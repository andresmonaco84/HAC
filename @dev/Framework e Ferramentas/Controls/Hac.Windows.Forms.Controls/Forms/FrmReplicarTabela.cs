using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using HospitalAnaCosta.Services.Produto.DTO;

namespace Hac.Windows.Forms.Controls.Forms
{
    public partial class FrmReplicarTabela : FrmBase
    {
        public FrmReplicarTabela()
        {
            InitializeComponent();

            Titulo = "Selecionar Itens";
        }

        #region [Propriedades de Acesso aos Serviços de Produtos]

        private ConvenioTabelaUtilizadaDataTable dtbItens;
        public ConvenioTabelaUtilizadaDataTable DtbItens
        {
            get { return dtbItens; }
            set { dtbItens = value; }
        }

        private ConvenioTabelaUtilizadaDataTable dtbItensSelecionados;
        public ConvenioTabelaUtilizadaDataTable DtbItensSelecionados
        {
            get { return dtbItensSelecionados; }
            set { dtbItensSelecionados = value; }
        }

        #endregion

        private void FrmReplicarTabela_Load(object sender, EventArgs e)
        {
            dgvPesquisa.AutoGenerateColumns = false;
            
            //dgvPesquisa.Columns["Idt"].DataPropertyName = ConvenioTabelaUtilizadaDTO.FieldNames.CodigoTabelaMedicaCobranca;
            dgvPesquisa.Columns["Idt"].DataPropertyName = ConvenioTabelaUtilizadaDTO.FieldNames.IdtAssociacaoConvenioTabelaUtilizada;
            dgvPesquisa.Columns["Descricao"].DataPropertyName = "COD_DESC_TABELA_COB";

            dtbItens.Columns.Add("colSeleciona");
            dgvPesquisa.Columns["colSeleciona"].DataPropertyName = "colSeleciona";

            foreach (DataRow row in dtbItens.Rows)
            {
                //if (dtbItensSelecionados.Select(string.Format("{0}='{1}'", ConvenioTabelaUtilizadaDTO.FieldNames.CodigoTabelaMedicaCobranca, row[ConvenioTabelaUtilizadaDTO.FieldNames.CodigoTabelaMedicaCobranca].ToString())).Length > 0)
                if (dtbItensSelecionados.Select(string.Format("{0}='{1}'", ConvenioTabelaUtilizadaDTO.FieldNames.IdtAssociacaoConvenioTabelaUtilizada, row[ConvenioTabelaUtilizadaDTO.FieldNames.IdtAssociacaoConvenioTabelaUtilizada].ToString())).Length > 0)
                {
                    row["colSeleciona"] = true;
                }
            }

            dgvPesquisa.DataSource = dtbItens;

            dgvPesquisa.Sort(Descricao, ListSortDirection.Ascending);            
        }

        private void tsbOK_Click(object sender, EventArgs e)
        {
            if (dgvPesquisa.RowCount > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                if (dtbItensSelecionados == null) dtbItensSelecionados = new ConvenioTabelaUtilizadaDataTable();
                foreach (DataGridViewRow dtgRow in dgvPesquisa.Rows)
                {
                    if (bool.Parse(dtgRow.Cells["colSeleciona"].EditedFormattedValue.ToString()))
                    {
                        try
                        {
                            dtbItensSelecionados.Add((ConvenioTabelaUtilizadaDTO)dtbItens.Rows.Find(dtgRow.Cells["Idt"].Value.ToString()));
                        }
                        catch (Exception ex)
                        {
                            //Deixar passar quando for duplicar registro, pois não precisa incluir de novo e o DataTable continua correto
                            if (ex.Message.IndexOf("ASS_CTU_ID") == -1) throw ex;
                        }
                    }
                    else
                    {
                        if (dtbItensSelecionados.Rows.Find(dtgRow.Cells["Idt"].Value.ToString()) != null)
                            dtbItensSelecionados.Rows.Remove(dtbItensSelecionados.Rows.Find(dtgRow.Cells["Idt"].Value.ToString()));
                    }
                }
                dtbItensSelecionados.AcceptChanges();
                this.Cursor = Cursors.Default;
            }
            this.Close();            
        }

        /// <summary>
        /// ReplicarItens
        /// </summary>
        /// <param name="dtb">Itens a selecionar</param>
        /// /// <param name="dtbSelecionados">Itens selecionados para replicação</param>
        /// <returns>Retorna itens selecionados</returns>
        public static ConvenioTabelaUtilizadaDataTable ReplicarItens(ConvenioTabelaUtilizadaDataTable dtb, ConvenioTabelaUtilizadaDataTable dtbSelecionados, string itemCobranca)
        {
            FrmReplicarTabela frm = new FrmReplicarTabela();
            frm.lblItem.Text = itemCobranca;
            frm.dtbItens = dtb;
            frm.dtbItensSelecionados = dtbSelecionados;
            frm.ShowDialog();
            return frm.DtbItensSelecionados;
        }
    }
}