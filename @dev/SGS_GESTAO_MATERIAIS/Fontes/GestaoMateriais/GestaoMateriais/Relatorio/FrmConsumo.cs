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

namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    public partial class FrmConsumo : FrmBase
    {
        private const string matMedInicio = "<SELECIONE O PRODUTO CLICANDO NO BOTÃO 'Mat/Med'>";
        private DateTime dataAtual; 

        public FrmConsumo()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇOS

        // MatMed
        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }        

        // Utilitario
        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        #endregion

        #region MÉTODOS        

        private void ExecRelatorio()
        {
            if (dtoMatMed == null || dtoMatMed.Idt.Value.IsNull)
            {
                MessageBox.Show("Selecione o Mat/Med.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtInicio.Text == string.Empty)
            {
                MessageBox.Show("Digite a Data Início do período para consulta", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtInicio.Focus();
                return;
            }
            if (txtFim.Text == string.Empty)
            {
                MessageBox.Show("Digite a Data Fim do período para consulta", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFim.Focus();
                return;
            }
            try
            {
                if (Convert.ToDateTime(txtFim.Text) <= Convert.ToDateTime(txtInicio.Text))
                {
                    MessageBox.Show("A Data Fim deve ser maior que a Data Início.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFim.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Data Início ou Fim inválida.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
            if (DateTime.Parse(Convert.ToDateTime(txtFim.Text).ToString("01/MM/yyyy")) > 
                DateTime.Parse(Convert.ToDateTime(txtInicio.Text).AddMonths(11).ToString("01/MM/yyyy")))
            {
                MessageBox.Show("O período tem que ser menor ou igual a um ano.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFim.Focus();
                return;
            }                      
                        
            DateTime dataInicio = DateTime.Parse(Convert.ToDateTime(txtInicio.Text).ToString("01/MM/yyyy"));
            DateTime dataAux = dataInicio;
            string dataFim = string.Format("{0}/{1}", DateTime.DaysInMonth(DateTime.Parse(txtFim.Text).Year, DateTime.Parse(txtFim.Text).Month), DateTime.Parse(txtFim.Text).ToString("MM/yyyy"));
            string nomeRelatorio = "GM_02_MTMD_CONSUMO";
            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[20];

            #region Monta Parâmetros

            byte x = 0;
            byte meses = 0;
            //Verifica qtd de meses existente no período
            while (dataAux <= DateTime.Parse(Convert.ToDateTime(txtFim.Text).ToString("01/MM/yyyy")))
            {
                dataAux = dataAux.AddMonths(1);
                meses += 1;
            }

            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_ID", dtoMatMed.Idt.Value);            
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_DATA_INICIO", dataInicio.ToString("dd/MM/yyyy"));
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_DATA_FIM", dataFim);            
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("DT_INI", DateTime.Parse(txtInicio.Text).ToString("01/MM/yyyy"));
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("DT_FIM", dataFim);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("USUARIO", FrmPrincipal.dtoSeguranca.Login.Value);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PRODUTO", lblProduto.Text);
            if (meses >= 1) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes1", Generico.ObterMesAno((byte)dataInicio.Month, dataInicio.Year));
            if (meses >= 2) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes2", Generico.ObterMesAno((byte)dataInicio.AddMonths(1).Month, dataInicio.AddMonths(1).Year));
            if (meses >= 3) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes3", Generico.ObterMesAno((byte)dataInicio.AddMonths(2).Month, dataInicio.AddMonths(2).Year));
            if (meses >= 4) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes4", Generico.ObterMesAno((byte)dataInicio.AddMonths(3).Month, dataInicio.AddMonths(3).Year));
            if (meses >= 5) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes5", Generico.ObterMesAno((byte)dataInicio.AddMonths(4).Month, dataInicio.AddMonths(4).Year));
            if (meses >= 6) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes6", Generico.ObterMesAno((byte)dataInicio.AddMonths(5).Month, dataInicio.AddMonths(5).Year));
            if (meses >= 7) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes7", Generico.ObterMesAno((byte)dataInicio.AddMonths(6).Month, dataInicio.AddMonths(6).Year));
            if (meses >= 8) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes8", Generico.ObterMesAno((byte)dataInicio.AddMonths(7).Month, dataInicio.AddMonths(7).Year));
            if (meses >= 9) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes9", Generico.ObterMesAno((byte)dataInicio.AddMonths(8).Month, dataInicio.AddMonths(8).Year));
            if (meses >= 10) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes10", Generico.ObterMesAno((byte)dataInicio.AddMonths(9).Month, dataInicio.AddMonths(9).Year));
            if (meses >= 11) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes11", Generico.ObterMesAno((byte)dataInicio.AddMonths(10).Month, dataInicio.AddMonths(10).Year));
            if (meses >= 12) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes12", Generico.ObterMesAno((byte)dataInicio.AddMonths(11).Month, dataInicio.AddMonths(11).Year));

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

        #endregion

        #region EVENTOS

        private void FrmConsumo_Load(object sender, EventArgs e)
        {
            dataAtual = Utilitario.ObterDataHoraServidor();
            lblProduto.Text = matMedInicio;
            txtInicio.Text = DateTime.Parse(string.Format("01/{0}/{1}", dataAtual.AddMonths(-11).Month, dataAtual.AddMonths(-11).Year)).ToString("dd/MM/yyyy");
            txtFim.Text = DateTime.Parse(string.Format("{0}/{1}/{2}", DateTime.DaysInMonth(dataAtual.Year, dataAtual.Month), dataAtual.Month, dataAtual.Year)).ToString("dd/MM/yyyy");
            tsHac.Items["tsBtnMatMed"].Enabled = true;
        }

        private bool tsHac_MatMedClick(object sender)
        {
            dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(new MaterialMedicamentoDTO());
            if (dtoMatMed == null) return false;
            lblProduto.Text = dtoMatMed.NomeFantasia.Value;
            return true;
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            ExecRelatorio();
            return false;
        }

        private bool tsHac_LimparClick(object sender)
        {            
            return true;
        }

        private void tsHac_AfterLimpar(object sender)
        {
            tsHac.Items["tsBtnMatMed"].Enabled = true;
            dtoMatMed = null;
            lblProduto.Text = matMedInicio;
        }

        #endregion                                   
    }
}