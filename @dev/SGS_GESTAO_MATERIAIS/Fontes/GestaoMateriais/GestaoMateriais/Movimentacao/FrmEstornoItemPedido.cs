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
using Microsoft.ReportingServices.ReportRendering;
using HospitalAnaCosta.SGS.GestaoMateriais.Relatorio;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmEstornoItemPedido : FrmBase
    {
        #region OBJETOS SERVIÇOS

        private const int UTI_ALMOX_SATELITE = 2092;
        private const int FARMACIA_CENTRAL = 2592;
        private const int CENTRO_CIRURGICO = 61;
        
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }

        private PacienteDTO dtoAtendimento;
        private IPaciente _atendimento;
        private IPaciente Atendimento
        {
            get { return _atendimento != null ? _atendimento : _atendimento = (IPaciente)Global.Common.GetObject(typeof(IPaciente)); }
        }

        private RequisicaoDTO dtoRequisicao;
        private RequisicaoItensDTO dtoRequisicaoItem;
        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }

        // Kit
        private IKit _kit;
        private IKit Kit
        {
            get { return _kit != null ? _kit : _kit = (IKit)Global.Common.GetObject(typeof(IKit)); }
        }

        private DataTable _dtbMovimento;
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }

        private IMatMedSetorConfig _matMedConfig;
        private IMatMedSetorConfig MatMedSetorConfig
        {
            get { return _matMedConfig != null ? _matMedConfig : _matMedConfig = (IMatMedSetorConfig)Global.Common.GetObject(typeof(IMatMedSetorConfig)); }
        }

        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        private Generico gen = new Generico();
        private bool _usuarioPermissaoDevolverItemFaturado = false;
        private bool _origemRecebimento = false;
        private bool _pedidoFarmaciaCentroCirurgico = false;

        #endregion

        #region MÉTODOS

        public static void Carregar(RequisicaoDTO dtoReq, RequisicaoItensDTO dtoReqItem, bool origemRecebimento, bool pedidoFarmaciaCentroCirurgico)
        {
            FrmEstornoItemPedido frm = new FrmEstornoItemPedido();
            frm.dtoRequisicao = dtoReq;
            frm.dtoRequisicaoItem = dtoReqItem;
            frm.grbAtendimento.Visible = false;
            frm._origemRecebimento = origemRecebimento;
            frm._pedidoFarmaciaCentroCirurgico = pedidoFarmaciaCentroCirurgico;
            frm.ShowDialog();
        }

        public FrmEstornoItemPedido()
        {
            InitializeComponent();
        }

        private bool VerificaSetorPodeEstornar()
        {
            grbDevolver.Visible = false;

            if (cmbSetor.SelectedValue.ToString() == "2252") //ATENDIMENTO DOMICILIAR
            {
                MessageBox.Show("Este Setor não pode estornar por esta tela", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cmbSetor.SelectedIndex = -1;
                return false;
            }
            
            int idCentroDisp = 0;
            MovimentacaoDTO dtoMovimento = new MovimentacaoDTO();
            dtoMovimento.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            SetorDTO dtoSetFarm;
            dtoMovimento = Movimento.CentroDispensacao(dtoMovimento, out dtoSetFarm);
            if (!dtoMovimento.IdtSetorBaixa.Value.IsNull)
                idCentroDisp = (int)dtoMovimento.IdtSetorBaixa.Value;

            if (idCentroDisp == UTI_ALMOX_SATELITE)
            {
                grbDevolver.Visible = true;
                rbDevAlmoxUTI.Checked = true;
            }   

            return true;
        }

        private void ConfiguraDTG()
        {
            dtgBaixas.AutoGenerateColumns = false;

            dtgBaixas.Columns[colIdtMov.Name].DataPropertyName = MovimentacaoDTO.FieldNames.Idt;
            dtgBaixas.Columns[colIdUnidadeCentroDisp.Name].DataPropertyName = MovimentacaoDTO.FieldNames.IdtUnidade;
            dtgBaixas.Columns[colIdLocalCentroDisp.Name].DataPropertyName = MovimentacaoDTO.FieldNames.IdtLocal;
            dtgBaixas.Columns[colIdSetorCentroDisp.Name].DataPropertyName = MovimentacaoDTO.FieldNames.IdtSetor;
            dtgBaixas.Columns[colTipoPedido.Name].DataPropertyName = RequisicaoDTO.FieldNames.IdtTipoRequisicao;
            dtgBaixas.Columns[colIdtProduto.Name].DataPropertyName = MovimentacaoDTO.FieldNames.IdtProduto;
            dtgBaixas.Columns[colFracionado.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.FlFracionado;
            dtgBaixas.Columns[colReutiliza.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.FlReutilizavel;
            dtgBaixas.Columns[colIdLote.Name].DataPropertyName = MovimentacaoDTO.FieldNames.IdtLote;
            dtgBaixas.Columns[colPedido.Name].DataPropertyName = RequisicaoDTO.FieldNames.Idt;
            dtgBaixas.Columns[colDataMov.Name].DataPropertyName = MovimentacaoDTO.FieldNames.DataMovimento;
            dtgBaixas.Columns[colDataMov.Name].DefaultCellStyle.Format = "dd/MM/yy HH:mm:ss";
            dtgBaixas.Columns[colDsProduto.Name].DataPropertyName = MovimentacaoDTO.FieldNames.DsProduto;
            dtgBaixas.Columns[colLoteFab.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.NumLote;
            dtgBaixas.Columns[colQtde.Name].DataPropertyName = MovimentacaoDTO.FieldNames.Qtde;
            dtgBaixas.Columns[colAtendimento.Name].DataPropertyName = RequisicaoDTO.FieldNames.IdtAtendimento;
            dtgBaixas.Columns[colIdtMovRef.Name].DataPropertyName = "MTMD_MOV_ID_REF";
            dtgBaixas.Columns[colIdFilialReq.Name].DataPropertyName = "CAD_MTMD_FILIAL_ID_REQ";
            dtgBaixas.Columns[colIdUnidadeReq.Name].DataPropertyName = "CAD_UNI_ID_UNIDADE_REQ";
            dtgBaixas.Columns[colIdLocalReq.Name].DataPropertyName = "CAD_LAT_ID_LOCAL_REQ";
            dtgBaixas.Columns[colIdSetorReq.Name].DataPropertyName = "CAD_SET_ID_REQ";
            dtgBaixas.Columns[colEstoque.Name].DataPropertyName = "ESTOQUE_REQ";
            dtgBaixas.Columns[colUnidadePed.Name].DataPropertyName = "UNIDADE_REQ";
            dtgBaixas.Columns[colSetorPed.Name].DataPropertyName = "SETOR_REQ";
            dtgBaixas.Columns[colCentroDisp.Name].DataPropertyName = "CENTRO_DISP";            
        }

        private void ConfiguraTipoAtendimento()
        {
            MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();

            dtoCfg.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoCfg.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoCfg.Idtsetor.Value = cmbSetor.SelectedValue.ToString();

            dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);
            
            if (dtoCfg.AtendeTodosSetores.Value == 1)
            {
                if (int.Parse(cmbSetor.SelectedValue.ToString()) != CENTRO_CIRURGICO)
                {
                    grpTipoAtendimento.Enabled = true;
                    rbAmbulatorio.Enabled = true;
                    rbInternado.Enabled = true;
                }

                rbAmbulatorio.Checked = false;
                rbInternado.Checked = true;
            }
            else if (cmbLocal.Text == "AMBULATORIO")
            {
                rbAmbulatorio.Enabled = false;
                rbInternado.Enabled = false;

                grpTipoAtendimento.Enabled = false;
                rbAmbulatorio.Checked = true;
            }
            else
            {
                rbAmbulatorio.Enabled = false;
                rbInternado.Enabled = false;

                grpTipoAtendimento.Enabled = false;
                rbInternado.Checked = true;
            }
        }

        private void CarregaInfoPaciente()
        {            
            dtoAtendimento = new PacienteDTO();
            dtoAtendimento.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoAtendimento.IdtLocalAtendimento.Value = cmbLocal.SelectedValue.ToString();
            dtoAtendimento.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            if (rbInternado.Checked)
                dtoAtendimento.TpAtendimento.Value = "I";
            else
                dtoAtendimento.TpAtendimento.Value = "A";
            if (txtNroInternacao.Text != string.Empty)
                dtoAtendimento.Idt.Value = Convert.ToInt64(txtNroInternacao.Text);
            try
            {
                dtoAtendimento = gen.ObterPaciente(dtoAtendimento);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            if (!dtoAtendimento.NmPaciente.Value.IsNull)
            {
                txtNomePac.Text = dtoAtendimento.NmPaciente.Value;
                txtNroInternacao.Text = dtoAtendimento.Idt.Value.ToString();                

                CarregarGrid(false);

                txtCodProduto.Enabled = btnHistorico.Enabled = true;                
                if (txtCodProduto.Enabled) txtCodProduto.Focus();
            }
        }

        private void CarregarGrid(bool historicoGeral)
        {
            this.Cursor = Cursors.WaitCursor;
            MovimentacaoDTO dtoMov = new MovimentacaoDTO();
            int intSetor = 0;
            if (!grbAtendimento.Visible)
            {                
                dtoMov.IdtRequisicao.Value = dtoRequisicaoItem.Idt.Value;
                dtoMov.IdtProduto.Value = dtoRequisicaoItem.IdtProduto.Value;
                dtoMov.IdtAtendimento.Value = dtoRequisicao.IdtAtendimento.Value;
                intSetor = (int)dtoRequisicao.IdtSetor.Value;
            }
            else
            {
                dtoMov.IdtAtendimento.Value = txtNroInternacao.Text;
                dtoMov.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                intSetor = int.Parse(cmbSetor.SelectedValue.ToString());
                if (!historicoGeral)
                    dtoMov.DataMovimento.Value = Utilitario.ObterDataHoraServidor().AddHours(-48).ToString("dd/MM/yyyy HH:mm");
            }
            _dtbMovimento = Movimento.ObterSaidasCentroDispPedidoAnalitico(dtoMov, gen.UtiCompartilhada(intSetor), _pedidoFarmaciaCentroCirurgico);
            dtgBaixas.DataSource = _dtbMovimento;            
            txtCodProduto.Focus();
            this.Cursor = Cursors.Default;
        }

        private void ExcluirProduto(DataGridViewRow dtgRow, MovimentacaoDTO dtoMovFaturado)
        {
            MovimentacaoDTO dtoMov = new MovimentacaoDTO();            
            int atendimento = 0;
            dtoMov.Idt.Value = decimal.Parse(dtgRow.Cells[colIdtMov.Name].Value.ToString());
            dtoMov.FlEstornado.Value = 1;
            if (Movimento.Sel(dtoMov, false).Rows.Count > 0)
            {
                //MessageBox.Show("Item já estornado por outro processo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return;
            }
            if (dtoRequisicao == null || dtoRequisicao.IdtTipoRequisicao.Value.IsNull)
            {
                byte tipoPedido = byte.Parse(dtgRow.Cells[colTipoPedido.Name].Value.ToString());
                if (dtoRequisicao == null) dtoRequisicao = new RequisicaoDTO();
                dtoRequisicao.IdtTipoRequisicao.Value = tipoPedido;
            }
            if (gen.TipoPedidoEntradaAuto(dtoRequisicao))            
            {
                if (dtoRequisicao.IdtSetor.Value != CENTRO_CIRURGICO || _pedidoFarmaciaCentroCirurgico)
                {
                    MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();
                    dtoMatMed.Idt.Value = decimal.Parse(dtgRow.Cells[colIdtProduto.Name].Value.ToString());
                    dtoMatMed.FlReutilizavel.Value = 0;
                    if (!string.IsNullOrEmpty(dtgRow.Cells[colReutiliza.Name].Value.ToString())) dtoMatMed.FlReutilizavel.Value = byte.Parse(dtgRow.Cells[colReutiliza.Name].Value.ToString());
                    dtoMatMed.FlFracionado.Value = byte.Parse(dtgRow.Cells[colFracionado.Name].Value.ToString());

                    if (gen.ItemBaixaAutomaticaDispensa(dtoMatMed))
                    {
                        if (dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO)
                        {
                            atendimento = int.Parse(dtgRow.Cells[colAtendimento.Name].Value.ToString());
                            if (atendimento > 0)
                            {
                                if (dtoMovFaturado == null)
                                    dtoMov = this.ObterIdMovBaixaAutoDispPac(dtgRow);
                                else
                                    dtoMov = dtoMovFaturado;

                                if (dtoMov.Idt.Value > 0)
                                {
                                    try
                                    {
                                        if (dtoMovFaturado == null && Movimento.PermitirEstornoConsumoItem(ref dtoMov))
                                            Movimento.EstornarMovimentoConsumoPaciente(dtoMov);
                                        else if (dtoMovFaturado != null)
                                            Movimento.EstornarMovimentoConsumoPacienteFaturado(dtoMov);

                                        #region Verificar se Medicamento tem kit automático vinculado e estornar lançamento do faturamento se houver
                                        if (!gen.SetorPediatria(int.Parse(dtgRow.Cells[colIdSetorReq.Name].Value.ToString()))) //Não estornar faturamento para PEDIATRIA, pois os kits são diferentes
                                        {
                                            RequisicaoItensDTO dtoRI = new RequisicaoItensDTO();
                                            dtoRI.Idt.Value = decimal.Parse(dtgRow.Cells[colPedido.Name].Value.ToString());
                                            dtoRI.IdtProduto.Value = dtoMatMed.Idt.Value;
                                            RequisicaoItensDataTable dtbRI = RequisicaoItens.Sel(dtoRI);
                                            if (dtbRI.Rows.Count > 0)
                                            {
                                                dtoRI = dtbRI.TypedRow(0);
                                                if ((dtoRI.QtdSolicitada.Value == 1 || dtoRI.QtdFornecida.Value == 1) &&
                                                    int.Parse(dtbRI.Rows[0][MaterialMedicamentoDTO.FieldNames.IdtGrupo].ToString()) == 1)
                                                {
                                                    dtoMatMed.IdtPrincipioAtivo.Value = dtbRI.Rows[0][MaterialMedicamentoDTO.FieldNames.IdtPrincipioAtivo].ToString();
                                                    KitDataTable dtbMateriaisKit = Kit.ListarMateriaisAplicaMedicamento(dtoMatMed);
                                                    MovimentacaoDTO dtoMovFat = new MovimentacaoDTO();

                                                    dtoMovFat.IdtRequisicao.Value = dtoRI.Idt.Value;

                                                    foreach (DataRow row in dtbMateriaisKit.Rows)
                                                    {
                                                        dtoMovFat.IdtProduto.Value = int.Parse(row[MaterialMedicamentoDTO.FieldNames.Idt].ToString());
                                                        dtoMovFat.Qtde.Value = int.Parse(row[KitDTO.FieldNames.QtdeItem].ToString());

                                                        dtoMovFat.Idt.Value = Movimento.ObterIdMovimentoEnvioFaturamento(dtoMovFat);

                                                        if (dtoMovFat.Idt.Value > 0)
                                                        {
                                                            Movimento.EstornarMovimentoFaturamento(dtoMovFat);
                                                            Movimento.MarcarEstornoMovimento((decimal)dtoMovFat.Idt.Value);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        this.Cursor = Cursors.Default;
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            dtoMov = this.ObterIdMovBaixaAutoDispPac(dtgRow);
                            dtoMov.IdtTipo.Value = (byte)MovimentacaoDTO.TipoMovimento.ENTRADA;
                            dtoMov.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.ENTRADA_ESTORNO_LANCAMENTO;
                            dtoMov.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                            Movimento.EntradaProduto(dtoMov);
                        }
                    }
                }
                else
                {
                    if (dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO)
                        atendimento = int.Parse(dtgRow.Cells[colAtendimento.Name].Value.ToString());
                }
            }

            if (gen.UtiCompartilhada(int.Parse(dtgRow.Cells[colIdSetorReq.Name].Value.ToString())) || _pedidoFarmaciaCentroCirurgico)
                return; //Não realiza transferência quando UTI Compartilhada com Almox. UTI ou C.C.

            dtoMov = new MovimentacaoDTO();

            // unidade de baixa
            dtoMov.IdtUnidadeBaixa.Value = decimal.Parse(dtgRow.Cells[colIdUnidadeReq.Name].Value.ToString());
            dtoMov.IdtLocalBaixa.Value = decimal.Parse(dtgRow.Cells[colIdLocalReq.Name].Value.ToString());
            dtoMov.IdtSetorBaixa.Value = decimal.Parse(dtgRow.Cells[colIdSetorReq.Name].Value.ToString());

            // unidade de entrada
            if (!grbDevolver.Visible)
            {
                dtoMov.IdtUnidade.Value = decimal.Parse(dtgRow.Cells[colIdUnidadeCentroDisp.Name].Value.ToString());
                dtoMov.IdtLocal.Value = decimal.Parse(dtgRow.Cells[colIdLocalCentroDisp.Name].Value.ToString());
                dtoMov.IdtSetor.Value = decimal.Parse(dtgRow.Cells[colIdSetorCentroDisp.Name].Value.ToString());
            }
            else
            {
                dtoMov.IdtUnidade.Value = 244; //SANTOS
                dtoMov.IdtLocal.Value = 33; //ADM
                if (rbDevAlmoxUTI.Checked)
                {
                    dtoMov.IdtSetor.Value = UTI_ALMOX_SATELITE;
                }
                else
                {
                    dtoMov.IdtSetor.Value = FARMACIA_CENTRAL;
                }
            }

            dtoMov.IdtFilial.Value = decimal.Parse(dtgRow.Cells[colIdFilialReq.Name].Value.ToString()); //(decimal)FilialMatMedDTO.Filial.HAC;
            dtoMov.IdtRequisicao.Value = decimal.Parse(dtgRow.Cells[colPedido.Name].Value.ToString());
            if (atendimento > 0)
                dtoMov.IdtAtendimento.Value = atendimento;

            dtoMov.IdtProduto.Value = decimal.Parse(dtgRow.Cells[colIdtProduto.Name].Value.ToString());
            if (!string.IsNullOrEmpty(dtgRow.Cells[colIdLote.Name].Value.ToString())) 
                dtoMov.IdtLote.Value = decimal.Parse(dtgRow.Cells[colIdLote.Name].Value.ToString());
            dtoMov.Qtde.Value = decimal.Parse(dtgRow.Cells[colQtde.Name].Value.ToString());

            dtoMov.IdtTipo.Value = (byte)MovimentacaoDTO.TipoMovimento.ENTRADA;
            dtoMov.IdtTipoBaixa.Value = (byte)MovimentacaoDTO.TipoMovimento.SAIDA;
            dtoMov.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.TRANSFERENCIA_ENTRADA;
            dtoMov.IdtSubTipoBaixa.Value = (byte)MovimentacaoDTO.SubTipoMovimento.TRANSFERENCIA_SAIDA;
            dtoMov.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

            try
            {
                Movimento.TransfereEstoqueProduto(dtoMov);
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                return;
            }

            Movimento.MarcarEstornoMovimento(int.Parse(dtgRow.Cells[colIdtMov.Name].Value.ToString()));
        }

        private MovimentacaoDTO ObterIdMovBaixaAutoDispPac(DataGridViewRow dtgRow)
        {
            MovimentacaoDTO dtoMov = new MovimentacaoDTO();
            dtoMov.IdtUnidade.Value = decimal.Parse(dtgRow.Cells[colIdUnidadeReq.Name].Value.ToString());
            dtoMov.IdtLocal.Value = decimal.Parse(dtgRow.Cells[colIdLocalReq.Name].Value.ToString());
            dtoMov.IdtSetor.Value = decimal.Parse(dtgRow.Cells[colIdSetorReq.Name].Value.ToString());
            dtoMov.IdtFilial.Value = decimal.Parse(dtgRow.Cells[colIdFilialReq.Name].Value.ToString());
            dtoMov.IdtProduto.Value = decimal.Parse(dtgRow.Cells[colIdtProduto.Name].Value.ToString());
            if (!string.IsNullOrEmpty(dtgRow.Cells[colIdLote.Name].Value.ToString()))
                dtoMov.IdtLote.Value = decimal.Parse(dtgRow.Cells[colIdLote.Name].Value.ToString());
            dtoMov.Qtde.Value = decimal.Parse(dtgRow.Cells[colQtde.Name].Value.ToString());
            dtoMov.IdtUsuarioEstorno.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

            dtoMov.IdtRequisicao.Value = decimal.Parse(dtgRow.Cells[colPedido.Name].Value.ToString());
            if (!gen.UtiCompartilhada(int.Parse(dtgRow.Cells[colIdSetorReq.Name].Value.ToString())))
                dtoMov.Idt.Value = Movimento.ObterIdMovimentoBaixaAutoDispensaPaciente(dtoMov);
            else
                dtoMov.Idt.Value = decimal.Parse(dtgRow.Cells[colIdtMov.Name].Value.ToString());

            return dtoMov;
        }

        private void MarcarExclusao()
        {
            CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();

            dtoCodigoBarra.CdBarra.Value = txtCodProduto.Text;
            dtoCodigoBarra.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC;

            // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
            MaterialMedicamentoDTO dtoMatMedExcluir = MatMed.BuscaCodigoBarra(dtoCodigoBarra);

            if (dtoMatMedExcluir == null)
            {
                MessageBox.Show(" Material/medicamento não identificado ", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodProduto.Text = string.Empty;
                txtCodProduto.Focus();
                return;
            }
            //if (dtoMatMedExcluir.FlFracionado.Value == 1)
            //{
            //    MessageBox.Show("Não é permitido realizar devolução de item fracionado por esta funcionalidade.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    txtCodProduto.Text = string.Empty;
            //    txtCodProduto.Focus();
            //    return;
            //}

            DataRow[] rowsProduto;
            if (dtoMatMedExcluir.IdtGrupo.Value == 1) //Para medicamento buscar lote
            {
                rowsProduto = _dtbMovimento.Select(string.Format("{0} = {1} AND {2} = {3}", MovimentacaoDTO.FieldNames.IdtProduto, 
                                                                                            dtoMatMedExcluir.Idt.Value,
                                                                                            MovimentacaoDTO.FieldNames.IdtLote,
                                                                                            dtoMatMedExcluir.IdtLote.Value));
            }
            else
                rowsProduto = _dtbMovimento.Select(string.Format("{0} = {1}", MovimentacaoDTO.FieldNames.IdtProduto, dtoMatMedExcluir.Idt.Value));

            if (rowsProduto.Length > 0)
            {
                this.Cursor = Cursors.WaitCursor;

                bool selecionar = false;
                foreach (DataGridViewRow dtgRow in dtgBaixas.Rows)
                {
                    if (dtgRow.Cells[colIdtProduto.Name].Value.ToString() == dtoMatMedExcluir.Idt.Value && !bool.Parse(dtgRow.Cells[colExcluir.Name].EditedFormattedValue.ToString()))
                    {                        
                        if (dtoMatMedExcluir.IdtGrupo.Value == 1 && !dtoMatMedExcluir.IdtLote.Value.IsNull) //Para medicamento buscar lote
                        {
                            if (dtgRow.Cells[colIdLote.Name].Value.ToString() == dtoMatMedExcluir.IdtLote.Value)
                                selecionar = true;
                        }
                        else
                        {
                            selecionar = true;
                        }
                        if (selecionar)
                        {
                            dtgBaixas.CurrentCell = dtgRow.Cells[colExcluir.Name];
                            dtgRow.Cells[colExcluir.Name].Value = 1;
                            //MessageBox.Show("ITEM SELECIONADO COM SUCESSO!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
                if (!selecionar)
                    MessageBox.Show("Item já selecionado!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Baixa do respectivo item não listada abaixo!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            txtCodProduto.Text = string.Empty;
            txtCodProduto.Focus();
        }

        private void LimparPaciente()
        {
            dtoAtendimento = null;
            _dtbMovimento = null;
            dtgBaixas.DataSource = null;
            txtNomePac.Text = txtNroInternacao.Text = string.Empty;
        }

        private bool ValidarPeriodo()
        {
            if (txtDtIni.Text == string.Empty)
            {
                MessageBox.Show("Digite a Data Início", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDtIni.Focus();
                return false;
            }
            if (txtDtFim.Text == string.Empty)
            {
                MessageBox.Show("Digite a Data Fim", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDtFim.Focus();
                return false;
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
            if (Convert.ToDateTime(txtDtFim.Text).Date > Convert.ToDateTime(txtDtIni.Text).Date.AddMonths(6).Date)
            {
                MessageBox.Show("Período não pode ser superior a 6 meses.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDtFim.Focus();
                return false;
            }
            if (Convert.ToDateTime(txtDtIni.Text).Date < Convert.ToDateTime("01/01/2019").Date)
            {
                MessageBox.Show("Período tem que ser a partir do ano de 2019.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDtIni.Focus();
                return false;
            }
            return true;
        }

        #endregion

        private void FrmEstornoItemPedido_Load(object sender, EventArgs e)
        {
            ConfiguraDTG();
            if (grbAtendimento.Visible)
            {
                if (gen.VerificaAcessoFuncionalidade("PesquisaIndiceDevolucao")) tsIndiceDev.Visible = true;
                //Já trazer fixo Unidade = Santos e Local = Internado
                cmbUnidade.Carregaunidade();
                cmbUnidade.SelectedValue = 244; //SANTOS
                cmbLocal.SelectedValue = 29; //INTERNADO
                lblLegendaFrac.Visible = true;
                _usuarioPermissaoDevolverItemFaturado = gen.VerificaAcessoFuncionalidade("DevolverItemFaturado");
            }
            else
            {
                tsHac.Items["tsBtnLimpar"].Visible = lblCodBarra.Visible = txtCodProduto.Visible = false;
                Point point = new Point();
                point.X = tabConsumo.Location.X;
                point.Y = tabConsumo.Location.Y - 75;
                tabConsumo.Location = point;
                tabConsumo.Height = tabConsumo.Height + 75;
                CarregarGrid(false);
            }
            
            if (grbAtendimento.Visible || _origemRecebimento)
                lblCodBarra.Visible = txtCodProduto.Visible = true;

            if (_origemRecebimento)
            {
                Point point = new Point();
                point.X = lblCodBarra.Location.X;
                point.Y = lblCodBarra.Location.Y - 78;
                lblCodBarra.Location = point;

                point = new Point();
                point.X = txtCodProduto.Location.X;
                point.Y = txtCodProduto.Location.Y - 78;
                txtCodProduto.Location = point;

                txtCodProduto.Enabled = true;
                txtCodProduto.Focus();
            }
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (VerificaSetorPodeEstornar()) ConfiguraTipoAtendimento();
            LimparPaciente();
            txtNroInternacao.Focus();
        }        

        private bool tsHac_LimparClick(object sender)
        {
            return true;
        }

        private void tsHac_AfterLimpar(object sender)
        {
            txtCodProduto.Enabled = btnHistorico.Enabled = false;
            LimparPaciente();
            pnlIndiceDev.Visible = false;
            grbDevolver.Visible = false;
        }        

        private void tsEstornar_Click(object sender, EventArgs e)
        {
            if (dtgBaixas.Rows.Count > 0)
            {
                if (MessageBox.Show("Deseja realmente estornar os itens selecionados ?",
                                    "Gestão de Materiais e Medicamentos",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    bool itemExcluido = false;
                    foreach (DataGridViewRow dtgRow in dtgBaixas.Rows)
                    {
                        if (bool.Parse(dtgRow.Cells[colExcluir.Name].EditedFormattedValue.ToString()))
                        {
                            this.ExcluirProduto(dtgRow, null);
                            itemExcluido = true;
                        }
                    }
                    this.Cursor = Cursors.Default;
                    if (!grbAtendimento.Visible) this.Close();
                    CarregarGrid(false);
                    if (itemExcluido)
                        MessageBox.Show("Item(s) não faturado(s) estornado(s) com sucesso.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Nenhum item foi estornado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Não existem itens a serem estornados.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void tsIndiceDev_Click(object sender, EventArgs e)
        {
            tsHac.Controla(Evento.eLimpar);
            txtCodProduto.Enabled = btnHistorico.Enabled = false;
            LimparPaciente();            

            txtDtIni.Text = Utilitario.ObterDataHoraServidor().AddMonths(-1).ToString("dd/MM/yyyy");
            txtDtFim.Text = Utilitario.ObterDataHoraServidor().ToString("dd/MM/yyyy");
            txtQtdForn.Text = txtQtdDev.Text = txtIndiceDev.Text = string.Empty;
            
            pnlIndiceDev.BorderStyle = BorderStyle.FixedSingle;
            pnlIndiceDev.Visible = chkSetor.Enabled = true;
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            pnlIndiceDev.Visible = false;
            if (dtoAtendimento != null && !dtoAtendimento.NmPaciente.Value.IsNull) CarregarGrid(true);
        } 

        private void btnPesquisaPac_Click(object sender, EventArgs e)
        {
            if (txtNroInternacao.Enabled)
            {
                txtCodProduto.Enabled = btnHistorico.Enabled = false;
                if (cmbSetor.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione o Setor", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimparPaciente();
                    return;
                }
                CarregaInfoPaciente();
            }
            if (txtNroInternacao.Text.Length == 0) LimparPaciente();
        }

        private void txtNroInternacao_Validated(object sender, EventArgs e)
        {
            if (txtNroInternacao.Text.Length != 0)
                btnPesquisaPac_Click(sender, e);
            else
                LimparPaciente();
        }

        private void txtCodProduto_Validating(object sender, CancelEventArgs e)
        {
            if (txtCodProduto.Text != string.Empty)
                MarcarExclusao();
        }

        private void dtgBaixas_DoubleClick(object sender, EventArgs e) { }

        private void dtgBaixas_CellDoubleClick(object sender, DataGridViewCellEventArgs e) { }

        private void dtgBaixas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grbAtendimento.Visible && e.RowIndex >= 0 && dtgBaixas.Rows.Count > 0)
            {
                if (dtgBaixas.Columns[e.ColumnIndex].Name == colExcluir.Name)
                {
                    //if (dtgBaixas.Rows[e.RowIndex].Cells[colFracionado.Name].Value.ToString() == "1")
                    //{
                    //    dtgBaixas.Rows[e.RowIndex].Cells[colExcluir.Name].Value = 0;                        
                    //    MessageBox.Show("Não é permitido realizar devolução de item fracionado por esta funcionalidade.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);                        
                    //}
                    if (_usuarioPermissaoDevolverItemFaturado && !bool.Parse(dtgBaixas.Rows[e.RowIndex].Cells[colExcluir.Name].EditedFormattedValue.ToString()))
                    {
                        this.Cursor = Cursors.WaitCursor;
                        MovimentacaoDTO dtoMovFat = this.ObterIdMovBaixaAutoDispPac(dtgBaixas.Rows[e.RowIndex]);
                        if (!Movimento.PermitirEstornoConsumoItem(ref dtoMovFat))
                        {
                            if (MessageBox.Show("Este item JÁ foi FATURADO, deseja realmente realizar este estorno para o estoque sem modificar a conta do paciente ?",
                                                "Gestão de Materiais e Medicamentos",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {                                
                                this.ExcluirProduto(dtgBaixas.Rows[e.RowIndex], dtoMovFat);
                                this.CarregarGrid(false);
                                MessageBox.Show("Item faturado estornado com sucesso.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void dtgBaixas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (grbAtendimento.Visible && e.RowIndex >= 0 && dtgBaixas.Rows.Count > 0)
            //{
            //    if (dtgBaixas.Rows[e.RowIndex].Cells[colFracionado.Name].Value.ToString() == "1")
            //    {
            //        e.CellStyle.ForeColor = Color.Gray;
            //        dtgBaixas.Rows[e.RowIndex].Cells[colExcluir.Name].ReadOnly = true;
            //    }
            //}
        }

        private void btnCancelarPlanilha_Click(object sender, EventArgs e)
        {
            pnlIndiceDev.Visible = false;
            txtDtIni.Text = txtDtFim.Text = string.Empty;
        }

        private void btnGerarIndice_Click(object sender, EventArgs e)
        {
            if (!ValidarPeriodo()) return;

            this.Cursor = Cursors.WaitCursor;

            btnExcel.Visible = false;
            txtQtdDev.Text = txtIndiceDev.Text = string.Empty;

            RequisicaoDTO dto = new RequisicaoDTO();
            dto.DataRequisicao.Value = txtDtIni.Text;
            dto.DataRequisicao2.Value = txtDtFim.Text;

            if (chkSetor.Checked && sender != null)
            {
                string nomeRelatorio = "GM_40_INDICE_DEVOLUCAO";
                Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[3];

                #region Monta Parâmetros

                int x = 0;                

                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("USUARIO", FrmPrincipal.dtoSeguranca.Login.Value);
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("DATA_DE", txtDtIni.Text);
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("DATA_ATE", DateTime.Parse(txtDtFim.Text).ToString("dd/MM/yyyy 23:59:59"));

                #endregion

                Microsoft.Reporting.WinForms.ReportParameter[] reportParamTemp = new Microsoft.Reporting.WinForms.ReportParameter[x];

                for (int i = 0; i < reportParam.Length; i++)
                {
                    if (reportParam[i] == null) break;
                    reportParamTemp[i] = reportParam[i];
                }
                reportParam = reportParamTemp;
                reportParamTemp = null;

                FrmReportViewer frmRelatorio = new FrmReportViewer();
                frmRelatorio.AbreRelatorio(nomeRelatorio, reportParam);
            }

            DataTable dtb = RequisicaoItens.ObterIndiceDevolucaoPeriodo(dto);

            txtQtdForn.Text = int.Parse(dtb.Rows[0]["QTD_TOTAL_FORNECIDA"].ToString()).ToString("N0");            

            if (decimal.Parse(txtQtdForn.Text) > 0)
            {
                btnExcel.Visible = true;

                if (!string.IsNullOrEmpty(dtb.Rows[0]["QTD_DEVOLVIDA"].ToString()))
                    txtQtdDev.Text = int.Parse(dtb.Rows[0]["QTD_DEVOLVIDA"].ToString()).ToString("N0");

                if (!string.IsNullOrEmpty(dtb.Rows[0]["INDICE_DEVOLUCAO"].ToString()))
                    txtIndiceDev.Text = decimal.Parse(dtb.Rows[0]["INDICE_DEVOLUCAO"].ToString()).ToString("N2");
                
            }            

            this.Cursor = Cursors.Default;
        }        

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (!ValidarPeriodo()) return;

            btnGerarIndice_Click(null, null);

            this.Cursor = Cursors.WaitCursor;

            RequisicaoDTO dto = new RequisicaoDTO();
            dto.DataRequisicao.Value = txtDtIni.Text;
            dto.DataRequisicao2.Value = txtDtFim.Text;            

            DataTable dtb = RequisicaoItens.ListarDevolucoesPeriodo(dto);

            if (dtb.Rows.Count > 0)
            {
                Generico.ExportarExcel(dtb.DefaultView.ToTable(false, "SETOR",
                                                                      "GRUPO_ID",
                                                                      "PRODUTO_ID",
                                                                      "PRODUTO",
                                                                      "PEDIDO",
                                                                      "QTD_SOLICITADA",
                                                                      "QTD_FORNECIDA",
                                                                      "QTD_DEVOLVIDA",
                                                                      "DATA_PEDIDO",
                                                                      "DATA_DISPENSACAO",
                                                                      "DATA_DEVOLUCAO",
                                                                      "QTD_HORAS_DEV"));
            }
            else
                MessageBox.Show("Nenhum registro encontrado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            this.Cursor = Cursors.Default;
        }        
    }
}