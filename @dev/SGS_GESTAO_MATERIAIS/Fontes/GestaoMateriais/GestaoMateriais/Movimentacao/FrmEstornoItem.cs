using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmEstornoItem : FrmBase
    {
        #region OBJETOS SERVIÇOS

        private const int ALMOX_CENTRAL = 29;
        private const int FARMACIA_CENTRAL = 2592;
        private const int HOTELARIA = 1372;

        private IMotivoPerda _motivoperda;
        private IMotivoPerda MotivoPerda
        {
            get { return _motivoperda != null ? _motivoperda : _motivoperda = (IMotivoPerda)Global.Common.GetObject(typeof(IMotivoPerda)); }
        }

        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }

        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }

        private IHistoricoNotaFiscal _histNF;
        private IHistoricoNotaFiscal HistoricoNotaFiscal
        {
            get { return _histNF != null ? _histNF : _histNF = (IHistoricoNotaFiscal)Global.Common.GetObject(typeof(IHistoricoNotaFiscal)); }
        }        

        #endregion

        public FrmEstornoItem()
        {
            InitializeComponent();
        }

        private void CarregarProduto()
        {
            if (dtoMatMed == null)
            {
                MessageBox.Show("Material/Medicamento não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtoMatMed = null;
                txtDsProduto.Text = string.Empty;
                txtIdProduto.Focus();
            }
            else if (dtoMatMed.FlAtivo.Value == 0)
            {
                MessageBox.Show("Material/Medicamento Inativo", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtoMatMed = null;
                txtDsProduto.Text = string.Empty;
                txtIdProduto.Focus();
            }
            else
            {
                txtDsProduto.Text = dtoMatMed.NomeFantasia.Value;

                if ((int)dtoMatMed.IdtGrupo.Value == 1)
                {
                    lblNumLote.Visible = lblValidade.Visible = true;

                    HistoricoNotaFiscalDTO dtoHistNF = new HistoricoNotaFiscalDTO();
                    dtoHistNF.IdtProduto.Value = dtoMatMed.Idt.Value;
                    dtoHistNF.IdtLote.Value = dtoMatMed.IdtLote.Value;
                    dtoHistNF.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;

                    HistoricoNotaFiscalDataTable dtbHNF = HistoricoNotaFiscal.Sel(dtoHistNF);
                    if (dtbHNF.Rows.Count > 0)
                    {
                        lblNumLote.Text = dtbHNF.TypedRow(0).NumLote.Value;
                        if (!dtbHNF.TypedRow(0).DataValidadeProduto.Value.IsNull)
                            lblValidade.Text = DateTime.Parse(dtbHNF.TypedRow(0).DataValidadeProduto.Value).ToString("dd/MM/yy");
                    }
                }
                else
                    lblNumLote.Visible = lblValidade.Visible = false;
            }            

            txtIdProduto.Text = string.Empty;
            txtQtdTransf.Text = "1";
            txtQtdTransf.Focus();
        }

        private bool Salvar()
        {
            if (dtoMatMed == null)
            {
                MessageBox.Show("Selecione o Mat/Med", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!grbDevolver.Visible && lblDevHotelaria.Visible)
            {
                if ((int)dtoMatMed.IdtGrupo.Value != 44)
                {
                    MessageBox.Show("Permitido devolução apenas de Uniformes para Hotelaria", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            if (int.Parse(txtQtdTransf.Text) <= 0)
            {
                MessageBox.Show("Qtd. deve ser maior que 0", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                MovimentacaoDTO dtoMov = new MovimentacaoDTO();
                dtoMov.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                dtoMov.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                dtoMov.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                dtoMov.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                dtoMov.IdtProduto.Value = dtoMatMed.Idt.Value;
                if ((int)dtoMatMed.IdtGrupo.Value == 1)
                    dtoMov.IdtLote.Value = dtoMatMed.IdtLote.Value;

                dtoMov.Qtde.Value = txtQtdTransf.Text;
                dtoMov.IdtUsuarioEstorno.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                dtoMov.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                dtoMov.IdtTipo.Value = (byte)MovimentacaoDTO.TipoMovimento.ENTRADA;
                dtoMov.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.DEVOLUCAO_SETOR_SEM_PEDIDO;

                if (cmbMotivo.SelectedIndex != -1) dtoMov.idtMotivo.Value = cmbMotivo.SelectedValue.ToString();

                Movimento.EntradaProduto(dtoMov);

                bool efetuarTransferencia = true;
                if (lblDevHotelaria.Visible &&
                    int.Parse(cmbSetor.SelectedValue.ToString()) == HOTELARIA)
                    efetuarTransferencia = false;

                if (efetuarTransferencia)
                {
                    //Realizar processo de Transferência
                    dtoMov = new MovimentacaoDTO();

                    // unidade de baixa
                    dtoMov.IdtUnidadeBaixa.Value = cmbUnidade.SelectedValue.ToString();
                    dtoMov.IdtLocalBaixa.Value = cmbLocal.SelectedValue.ToString();
                    dtoMov.IdtSetorBaixa.Value = cmbSetor.SelectedValue.ToString();

                    // unidade de entrada
                    dtoMov.IdtUnidade.Value = 244; //SANTOS
                    dtoMov.IdtLocal.Value = 33; //ADM
                    if (grbDevolver.Visible)
                    {
                        if (rbDevAlmox.Checked)
                            dtoMov.IdtSetor.Value = ALMOX_CENTRAL;
                        else
                            dtoMov.IdtSetor.Value = FARMACIA_CENTRAL;
                    }
                    else if (lblDevHotelaria.Visible)
                        dtoMov.IdtSetor.Value = HOTELARIA;
                    else
                    {
                        MessageBox.Show("DESTINO NÃO INFORMADO", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    dtoMov.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;

                    dtoMov.IdtProduto.Value = dtoMatMed.Idt.Value;
                    if ((int)dtoMatMed.IdtGrupo.Value == 1)
                        dtoMov.IdtLote.Value = dtoMatMed.IdtLote.Value;

                    dtoMov.Qtde.Value = txtQtdTransf.Text;

                    dtoMov.IdtTipo.Value = (byte)MovimentacaoDTO.TipoMovimento.ENTRADA;
                    dtoMov.IdtTipoBaixa.Value = (byte)MovimentacaoDTO.TipoMovimento.SAIDA;
                    dtoMov.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.TRANSFERENCIA_ENTRADA;
                    dtoMov.IdtSubTipoBaixa.Value = (byte)MovimentacaoDTO.SubTipoMovimento.TRANSFERENCIA_SAIDA;
                    dtoMov.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                    Movimento.TransfereEstoqueProduto(dtoMov);
                }

                tsHac_CancelarClick(null);                

                txtIdProduto.Text = txtDsProduto.Text = string.Empty;
                cmbMotivo.IniciaLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                return false;
            } 
            this.Cursor = Cursors.Default;
            MessageBox.Show("Devolução registrada com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }


        private void FrmEstornoItem_Load(object sender, EventArgs e)
        {            
            cmbMotivo.DisplayMember = MotivoPerdaDTO.FieldNames.DsMotivo;
            cmbMotivo.ValueMember = MotivoPerdaDTO.FieldNames.idtMotivo;
            cmbMotivo.DataSource = MotivoPerda.Sel(new MotivoPerdaDTO(), "1");
            cmbMotivo.IniciaLista();

            cmbUnidade.Carregaunidade();
            cmbUnidade.SelectedValue = 244; //SANTOS
            cmbLocal.SelectedValue = 29; //INTERNADO
            
            if (FrmPrincipal.dtoSeguranca.IdtSetor.Value == HOTELARIA)
            {
                grbDevolver.Visible = false;
                lblDevHotelaria.Visible = true;
                tsHac.MatMedVisivel = true;
                cmbMotivo.Enabled = false;
                cmbMotivo.Editavel = ControleEdicao.Nunca;
            }
            else
                lblDevHotelaria.Visible = false;
        }

        private void txtIdProduto_Validating(object sender, CancelEventArgs e)
        {
            if (txtIdProduto.Text != string.Empty)
            {
                this.Cursor = Cursors.WaitCursor;
                CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();

                dtoCodigoBarra.CdBarra.Value = txtIdProduto.Text;
                // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
                dtoMatMed = MatMed.BuscaCodigoBarra(dtoCodigoBarra);

                this.CarregarProduto();
                this.Cursor = Cursors.Default;
            }
        }

        private void txtQtdTransf_Enter(object sender, EventArgs e)
        {
            txtQtdTransf.SelectAll();
        }

        private bool tsHac_NovoClick(object sender)
        {
            tsHac_CancelarClick(sender);            
            return true;
        }

        private bool tsHac_AfterNovo(object sender)
        {
            txtIdProduto.Focus();
            return true;
        }

        private bool tsHac_CancelarClick(object sender)
        {
            dtoMatMed = null;            
            lblNumLote.Text = lblValidade.Text = string.Empty;
            txtQtdTransf.Text = "1";
            return true;
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
            tsHac_NovoClick(sender);
        }

        private bool tsHac_SalvarClick(object sender)
        {
            this.Salvar();

            txtIdProduto.Text = string.Empty;
            txtIdProduto.Focus();

            return false;
        }

        private bool tsHac_MatMedClick(object sender)
        {
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
    }
}