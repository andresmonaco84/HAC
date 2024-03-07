using System;
using System.Collections.Generic;
using System.Text;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using Microsoft.Win32;
using CDSSoftware;
using System.IO.Ports;
using PrinterClassDll;
using System.Configuration;

//Documentação da linguagem utilizada para a Zebra
//https://pt.scribd.com/doc/160488495/Zebra-Zpl-Manual-Portugues

namespace HospitalAnaCosta.SGS.GestaoMateriais.Impressao
{
    public class ImpZebra
    {
        #region OBJETOS SERVIÇOS

        private bool _mav = false; //Med. Alta Vigilancia
        private string _endereco = string.Empty;
        private int _grupo = 0;

        // HistoricoNotaFiscal  
        private HistoricoNotaFiscalDTO dtoHistNFImprimir;
        private IHistoricoNotaFiscal _histNF;
        private IHistoricoNotaFiscal HistoricoNotaFiscal
        {
            get { return _histNF != null ? _histNF : _histNF = (IHistoricoNotaFiscal)Global.Common.GetObject(typeof(IHistoricoNotaFiscal)); }
        }        

        // CodigoBarra        
        private CodigoBarraDTO dtoCodBarra;
        private ICodigoBarra _codigoBarra;
        private ICodigoBarra CodigoBarra
        {
            get { return _codigoBarra != null ? _codigoBarra : _codigoBarra = (ICodigoBarra)Global.Common.GetObject( typeof(ICodigoBarra)); }
        }
        
        #endregion                

        public static string PortaImpressoraZebraNomeRegistroHAC()
        {
            return "PortaImpressoraZebraHAC";
        }

        public static string PortaImpressoraZebraNomeRegistroACS()
        {
            return "PortaImpressoraZebraACS";
        }

        public static string ImpressoraZebraUSBNomeRegistroHAC()
        {
            return "NomeImpressoraZebraUSB_HAC";
        }

        public static string ImpressoraZebraUSBNomeRegistroACS()
        {
            return "NomeImpressoraZebraUSB_ACS";
        }

