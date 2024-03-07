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

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmGrupoMatMed : FrmBase
    {

        private IGrupoMatMed grupomatmed;
        public IGrupoMatMed Grupo
        {
            get { return grupomatmed != null ? grupomatmed : grupomatmed = (IGrupoMatMed)Global.Common.GetObject( typeof(IGrupoMatMed)); }
        }
        public GrupoMatMedDataTable GrupoDTBL;
        public GrupoMatMedDTO GrupoDTO;

        private ISubGrupoMatMed subgrupo;
        public ISubGrupoMatMed SubGrupo
        {
            get { return subgrupo != null ? subgrupo : subgrupo = (ISubGrupoMatMed)Global.Common.GetObject(typeof(ISubGrupoMatMed)); }
        }
        public SubGrupoMatMedDataTable SubGrupoDTBL;
        public SubGrupoMatMedDTO SubGrupoDTO;

        private IMaterialMedicamento matmed;
        public IMaterialMedicamento MatMed
        {
            get { return matmed != null ? matmed : matmed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }
        public MaterialMedicamentoDataTable MatMedDTBL;
        public MaterialMedicamentoDTO MatMedDTO;

        public FrmGrupoMatMed()
        {
            InitializeComponent();
        }        

        #region FUNÇÕES

        private void CfgSubGrupo()
        {
            dtgSubGrupo.AutoGenerateColumns = false;
            dtgSubGrupo.Columns["colDsSubGrupo"].DataPropertyName = SubGrupoMatMedDTO.FieldNames.DsSubGrupo;
            dtgSubGrupo.Columns["colSubGrupoIdt"].DataPropertyName = SubGrupoMatMedDTO.FieldNames.Idt;            
        }

        private void CfgMaterial()
        {
            dtgMatMed.AutoGenerateColumns = false;
            dtgMatMed.Columns["colDsMatMed"].DataPropertyName = MaterialMedicamentoDTO.FieldNames.NomeFantasia;
            dtgMatMed.Columns["colMatMedIdt"].DataPropertyName = MaterialMedicamentoDTO.FieldNames.Idt;            
        }

        private void CfgGrupo()
        {
            dtgGrupo.AutoGenerateColumns = false;
            dtgGrupo.Columns["colGrupoIdt"].DataPropertyName = GrupoMatMedDTO.FieldNames.Idt;
            dtgGrupo.Columns["colDsGrupo"].DataPropertyName = GrupoMatMedDTO.FieldNames.DsGrupo;            
        }
        
        private void CarregaGrupo()
        {
            CfgGrupo();
            GrupoDTBL = new GrupoMatMedDataTable();
            GrupoDTBL = Grupo.Sel(new GrupoMatMedDTO());
            dtgGrupo.DataSource = GrupoDTBL;
        }

        private void CarregaSubGrupo( )
        {
            CfgSubGrupo();
            SubGrupoDTBL = new SubGrupoMatMedDataTable();
            SubGrupoDTBL = SubGrupo.Sel(SubGrupoDTO);
            dtgSubGrupo.DataSource = SubGrupoDTBL;
        }

        #endregion

        private void FrmGrupoMatMed_Load(object sender, EventArgs e)
        {
            CarregaGrupo();
        }

        private void dtgGrupo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SubGrupoDTO = new SubGrupoMatMedDTO();
            SubGrupoDTO.IdtGrupo.Value = dtgGrupo.Rows[e.RowIndex].Cells["colGrupoIdt"].Value.ToString();
            CarregaSubGrupo();

            txtGrupo.Text = dtgGrupo.Rows[e.RowIndex].Cells["colDsGrupo"].Value.ToString();
            txtSubGrupo.Text = string.Empty;
            MatMedDTBL = null;
            dtgMatMed.DataSource = null;            
        }        

        private void dtgGrupo_SelectionChanged(object sender, EventArgs e)
        {
            SubGrupoDTO = new SubGrupoMatMedDTO();
            SubGrupoDTBL = new SubGrupoMatMedDataTable();
            dtgSubGrupo.DataSource = null;           
        }

        private void dtgSubGrupo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MatMedDTBL = new MaterialMedicamentoDataTable();
            MatMedDTO = new MaterialMedicamentoDTO();
            CfgMaterial();
            MatMedDTO.IdtGrupo.Value = dtgGrupo.Rows[dtgGrupo.CurrentRow.Index].Cells["colGrupoIdt"].Value.ToString();
            // MatMedDTO.IdtGrupo.Value = dtgGrupo.Rows[e.RowIndex].Cells["colGrupoIdt"].Value.ToString();
            MatMedDTO.IdtSubGrupo.Value = dtgSubGrupo.Rows[e.RowIndex].Cells["colSubGrupoIdt"].Value.ToString();
            MatMedDTBL = MatMed.Sel( MatMedDTO );
            dtgMatMed.DataSource = MatMedDTBL;
            tabPrincipal.SelectedTab = tabMatMed;            
            txtSubGrupo.Text = dtgSubGrupo.Rows[e.RowIndex].Cells["colDsSubGrupo"].Value.ToString();
        }        
    }
}