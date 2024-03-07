using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Hac.Windows.Forms.Controls;
using Hac.Windows.Forms.Controls.Exceptions;
using HacFramework.Windows.Helpers;
using HospitalAnaCosta.Framework;
using MVC = HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Cadastro.Interface;
using HospitalAnaCosta.Services.Produto.Interface;
using HospitalAnaCosta.Services.Seguranca.Interface;
using HospitalAnaCosta.Services.Seguranca.DTO;
//using HospitalAnaCosta.Services.Email.Interface;

using HospitalAnaCosta.Framework;
using FuncionalidadeDTO = HospitalAnaCosta.Services.Seguranca.DTO.FuncionalidadeDTO;

using System.Deployment.Application;
using System.Reflection;
using System.ComponentModel;
using System.Reflection;
using System.IO;
using System.Xml;
using System.Net.Mail;
using System.Configuration;
using System.Data.OracleClient;
using System.Collections.Specialized;
using System.Net;

namespace Hac.Windows.Forms
{
    public partial class FrmBase : Form
    {
        protected const string msgsucesso = "Operação realizada com sucesso!";
        protected const string msgexcluir = "Deseja excluir o registro selecionado?";
        protected const string msgselecionar = "Nenhum registro selecionado!";

        public DateTime DateTimeServ
        {
            get { return Log.DataHoraServ(); }
        }

        public string TimeZone
        {
            get { return Log.TimeZone(); }
        }

        public bool TimeZoneInvalido
        {
            get
            {
                var invalid = DateTime.Now.ToString("O").Substring(DateTime.Now.ToString("O").Length - 6, 6) != TimeZone;
                if (!invalid)
                {
                    invalid = System.TimeZone.CurrentTimeZone.IsDaylightSavingTime(new DateTime(2012, 12, 12));                    
                }
                return invalid;
            }
        }

        public static decimal Truncate(decimal d, int digits, MidpointRounding mid = MidpointRounding.AwayFromZero, bool umCentavo = false)
        {
            decimal r = Math.Round(d, digits);

            if (d > 0 && r > d)
            {
                r = r - new decimal(1, 0, 0, false, Convert.ToByte(digits));
            }
            else if (d < 0 && r < d)
            {
                r = r + new decimal(1, 0, 0, false, Convert.ToByte(digits));
            }

            if (umCentavo &&  d > 0 && r == 0)
            {
                r = 0.01m;
            }

            return r;
        }


        public void VerificarTimeZone()
        {
            try
            {
                if (TimeZoneInvalido)
                {
                    NameValueCollection appSettings = ConfigurationManager.AppSettings;
                    string host = appSettings["HOST_ORIGEM_EMAIL_SGS"];
                    string porta = appSettings["PORTA_HOST_ORIGEM_EMAIL_SGS"];
                    string pass = appSettings["EMAIL_ORIGEM_SGS_PASSWORD"]; //""(producao) e senha do pedro no homolog;

                    string emailOrigem = appSettings["EMAIL_ORIGEM_SGS"];
                    string emailDestino = appSettings["EMAIL_DESTINO_CORREIO"];
                    string emailDestinoCopia = appSettings["EMAIL_DESTINO_REATIVACAO_PESSOA"];

                    string ipAddress = "";
                    foreach (var s in Dns.GetHostAddresses(Dns.GetHostName()))
                    {
                        ipAddress += "<br/>" + s;
                    }


                    var htmlAviso = string.Format("<strong>CLIENT TIMEZONE:</strong><br/>{6}<p/>" +
                        "<strong>SERVER TIMEZONE:</strong><br/>{5}<p/><strong>MACHINENAME:</strong>" +
                        "<br/>{0}<p/><strong>OS:</strong><br/>{1}<p/><strong>USERNAME:</strong>" +
                        "<br/>{3} {4}<p/><strong>IPs:</strong>{2}" +
                        "<p/><strong>DAYLIGHT SAVINGS ENABLED:</strong> {7}",
                            Environment.MachineName, 
                            Environment.OSVersion, 
                            ipAddress, 
                            Environment.UserName, 
                            (!string.IsNullOrEmpty(Environment.UserDomainName) ? Environment.UserDomainName : ""), 
                            TimeZone,  
                            DateTime.Now.ToString("O").Substring(DateTime.Now.ToString("O").Length - 6, 6),
                            System.TimeZone.CurrentTimeZone.IsDaylightSavingTime(new DateTime(2012, 12, 12)));


                    enviaEmail(host, porta, pass, emailOrigem, "tisgs@anacosta.com.br", "", "INVALID TIMEZONE", htmlAviso);
                    enviaEmail(host, porta, pass, emailOrigem, "suporte@anacosta.com.br", "", "INVALID TIMEZONE", htmlAviso);
                }
            }
            catch (Exception)
            {

                
            }

            
        }

        private ModoEdicao modotela;

        public FrmBase()
        {
            InitializeComponent();
        }

        private static PassportDTO dtoPassport;
        public static PassportDTO DtoPassport
        {
            get { return dtoPassport; }
            set { dtoPassport = value; }
        }

        private static Form mdiForm;
        public static Form MdiForm
        {
            get { return FrmBase.mdiForm; }
            set { FrmBase.mdiForm = value; }
        }

        public static Form VerificarSeFormJaAberto(string nomeFormulario)
        {
            Form form = null;

            foreach (Form frmChild in mdiForm.MdiChildren)
            {
                if (nomeFormulario == frmChild.Name)
                {
                    form = frmChild;
                }
            }
            return form;
        }

        public static void AbrirWebResultadoDeExames()
        {
            AbrirWeb("Atendimento_SADT/atesadt_historico_paciente.aspx", 1027, 605, "Resultado de Exames", false, true);
        }
        public static void AbrirWebResultadoDeExames(string nomePaciente, string dataNascimento, string idtAtendimento)
        {
            AbrirWeb(string.Format("Atendimento_SADT/atesadt_historico_paciente.aspx?nomepaciente={0}&dataNascimento={1}&idtAtendimento={2}",
                nomePaciente,dataNascimento,idtAtendimento), 1027, 605, "Resultado de Exames", false, true);
        }

        public static void AbrirWebResponsavel(string idtIdentificacao, string idtParcela)
        {
            AbrirWeb("faturamento/fat_envio.aspx?origem=Responsavel&idtAtendimento=" + idtIdentificacao + "&parcela=" + idtParcela, 860, 500, "Faturamento Particular", false);
        }

        protected static void AbrirWeb(string url, int width = 1024, int height = 720, string title = "",bool hideMenu = false, bool explorer = false)
        {
            var frmWeb = AbrirWeb_(url, width, height, title, hideMenu, explorer);
            if(frmWeb != null)
            {
                AbrirFormularioDialog(frmWeb);
            }            
        }
        
        private static Form AbrirWeb_(string url, int width = 1024, int height = 720, string title = "", bool hideMenu = false, bool explorer = false)
        {
            if (ConfigurationManager.AppSettings["ServidorServiços"].ToLower().Contains("svchac"))
                url = "http://sgs.anacosta.com.br/" + url;
            else if (ConfigurationManager.AppSettings["ServidorServiços"].ToLower().Contains("devhac"))
                url = "http://devhac05.anacosta.com.br/sgs_homolog/" + url;
            else
                url = "http://localhost:8080/" + url;

            var transfer = string.Format("{0};{1};{2};{3};{4};{5};{6}",
                                        DtoPassport.Unidade.Idt.Value,
                                        DtoPassport.LocalAtendimento.Idt.Value,
                                        DtoPassport.Setor.Idt.Value,
                                        DtoPassport.Usuario.Login.Value,
                                        DtoPassport.Usuario.Senha.Value,
                                        DtoPassport.Usuario.Idt.Value,
                                        url);

            var transferEncoded = Base64Encode(transfer);
            var urlTranfer = "";

            if (ConfigurationManager.AppSettings["ServidorServiços"].ToLower().Contains("svchac"))
                urlTranfer = string.Format("http://sgs.anacosta.com.br/login.aspx?transfer={0}", transferEncoded);
            else if (ConfigurationManager.AppSettings["ServidorServiços"].ToLower().Contains("devhac"))
                urlTranfer = string.Format("http://devhac05.anacosta.com.br/sgs_homolog/login.aspx?transfer={0}", transferEncoded);
            else
            {
                // urlTranfer = string.Format("http://devhac05.anacosta.com.br/sgs_homolog/login.aspx?transfer={0}", transferEncoded);
                urlTranfer = string.Format("http://localhost:8080/login.aspx?transfer={0}", transferEncoded);
            }

            if (explorer)
            {
                System.Diagnostics.Process.Start("msedge.exe", urlTranfer);
                return null;
            }
            else
            {
                var frmWeb = new Controls.Forms.FrmWeb(urlTranfer, title, width, height, hideMenu);
                return frmWeb;
            }
        }

