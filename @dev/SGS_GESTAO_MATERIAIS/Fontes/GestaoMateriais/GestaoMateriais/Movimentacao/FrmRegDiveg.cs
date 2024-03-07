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
    public partial class FrmRegDiveg : FrmBase
    {
        public FrmRegDiveg()
        {
            InitializeComponent();
        }

        // Movimentacao
        private static MovimentacaoDTO dtoMovimento;
        private static MovimentacaoDataTable dtbMovimento;
        private static IMovimentacao _movimento;
        private static IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }
        private static MovimentacaoComplementoDTO dtoMovComp;
        private static MovimentacaoComplementoDataTable dtbMovComp;
        private static IMovimentacaoComplemento _movComp;
        private static IMovimentacaoComplemento MovComplemento
        {
            get { return _movComp != null ? _movComp : _movComp = (IMovimentacaoComplemento)Global.Common.GetObject(typeof(IMovimentacaoComplemento)); }
        }

        private static FrmRegDiveg frmRegDiveg;

        public static void RegistrarDivergencia(MovimentacaoDTO dto)
        {
            dtoMovimento = dto;
            frmRegDiveg = new FrmRegDiveg();
            frmRegDiveg.txtDescricao.Enabled = false;
            frmRegDiveg.chkResolvida.Visible = true;
            frmRegDiveg.lblObs.Visible = false;
            RegistrarDivergencia();
        }

        public static void RegistrarDivergencia(RequisicaoDTO dtoRequisicao, RequisicaoItensDTO dtoReqItem)
        {
            dtoMovimento = new MovimentacaoDTO();
            dtoMovimento.IdtUnidade.Value = dtoRequisicao.IdtUnidade.Value;
            dtoMovimento.IdtLocal.Value = dtoRequisicao.IdtLocal.Value;
            dtoMovimento.IdtSetor.Value = dtoRequisicao.IdtSetor.Value;
            dtoMovimento.IdtRequisicao.Value = dtoReqItem.Idt.Value;
            dtoMovimento.IdtProduto.Value = dtoReqItem.IdtProduto.Value;
            dtoMovimento.IdtTipo.Value = (byte)MovimentacaoDTO.TipoMovimento.ENTRADA;

            // OK NÃO UTILIZA DATA DE FORNECIMENTO
            dtbMovimento = Movimento.Sel(dtoMovimento, false);

            if (dtbMovimento.Rows.Count > 0)
            {
                dtoMovimento = (MovimentacaoDTO)dtbMovimento.Rows[0];
                RegistrarDivergencia();
            }
            else
            {
                MessageBox.Show("Produto sem nenhuma movimentação de entrada registrada para esta requisição", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private static void RegistrarDivergencia()
        {
            if (dtoMovimento.FlFinalizado.Value.IsNull || 
                dtoMovimento.FlFinalizado.Value != (byte)MovimentacaoDTO.StatusDivergencia.RESOLVIDA) dtoMovimento.FlFinalizado.Value = (byte)MovimentacaoDTO.StatusDivergencia.EM_DIVERGENCIA;
            if (dtoMovimento.FlFinalizado.Value == (byte)MovimentacaoDTO.StatusDivergencia.EM_DIVERGENCIA)
            {
                if (frmRegDiveg == null) frmRegDiveg = new FrmRegDiveg();
                dtoMovComp = new MovimentacaoComplementoDTO();
                dtoMovComp.Idt.Value = dtoMovimento.Idt.Value;
                dtbMovComp = MovComplemento.Sel(dtoMovComp);
                if (dtbMovComp.Rows.Count > 0)
                {
                    dtoMovComp = (MovimentacaoComplementoDTO)dtbMovComp.Rows[0];
                    frmRegDiveg.txtDescricao.Text = dtoMovComp.Obs.Value;
                    frmRegDiveg.txtUsuario.Text = dtoMovComp.UsuarioRelatado.Value;
                }
                else
                {
                    frmRegDiveg.txtUsuario.Text = FrmPrincipal.dtoSeguranca.NmUsuario.Value;
                }

                frmRegDiveg.txtDsProduto.Text = dtoMovimento.DsProduto.Value;
                frmRegDiveg.ShowDialog();
            }
            else if (dtoMovimento.FlFinalizado.Value == (byte)MovimentacaoDTO.StatusDivergencia.RESOLVIDA)
            {
                MessageBox.Show("Divergência já resolvida pelo almoxarifado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool tsHac_SalvarClick(object sender)
        {
            string msg;
            dtoMovComp.Obs.Value = txtDescricao.Text;
            dtoMovComp.UsuarioRelatado.Value = FrmPrincipal.dtoSeguranca.NmUsuario.Value;
            if (chkResolvida.Checked)
            {
                dtoMovimento.FlFinalizado.Value = (byte)MovimentacaoDTO.StatusDivergencia.RESOLVIDA;
                msg = "Divergência finalizada com sucesso"; 
            }
            else
            {
                dtoMovimento.FlFinalizado.Value = (byte)MovimentacaoDTO.StatusDivergencia.EM_DIVERGENCIA;
                msg = "Divergência registrada com sucesso";
            }            
            MovComplemento.RegistrarDivergencia(dtoMovComp, dtoMovimento);
            MessageBox.Show(msg, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            return false;
        }

        private void FrmRegDiveg_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmRegDiveg = null;
            dtoMovimento = null;
            dtbMovimento = null;
            _movimento = null;
            dtoMovComp = null;
            dtbMovComp = null;
            _movComp = null;
        }
    }
}