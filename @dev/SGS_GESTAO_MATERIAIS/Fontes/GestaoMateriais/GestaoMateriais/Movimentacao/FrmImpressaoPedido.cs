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
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HacFramework.Windows.Helpers;
using System.Configuration;
using System.Threading;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmImpressaoPedido : FrmBase
    {
        public FrmImpressaoPedido()
        {
            InitializeComponent();
        }

        private const int _qtdReimpressaoPadrao = 3;

        #region OBJETOS SERVIÇOS

        private bool _farmacia = false;

        // Itens Requisição
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
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject(typeof(IRequisicao)); }
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

        #region Métodos

        private void ConfiguraCombos()
        {
            //if (FrmPrincipal.dtoSeguranca.IdtNivelSeguranca.Value == (int)SegurancaDTO.NivelSeguranca.OPERADOR)
            //{
                cmbUnidade.Enabled = false;
                cmbUnidade.Editavel = ControleEdicao.Nunca;

                cmbLocal.Enabled = false;
                cmbLocal.Editavel = ControleEdicao.Nunca;

                cmbSetor.Enabled = false;
                cmbSetor.Editavel = ControleEdicao.Nunca;

                cmbUnidade.SelectedValue = FrmPrincipal.dtoSeguranca.IdtUnidade.Value;
                cmbLocal.SelectedValue = FrmPrincipal.dtoSeguranca.IdtLocal.Value;
                cmbSetor.SelectedValue = FrmPrincipal.dtoSeguranca.IdtSetor.Value;
            // }
            // CarregarComboMatMed();
        }

        private void ConfigurarDtgReqMatMed()
        {
            dtgReqMatMed.Columns["colReqIdt"].DataPropertyName = RequisicaoDTO.FieldNames.Idt;
            dtgReqMatMed.Columns["colIdtUnidade"].DataPropertyName = RequisicaoDTO.FieldNames.IdtUnidade;
            dtgReqMatMed.Columns["colDsUnidade"].DataPropertyName = RequisicaoDTO.FieldNames.DsUnidade;
            dtgReqMatMed.Columns["colIdtLocal"].DataPropertyName = RequisicaoDTO.FieldNames.IdtLocal;
            dtgReqMatMed.Columns["colDsLocal"].DataPropertyName = RequisicaoDTO.FieldNames.DsLocal;
            dtgReqMatMed.Columns["colIdtSetor"].DataPropertyName = RequisicaoDTO.FieldNames.IdtSetor;
            dtgReqMatMed.Columns["colDsSetor"].DataPropertyName = RequisicaoDTO.FieldNames.DsSetor;
            dtgReqMatMed.Columns["colData"].DataPropertyName = RequisicaoDTO.FieldNames.DataAtualizacao;
        }

        private void CarregarComboTipo()
        {
            Generico gen = new Generico();
            List<ListItem> list = new List<ListItem>();
            if (gen.LogadoManutencao())
            {
                list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.MANUTENCAO).ToString(), "MANUTENÇÂO"));
                cmbTipoRequisicao.SelectedValue = ((byte)RequisicaoDTO.TipoRequisicao.MANUTENCAO).ToString();
            }
            else
            {
                list.Add(new ListItem("-1", "<Selecione>"));
                list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO).ToString(), "PERSONALIZADO"));
                list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.ESTOQUE_LOCAL_MAT_MED).ToString(), "ESTOQUE LOCAL MAT/MED"));
                list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.PADRAO).ToString(), "PADRÃO"));
                if (!_farmacia)
                {
                    list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.IMPRESSOS_MAT_EXPEDIENTE).ToString(), "IMPRESSOS E MATERIAIS DE EXPEDIENTE"));
                    list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.HIGIENIZACAO).ToString(), "HIGIENIZAÇÃO"));
                    list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.OUTROS).ToString(), "OUTROS"));
                }
                list.Add(new ListItem("99", "PENDENTES"));
            }

            cmbTipoRequisicao.ValueMember = ListItem.FieldNames.Key;
            cmbTipoRequisicao.DisplayMember = ListItem.FieldNames.Value;
            cmbTipoRequisicao.DataSource = list;            
            if (gen.LogadoManutencao())
                cmbTipoRequisicao.SelectedValue = ((byte)RequisicaoDTO.TipoRequisicao.MANUTENCAO).ToString();
            else
                cmbTipoRequisicao.IniciaLista();
        }

        private void CarregarReqMatMed()
        {
            dtoRequisicao = new RequisicaoDTO();
            int tpReq = byte.Parse(cmbTipoRequisicao.SelectedValue.ToString());

            if (tpReq == 99)
            {
                dtoRequisicao.FlPendente.Value = (decimal)RequisicaoDTO.Pendente.SIM;
            }
            else
            {
                dtoRequisicao.IdtTipoRequisicao.Value = tpReq;
                dtoRequisicao.FlPendente.Value = (decimal)RequisicaoDTO.Pendente.NAO;
            }
            dtoRequisicao.Status.Value = (int)RequisicaoDTO.StatusRequisicao.FECHADA;
            dtoRequisicao.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoRequisicao.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoRequisicao.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            if (!chkHomeCare.Visible) chkHomeCare.Checked = false;

            this.dtbRequisicao = Requisicao.SelImpressaoCentroDispensacao(dtoRequisicao, chkHomeCare.Checked);
            if (!chkHomeCare.Checked) this.AdicionarReqCarrinhoEmergencia();
            dtgReqMatMed.DataSource = this.dtbRequisicao;
        }

        private void AdicionarReqCarrinhoEmergencia()
        {
            RequisicaoDTO dtoReqCE = new RequisicaoDTO();
            RequisicaoDataTable dtbReqCE;

            dtoReqCE.IdtTipoRequisicao.Value = (byte)RequisicaoDTO.TipoRequisicao.CARRINHO_EMERGENCIA;
            dtoReqCE.Status.Value = (int)RequisicaoDTO.StatusRequisicao.FECHADA;
            dtoReqCE.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoReqCE.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoReqCE.IdtSetor.Value = cmbSetor.SelectedValue.ToString();

            dtbReqCE = Requisicao.SelImpressaoCentroDispensacao(dtoReqCE, false);

            foreach (DataRow row in dtbReqCE.Rows)
            {
                this.dtbRequisicao.Add((RequisicaoDTO)row);
            }
        }

        /// <summary>
        /// Se reqId = null, reimprime as últimas. Se não, imprime determinado pedido.
        /// </summary>
        private void Reimprimir(long? reqId)
        {
            if (ConfigurationManager.AppSettings["HAC.REMOTING.SGS.ACS.GESTAOMATERIAIS.PATH"] != "svchac01.anacosta.com.br") return;

            this.Cursor = Cursors.WaitCursor;
                        
            if (reqId == null)
            {
                if (cmbTipoRequisicao.SelectedValue != null && cmbTipoRequisicao.SelectedValue.ToString() != "-1")
                {
                    dtoRequisicao = new RequisicaoDTO();
                    int tpReq = byte.Parse(cmbTipoRequisicao.SelectedValue.ToString());

                    if (tpReq == 99)
                    {
                        dtoRequisicao.FlPendente.Value = (decimal)RequisicaoDTO.Pendente.SIM;
                    }
                    else
                    {
                        dtoRequisicao.IdtTipoRequisicao.Value = tpReq;
                        dtoRequisicao.FlPendente.Value = (decimal)RequisicaoDTO.Pendente.NAO;
                    }
                    dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.IMPRESSO;
                }
                else
                {
                    MessageBox.Show("Selecione o Tipo", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Cursor = Cursors.Default;
                    cmbTipoRequisicao.Focus();
                    return;
                }
            }
            else
            {
                dtoRequisicao = new RequisicaoDTO();
                dtoRequisicao.Idt.Value = reqId;
            }            

            try
            {
                Impressao.ImpressaoPedido imp = new HospitalAnaCosta.SGS.GestaoMateriais.Impressao.ImpressaoPedido();
                bool impresso = false;

                if (reqId == null)
                {
                    dtbRequisicao = Requisicao.SelUltimas(dtoRequisicao, int.Parse(txtQtdReimpressao.Text));
                }
                else
                {
                    dtbRequisicao = Requisicao.Sel(dtoRequisicao, false);
                }                

                foreach (DataRow row in dtbRequisicao.Rows)
                {
                    dtoRequisicao = (RequisicaoDTO)row;

                    if (reqId == null)
                    {
                        imp.Imprimir(dtoRequisicao, false);
                        impresso = true;
                    }
                    else
                    {
                        if (dtoRequisicao.Status.Value != (byte)RequisicaoDTO.StatusRequisicao.ABERTA &&
                            dtoRequisicao.Status.Value != (byte)RequisicaoDTO.StatusRequisicao.FECHADA)
                        {
                            imp.Imprimir(dtoRequisicao, false);
                            impresso = true;
                        }
                    }
                }

                if (dtbRequisicao.Rows.Count > 0 && impresso)
                {
                    MessageBox.Show("Processo finalizado com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Não há pedido(s) a ser(em) reimpresso(s)", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }                
            }
            catch (Exception ex)
            {
                dtbRequisicao = null;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }           

            this.Cursor = Cursors.Default;
        }

        private bool ImprimirRequisicao()
        {
            if (this.dtbRequisicao.Rows.Count > 0)
            {
                Impressao.ImpressaoPedido imp = new HospitalAnaCosta.SGS.GestaoMateriais.Impressao.ImpressaoPedido();

                dtoRequisicao = this.dtbRequisicao.TypedRow(0);

                try
                {
                    this.AtualizarRequisicaoStatus((decimal)RequisicaoDTO.StatusRequisicao.IMPRESSO);

                    if (ConfigurationManager.AppSettings["HAC.REMOTING.SGS.ACS.GESTAOMATERIAIS.PATH"] == "svchac01.anacosta.com.br")
                        imp.Imprimir(dtoRequisicao, false);

                    dtoRequisicao.Status.Value = (decimal)RequisicaoDTO.StatusRequisicao.IMPRESSO;
                }
                catch (Exception ex)
                {
                    this.AtualizarRequisicaoStatus((decimal)RequisicaoDTO.StatusRequisicao.FECHADA);
                    dtbRequisicao = null;
                    dtgReqMatMed.DataSource = null;
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Pára o timer
                    chkImprimir.Checked = false;
                    return false;
                }
            }
            return true;
        }

        //private void CarregarTipoRequisicao(ComboBox cbo)
        //{
        //    List<ListItem> list = new List<ListItem>();
        //    list.Add(new ListItem("-1", "<Selecione>"));
        //    list.Add(new ListItem("0", "PERSONALIZADO"));
        //    list.Add(new ListItem("1", "PADRÃO"));
        //    list.Add(new ListItem("2", "IMPRESSOS E MATERIAIS DE EXPEDIENTE"));
        //    list.Add(new ListItem("3", "PENDENTES"));


        //    cbo.ValueMember = ListItem.FieldNames.Key;
        //    cbo.DisplayMember = ListItem.FieldNames.Value;
        //    cbo.DataSource = list;
        //    cbo.SelectedValue = "-1";

        //}

        private void AtualizarRequisicaoStatus(decimal status)
        {
            RequisicaoDTO dtoReqAux = this.dtbRequisicao.TypedRow(0);

            if (status == (decimal)RequisicaoDTO.StatusRequisicao.IMPRESSO)
                dtoReqAux.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
            else
                dtoReqAux.IdtUsuario.Value = dtoReqAux.IdtUsuarioRequisicao.Value;
            
            dtoReqAux.Status.Value = status;

            this.Requisicao.Upd(dtoReqAux);
        }

        private void AtualizarPedidosPacientesTransferidosUTI()
        {
            try
            {
                Requisicao.AtualizarPedidosPacientesTransferidosUTI();
            }
            catch (Exception ex)
            {                
                MessageBox.Show("Erro no processo de verificação de Pacientes transferidos " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        #endregion

        #region Eventos

        private void FrmImpressaoPedido_Load(object sender, EventArgs e)
        {
            _farmacia = new Generico().LogadoSetorFarmacia();
            tmPacienteTransf_Tick(sender, e);
            //CarregarTipoRequisicao(cmbTipoRequisicao);
            CarregarComboTipo();
            txtQtdReimpressao.Text = _qtdReimpressaoPadrao.ToString();
            dtgReqMatMed.AutoGenerateColumns = false;
            cmbUnidade.Carregaunidade();
            ConfiguraCombos();
            this.ConfigurarDtgReqMatMed();
            if (!_farmacia && !new Generico().LogadoManutencao())
                chkHomeCare.Visible = new Generico().VerificaAcessoFuncionalidade("FrmAtendimentoDomiciliar");
            btnStatusImpresso.Visible = btnStatusImpresso.Enabled = new Generico().VerificaAcessoFuncionalidade("FrmAcertoEstoque");            
        }

        private void cmbTipoRequisicao_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkImprimir.Enabled = true;
            btnReimpUlt.Enabled = true;
            btnReimpReqNum.Enabled = true;
            txtQtdReimpressao.Enabled = true;
            txtReqNum.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            this.CarregarReqMatMed();
            if (this.ImprimirRequisicao()) timer.Start();
        }

        private void tmPedidoAuto_Tick(object sender, EventArgs e)
        {
            if (_farmacia && chkImprimir.Checked)
            {
                if (cmbTipoRequisicao.SelectedValue.ToString() != "-1" && byte.Parse(cmbTipoRequisicao.SelectedValue.ToString()) == (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO)
                {
                    bool processoLiberado = true;
                    DateTime? dtUltimoProcesso = MatMedSetorConfig.DataUltimaGeracaoPedidosAutomaticosFarmacia();
                    if (dtUltimoProcesso != null)
                    {
                        DateTime dtProximoProcessoLiberada = dtUltimoProcesso.Value.AddMinutes(3);
                        DateTime dtAtual = Utilitario.ObterDataHoraServidor();
                        if (dtAtual < dtProximoProcessoLiberada)
                            processoLiberado = false;
                    }
                    if (processoLiberado)
                        Requisicao.GerarPedidoAutomaticos();
                }
            }
        }

        private void tmPacienteTransf_Tick(object sender, EventArgs e)
        {
            if (_farmacia)
            {
                new Thread(new ThreadStart(AtualizarPedidosPacientesTransferidosUTI)).IsBackground = true;
                new Thread(new ThreadStart(AtualizarPedidosPacientesTransferidosUTI)).Start();
                tmPacienteTransf.Start();
            }
        }

        private void chkImprimir_CheckedChanged(object sender, EventArgs e)
        {
            if (chkImprimir.Checked)
            {
                if (cmbTipoRequisicao.SelectedValue.ToString() == "-1")
                {                    
                    MessageBox.Show("Selecione o Tipo", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    chkImprimir.Checked = false;
                    cmbTipoRequisicao.Focus();
                    return;
                }
                cmbTipoRequisicao.Enabled = false;
                btnReimpUlt.Enabled = false;
                btnReimpReqNum.Enabled = false;
                txtQtdReimpressao.Enabled = false;
                txtReqNum.Enabled = false;
                txtQtdReimpressao.Text = _qtdReimpressaoPadrao.ToString();
                txtReqNum.Text = string.Empty;
                tmPedidoAuto.Start();
                timer.Start();                
            }
            else
            {
                timer.Stop();
                tmPedidoAuto.Stop();
                cmbTipoRequisicao.Enabled = true;
                btnReimpUlt.Enabled = true;
                btnReimpReqNum.Enabled = true;
                txtQtdReimpressao.Enabled = true;
                txtReqNum.Enabled = true;
            }
        }

        private void btnReimpUlt_Click(object sender, EventArgs e)
        {
            if (txtQtdReimpressao.Text == string.Empty)
            {
                MessageBox.Show("Qtd. para reimpressão de pedidos deve ser preenchida", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtQtdReimpressao.Focus();
                return;
            }
            if (long.Parse(txtQtdReimpressao.Text) != 0)
            {
                string msg = string.Format("Deseja realmente reimprimir os últimos {0} pedidos ?", txtQtdReimpressao.Text);
                if (long.Parse(txtQtdReimpressao.Text) == 1) msg = "Deseja realmente reimprimir o último pedido ?";
                if (MessageBox.Show(msg, "Gestão de Materiais e Medicamentos",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Reimprimir(null);
                }
            }
            else
            {
                MessageBox.Show("Qtd. para reimpressão de pedidos deve ser maior que 0", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtQtdReimpressao.Focus();
            }
        }

        private void btnReimpReqNum_Click(object sender, EventArgs e)
        {
            if (txtReqNum.Text == string.Empty)
            {
                MessageBox.Show("N° Pedido deve ser preenchido", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtReqNum.Focus();
                return;
            }            
            if (MessageBox.Show(string.Format("Deseja realmente reimprimir o Pedido N° {0} ?", txtReqNum.Text), "Gestão de Materiais e Medicamentos",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Reimprimir(long.Parse(txtReqNum.Text));
            }
        }

        private void btnStatusImpresso_Click(object sender, EventArgs e)
        {
            if (txtReqNum.Text == string.Empty)
            {
                MessageBox.Show("N° Pedido deve ser preenchido", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtReqNum.Focus();
                return;
            }
            RequisicaoDTO dtoReq = new RequisicaoDTO();
            dtoReq.Idt.Value = txtReqNum.Text;
            dtoReq = Requisicao.SelChave(dtoReq);
            if (dtoReq == null || dtoReq.Idt.Value.IsNull)
            {
                MessageBox.Show("Pedido inexistente", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtReqNum.Focus();
                return;
            }
            if (dtoReq.Status.Value == (decimal)RequisicaoDTO.StatusRequisicao.FECHADA)
            {
                dtoReq.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                dtoReq.Status.Value = (decimal)RequisicaoDTO.StatusRequisicao.IMPRESSO;
                Requisicao.Upd(dtoReq);
                MessageBox.Show("Pedido atualizado p/ Impresso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Status do Pedido deve ser ENVIADO AO ALMOXARIFADO", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        #endregion        
    }
}