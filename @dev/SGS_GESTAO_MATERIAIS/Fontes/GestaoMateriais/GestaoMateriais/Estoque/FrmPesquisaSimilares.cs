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
using HospitalAnaCosta.SGS.GestaoMateriais;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    public partial class FrmPesquisaSimilares : FrmBase
    {
        private IMatMedSimilar _similar;
        private IMatMedSimilar Similar
        {
            get { return _similar != null ? _similar : _similar = (IMatMedSimilar)Global.Common.GetObject(typeof(IMatMedSimilar)); }
        }

        private MaterialMedicamentoDTO _dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }   

        public FrmPesquisaSimilares()
        {
            InitializeComponent();           
        }

        public MaterialMedicamentoDTO VisualizarSimilares(MaterialMedicamentoDTO dtoMatMed)
        {
            MatMedSimilarDTO dtoSimilar = new MatMedSimilarDTO();

            if (dtoMatMed.IdtPrincipioAtivo.Value.IsNull) dtoMatMed = MatMed.SelChave(dtoMatMed);

            dtoSimilar.IdPrincipioAtivo.Value = dtoMatMed.IdtPrincipioAtivo.Value;
            dtoSimilar.IdProduto.Value = dtoMatMed.Idt.Value;
            dtoSimilar.FlAtivo.Value = (byte)MatMedSimilarDTO.Ativo.SIM;

            lblMatMed.Text = dtoMatMed.NomeFantasia.ToString();

            dtgMatMed.AutoGenerateColumns = false;
            dtgMatMed.Columns[colIdt.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.Idt;
            dtgMatMed.Columns[colDescricao.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.NomeFantasia;
            dtgMatMed.DataSource = Similar.ListarSimilares(dtoSimilar, null);

            _dtoMatMed = dtoMatMed;

            this.ShowDialog();

            return _dtoMatMed;
        }

        private void dtgMatMed_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > 0)
            {
                _dtoMatMed = new MaterialMedicamentoDTO();
                _dtoMatMed.Idt.Value = dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value.ToString();
                _dtoMatMed = MatMed.SelChave(_dtoMatMed);
                this.Close();
            }
        }        
    }
}