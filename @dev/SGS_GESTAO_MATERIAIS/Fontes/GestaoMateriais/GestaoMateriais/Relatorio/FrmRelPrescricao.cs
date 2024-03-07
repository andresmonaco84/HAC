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
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using Microsoft.ReportingServices.ReportRendering;
using HospitalAnaCosta.Framework;
using HacFramework.Windows.Helpers;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    public partial class FrmRelPrescricao : FrmBase
    {
        #region OBJETOS SERVIÇOS

        private const string matMedInicio = "<SELECIONE O PRODUTO CLICANDO NO BOTÃO 'Mat/Med'>";

        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }

        private IPaciente _atendimento;
        private IPaciente Atendimento
        {
            get { return _atendimento != null ? _atendimento : _atendimento = (IPaciente)Global.Common.GetObject(typeof(IPaciente)); }
        }

        private IPrescricao _prescricao;
        private IPrescricao Prescricao
        {
            get { return _prescricao != null ? _prescricao : _prescricao = (IPrescricao)Global.Common.GetObject(typeof(IPrescricao)); }
        }

        private static IDoencaDiagnostico _dodi;
        private static IDoencaDiagnostico DoencaDiagnostico
        {
            get { return _dodi != null ? _dodi : _dodi = (IDoencaDiagnostico)Global.Common.GetObject(typeof(IDoencaDiagnostico)); }
        }

        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        #endregion        

        #region Métodos

        public static void CarregarTela()
        {
            FrmRelPrescricao frm = new FrmRelPrescricao();
            frm.ShowDialog();
        }

        private void CarregaInfoPaciente()
        {
            txtNomePac.Text = string.Empty;            
            DataTable dtPaciente = Atendimento.ObterPaciente(decimal.Parse(txtNroInternacao.Text));
            if (dtPaciente.Rows.Count == 0)
            {
                MessageBox.Show("Paciente não encontrado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNroInternacao.Text = string.Empty;
                txtNroInternacao.Focus();
                return;
            }
            if (dtPaciente.Rows.Count > 0)
            {
                txtNroInternacao.Enabled = false;
                txtNomePac.Text = dtPaciente.Rows[0][1].ToString();
            }
        }

        private void CarregarComboDoencaDiagnostico(string tipo, HacComboBox cmbDoDi)
        {
            DoencaDiagnosticoDTO dtoDoDi = new DoencaDiagnosticoDTO();
            dtoDoDi.Tipo.Value = tipo;

            cmbDoDi.ValueMember = DoencaDiagnosticoDTO.FieldNames.Id;
            cmbDoDi.DisplayMember = DoencaDiagnosticoDTO.FieldNames.Descricao;
            DoencaDiagnosticoDataTable dtbDoDi = DoencaDiagnostico.Listar(dtoDoDi);

            DataRow row = dtbDoDi.NewRow();
            row[DoencaDiagnosticoDTO.FieldNames.Id] = -1;
            row[DoencaDiagnosticoDTO.FieldNames.Descricao] = "<Selecione>";
            dtbDoDi.Rows.InsertAt(row, 0);

            cmbDoDi.DataSource = dtbDoDi;            
        }

        private bool ValidarPeriodo()
        {
            if (txtInicio.Text == string.Empty)
            {
                MessageBox.Show("Digite a Data Início", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInicio.Focus();
                return false;
            }
            if (txtFim.Text == string.Empty)
            {
                MessageBox.Show("Digite a Data Fim", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFim.Focus();
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
            return true;
        }

        #endregion

        public FrmRelPrescricao()
        {
            InitializeComponent();
        }

        private void FrmRelPrescricao_Load(object sender, EventArgs e)
        {
            lblProduto.Text = matMedInicio; 
            txtInicio.Text = Utilitario.ObterDataHoraServidor().AddMonths(-3).ToString("01/MM/yyyy");
            txtFim.Text = Utilitario.ObterDataHoraServidor().ToString("dd/MM/yyyy");
            tsHac.Items["tsBtnMatMed"].Enabled = true;
            cmbProced.DataSource = Enum.GetValues(typeof(PrescricaoDTO.ProcedenciaPacienteEnum));
            cmbProced.SelectedIndex = -1;
            cmbUnidade.Carregaunidade();
            cmbUnidade.SelectedValue = 244; //SANTOS
            cmbLocal.SelectedValue = 29; //INTERNADO
            CarregarComboDoencaDiagnostico("DI", cmbDiagnostico);
            CarregarComboDoencaDiagnostico("DO", cmbDoenca);
        }        

        private void txtNroInternacao_Validating(object sender, CancelEventArgs e)
        {
            btnPesquisaPac_Click(sender, e);
        }

        private void cmbDiagnostico_SelectionChangeCommitted(object sender, EventArgs e)
        {
            rbComSemCultura.Checked = rbComCultura.Checked = rbSemCultura.Checked = false;
        }

        private void cmbDoenca_SelectionChangeCommitted(object sender, EventArgs e)
        {
            rbComSemCultura.Checked = rbComCultura.Checked = rbSemCultura.Checked = false;
        }

        private void rbDi_CheckedChanged(object sender, EventArgs e) { }        

        private void rbDo_CheckedChanged(object sender, EventArgs e) { }

        private void rbDi_Click(object sender, EventArgs e)
        {
            if (rbDi.Checked)
            {
                cmbDoenca.SelectedIndex = -1;
                cmbDoenca.Enabled = false;
                cmbDiagnostico.Enabled = true;
                rbComSemCultura.Checked = rbComCultura.Checked = rbSemCultura.Checked = false;
            }
            else
                cmbDoenca.Enabled = true;
        }

        private void rbDo_Click(object sender, EventArgs e)
        {
            if (rbDo.Checked)
            {
                cmbDiagnostico.SelectedIndex = -1;
                cmbDiagnostico.Enabled = false;
                cmbDoenca.Enabled = true;
                rbComSemCultura.Checked = rbComCultura.Checked = rbSemCultura.Checked = false;
            }
            else
                cmbDiagnostico.Enabled = true;
        }

        private void rbComSemCultura_Click(object sender, EventArgs e)
        {
            if (rbComSemCultura.Checked)
            {
                rbDo.Checked = rbDi.Checked = false;
                cmbDiagnostico.SelectedIndex = cmbDoenca.SelectedIndex = -1;
                rbDo.Enabled = rbDi.Enabled = cmbDiagnostico.Enabled = cmbDoenca.Enabled = true;
            }
        }

        private void rbComCultura_Click(object sender, EventArgs e)
        {
            if (rbComCultura.Checked)
            {
                rbDo.Checked = rbDi.Checked = false;
                cmbDiagnostico.SelectedIndex = cmbDoenca.SelectedIndex = -1;
                rbDo.Enabled = rbDi.Enabled = cmbDiagnostico.Enabled = cmbDoenca.Enabled = true;
            }
        }

        private void rbSemCultura_Click(object sender, EventArgs e)
        {
            if (rbSemCultura.Checked)
            {
                rbDo.Checked = rbDi.Checked = false;
                cmbDiagnostico.SelectedIndex = cmbDoenca.SelectedIndex = -1;
                rbDo.Enabled = rbDi.Enabled = cmbDiagnostico.Enabled = cmbDoenca.Enabled = true;
            }
        }      

        private void btnPesquisaPac_Click(object sender, EventArgs e)
        {
            txtNomePac.Text = string.Empty;
            if (txtNroInternacao.Enabled && !string.IsNullOrEmpty(txtNroInternacao.Text))
                CarregaInfoPaciente();
        }

        private void btnLimparProduto_Click(object sender, EventArgs e)
        {
            dtoMatMed = null;
            lblProduto.Text = matMedInicio;            
            btnLimparProduto.Visible = false;
            rbAutorizadosTodos.Checked = rbComSemModificacao.Checked = true;
        }

        private bool tsHac_MatMedClick(object sender)
        {
            dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(new MaterialMedicamentoDTO());
            if (dtoMatMed == null)
            {
                lblProduto.Text = matMedInicio;
                return false;
            }
            lblProduto.Text = dtoMatMed.NomeFantasia.Value;
            btnLimparProduto.Visible = true;
            return true;
        }

        private bool tsHac_LimparClick(object sender)
        {
            return true;
        }

        private void tsHac_AfterLimpar(object sender)
        {
            tsHac.Items["tsBtnMatMed"].Enabled = true;
            btnLimparProduto_Click(null, null);
            rbAutorizadosTodos.Checked = rbComSemModificacao.Checked = true;
            txtInicio.Text = Utilitario.ObterDataHoraServidor().AddMonths(-3).ToString("01/MM/yyyy");
            txtFim.Text = Utilitario.ObterDataHoraServidor().ToString("dd/MM/yyyy");
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            return default(bool);
        }

        private void btnPacSetor_Click(object sender, EventArgs e)
        {
            if (ValidarPeriodo())
            {
                this.Cursor = Cursors.WaitCursor;
                PrescricaoDTO dtoPrescricao = new PrescricaoDTO();
                decimal? idUnidade = null, idLocal = null, idSetor = null;
                int? idadeDe = null, idadeAte = null;
                char? sexo = null;

                dtoPrescricao.DataInicioConsumo.Value = txtInicio.Text;
                dtoPrescricao.DataLimiteConsumo.Value = txtFim.Text;

                if (!string.IsNullOrEmpty(txtNroInternacao.Text))
                    dtoPrescricao.IdAtendimento.Value = txtNroInternacao.Text;

                if (cmbUnidade.SelectedIndex > -1)
                    idUnidade = decimal.Parse(cmbUnidade.SelectedValue.ToString());

                if (cmbLocal.SelectedIndex > -1)
                    idLocal = decimal.Parse(cmbLocal.SelectedValue.ToString());

                if (cmbSetor.SelectedIndex > -1)
                    idSetor = decimal.Parse(cmbSetor.SelectedValue.ToString());

                if (!string.IsNullOrEmpty(txtIdadeDe.Text))
                    idadeDe = int.Parse(txtIdadeDe.Text);

                if (!string.IsNullOrEmpty(txtIdadeAte.Text))
                    idadeAte = int.Parse(txtIdadeAte.Text);

                if (rbMasculino.Checked)
                    sexo = char.Parse(rbMasculino.Text);
                else if (rbFeminino.Checked)
                    sexo = char.Parse(rbFeminino.Text);
                                
                DataTable dtb = Prescricao.ListarPacientesSetor(dtoPrescricao,
                                                                idUnidade,
                                                                idLocal,
                                                                idSetor,
                                                                idadeDe,
                                                                idadeAte,
                                                                sexo);

                if (dtb.Rows.Count > 0)
                {
                    Generico.ExportarExcel(dtb.DefaultView.ToTable(true, "PACIENTE",
                                                                         "ATENDIMENTO",
                                                                         "TIPO_PAC",
                                                                         "DT_NASCIMENTO",
                                                                         "IDADE",
                                                                         "SEXO",
                                                                         "UNIDADE",
                                                                         "SETOR",
                                                                         "DT_ENTRADA_PAC",
                                                                         "DT_SAIDA_PAC"));
                }
                else
                    MessageBox.Show("Nenhum registro encontrado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Cursor = Cursors.Default;
            }
        }

        private void btnPesquisaClinica_Click(object sender, EventArgs e)
        {
            if (ValidarPeriodo())
            {
                this.Cursor = Cursors.WaitCursor;
                bool? comCultura = null;
                PrescricaoDTO dtoPrescricao = new PrescricaoDTO();
                DoencaDiagnosticoDTO dtoDoDi = null;

                dtoPrescricao.DataInicioConsumo.Value = txtInicio.Text;
                dtoPrescricao.DataLimiteConsumo.Value = txtFim.Text;

                if (!string.IsNullOrEmpty(txtNroInternacao.Text))
                    dtoPrescricao.IdAtendimento.Value = txtNroInternacao.Text;

                if (cmbProced.SelectedValue != null && cmbProced.SelectedIndex > -1)
                    dtoPrescricao.ProcedenciaPaciente.Value = (byte)((PrescricaoDTO.ProcedenciaPacienteEnum)cmbProced.SelectedValue);                

                if (cmbDiagnostico.SelectedValue != null && cmbDiagnostico.SelectedValue.ToString() != "-1")
                    dtoPrescricao.IdDoencaDiagnostico.Value = cmbDiagnostico.SelectedValue.ToString();

                if (cmbDoenca.SelectedValue != null && cmbDoenca.SelectedValue.ToString() != "-1")
                    dtoPrescricao.IdDoencaDiagnostico.Value = cmbDoenca.SelectedValue.ToString();

                if (rbDi.Checked || rbDo.Checked)
                {
                    dtoDoDi = new DoencaDiagnosticoDTO();
                    dtoDoDi.Tipo.Value = rbDi.Checked ? "DI" : "DO";
                }

                if (rbComCultura.Checked)
                    comCultura = true;
                else if (rbSemCultura.Checked)
                    comCultura = false;

                DataTable dtb = Prescricao.ListarPacientesClinico(dtoPrescricao, dtoDoDi, comCultura);

                if (dtb.Rows.Count > 0)
                {
                    if ((rbDi.Checked || (cmbDiagnostico.SelectedValue != null && cmbDiagnostico.SelectedValue.ToString() != "-1")) ||
                        (rbDo.Checked || (cmbDoenca.SelectedValue != null && cmbDoenca.SelectedValue.ToString() != "-1")))
                    {
                        Generico.ExportarExcel(dtb.DefaultView.ToTable(true, "PACIENTE",
                                                                             "ATENDIMENTO",
                                                                             "PROCEDENCIA_PAC_DSC",
                                                                             "DESCRICAO_TIPO",
                                                                             "DESCRICAO"));
                    }                    
                    else if (comCultura != null || rbComSemCultura.Checked)
                    {
                        Generico.ExportarExcel(dtb.DefaultView.ToTable(true, "PACIENTE",
                                                                             "ATENDIMENTO",
                                                                             "PROCEDENCIA_PAC_DSC",
                                                                             "DATA_CULTURA",
                                                                             "MATERIAL",
                                                                             "MICROORGANISMO",
                                                                             "SENSIBILIDADE_MIC"));
                    }
                    else
                    {
                        Generico.ExportarExcel(dtb.DefaultView.ToTable(true, "PACIENTE",
                                                                             "ATENDIMENTO",
                                                                             "PROCEDENCIA_PAC_DSC"));
                    }
                }
                else
                    MessageBox.Show("Nenhum registro encontrado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Cursor = Cursors.Default;
            }
        }

        private void btnPesquisaMed_Click(object sender, EventArgs e)
        {
            if (ValidarPeriodo())
            {
                this.Cursor = Cursors.WaitCursor;
                PrescricaoDTO dtoPrescricao = new PrescricaoDTO();
                bool? comModificacao = null;
                int? qtdDiasDe = null, qtdDiasAte = null;

                dtoPrescricao.DataInicioConsumo.Value = txtInicio.Text;
                dtoPrescricao.DataLimiteConsumo.Value = txtFim.Text;

                if (dtoMatMed != null && !dtoMatMed.Idt.Value.IsNull)
                    dtoPrescricao.IdProduto.Value = dtoMatMed.Idt.Value.ToString();

                if (rbAutorizados.Checked)
                    dtoPrescricao.FlAutorizado.Value = 1;
                else if (rbAutorizadosNao.Checked)
                    dtoPrescricao.FlAutorizado.Value = 0;

                if (rbComModificacao.Checked)
                    comModificacao = true;
                else if (rbSemModificacao.Checked)
                    comModificacao = false;

                if (!string.IsNullOrEmpty(txtQtdDiasDe.Text))
                    qtdDiasDe = int.Parse(txtQtdDiasDe.Text);

                if (!string.IsNullOrEmpty(txtQtdDiasAte.Text))
                    qtdDiasAte = int.Parse(txtQtdDiasAte.Text);

                DataTable dtb = Prescricao.ListarMedicamentosEstatisticaAnalitico(dtoPrescricao, comModificacao, qtdDiasDe, qtdDiasAte);

                if (dtb.Rows.Count > 0)
                {
                    Generico.ExportarExcel(dtb.DefaultView.ToTable(true, "ID_MED",
                                                                         "MEDICAMENTO",
                                                                         "ID_PRESCRICAO",
                                                                         "QTD_DIAS_PRESCRITOS",
                                                                         "COM_MODIFICACAO",
                                                                         "AUTORIZADO"));
                }
                else
                    MessageBox.Show("Nenhum registro encontrado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Cursor = Cursors.Default;
            }
        }

        private void btnGerarPercAutoriza_Click(object sender, EventArgs e)
        {
            if (ValidarPeriodo())
            {
                this.Cursor = Cursors.WaitCursor;
                PrescricaoDTO dtoPrescricao = new PrescricaoDTO();

                dtoPrescricao.DataInicioConsumo.Value = txtInicio.Text;
                dtoPrescricao.DataLimiteConsumo.Value = txtFim.Text;

                DataTable dtb = Prescricao.ListarMedicamentosEstatisticaPercentual(dtoPrescricao);

                if (dtb.Rows.Count > 0)
                {
                    Generico.ExportarExcel(dtb.DefaultView.ToTable(true, "MEDICAMENTO",
                                                                         "QTD_TOTAL_REGISTROS_PERIODO",
                                                                         "PERC_QTD_SEM_INF_AUTORIZACAO",
                                                                         "PERC_QTD_AUTORIZADOS",
                                                                         "PERC_QTD_NAO_AUTORIZADOS",
                                                                         "PERC_MODIFICADOS"));
                }
                else
                    MessageBox.Show("Nenhum registro encontrado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Cursor = Cursors.Default;
            }
        }

        private void btnPesquisarFormsCompletos_Click(object sender, EventArgs e)
        {
            if (ValidarPeriodo())
            {
                this.Cursor = Cursors.WaitCursor;
                PrescricaoDTO dtoPrescricao = new PrescricaoDTO();

                dtoPrescricao.DataInicioConsumo.Value = txtInicio.Text;
                dtoPrescricao.DataLimiteConsumo.Value = txtFim.Text;

                DataTable dtb = Prescricao.ListarFormulariosCompletos(dtoPrescricao);

                if (dtb.Rows.Count > 0)
                {
                    Generico.ExportarExcel(dtb.DefaultView.ToTable(true, "PERIODO_DATA_INICIO",
                                                                         "PERIODO_DATA_FIM",
                                                                         "QTD_TOTAL_PRESCRICOES_PERIODO",
                                                                         "QTD_COMPLETAS",
                                                                         "QTD_INCOMPLETAS"));
                }
                else
                    MessageBox.Show("Nenhum registro encontrado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Cursor = Cursors.Default;
            }
        }        
    }
}