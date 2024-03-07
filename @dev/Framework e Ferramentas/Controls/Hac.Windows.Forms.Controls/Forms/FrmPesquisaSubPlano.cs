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
    public partial class FrmPesquisaSubPlano : FrmBase
    {
        public FrmPesquisaSubPlano()
        {
            InitializeComponent();

            Titulo = "Pesquisar Sub Plano";
        }

        private SubPlanoDataTable dtbSubPlano;

        public SubPlanoDataTable DtbSubPlano
        {
            get { return dtbSubPlano; }
            set { dtbSubPlano = value; }
        }

        private SubPlanoDTO dtoSubPlano;

        private void FrmPesquisaSubPlano_Load(object sender, EventArgs e)
        {
            dgvPesquisaSubPlano.AutoGenerateColumns = false;

            dgvPesquisaSubPlano.Columns["Codigo"].DataPropertyName = SubPlanoDTO.FieldNames.Codigo;
            dgvPesquisaSubPlano.Columns["Descricao"].DataPropertyName = SubPlanoDTO.FieldNames.Descricao;

            dgvPesquisaSubPlano.DataSource = dtbSubPlano;

            dgvPesquisaSubPlano.Sort(Descricao, ListSortDirection.Ascending);
        }

        public static SubPlanoDTO AbrirPesquisaSubPlano
                        (SubPlanoDataTable dtbSubPlano)
        {
            FrmPesquisaSubPlano frmPesquisa = new FrmPesquisaSubPlano();
            frmPesquisa.DtbSubPlano = dtbSubPlano;
            frmPesquisa.ShowDialog();
            return frmPesquisa.dtoSubPlano;
        }

        private void dgvPesquisaSubPlano_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dtoSubPlano = (SubPlanoDTO)((DataRowView)dgvPesquisaSubPlano.Rows[e.RowIndex].DataBoundItem).Row;
                this.Close();   
            }
        }

        private void txtNomeSubPlano_TextChanged(object sender, EventArgs e)
        {
            if (txtDescricaoSubPlano.Text.ToString() == string.Empty)
                dtbSubPlano.DefaultView.RowFilter = null;
            else
                dtbSubPlano.DefaultView.RowFilter = String.Format("{0} LIKE '%{1}%'",
                        SubPlanoDTO.FieldNames.Descricao, txtDescricaoSubPlano.Text.ToString());
        }

    }
}