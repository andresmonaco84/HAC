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
using HospitalAnaCosta.SGS.GestaoMateriais.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmAdicionarMedKit : FrmBase
    {
        #region OBJETOS SERVIÇOS

        private KitDTO _dtoKitSelecionado;
        private IKit _kit;
        private IKit Kit
        {
            get { return _kit != null ? _kit : _kit = (IKit)Global.Common.GetObject(typeof(IKit)); }
        }

        #endregion

        public FrmAdicionarMedKit()
        {
            InitializeComponent();
        }

        public static void AssociarMedicamentoAplicacao(KitDTO dtoKitSelecionado)
        {
            FrmAdicionarMedKit frm = new FrmAdicionarMedKit();
            frm._dtoKitSelecionado = dtoKitSelecionado;            
            frm.ShowDialog();
        }        

        private void FrmAdicionarMedKit_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            lblKitDsc.Text = _dtoKitSelecionado.Descricao.Value;
            KitDataTable dtbMed = Kit.ListarMedicamentosAssociadosAplicaKit(_dtoKitSelecionado);
            dtgItem.AutoGenerateColumns = false;
            dtgItem.DataSource = dtbMed;
            dtgItem.ClearSelection();
            tsHac.Items["tsBtnMatMed"].Enabled = true;
            this.Cursor = Cursors.Default;
        }

        private bool tsHac_MatMedClick(object sender)
        {
            MaterialMedicamentoDTO dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(new MaterialMedicamentoDTO());
            
            if (dtoMatMed != null)
            {
                if ((int)dtoMatMed.IdtGrupo.Value != 1)
                {
                    dtoMatMed = null;
                    MessageBox.Show("Permitido adicionar apenas medicamentos!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                this.Cursor = Cursors.WaitCursor;
                KitDTO dtoItemKit = new KitDTO();
                dtoItemKit.IdKit.Value = _dtoKitSelecionado.IdKit.Value;
                dtoItemKit.IdProduto.Value = dtoMatMed.Idt.Value;

                Kit.InsMedicamentoAssociadoAplicaKit(dtoItemKit, (int)FrmPrincipal.dtoSeguranca.Idt.Value);

                dtgItem.DataSource = Kit.ListarMedicamentosAssociadosAplicaKit(_dtoKitSelecionado);
                dtgItem.ClearSelection();
                this.Cursor = Cursors.Default;
            }
            return true;
        }

        private void dtgItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgItem.Columns[e.ColumnIndex].Name == colDeletar.Name)
            {
                if (MessageBox.Show("Deseja excluir a associação do medicamento para este kit ?", "Gestão de Materiais e Medicamentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    KitDTO dtoItemKit = new KitDTO();
                    dtoItemKit.IdKit.Value = _dtoKitSelecionado.IdKit.Value;
                    dtoItemKit.IdProduto.Value = dtgItem.Rows[e.RowIndex].Cells[colIdProduto.Name].Value.ToString();

                    Kit.ExcluirMedicamentoAssociadoAplicaKit(dtoItemKit, (int)FrmPrincipal.dtoSeguranca.Idt.Value);

                    dtgItem.DataSource = Kit.ListarMedicamentosAssociadosAplicaKit(_dtoKitSelecionado);
                    dtgItem.ClearSelection();
                    this.Cursor = Cursors.Default;
                }
            }
        }
    }
}