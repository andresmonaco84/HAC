using System;
using System.Configuration;
using System.ServiceProcess;
using System.Timers;
using HospitalAnaCosta.SGS.InterfaceAgendaWeb;
using InterfaceAgendaWeb;
using System.Collections.Generic;

namespace SGS.AgenteService
{
    partial class AgenteService : ServiceBase
    {
        public AgenteService()
        {

            timerMensagemRespostas.Elapsed += TimerMensagemRespostas_Elapsed;
            timerMensagem.Elapsed += TimerMensagem_Elapsed;
            timerBeneficiarios.Elapsed += TimerBeneficiarios_Elapsed;
            timerEscalas.Elapsed += TimerEscalas_Elapsed;
            timerHistoricoInternacao.Elapsed += TimerHistoricoInternacao_Elapsed;
            timerFeriados.Elapsed += TimerFeriados_Elapsed;
            timerElegibilidade.Elapsed += timerElegibilidade_Elapsed;
            timerAutaComplexidade.Elapsed += timerAutaComplexidade_Elapsed;
            timerMensagemEmail.Elapsed += TimerMensagemEmail_Elapsed;
            timerMensagemClientControl.Elapsed += TimerMensagem_ClientControl;
            timerLinksTeleconsulta.Elapsed += TimerLinksTeleconsulta_Elapsed;
            timerCargaEnviosWhatsApp.Elapsed += TimerCargaEnviosWhatsApp_Elapsed;
            timerPendenciasBradesco.Elapsed += TimerPendenciasBradesco_Elapsed;
            timerBasePortalACS.Elapsed += TimerBasePortalACS_Elapsed;
        }

