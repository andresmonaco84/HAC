using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmPedidoCarrinhoEmerg : FrmBase
    {
        public FrmPedidoCarrinhoEmerg()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇOS

        // Itens Requisição
        private RequisicaoItensDataTable dtbRequisicaoItem;
        private RequisicaoItensDTO dtoRequisicaoItem;
        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject( typeof(IRequisicaoItens)); }
        }

        // Requisição
        private RequisicaoDTO dtoRequisicao;
        private RequisicaoDataTable dtbRequisicao;
        private IRequisicao _requisicao;
        private IRequisicao Requisicao
        {
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject( typeof(IRequisicao)); }
        }

        // Estoque
        private EstoqueLocalDTO dtoEstoque;
        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject( typeof(IEstoqueLocal)); }
        }

        // Pedido Padrão        
        private PedidoPadraoDTO dtoPedidoPadrao;
        private IPedidoPadrao _pedidopadrao;
        private IPedidoPadrao PedidoPadrao
        {
            get { return _pedidopadrao != null ? _pedidopadrao : _pedidopadrao = (IPedidoPadrao)Global.Common.GetObject(typeof(IPedidoPadrao)); }
        }

        #endregion

        #region FUNÇÕES

        //private void ConfiguraCombos()
        //{
        //    if (FrmPrincipal.dtoSeguranca.IdtNivelSeguranca.Value == (int)SegurancaDTO.NivelSeguranca.OPERADOR)
        //    {
        //        cmbUnidade.Enabled = false;
        //        cmbUnidade.Editavel = ControleEdicao.Nunca;
        //        cmbUnidade.SelectedValue = FrmPrincipal.dtoSeguranca.IdtUnidade.Value;

        //        cmbLocal.Enabled = false;
        //        cmbLocal.Editavel = ControleEdicao.Nunca;
        //        cmbLocal.SelectedValue = FrmPrincipal.dtoSeguranca.IdtLocal.Value;

        //        cmbSetor.Enabled = false;
        //        cmbSetor.Editavel = ControleEdicao.Nunca;
        //        cmbSetor.SelectedValue = FrmPrincipal.dtoSeguranca.IdtSetor.Value;
        //    }
        //}

        private bool ValidarFilial()
        {
            if (!rbAcs.Checked && !rbHac.Checked)
            {
                MessageBox.Show("Selecione a Filial", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private bool Validar()
        {
            if (!ValidarFilial()) return false;

            return true;
        }

        private void ConfiguraEstoqueDTO()
        {
            dtoEstoque = new EstoqueLocalDTO();

            dtoEstoque.IdtUnidade.Value = dtoRequisicao.IdtUnidade.Value;
            dtoEstoque.IdtLocal.Value = dtoRequisicao.IdtLocal.Value;
            dtoEstoque.IdtSetor.Value = dtoRequisicao.IdtSetor.Value;
            dtoEstoque.IdtProduto.Value = dtoRequisicaoItem.IdtProduto.Value;
            dtoEstoque.IdtLote.Value = null;
            if (rbHac.Checked)
            {
                dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            }
            else if (rbAcs.Checked)
            {
                dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
            }
        }

        private void ConfiguraRequisicaoDTO()
        {
            dtoRequisicao = new RequisicaoDTO();

            dtoRequisicao.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoRequisicao.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoRequisicao.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.ABERTA;
            dtoRequisicao.IdtTipoRequisicao.Value = (byte)RequisicaoDTO.TipoRequisicao.CARRINHO_EMERGENCIA;
            if (rbHac.Checked)
            {
                dtoRequisicao.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            }
            else if (rbAcs.Checked)
            {
                dtoRequisicao.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
            }
        }

        private void ConfiguraPedidoPadraoDTO()
        {
            dtoPedidoPadrao = new PedidoPadraoDTO();

            dtoPedidoPadrao.IdtUnidade.Value = int.Parse(cmbUnidade.SelectedValue.ToString());
            dtoPedidoPadrao.IdtSetor.Value = int.Parse(cmbSetor.SelectedValue.ToString());
            dtoPedidoPadrao.IdtLocal.Value = int.Parse(cmbLocal.SelectedValue.ToString());
            dtoPedidoPadrao.Status.Value = (byte)PedidoPadraoDTO.StatusPedidoPadrao.CONFIRMADO;
            if (rbHac.Checked)
            {
                dtoPedidoPadrao.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
            }
            else if (rbAcs.Checked)
            {
                dtoPedidoPadrao.IdtFilial.Value = (int)FilialMatMedDTO.Filial.ACS;
            }
        }

        private void ConfiguraDTG()
        {
            dtgMatMed.AutoGenerateColumns = false;
            dtgMatMed.Columns["colReqItemIdt"].DataPropertyName = RequisicaoItensDTO.FieldNames.Idt;
            dtgMatMed.Columns["colMatMedIdt"].DataPropertyName = RequisicaoItensDTO.FieldNames.IdtProduto;
            dtgMatMed.Columns["colDsProd"].DataPropertyName = RequisicaoItensDTO.FieldNames.DsProduto;
            dtgMatMed.Columns["colDsUnidadeVenda"].DataPropertyName = RequisicaoItensDTO.FieldNames.DsUnidadeVenda;
            dtgMatMed.Columns["colQtde"].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdFornecida;
            dtgMatMed.Columns["colQtde"].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdSolicitada;
            dtgMatMed.Columns["colQtdeFornecida"].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdFornecida;
            dtgMatMed.Columns["colEstoqueLocal"].DataPropertyName = RequisicaoItensDTO.FieldNames.EstoqueLocalQtde;
        }

        private void Carregar()
        {
            ConfiguraRequisicaoDTO();

            dtbRequisicao = Requisicao.Sel(dtoRequisicao, false);

            if (dtbRequisicao.Rows.Count > 0)
            {
                dtoRequisicao = (RequisicaoDTO)dtbRequisicao.Rows[0];

                txtReqIdt.Text = dtoRequisicao.Idt.ToString();

                dtoRequisicaoItem = new RequisicaoItensDTO();

                dtoRequisicaoItem.Idt.Value = int.Parse(txtReqIdt.Text);

                dtbRequisicaoItem = RequisicaoItens.SelItensRequisicao(dtoRequisicaoItem, true);
                txtData.Text = ((DateTime)dtoRequisicao.DataAtualizacao.Value).ToString("dd/MM/yyyy");
            }
            else
            {
                txtReqIdt.Text = string.Empty;
                dtbRequisicaoItem = new RequisicaoItensDataTable();
                txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            dtgMatMed.DataSource = dtbRequisicaoItem;
        }

        private bool Salvar()
        {
            if (!Validar()) return false;

            try
            {
                if (dtbRequisicaoItem.Rows.Count != 0)
                {
                    dtoRequisicao.Status.Value = (int)(cbStatus.Checked ? RequisicaoDTO.StatusRequisicao.FECHADA : RequisicaoDTO.StatusRequisicao.ABERTA);

                    if (txtReqIdt.Text != string.Empty) dtoRequisicao.Idt.Value = int.Parse(txtReqIdt.Text);

                    if (rbHac.Checked)
                    {
                        dtoRequisicao.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                    }
                    else if (rbAcs.Checked)
                    {
                        dtoRequisicao.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
                    }
                    dtoRequisicao.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    dtoRequisicao = Requisicao.Gravar(dtoRequisicao, dtbRequisicaoItem);

                    dtbRequisicaoItem.AcceptChanges();

                    if (cbStatus.Checked)
                    {
                        tsHac.Controla(Evento.eCancelar);
                    }
                    else
                    {
                        txtReqIdt.Text = dtoRequisicao.Idt.Value.ToString();
                    }

                    MessageBox.Show("Registro Salvo com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Você não pode salvar uma requisição sem itens", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        #endregion

        #region EVENTOS

        private void FrmPedidoCarrinhoEmerg_Load(object sender, EventArgs e)
        {
            cmbUnidade.Carregaunidade();
            Generico.ConfiguraCombos(cmbUnidade, cmbLocal, cmbSetor, FrmPrincipal.dtoSeguranca);
            ConfiguraDTG();
        }

        private bool tsHac_MatMedClick(object sender)
        {
            if (!ValidarFilial()) return false;

            ConfiguraRequisicaoDTO();

            MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO(); ;
            
            dtoMatMed.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.SEM_ESTOQUE;

            dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMed);

            if (dtoMatMed == null) return false;
            if (dtoMatMed.Idt.Value.IsNull) return false;            

            if (dtbRequisicaoItem == null) dtbRequisicaoItem = new RequisicaoItensDataTable();
            if (dtbRequisicaoItem.Select(string.Format("{0} = {1}",
                                         RequisicaoItensDTO.FieldNames.IdtProduto,
                                         dtoMatMed.Idt.Value)).Length > 0)
            {
                MessageBox.Show("Já foi adicionado o Material/Medicamento Selecionado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            ConfiguraPedidoPadraoDTO();

            PedidoPadraoItensDTO dtoPedPadItem = new PedidoPadraoItensDTO();

            if (!PedidoPadrao.ProdutoPadrao(dtoPedidoPadrao, dtoMatMed, ref dtoPedPadItem, false))
            {
                MessageBox.Show(string.Format("O Material/Medicamento {0} tem que pertencer ao Estoque Padrão para poder ser requisitado", dtoMatMed.NomeFantasia.Value),
                                "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }

            if (dtoMatMed != null)
            {
                dtoRequisicaoItem = RequisicaoItens.ConverteMatMedRequisicao(dtoMatMed);
                // verifica estoque local
                ConfiguraEstoqueDTO();
                dtoEstoque = Estoque.EstoqueLocalProduto(dtoEstoque);
                dtoRequisicaoItem.EstoqueLocalQtde.Value = dtoEstoque.Qtde.Value;

                // Solicita quantidade
                dtoRequisicaoItem = FrmQtdMatMed.DigitaQtde(dtoRequisicaoItem);

                if (dtoRequisicaoItem != null)
                {
                    if (!dtoRequisicaoItem.EstoqueLocalQtde.Value.IsNull &&
                        !dtoRequisicaoItem.QtdSolicitada.Value.IsNull)
                    {
                        if ((decimal)dtoRequisicaoItem.EstoqueLocalQtde.Value > 0)
                        {
                            if ((decimal)dtoRequisicaoItem.QtdSolicitada.Value <= (decimal)dtoRequisicaoItem.EstoqueLocalQtde.Value)
                            {
                                MessageBox.Show(string.Format("O Material/Medicamento {0} não pode ser requisitado, pois já existe quantidade suficiente no estoque local.", dtoMatMed.NomeFantasia.Value),
                                                              "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                            else if ((decimal)dtoRequisicaoItem.QtdSolicitada.Value > (decimal)dtoRequisicaoItem.EstoqueLocalQtde.Value)
                            {
                                dtoRequisicaoItem.QtdSolicitada.Value = dtoRequisicaoItem.QtdFornecida.Value;
                                dtoRequisicaoItem.QtdFornecida.Value = 0;

                                if (dtoRequisicaoItem.EstoqueLocalQtde.Value != 0)
                                {
                                    if (dtoRequisicaoItem.EstoqueLocalQtde.Value >= dtoPedPadItem.Qtde.Value)
                                    {
                                        MessageBox.Show(string.Format("O Material/Medicamento {0} não pode ser requisitado, pois já está cheio no setor, de acordo com o estoque padrão.", dtoMatMed.NomeFantasia.Value),
                                                              "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return false;
                                    }
                                    else
                                    {
                                        if ((decimal)dtoRequisicaoItem.QtdSolicitada.Value > (decimal)dtoPedPadItem.Qtde.Value)
                                        {
                                            dtoRequisicaoItem.QtdSolicitada.Value = dtoPedPadItem.Qtde.Value;
                                            MessageBox.Show(string.Format("Já existe {2} {0} no estoque local!!!\n\nA QUANTIDADE REQUISITADA SERÁ DE {1}, QUE É O LIMITE DO ESTOQUE PADRÃO",
                                                            dtoMatMed.NomeFantasia.Value, dtoRequisicaoItem.QtdSolicitada.Value, dtoRequisicaoItem.EstoqueLocalQtde.Value),
                                                            "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                        else
                                        {
                                            MessageBox.Show(string.Format("Já existe {2} {0} no estoque local!!!\n\nA QUANTIDADE REQUISITADA SERÁ DE {1}",
                                                            dtoMatMed.NomeFantasia.Value, dtoRequisicaoItem.QtdSolicitada.Value, dtoRequisicaoItem.EstoqueLocalQtde.Value),
                                                            "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }                                    
                                    }                                    
                                }
                                else
                                {
                                    if ((decimal)dtoRequisicaoItem.QtdSolicitada.Value > (decimal)dtoPedPadItem.Qtde.Value)
                                    {
                                        MessageBox.Show(string.Format("Quantidade requisitada de {0} não pode ser maior que o seu estoque padrão que é {1}.", dtoMatMed.NomeFantasia.Value, dtoPedPadItem.Qtde.Value),
                                                                      "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if ((decimal)dtoRequisicaoItem.QtdSolicitada.Value > (decimal)dtoPedPadItem.Qtde.Value)
                            {
                                MessageBox.Show(string.Format("Quantidade requisitada de {0} não pode ser maior que o seu estoque padrão que é {1}.", dtoMatMed.NomeFantasia.Value, dtoPedPadItem.Qtde.Value),
                                                              "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                        }                        
                    }

                    // se for uma requisição já salva terá ID da requisição tem que atribuir ao dtoReq
                    if (txtReqIdt.Text.Length != 0) dtoRequisicaoItem.Idt.Value = Convert.ToDecimal(txtReqIdt.Text);
                    
                    try
                    {                        
                        dtbRequisicaoItem.Add(dtoRequisicaoItem);
                        dtgMatMed.DataSource = dtbRequisicaoItem;
                    }                    
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }

        private bool tsHac_NovoClick(object sender)
        {
            return true;
        }

        private bool tsHac_SalvarClick(object sender)
        {
            return this.Salvar();
        }

        private void dtgMatMed_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgMatMed.Columns[e.ColumnIndex].Name == "colDeletar")
            {
                if (MessageBox.Show("Deseja deletar esse produto da lista ?",
                                     "Gestão de Materiais e Medicamentos",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int nCount = 0; nCount < dtbRequisicaoItem.Rows.Count; nCount++)
                    {
                        if (dtbRequisicaoItem.Rows[nCount].RowState != DataRowState.Deleted)
                        {
                            if (dtbRequisicaoItem.Rows[nCount][RequisicaoItensDTO.FieldNames.IdtProduto].ToString() == dtgMatMed.Rows[e.RowIndex].Cells["colMatMedIdt"].Value.ToString())
                            {
                                dtbRequisicaoItem.Rows[nCount].Delete();
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void cmbUnidade_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tsHac.Controla(Evento.eCancelar);
        }

        private void cmbLocal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tsHac.Controla(Evento.eCancelar);
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tsHac.Controla(Evento.eCancelar);
        }

        private void rbHac_Click(object sender, EventArgs e)
        {
            this.Carregar();
        }

        private void rbAcs_Click(object sender, EventArgs e)
        {
            this.Carregar();
        }

        private void FrmPedidoCarrinhoEmerg_FormClosing(object sender, FormClosingEventArgs e)
        {
            grbFilial.Enabled = false;
        }

        #endregion                       
    }
}