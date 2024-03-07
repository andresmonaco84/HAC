using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.DTO;

namespace Hac.Windows.Forms.Controls.Forms
{
    public partial class FrmPesquisaProfissionalCorpoClinico : FrmBase
    {
        public FrmPesquisaProfissionalCorpoClinico()
        {
            InitializeComponent();

            Titulo = "Pesquisar Profissional";
        }

        private ProfissionalDataTable dtbProfissionalCorpoClinico;

        public ProfissionalDataTable DtbProfissionalCorpoClinico
        {
            get { return dtbProfissionalCorpoClinico; }
            set { dtbProfissionalCorpoClinico = value; }
        }

        //public bool 

        private ProfissionalDTO dtoProfissionalCorpoClinico;

        private void FrmPesquisaProfissionalCorpoClinico_Load(object sender, EventArgs e)
        {
            dgvPesquisaProfissinalCorpoClinico.AutoGenerateColumns = false;
            dgvPesquisaProfissinalCorpoClinico.Columns["TipoConselho"].DataPropertyName = ProfissionalDTO.FieldNames.CodigoConselho;
            dgvPesquisaProfissinalCorpoClinico.Columns["UFConselho"].DataPropertyName = ProfissionalDTO.FieldNames.UFConselho;
            dgvPesquisaProfissinalCorpoClinico.Columns["CodigoConselho"].DataPropertyName = ProfissionalDTO.FieldNames.ConselhoProfissional;
            dgvPesquisaProfissinalCorpoClinico.Columns["NomeProfissional"].DataPropertyName = ProfissionalDTO.FieldNames.Nome;

            dgvPesquisaProfissinalCorpoClinico.DataSource = dtbProfissionalCorpoClinico;

            dgvPesquisaProfissinalCorpoClinico.Sort(NomeProfissional, ListSortDirection.Ascending);
        }

        public static ProfissionalDTO AbrirPesquisaProfissionalCorpoClinico
                        (ProfissionalDataTable dtbProfissionalCorpoClinico)
        {
            FrmPesquisaProfissionalCorpoClinico frmPesquisa = new FrmPesquisaProfissionalCorpoClinico();
            frmPesquisa.DtbProfissionalCorpoClinico = dtbProfissionalCorpoClinico;
            frmPesquisa.ShowDialog();
            return frmPesquisa.dtoProfissionalCorpoClinico;
        }

        private void dgvPesquisaProfissinalSolicitante_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dtoProfissionalCorpoClinico = (ProfissionalDTO)((DataRowView)dgvPesquisaProfissinalCorpoClinico.Rows[e.RowIndex].DataBoundItem).Row;
                this.Close();  
            }
        }

        private void txtNomeProfissionalCorpoClinico_TextChanged(object sender, EventArgs e)
        {
            if (txtNomeProfissionalCorpoClinico.Text.ToString() == string.Empty)
                dtbProfissionalCorpoClinico.DefaultView.RowFilter = null;
            else
                dtbProfissionalCorpoClinico.DefaultView.RowFilter = String.Format("{0} LIKE '%{1}%'", 
                        ProfissionalDTO.FieldNames.Nome, txtNomeProfissionalCorpoClinico.Text.ToString());
        }

        private void txtNomeProfissionalCorpoClinico_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = FrmBase.SoLetras((TextBox)sender, e);
        }

        private void dgvPesquisaProfissinalCorpoClinico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgvPesquisaProfissinalCorpoClinico.SelectedRows.Count > 0)
            {
                DataGridViewCellEventArgs eg = new DataGridViewCellEventArgs(dgvPesquisaProfissinalCorpoClinico.SelectedRows[0].Index, dgvPesquisaProfissinalCorpoClinico.SelectedRows[0].Index);
                dgvPesquisaProfissinalSolicitante_CellDoubleClick(sender, eg);
            }
        }

        
    }
}