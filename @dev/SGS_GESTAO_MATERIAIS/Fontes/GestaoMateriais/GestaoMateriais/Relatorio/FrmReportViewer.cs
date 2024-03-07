using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using HospitalAnaCosta.SGS.Componentes;
using System.Configuration;
using System.Net;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    public partial class FrmReportViewer : FrmBase
    {
        public FrmReportViewer()
        {
            InitializeComponent();
        }

        private string RelatorioTemp = "";
        private ReportParameter[] reportParamTemp;
        private bool DesabilitaExportacao = false;

        private void FrmReportViewer_Load(object sender, EventArgs e)
        {
            //ReportParameter[] reportParamFinal = new ReportParameter[50];

            //for (int i = 0; i < reportParamTemp.Length; i++)
            //{
            //    if (reportParamTemp[i] == null)
            //        break;
            //    reportParamFinal[i] = reportParamTemp[i];
            //}

            //reportParamTemp = null;

            this.Cursor = Cursors.WaitCursor;

            string value = ConfigurationSettings.AppSettings["ReportServerURL"];

            reportViewer1.ProcessingMode = ProcessingMode.Remote;


            NetworkCredential nc = new NetworkCredential("relatorio", "relatorio", "anacosta");
            reportViewer1.ShowCredentialPrompts = false;
            reportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = nc;
            reportViewer1.ServerReport.ReportServerUrl = new Uri(@value);

            while (reportViewer1.ServerReport.IsDrillthroughReport)
            {
                reportViewer1.PerformBack();
            }

            try
            {
                reportViewer1.ServerReport.ReportPath = string.Format("{0}{1}", ConfigurationSettings.AppSettings["ReportPath"], RelatorioTemp);
                //reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ServerReport.SetParameters(reportParamTemp);
                reportViewer1.ShowParameterPrompts = false;
                reportViewer1.ZoomMode = ZoomMode.Percent;
                //reportViewer1.ZoomPercent = 100;
                reportViewer1.ShowZoomControl = true;

                if (DesabilitaExportacao)
                    reportViewer1.ShowExportButton = false;

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Cursor = Cursors.Default;
        }

        public void AbreRelatorio(string Relatorio, ReportParameter[] reportParam)
        {
            this.AbreRelatorio(Relatorio, reportParam, false);
        }

        public void AbreRelatorio(string Relatorio, ReportParameter[] reportParam, bool desabilitarExportacao)
        {
            FrmReportViewer frmReportViewer = new FrmReportViewer();
            frmReportViewer.RelatorioTemp = Relatorio;
            frmReportViewer.reportParamTemp = reportParam;
            try
            {
                frmReportViewer.MdiParent = FrmPrincipal.ActiveForm;
            }
            catch
            {
                //Não gerar erro se não for MDI Container
            }
            frmReportViewer.DesabilitaExportacao = desabilitarExportacao;
            //frmReportViewer.WindowState = FormWindowState.Maximized;
            frmReportViewer.Show();
        }
    }
}