using System;
using System.Windows.Forms;
using Microsoft.Win32;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;
using HospitalAnaCosta.Services.Seguranca.Interface;
//using HospitalAnaCosta.Services.Seguranca.Control;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Specialized;

namespace Hac.Windows.Forms.Controls.Forms
{
    public partial class FrmLogin : FrmBase
    {
        private Int32 idTelaOrigem = 0;  //0 windows  1 libera��o   2 Prontuario Eletronico //filtrar comportamento de tela
        private Int32 idTelaDestino = 0;  //0 menu 1 FrmPrescricao 2 Relatorios
        private string idUsuarioTelaOrigem = "0";  // Recuperar informa��es do usuario
        private Int32 idAtendimentoTelaOrigem = 0;  // Recuperar informa��es do atendimento
        private Int32 idPacienteTelaOrigem = 0;  // Recuperar informa��es do paciente

        #region [CONSTRUTOR]

        public FrmLogin(string Arguments)
        {
            try
            {
                InitializeComponent();
              
                if (Arguments != null && Arguments.Length > 0)
                {
                    //MessageBox.Show(idTelaOrigem.ToString());

                    string[] a = Arguments.Split(',');

                    idTelaOrigem = Convert.ToInt16(a[0]);
                    idTelaDestino = Convert.ToInt16(a[1]);
                    idUsuarioTelaOrigem = a[2].ToString();
                    idAtendimentoTelaOrigem = Convert.ToInt32(a[3]);
                    idPacienteTelaOrigem = Convert.ToInt32(a[4]);

                    //MessageBox.Show(string.Format("a {0} {1} {2} {3} {4}", a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString()), "Interna��o", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao receber os par�metros.");
            } 
        }
        public FrmLogin()
        {
            InitializeComponent();
        }

        #endregion        

        #region [FORM LOAD]

        /// <summary>
        /// Carrega unidade, esconde os paineis de Trocar Senha e Localiza��o.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            VerificadorClientControl.VerificarClientControl();

            Height = TelaFechada;

            //Tirar isto - utlizado para esperar o remoting abrir em modo de debug
            if(idTelaOrigem==0){
            #if (DEBUG)
                System.Threading.Thread.Sleep(10000);
            #endif
            }

            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName)[0].MainWindowTitle == "SGS - Sistema de Gest�o de Sa�de - Interna��o")
            {
                cmbUnidade.Internacao = true;
            }
            //if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName)[0].MainWindowTitle == "SGS - Sistema de Gest�o de Sa�de - Faturamento")
            //{
            //    cmbUnidade.Fatura = true;
            //}
            cmbUnidade.Carregaunidade();
            
            pnlTrocaSenha.Visible = false;
            pnlUnidade.Visible = false;
            this.SelecionarCombos();
            this.SelecionarUsuario();

            btnLogin.GotFocus += btnLogin_GotFocus;
            btnSalvarNovaSenha.GotFocus += btnSalvarNovaSenha_GotFocus;

