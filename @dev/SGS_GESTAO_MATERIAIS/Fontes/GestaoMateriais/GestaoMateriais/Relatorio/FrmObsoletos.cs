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
    public partial class FrmObsoletos : FrmBase
    {
        // GrupoMatMed        
        private IGrupoMatMed _grupoMatMed;
        private IGrupoMatMed GrupoMatMed
        {
            get { return _grupoMatMed != null ? _grupoMatMed : _grupoMatMed = (IGrupoMatMed)Global.Common.GetObject(typeof(IGrupoMatMed)); }
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

            return true;
        }

        public FrmObsoletos()
        {
            InitializeComponent();
        }

        private void FrmObsoletos_Load(object sender, EventArgs e)
        {
            cmbGrupo.DataSource = GrupoMatMed.Sel(new GrupoMatMedDTO());
            cmbGrupo.IniciaLista();
            tsHac_AfterLimpar(null);            
        }

        private void chbFecha_Click(object sender, EventArgs e)
        {
            if (chbFecha.Checked)
            {
                chbSemEstoque.Checked = false;
                ConfigurarControles(gbFecha.Controls, true);
                ConfigurarControles(gbCobrados.Controls, false);
                txtFim.Text = DateTime.Parse(string.Format("{0}/{1}/{2}", DateTime.DaysInMonth(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month), DateTime.Now.AddMonths(-1).Month, DateTime.Now.AddMonths(-1).Year)).ToString("dd/MM/yyyy");
                txtInicio.Text = Convert.ToDateTime(txtFim.Text).AddMonths(-6).AddDays(1).ToString("dd/MM/yyyy");
            }
            else if (chbSemEstoque.Checked)
            {
                chbFecha.Checked = false;
                ConfigurarControles(gbFecha.Controls, false);
                ConfigurarControles(gbCobrados.Controls, true);
            }
            else
            {
                ConfigurarControles(gbFecha.Controls, false);
                ConfigurarControles(gbCobrados.Controls, false);
            }
        }

        private void chbSemEstoque_Click(object sender, EventArgs e)
        {
            if (chbSemEstoque.Checked) chbFecha.Checked = false;
            chbFecha_Click(sender, e);
        }

        private void tsHac_AfterLimpar(object sender)
        {
            rbHac.Checked = rbCobrados.Checked = true;
            ConfigurarControles(gbFecha.Controls, false);
            ConfigurarControles(gbCobrados.Controls, false);
        }

        private bool tsHac_LimparClick(object sender)
        {
            return true;
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            if (cmbGrupo.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o Grupo.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!chbFecha.Checked && !chbSemEstoque.Checked)
            {
                MessageBox.Show("Selecione uma das 2 opções de relatório", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (chbFecha.Checked && gbFecha.Enabled)
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
            }

            string nomeRelatorio = "GM_16_PRODUTOS_OBSOLETOS";
            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[10];

            if (chbFecha.Checked) nomeRelatorio = "GM_21_OBSOLETOS_SALDO_SETOR";
                        
            #region Monta Parâmetros

            byte x = 0;
            
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("USUARIO", FrmPrincipal.dtoSeguranca.Login.Value);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_GRUPO_ID", cmbGrupo.SelectedValue.ToString());
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("GRUPO", cmbGrupo.Text);
            
            if (chbSemEstoque.Checked)
            {
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PSEM_ESTOQUE", "1");
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pCAD_MTMD_FL_FATURADO", rbCobrados.Checked ? "1" : rbNaoCobrados.Checked ? "0" : null);
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("TITULO", "Produtos ativos sem compra e saldo nos últimos 6 meses");
            }
            else
            {
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_FILIAL_ID", rbHac.Checked ? ((byte)FilialMatMedDTO.Filial.HAC).ToString() :
                                                                                                           rbAcs.Checked ? ((byte)FilialMatMedDTO.Filial.ACS).ToString() :
                                                                                                           null);
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("FILIAL", rbHac.Checked ? Enum.GetName(typeof(FilialMatMedDTO.Filial), FilialMatMedDTO.Filial.HAC) :
                                                                                              rbAcs.Checked ? Enum.GetName(typeof(FilialMatMedDTO.Filial), FilialMatMedDTO.Filial.ACS) :
                                                                                              "--");
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_MOV_DATA_DE", txtInicio.Text);
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_MOV_DATA_ATE", txtFim.Text);
                //reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("TITULO", "Produtos com saldo e sem movimentações no fechamento");
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

            return default(bool);
        }
    }
}