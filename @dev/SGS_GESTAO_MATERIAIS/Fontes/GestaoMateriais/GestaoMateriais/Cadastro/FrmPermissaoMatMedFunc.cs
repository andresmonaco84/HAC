using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.Seguranca.Interface;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.View;
using HospitalAnaCosta.SGS.Componentes;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmPermissaoMatMedFunc : FrmBase
    {
        #region OBJETOS SERVIÇOS

        private CommonSeguranca _commonSeguranca;
        private CommonSeguranca CommonSeguranca
        {
            get { return _commonSeguranca != null ? _commonSeguranca : _commonSeguranca = new CommonSeguranca(null); }
        }        

        private MatMedFuncionalidadeDTO dtoMatMedFuncSelecionado;
        private MatMedFuncionalidadeDataTable dtbMatMedFunc;
        private IMatMedFuncionalidade _matMedFuncionalidade;
        private IMatMedFuncionalidade MatMedFuncionalidade
        {
            get { return _matMedFuncionalidade != null ? _matMedFuncionalidade : _matMedFuncionalidade = (IMatMedFuncionalidade)Global.Common.GetObject(typeof(IMatMedFuncionalidade)); }
        }

        #endregion

        #region MÉTODOS

        public FrmPermissaoMatMedFunc()
        {
            InitializeComponent();
        }

        private void CarregarFuncionalidadesGestaoEstoque()
        {
            dtgListaFuncionalidade.AutoGenerateColumns = false;
            dtgListaFuncionalidade.Columns["colIdt"].DataPropertyName = FuncionalidadeDTO.FieldNames.Idt;
            dtgListaFuncionalidade.Columns["colFuncionalidadePai"].DataPropertyName = FuncionalidadeDTO.FieldNames.IdtFuncionalidadePai;
            dtgListaFuncionalidade.Columns["colMenu"].DataPropertyName = FuncionalidadeDTO.FieldNames.FlItemMenu;
            dtgListaFuncionalidade.Columns["colNmFuncionalidade"].DataPropertyName = FuncionalidadeDTO.FieldNames.NmFuncionalidade;
            dtgListaFuncionalidade.Columns["colNmPagina"].DataPropertyName = FuncionalidadeDTO.FieldNames.NmPagina;

            dtgListaFuncionalidade.DataSource = new Generico().ListarTipoPedidoFuncionalidade(true);
        }

        private void CarregarProdutosFuncionalidade()
        {
            this.Cursor = Cursors.WaitCursor;
            dtbMatMedFunc = MatMedFuncionalidade.Sel(dtoMatMedFuncSelecionado);
            dtgMatMed.DataSource = dtbMatMedFunc;
            this.Cursor = Cursors.Default;
        }

        private void ConfigGridMatMed()
        {
            dtgMatMed.AutoGenerateColumns = false;
            dtgMatMed.Columns["colIdProduto"].DataPropertyName = MaterialMedicamentoDTO.FieldNames.Idt;
            dtgMatMed.Columns["colDescricao"].DataPropertyName = MaterialMedicamentoDTO.FieldNames.NomeFantasia;
            dtgMatMed.Columns[colQtdeMax.Name].DataPropertyName = MatMedFuncionalidadeDTO.FieldNames.QtdeMaximaPedido;
        }

        #endregion

        #region EVENTOS

        private void FrmPermissaoMatMedSetor_Load(object sender, EventArgs e)
        {
            ConfigGridMatMed();
            CarregarFuncionalidadesGestaoEstoque();            
        }

        private void dtgListaFuncionalidade_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtoMatMedFuncSelecionado = new MatMedFuncionalidadeDTO();
            dtoMatMedFuncSelecionado.IdFuncionalidade.Value = dtgListaFuncionalidade.Rows[e.RowIndex].Cells[colIdt.Name].Value.ToString();
            CarregarProdutosFuncionalidade();
        }

        private bool tsHac_MatMedClick(object sender)
        {
            if (dtgListaFuncionalidade.CurrentRow != null && dtgListaFuncionalidade.CurrentRow.Cells[colNmPagina.Name].Value.ToString() == "EstoqueLocalTodosProdutos")
            {
                MessageBox.Show("Este tipo já contempla pedir todos os produtos não permitindo parametrização específica !", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO(); ;

            dtoMatMed.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.SEM_ESTOQUE;
            dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMed);                                            

            if (dtoMatMed != null)
            {
                if (dtbMatMedFunc.Select(string.Format("{0}={1}", MaterialMedicamentoDTO.FieldNames.Idt, dtoMatMed.Idt.Value.ToString())).Length > 0)
                {
                    MessageBox.Show("Produto já incluso nesta funcionalidade", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                this.Cursor = Cursors.WaitCursor;
                MatMedFuncionalidadeDTO dtoMatMedFunc = new MatMedFuncionalidadeDTO();
                dtoMatMedFunc.IdFuncionalidade.Value = dtoMatMedFuncSelecionado.IdFuncionalidade.Value;
                dtoMatMedFunc.IdProduto.Value = dtoMatMed.Idt.Value;
                dtoMatMedFunc.IdUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                MatMedFuncionalidade.Ins(dtoMatMedFunc);
                CarregarProdutosFuncionalidade();
                this.Cursor = Cursors.Default;
            }

            return true;
        }

        private void dtgMatMed_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgMatMed.Columns[e.ColumnIndex].Name == "colDel")
            {
                if (MessageBox.Show("Deseja realmente excluir este produto da lista ?",
                                     "Gestão de Materiais e Medicamentos",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    for (int nCount = 0; nCount < dtbMatMedFunc.Rows.Count; nCount++)
                    {
                        if (dtbMatMedFunc.Rows[nCount].RowState != DataRowState.Deleted)
                        {
                            if (dtbMatMedFunc.Rows[nCount][MaterialMedicamentoDTO.FieldNames.Idt].ToString() == dtgMatMed.Rows[e.RowIndex].Cells["colIdProduto"].Value.ToString())
                            {
                                MatMedFuncionalidadeDTO dtoMatMedFunc = new MatMedFuncionalidadeDTO();
                                dtoMatMedFunc.IdFuncionalidade.Value = dtoMatMedFuncSelecionado.IdFuncionalidade.Value;
                                dtoMatMedFunc.IdProduto.Value = dtgMatMed.Rows[e.RowIndex].Cells["colIdProduto"].Value.ToString();
                                MatMedFuncionalidade.Del(dtoMatMedFunc);
                                CarregarProdutosFuncionalidade();
                                break;
                            }
                        }
                    }
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void dtgMatMed_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dtgMatMed.Columns[e.ColumnIndex].Name == colQtdeMax.Name)
            {
                if (!string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    if (!this.IsNumber(e.FormattedValue.ToString()))
                    {
                        tsHac.Enabled = false;
                        MessageBox.Show("Qtd. Máx. deve ser numérico", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Cancel = true;
                    }
                    else if (e.FormattedValue.ToString().IndexOf(',') > -1)
                    {
                        tsHac.Enabled = false;
                        MessageBox.Show("Qtd. Máx. deve ser um número inteiro", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Cancel = true;
                    }
                    else if (decimal.Parse(e.FormattedValue.ToString()) <= 0)
                    {
                        tsHac.Enabled = false;
                        MessageBox.Show("Qtd. Máx. deve ser maior que 0", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Cancel = true;
                    }
                    else
                        tsHac.Enabled = true;
                }
            }
        }

        private void dtgMatMed_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dtgMatMed.Columns[e.ColumnIndex].Name == colQtdeMax.Name)
            {
                this.Cursor = Cursors.WaitCursor;
                
                MatMedFuncionalidadeDTO dtoMatMedFunc = new MatMedFuncionalidadeDTO();
                dtoMatMedFunc.IdFuncionalidade.Value = dtoMatMedFuncSelecionado.IdFuncionalidade.Value;
                dtoMatMedFunc.IdProduto.Value = dtgMatMed.Rows[e.RowIndex].Cells[colIdProduto.Name].Value.ToString();
                dtoMatMedFunc.IdUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                if (!string.IsNullOrEmpty(dtgMatMed.Rows[e.RowIndex].Cells[colQtdeMax.Name].Value.ToString()))
                    dtoMatMedFunc.QtdeMaximaPedido.Value = dtgMatMed.Rows[e.RowIndex].Cells[colQtdeMax.Name].Value.ToString();
                else
                    dtoMatMedFunc.QtdeMaximaPedido.Value = new Framework.DTO.TypeDecimal();

                MatMedFuncionalidade.Atualizar(dtoMatMedFunc);

                this.Cursor = Cursors.Default;
            }
        }

        #endregion
    }
}