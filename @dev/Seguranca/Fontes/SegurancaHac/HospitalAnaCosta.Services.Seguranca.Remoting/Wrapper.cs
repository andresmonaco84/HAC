using System;
using System.Collections.Generic;
using System.Text;
using HospitalAnaCosta.Framework.Communication.Remoting;
using System.Configuration;
using HospitalAnaCosta.Services.Seguranca.Control;
using System.Diagnostics;


namespace HospitalAnaCosta.Services.Seguranca.Remoting
{
    public class Wrapper : HospitalAnaCosta.Framework.Communication.Remoting.Server
    {
        public Wrapper()
        {
            InitializeComponent();
            Configure();
        }

        private void InitializeComponent()
        {
            #if DEBUG
                 base.ShowStatus += new ShowStatusEventHandler(Wrapper_ShowStatus);
                 base.ShowStatusInstance += new ShowStatusInstanceEventHandler(Wrapper_ShowStatusInstance);
            #endif
        }

        void Wrapper_ShowStatusInstance(InstanceEventArgs args)
        {
            #if DEBUG
                try
                {
                    Console.Clear();
                    foreach (KeyValuePair<string, int> val in args.Instance)
                    {
                        Console.WriteLine("{0} : {1}", val.Key.Substring(val.Key.LastIndexOf(".") + 1), val.Value);
                    }
                }
                catch { }
            #endif
        }

        void Wrapper_ShowStatus(StatusEventArgs args)
        {
            #if DEBUG
                Console.WriteLine(args.StatusMessage);
            #endif
        }

        public void Logar(string log)
        {
            EventLog elog = new EventLog();
            elog.Log = "SGS.Seguranca";
            elog.Source = "Seguranca";
            elog.WriteEntry(log);
            elog.Close();
            elog = null;
        }

        private new void Configure()
        {
            string str = string.Format("String de Conexão.: {0}", ConfigurationManager.ConnectionStrings["ConnectionStringOracle"].ConnectionString);
            Console.WriteLine(str);

            // adicionando os canais
            int porta = int.Parse(ConfigurationManager.AppSettings["HAC.REMOTING.SERVICES.SEGURANCA.PORT"]);
            base.AddChannel(porta, ChannelType.TCP);
            Logar(string.Format("Abrindo Canal TCP Porta: {0}", porta));

            //Assembly que dever ser carregados            
            base.AssemblyToLoad.Add("Seguranca", "HospitalAnaCosta.Services.Seguranca.Control");
            Logar("Carregando Assembly 'HospitalAnaCosta.Services.Seguranca.Control'");

            // adicionando os namespaces que devem ser expostos
            base.NamespaceExpose.Add("Seguranca", "HospitalAnaCosta.Services.Seguranca.Control");
            Logar("Registrando Nomes");

            base.LoadTypes();
            Logar("Serviço iniciado com sucesso");
        }

        public void Start()
        {
            this.StartListen();
        }
    }
}
