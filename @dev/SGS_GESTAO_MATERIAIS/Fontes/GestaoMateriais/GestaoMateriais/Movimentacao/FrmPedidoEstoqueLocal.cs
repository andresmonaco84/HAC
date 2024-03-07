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
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.View;
using HospitalAnaCosta.SGS.Seguranca.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HacFramework.Windows.Helpers;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmPedidoEstoqueLocal : FrmBase
    {
        public FrmPedidoEstoqueLocal()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇOS

        private const int QTDE_MAX_PADRAO_PERMITIDA = 1000;
        private const decimal DROGAS_E_MEDICAMENTOS = 1;
        private const decimal ANTIMICROBIANOS_RESTRITOS = 981;
        private const int UNIDADE_AMB_SANTOS = 248;
        private const int LOCAL_AMB = 27;
        private const int SETOR_AMB = 37;
        private int? _idFuncionalidade = null;
        private bool _podePedirTudo = false;

        private CommonSeguranca _commonSeguranca;
        protected CommonSeguranca CommonSeguranca
        {
            get { return _commonSeguranca != null ? _commonSeguranca : _commonSeguranca = new CommonSeguranca(null); }
        }

        // Itens Requisição
        private RequisicaoItensDataTable dtbRequisicaoItem;
        private RequisicaoItensDTO dtoRequisicaoItem;
        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }

        // Requisição
        private RequisicaoDTO dtoRequisicao;
        private RequisicaoDataTable dtbRequisicao;
        private IRequisicao _requisicao;
        private IRequisicao Requisicao
        {
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject(typeof(IRequisicao)); }
        }

        // MatMed
        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get
            {
                return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento));
            }
        }

        // Similar
        private IMatMedSimilar _similar;
        private IMatMedSimilar Similar
        {
            get { return _similar != null ? _similar : _similar = (IMatMedSimilar)Global.Common.GetObject(typeof(IMatMedSimilar)); }
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

        // Pedido Padrão        
        private IPedidoPadrao _pedidopadrao;
        private IPedidoPadrao PedidoPadrao
        {
            get { return _pedidopadrao != null ? _pedidopadrao : _pedidopadrao = (IPedidoPadrao)Global.Common.GetObject(typeof(IPedidoPadrao)); }
        }

        // Kit
        private IKit _kit;
        private IKit Kit
        {
            get { return _kit != null ? _kit : _kit = (IKit)Global.Common.GetObject(typeof(IKit)); }
        }

        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        #endregion

        #region FUNÇÕES

        private void ConfiguraRequisicaoDTO()
        {
            if (cmbSetor.SelectedValue != null)
            {
                dtoRequisicao = new RequisicaoDTO();

                dtoRequisicao.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                dtoRequisicao.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                dtoRequisicao.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.ABERTA;
                dtoRequisicao.FlPendente.Value = (byte)RequisicaoDTO.Pendente.NAO;
                dtoRequisicao.IdtTipoRequisicao.Value = (byte)RequisicaoDTO.TipoRequisicao.ESTOQUE_LOCAL_MAT_MED;
                dtoRequisicao.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            }
        }

        private void ConfiguraDTG()
        {
            dtgMatMed.AutoGenerateColumns = false;
            dtgMatMed.Columns[colReqItemIdt.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.Idt;
            dtgMatMed.Columns[colMatMedIdt.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.IdtProduto;
            dtgMatMed.Columns[colDsProd.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.DsProduto;
            dtgMatMed.Columns[colMAV.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia;
            dtgMatMed.Columns[colDsUnidadeVenda.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.DsUnidadeVenda;
            dtgMatMed.Columns[colQtde.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdSolicitada;
            dtgMatMed.Columns[colMatMedPrincAt.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.IdtPrincipioAtivo;
        }

        private int ObterQtdMaximaPedidoItem()
        {
            if (_podePedirTudo || _idFuncionalidade == null) return QTDE_MAX_PADRAO_PERMITIDA;

            MatMedFuncionalidadeDTO dtoMatMedFunc = new MatMedFuncionalidadeDTO();
            dtoMatMedFunc.IdFuncionalidade.Value = _idFuncionalidade.Value;
            dtoMatMedFunc.IdProduto.Value = dtoMatMed.Idt.Value;
            MatMedFuncionalidadeDataTable dtbMMF = MatMedFuncionalidade.Sel(dtoMatMedFunc);
            if (dtbMMF.Rows.Count > 0)
            {
                string qtdMaxima = dtbMMF.Rows[0]["QTDE_MAXIMA_PEDIDO"].ToString();
                if (string.IsNullOrEmpty(qtdMaxima))
                    return QTDE_MAX_PADRAO_PERMITIDA;
                else
                    return int.Parse(qtdMaxima);
            }
            return QTDE_MAX_PADRAO_PERMITIDA;
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

        private void CarregarComboMatMed()
        {
            btnSugerir.Visible = btnSugerir.Enabled = false;
            _podePedirTudo = false;
            if (cmbSetor.SelectedValue != null)
            {
                this.Cursor = Cursors.WaitCursor;
                _idFuncionalidade = ObterFuncionalidadeSetor();

                if (_idFuncionalidade != null)
                {
                    cmbMatMed.ValueMember = MaterialMedicamentoDTO.FieldNames.Idt;
                    cmbMatMed.DisplayMember = MaterialMedicamentoDTO.FieldNames.NomeFantasia;

                    FuncionalidadeDTO dtoFuncionalidade = new FuncionalidadeDTO();
                    dtoFuncionalidade.Idt.Value = _idFuncionalidade.Value;
                    dtoFuncionalidade.FiltraAssociados.Value = 2;
                    FuncionalidadeDataTable dtbFuncionalidade = Funcionalidade.Sel(dtoFuncionalidade);
                    if (dtbFuncionalidade.TypedRow(0).NmPagina.Value == "EstoqueLocalTodosProdutos")
                    {
                        SetorDTO dtoSetor = new SetorDTO();
                        dtoSetor.FlAlmoxCentral.Value = (byte)SetorDTO.AlmoxarifadoCentral.SIM;
                        dtoSetor = Setor.Sel(dtoSetor).TypedRow(0);
                        PedidoPadraoDTO dtoPedidoPadrao = new PedidoPadraoDTO();
                        dtoPedidoPadrao.IdtUnidade.Value = dtoSetor.IdtUnidade.Value;
                        dtoPedidoPadrao.IdtLocal.Value = dtoSetor.IdtLocalAtendimento.Value;
                        dtoPedidoPadrao.IdtSetor.Value = dtoSetor.Idt.Value;

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
                                    if ((rbMat.Checked && rowPedido[MaterialMedicamentoDTO.FieldNames.IdtGrupo].ToString() != DROGAS_E_MEDICAMENTOS.ToString()) ||
                                        (rbMed.Checked && rowPedido[MaterialMedicamentoDTO.FieldNames.IdtGrupo].ToString() == DROGAS_E_MEDICAMENTOS.ToString()))
                                    {
                                        rowMM = dtbMatMed.NewRow();
                                        rowMM[MaterialMedicamentoDTO.FieldNames.Idt] = rowPedido[MaterialMedicamentoDTO.FieldNames.Idt];
                                        rowMM[MaterialMedicamentoDTO.FieldNames.NomeFantasia] = rowPedido[MaterialMedicamentoDTO.FieldNames.NomeFantasia];
                                        dtbMatMed.Rows.Add(rowMM);
                                    }
                                }
                            }
                            dtbMatMed.AcceptChanges();
                            cmbMatMed.DataSource = dtbMatMed;
                        }
                        btnSugerir.Visible = btnSugerir.Enabled = true;
                        _podePedirTudo = true;
                    }
                    else
                    {
                        MatMedFuncionalidadeDTO dtoMatMedFunc = new MatMedFuncionalidadeDTO();
                        dtoMatMedFunc.IdFuncionalidade.Value = _idFuncionalidade.Value;
                        MatMedFuncionalidadeDataTable dtbMatMedFunc = MatMedFuncionalidade.Sel(dtoMatMedFunc);
                        cmbMatMed.DataSource = new DataView(dtbMatMedFunc,
                                                            string.Format("{0} {1} {2}", MaterialMedicamentoDTO.FieldNames.IdtGrupo, rbMat.Checked ? "<>" : "=", DROGAS_E_MEDICAMENTOS),
                                                            string.Empty, DataViewRowState.CurrentRows).ToTable();
                    }
                    cmbMatMed.IniciaLista();
                }
                else
                {
                    cmbMatMed.DataSource = null;
                    MessageBox.Show("Este setor não tem cadastro de Mat/Med vinculado para este tipo de pedido.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                this.Cursor = Cursors.Default;
            }
            else
                _idFuncionalidade = null;
        }

        private void Carregar()
        {
            this.Cursor = Cursors.WaitCursor;
            ConfiguraRequisicaoDTO();

            dtbRequisicao = Requisicao.Sel(dtoRequisicao, false);

            if (dtbRequisicao.Rows.Count > 0)
            {
                btnSugerir.Visible = false;
                dtoRequisicao = (RequisicaoDTO)dtbRequisicao.Rows[0];

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

                if (dtoRequisicao.Urgencia.Value.IsNull) dtoRequisicao.Urgencia.Value = 0;
                cbUrgente.Checked = (byte)dtoRequisicao.Urgencia.Value == 1 ? true : false;
                txtReqIdt.Text = dtoRequisicao.Idt.ToString();
                rbMat.Enabled = rbMed.Enabled = false;

                dtoRequisicaoItem = new RequisicaoItensDTO();

                dtoRequisicaoItem.Idt.Value = int.Parse(txtReqIdt.Text);

                dtbRequisicaoItem = RequisicaoItens.SelItensRequisicao(dtoRequisicaoItem, true);
                txtData.Text = ((DateTime)dtoRequisicao.DataAtualizacao.Value).ToString("dd/MM/yyyy");
                if (dtbRequisicaoItem.Rows.Count > 0)
                {
                    if (int.Parse(dtbRequisicaoItem.Rows[0][MaterialMedicamentoDTO.FieldNames.IdtGrupo].ToString()) == DROGAS_E_MEDICAMENTOS)
                        rbMed.Checked = true;

                    if (rbMed.Checked)
                        CarregarComboMatMed();
                }
            }
            else
            {
                txtReqIdt.Text = string.Empty;
                rbMat.Enabled = rbMed.Enabled = true;
                dtbRequisicaoItem = new RequisicaoItensDataTable();
                txtData.Text = Utilitario.ObterDataHoraServidor().ToString("dd/MM/yyyy");
                cbStatus.Checked = true;
            }

            dtgMatMed.DataSource = dtbRequisicaoItem;

            cmbUnidade.Enabled = cmbLocal.Enabled = cmbSetor.Enabled = false;

            this.Cursor = Cursors.Default;
        }

        private bool AmbulatorioMaterialEnviarAlmox()
        {
            if ((int)dtoRequisicao.IdtUnidade.Value == UNIDADE_AMB_SANTOS && 
                (int)dtoRequisicao.IdtLocal.Value == LOCAL_AMB &&
                (int)dtoRequisicao.IdtSetor.Value != SETOR_AMB)
                return true;

            return false;
        }

        private bool Salvar()
        {
            try
            {
                if (dtbRequisicaoItem.Rows.Count != 0)
                {
                    dtoRequisicao.Urgencia.Value = (int)(cbUrgente.Checked ? 1 : 0);
                    dtoRequisicao.Status.Value = (int)(cbStatus.Checked ? RequisicaoDTO.StatusRequisicao.FECHADA : RequisicaoDTO.StatusRequisicao.ABERTA);

                    if (txtReqIdt.Text != string.Empty) dtoRequisicao.Idt.Value = int.Parse(txtReqIdt.Text);

                    dtoRequisicao.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                    dtoRequisicao.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                    if (!AmbulatorioMaterialEnviarAlmox() ||
                        (rbMed.Checked && AmbulatorioMaterialEnviarAlmox()))
                    {
                        int? idSetorFarmacia = new Generico().ObterFarmaciaSetor((int)dtoRequisicao.IdtSetor.Value);
                        if (idSetorFarmacia != null)
                            dtoRequisicao.SetorFarmacia.Value = idSetorFarmacia;
                    }

                    dtoRequisicao = Requisicao.Gravar(dtoRequisicao, dtbRequisicaoItem);

                    dtbRequisicaoItem.AcceptChanges();

                    txtReqIdt.Text = dtoRequisicao.Idt.Value.ToString();

                    MessageBox.Show("Registro Salvo com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (cbStatus.Checked)
                    {
                        dtoRequisicao = null;
                        dtgMatMed.Enabled = false;
                    }
                    else
                        dtgMatMed.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Você não pode salvar uma requisição sem itens", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void VerificaCarrinhoEmergencia()
        {
            if (cmbSetor.SelectedValue != null)
            {
                int? setorCarrEmergPai = new Generico().SetorCarrinhoEmergencia(int.Parse(cmbSetor.SelectedValue.ToString()));
                if (setorCarrEmergPai != null)
                {
                    cmbSetor.SelectedIndex = -1;
                    MessageBox.Show("Este setor é um Carrinho de Emergência não sendo permitido solicitar item ao mesmo.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        private bool AdicionarItem(int? qtdReq)
        {
            if (dtbRequisicaoItem == null) dtbRequisicaoItem = new RequisicaoItensDataTable();
            if (dtbRequisicaoItem.Select(string.Format("{0} = {1}",
                                                       RequisicaoItensDTO.FieldNames.IdtProduto,
                                                       dtoMatMed.Idt.Value)).Length > 0)
            {
                if (!grbKit.Visible || cmbKit.SelectedIndex == -1)
                {
                    MessageBox.Show("Já foi adicionado o Material/Medicamento Selecionado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbMatMed.Focus();
                }
                return false;
            }

            if (dtoMatMed.IdtPrincipioAtivo.Value.IsNull) dtoMatMed.IdtPrincipioAtivo.Value = 0;
            if (dtoMatMed.IdtPrincipioAtivo.Value != 0)
            {
                if (dtbRequisicaoItem.Select(string.Format("{0} = {1}",
                                                           RequisicaoItensDTO.FieldNames.IdtPrincipioAtivo,
                                                           dtoMatMed.IdtPrincipioAtivo.Value)).Length > 0 && !string.IsNullOrEmpty(txtQtdReq.Text))
                {
                    MessageBox.Show("Já foi adicionado Material/Medicamento similar a este", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbMatMed.Focus();
                    return false;
                }
                else if (dtbRequisicaoItem.Select(string.Format("{0} = {1}",
                                                                RequisicaoItensDTO.FieldNames.IdtPrincipioAtivo,
                                                                dtoMatMed.IdtPrincipioAtivo.Value)).Length > 0 && string.IsNullOrEmpty(txtQtdReq.Text))
                {
                    //Nao deixar adicionar similar quando sugestao sem mandar msg
                    return false;
                }
            }

            // Converte dto MatMed para dto RequisicaoItem
            dtoRequisicaoItem = RequisicaoItens.ConverteMatMedRequisicao(dtoMatMed);

            if (qtdReq == null)
            {
                // Solicita quantidade
                dtoRequisicaoItem = FrmQtdMatMed.DigitaQtde(dtoRequisicaoItem);
            }
            else
                dtoRequisicaoItem.QtdSolicitada.Value = qtdReq;

            if (dtoRequisicaoItem != null)
            {
                // se for uma requisição já salva terá ID da requisição tem que atribuir ao dtoReq
                if (txtReqIdt.Text.Length != 0)
                {
                    dtoRequisicaoItem.Idt.Value = Convert.ToDecimal(txtReqIdt.Text);
                }
                try
                {
                    dtbRequisicaoItem.Add(dtoRequisicaoItem);
                    if (dtbRequisicaoItem.Columns.IndexOf(MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia) == -1)
                        dtbRequisicaoItem.Columns.Add(MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia);
                    dtbRequisicaoItem.Rows[dtbRequisicaoItem.Rows.Count - 1][MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia] = dtoMatMed.MedAltaVigilancia.Value;
                    dtgMatMed.DataSource = dtbRequisicaoItem;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        /// Solução alternativa para atualizar o grid quando está em edição.        
        private void AtualizaGridEmEdicao()
        {
            chkAjudaAtualizarGrid.Visible = true;
            chkAjudaAtualizarGrid.Focus();
            chkAjudaAtualizarGrid.Visible = false;
        }

        private void CarregarKit()
        {
            this.Cursor = Cursors.WaitCursor;
            grbKit.Visible = false;

            KitDTO dtoKit = new KitDTO();
            dtoKit.Ativo.Value = 1;
            DataTable dtbKit = Kit.Listar(dtoKit);
            dtbKit = new DataView(dtbKit, string.Format("{0} = {1}", RequisicaoDTO.FieldNames.IdtSetor, cmbSetor.SelectedValue.ToString()), string.Empty, DataViewRowState.OriginalRows).ToTable();

            if (dtbKit.Rows.Count > 0)
            {
                grbKit.Visible = true;
                cmbKit.DataSource = dtbKit;
                cmbKit.IniciaLista();
            }
            this.Cursor = Cursors.Default;
        }

        private void CarregarItensKit()
        {
            this.Cursor = Cursors.WaitCursor;
            KitDTO dtoKit = new KitDTO();
            dtoKit.IdKit.Value = cmbKit.SelectedValue.ToString();
            KitDataTable dtbItem = Kit.ListarItem(dtoKit);

            foreach (DataRow row in dtbItem.Rows)
            {
                if (rbMat.Checked && int.Parse(row[MaterialMedicamentoDTO.FieldNames.IdtGrupo].ToString()) != 1 ||
                    rbMed.Checked && int.Parse(row[MaterialMedicamentoDTO.FieldNames.IdtGrupo].ToString()) == 1)
                {
                    MaterialMedicamentoDTO dtoMatMedRef = new MaterialMedicamentoDTO();
                    dtoMatMedRef.Idt.Value = row[KitDTO.FieldNames.IdProduto].ToString();
                    dtoMatMed = MatMed.SelChave(dtoMatMedRef);

                    this.AdicionarItem(int.Parse(row[KitDTO.FieldNames.QtdeItem].ToString()));
                }
            }

            //dtgMatMed.DataSource = dtbRequisicaoItem;
            cmbKit.IniciaLista();

            if (dtbRequisicaoItem.Rows.Count == 0)
                MessageBox.Show("Não há itens deste kit a ser adicionado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            this.Cursor = Cursors.Default;
        }

        #endregion

        #region EVENTOS

        private void FrmPedidoEstoqueLocal_Load(object sender, EventArgs e)
        {
            ConfiguraDTG();
            tsHac.MatMedVisivel = false; //Não será liberado nem pedido de fracionados
            grbAddMatMed.Enabled = true;

            cmbUnidade.Carregaunidade();
            Generico.ConfiguraCombos(cmbUnidade, cmbLocal, cmbSetor, FrmPrincipal.dtoSeguranca);

            VerificaCarrinhoEmergencia();
            CarregarComboMatMed();
            CarregarKit();

            btnAdd.GotFocus += btnAdd_GotFocus;
        }

        private void rbMat_Click(object sender, EventArgs e)
        {
            rbMed_Click(sender, e);
        }

        private void rbMed_Click(object sender, EventArgs e)
        {
            if (txtReqIdt.Text == string.Empty && cmbSetor.SelectedValue != null)
            {
                dtbRequisicaoItem = new RequisicaoItensDataTable();
                dtgMatMed.DataSource = dtbRequisicaoItem;
                CarregarComboMatMed();
                cmbMatMed.IniciaLista();
                cmbMatMed.Focus();
            }
        }

        private void cmbUnidade_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tsHac.Controla(Evento.eCancelar);
            grbKit.Visible = false;
        }

        private void cmbLocal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tsHac.Controla(Evento.eCancelar);
            grbKit.Visible = false;
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbSetor.SelectedValue != null)
            {
                dtbRequisicaoItem = null;
                tsHac.Controla(Evento.eCancelar);
                VerificaCarrinhoEmergencia();
                CarregarComboMatMed();
                CarregarKit();
            }
            else
                _idFuncionalidade = null;
        }

        private void cmbKit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbKit.SelectedIndex > -1)
            {
                CarregarItensKit();
            }
        }

        private void cmbMatMed_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbMatMed.SelectedValue != null)
            {
                btnAdd.Enabled = true;
                txtQtdReq.Focus();
            }
        }

        private void cmbMatMed_DropDown(object sender, EventArgs e) { }

        private void cmbMatMed_Enter(object sender, EventArgs e)
        {
            cmbMatMed.DroppedDown = true;
        }

        private void cmbMatMed_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue >= 97 && e.KeyValue <= 122))
            {
                cmbMatMed.DroppedDown = true;
            }
            else if (e.KeyValue >= 65 && e.KeyValue <= 90)
            {
                cmbMatMed.DroppedDown = true;
            }
            else if (cmbMatMed.SelectedIndex != -1)
            {
                //Se teclar enter, foca qtd.
                if (e.KeyValue == 13)
                {
                    cmbMatMed.DroppedDown = false;
                    txtQtdReq.Enabled = btnAdd.Enabled = true;
                    txtQtdReq.Focus();
                }
            }
        }

        protected void btnAdd_GotFocus(object sender, EventArgs e)
        {
            if (txtQtdReq.Text == string.Empty) txtQtdReq.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbSetor.SelectedValue == null || cmbSetor.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o Setor", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSetor.Focus();
                return;
            }
            if (cmbMatMed.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o Mat/Med", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMatMed.Focus();
                return;
            }
            else if (txtQtdReq.Text == string.Empty || int.Parse(txtQtdReq.Text) <= 0)
            {
                MessageBox.Show("Digite a Qtde.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQtdReq.Focus();
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            MaterialMedicamentoDTO dto = new MaterialMedicamentoDTO();

            ConfiguraRequisicaoDTO();

            dto.Idt.Value = cmbMatMed.SelectedValue.ToString();
            dtoMatMed = MatMed.SelChave(dto);

            int qtdMaximaPedido = ObterQtdMaximaPedidoItem();
            if (int.Parse(txtQtdReq.Text) > qtdMaximaPedido)
            {
                MessageBox.Show("Qtde. deste item não pode ser maior que " + qtdMaximaPedido + " por Pedido.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Cursor = Cursors.Default;
                txtQtdReq.Focus();
                return;
            }

            MatMedSimilarDTO dtoSimilar = new MatMedSimilarDTO();
            dtoSimilar.IdPrincipioAtivo.Value = dtoMatMed.IdtPrincipioAtivo.Value;
            dtoSimilar.IdProduto.Value = dtoMatMed.Idt.Value;
            dtoSimilar.FlAtivo.Value = (byte)MatMedSimilarDTO.Ativo.SIM;
            MaterialMedicamentoDTO dtoMatMedAntimicrobiano = new MaterialMedicamentoDTO();
            dtoMatMedAntimicrobiano.IdtGrupo.Value = DROGAS_E_MEDICAMENTOS;
            dtoMatMedAntimicrobiano.IdtSubGrupo.Value = ANTIMICROBIANOS_RESTRITOS;
            MatMedSimilarDataTable dtbSimilarAntimicrobiano = Similar.ListarSimilares(dtoSimilar, dtoMatMedAntimicrobiano);
            if (dtbSimilarAntimicrobiano.Rows.Count > 0)
            {
                MessageBox.Show("Item não pode ser similar a nenhum Antimicrobiano de Uso Restrito.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Cursor = Cursors.Default;
                return;
            }

            this.AdicionarItem(int.Parse(txtQtdReq.Text));

            btnSugerir.Visible = false;
            rbMat.Enabled = rbMed.Enabled = false;
            txtQtdReq.Enabled = btnAdd.Enabled = false;
            txtQtdReq.Text = string.Empty;
            cmbMatMed.SelectedIndex = -1;
            cmbMatMed.Text = "<Selecione>";
            cmbMatMed.Focus();

            this.Cursor = Cursors.Default;
        }

        private void btnSugerir_Click(object sender, EventArgs e)
        {
            if (dtoRequisicao == null) return;

            if (cmbSetor.SelectedIndex > -1 && string.IsNullOrEmpty(txtReqIdt.Text))
            {
                if (dtbRequisicaoItem != null && dtbRequisicaoItem.Rows.Count > 0) return;

                this.Cursor = Cursors.WaitCursor;

                RequisicaoDTO dtoReq = new RequisicaoDTO();
                dtoReq.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                dtoReq.DataRequisicao.Value = Utilitario.ObterDataHoraServidor().AddDays(-1);

                MaterialMedicamentoDTO dtoMatMedSug = new MaterialMedicamentoDTO();
                if (rbMed.Checked)
                    dtoMatMedSug.IdtGrupo.Value = DROGAS_E_MEDICAMENTOS;
                else
                    dtoMatMedSug.IdtGrupo.Value = 6;

                RequisicaoItensDataTable dtbItens = RequisicaoItens.SelSugestaoItensRequisicao(dtoReq, dtoMatMedSug);
                dtbRequisicaoItem = new RequisicaoItensDataTable();
                txtQtdReq.Text = string.Empty;
                if (dtbItens.Rows.Count > 0)
                {
                    ConfiguraRequisicaoDTO();
                    MaterialMedicamentoDTO dtoMatMedRef;
                    foreach (DataRow row in dtbItens.Rows)
                    {
                        dtoMatMedRef = new MaterialMedicamentoDTO();
                        dtoMatMedRef.Idt.Value = row[RequisicaoItensDTO.FieldNames.IdtProduto].ToString();
                        dtoMatMed = MatMed.SelChave(dtoMatMedRef);

                        this.AdicionarItem(int.Parse(row[RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString()));
                    }
                }

                dtgMatMed.DataSource = dtbRequisicaoItem;

                if (dtgMatMed.Rows.Count == 0)
                    MessageBox.Show("Não há itens solicitados nas últimas 24 horas para sugestão.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    btnSugerir.Visible = false;

                this.Cursor = Cursors.Default;
            }
        }

        private bool tsHac_MatMedClick(object sender)
        {
            if (dtoRequisicao == null) ConfiguraRequisicaoDTO();

            MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO(); ;
            SetorDTO dtoSetor = new SetorDTO();

            dtoSetor.Idt.Value = dtoRequisicao.IdtSetor.Value;
            dtoSetor.IdtLocalAtendimento.Value = dtoRequisicao.IdtLocal.Value;
            dtoSetor.IdtUnidade.Value = dtoRequisicao.IdtUnidade.Value;

            dtoMatMed.IdtUnidade.Value = dtoSetor.IdtUnidade.Value;
            dtoMatMed.IdtLocal.Value = dtoSetor.IdtLocalAtendimento.Value;
            dtoMatMed.IdtSetor.Value = dtoSetor.Idt.Value;
            dtoMatMed.IdtFilial.Value = dtoRequisicao.IdtFilial.Value;
            dtoMatMed.FlFracionado.Value = ((int)MaterialMedicamentoDTO.Fracionado.SIM).ToString();
            dtoMatMed.FlAtivo.Value = 1;

            dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMed);

            if (dtoMatMed != null)
            {
                if (dtbRequisicaoItem == null) dtbRequisicaoItem = new RequisicaoItensDataTable();
                if (dtbRequisicaoItem.Select(string.Format("{0} = {1}",
                                                            RequisicaoItensDTO.FieldNames.IdtProduto,
                                                            dtoMatMed.Idt.Value)).Length > 0)
                {
                    MessageBox.Show("Já foi adicionado o Material/Medicamento Selecionado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                dtoRequisicaoItem = RequisicaoItens.ConverteMatMedRequisicao(dtoMatMed);

                // Solicita quantidade
                dtoRequisicaoItem = FrmQtdMatMed.DigitaQtde(dtoRequisicaoItem);

                if (dtoRequisicaoItem != null)
                {
                    // se for uma requisição já salva terá ID da requisição tem que atribuir ao dtoReq
                    if (txtReqIdt.Text.Length != 0)
                    {
                        dtoRequisicaoItem.Idt.Value = Convert.ToDecimal(txtReqIdt.Text);
                    }
                    try
                    {
                        if (dtbRequisicaoItem == null) dtbRequisicaoItem = new RequisicaoItensDataTable();
                        dtbRequisicaoItem.Add(dtoRequisicaoItem);
                        dtgMatMed.DataSource = dtbRequisicaoItem;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }

        private bool tsHac_NovoClick(object sender)
        {
            return true;
        }

        private bool tsHac_AfterNovo(object sender)
        {
            btnSugerir.Visible = _podePedirTudo;
            dtgMatMed.Enabled = cmbMatMed.Enabled = btnSugerir.Enabled = true;

            this.Carregar();

            cmbMatMed.IniciaLista();
            cmbMatMed.Focus();

            return true;
        }

        private bool tsHac_CancelarClick(object sender)
        {
            dtbRequisicaoItem = null;
            dtgMatMed.Enabled = true;
            btnAdd.Enabled = btnSugerir.Enabled = false;
            //btnSugerir.Visible = false;
            return true;
        }

        private bool tsHac_SalvarClick(object sender)
        {
            this.AtualizaGridEmEdicao();
            return this.Salvar();
        }

        private void dtgMatMed_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgMatMed.Columns[e.ColumnIndex].Name == colDeletar.Name)
            {
                if (MessageBox.Show("Deseja excluir esse produto da lista ?",
                                     "Gestão de Materiais e Medicamentos",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int nCount = 0; nCount < dtbRequisicaoItem.Rows.Count; nCount++)
                    {
                        if (dtbRequisicaoItem.Rows[nCount].RowState != DataRowState.Deleted)
                        {
                            if (dtbRequisicaoItem.Rows[nCount][RequisicaoItensDTO.FieldNames.IdtProduto].ToString() == dtgMatMed.Rows[e.RowIndex].Cells[colMatMedIdt.Name].Value.ToString())
                            {
                                dtbRequisicaoItem.Rows[nCount].Delete();
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void dtgMatMed_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dtgMatMed.Columns[e.ColumnIndex].Name == colQtde.Name)
            {
                if (!string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    if (!this.IsNumber(e.FormattedValue.ToString()))
                    {
                        tsHac.Enabled = false;
                        MessageBox.Show("Qtd. Máx. deve ser numérico", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Cancel = true;
                    }
                    else if (e.FormattedValue.ToString().IndexOf(',') > -1)
                    {
                        tsHac.Enabled = false;
                        MessageBox.Show("Qtd. Máx. deve ser um número inteiro", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Cancel = true;
                    }
                    else if (int.Parse(e.FormattedValue.ToString()) <= 0)
                    {
                        tsHac.Enabled = false;
                        MessageBox.Show("Qtd. Máx. deve ser maior que 0", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Cancel = true;
                    }
                    int qtdMaximaPedido = ObterQtdMaximaPedidoItem();
                    if (int.Parse(e.FormattedValue.ToString()) > qtdMaximaPedido)
                    {
                        tsHac.Enabled = false;
                        MessageBox.Show("Qtde. deste item não pode ser maior que " + qtdMaximaPedido + " por Pedido.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                    }
                    else
                        tsHac.Enabled = true;
                }
            }
        }

        private void dtgMatMed_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dtgMatMed.Columns[e.ColumnIndex].Name == colQtde.Name)
            {
                this.Cursor = Cursors.WaitCursor;

                int qtd = int.Parse(dtgMatMed.Rows[e.RowIndex].Cells[colQtde.Name].Value.ToString());
                MaterialMedicamentoDTO dtoMatMedRef = new MaterialMedicamentoDTO();
                dtoMatMedRef.Idt.Value = dtgMatMed.Rows[e.RowIndex].Cells[colMatMedIdt.Name].Value.ToString();

                DataRow rowItem = dtbRequisicaoItem.Select(string.Format("{0} = {1}",
                                                                           RequisicaoItensDTO.FieldNames.IdtProduto,
                                                                           dtgMatMed.Rows[e.RowIndex].Cells[colMatMedIdt.Name].Value.ToString()))[0];
                rowItem.Delete();

                ConfiguraRequisicaoDTO();
                dtoMatMed = MatMed.SelChave(dtoMatMedRef);

                this.AdicionarItem(qtd);

                dtgMatMed.Sort(dtgMatMed.Columns[colDsProd.Name], ListSortDirection.Ascending);

                this.Cursor = Cursors.Default;
            }
        }

        #endregion
    }
}