

  --PRC_AUT_CONF_ESP_AUTORIZADOR_D
  create or replace procedure PRC_AUT_CONF_ESP_AUTORIZADOR_D 
  (
     pCODCON IN TB_AUT_CONF_ESP_AUTORIZADOR.CODCON%type,
     pCODESPMED IN TB_AUT_CONF_ESP_AUTORIZADOR.CODESPMED%type,
     pTP_ATENDIMENTO IN TB_AUT_CONF_ESP_AUTORIZADOR.TP_ATENDIMENTO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUT_CONF_ESP_AUTORIZADOR_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AUT_CONF_ESP_AUTORIZADOR
    WHERE  
        CODCON = pCODCON
    AND CODESPMED = pCODESPMED
    AND TP_ATENDIMENTO = pTP_ATENDIMENTO;	   
  end PRC_AUT_CONF_ESP_AUTORIZADOR_D;
