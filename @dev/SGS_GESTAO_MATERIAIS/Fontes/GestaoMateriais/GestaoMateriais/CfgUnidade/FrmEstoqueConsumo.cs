using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Componentes;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmEstoqueConsumo : FrmBase
    {

        decimal _IdtUnidade;
        decimal _IdtLocal;
        decimal _IdtSetor;
        public FrmEstoqueConsumo()
        {
            InitializeComponent();
        }

        public FrmEstoqueConsumo(decimal IdtUnidade, decimal IdtLocal, decimal IdtSetor)
        {
            _IdtUnidade = IdtUnidade;
            _IdtLocal = IdtLocal;
            _IdtSetor = IdtSetor;

            InitializeComponent();
        }

        #region OBJETOS SERVIÇOS

   
        private SetorEstoqueConsumoDataTable dtbEstoqueConsumo;
        private IMatMedSetorConfig _matMedConfig;
        private IMatMedSetorConfig MatMedSetorConfig
        {
            get { return _matMedConfig != null ? _matMedConfig : _matMedConfig = (IMatMedSetorConfig)Global.Common.GetObject(typeof(IMatMedSetorConfig)); }
        }

       #endregion

        private void ConfiguraCombos()
        {
            // cmbUnidade.SelectedValue = FrmPrincipal.dtoSeguranca.IdtUnidade.Value;
            // cmbLocal.SelectedValue = FrmPrincipal.dtoSeguranca.IdtLocal.Value;
            // cmbSetor.SelectedValue = FrmPrincipal.dtoSeguranca.IdtSetor.Value;

            cmbUnidade.SelectedValue = _IdtUnidade;
            cmbLocal.SelectedValue =  _IdtLocal;
            cmbSetor.SelectedValue = _IdtSetor;
            cmbUnidade.Enabled = false;
            cmbLocal.Enabled = false;
            cmbSetor.Enabled = false;
        }

        private void ConfiguraSetorDTG()
        {
            dtgEstoqueConsumo.AutoGenerateColumns = false;
            dtgEstoqueConsumo.Columns["colIdtUnidade"].DataPropertyName = SetorEstoqueConsumoDTO.FieldNames.IdtUnidadeConsumo;
            dtgEstoqueConsumo.Columns["colDsUnidade"].DataPropertyName = SetorEstoqueConsumoDTO.FieldNames.DsUnidadeConsumo;
            dtgEstoqueConsumo.Columns["colIdtLocal"].DataPropertyName = SetorEstoqueConsumoDTO.FieldNames.IdtLocalConsumo;
            dtgEstoqueConsumo.Columns["colDsLocal"].DataPropertyName = SetorEstoqueConsumoDTO.FieldNames.DsLocalConsumo;
            dtgEstoqueConsumo.Columns["colIdtSetor"].DataPropertyName = SetorEstoqueConsumoDTO.FieldNames.IdtSetorConsumo;
            dtgEstoqueConsumo.Columns["colDsSetor"].DataPropertyName = SetorEstoqueConsumoDTO.FieldNames.DsSetorConsumo;
            dtgEstoqueConsumo.Columns["colIdtFilial"].DataPropertyName = SetorEstoqueConsumoDTO.FieldNames.IdtFilial;
            dtgEstoqueConsumo.Columns["colDsFilial"].DataPropertyName = SetorEstoqueConsumoDTO.FieldNames.DsFilial;
        }

        private void CarregaEstoqueConsumo()
        {
            SetorEstoqueConsumoDTO dtoConsumo = new SetorEstoqueConsumoDTO();
            dtoConsumo.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoConsumo.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoConsumo.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtbEstoqueConsumo = MatMedSetorConfig.SetorEstoqueConsumoObter(dtoConsumo);
            dtgEstoqueConsumo.DataSource = dtbEstoqueConsumo;
        }

        private void FrmEstoqueConsumo_Load(object sender, EventArgs e)
        {
            cmbUnidade.Carregaunidade();
            ConfiguraSetorDTG();
            ConfiguraCombos();
            CarregaEstoqueConsumo();

        }

        private bool hacToolStrip1_NovoClick(object sender)
        {
            SetorEstoqueConsumoDTO dtoConsumo = new SetorEstoqueConsumoDTO();

            dtoConsumo = FrmAddSetorConsumo.SelecionarSetor();
            if (dtoConsumo != null)
            {
                dtoConsumo.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                dtoConsumo.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                dtoConsumo.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                MatMedSetorConfig.SetorEstoqueConsumoSalvar(dtoConsumo);
                CarregaEstoqueConsumo();
            }

            return true;
        }

        private void dtgEstoqueConsumo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgEstoqueConsumo.Columns[e.ColumnIndex].Name == "colDeletarConsumo")
            {
                if (MessageBox.Show("Deseja excluir esta unidade da lista ?",
                                     "Gestão de Materiais e Medicamentos",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SetorEstoqueConsumoDTO dto = new SetorEstoqueConsumoDTO();
                    dto.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                    dto.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                    dto.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                    dto.IdtFilial.Value = dtgEstoqueConsumo.Rows[e.RowIndex].Cells["colIdtFilial"].Value.ToString();
                    MatMedSetorConfig.SetorEstoqueConsumoExcluir(dto);
                    CarregaEstoqueConsumo();
                }
            }
        }
    }
}