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
    public partial class FrmPesquisaConvenio : FrmBase
    {
        public FrmPesquisaConvenio()
        {
            InitializeComponent();

            Titulo = "Pesquisar Convênio";
        }

        private ConvenioDataTable dtbConvenio;

        public ConvenioDataTable DtbConvenio
        {
            get { return dtbConvenio; }
            set { dtbConvenio = value; }
        }

        private ConvenioDTO dtoConvenio;

        private void FrmPesquisaConvenio_Load(object sender, EventArgs e)
        {
            dgvPesquisaConvenio.AutoGenerateColumns = false;

            dgvPesquisaConvenio.Columns["IdtConvenio"].DataPropertyName = ConvenioDTO.FieldNames.IdtConvenio;
            dgvPesquisaConvenio.Columns["Codigo"].DataPropertyName = ConvenioDTO.FieldNames.CodigoHACPrestador;
            dgvPesquisaConvenio.Columns["Descricao"].DataPropertyName = ConvenioDTO.FieldNames.NomeFantasia;

            dgvPesquisaConvenio.DataSource = dtbConvenio;

            dgvPesquisaConvenio.Sort(Descricao, ListSortDirection.Ascending);
        }

        public static ConvenioDTO AbrirPesquisaConvenio
                        (ConvenioDataTable dtbConvenio)
        {
            FrmPesquisaConvenio frmPesquisa = new FrmPesquisaConvenio();
            frmPesquisa.DtbConvenio = dtbConvenio;
            frmPesquisa.ShowDialog();
            return frmPesquisa.dtoConvenio;
        }

        private void dgvPesquisaConvenio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dtoConvenio = (ConvenioDTO)((DataRowView)dgvPesquisaConvenio.Rows[e.RowIndex].DataBoundItem).Row;
                this.Close();  
            }
        }

        private void txtNomeConvenio_TextChanged(object sender, EventArgs e)
        {
            if (txtDescricaoConvenio.Text.ToString() == string.Empty)
                dtbConvenio.DefaultView.RowFilter = null;
            else
                dtbConvenio.DefaultView.RowFilter = String.Format("{0} LIKE '%{1}%'",
                        ConvenioDTO.FieldNames.NomeFantasia, txtDescricaoConvenio.Text.ToString());
        }

    }
}