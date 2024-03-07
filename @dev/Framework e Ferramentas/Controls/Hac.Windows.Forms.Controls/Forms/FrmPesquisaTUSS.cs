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
    public partial class FrmPesquisaTUSS : FrmBase
    {
        public FrmPesquisaTUSS()
        {
            InitializeComponent();
        }

        private bool tspCommand_PesquisarClick(object sender)
        {
            grb2.Visible = false;
            if (string.IsNullOrEmpty(txtCod.Text))
                return false;

            ProdutoDTO dtoProd = new ProdutoDTO();
            dtoProd.CodigoTabelaMatMed.Value = txtCod.Text.Trim();
            ProdutoDataTable dtbProd = Produto.ObterPorCodigoTabelaMatMed(dtoProd);

            if (dtbProd.Rows.Count > 0)
            {
                dtoProd = dtbProd.TypedRow(0);
                lblProduto1.Text = dtoProd.Codigo.Value.ToString().Trim() + " - " + dtoProd.Descricao.Value;
                lblCodTUSS1.Text = dtoProd.CodigoTUSS.Value;
                lblTabela1.Text = dtbProd.Rows[0][TabelaMedicaDTO.FieldNames.DescricaoTabelaMedica].ToString();
            }
            else
            {
                lblProduto1.Text = lblCodTUSS1.Text = lblTabela1.Text = "--";
                MessageBox.Show("Nenhum registro encontrado!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtbProd.Rows.Count > 1)
            {
                grb2.Visible = true;
                dtoProd = dtbProd.TypedRow(1);
                lblProduto2.Text = dtoProd.Codigo.Value + " - " + dtoProd.Descricao.Value;
                lblCodTUSS2.Text = dtoProd.CodigoTUSS.Value;
                lblTabela2.Text = dtbProd.Rows[1][TabelaMedicaDTO.FieldNames.DescricaoTabelaMedica].ToString();
            }

            if (dtbProd.Rows.Count > 2)
                MessageBox.Show("Cod. com mais de 2 registros, favor entrar em contato com um administrador!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return true;
        }
    }
}
