using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using HospitalAnaCosta.Services.Produto.DTO;
using HospitalAnaCosta.Framework;
using Hac.Windows.Forms;

namespace Hac.Windows.Forms.Controls.Forms
{
    public partial class FrmReplicarTipoProcedimento : FrmBase
    {
        public FrmReplicarTipoProcedimento()
        {
            InitializeComponent();

            Titulo = "Selecionar Itens";
        }

        #region [Propriedades de Acesso aos Serviços de Produtos]

        ///// <summary>
        ///// Common Produto
        ///// </summary>
        //private CommonServices _CommonServices;
        //private CommonServices CommonServices
        //{
        //    get
        //    {
        //        return _CommonServices != null ? _CommonServices : _CommonServices = new CommonServices(FrmBase.DtoPassport);
        //    }
        //}

        ///// <summary>
        ///// Acessa os serviços de Tipo de Atributo do Produto
        ///// </summary>
        //private ITipoAtributoProduto _tipoAtributoProduto;
        //protected ITipoAtributoProduto TipoAtributoProduto
        //{
        //    get
        //    {
        //        return _tipoAtributoProduto != null ? _tipoAtributoProduto : _tipoAtributoProduto = (HospitalAnaCosta.Services.Produto.Interface.ITipoAtributoProduto)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Produto.Interface.ITipoAtributoProduto));
        //    }
        //}

        private TipoAtributoProdutoDataTable dtbItens;
        public TipoAtributoProdutoDataTable DtbItens
        {
            get { return dtbItens; }
            set { dtbItens = value; }
        }

        private TipoAtributoProdutoDataTable dtbItensSelecionados;
        public TipoAtributoProdutoDataTable DtbItensSelecionados
        {
            get { return dtbItensSelecionados; }
            set { dtbItensSelecionados = value; }
        }

        private ConvenioTabelaUtilizadaDataTable dtbTabelasSelecionadas;
        public ConvenioTabelaUtilizadaDataTable TabelasSelecionadas
        {
            get { return dtbTabelasSelecionadas; }
            set { dtbTabelasSelecionadas = value; }
        }

        private decimal _idtConvenio;
        public decimal IdtConvenio
        {
            get { return _idtConvenio; }
            set { _idtConvenio = value; }
        }

        #endregion

        private void FrmReplicarTipoProcedimento_Load(object sender, EventArgs e)
        {
            dgvPesquisa.AutoGenerateColumns = false;

            dgvPesquisa.Columns["Idt"].DataPropertyName = TipoAtributoProdutoDTO.FieldNames.TipoAtributo;
            dgvPesquisa.Columns["Descricao"].DataPropertyName = TipoAtributoProdutoDTO.FieldNames.DescricacaoAtributo;

            dtbItens.Columns.Add("colSeleciona");
            dgvPesquisa.Columns["colSeleciona"].DataPropertyName = "colSeleciona";

            foreach (DataRow row in dtbItens.Rows)
            {
                if (dtbItensSelecionados.Select(string.Format("{0}='{1}'", TipoAtributoProdutoDTO.FieldNames.TipoAtributo, row[TipoAtributoProdutoDTO.FieldNames.TipoAtributo].ToString())).Length > 0)
                {
                    row["colSeleciona"] = true;
                }
            }

            dgvPesquisa.DataSource = dtbItens;

            dgvPesquisa.Sort(Descricao, ListSortDirection.Ascending);

            //if (dtbItens.Rows.Count > 0)
            //{
            //    chkSelTodos.Visible = true;
            //    if (dtbItens.Rows.Count == dtbItensSelecionados.Rows.Count) chkSelTodos.Checked = true;
            //} 
        }

        private void tsbOK_Click(object sender, EventArgs e)
        {
            if (dgvPesquisa.RowCount > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                dtbItensSelecionados = new  TipoAtributoProdutoDataTable();
                foreach (DataGridViewRow dtgRow in dgvPesquisa.Rows)
                {
                    if (bool.Parse(dtgRow.Cells["colSeleciona"].EditedFormattedValue.ToString()))
                    {
                        dtbItensSelecionados.Add((TipoAtributoProdutoDTO)dtbItens.Rows.Find(dtgRow.Cells["Idt"].Value.ToString()));
                    }
                }
                this.Cursor = Cursors.Default;
            }
            this.Close();
        }

