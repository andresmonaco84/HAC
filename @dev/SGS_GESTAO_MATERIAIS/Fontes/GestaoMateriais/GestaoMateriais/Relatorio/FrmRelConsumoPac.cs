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
    public partial class FrmRelConsumoPac : FrmBase
    {
        private const string matMedInicio = "<SELECIONE O PRODUTO CLICANDO NO BOTÃO 'Mat/Med'>";
        private DateTime dataAtual;        

        public FrmRelConsumoPac()
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

        // Atendimento
        private IPaciente _atendimento;
        private IPaciente Atendimento
        {
            get { return _atendimento != null ? _atendimento : _atendimento = (IPaciente)Global.Common.GetObject(typeof(IPaciente)); }
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
            if (!chbPlanilhaCompleta.Checked &&
                ((dtoMatMed == null || dtoMatMed.Idt.Value.IsNull) && !chkSomenteCOVID.Checked) && 
                (string.IsNullOrEmpty(txtNroInternacao.Text) || string.IsNullOrEmpty(txtNomePac.Text)))
            {
                MessageBox.Show("Selecione o Mat/Med. ou o Paciente", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                //if (!chbPlanilhaCompleta.Checked || (chbPlanilhaCompleta.Checked && cmbSetor.SelectedIndex == -1))
                //{
                //    MessageBox.Show("Selecione o Mat/Med. ou o Paciente", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
            }
            if (string.IsNullOrEmpty(txtNomePac.Text))
            {
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
            }
            if (txtInicio.Text != string.Empty)
            {
                try
                {
                    if (Convert.ToDateTime(txtFim.Text) < Convert.ToDateTime(txtInicio.Text))
                    {
                        MessageBox.Show("A Data Fim deve ser maior ou igual à Data Início.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtFim.Focus();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Data Início ou Fim inválida.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(txtNroInternacao.Text))
                {
                    TimeSpan periodoConsulta = DateTime.Parse(txtFim.Text) - DateTime.Parse(txtInicio.Text);
                    if (periodoConsulta.Days > 31)
                    {
                        MessageBox.Show("Período não pode ser superior a 1 mês.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtFim.Focus();
                        return;
                    }
                }
                //if (DateTime.Parse(Convert.ToDateTime(txtFim.Text).ToString("01/MM/yyyy")) >
                //    DateTime.Parse(Convert.ToDateTime(txtInicio.Text).AddMonths(3).ToString("01/MM/yyyy")))
                //{
                //    MessageBox.Show("O período tem que ser menor ou igual a 3 meses.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtFim.Focus();
                //    return;
                //}
            }
            if (cmbSetor.SelectedIndex == -1 &&
                (cmbUnidade.SelectedIndex != -1 || cmbLocal.SelectedIndex != -1))
            {
                if (cmbUnidade.SelectedIndex != -1 && cmbLocal.SelectedIndex != -1)
                {
                    MessageBox.Show("Selecione o Setor ou limpe a Unidade/Local.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbSetor.Focus();
                }
                else if (cmbUnidade.SelectedIndex != -1 && cmbLocal.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione o Local/Setor ou limpe a Unidade.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbLocal.Focus();
                }
                else if (cmbLocal.SelectedIndex != -1)
                {
                    MessageBox.Show("Selecione o Setor ou limpe o Local.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbLocal.Focus();
                }
                return;
            }

            //if (!rbHac.Checked && !rbCE.Checked && !rbAmbos.Checked) rbAmbos.Checked = true;            
            if (!rbHac.Checked && !rbCE.Checked && !rbConsig.Checked)
            {
                MessageBox.Show("Selecione o estoque (HAC / CE / CONS)", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string nomeRelatorio = "GM_14_BAIXAS_PRODUTO_PACIENTE";
            if (chbPlanilhaCompleta.Checked)
                nomeRelatorio = "GM_14_CONSUMO_PAC_CONV";

            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[11];

            #region Monta Parâmetros

            byte x = 0;

            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_FILIAL_ID", new Generico().RetornaFilial(rbHac, new RadioButton(), rbCE, rbConsig).ToString());
            if (!chbPlanilhaCompleta.Checked) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("FILIAL", rbHac.Checked ? "HAC" : "ACS");

            if (dtoMatMed != null && !dtoMatMed.Idt.Value.IsNull)
            {
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_ID", dtoMatMed.Idt.Value);
                if (!chbPlanilhaCompleta.Checked) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PRODUTO", lblProduto.Text);
            }

            if (!string.IsNullOrEmpty(txtNroInternacao.Text) && !string.IsNullOrEmpty(txtNomePac.Text))
            {
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PATD_ATE_ID", txtNroInternacao.Text.Trim());
                if (!chbPlanilhaCompleta.Checked) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PACIENTE", txtNomePac.Text);
            }

            if (txtInicio.Text != string.Empty)
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_MOV_DATA", txtInicio.Text);
            else if (chbPlanilhaCompleta.Checked)
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_MOV_DATA", dataAtual.AddMonths(-6).ToString("01/MM/yyyy"));

            if (txtFim.Text != string.Empty)
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_MOV_DATA_FIM", txtFim.Text);
            else if (chbPlanilhaCompleta.Checked)
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_MOV_DATA_FIM", dataAtual.ToString("dd/MM/yyyy"));

            if (cmbSetor.SelectedIndex != -1)
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_SET_ID", cmbSetor.SelectedValue.ToString());

            if (!chbPlanilhaCompleta.Checked)
            {
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("USUARIO", FrmPrincipal.dtoSeguranca.Login.Value);
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PTIRAR_DATA", chbTirarData.Checked ? "1" : "0");
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PSOMENTECOVID", chkSomenteCOVID.Checked ? "1" : "0");

                if (chkSomenteCOVID.Checked)
                    nomeRelatorio = "GM_14_BAIXAS_PRODUTO_PACIENTE_COVID";
            }            
            
           // reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCOM_PEDIDO", "0");
            
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

        private void CarregaInfoPaciente()
        {
            if (string.IsNullOrEmpty(txtNroInternacao.Text)) return;
            DataTable dtPaciente = Atendimento.ObterPaciente(decimal.Parse(txtNroInternacao.Text));

            if (dtPaciente.Rows.Count > 0)
            {
                txtNomePac.Text = dtPaciente.Rows[0][1].ToString();
                txtInicio.Text = txtFim.Text = string.Empty;
            }
            else
            {
                txtNomePac.Text = string.Empty;                
            }
        }

        #endregion        

        #region EVENTOS
                
        private void FrmRelConsumoPac_Load(object sender, EventArgs e)
        {
            dataAtual = Utilitario.ObterDataHoraServidor();
            lblProduto.Text = matMedInicio;            
            txtFim.Text = DateTime.Parse(string.Format("{0}/{1}/{2}", dataAtual.Day, dataAtual.Month, dataAtual.Year)).ToString("dd/MM/yyyy");
            txtInicio.Text = DateTime.Parse(txtFim.Text).AddDays(-7).ToString("dd/MM/yyyy");
            tsHac.Items["tsBtnMatMed"].Enabled = true;
            cmbUnidade.Carregaunidade();
        }

        private bool tsHac_MatMedClick(object sender)
        {
            dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(new MaterialMedicamentoDTO());
            if (dtoMatMed == null)
            {
                lblProduto.Text = matMedInicio;
                return false;
            } 
            lblProduto.Text = dtoMatMed.NomeFantasia.Value;
            btnLimparProduto.Visible = true;
            return true;
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            if (txtNroInternacao.Text.Length != 0)
                btnPesquisaPac_Click(sender, null);
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
            btnLimparProduto_Click(null, null);
            cmbUnidade.LimparCmbUnidade();
        }

        private void btnPesquisaPac_Click(object sender, EventArgs e)
        {
            if (txtNroInternacao.Enabled) CarregaInfoPaciente();            
        }

        private void btnLimparProduto_Click(object sender, EventArgs e)
        {
            dtoMatMed = null;
            lblProduto.Text = matMedInicio;
            btnLimparProduto.Visible = false;
        }

        private void txtNroInternacao_Validating(object sender, CancelEventArgs e)
        {
            if (txtNroInternacao.Text.Length != 0)
                btnPesquisaPac_Click(sender, e);
            else
            {
                txtNomePac.Text = string.Empty;
                txtFim.Text = DateTime.Parse(string.Format("{0}/{1}/{2}", dataAtual.Day, dataAtual.Month, dataAtual.Year)).ToString("dd/MM/yyyy");
                txtInicio.Text = DateTime.Parse(txtFim.Text).AddDays(-7).ToString("dd/MM/yyyy");
            }
        }

        private void cmbUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUnidade.SelectedIndex == -1)
                cmbLocal.LimparCmbLocal();
        }

        private void cmbLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLocal.SelectedIndex == -1)
                cmbSetor.LimparCmbSetor();
        }

        private void cmbSetor_SelectedIndexChanged(object sender, EventArgs e)
        {
                     
        }

        private void chbPlanilhaCompleta_Click(object sender, EventArgs e)
        {
            if (chbPlanilhaCompleta.Checked)
            {
                chkSomenteCOVID.Checked = chbTirarData.Checked = false;
                //rbHac.Checked = true;
            }
        }

        private void chkSomenteCOVID_Click(object sender, EventArgs e)
        {
            if (chkSomenteCOVID.Checked) chbPlanilhaCompleta.Checked = false;                
        }        

        private void rbAcs_Click(object sender, EventArgs e)
        {
            if (rbCE.Checked) chbPlanilhaCompleta.Checked = false;
        }

        private void rbHac_Click(object sender, EventArgs e)
        {
            if (rbHac.Checked) chbPlanilhaCompleta.Checked = false;
        }

        private void chbTirarData_Click(object sender, EventArgs e)
        {
            if (chbTirarData.Checked) chbPlanilhaCompleta.Checked = false;
        }
        #endregion
    }
}