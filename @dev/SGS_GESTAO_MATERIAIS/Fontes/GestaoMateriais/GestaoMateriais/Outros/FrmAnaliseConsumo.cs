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
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmAnaliseConsumo : FrmBase
    {
        public FrmAnaliseConsumo()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇO

        // Pedido Padrão        
        private PedidoPadraoDTO dtoPedidoPadrao;
        private IPedidoPadrao _pedidopadrao;
        private IPedidoPadrao PedidoPadrao
        {
            get { return _pedidopadrao != null ? _pedidopadrao : _pedidopadrao = (IPedidoPadrao)Global.Common.GetObject( typeof(IPedidoPadrao)); }
        }

        // Itens de Pedido Padrão        
        private PedidoPadraoItensDTO dtoPedidoPadraoItens;
        private PedidoPadraoItensDataTable dtbPedidoPadraoItens;

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Carrega valoes para o dto do pedido padrão
        /// </summary>
        private void ConfiguraPedidoPadraoDTO()
        {
            dtoPedidoPadrao = new PedidoPadraoDTO();
            
            if (rbHac.Checked)
            {
                dtoPedidoPadrao.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
            }
            else if (rbAcs.Checked)
            {
                dtoPedidoPadrao.IdtFilial.Value = (int)FilialMatMedDTO.Filial.ACS;
            }
        }
                
        private void Carregar()
        {
            this.Cursor = Cursors.WaitCursor;
            this.ConfiguraPedidoPadraoDTO();
            dtbPedidoPadraoItens = PedidoPadrao.ListarItemRessuprir(dtoPedidoPadrao);
            dtgItensRessuprir.DataSource = dtbPedidoPadraoItens;
            lblSelecione.Visible = false;
            //if (dtbPedidoPadraoItens.Rows.Count > 0) lblSelecione.Visible = true;
            this.Cursor = Cursors.Default;
        }        

        /// <summary>
        /// Configura Colunas do DataGrid baseado nos campos do dto
        /// </summary>
        private void ConfiguraDTG()
        {
            dtgItensRessuprir.AutoGenerateColumns = false;

            dtgItensRessuprir.Columns["colIdProduto"].DataPropertyName = PedidoPadraoItensDTO.FieldNames.IdtProduto;
            dtgItensRessuprir.Columns["colPedidoPadraoIdt"].DataPropertyName = PedidoPadraoItensDTO.FieldNames.Idt;
            dtgItensRessuprir.Columns["colDsUnidade"].DataPropertyName = PedidoPadraoItensDTO.FieldNames.DsUnidade;            
            dtgItensRessuprir.Columns["colDsLocal"].DataPropertyName = PedidoPadraoItensDTO.FieldNames.DsLocal;                       
            dtgItensRessuprir.Columns["colDsSetor"].DataPropertyName = PedidoPadraoItensDTO.FieldNames.DsSetor;            
            dtgItensRessuprir.Columns["colDsProduto"].DataPropertyName = PedidoPadraoItensDTO.FieldNames.DsProduto;          
            
            dtgItensRessuprir.Columns["colDtUltDisp"].DataPropertyName = PedidoPadraoItensDTO.FieldNames.DataDispensado;
            dtgItensRessuprir.Columns["colDtUltDisp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgItensRessuprir.Columns["colDtUltDisp"].DefaultCellStyle.Format = "dd/MM/yyyy à\\s HH:mm:ss";
            
            dtgItensRessuprir.Columns["colPercEstoqueMin"].DataPropertyName = PedidoPadraoItensDTO.FieldNames.PontoRessuprimento;
            dtgItensRessuprir.Columns["colPercEstoqueMin"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            
            dtgItensRessuprir.Columns["colPercConsumida"].DataPropertyName = PedidoPadraoItensDTO.FieldNames.Percentual;
            dtgItensRessuprir.Columns["colPercConsumida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;            
        }

        private void Salvar()
        {
            PedidoPadraoItensDataTable dtbPedPadItemAbastecer = null;

            try
            {
                foreach (DataGridViewRow dtgRow in dtgItensRessuprir.Rows)
                {
                    if (bool.Parse(dtgRow.Cells["colCheck"].EditedFormattedValue.ToString()))
                    {
                        dtoPedidoPadraoItens = (PedidoPadraoItensDTO)dtbPedidoPadraoItens.Select(string.Format("{0} = {1} AND {2} = {3}",
                                                PedidoPadraoItensDTO.FieldNames.Idt,
                                                dtgRow.Cells["colPedidoPadraoIdt"].Value,
                                                PedidoPadraoItensDTO.FieldNames.IdtProduto,
                                                dtgRow.Cells["colIdProduto"].Value), string.Empty)[0];

                        dtoPedidoPadrao.Idt.Value = dtoPedidoPadraoItens.Idt.Value;
                        dtoPedidoPadrao.IdtUnidade.Value = dtoPedidoPadraoItens.IdtUnidade.Value;
                        dtoPedidoPadrao.IdtLocal.Value = dtoPedidoPadraoItens.IdtLocal.Value;
                        dtoPedidoPadrao.IdtSetor.Value = dtoPedidoPadraoItens.IdtSetor.Value;

                        dtbPedPadItemAbastecer = new PedidoPadraoItensDataTable();

                        dtbPedPadItemAbastecer.Add(dtoPedidoPadraoItens);
                        dtoPedidoPadrao.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                        // PedidoPadrao.GeraRequisicao(dtoPedidoPadrao, dtbPedPadItemAbastecer, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }                               

            if (dtbPedPadItemAbastecer != null)
            {
                this.Carregar();
                MessageBox.Show("Processo executado com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Selecione algum setor/produto para a geração de pedido para reabastecimento", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion        

        #region EVENTOS

        private void FrmAnaliseConsumo_Load(object sender, EventArgs e)
        {   
            this.ConfiguraDTG();
            //this.Carregar();
        }

        private void rbHac_CheckedChanged(object sender, EventArgs e)
        {
            this.Carregar();
        }

        private void rbAcs_CheckedChanged(object sender, EventArgs e)
        {
            this.Carregar();
        }        

        private bool tsHac_SalvarClick(object sender)
        {
            if (MessageBox.Show("Deseja realmente gerar pedidos para reabastecer os setores com os produtos selecionados ?",
                                "Gestão de Materiais e Medicamentos",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Salvar();
            }
            return false;
        }

        #endregion                
    }
}