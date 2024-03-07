/*
 * Cadastro de Estoque compartilhado
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.Componentes;
using HacFramework.Windows.Helpers;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmAddSetorConsumo : FrmBase
    {
        public FrmAddSetorConsumo()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇOS

        private SetorEstoqueConsumoDTO dtoSetor;

        #endregion

        private void FrmAddSetorAlmox_Load(object sender, EventArgs e)
        {
            dtoSetor = null;
            cmbUnidade.Carregaunidade();
            CarregaFilial(cmbFilial);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cmbUnidade.SelectedIndex == -1 || cmbLocal.SelectedIndex == -1 || cmbSetor.SelectedIndex == -1 || cmbFilial.SelectedIndex == -1 )
            {
                MessageBox.Show("Selecione Unidade/Local/Setor antes de confirmar", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            dtoSetor = new SetorEstoqueConsumoDTO();

            dtoSetor.IdtUnidadeConsumo.Value = cmbUnidade.SelectedValue.ToString();
            dtoSetor.DsUnidadeConsumo.Value = cmbUnidade.Text;

            dtoSetor.IdtLocalConsumo.Value = cmbLocal.SelectedValue.ToString();
            dtoSetor.DsLocalConsumo.Value = cmbLocal.Text;

            dtoSetor.IdtSetorConsumo.Value = cmbSetor.SelectedValue.ToString();
            dtoSetor.DsSetorConsumo.Value = cmbSetor.Text;

            dtoSetor.IdtFilial.Value = cmbFilial.SelectedValue.ToString();
            dtoSetor.DsFilial.Value = cmbFilial.Text;

            this.Close();
        }

        public static SetorEstoqueConsumoDTO SelecionarSetor()
        {

            FrmAddSetorConsumo frmAddSetorConsumo = new FrmAddSetorConsumo();
            frmAddSetorConsumo.ShowDialog();


            return frmAddSetorConsumo.dtoSetor;
        }


        protected void CarregaFilial(ComboBox cbo)
        {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Selecione>"));
            // list.Add(new ListItem("0", "PERSONALISADA"));
            list.Add(new ListItem("1", "HAC"));
            list.Add(new ListItem("2", "ACS"));
            // list.Add(new ListItem("3", "PENDENTES"));
            list.Add(new ListItem("4", "C.E."));


            cbo.ValueMember = ListItem.FieldNames.Key;
            cbo.DisplayMember = ListItem.FieldNames.Value;
            cbo.DataSource = list;
            cbo.SelectedValue = "-1";

        }

    }
}