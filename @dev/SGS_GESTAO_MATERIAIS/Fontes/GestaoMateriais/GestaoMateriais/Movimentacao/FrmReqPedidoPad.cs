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
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmReqPedidoPad : FrmBase
    {
        public FrmReqPedidoPad()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇO

        // Pedido Padrão
        private PedidoPadraoDataTable dtbPedidoPadrao;
        private PedidoPadraoDTO dtoPedidoPadrao;
        private IPedidoPadrao _pedidopadrao;
        private IPedidoPadrao PedidoPadrao
        {
            get { return _pedidopadrao != null ? _pedidopadrao : _pedidopadrao = (IPedidoPadrao)Global.Common.GetObject( typeof(IPedidoPadrao)); }
        }        

        Generico gen = new Generico();
                
        #endregion

        #region MÉTODOS

        private void ConfiguraDTG()
        {
            dtgPedidoPadrao.AutoGenerateColumns = false;
            dtgPedidoPadrao.Columns["colPedidoPadraoIdt"].DataPropertyName = PedidoPadraoDTO.FieldNames.Idt;
            dtgPedidoPadrao.Columns["colDsUnidade"].DataPropertyName = PedidoPadraoDTO.FieldNames.DsUnidade;
            dtgPedidoPadrao.Columns["colDsLocal"].DataPropertyName = PedidoPadraoDTO.FieldNames.DsLocal;
            dtgPedidoPadrao.Columns["colDsSetor"].DataPropertyName = PedidoPadraoDTO.FieldNames.DsSetor;
            dtgPedidoPadrao.Columns["colStatus"].DataPropertyName = PedidoPadraoDTO.FieldNames.Status;
            dtgPedidoPadrao.Columns["colDataUltDisp"].DataPropertyName = PedidoPadraoDTO.FieldNames.DataDispensado;
            dtgPedidoPadrao.Columns["colDataUltDisp"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dtgPedidoPadrao.Columns["colDataUltPedido"].DataPropertyName = PedidoPadraoDTO.FieldNames.DataUltimaRequisicao;
            dtgPedidoPadrao.Columns["colDataUltPedido"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }        

        private void CarregarPedidos()
        {
            this.Cursor = Cursors.WaitCursor;
            dtoPedidoPadrao = new PedidoPadraoDTO();
            Generico Acesso = new Generico();

            dtoPedidoPadrao.IdtFilial.Value = gen.RetornaFilial(rbHac, new RadioButton(), rbCE);

            dtoPedidoPadrao.DataDispensado.Value = DateTime.Now;
            // dtoPedidoPadrao.Status.Value = (byte)PedidoPadraoDTO.StatusPedidoPadrao.CONFIRMADO;
            dtoPedidoPadrao.IdtUnidade.Value = FrmPrincipal.dtoSeguranca.IdtUnidade.Value;
            dtoPedidoPadrao.IdtLocal.Value = FrmPrincipal.dtoSeguranca.IdtLocal.Value;
            dtoPedidoPadrao.IdtSetor.Value = FrmPrincipal.dtoSeguranca.IdtSetor.Value;

            // SO PODE VISIALIZAR OUTRAS UNIDADE QUEM TEM PERMISSÃO
            // if (!Acesso.VerificaAcessoFuncionalidade("cmbUnidade"))
            //     dtoPedidoPadrao.IdtUnidade.Value = FrmPrincipal.dtoSeguranca.IdtUnidade.Value;
            // dtbPedidoPadrao = PedidoPadrao.Sel(dtoPedidoPadrao);
            dtbPedidoPadrao = PedidoPadrao.GeraImpressaoPedidoPadrao(dtoPedidoPadrao);            
            dtgPedidoPadrao.DataSource = dtbPedidoPadrao;


            lblSelecione.Visible = false;
            if (dtbPedidoPadrao.Rows.Count > 0) lblSelecione.Visible = true;
            this.Cursor = Cursors.Default;
        }

        private void Salvar()
        {
            PedidoPadraoDataTable dtbPedPadAbastecer = new PedidoPadraoDataTable();

            foreach (DataGridViewRow dtgRow in dtgPedidoPadrao.Rows)
            {
                if (bool.Parse(dtgRow.Cells["colCheck"].EditedFormattedValue.ToString()))
                {
                    dtoPedidoPadrao = (PedidoPadraoDTO)dtbPedidoPadrao.Rows.Find(Convert.ToInt64(dtgRow.Cells["colPedidoPadraoIdt"].Value));
                    dtoPedidoPadrao.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    int? idSetorFarmacia = null;
                    if (chbEnvioFarmacia.Checked) idSetorFarmacia = (int)FrmPrincipal.dtoSeguranca.IdtSetor.Value;
                    try
                    {

                       PedidoPadrao.GeraRequisicao(dtoPedidoPadrao,
                                                   rbApenasMateriais.Checked ? ((int)MaterialMedicamentoDTO.TipoMatMed.MATERIAL).ToString() : (rbApenasMedicamentos.Checked ? ((int)MaterialMedicamentoDTO.TipoMatMed.MEDICAMENTO).ToString() : ((int)MaterialMedicamentoDTO.TipoMatMed.TODOS).ToString()),
                                                   idSetorFarmacia);
                    } 
                    catch (Exception ex)
                    {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                    }                   

                    // dtbPedPadAbastecer.Add(dtoPedidoPadrao);
                }
            }
            this.CarregarPedidos();
            MessageBox.Show("Processo executado com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*
            if (dtbPedPadAbastecer.Rows.Count > 0)
            {
                try
                {
                    // PedidoPadrao.GeraRequisicao(dtbPedPadAbastecer, false);
                    PedidoPadrao.GeraRequisicao();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }                   
                this.CarregarPedidos();
                MessageBox.Show("Processo executado com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Selecione algum setor para a geração de pedido padrão", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }                                  
             * */
        }

        #endregion

        #region EVENTOS

        private void FrmReqPedidoPad_Load(object sender, EventArgs e)
        {
            this.ConfiguraDTG();
            rbHac.Checked = true;
            this.CarregarPedidos();
            chbEnvioFarmacia.Checked = gen.LogadoSetorFarmacia();
            if (chbEnvioFarmacia.Checked) chbEnvioFarmacia.Visible = true;
        }

        private bool tsHac_SalvarClick(object sender)
        {
            if (MessageBox.Show("Deseja realmente gerar pedido padrão dos setores selecionados ?",
                                "Gestão de Materiais e Medicamentos",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Salvar();
            }            
            return false;
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

        #endregion                                       

        private void dtgPedidoPadrao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtbPedidoPadrao != null)
            {
                if (dtbPedidoPadrao.Rows.Count > 0 && dtbPedidoPadrao.Rows.Count == dtgPedidoPadrao.Rows.Count)
                {
                    if (dtgPedidoPadrao.Rows[e.RowIndex].Cells["colStatus"].Value.ToString() == "2")
                        e.CellStyle.ForeColor = Color.Orange;
                    else if(dtgPedidoPadrao.Rows[e.RowIndex].Cells["colStatus"].Value.ToString() == "5" )
                        e.CellStyle.ForeColor = Color.Red;

                }
            }
        }
    }
}