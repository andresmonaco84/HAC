using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using Hac.Windows.Forms;

namespace Hac.Windows.Forms.Controls.Forms
{
    public partial class FrmPesquisaProfissionalSolicitante : FrmBase
    {
        public FrmPesquisaProfissionalSolicitante()
        {
            InitializeComponent();

            Titulo = "Pesquisar Profissional";
        }

        private ProfissionalSolicitanteDataTable dtbProfissionalSolicitante;

        public ProfissionalSolicitanteDataTable DtbProfissionalSolicitante
        {
            get { return dtbProfissionalSolicitante; }
            set { dtbProfissionalSolicitante = value; }
        }

        private ProfissionalSolicitanteDTO dtoProfissionalSolicitante;

        private void FrmPesquisaProfissionalSolicitante_Load(object sender, EventArgs e)
        {
            dgvPesquisaProfissinalSolicitante.AutoGenerateColumns = false;
            dgvPesquisaProfissinalSolicitante.Columns["TipoConselho"].DataPropertyName = ProfissionalSolicitanteDTO.FieldNames.TipoConselho;
            dgvPesquisaProfissinalSolicitante.Columns["UFConselho"].DataPropertyName = ProfissionalSolicitanteDTO.FieldNames.UFConselho;
            dgvPesquisaProfissinalSolicitante.Columns["CodigoConselho"].DataPropertyName = ProfissionalSolicitanteDTO.FieldNames.CodigoConselho;
            dgvPesquisaProfissinalSolicitante.Columns["NomeProfissional"].DataPropertyName = ProfissionalSolicitanteDTO.FieldNames.NomeProfissional;

            dgvPesquisaProfissinalSolicitante.DataSource = dtbProfissionalSolicitante;

            dgvPesquisaProfissinalSolicitante.Sort(NomeProfissional,ListSortDirection.Ascending);
        }

        public static ProfissionalSolicitanteDTO AbrirPesquisaProfissionalSolicitante
                        (ProfissionalSolicitanteDataTable dtbProfissionalSolicitante,
                        ProfissionalSolicitanteDTO _dtoProfissionalSolicitante)
        {
            FrmPesquisaProfissionalSolicitante frmPesquisa = new FrmPesquisaProfissionalSolicitante();
            frmPesquisa.DtbProfissionalSolicitante = dtbProfissionalSolicitante;
            frmPesquisa.dtoProfissionalSolicitante = _dtoProfissionalSolicitante;
            frmPesquisa.ShowDialog();
            return frmPesquisa.dtoProfissionalSolicitante;
        }

        private void dgvPesquisaProfissinalSolicitante_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dtoProfissionalSolicitante = (ProfissionalSolicitanteDTO)((DataRowView)dgvPesquisaProfissinalSolicitante.Rows[e.RowIndex].DataBoundItem).Row;
                this.Close();   
            }
        }

        private void txtNomeProfissionalSolicitante_TextChanged(object sender, EventArgs e)
        {
            //if (txtNomeProfissionalSolicitante.Text.ToString() == string.Empty)
            //    dtbProfissionalSolicitante.DefaultView.RowFilter = null;
            //else
            //    dtbProfissionalSolicitante.DefaultView.RowFilter = String.Format("{0} LIKE '%{1}%'", 
            //            ProfissionalSolicitanteDTO.FieldNames.NomeProfissional, txtNomeProfissionalSolicitante.Text.ToString());
        }

        private void btnPesquisarProfissionalSolicitante_Click(object sender, EventArgs e)
        {
            if (txtNomeProfissionalSolicitante.Text.Replace("%", "").Replace(" ", "").Length >= 3)
            {
                DtbProfissionalSolicitante =
                       PesquisarProfissionalSolicitante(dtoProfissionalSolicitante.UFConselho.Value,
                           dtoProfissionalSolicitante.TipoConselho.Value,
                           null,
                           txtNomeProfissionalSolicitante.Text);

                dgvPesquisaProfissinalSolicitante.DataSource = DtbProfissionalSolicitante;
            }
            else
            {
                MessageBox.Show("Informe pelo menos 3 caracteres.", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private ProfissionalSolicitanteDataTable PesquisarProfissionalSolicitante(string ufConselho, string tipoConselho, string codigoConselho, string nome)
        {
            try
            {
                ProfissionalSolicitanteDTO dtoProfissionalSolicitante = new ProfissionalSolicitanteDTO();
                dtoProfissionalSolicitante.UFConselho.Value = ufConselho;
                dtoProfissionalSolicitante.TipoConselho.Value = tipoConselho;
                if (codigoConselho != null) dtoProfissionalSolicitante.CodigoConselho.Value = codigoConselho;
                dtoProfissionalSolicitante.FlAtivoOk.Value = "S";
                if (nome != null) dtoProfissionalSolicitante.NomeProfissional.Value = "%" + nome + "%";

                return ProfissionalSolicitante.Listar(dtoProfissionalSolicitante);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}