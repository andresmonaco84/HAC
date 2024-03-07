using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.GestaoMateriais;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Componentes;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmConsumoCCirurgico_old : FrmBase
    {
        public FrmConsumoCCirurgico_old()
        {
            InitializeComponent();
        } 

        #region Objetos Serviço
        
        //private CommonCadastro _commonCadastro;
        //private CommonCadastro CommonCadastro
        //{
        //    get { return _commonCadastro != null ? _commonCadastro : _commonCadastro = new CommonCadastro(null); }
        //}

        // Atendimento
        private HospitalAnaCosta.SGS.GestaoMateriais.DTO.PacienteDTO dtoAtendimento;
        private IPaciente _atendimento;
        private IPaciente Atendimento
        {
            get { return _atendimento != null ? _atendimento : _atendimento = (IPaciente)Global.Common.GetObject(typeof(IPaciente)); }
        }
        // Movimentos
        private MovimentacaoDTO dtoMovimento;
        private MovimentacaoDataTable dtbMovimento = new MovimentacaoDataTable();
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject( typeof(IMovimentacao)); }
        }   
     
        // MatMed        
        private MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();        
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject( typeof(IMaterialMedicamento)); }
        }        

        // Filial        
        private IFilialMatMed _filialMatMed;
        private IFilialMatMed FilialMatMed
        {
            get { return _filialMatMed != null ? _filialMatMed : _filialMatMed = (IFilialMatMed)Global.Common.GetObject( typeof(IFilialMatMed)); }
        }

        // Pedido Padrão        
        private PedidoPadraoDTO dtoPedidoPadrao;
        private IPedidoPadrao _pedidopadrao;
        private IPedidoPadrao PedidoPadrao
        {
            get { return _pedidopadrao != null ? _pedidopadrao : _pedidopadrao = (IPedidoPadrao)Global.Common.GetObject(typeof(IPedidoPadrao)); }
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

        // Estoque
        private EstoqueLocalDTO dtoEstoque;
        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject(typeof(IEstoqueLocal)); }
        }

        private IMatMedSetorConfig _matMedConfig;
        private IMatMedSetorConfig MatMedSetorConfig
        {
            get { return _matMedConfig != null ? _matMedConfig : _matMedConfig = (IMatMedSetorConfig)Global.Common.GetObject(typeof(IMatMedSetorConfig)); }
        }        


        #endregion                
        
        #region Métodos

        private void ConfiguraCombos()
        {
            cmbUnidade.SelectedValue = FrmPrincipal.dtoSeguranca.IdtUnidade.Value;
            cmbLocal.SelectedValue = FrmPrincipal.dtoSeguranca.IdtLocal.Value;
            cmbSetor.SelectedValue = FrmPrincipal.dtoSeguranca.IdtSetor.Value;

            if (FrmPrincipal.dtoSeguranca.IdtNivelSeguranca.Value == (int)SegurancaDTO.NivelSeguranca.OPERADOR)
            {
                cmbUnidade.Enabled = false;
                cmbUnidade.Editavel = ControleEdicao.Nunca;

                cmbLocal.Enabled = false;
                cmbLocal.Editavel = ControleEdicao.Nunca;

                cmbSetor.Enabled = false;
                cmbSetor.Editavel = ControleEdicao.Nunca;

            }
            lblSetor.Text = string.Format(" {0}/{1}/{2}",cmbUnidade.SelectedValue.ToString(),cmbLocal.SelectedValue.ToString(), cmbSetor.SelectedValue.ToString()  );
        }

        private void ConfiguraMovimentoDTO()
        {
            dtoMovimento = new MovimentacaoDTO();
            dtoMovimento.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoMovimento.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoMovimento.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoMovimento.FlEstornado.Value = (int)MovimentacaoDTO.Estornado.NAO;
            dtoMovimento.IdtSubTipo.Value = (int)MovimentacaoDTO.SubTipoMovimento.ENTRADA_RESSUPRIMENTO_PERSONALIZADO;
            dtoMovimento.IdtTipo.Value = (int)MovimentacaoDTO.TipoMovimento.ENTRADA;
            // VAI ESTAR COM FLAG DE FATURADO QUANDO CONFIRMAR CONSUMO
            dtoMovimento.FlFaturado.Value = (int)MovimentacaoDTO.Faturado.NAO; 

            if (cbCE.Checked)
            {
                dtoMovimento.IdtFilial.Value = (int)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
            }
            else if (rbHac.Checked)
            {
                dtoMovimento.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            }            
            else if (rbAcs.Checked)
            {
                dtoMovimento.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
            }
            dtoMovimento.IdtAtendimento.Value = dtoAtendimento.Idt.Value;
            dtoAtendimento.IdtLocalAtendimento.Value = cmbLocal.SelectedValue.ToString();
            dtoMovimento.TpAtendimento.Value = Atendimento.ObterTipoAtendimento(dtoAtendimento).TpAtendimento.Value;
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
        
        private void ConfiguraDTG()
        {
            /*
            dtgConsumo.AutoGenerateColumns = false;
            dtgConsumo.Dock = DockStyle.Fill;
            dtgConsumo.Columns["colIdtMovimento"].DataPropertyName = MovimentacaoDTO.FieldNames.Idt;
            dtgConsumo.Columns["colIdtProduto"].DataPropertyName = MovimentacaoDTO.FieldNames.IdtProduto;
            dtgConsumo.Columns["colDsProduto"].DataPropertyName = MovimentacaoDTO.FieldNames.DsProduto;            
            dtgConsumo.Columns["colQtde"].DataPropertyName = MovimentacaoDTO.FieldNames.DsQtdeConsumo;
            dtgConsumo.Columns["colQtde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgConsumo.Columns["colUnidadeVenda"].DataPropertyName = MovimentacaoDTO.FieldNames.DsUnidadeVenda;
            dtgConsumo.Columns["colUnidadeVenda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgConsumo.Columns["colSaldo"].DataPropertyName = MovimentacaoDTO.FieldNames.EstoqueLocal;
            dtgConsumo.Columns["colSaldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgConsumo.Columns["colSaldo"].DefaultCellStyle.Format = "N0";
            */
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
            this.Cursor = Cursors.WaitCursor;
            ConfiguraMovimentoDTO();
            dtoMovimento.IdtFilial.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
            dtgHistConsumo.DataSource = Movimento.Sel(dtoMovimento, false);
            this.Cursor = Cursors.Default;
        }
        
        // private void CarregaInfoPaciente(AtendimentoDTO dto)
        private void CarregaInfoPaciente( )
        {
            dtoAtendimento = new HospitalAnaCosta.SGS.GestaoMateriais.DTO.PacienteDTO();
            dtoAtendimento.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoAtendimento.IdtLocalAtendimento.Value = cmbLocal.SelectedValue.ToString();
            dtoAtendimento.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            if (txtNroInternacao.Text != string.Empty)
                dtoAtendimento.Idt.Value = Convert.ToInt64(txtNroInternacao.Text);
            Generico Gen = new Generico();
            dtoAtendimento = Gen.ObterPaciente(dtoAtendimento, false);

            if (!dtoAtendimento.NmPaciente.Value.IsNull)
            {
                FilialMatMedDTO dtoFilial = new FilialMatMedDTO();
                txtNomePac.Text = dtoAtendimento.NmPaciente.Value;
                txtNroInternacao.Text = dtoAtendimento.Idt.Value.ToString();
                txtCodConvenio.Text = dtoAtendimento.CdPlano.Value;
                txtNomeConvenio.Text = dtoAtendimento.NmPlano.Value;
                txtLocal.Text = dtoAtendimento.DsSetor.Value;
                txtQuartoLeito.Text = string.Format("{0} / {1}", dtoAtendimento.CdQuarto.ToString(), dtoAtendimento.CdLeito.ToString());
                dtoFilial.TpPlano.Value = dtoAtendimento.TpPlano.Value;

                if (FilialMatMed.ObterFilialAtendimento(dtoFilial) == FilialMatMedDTO.Filial.HAC)
                {
                    rbHac.Checked = true;
                }
                else
                {
                    rbAcs.Checked = true;
                }

                txtNroInternacao.Enabled = false;
                cmbUnidade.Enabled = false;
                cmbLocal.Enabled = false;
                cmbSetor.Enabled = false;
                cbCE.Enabled = true;
                txtCodProduto.Enabled = true;
                txtCodProduto.Focus();

                CarregarHistoricoConsumo();
            }
        }

        #region BAIXAPRODUTO
        /*
        private void BaixarProduto()
        {
            if (this.PermitirConsumo())
            {
                try
                {
                    ConfiguraMovimentoDTO();
                    if (txtCodProduto.Text != string.Empty) dtoMovimento.CdBarra.Value = txtCodProduto.Text;

                    if (dtoMatMed == null)
                    {
                        CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();

                        dtoCodigoBarra.CdBarra.Value = dtoMovimento.CdBarra.Value;
                        dtoCodigoBarra.IdtFilial.Value = dtoMovimento.IdtFilial.Value;
                        
                        // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
                        dtoMatMed = MatMed.BuscaCodigoBarra(dtoCodigoBarra);

                        if (dtoMatMed == null)
                        {
                            MessageBox.Show(" Material/medicamento não identificado ", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtCodProduto.Text = string.Empty;
                            txtCodProduto.Focus();
                            return;
                        }
                    }

                    //if (dtoMatMed.FlFaturado.Value.IsNull) dtoMatMed.FlFaturado.Value = (byte)MaterialMedicamentoDTO.Faturado.NAO;
                    //if (dtoMatMed.FlFaturado.Value == (byte)MaterialMedicamentoDTO.Faturado.NAO)
                    //{
                    //    MessageBox.Show(" Material/medicamento não deve ser faturado de acordo com o cadastro ", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    txtCodProduto.Text = string.Empty;
                    //    txtCodProduto.Focus();
                    //    return;
                    //}

                    #region Retirado em 11/11/2009
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
                    //            txtCodProduto.Text = string.Empty;
                    //            txtCodProduto.Focus();
                    //            return;
                    //        }
                    //    }
                    //}
                    #endregion

                    dtoMovimento.IdtSubTipo.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
                    if (chkFracionar.Checked) dtoMatMed.FlFracionado.Value = (byte)MaterialMedicamentoDTO.Fracionado.SIM;
                    dtoMovimento.FlFracionado.Value = dtoMatMed.FlFracionado.Value;
                    //Se for fracionado, digitar qtd.
                    if (dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM)
                    {
                        dtoMovimento = DigitarQtde();
                        if (decimal.Parse(dtoMovimento.Qtde.Value.ToString()) == 0)
                        {
                            txtCodProduto.Text = string.Empty;
                            txtCodProduto.Focus();
                            return;
                        }
                        #region Retirado tratamento sendo feito no serviço - 02/12/2009
                        // if (cbCE.Checked)
                        //{
                            //dtoMovimento.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
                            //if (dtoMovimento.FlFracionado.Value == (int)MaterialMedicamentoDTO.Fracionado.SIM)
                            //{
                            //    dtoMovimento.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA_CARRINHO_EMERGENCIA;
                            //}
                            //else
                            //{
                            //    dtoMovimento.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_CONSUMO_CARRINHO_EMERGENCIA_FATURADO;
                            //}
                        //}
                        #endregion
                    }
                    else
                    {
                        #region Atualiza Requisição do carrinho de emergência
                        //Se não for fracionado, baixará do estoque, e terá que ser gerado um pedido, caso seja consumo de carrinho de emergência
                        if (cbCE.Checked)
                        {
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
                        #endregion
                    }

                    #region Retirado, filial esta sendo verificada no inicio do metodo
                    //if (!cbCE.Checked)
                    //{
                    //    if (rbHac.Checked)
                    //    {
                    //        dtoMovimento.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                    //    }
                    //    else
                    //    {
                    //        dtoMovimento.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
                    //    }
                    //}
                    #endregion

                    dtoMovimento.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    // ############## GERA O MOVIMENTO #############################################################
                    Movimento.MovimentaEstoqueProduto(dtoMovimento, dtoMatMed);
                    // #############################################################################################
                    // dtgConsumo.DataSource = this.AtualizaGrid();
                    this.CarregarHistoricoConsumo();                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtCodProduto.Text = string.Empty;
                txtCodProduto.Focus();
                dtbMovimento.AcceptChanges();
                tsHac.Items["tsBtnNovo"].Enabled = true;
                chkFracionar.Checked = false;

            }
            else
            {
                dtoMatMed = null;
                MessageBox.Show("A conta deste paciente foi fechada e nenhum produto pode ser consumido", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodProduto.Focus();
            }
        }
        */
#endregion

        private void SalvarPedidoCE()
        {
            try
            {
                if (dtbRequisicaoItemCE.Rows.Count > 0)
                {
                    ConfiguraRequisicaoCEDTO();
                    dtoRequisicaoCE.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    Requisicao.Gravar(dtoRequisicaoCE, dtbRequisicaoItemCE);
                }
                else
                {
                    MessageBox.Show("Não foi consumido nenhum produto para a geração de pedido do carrinho de emergência", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                dtoRequisicaoCE = null;
                dtbRequisicaoItemCE = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Verifica se pode excluir pelas regras do faturamento
        /// </summary>
        private bool PermitirExclusao(decimal idMovimento)
        {
            MovimentacaoDTO dto = new MovimentacaoDTO();
            dto.Idt.Value = idMovimento;
            dto.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dto.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dto.IdtSetor.Value = cmbLocal.SelectedValue.ToString();

            try
            {
                return !Movimento.PermiteConsumo(dto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

        }

        /// <summary>
        /// Verifica se pode consumir pelas regras do faturamento
        /// </summary>
        private bool PermitirConsumo()
        {
            MovimentacaoDTO dto = new MovimentacaoDTO();
            dto.IdtAtendimento.Value = dtoAtendimento.Idt.Value;
            dto.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dto.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dto.IdtSetor.Value = cmbLocal.SelectedValue.ToString();

            try
            {
                return !Movimento.PermiteConsumo(dto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

        // private int DigitarQtde()
        private MovimentacaoDTO DigitarQtde()
        {
            // MovimentacaoDTO dtoMov = new MovimentacaoDTO();

            dtoMovimento.DsProduto.Value = dtoMatMed.NomeFantasia.Value;
            dtoMovimento.FlFracionado.Value = dtoMatMed.FlFracionado.Value;
            dtoMovimento.UnidadeVenda.Value = dtoMatMed.UnidadeVenda.Value;
            dtoMovimento.DsUnidadeVenda.Value = dtoMatMed.DsUnidadeVenda.Value;
            dtoMovimento.FormOrigem.Value = (int)MovimentacaoDTO.TelaOrigem.CONSUMO_PACIENTE;
            dtoMovimento.TpFracao.Value = dtoMatMed.TpFracao.Value;

            dtoMovimento = FrmQtdMatMed.DigitaQtde(dtoMovimento);

            if (dtoMovimento == null) dtoMovimento = new MovimentacaoDTO();
            // dtoMatMed.FlFracionado.Value = dtoMovimento.FlFracionado.Value;
            if (dtoMovimento.Qtde.Value.IsNull) dtoMovimento.Qtde.Value = 0;

            // return (int)dtoMov.Qtde.Value;
            return dtoMovimento;
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
            dtbMovimento = new MovimentacaoDataTable();
            // dtgConsumo.DataSource = null;
            dtgHistConsumo.DataSource = null;
            dtoRequisicaoCE = null;
            dtbRequisicaoItemCE = null;
            cbCE.Checked = false;
            btnFinalizarCE.Visible = false;
            return true;
        }

        #endregion

        #region Eventos

        private void FrmConsumoPaciente_Load(object sender, EventArgs e)
        {
            cmbUnidade.Carregaunidade();
            ConfiguraCombos();
            ConfiguraDTG();            
            #if DEBUG
                tsHac.Items["tsBtnMatMed"].Visible = true;
            #else
                tsHac.Items["tsBtnMatMed"].Visible = false;
            #endif
            }

        private void btnPesquisaPac_Click(object sender, EventArgs e)
        {
            if (txtNroInternacao.Enabled)
            {
                // this.PesquisarPaciente();
                CarregaInfoPaciente();
                tsHac.Items["tsBtnNovo"].Enabled = true;
            }
        }

        private void txtNroInternacao_Validated(object sender, EventArgs e)
        {
            if (txtNroInternacao.Text.Length != 0)
            {
                btnPesquisaPac_Click(sender, e);
                tsHac.Items["tsBtnNovo"].Enabled = true;
            }
        }

        private void txtCodProduto_Validating(object sender, CancelEventArgs e)
        {
            if (txtCodProduto.Text != string.Empty)
            {
                dtoMatMed = null;
                // this.BaixarProduto();
                tsHac.Items["tsBtnNovo"].Enabled = true;
            }
        }

        private bool tsHac_MatMedClick(object sender)
        {
            if (!rbAcs.Checked && !rbHac.Checked)
            {
                MessageBox.Show("Pesquise o paciente", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroInternacao.Focus();
                return false;
            }
            dtoMatMed = new MaterialMedicamentoDTO();
            // byte idFilial = 
            // MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();
            dtoMatMed.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoMatMed.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoMatMed.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoMatMed.IdtFilial.Value = rbHac.Checked ? (byte)FilialMatMedDTO.Filial.HAC : (byte)FilialMatMedDTO.Filial.ACS;

            // dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(MaterialMedicamentoDTO.TipoMatMed.TODOS, idFilial);
            dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMed);
            if (dtoMatMed != null)
            {
               // if (!dtoMatMed.Idt.Value.IsNull)// this.BaixarProduto();
            } 
            return true;
        }

        private bool tsHac_SairClick(object sender)
        {
            return ZerarObjetos(false);
        }

        private bool tsHac_NovoClick(object sender)
        {
            return ZerarObjetos(false);
        }

        private bool tsHac_CancelarClick(object sender)
        {
            return ZerarObjetos(false);
        }

        private void cmbUnidade_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblSetor.Text = string.Format(" {0}", cmbUnidade.SelectedValue.ToString());
            if (ZerarObjetos(false)) tsHac.Controla(Evento.eCancelar);
        }

        private void cmbLocal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblSetor.Text = string.Format(" {0}/{1}", cmbUnidade.SelectedValue.ToString(), cmbLocal.SelectedValue.ToString());
            if (ZerarObjetos(false)) tsHac.Controla(Evento.eCancelar);
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblSetor.Text = string.Format(" {0}/{1}/{2}", cmbUnidade.SelectedValue.ToString(), cmbLocal.SelectedValue.ToString(), cmbSetor.SelectedValue.ToString());
            if (ZerarObjetos(false)) tsHac.Controla(Evento.eCancelar);
        }

        private void dtgHistConsumo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgHistConsumo.Columns[e.ColumnIndex].Name == "colDsProdutoHist")
            {
                if (dtgHistConsumo.Rows[e.RowIndex].Cells["colIdFilial"].Value.ToString() != string.Empty)
                {
                    if (byte.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colIdFilial"].Value.ToString()) == (byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA)
                    {
                        //e.Value = string.Format("CARRO EMERG. -> {0}", e.Value.ToString());
                        e.Value = string.Format("{0} (CARRO EMERG.)", e.Value.ToString());
                    }
                }
            }            
            //if (!this.PermitirExclusao(decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colIdtMovimentoHist"].Value.ToString())))
            //{
            //    lblLegenda.Visible = true;
            //    e.CellStyle.BackColor = Color.Yellow;
            //}            
        }

        private void dtgHistConsumo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
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

                dtoMatMed = new MaterialMedicamentoDTO();
                dtoMatMed.Idt.Value = dtgHistConsumo.Rows[e.RowIndex].Cells["colIdtProdutoHist"].Value.ToString();
                dtoMatMed = MatMed.SelChave(dtoMatMed);

                ConfiguraMovimentoDTO();
                dtoMovimento.Idt.Value = decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colIdtMovimentoHist"].Value.ToString());

                #region Retirado em 08/12/2009
                //if (PedidoPadrao.ProdutoPadrao(dtoPedidoPadrao, dtoMatMed))
                //{                    
                //    //DateTime dataRessup = DateTime.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colDataRessup"].Value.ToString());
                //    // Busca valor no banco, pois a tela da pessoa pode estar aberta a muito tempo e não ter a Data Ressup. atualizada
                //    MovimentacaoDTO dtoMovDataRessup = Movimento.SelChave(dtoMovimento);
                //    if (!dtoMovDataRessup.DataRessupri.Value.IsNull)
                //    {
                //        DateTime dataRessup = (DateTime)dtoMovDataRessup.DataRessupri.Value;
                //        DateTime dataMov = DateTime.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colDataHist"].Value.ToString());

                //        if (dataRessup > dataMov)
                //        {
                //            MessageBox.Show("Estorno indevido, pois é um produto do estoque fixo que já foi ressuprido depois deste consumo", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //            this.Cursor = Cursors.Default;
                //            return;
                //        }
                //    }                    
                //}
                #endregion

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

                //if (this.PermitirExclusao((decimal)dtoMovimento.Idt.Value))
                //{
                    if (MessageBox.Show("Deseja realmente estornar este consumo ?",
                                        "Gestão de Materiais e Medicamentos",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            // dtoMovimento.IdtProduto.Value = long.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colIdtProdutoHist"].Value.ToString());
                            // dtoMovimento.Qtde.Value = decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colQtdInteiraHist"].Value.ToString());
                            dtoMovimento.IdtUsuarioEstorno.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                            dtoMovimento.Idt.Value = decimal.Parse(dtgHistConsumo.Rows[e.RowIndex].Cells["colIdtMovimentoHist"].Value.ToString());
                            // Movimento.EstornarMovimentoCentroCirurgico(dtoMovimento);
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
                //}
                //else
                //{
                //    MessageBox.Show("Este consumo já foi faturado e não pode ser estornado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
                this.Cursor = Cursors.Default;
            }
        }

        private void tabConsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodProduto.Focus();
            tsHac.Items["tsBtnNovo"].Enabled = true;
        }

        private void cbCE_Click(object sender, EventArgs e)
        {
            if (cbCE.Checked)
            {
                //MessageBox.Show("O próximo consumo gerará um pedido para o almoxarifado, para o reabastecimento do carrinho de emergência", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show("Os próximos consumos gerarão um pedido para o almoxarifado, para o reabastecimento do carrinho de emergência.\n\nDepois de registrar o(s) consumo(s), clique em Finalizar Consumo do Carrinho de Emergência.",
                                "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbCE.Enabled = false;
                btnFinalizarCE.Visible = true;
                dtbRequisicaoItemCE = new RequisicaoItensDataTable();
            }
            else
            {
                dtoRequisicaoCE = null;
                dtbRequisicaoItemCE = null;
            }
            txtCodProduto.Focus();            
        }

        private void btnFinalizarCE_Click(object sender, EventArgs e)
        {            
            SalvarPedidoCE();
            cbCE.Checked = false;
            cbCE.Enabled = true;
            btnFinalizarCE.Visible = false;
            txtCodProduto.Focus();  
        }

        private void FrmConsumoPaciente_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !ZerarObjetos(true);
        }

        #endregion

        private bool tsHac_SalvarClick(object sender)
        {
            ConfiguraMovimentoDTO();
            dtoMovimento.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
            Movimento.SalvaMovimentoCentroCirurgico(dtoMovimento);
            CarregarHistoricoConsumo();
            return true;
        }
    }
}