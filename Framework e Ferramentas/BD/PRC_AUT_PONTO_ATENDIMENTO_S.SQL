 
  --PRC_AUT_PONTO_ATENDIMENTO_S
  create or replace procedure PRC_AUT_PONTO_ATENDIMENTO_S 
  (
     pCODCLI IN TB_AUT_PONTO_ATENDIMENTO.CODCLI%type DEFAULT NULL,
     pCODUNI IN TB_AUT_PONTO_ATENDIMENTO.CODUNI%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_PONTO_ATENDIMENTO_S
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CODCLI,
       CODUNI
    FROM TB_AUT_PONTO_ATENDIMENTO
    WHERE
        (pCODCLI is null OR CODCLI = pCODCLI) AND 
        (pCODUNI is null OR CODUNI = pCODUNI);          
    io_cursor := v_cursor;
  end PRC_AUT_PONTO_ATENDIMENTO_S;
