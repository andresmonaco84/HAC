using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

using Hac.Windows.Forms.Controls.Forms;
using HacFramework.Windows.Helpers;
using HospitalAnaCosta.Framework;

using HospitalAnaCosta.SGS.Cadastro.DTO;
using HospitalAnaCosta.SGS.Cadastro.Interface;

using HospitalAnaCosta.Services.Produto.DTO;
using HospitalAnaCosta.Services.Produto.Interface;

using System.Drawing;

namespace Hac.Windows.Forms.Controls
{
    [DesignerCategory("Component")]
    public partial class HacBuscaPaciente : HacUserControl
    {
        private const string titulo = "Busca de Pacientes";

        #region Remoting
        private ICadastroPaciente _paciente;
        private ICadastroPessoa _pessoa;
        //private ITelefone _telefone;
        //private IEndereco _endereco;
        //private IAssociacaoPessoaTelefone _associacaoPessoaTelefone;
        //private IAssociacaoPessoaEndereco _associacaoPessoaEndereco;

        private ICadastroPaciente Paciente
        {
            get { return _paciente != null ? _paciente : _paciente = (ICadastroPaciente)CommonServices.GetObject(typeof(ICadastroPaciente)); }
        }

        private ICadastroPessoa Pessoa
        {
            get { return _pessoa != null ? _pessoa : _pessoa = (ICadastroPessoa)CommonServices.GetObject(typeof(ICadastroPessoa)); }
        }

        //private ITelefone Telefone
        //{
        //    get { return _telefone != null ? _telefone : _telefone = (ITelefone)CommonServices.GetObject(typeof(ITelefone)); }
        //}

        //private IEndereco Endereco
        //{
        //    get { return _endereco != null ? _endereco : _endereco = (IEndereco)CommonServices.GetObject(typeof(IEndereco)); }
        //}

        //private IAssociacaoPessoaEndereco  AssociacaoPessoaEndereco
        //{
        //    get { return _associacaoPessoaEndereco != null ? _associacaoPessoaEndereco : _associacaoPessoaEndereco = (IAssociacaoPessoaEndereco)CommonServices.GetObject(typeof(IAssociacaoPessoaEndereco)); }
        //}

        //private IAssociacaoPessoaTelefone AssociacaoPessoaTelefone
        //{
        //    get { return _associacaoPessoaTelefone != null ? _associacaoPessoaTelefone : _associacaoPessoaTelefone = (IAssociacaoPessoaTelefone)CommonServices.GetObject(typeof(IAssociacaoPessoaTelefone)); }
        //}

        #endregion

        private bool cancelou = false;

        private PlanoDTO dtoPlano;
        private ConvenioDTO dtoConvenio;
        private CadastroPacienteDTO dtoPaciente;
        private CadastroPessoaDTO dtoPessoa;
        private DataSet dsPaciente;

        public DataSet DsPaciente
        {
            get { return dsPaciente; }
            set { dsPaciente = value; }
        }

        public CadastroPessoaDTO DtoPessoa
        {
            get { return dtoPessoa; }
            set { dtoPessoa = value; }
        }

        public CadastroPacienteDTO DtoPaciente
        {
            get { return dtoPaciente; }
            set { dtoPaciente = value; }
        }

        public ConvenioDTO DtoConvenio
        {
            get { return dtoConvenio; }
            set { dtoConvenio = value; }
        }

        public PlanoDTO DtoPlano
        {
            get { return dtoPlano; }
            set { dtoPlano = value; }
        }

        private bool _caraterUrgencia = false;
        [Category("Hac")]
        [Description("True - Alguns campos não são obrigatórios")]
        public bool CaraterUrgencia
        {
            get { return _caraterUrgencia; }
            set { _caraterUrgencia = value; }
        }

        [Category("Hac")]
        [Description("Modo Consulta Convênio")]
        public bool ModoConsultaConvenio
        {
            get { return ctlConvenio.ModoConsulta; }
            set { ctlConvenio.ModoConsulta = value; }
        }

        [Category("Hac")]
        [Description("Modo Consulta Plano")]
        public bool ModoConsultaPlano
        {
            get { return ctlPlano.ModoConsulta; }
            set { ctlPlano.ModoConsulta = value; }
        }

        public delegate void PesquisaIdentificacaoDelegate(object sender, CancelEventArgs e);

        [Category("Hac")]
        public event PesquisaIdentificacaoDelegate PesquisaIdentificacao;

        [Category("Hac")]
        protected virtual void OnPesquisaIdentificacao(CancelEventArgs e)
        {
            if (PesquisaIdentificacao != null)
                PesquisaIdentificacao(this, e);

        }

        public delegate void PesquisarAtendimentosDelegate(object sender, CancelEventArgs e);

        [Category("Hac")]
        public event PesquisarAtendimentosDelegate PesquisarAtendimentos;

        [Category("Hac")]
        protected virtual void OnPesquisarAtendimentos(CancelEventArgs e)
        {
            if (PesquisarAtendimentos != null)
                PesquisarAtendimentos(this, e);
        }

        public delegate void CtlPlanoLeaveDelegate(PlanoDTO dtoPlano, CancelEventArgs e);

        [Category("Hac")]
        public event CtlPlanoLeaveDelegate CtlPlanoLeave;

        [Category("Hac")]
        protected virtual void OnCtlPlanoLeave(CancelEventArgs e)
        {
            if (CtlPlanoLeave != null && ctlPlano.DtoPlano != null)
                CtlPlanoLeave(ctlPlano.DtoPlano, e);
        }


        public delegate void btnPesquisarCadastroPaciente_AfterClickDelegate(CancelEventArgs e);

        [Category("Hac")]
        public event btnPesquisarCadastroPaciente_AfterClickDelegate BtnPesquisarCadastroPaciente_AfterClick;

        [Category("Hac")]
        protected virtual void OnBtnPesquisarCadastroPaciente_AfterClick(CancelEventArgs e)
        {
            if (BtnPesquisarCadastroPaciente_AfterClick != null)
                BtnPesquisarCadastroPaciente_AfterClick(e);
        }


        [Category("Hac")]
        public int IdentificacaoLength
        {
            get { return txtIdentificacao.MaxLength; }
            set { txtIdentificacao.MaxLength = value; }
        }

