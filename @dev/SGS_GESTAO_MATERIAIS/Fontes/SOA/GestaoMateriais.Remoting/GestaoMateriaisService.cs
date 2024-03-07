using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Remoting
{
    public partial class GestaoMateriaisService : ServiceBase
    {
        private Wrapper wrapper;
        public GestaoMateriaisService()
            : base()
        {
            this.AutoLog = false;
            this.ServiceName = "SGS.GestaoMateriaisService";
            this.CanPauseAndContinue = false;
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            try
            {
                wrapper = new Wrapper();
                wrapper.Start();
            }
            catch (Exception ex)
            {
                if (wrapper != null)
                    wrapper.Logar(ex.Message);
            }
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service. 
            wrapper.Logar("Serviço finalizado com Sucesso");
            wrapper = null;
        }
    }
}
