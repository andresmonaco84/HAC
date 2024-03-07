using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace HospitalAnaCosta.Services.BeneficiarioACS.Remoting
{
    [RunInstaller(true)]
    public partial class BeneficiarioACSInstaller : Installer
    {
        private System.ServiceProcess.ServiceProcessInstaller
                                  processInstaller;
        private System.ServiceProcess.ServiceInstaller installer;

        public BeneficiarioACSInstaller()
        {
            this.processInstaller =
            new System.ServiceProcess.ServiceProcessInstaller();
            this.installer =
             new System.ServiceProcess.ServiceInstaller();
            // serviceProcessInstaller1 
            // 
            this.processInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            // 
            // serviceInstaller1 
            // 
            this.installer.ServiceName = "SGS.BeneficiarioACSService";
            this.installer.Description = "SGS - Módulo BeneficiarioACS";
            this.installer.StartType =
              System.ServiceProcess.ServiceStartMode.Automatic;

            // 
            // ProjectInstaller 
            // 
            this.Installers.AddRange(
              (new System.Configuration.Install.Installer[]
              {this.processInstaller, 
               this.installer}));
        }
    }
}