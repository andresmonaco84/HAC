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
    public partial class FrmPesquisaFornecedor : FrmBase
    {
        private DataTable dtbFornecedor;
        
        public FrmPesquisaFornecedor()
        {
            InitializeComponent();
        }

        private void FrmPesquisaFornecedor_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dtbFornecedor = MaterialMedicamento.ListarFornecedores();
            dgvPesquisaForn.AutoGenerateColumns = false;
            dgvPesquisaForn.DataSource = dtbFornecedor;
            dtbFornecedor.DefaultView.RowFilter = MontarFiltro();
            this.Cursor = Cursors.Default;
        }

        private string MontarFiltro()
        {
            this.Cursor = Cursors.WaitCursor;

            string filtro = string.Format("CAD_FORN_FILIAL_ID = {0} ", rbHAC.Checked ? 1 : 2);
            
            if (txtCod.Text != string.Empty)
                filtro += string.Format("AND CAD_FORN_CODCFO LIKE '{0}%' ", txtCod.Text);

            if (txtNome.Text != string.Empty)
                filtro += string.Format("AND CAD_FORN_NOME LIKE '{0}' ", MontarLikeNome());

            this.Cursor = Cursors.Default;

            return filtro;
        }                

        private string MontarLikeNome()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < txtNome.Text.Length; i++)
            {
                char c = txtNome.Text[i];
                if (c == '*' || c == '%')
                    sb.Append("%' AND CAD_FORN_NOME LIKE '%");
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }

        private void rbHAC_Click(object sender, EventArgs e)
        {
            dtbFornecedor.DefaultView.RowFilter = MontarFiltro();
        }

        private void rbACS_Click(object sender, EventArgs e)
        {
            dtbFornecedor.DefaultView.RowFilter = MontarFiltro();
        }

        private void txtCod_TextChanged(object sender, EventArgs e)
        {
            if (txtNome.Text != string.Empty && txtCod.Text != string.Empty) txtNome.Text = string.Empty;
            dtbFornecedor.DefaultView.RowFilter = MontarFiltro();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (txtNome.Text != string.Empty && txtCod.Text != string.Empty) txtCod.Text = string.Empty;
            dtbFornecedor.DefaultView.RowFilter = MontarFiltro();
        }

        private void dgvPesquisaForn_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)            
                return;

            this.Codigo = dgvPesquisaForn.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.NomeFornecedor = dgvPesquisaForn.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.CodigoFornecedorMaterial = dgvPesquisaForn.Rows[e.RowIndex].Cells[2].Value.ToString();            
            this.Close();
        }

        public string Codigo { get; set; }
        public string NomeFornecedor { get; set; }
        public string CodigoFornecedorMaterial { get; set; }
    }
}