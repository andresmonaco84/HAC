using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmRecebUnidade : FrmBase
    {
        public FrmRecebUnidade()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇO

        // Requisição
        private RequisicaoDTO dtoRequisicao;
        private IRequisicao _requisicao;
        private IRequisicao Requisicao
        {
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject( typeof(IRequisicao)); }
        }

        // Itens Requisição
        private RequisicaoItensDTO dtoReqItem;
        private RequisicaoItensDataTable dtbReqItem;        
        private IRequisicaoItens _ReqItem;
        private IRequisicaoItens ReqItem
        {
            get { return _ReqItem != null ? _ReqItem : _ReqItem = (IRequisicaoItens)Global.Common.GetObject( typeof(IRequisicaoItens)); }
        }

        // MatMed
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject( typeof(IMaterialMedicamento)); }
        }        

        // Utilitario
        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        private IMatMedSetorConfig _matMedConfig;
        private IMatMedSetorConfig MatMedSetorConfig
        {
            get { return _matMedConfig != null ? _matMedConfig : _matMedConfig = (IMatMedSetorConfig)Global.Common.GetObject(typeof(IMatMedSetorConfig)); }
        }

        private IPaciente _atendimento;
        private IPaciente Atendimento
        {
            get { return _atendimento != null ? _atendimento : _atendimento = (IPaciente)Global.Common.GetObject(typeof(IPaciente)); }
        }

        private bool _permitePedidoOutroSetor = false;

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
            dtgMatMed.Columns["colQtdeFornecida"].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdFornecida;
            dtgMatMed.Columns["colQtdePadrao"].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdePadrao;
            dtgMatMed.Columns["colEstoqueLocal"].DataPropertyName = RequisicaoItensDTO.FieldNames.EstoqueLocalQtde;
            dtgMatMed.Columns["colQtdCentDisp"].DataPropertyName = RequisicaoItensDTO.FieldNames.EstoqueCentDispQtde;
            dtgMatMed.Columns["colPriAtivo"].DataPropertyName = RequisicaoItensDTO.FieldNames.IdtPrincipioAtivo;
        }

        private void CarregaItens()
        {
            dtoReqItem = new RequisicaoItensDTO();
            dtoReqItem.Idt = dtoRequisicao.Idt;
            if (dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO &&
                dtoRequisicao.Status.Value != (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX &&
                dtoRequisicao.Status.Value != (byte)RequisicaoDTO.StatusRequisicao.RECEBIDA_UNIDADE)
                dtbReqItem = new Generico().PedidoOrdenadoKit(dtoReqItem);
            else
                dtbReqItem = ReqItem.Sel(dtoReqItem);
            //Se req. dispensada ou recebida pela unidade, trazer só onde qtd. fornecida > 0
            if (dtoRequisicao.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX ||
                dtoRequisicao.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.RECEBIDA_UNIDADE)
            {
                DataView dvReqItem = new DataView(dtbReqItem, string.Format("{0} > 0", RequisicaoItensDTO.FieldNames.QtdFornecida), string.Empty, DataViewRowState.OriginalRows);
                dtgMatMed.DataSource = dvReqItem;
            }
            else
            {
                dtgMatMed.DataSource = dtbReqItem;
            }              
        }

        private void CarregarRequisicao()
        {
            btnDevolver.Visible = btnReceber.Visible = dtgMatMed.Columns[colDevolver.Name].Visible = false;
            if (txtIdRequisicao.Enabled)
            {
                dtoRequisicao = new RequisicaoDTO();

                dtoRequisicao.Idt.Value = this.ObterReqIdCodBarra();
                dtoRequisicao = Requisicao.SelChave(dtoRequisicao);                

                if (dtoRequisicao.Idt.Value.IsNull)
                {
                    MessageBox.Show("Pedido não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtIdRequisicao.Text = string.Empty;
                    txtIdRequisicao.Focus();
                    return;
                }

                if (!_permitePedidoOutroSetor &&
                    FrmPrincipal.dtoSeguranca.IdtSetor.Value.ToString() != dtoRequisicao.IdtSetor.Value.ToString())
                {
                    MessageBox.Show("Pedido não referente ao setor logado no sistema", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtIdRequisicao.Text = string.Empty;
                    txtIdRequisicao.Focus();
                    return;
                }

                if (!dtoRequisicao.IdtAtendimento.Value.IsNull && dtoRequisicao.IdtFilial.Value != (byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA &&
                    dtoRequisicao.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX &&
                    dtoRequisicao.IdtSetor.Value != 61) //Não liberar a princípio devolução do C.Cir. por esta func. 
                {
                    MatMedSetorConfigDTO dtoSetorCfg = new MatMedSetorConfigDTO();
                    dtoSetorCfg.Idtsetor.Value = dtoRequisicao.IdtSetor.Value.ToString();
                    if (Atendimento.ControlaConsumoPacienteSetor((decimal)dtoRequisicao.IdtAtendimento.Value, dtoSetorCfg))
                        btnReceber.Visible = true; //btnDevolver.Visible = 
                }

                if ((int)FrmPrincipal.dtoSeguranca.IdtLocal.Value != 29) //Não liberar devolução se estiver logado em local de Internado (ENFERMAGEM)
                {
                    if ((dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.ESTOQUE_LOCAL_MAT_MED ||
                         dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.MANUTENCAO) &&
                        (dtoRequisicao.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX ||
                         dtoRequisicao.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.RECEBIDA_UNIDADE))
                        dtgMatMed.Columns[colDevolver.Name].Visible = true;
                }
            }

            txtStatus.Text = Requisicao.RetornarStatus(dtoRequisicao);
            this.PreencherTipoRequisicao();
            //if ((byte)RequisicaoDTO.TipoRequisicao.CARRINHO_EMERGENCIA == (byte)dtoRequisicao.IdtTipoRequisicao.Value)
            if (dtoRequisicao.IdtFilial.Value == (byte)FilialMatMedDTO.Filial.HAC)
            {
                MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();
                dtoCfg.IdtUnidade.Value = dtoRequisicao.IdtUnidade.Value;
                dtoCfg.IdtLocal.Value = dtoRequisicao.IdtLocal.Value;
                dtoCfg.Idtsetor.Value = dtoRequisicao.IdtSetor.Value;
                dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);
                if (dtoCfg.EstoqueUnificadoHAC.Value.IsNull) dtoCfg.EstoqueUnificadoHAC.Value = 0;
                if (dtoCfg.EstoqueUnificadoHAC.Value == 1)
                    lblEstoqueUnificado.Text = "ESTOQUE ÚNICO HAC";
                else
                    lblEstoqueUnificado.Text = string.Empty;
            }
            if (dtoRequisicao.IdtFilial.Value == (byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA)
            {
                txtFilial.Text = "HAC";
            }
            else
            {
                txtFilial.Text = dtoRequisicao.IdtFilial.Value == (byte)FilialMatMedDTO.Filial.ACS ? "ACS" : "HAC";
            }            
            if (!dtoRequisicao.DataRequisicao.Value.IsNull) txtData.Text = ((DateTime)dtoRequisicao.DataRequisicao.Value).ToString("dd/MM/yyyy à\\s HH:mm:ss");
            txtUnidade.Text = dtoRequisicao.DsUnidade.Value;
            txtLocal.Text = dtoRequisicao.DsLocal.Value;
            txtSetor.Text = dtoRequisicao.DsSetor.Value;            
            txtIdRequisicao.Text = dtoRequisicao.Idt.Value;
            lblUsuarioReq.Text = dtoRequisicao.DsUsuarioRequisicao.Value;
            dtgMatMed.Columns["colDiverg"].Visible = false;
            if (dtoRequisicao.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX ||
                dtoRequisicao.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.RECEBIDA_UNIDADE)
            {
                lblUsuarioDisp.Text = dtoRequisicao.DsUsuarioDispensacao.Value;
                lblDataDisp.Visible = true;
                txtDataDisp.Visible = true;
                if (!dtoRequisicao.DataDispensacao.Value.IsNull)
                {
                    txtDataDisp.Text = ((DateTime)dtoRequisicao.DataDispensacao.Value).ToString("dd/MM/yyyy à\\s HH:mm:ss");
                    //Só pode registrar divergência se a dispensação tiver a data atual ou de 1 dia atrás
                    if (DateTime.Parse(((DateTime)dtoRequisicao.DataDispensacao.Value).ToString("dd/MM/yyyy")) <= DateTime.Parse(Utilitario.ObterDataHoraServidor().ToString("dd/MM/yyyy")) &&
                        DateTime.Parse(((DateTime)dtoRequisicao.DataDispensacao.Value).ToString("dd/MM/yyyy")) >= DateTime.Parse(Utilitario.ObterDataHoraServidor().AddDays(-1).ToString("dd/MM/yyyy")))
                    {
                        dtgMatMed.Columns["colDiverg"].Visible = true;
                    }
                }
            }
            else
            {
                lblUsuarioDisp.Text = "--";
                lblDataDisp.Visible = false;
                txtDataDisp.Visible = false;
            }
            //if (dtoRequisicao.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX)
            //{
            //    tsHac.Controla(Evento.eEditar);
            //}
            txtIdRequisicao.Enabled = false;
            pnlUsuario.Visible = true;
            this.CarregaItens();
        }

        /// <summary>
        /// Retira o último caractere que é apenas de controle na geração do cod. de barra
        /// </summary>
        /// <returns></returns>
        private long ObterReqIdCodBarra()
        {
            return long.Parse(txtIdRequisicao.Text.Substring(0, txtIdRequisicao.Text.Length - 1));
        }

        private void ZerarObjetos()
        {
            dtoRequisicao = null;            
            dtbReqItem = null;
            pnlUsuario.Visible = false;
            lblDataDisp.Visible = false;
            txtDataDisp.Visible = false;
            btnDevolver.Visible = btnReceber.Visible = false;
            lblEstoqueUnificado.Text = string.Empty;
        }

        private void PreencherTipoRequisicao()
        {
            txtTipo.Text = Generico.ObterTipoRequisicaoDescricao((byte)dtoRequisicao.IdtTipoRequisicao.Value);            
        }

        private void AtualizarStatusPedido()
        {
            dtoRequisicao.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
            //Requisicao.Gravar(dtoRequisicao, dtbReqItem);
            Requisicao.Upd(dtoRequisicao);
        }        

        #endregion

        #region EVENTOS

        private void FrmLiberacaoAlmox_Load(object sender, EventArgs e)
        {
            this.ConfiguraItensDTG();
            _permitePedidoOutroSetor = new Generico().VerificaAcessoFuncionalidade("cmbSetor");
        }

        private bool tsHac_SalvarClick(object sender)
        {
            if (MessageBox.Show("Deseja realmente confirmar o recebimento dos itens listados ?",
                                "Gestão de Materiais e Medicamentos",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.RECEBIDA_UNIDADE;
                    AtualizarStatusPedido();
                    this.CarregarRequisicao();
                    MessageBox.Show("Recebimento registrado com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }

        private bool tsHac_NovoClick(object sender)
        {
            tsHac.Controla(Evento.eNovo);
            this.ZerarObjetos();
            txtIdRequisicao.Focus();
            return false;
        }

        private bool tsHac_CancelarClick(object sender)
        {
            this.ZerarObjetos();
            return true;
        }

        private void txtIdRequisicao_Validating(object sender, CancelEventArgs e)
        {
            if (txtIdRequisicao.Text != string.Empty) this.CarregarRequisicao();            
        }

        private void btnReceber_Click(object sender, EventArgs e)
        {
            PacienteDTO dtoPac = new PacienteDTO();
            dtoPac.Idt.Value = dtoRequisicao.IdtAtendimento.Value;
            dtoPac.IdtUnidade.Value = dtoRequisicao.IdtUnidade.Value;
            dtoPac.IdtLocalAtendimento.Value = dtoRequisicao.IdtLocal.Value;
            dtoPac.IdtSetor.Value = dtoRequisicao.IdtSetor.Value;            
            dtoPac = Atendimento.SelChave(dtoPac);

            if (dtoPac != null && dtoPac.DtTransf.Value.IsNull)
                tsHac_SalvarClick(sender);
            else
                MessageBox.Show("Itens não podem ser recebidos, pois paciente já saiu do Setor.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente devolver os itens listados ?",
                                "Gestão de Materiais e Medicamentos",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    dtoRequisicao.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value; 
                    if (ReqItem.DevolverAlmoxarifado(dtoRequisicao))
                    {
                        dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.DEVOLVIDO_ENFERMAGEM;
                        AtualizarStatusPedido();
                        this.CarregarRequisicao();
                        MessageBox.Show("Itens devolvidos p/ o centro de dispensação com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtgMatMed_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgMatMed.Columns[e.ColumnIndex].Name == "colQtdeFornecida")
            {
                if (dtoRequisicao != null)
                {
                    if (!dtoRequisicao.Status.Value.IsNull)
                    {
                        if (dtoRequisicao.Status.Value != (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX &&
                            dtoRequisicao.Status.Value != (byte)RequisicaoDTO.StatusRequisicao.RECEBIDA_UNIDADE)
                        {
                            e.Value = 0;
                        }
                    }
                }                
            }
        }

        private void dtgMatMed_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();
            dtoMatMed.Idt.Value = Convert.ToDecimal(dtgMatMed.Rows[e.RowIndex].Cells["colMatMedIdt"].Value.ToString());
            dtoMatMed.IdtPrincipioAtivo.Value = Convert.ToDecimal(dtgMatMed.Rows[e.RowIndex].Cells["colPriAtivo"].Value.ToString());
            dtoMatMed.NomeFantasia.Value = dtgMatMed.Rows[e.RowIndex].Cells["colDsProd"].Value.ToString();
            new FrmPesquisaSimilares().VisualizarSimilares(dtoMatMed);
        }

        private void dtgMatMed_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgMatMed.Columns[e.ColumnIndex].Name == "colDiverg")
            {
                this.Cursor = Cursors.WaitCursor;
                for (int nCount = 0; nCount < dtbReqItem.Rows.Count; nCount++)
                {
                    if (dtbReqItem.Rows[nCount][RequisicaoItensDTO.FieldNames.IdtProduto].ToString() == dtgMatMed.Rows[e.RowIndex].Cells["colMatMedIdt"].Value.ToString())
                    {
                        dtoReqItem = (RequisicaoItensDTO)dtbReqItem.Rows[nCount];                        
                        break;
                    }
                }

                FrmRegDiveg.RegistrarDivergencia(dtoRequisicao, dtoReqItem);
                this.Cursor = Cursors.Default;
            }
        }

        private void dtgMatMed_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgMatMed.Columns[e.ColumnIndex].Name == colDevolver.Name &&
                dtoRequisicao != null && !dtoRequisicao.DataDispensacao.Value.IsNull)
            {
                if (DateTime.Parse(((DateTime)dtoRequisicao.DataDispensacao.Value).ToString("dd/MM/yyyy")) < Utilitario.ObterDataHoraServidor().Date.AddDays(-30))
                {
                    MessageBox.Show("Itens só podem ser devolvidos em até 30 dias após a Dispensação.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.Cursor = Cursors.WaitCursor;

                RequisicaoItensDTO dtoRequisicaoItem = new RequisicaoItensDTO();
                dtoRequisicaoItem.Idt.Value = dtoRequisicao.Idt.Value;
                dtoRequisicaoItem.IdtProduto.Value = Convert.ToInt64(dtgMatMed.Rows[e.RowIndex].Cells[colMatMedIdt.Name].Value.ToString());
                dtoRequisicaoItem.IdtUsuarioDispensacao.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                FrmEstornoItemPedido.Carregar(dtoRequisicao, dtoRequisicaoItem, true, false);

                CarregaItens();
                
                this.Cursor = Cursors.Default;
            }
        }

        #endregion
    }
}