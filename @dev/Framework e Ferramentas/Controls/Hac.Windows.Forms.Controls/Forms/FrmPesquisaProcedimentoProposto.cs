using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using Hac.Windows.Forms;
using HospitalAnaCosta.Services.Produto.DTO;

namespace Hac.Windows.Forms.Controls.Forms
{
    public partial class FrmPesquisaProcedimentoProposto : FrmBase
    {
        public FrmPesquisaProcedimentoProposto()
        {
            InitializeComponent();

            Titulo = "Pesquisar Procedimento Proposto";
        }

        private DataTable dtbProcedimentoProposto;
        public DataTable DtbProcedimentoProposto
        {
            get { return dtbProcedimentoProposto; }
            set { dtbProcedimentoProposto = value; }
        }

        private ProdutoDTO dtoProcedimentoProposto;

        private void FrmPesquisaProcedimentoProposto_Load(object sender, EventArgs e)
        {
            dgvPesquisaProcedimentoProposto.AutoGenerateColumns = false;
            dgvPesquisaProcedimentoProposto.Columns["Codigo"].DataPropertyName = ProdutoDTO.FieldNames.Codigo;
            dgvPesquisaProcedimentoProposto.Columns["Descricao"].DataPropertyName = ProdutoDTO.FieldNames.Descricao;

            dgvPesquisaProcedimentoProposto.DataSource = dtbProcedimentoProposto;

            dgvPesquisaProcedimentoProposto.Sort(Descricao,ListSortDirection.Ascending);

            txtNomeProcedimentoProposto_TextChanged(sender, e);
        }

        public static ProdutoDTO AbrirPesquisaProcedimentoProposto(DataTable dtbProcedimentoProposto)
        {
            FrmPesquisaProcedimentoProposto frmPesquisa = new FrmPesquisaProcedimentoProposto();
            frmPesquisa.DtbProcedimentoProposto = dtbProcedimentoProposto;
            frmPesquisa.ShowDialog();
            return frmPesquisa.dtoProcedimentoProposto;
        }

        private void dgvPesquisaProcedimentoProposto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                //dtoProcedimentoProposto = (ProdutoDTO)((DataRowView)dgvPesquisaProcedimentoProposto.Rows[e.RowIndex].DataBoundItem).Row;
                dtoProcedimentoProposto = new ProdutoDTO();

                //TODO: Fabíola
                if (((DataRowView)dgvPesquisaProcedimentoProposto.Rows[e.RowIndex].DataBoundItem).Row[ProdutoDTO.FieldNames.Idt].ToString() == "")
                {
                    dtoProcedimentoProposto.Codigo.Value = ((DataRowView)dgvPesquisaProcedimentoProposto.Rows[e.RowIndex].DataBoundItem).Row[ProdutoDTO.FieldNames.Codigo].ToString().Trim();
                    dtoProcedimentoProposto = Produto.Listar(dtoProcedimentoProposto).TypedRow(0);
                }
                else
                {
                    dtoProcedimentoProposto.Idt.Value = ((DataRowView)dgvPesquisaProcedimentoProposto.Rows[e.RowIndex].DataBoundItem).Row[ProdutoDTO.FieldNames.Idt].ToString();
                    dtoProcedimentoProposto = Produto.Pesquisar(dtoProcedimentoProposto);
                }
                
                this.Close();  
            }
        }

        private void txtNomeProcedimentoProposto_TextChanged(object sender, EventArgs e)
        {
            if (txtNomeProcedimentoProposto.Text.ToString() == string.Empty)
                dtbProcedimentoProposto.DefaultView.RowFilter = null;
            else
                dtbProcedimentoProposto.DefaultView.RowFilter = String.Format("{0} LIKE '%{1}%'", 
                        ProdutoDTO.FieldNames.Descricao, txtNomeProcedimentoProposto.Text.ToString());
        }

        private void dgvPesquisaProcedimentoProposto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgvPesquisaProcedimentoProposto.SelectedRows.Count > 0)
            {
                DataGridViewCellEventArgs eg = new DataGridViewCellEventArgs(dgvPesquisaProcedimentoProposto.SelectedRows[0].Index, dgvPesquisaProcedimentoProposto.SelectedRows[0].Index);
                dgvPesquisaProcedimentoProposto_CellDoubleClick(sender,eg);
            }
        }
    }
}