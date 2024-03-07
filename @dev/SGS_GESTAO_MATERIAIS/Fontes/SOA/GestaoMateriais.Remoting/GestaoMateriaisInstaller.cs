using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Remoting
{
    [RunInstaller(true)]
    public partial class SADTInstaller : Installer
    {
        private System.ServiceProcess.ServiceProcessInstaller
                                  processInstaller;
        private System.ServiceProcess.ServiceInstaller installer;

        public SADTInstaller()
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
            this.installer.ServiceName = "SGS.GestaoMateriaisService";
            this.installer.Description = "SGS - Módulo GestaoMateriais";
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