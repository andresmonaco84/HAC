

  --PRC_AUT_MEDICO_LOCAL_ESP_I
  create or replace procedure PRC_AUT_MEDICO_LOCAL_ESP_I
  (
     pCODCLI IN TB_AUT_MEDICO_LOCAL_ESP.CODCLI%type,
     pCODUNI IN TB_AUT_MEDICO_LOCAL_ESP.CODUNI%type,
     pCODESP IN TB_AUT_MEDICO_LOCAL_ESP.CODESP%type,
     pCODCRM IN TB_AUT_MEDICO_LOCAL_ESP.CODCRM%type,
     pNOMMED IN TB_AUT_MEDICO_LOCAL_ESP.NOMMED%type default NULL	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_MEDICO_LOCAL_ESP_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_AUT_MEDICO_LOCAL_ESP
    (
       CODCLI,
       CODUNI,
       CODESP,
       CODCRM,
       NOMMED
    )
    VALUES
    (
	     pCODCLI,
	     pCODUNI,
	     pCODESP,
	     pCODCRM,
	     pNOMMED
    );
	
  end PRC_AUT_MEDICO_LOCAL_ESP_I;

