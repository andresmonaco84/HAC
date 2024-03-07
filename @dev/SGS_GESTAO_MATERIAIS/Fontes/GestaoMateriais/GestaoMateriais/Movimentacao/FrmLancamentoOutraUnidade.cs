using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.Services.BeneficiarioACS.Interface;
using HospitalAnaCosta.Services.BeneficiarioACS.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Componentes;


namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmLancamentoOutraUnidade : FrmGestao
    {
        public FrmLancamentoOutraUnidade()
        {
            InitializeComponent();
        }

        FrmPrincipal Acesso = new FrmPrincipal();

        Generico gen = new Generico();

        #region Objetos Serviço

        private LocalEstoqueDTO dtoLocalEstoque;

        // Material Medicamento
        // private MaterialMedicamentoDataTable dtbMaterialMedicamento;
        private MaterialMedicamentoDTO dtoMaterialMedicamento;

        // Movimentos
        private MovimentacaoDTO dtoMovimento = new MovimentacaoDTO();
        private MovimentacaoDataTable dtbMovimento;
        private MovimentacaoDataTable dtbMovimentoHistorico;

        private IMatMedSetorConfig _matMedConfig;
        private IMatMedSetorConfig MatMedSetorConfig
        {
            get { return _matMedConfig != null ? _matMedConfig : _matMedConfig = (IMatMedSetorConfig)Global.Common.GetObject(typeof(IMatMedSetorConfig)); }
        }

        // Requisição        
        private IRequisicao _requisicao;
        private IRequisicao Requisicao
        {
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject(typeof(IRequisicao)); }
        }

        // Itens Requisição        
        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }

        #endregion                

        #region MÉTODOS

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
            dtgMatMed.Columns[colMAVMov.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia;
            // 
            dtgHistoricoCCusto.AutoGenerateColumns = false;
            dtgHistoricoCCusto.Columns["colDsProdutoHist"].DataPropertyName = MovimentacaoDTO.FieldNames.DsProduto;
            dtgHistoricoCCusto.Columns["colDtMov"].DataPropertyName = MovimentacaoDTO.FieldNames.DataMovimento;
            dtgHistoricoCCusto.Columns["colQtdeHist"].DataPropertyName = MovimentacaoDTO.FieldNames.Qtde;
            // dtgHistoricoCCusto.Columns["colIdtMov"].DataPropertyName = MovimentacaoDTO.FieldNames.Idt;
            dtgHistoricoCCusto.Columns["colDtMov"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dtgHistoricoCCusto.Columns["colMovId"].DataPropertyName = MovimentacaoDTO.FieldNames.Idt;
            dtgHistoricoCCusto.Columns[colMAV.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia;
            dtgHistoricoCCusto.Columns[colLoteFab.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.NumLote;
            // 
        }

        private Boolean ValidaFilial()
        {
            if (!rbHac.Checked && !rbAcs.Checked && !rbCE.Checked)
            {
                MessageBox.Show("Selecione um Estoque", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        #region DESUSO
        /// <summary>
        /// Verifica os RBs e retorna filial selecionada pelo operador
        /// </summary>
        /// <returns></returns>
        //private decimal RetornaFilial()
        //{
        //    return (decimal)(rbHac.Checked ? FilialMatMedDTO.Filial.HAC : (rbAcs.Checked ? FilialMatMedDTO.Filial.ACS : (rbCE.Checked ? FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA : FilialMatMedDTO.Filial.HAC)));
        //}

        /*
        private bool Salvar()
        {           
            this.AtualizaGridEmEdicao();


            if (!this.Validar()) return false;
            if (!ValidaFilial()) return false;
            try
            {

                for (short i = 0; i < this.dtbMovimento.Rows.Count; ++i)
                {
                    this.dtoMovimento = this.dtbMovimento.TypedRow(i);
                    // FILIAL
                    // UNIDADE DE ORIGEM ( BAIXA NO ESTOQUE )
                    this.dtoMovimento.IdtLocalEstoque.Value = this.dtoMovimentacaoTipoCCusto.IdtLocalEstoque.Value;
                    dtoMovimento.IdtFilial.Value = RetornaFilial();
                    // UNIDADE DE DESTINO ( DESPESA )
                    this.dtoMovimento.IdtUnidade.Value = decimal.Parse(cmbUnidade.SelectedValue.ToString());
                    this.dtoMovimento.IdtLocal.Value = decimal.Parse(cmbLocal.SelectedValue.ToString());
                    this.dtoMovimento.IdtSetor.Value = decimal.Parse(cmbSetor.SelectedValue.ToString());
                    this.dtoMovimento.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    dtoMovimento.IdtSubTipo.Value = (int)MovimentacaoDTO.SubTipoMovimento.BAIXA_CONSUMO_CENTRO_CUSTO;
                    // this.dtoMovimento.IdtAtendimento.Value = null;
                    // this.dtoMovimento.TpAtendimento.Value = null;


                    Movimento.DistribuiDespesaCentroCusto(dtoMovimento);
                    
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
        */
        #endregion

        /// Solução alternativa para atualizar o grid quando está em edição.        
        private void AtualizaGridEmEdicao()
        {
            chkAjudaAtualizarGrid.Visible = true;
            chkAjudaAtualizarGrid.Focus();
            chkAjudaAtualizarGrid.Visible = false;
        }

        /// <summary>
        /// Carrega Locais de estoque que o operador tem acesso
        /// O Acesso são as unidades que o operador esta cadastrado
        /// </summary>
        private void CarregarComboLocalEstoque()
        {
            Generico gen = new Generico();
            LocalEstoqueDTO dtoEstoqueMovimentacao = new LocalEstoqueDTO();
            LocalEstoqueDataTable dtbEstoqueMovimentacao = new LocalEstoqueDataTable();

            cmbLocalEstoque.DisplayMember = LocalEstoqueDTO.FieldNames.DsLocalEstoque;
            cmbLocalEstoque.ValueMember = LocalEstoqueDTO.FieldNames.IdtLocalEstoque;

            // Esta passando o ID do usuário como ID do local, tem que acertar no serviço e procedure
            dtoEstoqueMovimentacao.IdtLocalEstoque.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
            dtbEstoqueMovimentacao = EstoqueMovimentacao.EstoqueUsuario(dtoEstoqueMovimentacao);
            cmbLocalEstoque.DataSource = dtbEstoqueMovimentacao;
            cmbLocalEstoque.IniciaLista();
        }

        /// <summary>
        /// Limpa todos os objetos da tela
        /// </summary>
        private void LimparMatMed()
        {
            if (dtbMovimento != null) this.dtbMovimento.Rows.Clear();
            if (dtbMovimentoHistorico != null) dtbMovimentoHistorico.Rows.Clear();
            if (dtoMovimento != null) this.dtoMovimento = null;
            if (dtoMaterialMedicamento != null) dtoMaterialMedicamento = null;
            txtCodProd.Text = string.Empty;
            // deixa botão NOVO sempre Enable
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
            if (dtoMaterialMedicamento != null)
            {
                bool estoqueUnico = false;
                MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();
                dtoCfg.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                dtoCfg.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                dtoCfg.Idtsetor.Value = cmbSetor.SelectedValue.ToString();
                dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);
                if (dtoCfg.EstoqueUnificadoHAC.Value.IsNull) dtoCfg.EstoqueUnificadoHAC.Value = 0;
                if (dtoCfg.EstoqueUnificadoHAC.Value == 1) estoqueUnico = true;
                if (rbAcs.Checked && estoqueUnico)
                {
                    MessageBox.Show("Não pode dar baixa do estoque do ACS quando o C. Custo é Estoque Único", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                try
                {
                    //if (Convert.ToDecimal(dtoMaterialMedicamento.Tabelamedica.Value) == (decimal)MaterialMedicamentoDTO.TipoMatMed.MEDICAMENTO)
                    //{
                    //    MessageBox.Show("Este produto não é um material", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                        
                    //    return;
                    //}
                    dtoMovimento = new MovimentacaoDTO();
                    if (!dtoMaterialMedicamento.IdtLote.Value.IsNull && (decimal)dtoMaterialMedicamento.IdtLote.Value != 0)
                        dtoMovimento.IdtLote.Value = dtoMaterialMedicamento.IdtLote.Value;
                    // Unidades da Origem só para buscar estoque                    
                    dtoMovimento.IdtFilial.Value = gen.RetornaFilial(rbHac, rbAcs, rbCE);
                    dtoMovimento.IdtLocalEstoque.Value = dtoLocalEstoque.IdtLocalEstoque.Value;
                    dtoMovimento.IdtLocal.Value = dtoLocalEstoque.IdtLocal.Value;
                    dtoMovimento.IdtSetor.Value = dtoLocalEstoque.IdtSetor.Value;
                    dtoMovimento.IdtUnidade.Value = dtoLocalEstoque.IdtUnidade.Value;
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
                            // UNIDADE DE ORIGEM ( BAIXA NO ESTOQUE )
                            dtoMovimento.IdtLocalEstoque.Value = this.dtoLocalEstoque.IdtLocalEstoque.Value;
                            dtoMovimento.IdtFilial.Value = gen.RetornaFilial(rbHac, rbAcs, rbCE);
                            // UNIDADE DE DESTINO ( DESPESA )
                            dtoMovimento.IdtUnidade.Value = decimal.Parse(cmbUnidade.SelectedValue.ToString());
                            dtoMovimento.IdtLocal.Value = decimal.Parse(cmbLocal.SelectedValue.ToString());
                            dtoMovimento.IdtSetor.Value = decimal.Parse(cmbSetor.SelectedValue.ToString());
                            dtoMovimento.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                            dtoMovimento.IdtSubTipo.Value = (int)MovimentacaoDTO.SubTipoMovimento.BAIXA_CONSUMO_CENTRO_CUSTO;
                            dtoMovimento.IdtAtendimento.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal(); ;
                            dtoMovimento.TpAtendimento.Value = new HospitalAnaCosta.Framework.DTO.TypeString();
                            dtoMovimento.FlFracionado.Value = (int)MaterialMedicamentoDTO.Fracionado.NAO;                            

                            Movimento.DistribuiDespesaCentroCusto(dtoMovimento);
                            dtbMovimento.Add(dtoMovimento);

                            if (dtbMovimento.Columns.IndexOf(MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia) == -1)
                                dtbMovimento.Columns.Add(MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia);
                            dtbMovimento.Rows[dtbMovimento.Rows.Count - 1][MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia] = dtoMaterialMedicamento.MedAltaVigilancia.Value;
                            dtgMatMed.DataSource = dtbMovimento;
                            if (dtbMovimento.Rows.Count > 0)
                            {
                                cmbUnidade.Enabled = false;
                                cmbLocal.Enabled = false;
                                cmbSetor.Enabled = false;
                            }
                            if (rbCE.Checked) this.SalvarPedidoCE();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            tsHac.Items["tsBtnNovo"].Enabled = true;
        }

        /// <summary>
        /// Gera Requisição do Carrinho de Emergencia
        /// </summary>
        private void SalvarPedidoCE()
        {          
            try
            {
                RequisicaoItensDataTable dtbRequisicaoItemCE = new RequisicaoItensDataTable();
                RequisicaoItensDTO dtoRequisicaoItemCE = RequisicaoItens.ConverteMatMedRequisicao(dtoMaterialMedicamento);

                dtoRequisicaoItemCE.QtdSolicitada.Value = dtoMovimento.Qtde.Value;
                dtbRequisicaoItemCE.Add(dtoRequisicaoItemCE);

                RequisicaoDTO dtoRequisicaoCE = new RequisicaoDTO();

                dtoRequisicaoCE.IdtUnidade.Value = dtoLocalEstoque.IdtUnidade.Value;
                dtoRequisicaoCE.IdtSetor.Value = dtoLocalEstoque.IdtSetor.Value;
                dtoRequisicaoCE.IdtLocal.Value = dtoLocalEstoque.IdtLocal.Value;
                dtoRequisicaoCE.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.FECHADA;
                dtoRequisicaoCE.IdtTipoRequisicao.Value = (byte)RequisicaoDTO.TipoRequisicao.CARRINHO_EMERGENCIA;
                dtoRequisicaoCE.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
                dtoRequisicaoCE.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                int? idSetorFarmacia = new Generico().ObterFarmaciaSetor((int)dtoRequisicaoCE.IdtSetor.Value);
                if (idSetorFarmacia != null)
                    dtoRequisicaoCE.SetorFarmacia.Value = idSetorFarmacia;

                Requisicao.Gravar(dtoRequisicaoCE, dtbRequisicaoItemCE);

                dtoRequisicaoCE = null;
                dtbRequisicaoItemCE = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaHistDespesas()
        {
            this.Cursor = Cursors.WaitCursor;
            dtoMovimento = new MovimentacaoDTO();
            ValidaFilial();
            // UNIDADE DE ORIGEM ( BAIXA NO ESTOQUE )
            if (dtoLocalEstoque != null)
                dtoMovimento.IdtLocalEstoque.Value = this.dtoLocalEstoque.IdtLocalEstoque.Value;

            // UNIDADE DE DESTINO ( DESPESA )
            dtoMovimento.IdtUnidade.Value = decimal.Parse(cmbUnidade.SelectedValue.ToString());
            dtoMovimento.IdtLocal.Value = decimal.Parse(cmbLocal.SelectedValue.ToString());
            dtoMovimento.IdtSetor.Value = decimal.Parse(cmbSetor.SelectedValue.ToString());
            dtoMovimento.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
            dtoMovimento.IdtFilial.Value = gen.RetornaFilial(rbHac, rbAcs, rbCE);
            if (txtDtMov.Text != string.Empty)
                this.dtoMovimento.DataMovimento.Value = Convert.ToDateTime(txtDtMov.Text);

            if (dtbMovimentoHistorico == null)
            {
                dtbMovimentoHistorico = new MovimentacaoDataTable();
            }
            dtoMovimento.IdtAtendimento.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
            dtoMovimento.TpAtendimento.Value = new HospitalAnaCosta.Framework.DTO.TypeString();
            dtoMovimento.IdtLocalEstoque.Value = cmbLocalEstoque.SelectedValue.ToString();

            dtbMovimentoHistorico = Movimento.HistoricoDespesaCentroCusto(dtoMovimento);
            dtgHistoricoCCusto.DataSource = dtbMovimentoHistorico;
            this.Cursor = Cursors.Default;
        }

        private void FixarCE()
        {
            rbHac.Enabled = true; rbCE.Checked = false;
            if (cmbSetor.SelectedValue == null || cmbSetor.SelectedIndex == -1) return;
            if (new Generico().SetorCarrinhoEmergencia(int.Parse(cmbSetor.SelectedValue.ToString()))  != null)
            {
                rbCE.Checked = true;
                rbHac.Enabled = false;
            }            
        }

        #endregion

        #region EVENTOS

        private void LancamentoOutraUnidade_Load(object sender, EventArgs e)
        {
            rbAcs.Editavel = ControleEdicao.Nunca;
            CarregarComboLocalEstoque();
            ConfiguraDTG();
        }

        private bool tsHac_CancelarClick(object sender)
        {
            this.LimparMatMed();
            this.FixarCE();
            return true;
        }

        private bool tsHac_NovoClick(object sender)
        {
            this.LimparMatMed();
            this.FixarCE();
            return true;
        }

        private bool tsHac_AfterNovo(object sender)
        {
            if (!string.IsNullOrEmpty(lblEstoqueUnificado.Text))
            {
                rbAcs.Enabled = false;
                rbAcs.Checked = false;
            }
            //else
            //    rbAcs.Enabled = true;
            return default(bool);
        }    

        private bool tsHac_SalvarClick(object sender)
        {
            /*
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
             */
            return false;
        }

        private bool tsHac_MatMedClick(object sender)
        {
            if (cmbUnidade.SelectedIndex == -1 || cmbLocal.SelectedIndex == -1 || cmbSetor.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione Unidade/Local/Setor antes de pesquisar o material", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            dtoMaterialMedicamento = new MaterialMedicamentoDTO();
            dtoMaterialMedicamento.IdtFilial.Value = gen.RetornaFilial(rbHac, rbAcs, rbCE);
            dtoMaterialMedicamento.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.SEM_ESTOQUE;
            dtoMaterialMedicamento.FlAtivo.Value = 1;
            dtoMaterialMedicamento = FrmPesquisaMatMed.SelecionaMatMed(dtoMaterialMedicamento);

            if (dtoMaterialMedicamento != null)
            {
                if (!dtoMaterialMedicamento.Idt.Value.IsNull)
                {
                    if ((int)dtoMaterialMedicamento.IdtGrupo.Value == 1)
                    {
                        MessageBox.Show("Obrigatório baixa pelo Código de Barra para Medicamentos !", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtIdProduto.Focus();
                        return false;
                    }
                    else
                        CarregarProduto();
                }
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
                    dtoMovimento = new MovimentacaoDTO();
                    // UNIDADE DE DESTINO ( DESPESA )
                    dtoMovimento.IdtUsuarioEstorno.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    dtoMovimento.Idt.Value = Convert.ToDecimal(dtgHistoricoCCusto.Rows[e.RowIndex].Cells["colMovId"].Value.ToString());
                    dtoMovimento.IdtFilial.Value = gen.RetornaFilial(rbHac, rbAcs, rbCE);

                    try
                    {
                        Movimento.EstornaDespesaCCusto(dtoMovimento);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
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
                // int QtdDigitada = Convert.ToInt16( dtgMatMed.Rows[e.RowIndex].Cells["colQtde"].Value.ToString());
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
            // CarregaHistDespesas();
            txtIdProduto.Focus();
            this.FixarCE();
        }

        private void txtIdProduto_Validating(object sender, CancelEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (txtIdProduto.Text != string.Empty)
            {
                CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();
                dtoMaterialMedicamento = null;
                dtoCodigoBarra.CdBarra.Value = txtIdProduto.Text;
                dtoCodigoBarra.IdtFilial.Value = gen.RetornaFilial(rbHac, rbAcs, rbCE);
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
                    txtIdProduto.Text = string.Empty;
                    txtIdProduto.Focus();
                }
                else if (dtoMaterialMedicamento.FlAtivo.Value == 0)
                {
                    MessageBox.Show("Material/medicamento Inativo", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtIdProduto.Text = string.Empty;
                    txtIdProduto.Focus();
                }
                else
                {
                    this.CarregarProduto();
                }
                txtIdProduto.Text = string.Empty;
                txtIdProduto.Focus();
            }
            this.Cursor = Cursors.Default;

        }

        private void txtCodProd_Validating(object sender, CancelEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (txtCodProd.Text != string.Empty)
            {
                MaterialMedicamentoDTO dtoCdMne = new MaterialMedicamentoDTO();
                dtoCdMne.CodMne.Value = txtCodProd.Text.Trim();
                MaterialMedicamentoDataTable dtbMatMed = MaterialMedicamento.Sel(dtoCdMne);

                if (dtbMatMed.Rows.Count > 0)
                {
                    dtoMaterialMedicamento = dtbMatMed.TypedRow(0);
                    if (!dtoMaterialMedicamento.Idt.Value.IsNull)
                    {
                        if ((int)dtoMaterialMedicamento.IdtGrupo.Value == 1)
                        {
                            MessageBox.Show("Obrigatório baixa pelo Código de Barra para Medicamentos !", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Cursor = Cursors.Default;
                            txtCodProd.Text = string.Empty;
                            txtCodProd.Focus();
                            return;
                        }
                        else
                            CarregarProduto();
                    }                    
                }
                else
                {
                    MessageBox.Show("Material/medicamento não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodProd.Text = string.Empty;
                    txtCodProd.Focus();
                }
                txtCodProd.Text = string.Empty;
                txtCodProd.Focus();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Limpa DTO Lolca de Estoque e ajusta IdtLocalEstoque para Estoque de consumo Selecionado
        /// Recarrega os combos de Unidade/Local/Setor conforme estoque selecionado
        /// </summary>
        private void AcertaLocalEstoque()
        {
            cmbUnidade.DataSource = null;
            dtoLocalEstoque = new LocalEstoqueDTO();
            dtoLocalEstoque.IdtLocalEstoque.Value = decimal.Parse(cmbLocalEstoque.SelectedValue.ToString());
            dtoLocalEstoque = EstoqueMovimentacao.SelChave(dtoLocalEstoque);

            MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();

            // se mudar local de estoque
            dtoCfg.IdtUnidade.Value = dtoLocalEstoque.IdtUnidade.Value;
            dtoCfg.IdtLocal.Value = dtoLocalEstoque.IdtLocal.Value;
            dtoCfg.Idtsetor.Value = dtoLocalEstoque.IdtSetor.Value;
            dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);
            // verifica se pode carregar combos com todos os setores ou só os que usuário tem acesso
            if (dtoCfg.ConsomeParaOutroCentroCusto.Value != 1)
            {
                cmbUnidade.IdtUsuario = (decimal)FrmPrincipal.dtoSeguranca.Idt.Value;
                cmbSetor.IdtUsuario = (decimal)FrmPrincipal.dtoSeguranca.Idt.Value;
                cmbSetor.SetorUsuario = true;
            }
            else
            {
                cmbUnidade.UnidadeUsuario = false; cmbSetor.SetorUsuario = false;
                cmbUnidade.IdtUsuario = 0; cmbSetor.IdtUsuario = 0;
            }
            cmbUnidade.Carregaunidade();

            if (dtoCfg.EstoqueUnificadoHAC.Value.IsNull) dtoCfg.EstoqueUnificadoHAC.Value = 0;
            if (dtoCfg.EstoqueUnificadoHAC.Value == 1)
            {
                //rbCE.Checked = true;
                //grbFilial.Visible = false;                
                lblEstoqueUnificado.Text = "ESTOQUE UNIFICADO";
                rbAcs.Enabled = false;
            }
            else
            {
                //rbHac.Checked = true;
                //grbFilial.Visible = true;
                lblEstoqueUnificado.Text = string.Empty;
                //rbAcs.Enabled = true;
            }
            rbHac.Checked = grbFilial.Visible = true;            
            lblCodProd.Visible = txtCodProd.Visible = false;
            rbCE.Enabled = rbHac.Enabled;

            if (dtoLocalEstoque.IdtSetor.Value == 124) //Habilitar Cod. para Laboratorio Santos
                lblCodProd.Visible = txtCodProd.Visible = true;            
        }

        private void cmbTiposCCusto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AcertaLocalEstoque();
            LimparMatMed();
        }

        private void btnPesqMov_Click(object sender, EventArgs e)
        {
            if (cmbUnidade.SelectedIndex == -1 || cmbLocal.SelectedIndex == -1 || cmbSetor.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione Unidade/Local/Setor antes de pesquisar o material", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                CarregaHistDespesas();
            }
        }

        private void rbHac_CheckedChanged(object sender, EventArgs e)
        {
            LimparMatMed();
        }

        private void rbAcs_CheckedChanged(object sender, EventArgs e)
        {
            LimparMatMed();
        }

        private void rbCE_CheckedChanged(object sender, EventArgs e)
        {
            LimparMatMed();
        }      

        #endregion                    
    }
}