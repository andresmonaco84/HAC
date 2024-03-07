using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao;
using HospitalAnaCosta.SGS.GestaoMateriais.Componentes;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    public partial class FrmEstoqueOnlineLote : FrmGestao
    {
        public FrmEstoqueOnlineLote()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇO

        private MaterialMedicamentoDTO dtoMatMed;

        private IMatMedSetorConfig _matMedConfig;
        private IMatMedSetorConfig MatMedSetorConfig
        {
            get { return _matMedConfig != null ? _matMedConfig : _matMedConfig = (IMatMedSetorConfig)Global.Common.GetObject(typeof(IMatMedSetorConfig)); }
        }

        private EstoqueLocalDTO dtoEstoque;
        private EstoqueLocalDataTable dtbEstoque;
        // Estoque
        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject(typeof(IEstoqueLocal)); }
        }

        private IHistoricoNotaFiscal _histNF;
        private IHistoricoNotaFiscal HistoricoNotaFiscal
        {
            get { return _histNF != null ? _histNF : _histNF = (IHistoricoNotaFiscal)Global.Common.GetObject(typeof(IHistoricoNotaFiscal)); }
        }        

        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        Generico gen = new Generico();

        #endregion

        #region MÉTODOS

        private void CarregaItens()
        {
            dtgMatMed.Columns[colEnderecoAlmox.Name].Visible = false;
            if (!rbHac.Checked && !rbCE.Checked)
            {
                MessageBox.Show("Selecione o Estoque: HAC ou CE", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cmbUnidade.SelectedIndex == -1 || cmbLocal.SelectedIndex == -1 || cmbSetor.SelectedIndex == -1)
            {
                rbHac.Checked = false;                
                rbCE.Checked = false;               

                MessageBox.Show("Selecione Unidade/Local/Setor Para Pesquisa", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                dtgMatMed.DataSource = null;
                ConfiguraEstoqueDTO();
                dtbEstoque = Estoque.ListarEstoqueLote(dtoEstoque);
                if (chkLotesSaldo.Checked)
                {
                    DataView dtv = new DataView(dtbEstoque,
                                                string.Format("{0} > 0 AND {1} <> 'SEM_LOTE'", EstoqueLocalDTO.FieldNames.QtdeLote, EstoqueLocalDTO.FieldNames.CodLote), 
                                                null, DataViewRowState.CurrentRows);
                    dtgMatMed.DataSource = dtv.ToTable();
                }
                else
                    dtgMatMed.DataSource = dtbEstoque;

                mnuEstoqueOnLine.Items[mnuItemImp.Name].Visible = gen.VerificaAcessoFuncionalidade("FrmImpCodBarra");
                mnuEstoqueOnLine.Items[mnuTransfere.Name].Visible = gen.VerificaAcessoFuncionalidade("FrmTransfMatMed");
                if (int.Parse(cmbSetor.SelectedValue.ToString()) == 29) //Almox. Central
                    dtgMatMed.Columns[colEnderecoAlmox.Name].Visible = true;
                this.Cursor = Cursors.Default;
                try
                {
                    SetorEstoqueConsumoDTO dtoEstoqueConsumo = new SetorEstoqueConsumoDTO();
                    dtoEstoqueConsumo.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                    dtoEstoqueConsumo.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                    dtoEstoqueConsumo.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                    dtoEstoqueConsumo.IdtFilial.Value = RetornaFilial();

                    if (gen.CarregaEstoqueConsumo(dtoEstoqueConsumo).Rows.Count > 0)
                    {
                        tsHac.Items["lblEstComp"].Text = "Esta Unidade Consome do estoque outra Unidade";
                        tsHac.Items["lblEstComp"].Visible = true;

                    }
                    else if (gen.VerificaEstoqueCompartilhado(dtoEstoqueConsumo).Rows.Count > 0)
                    {
                        // alguém consome deste estoque
                        tsHac.Items["lblEstComp"].Text = "Outra(s) Unidade(s) Consome(m) deste estoque";
                        tsHac.Items["lblEstComp"].Visible = true;
                    }
                    else
                    {
                        tsHac.Items["lblEstComp"].Visible = false;
                    }
                }
                catch
                {
                    MessageBox.Show("erro Buscando Estoque Compartilhado", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        /// <summary>
        /// Configura Colunas do Data Grid baseado nos campos do dto
        /// </summary>
        private void ConfiguraDTG()
        {
            dtgMatMed.AutoGenerateColumns = false;

            dtgMatMed.Columns[colIdtProduto.Name].DataPropertyName = EstoqueLocalDTO.FieldNames.IdtProduto;
            dtgMatMed.Columns[colIdtProduto.Name].ToolTipText = string.Empty;
            dtgMatMed.Columns[colIdtProduto.Name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

            dtgMatMed.Columns[colDsProduto.Name].DataPropertyName = EstoqueLocalDTO.FieldNames.DsProduto;
            dtgMatMed.Columns[colDsProduto.Name].ToolTipText = string.Empty;

            dtgMatMed.Columns[colCodLote.Name].DataPropertyName = EstoqueLocalDTO.FieldNames.CodLote;
            dtgMatMed.Columns[colNumLote.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.NumLote;
            dtgMatMed.Columns[colQtdeLote.Name].DataPropertyName = EstoqueLocalDTO.FieldNames.QtdeLote;

            dtgMatMed.Columns[colMAV.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia;
            dtgMatMed.Columns[colFlFracionado.Name].DataPropertyName = EstoqueLocalDTO.FieldNames.FlFracionado;
            dtgMatMed.Columns[colFlAtivo.Name].DataPropertyName = EstoqueLocalDTO.FieldNames.FlAtivo;            

            dtgMatMed.Columns[colDtAtualiza.Name].DataPropertyName = EstoqueLocalDTO.FieldNames.DataAtualizaLote;
            dtgMatMed.Columns[colDtAtualiza.Name].DefaultCellStyle.Format = "dd/MM/yyyy à\\s HH:mm:ss";

            dtgMatMed.Columns[colDataVal.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.DataValidadeProduto;
            dtgMatMed.Columns[colEnderecoAlmox.Name].DataPropertyName = "CAD_MTMD_ENDERECO_ALMOX_HAC";
        }

        private decimal RetornaFilial()
        {
            decimal retorno = 0;
            if (rbHac.Checked)
                retorno = (decimal)FilialMatMedDTO.Filial.HAC;
            
            else if (rbCE.Checked)
                retorno = (decimal)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
            return retorno;
        }

        private void ConfiguraEstoqueDTO()
        {
            dtoEstoque = new EstoqueLocalDTO();

            dtoEstoque.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoEstoque.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoEstoque.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoEstoque.IdtFilial.Value = RetornaFilial();
            if (!chkTodos.Checked && dtoMatMed != null && !dtoMatMed.Idt.Value.IsNull)
                dtoEstoque.IdtProduto.Value = dtoMatMed.Idt.Value;
            
            dtoEstoque.Origem.Value = 1;
        }

        private void Limpar()
        {            
            tsHac.Items["lblEstComp"].Visible = false;
            tsHac.Controla(Evento.eCancelar);
        }

        private void VerificaEstoqueUnificado()
        {
            int? setorCarrEmergPai = gen.SetorCarrinhoEmergencia(int.Parse(cmbSetor.SelectedValue.ToString()));
            if (setorCarrEmergPai != null)
            {
                this.ConfigurarControles(grbFilial.Controls, false);
                rbCE.Checked = true;
                return;
            }
            else
            {
                this.ConfigurarControles(grbFilial.Controls, true);
                rbCE.Checked = false;
            }
            MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();
            dtoCfg.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoCfg.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoCfg.Idtsetor.Value = cmbSetor.SelectedValue.ToString();
            dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);
            if (dtoCfg.EstoqueUnificadoHAC.Value.IsNull) dtoCfg.EstoqueUnificadoHAC.Value = 0;
            if (dtoCfg.EstoqueUnificadoHAC.Value == 1)
            {
                this.Cursor = Cursors.WaitCursor;                
                rbHac.Checked = true;
                this.Cursor = Cursors.Default;
                
            }
            else
            {
                rbCE.Text = "CE";
                rbCE.Checked = false;
                grbFilial.Visible = true;                
            }
        }

        #endregion

        private void FrmEstoqueOnlineLote_Load(object sender, EventArgs e)
        {
            cmbSetor.ComEstoque = false;
            cmbUnidade.Carregaunidade();
            Generico.ConfiguraCombos(cmbUnidade, cmbLocal, cmbSetor, FrmPrincipal.dtoSeguranca);
            ConfiguraDTG();
            VerificaEstoqueUnificado();            
            tsHac.Items["tsBtnMatMed"].Enabled = chkLotesSaldo.Checked = true;            
        }

        private void rbHac_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHac.Checked)
            {
                dtoMatMed = null;
                chkTodos.Checked = chkLotesSaldo.Checked = true;                
                CarregaItens();
            }
        }

        private void rbCE_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCE.Checked)
            {
                dtoMatMed = null;
                chkTodos.Checked = chkLotesSaldo.Checked = true;                
                CarregaItens();
            }
        }

        private void rbHac_Click(object sender, EventArgs e) {}

        private void rbCE_Click(object sender, EventArgs e)
        {
            if (rbCE.Checked)
            {
                this.Cursor = Cursors.WaitCursor;

                string strMsgSetoresCE = gen.SetoresCE_MessageBox(int.Parse(cmbSetor.SelectedValue.ToString()));

                if (!string.IsNullOrEmpty(strMsgSetoresCE))
                    MessageBox.Show(strMsgSetoresCE.ToString(), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Cursor = Cursors.Default;
            }
        }        

        private void dtgMatMed_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtbEstoque != null)
            {
                if (dtbEstoque.Rows.Count > 0) // && dtbEstoque.Rows.Count == dtgMatMed.Rows.Count)
                {                    
                    if (dtgMatMed.Rows[e.RowIndex].Cells["colFlAtivo"].Value.ToString() == "0")
                    {
                        e.CellStyle.BackColor = Color.LightBlue;
                        e.CellStyle.ForeColor = Color.Gray;
                        e.CellStyle.SelectionForeColor = Color.Gray;                        
                        dtgMatMed.Rows[e.RowIndex].Cells[colDsProduto.Name].ToolTipText = "Este Produto está Inativo";
                    }
                    if (dtgMatMed.Columns[e.ColumnIndex].Name == colDataVal.Name &&
                        !string.IsNullOrEmpty(dtgMatMed.Rows[e.RowIndex].Cells[colDataVal.Name].Value.ToString()))
                    {
                        DateTime dtVal = DateTime.Parse(dtgMatMed.Rows[e.RowIndex].Cells[colDataVal.Name].Value.ToString());
                        if (dtVal.Date < Utilitario.ObterDataHoraServidor().Date) //Item vencido
                        {
                            e.CellStyle.SelectionForeColor = Color.WhiteSmoke;
                            e.CellStyle.SelectionBackColor = Color.Red;
                            e.CellStyle.BackColor = Color.Red;
                        }
                        else if (dtVal.Date >= Utilitario.ObterDataHoraServidor().Date && dtVal.Date <= Utilitario.ObterDataHoraServidor().AddDays(30).Date) //Item vence nos próximos 30 dias
                        {
                            e.CellStyle.SelectionForeColor = Color.WhiteSmoke;
                            e.CellStyle.SelectionBackColor = Color.Orange;
                            e.CellStyle.BackColor = Color.Orange;
                        }
                        else if (dtVal.Date >= Utilitario.ObterDataHoraServidor().Date && dtVal.Date <= Utilitario.ObterDataHoraServidor().AddDays(60).Date) //Item vence nos próximos 60 dias
                        {
                            e.CellStyle.SelectionForeColor = Color.DarkGray;
                            e.CellStyle.SelectionBackColor = Color.Yellow;
                            e.CellStyle.BackColor = Color.Yellow;
                        }
                    }
                }
            } 
        }

        private void dtgMatMed_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dtgMatMed.Columns[e.ColumnIndex].Name == "colSimilar")
                {
                    this.Cursor = Cursors.WaitCursor;
                    MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();
                    dtoMatMed.Idt.Value = Convert.ToDecimal(dtgMatMed.Rows[e.RowIndex].Cells["colIdtProduto"].Value.ToString());
                    new FrmPesquisaSimilares().VisualizarSimilares(dtoMatMed);
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void dtgMatMed_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dtgMatMed.ClearSelection();
                int curRowIndex = dtgMatMed.HitTest(e.X, e.Y).RowIndex;
                if (curRowIndex >= 0 && curRowIndex != dtgMatMed.NewRowIndex)
                {
                    dtgMatMed.Rows[curRowIndex].Selected = true;
                    dtgMatMed.CurrentCell = dtgMatMed.Rows[curRowIndex].Cells[0];
                }
            }
        }

        private void cmbUnidade_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Limpar();            
        }

        private void cmbLocal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Limpar();            
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Limpar();            
            VerificaEstoqueUnificado();            
        }

        private void dtgMatMed_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dtgMatMed.Rows[e.RowIndex].Cells[colCodLote.Name].Value.ToString() != "SEM_LOTE")
                {
                    MovimentacaoDTO dtoMovimentacao = new MovimentacaoDTO();
                    dtoMovimentacao.CodLote.Value = dtgMatMed.Rows[e.RowIndex].Cells[colCodLote.Name].Value.ToString();
                    dtoMovimentacao.IdtProduto.Value = Convert.ToInt64(dtgMatMed.Rows[e.RowIndex].Cells[colIdtProduto.Name].Value.ToString());
                    dtoMovimentacao.DsProduto.Value = dtgMatMed.Rows[e.RowIndex].Cells[colDsProduto.Name].Value.ToString();
                    dtoMovimentacao.IdtUnidade.Value = dtoEstoque.IdtUnidade.Value;
                    dtoMovimentacao.IdtLocal.Value = dtoEstoque.IdtLocal.Value;
                    dtoMovimentacao.IdtSetor.Value = dtoEstoque.IdtSetor.Value;
                    dtoMovimentacao.IdtFilial.Value = dtoEstoque.IdtFilial.Value;
                    if (dtgMatMed.Rows[e.RowIndex].Cells[colQtdeLote.Name].Value.ToString() == string.Empty)
                        dtoMovimentacao.Qtde.Value = 0;
                    else
                        dtoMovimentacao.Qtde.Value = Convert.ToDecimal(dtgMatMed.Rows[e.RowIndex].Cells[colQtdeLote.Name].Value.ToString());

                    new Movimentacao.FrmMovimentacao().Movimentacao(dtoMovimentacao);
                }
            }
        }

        private bool tsHac_MatMedClick(object sender)
        {
            if (rbHac.Checked || rbCE.Checked)
            {
                MaterialMedicamentoDTO dtoMatMedAux = new MaterialMedicamentoDTO();
                dtoMatMedAux.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.SEM_ESTOQUE;
                dtoMatMedAux = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMedAux);

                if (dtoMatMedAux != null)
                {
                    dtoMatMed = dtoMatMedAux;
                    chkTodos.Checked = false;
                    CarregaItens();
                }                
            }
            return false;
        }

        private void chkLotesSaldo_Click(object sender, EventArgs e)
        {
            CarregaItens();                
        }

        private void chkTodos_Click(object sender, EventArgs e)
        {
            if (dtoMatMed == null)
                chkTodos.Checked = true;
            else
            {
                if (chkTodos.Checked)
                    dtoMatMed = null;                
            }
            CarregaItens();
        }
        
        private void mnuItemImp_Click(object sender, EventArgs e)
        {
            HistoricoNotaFiscalDTO dtoHistNFImprimir = new HistoricoNotaFiscalDTO();

            dtoHistNFImprimir.IdtProduto.Value = dtgMatMed.CurrentRow.Cells[colIdtProduto.Name].Value.ToString();
            dtoHistNFImprimir.CodLote.Value = dtgMatMed.CurrentRow.Cells[colCodLote.Name].Value.ToString();
            dtoHistNFImprimir.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC;

            FrmImpCodBarra.CarregarItemImpressao(dtoHistNFImprimir);
        }

        private void mnuTransfere_Click(object sender, EventArgs e)
        {
            if (dtgMatMed.CurrentRow == null) return;
            if (base.Confirma(string.Format("{0} {1}?", "Deseja Fazer Transferência entre estoques do produto", dtgMatMed.CurrentRow.Cells[colDsProduto.Name].Value.ToString())))
            {
                HistoricoNotaFiscalDTO dtoHistNF = new HistoricoNotaFiscalDTO();
                dtoHistNF.IdtProduto.Value = dtgMatMed.CurrentRow.Cells[colIdtProduto.Name].Value.ToString();
                dtoHistNF.CodLote.Value = dtgMatMed.CurrentRow.Cells[colCodLote.Name].Value.ToString();
                dtoHistNF.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC;

                HistoricoNotaFiscalDataTable dtbHNF = HistoricoNotaFiscal.Sel(dtoHistNF);
                if (dtbHNF.Rows.Count > 0)
                {
                    MovimentacaoDTO dtoTransfere = new MovimentacaoDTO();
                    dtoTransfere.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                    dtoTransfere.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                    dtoTransfere.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                    dtoTransfere.IdtProduto.Value = dtgMatMed.CurrentRow.Cells[colIdtProduto.Name].Value.ToString();
                    dtoTransfere.DsProduto.Value = dtgMatMed.CurrentRow.Cells[colDsProduto.Name].Value.ToString();
                    dtoTransfere.IdtFilial.Value = RetornaFilial();
                    dtoTransfere.IdtLote.Value = dtbHNF.TypedRow(0).IdtLote.Value;
                    FrmTransfMatMed.Transferencia(dtoTransfere);
                }
                else
                    MessageBox.Show("LOTE NÃO IDENTIFICADO!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}