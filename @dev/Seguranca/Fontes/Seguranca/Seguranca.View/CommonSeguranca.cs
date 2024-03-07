using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using RMT = HospitalAnaCosta.Framework.Communication.Remoting;
using System.Configuration;
using HospitalAnaCosta.SGS.Seguranca.Interface;

namespace HospitalAnaCosta.SGS.Seguranca.View
{
    public class CommonSeguranca
    {

        private object credential = null;

        /// Possui os metodos comuns para toda a aplicacao 
        /// </summary>
        /// <param name="credential">credencial</param>
        public CommonSeguranca(object Credential)
        {
            this.credential = Credential;
        }

        /// <summary>
        /// Salva/altera a credencial de quem esta fazendo a chamada
        /// </summary>
        public object Credential
        {
            get { return credential; }
            set { credential = value; }
        }

        /// <summary>
        /// Format o nome para inicial maiscula e restante minuscula
        /// </summary>
        /// <param name="Nome">String do nome</param>
        /// <returns>Nome formatado</returns>
        public string FormatNome(string Nome)
        {
            string text = Nome.ToLowerInvariant();
            string result = "";
            string pattern = @"\w+|\W+";

            foreach (Match m in Regex.Matches(text, pattern))
            {
                // get the matched string
                string x = m.ToString();
                // if the first char is lower case
                if (char.IsLower(x[0]))
                    // capitalize it
                    x = char.ToUpper(x[0]) + x.Substring(1, x.Length - 1);
                // collect all text
                result += x;
            }
            // Trata palavras de ligação: da, de, do, das, dos
            result = Regex.Replace(result, " De ", " de ");
            result = Regex.Replace(result, " Do ", " do ");
            result = Regex.Replace(result, " Dos ", " dos ");
            result = Regex.Replace(result, " Da ", " da ");
            result = Regex.Replace(result, " Das ", " das ");
            return result;
        }
        private static RMT.Client CreateClient()
        {
            RMT.Client client = new RMT.Client();
            string url = string.Empty;
            url = string.Format(@"{0}://{1}:{2}/"
                                , ConfigurationManager.AppSettings["HAC.REMOTING.SGS.SEGURANCA.CHANNEL"]
                                , ConfigurationManager.AppSettings["HAC.REMOTING.SGS.SEGURANCA.PATH"]
                                , ConfigurationManager.AppSettings["HAC.REMOTING.SGS.SEGURANCA.PORT"]);

            RMT.ChannelType channelType = RMT.ChannelType.TCP;

            client.Url = url;
            client.AddChannel(channelType);
            return client;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns>Retorna uma instancia do codigo da control</returns>
        public object GetObject(System.Type type)
        {

            RMT.Client client = CreateClient();
            string tp = type.Name;
            object result = null;
            switch (tp)
            {
                case "IAssPerfilFuncionalidade":
                    result = client.GetObject(typeof(IAssPerfilFuncionalidade), "HospitalAnaCosta.SGS.Seguranca.Control.AssPerfilFuncionalidade");
                    break;
                case "IAssPerfilUsuario":
                    result = client.GetObject(typeof(IAssPerfilUsuario), "HospitalAnaCosta.SGS.Seguranca.Control.AssPerfilUsuario");
                    break;
                case "IAutentica":
                    result = client.GetObject(typeof(IAutentica), "HospitalAnaCosta.SGS.Seguranca.Control.Autentica");
                    break;
                case "IFuncionalidade":
                    result = client.GetObject(typeof(IFuncionalidade), "HospitalAnaCosta.SGS.Seguranca.Control.Funcionalidade");
                    break;
                case "IModulo":
                    result = client.GetObject(typeof(IModulo), "HospitalAnaCosta.SGS.Seguranca.Control.Modulo");
                    break;
                case "IPerfil":
                    result = client.GetObject(typeof(IPerfil), "HospitalAnaCosta.SGS.Seguranca.Control.Perfil");
                    break;
                case "ISistema":
                    result = client.GetObject(typeof(ISistema), "HospitalAnaCosta.SGS.Seguranca.Control.Sistema");
                    break;
                case "IUsuario":
                    result = client.GetObject(typeof(IUsuario), "HospitalAnaCosta.SGS.Seguranca.Control.Usuario");
                    break;
                case "IUsuarioUnidade":
                    result = client.GetObject(typeof(IUsuarioUnidade), "HospitalAnaCosta.SGS.Seguranca.Control.UsuarioUnidade");
                    break;
                case "IUnidadeLocalSetorUsuario":
                    result = client.GetObject(typeof(IUnidadeLocalSetorUsuario), "HospitalAnaCosta.SGS.Seguranca.Control.UnidadeLocalSetorUsuario");
                    break;
                case "IUsuarioFuncionalidade":
                    result = client.GetObject(typeof(IUsuarioFuncionalidade), "HospitalAnaCosta.SGS.Seguranca.Control.UsuarioFuncionalidade");
                    break;

            }
            ((HospitalAnaCosta.SGS.Seguranca.Interface.IControl)result).Credential = this.Credential;


            return result;
        }
    }
}
