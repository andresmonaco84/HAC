using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;
using System;

namespace HospitalAnaCosta.Services.Seguranca.Remoting
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            #if DEBUG
                Wrapper wrapper = new Wrapper();
                wrapper.Start();
                Console.Read();
            #else
                ServiceBase[] ServicesToRun;

                // More than one user Service may run within the same process. To add
                // another service to this process, change the following line to
                // create a second service object. For example,
                //
                //   ServicesToRun = new ServiceBase[] {new Service1(), new MySecondUserService()};
                //
                ServicesToRun = new ServiceBase[] { new SegurancaService() };

                ServiceBase.Run(ServicesToRun);
            #endif
        }
    }
}