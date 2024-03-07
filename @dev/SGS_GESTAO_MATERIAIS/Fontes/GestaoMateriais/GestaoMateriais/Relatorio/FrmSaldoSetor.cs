using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Reporting.WinForms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using Microsoft.ReportingServices.ReportRendering;
using HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    public partial class FrmSaldoSetor : FrmBase
    {
        private const string matMedInicio = "<SELECIONE O PRODUTO CLICANDO NO BOTÃO 'Mat/Med'>";

        private bool _baixasSetorDia;
        public bool BaixasSetorDia
        {
            set { _baixasSetorDia = value; }
            get { return _baixasSetorDia; }
        }

        private bool _atdDomiciliar;
        public bool AtendimentoDomiciliar
        {
            set { _atdDomiciliar = value; }
            get { return _atdDomiciliar; }
        }

        private bool _pedidos;
        public bool Pedidos
        {
            set { _pedidos = value; }
            get { return _pedidos; }
        }

        private bool _baixasPacienteSetor;
        public bool BaixasPacienteSetor
        {
            set { _baixasPacienteSetor = value; }
            get { return _baixasPacienteSetor; }
        }

        private bool _baixasSetorXFat;
        public bool BaixasSetorXFat
        {
            set { _baixasSetorXFat = value; }
            get { return _baixasSetorXFat; }
        }

        private bool _baixasEntradasSetor;
        public bool BaixasEntradasSetor
        {
            set { _baixasEntradasSetor = value; }
            get { return _baixasEntradasSetor; }
        }

        public FrmSaldoSetor()
        {           
            InitializeComponent();            
        }

        #region OBJETOS SERVIÇOS

        // GrupoMatMed        
        private IGrupoMatMed _grupoMatMed;
        private IGrupoMatMed GrupoMatMed
        {
            get { return _grupoMatMed != null ? _grupoMatMed : _grupoMatMed = (IGrupoMatMed)Global.Common.GetObject(typeof(IGrupoMatMed)); }
        }

        // SubGrupoMatMed
        private SubGrupoMatMedDTO dtoSubGrupo;
        private ISubGrupoMatMed _subGrupoMatMed;
        private ISubGrupoMatMed SubGrupoMatMed
        {
            get { return _subGrupoMatMed != null ? _subGrupoMatMed : _subGrupoMatMed = (ISubGrupoMatMed)Global.Common.GetObject(typeof(ISubGrupoMatMed)); }
        }

        // MatMed
        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }

        // Setor                  
        private ISetor _isetor;
        private ISetor Setor
        {
            get { return _isetor != null ? _isetor : _isetor = (ISetor)Global.Common.GetObject(typeof(ISetor)); }
        }
        
        #endregion

        #region MÉTODOS

        private void CarregarComboGrupo()
        {
            cmbGrupo.DataSource = GrupoMatMed.Sel(new GrupoMatMedDTO());
            cmbGrupo.IniciaLista();
        }

        private void CarregarComboSubGrupo()
        {
            dtoSubGrupo = new SubGrupoMatMedDTO();
            dtoSubGrupo.IdtGrupo.Value = cmbGrupo.SelectedValue.ToString();
            cmbSubGrupo.DataSource = SubGrupoMatMed.Sel(dtoSubGrupo);
            cmbSubGrupo.IniciaLista();
        }

        private void ExecRelatorio()
        {
            string nomeRelatorio = "GM_03_MTMD_SALDO_SETOR";
            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[25];

            if (BaixasSetorDia) nomeRelatorio = "GM_13_BAIXAS_SETOR_DIA";
            else if (BaixasPacienteSetor) nomeRelatorio = "GM_18_BAIXAS_SETOR";
            else if (BaixasEntradasSetor) nomeRelatorio = "GM_20_MOVIMENTOS_SETOR";
            else if (BaixasSetorXFat) nomeRelatorio = "GM_52_BAIXAS_ESTOQUE_X_FATURA";
            else if (chbLote.Checked) nomeRelatorio = "GM_51_MED_LOTE";
            else if (Pedidos) nomeRelatorio = "GM_54_PEDIDOS";
            else if (chbPlanilhaCompleta.Checked) nomeRelatorio = "GM_03_MTMD_SALDO_SETORES_PLANILHA";
            
            if (chbDDD.Checked) nomeRelatorio = "GM_53_CONSUMO_ANTIBIOTICOS_DDD";

            if (!chbPlanilhaCompleta.Checked && !chbDDD.Checked && !Pedidos)
            {
                if (!BaixasEntradasSetor && (cmbUnidade.SelectedIndex == -1 || cmbLocal.SelectedIndex == -1 || cmbSetor.SelectedIndex == -1))
                {
                    MessageBox.Show("Selecione Unidade/Local/Setor antes de pesquisar", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (grbEstoque.Visible && (!rbAcs.Checked && !rbHac.Checked && !rbCE.Checked && !rbConsig.Checked))
                {
                    //MessageBox.Show("Selecione o estoque (HAC / ACS / CE)", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MessageBox.Show("Selecione o estoque (HAC / CE / CONS)", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            #region Monta Parâmetros

            byte x = 0;

            if (chbSepse.Visible && chbSepse.Checked)
            {
                nomeRelatorio = "GM_58_PEDIDOS_SEPSE";
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_MOV_DATA", txtInicio.Text);
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_MOV_DATA_FIM", txtFim.Text);
            }
            else
            {
                if (!chbDDD.Checked)
                {
                    if (!BaixasEntradasSetor && !BaixasSetorXFat && !Pedidos && !chbPlanilhaCompleta.Checked)
                    {
                        if (!chbLote.Checked)
                        {
                            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_UNI_ID_UNIDADE", cmbUnidade.SelectedValue.ToString()); cmbUnidade.Focus();
                            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("UNIDADE", cmbUnidade.Text);
                            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_LAT_ID_LOCAL_ATENDIMENTO", cmbLocal.SelectedValue.ToString()); cmbLocal.Focus();
                            if (!BaixasPacienteSetor)
                                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("LOCAL", cmbLocal.Text);
                        }
                        if (!chbLote.Checked)
                            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("SETOR", cmbSetor.Text);
                        else
                            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PSETOR", cmbSetor.Text);
                    }
                    if (cmbSetor.SelectedIndex != -1)
                    {
                        reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_SET_ID", cmbSetor.SelectedValue.ToString());
                        cmbSetor.Focus();

                        if (BaixasSetorXFat && !Pedidos && !chbPlanilhaCompleta.Checked)
                            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PSETOR", cmbSetor.Text);
                    }

                    if (grbEstoque.Visible)
                    {
                        if (!rbAcs.Checked && !rbHac.Checked && !rbCE.Checked && !rbConsig.Checked) rbHac.Checked = true;
                        reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_FILIAL_ID", rbHac.Checked ? ((byte)FilialMatMedDTO.Filial.HAC).ToString() :
                                                                                                                   rbConsig.Checked ? ((byte)FilialMatMedDTO.Filial.CONSIGNADO).ToString() :
                                                                                                                   rbAcs.Checked ? ((byte)FilialMatMedDTO.Filial.ACS).ToString() :
                                                                                                                   ((byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA).ToString());
                        if (!BaixasEntradasSetor && !chbLote.Checked && !Pedidos && !chbPlanilhaCompleta.Checked)
                            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("FILIAL", rbHac.Checked ? Enum.GetName(typeof(FilialMatMedDTO.Filial), FilialMatMedDTO.Filial.HAC) :
                                                                                                          rbConsig.Checked ? Enum.GetName(typeof(FilialMatMedDTO.Filial), FilialMatMedDTO.Filial.CONSIGNADO) :
                                                                                                          rbAcs.Checked ? Enum.GetName(typeof(FilialMatMedDTO.Filial), FilialMatMedDTO.Filial.ACS) :
                                                                                                          "CARRINHO DE EMERGÊNCIA");
                    }
                    if (!chbLote.Checked && !BaixasSetorXFat && !Pedidos && !chbPlanilhaCompleta.Checked) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("USUARIO", FrmPrincipal.dtoSeguranca.Login.Value);
                    if (cmbGrupo.SelectedIndex > -1 && !BaixasSetorXFat)
                    {
                        if (!chbLote.Checked)
                        {
                            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_GRUPO_ID", cmbGrupo.SelectedValue.ToString());
                            if (BaixasSetorDia || BaixasPacienteSetor) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("GRUPO", cmbGrupo.Text);
                            if (Pedidos) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PGRUPO", cmbGrupo.Text);
                        }
                        if (cmbSubGrupo.SelectedIndex > -1 && !BaixasSetorDia && !BaixasPacienteSetor) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_SUBGRUPO_ID", cmbSubGrupo.SelectedValue.ToString());
                    }
                    if (!BaixasSetorDia && !BaixasPacienteSetor && !BaixasEntradasSetor && !BaixasSetorXFat && !Pedidos && !chbPlanilhaCompleta.Checked)
                    {
                        if (!chbLote.Checked)
                        {
                            if (rbApenasMateriais.Checked)
                                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PTIS_MED_CD_TABELAMEDICA", ((byte)MaterialMedicamentoDTO.TipoMatMed.MATERIAL).ToString());
                            else if (rbApenasMedicamentos.Checked)
                                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PTIS_MED_CD_TABELAMEDICA", ((byte)MaterialMedicamentoDTO.TipoMatMed.MEDICAMENTO).ToString());
                        }
                    }
                }
                if (BaixasSetorDia || BaixasPacienteSetor || BaixasEntradasSetor || BaixasSetorXFat || Pedidos)
                {
                    if (!chbDDD.Checked && !Pedidos)
                    {
                        reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDATA_DE", txtInicio.Text);
                        reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDATA_ATE", txtFim.Text);
                    }
                    else
                    {
                        reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_MOV_DATA", txtInicio.Text);
                        reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_MOV_DATA_FIM", txtFim.Text);
                    }
                }
                if (BaixasEntradasSetor && !chbDDD.Checked)
                {
                    if (dtoMatMed != null)
                        reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_ID", dtoMatMed.Idt.Value.ToString());

                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PAGRUPAR_SETOR", chbAgruparSetor.Checked ? true.ToString() : false.ToString());

                    TimeSpan periodoConsulta = DateTime.Parse(txtFim.Text) - DateTime.Parse(txtInicio.Text);
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDIAS_PERIODO_CONSULTA", periodoConsulta.Days.ToString());
                }

                if (nomeRelatorio == "GM_03_MTMD_SALDO_SETOR" && chbOrdenarEnd.Visible && chbOrdenarEnd.Checked)
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pORDENAR_ENDERECO", "1");

                if (cmbTipoPedido.Visible && cmbTipoPedido.SelectedIndex > 0)
                {
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTM_TIPO_REQUISICAO", cmbTipoPedido.SelectedValue.ToString());
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PTIPO", cmbTipoPedido.Text);
                }

                if (!chbPlanilhaCompleta.Checked)
                {
                    if (chbPadrao.Visible && chbPadrao.Checked)
                        reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pCAD_MTMD_FL_PADRAO", "1");

                    if (chbPadraoNao.Visible && chbPadraoNao.Checked)
                        reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pCAD_MTMD_FL_PADRAO", "0");
                }
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
            //tsHac.Focus();
        }

        private bool ValidarPeriodo()
        {
            if (txtFim.Text.Length > 0)
            {
                if (Convert.ToDateTime(txtInicio.Text) > Convert.ToDateTime(txtFim.Text))
                {
                    MessageBox.Show("A data inicial não pode ser maior que a data final.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
                txtFim.Text = DateTime.Now.ToString("dd/MM/yyyy");

            TimeSpan periodoConsulta = DateTime.Parse(txtFim.Text) - DateTime.Parse(txtInicio.Text);
            if (periodoConsulta.Days > 62)
            {
                MessageBox.Show("Período não pode ser superior a 2 meses.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion

        #region EVENTOS

        private void FrmSaldoSetor_Load(object sender, EventArgs e)
        {
            this.AccessibleName = AtendimentoDomiciliar ? "FrmSaldoSetorAtdDomiciliar" : "FrmSaldoSetor";
            lblProduto.Text = matMedInicio;
            cmbUnidade.Carregaunidade();
            CarregarComboGrupo();
            tsHac.Items["tsBtnMatMed"].Enabled = true;
            groupBox6.Text = "Seleção Obrigatória";
            if (BaixasSetorDia || BaixasPacienteSetor || BaixasEntradasSetor || BaixasSetorXFat || Pedidos)
            {
                grbPeriodo.Visible = true;
                grbMatMed.Visible = chbOrdenarEnd.Visible = false;
                if (!BaixasEntradasSetor)
                    lblSubGrupo.Visible = cmbSubGrupo.Visible = false;
                groupBox3.Text = "Seleção de Filtro";
                if (BaixasEntradasSetor)
                {
                    groupBox3.Text = groupBox6.Text = string.Empty;
                    tsHac.TituloTela = "Relatório de Baixas/Entradas de Mat/Med por Setor";
                    chbAgruparSetor.Visible = lblProd.Visible = lblProduto.Visible = tsHac.MatMedVisivel = true;
                    txtInicio.Text = DateTime.Now.ToString("01/MM/yyyy");
                    txtFim.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else if (BaixasPacienteSetor)
                {
                    tsHac.TituloTela = "Relatório de Baixas ao Paciente por Setor";
                    grbEstoque.Visible = false;
                    txtInicio.Text = DateTime.Parse(string.Format("01/{0}/{1}", DateTime.Now.AddMonths(-1).Month, DateTime.Now.AddMonths(-1).Year)).ToString("dd/MM/yyyy");
                    txtFim.Text = DateTime.Parse(string.Format("{0}/{1}/{2}", DateTime.DaysInMonth(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month), DateTime.Now.AddMonths(-1).Month, DateTime.Now.AddMonths(-1).Year)).ToString("dd/MM/yyyy");
                }
                else if (BaixasSetorXFat)
                {
                    tsHac.TituloTela = "Relatório de Baixas Setor x Faturamento";
                    grbEstoque.Visible = false;
                    txtInicio.Text = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
                    txtFim.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    cmbGrupo.SelectedValue = 1;
                    cmbGrupo.Enabled = false;
                }
                else
                {
                    tsHac.TituloTela = "Relatório de Baixas Diárias do Setor";
                    txtFim.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtInicio.Text = Convert.ToDateTime(txtFim.Text).AddDays(-10).ToString("dd/MM/yyyy");
                }
                if (BaixasSetorDia) chbDDD.Visible = true;
                if (Pedidos)
                {
                    cmbTipoPedido.Visible = lblTipoPedido.Visible = true;
                    Generico.CarregarComboTipoPedido(ref cmbTipoPedido);
                    tsHac.TituloTela = "Relatório de Pedidos";
                    chbSepse.Visible = true;
                }
            }
            else
                chbLote.Visible = chbPadraoNao.Visible = chbPadrao.Visible = chbPlanilhaCompleta.Visible = true;

            if (AtendimentoDomiciliar)
            {
                tsHac.TituloTela = "Relatório de Baixas ao Paciente de Atendimento Domiciliar";
                cmbUnidade.Limpar = cmbLocal.Limpar = cmbSetor.Limpar =
                cmbUnidade.Enabled = cmbLocal.Enabled = cmbSetor.Enabled = chbOrdenarEnd.Visible = chbLote.Visible = chbPadraoNao.Visible = chbPadrao.Visible = chbPlanilhaCompleta.Visible = false;
                cmbUnidade.Editavel = cmbLocal.Editavel = cmbSetor.Editavel = ControleEdicao.Nunca;
                cmbUnidade.SelectedValue = 244; //SANTOS
                cmbLocal.SelectedValue = 46; //ATENDIMENTO DOMICILIAR
                cmbSetor.SelectedValue = 2252; //ATENDIMENTO DOMICILIAR
            }
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            if (!chbDDD.Visible) chbDDD.Checked = false;                

            if (BaixasSetorDia || BaixasPacienteSetor || BaixasEntradasSetor || BaixasSetorXFat || Pedidos)
            {
                //Validar Datas
                if (txtInicio.Text == string.Empty || !BasicFunctions.ValidarData(txtInicio.Text))
                {
                    MessageBox.Show("Digite uma data de período inicial válida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (Convert.ToDateTime(txtInicio.Text) > DateTime.Now.Date)
                {
                    MessageBox.Show("Data de período inicial não pode ser maior que hoje.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtFim.Text != string.Empty && !BasicFunctions.ValidarData(txtFim.Text))
                {
                    MessageBox.Show("Digite uma data de período final válida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (!this.ValidarPeriodo()) return false;

                if (!chbDDD.Checked && !chbSepse.Checked)
                {
                    if (Pedidos)
                    {
                        if (cmbTipoPedido.SelectedValue == null)
                            cmbTipoPedido.SelectedIndex = 0;

                        if (cmbGrupo.SelectedIndex == -1 && (cmbTipoPedido.SelectedValue.ToString() == "-1" || cmbTipoPedido.SelectedIndex == 0))
                        {
                            MessageBox.Show("Selecione o Grupo ou o Tipo Pedido.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        if (!BaixasEntradasSetor && cmbGrupo.SelectedIndex == -1)
                        {
                            MessageBox.Show("Selecione o Grupo.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        else if (BaixasEntradasSetor)
                        {
                            if (cmbGrupo.SelectedIndex == -1 && dtoMatMed == null)
                            {
                                MessageBox.Show("Selecione o Grupo ou o Produto.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                }
            }
            ExecRelatorio();
            return false;
        }

        private bool tsHac_LimparClick(object sender)
        {
            return true;
        }

        private void tsHac_AfterLimpar(object sender)
        {
            cmbUnidade.Focus();
            tsHac.Items["tsBtnMatMed"].Enabled = true;
            rbTodos.Checked = true;
            btnLimparProduto_Click(null, null);
            if (chbLote.Visible) cmbGrupo.Enabled = grbMatMed.Visible = true;
            if (chbOrdenarEnd.Visible) chbOrdenarEnd.Enabled = true;
        }

        private bool tsHac_MatMedClick(object sender)
        {
            dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(new MaterialMedicamentoDTO());
            if (dtoMatMed == null) return false;
            lblProduto.Text = dtoMatMed.NomeFantasia.Value;
            btnLimparProduto.Visible = true;
            return true;
        }

        private void btnLimparProduto_Click(object sender, EventArgs e)
        {
            dtoMatMed = null;
            lblProduto.Text = matMedInicio;
            btnLimparProduto.Visible = false;
        }

        private void cmbGrupo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CarregarComboSubGrupo();
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            chbOrdenarEnd.Visible = false;
            if (!BaixasSetorDia && !BaixasEntradasSetor && !BaixasPacienteSetor && !BaixasSetorXFat && !Pedidos &&
                cmbSetor.SelectedIndex > -1)
            {
                this.Cursor = Cursors.WaitCursor;
                SetorDTO dtoSetor = new SetorDTO();
                dtoSetor.Idt.Value = cmbSetor.SelectedValue.ToString();
                dtoSetor = Setor.SelChave(dtoSetor);
                this.Cursor = Cursors.Default;

                if (dtoSetor.FlAlmoxCentral.Value == (byte)SetorDTO.AlmoxarifadoCentral.SIM || (int)dtoSetor.Idt.Value == 2592) //2592 = Farmacia Central
                    chbOrdenarEnd.Visible = true;
            }   
        }

        private void chbLote_Click(object sender, EventArgs e)
        {
            cmbGrupo.Enabled = grbMatMed.Visible = true;            
            chbOrdenarEnd.Checked = false;
            if (chbOrdenarEnd.Visible) chbOrdenarEnd.Enabled = true;
            
            if (chbLote.Checked)
            {
                chbPlanilhaCompleta.Checked = false;
                rbHac.Checked = true;
                cmbGrupo.SelectedValue = 1;
                CarregarComboSubGrupo();
                cmbGrupo.Enabled = grbMatMed.Visible = false;
                if (chbOrdenarEnd.Visible) chbOrdenarEnd.Enabled = false;
            }
        }

        private void chbSepse_Click(object sender, EventArgs e)
        {
            if (chbSepse.Checked)            
                groupBox3.Visible = false;            
            else
                groupBox3.Visible = true;
        }

        private void chbPadrao_Click(object sender, EventArgs e)
        {
            if (chbPadrao.Checked)
                chbPadraoNao.Checked = chbPlanilhaCompleta.Checked = false;
        }

        private void chbPadraoNao_Click(object sender, EventArgs e)
        {
            if (chbPadraoNao.Checked)
                chbPadrao.Checked = chbPlanilhaCompleta.Checked = false;
        }

        private void chbPlanilhaCompleta_Click(object sender, EventArgs e)
        {
            if (chbPlanilhaCompleta.Checked)
            {
                rbTodos.Checked = true;
                chbLote.Checked = chbPadrao.Checked = chbPadraoNao.Checked = false;
                chbLote.Visible = chbPadrao.Visible = chbPadraoNao.Visible = false;
                chbLote_Click(sender, e);
                if (chbOrdenarEnd.Visible) chbOrdenarEnd.Enabled = false;
            }
            else
            {                
                chbLote.Visible = chbPadrao.Visible = chbPadraoNao.Visible = true;
                if (chbOrdenarEnd.Visible) chbOrdenarEnd.Enabled = true;
            }
        }
        #endregion 
    }
}