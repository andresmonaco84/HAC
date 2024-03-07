using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmLiberaAtendimento : FrmBase
    {
        private const string labelLiberar = "Clique aqui p/ liberar atendimento p/ ajuste imediato";
        private const string labelAtualizar = "Clique aqui p/ atualizar atendimento em ajuste";

        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }

        public FrmLiberaAtendimento()
        {
            InitializeComponent();
            dtgAtendimento.AutoGenerateColumns = false;
        }

        private void FrmLiberaAtendimento_Load(object sender, EventArgs e)
        {
            btnLiberar.Text = labelLiberar;
            btnLiberar.Visible = true;
            btnLiberar.Enabled = false;
            
            dtgAtendimento.DataSource = Movimento.AtendimentosLiberados();
            dtgAtendimento.ClearSelection();
        }

        private bool tsHac_NovoClick(object sender)
        {
            return true;
        }

        private bool tsHac_AfterNovo(object sender)
        {
            cbAberto.Checked = btnLiberar.Enabled = true;
            cbAberto.Enabled = false;
            btnLiberar.Text = labelLiberar;
            txtAtd.Focus();
            return true;
        }

        private bool tsHac_CancelarClick(object sender)
        {
            btnLiberar.Text = "--";
            cbAberto.Enabled = btnLiberar.Enabled = false;
            return true;
        }   
                
        private void btnLiberar_Click(object sender, EventArgs e)
        {
            if (txtAtd.Text.Length < 7)
            {
                MessageBox.Show("Digite um atendimento com mais de 6 caracteres", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAtd.Focus();
                return;
            }

            this.Cursor = Cursors.WaitCursor;            

            if (btnLiberar.Text == labelLiberar)
            {
                foreach (DataGridViewRow row in dtgAtendimento.Rows)
                {
                    if (row.Cells[colAtd.Name].Value.ToString() == txtAtd.Text.Trim())
                    {
                        MessageBox.Show("Atendimento já registrado para ajuste", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAtd.Focus();
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }
                Movimento.LiberarAtendimento(decimal.Parse(txtAtd.Text), 1, (decimal)FrmPrincipal.dtoSeguranca.Idt.Value);
            }
            else if (btnLiberar.Text == labelAtualizar)
                Movimento.AtualizarAtendimentoLiberado(decimal.Parse(txtAtd.Text), cbAberto.Checked ? 1 : 0);
            else
            {
                this.Cursor = Cursors.Default;
                return;
            }

            txtAtd.Enabled = btnLiberar.Enabled = cbAberto.Enabled = false;
            //MessageBox.Show("Atendimento liberado com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dtgAtendimento.DataSource = Movimento.AtendimentosLiberados();
            dtgAtendimento.ClearSelection();

            tsHac.Items["tsBtnNovo"].Enabled = true;

            this.Cursor = Cursors.Default;
        }

        private void txtAtd_KeyUp(object sender, KeyEventArgs e)
        {
            //tsHac.Items["tsBtnNovo"].Enabled = true;
        }

        private void dtgAtendimento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                btnLiberar.Text = labelAtualizar;
                btnLiberar.Enabled = cbAberto.Enabled = true;
                txtAtd.Enabled = false;

                txtAtd.Text = dtgAtendimento.Rows[e.RowIndex].Cells[colAtd.Name].Value.ToString();                
                cbAberto.Checked = (decimal)dtgAtendimento.Rows[e.RowIndex].Cells[colFlAberto.Name].Value == 1 ? true : false;
            }            
        }             
    }
}