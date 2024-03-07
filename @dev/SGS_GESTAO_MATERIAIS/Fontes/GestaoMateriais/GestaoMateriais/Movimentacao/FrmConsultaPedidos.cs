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
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmPedidosConsulta : FrmBase
    {
        public FrmPedidosConsulta()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇO

        // Requisição
        private static RequisicaoDTO dtoRequisicao;
        private static RequisicaoDataTable dtbRequisicao;
        private static IRequisicao _requisicao;
        private static IRequisicao Requisicao
        {
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject(typeof(IRequisicao)); }
        }

        #endregion

        #region MÉTODOS

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

        private void ConfiguraDTG()
        {
            dtgPedido.AutoGenerateColumns = false;
            dtgPedido.Columns["colReqIdt"].DataPropertyName = RequisicaoDTO.FieldNames.Idt;
            dtgPedido.Columns["colDataReq"].DataPropertyName = RequisicaoDTO.FieldNames.DataRequisicao;
            dtgPedido.Columns["colDataReq"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dtgPedido.Columns["colDataDisp"].DataPropertyName = RequisicaoDTO.FieldNames.DataDispensacao;
            dtgPedido.Columns["colDataDisp"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dtgPedido.Columns["colPendente"].DataPropertyName = RequisicaoDTO.FieldNames.FlPendente;
            dtgPedido.Columns["colIdStatus"].DataPropertyName = RequisicaoDTO.FieldNames.Status;
            dtgPedido.Columns["colUsuarioPedido"].DataPropertyName = RequisicaoDTO.FieldNames.DsUsuarioRequisicao;
            dtgPedido.Columns["colUsuarioDispensa"].DataPropertyName = RequisicaoDTO.FieldNames.DsUsuarioDispensacao;
            dtgPedido.Columns["colTpRequisicao"].DataPropertyName = RequisicaoDTO.FieldNames.DsTipoRequisicao;
            dtgPedido.Columns["colIdtAtendimento"].DataPropertyName = RequisicaoDTO.FieldNames.IdtAtendimento;
            dtgPedido.Columns["colKit"].DataPropertyName = KitDTO.FieldNames.Descricao;
            dtgPedido.Columns[colOrigem.Name].DataPropertyName = RequisicaoDTO.FieldNames.SetorFarmacia;
        }

        private void Pesquisar()
        {
            dtoRequisicao = new RequisicaoDTO();          

            #region Cabeçalho

            if (cmbUnidade.SelectedIndex != -1)
            {
                dtoRequisicao.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("Selecione a unidade", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbUnidade.Focus();
                return;
            }
            if (cmbLocal.SelectedIndex != -1)
            {
                dtoRequisicao.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("Selecione o local", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbLocal.Focus();
                return;
            }
            if (cmbSetor.SelectedIndex != -1)
            {
                dtoRequisicao.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("Selecione o setor", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbSetor.Focus();
                return;
            }
            if (rbHac.Checked)
            {
                dtoRequisicao.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            }
            else if (rbAcs.Checked)
            {
                dtoRequisicao.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
            }
            //else
            //{
            //    MessageBox.Show("Selecione a filial", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            #endregion                                               

            #region Tipo Pedido
 
            //if (cmbTipoPedido.SelectedValue.ToString() == "-1")
            //{
            //    MessageBox.Show("Selecione o tipo do pedido", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    cmbTipoPedido.Focus();
            //    return;
            //}
            //else
            //{
            if (cmbTipoPedido.SelectedValue == null)
                cmbTipoPedido.SelectedIndex = 0;
            if (cmbTipoPedido.SelectedValue.ToString() != "-1")
                dtoRequisicao.IdtTipoRequisicao.Value = byte.Parse(cmbTipoPedido.SelectedValue.ToString());

            if (cmbTipoPedido.SelectedValue.ToString() == ((byte)RequisicaoDTO.TipoRequisicao.CARRINHO_EMERGENCIA).ToString())
            {
                if (rbHac.Checked) dtoRequisicao.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
            }
            
            //if (cmbTipoPedido.SelectedValue.ToString() == ((byte)RequisicaoDTO.TipoRequisicao.PADRAO).ToString())
            //    dtgPedido.Columns[colOrigem.Name].Visible = true;
            //else
            //    dtgPedido.Columns[colOrigem.Name].Visible = false;

            // }
        
            #endregion            

            #region Período

            if (txtInicio.Text == string.Empty)
            {
                //MessageBox.Show("Data Início deve ser preenchida", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //txtInicio.Focus();
                //return;
                txtInicio.Text = DateTime.Now.AddDays(-7).ToString();
            }
            if (txtFim.Text == string.Empty)
            {
                //MessageBox.Show("Data Fim deve ser preenchida", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //txtFim.Focus();
                //return;
                txtFim.Text = DateTime.Now.ToString();
            }

            DateTime dt;
            if (!DateTime.TryParse(txtInicio.Text, out dt))
            {
                MessageBox.Show("Data Início inválida", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtInicio.Focus();
                return;
            }
            else
            {
                dtoRequisicao.DataRequisicao.Value = txtInicio.Text;
            }
            if (!DateTime.TryParse(txtFim.Text, out dt))
            {
                MessageBox.Show("Data Fim inválida", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFim.Focus();
                return;
            }
            else
            {
                dtoRequisicao.DataRequisicao2.Value = txtFim.Text;
            }

            #endregion
            
            #region Status

            if (rbAlmox.Checked)
            {
                dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.FECHADA;
            }
            else if (rbNaDisp.Checked)
            {
                dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.IMPRESSO;
            }
            else if (rbDispensado.Checked)
            {
                dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX;
            }
            else if (rbCancelado.Checked)
            {
                dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.CANCELADA;
            }
            else if (rbDevolvido.Checked)
            {
                dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.DEVOLVIDO_ENFERMAGEM;
            }

            if (chkPendente.Checked) dtoRequisicao.FlPendente.Value = (byte)RequisicaoDTO.Pendente.SIM;

            #endregion

            if (txtNumAtend.Text != string.Empty) dtoRequisicao.IdtAtendimento.Value = txtNumAtend.Text;
            
            this.Cursor = Cursors.WaitCursor;
            try
            {
                dtbRequisicao = Requisicao.Sel(dtoRequisicao, true);
                dtgPedido.DataSource = dtbRequisicao;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            this.Cursor = Cursors.Default;
        }

        #endregion

        #region EVENTOS

        private void FrmPedidosConsulta_Load(object sender, EventArgs e)
        {
            cmbUnidade.Carregaunidade();
            Generico.ConfiguraCombos(cmbUnidade,cmbLocal,cmbSetor,FrmPrincipal.dtoSeguranca);
            Generico.CarregarComboTipoPedido(ref cmbTipoPedido);            
            ConfiguraDTG();
            //txtInicio.Text = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
            //txtFim.Text = DateTime.Now.ToString("dd/MM/yyyy");
            tsHac.Items["tsBtnPesquisar"].Enabled = true;
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            Pesquisar();
            return true;
        }

        private void dtgPedido_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgPedido.Columns[e.ColumnIndex].Name == "colStatus")
            {
                dtoRequisicao.Status.Value = byte.Parse(dtgPedido.Rows[e.RowIndex].Cells["colIdStatus"].Value.ToString());
                dtoRequisicao.FlPendente.Value = byte.Parse(dtgPedido.Rows[e.RowIndex].Cells["colPendente"].Value.ToString());
                e.Value = Requisicao.RetornarStatus(dtoRequisicao);
            }
            else if (dtgPedido.Columns[colOrigem.Name].Visible && dtgPedido.Columns[e.ColumnIndex].Name == colOrigem.Name)
            {
                if (!string.IsNullOrEmpty(dtgPedido.Rows[e.RowIndex].Cells[colOrigem.Name].Value.ToString()))
                    e.Value = "FARMACIA";
                else
                    e.Value = "ALMOXARIFADO";
            }
            else if (dtgPedido.Columns[e.ColumnIndex].Name == colPendente.Name)
            {
                if (!string.IsNullOrEmpty(dtgPedido.Rows[e.RowIndex].Cells[colPendente.Name].Value.ToString()) &&
                    byte.Parse(dtgPedido.Rows[e.RowIndex].Cells[colPendente.Name].Value.ToString()) == 1)
                    e.Value = "SIM";
                else
                    e.Value = "NÃO";
            }
        }

        private void dtgPedido_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRow rowItem = dtbRequisicao.Select(string.Format("{0} = {1}",
                                                                    RequisicaoDTO.FieldNames.Idt,
                                                                    dtgPedido.Rows[e.RowIndex].Cells[colReqIdt.Name].Value.ToString()))[0];
                FrmItensReq.Pesquisar((RequisicaoDTO)rowItem);
            }
        }

        private void txtNumAtend_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtNumAtend.Text != string.Empty)
            {
                cmbTipoPedido.SelectedValue = ((byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO).ToString();
            }
        }      

        private void cmbTipoRequisicao_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbTipoPedido.SelectedValue.ToString() != ((byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO).ToString())
            {
                txtNumAtend.Text = string.Empty;
            }
        }

        #endregion        
    }
}