using System;
using System.Reflection;
using System.Text;

namespace HospitalAnaCosta.Framework
{
    public class ResourcesHelper
    {
        [Serializable]
        public enum PaginaResourceEnum
        {
            AvisoAgendamento = 1,
            CancelamentoAgendamento = 2,
            LembreteAgendamento48Horas = 3,
            AvisoAgendamentoSADT = 4, 
            CancelamentoAgendamentoSADT = 5
        }
        /// <summary>
        /// Recupear o caminho da assembly passada como parametro
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        public static string FindResourcePath(Assembly assembly, string searchPattern)
        {
            string[] arrayOfResources = assembly.GetManifestResourceNames();
            foreach (string resource in arrayOfResources)
            {
                if (resource.ToUpper().IndexOf("." + searchPattern.ToUpper()) != -1)
                {
                    return resource;
                }
            }

            return null;
        }
        /// <summary>
        /// Obtém o código HTML da página referente ao enum passado como parâmetro
        /// </summary>
        /// <param name="pagina">enum de página</param>
        /// <returns>conteúdo html da página</returns>
        public static string ObterHtml(PaginaResourceEnum pagina)
        {
            string htmlRetorno = "";
            Assembly currentAssembly = Assembly.GetExecutingAssembly();

            //Carrega o HTML
            string resourcePath = ResourcesHelper.FindResourcePath(currentAssembly, _ObterNomePagina(pagina));

            System.IO.StreamReader sr = null;
            try
            {
                sr = new System.IO.StreamReader(currentAssembly.GetManifestResourceStream(resourcePath),Encoding.Default);
                htmlRetorno = sr.ReadToEnd();
                htmlRetorno.Replace(@"\r\n", Environment.NewLine);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                    sr = null;
                }                
            }

            return htmlRetorno;
        }
        /// <summary>
        /// obtém o nome da página a partir da enum respectiva, passada como parâmetro
        /// </summary>
        /// <param name="pagina">enum contendo a página informada</param>
        /// <returns>retorna o nome da página correspondente</returns>
        private static string _ObterNomePagina(PaginaResourceEnum pagina)
        {
            string nomePagina = "";
            switch (pagina)
            {
                case PaginaResourceEnum.AvisoAgendamento:
                    nomePagina = "AvisoAgendamento.htm";
                    break;
                case PaginaResourceEnum.CancelamentoAgendamento:
                    nomePagina = "CancelamentoAgendamento.htm";
                    break;
                case PaginaResourceEnum.LembreteAgendamento48Horas:
                    nomePagina = "LembreteAgendamento.htm";
                    break;
                case PaginaResourceEnum.AvisoAgendamentoSADT:
                    nomePagina = "AvisoAgendamentoSADT.htm";
                    break;
                case PaginaResourceEnum.CancelamentoAgendamentoSADT:
                    nomePagina = "CancelamentoAgendamentoSADT.htm";
                    break;
                default:
                    break;
            }
            return nomePagina;
        }
    }
}
