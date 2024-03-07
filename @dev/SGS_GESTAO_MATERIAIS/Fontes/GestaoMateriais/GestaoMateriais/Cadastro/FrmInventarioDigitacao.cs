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
using HospitalAnaCosta.SGS.Seguranca.Forms;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using System.IO;
using System.Security.Cryptography;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Cadastro
{
    public partial class FrmInventarioDigitacao : FrmBase
    {
        #region OBJETOS SERVIÇOS

        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }

        // GrupoMatMed        
        private IGrupoMatMed _grupoMatMed;
        private IGrupoMatMed GrupoMatMed
        {
            get { return _grupoMatMed != null ? _grupoMatMed : _grupoMatMed = (IGrupoMatMed)Global.Common.GetObject(typeof(IGrupoMatMed)); }
        }

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

        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        #endregion

        #region VARIÁVEIS GLOBAIS INTERNAS

        private bool _qtdSemId = false;
        private bool _idInvalido = false;
        private bool _salvarItem = false;
        private bool _naoMostraMsg = false;
        private bool _limparGrid = false;
        private bool _carregarDigitacaoPosExclusaoArquivo = false;
        private decimal _valorEdit = 0;
        private DateTime? _dataInicioInv = null;
        
        #endregion

        #region MÉTODOS

        public FrmInventarioDigitacao()
        {
            InitializeComponent();
        }

        private bool RegistroJaExistente(decimal idtProduto, int rowIndexEdicao, out int rowIndexItem)
        {
            foreach (DataGridViewRow row in dtgMatMed.Rows)
            {
                if (row.Cells[colIdt.Name].Value != null && row.Cells[colIdt.Name].Value.ToString() != string.Empty &&
                    row.Index != rowIndexEdicao && decimal.Parse(row.Cells[colIdt.Name].Value.ToString()) == idtProduto)
                {
                    rowIndexItem = row.Index;
                    return true;
                }
            }
            rowIndexItem = -1;
            return false;
        }

        private bool ValidarFilial()
        {
            if (!rbAcs.Checked && !rbHac.Checked && !rbCE.Checked && !rbConsig.Checked)
            {
                MessageBox.Show("Selecione o estoque (HAC / CE / CONSIGNADO)", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private bool ValidarData()
        {
            if (txtData.Text == string.Empty)
            {
                MessageBox.Show("Data deve ser preenchida", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtData.Focus();
                return false;
            }
            DateTime dt;
            if (!DateTime.TryParse(txtData.Text, out dt))
            {
                MessageBox.Show("Data inválida", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtData.Focus();
                return false;
            }
            return true;
        }
        
        private void AtualizarQtdFinal()
        {
            lblQtd.Text = ((int)(dtgMatMed.RowCount - 1)).ToString("N0");
        }

        private bool InventarioExistenteDiaAnterior()
        {
            InventarioMatMedDTO dtoInv = new InventarioMatMedDTO();

            dtoInv.IdSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoInv.IdFilial.Value = new Generico().RetornaFilial(rbHac, rbAcs, rbCE, rbConsig);
            dtoInv.DataInventario.Value = DateTime.Parse(txtData.Text).Date.AddDays(-1);
            dtoInv.FlAndamento.Value = 0;
            if (cmbGrupo.SelectedIndex > 0) dtoInv.IdtGrupo.Value = cmbGrupo.SelectedValue.ToString();

            if (InventarioMatMed.ListarControle(dtoInv).Rows.Count > 0) return true;

            return false;
        }

        private void CarregarImportacoes()
        {
            InventarioMatMedDTO dtoInv = new InventarioMatMedDTO();
            dtoInv.IdSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoInv.IdFilial.Value = new Generico().RetornaFilial(rbHac, new HacRadioButton(), rbCE, rbConsig);
            dtgImportacoes.DataSource = InventarioMatMed.ListarArquivosSalvosImportacaoPalmTXT(dtoInv);            
            if (dtgImportacoes.Rows.Count > 0)
            {
                pnlImportacoes.BorderStyle = BorderStyle.FixedSingle;
                pnlImportacoes.Visible = true;
                dtgImportacoes.ClearSelection();
            }
            else if (!pnlImportacoes.Visible)
            {                 
                MessageBox.Show("NENHUM ARQUIVO IMPORTADO ATÉ O MOMENTO PARA A CONTAGEM DESTE ESTOQUE !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CarregarInventariosAndamento()
        {
            this.Cursor = Cursors.WaitCursor;
            InventarioMatMedDTO dto = new InventarioMatMedDTO();
            dto.FlAndamento.Value = cbFinalizados.Checked ? 0 : 1;
            dtgInventariosAndamento.AutoGenerateColumns = false;
            dtgInventariosAndamento.DataSource = InventarioMatMed.ListarControle(dto);
            dtgInventariosAndamento.ClearSelection();
            dtgInventariosAndamento.Sort(dtgInventariosAndamento.Columns[0], ListSortDirection.Descending);
            this.Cursor = Cursors.Default;
        }

        private void CarregarDigitacao()
        {
            this.Cursor = Cursors.WaitCursor;
            _dataInicioInv = null;
            dtoInventario = new InventarioMatMedDTO();

            dtoInventario.IdSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoInventario.IdFilial.Value = new Generico().RetornaFilial(rbHac, rbAcs, rbCE, rbConsig);
            dtoInventario.DataInventario.Value = DateTime.Parse(txtData.Text).Date;
            dtoInventario.FlMedicamento.Value = 0;
            dtoInventario.IdtGrupo.Value = 0;
            bool flSoMedicamentos = false;
            if (cmbGrupo.SelectedIndex > 0)
            {
                dtoInventario.IdtGrupo.Value = cmbGrupo.SelectedValue.ToString();
                if ((int)dtoInventario.IdtGrupo.Value == 1)
                {
                    dtoInventario.FlMedicamento.Value = 1;
                    flSoMedicamentos = true;
                }
            }            

            InventarioMatMedDataTable dtbInventario = InventarioMatMed.ListarControle(dtoInventario);

            tsImportar.Enabled = false;
            if (dtbInventario.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtbInventario.Rows[0]["CAD_MTMD_DT_INICIO_INV"].ToString()))
                    _dataInicioInv = DateTime.Parse(dtbInventario.Rows[0]["CAD_MTMD_DT_INICIO_INV"].ToString());

                if (!string.IsNullOrEmpty(dtbInventario.Rows[0]["MTMD_DT_IMPORT"].ToString()))
                    MessageBox.Show("INVENTÁRIO JÁ IMPORTADO!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    tsImportar.Enabled = true;

                if (rbConsig.Checked)
                    btnImportarArqPalm.Enabled = false;
                else
                    btnImportarArqPalm.Enabled = true;

                //Carregar os itens do grid
                _limparGrid = true;
                dtgMatMed.Rows.Clear();
                _limparGrid = false;                
                
                int indexGrid = 0;
                DataTable dtbItens = InventarioMatMed.Listar(dtoInventario);
                dtoInventario = dtbInventario.TypedRow(0);
                if (dtoInventario.Fechamento.Value == 1 || dtoInventario.Fechamento.Value == 2)
                {
                    DataView dvItens = new DataView(dtbItens, string.Format("{0} IS NOT NULL", dtoInventario.Fechamento.Value == 1 ? InventarioMatMedDTO.FieldNames.Qtde2 : InventarioMatMedDTO.FieldNames.Qtde3), string.Empty, DataViewRowState.CurrentRows);
                    dtbItens = dvItens.ToTable();
                }
                decimal digitacaoNum = ((decimal)((decimal)dtoInventario.Fechamento.Value + 1));
                _salvarItem = false;
                lblInventarioTerceirizado.Visible = btnGerarTXT.Visible = false;
                
                if (dtoInventario.FlAndamento.Value != 2)//Se não for empresa terceirizada
                {
                    if (!flSoMedicamentos)
                    {
                        foreach (DataRow row in dtbItens.Rows)
                        {
                            dtgMatMed.Rows.Add();
                            dtgMatMed.Rows[indexGrid].Cells[colIdt.Name].Value = row[InventarioMatMedDTO.FieldNames.IdProduto];
                            dtgMatMed.Rows[indexGrid].Cells[colDataAtualiza.Name].Value = row[InventarioMatMedDTO.FieldNames.DtAtualizacao];
                            //dtgMatMed.Rows[indexGrid].Cells[colQtd.Name].Value = row[InventarioMatMedDTO.FieldNames.QtdeFinal];
                            if (digitacaoNum == 1 && !string.IsNullOrEmpty(row[InventarioMatMedDTO.FieldNames.Qtde1].ToString()))
                            {
                                dtgMatMed.Rows[indexGrid].Cells[colQtd.Name].Style.BackColor = Color.LightGray;
                                dtgMatMed.Rows[indexGrid].Cells[colQtd.Name].Value = row[InventarioMatMedDTO.FieldNames.Qtde1];
                            }
                            else if (digitacaoNum == 2 && !string.IsNullOrEmpty(row[InventarioMatMedDTO.FieldNames.Qtde2].ToString()))
                            {
                                dtgMatMed.Rows[indexGrid].Cells[colQtd.Name].Style.BackColor = Color.LightGray;
                                dtgMatMed.Rows[indexGrid].Cells[colQtd.Name].Value = row[InventarioMatMedDTO.FieldNames.Qtde2];
                            }
                            else if (digitacaoNum == 3 && !string.IsNullOrEmpty(row[InventarioMatMedDTO.FieldNames.Qtde3].ToString()))
                            {
                                dtgMatMed.Rows[indexGrid].Cells[colQtd.Name].Style.BackColor = Color.LightGray;
                                dtgMatMed.Rows[indexGrid].Cells[colQtd.Name].Value = row[InventarioMatMedDTO.FieldNames.Qtde3];
                            }
                            else
                            {
                                dtgMatMed.Rows[indexGrid].Cells[colQtd.Name].Value = 0;
                            }
                            indexGrid += 1;
                        }
                    }
                    
                    dtgMatMed.ClearSelection();

                    btnFecharNum.Text = digitacaoNum > 3 ? "-" : digitacaoNum.ToString();
                    lblDigitacao.Text = "DIGITAÇÃO " + btnFecharNum.Text;
                    lblContagemFechada.Text = dtoInventario.Fechamento.Value == 0 ? "-" : dtoInventario.Fechamento.Value.ToString();
                }
            }

            dtgMatMed.Columns[colDel.Name].Visible = false;
            txtCodProduto.Enabled = cbDigitar.Enabled = false;

            if (dtbInventario.Rows.Count == 0 || dtoInventario.FlAndamento.Value == "0")
            {
                cbAndamento.Checked = btnImportarArqPalm.Visible = btnImportacoes.Visible = false;
                //gbEstoque.Enabled = true;
                gbEstoque.Enabled = false;                
                //dtgMatMed.Enabled = false;
                dtgMatMed.ReadOnly = true;
                if (dtoInventario.Fechamento.Value != 3) MessageBox.Show("Inventário deste estoque/setor não está em andamento nesta data.\n\nAtive este inventário ou contate um gestor para poder alterar os produtos.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                cbAndamento.Checked = true;
                if (new Generico().VerificaAcessoFuncionalidade("ImportarContagemPalmTXT")) btnImportarArqPalm.Visible = btnImportacoes.Visible = true;                
                gbEstoque.Enabled = false;
                //dtgMatMed.Enabled = dtoInventario.Fechamento.Value == 3 ? false : true;                
                dtgMatMed.ReadOnly = (dtoInventario.FlAndamento.Value == 2 || dtoInventario.Fechamento.Value == 3 || !tsImportar.Enabled) ? true : false;                
                if (dtgMatMed.RowCount > 0 && !dtgMatMed.ReadOnly) dtgMatMed.CurrentCell = dtgMatMed.Rows[dtgMatMed.RowCount - 1].Cells[colIdt.Name];
                if (!dtgMatMed.ReadOnly)
                {
                    cbDigitar.Visible = false;
                    txtCodProduto.Enabled = true;
                    dtgMatMed.Focus();
                    dtgMatMed.Columns[colDel.Name].Visible = true;
                }
                if (dtoInventario.FlAndamento.Value == 2)
                {
                    lblInventarioTerceirizado.Visible = btnGerarTXT.Visible = true;
                    lblDigitacao.Text = string.Empty;
                    btnFecharNum.Text = "-";
                }
            }

            if (dtoInventario.Fechamento.Value == 3 && !_naoMostraMsg) MessageBox.Show("Contagem deste estoque/setor já finalizada nesta data de inventário.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);            

            _salvarItem = true;
            dtgMatMed.Sort(dtgMatMed.Columns[colDescricao.Name], ListSortDirection.Ascending);
            cbAndamento.Enabled = true;
            btnFecharNum.Enabled = !lblInventarioTerceirizado.Visible;
            if (!tsImportar.Enabled)
            {
                btnFecharNum.Text = "-";
                btnFecharNum.Enabled = false;
            }
            txtCodProduto.Focus();
            this.Cursor = Cursors.Default;
        }

        private void CarregarDadosHAC_ParaDigitacao1()
        {
            this.Cursor = Cursors.WaitCursor;
            EstoqueLocalDTO dtoEstoque = new EstoqueLocalDTO();
            dtoEstoque.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoEstoque.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoEstoque.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            dtoEstoque.Origem.Value = 1;
            EstoqueLocalDataTable dtbEstoque = Estoque.EstoqueOnLine(dtoEstoque);
            int indexGrid = 0;
            //_salvarItem = false; 
            DateTime dataAtual = Utilitario.ObterDataHoraServidor();
            foreach (DataRow row in dtbEstoque.Rows)
            {
                if (row[EstoqueLocalDTO.FieldNames.FlAtivo].ToString() == "1")
                {
                    dtgMatMed.Rows.Add();
                    dtgMatMed.Rows[indexGrid].Cells[colIdt.Name].Value = row[EstoqueLocalDTO.FieldNames.IdtProduto];
                    dtgMatMed.Rows[indexGrid].Cells[colDataAtualiza.Name].Value = dataAtual;
                    //dtgMatMed.Rows[indexGrid].Cells[colQtd.Name].Value = row[EstoqueLocalDTO.FieldNames.Qtde];
                    dtgMatMed.Rows[indexGrid].Cells[colQtd.Name].Value = 0;
                    dtgMatMed.Rows[indexGrid].Cells[colQtd.Name].Style.BackColor = Color.White;
                    indexGrid += 1;
                }
            }
            dtgMatMed.ClearSelection();
            //_salvarItem = true;
            this.Cursor = Cursors.Default;
        }

        private void AtualizarStatus()
        {            
            this.Cursor = Cursors.WaitCursor;
            bool terceirizado = false;
                                //cbAndamento.Checked && 
                                //MessageBox.Show("O inventário deste estoque/setor será realizado por uma empresa terceirizada ?", "Gestão de Materiais e Medicamentos",
                                //                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;

            string texto = "Deseja realmente ativar o inventário deste estoque/setor ?";
            if (!cbAndamento.Checked) texto = "Deseja realmente inativar o inventário deste estoque/setor ?";
            if (MessageBox.Show(texto, "Gestão de Materiais e Medicamentos",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool apenasMateriaisEmGeral = false;
                if (cmbGrupo.SelectedIndex == 0 && cbAndamento.Checked)
                {
                    InventarioMatMedDTO dtoInvMed = new InventarioMatMedDTO();
                    dtoInvMed.IdSetor.Value = cmbSetor.SelectedValue.ToString();
                    dtoInvMed.IdFilial.Value = new Generico().RetornaFilial(rbHac, rbAcs, rbCE, rbConsig);
                    dtoInvMed.FlAndamento.Value = 0;
                    dtoInvMed.DataInventario.Value = txtData.Text;
                    dtoInvMed.FlMedicamento.Value = 1;
                    InventarioMatMedDataTable dtbInvMed = InventarioMatMed.ListarControle(dtoInvMed);
                    if (dtbInvMed.Rows.Count > 0)
                    {
                        texto = "Já houve inventário de Medicamentos deste estoque/setor nesta data, deseja abrir apenas de materiais em geral ?";
                        if (MessageBox.Show(texto, "Gestão de Materiais e Medicamentos",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            apenasMateriaisEmGeral = true;
                        }
                        else
                        {
                            cbAndamento.Checked = !cbAndamento.Checked;
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }
                }
                if (rbConsig.Checked && !apenasMateriaisEmGeral)
                    apenasMateriaisEmGeral = true;

                if (terceirizado && cbAndamento.Checked)
                    dtoInventario.FlAndamento.Value = "2"; //Inventario terceirizado
                else
                    dtoInventario.FlAndamento.Value = cbAndamento.Checked ? "1" : "0";

                try
                {
                    InventarioMatMed.AtivarInventario(dtoInventario, apenasMateriaisEmGeral);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbAndamento.Checked = !cbAndamento.Checked;
                    this.Cursor = Cursors.Default;
                    return;
                }
                texto = "Inventário ativado com sucesso.";
                if (!cbAndamento.Checked) texto = "Inventário inativado com sucesso.";
                //MessageBox.Show("Status do inventário salvo com sucesso.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(texto, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _naoMostraMsg = true;

                txtCodProduto.Enabled = cbDigitar.Enabled = false;

                if (!cbAndamento.Checked)
                {
                    //dtgMatMed.Enabled = false;
                    dtgMatMed.ReadOnly = true;
                    dtgMatMed.Columns[colDel.Name].Visible = false;
                }
                else if (cbAndamento.Checked && !terceirizado)
                    CarregarDigitacao();
                else if (terceirizado)
                {
                    dtgMatMed.ReadOnly = lblInventarioTerceirizado.Visible = btnGerarTXT.Visible = true;
                    lblDigitacao.Text = string.Empty;
                    btnFecharNum.Text = "-";
                }
                
                _naoMostraMsg = false;

                if (pnlInventAnda.Visible) CarregarInventariosAndamento();                
            }
            else
            {
                cbAndamento.Checked = !cbAndamento.Checked;
            }
            //if (rbCE.Checked && cbAndamento.Checked && byte.Parse(btnFecharNum.Text) == 1 && dtgMatMed.RowCount == 1)
            //if (!rbAcs.Enabled && lblEstoqueUnificado.Text != string.Empty && cbAndamento.Checked && byte.Parse(btnFecharNum.Text) == 1 && dtgMatMed.RowCount == 1)
            //{
            //    if (dtgMatMed.Rows[0].Cells[0].Value == null) CarregarDadosHAC_ParaDigitacao1();
            //}
            this.Cursor = Cursors.Default;
        }

        private int ObterNumContagemAtualMedicamento()
        {
            InventarioMatMedDTO dtoInvMed = new InventarioMatMedDTO();

            dtoInvMed.IdSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoInvMed.IdFilial.Value = new Generico().RetornaFilial(rbHac, rbAcs, rbCE, rbConsig);
            dtoInvMed.DataInventario.Value = DateTime.Parse(txtData.Text).Date;
            dtoInvMed.FlMedicamento.Value = 1;

            InventarioMatMedDataTable dtbInvMed = InventarioMatMed.ListarControle(dtoInvMed);
            if (dtbInvMed.Rows.Count == 0) return 0;
            return ((int)dtbInvMed.TypedRow(0).Fechamento.Value + 1);
        }

        private void GravarLogImportacaoCodNaoEncontrado(bool medicamento, int qtde, string codBarra, DateTime dtInicioProcesso)
        {
            if (IsNumber(btnFecharNum.Text))
            {
                InventarioMatMedDTO dtoInv = new InventarioMatMedDTO();
                dtoInv.IdSetor.Value = cmbSetor.SelectedValue.ToString();
                dtoInv.IdFilial.Value = new Generico().RetornaFilial(rbHac, new HacRadioButton(), rbCE, rbConsig);
                dtoInv.DataInventario.Value = txtData.Text;
                dtoInv.FlMedicamento.Value = medicamento ? 1 : 0;
                dtoInv.IdUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                dtoInv.Fechamento.Value = int.Parse(btnFecharNum.Text) - 1;
                dtoInv.DtAtualizacao.Value = dtInicioProcesso;
                InventarioMatMed.Gravar(dtoInv, codBarra, qtde);
            }
        }

        private void AdicionarQtdMed(bool medicamento, int qtde, string codBarra, DateTime dtInicioProcesso, bool origemImportacao)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string codLote = null, numLote = null;
                if (medicamento)
                {
                    HistoricoNotaFiscalDTO dtoHistNF = new HistoricoNotaFiscalDTO();
                    dtoHistNF.IdtProduto.Value = dtoMatMed.Idt.Value;
                    dtoHistNF.IdtLote.Value = dtoMatMed.IdtLote.Value;
                    DataTable dtbLote = HistoricoNotaFiscal.ListarLoteValidade(dtoHistNF);
                    if (dtbLote.Rows.Count == 0)
                    {
                        //MessageBox.Show("Lote sem correspondência de entrada de NF com o medicamento !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //this.Cursor = Cursors.Default;
                        //return;
                        codLote = dtoHistNF.IdtLote.Value;
                        qtde = 0;
                    }
                    else if (string.IsNullOrEmpty(dtbLote.Rows[0][HistoricoNotaFiscalDTO.FieldNames.CodLote].ToString()))
                    {
                        //MessageBox.Show("Cod. Lote não identificado !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //this.Cursor = Cursors.Default;
                        //return;
                        codLote = dtoHistNF.IdtLote.Value;
                        qtde = 0;
                    }
                    else
                    {
                        codLote = dtbLote.Rows[0][HistoricoNotaFiscalDTO.FieldNames.CodLote].ToString();
                        numLote = dtbLote.Rows[0][HistoricoNotaFiscalDTO.FieldNames.NumLote].ToString();
                    }
                }

                InventarioMatMedDTO dtoInv = new InventarioMatMedDTO();
                dtoInv.IdSetor.Value = cmbSetor.SelectedValue.ToString();
                dtoInv.IdFilial.Value = new Generico().RetornaFilial(rbHac, new HacRadioButton(), rbCE, rbConsig);
                dtoInv.DataInventario.Value = txtData.Text;
                dtoInv.IdProduto.Value = dtoMatMed.Idt.Value;
                dtoInv.FlMedicamento.Value = medicamento ? 1 : 0;
                if (medicamento) dtoInv.CodLote.Value = codLote;
                InventarioMatMedDataTable dtbItem = InventarioMatMed.Listar(dtoInv);
                if (dtbItem.Rows.Count > 0) dtoInv = dtbItem.TypedRow(0);

                dtoInventario.Qtde1.Value = new Framework.DTO.TypeDecimal();
                dtoInventario.Qtde2.Value = new Framework.DTO.TypeDecimal();
                dtoInventario.Qtde3.Value = new Framework.DTO.TypeDecimal();
                dtoInventario.QtdeFinal.Value = new Framework.DTO.TypeDecimal();

                dtoInventario.DtAtualizacao.Value = dtInicioProcesso;
                dtoInventario.IdProduto.Value = dtoMatMed.Idt.Value;

                int numContagem = int.Parse(btnFecharNum.Text);
                if (medicamento)
                {
                    dtoInventario.CodLote.Value = codLote;
                    dtoInventario.NumLoteFab.Value = new Framework.DTO.TypeString();
                    if (numLote != null) dtoInventario.NumLoteFab.Value = numLote;

                    //Medicamento pode estar em contagem diferente
                    numContagem = ObterNumContagemAtualMedicamento();
                }
                else
                {
                    dtoInventario.CodLote.Value = new Framework.DTO.TypeString();
                    dtoInventario.NumLoteFab.Value = new Framework.DTO.TypeString();
                }

                switch (numContagem)
                {
                    case 1:
                        if (dtoInv != null && !dtoInv.Qtde1.Value.IsNull)
                            dtoInventario.QtdeFinal.Value = (int)dtoInv.Qtde1.Value + qtde;
                        else
                            dtoInventario.QtdeFinal.Value = qtde;

                        dtoInventario.Qtde1.Value = dtoInventario.QtdeFinal.Value;
                        break;
                    case 2:
                        if (dtoInv != null && !dtoInv.Qtde2.Value.IsNull)
                            dtoInventario.QtdeFinal.Value = (int)dtoInv.Qtde2.Value + qtde;
                        else
                            dtoInventario.QtdeFinal.Value = qtde;

                        dtoInventario.Qtde2.Value = dtoInventario.QtdeFinal.Value;
                        break;
                    case 3:
                        if (dtoInv != null && !dtoInv.Qtde3.Value.IsNull)
                            dtoInventario.QtdeFinal.Value = (int)dtoInv.Qtde3.Value + qtde;
                        else
                            dtoInventario.QtdeFinal.Value = qtde;

                        dtoInventario.Qtde3.Value = dtoInventario.QtdeFinal.Value;
                        break;
                }
                dtoInventario.IdUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;                
                if (dtoInventario.Fechamento.Value.IsNull) dtoInventario.Fechamento.Value = numContagem - 1;
                if (origemImportacao)
                    InventarioMatMed.Gravar(dtoInventario, codBarra, qtde);
                else
                {
                    if (cmbGrupo.SelectedIndex > 0) dtoInventario.IdtGrupo.Value = cmbGrupo.SelectedValue.ToString();
                    InventarioMatMed.Gravar(dtoInventario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }            

            this.Cursor = Cursors.Default;
        }

        private string GerarHash(byte[] b)
        {
            try
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                b = md5.ComputeHash(b);

                StringBuilder strMd5 = new StringBuilder();
                foreach (byte bs in b)
                {
                    strMd5.Append(bs.ToString("x2").ToLower());
                }
                return strMd5.ToString().Substring(0, 16);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na geração do Hash do arquivo. " + ex.Message, "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }            
        }

        private void ImportarDigitacaoPalm()
        {
            if (MessageBox.Show("Deseja realmente adicionar os dados de um arquivo TXT para esta contagem ?", "Gestão de Materiais e Medicamentos",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                openFileDialog.Filter = "Arquivos txt (*.txt)|*.txt|Todos os Arquivos (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.FileName.Substring(openFileDialog.FileName.Length - 4, 4).ToLower() != ".txt")
                    {
                        MessageBox.Show("Arquivo tem que ser .txt", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        openFileDialog.Dispose();
                        this.Cursor = Cursors.Default;
                        return;
                    }
                    this.Cursor = Cursors.WaitCursor;  
                  
                    string conteudoTXT = string.Empty;                    
                    StreamReader arquivoTextoValidar = new StreamReader(openFileDialog.OpenFile());                    
                    while (!arquivoTextoValidar.EndOfStream)
                    {
                        conteudoTXT += arquivoTextoValidar.ReadLine();
                    }
                    arquivoTextoValidar.Close();

                    string hash = this.GerarHash(Encoding.UTF8.GetBytes(conteudoTXT));
                    DataTable dtbHash = InventarioMatMed.ListarHashImportacaoPalmTXT(dtoInventario, hash);

                    if (dtbHash.Rows.Count > 0)
                    {
                        MessageBox.Show("NÃO FOI POSSÍVEL IMPORTAR ESTE ARQUIVO, POIS O MESMO JÁ FOI IMPORTADO ANTERIORMENTE PARA ESTE ESTOQUE, FAVOR VERIFICAR !!!", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        openFileDialog.Dispose();
                        this.Cursor = Cursors.Default;
                        return;
                    }

                    DateTime dtInicioProcesso = Utilitario.ObterDataHoraServidor();
                    StreamReader arquivoTexto = new StreamReader(openFileDialog.OpenFile());
                    int contLinha = 0, qtdImportada = 0, qtde;
                    string linha, codBarra;
                    string[] arrLinha;

                    while (!arquivoTexto.EndOfStream)
                    {
                        try
                        {
                            contLinha += 1;
                            linha = arquivoTexto.ReadLine();                            
                            if (contLinha == 1 && linha.Length > 24) //!= 24)
                            {
                                MessageBox.Show("Arquivo com formatação inválida.", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                openFileDialog.Dispose();
                                this.Cursor = Cursors.Default;
                                return;
                            }
                            if (string.IsNullOrEmpty(linha)) continue;
                            
                            //codBarra = linha.Substring(0, 18).Trim();
                            //qtde = int.Parse(linha.Substring(18, 6));

                            arrLinha = linha.Split(';');

                            codBarra = arrLinha[0].ToString().Trim();
                            qtde = int.Parse(arrLinha[1].ToString().Trim());

                            if (codBarra.Length > 5 && codBarra.Length <= 18)
                            {
                                CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();
                                dtoCodigoBarra.CdBarra.Value = codBarra.Trim();
                                dtoCodigoBarra.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC;
                                // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
                                dtoMatMed = MatMed.BuscaCodigoBarra(dtoCodigoBarra);

                                if (dtoMatMed == null || dtoMatMed.Idt.Value.IsNull)
                                {
                                    //MessageBox.Show("Código não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                                    
                                    GravarLogImportacaoCodNaoEncontrado(false, qtde, codBarra, dtInicioProcesso);
                                    continue;
                                }
                                else
                                {
                                    if (Convert.ToInt16(dtoMatMed.IdtGrupo.Value) != 1)
                                    {
                                        if (cmbGrupo.SelectedIndex > 0)
                                        {
                                            if (Convert.ToInt16(dtoMatMed.IdtGrupo.Value) != Convert.ToInt16(cmbGrupo.SelectedValue.ToString())) continue;                                            
                                        }
                                        dtoMatMed.IdtLote.Value = new Framework.DTO.TypeDecimal();
                                        //Add. Material
                                        this.AdicionarQtdMed(false, qtde, codBarra, dtInicioProcesso, true);
                                        qtdImportada += 1;
                                    }
                                    else if (dtoMatMed.IdtLote.Value.IsNull || (int)dtoMatMed.IdtLote.Value == 0)
                                    {
                                        //MessageBox.Show("LOTE NÃO IDENTIFICADO !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        GravarLogImportacaoCodNaoEncontrado(false, qtde, codBarra, dtInicioProcesso);
                                        continue;
                                    }
                                    else
                                    {   //Add. Medicamento
                                        this.AdicionarQtdMed(true, qtde, codBarra, dtInicioProcesso, true);
                                        qtdImportada += 1;
                                    }
                                }                                
                            }
                        }
                        catch (Exception ex)
                        {
                            InventarioMatMed.ExcluirArquivoSalvoImportacaoPalmTXT(dtoInventario);

                            MessageBox.Show("Erro na importação do arquivo, dado ou alguma formatação inválida, linha " + contLinha.ToString() + " -> " + ex.Message, "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Error);                            
                            openFileDialog.Dispose();                            

                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }
                    if (qtdImportada > 0)
                    {
                        MessageBox.Show("Foram importados " + qtdImportada.ToString() + " registros com sucesso para a contagem deste inventário.", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        openFileDialog.Dispose();

                        dtoInventario.DtAtualizacao.Value = dtInicioProcesso;
                        InventarioMatMed.InserirHash(dtoInventario, hash);
                        
                        CarregarDigitacao();
                    }
                    else
                        MessageBox.Show("NENHUM ITEM FOI IMPORTADO", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void ImportarInventario()
        {
            bool arquivoImportado = false;
            if (lblInventarioTerceirizado.Visible)
            {
                openFileDialog.Filter = "Arquivos txt (*.txt)|*.txt|Todos os Arquivos (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    StreamReader arquivoTexto = new StreamReader(openFileDialog.OpenFile());
                    int contLinha = 0; 
                    string[] linha;
                    decimal idFilial, idSetor;
                    InventarioMatMedDTO dtoInv = new InventarioMatMedDTO();
                    //CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();
                    MaterialMedicamentoDTO dtoProduto;

                    dtoInv.IdSetor.Value = cmbSetor.SelectedValue.ToString();
                    dtoInv.IdFilial.Value = new Generico().RetornaFilial(rbHac, rbAcs, rbCE, rbConsig);
                    dtoInv.DataInventario.Value = DateTime.Parse(txtData.Text).Date;
                    dtoInv.IdUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    //dtoCodigoBarra.IdtFilial.Value = rbCE.Checked ? (decimal)FilialMatMedDTO.Filial.HAC : dtoInv.IdFilial.Value;

                    while (!arquivoTexto.EndOfStream)
                    {
                        try
                        {
                            contLinha += 1;
                            linha = arquivoTexto.ReadLine().Split(';');
                            if (linha.Length == 1) continue;
                            if (contLinha == 1)
                            {
                                idFilial = decimal.Parse(linha[0].ToString().Trim());
                                if (idFilial == 3) idFilial = (decimal)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
                                idSetor = decimal.Parse(linha[1].ToString().Trim());

                                if (idFilial != (decimal)dtoInv.IdFilial.Value ||
                                    idSetor != (decimal)dtoInv.IdSetor.Value)
                                {
                                    MessageBox.Show("Não foi possível realizar a importação. Arquivo não correspondente a este Setor/Estoque. ", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    openFileDialog.Dispose();
                                    this.Cursor = Cursors.Default;
                                    return;
                                }
                            }

                            dtoProduto = new MaterialMedicamentoDTO();
                            dtoProduto.Idt.Value = decimal.Parse(linha[2].ToString().Trim());
                            dtoProduto = MatMed.SelChave(dtoProduto);

                            if (dtoProduto != null)                            
                                dtoInv.IdProduto.Value = dtoProduto.Idt.Value;                            
                            else
                            {
                                MessageBox.Show("Não foi possível realizar a importação. Produto não identificado, linha " + contLinha.ToString() + " COD_PRODUTO = " + linha[2].ToString().Trim(), "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                openFileDialog.Dispose();
                                this.Cursor = Cursors.Default;
                                return;
                            }

                            dtoInv.QtdeFinal.Value = decimal.Parse(linha[3].ToString().Trim());
                            dtoInv.Qtde1.Value = dtoInv.QtdeFinal.Value;

                            if (cmbGrupo.SelectedIndex > 0) dtoInv.IdtGrupo.Value = cmbGrupo.SelectedValue.ToString();

                            InventarioMatMed.Gravar(dtoInv);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro na importação do arquivo, dado ou alguma formatação inválida, linha " + contLinha.ToString() + " -> " + ex.Message, "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            openFileDialog.Dispose();
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }                    
                    openFileDialog.Dispose();
                    arquivoImportado = true;
                    this.Cursor = Cursors.Default;
                }
            }
            if (!lblInventarioTerceirizado.Visible || arquivoImportado)
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
                    int? idGrupo = null;
                    if (!dtoInventario.IdtGrupo.Value.IsNull) idGrupo = (int)dtoInventario.IdtGrupo.Value;
                    Movimento.ImportaInventario(dtoMovimentacao, idGrupo);
                    MessageBox.Show("Dados do inventário importados para o estoque com sucesso", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível importar os dados do inventário " + ex.Message, "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Cursor = Cursors.Default;
            }
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

        private bool ValidarProdutoRegra(MaterialMedicamentoDTO dtoMatMed)
        {
            if (Convert.ToInt16(dtoMatMed.IdtGrupo.Value) == 1)
            {
                MessageBox.Show("Não é permitido digitação de MEDICAMENTO nesta tela !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (cmbGrupo.SelectedIndex > 0)
            {
                if (Convert.ToInt16(dtoMatMed.IdtGrupo.Value) != Convert.ToInt16(cmbGrupo.SelectedValue.ToString()))
                {
                    MessageBox.Show("Grupo de produto não permitido neste inventário !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            if (rbAcs.Checked)
            {
                if (Convert.ToDecimal(dtoMatMed.Tabelamedica.Value) == (decimal)MaterialMedicamentoDTO.TipoMatMed.MATERIAL)
                {
                    MessageBox.Show("Não pode ter material no estoque do ACS", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if (dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM)
                {
                    MessageBox.Show("Não pode ter fracionado no estoque do ACS", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            if (Convert.ToDecimal(dtoMatMed.IdtGrupo.Value) == 4 &&
                Convert.ToDecimal(dtoMatMed.IdtSubGrupo.Value) == 942) //ALIMENTOS NAO ESTOCAVEIS
            {
                MessageBox.Show("Não é permitido contagem para 'ALIMENTOS NAO ESTOCAVEIS'", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (Convert.ToDecimal(dtoMatMed.IdtGrupo.Value) == 61 && !rbConsig.Checked)
            {
                MessageBox.Show("Não é permitido contagem para 'PRÓTESE, ÓRTESE, SÍNTESE'", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void GerarTXT()
        {
            this.Cursor = Cursors.WaitCursor;
            InventarioMatMedDTO dtoInv = new InventarioMatMedDTO();

            dtoInv.IdSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoInv.IdFilial.Value = new Generico().RetornaFilial(rbHac, rbAcs, rbCE, rbConsig);
            dtoInv.DataInventario.Value = DateTime.Parse(txtData.Text).Date;
            
            DataTable dtbItens = InventarioMatMed.ListarTXT(dtoInv);
            if (dtbItens.Rows.Count > 0)
            {
                sfDir.Filter = "Arquivos txt (*.txt)|*.txt";
                sfDir.FileName = (rbCE.Checked ? "CE" : (rbConsig.Checked ? "CONS" : (rbHac.Checked ? "HAC" : "ACS"))) + "-" + cmbSetor.Text.Replace(" ", "_") + "--" + DateTime.Parse(txtData.Text).Date.ToString("dd-MM-yyyy");
                if (sfDir.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter arqTexto = new StreamWriter(sfDir.FileName);
                    string filialArq = rbCE.Checked ? "3" : dtoInv.IdFilial.Value.ToString(); //No arquivo, filial do CE é 3 e não 4
                    decimal filialCodBarra = (rbCE.Checked ? (decimal)FilialMatMedDTO.Filial.HAC : (decimal)dtoInv.IdFilial.Value); //Passar HAC pra CE
                    foreach (DataRow row in dtbItens.Rows)
                    {
                        arqTexto.WriteLine(string.Format("{0};{1};{2};{3}",
                                                         filialArq,
                                                         cmbSetor.SelectedValue.ToString(),
                                                         row[InventarioMatMedDTO.FieldNames.IdProduto].ToString(), //CodigoBarra.ObterCodigo(filialCodBarra, decimal.Parse(row[InventarioMatMedDTO.FieldNames.IdProduto].ToString())),
                                                         row["CAD_MTMD_QTDE_ANTERIOR"].ToString()));
                    }
                    arqTexto.Close();
                    MessageBox.Show("Arquivo gerado com sucesso.", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Não há dados para gerar txt.", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            this.Cursor = Cursors.Default;
        }

        //Validar se setor usar estoque compartilhado (task 40478)
        private bool ValidarEstoqueCompartilhado()
        {
            if ((rbHac.Checked || rbAcs.Checked || rbCE.Checked || rbConsig.Checked) && ValidarSetor(false))
            {
                EstoqueLocalDTO dtoEstoque = new EstoqueLocalDTO();
                dtoEstoque.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                dtoEstoque.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                dtoEstoque.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                if (rbHac.Checked)
                    dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                else if (rbAcs.Checked)
                    dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
                else if (rbCE.Checked)
                    dtoEstoque.IdtFilial.Value = (int)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
                else if (rbConsig.Checked)
                    dtoEstoque.IdtFilial.Value = (int)FilialMatMedDTO.Filial.CONSIGNADO;

                this.Cursor = Cursors.WaitCursor;
                int idSetorEstoque = Estoque.EstoqueDeConsumo(dtoEstoque);
                this.Cursor = Cursors.Default;

                if (idSetorEstoque != int.Parse(cmbSetor.SelectedValue.ToString()))
                {
                    SetorDTO dtoSetor = new SetorDTO();
                    dtoSetor.Idt.Value = idSetorEstoque;                    
                    MessageBox.Show("Este Setor/Estoque não pode ser selecionado, pois utiliza o estoque do(a) " + Setor.SelChave(dtoSetor).Descricao.Value, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    cmbSetor.SelectedIndex = -1;
                    rbAcs.Enabled = true;
                    lblEstoqueUnificado.Text = string.Empty;
                    rbHac.Checked = rbAcs.Checked = rbCE.Checked = rbConsig.Checked = false;

                    return false;
                }

                if (rbCE.Checked)
                {                    
                    bool EstoqueCentroDispensacao = Estoque.EstoqueCentroDispensacao(dtoEstoque);
                    if (EstoqueCentroDispensacao)
                    {
                        MessageBox.Show("Estoque CE não pode ser selecionado para este setor, pois é um Centro de Dispensação.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        rbHac.Checked = rbAcs.Checked = rbCE.Checked = rbConsig.Checked = false;
                    }

                    return false;
                }
            }
            return true;
        }

        private void RegraHabilitarGrupo()
        {
            if (ValidarSetor(false))
            {
                Generico gen = new Generico();
                if (gen.SetorAlmoxCentral(int.Parse(cmbSetor.SelectedValue.ToString())) ||
                    gen.SetorFarmacia(int.Parse(cmbSetor.SelectedValue.ToString())))
                    cmbGrupo.Enabled = true;
            }
        }

        #endregion

        #region EVENTOS

        private void FrmInventarioDigitacao_Load(object sender, EventArgs e)
        {
            cmbUnidade.Carregaunidade();
            dtgImportacoes.AutoGenerateColumns = false;
            dtgImportacoes.Columns[colDataImport.Name].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            tsHac.Items["tsBtnMatMed"].Enabled = true;
            btnFecharNum.Enabled = false;
            txtData.Text = Utilitario.ObterDataHoraServidor().ToString("dd/MM/yyyy");
            grbCodBarra.Visible = true;
            //grbCodBarra.Visible = new Generico().LogadoSetorFarmacia() || (int)FrmPrincipal.dtoSeguranca.IdtSetor.Value == 29; //Farm ou Almox.

            DataTable dtGrupo = GrupoMatMed.Sel(new GrupoMatMedDTO());
            DataRow rowSel = dtGrupo.NewRow();
            rowSel[0] = -1; rowSel[1] = "<< TODOS >>";
            dtGrupo.Rows.InsertAt(rowSel, 0);
            cmbGrupo.DataSource = dtGrupo;
            cmbGrupo.Enabled = false;
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
                else if (!ValidarProdutoRegra(dtoMatMed))
                {
                    txtCodProduto.Text = string.Empty;
                    txtCodProduto.Focus();
                    return;
                }

                //this.AdicionarQtdMed(false, 1, null, DateTime.Now, false);
                                
                int rowIndexItem;
                if (RegistroJaExistente(int.Parse(dtoMatMed.Idt.Value), -1, out rowIndexItem))
                {
                    dtgMatMed.ClearSelection(); AtualizaGridEmEdicao();                    
                    dtgMatMed.CurrentCell = dtgMatMed.Rows[rowIndexItem].Cells[colQtd.Name];

                    int qtdAtual = 0;
                    if (!string.IsNullOrEmpty(dtgMatMed.Rows[rowIndexItem].Cells[colQtd.Name].Value.ToString()))
                        qtdAtual = int.Parse(dtgMatMed.Rows[rowIndexItem].Cells[colQtd.Name].Value.ToString());

                    dtgMatMed.Rows[rowIndexItem].Cells[colQtd.Name].Value = qtdAtual + 1;
                    dtgMatMed.Rows[rowIndexItem].Cells[colDataAtualiza.Name].Value = Utilitario.ObterDataHoraServidor();
                    dtgMatMed.Sort(dtgMatMed.Columns[colDataAtualiza.Name], ListSortDirection.Descending);
                }
                else
                {
                    if (dtgMatMed.Rows.Count == 0 ||
                        (dtgMatMed.Rows[0].Cells[colIdt.Name].Value != null && dtgMatMed.Rows[0].Cells[colIdt.Name].Value.ToString() != string.Empty))
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dtgMatMed);
                        dtgMatMed.Rows.Insert(0, row);                        
                    }

                    dtgMatMed.ClearSelection(); AtualizaGridEmEdicao();
                    dtgMatMed.CurrentCell = dtgMatMed.Rows[0].Cells[colQtd.Name];
                    dtgMatMed.Rows[0].Cells[colIdt.Name].Value = dtoMatMed.Idt.Value.ToString();
                    dtgMatMed.Rows[0].Cells[colDataAtualiza.Name].Value = Utilitario.ObterDataHoraServidor();
                    dtgMatMed.Rows[0].Cells[colQtd.Name].Value = 1;                    
                }                
                //dtgMatMed.CurrentCell = dtgMatMed.Rows[dtgMatMed.RowCount - 1].Cells[colIdt.Name];
                dtgMatMed.CurrentCell = dtgMatMed.Rows[0].Cells[colIdt.Name];
                txtCodProduto.Text = string.Empty;
                txtCodProduto.Focus();                
            }
        }

        private void txtData_Enter(object sender, EventArgs e)
        {
            txtData.Text = string.Empty;
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbSetor.SelectedValue == null) return;

            MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();
            dtoCfg.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoCfg.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoCfg.Idtsetor.Value = cmbSetor.SelectedValue.ToString();
            dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);
            if (dtoCfg.EstoqueUnificadoHAC.Value.IsNull) dtoCfg.EstoqueUnificadoHAC.Value = 0;
            if (dtoCfg.EstoqueUnificadoHAC.Value == 1)
            {
                //rbCE.Text = "EU";
                //rbCE.ForeColor = Color.Green;
                rbAcs.Enabled = rbAcs.Checked = false;                
                lblEstoqueUnificado.Text = "ESTOQUE ÚNICO HAC";
            }
            else
            {
                //rbCE.Text = "CE";
                //rbCE.ForeColor = Color.Black;
                rbAcs.Enabled = true;
                lblEstoqueUnificado.Text = string.Empty;
            }
            if (sender != null) ValidarEstoqueCompartilhado();

            cmbGrupo.Enabled = false;
            cmbGrupo.SelectedIndex = 0;
            RegraHabilitarGrupo();
        }

        private void rbEstoque_Click(object sender, EventArgs e)
        {
            ValidarEstoqueCompartilhado();
            if (rbConsig.Checked)
            {
                btnImportarArqPalm.Enabled = false;
                cmbGrupo.Enabled = false;
                cmbGrupo.SelectedIndex = 0;
            }
            else
            {
                btnImportarArqPalm.Enabled = true;
                RegraHabilitarGrupo();
            }
        }
                
        private bool tsHac_LimparClick(object sender)
        {
            if (dtgMatMed.CurrentCell != null && dtgMatMed.CurrentCell.IsInEditMode)
            {
                MessageBox.Show("Grid não pode estar em edição", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            btnImportarArqPalm.Enabled = true;
            lblDigitacao.Text = string.Empty;
            gbEstoque.Enabled = true;
            //dtgMatMed.Enabled = false;
            dtgMatMed.ReadOnly = true;
            try { dtgMatMed.Columns[colDel.Name].Visible = false; } catch { } //Quando célula em branco estava dando erro aqui
            btnFecharNum.Enabled = false;
            ConfigurarControles(gbEstoque.Controls, true);
            _limparGrid = true;
            dtgMatMed.Rows.Clear();
            _limparGrid = false;            
            AtualizarQtdFinal();
            lblContagemFechada.Text = "0";
            btnFecharNum.Text = "-";
            lblInventarioTerceirizado.Visible = btnGerarTXT.Visible = false;
            txtData.Text = Utilitario.ObterDataHoraServidor().ToString("dd/MM/yyyy");            
            dtoInventario = null;
            _dataInicioInv = null;
            _carregarDigitacaoPosExclusaoArquivo = false;
            btnFecharInventAndamento_Click(null, null);
            btnFecharImport_Click(null, null);
            return true;
        }

        private void tsHac_AfterLimpar(object sender)
        {
            tsHac.Items["tsBtnMatMed"].Enabled = true;
            lblEstoqueUnificado.Text = string.Empty;
            //rbAcs.Enabled = true;
            btnImportarArqPalm.Visible = btnImportacoes.Visible = false;
            txtCodProduto.Enabled = cbDigitar.Enabled = false;
        }

        private bool tsHac_MatMedClick(object sender)
        {
            if (pnlImportacoes.Visible) btnFecharImport_Click(sender, null);
            if (!gbEstoque.Enabled && cbAndamento.Checked)
            {
                if (dtgMatMed.Rows.Count > 0 &
                    dtgMatMed.Rows[dtgMatMed.RowCount - 1].Cells[colIdt.Name].Value != null &&
                    dtgMatMed.Rows[dtgMatMed.RowCount - 1].Cells[colIdt.Name].Value.ToString() != string.Empty &&
                    dtgMatMed.Rows[dtgMatMed.RowCount - 1].Cells[colQtd.Name].Value == null) return false;

                MaterialMedicamentoDTO dtoMatMedAux = new MaterialMedicamentoDTO();
                dtoMatMedAux.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.SEM_ESTOQUE;
                dtoMatMedAux.FlAtivo.Value = 1;
                dtoMatMedAux = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMedAux);
                if (dtoMatMedAux != null)
                {
                    if (!dtoMatMedAux.Idt.Value.IsNull)
                    {
                        if (!ValidarProdutoRegra(dtoMatMedAux)) return false;                        

                        if (dtgMatMed.Rows.Count == 0 ||
                            (dtgMatMed.Rows[dtgMatMed.RowCount - 1].Cells[colIdt.Name].Value != null &&
                             dtgMatMed.Rows[dtgMatMed.RowCount - 1].Cells[colIdt.Name].Value.ToString() != string.Empty))
                            dtgMatMed.Rows.Add();

                        dtgMatMed.Rows[dtgMatMed.RowCount - 1].Cells[colIdt.Name].Value = dtoMatMedAux.Idt.Value.ToString();
                        dtgMatMed.Rows[dtgMatMed.RowCount - 1].Cells[colDataAtualiza.Name].Value = Utilitario.ObterDataHoraServidor();
                    }

                }
            }            
            return true;
        }

        private void tsInventAndamento_Click(object sender, EventArgs e)
        {
            if (pnlImportacoes.Visible) btnFecharImport_Click(null, null);
            cbFinalizados.Checked = false;
            CarregarInventariosAndamento();
            dtgMatMed.Visible = txtCodProduto.Enabled = false;            
            pnlInventAnda.Visible = true;
            dtgInventariosAndamento.Visible = true;
            btnVerificar.Enabled = false;            
        }

        private void tsImportar_Click(object sender, EventArgs e)
        {
            if (pnlImportacoes.Visible) btnFecharImport_Click(sender, e);
            if (gbEstoque.Enabled || !cbAndamento.Checked)
            {
                MessageBox.Show("Carregue antes o inventário em andamento de um estoque/setor.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (lblContagemFechada.Text == "-" || (lblContagemFechada.Text != "-" && byte.Parse(lblContagemFechada.Text) < 1))
            {
                //MessageBox.Show("É necessário fechar a 1° contagem.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("ALERTA: NENHUMA CONTAGEM FOI FECHADA !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //return;
            }
            if (_dataInicioInv != null)
            {
                if (InventarioMatMed.InventarioImportando(dtoInventario, _dataInicioInv.Value))
                {
                    MessageBox.Show("INVENTÁRIO DE MATERIAIS JÁ IMPORTADO OU EM PROCESSAMENTO !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (MessageBox.Show("Deseja realmente zerar o estoque referente a este inventário e importar esta contagem para o respectivo setor?", "Gestão de Materiais e Medicamentos",
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
            if (ValidarSetor(true) && ValidarFilial() && ValidarData()) CarregarDigitacao();
        }

        private void btnFecharNum_Click(object sender, EventArgs e)
        {   
            if (gbEstoque.Enabled || !cbAndamento.Checked)
            {
                MessageBox.Show("Carregue os dados do inventário em andamento de um estoque/setor para poder fechar sua contagem.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (btnFecharNum.Text == "-" && !gbEstoque.Enabled && cbAndamento.Checked)
            {
                MessageBox.Show("Fechamento de contagem já encerrado, pois já foram fechadas as 3 digitações.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (btnFecharNum.Text == "-")
            {
                MessageBox.Show("Digitação não carregada.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Deseja realmente fechar a contagem do estoque selecionado deste setor?", "Gestão de Materiais e Medicamentos",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                InventarioMatMedDTO dtoInv = new InventarioMatMedDTO();

                dtoInv.IdSetor.Value = cmbSetor.SelectedValue.ToString();
                dtoInv.IdFilial.Value = new Generico().RetornaFilial(rbHac, rbAcs, rbCE, rbConsig);
                dtoInv.DataInventario.Value = txtData.Text;
                dtoInv.FlMedicamento.Value = 0;
                if (cmbGrupo.SelectedIndex > 0) dtoInv.IdtGrupo.Value = cmbGrupo.SelectedValue.ToString();
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
                dtoInventario.FlMedicamento.Value = 0;
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
                _naoMostraMsg = true;
                CarregarDigitacao();
                _naoMostraMsg = false;
            }            
        }

        private void btnFecharInventAndamento_Click(object sender, EventArgs e)
        {
            btnVerificar.Enabled = true;
            pnlInventAnda.Visible = false;
            dtgMatMed.Visible = true;
            if (dtgMatMed.Enabled)
            {
                txtCodProduto.Enabled = true;
                dtgMatMed.Focus();
            }
        }

        private void btnGerarTXT_Click(object sender, EventArgs e)
        {
            if (gbEstoque.Enabled || !cbAndamento.Checked)
            {
                MessageBox.Show("Carregue antes o inventário em andamento de um estoque/setor.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            
            if (MessageBox.Show("Deseja realmente gerar o arquivo .txt para importar os dados deste estoque para o software da empresa que realizará a contagem ?", "Gestão de Materiais e Medicamentos",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.GerarTXT();
            }
        }

        private void btnImportarArqPalm_Click(object sender, EventArgs e)
        {
            if (gbEstoque.Enabled || !cbAndamento.Checked)
            {
                MessageBox.Show("Carregue antes o inventário em andamento de um estoque/setor.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!tsImportar.Enabled)
            {
                MessageBox.Show("Inventário já importado para o estoque, impossibilitando qualquer importação de arquivo para a contagem deste setor.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.ImportarDigitacaoPalm();            
        }

        private void btnImportacoes_Click(object sender, EventArgs e)
        {
            if (gbEstoque.Enabled || !cbAndamento.Checked)
            {
                MessageBox.Show("Carregue antes o inventário em andamento de um estoque/setor.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CarregarImportacoes();
        }

        private void btnFecharImport_Click(object sender, EventArgs e)
        {
            pnlImportacoes.Visible = false;
            dtgImportacoes.DataSource = null;
            if (_carregarDigitacaoPosExclusaoArquivo)
            {
                CarregarDigitacao();
                _carregarDigitacaoPosExclusaoArquivo = false;
            }
        }

        private void cbAndamento_Click(object sender, EventArgs e)
        {
            if (gbEstoque.Enabled)
            {
                cbAndamento.Checked = !cbAndamento.Checked;
                MessageBox.Show("Carregue antes o inventário de um estoque/setor.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbAndamento.Checked && DateTime.Parse(txtData.Text) < Utilitario.ObterDataHoraServidor().Date.AddMonths(-1))
            {
                cbAndamento.Checked = false;
                MessageBox.Show("Não pode ser ativado um inventário com data anterior a 1 mês.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtoInventario.Fechamento.Value == 3 && cbAndamento.Checked)
            {
                cbAndamento.Checked = false;
                MessageBox.Show("Este inventário não pode ser reativado, pois a contagem deste estoque/setor já foi finalizada nesta data.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cbAndamento.Checked && InventarioExistenteDiaAnterior())
                MessageBox.Show("ALERTA: HOUVE UM INVENTÁRIO DESTE ESTOQUE NO DIA ANTERIOR, VERIFIQUE SE REALMENTE É NECESSÁRIO ABRIR OUTRO !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            if (cmbGrupo.SelectedIndex == 0)
            {
                if (!cbAndamento.Checked && InventarioMatMed.InventarioImportado(dtoInventario) == null)
                    MessageBox.Show("ALERTA: INVENTÁRIO DE MATERIAIS AINDA NÃO IMPORTADO !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else if (!cbAndamento.Checked && !rbConsig.Checked)
                {
                    dtoInventario.FlMedicamento.Value = 1;
                    if (!cbAndamento.Checked && InventarioMatMed.InventarioImportado(dtoInventario) == null)
                        MessageBox.Show("ALERTA: INVENTÁRIO DE MEDICAMENTO AINDA NÃO IMPORTADO. CASO ESTE SETOR NÃO TENHA MEDICAMENTO DESCONSIDERE ESTA MENSAGEM !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtoInventario.FlMedicamento.Value = 0;
                }

                if (cbAndamento.Checked)
                {
                    InventarioMatMedDTO dtoInvAtivo = new InventarioMatMedDTO();
                    dtoInvAtivo.IdSetor.Value = cmbSetor.SelectedValue.ToString();
                    dtoInvAtivo.IdFilial.Value = new Generico().RetornaFilial(rbHac, rbAcs, rbCE, rbConsig);
                    dtoInvAtivo.FlAndamento.Value = 1;
                    InventarioMatMedDataTable dtbInvAtivo = InventarioMatMed.ListarControle(dtoInvAtivo);
                    if (dtbInvAtivo.Rows.Count > 0)
                    {
                        cbAndamento.Checked = false;
                        MessageBox.Show("Este inventário geral não pode ser ativado, pois já há um de Medicamentos em andamento deste estoque/setor.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }

            //Só deixar atualizar se for gestor
            SegurancaDTO dtoUsuario;
            if (!ValidarUsuario(out dtoUsuario))
            {
                cbAndamento.Checked = !cbAndamento.Checked;
                return;
            }

            if (cmbGrupo.SelectedIndex > 0) dtoInventario.IdtGrupo.Value = cmbGrupo.SelectedValue.ToString();

            dtoInventario.IdUsuario.Value = dtoUsuario.Idt.Value;
            AtualizarStatus();
            if (cmbGrupo.SelectedIndex > 0 && dtoInventario.IdtGrupo.Value == 1 && cbAndamento.Checked)
            {
                InventarioMatMedDTO dtoInvMed = new InventarioMatMedDTO();

                dtoInvMed.IdSetor.Value = dtoInventario.IdSetor.Value;
                dtoInvMed.IdFilial.Value = dtoInventario.IdFilial.Value;                
                dtoInvMed.DataInventario.Value = txtData.Text;
                if (cmbGrupo.SelectedIndex > 0) dtoInvMed.IdtGrupo.Value = cmbGrupo.SelectedValue.ToString();

                SetorDTO dtoSetor = new SetorDTO();
                dtoSetor.Idt.Value = dtoInvMed.IdSetor.Value;
                dtoSetor = Setor.SelChave(dtoSetor);

                FrmInventarioDigitaMed.Carregar(dtoInvMed, dtoSetor);
            }
        }

        private void cbFinalizados_Click(object sender, EventArgs e)
        {
            CarregarInventariosAndamento();
        }

        #region GRIDS

        /// Solução alternativa para atualizar o grid quando está em edição.        
        private void AtualizaGridEmEdicao()
        {
            chkAjudaAtualizarGrid.Visible = true;
            chkAjudaAtualizarGrid.Focus();
            chkAjudaAtualizarGrid.Visible = false;
        }

        private void dtgMatMed_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == dtgMatMed[colIdt.Name, e.RowIndex].ColumnIndex)
                {
                    if (dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value != null &&
                        dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value.ToString().Trim() != string.Empty)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        decimal idBusca = decimal.Parse(dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value.ToString());
                        int rowIndexItem;
                        if (!RegistroJaExistente(idBusca, e.RowIndex, out rowIndexItem))
                        {
                            dtoMatMed = new MaterialMedicamentoDTO();
                            dtoMatMed.Idt.Value = idBusca.ToString();
                            dtoMatMed = MatMed.SelChave(dtoMatMed);
                            if (dtoMatMed != null)
                            {
                                if (_salvarItem && dtoMatMed.FlAtivo.Value == (byte)MaterialMedicamentoDTO.Status.NAO)
                                {
                                    MessageBox.Show("Produto inativo", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    _idInvalido = true;
                                }
                                else if (_salvarItem && !ValidarProdutoRegra(dtoMatMed))
                                {
                                    _idInvalido = true;
                                }
                                else
                                {
                                    dtgMatMed.CellValueChanged -= dtgMatMed_CellValueChanged;
                                    dtgMatMed.Rows[e.RowIndex].Cells[colDescricao.Name].Value = dtoMatMed.NomeFantasia.Value;
                                    dtgMatMed.CellValueChanged += dtgMatMed_CellValueChanged;
                                    dtgMatMed.Rows[e.RowIndex].Cells[colDescricao.Name].Style.Font = new Font(dtgMatMed.Font, FontStyle.Bold);
                                    dtgMatMed.Rows[e.RowIndex].Cells[colQtd.Name].ReadOnly = false;
                                    dtgMatMed.CurrentCell = dtgMatMed.Rows[e.RowIndex].Cells[colQtd.Name];
                                    dtgMatMed.BeginEdit(true);
                                }                                
                            }
                            else if (_salvarItem)
                            {
                                MessageBox.Show("Produto não encontrado", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                _idInvalido = true;                                
                            }
                        }
                        else if (_salvarItem)
                        {
                            MessageBox.Show("Produto já cadastrado", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            _idInvalido = true;                                                    
                        }
                        if (_idInvalido)
                        {
                            dtgMatMed.CellValueChanged -= dtgMatMed_CellValueChanged;
                            //dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value = 0;
                            dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value = string.Empty;
                            dtgMatMed.CellValueChanged += dtgMatMed_CellValueChanged;    
                        }
                        this.Cursor = Cursors.Default;
                    }
                }
                else if (e.ColumnIndex == dtgMatMed[colQtd.Name, e.RowIndex].ColumnIndex)
                {
                    bool itemValido = false;
                    if (dtgMatMed.Rows.Count > e.RowIndex - 1)
                    {
                        if (dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value == null || dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value.ToString().Trim() == string.Empty)
                        {
                            dtgMatMed.CurrentCell = dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name];
                            MessageBox.Show("Selecione o produto antes de digitar a quantidade", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            _qtdSemId = true;
                            dtgMatMed.CellValueChanged -= dtgMatMed_CellValueChanged;
                            dtgMatMed.Rows[e.RowIndex].Cells[colQtd.Name].Value = string.Empty;
                            dtgMatMed.CellValueChanged += dtgMatMed_CellValueChanged;
                        }
                        if (dtgMatMed.Rows[e.RowIndex].Cells[colQtd.Name].Value == null || dtgMatMed.Rows[e.RowIndex].Cells[colQtd.Name].Value.ToString().Trim() == string.Empty)
                        {
                            dtgMatMed.CellValueChanged -= dtgMatMed_CellValueChanged;
                            dtgMatMed.Rows[e.RowIndex].Cells[colQtd.Name].Value = _valorEdit.ToString();
                            dtgMatMed.CellValueChanged += dtgMatMed_CellValueChanged;
                            MessageBox.Show("Digite a quantidade", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Warning);                            
                            return;
                        }
                        //Se próxima linha já tiver ID, cair direto na qtd.
                        if (dtgMatMed.Rows.Count > 1)
                        {
                            if (dtgMatMed.Rows[e.RowIndex + 1].Cells[colIdt.Name].Value != null &&
                                dtgMatMed.Rows[e.RowIndex + 1].Cells[colIdt.Name].Value.ToString().Trim() != string.Empty &&
                                dtgMatMed.Rows[e.RowIndex + 1].Cells[colQtd.Name].Value != null &&
                                dtgMatMed.Rows[e.RowIndex + 1].Cells[colQtd.Name].Value.ToString().Trim() != string.Empty)
                            {
                                dtgMatMed.CurrentCell = dtgMatMed.Rows[e.RowIndex + 1].Cells[colQtd.Name];
                                itemValido = true;
                            }
                            else
                            {
                                dtgMatMed.CurrentCell = dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name];
                                itemValido = true;
                            }
                        }
                        else
                        {
                            if (dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value != null &&
                                dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value.ToString().Trim() != string.Empty &&
                                dtgMatMed.Rows[e.RowIndex].Cells[colQtd.Name].Value != null &&
                                dtgMatMed.Rows[e.RowIndex].Cells[colQtd.Name].Value.ToString().Trim() != string.Empty)
                            {
                                dtgMatMed.CurrentCell = dtgMatMed.Rows[e.RowIndex].Cells[colQtd.Name];
                                itemValido = true;
                            }
                            else
                            {
                                dtgMatMed.CurrentCell = dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name];
                                itemValido = true;
                            }
                        }
                    }
                    else
                    {
                        dtgMatMed.CurrentCell = dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name];
                        itemValido = true;
                    }
                    if (itemValido)
                    {
                        if (_salvarItem)
                        {
                            dtoInventario.IdProduto.Value = dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value.ToString();
                            dtoInventario.QtdeFinal.Value = dtgMatMed.Rows[e.RowIndex].Cells[colQtd.Name].Value.ToString();
                            switch (int.Parse(btnFecharNum.Text))
                            {
                                case 1:
                                    dtoInventario.Qtde1.Value = dtoInventario.QtdeFinal.Value;
                                    break;
                                case 2:
                                    dtoInventario.Qtde2.Value = dtoInventario.QtdeFinal.Value;
                                    break;
                                case 3:
                                    dtoInventario.Qtde3.Value = dtoInventario.QtdeFinal.Value;
                                    break;
                            }
                            if (cmbGrupo.SelectedIndex > 0) dtoInventario.IdtGrupo.Value = cmbGrupo.SelectedValue.ToString();
                            dtoInventario.IdUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                            try
                            {
                                InventarioMatMed.Gravar(dtoInventario);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dtgMatMed.Rows.Remove(dtgMatMed.Rows[e.RowIndex]);
                                AtualizarQtdFinal();
                                dtgMatMed.CurrentCell = dtgMatMed.Rows[dtgMatMed.RowCount - 1].Cells[colIdt.Name];
                                return;
                            }                            
                            dtgMatMed.Rows[e.RowIndex].Cells[colQtd.Name].Style.BackColor = Color.LightGray;
                            dtgMatMed.Rows[e.RowIndex].Cells[colDataAtualiza.Name].Value = DateTime.Now;
                        }                        

                        //dtgMatMed.Sort(dtgMatMed.Columns[colDescricao.Name], ListSortDirection.Ascending);
                        AtualizarQtdFinal();
                    } 
                }                
            }
        }

        private void dtgMatMed_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!_limparGrid)
            {
                if (_qtdSemId || _idInvalido ||
                    (dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value != null && dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value.ToString() != string.Empty &&
                    (dtgMatMed.Rows[e.RowIndex].Cells[colQtd.Name].Value == null || dtgMatMed.Rows[e.RowIndex].Cells[colQtd.Name].Value.ToString() == string.Empty)))
                {
                    _idInvalido = false;
                    _qtdSemId = false;
                    e.Cancel = true;
                }
                else
                {
                    dtgMatMed.Rows[e.RowIndex].Cells[colDescricao.Name].Style.Font = new Font(dtgMatMed.Font, FontStyle.Regular);
                }
            }
        }

        private void dtgMatMed_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dtgMatMed.CurrentCell.Selected) e.Control.KeyPress += this.CellNumber_KeyPress;
        }

        private void CellNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b') e.Handled = true;
        }

        private void dtgMatMed_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {                
                if (e.ColumnIndex == dtgMatMed[colDel.Name, e.RowIndex].ColumnIndex)
                {
                    if (dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value == null || dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value.ToString() == string.Empty) return;

                    //Verificar Saldo Estoque Online
                    EstoqueLocalDTO dtoEstoque = new EstoqueLocalDTO();
                    dtoEstoque.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                    dtoEstoque.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                    dtoEstoque.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                    dtoEstoque.IdtProduto.Value = dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value.ToString();
                    if (rbHac.Checked)
                        dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;                    
                    else if (rbAcs.Checked)                    
                        dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;                    
                    else if (rbCE.Checked)                    
                        dtoEstoque.IdtFilial.Value = (int)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
                    else if (rbConsig.Checked)
                        dtoEstoque.IdtFilial.Value = (int)FilialMatMedDTO.Filial.CONSIGNADO;
                    dtoEstoque = Estoque.EstoqueLocalProduto(dtoEstoque);
                    if (dtoEstoque.Qtde.Value.IsNull) dtoEstoque.Qtde.Value = 0;
                    if (dtoEstoque.Qtde.Value > 0)
                    {
                        MessageBox.Show("Este produto não pode ser excluído, pois tem saldo anterior", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (dtoInventario.Fechamento.Value != 0)
                    {
                        InventarioMatMedDTO dtoInv = new InventarioMatMedDTO();
                        dtoInv.IdSetor.Value = cmbSetor.SelectedValue.ToString();
                        dtoInv.IdFilial.Value = new Generico().RetornaFilial(rbHac, rbAcs, rbCE, rbConsig);
                        dtoInv.DataInventario.Value = txtData.Text;
                        dtoInv.IdProduto.Value = dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value.ToString();
                        InventarioMatMedDataTable dtbItem = InventarioMatMed.Listar(dtoInv);
                        if (dtbItem.Rows.Count > 0) dtoInv = dtbItem.TypedRow(0);
                        if (dtoInventario.Fechamento.Value == 1)
                        {
                            if (dtoInv.Qtde1.Value > 0)
                            {
                                MessageBox.Show("Este produto não pode ser excluído, pois tem saldo na 1° digitação", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                        if (dtoInventario.Fechamento.Value == 2)
                        {
                            if (dtoInv.Qtde1.Value > 0 || dtoInv.Qtde2.Value > 0)
                            {
                                MessageBox.Show("Este produto não pode ser excluído, pois tem saldo em digitação anterior", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                    }

                    if (MessageBox.Show("O produto que será excluído será removido de todas as contagens do inventário deste setor, deseja realmente excluir este produto da lista ?",
                                        "Gestão de Materiais e Medicamentos",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool erroItemNaoExistente = false;
                        try 
                        {
                            dtoInventario.IdProduto.Value = dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value.ToString();                            
                            InventarioMatMed.Excluir(dtoInventario);
                            dtgMatMed.Rows.Remove(dtgMatMed.Rows[e.RowIndex]);
                        }
                        catch (Exception ex)
                        {
                            //Ignorar erro ao excluir linha nao confirmada;
                            if (ex.Message.ToLower().Contains("no data found")) erroItemNaoExistente = true;
                        }
                        if (!erroItemNaoExistente)
                        {
                            AtualizarQtdFinal();
                            //dtgMatMed.CurrentCell = dtgMatMed.Rows[dtgMatMed.RowCount - 1].Cells[colIdt.Name];
                            if (dtgMatMed.Rows.Count > 0) dtgMatMed.CurrentCell = dtgMatMed.Rows[0].Cells[colIdt.Name];
                        }
                        else
                        {
                            MessageBox.Show("Produto não confirmado! Caso realmente seja um item errado e tenha que excluir, será necessário digitar 0, confirmar e posteriormente realizar a exclusão.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        txtCodProduto.Focus();                        
                    }
                }
            }
        }

        private void dtgMatMed_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (pnlImportacoes.Visible) btnFecharImport_Click(sender, e);
            _valorEdit = 0;
            if (e.RowIndex > -1)
            {
                //Não deixar digitar novamente o ID
                if (e.ColumnIndex == dtgMatMed[colIdt.Name, e.RowIndex].ColumnIndex)
                {
                    if (dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value != null &&
                        dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value.ToString() != string.Empty &&
                        dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value.ToString() != "0")
                        dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].ReadOnly = true;
                }
                //Se não tiver ID, não deixar digitar a qtd.
                if (e.ColumnIndex == dtgMatMed[colQtd.Name, e.RowIndex].ColumnIndex)
                {
                    if (dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value == null ||
                        dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value.ToString() == string.Empty ||
                        dtgMatMed.Rows[e.RowIndex].Cells[colIdt.Name].Value.ToString() == "0")
                        dtgMatMed.Rows[e.RowIndex].Cells[colQtd.Name].ReadOnly = true;
                    else if (dtgMatMed.Rows[e.RowIndex].Cells[colQtd.Name].Value != null && dtgMatMed.Rows[e.RowIndex].Cells[colQtd.Name].Value.ToString().Trim() != string.Empty)
                        _valorEdit = decimal.Parse(dtgMatMed.Rows[e.RowIndex].Cells[colQtd.Name].Value.ToString());
                }
                if (e.ColumnIndex == dtgMatMed[colDescricao.Name, e.RowIndex].ColumnIndex)
                    dtgMatMed.Rows[e.RowIndex].Cells[colDescricao.Name].ReadOnly = true;
            }
        }

        private void dtgInventariosAndamento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (pnlImportacoes.Visible) btnFecharImport_Click(sender, e);
            if (dtgInventariosAndamento.Rows.Count > 0)
            {
                if (dtgInventariosAndamento.Rows[e.RowIndex].Cells[colMedicamento.Name].Value.ToString() == "MED")
                {
                    InventarioMatMedDTO dtoInvMed = new InventarioMatMedDTO();

                    dtoInvMed.IdSetor.Value = dtgInventariosAndamento.Rows[e.RowIndex].Cells[colIdSetor.Name].Value.ToString();
                    if (decimal.Parse(dtgInventariosAndamento.Rows[e.RowIndex].Cells[colIdFilial.Name].Value.ToString()) == (decimal)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA)
                        dtoInvMed.IdFilial.Value = (decimal)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
                    else
                        dtoInvMed.IdFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC;
                    dtoInvMed.DataInventario.Value = DateTime.Parse(dtgInventariosAndamento.Rows[e.RowIndex].Cells[colData.Name].Value.ToString()).ToString("dd/MM/yyyy");
                    if (!string.IsNullOrEmpty(dtgInventariosAndamento.Rows[e.RowIndex].Cells[colIdGrupo.Name].Value.ToString()) &&
                        int.Parse(dtgInventariosAndamento.Rows[e.RowIndex].Cells[colIdGrupo.Name].Value.ToString()) != 0)
                        dtoInvMed.IdtGrupo.Value = dtgInventariosAndamento.Rows[e.RowIndex].Cells[colIdGrupo.Name].Value.ToString();

                    SetorDTO dtoSetor = new SetorDTO();
                    dtoSetor.Idt.Value = dtoInvMed.IdSetor.Value;
                    dtoSetor = Setor.SelChave(dtoSetor);

                    FrmInventarioDigitaMed.Carregar(dtoInvMed, dtoSetor);
                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    tsHac_LimparClick(null);
                    tsHac_AfterLimpar(null);

                    cmbUnidade.SelectedValue = dtgInventariosAndamento.Rows[e.RowIndex].Cells[colIdUnidade.Name].Value;
                    cmbLocal.SelectedValue = dtgInventariosAndamento.Rows[e.RowIndex].Cells[colIdLocal.Name].Value;
                    cmbSetor.SelectedValue = dtgInventariosAndamento.Rows[e.RowIndex].Cells[colIdSetor.Name].Value;
                    cmbSetor_SelectionChangeCommitted(null, null);
                    txtData.Text = DateTime.Parse(dtgInventariosAndamento.Rows[e.RowIndex].Cells[colData.Name].Value.ToString()).ToString("dd/MM/yyyy");
                    if (!string.IsNullOrEmpty(dtgInventariosAndamento.Rows[e.RowIndex].Cells[colIdGrupo.Name].Value.ToString()) &&
                        int.Parse(dtgInventariosAndamento.Rows[e.RowIndex].Cells[colIdGrupo.Name].Value.ToString()) != 0)
                        cmbGrupo.SelectedValue = dtgInventariosAndamento.Rows[e.RowIndex].Cells[colIdGrupo.Name].Value;

                    if (decimal.Parse(dtgInventariosAndamento.Rows[e.RowIndex].Cells[colIdFilial.Name].Value.ToString()) == (decimal)FilialMatMedDTO.Filial.HAC)
                        rbHac.Checked = true;
                    else if (decimal.Parse(dtgInventariosAndamento.Rows[e.RowIndex].Cells[colIdFilial.Name].Value.ToString()) == (decimal)FilialMatMedDTO.Filial.ACS)
                        rbAcs.Checked = true;
                    else if (decimal.Parse(dtgInventariosAndamento.Rows[e.RowIndex].Cells[colIdFilial.Name].Value.ToString()) == (decimal)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA)
                        rbCE.Checked = true;
                    else if (decimal.Parse(dtgInventariosAndamento.Rows[e.RowIndex].Cells[colIdFilial.Name].Value.ToString()) == (decimal)FilialMatMedDTO.Filial.CONSIGNADO)
                        rbConsig.Checked = true;

                    CarregarDigitacao();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void dtgImportacoes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgImportacoes.Rows.Count > 0 && e.RowIndex > -1)
            {
                if (e.ColumnIndex == dtgImportacoes[colExcluir.Name, e.RowIndex].ColumnIndex)
                {
                    if (!tsImportar.Enabled)
                    {
                        MessageBox.Show("Inventário já importado para o estoque, impossibilitando qualquer exclusão deste setor.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    byte numContagem = byte.Parse(dtgImportacoes.Rows[e.RowIndex].Cells[colImportContagem.Name].Value.ToString());
                    if (numContagem.ToString() != btnFecharNum.Text)
                    {
                        MessageBox.Show("A importação tem que ser referente à contagem atual.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (MessageBox.Show("Deseja realmente subtrair desta contagem todos os itens importados deste arquivo ?",
                                             "Gestão de Materiais e Medicamentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        InventarioMatMedDTO dtoInv = new InventarioMatMedDTO();                        
                        dtoInv.IdSetor.Value = cmbSetor.SelectedValue.ToString();
                        if (cmbGrupo.SelectedIndex > 0) dtoInv.IdtGrupo.Value = cmbGrupo.SelectedValue.ToString();
                        dtoInv.IdFilial.Value = new Generico().RetornaFilial(rbHac, new HacRadioButton(), rbCE, rbConsig);
                        dtoInv.DtAtualizacao.Value = DateTime.Parse(dtgImportacoes.Rows[e.RowIndex].Cells[colDataImport.Name].Value.ToString());
                        dtoInv.DataInventario.Value = DateTime.Parse(txtData.Text).Date;
                        dtoInv.IdUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;                        

                        try
                        {
                            InventarioMatMed.ExcluirArquivoSalvoImportacaoPalmTXT(dtoInv);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro na exclusão do arquivo: " + ex.Message, "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Cursor = Cursors.Default;
                            return;
                        }
                        _carregarDigitacaoPosExclusaoArquivo = true;

                        CarregarImportacoes();

                        MessageBox.Show("Importação excluída com sucesso.", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        #endregion
                                                
        #endregion
    }
}