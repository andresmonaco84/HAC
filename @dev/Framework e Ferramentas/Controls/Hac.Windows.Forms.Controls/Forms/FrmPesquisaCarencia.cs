using System;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using Hac.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Hac.Windows.Forms.Controls.Forms;

namespace Hac.Windows.Forms.Controls
{
    public partial class FrmPesquisaCarencia : FrmBase
    {
        public FrmPesquisaCarencia()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            InicializarControles();

            Titulo = "Pesquisa de Carências - Plano de Saúde Ana Costa";
        }

        private void InicializarControles()
        {
            grdCarencia.AutoGenerateColumns = grdCPT.AutoGenerateColumns = false;
            ctlPlano.Inicializar();
            ctlConvenio.Inicializar();
            ctlConvenio.Focus();
            grdCarencia.DataSource = 0;
            grdCPT.DataSource = 0;

            //Define o convenio SD01 como padrao
            ConvenioDTO dtoConvenioInicializar = new ConvenioDTO();
            dtoConvenioInicializar.IdtConvenio.Value = "281";
            ctlConvenio.CarregarConvenio(dtoConvenioInicializar);
            ctlConvenio.Enabled = false;
        }

        private void ConfiguraPlano()
        {
            if (ctlPlano.DtoPlano != null)
            {
                bool isACS = Paciente.IsFuncionarioACS(ctlConvenio.DtoConvenio.IdtConvenio.Value.ToString());

                if (isACS)
                {
                    txtCodSeq.Text = "000";
                    txtCredencialHac.Focus();
                }

            }
        }

        private void ctlConvenio_Pesquisar(object sender, EventArgs e)
        {
            if (ctlConvenio.DtoConvenio != null)
                ctlPlano.IdtConvenio = Convert.ToInt32(ctlConvenio.DtoConvenio.IdtConvenio.Value);
        }

        private bool tspCommand_PesquisarClick(object sender)
        {
            return Pesquisar(true);
        }

