using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Relatorio;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    public partial class FrmRelatoriosInventario : FrmBase
    {
        public FrmRelatoriosInventario()
        {
            InitializeComponent();
        }

        private void btnSaldo_Click(object sender, EventArgs e)
        {
            FrmRelEstoque frmRelEstoque = new FrmRelEstoque();
            frmRelEstoque.MdiParent = FrmPrincipal.ActiveForm;
            frmRelEstoque.Show();
        }

        private void btnDivergeCont1_Click(object sender, EventArgs e)
        {
            FrmRelEstoque frmRelEstoque = new FrmRelEstoque();
            frmRelEstoque.MdiParent = FrmPrincipal.ActiveForm;
            frmRelEstoque.DivergenciaContagem_1 = true;
            frmRelEstoque.Show();
        }  

        private void btnDivergeCont2_Click(object sender, EventArgs e)
        {
            FrmRelEstoque frmRelEstoque = new FrmRelEstoque();
            frmRelEstoque.MdiParent = FrmPrincipal.ActiveForm;
            frmRelEstoque.DivergenciaContagem_2 = true;
            frmRelEstoque.Show();
        }

        private void btnDivergeCont3_Click(object sender, EventArgs e)
        {
            FrmRelEstoque frmRelEstoque = new FrmRelEstoque();
            frmRelEstoque.MdiParent = FrmPrincipal.ActiveForm;
            frmRelEstoque.DivergenciaContagem_3 = true;
            frmRelEstoque.Show();
        }

        private void btnDigitaFinal_Click(object sender, EventArgs e)
        {
            FrmRelEstoque frmRelEstoque = new FrmRelEstoque();
            frmRelEstoque.MdiParent = FrmPrincipal.ActiveForm;
            frmRelEstoque.DigitacaoFinal = true;
            frmRelEstoque.Show();
        }

        private void btnDemonstrativo_Click(object sender, EventArgs e)
        {
            FrmRelEstoque frmRelEstoque = new FrmRelEstoque();
            frmRelEstoque.MdiParent = FrmPrincipal.ActiveForm;
            frmRelEstoque.DemonstrativoContagem = true;
            frmRelEstoque.Show();
        }

        private void btnRegistroInvent_Click(object sender, EventArgs e)
        {
            FrmRelRegistroInventario frm = new FrmRelRegistroInventario();
            frm.MdiParent = FrmPrincipal.ActiveForm;
            frm.Show();
        }

        private void btnSetoresSemContagem_Click(object sender, EventArgs e)
        {
            FrmRelSetoresInvent frm = new FrmRelSetoresInvent();
            frm.MdiParent = FrmPrincipal.ActiveForm;
            frm.SetoresSaldoSemContagem = true;
            frm.Show();
        }

        private void btnRelGeralSetores_Click(object sender, EventArgs e)
        {
            FrmRelSetoresInvent frm = new FrmRelSetoresInvent();
            frm.MdiParent = FrmPrincipal.ActiveForm;            
            frm.Show();
        }                
    }
}