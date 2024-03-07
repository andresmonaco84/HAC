using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Reporting.WinForms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using Microsoft.ReportingServices.ReportRendering;
using System.IO;
using System.Threading;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    public partial class FrmPosicaoMensalProduto : FrmBase
    {
        // Utilitario
        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        // GrupoMatMed        
        private IGrupoMatMed _grupoMatMed;
        private IGrupoMatMed GrupoMatMed
        {
            get { return _grupoMatMed != null ? _grupoMatMed : _grupoMatMed = (IGrupoMatMed)Global.Common.GetObject(typeof(IGrupoMatMed)); }
        }

        // SubGrupoMatMed
        private SubGrupoMatMedDTO dtoSubGrupo;
        private ISubGrupoMatMed _subGrupoMatMed;
        private ISubGrupoMatMed SubGrupoMatMed
        {
            get { return _subGrupoMatMed != null ? _subGrupoMatMed : _subGrupoMatMed = (ISubGrupoMatMed)Global.Common.GetObject(typeof(ISubGrupoMatMed)); }
        }

        // Movimentacao
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }

        // MovimentacaoMensal
        private IMovimentacaoMensal _movimentoMensal;
        private IMovimentacaoMensal MovimentoMensal
        {
            get { return _movimentoMensal != null ? _movimentoMensal : _movimentoMensal = (IMovimentacaoMensal)Global.Common.GetObject(typeof(IMovimentacaoMensal)); }
        }
        
        private bool _saidas;
        public bool Saidas
        {
            set { _saidas = value; }
            get { return _saidas; }
        }

        private bool _entradasConf;
        public bool EntradasConferencia
        {
            set { _entradasConf = value; }
            get { return _entradasConf; }
        }

        private bool _divergenciasEstCont;
        public bool DivergenciasContabil_X_Estoque
        {
            set { _divergenciasEstCont = value; }
            get { return _divergenciasEstCont; }
        }

        public FrmPosicaoMensalProduto()
        {
            InitializeComponent();
        }

        private void CarregarComboGrupo()
        {            
            cmbGrupo.DataSource = GrupoMatMed.Sel(new GrupoMatMedDTO()); 
            cmbGrupo.IniciaLista();
        }

        private void CarregarComboSubGrupo()
        {
            dtoSubGrupo = new SubGrupoMatMedDTO();
            dtoSubGrupo.IdtGrupo.Value = cmbGrupo.SelectedValue.ToString();
            cmbSubGrupo.ValueMember = SubGrupoMatMedDTO.FieldNames.Idt;
            cmbSubGrupo.DisplayMember = SubGrupoMatMedDTO.FieldNames.DsSubGrupo;
            cmbSubGrupo.DataSource = SubGrupoMatMed.Sel(dtoSubGrupo);
            cmbSubGrupo.IniciaLista();
        }

        private void ExecRelatorio()
        {
            string nomeRelatorio = chbInventario.Checked ? "GM_MovimentacaoMensalInventario" : "GM_MovimentacaoMensal";
            if (chbContabil.Checked) nomeRelatorio = "GM_MovimentacaoMensalInvCont";

            if (Saidas)
            {                
                if (rbUHAnal.Checked)
                {
                    nomeRelatorio = "GM_MovimentacaoMensal_saidasUnidades";
                }
                else if (rbUHSint.Checked)
                {
                    nomeRelatorio = "GM_MovimentacaoMensal_saidasUnidadesSintetico";
                }
                else if (rbCentroCustoData.Checked)
                {
                    nomeRelatorio = "GM_MovimentacaoMensal_SaidasCCusto";
                }
                else if (rbCentroCustoAnal.Checked)
                {
                    nomeRelatorio = "GM_MovimentacaoMensal_SaidasCCustoSintetico";
                }
                else if (rbCentroCustoSint.Checked)
                {
                    nomeRelatorio = "GM_MovimentacaoMensal_SaidasCCustoSintetico02";
                }
            }
            else if (EntradasConferencia)
            {
                nomeRelatorio = !chbGrupo.Checked ? "GM_MovimentacaoMensal_EntradasConf" : "GM_MovimentacaoMensal_TrocaGrupoConf"; 
            }
            else if (DivergenciasContabil_X_Estoque)
            {
                nomeRelatorio = !chbGrupo.Checked ? "GM_08_CONTABIL_X_ESTOQUE" : "GM_10_CONTABIL_X_ESTOQUE_GRUPO";
            }
            else if (chbGrupo.Checked)
            {
                if (chbContabil.Checked)
                    nomeRelatorio = "GM_MovimentacaoMensalGrupoInvCont";
                else
                    nomeRelatorio = chbInventario.Checked ? "GM_MovimentacaoMensalGrupoInventario" : "GM_MovimentacaoMensalGrupo";
            }

            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[22];

            #region Monta Parâmetros

            int x = 0;

            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_FILIAL_ID", rbHac.Checked ? "1" : "2");
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_MOV_MES", txtMes.Text);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_MOV_ANO", txtAno.Text);
            if (!DivergenciasContabil_X_Estoque && nomeRelatorio != "GM_MovimentacaoMensalInvCont")
            {
                if (!Saidas && !EntradasConferencia)
                {
                    if (cmbUnidade.SelectedValue.ToString() != "244")//Só envia unidade quando não for Santos
                    {
                        reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pCAD_UNI_ID_UNIDADE", cmbUnidade.SelectedValue.ToString());
                        reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pDESCRICAO_UNIDADE", cmbUnidade.Text);
                    }
                    if (!chbGrupo.Checked && cmbGrupo.SelectedIndex > -1 && cmbGrupo.Text != string.Empty)
                    {
                        reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pCAD_MTMD_GRUPO_ID", cmbGrupo.SelectedValue.ToString());
                        if (cmbSubGrupo.SelectedIndex > -1 && cmbSubGrupo.Text != string.Empty)
                            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pCAD_MTMD_SUBGRUPO_ID", cmbSubGrupo.SelectedValue.ToString());
                    }
                    if (chbContabil.Checked && nomeRelatorio == "GM_MovimentacaoMensalGrupoInvCont")
                    {
                        if (chbPadrao.Visible && chbPadrao.Checked)
                            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pCAD_MTMD_FL_PADRAO", "1");

                        if (chbPadraoNao.Visible && chbPadraoNao.Checked)
                            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pCAD_MTMD_FL_PADRAO", "0");
                    }
                }
                else if (!EntradasConferencia)
                {
                    if (rbUHAnal.Checked) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pRETIRAR_SANTOS", "1");
                    if (rbCentroCustoData.Checked || rbCentroCustoAnal.Checked)
                    {
                        if (chbDevolucao.Checked) reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pDEVOLUCAO", "1");
                        if (chbQuebra.Checked)
                            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pQUEBRAS", "1");
                        else
                            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pQUEBRAS", "2");
                    }
                }
            }
            else if (DivergenciasContabil_X_Estoque || nomeRelatorio == "GM_MovimentacaoMensalInvCont")
            {
                //DivergenciasContabil_X_Estoque
                if (!chbGrupo.Checked && cmbGrupo.SelectedIndex > -1 && cmbGrupo.Text != string.Empty)
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_GRUPO_ID", cmbGrupo.SelectedValue.ToString());
                if (nomeRelatorio == "GM_MovimentacaoMensalInvCont")
                {
                    if (cmbSubGrupo.SelectedIndex > -1 && cmbSubGrupo.Text != string.Empty)
                        reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_SUBGRUPO_ID", cmbSubGrupo.SelectedValue.ToString());
                }

                string dataDe = "01/" + txtMes.Text.PadLeft(2, '0') + "/" + txtAno.Text;
                string dataAte = DateTime.DaysInMonth(int.Parse(txtAno.Text), int.Parse(txtMes.Text)).ToString() + "/" + txtMes.Text.PadLeft(2, '0') + "/" + txtAno.Text;

                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDATA_DE", dataDe);
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDATA_ATE", dataAte);

                if (chbContabil.Checked)
                {
                    if (chbPadrao.Visible && chbPadrao.Checked)
                        reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_FL_PADRAO", "1");

                    if (chbPadraoNao.Visible && chbPadraoNao.Checked)
                        reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_FL_PADRAO", "0");
                }
            }
            //reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("usuario", FrmPrincipal.dtoSeguranca.Login.Value);
            //reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("sTitulo", "POSIÇÃO MENSAL DE ESTOQUE REF: " + txtMes.Text + '/' + txtAno.Text);

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
            frmRelatorio.MdiParent = FrmPrincipal.ActiveForm;
            frmRelatorio.AbreRelatorio(nomeRelatorio, reportParam);
            //tsHac.Focus();
            //this.WindowState = FormWindowState.Normal;
        }

        private bool ValidarMesAno()
        {
            if (txtMes.Text != string.Empty && txtAno.Text != string.Empty)
            {
                if (int.Parse(txtMes.Text) <= 0 || int.Parse(txtMes.Text) > 12)
                {
                    MessageBox.Show("Mês inválido", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (int.Parse(txtAno.Text) < 1900 || int.Parse(txtAno.Text) > 2099)
                {
                    MessageBox.Show("Ano inválido", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //Por enquanto que não está online o processo, deixar consultar o mês atual apenas para a prévia das entradas
                if (EntradasConferencia && !chbGrupo.Checked) return true;
                string mesAtual, mesPesquisa;
                mesAtual = Utilitario.ObterDataHoraServidor().Month.ToString();
                mesAtual = mesAtual.Length == 1 ? "0" + mesAtual : mesAtual;
                mesAtual = Utilitario.ObterDataHoraServidor().Year.ToString() + mesAtual;
                mesPesquisa = txtMes.Text;
                mesPesquisa = mesPesquisa.Length == 1 ? "0" + mesPesquisa : mesPesquisa;
                mesPesquisa = txtAno.Text + mesPesquisa;
                if (int.Parse(mesPesquisa) > int.Parse(mesAtual))
                {
                    MessageBox.Show("O mês tem que ser menor ou igual ao atual", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (DivergenciasContabil_X_Estoque && int.Parse(txtAno.Text) < 2017)
                {
                    MessageBox.Show("Busca permitida a partir de 2017", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (int.Parse(mesPesquisa) == int.Parse(mesAtual))
                {
                    DateTime? data = MovimentoMensal.ObterUltimaDataFechamento();
                    if (data != null)
                        MessageBox.Show("Relatório de estimativa prévia do mês atual com dados atualizados até " + data.Value.ToString("dd/MM/yyyy"), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return true;
            }
            else
            {
                MessageBox.Show("Informe o Mês/Ano", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }            
        }

        private void FrmPosicaoMensalProduto_Load(object sender, EventArgs e)
        {
            if (Saidas)
            {
                tsRel.TituloTela = "Saídas/Despesas das Unidades";
                chbGrupo.Visible = false;
                grbPosMensal.Visible = false;
                grbSaidas.Visible = true;
            }
            else if (EntradasConferencia)
            {
                tsRel.TituloTela = "Conferência do total de NFs e grupo de mat/med";
                chbGrupo.Text = "Troca de Grupo";
                grbPosMensal.Visible = false;
                this.Height = 120;
            }            
            else
            {
                if (DivergenciasContabil_X_Estoque)
                {
                    tsRel.TituloTela = "Divergências Contábil X Estoque";
                    cmbUnidade.Enabled = false;
                    lblSubGrupo.Visible = false;
                    cmbSubGrupo.Visible = false;
                }
                else
                    btnExcel.Visible = chbPadraoNao.Visible = chbPadrao.Visible = true;
                cmbUnidade.Carregaunidade();
                DataTable dtbUnidade = (DataTable)cmbUnidade.DataSource;
                dtbUnidade.Select(string.Format("{0}=244", UnidadeDTO.FieldNames.Idt))[0][UnidadeDTO.FieldNames.DsUnidade] = "SANTOS / GERAL REGIONAIS";
                cmbUnidade.SelectedValue = 244;//SANTOS = GERAL
                cmbUnidade.Enabled = false;
                CarregarComboGrupo();
                if (!DivergenciasContabil_X_Estoque)
                    grbGerarPrevia.Visible = new Generico().VerificaAcessoFuncionalidade("GerarPreviaFechamento");

                if (!DivergenciasContabil_X_Estoque) chbContabil.Visible = chbContabil.Checked = true;
            }
            txtMes.Text = Utilitario.ObterDataHoraServidor().AddMonths(-1).Month.ToString();
            txtAno.Text = Utilitario.ObterDataHoraServidor().AddMonths(-1).Year.ToString();
            //nmMes.Minimum = 1;
            //nmMes.Maximum = 12;
            tsRel.Items["tsBtnPesquisar"].Enabled = true;
        }

        private bool hacToolStrip1_ImprimirClick(object sender)
        {
            if (this.ValidarMesAno())
            {
                ExecRelatorio();
                return true;
            }
            return false;
        }

        private void chbDevolucao_Click(object sender, EventArgs e)
        {
            chbQuebra.Checked = false;
            if (chbDevolucao.Checked)
            {
                rbUHAnal.Enabled = rbUHSint.Enabled = rbCentroCustoSint.Enabled = false;
                rbCentroCustoData.Checked = true;
            }
            else
            {
                rbUHAnal.Enabled = rbUHSint.Enabled = rbCentroCustoSint.Enabled = true;
            }
        }

        private void chbQuebra_Click(object sender, EventArgs e)
        {
            chbDevolucao.Checked = false;
            if (chbQuebra.Checked)
            {
                rbUHAnal.Enabled = rbUHSint.Enabled = rbCentroCustoSint.Enabled = false;
                rbCentroCustoData.Checked = true;
            }
            else
            {
                rbUHAnal.Enabled = rbUHSint.Enabled = rbCentroCustoSint.Enabled = true;
            }
        }  
       
        private void rbUHAnal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUHAnal.Checked)
            {
                chbQuebra.Checked = chbDevolucao.Checked = false;
                chbQuebra.Enabled = chbDevolucao.Enabled = false;
            }            
        }

        private void rbUHSint_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUHSint.Checked)
            {
                chbQuebra.Checked = chbDevolucao.Checked = false;
                chbQuebra.Enabled = chbDevolucao.Enabled = false;
            }            
        }

        private void rbCentroCustoData_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCentroCustoData.Checked) chbQuebra.Enabled = chbDevolucao.Enabled = true;
        }

        private void rbCentroCustoAnal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCentroCustoAnal.Checked) chbQuebra.Enabled = chbDevolucao.Enabled = true;
        }

        private void rbCentroCustoSint_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCentroCustoSint.Checked)
            {
                chbQuebra.Checked = chbDevolucao.Checked = false;
                chbQuebra.Enabled = chbDevolucao.Enabled = false;
            }            
        }

        private void chbGrupo_Click(object sender, EventArgs e)
        {
            //chbContabil.Visible = chbContabil.Checked = false;
            cmbGrupo.IniciaLista();
            if (chbGrupo.Checked)
            {                
                cmbSubGrupo.DataSource = null;                
                cmbGrupo.Enabled = cmbSubGrupo.Enabled = false;
                //if (!DivergenciasContabil_X_Estoque && !EntradasConferencia) chbContabil.Visible = chbContabil.Checked = true;
            }
            else
            {
                cmbGrupo.Enabled = cmbSubGrupo.Enabled = true;
            }
        }

        private void cmbGrupo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbGrupo.SelectedIndex > -1)
            {
                chbGrupo.Checked = false;
                //chbGrupo.Enabled = false;
                if (cmbGrupo.Visible) CarregarComboSubGrupo();
            }
            else
            {
                //chbGrupo.Checked = true;
                chbGrupo.Enabled = true;
            }
        }

        private void cmbUnidade_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (chbInventario.Checked &&
                (cmbUnidade.SelectedValue != null && cmbUnidade.SelectedValue.ToString() != "244"))
                chbInventario.Checked = false;
        }

        private void chbInventario_Click(object sender, EventArgs e)
        {
            if (chbInventario.Checked)
                cmbUnidade.SelectedValue = 244; //Santos
        }    

        private void btnGerarArquivo_Click(object sender, EventArgs e)
        {
            if (this.ValidarMesAno())
            {
                this.Cursor = Cursors.WaitCursor;
                decimal total = 0;
                MovimentacaoMensalDTO dto = new MovimentacaoMensalDTO();
                dto.IdtFilial.Value = ((byte)FilialMatMedDTO.Filial.HAC).ToString();
                dto.Mes.Value = txtMes.Text;
                dto.Ano.Value = txtAno.Text;
                DataTable dtMov;
                if (chbNovoFormato.Checked)
                    dtMov = Movimento.SelMovArquivoContHeader(dto);
                else
                    dtMov = Movimento.SelMovArquivoCont(dto);
                if (dtMov.Rows.Count > 0)
                {
                    sfDir.Filter = "Arquivos txt (*.txt)|*.txt";
                    if (sfDir.ShowDialog() == DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        if (sfDir.FileName.IndexOf(".txt") == -1) sfDir.FileName += ".txt";
                        StreamWriter arqTexto = new StreamWriter(sfDir.FileName);                        
                        foreach (DataRow dr in dtMov.Rows)
                        {
                            arqTexto.WriteLine(dr["TXT_GERAR"].ToString());
                            total += decimal.Parse(dr["VALOR"].ToString());
                        }
                        arqTexto.Close();                        
                        MessageBox.Show("Arquivo gerado com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Não existem dados para a geração do arquivo", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                lblTotal.Text = total.ToString("N2");
                this.Cursor = Cursors.Default;
            }            
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (this.ValidarMesAno())
            {
                this.Cursor = Cursors.WaitCursor;

                //DataTable dtb;
                //if (chbGrupo.Checked)
                //    dtb = MovimentoMensal.ObterValoresMovGrupo(int.Parse(txtAno.Text), byte.Parse(txtMes.Text), byte.Parse(rbHac.Checked ? "1" : "2"));
                //else
                //    dtb = MovimentoMensal.ObterValoresMovProdutos(int.Parse(txtAno.Text), byte.Parse(txtMes.Text), byte.Parse(rbHac.Checked ? "1" : "2"));
                //Generico.ExportarExcel(dtb);

                string nomeRelatorio = "GM_48_CUSTO_MEDIO_COMPARA";

                Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[8];

                #region Monta Parâmetros

                int x = 0;

                string dataDe = "01/" + txtMes.Text.PadLeft(2, '0') + "/" + txtAno.Text;
                string dataAte = DateTime.DaysInMonth(int.Parse(txtAno.Text), int.Parse(txtMes.Text)).ToString() + "/" + txtMes.Text.PadLeft(2, '0') + "/" + txtAno.Text;
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDATA_DE", dataDe);
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDATA_ATE", dataAte);
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("COL_QTD_ATUAL", "Qtd. Cons. - " + DateTime.Parse(dataDe).ToString("MM/yy"));
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("COL_CM_ATUAL", "Custo Médio Unit. - " + DateTime.Parse(dataDe).ToString("MM/yy"));

                string dataDeAnterior = "01/" + DateTime.Parse(dataDe).AddMonths(-1).ToString("MM/") + DateTime.Parse(dataDe).AddMonths(-1).ToString("yyyy");
                string dataAteAnterior = DateTime.DaysInMonth(int.Parse(DateTime.Parse(dataDeAnterior).ToString("yyyy")), int.Parse(DateTime.Parse(dataDeAnterior).ToString("MM"))).ToString() +
                                         DateTime.Parse(dataDeAnterior).ToString("/MM/") + DateTime.Parse(dataDeAnterior).ToString("yyyy");
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDATA_DE_ANTERIOR", dataDeAnterior);
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDATA_ATE_ANTERIOR", dataAteAnterior);
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("COL_QTD_ANT", "Qtd. Cons. - " + DateTime.Parse(dataDeAnterior).ToString("MM/yy"));
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("COL_CM_ANT", "Custo Médio Unit. - " + DateTime.Parse(dataDeAnterior).ToString("MM/yy"));                
                
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
                frmRelatorio.MdiParent = FrmPrincipal.ActiveForm;
                frmRelatorio.AbreRelatorio(nomeRelatorio, reportParam);

                this.Cursor = Cursors.Default;
            }
        }

        private void btnPlanQtdsConsCCusto_Click(object sender, EventArgs e)
        {
            if (this.ValidarMesAno())
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtb = MovimentoMensal.ObterQtdsConsumoCCusto(int.Parse(txtAno.Text), byte.Parse(txtMes.Text), byte.Parse(rbHac.Checked ? "1" : "2"));
                Generico.ExportarExcel(dtb);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnGerarPrevia_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Lembrando que este é um processamento de dados demorado, deseja realmente gerar a prévia deste mês ?",
                                 "Gestão de Materiais e Medicamentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new Thread(new ThreadStart(ExecPrevia)).IsBackground = true;
                new Thread(new ThreadStart(ExecPrevia)).Start();
                emExecucao = true;
                timer.Start();                
                lblDataAtualizacaoPrevia.Text = "Processamento iniciado...";

                //SEM THREAD COMENTADA
                //this.Cursor = Cursors.WaitCursor;
                //MovimentoMensal.GerarPreviaMes();
                //this.Cursor = Cursors.Default;
                //MessageBox.Show("Prévia processada com sucesso, com dados atualizados até a data de ontem. Já pode emitir os relatórios.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        bool emExecucao;
        private void ExecPrevia() 
        { 
            MovimentoMensal.GerarPreviaMes();            
            emExecucao = false;
            MessageBox.Show("Prévia processada com sucesso, com dados atualizados até a data de ontem. Já pode emitir os relatórios.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime? dataUltimaExecucao = MovimentoMensal.ObterUltimaDataExecucaoFechamento();
            if (dataUltimaExecucao != null)
            {
                double minutosPassadosUltimaExec = Utilitario.ObterDataHoraServidor().Subtract(dataUltimaExecucao.Value).TotalMinutes;
                if (minutosPassadosUltimaExec > 5) return; //Ainda realizando pré-execução

                if (!emExecucao)
                {
                    timer.Stop();
                    lblDataAtualizacaoPrevia.Text = "PRÉVIA JÁ PROCESSADA !";
                }
                else
                    lblDataAtualizacaoPrevia.Text = "Processando prévia...";
            }            
        }

        private void chbContabil_Click(object sender, EventArgs e)
        {
            if (!chbContabil.Checked)
            {
                chbPadrao.Checked = chbPadraoNao.Checked = false;
                chbPadrao.Enabled = chbPadraoNao.Enabled = false;
            }
            else
                chbPadrao.Enabled = chbPadraoNao.Enabled = true;
        }

        private void chbPadraoNao_Click(object sender, EventArgs e)
        {
            if (chbPadraoNao.Checked)
                chbPadrao.Checked = false;
        }

        private void chbPadrao_Click(object sender, EventArgs e)
        {
            if (chbPadrao.Checked)
                chbPadraoNao.Checked = false;
        }
    }
}