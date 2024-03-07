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
using HacFramework.Windows.Helpers;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmSolicitacaoMaterial : FrmBase
    {
        public FrmSolicitacaoMaterial()
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
            get { return _pedidopadrao != null ? _pedidopadrao : _pedidopadrao = (IPedidoPadrao)Global.Common.GetObject( typeof(IPedidoPadrao)); }
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

        private void CarregarComboTipo()
        {
            Generico gen = new Generico();

            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.IMPRESSOS_MAT_EXPEDIENTE).ToString(), "IMPRESSOS E MATERIAIS DE EXPEDIENTE"));
            list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.HIGIENIZACAO).ToString(), "HIGIENIZAÇÃO"));
            if (gen.LogadoManutencao()) list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.MANUTENCAO).ToString(), "MANUTENÇÂO"));
            list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.OUTROS).ToString(), "OUTROS"));

            cmbTipo.ValueMember = ListItem.FieldNames.Key;
            cmbTipo.DisplayMember = ListItem.FieldNames.Value;
            cmbTipo.DataSource = list;
            if (gen.LogadoManutencao())
                cmbTipo.SelectedValue = ((byte)RequisicaoDTO.TipoRequisicao.MANUTENCAO).ToString();
            else
                cmbTipo.SelectedValue = ((byte)RequisicaoDTO.TipoRequisicao.IMPRESSOS_MAT_EXPEDIENTE).ToString();
        }
        
        private bool ValidarFilial()
        {
            if (!rbHac.Checked)
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
                dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;         
        }

        private void ConfiguraRequisicaoDTO()
        {
            dtoRequisicao = new RequisicaoDTO();

            dtoRequisicao.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoRequisicao.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoRequisicao.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.ABERTA;
            dtoRequisicao.FlPendente.Value = (byte)RequisicaoDTO.Pendente.NAO;
            dtoRequisicao.IdtTipoRequisicao.Value = cmbTipo.SelectedValue.ToString();
            if (rbHac.Checked)
                dtoRequisicao.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
        }

        /// <summary>
        /// Carrega valoes para o dto do pedido padrão
        /// </summary>
        private void ConfiguraPedidoPadraoDTO()
        {
            dtoPedidoPadrao = new PedidoPadraoDTO();

            dtoPedidoPadrao.IdtUnidade.Value = int.Parse(cmbUnidade.SelectedValue.ToString());
            dtoPedidoPadrao.IdtSetor.Value = int.Parse(cmbSetor.SelectedValue.ToString());
            dtoPedidoPadrao.IdtLocal.Value = int.Parse(cmbLocal.SelectedValue.ToString());
            dtoPedidoPadrao.Status.Value = (byte)PedidoPadraoDTO.StatusPedidoPadrao.CONFIRMADO;
            if (rbHac.Checked)
                dtoPedidoPadrao.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;            
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
            this.Cursor = Cursors.WaitCursor;
            ConfiguraRequisicaoDTO();

            dtbRequisicao = Requisicao.Sel(dtoRequisicao, false);
            
            if (dtbRequisicao.Rows.Count > 0)
            {
                dtoRequisicao = (RequisicaoDTO)dtbRequisicao.Rows[0];

                if (dtoRequisicao.Status.Value == (int)RequisicaoDTO.StatusRequisicao.ABERTA)
                {
                    cbStatus.Enabled = true;
                    cbStatus.Checked = false;
                }
                else if (dtoRequisicao.Status.Value == (int)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX)
                {
                    cbStatus.Enabled = false;
                    cbStatus.Checked = true;
                }

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
                cbStatus.Checked = true;
            }
            dtgMatMed.DataSource = dtbRequisicaoItem;
            cmbTipo.Enabled = false;
            if (new Generico().LogadoManutencao() && byte.Parse(cmbTipo.SelectedValue.ToString()) == (byte)RequisicaoDTO.TipoRequisicao.MANUTENCAO)
                dtgMatMed.Columns["colEstoqueLocal"].HeaderText = "Saldo Almox.";
            else
                dtgMatMed.Columns["colEstoqueLocal"].HeaderText = "Qtd. Local";
            this.Cursor = Cursors.Default;
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
                        dtoRequisicao.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                    
                    dtoRequisicao.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    dtoRequisicao = Requisicao.Gravar(dtoRequisicao, dtbRequisicaoItem);

                    dtbRequisicaoItem.AcceptChanges();

                    txtReqIdt.Text = dtoRequisicao.Idt.Value.ToString();

                    MessageBox.Show("Registro Salvo com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (cbStatus.Checked)
                    {
                        dtoRequisicao = null;
                        dtgMatMed.Enabled = false;
                    }
                    else
                        dtgMatMed.Enabled = true;
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

        private void VerificaCarrinhoEmergencia()
        {
            int? setorCarrEmergPai = new Generico().SetorCarrinhoEmergencia(int.Parse(cmbSetor.SelectedValue.ToString()));
            if (setorCarrEmergPai != null)
            {
                cmbSetor.SelectedIndex = -1;
                MessageBox.Show("Este setor é um Carrinho de Emergência não sendo permitido solicitar material ao mesmo.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }            
        }

        #endregion

        #region EVENTOS

        private void FrmSolicitacao_Load(object sender, EventArgs e)
        {
            cmbUnidade.Carregaunidade();
            Generico.ConfiguraCombos(cmbUnidade,cmbLocal,cmbSetor,FrmPrincipal.dtoSeguranca);
            CarregarComboTipo();
            ConfiguraDTG();
            VerificaCarrinhoEmergencia();
        }        

        private bool tsHac_MatMedClick(object sender)
        {
            if (!ValidarFilial()) return false;

            ConfiguraRequisicaoDTO();

            MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO(); ;            
            SetorDTO dtoSetor = new SetorDTO();

            dtoSetor.Idt.Value = dtoRequisicao.IdtSetor.Value;
            dtoSetor.IdtLocalAtendimento.Value = dtoRequisicao.IdtLocal.Value;
            dtoSetor.IdtUnidade.Value = dtoRequisicao.IdtUnidade.Value;

            dtoMatMed.IdtUnidade.Value = dtoSetor.IdtUnidade.Value;
            dtoMatMed.IdtLocal.Value = dtoSetor.IdtLocalAtendimento.Value;
            dtoMatMed.IdtSetor.Value = dtoSetor.Idt.Value;
            dtoMatMed.IdtFilial.Value = dtoRequisicao.IdtFilial.Value;            
            dtoMatMed.Tabelamedica.Value = ((int)MaterialMedicamentoDTO.TipoMatMed.MATERIAL).ToString();
            dtoMatMed.FlAtivo.Value = 1;

            if (cmbTipo.SelectedValue.ToString() == ((byte)RequisicaoDTO.TipoRequisicao.IMPRESSOS_MAT_EXPEDIENTE).ToString())
            {
                dtoMatMed.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.COM_PERMISSAO_SUBGRUPO;
                dtoMatMed.IdtGrupo.Value = 5; // IMPRESSOS
            }
            else if (cmbTipo.SelectedValue.ToString() == ((byte)RequisicaoDTO.TipoRequisicao.HIGIENIZACAO).ToString())
            {
                dtoMatMed.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.COM_PERMISSAO_SUBGRUPO;
                dtoMatMed.IdtGrupo.Value = 12; // HIGIENIZACAO
            }
            else if (cmbTipo.SelectedValue.ToString() == ((byte)RequisicaoDTO.TipoRequisicao.MANUTENCAO).ToString())
            {                
                dtoMatMed.IdtGrupo.Value = 8; // MANUTENCAO
            }
            else if (cmbTipo.SelectedValue.ToString() == ((byte)RequisicaoDTO.TipoRequisicao.OUTROS).ToString())
            {
                dtoMatMed.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.COM_PERMISSAO;                
            }

            // dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(dtoSetor, MaterialMedicamentoDTO.TipoMatMed.TODOS, (byte)dtoRequisicao.IdtFilial.Value);
            dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMed);

            if (dtoMatMed != null)
            {                
                if (dtbRequisicaoItem == null) dtbRequisicaoItem = new RequisicaoItensDataTable();
                if (dtbRequisicaoItem.Select(string.Format("{0} = {1}",
                                             RequisicaoItensDTO.FieldNames.IdtProduto,
                                             dtoMatMed.Idt.Value)).Length > 0)
                {
                    MessageBox.Show("Já foi adicionado o Material/Medicamento Selecionado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                ConfiguraPedidoPadraoDTO();

                if (PedidoPadrao.ProdutoPadrao(dtoPedidoPadrao, dtoMatMed))
                {
                    MessageBox.Show(string.Format("O Material/Medicamento {0} pertence ao Pedido Padrão deste setor e não pode ser requisitado", dtoMatMed.Descricao.Value),
                                    "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                dtoRequisicaoItem = RequisicaoItens.ConverteMatMedRequisicao(dtoMatMed);
                // verifica estoque local
                ConfiguraEstoqueDTO();
                if (new Generico().LogadoManutencao())
                {
                    dtoEstoque.IdtUnidade.Value = FrmPrincipal.dtoSeguranca.IdtUnidade.Value;
                    dtoEstoque.IdtLocal.Value = FrmPrincipal.dtoSeguranca.IdtLocal.Value;
                    dtoEstoque.IdtSetor.Value = FrmPrincipal.dtoSeguranca.IdtSetor.Value;
                }
                dtoEstoque = Estoque.EstoqueLocalProduto(dtoEstoque);
                dtoRequisicaoItem.EstoqueLocalQtde.Value = dtoEstoque.Qtde.Value;

                // Solicita quantidade
                dtoRequisicaoItem = FrmQtdMatMed.DigitaQtde(dtoRequisicaoItem);

                if (dtoRequisicaoItem != null)
                {
                    if (new Generico().LogadoManutencao())
                    {
                        if (dtoRequisicaoItem.EstoqueLocalQtde.Value.IsNull ||
                            dtoRequisicaoItem.EstoqueLocalQtde.Value < dtoRequisicaoItem.QtdSolicitada.Value)
                        {
                            MessageBox.Show("Item sem saldo suficiente no Estoque da Manutenção.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    // se for uma requisição já salva terá ID da requisição tem que atribuir ao dtoReq
                    if (txtReqIdt.Text.Length != 0)
                    {
                        dtoRequisicaoItem.Idt.Value = Convert.ToDecimal(txtReqIdt.Text);
                    }
                    try
                    {
                        if (dtbRequisicaoItem == null) dtbRequisicaoItem = new RequisicaoItensDataTable();
                        dtbRequisicaoItem.Add(dtoRequisicaoItem);
                        dtgMatMed.DataSource = dtbRequisicaoItem;
                        cmbTipo.Enabled = false;
                    }
                    //catch (ConstraintException ex)
                    //{
                    //    MessageBox.Show("Já foi adicionado o Material/Medicamento Selecionado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    return false;
                    //}
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
            dtgMatMed.Enabled = true;
            tsHac.Controla(Evento.eNovo);
            this.Carregar();
            return false;
        }

        private bool tsHac_CancelarClick(object sender)
        {
            cmbTipo.Enabled = dtgMatMed.Enabled = true;
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
            VerificaCarrinhoEmergencia();
        }

        private void rbHac_Click(object sender, EventArgs e)
        {
            this.Carregar();
        }

        private void rbAcs_Click(object sender, EventArgs e)
        {
            this.Carregar();
        }

        private void FrmSolicitacaoMaterial_FormClosing(object sender, FormClosingEventArgs e)
        {
            grbFilial.Enabled = false;
        }

        private void cmbTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //this.Carregar();
        }

        #endregion                                                                                            
    }
}