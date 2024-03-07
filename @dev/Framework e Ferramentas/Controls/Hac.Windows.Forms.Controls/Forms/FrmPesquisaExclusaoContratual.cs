using System;
using System.Data;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using HospitalAnaCosta.SGS.Cadastro.Interface;
using HospitalAnaCosta.Framework;
using Hac.Windows.Forms;

namespace Hac.Windows.Forms.Controls
{
    public partial class FrmPesquisaExclusaoContratual : FrmBase
    {

        ConvenioDTO dtoConvenio = new ConvenioDTO();
        PlanoDTO dtoPlano = new PlanoDTO();

        
        private string codigoConvenio;


        public FrmPesquisaExclusaoContratual()
        {
            InitializeComponent();

            ctlPlano.Inicializar();
            ctlConvenio.Inicializar();

            ctlConvenio.Focus();

            Titulo = "Pesquisa de Exclusão Contratual";
        }


        private void FrmPesquisaExclusaoContratual_Load(object sender, EventArgs e)
        {
            grdExclusao.AutoGenerateColumns = false;
            grdExclusao.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdExclusao.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdExclusao.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //Carrega o convênio SD01 para exibição
            ConvenioDTO dtoConvenioInicializa = new ConvenioDTO();
            dtoConvenioInicializa.IdtConvenio.Value = "281";
            dtoConvenioInicializa = Convenio.Pesquisar(dtoConvenioInicializa);                        
            ctlConvenio.CarregarConvenio(dtoConvenioInicializa);
            ctlConvenio.Enabled = false;
            
        }

        private void ctlConvenio_Pesquisar(object sender, EventArgs e)
        {
            if (ctlConvenio.DtoConvenio != null)
            {
                ctlPlano.IdtConvenio = Convert.ToInt32(ctlConvenio.DtoConvenio.IdtConvenio.Value);
                ctlPlano.Focus();
            }
        }

        private bool tspCommand_PesquisarClick(object sender)        
        {                        
            return Pesquisar();
        }

        private bool Pesquisar()
        {
            try
            {
                string credencial = string.Empty;

                try
                {
                    credencial = txtCodSeq.Text.PadLeft(3,'0') + txtCredencialHac.Text.PadLeft(7, '0') + txtCodSeqBen.Text.PadLeft(2,'0');
                }
                catch (Exception)
                {
                    throw  new Exception("A credencial não está no formato correto.");
                }
                

                DataTable dtbExclusao = ExclusaoContratual.Listar(ctlPlano.DtoPlano.CodigoPlanoHAC.Value, credencial);

                if (dtbExclusao.Rows.Count > 0)
                {
                    grdExclusao.DataSource = dtbExclusao;
                    return true;
                }
                else
                {
                    MessageBox.Show("Nenhuma exclusão contratual encontrada.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            catch (HacException ex)
            {
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
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

        private bool tspCommand_CancelarClick(object sender)
        {
            grdExclusao.DataSource = null;
            codigoConvenio = string.Empty;

            ctlPlano.Inicializar();
            ctlConvenio.Inicializar();
            ctlConvenio.Focus();

            return true;
        }

        private void tspCommand_BeforePesquisar(object sender)
        {
            ctlConvenio.Obrigatorio = true;
            ctlConvenio.ObrigatorioMensagem = "Campo Convênio Obrigatório.";

            ctlPlano.Obrigatorio = true;
            ctlPlano.ObrigatorioMensagem = "Campo Plano Obrigatório.";

            txtCodSeq.Obrigatorio = true;
            txtCodSeq.ObrigatorioMensagem = "Campo Credencial Obrigatório.";

            txtCodSeqBen.Obrigatorio = true;
            txtCodSeqBen.ObrigatorioMensagem = "Campo Credencial Obrigatório.";

            txtCredencialHac.Obrigatorio = true;
            txtCredencialHac.ObrigatorioMensagem = "Campo Credencial Obrigatório.";


        }

        public static void AbrirPesquisaExclusaoContratual(ConvenioDTO dtoConvenio, PlanoDTO dtoPlano, string credencial)
        {
            FrmPesquisaExclusaoContratual frmPesquisa = new FrmPesquisaExclusaoContratual();
            try
            {
                frmPesquisa.txtCodSeq.Text = credencial.Substring(0, 3);
                frmPesquisa.txtCredencialHac.Text = credencial.Substring(3, 7);
                frmPesquisa.txtCodSeqBen.Text = credencial.Substring(10, 2);   
            }
            catch
            {
                MessageBox.Show("A credencial não está no formato correto.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            frmPesquisa.ctlConvenio.CarregarConvenio(dtoConvenio);
            frmPesquisa.ctlPlano.CarregarPlano(dtoPlano);
            if (frmPesquisa.Pesquisar())
                frmPesquisa.ShowDialog();
        }

        private void ctlPlano_Pesquisar(object sender, EventArgs e)
        {
            if(ctlPlano.DtoPlano != null)
                txtCredencialHac.Focus();
        }

        private void txtCredencialHac_Leave(object sender, EventArgs e)
        {     
                if (txtCodSeqBen.Text == string.Empty)
                {
                    txtCodSeqBen.Text = "00";
                }     
        }

        private void ctlPlano_Leave(object sender, EventArgs e)
        {
            ConfiguraPlano();
        }

    }
}