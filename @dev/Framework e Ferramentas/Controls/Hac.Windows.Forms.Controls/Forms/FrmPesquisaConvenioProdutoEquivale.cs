using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using Hac.Windows.Forms;

using HospitalAnaCosta.SGS.Cadastro;

namespace Hac.Windows.Forms.Controls.Forms
{
    public partial class FrmPesquisaConvenioProdutoEquivale : FrmBase
    {
        public FrmPesquisaConvenioProdutoEquivale()
        {
            InitializeComponent();

            Titulo = "Pesquisar Procedimento Associado ao Convênio Equivalencia";
        }

        private DataTable dtb;
        private static DataRow rowResultado;
        public DataTable Dtb
        {
            get { return dtb; }
            set { dtb = value; }
        }

        private ConvenioProdutoEquivalenciaDTO dto;

        private void FrmPesquisaProcedimentoProposto_Load(object sender, EventArgs e)
        {
            dgvPesquisaProcedimentoProposto.AutoGenerateColumns = false;
            dgvPesquisaProcedimentoProposto.Columns["Codigo"].DataPropertyName = ConvenioProdutoEquivalenciaDTO.FieldNames.IdtProdutoDestino;
            dgvPesquisaProcedimentoProposto.Columns["Descricao"].DataPropertyName = "CAD_PRD_DS_DESCRICAO_DESTINO";

            dgvPesquisaProcedimentoProposto.DataSource = dtb;
        }

        public static DataRow AbrirPesquisaConvenioProdutoEquivalencia
                        (DataTable dtbConvenioProdutoEquivalencia)
        {
            FrmPesquisaConvenioProdutoEquivale frmPesquisa = new FrmPesquisaConvenioProdutoEquivale();
            frmPesquisa.Dtb = dtbConvenioProdutoEquivalencia;
            AbrirFormularioDialog(frmPesquisa);

            return rowResultado;
        }

        private void dgvPesquisaProcedimentoProposto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvPesquisaProcedimentoProposto.Rows[e.RowIndex];
                rowResultado = ((DataRowView)row.DataBoundItem).Row;
                //dto = (ConvenioProdutoEquivalenciaDTO)dtb.Select(
                //    string.Format("{0} = '{1}'", ConvenioProdutoEquivalenciaDTO.FieldNames.IdtProdutoDestino, row.Cells["Codigo"].Value.ToString()))[0];
                this.Close();
            }
        }

        private void txtNomeProcedimentoProposto_TextChanged(object sender, EventArgs e)
        {
            if (txtNomeProcedimentoProposto.Text.ToString() == string.Empty)
                dtb.DefaultView.RowFilter = null;
            else
                dtb.DefaultView.RowFilter = String.Format("{0} LIKE '%{1}%'",
                       "CAD_PRD_DS_DESCRICAO_DESTINO", txtNomeProcedimentoProposto.Text.ToString());
        }


    }
}