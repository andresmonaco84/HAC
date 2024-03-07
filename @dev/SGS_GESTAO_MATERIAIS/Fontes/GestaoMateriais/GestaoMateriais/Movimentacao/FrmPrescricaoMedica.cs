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

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmPrescricaoMedica : FrmBase
    {
        private IMaterialMedicamento _matMed;
        protected IMaterialMedicamento matMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject( typeof(IMaterialMedicamento)); }
        }
        private MaterialMedicamentoDataTable dtbMatMed;
        public FrmPrescricaoMedica()
        {
            InitializeComponent();
        }

        private void hacTextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void hacButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPrescricaoMedica_Shown(object sender, EventArgs e)
        {
            MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();
            //dtoMatMed.FlAtivo.Value = 0;
            
            // dtoMatMed.IdtSubGrupo.Value = 2;
            
            // dtbMatMed = matMed.Sel(dtoMatMed);
            // dtgPrescricao.DataSource = dtbMatMed;
        }

        private void hacButton9_Click(object sender, EventArgs e)
        {            
            // DataTable dtbTeste = HacService.ListarMedicos(0, "", "Bruno%");

        }
    }
}

