using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using Microsoft.Reporting.WinForms;
using HospitalAnaCosta.SGS.GestaoMateriais.Relatorio;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmImpPorPeriodo : FrmBase
    {
        ReportParameter[] reportParam; // = new ReportParameter[50];
        string nomeRelatorio, sPeriodo;

        public FrmImpPorPeriodo()
        {
            InitializeComponent();
        }

        public FrmImpPorPeriodo(ReportParameter[] pReportParam, string psNomeRelatorio)
        {
            reportParam = pReportParam;
            nomeRelatorio = psNomeRelatorio;
            InitializeComponent();
        }


        private void FrmImpPorPeriodo_Load(object sender, EventArgs e)
        {
            txtDtProced.Focus();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int X = 10;
            string sDtIni = null, sDtFim = null;
            string sHorIni = null, sHorFim = null, sMinIni = null, sMinFim = null;

            DateTime? dtIni = null;
            DateTime? dtFim = null;

            // verirfica se passou datas
            if (txtDtIni.Text != string.Empty)
            {
                if (txtDtFim.Text == string.Empty)
                {
                    txtDtFim.Text = txtDtIni.Text;
                    // verifica hora, não pode ser menor que hora inicial
                    if (nmHoraFim.Value <= nmHoraIni.Value)
                    {
                        // ajusta hora final para último horário do dia
                        nmHoraFim.Value = 23;
                        nmMinFim.Value = 59;
                    }
                }

                sHorIni = (((nmHoraIni.Value.ToString()).Length == 1) ? string.Format("{0}{1}","0",nmHoraIni.Value.ToString()) : nmHoraIni.Value.ToString());
                sHorFim = (((nmHoraFim.Value.ToString()).Length == 1) ? string.Format("{0}{1}","0", nmHoraFim.Value.ToString()) : nmHoraFim.Value.ToString());

                sMinIni = ((nmMinIni.Value.ToString()).Length == 1 ? string.Format("{0}{1}","0", nmMinIni.Value.ToString()) : nmMinIni.Value.ToString());
                sMinFim = ((nmMinFim.Value.ToString()).Length == 1 ? string.Format("{0}{1}","0", nmMinFim.Value.ToString()) : nmMinFim.Value.ToString());

                sDtIni = string.Format("{0} {1}:{2}", txtDtIni.Text, sHorIni, sMinIni);
                dtIni = Convert.ToDateTime(sDtIni);
                //sDtIni = Convert.ToDateTime(sDtIni).ToString();
                sDtFim = string.Format("{0} {1}:{2}", txtDtFim.Text, sHorFim, sMinFim);
                dtFim = Convert.ToDateTime(sDtFim);
                sPeriodo = string.Format("Período de {0} até {1}", sDtIni, sDtFim);

            }
            else
            {
                sPeriodo = string.Format("Nenhum filtro");
            }

            // Verifica data do procedimento
            if (txtDtProced.Text == string.Empty && txtDtIni.Text != string.Empty)
            {
                txtDtProced.Text = txtDtIni.Text;
            }
            //else if (txtDtProced.Text == string.Empty && txtDtIni.Text == string.Empty)
            //{
            //    txtDtProced.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //}

            if (string.IsNullOrEmpty(dtIni.ToString()))
            {
                string DtVazia = null;
                reportParam[X++] = new ReportParameter("PDATAINI", DtVazia);
                reportParam[X++] = new ReportParameter("PDATAFIM", DtVazia);
            }
            else
            {
                reportParam[X++] = new ReportParameter("PDATAINI", dtIni.ToString());
                reportParam[X++] = new ReportParameter("PDATAFIM", dtFim.ToString());

            }
            reportParam[X++] = new ReportParameter("sDataRel", txtDtProced.Text );
            reportParam[X++] = new ReportParameter("sPeriodo", sPeriodo);


            ReportParameter[] reportParamTemp = new ReportParameter[X];
            for (int i = 0; i < reportParam.Length; i++)
            {
                if (reportParam[i] == null) break;
                reportParamTemp[i] = reportParam[i];
            }
            reportParam = reportParamTemp;
            reportParamTemp = null;

            FrmReportViewer frmRelatorio = new FrmReportViewer();
            frmRelatorio.AbreRelatorio(nomeRelatorio, reportParam);
            // return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}