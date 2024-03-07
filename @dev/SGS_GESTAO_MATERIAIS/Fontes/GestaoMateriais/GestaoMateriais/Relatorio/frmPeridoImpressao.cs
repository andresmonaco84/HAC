using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    public partial class frmPeridoImpressao : FrmBase
    {

        MovimentacaoDTO dtoMovimento;

        public frmPeridoImpressao(MovimentacaoDTO dto )
        {
            dtoMovimento = dto;
            InitializeComponent();
        }

        private void frmPeridoImpressao_Load(object sender, EventArgs e)
        {

        }

        private void hacButton1_Click(object sender, EventArgs e)
        {
            string nomeRelatorio = "GM_RegistroPerdas";
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


    }
}