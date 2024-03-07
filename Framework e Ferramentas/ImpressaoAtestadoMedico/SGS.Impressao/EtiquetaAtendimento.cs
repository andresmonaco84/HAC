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
    public class EtiquetaAtendimento : Etiqueta
    {
        private PrintDocument etiqueta;
        private AtendimentoEntity atendimentoEntity;
        NameValueCollection appSettings = ConfigurationManager.AppSettings;
        Tools tools = new Tools();

        public EtiquetaAtendimento(AtendimentoEntity entity)
        {
            try
            {
                entity.NomeImpressora = VerificaImpressaoCodigoDeBarras(entity.NomeImpressora, entity.PossuiCodigoDeBarras);
                etiqueta = ConfigurarEtiquetaPadrao(entity);
                atendimentoEntity = entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao imprimir a etiqueta. \n" + ex.Message);
            }
        }
        
        protected override void Consultar()
        {
            atendimentoEntity = new AtendimentoData().Consultar(atendimentoEntity);
        }
       
        public override void Imprimir()
        {
            try
            {
                Consultar();
                tools.DataValidade(atendimentoEntity);
                etiqueta.PrintPage += new PrintPageEventHandler(MontarLayout);
                etiqueta.Print();
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new Exception("Falha ao imprimir etiqueta de Atendimento!\n" + ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.Message == "0")
                    throw new Exception("Falha ao abrir etiqueta de Atendimento.");
                else if (ex.Message == "1")
                    throw new Exception("Atendimento esta cancelado.");
                else if (ex.Message == "2")
                    throw new Exception("Falha ao abrir etiqueta de Liberação.");
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
            atendimentoEntity.Atendimento = string.Format("{0}: {1}",atendimentoEntity.Origem == "0" ? "ATEND" : "LIBER" , atendimentoEntity.Atendimento);
            //Origem = 1 imprime Validade

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

                w32prn.PrintText(string.Format("A{0},{1},0,4,1,1,N,\"{2}\"", x, y, atendimentoEntity.Atendimento));

                // X , Y , ROTATION, BARCODE SELECTION, NARROW BAR WIDTH, WIDE BAR WDTH, BAR CODE HEIGHT, PRINT HUMAN READABLE CODE
                w32prn.PrintText(string.Format("B{0},{1},0,3,2,5,50,N,\"{2}\"", 400, 5, barCode)); //300,30  CODE 39 3,2,5 é o q melhor lê

                //2
                y += entreLinhas + 20;
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Unid: {2}\"", x, y, atendimentoEntity.Unidade.PadRight(20).Substring(0, 15)));
                w32prn.PrintText(string.Format("A{0},{1},0,2,1,1,N,\"Local: {2}\"", x + 320, y, atendimentoEntity.Local));
                w32prn.PrintText(string.Format("A{0},{1},0,2,1,1,N,\"Setor: {2}\"", x + 520, y, atendimentoEntity.Setor));

                //3
                y += entreLinhas;
                w32prn.PrintText(string.Format("A{0},{1},0,2,1,1,N,\"Data: {2}\"", x, y, atendimentoEntity.DataAtendimento));
                w32prn.PrintText(string.Format("A{0},{1},0,2,1,1,N,\"Hora: {2}\"", x + 250, y, Convert.ToInt32(atendimentoEntity.HoraAtendimento).ToString("00:00")));
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Medico: {2}\"", x + 440, y, atendimentoEntity.Medico.PadRight(30).Substring(0, 14)));   //.PadRight(30).Substring(0, 28)

                //4
                y += entreLinhas;
                w32prn.PrintText(string.Format("A{0},{1},0,2,1,1,N,\"Conv: {2}\"", x, y, atendimentoEntity.CodigoConvenio + " - " + atendimentoEntity.Convenio.PadRight(30).Substring(0, 20)));
                w32prn.PrintText(string.Format("A{0},{1},0,2,1,1,N,\"Padrão: {2}\"", x + 520, y, atendimentoEntity.Padrao));

                //5
                y += entreLinhas;
                w32prn.PrintText(string.Format("A{0},{1},0,2,1,1,N,\"Plano: {2}\"", x, y, atendimentoEntity.CodigoPlano + " - " + atendimentoEntity.Plano.PadRight(30).Substring(0, 20)));
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Tipo: {2}\"", x + 520, y, atendimentoEntity.TipoPlano));

                //6
                y += entreLinhas;
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Nome: {2}\"", x, y, atendimentoEntity.Paciente.PadRight(50).Substring(0, 45)));

                //7
                y += entreLinhas;
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Nasc: {2}\"", x, y, atendimentoEntity.DataNascimento));
                w32prn.PrintText(string.Format("A{0},{1},0,2,1,1,N,\"Idade:{2}\"", x + 235, y, atendimentoEntity.Idade));
                w32prn.PrintText(string.Format("A{0},{1},0,2,1,1,N,\"Sexo:{2}\"", x + 360, y, atendimentoEntity.Sexo));
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Tipo Atend: {2}\"", x + 480, y, atendimentoEntity.TipoAtendimento.PadRight(10).Substring(0, 8)));

                //8
                y += entreLinhas;
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Matric: {2}\"", x, y, atendimentoEntity.Credencial));
                w32prn.PrintText(string.Format("A{0},{1},0,2,1,1,N,\"Tel: {2}\"", x + 450, y, atendimentoEntity.Telefone));

                //9
                y += entreLinhas;
                w32prn.PrintText(string.Format("A{0},{1},0,2,1,1,N,\"RG: {2}\"", x, y, atendimentoEntity.RG));
                if(atendimentoEntity.Origem == "1")
                    w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Valid: {2}\"", x + 240, y, atendimentoEntity.Validade));

                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Pront: {2}\"", x + 510, y, atendimentoEntity.Prontuario));

                w32prn.PrintText(string.Format("P{0}", etiqueta.PrinterSettings.Copies)); //qtd de impressoes
                w32prn.EndDoc();
           }
           //else if (etiqueta.PrinterSettings.PrinterName.ToUpper().Contains("BIXOLON"))
           //{
            //   PrinterClassDll.Win32Print w32prn = new PrinterClassDll.Win32Print();
            //T26,49,1,0,0,0,0,N,N,‟Font - 8 pt‟
            //T26,81,2,0,0,0,0,N,N,‟Font - 10 pt‟
            //T26,117,3,0,0,0,0,N,N,‟Font - 12 pt‟
             //   w32prn.PrintText(string.Format("T{0},{1},3,0,0,0,0,N,N,\"{2}\"",x,y,atendimentoEntity.Atendimento));
             //   w32prn.PrintText(string.Format("B1{0},{1},0,2,6,100,0,0\"{2}\"",400,5,barCode));

            //int x = 5;
            //    int y = 20;
            //    short entreLinhas = 30;
           //      w32prn.SetPrinterName(etiqueta.PrinterSettings.PrinterName);
           //      w32prn.OpenCashdrawer(2);

                 
           //     w32prn.SetDeviceFont(15f, "JAN13(EAN)", false, false); //substituir por CODE 39
           //     w32prn.PrintText(barCode.ToString().PadLeft(12, '0')); //.PadLeft(12, '0')

           //      w32prn.SetDeviceFont(8f, "FontA1x1", false, false);
           //      w32prn.PrintText(atendimentoEntity.Atendimento);

           //      w32prn.PrintText("Unid.: " + atendimentoEntity.Unidade + " Local: " + atendimentoEntity.Local + "  Setor: " + atendimentoEntity.Setor);

           //      w32prn.PrintText("Data: " + atendimentoEntity.DataAtendimento + "   Hora: " + Convert.ToInt32(atendimentoEntity.HoraAtendimento).ToString("00:00") + "   Medico: " + atendimentoEntity.Medico);

           //      w32prn.PrintText("Conv.: " + atendimentoEntity.CodigoConvenio + " - " + atendimentoEntity.Convenio.PadRight(30).Substring(0, 28) + " Padrão: " + atendimentoEntity.Padrao);
           //      w32prn.PrintText("Plano: " + atendimentoEntity.CodigoPlano + " - " + atendimentoEntity.Plano.PadRight(30).Substring(0, 28) + "Tipo: " + atendimentoEntity.TipoPlano);

           //      w32prn.PrintText("Nome: " + atendimentoEntity.Paciente);

           //      w32prn.PrintText("Nasc.: " + atendimentoEntity.DataNascimento + "  Idade: " + atendimentoEntity.Idade + "  Sexo:" + atendimentoEntity.Sexo + "  Tipo Atend.: " + atendimentoEntity.TipoAtendimento);
           //      w32prn.PrintText("Matric.: " + atendimentoEntity.Credencial + "         Tel.: " + atendimentoEntity.Telefone);

           //      w32prn.PrintText("RG: " + atendimentoEntity.RG + atendimentoEntity.Origem == "1" ? "   Valid.: " + atendimentoEntity.Validade : "" + "   Pront.: " + atendimentoEntity.Prontuario);
               
           //      w32prn.EndDoc();
           //}
           else
           {
            // declaração das coordenadas para impressão
            short iMargemEsquerda = 14, iMargemTopo = 12, iTamLinha = 14, iNroLinha = 1;

            // declara os tipos de fontes, cores, etc. que serão utilizados na etiqueta
            Font fontCabecalho = new Font("Lucida Sans", 9);
            Font fontCabecalhoNegrito = new Font("Lucida Sans", 9, FontStyle.Bold);
            Font fontDetalhe = new Font("Lucida Sans", 7);
            Font fontDetalheNegrito = new Font("Lucida Sans", 7, FontStyle.Bold);
            Font fontDetalheDestaque = new Font("Lucida Sans", 8);
            Font fontDetalheDestaqueNegrito = new Font("Lucida Sans", 8, FontStyle.Bold);


            #region Formatação da Etiqueta para Impressão

            // rotina para impressão da etiqueta
            // "1a." linha (Cód. Barras)
            //            if (TipoImpressora == 1)
            //{
                // **** TÉRMICA ****
                // se for imprimir na térmica, imprime o código de barras e incrementa a altura
                // do começo da etiqueta (topo)
                iMargemTopo += 10;
                iTamLinha++;
               // Font fontCodBarras = new Font("CODE 39", 14); // não funciona, a leitora não consegue ler.
               //Font fontCodBarras = new Font("JAN13(EAN)", 15f);
                // evPP.Graphics.DrawString(barCode, fontCodBarras, Brushes.Black, iMargemEsquerda + 200, iMargemTopo - 2);
           // }

            // **** LINHAS COMUNS A AMBAS ****
            // 1a. linha (Nro. Atendimento)
            evPP.Graphics.DrawString(atendimentoEntity.Atendimento, fontCabecalhoNegrito, Brushes.Black, iMargemEsquerda, iMargemTopo - 2);

            // 2a. linha (Unidade, Local Atendimento, Setor)
            evPP.Graphics.DrawString("Unid.: " + atendimentoEntity.Unidade, fontDetalheNegrito, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha);
            evPP.Graphics.DrawString("Local: " + atendimentoEntity.Local, fontDetalheNegrito, Brushes.Black, iMargemEsquerda + 170, iMargemTopo + iTamLinha);
            // se for "LIBERACAO" (Origem = 1), pega a Unidade que liberou o exame; se for ATENDIMENTO (Origem = 0), pega o setor
            evPP.Graphics.DrawString("Setor: " + atendimentoEntity.Setor, fontDetalheNegrito, Brushes.Black, iMargemEsquerda + 270, iMargemTopo + iTamLinha);

            // 3a. linha (Data, Hora, Médico)
            iNroLinha++;
            evPP.Graphics.DrawString("Data: " + atendimentoEntity.DataAtendimento, fontDetalhe, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * iNroLinha);
            evPP.Graphics.DrawString("Hora: " + Convert.ToInt32(atendimentoEntity.HoraAtendimento).ToString("00:00"), fontDetalhe, Brushes.Black, iMargemEsquerda + 100, iMargemTopo + iTamLinha * iNroLinha);
            evPP.Graphics.DrawString("Médico: " + atendimentoEntity.Medico, fontDetalheNegrito, Brushes.Black, iMargemEsquerda + 170, iMargemTopo + iTamLinha * iNroLinha);

            // 4a. linha (Convênio, Padrão)
            iNroLinha++;            
            evPP.Graphics.DrawString("Conv.: " + atendimentoEntity.CodigoConvenio + " - " + atendimentoEntity.Convenio.PadRight(30).Substring(0, 28), fontDetalhe, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * iNroLinha);
            evPP.Graphics.DrawString("Padrão: " + atendimentoEntity.Padrao , fontDetalhe, Brushes.Black, iMargemEsquerda + 270, iMargemTopo + iTamLinha * iNroLinha);

            // 5a. linha (Plano, Tipo Plano)
            iNroLinha++;            
            evPP.Graphics.DrawString("Plano: " + atendimentoEntity.CodigoPlano + " - " + atendimentoEntity.Plano.PadRight(30).Substring(0, 28), fontDetalhe, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * iNroLinha);
            evPP.Graphics.DrawString("Tipo: " + atendimentoEntity.TipoPlano, fontDetalheNegrito, Brushes.Black, iMargemEsquerda + 270, iMargemTopo + iTamLinha * iNroLinha);
            
            // 6a. linha (Paciente)
            iNroLinha++;
            --iMargemTopo;           
            evPP.Graphics.DrawString("Nome: " + atendimentoEntity.Paciente, fontDetalheDestaqueNegrito, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * iNroLinha);
            
            // 7a. linha (Dt. Nasc., Idade, Sexo, Tipo Atend.)
            iNroLinha++;
            ++iMargemTopo;
            evPP.Graphics.DrawString("Nasc.: " + atendimentoEntity.DataNascimento, fontDetalheDestaqueNegrito, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * iNroLinha);
            evPP.Graphics.DrawString("Idade: " + atendimentoEntity.Idade, fontDetalhe, Brushes.Black, iMargemEsquerda + 120, iMargemTopo + iTamLinha * iNroLinha);
            
            evPP.Graphics.DrawString("Sexo:" + atendimentoEntity.Sexo, fontDetalhe, Brushes.Black, iMargemEsquerda + 180, iMargemTopo + iTamLinha * iNroLinha);
            evPP.Graphics.DrawString("Tipo Atend.: " + atendimentoEntity.TipoAtendimento, fontDetalhe, Brushes.Black, iMargemEsquerda + 270, iMargemTopo + iTamLinha * iNroLinha);
            // 8a. linha (Matrícula, Telefone)
            iNroLinha++;
            evPP.Graphics.DrawString("Matríc.: " + atendimentoEntity.Credencial, fontDetalheDestaqueNegrito, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * iNroLinha);
            evPP.Graphics.DrawString("Tel.: " + atendimentoEntity.Telefone, fontDetalhe, Brushes.Black, iMargemEsquerda + 270, iMargemTopo + iTamLinha * iNroLinha);
            // 9a. linha (Validade, RG, Prontuário)
            iNroLinha++;
            iMargemTopo++;
            // se for "ATENDIMENTO" (Origem = 0) não tem a informação da validade; apenas "LIBERAÇÃO" (Origem = 1) a tem
            if (atendimentoEntity.Origem == "1")
                evPP.Graphics.DrawString("Valid.: " + atendimentoEntity.Validade, fontCabecalhoNegrito, Brushes.Black, iMargemEsquerda + 130, iMargemTopo + iTamLinha * iNroLinha);

            evPP.Graphics.DrawString("RG: " + atendimentoEntity.RG, fontDetalhe, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * iNroLinha);
            evPP.Graphics.DrawString("Pront.: " + atendimentoEntity.Prontuario, fontCabecalhoNegrito, Brushes.Black, iMargemEsquerda + 270, iMargemTopo + iTamLinha * iNroLinha);

            #endregion

            evPP.HasMorePages = false;

            fontCabecalho.Dispose();
            fontCabecalhoNegrito.Dispose();
            fontDetalhe.Dispose();
            fontDetalheNegrito.Dispose();
            fontDetalheDestaque.Dispose();
            fontDetalheDestaqueNegrito.Dispose();

            }
        }

    }


}