            // MessageBox.Show(idTelaOrigem.ToString(), "Interna��o", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            if (idTelaOrigem == 2) //P.E.
            {
                PainelLocallizacaoShow();
                bLocalizacao = true;
                cmbUnidade.SelectedValue = "244";
                
                //cmbUnidade_SelectedIndexChanged(null, null);
                cmbLocal.CarregaLocal(244,null);
                cmbLocal.SelectedValue = "29";
                //cmbLocal_SelectedIndexChanged(null, null);
                cmbSetor.CarregaSetor(244,29,null);
                cmbSetor.SelectedValue = "22";
                //cmbSetor_SelectedIndexChanged(null, null);
                txtUsuario.Text = idUsuarioTelaOrigem;
                UsuarioDTO dto = new UsuarioDTO();
                dto.Login.Value = idUsuarioTelaOrigem;
                UsuarioDataTable dtb = Usuario.Listar(dto);
                dto = dtb.TypedRow(0);
                txtSenha.Text = dto.Senha.Value;
                PassportDTO dtoPassport = new PassportDTO();
                dtoPassport.Usuario = dto;
                btnLogin_Click(null, null);
            }
            
        }

        public static PassportDTO AbrirFormLogin(bool fechaTelaLogin)
        {
            FrmLogin frmLogin = new FrmLogin();
            bOrigemDispensacao = fechaTelaLogin;
            frmLogin.ShowDialog();
            return frmLogin.DtoPassport;
        }
        public static PassportDTO AbrirFormLogin(bool fechaTelaLogin, string Arguments)
        {
            FrmLogin frmLogin = new FrmLogin(Arguments);
            bOrigemDispensacao = fechaTelaLogin;
            frmLogin.ShowDialog();
            return frmLogin.DtoPassport;
        }

        public static PassportDTO AbrirFormLogin(bool fechaTelaLogin,bool fechaTodasAsTelas)
        {
            FrmLogin frmLogin = new FrmLogin();
            bOrigemDispensacao = fechaTelaLogin;
            bFechaTodasAsTelas = fechaTodasAsTelas;
            frmLogin.ShowDialog();
            return frmLogin.DtoPassport;
        }

        public static PassportDTO AbrirFormLoginTesteAutenticacao(bool fechaTelaLogin, bool fechaTodasAsTelas, bool manterLoginSalvo = true)
        {
            FrmLogin frmLogin = new FrmLogin();
            bOrigemDispensacao = fechaTelaLogin;
            bFechaTodasAsTelas = fechaTodasAsTelas;
            frmLogin.ManterLoginSalvo = manterLoginSalvo;
            frmLogin.ShowDialog();            
            if (dtoPassportAuthentication == null)
                dtoPassport = null;

            return dtoPassport;
        }

        #endregion

        #region [VARI�VEIS PRIVADAS]

        private static PassportDTO dtoPassport;

        private int TelaAberta = 550;
        private int TelaFechada = 380;

        private bool bSenha = false;
        private bool bLocalizacao = false;
        public static bool bOrigemDispensacao = false;
        private static bool bFechaTodasAsTelas = true;

        private string registroCaminho = "Software\\Hospital Ana Costa\\Sistema de Seguranca\\Faturamento";
        
        #endregion
        
        #region [VARI�VEIS P�BLICAS]

        private  static PassportAuthenticationDTO dtoPassportAuthentication;

        public PassportDTO DtoPassport
        {
            get { return dtoPassport; }
            set { dtoPassport = value; }
        }

        #endregion     

        #region [PAINEL SENHA]

        /// <summary>
        /// Exibe o Painel de Trocar Senha, desabilita os campos de Login, e seta o foco nos campos de nova senha.
        /// </summary>
        private void PainelSenhaShow()
        {
            btnCancelar.Enabled = false;
            btnLogin.Enabled = false;
            txtUsuario.Enabled = false;
            txtSenha.Enabled = false;

            this.Height = TelaAberta;
            pnlTrocaSenha.Dock = DockStyle.Bottom;
            pnlTrocaSenha.Visible = true;
            lblTrocarLocalizacao.Enabled = false;

            if (txtSenha.Text == string.Empty)
            {
                txtSenhaAtual.Focus();
            }
            else
            {
                txtSenhaAtual.Text = txtSenha.Text;
                txtNovaSenha.Focus();
            }
        }

        /// <summary>
        /// Esconde o Painel de Trocar Senha, habilita os bot�es de Login e coloca o foco do teclado no campo de Login, 
        /// </summary>
        private void PainelSenhaHide()
        {
            lblSenhaAtual.Text = "Senha Atual:";
            lblNovaSenha.Text = "Nova Senha:";
            lblNovaSenha.Location = new System.Drawing.Point(75, 73);

            lblTrocarLocalizacao.Enabled = true;
            pnlTrocaSenha.Visible = false;
            Height = TelaFechada;
            btnCancelar.Enabled = true;
            btnLogin.Enabled = true;
            txtUsuario.Enabled = true;
            txtSenha.Enabled = true;
            if (txtUsuario.Text == string.Empty) { txtUsuario.Focus(); }
            else if (txtSenha.Text == string.Empty) { txtSenha.Focus(); }
        }

        /// <summary>
        /// Exibe ou esconde o Painel de Trocar Senha pelos metodos PainelSenhaShow ou PainelSenhaHide.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblTrocaSenha_Click(object sender, EventArgs e)
        {
            string url = Usuario.GeraToken(txtUsuario.Text, false, true);
            //NameValueCollection appSettings = ConfigurationManager.AppSettings;
            //string servidor = appSettings["HAC.REMOTING.SERVICES.PATH"];
            //string porta = appSettings["HAC.REMOTING.URL.PORT"];
            //url = url.Replace("[servidor]",servidor).Replace("[porta]",porta);
            //var transferEncoded = Base64Encode(url);
            //var frmWeb = new Controls.Forms.FrmWeb(url, "Senha", 1000, 760, false);
            //if (frmWeb != null)
            //{
            //    AbrirFormularioDialog(frmWeb);
            //}      
            //AbrirWeb(url, 1024, 720, "Senha", false, true);
            System.Diagnostics.Process.Start("msedge.exe", url);
            //txtSenhaAtual.Text = string.Empty;
            //txtNovaSenha.Text = string.Empty;
            //if (!bSenha)
            //{
            //    bSenha = true;
            //    PainelSenhaShow();
            //}
            //else
            //{
            //    bSenha = false;
            //    PainelSenhaHide();
            //}
        }

        /// <summary>
        /// Chama o metodo que salva a nova senha passando como parametro o Login, Senha Atual e Nova Senha, antes de salvar ele verifica se o Login e Senha Atual S�o v�lidos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalvarNovaSenha_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblSenhaAtual.Text == "Nova Senha:") ////Primeiro Acesso///
                {
                    if (txtSenhaAtual.Text != txtNovaSenha.Text)
                    {
                        MessageBox.Show("Opera��o n�o realizada. \nAs senhas devem ser iguais nos dois campos.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                        Usuario.PrimeiroAcesso(txtUsuario.Text, txtNovaSenha.Text);
                }
                else
                {
                    Usuario.TrocarSenha(txtUsuario.Text, txtSenhaAtual.Text, txtNovaSenha.Text);
                }
                

                MessageBox.Show("Opera��o realizada com sucesso!!! \n Senha alterada.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (HacException ex)
            {
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Opera��o n�o realizada!!! \n\n Ocorreu um erro na Troca de Senha. \n Mensagem: {0}", ex.Message), Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            PainelSenhaHide();
        }

        /// <summary>
        /// Cancela o salvar da Nova Senha, chamando o metodo que esconde o painel de senha.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelarNovaSenha_Click(object sender, EventArgs e)
        {
            PainelSenhaHide();
        }

        #endregion

        #region [PAINEL UNIDADE]

        /// <summary>
        /// Exibe o painel de Localiza��o, e seta o foco para o combo de unidade.
        /// </summary>
        private void PainelLocallizacaoShow()
        {
            this.Cursor = Cursors.WaitCursor;
            this.Height = TelaAberta;
            pnlUnidade.Dock = DockStyle.Bottom;
            pnlUnidade.Visible = true;
            lblTrocaSenha.Enabled = false;
            this.Cursor = Cursors.Default;
            cmbUnidade.Focus();
        }

        /// <summary>
        /// Esconde o Painel de Localiza��o, e chama o metodo RegistraLocal com o parametro como False para limpar os valores.
        /// </summary>
        private void PainelLocallizacaoHide()
        {
            lblTrocaSenha.Enabled = true;
            pnlUnidade.Visible = false;
            this.Height = TelaFechada;

            if (txtUsuario.Text == string.Empty)
            {
                txtUsuario.Focus();
            }
            else
            {
                txtSenha.Focus();
            }
            RegistrarLocal(false);
        }

        /// <summary>
        /// Exibe ou esconde o painel de localiza��o verificando se ja estiver visivel mantem exibido, sen�o esconde o painel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblTrocarLocalizacao_Click(object sender, EventArgs e)
        {
            if (!bLocalizacao)
            {
                PainelLocallizacaoShow();
                bLocalizacao = true;
            }
            else
            {
                PainelLocallizacaoHide();
                bLocalizacao = false;
            }
        }

        /// <summary>
        /// Verifica se existe valor nos Combos de Unidade, Local e Setor, se existir chama o m�todo que ira Registra a Localiza��o no Registro do Windows, esconder
        /// o Painel de Localiza��o e colocar o focu no campo de Login ou Senha.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalvarUnidade_Click(object sender, EventArgs e)
        {
            if (cmbUnidade.SelectedValue.ToString() == "-1" || cmbLocal.SelectedValue.ToString() == "-1" || cmbSetor.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Opera��o n�o realizada!!! \n\n Para salvar sua localiza��o selecione: Unidade, Local e Setor.", "SGS - Sistema de Gest�o de Sa�de", MessageBoxButtons.OK, MessageBoxIcon.Information);   
            }
            else
            {
                PainelLocallizacaoHide();    
            }
        }

        /// <summary>
        /// Cancela o salvar da localiza��o, esconde o painel de localiza��o, e limpa os valores salvos no registro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelarUnidade_Click(object sender, EventArgs e)
        {
            PainelLocallizacaoHide();
        }

        #endregion

        #region [M�TODOS]

        /// <summary>
        /// Salva no Registro o usu�rio digitado, verifica se vai ser salvo o valor ou se vai ser limpo os valores do registro
        /// pelo parametro bool limparValores, e ap�s salvar, exibe na ToolStrip Status a localiza��o Salva.
        /// </summary>
        /// <param name="limparValores"></param>
        private void RegistrarUsuario(bool limparValores)
        {
            AjustaDescricaoLocal();

            if (ManterLoginSalvo)
            {
                RegistryKey registro = Registry.CurrentUser;
                registro = registro.OpenSubKey(registroCaminho, true);

                if (registro == null)
                {
                    registro = Microsoft.Win32.Registry.CurrentUser;
                    registro = registro.CreateSubKey(registroCaminho);
                }
                else
                {
                    if (!limparValores)
                    {
                        if (txtUsuario.Text != string.Empty) registro.SetValue("Usuario", txtUsuario.Text);
                    }
                    else
                    {
                        registro.SetValue("Usuario", string.Empty);
                    }
                }
            }
            
        }

        /// <summary>
        /// Salva no Registro do Windows a localiza��o que o usu�rio selecionou nos campos, verifica se vai ser salva o valor ou se vai ser limpo os valores que est�o salvos no registro
        /// pelo parametro bool limparValores, e ap�s salvar, exibe na ToolStrip Status a localiza��o Salva.
        /// </summary>
        /// <param name="limparValores"></param>
        private void RegistrarLocal(bool limparValores)
        {
            AjustaDescricaoLocal();

            if (ManterLoginSalvo)
            {
                RegistryKey registro = Registry.CurrentUser;
                registro = registro.OpenSubKey(registroCaminho, true);

                if (registro == null)
                {
                    registro = Microsoft.Win32.Registry.CurrentUser;
                    registro = registro.CreateSubKey(registroCaminho);
                }
                else
                {
                    if (!limparValores)
                    {
                        if (cmbUnidade.SelectedValue != null && cmbUnidade.SelectedValue.ToString() != "-1") registro.SetValue("Unidade", cmbUnidade.SelectedValue);
                        if (cmbLocal.SelectedValue != null && cmbLocal.SelectedValue.ToString() != "-1") registro.SetValue("LocalAtendimento", cmbLocal.SelectedValue);
                        if (cmbSetor.SelectedValue != null && cmbSetor.SelectedValue.ToString() != "-1") registro.SetValue("Setor", cmbSetor.SelectedValue);
                    }
                    else
                    {
                        registro.SetValue("Unidade", string.Empty);
                        registro.SetValue("LocalAtendimento", string.Empty);
                        registro.SetValue("Setor", string.Empty);
                    }
                }
            }
            
        }

        /// <summary>
        /// Busca o nome do �ltimo usu�rio que logou no Sistema, essa informa��o foi salva no Registro do Windows, ap�s obter o nome do usu�rio � exibido o nome 
        /// no TextBox de Login.
        /// </summary>
        private void SelecionarUsuario()
        {
            RegistryKey registro = Registry.CurrentUser;
            registro = registro.OpenSubKey(registroCaminho, true);

            if (registro != null)
            {
                if (registro.GetValue("Usuario") != null)
                {
                    if (registro.GetValue("Usuario").ToString() != string.Empty)
                    {
                        txtUsuario.Text = registro.GetValue("Usuario").ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Verifica se unidade/Local/Setor j� foram definidos e est�o salvos no Registro do Windows, se tiver algo salvo, � obtido o valor do Registro
        /// e � atribuido aos combos os valores salvos no Registro
        /// </summary>
        private void SelecionarCombos()
        {
            RegistryKey registro = Registry.CurrentUser;
            registro = registro.OpenSubKey(registroCaminho, true);

            if (registro != null)
            {
                if (registro.GetValue("Unidade") != null)
                {
                    if (registro.GetValue("Unidade").ToString() != string.Empty)
                    {
                        cmbUnidade.SelectedValue = registro.GetValue("Unidade").ToString();
                    }
                }

                if (registro.GetValue("LocalAtendimento") != null && registro.GetValue("LocalAtendimento").ToString() != string.Empty)
                {
                    cmbLocal.SelectedValue = registro.GetValue("LocalAtendimento").ToString();
                }

                if (registro.GetValue("Setor") != null)
                {
                    if (registro.GetValue("Setor").ToString() != string.Empty && cmbUnidade.SelectedIndex != -1 && cmbLocal.SelectedIndex != -1)
                    {
                        cmbSetor.SelectedValue = registro.GetValue("Setor").ToString();
                        AjustaDescricaoLocal();
                    }
                    else
                    {
                        lblTrocarLocalizacao_Click(null, null);
                    }
                }
            }
            else
            {
                lblTrocarLocalizacao_Click(null, null);
            }
        }

        /// <summary>
        /// Exibe na ToolStrip de Status a localiza��o do ultimo usuario logado ou o valor "selecione" caso n�o tenha nenhuma localiza��o salva no Registro
        /// do windows
        /// </summary>
        private void AjustaDescricaoLocal()
        {
            try
            {
                if (cmbUnidade.SelectedValue.ToString() != "-1")
                {
                    toolStatus.Items["lblUnidade"].Text = String.Format("{0}  >> ", cmbUnidade.Text);
                    toolStatus.Items["lblLocal"].Text = String.Format("{0}  >> ", cmbLocal.Text);
                    toolStatus.Items["lblSetor"].Text = cmbSetor.Text;
                }
                else
                {
                    toolStatus.Items["lblUnidade"].Text = String.Format("{0}", cmbUnidade.Text);
                    toolStatus.Items["lblLocal"].Text = string.Empty;
                    toolStatus.Items["lblSetor"].Text = string.Empty;
                }
            }
            catch (Exception)
            {
                                
            }
        }

        private CommonServicesView _commonServices;
        protected CommonServicesView CommonServices
        {
            get
            {
                return _commonServices != null
                           ? _commonServices
                           : _commonServices = new CommonServicesView(FrmBase.DtoPassport);
            }
        }

        public bool ManterLoginSalvo = true;

        /// <summary>
        /// Recupera o Passport do Usu�rio, onde atrav�s dele � poss�vel saber qual sua Unidade e
        /// suas permiss�es, e registra o usu�rio e as informa��es de Local no Registro do Windows.
        /// </summary>
        public void IdentificacaoOk()
        {
            //Recupera o m�dulo do sistema no App.Config
            ModuloDTO dtoModulo = new ModuloDTO();             

            if(ConfigurationManager.AppSettings["HAC.SEGURANCA.CONFIG.MODULO"] == null)
                throw new HacException("M�dulo n�o configurado para o aplicativo. Verifique o App.Config da aplica��o.");

            dtoModulo.Nome.Value = ConfigurationManager.AppSettings["HAC.SEGURANCA.CONFIG.MODULO"].ToString();
            ModuloDataTable dtbModulo =  Modulo.Listar(dtoModulo);

            if (dtbModulo.Rows.Count == 0)
            {
                throw new HacException("M�dulo de configura��o da seguran�a n�o cadastrado.");
            }
            else
            {
                PassportDTO dtoPassport = Usuario.ObterPassport(Convert.ToInt32(cmbUnidade.SelectedValue),
                                                                dtoPassportAuthentication.Usuario,
                                                                Convert.ToInt32(cmbLocal.SelectedValue),
                                                                Convert.ToInt32(cmbSetor.SelectedValue),
                                                                Convert.ToDecimal(dtbModulo.TypedRow(0).Idt.Value));

                
                RegistrarUsuario(false);
                RegistrarLocal(false);

                this.DtoPassport = dtoPassport;

                //Atribuo nulo a vari�vel para for�ar a recria��o com o Passport.
                _commonServices = null;
               // UnidadeLocalSetorUsuario = null;

            }
        }
        public void IdentificacaoOk(PassportDTO dtoPassport)
        {
            //Recupera o m�dulo do sistema no App.Config
            ModuloDTO dtoModulo = new ModuloDTO();

            if (ConfigurationManager.AppSettings["HAC.SEGURANCA.CONFIG.MODULO"] == null)
                throw new HacException("M�dulo n�o configurado para o aplicativo. Verifique o App.Config da aplica��o.");

            dtoModulo.Nome.Value = ConfigurationManager.AppSettings["HAC.SEGURANCA.CONFIG.MODULO"].ToString();
            ModuloDataTable dtbModulo = Modulo.Listar(dtoModulo);

            if (dtbModulo.Rows.Count == 0)
            {
                throw new HacException("M�dulo de configura��o da seguran�a n�o cadastrado.");
            }
            else
            {                
                RegistrarUsuario(false);
                RegistrarLocal(false);

                this.DtoPassport = dtoPassport;

                //Atribuo nulo a vari�vel para for�ar a recria��o com o Passport.
                _commonServices = null;
                // UnidadeLocalSetorUsuario = null;

            }
        }

        #endregion

        #region [EVENTOS]

        /// <summary>
        /// Na abertura do Form verifica se existe um valor no campo de Login se existir coloca o foco no campo de Senha, sen�o o foco vai pro campo de Login.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            if (txtUsuario.Text != string.Empty)
            {
                txtSenha.Focus();
            }
            else
            {
                txtUsuario.Focus();
            }
        }

        /// <summary>
        /// Verifica se foi digitado login e senha, ap�s isso, executa o m�todo de Autentica��o do Usu�rio fazendo uma s�rie de verifica��es e retornando o status
        /// se estiver tudo ok, � executado o metodo de Obter PassPort.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == string.Empty)
            {
                MessageBox.Show("Opera��o n�o realizada!!! \n\n Digite um usu�rio!!!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsuario.Focus();
                return;
            }
            if (txtSenha.Text == string.Empty)
            {
                UsuarioDTO dto = new UsuarioDTO();
                dto.Login.Value = txtUsuario.Text;
                DataTable dtb = Usuario.Listar(dto);
                if (dtb.Rows.Count > 0)
                {
                    dto = Usuario.Listar(dto).TypedRow(0);
                    if (dto.Senha.Value.IsNull)
                    {
                        bSenha = true;
                        PainelSenhaShow();

                        txtSenhaAtual.Text = string.Empty;
                        lblSenhaAtual.Text = "Nova Senha:";
                        txtNovaSenha.Text = string.Empty;
                        lblNovaSenha.Text = "Confirmar a Senha:";
                        lblNovaSenha.Location = new System.Drawing.Point(34, 73);

                        MessageBox.Show("Primeiro Login??? \nDigite uma senha igual nos dois campos!!!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Opera��o n�o realizada!!! \n\n Digite uma senha!!!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSenha.Focus();
                        return;
                    }
                }
                MessageBox.Show("Opera��o n�o realizada!!! \n\n Digite uma senha!!!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSenha.Focus();
                return;
            }
            try
            {
                UsuarioDTO dto = new UsuarioDTO();
                dto.Login.Value = txtUsuario.Text;
                DataTable dtb = Usuario.Listar(dto);
                if (dtb.Rows.Count > 0)
                {
                    dto = Usuario.Listar(dto).TypedRow(0);
                    if (dto.Senha.Value.IsNull)
                    {
                        bSenha = true;
                        PainelSenhaShow();

                        txtSenhaAtual.Text = string.Empty;
                        lblSenhaAtual.Text = "Nova Senha:";
                        txtNovaSenha.Text = string.Empty;
                        lblNovaSenha.Text = "Confirmar a Senha:";
                        lblNovaSenha.Location = new System.Drawing.Point(34, 73);

                        MessageBox.Show("Primeiro Login??? \nDigite uma senha igual nos dois campos!!!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                    

                    if (idTelaOrigem == 2)
                    {
                        dtoPassportAuthentication = Usuario.AutenticarParaProntuarioEletronico(Convert.ToInt32(cmbUnidade.SelectedValue),
                                                 txtUsuario.Text.ToUpper(), txtSenha.Text,
                                                 Convert.ToInt32(cmbLocal.SelectedValue),
                                                 Convert.ToInt32(cmbSetor.SelectedValue));
                        

                        IdentificacaoOk();
                        foreach (Form frmChild in MdiForm.MdiChildren)
                        {
                            if ("FrmMenuBotoes" != frmChild.Name && "FrmMenu" != frmChild.Name && "FrmLogin" != frmChild.Name && bFechaTodasAsTelas == true)
                            {
                                frmChild.Dispose();
                                frmChild.Close();
                            }
                        }
                        // MessageBox.Show("Login realizado com sucesso.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        bFechaTodasAsTelas = true;
                        Close();

                    }
                    else
                    {
                        dtoPassportAuthentication = Usuario.Autenticar(Convert.ToInt32(cmbUnidade.SelectedValue),
                                                   txtUsuario.Text.ToUpper(), txtSenha.Text,
                                                   Convert.ToInt32(cmbLocal.SelectedValue),
                                                   Convert.ToInt32(cmbSetor.SelectedValue));
                        switch (dtoPassportAuthentication.PassportAuthenticationStatus)
                        {

                            #region "Autentica��o ok"
                            case PassportAuthenticationDTO.PassportAuthenticationStatusEnum.AutenticacaoOk:
                                IdentificacaoOk();
                                foreach (Form frmChild in MdiForm.MdiChildren)
                                {
                                    if ("FrmMenuBotoes" != frmChild.Name && "FrmMenu" != frmChild.Name && "FrmLogin" != frmChild.Name && bFechaTodasAsTelas == true)
                                    {
                                        frmChild.Dispose();
                                        frmChild.Close();
                                    }
                                }
                                // MessageBox.Show("Login realizado com sucesso.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                bFechaTodasAsTelas = true;
                                Close();
                                break;
                            #endregion

                            #region "Usu�rio n�o cadastrado"
                            case PassportAuthenticationDTO.PassportAuthenticationStatusEnum.UsuarioNaoCadastrado:
                                break;
                            #endregion

                            #region "Senha inv�lida"
                            case PassportAuthenticationDTO.PassportAuthenticationStatusEnum.SenhaInvalida:
                                txtSenha.Text = string.Empty;
                                break;
                            #endregion

                            #region "Usu�rio inativo"
                            case PassportAuthenticationDTO.PassportAuthenticationStatusEnum.UsuarioInativo:
                                break;
                            #endregion

                            #region "Usu�rio bloqueado"
                            case PassportAuthenticationDTO.PassportAuthenticationStatusEnum.UsuarioBloqueado:
                                break;
                            #endregion

                            #region "Senha expirada"
                            case PassportAuthenticationDTO.PassportAuthenticationStatusEnum.SenhaExpirada:
                                txtSenhaAtual.Text = string.Empty;
                                txtNovaSenha.Text = string.Empty;
                                if (!bSenha)
                                {
                                    bSenha = true;
                                    PainelSenhaShow();
                                }
                                else
                                {
                                    bSenha = false;
                                    PainelSenhaHide();
                                }

                                break;
                            #endregion

                            #region "Trocar Senha"
                            case PassportAuthenticationDTO.PassportAuthenticationStatusEnum.NecessarioTrocarSenha:
                                txtSenhaAtual.Text = string.Empty;
                                txtNovaSenha.Text = string.Empty;

                                if (!bSenha)
                                {
                                    bSenha = true;
                                    PainelSenhaShow();
                                }
                                else
                                {
                                    bSenha = false;
                                    PainelSenhaHide();
                                }

                                break;
                            #endregion

                            #region "Verifica se o pertence a unidade informada"
                            case PassportAuthenticationDTO.PassportAuthenticationStatusEnum.UsuarioNaoPertenceAUnidade:
                                break;
                            #endregion

                            #region "Verifica se o pertence ao local informado"
                            case PassportAuthenticationDTO.PassportAuthenticationStatusEnum.UsuarioNaoPertenceALocal:
                                break;
                            #endregion

                            #region "Verifica se o pertence ao setor informado"
                            case PassportAuthenticationDTO.PassportAuthenticationStatusEnum.UsuarioNaoPerteceASetor:
                                break;
                            #endregion

                            default:
                                MessageBox.Show("Opera��o n�o realizada!!! \n Ocorreu um problema desconhecido ao logar no sistema", "SGS - Sistema de Gest�o de Sa�de", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                    }
            }
            catch (HacException ex)
            {
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Opera��o n�o realizada!!! Ocorreu um erro no login!!! \n\n Erro {0}.", ex.Message), "SGS - Sistema de Gest�o de Sa�de", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void asd()
        //{
        //    try
        //    {

        //        var url = "https://integration-gateway-prod-8xgj7n6l.uc.gateway.dev/integration/whatsapp/sendTemplateMessage?key=AIzaSyCO-Axgq4KC6Cv6QmzCWjjlKVDYT4c-uDY";
        //        Console.WriteLine();
        //        Console.WriteLine(url);
        //        var payload = new LiftyPayLoad
        //        {
        //            destination = "55" + telefone,
        //            templateName = template
        //        };

        //        payload.parameters = new List<LiftyPayLoad.Parameter>();
        //        foreach (var item in pars)
        //        {
        //            payload.parameters.Add(new LiftyPayLoad.Parameter { text = item });
        //        }
                 
        //        var client = new RestClient(url);

        //        var json = JsonConvert.SerializeObject(payload);

        //        var request = new RestRequest();

        //        request.Method = Method.Post;
        //        request.AddBody(json, contentType: "application/json");
        //        request.AddHeader("Content-Type", "application/json");
        //        var response = client.ExecuteAsync(request).Result;
        //        Console.WriteLine("Response:");
        //        Console.WriteLine(response.Content);

        //        if (response.ErrorException != null)
        //        {
        //            throw response.ErrorException;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.BackgroundColor = ConsoleColor.DarkRed;
        //        Console.ForegroundColor = ConsoleColor.White;
        //        Console.WriteLine("Error: " + ex.Message);
        //        if (ex.InnerException != null)
        //        {
        //            Console.WriteLine(ex.InnerException.Message);
        //        }

        //    }
        //}
        /// <summary>
        /// Fecha ou encerra a aplica��o
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (bOrigemDispensacao)
            {
                dtoPassportAuthentication = null;
                Close();
            }
            else
            {
                Application.Exit();
            }            
        }
        
        /// <summary>
        /// Quando clicado no bot�o de Login, verifica qual campo ainda esta vazio e coloca o foco do teclado no campo vazio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_GotFocus(object sender, EventArgs e)
        {
            if (txtUsuario.Text == string.Empty) {
                txtUsuario.Focus();}
            else if (txtSenha.Text == string.Empty) { txtSenha.Focus(); }
        }

        /// <summary>
        /// Executa a rotina de Salvar Nova Senha se digitarem a tecla "ENTER" do teclado quando o foco estiver no TextBox de Nova Senha.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNovaSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se teclar enter quando tiver focado na nova senha, executa a rotina que salva a nova senha
            if (e.KeyChar == 13) btnSalvarNovaSenha_Click(sender, e);
        }

        /// <summary>
        /// Seta o Foco no Campo Senha Atual se ele estiver vazio ou no Nova Senha se ele estiver vazio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalvarNovaSenha_GotFocus(object sender, EventArgs e)
        {
            if (txtSenhaAtual.Text == string.Empty) { txtSenhaAtual.Focus(); }
            else if (txtNovaSenha.Text == string.Empty) { txtNovaSenha.Focus(); }
        }

        /// <summary>
        /// Executa a rotina de Login do Usuario se digitarem a tecla "ENTER" do teclado quando o foco estiver no TextBox de Senha.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se teclar enter quando tiver focado na senha, executa a rotina que processa o login
            if (e.KeyChar == 13) btnLogin_Click(sender, e);
        }
        
        #endregion              

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            txtSenha.Text = "12345678";
            btnLogin_Click(sender, e);
        }

        private void cmbUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbLocal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbSetor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblRecuperarSenha_Click(object sender, EventArgs e)
        {
            string url = Usuario.GeraToken(txtUsuario.Text, true, false);
            System.Diagnostics.Process.Start("msedge.exe", url);
        }
    }
}