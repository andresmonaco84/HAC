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

namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    public partial class FrmKardex : FrmBase
    {
        private const string matMedInicio = "<SELECIONE O PRODUTO CLICANDO NO BOTÃO 'Mat/Med'>";

        // MatMed
        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }

        // GrupoMatMed        
        private IGrupoMatMed _grupoMatMed;
        private IGrupoMatMed GrupoMatMed
        {
            get { return _grupoMatMed != null ? _grupoMatMed : _grupoMatMed = (IGrupoMatMed)Global.Common.GetObject(typeof(IGrupoMatMed)); }
        }

        // Utilitario
        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        public FrmKardex()
        {
            InitializeComponent();
        }

        private void ExecRelatorio()
        {
            string nomeRelatorio = "GM_47_KARDEX";

            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[6];

            #region Monta Parâmetros

            int x = 0;

            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDATA_DE", txtInicio.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDATA_ATE", DateTime.Parse(txtFim.Text).AddDays(1).Date.ToString());
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_FILIAL_ID", rbHac.Checked ? ((byte)FilialMatMedDTO.Filial.HAC).ToString() :
                                                                                                       ((byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA).ToString());
            if (cmbSetor.SelectedValue != null && cmbSetor.SelectedIndex > -1)
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_SET_ID", cmbSetor.SelectedValue.ToString());

            if (cmbGrupo.SelectedValue != null && cmbGrupo.SelectedIndex > -1)
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_GRUPO_ID", cmbGrupo.SelectedValue.ToString());

            if (dtoMatMed != null && !dtoMatMed.Idt.Value.IsNull)
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_ID", dtoMatMed.Idt.Value);

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
            frmRelatorio.MdiParent = FrmPrincipal.ActiveForm;
            frmRelatorio.AbreRelatorio(nomeRelatorio, reportParam);
        }

        private bool ValidarPeriodo()
        {
            //Validar Datas
            if (txtInicio.Text == string.Empty || !BasicFunctions.ValidarData(txtInicio.Text))
            {
                MessageBox.Show("Digite uma data de período inicial válida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInicio.Focus();
                return false;
            }
            else if (Convert.ToDateTime(txtInicio.Text) > Utilitario.ObterDataHoraServidor().Date)
            {
                MessageBox.Show("Data de período inicial não pode ser maior que hoje.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInicio.Focus();
                return false;
            }
            if (txtFim.Text == string.Empty || !BasicFunctions.ValidarData(txtFim.Text))
            {
                MessageBox.Show("Digite uma data de período final válida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFim.Focus();
                return false;
            }
            if (Convert.ToDateTime(txtInicio.Text) > Convert.ToDateTime(txtFim.Text))
            {
                MessageBox.Show("A data inicial não pode ser maior que a data final.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFim.Focus();
                return false;
            }
            TimeSpan tsPeriodo = DateTime.Parse(txtFim.Text) - DateTime.Parse(txtInicio.Text);
            if (tsPeriodo.Days > 30)
            {
                MessageBox.Show("Período não pode ser superior a 1 mês.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFim.Focus();
                return false;
            }
            return true;
        }

        private void FrmKardex_Load(object sender, EventArgs e)
        {
            cmbUnidade.Carregaunidade();
            
            cmbGrupo.DataSource = GrupoMatMed.Sel(new GrupoMatMedDTO());
            cmbGrupo.IniciaLista();

            txtInicio.Text = Utilitario.ObterDataHoraServidor().ToString("01/MM/yyyy");
            txtFim.Text = Utilitario.ObterDataHoraServidor().ToString("dd/MM/yyyy");

            lblProduto.Text = matMedInicio;
            tsRel.Items["tsBtnMatMed"].Enabled = true; 
        }

        private bool tsRel_PesquisarClick(object sender)
        {
            if (!ValidarPeriodo()) return false;

            if ((cmbGrupo.SelectedValue == null || cmbGrupo.SelectedIndex == -1) &&
                (cmbSetor.SelectedValue == null || cmbSetor.SelectedIndex == -1) && 
                (dtoMatMed == null || dtoMatMed.Idt.Value.IsNull))
            {
                MessageBox.Show("Selecione o Setor, o Grupo ou o Produto.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            ExecRelatorio();

            return true;
        }

        private bool tsRel_MatMedClick(object sender)
        {
            dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(new MaterialMedicamentoDTO());
            if (dtoMatMed == null)
            {
                lblProduto.Text = matMedInicio;
                btnLimparProduto.Visible = false;
                return false;
            }
            lblProduto.Text = dtoMatMed.NomeFantasia.Value;
            btnLimparProduto.Visible = true;
            return true;
        }

        private void btnLimparProduto_Click(object sender, EventArgs e)
        {
            dtoMatMed = null;
            lblProduto.Text = matMedInicio;
            btnLimparProduto.Visible = false;
        }
    }
}