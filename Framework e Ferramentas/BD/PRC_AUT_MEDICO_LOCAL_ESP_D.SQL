

  --PRC_AUT_MEDICO_LOCAL_ESP_D
  create or replace procedure PRC_AUT_MEDICO_LOCAL_ESP_D 
  (
     pCODCLI IN TB_AUT_MEDICO_LOCAL_ESP.CODCLI%type,
     pCODCRM IN TB_AUT_MEDICO_LOCAL_ESP.CODCRM%type,
     pCODESP IN TB_AUT_MEDICO_LOCAL_ESP.CODESP%type,
     pCODUNI IN TB_AUT_MEDICO_LOCAL_ESP.CODUNI%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUT_MEDICO_LOCAL_ESP_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AUT_MEDICO_LOCAL_ESP
    WHERE  
        CODCLI = pCODCLI
    AND CODCRM = pCODCRM
    AND CODESP = pCODESP
    AND CODUNI = pCODUNI;	   
  end PRC_AUT_MEDICO_LOCAL_ESP_D;
