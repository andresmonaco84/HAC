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

namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    public partial class FrmEnderecoAlmoxarifado : FrmBase
    {
        private decimal _idProduto;

        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }   

        public FrmEnderecoAlmoxarifado()
        {
            //testandooooo
            InitializeComponent();
        }

        public void Visualizar(decimal idProduto)
        {
            _idProduto = idProduto;

            MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();
            dtoMatMed.Idt.Value = _idProduto;
            DataTable dtbMatMed = MatMed.SelEnderecos(_idProduto);

            txtEndAlmoxHAC.Text = dtbMatMed.Rows[0]["CAD_MTMD_ENDERECO_ALMOX_HAC"].ToString();
            txtEndFarm.Text = dtbMatMed.Rows[0]["CAD_MTMD_ENDERECO_ALMOX_ACS"].ToString();

            this.ShowDialog();
            //testandooooo//testandooooo//testandooooo
        }        

        private void FrmEnderecoAlmoxarifado_Load(object sender, EventArgs e) {}        

        private bool tsHac_SalvarClick(object sender)
        {
            decimal? numEndHAC = null;
            if (!string.IsNullOrEmpty(txtEndAlmoxHAC.Text)) numEndHAC = decimal.Parse(txtEndAlmoxHAC.Text);
            decimal? numEndACS = null;
            if (!string.IsNullOrEmpty(txtEndFarm.Text)) numEndACS = decimal.Parse(txtEndFarm.Text);

            MatMed.AtualizarEnderecos(_idProduto, numEndHAC, numEndACS);
            MessageBox.Show("Endereço Salvo!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return default(bool);
        }
    }
}