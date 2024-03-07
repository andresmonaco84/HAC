using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.GestaoMateriais.Cadastro;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Interface;
using HospitalAnaCosta.SGS.Seguranca.View;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.Relatorio;
using System.Threading;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmPersonalizado : FrmBase
    {
        private int? ID_PrescricaoInternacao = null;
        private bool PrescricaoInternacaoGerada = false;
        private bool SetorPedidoAutomaticoVigencia = false;
        private const decimal CENTRO_CIRURGICO = 61;
        private const decimal ATENDIMENTO_DOMICILIAR = 2252;
        private const decimal ANTIMICROBIANOS_RESTRITOS = 981;
        private const decimal PROFILATICO = 940;
        private const int PSICOTROPICO1 = 12;
        private const int PSICOTROPICO2 = 912;
        private const decimal UTI_EDA_GERAL = 2732;
        private const decimal UTI_ALMOX_SATELITE = 2092;
        private bool _ultrapassouCorte = false;
        private int _qtdPendenteItemPrescricao = 0;
        private int _qtdTotalAutorizadaItemPrescricao = 0;
        private decimal _SetorThread = 0;
        private DataTable _dtbMatMedTrocaMemoria =  null;
        private DataTable _dtbMatMedAntimicrobianosMemoria = null;
        //private int Ponteiro = 0;
        //private enum navega
        //{
        //    PRIMEIRO,
        //    ANTERIOR,
        //    PROXIMO,
        //    ULTIMO
        //}

        public FrmPersonalizado()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇO

        private CommonSeguranca _commonSeguranca;
        protected CommonSeguranca CommonSeguranca
        {
            get { return _commonSeguranca != null ? _commonSeguranca : _commonSeguranca = new CommonSeguranca(null); }
        }

        private IUsuario _usuario;
        public IUsuario Usuario
        {
            get { return _usuario != null ? _usuario : _usuario = (IUsuario)CommonSeguranca.GetObject(typeof(IUsuario)); }
        }

        // Atendimento
        private PacienteDTO dtoAtendimento;
        private IPaciente _atendimento;
        private IPaciente Atendimento
        {
            get { return _atendimento != null ? _atendimento : _atendimento = (IPaciente)Global.Common.GetObject(typeof(IPaciente)); }
        }
        
        // Itens Requisição
        private RequisicaoItensDataTable dtbItensRemovidosPrescricao;
        private RequisicaoItensDataTable dtbRequisicaoItem;
        private RequisicaoItensDTO dtoRequisicaoItem;
        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject( typeof(IRequisicaoItens)); }
        }        
        
        // Requisição
        private RequisicaoDTO dtoRequisicao;
        private RequisicaoDataTable dtbRequisicao;        
        private IRequisicao _requisicao;
        private IRequisicao Requisicao
        {
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject( typeof(IRequisicao)); }
        }        

        // Estoque
        private EstoqueLocalDTO dtoEstoque;
        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject( typeof(IEstoqueLocal)); }
        }        
        
        // Pedido Padrão        
        private PedidoPadraoDTO dtoPedidoPadrao;
        private IPedidoPadrao _pedidopadrao;
        private IPedidoPadrao PedidoPadrao
        {
            get { return _pedidopadrao != null ? _pedidopadrao : _pedidopadrao = (IPedidoPadrao)Global.Common.GetObject( typeof(IPedidoPadrao)); }
        }

        // Filial        
        private IFilialMatMed _filialMatMed;
        private IFilialMatMed FilialMatMed
        {
            get { return _filialMatMed != null ? _filialMatMed : _filialMatMed = (IFilialMatMed)Global.Common.GetObject( typeof(IFilialMatMed)); }
        }

        // MatMed
        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get
            {
                return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject( typeof(IMaterialMedicamento));
            }
        }

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

        // Kit
        private IKit _kit;
        private IKit Kit
        {
            get { return _kit != null ? _kit : _kit = (IKit)Global.Common.GetObject(typeof(IKit)); }
        }

        // Prescricao
        private PrescricaoDTO dtoPrescricao;
        private IPrescricao _prescricao;
        private IPrescricao Prescricao
        {
            get { return _prescricao != null ? _prescricao : _prescricao = (IPrescricao)Global.Common.GetObject(typeof(IPrescricao)); }
        }

        // Similar
        private IMatMedSimilar _similar;
        private IMatMedSimilar Similar
        {
            get { return _similar != null ? _similar : _similar = (IMatMedSimilar)Global.Common.GetObject(typeof(IMatMedSimilar)); }
        }

        // Movimentos
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }

        private IMatMedFuncionalidade _matMedFuncionalidade;
        private IMatMedFuncionalidade MatMedFuncionalidade
        {
            get { return _matMedFuncionalidade != null ? _matMedFuncionalidade : _matMedFuncionalidade = (IMatMedFuncionalidade)Global.Common.GetObject(typeof(IMatMedFuncionalidade)); }
        }

        private IFuncionalidade _funcionalidade;
        private IFuncionalidade Funcionalidade
        {
            get { return _funcionalidade != null ? _funcionalidade : _funcionalidade = (IFuncionalidade)CommonSeguranca.GetObject(typeof(IFuncionalidade)); }
        }        

        // Utilitario
        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        private bool _carregarCombo = true;

        Generico gen = new Generico();

        #endregion

        #region FUNÇÕES

        /// <summary>
        /// Gera e retorna os itens gerados
        /// </summary>        
        public static bool GerarPedidoPrescricaoInt(RequisicaoDTO dtoReq, RequisicaoItensDataTable dtbReqItem, bool ultrapassouCorte)
        {
            FrmPersonalizado frm = new FrmPersonalizado();
            if (dtbReqItem.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum item encontrado na Prescrição!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return frm.PrescricaoInternacaoGerada;
            }
            frm.ID_PrescricaoInternacao = int.Parse(dtbReqItem.Rows[0][RequisicaoItensDTO.FieldNames.IdPrescricaoInternacao].ToString());
            frm.dtoRequisicao = dtoReq;
            frm.dtbRequisicaoItem = dtbReqItem;
            frm._ultrapassouCorte = ultrapassouCorte;
            frm.ShowDialog();
            //frm.Show();
            return frm.PrescricaoInternacaoGerada;
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
        //    // CarregarComboMatMed();
        //}        
       
        private void ExecThreadComboMatMed()
        {
            dtoMatMed = new MaterialMedicamentoDTO();

            dtoMatMed.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoMatMed.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoMatMed.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            //if (rbHac.Checked)
            //    dtoMatMed.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            //else if (rbAcs.Checked)
            //    dtoMatMed.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
            dtoMatMed.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.COM_PERMISSAO_SUBGRUPO;
            dtoMatMed.NomeFantasia.Value = "%";
            dtoMatMed.FlAtivo.Value = 1; // ATIVO

            if (_carregarCombo)
            {
                this.Cursor = Cursors.WaitCursor;
                cmbMatMed.Text = "A G U A R D E !!!";
                ConfiguraPedidoPadraoDTO();
                _SetorThread = decimal.Parse(cmbSetor.SelectedValue.ToString());
                new Thread(new ThreadStart(ComboMatMed)).IsBackground = true;
                new Thread(new ThreadStart(ComboMatMed)).Start();                                
                // cmbMatMed.IniciaLista();
                this.Cursor = Cursors.Default;
                btnAdd.Enabled = true;
                cmbMatMed.Focus();
            }
            else
            {
                if (cmbMatMed.Text != "A G U A R D E !!!")
                {
                    if (!cmbMatMed.Enabled && !cbAntimicrobianos.Checked)
                        cmbMatMed.Enabled = true;
                    btnAdd.Enabled = true;
                    cmbMatMed.IniciaLista();
                }
            }
        }
        
        private void ConfiguraRequisicaoDTO()
        {
            if (dtoRequisicao == null) dtoRequisicao = new RequisicaoDTO();
            dtoRequisicao.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoRequisicao.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoRequisicao.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.ABERTA;
            // INTERNO - EXTERNO - DOMICILIAR
            dtoRequisicao.IdtTipoRequisicao.Value = (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO;
            if (rbHac.Checked)
                dtoRequisicao.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;            
            else if (rbAcs.Checked)
                dtoRequisicao.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
        }

        /// <summary>
        /// Carrega valoes para o dto do pedido padrão
        /// </summary>
        private void ConfiguraPedidoPadraoDTO()
        {
            dtoPedidoPadrao = new PedidoPadraoDTO();

            dtoPedidoPadrao.IdtUnidade.Value = int.Parse(cmbUnidade.SelectedValue.ToString());
            dtoPedidoPadrao.IdtSetor.Value = int.Parse(cmbSetor.SelectedValue.ToString());
            dtoPedidoPadrao.IdtLocal.Value = int.Parse(cmbLocal.SelectedValue.ToString());
            dtoPedidoPadrao.Status.Value = (byte)PedidoPadraoDTO.StatusPedidoPadrao.CONFIRMADO;
            dtoPedidoPadrao.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
        }

        private bool Validar()
        {
            //if (!ValidarSetor()) return false;
            if (!ValidarPaciente()) return false;
            //if (!ValidarFilial()) return false;

            foreach (DataGridViewRow dtgRow in dtgPersonalisado.Rows)
            {
                if (ID_PrescricaoInternacao == null && long.Parse(dtgRow.Cells["colMatMedPrincAt"].Value.ToString()) != 0)
                {
                    if (dtbRequisicaoItem.Select(string.Format("{0} = {1}",
                                                 RequisicaoItensDTO.FieldNames.IdtPrincipioAtivo,
                                                 dtgRow.Cells["colMatMedPrincAt"].Value)).Length > 1)
                    {
                        MessageBox.Show(string.Format("O item {0} não pode ter um similar nesta lista", dtgRow.Cells["colDsProd"].Value.ToString()),
                                        "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                else if (ID_PrescricaoInternacao != null && !string.IsNullOrEmpty(dtgRow.Cells[colDataHoraDose.Name].Value.ToString()))
                {
                    string filtro = string.Format("{0} = {1} AND {2} <> 'DIL' AND {5} IS NOT NULL AND {3} IS NOT NULL AND {3} = '{4}'",
                                                    RequisicaoItensDTO.FieldNames.IdtPrincipioAtivo,
                                                    dtgRow.Cells[colMatMedPrincAt.Name].Value,
                                                    RequisicaoItensDTO.FieldNames.TipoPrescricaoItem,
                                                    RequisicaoItensDTO.FieldNames.DataHoraAdmPaciente,
                                                    dtgRow.Cells[colDataHoraDose.Name].Value,
                                                    RequisicaoItensDTO.FieldNames.HorasPeriodoDose);
                    DataRow[] arrDtRowPA = dtbRequisicaoItem.Select(filtro);
                    if (long.Parse(dtgRow.Cells[colMatMedPrincAt.Name].Value.ToString()) != 0)
                    {
                        if (arrDtRowPA.Length > 1)
                        {
                            MessageBox.Show(string.Format("O item {0} não pode ter um similar no mesmo período nesta lista, favor verificar a prescrição com o médico para ajuste.", dtgRow.Cells["colDsProd"].Value.ToString()),
                                            "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        //else if (arrDtRowPA.Length == 2)
                        //{
                        //    string periodoDose = arrDtRowPA[0][RequisicaoItensDTO.FieldNames.HorasPeriodoDose].ToString();
                        //    bool primeiroUrgente = periodoDose == string.Empty ? true : false;

                        //    periodoDose = arrDtRowPA[1][RequisicaoItensDTO.FieldNames.HorasPeriodoDose].ToString();
                        //    bool segundoUrgente = periodoDose == string.Empty ? true : false;

                        //    if ((primeiroUrgente && segundoUrgente) || (!primeiroUrgente && !segundoUrgente))
                        //    {
                        //        MessageBox.Show(string.Format("Só é permitido duplicar item ou similar quando UM É IMEDIATO e o OUTRO NÃO. Verificar item {0}.", dtgRow.Cells["colDsProd"].Value.ToString()),
                        //                        "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //        return false;
                        //    }
                        //}
                    }
                    else
                    {
                        filtro = string.Format("{0} = {1} AND {2} <> 'DIL' AND {5} IS NOT NULL AND {3} IS NOT NULL AND {3} = '{4}'",
                                                RequisicaoItensDTO.FieldNames.IdtProduto,
                                                dtgRow.Cells[colMatMedIdt.Name].Value,
                                                RequisicaoItensDTO.FieldNames.TipoPrescricaoItem,
                                                RequisicaoItensDTO.FieldNames.DataHoraAdmPaciente,
                                                dtgRow.Cells[colDataHoraDose.Name].Value,
                                                RequisicaoItensDTO.FieldNames.HorasPeriodoDose);
                        DataRow[] arrDtRowItem = dtbRequisicaoItem.Select(filtro);
                        if (arrDtRowItem.Length > 1)
                        {
                            MessageBox.Show(string.Format("Verificar item {0}, pois não podem ter itens iguais no mesmo período. Favor checar a prescrição com o médico para ajuste.", dtgRow.Cells["colDsProd"].Value.ToString()),
                                            "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        //else if (arrDtRowItem.Length == 2)
                        //{
                        //    string periodoDose = arrDtRowItem[0][RequisicaoItensDTO.FieldNames.HorasPeriodoDose].ToString();
                        //    bool primeiroUrgente = periodoDose == string.Empty ? true : false;

                        //    periodoDose = arrDtRowItem[1][RequisicaoItensDTO.FieldNames.HorasPeriodoDose].ToString();
                        //    bool segundoUrgente = periodoDose == string.Empty ? true : false;

                        //    if ((primeiroUrgente && segundoUrgente) || (!primeiroUrgente && !segundoUrgente))
                        //    {
                        //        MessageBox.Show(string.Format("Só é permitido duplicar registro quando UM É IMEDIATO e o OUTRO NÃO. Verificar item {0}.", dtgRow.Cells["colDsProd"].Value.ToString()),
                        //                        "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //        return false;
                        //    }
                        //}
                    }
                }
                if (dtgRow.Cells[colIdPrescricao.Name].Value.ToString() != string.Empty)
                {
                    if (!ValidarItemPrescricao(decimal.Parse(dtgRow.Cells[colIdPrescricao.Name].Value.ToString()),
                                               decimal.Parse(dtgRow.Cells[colMatMedIdt.Name].Value.ToString()),
                                               dtgRow.Cells[colDsProd.Name].Value.ToString(),
                                               int.Parse(dtgRow.Cells[colQtde.Name].Value.ToString()))) return false;
                }
            }

            return true;
        }

        private bool ValidarFilial()
        {
            if (!rbAcs.Checked && !rbHac.Checked)
            {
                MessageBox.Show("Selecione a Filial", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private bool ValidarSetor()
        {
            if (cmbUnidade.SelectedIndex == -1 || cmbLocal.SelectedIndex == -1 || cmbSetor.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione Unidade/Local/Setor Para Pesquisa", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private bool ValidarPaciente()
        {
            if (txtNroInternacao.Text == string.Empty || dtoAtendimento == null)
            {
                MessageBox.Show("Preencha o número do atendimento do paciente", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroInternacao.Focus();
                return false;
            }
            else if (dtoRequisicao == null)
            {
                MessageBox.Show("Pesquise o paciente", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void CarregaRequisicaoPaciente() //navega posicao)
        {
            if (ID_PrescricaoInternacao == null) dtgPersonalisado.Columns[colDeletar.Name].Visible = true;
            if (dtbRequisicao.Rows.Count > 0 && ID_PrescricaoInternacao == null)
            {
                #region AJUSTA PONTEIRO

                //switch (posicao)
                //{
                //    case navega.PRIMEIRO:
                //        Ponteiro = 0;
                //        BotoesNavegacao(navega.PRIMEIRO);
                //        break;
                //    case navega.ANTERIOR:
                //        Ponteiro--;
                //        if (Ponteiro < 0)
                //        {
                //            BotoesNavegacao(navega.PRIMEIRO);
                //            Ponteiro = 0;
                //        }
                //        break;
                //    case navega.PROXIMO:
                //        Ponteiro++;
                //        if (Ponteiro >= dtbRequisicao.Rows.Count)
                //        {
                //            BotoesNavegacao(navega.ULTIMO);
                //            Ponteiro = dtbRequisicao.Rows.Count;
                //        }
                //        break;
                //    case navega.ULTIMO:
                //        Ponteiro = dtbRequisicao.Rows.Count;
                //        BotoesNavegacao(navega.ULTIMO);
                //        break;
                //    default:
                //        break;
                //}

                #endregion

                dtoRequisicao = dtbRequisicao.TypedRow(0); //Ponteiro);
                if (!dtoRequisicao.IdKit.Value.IsNull)
                {
                    cmbKit.Visible = false;
                    cmbKit.Enabled = lblKitDsc.Visible = btnCancelarKit.Visible = true;

                    KitDTO dtoKit = new KitDTO();
                    dtoKit.IdKit.Value = dtoRequisicao.IdKit.Value;
                    lblKitDsc.Text = Kit.Listar(dtoKit).TypedRow(0).Descricao.Value;
                    grbAddMatMed.Visible = false; 
                    //ConfigurarControles(grbAddMatMed.Controls, false);
                    //dtgPersonalisado.Columns[colDeletar.Name].Visible = false;
                }
                else
                    cmbKit.Enabled = false;

                if (dtoRequisicao.Status.Value == (int)RequisicaoDTO.StatusRequisicao.ABERTA)
                {
                    cbStatus.Enabled = cbUrgente.Enabled = true;
                    cbStatus.Checked = false;
                }
                else if (dtoRequisicao.Status.Value == (int)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX)
                {
                    cbStatus.Enabled = cbUrgente.Enabled = false;
                    cbStatus.Checked = true;                    
                }
                ConfiguraRequisicaoDTO();
                cbUrgente.Checked = (byte)dtoRequisicao.Urgencia.Value == 1 ? true : false;
                txtReqIdt.Text = dtoRequisicao.Idt.Value.ToString();
                CarregaItens();
                txtData.Text = ((DateTime)dtoRequisicao.DataAtualizacao.Value).ToString("dd/MM/yyyy");
            }
            else
            {
                txtData.Text = Utilitario.ObterDataHoraServidor().Date.ToString("dd/MM/yyyy");
                txtReqIdt.Text = string.Empty;
                if (ID_PrescricaoInternacao == null)
                {
                    dtbRequisicaoItem = new RequisicaoItensDataTable();
                    dtgPersonalisado.DataSource = null;
                }
                else
                {
                    if (dtbRequisicao.Rows.Count > 0)
                    {
                        dtoRequisicao = dtbRequisicao.TypedRow(0);
                        ConfiguraRequisicaoDTO();
                        txtReqIdt.Text = dtoRequisicao.Idt.Value.ToString();
                    }

                    dtbRequisicaoItem = this.ObterItensPrescricaoInt(dtbRequisicaoItem);
                    dtgPersonalisado.DataSource = dtbRequisicaoItem;
                }
                cbStatus.Checked = true;
                if (ID_PrescricaoInternacao != null) cbStatus.Enabled = false;
            }
        }

        private void ObterPaciente()
        {
            dtoAtendimento = new HospitalAnaCosta.SGS.GestaoMateriais.DTO.PacienteDTO();
            dtoAtendimento.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoAtendimento.IdtLocalAtendimento.Value = cmbLocal.SelectedValue.ToString();
            dtoAtendimento.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            lblEU.Visible = false;
            if (this.EstoqueUnificado())//Neste método também verifica se setor pede kit
            {
                lblEU.Visible = true;
                //dtoAtendimento.TpAtendimento.Value = "U";
            }
            //else
            //    dtoAtendimento.TpAtendimento.Value = (rbInternado.Checked ? "I" : "A");

            if (rbInternado.Checked)
                dtoAtendimento.TpAtendimento.Value = "I";
            else
                dtoAtendimento.TpAtendimento.Value = "A";

            if (txtNroInternacao.Text != string.Empty)
                dtoAtendimento.Idt.Value = Convert.ToInt64(txtNroInternacao.Text);
            dtoAtendimento = gen.ObterPaciente(dtoAtendimento); 
        }
        
        private void CarregaInfoPaciente()
        {
            ObterPaciente();

            if (!dtoAtendimento.NmPaciente.Value.IsNull)
            {
                string pedidoNegado = PedidoNegado();
                if (!string.IsNullOrEmpty(pedidoNegado))
                {
                    MessageBox.Show(pedidoNegado, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtoRequisicao = null;
                    dtoPrescricao = null;
                    txtNroInternacao.Text = string.Empty;
                    if (ID_PrescricaoInternacao != null)
                        txtNroInternacao.Enabled = false;
                    else
                        txtNroInternacao.Focus();
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                FilialMatMedDTO dtoFilial = new FilialMatMedDTO();
                txtNomePac.Text = dtoAtendimento.NmPaciente.Value;
                txtNroInternacao.Text = dtoAtendimento.Idt.Value.ToString();
                txtCodConvenio.Text = dtoAtendimento.CdPlano.Value;
                //txtNomeConvenio.Text = dtoAtendimento.NmPlano.Value;
                txtNomeConvenio.Text = dtoAtendimento.DsEmpresa.Value;
                txtLocal.Text = dtoAtendimento.DsSetor.Value;
                txtQuartoLeito.Text = string.Format("{0} / {1}", dtoAtendimento.CdQuarto.ToString(), dtoAtendimento.CdLeito.ToString());
                dtoFilial.TpPlano.Value = dtoAtendimento.TpPlano.Value;

                if (FilialMatMed.ObterFilialAtendimento(dtoFilial) == FilialMatMedDTO.Filial.HAC)                
                    rbHac.Checked = true;                
                else                
                    rbAcs.Checked = true;                

                txtNroInternacao.Enabled = false;
                cmbUnidade.Enabled = false;
                cmbLocal.Enabled = false;
                cmbSetor.Enabled = false;
                dtoRequisicao = new RequisicaoDTO();

                dtoRequisicao.IdtAtendimento.Value = Convert.ToDecimal(txtNroInternacao.Text);
                dtoAtendimento.IdtLocalAtendimento.Value = cmbLocal.SelectedValue.ToString();
                dtoRequisicao.TpAtendimento = Atendimento.ObterTipoAtendimento(dtoAtendimento).TpAtendimento;
                dtoRequisicao.IdtSetor.Value = Convert.ToDecimal(cmbSetor.SelectedValue);
                if (ID_PrescricaoInternacao == null)
                    dtbRequisicao = Requisicao.RequisicaoPaciente(dtoRequisicao);
                else
                    dtbRequisicao = new RequisicaoDataTable();

                if (ID_PrescricaoInternacao != null) ConfiguraRequisicaoDTO();

                this.CarregaRequisicaoPaciente(); //navega.PRIMEIRO);

                #region Verificar se tem Pedido Automático em aberto
                RequisicaoDTO dtoReqPedidoAutoControle = new RequisicaoDTO();
                RequisicaoItensDTO dtoReqItemPedidoAutoControle = new RequisicaoItensDTO();
                
                dtoReqPedidoAutoControle.IdtAtendimento.Value = dtoRequisicao.IdtAtendimento.Value;
                dtoReqItemPedidoAutoControle.IdUsuarioPedidoAutoCancelado.Value = FrmPrincipal.dtoSeguranca.Idt.Value; //Passa o usuário para não trazer cancelados

                if (RequisicaoItens.ListarPedidoAutoControle(dtoReqItemPedidoAutoControle, dtoReqPedidoAutoControle, 2).Rows.Count > 0)
                    MessageBox.Show("AVISO: Este paciente já possui Pedidos Automáticos programados e podem haver alterações de acordo com esta prescrição.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                grbAddMatMed.Enabled = true;
                cmbMatMed.Focus();
                this.Cursor = Cursors.Default;
            }
            else
            {
                dtoRequisicao = null;
                dtoPrescricao = null;
                txtNroInternacao.Text = string.Empty;
                txtNroInternacao.Focus();
            }
        }

        private void HabilitarKitItemGrid()
        {
            dtgPersonalisado.Columns[colKitAssociado.Name].Visible = false;
            if (cmbSetor.SelectedValue == null) return;
            dtgPersonalisado.Columns[colKitAssociado.Name].Visible = true;
        }

        private string PedidoNegado()
        {
            if (dtoAtendimento.NmPaciente.Value.IsNull)            
                return "Pedido negado, paciente não se encontra neste setor.";
            
            if (gen.UtiCompartilhada(int.Parse(cmbSetor.SelectedValue.ToString())) &&
                !dtoAtendimento.HrTransf.Value.IsNull)
            {
                if (!dtoAtendimento.DtTransf.Value.IsNull)
                {
                    string strDtTransf = dtoAtendimento.DtTransf.Value.ToString().Replace("00:00:00", dtoAtendimento.HrTransf.Value.ToString().PadLeft(4, '0').Insert(2, ":"));
                    DateTime dtTransf = DateTime.Parse(strDtTransf);
                    if (Utilitario.ObterDataHoraServidor() > dtTransf.AddHours(6))
                        return "Pedido negado, paciente já saiu deste setor há mais de 6 horas.";
                }
            }
            else if (!dtoAtendimento.DataAtendimento.Value.IsNull && !dtoAtendimento.HrTransf.Value.IsNull && 
                     (cmbLocal.SelectedValue.ToString() != "29" || cmbSetor.SelectedValue.ToString() == CENTRO_CIRURGICO.ToString()) &&
                     cmbSetor.SelectedValue.ToString() != "114" && cmbSetor.SelectedValue.ToString() != "159") //Se não for HEMODIALISE E QUIMIOTERAPIA, liberar apenas 24 após atendimento
            {
                //DateTime dtAtd = DateTime.Parse(dtoAtendimento.DataAtendimento.Value.ToString());
                string strDtAtd = dtoAtendimento.DataAtendimento.Value.ToString().Replace("00:00:00", dtoAtendimento.HrTransf.Value.ToString().PadLeft(4, '0').Insert(2, ":"));
                DateTime dtAtd = DateTime.Parse(strDtAtd);
                if (Utilitario.ObterDataHoraServidor() > dtAtd.AddHours(24))
                    return "Pedido negado, paciente com data de atendimento superior a 24 horas.";
            }
            else if (cmbLocal.SelectedValue.ToString() == "29" && //INTERNADO
                     (!dtoAtendimento.DtAlta.Value.IsNull || !dtoAtendimento.DtTransf.Value.IsNull))
            {
                return "Pedido negado, paciente com alta ou transferido deste setor.";
            }

            return string.Empty;
        }

        //private void BotoesNavegacao(navega posicao)
        //{
        //    switch (posicao)
        //    {
        //        //case navega.PRIMEIRO:
        //        //    btnAnterior.Enabled = false;
        //        //    btnInicio.Enabled = false;
        //        //    btnProximo.Enabled = true;
        //        //    btnUltimo.Enabled = true;
        //        //    break;
        //        //case navega.ULTIMO:
        //        //    btnAnterior.Enabled = true;
        //        //    btnInicio.Enabled = true;
        //        //    btnProximo.Enabled = false;
        //        //    btnUltimo.Enabled = false;
        //        //    break;
        //        default:
        //            break;
        //    }
        //}

        private void CarregaItens()
        {
            dtoRequisicaoItem = new RequisicaoItensDTO();
            dtoRequisicaoItem.Idt.Value = dtoRequisicao.Idt.Value;
            dtgPersonalisado.DataSource = null;
            dtbRequisicaoItem = RequisicaoItens.SelItensRequisicao(dtoRequisicaoItem, true);
            dtgPersonalisado.DataSource = dtbRequisicaoItem;
            tsbPrescricoes.Visible = tsbImprimirPrescricao.Visible = cbAntimicrobianos.Checked = cbAntimicrobianos.Enabled = false;
            if (dtbRequisicaoItem.Rows.Count > 0)
            {
                if (dtbRequisicaoItem.TypedRow(0).IdPrescricao.Value.ToString() != string.Empty)
                    tsbPrescricoes.Visible = tsbImprimirPrescricao.Visible = cbAntimicrobianos.Checked = true;
            }
            else if (dtbRequisicaoItem.Rows.Count == 0)
                cbAntimicrobianos.Enabled = true;
        }

        private void ConfiguraDTG()
        {
            dtgPersonalisado.AutoGenerateColumns = false;
            dtgPersonalisado.Columns["colReqItemIdt"].DataPropertyName = RequisicaoItensDTO.FieldNames.Idt;
            dtgPersonalisado.Columns["colMatMedIdt"].DataPropertyName = RequisicaoItensDTO.FieldNames.IdtProduto;
            dtgPersonalisado.Columns["colDsProd"].DataPropertyName = RequisicaoItensDTO.FieldNames.DsProduto;
            dtgPersonalisado.Columns["colDsUnidadeVenda"].DataPropertyName = RequisicaoItensDTO.FieldNames.DsUnidadeVenda;
            dtgPersonalisado.Columns["colQtde"].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdFornecida;            
            dtgPersonalisado.Columns["colQtde"].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdSolicitada;
            dtgPersonalisado.Columns["colQtdeFornecida"].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdFornecida;
            dtgPersonalisado.Columns["colEstoqueLocal"].DataPropertyName = RequisicaoItensDTO.FieldNames.EstoqueLocalQtde;
            dtgPersonalisado.Columns["colMatMedPrincAt"].DataPropertyName = RequisicaoItensDTO.FieldNames.IdtPrincipioAtivo;
            dtgPersonalisado.Columns["colIdPrescricao"].DataPropertyName = RequisicaoItensDTO.FieldNames.IdPrescricao;
            dtgPersonalisado.Columns[colMAV.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia;
            dtgPersonalisado.Columns[colKitItemID.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.IdKitItem;
            dtgPersonalisado.Columns[colKitAssociado.Name].DataPropertyName = "CAD_MTMD_KIT_DSC_ITEM"; //KitDTO.FieldNames.Descricao;
            dtgPersonalisado.Columns[colQtdKitItemMultiplica.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdKitItemMultiplica;
            dtgPersonalisado.Columns[colPeriodoDose.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.HorasPeriodoDose;
            dtgPersonalisado.Columns[colDataHoraDose.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.DataHoraAdmPaciente;
            dtgPersonalisado.Columns[colDataHoraDose.Name].DefaultCellStyle.Format = "dd/MM HH:mm";
            dtgPersonalisado.Columns[colQtdDoseAdm.Name].DataPropertyName = "DOSE_ADM";
            dtgPersonalisado.Columns[colIdSubgrupo.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.IdtSubGrupo;
            dtgPersonalisado.Columns[colIdPrescricaoItemInternacao.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.IdPrescricaoItemInternacao;
            dtgPersonalisado.Columns[colObs.Name].DataPropertyName = "DS_OBSERVACAO";
            dtgPersonalisado.Columns[colItemGeladeira.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.FlItemGeladeira;
        }

        private void ConfiguraEstoqueDTO()
        {
            dtoEstoque = new EstoqueLocalDTO();

            dtoEstoque.IdtUnidade.Value = dtoRequisicao.IdtUnidade.Value;
            dtoEstoque.IdtLocal.Value = dtoRequisicao.IdtLocal.Value;
            dtoEstoque.IdtSetor.Value = dtoRequisicao.IdtSetor.Value;
            dtoEstoque.IdtProduto.Value = dtoRequisicaoItem.IdtProduto.Value;
            dtoEstoque.IdtLote.Value = null;
            if (lblEU.Visible)
            {
                dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            }
            else
            {
                if (rbHac.Checked)                
                    dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;                
                else if (rbAcs.Checked)                
                    dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;                
            }             
        }

        private bool GerarPedidoAutomaticoSetor()
        {
            if (SetorPedidoAutomaticoVigencia && (CairNaFarmacia() || gen.UtiGeralCardio(int.Parse(dtoRequisicao.IdtSetor.Value))))
                return true;

            return false;
        }

        //Cair na Farmácia quando pedido for feito pela mesma ou por AMB/PS
        private bool CairNaFarmacia()
        {
            return true; //Ajuste realizado em 23/11/2020 para materiais também começar a cair na Farmácia

            if (((int)FrmPrincipal.dtoSeguranca.IdtLocal.Value != 29 || gen.LogadoSetorFarmacia()))
                return true;

            return false;
        }

        private bool Salvar()
        {
            try
            {
                if (!Validar()) return false;
                // status: 0=FECHADA 1=ABERTA 2=ATENDIDA PELO ALMOX 3=CANCELADA
                if (txtNroInternacao.Text.Length != 0)
                {
                    if (dtbRequisicaoItem.Rows.Count != 0)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        if (gen.LogadoSetorFarmacia())
                        {
                            SetorDTO dtoSetFarm;
                            MovimentacaoDTO dtoMovCentroDisp = new MovimentacaoDTO();
                            dtoMovCentroDisp.IdtSetor.Value = dtoRequisicao.IdtSetor.Value;
                            dtoMovCentroDisp = Movimento.CentroDispensacao(dtoMovCentroDisp, out dtoSetFarm);
                            if (!dtoMovCentroDisp.IdtSetorBaixa.Value.IsNull && (decimal)dtoMovCentroDisp.IdtSetorBaixa.Value == UTI_ALMOX_SATELITE)
                            {   //Provisoriamente, quando estiver logado na Farmacia Central e for pedido da Satélite UTI, enviar itens pela Farmácia Central
                                dtoRequisicao.SetorFarmacia.Value = FrmPrincipal.dtoSeguranca.IdtSetor.Value;
                            }
                        }
                        else if ((int)FrmPrincipal.dtoSeguranca.IdtSetor.Value == CENTRO_CIRURGICO &&
                                 int.Parse(dtoRequisicao.IdtSetor.Value) == CENTRO_CIRURGICO)
                        {
                            dtoRequisicao.SetorFarmacia.Value = CENTRO_CIRURGICO;
                        }

                        if (dtoRequisicao.SetorFarmacia.Value.IsNull && int.Parse(dtoRequisicao.IdtSetor.Value) != CENTRO_CIRURGICO &&
                            CairNaFarmacia() || (gen.UtiGeralCardio(int.Parse(dtoRequisicao.IdtSetor.Value)) && !gen.UtiCompartilhada(int.Parse(dtoRequisicao.IdtSetor.Value))) ||
                            int.Parse(dtoRequisicao.IdtSetor.Value) == UTI_EDA_GERAL)
                        {
                            int? idSetorFarmacia = gen.ObterFarmaciaSetor((int)dtoRequisicao.IdtSetor.Value);
                            if (idSetorFarmacia != null)
                            {
                                dtoRequisicao.SetorFarmacia.Value = idSetorFarmacia;
                            }
                        }

                        bool totalImediatoPrescricaoInternacao = false;
                        if (ID_PrescricaoInternacao != null)
                        {
                            if (_ultrapassouCorte)
                            {
                                for (int nCount = 0; nCount < dtbRequisicaoItem.Rows.Count; nCount++)
                                {
                                    if (dtbRequisicaoItem.TypedRow(nCount).QtdSolicitada.Value > 0)
                                    {
                                        MessageBox.Show("PRESCRIÇÃO DO DIA ANTERIOR QUE ULTRAPASSOU O LIMITE DE TEMPO PARA CONFIRMAÇÂO DO PEDIDO E DEVE TER TODOS OS ITENS CANCELADOS.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.Cursor = Cursors.Default;
                                        return false;
                                    }
                                }
                            }
                            ObterPaciente();
                            string pedidoNegado = PedidoNegado();
                            if (!string.IsNullOrEmpty(pedidoNegado))
                            {
                                MessageBox.Show(pedidoNegado, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Cursor = Cursors.Default;
                                return false;

                            }
                            RequisicaoDTO dtoPedidoVerificar = new RequisicaoDTO();
                            dtoPedidoVerificar.IdtSetor.Value = dtoRequisicao.IdtSetor.Value;
                            RequisicaoItensDataTable dtbReqItem = RequisicaoItens.ListarItensPrescricaoInt(dtoPedidoVerificar, ID_PrescricaoInternacao.Value, "PE");
                            if (dtbReqItem.Rows.Count == 0)
                            {
                                MessageBox.Show("Prescrição já confirmada por outro processo!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.Cursor = Cursors.Default;
                                return false;
                            }                            

                            //Cancelar itens suspensos do Paciente
                            RequisicaoDTO dtoReqPedidoAutoControle; RequisicaoItensDTO dtoReqItemPedidoAutoControle;
                            RequisicaoDTO dtoPedido = new RequisicaoDTO();
                            dtoPedido.IdtSetor.Value = dtoRequisicao.IdtSetor.Value;
                            dtoPedido.IdtAtendimento.Value = txtNroInternacao.Text;
                            dtoPedido.DataRequisicao.Value = Utilitario.ObterDataHoraServidor().AddDays(-3);
                            dtoPedido.DataRequisicao2.Value = Utilitario.ObterDataHoraServidor().AddMinutes(2);
                            RequisicaoItensDataTable dtbReqItemVerifica = RequisicaoItens.ListarItensPrescricaoInt(dtoPedido, null, null);
                            foreach (DataRow row in dtbReqItemVerifica.Rows)
                            {
                                if (!string.IsNullOrEmpty(row[RequisicaoItensDTO.FieldNames.StatusPrescricaoItem].ToString()))
                                {
                                    string status = row[RequisicaoItensDTO.FieldNames.StatusPrescricaoItem].ToString();
                                    if (status == "SU" || status == "PE") //Suspenso / Pendente
                                    {
                                        //Verificar se tem Pedido Automático programado do item e cancelar
                                        dtoReqPedidoAutoControle = new RequisicaoDTO();
                                        dtoReqItemPedidoAutoControle = new RequisicaoItensDTO();

                                        dtoReqPedidoAutoControle.IdtAtendimento.Value = dtoPedido.IdtAtendimento.Value;
                                        dtoReqItemPedidoAutoControle.IdUsuarioPedidoAutoCancelado.Value = FrmPrincipal.dtoSeguranca.Idt.Value; //Passa o usuário para não trazer cancelados
                                        dtoReqItemPedidoAutoControle.IdPrescricaoItemInternacao.Value = row[RequisicaoItensDTO.FieldNames.IdPrescricaoItemInternacao].ToString();                                        

                                        RequisicaoItensDataTable dtbItemProgramado = RequisicaoItens.ListarPedidoAutoControle(dtoReqItemPedidoAutoControle, dtoReqPedidoAutoControle, 4);
                                        if (dtbItemProgramado.Rows.Count > 0)
                                            RequisicaoItens.CancelarProgramacaoItensPrescricao(dtbItemProgramado);                                        
                                    }
                                }
                            }

                            RequisicaoDTO dtoReqParamSetor = new RequisicaoDTO();
                            dtoReqParamSetor.IdtSetor.Value = int.Parse(cmbSetor.SelectedValue.ToString());
                            dtoReqParamSetor = gen.ObterSetorPedidoAutomaticoVigencia(dtoReqParamSetor);
                            if (dtoReqParamSetor.SetorPedidoAutoFlTotalImediato.Value.IsNull) dtoReqParamSetor.SetorPedidoAutoFlTotalImediato.Value = 0;                            

                            if (dtoReqParamSetor.SetorPedidoAutoFlTotalImediato.Value == 0)
                            {
                                #region Gerar MEDICAMENTOS separados quando houver duplicados em horários diferentes (tirando imediato)

                                DataRow[] rowsMed = dtbRequisicaoItem.Select(RequisicaoItensDTO.FieldNames.TipoPrescricaoItem + " <> 'DIL'");
                                if (rowsMed.Length > 0)
                                {
                                    string filtroMed;
                                    DataRow[] rowsItemMed;
                                    for (int nCount = 0; nCount < rowsMed.Length; nCount++)
                                    {
                                        filtroMed = string.Format("{0} = {1} AND {2} <> 'DIL' AND {3} IS NOT NULL",
                                                                    MaterialMedicamentoDTO.FieldNames.Idt,
                                                                    rowsMed[nCount][MaterialMedicamentoDTO.FieldNames.Idt].ToString(),
                                                                    RequisicaoItensDTO.FieldNames.TipoPrescricaoItem,
                                                                    RequisicaoItensDTO.FieldNames.HorasPeriodoDose);
                                        rowsItemMed = dtbRequisicaoItem.Select(filtroMed);
                                        if (rowsItemMed.Length > 1)
                                        {
                                            RequisicaoDTO dtoPedidoMedSeparado = null;
                                            RequisicaoItensDataTable dtbItemMedSeparado = null;
                                            for (int nCountItem = 0; nCountItem < rowsItemMed.Length; nCountItem++)
                                            {
                                                if (rowsItemMed[nCountItem]["FL_ITEM_KIT_ADICIONADO"].ToString() != "1")
                                                {
                                                    if (int.Parse(rowsItemMed[nCountItem][RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString()) == 0) continue;

                                                    dtoPedidoMedSeparado = new RequisicaoDTO(); dtbItemMedSeparado = new RequisicaoItensDataTable();
                                                    dtoPedidoMedSeparado.IdtAtendimento.Value = txtNroInternacao.Text;
                                                    if (dtoAtendimento != null) dtoPedidoMedSeparado.TpAtendimento = Atendimento.ObterTipoAtendimento(dtoAtendimento).TpAtendimento;
                                                    dtoPedidoMedSeparado.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                                                    dtoPedidoMedSeparado.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                                                    dtoPedidoMedSeparado.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                                                    dtoPedidoMedSeparado.Urgencia.Value = 0;
                                                    dtoPedidoMedSeparado.Status.Value = (int)(cbStatus.Checked ? RequisicaoDTO.StatusRequisicao.FECHADA : RequisicaoDTO.StatusRequisicao.ABERTA);
                                                    dtoPedidoMedSeparado.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                                                    dtoPedidoMedSeparado.IdtTipoRequisicao.Value = (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO;                                                    
                                                    if (!dtoRequisicao.SetorFarmacia.Value.IsNull)
                                                        dtoPedidoMedSeparado.SetorFarmacia.Value = dtoRequisicao.SetorFarmacia.Value;
                                                    dtoPedidoMedSeparado.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                                                    dtbItemMedSeparado.Add((RequisicaoItensDTO)rowsItemMed[nCountItem]);

                                                    dtoPedidoMedSeparado = Requisicao.Gravar(dtoPedidoMedSeparado, dtbItemMedSeparado);

                                                    rowsItemMed[nCountItem][RequisicaoItensDTO.FieldNames.QtdSolicitada] = 0;
                                                }
                                            }
                                        }
                                    }
                                }

                                #endregion

                                #region Gerar DILUENTES separados quando houver duplicados

                                DataRow[] rowsDiluentes = dtbRequisicaoItem.Select(RequisicaoItensDTO.FieldNames.TipoPrescricaoItem + " = 'DIL'");
                                if (rowsDiluentes.Length > 0)
                                {
                                    for (int nCount = 0; nCount < rowsDiluentes.Length; nCount++)
                                    {
                                        DataRow[] rowsItemDiluente = dtbRequisicaoItem.Select(string.Format("{0} = {1} AND {2} = 'DIL'", MaterialMedicamentoDTO.FieldNames.Idt, rowsDiluentes[nCount][MaterialMedicamentoDTO.FieldNames.Idt].ToString(), RequisicaoItensDTO.FieldNames.TipoPrescricaoItem));
                                        if (rowsItemDiluente.Length > 1)
                                        {
                                            RequisicaoDTO dtoPedidoDiluente = null;
                                            RequisicaoItensDataTable dtbItemDiluente = null;
                                            for (int nCountDilItem = 0; nCountDilItem < rowsItemDiluente.Length; nCountDilItem++)
                                            {
                                                if (int.Parse(rowsItemDiluente[nCountDilItem][RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString()) == 0) continue;

                                                dtoPedidoDiluente = new RequisicaoDTO(); dtbItemDiluente = new RequisicaoItensDataTable();
                                                dtoPedidoDiluente.IdtAtendimento.Value = txtNroInternacao.Text;
                                                if (dtoAtendimento != null) dtoPedidoDiluente.TpAtendimento = Atendimento.ObterTipoAtendimento(dtoAtendimento).TpAtendimento;
                                                dtoPedidoDiluente.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                                                dtoPedidoDiluente.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                                                dtoPedidoDiluente.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                                                if (rowsItemDiluente[nCountDilItem][RequisicaoItensDTO.FieldNames.HorasPeriodoDose].ToString() == string.Empty)
                                                    dtoPedidoDiluente.Urgencia.Value = 1;
                                                else
                                                    dtoPedidoDiluente.Urgencia.Value = 0;
                                                dtoPedidoDiluente.Status.Value = (int)(cbStatus.Checked ? RequisicaoDTO.StatusRequisicao.FECHADA : RequisicaoDTO.StatusRequisicao.ABERTA);
                                                dtoPedidoDiluente.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                                                dtoPedidoDiluente.IdtTipoRequisicao.Value = (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO;
                                                if (!dtoRequisicao.SetorFarmacia.Value.IsNull)
                                                    dtoPedidoDiluente.SetorFarmacia.Value = dtoRequisicao.SetorFarmacia.Value;
                                                dtoPedidoDiluente.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                                                dtbItemDiluente.Add((RequisicaoItensDTO)rowsItemDiluente[nCountDilItem]);

                                                dtoPedidoDiluente = Requisicao.Gravar(dtoPedidoDiluente, dtbItemDiluente);

                                                rowsItemDiluente[nCountDilItem][RequisicaoItensDTO.FieldNames.QtdSolicitada] = 0;
                                            }
                                        }
                                    }
                                }

                                #endregion

                                #region Varrer itens IMEDIATOS e já gerar Pedido

                                RequisicaoDTO dtoPedidoUrgente = null;
                                RequisicaoItensDTO dtoItemUrgente = null;
                                RequisicaoItensDataTable dtbItensUrgentes = null;
                                for (int nCount = 0; nCount < dtbRequisicaoItem.Rows.Count; nCount++)
                                {
                                    if (dtbRequisicaoItem.Rows[nCount][RequisicaoItensDTO.FieldNames.HorasPeriodoDose].ToString() == string.Empty &&
                                        dtbRequisicaoItem.Rows[nCount]["FL_ITEM_KIT_ADICIONADO"].ToString() != "1")
                                    {
                                        dtoItemUrgente = dtbRequisicaoItem.TypedRow(nCount);
                                        if (dtoItemUrgente.QtdSolicitada.Value > 0 || !dtoItemUrgente.JustificativaCancelamento.Value.IsNull)
                                        {
                                            if (dtoPedidoUrgente == null)
                                            {
                                                dtoPedidoUrgente = new RequisicaoDTO(); dtbItensUrgentes = new RequisicaoItensDataTable();
                                                dtoPedidoUrgente.IdtAtendimento.Value = txtNroInternacao.Text;
                                                if (dtoAtendimento != null) dtoPedidoUrgente.TpAtendimento = Atendimento.ObterTipoAtendimento(dtoAtendimento).TpAtendimento;
                                                dtoPedidoUrgente.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                                                dtoPedidoUrgente.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                                                dtoPedidoUrgente.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                                                dtoPedidoUrgente.Urgencia.Value = 1;
                                                dtoPedidoUrgente.Status.Value = (int)(cbStatus.Checked ? RequisicaoDTO.StatusRequisicao.FECHADA : RequisicaoDTO.StatusRequisicao.ABERTA);
                                                dtoPedidoUrgente.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                                                dtoPedidoUrgente.IdtTipoRequisicao.Value = (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO;
                                                if (!dtoRequisicao.SetorFarmacia.Value.IsNull)
                                                    dtoPedidoUrgente.SetorFarmacia.Value = dtoRequisicao.SetorFarmacia.Value;
                                                dtoPedidoUrgente.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                                            }

                                            dtbItensUrgentes.Add(dtoItemUrgente);
                                            dtbRequisicaoItem.Rows[nCount][RequisicaoItensDTO.FieldNames.QtdSolicitada] = 0;
                                        }
                                    }
                                }
                                if (dtoPedidoUrgente != null && dtbItensUrgentes != null && dtbItensUrgentes.Rows.Count > 0)
                                {
                                    dtoPedidoUrgente = Requisicao.Gravar(dtoPedidoUrgente, dtbItensUrgentes);
                                    //Verificar se tem algum kit vinculado aos imediatos e inserir
                                    for (int nCount = 0; nCount < dtbItensUrgentes.Rows.Count; nCount++)
                                    {
                                        dtoItemUrgente = dtbItensUrgentes.TypedRow(nCount);
                                        dtoItemUrgente.Idt.Value = dtoPedidoUrgente.Idt.Value;
                                        if (!string.IsNullOrEmpty(dtoItemUrgente.IdKitItem.Value.ToString()))
                                            RequisicaoItens.InserirItensKitPedido(dtoItemUrgente);
                                    }
                                }

                                #endregion

                                #region Gerar ANTIMICROBIANOS RESTRITOS separados

                                DataRow[] rowsAntimicro = dtbRequisicaoItem.Select(string.Format("{0} IN ({1})", MaterialMedicamentoDTO.FieldNames.IdtSubGrupo, ANTIMICROBIANOS_RESTRITOS));
                                if (rowsAntimicro.Length > 0)
                                {
                                    RequisicaoDTO dtoPedidoAntimicro = null;
                                    RequisicaoItensDTO dtoItemAntimicro = null;
                                    RequisicaoItensDataTable dtbItensAntimicro = null;
                                    for (int nCount = 0; nCount < rowsAntimicro.Length; nCount++)
                                    {
                                        if (rowsAntimicro[nCount][RequisicaoItensDTO.FieldNames.HorasPeriodoDose].ToString() != string.Empty &&
                                            rowsAntimicro[nCount]["FL_ITEM_KIT_ADICIONADO"].ToString() != "1")
                                        {
                                            dtoItemAntimicro = (RequisicaoItensDTO)rowsAntimicro[nCount];
                                            if (dtoItemAntimicro.QtdSolicitada.Value > 0 && dtoItemAntimicro.JustificativaCancelamento.Value.IsNull)
                                            {
                                                if (dtoPedidoAntimicro == null)
                                                {
                                                    dtoPedidoAntimicro = new RequisicaoDTO(); dtbItensAntimicro = new RequisicaoItensDataTable();
                                                    dtoPedidoAntimicro.IdtAtendimento.Value = txtNroInternacao.Text;
                                                    if (dtoAtendimento != null) dtoPedidoAntimicro.TpAtendimento = Atendimento.ObterTipoAtendimento(dtoAtendimento).TpAtendimento;
                                                    dtoPedidoAntimicro.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                                                    dtoPedidoAntimicro.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                                                    dtoPedidoAntimicro.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                                                    dtoPedidoAntimicro.Urgencia.Value = 0;
                                                    dtoPedidoAntimicro.Status.Value = (int)(cbStatus.Checked ? RequisicaoDTO.StatusRequisicao.FECHADA : RequisicaoDTO.StatusRequisicao.ABERTA);
                                                    dtoPedidoAntimicro.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                                                    dtoPedidoAntimicro.IdtTipoRequisicao.Value = (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO;
                                                    if (!dtoRequisicao.SetorFarmacia.Value.IsNull)
                                                        dtoPedidoAntimicro.SetorFarmacia.Value = dtoRequisicao.SetorFarmacia.Value;
                                                    dtoPedidoAntimicro.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                                                }

                                                dtbItensAntimicro.Add(dtoItemAntimicro);
                                                rowsAntimicro[nCount][RequisicaoItensDTO.FieldNames.QtdSolicitada] = 0;
                                            }
                                        }
                                    }
                                    if (dtoPedidoAntimicro != null && dtbItensAntimicro != null && dtbItensAntimicro.Rows.Count > 0)
                                    {
                                        dtoPedidoAntimicro = Requisicao.Gravar(dtoPedidoAntimicro, dtbItensAntimicro);
                                    }
                                }

                                #endregion

                                #region Gerar PSICOTROPICOS separados

                                DataRow[] rowsPsico = dtbRequisicaoItem.Select(string.Format("{0} IN ({1},{2})", MaterialMedicamentoDTO.FieldNames.IdtSubGrupo, PSICOTROPICO1, PSICOTROPICO2));
                                if (rowsPsico.Length > 0)
                                {
                                    RequisicaoDTO dtoPedidoPsico = null;
                                    RequisicaoItensDTO dtoItemPsico = null;
                                    RequisicaoItensDataTable dtbItensPsico = null;
                                    for (int nCount = 0; nCount < rowsPsico.Length; nCount++)
                                    {
                                        if (rowsPsico[nCount][RequisicaoItensDTO.FieldNames.HorasPeriodoDose].ToString() != string.Empty &&
                                            rowsPsico[nCount]["FL_ITEM_KIT_ADICIONADO"].ToString() != "1")
                                        {
                                            dtoItemPsico = (RequisicaoItensDTO)rowsPsico[nCount];
                                            if (dtoItemPsico.QtdSolicitada.Value > 0 && dtoItemPsico.JustificativaCancelamento.Value.IsNull)
                                            {
                                                if (dtoPedidoPsico == null)
                                                {
                                                    dtoPedidoPsico = new RequisicaoDTO(); dtbItensPsico = new RequisicaoItensDataTable();
                                                    dtoPedidoPsico.IdtAtendimento.Value = txtNroInternacao.Text;
                                                    if (dtoAtendimento != null) dtoPedidoPsico.TpAtendimento = Atendimento.ObterTipoAtendimento(dtoAtendimento).TpAtendimento;
                                                    dtoPedidoPsico.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                                                    dtoPedidoPsico.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                                                    dtoPedidoPsico.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                                                    dtoPedidoPsico.Urgencia.Value = 0;
                                                    dtoPedidoPsico.Status.Value = (int)(cbStatus.Checked ? RequisicaoDTO.StatusRequisicao.FECHADA : RequisicaoDTO.StatusRequisicao.ABERTA);
                                                    dtoPedidoPsico.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                                                    dtoPedidoPsico.IdtTipoRequisicao.Value = (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO;
                                                    if (!dtoRequisicao.SetorFarmacia.Value.IsNull)
                                                        dtoPedidoPsico.SetorFarmacia.Value = dtoRequisicao.SetorFarmacia.Value;
                                                    dtoPedidoPsico.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;                                                    
                                                }

                                                dtbItensPsico.Add(dtoItemPsico);
                                                rowsPsico[nCount][RequisicaoItensDTO.FieldNames.QtdSolicitada] = 0;
                                            }
                                        }
                                    }
                                    if (dtoPedidoPsico != null && dtbItensPsico != null && dtbItensPsico.Rows.Count > 0)
                                    {
                                        dtoPedidoPsico = Requisicao.Gravar(dtoPedidoPsico, dtbItensPsico);
                                    }
                                }

                                #endregion

                                #region Gerar Itens de Geladeira separados

                                DataRow[] rowsGelad = dtbRequisicaoItem.Select(string.Format("{0} = 1", RequisicaoItensDTO.FieldNames.FlItemGeladeira));
                                if (rowsGelad.Length > 0)
                                {
                                    RequisicaoDTO dtoPedidoGelad = null;
                                    RequisicaoItensDTO dtoItemGelad = null;
                                    RequisicaoItensDataTable dtbItensGelad = null;
                                    for (int nCount = 0; nCount < rowsGelad.Length; nCount++)
                                    {
                                        if (rowsGelad[nCount][RequisicaoItensDTO.FieldNames.HorasPeriodoDose].ToString() != string.Empty &&
                                            rowsGelad[nCount]["FL_ITEM_KIT_ADICIONADO"].ToString() != "1")
                                        {
                                            dtoItemGelad = (RequisicaoItensDTO)rowsGelad[nCount];
                                            if (dtoItemGelad.QtdSolicitada.Value > 0 && dtoItemGelad.JustificativaCancelamento.Value.IsNull)
                                            {
                                                if (dtoPedidoGelad == null)
                                                {
                                                    dtoPedidoGelad = new RequisicaoDTO(); dtbItensGelad = new RequisicaoItensDataTable();
                                                    dtoPedidoGelad.IdtAtendimento.Value = txtNroInternacao.Text;
                                                    if (dtoAtendimento != null) dtoPedidoGelad.TpAtendimento = Atendimento.ObterTipoAtendimento(dtoAtendimento).TpAtendimento;
                                                    dtoPedidoGelad.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                                                    dtoPedidoGelad.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                                                    dtoPedidoGelad.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                                                    dtoPedidoGelad.Urgencia.Value = 0;
                                                    dtoPedidoGelad.Status.Value = (int)(cbStatus.Checked ? RequisicaoDTO.StatusRequisicao.FECHADA : RequisicaoDTO.StatusRequisicao.ABERTA);
                                                    dtoPedidoGelad.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                                                    dtoPedidoGelad.IdtTipoRequisicao.Value = (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO;
                                                    if (!dtoRequisicao.SetorFarmacia.Value.IsNull)
                                                        dtoPedidoGelad.SetorFarmacia.Value = dtoRequisicao.SetorFarmacia.Value;
                                                    dtoPedidoGelad.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                                                }

                                                dtbItensGelad.Add(dtoItemGelad);
                                                rowsGelad[nCount][RequisicaoItensDTO.FieldNames.QtdSolicitada] = 0;
                                            }
                                        }
                                    }
                                    if (dtoPedidoGelad != null && dtbItensGelad != null && dtbItensGelad.Rows.Count > 0)
                                    {
                                        dtoPedidoGelad = Requisicao.Gravar(dtoPedidoGelad, dtbItensGelad);
                                    }
                                }

                                #endregion
                            }

                            #region Atualizar diretamente qtd. total de IMEDIATOS quando setor parametrizado

                            if (dtoReqParamSetor.SetorPedidoAutoFlTotalImediato.Value == 1)
                            {
                                if (dtoReqParamSetor.IdtSetor.Value != 22 ||
                                    (dtoReqParamSetor.IdtSetor.Value == 22 && !cbUrgente.Checked)) //22 = Admissao
                                {
                                    totalImediatoPrescricaoInternacao = true;
                                    dtoRequisicao.Urgencia.Value = 1;
                                    RequisicaoItensDTO dtoItemTotalImed = null;
                                    DateTime dataInicioAdm, dataCorteDiaSeguinte;
                                    int qtdPedidoTotalGerarItem = 0; int qtdHorasTotalGerar = 0;
                                    for (int nCount = 0; nCount < dtbRequisicaoItem.Rows.Count; nCount++)
                                    {
                                        dtoItemTotalImed = (RequisicaoItensDTO)dtbRequisicaoItem.Rows[nCount];
                                        if (dtoItemTotalImed.QtdSolicitada.Value > 0 && dtoItemTotalImed.JustificativaCancelamento.Value.IsNull)
                                        {
                                            if (dtbRequisicaoItem.Rows[nCount]["FL_ITEM_KIT_ADICIONADO"].ToString() != "1")
                                            {
                                                if (!dtoItemTotalImed.DataHoraAdmPaciente.Value.IsNull)
                                                    dataInicioAdm = DateTime.Parse(dtoItemTotalImed.DataHoraAdmPaciente.Value.ToString());
                                                else
                                                    dataInicioAdm = DateTime.Parse(Utilitario.ObterDataHoraServidor().AddHours(1).ToString("dd/MM/yyyy HH:00"));

                                                //dataCorteDiaSeguinte = DateTime.Parse(dataInicioAdm.AddDays(1).Date.ToString("dd/MM/yyyy") + " " + ((int)dtoReqParamSetor.SetorPedidoAutoHoraInicioProcesso.Value).ToString().PadLeft(2, '0') + ":00").AddHours(-(int)dtoReqParamSetor.SetorPedidoAutoHorasMinimaIniciar.Value);
                                                dataCorteDiaSeguinte = DateTime.Parse(dataInicioAdm.AddDays(1).Date.ToString("dd/MM/yyyy") + " " + ((int)dtoReqParamSetor.SetorPedidoAutoHoraInicioProcesso.Value).ToString().PadLeft(2, '0') + ":00").AddHours(-1);
                                                qtdHorasTotalGerar = (int)dataCorteDiaSeguinte.Subtract(dataInicioAdm).TotalHours;

                                                if (dtoItemTotalImed.HorasPeriodoDose.Value.IsNull) dtoItemTotalImed.HorasPeriodoDose.Value = 24;

                                                qtdPedidoTotalGerarItem = RequisicaoItens.ObterQtdPedidoTotalGerarItem(qtdHorasTotalGerar,
                                                                                                                       (int)dtoItemTotalImed.HorasPeriodoDose.Value,
                                                                                                                       (int)dtoItemTotalImed.QtdSolicitada.Value);
                                            }
                                            else
                                                qtdPedidoTotalGerarItem = (int)dtoItemTotalImed.QtdSolicitada.Value;

                                            dtbRequisicaoItem.Rows[nCount][RequisicaoItensDTO.FieldNames.QtdSolicitada] = qtdPedidoTotalGerarItem;
                                        }
                                    }
                                }
                            }

                            #endregion
                        }

                        if (!totalImediatoPrescricaoInternacao || dtoRequisicao.Urgencia.Value.IsNull)
                            dtoRequisicao.Urgencia.Value = (int)(cbUrgente.Checked ? 1 : 0);

                        dtoRequisicao.Status.Value = (int)(cbStatus.Checked ? RequisicaoDTO.StatusRequisicao.FECHADA : RequisicaoDTO.StatusRequisicao.ABERTA);

                        if (lblEU.Visible)
                        {
                            dtoRequisicao.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                        }
                        else
                        {
                            if (rbHac.Checked)                         
                                dtoRequisicao.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                            else if (rbAcs.Checked)                         
                                dtoRequisicao.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;                         
                        }
                        dtoRequisicao.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                        if (cmbKit.Visible && cmbKit.SelectedIndex > -1)
                            dtoRequisicao.IdKit.Value = cmbKit.SelectedValue.ToString();                        

                        //Retirar Periodo Dose caso haja (vindo da Prescrição da Internação), para não gerar Pedido Automático ou caso seja item de kit
                        foreach (DataRow row in dtbRequisicaoItem.Rows)
                        {
                            if (row.RowState != DataRowState.Deleted)
                            {
                                if (!SetorPedidoAutomaticoVigencia || (ID_PrescricaoInternacao != null && string.IsNullOrEmpty(row["DOSE_ADM"].ToString())))
                                {
                                    if (!string.IsNullOrEmpty(row[RequisicaoItensDTO.FieldNames.HorasPeriodoDose].ToString()) && string.IsNullOrEmpty(row[RequisicaoItensDTO.FieldNames.JustificativaCancelamento].ToString()))
                                    {
                                        row[RequisicaoItensDTO.FieldNames.HorasPeriodoDose] = DBNull.Value;
                                        row[RequisicaoItensDTO.FieldNames.DataHoraAdmPaciente] = DBNull.Value;
                                    }
                                }
                                if (ID_PrescricaoInternacao != null && string.IsNullOrEmpty(row[RequisicaoItensDTO.FieldNames.IdPrescricaoInternacao].ToString()))
                                    row[RequisicaoItensDTO.FieldNames.IdPrescricaoInternacao] = ID_PrescricaoInternacao.Value;
                            }
                        }

                        dtoRequisicao = Requisicao.Gravar(dtoRequisicao, dtbRequisicaoItem);

                        dtbRequisicaoItem.AcceptChanges();

                        #region Gravar vínculos com kit para ordenação no mat
                        //RequisicaoItens.ExcluirItensKit((int)dtoRequisicao.Idt.Value);		 
                        foreach (DataRow rowItem in dtbRequisicaoItem.Rows)
                        {
                            if (!string.IsNullOrEmpty(rowItem[RequisicaoItensDTO.FieldNames.IdKitItem].ToString()))
                            {
                                KitDTO dto = new KitDTO();
                                dto.IdKit.Value = rowItem[RequisicaoItensDTO.FieldNames.IdKitItem].ToString();
                                KitDataTable dtbKit = Kit.ListarItem(dto);
                                foreach (DataRow rowKit in dtbKit.Rows)
                                {
                                    RequisicaoItensDTO dtoRI = new RequisicaoItensDTO();
                                    dtoRI.Idt.Value = dtoRequisicao.Idt.Value;
                                    dtoRI.IdtProduto.Value = rowKit[KitDTO.FieldNames.IdProduto].ToString();
                                    RequisicaoItensDataTable dtbRI = RequisicaoItens.Sel(dtoRI);
                                    if (dtbRI.Rows.Count > 0)
                                    {
                                        dtoRI = dtbRI.TypedRow(0);
                                        int qtdMultiplica = int.Parse(rowItem[RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString());
                                        if (!string.IsNullOrEmpty(rowItem[RequisicaoItensDTO.FieldNames.QtdKitItemMultiplica].ToString()))
                                            qtdMultiplica = int.Parse(rowItem[RequisicaoItensDTO.FieldNames.QtdKitItemMultiplica].ToString());
                                        int qtdItemKit = int.Parse(rowKit[KitDTO.FieldNames.QtdeItem].ToString()) * qtdMultiplica;

                                        if (!totalImediatoPrescricaoInternacao && GerarPedidoAutomaticoSetor() && !cbUrgente.Checked && !cbAntimicrobianos.Checked && cbStatus.Checked)
                                        {                                            
                                            dtoRI.QtdSolicitada.Value = dtoRI.QtdSolicitada.Value - (int.Parse(rowKit[KitDTO.FieldNames.QtdeItem].ToString()) * qtdMultiplica);
                                            if (dtoRI.QtdSolicitada.Value < 0) dtoRI.QtdSolicitada.Value = 0;
                                            qtdItemKit = (int)dtoRI.QtdSolicitada.Value;

                                            RequisicaoItens.Upd(dtoRI);                                            
                                        }
                                        else
                                        {
                                            int qtdSolAssKit = RequisicaoItens.ObterQtdSolicitadaAssKit((int)dtoRequisicao.Idt.Value,
                                                                                                        int.Parse(rowKit[KitDTO.FieldNames.IdProduto].ToString()),
                                                                                                        (int)dto.IdKit.Value,
                                                                                                        int.Parse(rowItem[RequisicaoItensDTO.FieldNames.IdtProduto].ToString()));
                                            if (qtdSolAssKit > 0 && qtdSolAssKit != qtdItemKit)
                                            {
                                                RequisicaoItens.AtualizarItemKit((int)dtoRequisicao.Idt.Value,
                                                                                int.Parse(rowKit[KitDTO.FieldNames.IdProduto].ToString()),
                                                                                (int)dto.IdKit.Value,
                                                                                int.Parse(rowItem[RequisicaoItensDTO.FieldNames.IdtProduto].ToString()),
                                                                                qtdItemKit);
                                            }
                                            else if (qtdSolAssKit == 0)
                                            {
                                                RequisicaoItens.InserirItemKit((int)dtoRequisicao.Idt.Value,
                                                                                int.Parse(rowKit[KitDTO.FieldNames.IdProduto].ToString()),
                                                                                (int)dto.IdKit.Value,
                                                                                int.Parse(rowItem[RequisicaoItensDTO.FieldNames.IdtProduto].ToString()),
                                                                                qtdItemKit);
                                            }
                                        }
                                        //Atualizar Qtd. Item sem Kit                                        
                                        int qtdSolSemKit = (int)dtoRI.QtdSolicitada.Value -
                                                           RequisicaoItens.ObterQtdSolicitadaAssKit((int)dtoRequisicao.Idt.Value, int.Parse(rowKit[KitDTO.FieldNames.IdProduto].ToString()));
                                        if (qtdSolSemKit >= 0)
                                            RequisicaoItens.AtualizarItemKit((int)dtoRequisicao.Idt.Value,
                                                                             int.Parse(rowKit[KitDTO.FieldNames.IdProduto].ToString()),
                                                                             null,
                                                                             null,
                                                                             qtdSolSemKit);
                                        else
                                        {
                                            qtdSolSemKit = RequisicaoItens.ObterQtdSolicitadaAssKit((int)dtoRequisicao.Idt.Value,
                                                                                                    int.Parse(rowKit[KitDTO.FieldNames.IdProduto].ToString()),
                                                                                                    null,
                                                                                                    null);
                                            if (qtdSolSemKit > qtdItemKit) qtdSolSemKit = qtdItemKit;

                                            RequisicaoItens.AtualizarItemKit((int)dtoRequisicao.Idt.Value,
                                                                            int.Parse(rowKit[KitDTO.FieldNames.IdProduto].ToString()),
                                                                            (int)dto.IdKit.Value,
                                                                            int.Parse(rowItem[RequisicaoItensDTO.FieldNames.IdtProduto].ToString()),
                                                                            qtdSolSemKit);

                                            qtdSolSemKit = (int)dtoRI.QtdSolicitada.Value -
                                                           RequisicaoItens.ObterQtdSolicitadaAssKit((int)dtoRequisicao.Idt.Value, int.Parse(rowKit[KitDTO.FieldNames.IdProduto].ToString()));

                                            if (qtdSolSemKit < 0) qtdSolSemKit = 0;

                                            RequisicaoItens.AtualizarItemKit((int)dtoRequisicao.Idt.Value,
                                                                                int.Parse(rowKit[KitDTO.FieldNames.IdProduto].ToString()),
                                                                                null,
                                                                                null,
                                                                                qtdSolSemKit);
                                        }
                                    }
                                }                                
                            }
                        }

                    	#endregion

                        if (ID_PrescricaoInternacao != null)
                        {
                            RequisicaoDTO dtoReqPend = new RequisicaoDTO();
                            RequisicaoItensDTO dtoReqItemPend = new RequisicaoItensDTO();
                            dtoReqItemPend.IdUsuarioPedidoAutoCancelado.Value = 1; //Passa o usuário para não trazer cancelados
                            dtoReqItemPend.IdPrescricaoInternacao.Value = ID_PrescricaoInternacao;
                            RequisicaoItensDataTable dtbReqItemPendentesPrescricao = RequisicaoItens.ListarPedidoAutoControle(dtoReqItemPend, dtoReqPend, 2);
                            //Se não tiver mais nada pendente de geração para a prescrição, alterar o status dela na internação para Dispensada
                            if (dtbReqItemPendentesPrescricao.Rows.Count == 0)
                                RequisicaoItens.UpdStatusPrescricaoInt((int)dtoReqItemPend.IdPrescricaoInternacao.Value, "D");
                        }

                        txtReqIdt.Text = dtoRequisicao.Idt.Value.ToString();
                        txtData.Text = Utilitario.ObterDataHoraServidor().Date.ToString("dd/MM/yyyy");
                        cmbKit.Enabled = grbAddMatMed.Enabled = false;
                        MessageBox.Show("Registro Salvo com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Default;

                        if (ID_PrescricaoInternacao != null)
                        {
                            PrescricaoInternacaoGerada = true;
                            this.Close();
                            return true;
                        }

                        if (cbAntimicrobianos.Checked)
                        {
                            tsbPrescricoes.Visible =tsbImprimirPrescricao.Visible= cbAntimicrobianos.Checked = false;
                            _carregarCombo = true;
                            ExecThreadComboMatMed();
                        }
                        dtoRequisicao = null;
                        dtgPersonalisado.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Você não pode salvar uma requisição sem itens", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Cursor = Cursors.Default;
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("O Número do Atendimento é Obrigatório", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Cursor = Cursors.Default;
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtoRequisicao = null;
                this.Cursor = Cursors.Default;
                return false;
            }
            dtoPrescricao = null;
            btnCancelarKit.Visible = false;
            this.Cursor = Cursors.Default;
            return true;
        }

        private bool AdicionarItem(int? qtdReq)
        {
            if (dtbRequisicaoItem == null) dtbRequisicaoItem = new RequisicaoItensDataTable();
            if (dtbRequisicaoItem.Select(string.Format("{0} = {1}",
                                                       RequisicaoItensDTO.FieldNames.IdtProduto,
                                                       dtoMatMed.Idt.Value)).Length > 0)
            {
                MessageBox.Show("Já foi adicionado o Material/Medicamento Selecionado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbMatMed.Focus();
                return false;
            }

            if (dtoMatMed.IdtPrincipioAtivo.Value.IsNull) dtoMatMed.IdtPrincipioAtivo.Value = 0;
            if (dtoMatMed.IdtPrincipioAtivo.Value != 0)
            {
                if (dtbRequisicaoItem.Select(string.Format("{0} = {1}",
                                                           RequisicaoItensDTO.FieldNames.IdtPrincipioAtivo,
                                                           dtoMatMed.IdtPrincipioAtivo.Value)).Length > 0)
                {
                    MessageBox.Show("Já foi adicionado Material/Medicamento similar a este", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbMatMed.Focus();
                    return false;
                }
            }

            if (int.Parse(cmbSetor.SelectedValue.ToString()) != 202 && 
                int.Parse(cmbSetor.SelectedValue.ToString()) != 203 &&
                int.Parse(cmbSetor.SelectedValue.ToString()) != 150) //UTI NEONATAL -> 203, UTI PEDIATRICA MISTA -> 202, PEDIATRIA 9. CD -> 150
            {
                MaterialMedicamentoDTO dtoSeringaPesquisa = new MaterialMedicamentoDTO();
                dtoSeringaPesquisa.Idt.Value = dtoMatMed.Idt.Value;
                dtoSeringaPesquisa.NomeFantasia.Value = "%SERINGA SERISAM%"; //Liberar pedido desta seringa apenas para PEDIATRIA 9. CD, UTI NEONATAL e UTI PEDIATRICA
                MaterialMedicamentoDataTable dtbSeringaPesquisa = MatMed.Sel(dtoSeringaPesquisa);
                if (dtbSeringaPesquisa.Rows.Count > 0)
                {
                    MessageBox.Show("Item não liberado para pedido neste setor!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbMatMed.Focus();
                    return false;
                }
            }

            DateTime? dtHoraAdmPaciente = null;
            if (qtdReq != null && !cbUrgente.Checked && !cbAntimicrobianos.Checked &&
                GerarPedidoAutomaticoSetor() && MatMed.ProdutoPedidoAutomatico(dtoMatMed))
            {
                if (cmbPeriodoGerar.SelectedIndex == -1 || cmbPeriodoGerar.SelectedValue.ToString() == "-1")
                {
                    MessageBox.Show("Período Dose é obrigatório", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbPeriodoGerar.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtHora1.Text))
                {
                    MessageBox.Show("1º Horário Dose é obrigatório", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtHora1.Focus();
                    return false;
                }
                if (int.Parse(txtHora1.Text) > 23)
                {
                    MessageBox.Show("1º Horário Dose inválido.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtHora1.Focus();
                    return false;
                }
                dtHoraAdmPaciente = this.ObterDataInicioAdmPacienteDigitada(int.Parse(txtHora1.Text));
                DateTime dataUltimoPeriodo;
                if (!ValidarPrimeiroHorarioDose(dtHoraAdmPaciente.Value, out dataUltimoPeriodo))
                {
                    MessageBox.Show("1º Horário Dose não pode ser superior ao do último período de corte (" + dataUltimoPeriodo.ToString("dd/MM/yyyy HH:mm") + ").", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtHora1.Focus();
                    return false;
                }
            }

            if ((!gen.UtiCompartilhada(int.Parse(cmbSetor.SelectedValue.ToString()))) ||
                dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM)
            {
                ConfiguraPedidoPadraoDTO();

                if (PedidoPadrao.ProdutoPadrao(dtoPedidoPadrao, dtoMatMed, true))
                {
                    MessageBox.Show(string.Format("O Material/Medicamento {0} pertence ao Estoque Padrão e não pode ser requisitado", dtoMatMed.Descricao.Value),
                                    "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbMatMed.Focus();
                    return false;
                }
            }

            //Se estiver logado em INTERNADO (-UTI), não deixar pedir medicamento
            if ((int)FrmPrincipal.dtoSeguranca.IdtLocal.Value == 29)
            {
                if ((!gen.UtiGeralCardio(int.Parse(cmbSetor.SelectedValue.ToString())) && int.Parse(cmbSetor.SelectedValue.ToString()) != UTI_EDA_GERAL) &&
                        decimal.Parse(dtoMatMed.Tabelamedica.Value.ToString()) == (decimal)MaterialMedicamentoDTO.TipoMatMed.MEDICAMENTO)
                {
                    if (gen.ObterFarmaciaSetor(int.Parse(cmbSetor.SelectedValue.ToString())) != null)
                    {
                        MessageBox.Show(string.Format("Unidade de Internação não pode solicitar Medicamentos, entregar Prescrição Médica para a Farmácia!!!", dtoMatMed.Descricao.Value),
                                        "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbMatMed.Focus();
                        return false;
                    }
                }
            }

            if (int.Parse(cmbSetor.SelectedValue.ToString()) == ATENDIMENTO_DOMICILIAR ||
                cbAntimicrobianos.Checked) 
            {
                RequisicaoDTO dtoReqItemPend = new RequisicaoDTO();
                dtoReqItemPend.IdtAtendimento.Value = txtNroInternacao.Text.Trim();
                RequisicaoItensDataTable dtbReqItemPend = RequisicaoItens.SelReqItensPendentes(dtoReqItemPend);
                if (dtbReqItemPend.Select(string.Format("{0} = {1}",
                                                        RequisicaoItensDTO.FieldNames.IdtProduto,
                                                        dtoMatMed.Idt.Value)).Length > 0)
                {
                    int qtdPendentePedido = 0;
                    if (!cbAntimicrobianos.Checked)
                    {                        
                        DataRow row = dtbReqItemPend.Select(string.Format("{0} = {1}",
                                                                          RequisicaoItensDTO.FieldNames.IdtProduto,
                                                                          dtoMatMed.Idt.Value))[0];
                        qtdPendentePedido = int.Parse(row[RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString()) - int.Parse(row[RequisicaoItensDTO.FieldNames.QtdFornecida].ToString());
                        //if (MessageBox.Show("Já há " + qtdPendente.ToString() + " unidade(s) com pendência em aberta de baixa a este paciente referente a um pedido anterior, deseja realmente adicionar este item neste pedido criando mais pendências no almoxarifado ?",
                        if (MessageBox.Show("Consta(m) " + qtdPendentePedido.ToString() + " em quantidade pendente deste item, de um pedido anterior do paciente.\n\nDeseja realmente adicioná-lo ao pedido, gerando mais pendências ao Almoxarifado?",
                                            "Gestão de Materiais e Medicamentos",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        {
                            cmbMatMed.Focus();
                            return false;
                        }
                    }
                    else if (((!gen.UtiCompartilhada(int.Parse(cmbSetor.SelectedValue.ToString())))))
                    {
                        if (_qtdPendenteItemPrescricao == 0)
                            MessageBox.Show("Item já atingiu o limite do total autorizado da prescrição.",
                                            "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {                            
                            decimal UTI_GERAL = 201; decimal UTI_CARDIO = 200; decimal UTI_TERREO = 2652;                            
                            for (int i = 0; i <= dtbReqItemPend.Select(string.Format("{0} = {1} AND {2} = {3} AND ({4} NOT IN ({5},{6},{7}))",
                                                                                      RequisicaoItensDTO.FieldNames.IdtProduto, 
                                                                                      dtoMatMed.Idt.Value,
                                                                                      RequisicaoItensDTO.FieldNames.IdPrescricao, 
                                                                                      dtoPrescricao.IdPrescricao.Value,
                                                                                      RequisicaoDTO.FieldNames.IdtSetor,
                                                                                      UTI_CARDIO,
                                                                                      UTI_GERAL,
                                                                                      UTI_TERREO)).Length - 1; i++)
                            {
                                DataRow row = dtbReqItemPend.Select(string.Format("{0} = {1} AND {2} = {3}",
                                                                                  RequisicaoItensDTO.FieldNames.IdtProduto, dtoMatMed.Idt.Value,
                                                                                  RequisicaoItensDTO.FieldNames.IdPrescricao, dtoPrescricao.IdPrescricao.Value))[i];
                                qtdPendentePedido += int.Parse(row[RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString()) - int.Parse(row[RequisicaoItensDTO.FieldNames.QtdFornecida].ToString());                                
                            }
                            //if (int.Parse(txtQtdReq.Text) > (_qtdPendenteItemPrescricao - qtdPendentePedido))
                            //{
                            //    if (qtdPendentePedido > 0)
                            //        MessageBox.Show("Item já solicitado anteriormente e pendente na dispensação, favor aguardar o envio do almoxarifado.",
                            //                        "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);                                
                            //    return false;
                            //}
                            if (int.Parse(txtQtdReq.Text) > (_qtdPendenteItemPrescricao))
                            {
                                if (qtdPendentePedido > 0)
                                    MessageBox.Show("Qtd. requisitada superior ao limite autorizado da prescrição.",
                                                    "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                        }
                    }
                    else //Se for antimicrobiano UTI, validar a pendencia da prescrição (eliminada no consumo) para evitar duplicação de pedido. Na UTI não há dispensação, portanto não atualiza QtdFornecida do Pedido (depois foi feito um ajuste e está atualizando sim a QtdFornecida).
                    {
                        if (_qtdPendenteItemPrescricao == 0)
                            MessageBox.Show("Item já atingiu o limite do total autorizado da prescrição.",
                                            "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            int qtdSolicitada = 0;
                            for (int i = 0; i <= dtbReqItemPend.Select(string.Format("{0} = {1} AND {2} = {3}",
                                                            RequisicaoItensDTO.FieldNames.IdtProduto, dtoMatMed.Idt.Value,
                                                            RequisicaoItensDTO.FieldNames.IdPrescricao, dtoPrescricao.IdPrescricao.Value)).Length - 1; i++)
                            {
                                DataRow row = dtbReqItemPend.Select(string.Format("{0} = {1} AND {2} = {3}",
                                                                                  RequisicaoItensDTO.FieldNames.IdtProduto, dtoMatMed.Idt.Value,
                                                                                  RequisicaoItensDTO.FieldNames.IdPrescricao, dtoPrescricao.IdPrescricao.Value))[i];
                                qtdSolicitada += int.Parse(row[RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString());
                            }

                            if (int.Parse(txtQtdReq.Text) > (_qtdTotalAutorizadaItemPrescricao - qtdSolicitada))
                            {
                                MessageBox.Show("Item já solicitado anteriormente e pendente para consumo no almoxarifado da UTI.",
                                                "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                        }
                    }
                }
            }            

            #region ROTINA ABAIXO COMENTADA POR INDEFINIÇÃO DE REGRA

            //PedidoPadraoItensDTO dtoPedPadItem = null;

            //Rotina comentada por indefinição de regra. Se descomentar esta rotina, deve-se comentar o if que vem logo abaixo
            //if (!PedidoPadrao.LiberarProdutoPadraoReqPersonalizadaEstMin(dtoPedidoPadrao, dtoMatMed, ref dtoPedPadItem))
            //{
            //    //Quando o produto requisitado pertence ao pedido padrão, ele nunca vai ser liberado quando fracionado                    
            //    if (dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.NAO)
            //    {
            //        MessageBox.Show(string.Format("O Material/Medicamento {0} não pode ser requisitado, pois pertence ao Pedido Padrão deste setor e ele ou um similar já existe em uma qtd. mínima no estoque local.", dtoMatMed.NomeFantasia.Value),
            //                        "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show(string.Format("O Material/Medicamento {0} não pode ser requisitado, pois é um produto fracionado que pertence ao Pedido Padrão deste setor.", dtoMatMed.NomeFantasia.Value),
            //                        "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    return false;
            //}

            //Descomentar este if, se comentar o if acima por indefinição de regra
            //if (!PedidoPadrao.LiberarProdutoPadraoReqPersonalizadaEstMin(dtoPedidoPadrao, dtoMatMed, ref dtoPedPadItem))
            //{
            //    //Quando o produto requisitado pertence ao pedido padrão, ele nunca vai ser liberado quando fracionado                    
            //    if (dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM)
            //    {
            //        MessageBox.Show(string.Format("O Material/Medicamento {0} não pode ser requisitado, pois é um produto fracionado que pertence ao Pedido Padrão deste setor.", dtoMatMed.NomeFantasia.Value),
            //                        "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return false;
            //    }                                
            //}
            #endregion

            // Converte dto MatMed para dto RequisicaoItem
            dtoRequisicaoItem = RequisicaoItens.ConverteMatMedRequisicao(dtoMatMed);
            // verifica estoque local
            ConfiguraEstoqueDTO();
            dtoEstoque = Estoque.EstoqueLocalProduto(dtoEstoque);
            dtoRequisicaoItem.EstoqueLocalQtde.Value = dtoEstoque.Qtde.Value;
            if (dtoPrescricao != null && !dtoPrescricao.IdPrescricao.Value.IsNull)
                dtoRequisicaoItem.IdPrescricao.Value = dtoPrescricao.IdPrescricao.Value;

            if (qtdReq == null)
            {
                // Solicita quantidade
                if (GerarPedidoAutomaticoSetor() && MatMed.ProdutoPedidoAutomatico(dtoMatMed) && !cbUrgente.Checked)
                {
                    dtoRequisicaoItem = FrmQtdMatMed.DigitaQtde(dtoRequisicaoItem, true);
                    if (dtoRequisicaoItem != null)
                        dtoRequisicaoItem.DataHoraAdmPaciente.Value = this.ObterDataInicioAdmPacientePadrao();
                }
                else
                    dtoRequisicaoItem = FrmQtdMatMed.DigitaQtde(dtoRequisicaoItem);
            }
            else            
                dtoRequisicaoItem.QtdSolicitada.Value = qtdReq;

            #region RETIRADO
            //if (dtoPedPadItem == null && dtoRequisicaoItem != null)
            //{
            //    if (!dtoRequisicaoItem.EstoqueLocalQtde.Value.IsNull &&
            //        !dtoRequisicaoItem.QtdSolicitada.Value.IsNull)
            //    {
            //        if ((decimal)dtoRequisicaoItem.EstoqueLocalQtde.Value > 0)
            //        {
            //            if ((decimal)dtoRequisicaoItem.QtdSolicitada.Value < (decimal)dtoRequisicaoItem.EstoqueLocalQtde.Value)
            //            {
            //                MessageBox.Show(string.Format("O Material/Medicamento {0} não pode ser requisitado, pois já existe no estoque local.", dtoMatMed.NomeFantasia.Value),
            //                                              "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                return false;
            //            }
            //            else if ((decimal)dtoRequisicaoItem.QtdSolicitada.Value > (decimal)dtoRequisicaoItem.EstoqueLocalQtde.Value)
            //            {
            //                dtoRequisicaoItem.QtdSolicitada.Value = dtoRequisicaoItem.QtdFornecida.Value;
            //                dtoRequisicaoItem.QtdFornecida.Value = 0;

            //                if (dtoRequisicaoItem.EstoqueLocalQtde.Value != 0)
            //                {
            //                    MessageBox.Show(string.Format("Já existe {0} no estoque local!!!\n\nA QUANTIDADE REQUISITADA SERÁ DE {1}",
            //                                    dtoMatMed.NomeFantasia.Value, dtoRequisicaoItem.QtdSolicitada.Value),
            //                                    "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                }
            //            }
            //        }
            //    }
            //}
            #endregion

            if (dtoRequisicaoItem != null)
            {
                // se for uma requisição já salva terá ID da requisição tem que atribuir ao dtoReq
                if (txtReqIdt.Text.Length != 0)
                {
                    dtoRequisicaoItem.Idt.Value = Convert.ToDecimal(txtReqIdt.Text);
                }
                try
                {
                    if (GerarPedidoAutomaticoSetor() && !cbUrgente.Checked && !cbAntimicrobianos.Checked &&
                        (cmbPeriodoGerar.SelectedIndex > -1 && cmbPeriodoGerar.SelectedValue.ToString() != "-1") && dtHoraAdmPaciente != null)
                    {
                        dtoRequisicaoItem.HorasPeriodoDose.Value = cmbPeriodoGerar.SelectedValue.ToString();
                        dtoRequisicaoItem.DataHoraAdmPaciente.Value = dtHoraAdmPaciente.Value;
                    }

                    this.AdicionarItemTable(dtoRequisicaoItem);

                    if (ID_PrescricaoInternacao != null)
                        dtbRequisicaoItem.Select(string.Format("{0} = {1}", RequisicaoItensDTO.FieldNames.IdtProduto, dtoMatMed.Idt.Value))[0]["DOSE_ADM"] = dtoRequisicaoItem.QtdSolicitada.Value;

                    dtgPersonalisado.DataSource = dtbRequisicaoItem;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (int.Parse(cmbLocal.SelectedValue.ToString()) == (int)PacienteDTO.LocalAtendimento.PRONTO_SOCORRO)
                new Generico().AlertarAutorizacaoKitGastro(dtoMatMed);

            return true;
        }

        private void AdicionarItemTable(RequisicaoItensDTO dtoRI)
        {
            dtbRequisicaoItem.Add(dtoRI);

            AddColunasManualItens();
        }

        private void AddColunasManualItens()
        {
            if (dtbRequisicaoItem.Columns.IndexOf(MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia) == -1)
                dtbRequisicaoItem.Columns.Add(MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia);

            if (dtbRequisicaoItem.Columns.IndexOf(MaterialMedicamentoDTO.FieldNames.IdtSubGrupo) == -1)
                dtbRequisicaoItem.Columns.Add(MaterialMedicamentoDTO.FieldNames.IdtSubGrupo);

            if (dtbRequisicaoItem.Columns.IndexOf("FL_ITEM_KIT_ADICIONADO") == -1)
                dtbRequisicaoItem.Columns.Add("FL_ITEM_KIT_ADICIONADO");

            dtbRequisicaoItem.Rows[dtbRequisicaoItem.Rows.Count - 1][MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia] = dtoMatMed.MedAltaVigilancia.Value;
            dtbRequisicaoItem.Rows[dtbRequisicaoItem.Rows.Count - 1][MaterialMedicamentoDTO.FieldNames.IdtSubGrupo] = dtoMatMed.IdtSubGrupo.Value;
            dtbRequisicaoItem.Rows[dtbRequisicaoItem.Rows.Count - 1]["FL_ITEM_KIT_ADICIONADO"] = 0;
        }

        /// <summary>
        /// Método a ser usado na execução da thread
        /// </summary>
        private void ComboMatMed()
        {            
            CarregaComboDelegate carregaComboDelegate = new CarregaComboDelegate(CarregarMatMed);

            if (cbAntimicrobianos.Checked && txtNroInternacao.Text != string.Empty)
            {
                PrescricaoDTO dtoItem = new PrescricaoDTO();
                dtoItem.IdAtendimento.Value = txtNroInternacao.Text;
                PrescricaoDataTable dtbPresc = Prescricao.ListarItem(dtoItem, true);
                _dtbMatMedAntimicrobianosMemoria = dtbPresc;
                cmbMatMed.Invoke(carregaComboDelegate);
                _dtbMatMedAntimicrobianosMemoria = null;
            }            
            //else if ((_SetorThread != UTI_GERAL && _SetorThread != UTI_CARDIO))
            //{
            //    if (_dtbMatMedTrocaMemoria == null)
            //    {
            //        dtoMatMed.IdtGrupo.Value = 1; //Drogas e Medicamentos
            //        DataTable dtbMatMed1 = MatMed.SelSubGrupoSetorPermissao(dtoMatMed, true);

            //        dtoMatMed.IdtGrupo.Value = 6; //Consumo Material Medico Hospitalar
            //        DataTable dtbMatMedGrupo6 = MatMed.SelSubGrupoSetorPermissao(dtoMatMed, true);
            //        dtbMatMed1.Merge(dtbMatMedGrupo6);

            //        if (_SetorThread != ATENDIMENTO_DOMICILIAR)
            //        {
            //            dtoMatMed.IdtGrupo.Value = 61; //PROTESE, ORTESE, SINTESE
            //            DataTable dtbMatMedGrupo61 = MatMed.SelSubGrupoSetorPermissao(dtoMatMed, true);
            //            dtbMatMed1.Merge(dtbMatMedGrupo61);
            //        }
                    
            //        DataView dvMatMed = new DataView(dtbMatMed1, string.Format("{0} <> {1}", MaterialMedicamentoDTO.FieldNames.IdtSubGrupo, ANTIMICROBIANOS_RESTRITOS), MaterialMedicamentoDTO.FieldNames.NomeFantasia, DataViewRowState.CurrentRows);
            //        dtbMatMed1 = dvMatMed.ToTable();
            //        _dtbMatMedTrocaMemoria = dtbMatMed1;
            //        cmbMatMed.Invoke(carregaComboDelegate);
            //    }
            //}
            else
            {
                if (_dtbMatMedTrocaMemoria == null)
                {
                    int idCentroDisp = 0;
                    MovimentacaoDTO dtoMovimento = new MovimentacaoDTO();
                    dtoMovimento.IdtSetor.Value = (int)_SetorThread;
                    SetorDTO dtoSetFarm;
                    dtoMovimento = Movimento.CentroDispensacao(dtoMovimento, out dtoSetFarm);
                    if (!dtoMovimento.IdtSetorBaixa.Value.IsNull)
                        idCentroDisp = (int)dtoMovimento.IdtSetorBaixa.Value;

                    if (idCentroDisp == UTI_ALMOX_SATELITE)
                    {
                        dtoPedidoPadrao.IdtUnidade.Value = 244; //SANTOS
                        dtoPedidoPadrao.IdtLocal.Value = 33; //ADM.
                        dtoPedidoPadrao.IdtSetor.Value = idCentroDisp;
                    }
                    else if ((!gen.UtiCompartilhada((int)_SetorThread)))
                    {
                        SetorDTO dtoSetorAlmox = new SetorDTO();
                        dtoSetorAlmox.FlAlmoxCentral.Value = (byte)SetorDTO.AlmoxarifadoCentral.SIM;
                        dtoSetorAlmox = Setor.Sel(dtoSetorAlmox).TypedRow(0);
                        dtoPedidoPadrao.IdtUnidade.Value = dtoSetorAlmox.IdtUnidade.Value;
                        dtoPedidoPadrao.IdtLocal.Value = dtoSetorAlmox.IdtLocalAtendimento.Value;

                        int? idSetorFarmacia = gen.ObterFarmaciaSetor((int)_SetorThread);
                        if (idSetorFarmacia != null)
                            dtoPedidoPadrao.IdtSetor.Value = idSetorFarmacia.Value;
                        else
                            dtoPedidoPadrao.IdtSetor.Value = dtoSetorAlmox.Idt.Value;
                    }
                    MaterialMedicamentoDataTable dtbMatMed = new MaterialMedicamentoDataTable();
                    PedidoPadraoDataTable dtbPedidoPadrao = PedidoPadrao.Sel(dtoPedidoPadrao);
                    PedidoPadraoItensDataTable dtbPedidoPadraoItens = null;
                    DataRow rowMM;
                    if (dtbPedidoPadrao.Rows.Count > 0)
                    {
                        dtoPedidoPadrao = dtbPedidoPadrao.TypedRow(0);
                        dtbPedidoPadraoItens = PedidoPadrao.SelItens(dtoPedidoPadrao);
                        foreach (DataRow rowPedido in dtbPedidoPadraoItens.Rows)
                        {
                            if (rowPedido[MaterialMedicamentoDTO.FieldNames.IdtSubGrupo].ToString() != ANTIMICROBIANOS_RESTRITOS.ToString())
                            {
                                rowMM = dtbMatMed.NewRow();
                                rowMM[MaterialMedicamentoDTO.FieldNames.Idt] = rowPedido[MaterialMedicamentoDTO.FieldNames.Idt];
                                rowMM[MaterialMedicamentoDTO.FieldNames.NomeFantasia] = rowPedido[MaterialMedicamentoDTO.FieldNames.NomeFantasia];
                                dtbMatMed.Rows.Add(rowMM);
                            }
                        }
                        dtbMatMed.AcceptChanges();
                        _dtbMatMedTrocaMemoria = dtbMatMed;
                    }                    
                    cmbMatMed.Invoke(carregaComboDelegate);
                }
            }

            if (_dtbMatMedTrocaMemoria != null && !cbAntimicrobianos.Checked) cmbMatMed.Invoke(carregaComboDelegate);
            dtoMatMed.IdtGrupo.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
        }
       
        private delegate void CarregaComboDelegate();

        /// <summary>
        /// Método a ser usado pelo delegate CarregaComboDelegate
        /// </summary>        
        ///         
        private void CarregarMatMed()
        {
            cmbMatMed.ValueMember = MaterialMedicamentoDTO.FieldNames.Idt;
            cmbMatMed.DisplayMember = MaterialMedicamentoDTO.FieldNames.NomeFantasia;
            if (_dtbMatMedAntimicrobianosMemoria != null)
                cmbMatMed.DataSource = _dtbMatMedAntimicrobianosMemoria;
            else if (_dtbMatMedTrocaMemoria != null)
                cmbMatMed.DataSource = _dtbMatMedTrocaMemoria;
            else
                cmbMatMed.DataSource = new DataTable(); //dtb;
            cmbMatMed.IniciaLista();
            if (!cbAntimicrobianos.Checked) cmbMatMed.Enabled = true;
            cmbMatMed.Focus();
        }

        private void LimpaComboMatMed()
        {
            cmbMatMed.SelectedIndex = -1;
            cmbMatMed.Text = "<Selecione>";
        }

        /// <summary>
        /// Método também verifica permissão de setor para pedir kit
        /// </summary>        
        private bool EstoqueUnificado()
        {
            //Verifica se estoque é unificado
            MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();
            dtoCfg.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoCfg.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoCfg.Idtsetor.Value = cmbSetor.SelectedValue.ToString();
            
            dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);
            
            if (dtoCfg.SolicitaKit.Value.IsNull) dtoCfg.SolicitaKit.Value = 0;
            if (dtoCfg.EstoqueUnificadoHAC.Value.IsNull) dtoCfg.EstoqueUnificadoHAC.Value = 0;

            lblKitDsc.Text = string.Empty;
            cmbKit.Visible = lblKit.Visible = false;
            dtgPersonalisado.Columns[colKitAssociado.Name].Visible = true;
            if (dtoCfg.SolicitaKit.Value == 1 && ID_PrescricaoInternacao == null)
            {
                cmbKit.Visible = lblKit.Visible = true;
                KitDTO dtoKit = new KitDTO();
                dtoKit.Ativo.Value = 1;
                cmbKit.DataSource = Kit.Listar(dtoKit);
                cmbKit.IniciaLista();                
            }            

            if (dtoCfg.EstoqueUnificadoHAC.Value == 1)
            {
                //grpTipoAtendimento.Visible = false;
                return true;
                //MessageBox.Show("Estoque unificado não pode fazer pedido personalizado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //tsHac.NovoVisivel = false;
                //tsHac.PesquisarVisivel = false;
            }
            else
            {
                //grpTipoAtendimento.Visible = true;
                return false;
                //tsHac.NovoVisivel = true;
                //tsHac.PesquisarVisivel = true;
            }
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
                if (cmbSetor.SelectedValue.ToString() != CENTRO_CIRURGICO.ToString())
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
        }

        private void CarregarItensKit(KitDataTable dtbItem, int qtdMultiplicar, bool subtrair, int? periodoAplicacao)
        {
            bool medicamentoNaoInserido = false;
            this.Cursor = Cursors.WaitCursor;
            if (dtbItem == null)
            {
                KitDTO dtoKit = new KitDTO();
                dtoKit.IdKit.Value = cmbKit.SelectedValue.ToString();
                dtbItem = Kit.ListarItem(dtoKit);
                dtbRequisicaoItem = new RequisicaoItensDataTable();
            }
            ConfiguraRequisicaoDTO();
            if (dtbRequisicaoItem == null) dtbRequisicaoItem = new RequisicaoItensDataTable();           

            foreach (DataRow row in dtbItem.Rows)
            {
                if (cmbKit.Visible && !subtrair)
                {
                    if (dtoRequisicao.IdtSetor.Value != CENTRO_CIRURGICO && 
                        int.Parse(row[MaterialMedicamentoDTO.FieldNames.IdtGrupo].ToString()) == 1) //Não deixar inserir medicamento quando for pedido de kit (caso UTIs)
                    {
                        medicamentoNaoInserido = true;
                        continue;
                    }
                }
                else if (!cmbKit.Visible && int.Parse(dtgPersonalisado.CurrentRow.Cells[colMatMedIdt.Name].Value.ToString()) == int.Parse(row[KitDTO.FieldNames.IdProduto].ToString()))
                    continue; //Não pode inserir/subtrair item de kit se for o mesmo item selecionado do grid

                dtoMatMed.Idt.Value = row[KitDTO.FieldNames.IdProduto].ToString();
                DataRow rowReqItem;
                if (dtbRequisicaoItem.Select(string.Format("{0} = {1}",
                                                           RequisicaoItensDTO.FieldNames.IdtProduto,
                                                           dtoMatMed.Idt.Value)).Length > 0)
                {
                    rowReqItem = dtbRequisicaoItem.Select(string.Format("{0} = {1}", RequisicaoItensDTO.FieldNames.IdtProduto, dtoMatMed.Idt.Value))[0];
                    if (!subtrair)
                        rowReqItem[RequisicaoItensDTO.FieldNames.QtdSolicitada] = int.Parse(rowReqItem[RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString()) + (int.Parse(row[KitDTO.FieldNames.QtdeItem].ToString()) * qtdMultiplicar);
                    else
                        rowReqItem[RequisicaoItensDTO.FieldNames.QtdSolicitada] = int.Parse(rowReqItem[RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString()) - (int.Parse(row[KitDTO.FieldNames.QtdeItem].ToString()) * qtdMultiplicar);

                    if (int.Parse(rowReqItem[RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString()) <= 0)
                        ExcluirItem((int)dtoMatMed.Idt.Value);
                }
                else if (!subtrair)
                {                    
                    dtoMatMed = MatMed.SelChave(dtoMatMed);
                    dtoRequisicaoItem = RequisicaoItens.ConverteMatMedRequisicao(dtoMatMed);

                    // verifica estoque local
                    ConfiguraEstoqueDTO();
                    dtoEstoque = Estoque.EstoqueLocalProduto(dtoEstoque);
                    dtoRequisicaoItem.EstoqueLocalQtde.Value = dtoEstoque.Qtde.Value;

                    dtoRequisicaoItem.QtdSolicitada.Value = int.Parse(row[KitDTO.FieldNames.QtdeItem].ToString()) * qtdMultiplicar;
                    if (periodoAplicacao != null) dtoRequisicaoItem.HorasPeriodoDose.Value = periodoAplicacao.Value;

                    // se for uma requisição já salva terá ID da requisição tem que atribuir ao dtoReq
                    if (txtReqIdt.Text.Length != 0)
                        dtoRequisicaoItem.Idt.Value = int.Parse(txtReqIdt.Text);

                    try
                    {
                        dtbRequisicaoItem.Add(dtoRequisicaoItem);

                        AddColunasManualItens();

                        dtbRequisicaoItem.Rows[dtbRequisicaoItem.Rows.Count - 1]["FL_ITEM_KIT_ADICIONADO"] = 1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            dtgPersonalisado.DataSource = dtbRequisicaoItem;

            if (medicamentoNaoInserido && dtbItem.Rows.Count > 0 && !cmbKit.Visible)
                MessageBox.Show("AVISO: Este kit tem medicamentos que não foram inseridos para este Setor, mas podem ser pedidos sem a associação de kit.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (medicamentoNaoInserido && dtbItem.Rows.Count > 0 && cmbKit.Visible)
                MessageBox.Show("AVISO: Este kit tem medicamentos que não foram inseridos, pois está liberado apenas materiais para esta funcionalidade.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            this.Cursor = Cursors.Default;
        }

        DataRow _rowJustificarCancelamento;
        private void ExcluirItem(int idProduto)
        {
            for (int nCount = 0; nCount < dtbRequisicaoItem.Rows.Count; nCount++)
            {
                if (dtbRequisicaoItem.Rows[nCount].RowState != DataRowState.Deleted)
                {
                    if (int.Parse(dtbRequisicaoItem.Rows[nCount][RequisicaoItensDTO.FieldNames.IdtProduto].ToString()) == idProduto)
                    {
                        if (ID_PrescricaoInternacao == null || dtgPersonalisado.Rows[dtgPersonalisado.SelectedCells[0].RowIndex].Cells[colIdPrescricaoItemInternacao.Name].Value.ToString() == string.Empty)
                            dtbRequisicaoItem.Rows[nCount].Delete();
                        else
                        {
                            if (dtbRequisicaoItem.Rows[nCount][RequisicaoItensDTO.FieldNames.IdPrescricaoItemInternacao].ToString() == 
                                dtgPersonalisado.Rows[dtgPersonalisado.SelectedCells[0].RowIndex].Cells[colIdPrescricaoItemInternacao.Name].Value.ToString())
                            {
                                _rowJustificarCancelamento = dtbRequisicaoItem.Rows[nCount];

                                grbJustificativa.Visible = lblMatMed.Visible = true;
                                dtgPersonalisado.Visible = tsHac.SalvarVisivel = tsHac.MatMedVisivel = false;
                                lblMatMed.Text = dtbRequisicaoItem.Rows[nCount][RequisicaoItensDTO.FieldNames.DsProduto].ToString();
                                txtJustificativaCancel.Text = dtbRequisicaoItem.Rows[nCount][RequisicaoItensDTO.FieldNames.JustificativaCancelamento].ToString();
                                txtJustificativaCancel.Enabled = true; txtJustificativaCancel.Focus();
                            }
                            else
                                continue;
                        }
                        break;
                    }
                }
            }
        }

        private bool ValidarItemPrescricao(decimal idPrescricao, decimal idProduto, string dscProduto, int qtdReq)
        {            
            this.Cursor = Cursors.WaitCursor;
            PrescricaoDTO dtoItem = new PrescricaoDTO();
            dtoItem.IdPrescricao.Value = idPrescricao;
            dtoItem.IdProduto.Value = idProduto;
            PrescricaoDataTable dtbPresc = Prescricao.ListarItem(dtoItem, true);
            _qtdPendenteItemPrescricao = _qtdTotalAutorizadaItemPrescricao = 0;
            if (dtbPresc.Rows.Count == 1)
            {
                dtoItem = dtbPresc.TypedRow(0);
                DateTime dtAtual = Utilitario.ObterDataHoraServidor().Date;
                if (dtAtual < DateTime.Parse(dtoItem.DataInicioConsumo.Value.ToString()).Date)
                {
                    if (string.IsNullOrEmpty(dscProduto))
                        MessageBox.Show("Data atual deve ser maior ou igual à data de início de consumo autorizada deste item.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Data atual deve ser maior ou igual à data de início de consumo autorizada do item " + dscProduto + ".", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    this.Cursor = Cursors.Default;
                    return false;
                }
                if (dtAtual > DateTime.Parse(dtoItem.DataLimiteConsumo.Value.ToString()).Date)
                {
                    if (string.IsNullOrEmpty(dscProduto))
                        MessageBox.Show("Data atual ultrapassou a data limite de consumo autorizada deste item.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Data atual ultrapassou a data limite de consumo autorizada do item " + dscProduto + ".", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    this.Cursor = Cursors.Default;
                    return false;
                }
                if (qtdReq > int.Parse(dtbPresc.Rows[0]["QTDE_PENDENTE"].ToString()))
                {
                    if (string.IsNullOrEmpty(dscProduto))
                        MessageBox.Show("Qtd. Requis. deste item tem que ser menor ou igual à Qtd. Pendente Envio da prescrição.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Qtd. Requis. do item " + dscProduto + " tem que ser menor ou igual à Qtd. Pendente Envio da prescrição.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    this.Cursor = Cursors.Default;
                    return false;
                }
                RequisicaoItensDTO dtoReqItem = new RequisicaoItensDTO();
                dtoReqItem.IdtProduto.Value = idProduto;
                dtoReqItem.IdPrescricao.Value = idPrescricao;
                decimal qtdPedidaHoje = RequisicaoItens.ObterQtdItemPedidaHoje(dtoReqItem, string.IsNullOrEmpty(txtReqIdt.Text) ? 0 : int.Parse(txtReqIdt.Text));
                if ((qtdReq + qtdPedidaHoje) > (int)dtoItem.QtdDia.Value)
                {
                    if (string.IsNullOrEmpty(dscProduto))
                        MessageBox.Show("Qtd. diária solicitada deve ser menor ou igual a qtd. diária autorizada da prescrição.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Qtd. diária solicitada do item " + dscProduto + " deve ser menor ou igual a qtd. diária autorizada da prescrição.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    this.Cursor = Cursors.Default;
                    return false;
                }
                _qtdPendenteItemPrescricao = int.Parse(dtbPresc.Rows[0]["QTDE_PENDENTE"].ToString());
                _qtdTotalAutorizadaItemPrescricao = int.Parse(dtbPresc.Rows[0][PrescricaoDTO.FieldNames.QtdTotal].ToString());
            }
            else if (dtbPresc.Rows.Count == 0)
            {
                if (string.IsNullOrEmpty(dscProduto))
                    MessageBox.Show("Este item não consta pendente na prescrição.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show(dscProduto + " não consta pendente na prescrição.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Cursor = Cursors.Default;
                return false;
            }
            else if (dtbPresc.Rows.Count > 1)
            {
                if (string.IsNullOrEmpty(dscProduto))
                    MessageBox.Show("Item repetido ativo na prescrição, favor contatar o administrador do sistema.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show(dscProduto + " repetido ativo na prescrição, favor contatar o administrador do sistema.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                this.Cursor = Cursors.Default;
                return false;
            }

            this.Cursor = Cursors.Default;
            return true;
        }

        private void HabilitarBotaoMatMedSuperior()
        {
            tsHac.MatMedVisivel = true; //Agora será habilitado para todos os setores
            //tsHac.MatMedVisivel = false;

            if (cmbSetor.SelectedValue != null && (gen.UtiCompartilhada(int.Parse(cmbSetor.SelectedValue.ToString()))))
                grbAddMatMed.Text = "Adicionar Mat/Med"; //tsHac.MatMedVisivel = true;
            else
                grbAddMatMed.Text = "Adicionar Mat/Med c/ Estoque Padrão no Almoxarifado";
        }

        private int ObterPrimeiroHorarioPadraoSetor()
        {
            DateTime? dataInicioCorte = this.ObterDataInicioAdmPacientePadrao();
            if (dataInicioCorte != null)
                return dataInicioCorte.Value.Hour;

            return 18;
        }

        private DateTime? ObterDataInicioAdmPacientePadrao()
        {
            int? periodoDoseSetor; DateTime? dtFimCorte;
            return ObterDataInicioAdmPacientePadrao(out periodoDoseSetor, out dtFimCorte);
        }

        private DateTime? ObterDataInicioAdmPacientePadrao(out int? periodoDoseSetor, out DateTime? dtFimCorte)
        {
            RequisicaoDTO dtoReq = new RequisicaoDTO();
            dtoReq.IdtSetor.Value = int.Parse(cmbSetor.SelectedValue.ToString());
            dtoReq = gen.ObterSetorPedidoAutomaticoVigencia(dtoReq);
            if (dtoReq != null)
            {
                periodoDoseSetor = (int)dtoReq.SetorPedidoAutoHorasPeriodoDose.Value;
                DateTime dataInicioEmissao;
                DateTime dtInicioCorte = RequisicaoItens.ObterDataInicioAdmPacientePadrao(dtoReq, out dataInicioEmissao);
                DateTime dataAtual = Utilitario.ObterDataHoraServidor();
                if (dtInicioCorte.Date == dataAtual.Date)
                    dtFimCorte = DateTime.Parse(dtInicioCorte.AddDays(1).Date.ToString("dd/MM/yyyy") + " " + ((int)dtoReq.SetorPedidoAutoHoraInicioProcesso.Value).ToString().PadLeft(2, '0') + ":00");
                else
                    dtFimCorte = DateTime.Parse(dataAtual.AddDays(1).Date.ToString("dd/MM/yyyy") + " " + ((int)dtoReq.SetorPedidoAutoHoraInicioProcesso.Value).ToString().PadLeft(2, '0') + ":00");
                              
                return dtInicioCorte;
            }
            periodoDoseSetor = null;
            dtFimCorte = null;
            return null;
        }

        private DateTime ObterDataInicioAdmPacienteDigitada(int horaInicioAdmPac)
        {
            DateTime dataAtual = Utilitario.ObterDataHoraServidor();
            try
            {
                DateTime dataInicioAdmPac = DateTime.Parse(dataAtual.Date.ToString("dd/MM/yyyy") + " " + horaInicioAdmPac.ToString().PadLeft(2, '0') + ":00");

                if (SetorPedidoAutomaticoVigencia && dataInicioAdmPac < dataAtual)
                    dataInicioAdmPac = DateTime.Parse(dataAtual.AddDays(1).Date.ToString("dd/MM/yyyy") + " " + horaInicioAdmPac.ToString().PadLeft(2, '0') + ":00");

                return dataInicioAdmPac;
            }
            catch
            {
                return ObterDataInicioAdmPacienteDigitada(int.Parse(ObterPrimeiroHorarioPadraoSetor().ToString()));
            }
        }

        private bool ValidarPrimeiroHorarioDose(DateTime dtHoraAdmPaciente, out DateTime dataUltimoPeriodo)
        {
            int? periodoDoseSetor; DateTime? dtFimCorte;
            DateTime? dataInicioCortePadrao = this.ObterDataInicioAdmPacientePadrao(out periodoDoseSetor, out dtFimCorte);
            dataUltimoPeriodo = dtFimCorte.Value; //dtFimCorte.Value.AddHours(-periodoDoseSetor.Value);
            if (dtHoraAdmPaciente > dataUltimoPeriodo)
                return false;

            return true;
        }

        private int? ObterFuncionalidadeSetor()
        {
            MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();
            dtoCfg.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoCfg.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoCfg.Idtsetor.Value = cmbSetor.SelectedValue.ToString();
            dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);
            if (dtoCfg != null && !dtoCfg.IdFuncionalidade.Value.IsNull)
                return (int)dtoCfg.IdFuncionalidade.Value;
            else
                return null;
        }

        private RequisicaoItensDataTable ObterItensPrescricaoInt(RequisicaoItensDataTable dtbItens)
        {
            dtbRequisicaoItem = new RequisicaoItensDataTable();
            bool itemDeEstoque = false;
            int qtdAntimicrobianosNaoAutorizados = 0;
            int qtdItensEstoque = 0;
            int? idFuncionalidadeSetor = ObterFuncionalidadeSetor();            
            MatMedFuncionalidadeDataTable dtbMatMedFunc = null;
            if (idFuncionalidadeSetor != null)
            {
                FuncionalidadeDTO dtoFuncionalidade = new FuncionalidadeDTO();
                dtoFuncionalidade.Idt.Value = idFuncionalidadeSetor.Value;
                dtoFuncionalidade.FiltraAssociados.Value = 2;
                FuncionalidadeDataTable dtbFuncionalidade = Funcionalidade.Sel(dtoFuncionalidade);
                if (dtbFuncionalidade.TypedRow(0).NmPagina.Value != "EstoqueLocalTodosProdutos")
                {
                    MatMedFuncionalidadeDTO dtoMatMedFunc = new MatMedFuncionalidadeDTO();
                    dtoMatMedFunc.IdFuncionalidade.Value = idFuncionalidadeSetor.Value;
                    dtbMatMedFunc = MatMedFuncionalidade.Sel(dtoMatMedFunc);
                }
            }
            DataRow[] rowsImediatos = dtbItens.Select("FL_IMEDIATO = 'S'");
            if (rowsImediatos.Length > 0)
            {
                for (int nCount = 0; nCount < rowsImediatos.Length; nCount++)
                {
                    DataRow[] rowsItemImediato = dtbItens.Select(string.Format("{0} = {1} AND FL_IMEDIATO = 'S'", MaterialMedicamentoDTO.FieldNames.Idt, rowsImediatos[nCount][MaterialMedicamentoDTO.FieldNames.Idt].ToString()));
                    if (rowsItemImediato.Length > 1) //Se item for duplicado como imediato, agrupar qtd. em um registro só
                    {
                        for (int nCountImedItem = 0; nCountImedItem < rowsItemImediato.Length; nCountImedItem++)
                        {
                            if (nCountImedItem > 0)
                            {
                                if (int.Parse(rowsItemImediato[nCountImedItem][RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString()) == 0) continue;

                                rowsItemImediato[0][RequisicaoItensDTO.FieldNames.QtdSolicitada] = int.Parse(rowsItemImediato[0][RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString()) + int.Parse(rowsItemImediato[nCountImedItem][RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString());
                                rowsItemImediato[0][RequisicaoItensDTO.FieldNames.ObservacaoItem] = rowsItemImediato[0][RequisicaoItensDTO.FieldNames.ObservacaoItem].ToString().Trim() + " / " + rowsItemImediato[nCountImedItem][RequisicaoItensDTO.FieldNames.ObservacaoItem].ToString().Trim();
                                rowsItemImediato[nCountImedItem][RequisicaoItensDTO.FieldNames.QtdSolicitada] = 0;
                            }
                        }                        
                    }
                }
            }

            bool setorImediato = false;
            RequisicaoDTO dtoReqParamSetor = new RequisicaoDTO();
            dtoReqParamSetor.IdtSetor.Value = int.Parse(cmbSetor.SelectedValue.ToString());
            dtoReqParamSetor = gen.ObterSetorPedidoAutomaticoVigencia(dtoReqParamSetor);
            if (dtoReqParamSetor.SetorPedidoAutoFlTotalImediato.Value.IsNull) dtoReqParamSetor.SetorPedidoAutoFlTotalImediato.Value = 0;
            if (dtoReqParamSetor.SetorPedidoAutoFlTotalImediato.Value == 1) setorImediato = true;

            foreach (DataRow row in dtbItens.Rows)
            {
                bool flImediato = row["FL_IMEDIATO"].ToString() == "S" ? true : false;
                //if (!flImediato && setorImediato) flImediato = true;

                if (int.Parse(row[RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString()) == 0 && flImediato)
                {
                    RequisicaoItens.UpdStatusItemPrescricaoInt(null,
                                                               int.Parse(row[RequisicaoItensDTO.FieldNames.IdPrescricaoItemInternacao].ToString()),
                                                               (int)FrmPrincipal.dtoSeguranca.Idt.Value,
                                                               "GE");
                    PrescricaoInternacaoGerada = true;
                    continue;
                }

                dtoMatMed = new MaterialMedicamentoDTO();
                dtoMatMed.Idt.Value = row[MaterialMedicamentoDTO.FieldNames.Idt].ToString();
                dtoMatMed.IdtPrincipioAtivo.Value = row[MaterialMedicamentoDTO.FieldNames.IdtPrincipioAtivo].ToString();
                dtoMatMed = Estoque.ObterSimilarProximoVencimento(dtoMatMed);

                if (dtoMatMed.IdtSubGrupo.Value == ANTIMICROBIANOS_RESTRITOS.ToString())
                {
                    PrescricaoDTO dtoPrescAtm = new PrescricaoDTO();
                    dtoPrescAtm.IdAtendimento.Value = txtNroInternacao.Text;
                    dtoPrescAtm.IdMedicamentoPrescricaoMedica.Value = row[RequisicaoItensDTO.FieldNames.IdPrescricaoItemInternacao].ToString();
                    //dtoPrescAtm.IdProduto.Value = row[MaterialMedicamentoDTO.FieldNames.Idt].ToString();                    
                    PrescricaoDataTable dtbPrescAtm = Prescricao.ListarItem(dtoPrescAtm, true);
                    if (dtbPrescAtm.Rows.Count > 0)
                    {
                        if (!dtbPrescAtm.TypedRow(0).FlAutorizado.Value.IsNull &&
                            dtbPrescAtm.TypedRow(0).FlAutorizado.Value == 0) //ANTIMICROBIANOS_RESTRITOS NÃO AUTORIZADO
                        {
                            qtdAntimicrobianosNaoAutorizados += 1;

                            RequisicaoItens.UpdStatusItemPrescricaoInt(null,
                                                                        int.Parse(row[RequisicaoItensDTO.FieldNames.IdPrescricaoItemInternacao].ToString()),
                                                                        (int)FrmPrincipal.dtoSeguranca.Idt.Value,
                                                                        "GE");
                            PrescricaoInternacaoGerada = true;
                            continue;
                        }
                    }
                }

                itemDeEstoque = false;
                if (dtbMatMedFunc != null)
                {
                    if (dtbMatMedFunc.Select(string.Format("{0}={1}", MaterialMedicamentoDTO.FieldNames.Idt, dtoMatMed.Idt.Value.ToString())).Length > 0)
                    {
                        itemDeEstoque = true;
                    }
                    else if (dtoMatMed.IdtPrincipioAtivo.Value != 0 && 
                                dtbMatMedFunc.Select(string.Format("{0}={1}", MaterialMedicamentoDTO.FieldNames.IdtPrincipioAtivo, dtoMatMed.IdtPrincipioAtivo.Value.ToString())).Length > 0)
                    {
                        itemDeEstoque = true;
                    }
                    if (itemDeEstoque)
                    {
                        qtdItensEstoque += 1;

                        RequisicaoItens.UpdStatusItemPrescricaoInt(null,
                                                                    int.Parse(row[RequisicaoItensDTO.FieldNames.IdPrescricaoItemInternacao].ToString()),
                                                                    (int)FrmPrincipal.dtoSeguranca.Idt.Value,
                                                                    "GE");
                        PrescricaoInternacaoGerada = true;
                        continue;
                    }
                }

                dtoRequisicaoItem = (RequisicaoItensDTO)row;
                dtoRequisicaoItem.IdtProduto.Value = dtoMatMed.Idt.Value;
                dtoRequisicaoItem.DsProduto.Value = dtoMatMed.NomeFantasia.Value;
                dtoRequisicaoItem.DsUnidadeVenda.Value = dtoMatMed.DsUnidadeVenda.Value;
                dtoRequisicaoItem.UnidadeVenda.Value = dtoMatMed.UnidadeVenda.Value;
                dtoRequisicaoItem.UnidadeControle.Value = dtoMatMed.UnidadeControle.Value;
                dtoRequisicaoItem.UnidadeCompra.Value = dtoMatMed.UnidadeCompra.Value;
                    
                DateTime dataAtual = Utilitario.ObterDataHoraServidor();
                if (flImediato)
                {
                    if (SetorPedidoAutomaticoVigencia && !string.IsNullOrEmpty(row["HORA_ADM_PAC"].ToString()))
                    {
                        string horaAdmPac = row["HORA_ADM_PAC"].ToString().Substring(0, 2);
                        DateTime dataInicioAdmPac = DateTime.Parse(dataAtual.Date.ToString("dd/MM/yyyy") + " " + horaAdmPac.ToString().PadLeft(2, '0') + ":00");
                        if (dataInicioAdmPac.Subtract(dataAtual).Hours >= 12)
                            dataInicioAdmPac = dataInicioAdmPac.AddDays(-1);
                        //else if (setorImediato && dataInicioAdmPac.Subtract(dataAtual).Hours >= 23)
                        //    dataInicioAdmPac = dataInicioAdmPac.AddDays(-1);
                            
                        dtoRequisicaoItem.DataHoraAdmPaciente.Value = dataInicioAdmPac;
                    }
                    else
                        dtoRequisicaoItem.DataHoraAdmPaciente.Value = Utilitario.ObterDataHoraServidor().AddMinutes(2); //Utilitario.ObterDataHoraServidor().AddHours(1).ToString("dd/MM/yyyy HH:00");

                    dtoRequisicaoItem.HorasPeriodoDose.Value = new Framework.DTO.TypeDecimal();
                }
                else
                {   
                    if (string.IsNullOrEmpty(row["HORA_ADM_PAC"].ToString()))
                        row["HORA_ADM_PAC"] = ObterDataInicioAdmPacienteDigitada(int.Parse(ObterPrimeiroHorarioPadraoSetor().ToString()));

                    string horaAdmPac = row["HORA_ADM_PAC"].ToString().Substring(0, 2);
                    DateTime dtHoraAdmPaciente;
                    DateTime dataPrescricao = DateTime.Parse(row["DT_HORA_PRESCRICAO"].ToString());
                    if (dataPrescricao.Date == dataAtual.AddDays(-1).Date) //Prescrição de ontem
                        dtHoraAdmPaciente = DateTime.Parse(dataAtual.Date.ToString("dd/MM/yyyy") + " " + horaAdmPac.ToString().PadLeft(2, '0') + ":00");
                    else
                        dtHoraAdmPaciente = this.ObterDataInicioAdmPacienteDigitada(int.Parse(horaAdmPac));

                    if (setorImediato && dtHoraAdmPaciente.Subtract(dataAtual).Hours >= 20) //Neste caso médico deve ter colocado uma hora de hoje anterior
                        dtHoraAdmPaciente = dtHoraAdmPaciente.AddDays(-1);
                        
                    if (!SetorPedidoAutomaticoVigencia)
                    {
                        dtoRequisicaoItem.DataHoraAdmPaciente.Value = dtHoraAdmPaciente;
                    }
                    else
                    {
                        DateTime dataUltimoPeriodo;
                        if (ValidarPrimeiroHorarioDose(dtHoraAdmPaciente, out dataUltimoPeriodo))
                        {
                            dtoRequisicaoItem.DataHoraAdmPaciente.Value = dtHoraAdmPaciente;
                        }
                        else
                        {
                            dtoRequisicaoItem.DataHoraAdmPaciente.Value = dataUltimoPeriodo;
                        }
                    }
                }

                this.AdicionarItemTable(dtoRequisicaoItem);                          
            }

            if (qtdAntimicrobianosNaoAutorizados > 0)
            {
                MessageBox.Show("AVISO: A prescrição original tem " + qtdAntimicrobianosNaoAutorizados + " Antimicrobiano(s) Restrito(s) não autorizado(s).", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (qtdItensEstoque > 0)
            {
                MessageBox.Show("AVISO: A prescrição original tem " + qtdItensEstoque + " item(ns) de estoque que não é incluido neste pedido.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            RequisicaoItensDTO dtoItensRemovidos = new RequisicaoItensDTO();
            dtoItensRemovidos.IdPrescricaoInternacao.Value = ID_PrescricaoInternacao.Value;
            dtbItensRemovidosPrescricao = RequisicaoItens.ListarItensGeradosPrescricaoInt_SemPedidoGestao(dtoItensRemovidos);
            btnItensRemovidos.Visible = dtbItensRemovidosPrescricao.Rows.Count > 0;
            btnObs.Visible = true;

            return dtbRequisicaoItem;
        }

        /// Solução alternativa para atualizar o grid quando está em edição.        
        private void AtualizaGridEmEdicao()
        {
            chkAjudaAtualizarGrid.Visible = true;
            chkAjudaAtualizarGrid.Focus();
            chkAjudaAtualizarGrid.Visible = false;
        }

        #endregion

        #region EVENTOS

        private void FrmPersonalizado_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            grpTipoAtendimento.Enabled = false;
            ConfiguraDTG();
            cmbPeriodoGerar.Carregar();            
            //txtUsuario.Text = FrmPrincipal.dtoSeguranca.NmUsuario.Value;
            cmbUnidade.Carregaunidade();
            if (ID_PrescricaoInternacao == null)
            {
                Generico.ConfiguraCombos(cmbUnidade, cmbLocal, cmbSetor, FrmPrincipal.dtoSeguranca);
                SetorPedidoAutomaticoVigencia = gen.SetorPedidoAutomaticoVigencia(int.Parse(cmbSetor.SelectedValue.ToString()));
                ConfiguraTipoAtendimento();
                //dtgPersonalisado.Columns[colQtde.Name].ReadOnly = true;
                if (!_ultrapassouCorte)
                {
                    _carregarCombo = true;
                    ExecThreadComboMatMed();
                    btnAdd.GotFocus += btnAdd_GotFocus;
                }
            }
            else
            {
                tsHac.Controla(Evento.eNovo);
                lblPrescricao.Visible = tsbImprimirPrescricao.Visible = true; lblPrescricao.Text = "Prescrição: " + ID_PrescricaoInternacao.Value;
                if (dtoRequisicao.IdtSetor.Value == 22) //22 = Admissao
                {
                    cmbSetor.Internacao = false;
                    cmbSetor.ComEstoque = false;
                }
                cmbUnidade.SelectedValue = dtoRequisicao.IdtUnidade.Value;
                cmbLocal.SelectedValue = dtoRequisicao.IdtLocal.Value;                
                cmbSetor.SelectedValue = dtoRequisicao.IdtSetor.Value;
                SetorPedidoAutomaticoVigencia = gen.SetorPedidoAutomaticoVigencia(int.Parse(cmbSetor.SelectedValue.ToString()));
                cmbUnidade.Enabled = cmbLocal.Enabled = cmbSetor.Enabled = false;
                cbAntimicrobianos.Visible = false;
                tsHac.CancelarVisivel = tsHac.NovoVisivel = false;
                if (!_ultrapassouCorte)
                {
                    _carregarCombo = true;
                    ExecThreadComboMatMed();
                    btnAdd.GotFocus += btnAdd_GotFocus;
                }
                ConfiguraTipoAtendimento();
                txtNroInternacao.Text = dtoRequisicao.IdtAtendimento.Value;
                txtNroInternacao_Validating(sender, null);                    
            }            
            //VerificaEstoqueUnificado();            
            if (ID_PrescricaoInternacao != null && _ultrapassouCorte)
            {
                cmbMatMed.Enabled = btnAdd.Enabled = false;
            }
            else
                HabilitarBotaoMatMedSuperior();

            HabilitarKitItemGrid();
            if (cmbLocal.Text == "AMBULATORIO")
                rbAmbulatorio.Checked = true;
            else
                rbInternado.Checked = true;            
            this.Cursor = Cursors.Default;
        }        

        private void btnPesquisaPac_Click(object sender, EventArgs e)
        {
            if (!ValidarSetor()) return;
            // if (txtNroInternacao.Enabled) this.PesquisarPaciente();
            if (txtNroInternacao.Enabled)
            {
                CarregaInfoPaciente();
                _carregarCombo = false;
                ExecThreadComboMatMed();
                //cmbMatMed.Enabled = false;
            }            
        }
        
        private void txtNroInternacao_Validating(object sender, CancelEventArgs e)
        {
            if (txtNroInternacao.Text.Length != 0)
            {
                btnPesquisaPac_Click(sender, e);
                tsHac.Items["tsBtnPesquisar"].Enabled = true;                
            }
        }

        private void txtQtdReq_Validating(object sender, CancelEventArgs e)
        {

        }

        private bool tsHac_CancelarClick(object sender)
        {
            if (cbAntimicrobianos.Checked)
            {
                _carregarCombo = true;
                ExecThreadComboMatMed();
            }
            cbAntimicrobianos.Visible = grpTipoAtendimento.Visible = cmbKit.Enabled = grbAddMatMed.Visible = dtgPersonalisado.Enabled = true;
            cmbKit.Visible = lblKit.Visible = lblKitDsc.Visible = btnCancelarKit.Visible = 
            tsbPrescricoes.Visible = tsbImprimirPrescricao.Visible= btnPesquisaPac.Visible = grbAddMatMed.Enabled = false;            
            dtoRequisicao = null;
            dtoAtendimento = null;
            dtoPrescricao = null;
            _dtbMatMedTrocaMemoria = null;
            // cmbMatMed.IniciaLista();
            return true;
        }
        
        private bool tsHac_NovoClick(object sender)
        {
            cbAntimicrobianos.Visible = btnPesquisaPac.Visible = grpTipoAtendimento.Visible = cmbKit.Enabled = grbAddMatMed.Visible = dtgPersonalisado.Enabled = true;
            tsbPrescricoes.Visible = tsbImprimirPrescricao.Visible = cmbKit.Visible = lblKit.Visible = lblKitDsc.Visible = btnCancelarKit.Visible = false;
            dtoRequisicao = null;
            dtoAtendimento = null;
            dtoPrescricao = null;
            _dtbMatMedTrocaMemoria = null;
            tsHac.NomeControleFoco = txtNroInternacao.Name;
            _carregarCombo = false;
            // ExecThreadComboMatMed();
            HabilitarBotaoMatMedSuperior();
            return true;
        }

        private bool tsHac_SalvarClick(object sender)
        {
            this.AtualizaGridEmEdicao();
            return this.Salvar();
        }

        private bool tsHac_MatMedClick(object sender)
        {
            if (cbAntimicrobianos.Checked) return false;
            if (!ValidarSetor()) return false;
            if (!ValidarPaciente()) return false;
            
            //TODO: PASSAR CONVÊNIO COMO PARÂMETRO PARA TELA DE PESQUISA MATERIAIS
            ConfiguraRequisicaoDTO();

            dtoMatMed = new MaterialMedicamentoDTO();
            SetorDTO dtoSetor = new SetorDTO();

            dtoSetor.Idt.Value = dtoRequisicao.IdtSetor.Value;
            dtoSetor.IdtLocalAtendimento.Value = dtoRequisicao.IdtLocal.Value;
            dtoSetor.IdtUnidade.Value = dtoRequisicao.IdtUnidade.Value;

            dtoMatMed.IdtUnidade.Value = dtoSetor.IdtUnidade.Value;
            dtoMatMed.IdtLocal.Value = dtoSetor.IdtLocalAtendimento.Value;
            dtoMatMed.IdtSetor.Value = dtoSetor.Idt.Value;
            //dtoMatMed.IdtFilial.Value = dtoRequisicao.IdtFilial.Value;
            dtoMatMed.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.COM_PERMISSAO_SUBGRUPO;

            //dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(dtoSetor, MaterialMedicamentoDTO.TipoMatMed.TODOS, (byte)dtoRequisicao.IdtFilial.Value);
            dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMed);            

            if (dtoMatMed != null)
            {
                if (dtoMatMed.IdtGrupo.Value == 1 && dtoMatMed.IdtSubGrupo.Value.ToString() == ANTIMICROBIANOS_RESTRITOS.ToString())
                {
                    MessageBox.Show("Antimicrobiano restrito não pode ser inserido por esta funcionalidade.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtoMatMed = null;
                    return false;
                }
                cmbMatMed.IniciaLista();
                txtQtdReq.Enabled = btnAdd.Enabled = false;
                return this.AdicionarItem(null);
            }            

            return true;
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            if (!ValidarSetor()) return false;
            if (!ValidarPaciente()) return false;

            FrmPedidos.Pesquisar(dtoRequisicao);
            return true;
        }

        private void tsbPrescricoes_Click(object sender, EventArgs e)
        {
            if (!ValidarSetor()) return;
            if (txtNroInternacao.Text != string.Empty && txtNomePac.Text != string.Empty)
            {
                this.Cursor = Cursors.WaitCursor;
                PrescricaoDTO dtoPrescricaoRetorno = FrmPrescricaoPesquisa.PesquisarPendenciasPaciente(decimal.Parse(txtNroInternacao.Text.Trim()));

                if (dtoPrescricaoRetorno != null && !dtoPrescricaoRetorno.IdProduto.Value.IsNull)
                {
                    if ((int)dtoPrescricaoRetorno.QtdDia.Value == 0)
                    {
                        MessageBox.Show("Item já solicitado hoje para este paciente, atingindo seu limite diário!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Cursor = Cursors.Default;
                        return;
                    }

                    dtoPrescricao = dtoPrescricaoRetorno;
                    bool carregarComboNovamente = false;
                    try
                    {
                        cmbMatMed.SelectedValue = dtoPrescricao.IdProduto.Value;
                        if (cmbMatMed.SelectedValue == null) carregarComboNovamente = true;
                    }
                    catch
                    {
                        carregarComboNovamente = true;
                    }
                    if (carregarComboNovamente)
                    {
                        PrescricaoDTO dtoItem = new PrescricaoDTO();
                        dtoItem.IdAtendimento.Value = txtNroInternacao.Text;
                        PrescricaoDataTable dtbPresc = Prescricao.ListarItem(dtoItem, true);
                        cmbMatMed.DataSource = dtbPresc;
                        cmbMatMed.SelectedValue = dtoPrescricao.IdProduto.Value;
                    }
                    txtQtdReq.Text = dtoPrescricao.QtdDia.Value;
                    txtQtdReq.Enabled = true;
                }                

                this.Cursor = Cursors.Default;
            }
        }

        private void dtgPersonalisado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {      
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                int idProduto = int.Parse(dtgPersonalisado.Rows[e.RowIndex].Cells[colMatMedIdt.Name].Value.ToString());
                if (dtgPersonalisado.Columns[e.ColumnIndex].Name == colDeletar.Name)
                {
                    if (ID_PrescricaoInternacao == null || dtgPersonalisado.Rows[e.RowIndex].Cells[colIdPrescricaoItemInternacao.Name].Value.ToString() == string.Empty)
                    {
                        if (MessageBox.Show("Deseja excluir esse produto da lista ?",
                                             "Gestão de Materiais e Medicamentos",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ExcluirItem(idProduto);
                        }
                    }
                    else
                        ExcluirItem(idProduto);
                }
                else if (dtgPersonalisado.Columns[e.ColumnIndex].Name == colKitAssociado.Name &&
                         int.Parse(dtgPersonalisado.Rows[e.RowIndex].Cells[colQtde.Name].Value.ToString()) > 0)
                {
                    MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();
                    dtoMatMed.Idt.Value = idProduto;
                    dtoMatMed = MatMed.SelChave(dtoMatMed);
                    if (dtoMatMed.IdtGrupo.Value != 1 || dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM)
                    {
                        MessageBox.Show("Permitido associar Kit apenas à medicamento inteiro.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //else if (ID_PrescricaoInternacao != null && dtoMatMed.IdtGrupo.Value == 1 && dtgPersonalisado.Rows[e.RowIndex].Cells[colPeriodoDose.Name].Value.ToString() == string.Empty)
                    //{
                    //    MessageBox.Show("Não permitido associar Kit a um medicamento imediato.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}
                    bool removerItens = false;
                    KitDataTable dtbKitItens = null;
                    int? idKitJaSelecionado = null;
                    int qtdKitItemMultiplica = int.Parse(dtgPersonalisado.Rows[e.RowIndex].Cells[colQtde.Name].Value.ToString());
                    if (!string.IsNullOrEmpty(dtgPersonalisado.Rows[e.RowIndex].Cells[colKitItemID.Name].Value.ToString()))
                    {
                        idKitJaSelecionado = int.Parse(dtgPersonalisado.Rows[e.RowIndex].Cells[colKitItemID.Name].Value.ToString());
                        KitDTO dtoKit = new KitDTO();
                        dtoKit.IdKit.Value = (int)idKitJaSelecionado.Value;
                        if (!string.IsNullOrEmpty(dtgPersonalisado.Rows[e.RowIndex].Cells[colQtdKitItemMultiplica.Name].Value.ToString()))
                            qtdKitItemMultiplica = int.Parse(dtgPersonalisado.Rows[e.RowIndex].Cells[colQtdKitItemMultiplica.Name].Value.ToString());
                        dtbKitItens = FrmAdicionarKit.SelecionarKit(dtoKit, out removerItens, ref qtdKitItemMultiplica);
                    }
                    else
                        dtbKitItens = FrmAdicionarKit.SelecionarKit(null, out removerItens, ref qtdKitItemMultiplica);

                    if (dtbKitItens != null && dtbKitItens.Rows.Count > 0)
                    {
                        KitDTO dtoKit = new KitDTO();
                        dtoKit.IdKit.Value = dtbKitItens.TypedRow(0).IdKit.Value;
                        dtoKit = Kit.Listar(dtoKit).TypedRow(0);

                        if (dtbRequisicaoItem == null) dtbRequisicaoItem = new RequisicaoItensDataTable();
                        if (dtbRequisicaoItem.Columns.IndexOf("CAD_MTMD_KIT_DSC_ITEM") == -1)
                            dtbRequisicaoItem.Columns.Add("CAD_MTMD_KIT_DSC_ITEM");

                        if (removerItens)
                        {
                            DataRow rowMedicamento = dtbRequisicaoItem.Select(string.Format("{0} = {1}", RequisicaoItensDTO.FieldNames.IdtProduto, dtoMatMed.Idt.Value))[0];
                            rowMedicamento[RequisicaoItensDTO.FieldNames.IdKitItem] = DBNull.Value;
                            rowMedicamento["CAD_MTMD_KIT_DSC_ITEM"] = DBNull.Value;
                            rowMedicamento[RequisicaoItensDTO.FieldNames.QtdKitItemMultiplica] = DBNull.Value;

                            dtgPersonalisado.Rows[e.RowIndex].Cells[colKitItemID.Name].Value = rowMedicamento[RequisicaoItensDTO.FieldNames.IdKitItem];
                            dtgPersonalisado.Rows[e.RowIndex].Cells[colKitAssociado.Name].Value = rowMedicamento["CAD_MTMD_KIT_DSC_ITEM"];

                            CarregarItensKit(dtbKitItens, qtdKitItemMultiplica, true, null);
                        }
                        else if (idKitJaSelecionado == null)
                        {
                            DataRow rowMedicamento = dtbRequisicaoItem.Select(string.Format("{0} = {1}", RequisicaoItensDTO.FieldNames.IdtProduto, dtoMatMed.Idt.Value))[0];
                            rowMedicamento[RequisicaoItensDTO.FieldNames.IdKitItem] = dtoKit.IdKit.Value;
                            rowMedicamento["CAD_MTMD_KIT_DSC_ITEM"] = dtoKit.Descricao.Value;
                            rowMedicamento[RequisicaoItensDTO.FieldNames.QtdKitItemMultiplica] = qtdKitItemMultiplica;

                            dtgPersonalisado.Rows[e.RowIndex].Cells[colKitItemID.Name].Value = rowMedicamento[RequisicaoItensDTO.FieldNames.IdKitItem];
                            dtgPersonalisado.Rows[e.RowIndex].Cells[colKitAssociado.Name].Value = rowMedicamento["CAD_MTMD_KIT_DSC_ITEM"];

                            int? periodoAplicacao = null;
                            if (ID_PrescricaoInternacao != null && dtgPersonalisado.Rows[e.RowIndex].Cells[colPeriodoDose.Name].Value.ToString() != string.Empty)
                                periodoAplicacao = int.Parse(dtgPersonalisado.Rows[e.RowIndex].Cells[colPeriodoDose.Name].Value.ToString());

                            CarregarItensKit(dtbKitItens, qtdKitItemMultiplica, false, periodoAplicacao);
                        }
                        else if (idKitJaSelecionado != null && idKitJaSelecionado.Value != dtoKit.IdKit.Value)
                        {
                            MessageBox.Show("Kit associado não pode ser modificado, favor remover a associação atual para realizar uma nova.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void dtgPersonalisado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dtgPersonalisado.Rows[e.RowIndex].Cells[colIdSubgrupo.Name].Value != null)
                {
                    if (dtgPersonalisado.Rows[e.RowIndex].Cells[colIdSubgrupo.Name].Value.ToString() == string.Empty)
                        dtgPersonalisado.Rows[e.RowIndex].Cells[colIdSubgrupo.Name].Value = 0;

                    if (int.Parse(dtgPersonalisado.Rows[e.RowIndex].Cells[colIdSubgrupo.Name].Value.ToString()) == PSICOTROPICO1 ||
                        int.Parse(dtgPersonalisado.Rows[e.RowIndex].Cells[colIdSubgrupo.Name].Value.ToString()) == PSICOTROPICO2)
                    {
                        dtgPersonalisado.Rows[e.RowIndex].Cells[colDsProd.Name].Style.BackColor = Color.Orange;
                        dtgPersonalisado.Rows[e.RowIndex].Cells[colDsProd.Name].Style.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                        lblLaranja.Visible = lblPsico.Visible = true;
                    }
                    else if (int.Parse(dtgPersonalisado.Rows[e.RowIndex].Cells[colIdSubgrupo.Name].Value.ToString()) == PROFILATICO)
                    {
                        dtgPersonalisado.Rows[e.RowIndex].Cells[colDsProd.Name].Style.BackColor = Color.Yellow;
                        dtgPersonalisado.Rows[e.RowIndex].Cells[colDsProd.Name].Style.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                        lblAmarelo.Visible = lblProfila.Visible = true;
                    }
                }

                if (dtgPersonalisado.Rows[e.RowIndex].Cells[colQtde.Name].Value != null)
                {
                    if (ID_PrescricaoInternacao != null && dtgPersonalisado.Rows[e.RowIndex].Cells[colPeriodoDose.Name].Value.ToString() == string.Empty &&
                        int.Parse(dtgPersonalisado.Rows[e.RowIndex].Cells[colQtde.Name].Value.ToString()) > 0)
                    {
                        dtgPersonalisado.Rows[e.RowIndex].Cells[colQtde.Name].Style.BackColor = Color.LightGreen;
                        lblVerde.Visible = lblImediato.Visible = true;
                    }
                }
            }
        }

        private void dtgPersonalisado_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dtgPersonalisado.Columns[e.ColumnIndex].Name == colQtde.Name)
            {
                tsHac.SalvarVisivel = false;
                if (!string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    if (dtgPersonalisado.Rows[e.RowIndex].DefaultCellStyle.BackColor != Color.LightGray)
                    {
                        if (!this.IsNumber(e.FormattedValue.ToString()))
                        {
                            MessageBox.Show("Qtd. Máx. deve ser numérico", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            e.Cancel = true;
                        }
                        else if (e.FormattedValue.ToString().IndexOf(',') > -1)
                        {
                            MessageBox.Show("Qtd. Máx. deve ser um número inteiro", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            e.Cancel = true;
                        }
                        else if (int.Parse(e.FormattedValue.ToString()) <= 0)
                        {
                            MessageBox.Show("Qtd. Máx. deve ser maior que 0", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            e.Cancel = true;
                        }
                        else
                            tsHac.SalvarVisivel = true;
                    }
                    else
                        tsHac.SalvarVisivel = true;
                }                
            }
        }

        private void dtgPersonalisado_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dtgPersonalisado.Columns[e.ColumnIndex].Name == colQtde.Name)
            {
                this.Cursor = Cursors.WaitCursor;

                int qtd = int.Parse(dtgPersonalisado.Rows[e.RowIndex].Cells[colQtde.Name].Value.ToString());
                //MaterialMedicamentoDTO dtoMatMedRef = new MaterialMedicamentoDTO();
                //dtoMatMedRef.Idt.Value = dtgPersonalisado.Rows[e.RowIndex].Cells[colMatMedIdt.Name].Value.ToString();

                DataRow rowItem = dtbRequisicaoItem.Select(string.Format("{0} = {1}",
                                                                           RequisicaoItensDTO.FieldNames.IdtProduto,
                                                                           dtgPersonalisado.Rows[e.RowIndex].Cells[colMatMedIdt.Name].Value.ToString()))[0];
                rowItem[RequisicaoItensDTO.FieldNames.QtdSolicitada] = qtd;

                tsHac.SalvarVisivel = true;

                this.Cursor = Cursors.Default;
            }            
        }

        private void dtgPersonalisado_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1 && dtgPersonalisado.Columns[e.ColumnIndex].Name == colItemGeladeira.Name)
            {
                this.Cursor = Cursors.WaitCursor;

                DataRow rowItem = dtbRequisicaoItem.Select(string.Format("{0} = {1}",
                                                                         RequisicaoItensDTO.FieldNames.IdtProduto,
                                                                         dtgPersonalisado.Rows[e.RowIndex].Cells[colMatMedIdt.Name].Value.ToString()))[0];

                if (bool.Parse(dtgPersonalisado.Rows[e.RowIndex].Cells[colItemGeladeira.Name].EditedFormattedValue.ToString()))
                    rowItem[RequisicaoItensDTO.FieldNames.FlItemGeladeira] = 1;
                else
                    rowItem[RequisicaoItensDTO.FieldNames.FlItemGeladeira] = 0;

                tsHac.SalvarVisivel = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void dtgPersonalisado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dtgPersonalisado_MouseDown(object sender, MouseEventArgs e)
        {
            if (dtgPersonalisado.Rows.Count > 0)
            {
                dtgPersonalisado.ClearSelection();
                int curRowIndex = dtgPersonalisado.HitTest(e.X, e.Y).RowIndex;
                int curColumnIndex = dtgPersonalisado.HitTest(e.X, e.Y).ColumnIndex;
                if (curRowIndex >= 0 && curRowIndex != dtgPersonalisado.NewRowIndex)
                {
                    dtgPersonalisado.Rows[curRowIndex].Selected = true;
                    dtgPersonalisado.CurrentCell = dtgPersonalisado.Rows[curRowIndex].Cells[curColumnIndex];
                }
            }
        }   

        private void dtgPersonalisado_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (dtgPersonalisado.CurrentCell.Selected) e.Control.KeyPress += this.CellNumber_KeyPress;
        }

        private void CellNumber_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnCancelarKit_Click(object sender, EventArgs e)
        {
            dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.CANCELADA;
            Requisicao.Upd(dtoRequisicao);

            tsHac_CancelarClick(sender);
            tsHac.Controla(Evento.eCancelar);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbMatMed.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o Mat/Med", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMatMed.Focus();
                return;
            }
            else if (txtQtdReq.Text == string.Empty ||  Convert.ToDecimal( txtQtdReq.Text) <= 0 )
            {
                MessageBox.Show("Digite a Qtd. Requis.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQtdReq.Focus();
                return;
            }
            else if (decimal.Parse(txtQtdReq.Text) <= 0)
            {
                MessageBox.Show("Qtd. Requis. deve ser maior que 0", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQtdReq.Focus();
                return;
            }
            if (cbAntimicrobianos.Checked) 
            {
                if (dtoPrescricao == null || dtoPrescricao.IdPrescricao.Value.IsNull)
                {
                    MessageBox.Show("Item de prescrição não selecionado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!ValidarItemPrescricao((decimal)dtoPrescricao.IdPrescricao.Value, (decimal)dtoPrescricao.IdProduto.Value, null, int.Parse(txtQtdReq.Text))) return;
            }

            this.Cursor = Cursors.WaitCursor;

            MaterialMedicamentoDTO dto = new MaterialMedicamentoDTO();

            ConfiguraRequisicaoDTO();

            if (dtoMatMed != null && !dtoMatMed.Idt.Value.IsNull)
            {
                if (dtoMatMed.Idt.Value.ToString() != cmbMatMed.SelectedValue.ToString())
                {
                    dto.Idt.Value = cmbMatMed.SelectedValue.ToString();
                    dtoMatMed = MatMed.SelChave(dto);
                }
            }
            else
            {
                dto.Idt.Value = cmbMatMed.SelectedValue.ToString();
                dtoMatMed = MatMed.SelChave(dto);
            }            

            if (!cbAntimicrobianos.Checked)
            {
                MatMedSimilarDTO dtoSimilar = new MatMedSimilarDTO();
                dtoSimilar.IdPrincipioAtivo.Value = dtoMatMed.IdtPrincipioAtivo.Value;
                dtoSimilar.IdProduto.Value = dtoMatMed.Idt.Value;
                dtoSimilar.FlAtivo.Value = (byte)MatMedSimilarDTO.Ativo.SIM;
                MaterialMedicamentoDTO dtoMatMedAntimicrobiano = new MaterialMedicamentoDTO();
                dtoMatMedAntimicrobiano.IdtGrupo.Value = 1;
                dtoMatMedAntimicrobiano.IdtSubGrupo.Value = ANTIMICROBIANOS_RESTRITOS;
                MatMedSimilarDataTable dtbSimilarAntimicrobiano = Similar.ListarSimilares(dtoSimilar, dtoMatMedAntimicrobiano);
                if (dtbSimilarAntimicrobiano.Rows.Count > 0)
                {
                    MessageBox.Show("Item não pode ser similar a nenhum Antimicrobiano de Uso Restrito.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Cursor = Cursors.Default;
                    return;
                }
            }

            this.AdicionarItem(int.Parse(txtQtdReq.Text));

            cbAntimicrobianos.Enabled = false;

            // cmbMatMed.IniciaLista();
            txtQtdReq.Text = txtHora1.Text = string.Empty;
            cmbMatMed.SelectedIndex = -1;
            cmbMatMed.Text = "<Selecione>";
            cmbMatMed.Focus();

            cmbKit.Enabled = false;

            this.Cursor = Cursors.Default;
        }

        protected void btnAdd_GotFocus(object sender, EventArgs e)
        {
            if (txtQtdReq.Text == string.Empty) txtQtdReq.Focus();
        }

        private void cmbMatMed_KeyUp(object sender, KeyEventArgs e)
        {
            Boolean _processa = true;
            if ((e.KeyValue >= 97 && e.KeyValue <= 122) && _processa )
            {
                cmbMatMed.DroppedDown = true;
                // cmbMatMed.SelectionLength = 0;
                // cmbMatMed.Text = string.Empty;
                
            }
            else if (e.KeyValue >= 65 && e.KeyValue <= 90 && _processa)
            {
                cmbMatMed.DroppedDown = true;
                // cmbMatMed.SelectionLength = 0;
                // cmbMatMed.Text = string.Empty;
                
            }
            else if (cmbMatMed.SelectedIndex != -1)
            {
                //Se teclar enter, foca qtd.
                if (e.KeyValue == 13)
                {
                    cmbMatMed.DroppedDown = false;
                    _processa = false;
                    txtQtdReq.Enabled = true;
                    btnAdd.Enabled = true;
                    txtQtdReq.Focus();
                }
            }
        }

        private void cmbMatMed_DropDown(object sender, EventArgs e)
        {
            // cmbMatMed.SelectionLength = 0;
        }

        private void cmbMatMed_Enter(object sender, EventArgs e)
        {
            cmbMatMed.DroppedDown = true;
        }

        private void cmbMatMed_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbPeriodoGerar.Enabled = txtHora1.Enabled = false;
            cmbPeriodoGerar.IniciaLista();
            txtHora1.Text = string.Empty;

            if (cmbMatMed.SelectedIndex > -1)
            {
                this.Cursor = Cursors.WaitCursor;
                MaterialMedicamentoDTO dto = new MaterialMedicamentoDTO();

                dto.Idt.Value = cmbMatMed.SelectedValue.ToString();
                dtoMatMed = MatMed.SelChave(dto);

                if (GerarPedidoAutomaticoSetor() && MatMed.ProdutoPedidoAutomatico(dtoMatMed) && !cbUrgente.Checked && !cbAntimicrobianos.Checked)
                {
                    cmbPeriodoGerar.Enabled = txtHora1.Enabled = true;
                    txtHora1.Text = ObterPrimeiroHorarioPadraoSetor().ToString();
                }

                txtQtdReq.Focus();
                this.Cursor = Cursors.Default;
            }
        }

        private void cmbPeriodoGerar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbPeriodoGerar.SelectedIndex > -1 && cmbPeriodoGerar.SelectedValue.ToString() == "-1" && cmbPeriodoGerar.Items.Count > 1)
                cmbPeriodoGerar.SelectedIndex = 1;

            if (cmbPeriodoGerar.SelectedIndex > -1 && cmbPeriodoGerar.SelectedValue.ToString() != "-1")
                btnAdd.Focus();
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            tsHac.Controla(Evento.eCancelar);
            tsbPrescricoes.Visible = tsbImprimirPrescricao.Visible= cbAntimicrobianos.Checked = false;
            dtoRequisicao = null;
            dtoAtendimento = null;
            dtoPrescricao = null;
            _dtbMatMedTrocaMemoria = null;
            _carregarCombo = true;
            ExecThreadComboMatMed();
            //VerificaEstoqueUnificado();
            HabilitarBotaoMatMedSuperior();
            ConfiguraTipoAtendimento();
            HabilitarKitItemGrid();
            SetorPedidoAutomaticoVigencia = gen.SetorPedidoAutomaticoVigencia(int.Parse(cmbSetor.SelectedValue.ToString()));
            this.Cursor = Cursors.Default;
        }

        private void cmbLocal_SelectionChangeCommitted(object sender, EventArgs e)
        {            
            tsHac.Controla(Evento.eCancelar);
        }

        private void cmbUnidade_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LimpaComboMatMed();
            tsHac.Controla(Evento.eCancelar);
        }

        private void cmbKit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbKit.SelectedIndex > -1)
            {
                CarregarItensKit(null, 1, false, null);
                dtgPersonalisado.Columns[colDeletar.Name].Visible = false;
                tsHac.MatMedVisivel = grbAddMatMed.Visible = dtgPersonalisado.Columns[colKitAssociado.Name].Visible = false;
                tsbPrescricoes.Visible = tsbImprimirPrescricao.Visible = cbAntimicrobianos.Visible = cbAntimicrobianos.Enabled = false;
            }            
        }

        private void cbMAV_Click(object sender, EventArgs e)
        {

        }

        private void cbPsico_Click(object sender, EventArgs e)
        {

        }

        private void cbAntimicrobianos_Click(object sender, EventArgs e)
        {
            if (!ValidarPaciente())
            {
                cbAntimicrobianos.Checked = false;
                return;
            }
            
            tsbPrescricoes.Visible = tsbImprimirPrescricao.Visible= cmbMatMed.Enabled = false;
            
            _carregarCombo = true;
            ExecThreadComboMatMed();

            if (cbAntimicrobianos.Checked)
            {
                tsbPrescricoes.Visible = tsbImprimirPrescricao.Visible = true;
                cmbMatMed.Enabled = false;
            }
            txtQtdReq.Text = txtHora1.Text = string.Empty;
            txtQtdReq.Enabled = false;            
        }

        private void cbUrgente_Click(object sender, EventArgs e)
        {
            if (cbUrgente.Checked)
            {
                cmbPeriodoGerar.IniciaLista();
                txtHora1.Text = string.Empty;
                cmbPeriodoGerar.Enabled = txtHora1.Enabled = false;
                if (ID_PrescricaoInternacao != null)
                {
                    MessageBox.Show("Todos os itens sairão como URGENTES, favor verificar e alterar quantidades conforme necessidade, pois este pedido sairá uma única vez.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbUrgente.Enabled = false;
                    foreach (DataGridViewRow row in dtgPersonalisado.Rows)
                    {
                        row.Cells[colDataHoraDose.Name].Value = DBNull.Value;
                        row.Cells[colPeriodoDose.Name].Value = DBNull.Value;
                    }
                    dtgPersonalisado.ClearSelection();
                }
                else if (SetorPedidoAutomaticoVigencia)
                    MessageBox.Show("Pedidos URGENTES não geram Pedidos Automáticos (por período da dose), eles são únicos.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (SetorPedidoAutomaticoVigencia)
                {
                    cmbPeriodoGerar.Enabled = txtHora1.Enabled = true;
                    dtbRequisicaoItem = new RequisicaoItensDataTable();
                    dtgPersonalisado.DataSource = dtbRequisicaoItem;
                }
            }
        }

        private void btnGravarJust_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtJustificativaCancel.Text))
            {
                _rowJustificarCancelamento[RequisicaoItensDTO.FieldNames.JustificativaCancelamento] = txtJustificativaCancel.Text;
                _rowJustificarCancelamento[RequisicaoItensDTO.FieldNames.QtdSolicitada] = 0;
                _rowJustificarCancelamento[RequisicaoItensDTO.FieldNames.DoseAdministrar] = DBNull.Value;
                //_rowJustificarCancelamento[RequisicaoItensDTO.FieldNames.HorasPeriodoDose] = DBNull.Value;
                _rowJustificarCancelamento[RequisicaoItensDTO.FieldNames.DataHoraAdmPaciente] = DBNull.Value;

                foreach (DataGridViewRow row in dtgPersonalisado.Rows)
                {
                    if (row.Cells[colMatMedIdt.Name].Value.ToString() == _rowJustificarCancelamento[RequisicaoItensDTO.FieldNames.IdtProduto].ToString() &&
                        row.Cells[colIdPrescricaoItemInternacao.Name].Value.ToString() == _rowJustificarCancelamento[RequisicaoItensDTO.FieldNames.IdPrescricaoItemInternacao].ToString())
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                        row.Cells[colQtde.Name].ReadOnly = true;
                        dtgPersonalisado.ClearSelection();
                        break;
                    }
                }

                btnCancelJust_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Digite a Justificativa.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtJustificativaCancel.Focus();
            }
        }

        private void btnCancelJust_Click(object sender, EventArgs e)
        {
            dtgPersonalisado.Visible = tsHac.SalvarVisivel = tsHac.MatMedVisivel = true;
            grbJustificativa.Visible = false;
            lblMatMed.Text = txtJustificativaCancel.Text = string.Empty;            
        }

        private void btnItensRemovidos_Click(object sender, EventArgs e)
        {
            if (dtbItensRemovidosPrescricao != null && dtbItensRemovidosPrescricao.Rows.Count > 0)
            {
                StringBuilder sbItens = new StringBuilder();
                //sbItens.Append("Os seguintes itens desta Prescrição foram removidos automaticamente do Pedido por serem itens de estoque ou antimicrobianos:\n\n");
                sbItens.Append("Os seguintes itens desta Prescrição foram removidos automaticamente:\n\n");

                foreach (DataRow row in dtbItensRemovidosPrescricao.Rows)
                    sbItens.Append(string.Format("-  {0}\n", row["ITEM"].ToString()));

                MessageBox.Show(sbItens.ToString(), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGravarObs_Click(object sender, EventArgs e)
        {
            if (ID_PrescricaoInternacao != null)
            {
                this.Cursor = Cursors.WaitCursor;

                string categoria = null;
                if (!string.IsNullOrEmpty(txtCategoria.Text.Trim())) categoria = txtCategoria.Text.Trim();

                Requisicao.UpdOBSPrescricaoInt(ID_PrescricaoInternacao.Value, gen.ObterTextoLimitado(txtObs.Text, 500), (int)FrmPrincipal.dtoSeguranca.Idt.Value, categoria);
                
                btnCancelObs_Click(sender, e);

                this.Cursor = Cursors.Default;
            }
        }

        private void btnCancelObs_Click(object sender, EventArgs e)
        {
            dtgPersonalisado.Visible = tsHac.SalvarVisivel = tsHac.MatMedVisivel = true;
            grbObs.Visible = false;            
        }

        private void btnObs_Click(object sender, EventArgs e)
        {
            if (ID_PrescricaoInternacao != null)
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtbPresc = Requisicao.ListarPrescricaoInt(new RequisicaoDTO(), ID_PrescricaoInternacao.Value, null, false);
                if (dtbPresc.Rows.Count > 0)
                {
                    grbObs.Visible = true;
                    dtgPersonalisado.Visible = tsHac.SalvarVisivel = tsHac.MatMedVisivel = false;

                    txtObs.Enabled = txtCategoria.Enabled = txtJustificativaMedica.Enabled = txtObsAnterior.Enabled = true;
                    txtJustificativaMedica.ReadOnly = txtObsAnterior.ReadOnly = true;
                    txtObs.Text = dtbPresc.Rows[0]["OBS_FARMACIA"].ToString();
                    txtCategoria.Text = dtbPresc.Rows[0]["CATEGORIA_INTERV"].ToString();
                    txtJustificativaMedica.Text = dtbPresc.Rows[0]["DS_JUSTIF"].ToString();
                    txtObsAnterior.Text = dtbPresc.Rows[0]["OBS_FARMAC_ANT"].ToString();

                    #region ADD USUARIO OBS

                    UsuarioDTO dtoUsu;
                    string strRegistroDeInicio = " (REGISTRO DE: ";

                    if (txtObsAnterior.Text.IndexOf(strRegistroDeInicio) == -1 && !string.IsNullOrEmpty(dtbPresc.Rows[0]["SEG_USU_ID_INTERV_ANT"].ToString()))
                    {
                        dtoUsu = new UsuarioDTO();
                        dtoUsu.Idt.Value = dtbPresc.Rows[0]["SEG_USU_ID_INTERV_ANT"].ToString();
                        dtoUsu = Usuario.SelChave(dtoUsu);
                        txtObsAnterior.Text += strRegistroDeInicio + dtoUsu.NmUsuario.Value.ToString().Trim() + ")";
                    }

                    #endregion
                    
                    if (string.IsNullOrEmpty(txtObs.Text)) txtObs.Focus();
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void lblPrescricao_DoubleClick(object sender, EventArgs e)
        {
            grpDataAtualizacaoImpressao.Visible = true;
        }

        #endregion        
        
        private void btnReimpressaoTotal_Click(object sender, EventArgs e)
        {
            ImprimirPrescricao(true);
        }

        private void ImprimirPrescricao(bool tudo)
        {
            this.Cursor = Cursors.WaitCursor;
            string nomeRelatorio = "INT_48_PRESCRICAO_MEDICA_NOVA";
            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[5];

            #region Monta Parâmetros

            int x = 0;

            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PATD_PME_ID", ID_PrescricaoInternacao.Value.ToString());
           // reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PSOMENTE_NOVOS", !tudo ? "S" : "");
            
            if (dataAtualizacaoImpressaoSelecionada != null && !tudo)
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDATA_ATUALIZACAO", dataAtualizacaoImpressaoSelecionada.ToString());
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
            frmRelatorio.AbreRelatorio(nomeRelatorio, reportParam, true);
            this.Cursor = Cursors.Default;
        }

        DateTime? dataAtualizacaoImpressaoSelecionada = null;
        decimal idtUsuarioAlteracaoImpressaoSelecionada = 0;
        private void btnFecharSelecaoDataAtualizacao_Click(object sender, EventArgs e)
        {
            btnLimparSelecaoDataAtualizacaoImpressao_Click(null, null);
            grpDataAtualizacaoImpressao.Visible = false;
        }

        private void btnSelecionarDataHoraImpressao_Click(object sender, EventArgs e)
        {
            if (dataAtualizacaoImpressaoSelecionada == null)
            {
                MessageBox.Show("Selecione a data de atualização dos itens.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ImprimirPrescricao(false);
        }

        private void btnLimparSelecaoDataAtualizacaoImpressao_Click(object sender, EventArgs e)
        {
            grdDataAtualizacaoImpressao.ClearSelection();
            dataAtualizacaoImpressaoSelecionada = null;
            idtUsuarioAlteracaoImpressaoSelecionada = 0;
        }

        private void grdDataAtualizacaoImpressao_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataAtualizacaoImpressaoSelecionada = null;
            idtUsuarioAlteracaoImpressaoSelecionada = 0;
            if (e.RowIndex != -1)
            {
                dataAtualizacaoImpressaoSelecionada = Convert.ToDateTime(grdDataAtualizacaoImpressao.Rows[e.RowIndex].Cells["DATA_ATUALIZACAO"].Value);
                idtUsuarioAlteracaoImpressaoSelecionada = Convert.ToDecimal(grdDataAtualizacaoImpressao.Rows[e.RowIndex].Cells["IDUSUARIOATUALIZACAO"].Value);
            }
        }

        private void grdDataAtualizacaoImpressao_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            grdDataAtualizacaoImpressao_CellMouseClick(sender, e);
        }

        private void tsbImprimirPrescricao_Click(object sender, EventArgs e)
        {
            if (ID_PrescricaoInternacao != null && lblPrescricao.Visible && !string.IsNullOrEmpty(lblPrescricao.Text) && !ValidarPaciente()) return;

            if (lblPrescricao.Text.Length > 0)
            {
                grpDataAtualizacaoImpressao.Visible = true;
                decimal idtPrescricao = Convert.ToDecimal(lblPrescricao.Text.Replace("Prescrição: ", ""));
                grdDataAtualizacaoImpressao.DataSource = Prescricao.ListarDataAtualizacaoItemPrescricao(idtPrescricao);
                grdDataAtualizacaoImpressao.ClearSelection();
            }
            else
            {
                grpDataAtualizacaoImpressao.Visible = false;
                grdDataAtualizacaoImpressao.DataSource = null;
            }
        }

        private void MnUrgenciarItem_Click(object sender, EventArgs e)
        {
            if (dtgPersonalisado.CurrentCell != null)
            {
                this.Cursor = Cursors.WaitCursor;
                if (dtgPersonalisado.CurrentRow.Cells[colDataHoraDose.Name].Value != DBNull.Value)
                {
                    dtgPersonalisado.CurrentRow.Cells[colDataHoraDose.Name].Value = DBNull.Value;
                    dtgPersonalisado.CurrentRow.Cells[colPeriodoDose.Name].Value = DBNull.Value;
                }
                this.Cursor = Cursors.Default;
            }
        }             
    }
}