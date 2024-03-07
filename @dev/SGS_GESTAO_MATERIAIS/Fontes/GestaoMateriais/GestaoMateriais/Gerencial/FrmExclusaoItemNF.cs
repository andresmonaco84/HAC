using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.Componentes;
using System.Web.UI.WebControls;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Gerencial
{
    public partial class FrmExclusaoItemNF : FrmBase
    {
        private bool _excluido = false;

        #region OBJETOS SERVIÇOS

        private MaterialMedicamentoDTO dtoProduto;
        private MaterialMedicamentoDTO dtoProdutoAcerto;
        private HistoricoNotaFiscalDTO dtoNFAcerto;

        private IHistoricoNFEstorno _hnfe;
        private IHistoricoNFEstorno HistNFEstorno
        {
            get { return _hnfe != null ? _hnfe : _hnfe = (IHistoricoNFEstorno)Global.Common.GetObject(typeof(IHistoricoNFEstorno)); }
        }
        #endregion

        public FrmExclusaoItemNF()
        {
            InitializeComponent();
        }

        public static bool SolicitarExclusao(HistoricoNotaFiscalDTO dtoNF, MaterialMedicamentoDTO dtoMatMed)
        {
            FrmExclusaoItemNF frm = new FrmExclusaoItemNF();
            frm.dtoProduto = dtoMatMed;
            frm.dtoProdutoAcerto = dtoMatMed;
            frm.dtoNFAcerto = dtoNF;
            frm.ShowDialog();
            return frm._excluido;
        }

        private void FrmExclusaoItemNF_Load(object sender, EventArgs e)
        {
            tsHac.Controla(Evento.eEditar);

            lblCod.Text = dtoProduto.CodMne.Value;
            lblProduto.Text = dtoProduto.NomeFantasia.Value;
            lblEstoque.Text = dtoNFAcerto.IdtFilial.Value == 2 ? "ACS" : "HAC";

            lblNumero.Text = dtoNFAcerto.NrNota.Value;
            lblFornecedor.Text = dtoNFAcerto.DsFornecedor.Value;
            lblQtdEstorno.Text = ((decimal)dtoNFAcerto.Qtde.Value).ToString("N0");
            lblLote.Text = dtoNFAcerto.NumLote.Value;
            lblData.Text = dtoNFAcerto.DataPrcMedio.Value;            

            lblCodAcerto.Text = dtoProdutoAcerto.CodMne.Value;
            lblProdutoAcerto.Text = dtoProdutoAcerto.NomeFantasia.Value;            
        }

        private bool tsHac_ExcluirClick(object sender)
        {
            int qtdMaxPermitidaDevolucaoParcial = int.Parse(lblQtdEstorno.Text.Replace(".", "")) - 1;
            if (!chbSemSubst.Checked && dtoProdutoAcerto == null)
            {
                MessageBox.Show("Selecione o produto de acerto que substituirá o produto selecionado da NF", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (txtMotivo.Text == string.Empty)
            {
                MessageBox.Show("Digite o motivo do estorno", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (chbDevParc.Checked && txtQtdDevParc.Text == string.Empty)
            {
                MessageBox.Show("Digite a Qtd. a devolver", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (chbDevParc.Checked)                      
            {
                if (qtdMaxPermitidaDevolucaoParcial == 0)
                {
                    MessageBox.Show("Não há qtd. para devolução parcial deste item nesta NF", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else if (int.Parse(txtQtdDevParc.Text) == 0 || int.Parse(txtQtdDevParc.Text) > qtdMaxPermitidaDevolucaoParcial)
                {
                    if (qtdMaxPermitidaDevolucaoParcial == 1)
                        MessageBox.Show("Qtd. a devolver só pode ser 1", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        MessageBox.Show("Qtd. a devolver tem que ser entre 1 e " + qtdMaxPermitidaDevolucaoParcial.ToString(), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            HistoricoNFEstornoDTO dtoNFE = new HistoricoNFEstornoDTO();
            dtoNFE.IdtLote.Value = dtoNFAcerto.IdtLote.Value;
            dtoNFE.TpMov.Value = dtoNFAcerto.TpMovimento.Value;
            dtoNFE.DsFornecedor.Value = dtoNFAcerto.DsFornecedor.Value;
            dtoNFE.NrNota.Value = dtoNFAcerto.NrNota.Value;
            dtoNFE.IdMovRM.Value = dtoNFAcerto.IdMovRM.Value;
            dtoNFE.IdtFilial.Value = dtoNFAcerto.IdtFilial.Value;
            dtoNFE.IdtProduto.Value = dtoNFAcerto.IdtProduto.Value;
            dtoNFE.StatusEstorno.Value = (byte)HistoricoNFEstornoDTO.Status.OK;
            if (!chbSemSubst.Checked && dtoProdutoAcerto != null)
            {
                dtoNFE.IdtProdutoAcerto.Value = dtoProdutoAcerto.Idt.Value;
                dtoNFE.StatusEstorno.Value = (byte)HistoricoNFEstornoDTO.Status.PENDENTE_ACERTO;
            } 
            dtoNFE.Motivo.Value = txtMotivo.Text;
            dtoNFE.QtdeEstorno.Value = lblQtdEstorno.Text;
            dtoNFE.UsuarioAtualizacao.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
            int? qtdDevParc = null;
            if (chbDevParc.Checked)
            {
                qtdDevParc = int.Parse(txtQtdDevParc.Text);
                dtoNFE.Motivo.Value += " - QTDE.: " + txtQtdDevParc.Text;
            }
            try
            {
                HistNFEstorno.Incluir(dtoNFE, qtdDevParc, dtoNFAcerto.PrecoUnitario.Value);
                _excluido = true;
                this.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("FK_NFE") > -1)
                    MessageBox.Show("NF já com registro de devolução no SGS", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return false;
        }

        private bool tsHac_MatMedClick(object sender)
        {
            if (!chbDevParc.Checked)
            {
                MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();
                dtoMatMed.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.SEM_ESTOQUE;
                dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMed);
                lblNenhum.Visible = lblMesmo.Visible = lblOutro.Visible = false;
                if (dtoMatMed != null)
                {
                    dtoProdutoAcerto = dtoMatMed;
                    lblCodAcerto.Text = dtoProdutoAcerto.CodMne.Value;
                    lblProdutoAcerto.Text = dtoProdutoAcerto.NomeFantasia.Value;
                    chbSemSubst.Checked = false;
                }
                else if (dtoProdutoAcerto == null)
                {
                    lblNenhum.Visible = true;
                }

                if (dtoProdutoAcerto != null && dtoProdutoAcerto.Idt.Value.ToString() == dtoProduto.Idt.Value.ToString())
                    lblMesmo.Visible = true;
                else
                    lblOutro.Visible = true;

                return true;
            }
            return false;
        }  

        private void chbSemSubst_Click(object sender, EventArgs e)
        {
            lblMesmo.Visible = lblOutro.Visible = false;            
            if (chbSemSubst.Checked)
            {
                dtoProdutoAcerto = null;
                lblNenhum.Visible = true;
                lblCodAcerto.Text = "-";
                lblProdutoAcerto.Text = "-";
            }            
        }

        private void chbDevParc_Click(object sender, EventArgs e)
        {
            lblOutro.Visible = false;
            if (chbDevParc.Checked)
            {
                chbSemSubst.Checked = false;
                txtMotivo.Text = chbDevParc.Text;
                chbSemSubst.Enabled = txtMotivo.Enabled = lblNenhum.Visible = false;
                txtQtdDevParc.Enabled = lblMesmo.Visible = true;

                dtoProdutoAcerto = dtoProduto;

                lblCodAcerto.Text = dtoProdutoAcerto.CodMne.Value;
                lblProdutoAcerto.Text = dtoProdutoAcerto.NomeFantasia.Value;
                txtQtdDevParc.Focus();
            }
            else
            {
                txtMotivo.Text = string.Empty;
                chbSemSubst.Enabled = txtMotivo.Enabled = lblNenhum.Visible = true;
                txtQtdDevParc.Enabled = lblMesmo.Visible = false;
                dtoProdutoAcerto = null;
                lblCodAcerto.Text = "-";
                lblProdutoAcerto.Text = "-";
                txtMotivo.Focus();
            }
        }                      
    }
}