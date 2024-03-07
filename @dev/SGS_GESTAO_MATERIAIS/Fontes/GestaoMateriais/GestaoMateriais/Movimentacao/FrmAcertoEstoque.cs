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

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmAcertoEstoque : FrmBase
    {
        public FrmAcertoEstoque()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇOS

        private ICodigoBarra _codigoBarra;
        private ICodigoBarra CodigoBarra
        {
            get { return _codigoBarra != null ? _codigoBarra : _codigoBarra = (ICodigoBarra)Global.Common.GetObject(typeof(ICodigoBarra)); }
        }

        private IHistoricoNotaFiscal _histNF;
        private IHistoricoNotaFiscal HistoricoNotaFiscal
        {
            get { return _histNF != null ? _histNF : _histNF = (IHistoricoNotaFiscal)Global.Common.GetObject(typeof(IHistoricoNotaFiscal)); }
        }

        // Estoque
        private EstoqueLocalDTO dtoEstoque;
        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject( typeof(IEstoqueLocal)); }
        }

        // MatMed
        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject( typeof(IMaterialMedicamento)); }
        }

        // Pedido Padrão        
        private PedidoPadraoDTO dtoPedidoPadrao;
        private IPedidoPadrao _pedidopadrao;
        private IPedidoPadrao PedidoPadrao
        {
            get { return _pedidopadrao != null ? _pedidopadrao : _pedidopadrao = (IPedidoPadrao)Global.Common.GetObject(typeof(IPedidoPadrao)); }
        }
        
        #endregion


        public static void AcertaEstoque(MovimentacaoDTO dto)
        {
            FrmAcertoEstoque frmAcerto = new FrmAcertoEstoque();
            MaterialMedicamentoDTO dtoMaterial = new MaterialMedicamentoDTO();
            frmAcerto.MdiParent = FrmPrincipal.ActiveForm;
            frmAcerto.Show();
            frmAcerto.tsHac_NovoClick(frmAcerto.tsHac);
            dtoMaterial.Idt.Value = dto.IdtProduto.Value;
            dtoMaterial = frmAcerto.MatMed.SelChave(dtoMaterial);

            frmAcerto.cmbUnidade.SelectedValue = dto.IdtUnidade.Value;
            frmAcerto.cmbLocal.SelectedValue = dto.IdtLocal.Value;
            frmAcerto.cmbSetor.SelectedValue = dto.IdtSetor.Value;

            frmAcerto.dtoMatMed = dtoMaterial;
            frmAcerto.CarregarProduto();
            if (dto.IdtFilial.Value == (decimal)FilialMatMedDTO.Filial.HAC)
            {
                frmAcerto.rbHac.Checked = true;
            }
            else if (dto.IdtFilial.Value == (decimal)FilialMatMedDTO.Filial.ACS)
            {
                frmAcerto.rbAcs.Checked = true;
            }
            else if (dto.IdtFilial.Value == (decimal)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA)
            {
                frmAcerto.rbCE.Checked = true;
            }

            frmAcerto.txtNovaQtd.Enabled = true;
        }

        #region FUNÇÕES

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
        
        private void ConfiguraEstoqueDTO()
        {
            dtoEstoque = new EstoqueLocalDTO();

            dtoEstoque.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoEstoque.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoEstoque.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            if (dtoMatMed != null) dtoEstoque.IdtProduto = dtoMatMed.Idt;
            if (txtNovaQtd.Text != string.Empty) dtoEstoque.Qtde.Value = txtNovaQtd.Text;
            if (rbHac.Checked)
            {
                dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            }
            else if (rbAcs.Checked)
            {
                dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
            }
            else if (rbCE.Checked)
            {
                dtoEstoque.IdtFilial.Value = (int)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
            }
            dtoEstoque.Origem.Value = 1;
        }

        private void ConfiguraPedidoPadraoDTO()
        {
            dtoPedidoPadrao = new PedidoPadraoDTO();

            dtoPedidoPadrao.IdtUnidade.Value = int.Parse(cmbUnidade.SelectedValue.ToString());
            dtoPedidoPadrao.IdtSetor.Value = int.Parse(cmbSetor.SelectedValue.ToString());
            dtoPedidoPadrao.IdtLocal.Value = int.Parse(cmbLocal.SelectedValue.ToString());
            dtoPedidoPadrao.Status.Value = (byte)PedidoPadraoDTO.StatusPedidoPadrao.CONFIRMADO;
            if (rbHac.Checked)
            {
                dtoPedidoPadrao.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
            }
            else if (rbAcs.Checked)
            {
                dtoPedidoPadrao.IdtFilial.Value = (int)FilialMatMedDTO.Filial.ACS;
            }
            else if (rbCE.Checked)
            {
                dtoPedidoPadrao.IdtFilial.Value = (int)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
            }
        }
        
        private void AtualizarQtdEstoque()
        {
            txtQtdEstoque.Text = string.Empty;
            txtQtdPadrao.Text = string.Empty;
            lblQtdPadrao.Visible = false;
            txtQtdPadrao.Visible = false;
            if (dtoMatMed != null)
            {
                this.ConfiguraEstoqueDTO();
                if (!dtoEstoque.IdtFilial.Value.IsNull)
                {
                    dtoEstoque = Estoque.EstoqueLocalProduto(dtoEstoque);

                    if (!dtoEstoque.Qtde.Value.IsNull)
                    {
                        txtQtdEstoque.Text = dtoEstoque.Qtde.Value.ToString();
                    }
                    else
                    {
                        txtQtdEstoque.Text = "0";
                    }
                    if (!dtoEstoque.QtdePadrao.Value.IsNull)
                    {
                        lblQtdPadrao.Visible = true;
                        txtQtdPadrao.Visible = true;
                        txtQtdPadrao.Text = dtoEstoque.QtdePadrao.Value.ToString();
                    }
                    else if (txtQtdEstoque.Text == "0")
                    {
                        ConfiguraPedidoPadraoDTO();
                        PedidoPadraoItensDTO dtoPedPadItem = null;
                        if (PedidoPadrao.ProdutoPadrao(dtoPedidoPadrao, dtoMatMed, ref dtoPedPadItem, false))
                        {
                            lblQtdPadrao.Visible = true;
                            txtQtdPadrao.Visible = true;
                            txtQtdPadrao.Text = dtoPedPadItem.Qtde.Value.ToString();
                        }
                    }
                    txtNovaQtd.Focus();
                }
            }
            else
            {
                txtIdProduto.Focus();
            }
        }

        private void CarregarProduto()
        {
            if (dtoMatMed != null)
            {
                txtDsProduto.Text = dtoMatMed.NomeFantasia.Value;
                txtUnidadeVenda.Text = dtoMatMed.DsUnidadeVenda.Value;
                //if (dtoMatMed.FlFracionado.Value == (decimal)MaterialMedicamentoDTO.Fracionado.SIM ||
                //     dtoMatMed.Tabelamedica.Value == ((decimal)MaterialMedicamentoDTO.TipoMatMed.MATERIAL).ToString())
                if (Generico.ProdutoUsoExclusivoHAC(dtoMatMed))
                {                    
                    rbHac.Checked = true;
                }
                else
                {
                    rbHac.Checked = false;
                    rbAcs.Checked = false;
                    rbCE.Checked = false;
                }
            }
            else
            {
                txtDsProduto.Text = string.Empty;
                txtUnidadeVenda.Text = string.Empty;
            }            
            this.AtualizarQtdEstoque();
            txtIdProduto.Text = string.Empty;
        }

        private bool ValidarFilial()
        {
            if (!rbAcs.Checked && !rbHac.Checked && !rbCE.Checked)
            {
                MessageBox.Show("Selecione a Filial", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private bool Validar()
        {
            if (!this.ValidarFilial()) return false;            

            if (dtoMatMed == null)
            {
                MessageBox.Show("Selecione o Mat/Med", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (rbAcs.Checked)
            {
                //if ((dtoMatMed.Tabelamedica.Value == ((int)MaterialMedicamentoDTO.TipoMatMed.MATERIAL).ToString() ||
                //     dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM) &&
                //     decimal.Parse(txtNovaQtd.Text) > 0)
                if ((Generico.ProdutoUsoExclusivoHAC(dtoMatMed)) && decimal.Parse(txtNovaQtd.Text) > 0)
                {
                    MessageBox.Show("Este produto é fracionado ou é um material e não pode existir no estoque do ACS", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            //if (decimal.Parse(txtNovaQtd.Text) == decimal.Parse(txtQtdEstoque.Text))
            //{
            //    MessageBox.Show("Nova Qtd. não pode ser igual à Qtd. Estoque", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}

            if (txtQtdPadrao.Text != string.Empty && txtQtdPadrao.Visible)
            {
                EstoqueLocalDTO dtoEstoqueCentDisp = new EstoqueLocalDTO();
                dtoEstoqueCentDisp.IdtUnidade.Value = int.Parse(cmbUnidade.SelectedValue.ToString());
                dtoEstoqueCentDisp.IdtSetor.Value = int.Parse(cmbSetor.SelectedValue.ToString());
                dtoEstoqueCentDisp.IdtLocal.Value = int.Parse(cmbLocal.SelectedValue.ToString());
                bool EstoqueCentroDispensacao = Estoque.EstoqueCentroDispensacao(dtoEstoqueCentDisp);

                if (decimal.Parse(txtNovaQtd.Text) > decimal.Parse(txtQtdPadrao.Text) && !EstoqueCentroDispensacao)
                {
                    MessageBox.Show("Nova Qtd. deve ser menor ou igual à Qtd. Padrão", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }            

            return true;
        }

        private bool Salvar()
        {
            if (!this.Validar()) return false;
            try
            {
                this.ConfiguraEstoqueDTO();
                dtoEstoque.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                Estoque.AcertarEstoqueProduto(dtoEstoque, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            this.AtualizarQtdEstoque();
            MessageBox.Show("Estoque acertado com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        #endregion

        #region EVENTOS

        private void FrmAcertoEstoque_Load(object sender, EventArgs e)
        {
            cmbUnidade.Carregaunidade();
            Generico.ConfiguraCombos(cmbUnidade, cmbLocal, cmbSetor, FrmPrincipal.dtoSeguranca);
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

        private bool tsHac_CancelarClick(object sender)
        {
            dtoMatMed = null;
            return true;
        }

        private bool tsHac_NovoClick(object sender)
        {
            dtoMatMed = null;
            return true;
        }

        private bool tsHac_SalvarClick(object sender)
        {
            if (!new Generico().VerificaAcessoFuncionalidade("FrmAcertoEstoque"))
            {
                MessageBox.Show("Usuário sem permissão para esta funcionalidade", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;    
            }
            if (MessageBox.Show("Deseja realmente executar o acerto deste estoque ?",
                                "Gestão de Materiais e Medicamentos",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return this.Salvar();
            }
            return false;
        }        

        private bool tsHac_MatMedClick(object sender)
        {
            //if (!ValidarFilial()) return false;

            dtoMatMed = new MaterialMedicamentoDTO();
            
            this.ConfiguraEstoqueDTO();

            //dtoMatMed.IdtFilial.Value = dtoEstoque.IdtFilial.Value;
            dtoMatMed.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.SEM_ESTOQUE;            
            dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMed);

            this.CarregarProduto();            

            return true;
        }

        private void txtIdProduto_Validating(object sender, CancelEventArgs e)
        {
            if (txtIdProduto.Text != string.Empty)
            {
                if (!this.ValidarFilial())
                {
                    txtIdProduto.Text = string.Empty;
                    return;
                }

                CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();

                dtoCodigoBarra.CdBarra.Value = txtIdProduto.Text;
                // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
                dtoMatMed = MatMed.BuscaCodigoBarra(dtoCodigoBarra);

                this.CarregarProduto();

                if (dtoMatMed == null)
                {
                    MessageBox.Show("Material/medicamento não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtIdProduto.Focus();
                }
            }
        }

        private void rbHac_CheckedChanged(object sender, EventArgs e)
        {
            this.AtualizarQtdEstoque();            
        }

        private void rbAcs_CheckedChanged(object sender, EventArgs e)
        {
            this.AtualizarQtdEstoque();            
        }

        private void rbCE_CheckedChanged(object sender, EventArgs e)
        {
            this.AtualizarQtdEstoque();
        }

        #endregion

        private void btnPesquisarCodBarra_Click(object sender, EventArgs e)
        {
            if (dtoMatMed == null) return;
            if (dtoMatMed.IdtGrupo.Value == 1 && string.IsNullOrEmpty(txtCodLote.Text))
            {
                MessageBox.Show("Cod Lote obrigatório para medicamento.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodLote.Focus();
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            if (dtoMatMed.IdtGrupo.Value == 1)
            {
                HistoricoNotaFiscalDTO dtoHistNF = new HistoricoNotaFiscalDTO();
                CodigoBarraDTO dtoCodBarraReimpressao = new CodigoBarraDTO();
                dtoCodBarraReimpressao.IdtFilial.Value = 1;
                dtoCodBarraReimpressao.IdtProduto.Value = dtoMatMed.Idt.Value;

                dtoHistNF.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
                dtoHistNF.IdtProduto.Value = dtoMatMed.Idt.Value;
                dtoHistNF.CodLote.Value = txtCodLote.Text;

                HistoricoNotaFiscalDataTable dtbHistNF = HistoricoNotaFiscal.Sel(dtoHistNF);

                if (dtbHistNF.Rows.Count > 0)
                {
                    dtoHistNF = dtbHistNF.TypedRow(0);
                    dtoCodBarraReimpressao.IdtLote.Value = dtoHistNF.IdtLote.Value;

                    CodigoBarraDataTable dtbCod = CodigoBarra.Sel(dtoCodBarraReimpressao, (decimal)FrmPrincipal.dtoSeguranca.Idt.Value);
                    if (dtbCod.Rows.Count > 0)
                    {
                        dtoCodBarraReimpressao = dtbCod.TypedRow(0);
                        txtCodBarra.Text = dtoCodBarraReimpressao.CdBarra.Value;
                    }
                    else
                    {
                        MessageBox.Show("CODIGO NAO ENCONTRADO", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCodBarra.Text = string.Empty;
                        this.Cursor = Cursors.Default;
                    }
                }
                else
                {
                    MessageBox.Show("CODIGO NAO ENCONTRADO", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodBarra.Text = string.Empty;
                    this.Cursor = Cursors.Default;
                    return;
                }

                this.Cursor = Cursors.Default;
            }
            else
            {
                txtCodLote.Text = string.Empty;
                string codBarra = CodigoBarra.ObterCodigo(1, (decimal)dtoMatMed.Idt.Value);
                if (codBarra != dtoMatMed.Idt.Value.ToString())
                    txtCodBarra.Text = codBarra;
                else
                {
                    MessageBox.Show("CODIGO NAO ENCONTRADO", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodBarra.Text = string.Empty;
                    this.Cursor = Cursors.Default;
                    return;
                }
            }

            this.Cursor = Cursors.Default;
        }
    }
}