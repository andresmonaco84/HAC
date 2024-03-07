using System.Configuration;
using System.Text.RegularExpressions;
using RMT = HospitalAnaCosta.Framework.Communication.Remoting;

namespace HospitalAnaCosta.Services.BeneficiarioACS.View
{
    public class CommonBeneficiarioACS
    {
        private object credential = null;

        /// Possui os metodos comuns para toda a aplicacao 
        /// </summary>
        /// <param name="credential">credencial</param>
        public CommonBeneficiarioACS(object Credential)
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
                                , ConfigurationManager.AppSettings["HAC.REMOTING.SERVICES.BENEFICIARIOACS.CHANNEL"]
                                , ConfigurationManager.AppSettings["HAC.REMOTING.SERVICES.BENEFICIARIOACS.PATH"]
                                , ConfigurationManager.AppSettings["HAC.REMOTING.SERVICES.BENEFICIARIOACS.PORT"]);


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
                case "IBeneficiarioACS":
                    result = client.GetObject(typeof(HospitalAnaCosta.Services.BeneficiarioACS.Interface.IBeneficiarioACS), "HospitalAnaCosta.Services.BeneficiarioACS.Control.BeneficiarioACS");
                    break;
                case "IBenefHomeCare":
                    result = client.GetObject(typeof(HospitalAnaCosta.Services.BeneficiarioACS.Interface.IBenefHomeCare), "HospitalAnaCosta.Services.BeneficiarioACS.Control.BenefHomeCare");
                    break; 
            }
            ((HospitalAnaCosta.Services.BeneficiarioACS.Interface.IControl)result).Credential = this.Credential;

            return result;
        }
    }
}