using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using System.Web.UI.WebControls;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    public partial class FrmUnidadesEstoque : HospitalAnaCosta.SGS.GestaoMateriais.FrmGestaoMateriais
    {
        // private int idtUnidade;
        /*
        private IUnidadeEstoque _matMed;
        protected IUnidadeEstoque matMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IUnidadeEstoque)Common.GetObject(HospitalAnaCosta.SGS.View.Common.Sistema.GestaoMateriais, typeof(IUnidadeEstoque)); }
        }
        */

        public FrmUnidadesEstoque()
        {
            InitializeComponent();
        }

        private void FrmUnidadesEstoque_Shown(object sender, EventArgs e)
        {


        }

        #region Funcoes
        protected void MudaBotoes(string modo)
        {

            switch (modo)
            {
                case "EDIT":
                case "INS":
                    btnSalvar.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnNovo.Enabled = false;
                    break;
                case "INI":
                case "SALVA":
                case "CANCELA":
                    btnSalvar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnNovo.Enabled = true;
                    break;
                default:
                    break;
            }

        }


        private void ConfiguraGrid()
        {
            dtgUnidaEstoque.Columns["colDsUnidade"].DataPropertyName = UnidadeEstoqueDTO.FieldNames.UniEstDescricao;
            dtgUnidaEstoque.Columns["colUnidade"].DataPropertyName = UnidadeEstoqueDTO.FieldNames.UniDescricao;
            dtgUnidaEstoque.Columns["colLocal"].DataPropertyName = UnidadeEstoqueDTO.FieldNames.LocalDescricao;
            dtgUnidaEstoque.Columns["colIdt"].DataPropertyName = UnidadeEstoqueDTO.FieldNames.Idt;
            dtgUnidaEstoque.Columns["colIdtLocal"].DataPropertyName = UnidadeEstoqueDTO.FieldNames.LocalAtendimentoId;
            dtgUnidaEstoque.Columns["colUnidIdt"].DataPropertyName = UnidadeEstoqueDTO.FieldNames.UnidadeId;
        }

        private void CarregaGrid()
        {
            ConfiguraGrid();
            dtgUnidaEstoque.AutoGenerateColumns = false;
            dtgUnidaEstoque.DataSource = matMed.Sel(new UnidadeEstoqueDTO());
        }

        #endregion

        #region botoes

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            MudaBotoes("CANCELA");

        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {

            MudaBotoes("INS");
            txtUniDescricao.Text = string.Empty;
            cboLocal.Items.Clear();
            cboLocal.Text = string.Empty;
            cboUnidade.Text = string.Empty;
            txtUniDescricao.Focus();

        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cboUnidade.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma Unidade");
            }

            if (cboLocal.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma Unidade");
            }
            if (txtUniDescricao.Text == string.Empty)
            {
                MessageBox.Show("Digite Uma Descrição para a Unidade");
            }

            UnidadeEstoqueDTO dto = new UnidadeEstoqueDTO();
            dto.Idt.Value = (txtIdt.Text.Length == 0 ?  0 : Convert.ToInt32(txtIdt.Text));
            dto.UniEstDescricao.Value = txtUniDescricao.Text;
            dto.UnidadeId.Value = ((ListItem)cboUnidade.SelectedItem).Value;
            dto.LocalAtendimentoId.Value = ((ListItem)cboLocal.SelectedItem).Value;
            dto = matMed.Grava(dto);
            txtIdt.Text = dto.Idt.Value;

            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            btnNovo.Enabled = true;
            MudaBotoes("SALVA");

            MessageBox.Show("Registro Salvo com sucesso !!!", "Materiais Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

        }


        #endregion


        //private void cboUnidade_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ListItem item = (ListItem)cboUnidade.SelectedItem;
        //    idtUnidade = Convert.ToInt32(item.Value);
        //    cboLocal.Text = string.Empty;
        //    cboLocal.CarregaLocal(idtUnidade);
        //}

        private void dtgUnidaEstoque_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtIdt.Text = dtgUnidaEstoque.SelectedRows[0].Cells["colIdt"].Value.ToString();
            txtUniDescricao.Text = dtgUnidaEstoque.SelectedRows[0].Cells["colDsUnidade"].Value.ToString();
            cboUnidade.ValueMember = dtgUnidaEstoque.SelectedRows[0].Cells["colUnidIdt"].Value.ToString();
            cboUnidade.Text = dtgUnidaEstoque.SelectedRows[0].Cells["colUnidade"].Value.ToString();
            cboLocal.ValueMember = dtgUnidaEstoque.SelectedRows[0].Cells["colIdtLocal"].Value.ToString();
            cboLocal.Text = dtgUnidaEstoque.SelectedRows[0].Cells["colLocal"].Value.ToString();
            MudaBotoes("EDIT");
        }

        private void FrmUnidadesEstoque_Load(object sender, EventArgs e)
        {
            // botoes
            MudaBotoes("INI");

            CarregaGrid();
            cboUnidade.Carregaunidade();

        }

    }
}

