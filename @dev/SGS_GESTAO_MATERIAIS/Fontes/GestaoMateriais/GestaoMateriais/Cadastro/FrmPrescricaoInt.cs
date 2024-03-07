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
using HospitalAnaCosta.SGS.Seguranca.Interface;
using HospitalAnaCosta.SGS.Seguranca.View;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.GestaoMateriais.Relatorio;
using HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Cadastro
{
    public partial class FrmPrescricaoInt : FrmBase
    {
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

        private IRequisicao _requisicao;
        private IRequisicao Requisicao
        {
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject(typeof(IRequisicao)); }
        }

        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }

        private IPaciente _atendimento;
        private IPaciente Atendimento
        {
            get { return _atendimento != null ? _atendimento : _atendimento = (IPaciente)Global.Common.GetObject(typeof(IPaciente)); }
        }

        // Utilitario
        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        public FrmPrescricaoInt()
        {
            InitializeComponent();
        }

        private void ConfigGrid()
        {
            dtgPrescricao.AutoGenerateColumns = false;

            dtgPrescricao.Columns[colCodPresc.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.IdPrescricaoInternacao;
            dtgPrescricao.Columns[colIdAtendimento.Name].DataPropertyName = RequisicaoDTO.FieldNames.IdtAtendimento;
            dtgPrescricao.Columns[colPaciente.Name].DataPropertyName = "NOME_PACIENTE";
            dtgPrescricao.Columns[colSetor.Name].DataPropertyName = SetorDTO.FieldNames.Descricao;
            dtgPrescricao.Columns[colIdSetor.Name].DataPropertyName = RequisicaoDTO.FieldNames.IdtSetor;
            dtgPrescricao.Columns[colQL.Name].DataPropertyName = "QUARTO_LEITO";
            dtgPrescricao.Columns[colQtdePend.Name].DataPropertyName = "QTD_ITENS_PENDENTES";
            dtgPrescricao.Columns[colData.Name].DataPropertyName = "DT_HORA_PRESCRICAO";
            dtgPrescricao.Columns[colData.Name].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dtgPrescricao.Columns[colDataEntrada.Name].DataPropertyName = "DT_HORA_ENTRADA";
            dtgPrescricao.Columns[colDataEntrada.Name].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dtgPrescricao.Columns[colQtdeImed.Name].DataPropertyName = "QTD_IMEDIATOS_PENDENTES";
            dtgPrescricao.Columns[colPrescricaoStatus.Name].DataPropertyName = "ATD_PME_FL_STATUS";
        }

        private void CarregaInfoPaciente()
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable dtPaciente = Atendimento.ObterPaciente(decimal.Parse(txtNroInternacao.Text));

            if (dtPaciente.Rows.Count > 0)
            {
                txtNomePac.Text = dtPaciente.Rows[0][1].ToString();
                tsHac.Items["tsBtnPesquisar"].Enabled = true;
            }
            else
            {
                MessageBox.Show("Paciente não identificado com esta sequência.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomePac.Text = string.Empty;
                txtNroInternacao.Text = string.Empty;
                txtNroInternacao.Focus();
            }
            this.Cursor = Cursors.Default;
        }

        private void FrmPrescricaoInt_Load(object sender, EventArgs e)
        {
            cmbUnidade.Carregaunidade();
            cmbUnidade.SelectedValue = 244; //SANTOS
            cmbLocal.SelectedValue = 29; //INTERNADO
            ConfigGrid();
            tsHac_PesquisarClick(null);
            tmPesquisa.Start();

            if (new Generico().VerificaAcessoFuncionalidade("FrmRelatorios")) tsPlanilha.Visible = true;
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tsHac.Items["tsBtnPesquisar"].Enabled = true;
        }

        private void txtNroInternacao_Validating(object sender, CancelEventArgs e)
        {
            if (txtNroInternacao.Text.Length != 0)
                btnPesquisaPac_Click(sender, e);
            else
                txtNomePac.Text = string.Empty;
        }

        private void btnPesquisaPac_Click(object sender, EventArgs e)
        {
            if (txtNroInternacao.Enabled && !string.IsNullOrEmpty(txtNroInternacao.Text))
                CarregaInfoPaciente();  
        }        

        private bool tsHac_PesquisarClick(object sender)
        {            
            this.Cursor = Cursors.WaitCursor;            
            if (grbObs.Visible) btnCancelObs_Click(sender, null);
            lblVerde.Visible = lblImediato.Visible = lblLaranja.Visible = lblSuspensa.Visible = false;
            txtNroInternacao_Validating(sender, null);
            RequisicaoDTO dtoReq = new RequisicaoDTO();
            int? idPrescInt = null;
            string statusItens = "PE"; //PENDENTES

            if (cmbSetor.SelectedIndex > -1)
                dtoReq.IdtSetor.Value = cmbSetor.SelectedValue.ToString();

            if (!string.IsNullOrEmpty(txtNroInternacao.Text) && !string.IsNullOrEmpty(txtNomePac.Text))
                dtoReq.IdtAtendimento.Value = txtNroInternacao.Text;

            if (!string.IsNullOrEmpty(txtCodPrescricao.Text))
                idPrescInt = int.Parse(txtCodPrescricao.Text);

            if (!cbHistorico.Checked)
            {
                if (!cbPendentes.Checked) statusItens = "GE"; //GERADOS

                DateTime dataAtual = Utilitario.ObterDataHoraServidor();
                if (!cbPendentes.Checked && dtoReq.IdtSetor.Value.IsNull && dtoReq.IdtAtendimento.Value.IsNull && idPrescInt == null)
                {
                    dtoReq.DataRequisicao.Value = dataAtual.AddDays(-7).Date; //trazer só até 1 semana atrás
                    dtoReq.DataRequisicao2.Value = dataAtual;
                }
                else if (cbPendentes.Checked)
                {
                    //dtoReq.DataRequisicao.Value = dataAtual.AddDays(-1); //trazer só até 1 dia atrás nas Pendências (eliminando casos de troca de setor)
                    dtoReq.DataRequisicao.Value = dataAtual.AddHours(-12); //trazer Pendências de prescrições de até 12 horas atrás
                    dtoReq.DataRequisicao2.Value = dataAtual;
                }
                dtgPrescricao.DataSource = Requisicao.ListarPrescricaoInt(dtoReq, idPrescInt, statusItens, cbSuspensa.Checked);
            }
            else
                dtgPrescricao.DataSource = Requisicao.ListarPrescricaoIntHistorico(dtoReq, idPrescInt, cbSuspensa.Checked);
            
            dtgPrescricao.ClearSelection();

            tsHac.Items["tsBtnPesquisar"].Enabled = true;
            this.Cursor = Cursors.Default;
            return false;
        }

        private bool tsHac_LimparClick(object sender)
        {
            btnCancelObs_Click(sender, null);
            return true;
        }  

        private void dtgPrescricao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (dtgPrescricao.Columns[e.ColumnIndex].Name == colImprimir.Name)
                {
                    this.Cursor = Cursors.WaitCursor;
                    string nomeRelatorio = "INT_48_PRESCRICAO_MEDICA_NOVA";
                    Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[5];

                    #region Monta Parâmetros

                    int x = 0;

                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PATD_PME_ID", dtgPrescricao.Rows[e.RowIndex].Cells[colCodPresc.Name].Value.ToString());

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
            }
        }

        private bool _editandoPrescricao = false;
        private void dtgPrescricao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                this.Cursor = Cursors.WaitCursor;
                DateTime dataAtual = Utilitario.ObterDataHoraServidor();
                DateTime dataPrescricao = DateTime.Parse(dtgPrescricao.Rows[e.RowIndex].Cells[colData.Name].Value.ToString());
                RequisicaoDTO dtoPedido = new RequisicaoDTO();
                dtoPedido.IdtSetor.Value = int.Parse(dtgPrescricao.Rows[e.RowIndex].Cells[colIdSetor.Name].Value.ToString());
                RequisicaoDataTable dtbReq = Requisicao.ListarParamPedidoAuto(dtoPedido);
                dtbReq = (RequisicaoDataTable)Utilitario.ValidarVigencia(dataAtual,
                                                                         RequisicaoDTO.FieldNames.SetorPedidoAutoDtHoraIniVigencia,
                                                                         RequisicaoDTO.FieldNames.SetorPedidoAutoDtHoraFimVigencia,
                                                                         dtbReq);
                if (dtbReq.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dtgPrescricao.Rows[e.RowIndex].Cells[colPrescricaoStatus.Name].Value.ToString()))
                    {
                        if (dtgPrescricao.Rows[e.RowIndex].Cells[colPrescricaoStatus.Name].Value.ToString() == "S")
                        {
                            MessageBox.Show("PRESCRIÇÃO SUSPENSA!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }

                    bool ultrapassouCorte = false;
                    if (dataAtual.Date == dataPrescricao.AddDays(1).Date)
                    {
                        DateTime dataFimCorte = DateTime.Parse(dataAtual.Date.ToString("dd/MM/yyyy") + " " + ((int)dtbReq.TypedRow(0).SetorPedidoAutoHoraInicioProcesso.Value).ToString().PadLeft(2, '0') + ":00");
                        DateTime dataInicioCorte = Requisicao.DataInicioCorteDiaSeguintePrescricao(dataFimCorte,
                                                                                                   (int)dtbReq.TypedRow(0).SetorPedidoAutoHorasPeriodoDose.Value,
                                                                                                   (int)dtbReq.TypedRow(0).SetorPedidoAutoHorasMinimaIniciar.Value,
                                                                                                   out ultrapassouCorte);
                    }
                    else if (dataPrescricao.Date <= dataAtual.AddDays(-2).Date)
                        ultrapassouCorte = true;

                    //if (ultrapassouCorte)
                    //{
                    //    MessageBox.Show("PRESCRIÇÃO ULTRAPASSOU LIMITE PARA PEDIDO DA DATA/HORA DE CORTE E DEVE SER SUSPENSA, SENDO CRIADA UMA NOVA.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    this.Cursor = Cursors.Default;
                    //    return;
                    //}

                    int idPrescInt = int.Parse(dtgPrescricao.Rows[e.RowIndex].Cells[colCodPresc.Name].Value.ToString());

                    dtoPedido = new RequisicaoDTO();
                    if ((int)dtbReq.TypedRow(0).SetorPedidoAutoFlItensImediatos.Value == 1) dtoPedido.Urgencia.Value = 0;
                    dtoPedido.IdtSetor.Value = int.Parse(dtgPrescricao.Rows[e.RowIndex].Cells[colIdSetor.Name].Value.ToString());
                    RequisicaoItensDataTable dtbReqItem = RequisicaoItens.ListarItensPrescricaoInt(dtoPedido, idPrescInt, "PE");

                    if (dtbReqItem.Rows.Count > 0)
                    {
                        _editandoPrescricao = true;
                        RequisicaoDTO dtoReq = new RequisicaoDTO();
                        dtoReq.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                        dtoReq.IdtAtendimento.Value = dtbReqItem.Rows[0][RequisicaoDTO.FieldNames.IdtAtendimento].ToString();
                        dtoReq.TpAtendimento.Value = "I";
                        dtoReq.IdtUnidade.Value = dtbReqItem.Rows[0][RequisicaoDTO.FieldNames.IdtUnidade].ToString();
                        dtoReq.IdtLocal.Value = dtbReqItem.Rows[0][RequisicaoDTO.FieldNames.IdtLocal].ToString();
                        dtoReq.IdtSetor.Value = dtbReqItem.Rows[0][RequisicaoDTO.FieldNames.IdtSetor].ToString();
                        dtoReq.IdtTipoRequisicao.Value = (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO;
                        dtoReq.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.ABERTA;

                        if (HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao.FrmPersonalizado.GerarPedidoPrescricaoInt(dtoReq, dtbReqItem, ultrapassouCorte))
                        {
                            //Comentado porque o status é atualizado ao gravar item a item da prescrição
                            //RequisicaoItens.UpdStatusItemPrescricaoInt(idPrescInt,
                            //                                           null,
                            //                                           (int)FrmPrincipal.dtoSeguranca.Idt.Value,
                            //                                           "GE");
                            tsHac_PesquisarClick(null);
                        }
                        _editandoPrescricao = false;
                    }
                    else
                    {
                        MessageBox.Show("Nenhum item está mais Pendente nesta Prescrição.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DataTable dtbPresc = Requisicao.ListarPrescricaoInt(new RequisicaoDTO(), idPrescInt, null, false);
                        if (dtbPresc.Rows.Count > 0)
                        {
                            dtgPrescricao.Visible = false;
                            grbObs.Visible = true;
                            lblCodPrescricao.Text = idPrescInt.ToString();

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

                            if (!string.IsNullOrEmpty(dtbPresc.Rows[0]["SEG_USU_ID_INTERV"].ToString()))
                            {
                                dtoUsu = new UsuarioDTO();
                                dtoUsu.Idt.Value = dtbPresc.Rows[0]["SEG_USU_ID_INTERV"].ToString();
                                dtoUsu = Usuario.SelChave(dtoUsu);
                                lblUsuarioInterv.Text = "Registrado por: " + dtoUsu.NmUsuario.Value.ToString().Trim();
                            }

                            #endregion

                            if (string.IsNullOrEmpty(txtObs.Text)) txtObs.Focus();
                        }
                    }                    
                }
                else
                    MessageBox.Show("Setor Sem Parametrização de Geração de Pedido Automático.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Cursor = Cursors.Default;
            }
        }

        private void dtgPrescricao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (int.Parse(dtgPrescricao.Rows[e.RowIndex].Cells[colQtdePend.Name].Value.ToString()) > 0)
                    dtgPrescricao.Rows[e.RowIndex].Cells[colQtdePend.Name].Style.ForeColor = Color.Red;

                if (dtgPrescricao.Rows[e.RowIndex].Cells[colIdAtendimento.Name].Value != null)
                {
                    if (int.Parse(dtgPrescricao.Rows[e.RowIndex].Cells[colQtdeImed.Name].Value.ToString()) > 0)
                    {
                        dtgPrescricao.Rows[e.RowIndex].Cells[colIdAtendimento.Name].Style.BackColor = Color.LightGreen;
                        lblVerde.Visible = lblImediato.Visible = true;
                    }
                }
                if (dtgPrescricao.Rows[e.RowIndex].Cells[colPrescricaoStatus.Name].Value != null)
                {
                    if (!string.IsNullOrEmpty(dtgPrescricao.Rows[e.RowIndex].Cells[colPrescricaoStatus.Name].Value.ToString()))
                    {
                        if (dtgPrescricao.Rows[e.RowIndex].Cells[colPrescricaoStatus.Name].Value.ToString() == "S")
                        {
                            dtgPrescricao.Rows[e.RowIndex].Cells[colCodPresc.Name].Style.BackColor = Color.DarkOrange;
                            lblLaranja.Visible = lblSuspensa.Visible = true;
                        }
                    }
                }
            }
        }

        private void tmPesquisa_Tick(object sender, EventArgs e)
        {
            if (cbHistorico.Checked || grbObs.Visible) return;

            if (!_editandoPrescricao) tsHac_PesquisarClick(null);
        }

        private void cbHistorico_Click(object sender, EventArgs e)
        {
            if (cbHistorico.Checked)
                cbPendentes.Visible = false;
            else
                cbPendentes.Visible = cbPendentes.Checked = true;

            txtNroInternacao.Focus();
        }

        private void btnGravarObs_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblCodPrescricao.Text))
            {
                this.Cursor = Cursors.WaitCursor;

                string categoria = null;
                if (!string.IsNullOrEmpty(txtCategoria.Text.Trim())) categoria = txtCategoria.Text.Trim();

                Requisicao.UpdOBSPrescricaoInt(int.Parse(lblCodPrescricao.Text), new Generico().ObterTextoLimitado(txtObs.Text, 500), (int)FrmPrincipal.dtoSeguranca.Idt.Value, categoria);
                btnCancelObs_Click(sender, e);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnCancelObs_Click(object sender, EventArgs e)
        {
            dtgPrescricao.Visible = true;
            grbObs.Visible = false;
            lblCodPrescricao.Text = string.Empty;
        }

        private void tsPlanilha_Click(object sender, EventArgs e)
        {
            txtDtIni.Text = Utilitario.ObterDataHoraServidor().AddDays(-7).ToString("dd/MM/yyyy");
            txtDtFim.Text = Utilitario.ObterDataHoraServidor().ToString("dd/MM/yyyy");

            // configura panel
            pnlPlanilha.BorderStyle = BorderStyle.FixedSingle;
            pnlPlanilha.Visible = true;
            // configura panel
            return;
        }

        private void txtDtIni_MouseClick(object sender, MouseEventArgs e)
        {
            txtDtIni.Text = string.Empty;
            txtDtIni.Focus();
        }

        private void txtDtFim_MouseClick(object sender, MouseEventArgs e)
        {
            txtDtFim.Text = string.Empty;
            txtDtFim.Focus();
        }

        private void btnGerarPlanilha_Click(object sender, EventArgs e)
        {
            if (txtDtIni.Text == string.Empty)
            {
                MessageBox.Show("Digite a Data Início", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDtIni.Focus();
                return;
            }
            if (txtDtFim.Text == string.Empty)
            {
                MessageBox.Show("Digite a Data Fim", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDtFim.Focus();
                return;
            }
            try
            {
                if (Convert.ToDateTime(txtDtFim.Text).Date < Convert.ToDateTime(txtDtIni.Text).Date)
                {
                    MessageBox.Show("A Data Fim deve ser maior ou igual à Data Início.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDtFim.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Data inválida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToDateTime(txtDtFim.Text).Date > Convert.ToDateTime(txtDtIni.Text).Date.AddMonths(6).Date)
            {
                MessageBox.Show("Período não pode ser superior a 6 meses.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDtFim.Focus();
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            string nomeRelatorio = "GM_60_INTERVENCAO_FARM";
            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[3];

            #region Monta Parâmetros

            int x = 0;

            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pDATA_DE", txtDtIni.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pDATA_ATE", DateTime.Parse(txtDtFim.Text).AddDays(1).Date.ToString());

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

        private void btnCancelarPlanilha_Click(object sender, EventArgs e)
        {
            pnlPlanilha.Visible = false;
            txtDtIni.Text = txtDtFim.Text = string.Empty;
        }
    }
}