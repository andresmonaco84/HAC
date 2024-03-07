using System;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using Hac.Windows.Forms.Controls.Code;
using HospitalAnaCosta.SGS.Cadastro.Interface;
using System.Collections.Generic;
using HospitalAnaCosta.SGS.Internacao.Interface;
using HospitalAnaCosta.SGS.Internacao.DTO;
using System.Web.UI.WebControls;


namespace Hac.Windows.Forms.Controls.Forms
{
    public partial class FrmCadastroPaciente : FrmBase
    {
        private CadastroPacienteDTO dtoPaciente = null;
        private CadastroPessoaDTO dtoPessoa = null;
        private ConvenioDTO dtoConvenio = null;
        private PlanoDTO dtoPlano = null;

        public bool isCNS_Obrigatorio;
        public bool IsCNS_Obrigatorio
        {
            get { return isCNS_Obrigatorio; }
            set { isCNS_Obrigatorio = value; }
        }

        #region OBJETOS SERVIÇO
        private ISubPlano _subPlano;
        public ISubPlano SubPlano
        {
            get { return _subPlano != null ? _subPlano : _subPlano = (ISubPlano)CommonServices.GetObject(typeof(ISubPlano)); }
        }
     

        private IAtendimentoInternacao _atendimentoInternacao;
        public IAtendimentoInternacao AtendimentoInternacao
        {
            get { return _atendimentoInternacao != null ? _atendimentoInternacao : _atendimentoInternacao = (IAtendimentoInternacao)CommonServices.GetObject(typeof(IAtendimentoInternacao)); }
        }

        private IMovimentacaoPacienteLeito _movimentacaoPacienteLeito;
        public IMovimentacaoPacienteLeito MovimentacaoPacienteLeito
        {
            get { return _movimentacaoPacienteLeito != null ? _movimentacaoPacienteLeito : _movimentacaoPacienteLeito = (IMovimentacaoPacienteLeito)CommonServices.GetObject(typeof(IMovimentacaoPacienteLeito)); }
        }

        private ICadastroPaciente _paciente;
        private ICadastroPaciente Paciente
        {
            get { return _paciente != null ? _paciente : _paciente = (ICadastroPaciente)CommonServices.GetObject(typeof(ICadastroPaciente)); }
        }

        #endregion

        private bool retorno = false;

        public FrmCadastroPaciente()
        {
            InitializeComponent();
            Titulo = "Cadastro de Paciente";

            dtbTelefone = new TelefoneDataTable();
            dtbEndereco = new EnderecoDataTable();

            InicializarControles();
        }

        private void FrmCadastroPaciente_Load(object sender, EventArgs e)
        {
            ConfigurarControlesSalvar();
            AjustarControlesInicio();

            btnAdicionarTelefone_Click(sender, new EventArgs());
            btnAdicionarEndereco_Click(sender, new EventArgs());

            if (_flagModoConsulta)
            {
                tspCommand.Items["tsBtnSalvar"].Visible = false;
            }
            else
            {
                tspCommand.Items["tsBtnSalvar"].Visible = true;
            }
        }


        private void InicializarControles()
        {
            //AtendimentoDTO dtoAtendimento = new AtendimentoDTO();
            //dtoAtendimento.Idt.Value = codigoIdentificacao;

            CarregarSexo(cboSexo);
            CarregarTipoTelefone(cboTipoTelefone);
            CarregarTipoEndereco(cboTipoEndereco);
            CarregarUF(cboUF);
            CarregarProfissao();
            CarregarNacionalidade();
            CarregarEscolaridade();
            CarregarTipoSanguineo(cboTipoSanguineo);
            CarregarEstadoCivil(cboEstadoCivil);
            CarregarTipoLogradouro();
            CarregarComboGridCidade();

            ctlPlano.Inicializar();
            ctlConvenio.Inicializar();
            ctlSubPlano.Inicializar();

            ConfigurarGridTelefone();
            ConfigurarGridEndereco();

            //HabilitarCamposEndereco(false);
            //HabilitarCamposTelefone(false);
        }


        private void ConfigurarControlesSalvar()
        {
            CarregarGridTelefone();
            CarregarGridEndereco();

            HabilitarCamposTelefone(false);
            LimparCamposTelefone();

            HabilitarCamposEndereco(false);
            LimparCamposEndereco();
        }

        private void AjustarControlesInicio()
        {
            txtEmpresa.Enabled = false;
            txtIdade.Enabled = false;

            //Ajustar MaxLenght
            dtoPaciente = new CadastroPacienteDTO();
            dtoPessoa = new CadastroPessoaDTO();
            TelefoneDTO dtoTelefone = new TelefoneDTO();
            EnderecoDTO dtoEndereco = new EnderecoDTO();

            txtProntuario.MaxLength = 7;
            txtCredencial.MaxLength = dtoPaciente.CodigoCredencial.Size;
            txtNome.MaxLength = dtoPessoa.NomePessoa.Size;
            txtNomeMae.MaxLength = dtoPessoa.NomeMae.Size;
            txtNaturalidade.MaxLength = dtoPessoa.Naturalidade.Size;
            txtNomePai.MaxLength = dtoPessoa.NomePai.Size;
            txtNomeConjuge.MaxLength = dtoPessoa.NomeConjuge.Size;
            txtNomeTitularResponsavel.MaxLength = dtoPaciente.NomeTitular.Size;
            txtRG.MaxLength = dtoPessoa.RG.Size;
            txtOrgaoEmissor.MaxLength = dtoPessoa.OrgaoEmissorRG.Size;
            txtObservacao.MaxLength = dtoPaciente.Observacao.Size;
            //telefone
            txtRamal.MaxLength = 10;
            txtContatoObservacao.MaxLength = dtoTelefone.Contato.Size;
            //endereco
            mskCEP.MaxLength = dtoEndereco.CEP.Size;
            txtLogradouro.MaxLength = dtoEndereco.NomeLogradouro.Size;
            txtNumero.MaxLength = dtoEndereco.DescricaoNumero.Size;
            txtComplemento.MaxLength = dtoEndereco.DescricaoComplemento.Size;
            txtBairro.MaxLength = dtoEndereco.NomeBairro.Size;

            dtoPaciente = null;
            dtoPessoa = null;
            dtoTelefone = null;
            dtoEndereco = null;

            if (dtoConvenio != null)
            {
                ctlConvenio.CarregarConvenio(dtoConvenio);
            }

            if (dtoPlano != null)
                ctlPlano.CarregarPlano(dtoPlano);

            if (FrmCadastroPaciente.Credencial != string.Empty)
                txtCredencial.Text = FrmCadastroPaciente.Credencial;
        }

        private bool _isRecemNascido = false;
        private bool IsRecemNascido
        {
            get { return _isRecemNascido; }
            set { _isRecemNascido = value; }
        }

        private bool _flagModoConsulta = false;
        private bool FlagModoConsulta
        {
            get { return _flagModoConsulta; }
            set { _flagModoConsulta = value; }
        }

        private static bool obrigaDigitacaoCredencial = false;

        public static bool ObrigaDigitacaoCredencial
        {
            get { return obrigaDigitacaoCredencial; }
            set { obrigaDigitacaoCredencial = value; }
        }

        private static string credencial = string.Empty;
        public static string Credencial
        {
            get { return credencial; }
            set { credencial = value; }
        }

        private static bool isRN = false;
        /// <summary>
        /// Flag Recem Nascido - caso seja um cadastro RN, deve recuperar algumas informações dos Pais.
        /// </summary>
        public static bool IsRN
        {
            get { return isRN; }
            set { isRN = value; }
        }


        private bool salvou = false;
        /// <summary>
        /// Flag que indica se a o usuário salvou o paciente com sucesso.
        /// Quando a digitação da credencial é obrigatória, e o usuário não salva o paciente e sai da tela, a busca de paciente retorna false.
        /// </summary>
        public bool Salvou
        {
            get { return salvou; }
            set { salvou = value; }
        }


        private DataSet dsPaciente = null;
        public DataSet DsPaciente
        {
            get { return dsPaciente; }
            set { dsPaciente = value; }
        }

        private string md5Atual = null;

        private int? idtEndereco;

        //Quando True, alguns campos não são obrigatórios
        private bool _caraterUrgencia = false;
        private bool CaraterUrgencia
        {
            get { return _caraterUrgencia; }
            set { _caraterUrgencia = value; }
        }

        private static bool _habilitaCredencial = true;
        public static bool HabilitaCredencial
        {
            get { return _habilitaCredencial; }
            set { _habilitaCredencial = value; }
        }


        [Category("Hac")]
        private CadastroPacienteDTO DtoPaciente
        {
            get { return dtoPaciente; }
        }

        [Category("Hac")]
        private CadastroPessoaDTO DtoPessoa
        {
            get { return dtoPessoa; }
        }

        ~FrmCadastroPaciente()
        {
            try
            {
                SetNullObjects();
            }
            finally
            {
                Dispose();
            }
        }

        protected void SetNullObjects()
        {
            md5Atual = null;
            dtoPessoa = null;
            if (dtbTelefone != null)
            {
                dtbTelefone.Dispose();
            }
            if (dtbEndereco != null)
            {
                dtbEndereco.Dispose();
            }
            dtbTelefone = null;
        }

        #region "Carregar Combos"
        protected void CarregarEscolaridade()
        {
            EscolaridadeDTO dtoEscolaridade = new EscolaridadeDTO();
            EscolaridadeDataTable dtbEscolaridade = Escolaridade.Listar(dtoEscolaridade);
            dtbEscolaridade.DefaultView.Sort = dtoEscolaridade.NomeEscolaridade.FieldName;

            CarregarComboComSelecione(cboEscolaridade, dtbEscolaridade.DefaultView.ToTable(), dtoEscolaridade.CodigoEscolaridade.FieldName, dtoEscolaridade.NomeEscolaridade.FieldName);
        }

        protected void CarregarTipoTelefone(object obj)
        {
            TipoTelefoneEnderecoDTO dtoTipoTelefoneEndereco = new TipoTelefoneEnderecoDTO();
            DataTable dtbTipoTelefoneEndereco = TipoTelefoneEndereco.Listar(dtoTipoTelefoneEndereco);

            DataView dv = dtbTipoTelefoneEndereco.DefaultView;
            dv.RowFilter = "AUX_TTE_CD_TIPO IN ('A','T') AND AUX_TTE_CD_TP_TEL_END NOT IN (9,10,11,14)";
            dtbTipoTelefoneEndereco = dv.ToTable();

            HacComboBox combo = (HacComboBox)obj;
            combo.DisplayMember = dtoTipoTelefoneEndereco.Nome.FieldName;
            combo.ValueMember = dtoTipoTelefoneEndereco.TipoTelefoneEndereco.FieldName;

            dtoTipoTelefoneEndereco = null;
            combo.DataSource = dtbTipoTelefoneEndereco;
            TipoTelefone.DataSource = dtbTipoTelefoneEndereco;
        }

