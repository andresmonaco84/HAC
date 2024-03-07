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
    public class EtiquetaPaciente : Etiqueta
    {
        public event EventHandler onMsg;
        public string mensagem = string.Empty;

        private void enviaMensagem(string txt)
        {
            this.mensagem = txt;
            if (onMsg != null) onMsg(null, null);
        }

        private PrintDocument etiqueta;
        private PacienteEntity pacienteEntity;
        NameValueCollection appSettings = ConfigurationManager.AppSettings;

        public EtiquetaPaciente(PacienteEntity entity)
        {
            //entity.NomeImpressora = VerificaImpressaoCodigoDeBarras(entity.NomeImpressora, entity.PossuiCodigoDeBarras);

            etiqueta = ConfigurarEtiquetaPadrao(entity);
            pacienteEntity = entity;
        }
        protected override void Consultar()
        {
            pacienteEntity = new PacienteData().Consultar(pacienteEntity);
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
                throw new Exception("Falha ao imprimir etiqueta de Paciente!\n" + ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.Message == "0")
                    throw new Exception("Paciente inexistente.");
                else
                    throw new Exception("Falha ao imprimir a etiqueta de Paciente!\n" + ex.Message);
            }
            GC.Collect();
        }

        protected override void MontarLayout(object sender, PrintPageEventArgs evPP)
        {
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
                int y = 40;
                short entreLinhas = 36;

                //1
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Conv: {2}\"", x, y, pacienteEntity.CodigoConvenio + " - " + pacienteEntity.Convenio.PadRight(30).Substring(0, 21)));
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Pront: {2}\"", x + 510, y, pacienteEntity.Prontuario));
                
                //2
                y += entreLinhas ;
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Plano: {2}\"", x, y, pacienteEntity.CodigoPlano + " - " + pacienteEntity.Plano.PadRight(30).Substring(0, 21)));
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Tipo: {2}\"", x + 520, y, pacienteEntity.TipoPlano));
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Padrão: {2}\"", x + 520, y, pacienteEntity.Padrao));

                //3
                y += entreLinhas;
                w32prn.PrintText(string.Format("A{0},{1},0,4,1,1,N,\"Nome: {2}\"", x, y, pacienteEntity.Paciente.PadRight(50).Substring(0, 45)));
                
                //4
                y += entreLinhas;
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Nasc: {2}\"", x, y, pacienteEntity.DataNascimento));
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Idade:{2}\"", x + 275, y, pacienteEntity.Idade));
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Sexo:{2}\"", x + 520, y, pacienteEntity.Sexo));

                //5
                y += entreLinhas;
                w32prn.PrintText(string.Format("A{0},{1},0,4,1,1,N,\"Matric: {2}\"", x, y, pacienteEntity.Credencial));
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"Tel: {2}\"", x + 450, y, pacienteEntity.Telefone));

                //6
                y += entreLinhas;
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"RG: {2}\"", x, y, pacienteEntity.RG));

                //7
                y += entreLinhas;
                if (pacienteEntity.StatusLiberacao == "P")
                    w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"LIBER: AÇÃO PENDENTE  {2}\"", x, y, pacienteEntity.Atendimento ));
                else
                    w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"LIBER: AÇÃO NÃO AUTORIZADA   {2}\"", x, y, pacienteEntity.Atendimento));



                w32prn.PrintText(string.Format("P{0}", etiqueta.PrinterSettings.Copies)); //qtd de impressoes
                w32prn.EndDoc();
           }
            //else if (etiqueta.PrinterSettings.PrinterName.ToUpper().Contains("BIXOLON"))
            //{
            //    //
            //}
            else
            {
                // declaração das coordenadas para impressão
                short iMargemEsquerda = 20, iMargemTopo = 11, iTamLinha = 15; //, iTamLinhaNegrito = 17;
                short iTamConvenioPlano = 40;

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
                //    iTamConvenioPlano += 3;
                //    fontDetalheDestaqueNegrito = new Font("Lucida Sans", 8, FontStyle.Bold);
                //    fontDetalheNegrito = new Font("Lucida Sans", 7, FontStyle.Bold);
                //    fontDetalhe = new Font("Lucida Sans", 7);
                //}

                // 1a. linha (Convênio, Pront)            
                evPP.Graphics.DrawString("Conv: " + pacienteEntity.CodigoConvenio + " - " + pacienteEntity.Convenio.PadRight(50).Substring(0, 23), fontDetalhe, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha);
                evPP.Graphics.DrawString("Pront: " + pacienteEntity.Prontuario, fontDetalheDestaqueNegrito, Brushes.Black, iMargemEsquerda + 250, iMargemTopo + iTamLinha - 1);

                // 2a. linha (Plano, Tipo Plano, Padrão)
                evPP.Graphics.DrawString("Plano: " + pacienteEntity.CodigoPlano + " - " + pacienteEntity.Plano.Replace("434343", "+").PadRight(50).Substring(0, 18), fontDetalhe, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * 2);
                evPP.Graphics.DrawString("Tipo: " + pacienteEntity.TipoPlano, fontDetalheNegrito, Brushes.Black, iMargemEsquerda + 210, iMargemTopo + iTamLinha * 2);
                evPP.Graphics.DrawString("Padrao: " + pacienteEntity.Padrao, fontDetalhe, Brushes.Black, iMargemEsquerda + 270, iMargemTopo + iTamLinha * 2);

                // 3a. linha (Paciente)
                iMargemTopo++;
                evPP.Graphics.DrawString("Paciente: " + pacienteEntity.Paciente.PadRight(55).Substring(0, 40), fontDetalheDestaqueNegrito, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * 3);

                // 4a. linha (Dt. Nasc., Idade, Sexo)
                evPP.Graphics.DrawString("Nasc: " + pacienteEntity.DataNascimento, fontDetalhe, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * 4);
                evPP.Graphics.DrawString("Idade: " + pacienteEntity.Idade, fontDetalhe, Brushes.Black, iMargemEsquerda + 150, iMargemTopo + iTamLinha * 4);
                evPP.Graphics.DrawString("Sexo: " + pacienteEntity.Sexo, fontDetalhe, Brushes.Black, iMargemEsquerda + 250, iMargemTopo + iTamLinha * 4);

                // 5a. linha (Matrícula, Telefone)
                evPP.Graphics.DrawString("Matric: " + pacienteEntity.Credencial, fontDetalheNegrito, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * 5);
                evPP.Graphics.DrawString("Tel: " + pacienteEntity.Telefone, fontDetalhe, Brushes.Black, iMargemEsquerda + 250, iMargemTopo + iTamLinha * 5);

                // 6a. linha (RG, Prontuário)
                evPP.Graphics.DrawString("RG: " + pacienteEntity.RG, fontDetalhe, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * 6);

                // 7a. linha (Nro. Liberação)
                // apenas "PACIENTE" (Origem = 2) pode ter o número da liberação pendente (concatena "LIBER" + "AÇÃO PENDENTE" ou "LIBER" + "AÇÃO NÃO-AUTORIZADA")
                //if (pacienteEntity.Origem == "2")
                //{
                if (pacienteEntity.StatusLiberacao == "P")
                    evPP.Graphics.DrawString("LIBER: AÇÃO PENDENTE " + pacienteEntity.Atendimento, fontDetalheDestaqueNegrito, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * 7);
                else if (pacienteEntity.StatusLiberacao == "N")
                    evPP.Graphics.DrawString("LIBER: AÇÃO NÃO AUTORIZADA " + pacienteEntity.Atendimento, fontDetalheDestaqueNegrito, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * 7);
                //}

                #endregion

                evPP.HasMorePages = false;

                fontDetalheDestaqueNegrito.Dispose();
                fontDetalheNegrito.Dispose();
                fontDetalhe.Dispose();
            }
            }
        }

    }



