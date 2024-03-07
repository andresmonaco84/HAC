using HospitalAnaCosta.SGS.Impressao.dto;
using HospitalAnaCosta.SGS.tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace HospitalAnaCosta.SGS.Impressao
{
    public class ImpressaoProntuarioEletronico
    {

        List<string> linhasCorpo;
        int linhaImpressaAtual = 0;
        float linhasPorPagina;
        float PosicaoY = 0;
        int count = 0;
        float MargemEsquerda;
        float MargemDireita;
        float MargemTopo;
        string Linha;
        int coluna =0;
        float linha =0;
        float alturaLinha;
        int ultimaLinhaPagina;

        int colunaInicial;
        int linhaCorpoInicial;
        int ultimaLinhaCorpo;
        Pen pp = new Pen(Brushes.Black);
        int gLinhaIni = 8;
        int gLinhaFim = 8;
        int gColIni = 0;
        int gColFim = 0;
        int nPagina = 1;



        public enum TipoImpressaoProntuario
        {
            AtestadoDeclaracaoDto = 0,
            RelatorioInss =1
        }

        private Font fontTitulo;
        private Font fontTexto;
        private Font fontTextoBold;
        private Font fontTextoMsg;
        private Font fontRodape;
        private string arquivo = "Atestado-Declaracao";
        AtestadoDeclaracaoDto dtoAtestadoDeclaracao;
        private string impressora;
        public TipoImpressaoProntuario tipoImpressao;
       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sIdtAtendimento"></param>
        /// <param name="ignoraImpressoraPadrao">TRUE = Busca na tabela do setor a impressora que deve ser impresso o atestado, ignorando a impressora padrão definida na máquina</param>
        /// <returns></returns>
        public string imprimir(string sIdtAtendimento, string sIdtUsuario, string usarEstaImpressora)
        // public string imprimir(string sIdtAtendimento, string sIdtUsuario)
        {
            try{

                if (buscaDados(sIdtAtendimento))
                {
                    fontTitulo = new Font("Arial", 12);
                    fontTexto = new Font("Times New Roman", 10);
                    fontTextoBold = new Font("Times New Roman", 10, FontStyle.Bold);
                    fontTextoMsg = new Font("Times New Roman", 14);
                    fontRodape = new Font("Times New Roman", 6);
                    PrintDocument doc = new PrintDocument();
                    try
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(usarEstaImpressora))
                            {
                                impressora = usarEstaImpressora;
                            }
                            else if (impressora == null)
                            {
                                buscaImpressora(dtoAtestadoDeclaracao.setorIdt);
                            }
                        }
                        catch
                        {
                            impressora = null;
                        }
                        // impressora = @"\\nethac01\fg-ti-samsung-ml4550-01";
                        doc.PrinterSettings.PrinterName = impressora;
                    }
                    catch
                    {

                    }
                    doc.DocumentName = arquivo;
                    doc.PrintPage += doc_PrintPage;
                    dtoAtestadoDeclaracao.setIdtUsuario(sIdtUsuario);
                    if (this.tipoImpressao == TipoImpressaoProntuario.AtestadoDeclaracaoDto)
                    {
                        geraLog();
                    }                    
                    doc.Print();
                    doc.Dispose();
                    return null;
                }
                else
                {
                return "Atendimento não encontrado";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }



        private void cabecalho(PrintPageEventArgs e)
        {            
            WebClient client = new WebClient();
            string urlImage = "http://iishac01/sgs/imagens/img_login_sgs.JPG";
            MemoryStream stream = new MemoryStream(client.DownloadData(urlImage));
            e.Graphics.DrawImage(Image.FromStream(stream), 30, 15, 180, 55);

            #region MONTA BORDA
            gLinhaIni = 8;
            gLinhaFim = 8;
            gColIni = (int)MargemEsquerda;
            gColFim = (int)MargemDireita;
            e.Graphics.DrawLine(pp, gColIni, gLinhaIni, gColFim, gLinhaFim); // horizontal alto
            gLinhaIni = gLinhaFim = 75;
            e.Graphics.DrawLine(pp, gColIni, gLinhaIni, gColFim, gLinhaFim); // horizontal MEIO
            gLinhaIni = 8;
            // gLinhaFim = 575;
            gLinhaFim = ultimaLinhaPagina;
            gColIni = gColFim = (int)MargemEsquerda;
            e.Graphics.DrawLine(pp, gColIni, gLinhaIni, gColFim, gLinhaFim); // vertical esquerdo
            gLinhaIni = 8;
            gLinhaFim = ultimaLinhaPagina;
            gColIni = gColFim = (int)MargemDireita;
            e.Graphics.DrawLine(pp, gColIni, gLinhaIni, gColFim, gLinhaFim); // vertical direito
            gLinhaIni = gLinhaFim = ultimaLinhaPagina;
            gColIni = (int)MargemEsquerda;
            gColFim = (int)MargemDireita;
            e.Graphics.DrawLine(pp, gColIni, gLinhaIni, gColFim, gLinhaFim); // horizontal PÉ
            // PROTOCOLO
            e.Graphics.DrawString(dtoAtestadoDeclaracao.protocolo, fontRodape, Brushes.Black, gColIni + 4, gLinhaFim - 10, StringFormat.GenericTypographic);
            #endregion MONTA BORDA
            linha = 40;
            if (this.tipoImpressao == TipoImpressaoProntuario.AtestadoDeclaracaoDto)
            {
                if (dtoAtestadoDeclaracao.tipo.Equals("A"))
                {
                    coluna = 330;
                    e.Graphics.DrawString("ATESTADO MÉDICO", fontTitulo, Brushes.Black, coluna, linha, new StringFormat());
                }
                else
                {
                    coluna = 280;
                    e.Graphics.DrawString("DECLARAÇÃO DE COMPARECIMENTO", fontTitulo, Brushes.Black, coluna, linha, new StringFormat());
                }
            }
            else if (this.tipoImpressao == TipoImpressaoProntuario.RelatorioInss)
            {
                coluna = 280;
                e.Graphics.DrawString("RELATÓRIO MÉDICO AO INSS", fontTitulo, Brushes.Black, coluna, linha, new StringFormat());
            }

            // coluna = 600;
            //coluna = (int)(MargemDireita - (e.Graphics.MeasureString(dtoAtestadoDeclaracao.dataImpressao.ToString(), fontTexto).Width));
            //linha = 40;
            //e.Graphics.DrawString(dtoAtestadoDeclaracao.dataImpressao.ToString(), fontTexto, Brushes.Black, coluna, linha, new StringFormat());
            string data = string.Format("{0} {1}",dtoAtestadoDeclaracao.dataAtendimento.ToStrF("dd/mm/yyyy"), Utilitario.formataHora(dtoAtestadoDeclaracao.horaAtendimento));
            string dataAtendimento = string.Format(" Data Atendimento: {0}", data);
            coluna = (int)(MargemDireita - (e.Graphics.MeasureString(dataAtendimento, fontTexto).Width));
            linha = 40;
            e.Graphics.DrawString(dataAtendimento, fontTexto, Brushes.Black, coluna, linha, new StringFormat());


        }

        private void buscaImpressora(decimal? pIdtSetor)
        {
            DataTable result = new DataTable();
            ClassBase cBase = new ClassBase();
            string sQuery = string.Empty;
            sQuery = string.Format("SELECT CAD_SET_IMPRESSORA_PADRAO FROM TB_CAD_SET_SETOR WHERE CAD_SET_ID = {0}", pIdtSetor);
            result = cBase.remoto.executeQuery(sQuery);
            if (result.Rows.Count > 0)
            {
                try
                {
                    impressora = result.Rows[0]["CAD_SET_IMPRESSORA_PADRAO"].ToString();
                    if (impressora == "") impressora = null;
                }
                catch
                {
                    impressora = null;
                }
            }
            else
            {
                impressora = null;
            }
            
        }
        private bool buscaDados(string pIdtAtendimento)
        {
            ClassBase cBase = new ClassBase();
            string sQuery = string.Empty;
            DataTable result;
            if (this.tipoImpressao == TipoImpressaoProntuario.AtestadoDeclaracaoDto)
            {
                sQuery += string.Format(" SELECT PES.CAD_PES_NM_PESSOA,   PAC.CAD_PAC_NR_PRONTUARIO, TO_NUMBER(PRO.CAD_PRO_NR_CONSELHO) CAD_PRO_NR_CONSELHO,  ");
                sQuery += string.Format("        R.QTDDIAS,               R.INI_AFASTA,              R.FIM_AFASTA,                                           ");
                sQuery += string.Format("        PRO.CAD_PRO_NM_NOME,     A.CID,                     UNI.CAD_UNI_DS_UNIDADE, ");
                sQuery += string.Format("        SETO.CAD_SET_DS_SETOR,   R.TP_ATESTADO,             R.CONSULTA_ACOM, ");
                sQuery += string.Format("        R.INI_PERIODO,           R.FIM_PERIODO,             R.ACOMPANHANTE,   ");
                sQuery += string.Format("        R.CONSULTA_TRAT,         R.CONSULTA_MED,            SETO.CAD_SET_ID, ");
                sQuery += string.Format("        ATE.ATD_ATE_ID,           SYSDATE DATA_IMPRESSAO,   R.DT_ATESTADO,     ATE.ATD_ATE_DT_ATENDIMENTO, ATE.ATD_ATE_HR_ATENDIMENTO ");
                sQuery += string.Format(" FROM TB_ATD_ATE_ATENDIMENTO ATE,  ");
                sQuery += string.Format("              TB_ASS_PAT_PACIEATEND PAT,  ");
                sQuery += string.Format("              TB_CAD_PAC_PACIENTE PAC,  ");
                sQuery += string.Format("              TB_CAD_PES_PESSOA PES, ");
                sQuery += string.Format("              TB_CAD_PRO_PROFISSIONAL PRO,  ");
                sQuery += string.Format("              ATENDIMENTO A,  ");
                sQuery += string.Format("              PEP.ATESTADO_NOVO R,  ");
                sQuery += string.Format("              TB_CAD_UNI_UNIDADE UNI,  ");
                sQuery += string.Format("              TB_CAD_SET_SETOR SETO ");
                sQuery += string.Format(" WHERE ATE.ATD_ATE_ID        = {0} ", pIdtAtendimento);
                // sQuery += string.Format(" AND ATE.CAD_PRO_ID_PROF_EXEC = PRO.CAD_PRO_ID_PROFISSIONAL(+) ");
                sQuery += string.Format(" AND PRO.CAD_PRO_NR_CONSELHO = TO_CHAR(R.CODMED) ");
                sQuery += string.Format(" AND ATE.ATD_ATE_ID          = A.CODATEAMB ");
                sQuery += string.Format(" AND ATE.ATD_ATE_ID          = PAT.ATD_ATE_ID ");
                sQuery += string.Format(" AND PAT.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE ");
                sQuery += string.Format(" AND PAC.CAD_PES_ID_PESSOA   = PES.CAD_PES_ID_PESSOA ");
                sQuery += string.Format(" AND ATE.ATD_ATE_ID          = R.CODATEAMB ");
                sQuery += string.Format(" AND ATE.CAD_UNI_ID_UNIDADE  = UNI.CAD_UNI_ID_UNIDADE ");
                sQuery += string.Format(" AND ATE.CAD_SET_ID          = SETO.CAD_SET_ID ");
                sQuery += string.Format(" ORDER BY R.DT_ATESTADO ");
            }
            else
            {
                sQuery += string.Format(" SELECT PES.CAD_PES_NM_PESSOA,   PAC.CAD_PAC_NR_PRONTUARIO, TO_NUMBER(PRO.CAD_PRO_NR_CONSELHO) CAD_PRO_NR_CONSELHO,  ");
                sQuery += string.Format("        PRO.CAD_PRO_NM_NOME,     A.CID,                     UNI.CAD_UNI_DS_UNIDADE, ");
                sQuery += string.Format("        SETO.CAD_SET_DS_SETOR,   ");
                sQuery += string.Format("        SETO.CAD_SET_ID, ");
                sQuery += string.Format("        ATE.ATD_ATE_ID,           SYSDATE DATA_IMPRESSAO,   ATE.ATD_ATE_DT_ATENDIMENTO, ATE.ATD_ATE_HR_ATENDIMENTO ");
                sQuery += string.Format(" FROM TB_ATD_ATE_ATENDIMENTO ATE,  ");
                sQuery += string.Format("              TB_ASS_PAT_PACIEATEND PAT,  ");
                sQuery += string.Format("              TB_CAD_PAC_PACIENTE PAC,  ");
                sQuery += string.Format("              TB_CAD_PES_PESSOA PES, ");
                sQuery += string.Format("              TB_CAD_PRO_PROFISSIONAL PRO,  ");
                sQuery += string.Format("              ATENDIMENTO A,  ");
                sQuery += string.Format("              TB_CAD_UNI_UNIDADE UNI,  ");
                sQuery += string.Format("              TB_CAD_SET_SETOR SETO ");
                sQuery += string.Format(" WHERE ATE.ATD_ATE_ID        = {0} ", pIdtAtendimento);
                // sQuery += string.Format(" AND ATE.CAD_PRO_ID_PROF_EXEC = PRO.CAD_PRO_ID_PROFISSIONAL(+) ");
                sQuery += string.Format(" AND PRO.CAD_PRO_NR_CONSELHO = TO_CHAR(A.CODMED) ");
                sQuery += string.Format(" AND ATE.ATD_ATE_ID          = A.CODATEAMB ");
                sQuery += string.Format(" AND ATE.ATD_ATE_ID          = PAT.ATD_ATE_ID ");
                sQuery += string.Format(" AND PAT.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE ");
                sQuery += string.Format(" AND PAC.CAD_PES_ID_PESSOA   = PES.CAD_PES_ID_PESSOA ");
                sQuery += string.Format(" AND ATE.CAD_UNI_ID_UNIDADE  = UNI.CAD_UNI_ID_UNIDADE ");
                sQuery += string.Format(" AND ATE.CAD_SET_ID          = SETO.CAD_SET_ID ");
            }

            result = cBase.remoto.executeQuery(sQuery);
            if (result.Rows.Count > 0)
            {
                // retorna a última linha inserida na tabela
                dtoAtestadoDeclaracao = new AtestadoDeclaracaoDto();
                dtoAtestadoDeclaracao.converteDataRowParaAtestadoDeclaracaoDto(result.Rows[result.Rows.Count - 1]);
                if (this.tipoImpressao == TipoImpressaoProntuario.RelatorioInss)
                {
                    sQuery = string.Format("SELECT DS_RELATORIO FROM REL_MEDICO REL WHERE REL.CODATEAMB = {0} ", pIdtAtendimento);
                    result = cBase.remoto.executeQuery(sQuery);
                    if (result.Rows.Count > 0)
                    {
                        dtoAtestadoDeclaracao.setRelatorio(result.Rows[0]["DS_RELATORIO"].ToString());
                    }
                }
                return true;

            }
            else
            {
                return false;
            }
        }

        private List<string> geraCorpoMultiplasLinhas(string txt, Font f, PrintPageEventArgs e)
        {
            List<string> montaLinhas = new List<string>();
            int tamanhoMaximoLinha = 70;
            int tamanhoDoTexto = txt.Length;
            int colunaAtual = 0;
            int larguraDaLinha = 0;
            // busca tamanho maximo de caracteres que cabe em uma linha de acordo com a font usada
            while (true)
            {
                string _linha = txt.Substring(colunaAtual, tamanhoMaximoLinha);
                larguraDaLinha = (int)e.Graphics.MeasureString(_linha, f).Width;
                if (larguraDaLinha < MargemDireita) break;
                else tamanhoMaximoLinha -= 5;

            }
            int i = 0;
            int qtdCaracteres = tamanhoMaximoLinha;
            while (true)
        	{
                try
                {
                    if (i >= tamanhoDoTexto) break;
                    string _linha = string.Empty;
                    try
                    {
                        _linha = txt.Substring(i, qtdCaracteres);
                    }
                    catch
                    {
                        _linha = txt.Substring(i);
                    }
                    int posi = _linha.IndexOf("\r\n");
                    if (posi != -1)
                    {
                        posi += "\r\n".Length;
                        _linha = txt.Substring(i, posi);
                        qtdCaracteres = posi;
                        montaLinhas.Add(_linha);
                        i += qtdCaracteres;
                        qtdCaracteres = tamanhoMaximoLinha;
                        continue;
                    }
                    string ultimoCaracter = string.Empty;
                    try
                    {
                        ultimoCaracter = _linha.Substring(qtdCaracteres - 1, 1);
                    }
                    catch
                    {
                        qtdCaracteres = _linha.Length;
                        if ((i + qtdCaracteres) >= tamanhoDoTexto)
                        {
                            montaLinhas.Add(_linha);
                            i += qtdCaracteres;
                            qtdCaracteres = tamanhoMaximoLinha;
                            continue;
                        }
                        else
                        {
                            ultimoCaracter = _linha.Substring(qtdCaracteres - 1, 1);
                        }

                    }
                    if (ultimoCaracter != "." && ultimoCaracter != "," && ultimoCaracter != " ")
                    {
                        qtdCaracteres--;
                    }
                    else
                    {
                        // tamanhoAtual++; // pega proximo caracter 
                        montaLinhas.Add(_linha);
                        i += qtdCaracteres;
                        qtdCaracteres = tamanhoMaximoLinha;
                    }
                }
                catch (Exception exlinha)
                {
                    throw;
                }

	        }
            return montaLinhas;
        }

        private void geraLog()
        {
            ClassBase cBase = new ClassBase();
            string sQuery = string.Empty;
            DataTable result;
            #region GERA SEQUENCE
            sQuery += string.Format("SELECT SEQ_ATESTADO_LOG.NEXTVAL ID_ATESTADO FROM DUAL");
            result = cBase.remoto.executeQuery(sQuery);
            dtoAtestadoDeclaracao.setIdtAtestado(Convert.ToDecimal(result.Rows[0]["ID_ATESTADO"].ToString()));
            string data = string.Empty;
            #endregion
            data = string.Format(" TO_DATE('{0}','DDMMYYYYHH24MI')", Convert.ToDateTime(dtoAtestadoDeclaracao.dataImpressao.ToString()).ToString("ddMMyyyyhhmm"));
            dtoAtestadoDeclaracao.setIdtUsuario(dtoAtestadoDeclaracao.idtUsuario == null ? 0 : dtoAtestadoDeclaracao.idtUsuario);
            sQuery = string.Empty;
            sQuery = "INSERT INTO TB_ATD_ATESTADO_LOG (";
            sQuery += "ID_ATESTADO, ";
            sQuery += "ATD_ATE_ID,";
            sQuery += "SEG_USU_ID_USUARIO,";
            sQuery += "DATA_IMPRESSAO";
            sQuery += ")VALUES(";
            sQuery += string.Format("{0},", dtoAtestadoDeclaracao.idtAtestado);
            sQuery += string.Format("{0},", dtoAtestadoDeclaracao.idtAtendimento);
            sQuery += string.Format("{0},", dtoAtestadoDeclaracao.idtUsuario);
            sQuery += string.Format("{0}",data);
            sQuery += string.Format(")");
            cBase.remoto.executeQuery(sQuery);
            dtoAtestadoDeclaracao.setProtocolo(string.Format("{0}{1}{2}{3}", dtoAtestadoDeclaracao.idtAtestado.ToString().PadLeft(8,'0'),
                                                                            dtoAtestadoDeclaracao.idtAtendimento.ToString().PadLeft(8, '0'),
                                                                            dtoAtestadoDeclaracao.idtUsuario.ToString().PadLeft(8,'0'),
                                                                            Convert.ToDateTime(dtoAtestadoDeclaracao.dataImpressao.ToString()).ToString("ddMMyyyyhhmm")));
        }


        private void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            // float linhasPorPagina;
            //float PosicaoY = 0;
            // int count = 0;
            MargemEsquerda = e.PageSettings.Margins.Left = 10;
            MargemDireita = e.PageSettings.PrintableArea.Width - MargemEsquerda;
            MargemTopo = e.PageSettings.HardMarginY;
            Linha = null;
            coluna = 0;
            linha = 0;
            alturaLinha = fontTexto.Height;
            ultimaLinhaPagina = (int)(e.PageBounds.Height - (alturaLinha * 4)); // preserva 4 linhas no final da folha
            ultimaLinhaCorpo = (int)(ultimaLinhaPagina - (alturaLinha * 9));

            colunaInicial = (int)(MargemEsquerda + 5); // 5 char de distancia da margem inicial
            linhaCorpoInicial = (int)(e.MarginBounds.Height / 4);


            #region CABEÇALHO
            cabecalho(e);
            #endregion CABEÇALHO

#region CORPO
            if (this.tipoImpressao == TipoImpressaoProntuario.AtestadoDeclaracaoDto)
            {
                #region ATESTADO DECLARAÇÃO
                string labelNome = "NOME :";
                string labelCid = "CID. ";
                string labelRG = "RG: ";
                string labelInicioAfastamento = "Inicio do afastamento: ";
                string labelPeriodo = "Período: das {0} às {1} horas.";
                string labelFimAfastamento = "Fim do afastamento:";
                string textoAtestadoCorpo = "Atesto que a pessoa acima qualificada necessita de {0} dia(s) de afastamento do trabalho, por motivo de doença.";
                string textoDeclaracaoCorpo = "Declaro que a pessoa acima qualificada compareceu ao nosso serviço ";


                string identificacaoMedico = string.Format("CRM: {0}   {1}", dtoAtestadoDeclaracao.crm, dtoAtestadoDeclaracao.nomeMedico);
                #region IDENTIFICAÇÃO
                coluna = colunaInicial;
                linha = linhaCorpoInicial;
                e.Graphics.DrawString(string.Format("{0}", labelNome), fontTextoBold, Brushes.Black, coluna, linha, new StringFormat());
                coluna += (int)e.Graphics.MeasureString(labelNome, fontTextoBold).Width;
                e.Graphics.DrawString(string.Format("{0}", dtoAtestadoDeclaracao.nomePessoa), fontTexto, Brushes.Black, coluna, linha, new StringFormat());
                coluna = colunaInicial;
                linha += alturaLinha;
                e.Graphics.DrawString(string.Format("{0}", labelRG), fontTextoBold, Brushes.Black, coluna, linha, new StringFormat());
                coluna += (int)e.Graphics.MeasureString(labelNome, fontTextoBold).Width;
                e.Graphics.DrawString(string.Format("{0}", dtoAtestadoDeclaracao.rg), fontTexto, Brushes.Black, coluna, linha, new StringFormat());
                #endregion IDENTIFICAÇÃO


                coluna = colunaInicial;
                linha += (alturaLinha * 5);
                Rectangle rect2 = new Rectangle(coluna + 5, (int)linha, (int)MargemDireita - coluna - 5, (int)(alturaLinha * 4)); // mudar altura do retangulo para algo não hard code
                if (dtoAtestadoDeclaracao.tipo == "A")
                {
                    #region TEXTO ATESTADO
                    e.Graphics.DrawString(string.Format(textoAtestadoCorpo, dtoAtestadoDeclaracao.diasDeAfastamento), fontTextoMsg, Brushes.Black, rect2, StringFormat.GenericTypographic);
                    // e.Graphics.DrawRectangle(Pens.Red, rect2);
                    coluna = colunaInicial;
                    linha = rect2.Bottom + alturaLinha;
                    e.Graphics.DrawString(labelInicioAfastamento, fontTextoBold, Brushes.Black, coluna, linha, new StringFormat());
                    coluna += (int)e.Graphics.MeasureString(labelInicioAfastamento, fontTextoBold).Width;
                    e.Graphics.DrawString(string.Format("{0}", dtoAtestadoDeclaracao.dataInicioAfastamento.ToString().Replace("00:00:00", "")), fontTexto, Brushes.Black, coluna, linha, new StringFormat());
                    linha += alturaLinha;
                    coluna = colunaInicial;
                    e.Graphics.DrawString(string.Format("{0}", labelFimAfastamento), fontTextoBold, Brushes.Black, coluna, linha, new StringFormat());
                    coluna += (int)e.Graphics.MeasureString(labelInicioAfastamento, fontTextoBold).Width;
                    e.Graphics.DrawString(string.Format("{0}", dtoAtestadoDeclaracao.dataFimAfastamento.ToString().Replace("00:00:00", "")), fontTexto, Brushes.Black, coluna, linha, new StringFormat());
                    #endregion TEXTO ATESTADO
                }
                else if (dtoAtestadoDeclaracao.tipo == "D")
                {

                    #region DECLARAÇÃO
                    if (dtoAtestadoDeclaracao.declaracaoDeConsulta.Equals("Y"))
                        textoDeclaracaoCorpo += "para consulta médica. ";
                    else if (dtoAtestadoDeclaracao.declaracaoDeTratamento.Equals("Y"))
                        textoDeclaracaoCorpo += "para o tratamento. ";
                    // else if (dtoAtestadoDeclaracao.declaracaoDeAcompanhante.Equals("X"))
                    // textoDeclaracaoCorpo += "como acompanhante ";

                    // textoDeclaracaoCorpo += string.Format("de seu(sua) {0}", dtoAtestadoDeclaracao.acompanhante);
                    e.Graphics.DrawString(textoDeclaracaoCorpo, fontTextoMsg, Brushes.Black, rect2, StringFormat.GenericTypographic);
                    coluna = colunaInicial;
                    linha = rect2.Bottom + alturaLinha;
                    e.Graphics.DrawString(string.Format(labelPeriodo, dtoAtestadoDeclaracao.inicioPeriodoDeclaracao, dtoAtestadoDeclaracao.fimPeriodoDeclaracao), fontTextoMsg, Brushes.Black, coluna, linha, new StringFormat());

                    #endregion DECLARAÇÃO
                }
                else
                {
                    Console.Write("Não foi definido o tipo de documento a ser impresso (Atestado/Declaração)");
                }
                coluna = colunaInicial;
                linha += (alturaLinha * 2);
                e.Graphics.DrawString(string.Format("{0}", labelCid), fontTextoBold, Brushes.Black, coluna, linha, new StringFormat());
                coluna += (int)e.Graphics.MeasureString(labelNome, fontTextoBold).Width;
                e.Graphics.DrawString(dtoAtestadoDeclaracao.cid, fontTexto, Brushes.Black, coluna, linha, new StringFormat());
                coluna = (int)(MargemDireita - (e.Graphics.MeasureString(identificacaoMedico, fontTexto).Width));
                e.Graphics.DrawString(identificacaoMedico, fontTexto, Brushes.Black, coluna, linha, new StringFormat());
                #endregion ATESTADO DECLARAÇÃO
            }
            else if (this.tipoImpressao == TipoImpressaoProntuario.RelatorioInss)
            {
                string identificacaoMedico = string.Format("CRM: {0}   {1}", dtoAtestadoDeclaracao.crm, dtoAtestadoDeclaracao.nomeMedico);
                if (nPagina == 1)
                {
                    string textoLinha1 = "Ao";
                    string textoLinha2 = "INSS - Instituto nacional de seguro social";
                    string textoLinha3 = "A/C Perícia Médica";
                    string labelNome = "O Sr(a). ";
                    string textoCorpo = "";
                    string frase = "está em acompanhamento nesta Unidade com quadro de ";
                    

                    #region IDENTIFICAÇÃO
                    coluna = colunaInicial;
                    linha = linhaCorpoInicial;
                    e.Graphics.DrawString(string.Format("{0}", textoLinha1), fontTextoBold, Brushes.Black, coluna, linha, new StringFormat());
                    coluna = colunaInicial;
                    linha += alturaLinha;
                    e.Graphics.DrawString(string.Format("{0}", textoLinha2), fontTextoBold, Brushes.Black, coluna, linha, new StringFormat());
                    coluna = colunaInicial;
                    linha += alturaLinha * 2;
                    e.Graphics.DrawString(string.Format("{0}", textoLinha3), fontTextoBold, Brushes.Black, coluna, linha, new StringFormat());


                    coluna = colunaInicial;
                    linha += alturaLinha * 2;
                    e.Graphics.DrawString(string.Format("{0}", labelNome), fontTextoBold, Brushes.Black, coluna, linha, new StringFormat());
                    coluna += (int)e.Graphics.MeasureString(labelNome, fontTextoBold).Width;
                    e.Graphics.DrawString(string.Format("{0}", dtoAtestadoDeclaracao.nomePessoa), fontTexto, Brushes.Black, coluna, linha, new StringFormat());
                    coluna = colunaInicial;
                    linha += alturaLinha;
                    e.Graphics.DrawString(string.Format("{0}", frase), fontTextoBold, Brushes.Black, coluna, linha, new StringFormat());
                    coluna += (int)e.Graphics.MeasureString(frase, fontTextoBold).Width;
                    e.Graphics.DrawString(string.Format("{0}", dtoAtestadoDeclaracao.cid), fontTexto, Brushes.Black, coluna, linha, new StringFormat());
                    coluna = colunaInicial;
                    linha += alturaLinha * 2;
                    e.Graphics.DrawString(string.Format("{0}", "Em tratamento : "), fontTexto, Brushes.Black, coluna, linha, new StringFormat());
                    coluna = colunaInicial;
                    linha += alturaLinha * 2;

                }
                else
                {
                    coluna = colunaInicial;
                    linha += alturaLinha * 8;

                }

                linhasCorpo = geraCorpoMultiplasLinhas(dtoAtestadoDeclaracao.relatorio, fontTextoMsg, e);
                for (int y = linhaImpressaAtual; y < linhasCorpo.Count; y++)
                {
                    e.Graphics.DrawString(linhasCorpo[y], fontTextoMsg, Brushes.Black, coluna, linha, new StringFormat());
                    linha += alturaLinha;
                    if (linha >= ultimaLinhaCorpo)
                    {
                        rodape(e);
                        e.HasMorePages = true;
                        linhaImpressaAtual = y + 1;
                        nPagina++;
                        return;                                                
                    }
                }
                coluna = (int)(MargemDireita - (e.Graphics.MeasureString(identificacaoMedico, fontTexto).Width));
                linha = (ultimaLinhaCorpo-(alturaLinha*2));
                e.Graphics.DrawString(identificacaoMedico, fontTexto, Brushes.Black, coluna, linha, new StringFormat());
                coluna = 100;
                linha = ultimaLinhaCorpo;
                e.Graphics.DrawString("A concessão, bem como a manutenção do afastamento do trabalho é critério exclusivo da perícia médica.", fontTexto, Brushes.Black, coluna, linha, new StringFormat());
                #endregion IDENTIFICAÇÃO

            }


#endregion CORPO
            #region RODAPE
            rodape(e);
            #endregion RODAPE


            e.HasMorePages = false;
        }

        private PrintPageEventArgs quebraPágina(PrintPageEventArgs e)
        {
            PrintPageEventArgs a;
            Font sFont = new Font("Arial", 10);
            Brush sBrush = Brushes.White;
            string test = char.ConvertFromUtf32(12);
            e.Graphics.DrawString(test, sFont, sBrush, 0, 0, new StringFormat());
            e.HasMorePages = true;
            a = new PrintPageEventArgs(e.Graphics, e.MarginBounds, e.PageBounds, e.PageSettings);
            // e.PageSettings.PrinterSettings.ToPage = 2;
            return a;
        }


        private void rodape(PrintPageEventArgs e)
        {
            string labelLocal = "Local: ";
            string labelSetor = "Setor: ";
            string DataEmissao = "Data emissão: ";
            string assinatura = "Assinatura e carimbo do médico";

            linha = (ultimaLinhaPagina - (alturaLinha * 7));
            gLinhaIni = gLinhaFim = (int)linha;
            gColIni = (int)MargemEsquerda;
            gColFim = (int)MargemDireita;
            e.Graphics.DrawLine(pp, gColIni, gLinhaIni, gColFim, gLinhaFim); // horizontal RODAPÉ

            linha += alturaLinha * 2;
            coluna = colunaInicial;
            e.Graphics.DrawString(string.Format("{0}", labelLocal), fontTextoBold, Brushes.Black, coluna, linha, new StringFormat());
            coluna += (int)e.Graphics.MeasureString(labelLocal, fontTextoBold).Width;
            e.Graphics.DrawString(dtoAtestadoDeclaracao.dsUnidade, fontTexto, Brushes.Black, coluna, linha, new StringFormat());

            coluna = 300;
            // coluna = (int)(e.Graphics.MeasureString(labelLocal, fontTextoBold).Width + e.Graphics.MeasureString(txtLocal, fontTextoBold).Width)+10;
            e.Graphics.DrawString(string.Format("{0}", DataEmissao), fontTexto, Brushes.Black, coluna, linha, new StringFormat());
            coluna += (int)e.Graphics.MeasureString(DataEmissao, fontTexto).Width;
            e.Graphics.DrawString(dtoAtestadoDeclaracao.dataImpressao.ToString(), fontTexto, Brushes.Black, coluna, linha, new StringFormat());

            coluna = (int)(MargemDireita - (e.Graphics.MeasureString(assinatura, fontTextoBold).Width));
            e.Graphics.DrawString(string.Format("{0}", assinatura), fontTextoBold, Brushes.Black, coluna, linha, new StringFormat());

            linha += alturaLinha;
            coluna = colunaInicial;
            e.Graphics.DrawString(string.Format("{0}", labelSetor), fontTextoBold, Brushes.Black, coluna, linha, new StringFormat());
            coluna += (int)e.Graphics.MeasureString(labelSetor, fontTextoBold).Width;
            e.Graphics.DrawString(dtoAtestadoDeclaracao.dsSetor, fontTexto, Brushes.Black, coluna, linha, new StringFormat());


            linha += (alturaLinha * 2);
            gLinhaIni = gLinhaFim = (int)linha;
            gColIni = colunaInicial;
            gColFim = (int)MargemDireita - 10;
            e.Graphics.DrawLine(pp, gColIni, gLinhaIni, gColFim, gLinhaFim); // linha assinatura
            e.Graphics.DrawString("www.anacosta.com.br", fontTexto, Brushes.Black, 360, linha + 5, new StringFormat());
        }
    }
}
