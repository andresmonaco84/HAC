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
    public partial class FrmHistDevolucoesNF : FrmBase
    {
        private MaterialMedicamentoDTO dtoProduto;
        private HistoricoNFEstornoDataTable dtbNFE;

        private IHistoricoNFEstorno _hnfe;
        private IHistoricoNFEstorno HistNFEstorno
        {
            get { return _hnfe != null ? _hnfe : _hnfe = (IHistoricoNFEstorno)Global.Common.GetObject(typeof(IHistoricoNFEstorno)); }
        }

        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        public FrmHistDevolucoesNF()
        {
            InitializeComponent();
        }

        private void ConfigurarGrid()
        {
            dtgCompras.AutoGenerateColumns = false;
            dtgCompras.Columns[colNF.Name].DataPropertyName = HistoricoNFEstornoDTO.FieldNames.NrNota;
            dtgCompras.Columns[colFornecedor.Name].DataPropertyName = HistoricoNFEstornoDTO.FieldNames.DsFornecedor;
            dtgCompras.Columns[colData.Name].DataPropertyName = HistoricoNFEstornoDTO.FieldNames.DataAtualizacao;
            dtgCompras.Columns[colQtd.Name].DataPropertyName = HistoricoNFEstornoDTO.FieldNames.QtdeEstorno;
            dtgCompras.Columns[colQtd.Name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgCompras.Columns[colQtd.Name].DefaultCellStyle.Format = "N0";
            dtgCompras.Columns[colTpMovimento.Name].DataPropertyName = HistoricoNFEstornoDTO.FieldNames.TpMov;
            dtgCompras.Columns[colMotivo.Name].DataPropertyName = HistoricoNFEstornoDTO.FieldNames.Motivo;
            dtgCompras.Columns[colDataAcerto.Name].DataPropertyName = HistoricoNFEstornoDTO.FieldNames.DataAcerto;
            dtgCompras.Columns[colProdutoAcerto.Name].DataPropertyName = "PRODUTO_ACERTO";
            dtgCompras.Columns[colStatus.Name].DataPropertyName = "STATUS_DESCRICAO";
        }

        private void CarregarGrid()
        {
            HistoricoNFEstornoDTO dtoNFE = new HistoricoNFEstornoDTO();
            dtoNFE.IdtFilial.Value = dtoProduto.IdtFilial.Value;
            dtoNFE.IdtProduto.Value = dtoProduto.Idt.Value;
            dtbNFE = HistNFEstorno.Listar(dtoNFE);
            dtgCompras.DataSource = dtbNFE;
        }

        public static bool ExclusoesProduto(MaterialMedicamentoDTO dtoMatMed)
        {
            FrmHistDevolucoesNF frm = new FrmHistDevolucoesNF();
            frm.dtoProduto = dtoMatMed;
            frm.ShowDialog();
            return true;
        }

        private void FrmHistDevolucoesNF_Load(object sender, EventArgs e)
        {
            lblCod.Text = dtoProduto.CodMne.Value;
            lblProduto.Text = dtoProduto.NomeFantasia.Value;
            lblEstoque.Text = dtoProduto.IdtFilial.Value == 2 ? "ACS" : "HAC";
            ConfigurarGrid();
            CarregarGrid();
        }

        private void dtgCompras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (dtgCompras.Columns[e.ColumnIndex].Name == colNF.Name)
                {
                    HistoricoNFEstornoDTO dtoNFE = (HistoricoNFEstornoDTO)dtbNFE.Select(string.Format("{0} = '{1}' AND {2} = '{3}'",
                                                                                                       HistoricoNFEstornoDTO.FieldNames.NrNota,
                                                                                                       dtgCompras.Rows[e.RowIndex].Cells[colNF.Name].Value,
                                                                                                       HistoricoNFEstornoDTO.FieldNames.DsFornecedor,
                                                                                                       dtgCompras.Rows[e.RowIndex].Cells[colFornecedor.Name].Value))[0];
                    HistoricoNotaFiscalDTO dtoNF = new HistoricoNotaFiscalDTO();
                    //dtoNF.DataPrcMedio.Value = Utilitario.ObterDataHoraServidor().Date.AddDays(-3);
                    dtoNF.DataPrcMedio.Value = DateTime.Parse(dtoNFE.DataAtualizacao.Value.ToString()).Date.AddDays(-31);
                    dtoNF.IdtFilial.Value = dtoNFE.IdtFilial.Value;
                    dtoNF.NrNota.Value = dtoNFE.NrNota.Value;
                    dtoNF.DsFornecedor.Value = dtoNFE.DsFornecedor.Value;
                    if (FrmNFProdutos.Pesquisar(dtoNF))
                        this.CarregarGrid();
                }
            }
        }
    }
}