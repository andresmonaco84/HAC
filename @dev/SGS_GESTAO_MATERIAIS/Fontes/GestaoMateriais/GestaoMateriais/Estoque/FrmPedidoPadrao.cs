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
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    public partial class FrmPedidoPadrao : FrmBase
    {
        public FrmPedidoPadrao()
        { 
            InitializeComponent();        
        }

        #region OBJETOS SERVIÇO

        private int? _setorCarrEmergPai = null;

        // Pedido Padrão
        private PedidoPadraoDataTable dtbPedidoPadrao;
        private PedidoPadraoDTO dtoPedidoPadrao;
        private IPedidoPadrao _pedidopadrao;
        private IPedidoPadrao PedidoPadrao
        {
            get { return _pedidopadrao != null ? _pedidopadrao : _pedidopadrao = (IPedidoPadrao)Global.Common.GetObject(typeof(IPedidoPadrao)); }
        }

        // Itens de Pedido Padrão        
        private PedidoPadraoItensDTO dtoPedidoPadraoItens;
        private PedidoPadraoItensDataTable dtbPedidoPadraoItens;

        // Itens Requisição        
        private RequisicaoItensDTO dtoRequisicaoItem;
        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }                

        // Estoque
        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject(typeof(IEstoqueLocal)); }
        }
        private EstoqueLocalDTO dtoEstoque;

        private IMatMedSetorConfig _matMedConfig;
        private IMatMedSetorConfig MatMedSetorConfig
        {
            get { return _matMedConfig != null ? _matMedConfig : _matMedConfig = (IMatMedSetorConfig)Global.Common.GetObject(typeof(IMatMedSetorConfig)); }
        }

        #endregion

        #region MÉTODOS
        

        /// <summary>
        /// Carrega valoes para o dto do pedido padrão
        /// </summary>
        /// 
        private void ConfiguraPedidoPadraoDTO()
        {
            dtoPedidoPadrao = new PedidoPadraoDTO();

            dtoPedidoPadrao.IdtUnidade.Value = int.Parse(cmbUnidade.SelectedValue.ToString());
            dtoPedidoPadrao.IdtSetor.Value = int.Parse(cmbSetor.SelectedValue.ToString());
            dtoPedidoPadrao.IdtLocal.Value = int.Parse(cmbLocal.SelectedValue.ToString());

            if (rbHac.Checked)
            {
                dtoPedidoPadrao.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
            }
            else if (rbAcs.Checked)
            {
                dtoPedidoPadrao.IdtFilial.Value = (int)FilialMatMedDTO.Filial.ACS;
            }
            else if (rbCE.Checked)
            {
                dtoPedidoPadrao.IdtFilial.Value = (int)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
            }
        }

        private bool ValidarFilial()
        {
            if (!rbAcs.Checked && !rbHac.Checked && !rbCE.Checked)  
            {
                MessageBox.Show("Selecione o estoque (HAC/ACS/CE)", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private bool Validar()
        {

            EstoqueLocalDTO dtoEstoqueCentDisp = new EstoqueLocalDTO();
            dtoEstoqueCentDisp.IdtUnidade.Value = int.Parse(cmbUnidade.SelectedValue.ToString());
            dtoEstoqueCentDisp.IdtSetor.Value = int.Parse(cmbSetor.SelectedValue.ToString());
            dtoEstoqueCentDisp.IdtLocal.Value = int.Parse(cmbLocal.SelectedValue.ToString());
            decimal QtdeEstoque = 0;
            decimal QtdePadrao = 0;
            bool EstoqueCentroDispensacao = Estoque.EstoqueCentroDispensacao(dtoEstoqueCentDisp);
            if (!ValidarFilial()) return false;

            if (txtPeriodo.Text == string.Empty)
            {
                MessageBox.Show("Digite o Período", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPeriodo.Focus();
                return false;
            }

            foreach (DataGridViewRow dtgRow in dtgMatMed.Rows)
            {
                QtdeEstoque = decimal.Parse(dtgRow.Cells["colQtdeEstoque"].EditedFormattedValue.ToString());
                QtdePadrao = decimal.Parse(dtgRow.Cells["colQtdePadrao"].EditedFormattedValue.ToString());

                if (string.Format("{0}", dtgRow.Cells["colPercRessuprimento"].Value) == string.Empty)
                {
                    MessageBox.Show("Est. Mínimo deve ser informado",
                                    "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if ((QtdePadrao < QtdeEstoque) && !EstoqueCentroDispensacao )
                {
                    MessageBox.Show(string.Format("Qtd. Padrão do item {0} não pode ser menor do que já existe no Est. Local", dtgRow.Cells["colDsProduto"].Value.ToString()),
                                    "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                    
                    return false;
                }
                if (long.Parse(dtgRow.Cells["colMatMedPrincAt"].Value.ToString()) != 0)
                {
                    if (dtbPedidoPadraoItens.Select(string.Format("{0} = {1}",
                                                PedidoPadraoItensDTO.FieldNames.IdtPrincipioAtivo,
                                                dtgRow.Cells["colMatMedPrincAt"].Value)).Length > 1) // && !EstoqueCentroDispensacao)
                    {
                        MessageBox.Show(string.Format("O item {0} não pode ter um similar nesta lista", dtgRow.Cells["colDsProduto"].Value.ToString()),
                                        "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }                                
            }

            return true;
        }

        /// <summary>
        /// Verifica se os Combos estão preenchidos, muda estado dos botões, carrega o dto
        /// </summary>
        private void Carregar()
        {
            this.Cursor = Cursors.WaitCursor;
            lblTotalLst.Text = string.Empty;
            ConfiguraPedidoPadraoDTO();

            dtbPedidoPadrao = PedidoPadrao.Sel(dtoPedidoPadrao);
                        
            txtDataDispensacao.Text = string.Empty;
            txtDataUltReq.Text = string.Empty;
            cbStatus.Checked = false;

            if (dtbPedidoPadrao.Rows.Count > 0)
            {
                dtoPedidoPadrao = (PedidoPadraoDTO)dtbPedidoPadrao.Rows[0];
                txtPeriodo.Text = dtoPedidoPadrao.Periodo.Value;
                if (!dtoPedidoPadrao.DataDispensado.Value.IsNull) txtDataDispensacao.Text = ((DateTime)dtoPedidoPadrao.DataDispensado.Value).ToString("dd/MM/yyyy HH:mm:ss");
                if (!dtoPedidoPadrao.DataUltimaRequisicao.Value.IsNull) txtDataUltReq.Text = ((DateTime)dtoPedidoPadrao.DataUltimaRequisicao.Value).ToString("dd/MM/yyyy HH:mm:ss");
                if (byte.Parse(dtoPedidoPadrao.Status.Value) == (byte)PedidoPadraoDTO.StatusPedidoPadrao.CONFIRMADO) cbStatus.Checked = true;
                dtbPedidoPadraoItens = PedidoPadrao.SelItens(dtoPedidoPadrao);
                lblTotalLst.Text = dtbPedidoPadraoItens.Rows.Count.ToString(); 
            }
            else
            {
                txtPeriodo.Text = string.Empty;
                dtbPedidoPadraoItens = new PedidoPadraoItensDataTable();
            }

            dtgMatMed.DataSource = dtbPedidoPadraoItens;
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Configura Colunas do DataGrid baseado nos campos do dto
        /// </summary>
        private void ConfiguraDTG()
        {
            dtgMatMed.AutoGenerateColumns = false;
            dtgMatMed.Columns["colMatMedPrincAt"].DataPropertyName = PedidoPadraoItensDTO.FieldNames.IdtPrincipioAtivo;
            dtgMatMed.Columns["colMatMedIdt"].DataPropertyName = PedidoPadraoItensDTO.FieldNames.IdtProduto;
            dtgMatMed.Columns["colDsProduto"].DataPropertyName = PedidoPadraoItensDTO.FieldNames.DsProduto;            

            dtgMatMed.Columns["colQtdePadrao"].DataPropertyName = PedidoPadraoItensDTO.FieldNames.Qtde;
            dtgMatMed.Columns["colQtdePadrao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgMatMed.Columns["colQtdePadrao"].DefaultCellStyle.Format = "N0";

            dtgMatMed.Columns["colQtdeEstoque"].DataPropertyName = PedidoPadraoItensDTO.FieldNames.EstoqueLocalQtde;
            dtgMatMed.Columns["colQtdeEstoque"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgMatMed.Columns["colQtdeEstoque"].DefaultCellStyle.Format = "N0";

            dtgMatMed.Columns["colQtdeFornecer"].DataPropertyName = PedidoPadraoItensDTO.FieldNames.Fornecer;
            dtgMatMed.Columns["colQtdeFornecer"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgMatMed.Columns["colQtdeFornecer"].DefaultCellStyle.Format = "N0";

            dtgMatMed.Columns["colConsumido"].DataPropertyName = PedidoPadraoItensDTO.FieldNames.Consumido;
            dtgMatMed.Columns["colConsumido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgMatMed.Columns["colConsumido"].DefaultCellStyle.Format = "N0";

            dtgMatMed.Columns["colPercentual"].DataPropertyName = PedidoPadraoItensDTO.FieldNames.Percentual;
            dtgMatMed.Columns["colPercentual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

            dtgMatMed.Columns["colPercRessuprimento"].DataPropertyName = PedidoPadraoItensDTO.FieldNames.PontoRessuprimento;
            dtgMatMed.Columns["colPercRessuprimento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgMatMed.Columns["colPercRessuprimento"].DefaultCellStyle.Format = "N0";

            dtgMatMed.Columns["colDtAtu"].DataPropertyName = PedidoPadraoItensDTO.FieldNames.DataAtualizado;
            dtgMatMed.Columns["colDtAtu"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgMatMed.Columns["colDtRess"].DataPropertyName = PedidoPadraoItensDTO.FieldNames.DataRessupri;
            dtgMatMed.Columns["colDtRess"].DefaultCellStyle.Format = "dd/MM/yyyy";

        }

        private void ConfiguraEstoqueDTO()
        {
            dtoEstoque = new EstoqueLocalDTO();

            dtoEstoque.IdtUnidade.Value = dtoPedidoPadrao.IdtUnidade.Value;
            dtoEstoque.IdtLocal.Value = dtoPedidoPadrao.IdtLocal.Value;
            dtoEstoque.IdtSetor.Value = dtoPedidoPadrao.IdtSetor.Value;
            dtoEstoque.IdtProduto.Value = dtoPedidoPadraoItens.IdtProduto.Value;
            if (rbHac.Checked)
            {
                dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            }
            else if (rbAcs.Checked)
            {
                dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
            }
            else if (rbCE.Checked)
            {
                dtoEstoque.IdtFilial.Value = (int)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
            }
        }

        private bool Salvar()
        {
            this.AtualizaGridEmEdicao();
            if (!Validar()) return false;
            try
            {
                if (dtbPedidoPadraoItens.Rows.Count != 0)
                {
                    dtoPedidoPadrao.Status.Value = (byte)(cbStatus.Checked ? PedidoPadraoDTO.StatusPedidoPadrao.CONFIRMADO : PedidoPadraoDTO.StatusPedidoPadrao.CONFIRMAR);
                    dtoPedidoPadrao.Periodo.Value = decimal.Parse(txtPeriodo.Text);
                    dtoPedidoPadrao.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    PedidoPadrao.Gravar(dtoPedidoPadrao, dtbPedidoPadraoItens);
                    dtbPedidoPadraoItens.AcceptChanges();                    
                    MessageBox.Show("Registro Salvo com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Você não pode salvar um pedido sem itens", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        /// Solução alternativa para atualizar o grid quando está em edição.        
        private void AtualizaGridEmEdicao()
        {
            chkAjudaAtualizarGrid.Visible = true;
            chkAjudaAtualizarGrid.Focus();
            chkAjudaAtualizarGrid.Visible = false;
        }

        private void VerificaEstoqueUnificado()
        {
            _setorCarrEmergPai = new Generico().SetorCarrinhoEmergencia(int.Parse(cmbSetor.SelectedValue.ToString()));
            if (_setorCarrEmergPai != null)
            {
                this.ConfigurarControles(grbFilial.Controls, false);
                rbAcs.Editavel = ControleEdicao.Nunca;
                rbCE.Checked = true;
                this.Carregar();
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
                rbAcs.Enabled = false;
                rbAcs.Editavel = ControleEdicao.Nunca;
                //rbCE.Text = "EU";
                //rbCE.Checked = true;
                //grbFilial.Visible = false;
                lblEstoqueUnificado.Text = "ESTOQUE ÚNICO HAC";
                //lblEstoqueUnificado.Text = string.Empty;
            }
            else
            {
                rbAcs.Editavel = ControleEdicao.NovoRegistro;
                //rbAcs.Enabled = true;
                rbCE.Text = "CE";
                //rbCE.Checked = false;
                grbFilial.Visible = true;
                lblEstoqueUnificado.Text = string.Empty;
            }
        }

        #endregion

        #region EVENTOS

        private void FrmPedidoPadrao_Load(object sender, EventArgs e)
        {
            cmbUnidade.Carregaunidade();
            Generico.ConfiguraCombos(cmbUnidade, cmbLocal, cmbSetor, FrmPrincipal.dtoSeguranca);
            VerificaEstoqueUnificado();
            ConfiguraDTG();
        }

        private void rbAcs_Click(object sender, EventArgs e)
        {
            this.Carregar();     
        }

        private void rbHac_Click(object sender, EventArgs e)
        {
            this.Carregar();
        }

        private void rbCE_Click(object sender, EventArgs e)
        {
            this.Carregar();
        }
        
        private void FrmPedidoPadrao_FormClosing(object sender, FormClosingEventArgs e)
        {
           grbFilial.Enabled = false;
        }

        private void btnDispensar_Click(object sender, EventArgs e)
        {
            // PedidoPadrao.GeraRequisicao(dtoPedidoPadrao);
            MessageBox.Show("Requisição Gerada Com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool tsHac_NovoClick(object sender)
        {
            return true;
        }

        private bool tsHac_AfterNovo(object sender)
        {
            if (_setorCarrEmergPai == null)
            {
                this.ConfigurarControles(grbFilial.Controls, true);
                if (!string.IsNullOrEmpty(lblEstoqueUnificado.Text))
                {
                    rbAcs.Enabled = false;
                    rbAcs.Editavel = ControleEdicao.Nunca;
                }
            }
            else
            {
                rbCE.Checked = true;
                this.Carregar();
            }            
            return true;
        }

        private bool tsHac_CancelarClick(object sender)
        {
            this.ConfigurarControles(grbFilial.Controls, false);
            rbCE.Checked = false;
            return true;
        }
        
        private bool tsHac_SalvarClick(object sender)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.Salvar())
            {
                this.Cursor = Cursors.Default;
                return true;
            }
            else
            {
                this.Cursor = Cursors.Default;
                return false;
            }            
        }

        private bool tsHac_MatMedClick(object sender)
        {
            if (!ValidarFilial()) return false;

            MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();

            if (rbAcs.Checked)
            {
                dtoMatMed.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
            }
            else if (rbHac.Checked)
            {
                dtoMatMed.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            }

            dtoMatMed.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoMatMed.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoMatMed.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoMatMed.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.SEM_ESTOQUE;

            // dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(MaterialMedicamentoDTO.TipoMatMed.TODOS, (byte)dtoMatMed.IdtFilial.Value);
            dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMed);

            if (dtoMatMed != null)
            {
                if (dtbPedidoPadraoItens == null) dtbPedidoPadraoItens = new PedidoPadraoItensDataTable();
                if (dtbPedidoPadraoItens.Select(string.Format("{0} = {1}",
                                                PedidoPadraoItensDTO.FieldNames.IdtProduto,
                                                dtoMatMed.Idt.Value)).Length > 0)
                {
                    MessageBox.Show("Já foi adicionado o Material/Medicamento Selecionado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                if (rbAcs.Checked)
                {
                    if ((dtoMatMed.Tabelamedica.Value == ((int)MaterialMedicamentoDTO.TipoMatMed.MATERIAL).ToString() ||
                         dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM))
                    {
                        MessageBox.Show("Este produto é fracionado ou é um material e não pode existir no estoque do ACS", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }

                // converto dto MatMed para dto RequisicaoItem
                dtoPedidoPadraoItens = PedidoPadrao.ConverteMatMedPedidoPadrao(dtoMatMed);

                // verifica estoque local
                ConfiguraEstoqueDTO();
                dtoEstoque = Estoque.EstoqueLocalProduto(dtoEstoque);
                dtoPedidoPadraoItens.EstoqueLocalQtde.Value = dtoEstoque.Qtde.Value;

                // Solicita quantidade
                dtoPedidoPadraoItens = FrmQtdMatMed.DigitaQtde(dtoPedidoPadraoItens);                

                if (dtoPedidoPadraoItens != null)
                {
                    try
                    {
                        dtoPedidoPadraoItens.PontoRessuprimento.Value = 30;
                        dtbPedidoPadraoItens.Add(dtoPedidoPadraoItens);
                        dtgMatMed.DataSource = dtbPedidoPadraoItens;
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
            VerificaEstoqueUnificado();
        }

        private void dtgMatMed_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgMatMed.Columns[e.ColumnIndex].Name == "colDeletar")
            {
                if (MessageBox.Show("Deseja deletar esse produto da lista ?",
                                     "Gestão de Materiais e Medicamentos",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int nCount = 0; nCount < dtbPedidoPadraoItens.Rows.Count; nCount++)
                    {
                        if (dtbPedidoPadraoItens.Rows[nCount].RowState != DataRowState.Deleted)
                        {
                            if (dtbPedidoPadraoItens.Rows[nCount][RequisicaoItensDTO.FieldNames.IdtProduto].ToString() == dtgMatMed.Rows[e.RowIndex].Cells["colMatMedIdt"].Value.ToString())
                            {
                                dtbPedidoPadraoItens.Rows[nCount].Delete();
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void dtgMatMed_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgMatMed.Columns[e.ColumnIndex].Name == "colQtdePadrao")
            {
                for (int nCount = 0; nCount < dtbPedidoPadraoItens.Rows.Count; nCount++)
                {
                    if (dtbPedidoPadraoItens.Rows[nCount].RowState != DataRowState.Deleted)
                    {
                        if (dtbPedidoPadraoItens.Rows[nCount][RequisicaoItensDTO.FieldNames.IdtProduto].ToString() == dtgMatMed.Rows[e.RowIndex].Cells["colMatMedIdt"].Value.ToString())
                        {
                            dtoRequisicaoItem = new RequisicaoItensDTO();                            

                            if (!string.IsNullOrEmpty(dtgMatMed.Rows[e.RowIndex].Cells["colQtdePadrao"].Value.ToString()))
                            {
                                dtoRequisicaoItem.QtdSolicitada.Value = dtgMatMed.Rows[e.RowIndex].Cells["colQtdePadrao"].Value.ToString();
                            }

                            if (!string.IsNullOrEmpty(dtgMatMed.Rows[e.RowIndex].Cells["colQtdeEstoque"].Value.ToString()))
                            {
                                dtoRequisicaoItem.EstoqueLocalQtde.Value = dtgMatMed.Rows[e.RowIndex].Cells["colQtdeEstoque"].Value.ToString();
                            }
                            
                            //dtoRequisicaoItem = RequisicaoItens.CalculaQtdFornecidaAlmoxarifado(dtoRequisicaoItem);

                            // dtgMatMed.Rows[e.RowIndex].Cells["colQtdeFornecer"].Value = dtoRequisicaoItem.QtdFornecida.Value;
                            break;
                        }
                    }
                }
            }
        }

        private void dtgMatMed_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dtgMatMed.Columns[e.ColumnIndex].Name == "colQtdePadrao")
            {
                if (!this.IsNumber(e.FormattedValue.ToString()))
                {
                    tsHac.Enabled = false;
                    MessageBox.Show("Qtde Padrão deve ser numérico", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                    
                    e.Cancel = true;
                }
                else if (e.FormattedValue.ToString().IndexOf(',') > -1)
                {
                    tsHac.Enabled = false;
                    MessageBox.Show("Qtde Padrão deve ser um número inteiro", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
                else if (decimal.Parse(e.FormattedValue.ToString()) <= 0)
                {
                    tsHac.Enabled = false;
                    MessageBox.Show("Qtde Padrão deve ser maior que 0", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }                
            }
            if (dtgMatMed.Columns[e.ColumnIndex].Name == "colPercRessuprimento")
            {
                if (!this.IsNumber(e.FormattedValue.ToString()))
                {
                    tsHac.Enabled = false;
                    MessageBox.Show("Est. Mínimo deve ser numérico", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
                else if (e.FormattedValue.ToString().IndexOf(',') > -1)
                {
                    tsHac.Enabled = false;
                    MessageBox.Show("Est. Mínimo deve ser um número inteiro", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
                else if ((decimal.Parse(e.FormattedValue.ToString()) <= 0) || (decimal.Parse(e.FormattedValue.ToString()) > 100))
                {
                    tsHac.Enabled = false;
                    MessageBox.Show("Est. Mínimo deve estar entre 1 e 100", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
            }
        }

        private void dtgMatMed_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            tsHac.Enabled = true;
        }       

        #endregion        
    }
}