        protected void CarregarTipoEndereco(object obj)
        {
            TipoTelefoneEnderecoDTO dtoTipoTelefoneEndereco = new TipoTelefoneEnderecoDTO();
            DataTable dtbTipoTelefoneEndereco = TipoTelefoneEndereco.Listar(dtoTipoTelefoneEndereco);

            DataView dv = dtbTipoTelefoneEndereco.DefaultView;
            dv.RowFilter = "AUX_TTE_CD_TIPO IN ('A','E') AND AUX_TTE_CD_TP_TEL_END NOT IN (12)";
            dtbTipoTelefoneEndereco = dv.ToTable();

            HacComboBox combo = (HacComboBox)obj;
            combo.DisplayMember = dtoTipoTelefoneEndereco.Nome.FieldName;
            combo.ValueMember = dtoTipoTelefoneEndereco.TipoTelefoneEndereco.FieldName;

            dtoTipoTelefoneEndereco = null;
            combo.DataSource = dtbTipoTelefoneEndereco;
            TipoEndereco.DataSource = dtbTipoTelefoneEndereco;
        }

        protected void CarregarUF(object obj)
        {
            UFDTO dtoUF = new UFDTO();
            UFDataTable dtbUF = base.UF.Listar(dtoUF);

            HacComboBox combo = (HacComboBox)obj;
            combo.DisplayMember = dtoUF.Descricao.FieldName;
            combo.ValueMember = dtoUF.Codigo.FieldName;

            dtoUF = null;
            combo.DataSource = dtbUF;
        }

        protected void CarregarTipoLogradouro()
        {
            TipoLogradouroDTO dto = new TipoLogradouroDTO();
            TipoLogradouroDataTable dtbTipoLogradouro = base.TipoLogradouro.Listar(dto);

            cboTipoLogradouro.DisplayMember = dto.Descricao.FieldName;
            cboTipoLogradouro.ValueMember = dto.Codigo.FieldName;

            dto = null;
            cboTipoLogradouro.DataSource = dtbTipoLogradouro;
            TipoLogradouro.DataSource = dtbTipoLogradouro;
        }

        private void CarregarComboGridCidade()
        {
            MunicipioDTO dtoMunicipio = new MunicipioDTO();
            MunicipioDataTable dtbMunicipio = Municipio.Listar(dtoMunicipio);

            Cidade.DisplayMember = dtoMunicipio.NomeMunicipio.FieldName;
            Cidade.ValueMember = dtoMunicipio.CodigoIBGE.FieldName;

            dtoMunicipio = null;
            Cidade.DataSource = dtbMunicipio;
        }

        protected void CarregarProfissao()
        {
            ProfissaoDTO dtoProfissao = new ProfissaoDTO();
            ProfissaoDataTable dtbProfissao = Profissao.Listar(dtoProfissao);
            dtbProfissao.DefaultView.Sort = dtoProfissao.Descricao.FieldName;

            CarregarComboComSelecione(cboProfissao, dtbProfissao.DefaultView.ToTable(), dtoProfissao.Codigo.FieldName, dtoProfissao.Descricao.FieldName);
        }

        private void CarregarCidade()
        {
            MunicipioDTO dtoMunicipio = new MunicipioDTO();
            dtoMunicipio.SiglaUF.Value = Convert.ToString(cboUF.SelectedValue);
            MunicipioDataTable dtbMunicipio = Municipio.Listar(dtoMunicipio);

            CarregarComboComSelecione(cboCidade, dtbMunicipio.DefaultView.ToTable(), dtoMunicipio.CodigoIBGE.FieldName, dtoMunicipio.NomeMunicipio.FieldName);
        }

        private void CarregarNacionalidade()
        {
            NacionalidadeDTO dtoNacionalidade = new NacionalidadeDTO();
            NacionalidadeDataTable dtbNacionalidade = Nacionalidade.Listar(dtoNacionalidade);
            dtbNacionalidade.DefaultView.Sort = dtoNacionalidade.NomeNacionalidade.FieldName;

            CarregarComboComSelecione(cboNacionalidade, dtbNacionalidade.DefaultView.ToTable(), dtoNacionalidade.CodigoNacionalidade.FieldName, dtoNacionalidade.NomeNacionalidade.FieldName);
        }
        #endregion

        /// <summary>
        /// AbrirCadastroPaciente
        /// </summary>
        /// <param name="dsPaciente"></param>
        /// <param name="caraterUrgencia">Quando True, alguns campos não são obrigatórios</param>
        /// <returns></returns>
        public static bool AbrirCadastroPaciente(ref DataSet dsPaciente, bool caraterUrgencia, bool isRecemNascido, int? codigoIdentificacao, Boolean flagModoConsulta, ref bool flagConvenioPlanoAlterado, bool _isCNS_Obrigatorio)
        {
            FrmCadastroPaciente frmCadPaciente = new FrmCadastroPaciente();
            frmCadPaciente.IsRecemNascido = isRecemNascido;
            frmCadPaciente.FlagModoConsulta = flagModoConsulta;
            frmCadPaciente.CodigoIdentificacao = codigoIdentificacao;
            frmCadPaciente.dsPaciente = dsPaciente;
            frmCadPaciente.CarregarCadastroPaciente();
            frmCadPaciente.CaraterUrgencia = caraterUrgencia;
            frmCadPaciente.IsCNS_Obrigatorio = _isCNS_Obrigatorio;
            frmCadPaciente.ShowDialog();
            dsPaciente = frmCadPaciente.dsPaciente;
            flagConvenioPlanoAlterado = frmCadPaciente.flagConvenioPlanoAlterado;
            return frmCadPaciente.retorno;
        }

