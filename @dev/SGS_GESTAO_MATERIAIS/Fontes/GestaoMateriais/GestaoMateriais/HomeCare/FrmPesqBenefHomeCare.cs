using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.Services.BeneficiarioACS.DTO;
using HospitalAnaCosta.Services.BeneficiarioACS.Interface;
using HospitalAnaCosta.Services.BeneficiarioACS.View;
using HospitalAnaCosta.SGS.Componentes;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmPesqBenefHomeCare : FrmBase
    {
        public FrmPesqBenefHomeCare()
        {
            InitializeComponent();
        }

        #region SERVIÇOS

        private CommonBeneficiarioACS _commonBnfACS;
        private CommonBeneficiarioACS CommonBnfACS
        {
            get { return _commonBnfACS != null ? _commonBnfACS : _commonBnfACS = new CommonBeneficiarioACS(null); }
        }
        private BenefHomeCareDTO dtoBeneficiario;
        private IBenefHomeCare _beneficiario;
        private IBenefHomeCare Beneficiario
        {
            get { return _beneficiario != null ? _beneficiario : _beneficiario = (IBenefHomeCare)CommonBnfACS.GetObject(typeof(IBenefHomeCare)); }
            
        }

        #endregion
        public static BenefHomeCareDTO BuscaBeneficiarioHomeCare()
        {
            FrmPesqBenefHomeCare frmPesqBenef = new FrmPesqBenefHomeCare();
            //
            frmPesqBenef.ShowDialog();
            return frmPesqBenef.dtoBeneficiario;
        }

        private void ConfiguraDtgBnf()
        {
            dtgBeneficiario.AutoGenerateColumns = false;
            dtgBeneficiario.Columns["colCdPlano"].DataPropertyName = BenefHomeCareDTO.FieldNames.CodigoPlano;
            dtgBeneficiario.Columns["colIdtHomeCare"].DataPropertyName = BenefHomeCareDTO.FieldNames.CodigoHomeCare;
            dtgBeneficiario.Columns["colNmBeneficiario"].DataPropertyName = BenefHomeCareDTO.FieldNames.NomeBeneficiario;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (txtNomBenef.Text != string.Empty)
            {
                dtoBeneficiario = new BenefHomeCareDTO();
                dtoBeneficiario.NomeBeneficiario.Value = txtNomBenef.Text;
                dtoBeneficiario.FlAtivo.Value = (byte)BenefHomeCareDTO.Ativo.SIM;
                ConfiguraDtgBnf();
                dtgBeneficiario.DataSource = Beneficiario.Sel(dtoBeneficiario);                
                if (((BenefHomeCareDataTable)dtgBeneficiario.DataSource).Rows.Count == 0)                
                {
                    MessageBox.Show("Não foi encontrado nenhum beneficiário em internação domiciliar", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNomBenef.Focus();
                }
            }
        }

        private void dtgBeneficiario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dtoBeneficiario = new BenefHomeCareDTO();
            dtoBeneficiario.CodigoHomeCare.Value = Convert.ToDecimal(dtgBeneficiario.Rows[e.RowIndex].Cells["colIdtHomeCare"].Value.ToString());
            dtoBeneficiario = Beneficiario.SelChave(dtoBeneficiario);
            this.Close();
        }
    }
}