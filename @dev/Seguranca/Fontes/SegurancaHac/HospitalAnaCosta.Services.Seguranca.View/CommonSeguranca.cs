using System.Configuration;
using System.Text.RegularExpressions;
using RMT = HospitalAnaCosta.Framework.Communication.Remoting;
using HospitalAnaCosta.Services.Seguranca.Interface;

namespace HospitalAnaCosta.Services.Seguranca.View
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
                                , ConfigurationManager.AppSettings["HAC.REMOTING.SERVICES.SEGURANCA.CHANNEL"]
                                , ConfigurationManager.AppSettings["HAC.REMOTING.SERVICES.SEGURANCA.PATH"]
                                , ConfigurationManager.AppSettings["HAC.REMOTING.SERVICES.SEGURANCA.PORT"]);


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
                case "IFuncionalidade":
                    result = client.GetObject(typeof(IFuncionalidade), "HospitalAnaCosta.Services.Seguranca.Control.Funcionalidade");
                    break;

                case "ILogErros":
                    result = client.GetObject(typeof(ILogErros), "HospitalAnaCosta.Services.Seguranca.Control.LogErros");
                    break;

                case "IModulo":
                    result = client.GetObject(typeof(IModulo), "HospitalAnaCosta.Services.Seguranca.Control.Modulo");
                    break;

                case "IModuloPerfil":
                    result = client.GetObject(typeof(IModuloPerfil), "HospitalAnaCosta.Services.Seguranca.Control.ModuloPerfil");
                    break;

                case "IParametro":
                    result = client.GetObject(typeof(IParametro), "HospitalAnaCosta.Services.Seguranca.Control.Parametro");
                    break;

                case "IPerfil":
                    result = client.GetObject(typeof(IPerfil), "HospitalAnaCosta.Services.Seguranca.Control.Perfil");
                    break;

                case "ITrace":
                    result = client.GetObject(typeof(ITrace), "HospitalAnaCosta.Services.Seguranca.Control.Trace");
                    break;

                case "IUsuario":
                    result = client.GetObject(typeof(IUsuario), "HospitalAnaCosta.Services.Seguranca.Control.Usuario");
                    break;

                case "IUsuarioUnidade":
                    result = client.GetObject(typeof(IUsuarioUnidade), "HospitalAnaCosta.Services.Seguranca.Control.UsuarioUnidade");
                    break;
                case "IPermissaoUsuario":
                    result = client.GetObject(typeof(IPermissaoUsuario), "HospitalAnaCosta.Services.Seguranca.Control.PermissaoUsuario");
                    break;
                case "IPerfilFuncionalidade":
                    result = client.GetObject(typeof(IPerfilFuncionalidade), "HospitalAnaCosta.Services.Seguranca.Control.PerfilFuncionalidade");
                    break;
                case "IUnidadeLocalSetorUsuario":
                    result = client.GetObject(typeof(IUnidadeLocalSetorUsuario), "HospitalAnaCosta.Services.Seguranca.Control.UnidadeLocalSetorUsuario");
                    break;

            }
            ((HospitalAnaCosta.Services.Seguranca.Interface.IControl)result).Credential = this.Credential;

            return result;
        }
    }
}
