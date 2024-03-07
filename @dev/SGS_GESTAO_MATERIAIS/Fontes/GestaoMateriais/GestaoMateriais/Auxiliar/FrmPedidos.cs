using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.Componentes;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmPedidos : FrmBase
    {
        public FrmPedidos()
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
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject( typeof(IRequisicao)); }
        }

        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }        

        #endregion

        public static void Pesquisar(RequisicaoDTO dtoReq)
        {
            FrmPedidos frmPedidos = new FrmPedidos();

            #region CONFIGURAÇÃO DO GRID
            frmPedidos.dtgPedido.AutoGenerateColumns = false;
            frmPedidos.dtgPedido.Columns["colReqIdt"].DataPropertyName = RequisicaoDTO.FieldNames.Idt;
            frmPedidos.dtgPedido.Columns["colDataReq"].DataPropertyName = RequisicaoDTO.FieldNames.DataRequisicao;
            frmPedidos.dtgPedido.Columns["colDataReq"].DefaultCellStyle.Format = "dd/MM/yyyy à\\s HH:mm:ss";
            frmPedidos.dtgPedido.Columns["colDataDisp"].DataPropertyName = RequisicaoDTO.FieldNames.DataDispensacao;
            frmPedidos.dtgPedido.Columns["colDataDisp"].DefaultCellStyle.Format = "dd/MM/yyyy à\\s HH:mm:ss";
            frmPedidos.dtgPedido.Columns["colPendente"].DataPropertyName = RequisicaoDTO.FieldNames.FlPendente;
            frmPedidos.dtgPedido.Columns["colIdStatus"].DataPropertyName = RequisicaoDTO.FieldNames.Status;
            frmPedidos.dtgPedido.Columns["colKit"].DataPropertyName = KitDTO.FieldNames.Descricao;
            #endregion           

            dtoRequisicao = new RequisicaoDTO();

            dtoRequisicao.IdtAtendimento.Value = dtoReq.IdtAtendimento.Value;
            dtoRequisicao.TpAtendimento.Value = dtoReq.TpAtendimento.Value;
            dtoRequisicao.IdtSetor.Value = dtoReq.IdtSetor.Value;
            dtbRequisicao = Requisicao.Sel(dtoRequisicao, true);
            frmPedidos.dtgPedido.DataSource = dtbRequisicao;
            frmPedidos.lblNumAtendimento.Text = dtoRequisicao.IdtAtendimento.Value;
            frmPedidos.Show();
            //frmPedidos.ShowDialog();
        }

        private void dtgPedido_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgPedido.Columns[e.ColumnIndex].Name == "colStatus")
            {
                dtoRequisicao.Status.Value = byte.Parse(dtgPedido.Rows[e.RowIndex].Cells["colIdStatus"].Value.ToString());
                dtoRequisicao.FlPendente.Value = byte.Parse(dtgPedido.Rows[e.RowIndex].Cells["colPendente"].Value.ToString());
                e.Value = Requisicao.RetornarStatus(dtoRequisicao);
            }
            else if (dtgPedido.Columns[e.ColumnIndex].Name == colAntimicrobiano.Name)
            {
                RequisicaoItensDTO dtoRI = new RequisicaoItensDTO();
                dtoRI.Idt.Value = decimal.Parse(dtgPedido.Rows[e.RowIndex].Cells[colReqIdt.Name].Value.ToString());
                RequisicaoItensDataTable dtbRI = RequisicaoItens.Sel(dtoRI);
                if (dtbRI.Rows.Count > 0)
                {
                    if (!dtbRI.TypedRow(0).IdPrescricao.Value.IsNull && dtbRI.TypedRow(0).IdPrescricao.Value.ToString() != "0")
                        e.Value = "SIM";
                    else
                        e.Value = "NÃO";
                }
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
    }
}