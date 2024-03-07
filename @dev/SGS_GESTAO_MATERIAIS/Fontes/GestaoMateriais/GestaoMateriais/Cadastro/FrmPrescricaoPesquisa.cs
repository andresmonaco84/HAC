using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Cadastro
{
    public partial class FrmPrescricaoPesquisa : FrmBase
    {
        #region OBJETOS SERVIÇOS

        private bool _pesquisarLoad = false;
        // MatMed
        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }

        private PrescricaoDTO dtoPrescricao;
        private IPrescricao _prescricao;
        private IPrescricao Prescricao
        {
            get { return _prescricao != null ? _prescricao : _prescricao = (IPrescricao)Global.Common.GetObject(typeof(IPrescricao)); }
        }

        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }        

        // Atendimento
        private IPaciente _atendimento;
        private IPaciente Atendimento
        {
            get { return _atendimento != null ? _atendimento : _atendimento = (IPaciente)Global.Common.GetObject(typeof(IPaciente)); }
        }

        // Utilitario
        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        #endregion

        public FrmPrescricaoPesquisa()
        {
            InitializeComponent();
        }

        private void CarregaInfoPaciente()
        {
            DataTable dtPaciente = Atendimento.ObterPaciente(decimal.Parse(txtNroInternacao.Text));
            txtNomePac.Text = string.Empty;
            if (dtPaciente.Rows.Count > 0)
            {
                txtNomePac.Text = dtPaciente.Rows[0][1].ToString();
                tsHac.Items["tsBtnPesquisar"].Enabled = true;
            }
            else
            {
                MessageBox.Show("Paciente não encontrado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNroInternacao.Text = string.Empty;
                txtNroInternacao.Focus();
            }            
        }

        public static PrescricaoDTO Pesquisar()
        {
            FrmPrescricaoPesquisa frm = new FrmPrescricaoPesquisa();
            frm.ShowDialog();
            return frm.dtoPrescricao;
        }

        public static PrescricaoDTO PesquisarPendenciasPaciente(decimal idAtendimento)
        {
            FrmPrescricaoPesquisa frm = new FrmPrescricaoPesquisa();
            
            //frm.tsHac.Items["tsBtnPesquisar"].Visible = 
            frm.tsHac.Items["tsBtnMatMed"].Visible =
            frm.btnPesquisaPac.Visible = frm.txtNroInternacao.Enabled = frm.grbStatus.Enabled = frm.cbPendenteAVencer.Enabled = false;
            //frm.txtDataLimite.Enabled = frm.txtDataIniConsumo.Enabled = false;
            
            frm.txtNroInternacao.Text = idAtendimento.ToString();
            frm.CarregaInfoPaciente();

            frm._pesquisarLoad = true;
            frm.ShowDialog();

            return frm.dtoPrescricao;
        }

        private void CarregarPeriodoPadrao(bool carregarDataLimite)
        {
            DateTime dataAtual = Utilitario.ObterDataHoraServidor();
            //txtDataIniConsumo.Text = DateTime.Parse(string.Format("{0}/{1}/{2}", dataAtual.Day, dataAtual.Month, dataAtual.Year)).AddDays(-7).ToString("dd/MM/yyyy");
            txtDataIniConsumo.Text = DateTime.Parse(string.Format("{0}/{1}/{2}", dataAtual.Day, dataAtual.Month, dataAtual.Year)).AddDays(-3).ToString("dd/MM/yyyy");
            if (carregarDataLimite) txtDataLimite.Text = DateTime.Parse(string.Format("{0}/{1}/{2}", dataAtual.Day, dataAtual.Month, dataAtual.Year)).AddDays(30).ToString("dd/MM/yyyy");
        }

        private void FrmPrescricaoPesquisa_Load(object sender, EventArgs e)
        {
            cmbUnidade.Carregaunidade();
            cmbUnidade.SelectedValue = 244; //SANTOS
            cmbLocal.SelectedValue = 29; //INTERNADO

            dtgItem.AutoGenerateColumns = false;
            dtgItem.Columns[colIdPrescInt.Name].DataPropertyName = PrescricaoDTO.FieldNames.IdPrescricaoMedica;
            dtgItem.Columns[colId.Name].DataPropertyName = PrescricaoDTO.FieldNames.IdPrescricao;
            dtgItem.Columns[colIdProduto.Name].DataPropertyName = PrescricaoDTO.FieldNames.IdProduto;
            dtgItem.Columns[colIdAtendimento.Name].DataPropertyName = PrescricaoDTO.FieldNames.IdAtendimento;
            dtgItem.Columns[colProduto.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.NomeFantasia;
            dtgItem.Columns[colDataLimite.Name].DataPropertyName = PrescricaoDTO.FieldNames.DataLimiteConsumo;
            dtgItem.Columns[colDataLimite.Name].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgItem.Columns[colQtdPendente.Name].DataPropertyName = "QTDE_PENDENTE";
            dtgItem.Columns[colQtdeDia.Name].DataPropertyName = PrescricaoDTO.FieldNames.QtdDia;
            dtgItem.Columns[colQtdeAuto.Name].DataPropertyName = PrescricaoDTO.FieldNames.QtdTotal;
            dtgItem.Columns[colQtdDisp.Name].DataPropertyName = PrescricaoDTO.FieldNames.QtdDispensada;
            dtgItem.Columns[colDataInicio.Name].DataPropertyName = PrescricaoDTO.FieldNames.DataInicioConsumo;
            dtgItem.Columns[colDataInicio.Name].DefaultCellStyle.Format = "dd/MM/yyyy";
            //dtgItem.Columns[colQtdPedidaHoje.Name].DataPropertyName = "QTD_PEDIDA_HOJE";
            dtgItem.Columns[colPaciente.Name].DataPropertyName = PacienteDTO.FieldNames.NmPaciente;
            dtgItem.Columns[colSetor.Name].DataPropertyName = SetorDTO.FieldNames.Descricao;
            dtgItem.Columns[colAutorizado.Name].DataPropertyName = "AUTORIZADO";

            CarregarPeriodoPadrao(true);

            tsHac.Items["tsBtnPesquisar"].Enabled = true;
            tsHac.Items["tsBtnMatMed"].Enabled = true;

            if (_pesquisarLoad)
            {
                dtgItem.Columns[colQtdPedidaHoje.Name].Visible = true;
                tsHac_PesquisarClick(null);
            }
        }

        private bool tsHac_CancelarClick(object sender)
        {
            dtoPrescricao = null;
            dtoMatMed = null;
            return true;
        }

        private void tsHac_AfterCancelar(object sender)
        {            
            lblProduto.Text = string.Empty;
            CarregarPeriodoPadrao(true);
            tsHac.Items["tsBtnPesquisar"].Enabled = true;
            tsHac.Items["tsBtnMatMed"].Enabled = true;
        }

        private bool tsHac_MatMedClick(object sender)
        {
            MaterialMedicamentoDTO dtoProdutoSel = null;
            if (dtoMatMed != null)
            {
                dtoProdutoSel = new MaterialMedicamentoDTO();
                dtoProdutoSel.Idt.Value = dtoMatMed.Idt.Value;
                dtoProdutoSel.NomeFantasia.Value = dtoMatMed.NomeFantasia.Value;
            }
            dtoMatMed = new MaterialMedicamentoDTO();
            dtoMatMed.IdtGrupo.Value = 1; //Drogas e Medicamentos
            dtoMatMed.IdtSubGrupo.Value = 981; //Antimicrobianos Restritos
            dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMed);
            if (dtoMatMed == null)
            {
                if (dtoProdutoSel != null) dtoMatMed = dtoProdutoSel;
                return false;
            }
            lblProduto.Text = dtoMatMed.NomeFantasia.Value;
            btnLimparProduto.Visible = true;
            return true;
        }  

        private bool tsHac_PesquisarClick(object sender)
        {
            if (txtNomePac.Text == string.Empty && txtNroInternacao.Text != string.Empty) CarregaInfoPaciente();

            #region VALIDAÇÃO DAS DATAS
            if (txtDataIniConsumo.Text != string.Empty && txtDataLimite.Text != string.Empty)
            {
                try
                {
                    if (Convert.ToDateTime(txtDataLimite.Text) < Convert.ToDateTime(txtDataIniConsumo.Text))
                    {
                        MessageBox.Show("A Data Limite Consumo deve ser maior ou igual à Data Início.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDataLimite.Focus();
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show("Data inválida.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            #endregion

            this.Cursor = Cursors.WaitCursor;
            PrescricaoDTO dtoItem = new PrescricaoDTO();

            if (txtNroInternacao.Text != string.Empty && txtNomePac.Text != string.Empty)
                dtoItem.IdAtendimento.Value = txtNroInternacao.Text;

            if (dtoMatMed != null && !dtoMatMed.Idt.Value.IsNull)
                dtoItem.IdProduto.Value = dtoMatMed.Idt.Value;

            dtoItem.Status.Value = rbAtiva.Checked ? "1" : "0";

            if (txtDataIniConsumo.Text != string.Empty)
                dtoItem.DataInicioConsumo.Value = txtDataIniConsumo.Text;

            if (txtDataLimite.Text != string.Empty)
                dtoItem.DataLimiteConsumo.Value = txtDataLimite.Text;

            if (dtoItem.IdAtendimento.Value.IsNull &&
                dtoItem.IdProduto.Value.IsNull &&
                dtoItem.DataInicioConsumo.Value.IsNull &&
                dtoItem.DataLimiteConsumo.Value.IsNull)
            {
                DateTime dataAtual = Utilitario.ObterDataHoraServidor();
                txtDataIniConsumo.Text = DateTime.Parse(string.Format("{0}/{1}/{2}", dataAtual.Day, dataAtual.Month, dataAtual.Year)).AddDays(-7).ToString("dd/MM/yyyy");
                dtoItem.DataInicioConsumo.Value = txtDataIniConsumo.Text;
            }

            if (rbAutorizado.Checked)
                dtoItem.FlAutorizado.Value = 1;
            else if (rbAutorizadoNao.Checked)
                dtoItem.FlAutorizado.Value = 0;
            else if (rbAutoPend.Checked)
                dtoItem.FlAutorizado.Value = 2;

            PacienteDTO dtoPac = null;
            if (txtNroInternacao.Text == string.Empty && !string.IsNullOrEmpty(txtNomePac.Text))
            {
                dtoPac = new PacienteDTO();
                dtoPac.NmPaciente.Value = txtNomePac.Text;
            }
            if (cmbSetor.SelectedValue != null && cmbSetor.SelectedIndex > -1)
            {
                if (dtoPac == null) dtoPac = new PacienteDTO();
                dtoPac.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            }

            PrescricaoDataTable dtbPresc = Prescricao.ListarItem(dtoItem, cbPendenteAVencer.Checked, true, dtoPac);
            RequisicaoItensDTO dtoReqItem = null;

            //if (this._pesquisarLoad) dtbPresc.Columns.Add("QTD_PEDIDA_HOJE");            

            dtgItem.DataSource = dtbPresc;

            foreach (DataGridViewRow dtgRow in dtgItem.Rows)
            {
                if (int.Parse(dtgRow.Cells[colQtdPendente.Name].Value.ToString()) == 0)
                {
                    dtgRow.Cells[colQtdPendente.Name].Style.Font = new Font(dtgItem.Font, FontStyle.Regular);
                    dtgRow.Cells[colQtdPendente.Name].Style.ForeColor = Color.Black;
                }
                else if (dtgItem.Columns[colQtdPedidaHoje.Name].Visible)
                {
                    if (dtoReqItem == null) dtoReqItem = new RequisicaoItensDTO();
                    dtoReqItem.IdtProduto.Value = dtgRow.Cells[colIdProduto.Name].Value.ToString();
                    dtoReqItem.IdPrescricao.Value = dtgRow.Cells[colId.Name].Value.ToString();
                    dtgRow.Cells[colQtdPedidaHoje.Name].Value = RequisicaoItens.ObterQtdItemPedidaHoje(dtoReqItem, 0);
                }
                if (dtgRow.Cells[colCompleto.Name].Value.ToString() == "0")
                    dtgRow.DefaultCellStyle.ForeColor = Color.Red;
                else
                    dtgRow.DefaultCellStyle.ForeColor = Color.Black;
            }

            dtgItem.ClearSelection();

            tsHac.Items["tsBtnPesquisar"].Enabled = true;
            tsHac.Items["tsBtnMatMed"].Enabled = true;
            this.Cursor = Cursors.Default;
            return default(bool);
        }

        private void txtNroInternacao_Validating(object sender, CancelEventArgs e)
        {
            if (txtNroInternacao.Text.Length != 0)
                btnPesquisaPac_Click(sender, e);
            else
                txtNomePac.Text = string.Empty;
        } 

        private void btnPesquisaPac_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNroInternacao.Text)) 
                CarregaInfoPaciente();
            else
                txtNomePac.Text = string.Empty;
        }

        private void btnLimparProduto_Click(object sender, EventArgs e)
        {
            dtoMatMed = null;
            lblProduto.Text = string.Empty;
            btnLimparProduto.Visible = false;
        }  

        private void dtgItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                dtoPrescricao = new PrescricaoDTO();
                dtoPrescricao.IdPrescricao.Value = dtgItem.SelectedRows[0].Cells[colId.Name].Value.ToString();
                dtoPrescricao.IdProduto.Value = dtgItem.SelectedRows[0].Cells[colIdProduto.Name].Value.ToString();
                if (dtgItem.Columns[colQtdPedidaHoje.Name].Visible && 
                    !string.IsNullOrEmpty(dtgItem.SelectedRows[0].Cells[colQtdPedidaHoje.Name].Value.ToString()))
                    dtoPrescricao.QtdDia.Value = int.Parse(dtgItem.SelectedRows[0].Cells[colQtdeDia.Name].Value.ToString()) - int.Parse(dtgItem.SelectedRows[0].Cells[colQtdPedidaHoje.Name].Value.ToString());
                else
                    dtoPrescricao.QtdDia.Value = dtgItem.SelectedRows[0].Cells[colQtdeDia.Name].Value.ToString();
                dtoPrescricao.QtdTotal.Value = dtgItem.SelectedRows[0].Cells[colQtdeAuto.Name].Value.ToString();
                dtoPrescricao.QtdDispensada.Value = dtgItem.SelectedRows[0].Cells[colQtdDisp.Name].Value.ToString();
                dtoPrescricao.DataInicioConsumo.Value = dtgItem.SelectedRows[0].Cells[colDataInicio.Name].Value.ToString();
                dtoPrescricao.DataLimiteConsumo.Value = dtgItem.SelectedRows[0].Cells[colDataLimite.Name].Value.ToString();

                if (dtgItem.SelectedRows[0].Cells[colCompleto.Name].Value.ToString() == "0")
                    MessageBox.Show("Prescrição com cadastro incompleto no Sistema de Internação.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Close();
            }
        }

        private void rbAutoPend_Click(object sender, EventArgs e)
        {
            if (rbAutoPend.Checked)
            {
                //DateTime dataAtual = Utilitario.ObterDataHoraServidor();
                //txtDataIniConsumo.Text = DateTime.Parse(string.Format("{0}/{1}/{2}", dataAtual.Day, dataAtual.Month, dataAtual.Year)).AddMonths(-1).ToString("01/MM/yyyy");
                CarregarPeriodoPadrao(false);
            }
        }

        private void rbTodas_Click(object sender, EventArgs e)
        {
            if (rbTodas.Checked)
                CarregarPeriodoPadrao(true);
        }         
    }
}