        public string ImprimirEtiquetaCodBarra(HistoricoNotaFiscalDTO dtoHistNF, 
                                               string codLoteAvulso, 
                                               string dataValidadeAvulso, 
                                               bool mav,
                                               string endereco,
                                               int grupo)
        {
            if (dtoHistNF.IdtProduto.Value.IsNull)
                return "Obrigado informar produto";

            _mav = mav;
            _endereco = endereco;
            _grupo = grupo;

            string nomeImpUSB = string.Empty;
            string porta = (dtoHistNF.IdtFilial.Value == (decimal)FilialMatMedDTO.Filial.HAC) ? 
                                                         Utilitario.ObterRegistroWindows(PortaImpressoraZebraNomeRegistroHAC()) :
                                                         Utilitario.ObterRegistroWindows(PortaImpressoraZebraNomeRegistroACS());            
            if (string.IsNullOrEmpty(porta))
                return "Porta da impressora Zebra precisa ser configurada";

            if (dtoHistNF.IdtFilial.Value.IsNull)
                return "Obrigado informar se é estoque HAC ou ACS";
            else
            {
                if (porta == Utilitario.PortaComunicacao.USB && dtoHistNF.IdtFilial.Value == (decimal)FilialMatMedDTO.Filial.HAC)
                {
                    nomeImpUSB = Utilitario.ObterRegistroWindows(ImpressoraZebraUSBNomeRegistroHAC());
                    if (string.IsNullOrEmpty(nomeImpUSB))
                        return "Nome da Impressora USB HAC precisa ser configurado";
                }
                else if (porta == Utilitario.PortaComunicacao.USB && dtoHistNF.IdtFilial.Value == (decimal)FilialMatMedDTO.Filial.ACS)
                {
                    nomeImpUSB = Utilitario.ObterRegistroWindows(ImpressoraZebraUSBNomeRegistroACS());
                    if (string.IsNullOrEmpty(nomeImpUSB))
                        return "Nome da Impressora USB do Plano ACS precisa ser configurado";
                }
            }

            int qtdImprimir = (int)dtoHistNF.Qtde.Value;
            int resto = (qtdImprimir % 3);
            int col1 = 35; //Valor da coordenada da coluna referente a 1° etiqueta
            int col2 = 305; //Valor da coordenada da coluna referente a 2° etiqueta
            int col3 = 575; //Valor da coordenada da coluna referente a 3° etiqueta

            //Divide por 3 porque são 3 etiquetas por impressão
            qtdImprimir = qtdImprimir / 3;
            
            //Sempre arredonda para cima
            if (resto > 0) qtdImprimir += 1;

            //52 é o limite máximo de caracteres da descrição do produto
            dtoHistNF.DsProduto.Value = Utilitario.TruncarCampo(dtoHistNF.DsProduto.Value.ToString(), 52);

            dtoCodBarra = new CodigoBarraDTO();

            dtoCodBarra.IdtProduto.Value = dtoHistNF.IdtProduto.Value;
            dtoCodBarra.IdtFilial.Value = dtoHistNF.IdtFilial.Value;

            if (dtoHistNF.IdtLote.Value.IsNull)
            {
                if (_grupo == 1 && !string.IsNullOrEmpty(codLoteAvulso)) //Buscar cod. barra do lote do medicamento se estiver com entrada correta
                {
                    HistoricoNotaFiscalDTO dtoNF = new HistoricoNotaFiscalDTO();

                    dtoNF.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
                    dtoNF.IdtProduto.Value = dtoHistNF.IdtProduto.Value;
                    dtoNF.CodLote.Value = codLoteAvulso;

                    HistoricoNotaFiscalDataTable dtbHistNF = HistoricoNotaFiscal.Sel(dtoNF);

                    if (dtbHistNF.Rows.Count > 0)
                    {
                        dtoHistNF.NumLote.Value = dtbHistNF.TypedRow(0).NumLote.Value;
                        dtoCodBarra.IdtLote.Value = dtbHistNF.TypedRow(0).IdtLote.Value;
                        dtoCodBarra = CodigoBarra.Sel(dtoCodBarra, (decimal)FrmPrincipal.dtoSeguranca.Idt.Value).TypedRow(0);
                    }                    
                }
                if (dtoCodBarra.CdBarra.Value.IsNull)
                    dtoCodBarra = CodigoBarra.SelAvulso(dtoCodBarra, (decimal)FrmPrincipal.dtoSeguranca.Idt.Value);
            }
            else
            {
                dtoCodBarra.IdtLote.Value = dtoHistNF.IdtLote.Value;
                dtoCodBarra = CodigoBarra.Sel(dtoCodBarra, (decimal)FrmPrincipal.dtoSeguranca.Idt.Value).TypedRow(0);
            }

            //Retira o dígito do Cod. Barra que vem do banco
            dtoCodBarra.CdBarra.Value = dtoCodBarra.CdBarra.Value.ToString().Substring(0, dtoCodBarra.CdBarra.Value.ToString().Length - 1);

            dtoHistNFImprimir = dtoHistNF;

            if (dtoHistNF.IdtLote.Value.IsNull && dtoHistNFImprimir.CodLote.Value.IsNull && codLoteAvulso != null)
            {
                dtoHistNF.NumLote.Value = "*" + dtoHistNF.NumLote.Value;
                dtoHistNFImprimir.CodLote.Value = codLoteAvulso;
                dtoHistNFImprimir.DataValidadeProduto.Value = dataValidadeAvulso;
            }

            if (ConfigurationManager.AppSettings["HAC.REMOTING.SGS.ACS.GESTAOMATERIAIS.PATH"] == "svchac01.anacosta.com.br")
            {
                if (porta == Utilitario.PortaComunicacao.Paralela1 || porta == Utilitario.PortaComunicacao.Paralela2)
                    this.ExecutarImpressaoPortaParalela(qtdImprimir, col1, col2, col3, porta, (int)dtoHistNF.Qtde.Value);
                else if (porta == Utilitario.PortaComunicacao.Serial1 || porta == Utilitario.PortaComunicacao.Serial2)
                    this.ExecutarImpressaoPortaSerial(qtdImprimir, col1, col2, col3, porta, (int)dtoHistNF.Qtde.Value);
                else if (porta == Utilitario.PortaComunicacao.USB)
                    this.ExecutarImpressaoPortaUSB(qtdImprimir, col1, col2, col3, nomeImpUSB);
            }
            
            return string.Empty;
        }

