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
using HospitalAnaCosta.SGS.GestaoMateriais.Relatorio;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmConsumoCCirurgico : FrmBase
    {
        public FrmConsumoCCirurgico()
        {
            InitializeComponent();
        }

        private bool _logadoAlmoxCentral = false;
        private bool ESTOQUE_UNIFICADO_HAC = false;
        private bool baixaKit = false;

        #region Objetos Serviço

        //private CommonCadastro _commonCadastro;
        //private CommonCadastro CommonCadastro
        //{
        //    get { return _commonCadastro != null ? _commonCadastro : _commonCadastro = new CommonCadastro(null); }
        //}

        // Atendimento
        private PacienteDTO dtoAtendimento;
        private IPaciente _atendimento;
        private IPaciente Atendimento
        {
            get { return _atendimento != null ? _atendimento : _atendimento = (IPaciente)Global.Common.GetObject(typeof(IPaciente)); }
        }

        private ISetor _isetor;
        private ISetor Setor
        {
            get { return _isetor != null ? _isetor : _isetor = (ISetor)Global.Common.GetObject(typeof(ISetor)); }
        }

        // Movimentos
        private MovimentacaoDTO dtoMovimento;
        private MovimentacaoDataTable dtbMovimento = new MovimentacaoDataTable();
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }

        private MovimentacaoDataTable _movimentoDadosGrid;
        private MovimentacaoDataTable MovimentoDadosGrid
        {
            get { return _movimentoDadosGrid; }
            set { _movimentoDadosGrid = value; }
        }

        // MatMed        
        private MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }

        // Filial        
        private IFilialMatMed _filialMatMed;
        private IFilialMatMed FilialMatMed
        {
            get { return _filialMatMed != null ? _filialMatMed : _filialMatMed = (IFilialMatMed)Global.Common.GetObject(typeof(IFilialMatMed)); }
        }

        // Pedido Padrão        
        private PedidoPadraoDTO dtoPedidoPadrao;
        private IPedidoPadrao _pedidopadrao;
        private IPedidoPadrao PedidoPadrao
        {
            get { return _pedidopadrao != null ? _pedidopadrao : _pedidopadrao = (IPedidoPadrao)Global.Common.GetObject(typeof(IPedidoPadrao)); }
        }

        // Itens Requisição
        private RequisicaoItensDataTable dtbRequisicaoItemCE;
        private RequisicaoItensDTO dtoRequisicaoItemCE;
        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }

        // Requisição
        private RequisicaoDTO dtoRequisicaoCE;
        private IRequisicao _requisicao;
        private IRequisicao Requisicao
        {
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject(typeof(IRequisicao)); }
        }

        // Estoque
        private EstoqueLocalDTO dtoEstoque;
        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject(typeof(IEstoqueLocal)); }
        }

        private IKit _kit;
        private IKit Kit
        {
            get { return _kit != null ? _kit : _kit = (IKit)Global.Common.GetObject(typeof(IKit)); }
        }

        private IMatMedSetorConfig _matMedConfig;
        private IMatMedSetorConfig MatMedSetorConfig
        {
            get { return _matMedConfig != null ? _matMedConfig : _matMedConfig = (IMatMedSetorConfig)Global.Common.GetObject(typeof(IMatMedSetorConfig)); }
        }

        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        #endregion

        FrmCentroCirurgicoPendencia frm;

        //bool ItemAdiconado = false;
        string _produtosNaoExcluidos;

        #region Métodos

        private int RetornaFilial()
        {
            if (rbHac.Checked)
            {
                return (int)FilialMatMedDTO.Filial.HAC;
            }
            else if (rbAcs.Checked)
            {
                return (int)FilialMatMedDTO.Filial.ACS;
            }
            else
            {
                return 0;
            }

        }

        private decimal CONTA_FATURADA = (int)PacienteDTO.Faturada.NAO;

        private bool LogadoAlmoxCentral()
        {
            SetorDTO dtoSetor = new SetorDTO();
            dtoSetor.Idt.Value = (int)FrmPrincipal.dtoSeguranca.IdtSetor.Value;
            dtoSetor = Setor.SelChave(dtoSetor);
            if (dtoSetor.FlAlmoxCentral.Value == (byte)SetorDTO.AlmoxarifadoCentral.SIM) return true;
            return false;
        }

        //private void ConfiguraCombos()
        //{
        //    cmbUnidade.SelectedValue = FrmPrincipal.dtoSeguranca.IdtUnidade.Value;
        //    cmbLocal.SelectedValue = FrmPrincipal.dtoSeguranca.IdtLocal.Value;
        //    cmbSetor.SelectedValue = FrmPrincipal.dtoSeguranca.IdtSetor.Value;

        //    if (FrmPrincipal.dtoSeguranca.IdtNivelSeguranca.Value == (int)SegurancaDTO.NivelSeguranca.OPERADOR)
        //    {
        //        cmbUnidade.Enabled = false;
        //        cmbUnidade.Editavel = ControleEdicao.Nunca;

        //        cmbLocal.Enabled = false;
        //        cmbLocal.Editavel = ControleEdicao.Nunca;

        //        cmbSetor.Enabled = false;
        //        cmbSetor.Editavel = ControleEdicao.Nunca;

        //    }
        //}

        private void ConfiguraMovimentoDTO()
        {
            dtoMovimento = new MovimentacaoDTO();
            dtoMovimento.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoMovimento.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoMovimento.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoMovimento.FlEstornado.Value = (byte)MovimentacaoDTO.Estornado.NAO;
            if (cbCE.Checked)
                dtoMovimento.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
            else if (cbConsignado.Checked)
                dtoMovimento.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.CONSIGNADO;
            else if (rbHac.Checked || ESTOQUE_UNIFICADO_HAC)            
                dtoMovimento.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            else if (rbAcs.Checked)            
                dtoMovimento.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
            
            dtoMovimento.IdtAtendimento.Value = dtoAtendimento.Idt.Value;
            dtoAtendimento.IdtLocalAtendimento.Value = cmbLocal.SelectedValue.ToString();
            dtoMovimento.TpAtendimento.Value = Atendimento.ObterTipoAtendimento(dtoAtendimento).TpAtendimento.Value;
        }

        private void ConfiguraRequisicaoCEDTO()
        {
            dtoRequisicaoCE = new RequisicaoDTO();

            dtoRequisicaoCE.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoRequisicaoCE.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoRequisicaoCE.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoRequisicaoCE.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.FECHADA;
            dtoRequisicaoCE.IdtTipoRequisicao.Value = (byte)RequisicaoDTO.TipoRequisicao.CARRINHO_EMERGENCIA;
            dtoRequisicaoCE.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
        }

        private void ConfiguraDTG()
        {
            dtgHistConsumo.AutoGenerateColumns = false;
            dtgHistConsumo.Columns["colIdtMovimentoHist"].DataPropertyName = MovimentacaoDTO.FieldNames.Idt;
            dtgHistConsumo.Columns["colIdtProdutoHist"].DataPropertyName = MovimentacaoDTO.FieldNames.IdtProduto;
            dtgHistConsumo.Columns["colDsProdutoHist"].DataPropertyName = MovimentacaoDTO.FieldNames.DsProduto;
            dtgHistConsumo.Columns["colDataHist"].DataPropertyName = MovimentacaoDTO.FieldNames.DataMovimento;
            dtgHistConsumo.Columns["colDataHist"].DefaultCellStyle.Format = "dd/MM/yyyy à\\s HH:mm:ss";
            dtgHistConsumo.Columns["colQtdHist"].DataPropertyName = MovimentacaoDTO.FieldNames.DsQtdeConsumo;
            dtgHistConsumo.Columns["colQtdHist"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgHistConsumo.Columns["colQtdInteiraHist"].DataPropertyName = MovimentacaoDTO.FieldNames.Qtde;
            dtgHistConsumo.Columns["colFaturado"].DataPropertyName = MovimentacaoDTO.FieldNames.FlFaturado;
            dtgHistConsumo.Columns["colDataRessup"].DataPropertyName = MovimentacaoDTO.FieldNames.DataRessupri;
            dtgHistConsumo.Columns["colIdFilial"].DataPropertyName = MovimentacaoDTO.FieldNames.IdtFilial;
            dtgHistConsumo.Columns["colDsQtdeConvertida"].DataPropertyName = MovimentacaoDTO.FieldNames.DsQtdConvertida;
            dtgHistConsumo.Columns["colDsQtdeConvertida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgHistConsumo.Columns["colSubTpMov"].DataPropertyName = MovimentacaoDTO.FieldNames.IdtSubTipo;
            dtgHistConsumo.Columns[colLoteFab.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.NumLote;
            dtgHistConsumo.Columns[colKitID.Name].DataPropertyName = KitDTO.FieldNames.IdKit;
            dtgHistConsumo.Columns[colKit.Name].DataPropertyName = KitDTO.FieldNames.Descricao;
            dtgHistConsumo.Columns[colLoteID.Name].DataPropertyName = MovimentacaoDTO.FieldNames.IdtLote;
            // colDsQtdeConvertida            
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

            baixaKit = false;
            if (dtoCfg.SolicitaKit.Value == 1) baixaKit = true;
        }

        private void CarregarHistoricoConsumo()
        {
            this.Cursor = Cursors.WaitCursor;
            dtbMovimento.Rows.Clear();
            txtDscPesquisa.Text = string.Empty;
            // lblLegenda.Visible = false;
            ConfiguraMovimentoDTO();
            dtoMovimento.IdtFilial.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
            // NAO USA DATA FORNECIMENTO
            // MovimentoDadosGrid = Movimento.Sel(dtoMovimento, true);
            MovimentoDadosGrid = Movimento.HistoricoConsumoPaciente(dtoMovimento);
            dtgHistConsumo.DataSource = MovimentoDadosGrid;
            if (dtgHistConsumo.Rows.Count > 0)
            {
                //btnHistorico.Enabled = false;
                btnExcluir.Enabled = true;
                DesabilitarExlusao(false);
            }
            txtCodProduto.Focus();
            this.Cursor = Cursors.Default;
        }

        private void CarregaInfoPaciente()
        {
            dtoAtendimento = new PacienteDTO();
            dtoAtendimento.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoAtendimento.IdtLocalAtendimento.Value = cmbLocal.SelectedValue.ToString();
            dtoAtendimento.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            if (rbInternado.Checked)
                dtoAtendimento.TpAtendimento.Value = "I";
            else
                dtoAtendimento.TpAtendimento.Value = "E";
            if (txtNroInternacao.Text != string.Empty)
                dtoAtendimento.Idt.Value = Convert.ToInt64(txtNroInternacao.Text);
            Generico Gen = new Generico();
            dtoAtendimento = Gen.ObterPaciente(dtoAtendimento);

            if (!dtoAtendimento.NmPaciente.Value.IsNull)
            {
                FilialMatMedDTO dtoFilial = new FilialMatMedDTO();
                txtNomePac.Text = dtoAtendimento.NmPaciente.Value;
                txtNroInternacao.Text = dtoAtendimento.Idt.Value.ToString();
                txtCodConvenio.Text = dtoAtendimento.CdPlano.Value;
                //txtNomeConvenio.Text = dtoAtendimento.NmPlano.Value;
                txtNomeConvenio.Text = dtoAtendimento.DsEmpresa.Value;
                txtLocal.Text = dtoAtendimento.DsSetor.Value;
                txtQuartoLeito.Text = string.Format("{0} / {1}", dtoAtendimento.CdQuarto.ToString(), dtoAtendimento.CdLeito.ToString());
                txtDtTranf.Text = dtoAtendimento.DtTransf.Value;
                txtHrTransf.Text = dtoAtendimento.HrTransf.Value;
                dtoFilial.TpPlano.Value = dtoAtendimento.TpPlano.Value;

                CONTA_FATURADA = Convert.ToDecimal(dtoAtendimento.ContaFaturada.Value.ToString());
                if (CONTA_FATURADA == (int)PacienteDTO.Faturada.SIM)
                {
                    lblContaFaturada.Visible = true;
                }

                if (FilialMatMed.ObterFilialAtendimento(dtoFilial) == FilialMatMedDTO.Filial.HAC)
                    rbHac.Checked = true;
                else
                    rbAcs.Checked = true;

                grpTipoAtendimento.Enabled = false;
                txtNroInternacao.Enabled = false;
                cmbUnidade.Enabled = false;
                cmbLocal.Enabled = false;
                cmbSetor.Enabled = false;
                cmbKit.Enabled = true;
                cbCE.Enabled = true;
                txtCodProduto.Enabled = true;
                txtCodProduto.Focus();
                dtbMovimento.Clear();
                pnlIndiceDev.Visible = false;
                if (chkExcluirProximo.Checked) chkExcluirProximo.Checked = false;
                //CarregarHistoricoConsumo();
            }
            else
            {
                txtNroInternacao.Text = string.Empty;
                txtNroInternacao.Focus();
            }
        }

        private void BaixarProduto(int? qtdMov)
        {
            if (PermitirConsumo())
            {
                try
                {
                    pnlIndiceDev.Visible = false;
                    ConfiguraMovimentoDTO();
                    if (txtCodProduto.Text != string.Empty) dtoMovimento.CdBarra.Value = txtCodProduto.Text;

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
                            return;
                        }
                        if (dtoMatMed.FlAtivo.Value == 0)
                        {
                            MessageBox.Show("Produto Inativo", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtCodProduto.Text = string.Empty;
                            txtCodProduto.Focus();
                            return;
                        }
                    }

                    if (qtdMov != null)
                        dtoMovimento.Qtde.Value = qtdMov.Value;

                    dtoMovimento.IdtSubTipo.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
                    if (chkFracionar.Checked) dtoMatMed.FlFracionado.Value = (byte)MaterialMedicamentoDTO.Fracionado.SIM;
                    dtoMovimento.FlFracionado.Value = dtoMatMed.FlFracionado.Value;
                    //Se for fracionado, digitar qtd.
                    if (dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM && !_logadoAlmoxCentral)
                    {
                        if (cmbKit.SelectedIndex > -1)
                        {
                            dtoMovimento.Qtde.Value = dtoMovimento.Qtde.Value * dtoMatMed.UnidadeVenda.Value;
                        }
                        else
                        {
                            dtoMovimento = DigitarQtde();
                            if (decimal.Parse(dtoMovimento.Qtde.Value.ToString()) == 0)
                            {
                                txtCodProduto.Text = string.Empty;
                                txtCodProduto.Focus();
                                return;
                            }
                        }
                    }
                    else
                    {
                        #region Atualiza Requisição do carrinho de emergência
                        //Se não for fracionado, baixará do estoque, e terá que ser gerado um pedido, caso seja consumo de carrinho de emergência
                        if (cbCE.Checked)
                        {
                            dtoRequisicaoItemCE = RequisicaoItens.ConverteMatMedRequisicao(dtoMatMed);
                            if (dtbRequisicaoItemCE.Select(string.Format("{0} = {1}",
                                                         RequisicaoItensDTO.FieldNames.IdtProduto,
                                                         dtoMatMed.Idt.Value)).Length > 0)
                            {
                                decimal qtdAnterior = decimal.Parse(dtbRequisicaoItemCE.Select(string.Format("{0} = {1}",
                                                                    RequisicaoItensDTO.FieldNames.IdtProduto,
                                                                    dtoMatMed.Idt.Value))[0][RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString());
                                dtoRequisicaoItemCE.QtdSolicitada.Value = qtdAnterior + 1;
                                dtbRequisicaoItemCE.Select(string.Format("{0} = {1}",
                                                           RequisicaoItensDTO.FieldNames.IdtProduto,
                                                           dtoMatMed.Idt.Value))[0][RequisicaoItensDTO.FieldNames.QtdSolicitada] = dtoRequisicaoItemCE.QtdSolicitada.Value;
                            }
                            else
                            {
                                dtoRequisicaoItemCE.QtdSolicitada.Value = 1;
                                dtbRequisicaoItemCE.Add(dtoRequisicaoItemCE);
                            }
                            //dtoMovimento.IdtSubTipo.Value = (int)MovimentacaoDTO.SubTipoMovimento.BAIXA_CONSUMO_CARRINHO_EMERGENCIA_NAO_FATURADO;
                        }
                        else
                        {
                            // NÃO É CARRINHO DE EMERGENCIA E NAO FRACIONADO
                            dtoMovimento.IdtSubTipo.Value = (int)MovimentacaoDTO.SubTipoMovimento.BAIXA_CONSUMO_NAO_FATURADO_SETOR;
                        }
                        #endregion
                    }
                    // TESTA NOVAMENTE, SE O PRODUTO ERA FRACIONADO NA TELA DE QTDE PODE MUDAR O FLAG
                    if (dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.NAO || _logadoAlmoxCentral)
                    {
                        dtoMovimento.IdtSubTipo.Value = (int)MovimentacaoDTO.SubTipoMovimento.BAIXA_CONSUMO_NAO_FATURADO_SETOR;
                    }
                    else if (dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM)
                    {
                        dtoMovimento.IdtSubTipo.Value = (int)MovimentacaoDTO.SubTipoMovimento.BAIXA_FRACIONADA_NAO_FATURADA;
                    }
                    //else
                    //{
                    //    dtoMovimento.IdtSubTipo.Value = (int)MovimentacaoDTO.SubTipoMovimento.BAIXA_FRACIONADA_NAO_FATURADA;
                    //}
                    dtoMovimento.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    dtoMovimento.DtFaturamento.Value = txtDtTranf.Text;
                    dtoMovimento.HrFaturamento.Value = txtHrTransf.Text;
                    dtoMovimento.TipoEmpresa.Value = rbHac.Checked ? (byte)MovimentacaoDTO.Empresa.HAC : (byte)MovimentacaoDTO.Empresa.ACS;
                    if (!dtoMatMed.IdtLote.Value.IsNull && (decimal)dtoMatMed.IdtLote.Value != 0) dtoMovimento.IdtLote.Value = dtoMatMed.IdtLote.Value;

                    if (_logadoAlmoxCentral && !cbCE.Checked) //Se tiver logado no Almoxarifado, transferir item do Almox. p/ o C.C.
                    {
                        try
                        {
                            if (dtoMovimento.IdtProduto.Value.IsNull) dtoMovimento.IdtProduto.Value = dtoMatMed.Idt.Value;
                            if (!new Generico().TransferirItemDeAlmoxCentralPara(dtoMovimento)) return;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // ############## GERA O MOVIMENTO #############################################################
                    dtoMovimento = Movimento.MovimentaEstoqueProduto(dtoMovimento, dtoMatMed, null);
                    // #############################################################################################

                    // dtgConsumo.DataSource = this.AtualizaGrid();
                    //this.CarregarHistoricoConsumo();
                    //MovimentacaoDTO dtoMovSel = new MovimentacaoDTO();
                    //dtoMovSel.Idt.Value = dtoMovimento.Idt.Value;
                    //dtoMovimento = Movimento.Sel(dtoMovSel, true).TypedRow(0);   

                    if (_logadoAlmoxCentral && !cbCE.Checked && dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM && !dtoMatMed.UnidadeVenda.Value.IsNull)
                        dtoMovimento.DsQtdeConsumo.Value = (dtoMovimento.Qtde.Value * dtoMatMed.UnidadeVenda.Value) + "/" + dtoMatMed.UnidadeVenda.Value;

                    dtbMovimento.Add(dtoMovimento);
                    DesabilitarExlusao(true);

                    if (cmbKit.SelectedIndex > -1)
                    {
                        if (dtbMovimento.Columns.IndexOf(KitDTO.FieldNames.IdKit) == -1)
                            dtbMovimento.Columns.Add(KitDTO.FieldNames.IdKit);

                        if (dtbMovimento.Columns.IndexOf(KitDTO.FieldNames.Descricao) == -1)
                            dtbMovimento.Columns.Add(KitDTO.FieldNames.Descricao);

                        dtbMovimento.Rows[dtbMovimento.Rows.Count - 1][KitDTO.FieldNames.IdKit] = cmbKit.SelectedValue.ToString();
                        dtbMovimento.Rows[dtbMovimento.Rows.Count - 1][KitDTO.FieldNames.Descricao] = cmbKit.Text;
                    }

                    dtgHistConsumo.DataSource = dtbMovimento;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dtbMovimento.AcceptChanges();
                txtCodProduto.Text = string.Empty;
                txtCodProduto.Focus();
                tsHac.Items["tsBtnNovo"].Enabled = true;
                chkFracionar.Checked = false;
                dtgHistConsumo.Sort(dtgHistConsumo.Columns["colDataHist"], ListSortDirection.Descending);
                dtgHistConsumo.ClearSelection();                
            }
        }

        private void DesabilitarExlusao(bool desabilitar)
        {            
            dtgHistConsumo.Columns["colChkExcluir"].Visible = !desabilitar;
            dtgHistConsumo.Columns["colDsQtdeConvertida"].Visible = !desabilitar;
            chkExcluirProximo.Enabled = !desabilitar;
            btnExcluir.Enabled = !desabilitar;
            txtDscPesquisa.Enabled = !desabilitar;
        }

        //private void SalvarPedidoCE()
        //{
        //    try
        //    {
        //        if (dtbRequisicaoItemCE.Rows.Count > 0)
        //        {
        //            ConfiguraRequisicaoCEDTO();
        //            dtoRequisicaoCE.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
        //            Requisicao.Gravar(dtoRequisicaoCE, dtbRequisicaoItemCE);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Não foi consumido nenhum produto para a geração de pedido do carrinho de emergência", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        }
        //        dtoRequisicaoCE = null;
        //        dtbRequisicaoItemCE = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        /// <summary>
        /// Verifica se pode consumir pelas regras do faturamento
        /// </summary>
        
        private bool PermitirConsumo()
        {
            // verifco novamente
            MovimentacaoDTO dto = new MovimentacaoDTO();
            dto.IdtAtendimento.Value = dtoAtendimento.Idt.Value;
            dto.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dto.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dto.IdtSetor.Value = cmbSetor.SelectedValue.ToString();

            MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();
            // cfg
            dtoCfg.IdtUnidade.Value = dto.IdtUnidade.Value;
            dtoCfg.IdtLocal.Value = dto.IdtLocal.Value;
            dtoCfg.Idtsetor.Value = dto.IdtSetor.Value;
            dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);
            if (dtoCfg.AtendeTodosSetores.Value == 1)
            {
                if (dto.IdtLocal.Value == (int)PacienteDTO.LocalAtendimento.CENTRO_CIRURGICO)
                    dto.IdtLocal.Value = (int)PacienteDTO.LocalAtendimento.INTERNADO;
                dto.IdtSetor.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
            }

            try
            {
                //if (!Movimento.PermiteConsumo(dto))
                //{
                //    CONTA_FATURADA = (int)PacienteDTO.Faturada.SIM;
                //    lblContaFaturada.Visible = true;
                //}
                //else
                //{
                //    CONTA_FATURADA = (int)PacienteDTO.Faturada.NAO;
                //    lblContaFaturada.Visible = false;
                //}
                CONTA_FATURADA = (int)PacienteDTO.Faturada.NAO;
                lblContaFaturada.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (CONTA_FATURADA == (int)PacienteDTO.Faturada.SIM)
            {
                MessageBox.Show("CONTA FATURADA", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                lblContaFaturada.Visible = false;
            }
            return true;

        }

        // private int DigitarQtde()
        private MovimentacaoDTO DigitarQtde()
        {
            // MovimentacaoDTO dtoMov = new MovimentacaoDTO();

            dtoMovimento.DsProduto.Value = dtoMatMed.NomeFantasia.Value;
            dtoMovimento.FlFracionado.Value = dtoMatMed.FlFracionado.Value;
            dtoMovimento.UnidadeVenda.Value = dtoMatMed.UnidadeVenda.Value;
            dtoMovimento.DsUnidadeVenda.Value = dtoMatMed.DsUnidadeVenda.Value;
            dtoMovimento.FormOrigem.Value = (int)MovimentacaoDTO.TelaOrigem.CONSUMO_PACIENTE;
            dtoMovimento.TpFracao.Value = dtoMatMed.TpFracao.Value;

            dtoMovimento = FrmQtdMatMed.DigitaQtde(dtoMovimento);

            if (dtoMovimento == null) dtoMovimento = new MovimentacaoDTO();
            // dtoMatMed.FlFracionado.Value = dtoMovimento.FlFracionado.Value;
            if (dtoMovimento.Qtde.Value.IsNull) dtoMovimento.Qtde.Value = 0;

            // return (int)dtoMov.Qtde.Value;
            return dtoMovimento;
        }

        private bool ZerarObjetos(bool finalizarPedidoCarrEmergSemMsg, bool cancelar)
        {
            #region CE
            if (dtbRequisicaoItemCE != null)
            {
                if (dtbRequisicaoItemCE.Rows.Count > 0)
                {
                    if (finalizarPedidoCarrEmergSemMsg)
                    {
                        //SalvarPedidoCE();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Finalize o Consumo do Carrinho de Emergência",
                                        "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnFinalizarCE.Focus();
                        return false;
                    }
                }
            }
            #endregion

            // lblLegenda.Visible = false;            
            dtoAtendimento = null;
            dtoMatMed = null;
            dtbMovimento = new MovimentacaoDataTable();
            // dtbMovimento = new MovimentacaoDataTable();
            // dtgConsumo.DataSource = null;
            dtgHistConsumo.DataSource = null;
            dtoRequisicaoCE = null;
            dtbRequisicaoItemCE = null;
            cbCE.Checked = false;
            btnFinalizarCE.Visible = false;
            btnHistorico.Enabled = false;

            txtDtTranf.Text = string.Empty;
            txtHrTransf.Text = string.Empty;
            CONTA_FATURADA = (int)PacienteDTO.Faturada.NAO;
            lblContaFaturada.Visible = false;
            btnExcluir.Enabled = pnlIndiceDev.Visible = false;

            CarregarComboKit(false, cancelar);
            cmbKit.Enabled = false;
            rbInternado.Checked = true;

            return true;
        }

        private void MarcarExclusao()
        {
            CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();

            dtoCodigoBarra.CdBarra.Value = txtCodProduto.Text; ;
            dtoCodigoBarra.IdtFilial.Value = RetornaFilial();

            // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
            MaterialMedicamentoDTO dtoMatMedExcluir = MatMed.BuscaCodigoBarra(dtoCodigoBarra);

            if (dtoMatMedExcluir == null)
            {
                MessageBox.Show(" Material/medicamento não identificado ", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodProduto.Text = string.Empty;
                txtCodProduto.Focus();
                return;
            }

            DataRow[] rowsProduto = MovimentoDadosGrid.Select(string.Format("{0} = {1}", MovimentacaoDTO.FieldNames.IdtProduto, dtoMatMedExcluir.Idt.Value));

            if (rowsProduto.Length > 0)
            {
                if (PermitirConsumo())
                {
                        this.Cursor = Cursors.WaitCursor;
                        foreach (DataGridViewRow dtgRow in dtgHistConsumo.Rows)
                        {
                            if (dtgRow.Cells["colIdtProdutoHist"].Value.ToString() == dtoMatMedExcluir.Idt.Value && !bool.Parse(dtgRow.Cells["colChkExcluir"].EditedFormattedValue.ToString()))
                            {
                                dtgRow.Cells["colChkExcluir"].Value = 1;
                                break;
                            }
                        }
                        this.Cursor = Cursors.Default;
                }
            }
            else
            {
                MessageBox.Show(" Material/medicamento não registrado até o momento para este paciente ", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            txtCodProduto.Text = string.Empty;
            txtCodProduto.Focus();
        }

        private void ExcluirPeloCodBarra()
        {
            CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();

            dtoCodigoBarra.CdBarra.Value = txtCodProduto.Text; ;
            dtoCodigoBarra.IdtFilial.Value = RetornaFilial();

            // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
            MaterialMedicamentoDTO dtoMatMedExcluir = MatMed.BuscaCodigoBarra(dtoCodigoBarra);

            if (dtoMatMedExcluir == null)
            {
                MessageBox.Show(" Material/medicamento não identificado ", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodProduto.Text = string.Empty;
                txtCodProduto.Focus();
                return;
            }

            DataRow[] rowsProduto = MovimentoDadosGrid.Select(string.Format("{0} = {1}", MovimentacaoDTO.FieldNames.IdtProduto, dtoMatMedExcluir.Idt.Value));

            if (rowsProduto.Length > 0)
            {
                if (PermitirConsumo())
                {
                    if (MessageBox.Show(string.Format("Deseja realmente estornar o produto {0} ?", dtoMatMedExcluir.NomeFantasia.Value),
                                        "Gestão de Materiais e Medicamentos",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        foreach (DataGridViewRow dtgRow in dtgHistConsumo.Rows)
                        {
                            if (dtgRow.Cells["colIdtProdutoHist"].Value.ToString() == dtoMatMedExcluir.Idt.Value)
                            {
                                this.ExcluirProduto(dtgRow);
                                break;
                            }
                        }
                        this.CarregarHistoricoConsumo();
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            else
            {
                MessageBox.Show(" Material/medicamento não registrado até o momento para este paciente ", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            txtCodProduto.Text = string.Empty;
            txtCodProduto.Focus();
        }

        private void ExcluirProduto(DataGridViewRow dtgRow)
        {
            dtoPedidoPadrao = new PedidoPadraoDTO();

            dtoPedidoPadrao.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoPedidoPadrao.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoPedidoPadrao.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoPedidoPadrao.Status.Value = (byte)PedidoPadraoDTO.StatusPedidoPadrao.CONFIRMADO;

            dtoPedidoPadrao.IdtFilial.Value = RetornaFilial();

            dtoMatMed = new MaterialMedicamentoDTO();
            dtoMatMed.Idt.Value = dtgRow.Cells["colIdtProdutoHist"].Value.ToString();
            dtoMatMed = MatMed.SelChave(dtoMatMed);

            ConfiguraMovimentoDTO();
            dtoMovimento.Idt.Value = decimal.Parse(dtgRow.Cells["colIdtMovimentoHist"].Value.ToString());

            //PedidoPadraoItensDTO dtoPedPadItem = new PedidoPadraoItensDTO();

            //if (byte.Parse(dtgRow.Cells["colSubTpMov"].Value.ToString()) != (byte)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA &&
            //    byte.Parse(dtgRow.Cells["colSubTpMov"].Value.ToString()) != (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_FRACIONADA_NAO_FATURADA &&
            //    byte.Parse(dtgRow.Cells["colSubTpMov"].Value.ToString()) != (byte)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA_CARRINHO_EMERGENCIA)
            //{
            //    if (PedidoPadrao.ProdutoPadrao(dtoPedidoPadrao, dtoMatMed, ref dtoPedPadItem, true))
            //    {
            //        decimal qtdNova = decimal.Parse(dtgRow.Cells["colQtdHist"].Value.ToString()) + dtoPedPadItem.EstoqueLocalQtde.Value.DBValue.Value;

            //        if (qtdNova > dtoPedPadItem.Qtde.Value)
            //        {
            //            MessageBox.Show("Não pode ser realizado o estorno deste produto neste momento, pois ele pertence ao estoque fixo que já está cheio", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //            dtgRow.DefaultCellStyle.BackColor = Color.Red;
            //        }
            //    }
            //}
            if (Movimento.PermitirEstornoConsumoItem(ref dtoMovimento))
            {
                try
                {
                    dtoMovimento.IdtFilial.Value = decimal.Parse(dtgRow.Cells["colIdFilial"].Value.ToString());
                    dtoMovimento.IdtProduto.Value = decimal.Parse(dtgRow.Cells["colIdtProdutoHist"].Value.ToString());
                    dtoMovimento.Qtde.Value = decimal.Parse(dtgRow.Cells["colQtdInteiraHist"].Value.ToString());
                    dtoMovimento.IdtUsuarioEstorno.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    Movimento.EstornarMovimentoConsumoPaciente(dtoMovimento);
                    // dtbMovimento = new MovimentacaoDataTable();
                    // dtgConsumo.DataSource = dtbMovimento;
                    if (rbDevAlmox.Checked)
                    {
                        RequisicaoDTO dtoRequisicao = new RequisicaoDTO();  
                        dtoRequisicao.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                        dtoRequisicao.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                        dtoRequisicao.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                        dtoRequisicao.IdtFilial.Value = dtoMovimento.IdtFilial.Value; //(byte)FilialMatMedDTO.Filial.HAC;
                        dtoRequisicao.IdtAtendimento.Value = txtNroInternacao.Text;
                        //dtoRequisicao.Idt.Value = ;
                        RequisicaoItensDTO dtoReqItem = new RequisicaoItensDTO();
                        dtoReqItem.IdtProduto.Value = dtoMovimento.IdtProduto.Value;
                        dtoReqItem.QtdFornecida.Value = dtoMovimento.Qtde.Value;
                        if (!string.IsNullOrEmpty(dtgRow.Cells[colLoteID.Name].Value.ToString()) && decimal.Parse(dtgRow.Cells[colLoteID.Name].Value.ToString()) != 0)
                        {
                            dtoMovimento.IdtLote.Value = decimal.Parse(dtgRow.Cells[colLoteID.Name].Value.ToString());
                            dtoReqItem.IdtLote.Value = dtoMovimento.IdtLote.Value;
                        }

                        new Generico().TransferirItemParaAlmoxCentral(dtoRequisicao, dtoReqItem);
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.IndexOf("Object") == -1)
                        MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtgRow.DefaultCellStyle.BackColor = Color.Red;
                    // this.Cursor = Cursors.Default;
                }
            }
            else
            {
                _produtosNaoExcluidos += string.Format("- {0} ({1})\n", dtgRow.Cells["colDsProdutoHist"].Value.ToString(), dtgRow.Cells["colDataHist"].Value.ToString());
            }
        }

        private bool ValidarPeriodo()
        {
            if (txtDtIni.Text == string.Empty)
            {
                MessageBox.Show("Digite a Data Início", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDtIni.Focus();
                return false;
            }
            if (txtDtFim.Text == string.Empty)
            {
                MessageBox.Show("Digite a Data Fim", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDtFim.Focus();
                return false;
            }
            try
            {
                if (Convert.ToDateTime(txtDtFim.Text).Date < Convert.ToDateTime(txtDtIni.Text).Date)
                {
                    MessageBox.Show("A Data Fim deve ser maior ou igual à Data Início.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDtFim.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Data inválida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Convert.ToDateTime(txtDtFim.Text).Date > Convert.ToDateTime(txtDtIni.Text).Date.AddMonths(6).Date)
            {
                MessageBox.Show("Período não pode ser superior a 6 meses.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDtFim.Focus();
                return false;
            }            
            return true;
        }

        private void CarregarComboKit(bool devolucao, bool cancelar)
        {
            if (baixaKit)
            {
                this.Cursor = Cursors.WaitCursor;
                cmbKit.Visible = lblKit.Visible = true;
                if (!devolucao && !cancelar)
                {
                    KitDTO dtoKit = new KitDTO();
                    dtoKit.Ativo.Value = 1;
                    dtoKit.IdSetor.Value = cmbSetor.SelectedValue.ToString();
                    cmbKit.DataSource = Kit.Listar(dtoKit);
                }
                else if (dtoAtendimento != null && !dtoAtendimento.Idt.Value.IsNull && !cancelar)
                {
                    MovimentacaoDTO dtoMov = new MovimentacaoDTO();
                    dtoMov.IdtAtendimento.Value = dtoAtendimento.Idt.Value;
                    dtoMov.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                    cmbKit.DataSource = Movimento.ObterKitsConsumidosPaciente(dtoMov);
                }
                cmbKit.IniciaLista();
                this.Cursor = Cursors.Default;
            }
        }

        private int SaldoEstoque()
        {
            EstoqueLocalDTO dtoEstoque = new EstoqueLocalDTO();

            dtoEstoque.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoEstoque.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoEstoque.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoEstoque.IdtProduto.Value = dtoMatMed.Idt.Value;            
            if (cbConsignado.Checked)
                dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.CONSIGNADO;
            else
                dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;

            dtoEstoque = Estoque.EstoqueLocalProduto(dtoEstoque);

            if (dtoEstoque.Qtde.Value.IsNull) dtoEstoque.Qtde.Value = 0;

            return (int)dtoEstoque.Qtde.Value;
        }

        #endregion

        #region Eventos

        private void FrmConsumoPaciente_Load(object sender, EventArgs e)
        {
            cbConsignado.Visible = true;
            cmbUnidade.Enabled = cmbLocal.Enabled = cmbSetor.Enabled = cmbKit.Enabled = false;
            cmbUnidade.Editavel = cmbLocal.Editavel = cmbSetor.Editavel = ControleEdicao.Nunca;
            cmbUnidade.Carregaunidade();
            cmbUnidade.SelectedValue = 244; //SANTOS
            cmbLocal.SelectedValue = 29; //INTERNADO
            cmbSetor.SelectedValue = 61; //CENTRO CIRURGICO
            AtribuirEstoqueUnico();

            _logadoAlmoxCentral = this.LogadoAlmoxCentral();

            ConfiguraDTG();
            btnExcluir.Enabled = false;
#if DEBUG
            //tsHac.Items["tsBtnMatMed"].Visible = true;
            txtDtTranf.Visible = true;
            txtHrTransf.Visible = true;
#else
                //tsHac.Items["tsBtnMatMed"].Visible = false;
#endif
            tsHac.Items["tsBtnMatMed"].Visible = true;
            //CarregarComboKit(false);
            tsHac.Items["tsBtnPrint"].Visible = tsHac.Items["tsBtnPrint"].Enabled = true;
            tsHac.Items["tsBtnPrint"].Text = "Imprimir Consumo";
            tsHac.Items["tsBtnPrint"].Size = new Size(140, 25);
        }

        private void btnPesquisaPac_Click(object sender, EventArgs e)
        {
            if (txtNroInternacao.Enabled)
            {
                // this.PesquisarPaciente();
                CarregaInfoPaciente();
                tsHac.Items["tsBtnNovo"].Enabled = true;                
                btnHistorico.Enabled = true;
                txtDscPesquisa.Text = string.Empty;
            }
        }

        private void txtNroInternacao_Validated(object sender, EventArgs e)
        {
            if (txtNroInternacao.Text.Length != 0)
            {
                btnPesquisaPac_Click(sender, e);
                tsHac.Items["tsBtnNovo"].Enabled = true;
                txtDscPesquisa.Text = string.Empty;
            }
        }

        private void txtCodProduto_Validating(object sender, CancelEventArgs e)
        {
            if (txtCodProduto.Text != string.Empty)
            {
                if (!chkExcluirProximo.Checked)
                {
                    dtoMatMed = null;
                    if (cmbKit.SelectedIndex > -1) cmbKit.IniciaLista();
                    this.BaixarProduto(null);
                    tsHac.Items["tsBtnNovo"].Enabled = true;
                }
                else
                {
                    // this.ExcluirPeloCodBarra();
                    MarcarExclusao();
                }
            }
        }

        private bool tsHac_MatMedClick(object sender)
        {            
            if ((!rbAcs.Checked && !rbHac.Checked) || dtoAtendimento == null)
            {
                MessageBox.Show("Pesquise o paciente", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroInternacao.Focus();
                return false;
            }
            if (!PermitirConsumo()) return false;
            dtoMatMed = new MaterialMedicamentoDTO();
            // byte idFilial = 
            // MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();
            dtoMatMed.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoMatMed.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoMatMed.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            //dtoMatMed.IdtFilial.Value = rbHac.Checked ? (byte)FilialMatMedDTO.Filial.HAC : (byte)FilialMatMedDTO.Filial.ACS;
            dtoMatMed.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC; //gen.RetornaFilial(rbHac, rbAcs); // rbHac.Checked ? (byte)FilialMatMedDTO.Filial.HAC : (byte)FilialMatMedDTO.Filial.ACS;
            dtoMatMed.FlAtivo.Value = 1;

            // dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(MaterialMedicamentoDTO.TipoMatMed.TODOS, idFilial);
            dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMed);
            if (dtoMatMed != null)
            {
                if (!dtoMatMed.Idt.Value.IsNull)
                {
                    if ((int)dtoMatMed.IdtGrupo.Value == 1)
                    {
                        MessageBox.Show("Obrigatório baixa pelo Código de Barra para Medicamentos !", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCodProduto.Focus();
                        return false;
                    }
                    else
                    {
                        if (cmbKit.SelectedIndex > -1) cmbKit.IniciaLista();
                        this.Cursor = Cursors.WaitCursor;
                        this.BaixarProduto(null);
                        this.Cursor = Cursors.Default;
                    }
                }
            }

            return true;
        }

        private bool tsHac_SairClick(object sender)
        {
            return ZerarObjetos(false, true);
        }

        private bool tsHac_NovoClick(object sender)
        {
            return ZerarObjetos(false, false);
        }

        private bool tsHac_AfterNovo(object sender)
        {
            //tsHac.Items["tsBtnMatMed"].Visible = false;
            grpTipoAtendimento.Enabled = true;
            rbAmbPS.Enabled = true;
            rbInternado.Enabled = true;
            return true;
        }

        private bool tsHac_CancelarClick(object sender)
        {
            return ZerarObjetos(false, true);
        }

        private void tsHac_AfterCancelar(object sender)
        {
            //tsHac.Items["tsBtnMatMed"].Visible = false;
            grpTipoAtendimento.Enabled = false;
        }

        private void cmbUnidade_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ZerarObjetos(false, true)) tsHac.Controla(Evento.eCancelar);
        }

        private void cmbLocal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ZerarObjetos(false, true)) tsHac.Controla(Evento.eCancelar);
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ZerarObjetos(false, false)) tsHac.Controla(Evento.eCancelar);
        }

        private void cmbKit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbKit.SelectedIndex > -1)
            {
                string dsc = "Deseja realmente BAIXAR o Kit " + cmbKit.Text + " para este paciente ?";
                if (chkExcluirProximo.Checked) dsc = "Deseja realmente DEVOLVER o Kit " + cmbKit.Text + " deste paciente ?";
                if (MessageBox.Show(dsc, "Gestão de Materiais e Medicamentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (!chkExcluirProximo.Checked)
                    {
                        int qtdTotalMat = 0;
                        KitDTO dtoKit = new KitDTO();
                        dtoKit.IdKit.Value = cmbKit.SelectedValue.ToString();
                        KitDataTable dtbKit = Kit.ListarItem(dtoKit);
                        foreach (DataRow row in dtbKit.Rows)
                        {
                            if (int.Parse(row[MaterialMedicamentoDTO.FieldNames.IdtGrupo].ToString()) != 1) //Não baixar medicamento
                            {
                                dtoMatMed = new MaterialMedicamentoDTO();
                                dtoMatMed.Idt.Value = row[KitDTO.FieldNames.IdProduto].ToString();
                                dtoMatMed = MatMed.SelChave(dtoMatMed);
                                if (SaldoEstoque() >= int.Parse(row[KitDTO.FieldNames.QtdeItem].ToString()))
                                {
                                    qtdTotalMat = int.Parse(row[KitDTO.FieldNames.QtdeItem].ToString());
                                    for (int qtdAdd = 1; qtdAdd <= qtdTotalMat; qtdAdd++)
                                    {
                                        this.BaixarProduto(1);
                                        if (!dtoMovimento.Idt.Value.IsNull)
                                            Movimento.AtualizarKit(decimal.Parse(cmbKit.SelectedValue.ToString()), (decimal)dtoMovimento.Idt.Value);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (dtgHistConsumo.Rows.Count > 0)
                        {
                            if (PermitirConsumo())
                            {
                                this.Cursor = Cursors.WaitCursor;
                                _produtosNaoExcluidos = string.Empty;
                                foreach (DataGridViewRow dtgRow in dtgHistConsumo.Rows)
                                {
                                    if (!string.IsNullOrEmpty(dtgRow.Cells[colKitID.Name].Value.ToString()) &&
                                        int.Parse(dtgRow.Cells[colKitID.Name].Value.ToString()) == int.Parse(cmbKit.SelectedValue.ToString()))
                                    {
                                        this.ExcluirProduto(dtgRow);
                                    }
                                }
                                this.CarregarHistoricoConsumo();
                                if (!string.IsNullOrEmpty(_produtosNaoExcluidos))
                                {
                                    MessageBox.Show(string.Format("Os seguintes produtos não foram excluidos, pois já foram faturados:\n\n{0}", _produtosNaoExcluidos), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    _produtosNaoExcluidos = string.Empty;
                                }
                                CarregarComboKit(chkExcluirProximo.Checked, false);
                                this.Cursor = Cursors.Default;                                
                                txtCodProduto.Text = string.Empty;
                                txtCodProduto.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Não existem itens a serem excluidos", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    cmbKit.IniciaLista();
                    txtCodProduto.Focus();
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    cmbKit.IniciaLista();
                    txtCodProduto.Focus();
                }
            }
        }

        private void dtgHistConsumo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dtgHistConsumo.Columns[e.ColumnIndex].Name == "colDsProdutoHist")
                {
                    if (dtgHistConsumo.Rows[e.RowIndex].Cells["colIdFilial"].Value.ToString() != string.Empty)
                    {
                        if (byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colIdFilial"].Value.ToString()) == (byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA)
                        {
                            //e.Value = string.Format("CARRO EMERG. -> {0}", e.Value.ToString());
                            e.Value = string.Format("{0} (CARRO EMERG.)", e.Value.ToString());
                        }
                    }
                    if (dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString() != string.Empty) //&& chkExcluirProximo.Enabled
                    {
                        if (byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString()) == (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_SETOR_CONSUMO_PACIENTE ||
                            byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString()) == (byte)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA ||
                            byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString()) == (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_CONSUMO_CARRINHO_EMERGENCIA_FATURADO)
                        {
                            // e.CellStyle.ForeColor = Color.Gray;
                            dtgHistConsumo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                        }
                    }
                }
                //if (!this.PermitirExclusao(decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colIdtMovimentoHist"].Value.ToString())))
                //{
                //    lblLegenda.Visible = true;
                //    e.CellStyle.BackColor = Color.Yellow;
                //}   
            }
        }
        #region desuso
        /*
        private void dtgHistConsumo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgHistConsumo.Columns[e.ColumnIndex].Name == "colDeletarHist")
            {
                this.Cursor = Cursors.WaitCursor;
                dtoPedidoPadrao = new PedidoPadraoDTO();                

                dtoPedidoPadrao.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                dtoPedidoPadrao.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                dtoPedidoPadrao.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                dtoPedidoPadrao.Status.Value = (byte)PedidoPadraoDTO.StatusPedidoPadrao.CONFIRMADO;
                if (rbHac.Checked)
                {
                    dtoPedidoPadrao.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
                }
                else if (rbAcs.Checked)
                {
                    dtoPedidoPadrao.IdtFilial.Value = (int)FilialMatMedDTO.Filial.ACS;
                }

                dtoMatMed = new MaterialMedicamentoDTO();
                dtoMatMed.Idt.Value = dtgHistConsumo.Rows[e.RowIndex].Cells["colIdtProdutoHist"].Value.ToString();
                dtoMatMed = MatMed.SelChave(dtoMatMed);

                ConfiguraMovimentoDTO();
                dtoMovimento.Idt.Value = decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colIdtMovimentoHist"].Value.ToString());

                PedidoPadraoItensDTO dtoPedPadItem = new PedidoPadraoItensDTO();

                if (byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString()) != (byte)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA &&
                    byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString()) != (byte)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA_CARRINHO_EMERGENCIA)
                {
                    if (PedidoPadrao.ProdutoPadrao(dtoPedidoPadrao, dtoMatMed, ref dtoPedPadItem, true))
                    {
                        decimal qtdNova = decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colQtdHist"].Value.ToString()) + dtoPedPadItem.EstoqueLocalQtde.Value.DBValue.Value;

                        if (qtdNova > dtoPedPadItem.Qtde.Value)
                        {
                            MessageBox.Show("Não pode ser realizado o estorno deste produto neste momento, pois ele pertence ao estoque fixo que já está cheio", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }
                }                            
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
                        this.CarregarHistoricoConsumo();
                        // dtbMovimento = new MovimentacaoDataTable();
                        // dtgConsumo.DataSource = dtbMovimento;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Cursor = Cursors.Default;
                    }                        
                }                
                this.Cursor = Cursors.Default;
            }
        }
        */
        #endregion

        private void tabConsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodProduto.Focus();
            tsHac.Items["tsBtnNovo"].Enabled = true;
        }

        private void cbCE_Click(object sender, EventArgs e)
        {
            if (PermitirConsumo())
            {
                if (cbCE.Checked)
                {
                    //MessageBox.Show("O próximo consumo gerará um pedido para o almoxarifado, para o reabastecimento do carrinho de emergência", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MessageBox.Show("Os próximos consumos gerarão um pedido para o almoxarifado, para o reabastecimento do carrinho de emergência.\n\nDepois de registrar o(s) consumo(s), clique em Finalizar Consumo do Carrinho de Emergência.",
                                    "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbCE.Enabled = false;
                    btnFinalizarCE.Visible = true;
                    dtbRequisicaoItemCE = new RequisicaoItensDataTable();
                }
                else
                {
                    dtoRequisicaoCE = null;
                    dtbRequisicaoItemCE = null;
                }
                txtCodProduto.Focus();
            }
        }

        private void btnFinalizarCE_Click(object sender, EventArgs e)
        {
            if (PermitirConsumo())
            {
                // SalvarPedidoCE();
                cbCE.Checked = false;
                cbCE.Enabled = true;
                btnFinalizarCE.Visible = false;
                txtCodProduto.Focus();
            }
        }

        private void FrmConsumoPaciente_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !ZerarObjetos(true, true);
        }

        private bool tsHac_SalvarClick(object sender)
        {
            if (dtoAtendimento == null) return false;
            if (!PermitirConsumo()) return false;
            if (!new Generico().ValidarContaFaturadaComNF((decimal)dtoAtendimento.Idt.Value, decimal.Parse(cmbSetor.SelectedValue.ToString())))
            {
                MessageBox.Show("A conta deste paciente já foi faturada e mais nenhum produto pode ser registrado na mesma", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            this.Cursor = Cursors.WaitCursor;
            string quebraLinha = System.Environment.NewLine.ToString();
            ConfiguraMovimentoDTO();
            dtoMovimento.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
            try
            {
                Movimento.SalvaMovimentoCentroCirurgico(dtoMovimento);
                CarregarHistoricoConsumo();
                MessageBox.Show(" Itens faturados com sucesso ", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnExcluir.Enabled = false;
                btnHistorico.Enabled = false;
                cmbKit.Enabled = false;
                cmbKit.IniciaLista();
                this.Cursor = Cursors.Default;
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(" NÃO FOI POSSÍVEL FATURAR OS ITENS " + quebraLinha + quebraLinha + quebraLinha + e.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                return false;
            }
            this.Cursor = Cursors.Default;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dtgHistConsumo.Rows.Count > 0)
            {
                if (PermitirConsumo())
                {
                    if (MessageBox.Show("Deseja realmente estornar os Produtos Selecionados ?",
                                        "Gestão de Materiais e Medicamentos",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        _produtosNaoExcluidos = string.Empty;
                        foreach (DataGridViewRow dtgRow in dtgHistConsumo.Rows)
                        {
                            if (bool.Parse(dtgRow.Cells["colChkExcluir"].EditedFormattedValue.ToString()))
                            {
                                this.ExcluirProduto(dtgRow);
                            }
                        }
                        this.CarregarHistoricoConsumo();
                        if (!string.IsNullOrEmpty(_produtosNaoExcluidos))
                        {
                            MessageBox.Show(string.Format("Os seguintes produtos não foram excluidos, pois já foram faturados:\n\n{0}", _produtosNaoExcluidos), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            _produtosNaoExcluidos = string.Empty;
                        }
                        this.Cursor = Cursors.Default;
                    }
                    txtCodProduto.Text = string.Empty;
                    txtCodProduto.Focus();
                }
            }
            else
            {
                MessageBox.Show("Não existem itens a serem excluidos", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtDscPesquisa_TextChanged(object sender, EventArgs e)
        {
            MovimentoDadosGrid.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", MovimentacaoDTO.FieldNames.DsProduto, txtDscPesquisa.Text);
        }

        private void chkExcluirProximo_Click(object sender, EventArgs e)
        {
            CarregarComboKit(chkExcluirProximo.Checked, false);
            txtDscPesquisa.Text = string.Empty;
            txtCodProduto.Text = string.Empty;
            txtCodProduto.Focus();
        }

        private void txtCodProduto_Enter(object sender, EventArgs e)
        {
            if (chkExcluirProximo.Checked) txtDscPesquisa.Text = string.Empty;
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            dtbMovimento.Rows.Clear();
            if (!dtoAtendimento.NmPaciente.Value.IsNull) CarregarHistoricoConsumo();
            txtCodProduto.Focus();
        }

        private void btnPendencia_Click(object sender, EventArgs e)
        {
            MovimentacaoDTO dtoPendencia = new MovimentacaoDTO();
            dtoPendencia.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoPendencia.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoPendencia.IdtSetor.Value = cmbSetor.SelectedValue.ToString();

            if (frm == null || frm.IsDisposed)
            {
                frm = new FrmCentroCirurgicoPendencia(dtoPendencia);
                frm.MdiParent = FrmPrincipal.ActiveForm;

            }

            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.Focus();
        }

        private void hacLabel1_DoubleClick(object sender, EventArgs e)
        {
            dtgHistConsumo.Columns["colSubTpMov"].Visible = !(dtgHistConsumo.Columns["colSubTpMov"].Visible);
        }

        private void btnDevolucoes_Click(object sender, EventArgs e)
        {
            txtDtIni.Text = Utilitario.ObterDataHoraServidor().AddMonths(-1).ToString("dd/MM/yyyy");
            txtDtFim.Text = Utilitario.ObterDataHoraServidor().ToString("dd/MM/yyyy");            

            pnlIndiceDev.BorderStyle = BorderStyle.FixedSingle;
            pnlIndiceDev.Visible = true;
        }

        private void btnCancelarPlanilha_Click(object sender, EventArgs e)
        {
            pnlIndiceDev.Visible = false;
            txtDtIni.Text = txtDtFim.Text = string.Empty;
        }

        private void btnGerarIndice_Click(object sender, EventArgs e)
        {
            if (!ValidarPeriodo()) return;

            this.Cursor = Cursors.WaitCursor;

            RequisicaoDTO dto = new RequisicaoDTO();
            dto.DataRequisicao.Value = txtDtIni.Text;
            dto.DataRequisicao2.Value = txtDtFim.Text;

            string nomeRelatorio = "GM_42_DEVOLUCOES_CENTRO_CIR";
            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[3];

            #region Monta Parâmetros

            int x = 0;

            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("DATA_DE", txtDtIni.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("DATA_ATE", DateTime.Parse(txtDtFim.Text).ToString("dd/MM/yyyy 23:59:59"));

            #endregion

            Microsoft.Reporting.WinForms.ReportParameter[] reportParamTemp = new Microsoft.Reporting.WinForms.ReportParameter[x];

            for (int i = 0; i < reportParam.Length; i++)
            {
                if (reportParam[i] == null) break;
                reportParamTemp[i] = reportParam[i];
            }
            reportParam = reportParamTemp;
            reportParamTemp = null;

            FrmReportViewer frmRelatorio = new FrmReportViewer();
            frmRelatorio.AbreRelatorio(nomeRelatorio, reportParam);

            this.Cursor = Cursors.Default;
        }

        private void rbInternado_Click(object sender, EventArgs e)
        {
            txtNroInternacao.Focus();
        }

        private void cbConsignado_Click(object sender, EventArgs e)
        {
            if (cbConsignado.Checked)
                tsHac.Items["tsBtnMatMed"].Visible = true;
            //else
            //    tsHac.Items["tsBtnMatMed"].Visible = false;
        }

        private bool tsHac_ImprimirClick(object sender)
        {
            if (txtNomePac.Text == string.Empty)
            {
                MessageBox.Show("Nenhum atendimento foi carregado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            
            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[8];
            string nomeRelatorio = "GM_62_CENTRO_CIR_CONSUMO";
            if (sender.ToString().IndexOf("Ficha de Despesa") > -1)
                nomeRelatorio = "GM_63_CENTRO_CIR_FICHA_DESP";            

            #region Monta Parâmetros

            int x = 0;

            if (nomeRelatorio == "GM_62_CENTRO_CIR_CONSUMO")
            {
                if (Movimento.ContaSalvaFaturamento(decimal.Parse(txtNroInternacao.Text)))
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("TITULO_REL", "CONSUMO PACIENTE CENTRO CIRÚRGICO - ITENS UTILIZADOS");
                else
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("TITULO_REL", "CONSUMO PACIENTE CENTRO CIRÚRGICO - ITENS SEPARADOS");

                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_SET_ID", cmbSetor.SelectedValue.ToString());
            }
            else
            {
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCREDENCIAL", dtoAtendimento.Credencial.Value);
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMAE", dtoAtendimento.NmMae.Value);
            }
            
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PATD_ATE_ID", txtNroInternacao.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PPACIENTE", txtNomePac.Text);

            if (dtoAtendimento != null)
            {
                if (!dtoAtendimento.DtNascimento.Value.IsNull) 
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDT_NASC", dtoAtendimento.DtNascimento.Value.ToString().Substring(0, 10));

                if (!dtoAtendimento.DsEmpresa.Value.IsNull && !dtoAtendimento.CdPlano.Value.IsNull)
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCONVENIO", dtoAtendimento.CdPlano.Value.ToString() + " / " + dtoAtendimento.DsEmpresa.Value);
            }
            #endregion

            Microsoft.Reporting.WinForms.ReportParameter[] reportParamTemp = new Microsoft.Reporting.WinForms.ReportParameter[x];

            for (int i = 0; i < reportParam.Length; i++)
            {
                if (reportParam[i] == null) break;
                reportParamTemp[i] = reportParam[i];
            }
            reportParam = reportParamTemp;
            reportParamTemp = null;

            FrmReportViewer frmRelatorio = new FrmReportViewer();
            frmRelatorio.AbreRelatorio(nomeRelatorio, reportParam);
            return true;
        }

        private void tsFichaDesp_Click(object sender, EventArgs e)
        {
            tsHac_ImprimirClick(sender);
        }
        #endregion        
    }
}