        [Category("Hac")]
        public string Identificacao
        {
            get { return txtIdentificacao.Text; }
            set { txtIdentificacao.Text = value; }
        }

        private int idtUnidade;
        [Category("Hac")]
        public int IdtUnidade
        {
            get { return idtUnidade; }
            set { idtUnidade = value; }
        }

        private int idtLocal;
        [Category("Hac")]
        public int IdtLocal
        {
            get { return idtLocal; }
            set { idtLocal = value; }
        }

        [Category("Hac")]
        public string padrao
        {
            get { return txtPadrao.Text; }
        }

        private bool _isAcidenteTrabalho = false;
        private bool _isRefeicaoAcompanhante = false;
        private bool _isAcompanhante = false;
        private bool _isAmbulanciaAlta = false;

        [Category("Hac")]
        public bool isAcidenteTrabalho
        {
            get { return _isAcidenteTrabalho; }
        }

        [Category("Hac")]
        public bool isRefeicaoAcompanhante
        {
            get { return _isRefeicaoAcompanhante; }
        }

        [Category("Hac")]
        public bool isAcompanhante
        {
            get { return _isAcompanhante; }
        }

        [Category("Hac")]
        public bool isAmbulanciaAlta
        {
            get { return _isAmbulanciaAlta; }
        }

        [Category("Hac")]
        public bool isRN
        {
            get { return chkRN.Checked; }
            set { chkRN.Checked = value; }
        }

        [Category("Hac")]
        public bool DefinirPesquisaIdentificacao
        {
            get { return radPPIdentificacao.Checked; }
            set { radPPIdentificacao.Checked = value; }
        }

        public Boolean _flagModoConsulta = false;

        public bool flagConvenioPlanoAlterado;
        public bool FlagConvenioPlanoAlterado
        {
            get { return flagConvenioPlanoAlterado; }
            set { flagConvenioPlanoAlterado = value; }
        }

        public bool isCNS_Obrigatorio;
        public bool IsCNS_Obrigatorio
        {
            get { return isCNS_Obrigatorio; }
            set { isCNS_Obrigatorio = value; }
        }


        /// <summary>
        /// Carregar Sexo
        /// </summary>
        /// <param name="comboPadrao">ComboBox</param>
        private void CarregarSexo(ComboBox cboSexo)
        {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Selecione>"));
            list.Add(new ListItem("M", "MASCULINO"));
            list.Add(new ListItem("F", "FEMININO"));

            cboSexo.ValueMember = ListItem.FieldNames.Key;
            cboSexo.DisplayMember = ListItem.FieldNames.Value;
            cboSexo.DataSource = list;
            cboSexo.SelectedValue = "-1";
        }

        private void ConfigurarBotoes()
        {
            Bitmap imgButton = new Bitmap(new Bitmap(global::Hac.Windows.Forms.Controls.Properties.Resources.imgCarteirinhaOK), btnPesquisarBeneficiario.Width, btnPesquisarBeneficiario.Height);
            btnPesquisarBeneficiario.BackgroundImage = null;
            btnPesquisarBeneficiario.Image = imgButton;

            Bitmap imgButton2 = new Bitmap(new Bitmap(global::Hac.Windows.Forms.Controls.Properties.Resources.imgPaciente), btnPesquisarCadastroPaciente.Width, btnPesquisarCadastroPaciente.Height);
            btnPesquisarCadastroPaciente.BackgroundImage = null;
            btnPesquisarCadastroPaciente.Image = imgButton2;

            Bitmap imgButton3 = new Bitmap(new Bitmap(global::Hac.Windows.Forms.Controls.Properties.Resources.imgCarterinha), btnPesquisarExclusaoContratual.Width, btnPesquisarExclusaoContratual.Height);
            btnPesquisarExclusaoContratual.BackgroundImage = null;
            btnPesquisarExclusaoContratual.Image = imgButton3;

            Bitmap imgButton4 = new Bitmap(new Bitmap(global::Hac.Windows.Forms.Controls.Properties.Resources.imgLupa));
            btnPesquisaCarencia.BackgroundImage = null;
            btnPesquisaCarencia.Image = imgButton4;
        }

        public HacBuscaPaciente()
        {
            InitializeComponent();

            ConfigurarBotoes();
            Inicializar();                       

            CarregarSexo(cboSexo);
            ctlPlano.Inicializar();
            ctlConvenio.Inicializar();
            ctlSubPlano.Inicializar();
        }

        ~HacBuscaPaciente()
        {
            try
            {
                Dispose();
            }
            finally
            {
                Collect();
            }
        }

        #region "Funções"

        public void BeforePesquisar()
        {
            if (txtCredencialHac.Text != string.Empty)
            {
                if (txtCodSeqBen.Text == string.Empty)
                {
                    txtCodSeqBen.Text = "00";
                }
            }

            if (radPPIdentificacao.Checked)
            {
                txtIdentificacao.Obrigatorio = true;
                txtProntuario.Obrigatorio = false;
                ctlConvenio.Obrigatorio = false;
                ctlPlano.Obrigatorio = false;
                txtCredencial.Obrigatorio = false;
                txtNomePaciente.Obrigatorio = false;
                mskDataNascimento.Obrigatorio = false;
                cboSexo.Obrigatorio = false;
                
                txtIdentificacao.ObrigatorioMensagem = "Campo Identificação Obrigatório.";
            }
            if (radPPProntuario.Checked)
            {
                txtIdentificacao.Obrigatorio = false;
                txtProntuario.Obrigatorio = true;
                ctlConvenio.Obrigatorio = false;
                ctlPlano.Obrigatorio = false;
                txtCredencial.Obrigatorio = false;
                txtNomePaciente.Obrigatorio = false;
                mskDataNascimento.Obrigatorio = false;
                cboSexo.Obrigatorio = false;
                
                txtProntuario.ObrigatorioMensagem = "Campo Prontuário Obrigatório.";
            }
            if (radPPCredencial.Checked)
            {                 
                txtIdentificacao.Obrigatorio = false;
                txtProntuario.Obrigatorio = false;
                ctlConvenio.Obrigatorio = true;
                ctlPlano.Obrigatorio = true;
                txtCredencial.Obrigatorio = true;
                txtNomePaciente.Obrigatorio = false;
                mskDataNascimento.Obrigatorio = false;
                cboSexo.Obrigatorio = false;

                ctlConvenio.ObrigatorioMensagem = "Campo Convênio Obrigatório.";     
                ctlPlano.ObrigatorioMensagem = "Campo Plano Obrigatório.";
                txtCredencial.ObrigatorioMensagem = "Credencial Obrigatória.";
            }
            if (radPPPaciente.Checked)
            {
                txtIdentificacao.Obrigatorio = false;
                txtProntuario.Obrigatorio = false;
                ctlConvenio.Obrigatorio = false;
                ctlPlano.Obrigatorio = false;
                txtCredencial.Obrigatorio = false;
                txtNomePaciente.Obrigatorio = true;
                mskDataNascimento.Obrigatorio = true;
                cboSexo.Obrigatorio = true;

                txtNomePaciente.ObrigatorioMensagem = "Campo Nome Paciente Obrigatório.";                
                mskDataNascimento.ObrigatorioMensagem = "Campo Data de Nascimento Obrigatório.";                
                cboSexo.ObrigatorioMensagem = "Campo Sexo Obrigatório.";
            }
        }

