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

namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    public partial class FrmRelBaixaCCusto : FrmBase
    {
        private const string matMedInicio = "<SELECIONE O PRODUTO CLICANDO NO BOTÃO 'Mat/Med'>";

        private int _idCCusto = 0;
        private ISetor _isetor;
        private ISetor Setor
        {
            get { return _isetor != null ? _isetor : _isetor = (ISetor)Global.Common.GetObject(typeof(ISetor)); }
        }

        // MatMed
        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }

        // GrupoMatMed        
        private IGrupoMatMed _grupoMatMed;
        private IGrupoMatMed GrupoMatMed
        {
            get { return _grupoMatMed != null ? _grupoMatMed : _grupoMatMed = (IGrupoMatMed)Global.Common.GetObject(typeof(IGrupoMatMed)); }
        }

        // MovimentacaoMensal
        private IMovimentacaoMensal _movimentoMensal;
        private IMovimentacaoMensal MovimentoMensal
        {
            get { return _movimentoMensal != null ? _movimentoMensal : _movimentoMensal = (IMovimentacaoMensal)Global.Common.GetObject(typeof(IMovimentacaoMensal)); }
        }

        // Utilitario
        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        //private void ExecRelatorio()
        //{
        //    string nomeRelatorio = "GM_38_BAIXAS_CCUSTO_FECHA";

        //    Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[8];

        //    #region Monta Parâmetros

        //    int x = 0;

        //    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pCAD_MTMD_FILIAL_ID", rbHac.Checked ? "1" : "2");
        //    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pMES", txtMes.Text);
        //    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pANO", txtAno.Text);
            
        //    string dataDe = "01/" + txtMes.Text.PadLeft(2, '0') + "/" + txtAno.Text;
        //    string dataAte = DateTime.DaysInMonth(int.Parse(txtAno.Text), int.Parse(txtMes.Text)).ToString() + "/" + txtMes.Text.PadLeft(2, '0') + "/" + txtAno.Text;
        //    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pDATA_DE", dataDe);
        //    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pDATA_ATE", dataAte);

        //    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pCCUSTO", txtCCusto.Text);
        //    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pCCUSTO_DSC", lblCCustoDsc.Text);
        //    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pCAD_CEC_ID_CCUSTO", _idCCusto.ToString());

        //    #endregion

        //    Microsoft.Reporting.WinForms.ReportParameter[] reportParamTemp = new Microsoft.Reporting.WinForms.ReportParameter[x];

        //    for (int i = 0; i < reportParam.Length; i++)
        //    {
        //        if (reportParam[i] == null) break;
        //        reportParamTemp[i] = reportParam[i];
        //    }
        //    reportParam = reportParamTemp;
        //    reportParamTemp = null;

        //    FrmReportViewer frmRelatorio = new FrmReportViewer();
        //    frmRelatorio.MdiParent = FrmPrincipal.ActiveForm;
        //    frmRelatorio.AbreRelatorio(nomeRelatorio, reportParam);
        //    //tsHac.Focus();
        //    //this.WindowState = FormWindowState.Normal;
        //}

        private void ExecRelatorio()
        {
            string nomeRelatorio = "GM_41_CONSUMO_CCUSTO_FECHA_HIST";
            if (chbDevolucoes.Checked)
                nomeRelatorio = "GM_61_DEVOLUCOES";
            else
            {
                if (chbPlanilhaSimples.Checked)
                    nomeRelatorio = "GM_56_CONS_CCUSTO_PLANILHA";
                else if (chbPorMovimento.Checked)
                    nomeRelatorio = "GM_57_CONS_CCUSTO_MOV";
            }

            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[9];

            #region Monta Parâmetros

            int x = 0;

            string dataDe = "01/" + txtMes.Text.PadLeft(2, '0') + "/" + txtAno.Text;
            string dataAte = DateTime.DaysInMonth(int.Parse(txtAno.Text), int.Parse(txtMes.Text)).ToString() + "/" + txtMes.Text.PadLeft(2, '0') + "/" + txtAno.Text;
            DateTime dtIni = DateTime.Parse(dataDe).AddMonths(-5).Date;
            //if (chbPlanilhaSimples.Checked || chbPorMovimento.Checked) dtIni = DateTime.Parse(dataDe).Date;
            if (chbDevolucoes.Checked || chbPorMovimento.Checked || (chbPlanilhaSimples.Checked && (cmbGrupo.SelectedValue == null || cmbGrupo.SelectedIndex == -1))) dtIni = DateTime.Parse(dataDe).Date;

            if (chbDevolucoes.Checked)
            {
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_MOV_DATA", dtIni.ToString("dd/MM/yyyy"));
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_MOV_DATA_FIM", dataAte);
            }
            else
            {
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pDATA_DE", dtIni.ToString("dd/MM/yyyy"));
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pDATA_ATE", dataAte);

                if (!chbGrupo.Checked)
                {
                    if (!chbTodosSetores.Checked)
                    {
                        if (cmbUnidade.SelectedValue != null) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pCAD_UNI_ID_UNIDADE", cmbUnidade.SelectedValue.ToString());
                        if (cmbSetor.SelectedValue != null && cmbSetor.SelectedIndex > -1)
                            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pCAD_SET_ID", cmbSetor.SelectedValue.ToString());
                    }

                    if (cmbGrupo.SelectedValue != null && cmbGrupo.SelectedIndex > -1)
                        reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pCAD_MTMD_GRUPO_ID", cmbGrupo.SelectedValue.ToString());

                    if (dtoMatMed != null && !dtoMatMed.Idt.Value.IsNull)
                        reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pCAD_MTMD_ID", dtoMatMed.Idt.Value);

                    if (_idCCusto > 0 && !chbPorMovimento.Checked)
                    {
                        reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pCAD_CEC_ID_CCUSTO", _idCCusto.ToString());
                        if (!chbPlanilhaSimples.Checked)
                            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pCCUSTO_DSC", "Centro de Custo: " + txtCCusto.Text);
                    }
                }
                else
                    nomeRelatorio = "GM_43_CONS_CCUSTO_FECHA_HIST_GRUPO";
            }
            if (!rbHac.Checked && !rbConsig.Checked) rbHac.Checked = true;
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pCAD_MTMD_FILIAL_ID", new Generico().RetornaFilial(rbHac, new RadioButton(), new RadioButton(), rbConsig).ToString());

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
            frmRelatorio.MdiParent = FrmPrincipal.ActiveForm;
            frmRelatorio.AbreRelatorio(nomeRelatorio, reportParam);            
        }

        public FrmRelBaixaCCusto()
        {
            InitializeComponent();
        }

        private void FrmRelBaixaCCusto_Load(object sender, EventArgs e)
        {
            cmbUnidade.Carregaunidade();
            Generico.ConfiguraCombos(cmbUnidade, cmbLocal, cmbSetor, FrmPrincipal.dtoSeguranca);

            if (!cmbSetor.Enabled)
                chbGrupo.Visible = chbGrupo.Checked = chbTodosSetores.Visible = chbTodosSetores.Checked = false;

            cmbGrupo.DataSource = GrupoMatMed.Sel(new GrupoMatMedDTO());
            cmbGrupo.IniciaLista();

            txtMes.Text = Utilitario.ObterDataHoraServidor().AddMonths(-1).Month.ToString();
            txtAno.Text = Utilitario.ObterDataHoraServidor().AddMonths(-1).Year.ToString();

            lblProduto.Text = matMedInicio;
            tsRel.Items["tsBtnMatMed"].Enabled = true;            
        }

        private void txtCCusto_Validating(object sender, CancelEventArgs e)
        {
            btnPesquisaCCusto_Click(sender, e);
        }

        private void btnPesquisaCCusto_Click(object sender, EventArgs e)
        {
            _idCCusto = 0;
            lblCCustoDsc.Text = "--";
            if (!string.IsNullOrEmpty(txtCCusto.Text))
            {
                SetorDataTable dtbSetor = Setor.SelSetoresCentroCusto(txtCCusto.Text);
                if (dtbSetor.Rows.Count > 0)
                {
                    bool carregar = false;
                    if (!new Generico().VerificaAcessoFuncionalidade("cmbSetor"))
                    {
                        if (dtbSetor.Select(string.Format("{0}={1}", SetorDTO.FieldNames.Idt, FrmPrincipal.dtoSeguranca.IdtSetor.Value)).Length > 0)
                            carregar = true;
                        else
                        {
                            MessageBox.Show("Usuário/Setor sem permissão de acesso ao Centro de Custo " + dtbSetor.Rows[0]["CAD_CEC_DS_CCUSTO"].ToString(), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCCusto.Text = string.Empty;
                            txtCCusto.Focus();
                            return;
                        }
                    }
                    else
                        carregar = true;

                    if (carregar)
                    {
                        _idCCusto = int.Parse(dtbSetor.Rows[0]["CAD_CEC_ID_CCUSTO"].ToString());
                        lblCCustoDsc.Text = dtbSetor.Rows[0]["CAD_CEC_DS_CCUSTO"].ToString();
                    }
                }
                else
                {                    
                    MessageBox.Show("Centro de Custo não encontrado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCCusto.Text = string.Empty;
                    lblCCustoDsc.Text = "--";
                    txtCCusto.Focus();
                }
            }
        }

        private bool tsRel_PesquisarClick(object sender)
        {
            if (string.IsNullOrEmpty(txtCCusto.Text)) btnPesquisaCCusto_Click(sender, null);
            if (txtMes.Text != string.Empty && txtAno.Text != string.Empty)
            {
                if (int.Parse(txtMes.Text) <= 0 || int.Parse(txtMes.Text) > 12)
                {
                    MessageBox.Show("Mês inválido", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (int.Parse(txtAno.Text) < 1900 || int.Parse(txtAno.Text) > 2099)
                {
                    MessageBox.Show("Ano inválido", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Informe o Mês/Ano", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!chbDevolucoes.Checked)
            {
                if (!chbGrupo.Checked && (dtoMatMed == null || dtoMatMed.Idt.Value.IsNull))
                {
                    if (((chbTodosSetores.Visible && !chbTodosSetores.Checked && cmbUnidade.SelectedIndex == -1) ||
                        (!chbTodosSetores.Visible && cmbUnidade.SelectedIndex == -1)) && _idCCusto == 0)
                    {
                        MessageBox.Show("Selecione a Unidade", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (chbTodosSetores.Visible && chbTodosSetores.Checked && _idCCusto == 0 &&
                        (cmbGrupo.SelectedValue == null || cmbGrupo.SelectedIndex == -1))
                    {
                        MessageBox.Show("Selecione o Grupo", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            //if (string.IsNullOrEmpty(txtCCusto.Text))
            //{
            //    MessageBox.Show("Informe um Centro de Custo válido", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (_idCCusto > 0)
                //ExecRelatorio();

            if (Utilitario.ObterDataHoraServidor().Month == int.Parse(txtMes.Text) && Utilitario.ObterDataHoraServidor().Year == int.Parse(txtAno.Text))
            {
                DateTime? data = MovimentoMensal.ObterUltimaDataFechamento();
                if (data != null)
                    MessageBox.Show("Relatório de estimativa prévia do mês atual com dados atualizados até " + data.Value.ToString("dd/MM/yyyy"), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            ExecRelatorio();

            return true;
        }

        private bool tsRel_MatMedClick(object sender)
        {
            dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(new MaterialMedicamentoDTO());
            if (dtoMatMed == null)
            {
                lblProduto.Text = matMedInicio;
                btnLimparProduto.Visible = false;
                return false;
            }
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

        private void chbPorMovimento_Click(object sender, EventArgs e)
        {
            if (chbPorMovimento.Checked) chbPlanilhaSimples.Checked = chbDevolucoes.Checked = false;
        }

        private void chbPlanilhaSimples_Click(object sender, EventArgs e)
        {
            if (chbPlanilhaSimples.Checked) chbPorMovimento.Checked = chbDevolucoes.Checked = false;
        }

        private void chbTodosSetores_Click(object sender, EventArgs e)
        {
            if (!chbTodosSetores.Checked) chbDevolucoes.Checked = false;
        } 

        private void chbDevolucoes_Click(object sender, EventArgs e)
        {
            if (chbDevolucoes.Checked)
            {
                chbPorMovimento.Checked = chbPlanilhaSimples.Checked = chbGrupo.Checked = false;
                chbTodosSetores.Checked = true;
            }
        }        
    }
}