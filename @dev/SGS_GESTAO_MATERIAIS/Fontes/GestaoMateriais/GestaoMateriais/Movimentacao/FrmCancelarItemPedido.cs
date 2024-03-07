using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.GestaoMateriais;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Componentes;
using Microsoft.ReportingServices.ReportRendering;
using HospitalAnaCosta.SGS.GestaoMateriais.Relatorio;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmCancelarItemPedido : FrmBase
    {
        #region OBJETOS SERVIÇOS

        private SetorDTO dtoSetor;

        // MatMed
        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }

        // Atendimento
        private IPaciente _atendimento;
        private IPaciente Atendimento
        {
            get { return _atendimento != null ? _atendimento : _atendimento = (IPaciente)Global.Common.GetObject(typeof(IPaciente)); }
        }

        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }

        // Movimentos
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }

        // Estoque
        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject(typeof(IEstoqueLocal)); }
        }

        private IHistoricoNotaFiscal _histNF;
        private IHistoricoNotaFiscal HistoricoNotaFiscal
        {
            get { return _histNF != null ? _histNF : _histNF = (IHistoricoNotaFiscal)Global.Common.GetObject(typeof(IHistoricoNotaFiscal)); }
        }

        // Utilitario
        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        //Generico gen = new Generico();

        #endregion

        #region MÉTODOS

        public FrmCancelarItemPedido()
        {
            InitializeComponent();
        }

        private void CarregarComboSetorPaciente()
        {
            lblSetorOrigem.Visible = cmbSetorOrigem.Visible = true;
            this.Cursor = Cursors.WaitCursor;
            cmbSetorOrigem.DataSource = RequisicaoItens.SelPendenciasConsumoPacSetores(int.Parse(txtNroInternacao.Text));
            this.Cursor = Cursors.Default;
        }

        private void CarregaInfoPaciente()
        {
            DataTable dtPaciente = Atendimento.ObterPaciente(decimal.Parse(txtNroInternacao.Text));

            if (dtPaciente.Rows.Count > 0)
            {
                txtNomePac.Text = dtPaciente.Rows[0][1].ToString();
                txtNroInternacao.Enabled = false;

                if (txtDsProduto.Text != string.Empty && dtoMatMed != null && !dtoMatMed.Idt.Value.IsNull)
                    CarregarPedidosDevolucao(true, null, null);
            }
            else
            {
                MessageBox.Show("Paciente não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblSetorOrigem.Visible = cmbSetorOrigem.Visible = dtgTransfPac.Visible = false;
                txtNroInternacao.Text = txtNomePac.Text = string.Empty;
                txtNroInternacao.Enabled = true;
                txtNroInternacao.Focus();
            }
        }

        private bool _pacienteAnterior = false;
        private void CarregarPedidosDevolucao(bool atualizarGrid, int? numPedido, int? idLote)
        {
            _pacienteAnterior = false;
            if (!string.IsNullOrEmpty(txtNroInternacao.Text) && dtoMatMed != null)
            {
                this.Cursor = Cursors.WaitCursor;

                RequisicaoItensDataTable dtbReq = RequisicaoItens.SelPedidosReqItenPac(int.Parse(txtNroInternacao.Text), (int)dtoMatMed.Idt.Value, null);
                if (dtbReq.Rows.Count == 0)
                {
                    if (Atendimento.AnteriorControleConsumo(int.Parse(txtNroInternacao.Text)))
                    {
                        _pacienteAnterior = true;
                        dtbReq = RequisicaoItens.SelPedidosReqItenPac(int.Parse(txtNroInternacao.Text), (int)dtoMatMed.Idt.Value, null, (int)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX);
                        if (atualizarGrid && dtbReq.Rows.Count > 0)
                            MessageBox.Show("Paciente com Data de Atendimento anterior ao início do controle no setor.\n\nDevoluções liberadas sem verificação do consumo.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                if (atualizarGrid)
                {
                    dtgLotes.DataSource = null;
                    _selecionarPedido = false;
                    dtgPedidos.DataSource = dtbReq;
                    dtgPedidos.ClearSelection();
                    _selecionarPedido = true;
                    dtoSetor = null;
                }

                RequisicaoItensDataTable dtbPendenciaConsumo = RequisicaoItens.SelReqItensPendentesConsumoPac(int.Parse(txtNroInternacao.Text), (int)dtoMatMed.Idt.Value, null);

                lblQtdPendenteCons.Text = "0";
                if (dtbPendenciaConsumo.Rows.Count > 0)
                    lblQtdPendenteCons.Text = dtbPendenciaConsumo.Rows[0]["QTD_PENDENTE"].ToString();

                txtCodLote.Text = string.Empty;
                txtCodLote.Visible = false;
                lblLote.Visible = true;
                if (numPedido != null && dtbReq.Rows.Count > 0)
                {
                    if (dtbReq.Select("MTMD_REQ_ID = " + numPedido.Value.ToString()).Length > 0)
                    {
                        DataRow row = dtbReq.Select("MTMD_REQ_ID = " + numPedido.Value.ToString())[0];

                        lblEstLocal.Text = lblLote.Text = lblQtdTransf.Text = "---";
                        lblSetor.Text = row["CAD_SET_DS_SETOR"].ToString();
                        lblPedido.Text = numPedido.Value.ToString();
                        lblEstLocal.Text = row["MTMD_ESTLOC_QTDE"].ToString();                        

                        dtoSetor = new SetorDTO();
                        dtoSetor.Idt.Value = row[SetorDTO.FieldNames.Idt].ToString();
                        dtoSetor.IdtLocalAtendimento.Value = row[SetorDTO.FieldNames.IdtLocalAtendimento].ToString();
                        dtoSetor.IdtUnidade.Value = row[SetorDTO.FieldNames.IdtUnidade].ToString();

                        if (idLote != null)
                        {
                            MovimentacaoDTO dtoMovimento = new MovimentacaoDTO();
                            dtoMovimento.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC;
                            dtoMovimento.IdtRequisicao.Value = numPedido;
                            dtoMovimento.IdtProduto.Value = dtoMatMed.Idt.Value;
                            DataTable dtbLote = new DataView(Movimento.ObterEntradasCentroDispPedido(dtoMovimento),
                                                             idLote == 0 ? "MTMD_LOTEST_ID IS NULL OR MTMD_LOTEST_ID = 0" : string.Format("MTMD_LOTEST_ID = {0}", idLote),
                                                             string.Empty,
                                                             DataViewRowState.CurrentRows).ToTable();
                            if (dtbLote.Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(dtbLote.Rows[0][EstoqueLocalDTO.FieldNames.IdtLote].ToString()))
                                    dtoMatMed.IdtLote.Value = dtbLote.Rows[0][EstoqueLocalDTO.FieldNames.IdtLote].ToString();
                                else                                
                                    dtoMatMed.IdtLote.Value = new Framework.DTO.TypeDecimal();

                                #region Carregar Saldo Lote

                                EstoqueLocalDTO dtoEstoque = new EstoqueLocalDTO();

                                dtoEstoque.IdtUnidade.Value = dtoSetor.IdtUnidade.Value;
                                dtoEstoque.IdtLocal.Value = dtoSetor.IdtLocalAtendimento.Value;
                                dtoEstoque.IdtSetor.Value = dtoSetor.Idt.Value;
                                dtoEstoque.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC;
                                dtoEstoque.IdtProduto.Value = dtoMatMed.Idt.Value;
                                if (!dtoMatMed.IdtLote.Value.IsNull)
                                {
                                    lblLote.Text = dtbLote.Rows[0][EstoqueLocalDTO.FieldNames.CodLote].ToString();
                                    dtoEstoque.CodLote.Value = lblLote.Text;
                                }

                                EstoqueLocalDataTable dtbEstoque = Estoque.ListarEstoqueLote(dtoEstoque);
                                if (dtbEstoque.Rows.Count > 0 && !dtoMatMed.IdtLote.Value.IsNull)
                                    lblEstLocal.Text = dtbEstoque.TypedRow(0).QtdeLote.ToString();
                                else if (dtbEstoque.Rows.Count > 0)
                                {
                                    DataTable dtbEstSemLote = new DataView(dtbEstoque,
                                                                           string.Format("{0} = 'SEM_LOTE'", EstoqueLocalDTO.FieldNames.CodLote),
                                                                           string.Empty,
                                                                           DataViewRowState.CurrentRows).ToTable();
                                    if (dtbEstSemLote.Rows.Count > 0)
                                        lblEstLocal.Text = dtbEstSemLote.Rows[0][EstoqueLocalDTO.FieldNames.QtdeLote].ToString();
                                    else
                                        lblEstLocal.Text = "0";

                                    if (int.Parse(lblEstLocal.Text) == 0)
                                    {
                                        //MessageBox.Show("Baixa sem rastreabilidade e saldo SEM_LOTE zerado.\n\nDigite um lote com saldo para eliminar esta pendência.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        lblLote.Visible = false;
                                        txtCodLote.Visible = true;
                                        txtCodLote.Focus();
                                    }
                                }

                                #endregion

                                int qtdDevolvida = int.Parse(dtbLote.Rows[0]["MTMD_MOV_QTDE_DEV"].ToString());
                                int qtdForn = int.Parse(dtbLote.Rows[0][MovimentacaoDTO.FieldNames.Qtde].ToString()) - qtdDevolvida;

                                if (qtdForn > int.Parse(row["MTMD_REQITEM_QTD_FORNECIDA"].ToString()))
                                    qtdForn = int.Parse(row["MTMD_REQITEM_QTD_FORNECIDA"].ToString());

                                if (!_pacienteAnterior)
                                {
                                    if (qtdForn > int.Parse(lblQtdPendenteCons.Text))
                                        lblQtdTransf.Text = lblQtdPendenteCons.Text;
                                    else
                                        lblQtdTransf.Text = qtdForn.ToString();
                                }
                                else
                                    lblQtdTransf.Text = qtdForn.ToString();
                            }                            
                        }
                    }
                }
                else
                    lblEstLocal.Text = lblPedido.Text = lblLote.Text = lblQtdTransf.Text = lblSetor.Text = "---";

                this.Cursor = Cursors.Default;
            }
        }

        private void CarregarLotes(int numPedido)
        {
            if (dtoMatMed != null)
            {
                this.Cursor = Cursors.WaitCursor;
                MovimentacaoDTO dtoMovimento = new MovimentacaoDTO();
                dtoMovimento.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC;
                dtoMovimento.IdtRequisicao.Value = numPedido;
                dtoMovimento.IdtProduto.Value = dtoMatMed.Idt.Value;
                dtgLotes.DataSource = Movimento.ObterEntradasCentroDispPedido(dtoMovimento);
                //CarregarPedidosDevolucao(false, numPedido, null);
                this.Cursor = Cursors.Default;
            }
        }

        private void AtualizarGridLote()
        {
            if (dtgPedidos.CurrentRow != null && dtgLotes.CurrentRow != null)
            {
                if (string.IsNullOrEmpty(dtgLotes.CurrentRow.Cells[colIdLote.Name].Value.ToString()))
                    CarregarPedidosDevolucao(false,
                                             int.Parse(dtgPedidos.CurrentRow.Cells[colIdReq.Name].Value.ToString()),
                                             0);
                else
                    CarregarPedidosDevolucao(false,
                                             int.Parse(dtgPedidos.CurrentRow.Cells[colIdReq.Name].Value.ToString()),
                                             int.Parse(dtgLotes.CurrentRow.Cells[colIdLote.Name].Value.ToString()));
            }
        }

        private void LimparLabels()
        {            
            lblSetorOrigem.Visible = cmbSetorOrigem.Visible = dtgTransfPac.Visible = grbTransf.Visible = txtQtdTransf.Visible = false;
            dtgPedidos.Visible = dtgLotes.Visible = lblQtdTransf.Visible = txtIdProduto.Enabled = btnDevolver.Enabled = true;
            lblEstLocal.Text = lblPedido.Text = lblLote.Text = lblQtdTransf.Text = lblSetor.Text = lblQtdPendenteCons.Text = "---";
            dtgTransfPac.DataSource = null; dtgLotes.DataSource = null;
        }

        private void AtribuirDestinoAlmox()
        {
            cmbUnidadeDestino.SelectedValue = 244;
            cmbLocalDestino.SelectedValue = 33;
            
            //Não será mais padrão após a implantação da FARMÁCIA///////////////
            //cmbSetorDestino.SelectedValue = 29; //Almoxarifado como padrão
        }
                    
        private bool ValidarTransfPac()
        {
            if (cmbSetorDestino.SelectedIndex == -1)
            {
                MessageBox.Show("Setor Destino deve estar preenchido", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (int.Parse(cmbLocalDestino.SelectedValue.ToString()) != (int)PacienteDTO.LocalAtendimento.INTERNADO)
            {
                MessageBox.Show("Local de Destino tem que ser INTERNADO.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private bool TransferirItem()
        {
            if (decimal.Parse(lblQtdTransf.Text) == 0)
            {
                MessageBox.Show("Qtd. Transf. deve ser maior que 0", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            this.Cursor = Cursors.WaitCursor;
            MovimentacaoDTO dtoMovimento = new MovimentacaoDTO();

            // unidade de baixa
            dtoMovimento.IdtUnidadeBaixa.Value = dtoSetor.IdtUnidade.Value;
            dtoMovimento.IdtLocalBaixa.Value = dtoSetor.IdtLocalAtendimento.Value;
            dtoMovimento.IdtSetorBaixa.Value = dtoSetor.Idt.Value;

            // unidade de entrada
            dtoMovimento.IdtUnidade.Value = cmbUnidadeDestino.SelectedValue.ToString();
            dtoMovimento.IdtLocal.Value = cmbLocalDestino.SelectedValue.ToString();
            dtoMovimento.IdtSetor.Value = cmbSetorDestino.SelectedValue.ToString();

            dtoMovimento.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC;
            dtoMovimento.IdtRequisicao.Value = lblPedido.Text;
            dtoMovimento.IdtAtendimento.Value = txtNroInternacao.Text;

            dtoMovimento.IdtProduto.Value = dtoMatMed.Idt.Value;
            if (!dtoMatMed.IdtLote.Value.IsNull && (decimal)dtoMatMed.IdtLote.Value != 0) dtoMovimento.IdtLote.Value = dtoMatMed.IdtLote.Value;
            dtoMovimento.Qtde.Value = lblQtdTransf.Text;
            dtoMovimento.IdtTipo.Value = (byte)MovimentacaoDTO.TipoMovimento.ENTRADA;
            dtoMovimento.IdtTipoBaixa.Value = (byte)MovimentacaoDTO.TipoMovimento.SAIDA;
            dtoMovimento.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.TRANSFERENCIA_ENTRADA;
            dtoMovimento.IdtSubTipoBaixa.Value = (byte)MovimentacaoDTO.SubTipoMovimento.TRANSFERENCIA_SAIDA;
            dtoMovimento.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

            try
            {
                Movimento.TransfereEstoqueProduto(dtoMovimento);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return false;
            }
            this.Cursor = Cursors.Default;
            return true;
        }

        private void AjustarCaracteresCodLote()
        {
            if (!string.IsNullOrEmpty(txtCodLote.Text) && txtCodLote.Text.Length < 4)
                txtCodLote.Text = txtCodLote.Text.PadLeft(4, '0');
        }

        private void CarregarLote()
        {
            this.Cursor = Cursors.WaitCursor;
            HistoricoNotaFiscalDTO dtoHistNF = new HistoricoNotaFiscalDTO();

            dtoHistNF.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
            dtoHistNF.IdtProduto.Value = dtoMatMed.Idt.Value;

            AjustarCaracteresCodLote();
            dtoHistNF.CodLote.Value = txtCodLote.Text;            

            HistoricoNotaFiscalDataTable dtbHistNF = HistoricoNotaFiscal.Sel(dtoHistNF);

            lblEstLocal.Text = "0";
            dtoMatMed.IdtLote.Value = new Framework.DTO.TypeDecimal();
            if (dtbHistNF.Rows.Count > 0)
            {
                dtoHistNF = dtbHistNF.TypedRow(0);
                if (dtoHistNF.IdtLote.Value.IsNull)
                {
                    MessageBox.Show("Lote não encontrado em nenhuma NF", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodLote.Focus();
                    return;
                }
                dtoMatMed.IdtLote.Value = dtoHistNF.IdtLote.Value;

                txtCodLote.Text = dtoHistNF.CodLote.Value;                

                EstoqueLocalDTO dtoEstoque = new EstoqueLocalDTO();
                dtoEstoque.IdtProduto.Value = dtoMatMed.Idt.Value;
                dtoEstoque.CodLote.Value = txtCodLote.Text;
                dtoEstoque.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
                dtoEstoque.IdtUnidade.Value = dtoSetor.IdtUnidade.Value;
                dtoEstoque.IdtLocal.Value = dtoSetor.IdtLocalAtendimento.Value;
                dtoEstoque.IdtSetor.Value = dtoSetor.Idt.Value;
                DataTable dtbEstoque = new DataView(Estoque.ListarEstoqueLote(dtoEstoque),
                                                    string.Format("{0} <> 'SEM_LOTE'", EstoqueLocalDTO.FieldNames.CodLote),
                                                    string.Empty,
                                                    DataViewRowState.CurrentRows).ToTable();
                if (dtbEstoque.Rows.Count > 0)
                    lblEstLocal.Text = dtbEstoque.Rows[0][EstoqueLocalDTO.FieldNames.QtdeLote].ToString();
            }            

            if (int.Parse(lblEstLocal.Text) == 0)
            {
                MessageBox.Show("Lote sem saldo no momento", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodLote.Text = string.Empty;
                txtCodLote.Focus();
            }

            this.Cursor = Cursors.Default;
        }
        
        #endregion

        #region EVENTOS

        private void FrmCancelarItemPedido_Load(object sender, EventArgs e)
        {
            dtgPedidos.AutoGenerateColumns = dtgLotes.AutoGenerateColumns =  dtgTransfPac.AutoGenerateColumns = false;
            cmbUnidadeDestino.Carregaunidade();
            AtribuirDestinoAlmox();
            txtNroInternacao.Focus();
        }        

        private bool tsHac_LimparClick(object sender)
        {
            return true;
        }

        private void tsHac_AfterLimpar(object sender)
        {
            dtoMatMed = null; dtoSetor = null; _qtdTransfEdit = null;
            _pacienteAnterior = false;
            LimparLabels();
            AtribuirDestinoAlmox();
            txtNroInternacao.Focus();
        }

        private void txtNroInternacao_Validating(object sender, CancelEventArgs e)
        {
            if (txtNroInternacao.Text.Length != 0)
                btnPesquisaPac_Click(sender, e);  
            else
                txtNomePac.Text = string.Empty;
        }

        private void txtIdProduto_Validating(object sender, CancelEventArgs e)
        {
            if (txtIdProduto.Text != string.Empty)
            {
                dtoMatMed = new MaterialMedicamentoDTO();
                dtoMatMed.Idt.Value = txtIdProduto.Text;
                dtoMatMed = MatMed.SelChave(dtoMatMed);
                if (dtoMatMed == null)
                {
                    MessageBox.Show("Material/medicamento não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtIdProduto.Text = txtDsProduto.Text = string.Empty;
                    LimparLabels();
                    dtgPedidos.DataSource = null;
                    dtgLotes.DataSource = null;
                    txtIdProduto.Focus();
                    return;
                }
                txtDsProduto.Text = string.Format("{0}", dtoMatMed.NomeFantasia.Value);

                if (txtNroInternacao.Text != string.Empty && txtNomePac.Text != string.Empty)
                    CarregarPedidosDevolucao(true, null, null);
            }
            else if (txtIdProduto.Enabled)
            {
                dtoMatMed = null; dtoSetor = null;
                _pacienteAnterior = false;
                txtDsProduto.Text = string.Empty;
                LimparLabels();
                dtgPedidos.DataSource = null;
                dtgLotes.DataSource = null;
            }
        }

        private void txtLote_Validating(object sender, CancelEventArgs e)
        {
            if (dtoMatMed != null && txtCodLote.Text != string.Empty)
            {
                CarregarLote();
            }            
        }

        private void txtQtdTransf_Validating(object sender, CancelEventArgs e)
        {
            if (txtQtdTransf.Text != string.Empty)                
            {
                this.Cursor = Cursors.WaitCursor;
                
                if (int.Parse(txtQtdTransf.Text) > _qtdTransfEdit)
                    txtQtdTransf.Text = _qtdTransfEdit.Value.ToString();

                txtQtdTransf.Visible = false;
                lblQtdTransf.Visible = true;

                lblQtdTransf.Text = txtQtdTransf.Text;
                btnDevolver.Focus();
                _qtdTransfEdit = null;

                this.Cursor = Cursors.Default;
            }
            else if (txtQtdTransf.Text == string.Empty)
            {
                _qtdTransfEdit = null;
                txtQtdTransf.Visible = false;
                lblQtdTransf.Visible = true;
            }
        }

        private int? _qtdTransfEdit;
        private void lblQtdTransf_DoubleClick(object sender, EventArgs e)
        {
            _qtdTransfEdit = null;
            if (lblQtdTransf.Text != "---")
            {
                if (int.Parse(lblQtdTransf.Text) > 0)
                {
                    lblQtdTransf.Visible = false;
                    txtQtdTransf.Visible = true;
                    txtQtdTransf.Text = lblQtdTransf.Text;
                    _qtdTransfEdit = int.Parse(lblQtdTransf.Text);
                    txtQtdTransf.Focus();
                }
            }
        }

        private void btnPesquisaProd_Click(object sender, EventArgs e)
        {
            txtIdProduto_Validating(sender, null);
        }

        private void btnPesquisaPac_Click(object sender, EventArgs e)
        {
            if (txtNroInternacao.Enabled)
                CarregaInfoPaciente();
        }        

        private void btnDevolver_Click(object sender, EventArgs e)
        {            
            if (grbTransf.Visible) return;
            if (txtQtdTransf.Visible) txtQtdTransf_Validating(null, null);
            if (lblQtdPendenteCons.Text.IndexOf('-') > -1) lblQtdPendenteCons.Text = "0";
            if (dtoSetor != null && (txtNroInternacao.Text != string.Empty && txtNomePac.Text != string.Empty) &&
                (txtDsProduto.Text != string.Empty && dtoMatMed != null && !dtoMatMed.Idt.Value.IsNull))
            {
                if (decimal.Parse(lblQtdPendenteCons.Text) == 0 && !_pacienteAnterior)
                {
                    MessageBox.Show("Item sem pendência de consumo para este paciente", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (cmbSetorDestino.SelectedIndex == -1)
                {
                    MessageBox.Show("Setor Destino deve estar preenchido", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (txtCodLote.Visible && txtCodLote.Text == string.Empty)
                {
                    MessageBox.Show("Lote não informado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodLote.Focus();
                    return;
                }
                else if (txtCodLote.Visible && dtoMatMed.IdtLote.Value.IsNull)
                {
                    MessageBox.Show("Lote válido não informado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodLote.Focus();
                    return;
                }
                if (lblQtdTransf.Text.IndexOf('-') > -1)
                {
                    MessageBox.Show("Qtd. Transf. não informada", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (decimal.Parse(lblQtdTransf.Text) == 0)
                {
                    MessageBox.Show("Qtd. Transf. deve ser maior que 0", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (MessageBox.Show("Deseja realmente devolver este item ?", "Gestão de Materiais e Medicamentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int qtdTransf = int.Parse(lblQtdTransf.Text);
                    if (!_pacienteAnterior && !txtCodLote.Visible) AtualizarGridLote();
                    if (qtdTransf > int.Parse(lblQtdTransf.Text))
                    {
                        MessageBox.Show("Qtd. Transf. não pode ser maior que " + lblQtdTransf.Text, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    lblQtdTransf.Text = qtdTransf.ToString();
                    if (TransferirItem())
                    {                        
                        MessageBox.Show("Item devolvido com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CarregarPedidosDevolucao(true, null, null);
                    }
                }
            }
            else
                MessageBox.Show("Paciente/Produto/Pedido devem estar carregados", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void cmbLocalDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSetorOrigem.Visible && cmbSetorOrigem.SelectedIndex != -1 && 
                cmbLocalDestino.SelectedIndex != -1 && cmbSetorDestino.DataSource != null)
            {                
                try
                {
                    SetorDataTable dtbSetor = (SetorDataTable)cmbSetorDestino.DataSource;
                    if (dtbSetor.Rows.Count > 0)
                    {
                        dtbSetor.Rows.Remove(dtbSetor.Select(string.Format("{0}={1}", SetorDTO.FieldNames.Idt, cmbSetorOrigem.SelectedValue))[0]);
                        cmbSetorDestino.IniciaLista();
                    }
                }
                catch { return; }
            }
        }

        private bool _selecionarPedido = true;
        private void dtgPedidos_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgPedidos.Rows.Count > 0 && _selecionarPedido)
                CarregarLotes(int.Parse(dtgPedidos.CurrentRow.Cells[colIdReq.Name].Value.ToString()));
        }

        private void dtgLotes_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgLotes.Rows.Count > 0 && dtgPedidos.Rows.Count > 0)
                AtualizarGridLote();
        }

        #region PROCESSOS DE TRANSFERÊNCIA DE PACIENTE

        private void cmbSetorOrigem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((txtNroInternacao.Text != string.Empty && txtNomePac.Text != string.Empty) &&
                cmbSetorOrigem.SelectedValue != null && cmbSetorOrigem.SelectedIndex >= 0)
            {
                this.Cursor = Cursors.WaitCursor;
                dtgTransfPac.DataSource = RequisicaoItens.SelReqItensLotesPendentesConsumoPac(int.Parse(txtNroInternacao.Text), int.Parse(cmbSetorOrigem.SelectedValue.ToString()));                
                cmbUnidadeDestino.SelectedValue = 244;
                cmbLocalDestino.IniciaLista();
                cmbLocalDestino.SelectedValue = (int)PacienteDTO.LocalAtendimento.INTERNADO;
                this.Cursor = Cursors.Default;
            }
        }

        private void tsTransferirPaciente_Click(object sender, EventArgs e)
        {
            if (txtNroInternacao.Text != string.Empty && txtNomePac.Text != string.Empty)
            {                
                this.Cursor = Cursors.WaitCursor;

                dtgPedidos.DataSource = null; dtgLotes.DataSource = null;                
                if (lblPedido.Text != "---") LimparLabels();

                CarregarComboSetorPaciente();

                dtoMatMed = null;
                _pacienteAnterior = false;
                txtIdProduto.Text = txtDsProduto.Text = string.Empty;

                if (cmbSetorOrigem.Items.Count > 0)
                {                    
                    dtgTransfPac.Visible = grbTransf.Visible = true;
                    dtgPedidos.Visible = dtgLotes.Visible = txtIdProduto.Enabled = btnDevolver.Enabled = false;
                }
                else
                {
                    lblSetorOrigem.Visible = cmbSetorOrigem.Visible = false;                    
                    MessageBox.Show("Paciente sem pendências.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                this.Cursor = Cursors.Default;
            }
            else
            {
                dtgTransfPac.Visible = grbTransf.Visible = false;
                dtgPedidos.Visible = dtgLotes.Visible = txtIdProduto.Enabled = btnDevolver.Enabled = true;
            }
        }

        private void dtgTransfPac_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgTransfPac.Rows.Count > 0)                
            {
                if (dtgTransfPac.Columns[e.ColumnIndex].Name == colQtdEstoqueOrigem.Name)
                {
                    if (int.Parse(dtgTransfPac.Rows[e.RowIndex].Cells[colQtdTransf.Name].Value.ToString()) >
                        int.Parse(dtgTransfPac.Rows[e.RowIndex].Cells[colQtdEstoqueOrigem.Name].Value.ToString()))
                    {
                        e.CellStyle.SelectionBackColor = Color.Red;
                        e.CellStyle.BackColor = Color.Red;
                    }
                }
                else if (dtgTransfPac.Columns[e.ColumnIndex].Name == colQtdTransf.Name)
                    e.CellStyle.Font = new Font(dtgTransfPac.Font, FontStyle.Bold);     
            }            
        }

        private void btnCancelarTransf_Click(object sender, EventArgs e)
        {            
            LimparLabels();
            AtribuirDestinoAlmox();
            txtIdProduto.Focus();
        }

        private void btnProcessarTransf_Click(object sender, EventArgs e)
        {
            if (dtgTransfPac.Rows.Count == 0) return;
            this.Cursor = Cursors.WaitCursor;
            if (ValidarTransfPac())
            {
                if (MessageBox.Show("Deseja realmente transferir todas as pendências deste paciente para " + cmbSetorDestino.Text + "?", "Gestão de Materiais e Medicamentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RequisicaoDTO dtoRequisicao = new RequisicaoDTO();
                    dtoRequisicao.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                    dtoRequisicao.IdtUnidade.Value = cmbUnidadeDestino.SelectedValue.ToString();
                    dtoRequisicao.IdtSetor.Value = cmbSetorDestino.SelectedValue.ToString();
                    dtoRequisicao.IdtLocal.Value = cmbLocalDestino.SelectedValue.ToString();
                    dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.RECEBIDA_UNIDADE;
                    dtoRequisicao.IdtTipoRequisicao.Value = (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO;
                    dtoRequisicao.IdtAtendimento.Value = txtNroInternacao.Text;
                    dtoRequisicao.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                    int? idSetorFarmacia = new Generico().ObterFarmaciaSetor((int)dtoRequisicao.IdtSetor.Value);
                    if (idSetorFarmacia != null)
                        dtoRequisicao.SetorFarmacia.Value = idSetorFarmacia;

                    string mensagem;
                    if (RequisicaoItens.TransferirPacienteSetor(dtoRequisicao, int.Parse(cmbSetorOrigem.SelectedValue.ToString()), out mensagem))
                    {
                        MessageBox.Show("Transferência do Paciente realizada com sucesso!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //dtgTransfPac.DataSource = RequisicaoItens.SelReqItensLotesPendentesConsumoPac(int.Parse(txtNroInternacao.Text), int.Parse(cmbSetorOrigem.SelectedValue.ToString()));
                        btnCancelarTransf_Click(sender, e);
                    }
                    else
                        MessageBox.Show(mensagem, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            this.Cursor = Cursors.Default;
        }

        #endregion

        #endregion
    }
}