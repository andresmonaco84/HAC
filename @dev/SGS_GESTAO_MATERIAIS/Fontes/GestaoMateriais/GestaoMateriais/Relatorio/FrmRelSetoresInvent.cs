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
    public partial class FrmRelSetoresInvent : FrmBase
    {
        private bool _setoresSaldoSemContagem;
        public bool SetoresSaldoSemContagem
        {
            set { _setoresSaldoSemContagem = value; }
            get { return _setoresSaldoSemContagem; }
        }

        private IInventarioMatMed _inventarioMatMed;
        private IInventarioMatMed InventarioMatMed
        {
            get { return _inventarioMatMed != null ? _inventarioMatMed : _inventarioMatMed = (IInventarioMatMed)Global.Common.GetObject(typeof(IInventarioMatMed)); }
        }

        public FrmRelSetoresInvent()
        {
            InitializeComponent();                        
        }        

        private bool ValidarPeriodo()
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

        private void ExecRelatorio()
        {
            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[4];
            string nomeRelatorio = "GM_24_INVENTARIO_DIGITA_FIM_GERAL";
            if (!rbDigita.Checked)
            {
                if (rbDemonstAnalitico.Checked)
                    nomeRelatorio = "GM_25_INVENT_X_ESTOQUE_GERAL";
                else if (rbDemonstSintetico.Checked)
                    nomeRelatorio = "GM_26_INVENT_X_ESTOQUE_SETORES";
            }

            #region Monta Parâmetros
            byte x = 0;
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_FILIAL_ID", rbHac.Checked ? ((byte)FilialMatMedDTO.Filial.HAC).ToString() :
                                                                                                       rbAcs.Checked ? ((byte)FilialMatMedDTO.Filial.ACS).ToString() :
                                                                                                       ((byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA).ToString());
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_DT_DE", txtInicio.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_DT_ATE", txtFim.Text);

            if (rbDigita.Checked)
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("USUARIO", FrmPrincipal.dtoSeguranca.Login.Value);

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
        }

        private void FrmRelSetoresInvent_Load(object sender, EventArgs e)
        {
            dtgSetores.AutoGenerateColumns = false;
            txtInicio.Text = DateTime.Now.ToString("01/MM/yyyy");
            txtFim.Text = DateTime.Now.ToString("dd/MM/yyyy");
            if (!SetoresSaldoSemContagem)
            {
                tsHac.TituloTela = "Relatórios gerais de inventário dos setores";
                dtgSetores.Visible = false;
                grbEstoque.Visible = grbRelatorio.Visible = true;
                rbHac.Checked = true; rbHac.Checked = false; //Estava vindo forçado CE por algum problema do Designer.cs
                rbDigita.Checked = true; rbDigita.Checked = false; //Estava vindo forçado Rel. Sintetico por algum problema do Designer.cs
            }
            
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            if (!ValidarPeriodo()) return false;

            if (SetoresSaldoSemContagem)
                dtgSetores.DataSource = InventarioMatMed.SetoresSemContagem(DateTime.Parse(txtInicio.Text), DateTime.Parse(txtFim.Text));
            else
            {
                if (!rbAcs.Checked && !rbHac.Checked && !rbCE.Checked)
                {
                    MessageBox.Show("Selecione o Estoque (HAC / ACS / CE)", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if (!rbDigita.Checked && !rbDemonstAnalitico.Checked && !rbDemonstSintetico.Checked)
                {
                    MessageBox.Show("Selecione o Relatório", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                ExecRelatorio();
            }
            
            return false;
        }        
    }
}