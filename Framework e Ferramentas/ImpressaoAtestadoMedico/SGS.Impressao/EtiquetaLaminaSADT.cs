using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Collections;
using System.Drawing;
using PrinterClassDll;
using System.Globalization;
using System.Configuration;
using System.Collections.Specialized;

namespace HospitalAnaCosta.SGS.Impressao
{ 
    public class EtiquetaLaminaSADT : Etiqueta
    {
        private PrintDocument etiqueta;
        private LaminaSADTEntity laminaSADTEntity;
        NameValueCollection appSettings = ConfigurationManager.AppSettings;

        private PrintDocument FormatarEtiquetaMatricial(Entity e)
        {
            try
            {
                 int larguraEtiqueta  = 440;
                 int alturaEtiqueta = 150;
                 int margemEsquerda = 62;
                 int margemDireita = 47;
                 int margemTopo = 0;
                 int margemBaixo = 5;

                 PrintDocument etiqueta = new PrintDocument();
                 etiqueta.PrinterSettings.PrinterName = e.NomeImpressora;
                 etiqueta.DefaultPageSettings.PrinterSettings.Copies = (short)e.QuantidadeCopias;
                // formata o tamanho da etiqueta a ser impressa (em centésimos de polegadas)
                // PaperSize configPapel = new PaperSize("Custom Paper Size", 440, 150); //511, 150); // (511.81 x 149.60)
                PaperSize configPapel = new PaperSize("Custom Paper Size", larguraEtiqueta, alturaEtiqueta);
                etiqueta.DefaultPageSettings.PaperSize = configPapel;
                // formata o tamanho das margens da etiqueta (em centésimos de polegadas)
                //Margins configMargem = new Margins(62, 47, 0, 5); // (47.244 x 03.94)
                Margins configMargem = new Margins(margemEsquerda, margemDireita, margemTopo, margemBaixo);
                etiqueta.DefaultPageSettings.Margins = configMargem;
                // para evitar passar duas vezes com o carro de impressão (e "borrar" a etiqueta), recebe o tipo de resolução como parâmetro
                etiqueta.DefaultPageSettings.PrinterResolution.Kind = PrinterResolutionKind.Low;

                return etiqueta;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("FormatarEtiquetaMatricial: {0}", ex.Message));
            }

        }

        public EtiquetaLaminaSADT(LaminaSADTEntity entity)
        {            
            //entity.NomeImpressora = VerificaImpressaoCodigoDeBarras(entity.NomeImpressora, entity.PossuiCodigoDeBarras);
            
            etiqueta = ConfigurarEtiquetaPadrao(entity);
            laminaSADTEntity = entity;
        }
        
        protected override void Consultar()
        {
            laminaSADTEntity = new LaminaSADTData().Consultar(laminaSADTEntity);
        }
       
        public override void Imprimir()
        {
            try
            {
                {
                    Consultar();
                    etiqueta.PrintPage += new PrintPageEventHandler(MontarLayout);
                    etiqueta.Print();
                }

            }
            catch (IndexOutOfRangeException ex)
            {
                throw new Exception("Falha ao imprimir etiqueta de Lamina SADT!\n" + ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.Message == "0")
                    throw new Exception("Falha ao abrir etiqueta de Lamina SADT.");
                else if (ex.Message == "1")
                    throw new Exception("Atendimento SADT esta cancelado.");
               
                else
                    throw new Exception("Falha ao imprimir a etiqueta. \n" + ex.Message);
            }
            GC.Collect();
        }

        protected override void MontarLayout(object sender, PrintPageEventArgs evPP)
        {
            // declaração das coordenadas para impressão
            // short iMargemEsquerda = 15, iMargemTopo = -7, iTamLinha = 14; //, iTamLinhaNegrito = 17;
            short coluna = 15;
            short linha = 10;
            // declara os tipos de fontes, cores, etc. que serão utilizados na etiqueta
            Font fontDetalheDestaqueNegrito;
            Font fontDetalheNegrito;
            Font fontDetalhe;

            #region Formatação da Etiqueta para Impressão

            fontDetalheDestaqueNegrito = new Font(FontFamily.GenericMonospace, 9, FontStyle.Bold);
            fontDetalheNegrito = new Font(FontFamily.GenericMonospace, 8, FontStyle.Bold);
            fontDetalhe = new Font(FontFamily.GenericMonospace, 8);

            //fontDetalheDestaqueNegrito = new Font("Lucida Sans", 9, FontStyle.Bold);
            //fontDetalheNegrito = new Font("Lucida Sans", 8, FontStyle.Bold);
            //fontDetalhe = new Font("Lucida Sans", 8);            

            // localAtendimento = localAtendimento.Split(':')[1].ToString().Trim();
            // localAtendimento = localAtendimento.Trim().Equals("-") ? "" : localAtendimento;

            // linha 1
            evPP.Graphics.DrawString(string.Format("{0}.: {1}",laminaSADTEntity.TipoIntLib == "L" ? "LIB" : "INT", laminaSADTEntity.Atendimento), fontDetalheNegrito, Brushes.Black, coluna, linha);
            evPP.Graphics.DrawString(laminaSADTEntity.DataAtendimento, fontDetalheDestaqueNegrito, Brushes.Black, coluna + 120, linha);
            // linha 2
            evPP.Graphics.DrawString(laminaSADTEntity.Paciente.PadRight(55).Substring(0,53), fontDetalheNegrito, Brushes.Black, coluna, linha * 2);
            // linha 3
            evPP.Graphics.DrawString(laminaSADTEntity.Local, fontDetalheNegrito, Brushes.Black, coluna, linha * 3);
            evPP.Graphics.DrawString(string.Concat("Proced.: ",laminaSADTEntity.Setor), fontDetalhe, Brushes.Black, coluna + 160, linha * 3); 
            // linha 4
            evPP.Graphics.DrawString(string.Concat("Nro. Exame: ",laminaSADTEntity.CodigoExame), fontDetalheNegrito, Brushes.Black, coluna, linha * 4);

            #endregion

            evPP.HasMorePages = false;

            fontDetalheDestaqueNegrito.Dispose();
            fontDetalheNegrito.Dispose();
            fontDetalhe.Dispose();
        }

    }


}