        private void chkSelTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dtgRow in dgvPesquisa.Rows)
            {
                dtgRow.Cells[colSeleciona.Name].Value = chkSelTodos.Checked;
            }  
        }

        private void dgvPesquisa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == dgvPesquisa.Columns[colTabelas.Name].Index ||
                    e.ColumnIndex == dgvPesquisa.Columns[colSeleciona.Name].Index)
                {
                    //if (!bool.Parse(dgvPesquisa.Rows[e.RowIndex].Cells["colSeleciona"].EditedFormattedValue.ToString()))
                    //{
                    //    MessageBox.Show("Selecione o item para poder adicionar suas tabelas de cobrança", "Seleção de Itens", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}
                    if (e.ColumnIndex == dgvPesquisa.Columns[colTabelas.Name].Index &&
                        !bool.Parse(dgvPesquisa.Rows[e.RowIndex].Cells["colSeleciona"].EditedFormattedValue.ToString()))
                        dgvPesquisa.Rows[e.RowIndex].Cells[colSeleciona.Name].Value = true;

                    this.Cursor = Cursors.WaitCursor;

                    ConvenioTabelaUtilizadaDTO dtoItem = new ConvenioTabelaUtilizadaDTO();
                    dtoItem.TipoAtributo.Value = dgvPesquisa.Rows[e.RowIndex].Cells[Idt.Name].Value.ToString();
                    dtoItem.IdtConvenio.Value = this.IdtConvenio;
                    ConvenioTabelaUtilizadaDataTable dtbItens = ConvenioTabelaUtilizada.ListarJoinTudo(dtoItem);
                    dtbItens = (ConvenioTabelaUtilizadaDataTable)BasicFunctions.ValidarVigencia(ConvenioTabelaUtilizadaDTO.FieldNames.DataInicioVigencia, ConvenioTabelaUtilizadaDTO.FieldNames.DataFimVigencia, dtbItens);
                    
                    if (TabelasSelecionadas == null) TabelasSelecionadas = new ConvenioTabelaUtilizadaDataTable();

                    if (dtbItens.Rows.Count > 0 && e.ColumnIndex == dgvPesquisa.Columns[colTabelas.Name].Index)
                    {
                        TabelasSelecionadas = FrmReplicarTabela.ReplicarItens(dtbItens, TabelasSelecionadas, dgvPesquisa.Rows[e.RowIndex].Cells[Descricao.Name].Value.ToString());

                        if (TabelasSelecionadas.Select(string.Format("{0}='{1}'", TipoAtributoProdutoDTO.FieldNames.TipoAtributo, dtoItem.TipoAtributo.Value.ToString())).Length == 0)
                            dgvPesquisa.Rows[e.RowIndex].Cells[colSeleciona.Name].Value = false;
                    }
                    else if (dtbItens.Rows.Count == 0 && bool.Parse(dgvPesquisa.Rows[e.RowIndex].Cells["colSeleciona"].EditedFormattedValue.ToString()))
                    {
                        MessageBox.Show("Nenhuma tabela de cobrança associada a este item", "Seleção de Itens", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvPesquisa.EndEdit();
                        dgvPesquisa.Rows[e.RowIndex].Cells[colSeleciona.Name].Value = false;
                    }
                    else if (e.ColumnIndex == dgvPesquisa.Columns[colSeleciona.Name].Index && !bool.Parse(dgvPesquisa.Rows[e.RowIndex].Cells["colSeleciona"].EditedFormattedValue.ToString()))
                    {
                        MessageBox.Show("Selecione alguma tabela de cobrança", "Seleção de Itens", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                    this.Cursor = Cursors.Default;                    
                }
            }
        }

        /// <summary>
        /// ReplicarItens
        /// </summary>
        /// <param name="dtb">Itens a selecionar</param>
        /// /// <param name="dtbSelecionados">Itens selecionados para replicação</param>
        /// <returns>Retorna itens selecionados</returns>
        public static TipoAtributoProdutoDataTable ReplicarItens(TipoAtributoProdutoDataTable dtb, TipoAtributoProdutoDataTable dtbSelecionados, decimal idtConvenio, ref ConvenioTabelaUtilizadaDataTable tabelasSelecionadas)
        {
            FrmReplicarTipoProcedimento frm = new FrmReplicarTipoProcedimento();
            frm.dtbItens = dtb;
            frm.dtbItensSelecionados = dtbSelecionados;
            frm.IdtConvenio = idtConvenio;
            frm.TabelasSelecionadas = tabelasSelecionadas;
            frm.ShowDialog();
            tabelasSelecionadas = frm.TabelasSelecionadas;
            return frm.DtbItensSelecionados;
        }       
    }
}