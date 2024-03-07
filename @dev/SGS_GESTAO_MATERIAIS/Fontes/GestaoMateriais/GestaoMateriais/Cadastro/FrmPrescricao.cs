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
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.GestaoMateriais.Relatorio;
using HospitalAnaCosta.SGS.Seguranca.View;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Interface;
using HospitalAnaCosta.SGS.Seguranca.Forms;
using HospitalAnaCosta.Framework;
using HacFramework.Windows.Helpers;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Cadastro
{
    public partial class FrmPrescricao : FrmBase
    {
        private const string matMedInicio = "<SELECIONE O PRODUTO CLICANDO NO BOTÃO 'Mat/Med'>";
        private const int _qtdPermitidaExternos = 21;
        private bool _pacienteHemodialise = false;
        private bool _pacienteEndo = false;
        private bool _usuarioSomenteLeitura = false;
        private const decimal UTI_ALMOX_SATELITE = 2092;

        #region OBJETOS SERVIÇOS
        //private int _qtdDispensada = 0;
        private bool _prescricaoInativa;
        private bool _naoAutorizado = false;
        private DateTime _dtInicioValidar;
        private DateTime _dtLimiteValidar;
        private string _ufConselhoProf;
        private int? _idMPM;        

        // MatMed
        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }

        private PrescricaoDataTable dtbPrescricao;
        private PrescricaoDTO dtoPrescricao;
        private IPrescricao _prescricao;
        private IPrescricao Prescricao
        {
            get { return _prescricao != null ? _prescricao : _prescricao = (IPrescricao)Global.Common.GetObject(typeof(IPrescricao)); }
        }

        // Atendimento        
        private string _tpPaciente;
        private IPaciente _atendimento;
        private IPaciente Atendimento
        {
            get { return _atendimento != null ? _atendimento : _atendimento = (IPaciente)Global.Common.GetObject(typeof(IPaciente)); }
        }

        private static IRequisicaoItens _requisicaoitens;
        private static IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }

        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }

        private static IDoencaDiagnostico _dodi;
        private static IDoencaDiagnostico DoencaDiagnostico
        {
            get { return _dodi != null ? _dodi : _dodi = (IDoencaDiagnostico)Global.Common.GetObject(typeof(IDoencaDiagnostico)); }
        }

        // Utilitario
        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        private CommonSeguranca _commonSeguranca;
        protected CommonSeguranca CommonSeguranca
        {
            get { return _commonSeguranca != null ? _commonSeguranca : _commonSeguranca = new CommonSeguranca(null); }
        }

        private IUsuario _usuario;
        public IUsuario Usuario
        {
            get { return _usuario != null ? _usuario : _usuario = (IUsuario)CommonSeguranca.GetObject(typeof(IUsuario)); }
        }

        #endregion

        #region Métodos

        public FrmPrescricao()
        {
            InitializeComponent();            
        }

        private bool ValidarUsuario(out SegurancaDTO dtoUsuario)
        {
            this.Cursor = Cursors.WaitCursor;
            dtoUsuario = FrmLogin.Logar(true);
            if (dtoUsuario != null)
            {
                if (!new Generico().VerificaAcessoFuncionalidade(this.Name, dtoUsuario))
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

        private void ConfigurarGrids()
        {
            dtgItem.AutoGenerateColumns = dtgAntimicroAnterior.AutoGenerateColumns = dtgInternacaoPrevia.AutoGenerateColumns = dtgCultura.AutoGenerateColumns = false;

            dtgItem.Columns[colIdMPM.Name].DataPropertyName = PrescricaoDTO.FieldNames.IdMedicamentoPrescricaoMedica;
            dtgItem.Columns[colIdProduto.Name].DataPropertyName = PrescricaoDTO.FieldNames.IdProduto;
            dtgItem.Columns[colMatMedPrincAt.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.IdtPrincipioAtivo;
            dtgItem.Columns[colProduto.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.NomeFantasia;
            dtgItem.Columns[colDataLimite.Name].DataPropertyName = PrescricaoDTO.FieldNames.DataLimiteConsumo;
            dtgItem.Columns[colDataLimite.Name].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgItem.Columns[colQtdeDia.Name].DataPropertyName = PrescricaoDTO.FieldNames.QtdDia;
            dtgItem.Columns[colQtdeAuto.Name].DataPropertyName = PrescricaoDTO.FieldNames.QtdTotal;
            dtgItem.Columns[colQtdDisp.Name].DataPropertyName = PrescricaoDTO.FieldNames.QtdDispensada;
            dtgItem.Columns[colDataInicio.Name].DataPropertyName = PrescricaoDTO.FieldNames.DataInicioConsumo;
            dtgItem.Columns[colDataInicio.Name].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgItem.Columns[colObs.Name].DataPropertyName = PrescricaoDTO.FieldNames.ObservacaoItem;
            dtgItem.Columns[colViaItem.Name].DataPropertyName = PrescricaoDTO.FieldNames.Via;
            dtgItem.Columns[colAutorizado.Name].DataPropertyName = PrescricaoDTO.FieldNames.FlAutorizado;
            dtgItem.Columns[colParecer.Name].DataPropertyName = PrescricaoDTO.FieldNames.ParecerSCIH;
            dtgItem.Columns[colDataParecer.Name].DataPropertyName = PrescricaoDTO.FieldNames.ParecerData;
            dtgItem.Columns[colIdProf.Name].DataPropertyName = PrescricaoDTO.FieldNames.IdProfissionalSCIH;

            dtgCultura.Columns[colSeq.Name].DataPropertyName = PrescricaoDTO.FieldNames.CulturaSequencial;
            dtgCultura.Columns[colData.Name].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgCultura.Columns[colData.Name].DataPropertyName = PrescricaoDTO.FieldNames.DataCultura;
            dtgCultura.Columns[colMaterial.Name].DataPropertyName = PrescricaoDTO.FieldNames.Material;
            dtgCultura.Columns[colMicroorg.Name].DataPropertyName = PrescricaoDTO.FieldNames.Microorganismo;
            dtgCultura.Columns[colSensibilidade.Name].DataPropertyName = PrescricaoDTO.FieldNames.SensibilidadeMIC;
        }

        private void CarregaInfoProfissionalSolicitante(bool validar)
        {
            txtProfSol.Text = string.Empty;
            DataTable dtbProf = Prescricao.ListarProfissionalSolicitante(txtCRM.Text.Trim(), "SP", "CRM");
            if (dtbProf.Rows.Count > 0)
            {
                txtProfSol.Text = dtbProf.Rows[0]["CAD_PSO_NM_PROFISSIONAL"].ToString();
                _ufConselhoProf = dtbProf.Rows[0]["CAD_PSO_SG_UF_CONSELHO"].ToString();
            }
            else
            {
                dtbProf = Prescricao.ListarProfissionalSolicitante(txtCRM.Text, null, "CRM");
                if (dtbProf.Rows.Count > 0)
                {
                    txtProfSol.Text = dtbProf.Rows[0]["CAD_PSO_NM_PROFISSIONAL"].ToString();
                    _ufConselhoProf = dtbProf.Rows[0]["CAD_PSO_SG_UF_CONSELHO"].ToString();
                }
            }
            if (validar && txtProfSol.Text == string.Empty)
            {
                MessageBox.Show("Profissional não encontrado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCRM.Text = string.Empty;
                txtCRM.Focus();
            }           
        }

        private void CarregaInfoProfissionalParecer(bool validar)
        {
            txtProfParecer.Text = string.Empty;
            DataTable dtbProf = Prescricao.ListarProfissionalCorpoClinico(txtCRMParecer.Text.Trim(), "SP", "CRM", null);
            if (dtbProf.Rows.Count > 0)
            {
                txtProfParecer.Text = dtbProf.Rows[0]["CAD_PRO_NM_NOME"].ToString();
                dtoPrescricao.IdProfissionalSCIH.Value = dtbProf.Rows[0]["CAD_PRO_ID_PROFISSIONAL"].ToString();
            }
            else
            {
                dtbProf = Prescricao.ListarProfissionalCorpoClinico(txtCRMParecer.Text, null, "CRM", null);
                if (dtbProf.Rows.Count > 0)
                {
                    txtProfParecer.Text = dtbProf.Rows[0]["CAD_PRO_NM_NOME"].ToString();
                    dtoPrescricao.IdProfissionalSCIH.Value = dtbProf.Rows[0]["CAD_PRO_ID_PROFISSIONAL"].ToString();
                }
            }
            if (validar && txtProfParecer.Text == string.Empty)
            {
                MessageBox.Show("Profissional não encontrado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCRMParecer.Text = string.Empty;
                txtCRMParecer.Focus();
            }
        }

        private void CarregaInfoPaciente(bool validar)
        {
            txtNomePac.Text = string.Empty;
            btnMais.Visible = btnMenos.Visible = false;
            DataTable dtPaciente = Atendimento.ObterPaciente(decimal.Parse(txtNroInternacao.Text));
            if (dtPaciente.Rows.Count == 0)
            {
                MessageBox.Show("Paciente não encontrado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNroInternacao.Text = string.Empty;
                txtNroInternacao.Focus();
                return;
            }
            _pacienteHemodialise = dtPaciente.Rows[0][PacienteDTO.FieldNames.IdtSetor].ToString() == "114" ? true : false;
            _pacienteEndo = dtPaciente.Rows[0][PacienteDTO.FieldNames.IdtSetor].ToString() == "87" ? true : false;
            if (dtPaciente.Rows.Count > 0)
            {
                _tpPaciente = dtPaciente.Rows[0]["TP_PACIENTE"].ToString();
                if (validar)
                {
                    //if (dtPaciente.Rows[0]["TP_PACIENTE"].ToString() != "I")
                    //{
                    //    MessageBox.Show("Paciente inválido", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    txtNroInternacao.Text = string.Empty;
                    //    txtNroInternacao.Focus();
                    //    return;
                    //}
                    if (_tpPaciente == "I" &&
                        !string.IsNullOrEmpty(dtPaciente.Rows[0]["DT_ALTA"].ToString()))
                    {
                        MessageBox.Show("Este paciente já teve alta.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNroInternacao.Text = string.Empty;
                        txtNroInternacao.Focus();
                        return;
                    }
                    else if (_tpPaciente != "I" &&
                             !string.IsNullOrEmpty(dtPaciente.Rows[0]["DT_INT"].ToString()) && !string.IsNullOrEmpty(dtPaciente.Rows[0]["HR_TRANSF"].ToString()))
                    {
                        string strDtAtd = dtPaciente.Rows[0]["DT_INT"].ToString().Replace("00:00:00", dtPaciente.Rows[0]["HR_TRANSF"].ToString().PadLeft(4, '0').Insert(2, ":"));
                        DateTime dtAtd = DateTime.Parse(strDtAtd);
                        if ((!_pacienteHemodialise && !_pacienteEndo) && Utilitario.ObterDataHoraServidor() > dtAtd.AddHours(24))
                        {
                            MessageBox.Show("Este paciente tem a data de atendimento registrada há mais de 24 horas.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNroInternacao.Text = string.Empty;
                            txtNroInternacao.Focus();
                            return;
                        }
                        else if ((_pacienteHemodialise || _pacienteEndo) &&
                                 Utilitario.ObterDataHoraServidor() > dtAtd.AddDays(60)) //Liberar 60 dias para Hemodialise e ENDO conforme regra da query de consumo de externos
                        {
                            MessageBox.Show("Este paciente tem a data de atendimento registrada há mais de 60 dias.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNroInternacao.Text = string.Empty;
                            txtNroInternacao.Focus();
                            return;
                        }
                        else if (!_pacienteHemodialise && !_pacienteEndo) //Liberar qtd. para Hemodialise e ENDOSCOPIA
                        {                            
                            RotinaPacienteNaoInternado();
                            MessageBox.Show("Este paciente não é internado é só poderá consumir no máximo " + _qtdPermitidaExternos + " em quantidade.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtObs.Focus();
                        }
                    }
                }
                else if (_tpPaciente != "I" && !_pacienteHemodialise && !_pacienteEndo) //Liberar qtd. para Hemodialise e ENDOSCOPIA
                {
                    RotinaPacienteNaoInternado();
                }
                txtNomePac.Text = dtPaciente.Rows[0][1].ToString();
            }               

            txtNroInternacao.Enabled = true;
            if (txtNomePac.Text != string.Empty)
            {
                _naoPesquisarPaciente = true;
                txtNroInternacao.Enabled = false;
                _naoPesquisarPaciente = false;
            }
        }

        private void RotinaPacienteNaoInternado()
        {
            txtDataIniConsumo.Text = Utilitario.ObterDataHoraServidor().ToString("dd/MM/yyyy");
            txtDataLimite.Text = Utilitario.ObterDataHoraServidor().AddDays(1).ToString("dd/MM/yyyy");
            txtQtdTotalAuto.Text = txtQtdDia.Text = "1";
            btnMais.Text = "+";
            btnMais.Visible = btnMenos.Visible = btnMais.Enabled = btnMenos.Enabled = cmbVia.Enabled = true;
            txtDataIniConsumo.Enabled = txtDataLimite.Enabled = txtQtdTotalAuto.Enabled = txtQtdDia.Enabled = false;            
        }

        private bool _carregandoPrescricao = false;
        private void CarregarPrescricao()
        {
            lblPrescInt.Visible = lblPrescIntCod.Visible = false;
            lblInclusao.Text = lblAlteracao.Text = string.Empty;
            if (txtCod.Text != string.Empty)
            {
                _prescricaoInativa = false;
                this.Cursor = Cursors.WaitCursor;
                dtoPrescricao = new PrescricaoDTO();
                dtoPrescricao.IdPrescricao.Value = txtCod.Text;
                dtbPrescricao = Prescricao.ListarItem(dtoPrescricao, false);
                if (dtbPrescricao.Rows.Count > 0)
                {
                    dtoPrescricao = dtbPrescricao.TypedRow(0);
                    txtNroInternacao.Text = dtoPrescricao.IdAtendimento.Value;
                    CarregaInfoPaciente(false);

                    _carregandoPrescricao = true;
                    txtCRM.Text = dtoPrescricao.CRM.Value;
                    CarregaInfoProfissionalSolicitante(false);
                    _carregandoPrescricao = false;                    
                    
                    lblInclusao.Text = "Dta. Inclusão: " + DateTime.Parse(dtoPrescricao.DataInclusao.Value.ToString()).ToString("dd/MM/yyyy hh:mm");
                    if (!dtoPrescricao.DataAlteracao.Value.IsNull)
                        lblAlteracao.Text = "Dta. Alteração: " + DateTime.Parse(dtoPrescricao.DataAlteracao.Value.ToString()).ToString("dd/MM/yyyy hh:mm");
                    //else
                    //    lblAlteracao.Text = string.Empty; //"Dta. Alteração: " + DateTime.Parse(dtoPrescricao.DataInclusao.Value.ToString()).ToString("dd/MM/yyyy hh:mm");
                    cbStatus.Checked = dtoPrescricao.Status.Value == 1 ? true : false;
                    _prescricaoInativa = !cbStatus.Checked;
                    if (!dtoPrescricao.ProcedenciaPaciente.Value.IsNull)
                        cmbProced.SelectedItem = (PrescricaoDTO.ProcedenciaPacienteEnum)byte.Parse(dtoPrescricao.ProcedenciaPaciente.Value.ToString());
                    else
                        cmbProced.IniciaLista();
                    txtPeso.Text = dtoPrescricao.Peso.Value;
                    txtCreatinina.Text = dtoPrescricao.Creatinina.Value;
                    btnSalvar.Visible = cbStatus.Enabled = btnSalvar.Enabled = txtCRM.Enabled = cmbProced.Enabled = txtPeso.Enabled = txtCreatinina.Enabled = true;                    
                    btnNovo_Click(null, null);
                    CarregarItens();

                    if (!dtoPrescricao.IdPrescricaoMedica.Value.IsNull)
                    {
                        lblPrescIntCod.Text = dtoPrescricao.IdPrescricaoMedica.Value;
                        lblPrescInt.Visible = lblPrescIntCod.Visible = true;
                        btnSalvar.Visible = cbStatus.Enabled = btnSalvar.Enabled = txtCRM.Enabled = cmbProced.Enabled = txtPeso.Enabled = txtCreatinina.Enabled = false;
                        btnNovo.Enabled = btnExcluirItem.Enabled = false;
                        btnAddDoenca.Enabled = btnAddDiagnostico.Enabled = false;
                    }
                    else
                    {
                        btnNovo.Enabled = btnExcluirItem.Enabled = true;
                        btnAddDoenca.Enabled = btnAddDiagnostico.Enabled = true;
                    }

                    txtCod.Enabled = false;
                    cmbProced.Focus();
                    if (_usuarioSomenteLeitura)
                        btnAddItem.Enabled = btnSalvar.Visible = false;
                }
                else
                {
                    MessageBox.Show("Prescrição não encontrada", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCod.Text = string.Empty;
                    txtCod.Focus();
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void CarregarItens()
        {
            if (dtbPrescricao != null)
            {
                this.Cursor = Cursors.WaitCursor;
                dtgItem.DataSource = dtbPrescricao;
                dtgItem.ClearSelection();
                this.Cursor = Cursors.Default;
            }
        }

        private bool SalvarPrescricao()
        {
            //if (_prescricaoInativa && cbStatus.Checked && !string.IsNullOrEmpty(txtCod.Text))
            //{
            //    MessageBox.Show("Prescrição não pode ser reativada", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            if ((dtoPrescricao == null || dtoPrescricao.IdPrescricao.Value.IsNull) && !cbStatus.Checked)
            {
                MessageBox.Show("Não pode ser incluída prescrição inativa", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            this.Cursor = Cursors.WaitCursor;
            
            if (dtoPrescricao == null || dtoPrescricao.IdPrescricao.Value.IsNull) dtoPrescricao = new PrescricaoDTO();
            dtoPrescricao.IdAtendimento.Value = txtNroInternacao.Text;
            dtoPrescricao.Status.Value = cbStatus.Checked ? 1 : 0;
            dtoPrescricao.CRM.Value = txtCRM.Text;
            if (_ufConselhoProf != null)
                dtoPrescricao.UFConselhoProfissional.Value = _ufConselhoProf;
            if (cmbProced.SelectedValue != null) dtoPrescricao.ProcedenciaPaciente.Value = (byte)((PrescricaoDTO.ProcedenciaPacienteEnum)cmbProced.SelectedValue);
            dtoPrescricao.Peso.Value = txtPeso.Text;
            dtoPrescricao.Creatinina.Value = txtCreatinina.Text;

            if (!lblPrescIntCod.Visible && !_prescricaoInativa && !cbStatus.Checked)
            {
                //Se prescrição for inativada e houverem pedidos vinculados a algum item, zerar qtd. solicitada nos pedidos respectivos ao item. Não poderá ser inativada prescrição caso já tenha algum pedido enviado à ala.
                PrescricaoDTO dto = new PrescricaoDTO();
                dto.IdPrescricao.Value = txtCod.Text; //Atualizar DataTable
                dtbPrescricao = Prescricao.ListarItem(dto, false);

                foreach (DataRow row in dtbPrescricao.Rows)
                {
                    if (!string.IsNullOrEmpty(row[PrescricaoDTO.FieldNames.IdProduto].ToString()))
                    {
                        if (!ValidarInativacaoItem(decimal.Parse(row[PrescricaoDTO.FieldNames.IdProduto].ToString()), true, false))
                        {
                            this.Cursor = Cursors.Default;
                            return false;
                        }
                    }
                }
                foreach (DataRow row in dtbPrescricao.Rows)
                {
                    if (!string.IsNullOrEmpty(row[PrescricaoDTO.FieldNames.IdProduto].ToString()))
                        ValidarInativacaoItem(decimal.Parse(row[PrescricaoDTO.FieldNames.IdProduto].ToString()), false, true);
                }
            }
            dtoPrescricao.IdUsuarioAlteracao.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
            dtoPrescricao = Prescricao.Gravar(dtoPrescricao);

            txtCod.Text = dtoPrescricao.IdPrescricao.Value;
            txtCod.Enabled = false;
            _prescricaoInativa = !cbStatus.Checked;            
            
            this.Cursor = Cursors.Default;
            return true;
        }

        private bool AdicionarItem(bool zerarItem)
        {
            SegurancaDTO dtoUsuario;
            if (!ValidarUsuario(out dtoUsuario)) return false;

            if (string.IsNullOrEmpty(txtCod.Text) && !txtCod.Enabled &&
                (dtoPrescricao == null || dtoPrescricao.IdPrescricao.Value.IsNull))
            {
                if (!this.ValidarPrescricao()) return false;
                _novaPrescricaoSalva = this.SalvarPrescricao();
                if (!_novaPrescricaoSalva) return false;
            }
            
            if (txtCod.Text != string.Empty && dtoPrescricao != null && !dtoPrescricao.IdPrescricao.Value.IsNull)
            {
                this.Cursor = Cursors.WaitCursor;
                PrescricaoDTO dtoItem = new PrescricaoDTO();
                dtoItem.IdPrescricao.Value = dtoPrescricao.IdPrescricao.Value;
                dtoItem.IdProduto.Value = dtoMatMed.Idt.Value;
                dtoItem.DataInicioConsumo.Value = txtDataIniConsumo.Text;
                dtoItem.DataLimiteConsumo.Value = txtDataLimite.Text;
                dtoItem.QtdTotal.Value = zerarItem ? "0" : txtQtdTotalAuto.Text;
                dtoItem.QtdDia.Value = zerarItem ? "0" : txtQtdDia.Text;
                //dtoItem.QtdDispensada.Value = _qtdDispensada.ToString();
                dtoItem.ObservacaoItem.Value = txtObs.Text;
                if (cmbVia.SelectedValue != null && cmbVia.SelectedValue.ToString() != "-1") dtoItem.Via.Value = cmbVia.SelectedValue.ToString();

                dtoItem.FlAutorizado.Value = dtoPrescricao.FlAutorizado.Value;
                //if (dtoItem.FlAutorizado.Value.IsNull) dtoItem.FlAutorizado.Value = 0;
                dtoItem.IdProfissionalSCIH.Value = dtoPrescricao.IdProfissionalSCIH.Value;
                dtoItem.ParecerData.Value = dtoPrescricao.ParecerData.Value;
                dtoItem.ParecerSCIH.Value = dtoPrescricao.ParecerSCIH.Value;
                if (lblPrescIntCod.Visible)
                {
                    dtoItem.IdPrescricaoMedica.Value = lblPrescIntCod.Text;
                    if (_idMPM != null)
                        dtoItem.IdMedicamentoPrescricaoMedica.Value = _idMPM.Value;

                    if (!dtoItem.DataLimiteConsumo.Value.IsNull)
                    {
                        if ((DateTime)dtoItem.DataLimiteConsumo.Value < _dtLimiteValidar.Date &&
                            (DateTime)dtoItem.DataLimiteConsumo.Value >= Utilitario.ObterDataHoraServidor().Date) //Se trocou Data Limite de Consumo, cancela programação após a data se houver
                            this.CancelarProgramacaoItemPrescricao((DateTime)dtoItem.DataLimiteConsumo.Value);
                    }
                }

                dtoItem.IdUsuarioAlteracao.Value = dtoUsuario.Idt.Value;
                dtoItem.IdAtendimento.Value = dtoPrescricao.IdAtendimento.Value;
                dtoItem.CRM.Value = txtCRM.Text;
                Prescricao.GravarItem(dtoItem, true);                
       
                this.Cursor = Cursors.Default;
                return true;
            }
            else
                MessageBox.Show("Prescrição não selecionada", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return false;
        }

        private bool ValidarInativacaoItem(decimal idProduto, bool validarDispensado, bool zerarItens)
        {
            //Se item for inativado e houverem pedidos vinculados a ele, zerar qtd. solicitada nos pedidos respectivos ao item. Não poderá ser inativado item caso já tenha algum pedido enviado à ala.
            
            if (validarDispensado)
            {
                PrescricaoDTO dto = new PrescricaoDTO();
                dto.IdPrescricao.Value = txtCod.Text;
                dto.IdProduto.Value = idProduto;
                PrescricaoDataTable dtb  = Prescricao.ListarItem(dto, false);
                if (dtb.Rows.Count > 0 && dtb.TypedRow(0).QtdDispensada.Value > 0)
                {
                    MessageBox.Show("Exclusão ou inativação não permitida, item ID " + idProduto.ToString() + " já dispensado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                #region COMENTADO NAO BUSCA MAIS NA FONTE
                //AO INVES DE BUSCAR QTD. DISP. DO GRID, VAI NOVAMENTE NA FONTE, POIS ENQUANTO A TELA ESTÁ ABERTA PODE TER SIDO ATUALIZADA                
                //foreach (DataRow row in dtbRequisicaoItem.Rows)
                //{
                //    if (decimal.Parse(row[RequisicaoItensDTO.FieldNames.IdtProduto].ToString()) == idProduto ||
                //        (idPrincipioAtivo != 0 && decimal.Parse(row[RequisicaoItensDTO.FieldNames.IdtPrincipioAtivo].ToString()) == idPrincipioAtivo))
                //    {
                //        if (row[RequisicaoDTO.FieldNames.Status].ToString() == ((byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX).ToString() ||
                //            row[RequisicaoDTO.FieldNames.Status].ToString() == ((byte)RequisicaoDTO.StatusRequisicao.RECEBIDA_UNIDADE).ToString())
                //        {
                //            if (int.Parse(row[RequisicaoItensDTO.FieldNames.QtdFornecida].ToString()) > 0)
                //            {
                //                MessageBox.Show("Exclusão ou inativação não permitida, item ID " + dtoRequisicaoItem.IdtProduto.Value + " já dispensado do almoxarifado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //                return false;
                //            }
                //        }
                //        else if (int.Parse(row[RequisicaoItensDTO.FieldNames.QtdFornecida].ToString()) > 0)
                //        {
                //            MessageBox.Show("Exclusão ou inativação não permitida, item ID " + dtoRequisicaoItem.IdtProduto.Value + " está sendo dispensado do almoxarifado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //            return false;
                //        }
                //    }
                //}
                //Validar Consumo UTIs
                //int qtdConsumoInt = 0;
                //MovimentacaoDTO dtoMov = new MovimentacaoDTO();k
                //dtoMov.IdtSetor.Value = 200; //UTI_CARDIO
                //dtoMov.IdtAtendimento.Value = txtNroInternacao.Text;
                //dtoMov.IdtProduto.Value = idProduto.ToString();
                //DataTable dtbMov = Movimento.ObterQtdProdutoBaixaPacSetor(dtoMov, idPrincipioAtivo);
                ////Pode retornar até 2 linhas, caso produto com movimento fracionado
                //if (dtbMov.Rows.Count > 0)
                //{
                //    if (dtbMov.Rows[0]["MOV_TIPO"].ToString() == "I") qtdConsumoInt = int.Parse(dtbMov.Rows[0]["QTD_CONSUMO"].ToString());
                //    if (dtbMov.Rows.Count > 1)
                //        if (dtbMov.Rows[1]["MOV_TIPO"].ToString() == "I") qtdConsumoInt = int.Parse(dtbMov.Rows[0]["QTD_CONSUMO"].ToString());
                //}
                //dtoMov.IdtSetor.Value = 201; //UTI_GERAL
                //dtbMov = Movimento.ObterQtdProdutoBaixaPacSetor(dtoMov, idPrincipioAtivo);
                //if (dtbMov.Rows.Count > 0)
                //{
                //    if (dtbMov.Rows[0]["MOV_TIPO"].ToString() == "I") qtdConsumoInt += int.Parse(dtbMov.Rows[0]["QTD_CONSUMO"].ToString());
                //    if (dtbMov.Rows.Count > 1)
                //        if (dtbMov.Rows[1]["MOV_TIPO"].ToString() == "I") qtdConsumoInt += int.Parse(dtbMov.Rows[0]["QTD_CONSUMO"].ToString());
                //}
                //if (qtdConsumoInt > 0)
                //{
                //    MessageBox.Show("Exclusão ou inativação não permitida, item ID " + idProduto.ToString() + " já dispensado do almoxarifado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}            
                #endregion                   
            }
            
            if (zerarItens)
            {
                RequisicaoItensDTO dtoRequisicaoItem = new RequisicaoItensDTO();
                dtoRequisicaoItem.IdPrescricao.Value = dtoPrescricao.IdPrescricao.Value;
                //dtoRequisicaoItem.IdtProduto.Value = idProduto.ToString();
                RequisicaoItensDataTable dtbRequisicaoItem = RequisicaoItens.Sel(dtoRequisicaoItem);
                MaterialMedicamentoDTO dtoProd = new MaterialMedicamentoDTO();
                dtoProd.Idt.Value = idProduto.ToString();
                int idPrincipioAtivo = (int)MatMed.SelChave(dtoProd).IdtPrincipioAtivo.Value;
                foreach (DataRow row in dtbRequisicaoItem.Rows)
                {
                    if (decimal.Parse(row[RequisicaoItensDTO.FieldNames.IdtProduto].ToString()) == idProduto ||
                        (idPrincipioAtivo != 0 && decimal.Parse(row[RequisicaoItensDTO.FieldNames.IdtPrincipioAtivo].ToString()) == idPrincipioAtivo))
                    {
                        dtoRequisicaoItem = new RequisicaoItensDTO();
                        dtoRequisicaoItem.Idt.Value = row[RequisicaoItensDTO.FieldNames.Idt].ToString();
                        dtoRequisicaoItem.IdtProduto.Value = row[RequisicaoItensDTO.FieldNames.IdtProduto].ToString();
                        dtoRequisicaoItem.QtdSolicitada.Value = 0;
                        dtoRequisicaoItem.QtdFornecida.Value = 0;
                        RequisicaoItens.Upd(dtoRequisicaoItem);
                    }
                }
            }

            return true;
        }

        private bool ValidarAlteracao()
        {            
            if (dtoPrescricao != null && !dtoPrescricao.DataInclusao.Value.IsNull && lblInclusao.Text != string.Empty)
            {
                if (Convert.ToDateTime(dtoPrescricao.DataInclusao.Value.ToString()) < Utilitario.ObterDataHoraServidor().AddMonths(-2))
                {
                    MessageBox.Show("Alteração inválida. Prescrição incluída há mais de 2 meses.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private bool ValidarPrescricao()
        {
            if (txtNroInternacao.Text == string.Empty || txtNomePac.Text == string.Empty)
            {
                MessageBox.Show("Atendimento é obrigatório", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNroInternacao.Enabled = true;
                txtNroInternacao.Focus();
                return false;
            }
            if (txtCRM.Text == string.Empty)
            {
                MessageBox.Show("CRM é obrigatório", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCRM.Focus();
                return false;
            }
            return true;
        }

        private bool ValidarItem()
        {
            if (!this.ValidarAlteracao()) return false;
            if (_prescricaoInativa)
            {
                MessageBox.Show("Prescrição inativa", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }            
            if (dtoMatMed == null)
            {
                MessageBox.Show("Selecione o item", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            #region VALIDAÇÃO DAS DATAS

            if (txtDataIniConsumo.Text == string.Empty)
            {
                MessageBox.Show("Digite a Data Início Consumo", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDataIniConsumo.Focus();
                return false;
            }
            if (txtDataLimite.Text == string.Empty)
            {
                MessageBox.Show("Digite a Data Limite Consumo", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDataLimite.Focus();
                return false;
            }
            try
            {
                if (Convert.ToDateTime(txtDataLimite.Text) < Convert.ToDateTime(txtDataIniConsumo.Text))
                {
                    MessageBox.Show("A Data Limite Consumo deve ser maior ou igual à Data Início.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDataLimite.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Data inválida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Convert.ToDateTime(txtDataLimite.Text).Date > Utilitario.ObterDataHoraServidor().Date.AddMonths(3))
            {
                MessageBox.Show("A Data Limite Consumo não pode ser superior a 3 meses.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDataLimite.Focus();
                return false;
            }
            #endregion

            #region VALIDAÇÃO DAS QTDES

            if (txtQtdTotalAuto.Text == string.Empty || int.Parse(txtQtdTotalAuto.Text) <= 0)
            {
                MessageBox.Show("Digite a Qtde. Total Autorizada", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQtdTotalAuto.Focus();
                return false;
            }
            if (txtQtdDia.Text == string.Empty || int.Parse(txtQtdDia.Text) <= 0)
            {
                MessageBox.Show("Digite a Qtde. Diária Autorizada", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQtdDia.Focus();
                return false;
            }
            if (int.Parse(txtQtdDia.Text) > int.Parse(txtQtdTotalAuto.Text))
            {
                MessageBox.Show("Qtde. Diária não pode ser maior que a Qtd. Total Autorizada", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQtdDia.Focus();
                return false;
            }
            #endregion

            this.Cursor = Cursors.WaitCursor;

            foreach (DataGridViewRow dtgRow in dtgItem.Rows)
            {
               if (!string.IsNullOrEmpty(dtgRow.Cells[colMatMedPrincAt.Name].Value.ToString()) && decimal.Parse(dtgRow.Cells[colMatMedPrincAt.Name].Value.ToString()) != 0 &&
                   (!dtoMatMed.IdtPrincipioAtivo.Value.IsNull && dtoMatMed.IdtPrincipioAtivo.Value.ToString() != "0"))
                {
                    if ((dtgRow.Cells[colMatMedPrincAt.Name].Value.ToString() == dtoMatMed.IdtPrincipioAtivo.Value.ToString()) &&
                        (dtgRow.Cells[colIdProduto.Name].Value.ToString() != dtoMatMed.Idt.Value.ToString()))
                    {
                        MessageBox.Show(string.Format("Gravação não efetuada, pois a prescrição já tem o {0}, item similar a este.", dtgRow.Cells[colProduto.Name].Value.ToString()),
                                        "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Cursor = Cursors.Default;
                        return false;
                    }
                }
            }

            PrescricaoDTO dtoItem = new PrescricaoDTO();
            dtoItem.IdAtendimento.Value = txtNroInternacao.Text;
            dtoItem.IdProduto.Value = dtoMatMed.Idt.Value;
            PrescricaoDataTable dtbPresc = Prescricao.ListarItem(dtoItem, true);
            DateTime dtIni, dtFim;
            foreach (DataRow row in dtbPresc.Rows)
            {
                if (row[PrescricaoDTO.Captions.IdPrescricao].ToString() != txtCod.Text)
                {
                    dtIni = DateTime.Parse(row[PrescricaoDTO.Captions.DataInicioConsumo].ToString()).Date;
                    dtFim = DateTime.Parse(row[PrescricaoDTO.Captions.DataLimiteConsumo].ToString()).Date;

                    if ((DateTime.Parse(txtDataIniConsumo.Text).Date >= dtIni && DateTime.Parse(txtDataIniConsumo.Text).Date <= dtFim) ||
                        (DateTime.Parse(txtDataLimite.Text).Date >= dtIni && DateTime.Parse(txtDataLimite.Text).Date <= dtFim))
                    {
                        MessageBox.Show("Já existe outra prescrição pendente deste medicamento neste período para este paciente", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Cursor = Cursors.Default;
                        return false;
                    }
                }
            }

            if (dtoPrescricao != null && !dtoPrescricao.IdPrescricao.Value.IsNull)
            {
                //Caso item alterado da prescrição já tenha algum pedido vinculado, não permitir alteração para Qtd. Total Autorizada a menor do que já foi pedido, caso contrário, será necessário excluir item p/ adicionar novamente.
                int qtdTotalSolicitada = 0;
                RequisicaoItensDTO dtoRequisicaoItem = new RequisicaoItensDTO();
                dtoRequisicaoItem.IdPrescricao.Value = dtoPrescricao.IdPrescricao.Value;
                dtoRequisicaoItem.IdtProduto.Value = dtoMatMed.Idt.Value;
                RequisicaoItensDataTable dtbRequisicaoItem = RequisicaoItens.Sel(dtoRequisicaoItem);
                foreach (DataRow row in dtbRequisicaoItem.Rows)
                {
                    if (row[RequisicaoDTO.FieldNames.Status].ToString() != ((byte)RequisicaoDTO.StatusRequisicao.CANCELADA).ToString() &&
                        row[RequisicaoDTO.FieldNames.Status].ToString() != ((byte)RequisicaoDTO.StatusRequisicao.CANCELADA_POR_ALTA).ToString())
                        qtdTotalSolicitada += int.Parse(row[RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString());
                }

                #region VALIDAÇÕES CASO HAJA PEDIDO (QTDE E DATAS)

                if (int.Parse(txtQtdTotalAuto.Text) < qtdTotalSolicitada)
                {
                    MessageBox.Show("Qtd. Total Autorizada não pode ser menor que " + qtdTotalSolicitada.ToString() + " (Qtd. já solicitada ao paciente). Neste caso o item terá que ser excluído para a inclusão de outro.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Cursor = Cursors.Default;
                    return false;
                }
                if (Convert.ToDateTime(txtDataIniConsumo.Text) != _dtInicioValidar && qtdTotalSolicitada > 0)
                {
                    //MessageBox.Show("Data Início deve ser menor ou igual à " + _dtInicioValidar.ToString("dd/MM/yyyy") + ".", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show("Data Início não pode ser alterada, pois já há itens solicitados.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Cursor = Cursors.Default;
                    return false;
                }
                else if (Convert.ToDateTime(txtDataIniConsumo.Text) < _dtInicioValidar && Convert.ToDateTime(txtDataIniConsumo.Text) < Utilitario.ObterDataHoraServidor().Date && qtdTotalSolicitada == 0)
                {
                    MessageBox.Show("Data Início deve ser maior ou igual à " + _dtInicioValidar.ToString("dd/MM/yyyy") + ".", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Cursor = Cursors.Default;
                    return false;
                }
                //if (Convert.ToDateTime(txtDataLimite.Text) < _dtLimiteValidar && qtdTotalSolicitada > 0)
                //{
                //    MessageBox.Show("Data Limite deve ser maior ou igual à " + _dtLimiteValidar.ToString("dd/MM/yyyy") + ".", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    this.Cursor = Cursors.Default;
                //    return false;
                //}
                if (Convert.ToDateTime(txtDataLimite.Text) < Utilitario.ObterDataHoraServidor().Date && qtdTotalSolicitada > 0) // && qtdTotalSolicitada == 0)
                {
                    MessageBox.Show("Data Limite deve ser maior ou igual à " + Utilitario.ObterDataHoraServidor().ToString("dd/MM/yyyy") + ".", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Cursor = Cursors.Default;
                    return false;
                }
                #endregion
            }            

            this.Cursor = Cursors.Default;
            return true;
        }

        private void RotinaNovoItem()
        {
            dtoMatMed = null;
            _idMPM = null;
            _naoAutorizado = false;
            lblIntervalo.Text = lblDoseAdm.Text = "-";
            txtDataIniConsumo.Enabled = txtDataLimite.Enabled = txtQtdDia.Enabled = txtQtdTotalAuto.Enabled = txtObs.Enabled = cmbVia.Enabled = true;
            txtDataLimite.Text = txtQtdDia.Text = txtQtdTotalAuto.Text = txtObs.Text = string.Empty;
            lblProduto.Text = matMedInicio;
            if (cmbVia.Items.Count > 0)
                cmbVia.SelectedIndex = 0;

            DateTime dataAtual = Utilitario.ObterDataHoraServidor();
            txtDataIniConsumo.Text = DateTime.Parse(string.Format("{0}/{1}/{2}", dataAtual.Day, dataAtual.Month, dataAtual.Year)).ToString("dd/MM/yyyy");

            _dtLimiteValidar = _dtInicioValidar = dataAtual.Date;

            if (tsHac.Items["tsBtnMatMed"] != null) tsHac.Items["tsBtnMatMed"].Enabled = true;
            btnMais.Visible = btnMenos.Visible = btnExcluirItem.Enabled = false;
            dtgItem.ClearSelection();

            if (!string.IsNullOrEmpty(_tpPaciente) && _tpPaciente != "I" && !_pacienteHemodialise && !_pacienteEndo) RotinaPacienteNaoInternado();
        }

        private void CarregarVia()
        {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Selecione>"));

            list.Add(new ListItem("EV", "Endovenosa"));
            list.Add(new ListItem("VO", "Via Oral"));

            if (lblPrescIntCod.Visible)
            {
                list.Add(new ListItem("20", "IV - INTRAVENOSA"));
                list.Add(new ListItem("13", "IM - INTRAMUSCULAR"));
                list.Add(new ListItem("25", "VO - ORAL"));
                list.Add(new ListItem("01", "BUCAL"));
                list.Add(new ListItem("02", "CAPILAR"));
                list.Add(new ListItem("03", "DERMATOLOGICA"));
                list.Add(new ListItem("90", "HIPODERMÓCLISE"));
                list.Add(new ListItem("04", "EPIDURAL"));
                list.Add(new ListItem("05", "GTT - GASTROSTOMIA / JEJUNOSTOMIA"));
                list.Add(new ListItem("06", "INALATORIA"));
                list.Add(new ListItem("07", "INTRA-OSSEA"));
                list.Add(new ListItem("08", "INTRA-ARTERIAL"));
                list.Add(new ListItem("09", "INTRA-ARTICULAR"));
                list.Add(new ListItem("10", "INTRACARDIACA"));
                list.Add(new ListItem("11", "INTRADERMICA"));
                list.Add(new ListItem("12", "INTRALESIONAL"));
                list.Add(new ListItem("14", "INTRAPERITONIAL"));
                list.Add(new ListItem("15", "INTRAPLEURAL"));
                list.Add(new ListItem("16", "INTRATECAL"));
                list.Add(new ListItem("17", "INTRATRAQUEAL"));
                list.Add(new ListItem("18", "INTRAUTERINA"));
                list.Add(new ListItem("21", "INTRAVITREA"));
                list.Add(new ListItem("22", "IRRIGAÇÃO"));
                list.Add(new ListItem("23", "NASAL"));
                list.Add(new ListItem("24", "OFTALMICA"));
                list.Add(new ListItem("26", "OTOLOGICA"));
                list.Add(new ListItem("27", "VR - RETAL"));
                list.Add(new ListItem("28", "SNE - SONDA ENTERAL"));
                list.Add(new ListItem("29", "SNG - SONDA GASTRICA"));
                list.Add(new ListItem("30", "SC - SUBCUTANEA"));
                list.Add(new ListItem("31", "SL - SUBLINGUAL"));
                list.Add(new ListItem("32", "TRANSDERMICA"));
                list.Add(new ListItem("33", "URETRAL"));
                list.Add(new ListItem("34", "VAGINAL"));
                list.Add(new ListItem("35", "NÃO SE APLICA"));
            }

            cmbVia.ValueMember = ListItem.FieldNames.Key;
            cmbVia.DisplayMember = ListItem.FieldNames.Value;
            cmbVia.DataSource = list;
            cmbVia.IniciaLista();
        }

        private void CarregarDoencaDiagnostico(string tipo, HacCheckedListBox clbDoDi)
        {
            DoencaDiagnosticoDTO dtoDoDi = new DoencaDiagnosticoDTO();
            dtoDoDi.Tipo.Value = tipo;
            if (clbDoDi.Items.Count == 0)
            {                
                DoencaDiagnosticoDataTable dtbDoDi = DoencaDiagnostico.Listar(dtoDoDi);                
                foreach (DataRow row in dtbDoDi.Rows)
                    clbDoDi.Items.Add(new ListItem(row[DoencaDiagnosticoDTO.FieldNames.Id].ToString(), row[DoencaDiagnosticoDTO.FieldNames.Descricao].ToString()));
            }
            if (dtoPrescricao != null)
            {
                PrescricaoDTO dtoPrcDoDi = new PrescricaoDTO();
                dtoPrcDoDi.IdPrescricao.Value = dtoPrescricao.IdPrescricao.Value;
                if (!dtoPrescricao.IdPrescricaoMedica.Value.IsNull)
                {
                    dtoPrcDoDi.IdPrescricaoMedica.Value = dtoPrescricao.IdPrescricaoMedica.Value;
                    dtoPrcDoDi.IdAtendimento.Value = dtoPrescricao.IdAtendimento.Value;
                }
                PrescricaoDataTable dtbPrcDo = Prescricao.ListarDoencaDiagnostico(dtoPrcDoDi, dtoDoDi);
                for (int index = 0; index < clbDoDi.Items.Count; index++)
                    clbDoDi.SetItemChecked(index, dtbPrcDo.Select(string.Format("{0}={1}", PrescricaoDTO.FieldNames.IdDoencaDiagnostico, ((ListItem)clbDoDi.Items[index]).Key)).Length > 0);

                if (tipo == "DI")
                {
                    cbMedicoAssinou.Enabled = txtDataAssinaturaMedico.Enabled = true;
                    cbMedicoAssinou.Checked = !dtoPrescricao.DataAssinaturaSCIH.Value.IsNull;
                    txtDataAssinaturaMedico.Text = string.Empty;
                    if (!dtoPrescricao.DataAssinaturaSCIH.Value.IsNull)
                        txtDataAssinaturaMedico.Text = ((DateTime)dtoPrescricao.DataAssinaturaSCIH.Value).ToString("dd/MM/yyyy");
                    txtDataAssinaturaMedico.Enabled = !string.IsNullOrEmpty(txtDataAssinaturaMedico.Text);
                }
            }
        }

        private void AdicionarDoencaDiagnostico(string tipo, HacCheckedListBox clbDoDi)
        {
            bool selecionarNovoItem = false;
            bool itemModificado = false;
            DoencaDiagnosticoDTO dtoDoDi = new DoencaDiagnosticoDTO();
            dtoDoDi.Tipo.Value = tipo;
            dtoDoDi = FrmDoencaDiagnostico.Carregar(dtoDoDi, out selecionarNovoItem, out itemModificado);
            if ((dtoDoDi != null && !dtoDoDi.Id.Value.IsNull) && selecionarNovoItem)
                clbDoDi.Items.Add(new ListItem(dtoDoDi.Id.Value, dtoDoDi.Descricao.Value), true);            
            else if (itemModificado)
            {
                clbDoDi.Items.Clear();
                CarregarDoencaDiagnostico(tipo, clbDoDi);
            }
        }

        private bool SalvarDoencaDiagnostico(string tipo, HacCheckedListBox clbDoDi)
        {
            if (dtoPrescricao != null)
            {
                if (tipo == "DI")
                {
                    PrescricaoDTO dtoPrcDi = new PrescricaoDTO();
                    dtoPrcDi.IdPrescricao.Value = dtoPrescricao.IdPrescricao.Value;
                    dtoPrcDi = Prescricao.ListarItem(dtoPrcDi, false).TypedRow(0);
                    if (!string.IsNullOrEmpty(txtDataAssinaturaMedico.Text))
                    {
                        #region VALIDAÇÃO DATA
                        try
                        {
                            if (Convert.ToDateTime(txtDataAssinaturaMedico.Text) < ((DateTime)dtoPrescricao.DataInclusao.Value).Date)
                            {
                                MessageBox.Show("A Data da Assinatura não pode ser menor que a Data da Inclusão da Prescrição.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtDataAssinaturaMedico.Focus();
                                return false;
                            }
                            if (Convert.ToDateTime(txtDataAssinaturaMedico.Text) > Utilitario.ObterDataHoraServidor().Date)
                            {
                                MessageBox.Show("A Data da Assinatura não pode ser maior que a Data Atual.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtDataAssinaturaMedico.Focus();
                                return false;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Data Assinatura inválida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        #endregion
                        
                        dtoPrcDi.DataAssinaturaSCIH.Value = txtDataAssinaturaMedico.Text;
                    }
                    else if (string.IsNullOrEmpty(txtDataAssinaturaMedico.Text))
                        dtoPrcDi.DataAssinaturaSCIH.Value = new Framework.DTO.TypeDateTime();
                    
                    dtoPrcDi.IdUsuarioAlteracao.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    Prescricao.GravarInformacoesExtras(dtoPrcDi);

                    dtoPrescricao = dtoPrcDi;                    
                }
                PrescricaoDTO dtoPrcDoDi = new PrescricaoDTO();
                DoencaDiagnosticoDTO dtoDoDi = new DoencaDiagnosticoDTO();
                dtoPrcDoDi.IdPrescricao.Value = dtoPrescricao.IdPrescricao.Value;
                dtoDoDi.Tipo.Value = tipo;
                PrescricaoDataTable dtbPrcDo = Prescricao.ListarDoencaDiagnostico(dtoPrcDoDi, dtoDoDi);
                bool jaExiste;

                for (int index = 0; index < clbDoDi.Items.Count; index++)
                {
                    dtoPrescricao.IdDoencaDiagnostico.Value = ((ListItem)clbDoDi.Items[index]).Key;
                    jaExiste = dtbPrcDo.Select(string.Format("{0}={1}", PrescricaoDTO.FieldNames.IdDoencaDiagnostico, dtoPrescricao.IdDoencaDiagnostico.Value)).Length > 0;

                    if (clbDoDi.GetItemChecked(index) && !jaExiste)
                        Prescricao.AssociarDoencaDiagnostico(dtoPrescricao);
                    else if (!clbDoDi.GetItemChecked(index) && jaExiste)
                        Prescricao.DesassociarDoencaDiagnostico(dtoPrescricao);

                    dtoPrescricao.IdDoencaDiagnostico.Value = new Framework.DTO.TypeDecimal();
                }
                return true;
            }
            return false;
        }

        private void CarregarDadosInternacao()
        {
            HabilitarSubTela(grbDadosInternacao);
            this.LimparControles(grbDadosInternacao.Controls);
            this.ConfigurarControles(grbDadosInternacao.Controls, true);
            txtCirurgia.Enabled = txtAcessoVasc.Enabled = txtSondaVes.Enabled = txtOutros.Enabled = false;

            if (dtoPrescricao != null)
            {
                if (dtoPrescricao.FlInternadoUTI.Value.IsNull) dtoPrescricao.FlInternadoUTI.Value = 0;
                cbInternadoUTI.Checked = dtoPrescricao.FlInternadoUTI.Value == 1 ? true : false;

                if (dtoPrescricao.FlVentilaMecanica.Value.IsNull) dtoPrescricao.FlVentilaMecanica.Value = 0;
                cbVentiMec.Checked = dtoPrescricao.FlVentilaMecanica.Value == 1 ? true : false;

                if (!dtoPrescricao.CirurgiaDsc.Value.IsNull)
                {
                    cbCirurgia.Checked = cbCirurgia.Enabled = txtCirurgia.Enabled = true;
                    txtCirurgia.Text = dtoPrescricao.CirurgiaDsc.Value;
                }
                if (!dtoPrescricao.AcessoVascularDsc.Value.IsNull)
                {
                    cbAcessoVasc.Checked = cbAcessoVasc.Enabled = txtAcessoVasc.Enabled = true;
                    txtAcessoVasc.Text = dtoPrescricao.AcessoVascularDsc.Value;
                }
                if (!dtoPrescricao.SondaVesicalDsc.Value.IsNull)
                {
                    cbSondaVes.Checked = cbSondaVes.Enabled = txtSondaVes.Enabled = true;
                    txtSondaVes.Text = dtoPrescricao.SondaVesicalDsc.Value;
                }
                if (!dtoPrescricao.OutrosDsc.Value.IsNull)
                {
                    cbOutros.Checked = cbOutros.Enabled = txtOutros.Enabled = true;
                    txtOutros.Text = dtoPrescricao.OutrosDsc.Value;
                }
            }
        }

        private bool SalvarDadosInternacao()
        {
            if (dtoPrescricao != null)
            {
                PrescricaoDTO dtoPrcInternacao = new PrescricaoDTO();
                
                dtoPrcInternacao.IdPrescricao.Value = dtoPrescricao.IdPrescricao.Value;
                dtoPrcInternacao = Prescricao.ListarItem(dtoPrcInternacao, false).TypedRow(0);
                
                dtoPrcInternacao.FlInternadoUTI.Value = cbInternadoUTI.Checked ? 1 : 0;
                dtoPrcInternacao.FlVentilaMecanica.Value = cbVentiMec.Checked ? 1 : 0;
                
                if (cbCirurgia.Checked && !string.IsNullOrEmpty(txtCirurgia.Text.Trim()))
                    dtoPrcInternacao.CirurgiaDsc.Value = txtCirurgia.Text.Trim();
                else
                    dtoPrcInternacao.CirurgiaDsc.Value = new Framework.DTO.TypeString();                

                if (cbAcessoVasc.Checked && !string.IsNullOrEmpty(txtAcessoVasc.Text.Trim()))
                    dtoPrcInternacao.AcessoVascularDsc.Value = txtAcessoVasc.Text.Trim();
                else
                    dtoPrcInternacao.AcessoVascularDsc.Value = new Framework.DTO.TypeString();

                if (cbSondaVes.Checked && !string.IsNullOrEmpty(txtSondaVes.Text.Trim()))
                    dtoPrcInternacao.SondaVesicalDsc.Value = txtSondaVes.Text.Trim();
                else
                    dtoPrcInternacao.SondaVesicalDsc.Value = new Framework.DTO.TypeString();

                if (cbOutros.Checked && !string.IsNullOrEmpty(txtOutros.Text.Trim()))
                    dtoPrcInternacao.OutrosDsc.Value = txtOutros.Text.Trim();
                else
                    dtoPrcInternacao.OutrosDsc.Value = new Framework.DTO.TypeString();

                dtoPrcInternacao.IdUsuarioAlteracao.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                Prescricao.GravarInformacoesExtras(dtoPrcInternacao);
                
                dtoPrescricao = dtoPrcInternacao;
                return true;
            }
            return false;
        }

        private bool SalvarInfComplementares()
        {
            if (dtoPrescricao != null)
            {
                PrescricaoDTO dtoPrc = new PrescricaoDTO();

                dtoPrc.IdPrescricao.Value = dtoPrescricao.IdPrescricao.Value;
                dtoPrc = Prescricao.ListarItem(dtoPrc, false).TypedRow(0);
                dtoPrc.InformacoesComplementares.Value = txtInfCompl.Text;
                dtoPrc.IdUsuarioAlteracao.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                Prescricao.GravarInformacoesExtras(dtoPrc);

                dtoPrescricao = dtoPrc;

                return true;
            }
            return false;
        }

        private void CarregarCultura()
        {
            HabilitarSubTela(grbCultura);
            if (dtoPrescricao != null)
            {                
                LimparCulturaEdicao();
                this.ConfigurarControles(grbCultura.Controls, true);
                dtgCultura.DataSource = Prescricao.ListarCultura(dtoPrescricao);
                dtgCultura.ClearSelection();
                //if (dtgCultura.Rows.Count == 0) txtDataCultura.Focus();
            }
        }

        private void LimparCulturaEdicao()
        {
            dtoPrescricao.CulturaSequencial.Value = new Framework.DTO.TypeDecimal();
            txtMaterial.Text = txtMicroorg.Text = txtSensibilidade.Text = string.Empty;
            txtDataCultura.Text = Utilitario.ObterDataHoraServidor().ToString("dd/MM/yyyy");
        }

        private bool SalvarCultura()
        {
            #region VALIDAÇÃO DATA
            if (string.IsNullOrEmpty(txtDataCultura.Text))
            {
                MessageBox.Show("Data da Cultura é Obrigatória.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDataCultura.Focus();
                return false;
            }
            try
            {
                if (Convert.ToDateTime(txtDataCultura.Text) < ((DateTime)dtoPrescricao.DataInclusao.Value).Date)
                {
                    MessageBox.Show("A Data da Cultura não pode ser menor que a Data da Inclusão da Prescrição.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDataCultura.Focus();
                    return false;
                }
                if (Convert.ToDateTime(txtDataCultura.Text) > Utilitario.ObterDataHoraServidor().Date)
                {
                    MessageBox.Show("A Data da Cultura não pode ser maior que a Data Atual.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDataCultura.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Data da Cultura inválida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            #endregion

            if (string.IsNullOrEmpty(txtMaterial.Text) && string.IsNullOrEmpty(txtMicroorg.Text) && string.IsNullOrEmpty(txtSensibilidade.Text))
            {
                MessageBox.Show("Digite pelo menos um dos 3 campos.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaterial.Focus();
                return false;
            }

            dtoPrescricao.DataCultura.Value = txtDataCultura.Text;
            dtoPrescricao.Material.Value = txtMaterial.Text;
            dtoPrescricao.Microorganismo.Value = txtMicroorg.Text;
            dtoPrescricao.SensibilidadeMIC.Value = txtSensibilidade.Text;

            Prescricao.GravarCultura(dtoPrescricao);
            CarregarCultura();

            return true;
        }

        private void CarregarParecer()
        {
            HabilitarSubTela(grbParecer);            
            this.ConfigurarControles(grbParecer.Controls, true);
            if (dtoPrescricao == null)
                this.LimparControles(grbParecer.Controls);

            rbAutorizado.Enabled = rbAutorizadoNao.Enabled = true;
            //if (rbAutorizadoNao.Checked)
            //    rbAutorizado.Enabled = rbAutorizadoNao.Enabled = false;
        }

        private bool SalvarParecer()
        {
            if (!rbAutorizado.Checked && !rbAutorizadoNao.Checked)
            {
                MessageBox.Show("Favor checar se está autorizado ou não.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(txtCRMParecer.Text))
            {
                MessageBox.Show("CRM obrigatório.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            #region VALIDAÇÃO DATA
            if (!string.IsNullOrEmpty(txtDataParecer.Text))
                try
                {
                    if (!string.IsNullOrEmpty(txtDataParecer.Text) && Convert.ToDateTime(txtDataParecer.Text) < ((DateTime)dtoPrescricao.DataInclusao.Value).Date)
                    {
                        MessageBox.Show("A Data do Parecer não pode ser menor que a Data da Inclusão da Prescrição.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDataParecer.Focus();
                        return false;
                    }
                    if (Convert.ToDateTime(txtDataParecer.Text) > Utilitario.ObterDataHoraServidor().Date)
                    {
                        MessageBox.Show("A Data do Parecer não pode ser maior que a Data Atual.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDataParecer.Focus();
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show("Data do Parecer inválida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            #endregion            

            bool itemZerar = false;
            if (_naoAutorizado && !rbAutorizado.Checked && rbAutorizadoNao.Checked &&
                MessageBox.Show("Confirma que o consumo deste medicamento realmente NÃO está autorizado?",
                                "Gestão de Materiais e Medicamentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                this.CancelarProgramacaoItemPrescricao(null);
                itemZerar = true;
            }
            else if (rbAutorizado.Checked)
            {
                this.Cursor = Cursors.WaitCursor;
                this.ReativarProgramacaoItemPrescricao();
            }

            this.Cursor = Cursors.WaitCursor;
            if (rbAutorizado.Checked || !rbAutorizado.Enabled || itemZerar)
            {
                dtoPrescricao.FlAutorizado.Value = rbAutorizado.Checked ? 1 : 0;
                dtoPrescricao.ParecerSCIH.Value = txtParecer.Text;
                dtoPrescricao.ParecerData.Value = new Framework.DTO.TypeDateTime();
                if (!string.IsNullOrEmpty(txtDataParecer.Text))
                    dtoPrescricao.ParecerData.Value = txtDataParecer.Text;
                dtoPrescricao.IdProduto.Value = dtoMatMed.Idt.Value;
                dtoPrescricao.IdUsuarioAlteracao.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                if (_naoAutorizado && _idMPM != null)
                    dtoPrescricao.IdMedicamentoPrescricaoMedica.Value = _idMPM.Value;
                else
                    dtoPrescricao.IdMedicamentoPrescricaoMedica.Value = new Framework.DTO.TypeDecimal();

                Prescricao.GravarParecerSCIH(dtoPrescricao);

                if (_idMPM != null)
                    dtoPrescricao.IdMedicamentoPrescricaoMedica.Value = _idMPM.Value;

                if (rbAutorizadoNao.Checked)
                {
                    txtDataLimite.Enabled = btnAddItem.Enabled = false;
                    //rbAutorizado.Enabled = rbAutorizadoNao.Enabled = false;
                }
                else
                    txtDataLimite.Enabled = btnAddItem.Enabled = true;

                _naoAutorizado = false;

                PrescricaoDTO dto = new PrescricaoDTO();
                dto.IdPrescricao.Value = txtCod.Text; //Atualizar DataTable
                dtbPrescricao = Prescricao.ListarItem(dto, false);
                CarregarItens();
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.Default;
                return false;
            }            

            return true;
        }

        private void CancelarProgramacaoItemPrescricao(DateTime? dtLimite)
        {
            if (_idMPM != null)
            {
                RequisicaoItensDTO dtoRequisicaoItem = new RequisicaoItensDTO();
                dtoRequisicaoItem.IdPrescricaoItemInternacao.Value = _idMPM;                
                RequisicaoItensDataTable dtbRequisicaoItem = RequisicaoItens.Sel(dtoRequisicaoItem);                
                foreach (DataRow row in dtbRequisicaoItem.Rows)
                {
                    if (int.Parse(row[RequisicaoDTO.FieldNames.Status].ToString()) == (byte)RequisicaoDTO.StatusRequisicao.IMPRESSO ||
                        int.Parse(row[RequisicaoDTO.FieldNames.Status].ToString()) == (byte)RequisicaoDTO.StatusRequisicao.FECHADA)
                    {
                        dtoRequisicaoItem = new RequisicaoItensDTO();
                        dtoRequisicaoItem.Idt.Value = row[RequisicaoItensDTO.FieldNames.Idt].ToString();
                        dtoRequisicaoItem.IdtProduto.Value = row[RequisicaoItensDTO.FieldNames.IdtProduto].ToString();
                        dtoRequisicaoItem.QtdSolicitada.Value = 0;
                        dtoRequisicaoItem.QtdFornecida.Value = 0;
                        RequisicaoItens.Upd(dtoRequisicaoItem);
                    }
                }

                RequisicaoDTO dtoReqPedidoAutoControle = new RequisicaoDTO();
                RequisicaoItensDTO dtoReqItemPedidoAutoControle = new RequisicaoItensDTO();

                dtoReqPedidoAutoControle.IdtAtendimento.Value = dtoPrescricao.IdAtendimento.Value;
                dtoReqItemPedidoAutoControle.IdUsuarioPedidoAutoCancelado.Value = FrmPrincipal.dtoSeguranca.Idt.Value; //Passa o usuário para não trazer cancelados
                dtoReqItemPedidoAutoControle.IdPrescricaoItemInternacao.Value = _idMPM.Value;

                DataTable dtbItemProgramado = RequisicaoItens.ListarPedidoAutoControle(dtoReqItemPedidoAutoControle, dtoReqPedidoAutoControle, 4);

                if (dtLimite != null)
                {
                    dtbItemProgramado = new DataView(dtbItemProgramado,
                                                     string.Format("{0} >= '{1}'", RequisicaoItensDTO.FieldNames.DataHoraAdmPaciente, dtLimite.Value.Date.AddDays(1)),
                                                     string.Empty,
                                                     DataViewRowState.CurrentRows).ToTable();
                }
                    
                if (dtbItemProgramado.Rows.Count > 0)
                    RequisicaoItens.CancelarProgramacaoItensPrescricao(dtbItemProgramado);
            }
        }

        private void ReativarProgramacaoItemPrescricao()
        {
            if (_idMPM != null)
            {
                RequisicaoDTO dtoReqPedidoAutoControle = new RequisicaoDTO();
                RequisicaoItensDTO dtoReqItemPedidoAutoControle = new RequisicaoItensDTO();

                dtoReqPedidoAutoControle.IdtAtendimento.Value = dtoPrescricao.IdAtendimento.Value;                
                dtoReqItemPedidoAutoControle.IdPrescricaoItemInternacao.Value = _idMPM.Value;

                DataTable dtbItemProgramado = RequisicaoItens.ListarPedidoAutoControle(dtoReqItemPedidoAutoControle, dtoReqPedidoAutoControle, 1);

                if (dtbItemProgramado.Rows.Count > 0)
                {
                    DateTime dataAtual = Utilitario.ObterDataHoraServidor();
                    foreach (DataRow rowProgramado in dtbItemProgramado.Rows)
                    {
                        if (string.IsNullOrEmpty(rowProgramado[RequisicaoItensDTO.FieldNames.IdtNovo].ToString()) &&
                            !string.IsNullOrEmpty(rowProgramado[RequisicaoItensDTO.FieldNames.IdUsuarioPedidoAutoCancelado].ToString()))
                        {
                            string dataAdm = rowProgramado[RequisicaoItensDTO.FieldNames.DataHoraAdmPaciente].ToString();
                            if (DateTime.Parse(dataAdm) >= dataAtual) //Se tiver dentro do prazo, reativar pedido programado
                            {
                                RequisicaoItensDTO dtoReqItemCancela = new RequisicaoItensDTO();

                                dtoReqItemCancela.Idt.Value = rowProgramado[RequisicaoItensDTO.FieldNames.Idt].ToString();
                                dtoReqItemCancela.IdtProduto.Value = rowProgramado[RequisicaoItensDTO.FieldNames.IdtProduto].ToString();
                                dtoReqItemCancela.DataHoraGerar.Value = rowProgramado[RequisicaoItensDTO.FieldNames.DataHoraGerar].ToString();
                                dtoReqItemCancela.DataHoraAdmPaciente.Value = rowProgramado[RequisicaoItensDTO.FieldNames.DataHoraAdmPaciente].ToString();
                                dtoReqItemCancela.IdUsuarioPedidoAutoCancelado.Value = new Framework.DTO.TypeDecimal();

                                RequisicaoItens.CancelarPedidoAutoControle(dtoReqItemCancela, true);
                            }
                        }
                    }
                }
            }
        }

        private void HabilitarSubTela(GroupBox grbSubTela)
        {
            pnlSubTelas.Visible = btnSalvarSubTela.Enabled = true;            
            foreach (Control control in pnlSubTelas.Controls)
            {
                if ((control.Name == grbSubTela.Name || control.Name == btnFechar.Name) ||
                    (control.Name == btnSalvarSubTela.Name && (grbSubTela.Name != grbInternacaoAnterior.Name &&
                                                               grbSubTela.Name != grbAntimicroAnterior.Name)))
                    control.Visible = true;                
                else
                    control.Visible = false;
            }            
        }        

        #endregion

        #region Eventos

        private void grbDados_Enter(object sender, EventArgs e) {}

        private void FrmPrescricao_Load(object sender, EventArgs e)
        {            
            tsHac.Items["tsBtnPesquisar"].Enabled = true;
            btnSalvar.Visible = false;
            _usuarioSomenteLeitura = new Generico().VerificaAcessoFuncionalidade("SoLeituraPrescricao");
            if (_usuarioSomenteLeitura) btnAddItem.Enabled = false;            
            cmbProced.DataSource = Enum.GetValues(typeof(PrescricaoDTO.ProcedenciaPacienteEnum));            
            ConfigurarGrids();
        }        

        private bool _naoValidar_txtCod = false;
        private void txtCod_Validating(object sender, CancelEventArgs e)
        {
            if (!_naoValidar_txtCod) CarregarPrescricao();
        }

        private bool _naoPesquisarPaciente = false;
        private void txtNroInternacao_Validating(object sender, CancelEventArgs e)
        {
            if (!_naoPesquisarPaciente) btnPesquisaPac_Click(sender, e);
        }

        private void txtNroInternacao_TextChanged(object sender, EventArgs e) {}

        private void txtCRM_Validating(object sender, CancelEventArgs e)
        {
            if (!_carregandoPrescricao) btnPesquisaProf_Click(sender, e);
            _carregandoPrescricao = false;
        }

        private void txtCRMParecer_Validating(object sender, CancelEventArgs e)
        {
            if (!_carregandoPrescricao) btnPesquisaProfParecer_Click(sender, e);
            _carregandoPrescricao = false;
        }

        private void txtNomePac_Validating(object sender, CancelEventArgs e) {}

        private void txtDataLimite_Validating(object sender, CancelEventArgs e)
        {
            if (txtDataLimite.Text != string.Empty)
                txtQtdTotalAuto.Focus();
        }

        private void txtQtdTotalAuto_Validating(object sender, CancelEventArgs e)
        {
            //if (txtQtdDia.Text == string.Empty || txtQtdTotalAuto.Text == string.Empty || 
            //    (txtQtdTotalAuto.Text != string.Empty && int.Parse(txtQtdDia.Text) > int.Parse(txtQtdTotalAuto.Text)))
            //    txtQtdDia.Text = txtQtdTotalAuto.Text;
            if (txtQtdTotalAuto.Text != string.Empty)
                txtQtdDia.Focus();
        }        

        private void btnPesquisaProfParecer_Click(object sender, EventArgs e)
        {
            if (txtCRMParecer.Enabled && !string.IsNullOrEmpty(txtCRMParecer.Text))
                CarregaInfoProfissionalParecer(true);
            else
            {
                txtProfParecer.Text = string.Empty;
                if (dtoPrescricao != null)
                    dtoPrescricao.IdProfissionalSCIH.Value = new Framework.DTO.TypeDecimal();
            }
        }

        private void btnPesquisaProf_Click(object sender, EventArgs e)
        {
            if (txtCRM.Enabled && !string.IsNullOrEmpty(txtCRM.Text))
                CarregaInfoProfissionalSolicitante(true);
            else
                txtProfSol.Text = string.Empty;
        }

        private void btnPesquisaPac_Click(object sender, EventArgs e)
        {
            if (txtNroInternacao.Enabled && !string.IsNullOrEmpty(txtNroInternacao.Text)) 
                CarregaInfoPaciente(true);
            else if (txtCod.Enabled)
                txtNomePac.Text = string.Empty;
        }        

        private void btnMais_Click(object sender, EventArgs e)
        {
            if (txtNomePac.Text != string.Empty)
            {                
                int qtdNova = int.Parse(txtQtdTotalAuto.Text) + 1;
                if (qtdNova > _qtdPermitidaExternos)
                {
                    btnMais.Enabled = false;
                    return;
                }
                else if (qtdNova == _qtdPermitidaExternos)
                    btnMais.Enabled = false;

                btnMenos.Enabled = true;

                txtQtdTotalAuto.Text = txtQtdDia.Text = qtdNova.ToString();
            }
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            if (txtNomePac.Text != string.Empty)
            {
                int qtdNova = int.Parse(txtQtdTotalAuto.Text) - 1;
                if (qtdNova == 0)
                {
                    btnMenos.Enabled = false;
                    return;
                }
                else if (qtdNova == 1)
                    btnMenos.Enabled = false;

                btnMais.Enabled = true;

                txtQtdTotalAuto.Text = txtQtdDia.Text = qtdNova.ToString();
            }
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            if (dtoPrescricao != null && !dtoPrescricao.IdPrescricao.Value.IsNull &&
                dtoMatMed != null && !dtoMatMed.Idt.Value.IsNull &&
                txtNroInternacao.Text != string.Empty && txtNomePac.Text != string.Empty)
            {
                this.Cursor = Cursors.WaitCursor;
                RequisicaoItensDTO dtoReqItem = new RequisicaoItensDTO();
                dtoReqItem.IdPrescricao.Value = dtoPrescricao.IdPrescricao.Value;
                if (_idMPM == null)
                    dtoReqItem.IdtProduto.Value = dtoMatMed.Idt.Value;
                else
                    dtoReqItem.IdPrescricaoItemInternacao.Value = _idMPM;

                FrmItensReq.PesquisarPrescricaoItem(dtoReqItem);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!this.ValidarPrescricao()) return;
            if (!this.ValidarAlteracao()) return;
            if (this.SalvarPrescricao())
            {
                btnNovo_Click(null, null);
                MessageBox.Show("Prescrição salva com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return;
        }

        private void btnSalvarSubTela_Click(object sender, EventArgs e)
        {
            bool salvo = false;

            if (grbParecer.Visible)
                salvo = SalvarParecer();

            if (!lblPrescIntCod.Visible)
            {
                if (grbDadosInternacao.Visible)
                    salvo = SalvarDadosInternacao();
                else if (grbDoencaBase.Visible)
                    salvo = SalvarDoencaDiagnostico("DO", clbDoencaBase);
                else if (grbDiagnostico.Visible)
                    salvo = SalvarDoencaDiagnostico("DI", clbDiagnostico);
                else if (grbInfCompl.Visible)
                    salvo = SalvarInfComplementares();
                else if (grbCultura.Visible)
                    salvo = SalvarCultura();
            }
            else if (!grbParecer.Visible && !salvo)
            {
                MessageBox.Show("NÃO PERMITIDO REALIZAR ESSA ALTERAÇÃO !", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (salvo)
                MessageBox.Show("Dados salvo com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool _novaPrescricaoSalva;
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            _novaPrescricaoSalva = false;
            if (!this.ValidarItem()) return;
            if (this.AdicionarItem(false))
            {
                btnNovo_Click(null, null);

                if (_novaPrescricaoSalva)
                {
                    CarregarPrescricao();
                    _novaPrescricaoSalva = false;
                }
                else
                {
                    PrescricaoDTO dto = new PrescricaoDTO();
                    dto.IdPrescricao.Value = txtCod.Text; //Atualizar DataTable
                    dtbPrescricao = Prescricao.ListarItem(dto, false);
                    CarregarItens();
                }
            }
        }        

        private void btnExcluirItem_Click(object sender, EventArgs e)
        {
            if (_prescricaoInativa)
            {
                MessageBox.Show("Prescrição inativa", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtoPrescricao != null && !dtoPrescricao.IdPrescricao.Value.IsNull &&
                dtoMatMed != null && !dtoMatMed.Idt.Value.IsNull)
            {
                if (!lblPrescIntCod.Visible)
                {
                    if (MessageBox.Show("Deseja realmente excluir este item?", "Gestão de Materiais e Medicamentos",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SegurancaDTO dtoUsuario;
                        if (!ValidarUsuario(out dtoUsuario)) return;

                        this.Cursor = Cursors.WaitCursor;
                        if (!ValidarInativacaoItem((decimal)dtoMatMed.Idt.Value, true, true))
                        {
                            this.Cursor = Cursors.Default;
                            return;
                        }

                        PrescricaoDTO dtoItem = new PrescricaoDTO();
                        dtoItem.IdPrescricao.Value = dtoPrescricao.IdPrescricao.Value;
                        dtoItem.IdProduto.Value = dtoMatMed.Idt.Value;
                        dtoItem.IdUsuarioAlteracao.Value = dtoUsuario.Idt.Value;
                        Prescricao.ExcluirItem(dtoItem);

                        btnNovo_Click(null, null);

                        PrescricaoDTO dto = new PrescricaoDTO();
                        dto.IdPrescricao.Value = txtCod.Text; //Atualizar DataTable
                        dtbPrescricao = Prescricao.ListarItem(dto, false);
                        CarregarItens();
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            else
                MessageBox.Show("Selecione um item de uma prescrição ativa", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            RotinaNovoItem();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            pnlSubTelas.Visible = false;            
        }

        private void btnDadosIntern_Click(object sender, EventArgs e)
        {
            if (dtoPrescricao == null)
            {
                MessageBox.Show("Selecione ou insira uma Prescrição", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CarregarDadosInternacao();            
        }

        private void btnInternPrevia_Click(object sender, EventArgs e)
        {
            lblInternadoOutroHosp.Visible = false;
            if (!string.IsNullOrEmpty(txtNomePac.Text))
            {
                HabilitarSubTela(grbInternacaoAnterior);
                dtgInternacaoPrevia.DataSource = Atendimento.ListarInternacoesAnterioresPaciente(decimal.Parse(txtNroInternacao.Text));

                if (!dtoPrescricao.InternacaoPrevia.Value.IsNull &&
                    dtoPrescricao.InternacaoPrevia.Value == "S") lblInternadoOutroHosp.Visible = true;
            }
            else
                MessageBox.Show("Selecione um paciente", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnAntimicroPrevio_Click(object sender, EventArgs e)
        {
            lblAntimicroForaHosp.Visible = false; lblAntimicroForaHosp.Text = string.Empty;
            if (!string.IsNullOrEmpty(txtNomePac.Text))
            {
                HabilitarSubTela(grbAntimicroAnterior);
                
                PrescricaoDTO dtoPrc = new PrescricaoDTO();
                dtoPrc.IdAtendimento.Value = txtNroInternacao.Text;
                if (!string.IsNullOrEmpty(txtCod.Text))
                    dtoPrc.IdPrescricao.Value = txtCod.Text;

                dtgAntimicroAnterior.DataSource = Prescricao.ListarItensPrescricoesAnterioresPaciente(dtoPrc);

                if (!dtoPrescricao.AtmPrevio.Value.IsNull)
                {
                    lblAntimicroForaHosp.Text = "Fora do HAC: " + dtoPrescricao.AtmPrevio.Value;
                    lblAntimicroForaHosp.Visible = true;
                }
            }
            else
                MessageBox.Show("Selecione um paciente", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnDoencaBase_Click(object sender, EventArgs e)
        {
            if (dtoPrescricao == null)
            {
                MessageBox.Show("Selecione ou insira uma Prescrição", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HabilitarSubTela(grbDoencaBase);
            CarregarDoencaDiagnostico("DO", clbDoencaBase);
        }

        private void btnDiagnostico_Click(object sender, EventArgs e)
        {
            if (dtoPrescricao == null)
            {
                MessageBox.Show("Selecione ou insira uma Prescrição", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HabilitarSubTela(grbDiagnostico);
            CarregarDoencaDiagnostico("DI", clbDiagnostico);
        }

        private void btnCulturaSol_Click(object sender, EventArgs e)
        {
            if (dtoPrescricao == null)
            {
                MessageBox.Show("Selecione ou insira uma Prescrição", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            
            CarregarCultura();
        }

        private void btnInfCompl_Click(object sender, EventArgs e)
        {
            if (dtoPrescricao == null)
            {
                MessageBox.Show("Selecione ou insira uma Prescrição", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HabilitarSubTela(grbInfCompl);
            if (dtoPrescricao != null)
            {
                txtInfCompl.Enabled = true;
                txtInfCompl.Text = dtoPrescricao.InformacoesComplementares.Value;
                if (string.IsNullOrEmpty(txtInfCompl.Text)) txtInfCompl.Focus();
            }
        }

        private void btnParecerSCIH_Click(object sender, EventArgs e)
        {
            if (_prescricaoInativa)
            {
                MessageBox.Show("Prescrição inativa", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtoPrescricao != null && !dtoPrescricao.IdPrescricao.Value.IsNull &&
                dtoMatMed != null && !dtoMatMed.Idt.Value.IsNull)
            {
                CarregarParecer();
            }
            else
                MessageBox.Show("Selecione um item de uma prescrição ativa", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnAddDoenca_Click(object sender, EventArgs e)
        {
            AdicionarDoencaDiagnostico("DO", clbDoencaBase);
        }

        private void btnAddDiagnostico_Click(object sender, EventArgs e)
        {
            AdicionarDoencaDiagnostico("DI", clbDiagnostico);
        }

        private void btnAddCultura_Click(object sender, EventArgs e)
        {           
            LimparCulturaEdicao();
            dtgCultura.ClearSelection();
            txtMaterial.Focus();
            //txtDataCultura.Focus();
        }

        private void cbCirurgia_Click(object sender, EventArgs e)
        {
            txtCirurgia.Enabled = false;
            txtCirurgia.Text = string.Empty;
            if (cbCirurgia.Checked)
            {
                txtCirurgia.Enabled = true;                
                txtCirurgia.Focus();
            }
        }

        private void cbAcessoVac_Click(object sender, EventArgs e)
        {
            txtAcessoVasc.Enabled = false;
            txtAcessoVasc.Text = string.Empty;
            if (cbAcessoVasc.Checked)
            {
                txtAcessoVasc.Enabled = true;                
                txtAcessoVasc.Focus();
            }
        }

        private void cbSondaVes_Click(object sender, EventArgs e)
        {
            txtSondaVes.Enabled = false;
            txtSondaVes.Text = string.Empty;
            if (cbSondaVes.Checked)
            {
                txtSondaVes.Enabled = true;                
                txtSondaVes.Focus();
            }
        }

        private void cbOutros_Click(object sender, EventArgs e)
        {
            txtOutros.Enabled = false;
            txtOutros.Text = string.Empty;
            if (cbOutros.Checked)
            {
                txtOutros.Enabled = true;                
                txtOutros.Focus();
            }
        }

        private void cbMedicoAssinou_Click(object sender, EventArgs e)
        {
            if (cbMedicoAssinou.Checked)
            {
                if (string.IsNullOrEmpty(txtDataAssinaturaMedico.Text)) txtDataAssinaturaMedico.Text = Utilitario.ObterDataHoraServidor().ToString("dd/MM/yyyy");
                txtDataAssinaturaMedico.Enabled = true;
                txtDataAssinaturaMedico.Focus();
            }
            else
            {
                txtDataAssinaturaMedico.Enabled = false;
                txtDataAssinaturaMedico.Text = string.Empty;                
                cbMedicoAssinou.Focus();
            }
        }

        private bool tsHac_NovoClick(object sender)
        {
            _prescricaoInativa = _pacienteHemodialise = _pacienteEndo = false;
            _tpPaciente = null;
            dtoPrescricao = null;
            dtoMatMed = null;            
            return true;
        }

        private bool tsHac_AfterNovo(object sender)
        {
            RotinaNovoItem();
            lblPrescInt.Visible = lblPrescIntCod.Visible = false;
            lblInclusao.Text = lblAlteracao.Text = string.Empty;
            cbStatus.Checked = btnSalvar.Enabled = true;
            cbStatus.Enabled = txtCod.Enabled = btnSalvar.Visible = btnExcluirItem.Enabled = btnMais.Visible = btnMenos.Visible = pnlSubTelas.Visible = false;
            cmbProced.SelectedIndex = 0;
            rbAutorizadoNao_Click(null, null);
            CarregarVia();
            txtCRM.Focus();            
            return true;
        }

        private bool tsHac_CancelarClick(object sender)
        {
            tsHac_NovoClick(sender);
            return true;
        }

        private void tsHac_AfterCancelar(object sender)
        {
            tsHac_AfterNovo(sender);
            txtCod.Enabled = true; txtCod.Focus();
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            PrescricaoDTO dtoPresc = FrmPrescricaoPesquisa.Pesquisar();
            if (dtoPresc != null && !dtoPresc.IdPrescricao.Value.IsNull && !dtoPresc.IdProduto.Value.IsNull)
            {
                txtCod.Text = dtoPresc.IdPrescricao.Value;
                CarregarPrescricao();
                foreach (DataGridViewRow row in dtgItem.Rows)
                {
                    if (row.Cells[colIdProduto.Name].Value.ToString() == dtoPresc.IdProduto.Value.ToString())
                    {
                        dtgItem.CurrentCell = row.Cells[1];
                        row.Selected = true;                        
                        dtgItem_CellClick(null, null);
                        break;
                    }
                }
                //Feita esta rotina abaixo pra não limpar edição do grid selecionada
                _naoValidar_txtCod = true;
                txtDataLimite.Focus();
                _naoValidar_txtCod = false;
            }
            else if (dtoPresc != null && !dtoPresc.IdPrescricao.Value.IsNull)
            {
                txtCod.Text = dtoPresc.IdPrescricao.Value;
                CarregarPrescricao();
            }
            return false;
        }

        private bool tsHac_MatMedClick(object sender)
        {
            if (txtCod.Enabled || _usuarioSomenteLeitura) return false;
            if (_prescricaoInativa)
            {
                MessageBox.Show("Prescrição inativa", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
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
            btnAddItem.Enabled = true;
            //Feita esta rotina abaixo pra não carregar novamente a prescrição
            _naoValidar_txtCod = true;
            txtDataLimite.Focus();
            _naoValidar_txtCod = false;
            return true;
        }

        private void tsbRelatorios_Click(object sender, EventArgs e)
        {
            FrmRelPrescricao.CarregarTela();
        }

        private void dtgItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _idMPM = null;
            _naoAutorizado = false;
            lblIntervalo.Visible = lblIntervaloDsc.Visible = lblDoseAdm.Visible = lblDoseAdmDsc.Visible = false;
            if (!string.IsNullOrEmpty(dtgItem.CurrentRow.Cells[colIdProduto.Name].Value.ToString()))
            {
                this.Cursor = Cursors.WaitCursor;
                btnNovo_Click(null, null);
                if (pnlSubTelas.Visible && !grbParecer.Visible) pnlSubTelas.Visible = false;
                dtoMatMed = new MaterialMedicamentoDTO();
                dtoMatMed.Idt.Value = dtgItem.CurrentRow.Cells[colIdProduto.Name].Value.ToString();
                dtoMatMed = MatMed.SelChave(dtoMatMed);
                lblProduto.Text = dtgItem.CurrentRow.Cells[colProduto.Name].Value.ToString();
                txtDataIniConsumo.Text = ((DateTime)dtgItem.CurrentRow.Cells[colDataInicio.Name].Value).ToString("dd/MM/yyyy");
                txtDataLimite.Text = ((DateTime)dtgItem.CurrentRow.Cells[colDataLimite.Name].Value).ToString("dd/MM/yyyy");
                txtQtdTotalAuto.Text = dtgItem.CurrentRow.Cells[colQtdeAuto.Name].Value.ToString();
                txtQtdDia.Text = dtgItem.CurrentRow.Cells[colQtdeDia.Name].Value.ToString();
                txtObs.Text = dtgItem.CurrentRow.Cells[colObs.Name].Value.ToString();
                CarregarVia();
                if (dtgItem.CurrentRow.Cells[colViaItem.Name].Value != null && !string.IsNullOrEmpty(dtgItem.CurrentRow.Cells[colViaItem.Name].Value.ToString()))
                    cmbVia.SelectedValue = dtgItem.CurrentRow.Cells[colViaItem.Name].Value.ToString();
                else
                    cmbVia.SelectedIndex = 0;

                rbAutorizado.Enabled = rbAutorizadoNao.Enabled = true;
                rbAutorizadoNao.ForeColor = Color.Black;
                if (string.IsNullOrEmpty(dtgItem.CurrentRow.Cells[colAutorizado.Name].Value.ToString()))
                    rbAutorizado.Checked = rbAutorizadoNao.Checked = false;
                else
                {
                    if (dtgItem.CurrentRow.Cells[colAutorizado.Name].Value.ToString() == "1")
                        rbAutorizado.Checked = true;
                    else
                    {
                        rbAutorizadoNao.Checked = true;
                        rbAutorizadoNao.ForeColor = Color.Red;
                        //rbAutorizado.Enabled = rbAutorizadoNao.Enabled = false;
                    }
                }
                
                rbAutorizadoNao_Click(null, null);                
                txtParecer.Text = dtgItem.CurrentRow.Cells[colParecer.Name].Value.ToString();
                
                txtDataParecer.Text = string.Empty;
                if (!string.IsNullOrEmpty(dtgItem.CurrentRow.Cells[colDataParecer.Name].Value.ToString()))
                    txtDataParecer.Text = ((DateTime)dtgItem.CurrentRow.Cells[colDataParecer.Name].Value).ToString("dd/MM/yyyy");
                else
                    txtDataParecer.Text = Utilitario.ObterDataHoraServidor().Date.ToString("dd/MM/yyyy");

                bool profLoginCarregado = false;
                if (string.IsNullOrEmpty(dtgItem.CurrentRow.Cells[colIdProf.Name].Value.ToString()))
                {
                    //dtgItem.CurrentRow.Cells[colIdProf.Name].Value = 3516; //Dr. Evaldo (como padrão)
                    UsuarioDTO dtoUsu = new UsuarioDTO();
                    dtoUsu.Idt.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    dtoUsu = Usuario.SelChave(dtoUsu);
                    if (!dtoUsu.Matricula.Value.IsNull)
                    {
                        txtCRMParecer.Text = dtoUsu.Matricula.Value;
                        CarregaInfoProfissionalParecer(false);
                        if (txtProfParecer.Text != string.Empty && !dtoPrescricao.IdProfissionalSCIH.Value.IsNull)
                        {
                            dtgItem.CurrentRow.Cells[colIdProf.Name].Value = dtoPrescricao.IdProfissionalSCIH.Value;
                            profLoginCarregado = true;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(dtgItem.CurrentRow.Cells[colIdProf.Name].Value.ToString()) && !profLoginCarregado)
                {
                    DataTable dtbProf = Prescricao.ListarProfissionalCorpoClinico(null, null, null, decimal.Parse(dtgItem.CurrentRow.Cells[colIdProf.Name].Value.ToString()));
                    if (dtbProf.Rows.Count > 0)
                    {
                        DataRow rowProf = dtbProf.Rows[0];
                        dtoPrescricao.IdProfissionalSCIH.Value = rowProf["CAD_PRO_ID_PROFISSIONAL"].ToString();
                        _carregandoPrescricao = true;
                        txtCRMParecer.Text = rowProf["CAD_PRO_NR_CONSELHO"].ToString();
                        txtProfParecer.Text = rowProf["CAD_PRO_NM_NOME"].ToString();
                    }
                    else
                    {
                        dtoPrescricao.IdProfissionalSCIH.Value = new Framework.DTO.TypeDecimal();
                        txtCRMParecer.Text = txtProfParecer.Text = string.Empty;
                    }
                }
                else if (!profLoginCarregado)
                {
                    dtoPrescricao.IdProfissionalSCIH.Value = new Framework.DTO.TypeDecimal();                    
                    txtCRMParecer.Text = txtProfParecer.Text = string.Empty;
                }
                _carregandoPrescricao = false;
                
                btnExcluirItem.Enabled = tsHac.Items["tsBtnMatMed"].Enabled = false;
                if (!_usuarioSomenteLeitura) btnExcluirItem.Enabled = btnAddItem.Enabled = true;
                dtgItem.CurrentRow.Selected = true;                

                _dtInicioValidar = Convert.ToDateTime(txtDataIniConsumo.Text);
                _dtLimiteValidar = Convert.ToDateTime(txtDataLimite.Text);

                if (lblPrescIntCod.Visible)
                {
                    txtDataIniConsumo.Enabled = txtQtdDia.Enabled = txtQtdTotalAuto.Enabled = txtObs.Enabled = cmbVia.Enabled = btnExcluirItem.Enabled = false;                    
                    if (new Generico().LogadoSetorFarmacia() || (int)FrmPrincipal.dtoSeguranca.IdtSetor.Value == UTI_ALMOX_SATELITE)
                        txtQtdDia.Enabled = txtQtdTotalAuto.Enabled = true;

                    if (!string.IsNullOrEmpty(dtgItem.CurrentRow.Cells[colIdMPM.Name].Value.ToString()))
                        _idMPM = int.Parse(dtgItem.CurrentRow.Cells[colIdMPM.Name].Value.ToString());

                    if (rbAutorizadoNao.Checked)
                        txtDataLimite.Enabled = btnAddItem.Enabled = false;

                    if (_idMPM != null)
                    {
                        RequisicaoDTO dtoPedido = new RequisicaoDTO();
                        DataTable dtbReqItem = new DataView(RequisicaoItens.ListarItensPrescricaoInt(new RequisicaoDTO(), int.Parse(lblPrescIntCod.Text), null),
                                                            string.Format("{0} = {1}", RequisicaoItensDTO.FieldNames.IdPrescricaoItemInternacao, _idMPM),
                                                            string.Empty,
                                                            DataViewRowState.CurrentRows).ToTable();
                        if (dtbReqItem.Rows.Count > 0)
                        {
                            lblIntervalo.Visible = lblIntervaloDsc.Visible = lblDoseAdm.Visible = lblDoseAdmDsc.Visible = true;
                            lblIntervalo.Text = dtbReqItem.Rows[0][RequisicaoItensDTO.FieldNames.HorasPeriodoDose].ToString();
                            lblDoseAdm.Text = dtbReqItem.Rows[0][RequisicaoItensDTO.FieldNames.DoseAdministrar].ToString();
                        }                        
                    }
                }

                this.Cursor = Cursors.Default;
            }
        }

        private void dtgCultura_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgCultura.Columns[e.ColumnIndex].Name == colExcluirCultura.Name)
            {
                if (lblPrescIntCod.Visible)
                {
                    MessageBox.Show("NÃO PERMITIDO REALIZAR EXCLUSÃO POR ESTA FUNCIONALIDADE!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Deseja excluir esse registro da lista ?",
                                     "Gestão de Materiais e Medicamentos",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtoPrescricao.CulturaSequencial.Value = dtgCultura.Rows[e.RowIndex].Cells[colSeq.Name].Value.ToString();
                    Prescricao.ExcluirCultura(dtoPrescricao);
                    CarregarCultura();
                }
            }
        }

        private void dtgCultura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgCultura.Rows.Count > 0 && dtoPrescricao != null)
            {
                dtoPrescricao.CulturaSequencial.Value = dtgCultura.CurrentRow.Cells[colSeq.Name].Value.ToString();

                txtDataCultura.Text = DateTime.Parse(dtgCultura.CurrentRow.Cells[colData.Name].Value.ToString()).ToString("dd/MM/yyyy");
                txtMaterial.Text = dtgCultura.CurrentRow.Cells[colMaterial.Name].Value.ToString();
                txtMicroorg.Text = dtgCultura.CurrentRow.Cells[colMicroorg.Name].Value.ToString();
                txtSensibilidade.Text = dtgCultura.CurrentRow.Cells[colSensibilidade.Name].Value.ToString();
            }
        }

        private void dtgCultura_SelectionChanged(object sender, EventArgs e)
        {
            //if (dtgCultura.Rows.Count > 0 && dtoPrescricao != null)
            //{
            //    dtoPrescricao.CulturaSequencial.Value = dtgCultura.CurrentRow.Cells[colSeq.Name].Value.ToString();

            //    txtDataCultura.Text = DateTime.Parse(dtgCultura.CurrentRow.Cells[colData.Name].Value.ToString()).ToString("dd/MM/yyyy"); 
            //    txtMaterial.Text = dtgCultura.CurrentRow.Cells[colMaterial.Name].Value.ToString();
            //    txtMicroorg.Text = dtgCultura.CurrentRow.Cells[colMicroorg.Name].Value.ToString();
            //    txtSensibilidade.Text = dtgCultura.CurrentRow.Cells[colSensibilidade.Name].Value.ToString();                
            //}
        }        

        private void grbCultura_Enter(object sender, EventArgs e) {}

        private void rbAutorizadoNao_Click(object sender, MouseEventArgs e)
        {
            if (grbParecer.Visible)
            {
                if (rbAutorizadoNao.Checked && !rbAutorizado.Checked)
                {
                    rbAutorizadoNao.ForeColor = Color.Red;
                    _naoAutorizado = true;
                }
                else
                {
                    rbAutorizadoNao.ForeColor = Color.Black;
                    _naoAutorizado = false;
                }
            }
        }        

        private void lblPrescIntCod_DoubleClick(object sender, EventArgs e)
        {
            //if (!lblPrescIntCod.Visible) return;

            this.Cursor = Cursors.WaitCursor;
            string nomeRelatorio = "INT_48_PRESCRICAO_MEDICA_NOVA";
            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[5];

            #region Monta Parâmetros

            int x = 0;

            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PATD_PME_ID", lblPrescIntCod.Text);

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
            frmRelatorio.AbreRelatorio(nomeRelatorio, reportParam, true);
            this.Cursor = Cursors.Default;
        }

        #endregion

        
    }
}