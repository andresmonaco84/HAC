using HospitalAnaCosta.SGS.InterfaceAgendaWeb;
using InterfaceAgendaWeb;
using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;
using System.Data.Common;


namespace SGS.AgenteService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {


#if DEBUG

            AtualizaBasePortalACS.DumpData();
            return;
            ////   PendenciasBradesco.Executa();
            ////            AtualizaMensageiro.CarregarMensagensParaEnviar();

            //Console.Read();
           

            return;

            //Mailer.Processar();

            //PendenciasBradesco.Executa();


            //HospitalAnaCosta.SGS.InterfaceAgendaWeb.AtualizaMensageiro.CarregarMensagensParaEnviar();

            return;
            

            //InterfaceAgendaWeb

            //SmsSender.EnviarLembretesLinksTeleconsulta();


            // AtualizaMensageiro.CarregarMensagensParaEnviar();
            return;


            //Mailer.Processar();

            //SmsSender.Processar();


            //try
            //{
            //    //SmsSender.Processar();
            //    SmsSender.ProcessarRespostas();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);                
            //}




            //try
            //{
            //    SmsSender.SendTest();
            //    Console.Read();
            //    return;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            // SmsSender.SendTestPEDRO();

            //SmsSender.Processar();

            //SmsSender.Processar();

            //AtualizaBeneficiario.Atualiza();
            //AtualizaBeneficiarioAgendaWEB.Vai();

            //try
            //{
            //    Mailer.Processar();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);                
            //}

            //Console.Read();

            //Wrapper wrapper = new Wrapper();
            //wrapper.Start();
            //AgenteService agente = new AgenteService();
            //agente.timerAutaComplexidade_Elapsed(null, null);
            //AtualizaElegibilidade.Vai();
            //AtualizaAutaComplexidade.Vai();
            // agente.TimerBeneficiarios_Elapsed(null, null);
            //agente.TimerEscalas_Elapsed(null, null);            
            //agente.TimerHistoricoInternacao_Elapsed(null, null);
            //agente.TimerMensagem_Elapsed(null, null);
            //Console.WriteLine("agenteSGS.Start()");                       


            //AtualizaBeneficiario.Atualiza();

            //AtualizaAutaComplexidade.Vai();            

            //AtualizaRestricaoWEB.Executa();

            //AtualizaElegibilidade.Vai();

            //AtualizaHistoricoInternacaoAgendaWEB.Vai();

            //AvisoTelemedicinaSemTelefone.EnviarAvisos();

            Console.WriteLine("Done");
            Console.Read();


#else



            ServiceBase[] ServicesToRun;

            // More than one user Service may run within the same process. To add
            // another service to this process, change the following line to
            // create a second service object. For example,
            //
            //   ServicesToRun = new ServiceBase[] {new Service1(), new MySecondUserService()};
            //
            ServicesToRun = new ServiceBase[] { new AgenteService() };

            ServiceBase.Run(ServicesToRun);

    
            Wrapper wrapper = new Wrapper();
            wrapper.Start();
            Console.Read();
#endif
        }
    }
}