        public static Form AbrirWebForm(string url, int width = 1024, int height = 720, string title = "", bool hideMenu = false)
        {
            var frmWeb = AbrirWeb_(url, width, height, title, hideMenu);
            return frmWeb;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static void AbrirFormularioReportViewer(Form form)
        {
            //Form frmChild = VerificarSeFormJaAberto(form.Name);
            //if (frmChild == null)
            //{
            //    if (!form.IsMdiContainer)
            //    {
            //        form.MdiParent = FrmBase.MdiForm;
                    form.ShowDialog();
            //    }
            //}
            //else
            //{
            //    frmChild.BringToFront();
            //}
        }

        public static void AbrirFormulario(Form form, bool verificaAberto)
        {
            Form frmChild = null;

            if (verificaAberto)
            {
                frmChild = VerificarSeFormJaAberto(form.Name);
            }

            if (frmChild == null)
            {
                // utilizado para não precisar criar a funcionalidade quando determinada tela ainda estiver em desenvolvimento (DEBUG)
                bool bValidarAcessoUsuario = false;
#if DEBUG
                bValidarAcessoUsuario =
                    (System.Configuration.ConfigurationManager.AppSettings["ServidorServiços"].ToString().ToUpper().Equals("LOCALHOST")) ;//||
                   // (System.Configuration.ConfigurationManager.AppSettings["ServidorServiços"].ToString().ToUpper().Equals("DEVHAC06")) ||
                   // (System.Configuration.ConfigurationManager.AppSettings["ServidorServiços"].ToString().ToUpper().Equals("DEVHAC04"));
#endif

                if (bValidarAcessoUsuario ||
                    (FrmBase.VerificarAcessoUsuario(form.Name, FrmBase.DtoPassport)))
                {
                    if (!form.IsMdiContainer)
                    {
                        form.MdiParent = FrmBase.MdiForm;
                        form.Show();
                    }
                }
            }
            else
            {
                frmChild.BringToFront();
            }
        }

        public static void AbrirFormulario(Form form, bool verificaAberto, bool validaAcessoUsuario)
        {
            Form frmChild = null;

            if (verificaAberto)
            {
                frmChild = VerificarSeFormJaAberto(form.Name);
            }

            if (frmChild == null)
            {
                // utilizado para não precisar criar a funcionalidade quando determinada tela ainda estiver em desenvolvimento (DEBUG)
                bool bValidarAcessoUsuario = false;
#if DEBUG
                bValidarAcessoUsuario =
                    (System.Configuration.ConfigurationManager.AppSettings["ServidorServiços"].ToString().ToUpper().Equals("LOCALHOST"));// ||
                // (System.Configuration.ConfigurationManager.AppSettings["ServidorServiços"].ToString().ToUpper().Equals("DEVHAC06")) ||
                  //  (System.Configuration.ConfigurationManager.AppSettings["ServidorServiços"].ToString().ToUpper().Equals("DEVHAC04"));
#endif

                if (validaAcessoUsuario)
                {
                    if (bValidarAcessoUsuario ||
                   (FrmBase.VerificarAcessoUsuario(form.Name, FrmBase.DtoPassport)))
                    {
                        if (!form.IsMdiContainer)
                        {
                            form.MdiParent = FrmBase.MdiForm;
                            form.Show();
                        }
                    }
                }
                else
                {
                    if (!form.IsMdiContainer)
                    {
                        form.MdiParent = FrmBase.MdiForm;
                        form.Show();
                    }
                }
            }
            else
            {
                frmChild.BringToFront();
            }
        }

        public static void AbrirFormulario(Form form)
        {
            AbrirFormulario(form, true);
        }

        public static void AbrirFormularioDialog(Form form)
        {
            Form frmChild = VerificarSeFormJaAberto(form.Name);
            if (frmChild == null)
            {
                // utilizado para não precisar criar a funcionalidade quando determinada tela ainda estiver em desenvolvimento (DEBUG)
                bool bValidarAcessoUsuario = false;
#if DEBUG
                bValidarAcessoUsuario =
                    (System.Configuration.ConfigurationManager.AppSettings["ServidorServiços"].ToString().ToUpper().Equals("LOCALHOST")) ;//||
                  //  (System.Configuration.ConfigurationManager.AppSettings["ServidorServiços"].ToString().ToUpper().Equals("DEVHAC06")) ||
                 //   (System.Configuration.ConfigurationManager.AppSettings["ServidorServiços"].ToString().ToUpper().Equals("DEVHAC04"));
#endif

                if (bValidarAcessoUsuario || (form.Name == "FrmWeb") || (form.Name == "FrmWebPopup") || (FrmBase.VerificarAcessoUsuario(form.Name, FrmBase.DtoPassport)))
                {
                    if (!form.IsMdiContainer)
                    {
                        form.ShowDialog();
                    }
                }
            }
            else
            {
                frmChild.BringToFront();
            }
        }
        public static void AbrirFormularioDialog(Form form, PassportDTO dtoPassportTemp)
        {
            Form frmChild = VerificarSeFormJaAberto(form.Name);
            if (frmChild == null)
            {
                bool bValidarAcessoUsuario = false;

                if (bValidarAcessoUsuario || (form.Name == "FrmWeb") || (form.Name == "FrmWebPopup") || (FrmBase.VerificarAcessoUsuario(form.Name, dtoPassportTemp)))
                {
                    if (!form.IsMdiContainer)
                    {
                        form.ShowDialog();
                    }
                }
            }
            else
            {
                frmChild.BringToFront();
            }
        }

        //utilizado para quem tem funcionalidade somente pesquisa
        public static void AbrirFormularioDialogSemVerificarPermissao(Form form, PassportDTO dtoPassportTemp)
        {
            Form frmChild = VerificarSeFormJaAberto(form.Name);
            if (frmChild == null)
            {
                if (!form.IsMdiContainer)
                {
                    form.ShowDialog();
                }
            }
            else
            {
                frmChild.BringToFront();
            }
        }
        /// <summary>
        /// This will create a Application Reference file on the users desktop
        /// if they do not already have one when the program is loaded.
        //    If not debugging in visual studio check for Application Reference
        //    #if (!debug)
        //        CheckForShortcut();
        //    #endif
        /// </summary>
        public static void CriarAtalhoDesktop()
        {
            ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;


            if (ad.IsFirstRun)
            {
                Assembly code = Assembly.GetExecutingAssembly();

                string company = string.Empty;
                string description = string.Empty;

                if (Attribute.IsDefined(code, typeof(AssemblyCompanyAttribute)))
                {
                    AssemblyCompanyAttribute ascompany = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(code,
                        typeof(AssemblyCompanyAttribute));
                    company = ascompany.Company;
                }

                if (Attribute.IsDefined(code, typeof(AssemblyDescriptionAttribute)))
                {
                    AssemblyDescriptionAttribute asdescription = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(code,
                        typeof(AssemblyDescriptionAttribute));
                    description = asdescription.Description;
                }

                company = "Sistema de Faturamento";
                description = "Sistema de Faturamento";

                if (company != string.Empty && description != string.Empty)
                {
                    string desktopPath = string.Empty;
                    desktopPath = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                        "\\", description, ".appref-ms");

                    string shortcutName = string.Empty;
                    shortcutName = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Programs),
                        "\\", company, "\\", description, ".appref-ms");

                    System.IO.File.Copy(shortcutName, desktopPath, true);
                }

            }
        }

        public void CarregarGridMantendoOrdenacao(ref HacDataGridView dgv, DataTable dtb)
        {
            DataGridViewColumn ordemSelecionada = dgv.SortedColumn;
            string sdirecaoSelecionada = dgv.SortOrder.ToString();
            ListSortDirection direcaoSelecionada = sdirecaoSelecionada == "Ascending" ? ListSortDirection.Ascending : ListSortDirection.Descending;
            dgv.DataSource = dtb;
            if (ordemSelecionada != null)
                dgv.Sort(ordemSelecionada, direcaoSelecionada);

        }

        #region MAIL
        public void enviaEmail(string host, string porta, string pass, string emailOrigem, string emailDestino, string emailDestinoCopia, string assunto, string mensagem)
        {
            try
            {
                //Tools tools = new Tools();
                //tools.enviaEmail(assunto, mensagem);

                //em produção os servidores estão liberados para relay na porta 25      
                Email.EnviaEmail(host, porta, pass, emailOrigem, emailDestino, emailDestinoCopia, assunto, mensagem);
            }
            catch (Exception)
            {
                //local e homolog autenticam pelo exchange pora 587(usuário e senha no appconfig)
                // É NECESSÁRIO ALTERAR A SENHA NO APPCONFIG QUANDO FOR TESTAR POIS UTILIZAMOS O USER PEDRO.CARVALHO@ANACOSTA POR FALTA DE LICENÇA
                Email.EnviaEmail(host, porta, "", emailOrigem, emailDestino, emailDestinoCopia, assunto, mensagem);
            }
        }
        public void enviaEmail(string host, string porta, string pass, string emailOrigem, string emailOrigemMostrar, string emailDestino, string emailDestinoCopia, string emailDevolucao, string assunto, string mensagem)
        {
            try
            {
                //em produção os servidores estão liberados para relay na porta 25      
                Email.EnviaEmail(host, porta, pass, emailOrigem, emailOrigemMostrar, emailDestino, emailDestinoCopia, emailDevolucao, assunto, mensagem);
            }
            catch (Exception)
            {
                //local e homolog autenticam pelo exchange pora 587(usuário e senha no appconfig)
                // É NECESSÁRIO ALTERAR A SENHA NO APPCONFIG QUANDO FOR TESTAR POIS UTILIZAMOS O USER PEDRO.CARVALHO@ANACOSTA POR FALTA DE LICENÇA
                Email.EnviaEmail(host, porta, string.Empty, emailOrigem, emailOrigemMostrar, emailDestino, emailDestinoCopia, emailDevolucao, assunto, mensagem);
            }
        }
        #endregion

        #region PROPRIEDADES PÚBLICAS

        private string titulo = "SGS - Sistema de Gestão de Saúde";

        /// <summary>
        /// Ajusta Modo Atual da Tela
        /// </summary>
        public ModoEdicao ModoTela
        {
            get { return modotela; }
            set { modotela = value; }
        }

        /// <summary>
        /// Titulo do Sistema
        /// </summary>
        public virtual string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        #endregion

        #region FUNÇÕES PÚBLICAS

        public void ShowError(HacException exception)
        {
            MessageBox.Show(exception.Message, "Erro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void AjustaModoTela(ModoEdicao e)
        {
            this.Text = this.Titulo;

            switch (e)
            {
                case ModoEdicao.Inicio:
                    this.ModoTela = ModoEdicao.Inicio;
                    break;
                case ModoEdicao.Novo:
                    this.ModoTela = ModoEdicao.Novo;
                    break;
                case ModoEdicao.Edicao:
                    this.ModoTela = ModoEdicao.Edicao;
                    foreach (Control ctr in this.Controls)
                    {
                        if (ctr is HacToolStrip)
                        {
                            ((HacToolStrip)ctr).Controla(Evento.eEditar);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Controla estado dos Objetos
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public void Controla(Evento e)
        {
            this.ControlarObjetos(e, this.Controls);
        }

        private StringBuilder Linhas;

        public bool ValidaObjeto(Evento e)
        {
            Linhas = new StringBuilder();
            ValidaObjeto(e, this.Controls);

            if (Linhas.Length > 0)
            {
                MessageBox.Show(Linhas.ToString(), "SGS - Validação de Informações", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Faz Validação dos Objetos ( FrmBase )
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public void ValidaObjeto(Evento e, Control.ControlCollection controls)
        {
            // chamada da toolstrip
            foreach (Control ObjFilhos in controls)
            {
                try
                {
                    CommonCtrl.ValidaObjeto(e, ObjFilhos);
                }
                catch (HacRequiredFieldException ex)
                {
                    Linhas.AppendLine(string.Format(" >> {0}", ex.Message));
                }
                catch (HacException ex)
                {
                    Linhas.AppendLine(string.Format(" >> {0}", ex.Message));
                }

                if (ObjFilhos.HasChildren && ObjFilhos.Visible && ObjFilhos.Enabled)
                    this.ValidaObjeto(e, ObjFilhos.Controls);
            }
        }

        #endregion

        #region FUNÇÕES PÚBLICAS (UTILITÁRIOS)

        public bool IsNumber(string valor)
        {
            decimal valorConvertido;
            return Decimal.TryParse(valor, out valorConvertido);
        }

        public bool IsDate(string valor)
        {
            if (!string.IsNullOrEmpty(valor))
            {
                DateTime retorno;
                return DateTime.TryParse(valor, out retorno);
            }

            return false;
        }

        protected void LimparControles(Control.ControlCollection controls)
        {
            foreach (Control ctr in controls)
            {
                try
                {
                    if (ctr.HasChildren) LimparControles(ctr.Controls);
                    if (ctr is HacTextBox) ((HacTextBox)ctr).Text = string.Empty;
                    if (ctr is HacComboBox) ((HacComboBox)ctr).SelectedValue = "-1";
                    if (ctr is HacCheckBox) ((HacCheckBox)ctr).Checked = false;
                    if (ctr is HacRadioButton) ((HacRadioButton)ctr).Checked = false;
                    if (ctr is HacMaskedTextBox) ((HacMaskedTextBox)ctr).Text = string.Empty;
                    if (ctr is HacDataGridView) ((HacDataGridView)ctr).DataSource = null;
                    if (ctr is HacConvenio) ((HacConvenio)ctr).Inicializar();
                    if (ctr is HacPlano) ((HacPlano)ctr).Inicializar();
                    //if (ctr is HacProcedimento) ((HacProcedimento)ctr).Inicializar();
                    if (ctr is HacProfissionalCorpoClinico) ((HacProfissionalCorpoClinico)ctr).Inicializar();
                    if (ctr is HacProfissionalSolicitante) ((HacProfissionalSolicitante)ctr).Inicializar();
                    if (ctr is HacDecimalTextBox) ((HacDecimalTextBox)ctr).LimparTextBox();
                }
                catch (Exception)
                {
                }
            }
        }
        protected void LimparTextBoxs(Control.ControlCollection controls)
        {
            foreach (Control ctr in controls)
            {
                if (ctr.HasChildren) LimparTextBoxs(ctr.Controls);
                if (ctr is HacTextBox) ((HacTextBox)ctr).Text = string.Empty;
                if (ctr is HacMaskedTextBox) ((HacMaskedTextBox)ctr).Text = string.Empty;
                if (ctr is HacDecimalTextBox) ((HacDecimalTextBox)ctr).LimparTextBox();
                if (ctr is HacCheckBox) ((HacCheckBox)ctr).Checked = false;
            }
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
                if (ctr is HacDataGridView) ((HacDataGridView)ctr).Enabled = habilitar;
                if (ctr is Button) ((Button)ctr).Enabled = habilitar;
                if (ctr is CheckedListBox) ((CheckedListBox)ctr).Enabled = habilitar;
            }
        }

        public static bool VerificarAcessoUsuario(string nomeFormulario, PassportDTO dto)
        {
            return VerificarAcessoUsuario(nomeFormulario, dto, true);
        }

        public static bool VerificarAcessoUsuario(string nomeFormulario, PassportDTO dto, bool exibeMensagem)
        {
            bool acessoFuncionalidadeUsuario = false;
            if (dto != null)
            {
                if (dto.Funcionalidades.Count > 0)
                {
                    try
                    {
                        foreach (KeyValuePair<int, FuncionalidadeDTO> funcionalidades in dto.Funcionalidades)
                        {
                            if (funcionalidades.Value.NomePagina.Value == nomeFormulario) //|| funcionalidades.Value.NomePagina.Value.ToString().ToUpper()+"_SOMENTEPESQUISA" == nomeFormulario)
                            {
                                acessoFuncionalidadeUsuario = true;
                            }
                        }
                    }
                    catch (HacException ex)
                    {
                        if (exibeMensagem)
                            MessageBox.Show(ex.Message, "SGS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        acessoFuncionalidadeUsuario = false;
                    }
                }
                else
                {
                    if (exibeMensagem)
                        MessageBox.Show("Nenhuma funcionalidade cadastrada para este usuário!", "SGS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    acessoFuncionalidadeUsuario = false;
                }

                if (!acessoFuncionalidadeUsuario)
                {
                    if (exibeMensagem)
                        MessageBox.Show("O usuário não tem permissão para acessar este formulário!", "SGS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            return acessoFuncionalidadeUsuario;
        }

        public static string RemoveAcentosStatic(string str)
        {
            //Para usar no HacBuscaPaciente
            FrmBase frm = new FrmBase();
            return frm.RemoveAcentos(str);
        }

        public string RemoveAcentos(string str)
        {
            string acentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç ";
            string equivalentes = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc ";
            for (int i = 0; i < acentos.Length; i++)
                str = str.Replace(acentos[i].ToString(), equivalentes[i].ToString()).Trim();

            return str;
        }

        /// <summary>
        /// Permite apenas a digitação de letras e espaço
        /// </summary>
        /// <param name="txt">TextBox</param>
        /// <param name="e">KeyPressEventArgs</param>
        /// <returns>bool</returns>
        public static bool SoLetras(TextBox txt, KeyPressEventArgs e)
        {
            bool retorno = false;

            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 32)
            {
                if (e.KeyChar != 8)
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            else
            {
                retorno = false;
            }

            return retorno;
        }

        public static bool SoNumeros(TextBox txt, KeyPressEventArgs e)
        {
            bool retorno = false;
            if (!char.IsNumber(e.KeyChar))
            {
                if (e.KeyChar != 8)
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            else
            {
                retorno = false;
            }
            return retorno;
        }


        public DataSet ConvertXMLToDataSet(string xmlData)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataSet xmlDS = new DataSet();
                stream = new StringReader(xmlData);

                reader = new XmlTextReader(stream);
                xmlDS.ReadXml(reader);
                return xmlDS;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (reader != null) reader.Close();
            }
        }

        public DataTable ConvertXMLToDataTable(string xmlData)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataTable xmlDS = new DataTable();
                stream = new StringReader(xmlData);

                reader = new XmlTextReader(stream);
                xmlDS.ReadXml(reader);
                return xmlDS;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (reader != null) reader.Close();
            }
        }

        public string ConvertDataSetToXML(DataSet xmlDS)
        {
            MemoryStream stream = null;
            XmlTextWriter writer = null;
            try
            {
                stream = new MemoryStream();
                writer = new XmlTextWriter(stream, Encoding.Unicode);

                xmlDS.WriteXml(writer);
                int count = (int)stream.Length;
                byte[] arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);
                UnicodeEncoding utf = new UnicodeEncoding();
                return utf.GetString(arr).Trim();
            }
            catch
            {
                return String.Empty;
            }
            finally
            {
                if (writer != null) writer.Close();
            }
        }

        #endregion

        #region FUNÇÕES PRIVADAS

        private void ControlarObjetos(Evento e, Control.ControlCollection controls)
        {
            foreach (Control objFilho in controls)
            {
                CommonCtrl.Controla(e, objFilho);
                if (objFilho.HasChildren && objFilho.Visible) this.ControlarObjetos(e, objFilho.Controls);
            }
        }

        #endregion

        #region EVENTOS

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.AjustaModoTela(ModoEdicao.Inicio);

            // caso uma das combinações IISHAC01/ORAPROD ou DEVHAC07/DESENV não seja respeitada, sai do sistema
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                if ((System.Deployment.Application.ApplicationDeployment.CurrentDeployment.UpdateLocation.Host.ToUpper().Equals("IISHAC01") &&
                    !System.Configuration.ConfigurationManager.AppSettings["ServidorBD"].ToString().ToUpper().Contains("ORAPROD"))
                    ||
                      ((System.Deployment.Application.ApplicationDeployment.CurrentDeployment.UpdateLocation.Host.ToUpper().Equals("DEVHAC07.ANACOSTA.COM.BR") ||
                      System.Deployment.Application.ApplicationDeployment.CurrentDeployment.UpdateLocation.Host.ToUpper().Equals("DEVHAC06.ANACOSTA.COM.BR")) &&
                    (!System.Configuration.ConfigurationManager.AppSettings["ServidorBD"].ToString().ToUpper().Contains("SGS") &&
                     !System.Configuration.ConfigurationManager.AppSettings["ServidorBD"].ToString().ToUpper().Contains("SGS2"))))
                {
                    MessageBox.Show("A versão do sistema em uso está desatualizada. O sistema será encerrado.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
            }
        }

        #endregion

        #region COMBOS

        protected void CarregarComboFontePagadora(ComboBox cboFontePagadora)
        {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Selecione>"));
            list.Add(new ListItem("ACS", "ACS"));
            list.Add(new ListItem("HAC", "HAC"));

            cboFontePagadora.ValueMember = ListItem.FieldNames.Key;
            cboFontePagadora.DisplayMember = ListItem.FieldNames.Value;
            cboFontePagadora.DataSource = list;
            cboFontePagadora.SelectedValue = "-1";
        }

        /// <summary>
        /// Carregar Sexo
        /// </summary>
        /// <param name="cboSexo">cboSexo</param>
        protected void CarregarSexo(ComboBox cboSexo)
        {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Selecione>"));
            list.Add(new ListItem("F", "FEMININO"));
            list.Add(new ListItem("M", "MASCULINO"));

            cboSexo.ValueMember = ListItem.FieldNames.Key;
            cboSexo.DisplayMember = ListItem.FieldNames.Value;
            cboSexo.DataSource = list;
            cboSexo.SelectedValue = "-1";
        }

        /// <summary>
        /// Carregar Tipo de Email
        /// </summary>
        /// <param name="cboTipoEmail">cboSexo</param>
        protected void CarregarTipoEmail(ComboBox cboSexo)
        {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Selecione>"));
            list.Add(new ListItem("PESSOAL", "PESSOAL"));
            list.Add(new ListItem("COMERCIAL", "COMERCIAL"));
            list.Add(new ListItem("CONTATO", "CONTATO"));
            list.Add(new ListItem("OUTRO", "OUTRO"));

            cboSexo.ValueMember = ListItem.FieldNames.Key;
            cboSexo.DisplayMember = ListItem.FieldNames.Value;
            cboSexo.DataSource = list;
            cboSexo.SelectedValue = "-1";
        }

        /// <summary>
        /// Carrega uma combo a partir de um DataTable, adiciona item inicial "Selecione" e posiciona.
        /// </summary>
        /// <param name="objCombo">Controle a ser preenchido</param>
        /// <param name="dtbDados">DataTable com valores</param>
        /// <param name="nomeKey">Nome do campo Value da combo</param>
        /// <param name="nomeValue">Nome do Campo Texto da combo</param>
        public void CarregarComboComSelecione(ComboBox objCombo, DataTable dtbDados, string nomeKey, string nomeValue, bool sort = true)
        {
            if (sort)
            {
                dtbDados = (DataTable)BasicFunctions.FiltrarDataTable(string.Empty, nomeValue, dtbDados);
            }            

            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Selecione>"));

            for (int i = 0; i < dtbDados.Rows.Count; i++)
            {
                list.Add(new ListItem(dtbDados.Rows[i][nomeKey].ToString(), dtbDados.Rows[i][nomeValue].ToString()));
            }

            objCombo.ValueMember = ListItem.FieldNames.Key;
            objCombo.DisplayMember = ListItem.FieldNames.Value;
            objCombo.DataSource = list;
            objCombo.SelectedIndex = 0;
        }

        public void CarregarComboComSelecione(ComboBox objCombo, DataTable dtbDados, string nomeKey, string nomeValue1, string nomeValue2)
        {
            dtbDados = (DataTable)BasicFunctions.FiltrarDataTable(string.Empty, string.Empty, dtbDados);

            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Selecione>"));

            for (int i = 0; i < dtbDados.Rows.Count; i++)
            {
                list.Add(new ListItem(dtbDados.Rows[i][nomeKey].ToString(), dtbDados.Rows[i][nomeValue1].ToString() + " - " + dtbDados.Rows[i][nomeValue2].ToString()));
            }

            objCombo.ValueMember = ListItem.FieldNames.Key;
            objCombo.DisplayMember = ListItem.FieldNames.Value;
            objCombo.DataSource = list;
            objCombo.SelectedIndex = 0;
        }

        /// <summary>
        /// Carregar Estado Civil
        /// </summary>
        /// <param name="cboEstadoCivil">cboEstadoCivil</param>
        protected void CarregarEstadoCivil(ComboBox cboEstadoCivil)
        {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Selecione>"));
            list.Add(new ListItem("2", "CASADO"));
            list.Add(new ListItem("4", "DIVORCIADO"));
            list.Add(new ListItem("3", "SEPARADO"));
            list.Add(new ListItem("1", "SOLTEIRO"));
            list.Add(new ListItem("6", "UNIÃO ESTÁVEL"));
            list.Add(new ListItem("5", "VIUVO"));

            cboEstadoCivil.ValueMember = ListItem.FieldNames.Key;
            cboEstadoCivil.DisplayMember = ListItem.FieldNames.Value;
            cboEstadoCivil.DataSource = list;
            cboEstadoCivil.SelectedValue = "-1";
        }

        /// <summary>
        /// CarregarTipoSanguineo
        /// </summary>
        /// <param name="cboTipoSanguineo"></param>
        protected void CarregarTipoSanguineo(ComboBox cboTipoSanguineo)
        {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Selecione>"));
            list.Add(new ListItem("1", "A+"));
            list.Add(new ListItem("2", "A-"));
            list.Add(new ListItem("3", "B+"));
            list.Add(new ListItem("4", "B-"));
            list.Add(new ListItem("5", "AB+"));
            list.Add(new ListItem("6", "AB-"));
            list.Add(new ListItem("7", "O+"));
            list.Add(new ListItem("8", "O-"));

            cboTipoSanguineo.ValueMember = ListItem.FieldNames.Key;
            cboTipoSanguineo.DisplayMember = ListItem.FieldNames.Value;
            cboTipoSanguineo.DataSource = list;
            cboTipoSanguineo.SelectedValue = "-1";
        }

        protected void CarregarComboPeriodicidade(ComboBox cboPeriodicidade)
        {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Selecione>"));
            list.Add(new ListItem("1", "MENSAL"));
            list.Add(new ListItem("2", "SEMANAL"));

            cboPeriodicidade.ValueMember = ListItem.FieldNames.Key;
            cboPeriodicidade.DisplayMember = ListItem.FieldNames.Value;
            cboPeriodicidade.DataSource = list;
            cboPeriodicidade.SelectedValue = "-1";
        }

        protected void CarregarComboTipoPagamento(ComboBox cboTipoPagamento)
        {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Selecione>"));
            list.Add(new ListItem("SOMAR", "SOMAR"));
            list.Add(new ListItem("SUBTRAIR", "SUBTRAIR"));
            list.Add(new ListItem("SUBSTITUIR", "SUBSTITUIR"));

            cboTipoPagamento.ValueMember = ListItem.FieldNames.Key;
            cboTipoPagamento.DisplayMember = ListItem.FieldNames.Value;
            cboTipoPagamento.DataSource = list;
            cboTipoPagamento.SelectedValue = "-1";
        }

        protected Boolean ValidarMesAnoAnteriorInformado(string mes, string ano)
        {
            int mesAnoInformado = Convert.ToInt32(ano) * 100 + Convert.ToInt32(mes);
            int mesAnoAtual = Convert.ToInt32(DateTimeServ.Year) * 100 + Convert.ToInt32(DateTimeServ.Month);

            if (mesAnoInformado < mesAnoAtual)
            {
                return false;
            }
            return true;
        }

        protected Boolean ValidarMesAnoAnteriorInformado(DateTime data)
        {
            int intMesInformado = Convert.ToInt32(data.ToString().Split('/')[0]);
            int intAnoInformado = Convert.ToInt32(data.ToString().Split('/')[1]);

            int mesAnoInformado = intAnoInformado * 100 + Convert.ToInt32(intMesInformado);
            int mesAnoAtual = Convert.ToInt32(DateTimeServ.Year) * 100 + Convert.ToInt32(DateTimeServ.Month);

            if (mesAnoInformado < mesAnoAtual)
            {
                return false;
            }
            return true;
        }

        //protected void CarregarComboBaseCalculo(ComboBox cboTipoBaseCalculo)
        //{
        //List<ListItem> list = new List<ListItem>();
        //list.Add(new ListItem("-1", "<Selecione>"));
        //list.Add(new ListItem("VLCAL", "VALOR CALCULADO"));
        //list.Add(new ListItem("CHCNV", "C.H. - CONVÊNIO"));
        //list.Add(new ListItem("CHFIX", "C.H. - FIXO"));
        //list.Add(new ListItem("PRODU", "PRODUTIVIDADE"));
        //list.Add(new ListItem("VLFIX", "VALOR FIXO"));
        //list.Add(new ListItem("VLFIA", "VALOR FIXO POR ATENDIMENTO"));

        //cboTipoBaseCalculo.ValueMember = ListItem.FieldNames.Key;
        //cboTipoBaseCalculo.DisplayMember = ListItem.FieldNames.Value;
        //cboTipoBaseCalculo.DataSource = list;
        //cboTipoBaseCalculo.SelectedValue = "-1";
        //}

        #endregion

        #region [ Propriedades de Acesso aos Serviços de Cadastro]
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

       
        private IAssociacaoPessoaMD5 _associacaoPessoaMD5;
        protected IAssociacaoPessoaMD5 AssociacaoPessoaMD5
        {
            get
            {
                return _associacaoPessoaMD5 != null ? _associacaoPessoaMD5 : _associacaoPessoaMD5 = (IAssociacaoPessoaMD5)CommonServices.GetObject(typeof(IAssociacaoPessoaMD5));
            }
        }

        /// <summary>
        /// Guia Atendimento
        /// </summary>
        private IGuiaAtendimento _guiaAtendimento;
        protected IGuiaAtendimento GuiaAtendimento
        {
            get
            {
                return _guiaAtendimento != null ? _guiaAtendimento : _guiaAtendimento = (IGuiaAtendimento)CommonServices.GetObject(typeof(IGuiaAtendimento));
            }
        }


        private ITabelaMedica _tabelaMedica;
        protected ITabelaMedica TabelaMedica
        {
            get
            {
                return _tabelaMedica != null ? _tabelaMedica : _tabelaMedica = (ITabelaMedica)CommonServices.GetObject(typeof(ITabelaMedica));
            }

        }

        /// <summary>
        /// Exclusao Contratual
        /// </summary>
        private IExclusaoContratual _exclusaoContratual;
        protected IExclusaoContratual ExclusaoContratual
        {
            get
            {
                return _exclusaoContratual != null ? _exclusaoContratual : _exclusaoContratual = (IExclusaoContratual)CommonServices.GetObject(typeof(IExclusaoContratual));
            }
        }



        /// <summary>
        /// Atendimento Internacao Complemento
        /// </summary>
        private IPacienteAtendimento _pacienteAtendimento;
        protected IPacienteAtendimento PacienteAtendimento
        {
            get
            {
                return _pacienteAtendimento != null ? _pacienteAtendimento : _pacienteAtendimento = (IPacienteAtendimento)CommonServices.GetObject(typeof(IPacienteAtendimento));
            }
        }

        /// <summary>
        /// Atendimento
        /// </summary>
        private IAtendimento _atendimento;
        protected IAtendimento Atendimento
        {
            get
            {
                return _atendimento != null ? _atendimento : _atendimento = (IAtendimento)CommonServices.GetObject(typeof(IAtendimento));
            }
        }

        /// <summary>
        /// TipoAtendimento
        /// </summary>
        private ITipoAtendimento _tipoAtendimento;
        protected ITipoAtendimento TipoAtendimento
        {
            get
            {
                return _tipoAtendimento != null ? _tipoAtendimento : _tipoAtendimento = (ITipoAtendimento)CommonServices.GetObject(typeof(ITipoAtendimento));
            }
        }

        /// <summary>
        /// Associacao Convenio Tipo Atendimento
        /// </summary>
        private IAssociacaoConvenioTipoAtendimento _assTipoAtendimento;
        protected IAssociacaoConvenioTipoAtendimento AssTipoAtendimento
        {
            get
            {
                return _assTipoAtendimento != null ? _assTipoAtendimento : _assTipoAtendimento = (IAssociacaoConvenioTipoAtendimento)CommonServices.GetObject(typeof(IAssociacaoConvenioTipoAtendimento));
            }
        }

        /// <summary>
        /// Associacao Convenio Unidade 
        /// </summary>
        private IAssociacaoConvenioUnidade _associacaoConvenioUnidade;
        protected IAssociacaoConvenioUnidade AssociacaoConvenioUnidade
        {
            get
            {
                return _associacaoConvenioUnidade != null ? _associacaoConvenioUnidade : _associacaoConvenioUnidade = (IAssociacaoConvenioUnidade)CommonServices.GetObject(typeof(IAssociacaoConvenioUnidade));
            }
        }

        /// <summary>
        /// Associacao Convenio Unidade Local Atendimento
        /// </summary>
        private IAssociacaoConvenioUnidadeLocalAtendimento _assConvenioUnidadeLocal;
        protected IAssociacaoConvenioUnidadeLocalAtendimento AssConvenioUnidadeLocal
        {
            get
            {
                return _assConvenioUnidadeLocal != null ? _assConvenioUnidadeLocal : _assConvenioUnidadeLocal = (IAssociacaoConvenioUnidadeLocalAtendimento)CommonServices.GetObject(typeof(IAssociacaoConvenioUnidadeLocalAtendimento));
            }
        }

        /// <summary>
        /// Associacao Convenio Unidade Tipo Acomodacao
        /// </summary>
        private IAssociacaoConvenioUnidadeTipoAcomodacao _assConvenioUnidadeTpAcomodacao;
        protected IAssociacaoConvenioUnidadeTipoAcomodacao AssConvenioUnidadeTpAcomodacao
        {
            get
            {
                return _assConvenioUnidadeTpAcomodacao != null ? _assConvenioUnidadeTpAcomodacao : _assConvenioUnidadeTpAcomodacao = (IAssociacaoConvenioUnidadeTipoAcomodacao)CommonServices.GetObject(typeof(IAssociacaoConvenioUnidadeTipoAcomodacao));
            }
        }

        /// <summary>
        /// Associacao Convenio Unidade Plano Tipo Acomodacao
        /// </summary>
        private IAssociacaoConvenioUnidadePlanoTipoAcomodacao _assConvenioUnidadePlanoTipoAcomodacao;
        protected IAssociacaoConvenioUnidadePlanoTipoAcomodacao AssConvenioUnidadePlanoTipoAcomodacao
        {
            get
            {
                return _assConvenioUnidadePlanoTipoAcomodacao != null ? _assConvenioUnidadePlanoTipoAcomodacao : _assConvenioUnidadePlanoTipoAcomodacao = (IAssociacaoConvenioUnidadePlanoTipoAcomodacao)CommonServices.GetObject(typeof(IAssociacaoConvenioUnidadePlanoTipoAcomodacao));
            }
        }

        /// <summary>
        /// Associacao Unidade x Local x Especialidade x Profissional
        /// </summary>
        private IAssociacaoUnidadeLocalEspecialidadeProfissional _associacaoUCP;
        protected IAssociacaoUnidadeLocalEspecialidadeProfissional AssociacaoUCP
        {
            get
            {
                return _associacaoUCP != null ? _associacaoUCP : _associacaoUCP = (IAssociacaoUnidadeLocalEspecialidadeProfissional)CommonServices.GetObject(typeof(IAssociacaoUnidadeLocalEspecialidadeProfissional));
            }
        }

        /// <summary>
        /// Profissional
        /// </summary>
        private IProfissional _profissional;
        protected IProfissional Profissional
        {
            get
            {
                return _profissional != null ? _profissional : _profissional = (IProfissional)CommonServices.GetObject(typeof(IProfissional));
            }
        }

        /// <summary>
        /// Beneficiario
        /// </summary>
        private IBeneficiario _beneficiario;
        protected IBeneficiario Beneficiario
        {
            get
            {
                return _beneficiario != null ? _beneficiario : _beneficiario = (IBeneficiario)CommonServices.GetObject(typeof(IBeneficiario));
            }
        }

        /// <summary>
        /// Conselho Profissional
        /// </summary>
        private IConselhoProfissional _conselhoProfissional;
        protected IConselhoProfissional ConselhoProfissional
        {
            get
            {
                return _conselhoProfissional != null ? _conselhoProfissional : _conselhoProfissional = (IConselhoProfissional)CommonServices.GetObject(typeof(IConselhoProfissional));
            }
        }

        /// <summary>
        /// Profissional Solicitante
        /// </summary>
        private IProfissionalSolicitante _profissionalSolicitante;
        protected IProfissionalSolicitante ProfissionalSolicitante
        {
            get
            {
                return _profissionalSolicitante != null ? _profissionalSolicitante : _profissionalSolicitante = (IProfissionalSolicitante)CommonServices.GetObject(typeof(IProfissionalSolicitante));
            }
        }

        /// <summary>
        /// Especialidade
        /// </summary>
        private IEspecialidade _especialidade;
        protected IEspecialidade Especialidade
        {
            get
            {
                return _especialidade != null ? _especialidade : _especialidade = (IEspecialidade)CommonServices.GetObject(typeof(IEspecialidade));
            }
        }

        /// <summary>
        /// Tipo Acomodacao
        /// </summary>
        private ITipoAcomodacao _tipoAcomodacao;
        protected ITipoAcomodacao TipoAcomodacao
        {
            get
            {
                return _tipoAcomodacao != null ? _tipoAcomodacao : _tipoAcomodacao = (ITipoAcomodacao)CommonServices.GetObject(typeof(ITipoAcomodacao));
            }
        }

        /// <summary>
        /// Tipo Acomodacao ACS
        /// </summary>
        private ITipoAcomodacaoACS _tipoAcomodacaoACS;
        protected ITipoAcomodacaoACS TipoAcomodacaoACS
        {
            get
            {
                return _tipoAcomodacaoACS != null ? _tipoAcomodacaoACS : _tipoAcomodacaoACS = (ITipoAcomodacaoACS)CommonServices.GetObject(typeof(ITipoAcomodacaoACS));
            }
        }

        /// <summary>
        /// Clinica
        /// </summary>
        private IClinica _clinica;
        protected IClinica Clinica
        {
            get
            {
                return _clinica != null ? _clinica : _clinica = (IClinica)CommonServices.GetObject(typeof(IClinica));
            }
        }

        /// <summary>
        /// Convenio
        /// </summary>
        private IConvenio _convenio;
        protected IConvenio Convenio
        {
            get
            {
                return _convenio != null ? _convenio : _convenio = (IConvenio)CommonServices.GetObject(typeof(IConvenio));
            }
        }

        /// <summary>
        /// Plano
        /// </summary>
        private IPlano _plano;
        protected IPlano Plano
        {
            get
            {
                return _plano != null ? _plano : _plano = (IPlano)CommonServices.GetObject(typeof(IPlano));
            }
        }

        /// <summary>
        /// Unidade
        /// </summary>
        private HospitalAnaCosta.SGS.Cadastro.Interface.IUnidade _unidade;
        protected HospitalAnaCosta.SGS.Cadastro.Interface.IUnidade Unidade
        {
            get
            {
                return _unidade != null ? _unidade : _unidade = (HospitalAnaCosta.SGS.Cadastro.Interface.IUnidade)CommonServices.GetObject(typeof(HospitalAnaCosta.SGS.Cadastro.Interface.IUnidade));
            }
        }

        /// <summary>
        /// Local Atendimento
        /// </summary>
        private ILocalAtendimento _local;
        protected ILocalAtendimento Local
        {
            get
            {
                return _local != null ? _local : _local = (ILocalAtendimento)CommonServices.GetObject(typeof(ILocalAtendimento));
            }
        }

        /// <summary>
        /// Setor
        /// </summary>
        private ISetor _setor;
        protected ISetor Setor
        {
            get
            {
                return _setor != null ? _setor : _setor = (ISetor)CommonServices.GetObject(typeof(ISetor));
            }
        }

        /// <summary>
        /// Tipo Telefone Endereco
        /// </summary>
        private ITipoTelefoneEndereco _tipoTelefoneEndereco;
        protected ITipoTelefoneEndereco TipoTelefoneEndereco
        {
            get
            {
                return _tipoTelefoneEndereco != null ? _tipoTelefoneEndereco : _tipoTelefoneEndereco = (ITipoTelefoneEndereco)CommonServices.GetObject(typeof(ITipoTelefoneEndereco));
            }
        }

       

        /// <summary>
        /// Municipio
        /// </summary>
        private IMunicipio _municipio;
        protected IMunicipio Municipio
        {
            get
            {
                return _municipio != null ? _municipio : _municipio = (IMunicipio)CommonServices.GetObject(typeof(IMunicipio));
            }
        }

        /// <summary>
        /// Profissão
        /// </summary>
        private IProfissao _profissao;
        protected IProfissao Profissao
        {
            get
            {
                return _profissao != null ? _profissao : _profissao = (IProfissao)CommonServices.GetObject(typeof(IProfissao));
            }
        }

        /// <summary>
        /// Nacionalidade
        /// </summary>
        private INacionalidade _nacionalidade;
        protected INacionalidade Nacionalidade
        {
            get
            {
                return _nacionalidade != null ? _nacionalidade : _nacionalidade = (INacionalidade)CommonServices.GetObject(typeof(INacionalidade));
            }
        }

        /// <summary>
        /// Endereço
        /// </summary>
        private IEndereco _endereco;
        protected IEndereco Endereco
        {
            get
            {
                return _endereco != null ? _endereco : _endereco = (IEndereco)CommonServices.GetObject(typeof(IEndereco));
            }
        }

        /// <summary>
        /// Endereço
        /// </summary>
        private IAssociacaoPessoaEndereco _associacaoPessoaEndereco;
        protected IAssociacaoPessoaEndereco AssociacaoPessoaEndereco
        {
            get
            {
                return _associacaoPessoaEndereco != null ? _associacaoPessoaEndereco : _associacaoPessoaEndereco = (IAssociacaoPessoaEndereco)CommonServices.GetObject(typeof(IAssociacaoPessoaEndereco));
            }
        }

        /// <summary>
        /// Telefone
        /// </summary>
        private ITelefone _telefone;
        protected ITelefone Telefone
        {
            get
            {
                return _telefone != null ? _telefone : _telefone = (ITelefone)CommonServices.GetObject(typeof(ITelefone));
            }
        }

        /// <summary>
        /// Email
        /// </summary>
        private IAssociacaoPessoaEmail _associacaoPessoaEmail;
        protected IAssociacaoPessoaEmail AssociacaoPessoaEmail
        {
            get
            {
                return _associacaoPessoaEmail != null ? _associacaoPessoaEmail : _associacaoPessoaEmail = (IAssociacaoPessoaEmail)CommonServices.GetObject(typeof(IAssociacaoPessoaEmail));
            }
        }

        /// <summary>
        /// Endereço
        /// </summary>
        private IAssociacaoPessoaTelefone _associacaoPessoaTelefone;
        protected IAssociacaoPessoaTelefone AssociacaoPessoaTelefone
        {
            get
            {
                return _associacaoPessoaTelefone != null ? _associacaoPessoaTelefone : _associacaoPessoaTelefone = (IAssociacaoPessoaTelefone)CommonServices.GetObject(typeof(IAssociacaoPessoaTelefone));
            }
        }

        /// <summary>
        /// Escolaridade
        /// </summary>
        private IEscolaridade _escolaridade;
        protected IEscolaridade Escolaridade
        {
            get
            {
                return _escolaridade != null ? _escolaridade : _escolaridade = (IEscolaridade)CommonServices.GetObject(typeof(IEscolaridade));
            }
        }

        /// <summary>
        /// Tipo Logradouro
        /// </summary>
        private ITipoLogradouro _tipoLogradouro;
        protected ITipoLogradouro TipoLogradouro
        {
            get
            {
                return _tipoLogradouro != null ? _tipoLogradouro : _tipoLogradouro = (ITipoLogradouro)CommonServices.GetObject(typeof(ITipoLogradouro));
            }
        }

        /// <summary>
        /// UF
        /// </summary>
        private IUF _uf;
        protected IUF UF
        {
            get
            {
                return _uf != null ? _uf : _uf = (IUF)CommonServices.GetObject(typeof(IUF));
            }
        }

        /// <summary>
        /// Paciente
        /// </summary>
        private ICadastroPaciente _paciente;
        protected ICadastroPaciente Paciente
        {
            get
            {
                return _paciente != null ? _paciente : _paciente = (ICadastroPaciente)CommonServices.GetObject(typeof(ICadastroPaciente));
            }
        }

        /// <summary>
        /// Pessoa
        /// </summary>
        private ICadastroPessoa _pessoa;
        protected ICadastroPessoa Pessoa
        {
            get
            {
                return _pessoa != null ? _pessoa : _pessoa = (ICadastroPessoa)CommonServices.GetObject(typeof(ICadastroPessoa));
            }
        }

        /// <summary>
        /// Associacao Convenio Documento Local Atendimento
        /// </summary>
        private IAssociacaoConvenioDocumentoLocalAtendimento _assDocumentoConvenio;
        protected IAssociacaoConvenioDocumentoLocalAtendimento AssDocumentoConvenio
        {
            get
            {
                return _assDocumentoConvenio != null ? _assDocumentoConvenio : _assDocumentoConvenio = (IAssociacaoConvenioDocumentoLocalAtendimento)CommonServices.GetObject(typeof(IAssociacaoConvenioDocumentoLocalAtendimento));
            }
        }

        /// <summary>
        /// Motivo Obito Mulher
        /// </summary>
        private IMotivoObitoMulher _motivoObitoMulher;
        protected IMotivoObitoMulher MotivoObitoMulher
        {
            get
            {
                return _motivoObitoMulher != null ? _motivoObitoMulher : _motivoObitoMulher = (IMotivoObitoMulher)CommonServices.GetObject(typeof(IMotivoObitoMulher));
            }
        }

        /// <summary>
        /// Acessa os serviços de Tipo de Atributo do Produto
        /// </summary>
        private ICadastroConvenioValorMoedaHospitalar _cadastroConvenioValorMoedaHospitalar;
        protected ICadastroConvenioValorMoedaHospitalar CadastroConvenioValorMoedaHospitalar
        {
            get
            {
                return _cadastroConvenioValorMoedaHospitalar != null ? _cadastroConvenioValorMoedaHospitalar : _cadastroConvenioValorMoedaHospitalar = (HospitalAnaCosta.SGS.Cadastro.Interface.ICadastroConvenioValorMoedaHospitalar)CommonServices.GetObject(typeof(HospitalAnaCosta.SGS.Cadastro.Interface.ICadastroConvenioValorMoedaHospitalar));
            }
        }

        /// <summary>
        /// Acessa os serviços de Tipo de Atributo do Produto
        /// </summary>
        private IAssociacaoPlanoMaterialMedicamento _associacaoPlanoMaterialMedicamento;
        protected IAssociacaoPlanoMaterialMedicamento AssociacaoPlanoMaterialMedicamento
        {
            get
            {
                return _associacaoPlanoMaterialMedicamento != null ? _associacaoPlanoMaterialMedicamento : _associacaoPlanoMaterialMedicamento = (HospitalAnaCosta.SGS.Cadastro.Interface.IAssociacaoPlanoMaterialMedicamento)CommonServices.GetObject(typeof(HospitalAnaCosta.SGS.Cadastro.Interface.IAssociacaoPlanoMaterialMedicamento));
            }
        }

        /// <summary>
        /// CadastroCentroCusto
        /// </summary>
        private ICadastroCentroCusto _cadastroCentroCusto;
        protected ICadastroCentroCusto CadastroCentroCusto
        {
            get
            {
                return _cadastroCentroCusto != null ? _cadastroCentroCusto : _cadastroCentroCusto = (ICadastroCentroCusto)CommonServices.GetObject(typeof(ICadastroCentroCusto));
            }
        }

        /// <summary>
        /// AssociacaoUnidadeLocalSetorCCustoClassContabil
        /// </summary>
        private IAssociacaoUnidadeLocalSetorCCustoClassContabil _associacaoUnidadeLocalSetorCCustoClassContabil;
        protected IAssociacaoUnidadeLocalSetorCCustoClassContabil AssociacaoUnidadeLocalSetorCCustoClassContabil
        {
            get
            {
                return _associacaoUnidadeLocalSetorCCustoClassContabil != null ? _associacaoUnidadeLocalSetorCCustoClassContabil : _associacaoUnidadeLocalSetorCCustoClassContabil = (IAssociacaoUnidadeLocalSetorCCustoClassContabil)CommonServices.GetObject(typeof(IAssociacaoUnidadeLocalSetorCCustoClassContabil));
            }
        }

        /// <summary>
        /// AssociacaoUnidadeLocalSetorCCustoClassContabil
        /// </summary>
        private ICadastroClassificacaoContabil _cadastroClassificacaoContabil;
        protected ICadastroClassificacaoContabil CadastroClassificacaoContabil
        {
            get
            {
                return _cadastroClassificacaoContabil != null ? _cadastroClassificacaoContabil : _cadastroClassificacaoContabil = (ICadastroClassificacaoContabil)CommonServices.GetObject(typeof(ICadastroClassificacaoContabil));
            }
        }

        /// <summary>
        /// AssociacaoUnidadeLocal
        /// </summary>
        private IAssociacaoUnidadeLocal _associacaoUnidadeLocal;
        protected IAssociacaoUnidadeLocal AssociacaoUnidadeLocal
        {
            get
            {
                return _associacaoUnidadeLocal != null ? _associacaoUnidadeLocal : _associacaoUnidadeLocal = (IAssociacaoUnidadeLocal)CommonServices.GetObject(typeof(IAssociacaoUnidadeLocal));
            }
        }

        /// <summary>
        /// Motivo Alteracao Auditoria
        /// </summary>
        private IMotivoAlteracaoAuditoria _motivoAlteracaoAuditoria;
        protected IMotivoAlteracaoAuditoria MotivoAlteracaoAuditoria
        {
            get
            {
                return _motivoAlteracaoAuditoria != null ? _motivoAlteracaoAuditoria : _motivoAlteracaoAuditoria = (IMotivoAlteracaoAuditoria)CommonServices.GetObject(typeof(IMotivoAlteracaoAuditoria));
            }
        }

        /// <summary>
        /// Cadastro Faturamento Motivo Pendencia
        /// </summary>
        private ICadastroFaturamentoMotivoPendencia _cadastroFaturamentoMotivoPendencia;
        protected ICadastroFaturamentoMotivoPendencia CadastroFaturamentoMotivoPendencia
        {
            get
            {
                return _cadastroFaturamentoMotivoPendencia != null ? _cadastroFaturamentoMotivoPendencia : _cadastroFaturamentoMotivoPendencia = (ICadastroFaturamentoMotivoPendencia)CommonServices.GetObject(typeof(ICadastroFaturamentoMotivoPendencia));
            }
        }

        /// <summary>
        /// Cadastro Faturamento Motivo Pendencia
        /// </summary>
        private IAssociacaoPlanoProdutoInternacao _associacaoPlanoProdutoInternacao;
        protected IAssociacaoPlanoProdutoInternacao AssociacaoPlanoProdutoInternacao
        {
            get
            {
                return _associacaoPlanoProdutoInternacao != null ? _associacaoPlanoProdutoInternacao : _associacaoPlanoProdutoInternacao = (IAssociacaoPlanoProdutoInternacao)CommonServices.GetObject(typeof(IAssociacaoPlanoProdutoInternacao));
            }
        }

        private IAssociacaoConvenioPacote _associacaoConvenioPacote;
        protected IAssociacaoConvenioPacote AssociacaoConvenioPacote
        {
            get
            {
                return _associacaoConvenioPacote != null ? _associacaoConvenioPacote : _associacaoConvenioPacote = (IAssociacaoConvenioPacote)CommonServices.GetObject(typeof(IAssociacaoConvenioPacote));
            }
        }

        /// <summary>
        /// Pessoa
     

        private ICadastroComposicaoTaxa _cadastroComposicaoTaxa;
        protected ICadastroComposicaoTaxa CadastroComposicaoTaxa
        {
            get { return _cadastroComposicaoTaxa != null ? _cadastroComposicaoTaxa : _cadastroComposicaoTaxa = (ICadastroComposicaoTaxa)CommonServices.GetObject(typeof(ICadastroComposicaoTaxa)); }
        }

        private IPercentualCobrancaUrgenciaTipoProduto _percentualCobrancaUrgenciaTipoProduto;
        protected IPercentualCobrancaUrgenciaTipoProduto PercentualCobrancaUrgenciaTipoProduto
        {
            get { return _percentualCobrancaUrgenciaTipoProduto != null ? _percentualCobrancaUrgenciaTipoProduto : _percentualCobrancaUrgenciaTipoProduto = (IPercentualCobrancaUrgenciaTipoProduto)CommonServices.GetObject(typeof(IPercentualCobrancaUrgenciaTipoProduto)); }
        }

        private ICadastroItemPacote _cadastroItemPacote;
        protected ICadastroItemPacote CadastroItemPacote
        {
            get
            {
                return _cadastroItemPacote != null ? _cadastroItemPacote : _cadastroItemPacote = (ICadastroItemPacote)CommonServices.GetObject(typeof(ICadastroItemPacote));
            }
        }

        private ICadastroDiariaAutomaticaConvenio _cadastroDiariaAutomaticaConvenio;
        protected ICadastroDiariaAutomaticaConvenio CadastroDiariaAutomaticaConvenio
        {
            get
            {
                return _cadastroDiariaAutomaticaConvenio != null ? _cadastroDiariaAutomaticaConvenio : _cadastroDiariaAutomaticaConvenio = (ICadastroDiariaAutomaticaConvenio)CommonServices.GetObject(typeof(ICadastroDiariaAutomaticaConvenio));
            }
        }

        /// <summary>
        /// Acessa os serviços de Valor Cobrança Material Medicamento
        /// </summary>
        private IValorCobrancaMaterialMedicamento _valorCobrancaMaterialMedicamento;
        protected IValorCobrancaMaterialMedicamento ValorCobrancaMaterialMedicamento
        {
            get
            {
                return _valorCobrancaMaterialMedicamento != null ? _valorCobrancaMaterialMedicamento : _valorCobrancaMaterialMedicamento = (HospitalAnaCosta.SGS.Cadastro.Interface.IValorCobrancaMaterialMedicamento)CommonServices.GetObject(typeof(HospitalAnaCosta.SGS.Cadastro.Interface.IValorCobrancaMaterialMedicamento));
            }
        }

        /// <summary>
        /// Acessa os serviços de IConvenioProdutoEquivalencia
        /// </summary>
        private IConvenioProdutoEquivalencia _convenioProdutoEquivalencia;
        protected IConvenioProdutoEquivalencia ConvenioProdutoEquivalencia
        {
            get
            {
                return _convenioProdutoEquivalencia != null ? _convenioProdutoEquivalencia : _convenioProdutoEquivalencia = (HospitalAnaCosta.SGS.Cadastro.Interface.IConvenioProdutoEquivalencia)CommonServices.GetObject(typeof(HospitalAnaCosta.SGS.Cadastro.Interface.IConvenioProdutoEquivalencia));
            }
        }

        //
        /// <summary>
        /// Acessa os serviços de CadastroDiferencaDiariaAutomatica
        /// </summary>
        private ICadastroDiferencaDiariaAutomatica _cadastroDiferencaDiariaAutomatica;
        protected ICadastroDiferencaDiariaAutomatica CadastroDiferencaDiariaAutomatica
        {
            get
            {
                return _cadastroDiferencaDiariaAutomatica != null ? _cadastroDiferencaDiariaAutomatica : _cadastroDiferencaDiariaAutomatica = (HospitalAnaCosta.SGS.Cadastro.Interface.ICadastroDiferencaDiariaAutomatica)CommonServices.GetObject(typeof(HospitalAnaCosta.SGS.Cadastro.Interface.ICadastroDiferencaDiariaAutomatica));
            }
        }

        private ICadastroPorteAnestesico _cadastroPorteAnestesico;
        protected ICadastroPorteAnestesico CadastroPorteAnestesico
        {
            get
            {
                return _cadastroPorteAnestesico != null ? _cadastroPorteAnestesico : _cadastroPorteAnestesico = (HospitalAnaCosta.SGS.Cadastro.Interface.ICadastroPorteAnestesico)CommonServices.GetObject(typeof(HospitalAnaCosta.SGS.Cadastro.Interface.ICadastroPorteAnestesico));
            }
        }

        private ITipoTecnicaProduto _tipoTecnicaProduto;
        protected ITipoTecnicaProduto TipoTecnicaProduto
        {
            get
            {
                return _tipoTecnicaProduto != null ? _tipoTecnicaProduto : _tipoTecnicaProduto = (HospitalAnaCosta.SGS.Cadastro.Interface.ITipoTecnicaProduto)CommonServices.GetObject(typeof(HospitalAnaCosta.SGS.Cadastro.Interface.ITipoTecnicaProduto));
            }
        }

        private IViaAcesso _viaAcesso;
        protected IViaAcesso ViaAcesso
        {
            get
            {
                return _viaAcesso != null ? _viaAcesso : _viaAcesso = (HospitalAnaCosta.SGS.Cadastro.Interface.IViaAcesso)CommonServices.GetObject(typeof(HospitalAnaCosta.SGS.Cadastro.Interface.IViaAcesso));
            }
        }


        private ICadastroGrauParticipacaoTISS _grauParticipacaoTISS;
        protected ICadastroGrauParticipacaoTISS GrauParticipacaoTISS
        {
            get
            {
                return _grauParticipacaoTISS != null ? _grauParticipacaoTISS : _grauParticipacaoTISS = (HospitalAnaCosta.SGS.Cadastro.Interface.ICadastroGrauParticipacaoTISS)CommonServices.GetObject(typeof(HospitalAnaCosta.SGS.Cadastro.Interface.ICadastroGrauParticipacaoTISS));
            }
        }

        private IPercentualGrauParticipacaoProfissionalSimultanea _percentualGrauParticipacaoProfissionalSimultanea;
        protected IPercentualGrauParticipacaoProfissionalSimultanea PercentualGrauParticipacaoProfissionalSimultanea
        {
            get
            {
                return _percentualGrauParticipacaoProfissionalSimultanea != null ? _percentualGrauParticipacaoProfissionalSimultanea : _percentualGrauParticipacaoProfissionalSimultanea = (HospitalAnaCosta.SGS.Cadastro.Interface.IPercentualGrauParticipacaoProfissionalSimultanea)CommonServices.GetObject(typeof(HospitalAnaCosta.SGS.Cadastro.Interface.IPercentualGrauParticipacaoProfissionalSimultanea));
            }
        }


        private IKitMaterialMedicamento _kitMaterialMedicamento;
        protected IKitMaterialMedicamento KitMaterialMedicamento
        {
            get
            {
                return _kitMaterialMedicamento != null ? _kitMaterialMedicamento : _kitMaterialMedicamento = (IKitMaterialMedicamento)CommonServices.GetObject(typeof(IKitMaterialMedicamento));
            }
        }

        private IConvenioTabelaUtilizada _convenioTabelaUtilizada;
        protected IConvenioTabelaUtilizada ConvenioTabelaUtilizada
        {
            get
            {
                return _convenioTabelaUtilizada != null ? _convenioTabelaUtilizada : _convenioTabelaUtilizada = (IConvenioTabelaUtilizada)CommonServices.GetObject(typeof(IConvenioTabelaUtilizada));
            }
        }

        private IPlanoProduto _planoProduto;
        protected IPlanoProduto PlanoProduto
        {
            get
            {
                return _planoProduto != null ? _planoProduto : _planoProduto = (IPlanoProduto)CommonServices.GetObject(typeof(IPlanoProduto));
            }

        }

        private IPacienteAtendimentoProcedimento _pacienteAtendimentoProcedimento;
        protected IPacienteAtendimentoProcedimento PacienteAtendimentoProcedimento
        {
            get
            {
                return _pacienteAtendimentoProcedimento != null ? _pacienteAtendimentoProcedimento : _pacienteAtendimentoProcedimento = (IPacienteAtendimentoProcedimento)CommonServices.GetObject(typeof(IPacienteAtendimentoProcedimento));
            }

        }

        private IPacienteAtendimentoProcedimentoGuia _pacienteAtendimentoProcedimentoGuia;
        protected IPacienteAtendimentoProcedimentoGuia PacienteAtendimentoProcedimentoGuia
        {
            get
            {
                return _pacienteAtendimentoProcedimentoGuia != null ? _pacienteAtendimentoProcedimentoGuia : _pacienteAtendimentoProcedimentoGuia = (IPacienteAtendimentoProcedimentoGuia)CommonServices.GetObject(typeof(IPacienteAtendimentoProcedimentoGuia));
            }

        }

        private INotaFiscalMaterial _notaFiscalMaterial;
        protected INotaFiscalMaterial NotaFiscalMaterial
        {
            get
            {
                return _notaFiscalMaterial != null ? _notaFiscalMaterial : _notaFiscalMaterial = (INotaFiscalMaterial)CommonServices.GetObject(typeof(INotaFiscalMaterial));
            }

        }

        private ILog _ilog;
        protected ILog Log
        {
            get
            {
                return _ilog != null ? _ilog : _ilog = (ILog)CommonServices.GetObject(typeof(ILog));
            }

        }
        private IUnidadeLocalSubPlano _unidadeLocalSubPlano;
        protected IUnidadeLocalSubPlano UnidadeLocalSubPlano
        {
            get
            {
                return _unidadeLocalSubPlano != null ? _unidadeLocalSubPlano : _unidadeLocalSubPlano = (IUnidadeLocalSubPlano)CommonServices.GetObject(typeof(IUnidadeLocalSubPlano));
            }
        }

        private ISubPlano _subPlano;
        public ISubPlano SubPlano
        {
            get { return _subPlano != null ? _subPlano : _subPlano = (ISubPlano)CommonServices.GetObject(typeof(ISubPlano)); }
        }

        /// <summary>
        /// CadastroBanco
        /// </summary>
        private ICadastroBanco _cadastroBanco;
        protected ICadastroBanco CadastroBanco
        {
            get
            {
                return _cadastroBanco != null ? _cadastroBanco : _cadastroBanco = (ICadastroBanco)CommonServices.GetObject(typeof(ICadastroBanco));
            }
        }

        /// <summary>
        /// Imposto
        /// </summary>
        private IImposto _imposto;
        protected IImposto Imposto
        {
            get
            {
                return _imposto != null ? _imposto : _imposto = (IImposto)CommonServices.GetObject(typeof(IImposto));
            }
        }

        /// <summary>
        /// ConvenioUnidadeImposto
        /// </summary>
        private IConvenioUnidadeImposto _convenioUnidadeImposto;
        protected IConvenioUnidadeImposto ConvenioUnidadeImposto
        {
            get
            {
                return _convenioUnidadeImposto != null ? _convenioUnidadeImposto : _convenioUnidadeImposto = (IConvenioUnidadeImposto)CommonServices.GetObject(typeof(IConvenioUnidadeImposto));
            }
        }

        private IAssociacaoBancoConta _associacaoBancoConta;
        protected IAssociacaoBancoConta AssociacaoBancoConta
        {
            get { return _associacaoBancoConta != null ? _associacaoBancoConta : _associacaoBancoConta = (IAssociacaoBancoConta)CommonServices.GetObject(typeof(IAssociacaoBancoConta)); }
        }

        private ITipoCredenciaProfissional _tipoCredenciaProfissional;
        protected ITipoCredenciaProfissional TipoCredenciaProfissional
        {
            get
            {
                return _tipoCredenciaProfissional ?? (_tipoCredenciaProfissional = (ITipoCredenciaProfissional)CommonServices.GetObject(typeof(ITipoCredenciaProfissional)));
            }
        }

        private IIndicador _indicador;
        protected IIndicador Indicador
        {
            get
            {
                return _indicador != null ? _indicador : _indicador = (IIndicador)CommonServices.GetObject(typeof(IIndicador));
            }
        }
        private IIndicadorAtendimento _indicadorAtendimento;
        protected IIndicadorAtendimento IndicadorAtendimento
        {
            get
            {
                return _indicadorAtendimento != null ? _indicadorAtendimento : _indicadorAtendimento = (IIndicadorAtendimento)CommonServices.GetObject(typeof(IIndicadorAtendimento));
            }
        }
        #endregion

        #region [ Propriedades de Acesso aos Serviços de Produtos]

        /// <summary>
        /// Exclusao Contratual
        /// </summary>
        private IEspecialidadeProcedimento _especialidadeProcedimento;
        protected IEspecialidadeProcedimento EspecialidadeProcedimento
        {
            get
            {
                return _especialidadeProcedimento != null ? _especialidadeProcedimento : _especialidadeProcedimento = (IEspecialidadeProcedimento)CommonServices.GetObject(typeof(IEspecialidadeProcedimento));
            }
        }

        /// <summary>
        /// Acessa os serviços de Produto
        /// </summary>
        private HospitalAnaCosta.Services.Produto.Interface.IProduto _produto;
        protected HospitalAnaCosta.Services.Produto.Interface.IProduto Produto
        {
            get
            {
                return _produto != null ? _produto : _produto = (HospitalAnaCosta.Services.Produto.Interface.IProduto)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Produto.Interface.IProduto));
            }
        }
        /// <summary>
        /// Acessa os serviços de MAT MED
        /// </summary>
        private HospitalAnaCosta.Services.Produto.Interface.IMaterialMedicamento _materialMedicamento;
        protected HospitalAnaCosta.Services.Produto.Interface.IMaterialMedicamento MaterialMedicamento
        {
            get
            {
                return _materialMedicamento != null ? _materialMedicamento : _materialMedicamento = (HospitalAnaCosta.Services.Produto.Interface.IMaterialMedicamento)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Produto.Interface.IMaterialMedicamento));
            }
        }

        /// <summary>
        /// Acessa os serviços de Tipo de Atributo do Produto
        /// </summary>
        private ITipoAtributoProduto _tipoAtributoProduto;
        protected ITipoAtributoProduto TipoAtributoProduto
        {
            get
            {
                return _tipoAtributoProduto != null ? _tipoAtributoProduto : _tipoAtributoProduto = (HospitalAnaCosta.Services.Produto.Interface.ITipoAtributoProduto)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Produto.Interface.ITipoAtributoProduto));
            }
        }


        /// <summary>
        /// Acessa os serviços de Indice Hospitalar
        /// </summary>
        private IIndiceHospitalar _indiceHospitalar;
        protected IIndiceHospitalar IndiceHospitalar
        {
            get
            {
                return _indiceHospitalar != null ? _indiceHospitalar : _indiceHospitalar = (HospitalAnaCosta.Services.Produto.Interface.IIndiceHospitalar)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Produto.Interface.IIndiceHospitalar));
            }
        }

        /// <summary>
        /// Acessa os serviços de Valor de Índice Hospitalar
        /// </summary>
        private IValorIndiceHospitalar _valorIndiceHospitalar;
        protected IValorIndiceHospitalar ValorIndiceHospitalar
        {
            get
            {
                return _valorIndiceHospitalar != null ? _valorIndiceHospitalar : _valorIndiceHospitalar = (HospitalAnaCosta.Services.Produto.Interface.IValorIndiceHospitalar)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Produto.Interface.IValorIndiceHospitalar));
            }
        }

        /// <summary>
        /// Acessa os serviços de Valor de Índice Hospitalar
        /// </summary>
        private IConvenioValorProduto _convenioValorProduto;
        protected IConvenioValorProduto ConvenioValorProduto
        {
            get
            {
                return _convenioValorProduto != null ? _convenioValorProduto : _convenioValorProduto = (HospitalAnaCosta.Services.Produto.Interface.IConvenioValorProduto)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Produto.Interface.IConvenioValorProduto));
            }
        }

        /// <summary>
        /// Acessa os serviços de IGrupoProcedimento
        /// </summary>
        private IGrupoProcedimento _grupoProcedimento;
        protected IGrupoProcedimento GrupoProcedimento
        {
            get
            {
                return _grupoProcedimento != null ? _grupoProcedimento : _grupoProcedimento = (HospitalAnaCosta.Services.Produto.Interface.IGrupoProcedimento)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Produto.Interface.IGrupoProcedimento));
            }
        }

        /// <summary>
        /// Acessa os serviços de IBrasindice
        /// </summary>
        private IBrasindice _brasindice;
        protected IBrasindice Brasindice
        {
            get
            {
                return _brasindice != null ? _brasindice : _brasindice = (HospitalAnaCosta.Services.Produto.Interface.IBrasindice)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Produto.Interface.IBrasindice));
            }
        }

        /// <summary>
        /// Acessa os serviços de ISimpro
        /// </summary>
        private ISimpro _simpro;
        protected ISimpro Simpro
        {
            get
            {
                return _simpro != null ? _simpro : _simpro = (HospitalAnaCosta.Services.Produto.Interface.ISimpro)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Produto.Interface.ISimpro));
            }
        }

        /// <summary>
        /// Acessa os serviços de IPercentualClassificacaoMedicamento
        /// </summary>
        private IPercentualClassificacaoMedicamento _percentualClassificacaoMedicamento;
        protected IPercentualClassificacaoMedicamento PercentualClassificacaoMedicamento
        {
            get
            {
                return _percentualClassificacaoMedicamento != null ? _percentualClassificacaoMedicamento : _percentualClassificacaoMedicamento = (HospitalAnaCosta.Services.Produto.Interface.IPercentualClassificacaoMedicamento)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Produto.Interface.IPercentualClassificacaoMedicamento));
            }
        }

        /// <summary>
        /// Acessa os serviços de IPercentualClassificacaoMedicamento
        /// </summary>
        private IHistoricoProduto _historicoProduto;
        protected IHistoricoProduto HistoricoProduto
        {
            get
            {
                return _historicoProduto != null ? _historicoProduto : _historicoProduto = (HospitalAnaCosta.Services.Produto.Interface.IHistoricoProduto)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Produto.Interface.IHistoricoProduto));
            }
        }

        /// <summary>
        /// Acessa os serviços de ICadastroApresentacaoProdutoMatMed
        /// </summary>
        private ICadastroApresentacaoProdutoMatMed _cadastroApresentacaoProdutoMatMed;
        protected ICadastroApresentacaoProdutoMatMed CadastroApresentacaoProdutoMatMed
        {
            get
            {
                return _cadastroApresentacaoProdutoMatMed != null ? _cadastroApresentacaoProdutoMatMed : _cadastroApresentacaoProdutoMatMed = (HospitalAnaCosta.Services.Produto.Interface.ICadastroApresentacaoProdutoMatMed)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Produto.Interface.ICadastroApresentacaoProdutoMatMed));
            }
        }

        /// <summary>
        /// Acessa os serviços de ITipoListaMedicamento
        /// </summary>
        private ITipoListaMedicamento _tipoListaMedicamento;
        protected ITipoListaMedicamento TipoListaMedicamento
        {
            get
            {
                return _tipoListaMedicamento != null ? _tipoListaMedicamento : _tipoListaMedicamento = (HospitalAnaCosta.Services.Produto.Interface.ITipoListaMedicamento)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Produto.Interface.ITipoListaMedicamento));
            }
        }
        #endregion

        #region [ Propriedades de Acesso aos Serviços de Segurança Hac]


        /// <summary>
        /// IModulo
        /// </summary>
        private HospitalAnaCosta.Services.Seguranca.Interface.IModulo _modulo;
        public HospitalAnaCosta.Services.Seguranca.Interface.IModulo Modulo
        {
            get
            {
                return _modulo != null ? _modulo : _modulo = (HospitalAnaCosta.Services.Seguranca.Interface.IModulo)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Seguranca.Interface.IModulo));
            }
        }

        /// <summary>
        /// IFuncionalidade
        /// </summary>
        /// 
        private HospitalAnaCosta.Services.Seguranca.Interface.IFuncionalidade _funcionalidade;
        public HospitalAnaCosta.Services.Seguranca.Interface.IFuncionalidade Funcionalidade
        {
            get
            {
                return _funcionalidade != null ? _funcionalidade : _funcionalidade = (HospitalAnaCosta.Services.Seguranca.Interface.IFuncionalidade)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Seguranca.Interface.IFuncionalidade));
            }
        }

        /// <summary>
        /// IPerfil
        /// </summary>
        private HospitalAnaCosta.Services.Seguranca.Interface.IPerfil _perfil;
        public HospitalAnaCosta.Services.Seguranca.Interface.IPerfil Perfil
        {
            get
            {
                return _perfil != null ? _perfil : _perfil = (HospitalAnaCosta.Services.Seguranca.Interface.IPerfil)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Seguranca.Interface.IPerfil));
            }
        }

        /// <summary>
        /// Usuario
        /// </summary>
        private HospitalAnaCosta.Services.Seguranca.Interface.IUsuario _usuario;
        public HospitalAnaCosta.Services.Seguranca.Interface.IUsuario Usuario
        {
            get
            {
                return _usuario != null ? _usuario : _usuario = (HospitalAnaCosta.Services.Seguranca.Interface.IUsuario)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Seguranca.Interface.IUsuario));
            }
        }

        /// <summary>
        /// ModuloPerfil
        /// </summary>
        private HospitalAnaCosta.Services.Seguranca.Interface.IModuloPerfil _moduloPerfil;
        public HospitalAnaCosta.Services.Seguranca.Interface.IModuloPerfil ModuloPerfil
        {
            get
            {
                return _moduloPerfil != null ? _moduloPerfil : _moduloPerfil = (HospitalAnaCosta.Services.Seguranca.Interface.IModuloPerfil)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Seguranca.Interface.IModuloPerfil));
            }
        }

        /// <summary>
        /// PermissaoUsuario
        /// </summary>
        private HospitalAnaCosta.Services.Seguranca.Interface.IPermissaoUsuario _permissaoUsuario;
        public HospitalAnaCosta.Services.Seguranca.Interface.IPermissaoUsuario PermissaoUsuario
        {
            get
            {
                return _permissaoUsuario != null ? _permissaoUsuario : _permissaoUsuario = (HospitalAnaCosta.Services.Seguranca.Interface.IPermissaoUsuario)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Seguranca.Interface.IPermissaoUsuario));
            }
        }

        /// <summary>
        /// PerfilFuncionalidade
        /// </summary>
        private HospitalAnaCosta.Services.Seguranca.Interface.IPerfilFuncionalidade _perfilFuncionalidade;
        public HospitalAnaCosta.Services.Seguranca.Interface.IPerfilFuncionalidade PerfilFuncionalidade
        {
            get
            {
                return _perfilFuncionalidade != null ? _perfilFuncionalidade : _perfilFuncionalidade = (HospitalAnaCosta.Services.Seguranca.Interface.IPerfilFuncionalidade)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Seguranca.Interface.IPerfilFuncionalidade));
            }
        }

        /// <summary>
        /// UsuarioUnidade
        /// </summary>
        private HospitalAnaCosta.Services.Seguranca.Interface.IUsuarioUnidade _usuarioUnidade;
        public HospitalAnaCosta.Services.Seguranca.Interface.IUsuarioUnidade UsuarioUnidade
        {
            get
            {
                return _usuarioUnidade != null ? _usuarioUnidade : _usuarioUnidade = (HospitalAnaCosta.Services.Seguranca.Interface.IUsuarioUnidade)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Seguranca.Interface.IUsuarioUnidade));
            }
        }

        /// <summary>
        /// UnidadeLocalSetorUsuario
        /// </summary>
        private HospitalAnaCosta.Services.Seguranca.Interface.IUnidadeLocalSetorUsuario _unidadeLocalSetorUsuario;
        public HospitalAnaCosta.Services.Seguranca.Interface.IUnidadeLocalSetorUsuario UnidadeLocalSetorUsuario
        {
            get
            {
                return _unidadeLocalSetorUsuario != null ? _unidadeLocalSetorUsuario : _unidadeLocalSetorUsuario = (HospitalAnaCosta.Services.Seguranca.Interface.IUnidadeLocalSetorUsuario)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Seguranca.Interface.IUnidadeLocalSetorUsuario));
            }
            //set
            //{
            //    _unidadeLocalSetorUsuario = value;
            //}
        }

        #endregion

        ///// <summary>
        ///// Email
        ///// </summary>
        //private HospitalAnaCosta.Services.Email.Interface.IEmail _email;
        //public HospitalAnaCosta.Services.Email.Interface.IEmail Email
        //{
        //    get
        //    {
        //        return _email != null ? _email : _email = (HospitalAnaCosta.Services.Email.Interface.IEmail)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Email.Interface.IEmail));
        //    }

        //}

        /// <summary>
        /// Email
        /// </summary>
        private HospitalAnaCosta.Services.Email.Interface.IEmail _email;
        public HospitalAnaCosta.Services.Email.Interface.IEmail Email
        {
            get
            {
                return _email != null ? _email : _email = (HospitalAnaCosta.Services.Email.Interface.IEmail)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Email.Interface.IEmail));
            }

        }
    }
}
//