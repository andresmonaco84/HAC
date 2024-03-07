    using System;
using System.Configuration;
using System.Timers;

namespace SGS.AgenteService
{
    partial class AgenteService
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        System.ComponentModel.IContainer components = null;

        bool executandoMensagem = (ConfigurationManager.AppSettings["MENSAGEM_ATIVO"] != "S");
        bool executandoClientControl = false;
        bool executandoEmail = false;

        Timer timerMensagemRespostas = new Timer(TimeSpan.FromHours(1).TotalMilliseconds);
        bool executandoMensagemRespostas = false;

        Timer timerLinksTeleconsulta = new Timer(TimeSpan.FromHours(1).TotalMilliseconds);
        bool executandoLinksTeleconsulta = false;

        Timer timerMensagem = new Timer(1000 * 60);
        Timer timerMensagemClientControl = new Timer(1000 * 60);
        Timer timerMensagemEmail = new Timer(1000 * 60);

        Timer timerCargaEnviosWhatsApp = new Timer(TimeSpan.FromHours(1).TotalMilliseconds);
        bool executandoCargaEnviosWhatsApp = false;

        Timer timerPendenciasBradesco = new Timer(TimeSpan.FromHours(1).TotalMilliseconds);
        bool executandoPendenciasBradesco = false;


        Timer timerElegibilidade = new Timer(Convert.ToInt32(ConfigurationManager.AppSettings["BENEFICIARIO_INTERVALO"]) * 1000 * 60);

        Timer timerAutaComplexidade = new Timer(60 * 1000 * 60);        

        bool executandoElegibilidade = (ConfigurationManager.AppSettings["BENEFICIARIO_ATIVO"] != "S");

        bool executandoBeneficiarios = (ConfigurationManager.AppSettings["BENEFICIARIO_ATIVO"] != "S");

        Timer timerBeneficiarios = new Timer(Convert.ToInt32(ConfigurationManager.AppSettings["BENEFICIARIO_INTERVALO"]) * 1000 * 60);

        bool executandoHistoricoInternacao = (ConfigurationManager.AppSettings["HISTORICOINTERNADO_ATIVO"] != "S");

        Timer timerHistoricoInternacao = new Timer(Convert.ToInt32(ConfigurationManager.AppSettings["HISTORICOINTERNADO_INTERVALO"]) * 1000 * 60);

        bool executandoEscalas = (ConfigurationManager.AppSettings["ESCALA_ATIVO"] != "S");

        Timer timerEscalas = new Timer(Convert.ToInt32(ConfigurationManager.AppSettings["ESCALA_INTERVALO"]) * 1000 * 60);

        bool executandoFeriados = (ConfigurationManager.AppSettings["FERIADO_ATIVO"] != "S");

        Timer timerFeriados = new Timer(Convert.ToInt32(ConfigurationManager.AppSettings["FERIADO_INTERVALO"]) * 1000 * 60);

        bool executandoBasePortalACS = false;

        Timer timerBasePortalACS = new Timer(60 * 1000 * 60);

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.ServiceName = "AgenteFaturamentoService";
        }

        #endregion
    }
}
