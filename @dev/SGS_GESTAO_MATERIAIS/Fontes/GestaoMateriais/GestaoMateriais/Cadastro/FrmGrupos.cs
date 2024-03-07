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
    public partial class FrmGrupos : FrmBase
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

        public FrmGrupos()
        {
            InitializeComponent();
        }        

        #region FUNÇÕES


        private void CfgMaterial()
        {
            dtgMatMed.AutoGenerateColumns = false;
            dtgMatMed.Columns["colDsMatMed"].DataPropertyName = MaterialMedicamentoDTO.FieldNames.NomeFantasia;
            dtgMatMed.Columns["colMatMedIdt"].DataPropertyName = MaterialMedicamentoDTO.FieldNames.Idt;            
        }


        private void CarregaMaterial()
        {
            MatMedDTBL = new MaterialMedicamentoDataTable();
            MatMedDTO = new MaterialMedicamentoDTO();
            CfgMaterial();
            MatMedDTO.IdtGrupo.Value = SubGrupoDTO.IdtGrupo.Value;
            MatMedDTO.IdtSubGrupo.Value = SubGrupoDTO.Idt.Value;
            MatMedDTBL = MatMed.Sel(MatMedDTO);
            dtgMatMed.DataSource = MatMedDTBL;
            txtGrupo.Text = SubGrupoDTO.DsGrupo.Value;
            txtSubGrupo.Text = SubGrupoDTO.DsSubGrupo.Value;

        }

        #endregion

        private void FrmGrupoMatMed_Load(object sender, EventArgs e)
        {
            CarregaMaterial();
        }


        public void MostraSubgrupos(SubGrupoMatMedDTO dto)
        {
            this.SubGrupoDTO = dto;
            this.ShowDialog();
        }

    }
}