  create or replace procedure PRC_CLINICA_CONTRATADA_S 
  (
     pCODCLI IN TB_CLINICA_CONTRATADA.CODCLI%type DEFAULT NULL,
     pRAZSOC IN TB_CLINICA_CONTRATADA.RAZSOC%type DEFAULT NULL,
     pIN_CANCELA IN TB_CLINICA_CONTRATADA.IN_CANCELA%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CLINICA_CONTRATADA_S
  * 
  *    Data Criacao: 	14/01/2008   Por: Andrea Cazuca
  *    Data Alteracao:	data da alteraÃ§Ã£o  Por: Nome do Analista
  *
  *	   Data AlteraÃ§Ã£o:	InclusÃ£o do campo in_cancela como parÃ¢metro para facilitar a busca
  *    Por: Fabiola R. Lopes
  *
  *    Funcao: Lista ou obtem a Instituicao Clinica
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CODCLI,
       RAZSOC,
       CGC,
       NOMFAN,
       ENDCLI,
       COMPLE,
       CEP,
       CIDCLI,
       UF,
       TELEF,
       RAMAL,
       CONPAC,
       TIPSERCLI,
       IN_CANCELA
    FROM TB_CLINICA_CONTRATADA
    WHERE
        (pCODCLI is null OR CODCLI = pCODCLI)
    AND (pRAZSOC is null OR RAZSOC LIKE UPPER(pRAZSOC)
    AND (IN_CANCELA is null or IN_CANCELA = pIN_CANCELA));
    io_cursor := v_cursor;
  end PRC_CLINICA_CONTRATADA_S;
/