        private void ExecutarImpressaoPortaUSB(int qtdLinhasImprimir, int col1, int col2, int col3, string nomeImpressora)
        {
            Win32PrintClass imp = new Win32PrintClass();

            imp.SetPrinterName(nomeImpressora);

            //Inicia comandos de impressão
            imp.PrintText("${^XA");

            //Comando que executa a quantidade a ser impressa
            imp.PrintText(ComandoQtdImprimir(qtdLinhasImprimir));

            //1° coluna do papel das etiquetas
            if (dtoHistNFImprimir.DsProduto.Value.ToString().Length <= 26)
                imp.PrintText(ComandoLinhaDescricaoProduto(col1)); //Desenha a linha da Descrição do Produto
            else
            {
                imp.PrintText(ComandoLinha1DescricaoProduto(col1)); //Desenha a linha da Descrição do Produto
                imp.PrintText(ComandoLinha2DescricaoProduto(col1)); //Desenha a linha da Descrição do Produto
            }
            imp.PrintText(ComandoLinhaCodBarra(col1)); //Desenha a linha referente ao Cód. Barra 
            imp.PrintText(ComandoLinhaEnderecoCRF(col1)); //Desenha a linha referente ao CRF
            if (!dtoHistNFImprimir.CodLote.Value.IsNull && !dtoHistNFImprimir.DataValidadeProduto.Value.IsNull)
                imp.PrintText(ComandoLinhaValidadeLote(col1)); //Desenha a linha da Data de Validade e N° Lote   
            else if (_mav)
                imp.PrintText(ComandoLinhaMAV(col1));

            //2° coluna do papel das etiquetas     
            if (dtoHistNFImprimir.DsProduto.Value.ToString().Length <= 26)
                imp.PrintText(ComandoLinhaDescricaoProduto(col2)); //Desenha a linha da Descrição do Produto
            else
            {
                imp.PrintText(ComandoLinha1DescricaoProduto(col2)); //Desenha a linha da Descrição do Produto
                imp.PrintText(ComandoLinha2DescricaoProduto(col2)); //Desenha a linha da Descrição do Produto
            }            
            imp.PrintText(ComandoLinhaCodBarra(col2)); //Desenha a linha referente ao Cód. Barra 
            imp.PrintText(ComandoLinhaEnderecoCRF(col2)); //Desenha a linha referente ao CRF
            if (!dtoHistNFImprimir.CodLote.Value.IsNull && !dtoHistNFImprimir.DataValidadeProduto.Value.IsNull)
                imp.PrintText(ComandoLinhaValidadeLote(col2)); //Desenha a linha da Data de Validade e N° Lote            
            else if (_mav)
                imp.PrintText(ComandoLinhaMAV(col2));

            //3° coluna do papel das etiquetas                
            if (dtoHistNFImprimir.DsProduto.Value.ToString().Length <= 26)
                imp.PrintText(ComandoLinhaDescricaoProduto(col3)); //Desenha a linha da Descrição do Produto
            else
            {
                imp.PrintText(ComandoLinha1DescricaoProduto(col3)); //Desenha a linha da Descrição do Produto
                imp.PrintText(ComandoLinha2DescricaoProduto(col3)); //Desenha a linha da Descrição do Produto
            }   
            imp.PrintText(ComandoLinhaCodBarra(col3)); //Desenha a linha referente ao Cód. Barra 
            imp.PrintText(ComandoLinhaEnderecoCRF(col3)); //Desenha a linha referente ao CRF
            if (!dtoHistNFImprimir.CodLote.Value.IsNull && !dtoHistNFImprimir.DataValidadeProduto.Value.IsNull)
                imp.PrintText(ComandoLinhaValidadeLote(col3)); //Desenha a linha da Data de Validade e N° Lote            
            else if (_mav)
                imp.PrintText(ComandoLinhaMAV(col3));

            //Finaliza comandos de impressão
            imp.PrintText("^XZ}$");

            imp.EndDoc();
        }