        private void TimerBasePortalACS_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!executandoBasePortalACS && DateTime.Now.Hour == 5)
            {
                executandoBasePortalACS = true;

                try
                {
                    AtualizaBasePortalACS.DumpData();
                }
                finally
                {
                    executandoBasePortalACS = false;
                    
                }
            }
        }

        private void TimerPendenciasBradesco_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!executandoPendenciasBradesco && DateTime.Now.Hour == 14)
            {
                executandoPendenciasBradesco = true;

                try
                {
                    PendenciasBradesco.Executa();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    executandoPendenciasBradesco = false;

                }


            }

        }

        private void TimerCargaEnviosWhatsApp_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!executandoCargaEnviosWhatsApp)
            {
                executandoCargaEnviosWhatsApp = true;

                try
                {
                    AtualizaMensageiro.CarregarMensagensParaEnviar();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    executandoCargaEnviosWhatsApp = false;

                }

                
            }
          
        }

        public void TimerLinksTeleconsulta_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(!executandoLinksTeleconsulta && DateTime.Now.Hour == 18)
            {
                executandoLinksTeleconsulta = true;
                try
                {
                    SmsSender.EnviarLembretesLinksTeleconsulta();
                }
                finally
                {

                    executandoLinksTeleconsulta = false;
                }
                

               
            }
        }

        public void TimerMensagemRespostas_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (executandoMensagemRespostas || !(new List<int> { 5, 10, 15, 20 }.Contains(DateTime.Now.Hour)) )
            {
                return;
            }

            try
            {
                executandoMensagemRespostas = true;
                SmsSender.ProcessarRespostas();
                AtualizaMensageiro.CarregarRespostasWhatsApp();

            }
            finally
            {

                executandoMensagemRespostas = false;
            }

        }

        public void TimerMensagemEmail_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (executandoEmail) return;


            try
            {
                executandoEmail = true;

                Mailer.Processar();

            }
            finally
            {
                executandoEmail = false;

            }

        }

        public void TimerMensagem_ClientControl(object sender, ElapsedEventArgs e)
        {
            if (executandoClientControl) return;

            try
            {

                executandoClientControl = true;
                MensagemClientControl.Executa();

            }
            finally
            {
                executandoClientControl = false;
            }

        }

        public void timerAutaComplexidade_Elapsed(object sender, ElapsedEventArgs e)
        {
            
            if (5 == DateTime.Now.Hour)
            {

                try
                {
                    AtualizaAutaComplexidade.Vai();

                }
                finally
                {

                }
            }

        }

        void timerElegibilidade_Elapsed(object sender, ElapsedEventArgs e)
        {

#if DEBUG
       //    AtualizaElegibilidade.Vai();
#endif

            if (!executandoElegibilidade && ConfigurationManager.AppSettings["BENEFICIARIO_HORA"] == DateTime.Now.Hour.ToString())
            {

                try
                {
                    executandoElegibilidade = true;
                    AtualizaElegibilidade.Vai();

                }
                finally
                {
                    executandoElegibilidade = false;
                }
            }

        }

        public void TimerFeriados_Elapsed(object sender, ElapsedEventArgs e)
        {
#if DEBUG
         //   AtualizaFeriadoAgendaWEB.Vai();
#endif

            if (!executandoFeriados && ConfigurationManager.AppSettings["FERIADO_HORA"] == DateTime.Now.Hour.ToString())
            {
                

                try
                {
                
                    executandoFeriados = true;
                    AtualizaFeriadoAgendaWEB.Vai();
                }
                finally
                {
                    executandoFeriados = false;

                }
            }
        }

        public void TimerHistoricoInternacao_Elapsed(object sender, ElapsedEventArgs e)
        {

#if DEBUG
            //AtualizaHistoricoInternacaoAgendaWEB.Vai();
#endif

            if (!executandoHistoricoInternacao)
            {
                //new Impersonation().Impersonate();

                try
                {
                    executandoHistoricoInternacao = true;
                    AtualizaHistoricoInternacaoAgendaWEB.Vai();
                }
                finally
                {
                    executandoHistoricoInternacao = false;

                }
            }
        }

        public void TimerEscalas_Elapsed(object sender, ElapsedEventArgs e)
        {
#if DEBUG
       //     AtualizaEscalasAgendaWEB.Vai();
#endif

            if (!executandoEscalas && ConfigurationManager.AppSettings["ESCALA_HORA"] == DateTime.Now.Hour.ToString())
            {
             //   new Impersonation().Impersonate();

                try
                {
                    executandoEscalas = true;
                    AtualizaEscalasAgendaWEB.Vai();
                }
                finally
                {
                    executandoEscalas = false;
                }
            }
        }

        public void TimerBeneficiarios_Elapsed(object sender, ElapsedEventArgs e)
        {
#if DEBUG
            AtualizaElegibilidade.Vai();

            //AtualizaBeneficiarioAgendaWEB.Vai();

            //AtualizaRestricaoWEB.Executa();

            //AtualizaHistoricoInternacaoAgendaWEB.Vai();

            //AtualizaEscalasAgendaWEB.Vai();


#endif
            if (!executandoBeneficiarios && (ConfigurationManager.AppSettings["BENEFICIARIO_HORA"] == DateTime.Now.Hour.ToString() || DateTime.Now.Hour == 13))
            {
               // new Impersonation().Impersonate();

                try
                {
                    executandoBeneficiarios = true;                   


                    //AtualizaBeneficiarioAgendaWEB.Vai();
                    AtualizaBeneficiario.Atualiza();

                    AtualizaRestricaoWEB.Executa();

                    AvisoTelemedicinaSemTelefone.EnviarAvisos();
                }
                finally
                {
                    executandoBeneficiarios = false;
                }
            }
        }

        public void TimerMensagem_Elapsed(object sender, ElapsedEventArgs e)
        {
            
            if (!executandoMensagem)
            {                

                try
                {
                    executandoMensagem = true;
                                  

                    SmsSender.Processar();
                    

                }
                finally
                {
                    executandoMensagem = false;
                }
             
            }
        }

        protected override void OnStart(string[] args)
        {
            //  new Impersonation().Impersonate();
            timerMensagemRespostas.Start();
            timerMensagem.Start();
            timerBeneficiarios.Start();
            timerEscalas.Start();
            timerFeriados.Start();
            timerHistoricoInternacao.Start();
            timerElegibilidade.Start();
            timerAutaComplexidade.Start();
            timerMensagemEmail.Start();
            timerMensagemClientControl.Start();
            timerLinksTeleconsulta.Start();
            timerCargaEnviosWhatsApp.Start();
            timerPendenciasBradesco.Start();
            timerBasePortalACS.Start();

        }

        protected override void OnStop()
        {
            //      new Impersonation().Revert();
            timerMensagem.Stop();
            timerBeneficiarios.Stop();
            timerEscalas.Stop();
            timerFeriados.Stop();
            timerHistoricoInternacao.Stop();
            timerElegibilidade.Stop();
            timerAutaComplexidade.Stop();
            timerMensagemEmail.Stop();
            timerMensagemClientControl.Stop();
            timerMensagemRespostas.Stop();
            timerLinksTeleconsulta.Stop();
            timerCargaEnviosWhatsApp.Stop();
            timerPendenciasBradesco.Stop();
            timerBasePortalACS.Stop();
        }

    }
}
