using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Collections;
using System.Drawing;
using System.Collections.Specialized;
using System.Configuration;
using System.Windows.Forms;

namespace HospitalAnaCosta.SGS.Impressao
{
    public enum EnumTipoEtiqueta
    {
        Atendimento = 0,
        Liberacao = 1,
        Clinica = 2,
        Paciente = 3,
        ExameLiberacao = 4,
        LaminaSADT = 5,
        EnvelopeProtocoloSADT = 6,
        EntregaSADT = 7,
        InternacaoCompleta = 8,
        InternacaoSimples = 9,
        FaturamentoConvenio = 10,
       // Atestado = 11,
    }

    public abstract class Etiqueta
    {
        protected abstract void Consultar();

        protected abstract void MontarLayout(object sender, PrintPageEventArgs evPP);

        public abstract void Imprimir();
        
        public string VerificaImpressaoCodigoDeBarras(string nomeImpressora,bool possuiCodigoDeBarras) {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            if (possuiCodigoDeBarras && nomeImpressora == appSettings["IMPRESSORA_ZEBRA"].ToString())
            {
                bool existeImpressoraGenericInstalada = false;
                foreach (string impressorasInstaladas in PrinterSettings.InstalledPrinters)
                {
                    if (impressorasInstaladas == appSettings["IMPRESSORA_GENERIC"].ToString())
                        existeImpressoraGenericInstalada = true;
                }
                if (!existeImpressoraGenericInstalada)
                    MessageBox.Show(string.Format("Impressora {0} não esta instalada.\nNão será possível imprimir o código de barras.\nFavor entrar em contato com o suporte.", appSettings["IMPRESSORA_GENERIC"].ToString()));

                nomeImpressora = appSettings["IMPRESSORA_GENERIC"].ToString();
            }

            return nomeImpressora;
        }

        protected PrintDocument ConfigurarEtiquetaPadrao(Entity e)
        {
            PrintDocument etiqueta = new PrintDocument();

            etiqueta.PrinterSettings.PrinterName = e.NomeImpressora; // ConfigurationManager.AppSettings["ImpressoraTermica"];
            // formata o tamanho da etiqueta a ser impressa (em centésimos de polegadas)
            PaperSize configPapel = new PaperSize("Custom Paper Size", 410, 170);
            etiqueta.DefaultPageSettings.PaperSize = configPapel;
            etiqueta.DefaultPageSettings.Landscape = false;
            etiqueta.DefaultPageSettings.PrinterSettings.Copies = (short)e.QuantidadeCopias;
            // formata o tamanho das margens da etiqueta (em centésimos de polegadas)
            Margins configMargem = new Margins(1, 1, 1, 1);
            etiqueta.DefaultPageSettings.Margins = configMargem;

            return etiqueta;
        }
    }
}
