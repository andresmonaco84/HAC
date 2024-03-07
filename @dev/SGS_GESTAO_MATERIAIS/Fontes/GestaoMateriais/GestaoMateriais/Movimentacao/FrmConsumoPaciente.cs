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
    public partial class FrmConsumoPaciente : FrmBase
    {
        public FrmConsumoPaciente()
        {
            InitializeComponent();
        }

        private decimal CONTA_FATURADA = (int)PacienteDTO.Faturada.NAO;
        private bool ESTOQUE_UNIFICADO_HAC = false;
        private int? CARRINHO_EMERG_SETOR_PAI = null;
        private int? SETOR_SELECIONADO = null;
        private const int HEMODINAMICA = 113;
        private const int TEMPO_IMPRESSAO_BCC = 360; //15 dias
        private const decimal ANTIMICROBIANOS_RESTRITOS = 981;

        #region Objetos Serviço

        // private CommonCadastro _commonCadastro;
        // private CommonCadastro CommonCadastro
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
        private EstoqueLocalDTO dtoEstoque;
        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject(typeof(IEstoqueLocal)); }
        }

        private MatMedSetorConfigDTO dtoSetorCfg;
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

        private Generico gen = new Generico();

        #endregion

        private bool VerificaSetorPodeAcessar()
        {
            if (int.Parse(cmbSetor.SelectedValue.ToString()) == 61 ||
                int.Parse(cmbSetor.SelectedValue.ToString()) == 2252) //Centr. Cir. / ATENDIMENTO DOMICILIAR
            {
                MessageBox.Show("Este Setor não pode consumir por esta tela", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cmbSetor.SelectedIndex = -1;
                return false;
            }
            CARRINHO_EMERG_SETOR_PAI = new Generico().SetorCarrinhoEmergencia(int.Parse(cmbSetor.SelectedValue.ToString()));
            if (CARRINHO_EMERG_SETOR_PAI != null)
            {
                FixarCE();
                cbCE_Click(null, null);
                //MessageBox.Show("Este setor é um Carrinho de Emergência, após as baixas favor clicar em 'Finalizar Consumo' para gerar o Pedido de reabastecimento.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
            }
            return true;
        }

        private void FixarCE()
        {
            if (CARRINHO_EMERG_SETOR_PAI == null)
            {
                cbCE.Checked = false;
                btnFinalizarCE.Visible = false;
            }
            else
            {
                dtbRequisicaoItemCE = new RequisicaoItensDataTable();
                cbCE.Checked = true;
                btnFinalizarCE.Visible = true;
            }
        }

        private bool VerificaSetorPodeConsumir(bool blnCarroEmerg)
        {            
            if (!blnCarroEmerg &&
                gen.UtiCompartilhada(int.Parse(cmbSetor.SelectedValue.ToString())) &&
                dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.NAO)
            {
                MessageBox.Show("Permitido movimentação apenas de fracionados deste setor por esta tela", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Cursor = Cursors.Default;
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
            else if (cbConsignado.Checked)
                dtoMovimento.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.CONSIGNADO;
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
            dtgHistConsumo.Sort(dtgHistConsumo.Columns["colDataHist"], ListSortDirection.Descending);
            dtgHistConsumo.Columns[colMAV.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia;
            dtgHistConsumo.Columns[colLoteFab.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.NumLote;
            dtgHistConsumo.Columns[colPedido.Name].DataPropertyName = MovimentacaoDTO.FieldNames.IdtRequisicao;
            // colDsQtdeConvertida            
        }

        private void ConfiguraItensPendentesDTG()
        {
            dtgItensPendentes.AutoGenerateColumns = false;            
            dtgItensPendentes.Columns[colMatMedIdtPend.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.IdtProduto;
            dtgItensPendentes.Columns[colDsMatMedPend.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.DsProduto;
            dtgItensPendentes.Columns[colQtdForn.Name].DataPropertyName = "QTD_FORNECIDA";
            dtgItensPendentes.Columns[colQtdForn.Name].DefaultCellStyle.Format = "N0";
            dtgItensPendentes.Columns[colQtdCons.Name].DataPropertyName = "QTD_CONSUMO";
            dtgItensPendentes.Columns[colQtdCons.Name].DefaultCellStyle.Format = "N0";
            dtgItensPendentes.Columns[colQtdPendente.Name].DataPropertyName = "QTD_PENDENTE";
            dtgItensPendentes.Columns[colQtdPendente.Name].DefaultCellStyle.Format = "N0";
            dtgItensPendentes.Columns[colSetor.Name].DataPropertyName = SetorDTO.FieldNames.Descricao;
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

            if (cbApenasFaturar.Visible && cbApenasFaturar.Checked)
                dtbHistMovimento = Movimento.HistoricoEnvioFaturamentoPaciente(dtoMovimento);
            else
                dtbHistMovimento = Movimento.HistoricoConsumoPaciente(dtoMovimento);

            dtgHistConsumo.DataSource = dtbHistMovimento;
            dtgHistConsumo.Columns["colDeletarHist"].Visible = txtCodProduto.Enabled;
            this.Cursor = Cursors.Default;
        }

        private void CarregaInfoPaciente()
        {
            PacienteDTO dtoAtendimentoHemodinamica = null;
            int ignoraHorasAte = 0;
            dtoAtendimento = new PacienteDTO();
            dtoAtendimento.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoAtendimento.IdtLocalAtendimento.Value = cmbLocal.SelectedValue.ToString();
            if (CARRINHO_EMERG_SETOR_PAI == null)
                dtoAtendimento.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            else
                dtoAtendimento.IdtSetor.Value = CARRINHO_EMERG_SETOR_PAI.Value;
            if (rbInternado.Checked)
                dtoAtendimento.TpAtendimento.Value = "I";
            else
                dtoAtendimento.TpAtendimento.Value = "A";
            if (txtNroInternacao.Text != string.Empty)
            {
                dtoAtendimento.Idt.Value = Convert.ToInt64(txtNroInternacao.Text);

                if (cmbSetor.SelectedValue.ToString() == HEMODINAMICA.ToString())
                    ignoraHorasAte = LiberarPesquisaHemodinamica(TEMPO_IMPRESSAO_BCC);
            }
            try
            {
                dtoAtendimento = gen.ObterPaciente(dtoAtendimento);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                if (txtNroInternacao.Text != string.Empty && cmbSetor.SelectedValue.ToString() == HEMODINAMICA.ToString())
                {
                    //if (ignoraHorasAte != 0 && ignoraHorasAte != TEMPO_IMPRESSAO_BCC)
                    if (ignoraHorasAte != TEMPO_IMPRESSAO_BCC)
                    {
                        LiberarPesquisaHemodinamica(ignoraHorasAte);

                        dtoAtendimentoHemodinamica = new PacienteDTO();
                        dtoAtendimentoHemodinamica.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                        dtoAtendimentoHemodinamica.IdtLocalAtendimento.Value = cmbLocal.SelectedValue.ToString();
                        dtoAtendimentoHemodinamica.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                        if (rbInternado.Checked)
                            dtoAtendimentoHemodinamica.TpAtendimento.Value = "I";
                        else
                            dtoAtendimentoHemodinamica.TpAtendimento.Value = "A";
                        dtoAtendimentoHemodinamica.Idt.Value = Convert.ToInt64(txtNroInternacao.Text);
                        dtoAtendimentoHemodinamica = Atendimento.SelChave(dtoAtendimentoHemodinamica);
                        if (dtoAtendimentoHemodinamica == null)
                        {
                            dtoAtendimentoHemodinamica = new PacienteDTO();
                            if (!dtoAtendimento.NmPaciente.Value.IsNull)
                                MessageBox.Show("Limite de tempo para consumo expirado deste paciente", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }

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
                    MessageBox.Show(" Paciente em Pré-Cadastro, não sendo possível baixar produto(s) ", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //Se for Centro de Disp., barra consumo (por causa dos regionais que podem ter acesso ao paciente)
                if (txtCodProduto.Enabled && 
                    ((cmbLocal.SelectedValue.ToString() == "27" && cmbSetor.Text.Trim().ToUpper().IndexOf("ALMOX") > -1) || cmbLocal.SelectedValue.ToString() != "27")) //Sempre liberar para AMB.
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

                if (txtCodProduto.Enabled) txtCodProduto.Focus();
                if (cmbSetor.SelectedValue.ToString() == HEMODINAMICA.ToString())
                {
                    tsHac.Items["tsBtnPrint"].Visible = true;
                    tsHac.Items["tsBtnPrint"].Enabled = true;
                }
                //if (cmbLocal.SelectedValue.ToString() == "29") //Para internado validar se item foi solicitado para o paciente
                dtoSetorCfg = new MatMedSetorConfigDTO();
                dtoSetorCfg.Idtsetor.Value = cmbSetor.SelectedValue.ToString();
                if (Atendimento.ControlaConsumoPacienteSetor(decimal.Parse(txtNroInternacao.Text), dtoSetorCfg))
                    btnPendentes.Visible = true;
            }
        }

        /// <summary>
        /// LiberarPesquisaHemodinamica
        /// </summary>
        /// <param name="valorGravar"></param>
        /// <returns>Retorna valor que tem que ser mantido depois do processo de busca, referente ao campo 'IgnoraAltaHorasAte'</returns>
        private int LiberarPesquisaHemodinamica(int valorGravar)
        {
            int retorno = 0;
            dtoSetorCfg = new MatMedSetorConfigDTO();
            dtoSetorCfg.Idtsetor.Value = cmbSetor.SelectedValue.ToString();
            dtoSetorCfg = MatMedSetorConfig.SetorCfg(dtoSetorCfg);
            if (!dtoSetorCfg.IgnoraAltaHorasAte.Value.IsNull)
            {
                retorno = (int)dtoSetorCfg.IgnoraAltaHorasAte.Value;
                dtoSetorCfg.IgnoraAltaHorasAte.Value = valorGravar != 0 ? valorGravar : new Framework.DTO.TypeDecimal();
                MatMedSetorConfig.SetorCfgSalvar(dtoSetorCfg);
            }            

            return retorno;
        }

        private bool AntimicrobianoPendentePedido()
        {
            if (!cbCE.Checked && dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.NAO)
            {
                int qtdConsumoInt = 0;
                MovimentacaoDTO dtoMov = new MovimentacaoDTO();
                //dtoMov.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                dtoMov.IdtAtendimento.Value = txtNroInternacao.Text;
                dtoMov.IdtProduto.Value = dtoMatMed.Idt.Value;
                int qtdSolicitada = RequisicaoItens.ObterQtdSolicitadaProdutoPaciente(dtoMov, (int)dtoMatMed.IdtPrincipioAtivo.Value);
                if (qtdSolicitada == 0)
                {
                    MessageBox.Show("Antimicrobiano não existente em nenhum pedido para este paciente, favor realizar um pedido personalizado ou solicitar uma prescrição.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    MessageBox.Show("Antimicrobiano já baixado para este paciente, favor realizar um novo pedido personalizado ou solicitar nova prescrição.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }                
            }
            return true;
        }

        private bool ItemPendentePedido()
        {
            if (!cbCE.Checked && dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.NAO)
            {
                int qtdPendente = 0;
                RequisicaoItensDataTable dtbPendenciaConsumo = RequisicaoItens.SelReqItensPendentesConsumoPac(int.Parse(txtNroInternacao.Text), (int)dtoMatMed.Idt.Value, int.Parse(cmbSetor.SelectedValue.ToString()));

                if (dtbPendenciaConsumo.Rows.Count > 0)
                    qtdPendente = int.Parse(dtbPendenciaConsumo.Rows[0]["QTD_PENDENTE"].ToString());

                if (qtdPendente == 0)
                {
                    dtbPendenciaConsumo = RequisicaoItens.SelPedidosReqItenPac(int.Parse(txtNroInternacao.Text), (int)dtoMatMed.Idt.Value, null, (int)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX);
                    string filtroQtdForn = string.Format("{0} > 0", RequisicaoItensDTO.FieldNames.QtdFornecida);

                    if (dtbPendenciaConsumo.Select(filtroQtdForn).Length > 0)                    
                        MessageBox.Show("Material/Medicamento pendente de Recebimento, PEDIDO N° " +
                                        dtbPendenciaConsumo.Select(filtroQtdForn)[0][RequisicaoItensDTO.FieldNames.Idt].ToString() + ". ", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);                    
                    else                    
                        MessageBox.Show("Material/Medicamento não pendente de consumo para este paciente, sendo necessário um novo pedido personalizado. ", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }                
            }
            return true;
        }

        private void BaixarProduto()
        {
            this.Cursor = Cursors.WaitCursor;
            if (PermitirConsumo() && gen.ValidarContaFaturadaComNF((decimal)dtoAtendimento.Idt.Value, decimal.Parse(cmbSetor.SelectedValue.ToString())))
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
                    if (!VerificaSetorPodeConsumir(cbCE.Checked))
                    {
                        txtCodProduto.Text = string.Empty;
                        txtCodProduto.Focus();
                        this.Cursor = Cursors.Default;
                        return;
                    }
                    if (dtoMatMed.IdtGrupo.Value == 1 && dtoMatMed.IdtSubGrupo.Value.ToString() == ANTIMICROBIANOS_RESTRITOS.ToString())
                    {
                        if (!AntimicrobianoPendentePedido())
                        {
                            txtCodProduto.Text = string.Empty;
                            txtCodProduto.Focus();
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }
                    else if (dtoMovimento.TpAtendimento.Value.ToString() == "I" && !cbCE.Checked && btnPendentes.Visible && !cbConsignado.Checked)
                    {
                        dtoPedidoPadrao = new PedidoPadraoDTO();
                        dtoPedidoPadrao.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                        dtoPedidoPadrao.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                        dtoPedidoPadrao.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                        dtoPedidoPadrao.Status.Value = (byte)PedidoPadraoDTO.StatusPedidoPadrao.CONFIRMADO;
                        dtoPedidoPadrao.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC;

                        if (!cbApenasFaturar.Visible) cbApenasFaturar.Checked = false;
                        if (!cbApenasFaturar.Checked && !PedidoPadrao.ProdutoPadrao(dtoPedidoPadrao, dtoMatMed, true))
                        {
                            if (!ItemPendentePedido())
                            {
                                txtCodProduto.Text = string.Empty;
                                txtCodProduto.Focus();
                                this.Cursor = Cursors.Default;
                                return;
                            }
                        }                        
                    }

                    dtoMovimento.IdtSubTipo.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
                    if (chkFracionar.Checked) dtoMatMed.FlFracionado.Value = (byte)MaterialMedicamentoDTO.Fracionado.SIM;
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
                    else if (cbDigitar.Visible && cbDigitar.Checked)
                    {
                        MovimentacaoDTO dtoQtd = new MovimentacaoDTO();
                        dtoQtd.DsProduto.Value = dtoMatMed.NomeFantasia.Value;
                        dtoQtd = FrmQtdMatMed.DigitaQtde(dtoQtd);
                        if (dtoQtd == null)
                        {
                            txtCodProduto.Text = string.Empty;
                            txtCodProduto.Focus();
                            this.Cursor = Cursors.Default;
                            return;
                        }
                        if (dtoQtd.Qtde.Value.IsNull) dtoQtd.Qtde.Value = 0;
                        if (dtoQtd.Qtde.Value == 0)
                        {                                
                            txtCodProduto.Text = string.Empty;
                            txtCodProduto.Focus();
                            this.Cursor = Cursors.Default;
                            return;
                        }                        
                        dtoMovimento.Qtde.Value = dtoQtd.Qtde.Value;                    
                    }
                    #endregion

                    dtoMovimento.TipoEmpresa.Value = rbHac.Checked ? (byte)MovimentacaoDTO.Empresa.HAC : (byte)MovimentacaoDTO.Empresa.ACS;
                    dtoMovimento.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    dtoMovimento.DtFaturamento.Value = txtDtTranf.Text;
                    dtoMovimento.HrFaturamento.Value = txtHrTransf.Text;
                    dtoMovimento.TpAtendimento.Value = (rbInternado.Checked ? "I" : "A");
                    if (!dtoMatMed.IdtLote.Value.IsNull && (decimal)dtoMatMed.IdtLote.Value != 0) dtoMovimento.IdtLote.Value = dtoMatMed.IdtLote.Value;
                    // ############## GERA O MOVIMENTO #############################################################
                    if (cbApenasFaturar.Visible && cbApenasFaturar.Checked)
                    {
                        dtoMovimento.IdtTipo.Value = (byte)MovimentacaoDTO.TipoMovimento.SAIDA;
                        dtoMovimento.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.INFO_ENVIO_FATURAMENTO;
                        dtoMovimento.FlFinalizado.Value = 1;
                        dtoMovimento = Movimento.EnviaProdutoFaturamento(dtoMovimento, dtoMatMed, CARRINHO_EMERG_SETOR_PAI);
                    }
                    else
                        dtoMovimento = Movimento.MovimentaEstoqueProduto(dtoMovimento, dtoMatMed, CARRINHO_EMERG_SETOR_PAI);
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
                        if (cbCE.Checked && !cbApenasFaturar.Checked)
                        {
                            dtoRequisicaoItemCE = RequisicaoItens.ConverteMatMedRequisicao(dtoMatMed);
                            if (dtoRequisicaoItemCE.IdtPrincipioAtivo.Value.IsNull) dtoRequisicaoItemCE.IdtPrincipioAtivo.Value = 0;
                            if (dtoRequisicaoItemCE.IdtPrincipioAtivo.Value != 0)
                            {
                                if (dtbRequisicaoItemCE.Select(string.Format("{0} = {1}",
                                                                             RequisicaoItensDTO.FieldNames.IdtPrincipioAtivo,
                                                                             dtoMatMed.IdtPrincipioAtivo.Value)).Length > 0)
                                {
                                    decimal qtdAnterior = decimal.Parse(dtbRequisicaoItemCE.Select(string.Format("{0} = {1}",
                                                                                                                 RequisicaoItensDTO.FieldNames.IdtPrincipioAtivo,
                                                                                                                 dtoMatMed.IdtPrincipioAtivo.Value))[0][RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString());
                                    dtoRequisicaoItemCE.QtdSolicitada.Value = qtdAnterior + 1;
                                    dtbRequisicaoItemCE.Select(string.Format("{0} = {1}",
                                                                             RequisicaoItensDTO.FieldNames.IdtPrincipioAtivo,
                                                                             dtoMatMed.IdtPrincipioAtivo.Value))[0][RequisicaoItensDTO.FieldNames.QtdSolicitada] = dtoRequisicaoItemCE.QtdSolicitada.Value;
                                }
                                else
                                {
                                    dtoRequisicaoItemCE.QtdSolicitada.Value = 1;
                                    dtbRequisicaoItemCE.Add(dtoRequisicaoItemCE);
                                }
                            }
                            else
                            {
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

                    if (int.Parse(cmbLocal.SelectedValue.ToString()) == (int)PacienteDTO.LocalAtendimento.PRONTO_SOCORRO)
                        gen.AlertarAutorizacaoKitGastro(dtoMatMed);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }                

                txtCodProduto.Text = string.Empty;
                txtCodProduto.Focus();
                dtbMovimento.AcceptChanges();
                tsHac.Items["tsBtnNovo"].Enabled = true;
                chkFracionar.Checked = false;
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

        #region NAO É MAIS UTILIZADO
        /*
        private MovimentacaoDataTable AtualizaGrid()
        {
            if (dtoMovimento.IdtTipo.Value != (byte)MovimentacaoDTO.TipoMovimento.SAIDA && dtoMovimento.IdtSubTipo.Value != (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_PERDA_QUEBRA)
            {
                // se não for registro de perda, atualiza datatable
                // atualiza informações sobre estoque NA TELA
                // dtoMovimento = .ConverteMatMedMovimento(dtoMatMed, dtoMovimento);
                if (dtbMovimento.Rows.Count != 0)
                {
                    string filtro = string.Format("{0} = {1}", MovimentacaoDTO.FieldNames.IdtProduto, dtoMovimento.IdtProduto.Value);
                    DataRow[] rows = dtbMovimento.Select(filtro);

                    if (rows.Length != 0)
                    {
                        if (Convert.ToDecimal(rows[0][MovimentacaoDTO.FieldNames.Qtde]) >= dtoMatMed.UnidadeVenda.Value && dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM)
                        {
                            rows[0][MovimentacaoDTO.FieldNames.Qtde] = 0;
                        }
                        rows[0][MovimentacaoDTO.FieldNames.Qtde] = (Convert.ToDecimal(rows[0][MovimentacaoDTO.FieldNames.Qtde]) + dtoMovimento.Qtde.Value);
                        if (dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM)
                        {
                            rows[0][MovimentacaoDTO.FieldNames.DsQtdeConsumo] = string.Format("{0}/{1}", Convert.ToString(rows[0][MovimentacaoDTO.FieldNames.Qtde]), dtoMatMed.UnidadeVenda.Value.ToString());
                            //rows[0][MovimentacaoDTO.FieldNames.DsQtdeFracionado] = string.Format("{1}/{0}  ( {2} )", dtoMatMed.UnidadeVenda.Value.ToString(), dtoMovimento.EstoqueLocalFracionado.Value.ToString(), dtoMatMed.DsUnidadeVenda.Value.ToString());                                
                        }
                        else
                        {
                            rows[0][MovimentacaoDTO.FieldNames.DsQtdeConsumo] = string.Format("{0}", Convert.ToString(rows[0][MovimentacaoDTO.FieldNames.Qtde]));
                        }

                        rows[0][MovimentacaoDTO.FieldNames.EstoqueLocal] = dtoMovimento.EstoqueLocal.Value;
                        // rows[0][MovimentacaoDTO.FieldNames.QtdeLote] = (Convert.ToDecimal(rows[0][MovimentacaoDTO.FieldNames.QtdeLote]) - 1);
                        dtoMovimento.Qtde.Value = Convert.ToDecimal(rows[0][MovimentacaoDTO.FieldNames.Qtde]);
                        dtoMovimento.DsQtdeConsumo.Value = rows[0][MovimentacaoDTO.FieldNames.DsQtdeConsumo].ToString();
                        //dtoMovimento.DsQtdeFracionado.Value = rows[0][MovimentacaoDTO.FieldNames.DsQtdeFracionado].ToString();
                    }
                    else
                    {
                        if (dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM)
                        {
                            dtoMovimento.DsQtdeConsumo.Value = string.Format("{0}/{1}", dtoMovimento.Qtde.Value.ToString(), dtoMatMed.UnidadeVenda.Value.ToString());
                            //dtoMovimento.DsQtdeFracionado.Value = string.Format("{1}/{0}  ( {2} )", dtoMatMed.UnidadeVenda.Value.ToString(), dtoMovimento.EstoqueLocalFracionado.Value.ToString(), dtoMatMed.DsUnidadeVenda.Value.ToString());                                
                        }
                        else
                        {
                            dtoMovimento.DsQtdeConsumo.Value = dtoMovimento.Qtde.Value.ToString();
                        }
                        dtbMovimento.Add(dtoMovimento);
                    }
                }
                else
                {
                    if (dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM)
                    {
                        dtoMovimento.DsQtdeConsumo.Value = string.Format("{0}/{1}", dtoMovimento.Qtde.Value.ToString(), dtoMatMed.UnidadeVenda.Value.ToString());
                        //dtoMovimento.DsQtdeFracionado.Value = string.Format("{1}/{0}  ( {2} )", dtoMatMed.UnidadeVenda.Value.ToString(), dtoMovimento.EstoqueLocalFracionado.Value.ToString(), dtoMatMed.DsUnidadeVenda.Value.ToString());                            
                    }
                    else
                    {
                        dtoMovimento.DsQtdeConsumo.Value = dtoMovimento.Qtde.Value.ToString();
                    }
                    dtbMovimento.Add(dtoMovimento);
                }

            }
            else
            {
                // retorna null quando for perda
                dtbMovimento = null;
            }
            return dtbMovimento;
        }
        */
        #endregion

        private void SalvarPedidoCE()
        {
            if (dtbRequisicaoItemCE == null)
            {
                MessageBox.Show("PEDIDO NÃO CARREGADO CORRETAMENTE!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
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
                    
                    if (CARRINHO_EMERG_SETOR_PAI != null)
                        MessageBox.Show("Pedido gerado com sucesso!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Não foi consumido nenhum produto para a geração de pedido do carrinho de emergência", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                dtoRequisicaoCE = null;
                dtbRequisicaoItemCE = null;
                if (CARRINHO_EMERG_SETOR_PAI != null)
                    dtbRequisicaoItemCE = new RequisicaoItensDataTable();
                cmbSetor.SelectedValue = SETOR_SELECIONADO;
                txtCodProduto.Focus();
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
                if (!Movimento.PermiteConsumo(dto))
                {
                    CONTA_FATURADA = (int)PacienteDTO.Faturada.SIM;
                    lblContaFaturada.Visible = true;
                }
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

            cbDigitar.Visible = cbDigitar.Checked = false;
            cbApenasFaturar.Visible = cbApenasFaturar.Checked = true;
            if (dtoCfg.IdFuncionalidade.Value.IsNull)
            {
                cbApenasFaturar.Visible = cbApenasFaturar.Checked = false;
                if (CARRINHO_EMERG_SETOR_PAI == null) cbDigitar.Visible = true;
            }
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
            dtbMovimento = new MovimentacaoDataTable();
            dtbHistMovimento = new MovimentacaoDataTable();
            // dtgConsumo.DataSource = null;
            dtgHistConsumo.DataSource = null;
            dtoRequisicaoCE = null;
            dtbRequisicaoItemCE = null;
            cbCE.Enabled = false;
            //if (!ESTOQUE_UNIFICADO_HAC) cbCE.Checked = false;
            FixarCE();
            pnlPendentes.Visible = grbCE.Visible = false;
            // SO HABILITA FRACIONAMENTO DE INTEIRO PARA
            // BERÇARIO ALA C
            //if (cmbSetor.SelectedValue != null && cmbSetor.SelectedValue.ToString() == "46") 
            //{
            //    chkFracionar.Enabled = true;
            //    chkFracionar.Visible = true;
            //}
            //else
            //{
            //    chkFracionar.Enabled = false;
            //    chkFracionar.Visible = false;
            //}
            chkFracionar.Enabled = false;
            chkFracionar.Visible = false;

            txtDtTranf.Text = string.Empty;
            txtHrTransf.Text = string.Empty;
            CONTA_FATURADA = (int)PacienteDTO.Faturada.NAO;
            lblContaFaturada.Visible = false;

            tsHac.Items["tsBtnPrint"].Enabled = false;
            if (cbApenasFaturar.Visible)
                cbApenasFaturar.Checked = true;

            return true;
        }

        private void CarregarItensPendentes()
        {
            this.Cursor = Cursors.WaitCursor;
            RequisicaoItensDataTable dtbPendenciaConsumo = RequisicaoItens.SelReqItensPendentesConsumoPac(int.Parse(txtNroInternacao.Text), null, null);
            if (dtbPendenciaConsumo.Rows.Count > 0)
            {
                dtgItensPendentes.DataSource = dtbPendenciaConsumo;
                pnlPendentes.Visible = true;
                btnFecharPendentes.Visible = true;
            }
            else
            {
                MessageBox.Show("Não existem itens pendentes pedidos para este paciente", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodProduto.Focus();
            }
            this.Cursor = Cursors.Default;
        }

        private void RotinaAtivarCE()
        {
            MessageBox.Show("Os próximos consumos gerarão um pedido para o reabastecimento do carrinho de emergência.\n\nDepois de registrar o(s) consumo(s), clique em Finalizar Consumo do Carrinho de Emergência.",
                            "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            cbCE.Enabled = false;
            btnFinalizarCE.Visible = true;
            cbConsignado.Enabled = false;
            cbConsignado.Checked = false;
            cbApenasFaturar.Checked = false;            
            dtbRequisicaoItemCE = new RequisicaoItensDataTable();
            txtCodProduto.Enabled = true;
        }

        #region Eventos

        private void FrmConsumoPaciente_Load(object sender, EventArgs e)
        {
            cbApenasFaturar.Visible = true; //mudar para true quando for para funcionar em Produção
            cbConsignado.Visible = true;
            cmbUnidade.Carregaunidade();
            Generico.ConfiguraCombos(cmbUnidade, cmbLocal, cmbSetor, FrmPrincipal.dtoSeguranca);
            SETOR_SELECIONADO = int.Parse(cmbSetor.SelectedValue.ToString());
            grpTipoAtendimento.Enabled = btnPendentes.Visible = false;
            if (VerificaSetorPodeAcessar()) ConfiguraTipoAtendimento();            
            ConfiguraDTG();
            ConfiguraItensPendentesDTG();
            chkFracionar.Enabled = false;
            chkFracionar.Visible = false;
            dtgHistConsumo.Columns["colDeletarHist"].Visible = false;

            if (cmbSetor.SelectedValue != null && cmbSetor.SelectedValue.ToString() == HEMODINAMICA.ToString())
            {
                tsHac.Items["tsBtnPrint"].Visible = true;
                tsHac.Items["tsBtnPrint"].Enabled = false;
            }
            else
            {
                tsHac.Items["tsBtnPrint"].Visible = false;
                tsHac.Items["tsBtnPrint"].Enabled = false;
            }
            tsHac.Items["tsBtnMatMed"].Visible = false;
#if DEBUG
            txtDtTranf.Visible = true;
            txtHrTransf.Visible = true;
            btnRegerarFaturamento.Visible = true;
#else                
                //tsHac.Items["tsBtnMatMed"].Visible = false;
                txtDtTranf.Visible = false;
                txtHrTransf.Visible = false;                
                btnRegerarFaturamento.Visible = false;
#endif
        }

        private void cbApenasFaturar_Click(object sender, EventArgs e)
        {
            if (cbConsignado.Checked)
            {
                cbApenasFaturar.Checked = false;
                MessageBox.Show("Funcionalidade não permitida quando checado estoque de CONSIGNADO", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            dtbHistMovimento.Rows.Clear();
            txtCodProduto.Focus();
        }

        private void btnPesquisaPac_Click(object sender, EventArgs e)
        {
            if (txtNroInternacao.Enabled)
            {
                // this.PesquisarPaciente();
                btnPendentes.Visible = false;
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
            if (!PermitirConsumo()) return false;
            if ((!rbAcs.Checked && !rbHac.Checked) || dtoAtendimento == null)
            {
                MessageBox.Show("Pesquise o paciente", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroInternacao.Focus();
                return false;
            }
            dtoMatMed = new MaterialMedicamentoDTO();
            dtoMatMed.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoMatMed.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoMatMed.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoMatMed.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC; //gen.RetornaFilial(rbHac, rbAcs); // rbHac.Checked ? (byte)FilialMatMedDTO.Filial.HAC : (byte)FilialMatMedDTO.Filial.ACS;
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
            tsHac.Items["tsBtnMatMed"].Visible = false;
            if (SETOR_SELECIONADO != null) cmbSetor.SelectedValue = SETOR_SELECIONADO;
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
            SETOR_SELECIONADO = null;
            if (ZerarObjetos(false)) tsHac.Controla(Evento.eCancelar);
        }

        private void cmbLocal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SETOR_SELECIONADO = null;
            if (ZerarObjetos(false)) tsHac.Controla(Evento.eCancelar);
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ZerarObjetos(false)) tsHac.Controla(Evento.eCancelar);
            if (VerificaSetorPodeAcessar()) ConfiguraTipoAtendimento();
            if (cmbSetor.SelectedValue != null && cmbSetor.SelectedIndex > -1)
                SETOR_SELECIONADO = int.Parse(cmbSetor.SelectedValue.ToString());
        }

        private void cmbCE_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbSetor.SelectedValue = cmbCE.SelectedValue.ToString();
            CARRINHO_EMERG_SETOR_PAI = new Generico().SetorCarrinhoEmergencia(int.Parse(cmbSetor.SelectedValue.ToString()));
            grbCE.Visible = false;
            RotinaAtivarCE();
            txtCodProduto.Focus();
        }

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
                }
                catch (Exception ex) { }
            }
            if (dtgHistConsumo.Columns[e.ColumnIndex].Name == colPedido.Name &&
                !string.IsNullOrEmpty(dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString()))
            {
                if (byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString()) != (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_CONS_DISP_AUTO_PACIENTE)
                    e.Value = string.Empty;
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
                if (dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString() != string.Empty)
                {
                    if (byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString()) == (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_CONS_DISP_AUTO_PACIENTE)
                    {
                        //MessageBox.Show("Não é permitido estornar por esta tela registro de baixa direta realizada na dispensação do pedido.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MessageBox.Show("Não permitido estorno de pedido personalizado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }                    
                }
                this.Cursor = Cursors.WaitCursor;
                dtoPedidoPadrao = new PedidoPadraoDTO();

                dtoPedidoPadrao.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                dtoPedidoPadrao.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                dtoPedidoPadrao.IdtLocal.Value = cmbLocal.SelectedValue.ToString(); 
                dtoPedidoPadrao.Status.Value = (byte)PedidoPadraoDTO.StatusPedidoPadrao.CONFIRMADO;
                dtoPedidoPadrao.IdtFilial.Value = dtgHistConsumo.Rows[e.RowIndex].Cells["colIdFilial"].Value.ToString() == "4" ? (decimal)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA : (decimal)FilialMatMedDTO.Filial.HAC;

                dtoMatMed = new MaterialMedicamentoDTO();
                dtoMatMed.Idt.Value = dtgHistConsumo.Rows[e.RowIndex].Cells["colIdtProdutoHist"].Value.ToString();
                dtoMatMed = MatMed.SelChave(dtoMatMed);

                //bool blnCE = false;
                //if (dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString() != string.Empty)
                //{
                //    if (byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString()) == (byte)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA_CARRINHO_EMERGENCIA ||
                //        byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString()) == (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_CONSUMO_CARRINHO_EMERGENCIA_FATURADO ||
                //        byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString()) == (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_CONSUMO_CARRINHO_EMERGENCIA_NAO_FATURADO)
                //        blnCE = true;
                //}

                //if (!VerificaSetorPodeConsumir(blnCE))                                    
                    //return;                

                ConfiguraMovimentoDTO();
                dtoMovimento.Idt.Value = decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colIdtMovimentoHist"].Value.ToString());

                #region Retirado em 08/12/2009
                //if (PedidoPadrao.ProdutoPadrao(dtoPedidoPadrao, dtoMatMed))
                //{                    
                //    //DateTime dataRessup = DateTime.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colDataRessup"].Value.ToString());
                //    // Busca valor no banco, pois a tela da pessoa pode estar aberta a muito tempo e não ter a Data Ressup. atualizada
                //    MovimentacaoDTO dtoMovDataRessup = Movimento.SelChave(dtoMovimento);
                //    if (!dtoMovDataRessup.DataRessupri.Value.IsNull)
                //    {
                //        DateTime dataRessup = (DateTime)dtoMovDataRessup.DataRessupri.Value;
                //        DateTime dataMov = DateTime.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colDataHist"].Value.ToString());

                //        if (dataRessup > dataMov)
                //        {
                //            MessageBox.Show("Estorno indevido, pois é um produto do estoque fixo que já foi ressuprido depois deste consumo", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //            this.Cursor = Cursors.Default;
                //            return;
                //        }
                //    }                    
                //}
                #endregion

                PedidoPadraoItensDTO dtoPedPadItem = new PedidoPadraoItensDTO();

                #region VERIFICA SE PODE EXCLUIR - COMPARA ESTOQUE PADRAO AO ESTOQUE ATUAL
                // verifica se existe a informação
                if (dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString() != string.Empty &&
                    decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colIdFilial"].Value.ToString()) != (decimal)FilialMatMedDTO.Filial.CONSIGNADO)
                {
                    if (byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString()) != (byte)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA &&
                        byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString()) != (byte)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA_CARRINHO_EMERGENCIA &&
                        byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString()) != (byte)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_REUTILIZAVEL)
                    {    
                        if (byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString()) == (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_CONSUMO_CARRINHO_EMERGENCIA_FATURADO)
                            dtoPedidoPadrao.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
                        if (PedidoPadrao.ProdutoPadrao(dtoPedidoPadrao, dtoMatMed, ref dtoPedPadItem, true))
                        {
                            decimal qtdNova = decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colQtdHist"].Value.ToString()) + dtoPedPadItem.EstoqueLocalQtde.Value.DBValue.Value;

                            if (qtdNova > dtoPedPadItem.Qtde.Value)
                            {
                                MessageBox.Show("Não pode ser realizado o estorno deste produto neste momento, pois ele pertence ao estoque fixo que já está no Limite", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.Cursor = Cursors.Default;
                                return;
                            }
                        }
                    }
                }
                #endregion

                //if (PermitirConsumo())                
                if (Movimento.PermitirEstornoConsumoItem(ref dtoMovimento))
                {
                    string mensagem = "Deseja realmente estornar este consumo ?";
                    bool apenasFaturamento = false;
                    if (dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString() != string.Empty &&
                        byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString()) == (byte)MovimentacaoDTO.SubTipoMovimento.INFO_ENVIO_FATURAMENTO)
                    {
                        mensagem = "Deseja realmente cancelar este item no faturamento?";
                        apenasFaturamento = true;
                    }
                    if (MessageBox.Show(mensagem, "Gestão de Materiais e Medicamentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            //dtoMovimento.IdtFilial.Value = decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colIdFilial"].Value.ToString());
                            dtoMovimento.IdtProduto.Value = long.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colIdtProdutoHist"].Value.ToString());
                            dtoMovimento.Qtde.Value = decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colQtdInteiraHist"].Value.ToString());
                            dtoMovimento.IdtUsuarioEstorno.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                            if (apenasFaturamento)
                            {
                                Movimento.EstornarMovimentoFaturamento(dtoMovimento);
                                Movimento.MarcarEstornoMovimento((decimal)dtoMovimento.Idt.Value);
                            }
                            else
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

                                // dtbHistMovimento.Rows[e.RowIndex].Delete();
                                dtbHistMovimento.AcceptChanges();
                            }
                            //else if (dtbMovimento.Rows.Count > 0)
                            //{
                            //    dtbMovimento.Select(string.Format("{0} = {1}",
                            //                             MovimentacaoDTO.FieldNames.Idt,
                            //                             dtoMovimento.Idt.Value))[0].Delete();
                            //    //dtbMovimento.Rows[e.RowIndex].Delete();
                            //    dtbMovimento.AcceptChanges();

                            //}
                        }
                        catch (Exception ex)
                        {
                            //if ( ex.Message.IndexOf("Object") == -1 )
                            MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ////this.Cursor = Cursors.Default;
                            //if (dtbHistMovimento.Rows.Count > 0)
                            //{
                            //    dtbHistMovimento.Rows[e.RowIndex].Delete();
                            //    dtbHistMovimento.AcceptChanges();
                            //}
                            //else if (dtbMovimento.Rows.Count > 0)
                            //{
                            //    dtbMovimento.Rows[e.RowIndex].Delete();
                            //    dtbMovimento.AcceptChanges();

                            //}
                            this.Cursor = Cursors.Default;
                        }
                        //finally
                        //{
                        //    if (dtbHistMovimento.Rows.Count > 0)
                        //    {
                        //        dtbHistMovimento.Rows[e.RowIndex].Delete();
                        //        dtbHistMovimento.AcceptChanges();
                        //    }
                        //    else if (dtbMovimento.Rows.Count > 0)
                        //    {
                        //        dtbMovimento.Rows[e.RowIndex].Delete();
                        //        dtbMovimento.AcceptChanges();

                        //    }

                        //}
                    }
                }
                else
                {
                    MessageBox.Show("Este consumo já foi faturado e não pode ser estornado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void tabConsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodProduto.Focus();
            tsHac.Items["tsBtnNovo"].Enabled = true;
        }

        private void cbCE_Click(object sender, EventArgs e)
        {
            if (cbConsignado.Checked)
            {
                cbCE.Checked = false;
                MessageBox.Show("Funcionalidade não permitida quando checado estoque de CONSIGNADO", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            grbCE.Visible = false;
            if (CARRINHO_EMERG_SETOR_PAI != null && !cbCE.Checked)
            {
                cbCE.Checked = true;
                cbConsignado.Enabled = false;
                cbConsignado.Checked = false;
                txtCodProduto.Focus();
                return;
            }
            if (PermitirConsumo())
            {
                if (cbCE.Checked)
                {
                    this.Cursor = Cursors.WaitCursor;
                    SetorDTO dtoSetor = new SetorDTO();
                    dtoSetor.CarrinhoEmergSetorPai.Value = cmbSetor.SelectedValue.ToString();
                    SetorDataTable dtbSetorCE = Setor.Sel(dtoSetor);
                    this.Cursor = Cursors.Default;
                    if (dtbSetorCE.Rows.Count > 0)
                    {
                        dtoSetor = new SetorDTO();
                        dtoSetor.Idt.Value = cmbSetor.SelectedValue.ToString();
                        dtoSetor.Descricao.Value = cmbSetor.Text;
                        dtbSetorCE.Add(dtoSetor); //Add. possibilidade de selecionar próprio setor

                        txtCodProduto.Enabled = false;
                        grbCE.Visible = true;
                        cbConsignado.Enabled = false;
                        cbConsignado.Checked = false;
                        cmbCE.DataSource = dtbSetorCE;
                        cmbCE.IniciaLista();
                        cmbCE.Focus();
                        return;
                    }
                    else
                    {
                        //MessageBox.Show("O próximo consumo gerará um pedido para o almoxarifado, para o reabastecimento do carrinho de emergência", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        RotinaAtivarCE();
                    }
                }
                else
                {
                    dtoRequisicaoCE = null;
                    dtbRequisicaoItemCE = null;
                }
                txtCodProduto.Focus();
            }
            if (!cbCE.Checked) cbConsignado.Enabled = true;
        }

        private void btnFinalizarCE_Click(object sender, EventArgs e)
        {
            if (txtNomePac.Text == string.Empty)
            {
                MessageBox.Show("Nenhum atendimento foi carregado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            SalvarPedidoCE();

            if (SETOR_SELECIONADO != null && SETOR_SELECIONADO.Value != int.Parse(cmbSetor.SelectedValue.ToString())) cmbSetor.SelectedValue = SETOR_SELECIONADO;
            cbCE.Checked = false;
            cbCE.Enabled = true;
            btnFinalizarCE.Visible = false;
            cbConsignado.Enabled = true;
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

        private bool tsHac_ImprimirClick(object sender)
        {
            if (txtNomePac.Text == string.Empty)
            {
                MessageBox.Show("Nenhum atendimento foi carregado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            string nomeRelatorio = "GM_DespesaHemodinamica";
            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[20];

            #region Monta Parâmetros

            int x = 0;

            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_UNI_ID_UNIDADE", cmbUnidade.SelectedValue.ToString());
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_LAT_ID_LOCAL_ATENDIMENTO", cmbLocal.SelectedValue.ToString());
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_SET_ID", cmbSetor.SelectedValue.ToString());
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PATD_ATE_ID", txtNroInternacao.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PATD_ATE_TP_PACIENTE", (rbInternado.Checked ? "I" : "A"));
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("sUnidLocalSetor", string.Format("{0} / {1} / {2} ", cmbUnidade.SelectedText, cmbLocal.SelectedText, cmbSetor.SelectedText));
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("SNomPac", txtNomePac.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("sAtendimento", txtNroInternacao.Text.ToString());
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("sAla", txtLocal.Text);
            // reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("sDataRel", DateTime.Now.ToString("dd/MM/yyyy").ToString());
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("sConvenio", string.Format("{0} - {1}", txtCodConvenio.Text, txtNomeConvenio.Text));

            #endregion

            //Microsoft.Reporting.WinForms.ReportParameter[] reportParamTemp = new Microsoft.Reporting.WinForms.ReportParameter[x];

            //for (int i = 0; i < reportParam.Length; i++)
            //{
            //    if (reportParam[i] == null) break;
            //    reportParamTemp[i] = reportParam[i];
            //}
            //reportParam = reportParamTemp;
            //reportParamTemp = null;

            //FrmReportViewer frmRelatorio = new FrmReportViewer();
            //frmRelatorio.AbreRelatorio(nomeRelatorio, reportParam);
            FrmImpPorPeriodo imp = new FrmImpPorPeriodo(reportParam, nomeRelatorio);
            imp.MdiParent = FrmPrincipal.ActiveForm;
            imp.Show();
            return true;
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
                dtoMov.TpAtendimento.Value = (rbInternado.Checked ? "I" : "A");

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

        private void btnFecharPendentes_Click(object sender, EventArgs e)
        {
            pnlPendentes.Visible = false;
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
            CarregarItensPendentes();
        }

        private void btnRelDevolucao_Click(object sender, EventArgs e)
        {
            string nomeRelatorio = "GM_35_PEDIDOS_PAC_PENDENCIA_CONS";
            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[5];

            #region Monta Parâmetros

            int x = 0;

            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_SET_ID", cmbSetor.SelectedValue.ToString());
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PSETOR", cmbSetor.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PATD_ATE_ID", txtNroInternacao.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PPACIENTE", txtNomePac.Text);            
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PUSUARIO", FrmPrincipal.dtoSeguranca.Login.Value);

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
        }

        private void btnFecharCE_Click(object sender, EventArgs e)
        {
            if (SETOR_SELECIONADO != null) cmbSetor.SelectedValue = SETOR_SELECIONADO;
            grbCE.Visible = false;
            cbCE.Checked = false;
            txtCodProduto.Enabled = true;
            txtCodProduto.Focus();
        }

        private void dtgItensPendentes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex != -1 && e.ColumnIndex != -1)
            //{
            //    MaterialMedicamentoDTO dtoMM = new MaterialMedicamentoDTO();
            //    dtoMM.Idt.Value = dtgItensPendentes.Rows[e.RowIndex].Cells[colMatMedIdtPend.Name].Value.ToString();
            //    dtoMM.NomeFantasia.Value = dtgItensPendentes.Rows[e.RowIndex].Cells[colDsMatMedPend.Name].Value.ToString();
            //    FrmCancelarItemPedido.Cancelar(dtoMM, int.Parse(txtNroInternacao.Text), int.Parse(dtgItensPendentes.Rows[e.RowIndex].Cells[colQtdPendente.Name].Value.ToString()));
            //    CarregarItensPendentes();
            //}
        }

        private void cbDigitar_Click(object sender, EventArgs e)
        {
            txtCodProduto.Focus();
        }

        private void cbConsignado_Click(object sender, EventArgs e)
        {
            if (cbConsignado.Checked && cbCE.Checked)
                btnFecharCE_Click(sender, e);

            if (cbConsignado.Checked)
            {
                cbApenasFaturar.Checked = false;
                tsHac.Items["tsBtnMatMed"].Visible = true;
            }
            else
                tsHac.Items["tsBtnMatMed"].Visible = false;
        }
        #endregion
    }
}