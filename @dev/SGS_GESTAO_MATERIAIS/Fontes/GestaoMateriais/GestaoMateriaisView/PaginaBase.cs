using System;
using System.Collections.Generic;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Framework.Web;
//using HospitalAnaCosta.SGS.Model.Seguranca;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using HospitalAnaCosta.Framework.Compress;
using System.Collections;

namespace HospitalAnaCosta.SGS.GestaoMateriaisView
{
    public class PaginaBase : HospitalAnaCosta.Framework.Web.BasePage
    {
        public Dictionary<object, string> validateControls;
        /*
        private Common common;
        protected Common Common
        {
            get
            {
                if (common == null)
                    common = new Common((PassportVO)Session["Passport"]);

                return common;
            }
        }
         * */
        private StringBuilder scriptValidate;

        private bool manterSessao = false;
        /// <summary>
        /// MantÈm sess„o da p·gina para que o usu·rio n„o precise refazer o login
        /// </summary>
        protected bool ManterSessao
        {
            set { manterSessao = value; }
            get { return manterSessao; }
        }

        /// <summary>
        /// Configura os controles recebidos, habilitando, desabilitando, mostrando ou escondendo
        /// </summary>
        /// <param name="habilitar">Habilita ou Desabilita</param>
        /// <param name="classes">as classes de objetos que dever„o entrar no controle</param>
        /// <param name="controls">controle pai dos controles configurados</param>
        /// <param name="mostrar">mostra ou esconde</param>
        private void ConfiguraControlesRecursivo(bool habilitar, ArrayList classes, ControlCollection controls, bool mostrar)
        {
            foreach (Control ctr in controls)
            {
                foreach (object obj in classes)
                {
                    if (ctr.GetType() == obj)
                    {
                        ((WebControl)ctr).Enabled = habilitar;
                        ctr.Visible = mostrar;
                    }
                }
                ConfiguraControlesRecursivo(habilitar, classes, ctr.Controls, mostrar);
            }
        }

        /// <summary>
        /// Configura os controles passados, habilitando e desabilitando.
        /// </summary>
        /// <param name="habilitar">Status do controle</param>
        /// <param name="controles">TypeOf dos controles</param>        
        protected virtual void ConfiguraControles(bool habilitar, ArrayList controles)
        {
            ConfiguraControlesRecursivo(habilitar, controles, Controls, true);
        }

        /// <summary>
        /// Configura os controles passados, habilitando e desabilitando
        /// </summary>
        /// <param name="habilitar">Status do controle</param>
        /// <param name="controles">TypeOf dos controles</param>
        /// <param name="controlsCollection">Controle Pai</param>
        protected virtual void ConfiguraControles(bool habilitar, ArrayList controles, ControlCollection controlsCollection)
        {
            ConfiguraControlesRecursivo(habilitar, controles, controlsCollection, true);
        }

        /// <summary>
        /// Configura os controles passados, habilitando e desabilitando.
        /// </summary>
        /// <param name="habilitar">Status do controle</param>
        /// <param name="controles">TypeOf dos controles</param>
        /// <param name="esconder">Esconder os controles</param>
        protected virtual void ConfiguraControles(bool habilitar, ArrayList controles, bool mostrar)
        {
            ConfiguraControlesRecursivo(habilitar, controles, Controls, mostrar);
        }

