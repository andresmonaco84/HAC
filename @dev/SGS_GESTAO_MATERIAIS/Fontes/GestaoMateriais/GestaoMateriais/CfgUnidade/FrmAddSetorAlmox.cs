using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.Componentes;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmAddSetorAlmox : FrmBase
    {
        public FrmAddSetorAlmox()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇOS

        private static SetorDTO dtoSetor;

        #endregion

        private void FrmAddSetorAlmox_Load(object sender, EventArgs e)
        {
            dtoSetor = null;
            cmbUnidade.Carregaunidade();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cmbUnidade.SelectedIndex == -1 || cmbLocal.SelectedIndex == -1 || cmbSetor.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione Unidade/Local/Setor antes de confirmar", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            dtoSetor = new SetorDTO();

            dtoSetor.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoSetor.DsUnidade.Value = cmbUnidade.Text;

            dtoSetor.IdtLocalAtendimento.Value = cmbLocal.SelectedValue.ToString();
            dtoSetor.DsLocal.Value = cmbLocal.Text;

            dtoSetor.Idt.Value = cmbSetor.SelectedValue.ToString();
            dtoSetor.Descricao.Value = cmbSetor.Text;

            this.Close();
        }
        
        public static SetorDTO SelecionarSetor()
        {
            FrmAddSetorAlmox frmAddSetorAlmox = new FrmAddSetorAlmox();
            frmAddSetorAlmox.ShowDialog();
            return dtoSetor;
        }
    }
}