using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.Forms;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmDispensacao : FrmBase
    {
        FrmDispensacaoPendencias frmPendencias;
        private const int _qtdMinimaMaterialParaDigitar = 10;
        private int _ultimoProdutoInserido;
        private bool _salvoSucesso = false;
        private bool _logadoAlmoxCentral = false;
        private bool _logadoCentroCirurgico = false;
        private const decimal CENTRO_CIRURGICO = 61;

        public FrmDispensacao()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇO
        
        //private CommonCadastro _commonCadastro;
        //private new CommonCadastro CommonCadastro
        //{
        //    get { return _commonCadastro != null ? _commonCadastro : _commonCadastro = new CommonCadastro(null); }
        //}
        
        // Atendimento
        private PacienteDTO dtoAtendimento;
        private IPaciente _atendimento;
        private IPaciente Atendimento
        {
            get { return _atendimento != null ? _atendimento : _atendimento = (IPaciente)Global.Common.GetObject( typeof(IPaciente)); }
        }

        // Requisição
        private RequisicaoDTO dtoRequisicao;
        private IRequisicao _requisicao;
        private IRequisicao Requisicao
        {
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject( typeof(IRequisicao)); }
        }

        // Itens Requisição
        private RequisicaoItensDTO dtoRequisicaoItem;
        private RequisicaoItensDataTable dtbReqItem;
        private RequisicaoItensDataTable dtbItensKit;
        //private RequisicaoItensDataTable dtbReqItemDispensado;
        private IRequisicaoItens _ReqItem;
        private IRequisicaoItens RequisicaoItem 
        {
            get { return _ReqItem != null ? _ReqItem : _ReqItem = (IRequisicaoItens)Global.Common.GetObject( typeof(IRequisicaoItens)); }
        }

        // MatMed
        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject( typeof(IMaterialMedicamento)); }
        }

        // Kit
        private IKit _kit;
        private IKit Kit
        {
            get { return _kit != null ? _kit : _kit = (IKit)Global.Common.GetObject(typeof(IKit)); }
        }

        // Estoque        
        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject( typeof(IEstoqueLocal)); }
        }

        // Movimentos        
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject( typeof(IMovimentacao)); }
        }

        MovimentacaoDTO dtoMovimento = new MovimentacaoDTO();

        private IMatMedSetorConfig _matMedConfig;
        private IMatMedSetorConfig MatMedSetorConfig
        {
            get { return _matMedConfig != null ? _matMedConfig : _matMedConfig = (IMatMedSetorConfig)Global.Common.GetObject(typeof(IMatMedSetorConfig)); }
        }
        
        private ISetor _isetor;
        private ISetor Setor
        {
            get { return _isetor != null ? _isetor : _isetor = (ISetor)Global.Common.GetObject(typeof(ISetor)); }
        }

        private Generico gen = new Generico();

        #endregion        

        #region FUNÇÕES

        private void ConfiguraItensDTG()
        {
            dtgMatMed.AutoGenerateColumns = false;
            dtgMatMed.Columns["colReqItemIdt"].DataPropertyName = RequisicaoItensDTO.FieldNames.Idt;
            dtgMatMed.Columns["colMatMedIdt"].DataPropertyName = RequisicaoItensDTO.FieldNames.IdtProduto;
            dtgMatMed.Columns["colDsProd"].DataPropertyName = RequisicaoItensDTO.FieldNames.DsProduto;
            dtgMatMed.Columns["colDsUnidadeVenda"].DataPropertyName = RequisicaoItensDTO.FieldNames.DsUnidadeVenda;
            dtgMatMed.Columns["colUnidadeMedidaItem"].DataPropertyName = RequisicaoItensDTO.FieldNames.UnidadeCompra;
            dtgMatMed.Columns["colQtde"].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdSolicitada;
            dtgMatMed.Columns["colQtde"].DefaultCellStyle.Format = "N0";
            dtgMatMed.Columns["colQtdeFornecida"].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdFornecida;
            dtgMatMed.Columns["colQtdeFornecida"].DefaultCellStyle.Format = "N0";
            dtgMatMed.Columns["colDssimilar"].DataPropertyName = RequisicaoItensDTO.FieldNames.DsProdutoOriginal;
            dtgMatMed.Columns[colMAV_Disp.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia;
            // dtgMatMed.Columns["colQtdePadrao"].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdePadrao;
            // dtgMatMed.Columns["colQtdePadrao"].DefaultCellStyle.Format = "N0";
            // dtgMatMed.Columns["colEstoqueLocal"].DataPropertyName = RequisicaoItensDTO.FieldNames.EstoqueLocalQtde;
            // dtgMatMed.Columns["colEstoqueLocal"].DefaultCellStyle.Format = "N0";
            // dtgMatMed.Columns["colQtdCentDisp"].DataPropertyName = RequisicaoItensDTO.FieldNames.EstoqueCentDispQtde;
            // dtgMatMed.Columns["colQtdCentDisp"].DefaultCellStyle.Format = "N0";
        }

        private void ConfiguraItensPendentesDTG()
        {
            dtgItensPendentes.AutoGenerateColumns = false;
            dtgItensPendentes.Columns["colMatMedIdtPend"].DataPropertyName = RequisicaoItensDTO.FieldNames.IdtProduto;
            dtgItensPendentes.Columns["colDsMatMedPend"].DataPropertyName = RequisicaoItensDTO.FieldNames.DsProduto;
            dtgItensPendentes.Columns["colQtdReqPend"].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdSolicitada;
            dtgItensPendentes.Columns["colQtdReqPend"].DefaultCellStyle.Format = "N0";
            dtgItensPendentes.Columns["colQtdFornPend"].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdFornecida;
            dtgItensPendentes.Columns["colQtdFornPend"].DefaultCellStyle.Format = "N0";            
            dtgItensPendentes.Columns["colQtdPendente"].DefaultCellStyle.Format = "N0";
            dtgItensPendentes.Columns[colMAV.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia;
        }
        
        private bool ValidarDispensada()
        {
            RequisicaoDTO dtoRequisicaoAux = new RequisicaoDTO();

            dtoRequisicaoAux.Idt.Value = dtoRequisicao.Idt.Value;
            dtoRequisicaoAux = Requisicao.SelChave(dtoRequisicaoAux);

            if (dtoRequisicaoAux.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX ||
                dtoRequisicaoAux.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.RECEBIDA_UNIDADE)
            {
                MessageBox.Show("Este pedido já foi dispensado por outro processo", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.ZerarObjetos();
                tsHac.Controla(Evento.eCancelar);
                return false;
            }
            return true;
        }

        private int RetornaLinhaUltimoProduto(int Ultimo)
        {
            RequisicaoItensDTO dtoItensTmp = new RequisicaoItensDTO();
            DataRow Linha = dtbReqItem.NewRow();
            for (int i = 0; i < dtbReqItem.Rows.Count; i++)
            {                
                dtoItensTmp = dtbReqItem.TypedRow(i);
                if (dtoItensTmp.IdtProduto.Value == Ultimo)
                {
                    DataRow rowDisp = dtbReqItem.NewRow();
                    // PEGA VALORES COLUNA POR COLUNA
                    for (int index = 0; index <= dtbReqItem.Rows[i].ItemArray.Length - 1; index++)
                    {
                        rowDisp[index] = dtbReqItem.Rows[i].ItemArray[index];
                    }
                    dtbReqItem.Rows.RemoveAt(i);
                    dtbReqItem.Rows.InsertAt(rowDisp, 0);
                }
            }            
            return 0;
        }

        private bool LogadoAlmoxCentral()
        {            
            return gen.SetorAlmoxCentral((int)FrmPrincipal.dtoSeguranca.IdtSetor.Value);
        }

        private bool PedidoFarmaciaCentroCirurgico(int idtSetorPedido)
        {
            if (idtSetorPedido == CENTRO_CIRURGICO && _logadoCentroCirurgico)
                return true;

            return false;
        }

        private void AdicionarItemDispensa(int? qtdFornecerAuto)
        {
            if (!ValidarDispensada()) return;

            if (dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO && dtoRequisicao.IdtAtendimento.Value.IsNull)
            {
                MessageBox.Show("Paciente não carregado corretamente", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int qtdForn = 0;
            txtIdProduto.Text = string.Empty;
            txtIdProduto.Focus();

            // chama metodo que vai inserir item para dispensação
            dtoRequisicaoItem = new RequisicaoItensDTO();
            dtoRequisicaoItem.Idt.Value = dtoRequisicao.Idt.Value;
            dtoRequisicaoItem.IdtProduto.Value = dtoMatMed.Idt.Value;
            dtoRequisicaoItem.IdtPrincipioAtivo.Value = dtoMatMed.IdtPrincipioAtivo.Value;            

            try
            {
                // #####################################################################
                dtoRequisicaoItem = RequisicaoItem.SelQtdeSolicitada(dtoRequisicaoItem);
                // #####################################################################                

                if (dtoRequisicaoItem != null)
                {
                    dtoRequisicaoItem.DsProduto.Value = dtoMatMed.NomeFantasia.Value;
                    if (qtdFornecerAuto == null)
                    {
                        if (_logadoAlmoxCentral && dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PADRAO)
                            qtdForn = DigitarQtde();
                        else if (dtoMatMed.Tabelamedica.Value == ((int)MaterialMedicamentoDTO.TipoMatMed.MATERIAL).ToString() &&
                                dtoRequisicaoItem.QtdSolicitada.Value > _qtdMinimaMaterialParaDigitar)
                            qtdForn = DigitarQtde();
                        else
                            qtdForn = 1;                        
                    }
                    else
                        qtdForn = qtdFornecerAuto.Value;

                    if (qtdForn > 0)
                    {
                        dtoRequisicaoItem.IdtUsuarioDispensacao.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                        if (!dtoMatMed.IdtLote.Value.IsNull) dtoRequisicaoItem.IdtLote.Value = dtoMatMed.IdtLote.Value;

                        if (gen.TipoPedidoEntradaAuto(dtoRequisicao))
                        {
                            if (dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO)
                            {
                                //Adicionar Personalizado de forma unitária por causa da devolução (possibilidade de estornar parte dos materiais)
                                for (int qtdAdd = 1; qtdAdd <= qtdForn; qtdAdd++)
                                {
                                    dtoRequisicaoItem.QtdFornecida.Value = 1;
                                    if (!gen.UtiCompartilhada((int)dtoRequisicao.IdtSetor.Value) &&
                                        !PedidoFarmaciaCentroCirurgico((int)dtoRequisicao.IdtSetor.Value))
                                    {
                                        RequisicaoItem.InsReqItemDispensacao(dtoRequisicaoItem);
                                    }

                                    if ((int)dtoRequisicao.IdtSetor.Value != CENTRO_CIRURGICO || PedidoFarmaciaCentroCirurgico((int)dtoRequisicao.IdtSetor.Value))                                        
                                        this.DarBaixaAutomatica((int)dtoRequisicaoItem.QtdFornecida.Value);
                                    
                                    if (dtoMatMed.Tabelamedica.Value == ((int)MaterialMedicamentoDTO.TipoMatMed.MEDICAMENTO).ToString() && qtdAdd == 1)
                                    {
                                        if (!gen.SetorPediatria((int)dtoRequisicao.IdtSetor.Value)) //Não faturar automático para PEDIATRIA, pois os kits são diferentes
                                        {
                                            KitDataTable dtbMateriaisKit = Kit.ListarMateriaisAplicaMedicamento(dtoMatMed);
                                            MovimentacaoDTO dtoMovFat;
                                            foreach (DataRow row in dtbMateriaisKit.Rows)
                                            {
                                                dtoMovFat = new MovimentacaoDTO();

                                                dtoMovFat.IdtRequisicao.Value = dtoRequisicao.Idt.Value;
                                                dtoMovFat.IdtFilial.Value = dtoRequisicao.IdtFilial.Value;
                                                dtoMovFat.IdtUnidade.Value = dtoRequisicao.IdtUnidade.Value;
                                                dtoMovFat.IdtLocal.Value = dtoRequisicao.IdtLocal.Value;
                                                dtoMovFat.IdtSetor.Value = dtoRequisicao.IdtSetor.Value;
                                                dtoMovFat.IdtAtendimento.Value = dtoRequisicao.IdtAtendimento.Value;
                                                dtoMovFat.TpAtendimento.Value = dtoRequisicao.TpAtendimento.Value;

                                                dtoMovFat.IdtTipo.Value = (byte)MovimentacaoDTO.TipoMovimento.SAIDA;
                                                dtoMovFat.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.INFO_ENVIO_FATURAMENTO;
                                                dtoMovFat.FlFinalizado.Value = 1;
                                                dtoMovFat.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                                                dtoMovFat.Qtde.Value = int.Parse(row[KitDTO.FieldNames.QtdeItem].ToString());
                                                dtoMovFat.IdtProduto.Value = int.Parse(row[MaterialMedicamentoDTO.FieldNames.Idt].ToString());

                                                MaterialMedicamentoDTO dtoMat = new MaterialMedicamentoDTO();
                                                dtoMat.Idt.Value = dtoMovFat.IdtProduto.Value;

                                                dtoMovimento = Movimento.EnviaProdutoFaturamento(dtoMovFat, MatMed.SelChave(dtoMat), null);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                dtoRequisicaoItem.QtdFornecida.Value = qtdForn;
                                if (!gen.UtiCompartilhada((int)dtoRequisicao.IdtSetor.Value) &&
                                    !PedidoFarmaciaCentroCirurgico((int)dtoRequisicao.IdtSetor.Value))
                                    RequisicaoItem.InsReqItemDispensacao(dtoRequisicaoItem);

                                this.DarBaixaAutomatica(qtdForn);
                            }                            
                        }
                        else
                        {
                            dtoRequisicaoItem.QtdFornecida.Value = qtdForn;                            
                            if (!gen.UtiCompartilhada((int)dtoRequisicao.IdtSetor.Value) || dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.CARRINHO_EMERGENCIA)
                                RequisicaoItem.InsReqItemDispensacao(dtoRequisicaoItem);
                        }

                        if (qtdFornecerAuto == null)
                        {
                            _ultimoProdutoInserido = (int)dtoRequisicaoItem.IdtProduto.Value;

                            dtbReqItem = RequisicaoItem.SelReqItensDispensacao(dtoRequisicao);
                            dtgMatMed.DataSource = dtbReqItem;
                            // procura ultimo produto inserido
                            int linha = RetornaLinhaUltimoProduto(_ultimoProdutoInserido);
                            dtgMatMed.Rows[linha].Selected = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Produto não consta neste pedido", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception e)
            {
                if (qtdFornecerAuto == null)
                    MessageBox.Show(e.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void DarBaixaAutomatica(int qtde)
        {
            if (gen.ItemBaixaAutomaticaDispensa(dtoMatMed))
            {
                dtoMovimento = new MovimentacaoDTO();

                dtoMovimento.IdtUnidade.Value = dtoRequisicao.IdtUnidade.Value;
                dtoMovimento.IdtLocal.Value = dtoRequisicao.IdtLocal.Value;
                dtoMovimento.IdtSetor.Value = dtoRequisicao.IdtSetor.Value;
                dtoMovimento.IdtRequisicao.Value = dtoRequisicao.Idt.Value;
                dtoMovimento.IdtAtendimento.Value = dtoRequisicao.IdtAtendimento.Value;

                if (dtoAtendimento != null)
                {
                    dtoMovimento.DtFaturamento.Value = dtoAtendimento.DtTransf.Value;
                    dtoMovimento.HrFaturamento.Value = dtoAtendimento.HrTransf.Value;
                    dtoAtendimento.IdtLocalAtendimento.Value = dtoRequisicao.IdtLocal.Value;
                    dtoMovimento.TpAtendimento.Value = Atendimento.ObterTipoAtendimento(dtoAtendimento).TpAtendimento.Value;
                }

                dtoMovimento.IdtFilial.Value = (byte)MovimentacaoDTO.Empresa.HAC;
                dtoMovimento.DsProduto.Value = dtoMatMed.NomeFantasia.Value;
                dtoMovimento.FlFracionado.Value = dtoMatMed.FlFracionado.Value;
                dtoMovimento.UnidadeVenda.Value = dtoMatMed.UnidadeVenda.Value;
                dtoMovimento.DsUnidadeVenda.Value = dtoMatMed.DsUnidadeVenda.Value;

                if (dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.NAO)
                    dtoMovimento.Qtde.Value = qtde;
                else
                    dtoMovimento.Qtde.Value = qtde * dtoMatMed.UnidadeVenda.Value;

                dtoMovimento.FlEstornado.Value = (int)MovimentacaoDTO.Estornado.NAO;
                dtoMovimento.IdtTipo.Value = (byte)MovimentacaoDTO.TipoMovimento.SAIDA;
                dtoMovimento.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_CONS_DISP_AUTO_PACIENTE;

                dtoMovimento.TipoEmpresa.Value = dtoRequisicao.IdtFilial.Value == (byte)FilialMatMedDTO.Filial.ACS ? (byte)MovimentacaoDTO.Empresa.ACS : (byte)MovimentacaoDTO.Empresa.HAC;
                dtoMovimento.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                if (!dtoMatMed.IdtLote.Value.IsNull && (decimal)dtoMatMed.IdtLote.Value != 0) dtoMovimento.IdtLote.Value = dtoMatMed.IdtLote.Value;

                // ############## GERA O MOVIMENTO #############################################################
                dtoMovimento = Movimento.MovimentaEstoqueProduto(dtoMovimento, dtoMatMed, null);
                // #############################################################################################
            }
            else if (!gen.ItemBaixaAutomaticaDispensa(dtoMatMed) && gen.UtiCompartilhada((int)dtoRequisicao.IdtSetor.Value))
            {
                MessageBox.Show("Baixa Automática realizada apenas para produtos inteiros, sendo necessário baixar pela tela Consumo Paciente neste caso.", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private int DigitarQtde()
        {
            MovimentacaoDTO dtoMov = new MovimentacaoDTO();

            dtoMov.DsProduto.Value = dtoRequisicaoItem.DsProduto.Value;
            dtoMov.EstoqueLocal.Value = dtoRequisicaoItem.EstoqueLocalQtde.Value;

            dtoMov = FrmQtdMatMed.DigitaQtde(dtoMov);

            if (dtoMov == null) dtoMov = new MovimentacaoDTO();
            if (dtoMov.Qtde.Value.IsNull) dtoMov.Qtde.Value = 0;

            return (int)dtoMov.Qtde.Value;
        }

        private void CarregarRequisicao()
        {
            dtoRequisicao = new RequisicaoDTO();

            dtoRequisicao.Idt.Value = this.ObterReqIdCodBarra();
            dtoRequisicao = Requisicao.SelChave(dtoRequisicao);

            #region Verificações

            if (dtoRequisicao.Idt.Value.IsNull)
            {
                MessageBox.Show("Pedido não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdRequisicao.Text = string.Empty;
                txtIdRequisicao.Focus();
                return;
            }
            else if (dtoRequisicao.IdtSetor.Value == 2252)
            {
                MessageBox.Show("Não é permitido dispensar pedidos de ATENDIMENTO DOMICILIAR por esta tela", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdRequisicao.Text = string.Empty;
                txtIdRequisicao.Focus();
                return;
            }
            
            bool liberarMesmoDispensada = false; //C.C. e Admissão liberar para poder fazer devolução do paciente
            if ((dtoRequisicao.IdtSetor.Value == CENTRO_CIRURGICO || dtoRequisicao.IdtSetor.Value == 22) && dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO)
                liberarMesmoDispensada = true;
            
            if (dtoRequisicao.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX && !liberarMesmoDispensada)
            {
                MessageBox.Show("Este pedido já foi dispensado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdRequisicao.Text = string.Empty;
                txtIdRequisicao.Focus();
                return;
            }
            else if (dtoRequisicao.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.RECEBIDA_UNIDADE)
            {
                MessageBox.Show("Este pedido já foi recebido pela unidade", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdRequisicao.Text = string.Empty;
                txtIdRequisicao.Focus();
                return;

            }
            else if (dtoRequisicao.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.CANCELADA)
            {
                MessageBox.Show("Este pedido foi cancelado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdRequisicao.Text = string.Empty;
                txtIdRequisicao.Focus();
                return;
            }
            else if (dtoRequisicao.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.CANCELADA_POR_ALTA)
            {
                MessageBox.Show("Este pedido foi cancelado, pois o paciente já teve alta", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdRequisicao.Text = string.Empty;
                txtIdRequisicao.Focus();
                return;
            }
            else if (dtoRequisicao.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.TRANSFERIDO_PACIENTE)
            {
                MessageBox.Show("Este pedido foi cancelado e transferido para outro setor devido a mudança de localização do paciente", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdRequisicao.Text = string.Empty;
                txtIdRequisicao.Focus();
                return;
            }
            else if (dtoRequisicao.Status.Value != (byte)RequisicaoDTO.StatusRequisicao.IMPRESSO &&
                     dtoRequisicao.Status.Value != (byte)RequisicaoDTO.StatusRequisicao.DEVOLVIDO_ENFERMAGEM && !liberarMesmoDispensada)
            {
                MessageBox.Show("Este pedido não está liberado para a dispensação, pois ainda não foi impressa", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdRequisicao.Text = string.Empty;
                txtIdRequisicao.Focus();
                return;
            }
            else if (dtoRequisicao.SetorFarmacia.Value.IsNull && gen.LogadoSetorFarmacia())
            {                
                MessageBox.Show("Não permitido dispensar este pedido pela Farmácia", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdRequisicao.Text = string.Empty;
                txtIdRequisicao.Focus();
                return;                
            }
            else if (!dtoRequisicao.SetorFarmacia.Value.IsNull && !gen.LogadoSetorFarmacia() &&
                     dtoRequisicao.IdtSetor.Value != CENTRO_CIRURGICO) //Liberar quando C.C. que funciona como uma Farmácia
            {
                MessageBox.Show("Permitido dispensar este pedido apenas pela Farmácia", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdRequisicao.Text = string.Empty;
                txtIdRequisicao.Focus();
                return;
            }
            else if (!dtoRequisicao.SetorFarmacia.Value.IsNull && gen.LogadoSetorFarmacia())
            {
                if ((int)dtoRequisicao.SetorFarmacia.Value != (int)FrmPrincipal.dtoSeguranca.IdtSetor.Value)
                {
                    MessageBox.Show("Farmácia do Setor do Pedido diferente da Logada nesta máquina", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtIdRequisicao.Text = string.Empty;
                    txtIdRequisicao.Focus();
                    return;
                }
            }
            else if (!dtoRequisicao.SetorFarmacia.Value.IsNull && dtoRequisicao.SetorFarmacia.Value == CENTRO_CIRURGICO)
            {
                if (!_logadoCentroCirurgico)
                {
                    MessageBox.Show("Este Pedido só pode ser dispensado pelo Centro Cirúrgico", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtIdRequisicao.Text = string.Empty;
                    txtIdRequisicao.Focus();
                    return;
                }
            }
            else if (_logadoCentroCirurgico && dtoRequisicao.SetorFarmacia.Value.IsNull && dtoRequisicao.IdtSetor.Value == CENTRO_CIRURGICO)
            {
                MessageBox.Show("Este Pedido não pode ser dispensado pelo Centro Cirúrgico", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdRequisicao.Text = string.Empty;
                txtIdRequisicao.Focus();
                return;
            }
            else if (dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.MANUTENCAO && !gen.LogadoManutencao())
            {
                MessageBox.Show("Permitido dispensar este pedido apenas pela Manutenção", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdRequisicao.Text = string.Empty;
                txtIdRequisicao.Focus();
                return;
            }
            else if ((dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.IMPRESSOS_MAT_EXPEDIENTE ||
                      dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.HIGIENIZACAO ||
                      dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.OUTROS)
                     && !_logadoAlmoxCentral)
            {
                MessageBox.Show("Permitido dispensar este pedido apenas pelo Almoxarifado Central", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdRequisicao.Text = string.Empty;
                txtIdRequisicao.Focus();
                return;
            }

            #endregion Fim Verificações            
             
            btnKits.Visible = false;
            dtbItensKit = null;
            if (dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO)
            {
                if (dtoRequisicao.IdtSetor.Value != CENTRO_CIRURGICO && dtoRequisicao.IdtSetor.Value != 22) //C.C. e Admissão não verificar paciente
                {
                    dtoAtendimento = new PacienteDTO();
                    dtoAtendimento.Idt.Value = dtoRequisicao.IdtAtendimento.Value;
                    dtoAtendimento.TpAtendimento.Value = dtoRequisicao.TpAtendimento.Value;
                    dtoAtendimento.IdtUnidade.Value = dtoRequisicao.IdtUnidade.Value;
                    dtoAtendimento.IdtLocalAtendimento.Value = dtoRequisicao.IdtLocal.Value;
                    dtoAtendimento.IdtSetor.Value = dtoRequisicao.IdtSetor.Value;

                    dtoAtendimento = Atendimento.SelChave(dtoAtendimento);

                    dtoRequisicaoItem = new RequisicaoItensDTO();
                    dtoRequisicaoItem.Idt.Value = dtoRequisicao.Idt.Value;

                    //Verifica se o paciente ainda está internado para poder liberar o mat/med
                    if (dtoRequisicao.TpAtendimento.Value.ToString().Trim() == "I" &&
                        (dtoAtendimento == null || dtoAtendimento.Idt.Value.IsNull) &&
                        !gen.UtiCompartilhada((int)dtoRequisicao.IdtSetor.Value))
                    {
                        MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();
                        dtoCfg.IdtUnidade.Value = dtoRequisicao.IdtUnidade.Value;
                        dtoCfg.IdtLocal.Value = dtoRequisicao.IdtLocal.Value;
                        dtoCfg.Idtsetor.Value = dtoRequisicao.IdtSetor.Value;
                        dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);
                        if (dtoCfg.AtendeTodosSetores.Value == 0)
                        {
                            bool cancelarPorAlta = true;
                            if (RequisicaoItem.Sel(dtoRequisicaoItem).Select(string.Format("{0} > 0", RequisicaoItensDTO.FieldNames.QtdFornecida)).Length > 0)
                                cancelarPorAlta = false; //Não cancelar caso tenha algum antimicrobiano dispensado

                            if (cancelarPorAlta)
                            {
                                dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.CANCELADA_POR_ALTA;
                                Requisicao.Upd(dtoRequisicao);

                                MessageBox.Show("Este pedido personalizado foi cancelado, pois o paciente já teve alta", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtIdRequisicao.Text = string.Empty;
                                txtIdRequisicao.Focus();
                                return;
                            }
                        }
                    }
                    if (RequisicaoItem.ExisteKitAssociadoPedidoAla((int)dtoRequisicao.Idt.Value))
                    {
                        dtbItensKit = RequisicaoItem.SelOrdenadoKit(dtoRequisicaoItem);
                        if (dtbItensKit.Rows.Count > 0)
                            btnKits.Visible = true;
                    }
                }                
            }

            //if (!gen.UtiCompartilhada((int)dtoRequisicao.IdtSetor.Value))
            AdicionarMaterialDispensaAutomatica();

            dtbReqItem = RequisicaoItem.SelReqItensDispensacao(dtoRequisicao);
            dtbReqItem.AcceptChanges();
            dtgMatMed.DataSource = dtbReqItem;
                        
            this.PreencherTipoRequisicao();
            lblEstoqueUnificado.Text = string.Empty;
            if ((byte)RequisicaoDTO.TipoRequisicao.CARRINHO_EMERGENCIA != (byte)dtoRequisicao.IdtTipoRequisicao.Value)
            {
                MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();
                dtoCfg.IdtUnidade.Value = dtoRequisicao.IdtUnidade.Value;
                dtoCfg.IdtLocal.Value = dtoRequisicao.IdtLocal.Value;
                dtoCfg.Idtsetor.Value = dtoRequisicao.IdtSetor.Value;
                dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);
                if (dtoCfg.EstoqueUnificadoHAC.Value.IsNull) dtoCfg.EstoqueUnificadoHAC.Value = 0;
                if (dtoCfg.EstoqueUnificadoHAC.Value == 1)
                    lblEstoqueUnificado.Text = "ESTOQUE ÚNICO HAC";
            }
            if (dtoRequisicao.IdtFilial.Value == (byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA)
                txtFilial.Text = "HAC";
            else
                txtFilial.Text = dtoRequisicao.IdtFilial.Value == (byte)FilialMatMedDTO.Filial.ACS ? "ACS" : "HAC";

            if (!dtoRequisicao.DataRequisicao.Value.IsNull) txtData.Text = ((DateTime)dtoRequisicao.DataRequisicao.Value).ToString("dd/MM/yyyy à\\s HH:mm:ss");
            txtUnidade.Text = dtoRequisicao.DsUnidade.Value;
            txtLocal.Text = dtoRequisicao.DsLocal.Value;
            txtSetor.Text = dtoRequisicao.DsSetor.Value;

            tsHac.Controla(Evento.eEditar);
            btnPendentes.Visible = true;
            txtIdRequisicao.Text = dtoRequisicao.Idt.Value;
            txtIdRequisicao.Enabled = false;
            txtIdProduto.Enabled = true;
            #if DEBUG
                tsHac.Items["tsBtnMatMed"].Enabled = true;
            #endif
            txtIdProduto.Focus();
        }

        private void AdicionarMaterialDispensaAutomatica()
        {
            if (gen.TipoPedidoEntradaAuto(dtoRequisicao) || dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PADRAO)
            {
                this.Cursor = Cursors.WaitCursor;
                RequisicaoItensDTO dtoReqItem = new RequisicaoItensDTO();
                dtoReqItem.Idt = dtoRequisicao.Idt;
                dtbReqItem = RequisicaoItem.Sel(dtoReqItem);

                int qtdFornecer, qtdPadraoEntrar;
                foreach (DataRow row in dtbReqItem.Rows)
                {
                    if (int.Parse(row[MaterialMedicamentoDTO.FieldNames.IdtGrupo].ToString()) != 1) //So para materiais
                    {
                        qtdFornecer = int.Parse(row[RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString()) - int.Parse(row[RequisicaoItensDTO.FieldNames.QtdFornecida].ToString());
                        if (qtdFornecer > 0)
                        {
                            dtoMatMed = new MaterialMedicamentoDTO();
                            dtoMatMed.Idt.Value = decimal.Parse(row[RequisicaoItensDTO.FieldNames.IdtProduto].ToString());
                            dtoMatMed = MatMed.SelChave(dtoMatMed);

                            if (dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PADRAO)
                            {
                                qtdPadraoEntrar = ObterQtdPadraoDisponivelEntrada();

                                if (qtdFornecer > qtdPadraoEntrar)
                                    qtdFornecer = qtdPadraoEntrar;
                            }

                            if (qtdFornecer > 0)
                                this.AdicionarItemDispensa(qtdFornecer);
                        }
                    }
                }
                this.Cursor = Cursors.Default;
            }
        }

        private int ObterQtdPadraoDisponivelEntrada()
        {
            EstoqueLocalDTO dtoEstoque = new EstoqueLocalDTO();

            dtoEstoque.IdtUnidade.Value = dtoRequisicao.IdtUnidade.Value;
            dtoEstoque.IdtLocal.Value = dtoRequisicao.IdtLocal.Value;
            dtoEstoque.IdtSetor.Value = dtoRequisicao.IdtSetor.Value;
            dtoEstoque.IdtProduto.Value = dtoMatMed.Idt.Value;
            dtoEstoque.IdtFilial.Value = dtoRequisicao.IdtFilial.Value;

            dtoEstoque = Estoque.EstoqueLocalProduto(dtoEstoque);

            if (!dtoEstoque.QtdePadrao.Value.IsNull)
            {
                int retorno = (int)dtoEstoque.QtdePadrao.Value - (int)dtoEstoque.Qtde.Value;
                if (retorno > 0)
                    return retorno;
            }

            return 0;
        }

        /// <summary>
        /// Retira o último caractere que é apenas de controle na geração do cod. de barra
        /// </summary>
        /// <returns></returns>
        private long ObterReqIdCodBarra()
        {
            if (txtIdRequisicao.Text.Length <= 1) return 0;
            return long.Parse(txtIdRequisicao.Text.Substring(0, txtIdRequisicao.Text.Length - 1));
        }

        private void ZerarObjetos()
        {
            dtgMatMed.DataSource = null;
            dtbReqItem = null;
            dtbItensKit = null;
            dtoRequisicao = null;
            dtoRequisicaoItem = null;
            dtoMatMed = null;
            dtoAtendimento = null;
            txtIdProduto.Enabled = false;
            btnPendentes.Visible = pnlPendentes.Visible = btnKits.Visible = false;            
            dtoMovimento = null;
            lblEstoqueUnificado.Text = string.Empty;
        }

        private void PreencherTipoRequisicao()
        {
            txtTipo.Text = Generico.ObterTipoRequisicaoDescricao((byte)dtoRequisicao.IdtTipoRequisicao.Value);            
        }

        private void Imprimir()
        {
            this.Cursor = Cursors.WaitCursor;

            RequisicaoDTO dtoReqImp = new RequisicaoDTO();

            dtoReqImp.Idt.Value = txtReqNum.Text;

            try
            {
                Impressao.ImpressaoPedido imp = new HospitalAnaCosta.SGS.GestaoMateriais.Impressao.ImpressaoPedido();
                RequisicaoDataTable dtbReqImp = Requisicao.Sel(dtoReqImp, false);

                if (dtbReqImp.Rows.Count > 0)
                {
                    dtoReqImp = dtbReqImp.TypedRow(0);

                    if (dtoReqImp.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX ||
                        dtoReqImp.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.RECEBIDA_UNIDADE)
                    {
                        imp.Imprimir(dtoReqImp, true);

                        MessageBox.Show("Processo finalizado com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Pedido não pode ser impresso, pois ainda não foi dispensado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Pedido não encontrado para ser impresso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }

        private void CarregarItensPendentes(bool origemSalvar)
        {
            this.Cursor = Cursors.WaitCursor;
            _salvoSucesso = false;
            RequisicaoDTO dtoReqItemPend = new RequisicaoDTO();
            dtoReqItemPend.Idt.Value = dtoRequisicao.Idt.Value;
            // RequisicaoItensDataTable dtbReqItemPend = RequisicaoItem.Sel(dtoReqItemPend);
            RequisicaoItensDataTable dtbReqItemPend = RequisicaoItem.SelReqItensPendentes(dtoReqItemPend);
            // DataView dvReqItemPend = new DataView(dtbReqItemPend, string.Format("{0} <> {1}", RequisicaoItensDTO.FieldNames.QtdSolicitada, RequisicaoItensDTO.FieldNames.QtdFornecida), string.Empty, DataViewRowState.OriginalRows);
            if (dtbReqItemPend.Rows.Count > 0)
            {
                dtgItensPendentes.DataSource = dtbReqItemPend;
                pnlPendentes.Visible = true;
                if (!origemSalvar)
                {
                    btnFecharPendentes.Visible = true;
                    btnCancelar.Visible = false;
                    btnDispensar.Visible = false;
                }
                else
                {
                    btnFecharPendentes.Visible = false;
                    btnCancelar.Visible = true;
                    btnDispensar.Visible = true;
                    MessageBox.Show("Existem itens pendentes neste pedido, clique em DISPENSAR para confirmar esta dispensação", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (!origemSalvar)
                {
                    MessageBox.Show("Não existem itens pendentes neste pedido", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtIdProduto.Focus();
                }
                else
                {
                    if (MessageBox.Show("Deseja realmente dispensar os itens listados ?", "Gestão de Materiais e Medicamentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Dispensar();
                    }                    
                }
            }
            this.Cursor = Cursors.Default;
        }
        
        private bool Dispensar()
        {            
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _salvoSucesso = false;
                if (!ValidarDispensada()) return false;
                SegurancaDTO dtoUsuarioDispensacao = FrmLogin.Logar(true);
                if (dtoUsuarioDispensacao != null)
                {                        
                    dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX;
                    dtoRequisicao.IdtUsuario.Value = dtoUsuarioDispensacao.Idt.Value;
                    //if (!string.IsNullOrEmpty(lblEstoqueUnificado.Text))
                    //    dtoRequisicao.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
                    // dtoRequisicao = Requisicao.Gravar(dtoRequisicao, dtbReqItem);
                    Requisicao.DispensarRequisicao(dtoRequisicao);

                    txtIdProduto.Enabled = false;
                    pnlPendentes.Visible = false;
                    btnPendentes.Visible = false;                    
                    dtbReqItem.Rows.Clear();
                    tsHac.Items["tsBtnSalvar"].Enabled = false;
                    MessageBox.Show("Pedido dispensado com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _salvoSucesso = true;                    
                    txtReqNum.Text = txtIdRequisicao.Text;
                    btnImpReqNum.Focus();
                    return _salvoSucesso;
                }
                else
                {
                    txtIdProduto.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;                    
            }
            return false;
        }        

        #endregion

        #region EVENTOS

        private void FrmLiberacaoAlmox_Load(object sender, EventArgs e)
        {
            #if DEBUG
                tsHac.Items["tsBtnMatMed"].Visible = true;
            #endif
            this.ConfiguraItensDTG();
            this.ConfiguraItensPendentesDTG();
            if (this.LogadoAlmoxCentral()) 
                _logadoAlmoxCentral = true;
            else if ((int)FrmPrincipal.dtoSeguranca.IdtSetor.Value == CENTRO_CIRURGICO)
                _logadoCentroCirurgico= true;
        }

        private bool tsHac_MatMedClick(object sender)
        {
            if (dtoRequisicao == null)
            {
                MessageBox.Show(" Nenhuma requisição selecionada ");
                return false;
            }
            dtoMatMed = new MaterialMedicamentoDTO();            
            dtoMatMed.IdtFilial.Value = dtoRequisicao.IdtFilial.Value;
            dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMed);
            if (dtoMatMed != null)
            {
                if (!dtoMatMed.Idt.Value.IsNull)
                {                    
                    this.Cursor = Cursors.WaitCursor;
                    this.AdicionarItemDispensa(null);
                    this.Cursor = Cursors.Default;
                }
            }
            #if DEBUG
                tsHac.Items["tsBtnMatMed"].Enabled = true;
            #endif

            return true;
        }

        private bool tsHac_SalvarClick(object sender)
        {
            this.CarregarItensPendentes(true);
            if (_salvoSucesso)
            {
                _salvoSucesso = false;
                tsHac.Items["tsBtnSalvar"].Enabled = false;
                return true;
            }
            else
            {
                return false;
            }            
        }

        private bool tsHac_NovoClick(object sender)
        {
            tsHac.Controla(Evento.eNovo);
            this.ZerarObjetos();
            txtIdRequisicao.Focus();
#if DEBUG
            tsHac.Items["tsBtnMatMed"].Enabled = true;
#endif
            return false;
        }

        private bool tsHac_CancelarClick(object sender)
        {
            if (dtoRequisicao != null && !dtoRequisicao.Idt.Value.IsNull)
            {
                if (RequisicaoItem.ListarPendenciasDispensacao((int)dtoRequisicao.Idt.Value).Rows.Count > 0)
                {
                    if (MessageBox.Show("Deseja realmente Cancelar esta Dispensação que está em andamento? Ela ficará Pendente!!!",
                                        "Gestão de Materiais e Medicamentos",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return false;                    
                }
            }
            this.ZerarObjetos();
            return true;
        }

        private void tsPendencias_Click(object sender, EventArgs e)
        {
            if (frmPendencias == null || frmPendencias.IsDisposed)
            {
                frmPendencias = new FrmDispensacaoPendencias();
                frmPendencias.MdiParent = FrmPrincipal.ActiveForm;
            }

            this.Cursor = Cursors.WaitCursor;
            frmPendencias.Show();
            this.Cursor = Cursors.Default;

            frmPendencias.WindowState = FormWindowState.Normal;
            frmPendencias.Focus();
        }

        private void txtIdRequisicao_Validating(object sender, CancelEventArgs e)
        {
            if (txtIdRequisicao.Text != string.Empty)
            {
                this.Cursor = Cursors.WaitCursor;
                this.CarregarRequisicao();
                this.Cursor = Cursors.Default;
            } 
        }

        private void txtIdProduto_Validating(object sender, CancelEventArgs e)
        {
            if (dtbReqItem != null && txtIdProduto.Text != string.Empty)
            {
                // 
                CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();
                dtoCodigoBarra.CdBarra.Value = txtIdProduto.Text;
                dtoCodigoBarra.IdtFilial.Value = dtoRequisicao.IdtFilial.Value;
                // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
                dtoMatMed = MatMed.BuscaCodigoBarra(dtoCodigoBarra);

                if (dtoMatMed == null)
                {
                    MessageBox.Show("Material/medicamento não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtIdProduto.Text = string.Empty;
                    txtIdProduto.Focus();
                    // return;
                }
                else if (dtoMatMed.FlAtivo.Value == 0)
                {
                    MessageBox.Show("Produto Inativo", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtIdProduto.Text = string.Empty;
                    txtIdProduto.Focus();                    
                }
                else
                {                 
                    this.Cursor = Cursors.WaitCursor;
                    this.AdicionarItemDispensa(null);
                    this.Cursor = Cursors.Default;
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
            this.Imprimir();
            //if (MessageBox.Show(string.Format("Deseja imprimir o Pedido N° {0} ?", txtReqNum.Text), "Gestão de Materiais e Medicamentos",
            //                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    this.Imprimir();
            //}
        }

        private void dtgMatMed_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgMatMed.Columns[e.ColumnIndex].Name == "colDeletar")
            {
                this.Cursor = Cursors.WaitCursor;

                bool excluirMaterialCompleto = false;
                if (_logadoAlmoxCentral && dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PADRAO)
                {
                    MaterialMedicamentoDTO dtoProd = new MaterialMedicamentoDTO();
                    dtoProd.Idt.Value = Convert.ToInt64(dtgMatMed.Rows[e.RowIndex].Cells["colMatMedIdt"].Value.ToString());
                    if (MatMed.SelChave(dtoProd).Tabelamedica.Value != ((int)MaterialMedicamentoDTO.TipoMatMed.MEDICAMENTO).ToString())
                        excluirMaterialCompleto = true;
                }

                if (!excluirMaterialCompleto)
                {
                    dtoRequisicaoItem = new RequisicaoItensDTO();
                    dtoRequisicaoItem.Idt.Value = dtoRequisicao.Idt.Value;
                    dtoRequisicaoItem.IdtProduto.Value = Convert.ToInt64(dtgMatMed.Rows[e.RowIndex].Cells["colMatMedIdt"].Value.ToString());
                    dtoRequisicaoItem.IdtUsuarioDispensacao.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    FrmEstornoItemPedido.Carregar(dtoRequisicao, dtoRequisicaoItem, false, PedidoFarmaciaCentroCirurgico((int)dtoRequisicao.IdtSetor.Value));
                    dtbReqItem = RequisicaoItem.SelReqItensDispensacao(dtoRequisicao);
                    dtgMatMed.DataSource = dtbReqItem;
                }
                else
                {
                    if (MessageBox.Show("Deseja excluir este item da lista de dispensa ?", "Gestão de Materiais e Medicamentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dtoRequisicaoItem = new RequisicaoItensDTO();
                        dtoRequisicaoItem.Idt.Value = dtoRequisicao.Idt.Value;
                        dtoRequisicaoItem.IdtProduto.Value = Convert.ToInt64(dtgMatMed.Rows[e.RowIndex].Cells[colMatMedIdt.Name].Value.ToString());
                        dtoRequisicaoItem.QtdFornecida.Value = Convert.ToInt64(dtgMatMed.Rows[e.RowIndex].Cells[colQtdeFornecida.Name].Value.ToString());
                        dtoRequisicaoItem.IdtUsuarioDispensacao.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                        try
                        {
                            if (gen.TransferirItemParaAlmoxCentral(dtoRequisicao, dtoRequisicaoItem))
                            {
                                //RequisicaoItem.DelReqItemDispensacao(dtoRequisicaoItem);
                                dtbReqItem = null;
                                dtbReqItem = RequisicaoItem.SelReqItensDispensacao(dtoRequisicao);
                                dtgMatMed.DataSource = dtbReqItem;
                            }                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    } 
                }
               
                this.Cursor = Cursors.Default;
            }
            txtIdProduto.Focus();
        }

        private void btnPendentes_Click(object sender, EventArgs e)
        {                      
            this.CarregarItensPendentes(false);
        }

        private void btnOkPendentes_Click(object sender, EventArgs e)
        {
            pnlPendentes.Visible = false;
            txtIdProduto.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlPendentes.Visible = false;
            txtIdProduto.Focus();
        }

        private void btnDispensar_Click(object sender, EventArgs e)
        {
            if (this.Dispensar())
            {
                _salvoSucesso = false;
                tsHac.Controla(Evento.eSalvar);
                tsHac.Items["tsBtnSalvar"].Enabled = false;
            } 
        }

        private void btnKits_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            FrmKitItemPedido.Pesquisar(dtbItensKit);
            this.Cursor = Cursors.Default;
        }

        private void dtgItensPendentes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgItensPendentes.Columns[e.ColumnIndex].Name == "colQtdPendente")
            {
                e.Value = decimal.Parse(dtgItensPendentes.Rows[e.RowIndex].Cells["colQtdReqPend"].Value.ToString()) -
                          decimal.Parse(dtgItensPendentes.Rows[e.RowIndex].Cells["colQtdFornPend"].Value.ToString());
            }
        }

        private void FrmDispensacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dtoRequisicao != null && !dtoRequisicao.Idt.Value.IsNull)
            {
                if (RequisicaoItem.ListarPendenciasDispensacao((int)dtoRequisicao.Idt.Value).Rows.Count > 0)
                {
                    e.Cancel = MessageBox.Show("Deseja realmente fechar a tela com a Dispensação deste Pedido em andamento ?",
                                               "Gestão de Materiais e Medicamentos",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;                    
                }
            }
        }

        #endregion        
    }
}