using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmTransfAtd : FrmBase
    {                
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }

        public FrmTransfAtd()
        {
            InitializeComponent();
        }        

        private void FrmTransfAtd_Load(object sender, EventArgs e)
        {            
            //tsHac.Items["tsBtnSalvar"].Enabled = true;
        }

        private bool tsHac_SalvarClick(object sender)
        {
            Movimento.TransferirAtendimento(decimal.Parse(txtAtdDE.Text), decimal.Parse(txtAtdPARA.Text));            
            MessageBox.Show("Transferência realizada com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtAtdDE.Text = txtAtdPARA.Text = string.Empty;
            txtAtdDE.Focus();
            return true;
        }
    }
}