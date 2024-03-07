using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.DTO;

namespace Hac.Windows.Forms.Controls.Forms
{
    public partial class FrmReplicarUnidadesLocais : FrmBase
    {
        public FrmReplicarUnidadesLocais()
        {
            InitializeComponent();

            Titulo = "Selecionar Unidades/Locais";
        }

        private Decimal _idtConvenio = 0;        
        public Decimal IdtConvenio
        {
            get { return _idtConvenio; }
            set { _idtConvenio = value; }
        }

        private DataTable dtbUnidadeLocalSelecionados;
        public DataTable DtbUnidadeLocalSelecionados
        {
            get { return dtbUnidadeLocalSelecionados; }
            set { dtbUnidadeLocalSelecionados = value; }
        }

        private DataTable dtbUnidadeLocalSelecionadosRetorno;
        public DataTable DtbUnidadeLocalSelecionadosRetorno
        {
            get { return dtbUnidadeLocalSelecionadosRetorno; }
            set { dtbUnidadeLocalSelecionadosRetorno = value; }
        }

        private string ObterFiltroSelect(int? idtUnidade, int? idtLocal)
        {
            string filtro;

            if (idtUnidade != null)
            {
                filtro = string.Format("{0} = {1}", UnidadeDTO.FieldNames.Idt, idtUnidade.Value);
            }
            else
            {
                filtro = string.Format("{0} IS NULL", UnidadeDTO.FieldNames.Idt);
            }
            if (idtLocal != null)
            {
                filtro += string.Format(" AND {0} = {1}", LocalAtendimentoDTO.FieldNames.Idt, idtLocal.Value);
            }
            else
            {
                filtro += string.Format(" AND {0} IS NULL", LocalAtendimentoDTO.FieldNames.Idt);
            }

            return filtro;
        }

        private void FrmReplicarUnidadesLocais_Load(object sender, EventArgs e)
        {
            cboUnidade.SomenteAtiva = true;
            cboUnidade.IdtConvenio = IdtConvenio;
            cboUnidade.Carregaunidade();
            cboLocal.CarregaLocal(new LocalAtendimentoDTO());

            if (dtbUnidadeLocalSelecionados == null || dtbUnidadeLocalSelecionados.Columns.Count == 0)
            {
                dtbUnidadeLocalSelecionados = new DataTable();

                dtbUnidadeLocalSelecionados.Columns.Add(UnidadeDTO.FieldNames.Idt);
                dtbUnidadeLocalSelecionados.Columns.Add(LocalAtendimentoDTO.FieldNames.Idt);
                dtbUnidadeLocalSelecionados.Columns.Add(UnidadeDTO.FieldNames.DsUnidade);
                dtbUnidadeLocalSelecionados.Columns.Add(LocalAtendimentoDTO.FieldNames.DsLocalAtendimento);
            }

            dtbUnidadeLocalSelecionadosRetorno = dtbUnidadeLocalSelecionados.Copy();

            dgvPesquisaUnidadeLocal.AutoGenerateColumns = false;

            dgvPesquisaUnidadeLocal.Columns["colIdtUnidade"].DataPropertyName = UnidadeDTO.FieldNames.Idt;
            dgvPesquisaUnidadeLocal.Columns["colIdtLocal"].DataPropertyName = LocalAtendimentoDTO.FieldNames.Idt;
            dgvPesquisaUnidadeLocal.Columns["colUnidade"].DataPropertyName = UnidadeDTO.FieldNames.DsUnidade;
            dgvPesquisaUnidadeLocal.Columns["colLocal"].DataPropertyName = LocalAtendimentoDTO.FieldNames.DsLocalAtendimento;

            dgvPesquisaUnidadeLocal.DataSource = dtbUnidadeLocalSelecionados;

            dgvPesquisaUnidadeLocal.Sort(colUnidade, ListSortDirection.Ascending);
            
            dgvPesquisaUnidadeLocal.ClearSelection();
        }

