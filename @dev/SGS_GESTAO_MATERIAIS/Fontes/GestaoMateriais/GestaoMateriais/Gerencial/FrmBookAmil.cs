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
using HospitalAnaCosta.SGS.GestaoMateriais.Relatorio;
using Microsoft.ReportingServices.ReportRendering;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Gerencial
{
    public partial class FrmBookAmil : FrmBase
    {
        string _mesAnterior, _mesAtual, _mesPesquisa;

        // Utilitario
        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        private IUnidade _unidade;
        private IUnidade Unidade
        {
            get { return _unidade != null ? _unidade : _unidade = (IUnidade)GlobalComponentes.Componentes.GetObject(typeof(IUnidade)); }
        }

        public FrmBookAmil()
        {
            InitializeComponent();
        }

        private void CarregarComboUnidadeMaster()
        {
            cmbUnidadeMaster.DataSource = Unidade.ListarUnidadesMaster();            
        }

        private bool ValidarMesAno()
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
                _mesAtual = Utilitario.ObterDataHoraServidor().Month.ToString();
                _mesAtual = _mesAtual.Length == 1 ? "0" + _mesAtual : _mesAtual;
                _mesAtual = Utilitario.ObterDataHoraServidor().Year.ToString() + _mesAtual;
                _mesPesquisa = txtMes.Text;
                _mesPesquisa = _mesPesquisa.Length == 1 ? "0" + _mesPesquisa : _mesPesquisa;
                _mesPesquisa = txtAno.Text + _mesPesquisa;
                if (int.Parse(_mesPesquisa) >= int.Parse(_mesAtual))
                {
                    MessageBox.Show("O mês tem que ser menor do que o atual", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
            else
            {
                MessageBox.Show("Informe o Mês/Ano", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void FrmBookAmil_Load(object sender, EventArgs e)
        {
            txtMes.Text = Utilitario.ObterDataHoraServidor().AddMonths(-1).Month.ToString();
            txtAno.Text = Utilitario.ObterDataHoraServidor().AddMonths(-1).Year.ToString();
            tsHac.Items["tsBtnPesquisar"].Enabled = true;
            CarregarComboUnidadeMaster();
            tsHac_AfterLimpar(sender);
        }

        private bool tsHac_LimparClick(object sender)
        {
            return true;
        }

        private void tsHac_AfterLimpar(object sender)
        {
            cmbUnidadeMaster.SelectedValue = 244; //SANTOS
            rbBookFarm.Checked = true;
            txtMes.Focus();
        }

        private void rbComprasUrg_Click(object sender, EventArgs e)
        {
            cmbUnidadeMaster.Enabled = true;
            if (rbComprasUrg.Checked)
            {
                cmbUnidadeMaster.SelectedValue = 244; //SANTOS
                cmbUnidadeMaster.Enabled = false;
            }
        }      

        private bool tsHac_PesquisarClick(object sender)
        {
            if (ValidarMesAno())
            {
                DateTime dataRef = DateTime.Parse(string.Format("01/{0}/{1}", txtMes.Text, txtAno.Text));
                string nomeRelatorio = rbBookFarm.Checked ? "GM_37_BOOK_FARMACIA" : "GM_36_BOOK_COMPRAS_URG";
                Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[6];

                #region Monta Parâmetros

                byte x = 0;

                string dataDe = "01/" + txtMes.Text.PadLeft(2, '0') + "/" + txtAno.Text;
                string dataAte = DateTime.DaysInMonth(int.Parse(txtAno.Text), int.Parse(txtMes.Text)).ToString() + "/" + txtMes.Text.PadLeft(2, '0') + "/" + txtAno.Text;
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pDATA_DE", dataDe);
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pDATA_ATE", dataAte);
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pMES", txtMes.Text);
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pANO", txtAno.Text);
                if (rbBookFarm.Checked) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pUNIDADE_MASTER_AMIL", cmbUnidadeMaster.SelectedValue.ToString());
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
            }
            return default(bool);
        }          
    }
}