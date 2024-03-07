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
    public partial class FrmInfMatMed : FrmBase
    {
        string _mesAnterior, _mesAtual, _mesPesquisa;

        // Utilitario
        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        // Movimentos        
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }

        public FrmInfMatMed()
        {
            InitializeComponent();
        }

        private void FrmInfMatMed_Load(object sender, EventArgs e)
        {
            txtMes.Text = Utilitario.ObterDataHoraServidor().AddMonths(-1).Month.ToString();
            txtAno.Text = Utilitario.ObterDataHoraServidor().AddMonths(-1).Year.ToString();            
            tsHac.Items["tsBtnPesquisar"].Enabled = true;
            if (!new Generico().VerificaAcessoFuncionalidade("GERAR_DADOS_INF_MAT_MED_REL")) grbSalvar.Visible = false;
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

        private bool tsHac_PesquisarClick(object sender)
        {
            if (ValidarMesAno())
            {
                DateTime dataRef = DateTime.Parse(string.Format("01/{0}/{1}", txtMes.Text, txtAno.Text));
                string nomeRelatorio = "GM_15_FECHA_INF_MAT_MED";
                Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[16];

                #region Monta Parâmetros

                byte x = 0;
                
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes12", Generico.ObterMesAno(byte.Parse(txtMes.Text), int.Parse(txtAno.Text)));
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes11", Generico.ObterMesAno((byte)dataRef.AddMonths(-1).Month, dataRef.AddMonths(-1).Year));
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes10", Generico.ObterMesAno((byte)dataRef.AddMonths(-2).Month, dataRef.AddMonths(-2).Year));
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes9", Generico.ObterMesAno((byte)dataRef.AddMonths(-3).Month, dataRef.AddMonths(-3).Year));
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes8", Generico.ObterMesAno((byte)dataRef.AddMonths(-4).Month, dataRef.AddMonths(-4).Year));
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes7", Generico.ObterMesAno((byte)dataRef.AddMonths(-5).Month, dataRef.AddMonths(-5).Year));
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes6", Generico.ObterMesAno((byte)dataRef.AddMonths(-6).Month, dataRef.AddMonths(-6).Year));
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes5", Generico.ObterMesAno((byte)dataRef.AddMonths(-7).Month, dataRef.AddMonths(-7).Year));
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes4", Generico.ObterMesAno((byte)dataRef.AddMonths(-8).Month, dataRef.AddMonths(-8).Year));
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes3", Generico.ObterMesAno((byte)dataRef.AddMonths(-9).Month, dataRef.AddMonths(-9).Year));
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes2", Generico.ObterMesAno((byte)dataRef.AddMonths(-10).Month, dataRef.AddMonths(-10).Year));
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("mes1", Generico.ObterMesAno((byte)dataRef.AddMonths(-11).Month, dataRef.AddMonths(-11).Year));

                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PREL_RFM_MES_FECHAMENTO", txtMes.Text);
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PREL_RFM_ANO_FECHAMENTO", txtAno.Text);
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

        private void btnGerarDados_Click(object sender, EventArgs e)
        {
            if (!chbEstoque.Checked && !chbReceita.Checked)
            {
                MessageBox.Show("Selecione pelo menos um dos processos !", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ValidarMesAno())
            {
                _mesAnterior = Utilitario.ObterDataHoraServidor().AddMonths(-1).Month.ToString();
                _mesAnterior = _mesAnterior.Length == 1 ? "0" + _mesAnterior : _mesAnterior;
                _mesAnterior = Utilitario.ObterDataHoraServidor().AddMonths(-1).Year.ToString() + _mesAnterior;
                if (int.Parse(_mesPesquisa) != int.Parse(_mesAnterior))
                {
                    MessageBox.Show("Só pode ser gerado dados do mês anterior !", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Deseja realmente gerar os dados de " + txtMes.Text + "/" + txtAno.Text + " ?",
                                    "Gestão de Materiais e Medicamentos",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    this.Cursor = Cursors.WaitCursor;
                    Movimento.GerarDadosRelatorioInfMatMed(byte.Parse(txtMes.Text),
                                                           int.Parse(txtAno.Text),
                                                           chbEstoque.Checked,
                                                           chbReceita.Checked,
                                                           int.Parse(FrmPrincipal.dtoSeguranca.Idt.ToString()));
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Processo realizado com sucesso!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }        
    }
}