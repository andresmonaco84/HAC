using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using Hac.Windows.Forms;


namespace Hac.Windows.Forms.Controls.Forms
{
    public partial class FrmPesquisaPlano : FrmBase
    {
        public FrmPesquisaPlano()
        {
            InitializeComponent();

            Titulo = "Pesquisar Plano";
        }

        private PlanoDataTable dtbPlano;

        public PlanoDataTable DtbPlano
        {
            get { return dtbPlano; }
            set { dtbPlano = value; }
        }

        private PlanoDTO dtoPlano;

        private void FrmPesquisaPlano_Load(object sender, EventArgs e)
        {
            dgvPesquisaPlano.AutoGenerateColumns = false;

            dgvPesquisaPlano.Columns["IdtPlano"].DataPropertyName = PlanoDTO.FieldNames.IdtPlano;
            dgvPesquisaPlano.Columns["Codigo"].DataPropertyName = PlanoDTO.FieldNames.CodigoPlanoHAC;
            dgvPesquisaPlano.Columns["Descricao"].DataPropertyName = PlanoDTO.FieldNames.NomePlano;
            dgvPesquisaPlano.Columns["Categoria"].DataPropertyName = PlanoDTO.FieldNames.CategoriaPlano;

            dgvPesquisaPlano.DataSource = dtbPlano;

            dgvPesquisaPlano.Sort(Descricao, ListSortDirection.Ascending);

        }

        public static PlanoDTO AbrirPesquisaPlano
                        (PlanoDataTable dtbPlano)
        {
            FrmPesquisaPlano frmPesquisa = new FrmPesquisaPlano();
            frmPesquisa.DtbPlano = dtbPlano;
            frmPesquisa.ShowDialog();
            return frmPesquisa.dtoPlano;
        }

        private void dgvPesquisaPlano_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dtoPlano = (PlanoDTO)((DataRowView)dgvPesquisaPlano.Rows[e.RowIndex].DataBoundItem).Row;
                this.Close();  
            }
        }

        private void txtNomePlano_TextChanged(object sender, EventArgs e)
        {
            if (txtDescricaoPlano.Text.ToString() == string.Empty)
                dtbPlano.DefaultView.RowFilter = null;
            else
                dtbPlano.DefaultView.RowFilter = String.Format("{0} LIKE '%{1}%'",
                        PlanoDTO.FieldNames.NomePlano, txtDescricaoPlano.Text.ToString());
        }

    }
}