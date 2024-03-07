using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using HospitalAnaCosta.Framework.Communication.Remoting;


namespace SGS.AgenteService
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

        private new void Configure()
        {
            base.LoadTypes();

        }

        public void Start()
        {
            AgenteService agenteService = new AgenteService();
            this.StartListen();
        }
    }
}
