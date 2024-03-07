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
    public partial class FrmPesquisaMatMed : FrmBase
    {
        private bool _pesqCodAnvisa = false;
        [Category("Hac")]
        public bool PesquisarPorCodANVISA
        {
            get { return _pesqCodAnvisa; }
            set { _pesqCodAnvisa = value; }
        }

        private bool _listaSal = false;
        public bool ListaSal
        {
            get { return _listaSal; }
            set { _listaSal = value; }
        }

        private string _diluente;
        [Category("Hac")]
        public string Diluente
        {
            get { return _diluente; }
            set { _diluente = value; }
        }

        public FrmPesquisaMatMed()
        {
            InitializeComponent();

            Titulo = "Pesquisar Produto Material Medicamento";
        }

        
        private DataTable dtb;
        public DataTable Dtb
        {
            get { return dtb; }
            set { dtb = value; }
        }
        private MaterialMedicamentoDataTable dtbMaterialMedicamento;
        public MaterialMedicamentoDataTable DtbMaterialMedicamento
        {
            get { return dtbMaterialMedicamento; }
            set { dtbMaterialMedicamento = value; }
        }
        private MaterialMedicamentoDTO dtoMaterialMedicamento;

        
        private void FrmPesquisaProcedimento_Load(object sender, EventArgs e)
        {
            dgvPesquisaProdutoMatMed.AutoGenerateColumns = false;
            dgvPesquisaProdutoMatMed.Columns["Codigo"].DataPropertyName = MaterialMedicamentoDTO.FieldNames.CodMne;
            dgvPesquisaProdutoMatMed.Columns["Descricao"].DataPropertyName = MaterialMedicamentoDTO.FieldNames.Descricao;
            dgvPesquisaProdutoMatMed.Columns[colFabricante.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.CdFabricante;
           // dgvPesquisaProdutoMatMed.Columns[colCodAnvisa.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.CodigoAnvisa;
            dgvPesquisaProdutoMatMed.Columns[colNomeFantasia.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.NomeFantasia;
            if (ListaSal)
            {
                dgvPesquisaProdutoMatMed.Columns[colNomeFantasia.Name].HeaderText = "SAL";
                lblCod.Visible = txtCod.Visible = false;

                dtb = dtbMaterialMedicamento;
                DataView dv = dtbMaterialMedicamento.DefaultView;  // retiro a dieta, diluente pra não listar
                dv.RowFilter = string.Format("{0} not IN (19, 919, 930)  ", MaterialMedicamentoDTO.FieldNames.IdtSubGrupo);
                dtb = dv.ToTable();
                dgvPesquisaProdutoMatMed.DataSource = dtb;
            }
            else
            {
                dgvPesquisaProdutoMatMed.DataSource = dtbMaterialMedicamento;
            }
            if (Diluente =="1")
            {
                lblCod.Visible= txtCod.Visible = false;
            }
            //if (PesquisarPorCodANVISA)
            //{
            //    lblCod.Text = "Cod. ANVISA:";

            //    dgvPesquisaProdutoMatMed.Columns["Codigo"].HeaderText = "Cod. ANVISA";
            //    dgvPesquisaProdutoMatMed.Columns["Codigo"].DataPropertyName = MaterialMedicamentoDTO.FieldNames.CodigoAnvisa;
            //    dgvPesquisaProdutoMatMed.Columns["Codigo"].Width = 130;

            //    dgvPesquisaProdutoMatMed.Columns[colCodAnvisa.Name].HeaderText = "Cod.";
            //    dgvPesquisaProdutoMatMed.Columns[colCodAnvisa.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.CodMne; 
            //}

            
            dgvPesquisaProdutoMatMed.Sort(colNomeFantasia, ListSortDirection.Ascending);
         
            txtNomeProcedimento.Focus();
          
        }

        public static MaterialMedicamentoDTO AbrirPesquisaMaterialMedicamento(MaterialMedicamentoDataTable dtbMatdMed, string diluente)
        {
            return AbrirPesquisaMaterialMedicamento(dtbMatdMed, false, diluente,false);
        }
        public static MaterialMedicamentoDTO AbrirPesquisaMaterialMedicamento(MaterialMedicamentoDataTable dtbMatdMed, bool listaSal)
        {
            return AbrirPesquisaMaterialMedicamento(dtbMatdMed, false, string.Empty, listaSal);
        }
        public static MaterialMedicamentoDTO AbrirPesquisaMaterialMedicamento(MaterialMedicamentoDataTable dtbMaterialMedicamento, bool pesquisaCodAnvisa, string diluente, bool listaSal)
        {
            FrmPesquisaMatMed frmPesquisa = new FrmPesquisaMatMed();
            dtbMaterialMedicamento.DefaultView.RowFilter = null;
            frmPesquisa.PesquisarPorCodANVISA = pesquisaCodAnvisa;
            frmPesquisa.Diluente = diluente;
            frmPesquisa.ListaSal = listaSal;
            frmPesquisa.DtbMaterialMedicamento = dtbMaterialMedicamento;
            frmPesquisa.ShowDialog();
            return frmPesquisa.dtoMaterialMedicamento;
        }

       
        private void dgvPesquisaProcedimentoProposto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dtoMaterialMedicamento = (MaterialMedicamentoDTO)((DataRowView)dgvPesquisaProdutoMatMed.Rows[e.RowIndex].DataBoundItem).Row;
                this.Close();  
            }
        }

        private void txtNomeProcedimentoProposto_TextChanged(object sender, EventArgs e)
        {
            if (txtCod.Text.ToString() != string.Empty && txtNomeProcedimento.Text.ToString() != string.Empty) txtCod.Text = string.Empty;
            if (txtNomeProcedimento.Text.ToString() == string.Empty)
                dtbMaterialMedicamento.DefaultView.RowFilter = null;
            else if (ListaSal)
            {
                dtbMaterialMedicamento.DefaultView.RowFilter = String.Format("{0} LIKE '%{1}%' and {2} not IN (19, 919, 930) ",
                                                                 MaterialMedicamentoDTO.FieldNames.Descricao, MontarLike(txtNomeProcedimento.Text),
                                                                 MaterialMedicamentoDTO.FieldNames.IdtSubGrupo);
            }
            else
                dtbMaterialMedicamento.DefaultView.RowFilter = String.Format("{0} LIKE '%{1}%'",
                                                                 MaterialMedicamentoDTO.FieldNames.NomeFantasia, MontarLike(txtNomeProcedimento.Text));
            dgvPesquisaProdutoMatMed.DataSource = dtb = dtbMaterialMedicamento;
        }

        private void txtCod_TextChanged(object sender, EventArgs e)
        {
            if (txtNomeProcedimento.Text.ToString() != string.Empty && txtCod.Text.ToString() != string.Empty) txtNomeProcedimento.Text = string.Empty;
            if (txtCod.Text.ToString() == string.Empty)
                dtbMaterialMedicamento.DefaultView.RowFilter = null;
            else
            {
                //if (PesquisarPorCodANVISA)
                //    dtbMaterialMedicamento.DefaultView.RowFilter = String.Format("{0} LIKE '{1}%'",
                //                                                     MaterialMedicamentoDTO.FieldNames.CodigoAnvisa, txtCod.Text.ToString());
                //else
                    dtbMaterialMedicamento.DefaultView.RowFilter = String.Format("{0} LIKE '{1}%'",
                                                                     MaterialMedicamentoDTO.FieldNames.CodMne, txtCod.Text.ToString());
            }
        }

        public string MontarLike(string textoPesquisa)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < textoPesquisa.Length; i++)
            {
                char c = textoPesquisa[i];
                if (c == '*' || c == '%')
                    sb.Append("%' AND " + MaterialMedicamentoDTO.FieldNames.NomeFantasia + " LIKE '%");
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }
}