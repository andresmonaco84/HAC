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
using HospitalAnaCosta.SGS.GestaoMateriais.Relatorio;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HacFramework.Windows.Helpers;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmRegistroPerda : FrmBase
    {
        Generico generico = new Generico();

        public FrmRegistroPerda()
        {
            InitializeComponent();
        }        

        #region OBJETOS SERVIÇOS

        // Estoque
        private EstoqueLocalDTO dtoEstoque;
        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject(typeof(IEstoqueLocal)); }
        }        

        // MatMed
        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject( typeof(IMaterialMedicamento)); }
        }

        // Movimentos
        private MovimentacaoDTO dtoMovPedido = null;
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

        // Motivo Perda
        // private MotivoPerdaDTO dtoMotivoPerda;
        private IMotivoPerda _motivoperda;
        private IMotivoPerda MotivoPerda
        {
            get { return _motivoperda != null ? _motivoperda : _motivoperda = (IMotivoPerda)Global.Common.GetObject(typeof(IMotivoPerda)); }
        }

        private IMatMedSetorConfig _matMedConfig;
        private IMatMedSetorConfig MatMedSetorConfig
        {
            get { return _matMedConfig != null ? _matMedConfig : _matMedConfig = (IMatMedSetorConfig)Global.Common.GetObject(typeof(IMatMedSetorConfig)); }
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

        private void ConfigurarMovimentoDTO()
        {
            if (cmbUnidade.SelectedIndex != -1) dtoMovimento.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            if (cmbLocal.SelectedIndex != -1) dtoMovimento.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            if (cmbSetor.SelectedIndex != -1) dtoMovimento.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            if (cmbMotivoPerda.SelectedIndex != -1) dtoMovimento.idtMotivo.Value = cmbMotivoPerda.SelectedValue.ToString();

            if (rbHac.Checked)
            {
                dtoMovimento.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
            }
            else if (rbAcs.Checked)
            {
                dtoMovimento.IdtFilial.Value = (int)FilialMatMedDTO.Filial.ACS;
            }
            else if (rbCE.Checked)
            {
                dtoMovimento.IdtFilial.Value = (int)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
            }
            else if (rbConsig.Checked)
            {
                dtoMovimento.IdtFilial.Value = (int)FilialMatMedDTO.Filial.CONSIGNADO;
            }

            if (txtQtdPerda.Text != string.Empty) dtoMovimento.Qtde.Value = txtQtdPerda.Text;

            dtoMovimento.UsuarioRelatado.Value = txtNomeColaborador.Text;
            dtoMovimento.Obs.Value = txtMotivoPerda.Text;

            dtoMovimento.IdtTipo.Value = (byte)MovimentacaoDTO.TipoMovimento.SAIDA;
            dtoMovimento.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_PERDA_QUEBRA;            
        }

        private void ConfiguraEstoqueDTO()
        {
            dtoEstoque = new EstoqueLocalDTO();            

            dtoEstoque.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoEstoque.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoEstoque.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoEstoque.IdtProduto.Value = dtoMatMed.Idt.Value;
            
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
            else if (rbConsig.Checked)
            {
                dtoEstoque.IdtFilial.Value = (int)FilialMatMedDTO.Filial.CONSIGNADO;
            }
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

        private void AtualizarQtdEstoque()
        {
            txtQtdEstoque.Text = txtQtdLote.Text = string.Empty;
            if (dtoMatMed != null)
            {
                this.ConfiguraEstoqueDTO();

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

                txtQtdPerda.Focus();
            }
            else
                txtIdProduto.Focus();
        }

        private void CarregarProduto()
        {
            if (dtoMatMed != null)
            {
                txtDsProduto.Text = dtoMatMed.NomeFantasia.Value;
                txtUnidadeVenda.Text = dtoMatMed.DsUnidadeVenda.Value;
            }
            else
            {
                txtDsProduto.Text = string.Empty;
                txtUnidadeVenda.Text = string.Empty;                
            }            
            this.AtualizarQtdEstoque();
            chkPedidoPers.Checked = false;
            txtPedido.Enabled = txtQtdPerda.ReadOnly = false;
            txtIdProduto.Text = txtPedido.Text = string.Empty;
        }

        private bool ValidarFilial()
        {
            if (!rbAcs.Checked && !rbHac.Checked && !rbCE.Checked && !rbConsig.Checked)
            {
                MessageBox.Show("Selecione a Filial", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private bool Validar()
        {
            if (!this.ValidarFilial()) return false;

            if (dtoMatMed == null)
            {
                MessageBox.Show("Selecione o Mat/Med", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (int.Parse(txtQtdPerda.Text) <= 0)
            {
                MessageBox.Show("Qtd. Perda deve ser maior que 0", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            #region retirado
            //if (dtoMatMed.FlFracionado.Value == "1")
            //{
            //    if (dtoEstoque.QtdeFracionada.Value.IsNull) dtoEstoque.QtdeFracionada.Value = 0;

            //    int qtdMaxFrac = ((int)dtoMatMed.UnidadeVenda.Value - (int)dtoEstoque.QtdeFracionada.Value);

            //    if (int.Parse(txtQtdPerda.Text) > qtdMaxFrac)
            //    {
            //        MessageBox.Show(string.Format("Qtd. Perda deve ser menor ou igual à {0}, que é o equivalente ao restante do frasco em uso", qtdMaxFrac),
            //                        "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return false;
            //    }
            //}
            //else
            //{
            //    if (int.Parse(txtQtdPerda.Text) > int.Parse(txtQtdEstoque.Text))
            //    {
            //        MessageBox.Show("Qtd. Perda deve ser menor ou igual à Qtd. Estoque", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return false;
            //    }
            //}
            #endregion

            if (string.IsNullOrEmpty(txtPedido.Text) && int.Parse(txtQtdPerda.Text) > int.Parse(txtQtdEstoque.Text))
            {
                MessageBox.Show("Qtd. Perda deve ser menor ou igual à Qtd. Estoque", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }            

            return true;
        }  

        private bool Salvar()
        {
            if (!this.Validar()) return false;
            if (chkPedidoPers.Checked && string.IsNullOrEmpty(txtPedido.Text))
            {
                MessageBox.Show("Pedido não informado!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!string.IsNullOrEmpty(txtPedido.Text))
            {
                int qtdPerda = int.Parse(txtQtdPerda.Text);
                if (AtualizarQtdPedido())
                {
                    if (qtdPerda > _qtdPerdaPedido)
                    {
                        MessageBox.Show("Qtd. Perda referente ao Pedido não pode ser maior que " + _qtdPerdaPedido, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    txtQtdPerda.Text = qtdPerda.ToString();
                    dtoMovimento.IdtRequisicao.Value = txtPedido.Text;

                    if (dtoMovPedido != null && dtoMovPedido.Idt.Value > 0)
                    {
                        dtoMovPedido.IdtUsuarioEstorno.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                        if (Movimento.PermitirEstornoConsumoItem(ref dtoMovPedido))
                        {
                            DataTable dtbMov = Movimento.ObterSaidasCentroDispPedidoAnalitico(dtoMovPedido, new Generico().UtiCompartilhada(int.Parse(cmbSetor.SelectedValue.ToString())), false);
                            if (dtbMov.Rows.Count > 0)
                            {
                                Movimento.EstornarMovimentoConsumoPaciente(dtoMovPedido);
                                if (!new Generico().UtiCompartilhada(int.Parse(cmbSetor.SelectedValue.ToString())))
                                    Movimento.MarcarEstornoMovimento(decimal.Parse(dtbMov.Rows[0][MovimentacaoDTO.FieldNames.Idt].ToString()));
                            }
                        }
                        else
                        {
                            MessageBox.Show("Item já faturado!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                    }
                }
                else
                    return false;
            }
            else
            {
                if (dtoEstoque == null || dtoEstoque.IdtProduto.Value.IsNull)
                    ConfiguraEstoqueDTO();                

                if (!new Generico().PermitirMovimentacaoItemNaoPadrao(dtoEstoque, dtoMatMed))
                {
                    MessageBox.Show("Movimentação permitida apenas para MAT/MED Padrão!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            try
            {
                ConfigurarMovimentoDTO();
                dtoMovimento.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                if (!dtoMatMed.IdtLote.Value.IsNull && (decimal)dtoMatMed.IdtLote.Value != 0) dtoMovimento.IdtLote.Value = dtoMatMed.IdtLote.Value;
                dtoMovimento = Movimento.MovimentaEstoqueProduto(dtoMovimento, dtoMatMed, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }            
            this.AtualizarQtdEstoque();
            if (rbCE.Checked) this.SalvarPedidoCE();
            MessageBox.Show("Perda registrada com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtPedido.Enabled = false;
            return true;
        }

        /// <summary>
        /// Gera Requisição do Carrinho de Emergencia
        /// </summary>
        private void SalvarPedidoCE()
        {
            try
            {
                dtbRequisicaoItemCE = new RequisicaoItensDataTable();
                dtoRequisicaoItemCE = RequisicaoItens.ConverteMatMedRequisicao(dtoMatMed);

                dtoRequisicaoItemCE.QtdSolicitada.Value = txtQtdPerda.Text;
                dtbRequisicaoItemCE.Add(dtoRequisicaoItemCE);

                ConfiguraRequisicaoCEDTO();
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

        private void VerificaEstoqueUnificado()
        {
            MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();
            dtoCfg.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoCfg.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoCfg.Idtsetor.Value = cmbSetor.SelectedValue.ToString();
            dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);
            if (dtoCfg.EstoqueUnificadoHAC.Value.IsNull) dtoCfg.EstoqueUnificadoHAC.Value = 0;
            if (dtoCfg.EstoqueUnificadoHAC.Value == 1)
            {
                //rbCE.Text = "EU";                
                //grbFilial.Visible = false;
                lblEstoqueUnificado.Text = "ESTOQUE ÚNICO HAC";
            }
            else
            {
                rbCE.Text = "CE";                
                grbFilial.Visible = true;
                lblEstoqueUnificado.Text = string.Empty;
            }
        }

        private int _qtdPerdaPedido = 0;
        private bool AtualizarQtdPedido()
        {
            dtoMovPedido = null;
            _qtdPerdaPedido = 0;
            if (new Generico().ItemBaixaAutomaticaDispensa(dtoMatMed))
            {
                this.Cursor = Cursors.WaitCursor;
                RequisicaoDTO dtoPedido = new RequisicaoDTO();
                dtoPedido.Idt.Value = txtPedido.Text;
                dtoPedido = Requisicao.SelChave(dtoPedido);
                if (dtoPedido.IdtAtendimento.Value.IsNull)
                {
                    MessageBox.Show("Pedido não Personalizado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPedido.Text = txtQtdPerda.Text = string.Empty;
                    txtPedido.Focus();
                    this.Cursor = Cursors.Default;
                    return false;
                }
                MovimentacaoDTO dtoMov = new MovimentacaoDTO();
                dtoMov.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                dtoMov.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                dtoMov.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                dtoMov.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                dtoMov.IdtProduto.Value = dtoMatMed.Idt.Value;
                if (!dtoMatMed.IdtLote.Value.IsNull && dtoMatMed.IdtLote.Value != 0)
                    dtoMov.IdtLote.Value = dtoMatMed.IdtLote.Value;
                dtoMov.Qtde.Value = 1;
                dtoMov.IdtUsuarioEstorno.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                dtoMov.IdtRequisicao.Value = txtPedido.Text;
                dtoMov.Idt.Value = Movimento.ObterIdMovimentoBaixaAutoDispensaPaciente(dtoMov);

                if (dtoMov.Idt.Value == 0)
                {
                    bool registroNaoEncontrado = true;
                    if ((decimal)dtoMatMed.IdtGrupo.Value != 1 && //Se não for medicamento tentar buscar ignorando lote
                        !dtoMov.IdtLote.Value.IsNull && dtoMatMed.IdtLote.Value != 0) 
                    {
                        dtoMov.IdtLote.Value = new Framework.DTO.TypeDecimal();
                        dtoMov.Idt.Value = Movimento.ObterIdMovimentoBaixaAutoDispensaPaciente(dtoMov);
                        if (dtoMov.Idt.Value != 0) registroNaoEncontrado = false;
                    }
                    if (registroNaoEncontrado)
                    {
                        MessageBox.Show("Pedido/Produto não encontrado com consumo para nenhum paciente", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtPedido.Text = txtQtdPerda.Text = string.Empty;
                        txtPedido.Focus();
                        this.Cursor = Cursors.Default;
                        return false;
                    }
                    else
                    {
                        dtoMovPedido = dtoMov;
                        _qtdPerdaPedido = (int)dtoMov.Qtde.Value;
                        txtQtdPerda.Text = _qtdPerdaPedido.ToString();
                    }
                }
                else
                {
                    dtoMovPedido = dtoMov;
                    _qtdPerdaPedido = (int)dtoMov.Qtde.Value;
                    txtQtdPerda.Text = _qtdPerdaPedido.ToString();
                }

                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Produto tem que ser inteiro para poder vincular ao pedido de um paciente", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPedido.Text = txtQtdPerda.Text = string.Empty;
                txtPedido.Focus();                
                return false;
            }
            return true;
        }

        private bool ValidarPeriodo()
        {
            if (txtDtIni.Text == string.Empty)
            {
                MessageBox.Show("Digite a Data Início", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDtIni.Focus();
                return false;
            }
            else if (txtDtIni.Text != string.Empty && txtDtFim.Text == string.Empty)
            {
                txtDtFim.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            }            
            try
            {
                if (Convert.ToDateTime(txtDtFim.Text).Date < Convert.ToDateTime(txtDtIni.Text).Date)
                {
                    MessageBox.Show("A Data Fim deve ser maior ou igual à Data Início.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDtFim.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Data inválida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Convert.ToDateTime(txtDtFim.Text).Date > Convert.ToDateTime(txtDtIni.Text).Date.AddMonths(3).Date)
            {
                MessageBox.Show("Período não pode ser superior a 3 meses.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDtFim.Focus();
                return false;
            }            
            return true;
        }

        #endregion

        #region EVENTOS

        private void FrmRegistroPerda_Load(object sender, EventArgs e)
        {
            cmbUnidade.Carregaunidade();
            cmbMotivoPerda.DisplayMember = MotivoPerdaDTO.FieldNames.DsMotivo;
            cmbMotivoPerda.ValueMember = MotivoPerdaDTO.FieldNames.idtMotivo;
            MotivoPerdaDataTable dtbMP = MotivoPerda.Sel(new MotivoPerdaDTO(), "0");

            chlMotivo.Items.Add(new ListItem("-1", "< SELECIONAR TODOS OS MOTIVOS >"), true);
            foreach (DataRow row in dtbMP.Rows)
                chlMotivo.Items.Add(new ListItem(row[MotivoPerdaDTO.FieldNames.idtMotivo].ToString(), row[MotivoPerdaDTO.FieldNames.DsMotivo].ToString()), true);

            if (!new Generico().VerificaAcessoFuncionalidade("RegistrarPerdaConferenciaQtde"))
            {                
                foreach (DataRow row in dtbMP.Rows)
                {   //Retirar ID 9 - CONFERÊNCIA DE QTDE.
                    if (int.Parse(row[MotivoPerdaDTO.FieldNames.idtMotivo].ToString()) == 9)
                    {
                        row.Delete();
                        dtbMP.AcceptChanges();
                        break;
                    }
                }
            }
            cmbMotivoPerda.DataSource = dtbMP;
            cmbMotivoPerda.IniciaLista();
            Generico.ConfiguraCombos(cmbUnidade,cmbLocal,cmbSetor,FrmPrincipal.dtoSeguranca);
            VerificaEstoqueUnificado();
            txtDataPerda.Text = DateTime.Now.ToShortDateString();
        }

        private bool tsHac_CancelarClick(object sender)
        {
            dtoMatMed = null;
            dtoMovPedido = null;
            _qtdPerdaPedido = 0;
            txtPedido.Enabled = txtQtdPerda.ReadOnly = false;
            return true;
        }
        
        private bool tsHac_NovoClick(object sender)
        {
            dtoMatMed = null;
            dtoMovPedido = null;
            _qtdPerdaPedido = 0;
            txtPedido.Enabled = txtQtdPerda.ReadOnly = false;
            return true;
        }

        private bool tsHac_SalvarClick(object sender)
        {
            return this.Salvar();
        }

        private bool tsHac_MatMedClick(object sender)
        {
            if (!ValidarFilial()) return false;

            dtoMatMed = new MaterialMedicamentoDTO();
            
            ConfigurarMovimentoDTO();

            dtoMatMed.IdtUnidade.Value = dtoMovimento.IdtUnidade.Value;
            dtoMatMed.IdtLocal.Value = dtoMovimento.IdtLocal.Value;
            dtoMatMed.IdtSetor.Value = dtoMovimento.IdtSetor.Value;
            if (rbCE.Checked || rbConsig.Checked)
            {
                dtoMatMed.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            }
            else
            {
                dtoMatMed.IdtFilial.Value = dtoMovimento.IdtFilial.Value;
            }
            dtoMatMed.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.COM_PERMISSAO_SUBGRUPO;

            dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMed);

            if (dtoMatMed != null)
            {
                if (!dtoMatMed.IdtGrupo.Value.IsNull && (int)dtoMatMed.IdtGrupo.Value == 1)
                {
                    MessageBox.Show("Obrigatório baixa pelo Código de Barra para Medicamentos !", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdProduto.Focus();
                    return false;                 
                }
            }  
            this.CarregarProduto();            

            return true;
        }

        private void txtIdProduto_Validating(object sender, CancelEventArgs e)
        {
            if (txtIdProduto.Text != string.Empty)
            {
                if (!this.ValidarFilial())
                {
                    txtIdProduto.Text = string.Empty;
                    return;
                } 

                CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();

                dtoCodigoBarra.CdBarra.Value = txtIdProduto.Text;
                // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
                dtoMatMed = MatMed.BuscaCodigoBarra(dtoCodigoBarra);

                this.CarregarProduto();

                if (dtoMatMed == null)
                {                    
                    MessageBox.Show("Material/medicamento não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtIdProduto.Focus();
                }                
            }
        }

        private void rbHac_CheckedChanged(object sender, EventArgs e)
        {
            this.AtualizarQtdEstoque();
            chkPedidoPers.Checked = false;
            txtPedido.Enabled = txtQtdPerda.ReadOnly = false;
            txtPedido.Text = string.Empty;
        }

        private void rbAcs_CheckedChanged(object sender, EventArgs e)
        {
            this.AtualizarQtdEstoque();
        }

        private void rbAcs_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblEstoqueUnificado.Text))
            {
                rbAcs.Checked = false;
                rbHac.Checked = true;
                MessageBox.Show("Não é possível registrar perda para o ACS, pois é Estoque Único.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            chkPedidoPers.Checked = false;
            txtPedido.Enabled = txtQtdPerda.ReadOnly = false;
            txtPedido.Text = string.Empty;
        }

        private void rbCE_CheckedChanged(object sender, EventArgs e)
        {
            rbHac_CheckedChanged(sender, e);            
        }

        private void rbConsig_CheckedChanged(object sender, EventArgs e)
        {
            rbHac_CheckedChanged(sender, e);
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            if (!ValidarFilial()) return false;
            if (generico.VerificaAcessoFuncionalidade("cmbUnidade")) chkSetores.Enabled = true;
            
            // configura panel
            pnlPeriodo.BorderStyle = BorderStyle.FixedSingle;
            pnlPeriodo.Visible = true;
            // configura panel

            return default(bool);
        }

        private void hacButton1_Click(object sender, EventArgs e)
        {
            if (!ValidarPeriodo()) return;

            if (!chkSetores.Checked && cmbSetor.SelectedValue == null)
            {
                MessageBox.Show("Selecione o Setor", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string nomeRelatorio;
            string sUnidade;
            string sLocal;
            string sSetor;
            decimal nFilial = generico.RetornaFilial(rbHac, rbAcs, rbCE, rbConsig);
            string sEstoque = " ESTOQUE " + (nFilial == 1 ? " HAC " : (nFilial == 4 ? " HAC " : " ACS "));
            int x = 0;

            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[8];

            #region Monta Parâmetros


            if (chkSetores.Checked)
            {
                nomeRelatorio = "GM_RegistrodePerdasGeral";
                sUnidade = null;
                sLocal = null;
                sSetor = null;
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("sUnidade", "Todas as Unidades" + sEstoque);
            }
            else
            {
                nomeRelatorio = "GM_RegistrodePerdas";
                sUnidade = cmbUnidade.SelectedValue.ToString();
                sLocal = cmbLocal.SelectedValue.ToString();
                sSetor = cmbSetor.SelectedValue.ToString();
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("sUnidade", string.Format("{0} / {1} / {2} {3}", cmbUnidade.Text, cmbLocal.Text, cmbSetor.Text, sEstoque));
            }
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_UNI_ID_UNIDADE", sUnidade);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_LAT_ID_LOCAL_ATENDIMENTO", sLocal);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_SET_ID", sSetor);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_FILIAL_ID", generico.RetornaFilial(rbHac, rbAcs, rbCE, rbConsig).ToString());
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_DATA_INI", txtDtIni.Text.ToString());
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_DATA_FIM", txtDtFim.Text.ToString());
            string motivos = null;
            if (!chlMotivo.GetItemChecked(0)) //Se não tiver com item "< SELECIONAR TODOS OS MOTIVOS >" checado (1° item), gerar string com os selecionados
            {
                for (int index = 1; index < chlMotivo.Items.Count; index++)
                {
                    if (chlMotivo.GetItemChecked(index))
                    {
                        if (!string.IsNullOrEmpty(motivos)) motivos += ",";
                        motivos += ((ListItem)chlMotivo.Items[index]).Key;                        
                    }
                }
                //if (motivos == ",") motivos = null;
            }
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PIDs_MOTIVO", motivos);

            #endregion

            //Microsoft.Reporting.WinForms.ReportParameter[] reportParamTemp = new Microsoft.Reporting.WinForms.ReportParameter[x];

            //for (int i = 0; i < reportParam.Length; i++)
            //{
            //    if (reportParam[i] == null) break;
            //    reportParamTemp[i] = reportParam[i];
            //}
            //reportParam = reportParamTemp;
            //reportParamTemp = null;

            FrmReportViewer frmRelatorio = new FrmReportViewer();
            frmRelatorio.AbreRelatorio(nomeRelatorio, reportParam);
            // frmRelatorio.MdiParent = FrmPrincipal.ActiveForm;
            // frmRelatorio.Show();
        }

        private void hacButton2_Click(object sender, EventArgs e)
        {
            pnlPeriodo.Visible = false;
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            VerificaEstoqueUnificado();
            dtoMatMed = null;
            dtoMovPedido = null;
            _qtdPerdaPedido = 0;
            tsHac.Controla(Evento.eCancelar);
        }

        private void cmbMotivoPerda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!chkPedidoPers.Checked &&
                (cmbMotivoPerda.SelectedIndex > -1 && cmbMotivoPerda.SelectedValue.ToString() == "11"))
            {
                MessageBox.Show("Este motivo só pode ser selecionado quando for vincular registro a algum pedido.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbMotivoPerda.SelectedIndex = -1;
                cmbMotivoPerda.IniciaLista();
            }
        }

        private void chlMotivo_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void chlMotivo_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void chlMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = ((CheckedListBox)sender).SelectedIndex;
            ListItem item = (ListItem)((CheckedListBox)sender).SelectedItem;
            if (item.Key == "-1")
            {
                this.Cursor = Cursors.WaitCursor;
                for (int index = 0; index < chlMotivo.Items.Count; index++)
                {
                    chlMotivo.SetItemChecked(index, chlMotivo.GetItemChecked(0));
                }
                this.Cursor = Cursors.Default;
            }
            else if (!chlMotivo.GetItemChecked(indice))
                chlMotivo.SetItemChecked(0, false);            
        }

        private void chkPedidoPers_Click(object sender, EventArgs e)
        {
            dtoMovPedido = null;
            if (chkPedidoPers.Checked)
            {
                if (!rbHac.Checked)
                {
                    MessageBox.Show("Opção permitida apenas para Estoque HAC.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    chkPedidoPers.Checked = false;
                    return;
                }
                _qtdPerdaPedido = 0;
                txtQtdPerda.Text = string.Empty;
                txtPedido.Enabled = true; //txtQtdPerda.ReadOnly = true;
                try
                {
                    cmbMotivoPerda.SelectedValue = 11;
                    cmbMotivoPerda.Enabled = false;
                    txtPedido.Focus();
                }
                catch
                {
                    cmbMotivoPerda.SelectedIndex = -1;
                    cmbMotivoPerda.IniciaLista();
                }
            }
            else
            {
                txtPedido.Text = string.Empty;
                txtPedido.Enabled = txtQtdPerda.ReadOnly = false;
                cmbMotivoPerda.Enabled = true;
                cmbMotivoPerda.SelectedIndex = -1;
                cmbMotivoPerda.IniciaLista();
            }
        }

        private void txtPedido_Validating(object sender, CancelEventArgs e)
        {
            dtoMovPedido = null;
            if (chkPedidoPers.Checked && !string.IsNullOrEmpty(txtPedido.Text) &&
                (dtoMatMed != null && !dtoMatMed.Idt.Value.IsNull))
            {
                AtualizarQtdPedido();
                txtQtdPerda.ReadOnly = false;
                if (!string.IsNullOrEmpty(txtPedido.Text))
                {
                    //txtQtdPerda.ReadOnly = true;
                    txtNomeColaborador.Focus();
                }
            }
            else if (chkPedidoPers.Checked)
            {
                _qtdPerdaPedido = 0;
                txtQtdPerda.Text = string.Empty;
                //txtQtdPerda.ReadOnly = true;
                if (dtoMatMed == null && txtPedido.Text != string.Empty)
                {
                    MessageBox.Show("Selecione o Produto", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPedido.Text = string.Empty;
                    txtIdProduto.Focus();
                }
            }
            else
                txtQtdPerda.ReadOnly = false;
        }

        private void txtQtdPerda_Validating(object sender, CancelEventArgs e) {}

        private void btnPlanilhaSint_Click(object sender, EventArgs e)
        {
            if (!ValidarPeriodo()) return;

            string nomeRelatorio = "GM_44_PERDAS_SINTETICO";
            decimal nFilial = generico.RetornaFilial(rbHac, rbAcs, rbCE, rbConsig);
            string sEstoque = " ESTOQUE " + (nFilial == 1 ? " HAC " : (nFilial == 4 ? " CE " : " ACS "));
            int x = 0;

            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[4];

            #region Monta Parâmetros

            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pESTOQUE", sEstoque);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_FILIAL_ID", generico.RetornaFilial(rbHac, rbAcs, rbCE, rbConsig).ToString());
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_DATA_INI", txtDtIni.Text.ToString());
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_DATA_FIM", txtDtFim.Text.ToString());

            #endregion            

            FrmReportViewer frmRelatorio = new FrmReportViewer();
            frmRelatorio.AbreRelatorio(nomeRelatorio, reportParam);
        }

        #endregion                
    }
}