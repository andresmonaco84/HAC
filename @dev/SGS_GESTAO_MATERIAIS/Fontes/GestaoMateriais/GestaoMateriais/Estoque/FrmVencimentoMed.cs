using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    public partial class FrmVencimentoMed : FrmBase
    {
        private const string matMedInicio = "<SELECIONE O PRODUTO CLICANDO NO BOTÃO 'Mat/Med'>";
        private MaterialMedicamentoDTO dtoMatMed;        

        private IHistoricoNotaFiscal _histNF;
        private IHistoricoNotaFiscal HistoricoNotaFiscal
        {
            get { return _histNF != null ? _histNF : _histNF = (IHistoricoNotaFiscal)Global.Common.GetObject(typeof(IHistoricoNotaFiscal)); }
        }        

        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        public FrmVencimentoMed()
        {
            InitializeComponent();
        }

        private bool ValidarPeriodo()
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
            return true;
        }

        private void FrmVencimentoMed_Load(object sender, EventArgs e)
        {
            dtgMed.AutoGenerateColumns = false;
            tsHac_AfterCancelar(sender);
        }

        private void btnLimparProduto_Click(object sender, EventArgs e)
        {
            dtoMatMed = null;
            lblProduto.Text = matMedInicio;
            btnLimparProduto.Visible = false;            
        }

        private bool tsHac_MatMedClick(object sender)
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

        private bool tsHac_CancelarClick(object sender)
        {
            return true;
        }

        private void tsHac_AfterCancelar(object sender)
        {
            tsHac.Items["tsBtnMatMed"].Enabled = tsHac.Items["tsBtnCancelar"].Enabled = true;
            btnLimparProduto_Click(null, null);
            txtInicio.Text = Utilitario.ObterDataHoraServidor().AddDays(-3).ToString("dd/MM/yyyy");
            txtFim.Text = Utilitario.ObterDataHoraServidor().AddDays(7).ToString("dd/MM/yyyy");
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            if (ValidarPeriodo())
            {
                HistoricoNotaFiscalDTO dtoHistNF = new HistoricoNotaFiscalDTO();

                if (!string.IsNullOrEmpty(txtCodLote.Text))
                    dtoHistNF.CodLote.Value = txtCodLote.Text;

                if (!string.IsNullOrEmpty(txtNumLote.Text))
                    dtoHistNF.NumLote.Value = txtNumLote.Text;

                if (dtoMatMed != null && !dtoMatMed.Idt.Value.IsNull)
                    dtoHistNF.IdtProduto.Value = dtoMatMed.Idt.Value;

                dtoHistNF.DataPrcMedio.Value = txtInicio.Text;
                dtoHistNF.DataValidadeProduto.Value = txtFim.Text;

                this.Cursor = Cursors.WaitCursor;
                try
                {
                    dtgMed.DataSource = HistoricoNotaFiscal.ListarLoteValidade(dtoHistNF);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                this.Cursor = Cursors.Default;

                return true;
            }
            return false;
        }
    }
}
