 
  --PRC_AUT_MEDICO_LOCAL_ESP_S
  create or replace procedure PRC_AUT_MEDICO_LOCAL_ESP_S 
  (
     pCODCLI IN TB_AUT_MEDICO_LOCAL_ESP.CODCLI%type DEFAULT NULL,
     pCODUNI IN TB_AUT_MEDICO_LOCAL_ESP.CODUNI%type DEFAULT NULL,
     pCODESP IN TB_AUT_MEDICO_LOCAL_ESP.CODESP%type DEFAULT NULL,
     pCODCRM IN TB_AUT_MEDICO_LOCAL_ESP.CODCRM%type DEFAULT NULL,
     pNOMMED IN TB_AUT_MEDICO_LOCAL_ESP.NOMMED%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_MEDICO_LOCAL_ESP_S
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
       CODESP,
       CODCRM,
       NOMMED
    FROM TB_AUT_MEDICO_LOCAL_ESP
    WHERE
        (pCODCLI is null OR CODCLI = pCODCLI) AND 
        (pCODUNI is null OR CODUNI = pCODUNI) AND 
        (pCODESP is null OR CODESP = pCODESP) AND 
        (pCODCRM is null OR CODCRM = pCODCRM) AND 
        (pNOMMED is null OR NOMMED = pNOMMED);          
    io_cursor := v_cursor;
  end PRC_AUT_MEDICO_LOCAL_ESP_S;
