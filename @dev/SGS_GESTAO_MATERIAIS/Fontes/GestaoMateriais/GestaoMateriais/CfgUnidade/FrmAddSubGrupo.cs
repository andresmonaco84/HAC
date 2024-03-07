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
    public partial class FrmAddSubGrupo : FrmBase
    {
        public FrmAddSubGrupo()
        {
            InitializeComponent();
        }

        public SubGrupoMatMedDTO dtoSubGrupo;        
        private ISubGrupoMatMed _subgrupo;
        public ISubGrupoMatMed SubGrupo
        {
            get { return _subgrupo != null ? _subgrupo : _subgrupo = (ISubGrupoMatMed)Global.Common.GetObject( typeof(ISubGrupoMatMed)); }
        }

        MatMedSetorConfigDataTable dtbMatMedSetor;
        MatMedSetorConfigDTO dtoMatMedSetor;

        private void FrmAddSubGrupo_Load(object sender, EventArgs e)
        {
            if (dtbMatMedSetor != null)
            {
                // Seleciona os itens
                foreach (DataGridViewRow dtgRow in dtgSubGrupo.Rows)
                {
                    if (dtbMatMedSetor.Select(string.Format("{0} = {1} AND {2} = {3}",
                        MatMedSetorConfigDTO.FieldNames.IdtSubGrupo, 
                        dtgRow.Cells["colSubGrupoIdt"].Value,
                        MatMedSetorConfigDTO.FieldNames.IdtGrupo,
                        dtgRow.Cells["colGrupoIdt"].Value), string.Empty).Length > 0)
                    {
                        dtgRow.Cells["colCheck"].Value = true;
                    }
                }
            }
            else
            {
                dtbMatMedSetor = new MatMedSetorConfigDataTable();
            }    
        }

        private void chkSelTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dtgRow in dtgSubGrupo.Rows)
            {
                dtgRow.Cells["colCheck"].Value = chkSelTodos.Checked;
            }            
        } 

        private void btnOk_Click(object sender, EventArgs e)
        {
            dtbMatMedSetor = new MatMedSetorConfigDataTable();
            foreach (DataGridViewRow dtgRow in dtgSubGrupo.Rows)
            {
                if (bool.Parse(dtgRow.Cells["colCheck"].EditedFormattedValue.ToString()))
                {
                    dtoMatMedSetor = new MatMedSetorConfigDTO();

                    dtoMatMedSetor.IdtGrupo.Value = dtgRow.Cells["colGrupoIdt"].Value.ToString();
                    dtoMatMedSetor.IdtSubGrupo.Value = dtgRow.Cells["colSubGrupoIdt"].Value.ToString();
                    dtoMatMedSetor.DsGrupo.Value = dtgRow.Cells["colDsGrupo"].Value.ToString();
                    dtoMatMedSetor.DsSubGrupo.Value = dtgRow.Cells["colDsSubGrupo"].Value.ToString();
                    
                    dtbMatMedSetor.Add(dtoMatMedSetor);
                }                
            }
            this.Close();
        }

        private void CfgSubGrupo()
        {
            dtgSubGrupo.AutoGenerateColumns = false;
            dtgSubGrupo.Columns["colGrupoIdt"].DataPropertyName = SubGrupoMatMedDTO.FieldNames.IdtGrupo;
            dtgSubGrupo.Columns["colDsGrupo"].DataPropertyName = SubGrupoMatMedDTO.FieldNames.DsGrupo;
            dtgSubGrupo.Columns["colDsSubGrupo"].DataPropertyName = SubGrupoMatMedDTO.FieldNames.DsSubGrupo;
            dtgSubGrupo.Columns["colSubGrupoIdt"].DataPropertyName = SubGrupoMatMedDTO.FieldNames.Idt;
        }

        public MatMedSetorConfigDataTable SelecionarSubGrupos(MatMedSetorConfigDataTable dtbMatMedSetorConfig)
        {
            CfgSubGrupo();           
            dtgSubGrupo.DataSource = SubGrupo.Sel(new SubGrupoMatMedDTO());

            dtbMatMedSetor = dtbMatMedSetorConfig;
            this.ShowDialog();

            return dtbMatMedSetor;
        }

        private void dtgSubGrupo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                SubGrupoMatMedDTO dtoSubGrupo = new SubGrupoMatMedDTO();
                dtoSubGrupo.Idt.Value = Convert.ToDecimal(dtgSubGrupo.Rows[e.RowIndex].Cells["colSubGrupoIdt"].Value.ToString());
                dtoSubGrupo.IdtGrupo.Value = Convert.ToDecimal(dtgSubGrupo.Rows[e.RowIndex].Cells["colGrupoIdt"].Value.ToString());
                dtoSubGrupo.DsSubGrupo.Value = dtgSubGrupo.Rows[e.RowIndex].Cells["colDsSubGrupo"].Value.ToString();
                dtoSubGrupo.DsGrupo.Value = dtgSubGrupo.Rows[e.RowIndex].Cells["colDsGrupo"].Value.ToString();
                FrmGrupos frmSubGrupo = new FrmGrupos();
                frmSubGrupo.MostraSubgrupos(dtoSubGrupo);
            }
        }                    
    }
}