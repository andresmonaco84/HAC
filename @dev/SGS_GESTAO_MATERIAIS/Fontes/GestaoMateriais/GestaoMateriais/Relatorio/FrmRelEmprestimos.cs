using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Reporting.WinForms;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using Microsoft.ReportingServices.ReportRendering;
using HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    public partial class FrmRelEmprestimos : FrmBase
    {
        // Utilitario
        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        public FrmRelEmprestimos()
        {
            InitializeComponent();
        }

        private bool ValidarPeriodo()
        {
            DateTime dataAtual = Utilitario.ObterDataHoraServidor();
            //Validar Datas
            if (txtInicio.Text == string.Empty || !BasicFunctions.ValidarData(txtInicio.Text))
            {
                MessageBox.Show("Digite uma data de período inicial válida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Convert.ToDateTime(txtInicio.Text) > dataAtual.Date)
            {
                MessageBox.Show("Data de período inicial não pode ser maior que hoje.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtFim.Text != string.Empty && !BasicFunctions.ValidarData(txtFim.Text))
            {
                MessageBox.Show("Digite uma data de período final válida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtFim.Text.Length > 0)
            {
                if (Convert.ToDateTime(txtInicio.Text) > Convert.ToDateTime(txtFim.Text))
                {
                    MessageBox.Show("A data inicial não pode ser maior que a data final.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
                txtFim.Text = dataAtual.ToString("dd/MM/yyyy");

            TimeSpan periodoConsulta = DateTime.Parse(txtFim.Text) - DateTime.Parse(txtInicio.Text);
            if (periodoConsulta.Days > 92)
            {
                MessageBox.Show("Período não pode ser superior a 3 meses.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void FrmRelEmprestimos_Load(object sender, EventArgs e)
        {
            DateTime dataAtual = Utilitario.ObterDataHoraServidor();
            txtInicio.Text = dataAtual.ToString("01/MM/yyyy");
            txtFim.Text = dataAtual.ToString("dd/MM/yyyy");
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            if (!this.ValidarPeriodo()) return false;

            string nomeRelatorio = "GM_55_EMPRESTIMOS";
            if (chbColunado.Checked) nomeRelatorio = "GM_59_EMPRESTIMOS_COLUNADO";
            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[2];

            #region Monta Parâmetros

            byte x = 0;

            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_MOV_DATA", txtInicio.Text);

            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_MOV_DATA_FIM", txtFim.Text);

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
            tsHac.Focus();

            return false;
        }
    }
}