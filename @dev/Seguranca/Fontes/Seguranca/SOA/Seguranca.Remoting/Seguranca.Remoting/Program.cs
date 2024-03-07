using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;
using System.Configuration;
using HospitalAnaCosta.SGS.Seguranca.Remoting;

namespace HospitalAnaCosta.SGS.seguranca.Remoting
{
    static class Program
    {
        static void Main(string[] args)
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