        private void CarregarCadastroPaciente()
        {
            if (dsPaciente != null)
            {
                MovimentacaoPacienteLeitoDTO dtoMovimentacaoPacienteLeito = new MovimentacaoPacienteLeitoDTO();
                MovimentacaoPacienteLeitoDataTable dtbMovimentacaoPacienteLeito = new MovimentacaoPacienteLeitoDataTable();

                AtendimentoDTO dtoAtendimento = new AtendimentoDTO();
                dtoAtendimento.Idt.Value = codigoIdentificacao;
                dtoAtendimento = Atendimento.Pesquisar(dtoAtendimento);

                bool isACS = false;

                txtEmpresa.Enabled = false;
                txtProntuario.Enabled = false;

                if (dsPaciente.Tables["CadastroPaciente"].Rows.Count > 0)
                {
                    //txtCredencial.Enabled = HabilitaCredencial;

                    dtoPaciente = (CadastroPacienteDTO)dsPaciente.Tables["CadastroPaciente"].Rows[0];
                    isACS = Paciente.IsFuncionarioACS(dtoPaciente.IdtConvenio.Value.ToString());

                    #region Carregar Paciente

                    //Se existir paciente e for ACS, não obriga digitação de credencial.
                    if (isACS)
                    {
                        FrmCadastroPaciente.ObrigaDigitacaoCredencial = false;
                    }

                    if (!FrmCadastroPaciente.ObrigaDigitacaoCredencial)
                    {
                        //txtCredencial.Enabled = false;
                        txtCredencial.Text = dtoPaciente.CodigoCredencial.Value;
                    }
                    else
                    {
                        //txtCredencial.Enabled = true;
                        txtCredencial.Text = string.Empty;
                    }


                    if (!this.IsRecemNascido)
                    {
                        if (dtoAtendimento != null)
                        {
                            dtoMovimentacaoPacienteLeito = new MovimentacaoPacienteLeitoDTO();
                            dtoMovimentacaoPacienteLeito.IdtAtendimento.Value = dtoAtendimento.Idt.Value;
                            dtbMovimentacaoPacienteLeito = MovimentacaoPacienteLeito.Listar(dtoMovimentacaoPacienteLeito);
                            if (dtbMovimentacaoPacienteLeito.Rows.Count > 0 ||
                                !AtendimentoInternacao.ValidarContaFaturada(dtoAtendimento, false) ||
                                Paciente.IsPacienteInternadoAlta(Convert.ToDecimal(dtoAtendimento.Idt.Value)))
                            {
                                txtCredencial.Enabled = false;
                            }
                            else
                            {
                                txtCredencial.Enabled = true;
                            }
                        }
                        else
                        {
                            txtCredencial.Enabled = true;
                        }
                    }
                    else
                    {
                        txtCredencial.Enabled = true;
                    }


                    if (!dtoPaciente.IdtConvenio.Value.IsNull)
                    {
                        //ConvenioDTO 
                        dtoConvenio = new ConvenioDTO();
                        dtoConvenio.IdtConvenio.Value = dtoPaciente.IdtConvenio.Value;
                        ctlConvenio.CarregarConvenio(dtoConvenio);

                        if (dtoAtendimento != null)
                        {
                            dtoMovimentacaoPacienteLeito = new MovimentacaoPacienteLeitoDTO();
                            dtoMovimentacaoPacienteLeito.IdtAtendimento.Value = dtoAtendimento.Idt.Value;
                            dtoMovimentacaoPacienteLeito.StatusTransferencia.Value = "A";
                            dtbMovimentacaoPacienteLeito = MovimentacaoPacienteLeito.Listar(dtoMovimentacaoPacienteLeito);
                            if (dtbMovimentacaoPacienteLeito.Rows.Count > 0 ||
                                !AtendimentoInternacao.ValidarContaFaturada(dtoAtendimento, false) ||
                                Paciente.IsPacienteInternadoAlta(Convert.ToDecimal(dtoAtendimento.Idt.Value)))
                            {
                                ctlConvenio.Enabled = false;
                            }
                            else
                            {
                                ctlConvenio.Enabled = true;
                            }
                        }
                        else
                        {
                            ctlConvenio.Enabled = true;
                        }
                    }

                    if (!dtoPaciente.IdtPlano.Value.IsNull)
                    {
                        PlanoDTO dtoPlano = new PlanoDTO();
                        dtoPlano.IdtPlano.Value = dtoPaciente.IdtPlano.Value;
                        ctlPlano.CarregarPlano(dtoPlano);

                        if (dtoAtendimento != null)
                        {
                            dtoMovimentacaoPacienteLeito = new MovimentacaoPacienteLeitoDTO();
                            dtoMovimentacaoPacienteLeito.IdtAtendimento.Value = dtoAtendimento.Idt.Value;
                            dtoMovimentacaoPacienteLeito.StatusTransferencia.Value = "A";
                            dtbMovimentacaoPacienteLeito = MovimentacaoPacienteLeito.Listar(dtoMovimentacaoPacienteLeito);
                            if (dtbMovimentacaoPacienteLeito.Rows.Count > 0 ||
                                !AtendimentoInternacao.ValidarContaFaturada(dtoAtendimento, false) ||
                                Paciente.IsPacienteInternadoAlta(Convert.ToDecimal(dtoAtendimento.Idt.Value)))
                            {
                                ctlPlano.Enabled = false;
                            }
                            else
                            {
                                ctlPlano.Enabled = true;
                            }
                        }
                        else
                        {
                            ctlPlano.Enabled = true;
                        }
                    }

                    if (!dtoPaciente.CodigoSubPlano.Value.IsNull)
                    {
                        SubPlanoDTO dtoSubPlano = new SubPlanoDTO();
                        dtoSubPlano.Codigo.Value = dtoPaciente.CodigoSubPlano.Value.ToString();
                        ctlSubPlano.CarregarSubPlano(dtoSubPlano);
                    }

                    //txtCartaoNacionalSaude.Text = dtoPaciente.CodigoCNS.Value;
                    txtObservacao.Text = dtoPaciente.Observacao.Value;
                    txtProntuario.Text = dtoPaciente.Prontuario.Value;
                    txtNomeTitularResponsavel.Text = dtoPaciente.NomeTitular.Value;

                    if (!dtoPaciente.DataValidadeCredencial.Value.IsNull)
                        mskValidadeCredencial.Text = Convert.ToDateTime(dtoPaciente.DataValidadeCredencial.Value).ToString("dd/MM/yyyy");

                    #endregion
                }

                if (dsPaciente.Tables["CadastroPessoa"].Rows.Count > 0)
                {
                    dtoPessoa = (CadastroPessoaDTO)dsPaciente.Tables["CadastroPessoa"].Rows[0];

                    #region Carregar Pessoa

                    CarregarPessoa(dtoPessoa);

                    #endregion

                    if (dsPaciente.Tables["dtbEndereco"] != null)
                    {

                        dtbEndereco = new EnderecoDataTable();
                        foreach (DataRow row in dsPaciente.Tables["dtbEndereco"].Rows)
                        {
                            EnderecoDTO dtoEndereco = (EnderecoDTO)row;
                            dtbEndereco.Add(dtoEndereco);
                        }

                        CarregarGridEndereco();
                        gridEndereco.ClearSelection();
                    }

                    if (dsPaciente.Tables["dtbTelefone"] != null)
                    {

                        foreach (DataRow row in dsPaciente.Tables["dtbTelefone"].Rows)
                        {
                            TelefoneDTO dtoTelefone = (TelefoneDTO)row;
                            dtbTelefone.Add(dtoTelefone);
                        }
                        CarregarGridTelefone();
                        gridTelefone.ClearSelection();
                    }

                    //Carregar prontuário
                    if (dsPaciente.Tables["Prontuario"] != null)
                    {
                        txtProntuario.Text = dsPaciente.Tables["Prontuario"].Rows[0]["Prontuario"].ToString();
                    }
                    else
                    {
                        if ((dsPaciente.Tables["CadastroPaciente"] == null || dsPaciente.Tables["CadastroPaciente"].Rows[0][CadastroPacienteDTO.FieldNames.IdtPaciente].ToString() == string.Empty)
                            && dsPaciente.Tables["CadastroPessoa"] != null && dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.IdtPessoa].ToString() != string.Empty)
                            txtProntuario.Text = FrmSelecaoProntuario.AbrirSelecaoProntuario(Convert.ToDecimal(dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.IdtPessoa].ToString()));
                    }
                }
            }
        }

        private void CarregarPessoa(CadastroPessoaDTO dtoPessoa)
        {
            if (dtoPessoa != null)
            {

                //md5Atual = Paciente.ConverterTextoParaMD5(string.Format("{0}{1}{2}", dtoPessoa.NomePessoa.Value, Convert.ToDateTime(dtoPessoa.DataNascimento.Value).ToString("ddMMyyyy"), dtoPessoa.Sexo.Value));

                txtNome.Text = dtoPessoa.NomePessoa.Value;
                txtNomePai.Text = dtoPessoa.NomePai.Value;
                txtNomeMae.Text = dtoPessoa.NomeMae.Value;
                txtNomeConjuge.Text = dtoPessoa.NomeConjuge.Value;
                txtRG.Text = dtoPessoa.RG.Value;
                txtOrgaoEmissor.Text = dtoPessoa.OrgaoEmissorRG.Value;

                if (!dtoPessoa.Sexo.Value.IsNull)
                    cboSexo.SelectedValue = dtoPessoa.Sexo.Value.ToString();

                chkDoador.Checked = dtoPessoa.FlDoadorOrgaosOk.Value == "S" ? true : false;
                txtNaturalidade.Text = dtoPessoa.Naturalidade.Value;

                if (!dtoPessoa.DataNascimento.Value.IsNull)
                    txtIdade.Text = Funcoes.CalcularIdade(Convert.ToDateTime(dtoPessoa.DataNascimento.Value)).ToString();

                if (!dtoPessoa.TipoSanguineo.Value.IsNull)
                    cboTipoSanguineo.SelectedValue = dtoPessoa.TipoSanguineo.Value.ToString();

                if (!dtoPessoa.DataNascimento.Value.IsNull)
                    mskDataNascimento.Text = Convert.ToDateTime(dtoPessoa.DataNascimento.Value).ToString("dd/MM/yyyy");

                if (!dtoPessoa.CNPJCPF.Value.IsNull && dtoPessoa.CNPJCPF.Value > 0)
                    mskCPF.Text = dtoPessoa.CNPJCPF.Value.ToString().PadLeft(11, '0');

                if (!dtoPessoa.CodigoProfissao.Value.IsNull)
                    cboProfissao.SelectedValue = dtoPessoa.CodigoProfissao.Value.ToString();

                if (!dtoPessoa.CodigoNacionalidade.Value.IsNull)
                    cboNacionalidade.SelectedValue = dtoPessoa.CodigoNacionalidade.Value.ToString();

                if (!dtoPessoa.CodigoEscolaridade.Value.IsNull)
                    cboEscolaridade.SelectedValue = dtoPessoa.CodigoEscolaridade.Value.ToString();

                if (!dtoPessoa.DataExpedicaoRG.Value.IsNull)
                    mskDataExpedicao.Text = Convert.ToDateTime(dtoPessoa.DataExpedicaoRG.Value).ToString("dd/MM/yyyy");

                if (!dtoPessoa.EstadoCivil.Value.IsNull)
                    cboEstadoCivil.SelectedValue = dtoPessoa.EstadoCivil.Value.ToString();

                if (!dtoPessoa.CodigoCartaoNacionalSaudeSUS.Value.IsNull)
                    txtCartaoNacionalSaude.Text = dtoPessoa.CodigoCartaoNacionalSaudeSUS.Value.ToString();

                if (!dtoPessoa.IdtPessoa.Value.IsNull)
                {
                    PesquisarEnderecos(dtoPessoa);
                    PesquisarTelefones(dtoPessoa);
                }
            }

        }

        private void cboUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarCidade();
        }

        private void mskDataNascimento_Leave(object sender, EventArgs e)
        {
            if (mskDataNascimento.Text != string.Empty)
                txtIdade.Text = Funcoes.CalcularIdade(Convert.ToDateTime(mskDataNascimento.Text)).ToString();

            verificarMD5(sender, e);
        }

        private bool Salvar()
        {

            bool flagAltera = false; //alterar convenio, plano ou credencial
            bool flagNovoPaciente = false;

            try
            {
                if (Convert.ToDateTime(mskDataNascimento.Text) < Convert.ToDateTime("1/1/1900"))
                {
                    MessageBox.Show("Data de Nascimento inválida.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mskDataNascimento.Focus();

                }
                
                try   ////  VALIDAR C.N.S.
                {
                    Int64 CNS = 0;
                    if (txtCartaoNacionalSaude.Text.Trim().Length != 0)
                        CNS = Convert.ToInt64(txtCartaoNacionalSaude.Text.Trim());

                    if (txtCartaoNacionalSaude.Text.Trim().Length > 18)
                        throw new Exception("");
                }
                catch (Exception)
                {
                    MessageBox.Show("Cartão Nacional de Saúde inválido. Permitido somente 18 números.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //validar plano e credencial informados
                if (_isRecemNascido || codigoIdentificacao != null)
                {
                    if (ctlConvenio.DtoConvenio.CodigoHACPrestador.Value == "SD01" ||
                        ctlConvenio.DtoConvenio.CodigoHACPrestador.Value == "GG05")
                    {
                        if (txtCredencial.Text.Length < 12)
                        {
                            MessageBox.Show("Credencial Inválida!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCredencial.Focus();
                            return false;
                        }
                        BeneficiarioDTO dtoBeneficiario = new BeneficiarioDTO();

                        dtoBeneficiario.CodigoLoja.Value = txtCredencial.Text.Substring(0, 3);
                        dtoBeneficiario.CodigoMatricula.Value = txtCredencial.Text.ToString().Substring(3, 7);
                        dtoBeneficiario.CodigoSeqMatricula.Value = txtCredencial.Text.ToString().Substring(10, 2);
                        dtoBeneficiario.CodigoEmpresa.Value = ctlPlano.DtoPlano.CodigoPlanoHAC.Value;

                        BeneficiarioDataTable dtbBeneficiario = Beneficiario.Listar(dtoBeneficiario);


                        if (dtbBeneficiario.Rows.Count <= 0)
                        {
                            MessageBox.Show("Beneficiário Inexistente!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                        else
                        {
                            dtoBeneficiario = dtbBeneficiario.TypedRow(0);

                            dtoBeneficiario.CodigoEmpresa.Value = ctlPlano.DtoPlano.CodigoPlanoHAC.Value;

                            Beneficiario.ValidarBeneficiarioACS(ref dtoBeneficiario);

                            //pesquisar o beneficiário que foi transferido pelo convenio informado
                            //pois na procedure está feito um decode
                            dtoBeneficiario.CodigoEmpresa.Value = ctlPlano.DtoPlano.CodigoPlanoHAC.Value;

                            dtoBeneficiario = _paciente.VerificarBeneficiarioTransferido(dtoBeneficiario);

                            PlanoDTO dtoPlano = new PlanoDTO();
                            dtoPlano.IdtConvenio.Value = ctlConvenio.DtoConvenio.IdtConvenio.Value;
                            dtoPlano.CodigoPlanoHAC.Value = dtoBeneficiario.CodigoEmpresa.Value;

                            PlanoDataTable dtbPlano = Plano.Listar(dtoPlano);
                            PlanoDTO _dtoPlano = dtbPlano.TypedRow(0);

                            ctlPlano.CarregarPlano(_dtoPlano);

                            txtCredencial.Text = string.Format("{0}{1}{2}",
                                                               dtoBeneficiario.CodigoLoja.Value.ToString().PadLeft(3, '0'),
                                                               dtoBeneficiario.CodigoMatricula.Value.ToString().PadLeft(7, '0'),
                                                               dtoBeneficiario.CodigoSeqMatricula.Value.ToString().PadLeft(2, '0'));
                        }
                    }
                }
            }
            catch (HacException ex)
            {
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (!ctlSubPlano.SubPlanoDigitadoCarregado)
            {
                MessageBox.Show("SubPlano não encontrado!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }


            if (!ValidarDataAtual())
            {
                return false;
            }

            bool retorno = true;

            StringBuilder busMessage = new StringBuilder();
            if (dtbTelefone.DefaultView.Count == 0)
            {
                busMessage.Append("Favor cadastrar pelo menos um telefone.");
            }
            if (dtbEndereco.DefaultView.Count == 0)
            {
                if (busMessage.Length > 0) busMessage.Append("\n");
                busMessage.Append("Favor cadastrar pelo menos um endereço.");
            }
            if (FrmCadastroPaciente.IsRN)
            {
                //Verifica quantidade de dias do RN
                TimeSpan ts = DateTime.Now - Convert.ToDateTime(mskDataNascimento.Text);
                if (ts.Days > 60)
                {
                    if (busMessage.Length > 0) busMessage.Append("\n");
                    busMessage.Append("Não é permitido internar o RN com idade maior que 2 meses com os dados do titular.\nFavor informar a credencial correta.");
                }
            }
            if (mskDataExpedicao.Text != string.Empty && Convert.ToDateTime(mskDataExpedicao.Text) > DateTime.Now)
            {
                if (busMessage.Length > 0) busMessage.Append("\n");
                busMessage.Append("Data de Expedição não pode ser maior que a data atual.");
                mskDataExpedicao.Focus();
            }
            if (Convert.ToDateTime(mskDataNascimento.Text) > DateTimeServ.Date)
            {
                if (busMessage.Length > 0) busMessage.Append("\n");
                busMessage.Append("Data de nascimento não pode ser maior que a data atual.");
                mskDataNascimento.Focus();
            }
            if (ctlSubPlano.DtoSubPlano != null)
            {
                if (!Paciente.ValidarCredencialSubPlano(txtCredencial.Text,
                                                        Convert.ToInt32(ctlConvenio.DtoConvenio.IdtConvenio.Value),
                                                        ctlSubPlano.DtoSubPlano.Codigo.Value))
                {
                    if (busMessage.Length > 0) busMessage.Append("\n");
                    busMessage.Append("Sub-plano inválido, Favor verificar o sub-plano e ou credencial informados.");
                    txtCredencial.Focus();
                }
            }
            if (!ctlConvenio.DtoConvenio.ExigeValidadeCredencial.Value.IsNull)
            {
                if (ctlConvenio.DtoConvenio.ExigeValidadeCredencial.Value == "S")
                {
                    if (mskValidadeCredencial.Text.Length == 0)
                    {
                        busMessage.Append("Data de validade da credencial é obrigatória para este Convênio.");
                        mskValidadeCredencial.Focus();
                    }
                }
            }
            if (busMessage.Length > 0)
            {
                MessageBox.Show(busMessage.ToString(), Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {

                try
                {
                    #region Pessoa

                    dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.NomePessoa] = RemoveAcentos(txtNome.Text.Trim());
                    dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.NomeMae] = RemoveAcentos(txtNomeMae.Text.Trim());
                    dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.NomePai] = RemoveAcentos(txtNomePai.Text.Trim());
                    dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.NomeConjuge] = RemoveAcentos(txtNomeConjuge.Text.Trim());
                    dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.JuridicaOk] = "N";
                    dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.OrgaoEmissorRG] = txtOrgaoEmissor.Text.Trim();
                    dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.RG] = txtRG.Text;

                    if (mskCPF.Text != string.Empty)
                        dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.CNPJCPF] = mskCPF.Text.Replace(".", "").Replace("-", "");
                    else
                        dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.CNPJCPF] = DBNull.Value;

                    if (cboSexo.SelectedValue.ToString() != "-1")
                        dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.Sexo] = cboSexo.SelectedValue.ToString();
                    else
                        dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.Sexo] = DBNull.Value;


                    dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.DataNascimento] = Convert.ToDateTime(mskDataNascimento.Text);

                    if (cboProfissao.SelectedIndex != -1 && cboProfissao.SelectedValue.ToString() != "-1")
                        dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.CodigoProfissao] = Convert.ToDecimal(cboProfissao.SelectedValue);
                    else
                        dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.CodigoProfissao] = DBNull.Value;

                    if (cboNacionalidade.SelectedIndex != -1 && cboNacionalidade.SelectedValue.ToString() != "-1")
                        dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.CodigoNacionalidade] = Convert.ToDecimal(cboNacionalidade.SelectedValue);
                    else
                        dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.CodigoNacionalidade] = DBNull.Value;

                    dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.FlDoadorOrgaosOk] = chkDoador.Checked ? "S" : "N";
                    dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.Naturalidade] = txtNaturalidade.Text;

                    if (mskDataExpedicao.Text.Length > 0)
                        dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.DataExpedicaoRG] = Convert.ToDateTime(mskDataExpedicao.Text);
                    else
                        dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.DataExpedicaoRG] = DBNull.Value;

                    if (cboEstadoCivil.SelectedIndex != -1 && cboEstadoCivil.SelectedValue.ToString() != "-1")
                        dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.EstadoCivil] = cboEstadoCivil.SelectedValue.ToString();
                    else
                        dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.EstadoCivil] = DBNull.Value;

                    if (cboEscolaridade.SelectedIndex != -1 && cboEscolaridade.SelectedValue.ToString() != "-1")
                        dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.CodigoEscolaridade] = Convert.ToDecimal(cboEscolaridade.SelectedValue);
                    else
                        dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.CodigoEscolaridade] = DBNull.Value;

                    if (cboTipoSanguineo.SelectedIndex != -1 && cboTipoSanguineo.SelectedValue.ToString() != "-1")
                        dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.TipoSanguineo] = cboTipoSanguineo.SelectedValue.ToString();
                    else
                        dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.TipoSanguineo] = DBNull.Value;

                    dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.CodigoCartaoNacionalSaudeSUS] = txtCartaoNacionalSaude.Text.Trim();
                    
                    #endregion

                    #region Paciente

                    if (!Paciente.IsFuncionarioACS(ctlConvenio.DtoConvenio.IdtConvenio.Value))
                    {
                        Paciente.ValidarCredencial(txtCredencial.Text, ctlConvenio.DtoConvenio);
                    }

                    //Se for um novo paciente
                    if ((dsPaciente.Tables["CadastroPaciente"].Rows.Count == 0) ||
                        (dsPaciente.Tables["CadastroPaciente"].Rows[0]["CAD_PAC_ID_PACIENTE"] == DBNull.Value))
                    {
                        flagNovoPaciente = true;

                        if (dsPaciente.Tables["Convenio"] == null)
                            dsPaciente = Paciente.AdicionarConvenioPlano(dsPaciente);

                        DataRow drConvenio = dsPaciente.Tables["Convenio"].NewRow();
                        if (dsPaciente.Tables["CadastroPaciente"].Rows.Count == 0)
                        {
                            drConvenio[ConvenioDTO.FieldNames.IdtConvenio] = ctlConvenio.DtoConvenio.IdtConvenio.Value;
                            dsPaciente.Tables["Convenio"].Rows.Add(drConvenio);
                        }
                        else if (ctlConvenio.DtoConvenio.IdtConvenio.Value != dsPaciente.Tables["CadastroPaciente"].Rows[0]["CAD_CNV_ID_CONVENIO"].ToString())
                        {
                            drConvenio[ConvenioDTO.FieldNames.IdtConvenio] = ctlConvenio.DtoConvenio.IdtConvenio.Value;
                            dsPaciente.Tables["Convenio"].Rows.Add(drConvenio);
                        }

                        DataRow drPlano = dsPaciente.Tables["Plano"].NewRow();
                        if (dsPaciente.Tables["CadastroPaciente"].Rows.Count == 0)
                        {
                            drPlano[PlanoDTO.FieldNames.IdtPlano] = ctlPlano.DtoPlano.IdtPlano.Value;
                            dsPaciente.Tables["Plano"].Rows.Add(drPlano);
                        }
                        else if (ctlPlano.DtoPlano.IdtPlano.Value != dsPaciente.Tables["CadastroPaciente"].Rows[0]["CAD_PLA_ID_PLANO"].ToString())
                        {
                            drPlano[PlanoDTO.FieldNames.IdtPlano] = ctlPlano.DtoPlano.IdtPlano.Value;
                            dsPaciente.Tables["Plano"].Rows.Add(drPlano);
                        }

                        dsPaciente.Tables["CadastroPaciente"].Columns[CadastroPacienteDTO.FieldNames.IdtPaciente].AllowDBNull = true;
                        dsPaciente.Tables["CadastroPaciente"].PrimaryKey = null;
                        dsPaciente.Tables["CadastroPaciente"].Rows.Add(dsPaciente.Tables["CadastroPaciente"].NewRow());

                    }

                    if (flagNovoPaciente == false)
                    {
                        if ((dsPaciente.Tables["CadastroPaciente"].Rows[0]["CAD_CNV_ID_CONVENIO"].ToString() != ctlConvenio.DtoConvenio.IdtConvenio.Value) ||
                            (dsPaciente.Tables["CadastroPaciente"].Rows[0]["CAD_PLA_ID_PLANO"].ToString() != ctlPlano.DtoPlano.IdtPlano.Value) ||
                            (dsPaciente.Tables["CadastroPaciente"].Rows[0]["CAD_PAC_CD_CREDENCIAL"].ToString() != txtCredencial.Text.ToString()) ||
                            (dsPaciente.Tables["CadastroPaciente"].Rows[0]["CAD_PAC_ID_PACIENTE"] == DBNull.Value))
                        {
                            flagAltera = true;

                            if ((dsPaciente.Tables["CadastroPaciente"].Rows[0]["CAD_CNV_ID_CONVENIO"].ToString() != ctlConvenio.DtoConvenio.IdtConvenio.Value) ||
                                (dsPaciente.Tables["CadastroPaciente"].Rows[0]["CAD_PLA_ID_PLANO"].ToString() != ctlPlano.DtoPlano.IdtPlano.Value))
                            {
                                //fazendo
                                flagConvenioPlanoAlterado = true;
                            }

                            //ver
                            if (dsPaciente.Tables["Convenio"] == null)
                                dsPaciente = Paciente.AdicionarConvenioPlano(dsPaciente);

                            Boolean flagConvenioExiste = false;
                            foreach (DataRow row in dsPaciente.Tables["Convenio"].Rows)
                            {
                                if ((row[CadastroPacienteDTO.FieldNames.IdtConvenio].ToString()) == ctlConvenio.DtoConvenio.IdtConvenio.Value.ToString())
                                {
                                    flagConvenioExiste = true;
                                    break;
                                }
                            }
                            if (!flagConvenioExiste)
                            //if (dsPaciente.Tables["Convenio"].Rows[0]["CAD_CNV_ID_CONVENIO"].ToString() != ctlConvenio.DtoConvenio.IdtConvenio.Value)
                            {
                                DataRow drConvenio = dsPaciente.Tables["Convenio"].NewRow();

                                drConvenio[ConvenioDTO.FieldNames.IdtConvenio] = ctlConvenio.DtoConvenio.IdtConvenio.Value;
                                dsPaciente.Tables["Convenio"].Rows.Add(drConvenio);
                            }

                            Boolean flagPlanoExiste = false;
                            foreach (DataRow row in dsPaciente.Tables["Plano"].Rows)
                            {
                                if ((row[CadastroPacienteDTO.FieldNames.IdtPlano].ToString()) == ctlPlano.DtoPlano.IdtPlano.Value.ToString())
                                {
                                    flagPlanoExiste = true;
                                    break;
                                }
                            }
                            if (!flagPlanoExiste)
                            //if (dsPaciente.Tables["Plano"].Rows[0][CadastroPacienteDTO.FieldNames.IdtPlano].ToString() != ctlPlano.DtoPlano.IdtPlano.Value)
                            {
                                DataRow drPlano = dsPaciente.Tables["Plano"].NewRow();

                                drPlano[PlanoDTO.FieldNames.IdtPlano] = ctlPlano.DtoPlano.IdtPlano.Value;
                                dsPaciente.Tables["Plano"].Rows.Add(drPlano);
                            }
                        }
                    }

                    dsPaciente.Tables["CadastroPaciente"].Rows[0][CadastroPacienteDTO.FieldNames.IdtConvenio] = ctlConvenio.DtoConvenio.IdtConvenio.Value;
                    dsPaciente.Tables["CadastroPaciente"].Rows[0][CadastroPacienteDTO.FieldNames.IdtPlano] = ctlPlano.DtoPlano.IdtPlano.Value;

                    dsPaciente.Tables["CadastroPaciente"].Rows[0][CadastroPacienteDTO.FieldNames.NomeTitular] = RemoveAcentos(txtNomeTitularResponsavel.Text.Trim());
                    dsPaciente.Tables["CadastroPaciente"].Rows[0][CadastroPacienteDTO.FieldNames.Observacao] = txtObservacao.Text;
                    dsPaciente.Tables["CadastroPaciente"].Rows[0][CadastroPacienteDTO.FieldNames.CodigoCredencial] = txtCredencial.Text;
                    dsPaciente.Tables["CadastroPaciente"].Rows[0][CadastroPacienteDTO.FieldNames.CodigoCNS] = txtCartaoNacionalSaude.Text.Trim();

                    if (txtProntuario.Text == "7")
                    {
                        //Adicionar Prontuario
                        if (dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.IdtPessoa].ToString() != string.Empty)
                        {
                            txtProntuario.Text = FrmSelecaoProntuario.AbrirSelecaoProntuario(Convert.ToDecimal(dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.IdtPessoa]));
                        }
                    }

                    if (txtProntuario.Text != string.Empty)
                        dsPaciente.Tables["CadastroPaciente"].Rows[0][CadastroPacienteDTO.FieldNames.Prontuario] = txtProntuario.Text;
                    else
                        dsPaciente.Tables["CadastroPaciente"].Rows[0][CadastroPacienteDTO.FieldNames.Prontuario] = DBNull.Value;

                    if (ctlSubPlano.DtoSubPlano != null)
                        dsPaciente.Tables["CadastroPaciente"].Rows[0][CadastroPacienteDTO.FieldNames.CodigoSubPlano] = ctlSubPlano.DtoSubPlano.Codigo.Value;
                    else
                        dsPaciente.Tables["CadastroPaciente"].Rows[0][CadastroPacienteDTO.FieldNames.CodigoSubPlano] = DBNull.Value;

                    if (mskValidadeCredencial.Text.Length > 0)
                        dsPaciente.Tables["CadastroPaciente"].Rows[0][CadastroPacienteDTO.FieldNames.DataValidadeCredencial] = Convert.ToDateTime(mskValidadeCredencial.Text);
                    else
                        dsPaciente.Tables["CadastroPaciente"].Rows[0][CadastroPacienteDTO.FieldNames.DataValidadeCredencial] = DBNull.Value;

                    #endregion


                    if (dsPaciente.Tables["MD5"] != null)
                    {
                        if (dsPaciente.Tables["MD5"].Rows.Count > 0)
                            dsPaciente.Tables["MD5"].Rows[0]["CodigoMD5Alterado"] = Pessoa.GerarMD5Pessoa(RemoveAcentos(txtNome.Text.Trim()), Convert.ToDateTime(mskDataNascimento.Text), cboSexo.SelectedValue.ToString());
                    }

                    Paciente.Salvar(ref dsPaciente, dtbTelefone, dtbEndereco, flagAltera, codigoIdentificacao);
                    MessageBox.Show("Operação realizada com sucesso.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FrmCadastroPaciente.Credencial = string.Empty;

                    this.retorno = true;
                    retorno = true;
                }
                catch (OracleException ex)
                {
                    if (ex.Code == 20000)
                        MessageBox.Show("O Tipo de Endereço escolhido já existe, você pode alterá-lo ou escolher um outro Tipo de Endereço.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (ex.Code == 1)
                        MessageBox.Show("O paciente já existe.\nFavor pesquisar pela credencial.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    retorno = false;
                }
                catch (HacException ex)
                {
                    retorno = false;
                    MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    //Correção: Se buscava um paciente pelo nome e recuperava um paciente com a credencial inválida, ele não permitia alterar;
                    if (ex.Message.ToString() == "Credencial Inválida")
                    {
                        txtCredencial.Enabled = true;
                        txtCredencial.Focus();
                    }
                }

                return retorno;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void ctlPlano_Pesquisar(object sender, EventArgs e)
        {
            if (ctlPlano.DtoPlano != null)
            {
                ctlSubPlano.IdtPlano = Convert.ToInt32(ctlPlano.DtoPlano.IdtPlano.Value);
                //ctlSubPlano.IdtLocal = idtLocal;
                //ctlSubPlano.IdtUnidade = idtUnidade;
                txtCredencial.Focus();


                if (dtoPlano != null)
                {
                    if (Convert.ToInt32(dtoPlano.IdtPlano.Value) != Convert.ToInt32(ctlPlano.DtoPlano.IdtPlano.Value))
                    {
                        txtCredencial.Text = string.Empty;
                    }
                }
            }
        }

        private void ctlConvenio_Pesquisar(object sender, EventArgs e)
        {
            AtendimentoDTO dtoAtendimento = new AtendimentoDTO();
            dtoAtendimento.Idt.Value = codigoIdentificacao;
            dtoAtendimento = Atendimento.Pesquisar(dtoAtendimento);

            if (ctlConvenio.DtoConvenio != null)
            {
                if (dtoConvenio == null && (ctlConvenio.DtoConvenio.CodigoHACPrestador.Value == "SD01" || ctlConvenio.DtoConvenio.CodigoHACPrestador.Value == "GG05"))
                {
                    MessageBox.Show("Favor pesquisar pela credencial.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctlConvenio.Inicializar();
                    return;
                }

                if (ctlConvenio.DtoConvenio.CodigoHACPrestador.Value == "PA__")
                {
                    txtCredencial.Text = string.Empty;
                    txtCredencial.Enabled = false;
                }
                else
                {
                    if (!this.IsRecemNascido)
                    {
                        if (dtoAtendimento != null)
                        {
                            MovimentacaoPacienteLeitoDTO dtoMovimentacaoPacienteLeito = new MovimentacaoPacienteLeitoDTO();
                            dtoMovimentacaoPacienteLeito.IdtAtendimento.Value = dtoAtendimento.Idt.Value;
                            dtoMovimentacaoPacienteLeito.StatusTransferencia.Value = "A";
                            MovimentacaoPacienteLeitoDataTable dtbMovimentacaoPacienteLeito =
                                MovimentacaoPacienteLeito.Listar(dtoMovimentacaoPacienteLeito);
                            if (dtbMovimentacaoPacienteLeito.Rows.Count > 0 ||  //não permitido alteração se: paciente no leito
                                !AtendimentoInternacao.ValidarContaFaturada(dtoAtendimento, false) || //conta estiver faturada
                                Paciente.IsPacienteInternadoAlta(Convert.ToDecimal(dtoAtendimento.Idt.Value))) //paciente com alta
                            {
                                txtCredencial.Enabled = false;
                            }
                            else
                            {
                                txtCredencial.Enabled = true;
                            }
                        }
                        else
                        {
                            txtCredencial.Enabled = true;
                        }
                    }
                    else
                    {
                        txtCredencial.Enabled = true;
                    }
                }

                ctlSubPlano.Inicializar();
                ctlPlano.IdtConvenio = Convert.ToInt32(ctlConvenio.DtoConvenio.IdtConvenio.Value);
                ctlSubPlano.IdtConvenio = Convert.ToInt32(ctlConvenio.DtoConvenio.IdtConvenio.Value);
                ctlSubPlano.IdtUnidade = Convert.ToInt32(DtoPassport.Unidade.Idt.Value);
                ctlSubPlano.IdtLocal = Convert.ToInt32(DtoPassport.LocalAtendimento.Idt.Value);


                ctlPlano.Focus();

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


                if (dtoConvenio != null)
                {
                    if (Convert.ToInt32(dtoConvenio.IdtConvenio.Value) != Convert.ToInt32(ctlConvenio.DtoConvenio.IdtConvenio.Value))
                    {
                        txtCredencial.Text = string.Empty;
                    }
                }
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
                txtCredencial.Focus();
            }
        }

        #region Endereço

        private EnderecoDataTable dtbEndereco = null;
        private int? rowIndexGridEndereco;

        private void HabilitarCamposEndereco(bool habilitar)
        {
            cboTipoEndereco.Enabled = habilitar;
            cboCidade.Enabled = habilitar;
            cboTipoLogradouro.Enabled = habilitar;
            cboUF.Enabled = habilitar;
            mskCEP.Enabled = habilitar;
            txtLogradouro.Enabled = habilitar;
            txtNumero.Enabled = habilitar;
            txtComplemento.Enabled = habilitar;
            txtBairro.Enabled = habilitar;
        }

        private void LimparCamposEndereco()
        {
            cboTipoEndereco.SelectedIndex = -1;
            cboCidade.SelectedIndex = -1;
            cboTipoLogradouro.SelectedIndex = -1;
            cboUF.SelectedIndex = -1;
            mskCEP.Text = string.Empty;
            txtLogradouro.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtComplemento.Text = string.Empty;
            txtBairro.Text = string.Empty;

            btnConfirmarEndereco.Enabled = false;
            btnCancelarEndereco.Enabled = false;
            btnAdicionarEndereco.Enabled = true;
            btnExcluirEndereco.Enabled = false;
        }

        private void btnCancelarEndereco_Click(object sender, EventArgs e)
        {
            LimparCamposEndereco();
            HabilitarCamposEndereco(false);
        }

        private void btnConfirmarEndereco_Click(object sender, EventArgs e)
        {
            StringBuilder busMessage = new StringBuilder();
            if (cboTipoEndereco.SelectedIndex == -1)
            {
                busMessage.Append("O campo Tipo Endereco é obrigatório.");
            }
            if (cboCidade.SelectedIndex == -1 || cboCidade.SelectedValue.ToString() == "-1")
            {
                if (busMessage.Length > 0) busMessage.Append("\n");
                busMessage.Append("O campo Cidade é obrigatório.");
            }
            if (cboTipoLogradouro.SelectedIndex == -1)
            {
                if (busMessage.Length > 0) busMessage.Append("\n");
                busMessage.Append("O campo Tipo Logradouro é obrigatório.");
            }
            if (cboUF.SelectedIndex == -1)
            {
                if (busMessage.Length > 0) busMessage.Append("\n");
                busMessage.Append("O campo UF é obrigatório.");
            }
            if (txtNumero.Text == string.Empty)
            {
                if (busMessage.Length > 0) busMessage.Append("\n");
                busMessage.Append("O campo Número é obrigatório.");
            }
            if (txtBairro.Text == string.Empty)
            {
                if (busMessage.Length > 0) busMessage.Append("\n");
                busMessage.Append("O campo Bairro é obrigatório.");
            }
            if (txtLogradouro.Text == string.Empty)
            {
                if (busMessage.Length > 0) busMessage.Append("\n");
                busMessage.Append("O campo Logradouro é obrigatório.");
            }

            if (rowIndexGridEndereco == null)
            {
                foreach (DataGridViewRow linhaEnd in gridEndereco.Rows)
                {
                    if (linhaEnd.Cells[0].FormattedValue == cboTipoEndereco.Text)
                    {
                        if (busMessage.Length > 0) busMessage.Append("\n");
                        busMessage.Append("Tipo de Endereço não pode ser repetido.");
                    }
                }
            }

            if (busMessage.Length > 0)
            {
                MessageBox.Show(busMessage.ToString(), Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (rowIndexGridEndereco != null)
                {
                    gridEndereco.Rows[Convert.ToInt32(rowIndexGridEndereco)].Cells["Logradouro"].Value = txtLogradouro.Text;
                    gridEndereco.Rows[Convert.ToInt32(rowIndexGridEndereco)].Cells["Numero"].Value = txtNumero.Text;
                    gridEndereco.Rows[Convert.ToInt32(rowIndexGridEndereco)].Cells["UF"].Value = cboUF.SelectedValue.ToString();
                    gridEndereco.Rows[Convert.ToInt32(rowIndexGridEndereco)].Cells["Cidade"].Value = cboCidade.SelectedValue.ToString();
                    gridEndereco.Rows[Convert.ToInt32(rowIndexGridEndereco)].Cells["TipoEndereco"].Value = cboTipoEndereco.SelectedValue.ToString();
                    gridEndereco.Rows[Convert.ToInt32(rowIndexGridEndereco)].Cells["TipoLogradouro"].Value = cboTipoLogradouro.SelectedValue.ToString();
                    gridEndereco.Rows[Convert.ToInt32(rowIndexGridEndereco)].Cells["Complemento"].Value = txtComplemento.Text;
                    gridEndereco.Rows[Convert.ToInt32(rowIndexGridEndereco)].Cells["Bairro"].Value = txtBairro.Text;
                    gridEndereco.Rows[Convert.ToInt32(rowIndexGridEndereco)].Cells["CEP"].Value = mskCEP.Text.Replace("-", "");
                }
                else
                {
                    EnderecoDTO dtoEndereco = new EnderecoDTO();
                    dtoEndereco.CEP.Value = mskCEP.Text.Replace("-", "");
                    dtoEndereco.DescricaoComplemento.Value = txtComplemento.Text;
                    dtoEndereco.DescricaoNumero.Value = txtNumero.Text;
                    dtoEndereco.NomeBairro.Value = txtBairro.Text;
                    dtoEndereco.NomeLogradouro.Value = txtLogradouro.Text;
                    if (cboUF.SelectedIndex != -1) dtoEndereco.UF.Value = Convert.ToString(cboUF.SelectedValue);
                    if (cboCidade.SelectedIndex != -1) dtoEndereco.CodigoIBGE.Value = cboCidade.SelectedValue.ToString();
                    if (cboTipoLogradouro.SelectedIndex != -1) dtoEndereco.TipoLogradouro.Value = cboTipoLogradouro.SelectedValue.ToString();
                    if (cboTipoEndereco.SelectedIndex != -1) dtoEndereco.TipoTelefone.Value = Convert.ToDecimal(cboTipoEndereco.SelectedValue);
                    dtbEndereco.Add(dtoEndereco);
                }

                gridEndereco.ClearSelection();

                LimparCamposEndereco();
                HabilitarCamposEndereco(false);
            }
        }

        private void btnAdicionarEndereco_Click(object sender, EventArgs e)
        {
            LimparCamposEndereco();
            HabilitarCamposEndereco(true);

            btnConfirmarEndereco.Enabled = true;
            btnCancelarEndereco.Enabled = true;
            btnAdicionarEndereco.Enabled = false;
            btnExcluirEndereco.Enabled = false;

            cboTipoEndereco.SelectedValue = 1;
            cboUF.SelectedValue = "SP";

            rowIndexGridEndereco = null;
        }

        private void btnExcluirEndereco_Click(object sender, EventArgs e)
        {
            if (rowIndexGridEndereco != null)
                gridEndereco.Rows.Remove(gridEndereco.Rows[Convert.ToInt32(rowIndexGridEndereco)]);

            rowIndexGridEndereco = null;
            gridEndereco.ClearSelection();

            LimparCamposEndereco();
            HabilitarCamposEndereco(false);
        }

        private void PesquisarEnderecos(CadastroPessoaDTO dtoPessoaPesquisa)
        {

            AssociacaoPessoaEnderecoDTO dtoAssociacaoPessoaEndereco = new AssociacaoPessoaEnderecoDTO();
            dtoAssociacaoPessoaEndereco.IdtPessoa.Value = dtoPessoaPesquisa.IdtPessoa.Value;

            AssociacaoPessoaEnderecoDataTable dtbPessoaEnderecoDataTable = AssociacaoPessoaEndereco.Listar(dtoAssociacaoPessoaEndereco);

            foreach (AssociacaoPessoaEnderecoDTO dtoPessoaEndereco in dtbPessoaEnderecoDataTable)
            {
                EnderecoDTO dtoEndereco = new EnderecoDTO();
                dtoEndereco.IdtEndereco.Value = dtoPessoaEndereco.IdtEndereco.Value;
                dtbEndereco.Add(Endereco.Pesquisar(dtoEndereco));
            }




            List<DataRow> lstRemoverTipoEndereco = new List<DataRow>();

            foreach (DataRow rowTipoEndereco in dtbEndereco.Rows)
            {
                if (rowTipoEndereco["AUX_TTE_CD_TP_TEL_END"].ToString() != "1" &&
                    rowTipoEndereco["AUX_TTE_CD_TP_TEL_END"].ToString() != "2" &&
                    rowTipoEndereco["AUX_TTE_CD_TP_TEL_END"].ToString() != "4" &&
                    rowTipoEndereco["AUX_TTE_CD_TP_TEL_END"].ToString() != "6")
                {
                    lstRemoverTipoEndereco.Add(rowTipoEndereco);
                }
            }

            foreach (DataRow row in lstRemoverTipoEndereco)
            {
                dtbEndereco.Rows.Remove(row);
            }




            dtbEndereco.AcceptChanges();

            CarregarGridEndereco();
            gridEndereco.ClearSelection();
        }

        private void CarregarGridEndereco()
        {
            dtbEndereco.Columns["CAD_END_ID_ENDERECO"].AllowDBNull = true;
            dtbEndereco.PrimaryKey = null;

            gridEndereco.DataSource = dtbEndereco;
        }

        private void ConfigurarGridEndereco()
        {
            TipoEndereco.DataPropertyName = EnderecoDTO.FieldNames.TipoTelefone;
            TipoEndereco.DisplayMember = TipoTelefoneEnderecoDTO.FieldNames.Nome;
            TipoEndereco.ValueMember = TipoTelefoneEnderecoDTO.FieldNames.TipoTelefoneEndereco;

            Logradouro.DataPropertyName = EnderecoDTO.FieldNames.NomeLogradouro;
            Numero.DataPropertyName = EnderecoDTO.FieldNames.DescricaoNumero;
            UF.DataPropertyName = EnderecoDTO.FieldNames.UF;
            Complemento.DataPropertyName = EnderecoDTO.FieldNames.DescricaoComplemento;
            Bairro.DataPropertyName = EnderecoDTO.FieldNames.NomeBairro;
            CEP.DataPropertyName = EnderecoDTO.FieldNames.CEP;

            TipoLogradouro.DataPropertyName = EnderecoDTO.FieldNames.TipoLogradouro;
            TipoLogradouro.DisplayMember = TipoLogradouroDTO.FieldNames.Descricao;
            TipoLogradouro.ValueMember = TipoLogradouroDTO.FieldNames.Codigo;

            Cidade.DataPropertyName = EnderecoDTO.FieldNames.CodigoIBGE;
            Cidade.DisplayMember = MunicipioDTO.FieldNames.NomeMunicipio;
            Cidade.ValueMember = MunicipioDTO.FieldNames.CodigoIBGE;

            gridEndereco.AutoGenerateColumns = false;
            gridEndereco.AllowUserToAddRows = false;
        }

        private void gridEndereco_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                LimparCamposEndereco();

                rowIndexGridEndereco = e.RowIndex;

                EnderecoDTO dtoEndereco = ((EnderecoDTO)((DataRowView)gridEndereco.Rows[e.RowIndex].DataBoundItem).Row);
                cboTipoEndereco.SelectedValue = Convert.ToDecimal(dtoEndereco.TipoTelefone.Value);
                txtLogradouro.Text = dtoEndereco.NomeLogradouro.Value.ToString();
                txtNumero.Text = dtoEndereco.DescricaoNumero.Value.ToString();
                txtComplemento.Text = dtoEndereco.DescricaoComplemento.Value.ToString();
                cboUF.SelectedValue = dtoEndereco.UF.Value.ToString();
                cboCidade.SelectedValue = Convert.ToDecimal(dtoEndereco.CodigoIBGE.Value).ToString();
                txtBairro.Text = dtoEndereco.NomeBairro.Value.ToString();
                cboTipoLogradouro.SelectedValue = dtoEndereco.TipoLogradouro.Value.ToString();
                mskCEP.Text = dtoEndereco.CEP.Value.ToString();

                HabilitarCamposEndereco(true);
                btnConfirmarEndereco.Enabled = true;
                btnCancelarEndereco.Enabled = true;
                btnAdicionarEndereco.Enabled = false;
                btnExcluirEndereco.Enabled = true;
            }
        }

        private void btnPesquisarCEP_Click(object sender, EventArgs e)
        {
            if (mskCEP.Text != string.Empty)
            {
                DataTable dtbEndereco = Endereco.PesquisarPorCEP(mskCEP.Text);
                if (dtbEndereco.Rows.Count > 0)
                {
                    txtLogradouro.Text = dtbEndereco.Rows[0]["ENDERECO"].ToString();
                    txtBairro.Text = dtbEndereco.Rows[0]["BAIRRO"].ToString();
                    cboUF.SelectedValue = dtbEndereco.Rows[0]["UF"].ToString();
                    cboCidade.SelectedIndex = cboCidade.FindString(dtbEndereco.Rows[0]["CIDADE"].ToString());
                    cboTipoLogradouro.SelectedIndex = cboTipoLogradouro.FindString(dtbEndereco.Rows[0]["TIPO"].ToString());
                    txtNumero.Focus();
                }
                else
                {
                    MessageBox.Show("Endereço não encontrado para este CEP.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (txtLogradouro.Text != string.Empty && cboCidade.SelectedIndex != -1 && cboUF.SelectedIndex != -1)
                {
                    DataTable dtbEndereco =
                        Endereco.ListarPorLogradouroCidadeUF(txtLogradouro.Text, cboCidade.Text.ToString(),
                                                             cboUF.SelectedValue.ToString());

                    bool retorno = true;
                    if (dtbEndereco.Rows.Count > 0)
                    {
                        if (dtbEndereco.Rows.Count > 1)
                        {
                            retorno = FrmSelecaoEndereco.AbrirSelecaoEndereco(ref dtbEndereco);
                        }

                        if (retorno)
                        {
                            txtLogradouro.Text = dtbEndereco.Rows[0]["NOMELOGRADOURO"].ToString();
                            txtBairro.Text = dtbEndereco.Rows[0]["BAIRRO"].ToString();
                            cboTipoLogradouro.SelectedIndex = cboTipoLogradouro.FindString(dtbEndereco.Rows[0]["TIPOLOGRADOURO"].ToString());
                            mskCEP.Text = dtbEndereco.Rows[0]["CEP"].ToString().Replace("-", "");
                            txtComplemento.Text = dtbEndereco.Rows[0]["COMPLEMENTO"].ToString();
                            txtNumero.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("CEP não encontrado para este endereço.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }


        #endregion

        #region Telefone

        private TelefoneDataTable dtbTelefone = null;
        private int? rowIndexGridTelefone;

        private void HabilitarCamposTelefone(bool habilitar)
        {
            cboTipoTelefone.Enabled = habilitar;
            mskTelefone.Enabled = habilitar;
            txtRamal.Enabled = habilitar;
            txtContatoObservacao.Enabled = habilitar;
        }

        private void LimparCamposTelefone()
        {
            cboTipoTelefone.SelectedIndex = -1;
            mskTelefone.Text = string.Empty;
            txtRamal.Text = string.Empty;
            txtContatoObservacao.Text = string.Empty;

            btnConfirmarTelefone.Enabled = false;
            btnCancelarTelefone.Enabled = false;
            btnAdicionarTelefone.Enabled = true;
            btnExcluirTelefone.Enabled = false;
        }

        private void btnCancelarTelefone_Click(object sender, EventArgs e)
        {
            LimparCamposTelefone();
            HabilitarCamposTelefone(false);
        }

        private void btnAdicionarTelefone_Click(object sender, EventArgs e)
        {
            LimparCamposTelefone();
            HabilitarCamposTelefone(true);

            btnConfirmarTelefone.Enabled = true;
            btnCancelarTelefone.Enabled = true;
            btnAdicionarTelefone.Enabled = false;
            btnExcluirTelefone.Enabled = false;

            cboTipoTelefone.SelectedValue = 1;

            rowIndexGridTelefone = null;
        }

        private void btnConfirmarTelefone_Click(object sender, EventArgs e)
        {
            StringBuilder busMessage = new StringBuilder();
            if (cboTipoTelefone.SelectedIndex == -1)
            {
                busMessage.Append("O campo Tipo Telefone é obrigatório.");
            }
            if (mskTelefone.Text == string.Empty)
            {
                if (busMessage.Length > 0) busMessage.Append("\n");
                busMessage.Append("O campo Telefone é obrigatório.");
            }


            if (busMessage.Length > 0)
            {
                MessageBox.Show(busMessage.ToString(), Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                TelefoneDTO dtoTelefone;

                if (rowIndexGridTelefone != null)
                {
                    gridTelefone.Rows[Convert.ToInt32(rowIndexGridTelefone)].Cells["ContatoObservacao"].Value = txtContatoObservacao.Text;
                    if (txtRamal.Text != string.Empty) gridTelefone.Rows[Convert.ToInt32(rowIndexGridTelefone)].Cells["Ramal"].Value = txtRamal.Text;
                    gridTelefone.Rows[Convert.ToInt32(rowIndexGridTelefone)].Cells["colTelefone"].Value = mskTelefone.Text;
                    gridTelefone.Rows[Convert.ToInt32(rowIndexGridTelefone)].Cells["TipoTelefone"].Value = cboTipoTelefone.SelectedValue.ToString();
                }
                else
                {
                    dtoTelefone = new TelefoneDTO();
                    dtoTelefone.Contato.Value = txtContatoObservacao.Text;
                    dtoTelefone.Ramal.Value = txtRamal.Text;
                    dtoTelefone.Telefone.Value = mskTelefone.Text;
                    if (cboTipoTelefone.SelectedValue != null) dtoTelefone.TipoTelefoneEndereco.Value = cboTipoTelefone.SelectedValue.ToString();
                    dtbTelefone.Add(dtoTelefone);
                }

                gridTelefone.ClearSelection();

                LimparCamposTelefone();
                HabilitarCamposTelefone(false);
            }
        }

        private void btnExcluirTelefone_Click(object sender, EventArgs e)
        {
            if (rowIndexGridTelefone != null)
                gridTelefone.Rows.Remove(gridTelefone.Rows[Convert.ToInt32(rowIndexGridTelefone)]);

            rowIndexGridTelefone = null;
            gridTelefone.ClearSelection();

            LimparCamposTelefone();
            HabilitarCamposTelefone(false);
        }

        private void PesquisarTelefones(CadastroPessoaDTO dtoPessoaPesquisa)
        {
            AssociacaoPessoaTelefoneDTO dtoAssociacaoPessoaTelefone = new AssociacaoPessoaTelefoneDTO();
            dtoAssociacaoPessoaTelefone.IdtPessoa.Value = dtoPessoaPesquisa.IdtPessoa.Value;

            AssociacaoPessoaTelefoneDataTable dtbPessoaTelefoneDataTable = AssociacaoPessoaTelefone.Listar(dtoAssociacaoPessoaTelefone);

            foreach (AssociacaoPessoaTelefoneDTO dtoPessoaTelefone in dtbPessoaTelefoneDataTable)
            {
                TelefoneDTO dtoTelefone = new TelefoneDTO();
                dtoTelefone.IdtTelefone.Value = dtoPessoaTelefone.IdtTelefone.Value;
                dtbTelefone.Add(Telefone.Pesquisar(dtoTelefone));
            }
            dtbTelefone.AcceptChanges();

            CarregarGridTelefone();
            gridTelefone.ClearSelection();
        }

        private void CarregarGridTelefone()
        {
            dtbTelefone.Columns["CAD_TEL_ID_TELEFONE"].AllowDBNull = true;
            dtbTelefone.PrimaryKey = null;

            gridTelefone.DataSource = dtbTelefone;
        }

        private void ConfigurarGridTelefone()
        {
            TipoTelefone.DataPropertyName = TelefoneDTO.FieldNames.TipoTelefoneEndereco;
            TipoTelefone.DisplayMember = TipoTelefoneEnderecoDTO.FieldNames.Nome;
            TipoTelefone.ValueMember = TipoTelefoneEnderecoDTO.FieldNames.TipoTelefoneEndereco;

            colTelefone.DataPropertyName = TelefoneDTO.FieldNames.Telefone;
            Ramal.DataPropertyName = TelefoneDTO.FieldNames.Ramal;
            ContatoObservacao.DataPropertyName = TelefoneDTO.FieldNames.Contato;
            IdtTelefone.DataPropertyName = TelefoneDTO.FieldNames.IdtTelefone;

            gridTelefone.AutoGenerateColumns = false;
            gridTelefone.AllowUserToAddRows = false;
            gridTelefone.DataSource = dtbTelefone;
        }

        private void gridTelefone_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                LimparCamposTelefone();

                rowIndexGridTelefone = e.RowIndex;

                TelefoneDTO dtoTelefone = ((TelefoneDTO)((DataRowView)gridTelefone.Rows[e.RowIndex].DataBoundItem).Row);
                cboTipoTelefone.SelectedValue = dtoTelefone.TipoTelefoneEndereco.Value;
                mskTelefone.Text = dtoTelefone.Telefone.Value.ToString().Replace(" ", "");
                txtRamal.Text = dtoTelefone.Ramal.Value;
                txtContatoObservacao.Text = dtoTelefone.Contato.Value;

                HabilitarCamposTelefone(true);
                btnConfirmarTelefone.Enabled = true;
                btnCancelarTelefone.Enabled = true;
                btnAdicionarTelefone.Enabled = false;
                btnExcluirTelefone.Enabled = true;
            }
        }

        #endregion

        #region tspCommand
        private bool tspCommand_NovoClick(object sender)
        {
            txtCredencial.Enabled = true;
            dtoPaciente = null;
            ctlConvenio.Focus();

            return true;
        }

        private bool tspCommand_SalvarClick(object sender)
        {
            if (!verificarMD5())
                return Salvar();
            else
                return false;
        }

        private void tspCommand_BeforeSalvar(object sender)
        {
            ctlConvenio.Obrigatorio = true;
            ctlConvenio.ObrigatorioMensagem = "O campo Convênio é obrigatório.";

            ctlPlano.Obrigatorio = true;
            ctlPlano.ObrigatorioMensagem = "O campo Plano é obrigatório.";

            //Exceto para Convenio Particular (PA__)
            if (ctlConvenio.DtoConvenio != null)
            {
                if (ctlConvenio.DtoConvenio.CodigoHACPrestador.Value != "PA__" && ctlConvenio.DtoConvenio.CodigoHACPrestador.Value != "NP01")
                {
                    txtCredencial.Obrigatorio = true;
                    txtCredencial.ObrigatorioMensagem = "O campo Credencial é obrigatório.";
                    mskCPF.Obrigatorio = false;

                    if (txtCredencial.Text.Trim() == string.Empty)
                        txtCredencial.Enabled = true;
                }
                else
                {
                    cboNacionalidade.Obrigatorio = true;
                    cboNacionalidade.ObrigatorioMensagem = "O campo nacionalidade é obrigatório.";

                    txtCredencial.Obrigatorio = false;
                    mskCPF.Obrigatorio = this.CaraterUrgencia ? false : true;
                    mskCPF.ObrigatorioMensagem = "O campo CPF é obrigatório.";

                    if (cboNacionalidade.SelectedValue != null && cboNacionalidade.SelectedValue.ToString() != "10")
                    {
                        mskCPF.Obrigatorio = false;
                    }
                    else
                    {
                        mskCPF.Obrigatorio = true;
                    }
                }
            }

            txtNome.Obrigatorio = true;
            txtNome.ObrigatorioMensagem = "O campo Nome do Paciente é obrigatório.";

            mskDataNascimento.Obrigatorio = true;
            mskDataNascimento.ObrigatorioMensagem = "O campo Data de Nascimento é obrigatório.";

            cboSexo.Obrigatorio = true;
            cboSexo.ObrigatorioMensagem = "O campo Sexo é obrigatório.";

            txtRG.Obrigatorio = this.CaraterUrgencia ? false : true;
            txtRG.ObrigatorioMensagem = "O campo RG é obrigatório.";


            if (ctlConvenio.DtoConvenio != null)
            {
                //SubPlanoDTO dtoSubPlano = new SubPlanoDTO();
                //SubPlanoDataTable dtbSubPlano = new SubPlanoDataTable();
                //dtoSubPlano.IdtConvenio.Value = ctlConvenio.DtoConvenio.IdtConvenio.Value;
                //dtbSubPlano = SubPlano.Listar(dtoSubPlano);
                //if (dtbSubPlano.Rows.Count > 0)

                if (UnidadeLocalSubPlano.VerificaSubPlano(Convert.ToInt32(ctlConvenio.DtoConvenio.IdtConvenio.Value),
                                                          Convert.ToInt32(DtoPassport.Unidade.Idt.Value),
                                                          Convert.ToInt32(DtoPassport.LocalAtendimento.Idt.Value)))
                {
                    ctlSubPlano.Obrigatorio = true;
                    ctlSubPlano.ObrigatorioMensagem = "O campo do Sub-Plano é obrigatório.";
                }
                else
                {
                    ctlSubPlano.Obrigatorio = false;
                    ctlSubPlano.ObrigatorioMensagem = "";
                }
            }

            if (IsCNS_Obrigatorio)
            {
                IsCNS_Obrigatorio = 
                    txtCartaoNacionalSaude.Obrigatorio = false;
                //txtCartaoNacionalSaude.Obrigatorio = true;
                //txtCartaoNacionalSaude.ObrigatorioMensagem = "O campo Cartão Nacional de Saúde é obrigatório.";
            }
            else
            {
                txtCartaoNacionalSaude.Obrigatorio = false;
            }
        }

        private bool tspCommand_SairClick(object sender)
        {
            if (_flagModoConsulta)
            {
                return true;
            }

            if (_isRecemNascido)
            {
                if (ctlConvenio.DtoConvenio.CodigoHACPrestador.Value == "SD01" ||
                    ctlConvenio.DtoConvenio.CodigoHACPrestador.Value == "GG05")
                {
                    if (txtCredencial.Text.Length < 12)
                    {
                        return true;
                    }
                    BeneficiarioDTO dtoBeneficiario = new BeneficiarioDTO();

                    dtoBeneficiario.CodigoLoja.Value = txtCredencial.Text.Substring(0, 3);
                    dtoBeneficiario.CodigoMatricula.Value = txtCredencial.Text.ToString().Substring(3, 7);
                    dtoBeneficiario.CodigoSeqMatricula.Value = txtCredencial.Text.ToString().Substring(10, 2);
                    dtoBeneficiario.CodigoEmpresa.Value = ctlPlano.DtoPlano.CodigoPlanoHAC.Value;

                    BeneficiarioDataTable dtbBeneficiario = Beneficiario.Listar(dtoBeneficiario);
                    if (dtbBeneficiario.Rows.Count <= 0)
                    {
                        return true;
                    }
                }
            }

            if (tspCommand.SalvarHabilitado)
            {

                DialogResult dlgResult = MessageBox.Show("Alguns dados foram alterados e ainda não foram salvos, deseja salvar?", Titulo,
                                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (dlgResult)
                {
                    case DialogResult.Yes:
                        tspCommand_BeforeSalvar(sender);
                        if (((FrmBase)this.FindForm()).ValidaObjeto(Evento.eSalvar))
                        {
                            tspCommand_SalvarClick(sender);
                        }
                        else
                        {
                            return false;
                        }
                        break;
                }
            }

            return true;

            //if (dsPaciente != null)
            //{
            //    //Foi gerado um paciente a partir de um beneficiario ACS mas não foi salvo.
            //    if (dsPaciente.Tables["CadastroPaciente"].Rows.Count > 0)
            //    {
            //        CadastroPacienteDTO dtoCadastroPaciente = (CadastroPacienteDTO)dsPaciente.Tables["CadastroPaciente"].Rows[0];
            //        if (dtoCadastroPaciente.IdtPaciente.Value.IsNull)
            //            dsPaciente = null;
            //    }

            //    //Se foi criado um paciente ou alterado retorno true.
            //    if (dsPaciente == null)
            //        retorno = false;
            //    else
            //    {
            //        //Clicou em sair mas não tem paciente criado
            //        if (dsPaciente.Tables["CadastroPaciente"].Rows.Count == 0)
            //            retorno = false;
            //        //Clicou em sair, a credencial é obrigatória a digitação e não salvou.
            //        else if (obrigaDigitacaoCredencial == true && salvou == false)
            //            retorno = false;
            //        else
            //            //Variável retornada no AbrirCadastroPaciente
            //            retorno = true;

            //    }
            //    return true;
            //}
            //else
            //    retorno = false;
            //    return true;

            //Retorno da barra ToolStrip

        }
        #endregion

        private void tspCommand_AfterSalvar(object sender)
        {
            //this.Close();
            //btnFoto_Click(sender, new EventArgs());
            //abrir a tela da foto do paciente
            CadastroPessoaDTO dtoCadastroPessoa = (CadastroPessoaDTO)dsPaciente.Tables["CadastroPessoa"].Rows[0];
            Int32 idtPessoa = Convert.ToInt32(dtoCadastroPessoa.IdtPessoa.Value);
            FrmFoto.AbrirFormFoto(idtPessoa);
            Close();
        }

        private bool tspCommand_CancelarClick(object sender)
        {
            return true;
        }

        private void tspCommand_AfterCancelar(object sender)
        {
            dtbTelefone = new TelefoneDataTable();
            dtbEndereco = new EnderecoDataTable();

            ConfigurarControlesSalvar();
            InicializarControles();
        }

        private bool ValidarDataAtual()
        {
            StringBuilder busMessage = new StringBuilder();

            if (mskValidadeCredencial.Text.Length > 0)
            {
                if (Convert.ToDateTime(mskValidadeCredencial.Text) < DateTime.Now.Date)
                {
                    busMessage.Append("A data de validade da credencial não pode ser menor que a data atual.");
                }
            }

            if (busMessage.Length > 0)
            {
                MessageBox.Show(busMessage.ToString(), Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private void btnExibeMascaraCredencial_Click(object sender, EventArgs e)
        {
            if (!ctlConvenio.DtoConvenio.MascaraMatricula.Value.IsNull)
                toolTip1.SetToolTip(btnExibeMascaraCredencial, ctlConvenio.DtoConvenio.MascaraMatricula.Value.ToString());
            else
                toolTip1.SetToolTip(btnExibeMascaraCredencial, string.Empty);
        }

        /// <summary>
        /// Verificar a existencia de pessoas com o mesmo MD5 caso o idtPessoa não esteja preenchido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void verificarMD5(object sender, EventArgs e)
        {
            verificarMD5();
        }

        private bool verificarMD5()
        {
            if (txtNome.Text != string.Empty && mskDataNascimento.Text != string.Empty && cboSexo.SelectedValue != null && cboSexo.SelectedValue.ToString() != "-1" &&
                (dsPaciente.Tables["CadastroPessoa"] == null || dsPaciente.Tables["CadastroPessoa"].Rows[0][CadastroPessoaDTO.FieldNames.IdtPessoa].ToString() == string.Empty))
            {
                string md5 = Pessoa.GerarMD5Pessoa(RemoveAcentos(txtNome.Text.Trim()), Convert.ToDateTime(mskDataNascimento.Text), cboSexo.SelectedValue.ToString());
                CadastroPessoaDataTable dtbPessoa = new CadastroPessoaDataTable();
                dtbPessoa = Pessoa.ListarMD5(md5);

                if (dtbPessoa.Rows.Count > 0 && MessageBox.Show("Existe(m) um ou mais cadastro(s) de pessoa(s) com essas mesmas informações!\nDeseja exibir uma lista para seleção?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataSet dsPessoa = new DataSet();
                    dsPessoa.Tables.Add(dtbPessoa);
                    if (FrmSelecaoPessoa.AbrirSelecaoPessoa(ref dsPessoa))
                    {
                        //Limpar informações atuais da pessoa:
                        dsPaciente.Tables["CadastroPessoa"].Rows.Clear();
                        dtbEndereco.Rows.Clear();
                        dtbTelefone.Rows.Clear();

                        CadastroPessoaDTO dtoPessoaMD5 = (CadastroPessoaDTO)dsPessoa.Tables["CadastroPessoa"].Rows[0];
                        dsPaciente.Tables["CadastroPessoa"].Merge(dsPessoa.Tables["CadastroPessoa"]);
                        Paciente.ComplementarPessoa(ref dsPaciente);
                        CarregarPessoa(dtoPessoaMD5);

                        //Carregar prontuário
                        txtProntuario.Text = FrmSelecaoProntuario.AbrirSelecaoProntuario(Convert.ToDecimal(dtoPessoaMD5.IdtPessoa.Value));

                        return true;
                    }
                }
            }

            return false;
        }


        //codigoIdentificacao
        private int? codigoIdentificacao;
        private int? CodigoIdentificacao
        {
            get { return codigoIdentificacao; }
            set { codigoIdentificacao = value; }
        }

        private bool flagConvenioPlanoAlterado;
        public bool FlagConvenioPlanoAlterado
        {
            get { return flagConvenioPlanoAlterado; }
            set { flagConvenioPlanoAlterado = value; }
        }
    }
}

