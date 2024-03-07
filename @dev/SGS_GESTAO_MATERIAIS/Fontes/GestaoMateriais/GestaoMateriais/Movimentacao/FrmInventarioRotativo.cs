using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Forms;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmInventarioRotativo : FrmBase
    {
        public FrmInventarioRotativo()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇOS

        private ICodigoBarra _codigoBarra;
        private ICodigoBarra CodigoBarra
        {
            get { return _codigoBarra != null ? _codigoBarra : _codigoBarra = (ICodigoBarra)Global.Common.GetObject(typeof(ICodigoBarra)); }
        }        

        // Estoque
        private EstoqueLocalDTO dtoEstoque;
        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject(typeof(IEstoqueLocal)); }
        }

        // MatMed
        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }

        // Pedido Padrão                
        private IPedidoPadrao _pedidopadrao;
        private IPedidoPadrao PedidoPadrao
        {
            get { return _pedidopadrao != null ? _pedidopadrao : _pedidopadrao = (IPedidoPadrao)Global.Common.GetObject(typeof(IPedidoPadrao)); }
        }

        private IHistoricoNotaFiscal _histNF;
        private IHistoricoNotaFiscal HistoricoNotaFiscal
        {
            get { return _histNF != null ? _histNF : _histNF = (IHistoricoNotaFiscal)Global.Common.GetObject(typeof(IHistoricoNotaFiscal)); }
        }        

        #endregion

        #region FUNÇÕES

        private void ConfiguraEstoqueDTO()
        {
            dtoEstoque = new EstoqueLocalDTO();            

            dtoEstoque.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoEstoque.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoEstoque.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoEstoque.IdtProduto.Value = dtoMatMed.Idt.Value;         
            dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            if (rbCE.Checked)
                dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
            else if (rbConsig.Checked)
                dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.CONSIGNADO;         
        }

        private bool Validar()
        {
            if (!this.ValidarFiliais(true)) return false;

            if (dtoMatMed == null)
            {
                MessageBox.Show("Selecione o Mat/Med", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            
            //if (decimal.Parse(txtNovaQtd.Text) == decimal.Parse(txtQtdEstoque.Text))
            //{
            //    MessageBox.Show("Nova Qtd. não pode ser igual à Qtd. Estoque", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}            

            return true;
        }

        private bool ValidarFiliais(bool mostrarMsgBox)
        {
            if (!rbHac.Checked && !rbCE.Checked && !rbConsig.Checked)
            {
                if (mostrarMsgBox) MessageBox.Show("Selecione Estoque HAC / CE / CONSIGNADO ?", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }            
            return true;
        }

        private void LimparQtdEstoques()
        {
            txtQtdEstoque.Text = txtQtdLote.Text = txtQtdPadrao.Text = string.Empty;
        }

        private void AtualizarQtdEstoques()
        {
            this.LimparQtdEstoques();
            if (dtoMatMed != null)
            {
                this.Cursor = Cursors.WaitCursor;
                this.ConfiguraEstoqueDTO();

                txtQtdEstoque.Text = "0";
                lblNumLote.Text = string.Empty;
                if ((int)dtoMatMed.IdtGrupo.Value == 1)
                {
                    lblLote.Visible = txtQtdLote.Visible = true;
                    if (!dtoMatMed.IdtLote.Value.IsNull)
                        dtoEstoque.IdtLote.Value = dtoMatMed.IdtLote.Value;
                }
                else
                    lblLote.Visible = txtQtdLote.Visible = false;

                dtoEstoque = Estoque.EstoqueLocalProduto(dtoEstoque);
                
                if (!dtoEstoque.QtdePadrao.Value.IsNull)
                {
                    lblQtdPadrao.Visible = txtQtdPadrao.Visible = true;
                    txtQtdPadrao.Text = dtoEstoque.QtdePadrao.Value.ToString();
                }
                else
                    lblQtdPadrao.Visible = txtQtdPadrao.Visible = false;

                if (!dtoEstoque.Qtde.Value.IsNull) txtQtdEstoque.Text = dtoEstoque.Qtde.Value.ToString();

                if (!dtoEstoque.QtdeLote.Value.IsNull && txtQtdLote.Visible)
                {
                    txtQtdLote.Text = dtoEstoque.QtdeLote.Value.ToString();

                    HistoricoNotaFiscalDTO dtoHistNF = new HistoricoNotaFiscalDTO();
                    dtoHistNF.IdtProduto.Value = dtoMatMed.Idt.Value;
                    dtoHistNF.IdtLote.Value = dtoMatMed.IdtLote.Value;
                    dtoHistNF.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC;

                    HistoricoNotaFiscalDataTable dtbHNF = HistoricoNotaFiscal.Sel(dtoHistNF);
                    if (dtbHNF.Rows.Count > 0)
                    {
                        lblNumLote.Text = dtbHNF.TypedRow(0).NumLote.Value;
                        if (!lblNumLote.Visible) lblNumLote.Visible = true;
                    }
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void CarregarProduto()
        {
            if (dtoMatMed == null)
            {
                MessageBox.Show("Material/Medicamento não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDsProduto.Text = txtUnidadeVenda.Text = string.Empty;
                txtIdProduto.Focus();
            }
            else if (dtoMatMed.FlAtivo.Value == 0)
            {
                MessageBox.Show("Material/Medicamento Inativo", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtoMatMed = null;            
                txtDsProduto.Text = txtUnidadeVenda.Text = string.Empty;
                txtIdProduto.Focus();
            }
            else
            {
                txtDsProduto.Text = dtoMatMed.NomeFantasia.Value;
                txtUnidadeVenda.Text = dtoMatMed.DsUnidadeVenda.Value;
            }
            this.AtualizarQtdEstoques();            

            txtIdProduto.Text = txtNovaQtd.Text = string.Empty;
            txtNovaQtd.Focus();
        }

        private bool Salvar(int idUsuario)
        {
            if (!this.Validar()) return false;
            try
            {
                this.ConfiguraEstoqueDTO();

                dtoEstoque.Qtde.Value = txtNovaQtd.Text;
                if ((int)dtoMatMed.IdtGrupo.Value == 1)
                    dtoEstoque.IdtLote.Value = dtoMatMed.IdtLote.Value;
                dtoEstoque.IdtUsuario.Value = idUsuario;

                Estoque.AcertarEstoqueProduto(dtoEstoque, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            this.AtualizarQtdEstoques();
            MessageBox.Show("Saldo gravado com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private bool ValidarUsuario(out SegurancaDTO dtoUsuario)
        {
            this.Cursor = Cursors.WaitCursor;
            dtoUsuario = FrmLogin.Logar(true);
            if (dtoUsuario != null)
            {
                if (!new Generico().VerificaAcessoFuncionalidade("Inventario", dtoUsuario))
                {
                    MessageBox.Show("Usuário sem permissão para esta funcionalidade.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Cursor = Cursors.Default;
                    return false;
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                return false;
            }
            this.Cursor = Cursors.Default;
            return true;
        }

        #endregion

        #region EVENTOS

        private void FrmInventarioRotativo_Load(object sender, EventArgs e)
        {
            cmbUnidade.Carregaunidade();
            Generico.ConfiguraCombos(cmbUnidade, cmbLocal, cmbSetor, FrmPrincipal.dtoSeguranca);
        }        

        private void txtIdProduto_Validating(object sender, CancelEventArgs e)
        {
            if (txtIdProduto.Text != string.Empty)
            {
                if (!this.ValidarFiliais(true))
                {
                    txtIdProduto.Text = string.Empty;
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();

                dtoCodigoBarra.CdBarra.Value = txtIdProduto.Text;
                // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
                dtoMatMed = MatMed.BuscaCodigoBarra(dtoCodigoBarra);

                this.CarregarProduto();
                this.Cursor = Cursors.Default;
            }
        }

        private bool tsHac_MatMedClick(object sender)
        {
            if (!this.ValidarFiliais(true)) return false;

            MaterialMedicamentoDTO dtoMatMedAux = new MaterialMedicamentoDTO();

            dtoMatMedAux.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
            dtoMatMedAux.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.SEM_ESTOQUE;
            dtoMatMedAux.FlAtivo.Value = 1;
            dtoMatMedAux = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMedAux);

            if (dtoMatMedAux != null)
            {
                if (!dtoMatMedAux.Idt.Value.IsNull)
                {
                    if ((int)dtoMatMedAux.IdtGrupo.Value == 1)
                    {
                        MessageBox.Show("Obrigatório identificar MEDICAMENTO por Código de Barra  !", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtIdProduto.Focus();
                        return false;
                    }
                    else
                    {
                        dtoMatMed = dtoMatMedAux;
                        this.CarregarProduto();
                    }
                }
            }

            return true;
        }

        private bool tsHac_CancelarClick(object sender)
        {
            dtoMatMed = null;
            lblNumLote.Text = string.Empty;                    
            return true;
        }

        private bool tsHac_NovoClick(object sender)
        {
            tsHac_CancelarClick(sender);
            return true;
        }

        private bool tsHac_AfterNovo(object sender)
        {
            if (rbHac.Checked || rbCE.Checked || rbConsig.Checked) txtIdProduto.Focus();
            return true;
        }

        private bool tsHac_SalvarClick(object sender)
        {
            if (MessageBox.Show("Deseja realmente salvar este saldo para este item ?",
                                "Gestão de Materiais e Medicamentos",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SegurancaDTO dtoUsuario;
                if (!ValidarUsuario(out dtoUsuario)) return false;

                return this.Salvar((int)dtoUsuario.Idt.Value);
            }
            return false;
        }

        private void rbHac_CheckedChanged(object sender, EventArgs e)
        {
            this.AtualizarQtdEstoques();
            if (rbHac.Checked) txtIdProduto.Focus();
        }

        private void rbCE_CheckedChanged(object sender, EventArgs e)
        {
            this.AtualizarQtdEstoques();
            if (rbCE.Checked) txtIdProduto.Focus();
        }

        private void rbConsig_CheckedChanged(object sender, EventArgs e)
        {
            this.AtualizarQtdEstoques();
            if (rbConsig.Checked) txtIdProduto.Focus();
        }

        private void cmbUnidade_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dtoMatMed = null;
            tsHac.Controla(Evento.eCancelar);
        }

        private void cmbLocal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dtoMatMed = null;
            tsHac.Controla(Evento.eCancelar);
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dtoMatMed = null;
            tsHac.Controla(Evento.eCancelar);
        }        
        #endregion        
    }
}