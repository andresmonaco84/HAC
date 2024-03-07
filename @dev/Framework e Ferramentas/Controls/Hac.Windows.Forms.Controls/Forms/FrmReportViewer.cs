using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

using System.Configuration;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Net;
using Hac.Windows.Forms;
using Hac.Windows.Forms.Controls.Forms;
using System.Threading;

namespace Hac.Windows.Forms.Controls.Forms
{
    public partial class FrmReportViewer : FrmBase
    {
        public FrmReportViewer()
        {
            this.MdiParent = null;
            InitializeComponent();
            Titulo = "Relatório";
        }

        private string TituloRelatorio = string.Empty;
        private string RelatorioTemp = string.Empty;
        private ReportParameter[] reportParamTemp;
        private bool ModoImpressao = true;
        private bool DesabilitaExportacao = false;
        private bool DesabilitaImpressao = false;
        private FormWindowState statusJanela = FormWindowState.Maximized;

        private void FrmReportViewer_Load(object sender, EventArgs e)
        {
            this.WindowState = statusJanela;

            Titulo = TituloRelatorio;

            string value = ConfigurationManager.AppSettings["ReportServerURL"];
            string ReportPath = ConfigurationManager.AppSettings["ReportPath"];
            string ReportDomain = ConfigurationManager.AppSettings["ReportDomain"];
            string ReportUser = ConfigurationManager.AppSettings["ReportUser"];
            string ReportPassword = ConfigurationManager.AppSettings["ReportPassword"];
            string ReportSistemaOrigm = string.Empty;

            reportViewer1.ProcessingMode = ProcessingMode.Remote;
            reportViewer1.ServerReport.ReportServerUrl = new Uri(@value);

            NetworkCredential nc = new NetworkCredential(ReportUser, ReportPassword, ReportDomain);
            reportViewer1.ShowCredentialPrompts = false;
            reportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = nc;
            reportViewer1.ShowParameterPrompts = false;

            while (reportViewer1.ServerReport.IsDrillthroughReport)
            {
                reportViewer1.PerformBack();
            }

            try
            {
               reportViewer1.ServerReport.ReportPath = string.Format("{0}{1}", ReportPath, RelatorioTemp);
               
                reportViewer1.ServerReport.SetParameters(reportParamTemp);

                if (DesabilitaExportacao)
                    reportViewer1.ShowExportButton = false;

                if (DesabilitaImpressao)
                    reportViewer1.ShowPrintButton = false;

                if (ModoImpressao)
                {
                    reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                    reportViewer1.ZoomMode = ZoomMode.PageWidth;
                }
                else
                {                                     
                    reportViewer1.ZoomMode = ZoomMode.PageWidth;
                    reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AbreRelatorioPeloClientControl(string Relatorio, ReportParameter[] reportParam, string TituloRelatorio)
        {
            FrmReportViewer frmReportViewer = new FrmReportViewer();
            frmReportViewer.RelatorioTemp = Relatorio;
            frmReportViewer.reportParamTemp = reportParam;
            frmReportViewer.TituloRelatorio = TituloRelatorio;
            AbrirFormularioReportViewer(frmReportViewer);
        }

        public void AbreRelatorio(string Relatorio, ReportParameter[] reportParam, string TituloRelatorio,FormWindowState statusJanela, bool ModoImpressao)
        {
            FrmReportViewer frmReportViewer = new FrmReportViewer();
            frmReportViewer.RelatorioTemp = Relatorio;
            frmReportViewer.reportParamTemp = reportParam;
            frmReportViewer.TituloRelatorio = TituloRelatorio;
            frmReportViewer.ModoImpressao = ModoImpressao;
            frmReportViewer.statusJanela = statusJanela;
            AbrirFormulario(frmReportViewer, false);
        }
        public void AbreRelatorio(string Relatorio, ReportParameter[] reportParam, string TituloRelatorio)
        {
            FrmReportViewer frmReportViewer = new FrmReportViewer();
            frmReportViewer.RelatorioTemp = Relatorio;
            frmReportViewer.reportParamTemp = reportParam;
            frmReportViewer.TituloRelatorio = TituloRelatorio;
            AbrirFormulario(frmReportViewer, false);
        }
        public void AbreRelatorio(string Relatorio, ReportParameter[] reportParam, string TituloRelatorio, FormWindowState statusJanela)
        {
            FrmReportViewer frmReportViewer = new FrmReportViewer();
            frmReportViewer.RelatorioTemp = Relatorio;
            frmReportViewer.reportParamTemp = reportParam;
            frmReportViewer.TituloRelatorio = TituloRelatorio;
            frmReportViewer.statusJanela = statusJanela;
            AbrirFormulario(frmReportViewer, false);
        }
        public void AbreRelatorioDialog(string Relatorio, ReportParameter[] reportParam, string TituloRelatorio)
        {
            FrmReportViewer frmReportViewer = new FrmReportViewer();
            frmReportViewer.RelatorioTemp = Relatorio;
            frmReportViewer.reportParamTemp = reportParam;
            frmReportViewer.TituloRelatorio = TituloRelatorio;
            AbrirFormularioDialog(frmReportViewer);
        }

        public void AbreRelatorioDialogDesabilitaExportacao(string Relatorio, ReportParameter[] reportParam, string TituloRelatorio, bool habilitaImpressao)
        {
            FrmReportViewer frmReportViewer = new FrmReportViewer();
            frmReportViewer.RelatorioTemp = Relatorio;
            frmReportViewer.reportParamTemp = reportParam;
            frmReportViewer.TituloRelatorio = TituloRelatorio;
            frmReportViewer.DesabilitaExportacao = true;
            frmReportViewer.DesabilitaImpressao = !habilitaImpressao;
            AbrirFormularioDialog(frmReportViewer);
        }

        public void AbreRelatorioSemValidarAcesso(string Relatorio, ReportParameter[] reportParam, string TituloRelatorio, FormWindowState statusJanela)
        {
            FrmReportViewer frmReportViewer = new FrmReportViewer();
            frmReportViewer.RelatorioTemp = Relatorio;
            frmReportViewer.reportParamTemp = reportParam;
            frmReportViewer.TituloRelatorio = TituloRelatorio;
            frmReportViewer.statusJanela = statusJanela;
            
            AbrirFormulario(frmReportViewer, false,false);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
        

    }
}