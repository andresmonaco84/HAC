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
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmBaixaPedidoKit : FrmBase
    {
        public FrmBaixaPedidoKit()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇOS

        private int _qtdMedicamentos = 0;
        
        private IRequisicao _requisicao;
        private IRequisicao Requisicao
        {
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject(typeof(IRequisicao)); }
        }

        private RequisicaoItensDTO dtoRequisicaoItem;
        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }

        private MovimentacaoDTO dtoMovimento;        
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }

        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }

        #endregion

        public void CarregarKitBaixa(RequisicaoDTO dto, string kitDsc, MovimentacaoDTO dtoMov)
        {
            dtoMovimento = dtoMov;
            this.lblNumPedido.Text = dto.Idt.Value;
            this.lblKit.Text = dto.IdKit.Value + " - " + kitDsc;
            this.ShowDialog();
        }

        private void CarregarItensBaixa()
        {
            dtoRequisicaoItem = new RequisicaoItensDTO();
            dtoRequisicaoItem.Idt.Value = this.lblNumPedido.Text;
            dtgItensBaixa.DataSource = RequisicaoItens.ListarItensBaixa(dtoRequisicaoItem);
            
            foreach (DataGridViewRow dtgRow in dtgItensBaixa.Rows)
            {               
                dtgRow.Cells[colQtdPend.Name].Value = (int.Parse(dtgRow.Cells[colQtdSol.Name].Value.ToString()) - int.Parse(dtgRow.Cells[colQtdBaixada.Name].Value.ToString())).ToString();
                if (int.Parse(dtgRow.Cells[colQtdPend.Name].Value.ToString()) > 0)
                {
                    dtgRow.Cells[colChkBaixar.Name].Value = true;
                    dtgRow.Cells[colQtdPend.Name].Style.Font = new Font(dtgItensBaixa.Font, FontStyle.Bold);
                    dtgRow.Cells[colQtdPend.Name].Style.ForeColor = Color.Red;

                    if (string.IsNullOrEmpty(dtgRow.Cells[colQtdEstoque.Name].Value.ToString()) ||
                        int.Parse(dtgRow.Cells[colQtdPend.Name].Value.ToString()) > int.Parse(dtgRow.Cells[colQtdEstoque.Name].Value.ToString()))
                    {
                        dtgRow.Cells[colQtdEstoque.Name].Style.Font = new Font(dtgItensBaixa.Font, FontStyle.Bold);
                        dtgRow.Cells[colQtdEstoque.Name].Style.BackColor = Color.Red;
                    }
                }
            }
        }

        private bool SalvarItensBaixa()
        {
            RequisicaoItensDataTable dtbItens;
            MaterialMedicamentoDTO dtoMatMed;
            int qtdSaldoEstoqueAtual, qtdSolicitada, qtdBaixada, qtdBaixar, qtdProcesso = 0;

            _qtdMedicamentos = 0;
            dtoMovimento.IdtRequisicao.Value = dtoRequisicaoItem.Idt.Value;
            dtoMovimento.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
            
            foreach (DataGridViewRow dtgRow in dtgItensBaixa.Rows)
            {
                if (bool.Parse(dtgRow.Cells[colChkBaixar.Name].EditedFormattedValue.ToString()))
                {
                    try
                    {
                        dtoRequisicaoItem.IdtProduto.Value = int.Parse(dtgRow.Cells[colIdtProduto.Name].Value.ToString());
                        dtbItens = RequisicaoItens.ListarItensBaixa(dtoRequisicaoItem); //Vai no banco para atualizar a qtd. a baixar                   
                        qtdSaldoEstoqueAtual = (!string.IsNullOrEmpty(dtbItens.Rows[0][EstoqueLocalDTO.FieldNames.Qtde].ToString()) ? int.Parse(dtbItens.Rows[0][EstoqueLocalDTO.FieldNames.Qtde].ToString()) : 0);
                        if (qtdSaldoEstoqueAtual > 0)
                        {
                            qtdSolicitada = (!string.IsNullOrEmpty(dtbItens.Rows[0][RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString()) ? int.Parse(dtbItens.Rows[0][RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString()) : 0);
                            qtdBaixada = (!string.IsNullOrEmpty(dtbItens.Rows[0][RequisicaoItensDTO.FieldNames.QtdFornecida].ToString()) ? int.Parse(dtbItens.Rows[0][RequisicaoItensDTO.FieldNames.QtdFornecida].ToString()) : 0);
                            qtdBaixar = qtdSolicitada - qtdBaixada;
                            //Verificar saldo disponível para não enviar qtd. maior do que tem em estoque
                            if (qtdSaldoEstoqueAtual < qtdBaixar) qtdBaixar = qtdSaldoEstoqueAtual;

                            if (qtdBaixar > 0)
                            {
                                dtoMovimento.Qtde.Value = qtdBaixar;
                                dtoMovimento.IdtProduto.Value = dtoRequisicaoItem.IdtProduto.Value;

                                dtoMatMed = new MaterialMedicamentoDTO();
                                dtoMatMed.Idt.Value = dtoMovimento.IdtProduto.Value;
                                dtoMatMed = MatMed.SelChave(dtoMatMed);

                                if ((int)dtoMatMed.IdtGrupo.Value != 1) //Nao deixar baixar mais medicamento devido a rastreabilidade
                                {
                                    if (dtoMatMed.FlFracionado.Value.IsNull) dtoMatMed.FlFracionado.Value = (byte)MaterialMedicamentoDTO.Fracionado.NAO;
                                    if (dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM)
                                        dtoMovimento.FlFracionado.Value = (byte)MaterialMedicamentoDTO.Fracionado.NAO;

                                    Movimento.MovimentaEstoqueProduto(dtoMovimento, dtoMatMed, null);

                                    qtdProcesso += qtdBaixar;
                                }
                                else
                                    _qtdMedicamentos += 1;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }

            if (qtdProcesso == 0) return false;
            
            return true;
        }

        private void FrmBaixaPedidoKit_Load(object sender, EventArgs e)
        {
            dtgItensBaixa.AutoGenerateColumns = false;
            this.CarregarItensBaixa();
        }

        private bool tsHac_SalvarClick(object sender)
        {
            if (this.SalvarItensBaixa())
            {
                this.CarregarItensBaixa();
                MessageBox.Show("Materiais com saldo em estoque disponível baixados com sucesso.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Nenhum item foi salvo.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            if (_qtdMedicamentos > 0)            
                MessageBox.Show("Medicamentos de kit não podem mais ser baixados por esta funcionalidade.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
            _qtdMedicamentos = 0;

            return false;
        }
    }
}