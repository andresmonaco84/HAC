using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace HospitalAnaCosta.SGS.Cadastro.Remoting
{
    [RunInstaller(true)]
    public partial class SegurancaInstaller : Installer
    {
        private System.ServiceProcess.ServiceProcessInstaller
                                  processInstaller;
        private System.ServiceProcess.ServiceInstaller installer;

        public SegurancaInstaller()
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
            this.installer.ServiceName = "SGS.SegurancaServiceMatMed";
            this.installer.Description = "SGS - Módulo Seguranca MATMED";
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