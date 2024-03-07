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
using HospitalAnaCosta.Framework;
using HacFramework.Windows.Helpers;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    public partial class FrmRelPrescricaoImp : FrmBase
    {
        public FrmRelPrescricaoImp()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇOS

        private const string matMedInicio = "<SELECIONE O PRODUTO CLICANDO NO BOTÃO 'Mat/Med'>";

        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }      

        private IPrescricao _prescricao;
        private IPrescricao Prescricao
        {
            get { return _prescricao != null ? _prescricao : _prescricao = (IPrescricao)Global.Common.GetObject(typeof(IPrescricao)); }
        }

        private static IDoencaDiagnostico _dodi;
        private static IDoencaDiagnostico DoencaDiagnostico
        {
            get { return _dodi != null ? _dodi : _dodi = (IDoencaDiagnostico)Global.Common.GetObject(typeof(IDoencaDiagnostico)); }
        }

        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        #endregion      
  
        #region Métodos

        private void CarregarComboDoencaDiagnostico(string tipo, HacComboBox cmbDoDi)
        {
            DoencaDiagnosticoDTO dtoDoDi = new DoencaDiagnosticoDTO();
            dtoDoDi.Tipo.Value = tipo;

            cmbDoDi.ValueMember = DoencaDiagnosticoDTO.FieldNames.Id;
            cmbDoDi.DisplayMember = DoencaDiagnosticoDTO.FieldNames.Descricao;
            DoencaDiagnosticoDataTable dtbDoDi = DoencaDiagnostico.Listar(dtoDoDi);

            DataRow row = dtbDoDi.NewRow();
            row[DoencaDiagnosticoDTO.FieldNames.Id] = -1;
            row[DoencaDiagnosticoDTO.FieldNames.Descricao] = "<Selecione>";
            dtbDoDi.Rows.InsertAt(row, 0);

            cmbDoDi.DataSource = dtbDoDi;
        }

        private bool ValidarPeriodo(bool validarIdade)
        {
            if (txtInicio.Text == string.Empty)
            {
                MessageBox.Show("Digite a Data Início", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInicio.Focus();
                return false;
            }
            if (txtFim.Text == string.Empty)
            {
                MessageBox.Show("Digite a Data Fim", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFim.Focus();
                return false;
            }
            try
            {
                if (Convert.ToDateTime(txtFim.Text).Date < Convert.ToDateTime(txtInicio.Text).Date)
                {
                    MessageBox.Show("A Data Fim deve ser maior ou igual à Data Início.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFim.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Data inválida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (validarIdade && (!string.IsNullOrEmpty(txtIdadeDe.Text) && !string.IsNullOrEmpty(txtIdadeAte.Text)))
            {
                if (int.Parse(txtIdadeAte.Text) < int.Parse(txtIdadeDe.Text))
                {
                    MessageBox.Show("A 'Idade até' deve ser maior ou igual à 'Idade de'.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdadeAte.Focus();
                    return false;
                }
            }
            return true;
        }

        private void ExecRelatorio(bool blnPercAutorModif)
        {
            string nomeRelatorio = string.Empty;

            if (blnPercAutorModif)
                nomeRelatorio = "GM_30_PRESCRICOES_PERCENTUAIS";
            else if (rbRelMed.Checked)
                nomeRelatorio = "GM_28_PRESCRICOES_MED";
            else if (rbConsumoSetores.Checked)
                nomeRelatorio = "GM_29_PRESCRICOES_DEMOG_SETOR";
            else if (rbConsumoDoDi.Checked)
                nomeRelatorio = "GM_31_PRESCRICOES_DODI";

            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[11];

            #region Monta Parâmetros

            int x = 0;

            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("USUARIO", FrmPrincipal.dtoSeguranca.Login.Value);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("DATA_DE", txtInicio.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("DATA_ATE", txtFim.Text);

            if (!blnPercAutorModif)
            {
                if (dtoMatMed != null && !dtoMatMed.Idt.Value.IsNull)
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("CAD_MTMD_ID", dtoMatMed.Idt.Value);

                if (cmbUnidade.SelectedIndex > -1)
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("CAD_UNI_ID_UNIDADE", cmbUnidade.SelectedValue.ToString());

                if (cmbLocal.SelectedIndex > -1)
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("CAD_LAT_ID_LOCAL_ATENDIMENTO", cmbLocal.SelectedValue.ToString());

                if (cmbSetor.SelectedIndex > -1)
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("CAD_SET_ID", cmbSetor.SelectedValue.ToString());

                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("IDADE_DE", string.IsNullOrEmpty(txtIdadeDe.Text) ? "0" : txtIdadeDe.Text);
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("IDADE_ATE", string.IsNullOrEmpty(txtIdadeAte.Text) ? "130" : txtIdadeAte.Text);

                if (rbRelMed.Checked)
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pMEDICAMENTO_DESCRICAO", lblProduto.Text);

                if (rbConsumoDoDi.Checked && cmbSetor.SelectedIndex > -1)
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pSetor", cmbUnidade.Text + " / " + cmbSetor.Text);
                else if (rbConsumoDoDi.Checked && cmbLocal.SelectedIndex > -1)
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pSetor", cmbUnidade.Text + " / " + cmbLocal.Text + " / TODOS OS SETORES");
                else if (rbConsumoDoDi.Checked && cmbUnidade.SelectedIndex > -1)
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pSetor", cmbUnidade.Text + " / TODOS OS SETORES");
                else if (rbConsumoDoDi.Checked)
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pSetor", "TODOS OS SETORES");                

                if (rbConsumoDoDi.Checked && cmbDiagnostico.SelectedValue.ToString() != "-1")
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("CAD_MTMD_DODI_ID", cmbDiagnostico.SelectedValue.ToString());
                else if (rbConsumoDoDi.Checked && cmbDoenca.SelectedValue.ToString() != "-1")
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("CAD_MTMD_DODI_ID", cmbDoenca.SelectedValue.ToString());
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
            //frmRelatorio.MdiParent = FrmRelPrescricaoImp.ActiveForm;
            frmRelatorio.AbreRelatorio(nomeRelatorio, reportParam);
            //tsHac.Focus();            
        }

        #endregion

        #region Eventos

        private void FrmRelPrescricaoImp_Load(object sender, EventArgs e)
        {
            lblProduto.Text = matMedInicio;
            txtInicio.Text = Utilitario.ObterDataHoraServidor().AddMonths(-3).ToString("01/MM/yyyy");
            txtFim.Text = Utilitario.ObterDataHoraServidor().ToString("dd/MM/yyyy");
            tsHac.Items["tsBtnMatMed"].Enabled = true;            
            cmbUnidade.Carregaunidade();
            //cmbUnidade.SelectedValue = 244; //SANTOS
            //cmbLocal.SelectedValue = 29; //INTERNADO
            CarregarComboDoencaDiagnostico("DI", cmbDiagnostico);
            CarregarComboDoencaDiagnostico("DO", cmbDoenca);
            btnAtualizarFormCompletos_Click(sender, e);
        }

        private void cmbDiagnostico_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbDiagnostico.SelectedIndex > -1 && cmbDiagnostico.SelectedValue.ToString() != "-1")
            {
                rbConsumoDoDi.Checked = true;
                cmbDoenca.SelectedValue = "-1";
            }
        }

        private void cmbDoenca_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbDoenca.SelectedIndex > -1 && cmbDoenca.SelectedValue.ToString() != "-1")
            {
                rbConsumoDoDi.Checked = true;
                cmbDiagnostico.SelectedValue = "-1";
            }
        }

        private void rbRelMed_Click(object sender, EventArgs e)
        {
            if (rbRelMed.Checked)
            {
                cmbDiagnostico.SelectedValue = "-1";
                cmbDoenca.SelectedValue = "-1";
            }
        }

        private void rbConsumoSetores_Click(object sender, EventArgs e)
        {
            if (rbConsumoSetores.Checked)
            {
                cmbDiagnostico.SelectedValue = "-1";
                cmbDoenca.SelectedValue = "-1";
            }
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

        private bool tsHac_LimparClick(object sender)
        {
            return true;
        }

        private void tsHac_AfterLimpar(object sender)
        {
            tsHac.Items["tsBtnMatMed"].Enabled = rbRelMed.Checked = true;
            btnLimparProduto_Click(null, null);
            txtInicio.Text = Utilitario.ObterDataHoraServidor().AddMonths(-3).ToString("01/MM/yyyy");
            txtFim.Text = Utilitario.ObterDataHoraServidor().ToString("dd/MM/yyyy");
        }

        private void btnLimparProduto_Click(object sender, EventArgs e)
        {
            dtoMatMed = null;
            lblProduto.Text = matMedInicio;
            btnLimparProduto.Visible = false;
        }

        private void btnAtualizarFormCompletos_Click(object sender, EventArgs e)
        {
            txtQtdTotalPrc.Text = txtQtdCompletas.Text = txtQtdIncompletas.Text = string.Empty;
            if (ValidarPeriodo(false))
            {
                this.Cursor = Cursors.WaitCursor;
                PrescricaoDTO dtoPrescricao = new PrescricaoDTO();

                dtoPrescricao.DataInicioConsumo.Value = txtInicio.Text;
                dtoPrescricao.DataLimiteConsumo.Value = txtFim.Text;

                DataTable dtb = Prescricao.ListarFormulariosCompletos(dtoPrescricao);

                if (dtb.Rows.Count > 0)
                {
                    txtQtdTotalPrc.Text = decimal.Parse(dtb.Rows[0]["QTD_TOTAL_PRESCRICOES_PERIODO"].ToString()).ToString("N0");
                    txtQtdCompletas.Text = decimal.Parse(dtb.Rows[0]["QTD_COMPLETAS"].ToString()).ToString("N0");
                    txtQtdIncompletas.Text = decimal.Parse(dtb.Rows[0]["QTD_INCOMPLETAS"].ToString()).ToString("N0");
                }
                else
                    MessageBox.Show("Nenhum registro encontrado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Cursor = Cursors.Default;
            }
        }

        private void btnPercAutorModif_Click(object sender, EventArgs e)
        {
            if (ValidarPeriodo(false))
                ExecRelatorio(true);
        }

        private void btnGerarRel_Click(object sender, EventArgs e)
        {
            if (rbRelMed.Checked && (dtoMatMed == null || dtoMatMed.Idt.Value.IsNull))
            {
                MessageBox.Show("Selecione o Produto.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ValidarPeriodo(true))
                ExecRelatorio(false);
        }

        #endregion        
    }
}