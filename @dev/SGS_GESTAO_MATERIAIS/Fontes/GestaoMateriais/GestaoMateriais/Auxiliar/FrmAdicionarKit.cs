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

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmAdicionarKit : FrmBase
    {
        #region OBJETOS SERVIÇOS

        private bool _remover = false;

        private KitDTO _dtoKitSelecionado;
        private KitDataTable _dtbKitItensRetorno;
        private KitDataTable _dtbKitItens;
        private IKit _kit;
        private IKit Kit
        {
            get { return _kit != null ? _kit : _kit = (IKit)Global.Common.GetObject(typeof(IKit)); }
        }

        #endregion

        public static KitDataTable SelecionarKit(KitDTO dtoKitSelecionado, out bool remover, ref int qtdMultiplica)
        {
            FrmAdicionarKit frm = new FrmAdicionarKit();
            frm._dtoKitSelecionado = dtoKitSelecionado;
            frm.txtQtdeMultiplica.Text = qtdMultiplica.ToString();
            frm.ShowDialog();
            remover = frm._remover;
            qtdMultiplica = int.Parse(frm.txtQtdeMultiplica.Text);
            return frm._dtbKitItensRetorno;
        }

        public FrmAdicionarKit()
        {
            InitializeComponent();
        }

        private void CarregarComboKit()
        {
            this.Cursor = Cursors.WaitCursor;
            KitDTO dto = new KitDTO();
            dto.Ativo.Value = 1;
            cmbKit.DataSource = Kit.Listar(dto);
            cmbKit.IniciaLista();
            this.Cursor = Cursors.Default;
        }

        private void CarregarKitItens()
        {
            this.Cursor = Cursors.WaitCursor;

            KitDTO dto = new KitDTO();            
            dto.IdKit.Value = cmbKit.SelectedValue.ToString();
            _dtbKitItens = Kit.ListarItem(dto);
            dtgItem.DataSource = _dtbKitItens;
            dtgItem.ClearSelection();
            //dtgItem.Enabled = false;

            this.Cursor = Cursors.Default;
        }

        private void FrmAdicionarKit_Load(object sender, EventArgs e)
        {            
            dtgItem.AutoGenerateColumns = false;
            CarregarComboKit();
            if (_dtoKitSelecionado != null && !_dtoKitSelecionado.IdKit.Value.IsNull)
            {
                cmbKit.SelectedValue = _dtoKitSelecionado.IdKit.Value;
                CarregarKitItens();
                btnRemover.Enabled = true;
                btnOk.Enabled = cmbKit.Enabled = txtQtdeMultiplica.Enabled = false;
            }
        }

        private void cmbKit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbKit.SelectedIndex > -1)
            {
                CarregarKitItens();
            }
            else
                dtgItem.DataSource = null;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtQtdeMultiplica.Text == string.Empty || int.Parse(txtQtdeMultiplica.Text) <= 0)            
            {
                MessageBox.Show("Qtde. Multiplicar deve ser maior que 0", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQtdeMultiplica.Focus();
                return;
            }
            _dtbKitItensRetorno = _dtbKitItens;
            Close();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            _dtbKitItensRetorno = _dtbKitItens;
            _remover = true;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _dtbKitItensRetorno = _dtbKitItens = null;
            Close();
        }
    }
}