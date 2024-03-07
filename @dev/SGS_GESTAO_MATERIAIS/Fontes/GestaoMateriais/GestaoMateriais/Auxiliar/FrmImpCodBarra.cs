using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.GestaoMateriais.Impressao;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.Seguranca.Forms;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using System.IO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmImpCodBarra : FrmBase
    {
        public FrmImpCodBarra()
        {
            InitializeComponent();
        }

        public static void CarregarItemImpressao(HistoricoNotaFiscalDTO dtoHNF)
        {
            FrmImpCodBarra frm = new FrmImpCodBarra();
            frm.MdiParent = FrmPrincipal.ActiveForm;            
            frm.MdiParent = FrmEstoqueOnlineLote.ActiveForm;
            frm.Show();
            frm.rbAvulso.Checked = true;
            frm.rbOrigem_Click(null, null);
            frm.txtIdProduto.Text = dtoHNF.IdtProduto.Value.ToString();
            frm.txtIdProduto_Validating(null, null);
            if (!dtoHNF.CodLote.Value.IsNull)
            {
                frm.txtLote.Text = dtoHNF.CodLote.Value;
                frm.txtLote_Validating(null, null);
            }
            else
                frm.CarregarLoteAvulso();
        }

        #region OBJETOS SERVIÇOS
        
        private bool _validarDataLote = true;

        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject( typeof(IMaterialMedicamento)); }
        }

        private IHistoricoNotaFiscal _histNF;
        private IHistoricoNotaFiscal HistoricoNotaFiscal
        {
            get { return _histNF != null ? _histNF : _histNF = (IHistoricoNotaFiscal)Global.Common.GetObject( typeof(IHistoricoNotaFiscal)); }
        }        
        private HistoricoNotaFiscalDTO dtoHistNFImprimir;
        private HistoricoNotaFiscalDataTable dtbHistNF;

        private CodigoBarraDTO dtoCodBarraReimpressao;
        private ICodigoBarra _codigoBarra;
        private ICodigoBarra CodigoBarra
        {
            get { return _codigoBarra != null ? _codigoBarra : _codigoBarra = (ICodigoBarra)Global.Common.GetObject(typeof(ICodigoBarra)); }
        }

        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        #endregion

        private string _idProdutoCarregado = string.Empty;

        #region FUNÇÕES

        private void LimparVarGridNF()
        {
            dtgMatMed.DataSource = dtbHistNF = null;
            dtoHistNFImprimir = null;
            dtoCodBarraReimpressao = null;
            lblMAV.Visible = false;
        }        

        private void HabilitarObjetosPesquisa()
        {
            txtNumNota.Enabled = true;
            grbFilial.Enabled = true;
            ConfigurarControles(grbFilial.Controls, true);
            txtNumNota.Focus();
        }

        private bool ValidarFilial(bool mostrarMsgBox)
        {
            if (!rbAcs.Checked && !rbHac.Checked)
            {
                if (mostrarMsgBox) MessageBox.Show("Selecione a Filial", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void PesquisarNota()
        {
            if (txtNumNota.Text == string.Empty)
            {
                MessageBox.Show("Digite o Nr. Nota", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNumNota.Focus();
                return;
            }

            if (!ValidarFilial(true)) return;

            this.Cursor = Cursors.WaitCursor;

            HistoricoNotaFiscalDTO dtoHistNF = new HistoricoNotaFiscalDTO();
            string filial;

            //dtoHistNF.NrNota.Value = txtNumNota.Text;
            dtoHistNF.IdMovRM.Value = cmbFornecedor.SelectedValue.ToString();

            if (rbHac.Checked)
            {
                dtoHistNF.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
                filial = "HAC";
            }
            else
            {
                dtoHistNF.IdtFilial.Value = (int)FilialMatMedDTO.Filial.ACS;
                filial = "ACS";
            }

            dtbHistNF = HistoricoNotaFiscal.Sel(dtoHistNF);
            if (dtbHistNF.Rows.Count > 0)
            {
                dtgMatMed.DataSource = dtbHistNF;                
                dtgMatMed.ClearSelection();
            }
            else            
                MessageBox.Show(string.Format("Nota {0} não encontrada para o {1}", txtNumNota.Text, filial), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            lblCodBarra.Visible = txtCodBarra.Visible = btnReimprimir.Enabled = false;
            this.Cursor = Cursors.Default;
        }

        private void GerarTXT()
        {
            string txtLinha;
            if (rbNF.Checked)
            {
                txtLinha = dtoHistNFImprimir.DsProduto.Value.ToString().Trim() + ";" +
                           lblNumLoteFab.Text.Trim() + ";";

                if (!dtoHistNFImprimir.DataValidadeProduto.Value.IsNull)
                    txtLinha += DateTime.Parse(dtoHistNFImprimir.DataValidadeProduto.Value).ToString("dd/MM/yyyy");
                else
                {
                    MessageBox.Show("Produto sem Data de Validade cadastrada no Lote", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                txtLinha += ";";
            }
            else
            {
                txtLinha = dtoHistNFImprimir.DsProduto.Value.ToString().Trim() + ";" +
                           lblNumLoteFab.Text.Trim() + ";" +
                           txtValidade.Text + ";";
            }

            if (dtoHistNFImprimir.IdtFilial.Value.IsNull)
                dtoHistNFImprimir.IdtFilial.Value = (decimal)new Generico().RetornaFilial(rbHac, rbAcs);
            
            CodigoBarraDTO dtoCodBarra = new CodigoBarraDTO();

            dtoCodBarra.IdtProduto.Value = dtoHistNFImprimir.IdtProduto.Value;            
            dtoCodBarra.IdtFilial.Value = dtoHistNFImprimir.IdtFilial.Value;

            if (dtoHistNFImprimir.IdtLote.Value.IsNull)
            {
                dtoCodBarra = CodigoBarra.SelAvulso(dtoCodBarra, (decimal)FrmPrincipal.dtoSeguranca.Idt.Value);
            }
            else
            {
                dtoCodBarra.IdtLote.Value = dtoHistNFImprimir.IdtLote.Value;
                dtoCodBarra = CodigoBarra.Sel(dtoCodBarra, (decimal)FrmPrincipal.dtoSeguranca.Idt.Value).TypedRow(0);
            }

            txtLinha += dtoCodBarra.CdBarra.Value;
            //if (lblMAV.Visible) txtLinha += ";MAR";

            sfDir.Filter = "Arquivos txt (*.txt)|*.txt";
            if (dtoHistNFImprimir.IdtLote.Value.IsNull)
                sfDir.FileName = dtoHistNFImprimir.DsProduto.Value.ToString().Trim().Replace(" ", "_") + "_AVULSO";
            else
                sfDir.FileName = dtoHistNFImprimir.DsProduto.Value.ToString().Trim().Replace(" ", "_").Replace("/","") + "_LOTE_" + 
                                 dtoHistNFImprimir.CodLote.Value + "-" +
                                 dtoHistNFImprimir.DsFornecedor.Value.ToString().Trim().Replace(" ", "_").Replace(".", "").Replace("/", "");

            if (sfDir.ShowDialog() == DialogResult.OK)
            {                
                this.Cursor = Cursors.WaitCursor;
                if (sfDir.FileName.IndexOf(".txt") == -1) sfDir.FileName += ".txt";
                StreamWriter arqTexto = new StreamWriter(sfDir.FileName);
                arqTexto.WriteLine(txtLinha);                
                arqTexto.Close();
                this.Cursor = Cursors.Default;
                MessageBox.Show("Arquivo gerado com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ImprimirProduto()
        {
           if (dtoHistNFImprimir == null)
           {
               MessageBox.Show("Selecione o produto a ser impresso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return false;
           }

           if (rbNF.Checked && DateTime.Parse(dtoHistNFImprimir.DataPrcMedio.Value.ToString()).Date < Utilitario.ObterDataHoraServidor().Date.AddMonths(-12))
           {
               MessageBox.Show("NF entrou há mais de 12 meses, impossibilitando sua impressão.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return false;
           }

           if (dtoHistNFImprimir.IdtFilial.Value.IsNull && dtoHistNFImprimir.IdtLote.Value.IsNull)
           {
               if (!ValidarFilial(true)) return false;                
               if (rbAcs.Checked && (dtoMatMed.IdtGrupo.Value != 1 || dtoMatMed.FlFracionado.Value == 1))
               {
                   MessageBox.Show("Permitido apenas medicamento inteiro para o ACS", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                   return false;
               }               
               dtoHistNFImprimir.IdtFilial.Value = (decimal)new Generico().RetornaFilial(rbHac, rbAcs);
           }

           if (string.IsNullOrEmpty(txtQtdImprimir.Text))
           {
               MessageBox.Show("Digite a Qtd.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               txtQtdImprimir.Focus();
               return false;
           }
            
           dtoHistNFImprimir.Qtde.Value = txtQtdImprimir.Text;

           try
           {
               this.Cursor = Cursors.WaitCursor;
               string codLoteAvulso = null; string dataValidadeAvulso = null; string endereco = null;
               if (rbAvulso.Checked)
               {
                   codLoteAvulso = txtLote.Text;
                   dataValidadeAvulso = txtValidade.Text;
               }
               if (dtoMatMed == null || dtoMatMed.Idt.Value.ToString() != dtoHistNFImprimir.IdtProduto.Value.ToString())
               {                   
                    dtoMatMed = new MaterialMedicamentoDTO();
                    dtoMatMed.Idt.Value = dtoHistNFImprimir.IdtProduto.Value;
                    dtoMatMed = MatMed.SelChave(dtoMatMed);                
               }
               DataTable dtbMatMedEndereco = MatMed.SelEnderecos((decimal)dtoMatMed.Idt.Value);

               if (dtbMatMedEndereco.Rows.Count > 0)               
                   endereco = dtbMatMedEndereco.Rows[0]["CAD_MTMD_ENDERECO_ALMOX_HAC"].ToString();

               if (dtoHistNFImprimir.IdtFilial.Value.IsNull)
                   dtoHistNFImprimir.IdtFilial.Value = (decimal)new Generico().RetornaFilial(rbHac, rbAcs);

               string erroImpressao = new ImpZebra().ImprimirEtiquetaCodBarra(dtoHistNFImprimir,
                                                                              codLoteAvulso,
                                                                              dataValidadeAvulso,
                                                                              lblMAV.Visible,
                                                                              endereco,
                                                                              (int)dtoMatMed.IdtGrupo.Value);
               if (!string.IsNullOrEmpty(erroImpressao))
               {
                   MessageBox.Show(erroImpressao, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                   dtoHistNFImprimir = null;
                   return false;
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
               dtoHistNFImprimir = null;
               return false;
           }
           finally
           {
               this.Cursor = Cursors.Default;
           }
            
           return true;
        }

        private void LimparProduto()
        {            
            dtoCodBarraReimpressao = null;
            _idProdutoCarregado = string.Empty;
            txtIdProduto.Text = txtDsProduto.Text = txtCodLote.Text = txtCodBarraMostrar.Text = string.Empty;
            lblCodProduto.Text = lblCodFabricante.Text = "-";
            lblMAV.Visible = false;
            LimparLote();
        }

        private void LimparLote()
        {
            if (dtoHistNFImprimir != null)
            {
                dtoHistNFImprimir.IdtLote.Value = new Framework.DTO.TypeDecimal();
                dtoHistNFImprimir.CodLote.Value = new Framework.DTO.TypeString();
            }
            txtLote.Text = txtValidade.Text = string.Empty;
            lblCodLote.Text = lblNumLoteFab.Text = lblValidade.Text = "-";
        }

        private void CarregarDadosProduto()
        {            
            dtoHistNFImprimir = new HistoricoNotaFiscalDTO();
            dtoHistNFImprimir.IdtProduto.Value = dtoMatMed.Idt.Value;
            dtoHistNFImprimir.DsProduto.Value = dtoMatMed.NomeFantasia.Value;

            txtDsProduto.Text = dtoMatMed.NomeFantasia.Value;
            lblCodProduto.Text = dtoMatMed.CodMne.Value; //dtoMatMed.Idt.Value;
            lblCodFabricante.Text = dtoMatMed.CdFabricante.Value;
            _idProdutoCarregado = dtoMatMed.Idt.Value;
            LimparLote();

            tsHac.Items["tsBtnCancelar"].Enabled = true;
            lblCodBarra.Visible = txtCodBarra.Visible = btnReimprimir.Enabled = false;
            txtCodBarraCarregaItem.Text = txtCodLote.Text = txtCodBarraMostrar.Text = string.Empty;
        }

        private void CarregarDadosLote(DataRow rowLote)
        {
            if (!string.IsNullOrEmpty(rowLote[HistoricoNotaFiscalDTO.FieldNames.CodLote].ToString()) &&
                !string.IsNullOrEmpty(rowLote[HistoricoNotaFiscalDTO.FieldNames.IdtLote].ToString()))
            {
                dtoHistNFImprimir.CodLote.Value = rowLote[HistoricoNotaFiscalDTO.FieldNames.CodLote].ToString();
                dtoHistNFImprimir.IdtLote.Value = rowLote[HistoricoNotaFiscalDTO.FieldNames.IdtLote].ToString();
                dtoHistNFImprimir.DsFornecedor.Value = rowLote[HistoricoNotaFiscalDTO.FieldNames.DsFornecedor].ToString();
                if (rowLote[HistoricoNotaFiscalDTO.FieldNames.DataValidadeProduto].ToString() != string.Empty)
                {
                    txtValidade.Text = lblValidade.Text = DateTime.Parse(rowLote[HistoricoNotaFiscalDTO.FieldNames.DataValidadeProduto].ToString()).ToString("dd/MM/yyyy");                    
                    dtoHistNFImprimir.DataValidadeProduto.Value = txtValidade.Text;                    
                }
                lblCodLote.Text = dtoHistNFImprimir.CodLote.Value;
                lblNumLoteFab.Text = rowLote[HistoricoNotaFiscalDTO.FieldNames.NumLote].ToString();
                dtoHistNFImprimir.NumLote.Value = lblNumLoteFab.Text;
            }
            else
            {
                dtoHistNFImprimir.CodLote.Value = new Framework.DTO.TypeString();
                dtoHistNFImprimir.IdtLote.Value = new Framework.DTO.TypeDecimal();
                dtoHistNFImprimir.DsFornecedor.Value = new Framework.DTO.TypeString();
                dtoHistNFImprimir.DataValidadeProduto.Value = new Framework.DTO.TypeDateTime();
                dtoHistNFImprimir.NumLote.Value = new Framework.DTO.TypeString();
            }
        }

        private void BuscarLoteCodBarra(int idLote)
        {
            this.Cursor = Cursors.WaitCursor;
            HistoricoNotaFiscalDTO dtoHistNF = new HistoricoNotaFiscalDTO();

            dtoHistNF.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
            dtoHistNF.IdtProduto.Value = dtoMatMed.Idt.Value;
            dtoHistNF.IdtLote.Value = (decimal)idLote;
            
            HistoricoNotaFiscalDataTable dtbHistNF = HistoricoNotaFiscal.Sel(dtoHistNF);            

            if (dtbHistNF.Rows.Count > 0)
            {
                dtoHistNF = dtbHistNF.TypedRow(0);
                txtLote.Text = dtoHistNF.CodLote.Value;
                CarregarDadosLote(dtbHistNF.Rows[0]);
            }

            this.Cursor = Cursors.Default;
        }

        private HistoricoNotaFiscalDataTable PesquisaLote12Meses()
        {
            HistoricoNotaFiscalDTO dtoHistNF = new HistoricoNotaFiscalDTO();

            if (rbHac.Checked)
                dtoHistNF.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
            else
                dtoHistNF.IdtFilial.Value = (int)FilialMatMedDTO.Filial.ACS;

            dtoHistNF.IdtProduto.Value = dtoHistNFImprimir.IdtProduto.Value;
            if (_validarDataLote)
                dtoHistNF.DataPrcMedio.Value = Utilitario.ObterDataHoraServidor().Date.AddMonths(-12);
            else
                dtoHistNF.DataPrcMedio.Value = Utilitario.ObterDataHoraServidor().Date.AddMonths(-60);

            return HistoricoNotaFiscal.Sel(dtoHistNF);
        }

        private void CarregarLoteAvulso()
        {
            HistoricoNotaFiscalDataTable dtbNF = this.PesquisaLote12Meses();
            txtLote.Text = txtValidade.Text = string.Empty;
            lblNumLoteFab.Text = "-";
            txtLote.ReadOnly = false;
            if (dtbNF.Rows.Count > 0)
            {
                DataRow drNF = dtbNF.Select(string.Empty, string.Format("{0} DESC, {1} DESC", HistoricoNotaFiscalDTO.FieldNames.DataPrcMedio, HistoricoNotaFiscalDTO.FieldNames.CodLote))[0];
                txtLote.Text = drNF[HistoricoNotaFiscalDTO.FieldNames.CodLote].ToString();
                CarregarDadosLote(drNF);
            }
            else
            {
                txtLote.ReadOnly = true;
                MessageBox.Show("Item sem entrada de NF nos últimos 12 meses!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }        

        private bool ValidarLote()
        {
            HistoricoNotaFiscalDataTable dtbNF = this.PesquisaLote12Meses();
            DataRow[] lotesEncontrados = dtbNF.Select(string.Format("{0}='{1}'", HistoricoNotaFiscalDTO.FieldNames.CodLote, txtLote.Text.Trim()));            
            txtValidade.Text = string.Empty;
            lblNumLoteFab.Text = "-";
            if (lotesEncontrados.Length > 0)
            {
                CarregarDadosLote(lotesEncontrados[0]);
                return true;
            }
            return false;
        }

        #endregion

        #region EVENTOS

        private void FrmImpCodBarra_Load(object sender, EventArgs e)
        {            
            tsHac.Items["tsBtnPesquisar"].Enabled = true;
                        
            dtgMatMed.AutoGenerateColumns = false;
            dtgMatMed.Columns[colIdLote.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.IdtLote;
            dtgMatMed.Columns[colIdtProduto.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.IdtProduto;
            dtgMatMed.Columns[colDescricao.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.DsProduto;            
            dtgMatMed.Columns[colNumLote.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.NumLote;
            dtgMatMed.Columns[colCodLote.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.CodLote;
            dtgMatMed.Columns[colQtdeCompra.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.QtdeTotalNota;
            dtgMatMed.Columns[colQtdeCompra.Name].DefaultCellStyle.Format = "N0";
            dtgMatMed.Columns[colUnidade.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.UnidadeCompra;
            dtgMatMed.Columns[colData.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.DataPrcMedio;
            dtgMatMed.Columns[colData.Name].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dtgMatMed.Columns[colQtd.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.Qtde;
            dtgMatMed.Columns[colQtd.Name].DefaultCellStyle.Format = "N0";
            dtgMatMed.Columns[colMAV.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia;
            
            rbOrigem_Click(null, null);
            rbHac.Checked = true;
        }

        private bool tsHac_CancelarClick(object sender)
        {
            LimparVarGridNF();
            return true;
        }

        private void tsHac_AfterCancelar(object sender)
        {
            lblCodBarra.Visible = txtCodBarra.Visible = btnReimprimir.Enabled = tsHac.Items["tsBtnPesquisar"].Enabled = tsHac.Items["tsBtnMatMed"].Enabled = grbMostraCodBarra.Visible = false;
            rbHac.Checked = rbNF.Checked = true;
            LimparProduto();
            rbOrigem_Click(null, null);
        }

        private bool tsHac_MatMedClick(object sender)
        {
            if (rbAvulso.Checked || rbMedExterno.Checked)
            {
                dtoMatMed = new MaterialMedicamentoDTO();

                dtoMatMed.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.SEM_ESTOQUE;
                dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMed);
                lblMAV.Visible = false;

                if (dtoMatMed != null)
                {
                    txtIdProduto.Text = dtoMatMed.Idt.Value; //dtoMatMed.CodMne.Value;
                    txtIdProduto_Validating(null, null);
                    //txtDsProduto.Text = dtoMatMed.NomeFantasia.Value;
                    txtQtdImprimir.Focus();

                    tsHac.Items["tsBtnPesquisar"].Enabled = false;

                    if (dtoMatMed.MedAltaVigilancia.Value.IsNull) dtoMatMed.MedAltaVigilancia.Value = "N";
                    if (dtoMatMed.MedAltaVigilancia.Value == "S") lblMAV.Visible = true;                        
                }
                else
                    txtIdProduto.Text = txtDsProduto.Text = string.Empty;

                return true;
            }
            return false;
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            if (rbNF.Checked)
            {
                this.PesquisarNota();
                return true;
            }
            return false;
        }

        private bool tsHac_ImprimirClick(object sender)
        {
            if (btnReimprimir.Enabled)
            {
                MessageBox.Show("Item já impresso, favor digitar o código de barra e utilizar a funcionalidade de reimpressão!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }            
            return ImprimirProduto();
        }

        private void tsbGerarArquivo_Click(object sender, EventArgs e)
        {
            if (!ValidarFilial(true)) return;
            if (dtoHistNFImprimir == null)
            {
                MessageBox.Show("Selecione o produto a ser impresso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (rbAvulso.Checked)
            {
                if (txtLote.Text == string.Empty)
                {
                    MessageBox.Show("Digite o Lote", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtLote.Focus();
                    return;
                }
                else if (txtLote.ReadOnly)
                {
                    MessageBox.Show("Item sem entrada de NF nos últimos 12 meses!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtValidade.Text == string.Empty)
                {
                    MessageBox.Show("Digite a Validade", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtValidade.Focus();
                    return;
                }
                else
                {
                    DateTime dt;
                    if (!DateTime.TryParse(txtValidade.Text, out dt))
                    {
                        MessageBox.Show("Data de Validade inválida", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtValidade.Focus();
                        return;
                    }
                }
            }
            GerarTXT();
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodBarra.Text))
            {
                MessageBox.Show("Digite o Cod. Barra para reimpressão.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodBarra.Focus();
                return;
            }
            SegurancaDTO dtoUsuario;
            this.Cursor = Cursors.WaitCursor;
            dtoUsuario = FrmLogin.Logar(true);
            if (dtoUsuario != null)
            {
                if (!new Generico().VerificaAcessoFuncionalidade("ReimprimirCodBarra", dtoUsuario))
                {
                    MessageBox.Show("Usuário sem permissão para reimpressão.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Cursor = Cursors.Default;
                    return;
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                return;
            }
            if (dtoCodBarraReimpressao != null && !dtoCodBarraReimpressao.CdBarra.Value.IsNull && !dtoCodBarraReimpressao.IdtLote.Value.IsNull)
            {
                if (txtCodBarra.Text == dtoCodBarraReimpressao.CdBarra.Value)
                {
                    ImprimirProduto();
                }
                else
                {
                    MessageBox.Show("Cod. Barra digitado diferente do impresso para este produto/lote, favor digitar novamente.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodBarra.Text = string.Empty;
                    txtCodBarra.Focus();
                }
            }
            else
            {
                MessageBox.Show("Item para reimpressão não carregado corretamente.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Cursor = Cursors.Default;
        }

        private void rbHac_Click(object sender, EventArgs e)
        {
            if (rbNF.Checked)
                rbOrigem_Click(null, null);
            else if (rbAvulso.Checked && dtoHistNFImprimir != null && (!rbHac.Checked || !rbAcs.Checked))
                dtoHistNFImprimir.IdtFilial.Value = (decimal)new Generico().RetornaFilial(rbHac, rbAcs);
        }

        private void rbAcs_Click(object sender, EventArgs e)
        {
            if (rbNF.Checked)
                rbOrigem_Click(null, null);
            else if (rbAvulso.Checked && dtoHistNFImprimir != null && (!rbHac.Checked || !rbAcs.Checked))
                dtoHistNFImprimir.IdtFilial.Value = (decimal)new Generico().RetornaFilial(rbHac, rbAcs);
        }

        private void rbOrigem_Click(object sender, EventArgs e)
        {
            lblCodBarra.Visible = txtCodBarra.Visible = btnReimprimir.Enabled = grbMostraCodBarra.Visible = false;
            tsHac.Items["tsBtnPesquisar"].Enabled = rbNF.Checked;
            tsHac.Items["tsBtnMatMed"].Enabled = (rbAvulso.Checked || rbMedExterno.Checked);
            txtIdProduto.Text = txtNumNota.Text = string.Empty;
            LimparProduto();
            cmbFornecedor.DataSource = dtgMatMed.DataSource = null;
            if (!rbMedExterno.Checked) btnCancelarMedExt_Click(sender, e);
            if (rbAvulso.Checked || rbMedExterno.Checked)
            {                
                LimparVarGridNF();
                txtIdProduto.Validating += txtIdProduto_Validating;
                grbAvulso.Visible = txtIdProduto.Enabled = txtQtdImprimir.Enabled = true;
                ConfigurarControles(grbAvulso.Controls, !rbMedExterno.Checked);
                ConfigurarControles(grbNF.Controls, false);
                txtLote.Text = txtValidade.Text = txtQtdImprimir.Text = string.Empty;
                if (rbMedExterno.Checked)
                    txtIdProduto.Focus();
                else
                    txtCodBarraCarregaItem.Focus();

                if (rbAvulso.Checked)
                {
                    txtCodLote.Text = txtCodBarraMostrar.Text = string.Empty;
                    grbMostraCodBarra.Visible = new Generico().VerificaAcessoFuncionalidade("MostrarCodBarra");
                }
            }
            else
            {
                txtIdProduto.Validating -= txtIdProduto_Validating;
                grbAvulso.Visible = txtIdProduto.Enabled = txtQtdImprimir.Enabled = false;
                ConfigurarControles(grbNF.Controls, true);
                txtNumNota.Focus();
            }
        }

        private void dtgMatMed_SelectionChanged(object sender, EventArgs e)
        {
               
        }

        private void dtgMatMed_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataRow row;
            dtoHistNFImprimir = null;
            lblCodBarra.Visible = txtCodBarra.Visible = btnReimprimir.Enabled = txtQtdImprimir.Enabled = lblMAV.Visible = false;
            txtCodBarra.Text = string.Empty;

            if (dtbHistNF.Select(string.Format("{0} = {1}", HistoricoNotaFiscalDTO.FieldNames.IdtProduto, dtgMatMed.SelectedRows[0].Cells[colIdtProduto.Name].Value)).Length > 1)            
                row = dtbHistNF.Select(string.Format("{0} = {1}", HistoricoNotaFiscalDTO.FieldNames.IdtLote, dtgMatMed.SelectedRows[0].Cells[colIdLote.Name].Value))[0];
            else            
                row = dtbHistNF.Select(string.Format("{0} = {1}", HistoricoNotaFiscalDTO.FieldNames.IdtProduto, dtgMatMed.SelectedRows[0].Cells[colIdtProduto.Name].Value))[0];
            
            dtoHistNFImprimir = (HistoricoNotaFiscalDTO)row;

            if (dtoHistNFImprimir != null)
            {
                lblCodProduto.Text = row[MaterialMedicamentoDTO.FieldNames.CodMne].ToString(); //dtoHistNFImprimir.IdtProduto.Value;
                txtDsProduto.Text = dtoHistNFImprimir.DsProduto.Value;
                txtQtdImprimir.Text = string.Empty;
                if (!dtoHistNFImprimir.QtdeTotalNota.Value.IsNull && (int)dtoHistNFImprimir.QtdeTotalNota.Value > 0)
                {
                    DataRow[] dtRows = dtbHistNF.Select(string.Format("{0} = {1}", HistoricoNotaFiscalDTO.FieldNames.IdtProduto, dtgMatMed.SelectedRows[0].Cells[colIdtProduto.Name].Value));
                    int qtdUnitariaTotalNF = 0;
                    for (int cont = 0; cont < dtRows.Length; cont++)
                        qtdUnitariaTotalNF += int.Parse(dtRows[cont][HistoricoNotaFiscalDTO.FieldNames.Qtde].ToString());
                    //Sugerir Qtd. da Embalagem para imprimir a 1° vez conforme processo de chegada do item no Almox.
                    int unidadeCompra = qtdUnitariaTotalNF / (int)dtoHistNFImprimir.QtdeTotalNota.Value;
                    txtQtdImprimir.Text = ((int)dtoHistNFImprimir.Qtde.Value / unidadeCompra).ToString();
                }
                if (!dtoHistNFImprimir.CodLote.Value.IsNull)
                    lblCodLote.Text = dtoHistNFImprimir.CodLote.Value;
                else
                    lblCodLote.Text = "-";
                if (!dtoHistNFImprimir.NumLote.Value.IsNull)
                    lblNumLoteFab.Text = dtoHistNFImprimir.NumLote.Value;
                else
                    lblNumLoteFab.Text = "-";
                if (!string.IsNullOrEmpty(row[HistoricoNotaFiscalDTO.FieldNames.DataValidadeProduto].ToString()))
                    lblValidade.Text = DateTime.Parse(row[HistoricoNotaFiscalDTO.FieldNames.DataValidadeProduto].ToString()).ToString("dd/MM/yyyy");
                else
                    lblValidade.Text = "-"; 
                lblCodFabricante.Text = row[MaterialMedicamentoDTO.FieldNames.CdFabricante].ToString();
                if (row[MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia].ToString() == "S") lblMAV.Visible = true;
                txtQtdImprimir.Enabled = true;

                if (!dtoHistNFImprimir.IdtLote.Value.IsNull)
                {
                    dtoCodBarraReimpressao = new CodigoBarraDTO();
                    dtoCodBarraReimpressao.IdtFilial.Value = dtoHistNFImprimir.IdtFilial.Value;
                    dtoCodBarraReimpressao.IdtProduto.Value = dtoHistNFImprimir.IdtProduto.Value;
                    dtoCodBarraReimpressao.IdtLote.Value = dtoHistNFImprimir.IdtLote.Value;
                    CodigoBarraDataTable dtbCod = CodigoBarra.Sel(dtoCodBarraReimpressao, null);                    
                    if (dtbCod.Rows.Count > 0)
                    {
                        dtoCodBarraReimpressao = dtbCod.TypedRow(0);
                        //txtCodBarra.Text = string.Empty;
                        txtCodBarra.Text = dtoCodBarraReimpressao.CdBarra.Value; //Depois de estabilizado, zerar este txt
                        lblCodBarra.Visible = txtCodBarra.Visible = btnReimprimir.Enabled = true;
                        MessageBox.Show("Item com cód. barra já gerado ou impresso!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtQtdImprimir.Focus();
                    }
                    else
                        dtoCodBarraReimpressao = null;
                }
                else
                {
                    dtoCodBarraReimpressao = null;
                    MessageBox.Show("Item sem lote vinculado, gere etiqueta avulsa clicando em Imprimir, ou entre em contato com um administrador!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else            
                LimparProduto();

            tsHac.Items["tsBtnMatMed"].Enabled = false;
            tsHac.Items["tsBtnCancelar"].Enabled = true;
            this.Cursor = Cursors.Default;
        }

        private void txtCodBarraCarregaItem_Validating(object sender, CancelEventArgs e)
        {
            if (txtCodBarraCarregaItem.Text != string.Empty)
            {
                CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();

                dtoCodigoBarra.CdBarra.Value = txtCodBarraCarregaItem.Text;
                dtoCodigoBarra.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;

                // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
                dtoMatMed = MatMed.BuscaCodigoBarra(dtoCodigoBarra);

                if (dtoMatMed == null)
                {
                    MessageBox.Show("Produto não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimparProduto();
                    txtCodBarraCarregaItem.Text = string.Empty;
                    txtCodBarraCarregaItem.Focus();
                    return;
                }
                else
                    CarregarDadosProduto();

                txtIdProduto.Text = dtoMatMed.Idt.Value;
                txtDsProduto.Text = string.Format("{0}", dtoMatMed.NomeFantasia.Value);
                
                if (!dtoMatMed.IdtLote.Value.IsNull)
                    BuscarLoteCodBarra((int)dtoMatMed.IdtLote.Value);

                txtQtdImprimir.Focus();
            }
        }

        private void txtIdProduto_Validating(object sender, CancelEventArgs e)
        {            
            if (txtIdProduto.Text != string.Empty && txtIdProduto.Text != _idProdutoCarregado)
            {   
                dtoHistNFImprimir = null;
                dtoCodBarraReimpressao = null;
                if (rbAvulso.Checked || rbMedExterno.Checked) LimparVarGridNF();
                txtQtdImprimir.Text = string.Empty;

                //MaterialMedicamentoDTO dtoCdMne = new MaterialMedicamentoDTO();
                //dtoCdMne.CodMne.Value = txtCodProduto.Text.Trim();
                //MaterialMedicamentoDataTable dtbMatMed = MatMed.Sel(dtoCdMne);
                dtoMatMed = new MaterialMedicamentoDTO();
                dtoMatMed.Idt.Value = txtIdProduto.Text;
                dtoMatMed = MatMed.SelChave(dtoMatMed);

                //if (dtbMatMed.Rows.Count == 0)
                if (dtoMatMed == null || dtoMatMed.Idt.Value.IsNull)
                {
                    MessageBox.Show("Material/medicamento não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                    
                    dtoMatMed = null;
                    LimparProduto();
                    txtIdProduto.Focus();
                    return;
                }
                else
                {
                    if (rbMedExterno.Checked && dtoMatMed.IdtGrupo.Value != 1)
                    {
                        MessageBox.Show("Selecione um medicamento", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LimparProduto();
                        txtIdProduto.Focus();
                        return;
                    }                    
                    CarregarDadosProduto();                    
                    if (rbAvulso.Checked) CarregarLoteAvulso();
                    if (rbMedExterno.Checked)
                    {
                        // configura panel
                        pnlMedExterno.BorderStyle = BorderStyle.FixedSingle;
                        pnlMedExterno.Visible = true;
                        // configura panel
                        ConfigurarControles(pnlMedExterno.Controls, true);
                        txtNumLoteFabGerar.Text = txtValidadeGerar.Text = string.Empty;
                        txtNumLoteFabGerar.Focus();
                    }
                    else
                        txtQtdImprimir.Focus();
                }                
            }
            else if (txtIdProduto.Text == string.Empty && _idProdutoCarregado != string.Empty)
            {                
                dtoMatMed = null;
                LimparProduto();
                txtIdProduto.Focus();
            }
        }

        private void txtLote_Validating(object sender, CancelEventArgs e)
        {
            if (txtLote.Text != string.Empty && rbAvulso.Checked && dtoHistNFImprimir != null)
            {
                if (!ValidarLote())
                {
                    MessageBox.Show("Lote não identificado para este item", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimparLote();
                    txtLote.Focus();
                }
            }
            else if (dtoHistNFImprimir == null && txtLote.Text != string.Empty)
            {
                LimparLote();
                MessageBox.Show("Selecione um produto", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtLote.Text == string.Empty) LimparLote();
        }

        private void txtNumNota_Validating(object sender, CancelEventArgs e)
        {
            if (txtNumNota.Text != string.Empty)
            {
                this.Cursor = Cursors.WaitCursor;
                dtoHistNFImprimir = null;
                dtoCodBarraReimpressao = null;
                DataTable dtbForn = HistoricoNotaFiscal.ObterFornecedoresNF(txtNumNota.Text.Trim(), 
                                                                            (byte)new Generico().RetornaFilial(rbHac, rbAcs));

                if (dtbForn.Rows.Count == 0)
                {                    
                    MessageBox.Show(string.Format("Nota {0} não encontrada para o {1}", txtNumNota.Text, rbHac.Checked ? rbHac.Text : rbAcs.Text), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rbOrigem_Click( null, null);
                    this.Cursor = Cursors.Default;
                    return;
                }

                cmbFornecedor.ValueMember = HistoricoNotaFiscalDTO.FieldNames.IdMovRM;
                cmbFornecedor.DisplayMember = HistoricoNotaFiscalDTO.FieldNames.DsFornecedor;
                cmbFornecedor.DataSource = dtbForn;

                if (dtbForn.Rows.Count > 1)
                    cmbFornecedor.IniciaLista();
                else
                    this.PesquisarNota();

                tsHac.Items["tsBtnMatMed"].Enabled = false;
                tsHac.Items["tsBtnCancelar"].Enabled = true;
                this.Cursor = Cursors.Default;
            }
            else
                rbOrigem_Click(null, null);
        }

        private void cmbFornecedor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.PesquisarNota();
        }

        private void rbMedExterno_Click(object sender, EventArgs e)
        {
            if (rbMedExterno.Checked)
            {
                SegurancaDTO dtoUsuario;
                this.Cursor = Cursors.WaitCursor;
                dtoUsuario = FrmLogin.Logar(true);                
                if (dtoUsuario == null || !new Generico().VerificaAcessoFuncionalidade("GerarCodBarraExterno", dtoUsuario))
                {
                    if (dtoUsuario != null) MessageBox.Show("Usuário precisa ser autenticado com permissão para esta funcionalidade.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rbNF.Checked = true;
                    ConfigurarControles(grbAvulso.Controls, false);
                    rbOrigem_Click(sender, e);
                    this.Cursor = Cursors.Default;
                    return;
                }
            }
            rbOrigem_Click(sender, e);
            this.Cursor = Cursors.Default;
            return;
        }

        private void btnCancelarMedExt_Click(object sender, EventArgs e)
        {
            pnlMedExterno.Visible = false;
            txtNumLoteFabGerar.Text = txtValidadeGerar.Text = string.Empty;
            if (rbMedExterno.Checked)
            {
                rbAvulso.Checked = true;
                ConfigurarControles(grbAvulso.Controls, true);
                txtCodBarraCarregaItem.Focus();
            }
        }

        private void btnGerarCodMedExt_Click(object sender, EventArgs e)
        {
            if (dtoMatMed == null || dtoHistNFImprimir == null || dtoHistNFImprimir.IdtProduto.Value.IsNull)
            {
                MessageBox.Show("Selecione um produto", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdProduto.Focus();
                return;
            }
            if (dtoMatMed.IdtGrupo.Value != 1)
            {
                MessageBox.Show("Selecione um medicamento", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimparProduto();
                txtIdProduto.Focus();
                return;
            }
            if (txtValidadeGerar.Text == string.Empty)
            {
                MessageBox.Show("Digite a Data de Validade", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtValidadeGerar.Focus();
                return;
            }
            try
            {
                if (Convert.ToDateTime(txtValidadeGerar.Text) < Utilitario.ObterDataHoraServidor().Date.AddMonths(-24))
                {
                    MessageBox.Show("Medicamento não pode estar vencido há mais de 2 anos.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtValidadeGerar.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Data Validade inválida.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNumLoteFabGerar.Text.Length == 0)
            {
                MessageBox.Show("Digite o N° Lote Fab.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNumLoteFabGerar.Focus();
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            HistoricoNotaFiscalDTO dtoHNF = new HistoricoNotaFiscalDTO();

            dtoHNF.IdtProduto.Value = dtoHistNFImprimir.IdtProduto.Value;
            dtoHNF.NumLote.Value = txtNumLoteFabGerar.Text;
            dtoHNF.DataValidadeProduto.Value = txtValidadeGerar.Text;

            CodigoBarraDataTable dtbCdBarra = CodigoBarra.SelMedicamentoSemNF(dtoHNF, (decimal)FrmPrincipal.dtoSeguranca.Idt.Value, 29); //29 = ALMOX. CENTRAL
            
            txtNumLoteFabGerar.Text = txtValidadeGerar.Text = string.Empty;
            rbAvulso.Checked = true;
            ConfigurarControles(grbAvulso.Controls, true);

            if (dtbCdBarra.Rows.Count > 0)
                MessageBox.Show("Cd. Barra gerado com sucesso.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show("Houve algum problema ao gerar este código.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                return;
            }

            btnCancelarMedExt_Click(sender, e);

            txtLote.Text = dtbCdBarra.Rows[0][HistoricoNotaFiscalDTO.FieldNames.CodLote].ToString();
            _validarDataLote = false;
            txtLote_Validating(null, null);
            _validarDataLote = true;
            this.Cursor = Cursors.Default;
        }

        private void txtNumLoteFabGerar_Validating(object sender, CancelEventArgs e)
        {
            if (txtNumLoteFabGerar.Text != string.Empty) txtValidadeGerar.Focus();            
        }

        private void btnPesquisarCodBarra_Click(object sender, EventArgs e)
        {
            txtCodBarraMostrar.Text = string.Empty;
            if (dtoMatMed == null)
            {
                MessageBox.Show("Produto não informado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodLote.Text = string.Empty;
                return;
            }
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
                        txtCodBarraMostrar.Text = dtoCodBarraReimpressao.CdBarra.Value;
                    }
                    else
                    {
                        MessageBox.Show("CODIGO NAO ENCONTRADO", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Cursor = Cursors.Default;
                    }
                }
                else
                {
                    MessageBox.Show("CODIGO NAO ENCONTRADO", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    txtCodBarraMostrar.Text = codBarra;
                else
                {
                    MessageBox.Show("CODIGO NAO ENCONTRADO", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Cursor = Cursors.Default;
                    return;
                }
            }

            this.Cursor = Cursors.Default;
        }

        #endregion        
    }
}