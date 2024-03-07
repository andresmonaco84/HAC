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
    public class EtiquetaClinica : Etiqueta
    {
        private PrintDocument etiqueta;
        private ClinicaEntity clinicaEntity;
        NameValueCollection appSettings = ConfigurationManager.AppSettings;

        public EtiquetaClinica(ClinicaEntity entity)
        {
            //entity.NomeImpressora = VerificaImpressaoCodigoDeBarras(entity.NomeImpressora, entity.PossuiCodigoDeBarras);
            etiqueta = ConfigurarEtiquetaPadrao(entity);
            clinicaEntity = entity;
        }
        protected override void Consultar()
        {
            clinicaEntity = new ClinicaData().Consultar(clinicaEntity);
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
                throw new Exception("Falha ao imprimir etiqueta de Clinica!\n" + ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.Message == "0")
                    throw new Exception("Clinica inexistente.");
                else if (ex.Message == "1")
                    throw new Exception("Clinica inativa.");
                else if (ex.Message == "2")
                    throw new Exception("Erro ao pesquisar informações da Clinica.");
                else
                    throw new Exception("Falha ao imprimir a etiqueta de Clinica!\n" + ex.Message);
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
                int y = 30;
                short entreLinhas = 35;

                w32prn.PrintText(string.Format("A{0},{1},0,4,1,1,N,\"{2}\"", x, y, clinicaEntity.Descricao));
                
                //2
                y += entreLinhas + 20;
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"{2}\"", x, y, clinicaEntity.TipoLogradouro + " " + clinicaEntity.Logradouro));
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"{2}\"", x + 520, y, clinicaEntity.NumeroEndereco));

                //3
                y += entreLinhas;
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"{2}\"", x, y, clinicaEntity.Bairro));

                //4
                y += entreLinhas;
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"{2}\"", x, y, clinicaEntity.CEP));
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"{2}\"", x + 300, y,clinicaEntity.Complemento));

                //5
                y += entreLinhas;
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"{2}\"", x, y, clinicaEntity.Cidade));
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"{2}\"", x + 500, y, clinicaEntity.UF));

                //6
                y += entreLinhas;
                w32prn.PrintText(string.Format("A{0},{1},0,3,1,1,N,\"{2}\"", x, y, clinicaEntity.Telefone));

                w32prn.PrintText(string.Format("P{0}", etiqueta.PrinterSettings.Copies)); //qtd de impressoes
                w32prn.EndDoc();
            }
            //else if (etiqueta.PrinterSettings.PrinterName.ToUpper().Contains("BIXOLON"))
            //{
            //    PrinterClassDll.Win32Print w32prn = new PrinterClassDll.Win32Print();
            //    w32prn.SetPrinterName(etiqueta.PrinterSettings.PrinterName);
            //    w32prn.OpenCashdrawer(2);


            //    w32prn.SetDeviceFont(15f, "JAN13(EAN)", false, false); //substituir por CODE 39
              

            //    w32prn.SetDeviceFont(8f, "FontA1x1", false, false);
            //    //w32prn.PrintText(atendimentoEntity.Atendimento);

            //    //w32prn.PrintText("Unid.: " + atendimentoEntity.Unidade + " Local: " + atendimentoEntity.Local + "  Setor: " + atendimentoEntity.Setor);

            //    //w32prn.PrintText("Data: " + atendimentoEntity.DataAtendimento + "   Hora: " + Convert.ToInt32(atendimentoEntity.HoraAtendimento).ToString("00:00") + "   Medico: " + atendimentoEntity.Medico);

            //    //w32prn.PrintText("Conv.: " + atendimentoEntity.CodigoConvenio + " - " + atendimentoEntity.Convenio.PadRight(30).Substring(0, 28) + " Padrão: " + atendimentoEntity.Padrao);
            //    //w32prn.PrintText("Plano: " + atendimentoEntity.CodigoPlano + " - " + atendimentoEntity.Plano.PadRight(30).Substring(0, 28) + "Tipo: " + atendimentoEntity.TipoPlano);

            //    //w32prn.PrintText("Nome: " + atendimentoEntity.Paciente);

            //    //w32prn.PrintText("Nasc.: " + atendimentoEntity.DataNascimento + "  Idade: " + atendimentoEntity.Idade + "  Sexo:" + atendimentoEntity.Sexo + "  Tipo Atend.: " + atendimentoEntity.TipoAtendimento);
            //    //w32prn.PrintText("Matric.: " + atendimentoEntity.Credencial + "         Tel.: " + atendimentoEntity.Telefone);

            //    //w32prn.PrintText("RG: " + atendimentoEntity.RG + atendimentoEntity.Origem == "1" ? "   Valid.: " + atendimentoEntity.Validade : "" + "   Pront.: " + atendimentoEntity.Prontuario);

            //    w32prn.EndDoc();
            //}
            else
            {

                // declaração das coordenadas para impressão
                short iMargemEsquerda = 28, iMargemTopo = 22, iTamLinha = 18, iTamLinhaNegrito = 20;

                // declara os tipos de fontes, cores, etc. que serão utilizados na etiqueta
                Font fontCabecalho = new Font("Lucida Sans", 10);
                Font fontCabecalhoNegrito = new Font("Lucida Sans", 10, FontStyle.Bold);
                Font fontDetalhe = new Font("Lucida Sans", 8);
                Font fontDetalheNegrito = new Font("Lucida Sans", 8, FontStyle.Bold);

                #region Formatação da Etiqueta para Impressão

                // 1a. linha (Clínica)
                evPP.Graphics.DrawString(clinicaEntity.Descricao, fontDetalheNegrito, Brushes.Black, iMargemEsquerda, iMargemTopo); //clinicaEntity.CodigoClinica + " - " +
                // 2a. linha (Logradouro, Número)
                evPP.Graphics.DrawString(clinicaEntity.TipoLogradouro + " " + clinicaEntity.Logradouro, fontDetalhe, Brushes.Black, iMargemEsquerda, iMargemTopo + 1 + iTamLinha * 1);
                evPP.Graphics.DrawString(clinicaEntity.NumeroEndereco, fontDetalhe, Brushes.Black, iMargemEsquerda + 250, iMargemTopo + 1 + iTamLinha * 1);
                // 3a. linha (Bairro)
                evPP.Graphics.DrawString(clinicaEntity.Bairro, fontDetalhe, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * 2);
                // 4a. linha (CEP, Complemento)
                evPP.Graphics.DrawString(clinicaEntity.CEP, fontDetalhe, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * 3);
                evPP.Graphics.DrawString(clinicaEntity.Complemento, fontDetalhe, Brushes.Black, iMargemEsquerda + 250, iMargemTopo + iTamLinha * 3);
                // 5a. linha (Município, UF)
                evPP.Graphics.DrawString(clinicaEntity.Cidade, fontDetalhe, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * 4);
                evPP.Graphics.DrawString(clinicaEntity.UF, fontDetalhe, Brushes.Black, iMargemEsquerda + 250, iMargemTopo + iTamLinha * 4);
                // 6a. linha (Telefone)
                evPP.Graphics.DrawString(clinicaEntity.Telefone, fontDetalhe, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * 5);
                #endregion

                evPP.HasMorePages = false;



                fontCabecalho.Dispose();
                fontCabecalhoNegrito.Dispose();
                fontDetalhe.Dispose();
                fontDetalheNegrito.Dispose();

            }
        }
        }

    }