        private bool Pesquisar(bool aviso)
        {
            int codEst;
            int codBen;
            int codSeqBen;
            string message = string.Empty;

            codEst = Convert.ToInt32(txtCodSeq.Text);
            codBen = Convert.ToInt32(txtCredencialHac.Text);
            codSeqBen = Convert.ToInt32(txtCodSeqBen.Text);

            grdCarencia.DataSource = Beneficiario.ListarCarenciaBeneficiario(ctlPlano.DtoPlano.CodigoPlanoHAC.Value, codEst, codBen, codSeqBen);
            grdCPT.DataSource = Beneficiario.ListarCarenciaPorCid(ctlPlano.DtoPlano.CodigoPlanoHAC.Value, codEst, codBen, codSeqBen);

            if (grdCarencia.Rows.Count <= 0 && grdCPT.Rows.Count <= 0)
            {
                message = "Nenhuma carência encontrada.";
            }

            if (message != string.Empty && aviso)
            {
                MessageBox.Show(message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
                return true;

        }

        private void tspCommand_BeforePesquisar(object sender)
        {
            ctlConvenio.Obrigatorio = true;
            ctlConvenio.ObrigatorioMensagem = "Campo Convênio Obrigatório.";

            ctlPlano.Obrigatorio = true;
            ctlPlano.ObrigatorioMensagem = "Campo Plano Obrigatório.";

            txtCodSeq.Obrigatorio = true;
            txtCredencialHac.ObrigatorioMensagem = "Campo Credencial Obrigatório.";

            txtCredencialHac.Obrigatorio = true;
            txtCredencialHac.ObrigatorioMensagem = "Campo Credencial Obrigatório.";

            txtCodSeqBen.Obrigatorio = true;
            txtCredencialHac.ObrigatorioMensagem = "Campo Credencial Obrigatório.";

            if (txtCredencialHac.Text != string.Empty)
            {
                if (txtCodSeqBen.Text == string.Empty)
                {
                    txtCodSeqBen.Text = "00";
                }
            }
        }

        public static void AbrirPesquisaCarencia(ConvenioDTO dtoConvenio, PlanoDTO dtoPlano, string credencial)
        {
            FrmPesquisaCarencia frmPesquisa = new FrmPesquisaCarencia();
            frmPesquisa.txtCodSeq.Text = credencial.Substring(0, 3);
            frmPesquisa.txtCredencialHac.Text = credencial.Substring(3, 7);
            frmPesquisa.txtCodSeqBen.Text = credencial.Substring(10, 2);

            frmPesquisa.ctlConvenio.CarregarConvenio(dtoConvenio);
            frmPesquisa.ctlPlano.CarregarPlano(dtoPlano);
            if (frmPesquisa.Pesquisar(true))
                FrmBase.AbrirFormulario(frmPesquisa);
        }

        private bool tspCommand_LimparClick(object sender)
        {
            return true;
        }

        private void tspCommand_AfterLimpar(object sender)
        {
            InicializarControles();
        }

        private void txtCredencialHac_Leave(object sender, EventArgs e)
        {
            if (txtCredencialHac.Text != string.Empty)
            {
                if (txtCodSeqBen.Text == string.Empty)
                {
                    txtCodSeqBen.Text = "00";
                }
            }
        }

        private void ctlPlano_Leave(object sender, EventArgs e)
        {
            ConfiguraPlano();
        }

        private bool tspCommand_ImprimirClick(object sender)
        {
            if (grdCarencia.Rows.Count <= 0 && grdCPT.Rows.Count <= 0)
            {
                MessageBox.Show("Pesquise antes de Imprimir.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }


            ReportParameter[] reportParam = new ReportParameter[10];

            int x = 0;

            reportParam[x++] = new ReportParameter("PNM_USUARIO", string.Format("{0} - {1}",
            FrmBase.DtoPassport.Usuario.Matricula.Value.ToString(), FrmBase.DtoPassport.Usuario.Nome.Value.ToString()));

            reportParam[x++] = new ReportParameter("PCODCON", ctlPlano.DtoPlano.CodigoPlanoHAC.Value.ToString());
            reportParam[x++] = new ReportParameter("PCODEST", txtCodSeq.Text);
            reportParam[x++] = new ReportParameter("PCODBEN", txtCredencialHac.Text);
            reportParam[x++] = new ReportParameter("PCODSEQBEN", txtCodSeqBen.Text);
            
            ReportParameter[] reportParamTemp = new ReportParameter[x];

            for (int i = 0; i < reportParam.Length; i++)
            {
                if (reportParam[i] == null)
                    break;
                reportParamTemp[i] = reportParam[i];
            }
            reportParam = reportParamTemp;
            reportParamTemp = null;

            FrmReportViewer frmRelatorio = new FrmReportViewer();
            frmRelatorio.AbreRelatorio("CAD_06_BENEF_CARENCIA", reportParam, Titulo);
            return default(bool);


        }

        private void tspCommand_BeforeImprimir(object sender)
        {
            ctlConvenio.Obrigatorio = true;
            ctlConvenio.ObrigatorioMensagem = "Campo Convênio Obrigatório.";

            ctlPlano.Obrigatorio = true;
            ctlPlano.ObrigatorioMensagem = "Campo Plano Obrigatório.";

            txtCodSeq.Obrigatorio = true;
            txtCredencialHac.ObrigatorioMensagem = "Campo Credencial Obrigatório.";

            txtCredencialHac.Obrigatorio = true;
            txtCredencialHac.ObrigatorioMensagem = "Campo Credencial Obrigatório.";

            txtCodSeqBen.Obrigatorio = true;
            txtCredencialHac.ObrigatorioMensagem = "Campo Credencial Obrigatório.";

            if (txtCredencialHac.Text != string.Empty)
            {
                if (txtCodSeqBen.Text == string.Empty)
                {
                    txtCodSeqBen.Text = "00";
                }
            }
        }
    }
}