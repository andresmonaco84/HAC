using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace HospitalAnaCosta.Services.Seguranca.Remoting
{
    [RunInstaller(true)]
    public partial class SegurancaInstaller : Installer
    {
        private System.ServiceProcess.ServiceProcessInstaller processInstaller;
        private System.ServiceProcess.ServiceInstaller installer;

        public SegurancaInstaller()
        {
            this.processInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.installer = new System.ServiceProcess.ServiceInstaller();
            this.processInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.installer.StartType = System.ServiceProcess.ServiceStartMode.Automatic;

            this.installer.ServiceName = "SGS.SegurancaHac";
            this.installer.Description = "Serviço Segurança Hac";

            this.Installers.AddRange(
                        (new System.Configuration.Install.Installer[]
                        {this.processInstaller, 
                        this.installer}));
        }
    }
}