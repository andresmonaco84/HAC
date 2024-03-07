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
    public partial class FrmRelLivroMov : FrmBase
    {
        public MaterialMedicamentoDTO _dtoMatMed;
        public int _idUnidade;
        public byte _idFilial;

        // FilialMatMed
        private IFilialMatMed _filialMatMed;
        private IFilialMatMed FilialMatMed
        {
            get { return _filialMatMed != null ? _filialMatMed : _filialMatMed = (IFilialMatMed)Global.Common.GetObject(typeof(IFilialMatMed)); }
        }

        private ILivroRegistroMovimentos _livroRegistroMov;
        private ILivroRegistroMovimentos LivroRegistroMov
        {
            get { return _livroRegistroMov != null ? _livroRegistroMov : _livroRegistroMov = (ILivroRegistroMovimentos)Global.Common.GetObject(typeof(ILivroRegistroMovimentos)); }
        }

        // Utilitario
        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        public FrmRelLivroMov()
        {
            InitializeComponent();
        }

        public static void Carregar(int idUnidade, byte idFilial, MaterialMedicamentoDTO dtoMatMed)
        {
            FrmRelLivroMov frm = new FrmRelLivroMov();

            frm._idUnidade = idUnidade;
            frm._idFilial = idFilial;
            frm._dtoMatMed = dtoMatMed;
            frm.MdiParent = FrmPrincipal.ActiveForm;
            frm.Show();
        }

        private bool Validar()
        {
            if (cmbUnidade.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione a Unidade.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbUnidade.Focus();
                return false;
            }
            if (_dtoMatMed == null || _dtoMatMed.Idt.Value.IsNull)
            {
                MessageBox.Show("Selecione o Produto.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtDataRef.Text == string.Empty || !BasicFunctions.ValidarData(txtDataRef.Text))
            {
                MessageBox.Show("Digite uma Data Ref. válida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDataRef.Focus();
                return false;
            }
            if (ValidarMesAno())
                return true;

            return false;
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
                string mesAtual, mesPesquisa;
                mesAtual = Utilitario.ObterDataHoraServidor().Month.ToString();
                mesAtual = mesAtual.Length == 1 ? "0" + mesAtual : mesAtual;
                mesAtual = Utilitario.ObterDataHoraServidor().Year.ToString() + mesAtual;
                mesPesquisa = txtMes.Text;
                mesPesquisa = mesPesquisa.Length == 1 ? "0" + mesPesquisa : mesPesquisa;
                mesPesquisa = txtAno.Text + mesPesquisa;
                if (int.Parse(mesPesquisa) >= int.Parse(mesAtual))
                {
                    MessageBox.Show("O mês tem que ser menor do que o atual", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }                
                return true;
            }
            else
            {
                MessageBox.Show("Informe o Mês/Ano", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (string.IsNullOrEmpty(txtMes.Text))
                    txtMes.Focus();
                else
                    txtAno.Focus();
                return false;
            }
        }

        private void CarregarDadosFilial()
        {
            try
            {
                DataRow rowFilial = FilialMatMed.ObterDadosFilialRM(new Generico().RetornaFilial(rbHac, rbAcs)).Rows[0];

                txtNomeEmpresa.Text = rowFilial["NOME"].ToString();
                txtEndereco.Text = rowFilial["ENDERECO"].ToString();
                txtMunicipio.Text = rowFilial["CIDADE"].ToString();
                txtEstado.Text = rowFilial["ESTADO"].ToString();                
                txtCNPJ.Text = rowFilial["CNPJ"].ToString();

                txtFarmaceutico.Text = txtDiretorTec.Text = string.Empty;

                if (cmbUnidade.SelectedIndex > -1)
                {
                    string responsavel = null;
                    if (rbHac.Checked)
                    {
                        DataTable dtResponsavel = LivroRegistroMov.ObterResponsavel("FARMACIA", int.Parse(cmbUnidade.SelectedValue.ToString()));

                        if (dtResponsavel.Rows.Count > 0)
                            responsavel = dtResponsavel.Rows[0]["NM_PESSOA"].ToString().Trim() + " - " + dtResponsavel.Rows[0]["CD_CONSELHOPROF"].ToString().Trim()
                                           + " - " + dtResponsavel.Rows[0]["NR_CONSELHO"].ToString().Trim();

                        txtFarmaceutico.Text = responsavel;                        
                        
                        dtResponsavel = LivroRegistroMov.ObterResponsavel("DIR_TECNICO", int.Parse(cmbUnidade.SelectedValue.ToString()));

                        responsavel = null;
                        if (dtResponsavel.Rows.Count > 0)
                            responsavel = dtResponsavel.Rows[0]["NM_PESSOA"].ToString();

                        txtDiretorTec.Text = responsavel;
                    }
                    else
                    {
                        DataTable dtResponsavel = LivroRegistroMov.ObterResponsavel("FARMACIA_ACS", int.Parse(cmbUnidade.SelectedValue.ToString()));

                        if (dtResponsavel.Rows.Count > 0)
                            responsavel = dtResponsavel.Rows[0]["NM_PESSOA"].ToString().Trim() + " - " + dtResponsavel.Rows[0]["CD_CONSELHOPROF"].ToString().Trim()
                                           + " - " + dtResponsavel.Rows[0]["NR_CONSELHO"].ToString().Trim();

                        txtFarmaceutico.Text = responsavel;

                        dtResponsavel = LivroRegistroMov.ObterResponsavel("DIR_TECNICO_ACS", int.Parse(cmbUnidade.SelectedValue.ToString()));

                        responsavel = null;
                        if (dtResponsavel.Rows.Count > 0)
                            responsavel = dtResponsavel.Rows[0]["NM_PESSOA"].ToString();

                        txtDiretorTec.Text = responsavel;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecRelatorio()
        {
            string nomeRelatorio = "GM_27_LIVRO_REG_MOVIMENTOS";

            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[15];

            #region Monta Parâmetros

            int x = 0;

            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDATA_REF", txtDataRef.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_ID", _dtoMatMed.Idt.Value);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMED_GRUPO", _dtoMatMed.CodGrupoAnvisa.Value);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_UNI_ID_UNIDADE", cmbUnidade.SelectedValue.ToString());
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_FILIAL_ID", rbAcs.Checked ? "2" : "1");
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_MOV_MES", txtMes.Text.PadLeft(2, '0'));
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_MOV_ANO", txtAno.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PNOME_EMPRESA", txtNomeEmpresa.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PENDERECO", txtEndereco.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMUNICIPIO", txtMunicipio.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PESTADO", txtEstado.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCNPJ", txtCNPJ.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PFARMACEUTICO", txtFarmaceutico.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDIRETOR_TECNICO", txtDiretorTec.Text);

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
            //frmRelatorio.MdiParent = FrmLivroRegistro.ActiveForm;
            frmRelatorio.AbreRelatorio(nomeRelatorio, reportParam);
            //tsHac.Focus();            
        }

        private void FrmRelLivroMov_Load(object sender, EventArgs e)
        {
            cmbUnidade.Carregaunidade();
            if (_idUnidade > 0) cmbUnidade.SelectedValue = _idUnidade.ToString();
            if (_idFilial == 2) rbAcs.Checked = true; else rbHac.Checked = true;
            if (_dtoMatMed != null && !_dtoMatMed.Idt.Value.IsNull)
                lblProduto.Text = _dtoMatMed.NomeFantasia.Value;
            CarregarDadosFilial();
            tsHac.Items["tsBtnMatMed"].Enabled = true;
        }

        private void rbHac_CheckedChanged(object sender, EventArgs e)
        {
            CarregarDadosFilial();
        }

        private void rbAcs_CheckedChanged(object sender, EventArgs e)
        {
            CarregarDadosFilial();
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            if (this.Validar())
            {
                ExecRelatorio();
                return true;
            }
            return false;
        }

        private bool tsHac_MatMedClick(object sender)
        {
            MaterialMedicamentoDTO dtoMatMedPesquisa = new MaterialMedicamentoDTO();
            dtoMatMedPesquisa.IdtGrupo.Value = 1; //Drogas e Medicamentos
            dtoMatMedPesquisa.IdtSubGrupo.Value = 912; //Psicotropicos
            dtoMatMedPesquisa = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMedPesquisa);

            if (dtoMatMedPesquisa != null)
            {
                _dtoMatMed = dtoMatMedPesquisa;
                lblProduto.Text = _dtoMatMed.NomeFantasia.Value;
            }
            return true;
        }        
    }
}