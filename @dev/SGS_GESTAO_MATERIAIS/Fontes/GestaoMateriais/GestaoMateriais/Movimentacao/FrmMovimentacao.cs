using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
// using HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmMovimentacao : FrmBase
    {
        public FrmMovimentacao()
        {
            InitializeComponent();
        }

        public void Movimentacao( MovimentacaoDTO dto)
        {
            this.dtoMovimentacao = dto;
            this.ConfiguraDtg();
            // dtoMovimentacao.DataMovimento.Value = 
            lblProduto.Text = dtoMovimentacao.DsProduto.Value;
            if (!dtoMovimentacao.CodLote.Value.IsNull)
                lblLote.Text = "LOTE:  " + dtoMovimentacao.CodLote.Value;
            this.MdiParent = FrmPrincipal.ActiveForm;
            this.Show();
        }

        #region OBJETOS SERVIÇOS
        // Movimentos        
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }
        private MovimentacaoDTO dtoMovimentacao;
        private MovimentacaoDataTable dtbMovimentacao;
        #endregion

        int totalEntrada;
        int totalSaida;
        int Saldo;

        private void ConfiguraDtg()
        {
            dtgMovimento.AutoGenerateColumns = false;
            dtgMovimento.Columns["colIdtMov"].DataPropertyName = MovimentacaoDTO.FieldNames.Idt;
            dtgMovimento.Columns["colDtMov"].DataPropertyName = MovimentacaoDTO.FieldNames.DataMovimento;
            dtgMovimento.Columns["colDtMov"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dtgMovimento.Columns["colSubTipoMov"].DataPropertyName = MovimentacaoDTO.FieldNames.DsSubtipoMov;
            dtgMovimento.Columns["colEntrada"].DataPropertyName = MovimentacaoDTO.FieldNames.QtdeEntrada;
            dtgMovimento.Columns["colSaida"].DataPropertyName = MovimentacaoDTO.FieldNames.QtdeSaida;
            dtgMovimento.Columns["colReqId"].DataPropertyName = MovimentacaoDTO.FieldNames.IdtRequisicao;
            dtgMovimento.Columns["colAtdAteId"].DataPropertyName = MovimentacaoDTO.FieldNames.IdtAtendimento;
            if (!dtoMovimentacao.CodLote.Value.IsNull)
                dtgMovimento.Columns["colSaldoMovimento"].DataPropertyName = MovimentacaoDTO.FieldNames.SaldoLoteSetor;
            else
                dtgMovimento.Columns["colSaldoMovimento"].DataPropertyName = MovimentacaoDTO.FieldNames.SaldoMovimento;

            dtgMovimento.Columns["colIdtTpMov"].DataPropertyName = MovimentacaoDTO.FieldNames.IdtTipo;
            dtgMovimento.Columns["colIdtSubMov"].DataPropertyName = MovimentacaoDTO.FieldNames.IdtSubTipo;

            dtgMovimento.Columns["colUsuario"].DataPropertyName = MovimentacaoDTO.FieldNames.DsUsuario;
            dtgMovimento.Columns["colUsuEstorno"].DataPropertyName = MovimentacaoDTO.FieldNames.DsUsuarioEstorno;
            dtgMovimento.Columns["colFlEstorno"].DataPropertyName = MovimentacaoDTO.FieldNames.FlEstornado;
            dtgMovimento.Columns[colCodLote.Name].DataPropertyName = MovimentacaoDTO.FieldNames.CodLote;            
        }

        private void FrmMovimentacao_Load(object sender, EventArgs e)
        {
            ConfiguraDtg();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDtInicio.Text) || !BasicFunctions.ValidarData(txtDtInicio.Text))
            {
                MessageBox.Show("Digite uma data de período inicial válida", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDtInicio.Text = string.Empty;
                txtDtInicio.Focus();
            }
            else
            {
                if (txtDtFim.Text != string.Empty)
                {
                    try
                    {
                        if (Convert.ToDateTime(txtDtFim.Text) < Convert.ToDateTime(txtDtInicio.Text))
                        {
                            MessageBox.Show("A Data Até deve ser maior ou igual à Data De.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtDtFim.Text = string.Empty;
                            txtDtFim.Focus();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Data Até inválida.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtDtFim.Text = string.Empty;
                        txtDtFim.Focus();
                        return;
                    }
                }
                //if (string.IsNullOrEmpty(txtDtFim.Text)) txtDtFim.Text = txtDtInicio.Text;
                dtoMovimentacao.DataMovimento.Value = Convert.ToDateTime(txtDtInicio.Text);
                dtoMovimentacao.DataAte.Value = new Framework.DTO.TypeDateTime();
                if (!string.IsNullOrEmpty(txtDtFim.Text)) dtoMovimentacao.DataAte.Value = Convert.ToDateTime(txtDtFim.Text);
                CarregaGrid();
            }
        }

        private void CarregaGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            // dtbMovimentacao = Movimento.ListaMovimentacao(dtoMovimentacao);
            dtbMovimentacao = Movimento.HistoricoProdutoSetor(dtoMovimentacao);
            MovimentacaoDTO dto = new MovimentacaoDTO();
            totalEntrada = 0;
            totalSaida = 0;
            Saldo = 0;
            for (int i = 0; i < dtbMovimentacao.Rows.Count; i++)
            {
            
                dto = dtbMovimentacao.TypedRow(i);
                if (i == 0) 
                    if (!dto.SaldoMovimento.Value.IsNull) 
                        Saldo = (int)dto.SaldoMovimento.Value;

                if (!dto.QtdeEntrada.Value.IsNull)
                    if ( dto.IdtSubTipo.Value != (int)MovimentacaoDTO.SubTipoMovimento.CONSUMO_PACIENTE_ESTORNADO_FRACIONADO )
                        totalEntrada = totalEntrada + (int)dto.QtdeEntrada.Value;
                if (!dto.QtdeSaida.Value.IsNull)
                {
                    if (dto.IdtSubTipo.Value != (int)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA &&
                        dto.IdtSubTipo.Value != (int)MovimentacaoDTO.SubTipoMovimento.DISTRIBUICAO_DESPESA_CENTRO_CUSTO &&
                        dto.IdtSubTipo.Value != (int)MovimentacaoDTO.SubTipoMovimento.INFO_FATURAMENTO_CENTRO_CIRURGICO &&
                        dto.IdtSubTipo.Value != (int)MovimentacaoDTO.SubTipoMovimento.BAIXA_FRACIONADA_NAO_FATURADA
                        )
                    {
                        totalSaida = totalSaida + (int)dto.QtdeSaida.Value;
                    }
                }
            }
            Saldo = (Saldo + totalEntrada) - totalSaida;
            if (Saldo != dtoMovimentacao.Qtde.Value)
                lblSaldo.ForeColor = Color.DarkGray;
            lblSaldo.Text = Convert.ToString(Saldo);

            lblTotalEntrada.Text = totalEntrada.ToString();
            lblTotalSaidas.Text = totalSaida.ToString();
            dtgMovimento.DataSource = dtbMovimentacao;
            BaixaFracionada();
            this.Cursor = Cursors.Default;

        }

        private void BaixaFracionada()
        {
            for (int i = 0; i < dtgMovimento.Rows.Count; i++)
            {
                dtgMovimento.Rows[i].Selected = false;
                if (Convert.ToDecimal(dtgMovimento.Rows[i].Cells["colIdtSubMov"].Value.ToString()) == (int)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA ||
                    Convert.ToDecimal(dtgMovimento.Rows[i].Cells["colIdtSubMov"].Value.ToString()) == (int)MovimentacaoDTO.SubTipoMovimento.CONSUMO_PACIENTE_ESTORNADO_FRACIONADO ||
                    Convert.ToDecimal(dtgMovimento.Rows[i].Cells["colIdtSubMov"].Value.ToString()) == (int)MovimentacaoDTO.SubTipoMovimento.DISTRIBUICAO_DESPESA_CENTRO_CUSTO ||
                    Convert.ToDecimal(dtgMovimento.Rows[i].Cells["colIdtSubMov"].Value.ToString()) == (int)MovimentacaoDTO.SubTipoMovimento.INFO_FATURAMENTO_CENTRO_CIRURGICO ||
                    Convert.ToDecimal(dtgMovimento.Rows[i].Cells["colIdtSubMov"].Value.ToString()) == (int)MovimentacaoDTO.SubTipoMovimento.BAIXA_FRACIONADA_NAO_FATURADA ||
                    Convert.ToDecimal(dtgMovimento.Rows[i].Cells["colIdtSubMov"].Value.ToString()) == (int)MovimentacaoDTO.SubTipoMovimento.CONSUMO_PACIENTE_ESTORNADO ||
                    Convert.ToDecimal(dtgMovimento.Rows[i].Cells["colIdtSubMov"].Value.ToString()) == (int)MovimentacaoDTO.SubTipoMovimento.CONSUMO_PACIENTE_ESTORNADO_FRACIONADO ||
                    Convert.ToDecimal(dtgMovimento.Rows[i].Cells["colIdtSubMov"].Value.ToString()) == (int)MovimentacaoDTO.SubTipoMovimento.ENTRADA_ESTORNO_LANCAMENTO
                    )
                {
                    try
                    {
                        dtgMovimento.Rows[i].Visible = !(dtgMovimento.Rows[i].Visible);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        private void FrmMovimentacao_Shown(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void dtgMovimento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // e.CellStyle.BackColor = Color.White;
            if (dtgMovimento.Rows.Count > 0)
            {                
                if (dtgMovimento.Rows[e.RowIndex].Cells["colFlEstorno"].Value.ToString() == "1")
                {
                    if (dtgMovimento.Rows[e.RowIndex].Cells["colSubTipoMov"].Value.ToString().ToUpper().IndexOf("ESTORN") > -1)
                    {
                        // dtgMovimento.RowsDefaultCellStyle.ForeColor = Color.Gray;
                        e.CellStyle.ForeColor = Color.Brown;
                    }
                    else
                        e.CellStyle.ForeColor = Color.Gray;                 
                }
                else
                    e.CellStyle.ForeColor = Color.Black;

                dtgMovimento.Rows[e.RowIndex].Cells["colAtdAteId"].Style.BackColor = Color.LightGray;
                dtgMovimento.Rows[e.RowIndex].Cells["colSaldoMovimento"].Style.BackColor = Color.Gray;

                if (e.ColumnIndex == colEntrada.Index)
                    e.CellStyle.ForeColor = Color.Green;

                if (e.ColumnIndex == colSaida.Index)
                    e.CellStyle.ForeColor = Color.Red;

                if (e.ColumnIndex == colSaldoMovimento.Index)
                    e.CellStyle.ForeColor = Color.Black;
            }
        }

        private void dtgMovimento_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //if (dtgMovimento.Rows.Count > 0)
            //{
            //    if (dtgMovimento.Rows[e.RowIndex].Cells["colFlEstorno"].Value.ToString() == "1")
            //    {
            //        dtgMovimento.RowsDefaultCellStyle.ForeColor = Color.Gray;
            //    }
            //    else
            //    {
            //        dtgMovimento.RowsDefaultCellStyle.ForeColor = Color.Black;
            //        dtgMovimento.Rows[e.RowIndex].Cells["colAtdAteId"].Style.BackColor = Color.LightGray;
            //        dtgMovimento.Rows[e.RowIndex].Cells["colSaldoMovimento"].Style.BackColor = Color.Gray; ;
            //        //
            //        dtgMovimento.Rows[e.RowIndex].Cells["colEntrada"].Style.ForeColor = Color.Green;
            //        dtgMovimento.Rows[e.RowIndex].Cells["colSaida"].Style.ForeColor = Color.Red;
            //    }
            //}

        }

        private void lblProduto_DoubleClick(object sender, EventArgs e)
        {
            dtgMovimento.Columns["colIdtMov"].Visible = !(dtgMovimento.Columns["colIdtMov"].Visible);
            dtgMovimento.Columns["colIdtTpMov"].Visible = !(dtgMovimento.Columns["colIdtTpMov"].Visible);
            dtgMovimento.Columns["colIdtSubMov"].Visible = !(dtgMovimento.Columns["colIdtSubMov"].Visible);
        }

        private void lblProduto_Click(object sender, EventArgs e) { }

        private void chkMostraMov_Click(object sender, EventArgs e)
        {
            BaixaFracionada();
        }        
    }
}