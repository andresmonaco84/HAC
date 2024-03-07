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

namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    public partial class FrmIndiceRotatividade : FrmBase
    {
        private const string matMedInicio = "<SELECIONE O PRODUTO CLICANDO NO BOTÃO 'Mat/Med'>";
        
        public FrmIndiceRotatividade()
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

        // GrupoMatMed        
        private IGrupoMatMed _grupoMatMed;
        private IGrupoMatMed GrupoMatMed
        {
            get { return _grupoMatMed != null ? _grupoMatMed : _grupoMatMed = (IGrupoMatMed)Global.Common.GetObject(typeof(IGrupoMatMed)); }
        }

        // SubGrupoMatMed
        private SubGrupoMatMedDTO dtoSubGrupo;
        private ISubGrupoMatMed _subGrupoMatMed;
        private ISubGrupoMatMed SubGrupoMatMed
        {
            get { return _subGrupoMatMed != null ? _subGrupoMatMed : _subGrupoMatMed = (ISubGrupoMatMed)Global.Common.GetObject(typeof(ISubGrupoMatMed)); }
        }

        // Utilitario
        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        #endregion

        #region MÉTODOS

        private void CarregarComboGrupo()
        {
            cmbGrupo.DataSource = GrupoMatMed.Sel(new GrupoMatMedDTO());
            cmbGrupo.IniciaLista();
        }

        private void CarregarComboSubGrupo()
        {
            dtoSubGrupo = new SubGrupoMatMedDTO();
            dtoSubGrupo.IdtGrupo.Value = cmbGrupo.SelectedValue.ToString();
            cmbSubGrupo.DataSource = SubGrupoMatMed.Sel(dtoSubGrupo);
            cmbSubGrupo.IniciaLista();
        }

        private void ExecRelatorio()
        {
            //if (txtInicio.Text == string.Empty)
            //{
            //    MessageBox.Show("Digite a Data de Início do período para consulta", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            bool produtoSelecionado = false;
            if (dtoMatMed != null)
            {
                if (!dtoMatMed.Idt.Value.IsNull) produtoSelecionado = true;                
            }
            //if (cmbGrupo.SelectedIndex == -1 && !produtoSelecionado)
            //{
            //    MessageBox.Show("Selecione o Grupo ou o Produto", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            string nomeRelatorio = "GM_01_MTMD_INDICE_ROT";

            if (chbAnaFinanc.Checked) nomeRelatorio = "GM_12_MTMD_ANALISE_CONT";
            else if (chbRelResumido.Checked) nomeRelatorio = "GM_22_MTMD_INDICE_ROT_SIMPLES";
            
            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[20];
            string dataIni = string.Format("01/{0}/{1}", txtMes.Text.PadLeft(2, '0'), txtAno.Text);
            string dataFim;
            if (DateTime.Parse(dataIni).Month == Utilitario.ObterDataHoraServidor().Month &&
                DateTime.Parse(dataIni).Year == Utilitario.ObterDataHoraServidor().Year)
            {
                dataFim = string.Format("{0}/{1}/{2}", Utilitario.ObterDataHoraServidor().Day.ToString().PadLeft(2, '0'), txtMes.Text.PadLeft(2, '0'), txtAno.Text);
            }
            else
            {
                dataFim = string.Format("{0}/{1}/{2}", DateTime.DaysInMonth(int.Parse(txtAno.Text), int.Parse(txtMes.Text)), txtMes.Text.PadLeft(2, '0'), txtAno.Text);
            }

            #region Monta Parâmetros

            int x = 0;

            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_FILIAL_ID", rbHac.Checked ? "1" : "2");
            if (cmbGrupo.SelectedIndex > -1)
            {
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_GRUPO_ID", cmbGrupo.SelectedValue.ToString());
                if (cmbSubGrupo.SelectedIndex > -1) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_SUBGRUPO_ID", cmbSubGrupo.SelectedValue.ToString());
            }
            if (produtoSelecionado) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_ID", dtoMatMed.Idt.Value);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDATA_DE", dataIni);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDATA_ATE", dataFim);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("USUARIO", FrmPrincipal.dtoSeguranca.Login.Value);            
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("FILIAL", rbHac.Checked ? "HAC" : "ACS");
            cmbGrupo.Focus();
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("GRUPO", cmbGrupo.SelectedIndex > -1 ? cmbGrupo.SelectedText : "--");
            cmbSubGrupo.Focus();
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("SUBGRUPO", cmbSubGrupo.SelectedIndex > -1 ? cmbSubGrupo.SelectedText : "--");
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("DT_INI", dataIni);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("DT_FIM", dataFim);
                        
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

        private void FrmIndiceRotatividade_Load(object sender, EventArgs e)
        {                       
            CarregarComboGrupo();
            lblProduto.Text = matMedInicio;
            txtMes.Text = Utilitario.ObterDataHoraServidor().AddMonths(-1).Month.ToString();
            txtAno.Text = Utilitario.ObterDataHoraServidor().AddMonths(-1).Year.ToString();
            //txtInicio.Text = DateTime.Parse(string.Format("1/{0}/{1}", Utilitario.ObterDataHoraServidor().Month, Utilitario.ObterDataHoraServidor().Year)).ToString("dd/MM/yyyy");
            //txtFim.Text = DateTime.Parse(string.Format("{0}/{1}/{2}", DateTime.DaysInMonth(Utilitario.ObterDataHoraServidor().Year, Utilitario.ObterDataHoraServidor().Month),
            //              Utilitario.ObterDataHoraServidor().Month, Utilitario.ObterDataHoraServidor().Year)).ToString("dd/MM/yyyy");            
            tsHac.Items["tsBtnPesquisar"].Enabled = true;
            tsHac.Items["tsBtnMatMed"].Enabled = true;
        }

        private bool tsHac_MatMedClick(object sender)
        {
            dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(new MaterialMedicamentoDTO());
            if (dtoMatMed == null) return false;
            lblProduto.Text = dtoMatMed.NomeFantasia.Value;
            btnLimparProduto.Visible = true;
            return true;
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            if (txtMes.Text != string.Empty && txtAno.Text != string.Empty)
            {
                if (int.Parse(txtMes.Text) <= 0 || int.Parse(txtMes.Text) > 12)
                {
                    MessageBox.Show("Mês inválido", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (int.Parse(txtAno.Text) < 1900 || int.Parse(txtAno.Text) > 2099)
                {
                    MessageBox.Show("Ano inválido", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (chbAnaFinanc.Checked)
                {
                    //Por ser estimativa, deixar consultar apenas o mês atual para não haver confusão na análise de relatórios cruzando com os do fechamento
                    string mesAtual, mesPesquisa;
                    mesAtual = Utilitario.ObterDataHoraServidor().Month.ToString();
                    mesAtual = mesAtual.Length == 1 ? "0" + mesAtual : mesAtual;
                    mesAtual = Utilitario.ObterDataHoraServidor().Year.ToString() + mesAtual;
                    mesPesquisa = txtMes.Text;
                    mesPesquisa = mesPesquisa.Length == 1 ? "0" + mesPesquisa : mesPesquisa;
                    mesPesquisa = txtAno.Text + mesPesquisa;
                    if (int.Parse(mesPesquisa) != int.Parse(mesAtual))
                    {
                        MessageBox.Show("O mês tem que ser o atual para analisar a estimativa financeira da rotatividade", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                ExecRelatorio();

                return true;
            }
            else
            {
                MessageBox.Show("Informe o Mês/Ano", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }            
        }

        private void cmbGrupo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CarregarComboSubGrupo();
        }

        private void btnLimparProduto_Click(object sender, EventArgs e)
        {
            dtoMatMed = null;
            lblProduto.Text = matMedInicio;
            btnLimparProduto.Visible = false;
        }

        private void chbAnaFinanc_Click(object sender, EventArgs e)
        {
            chbRelResumido.Enabled = lblObs.Visible = true;
            if (chbAnaFinanc.Checked)
            {
                chbRelResumido.Checked = chbRelResumido.Enabled = false;
                lblObs.Visible = false;
            } 
        }

        #endregion        
    }
}