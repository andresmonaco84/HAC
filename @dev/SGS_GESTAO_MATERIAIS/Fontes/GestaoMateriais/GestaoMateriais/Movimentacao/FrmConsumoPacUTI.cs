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
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Interface;
using HospitalAnaCosta.SGS.Seguranca.View;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmConsumoPacUTI : FrmBase
    {
        public FrmConsumoPacUTI()
        {
            InitializeComponent();
        }

        private bool _controlaConsumoPaciente = true;
        private decimal CONTA_FATURADA = (int)PacienteDTO.Faturada.NAO;
        private bool ESTOQUE_UNIFICADO_HAC = false;        
        private const int UTI_CARDIO = 200;
        private const int UTI_GERAL = 201;
        private const decimal UTI_TERREO = 2652;

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
        //private EstoqueLocalDTO dtoEstoque;
        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject(typeof(IEstoqueLocal)); }
        }

        //private MatMedSetorConfigDTO dtoSetorCfg;
        private IMatMedSetorConfig _matMedConfig;
        private IMatMedSetorConfig MatMedSetorConfig
        {
            get { return _matMedConfig != null ? _matMedConfig : _matMedConfig = (IMatMedSetorConfig)Global.Common.GetObject(typeof(IMatMedSetorConfig)); }
        }

        // Setor
        private ISetor _isetor;
        private ISetor Setor
        {
            get { return _isetor != null ? _isetor : _isetor = (ISetor)Global.Common.GetObject(typeof(ISetor)); }
        }        

        // UsuarioFuncionalidade
        private IUnidadeLocalSetorUsuario _unidadeLocalSetorUsuario;
        private IUnidadeLocalSetorUsuario UnidadeLocalSetorUsuario
        {
            get { return _unidadeLocalSetorUsuario != null ? _unidadeLocalSetorUsuario : _unidadeLocalSetorUsuario = (IUnidadeLocalSetorUsuario)CommonSeguranca.GetObject(typeof(IUnidadeLocalSetorUsuario)); }
        }

        private CommonSeguranca _commonSeguranca;
        protected CommonSeguranca CommonSeguranca
        {
            get { return _commonSeguranca != null ? _commonSeguranca : _commonSeguranca = new CommonSeguranca(null); }
        }

        private Generico gen = new Generico();

        #endregion        

        #region Métodos

        /// <summary>
        /// Verifica se setor pode usar tela de consumo para dar baixa em produtos
        /// </summary>
        private bool VerificaSetorPodeConsumir()
        {
            if (cmbSetor.SelectedValue.ToString() != UTI_CARDIO.ToString() &&
                cmbSetor.SelectedValue.ToString() != UTI_GERAL.ToString() &&
                cmbSetor.SelectedValue.ToString() != UTI_TERREO.ToString()) 
            {
                MessageBox.Show("Este Setor não pode consumir por esta tela", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cmbSetor.SelectedIndex = -1;
                return false;
            }
            return true;
        }

        private void ConfiguraMovimentoDTO()
        {
            // dtbMovimento.DefaultView.Sort = "colDataHist asc";
            dtoMovimento = new MovimentacaoDTO();
            dtoMovimento.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoMovimento.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoMovimento.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoMovimento.FlEstornado.Value = (int)MovimentacaoDTO.Estornado.NAO;

            RadioButton rbCe = new RadioButton();
            if (cbCE.Checked)
                rbCe.Checked = true;
            else if (ESTOQUE_UNIFICADO_HAC)
                dtoMovimento.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC;

            if (dtoMovimento.IdtFilial.Value.IsNull)
                dtoMovimento.IdtFilial.Value = gen.RetornaFilial(rbHac, rbAcs, rbCe);

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
            // dtgHistConsumo.Columns["colDataHist"].DefaultCellStyle.Format = "dd/MM/yyyy à\\s HH:mm:ss";
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
            dtgHistConsumo.Columns["colIdRequisicao"].DataPropertyName = MovimentacaoDTO.FieldNames.IdtRequisicao;
            dtgHistConsumo.Columns[colMAV.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia;
            dtgHistConsumo.Sort(dtgHistConsumo.Columns["colDataHist"], ListSortDirection.Descending);
            dtgHistConsumo.Columns[colLoteFab.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.NumLote;
            // colDsQtdeConvertida            
        }

        private void CarregarHistoricoConsumo()
        {
            this.Cursor = Cursors.WaitCursor;
            dtbHistMovimento.Rows.Clear();
            dtbMovimento.Rows.Clear();
            lblLegenda.Visible = false;
            ConfiguraMovimentoDTO();
            dtoMovimento.IdtFilial.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
            dtoMovimento.TpAtendimento.Value = (rbInternado.Checked ? "I" : "A");
            // NAO UTILIZA DATA FORNECIMENTO
            //dtbHistMovimento= Movimento.Sel(dtoMovimento, true);
            dtbHistMovimento = Movimento.HistoricoConsumoPaciente(dtoMovimento);
            dtgHistConsumo.DataSource = dtbHistMovimento;
            dtgHistConsumo.Columns["colDeletarHist"].Visible = txtCodProduto.Enabled;

            this.Cursor = Cursors.Default;
        }

        private void CarregaInfoPaciente()
        {
            PacienteDTO dtoAtendimentoHemodinamica = null;
            //int ignoraHorasAte = 0;
            dtoAtendimento = new PacienteDTO();
            dtoAtendimento.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoAtendimento.IdtLocalAtendimento.Value = cmbLocal.SelectedValue.ToString();
            dtoAtendimento.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            if (rbInternado.Checked)
                dtoAtendimento.TpAtendimento.Value = "I";
            else
                dtoAtendimento.TpAtendimento.Value = "A";
            if (txtNroInternacao.Text != string.Empty)
            {
                dtoAtendimento.Idt.Value = Convert.ToInt64(txtNroInternacao.Text);
            }
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
                this.Cursor = Cursors.WaitCursor;
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

                if (FilialMatMed.ObterFilialAtendimento(dtoFilial) == FilialMatMedDTO.Filial.HAC)
                    rbHac.Checked = true;
                else
                    rbAcs.Checked = true;

                txtNroInternacao.Enabled = false;
                cmbUnidade.Enabled = false;
                cmbLocal.Enabled = false;
                cmbSetor.Enabled = false;
                //if (!ESTOQUE_UNIFICADO_HAC) cbCE.Enabled = true;
                cbCE.Enabled = true;
                dtbMovimento.Clear();

                txtCodProduto.Enabled = false;
                if (dtoAtendimentoHemodinamica == null || !dtoAtendimentoHemodinamica.NmPaciente.Value.IsNull)
                    txtCodProduto.Enabled = txtLocal.Text.Trim() == "SRRP" ? false : !gen.VerificaAcessoFuncionalidade("SoLeituraConsumo"); //Desabilitar para pré-cadastro
                //txtCodProduto.Enabled = !gen.VerificaAcessoFuncionalidade("SoLeituraConsumo");
                if (txtLocal.Text.Trim() == "SRRP")
                {
                    MessageBox.Show(" Paciente em Pré-Cadastro, não sendo possível baixar produto(s) ", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Cursor = Cursors.Default;
                }

                //Se for Centro de Disp., barra consumo (por causa dos regionais que podem ter acesso ao paciente)
                if (txtCodProduto.Enabled)
                {
                    SetorDTO dtoSetor = new SetorDTO();
                    dtoSetor.Idt.Value = cmbSetor.SelectedValue.ToString();
                    dtoSetor = Setor.SelChave(dtoSetor);
                    if (dtoSetor.FlAlmoxCentral.Value == (byte)SetorDTO.AlmoxarifadoCentral.SIM ||
                        dtoSetor.SubstituiAlmoxarifado.Value == "S")
                    {
                        txtCodProduto.Enabled = false;
                    }
                }

                _controlaConsumoPaciente = true;
                if (cmbSetor.SelectedValue.ToString() == UTI_TERREO.ToString())
                {
                    MatMedSetorConfigDTO dtoSetorCfg = new MatMedSetorConfigDTO();
                    dtoSetorCfg.Idtsetor.Value = cmbSetor.SelectedValue.ToString();
                    _controlaConsumoPaciente = Atendimento.ControlaConsumoPacienteSetor(decimal.Parse(txtNroInternacao.Text), dtoSetorCfg);                    
                }

                this.Cursor = Cursors.Default;

                CarregarKitsPedidos();

                if (txtCodProduto.Enabled) txtCodProduto.Focus();                
            }
        }

        private void CarregarKitsPedidos()
        {
            this.Cursor = Cursors.WaitCursor;
            RequisicaoDTO dtoReqKit = new RequisicaoDTO();
            dtoReqKit.IdtAtendimento.Value = dtoAtendimento.Idt.Value;
            dtoReqKit.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtgKit.AutoGenerateColumns = false;
            dtgKit.DataSource = Requisicao.ListarPacienteKits(dtoReqKit);
            dtgKit.ClearSelection();
            this.Cursor = Cursors.Default;
        }

        private bool ItemPendentePedido(out decimal? idRequisicao)
        {
            idRequisicao = null;
            if (!cbCE.Checked && dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.NAO)
            {
                int qtdConsumoInt = 0;
                MovimentacaoDTO dtoMov = new MovimentacaoDTO();
                dtoMov.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                dtoMov.IdtAtendimento.Value = txtNroInternacao.Text;
                dtoMov.IdtProduto.Value = dtoMatMed.Idt.Value;
                int qtdSolicitada = RequisicaoItens.ObterQtdSolicitadaProdutoPaciente(dtoMov, (int)dtoMatMed.IdtPrincipioAtivo.Value);
                if (qtdSolicitada == 0)
                {
                    MessageBox.Show("Material/medicamento não existente em nenhum pedido para este paciente, favor solicitar um pedido personalizado. ", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                DataTable dtbMov = Movimento.ObterQtdProdutoBaixaPacSetor(dtoMov, (int)dtoMatMed.IdtPrincipioAtivo.Value);
                //Pode retornar até 2 linhas, caso produto com movimento fracionado
                if (dtbMov.Rows.Count > 0)
                {                    
                    if (dtbMov.Rows[0]["MOV_TIPO"].ToString() == "I") qtdConsumoInt = int.Parse(dtbMov.Rows[0]["QTD_CONSUMO"].ToString());                
                    if (dtbMov.Rows.Count > 1)
                        if (dtbMov.Rows[1]["MOV_TIPO"].ToString() == "I") qtdConsumoInt = int.Parse(dtbMov.Rows[1]["QTD_CONSUMO"].ToString());
                }

                if (qtdConsumoInt >= qtdSolicitada)
                {
                    MessageBox.Show("Material/medicamento já baixado para este paciente, favor solicitar novo pedido personalizado. ", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                //if (dtoMatMed.IdtSubGrupo.Value.ToString() == "981") //Antimicrobianos Restritos
                decimal? idRequisicaoPrescricao = RequisicaoItens.ObterNumPedidoPrescricaoPaciente(dtoMov, (int)dtoMatMed.IdtPrincipioAtivo.Value);
                if (idRequisicaoPrescricao != null)
                    idRequisicao = idRequisicaoPrescricao;
                else
                    idRequisicao = RequisicaoItens.ObterNumPedidoPendentePaciente(dtoMov, (int)dtoMatMed.IdtPrincipioAtivo.Value);                
            }
            return true;
        }

        private void BaixarProduto()
        {
            this.Cursor = Cursors.WaitCursor;            
            if (gen.ValidarContaFaturadaComNF((decimal)dtoAtendimento.Idt.Value, decimal.Parse(cmbSetor.SelectedValue.ToString())))
            {
                try
                {
                    dtgHistConsumo.Columns["colDeletarHist"].Visible = false;

                    // limpa histórico quando adicionar itens
                    dtbHistMovimento.Rows.Clear();

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
                            this.Cursor = Cursors.Default;
                            return;
                        }
                        if (dtoMatMed.FlAtivo.Value == 0)
                        {
                            MessageBox.Show("Produto Inativo", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtCodProduto.Text = string.Empty;
                            txtCodProduto.Focus();
                            this.Cursor = Cursors.Default;
                            return;
                        }                        
                    }
                    if (_controlaConsumoPaciente)
                    {
                        decimal? idRequisicao;
                        if (!ItemPendentePedido(out idRequisicao))
                        {
                            txtCodProduto.Text = string.Empty;
                            txtCodProduto.Focus();
                            this.Cursor = Cursors.Default;
                            return;
                        }
                        if (idRequisicao != null)
                            dtoMovimento.IdtRequisicao.Value = idRequisicao.Value;
                    }

                    dtoMovimento.IdtSubTipo.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
                    dtoMovimento.FlFracionado.Value = dtoMatMed.FlFracionado.Value;

                    #region "Se for fracionado/reutilizavel, digitar qtd."
                    if (dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM ||
                        dtoMatMed.FlReutilizavel.Value == (decimal)MaterialMedicamentoDTO.Reutilizavel.SIM)
                    {
                        dtoMovimento = DigitarQtde();
                        if (decimal.Parse(dtoMovimento.Qtde.Value.ToString()) == 0)
                        {
                            txtCodProduto.Text = string.Empty;
                            txtCodProduto.Focus();
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }
                    #endregion

                    dtoMovimento.TipoEmpresa.Value = rbHac.Checked ? (byte)MovimentacaoDTO.Empresa.HAC : (byte)MovimentacaoDTO.Empresa.ACS;
                    dtoMovimento.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    dtoMovimento.DtFaturamento.Value = txtDtTranf.Text;
                    dtoMovimento.HrFaturamento.Value = txtHrTransf.Text;
                    dtoMovimento.TpAtendimento.Value = (rbInternado.Checked ? "I" : "A");
                    if (!dtoMatMed.IdtLote.Value.IsNull && (decimal)dtoMatMed.IdtLote.Value != 0) dtoMovimento.IdtLote.Value = dtoMatMed.IdtLote.Value;
                    // ############## GERA O MOVIMENTO #############################################################
                    dtoMovimento = Movimento.MovimentaEstoqueProduto(dtoMovimento, dtoMatMed, null);
                    // #############################################################################################
                    // dtgConsumo.DataSource = this.AtualizaGrid();

                    // RETIRADO PARA MELHORAR VELOCIDADE DO SISTEMA 10/03/2010
                    // CarregarHistoricoConsumo();

                    // insere linha  do produto consumido na grid
                    dtbMovimento.Add(dtoMovimento);
                    if (dtbMovimento.Columns.IndexOf(MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia) == -1)
                        dtbMovimento.Columns.Add(MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia);
                    dtbMovimento.Rows[dtbMovimento.Rows.Count - 1][MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia] = dtoMatMed.MedAltaVigilancia.Value;
                    dtgHistConsumo.DataSource = dtbMovimento;

                    if (dtoMatMed.FlReutilizavel.Value.IsNull) dtoMatMed.FlReutilizavel.Value = (byte)MaterialMedicamentoDTO.Fracionado.NAO;

                    if (dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.NAO &&
                        dtoMatMed.FlReutilizavel.Value == (decimal)MaterialMedicamentoDTO.Reutilizavel.NAO)
                    {
                        #region Atualiza Requisição do carrinho de emergência
                        //Se não for fracionado, baixará do estoque, e terá que ser gerado um pedido, caso seja consumo de carrinho de emergência
                        //if (cbCE.Checked && !ESTOQUE_UNIFICADO_HAC)
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
                        }
                    }
                        #endregion
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }

                txtCodProduto.Text = string.Empty;
                txtCodProduto.Focus();
                dtbMovimento.AcceptChanges();
                tsHac.Items["tsBtnNovo"].Enabled = true;
                dtgHistConsumo.Sort(dtgHistConsumo.Columns["colDataHist"], ListSortDirection.Descending);
                dtgHistConsumo.ClearSelection();
                if (dtgHistConsumo.Rows.Count > 0) dtgHistConsumo.Rows[0].Selected = true;
            }
            else
            {
                dtoMatMed = null;
                //MessageBox.Show("A conta deste paciente foi fechada e nenhum produto pode ser consumido", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show("A conta deste paciente já foi faturada e mais nenhum produto pode ser registrado na mesma", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodProduto.Focus();
            }
            this.Cursor = Cursors.Default;
        }

        private void SalvarPedidoCE()
        {
            try
            {
                if (dtbRequisicaoItemCE.Rows.Count > 0)
                {
                    ConfiguraRequisicaoCEDTO();
                    dtoRequisicaoCE.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                    int? idSetorFarmacia = gen.ObterFarmaciaSetor((int)dtoRequisicaoCE.IdtSetor.Value);
                    if (idSetorFarmacia != null)
                        dtoRequisicaoCE.SetorFarmacia.Value = idSetorFarmacia;

                    Requisicao.Gravar(dtoRequisicaoCE, dtbRequisicaoItemCE);
                }
                else
                {
                    MessageBox.Show("Não foi consumido nenhum produto para a geração de pedido do carrinho de emergência", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                dtoRequisicaoCE = null;
                dtbRequisicaoItemCE = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Verifica se pode consumir pelas regras do faturamento
        /// </summary>
        private bool PermitirConsumo()
        {
            return true;
            // veirifco novamente
            //MovimentacaoDTO dto = new MovimentacaoDTO();
            //dto.IdtAtendimento.Value = dtoAtendimento.Idt.Value;
            //dto.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            //dto.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            //dto.IdtSetor.Value = cmbSetor.SelectedValue.ToString();

            //MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();
            //// cfg
            //dtoCfg.IdtUnidade.Value = dto.IdtUnidade.Value;
            //dtoCfg.IdtLocal.Value = dto.IdtLocal.Value;
            //dtoCfg.Idtsetor.Value = dto.IdtSetor.Value;
            //dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);
            //if (dtoCfg.AtendeTodosSetores.Value == 1)
            //{
            //    if (dto.IdtLocal.Value == (int)PacienteDTO.LocalAtendimento.CENTRO_CIRURGICO)
            //        dto.IdtLocal.Value = (int)PacienteDTO.LocalAtendimento.INTERNADO;
            //    dto.IdtSetor.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
            //}

            //try
            //{
            //    if (!Movimento.PermiteConsumo(dto))
            //    {
            //        CONTA_FATURADA = (int)PacienteDTO.Faturada.SIM;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            //if (CONTA_FATURADA == (int)PacienteDTO.Faturada.SIM)
            //{
            //    MessageBox.Show("CONTA FATURADA", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}
            //return true;
        }

        private void ConfiguraTipoAtendimento()
        {
            MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();

            dtoCfg.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoCfg.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoCfg.Idtsetor.Value = cmbSetor.SelectedValue.ToString();

            dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);

            //if ( gen.ConsultaPacienteTodosOsSetores(dto) )
            if (dtoCfg.AtendeTodosSetores.Value == 1)
            {
                if (cmbSetor.SelectedValue.ToString() != "61") //C. Cir.
                {
                    grpTipoAtendimento.Enabled = true;
                    rbAmbulatorio.Enabled = true;
                    rbInternado.Enabled = true;
                }

                rbAmbulatorio.Checked = false;
                rbInternado.Checked = true;

            }
            else if (cmbLocal.Text == "AMBULATORIO")
            {
                rbAmbulatorio.Enabled = false;
                rbInternado.Enabled = false;

                grpTipoAtendimento.Enabled = false;
                rbAmbulatorio.Checked = true;
            }
            else
            {
                rbAmbulatorio.Enabled = false;
                rbInternado.Enabled = false;

                grpTipoAtendimento.Enabled = false;
                rbInternado.Checked = true;
            }

            if (dtoCfg.EstoqueUnificadoHAC.Value.IsNull) dtoCfg.EstoqueUnificadoHAC.Value = 0;
            if (dtoCfg.EstoqueUnificadoHAC.Value == 1)
            {
                ESTOQUE_UNIFICADO_HAC = lblEU.Visible = true;
                //cbCE.Text = "ESTOQUE UNIFICADO";
                //cbCE.Enabled = false;
                //cbCE.Checked = true;
            }
            else
            {
                ESTOQUE_UNIFICADO_HAC = lblEU.Visible = false;
                cbCE.Text = "CARRINHO DE EMERGÊNCIA";
                //cbCE.Enabled = true;
            }
        }

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

        private bool ZerarObjetos(bool finalizarPedidoCarrEmergSemMsg)
        {
            if (dtbRequisicaoItemCE != null)
            {
                if (dtbRequisicaoItemCE.Rows.Count > 0)
                {
                    if (finalizarPedidoCarrEmergSemMsg)
                    {
                        SalvarPedidoCE();
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
            dtgHistConsumo.Columns["colDeletarHist"].Visible = false;
            lblLegenda.Visible = false;
            dtoMatMed = null;
            dtoAtendimento = null;
            _controlaConsumoPaciente = true;
            dtbMovimento = new MovimentacaoDataTable();
            dtbHistMovimento = new MovimentacaoDataTable();
            // dtgConsumo.DataSource = null;
            dtgHistConsumo.DataSource = null;
            dtoRequisicaoCE = null;
            dtbRequisicaoItemCE = null;
            cbCE.Checked = false;
            btnFinalizarCE.Visible = false;

            txtDtTranf.Text = string.Empty;
            txtHrTransf.Text = string.Empty;
            CONTA_FATURADA = (int)PacienteDTO.Faturada.NAO;

            tsHac.Items["tsBtnPrint"].Enabled = false;

            return true;
        }

        #endregion

        #region Eventos

        private void FrmConsumoPaciente_Load(object sender, EventArgs e)
        {
            grpTipoAtendimento.Enabled = false;
            cmbUnidade.Enabled = cmbLocal.Enabled = false;
            cmbUnidade.Editavel = cmbLocal.Editavel = ControleEdicao.Nunca;
            cmbUnidade.Carregaunidade();
            cmbUnidade.SelectedValue = 244; //SANTOS
            cmbLocal.SelectedValue = 29; //INTERNADO
            //Mostrar apenas UTIs Geral e Cardio e p/ quem tiver acesso as mesmas
            DataTable dtbSetor = (DataTable)cmbSetor.DataSource;
            UnidadeLocalSetorUsuarioDTO dtoULS = new Seguranca.DTO.UnidadeLocalSetorUsuarioDTO();
            dtoULS.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
            foreach (DataRow row in dtbSetor.Rows)
            {
                if (row[SetorDTO.FieldNames.Idt].ToString() == UTI_GERAL.ToString() ||
                    row[SetorDTO.FieldNames.Idt].ToString() == UTI_CARDIO.ToString() ||
                    row[SetorDTO.FieldNames.Idt].ToString() == UTI_TERREO.ToString())
                {
                    dtoULS.IdtSetor.Value = row[SetorDTO.FieldNames.Idt].ToString();
                    DataTable dtbULS = UnidadeLocalSetorUsuario.ObterAcessoUsuarioSetor(dtoULS);
                    if (dtbULS.Rows.Count == 0) row.Delete();
                }                
                else
                    row.Delete();
            }
            dtbSetor.AcceptChanges();
            cmbSetor.DataSource = dtbSetor;
            cmbSetor.IniciaLista();
            ConfiguraDTG();
            dtgHistConsumo.Columns["colDeletarHist"].Visible = false;

            #if DEBUG
                txtDtTranf.Visible = true;
                txtHrTransf.Visible = true;
            #else                
                tsHac.Items["tsBtnMatMed"].Visible = false;
                txtDtTranf.Visible = false;
                txtHrTransf.Visible = false;                
            #endif
        }

        private void btnPesquisaPac_Click(object sender, EventArgs e)
        {
            if (txtNroInternacao.Enabled)
            {
                // this.PesquisarPaciente();
                CarregaInfoPaciente();
                tsHac.Items["tsBtnNovo"].Enabled = true;
            }
        }

        private void txtNroInternacao_Validated(object sender, EventArgs e)
        {
            if (txtNroInternacao.Text.Length != 0)
            {
                btnPesquisaPac_Click(sender, e);
                tsHac.Items["tsBtnNovo"].Enabled = true;
            }
        }

        private void txtCodProduto_Validating(object sender, CancelEventArgs e)
        {
            if (txtCodProduto.Text != string.Empty)
            {
                dtoMatMed = null;
                if (int.Parse(cmbSetor.SelectedValue.ToString()) == 2252) //ATENDIMENTO DOMICILIAR
                {
                    MessageBox.Show("Não é permitido consumir para ATENDIMENTO DOMICILIAR por esta tela", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                this.BaixarProduto();
                tsHac.Items["tsBtnNovo"].Enabled = true;
            }
        }

        private bool tsHac_MatMedClick(object sender)
        {
            if (txtNomePac.Text == string.Empty)
            {
                MessageBox.Show("Nenhum atendimento foi carregado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            //if (!PermitirConsumo()) return false;
            if (!rbAcs.Checked && !rbHac.Checked)
            {
                MessageBox.Show("Pesquise o paciente", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroInternacao.Focus();
                return false;
            }
            dtoMatMed = new MaterialMedicamentoDTO();
            dtoMatMed.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoMatMed.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoMatMed.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoMatMed.IdtFilial.Value = gen.RetornaFilial(rbHac, rbAcs); // rbHac.Checked ? (byte)FilialMatMedDTO.Filial.HAC : (byte)FilialMatMedDTO.Filial.ACS;
            dtoMatMed.FlAtivo.Value = 1; //ativo

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
                        this.BaixarProduto();
                }
            }            
            return true;
        }

        private bool tsHac_SairClick(object sender)
        {
            return ZerarObjetos(false);
        }

        private bool tsHac_NovoClick(object sender)
        {
            return ZerarObjetos(false);
        }

        private bool tsHac_AfterNovo(object sender)
        {
            if (ESTOQUE_UNIFICADO_HAC)
            {
                //cbCE.Checked = true;
                //cbCE.Enabled = false;
                lblEU.Visible = true;
            }
            else
                lblEU.Visible = false;
            return true;
        }

        private void tsHac_AfterCancelar(object sender)
        {
            tsHac_AfterNovo(null);
        }

        private bool tsHac_CancelarClick(object sender)
        {
            return ZerarObjetos(false);
        }

        private void cmbUnidade_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ZerarObjetos(false)) tsHac.Controla(Evento.eCancelar);
        }

        private void cmbLocal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ZerarObjetos(false)) tsHac.Controla(Evento.eCancelar);
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ZerarObjetos(false)) tsHac.Controla(Evento.eCancelar);
            if (VerificaSetorPodeConsumir()) ConfiguraTipoAtendimento();
        }

        private void tabConsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodProduto.Focus();
            tsHac.Items["tsBtnNovo"].Enabled = true;
        }

        private int _idRequisicaoKit, _idKit;
        private void dtgHistConsumo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgHistConsumo.Columns[e.ColumnIndex].Name == "colDsProdutoHist")
            {
                try
                {
                    if (dtgHistConsumo.Rows[e.RowIndex].Cells["colIdFilial"].Value.ToString() != string.Empty ||
                        dtgHistConsumo.Rows[e.RowIndex].Cells["colIdFilial"].Value != null)
                    {
                        if (byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colIdFilial"].Value.ToString()) == (byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA)
                        {
                            //e.Value = string.Format("CARRO EMERG. -> {0}", e.Value.ToString());
                            e.Value = string.Format("{0} (CARRO EMERG.)", e.Value.ToString());
                        }
                    }
                    int idRequisicao = string.IsNullOrEmpty(dtgHistConsumo.Rows[e.RowIndex].Cells["colIdRequisicao"].Value.ToString()) ? 0 : int.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colIdRequisicao"].Value.ToString());
                    if (idRequisicao > 0)
                    {
                        if (_idRequisicaoKit != idRequisicao)
                        {
                            RequisicaoDTO dtoReq = new RequisicaoDTO();
                            dtoReq.Idt.Value = idRequisicao;
                            dtoReq = Requisicao.SelChave(dtoReq);
                            _idKit = 0;
                            if (!dtoReq.IdKit.Value.IsNull)
                            {
                                _idKit = (int)dtoReq.IdKit.Value;
                                _idRequisicaoKit = idRequisicao;
                            }                            
                        }
                        if (_idKit > 0)
                            e.Value = string.Format("{0} ({1})", e.Value.ToString(), "KIT " + _idKit.ToString());
                    }
                    else
                    {
                        _idRequisicaoKit = _idKit = 0;
                    }
                }
                catch (Exception ex) { }
            }
            //if (!this.PermitirExclusao(decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colIdtMovimentoHist"].Value.ToString())))
            //{
            //    lblLegenda.Visible = true;
            //    e.CellStyle.BackColor = Color.Yellow;
            //}            
        }

        private void dtgHistConsumo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1 && dtgHistConsumo.Columns[e.ColumnIndex].Name == "colDeletarHist")
            {
                if (int.Parse(cmbSetor.SelectedValue.ToString()) == 2252) //ATENDIMENTO DOMICILIAR
                {
                    MessageBox.Show("Não é permitido estornar para ATENDIMENTO DOMICILIAR por esta tela", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                dtoPedidoPadrao = new PedidoPadraoDTO();

                dtoPedidoPadrao.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                dtoPedidoPadrao.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                dtoPedidoPadrao.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                dtoPedidoPadrao.Status.Value = (byte)PedidoPadraoDTO.StatusPedidoPadrao.CONFIRMADO;
                dtoPedidoPadrao.IdtFilial.Value = gen.RetornaFilial(rbHac, rbAcs);

                dtoMatMed = new MaterialMedicamentoDTO();
                dtoMatMed.Idt.Value = dtgHistConsumo.Rows[e.RowIndex].Cells["colIdtProdutoHist"].Value.ToString();
                dtoMatMed = MatMed.SelChave(dtoMatMed);

                ConfiguraMovimentoDTO();
                dtoMovimento.Idt.Value = decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colIdtMovimentoHist"].Value.ToString());
                
                PedidoPadraoItensDTO dtoPedPadItem = new PedidoPadraoItensDTO();

                //#region VERIFICA SE PODE EXCLUIR - COMPARA ESTOQUE PADRAO AO ESTOQUE ATUAL
                //// verifica se existe a informação
                //if (dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString() != string.Empty)
                //{
                //    if (byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString()) != (byte)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA &&
                //        byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString()) != (byte)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA_CARRINHO_EMERGENCIA &&
                //        byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString()) != (byte)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_REUTILIZAVEL
                //       )
                //    {
                //        if (PedidoPadrao.ProdutoPadrao(dtoPedidoPadrao, dtoMatMed, ref dtoPedPadItem, true))
                //        {
                //            decimal qtdNova = decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colQtdHist"].Value.ToString()) + dtoPedPadItem.EstoqueLocalQtde.Value.DBValue.Value;

                //            if (qtdNova > dtoPedPadItem.Qtde.Value)
                //            {
                //                MessageBox.Show("Não pode ser realizado o estorno deste produto neste momento, pois ele pertence ao estoque fixo que já está no Limite", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //                this.Cursor = Cursors.Default;
                //                return;
                //            }
                //        }
                //    }
                //}
                //#endregion
                
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
                            if (dtbHistMovimento.Rows.Count > 0 && dtbMovimento.Rows.Count > 0)
                            {
                                MessageBox.Show("As duas fontes de informções estão preenchidas, isso não deveria acontecer");
                                return;
                            }
                            // verifica de onde veio a solicitação de exclusão - se foi adicionando produto ou histórico
                            if (dtbHistMovimento.Rows.Count > 0)
                            {

                                dtbHistMovimento.Select(string.Format("{0} = {1}",
                                                         MovimentacaoDTO.FieldNames.Idt,
                                                         dtoMovimento.Idt.Value))[0].Delete();                             
                                dtbHistMovimento.AcceptChanges();
                            }
                            CarregarKitsPedidos();
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

        private void dtgKit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                RequisicaoDTO dtoReqKit = new RequisicaoDTO();
                dtoReqKit.Idt.Value = Convert.ToInt64(dtgKit.Rows[e.RowIndex].Cells[colIdPedido.Name].Value.ToString());
                dtoReqKit.IdKit.Value = Convert.ToInt64(dtgKit.Rows[e.RowIndex].Cells[colIdKit.Name].Value.ToString());
                ConfiguraMovimentoDTO();
                this.Cursor = Cursors.WaitCursor;
                new FrmBaixaPedidoKit().CarregarKitBaixa(dtoReqKit, dtgKit.Rows[e.RowIndex].Cells[colDscKit.Name].Value.ToString(), dtoMovimento);
                CarregarKitsPedidos();
                this.Cursor = Cursors.Default;
            }
        }        

        private void cbCE_Click(object sender, EventArgs e)
        {
            if (cbCE.Checked)
            {
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

        private void btnFinalizarCE_Click(object sender, EventArgs e)
        {
            SalvarPedidoCE();
            cbCE.Checked = false;
            cbCE.Enabled = true;
            btnFinalizarCE.Visible = false;
            txtCodProduto.Focus();
        }

        private void FrmConsumoPaciente_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !ZerarObjetos(true);
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            dtbMovimento.Rows.Clear();
            if (dtoAtendimento != null) CarregarHistoricoConsumo();
            if (txtNroInternacao.Text == string.Empty)
            {
                txtNroInternacao.Focus();
            }
            else
            {
                txtCodProduto.Focus();
            }
        }

        #endregion        
    }
}