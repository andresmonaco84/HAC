using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Reporting.WinForms;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.GestaoMateriais.Relatorio;
using Microsoft.ReportingServices.ReportRendering;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    public partial class FrmLivroRegistro : FrmBase
    {
        private const string matMedInicio = "<SELECIONE O PRODUTO CLICANDO NO BOTÃO 'Mat/Med'>";
        private MaterialMedicamentoDTO dtoMatMed;
        
        private ILivroRegistroMovimentos _livroRegistroMov;
        private ILivroRegistroMovimentos LivroRegistroMov
        {
            get { return _livroRegistroMov != null ? _livroRegistroMov : _livroRegistroMov = (ILivroRegistroMovimentos)Global.Common.GetObject(typeof(ILivroRegistroMovimentos)); }
        }
        
        public FrmLivroRegistro()
        {
            InitializeComponent();
        }

        private void ConfigurarGrid()
        {
            dtgItem.AutoGenerateColumns = false;
            dtgItem.Columns[colId.Name].DataPropertyName = LivroRegistroMovimentosDTO.FieldNames.IdtLivro;
            dtgItem.Columns[colIdProduto.Name].DataPropertyName = LivroRegistroMovimentosDTO.FieldNames.IdtProduto;
            dtgItem.Columns[colData.Name].DataPropertyName = LivroRegistroMovimentosDTO.FieldNames.DataRegistro;
            dtgItem.Columns[colData.Name].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgItem.Columns[colHistorico.Name].DataPropertyName = LivroRegistroMovimentosDTO.FieldNames.Historico;
            dtgItem.Columns[colHistManual.Name].DataPropertyName = LivroRegistroMovimentosDTO.FieldNames.HistoricoManual;
            dtgItem.Columns[colObs.Name].DataPropertyName = LivroRegistroMovimentosDTO.FieldNames.Observacao;
            dtgItem.Columns[colQtdeEntrada.Name].DataPropertyName = LivroRegistroMovimentosDTO.FieldNames.QtdEntrada;
            dtgItem.Columns[colQtdSaida.Name].DataPropertyName = LivroRegistroMovimentosDTO.FieldNames.QtdSaida;
            dtgItem.Columns[colQtdPerda.Name].DataPropertyName = LivroRegistroMovimentosDTO.FieldNames.QtdPerda;
            dtgItem.Columns[colQtdEstoque.Name].DataPropertyName = LivroRegistroMovimentosDTO.FieldNames.QtdEstoque;
        }

        private void CarregarGrid()
        {
            if (ValidarGeracaoPesquisa(true, true))
            {
                LivroRegistroMovimentosDTO dtoLRM = new LivroRegistroMovimentosDTO();
                dtoLRM.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                dtoLRM.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC;
                dtoLRM.IdtProduto.Value = dtoMatMed.Idt.Value;
                dtgItem.DataSource = LivroRegistroMov.Listar(dtoLRM, int.Parse(txtAno.Text), int.Parse(txtMes.Text));
            }
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
                return true;
            }
            else
            {
                MessageBox.Show("Informe o Mês/Ano", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private bool ValidarGeracaoPesquisa(bool validarProduto, bool validarMesAno)
        {
            if (cmbUnidade.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione a Unidade.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbUnidade.Focus();
                return false;
            }
            if (validarProduto)
            {
                if (dtoMatMed == null || dtoMatMed.Idt.Value.IsNull)
                {
                    MessageBox.Show("Selecione o Produto.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (validarMesAno)
            {
                if (ValidarMesAno())
                    return true;
            }

            return true;
        }

        private void FrmLivroRegistro_Load(object sender, EventArgs e)
        {
            cmbUnidade.Enabled = true;
            cmbUnidade.Carregaunidade();
            Generico.ConfiguraCombos(cmbUnidade, FrmPrincipal.dtoSeguranca);
            ConfigurarGrid();
            tsHac.Items["tsBtnMatMed"].Enabled = true;
            lblProduto.Text = matMedInicio;
        }

        private void tsbGerarDados_Click(object sender, EventArgs e)
        {
            if (ValidarGeracaoPesquisa(true, true))
            {
                if (MessageBox.Show("Deseja realmente gerar os dados de " + txtMes.Text + "/" + txtAno.Text + " ?",
                                    "Gestão de Materiais e Medicamentos",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    LivroRegistroMovimentosDTO dtoLRM = new LivroRegistroMovimentosDTO();
                    dtoLRM.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                    dtoLRM.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC;
                    dtoLRM.IdtProduto.Value = dtoMatMed.Idt.Value;
                    dtoLRM.UsuarioCriacao.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    try
                    {
                        LivroRegistroMov.GerarDados(dtoLRM, int.Parse(txtAno.Text), int.Parse(txtMes.Text), chbExcluirDadosPosteriores.Checked);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.IndexOf("DADO POSTERIOR") > -1)
                        {
                            string produto = dtoMatMed.Idt.Value.IsNull ? string.Empty : dtoMatMed.NomeFantasia.Value.ToString();
                            MessageBox.Show(string.Format("ITEM {0} JÁ TEM DADO POSTERIOR E NÃO PODE SER PROCESSADO NESTE MÊS, FAVOR ENTRAR EM CONTATO COM UM ADMINISTRADOR, OU MARCAR OPÇÃO PARA EXCLUSÃO DE DADOS POSTERIORES.", produto), 
                                            "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                            MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        this.Cursor = Cursors.Default;
                        return;
                    }

                    CarregarGrid();
                    this.Cursor = Cursors.Default;
                    //MessageBox.Show("Processo realizado com sucesso!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private bool tsHac_MatMedClick(object sender)
        {
            lblData.Text = string.Empty;
            MaterialMedicamentoDTO dtoMatMedPesquisa = new MaterialMedicamentoDTO();
            dtoMatMedPesquisa.IdtGrupo.Value = 1; //Drogas e Medicamentos
            dtoMatMedPesquisa.IdtSubGrupo.Value = 912; //Psicotropicos
            dtoMatMedPesquisa = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMedPesquisa);

            if (dtoMatMedPesquisa != null)
            {
                dtoMatMed = dtoMatMedPesquisa;
                lblProduto.Text = dtoMatMed.NomeFantasia.Value;

                DateTime? data = LivroRegistroMov.ObterUltimaDataRegistro((int)dtoMatMed.Idt.Value, int.Parse(cmbUnidade.SelectedValue.ToString()));
                if (data != null) 
                    lblData.Text = "Data Última Atualização dos Dados: " + data.Value.ToString("dd/MM/yyyy");
                else
                    lblData.Text = "Item sem dados gerados.";
            }
            return true;
        }

        private bool tsHac_LimparClick(object sender)
        {
            dtoMatMed = null;
            lblProduto.Text = matMedInicio;
            lblData.Text = string.Empty;
            return true;
        }

        private void tsHac_AfterLimpar(object sender)
        {
            tsHac.Items["tsBtnMatMed"].Enabled = true;
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            CarregarGrid();
            return true;
        }

        private bool tsHac_ImprimirClick(object sender)
        {
            if (ValidarGeracaoPesquisa(false, false))
                FrmRelLivroMov.Carregar(int.Parse(cmbUnidade.SelectedValue.ToString()), 
                                        (byte)FilialMatMedDTO.Filial.HAC, 
                                        dtoMatMed);
            return default(bool);
        }    

        private void dtgItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == dtgItem[colHistManual.Name, e.RowIndex].ColumnIndex ||
                    e.ColumnIndex == dtgItem[colObs.Name, e.RowIndex].ColumnIndex)
                {
                    this.Cursor = Cursors.WaitCursor;

                    LivroRegistroMovimentosDTO dtoLRM = new LivroRegistroMovimentosDTO();
                    
                    dtoLRM.IdtLivro.Value = dtgItem[colId.Name, e.RowIndex].Value.ToString();
                    dtoLRM.HistoricoManual.Value = dtgItem[colHistManual.Name, e.RowIndex].EditedFormattedValue.ToString().ToUpper().Trim();
                    dtoLRM.Observacao.Value = dtgItem[colObs.Name, e.RowIndex].EditedFormattedValue.ToString().ToUpper().Trim();
                    dtoLRM.UsuarioAlteracao.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                    LivroRegistroMov.AtualizarItem(dtoLRM);

                    this.Cursor = Cursors.Default;
                }
            }
        }            
    }
}