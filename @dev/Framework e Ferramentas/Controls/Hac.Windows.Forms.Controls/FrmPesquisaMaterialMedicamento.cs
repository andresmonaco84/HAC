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
    public partial class FrmPesquisaMaterialMedicamento : FrmBase
    {
        private bool _pesqCodAnvisa = false;
        [Category("Hac")]
        public bool PesquisarPorCodANVISA
        {
            get { return _pesqCodAnvisa; }
            set { _pesqCodAnvisa = value; }
        }

        public FrmPesquisaMaterialMedicamento()
        {
            InitializeComponent();

            Titulo = "Pesquisar Produto Material Medicamento";
        }

        private MaterialMedicamentoDataTable dtbMaterialMedicamento;
        public MaterialMedicamentoDataTable DtbMaterialMedicamento
        {
            get { return dtbMaterialMedicamento; }
            set { dtbMaterialMedicamento = value; }
        }
        private MaterialMedicamentoDTO dtoMaterialMedicamento;


        private ProdutoDataTable dtbMatdMed;
        public ProdutoDataTable DtbMatMed
        {
            get { return dtbMatdMed; }
            set { dtbMatdMed = value; }
        }

        private ProdutoDTO dtoMatMed;

        private void FrmPesquisaProcedimento_Load(object sender, EventArgs e)
        {
            dgvPesquisaProdutoMatMed.AutoGenerateColumns = false;
            dgvPesquisaProdutoMatMed.Columns["Codigo"].DataPropertyName = ProdutoDTO.FieldNames.Mnemonico;
            dgvPesquisaProdutoMatMed.Columns["Descricao"].DataPropertyName = ProdutoDTO.FieldNames.Descricao;
            dgvPesquisaProdutoMatMed.Columns[colFabricante.Name].DataPropertyName = ProdutoDTO.FieldNames.NomeFabricanteMatMed;
            dgvPesquisaProdutoMatMed.Columns[colCodAnvisa.Name].DataPropertyName = ProdutoDTO.FieldNames.CodAnvisa;
            dgvPesquisaProdutoMatMed.Columns[colNomeFantasia.Name].DataPropertyName = ProdutoDTO.FieldNames.NomeFantasia;

            if (PesquisarPorCodANVISA)
            {
                lblCod.Text = "Cod. ANVISA:";

                dgvPesquisaProdutoMatMed.Columns["Codigo"].HeaderText = "Cod. ANVISA";
                dgvPesquisaProdutoMatMed.Columns["Codigo"].DataPropertyName = ProdutoDTO.FieldNames.CodAnvisa;
                dgvPesquisaProdutoMatMed.Columns["Codigo"].Width = 130;

                dgvPesquisaProdutoMatMed.Columns[colCodAnvisa.Name].HeaderText = "Cod.";
                dgvPesquisaProdutoMatMed.Columns[colCodAnvisa.Name].DataPropertyName = ProdutoDTO.FieldNames.Mnemonico; 
            }

            dgvPesquisaProdutoMatMed.DataSource = dtbMatdMed;
            dgvPesquisaProdutoMatMed.Sort(colNomeFantasia, ListSortDirection.Ascending);
        }

        public static MaterialMedicamentoDTO AbrirPesquisaMaterialMedicamento (MaterialMedicamentoDataTable dtbMatdMed)
        {
            return AbrirPesquisaMaterialMedicamento(dtbMatdMed, false);
        }
        public static MaterialMedicamentoDTO AbrirPesquisaMaterialMedicamento (MaterialMedicamentoDataTable dtbMaterialMedicamento, bool pesquisaCodAnvisa)
        {
            FrmPesquisaMaterialMedicamento frmPesquisa = new FrmPesquisaMaterialMedicamento();
            dtbMaterialMedicamento.DefaultView.RowFilter = null;
            frmPesquisa.PesquisarPorCodANVISA = pesquisaCodAnvisa;
            frmPesquisa.DtbMaterialMedicamento = dtbMaterialMedicamento;
            frmPesquisa.ShowDialog();
            return frmPesquisa.dtoMaterialMedicamento;
        }

        public static ProdutoDTO AbrirPesquisaMaterialMedicamento (ProdutoDataTable dtbMatdMed)
        {            
            return AbrirPesquisaMaterialMedicamento(dtbMatdMed, false);
        }

        public static ProdutoDTO AbrirPesquisaMaterialMedicamento (ProdutoDataTable dtbMatdMed, bool pesquisaCodAnvisa)
        {
            FrmPesquisaMaterialMedicamento frmPesquisa = new FrmPesquisaMaterialMedicamento();
            dtbMatdMed.DefaultView.RowFilter = null;
            frmPesquisa.PesquisarPorCodANVISA = pesquisaCodAnvisa;
            frmPesquisa.DtbMatMed = dtbMatdMed;            
            frmPesquisa.ShowDialog();
            return frmPesquisa.dtoMatMed;
        }

        private void dgvPesquisaProcedimentoProposto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dtoMatMed = (ProdutoDTO)((DataRowView)dgvPesquisaProdutoMatMed.Rows[e.RowIndex].DataBoundItem).Row;
                this.Close();  
            }
        }

        private void txtNomeProcedimentoProposto_TextChanged(object sender, EventArgs e)
        {
            if (txtCod.Text.ToString() != string.Empty && txtNomeProcedimento.Text.ToString() != string.Empty) txtCod.Text = string.Empty;
            if (txtNomeProcedimento.Text.ToString() == string.Empty)
                dtbMatdMed.DefaultView.RowFilter = null;
            else
                dtbMatdMed.DefaultView.RowFilter = String.Format("{0} LIKE '{1}'",
                                                                 ProdutoDTO.FieldNames.NomeFantasia, MontarLike(txtNomeProcedimento.Text));
            
        }

        private void txtCod_TextChanged(object sender, EventArgs e)
        {
            if (txtNomeProcedimento.Text.ToString() != string.Empty && txtCod.Text.ToString() != string.Empty) txtNomeProcedimento.Text = string.Empty;
            if (txtCod.Text.ToString() == string.Empty)
                dtbMatdMed.DefaultView.RowFilter = null;
            else
            {
                if (PesquisarPorCodANVISA)
                    dtbMatdMed.DefaultView.RowFilter = String.Format("{0} LIKE '{1}%'",
                                                                     ProdutoDTO.FieldNames.CodAnvisa, txtCod.Text.ToString());
                else
                    dtbMatdMed.DefaultView.RowFilter = String.Format("{0} LIKE '{1}%'",
                                                                     ProdutoDTO.FieldNames.Codigo, txtCod.Text.ToString());
            }
        }

        public string MontarLike(string textoPesquisa)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < textoPesquisa.Length; i++)
            {
                char c = textoPesquisa[i];
                if (c == '*' || c == '%')
                    sb.Append("%' AND " + ProdutoDTO.FieldNames.NomeFantasia + " LIKE '%");
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }
}