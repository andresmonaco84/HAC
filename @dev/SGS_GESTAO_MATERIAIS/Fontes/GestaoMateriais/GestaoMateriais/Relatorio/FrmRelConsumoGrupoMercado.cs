using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Reporting.WinForms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using Microsoft.ReportingServices.ReportRendering;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    public partial class FrmRelConsumoGrupoMercado : FrmBase
    {
        private Generico gen = new Generico();
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }

        public FrmRelConsumoGrupoMercado()
        {
            InitializeComponent();
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            
            dtg.DataSource = Movimento.RelatorioConsumoGrupoMercado(radMesAtual.Checked ? "1" : "3");
            return true;
        }

        private bool tsHac_LimparClick(object sender)
        {
            dtg.DataSource = null;
            tsHac.Items["tsBtnPesquisar"].Enabled = true;
            return true;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dtg.DataSource = Movimento.RelatorioConsumoGrupoMercado(radMesAtual.Checked ? "1" : "3");
        }

        private void tsHac_AfterPesquisar(object sender)
        {
            tsHac.Items["tsBtnPesquisar"].Enabled = true;
        }

        private void FrmRelConsumoGrupoMercado_Load(object sender, EventArgs e)
        {
            
            if (!gen.LogadoSetorFarmacia())
            {
                MessageBox.Show("Acesso permitido para usuário logado na Farmácia Central.","Gestão de Materiais e Medicamentos", MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.BeginInvoke(new MethodInvoker(this.Close));
            }
        }
    }
}