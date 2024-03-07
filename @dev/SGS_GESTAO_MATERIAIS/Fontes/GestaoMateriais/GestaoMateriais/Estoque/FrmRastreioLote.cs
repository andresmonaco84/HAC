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
using HospitalAnaCosta.SGS.GestaoMateriais;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    public partial class FrmRastreioLote : FrmBase
    {
        public FrmRastreioLote()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇOS

        // MatMed
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

        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject(typeof(IEstoqueLocal)); }
        }        

        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }

        private IPaciente _atendimento;
        private IPaciente Atendimento
        {
            get { return _atendimento != null ? _atendimento : _atendimento = (IPaciente)Global.Common.GetObject(typeof(IPaciente)); }
        }

        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        #endregion        

        #region MÉTODOS

        private void ConfiguraDTGs()
        {
            dtgMovimento.AutoGenerateColumns = dtgSaldos.AutoGenerateColumns = false;

            dtgSaldos.Columns[colDsUnidade.Name].DataPropertyName = UnidadeDTO.FieldNames.DsUnidade;
            dtgSaldos.Columns[colDsSetor.Name].DataPropertyName = SetorDTO.FieldNames.Descricao;
            dtgSaldos.Columns[colEstoqueFilial.Name].DataPropertyName = "ESTOQUE_FILIAL";
            dtgSaldos.Columns[colSaldo.Name].DataPropertyName = EstoqueLocalDTO.FieldNames.QtdeLote;

            dtgMovimento.Columns[colIdtMov.Name].DataPropertyName = MovimentacaoDTO.FieldNames.Idt;
            dtgMovimento.Columns[colDtMov.Name].DataPropertyName = MovimentacaoDTO.FieldNames.DataMovimento;
            dtgMovimento.Columns[colDtMov.Name].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dtgMovimento.Columns[colSetor.Name].DataPropertyName = "SETOR";
            dtgMovimento.Columns[colSubTipoMov.Name].DataPropertyName = MovimentacaoDTO.FieldNames.DsSubtipoMov;
            dtgMovimento.Columns[colTpMov.Name].DataPropertyName = "TPMOV";
            dtgMovimento.Columns[colQtdMov.Name].DataPropertyName = MovimentacaoDTO.FieldNames.Qtde;
            dtgMovimento.Columns[colSaldoLoteMov.Name].DataPropertyName = MovimentacaoDTO.FieldNames.SaldoLoteTotal;
            dtgMovimento.Columns[colCodLote.Name].DataPropertyName = MovimentacaoDTO.FieldNames.CodLote;
            dtgMovimento.Columns[colReqId.Name].DataPropertyName = MovimentacaoDTO.FieldNames.IdtRequisicao;
            dtgMovimento.Columns[colAtdAteId.Name].DataPropertyName = MovimentacaoDTO.FieldNames.IdtAtendimento;
            dtgMovimento.Columns[colFilial.Name].DataPropertyName = "ESTOQUE_FILIAL";
            dtgMovimento.Columns[colFlEstorno.Name].DataPropertyName = MovimentacaoDTO.FieldNames.FlEstornado;
            dtgMovimento.Columns[colIdtTpMov.Name].DataPropertyName = MovimentacaoDTO.FieldNames.IdtTipo;
            dtgMovimento.Columns[colIdtSubMov.Name].DataPropertyName = MovimentacaoDTO.FieldNames.IdtSubTipo;
            dtgMovimento.Columns[colUsuarioMov.Name].DataPropertyName = MovimentacaoDTO.FieldNames.DsUsuario;
        }

        private bool ValidarPeriodo()
        {
            if (txtInicio.Text != string.Empty || txtFim.Text != string.Empty)
            {
                if (txtInicio.Text == string.Empty || txtFim.Text == string.Empty)
                {
                    MessageBox.Show("Inicio/Fim obrigatórios caso preenchido um dos dois campos.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);                    
                    return false;
                }
                try
                {
                    if (Convert.ToDateTime(txtFim.Text).Date < Convert.ToDateTime(txtInicio.Text).Date)
                    {
                        MessageBox.Show("A Data Fim deve ser maior ou igual à Data Início.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtFim.Focus();
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show("Data inválida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private bool ValidarValidade()
        {            
            try
            {
                DateTime dtVal = Convert.ToDateTime(txtValidade.Text).Date;
            }
            catch
            {
                MessageBox.Show("Data Validade Inválida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValidade.Focus();
                return false;
            }
            return true;
        }

        private void CarregaInfoPaciente()
        {
            DataTable dtPaciente = Atendimento.ObterPaciente(decimal.Parse(txtNroInternacao.Text));
            if (dtPaciente.Rows.Count > 0)            
                txtNomePac.Text = dtPaciente.Rows[0][1].ToString();            
            else
                txtNomePac.Text = string.Empty;
        }

        private void CarregarDadosLote(decimal? idLote)
        {
            if (dtoMatMed != null && (!string.IsNullOrEmpty(txtCodLote.Text) || idLote != null))
            {
                this.Cursor = Cursors.WaitCursor;
                HistoricoNotaFiscalDTO dtoHistNF = new HistoricoNotaFiscalDTO();

                dtoHistNF.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
                dtoHistNF.IdtProduto.Value = dtoMatMed.Idt.Value;

                if (!string.IsNullOrEmpty(txtCodLote.Text))
                {
                    AjustarCaracteresCodLote();
                    dtoHistNF.CodLote.Value = txtCodLote.Text;
                }
                else if (idLote != null && idLote.Value != 0)                
                    dtoHistNF.IdtLote.Value = idLote.Value;                
                else if (string.IsNullOrEmpty(txtCodLote.Text) && (idLote != null && idLote.Value == 0))
                {
                    //MessageBox.Show("O Lote referente a este Código de Barra não tem Controle de Saldo!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MessageBox.Show("Código de Barra referente a um Lote sem Controle de Saldo!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Cursor = Cursors.Default;
                    txtIdProduto.Text = string.Empty;
                    txtIdProduto.Focus();
                    return;
                }
                
                HistoricoNotaFiscalDataTable dtbHistNF = HistoricoNotaFiscal.Sel(dtoHistNF);

                if (dtbHistNF.Rows.Count > 0)
                {
                    dtoHistNF = dtbHistNF.TypedRow(0);

                    txtCodLote.Text = dtoHistNF.CodLote.Value;
                    lblNumLoteFab.Text = dtoHistNF.NumLote.Value;
                    if (!dtoHistNF.DataValidadeProduto.Value.IsNull)
                        lblValidade.Text = DateTime.Parse(dtoHistNF.DataValidadeProduto.Value).ToString("dd/MM/yyyy");
                    lblCodFabricante.Text = dtbHistNF.Rows[0][MaterialMedicamentoDTO.FieldNames.CdFabricante].ToString();

                    EstoqueLocalDTO dtoEstoque = new EstoqueLocalDTO();
                    dtoEstoque.IdtProduto.Value = dtoMatMed.Idt.Value;
                    dtoEstoque.CodLote.Value = txtCodLote.Text;
                    dtgSaldos.DataSource = new DataView(Estoque.ListarEstoqueLote(dtoEstoque),
                                                        string.Format("{0} <> 'SEM_LOTE'", EstoqueLocalDTO.FieldNames.CodLote),
                                                        string.Empty,
                                                        DataViewRowState.CurrentRows).ToTable();
                    dtgMovimento.DataSource = null;
                    txtIdProduto.Text = string.Empty;
                    dtgMovimento.Focus();

                    if (dtgSaldos.RowCount == 0)
                        MessageBox.Show("Lote sem saldo no momento", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (!string.IsNullOrEmpty(txtCodLote.Text))
                {
                    MessageBox.Show("Lote não identificado ou sem controle para este medicamento!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtIdProduto.Text = string.Empty;
                    LimparLote();                    
                    txtCodLote.Focus();
                }

                this.Cursor = Cursors.Default;
            }
        }

        private void AjustarCaracteresCodLote()
        {
            if (!string.IsNullOrEmpty(txtCodLote.Text) && txtCodLote.Text.Length < 4)
                txtCodLote.Text = txtCodLote.Text.PadLeft(4, '0');
        }

        private void LimparItem()
        {
            dtoMatMed = null;
            btnLimparProduto.Visible = false;
            txtIdProduto.Text = string.Empty;
            lblProduto.Text = "--";
            LimparLote();
            txtIdProduto.Focus();
        }

        private void LimparLote()
        {
            txtCodLote.Text = string.Empty;
            lblCodFabricante.Text = lblNumLoteFab.Text = lblValidade.Text = "--";
            txtNumLote.Visible = txtValidade.Visible = false;
            lblNumLoteFab.Visible = lblValidade.Visible = true;
            dtgMovimento.DataSource = null;
            dtgSaldos.DataSource = null;
        }

        private bool ItemDispensado()
        {
            this.Cursor = Cursors.WaitCursor;
            MovimentacaoDTO dtoMov = new MovimentacaoDTO();
            dtoMov.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
            dtoMov.IdtProduto.Value = dtoMatMed.Idt.Value;
            dtoMov.CodLote.Value = txtCodLote.Text;            
            if (Movimento.ObterQtdLoteDispensado(dtoMov) > 0)
            {
                MessageBox.Show("Item já dispensado, não permitindo alteração do número deste Lote.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Cursor = Cursors.Default;
                return true;
            }
            this.Cursor = Cursors.Default;
            return false;
        }

        #endregion

        #region EVENTOS

        private void FrmRastreioLote_Load(object sender, EventArgs e)
        {            
            ConfiguraDTGs();
            tsHac_AfterCancelar(sender);
        }

        private void btnPesquisaPac_Click(object sender, EventArgs e)
        {
            if (txtNroInternacao.Enabled) CarregaInfoPaciente();
        }

        private void txtNroInternacao_Validating(object sender, CancelEventArgs e)
        {
            if (txtNroInternacao.Text.Length != 0)
                btnPesquisaPac_Click(sender, e);
            else
                txtNomePac.Text = string.Empty;
        }        

        private void txtIdProduto_Validating(object sender, CancelEventArgs e)
        {
            if (txtIdProduto.Text != string.Empty)
            {
                CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();

                dtoCodigoBarra.CdBarra.Value = txtIdProduto.Text;
                dtoCodigoBarra.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;

                // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
                dtoMatMed = MatMed.BuscaCodigoBarra(dtoCodigoBarra);

                if (dtoMatMed == null)
                {
                    MessageBox.Show("Medicamento não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimparItem();                    
                    txtIdProduto.Focus();
                    return;
                }
                else
                {
                    if (!dtoMatMed.IdtGrupo.Value.IsNull && (int)dtoMatMed.IdtGrupo.Value != 1)
                    {
                        MessageBox.Show("Permitido carregar apenas medicamento !", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LimparItem();                        
                        txtIdProduto.Focus();
                        return;
                    }
                }
                lblProduto.Text = string.Format("{0}", dtoMatMed.NomeFantasia.Value);
                LimparLote();
                if (!dtoMatMed.IdtLote.Value.IsNull)
                    CarregarDadosLote((decimal)dtoMatMed.IdtLote.Value);                    
            }            
        }        

        private void txtCodLote_Validating(object sender, CancelEventArgs e)
        {
            if (dtoMatMed == null && txtCodLote.Text != string.Empty)
            {
                MessageBox.Show("Medicamento é obrigatório !", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimparItem();
                txtIdProduto.Focus();
                return;
            }
            else if (txtCodLote.Text == string.Empty)
                LimparLote();
            else
                CarregarDadosLote(null);
        }

        private void txtNumLote_Validating(object sender, CancelEventArgs e)
        {
            if (dtoMatMed != null && txtCodLote.Text != string.Empty)
            {
                this.Cursor = Cursors.WaitCursor;

                if (txtNumLote.Text == string.Empty)
                    txtNumLote.Text = _numLoteEdit;
                else
                {
                    HistoricoNotaFiscalDTO dtoHistNF = new HistoricoNotaFiscalDTO();
                    dtoHistNF.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
                    dtoHistNF.IdtProduto.Value = dtoMatMed.Idt.Value;
                    dtoHistNF.CodLote.Value = txtCodLote.Text;
                    dtoHistNF.NumLote.Value = txtNumLote.Text;
                    HistoricoNotaFiscal.AtualizarNumeroLote(dtoHistNF);
                }

                txtNumLote.Visible = false;
                lblNumLoteFab.Visible = true;

                lblNumLoteFab.Text = txtNumLote.Text;
                dtgSaldos.Focus();
                _numLoteEdit = string.Empty;

                this.Cursor = Cursors.Default;
            }
            else if (txtNumLote.Text == string.Empty)
            {
                txtNumLote.Visible = false;
                lblNumLoteFab.Visible = true;
            }
        }

        private void txtValidade_Validating(object sender, CancelEventArgs e)
        {
            if (dtoMatMed != null && txtCodLote.Text != string.Empty && txtValidade.Text != string.Empty && ValidarValidade())
            {
                this.Cursor = Cursors.WaitCursor;
                
                HistoricoNotaFiscalDTO dtoHistNF = new HistoricoNotaFiscalDTO();
                dtoHistNF.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
                dtoHistNF.IdtProduto.Value = dtoMatMed.Idt.Value;
                dtoHistNF.CodLote.Value = txtCodLote.Text;
                dtoHistNF.DataValidadeProduto.Value = txtValidade.Text;
                HistoricoNotaFiscal.AtualizarValidadeLote(dtoHistNF);

                txtValidade.Visible = false;
                lblValidade.Visible = true;

                lblValidade.Text = txtValidade.Text;
                dtgSaldos.Focus();
                
                this.Cursor = Cursors.Default;
            }
            else if (txtValidade.Text == string.Empty)
            {
                txtValidade.Visible = false;
                lblValidade.Visible = true;
            }
        }

        private string _numLoteEdit;
        private void lblNumLoteFab_DoubleClick(object sender, EventArgs e)
        {   
            _numLoteEdit = string.Empty;
            if (dtoMatMed != null && txtCodLote.Text != string.Empty)
            {
                if (new Generico().VerificaAcessoFuncionalidade("AlteraValidadeLote"))
                {
                    if (!ItemDispensado())
                    {
                        lblNumLoteFab.Visible = false;
                        txtNumLote.Visible = true;
                        _numLoteEdit = txtNumLote.Text = lblNumLoteFab.Text;
                        txtNumLote.Focus();
                    }
                }
            }
        }

        private void lblValidade_DoubleClick(object sender, EventArgs e)
        {
            if (dtoMatMed != null && txtCodLote.Text != string.Empty)
            {
                if (new Generico().VerificaAcessoFuncionalidade("AlteraValidadeLote"))
                {
                    lblValidade.Visible = false;
                    txtValidade.Visible = true;
                    txtValidade.Text = lblValidade.Text;
                    txtValidade.Focus();
                }
            }            
        }

        private bool tsHac_MatMedClick(object sender)
        {
            MaterialMedicamentoDTO dtoMatMedAux = FrmPesquisaMatMed.SelecionaMatMed(new MaterialMedicamentoDTO());
            if (dtoMatMedAux == null)
                return false;
            
            if (!dtoMatMedAux.IdtGrupo.Value.IsNull && (int)dtoMatMedAux.IdtGrupo.Value != 1)
            {
                MessageBox.Show("Permitido carregar apenas medicamento !", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimparItem();
                return false;
            }

            dtoMatMed = dtoMatMedAux;
            //btnLimparProduto.Visible = true;
            lblProduto.Text = dtoMatMed.NomeFantasia.Value;            
            txtIdProduto.Text = string.Empty;
            LimparLote();
            txtCodLote.Focus();
            
            CarregarDadosLote(null);
            
            return true;
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            if (string.IsNullOrEmpty(txtNomePac.Text) && (dtoMatMed == null || txtCodLote.Text == string.Empty))
            {
                MessageBox.Show("Medicamento e Lote obrigatórios para a pesquisa", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!string.IsNullOrEmpty(txtNroInternacao.Text) && !string.IsNullOrEmpty(txtNomePac.Text) && dtoMatMed == null)
            {
                MessageBox.Show("Medicamento é obrigatório para a pesquisa quando informado o paciente", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (ValidarPeriodo())
            {
                dtgMovimento.Focus();
                if (dtoMatMed != null)
                {
                    MovimentacaoDTO dtoMov = new MovimentacaoDTO();

                    dtoMov.IdtProduto.Value = dtoMatMed.Idt.Value;

                    if (!string.IsNullOrEmpty(txtCodLote.Text))
                    {
                        AjustarCaracteresCodLote();
                        dtoMov.CodLote.Value = txtCodLote.Text;
                    }

                    if (txtInicio.Text != string.Empty && txtFim.Text != string.Empty)
                    {
                        dtoMov.DataMovimento.Value = txtInicio.Text;
                        dtoMov.DataAte.Value = txtFim.Text;
                    }

                    if (!string.IsNullOrEmpty(txtNroInternacao.Text) && !string.IsNullOrEmpty(txtNomePac.Text))
                        dtoMov.IdtAtendimento.Value = txtNroInternacao.Text;

                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        dtgMovimento.DataSource = Movimento.RastrearLoteProduto(dtoMov);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.Cursor = Cursors.Default;

                    return true;
                }
            }
            return false;
        }

        private bool tsHac_CancelarClick(object sender)
        {
            return true;
        }

        private void tsHac_AfterCancelar(object sender)
        {
            tsHac.Items["tsBtnMatMed"].Enabled = tsHac.Items["tsBtnCancelar"].Enabled = true;
            btnLimparProduto_Click(null, null);
            txtInicio.Text = Utilitario.ObterDataHoraServidor().AddDays(-60).ToString("dd/MM/yyyy");
            txtFim.Text = Utilitario.ObterDataHoraServidor().ToString("dd/MM/yyyy");
            txtIdProduto.Focus();
        }

        private void btnLimparProduto_Click(object sender, EventArgs e)
        {
            LimparItem();
        }
        
        #endregion        
    }
}