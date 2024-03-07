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
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Cadastro
{
    public partial class FrmCadKit : FrmBase
    {
        public FrmCadKit()
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

        private KitDTO dtoKit;
        private IKit _kit;
        private IKit Kit
        {
            get { return _kit != null ? _kit : _kit = (IKit)Global.Common.GetObject(typeof(IKit)); }
        }

        #endregion

        private void CarregarComboKit()
        {
            cmbKit.DataSource = Kit.Listar(new KitDTO());
            cmbKit.IniciaLista();
        }

        private void CarregarKit()
        {
            this.Cursor = Cursors.WaitCursor;
            dtoKit = new KitDTO();
            dtoKit.IdKit.Value = cmbKit.SelectedValue.ToString();
            dtoKit = Kit.Listar(dtoKit).TypedRow(0);
            txtCod.Text = dtoKit.IdKit.Value;
            txtDescricao.Text = dtoKit.Descricao.Value;
            chbAtivo.Checked = dtoKit.Ativo.Value == 1 ? true : false;

            btnSalvar.Enabled = chbAtivo.Enabled = txtDescricao.Enabled = true;

            this.CarregarItens(dtoKit);

            this.Cursor = Cursors.Default;
        }

        private void CarregarItens(KitDTO dtoKit)
        {
            this.Cursor = Cursors.WaitCursor;
            KitDataTable dtbItem = Kit.ListarItem(dtoKit);
            dtgItem.DataSource = dtbItem;            
            this.Cursor = Cursors.Default;
        }

        private void SalvarKit()
        {
            if (dtoKit == null) dtoKit = new KitDTO();
            dtoKit.Ativo.Value = chbAtivo.Checked ? 1 : 0;
            dtoKit.Descricao.Value = txtDescricao.Text;
            dtoKit = Kit.Gravar(dtoKit, (int)FrmPrincipal.dtoSeguranca.Idt.Value);
            txtCod.Text = dtoKit.IdKit.Value;
        }

        private void AdicionarItem()
        {
            if (txtCod.Text != string.Empty && dtoKit != null)
            {
                this.Cursor = Cursors.WaitCursor;
                KitDTO dtoItemKit = new KitDTO();
                dtoItemKit.IdKit.Value = dtoKit.IdKit.Value;
                dtoItemKit.IdProduto.Value = dtoMatMed.Idt.Value;
                dtoItemKit.QtdeItem.Value = txtQtde.Text;

                Kit.GravarItem(dtoItemKit, (int)FrmPrincipal.dtoSeguranca.Idt.Value);

                dtoItemKit.IdProduto.Value = new Framework.DTO.TypeDecimal();
                this.CarregarItens(dtoItemKit);
                dtoMatMed = null;
                lblProduto.Text = txtQtde.Text = string.Empty;
                this.Cursor = Cursors.Default;
            }
            else
                MessageBox.Show("Kit não selecionado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void FrmCadKit_Load(object sender, EventArgs e)
        {
            dtgItem.AutoGenerateColumns = false;
            CarregarComboKit();
        }

        private bool tsHac_NovoClick(object sender)
        {
            dtoKit = null;
            dtoMatMed = null;
            return true;
        }

        private bool tsHac_AfterNovo(object sender)
        {
            lblProduto.Text = string.Empty;
            btnAddItem.Enabled = cmbKit.Enabled = false;
            btnSalvar.Enabled = true;
            cmbKit.IniciaLista();
            txtDescricao.Focus();
            btnNovo.Visible = false;
            return true;
        }

        private bool tsHac_CancelarClick(object sender)
        {
            dtoKit = null;
            dtoMatMed = null;
            return true;
        }

        private void tsHac_AfterCancelar(object sender)
        {
            lblProduto.Text = string.Empty;
            btnAddItem.Enabled = btnSalvar.Enabled = false;
            cmbKit.Enabled = true;
            cmbKit.IniciaLista();
            btnNovo.Visible = false;
        }

        private bool tsHac_MatMedClick(object sender)
        {
            if (txtCod.Text != string.Empty)
            {
                MaterialMedicamentoDTO dtoProdutoSel = null;
                if (dtoMatMed != null)
                {
                    dtoProdutoSel = new MaterialMedicamentoDTO();
                    dtoProdutoSel.Idt.Value = dtoMatMed.Idt.Value;
                    dtoProdutoSel.NomeFantasia.Value = dtoMatMed.NomeFantasia.Value;
                }
                dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(new MaterialMedicamentoDTO());
                if (dtoMatMed == null)
                {
                    if (dtoProdutoSel != null) dtoMatMed = dtoProdutoSel;
                    return false;
                }
                //else
                //{
                //    if ((int)dtoMatMed.IdtGrupo.Value == 1)
                //    {
                //        dtoMatMed = null;
                //        MessageBox.Show("Não é permitido adicionar medicamento!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return false;
                //    }
                //}
                lblProduto.Text = dtoMatMed.NomeFantasia.Value;
                txtQtde.Enabled = btnAddItem.Enabled = true;
                txtQtde.Text = string.Empty;
                txtQtde.Focus();
                return true;
            }
            return false;
        }

        private void tsAssMed_Click(object sender, EventArgs e)
        {
            if (dtoKit == null)
            {
                MessageBox.Show("Selecione o kit!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FrmAdicionarMedKit.AssociarMedicamentoAplicacao(dtoKit);
        }   

        private void cmbKit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbKit.SelectedIndex > -1)
            {
                CarregarKit();
                btnNovo_Click(sender, e);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == string.Empty)
            {
                MessageBox.Show("Descrição do Kit é obrigatória", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescricao.Focus();
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            this.SalvarKit();
            this.CarregarComboKit();
            this.Cursor = Cursors.Default;
            cmbKit.SelectedValue = txtCod.Text;
            cmbKit.Enabled = txtQtde.Enabled = btnAddItem.Enabled = true;
            btnNovo.Visible = false;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (dtoMatMed == null)
            {
                MessageBox.Show("Selecione o Item", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtQtde.Text == string.Empty || int.Parse(txtQtde.Text) <= 0)
            {
                MessageBox.Show("Digite a Qtde. do Item", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtQtde.Focus();
                return;
            }
            if (txtDescricao.Text.Trim() != cmbKit.Text && txtDescricao.Text != string.Empty)
            {
                this.SalvarKit();
                this.CarregarComboKit();
                cmbKit.SelectedValue = txtCod.Text;
            }
            this.AdicionarItem();
            btnNovo.Visible = false;
        }

        private void dtgItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtoKit != null && dtgItem.Columns[e.ColumnIndex].Name == "colDeletar")
            {
                if (MessageBox.Show("Deseja deletar este item do kit ?", "Gestão de Materiais e Medicamentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    KitDTO dtoItemKit = new KitDTO();
                    dtoItemKit.IdKit.Value = dtoKit.IdKit.Value;
                    dtoItemKit.IdProduto.Value = dtgItem.Rows[e.RowIndex].Cells[colIdProduto.Name].Value.ToString();

                    Kit.ExcluirItem(dtoItemKit);

                    dtoItemKit.IdProduto.Value = new Framework.DTO.TypeDecimal();
                    this.CarregarItens(dtoItemKit);
                    dtoMatMed = null;
                    lblProduto.Text = txtQtde.Text = string.Empty;
                }
            }
        }

        private void dtgItem_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgItem.Rows.Count > 0)
            {
                dtoMatMed = new MaterialMedicamentoDTO();
                dtoMatMed.Idt.Value = dtgItem.CurrentRow.Cells[colIdProduto.Name].Value.ToString();
                lblProduto.Text = dtgItem.CurrentRow.Cells[colDsProduto.Name].Value.ToString();
                txtQtde.Text = dtgItem.CurrentRow.Cells[colQtde.Name].Value.ToString();
                txtQtde.Enabled = btnAddItem.Enabled = true;
                btnNovo.Visible = true;
            }
        }

        private void dtgItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgItem_SelectionChanged(sender, e);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (dtoKit != null)
            {
                dtoMatMed = null;
                txtQtde.Enabled = btnAddItem.Enabled = true;
                lblProduto.Text = txtQtde.Text = string.Empty;
                btnNovo.Visible = false; 
            }
        }        
    }
}