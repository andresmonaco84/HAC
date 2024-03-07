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
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmReqPendente : FrmBase
    {
        public FrmReqPendente()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇO

        // Requisição
        private RequisicaoDTO dtoRequisicao;
        private RequisicaoDataTable dtbRequisicao;
        private IRequisicao _requisicao;
        private IRequisicao Requisicao
        {
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject(typeof(IRequisicao)); }
        }

        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }        

        #endregion

        #region MÉTODOS

        private void ConfiguraDTG()
        {
            dtgPedido.AutoGenerateColumns = false;
            dtgPedido.Columns["colReqIdt"].DataPropertyName = RequisicaoDTO.FieldNames.Idt;
            dtgPedido.Columns["colDsUnidade"].DataPropertyName = RequisicaoDTO.FieldNames.DsUnidade;
            dtgPedido.Columns["colDsLocal"].DataPropertyName = RequisicaoDTO.FieldNames.DsLocal;
            dtgPedido.Columns["colDsSetor"].DataPropertyName = RequisicaoDTO.FieldNames.DsSetor;            
            dtgPedido.Columns["colData"].DataPropertyName = RequisicaoDTO.FieldNames.DataAtualizacao;
            dtgPedido.Columns["colData"].DefaultCellStyle.Format = "dd/MM/yyyy à\\s HH:mm:ss";
            dtgPedido.Columns["colIdRef"].DataPropertyName = RequisicaoDTO.FieldNames.IdtReqRef;
            dtgPedido.Columns["colIdTipo"].DataPropertyName = RequisicaoDTO.FieldNames.IdtTipoRequisicao;
        }

        private void CarregarPedidos()
        {
            this.Cursor = Cursors.WaitCursor;
            dtoRequisicao = new RequisicaoDTO();

            if (rbHac.Checked)            
                dtoRequisicao.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;            
            else if (rbAcs.Checked)
                dtoRequisicao.IdtFilial.Value = (int)FilialMatMedDTO.Filial.ACS;
            else if (rbCE.Checked)
                dtoRequisicao.IdtFilial.Value = (int)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;

            dtoRequisicao.FlPendente.Value = (byte)RequisicaoDTO.Pendente.SIM;
            dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.ABERTA;
            // criar funcionalidade para verificar se operador pode gerar pedido padrão de todas as unidades
            // ou só da unidade que esta selecionada no login.
            // dtoRequisicao.IdtUnidade.Value = FrmPrincipal.dtoSeguranca.IdtUnidade.Value;
            dtbRequisicao = Requisicao.Sel(dtoRequisicao, false);
            
            bool pedidoOcultoCentroDisp = false;
            foreach (DataRow row in dtbRequisicao.Rows)
            {
                pedidoOcultoCentroDisp = false;
                if (new Generico().LogadoSetorFarmacia())
                {
                    if (string.IsNullOrEmpty(row[RequisicaoDTO.FieldNames.SetorFarmacia].ToString()))
                    {
                        row.Delete();
                        pedidoOcultoCentroDisp = true;
                    }
                    else if (int.Parse(row[RequisicaoDTO.FieldNames.SetorFarmacia].ToString()) != (int)FrmPrincipal.dtoSeguranca.IdtSetor.Value)
                    {
                        row.Delete();
                        pedidoOcultoCentroDisp = true;
                    }
                }
                else if (!string.IsNullOrEmpty(row[RequisicaoDTO.FieldNames.SetorFarmacia].ToString()))
                {
                    row.Delete();
                    pedidoOcultoCentroDisp = true;
                }
                if (chbAntimicrobianos.Checked || chbPsico.Checked || rbApenasMateriais.Checked || rbApenasMedicamentos.Checked)
                {                    
                    if (!pedidoOcultoCentroDisp)
                    {
                        RequisicaoItensDTO dtoRI = new RequisicaoItensDTO();
                        RequisicaoItensDataTable dtbRI;
                        dtoRI.Idt.Value = decimal.Parse(row[RequisicaoDTO.FieldNames.Idt].ToString());
                        dtbRI = RequisicaoItens.Sel(dtoRI);
                        if (dtbRI.Rows.Count > 0)
                        {
                            if (chbAntimicrobianos.Checked)
                            {
                                if (dtbRI.TypedRow(0).IdPrescricao.Value.IsNull || dtbRI.TypedRow(0).IdPrescricao.Value.ToString() == "0")
                                    row.Delete();
                            }
                            else if (chbPsico.Checked)
                            {
                                if (dtbRI.Select(string.Format("{0}=912", MaterialMedicamentoDTO.FieldNames.IdtSubGrupo)).Length == 0) //Deixar apenas subgrupo Psicotropicos = 912
                                    row.Delete();
                            }
                            if (rbApenasMateriais.Checked)
                            {
                                if (dtbRI.Select(string.Format("{0}<>1", MaterialMedicamentoDTO.FieldNames.IdtGrupo)).Length == 0 ||
                                    dtbRI.Select(string.Format("{0}<>1", MaterialMedicamentoDTO.FieldNames.IdtGrupo)).Length != dtbRI.Rows.Count)
                                    row.Delete();
                            }
                            else if (rbApenasMedicamentos.Checked)
                            {
                                if (dtbRI.Select(string.Format("{0}=1", MaterialMedicamentoDTO.FieldNames.IdtGrupo)).Length == 0 ||
                                    dtbRI.Select(string.Format("{0}=1", MaterialMedicamentoDTO.FieldNames.IdtGrupo)).Length != dtbRI.Rows.Count)
                                    row.Delete();
                            }
                        }
                    }
                }
            }
            dtbRequisicao.AcceptChanges();
            dtgPedido.DataSource = dtbRequisicao;

            lblSelecione.Visible = false;
            if (dtbRequisicao.Rows.Count > 0) lblSelecione.Visible = true;
            this.Cursor = Cursors.Default;
        }

        private void Salvar()
        {
            bool reqSalva = false;

            try
            {
                foreach (DataGridViewRow dtgRow in dtgPedido.Rows)
                {
                    if (bool.Parse(dtgRow.Cells["colCheck"].EditedFormattedValue.ToString()))
                    {
                        DataRow rowItem = dtbRequisicao.Select(string.Format("{0} = {1}",
                                                                             RequisicaoDTO.FieldNames.Idt,
                                                                             dtgRow.Cells[colReqIdt.Name].Value.ToString()))[0];
                        dtoRequisicao = (RequisicaoDTO)rowItem; //(RequisicaoDTO)dtbRequisicao.Rows.Find(dtgRow.Cells["colReqIdt"].Value);
                        dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.FECHADA;
                        dtoRequisicao.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                        Requisicao.Upd(dtoRequisicao);
                        reqSalva = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            

            if (reqSalva)
            {
                this.CarregarPedidos();
                MessageBox.Show("Pedido(s) liberado(s) com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Selecione algum setor para a liberação de pedido pendente", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }               

        #endregion

        #region EVENTOS

        private void FrmReqPendente_Load(object sender, EventArgs e)
        {
            this.ConfiguraDTG();
            rbHac.Checked = true;
            rbHac.Checked = false;
        }

        private bool tsHac_SalvarClick(object sender)
        {
            if (MessageBox.Show("Deseja realmente liberar o pedido pendente dos setores selecionados ?",
                                "Gestão de Materiais e Medicamentos",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Salvar();
            }
            return false;
        }

        private bool tsHac_LimparClick(object sender)
        {
            return true;
        }

        private void tsHac_AfterLimpar(object sender)
        {
            rbTodos.Checked = true;
        }

        private void rbHac_Click(object sender, EventArgs e)
        {
            this.CarregarPedidos();
        }

        private void rbAcs_Click(object sender, EventArgs e)
        {
            this.CarregarPedidos();
        }

        private void rbCE_Click(object sender, EventArgs e)
        {
            this.CarregarPedidos();
        }

        private void chbAntimicrobianos_Click(object sender, EventArgs e)
        {
            if (chbAntimicrobianos.Checked && chbPsico.Checked)
                chbPsico.Checked = false;

            if (rbHac.Checked || rbAcs.Checked || rbCE.Checked)
                this.CarregarPedidos();
        }

        private void chbPsico_Click(object sender, EventArgs e)
        {
            if (chbAntimicrobianos.Checked && chbPsico.Checked)
                chbAntimicrobianos.Checked = false;

            if (rbHac.Checked || rbAcs.Checked || rbCE.Checked)
                this.CarregarPedidos();
        }

        private void rbApenasMateriais_Click(object sender, EventArgs e)
        {
            if (rbHac.Checked || rbAcs.Checked || rbCE.Checked)
                this.CarregarPedidos();
        }

        private void rbApenasMedicamentos_Click(object sender, EventArgs e)
        {
            if (rbHac.Checked || rbAcs.Checked || rbCE.Checked)
                this.CarregarPedidos();
        }

        private void rbTodos_Click(object sender, EventArgs e)
        {
            if (rbHac.Checked || rbAcs.Checked || rbCE.Checked)
                this.CarregarPedidos();
        }

        private void dtgPedido_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgPedido.Columns[e.ColumnIndex].Name == "colReqTipo")
            {
                e.Value = Generico.ObterTipoRequisicaoDescricao(byte.Parse(dtgPedido.Rows[e.RowIndex].Cells["colIdTipo"].Value.ToString()));
            }
        }

        private void dtgPedido_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRow rowItem = dtbRequisicao.Select(string.Format("{0} = {1}",
                                                                    RequisicaoDTO.FieldNames.Idt,
                                                                    dtgPedido.Rows[e.RowIndex].Cells[colReqIdt.Name].Value.ToString()))[0];
                FrmItensReq.Editar((RequisicaoDTO)rowItem);
                this.CarregarPedidos();
            }            
        }

        #endregion
    }
}