        public void AfterPesquisar()
        {
            DesabilitarControlesParaEdicao();
            HabilitarBotoes();
            btnPesquisarBeneficiario.Enabled = true;
        }

        public void Inicializar()
        {
            Collect();
            DesabilitarControles();

            gbxPesquisaPor.Enabled = true;

            radPPIdentificacao.Checked = true;
            txtIdentificacao.Enabled = true;
            idtUnidade = 0;
            idtLocal = 0;

            this.DsPaciente = null;
            this.DtoPaciente = null;
            this.DtoPessoa = null;
            this.DtoPlano = null;
            this.DtoConvenio = null;

            FrmCadastroPaciente.IsRN = false;

            chkRN.Checked = FrmCadastroPaciente.IsRN;
        }

        public void DesabilitarControles()
        {
            ConfigurarControles(this.Controls, false);
            txtCodSeq.Enabled = false;
            txtCredencialHac.Enabled = false;
            txtCodSeqBen.Enabled = false;

            ConfigurarControles(this.gbxPesquisaPor.Controls, true);

            btnPesquisarBeneficiario.Enabled = true;
        }

        public void DesabilitarControlesParaEdicao()
        {
            ConfigurarControles(this.Controls, false);
        }

        public void DesabilitarPesquisaPor()
        {
            ConfigurarControles(this.gbxPesquisaPor.Controls, false);
        }

        protected void ConfigurarControles(Control.ControlCollection controls, bool habilitar)
        {
            foreach (Control ctr in controls)
            {
                if (ctr.HasChildren) ConfigurarControles(ctr.Controls, habilitar);
                if (ctr is HacTextBox) ((HacTextBox)ctr).Enabled = habilitar;
                if (ctr is HacComboBox) ((HacComboBox)ctr).Enabled = habilitar;
                if (ctr is HacRadioButton) ((HacRadioButton)ctr).Enabled = habilitar;
                if (ctr is HacCheckBox) ((HacCheckBox)ctr).Enabled = habilitar;
                if (ctr is HacButton) ((HacButton)ctr).Enabled = habilitar;
                if (ctr is HacMaskedTextBox) ((HacMaskedTextBox)ctr).Enabled = habilitar;
            }
        }
        #endregion

