using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace HospitalAnaCosta.SGS.AgenteFaturamentoService
{
    [RunInstaller(true)]
    public partial class AgenteInstaller : Installer
    {
        public AgenteInstaller()
        {
            InitializeComponent();
                        this.agenteProcessInstaller =
            new System.ServiceProcess.ServiceProcessInstaller();
            this.agenteInstaller =
             new System.ServiceProcess.ServiceInstaller();

            this.agenteProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;

            this.agenteInstaller.ServiceName = "SGS.AgenteService";
            this.agenteInstaller.Description = "Serviço Agente do SGS";
            this.agenteInstaller.StartType =
              System.ServiceProcess.ServiceStartMode.Automatic;

            // 
            // ProjectInstaller 
            // 
            this.Installers.AddRange(
              (new System.Configuration.Install.Installer[]
              {this.agenteProcessInstaller, 
               this.agenteInstaller}));

        }

           private System.ServiceProcess.ServiceProcessInstaller
                                  agenteProcessInstaller;
        private System.ServiceProcess.ServiceInstaller agenteInstaller;

     
    }

}