using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.Componentes;
using System.Web.UI.WebControls;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Gerencial
{
    public partial class FrmNFProdutos : FrmBase
    {
        private bool _excluido = false;

        #region OBJETOS SERVIÇOS
        private HistoricoNotaFiscalDTO dtoNotaFiscal;
        private HistoricoNotaFiscalDataTable dtbHistNF;

        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        private IHistoricoNotaFiscal _histNF;
        private IHistoricoNotaFiscal HistoricoNotaFiscal
        {
            get { return _histNF != null ? _histNF : _histNF = (IHistoricoNotaFiscal)Global.Common.GetObject(typeof(IHistoricoNotaFiscal)); }
        }

        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }

        #endregion

        public FrmNFProdutos()
        {
            InitializeComponent();
        }

        private void ConfigurarComprasDTG()
        {
            dtgCompras.AutoGenerateColumns = false;
            dtgCompras.Columns[colProduto.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.DsProduto;
            dtgCompras.Columns[colIdProduto.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.IdtProduto;
            dtgCompras.Columns["colData"].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.DataPrcMedio;
            dtgCompras.Columns["colData"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dtgCompras.Columns["colQtd"].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.Qtde;
            dtgCompras.Columns["colQtd"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgCompras.Columns["colQtd"].DefaultCellStyle.Format = "N0";
            dtgCompras.Columns["colUnidade"].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.UnidadeCompra; // (unidade (compra))
            dtgCompras.Columns["colVlrUnitario"].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.PrecoUnitario;
            dtgCompras.Columns["colVlrUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgCompras.Columns["colTpMovimento"].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.TpMovimento;

            dtgCompras.Columns["colSaldoanterior"].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.SaldoAnterior;
            dtgCompras.Columns["colSaldoanterior"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgCompras.Columns["colSaldoanterior"].DefaultCellStyle.Format = "N0";

            dtgCompras.Columns["colCustoMedio"].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.CustoMedio;
            dtgCompras.Columns["colCustoMedio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

            dtgCompras.Columns["colQtdeCompra"].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.QtdeTotalNota;
            dtgCompras.Columns["colQtdeCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

            dtgCompras.Columns[colIdLote.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.IdtLote;
            dtgCompras.Columns[colLoteFab.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.NumLote;
        }

        private void BuscaHistoricoNotaFiscal()
        {
            HistoricoNotaFiscalDTO dtoHistNF = new HistoricoNotaFiscalDTO();
            dtoHistNF.NrNota.Value = dtoNotaFiscal.NrNota.Value;
            dtoHistNF.DataPrcMedio.Value = DateTime.Parse(dtoNotaFiscal.DataPrcMedio.Value.ToString()).Date.AddDays(-7);
            dtoHistNF.IdtFilial.Value = dtoNotaFiscal.IdtFilial.Value;
            dtbHistNF = HistoricoNotaFiscal.Sel(dtoHistNF);
            foreach (DataRow row in dtbHistNF.Rows)
            {
                if (row[HistoricoNotaFiscalDTO.FieldNames.DsFornecedor].ToString() != lblFornecedor.Text)
                    row.Delete();
            }
            dtbHistNF.AcceptChanges();
            dtgCompras.DataSource = dtbHistNF;
            if (!new Generico().VerificaAcessoFuncionalidade("EstornoNF"))
                dtgCompras.Columns[0].Visible = false;
        }

        public static bool Pesquisar(HistoricoNotaFiscalDTO dtoNF)
        {
            FrmNFProdutos frm = new FrmNFProdutos();
            frm.dtoNotaFiscal = dtoNF;            
            frm.ShowDialog();
            return frm._excluido;
        }

        private void FrmNFProdutos_Load(object sender, EventArgs e)
        {            
            lblEstoque.Text = dtoNotaFiscal.IdtFilial.Value == 2 ? "ACS" : "HAC";
            lblNumero.Text = dtoNotaFiscal.NrNota.Value;
            lblFornecedor.Text = dtoNotaFiscal.DsFornecedor.Value;
            ConfigurarComprasDTG();
            BuscaHistoricoNotaFiscal();
        }

        private void dtgCompras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {             
                if (dtgCompras.Columns[e.ColumnIndex].Name == colExcluir.Name)
                {
                    HistoricoNotaFiscalDTO dtoNF = null;
                    DataRow[] drNotas = dtbHistNF.Select(string.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = {5}",
                                                                               HistoricoNotaFiscalDTO.FieldNames.NrNota,
                                                                               lblNumero.Text,
                                                                               HistoricoNotaFiscalDTO.FieldNames.DsFornecedor,
                                                                               lblFornecedor.Text,
                                                                               HistoricoNotaFiscalDTO.FieldNames.IdtProduto,
                                                                               dtgCompras.Rows[e.RowIndex].Cells[colIdProduto.Name].Value));
                    if (drNotas.Length == 1)
                    {
                        dtoNF = (HistoricoNotaFiscalDTO)drNotas[0];
                        //dtoNF.IdtLote.Value = new Framework.DTO.TypeDecimal();
                    }
                    else
                    {   //Buscar por lote também
                        dtoNF = (HistoricoNotaFiscalDTO)dtbHistNF.Select(string.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = {5} AND {6} = {7}",
                                                                                       HistoricoNotaFiscalDTO.FieldNames.NrNota,
                                                                                       lblNumero.Text,
                                                                                       HistoricoNotaFiscalDTO.FieldNames.DsFornecedor,
                                                                                       lblFornecedor.Text,
                                                                                       HistoricoNotaFiscalDTO.FieldNames.IdtLote,
                                                                                       dtgCompras.Rows[e.RowIndex].Cells[colIdLote.Name].Value,
                                                                                       HistoricoNotaFiscalDTO.FieldNames.IdtProduto,
                                                                                       dtgCompras.Rows[e.RowIndex].Cells[colIdProduto.Name].Value))[0];
                    }
                    if (//DateTime.Parse(dtoNF.DataPrcMedio.Value.ToString()).Date >= Utilitario.ObterDataHoraServidor().Date.AddDays(-7) &&
                        DateTime.Parse(dtoNF.DataPrcMedio.Value.ToString()).Date.ToString("MMyyyy") == Utilitario.ObterDataHoraServidor().Date.ToString("MMyyyy"))
                    {
                        MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();
                        dtoMatMed.Idt.Value = dtoNF.IdtProduto.Value;
                        if (FrmExclusaoItemNF.SolicitarExclusao(dtoNF, MatMed.SelChave(dtoMatMed)))
                            this.BuscaHistoricoNotaFiscal();
                    }
                    else
                    {
                        MessageBox.Show("Estorno inválido, pois esta nota não é referente ao mês atual.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }                
            }
        }
    }
}