        /// <summary>
        /// Valida se o controle est· preenchido
        /// </summary>
        protected bool ValidateRequiredFields(out StringBuilder msg)
        {
            if (validateControls == null)
            {
                throw new HacException("Controles para validaÁ„o nulo.");
            }
            msg = new StringBuilder();
            foreach (KeyValuePair<object, string> field in validateControls)
            {
                if (field.Key is TextBox)
                    if (((TextBox)field.Key).Text.Trim().Length == 0)
                    {
                        msg.Append(string.Concat(field.Value, @"\n"));
                    }
                    else
                    {
                        ((TextBox)field.Key).Text = RemoveAcentos(((TextBox)field.Key).Text);
                    }
                if (field.Key is DropDownList)
                {
                    if (((DropDownList)field.Key).SelectedIndex <= 0)
                    {
                        msg.Append(string.Concat(field.Value, @"\n"));
                    }
                }
                if (field.Key is Label)
                    if (((Label)field.Key).Text.Trim().Length == 0)
                    {
                        msg.Append(string.Concat(field.Value, @"\n"));
                    }
            }
            if (msg.Length != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Procura e adiciona o objeto na funÁ„o de limpeza de campos
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="funcaoScript"></param>
        private void FindAndRegisterScriptRecurssive(ControlCollection controls, ref StringBuilder funcaoScript)
        {
            foreach (Control ctr in controls)
            {
                if (ctr is TextBox)
                {
                    funcaoScript.AppendFormat(@"document.getElementById('{0}').value = '';", ctr.UniqueID.Replace("$", "_"));
                }
                if (ctr is DropDownList)
                {
                    funcaoScript.AppendFormat(@"document.getElementById('{0}').value = 0;", ctr.UniqueID.Replace("$", "_"));
                }
                FindAndRegisterScriptRecurssive(ctr.Controls, ref funcaoScript);
            }
        }
        /// <summary>
        /// Registra script para limpar campos
        /// </summary>
        /// <param name="controls">Controles</param>
        /// <param name="nomeFuncao">Nome da funÁ„o a ser registrada</param>
        /// <returns></returns>
        protected string RegisterScriptClearFields(ControlCollection controls, string nomeFuncao)
        {
            return RegisterScriptClearFields(controls, nomeFuncao, null);
        }

        /// <summary>
        /// Registra script para limpar campos
        /// </summary>
        /// <param name="controls">Controles</param>
        /// <param name="nomeFuncao">Nome da funÁ„o a ser registrada</param>
        /// <returns></returns>
        protected string RegisterScriptClearFields(ControlCollection controls, string nomeFuncao, Dictionary<string, bool> controlsToConfigure)
        {
            StringBuilder funcaoScript = new StringBuilder();

            funcaoScript.AppendFormat(@"function {0} ", nomeFuncao);
            funcaoScript.Append(@"{ ");
            Guid guid = Guid.NewGuid();

            FindAndRegisterScriptRecurssive(controls, ref funcaoScript);

            if (controlsToConfigure != null)
            {
                bool valor;
                foreach (KeyValuePair<string, bool> field in controlsToConfigure)
                {
                    valor = !field.Value;
                    funcaoScript.AppendFormat(@"document.getElementById('{0}').disabled = {1};", field.Key.Replace("$", "_"), valor.ToString().ToLower());
                }
            }

            funcaoScript.Append(@" }");

            ClientScript.RegisterClientScriptBlock(GetType(), guid.ToString(), funcaoScript.ToString(), true);

            return string.Format("{0};", nomeFuncao);
        }

        //TODO:    FUN«√O DE REMO«√O DE ACENTOS EM STRINGS, POR SUAS VOGAIS EQUIVALENTES
        protected string RemoveAcentos(string str)
        {
            string acentos = "ƒ≈¡¬¿√‰·‚‡„… À»ÈÍÎËÕŒœÃÌÓÔÏ÷”‘“’ˆÛÙÚı‹⁄€¸˙˚˘«Á ";
            string equivalentes = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc ";
            for (int i = 0; i < acentos.Length; i++)
                str = str.Replace(acentos[i].ToString(), equivalentes[i].ToString()).Trim();

            return str;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (ManterSessao)
            {
                StringBuilder strRefresh = new StringBuilder(453);
                strRefresh.AppendFormat(@"function refresh(){0}", Environment.NewLine);
                strRefresh.Append(@"{ __doPostBack('', ''); setTimeout( 'refresh()', 30000 ); }");

                ClientScript.RegisterClientScriptBlock(GetType(), "refresh", strRefresh.ToString(), true);

                ClientScript.RegisterStartupScript(GetType(), "load", "setTimeout( 'refresh()', 30000 );", true);
            }

        }
    }
}