        private void ExecutarImpressaoPortaParalela(int qtdLinhasImprimir, int col1, int col2, int col3, string porta, int qtdEtiquetasImprimir)
        {
            ImprimeTexto imp = new ImprimeTexto();

            imp.Inicio(porta);

            int qtdEtiquetasImpressas = 0;
            for (int iContLinha = 1; iContLinha <= qtdLinhasImprimir; iContLinha++)
            {
                //Inicia comandos de impressão
                imp.Imp("^XA");

                //Comando que executa a quantidade a ser impressa
                imp.Imp(ComandoQtdImprimir(1));

                //1° coluna do papel das etiquetas
                if (qtdEtiquetasImpressas < qtdEtiquetasImprimir)
                {
                    imp.Imp(ComandoLinhaDescricaoProduto(col1)); //Desenha a linha da Descrição do Produto
                    imp.Imp(ComandoLinhaCodBarra(col1)); //Desenha a linha referente ao Cód. Barra 
                    imp.Imp(ComandoLinhaEnderecoCRF(col1)); //Desenha a linha referente ao CRF
                    if (!dtoHistNFImprimir.CodLote.Value.IsNull && !dtoHistNFImprimir.DataValidadeProduto.Value.IsNull)
                        imp.Imp(ComandoLinhaValidadeLote(col1)); //Desenha a linha da Data de Validade e N° Lote
                    else if (_mav)
                        imp.Imp(ComandoLinhaMAV(col1));

                    qtdEtiquetasImpressas += 1;
                }

                //2° coluna do papel das etiquetas
                if (qtdEtiquetasImpressas < qtdEtiquetasImprimir)
                {
                    imp.Imp(ComandoLinhaDescricaoProduto(col2)); //Desenha a linha da Descrição do Produto
                    imp.Imp(ComandoLinhaCodBarra(col2)); //Desenha a linha referente ao Cód. Barra 
                    imp.Imp(ComandoLinhaEnderecoCRF(col2)); //Desenha a linha referente ao CRF
                    if (!dtoHistNFImprimir.CodLote.Value.IsNull && !dtoHistNFImprimir.DataValidadeProduto.Value.IsNull)
                        imp.Imp(ComandoLinhaValidadeLote(col2)); //Desenha a linha da Data de Validade e N° Lote
                    else if (_mav)
                        imp.Imp(ComandoLinhaMAV(col2));

                    qtdEtiquetasImpressas += 1;
                }

                //3° coluna do papel das etiquetas
                if (qtdEtiquetasImpressas < qtdEtiquetasImprimir)
                {
                    imp.Imp(ComandoLinhaDescricaoProduto(col3)); //Desenha a linha da Descrição do Produto
                    imp.Imp(ComandoLinhaCodBarra(col3)); //Desenha a linha referente ao Cód. Barra 
                    imp.Imp(ComandoLinhaEnderecoCRF(col3)); //Desenha a linha referente ao CRF
                    if (!dtoHistNFImprimir.CodLote.Value.IsNull && !dtoHistNFImprimir.DataValidadeProduto.Value.IsNull)
                        imp.Imp(ComandoLinhaValidadeLote(col3)); //Desenha a linha da Data de Validade e N° Lote
                    else if (_mav)
                        imp.Imp(ComandoLinhaMAV(col3));

                    qtdEtiquetasImpressas += 1;
                }

                //Finaliza comandos de impressão
                imp.Imp("^XZ");                
            }

            imp.Fim();
        }

