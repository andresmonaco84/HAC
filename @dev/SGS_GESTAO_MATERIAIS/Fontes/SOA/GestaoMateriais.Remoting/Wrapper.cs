using System;
using System.Collections.Generic;
using System.Text;
using HospitalAnaCosta.Framework.Communication.Remoting;
using System.Configuration;
using HospitalAnaCosta.SGS.GestaoMateriais.Control;
using System.Diagnostics;


namespace HospitalAnaCosta.SGS.GestaoMateriais.Remoting
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
            //PrintStatus(args.StatusMessage);
            Console.WriteLine(args.StatusMessage);
#endif
        }

        public void Logar(string log)
        {
            EventLog elog = new EventLog();
            elog.Log = "SGS.GestaoMateriais";
            elog.Source = "GestaoMateriais";
            //elog.WriteEntry(log);
            elog.Close();
            elog = null;
        }

        private new void Configure()
        {
            string str = string.Format("String de Conexão.: {0}", ConfigurationManager.ConnectionStrings["ConnectionStringOracle"].ConnectionString);
            Console.WriteLine(str);

            // adicionando os canais
            int porta = int.Parse(ConfigurationManager.AppSettings["HAC.REMOTING.SGS.GESTAOMATERIAIS.PORT"]);
            base.AddChannel(porta, ChannelType.TCP);
            Logar(string.Format("Abrindo Canal TCP Porta: {0}", porta));
            //Assembly que dever ser carregados            
            base.AssemblyToLoad.Add("SGS.GestaoMateriais", "GestaoMateriais.Control");
            Logar("Carregando Assembly 'GestaoMateriais.Control'");
            // adicionando os namespaces que devem ser expostos
            base.NamespaceExpose.Add("GestaoMateriais.Control", "HospitalAnaCosta.SGS.GestaoMateriais.Control");
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
