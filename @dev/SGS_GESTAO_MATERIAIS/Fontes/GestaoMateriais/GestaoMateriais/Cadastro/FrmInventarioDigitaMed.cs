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
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.Seguranca.Forms;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using System.IO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Cadastro
{
    public partial class FrmInventarioDigitaMed : FrmBase
    {
        #region OBJETOS SERVIÇOS

        private DateTime? _dataInicioInv = null;
        private int? _idGrupo = null;

        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }

        private InventarioMatMedDataTable dtbInventario;
        private InventarioMatMedDTO dtoInventario;
        private IInventarioMatMed _inventarioMatMed;
        private IInventarioMatMed InventarioMatMed
        {
            get { return _inventarioMatMed != null ? _inventarioMatMed : _inventarioMatMed = (IInventarioMatMed)Global.Common.GetObject(typeof(IInventarioMatMed)); }
        }

        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }

        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject(typeof(IEstoqueLocal)); }
        }

        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        private IMatMedSetorConfig _matMedConfig;
        private IMatMedSetorConfig MatMedSetorConfig
        {
            get { return _matMedConfig != null ? _matMedConfig : _matMedConfig = (IMatMedSetorConfig)Global.Common.GetObject(typeof(IMatMedSetorConfig)); }
        }

        private ICodigoBarra _codigoBarra;
        private ICodigoBarra CodigoBarra
        {
            get { return _codigoBarra != null ? _codigoBarra : _codigoBarra = (ICodigoBarra)Global.Common.GetObject(typeof(ICodigoBarra)); }
        }

        private ISetor _setor;
        private ISetor Setor
        {
            get { return _setor != null ? _setor : _setor = (ISetor)Global.Common.GetObject(typeof(ISetor)); }
        }

        private IHistoricoNotaFiscal _histNF;
        private IHistoricoNotaFiscal HistoricoNotaFiscal
        {
            get { return _histNF != null ? _histNF : _histNF = (IHistoricoNotaFiscal)Global.Common.GetObject(typeof(IHistoricoNotaFiscal)); }
        }        

        #endregion

        #region MÉTODOS

        public static void Carregar(InventarioMatMedDTO dto, SetorDTO dtoSetor)
        {
            FrmInventarioDigitaMed frmInvMed = new FrmInventarioDigitaMed();
            frmInvMed.cmbUnidade.Carregaunidade();
            frmInvMed.cmbUnidade.SelectedValue = dtoSetor.IdtUnidade.Value;
            frmInvMed.cmbLocal.SelectedValue = dtoSetor.IdtLocalAtendimento.Value;
            frmInvMed.cmbSetor.SelectedValue = dto.IdSetor.Value;
            frmInvMed.txtData.Text = DateTime.Parse(dto.DataInventario.Value.ToString()).ToString("dd/MM/yyyy");
            if ((int)dto.IdFilial.Value == (int)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA)
                frmInvMed.rbCE.Checked = true;
            else
                frmInvMed.rbHac.Checked = true;
            if (!dto.IdtGrupo.Value.IsNull)
                frmInvMed._idGrupo = (int)dto.IdtGrupo.Value;
            
            frmInvMed.ShowDialog();
        }

        public FrmInventarioDigitaMed()
        {
            InitializeComponent();
        }

        private void ConfigurarGrid()
        {
            dtgMatMed.AutoGenerateColumns = false;
            dtgMatMed.Columns[colDescricao.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.NomeFantasia;
            dtgMatMed.Columns[colIdt.Name].DataPropertyName = InventarioMatMedDTO.FieldNames.IdProduto;
            dtgMatMed.Columns[colCodLote.Name].DataPropertyName = InventarioMatMedDTO.FieldNames.CodLote;
            dtgMatMed.Columns[colNumFabLote.Name].DataPropertyName = InventarioMatMedDTO.FieldNames.NumLoteFab;
            dtgMatMed.Columns[colQtd.Name].DataPropertyName = InventarioMatMedDTO.FieldNames.QtdeFinal;
            dtgMatMed.Columns[colData.Name].DataPropertyName = InventarioMatMedDTO.FieldNames.DtAtualizacao;
        }

        private bool ValidarFilial(bool mostrarMensagem)
        {
            if (!rbHac.Checked && !rbCE.Checked)
            {
                if (mostrarMensagem) MessageBox.Show("Selecione o estoque (HAC/CE)", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private bool ValidarSetor(bool mostrarMensagem)
        {
            if (cmbSetor.SelectedIndex == -1 || string.IsNullOrEmpty(cmbSetor.Text))
            {
                if (mostrarMensagem) MessageBox.Show("Selecione o Setor", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private bool ValidarData(bool mostrarMensagem)
        {
            if (txtData.Text == string.Empty)
            {
                if (mostrarMensagem) MessageBox.Show("Data deve ser preenchida", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtData.Focus();
                return false;
            }
            DateTime dt;
            if (!DateTime.TryParse(txtData.Text, out dt))
            {
                if (mostrarMensagem) MessageBox.Show("Data inválida", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtData.Focus();
                return false;
            }
            return true;
        }

        private void CarregarItens()
        {
            this.Cursor = Cursors.WaitCursor;
            InventarioMatMedDTO dtoInv = new InventarioMatMedDTO();
            dtoInv.IdSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoInv.IdFilial.Value = new Generico().RetornaFilial(rbHac, new HacRadioButton(), rbCE);
            dtoInv.DataInventario.Value = DateTime.Parse(txtData.Text).Date;
            dtoInv.FlMedicamento.Value = 1;
            DataTable dtbItem = InventarioMatMed.Listar(dtoInv);
            if (dtoInventario.Fechamento.Value == 1 || dtoInventario.Fechamento.Value == 2)
            {
                DataView dvItens = new DataView(dtbItem, string.Format("{0} IS NOT NULL", dtoInventario.Fechamento.Value == 1 ? InventarioMatMedDTO.FieldNames.Qtde2 : InventarioMatMedDTO.FieldNames.Qtde3), string.Empty, DataViewRowState.CurrentRows);
                dtbItem = dvItens.ToTable();
            }
            dtgMatMed.DataSource = dtbItem;
            dtgMatMed.Columns[colDel.Name].Visible = true;
            dtgMatMed.Sort(dtgMatMed.Columns[colDescricao.Name], ListSortDirection.Ascending);
            dtgMatMed.ClearSelection();
            this.Cursor = Cursors.Default;
        }

        private void Carregar()
        {            
            this.Cursor = Cursors.WaitCursor;
            _dataInicioInv = null;
            dtoInventario = new InventarioMatMedDTO();

            dtoInventario.IdSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoInventario.IdFilial.Value = new Generico().RetornaFilial(rbHac, new HacRadioButton(), rbCE);
            dtoInventario.DataInventario.Value = DateTime.Parse(txtData.Text).Date;
            dtoInventario.FlMedicamento.Value = 1;

            InventarioMatMedDataTable dtbInventario = InventarioMatMed.ListarControle(dtoInventario);

            tsImportar.Enabled = btnPesquisaItens.Visible = dtgMatMed.Columns[colDel.Name].Visible = dtgMatMed.Columns[colZerar.Name].Visible = false;

            if (dtbInventario.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtbInventario.Rows[0]["CAD_MTMD_DT_INICIO_INV"].ToString()))                                    
                    _dataInicioInv = DateTime.Parse(dtbInventario.Rows[0]["CAD_MTMD_DT_INICIO_INV"].ToString());

                if (!string.IsNullOrEmpty(dtbInventario.Rows[0]["MTMD_DT_IMPORT"].ToString()))
                    MessageBox.Show("INVENTÁRIO JÁ IMPORTADO!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    tsImportar.Enabled = true;

                dtoInventario = dtbInventario.TypedRow(0);                
                decimal digitacaoNum = ((decimal)((decimal)dtoInventario.Fechamento.Value + 1));                

                btnFecharNum.Text = digitacaoNum > 3 ? "-" : digitacaoNum.ToString();
                lblDigitacao.Text = "CONTAGEM " + btnFecharNum.Text;
                lblContagemFechada.Text = dtoInventario.Fechamento.Value == 0 ? "-" : dtoInventario.Fechamento.Value.ToString();                

                CarregarItens();
            }            

            if (dtbInventario.Rows.Count == 0 || dtoInventario.FlAndamento.Value == "0")
            {
                gbEstoque.Enabled = txtCodProduto.Enabled = dtgMatMed.Enabled = tsImportar.Enabled = false;
                if (dtoInventario.Fechamento.Value != 3) MessageBox.Show("Inventário deste estoque/setor não está em andamento nesta data.\n\nAtive este inventário ou contate um gestor.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                gbEstoque.Enabled = false;
                btnPesquisaItens.Visible = true;
                txtCodProduto.Enabled = dtgMatMed.Enabled = tsImportar.Enabled;
                
                if (dtoInventario.FlAndamento.Value == 2)
                {                    
                    lblDigitacao.Text = string.Empty;
                    btnFecharNum.Text = "-";
                }
            }

            cbDigitar.Visible = cbDigitar.Checked = false;

            if (dtoInventario.Fechamento.Value == 3)
            {
                gbEstoque.Enabled = txtCodProduto.Enabled = dtgMatMed.Enabled = false;
                MessageBox.Show("Contagem deste estoque/setor já finalizada nesta data de inventário.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tsImportar.Enabled)
            {
                SetorDTO dtoSetor = new SetorDTO();
                dtoSetor.Idt.Value = dtoInventario.IdSetor.Value;
                dtoSetor = Setor.SelChave(dtoSetor);

                EstoqueLocalDTO dtoEstoqueCentDisp = new EstoqueLocalDTO();
                dtoEstoqueCentDisp.IdtUnidade.Value = int.Parse(cmbUnidade.SelectedValue.ToString());
                dtoEstoqueCentDisp.IdtSetor.Value = int.Parse(cmbSetor.SelectedValue.ToString());
                dtoEstoqueCentDisp.IdtLocal.Value = int.Parse(cmbLocal.SelectedValue.ToString());
                bool EstoqueCentroDispensacao = Estoque.EstoqueCentroDispensacao(dtoEstoqueCentDisp);

                if (dtoSetor.FlAlmoxCentral.Value == (byte)SetorDTO.AlmoxarifadoCentral.SIM || EstoqueCentroDispensacao ||
                    dtoSetor.Descricao.Value.ToString().ToUpper().IndexOf("UNITAR") > -1 ||
                    dtoSetor.Descricao.Value.ToString().ToUpper().IndexOf("FARM") > -1)
                    cbDigitar.Visible = cbDigitar.Checked = dtgMatMed.Columns[colZerar.Name].Visible = true;
            }
            
            btnFecharNum.Enabled = true;
            if (!tsImportar.Enabled)
            {
                btnFecharNum.Text = "-";
                btnFecharNum.Enabled = false;
            }
            txtCodProduto.Focus();
            this.Cursor = Cursors.Default;
        }

        private void AdicionarQtdMed(bool subtrair, string codLote, string numLote, int? qtdSubtrair)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                MovimentacaoDTO dtoQtd = new MovimentacaoDTO();
                if (!subtrair)
                {
                    HistoricoNotaFiscalDTO dtoHistNF = new HistoricoNotaFiscalDTO();
                    dtoHistNF.IdtProduto.Value = dtoMatMed.Idt.Value;
                    dtoHistNF.IdtLote.Value = dtoMatMed.IdtLote.Value;
                    DataTable dtbLote = HistoricoNotaFiscal.ListarLoteValidade(dtoHistNF);
                    if (dtbLote.Rows.Count == 0)
                    {
                        MessageBox.Show("Lote sem correspondência de entrada de NF com o medicamento !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Cursor = Cursors.Default;
                        txtCodProduto.Text = string.Empty;
                        txtCodProduto.Focus();
                        return;
                    }
                    else if (string.IsNullOrEmpty(dtbLote.Rows[0][HistoricoNotaFiscalDTO.FieldNames.CodLote].ToString()))
                    {
                        MessageBox.Show("Cod. Lote não identificado !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Cursor = Cursors.Default;
                        txtCodProduto.Text = string.Empty;
                        txtCodProduto.Focus();
                        return;
                    }
                    else
                    {
                        codLote = dtbLote.Rows[0][HistoricoNotaFiscalDTO.FieldNames.CodLote].ToString();
                        numLote = dtbLote.Rows[0][HistoricoNotaFiscalDTO.FieldNames.NumLote].ToString();
                    }

                    if (cbDigitar.Visible && cbDigitar.Checked)
                    {
                        dtoQtd.DsProduto.Value = dtoMatMed.Descricao.Value;
                        //dtoMov.EstoqueLocal.Value = dtoRequisicaoItem.EstoqueLocalQtde.Value;
                        dtoQtd = FrmQtdMatMed.DigitaQtde(dtoQtd);

                        if (dtoQtd == null) dtoQtd = new MovimentacaoDTO();
                        if (dtoQtd.Qtde.Value.IsNull) dtoQtd.Qtde.Value = 0;

                        if (dtoQtd.Qtde.Value == 0)
                        {
                            //Cancela contagem
                            this.Cursor = Cursors.Default;
                            txtCodProduto.Text = string.Empty;
                            txtCodProduto.Focus();
                            return;
                        }
                    }
                    else
                        dtoQtd.Qtde.Value = 1;
                }

                InventarioMatMedDTO dtoInv = new InventarioMatMedDTO();
                dtoInv.IdSetor.Value = cmbSetor.SelectedValue.ToString();
                dtoInv.IdFilial.Value = new Generico().RetornaFilial(rbHac, new HacRadioButton(), rbCE);
                dtoInv.DataInventario.Value = txtData.Text;
                dtoInv.IdProduto.Value = dtoMatMed.Idt.Value;
                dtoInv.FlMedicamento.Value = 1;
                dtoInv.CodLote.Value = codLote;
                InventarioMatMedDataTable dtbItem = InventarioMatMed.Listar(dtoInv);                
                if (dtbItem.Rows.Count > 0) dtoInv = dtbItem.TypedRow(0);

                dtoInventario.DtAtualizacao.Value = Utilitario.ObterDataHoraServidor();
                dtoInventario.IdProduto.Value = dtoMatMed.Idt.Value;
                dtoInventario.CodLote.Value = dtoInv.CodLote.Value;
                dtoInventario.NumLoteFab.Value = numLote;

                switch (int.Parse(btnFecharNum.Text))
                {
                    case 1:
                        if (!subtrair)
                        {
                            if (dtoInv != null && !dtoInv.Qtde1.Value.IsNull)
                                dtoInventario.QtdeFinal.Value = (int)dtoInv.Qtde1.Value + (int)dtoQtd.Qtde.Value;
                            else
                                dtoInventario.QtdeFinal.Value = dtoQtd.Qtde.Value;
                        }
                        else if (dtoInv != null && !dtoInv.Qtde1.Value.IsNull && (int)dtoInv.Qtde1.Value > 0)
                            dtoInventario.QtdeFinal.Value = (int)dtoInv.Qtde1.Value - qtdSubtrair.Value;                       

                        dtoInventario.Qtde1.Value = dtoInventario.QtdeFinal.Value;
                        break;
                    case 2:
                        if (!subtrair)
                        {
                            if (dtoInv != null && !dtoInv.Qtde2.Value.IsNull)
                                dtoInventario.QtdeFinal.Value = (int)dtoInv.Qtde2.Value + (int)dtoQtd.Qtde.Value;
                            else
                                dtoInventario.QtdeFinal.Value = dtoQtd.Qtde.Value;
                        }
                        else if (dtoInv != null && !dtoInv.Qtde2.Value.IsNull && (int)dtoInv.Qtde2.Value > 0)
                            dtoInventario.QtdeFinal.Value = (int)dtoInv.Qtde2.Value - qtdSubtrair.Value;                        

                        dtoInventario.Qtde2.Value = dtoInventario.QtdeFinal.Value;
                        break;
                    case 3:
                        if (!subtrair)
                        {
                            if (dtoInv != null && !dtoInv.Qtde3.Value.IsNull)
                                dtoInventario.QtdeFinal.Value = (int)dtoInv.Qtde3.Value + (int)dtoQtd.Qtde.Value;
                            else
                                dtoInventario.QtdeFinal.Value = dtoQtd.Qtde.Value;
                        }
                        else if (dtoInv != null && !dtoInv.Qtde3.Value.IsNull && (int)dtoInv.Qtde3.Value > 0)
                            dtoInventario.QtdeFinal.Value = (int)dtoInv.Qtde3.Value - qtdSubtrair.Value;                        

                        dtoInventario.Qtde3.Value = dtoInventario.QtdeFinal.Value;
                        break;
                }
                if (_idGrupo != null) dtoInventario.IdtGrupo.Value = _idGrupo.Value;
                dtoInventario.IdUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                InventarioMatMed.Gravar(dtoInventario);

                //Limpar itens pra não ficar muito pesado na tela
                if (dtbInventario != null && dtbInventario.Rows.Count >= 20) dtbInventario = null;

                // insere linha no grid
                if (dtbInventario == null)
                {
                    dtbInventario = new InventarioMatMedDataTable();
                    dtbInventario.Columns.Add(MaterialMedicamentoDTO.FieldNames.NomeFantasia);
                }

                DataRow[] rowExistente = dtbInventario.Select(string.Format("{0} = {1} AND {2} = {3}", MaterialMedicamentoDTO.FieldNames.Idt, dtoMatMed.Idt.Value,
                                                                                                       InventarioMatMedDTO.FieldNames.CodLote, dtoInventario.CodLote.Value));
                if (rowExistente.Length == 0)
                {
                    dtbInventario.Add(dtoInventario);
                    dtbInventario.Rows[dtbInventario.Rows.Count - 1][MaterialMedicamentoDTO.FieldNames.NomeFantasia] = dtoMatMed.NomeFantasia.Value;
                }
                else
                {
                    rowExistente[0][InventarioMatMedDTO.FieldNames.QtdeFinal] = dtoInventario.QtdeFinal.Value;
                    rowExistente[0][InventarioMatMedDTO.FieldNames.DtAtualizacao] = Utilitario.ObterDataHoraServidor();
                }

                dtgMatMed.DataSource = dtbInventario;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            txtCodProduto.Text = string.Empty;
            txtCodProduto.Focus();
            dtbInventario.AcceptChanges();
            dtgMatMed.Sort(dtgMatMed.Columns[colData.Name], ListSortDirection.Descending);
            dtgMatMed.ClearSelection();
            dtgMatMed.Rows[0].Cells[colQtd.Name].Selected = true;
            
            this.Cursor = Cursors.Default;
        }

        private void ImportarInventario()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                MovimentacaoDTO dtoMovimentacao = new MovimentacaoDTO();
                dtoMovimentacao.IdtSetor.Value = dtoInventario.IdSetor.Value;
                dtoMovimentacao.IdtFilial.Value = dtoInventario.IdFilial.Value;
                dtoMovimentacao.DtFaturamento.Value = dtoInventario.DataInventario.Value;
                dtoMovimentacao.IdtUsuario.Value = dtoInventario.IdUsuario.Value;
                tsImportar.Enabled = false;
                Movimento.ImportaInventarioMed(dtoMovimentacao, _idGrupo);
                MessageBox.Show("Dados do inventário importados para o estoque com sucesso", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível importar os dados do inventário " + ex.Message, "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
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

        private bool ValidarProdutoRegra()
        {
            if (Convert.ToDecimal(dtoMatMed.IdtGrupo.Value) != 1)
            {
                MessageBox.Show("Permitido inventário apenas de MEDICAMENTO nesta tela !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (dtoMatMed.IdtLote.Value.IsNull || (int)dtoMatMed.IdtLote.Value == 0)
            {
                MessageBox.Show("LOTE NÃO IDENTIFICADO !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }  
            return true;
        }        
        
        private bool ValidarEstoqueCompartilhado()
        {
            if ((rbHac.Checked || rbCE.Checked) && ValidarSetor(false))
            {
                EstoqueLocalDTO dtoEstoque = new EstoqueLocalDTO();
                dtoEstoque.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                dtoEstoque.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                dtoEstoque.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                if (rbHac.Checked)
                    dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;                
                else if (rbCE.Checked)
                    dtoEstoque.IdtFilial.Value = (int)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;

                this.Cursor = Cursors.WaitCursor;
                int idSetorEstoque = Estoque.EstoqueDeConsumo(dtoEstoque);
                this.Cursor = Cursors.Default;

                if (idSetorEstoque != int.Parse(cmbSetor.SelectedValue.ToString()))
                {
                    SetorDTO dtoSetor = new SetorDTO();
                    dtoSetor.Idt.Value = idSetorEstoque;                    
                    MessageBox.Show("Este Setor/Estoque não pode ser selecionado, pois utiliza o estoque do(a) " + Setor.SelChave(dtoSetor).Descricao.Value, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    cmbSetor.SelectedIndex = -1;                    
                    lblEstoqueUnificado.Text = string.Empty;
                    rbHac.Checked = rbCE.Checked = false;

                    return false;
                }

                if (rbCE.Checked)
                {
                    bool EstoqueCentroDispensacao = Estoque.EstoqueCentroDispensacao(dtoEstoque);
                    if (EstoqueCentroDispensacao)
                    {
                        MessageBox.Show("Estoque CE não pode ser selecionado para este setor, pois é um Centro de Dispensação.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        rbHac.Checked = rbCE.Checked = false;
                    }

                    return false;
                }
            }
            return true;
        }

        #endregion

        #region EVENTOS

        private void FrmInventarioDigitaMed_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            if (ValidarSetor(false) && ValidarFilial(false) && ValidarData(false))
                Carregar();
            else
            {
                cmbUnidade.Carregaunidade();                
                rbHac.Checked = true;
                txtData.Text = Utilitario.ObterDataHoraServidor().ToString("dd/MM/yyyy");
                btnFecharNum.Enabled = false;
            }
            if (txtCodProduto.Enabled) txtCodProduto.Focus();                     
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();
            dtoCfg.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoCfg.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoCfg.Idtsetor.Value = cmbSetor.SelectedValue.ToString();
            dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);
            if (dtoCfg.EstoqueUnificadoHAC.Value.IsNull) dtoCfg.EstoqueUnificadoHAC.Value = 0;
            if (dtoCfg.EstoqueUnificadoHAC.Value == 1)
                lblEstoqueUnificado.Text = "ESTOQUE ÚNICO HAC";
            else
                lblEstoqueUnificado.Text = string.Empty;
            if (sender != null) ValidarEstoqueCompartilhado();
        }

        private void rbEstoque_Click(object sender, EventArgs e)
        {
            ValidarEstoqueCompartilhado();
        }

        private bool tsHac_LimparClick(object sender)
        {
            if (dtgMatMed.CurrentCell != null && dtgMatMed.CurrentCell.IsInEditMode)
            {
                MessageBox.Show("Grid não pode estar em edição", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            lblDigitacao.Text = string.Empty;
            gbEstoque.Enabled = true;            
            dtgMatMed.Enabled = true;
            try { dtgMatMed.Columns[colDel.Name].Visible = dtgMatMed.Columns[colZerar.Name].Visible = false; }
            catch { } //Quando célula em branco estava dando erro aqui
            btnFecharNum.Enabled = false;
            ConfigurarControles(gbEstoque.Controls, true);            
            lblContagemFechada.Text = "0";
            btnFecharNum.Text = "-";            
            txtData.Text = Utilitario.ObterDataHoraServidor().ToString("dd/MM/yyyy");
            dtoInventario = null;
            dtbInventario = null;
            _dataInicioInv = null;
            dtgMatMed.DataSource = dtbInventario;
            return true;
        }

        private void tsHac_AfterLimpar(object sender)
        {
            lblEstoqueUnificado.Text = string.Empty;
        }

        private void tsImportar_Click(object sender, EventArgs e)
        {
            if (gbEstoque.Enabled || (lblContagemFechada.Text == "0" || lblContagemFechada.Text == "-"))
            {
                //MessageBox.Show("Carregue antes um inventário em andamento com a 2° contagem fechada de um estoque/setor.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("ALERTA: NENHUMA CONTAGEM FOI FECHADA !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //return;
            }
            //else if (lblContagemFechada.Text != "-" && byte.Parse(lblContagemFechada.Text) < 1)
            //{
            //    MessageBox.Show("É necessário fechar a 1° contagem.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            if (_dataInicioInv != null)
            {
                if (InventarioMatMed.InventarioImportando(dtoInventario, _dataInicioInv.Value))
                {
                    MessageBox.Show("INVENTÁRIO DE MEDICAMENTOS JÁ IMPORTADO OU EM PROCESSAMENTO !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (MessageBox.Show("Deseja realmente zerar o estoque de MEDICAMENTOS deste setor e importar os dados deste inventário para ele?", "Gestão de Materiais e Medicamentos",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Só deixar importar se for gestor            
                SegurancaDTO dtoUsuario;
                if (!ValidarUsuario(out dtoUsuario)) return;

                dtoInventario.IdUsuario.Value = dtoUsuario.Idt.Value;
                ImportarInventario();
            }    
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            if (ValidarSetor(true) && ValidarFilial(true) && ValidarData(true)) Carregar();
        }

        private void btnPesquisaItens_Click(object sender, EventArgs e)
        {
            if (!gbEstoque.Enabled)
            {
                CarregarItens();
                txtCodProduto.Focus();
            }
        }

        private void btnFecharNum_Click(object sender, EventArgs e)
        {
            if (!tsImportar.Enabled)
            {
                MessageBox.Show("Inventário inativo.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (btnFecharNum.Text == "-")
            {
                MessageBox.Show("Nenhuma contagem em andamento.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            
            if (MessageBox.Show("Deseja realmente fechar a contagem do estoque selecionado deste setor?", "Gestão de Materiais e Medicamentos",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                InventarioMatMedDTO dtoInv = new InventarioMatMedDTO();

                dtoInv.IdSetor.Value = cmbSetor.SelectedValue.ToString();
                dtoInv.IdFilial.Value = new Generico().RetornaFilial(rbHac, new HacRadioButton(), rbCE);
                dtoInv.DataInventario.Value = txtData.Text;
                dtoInv.FlMedicamento.Value = 1;
                InventarioMatMedDataTable dtbInv = InventarioMatMed.ListarControle(dtoInv);
                if (decimal.Parse(dtbInv.TypedRow(0).Fechamento.Value.ToString()) >= decimal.Parse(btnFecharNum.Text))
                {
                    MessageBox.Show("FECHAMENTO JÁ REALIZADO (POSSIVELMENTE FOI FEITO EM OUTRA MÁQUINA)", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (decimal.Parse(dtbInv.TypedRow(0).Fechamento.Value.ToString()) >= 3)
                {
                    MessageBox.Show("FECHAMENTO NÃO PODE SER MAIOR QUE 3 (POSSIVELMENTE FOI FEITO RECENTEMENTE UM FECHAMENTO EM OUTRA MÁQUINA)", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Só deixar fechar se for gestor            
                SegurancaDTO dtoUsuario;
                if (!ValidarUsuario(out dtoUsuario)) return;

                dtoInventario.IdUsuario.Value = dtoUsuario.Idt.Value;
                dtoInventario.FlMedicamento.Value = 1;
                try
                {
                    InventarioMatMed.FecharInventario(dtoInventario);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Contagem de inventário fechada com sucesso.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
                Carregar();
                dtbInventario = null;
            }            
        }

        private void txtCodProduto_Validating(object sender, CancelEventArgs e)
        {
            if (txtCodProduto.Text != string.Empty)
            {
                CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();
                dtoCodigoBarra.CdBarra.Value = txtCodProduto.Text;
                dtoCodigoBarra.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC;
                // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
                dtoMatMed = MatMed.BuscaCodigoBarra(dtoCodigoBarra);

                if (dtoMatMed == null)
                {
                    MessageBox.Show("Código não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodProduto.Text = string.Empty;
                    txtCodProduto.Focus();                    
                    return;
                }
                else if (!ValidarProdutoRegra())
                {
                    txtCodProduto.Text = string.Empty;
                    txtCodProduto.Focus();
                    return;
                }

                this.AdicionarQtdMed(false, null, null, null);
            }
        }

        private void cbDigitar_Click(object sender, EventArgs e)
        {
            txtCodProduto.Text = string.Empty;
            txtCodProduto.Focus();
        }

        private void dtgMatMed_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == dtgMatMed[colDel.Name, e.RowIndex].ColumnIndex ||
                    e.ColumnIndex == dtgMatMed[colZerar.Name, e.RowIndex].ColumnIndex)
                {
                    if (dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value == null || dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value.ToString() == string.Empty) return;
                    try
                    {
                        if (int.Parse(dtgMatMed.Rows[e.RowIndex].Cells[colQtd.Name].Value.ToString()) == 0)
                        {
                            MessageBox.Show("SEM QTDE. PARA SUBTRAÇÃO", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("SEM QTDE. PARA SUBTRAÇÃO", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    this.Cursor = Cursors.WaitCursor;
                    
                    dtoMatMed = new MaterialMedicamentoDTO();
                    dtoMatMed.Idt.Value = dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value.ToString();
                    dtoMatMed = MatMed.SelChave(dtoMatMed);

                    int qtdSubtrair = 1;
                    string mensagem = "Deseja realmente subtrair 1 unidade deste item nesta contagem ?";
                    if (e.ColumnIndex == dtgMatMed[colZerar.Name, e.RowIndex].ColumnIndex)
                    {
                        mensagem = "Deseja realmente zerar este item nesta contagem ?";
                        qtdSubtrair = int.Parse(dtgMatMed.Rows[e.RowIndex].Cells[colQtd.Name].Value.ToString());
                    }

                    if (MessageBox.Show(mensagem, "Gestão de Materiais e Medicamentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.AdicionarQtdMed(true,
                                             dtgMatMed.Rows[e.RowIndex].Cells[colCodLote.Name].Value.ToString(),
                                             dtgMatMed.Rows[e.RowIndex].Cells[colNumFabLote.Name].Value.ToString(),
                                             qtdSubtrair);                        
                    }
                    txtCodProduto.Focus();                    
                }
                this.Cursor = Cursors.Default;
            }
        }

        #endregion
    }
}