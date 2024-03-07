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
    public class EtiquetaExameLiberacao : Etiqueta
    {
        private PrintDocument etiqueta;
        private AtendimentoEntity atendimentoEntity;
        NameValueCollection appSettings = ConfigurationManager.AppSettings;
        Tools tools = new Tools();

        public EtiquetaExameLiberacao(AtendimentoEntity entity)
        {
            entity.NomeImpressora = VerificaImpressaoCodigoDeBarras(entity.NomeImpressora, entity.PossuiCodigoDeBarras);

            etiqueta = ConfigurarEtiquetaPadrao(entity);
            atendimentoEntity = entity;
        }
        
        protected override void Consultar()
        {
            atendimentoEntity = new ExameLiberacaoData().Consultar(atendimentoEntity);
        }

        public override void Imprimir()
        {
            try
            {
                {
                    Consultar();
                    tools.DataValidade(atendimentoEntity);
                    etiqueta.PrintPage += new PrintPageEventHandler(MontarLayout);
                    etiqueta.Print();
                }

            }
            catch (IndexOutOfRangeException ex)
            {
                throw new Exception("Falha ao imprimir etiqueta de Exame Liberação!\n" + ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.Message == "0")
                    throw new Exception("Falha ao abrir etiqueta de Exame Liberação.");
                if (ex.Message == "4")
                    throw new Exception("Não é possível liberar o exame após 30 dias da data do atendimento. Favor dar um novo atendimento.");
                else if (ex.Message == "5")
                    throw new Exception("Impressão cancelada.");
                else
                    throw new Exception("Falha ao imprimir a etiqueta. \n" + ex.Message);
            }
            GC.Collect();
        }

        protected override void MontarLayout(object sender, PrintPageEventArgs evPP)
        {
            if (atendimentoEntity.IDLocal == "27")
                atendimentoEntity.Local = "AMB";
            else if (atendimentoEntity.IDLocal == "30" || atendimentoEntity.IDLocal == "34")
                atendimentoEntity.Local = "P.S.";

            string barCode = atendimentoEntity.Atendimento;
            atendimentoEntity.Atendimento = atendimentoEntity.Origem == "0" ? "ATEND: " : "LIBER: " + atendimentoEntity.Atendimento;
            //Origem = 1 imprime Validade

            if (etiqueta.PrinterSettings.PrinterName == appSettings["IMPRESSORA_GENERIC"].ToString())
            {
                PrinterClassDll.Win32Print w32prn = new PrinterClassDll.Win32Print();
                w32prn.SetPrinterName(etiqueta.PrinterSettings.PrinterName); 

                w32prn.PrintText("ZB"); //orientação
                w32prn.PrintText("Q360,019"); //area
                w32prn.PrintText("q831");
                w32prn.PrintText("rN");
                w32prn.PrintText("S4");
                w32prn.PrintText("D6"); // densidade

                w32prn.PrintText("JB");
                w32prn.PrintText("OC200"); // enable label sensor OP
                w32prn.PrintText("R15,15"); //margem
                w32prn.PrintText("N"); //insere linha

                // w32prn.PrintText(string.Format("LO100,90,10,10"));
                // w32prn.PrintText(string.Format("LO50,50,10,10"));
                int x = 5;
                int y = 20;
                short entreLinhas = 30;

                w32prn.PrintText(string.Format("A{0},{1},0,4,1,1,N,\"{2}\"", x, y, atendimentoEntity.Atendimento));

                // X , Y , ROTATION, BARCODE SELECTION, NARROW BAR WIDTH, WIDE BAR WDTH, BAR CODE HEIGHT, PRINT HUMAN READABLE CODE
                w32prn.PrintText(string.Format("B{0},{1},0,3,2,5,50,N,\"{2}\"", 400, 5, barCode)); //300,30  CODE 39 2,5 é o q melhor lê

                //2
                y += entreLinhas + 20;
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Nome: {2}\"", x, y, atendimentoEntity.Paciente.PadRight(50).Substring(0, 45)));

                //7
                y += entreLinhas;               
                string[] strCodExameTemp;
                string[] strDescricaoExameTemp;
                string strDescExame = "";
                char cToken = ';';

                strCodExameTemp = atendimentoEntity.CodigoProduto.Split(cToken);
                strDescricaoExameTemp = atendimentoEntity.DescricaoProduto.Split(cToken);

                short iContLinhas = 1;
                for (short iCont = 0; iCont < strCodExameTemp.Length; iCont++)
                {
                    strDescExame = strDescricaoExameTemp[iCont];
                    w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"{2} - {3} : AUTORIZADO\"", x, y , strCodExameTemp[iCont], strDescExame.PadRight(40).Substring(0, 28)));

                    y += entreLinhas;
                    if ((iContLinhas % 6) == 0)
                    {
                        break;
                    }
                }

                w32prn.PrintText(string.Format("P{0}", etiqueta.PrinterSettings.Copies)); //qtd de impressoes
                w32prn.EndDoc();
           }
           //else if (etiqueta.PrinterSettings.PrinterName.ToUpper().Contains("BIXOLON"))
           //{
           //    PrinterClassDll.Win32Print w32prn = new PrinterClassDll.Win32Print();
           //      w32prn.SetPrinterName(etiqueta.PrinterSettings.PrinterName);
           //      w32prn.OpenCashdrawer(2);

                 
           //     w32prn.SetDeviceFont(15f, "JAN13(EAN)", false, false); //substituir por CODE 39
           //     w32prn.PrintText(barCode.ToString().PadLeft(12, '0')); //.PadLeft(12, '0')

           //      w32prn.SetDeviceFont(8f, "FontA1x1", false, false);
           //      w32prn.PrintText(atendimentoEntity.Atendimento);

           //      string[] strCodExameTemp;
           //      string[] strDescricaoExameTemp;
           //      string strDescExame = "";
           //      char cToken = ';';

           //      strCodExameTemp = atendimentoEntity.CodigoProduto.Split(cToken);
           //      strDescricaoExameTemp = atendimentoEntity.DescricaoProduto.Split(cToken);

           //      short iContLinhas = 1;
           //      for (short iCont = 0; iCont < strCodExameTemp.Length; iCont++)
           //      {
           //          strDescExame = strDescricaoExameTemp[iCont];
           //          w32prn.PrintText(string.Format("{0} - {1} : AUTORIZADO\"", strCodExameTemp[iCont], strDescExame.PadRight(40).Substring(0, 28)));

           //          //y += entreLinhas;
           //          if ((iContLinhas % 6) == 0)
           //          {
           //              break;
           //          }
           //      }
             
           //      w32prn.PrintText("Nome: " + atendimentoEntity.Paciente);

             
               
           //      w32prn.EndDoc();
           //}
           else
           {
               // declaração das coordenadas para impressão
               short iMargemEsquerda = 6, iMargemTopo = 1, iTamLinha = 14; //, iTamLinhaNegrito = 17;

               // declara os tipos de fontes, cores, etc. que serão utilizados na etiqueta
               Font fontDetalheDestaqueNegrito;
               Font fontDetalheNegrito;
               Font fontDetalhe;

               #region Formatação da Etiqueta para Impressão
               // rotina para impressão da etiqueta
               // se for imprimir na térmica, aumenta a distância entre as linhas
               //if (TipoImpressora == 1)
               //{
                   iMargemEsquerda += 3;
                   //iMargemTopo += 1;
                   iTamLinha += 5;
                   fontDetalheDestaqueNegrito = new Font("Lucida Sans", 9, FontStyle.Bold);
                   fontDetalheNegrito = new Font("Lucida Sans", 8, FontStyle.Bold);
                   fontDetalhe = new Font("Lucida Sans", 8);
               //}
               //else
               //{
               //    fontDetalheDestaqueNegrito = new Font("Lucida Sans", 8, FontStyle.Bold);
               //    fontDetalheNegrito = new Font("Lucida Sans", 7, FontStyle.Bold);
               //    fontDetalhe = new Font("Lucida Sans", 7);
               //}

               // 1a. linha (Nro. Liberação, Nome do Paciente)
               iMargemTopo++;
               evPP.Graphics.DrawString(atendimentoEntity.Atendimento, fontDetalheDestaqueNegrito, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha);
               //evPP.Graphics.DrawString(barCode, fontDetalheDestaqueNegrito, Brushes.Black, iMargemEsquerda + 150, iMargemTopo + iTamLinha);
               evPP.Graphics.DrawString(atendimentoEntity.Paciente.PadRight(55).Substring(0,53), fontDetalheNegrito, Brushes.Black, iMargemEsquerda + 120, iMargemTopo + iTamLinha);

               // 2a. linha (Cód. AMB, Descrição do Exame)
               // da 2a. a 7a. linhas, a etiqueta imprimirá o CÓD. AMB e a DESCRIÇÃO DO EXAME (além da palavra
               // AUTORIZADO) para popular as linhas com os códigos e descrições dos exames, a lógica faz
               // o programa "quebrar" a string que contem tais valores
               string[] strCodExameTemp;
               string[] strDescricaoExameTemp;
               string strDescExame = "";
               char cToken = ';';

               strCodExameTemp = atendimentoEntity.CodigoProduto.Split(cToken);
               strDescricaoExameTemp = atendimentoEntity.DescricaoProduto.Split(cToken);

               short iContLinhas = 0;
               for (short iCont = 0; iCont < strCodExameTemp.Length; iCont++)
               {
                   strDescExame = strDescricaoExameTemp[iCont];
                   evPP.Graphics.DrawString(strCodExameTemp[iCont] + " - ", fontDetalhe, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * (2 + iContLinhas));
                   evPP.Graphics.DrawString(strDescExame.PadRight(40).Substring(0,38) + ": AUTORIZADO", fontDetalhe, Brushes.Black, iMargemEsquerda + 62, iMargemTopo + iTamLinha * (2 + iContLinhas));
                   //if (strDescExame.Length > 38)
                   //    evPP.Graphics.DrawString(strDescExame.Remove(38) + ": AUTORIZADO", fontDetalhe, Brushes.Black, iMargemEsquerda + 62, iMargemTopo + iTamLinha * (2 + iContLinhas));
                   //else
                   //    evPP.Graphics.DrawString(strDescExame + ": AUTORIZADO", fontDetalhe, Brushes.Black, iMargemEsquerda + 62, iMargemTopo + iTamLinha * (2 + iContLinhas));
                   iContLinhas++;
                   if ((iContLinhas % 6) == 0)
                   {
                       //iMargemTopo = 1;
                       //iContLinhas = 0;
                       evPP.HasMorePages = true;
                   }
                   else
                       evPP.HasMorePages = false;
               }

               #endregion

               fontDetalheDestaqueNegrito.Dispose();
               fontDetalheNegrito.Dispose();
               fontDetalhe.Dispose();

            }
        }

    }


}
