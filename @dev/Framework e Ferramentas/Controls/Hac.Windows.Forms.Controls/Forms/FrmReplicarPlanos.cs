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
    public partial class FrmReplicarPlanos : FrmBase
    {       
        public FrmReplicarPlanos()
        {
            InitializeComponent();

            Titulo = "Selecionar Planos";
        }
        
        private PlanoDataTable dtbPlano;
        public PlanoDataTable DtbPlano
        {
            get { return dtbPlano; }
            set { dtbPlano = value; }
        }

        private PlanoDataTable dtbPlanosSelecionados;
        public PlanoDataTable DtbPlanosSelecionados
        {
            get { return dtbPlanosSelecionados; }
            set { dtbPlanosSelecionados = value; }
        }

        /// <summary>
        /// CarregarGrid
        /// Apenas um dos parâmetros devem ser verdadeiros
        /// </summary>
        /// <param name="todos"></param>
        /// <param name="sup"></param>
        /// <param name="inf"></param>
        private void CarregarGrid(bool todos, bool sup, bool inf, bool com, bool mid, bool pre)
        {
            this.Cursor = Cursors.WaitCursor;
            if (!todos && dtbPlanosSelecionados != null && dtbPlanosSelecionados.Rows.Count > 0)
            {
                dtbPlanosSelecionados = new PlanoDataTable();
                foreach (DataRow row in dtbPlano.Rows) { row["colSeleciona"] = false; }
                chkSelTodos.Checked = false;
            }
            else if (!todos)
            {
                foreach (DataRow row in dtbPlano.Rows) { row["colSeleciona"] = false; }
                chkSelTodos.Checked = false;
            }

            if (todos)
                dgvPesquisaPlano.DataSource = dtbPlano;
            else if (sup)
                dgvPesquisaPlano.DataSource = new DataView(dtbPlano, string.Format("{0}='{1}'", PlanoDTO.FieldNames.CategoriaPlano, "SUP"), string.Empty, DataViewRowState.CurrentRows).ToTable();
            else if (inf)
                dgvPesquisaPlano.DataSource = new DataView(dtbPlano, string.Format("{0}='{1}'", PlanoDTO.FieldNames.CategoriaPlano, "INF"), string.Empty, DataViewRowState.CurrentRows).ToTable();
            else if (com)
                dgvPesquisaPlano.DataSource = new DataView(dtbPlano, string.Format("{0}='{1}'", PlanoDTO.FieldNames.CategoriaPlano, "COM"), string.Empty, DataViewRowState.CurrentRows).ToTable();
            else if (mid)
                dgvPesquisaPlano.DataSource = new DataView(dtbPlano, string.Format("{0}='{1}'", PlanoDTO.FieldNames.CategoriaPlano, "MID"), string.Empty, DataViewRowState.CurrentRows).ToTable();
            else if (pre)
                dgvPesquisaPlano.DataSource = new DataView(dtbPlano, string.Format("{0}='{1}'", PlanoDTO.FieldNames.CategoriaPlano, "PRE"), string.Empty, DataViewRowState.CurrentRows).ToTable();

            dgvPesquisaPlano.Sort(Descricao, ListSortDirection.Ascending);

            if (dgvPesquisaPlano.RowCount > 0)
            {
                chkSelTodos.Visible = true;
                if (dgvPesquisaPlano.RowCount == dtbPlanosSelecionados.Rows.Count) chkSelTodos.Checked = true;
            }
            this.Cursor = Cursors.Default;
        }

        private void FrmReplicarPlanos_Load(object sender, EventArgs e)
        {
            dgvPesquisaPlano.AutoGenerateColumns = false;

            dgvPesquisaPlano.Columns["IdtPlano"].DataPropertyName = PlanoDTO.FieldNames.IdtPlano;
            dgvPesquisaPlano.Columns["Codigo"].DataPropertyName = PlanoDTO.FieldNames.CodigoPlanoHAC;
            dgvPesquisaPlano.Columns["Descricao"].DataPropertyName = PlanoDTO.FieldNames.NomePlano;
            dgvPesquisaPlano.Columns["Categoria"].DataPropertyName = PlanoDTO.FieldNames.CategoriaPlano;

            dtbPlano.Columns.Add("colSeleciona");
            dgvPesquisaPlano.Columns["colSeleciona"].DataPropertyName = "colSeleciona";

            foreach (DataRow row in dtbPlano.Rows)
            {
                if (dtbPlanosSelecionados.Select(string.Format("{0}={1}", PlanoDTO.FieldNames.IdtPlano, row[PlanoDTO.FieldNames.IdtPlano].ToString())).Length > 0)
                {
                    row["colSeleciona"] = true;
                }
            }

            CarregarGrid(true, false, false, false, false, false);
        }

        /// <summary>
        /// ReplicarPlanos
        /// </summary>
        /// <param name="dtbPlano">Planos do convênio</param>
        /// /// <param name="dtbPlanosSelecionados">Planos selecionados para replicação</param>
        /// <returns>Retorna planos selecionados</returns>
        public static PlanoDataTable ReplicarPlanos(PlanoDataTable dtbPlano, PlanoDataTable dtbPlanosSelecionados)
        {
            FrmReplicarPlanos frmReplicarPlanos = new FrmReplicarPlanos();
            frmReplicarPlanos.DtbPlano = dtbPlano;
            frmReplicarPlanos.DtbPlanosSelecionados = dtbPlanosSelecionados;
            frmReplicarPlanos.ShowDialog();
            return frmReplicarPlanos.DtbPlanosSelecionados;
        }

        private void tsbOK_Click(object sender, EventArgs e)
        {
            if (dgvPesquisaPlano.RowCount > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                dtbPlanosSelecionados = new PlanoDataTable();
                foreach (DataGridViewRow dtgRow in dgvPesquisaPlano.Rows)
                {
                    if (bool.Parse(dtgRow.Cells["colSeleciona"].EditedFormattedValue.ToString()))
                    {
                        dtbPlanosSelecionados.Add((PlanoDTO)dtbPlano.Rows.Find(Convert.ToInt64(dtgRow.Cells["IdtPlano"].Value)));
                    }
                }                
                this.Cursor = Cursors.Default;
            }          
            this.Close();
        }

        private void chkSelTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dtgRow in dgvPesquisaPlano.Rows)
            {
                dtgRow.Cells[colSeleciona.Name].Value = chkSelTodos.Checked;
            }  
        }

        private void rbTodos_Click(object sender, EventArgs e)
        {
            CarregarGrid(true, false, false, false, false, false);
        }

        private void rbSup_Click(object sender, EventArgs e)
        {
            CarregarGrid(false, true, false, false, false, false);
        }

        private void rbInf_Click(object sender, EventArgs e)
        {
            CarregarGrid(false, false, true, false, false, false);
        }

        private void rbCom_Click(object sender, EventArgs e)
        {
            CarregarGrid(false, false, false, true, false, false);
        }

        private void rmMid_Click(object sender, EventArgs e)
        {
            CarregarGrid(false, false, false, false, true, false);
        }

        private void rmPremium_Click(object sender, EventArgs e)
        {
            CarregarGrid(false, false, false, false, false, true);
        }                
    }
}