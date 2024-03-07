using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Interface;
using HospitalAnaCosta.SGS.Seguranca.View;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Cadastro
{
    public partial class FrmPedidoAutomaticoSetor : FrmBase
    {
        private MaterialMedicamentoDTO dtoMatMed;

        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }

        private IPaciente _atendimento;
        private IPaciente Atendimento
        {
            get { return _atendimento != null ? _atendimento : _atendimento = (IPaciente)Global.Common.GetObject(typeof(IPaciente)); }
        }

        public FrmPedidoAutomaticoSetor()
        {
            InitializeComponent();
        }

        private void ConfigGrid()
        {
            dtgPedidosGerar.AutoGenerateColumns = false;

            dtgPedidosGerar.Columns[colDsProd.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.NomeFantasia;
            dtgPedidosGerar.Columns[colDataDose.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.DataHoraAdmPaciente;
            dtgPedidosGerar.Columns[colDataDose.Name].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dtgPedidosGerar.Columns[colDataGerar.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.DataHoraGerar;
            dtgPedidosGerar.Columns[colDataGerar.Name].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dtgPedidosGerar.Columns[colPeriodoDose.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.HorasPeriodoDose;
            dtgPedidosGerar.Columns[colQtdGerar.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdPedidoGerar;
            dtgPedidosGerar.Columns[colSetor.Name].DataPropertyName = SetorDTO.FieldNames.Descricao;
            dtgPedidosGerar.Columns[colAtendimento.Name].DataPropertyName = RequisicaoDTO.FieldNames.IdtAtendimento;
            dtgPedidosGerar.Columns[colPedidoOrigem.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.Idt;
            dtgPedidosGerar.Columns[colPedidoNovo.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.IdtNovo;
            dtgPedidosGerar.Columns[colIdProduto.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.IdtProduto;
            dtgPedidosGerar.Columns[colCodPresc.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.IdPrescricaoInternacao;
        }

        private bool ValidarSetor()
        {
            if (cmbUnidade.SelectedIndex == -1 || cmbLocal.SelectedIndex == -1 || cmbSetor.SelectedIndex == -1)
                return false;

            return true;
        }

        private void CarregaInfoPaciente()
        {
            DataTable dtPaciente = Atendimento.ObterPaciente(decimal.Parse(txtNroInternacao.Text));

            if (dtPaciente.Rows.Count > 0)
            {
                txtNomePac.Text = dtPaciente.Rows[0][1].ToString();
                tsHac.Items["tsBtnPesquisar"].Enabled = true;
            }
            else
            {
                MessageBox.Show("Paciente não identificado com esta sequência.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomePac.Text = string.Empty;
                txtNroInternacao.Text = string.Empty;
                txtNroInternacao.Focus();
            }
        }

        private void FrmPedidoAutomaticoSetor_Load(object sender, EventArgs e)
        {
            cmbUnidade.Carregaunidade();
            ConfigGrid();
            tsHac_PesquisarClick(null);
            tsHac.Items["tsBtnMatMed"].Enabled = tsHac.Items["tsBtnPesquisar"].Enabled = btnSalvar.Enabled = true;
            btnStatus.Visible = new Generico().VerificaAcessoFuncionalidade("FrmReprocessarAtd");
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tsHac.Items["tsBtnPesquisar"].Enabled = true;
        }

        private bool tsHac_CancelarClick(object sender)
        {
            return true;
        }

        private void tsHac_AfterCancelar(object sender)
        {
            tsHac.Items["tsBtnMatMed"].Enabled = true;
            txtQtd.Enabled = false;
            txtQtd.Text = string.Empty;
            btnLimparProduto_Click(null, null);
        }

        private bool tsHac_MatMedClick(object sender)
        {
            dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(new MaterialMedicamentoDTO());
            if (dtoMatMed == null)
            {
                txtProduto.Text = string.Empty;
                btnLimparProduto.Visible = false;
                return false;
            }
            txtProduto.Text = dtoMatMed.NomeFantasia.Value;
            btnLimparProduto.Visible = true;
            tsHac.Items["tsBtnPesquisar"].Enabled = true;
            return true;
        }        

        private bool tsHac_PesquisarClick(object sender)
        {
            this.Cursor = Cursors.WaitCursor;
            RequisicaoDTO dtoReq = new RequisicaoDTO();
            RequisicaoItensDTO dtoReqItem = new RequisicaoItensDTO();

            if (ValidarSetor())
                dtoReq.IdtSetor.Value = cmbSetor.SelectedValue.ToString();

            if (!string.IsNullOrEmpty(txtNroInternacao.Text) && !string.IsNullOrEmpty(txtNomePac.Text))
                dtoReq.IdtAtendimento.Value = txtNroInternacao.Text;

            if (dtoMatMed != null && !dtoMatMed.Idt.Value.IsNull)
                dtoReqItem.IdtProduto.Value = dtoMatMed.Idt.Value;

            dtoReqItem.IdUsuarioPedidoAutoCancelado.Value = FrmPrincipal.dtoSeguranca.Idt.Value; //Passa o usuário para não trazer cancelados

            byte tipoBusca = 2;
            if (cbGerados.Checked && dtoReq.IdtSetor.Value.IsNull && dtoReq.IdtAtendimento.Value.IsNull && dtoReqItem.IdtProduto.Value.IsNull)
            {
                tipoBusca = 3;
                dtoReq.DataRequisicao.Value = DateTime.Now.AddDays(-5).Date; //trazer só até 5 dias
                //dtoReq.DataRequisicao.Value = DateTime.Now.AddMonths(-1).Date; //trazer só até 1 mês atrás
            }
            else if (cbGerados.Checked)
                tipoBusca = 3;
            
            if (cbGerados.Checked)
                dtgPedidosGerar.Columns[colSelecionar.Name].Visible = false;
            else
                dtgPedidosGerar.Columns[colSelecionar.Name].Visible = true;

            dtgPedidosGerar.DataSource = RequisicaoItens.ListarPedidoAutoControle(dtoReqItem, dtoReq, tipoBusca);            

            tsHac.Items["tsBtnPesquisar"].Enabled = true;
            this.Cursor = Cursors.Default;
            return false;
        }

        private void tsCancelarGeracaoPedidos_Click(object sender, EventArgs e)
        {
            if (!dtgPedidosGerar.Columns[colSelecionar.Name].Visible)
            {
                MessageBox.Show("Favor gerar listagem sem Pedidos Gerados para cancelamento.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtgPedidosGerar.Rows.Count > 0)
            {
                if (MessageBox.Show("Deseja realmente cancelar a geração dos Pedidos selecionados ?",
                                    "Gestão de Materiais e Medicamentos",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    bool itemCancelado = false;
                    foreach (DataGridViewRow dtgRow in dtgPedidosGerar.Rows)
                    {
                        if (bool.Parse(dtgRow.Cells[colSelecionar.Name].EditedFormattedValue.ToString()))
                        {
                            RequisicaoItensDTO dtoReqItem = new RequisicaoItensDTO();

                            dtoReqItem.Idt.Value = decimal.Parse(dtgRow.Cells[colPedidoOrigem.Name].Value.ToString());
                            dtoReqItem.IdtProduto.Value = decimal.Parse(dtgRow.Cells[colIdProduto.Name].Value.ToString());
                            dtoReqItem.DataHoraGerar.Value = DateTime.Parse(dtgRow.Cells[colDataGerar.Name].Value.ToString());
                            dtoReqItem.DataHoraAdmPaciente.Value = DateTime.Parse(dtgRow.Cells[colDataDose.Name].Value.ToString());
                            dtoReqItem.IdUsuarioPedidoAutoCancelado.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                            RequisicaoItens.CancelarPedidoAutoControle(dtoReqItem);

                            itemCancelado = true;
                        }
                    }
                    tsHac_PesquisarClick(null);
                    this.Cursor = Cursors.Default;                                       

                    if (itemCancelado)
                        MessageBox.Show("Item(ns) cancelado(s) com sucesso.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Nenhum item foi cancelado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Não existem itens para cancelar.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQtd.Text) || !txtQtd.Enabled) return;
            if (int.Parse(txtQtd.Text) == 0)
            {
                MessageBox.Show("QTDE. deve ser maior que 0.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtQtd.Text = string.Empty;
                txtQtd.Focus();
                return;
            }
            if (dtgPedidosGerar.Rows.Count > 0 && dtgPedidosGerar.CurrentRow.Index > -1 && //dtgPedidosGerar.CurrentRow.Selected &&
                int.Parse(dtgPedidosGerar.CurrentRow.Cells[colQtdGerar.Name].Value.ToString()) != int.Parse(txtQtd.Text))
            {
                this.Cursor = Cursors.WaitCursor;
                RequisicaoItensDTO dtoReqItem = new RequisicaoItensDTO();

                dtoReqItem.QtdPedidoGerar.Value = txtQtd.Text;
                dtoReqItem.Idt.Value = decimal.Parse(dtgPedidosGerar.CurrentRow.Cells[colPedidoOrigem.Name].Value.ToString());
                dtoReqItem.IdtProduto.Value = decimal.Parse(dtgPedidosGerar.CurrentRow.Cells[colIdProduto.Name].Value.ToString());
                dtoReqItem.DataHoraGerar.Value = DateTime.Parse(dtgPedidosGerar.CurrentRow.Cells[colDataGerar.Name].Value.ToString());
                dtoReqItem.IdtUsuarioDispensacao.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                RequisicaoItens.UpdPedidoAutoControle(dtoReqItem, null);
                tsHac_PesquisarClick(null);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnLimparProduto_Click(object sender, EventArgs e)
        {
            dtoMatMed = null;
            txtProduto.Text = string.Empty;
            btnLimparProduto.Visible = false;
        }

        private void btnPesquisaPac_Click(object sender, EventArgs e)
        {
            if (txtNroInternacao.Enabled && !string.IsNullOrEmpty(txtNroInternacao.Text))
                CarregaInfoPaciente();  
        }

        private void cbGerados_Click(object sender, EventArgs e)
        {
            tsHac.Items["tsBtnPesquisar"].Enabled = true;
        }

        private void txtNroInternacao_Validating(object sender, CancelEventArgs e)
        {
            if (txtNroInternacao.Text.Length != 0)
                btnPesquisaPac_Click(sender, e);
            else
                txtNomePac.Text = string.Empty;
        }

        private void dtgPedidosGerar_SelectionChanged(object sender, EventArgs e)
        {            
            tsHac.Items["tsBtnPesquisar"].Enabled = true;
        }

        private void dtgPedidosGerar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            txtQtd.Enabled = false;
            txtQtd.Text = string.Empty;

            if (e != null && dtgPedidosGerar.CurrentRow != null && dtgPedidosGerar.CurrentRow.Cells[colQtdGerar.Name].Selected && //dtgPedidosGerar.CurrentRow.Selected &&
                dtgPedidosGerar.Columns[colSelecionar.Name].Visible)
            {
                if (string.IsNullOrEmpty(dtgPedidosGerar.CurrentRow.Cells[colPedidoNovo.Name].Value.ToString()) ) //&&
                     //DateTime.Parse(dtgPedidosGerar.CurrentRow.Cells[colDataGerar.Name].Value.ToString()) > DateTime.Now)
                {
                    txtQtd.Text = dtgPedidosGerar.CurrentRow.Cells[colQtdGerar.Name].Value.ToString();
                    txtQtd.Enabled = true;                                     
                    dtgPedidosGerar.CurrentRow.Cells[colDsProd.Name].Selected = true;
                    txtQtd.Focus(); txtQtd.SelectAll();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            new FrmPedidoAutoStatus().Visualizar();
        }        

        private void dtgPedidosGerar_MouseDown(object sender, MouseEventArgs e)
        {
            if (dtgPedidosGerar.Rows.Count > 0)
            {
                dtgPedidosGerar.ClearSelection();
                int curRowIndex = dtgPedidosGerar.HitTest(e.X, e.Y).RowIndex;
                int curColumnIndex = dtgPedidosGerar.HitTest(e.X, e.Y).ColumnIndex;
                if (curRowIndex >= 0 && curRowIndex != dtgPedidosGerar.NewRowIndex)
                {
                    dtgPedidosGerar.Rows[curRowIndex].Selected = true;
                    dtgPedidosGerar.CurrentCell = dtgPedidosGerar.Rows[curRowIndex].Cells[curColumnIndex];
                }
            }
        }

        private void MnAlterarHora_Click(object sender, EventArgs e)
        {
            if (dtgPedidosGerar.CurrentCell != null)
            {
                this.Cursor = Cursors.WaitCursor;
                RequisicaoItensDTO dtoReqItem = new RequisicaoItensDTO();

                dtoReqItem.QtdPedidoGerar.Value = int.Parse(dtgPedidosGerar.CurrentRow.Cells[colQtdGerar.Name].Value.ToString());
                dtoReqItem.IdPrescricaoInternacao.Value = int.Parse(dtgPedidosGerar.CurrentRow.Cells[colCodPresc.Name].Value.ToString());
                dtoReqItem.Idt.Value = int.Parse(dtgPedidosGerar.CurrentRow.Cells[colPedidoOrigem.Name].Value.ToString());
                dtoReqItem.IdtProduto.Value = int.Parse(dtgPedidosGerar.CurrentRow.Cells[colIdProduto.Name].Value.ToString());
                dtoReqItem.DsProduto.Value = dtgPedidosGerar.CurrentRow.Cells[colDsProd.Name].Value.ToString();
                dtoReqItem.DataHoraGerar.Value = DateTime.Parse(dtgPedidosGerar.CurrentRow.Cells[colDataGerar.Name].Value.ToString());
                dtoReqItem.DataHoraAdmPaciente.Value = DateTime.Parse(dtgPedidosGerar.CurrentRow.Cells[colDataDose.Name].Value.ToString());

                new FrmPedidoAutoAltera().Visualizar(dtoReqItem);
                
                tsHac_PesquisarClick(null);
                this.Cursor = Cursors.Default;
            }
        }        
    }
}