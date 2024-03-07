using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.DTO;


namespace Hac.Windows.Forms.Controls.Forms
{
    public partial class FrmPesquisaClinica : FrmBase
    {
        public FrmPesquisaClinica()
        {
            InitializeComponent();

            Titulo = "Pesquisar Clínica";
        }

        private ClinicaDataTable dtbClinica;

        public ClinicaDataTable DtbClinica
        {
            get { return dtbClinica; }
            set { dtbClinica = value; }
        }

        private ClinicaDTO dtoClinica;

        private void FrmPesquisaClinica_Load(object sender, EventArgs e)
        {
            dgvPesquisaClinica.AutoGenerateColumns = false;

            dgvPesquisaClinica.Columns["Idt"].DataPropertyName = ClinicaDTO.FieldNames.Idt;
            dgvPesquisaClinica.Columns["Codigo"].DataPropertyName = ClinicaDTO.FieldNames.CodigoClinica;
            dgvPesquisaClinica.Columns["Descricao"].DataPropertyName = ClinicaDTO.FieldNames.Descricao;

            dgvPesquisaClinica.DataSource = dtbClinica;

            dgvPesquisaClinica.Sort(Descricao, ListSortDirection.Ascending);

            txtDescricaoClinica.Focus();
        }

        private void FrmPesquisaClinica_Activated(object sender, EventArgs e)
        {
            txtDescricaoClinica.Focus();
        }

        public static ClinicaDTO AbrirPesquisaClinica(ClinicaDataTable dtbClinica)
        {
            FrmPesquisaClinica frmPesquisa = new FrmPesquisaClinica();
            frmPesquisa.DtbClinica = dtbClinica;
            frmPesquisa.ShowDialog();
            return frmPesquisa.dtoClinica;
        }

        private void dgvPesquisaClinica_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dtoClinica = (ClinicaDTO)((DataRowView)dgvPesquisaClinica.Rows[e.RowIndex].DataBoundItem).Row;
                this.Close();  
            }
        }

        private void txtNomeClinica_TextChanged(object sender, EventArgs e)
        {
            if (txtDescricaoClinica.Text.ToString() == string.Empty)
            {
                dtbClinica.DefaultView.RowFilter = null;
            }
            else
            {
                dtbClinica.DefaultView.RowFilter = String.Format("{0} LIKE '%{1}%'",
                                                                 ClinicaDTO.FieldNames.Descricao,
                                                                 txtDescricaoClinica.Text.ToString());
            }
        }
    }
}