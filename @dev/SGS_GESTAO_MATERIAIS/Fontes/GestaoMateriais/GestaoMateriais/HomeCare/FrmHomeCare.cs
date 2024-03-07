using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.Services.BeneficiarioACS.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Impressao;
using HospitalAnaCosta.SGS.Componentes;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmHomeCare : FrmBase
    {
        public FrmHomeCare()
        {
            InitializeComponent();
        }

        #region Objetos Serviço

        // MovimentacaoTipoCCusto
        private LocalEstoqueDTO dtoLocalEstoque;
        private ILocalEstoque _movimentacaoTipoCCusto;
        private ILocalEstoque MovimentacaoTipoCCusto
        {
            get { return _movimentacaoTipoCCusto != null ? _movimentacaoTipoCCusto : _movimentacaoTipoCCusto = (ILocalEstoque)Global.Common.GetObject(typeof(ILocalEstoque)); }
        }

        // Material Medicamento
        // private MaterialMedicamentoDataTable dtbMaterialMedicamento;
        private MaterialMedicamentoDTO dtoMaterialMedicamento;
        private IMaterialMedicamento _materialMedicamento;
        private IMaterialMedicamento MaterialMedicamento
        {
            get { return _materialMedicamento != null ? _materialMedicamento : _materialMedicamento = (IMaterialMedicamento)Global.Common.GetObject( typeof(IMaterialMedicamento)); }
        }

        // Movimentos
        private MovimentacaoDTO dtoMovimento = new MovimentacaoDTO();
        private MovimentacaoDataTable dtbMovimento;
        private MovimentacaoDataTable dtbMovimentoHistorico;
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject( typeof(IMovimentacao)); }
        }

        // Beneficiario
        private BenefHomeCareDTO dtoBeneficiario;        

        // Itens Requisição
        private RequisicaoItensDataTable dtbReqItem;
        private RequisicaoItensDTO dtoReqItem;
        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }

        // Requisição
        private RequisicaoDTO dtoRequisicao;
        private IRequisicao _requisicao;
        private IRequisicao Requisicao
        {
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject(typeof(IRequisicao)); }
        }

        #endregion                

        #region MÉTODOS

        private void ConfiguraCombos()
        {
            //if (FrmPrincipal.dtoSeguranca.IdtNivelSeguranca.Value == (int)SegurancaDTO.NivelSeguranca.OPERADOR)
            //{
            // FORÇA HOME CARE 
            cmbUnidade.Enabled = false;
            cmbUnidade.Editavel = ControleEdicao.Nunca;
            cmbUnidade.SelectedValue = FrmPrincipal.dtoSeguranca.IdtUnidade.Value;

            cmbLocal.Enabled = false;
            cmbLocal.Editavel = ControleEdicao.Nunca;
            cmbLocal.SelectedValue = FrmPrincipal.dtoSeguranca.IdtLocal.Value;

            cmbSetor.Enabled = false;
            cmbSetor.Editavel = ControleEdicao.Nunca;
            cmbSetor.SelectedValue = FrmPrincipal.dtoSeguranca.IdtSetor.Value;
            //}
        }       

        private bool Validar()
        {
            foreach (DataGridViewRow dtgRow in dtgMatMed.Rows)
            {
                if (string.Format("{0}", dtgRow.Cells["colQtde"].Value) == string.Empty)
                {
                    MessageBox.Show("A quantidade deve ser informada",
                                    "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }                
            }
         
            return true;
        }        

        /// <summary>
        /// Configura Colunas do DataGrid baseado nos campos do dto
        /// </summary>
        private void ConfiguraDTG()
        {
            dtgMatMed.AutoGenerateColumns = false;
            dtgMatMed.Columns["colMatMedIdt"].DataPropertyName = MovimentacaoDTO.FieldNames.IdtProduto;
            dtgMatMed.Columns["colDsProduto"].DataPropertyName = MovimentacaoDTO.FieldNames.DsProduto;
            dtgMatMed.Columns["colQtde"].DataPropertyName = MovimentacaoDTO.FieldNames.Qtde;
            dtgMatMed.Columns["colQtde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgMatMed.Columns["colQtde"].DefaultCellStyle.Format = "N0";
            // 
            dtgHistoricoCCusto.AutoGenerateColumns = false;
            dtgHistoricoCCusto.Columns["colReqId"].DataPropertyName = MovimentacaoDTO.FieldNames.IdtRequisicao;
            dtgHistoricoCCusto.Columns["colDsProdutoHist"].DataPropertyName = MovimentacaoDTO.FieldNames.DsProduto;
            dtgHistoricoCCusto.Columns["colDtMov"].DataPropertyName = MovimentacaoDTO.FieldNames.DataMovimento;
            dtgHistoricoCCusto.Columns["colQtdeHist"].DataPropertyName = MovimentacaoDTO.FieldNames.Qtde;
            // dtgHistoricoCCusto.Columns["colIdtMov"].DataPropertyName = MovimentacaoDTO.FieldNames.Idt;
            dtgHistoricoCCusto.Columns["colDtMov"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dtgHistoricoCCusto.Columns["colMovId"].DataPropertyName = MovimentacaoDTO.FieldNames.Idt;
            
            // 

        }        

        private bool Salvar()
        {           
            this.AtualizaGridEmEdicao();
            if (!this.Validar()) return false;
            try
            {
                if (this.dtbMovimento.Rows.Count > 0)
                {
                    dtoRequisicao = new RequisicaoDTO();

                    dtoRequisicao.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                    dtoRequisicao.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                    dtoRequisicao.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                    //dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao. ;
                    dtoRequisicao.IdtTipoRequisicao.Value = (byte)RequisicaoDTO.TipoRequisicao.INTERNACAO_DOMICILIAR;
                    dtoRequisicao.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
                    dtoRequisicao.IdtAtendimento.Value = Convert.ToDecimal(txtCodPac.Text);
                    dtoRequisicao.TpAtendimento.Value = "H";

                    dtoRequisicao = Requisicao.Ins(dtoRequisicao);

                    dtbReqItem = new RequisicaoItensDataTable();
                }
                for (short i = 0; i < this.dtbMovimento.Rows.Count; ++i)
                {                    
                    dtoMovimento = this.dtbMovimento.TypedRow(i);
                    //Adiciona o item na requisição
                    dtoReqItem = new RequisicaoItensDTO();

                    dtoReqItem.IdtProduto.Value = dtoMovimento.IdtProduto.Value;
                    dtoReqItem.QtdSolicitada.Value = dtoMovimento.Qtde.Value;
                    dtbReqItem.Add(dtoReqItem);
                    
                    // UNIDADE DE ORIGEM ( BAIXA NO ESTOQUE )
                    this.dtoMovimento.IdtLocalEstoque.Value = this.dtoLocalEstoque.IdtLocalEstoque.Value;
                    // UNIDADE DE DESTINO ( DESPESA )
                    this.dtoMovimento.IdtUnidade.Value = decimal.Parse(cmbUnidade.SelectedValue.ToString());
                    this.dtoMovimento.IdtLocal.Value = decimal.Parse(cmbLocal.SelectedValue.ToString());
                    this.dtoMovimento.IdtSetor.Value = decimal.Parse(cmbSetor.SelectedValue.ToString());
                    this.dtoMovimento.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    this.dtoMovimento.IdtRequisicao.Value = dtoRequisicao.Idt.Value;
                    this.dtoMovimento.IdtAtendimento.Value = Convert.ToDecimal(txtCodPac.Text);
                    this.dtoMovimento.TpAtendimento.Value = "H";

                    Movimento.DistribuiDespesaCentroCusto(dtoMovimento);                    
                }
                if (this.dtbMovimento.Rows.Count > 0)
                {
                    try
                    {   //GRAVA REQUISIÇÃO
                        dtoRequisicao.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                        Requisicao.Gravar(dtoRequisicao, dtbReqItem);
                        dtoReqItem = null;
                        dtbReqItem = null;
                        txtReqNum.Text = dtoRequisicao.Idt.Value;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            MessageBox.Show("Baixa registrada com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            this.LimparMatMed();
            txtDtMov.Text = string.Empty;
            CarregaHistDespesas();

            return true;
        }

        /// Solução alternativa para atualizar o grid quando está em edição.        
        private void AtualizaGridEmEdicao()
        {
            chkAjudaAtualizarGrid.Visible = true;
            chkAjudaAtualizarGrid.Focus();
            chkAjudaAtualizarGrid.Visible = false;
        }

        private void CarregarComboTiposCCusto()
        {
            LocalEstoqueDTO dtoMovTipoCCusto = new LocalEstoqueDTO();
            LocalEstoqueDTO dtoMovTipoCCustoHig = new LocalEstoqueDTO();
            LocalEstoqueDataTable dtbMovTipoCCusto = new LocalEstoqueDataTable();

            cmbTiposCCusto.DisplayMember = LocalEstoqueDTO.FieldNames.DsLocalEstoque;
            cmbTiposCCusto.ValueMember = LocalEstoqueDTO.FieldNames.IdtLocalEstoque;

            //if (FrmPrincipal.dtoSeguranca.IdtNivelSeguranca.Value == (int)SegurancaDTO.NivelSeguranca.OPERADOR)
            //{
                //dtoMovTipoCCusto.IdtLocal.Value = FrmPrincipal.dtoSeguranca.IdtLocal.Value;
                //dtoMovTipoCCusto.IdtSetor.Value = FrmPrincipal.dtoSeguranca.IdtSetor.Value;
                //dtoMovTipoCCusto.IdtUnidade.Value = FrmPrincipal.dtoSeguranca.IdtUnidade.Value;

            // FORÇA HOME CARE - que usa estoque central
            dtoMovTipoCCusto.IdtLocal.Value = 33;
            dtoMovTipoCCusto.IdtSetor.Value = 29;
            dtoMovTipoCCusto.IdtUnidade.Value = 244;

            //}
            dtbMovTipoCCusto = this.MovimentacaoTipoCCusto.Sel(dtoMovTipoCCusto);

            //Adiciona Almoxarifado Higienização hardcode provisoriamente
            dtoMovTipoCCustoHig.IdtLocalEstoque.Value = 61; 
            dtoMovTipoCCustoHig = this.MovimentacaoTipoCCusto.SelChave(dtoMovTipoCCustoHig);
            dtbMovTipoCCusto.Add(dtoMovTipoCCustoHig);

            cmbTiposCCusto.DataSource = dtbMovTipoCCusto;
            cmbTiposCCusto.IniciaLista();
            dtoMovTipoCCusto = dtbMovTipoCCusto.TypedRow(0);
            cmbTiposCCusto.SelectedValue = (int)dtoMovTipoCCusto.IdtLocalEstoque.Value;
            
            AcertaTipoCCusto();
        }

        private void LimparMatMed()
        {
            if (dtbMovimento != null) this.dtbMovimento.Rows.Clear();
            if (dtoMovimento != null) this.dtoMovimento = null;
            if (dtoMaterialMedicamento != null) dtoMaterialMedicamento = null;
        }

        private void ConfigurarMovimentoDTO()
        {
            // this.dtoMovimento.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;            
            // this.dtoMovimento.IdtTipo.Value = (byte)MovimentacaoDTO.TipoMovimento.SAIDA;
            // this.dtoMovimento.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_CONSUMO_CENTRO_CUSTO;
            // this.dtoMovimento.Obs.Value = "BAIXA_CONSUMO_CENTRO_CUSTO";
        }

        private void CarregarProduto()
        {
            if (txtCodPac.Text.Length == 0 || txtNomPac.Text.Length == 0)
            {
                MessageBox.Show("Selecione um paciente clicando em Internação Domiciliar", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dtoMaterialMedicamento != null)
            {
                try
                {
                    txtReqNum.Text = string.Empty;
                    // Unidades da Origem só para buscar estoque
                    dtoMovimento = new MovimentacaoDTO();
                    dtoMovimento.IdtLocalEstoque.Value = dtoLocalEstoque.IdtLocalEstoque.Value;
                    dtoMovimento.IdtLocal.Value = dtoLocalEstoque.IdtLocal.Value;
                    dtoMovimento.IdtSetor.Value = dtoLocalEstoque.IdtSetor.Value;
                    dtoMovimento.IdtUnidade.Value = dtoLocalEstoque.IdtUnidade.Value;
                    dtoMovimento.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
                    //Se produto for material ou fracionado, filial será HAC
                    if (dtoMaterialMedicamento.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM ||
                        dtoMaterialMedicamento.Tabelamedica.Value == ((int)MaterialMedicamentoDTO.TipoMatMed.MATERIAL).ToString())
                    {
                        dtoMovimento.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                    }

                    // busca infornmações
                    dtoMovimento = Movimento.ConverteMatMedMovimento(dtoMaterialMedicamento, dtoMovimento);
                    // limpa Unidade para garantir que não vai enviar informações erradas quando salvar
                    dtoMovimento.IdtLocal.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
                    dtoMovimento.IdtSetor.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
                    dtoMovimento.IdtUnidade.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal(); 

                    if ((dtoMovimento.Qtde.Value.IsNull) || (dtoMovimento.Qtde.Value < 1))
                    {
                        MessageBox.Show("Não existe estoque para movimentar este produto", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // 
                        // dtoMovimento.EstoqueLocal.Value = dtoEstoque.Qtde.Value;
                        // dtoMovimento.IdtProduto.Value = dtoMaterialMedicamento.Idt.Value;
                        // dtoMovimento.DsProduto.Value = dtoMaterialMedicamento.Descricao.Value;
                        while (true)
                        {
                            dtoMovimento = FrmQtdMatMed.DigitaQtde(dtoMovimento);
                            if (dtoMovimento == null) break;
                            if ((dtoMovimento.Qtde.Value > dtoMovimento.EstoqueLocal.Value || dtoMovimento.EstoqueLocal.Value.IsNull))
                            {
                                MessageBox.Show("Não existe estoque para movimentar este produto", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);                                
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (dtoMovimento != null)
                        {

                            if (this.dtbMovimento == null)
                                this.dtbMovimento = new MovimentacaoDataTable();
                            string Pesquisa = string.Format("{0} = {1}", MovimentacaoDTO.FieldNames.IdtProduto, this.dtoMaterialMedicamento.Idt.Value);
                            DataRow[] LinhaAdd = this.dtbMovimento.Select(Pesquisa);
                            if (LinhaAdd.Length == 0)
                            {
                                dtbMovimento.Add(dtoMovimento);
                            }
                            else
                            {
                                // MessageBox.Show("Já foi adicionado o Material/Medicamento Selecionado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                LinhaAdd[0][MovimentacaoDTO.FieldNames.Qtde] = Convert.ToDecimal(LinhaAdd[0][MovimentacaoDTO.FieldNames.Qtde]) + dtoMovimento.Qtde.Value;
                            }
                            dtgMatMed.DataSource = dtbMovimento;
                            if (dtbMovimento.Rows.Count > 0)
                            {
                                //cmbTiposCCusto.Enabled = false;
                                cmbUnidade.Enabled = false;
                                cmbLocal.Enabled = false;
                                cmbSetor.Enabled = false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CarregaHistDespesas()
        {
            dtoMovimento = new MovimentacaoDTO();
            // UNIDADE DE ORIGEM ( BAIXA NO ESTOQUE )
            if (dtoLocalEstoque != null)
                dtoMovimento.IdtLocalEstoque.Value = this.dtoLocalEstoque.IdtLocalEstoque.Value;

            // UNIDADE DE DESTINO ( DESPESA )
            dtoMovimento.IdtUnidade.Value = decimal.Parse(cmbUnidade.SelectedValue.ToString());
            dtoMovimento.IdtLocal.Value = decimal.Parse(cmbLocal.SelectedValue.ToString());
            dtoMovimento.IdtSetor.Value = decimal.Parse(cmbSetor.SelectedValue.ToString());
            dtoMovimento.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
            if (txtDtMov.Text != string.Empty)
                this.dtoMovimento.DataMovimento.Value = Convert.ToDateTime(txtDtMov.Text);

            if (dtbMovimentoHistorico == null)
                dtbMovimentoHistorico = new MovimentacaoDataTable();
            if (txtCodPac.Text.Length > 0)
            {
                dtoMovimento.IdtAtendimento.Value = Convert.ToDecimal(txtCodPac.Text);
                dtoMovimento.TpAtendimento.Value = "H";
            }
            else
            {
                dtoMovimento.IdtAtendimento.Value = null;
                dtoMovimento.TpAtendimento.Value = null;
            }

            dtbMovimentoHistorico = Movimento.HistoricoDespesaCentroCusto(dtoMovimento);
            dtgHistoricoCCusto.DataSource = dtbMovimentoHistorico;
        }

        #endregion

        #region EVENTOS

        private void LancamentoOutraUnidade_Load(object sender, EventArgs e)
        {
            cmbUnidade.Carregaunidade();
            // CARREGA UNIDADE/LOCAL/SETOR = SANTOS/ADMINISTRATIVO/HOMECARE
            cmbUnidade.SelectedValue = 244;
            cmbLocal.SelectedValue = 33;
            cmbSetor.SelectedValue = 552;
            cmbUnidade.Enabled = false;
            cmbLocal.Enabled = false;
            cmbSetor.Enabled = false;

            btnHomeCare.Enabled = false;
            this.CarregarComboTiposCCusto();
            this.ConfiguraDTG();
        }

        private bool tsHac_CancelarClick(object sender)
        {
            this.LimparMatMed();
            btnHomeCare.Enabled = false;
            return true;
        }

        private bool tsHac_NovoClick(object sender)
        {
            LimparMatMed();
            btnHomeCare.Enabled = true;
            // CARREGA UNIDADE/LOCAL/SETOR = SANTOS/ADMINISTRATIVO/HOMECARE
            //cmbUnidade.SelectedValue = 244;
            //cmbLocal.SelectedValue = 33;
            //cmbSetor.SelectedValue = 552;
            //cmbUnidade.Enabled = false;
            //cmbLocal.Enabled = false;
            //cmbSetor.Enabled = false;

            /*
            txtBairro.Text = string.Empty;
            txtCdPlano.Text = string.Empty;
            txtCep.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtCodPac.Text = string.Empty;
            txtDsPlano.Text = string.Empty;
            txtDtMov.Text = string.Empty;
             * */
            return true;
        }

        private bool tsHac_SalvarClick(object sender)
        {
            if (cmbTiposCCusto.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione a Origem", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbTiposCCusto.Focus();
                return false;
            }
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
            if (cmbUnidade.SelectedIndex == -1 || cmbLocal.SelectedIndex == -1 || cmbSetor.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione Unidade/Local/Setor antes de pesquisar o material", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            dtoMaterialMedicamento = new MaterialMedicamentoDTO();            
            dtoMaterialMedicamento.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.SEM_ESTOQUE;
            dtoMaterialMedicamento = FrmPesquisaMatMed.SelecionaMatMed(dtoMaterialMedicamento);

            if (dtoMaterialMedicamento != null)
            {
                CarregarProduto();
            }
            return true;
        }        

        private void dtgMatMed_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgMatMed.Columns[e.ColumnIndex].Name == "colDeletar")
            {
                if (MessageBox.Show("Deseja excluir este produto da lista ?",
                                     "Gestão de Materiais e Medicamentos",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int nCount = 0; nCount < dtbMovimento.Rows.Count; nCount++)
                    {
                        if (dtbMovimento.Rows[nCount].RowState != DataRowState.Deleted)
                        {
                            if (dtbMovimento.Rows[nCount][RequisicaoItensDTO.FieldNames.IdtProduto].ToString() == dtgMatMed.Rows[e.RowIndex].Cells["colMatMedIdt"].Value.ToString())
                            {
                                dtbMovimento.Rows[nCount].Delete();

                                if (dtbMovimento.Rows.Count == 0)
                                {
                                    //cmbTiposCCusto.Enabled = true;
                                    cmbUnidade.Enabled = true;
                                    cmbLocal.Enabled = true;
                                    cmbSetor.Enabled = true;
                                } 
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void dtgHistoricoCCusto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgHistoricoCCusto.Columns[e.ColumnIndex].Name == "ColDelHist")
            {
                if (MessageBox.Show("Deseja excluir este produto da lista ?",
                                     "Gestão de Materiais e Medicamentos",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MovimentacaoDTO dto = new MovimentacaoDTO();                    
                    dto.IdtUsuarioEstorno.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    dto.Idt.Value = Convert.ToDecimal(dtgHistoricoCCusto.Rows[e.RowIndex].Cells["colMovId"].Value.ToString());
                    Movimento.EstornaDespesaCCusto(dto);
                    CarregaHistDespesas();
                }
            }
        }

        private void dtgMatMed_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dtgMatMed.Columns[e.ColumnIndex].Name == "colQtde")
            {
                if (!this.IsNumber(e.FormattedValue.ToString()))
                {
                    tsHac.Enabled = false;
                    MessageBox.Show("A quantidade deve ser numérica", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
                else if (e.FormattedValue.ToString().IndexOf(',') > -1)
                {
                    tsHac.Enabled = false;
                    MessageBox.Show("A quantidade deve ser um número inteiro", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
                else if (decimal.Parse(e.FormattedValue.ToString()) <= 0)
                {
                    tsHac.Enabled = false;
                    MessageBox.Show("A quantidade deve ser maior que 0", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
                int QtdDigitada = Convert.ToInt16(e.FormattedValue.ToString());
                if (QtdDigitada > dtoMovimento.Qtde.Value)
                {
                    MessageBox.Show("Quantidade digitada é maior que o estoque local existente", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dtgMatMed_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            tsHac.Enabled = true;
        }

        private void cmbUnidade_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LimparMatMed();
            dtgMatMed.DataSource = null;            
        }

        private void cmbLocal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LimparMatMed();
            dtgMatMed.DataSource = null;
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LimparMatMed();
            dtgMatMed.DataSource = null;
            dtbMovimento = null;
            txtIdProduto.Focus();
        }

        private void txtIdProduto_Validating(object sender, CancelEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (txtIdProduto.Text != string.Empty)
            {

                CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();
                dtoMaterialMedicamento = null;
                dtoCodigoBarra.CdBarra.Value = txtIdProduto.Text;
                // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
                try
                {
                    dtoMaterialMedicamento = MaterialMedicamento.BuscaCodigoBarra(dtoCodigoBarra);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (dtoMaterialMedicamento == null)
                {
                    MessageBox.Show("Material/medicamento não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtIdProduto.Focus();
                }
                else if (dtoMaterialMedicamento.FlAtivo.Value == 0)
                {
                    MessageBox.Show("Produto Inativo", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtIdProduto.Focus();
                }
                else
                {
                    this.CarregarProduto();
                }
                txtIdProduto.Text = string.Empty;
            }
            this.Cursor = Cursors.Default;

        }

        private void AcertaTipoCCusto()
        {
            dtoLocalEstoque = new LocalEstoqueDTO();
            dtoLocalEstoque.IdtLocalEstoque.Value = decimal.Parse(cmbTiposCCusto.SelectedValue.ToString());
            dtoLocalEstoque = MovimentacaoTipoCCusto.SelChave(dtoLocalEstoque);

        }

        private void cmbTiposCCusto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AcertaTipoCCusto();
        }

        private void btnPesqMov_Click(object sender, EventArgs e)
        {
            if (cmbUnidade.SelectedIndex == -1 || cmbLocal.SelectedIndex == -1 || cmbSetor.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione Unidade/Local/Setor antes de pesquisar", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else if (txtCodPac.Text.Length == 0 || txtNomPac.Text.Length == 0)
            {
                MessageBox.Show("Selecione um paciente clicando em Internação Domiciliar antes de pesquisar", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                CarregaHistDespesas();
            }
        }

        private void btnHomeCare_Click(object sender, EventArgs e)
        {
            if (cmbUnidade.SelectedIndex == -1 || cmbLocal.SelectedIndex == -1 || cmbSetor.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione Unidade/Local/Setor antes de pesquisar o material", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {                
                dtoBeneficiario = new BenefHomeCareDTO();
                dtoBeneficiario = FrmPesqBenefHomeCare.BuscaBeneficiarioHomeCare();

                if (dtoBeneficiario != null)
                {
                    txtCodPac.Text = dtoBeneficiario.CodigoHomeCare.Value.ToString();
                    txtNomPac.Text = dtoBeneficiario.NomeBeneficiario.Value;
                    txtCdPlano.Text = dtoBeneficiario.CodigoPlano.Value;
                    txtDsPlano.Text = dtoBeneficiario.DescricaoConvenio.Value;
                    txtBairro.Text = dtoBeneficiario.Bairro.Value;
                    txtCep.Text = dtoBeneficiario.CEP.Value;
                    txtTelefone.Text = dtoBeneficiario.Telefone.Value;
                    txtUF.Text = dtoBeneficiario.UF.Value;
                    txtEndereco.Text = string.Format("{0} {1}/{2}", dtoBeneficiario.Endereco.Value, dtoBeneficiario.NumeroEndereco.Value, dtoBeneficiario.ComplementoEndereco.Value);
                    txtCidade.Text = dtoBeneficiario.Cidade.Value;
                    txtIdProduto.Focus();
                }
            }
        }

        private void btnImpReqNum_Click(object sender, EventArgs e)
        {
            if (txtReqNum.Text == string.Empty)
            {
                MessageBox.Show("N° Pedido deve ser preenchido", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtReqNum.Focus();
                return;
            }
            if (MessageBox.Show(string.Format("Deseja realmente imprimir o Pedido N° {0} ?", txtReqNum.Text), "Gestão de Materiais e Medicamentos",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Impressao.ImpressaoPedido imp = new HospitalAnaCosta.SGS.GestaoMateriais.Impressao.ImpressaoPedido();
                RequisicaoDTO dto = new RequisicaoDTO();
                dto.Idt.Value = txtReqNum.Text;
                RequisicaoDataTable dtb = Requisicao.Sel(dto, false);
                if (dtb.Rows.Count == 1)
                {
                    dto = dtb.TypedRow(0);
                    if (dto.IdtTipoRequisicao.Value == (decimal)RequisicaoDTO.TipoRequisicao.INTERNACAO_DOMICILIAR)
                    {
                        imp.Imprimir(dto, false);
                    }
                    else
                    {
                        MessageBox.Show("Pedido não referente a internação domiciliar", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Pedido não encontrado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        #endregion                  
    }
}