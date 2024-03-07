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
    public partial class FrmDevolucaoConsig : FrmBase
    {
        public FrmDevolucaoConsig()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇOS

        //private ICodigoBarra _codigoBarra;
        //private ICodigoBarra CodigoBarra
        //{
        //    get { return _codigoBarra != null ? _codigoBarra : _codigoBarra = (ICodigoBarra)Global.Common.GetObject(typeof(ICodigoBarra)); }
        //}

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

        // Movimento
        private MovimentacaoDTO dtoMovimento = new MovimentacaoDTO();
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }

        #endregion

        private void ConfiguraEstoqueDTO()
        {
            dtoEstoque = new EstoqueLocalDTO();

            dtoEstoque.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoEstoque.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoEstoque.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoEstoque.IdtProduto.Value = dtoMatMed.Idt.Value;
            dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.CONSIGNADO;
        }

        private void ConfigurarMovimentoDTO()
        {
            if (dtoMovimento == null) dtoMovimento = new MovimentacaoDTO();
            if (cmbUnidade.SelectedIndex != -1) dtoMovimento.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            if (cmbLocal.SelectedIndex != -1) dtoMovimento.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            if (cmbSetor.SelectedIndex != -1) dtoMovimento.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            //if (cmbMotivoPerda.SelectedIndex != -1) dtoMovimento.idtMotivo.Value = cmbMotivoPerda.SelectedValue.ToString();

            dtoMovimento.IdtFilial.Value = (int)FilialMatMedDTO.Filial.CONSIGNADO;            

            if (txtQtdDev.Text != string.Empty) dtoMovimento.Qtde.Value = txtQtdDev.Text;
            
            dtoMovimento.Obs.Value = txtFornecedor.Text.ToUpper();

            dtoMovimento.IdtTipo.Value = (byte)MovimentacaoDTO.TipoMovimento.SAIDA;
            dtoMovimento.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.DEVOLUCAO_CONSIGNADO_FORNECEDOR;
        }

        private bool Validar()
        {
            if (dtoMatMed == null)
            {
                MessageBox.Show("Selecione o Produto", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if ((int)dtoMatMed.IdtGrupo.Value == 1)
            {
                MessageBox.Show("Não permitido devolver Medicamento por esta funcionalidade", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtQtdEstoque.Text == string.Empty) txtQtdEstoque.Text = "0";
            if (decimal.Parse(txtQtdDev.Text) > decimal.Parse(txtQtdEstoque.Text))
            {
                MessageBox.Show("Qtd. Devolução não pode maior à Qtd. Estoque", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (int.Parse(txtQtdEstoque.Text) <= 0)
            {
                MessageBox.Show("Qtd. Devolução deve ser maior que 0", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(txtFornecedor.Text))
            {
                MessageBox.Show("Digite o Fornecedor", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFornecedor.Focus();
                return false;
            }

            return true;
        }

        private void AtualizarQtdEstoques()
        {
            txtQtdEstoque.Text = string.Empty;
            if (dtoMatMed != null)
            {
                this.Cursor = Cursors.WaitCursor;

                this.ConfiguraEstoqueDTO();

                txtQtdEstoque.Text = "0";                

                dtoEstoque = Estoque.EstoqueLocalProduto(dtoEstoque);

                if (!dtoEstoque.Qtde.Value.IsNull) txtQtdEstoque.Text = dtoEstoque.Qtde.Value.ToString();
                
                this.Cursor = Cursors.Default;
            }
        }

        private void CarregarProduto()
        {
            if (dtoMatMed == null)
            {
                MessageBox.Show("Material/Medicamento não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdProduto.Focus();
            }
            else if (dtoMatMed.FlAtivo.Value == 0)
            {
                MessageBox.Show("Material/Medicamento Inativo", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtoMatMed = null;
                txtIdProduto.Focus();
            }
            else
            {
                txtIdProduto.Text = dtoMatMed.Idt.Value;
                txtProdDsc.Text = dtoMatMed.NomeFantasia.Value;
                txtIdProduto.Enabled = false;
            }
            this.AtualizarQtdEstoques();

            //txtIdProduto.Text = string.Empty;
            txtQtdDev.Text = "1";
            txtQtdDev.Focus();
            txtQtdDev.Select();
        }

        private bool Salvar()
        {
            if (!this.Validar()) return false;
            try
            {
                ConfigurarMovimentoDTO();
                dtoMovimento.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                dtoMovimento = Movimento.MovimentaEstoqueProduto(dtoMovimento, dtoMatMed, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            this.AtualizarQtdEstoques();
            MessageBox.Show("Devolução registrada com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private void FrmDevolucaoConsig_Load(object sender, EventArgs e)
        {
            cmbUnidade.Enabled = cmbLocal.Enabled = cmbSetor.Enabled = false;
            cmbUnidade.Editavel = cmbLocal.Editavel = cmbSetor.Editavel = ControleEdicao.Nunca;
            cmbUnidade.Carregaunidade();
            cmbUnidade.SelectedValue = 244; //SANTOS
            cmbLocal.SelectedValue = 33; //ADM
            cmbSetor.SelectedValue = 29; //ALMOX CENTRAL
            if ((int)FrmPrincipal.dtoSeguranca.IdtSetor.Value != int.Parse(cmbSetor.SelectedValue.ToString()))
            {
                tsHac.Enabled = txtProdDsc.Enabled = false;
                MessageBox.Show("Necessário estar logado como Almoxarifado Central !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
            }
        }

        private bool tsHac_CancelarClick(object sender)
        {
            dtoMatMed = null;
            txtIdProduto.Enabled = true;
            return true;
        }

        private bool tsHac_NovoClick(object sender)
        {
            tsHac_CancelarClick(sender);
            txtIdProduto.Focus();
            return true;
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
                        return true;
                    }
                }
            }
            return false;
        }

        private void txtIdProduto_Validating(object sender, CancelEventArgs e)
        {
            if (txtIdProduto.Text != string.Empty)
            {
                txtProdDsc.Text = string.Empty;

                dtoMatMed = new MaterialMedicamentoDTO();
                try
                {
                    dtoMatMed.Idt.Value = txtIdProduto.Text;
                    dtoMatMed = MatMed.SelChave(dtoMatMed);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERRO AO BUSCAR ID/CODIGO: " + ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtoMatMed = null;
                    txtIdProduto.Text = string.Empty;
                    txtIdProduto.Focus();
                    return;
                }

                if (dtoMatMed == null || dtoMatMed.Idt.Value.IsNull)
                {
                    MessageBox.Show("Material/medicamento não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtoMatMed = null;
                    txtIdProduto.Text = string.Empty;
                    txtIdProduto.Focus();
                    return;
                }
                else
                {
                    this.CarregarProduto();
                }
            }
            else if (txtIdProduto.Text == string.Empty)
            {
                dtoMatMed = null;
                txtIdProduto.Text = txtProdDsc.Text = string.Empty;
                txtIdProduto.Focus();
            }
        }

        private bool tsHac_SalvarClick(object sender)
        {
            return this.Salvar();
        }              
    }
}