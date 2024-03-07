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
    public partial class FrmRelatorios : FrmBase
    {
        
        private bool _fecha;
        public bool Fechamento
        {
            set { _fecha = value; }
            get { return _fecha; }
        }
        
        public FrmRelatorios()
        {
            InitializeComponent();
        }

        private void btnIR_Click(object sender, EventArgs e)
        {
            //new FrmIndiceRotatividade().ShowDialog(this);
            // new FrmIndiceRotatividade().Show();
            FrmIndiceRotatividade frmIr = new FrmIndiceRotatividade();
            frmIr.MdiParent = FrmPrincipal.ActiveForm;
            frmIr.Show();
        }

        private void btnConsumo_Click(object sender, EventArgs e)
        {
            //new FrmConsumo().ShowDialog(this);

            // new FrmConsumo().Show();
            //FrmConsumo consumo = new FrmConsumo();
            //consumo.MdiParent = FrmPrincipal.ActiveForm;
            //consumo.Show();
            FrmRelEmprestimos frmRelEmprestimos = new FrmRelEmprestimos();
            frmRelEmprestimos.MdiParent = FrmPrincipal.ActiveForm;
            frmRelEmprestimos.Show();
        }

        private void btnObsoletos_Click(object sender, EventArgs e)
        {
            FrmObsoletos frm = new FrmObsoletos();
            frm.MdiParent = FrmPrincipal.ActiveForm;
            frm.Show();
        }    

        private void btnSaldo_Click(object sender, EventArgs e)
        {
            //new FrmSaldoSetor().ShowDialog(this);
            FrmSaldoSetor frmSaldo = new FrmSaldoSetor();
            frmSaldo.MdiParent = FrmPrincipal.ActiveForm;
            frmSaldo.Show();
        }

        private void btnBaixasEntradas_Click(object sender, EventArgs e)
        {
            FrmSaldoSetor frmSaldo = new FrmSaldoSetor();
            frmSaldo.MdiParent = FrmPrincipal.ActiveForm;
            frmSaldo.BaixasEntradasSetor = true;
            frmSaldo.Show();
        }   

        private void btnBaixas_Click(object sender, EventArgs e)
        {
            FrmSaldoSetor frmSaldo = new FrmSaldoSetor();
            frmSaldo.MdiParent = FrmPrincipal.ActiveForm;
            frmSaldo.BaixasSetorDia = true;
            frmSaldo.Show();
        }

        private void btnConsumoSetor_Click(object sender, EventArgs e)
        {
            FrmSaldoSetor frmSaldo = new FrmSaldoSetor();
            frmSaldo.MdiParent = FrmPrincipal.ActiveForm;
            frmSaldo.BaixasPacienteSetor = true;
            frmSaldo.Show();
        }

        private void btnConsumoPac_Click(object sender, EventArgs e)
        {
            FrmRelConsumoPac consumo = new FrmRelConsumoPac();
            consumo.MdiParent = FrmPrincipal.ActiveForm;
            consumo.Show();
        }

        private void btnPosicaoMensal_Click(object sender, EventArgs e)
        {
            FrmPosicaoMensalProduto posicaoproduto = new FrmPosicaoMensalProduto();
            posicaoproduto.MdiParent = FrmPrincipal.ActiveForm;
            posicaoproduto.Saidas = false;
            posicaoproduto.Show();
        }

        private void btmSaidasUnidades_Click(object sender, EventArgs e)
        {
            FrmPosicaoMensalProduto posicaoproduto = new FrmPosicaoMensalProduto();
            posicaoproduto.MdiParent = FrmPrincipal.ActiveForm;
            posicaoproduto.Saidas = true;
            posicaoproduto.Show();
        }

        private void FrmRelatorios_Load(object sender, EventArgs e)
        {
            if (Fechamento)
            {
                tsHac.TituloTela = "Relatórios de Fechamento Contábil";
                gbFechamento.Visible = true;
            }
            else
            {
                tsHac.TituloTela = "Relatórios Gerenciais";
                gbGerencial.Visible = true;
            }                
        }

        private void btnConfNF_Click(object sender, EventArgs e)
        {
            FrmPosicaoMensalProduto posicaoproduto = new FrmPosicaoMensalProduto();
            posicaoproduto.MdiParent = FrmPrincipal.ActiveForm;
            posicaoproduto.EntradasConferencia = true;
            posicaoproduto.Show();
        }

        private void btnDivergencias_Click(object sender, EventArgs e)
        {
            FrmPosicaoMensalProduto posicaoproduto = new FrmPosicaoMensalProduto();
            posicaoproduto.MdiParent = FrmPrincipal.ActiveForm;
            posicaoproduto.DivergenciasContabil_X_Estoque = true;
            posicaoproduto.Show();
        }               

        private void btnConsumoMedicamentoGrupoMercado_Click(object sender, EventArgs e)
        {
            FrmRelConsumoGrupoMercado consumo = new FrmRelConsumoGrupoMercado();
            consumo.MdiParent = FrmPrincipal.ActiveForm;
            consumo.Show();
        }

        private void btnBaixasSetor_Click(object sender, EventArgs e)
        {
            FrmSaldoSetor frmSaldo = new FrmSaldoSetor();
            frmSaldo.MdiParent = FrmPrincipal.ActiveForm;
            frmSaldo.BaixasSetorXFat = true;
            frmSaldo.Show();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            FrmSaldoSetor frmSaldo = new FrmSaldoSetor();
            frmSaldo.MdiParent = FrmPrincipal.ActiveForm;
            frmSaldo.Pedidos = true;
            frmSaldo.Show();
        }                                 
    }
}