        [Category("Hac")]
        public bool Pesquisar(Boolean flagModoConsulta, bool isCNS_Obrigatorio)
        {
            _flagModoConsulta = flagModoConsulta;

            IsCNS_Obrigatorio = isCNS_Obrigatorio;

            bool result = false;

            if (radPPIdentificacao.Checked)
            {
                CancelEventArgs cancelEventArgs = new CancelEventArgs();
                OnPesquisaIdentificacao(cancelEventArgs);
                result = !cancelEventArgs.Cancel;
            }
            if (radPPCredencial.Checked)
            {
                result = PesquisarPorCredencial();
            }
            if (radPPProntuario.Checked)
            {
                result = PesquisarPorProntuario();
            }
            if (radPPPaciente.Checked)
            {
                //result = PesquisarPorNomeDataNascimentoSexo();
                //validando data válida
                {
                    if (BasicFunctions.ValidarData(mskDataNascimento.Text))
                    {
                        result = PesquisarPorNomeDataNascimentoSexo();
                    }
                    else
                    {
                        MessageBox.Show("Data Inválida", titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        mskDataNascimento.Focus();
                    }
                }
            }
            if (radPPAtendimentos.Checked)
            {
                CancelEventArgs cancelEventArgs = new CancelEventArgs();
                OnPesquisarAtendimentos(cancelEventArgs);
                result = !cancelEventArgs.Cancel;
            }

            return result;
        }

        public void HabilitarBotoes()
        {
            btnPesquisarCadastroPaciente.Enabled = true;
            btnPesquisarCoberturaExigencia.Enabled = true;
            btnPesquisarBeneficiario.Enabled = true;
            if (ctlConvenio.DtoConvenio != null)
            {
                if (ctlConvenio.DtoConvenio.CodigoHACPrestador.Value == "SD01")
                    btnPesquisarExclusaoContratual.Enabled = btnPesquisaCarencia.Enabled = true;
                else
                    btnPesquisarExclusaoContratual.Enabled = btnPesquisaCarencia.Enabled = false;
            }

            if (_flagModoConsulta)
            {
                btnPesquisarCoberturaExigencia.Enabled =
                    btnExibeMascaraCredencial.Enabled =
                    btnEtiquetaPaciente.Enabled =
                    btnPesquisarBeneficiario.Enabled =
                    btnPesquisarExclusaoContratual.Enabled =
                    btnPesquisaCarencia.Enabled = false;

                btnPesquisarCadastroPaciente.Enabled = true;
            }
            
        }

        public void EsconderBotoes(bool esconder)
        {
            btnPesquisarCadastroPaciente.Visible = !esconder;
            btnPesquisarCoberturaExigencia.Visible = !esconder;
            //btnPesquisarBeneficiario.Visible = !esconder;
            btnPesquisarExclusaoContratual.Visible = !esconder;
            btnPesquisaCarencia.Visible = !esconder;
        }

        public void Collect()
        {
            //_CommonServices = null;
            _paciente = null;
            _pessoa = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        #region "Check's"
        private void radPPIdentificacao_CheckedChanged(object sender, EventArgs e)
        {
            if (radPPIdentificacao.Checked)
            {
                LimparCampos();
                DesabilitarControles();
                txtIdentificacao.Enabled = true;
                txtIdentificacao.Focus();
            }
        }

        private void radPPCredencial_CheckedChanged(object sender, EventArgs e)
        {
            if (radPPCredencial.Checked)
            {
                LimparCampos();
                DesabilitarControles();
                gbxIdentificacaoPaciente.Enabled = true;
                ctlConvenio.Enabled = true;
                ctlPlano.Enabled = true;
                ctlSubPlano.Enabled = true;
                txtCredencial.Enabled = true;
                txtCodSeq.Enabled = true;
                txtCodSeqBen.Enabled = true;
                txtCredencialHac.Enabled = true;
                chkRN.Enabled = true;
                ctlConvenio.Focus();

                //
                dtoConvenio = new ConvenioDTO();
                dtoConvenio.IdtConvenio.Value = 281;
                ctlConvenio.CarregarConvenio(dtoConvenio);
            }
        }
        private void radPPProntuario_CheckedChanged(object sender, EventArgs e)
        {
            if (radPPProntuario.Checked)
            {
                LimparCampos();
                DesabilitarControles();
                txtProntuario.Enabled = true;
                txtProntuario.Focus();
            }
        }

        #endregion

        private void ConfiguraConvenio()
        {
            if (ctlConvenio.DtoConvenio != null)
            {
                bool isACS = Paciente.IsFuncionarioACS(ctlConvenio.DtoConvenio.IdtConvenio.Value.ToString());

                txtCodSeq.Visible = isACS;
                txtCredencialHac.Visible = isACS;
                txtCodSeqBen.Visible = isACS;
                if (!radPPPaciente.Checked)
                {
                    txtCodSeq.Enabled = isACS;
                    txtCredencialHac.Enabled = isACS;
                    txtCodSeqBen.Enabled = isACS;
                }                
                
                txtCredencial.Visible = !isACS;                
                if (!radPPPaciente.Checked)
                {
                    txtCredencial.Enabled = !isACS;
                }
                ctlPlano.Focus();
            }
        }

        public void SetaPaciente()
        {
            try
            {
                if (dsPaciente != null)
                {
                    dtoPaciente = (CadastroPacienteDTO)dsPaciente.Tables["CadastroPaciente"].Rows[0];
                    dtoPessoa = (CadastroPessoaDTO)dsPaciente.Tables["CadastroPaciente"].Rows[0].GetParentRow("relPessoa");
                    dtoConvenio = (ConvenioDTO)dsPaciente.Tables["CadastroPaciente"].Rows[0].GetParentRow("relConvenio");
                    dtoPlano = (PlanoDTO)dsPaciente.Tables["CadastroPaciente"].Rows[0].GetParentRow("relPlano");
                    DataRow rowComplementoPaciente = dsPaciente.Tables["CadastroPaciente"].Rows[0].GetParentRow("relComplementoPaciente");

                    ctlConvenio.CarregarConvenio(dtoConvenio);
                    ctlPlano.CarregarPlano(dtoPlano);

                    if (!dtoPaciente.CodigoSubPlano.Value.IsNull)
                    {
                        SubPlanoDTO _dtoSubPlano = new SubPlanoDTO();
                        _dtoSubPlano.Codigo.Value = dtoPaciente.CodigoSubPlano.Value;
                        _dtoSubPlano.IdtConvenio.Value = dtoConvenio.IdtConvenio.Value;                        
                        ctlSubPlano.CarregarSubPlano(_dtoSubPlano);
                    }
                    
                    txtPadrao.Text = rowComplementoPaciente["Padrao"].ToString();
                    
                    if(rowComplementoPaciente["Cronico"].ToString() != string.Empty)
                        txtCronico.Text = Convert.ToBoolean(rowComplementoPaciente["Cronico"]) ? "Crônico" : string.Empty;

                    if (rowComplementoPaciente["InstitutoGeriatria"].ToString() != string.Empty)
                        txtInstitutoGeriatria.Text = Convert.ToBoolean(rowComplementoPaciente["InstitutoGeriatria"]) ? "INST.GERIATRIA" : string.Empty;

                    //if (Paciente.isPacienteInstitutoGeriatria(null,dtoPaciente))
                    //    txtInstitutoGeriatria.Text = "INST.GERIATRIA";

                    if (rowComplementoPaciente["CoberturaAcidenteTrabalho"].ToString() != string.Empty)
                        _isAcidenteTrabalho = Convert.ToBoolean(rowComplementoPaciente["CoberturaAcidenteTrabalho"]);
                    if (rowComplementoPaciente["CoberturaRefeicaoAcompanhante"].ToString() != string.Empty)
                        _isRefeicaoAcompanhante = Convert.ToBoolean(rowComplementoPaciente["CoberturaRefeicaoAcompanhante"]);
                    if (rowComplementoPaciente["CoberturaAcompanhante"].ToString() != string.Empty)
                        _isAcompanhante = Convert.ToBoolean(rowComplementoPaciente["CoberturaAcompanhante"]);
                    if (rowComplementoPaciente["CoberturaAmbulancia"].ToString() != string.Empty)
                        _isAmbulanciaAlta = Convert.ToBoolean(rowComplementoPaciente["CoberturaAmbulancia"]);

                    txtNomePaciente.Text = dtoPessoa.NomePessoa.Value;
                    txtNomeMae.Text = dtoPessoa.NomeMae.Value;
                    txtProntuario.Text = dtoPaciente.Prontuario.Value;

                    if (Paciente.IsFuncionarioACS(ctlConvenio.DtoConvenio.IdtConvenio.Value.ToString()))
                    {
                        if (radPPCredencial.Checked && txtCredencialHac.Text != string.Empty && 
                            (Convert.ToInt32(txtCredencialHac.Text) != Convert.ToInt32(dtoPaciente.CodigoCredencial.Value.ToString().Substring(3, 7))
                            || (ctlPlano.DtoPlano.IdtPlano.Value.ToString() != dtoPaciente.IdtPlano.Value.ToString())))
                        {
                            //Se a credencial retornada é diferente da credencial digitada, o Paciente foi transferido.
                            MessageBox.Show("Beneficiário Transferido.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        txtCodSeq.Text = dtoPaciente.CodigoCredencial.Value.ToString().Substring(0, 3);
                        txtCredencialHac.Text = dtoPaciente.CodigoCredencial.Value.ToString().Substring(3, 7);
                        txtCodSeqBen.Text = dtoPaciente.CodigoCredencial.Value.ToString().Substring(10, 2);

                    }
                    else
                    {
                        txtCredencial.Text = dtoPaciente.CodigoCredencial.Value;
                    }

                    mskDataNascimento.Text = Convert.ToDateTime(dtoPessoa.DataNascimento.Value).ToString("dd/MM/yyyy");
                    cboSexo.SelectedValue = dtoPessoa.Sexo.Value.ToString();

                    HabilitarBotoes();

                    ctlConvenio.Enabled = false;
                    ctlPlano.Enabled = false;
                    ctlSubPlano.Enabled = false;
                    txtCredencial.Enabled = false;
                    txtIdentificacao.Enabled = false;
                    gbxPesquisaPor.Enabled = false;


                    //Se tiver restrição financeira avisar o usuário
                    if (rowComplementoPaciente["RestricaoFinanceira"].ToString() != string.Empty)
                    {
                        bool? restricaoFinanceira = Convert.ToBoolean(rowComplementoPaciente["RestricaoFinanceira"]);
                        if (restricaoFinanceira == true)
                        {
                            MessageBox.Show("Beneficiário com restrição financeira.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    AfterPesquisar();
                }                 
            }
            catch (HacException ex)
            {
                MessageBox.Show(ex.Message, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool PesquisarPorCredencial()
        {
            bool retorno = true;
            FrmCadastroPaciente.ObrigaDigitacaoCredencial = false;

            try
            {
                if(ctlConvenio.DtoConvenio == null || ctlPlano.DtoPlano == null)
                {
                    ctlConvenio.Inicializar();
                    ctlPlano.Inicializar();
                    throw new HacException(">> Campo Convênio Obrigatório.\n>> Campo Plano Obrigatório.");
                }

                if(ctlConvenio.DtoConvenio.CodigoHACPrestador.Value.ToString() == "PA__" || ctlPlano.DtoPlano.CodigoPlanoHAC.Value.ToString() == "PA__" || ctlConvenio.DtoConvenio.CodigoHACPrestador.Value.ToString() == "NP01" )
                {
                    throw new HacException("Pesquisar por prontuário ou nome, data de nascimento e sexo!");
                }

                string credencial;
                if (Paciente.IsFuncionarioACS(ctlConvenio.DtoConvenio.IdtConvenio.Value.ToString()))
                    credencial = string.Format("{0}{1}{2}", txtCodSeq.Text.PadLeft(3, '0'), txtCredencialHac.Text.PadLeft(7, '0'), txtCodSeqBen.Text.PadLeft(2, '0'));
                else
                    credencial = txtCredencial.Text;

                Paciente.ValidarCredencial(credencial, ctlConvenio.DtoConvenio);

                CadastroPacienteDTO dtoPaciente = new CadastroPacienteDTO();
                dtoPaciente.CodigoCredencial.Value = credencial;
                dtoPaciente.IdtConvenio.Value = ctlConvenio.DtoConvenio.IdtConvenio.Value;
                dtoPaciente.IdtPlano.Value = ctlPlano.DtoPlano.IdtPlano.Value;

                dsPaciente = Paciente.PesquisarPorCredencial(dtoPaciente);

                //Encontrou paciente?
                if (dsPaciente != null)
                {
                    //Encontrou mais de um paciente?
                    if (dsPaciente.Tables["CadastroPaciente"].Rows.Count > 1)
                    {
                        //Abrir lista de pacientes para seleção
                        retorno = FrmSelecaoPessoaPaciente.AbrirSelecaoPessoaPaciente(ref dsPaciente);

                        //Clicou no botão Cadastrar Nova Pessoa/Paciente
                        if (retorno && dsPaciente.Tables["CadastroPaciente"].Rows.Count == 0 && dsPaciente.Tables["CadastroPessoa"].Rows.Count == 0)
                        {
                            dsPaciente = Paciente.PreencherDataSetPessoaPaciente(null, dtoPaciente);
                            FrmCadastroPaciente.ObrigaDigitacaoCredencial = true;
                            retorno = FrmCadastroPaciente.AbrirCadastroPaciente(ref dsPaciente, this.CaraterUrgencia, this.isRN, null, false, ref flagConvenioPlanoAlterado, this.isCNS_Obrigatorio);
                            DesabilitaCadastroPaciente = true;
                        }
                        else if(retorno)
                        {
                            DesabilitaCadastroPaciente = false;
                        }

                        if (!DesabilitaCadastroPaciente)
                        {
                            if (retorno)
                            {
                                //Se selecionou um, complemento dados do paciente selecionado
                                Paciente.ComplementarPaciente(ref dsPaciente);
                                //Abro cadastro de paciente para edição                                
                                if (chkRN.Checked)
                                {
                                    FrmCadastroPaciente.IsRN = true;
                                    dsPaciente = Paciente.PreencherDataSetRN(dsPaciente);
                                }
                                else
                                {
                                    FrmCadastroPaciente.IsRN = false;
                                }
                                retorno = FrmCadastroPaciente.AbrirCadastroPaciente(ref dsPaciente, this.CaraterUrgencia, this.isRN, null, false, ref flagConvenioPlanoAlterado, this.isCNS_Obrigatorio);
                            }          
                        }
                    }
                    else
                    {
                        if (!DesabilitaCadastroPaciente)
                        {
                            //Se encontrou um, complemento dados do paciente selecionado
                            Paciente.ComplementarPaciente(ref dsPaciente);
                            //Abro cadastro de paciente para edição                            
                            if (chkRN.Checked)
                            {
                                FrmCadastroPaciente.IsRN = true;
                                dsPaciente = Paciente.PreencherDataSetRN(dsPaciente);
                            }
                            else
                            {
                                FrmCadastroPaciente.IsRN = false;
                            }
                            retorno = FrmCadastroPaciente.AbrirCadastroPaciente(ref dsPaciente, this.CaraterUrgencia, this.isRN, null, false, ref flagConvenioPlanoAlterado, this.isCNS_Obrigatorio);
                        }
                    }
                }
                else
                {
                    //Não encontrou paciente abre cadastro de um novo
                    dsPaciente = Paciente.PreencherDataSetCredencial(dtoPaciente);
                    retorno = FrmCadastroPaciente.AbrirCadastroPaciente(ref dsPaciente, this.CaraterUrgencia, this.isRN, null, false, ref flagConvenioPlanoAlterado, this.isCNS_Obrigatorio);
                }

                //Se tiver retornado o paciente preenchido, apresentar os dados do paciente
                if (retorno)
                {
                    SetaPaciente();
                }                
            }
            catch (HacException ex)
            {
                MessageBox.Show(ex.Message, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                retorno = false;
            }

            return retorno;
        }        

        private bool PesquisarPorProntuario()
        {
            bool retorno = true;
            FrmCadastroPaciente.ObrigaDigitacaoCredencial = false;
            
            try
            {
                //Não permitir pesquisar pelo prontuário 7
                if(Convert.ToInt32(txtProntuario.Text) == 7)
                {
                    txtProntuario.Text = string.Empty;
                    txtProntuario.Focus();
                    throw new HacException("Não é possível pesquisar por esse número de prontuário!");
                }

                CadastroPacienteDTO dtoPaciente = new CadastroPacienteDTO();
                dtoPaciente.Prontuario.Value = txtProntuario.Text;

                dsPaciente = Paciente.PesquisarPorProntuario(dtoPaciente);

                //Encontrou paciente?
                if (dsPaciente != null)
                {
                    //Encontrou mais de um paciente?
                    if (dsPaciente.Tables["CadastroPaciente"].Rows.Count > 0)
                    {
                        //Abrir lista de pacientes para seleção
                        retorno = FrmSelecaoPessoaPaciente.AbrirSelecaoPessoaPaciente(ref dsPaciente);

                        //Clicou no botão Cadastrar Nova Pessoa/Paciente
                        if (retorno && dsPaciente.Tables["CadastroPessoa"].Rows.Count == 0)
                        {
                            dsPaciente = Paciente.PreencherDataSetPessoaPaciente(null, null);
                            FrmCadastroPaciente.ObrigaDigitacaoCredencial = true;
                            retorno = FrmCadastroPaciente.AbrirCadastroPaciente(ref dsPaciente, this.CaraterUrgencia, this.isRN, null, false, ref flagConvenioPlanoAlterado, this.isCNS_Obrigatorio);
                            DesabilitaCadastroPaciente = true;
                        }
                        else if (retorno)
                        {
                            DesabilitaCadastroPaciente = false;
                        }

                        if (!DesabilitaCadastroPaciente)
                        {
                            if (retorno)
                            {
                                //Se selecionou um, complemento dados do paciente selecionado
                                Paciente.ComplementarPaciente(ref dsPaciente);
                                //Abro cadastro de paciente para edição                                
                                retorno = FrmCadastroPaciente.AbrirCadastroPaciente(ref dsPaciente, this.CaraterUrgencia, this.isRN, null, false, ref flagConvenioPlanoAlterado, this.isCNS_Obrigatorio);
                            }
                        }
                    }
                    else
                    {
                        if (!DesabilitaCadastroPaciente)
                        {
                            //Se encontrou um, complemento dados do paciente selecionado
                            Paciente.ComplementarPaciente(ref dsPaciente);
                            //Abro cadastro de paciente para edição
                            FrmCadastroPaciente.ObrigaDigitacaoCredencial = true;
                            retorno = FrmCadastroPaciente.AbrirCadastroPaciente(ref dsPaciente, this.CaraterUrgencia, this.isRN, null, false, ref flagConvenioPlanoAlterado, this.isCNS_Obrigatorio);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Prontuário não encontrado.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    retorno = false;
                }

                //Se tiver retornado o paciente preenchido, apresentar os dados do paciente
                if (retorno)
                {
                    SetaPaciente();
                }
         
            }
            catch (HacException ex)
            {
                MessageBox.Show(ex.Message, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                retorno = false;
            }

            return retorno;

        }

        private bool PesquisarPorNomeDataNascimentoSexo()
        {
            bool retorno = true;
            FrmCadastroPaciente.ObrigaDigitacaoCredencial = false;

            try
            {
                CadastroPessoaDTO dtoPessoa = new CadastroPessoaDTO();
                dtoPessoa.NomePessoa.Value = FrmBase.RemoveAcentosStatic(txtNomePaciente.Text.Trim());
                dtoPessoa.DataNascimento.Value = mskDataNascimento.Text;
                dtoPessoa.Sexo.Value = cboSexo.SelectedValue.ToString();
                

                CadastroPacienteDTO dtoPaciente = null;
                if (ctlPlano.DtoPlano != null)
                {
                    dtoPaciente = new CadastroPacienteDTO();
                    dtoPaciente.IdtConvenio.Value = ctlPlano.DtoPlano.IdtConvenio.Value;
                    dtoPaciente.IdtPlano.Value = ctlPlano.DtoPlano.IdtPlano.Value;
                }

                if (ctlConvenio.DtoConvenio != null && (ctlConvenio.DtoConvenio.CodigoHACPrestador.Value.ToString() == "SD01" || ctlConvenio.DtoConvenio.CodigoHACPrestador.Value.ToString() == "GG05"))
                {
                    string codPlanoHac = string.Empty;
                    if (ctlPlano.DtoPlano != null && ctlPlano.DtoPlano.CodigoPlanoHAC.Value.ToString() != string.Empty)
                        codPlanoHac = ctlPlano.DtoPlano.CodigoPlanoHAC.Value.ToString();

                    if (Paciente.ObterBeneficiarioPorNomeDataNascimentoSexo(dtoPessoa, codPlanoHac) == null)
                   {
                       throw new HacException("Beneficiário não encontrado.\nFavor pesquisar pela credencial ou pela Pesquisa de Beneficiários.");
                   }
                }

                dsPaciente = Paciente.PesquisarPorNomeDataNascimentoSexo(dtoPessoa, ctlPlano.DtoPlano);
                
                if (dsPaciente != null)
                {
                    //Encontrou mais de um paciente?
                    if (dsPaciente.Tables["CadastroPaciente"].Rows.Count > 0)
                    {
                        //Abrir lista de pacientes para seleção                        
                        retorno = FrmSelecaoPessoaPaciente.AbrirSelecaoPessoaPaciente(ref dsPaciente);

                        //Clicou no botão Cadastrar Nova Pessoa/Paciente
                        if (retorno && dsPaciente.Tables["CadastroPessoa"].Rows.Count == 0)
                        {
                            dsPaciente = Paciente.PreencherDataSetPessoaPaciente(dtoPessoa, null);
                            FrmCadastroPaciente.ObrigaDigitacaoCredencial = true;
                            retorno = FrmCadastroPaciente.AbrirCadastroPaciente(ref dsPaciente, this.CaraterUrgencia, this.isRN, null, false, ref flagConvenioPlanoAlterado, this.isCNS_Obrigatorio);
                            DesabilitaCadastroPaciente = true;
                        }
                        else if (retorno)
                        {
                            DesabilitaCadastroPaciente = false;
                        }

                        if (!DesabilitaCadastroPaciente)
                        {
                            if (retorno)
                            {                               
                                if (dsPaciente.Tables["CadastroPaciente"].Rows.Count == 0 && dtoPaciente != null)
                                {
                                    dsPaciente = Paciente.PreencherDataSetPessoaPaciente((CadastroPessoaDTO)dsPaciente.Tables["CadastroPessoa"].Rows[0], dtoPaciente);                         
                                }
                                else
                                    //Se selecionou um, complemento dados do paciente selecionado
                                    Paciente.ComplementarPaciente(ref dsPaciente);
                                
                                //Abro cadastro de paciente para edição                                
                                if (chkRN.Checked)
                                {
                                    FrmCadastroPaciente.IsRN = true;
                                    dsPaciente = Paciente.PreencherDataSetRN(dsPaciente);
                                }
                                else
                                {
                                    FrmCadastroPaciente.IsRN = false;
                                }
                                retorno = FrmCadastroPaciente.AbrirCadastroPaciente(ref dsPaciente, this.CaraterUrgencia, this.isRN, null, false, ref flagConvenioPlanoAlterado, this.isCNS_Obrigatorio);
                            }
                        }
                    }
                    else
                    {
                        if (!DesabilitaCadastroPaciente)
                        {
                            //Se selecionou um, complemento dados do paciente seleciona                            
                            Paciente.ComplementarPaciente(ref dsPaciente);
                            //Abro cadastro de paciente para edição     
                            if (chkRN.Checked)
                            {
                                FrmCadastroPaciente.IsRN = true;
                                dsPaciente = Paciente.PreencherDataSetRN(dsPaciente);
                            }
                            else
                            {
                                FrmCadastroPaciente.IsRN = false;
                            }
                            FrmCadastroPaciente.ObrigaDigitacaoCredencial = true;
                            retorno = FrmCadastroPaciente.AbrirCadastroPaciente(ref dsPaciente, this.CaraterUrgencia, this.isRN, null, false, ref flagConvenioPlanoAlterado, this.isCNS_Obrigatorio);
                        }
                    }
                }
                else
                {
                    //Não encontrou paciente abre cadastro de um novo
                    //dsPaciente = Paciente.PreencherDataSetNomeDataNascimentoSexo(dtoPessoa);
                    FrmCadastroPaciente.ObrigaDigitacaoCredencial = true;
                    dsPaciente = Paciente.PreencherDataSetPessoaPaciente(dtoPessoa, dtoPaciente);
                    retorno = FrmCadastroPaciente.AbrirCadastroPaciente(ref dsPaciente, this.CaraterUrgencia, this.isRN, null, false, ref flagConvenioPlanoAlterado, this.isCNS_Obrigatorio);
                }

                //Se tiver retornado o paciente preenchido, apresentar os dados do paciente
                if (retorno)
                {
                    SetaPaciente();
                }

            }
            catch (HacException ex)
            {
                MessageBox.Show(ex.Message, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                retorno = false;
            }

            return retorno;
        }
         

        private void txtCredencial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //ValidarCredencial(txtCredencial);
                PesquisarPorCredencial();
            }
        }


        private void radPPPaciente_CheckedChanged(object sender, EventArgs e)
        {
            if (radPPPaciente.Checked)
            {
                LimparCampos();
                DesabilitarControles();
                txtNomePaciente.Enabled = true;
                mskDataNascimento.Enabled = true;
                cboSexo.Enabled = true;
                chkRN.Enabled = true;
                //Campos não obrigatorios
                ctlConvenio.Enabled = true;
                ctlPlano.Enabled = true;                
                
                txtNomePaciente.Focus();
            }
        }

        public void LimparCampos()
        {
            txtIdentificacao.Text = string.Empty;
            txtProntuario.Text = string.Empty;
            ctlConvenio.Inicializar();
            ctlPlano.Inicializar();
            ctlSubPlano.Inicializar();
            txtCodSeq.Text = string.Empty;
            txtCredencial.Text = string.Empty;
            txtCredencialHac.Text = string.Empty;
            txtCodSeq.Text = string.Empty;
            txtNomePaciente.Text = string.Empty;
            txtNomeMae.Text = string.Empty;
            mskDataNascimento.Text = string.Empty;
            cboSexo.SelectedValue = "-1";
            txtPadrao.Text = string.Empty;
            txtCronico.Text = string.Empty;
            txtInstitutoGeriatria.Text = string.Empty;
            chkRN.Checked = false;
        }

        private void ctlConvenio_Pesquisar(object sender, EventArgs e)
        {
            if (ctlConvenio.DtoConvenio != null)
            {
                ctlPlano.Inicializar();
                ctlPlano.IdtConvenio = Convert.ToInt32(ctlConvenio.DtoConvenio.IdtConvenio.Value);

                ctlSubPlano.Inicializar();
                ctlSubPlano.IdtConvenio = Convert.ToInt32(ctlConvenio.DtoConvenio.IdtConvenio.Value);
                ConfiguraConvenio();

                ////Os botoes de carencia e exclusao contratual somente para convenio SD01
                //if (ctlConvenio.DtoConvenio.CodigoHACPrestador.Value.ToString() == "SD01")
                //    btnPesquisaCarencia.Enabled = btnPesquisarExclusaoContratual.Enabled = true;
                //else
                //    btnPesquisaCarencia.Enabled = btnPesquisarExclusaoContratual.Enabled = false;

                if (!ctlConvenio.DtoConvenio.CodigoModuloValidador.Value.IsNull &&
                 (ctlConvenio.DtoConvenio.CodigoModuloValidador.Value.ToString().Trim() == "1" ||
                 ctlConvenio.DtoConvenio.CodigoModuloValidador.Value.ToString().Trim() == "2" ||
                 ctlConvenio.DtoConvenio.CodigoModuloValidador.Value.ToString().Trim() == "3"))
                {
                    txtCredencial.AcceptedFormat = AcceptedFormat.Numerico;
                }
                else
                {
                    txtCredencial.AcceptedFormat = AcceptedFormat.AlfaNumerico;
                }

                if (!ctlConvenio.DtoConvenio.MascaraMatricula.Value.IsNull)
                {
                    toolTip1.SetToolTip(btnExibeMascaraCredencial, ctlConvenio.DtoConvenio.MascaraMatricula.Value.ToString());
                    btnExibeMascaraCredencial.Enabled = true;
                }
                else
                {
                    toolTip1.SetToolTip(btnExibeMascaraCredencial, string.Empty);
                    btnExibeMascaraCredencial.Enabled = false;
                }

            }
            
        }

        private void btnPesquisarCadastroPaciente_Click(object sender, EventArgs e)
        {
            int? identificacao = null;

            if (txtIdentificacao.Text.Length > 0)
                identificacao = Convert.ToInt32(txtIdentificacao.Text);
            else
            {
                identificacao = null;
            }

            FrmCadastroPaciente.ObrigaDigitacaoCredencial = false;
            if (FrmCadastroPaciente.AbrirCadastroPaciente(ref dsPaciente, this.CaraterUrgencia, this.isRN, identificacao, _flagModoConsulta, ref flagConvenioPlanoAlterado,this.IsCNS_Obrigatorio))
            {
                SetaPaciente();
            }

            OnBtnPesquisarCadastroPaciente_AfterClick(new CancelEventArgs());
        }

        private void btnPesquisarCoberturaExigencia_Click(object sender, EventArgs e)
        {
            FrmPesquisaCoberturaExigencia.AbrirPesquisaCoberturaExigencia(dtoPaciente);
        }

        private void btnPesquisarExclusaoContratual_Click(object sender, EventArgs e)
        {
            if (dtoPaciente != null)
                FrmPesquisaExclusaoContratual.AbrirPesquisaExclusaoContratual(dtoConvenio, dtoPlano, dtoPaciente.CodigoCredencial.Value);
        }

        private void btnPesquisaCarencia_Click(object sender, EventArgs e)
        {
            if (dtoPaciente != null)
                FrmPesquisaCarencia.AbrirPesquisaCarencia(dtoConvenio, dtoPlano, dtoPaciente.CodigoCredencial.Value);
        }

        private void btnPesquisarBeneficiario_Click(object sender, EventArgs e)
        {
           FrmPesquisaBeneficiario.AbrirPesquisaBeneficiario();
        }

        private void radPPAtendimentos_CheckedChanged(object sender, EventArgs e)
        {
            if (radPPAtendimentos.Checked)
            {
                LimparCampos();
                CancelEventArgs cancelEventArgs = new CancelEventArgs();
                OnPesquisarAtendimentos(cancelEventArgs);
                bool result = !cancelEventArgs.Cancel;
            }
        }

        private void ctlPlano_Pesquisar(object sender, EventArgs e)
        {
            if (((TextBox)ctlConvenio.Controls["txtCodigoConvenio"]).Text == string.Empty)
            {
                ctlPlano.Inicializar();
                MessageBox.Show("Informe o convênio antes de pesquisar o plano.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ctlPlano.DtoPlano != null)
            {
                ctlSubPlano.IdtPlano = Convert.ToInt32(ctlPlano.DtoPlano.IdtPlano.Value);
                ctlSubPlano.IdtLocal = idtLocal;
                ctlSubPlano.IdtUnidade = idtUnidade;
                ConfiguraPlano();   
                if(CtlPlanoLeave != null)
                    CtlPlanoLeave(ctlPlano.DtoPlano, null);   
            }
        }


        private void ConfiguraPlano()
        {
            if (ctlPlano.DtoPlano != null)
            {
                bool isACS = Paciente.IsFuncionarioACS(ctlConvenio.DtoConvenio.IdtConvenio.Value.ToString());

                if (isACS)
                {
                    txtCodSeq.Text = "000";
                    txtCredencialHac.Focus();
                }
                else
                    txtCredencial.Focus();
            }
        }

        private void txtCredencial_Leave(object sender, EventArgs e)
        {
            //ValidarCredencial(txtCredencial);
        }

        private void ctlSubPlano_Pesquisar(object sender, EventArgs e)
        {
            if (ctlSubPlano.DtoSubPlano != null)
            {
                bool isACS = Paciente.IsFuncionarioACS(ctlConvenio.DtoConvenio.IdtConvenio.Value.ToString());

                if (isACS)
                {
                    txtCredencialHac.Focus();
                }
                else
                {
                    txtCredencial.Focus();
                }
            }
        }

        private bool _desabilitaCadastroPaciente;

        public bool DesabilitaCadastroPaciente
        {
            get { return _desabilitaCadastroPaciente; }
            set { _desabilitaCadastroPaciente = value; }
        }

        private void txtCredencialHac_Leave(object sender, EventArgs e)
        {            
                if (txtCodSeqBen.Text == string.Empty)
                {
                    txtCodSeqBen.Text = "00";
                }            
        }

        private void txtCredencialHac_TextChanged(object sender, EventArgs e)
        {

        }

        private void ctlPlano_Leave(object sender, EventArgs e)
        {
            if (ctlPlano.DtoPlano != null && CtlPlanoLeave != null)
            {
                CtlPlanoLeave(ctlPlano.DtoPlano, null);
            }  
        }

        private void ctlPlano_Load(object sender, EventArgs e)
        {

        }

        private void btnExibeMascaraCredencial_Click(object sender, EventArgs e)
        {
            if (!ctlConvenio.DtoConvenio.MascaraMatricula.Value.IsNull)
                toolTip1.SetToolTip(btnExibeMascaraCredencial, ctlConvenio.DtoConvenio.MascaraMatricula.Value.ToString());
            else
                toolTip1.SetToolTip(btnExibeMascaraCredencial, string.Empty);
        }
    }
}
