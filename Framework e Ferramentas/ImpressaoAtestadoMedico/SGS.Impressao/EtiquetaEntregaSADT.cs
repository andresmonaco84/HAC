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
    public class EtiquetaEntregaSADT : Etiqueta
    {
        private PrintDocument etiqueta;
        private EntregaSADTEntity entregaSADTEntity;
        NameValueCollection appSettings = ConfigurationManager.AppSettings;

        public EtiquetaEntregaSADT(EntregaSADTEntity entity)
        {
            entity.NomeImpressora = VerificaImpressaoCodigoDeBarras(entity.NomeImpressora, entity.PossuiCodigoDeBarras);
            
            etiqueta = ConfigurarEtiquetaPadrao(entity);
            entregaSADTEntity = entity;
        }

        protected override void Consultar()
        {
            entregaSADTEntity = new EntregaSADTData().Consultar(entregaSADTEntity);
        }
       
        public override void Imprimir()
        {
            try
            {
                Consultar();
                etiqueta.PrintPage += new PrintPageEventHandler(MontarLayout);
                etiqueta.Print();
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new Exception("Falha ao imprimir etiqueta de Atendimento SADT!\n" + ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.Message == "0")
                    throw new Exception("Falha ao abrir etiqueta de Atendimento SADT.");
                else if (ex.Message == "1")
                    throw new Exception("Atendimento SADT esta cancelado.");
               
                else
                    throw new Exception("Falha ao imprimir a etiqueta. \n" + ex.Message);
            }
            GC.Collect();
        }

        protected override void MontarLayout(object sender, PrintPageEventArgs evPP)
        {
            string barCode = entregaSADTEntity.Atendimento;
            
            if (etiqueta.PrinterSettings.PrinterName == appSettings["IMPRESSORA_GENERIC"].ToString()) //ZEBRA força pela impressora Generic
            {
                //etiqueta.PrinterSettings.PrinterName = "Generic / Text Only";
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

                w32prn.PrintText(string.Format("A{0},{1},0,4,1,1,N,\"{2}\"", x, y, entregaSADTEntity.Atendimento));

                // X , Y , ROTATION, BARCODE SELECTION, NARROW BAR WIDTH, WIDE BAR WDTH, BAR CODE HEIGHT, PRINT HUMAN READABLE CODE
                w32prn.PrintText(string.Format("B{0},{1},0,3,2,5,50,N,\"{2}\"", 400, 5, barCode)); //300,30  CODE 39 3,2,5 é o q melhor lê

                //2
                y += entreLinhas + 20;
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Unid: {2}\"", x, y, entregaSADTEntity.Unidade.PadRight(20).Substring(0, 15)));
                w32prn.PrintText(string.Format("A{0},{1},0,2,1,1,N,\"Local: {2}\"", x + 320, y, entregaSADTEntity.Local));
                w32prn.PrintText(string.Format("A{0},{1},0,2,1,1,N,\"Setor: {2}\"", x + 520, y, entregaSADTEntity.Setor));

                //3
                y += entreLinhas;
                w32prn.PrintText(string.Format("A{0},{1},0,2,1,1,N,\"Data: {2}\"", x, y, entregaSADTEntity.DataAtendimento));
                w32prn.PrintText(string.Format("A{0},{1},0,2,1,1,N,\"Hora: {2}\"", x + 250, y, Convert.ToInt32(entregaSADTEntity.HoraAtendimento).ToString("00:00")));
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Medico: {2}\"", x + 440, y, entregaSADTEntity.Medico.PadRight(30).Substring(0, 14)));   //.PadRight(30).Substring(0, 28)

                //4
                y += entreLinhas;
                w32prn.PrintText(string.Format("A{0},{1},0,2,1,1,N,\"Conv: {2}\"", x, y, entregaSADTEntity.CodigoConvenio + " - " + entregaSADTEntity.Convenio.PadRight(30).Substring(0, 20)));
                w32prn.PrintText(string.Format("A{0},{1},0,2,1,1,N,\"Padrão: {2}\"", x + 520, y, entregaSADTEntity.Padrao));

                //5
                y += entreLinhas;
                w32prn.PrintText(string.Format("A{0},{1},0,2,1,1,N,\"Plano: {2}\"", x, y, entregaSADTEntity.CodigoPlano + " - " + entregaSADTEntity.Plano.PadRight(30).Substring(0, 20)));
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Tipo: {2}\"", x + 520, y, entregaSADTEntity.TipoPlano));

                //6
                y += entreLinhas;
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Nome: {2}\"", x, y, entregaSADTEntity.Paciente.PadRight(50).Substring(0, 45)));

                //7
                y += entreLinhas;
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Nasc: {2}\"", x, y, entregaSADTEntity.DataNascimento));
                w32prn.PrintText(string.Format("A{0},{1},0,2,1,1,N,\"Idade:{2}\"", x + 235, y, entregaSADTEntity.Idade));
                w32prn.PrintText(string.Format("A{0},{1},0,2,1,1,N,\"Sexo:{2}\"", x + 360, y, entregaSADTEntity.Sexo));
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Tipo Atend: {2}\"", x + 480, y, entregaSADTEntity.TipoAtendimento.PadRight(10).Substring(0, 8)));

                //8
                y += entreLinhas;
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Matric: {2}\"", x, y, entregaSADTEntity.Credencial));
                w32prn.PrintText(string.Format("A{0},{1},0,2,1,1,N,\"Tel: {2}\"", x + 450, y, entregaSADTEntity.Telefone));

                //9
                y += entreLinhas;
                w32prn.PrintText(string.Format("A{0},{1},0,2,1,1,N,\"RG: {2}\"", x, y, entregaSADTEntity.RG));
                if(entregaSADTEntity.Origem == "1")
                    w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Valid: {2}\"", x + 240, y, entregaSADTEntity.Validade));

                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Pront: {2}\"", x + 510, y, entregaSADTEntity.Prontuario));

                w32prn.PrintText(string.Format("P{0}", etiqueta.PrinterSettings.Copies)); //qtd de impressoes
                w32prn.EndDoc();
           }
           //else if (etiqueta.PrinterSettings.PrinterName.ToUpper().Contains("BIXOLON"))
           //{
            //   PrinterClassDll.Win32Print w32prn = new PrinterClassDll.Win32Print();
            //T26,49,1,0,0,0,0,N,N,‟Font - 8 pt‟
            //T26,81,2,0,0,0,0,N,N,‟Font - 10 pt‟
            //T26,117,3,0,0,0,0,N,N,‟Font - 12 pt‟
             //   w32prn.PrintText(string.Format("T{0},{1},3,0,0,0,0,N,N,\"{2}\"",x,y,entregaSADTEntity.Atendimento));
             //   w32prn.PrintText(string.Format("B1{0},{1},0,2,6,100,0,0\"{2}\"",400,5,barCode));

            //int x = 5;
            //    int y = 20;
            //    short entreLinhas = 30;
           //      w32prn.SetPrinterName(etiqueta.PrinterSettings.PrinterName);
           //      w32prn.OpenCashdrawer(2);

                 
           //     w32prn.SetDeviceFont(15f, "JAN13(EAN)", false, false); //substituir por CODE 39
           //     w32prn.PrintText(barCode.ToString().PadLeft(12, '0')); //.PadLeft(12, '0')

           //      w32prn.SetDeviceFont(8f, "FontA1x1", false, false);
           //      w32prn.PrintText(entregaSADTEntity.Atendimento);

           //      w32prn.PrintText("Unid.: " + entregaSADTEntity.Unidade + " Local: " + entregaSADTEntity.Local + "  Setor: " + entregaSADTEntity.Setor);

           //      w32prn.PrintText("Data: " + entregaSADTEntity.DataAtendimento + "   Hora: " + Convert.ToInt32(entregaSADTEntity.HoraAtendimento).ToString("00:00") + "   Medico: " + entregaSADTEntity.Medico);

           //      w32prn.PrintText("Conv.: " + entregaSADTEntity.CodigoConvenio + " - " + entregaSADTEntity.Convenio.PadRight(30).Substring(0, 28) + " Padrão: " + entregaSADTEntity.Padrao);
           //      w32prn.PrintText("Plano: " + entregaSADTEntity.CodigoPlano + " - " + entregaSADTEntity.Plano.PadRight(30).Substring(0, 28) + "Tipo: " + entregaSADTEntity.TipoPlano);

           //      w32prn.PrintText("Nome: " + entregaSADTEntity.Paciente);

           //      w32prn.PrintText("Nasc.: " + entregaSADTEntity.DataNascimento + "  Idade: " + entregaSADTEntity.Idade + "  Sexo:" + entregaSADTEntity.Sexo + "  Tipo Atend.: " + entregaSADTEntity.TipoAtendimento);
           //      w32prn.PrintText("Matric.: " + entregaSADTEntity.Credencial + "         Tel.: " + entregaSADTEntity.Telefone);

           //      w32prn.PrintText("RG: " + entregaSADTEntity.RG + entregaSADTEntity.Origem == "1" ? "   Valid.: " + entregaSADTEntity.Validade : "" + "   Pront.: " + entregaSADTEntity.Prontuario);
               
           //      w32prn.EndDoc();
           //}
           else
           {
               // declaração das coordenadas para impressão
               short iMargemEsquerda = 8, iMargemTopo = 7, iTamLinha = 14, iNroLinha = 1;

               // declara os tipos de fontes, cores, etc. que serão utilizados na etiqueta
               Font fontDetalheDestaqueNegrito;
               Font fontDetalheNegrito;
               Font fontDetalhe;
               //Font fontDetalhePequenoNegrito;

               #region Formatação da Etiqueta para Impressão
               // rotina para impressão da etiqueta
               // se for imprimir na térmica (TipoImpressora = 1), aumenta a distância entre as linhas
               //if (TipoImpressora == 1)
               //{
                   iMargemEsquerda += 3;
                   //iMargemTopo += 1;
                   iTamLinha += 2;
                   fontDetalheDestaqueNegrito = new Font("Lucida Sans", 9, FontStyle.Bold);
                   fontDetalheNegrito = new Font("Lucida Sans", 8, FontStyle.Bold);
                   fontDetalhe = new Font("Lucida Sans", 8);
                   //                fontDetalhePequenoNegrito = new Font("Lucida Sans", 6, FontStyle.Bold);
               //}
               //else
               //{
               //    fontDetalheDestaqueNegrito = new Font("Lucida Sans", 8, FontStyle.Bold);
               //    fontDetalheNegrito = new Font("Lucida Sans", 7, FontStyle.Bold);
               //    fontDetalhe = new Font("Lucida Sans", 7);
               //    //                fontDetalhePequenoNegrito = new Font("Lucida Sans", 6, FontStyle.Bold);
               //}
                   string strDataRealizacao = "";
                   //try
                   //{
                      
                   //    if (entregaSADTEntity.DataAtendimento.Contains(";"))
                   //    {
                   //        // para o caso de valores como "Data: 01/01/2000;01/01/2000"
                   //        if (entregaSADTEntity.DataAtendimento.Split(';')[0].Length > 0)
                   //            strDataRealizacao = Convert.ToDateTime(entregaSADTEntity.DataAtendimento.Split(',')[0]).ToString("dd/MM/yyyy");
                   //        // para o caso de valores como "Data: 01/01/2000"
                   //        else
                   //            strDataRealizacao = Convert.ToDateTime(entregaSADTEntity.DataAtendimento.Split(':')[1]).ToString("dd/MM/yyyy");
                   //    }
                   //}
                   //catch (Exception)
                   //{
                       
                   //    throw;
                   //}
              
               //if (strDataRealizacao.Length == 0)
               //    strDataRealizacao = entregaSADTEntity.DataAtual;
               //else
                   strDataRealizacao = entregaSADTEntity.DataAtendimentoSelecionado;

               // 1a. linha (Nro. Atendimento e Data (de entrega))
               evPP.Graphics.DrawString(string.Concat("ATEND.: ", entregaSADTEntity.Atendimento), fontDetalheDestaqueNegrito, Brushes.Black, iMargemEsquerda, iMargemTopo);
               evPP.Graphics.DrawString(string.Concat("Data: ", strDataRealizacao), fontDetalheDestaqueNegrito, Brushes.Black, iMargemEsquerda + 160, iMargemTopo);

               // 2a. linha (Convênio, Plano, Nome do Paciente)
               iNroLinha++;
               evPP.Graphics.DrawString(string.Format("Conv./Plano: {0} : / {1} {2}", entregaSADTEntity.CodigoConvenio, entregaSADTEntity.CodigoPlano , entregaSADTEntity.Plano.PadRight(40).Substring(0,8)), fontDetalheNegrito, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha);
               evPP.Graphics.DrawString(string.Concat("Proced.: ", entregaSADTEntity.Setor), fontDetalhe, Brushes.Black, iMargemEsquerda + 230, iMargemTopo + iTamLinha);
               
                // 3a. linha 
               evPP.Graphics.DrawString(string.Concat("Paciente: ", entregaSADTEntity.Paciente.PadRight(60).Substring(0, 58)), fontDetalheNegrito, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * iNroLinha);

               // 4a. linha (Unidade, Local Atendimento, Setor)
               iNroLinha++;
               evPP.Graphics.DrawString("Unid.: " + entregaSADTEntity.Unidade.PadRight(30).Substring(0,20), fontDetalheNegrito, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * iNroLinha);
               evPP.Graphics.DrawString("Local: " + entregaSADTEntity.Local.PadRight(30).Substring(0, 12), fontDetalheNegrito, Brushes.Black, iMargemEsquerda + 160, iMargemTopo + iTamLinha * iNroLinha);
               evPP.Graphics.DrawString("Setor: " + entregaSADTEntity.Setor.PadRight(30).Substring(0, 12), fontDetalheNegrito, Brushes.Black, iMargemEsquerda + 270, iMargemTopo + iTamLinha * iNroLinha);

               // 5a. linha (Endereço de entrega)
               iNroLinha++;
               evPP.Graphics.DrawString(string.Concat("End. Entrega: ", entregaSADTEntity.UnidadeEntrega), fontDetalhe, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * iNroLinha);

               // 5a. linha (Código do exame (todos os códigos))
               string[] strCodExameTemp;
               char cToken = ';';

               strCodExameTemp = entregaSADTEntity.MnemonicoProduto.Split(cToken);

               string[] strDataEntregaTemp;
               strDataEntregaTemp = entregaSADTEntity.DataResultado.Split(cToken);
               string strDataTemp = string.Empty;
               
               iMargemTopo++;
               
               bool bQuebraLinha = false;

               for (short iCont = 0; iCont < strCodExameTemp.Length; iCont++)
               {
                   // a cada 3 exames, quebra a linha
                   bQuebraLinha = ((iCont) % 3) == 0;

                   if (strDataTemp != strDataEntregaTemp[iCont])
                   {
                       iNroLinha++;
                       iMargemEsquerda = 8;
                       evPP.Graphics.DrawString("Dt Entrega: ", fontDetalheNegrito, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * (iNroLinha));
                       evPP.Graphics.DrawString(strDataEntregaTemp[iCont], fontDetalheDestaqueNegrito, Brushes.Black, iMargemEsquerda + 70, iMargemTopo - 1 + iTamLinha * (iNroLinha));
                       iMargemEsquerda += 150;
                   }
                   else if (bQuebraLinha)
                   {
                       iNroLinha++;
                       iMargemEsquerda = 158;
                   }
                   else
                       iMargemEsquerda += 80;


                   evPP.Graphics.DrawString(strCodExameTemp[iCont], fontDetalhe, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * (iNroLinha));

                   strDataTemp = strDataEntregaTemp[iCont];
               }

               #endregion

               evPP.HasMorePages = false;

               fontDetalheDestaqueNegrito.Dispose();
               fontDetalheNegrito.Dispose();
               fontDetalhe.Dispose();

            }
        }

    }


}
