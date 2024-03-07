using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.Seguranca.Forms;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmConferenciaPedido : FrmBase
    {
        #region OBJETOS SERVIÇOS

        private const string colNome_Data = "DATA_ATUALIZACAO";
        private const string colNome_QtdConf = "QTDE_CONFERIDA";
        //private const string colNome_QtdDif = "QTDE_DIFERENCA";
        private bool _permitePedidoOutroSetor = false;

        private RequisicaoDTO dtoRequisicao;
        private IRequisicao _requisicao;
        private IRequisicao Requisicao
        {
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject(typeof(IRequisicao)); }
        }
       
        private IRequisicaoItens _ReqItem;
        private IRequisicaoItens ReqItem
        {
            get { return _ReqItem != null ? _ReqItem : _ReqItem = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }

        private DataTable dtbMovimento;
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }

        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }

        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject(typeof(IEstoqueLocal)); }
        }        

        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        #endregion

        #region FUNÇÕES

        public FrmConferenciaPedido()
        {
            InitializeComponent();
        }

        private void ConfiguraItensDTG()
        {
            dtgMatMed.AutoGenerateColumns = false;
            dtgMatMed.Columns[colIdProduto.Name].DataPropertyName = MovimentacaoDTO.FieldNames.IdtProduto;
            dtgMatMed.Columns[colDescricao.Name].DataPropertyName = MovimentacaoDTO.FieldNames.DsProduto;
            dtgMatMed.Columns[colIdLote.Name].DataPropertyName = MovimentacaoDTO.FieldNames.IdtLote;
            dtgMatMed.Columns[colNumFabLote.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.NumLote;
            dtgMatMed.Columns[colQtdForn.Name].DataPropertyName = MovimentacaoDTO.FieldNames.Qtde;
            dtgMatMed.Columns[colQtdConf.Name].DataPropertyName = colNome_QtdConf;
            dtgMatMed.Columns[colData.Name].DataPropertyName = colNome_Data;
            dtgMatMed.Columns[colIdGrupo.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.IdtGrupo;
        }

        /// <summary>
        /// Retira o último caractere que é apenas de controle na geração do cod. de barra
        /// </summary>
        /// <returns></returns>
        private long ObterReqIdCodBarra()
        {
            return long.Parse(txtIdRequisicao.Text.Substring(0, txtIdRequisicao.Text.Length - 1));
        }

        private void CarregarRequisicao()
        {
            btnFinalizar.Visible = false;
            if (txtIdRequisicao.Enabled)
            {
                dtoRequisicao = new RequisicaoDTO();

                dtoRequisicao.Idt.Value = this.ObterReqIdCodBarra();
                dtoRequisicao = Requisicao.SelChave(dtoRequisicao);

                if (dtoRequisicao.Idt.Value.IsNull)
                {
                    MessageBox.Show("Pedido não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtIdRequisicao.Text = string.Empty;
                    txtIdRequisicao.Focus();
                    return;
                }

                if (dtoRequisicao.IdtTipoRequisicao.Value != (byte)RequisicaoDTO.TipoRequisicao.PADRAO)
                {
                    MessageBox.Show("Permitido apenas conferência de Pedido Padrão por esta funcionalidade", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtIdRequisicao.Text = string.Empty;
                    txtIdRequisicao.Focus();
                    return;
                }

                if (dtoRequisicao.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.RECEBIDA_UNIDADE)
                {
                    MessageBox.Show("Pedido já recebido", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtIdRequisicao.Text = string.Empty;
                    txtIdRequisicao.Focus();
                    return;
                }

                if (dtoRequisicao.Status.Value != (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX)
                {
                    MessageBox.Show("Pedido não dispensado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtIdRequisicao.Text = string.Empty;
                    txtIdRequisicao.Focus();
                    return;
                }

                if (!_permitePedidoOutroSetor &&
                    FrmPrincipal.dtoSeguranca.IdtSetor.Value.ToString() != dtoRequisicao.IdtSetor.Value.ToString())
                {
                    MessageBox.Show("Pedido não referente ao setor logado no sistema", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtIdRequisicao.Text = string.Empty;
                    txtIdRequisicao.Focus();
                    return;
                }
                if (!dtoRequisicao.DataDispensacao.Value.IsNull)
                {
                    if (DateTime.Parse(((DateTime)dtoRequisicao.DataDispensacao.Value).ToString("dd/MM/yyyy")) < Utilitario.ObterDataHoraServidor().Date.AddDays(-5))
                    {
                        MessageBox.Show("Itens só podem ser devolvidos em até 5 dias após a Dispensação.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtIdRequisicao.Text = string.Empty;
                        txtIdRequisicao.Focus();
                        return;
                    }
                }
            }           

            txtUnidade.Text = dtoRequisicao.DsUnidade.Value;
            txtLocal.Text = dtoRequisicao.DsLocal.Value;
            txtSetor.Text = dtoRequisicao.DsSetor.Value;
            txtIdRequisicao.Text = dtoRequisicao.Idt.Value;
            txtStatus.Text = Requisicao.RetornarStatus(dtoRequisicao);
            lblUsuarioReq.Text = dtoRequisicao.DsUsuarioRequisicao.Value;

            lblUsuarioDisp.Text = dtoRequisicao.DsUsuarioDispensacao.Value;
            lblDataDisp.Visible = true;
            txtDataDisp.Visible = true;
            if (!dtoRequisicao.DataDispensacao.Value.IsNull) txtDataDisp.Text = ((DateTime)dtoRequisicao.DataDispensacao.Value).ToString("dd/MM/yyyy à\\s HH:mm:ss");

            txtIdRequisicao.Enabled = txtCodProduto.Enabled = false;
            pnlUsuario.Visible = true;
            this.CarregaItens();

            if (dtbMovimento.Rows.Count > 0)
            {
                txtCodProduto.Enabled = true;
                txtCodProduto.Focus();
            }
        }

        private void CarregaItens()
        {
            this.Cursor = Cursors.WaitCursor;
            dtgMatMed.Enabled = true;

            MovimentacaoDTO dtoMov = new MovimentacaoDTO();            
            dtoMov.IdtRequisicao.Value = dtoRequisicao.Idt.Value;
            dtoMov.IdtSetor.Value = dtoRequisicao.IdtSetor.Value;
            
            dtbMovimento = Movimento.ObterEntradasPedidoProduto(dtoMov);
            dtbMovimento.Columns.Add(colNome_Data);
            dtbMovimento.Columns.Add(colNome_QtdConf);
            //dtbMovimento.Columns.Add(colNome_QtdDif);
            
            dtgMatMed.DataSource = dtbMovimento;
            this.Cursor = Cursors.Default;
        }

        private void ZerarObjetos()
        {
            dtoRequisicao = null;
            dtbMovimento = null;
            pnlUsuario.Visible = false;
            lblDataDisp.Visible = false;
            txtDataDisp.Visible = false;
            btnFinalizar.Visible = false;
            dtgMatMed.DataSource = dtbMovimento;
        }

        private bool ValidarProdutoRegra()
        {
            if (Convert.ToDecimal(dtoMatMed.IdtGrupo.Value) == 1 &&
                (dtoMatMed.IdtLote.Value.IsNull || (int)dtoMatMed.IdtLote.Value == 0))
            {
                MessageBox.Show("LOTE DO MEDICAMENTO NÃO IDENTIFICADO !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }            
            return true;
        }

        private void AdicionarQtd(int? qtdSubtrair)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {                
                DataRow[] rowExistente;
                if (Convert.ToDecimal(dtoMatMed.IdtGrupo.Value) == 1) //Buscar lote quando medicamento                
                    rowExistente = dtbMovimento.Select(string.Format("{0} = {1} AND {2} = {3}", MaterialMedicamentoDTO.FieldNames.Idt, dtoMatMed.Idt.Value,
                                                                                                MovimentacaoDTO.FieldNames.IdtLote, dtoMatMed.IdtLote.Value));                
                else                
                    rowExistente = dtbMovimento.Select(string.Format("{0} = {1}", MaterialMedicamentoDTO.FieldNames.Idt, dtoMatMed.Idt.Value));

                if (rowExistente.Length == 0)
                {
                    MessageBox.Show("Item não identificado no Pedido !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Cursor = Cursors.Default;
                    txtCodProduto.Text = string.Empty;
                    txtCodProduto.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(rowExistente[0][colNome_QtdConf].ToString()))
                    rowExistente[0][colNome_QtdConf] = 0;

                MovimentacaoDTO dtoQtd = new MovimentacaoDTO();
                if (qtdSubtrair == null)
                {
                    if (cbDigitar.Visible && cbDigitar.Checked)
                    {
                        dtoQtd.DsProduto.Value = dtoMatMed.Descricao.Value;
                        dtoQtd = FrmQtdMatMed.DigitaQtde(dtoQtd);

                        if (dtoQtd == null) dtoQtd = new MovimentacaoDTO();
                        if (dtoQtd.Qtde.Value.IsNull) dtoQtd.Qtde.Value = 0;

                        if (dtoQtd.Qtde.Value == 0)
                        {
                            //Cancela contagem
                            this.Cursor = Cursors.Default;
                            txtCodProduto.Text = string.Empty;
                            txtCodProduto.Focus();
                            return;
                        }
                    }
                    else
                        dtoQtd.Qtde.Value = 1;

                    int qtdNovaConf = int.Parse(rowExistente[0][colNome_QtdConf].ToString()) + (int)dtoQtd.Qtde.Value;
                    if (qtdNovaConf > int.Parse(rowExistente[0][MovimentacaoDTO.FieldNames.Qtde].ToString()))
                    {
                        MessageBox.Show("Qtd. Conferida não pode ser maior que a Qtd. Fornecida !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Cursor = Cursors.Default;
                        txtCodProduto.Text = string.Empty;
                        txtCodProduto.Focus();
                        return;
                    }

                    rowExistente[0][colNome_QtdConf] = qtdNovaConf;
                }
                else if (qtdSubtrair > 0)
                {
                    rowExistente[0][colNome_QtdConf] = int.Parse(rowExistente[0][colNome_QtdConf].ToString()) - qtdSubtrair.Value;
                }                

                rowExistente[0][colNome_Data] = Utilitario.ObterDataHoraServidor();
                dtbMovimento.AcceptChanges();
                dtgMatMed.DataSource = dtbMovimento;
                dtgMatMed.Sort(dtgMatMed.Columns[colData.Name], ListSortDirection.Descending);
                dtgMatMed.ClearSelection();
                btnFinalizar.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            this.Cursor = Cursors.Default;
        }

        private bool DevolverProduto(DataGridViewRow dtgRow)
        {
            MovimentacaoDTO dtoMov = new MovimentacaoDTO();           

            dtoMov.IdtFilial.Value = dtoRequisicao.IdtFilial.Value;
            dtoMov.IdtRequisicao.Value = dtoRequisicao.Idt.Value;

            dtoMov.IdtProduto.Value = decimal.Parse(dtgRow.Cells[colIdProduto.Name].Value.ToString());
            if (int.Parse(dtgRow.Cells[colIdGrupo.Name].Value.ToString()) == 1) //Atribuir lote a medicamento            
                dtoMov.IdtLote.Value = decimal.Parse(dtgRow.Cells[colIdLote.Name].Value.ToString());
            dtoMov.Qtde.Value = decimal.Parse(dtgRow.Cells[colQtdDif.Name].EditedFormattedValue.ToString());

            dtoMov.IdtTipo.Value = (byte)MovimentacaoDTO.TipoMovimento.ENTRADA;
            dtoMov.IdtTipoBaixa.Value = (byte)MovimentacaoDTO.TipoMovimento.SAIDA;
            dtoMov.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.TRANSFERENCIA_ENTRADA;
            dtoMov.IdtSubTipoBaixa.Value = (byte)MovimentacaoDTO.SubTipoMovimento.TRANSFERENCIA_SAIDA;
            dtoMov.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

            // unidade de baixa
            dtoMov.IdtUnidadeBaixa.Value = dtoRequisicao.IdtUnidade.Value;
            dtoMov.IdtLocalBaixa.Value = dtoRequisicao.IdtLocal.Value;
            dtoMov.IdtSetorBaixa.Value = dtoRequisicao.IdtSetor.Value;

            // unidade de entrada
            MovimentacaoDataTable dtbCentroDisp = Movimento.ObterCentroDispMovimentoPedido(dtoMov);
            if (dtbCentroDisp.Rows.Count > 0)
            {
                dtoMov.IdtUnidade.Value = dtbCentroDisp.TypedRow(0).IdtUnidade.Value;
                dtoMov.IdtLocal.Value = dtbCentroDisp.TypedRow(0).IdtLocal.Value;
                dtoMov.IdtSetor.Value = dtbCentroDisp.TypedRow(0).IdtSetor.Value;
            }
            else
            {
                MessageBox.Show("Item sem registro de baixa ativa no Centro de Dispensação para este pedido, impossibilitando a devolução.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            try
            {
                Movimento.TransfereEstoqueProduto(dtoMov);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void ProcessarDevolucao()
        {
            RequisicaoDTO dtoReqVerificar = new RequisicaoDTO();
            dtoReqVerificar.Idt.Value = dtoRequisicao.Idt.Value;
            dtoReqVerificar = Requisicao.SelChave(dtoReqVerificar);

            if (dtoReqVerificar.Status.Value != (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX)
            {
                MessageBox.Show("Pedido com Status diferente de Dispensado, provavelmente já deve ter sido recebido por outro processo.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnFinalizar.Visible = false;
                return;
            }

            bool conferido = false;
            bool itensDivergentes = false;
            int qtdEstoque = 0;
            EstoqueLocalDTO dtoEstoque = new EstoqueLocalDTO();

            dtoEstoque.IdtFilial.Value = dtoRequisicao.IdtFilial.Value;
            dtoEstoque.IdtUnidade.Value = dtoRequisicao.IdtUnidade.Value;
            dtoEstoque.IdtLocal.Value = dtoRequisicao.IdtLocal.Value;
            dtoEstoque.IdtSetor.Value = dtoRequisicao.IdtSetor.Value;

            foreach (DataGridViewRow dtgRow in dtgMatMed.Rows)
            {
                if (int.Parse(dtgRow.Cells[colQtdDif.Name].EditedFormattedValue.ToString()) > 0)
                {
                    dtoEstoque.IdtProduto.Value = int.Parse(dtgRow.Cells[colIdProduto.Name].Value.ToString());
                    if (int.Parse(dtgRow.Cells[colIdGrupo.Name].Value.ToString()) == 1) //Atribuir lote a medicamento
                        dtoEstoque.IdtLote.Value = dtgRow.Cells[colIdLote.Name].Value.ToString();

                    dtoEstoque = Estoque.EstoqueLocalProduto(dtoEstoque);
                    if (int.Parse(dtgRow.Cells[colIdGrupo.Name].Value.ToString()) == 1)
                        qtdEstoque = (int)dtoEstoque.QtdeLote.Value;
                    else
                        qtdEstoque = (int)dtoEstoque.Qtde.Value;

                    if (qtdEstoque < int.Parse(dtgRow.Cells[colQtdDif.Name].EditedFormattedValue.ToString()))
                    {
                        MessageBox.Show("DEVOLUÇÃO NÃO PROCESSADA!!!\n\nSaldo insuficiente para devolução do Item " + dtgRow.Cells[colDescricao.Name].Value.ToString(), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Cursor = Cursors.Default;
                        return;
                    }

                    itensDivergentes = true;
                }
            }

            if (itensDivergentes)
            {
                if (MessageBox.Show("Pedido com divergências neste recebimento. A quantidade divergente será devolvida para o Centro de Dispensação, deseja realmente finalizar esta conferência ?",
                                    "Gestão de Materiais e Medicamentos",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    string itensEmail = string.Empty;
                    foreach (DataGridViewRow dtgRow in dtgMatMed.Rows)
                    {
                        if (int.Parse(dtgRow.Cells[colQtdDif.Name].EditedFormattedValue.ToString()) > 0)
                        {
                            if (this.DevolverProduto(dtgRow))
                            {
                                itensEmail += "<BR><I>" + dtgRow.Cells[colIdProduto.Name].Value.ToString() + "</I> - " +
                                              dtgRow.Cells[colDescricao.Name].Value.ToString() + " - Qtde.: <B>" +
                                              dtgRow.Cells[colQtdDif.Name].EditedFormattedValue.ToString() + "</B>";
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(itensEmail))
                    {
                        itensEmail = "<HTML>PEDIDO: <B>" + dtoRequisicao.Idt.Value + "</B><BR>" +
                                     "SETOR: <B>" + dtoRequisicao.DsUnidade.Value + " / " + dtoRequisicao.DsSetor.Value + "</B><BR>" +
                                      itensEmail +
                                     "<P>ESTE E-MAIL FOI ENVIADO PELO SISTEMA DE GESTAO DE ESTOQUE (SGS)</HTML>";
                        Utilitario.EnviarEmail(Utilitario.EmailResponsavelAlmoxarifadoCentral(), itensEmail, "AVISO: DEVOLUCAO DE PEDIDO PADRAO");
                    }

                    this.Cursor = Cursors.Default;
                    conferido = true;
                }
            }
            else
            {
                if (MessageBox.Show("Pedido sem divergência no recebimento, deseja realmente finalizar esta conferência ?",
                                    "Gestão de Materiais e Medicamentos",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    conferido = true;
            }

            if (conferido)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.RECEBIDA_UNIDADE;
                    dtoRequisicao.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    Requisicao.Upd(dtoRequisicao);

                    tsHac.Controla(Evento.eSalvar);
                    txtCodProduto.Enabled = btnFinalizar.Enabled = dtgMatMed.Enabled = false;

                    MessageBox.Show("Conferência finalizada com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                }
            }
        }

        #endregion

        private void FrmConferenciaPedido_Load(object sender, EventArgs e)
        {
            this.ConfiguraItensDTG();
            _permitePedidoOutroSetor = new Generico().VerificaAcessoFuncionalidade("cmbSetor");
        }

        private bool tsHac_NovoClick(object sender)
        {
            tsHac.Controla(Evento.eNovo);
            this.ZerarObjetos();
            dtgMatMed.Enabled = true;
            txtIdRequisicao.Focus();
            return false;
        }

        private bool tsHac_CancelarClick(object sender)
        {
            this.ZerarObjetos();
            return true;
        }

        private void txtIdRequisicao_Validating(object sender, CancelEventArgs e)
        {
            if (txtIdRequisicao.Text != string.Empty) this.CarregarRequisicao();
        }

        private void txtCodProduto_Validating(object sender, CancelEventArgs e)
        {
            if (txtCodProduto.Text != string.Empty)
            {
                CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();
                dtoCodigoBarra.CdBarra.Value = txtCodProduto.Text;
                dtoCodigoBarra.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC;
                // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
                dtoMatMed = MatMed.BuscaCodigoBarra(dtoCodigoBarra);

                if (dtoMatMed == null)
                {
                    MessageBox.Show("Código não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodProduto.Text = string.Empty;
                    txtCodProduto.Focus();
                    return;
                }
                else if (!ValidarProdutoRegra())
                {
                    txtCodProduto.Text = string.Empty;
                    txtCodProduto.Focus();
                    return;
                }

                this.AdicionarQtd(null);
                txtCodProduto.Text = string.Empty;
                txtCodProduto.Focus();
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.ProcessarDevolucao();
            this.Cursor = Cursors.Default;
        }

        private void dtgMatMed_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dtgMatMed.Rows.Count > 0)
            {                
                if (dtgMatMed.Columns[e.ColumnIndex].Name == colQtdDif.Name)
                {
                    if (string.IsNullOrEmpty(dtgMatMed.Rows[e.RowIndex].Cells[colQtdConf.Name].Value.ToString()))
                        dtgMatMed.Rows[e.RowIndex].Cells[colQtdConf.Name].Value = 0;

                    e.Value = decimal.Parse(dtgMatMed.Rows[e.RowIndex].Cells[colQtdForn.Name].Value.ToString()) -
                              decimal.Parse(dtgMatMed.Rows[e.RowIndex].Cells[colQtdConf.Name].Value.ToString());

                    if (int.Parse(e.Value.ToString()) > 0)
                        dtgMatMed.Rows[e.RowIndex].Cells[colQtdDif.Name].Style.ForeColor = Color.Red;
                    else
                        dtgMatMed.Rows[e.RowIndex].Cells[colQtdDif.Name].Style.ForeColor = Color.Black;
                }
            }
        }

        private void dtgMatMed_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == dtgMatMed[colDel.Name, e.RowIndex].ColumnIndex)
                {
                    if (dtgMatMed.Rows[e.RowIndex].Cells[colIdProduto.Name].Value == null || dtgMatMed.Rows[e.RowIndex].Cells[colIdProduto.Name].Value.ToString() == string.Empty) return;
                    try
                    {
                        if (int.Parse(dtgMatMed.Rows[e.RowIndex].Cells[colQtdConf.Name].Value.ToString()) == 0)
                        {
                            MessageBox.Show("SEM QTDE. PARA SUBTRAÇÃO", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("SEM QTDE. PARA SUBTRAÇÃO", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    this.Cursor = Cursors.WaitCursor;

                    dtoMatMed = new MaterialMedicamentoDTO();
                    dtoMatMed.Idt.Value = dtgMatMed.Rows[e.RowIndex].Cells[colIdProduto.Name].Value.ToString();
                    dtoMatMed = MatMed.SelChave(dtoMatMed);
                    if (Convert.ToDecimal(dtoMatMed.IdtGrupo.Value) == 1) //Add. lote do medicamento
                        dtoMatMed.IdtLote.Value = dtgMatMed.Rows[e.RowIndex].Cells[colIdLote.Name].Value.ToString();

                    int qtdSubtrair = 1;
                    string mensagem = "Deseja realmente subtrair 1 unidade da conferência deste item ?";
                    //if (e.ColumnIndex == dtgMatMed[colZerar.Name, e.RowIndex].ColumnIndex)
                    //{
                    //    mensagem = "Deseja realmente zerar este item nesta contagem ?";
                    //    qtdSubtrair = int.Parse(dtgMatMed.Rows[e.RowIndex].Cells[colQtd.Name].Value.ToString());
                    //}

                    if (MessageBox.Show(mensagem, "Gestão de Materiais e Medicamentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.AdicionarQtd(qtdSubtrair);
                    }
                    txtCodProduto.Focus();
                }
                this.Cursor = Cursors.Default;
            }
        }  

        private void cbDigitar_Click(object sender, EventArgs e)
        {
            txtCodProduto.Focus();
        }              
    }
}