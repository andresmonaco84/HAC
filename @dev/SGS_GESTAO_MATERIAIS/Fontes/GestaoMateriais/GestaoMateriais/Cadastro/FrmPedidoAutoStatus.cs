using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Cadastro
{
    public partial class FrmPedidoAutoStatus : FrmBase
    {
        private IMatMedSetorConfig _matMedConfig;
        private IMatMedSetorConfig MatMedSetorConfig
        {
            get { return _matMedConfig != null ? _matMedConfig : _matMedConfig = (IMatMedSetorConfig)Global.Common.GetObject(typeof(IMatMedSetorConfig)); }
        }

        public FrmPedidoAutoStatus()
        {
            InitializeComponent();
        }

        public void Visualizar()
        {            
            this.chkEmExecucao.Checked = MatMedSetorConfig.GerandoPedidosAutomaticosFarmacia();
            this.txtUltimoProc.Text = MatMedSetorConfig.DataUltimaGeracaoPedidosAutomaticosFarmacia().ToString();            

            this.ShowDialog();
        }

        private bool tsHac_SalvarClick(object sender)
        {
            if (chkEmExecucao.Checked)
            {
                MessageBox.Show("Permitido apenas parar o processo por esta funcionalidade.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            MatMedSetorConfig.GerarPedidosAutomaticosFarmacia(chkEmExecucao.Checked, false);
            MessageBox.Show("Status de processo atualizado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return default(bool);
        }

        private void chkEmExecucao_Click(object sender, EventArgs e)
        {
            if (chkEmExecucao.Checked) chkEmExecucao.Checked = false;
        }

        private void FrmPedidoAutoStatus_Load(object sender, EventArgs e) {}   
    }
}