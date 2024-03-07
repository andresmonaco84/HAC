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

namespace HospitalAnaCosta.SGS.GestaoMateriais.Cadastro
{
    public partial class FrmPedidoAutoAltera : FrmBase
    {
        RequisicaoItensDTO _dtoItem;

        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }

        public FrmPedidoAutoAltera()
        {
            InitializeComponent();
        }

        public void Visualizar(RequisicaoItensDTO dtoItem)
        {
            _dtoItem = dtoItem;
            this.ShowDialog();
        }

        private void FrmPedidoAutoAltera_Load(object sender, EventArgs e)
        {
            if (_dtoItem != null)
            {
                lblCodPrescricao.Text = _dtoItem.IdPrescricaoInternacao.Value;
                lblItem.Text = _dtoItem.DsProduto.Value;
                lblDataDose.Text = _dtoItem.DataHoraAdmPaciente.Value;

                DateTime dataAtual = Utilitario.ObterDataHoraServidor();
                txtDtGerar.Text = dataAtual.ToString("dd/MM/yyyy"); //DateTime.Parse(_dtoItem.DataHoraGerar.Value.ToString()).ToString("dd/MM/yyyy");
                txtHora.Text = dataAtual.ToString("HH"); //DateTime.Parse(_dtoItem.DataHoraGerar.Value.ToString()).ToString("HH");
                txtMinuto.Text = dataAtual.ToString("mm"); //DateTime.Parse(_dtoItem.DataHoraGerar.Value.ToString()).ToString("mm");

                chkReplicar.Text = "Replicar novo horário p/ todos os itens desta Prescrição\n(ref. ao Pedido das " + DateTime.Parse(_dtoItem.DataHoraGerar.Value.ToString()).ToString("HH:mm")  + " hrs).";
            }
        }

        private bool tsHac_SalvarClick(object sender)
        {            
            if (txtDtGerar.Text == string.Empty || txtHora.Text == string.Empty || txtMinuto.Text == string.Empty)
            {
                MessageBox.Show("Digite a Data/Hora/Minuto para a geração do pedido.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDtGerar.Focus();
                return false;
            }
            if (int.Parse(txtHora.Text) > 24)
            {
                MessageBox.Show("Hora inválida.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHora.Focus();
                return false;
            }
            if (int.Parse(txtMinuto.Text) > 59)
            {
                MessageBox.Show("Minuto inválido.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMinuto.Focus();
                return false;
            }
            string strHoraMin = txtHora.Text.PadLeft(2, '0') + ":" + txtMinuto.Text.PadLeft(2, '0');
            string strData;
            try
            {
                strData = DateTime.Parse(txtDtGerar.Text).ToString("dd/MM/yyyy");
            }
            catch
            {
                MessageBox.Show("Data inválida.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDtGerar.Focus();
                return false;
            }
            DateTime dtHoraGerar = DateTime.Parse(strData + " " + strHoraMin);
            if (dtHoraGerar >= DateTime.Parse(_dtoItem.DataHoraAdmPaciente.Value.ToString()))
            {
                MessageBox.Show("Data/Hora Geração do Pedido deve ser inferior à Data/Hora Dose.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDtGerar.Focus();
                return false;
            }
            DateTime dataAtual = Utilitario.ObterDataHoraServidor();
            if (dtHoraGerar < dataAtual.AddMinutes(-30))
            {
                MessageBox.Show("Data/Hora Geração do Pedido deve ser superior à meia hora atrás.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDtGerar.Focus();
                return false;
            }
            
            DateTime novaDataGeracao = DateTime.Parse(strData + " " + strHoraMin);
            RequisicaoItensDTO dtoReqItem;

            if (chkReplicar.Checked)
            {
                RequisicaoItensDTO dtoReqItemPedidoAutoControle = new RequisicaoItensDTO();
                //dtoReqItemPedidoAutoControle.Idt.Value = _dtoItem.Idt.Value;
                dtoReqItemPedidoAutoControle.IdPrescricaoInternacao.Value = _dtoItem.IdPrescricaoInternacao.Value;
                dtoReqItemPedidoAutoControle.IdUsuarioPedidoAutoCancelado.Value = 1; //Passa o usuário para não trazer cancelados
                dtoReqItemPedidoAutoControle.DataHoraGerar.Value = _dtoItem.DataHoraGerar.Value;
                RequisicaoItensDataTable dtbPendenciasPrescricaoHora = RequisicaoItens.ListarPedidoAutoControle(dtoReqItemPedidoAutoControle, new RequisicaoDTO(), 2);

                foreach (DataRow rowReqItem in dtbPendenciasPrescricaoHora.Rows)
                {
                    if (string.IsNullOrEmpty(rowReqItem[RequisicaoItensDTO.FieldNames.IdtNovo].ToString()))
                    {
                        dtoReqItem = new RequisicaoItensDTO();

                        dtoReqItem.Idt.Value = rowReqItem[RequisicaoItensDTO.FieldNames.Idt].ToString();
                        dtoReqItem.IdtProduto.Value = rowReqItem[RequisicaoItensDTO.FieldNames.IdtProduto].ToString();
                        dtoReqItem.DataHoraGerar.Value = rowReqItem[RequisicaoItensDTO.FieldNames.DataHoraGerar].ToString();
                        dtoReqItem.DataHoraAdmPaciente.Value = rowReqItem[RequisicaoItensDTO.FieldNames.DataHoraAdmPaciente].ToString();
                        dtoReqItem.QtdPedidoGerar.Value = rowReqItem[RequisicaoItensDTO.FieldNames.QtdPedidoGerar].ToString();
                        dtoReqItem.IdtUsuarioDispensacao.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                        RequisicaoItens.UpdPedidoAutoControle(dtoReqItem, novaDataGeracao);
                    }
                }
            }
            else
            {
                dtoReqItem = new RequisicaoItensDTO();

                dtoReqItem.Idt.Value = _dtoItem.Idt.Value;
                dtoReqItem.IdtProduto.Value = _dtoItem.IdtProduto.Value;
                dtoReqItem.DataHoraGerar.Value = _dtoItem.DataHoraGerar.Value;
                dtoReqItem.DataHoraAdmPaciente.Value = _dtoItem.DataHoraAdmPaciente.Value;
                dtoReqItem.QtdPedidoGerar.Value = _dtoItem.QtdPedidoGerar.Value;
                dtoReqItem.IdtUsuarioDispensacao.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                RequisicaoItens.UpdPedidoAutoControle(dtoReqItem, novaDataGeracao);
            }

            MessageBox.Show("Data/Hora Geração do Pedido alterada com sucesso!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            return default(bool);
        }        
    }
}