 
  --PRC_AUT_CLINICA_PROCED_S
  create or replace procedure PRC_AUT_CLINICA_PROCED_S 
  (
     pCODCLI IN TB_AUT_CLINICA_PROCED.CODCLI%type DEFAULT NULL,
     pCODUNI IN TB_AUT_CLINICA_PROCED.CODUNI%type DEFAULT NULL,
     pCODATOMED IN TB_AUT_CLINICA_PROCED.CODATOMED%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_CLINICA_PROCED_S
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
       CODUNI,
       CODATOMED
    FROM TB_AUT_CLINICA_PROCED
    WHERE
        (pCODCLI is null OR CODCLI = pCODCLI) AND 
        (pCODUNI is null OR CODUNI = pCODUNI) AND 
        (pCODATOMED is null OR CODATOMED = pCODATOMED);          
    io_cursor := v_cursor;
  end PRC_AUT_CLINICA_PROCED_S;
