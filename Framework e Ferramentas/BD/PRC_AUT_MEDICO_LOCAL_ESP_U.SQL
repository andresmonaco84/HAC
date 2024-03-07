

  --PRC_AUT_MEDICO_LOCAL_ESP_U
  create or replace procedure PRC_AUT_MEDICO_LOCAL_ESP_U
  (
     pCODCLI IN TB_AUT_MEDICO_LOCAL_ESP.CODCLI%type,
     pCODUNI IN TB_AUT_MEDICO_LOCAL_ESP.CODUNI%type,
     pCODESP IN TB_AUT_MEDICO_LOCAL_ESP.CODESP%type,
     pCODCRM IN TB_AUT_MEDICO_LOCAL_ESP.CODCRM%type,
     pNOMMED IN TB_AUT_MEDICO_LOCAL_ESP.NOMMED%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_MEDICO_LOCAL_ESP_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AUT_MEDICO_LOCAL_ESP
    SET	   
        NOMMED = pNOMMED 
    WHERE
        CODCLI = pCODCLI
    AND CODCRM = pCODCRM
    AND CODESP = pCODESP
    AND CODUNI = pCODUNI;	
  end PRC_AUT_MEDICO_LOCAL_ESP_U;

