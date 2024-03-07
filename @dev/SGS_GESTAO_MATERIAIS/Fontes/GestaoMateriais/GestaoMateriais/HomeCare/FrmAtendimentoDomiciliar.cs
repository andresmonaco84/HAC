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

namespace HospitalAnaCosta.SGS.GestaoMateriais.HomeCare
{
    public partial class FrmAtendimentoDomiciliar : FrmBase
    {        
        public FrmAtendimentoDomiciliar()
        {
            InitializeComponent();
        }

        private bool ESTOQUE_UNIFICADO_HAC = false;

        #region Objetos Serviço

        // Atendimento
        private PacienteDTO dtoAtendimento;
        private IPaciente _atendimento;
        private IPaciente Atendimento
        {
            get { return _atendimento != null ? _atendimento : _atendimento = (IPaciente)Global.Common.GetObject(typeof(IPaciente)); }
        }

        // Movimentos
        private MovimentacaoDTO dtoMovimento;
        private MovimentacaoDataTable dtbMovimento = new MovimentacaoDataTable();
        private MovimentacaoDataTable dtbHistMovimento = new MovimentacaoDataTable();
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }

        // MatMed        
        private MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }
        
        // Itens Requisição
        private RequisicaoItensDTO dtoRequisicaoItem;
        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }

        // Requisição
        private IRequisicao _requisicao;
        private IRequisicao Requisicao
        {
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject(typeof(IRequisicao)); }
        }

        private IMatMedSetorConfig _matMedConfig;
        private IMatMedSetorConfig MatMedSetorConfig
        {
            get { return _matMedConfig != null ? _matMedConfig : _matMedConfig = (IMatMedSetorConfig)Global.Common.GetObject(typeof(IMatMedSetorConfig)); }
        }

        // Utilitario
        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        private Generico gen = new Generico();

        #endregion

        #region Metodos

        private void ConfiguraDTG()
        {
            dtgHistConsumo.AutoGenerateColumns = false;
            dtgHistConsumo.Columns["colDeletarHist"].Visible = false;
            dtgHistConsumo.Columns[colIdReqMov.Name].DataPropertyName = MovimentacaoDTO.FieldNames.IdtRequisicao;
            dtgHistConsumo.Columns["colIdtMovimentoHist"].DataPropertyName = MovimentacaoDTO.FieldNames.Idt;
            dtgHistConsumo.Columns["colIdtProdutoHist"].DataPropertyName = MovimentacaoDTO.FieldNames.IdtProduto;
            dtgHistConsumo.Columns["colDsProdutoHist"].DataPropertyName = MovimentacaoDTO.FieldNames.DsProduto;
            dtgHistConsumo.Columns["colDataHist"].DataPropertyName = MovimentacaoDTO.FieldNames.DataMovimento;            
            dtgHistConsumo.Columns["colDataHist"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dtgHistConsumo.Columns["colQtdHist"].DataPropertyName = MovimentacaoDTO.FieldNames.DsQtdeConsumo;
            dtgHistConsumo.Columns["colQtdHist"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgHistConsumo.Columns["colQtdInteiraHist"].DataPropertyName = MovimentacaoDTO.FieldNames.Qtde;
            dtgHistConsumo.Columns["colFaturado"].DataPropertyName = MovimentacaoDTO.FieldNames.FlFaturado;
            dtgHistConsumo.Columns["colDataRessup"].DataPropertyName = MovimentacaoDTO.FieldNames.DataRessupri;
            dtgHistConsumo.Columns["colIdFilial"].DataPropertyName = MovimentacaoDTO.FieldNames.IdtFilial;
            dtgHistConsumo.Columns["colDsQtdeConvertida"].DataPropertyName = MovimentacaoDTO.FieldNames.DsQtdConvertida;
            dtgHistConsumo.Columns["colDsQtdeConvertida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgHistConsumo.Columns["colSubTpMov"].DataPropertyName = MovimentacaoDTO.FieldNames.IdtSubTipo;
            dtgHistConsumo.Columns[colMAVHist.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia;
            dtgHistConsumo.Columns[colIdLote.Name].DataPropertyName = MovimentacaoDTO.FieldNames.IdtLote;
            dtgHistConsumo.Sort(dtgHistConsumo.Columns["colDataHist"], ListSortDirection.Descending);
            dtgHistConsumo.Columns[colLoteFab.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.NumLote;

            dtgGerarProtocolo.AutoGenerateColumns = false;
            dtgGerarProtocolo.Columns[colIdtMovimentoProt.Name].DataPropertyName = MovimentacaoDTO.FieldNames.Idt;
            dtgGerarProtocolo.Columns[colIdtProdutoProt.Name].DataPropertyName = MovimentacaoDTO.FieldNames.IdtProduto;
            dtgGerarProtocolo.Columns[colDataConsumoProt.Name].DataPropertyName = MovimentacaoDTO.FieldNames.DataMovimento;
            dtgGerarProtocolo.Columns[colProdutoDscProt.Name].DataPropertyName = MovimentacaoDTO.FieldNames.DsProduto;
            dtgGerarProtocolo.Columns[colQtdConsumoProt.Name].DataPropertyName = MovimentacaoDTO.FieldNames.Qtde;     
        }

        private void ConfiguraItensPendentesDTG()
        {
            dtgItensPendentes.AutoGenerateColumns = false;
            dtgItensPendentes.Columns[colIdReq.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.Idt;
            dtgItensPendentes.Columns["colMatMedIdtPend"].DataPropertyName = RequisicaoItensDTO.FieldNames.IdtProduto;
            dtgItensPendentes.Columns["colDsMatMedPend"].DataPropertyName = RequisicaoItensDTO.FieldNames.DsProduto;
            dtgItensPendentes.Columns["colQtdReqPend"].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdSolicitada;
            dtgItensPendentes.Columns["colQtdReqPend"].DefaultCellStyle.Format = "N0";
            dtgItensPendentes.Columns["colQtdFornPend"].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdFornecida;
            dtgItensPendentes.Columns["colQtdFornPend"].DefaultCellStyle.Format = "N0";
            dtgItensPendentes.Columns["colQtdPendente"].DefaultCellStyle.Format = "N0";
            dtgItensPendentes.Columns[colMAV.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia;
            dtgItensPendentes.Columns[colIdGrupo.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.IdtGrupo;
        }

        private void ConfiguraMovimentoDTO()
        {
            dtoMovimento = new MovimentacaoDTO();
            dtoMovimento.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoMovimento.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoMovimento.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            //dtoMovimento.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC; //(decimal)FilialMatMedDTO.Filial.ACS;
            //if (ESTOQUE_UNIFICADO_HAC)
            //    dtoMovimento.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            //else
            //    dtoMovimento.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
            dtoMovimento.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            dtoMovimento.FlEstornado.Value = (int)MovimentacaoDTO.Estornado.NAO;
            dtoMovimento.IdtAtendimento.Value = dtoAtendimento.Idt.Value;
            dtoMovimento.TpAtendimento.Value = "I";
        }

        private void AtribuirEstoqueUnico()
        {
            MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();

            dtoCfg.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoCfg.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoCfg.Idtsetor.Value = cmbSetor.SelectedValue.ToString();

            dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);

            if (dtoCfg.EstoqueUnificadoHAC.Value.IsNull) dtoCfg.EstoqueUnificadoHAC.Value = 0;
            if (dtoCfg.EstoqueUnificadoHAC.Value == 1) ESTOQUE_UNIFICADO_HAC = true;
        }
        
        private void CarregarHistoricoConsumo()
        {
            this.Cursor = Cursors.WaitCursor;
            dtbHistMovimento.Rows.Clear();
            dtbMovimento.Rows.Clear();            
            ConfiguraMovimentoDTO();
            dtoMovimento.IdtFilial.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
            dtoMovimento.TpAtendimento.Value = "I";            
            dtbHistMovimento = Movimento.HistoricoConsumoPaciente(dtoMovimento);            
            dtgHistConsumo.DataSource = dtbHistMovimento;
            dtgHistConsumo.Columns["colDeletarHist"].Visible = txtCodProduto.Enabled;
            this.Cursor = Cursors.Default;
        }

        private void CarregaInfoPaciente()
        {
            dtoAtendimento = new PacienteDTO();
            dtoAtendimento.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoAtendimento.IdtLocalAtendimento.Value = cmbLocal.SelectedValue.ToString();
            dtoAtendimento.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoAtendimento.TpAtendimento.Value = "I";
            
            if (txtNroInternacao.Text != string.Empty)
                dtoAtendimento.Idt.Value = Convert.ToInt64(txtNroInternacao.Text);
            try
            {
                dtoAtendimento = gen.ObterPaciente(dtoAtendimento);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }            

            if (!dtoAtendimento.NmPaciente.Value.IsNull)
            {
                FilialMatMedDTO dtoFilial = new FilialMatMedDTO();
                txtNomePac.Text = dtoAtendimento.NmPaciente.Value;
                txtNroInternacao.Text = dtoAtendimento.Idt.Value.ToString();
                
                dtoFilial.TpPlano.Value = dtoAtendimento.TpPlano.Value;                

                txtNroInternacao.Enabled = false;
                cmbUnidade.Enabled = false;
                cmbLocal.Enabled = false;
                cmbSetor.Enabled = false;                
                dtbMovimento.Clear();

                txtCodProduto.Enabled = !gen.VerificaAcessoFuncionalidade("SoLeituraConsumo");
                if (txtCodProduto.Enabled) txtCodProduto.Focus();
            }
        }

        private void CarregarItensPendentes(bool mostrarMensagem)
        {            
            this.Cursor = Cursors.WaitCursor;            
            RequisicaoDTO dtoReqItemPend = new RequisicaoDTO();
            dtoReqItemPend.IdtAtendimento.Value = dtoAtendimento.Idt.Value;            
            RequisicaoItensDataTable dtbReqItemPend = RequisicaoItens.SelReqItensPendentes(dtoReqItemPend);            
            if (dtbReqItemPend.Rows.Count > 0)
            {
                dtgItensPendentes.DataSource = dtbReqItemPend;
                pnlPendentes.Visible = true;
                btnFecharPendentes.Visible = true;                
            }
            else
            {
                if (mostrarMensagem)
                    MessageBox.Show("Não existem itens pendentes pedidos para este paciente", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodProduto.Focus();
            }
            this.Cursor = Cursors.Default;
        }

        private bool BuscarProduto()
        {
            ConfiguraMovimentoDTO();
            dtoMovimento.CdBarra.Value = txtCodProduto.Text;

            if (dtoMatMed == null)
            {
                CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();

                dtoCodigoBarra.CdBarra.Value = dtoMovimento.CdBarra.Value;
                dtoCodigoBarra.IdtFilial.Value = dtoMovimento.IdtFilial.Value;

                // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
                dtoMatMed = MatMed.BuscaCodigoBarra(dtoCodigoBarra);

                if (dtoMatMed == null)
                {
                    MessageBox.Show(" Material/medicamento não identificado ", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodProduto.Text = string.Empty;
                    txtCodProduto.Focus();
                    this.Cursor = Cursors.Default;
                    return false;
                }
                if (dtoMatMed.FlAtivo.Value == 0)
                {
                    MessageBox.Show("Produto Inativo", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodProduto.Text = string.Empty;
                    txtCodProduto.Focus();
                    this.Cursor = Cursors.Default;
                    return false;
                }
            }
            return true;
        }

        private bool EstornarDispensa(decimal idRequisicao, decimal idProduto, decimal? idLote, decimal qtde)
        {
            //dtoRequisicaoItem = new RequisicaoItensDTO();
            //dtoRequisicaoItem.Idt.Value = idRequisicao;
            //dtoRequisicaoItem.IdtProduto.Value = dtoMatMed.Idt.Value;
            //dtoRequisicaoItem.IdtUsuarioDispensacao.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
            //if (idLote != null)
            //    dtoRequisicaoItem.IdtLote.Value = idLote.Value;

            MovimentacaoDTO dtoMov = new MovimentacaoDTO();

            // unidade de baixa
            dtoMov.IdtUnidadeBaixa.Value = cmbUnidade.SelectedValue.ToString();
            dtoMov.IdtLocalBaixa.Value = cmbLocal.SelectedValue.ToString();
            dtoMov.IdtSetorBaixa.Value = cmbSetor.SelectedValue.ToString();
            dtoMov.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            dtoMov.IdtRequisicao.Value = idRequisicao;
            dtoMov.IdtAtendimento.Value = txtNroInternacao.Text;

            // unidade de entrada
            dtoMov.IdtUnidade.Value = 244; //SANTOS
            dtoMov.IdtLocal.Value = 33; //ADM
            dtoMov.IdtSetor.Value = 29; //ALMOX. CENTRAL            

            dtoMov.IdtProduto.Value = idProduto;
            if (idLote != null)
                dtoMov.IdtLote.Value = idLote.Value;
            dtoMov.Qtde.Value = qtde;

            dtoMov.IdtTipo.Value = (byte)MovimentacaoDTO.TipoMovimento.ENTRADA;
            dtoMov.IdtTipoBaixa.Value = (byte)MovimentacaoDTO.TipoMovimento.SAIDA;
            dtoMov.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.TRANSFERENCIA_ENTRADA;
            dtoMov.IdtSubTipoBaixa.Value = (byte)MovimentacaoDTO.SubTipoMovimento.TRANSFERENCIA_SAIDA;
            dtoMov.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

            try
            {
                //RequisicaoItens.DelReqItemDispensacao(dtoRequisicaoItem);
                Movimento.TransfereEstoqueProduto(dtoMov);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool DispensarAtendimentoDomiciliar(bool baixaSelMat)
        {
            if (!gen.ValidarContaFaturadaComNF((decimal)dtoAtendimento.Idt.Value, decimal.Parse(cmbSetor.SelectedValue.ToString())))
            {
                dtoMatMed = null;
                MessageBox.Show("A conta deste paciente já foi faturada e mais nenhum produto pode ser registrado na mesma", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodProduto.Text = string.Empty;
                txtCodProduto.Focus();
                return false;
            }
            RequisicaoDTO dtoReqItemPend = new RequisicaoDTO();
            dtoReqItemPend.IdtAtendimento.Value = dtoAtendimento.Idt.Value;
            RequisicaoItensDataTable dtbReqItemPend = RequisicaoItens.SelReqItensPendentes(dtoReqItemPend);
            if (dtbReqItemPend.Rows.Count == 0)
            {
                MessageBox.Show("Não existem itens pendentes de pedido a serem consumidos para este paciente", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodProduto.Text = string.Empty;
                txtCodProduto.Focus();
                return false;
            }
            dtoRequisicaoItem = new RequisicaoItensDTO();
            int qtdPendente = 0;
            foreach (DataRow row in dtbReqItemPend.Rows)
            {
                if (((RequisicaoItensDTO)row).IdtProduto.Value.ToString() == dtoMatMed.Idt.Value.ToString() ||
                    (((RequisicaoItensDTO)row).IdtPrincipioAtivo.Value.ToString() == dtoMatMed.IdtPrincipioAtivo.Value.ToString() && dtoMatMed.IdtPrincipioAtivo.Value.ToString() != "0"))
                {
                    dtoRequisicaoItem = (RequisicaoItensDTO)row;
                    dtoRequisicaoItem.IdtProduto.Value = dtoMatMed.Idt.Value; //Acerta ID se for similar
                    qtdPendente = (int)dtoRequisicaoItem.QtdSolicitada.Value - (int)dtoRequisicaoItem.QtdFornecida.Value;
                    if (baixaSelMat)
                    {
                        if (dtoMovimento.Qtde.Value > qtdPendente)
                            dtoMovimento.Qtde.Value = qtdPendente;
                    }
                    break;
                }
            }
            if (dtoRequisicaoItem.IdtProduto.Value.IsNull) 
                //&& dtoMatMed.FlFracionado.Value != (byte)MaterialMedicamentoDTO.Fracionado.SIM && dtoMatMed.FlReutilizavel.Value != (decimal)MaterialMedicamentoDTO.Reutilizavel.SIM)
            {
                MessageBox.Show("Este produto não consta em nenhum pedido pendente para este paciente", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodProduto.Text = string.Empty;
                txtCodProduto.Focus();
                return false;
            }
            if (!dtoRequisicaoItem.IdtProduto.Value.IsNull)
            {
                try
                {
                    dtoRequisicaoItem = RequisicaoItens.SelQtdeSolicitada(dtoRequisicaoItem);

                    if (dtoRequisicaoItem != null)
                    {
                        dtoRequisicaoItem.DsProduto.Value = dtoMatMed.NomeFantasia.Value;

                        if (baixaSelMat)
                            dtoRequisicaoItem.QtdFornecida.Value = dtoMovimento.Qtde.Value;
                        else if (cbDigitar.Checked)
                        {
                            MovimentacaoDTO dtoQtd = new MovimentacaoDTO();
                            dtoQtd.DsProduto.Value = dtoMatMed.NomeFantasia.Value;
                            dtoQtd = FrmQtdMatMed.DigitaQtde(dtoQtd);
                            if (dtoQtd == null)
                            {
                                txtCodProduto.Text = string.Empty;
                                txtCodProduto.Focus();
                                return false;
                            }
                            if (dtoQtd.Qtde.Value.IsNull) dtoQtd.Qtde.Value = 0;
                            if (dtoQtd.Qtde.Value == 0)
                            {                                
                                txtCodProduto.Text = string.Empty;
                                txtCodProduto.Focus();
                                return false;
                            }
                            dtoRequisicaoItem.QtdFornecida.Value = dtoQtd.Qtde.Value;
                            dtoMovimento.Qtde.Value = dtoQtd.Qtde.Value;
                        }
                        else
                            dtoRequisicaoItem.QtdFornecida.Value = 1;
                        dtoRequisicaoItem.IdtUsuarioDispensacao.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                        if (!dtoMatMed.IdtLote.Value.IsNull) dtoRequisicaoItem.IdtLote.Value = dtoMatMed.IdtLote.Value;

                        RequisicaoItens.InsReqItemDispensacao(dtoRequisicaoItem);
                    }
                    else
                    {
                        MessageBox.Show("Produto não consta neste pedido", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCodProduto.Text = string.Empty;
                        txtCodProduto.Focus();
                        return false;
                    }
                }
                catch (Exception e)
                {
                    if (baixaSelMat)
                    {
                        if (e.Message.ToUpper().IndexOf("NAO EXISTE SALDO") > -1)
                            return false;
                    }
                    else
                    {
                        MessageBox.Show(e.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCodProduto.Text = string.Empty;
                        txtCodProduto.Focus();
                    }
                    return false;
                }
            }
            else if (dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM || dtoMatMed.FlReutilizavel.Value == (decimal)MaterialMedicamentoDTO.Reutilizavel.SIM)
            {
                //Procurar se tem algum pedido deste produto para o atendimento, para validar consumo fracionado.
                RequisicaoDTO dtoReq = new RequisicaoDTO();
                dtoReq.IdtAtendimento.Value = dtoAtendimento.Idt.Value;
                dtoReq.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                dtoReq.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                dtoReq.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                dtoReq.IdtTipoRequisicao.Value = (decimal)RequisicaoDTO.TipoRequisicao.PERSONALIZADO;
                RequisicaoDataTable dtbReq = Requisicao.Sel(dtoReq, false);
                RequisicaoItensDTO dtoReqItem;
                foreach (DataRow rowReq in dtbReq.Rows)
                {
                    if (decimal.Parse(rowReq[RequisicaoDTO.FieldNames.Status].ToString()) != (decimal)RequisicaoDTO.StatusRequisicao.ABERTA &&
                        decimal.Parse(rowReq[RequisicaoDTO.FieldNames.Status].ToString()) != (decimal)RequisicaoDTO.StatusRequisicao.CANCELADA)
                    {
                        dtoReqItem = new RequisicaoItensDTO();
                        dtoReqItem.Idt.Value = decimal.Parse(rowReq[RequisicaoDTO.FieldNames.Idt].ToString());
                        dtoReqItem.IdtProduto.Value = dtoMatMed.Idt.Value;
                        RequisicaoItensDataTable dtbReqItem = RequisicaoItens.Sel(dtoReqItem);
                        if (dtbReqItem.Rows.Count > 0)
                            return true;                        
                    }
                }
                //MessageBox.Show("Este produto fracionado não consta em nenhum pedido para este paciente. Caso seja similar a algum produto de um pedido anterior, terá que ser feito o estorno do mesmo na tela de Baixa Fracionado ou Material.", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show("Este produto fracionado não consta em nenhum pedido pendente para este paciente.", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodProduto.Text = string.Empty;
                txtCodProduto.Focus();
                return false;
            }
            return true;
        }

        private void BaixarProduto()
        {     
            try
            {
                dtgHistConsumo.Columns["colDeletarHist"].Visible = false;
                if (dtoMatMed.FlReutilizavel.Value.IsNull) dtoMatMed.FlReutilizavel.Value = (byte)MaterialMedicamentoDTO.Fracionado.NAO;

                // limpa histórico quando adicionar itens
                dtbHistMovimento.Rows.Clear();                    

                dtoMovimento.IdtSubTipo.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();                    
                dtoMovimento.FlFracionado.Value = dtoMatMed.FlFracionado.Value;

                #region "Se for fracionado/reutilizavel, igualar qtd. à unidade de venda para consumir como inteiro"
                if (dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM ||
                    dtoMatMed.FlReutilizavel.Value == (decimal)MaterialMedicamentoDTO.Reutilizavel.SIM)
                {
                    //dtoMovimento = DigitarQtde();
                    if (!cbDigitar.Checked)
                        dtoMovimento.Qtde.Value = dtoMatMed.UnidadeVenda.Value;
                    else
                        dtoMovimento.Qtde.Value = dtoMatMed.UnidadeVenda.Value * dtoMovimento.Qtde.Value;
                    if (decimal.Parse(dtoMovimento.Qtde.Value.ToString()) == 0)
                    {
                        txtCodProduto.Text = string.Empty;
                        txtCodProduto.Focus();
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }
                #endregion

                dtoMovimento.TipoEmpresa.Value = (byte)MovimentacaoDTO.Empresa.ACS;
                dtoMovimento.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                dtoMovimento.DtFaturamento.Value = dtoAtendimento.DtTransf.Value;
                dtoMovimento.HrFaturamento.Value = dtoAtendimento.HrTransf.Value;
                dtoMovimento.TpAtendimento.Value = "I";
                dtoMovimento.IdtRequisicao.Value = dtoRequisicaoItem.Idt.Value;
                if (!dtoMatMed.IdtLote.Value.IsNull && (decimal)dtoMatMed.IdtLote.Value != 0) dtoMovimento.IdtLote.Value = dtoMatMed.IdtLote.Value;                
                // ############## GERA O MOVIMENTO #############################################################
                dtoMovimento = Movimento.MovimentaEstoqueProduto(dtoMovimento, dtoMatMed, null);
                // #############################################################################################
                    
                // insere linha  do produto consumido na grid
                dtbMovimento.Add(dtoMovimento);
                if (dtbMovimento.Columns.IndexOf(MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia) == -1)
                    dtbMovimento.Columns.Add(MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia);
                dtbMovimento.Rows[dtbMovimento.Rows.Count - 1][MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia] = dtoMatMed.MedAltaVigilancia.Value;
                dtgHistConsumo.DataSource = dtbMovimento;  
              
                RequisicaoDTO dtoReqItemPend = new RequisicaoDTO();
                dtoReqItemPend.Idt.Value = dtoRequisicaoItem.Idt.Value;
                RequisicaoItensDataTable dtbReqItemPend = RequisicaoItens.SelReqItensPendentes(dtoReqItemPend);
                //Se não tiver mais itens pendentes neste pedido, mudar status para dispensado
                if (dtbReqItemPend.Rows.Count == 0)
                {
                    RequisicaoDTO dtoReq = new RequisicaoDTO();
                    dtoReq.Idt.Value = dtoRequisicaoItem.Idt.Value;
                    dtoReq.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX;
                    dtoReq.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    Requisicao.Upd(dtoReq);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
                        
            dtbMovimento.AcceptChanges();            
        }
                           
        //private MovimentacaoDTO DigitarQtde()
        //{
        //    dtoMovimento.DsProduto.Value = dtoMatMed.NomeFantasia.Value;
        //    dtoMovimento.FlFracionado.Value = dtoMatMed.FlFracionado.Value;
        //    dtoMovimento.UnidadeVenda.Value = dtoMatMed.UnidadeVenda.Value;
        //    dtoMovimento.DsUnidadeVenda.Value = dtoMatMed.DsUnidadeVenda.Value;
        //    dtoMovimento.FormOrigem.Value = (int)MovimentacaoDTO.TelaOrigem.CONSUMO_PACIENTE;
        //    dtoMovimento.TpFracao.Value = dtoMatMed.TpFracao.Value;

        //    dtoMovimento = FrmQtdMatMed.DigitaQtde(dtoMovimento);

        //    if (dtoMovimento == null) dtoMovimento = new MovimentacaoDTO();            
        //    if (dtoMovimento.Qtde.Value.IsNull) dtoMovimento.Qtde.Value = 0;
                    
        //    return dtoMovimento;
        //}

        private bool ZerarObjetos(bool finalizarPedidoCarrEmergSemMsg)
        {
            txtCodProduto.ReadOnly = pnlPeriodo.Visible = pnlPendentes.Visible = false;
            dtgHistConsumo.Columns["colDeletarHist"].Visible = false;            
            dtoMatMed = null;
            dtoAtendimento = null;
            dtbMovimento = new MovimentacaoDataTable();
            dtbHistMovimento = new MovimentacaoDataTable();            
            dtgHistConsumo.DataSource = null;            
            return true;
        }

        private void CarregarItensGerarProtocolo()
        {
            this.Cursor = Cursors.WaitCursor;

            MovimentacaoDTO dtoMovProt = new MovimentacaoDTO();            
            dtoMovProt.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoMovProt.IdtAtendimento.Value = dtoAtendimento.Idt.Value;
            dtoMovProt.DataMovimento.Value = txtDtIni.Text;
            dtoMovProt.DataAte.Value = txtDtFim.Text;

            DataTable dtbProt = Movimento.ObterItensPendentesProtocolo(dtoMovProt);
            dtgGerarProtocolo.DataSource = dtbProt;
            
            this.Cursor = Cursors.Default;
        }

        private void RotinaPosBaixaCompleta()
        {
            dtgHistConsumo.Sort(dtgHistConsumo.Columns["colDataHist"], ListSortDirection.Descending);
            dtgHistConsumo.ClearSelection();
            if (dtgHistConsumo.Rows.Count > 0) dtgHistConsumo.Rows[0].Selected = true;

            txtCodProduto.Text = string.Empty;
            txtCodProduto.Focus();
        }

        #endregion

        #region Eventos

        private void FrmAtendimentoDomiciliar_Load(object sender, EventArgs e)
        {
            //#if DEBUG                
            //    btnRegerarFaturamento.Visible = true;
            //#else                
            //    btnRegerarFaturamento.Visible = false;
            //#endif
            tsHac.Items["tsBtnPrint"].Visible = tsHac.Items["tsBtnPrint"].Enabled = true;
            tsHac.Items["tsBtnPrint"].Text = "Protocolo de Recebimento";
            tsHac.Items["tsBtnPrint"].Size = new Size(180, 25);

            cmbUnidade.Enabled = cmbLocal.Enabled = cmbSetor.Enabled = false;
            cmbUnidade.Editavel = cmbLocal.Editavel = cmbSetor.Editavel = ControleEdicao.Nunca;
            cmbUnidade.Carregaunidade();
            cmbUnidade.SelectedValue = 244; //SANTOS
            cmbLocal.SelectedValue = 46; //ATENDIMENTO DOMICILIAR
            cmbSetor.SelectedValue = 2252; //ATENDIMENTO DOMICILIAR

            AtribuirEstoqueUnico();            
            ConfiguraDTG();
            ConfiguraItensPendentesDTG();
        }   //     

        private void txtNroInternacao_Validating(object sender, CancelEventArgs e)
        {
            if (txtNroInternacao.Text.Length != 0)
            {
                CarregaInfoPaciente();
                tsHac.Items["tsBtnNovo"].Enabled = true;
            }
        }

        private void txtCodProduto_Validating(object sender, CancelEventArgs e)
        {
            if (txtCodProduto.Text != string.Empty)
            {
                dtoMatMed = null;
                this.Cursor = Cursors.WaitCursor;
                if (txtCodProduto.Text != string.Empty && BuscarProduto())
                {
                    pnlPeriodo.Visible = pnlPendentes.Visible = false;
                    if (DispensarAtendimentoDomiciliar(false))
                    {
                        BaixarProduto();
                        RotinaPosBaixaCompleta();
                        tsHac.Items["tsBtnNovo"].Enabled = true;
                    }
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void chkSelTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dtgRow in dtgGerarProtocolo.Rows)
            {
                dtgRow.Cells[colSel.Name].Value = chkSelTodos.Checked;
            }
        }

        private bool tsHac_NovoClick(object sender)
        {
            return ZerarObjetos(false);
        }

        private bool tsHac_CancelarClick(object sender)
        {
            return ZerarObjetos(false);
        }

        private void tsHac_AfterCancelar(object sender)
        {
            
        }

        private bool tsHac_ImprimirClick(object sender)
        {
            if (txtNomePac.Text == string.Empty)
            {
                MessageBox.Show("Atendimento não carregado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroInternacao.Focus();
                return false;
            }
            txtDtIni.Text = txtDtFim.Text = Utilitario.ObterDataHoraServidor().ToString("dd/MM/yyyy");
            txtCodProduto.ReadOnly = pnlPeriodo.Visible = true;
            chkSelTodos.Checked = false;
            CarregarItensGerarProtocolo();
            return true;
        }
        
        private void dtgItensPendentes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {            
            if (e.RowIndex >= 0 && dtgItensPendentes.Rows.Count > 0)
            {
                if (dtgItensPendentes.Columns[e.ColumnIndex].Name == "colQtdPendente")
                {
                    e.Value = decimal.Parse(dtgItensPendentes.Rows[e.RowIndex].Cells["colQtdReqPend"].Value.ToString()) -
                              decimal.Parse(dtgItensPendentes.Rows[e.RowIndex].Cells["colQtdFornPend"].Value.ToString());
                }
                if (int.Parse(dtgItensPendentes.Rows[e.RowIndex].Cells[colIdGrupo.Name].Value.ToString()) == 1)
                {                    
                    dtgItensPendentes.Rows[e.RowIndex].Cells[colChkBaixar.Name].ReadOnly = true;
                }
            }
        }

        private void dtgItensPendentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dtgItensPendentes.Rows.Count > 0)
            {
                if (dtgItensPendentes.Columns[e.ColumnIndex].Name == colChkBaixar.Name)
                {                    
                    if (int.Parse(dtgItensPendentes.Rows[e.RowIndex].Cells[colIdGrupo.Name].Value.ToString()) == 1)
                    {                        
                        dtgItensPendentes.Rows[e.RowIndex].Cells[colChkBaixar.Name].Value = false;
                        MessageBox.Show("Não é permitido selecionar medicamento para baixa.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }                    
                }
            }
        }

        private void dtgHistConsumo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1 && dtgHistConsumo.Columns[e.ColumnIndex].Name == "colDeletarHist")
            {
                this.Cursor = Cursors.WaitCursor;
                
                dtoMatMed = new MaterialMedicamentoDTO();
                dtoMatMed.Idt.Value = dtgHistConsumo.Rows[e.RowIndex].Cells["colIdtProdutoHist"].Value.ToString();
                dtoMatMed = MatMed.SelChave(dtoMatMed);

                ConfiguraMovimentoDTO();
                decimal subTipoMov = decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString());
                dtoMovimento.Idt.Value = decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colIdtMovimentoHist"].Value.ToString());
                                
                if (Movimento.PermitirEstornoConsumoItem(ref dtoMovimento))
                {
                    if (MessageBox.Show("Deseja realmente estornar este consumo ?",
                                        "Gestão de Materiais e Medicamentos",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {                        
                        try
                        {
                            dtoMovimento.IdtProduto.Value = long.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colIdtProdutoHist"].Value.ToString());
                            dtoMovimento.Qtde.Value = decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colQtdInteiraHist"].Value.ToString());
                            dtoMovimento.IdtUsuarioEstorno.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                            Movimento.EstornarMovimentoConsumoPaciente(dtoMovimento);

                            //Se produto inteiro, devolver item para o almoxarifado
                            if (((dtoMatMed.FlFracionado.Value != (byte)MaterialMedicamentoDTO.Fracionado.SIM && dtoMatMed.FlReutilizavel.Value != (decimal)MaterialMedicamentoDTO.Reutilizavel.SIM) ||
                                subTipoMov != (decimal)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA) &&
                                !string.IsNullOrEmpty(dtgHistConsumo.Rows[e.RowIndex].Cells[colIdReqMov.Name].Value.ToString()))
                            {
                                decimal? idLote = null;
                                if (!string.IsNullOrEmpty(dtgHistConsumo.Rows[e.RowIndex].Cells[colIdLote.Name].Value.ToString()))
                                    idLote = decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells[colIdLote.Name].Value.ToString());
                                {
                                    EstornarDispensa(decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells[colIdReqMov.Name].Value.ToString()),
                                                     (decimal)dtoMovimento.IdtProduto.Value,
                                                     idLote,
                                                     (decimal)dtoMovimento.Qtde.Value);
                                }

                                RequisicaoDTO dtoReq = new RequisicaoDTO();
                                dtoReq.Idt.Value = dtgHistConsumo.Rows[e.RowIndex].Cells[colIdReqMov.Name].Value.ToString();
                                dtoReq.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.IMPRESSO;
                                dtoReq.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                                Requisicao.Upd(dtoReq);
                            }
                            
                            if (dtbHistMovimento.Rows.Count > 0)
                            {
                                dtbHistMovimento.Select(string.Format("{0} = {1}",
                                                            MovimentacaoDTO.FieldNames.Idt,
                                                            dtoMovimento.Idt.Value))[0].Delete();

                                dtbHistMovimento.AcceptChanges();
                            }
                            txtCodProduto.ReadOnly = pnlPeriodo.Visible = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Cursor = Cursors.Default;
                        }                        
                    }
                }
                else
                {
                    MessageBox.Show("Este consumo já foi faturado e não pode ser estornado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            if (dtoAtendimento == null || dtoAtendimento.Idt.Value.IsNull)
            {
                MessageBox.Show("Atendimento não carregado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroInternacao.Focus();
                return;
            }
            dtbMovimento.Rows.Clear();
            if (dtoAtendimento != null) CarregarHistoricoConsumo();
            if (txtNroInternacao.Text == string.Empty)
                txtNroInternacao.Focus();
            else
                txtCodProduto.Focus();
        }
        
        private void btnPendentes_Click(object sender, EventArgs e)
        {
            if (dtoAtendimento == null || dtoAtendimento.Idt.Value.IsNull)
            {
                MessageBox.Show("Atendimento não carregado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroInternacao.Focus();
                return;
            }
            CarregarItensPendentes(true);
        }

        private void btnFecharPendentes_Click(object sender, EventArgs e)
        {
            pnlPendentes.Visible = false;
            txtCodProduto.Focus();
        }

        private void btnGerarProtocolo_Click(object sender, EventArgs e)
        {
            bool gerar = false;
            foreach (DataGridViewRow dtgRow in dtgGerarProtocolo.Rows)
            {
                if (bool.Parse(dtgRow.Cells[colSel.Name].EditedFormattedValue.ToString()))
                {
                    gerar = true;
                    break;
                }
            }
            if (!gerar)
            {
                MessageBox.Show("Nenhum item selecionado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                int numProtocolo = 0;
                foreach (DataGridViewRow dtgRow in dtgGerarProtocolo.Rows)
                {
                    if (bool.Parse(dtgRow.Cells[colSel.Name].EditedFormattedValue.ToString()))
                    {
                        if (numProtocolo == 0)
                            numProtocolo = Movimento.ObterNovoNumProtocolo();

                        Movimento.AtualizarProtocolo(numProtocolo, decimal.Parse(dtgRow.Cells[colIdtMovimentoProt.Name].Value.ToString()));
                    }
                }

                gen.ImprimirProtocolo(numProtocolo, 
                                      decimal.Parse(txtNroInternacao.Text), 
                                      txtNomePac.Text, 
                                      decimal.Parse(cmbSetor.SelectedValue.ToString()), 
                                      Utilitario.ObterDataHoraServidor().Date);
                //CarregarItensGerarProtocolo();
                dtgGerarProtocolo.LimparDataGridView();
                this.Cursor = Cursors.Default;
                tsHac.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCodProduto.ReadOnly = pnlPeriodo.Visible = false;
            txtCodProduto.Focus();
        }

        private void tsPendenciasGerais_Click(object sender, EventArgs e)
        {
            FrmAtdDomiciliarPendencias frm = new FrmAtdDomiciliarPendencias();            
            frm.MdiParent = FrmPrincipal.ActiveForm;
            this.Cursor = Cursors.WaitCursor;
            frm.Show();
            this.Cursor = Cursors.Default;
        }

        private void btnPesquisarProt_Click(object sender, EventArgs e)
        {
            FrmProtocolo frm = new FrmProtocolo();
            frm.MdiParent = FrmPrincipal.ActiveForm;
            this.Cursor = Cursors.WaitCursor;
            frm._dtoMovimento = new MovimentacaoDTO();
            frm._dtoMovimento.IdtAtendimento.Value = txtNroInternacao.Text;
            frm._dtoMovimento.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            frm._nomePaciente = txtNomePac.Text;
            frm.Show();
            this.Cursor = Cursors.Default;
        }

        private void btnPesquisaItensGerarProt_Click(object sender, EventArgs e)
        {
            if (txtDtIni.Text == string.Empty)
            {
                MessageBox.Show("Data Início é obrigatória.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtDtFim.Text == string.Empty)
            {
                MessageBox.Show("Data Fim é obrigatória.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (Convert.ToDateTime(txtDtFim.Text) < Convert.ToDateTime(txtDtIni.Text))
                {
                    MessageBox.Show("A Data Fim deve ser maior ou igual à Data Início.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDtFim.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Data inválida.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CarregarItensGerarProtocolo();
        }

        private void btnRegerarFaturamento_Click(object sender, EventArgs e)
        {
             if (MessageBox.Show("Deseja realmente reenviar o consumo do atendimento digitado para o faturamento ?",
                                 "Gestão de Materiais e Medicamentos",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MovimentacaoDTO dtoMov = new MovimentacaoDTO();
                //dtoMov.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                //dtoMov.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                //dtoMov.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                //dtoMov.FlEstornado.Value = (int)MovimentacaoDTO.Estornado.NAO;

                dtoMov.IdtAtendimento.Value = txtNroInternacao.Text;
                //dtoMov.TpAtendimento.Value = (rbInternado.Checked ? "I" : "A");

                dtoMov.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                this.Cursor = Cursors.WaitCursor;

                //Esta linha abaixo regera no faturamento novo, apenas 1 atendimento (digitado no txtNroInternacao)
                int qtd = Movimento.RegerarContaFaturamento(dtoMov);

                //Esta rotina abaixo regera no faturamento novo, todos os atendimentos com movimentação de baixa no período
                //dtoMov.DataMovimento.Value = DateTime.Parse("20/09/2010").Date;
                //dtoMov.DataAte.Value = DateTime.Parse("20/09/2010").Date;
                //dtoMov.DataAte.Value = DateTime.Now.Date;

                //int qtd = 0;
                //DataTable dtbMov = Movimento.HistoricoConsumoAtendimentosPeriodo(dtoMov, 731);
                //dtbMov = new DataView(dtbMov, string.Empty, MovimentacaoDTO.FieldNames.IdtAtendimento + " desc", DataViewRowState.CurrentRows).ToTable();
                //foreach (DataRow row in dtbMov.Rows)
                //{
                //    dtoMov.IdtAtendimento.Value = row[MovimentacaoDTO.FieldNames.IdtAtendimento].ToString();
                //    dtoMov.TpAtendimento.Value = row[MovimentacaoDTO.FieldNames.TpAtendimento].ToString();
                //    qtd += Movimento.RegerarContaFaturamento(dtoMov);
                //}

                this.Cursor = Cursors.Default;
                MessageBox.Show(string.Format("Foram enviados {0} itens para o faturamento", qtd), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBaixarMat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente baixar os materiais selecionados ?",
                                "Gestão de Materiais e Medicamentos",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                int qtdRegistrosBaixados = 0;
                int qtdTotalMat = 0;
                foreach (DataGridViewRow dtgRow in dtgItensPendentes.Rows)
                {
                    if (bool.Parse(dtgRow.Cells[colChkBaixar.Name].EditedFormattedValue.ToString()))
                    {
                        ConfiguraMovimentoDTO();
                        dtoMatMed = new MaterialMedicamentoDTO();
                        dtoMatMed.Idt.Value = int.Parse(dtgRow.Cells[colMatMedIdtPend.Name].Value.ToString());
                        dtoMatMed = MatMed.SelChave(dtoMatMed);
                        if (dtoMatMed.IdtGrupo.Value != 1) //Garantir que não baixe medicamento por aqui
                        {
                            qtdTotalMat = int.Parse(dtgRow.Cells[colQtdReqPend.Name].Value.ToString()) - int.Parse(dtgRow.Cells[colQtdFornPend.Name].Value.ToString());
                            for (int qtdAdd = 1; qtdAdd <= qtdTotalMat; qtdAdd++)
                            {
                                dtoMovimento.Qtde.Value = 1;
                                if (DispensarAtendimentoDomiciliar(true))
                                {
                                    BaixarProduto();
                                    qtdRegistrosBaixados += 1;
                                }
                            }
                        }
                    }
                }
                if (dtoMovimento == null)
                {
                    MessageBox.Show("Nenhum material foi baixado!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Cursor = Cursors.Default;
                    return;
                }
                dtoMovimento.Qtde.Value = new Framework.DTO.TypeDecimal();
                if (qtdRegistrosBaixados > 0)
                {
                    MessageBox.Show("Materiais com saldo existente baixados com sucesso.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //CarregarItensPendentes(false);
                    btnFecharPendentes_Click(null, null);
                    RotinaPosBaixaCompleta();
                }
                else
                    MessageBox.Show("Nenhum material foi baixado!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Cursor = Cursors.Default;
            }
        }

        private void cbDigitar_Click(object sender, EventArgs e)
        {
            txtCodProduto.Focus();
        }

        #endregion        
    }
}