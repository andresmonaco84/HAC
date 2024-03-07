using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.GestaoMateriais.Componentes;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmEmprestimo : FrmBase
    {
        #region OBJETOS SERVIÇOS

        private const int idUnidadeAdm = 244;
        private const int idLocalAdm = 33;
        private const int idSetorAlmox = 29;
        private const int idSetorFarm = 2592;
        
        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }
        
        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject(typeof(IEstoqueLocal)); }
        }

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
        
        private IFilialMatMed _filialMatMed;
        private IFilialMatMed FilialMatMed
        {
            get { return _filialMatMed != null ? _filialMatMed : _filialMatMed = (IFilialMatMed)Global.Common.GetObject(typeof(IFilialMatMed)); }
        }

        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }

        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        #endregion

        #region FUNÇÕES

        public FrmEmprestimo()
        {
            InitializeComponent();
        }

        private void AtualizarQtdEstoque()
        {
            txtSaldoAlmox.Text = string.Empty;

            if (dtoMatMed == null) return;

            this.Cursor = Cursors.WaitCursor;

            EstoqueLocalDTO dtoEstoqueOrigem = new EstoqueLocalDTO();

            dtoEstoqueOrigem.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            dtoEstoqueOrigem.IdtUnidade.Value = idUnidadeAdm;
            dtoEstoqueOrigem.IdtLocal.Value = idLocalAdm;
            dtoEstoqueOrigem.IdtSetor.Value = rbAlmox.Checked ? idSetorAlmox : idSetorFarm;
            dtoEstoqueOrigem.IdtProduto.Value = dtoMatMed.Idt.Value;

            if ((int)dtoMatMed.IdtGrupo.Value == 1 && !dtoMatMed.IdtLote.Value.IsNull) //MEDICAMENTO
                dtoEstoqueOrigem.IdtLote.Value = dtoMatMed.IdtLote.Value;

            dtoEstoqueOrigem = Estoque.EstoqueLocalProduto(dtoEstoqueOrigem);

            if ((int)dtoMatMed.IdtGrupo.Value == 1 && !dtoMatMed.IdtLote.Value.IsNull) //MEDICAMENTO
                txtSaldoAlmox.Text = dtoEstoqueOrigem.QtdeLote.Value.ToString();
            else
                txtSaldoAlmox.Text = dtoEstoqueOrigem.Qtde.Value.ToString();

            this.Cursor = Cursors.Default;
        }

        private void CarregarEmpresas()
        {
            cmbEmpresa.DisplayMember = "CAD_MTMD_EMP_DESCRICAO";
            cmbEmpresa.ValueMember = "CAD_MTMD_ID_EMP_EMPRESTIMO";
            cmbEmpresa.DataSource = FilialMatMed.ObterEmpresaEmprestimo(null);
            cmbEmpresa.IniciaLista();
        }

        private void DesativarSaidaEntradaProduto()
        {
            txtCodBarra.Text = txtNumLoteFab.Text = txtValidade.Text = string.Empty;
            txtCodBarra.Enabled = false;
        }

        private void AtivarSaidaProduto(bool ativar)
        {
            LimparProduto();

            txtCodBarra.Text = string.Empty;
            txtCodBarra.Enabled = ativar;

            if (ativar)
            {
                txtIdProduto.Enabled = false;
                if (cmbEmpresa.SelectedIndex > -1)
                    txtCodBarra.Focus();
            }
            else
            {
                txtIdProduto.Enabled = true;
                if (cmbEmpresa.SelectedIndex > -1)
                    txtIdProduto.Focus();
            }
            if (cmbEmpresa.SelectedIndex == -1 || string.IsNullOrEmpty(cmbEmpresa.Text))
                cmbEmpresa.Focus();
        }

        private void LimparLote()
        {
            lblCodLote.Text = lblNumLoteFab.Text = lblValidade.Text = "--";
            lblCodLote.Visible = lblNumLoteFab.Visible = lblValidade.Visible = true;            
        }

        private void LimparProduto()
        {
            dtoMatMed = null;
            txtIdProduto.Text = txtDsProduto.Text = txtSaldoAlmox.Text = txtNumLoteFab.Text = txtValidade.Text = string.Empty;
            rbMedicamento.Checked = rbMaterial.Checked = false;
            grbEntradaProduto.Visible = btnRegistrarMov.Enabled = false;            
            SelecionarEstoque();
            LimparLote();
        }

        private void SelecionarEstoque()
        {
            rbAlmox.Enabled = rbFarm.Enabled = true;
            if (new Generico().LogadoSetorFarmacia())
                rbFarm.Checked = true;
            else
                rbAlmox.Checked = true; 
        }


        private void BuscarProduto()
        {
            this.Cursor = Cursors.WaitCursor;
            dtoMatMed = new MaterialMedicamentoDTO();
            dtoMatMed.Idt.Value = txtIdProduto.Text;
            dtoMatMed = MatMed.SelChave(dtoMatMed);

            if (dtoMatMed == null || dtoMatMed.Idt.Value.IsNull)
            {
                MessageBox.Show("Material/medicamento não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtoMatMed = null;
                LimparProduto();
                txtIdProduto.Focus();
                this.Cursor = Cursors.Default;
                return;
            }
            else
            {
                CarregarDadosProduto(false);
            }
            this.Cursor = Cursors.Default;
        }

        private void CarregarDadosProduto(bool baixa)
        {
            LimparLote();
            txtDsProduto.Text = dtoMatMed.NomeFantasia.Value;            

            if (!baixa && !dtoMatMed.IdtGrupo.Value.IsNull && (int)dtoMatMed.IdtGrupo.Value == 1)
            {
                MessageBox.Show("Digite o lote do medicamento para registrar a entrada.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rbMedicamento.Checked = true;
                grbEntradaProduto.Visible = true;
                txtNumLoteFab.Enabled = txtValidade.Enabled = true;
                txtNumLoteFab.Focus();
            }
            else if (!baixa)
            {
                rbMaterial.Checked = true;
                grbEntradaProduto.Visible = false;
                txtQtde.Focus();
            }

            if (baixa)
            {                
                if (!dtoMatMed.IdtGrupo.Value.IsNull && (int)dtoMatMed.IdtGrupo.Value == 1)
                {
                    rbMedicamento.Checked = true;
                    if (!dtoMatMed.IdtLote.Value.IsNull)
                        CarregarDadosLote((decimal)dtoMatMed.IdtLote.Value);
                }
                else
                    rbMaterial.Checked = true;

                txtCodBarra.Text = string.Empty;
            }

            AtualizarQtdEstoque();
            btnRegistrarMov.Enabled = true;
        }

        private void CarregarDadosLote(decimal? idLote)
        {
            if (dtoMatMed != null && idLote != null)
            {
                this.Cursor = Cursors.WaitCursor;
                HistoricoNotaFiscalDTO dtoHistNF = new HistoricoNotaFiscalDTO();

                dtoHistNF.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
                dtoHistNF.IdtProduto.Value = dtoMatMed.Idt.Value;
                dtoHistNF.IdtLote.Value = idLote.Value;                

                HistoricoNotaFiscalDataTable dtbHistNF = HistoricoNotaFiscal.Sel(dtoHistNF);

                if (dtbHistNF.Rows.Count > 0)
                {
                    dtoHistNF = dtbHistNF.TypedRow(0);

                    lblCodLote.Text = dtoHistNF.CodLote.Value;
                    lblNumLoteFab.Text = dtoHistNF.NumLote.Value;
                    if (!dtoHistNF.DataValidadeProduto.Value.IsNull)
                        lblValidade.Text = DateTime.Parse(dtoHistNF.DataValidadeProduto.Value).ToString("dd/MM/yy");
                }

                this.Cursor = Cursors.Default;
            }
        }

        private bool RegistrarMovimento()
        {
            this.Cursor = Cursors.WaitCursor;
            if (rbSaidaConcedido.Checked || rbSaidaDevolucao.Checked)
            {
                MovimentacaoDTO dtoMovimento = new MovimentacaoDTO();

                dtoMovimento.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
                dtoMovimento.IdtUnidade.Value = idUnidadeAdm;
                dtoMovimento.IdtLocal.Value = idLocalAdm;                
                dtoMovimento.IdtSetor.Value = rbAlmox.Checked ? idSetorAlmox : idSetorFarm;
                dtoMovimento.Qtde.Value = txtQtde.Text;

                dtoMovimento.IdtTipo.Value = (byte)MovimentacaoDTO.TipoMovimento.SAIDA;
                if (rbSaidaConcedido.Checked)
                    dtoMovimento.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_EMPRESTIMO_CONCEDIDO;
                else if (rbSaidaDevolucao.Checked)
                    dtoMovimento.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_EMPRESTIMO_DEVOLVIDO;

                dtoMovimento.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                if ((int)dtoMatMed.IdtGrupo.Value == 1) //MEDICAMENTO
                {
                    if (!dtoMatMed.IdtLote.Value.IsNull && (decimal)dtoMatMed.IdtLote.Value != 0)
                        dtoMovimento.IdtLote.Value = dtoMatMed.IdtLote.Value;
                    else
                    {
                        MessageBox.Show("Lote do medicamento não carregado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Cursor = Cursors.Default;
                        return false;
                    }
                }

                try
                {   
                    dtoMovimento = Movimento.MovimentaEstoqueProduto(dtoMovimento, dtoMatMed, null);

                    if (!dtoMovimento.Idt.Value.IsNull)
                        Movimento.AtualizarEmpresaEmprestimo(decimal.Parse(cmbEmpresa.SelectedValue.ToString()), (decimal)dtoMovimento.Idt.Value);

                    MessageBox.Show("Movimento registrado com sucesso.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    return false;
                }           
            }
            else //Entrada
            {                
                HistoricoNotaFiscalDTO dtoHNF = new HistoricoNotaFiscalDTO();

                if (rbEntradaObtido.Checked)
                    dtoHNF.TpMovimento.Value = ((int)MovimentacaoDTO.SubTipoMovimento.ENTRADA_EMPRESTIMO_OBTIDO).ToString();
                else if (rbEntradaDevolucao.Checked)
                    dtoHNF.TpMovimento.Value = ((int)MovimentacaoDTO.SubTipoMovimento.ENTRADA_EMPRESTIMO_DEVOLVIDO).ToString();

                dtoHNF.IdtFilial.Value = cmbEmpresa.SelectedValue.ToString();
                dtoHNF.IdtProduto.Value = dtoMatMed.Idt.Value;
                dtoHNF.NumLote.Value = txtNumLoteFab.Text;
                dtoHNF.DataValidadeProduto.Value = txtValidade.Text;
                dtoHNF.Qtde.Value = txtQtde.Text;

                CodigoBarraDataTable dtbCdBarra = CodigoBarra.SelMedicamentoSemNF(dtoHNF, 
                                                                                  (decimal)FrmPrincipal.dtoSeguranca.Idt.Value,
                                                                                  rbAlmox.Checked ? idSetorAlmox : idSetorFarm);

                if (dtbCdBarra.Rows.Count > 0)
                    MessageBox.Show("Movimento registrado com sucesso.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Houve algum problema ao registrar movimento.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    return false;
                }                
                
            }
            this.Cursor = Cursors.Default;
            return true;
        }
        
        #endregion

        #region EVENTOS

        private void FrmEmprestimo_Load(object sender, EventArgs e)
        {
            grbEntradaProduto.Visible = btnRegistrarMov.Enabled = false;
            CarregarEmpresas();            
        }

        private bool tsHac_NovoClick(object sender)
        {
            txtDescricaoNovaEmpresa.Visible = btnSalvar.Visible = false;
            grbEmprestimo.Enabled = cmbEmpresa.Enabled = txtIdProduto.Enabled = txtQtde.Enabled = rbAlmox.Enabled = rbFarm.Enabled = true;
            SelecionarEstoque();
            return true;
        }

        private bool tsHac_CancelarClick(object sender)
        {
            tsHac_NovoClick(null);
            return true;
        }

        private void tsHac_AfterCancelar(object sender)
        {
            LimparProduto();
            DesativarSaidaEntradaProduto();            
        }

        private bool tsHac_MatMedClick(object sender)
        {
            if (!rbSaidaConcedido.Checked && !rbEntradaDevolucao.Checked && !rbEntradaObtido.Checked && !rbSaidaDevolucao.Checked) return false;
            if (txtCodBarra.Enabled)
            {
                MessageBox.Show("Necessário passar cód. barra para identificar produto.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                dtoMatMed = new MaterialMedicamentoDTO();

                dtoMatMed.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.SEM_ESTOQUE;
                dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMed);                

                if (dtoMatMed != null)
                {
                    txtIdProduto.Text = dtoMatMed.Idt.Value;
                    BuscarProduto();
                    //txtQtde.Focus();
                }
                else
                    txtIdProduto.Text = txtDsProduto.Text = string.Empty;

                return true;
            }            
        }

        private void txtNumLoteFab_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNumLoteFab.Text))
                txtValidade.Focus();
        }

        private void txtValidade_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtValidade.Text))
                txtQtde.Focus();
        }

        private void txtIdProduto_Validating(object sender, CancelEventArgs e)
        {
            if (!rbSaidaConcedido.Checked && !rbEntradaDevolucao.Checked && !rbEntradaObtido.Checked && !rbSaidaDevolucao.Checked)
            {
                if (txtIdProduto.Text != string.Empty || dtoMatMed != null)
                {
                    MessageBox.Show("Selecione o tipo de movimento antes de carregar produto.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimparProduto();
                    grbEmprestimo.Focus();
                }
                return;
            }
            if (txtIdProduto.Text != string.Empty)
            {
                BuscarProduto();
            }
            else
            {
                LimparProduto();
            }
        }

        private void txtCodBarra_Validating(object sender, CancelEventArgs e)
        {
            if (txtCodBarra.Text != string.Empty)
            {
                this.Cursor = Cursors.WaitCursor;
                CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();

                dtoCodigoBarra.CdBarra.Value = txtCodBarra.Text;
                dtoCodigoBarra.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;

                // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
                dtoMatMed = MatMed.BuscaCodigoBarra(dtoCodigoBarra);

                if (dtoMatMed == null)
                {
                    MessageBox.Show("Material/medicamento não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtoMatMed = null;
                    LimparProduto();
                    txtIdProduto.Focus();
                    this.Cursor = Cursors.Default;
                    return;
                }
                else
                {
                    CarregarDadosProduto(true);
                }
                this.Cursor = Cursors.Default;
            }      
        }

        private void cmbEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbEmpresa.SelectedIndex > -1)
            {
                if (rbSaidaConcedido.Checked || rbSaidaDevolucao.Checked)
                    txtCodBarra.Focus();
                else if (rbEntradaObtido.Checked || rbEntradaDevolucao.Checked)
                    txtIdProduto.Focus();
            }
        }

        private void rbMaterial_Click(object sender, EventArgs e) {}

        private void rbMedicamento_Click(object sender, EventArgs e) {}

        private void rbSaidaConcedido_Click(object sender, EventArgs e)
        {
            if (rbSaidaConcedido.Checked || rbEntradaDevolucao.Checked)
                rbEntradaObtido.Checked = rbSaidaDevolucao.Checked = false;

            if (!tsHac.Items["tsBtnNovo"].Enabled)
                AtivarSaidaProduto(true);
        }

        private void rbEntradaDevolucao_Click(object sender, EventArgs e)
        {
            if (rbSaidaConcedido.Checked || rbEntradaDevolucao.Checked)
                rbEntradaObtido.Checked = rbSaidaDevolucao.Checked = false;

            if (!tsHac.Items["tsBtnNovo"].Enabled)
                AtivarSaidaProduto(false);
        }

        private void rbEntradaObtido_Click(object sender, EventArgs e)
        {
            if (rbEntradaObtido.Checked || rbSaidaDevolucao.Checked)
                rbSaidaConcedido.Checked = rbEntradaDevolucao.Checked = false;

            if (!tsHac.Items["tsBtnNovo"].Enabled)
                AtivarSaidaProduto(false);
        }

        private void rbSaidaDevolucao_Click(object sender, EventArgs e)
        {
            if (rbEntradaObtido.Checked || rbSaidaDevolucao.Checked)
                rbSaidaConcedido.Checked = rbEntradaDevolucao.Checked = false;

            if (!tsHac.Items["tsBtnNovo"].Enabled)
                AtivarSaidaProduto(true);
        }

        private void rbAlmox_Click(object sender, EventArgs e)
        {
            AtualizarQtdEstoque();
            txtQtde.Focus();
        }

        private void rbFarm_Click(object sender, EventArgs e)
        {
            AtualizarQtdEstoque();
            txtQtde.Focus();
        }

        private void btnRegistrarMov_Click(object sender, EventArgs e)
        {
            #region VALIDAÇÕES

            if (!rbSaidaConcedido.Checked && !rbEntradaDevolucao.Checked && !rbEntradaObtido.Checked && !rbSaidaDevolucao.Checked)
            {
                MessageBox.Show("Selecione o tipo de movimento.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cmbEmpresa.SelectedIndex == -1 || string.IsNullOrEmpty(cmbEmpresa.Text))
            {
                MessageBox.Show("Selecione a Empresa.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbEmpresa.Focus();
                return;
            }
            if (dtoMatMed == null || dtoMatMed.Idt.Value.IsNull)
            {
                MessageBox.Show("Produto não carregado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(txtQtde.Text))
            {
                MessageBox.Show("Digite a Quantidade.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtQtde.Focus();
                return;
            }
            else if (int.Parse(txtQtde.Text) == 0)
            {
                MessageBox.Show("Quantidade tem que ser maior que 0.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtQtde.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSaldoAlmox.Text)) txtSaldoAlmox.Text = "0";

            if (rbSaidaConcedido.Checked || rbSaidaDevolucao.Checked)
            {
                if (int.Parse(txtQtde.Text) > int.Parse(txtSaldoAlmox.Text))
                {
                    MessageBox.Show("Saldo insuficiente para baixa.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else if (grbEntradaProduto.Visible)
            {
                if (txtNumLoteFab.Text.Length == 0)
                {
                    MessageBox.Show("Digite o N° Lote Fab.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNumLoteFab.Focus();
                    return;
                }
                if (txtValidade.Text == string.Empty)
                {
                    MessageBox.Show("Digite a Data de Validade", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtValidade.Focus();
                    return;
                }
                try
                {
                    if (Convert.ToDateTime(txtValidade.Text) < Utilitario.ObterDataHoraServidor().Date)
                    {
                        MessageBox.Show("Medicamento não pode estar vencido.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtValidade.Focus();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Data Validade inválida.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            #endregion

            if (MessageBox.Show("Confirma o registro deste empréstimo ?",
                                "Gestão de Materiais e Medicamentos",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (RegistrarMovimento())
                {
                    AtualizarQtdEstoque();
                    tsHac.Items["tsBtnNovo"].Enabled = true;
                    btnRegistrarMov.Enabled = tsHac.Items["tsBtnCancelar"].Enabled = tsHac.Items["tsBtnMatMed"].Enabled = 
                    grbEmprestimo.Enabled = cmbEmpresa.Enabled = txtIdProduto.Enabled = txtQtde.Enabled = rbAlmox.Enabled = rbFarm.Enabled = false;
                }
            }
        }

        private void btnNovaEmpresa_Click(object sender, EventArgs e)
        {
            if (cmbEmpresa.Enabled)
            {
                txtDescricaoNovaEmpresa.Text = string.Empty;
                txtDescricaoNovaEmpresa.Visible = btnSalvar.Visible = btnSalvar.Enabled = true;
                txtDescricaoNovaEmpresa.Focus();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtDescricaoNovaEmpresa.Text.Trim().Length == 0)
            {
                txtDescricaoNovaEmpresa.Visible = btnSalvar.Visible = false;
                cmbEmpresa.Focus();
                return;
            }
            
            DataTable dtb = FilialMatMed.ObterEmpresaEmprestimo(null);
            DataView dv = dtb.DefaultView;
            dv.RowFilter = string.Format("CAD_MTMD_EMP_DESCRICAO='{0}'", txtDescricaoNovaEmpresa.Text);
            dtb = dv.ToTable();
            if (dtb.Rows.Count > 0)
            {
                MessageBox.Show("Já existe uma empresa com essa descrição.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            cmbEmpresa.DataSource = FilialMatMed.InserirEmpresaEmprestimo(txtDescricaoNovaEmpresa.Text, string.Empty);
            cmbEmpresa.IniciaLista();
            txtDescricaoNovaEmpresa.Text = string.Empty;
            txtDescricaoNovaEmpresa.Visible = btnSalvar.Visible = false;
            cmbEmpresa.Focus();
        }

        #endregion
    }
}