        private void btnAdicionarProdutoItem_Click(object sender, EventArgs e)
        {
            if ((cboUnidade.SelectedIndex == -1 || cboUnidade.SelectedValue.ToString() == "-1") &&
                (cboLocal.SelectedIndex == -1 || cboLocal.SelectedValue.ToString() == "-1"))
            {
                MessageBox.Show("Selecione a Unidade ou um Local", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? idtUnidade = null, idtLocal = null;
            
            if ((cboUnidade.SelectedIndex > -1 && cboUnidade.SelectedValue.ToString() != "-1")) idtUnidade = int.Parse(cboUnidade.SelectedValue.ToString());
            if ((cboLocal.SelectedIndex > -1 && cboLocal.SelectedValue.ToString() != "-1")) idtLocal = int.Parse(cboLocal.SelectedValue.ToString());

            if (dtbUnidadeLocalSelecionados.Select(this.ObterFiltroSelect(idtUnidade, idtLocal)).Length > 0)
            {
                MessageBox.Show("Unidade/Local já selecionado", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            DataRow row = dtbUnidadeLocalSelecionados.NewRow();

            if ((cboUnidade.SelectedIndex > -1 && cboUnidade.SelectedValue.ToString() != "-1"))
            {
                row[UnidadeDTO.FieldNames.Idt] = cboUnidade.SelectedValue.ToString();
                row[UnidadeDTO.FieldNames.DsUnidade] = cboUnidade.SelectedItem.ToString();
            }
            if ((cboLocal.SelectedIndex > -1 && cboLocal.SelectedValue.ToString() != "-1"))
            {
                row[LocalAtendimentoDTO.FieldNames.Idt] = cboLocal.SelectedValue.ToString();
                row[LocalAtendimentoDTO.FieldNames.DsLocalAtendimento] = cboLocal.SelectedItem.ToString();
            }            

            dtbUnidadeLocalSelecionados.Rows.Add(row);

            cboUnidade.SelectedIndex = 0;
            cboLocal.SelectedIndex = 0;

            dgvPesquisaUnidadeLocal.ClearSelection();
        }

        private void btnExcluirProdutoItem_Click(object sender, EventArgs e)
        {            
            foreach (DataGridViewRow selectedRow in dgvPesquisaUnidadeLocal.SelectedRows)
            {
                int? idtUnidade = null, idtLocal = null;

                if (!string.IsNullOrEmpty(selectedRow.Cells["colIdtUnidade"].Value.ToString())) idtUnidade = int.Parse(selectedRow.Cells["colIdtUnidade"].Value.ToString());
                if (!string.IsNullOrEmpty(selectedRow.Cells["colIdtLocal"].Value.ToString())) idtLocal = int.Parse(selectedRow.Cells["colIdtLocal"].Value.ToString());

                dtbUnidadeLocalSelecionados.Select(this.ObterFiltroSelect(idtUnidade, idtLocal))[0].Delete();
            }
            
            dtbUnidadeLocalSelecionados.AcceptChanges();

            dgvPesquisaUnidadeLocal.ClearSelection();
        }
                
        private void tsbOK_Click(object sender, EventArgs e)
        {
            dtbUnidadeLocalSelecionadosRetorno = dtbUnidadeLocalSelecionados;
            this.Close();
        }

        public static DataTable ReplicarUnidadesLocais(DataTable dtbUnidadeLocalSelecionados, int? idtConvenio)
        {
            FrmReplicarUnidadesLocais frmReplicarUnidadesLocais = new FrmReplicarUnidadesLocais();
            frmReplicarUnidadesLocais.DtbUnidadeLocalSelecionados = dtbUnidadeLocalSelecionados;
            if (idtConvenio != null) frmReplicarUnidadesLocais.IdtConvenio = idtConvenio.Value;
            frmReplicarUnidadesLocais.ShowDialog();
            return frmReplicarUnidadesLocais.DtbUnidadeLocalSelecionadosRetorno;
        }
    }
}