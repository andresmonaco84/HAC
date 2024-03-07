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
    public partial class FrmRelRegistroInventario : FrmBase
    {
        // Utilitario
        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        // FilialMatMed
        private IFilialMatMed _filialMatMed;
        private IFilialMatMed FilialMatMed
        {
            get { return _filialMatMed != null ? _filialMatMed : _filialMatMed = (IFilialMatMed)Global.Common.GetObject(typeof(IFilialMatMed)); }
        }

        public FrmRelRegistroInventario()
        {
            InitializeComponent();
        }

        private void FrmRelRegistroInventario_Load(object sender, EventArgs e)
        {
            txtDia.Text = DateTime.DaysInMonth(Utilitario.ObterDataHoraServidor().AddMonths(-1).Year, Utilitario.ObterDataHoraServidor().AddMonths(-1).Month).ToString();
            txtMes.Text = Utilitario.ObterDataHoraServidor().AddMonths(-1).Month.ToString();
            txtAno.Text = Utilitario.ObterDataHoraServidor().AddMonths(-1).Year.ToString();
            CarregarDadosFilial();
            tsHac.Items["tsBtnPesquisar"].Enabled = true;
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            if (txtDia.Text == string.Empty || txtMes.Text == string.Empty || txtAno.Text == string.Empty)
            {
                MessageBox.Show("Informe o Dia/Mês/Ano", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtCapa.Text.IndexOf("@LIVRO") > -1 || txtCapa.Text.IndexOf("@NUM_PAG_FIM") > -1 && txtCapa.Text != string.Empty)
            {
                txtLivro_Enter(null, null);
                txtLivro_Validating(null, null);
            }
            if (txtUltimaFolha.Text.IndexOf("@LIVRO") > -1 || txtUltimaFolha.Text.IndexOf("@NUM_PAG_FIM") > -1 && txtUltimaFolha.Text != string.Empty)
            {
                txtNumPagFinal_Enter(null, null);
                txtNumPagFinal_Validating(null, null);
            }

            string nomeRelatorio = "GM_11_REGISTRO_INVENTARIO";
            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[30];

            #region Monta Parâmetros

            int x = 0;

            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_FILIAL_ID", rbHac.Checked ? "1" : "2");
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_MOV_MES", txtMes.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_MOV_ANO", txtAno.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("DIA", txtDia.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("NOME_EMPRESA", txtNome.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("ENDERECO", txtEndereco.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("MUNICIPIO", txtMunicipio.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("ESTADO", txtEstado.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("INSC_ESTADUAL", txtInscEstadual.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("CNPJ", txtCNPJ.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("INSC_JUNTA_COM", txtInscJuntaCom.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("INSC_MUNICIPAL", txtInscMunicipal.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("LIVRO", txtLivro.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("MES_DESCRICAO", BasicFunctions.RetornaMes(int.Parse(txtMes.Text)));
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("NUM_PAG_FIM", txtNumPagFinal.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("DATA_ARQUIVAMENTO", txtDataArq.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("DATA_INICIO", txtDataDe.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("DATA_FIM", txtDataAte.Text);            
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PTEXTO_CAPA", txtCapa.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PTEXTO_ULTIMA_FOLHA", txtUltimaFolha.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCARGO_PESSOA_1", txtPessoaCargo1.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCARGO_PESSOA_DOC_1", txtCargoDoc1.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCARGO_PESSOA_2", txtPessoaCargo2.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCARGO_PESSOA_DOC_2", txtCargoDoc2.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCARGO_PESSOA_3", txtPessoaCargo3.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCARGO_PESSOA_DOC_3", txtCargoDoc3.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCARGO_PESSOA_4", txtPessoaCargo4.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCARGO_PESSOA_DOC_4", txtCargoDoc4.Text);
                        
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

            return default(bool);
        }

        private void rbHac_Click(object sender, EventArgs e)
        {
            CarregarDadosFilial();
        }

        private void rbAcs_Click(object sender, EventArgs e)
        {
            CarregarDadosFilial();
        }        

        private void txtLivro_Enter(object sender, EventArgs e)
        {
            if (txtLivro.Text != string.Empty)
            {
                txtCapa.Text = txtCapa.Text.Replace(" " + txtLivro.Text.Trim() + " ", " @LIVRO ");
                txtUltimaFolha.Text = txtUltimaFolha.Text.Replace(" " + txtLivro.Text.Trim() + " ", " @LIVRO ");
            }
        }

        private void txtNumPagFinal_Enter(object sender, EventArgs e)
        {
            if (txtNumPagFinal.Text != string.Empty)
            {                
                txtCapa.Text = txtCapa.Text.Replace(" " + txtNumPagFinal.Text.Trim() + " ", " @NUM_PAG_FIM ");
                txtUltimaFolha.Text = txtUltimaFolha.Text.Replace(" " + txtNumPagFinal.Text.Trim() + " ", " @NUM_PAG_FIM ");
            }
        }

        private void txtLivro_TextChanged(object sender, EventArgs e) {}

        private void txtNumPagFinal_TextChanged(object sender, EventArgs e) {}
        
        private void txtLivro_Validating(object sender, CancelEventArgs e)
        {
            if (txtLivro.Text != string.Empty)
            {
                if (txtLivro.Text == txtNumPagFinal.Text) txtLivro.Text = "0" + txtLivro.Text;
                txtCapa.Text = txtCapa.Text.Replace("@LIVRO", txtLivro.Text.Trim());
                txtUltimaFolha.Text = txtUltimaFolha.Text.Replace("@LIVRO", txtLivro.Text.Trim());
            }
        }

        private void txtNumPagFinal_Validating(object sender, CancelEventArgs e)
        {
            if (txtNumPagFinal.Text != string.Empty)
            {
                if (txtLivro.Text == txtNumPagFinal.Text)
                {
                    //Adiciona um 0 no Livro para não dar conflito nos Replaces
                    txtLivro.Text = "0" + txtLivro.Text;
                    txtCapa.Text = txtCapa.Text.Replace(" " + txtNumPagFinal.Text.Trim() + " ", " " + txtLivro.Text.Trim() + " ");
                    txtUltimaFolha.Text = txtUltimaFolha.Text.Replace(" " + txtNumPagFinal.Text.Trim() + " ", " " + txtLivro.Text.Trim() + " ");
                }
                txtCapa.Text = txtCapa.Text.Replace("@NUM_PAG_FIM", txtNumPagFinal.Text.Trim());
                txtUltimaFolha.Text = txtUltimaFolha.Text.Replace("@NUM_PAG_FIM", txtNumPagFinal.Text.Trim());
            }
        }         

        private void CarregarDadosFilial()
        {
            try
            {
                DataRow rowFilial = FilialMatMed.ObterDadosFilialRM(new Generico().RetornaFilial(rbHac, rbAcs)).Rows[0];

                txtNome.Text = rowFilial["NOME"].ToString();
                txtEndereco.Text = rowFilial["ENDERECO"].ToString();
                txtMunicipio.Text = rowFilial["CIDADE"].ToString();
                txtEstado.Text = rowFilial["ESTADO"].ToString();
                txtInscEstadual.Text = rowFilial["INSC_ESTADUAL"].ToString();
                txtCNPJ.Text = rowFilial["CNPJ"].ToString();
                txtInscJuntaCom.Text = rowFilial["INSC_JUNTA_COM"].ToString();
                txtInscMunicipal.Text = rowFilial["INSC_MUNICIPAL"].ToString();
                txtCapa.Text = "O presente Livro de Registro de Inventário de n° " + (txtLivro.Text == string.Empty ? "@LIVRO" : txtLivro.Text) + " possui " + 
                                (txtNumPagFinal.Text == string.Empty ? "@NUM_PAG_FIM" : txtNumPagFinal.Text) + " folhas numeradas do nº 01 ao n° " + 
                                (txtNumPagFinal.Text == string.Empty ? "@NUM_PAG_FIM" : txtNumPagFinal.Text) + " e servirá para a escrituração dos lançamentos próprios da sociedade empresária abaixo identificada:";
                txtUltimaFolha.Text = "O presente Livro de Registro de Inventário de n° " + (txtLivro.Text == string.Empty ? "@LIVRO" : txtLivro.Text) + " possui " + 
                                       (txtNumPagFinal.Text == string.Empty ? "@NUM_PAG_FIM" : txtNumPagFinal.Text) + " folhas numeradas do nº 01 ao n° " + 
                                       (txtNumPagFinal.Text == string.Empty ? "@NUM_PAG_FIM" : txtNumPagFinal.Text) + " e serviu para a escrituração da sociedade empresária " + txtNome.Text;

                if (rbHac.Checked)
                {
                    txtPessoaCargo1.Text = "Dr. José Luiz Boechat Paione";
                    txtCargoDoc1.Text = "Diretor Técnico";

                    txtPessoaCargo2.Text = "Marcio Antonio de Assis";
                    txtCargoDoc2.Text = "Diretor Administrativo";

                    txtPessoaCargo3.Text = "Rose Mary Peres Corrêa Bellem";
                    txtCargoDoc3.Text = "Diretora Comercial";

                    txtPessoaCargo4.Text = "Maria Aparecia Vieira de Melo";
                    txtCargoDoc4.Text = "Contadora - C.R.C.: 1SP183440/O-7";

                    txtPessoaCargo4.Enabled = txtCargoDoc4.Enabled = true;
                }
                else
                {
                    txtPessoaCargo1.Text = "Silmara dos Santos Tavares Luiz";
                    txtCargoDoc1.Text = "Diretora - CPF: 063.978.308-29";

                    txtPessoaCargo2.Text = "Eduardo de Oliveira";
                    txtCargoDoc2.Text = "Diretor - CPF: 758.294.878-53";

                    txtPessoaCargo3.Text = "Marcia Rita Nefertite Capovilla Miranda";
                    txtCargoDoc3.Text = "Contadora - C.R.C.: 1SP188938/O-9";
                                        
                    txtPessoaCargo4.Text = txtCargoDoc4.Text = string.Empty;
                    txtPessoaCargo4.Enabled = txtCargoDoc4.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }                 
    }
}