        private void ExecutarImpressaoPortaSerial(int qtdLinhasImprimir, int col1, int col2, int col3, string porta, int qtdEtiquetasImprimir)
        {
            SerialPort sp = new SerialPort(porta);

            //ABRE PORTA SERIAL
            //Verificar configuracoes da impressora
            sp.BaudRate = 9600;
            sp.DataBits = 8;
            sp.Parity = Parity.None;
            sp.StopBits = StopBits.One;
            sp.Open();

            int qtdEtiquetasImpressas = 0;
            for (int iContLinha = 1; iContLinha <= qtdLinhasImprimir; iContLinha++)
            {
                //Inicia comandos de impressão
                sp.Write("^XA");

                //Comando que executa a quantidade a ser impressa
                sp.Write(ComandoQtdImprimir(1));

                //1° coluna do papel das etiquetas
                if (qtdEtiquetasImpressas < qtdEtiquetasImprimir)
                {
                    sp.Write(ComandoLinhaDescricaoProduto(col1)); //Desenha a linha da Descrição do Produto
                    sp.Write(ComandoLinhaCodBarra(col1)); //Desenha a linha referente ao Cód. Barra 
                    sp.Write(ComandoLinhaEnderecoCRF(col1)); //Desenha a linha referente ao CRF
                    if (!dtoHistNFImprimir.CodLote.Value.IsNull && !dtoHistNFImprimir.DataValidadeProduto.Value.IsNull)
                        sp.Write(ComandoLinhaValidadeLote(col1)); //Desenha a linha da Data de Validade e N° Lote
                    else if (_mav)
                        sp.Write(ComandoLinhaMAV(col1));

                    qtdEtiquetasImpressas += 1;
                }

                //2° coluna do papel das etiquetas
                if (qtdEtiquetasImpressas < qtdEtiquetasImprimir)
                {
                    sp.Write(ComandoLinhaDescricaoProduto(col2)); //Desenha a linha da Descrição do Produto
                    sp.Write(ComandoLinhaCodBarra(col2)); //Desenha a linha referente ao Cód. Barra 
                    sp.Write(ComandoLinhaEnderecoCRF(col2)); //Desenha a linha referente ao CRF
                    if (!dtoHistNFImprimir.CodLote.Value.IsNull && !dtoHistNFImprimir.DataValidadeProduto.Value.IsNull)
                        sp.Write(ComandoLinhaValidadeLote(col2)); //Desenha a linha da Data de Validade e N° Lote
                    else if (_mav)
                        sp.Write(ComandoLinhaMAV(col2));

                    qtdEtiquetasImpressas += 1;
                }

                //3° coluna do papel das etiquetas
                if (qtdEtiquetasImpressas < qtdEtiquetasImprimir)
                {
                    sp.Write(ComandoLinhaDescricaoProduto(col3)); //Desenha a linha da Descrição do Produto
                    sp.Write(ComandoLinhaCodBarra(col3)); //Desenha a linha referente ao Cód. Barra 
                    sp.Write(ComandoLinhaEnderecoCRF(col3)); //Desenha a linha referente ao CRF
                    if (!dtoHistNFImprimir.CodLote.Value.IsNull && !dtoHistNFImprimir.DataValidadeProduto.Value.IsNull)
                        sp.Write(ComandoLinhaValidadeLote(col3)); //Desenha a linha da Data de Validade e N° Lote
                    else if (_mav)
                        sp.Write(ComandoLinhaMAV(col3));

                    qtdEtiquetasImpressas += 1;
                }

                //Finaliza comandos de impressão
                sp.Write("^XZ");
            }

            //FECHA PORTA SERIAL
            sp.Close();
        }

