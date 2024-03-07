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
    public class EtiquetaProtocoloSADT : Etiqueta
    {
        private PrintDocument etiqueta;
        private ProtocoloSADTEntity protocoloSADTEntity;
        NameValueCollection appSettings = ConfigurationManager.AppSettings;

        public EtiquetaProtocoloSADT(ProtocoloSADTEntity entity)
        {
            //entity.NomeImpressora = VerificaImpressaoCodigoDeBarras(entity.NomeImpressora, entity.PossuiCodigoDeBarras);
            etiqueta = ConfigurarEtiquetaPadrao(entity);
            protocoloSADTEntity = entity;
        }
        
        protected override void Consultar()
        {
            protocoloSADTEntity = new ProtocoloSADTData().Consultar(protocoloSADTEntity);
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
                throw new Exception("Falha ao imprimir etiqueta de Protocolo SADT!\n" + ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.Message == "0")
                    throw new Exception("Falha ao abrir etiqueta de Protocolo SADT.");
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
                short iMargemEsquerda = 14, iMargemTopo = 12, iTamLinha = 14, iNroLinha = 1;

                // declara os tipos de fontes, cores, etc. que serão utilizados na etiqueta
                Font fontDestaqueNegrito;
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
                    fontDestaqueNegrito = new Font("Lucida Sans", 10, FontStyle.Bold);
                    fontDetalheDestaqueNegrito = new Font("Lucida Sans", 9, FontStyle.Bold);
                    fontDetalheNegrito = new Font("Lucida Sans", 8, FontStyle.Bold);
                    fontDetalhe = new Font("Lucida Sans", 8);
                //}
                //else // matricial
                //{
                //    fontDestaqueNegrito = new Font("Lucida Sans", 9, FontStyle.Bold);
                //    fontDetalheDestaqueNegrito = new Font("Lucida Sans", 8, FontStyle.Bold);
                //    fontDetalheNegrito = new Font("Lucida Sans", 7, FontStyle.Bold);
                //    fontDetalhe = new Font("Lucida Sans", 7);
                //}

                string strSetorQuartoLeito = string.Empty;
                if (protocoloSADTEntity.TipoIntLib.Equals("I"))
                    strSetorQuartoLeito = string.Format("{0} - {1}/{2}", protocoloSADTEntity.Setor, protocoloSADTEntity.Quarto, protocoloSADTEntity.Leito);
                
                // informação do quarto/leito (para "internados") ou SAM (para pacientes de alta ou não internados)
                strSetorQuartoLeito = strSetorQuartoLeito.Trim().Equals("- /") ||
                                      string.IsNullOrEmpty(strSetorQuartoLeito) ? "SAM" : strSetorQuartoLeito;

                // 1a. linha (Nro. Atendimento, Data (de entrega) e Quarto/Leito)
                evPP.Graphics.DrawString(protocoloSADTEntity.Atendimento, fontDestaqueNegrito, Brushes.Black, iMargemEsquerda, iMargemTopo);
                evPP.Graphics.DrawString(protocoloSADTEntity.DataAtendimento, fontDetalheNegrito, Brushes.Black, iMargemEsquerda + 150, iMargemTopo);
                evPP.Graphics.DrawString(protocoloSADTEntity.SetorQuartoLeito, fontDetalheNegrito, Brushes.Black, iMargemEsquerda + 260, iMargemTopo);
                evPP.Graphics.DrawString(string.Concat(protocoloSADTEntity.Lote), fontDetalhe, Brushes.Black, iMargemEsquerda + 340, iMargemTopo);

                // 2a. linha (Convênio, Plano, Nome do Paciente)
                evPP.Graphics.DrawString(string.Format("{0} / {1}", protocoloSADTEntity.CodigoConvenio, protocoloSADTEntity.CodigoPlano), fontDetalheNegrito, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha);
                evPP.Graphics.DrawString(protocoloSADTEntity.Paciente, fontDetalheDestaqueNegrito, Brushes.Black, iMargemEsquerda + 110, iMargemTopo + iTamLinha);
                
                // 3a. linha (Unidade, Local Atendimento, Setor)
                iNroLinha++;
                evPP.Graphics.DrawString(protocoloSADTEntity.Unidade, fontDetalheNegrito, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * iNroLinha);
                evPP.Graphics.DrawString(protocoloSADTEntity.Local, fontDetalheNegrito, Brushes.Black, iMargemEsquerda + 150, iMargemTopo + iTamLinha * iNroLinha);
                evPP.Graphics.DrawString(protocoloSADTEntity.Setor, fontDetalheNegrito, Brushes.Black, iMargemEsquerda + 260, iMargemTopo + iTamLinha * iNroLinha);

                // 4a. linha (Endereço de entrega)
                iNroLinha++;
                evPP.Graphics.DrawString(protocoloSADTEntity.UnidadeEntrega, fontDetalhe, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * iNroLinha);

                // 5a. linha (Código do exame (todos os códigos desta liberação))
                // da 5a. a 10a. linhas, a etiqueta imprimirá o CÓD. AMB DO EXAME 
                // para popular as linhas com os códigos dos exames, a lógica faz
                // o programa "quebrar" a string que contem tais valores
                string[] strCodExameTemp;
                char cToken = ';';
                strCodExameTemp = protocoloSADTEntity.CodigoExame.Split(cToken);

                string[] strCodExameMnemoTemp;
                char cTokenHifen = '-';
//                strCodExameMnemoTemp = strCodExameTemp[
                

                iNroLinha++;
                evPP.Graphics.DrawString("EXAMES: ", fontDetalhe, Brushes.Black, iMargemEsquerda, iMargemTopo + iTamLinha * iNroLinha);
                for (short iCont = 0; iCont < strCodExameTemp.Length; iCont++)
                {
                    evPP.Graphics.DrawString(strCodExameTemp[iCont] + " - ", fontDetalheDestaqueNegrito, Brushes.Black, iMargemEsquerda + 50, iMargemTopo + iTamLinha * (iNroLinha));
                    if (((iCont) % 2) == 0)
                    {
                        iMargemEsquerda += 130;
                    }
                    else
                    {
                        iNroLinha++;
                        iMargemEsquerda -= 130;
                    }
                }

                #endregion

                evPP.HasMorePages = false;

                fontDetalheDestaqueNegrito.Dispose();
                fontDetalheNegrito.Dispose();
                fontDetalhe.Dispose();
        }

    }


}
