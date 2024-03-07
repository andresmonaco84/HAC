

  --PRC_AUT_CONF_ESP_AUTORIZADOR_I
  create or replace procedure PRC_AUT_CONF_ESP_AUTORIZADOR_I
  (
     pCODCON IN TB_AUT_CONF_ESP_AUTORIZADOR.CODCON%type,
     pCODESPMED IN TB_AUT_CONF_ESP_AUTORIZADOR.CODESPMED%type,
     pTP_ATENDIMENTO IN TB_AUT_CONF_ESP_AUTORIZADOR.TP_ATENDIMENTO%type,
     pQTD_LIMITE IN TB_AUT_CONF_ESP_AUTORIZADOR.QTD_LIMITE%type default NULL,
     pQTD_DIAS_PERIODO IN TB_AUT_CONF_ESP_AUTORIZADOR.QTD_DIAS_PERIODO%type default NULL	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_CONF_ESP_AUTORIZADOR_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_AUT_CONF_ESP_AUTORIZADOR
    (
       CODCON,
       CODESPMED,
       TP_ATENDIMENTO,
       QTD_LIMITE,
       QTD_DIAS_PERIODO
    )
    VALUES
    (
	     pCODCON,
	     pCODESPMED,
	     pTP_ATENDIMENTO,
	     pQTD_LIMITE,
	     pQTD_DIAS_PERIODO
    );
	
  end PRC_AUT_CONF_ESP_AUTORIZADOR_I;

