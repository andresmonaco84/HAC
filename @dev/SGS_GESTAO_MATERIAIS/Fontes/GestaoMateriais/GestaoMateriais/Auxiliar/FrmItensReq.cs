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

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmItensReq : FrmBase
    {
        private static FrmItensReq frmItensReq;

        public FrmItensReq()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇO

        // Requisição
        private static RequisicaoDTO dtoRequisicao;
        private IRequisicao _requisicao;
        private IRequisicao Requisicao
        {
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject( typeof(IRequisicao)); }
        }

        // Itens Requisição
        private static RequisicaoItensDataTable dtbRequisicaoItem;
        private static RequisicaoItensDTO dtoRequisicaoItem;
        private static IRequisicaoItens _requisicaoitens;
        private static IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject( typeof(IRequisicaoItens)); }
        }
        private static byte statusReq = 0;
        private static bool apenasConsulta = false;

        #endregion  
      
        private static void ConfiguraDTG()
        {
            frmItensReq.dtgMatMed.AutoGenerateColumns = false;
            frmItensReq.dtgMatMed.Columns["colReqItemIdt"].DataPropertyName = RequisicaoItensDTO.FieldNames.Idt;
            frmItensReq.dtgMatMed.Columns["colMatMedIdt"].DataPropertyName = RequisicaoItensDTO.FieldNames.IdtProduto;
            frmItensReq.dtgMatMed.Columns["colDsProd"].DataPropertyName = RequisicaoItensDTO.FieldNames.DsProduto;
            frmItensReq.dtgMatMed.Columns["colMAV"].DataPropertyName = MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia;
            frmItensReq.dtgMatMed.Columns["colDsUnidadeVenda"].DataPropertyName = RequisicaoItensDTO.FieldNames.DsUnidadeVenda;
            frmItensReq.dtgMatMed.Columns["colEstoqueLocal"].DataPropertyName = RequisicaoItensDTO.FieldNames.EstoqueLocalQtde;
            frmItensReq.dtgMatMed.Columns["colQtdePadrao"].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdePadrao;
            frmItensReq.dtgMatMed.Columns["colQtdCentDisp"].DataPropertyName = RequisicaoItensDTO.FieldNames.EstoqueCentDispQtde;
            frmItensReq.dtgMatMed.Columns["colQtde"].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdSolicitada;
            frmItensReq.dtgMatMed.Columns["colQtdeFornecida"].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdFornecida;
            frmItensReq.dtgMatMed.Columns["colCodPresc"].DataPropertyName = RequisicaoItensDTO.FieldNames.IdPrescricaoInternacao;
            if (apenasConsulta)
            {
                frmItensReq.dtgMatMed.Columns["colData"].Visible = true;
                frmItensReq.dtgMatMed.Columns["colData"].DataPropertyName = RequisicaoDTO.FieldNames.DataRequisicao;
                frmItensReq.dtgMatMed.Columns["colData"].DefaultCellStyle.Format = "dd/MM/yyyy à\\s HH:mm:ss";

                frmItensReq.dtgMatMed.Columns["colUsuPedido"].Visible = true;
                frmItensReq.dtgMatMed.Columns["colUsuPedido"].DataPropertyName = "DS_USUARIO_REQUISICAO";
            }            
        }

        /// <summary>
        /// Quando dtoItem != null é porque vai abrir por prescrição
        /// </summary>
        /// <param name="dtoReq"></param>
        /// <param name="dtoItem"></param>
        private static void RotinaCarregar(RequisicaoDTO dtoReq, RequisicaoItensDTO dtoItem)
        {
            frmItensReq = new FrmItensReq();
            dtoRequisicaoItem = new RequisicaoItensDTO();

            ConfiguraDTG();

            frmItensReq.Cursor = Cursors.WaitCursor;
            if (dtoItem != null)
            {
                if (dtoItem.IdPrescricaoItemInternacao.Value.IsNull)
                {
                    dtoRequisicaoItem.IdPrescricao.Value = dtoItem.IdPrescricao.Value;
                    dtoRequisicaoItem.IdtProduto.Value = dtoItem.IdtProduto.Value;                    
                }
                else
                    dtoRequisicaoItem.IdPrescricaoItemInternacao.Value = dtoItem.IdPrescricaoItemInternacao.Value;                

                dtbRequisicaoItem = RequisicaoItens.Sel(dtoRequisicaoItem);

                if (!dtoItem.IdPrescricaoItemInternacao.Value.IsNull && apenasConsulta)
                    frmItensReq.dtgMatMed.DataSource = new DataView(dtbRequisicaoItem,
                                                                     string.Format("{0} > 0", RequisicaoItensDTO.FieldNames.QtdSolicitada),
                                                                     string.Empty,
                                                                     DataViewRowState.CurrentRows).ToTable();
                else
                    frmItensReq.dtgMatMed.DataSource = dtbRequisicaoItem;
            }
            else
            {
                dtoRequisicaoItem.Idt.Value = dtoReq.Idt.Value;
                if (!apenasConsulta)
                    dtbRequisicaoItem = RequisicaoItens.SelItensRequisicao(dtoRequisicaoItem, true);
                else
                    dtbRequisicaoItem = RequisicaoItens.Sel(dtoRequisicaoItem);

                frmItensReq.dtgMatMed.DataSource = dtbRequisicaoItem;
            }            
            frmItensReq.Cursor = Cursors.Default;
            if (dtoItem == null) frmItensReq.lblNumReq.Text = dtoRequisicaoItem.Idt.Value;
            if (!apenasConsulta) statusReq = (byte)dtoReq.Status.Value;
        }

        public static void Editar(RequisicaoDTO dtoReq)
        {
            apenasConsulta = false;
            RotinaCarregar(dtoReq, null);
            dtoRequisicao = dtoReq;
            frmItensReq.ShowDialog();            
        }

        public static void Pesquisar(RequisicaoDTO dtoReq)
        {
            apenasConsulta = true;
            RotinaCarregar(dtoReq, null);
            
            frmItensReq.tsHac.SalvarVisivel = false;
            frmItensReq.dtgMatMed.Columns["colDeletar"].Visible = false;
            frmItensReq.dtgMatMed.Columns["colEstoqueLocal"].Visible = false;
            frmItensReq.dtgMatMed.Columns["colQtdePadrao"].Visible = false;
            frmItensReq.dtgMatMed.Columns["colQtdCentDisp"].Visible = false;
            frmItensReq.dtgMatMed.Columns["colQtde"].ReadOnly = true;
            frmItensReq.ShowDialog();            
        }

        public static void PesquisarPrescricaoItem(RequisicaoItensDTO dtoItem)
        {   
            apenasConsulta = true;            
            RotinaCarregar(null, dtoItem);

            frmItensReq.lblNumReq.Text = dtoItem.IdPrescricao.Value;
            frmItensReq.lblPedido.Text = "Prescrição";
            frmItensReq.tsHac.SalvarVisivel = false;
            frmItensReq.dtgMatMed.Columns["colReqItemIdt"].Visible = true;
            frmItensReq.dtgMatMed.Columns["colDeletar"].Visible = false;
            frmItensReq.dtgMatMed.Columns["colEstoqueLocal"].Visible = false;
            frmItensReq.dtgMatMed.Columns["colQtdePadrao"].Visible = false;
            frmItensReq.dtgMatMed.Columns["colQtdCentDisp"].Visible = false;
            frmItensReq.dtgMatMed.Columns["colQtde"].ReadOnly = true;
            frmItensReq.ShowDialog();
        }

        private bool tsHac_SalvarClick(object sender)
        {
            try
            {
                if (frmItensReq.dtgMatMed.RowCount == 0)
                {
                    //MessageBox.Show("Você não pode salvar esta requisição sem nenhum item adicionado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (MessageBox.Show("Se você salvar este pedido sem nenhum item, ele será cancelado. \n\nDeseja realmente cancelar este pedido ?",
                                         "Gestão de Materiais e Medicamentos",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.CANCELADA;
                        dtoRequisicao.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                        Requisicao.Upd(dtoRequisicao);
                        MessageBox.Show("Pedido cancelado com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmItensReq.Close();
                    }
                }
                else
                {
                    AtualizaGridEmEdicao();
                    dtoRequisicao.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    Requisicao.Gravar(dtoRequisicao, dtbRequisicaoItem);
                    MessageBox.Show("Itens Salvos com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }                     
            return false;
        }

        private void dtgMatMed_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgMatMed.Columns[e.ColumnIndex].Name == "colDeletar")
            {
                if (MessageBox.Show("Deseja deletar esse produto da lista ?",
                                     "Gestão de Materiais e Medicamentos",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int nCount = 0; nCount < dtbRequisicaoItem.Rows.Count; nCount++)
                    {
                        if (dtbRequisicaoItem.Rows[nCount].RowState != DataRowState.Deleted)
                        {
                            if (dtbRequisicaoItem.Rows[nCount][RequisicaoItensDTO.FieldNames.IdtProduto].ToString() == dtgMatMed.Rows[e.RowIndex].Cells["colMatMedIdt"].Value.ToString())
                            {
                                dtbRequisicaoItem.Rows[nCount].Delete();
                                break;
                            }
                        }
                    }
                }
            }
        }        

        private void dtgMatMed_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dtgMatMed.Columns[e.ColumnIndex].Name == "colQtde")
            {
                if (!this.IsNumber(e.FormattedValue.ToString()))
                {
                    tsHac.Enabled = false;
                    MessageBox.Show("Qtde Requis. deve ser numérica", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
                else if (e.FormattedValue.ToString().IndexOf(',') > -1)
                {
                    tsHac.Enabled = false;
                    MessageBox.Show("Qtde Requis. deve ser um número inteiro", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
                else if (decimal.Parse(e.FormattedValue.ToString()) <= 0)
                {                    
                    tsHac.Enabled = false;
                    MessageBox.Show("Qtde Requis. deve ser maior que 0", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;   
                }
            }
        }

        private void dtgMatMed_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            tsHac.Enabled = true;
        }

        private void dtgMatMed_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgMatMed.Columns[e.ColumnIndex].Name == "colQtdeFornecida" && !apenasConsulta)
            {
                if (statusReq != (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX &&
                    statusReq != (byte)RequisicaoDTO.StatusRequisicao.RECEBIDA_UNIDADE)
                {
                    e.Value = 0;
                }               
            }
        } 

        /// Solução alternativa para atualizar o grid quando está em edição.        
        private void AtualizaGridEmEdicao()
        {
            chkAjudaAtualizarGrid.Visible = true;
            chkAjudaAtualizarGrid.Focus();
            chkAjudaAtualizarGrid.Visible = false;
        }          
    }
}