        /// <summary>
        /// Retorna a string de comando da impressora que desenha a linha da Descrição do Produto
        /// </summary>        
        private string ComandoLinhaDescricaoProduto(int col)
        {
            return string.Format("^FO{0},45^AP^FD{1}^FS", col, dtoHistNFImprimir.DsProduto);
        }

        /// <summary>
        /// Retorna a string de comando da impressora que desenha a linha da Descrição do Produto
        /// </summary>        
        private string ComandoLinha1DescricaoProduto(int col)
        {
            return string.Format("^FO{0},31^AP^FD{1}^FS", col, Utilitario.TruncarCampo(dtoHistNFImprimir.DsProduto.Value.ToString(), 26));
        }

        /// <summary>
        /// Retorna a string de comando da impressora que desenha a linha da Descrição do Produto
        /// </summary>        
        private string ComandoLinha2DescricaoProduto(int col)
        {
            return string.Format("^FO{0},46^AP^FD{1}^FS", col, dtoHistNFImprimir.DsProduto.Value.ToString().Substring(26,
                                                               dtoHistNFImprimir.DsProduto.Value.ToString().Length >= 52 ? 26 : dtoHistNFImprimir.DsProduto.Value.ToString().Length - 26));
        }

        /// <summary>
        /// Retorna a string de comando da impressora que desenha a linha do CRF
        /// </summary>        
        private string ComandoLinhaEnderecoCRF(int col)
        {
            if (_grupo == 1 || _grupo == 6) //Só add. CRF pra MEDICAMENTOS E MATERIAL HOSP.
            {
                string strCRF = "RT: CRF-SP 36564";
                if (string.IsNullOrEmpty(_endereco))
                    return string.Format("^FO{0},150^AP^FD                {1}^FS", col, strCRF);
                else
                    return string.Format("^FO{0},150^AP^FD{1}             {2}^FS", col, _endereco, strCRF);
            }
            else
            {
                if (!string.IsNullOrEmpty(_endereco))
                    return string.Format("^FO{0},150^AP^FD{1}^FS", col, _endereco);                
            }
            return string.Empty;
        }

        /// <summary>
        /// Retorna a string de comando da impressora que desenha a linha do Cód. Barra
        /// </summary>        
        private string ComandoLinhaCodBarra(int col)
        {
            return string.Format("^FO{0},65^BY2^BEN,60,Y,N^FD{1}^FS", col + 10, dtoCodBarra.CdBarra.Value);
        }

        /// <summary>
        /// Retorna a string de comando da impressora que desenha a linha da Validade e N° lote
        /// </summary>        
        private string ComandoLinhaValidadeLote(int col)
        {
            if (_mav)
                return string.Format("^FO{0},170^AP^FDMAR   VAL{1}      L{2}^FS", col,
                                                                                  DateTime.Parse(dtoHistNFImprimir.DataValidadeProduto.Value).ToString("dd/MM/yy"),
                                                                                  dtoHistNFImprimir.NumLote.Value.ToString());
            else
                return string.Format("^FO{0},170^AP^FDVAL {1}         L {2}^FS", col,
                                                                                 DateTime.Parse(dtoHistNFImprimir.DataValidadeProduto.Value).ToString("dd/MM/yyyy"),
                                                                                 dtoHistNFImprimir.NumLote.Value.ToString());
        }

        /// <summary>
        /// Se não há Validade/Lote, insere uma linha apenas indicando quando for Medicamento de Alta Vigilancia
        /// </summary>
        /// <returns></returns>
        private string ComandoLinhaMAV(int col)
        {
            return string.Format("^FO{0},170^AP^FDMAR^FS", col);
        }

        /// <summary>
        /// Retorna a string de comando da impressora que executa a qtd. a imprimir
        /// </summary>        
        private string ComandoQtdImprimir(int qtdImprimir)
        {
            return string.Format("^PQ{0},0,1,Y", qtdImprimir);
        }
    }
}