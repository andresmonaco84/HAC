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
using HospitalAnaCosta.SGS.GestaoMateriais.Componentes;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmQtdMatMed : FrmGestao
    {
        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject( typeof(IRequisicaoItens)); }
        }
        private RequisicaoItensDTO dtoRequisicaoItem;
        private PedidoPadraoItensDTO dtoPedidoPadraoItens;
        private MovimentacaoDTO dtoMovimentacao;
        private int localChamado;
        private bool _limparDto = true;

        private ITipoFracao _tipofracao;
        private ITipoFracao TipoFracao
        {
            get { return _tipofracao != null ? _tipofracao : _tipofracao = (ITipoFracao)Global.Common.GetObject(typeof(ITipoFracao)); }
        }

        public FrmQtdMatMed()
        {
            InitializeComponent();
        }

        public static RequisicaoItensDTO DigitaQtde(RequisicaoItensDTO dto, bool selecionarPeriodoDose)
        {
            // CHAMDA DE:            
            // FrmPersonalizado
            FrmQtdMatMed frmQtdeMatmed = new FrmQtdMatMed();
            frmQtdeMatmed.dtoRequisicaoItem = dto;
            frmQtdeMatmed.localChamado = 1;
            frmQtdeMatmed.txtDsMatMed.Text = frmQtdeMatmed.dtoRequisicaoItem.DsProduto.Value;
            frmQtdeMatmed.txtEstoqueUnidade.Text = frmQtdeMatmed.dtoRequisicaoItem.EstoqueLocalQtde.Value;
            if (selecionarPeriodoDose)
            {
                frmQtdeMatmed.cmbPeriodoGerar.Visible = frmQtdeMatmed.cmbPeriodoGerar.Enabled = frmQtdeMatmed.lblPeriodoGerar.Visible = true;
                frmQtdeMatmed.cmbPeriodoGerar.Carregar();
            }
            frmQtdeMatmed.ShowDialog();
            return frmQtdeMatmed.dtoRequisicaoItem;
        }

        public static RequisicaoItensDTO DigitaQtde(RequisicaoItensDTO dto)
        {
            // CHAMDA DE:
            // FrmPedidoCarrinhoEmerg
            // FrmSolicitacaoMaterial
            FrmQtdMatMed frmQtdeMatmed = new FrmQtdMatMed();
            frmQtdeMatmed.dtoRequisicaoItem = dto;
            frmQtdeMatmed.localChamado = 1;
            frmQtdeMatmed.txtDsMatMed.Text = frmQtdeMatmed.dtoRequisicaoItem.DsProduto.Value;
            frmQtdeMatmed.txtEstoqueUnidade.Text = frmQtdeMatmed.dtoRequisicaoItem.EstoqueLocalQtde.Value;            
            frmQtdeMatmed.ShowDialog();
            return frmQtdeMatmed.dtoRequisicaoItem;
        }

        public static PedidoPadraoItensDTO DigitaQtde(PedidoPadraoItensDTO dto)
        {
            // CHAMADA DE:
            // FrmPedidoPadrao
            FrmQtdMatMed frmQtdeMatmed = new FrmQtdMatMed();
            frmQtdeMatmed.dtoPedidoPadraoItens = dto;
            frmQtdeMatmed.localChamado = 2;
            frmQtdeMatmed.txtDsMatMed.Text = frmQtdeMatmed.dtoPedidoPadraoItens.DsProduto.Value;
            frmQtdeMatmed.txtEstoqueUnidade.Text = frmQtdeMatmed.dtoPedidoPadraoItens.EstoqueLocalQtde.Value;
            frmQtdeMatmed.ShowDialog();
            return frmQtdeMatmed.dtoPedidoPadraoItens;
        }

        public static MovimentacaoDTO DigitaQtde(MovimentacaoDTO dto)
        {
            // CHAMADA DE: 
            // FrmDispensacao
            // FrmLancamentoOutraUnidade
            // FrmConsumoPaciente
            // 
            FrmQtdMatMed frmQtdeMatmed = new FrmQtdMatMed();
            frmQtdeMatmed.dtoMovimentacao = dto;
            frmQtdeMatmed.localChamado = 3;
            frmQtdeMatmed.txtDsMatMed.Text = frmQtdeMatmed.dtoMovimentacao.DsProduto.Value;
            //if (frmQtdeMatmed.dtoMovimentacao.FormOrigem.Value == (int)MovimentacaoDTO.TelaOrigem.CONSUMO_PACIENTE)
            //{
            //    frmQtdeMatmed.chkInteiro.Visible = true;
            //}

            if (!frmQtdeMatmed.dtoMovimentacao.TpFracao.Value.IsNull)
            {
                TipoFracaoDTO dtoTpFracao = new TipoFracaoDTO();
                dtoTpFracao.IdtTpFracao.Value = frmQtdeMatmed.dtoMovimentacao.TpFracao.Value;
                dtoTpFracao = frmQtdeMatmed.TipoFracao.SelChave(dtoTpFracao);
                frmQtdeMatmed.lblTpFracao.Visible = true;
                frmQtdeMatmed.txtTpFracao.Visible = true;
                frmQtdeMatmed.txtTpFracao.Text = dtoTpFracao.DsTpFracao.Value;
            }

            if (frmQtdeMatmed.dtoMovimentacao.EstoqueLocal.Value.IsNull)
            {
                frmQtdeMatmed.lblEstoque.Visible = false;
                frmQtdeMatmed.txtEstoqueUnidade.Visible = false;
            }
            else
            {
                frmQtdeMatmed.txtEstoqueUnidade.Text = frmQtdeMatmed.dtoMovimentacao.EstoqueLocal.Value;
            }

            if (frmQtdeMatmed.dtoMovimentacao.UnidadeVenda.Value.IsNull)
            {
                frmQtdeMatmed.lblUnidVenda.Visible = false;
                frmQtdeMatmed.txtUnidadeDeVenda.Visible = false;
            }
            else
            {
                // frmQtdeMatmed.lblUnidVenda.Visible = false;
                frmQtdeMatmed.txtUnidadeDeVenda.Text = frmQtdeMatmed.dtoMovimentacao.DsUnidadeVenda.Value.ToString();
            }
            frmQtdeMatmed.ShowDialog();            
            return frmQtdeMatmed.dtoMovimentacao;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtQtde.Text.Length != 0)
            {
                if (Convert.ToDecimal(txtQtde.Text) <= 0)
                {
                    MessageBox.Show("Quantidade Solicitada deve ser maior que 0", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQtde.Focus();
                }
                else
                {
                    if (localChamado == 1)
                    {
                        // requisicao
                        dtoRequisicaoItem.QtdSolicitada.Value = Convert.ToDecimal(txtQtde.Text);
                        dtoRequisicaoItem = RequisicaoItens.CalculaQtdFornecidaAlmoxarifado(dtoRequisicaoItem);
                    }
                    else if (localChamado == 2)
                    {
                        dtoPedidoPadraoItens.Qtde.Value = Convert.ToDecimal(txtQtde.Text);
                        if (dtoPedidoPadraoItens.EstoqueLocalQtde.Value.IsNull) dtoPedidoPadraoItens.EstoqueLocalQtde.Value = 0;

                        //Transforma dtoPedidoPadraoItens em dtoRequisicaoItem para calcular a qtd a Fornecer do item do Pedido Padrão
                        dtoRequisicaoItem = new RequisicaoItensDTO();

                        dtoRequisicaoItem.QtdSolicitada = dtoPedidoPadraoItens.Qtde;
                        dtoRequisicaoItem.EstoqueLocalQtde = dtoPedidoPadraoItens.EstoqueLocalQtde;
                        dtoRequisicaoItem = RequisicaoItens.CalculaQtdFornecidaAlmoxarifado(dtoRequisicaoItem);

                        dtoPedidoPadraoItens.Fornecer = dtoRequisicaoItem.QtdFornecida;
                    }
                    else if (localChamado == 3)
                    {
                        if ((!dtoMovimentacao.FlFracionado.Value.IsNull && dtoMovimentacao.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM) &&
                            Convert.ToDecimal(txtQtde.Text) >= 10000)
                        {
                            MessageBox.Show("Quantidade inválida, tem que ser menor que 10.000", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtQtde.Focus();
                            return;
                        }
                        dtoMovimentacao.Qtde.Value = Convert.ToDecimal(txtQtde.Text);                        
                    }
                    if (cmbPeriodoGerar.Visible)
                    {
                        if (cmbPeriodoGerar.SelectedIndex == -1 || cmbPeriodoGerar.SelectedValue.ToString() == "-1")
                        {
                            MessageBox.Show("Selecione o Período Dose", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbPeriodoGerar.Focus();
                            return;
                        }
                        dtoRequisicaoItem.HorasPeriodoDose.Value = cmbPeriodoGerar.SelectedValue.ToString();
                    }
                    _limparDto = false;
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Quantidade Solicitada não pode estar em branco", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQtde.Focus();
            }
        }

        private void FrmQtdMatMed_Load(object sender, EventArgs e)
        {
            txtQtde.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmQtdMatMed_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_limparDto)
            {
                dtoPedidoPadraoItens = null;
                dtoRequisicaoItem = null;
                dtoMovimentacao = null;
            } 
        }        
    }
}