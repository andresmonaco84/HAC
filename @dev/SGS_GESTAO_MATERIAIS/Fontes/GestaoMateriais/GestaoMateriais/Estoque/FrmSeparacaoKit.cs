using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.Seguranca.Forms;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais;
using HospitalAnaCosta.SGS.GestaoMateriais.Relatorio;
using Microsoft.ReportingServices.ReportRendering;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    public partial class FrmSeparacaoKit : FrmBase
    {
        #region OBJETOS SERVIÇOS

        private const string colNome_QtdSeparada = "QTDE_SEPARADA";
        private string _usuarioSeparacao = null;
        private int? _idKitSaldo = null;
        private DateTime? _dtFinal = null;

        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }

        // Kit
        private IKit _kit;
        private IKit Kit
        {
            get { return _kit != null ? _kit : _kit = (IKit)Global.Common.GetObject(typeof(IKit)); }
        }

        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        #endregion

        #region MÉTODOS

        public FrmSeparacaoKit()
        {
            InitializeComponent();
        }

        private void ConfiguraDTG()
        {
            dtgMatMed.AutoGenerateColumns = false;
            dtgMatMed.Columns[colIdProduto.Name].DataPropertyName = KitDTO.FieldNames.IdProduto;
            dtgMatMed.Columns[colIdKit.Name].DataPropertyName = KitDTO.FieldNames.IdKit;
            dtgMatMed.Columns[colDescricao.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.NomeFantasia;
            dtgMatMed.Columns[colQtdKit.Name].DataPropertyName = KitDTO.FieldNames.QtdeItem;
            dtgMatMed.Columns[colQtdSeparada.Name].DataPropertyName = colNome_QtdSeparada;
            dtgMatMed.Columns[colData.Name].DataPropertyName = "CAD_MTMD_KIT_ITEM_DATA";
        }

        private bool ValidarProduto()
        {
            return true;
        }

        private void AdicionarQtdItem(bool subtrair)
        {
            this.Cursor = Cursors.WaitCursor;
            bool itemAtualizado = false;
            try
            {                
                foreach (DataGridViewRow dtgRow in dtgMatMed.Rows)
                {
                    if (int.Parse(dtgRow.Cells[colIdProduto.Name].Value.ToString()) == (int)dtoMatMed.Idt.Value)
                    {
                        if (_idKitSaldo == null) _idKitSaldo = Kit.GerarSaldoID();

                        if (subtrair)
                        {
                            dtgRow.Cells[colQtdSeparada.Name].Value = int.Parse(dtgRow.Cells[colQtdSeparada.Name].Value.ToString()) - 1;
                        }
                        else
                        {
                            int qtdNova = int.Parse(dtgRow.Cells[colQtdSeparada.Name].Value.ToString()) + 1;
                            if (qtdNova > int.Parse(dtgRow.Cells[colQtdKit.Name].Value.ToString()))
                            {
                                MessageBox.Show("Qtde. Separada não pode ultrapassar à qtde. do kit.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtCodProduto.Text = string.Empty;
                                txtCodProduto.Focus();
                                this.Cursor = Cursors.Default;
                                return;
                            }
                            dtgRow.Cells[colQtdSeparada.Name].Value = qtdNova;
                        }

                        MovimentacaoDTO dtoMov = new MovimentacaoDTO();
                        dtoMov.IdtFilial.Value = 1;
                        dtoMov.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                        dtoMov.IdtProduto.Value = dtgRow.Cells[colIdProduto.Name].Value.ToString();
                        dtoMov.Qtde.Value = dtgRow.Cells[colQtdSeparada.Name].Value.ToString();
                        dtoMov.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                        Kit.GravarSaldo(_idKitSaldo.Value,
                                        int.Parse(dtgRow.Cells[colIdKit.Name].Value.ToString()),
                                        dtoMov);

                        dtgRow.Cells[colData.Name].Value = Utilitario.ObterDataHoraServidor();
                        itemAtualizado = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!itemAtualizado)
                MessageBox.Show("Item não correspondente à listagem deste Kit !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                dtgMatMed.Sort(dtgMatMed.Columns[colData.Name], ListSortDirection.Descending);
            
            dtgMatMed.ClearSelection();
            txtCodProduto.Text = string.Empty;
            txtCodProduto.Focus();

            this.Cursor = Cursors.Default;
        }

        private void CarregarItensKit()
        {
            this.Cursor = Cursors.WaitCursor;

            KitDTO dtoKit = new KitDTO();
            dtoKit.IdKit.Value = cmbKit.SelectedValue.ToString();
            KitDataTable dtbItem = Kit.ListarItem(dtoKit);

            dtbItem.Columns.Add(colNome_QtdSeparada);
            
            foreach (DataRow row in dtbItem.Rows)
            {
                if (int.Parse(row[MaterialMedicamentoDTO.FieldNames.IdtGrupo].ToString()) == 1) //Não deixar inserir medicamento "POR ENQUANTO"
                {
                    row.Delete();
                    continue;
                }
                row[colNome_QtdSeparada] = 0;
            }

            dtgMatMed.DataSource = dtbItem;

            this.Cursor = Cursors.Default;
        }

        #endregion

        #region EVENTOS

        private void FrmSeparacaoKit_Load(object sender, EventArgs e)
        {
            cmbUnidade.Enabled = cmbLocal.Enabled = cmbSetor.Enabled = false;
            cmbUnidade.Editavel = cmbLocal.Editavel = cmbSetor.Editavel = ControleEdicao.Nunca;
            cmbUnidade.Carregaunidade();
            cmbUnidade.SelectedValue = 244; //SANTOS
            cmbLocal.SelectedValue = 29; //INTERNADO
            cmbSetor.SelectedValue = 61; //CENTRO CIRURGICO (inicialmente carregando apenas este setor)

            cmbKit.Visible = lblKit.Visible = true;
            KitDTO dtoKit = new KitDTO();
            dtoKit.Ativo.Value = 1;
            cmbKit.DataSource = Kit.Listar(dtoKit);
            cmbKit.IniciaLista();

            ConfiguraDTG();
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
                else if (!ValidarProduto())
                {
                    txtCodProduto.Text = string.Empty;
                    txtCodProduto.Focus();
                    return;
                }

                this.AdicionarQtdItem(false);
                cmbKit.Enabled = false;
            }
        }        

        private bool tsHac_NovoClick(object sender)
        {
            return true;
        }

        private bool tsHac_AfterNovo(object sender)
        {
            tsHac_AfterCancelar(sender);

            cmbKit.Enabled = true;
            cmbKit.Focus();

            return default(bool);
        }

        private bool tsHac_CancelarClick(object sender)
        {
            cmbKit.IniciaLista();
            cmbKit.Enabled = false;
            return true;
        }        

        private void tsHac_AfterCancelar(object sender)
        {
            dtgMatMed.DataSource = null;
            _idKitSaldo = null;
            _dtFinal = null;
            _usuarioSeparacao = null;

            txtCodProduto.Enabled = btnFinalizar.Enabled = false;
            btnFinalizar.Text = "FINALIZAR";
        }

        private void tsPrevia_Click(object sender, EventArgs e)
        {
            if (cmbKit.SelectedIndex > -1)
            {
                this.Cursor = Cursors.WaitCursor;
                string nomeRelatorio = "GM_49_KIT_ITENS";
                Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[2];

                #region Monta Parâmetros

                byte x = 0;

                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_KIT_ID", cmbKit.SelectedValue.ToString());
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_KIT_DSC", cmbKit.Text);

                #endregion

                Microsoft.Reporting.WinForms.ReportParameter[] reportParamTemp = new Microsoft.Reporting.WinForms.ReportParameter[x];

                for (int i = 0; i < reportParam.Length; i++)
                {
                    if (reportParam[i] == null) break;
                    reportParamTemp[i] = reportParam[i];
                }
                reportParam = reportParamTemp;
                reportParamTemp = null;

                FrmReportViewer frmRelatorio = new FrmReportViewer();
                frmRelatorio.AbreRelatorio(nomeRelatorio, reportParam);
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Nenhum kit selecionado!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbKit.Focus();
            }
        }

        private void cmbKit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbKit.SelectedIndex > -1)
            {
                CarregarItensKit();
                btnFinalizar.Text = "FINALIZAR";
                txtCodProduto.Enabled = btnFinalizar.Enabled = dtgMatMed.Columns[colDel.Name].Visible = true;
                txtCodProduto.Text = string.Empty;
                txtCodProduto.Focus();
            }
            else
                txtCodProduto.Enabled = btnFinalizar.Enabled = dtgMatMed.Columns[colDel.Name].Visible = false;                   
        }

        private void dtgMatMed_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == dtgMatMed[colDel.Name, e.RowIndex].ColumnIndex)
                {
                    try
                    {
                        if (int.Parse(dtgMatMed.Rows[e.RowIndex].Cells[colQtdSeparada.Name].Value.ToString()) == 0)
                        {
                            MessageBox.Show("SEM QTDE. PARA SUBTRAÇÃO", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtCodProduto.Focus();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("SEM QTDE. PARA SUBTRAÇÃO", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCodProduto.Focus();
                        return;
                    }
                    this.Cursor = Cursors.WaitCursor;

                    dtoMatMed = new MaterialMedicamentoDTO();
                    dtoMatMed.Idt.Value = dtgMatMed.Rows[e.RowIndex].Cells[colIdProduto.Name].Value.ToString();
                    dtoMatMed = MatMed.SelChave(dtoMatMed);

                    if (MessageBox.Show("Deseja realmente subtrair 1 unidade deste item nesta contagem ?", "Gestão de Materiais e Medicamentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.AdicionarQtdItem(true);
                    }
                    txtCodProduto.Focus();
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void dtgMatMed_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dtgMatMed.Rows.Count > 0)
            {
                if (int.Parse(dtgMatMed.Rows[e.RowIndex].Cells[colQtdSeparada.Name].Value.ToString()) ==
                    int.Parse(dtgMatMed.Rows[e.RowIndex].Cells[colQtdKit.Name].Value.ToString()))
                    dtgMatMed.Rows[e.RowIndex].Cells[colQtdSeparada.Name].Style.ForeColor = Color.Green;
                else
                    dtgMatMed.Rows[e.RowIndex].Cells[colQtdSeparada.Name].Style.ForeColor = Color.Red;
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (_idKitSaldo == null)
            {
                MessageBox.Show("Nenhum item carregado!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodProduto.Focus();
                return;
            }

            if (btnFinalizar.Text != "IMPRIMIR")
            {
                foreach (DataGridViewRow dtgRow in dtgMatMed.Rows)
                {
                    if (int.Parse(dtgRow.Cells[colQtdSeparada.Name].Value.ToString()) <
                        int.Parse(dtgRow.Cells[colQtdKit.Name].Value.ToString()))
                    {
                        MessageBox.Show("Há pendências nesta separação impossibilitando a finalização!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCodProduto.Focus();
                        return;                        
                    }
                }
            }

            if (btnFinalizar.Text != "IMPRIMIR" &&
                MessageBox.Show("Deseja realmente finalizar a separação deste kit ?", "Gestão de Materiais e Medicamentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                SegurancaDTO dtoUsuario = FrmLogin.Logar(true);
                if (dtoUsuario != null)
                {
                    Kit.UpdSaldoKitImpressp(_idKitSaldo.Value);

                    _dtFinal = Utilitario.ObterDataHoraServidor();
                    _usuarioSeparacao = dtoUsuario.NmUsuario.Value;

                    tsHac.Items["tsBtnNovo"].Enabled = true;
                    tsHac.Items["tsBtnCancelar"].Enabled = txtCodProduto.Enabled = dtgMatMed.Columns[colDel.Name].Visible = false;
                    btnFinalizar.Text = "IMPRIMIR";
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    return;
                }
                this.Cursor = Cursors.Default;
            }

            if (btnFinalizar.Text == "IMPRIMIR")
            {
                this.Cursor = Cursors.WaitCursor;
                string nomeRelatorio = "GM_46_KIT_SEPARACAO";
                Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[6];

                #region Monta Parâmetros

                byte x = 0;

                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_KIT_SALDO_ID", _idKitSaldo.Value.ToString());                
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_SET_DS_SETOR", cmbSetor.Text);                
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_KIT_DSC", cmbKit.Text);
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDATA", _dtFinal.Value.ToString("dd/MM/yyyy HH:mm"));
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("USUARIO", _usuarioSeparacao);
                

                #endregion

                Microsoft.Reporting.WinForms.ReportParameter[] reportParamTemp = new Microsoft.Reporting.WinForms.ReportParameter[x];

                for (int i = 0; i < reportParam.Length; i++)
                {
                    if (reportParam[i] == null) break;
                    reportParamTemp[i] = reportParam[i];
                }
                reportParam = reportParamTemp;
                reportParamTemp = null;

                FrmReportViewer frmRelatorio = new FrmReportViewer();
                frmRelatorio.AbreRelatorio(nomeRelatorio, reportParam);
            }
            this.Cursor = Cursors.Default;
        }

        #endregion        
    }
}