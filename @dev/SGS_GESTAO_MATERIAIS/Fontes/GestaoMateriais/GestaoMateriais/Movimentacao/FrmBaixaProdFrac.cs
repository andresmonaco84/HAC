using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmBaixaProdFrac : FrmBase
    {
        public FrmBaixaProdFrac()
        {
            InitializeComponent();
        }

        private bool ESTOQUE_UNIFICADO_HAC = false;
        private int? CARRINHO_EMERG_SETOR_PAI = null;

        #region OBJETOS SERVIÇOS

        // Estoque
        private EstoqueLocalDTO dtoEstoque;
        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject( typeof(IEstoqueLocal)); }
        }

        // MatMed
        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject( typeof(IMaterialMedicamento)); }
        }

        // Movimentos
        private MovimentacaoDTO dtoMovimento = new MovimentacaoDTO();
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject( typeof(IMovimentacao)); }
        }

        // Itens Requisição
        private RequisicaoItensDataTable dtbRequisicaoItemCE;
        private RequisicaoItensDTO dtoRequisicaoItemCE;
        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }

        // Requisição
        private RequisicaoDTO dtoRequisicaoCE;
        private IRequisicao _requisicao;
        private IRequisicao Requisicao
        {
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject(typeof(IRequisicao)); }
        }

        private IMatMedSetorConfig _matMedConfig;
        private IMatMedSetorConfig MatMedSetorConfig
        {
            get { return _matMedConfig != null ? _matMedConfig : _matMedConfig = (IMatMedSetorConfig)Global.Common.GetObject(typeof(IMatMedSetorConfig)); }
        }

        #endregion        

        #region FUNÇÕES

        private void ConfiguraDTG()
        {
            dtgHistConsumo.AutoGenerateColumns = false;
            dtgHistConsumo.Columns["colIdtMovimentoHist"].DataPropertyName = MovimentacaoDTO.FieldNames.Idt;
            dtgHistConsumo.Columns["colIdtProdutoHist"].DataPropertyName = MovimentacaoDTO.FieldNames.IdtProduto;
            dtgHistConsumo.Columns["colDsProdutoHist"].DataPropertyName = MovimentacaoDTO.FieldNames.DsProduto;
            dtgHistConsumo.Columns["colDataHist"].DataPropertyName = MovimentacaoDTO.FieldNames.DataMovimento;
            dtgHistConsumo.Columns["colDataHist"].DefaultCellStyle.Format = "dd/MM/yyyy à\\s HH:mm:ss";
            dtgHistConsumo.Columns["colQtdHist"].DataPropertyName = MovimentacaoDTO.FieldNames.DsQtdeConsumo;
            dtgHistConsumo.Columns["colQtdHist"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgHistConsumo.Columns["colQtdInteiraHist"].DataPropertyName = MovimentacaoDTO.FieldNames.Qtde;
            dtgHistConsumo.Columns["colFaturado"].DataPropertyName = MovimentacaoDTO.FieldNames.FlFaturado;
            dtgHistConsumo.Columns["colDataRessup"].DataPropertyName = MovimentacaoDTO.FieldNames.DataRessupri;
            dtgHistConsumo.Columns["colIdFilial"].DataPropertyName = MovimentacaoDTO.FieldNames.IdtFilial;
            dtgHistConsumo.Columns["colDsQtdeConvertida"].DataPropertyName = MovimentacaoDTO.FieldNames.DsQtdConvertida;
            dtgHistConsumo.Columns["colDsQtdeConvertida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgHistConsumo.Columns["colSubTpMov"].DataPropertyName = MovimentacaoDTO.FieldNames.IdtSubTipo;
            // colDsQtdeConvertida            
        }

        private void CarregarHistoricoConsumo()
        {
            if (dtoMatMed != null)
            {
                this.Cursor = Cursors.WaitCursor;

                ConfiguraDTG();

                MovimentacaoDTO dtoHistMovimento = new MovimentacaoDTO();
                dtoHistMovimento.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                dtoHistMovimento.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                dtoHistMovimento.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                dtoHistMovimento.FlEstornado.Value = (int)MovimentacaoDTO.Estornado.NAO;
                dtoHistMovimento.IdtProduto.Value = dtoMatMed.Idt.Value;
                dtoHistMovimento.IdtTipo.Value = (int)MovimentacaoDTO.TipoMovimento.SAIDA;
                dtoHistMovimento.IdtSubTipo.Value = (int)MovimentacaoDTO.SubTipoMovimento.BAIXA_CONSUMO_NAO_FATURADO_SETOR;
                if (cbCE.Checked)
                {
                    dtoHistMovimento.IdtFilial.Value = (int)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
                }
                else if (rbHac.Checked)
                {
                    dtoHistMovimento.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                }
                else if (rbAcs.Checked)
                {
                    dtoHistMovimento.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
                }
                // NAO UTLIZA DATA FORNECIMENTO
                //dtgHistConsumo.DataSource = Movimento.Sel(dtoHistMovimento, true);
                dtgHistConsumo.DataSource = Movimento.Sel(dtoHistMovimento, false);
                this.Cursor = Cursors.Default;
            }
        }

        //private void ConfiguraCombos()
        //{
        //    cmbUnidade.SelectedValue = FrmPrincipal.dtoSeguranca.IdtUnidade.Value;
        //    cmbLocal.SelectedValue = FrmPrincipal.dtoSeguranca.IdtLocal.Value;
        //    cmbSetor.SelectedValue = FrmPrincipal.dtoSeguranca.IdtSetor.Value;

        //    if (FrmPrincipal.dtoSeguranca.IdtNivelSeguranca.Value == (int)SegurancaDTO.NivelSeguranca.OPERADOR)
        //    {
        //        cmbUnidade.Enabled = false;
        //        cmbUnidade.Editavel = ControleEdicao.Nunca;

        //        cmbLocal.Enabled = false;
        //        cmbLocal.Editavel = ControleEdicao.Nunca;

        //        cmbSetor.Enabled = false;
        //        cmbSetor.Editavel = ControleEdicao.Nunca;
        //    }
        //}

        /// <summary>
        /// Carrega Informações Básicas do DTO de Movimentação
        /// </summary>
        private void ConfigurarMovimentoDTO()
        {
            if (cmbUnidade.SelectedIndex != -1) dtoMovimento.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            if (cmbLocal.SelectedIndex != -1) dtoMovimento.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            if (cmbSetor.SelectedIndex != -1) dtoMovimento.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            RadioButton rbCe = new RadioButton();
            if (cbCE.Checked) rbCe.Checked = true;
            dtoMovimento.IdtFilial.Value = new Generico().RetornaFilial(rbHac, rbAcs, rbCe);
            dtoMovimento.Qtde.Value = 1;
            dtoMovimento.IdtTipo.Value = (byte)MovimentacaoDTO.TipoMovimento.SAIDA;
            dtoMovimento.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_CONSUMO_NAO_FATURADO_SETOR;
        }

        private void ConfiguraRequisicaoCEDTO()
        {
            dtoRequisicaoCE = new RequisicaoDTO();

            dtoRequisicaoCE.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoRequisicaoCE.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoRequisicaoCE.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoRequisicaoCE.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.FECHADA;
            dtoRequisicaoCE.IdtTipoRequisicao.Value = (byte)RequisicaoDTO.TipoRequisicao.CARRINHO_EMERGENCIA;
            dtoRequisicaoCE.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
        }

        private void ConfiguraEstoqueDTO()
        {
            dtoEstoque = new EstoqueLocalDTO();

            dtoEstoque.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoEstoque.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoEstoque.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoEstoque.IdtProduto.Value = dtoMatMed.Idt.Value;
            
            if (cbCE.Checked)
            {
                dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
            }
            else
            {
                if (rbHac.Checked)
                {
                    dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                }
                else if (rbAcs.Checked)
                {
                    dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
                }
            }
        }
        
        private void AtualizarQtdEstoque()
        {
            txtQtdEstoque.Text = txtQtdLote.Text = string.Empty;
            if (dtoMatMed != null)
            {
                ConfiguraEstoqueDTO();
                if (!dtoEstoque.IdtFilial.Value.IsNull)
                {
                    if ((int)dtoMatMed.IdtGrupo.Value == 1)
                    {
                        lblLote.Visible = txtQtdLote.Visible = true;
                        if (!dtoMatMed.IdtLote.Value.IsNull)
                            dtoEstoque.IdtLote.Value = dtoMatMed.IdtLote.Value;
                    }
                    else
                        lblLote.Visible = txtQtdLote.Visible = false;

                    dtoEstoque = Estoque.EstoqueLocalProduto(dtoEstoque);

                    txtQtdEstoque.Text = "0";
                    if (!dtoEstoque.Qtde.Value.IsNull) txtQtdEstoque.Text = dtoEstoque.Qtde.Value.ToString();
                    if (!dtoEstoque.QtdeLote.Value.IsNull && txtQtdLote.Visible) txtQtdLote.Text = dtoEstoque.QtdeLote.Value.ToString();
                }                
            }
        }

        private void CarregarProduto()
        {
            if (dtoMatMed != null)
            {
                txtDsProduto.Text = dtoMatMed.NomeFantasia.Value;
                txtUnidadeVenda.Text = dtoMatMed.DsUnidadeVenda.Value;                
                grbTipo.Enabled = false;
            }
            else
            {
                txtDsProduto.Text = string.Empty;
                txtUnidadeVenda.Text = string.Empty;
                if (rbFrac.Checked) grbTipo.Enabled = true;                             
            }            
            AtualizarQtdEstoque();
            txtIdProduto.Text = string.Empty;
        }
        
        private bool ValidarFilial()
        {
            if (!rbAcs.Checked && !rbHac.Checked)
            {
                MessageBox.Show("Selecione a Filial", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private bool ValidarTipo()
        {
            if (!rbFrac.Checked && !rbMat.Checked && !rbInteiroFrac.Checked)
            {
                MessageBox.Show("Selecione o Tipo Mat/Med", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private bool Validar()
        {
            if (!ValidarFilial()) return false;

            if (dtoMatMed == null)
            {
                MessageBox.Show("Selecione o Mat/Med", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (int.Parse(txtQtdEstoque.Text) <= 0)
            {
                MessageBox.Show("Não existe este produto no Estoque Local para realizar uma baixa", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //if (cbCE.Checked)
            //{
            //    dtoEstoque = new EstoqueLocalDTO();

            //    dtoEstoque.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            //    dtoEstoque.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            //    dtoEstoque.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            //    dtoEstoque.IdtProduto.Value = dtoMatMed.Idt.Value;
            //    dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;

            //    dtoEstoque = Estoque.EstoqueLocalProduto(dtoEstoque);

            //    if (!dtoEstoque.Qtde.Value.IsNull)
            //    {
            //        if (dtoEstoque.Qtde.Value > 0)
            //        {
            //            MessageBox.Show(" Material/medicamento não pode ser consumido do carrinho de emergência, pois existe no estoque local do HAC", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //            return false;
            //        }
            //    }
            //}

            return true;
        }

        private bool ValidarProduto()
        {
            if (dtoMatMed == null)
            {
                MessageBox.Show("Produto não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdProduto.Focus();
                return false;
            }

            if (dtoMatMed.FlAtivo.Value == 0)
            {
                MessageBox.Show("Produto está inativo", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdProduto.Focus();
                return false;
            }


            //if (dtoMatMed.FlBaixaAutomatica.Value.IsNull) dtoMatMed.FlBaixaAutomatica.Value = (byte)MaterialMedicamentoDTO.Faturado.NAO;
            //if (dtoMatMed.FlBaixaAutomatica.Value == (byte)MaterialMedicamentoDTO.Faturado.SIM)
            //{
            //    dtoMatMed = null;
            //    MessageBox.Show("Este produto tem baixa automática e não pode ser baixado através desta funcionalidade", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    txtIdProduto.Focus();
            //    return false;
            //}

            if (rbMat.Checked && dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.NAO)
            {
                if (dtoMatMed.FlFaturado.Value.IsNull) dtoMatMed.FlFaturado.Value = (byte)MaterialMedicamentoDTO.Faturado.NAO;
                if (dtoMatMed.FlFaturado.Value == (byte)MaterialMedicamentoDTO.Faturado.SIM)
                {
                    dtoMatMed = null;
                    MessageBox.Show("Este material tem que ser faturado e não pode ser baixado através desta funcionalidade", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtIdProduto.Text = string.Empty;
                    txtIdProduto.Focus();
                    return false;
                }
            }

            if (rbInteiroFrac.Checked && dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM)
            {
                MessageBox.Show("Este produto é Fracionado, Você deve selecionar a Opção de Baixar Fracionados para realizar esta baixa", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdProduto.Text = string.Empty;
                return false;
            }

            if (rbMat.Checked &&  Convert.ToDecimal(dtoMatMed.Tabelamedica.Value) == (decimal)MaterialMedicamentoDTO.TipoMatMed.MEDICAMENTO)
            {
                MessageBox.Show("Este produto não é Material de uso Geral", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdProduto.Text = string.Empty;
                return false;
            }

            if (rbFrac.Checked && dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.NAO)
            {
                MessageBox.Show("O produto tem que ser fracionado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdProduto.Text = string.Empty;
                return false;
            }

            return true;
        }

        private bool Salvar()
        {
            if (!Validar()) return false;
            try
            {
                ConfigurarMovimentoDTO();
                //if (cbCE.Checked && !ESTOQUE_UNIFICADO_HAC)
                if (cbCE.Checked)
                {
                    dtoMovimento.IdtFilial.Value = (int)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
                    dtoMovimento.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_CONSUMO_CARRINHO_EMERGENCIA_NAO_FATURADO;

                    dtoRequisicaoItemCE = RequisicaoItens.ConverteMatMedRequisicao(dtoMatMed);

                    if (dtbRequisicaoItemCE.Select(string.Format("{0} = {1}",
                                                 RequisicaoItensDTO.FieldNames.IdtProduto,
                                                 dtoMatMed.Idt.Value)).Length > 0)
                    {
                        decimal qtdAnterior = decimal.Parse(dtbRequisicaoItemCE.Select(string.Format("{0} = {1}",
                                                            RequisicaoItensDTO.FieldNames.IdtProduto,
                                                            dtoMatMed.Idt.Value))[0][RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString());
                        dtoRequisicaoItemCE.QtdSolicitada.Value = qtdAnterior + 1;
                        dtbRequisicaoItemCE.Select(string.Format("{0} = {1}",
                                                   RequisicaoItensDTO.FieldNames.IdtProduto,
                                                   dtoMatMed.Idt.Value))[0][RequisicaoItensDTO.FieldNames.QtdSolicitada] = dtoRequisicaoItemCE.QtdSolicitada.Value;
                    }
                    else
                    {
                        dtoRequisicaoItemCE.QtdSolicitada.Value = 1;
                        dtbRequisicaoItemCE.Add(dtoRequisicaoItemCE);
                    }
                }                
                dtoMovimento.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                if (!dtoMatMed.IdtLote.Value.IsNull && (decimal)dtoMatMed.IdtLote.Value != 0) dtoMovimento.IdtLote.Value = dtoMatMed.IdtLote.Value;
                dtoMovimento = Movimento.MovimentaEstoqueProduto(dtoMovimento, dtoMatMed, null);
                //txtIdProduto.Enabled = false;
                txtIdProduto.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            AtualizarQtdEstoque();
            MessageBox.Show("Baixa registrada com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private void SalvarPedidoCE()
        {
            if (dtbRequisicaoItemCE == null)
            {
                MessageBox.Show("PEDIDO NÃO CARREGADO CORRETAMENTE!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                if (dtbRequisicaoItemCE.Rows.Count > 0)
                {
                    ConfiguraRequisicaoCEDTO();
                    dtoRequisicaoCE.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                    int? idSetorFarmacia = new Generico().ObterFarmaciaSetor((int)dtoRequisicaoCE.IdtSetor.Value);
                    if (idSetorFarmacia != null)
                        dtoRequisicaoCE.SetorFarmacia.Value = idSetorFarmacia;

                    Requisicao.Gravar(dtoRequisicaoCE, dtbRequisicaoItemCE);

                    if (CARRINHO_EMERG_SETOR_PAI != null)
                        MessageBox.Show("Pedido gerado com sucesso!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Não foi consumido nenhum produto do carrinho de emergência", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                dtoRequisicaoCE = null;
                dtbRequisicaoItemCE = null;
                if (CARRINHO_EMERG_SETOR_PAI != null)
                    dtbRequisicaoItemCE = new RequisicaoItensDataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ZerarObjetos(bool finalizarPedidoCarrEmergSemMsg)
        {
            if (dtbRequisicaoItemCE != null)
            {
                if (dtbRequisicaoItemCE.Rows.Count > 0)
                {
                    if (finalizarPedidoCarrEmergSemMsg)
                    {
                        SalvarPedidoCE();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Finalize o Consumo do Carrinho de Emergência",
                                        "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnFinalizarCE.Focus();
                        return false;
                    }
                }
            }
            dtoMatMed = null;
            grbTipo.Enabled = true;
            dtoRequisicaoCE = null;
            dtbRequisicaoItemCE = null;
            cbCE.Enabled = false;
            //if (!ESTOQUE_UNIFICADO_HAC) cbCE.Checked = false;
            FixarCE();            
            return true;
        }

        private void RotinaFilial_Habilitada_Desabilitada()
        {
            if (rbInteiroFrac.Checked)
            {
                grbFilial.Enabled = true;
            }
            else
            {
                RotinaFilialPadrao();
            }
        }

        private void RotinaFilialPadrao()
        {
            rbHac.Checked = true;
            grbFilial.Enabled = false;
        }

        private void ConfiguraEstoque()
        {
            MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();

            dtoCfg.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoCfg.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoCfg.Idtsetor.Value = cmbSetor.SelectedValue.ToString();

            dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);            

            if (dtoCfg.EstoqueUnificadoHAC.Value.IsNull) dtoCfg.EstoqueUnificadoHAC.Value = 0;
            if (dtoCfg.EstoqueUnificadoHAC.Value == 1)
            {
                ESTOQUE_UNIFICADO_HAC = true;
                lblEU.Visible = true;
                rbHac.Checked = true;
                rbAcs.Enabled = false;
                //cbCE.Text = "ESTOQUE UNIFICADO";
                //cbCE.Enabled = false;
                //cbCE.Checked = true;
                //grbFilial.Visible = false;
            }
            else
            {
                ESTOQUE_UNIFICADO_HAC = false;
                lblEU.Visible = false;
                cbCE.Text = "CARRINHO DE EMERGÊNCIA";
                rbAcs.Enabled = true;
                //cbCE.Enabled = true;
                grbFilial.Visible = true;
            } 
            FixarCE();
            if (CARRINHO_EMERG_SETOR_PAI != null)
                cbCE_Click(null, null);
        }

        private void FixarCE()
        {
            if (cmbSetor.SelectedValue == null) return;
            CARRINHO_EMERG_SETOR_PAI = new Generico().SetorCarrinhoEmergencia(int.Parse(cmbSetor.SelectedValue.ToString()));
            if (CARRINHO_EMERG_SETOR_PAI == null)
            {
                cbCE.Checked = false;
                btnFinalizarCE.Visible = false;
            }
            else
            {
                dtbRequisicaoItemCE = new RequisicaoItensDataTable();
                cbCE.Checked = true;
                btnFinalizarCE.Visible = true;                
            }
        }

        #endregion

        #region EVENTOS

        private void FrmBaixaProdFrac_Load(object sender, EventArgs e)
        {
            cmbUnidade.Carregaunidade();
            Generico.ConfiguraCombos(cmbUnidade,cmbLocal,cmbSetor,FrmPrincipal.dtoSeguranca);
            ConfiguraEstoque();
        }

        private void cmbUnidade_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ZerarObjetos(false))
            {
                dtoMatMed = null;
                tsHac.Controla(Evento.eCancelar);
            }            
        }

        private void cmbLocal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ZerarObjetos(false))
            {
                dtoMatMed = null;
                tsHac.Controla(Evento.eCancelar);
            }            
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ZerarObjetos(false))
            {
                dtoMatMed = null;
                tsHac.Controla(Evento.eCancelar);
                ConfiguraEstoque();
            }            
        }

        private bool tsHac_SairClick(object sender)
        {
            return ZerarObjetos(false);
        }

        private bool tsHac_CancelarClick(object sender)
        {
            return ZerarObjetos(false);
        }

        private bool tsHac_NovoClick(object sender)
        {
            if (ZerarObjetos(false))
            {
                //if (!ESTOQUE_UNIFICADO_HAC) cbCE.Enabled = true;
                cbCE.Enabled = true;
                RotinaFilialPadrao();
                return true;
            }
            return false;
        }

        private bool tsHac_AfterNovo(object sender)
        {
            if (ESTOQUE_UNIFICADO_HAC)
            {
                //cbCE.Checked = true;
                //cbCE.Enabled = false;
                lblEU.Visible = true;
                rbHac.Checked = true;
                rbAcs.Enabled = false;
            }
            else
            {
                lblEU.Visible = false;
                rbAcs.Enabled = true;
            }
            return true;
        }

        private void tsHac_AfterCancelar(object sender)
        {
            tsHac_AfterNovo(null);
        }

        private bool tsHac_SalvarClick(object sender)
        {
            if (MessageBox.Show("Deseja realmente executar a baixa deste produto ?",
                                "Gestão de Materiais e Medicamentos",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Salvar();
            }
            return false;            
        }

        private bool tsHac_MatMedClick(object sender)
        {
            if (!ValidarTipo()) return false;
            if (!ValidarFilial()) return false;

            MaterialMedicamentoDTO dtoMatMedAux = new MaterialMedicamentoDTO();

            ConfigurarMovimentoDTO();

            dtoMatMedAux.IdtFilial.Value = dtoMovimento.IdtFilial.Value;
            dtoMatMedAux.IdtUnidade.Value = dtoMovimento.IdtUnidade.Value;
            dtoMatMedAux.IdtLocal.Value = dtoMovimento.IdtLocal.Value;
            dtoMatMedAux.IdtSetor.Value = dtoMovimento.IdtSetor.Value;
            dtoMatMedAux.FlAtivo.Value = 1; // ATIVO 27/01/2010
            if (rbFrac.Checked)
            {
                dtoMatMedAux.Tabelamedica.Value = ((int)MaterialMedicamentoDTO.TipoMatMed.MEDICAMENTO).ToString();
                dtoMatMedAux.FlFracionado.Value = (byte)MaterialMedicamentoDTO.Fracionado.SIM;
            }
            if (rbInteiroFrac.Checked)
            {
                dtoMatMedAux.Tabelamedica.Value = ((int)MaterialMedicamentoDTO.TipoMatMed.MEDICAMENTO).ToString();
                dtoMatMedAux.FlFracionado.Value = (byte)MaterialMedicamentoDTO.Fracionado.NAO;
            }
            if (rbMat.Checked) dtoMatMedAux.Tabelamedica.Value = ((int)MaterialMedicamentoDTO.TipoMatMed.MATERIAL).ToString();
            dtoMatMedAux.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.COM_PERMISSAO_SUBGRUPO;
            dtoMatMedAux = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMedAux);            

            if (dtoMatMedAux != null)
            {
                if (!dtoMatMedAux.Idt.Value.IsNull)
                {
                    if ((int)dtoMatMedAux.IdtGrupo.Value == 1)
                    {
                        MessageBox.Show("Obrigatório baixa pelo Código de Barra para Medicamentos !", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtIdProduto.Focus();
                        return false;
                    }
                    else
                    {
                        dtoMatMed = dtoMatMedAux;
                        if (ValidarProduto())
                        {
                            CarregarProduto();
                            CarregarHistoricoConsumo();
                        }
                    }
                }
            }  

            dtoMatMedAux = null;

            return true;
        }        

        private void txtIdProduto_Validating(object sender, CancelEventArgs e)
        {
            if (txtIdProduto.Text != string.Empty)
            {
                if (!ValidarTipo())
                {
                    txtIdProduto.Text = string.Empty;
                    return;
                }
                if (!ValidarFilial())
                {
                    txtIdProduto.Text = string.Empty;
                    return;
                }

                CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();

                dtoCodigoBarra.CdBarra.Value = txtIdProduto.Text;
                if (rbHac.Checked)
                {
                    dtoCodigoBarra.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
                }
                else if (rbAcs.Checked)
                {
                    dtoCodigoBarra.IdtFilial.Value = (int)FilialMatMedDTO.Filial.ACS;
                }
                // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
                dtoMatMed = MatMed.BuscaCodigoBarra(dtoCodigoBarra);

                if (ValidarProduto())
                {
                    CarregarProduto();
                }                


            }
        }

        private void rbFrac_Click(object sender, EventArgs e)
        {
            RotinaFilial_Habilitada_Desabilitada();
            txtIdProduto.Focus();
        }

        private void rbMat_Click(object sender, EventArgs e)
        {
            RotinaFilial_Habilitada_Desabilitada();
            txtIdProduto.Focus();
        }

        private void rbInteiroFrac_Click(object sender, EventArgs e)
        {
            RotinaFilial_Habilitada_Desabilitada();
            txtIdProduto.Focus();
        }

        private void rbHac_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarQtdEstoque();
            txtIdProduto.Focus();
        }

        private void rbAcs_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarQtdEstoque();
            txtIdProduto.Focus();
        }

        private void cbCE_Click(object sender, EventArgs e)
        {
            if (CARRINHO_EMERG_SETOR_PAI != null && !cbCE.Checked)
            {
                cbCE.Checked = true;                
                return;
            }
            if (cbCE.Checked)
            {
                //MessageBox.Show("O próximo consumo gerará um pedido para o almoxarifado, para o reabastecimento do carrinho de emergência", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show("Os próximos consumos gerarão um pedido para o reabastecimento do carrinho de emergência.\n\nDepois de registrar o(s) consumo(s), clique em Finalizar Consumo do Carrinho de Emergência.",
                                "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbUnidade.Enabled = false;
                cmbLocal.Enabled = false;
                cmbSetor.Enabled = false;
                cbCE.Enabled = false;
                btnFinalizarCE.Visible = true;                
                dtbRequisicaoItemCE = new RequisicaoItensDataTable();
            }
            else
            {
                cmbUnidade.Enabled = true;
                cmbLocal.Enabled = true;
                cmbSetor.Enabled = true;
                dtoRequisicaoCE = null;
                dtbRequisicaoItemCE = null;
            }
            AtualizarQtdEstoque();
        }        

        private void btnFinalizarCE_Click(object sender, EventArgs e)
        {
            SalvarPedidoCE();
            if (CARRINHO_EMERG_SETOR_PAI == null)
            {
                cbCE.Checked = false;
                cbCE.Enabled = true;
                btnFinalizarCE.Visible = false;
            }
            AtualizarQtdEstoque();            
        }

        private void FrmBaixaProdFrac_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !ZerarObjetos(true);
        }

        
        private void dtgHistConsumo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (dtgHistConsumo.Columns[e.ColumnIndex].Name == "colDeletarHist")
            {
                this.Cursor = Cursors.WaitCursor;
                dtoPedidoPadrao = new PedidoPadraoDTO();

                dtoPedidoPadrao.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                dtoPedidoPadrao.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                dtoPedidoPadrao.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                dtoPedidoPadrao.Status.Value = (byte)PedidoPadraoDTO.StatusPedidoPadrao.CONFIRMADO;
                if (rbHac.Checked)
                {
                    dtoPedidoPadrao.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
                }
                else if (rbAcs.Checked)
                {
                    dtoPedidoPadrao.IdtFilial.Value = (int)FilialMatMedDTO.Filial.ACS;
                }

                // MaterialMedicamentoDTO dtoMatMedDEL = new MaterialMedicamentoDTO();
                // dtoMatMedDEL.Idt.Value = dtgHistConsumo.Rows[e.RowIndex].Cells["colIdtProdutoHist"].Value.ToString();
                // dtoMatMedDEL = MatMed.SelChave(dtoMatMedDEL);

                ConfigurarMovimentoDTO();
                dtoMovimento.Idt.Value = decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colIdtMovimentoHist"].Value.ToString());

                PedidoPadraoItensDTO dtoPedPadItem = new PedidoPadraoItensDTO();

                if (byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString()) != (byte)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA &&
                    byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colSubTpMov"].Value.ToString()) != (byte)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA_CARRINHO_EMERGENCIA)
                {
                    if (PedidoPadrao.ProdutoPadrao(dtoPedidoPadrao, dtoMatMed, ref dtoPedPadItem, true))
                    {
                        decimal qtdNova = decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colQtdHist"].Value.ToString()) + dtoPedPadItem.EstoqueLocalQtde.Value.DBValue.Value;

                        if (qtdNova > dtoPedPadItem.Qtde.Value)
                        {
                            MessageBox.Show("Não pode ser realizado o estorno deste produto neste momento, pois ele pertence ao estoque fixo que já está cheio", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }
                }
                if (MessageBox.Show("Deseja realmente estornar este consumo ?",
                                    "Gestão de Materiais e Medicamentos",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        dtoMovimento.IdtProduto.Value = long.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colIdtProdutoHist"].Value.ToString());
                        dtoMovimento.Qtde.Value = decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colQtdInteiraHist"].Value.ToString());
                        dtoMovimento.IdtUsuarioEstorno.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                        Movimento.EstornarMovimentoConsumoPaciente(dtoMovimento);
                        this.CarregarHistoricoConsumo();
                        // dtbMovimento = new MovimentacaoDataTable();
                        // dtgConsumo.DataSource = dtbMovimento;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Cursor = Cursors.Default;
                    }
                }
                this.Cursor = Cursors.Default;
            }
             * */
        }
        

        #endregion        
    }
}