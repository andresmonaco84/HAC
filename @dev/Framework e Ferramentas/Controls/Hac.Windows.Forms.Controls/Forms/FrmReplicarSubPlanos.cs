using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.DTO;

namespace Hac.Windows.Forms.Controls.Forms
{

    public partial class FrmReplicarSubPlanos : FrmBase
    {
        /*
        public FrmReplicarSubPlanos()
        {
            InitializeComponent();

            Titulo = "Selecionar Sub-Planos";
        }
        
        private SubPlanoDataTable dtbSubPlano;
        public SubPlanoDataTable DtbSubPlano
        {
            get { return dtbSubPlano; }
            set { dtbSubPlano = value; }
        }

        private SubPlanoDataTable dtbSubPlanosSelecionados;
        public SubPlanoDataTable DtbSubPlanosSelecionados
        {
            get { return dtbSubPlanosSelecionados; }
            set { dtbSubPlanosSelecionados = value; }
        }    

        private void FrmReplicarSubPlanos_Load(object sender, EventArgs e)
        {
            dgvPesquisaSubPlano.AutoGenerateColumns = false;

            dgvPesquisaSubPlano.Columns["IdtSubPlano"].DataPropertyName = SubPlanoDTO.FieldNames.Idt;
            dgvPesquisaSubPlano.Columns["Codigo"].DataPropertyName = SubPlanoDTO.FieldNames.Codigo;
            dgvPesquisaSubPlano.Columns["Descricao"].DataPropertyName = SubPlanoDTO.FieldNames.Descricao;

            dtbSubPlano.Columns.Add("colSeleciona");
            dgvPesquisaSubPlano.Columns["colSeleciona"].DataPropertyName = "colSeleciona";

            foreach (DataRow row in dtbSubPlano.Rows)
            {
                if (dtbSubPlanosSelecionados.Select(string.Format("{0}={1}", SubPlanoDTO.FieldNames.Idt, row[SubPlanoDTO.FieldNames.Idt].ToString())).Length > 0)
                {
                    row["colSeleciona"] = true;
                }
            }

            dgvPesquisaSubPlano.DataSource = dtbSubPlano;

            dgvPesquisaSubPlano.Sort(Descricao, ListSortDirection.Ascending);

            if (dtbSubPlano.Rows.Count > 0)
            {
                chkSelTodos.Visible = true;
                if (dtbSubPlano.Rows.Count == dtbSubPlanosSelecionados.Rows.Count) chkSelTodos.Checked = true;
            } 
        }

        /// <summary>
        /// ReplicarSubPlanos
        /// </summary>
        /// <param name="dtbSubPlano">Sub-Planos do convênio</param>
        /// /// <param name="dtbSubPlanosSelecionados">Sub-Planos selecionados para replicação</param>
        /// <returns>Retorna sub-planos selecionados</returns>
        public static SubPlanoDataTable ReplicarSubPlanos(SubPlanoDataTable dtbSubPlano, SubPlanoDataTable dtbSubPlanosSelecionados)
        {
            FrmReplicarSubPlanos frmReplicarSubPlanos = new FrmReplicarSubPlanos();
            frmReplicarSubPlanos.DtbSubPlano = dtbSubPlano;
            frmReplicarSubPlanos.DtbSubPlanosSelecionados = dtbSubPlanosSelecionados;
            frmReplicarSubPlanos.ShowDialog();
            return frmReplicarSubPlanos.DtbSubPlanosSelecionados;
        }

        private void tsbOK_Click(object sender, EventArgs e)
        {
            if (dgvPesquisaSubPlano.RowCount > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                dtbSubPlanosSelecionados = new SubPlanoDataTable();
                foreach (DataGridViewRow dtgRow in dgvPesquisaSubPlano.Rows)
                {
                    if (bool.Parse(dtgRow.Cells["colSeleciona"].EditedFormattedValue.ToString()))
                    {
                        dtbSubPlanosSelecionados.Add((SubPlanoDTO)dtbSubPlano.Rows.Find(Convert.ToInt64(dtgRow.Cells["IdtSubPlano"].Value)));
                    }
                }                
                this.Cursor = Cursors.Default;
            }          
            this.Close();
        }

        private void chkSelTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dtgRow in dgvPesquisaSubPlano.Rows)
            {
                dtgRow.Cells[colSeleciona.Name].Value = chkSelTodos.Checked;
            }  
        }*/
    }
}