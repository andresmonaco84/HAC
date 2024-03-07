using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Relatorio;
using HospitalAnaCosta.SGS.Componentes;
using Microsoft.ReportingServices.ReportRendering;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    public partial class FrmEstoque : FrmBase
    {
        public FrmEstoque()
        {
            InitializeComponent();
        }        

        #region OBJETOS SERVIÇO

        // Estoque        
        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject( typeof(IEstoqueLocal)); }
        }
        private EstoqueLocalDTO dtoEstoque;
        private EstoqueLocalDataTable dtbEstoque;
        
        #endregion

        #region MÉTODOS
        
        private void ConfiguraCombos()
        {
            //cmbUnidade.Enabled = false;
            //cmbUnidade.Editavel = ControleEdicao.Nunca;
            //cmbUnidade.SelectedValue = FrmPrincipal.dtoSeguranca.IdtUnidade.Value;

            //cmbLocal.Enabled = false;
            //cmbLocal.Editavel = ControleEdicao.Nunca;
            //cmbLocal.SelectedValue = FrmPrincipal.dtoSeguranca.IdtLocal.Value;

            //cmbSetor.Enabled = false;
            //cmbSetor.Editavel = ControleEdicao.Nunca;
            //cmbSetor.SelectedValue = FrmPrincipal.dtoSeguranca.IdtSetor.Value;                       
        }
               
        private void CarregaItens()
        {
            if (cmbUnidade.SelectedIndex == -1 || cmbLocal.SelectedIndex == -1 || cmbSetor.SelectedIndex == -1)
            {
                rbHac.Checked = false;
                rbAcs.Checked = false;
                rbCE.Checked = false;
                MessageBox.Show("Selecione Unidade/Local/Setor Para Pesquisa", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                dtgMatMed.DataSource = null;
                ConfiguraEstoqueDTO();
                dtbEstoque = Estoque.Sel(dtoEstoque);
                dtgMatMed.DataSource = dtbEstoque;
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Configura Colunas do Data Grid baseado nos campos do dto
        /// </summary>
        private void ConfiguraDTG()
        {
            dtgMatMed.AutoGenerateColumns = false;
            dtgMatMed.Columns["colIdtProduto"].DataPropertyName = EstoqueLocalDTO.FieldNames.IdtProduto;
            dtgMatMed.Columns["colIdtProduto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgMatMed.Columns["colDsProduto"].DataPropertyName = EstoqueLocalDTO.FieldNames.DsProduto;

            dtgMatMed.Columns["colQtdePadrao"].DataPropertyName = EstoqueLocalDTO.FieldNames.QtdePadrao;            
            dtgMatMed.Columns["colQtdePadrao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgMatMed.Columns["colQtdePadrao"].DefaultCellStyle.Format = "N0";            

            dtgMatMed.Columns["colFornecido"].DataPropertyName = EstoqueLocalDTO.FieldNames.SaldoMovimentacao;
            dtgMatMed.Columns["colFornecido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgMatMed.Columns["colFornecido"].DefaultCellStyle.Format = "N0";

            dtgMatMed.Columns["colQtdeEstoque"].DataPropertyName = EstoqueLocalDTO.FieldNames.Qtde;
            dtgMatMed.Columns["colQtdeEstoque"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgMatMed.Columns["colQtdeEstoque"].DefaultCellStyle.Format = "N0";

            dtgMatMed.Columns["colOutros"].DataPropertyName = EstoqueLocalDTO.FieldNames.OutrosConsumos;
            dtgMatMed.Columns["colOutros"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgMatMed.Columns["colOutros"].DefaultCellStyle.Format = "N0";

            dtgMatMed.Columns["colConsumido"].DataPropertyName = EstoqueLocalDTO.FieldNames.Consumido;
            dtgMatMed.Columns["colConsumido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgMatMed.Columns["colConsumido"].DefaultCellStyle.Format = "N0";

            dtgMatMed.Columns["colPercentual"].DataPropertyName = EstoqueLocalDTO.FieldNames.Percentual;
            dtgMatMed.Columns["colPercentual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

            dtgMatMed.Columns["colFlFracionado"].DataPropertyName = EstoqueLocalDTO.FieldNames.FlFracionado;
            dtgMatMed.Columns["colTpMatMed"].DataPropertyName = EstoqueLocalDTO.FieldNames.Tabelamedica;            

            dtgMatMed.Columns["colDtFornecimento"].DataPropertyName = EstoqueLocalDTO.FieldNames.DataFornecimento;
            dtgMatMed.Columns["colDtFornecimento"].DefaultCellStyle.Format = "dd/MM/yyyy à\\s HH:mm:ss";

            dtgMatMed.Columns["colPercRessuprimento"].DataPropertyName = EstoqueLocalDTO.FieldNames.PontoRessuprimento;
            // dtgMatMed.Columns["colPercentual"].DefaultCellStyle.Format = "P02";
        }

        private void ConfiguraEstoqueDTO()
        {
            dtoEstoque = new EstoqueLocalDTO();

            dtoEstoque.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoEstoque.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoEstoque.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
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
        
        #endregion

        #region EVENTOS

        private void FrmEstoqueOnLine_Load(object sender, EventArgs e)
        {
            cmbUnidade.Carregaunidade();            
            ConfiguraCombos();
            ConfiguraDTG();
        }

        private void rbHac_Click(object sender, EventArgs e)
        {
            CarregaItens();
        }

        private void rbAcs_Click(object sender, EventArgs e)
        {
            CarregaItens();
        }

        private void rbCE_Click(object sender, EventArgs e)
        {
            CarregaItens();
        }

        private void dtgMatMed_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.BackColor = Color.LightBlue;
            if (dtbEstoque != null)
            {
                if (dtbEstoque.Rows.Count > 0 && dtbEstoque.Rows.Count == dtgMatMed.Rows.Count)
                {
                    if (!string.IsNullOrEmpty(dtgMatMed.Rows[e.RowIndex].Cells["colQtdePadrao"].Value.ToString()))
                    {
                        e.CellStyle.BackColor = Color.White;
                        string padrao = dtgMatMed.Rows[e.RowIndex].Cells["colQtdePadrao"].Value.ToString();
                        string fornecido = dtgMatMed.Rows[e.RowIndex].Cells["colFornecido"].Value.ToString();                        
                        string consumo = dtgMatMed.Rows[e.RowIndex].Cells["colConsumido"].Value.ToString();
                        string outrosConsumo = dtgMatMed.Rows[e.RowIndex].Cells["colOutros"].Value.ToString();
                        decimal saldo = decimal.Parse(dtgMatMed.Rows[e.RowIndex].Cells["colQtdeEstoque"].Value.ToString());
                        if (string.IsNullOrEmpty(fornecido)) fornecido = "0";
                        if (!string.IsNullOrEmpty(consumo) || !string.IsNullOrEmpty(outrosConsumo))
                        {
                            if (string.IsNullOrEmpty(consumo)) consumo = "0";
                            if (string.IsNullOrEmpty(outrosConsumo)) outrosConsumo = "0";
                            decimal calculoRef = decimal.Parse(fornecido); //Variável calculoRef pode ser pelo fornecido, ou padrao, quando fornecido for 0
                            if (decimal.Parse(fornecido) == 0) calculoRef = decimal.Parse(padrao);
                            decimal calculo = calculoRef - decimal.Parse(consumo) - decimal.Parse(outrosConsumo);
                            //Quando cálculo referente aos consumos não bater com saldo, a fonte do saldo ficará vermelha
                            if (calculo != saldo) dtgMatMed.Rows[e.RowIndex].Cells["colQtdeEstoque"].Style.ForeColor = Color.DarkRed;
                        }
                        else
                        {
                            //Se não tiver nenhum consumo, e saldo for maior que o padrão, a fonte do saldo ficará vermelha
                            if (saldo > decimal.Parse(padrao)) dtgMatMed.Rows[e.RowIndex].Cells["colQtdeEstoque"].Style.ForeColor = Color.DarkRed;
                        }
                        if (decimal.Parse(fornecido) > 0 && fornecido != padrao)
                        {
                            //Se qtd. fornecida for diferente da padrão, a fonte da qtd. fornecida ficará vermelha
                            dtgMatMed.Rows[e.RowIndex].Cells["colFornecido"].Style.ForeColor = Color.DarkRed;
                        }                        
                        if (!string.IsNullOrEmpty(dtgMatMed.Rows[e.RowIndex].Cells["colPercentual"].Value.ToString()))
                        {
                            decimal percentual = decimal.Parse(dtgMatMed.Rows[e.RowIndex].Cells["colPercentual"].Value.ToString());
                            if (percentual >= decimal.Parse(dtgMatMed.Rows[e.RowIndex].Cells["colPercRessuprimento"].Value.ToString()) && percentual <= 79)
                            {
                                if (dtgMatMed.Columns[e.ColumnIndex].Name == "colPercentual") e.CellStyle.BackColor = Color.Yellow;
                            }
                            if (percentual >= 80 && percentual <= 99)
                            {
                                if (dtgMatMed.Columns[e.ColumnIndex].Name == "colPercentual") e.CellStyle.BackColor = Color.Orange;
                            }
                            if (percentual == 100)
                            {
                                if (dtgMatMed.Columns[e.ColumnIndex].Name == "colPercentual") e.CellStyle.BackColor = Color.Red;                                    
                            }                          
                        }
                        if (dtgMatMed.Columns[e.ColumnIndex].Name == "colQtdePadrao") e.CellStyle.BackColor = Color.LightGray;                        
                        if (dtgMatMed.Columns[e.ColumnIndex].Name == "colQtdeEstoque") e.CellStyle.BackColor = Color.LightGray;                            
                    }
                }
            }            
        }

        private void dtgMatMed_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgMatMed.Columns[e.ColumnIndex].Name == "colSimilar")
            {
                this.Cursor = Cursors.WaitCursor;
                MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();
                dtoMatMed.Idt.Value = Convert.ToDecimal(dtgMatMed.Rows[e.RowIndex].Cells["colIdtProduto"].Value.ToString());                
                new FrmPesquisaSimilares().VisualizarSimilares(dtoMatMed);
                this.Cursor = Cursors.Default;
            }
        }

        private void cmbUnidade_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tsHac.Controla(Evento.eCancelar);
        }

        private void cmbLocal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tsHac.Controla(Evento.eCancelar);
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tsHac.Controla(Evento.eCancelar);
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            dtgMatMed.Columns["colIdtProduto"].Visible = !(dtgMatMed.Columns["colIdtProduto"].Visible);
            //dtgMatMed.Columns["colFlFracionado"].Visible = !(dtgMatMed.Columns["colFlFracionado"].Visible);
            // dtgMatMed.Columns["colTpMatMed"].Visible = !(dtgMatMed.Columns["colTpMatMed"].Visible);
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            #region Monta Parâmetros           
          
            int x = 0;

            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[20];
            string Relatorio = "GM_01_MTMD_INDICE_ROT";

            //reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_FILIAL_ID", "1");
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDATA_DE", DateTime.Now.AddDays(-9).ToString());
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDATA_ATE", DateTime.Now.ToString());
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("USUARIO", "teste");
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PRODUTO", "teste");
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("FILIAL", "teste");
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("GRUPO", "teste");
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("SUBGRUPO", "teste");
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("DT_INI", "teste");
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("DT_FIM", "teste");

            //if (cboUnidade.SelectedIndex != -1)
            //{
            //    reportParam[x++] = new ReportParameter("PCAD_MTMD_FILIAL_ID", cboUnidade.SelectedValue.ToString());
            //    reportParam[x++] = new ReportParameter("FILIAL", cboUnidade.Text);
            //}
            //if (cboLocal.SelectedIndex != -1)
            //{
            //    reportParam[x++] = new ReportParameter("PCAD_MTMD_GRUPO_ID", cboLocal.SelectedValue.ToString());
            //    reportParam[x++] = new ReportParameter("GRUPO", cboLocal.Text);
            //}
            //if (cboSetor.SelectedIndex != -1)
            //{
            //    reportParam[x++] = new ReportParameter("PCAD_MTMD_SUBGRUPO_ID", cboSetor.SelectedValue.ToString());
            //    reportParam[x++] = new ReportParameter("SUBGRUPO", cboSetor.Text);
            //}
            //else
            //{
            //    reportParam[x++] = new ReportParameter("PDATA_DE", "Todos");
            //    reportParam[x++] = new ReportParameter("PDATA_DE", "Todos");
            //    reportParam[x++] = new ReportParameter("PDATA_DE", "Todos");
            //    reportParam[x++] = new ReportParameter("PDATA_DE", "Todos");
            //}
            //if (cboSetor.SelectedIndex != -1)
            //{
            //    reportParam[x++] = new ReportParameter("PCAD_MTMD_ID", cboSetor.SelectedValue.ToString());
            //    reportParam[x++] = new ReportParameter("PRODUTO", cboSetor.Text);
            //}
            //PCAD_MTMD_ID

            #endregion

            Microsoft.Reporting.WinForms.ReportParameter[] reportParamTemp = new Microsoft.Reporting.WinForms.ReportParameter[x];

            for (int i = 0; i < reportParam.Length; i++)
            {
                if (reportParam[i] == null)
                    break;
                reportParamTemp[i] = reportParam[i];
            }
            reportParam = reportParamTemp;
            reportParamTemp = null;

            FrmReportViewer frmRelatorio = new FrmReportViewer();
            frmRelatorio.AbreRelatorio(Relatorio, reportParam);
            //return true;
        }
    }
}