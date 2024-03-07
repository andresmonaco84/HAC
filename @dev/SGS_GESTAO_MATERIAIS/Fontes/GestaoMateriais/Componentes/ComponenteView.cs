using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using RMT = HospitalAnaCosta.Framework.Communication.Remoting;
using System.Configuration;

namespace HospitalAnaCosta.SGS.Componentes
{
    class ComponenteView
    {
        private object credential = null;

        /// Possui os metodos comuns para toda a aplicacao 
        /// </summary>
        /// <param name="credential">credencial</param>
        public ComponenteView(object Credential)
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
                                , ConfigurationManager.AppSettings["HAC.REMOTING.SGS.ACS.GESTAOMATERIAIS.CHANNEL"]
                                , ConfigurationManager.AppSettings["HAC.REMOTING.SGS.ACS.GESTAOMATERIAIS.PATH"]
                                , ConfigurationManager.AppSettings["HAC.REMOTING.SGS.ACS.GESTAOMATERIAIS.PORT"]);


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
                        case "IGrupoMatMed":
                            result = client.GetObject(typeof(HospitalAnaCosta.SGS.GestaoMateriais.Interface.IGrupoMatMed), "HospitalAnaCosta.SGS.GestaoMateriais.Control.GrupoMatMed");
                            break;
                        case "IMaterialMedicamento":
                            result = client.GetObject(typeof(HospitalAnaCosta.SGS.GestaoMateriais.Interface.IMaterialMedicamento), "HospitalAnaCosta.SGS.GestaoMateriais.Control.MaterialMedicamento");
                            break;
                        case "IPrincipioAtivo":
                            result = client.GetObject(typeof(HospitalAnaCosta.SGS.GestaoMateriais.Interface.IPrincipioAtivo), "HospitalAnaCosta.SGS.GestaoMateriais.Control.PrincipioAtivo");
                            break;
                        case "ISubGrupoMatMed":
                            result = client.GetObject(typeof(HospitalAnaCosta.SGS.GestaoMateriais.Interface.ISubGrupoMatMed), "HospitalAnaCosta.SGS.GestaoMateriais.Control.SubGrupoMatMed");
                            break;
                        case "IRequisicao":
                            result = client.GetObject(typeof(HospitalAnaCosta.SGS.GestaoMateriais.Interface.IRequisicao), "HospitalAnaCosta.SGS.GestaoMateriais.Control.Requisicao");
                            break;
                        case "IRequisicaoItens":
                            result = client.GetObject(typeof(HospitalAnaCosta.SGS.GestaoMateriais.Interface.IRequisicaoItens), "HospitalAnaCosta.SGS.GestaoMateriais.Control.RequisicaoItens");
                            break;
                        case "IEstoqueLocal":
                            result = client.GetObject(typeof(HospitalAnaCosta.SGS.GestaoMateriais.Interface.IEstoqueLocal), "HospitalAnaCosta.SGS.GestaoMateriais.Control.EstoqueLocal");
                            break;
                        case "IPedidoPadrao":
                            result = client.GetObject(typeof(HospitalAnaCosta.SGS.GestaoMateriais.Interface.IPedidoPadrao), "HospitalAnaCosta.SGS.GestaoMateriais.Control.PedidoPadrao");
                            break;
                        case "IFilialMatMed":
                            result = client.GetObject(typeof(HospitalAnaCosta.SGS.GestaoMateriais.Interface.IFilialMatMed), "HospitalAnaCosta.SGS.GestaoMateriais.Control.FilialMatMed");
                            break;
                        case "ICodigoBarra":
                            result = client.GetObject(typeof(HospitalAnaCosta.SGS.GestaoMateriais.Interface.ICodigoBarra), "HospitalAnaCosta.SGS.GestaoMateriais.Control.CodigoBarra");
                            break;
                        case "IMovimentacao":
                            result = client.GetObject(typeof(HospitalAnaCosta.SGS.GestaoMateriais.Interface.IMovimentacao), "HospitalAnaCosta.SGS.GestaoMateriais.Control.Movimentacao");
                            break;
                        case "IMovimentacaoComplemento":
                            result = client.GetObject(typeof(HospitalAnaCosta.SGS.GestaoMateriais.Interface.IMovimentacaoComplemento), "HospitalAnaCosta.SGS.GestaoMateriais.Control.MovimentacaoComplemento");
                            break;
                        case "IMatMedSetorConfig":
                            result = client.GetObject(typeof(HospitalAnaCosta.SGS.GestaoMateriais.Interface.IMatMedSetorConfig), "HospitalAnaCosta.SGS.GestaoMateriais.Control.MatMedSetorConfig");
                            break;
                        case "IHistoricoNotaFiscal":
                            result = client.GetObject(typeof(HospitalAnaCosta.SGS.GestaoMateriais.Interface.IHistoricoNotaFiscal), "HospitalAnaCosta.SGS.GestaoMateriais.Control.HistoricoNotaFiscal");
                            break;
                        case "IMovimentacaoTipoCCusto":
                            result = client.GetObject(typeof(HospitalAnaCosta.SGS.GestaoMateriais.Interface.IHistoricoNotaFiscal), "HospitalAnaCosta.SGS.GestaoMateriais.Control.MovimentacaoTipoCCusto");
                            break;
                        case "IMatMedSimilar":
                            result = client.GetObject(typeof(HospitalAnaCosta.SGS.GestaoMateriais.Interface.IMatMedSimilar), "HospitalAnaCosta.SGS.GestaoMateriais.Control.MatMedSimilar");
                            break;
                        case "ITipoFracao":
                            result = client.GetObject(typeof(HospitalAnaCosta.SGS.GestaoMateriais.Interface.ITipoFracao), "HospitalAnaCosta.SGS.GestaoMateriais.Control.TipoFracao");
                            break;
                        case "IUtilitario":
                            result = client.GetObject(typeof(HospitalAnaCosta.SGS.GestaoMateriais.Interface.IUtilitario), "HospitalAnaCosta.SGS.GestaoMateriais.Control.Utilitario");
                            break;
                        case "IPaciente":
                            result = client.GetObject(typeof(HospitalAnaCosta.SGS.GestaoMateriais.Interface.IPaciente), "HospitalAnaCosta.SGS.GestaoMateriais.Control.Paciente");
                            break;  


            }
            ((HospitalAnaCosta.SGS.GestaoMateriais.Interface.IControl)result).Credential = this.Credential;

            return result;
        }

    }
}

