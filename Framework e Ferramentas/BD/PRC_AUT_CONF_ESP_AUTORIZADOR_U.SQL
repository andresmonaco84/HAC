

  --PRC_AUT_CONF_ESP_AUTORIZADOR_U
  create or replace procedure PRC_AUT_CONF_ESP_AUTORIZADOR_U
  (
     pCODCON IN TB_AUT_CONF_ESP_AUTORIZADOR.CODCON%type,
     pCODESPMED IN TB_AUT_CONF_ESP_AUTORIZADOR.CODESPMED%type,
     pTP_ATENDIMENTO IN TB_AUT_CONF_ESP_AUTORIZADOR.TP_ATENDIMENTO%type,
     pQTD_LIMITE IN TB_AUT_CONF_ESP_AUTORIZADOR.QTD_LIMITE%type default NULL,
     pQTD_DIAS_PERIODO IN TB_AUT_CONF_ESP_AUTORIZADOR.QTD_DIAS_PERIODO%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_CONF_ESP_AUTORIZADOR_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AUT_CONF_ESP_AUTORIZADOR
    SET	   
        QTD_LIMITE = pQTD_LIMITE,
        QTD_DIAS_PERIODO = pQTD_DIAS_PERIODO 
    WHERE
        CODCON = pCODCON
    AND CODESPMED = pCODESPMED
    AND TP_ATENDIMENTO = pTP_ATENDIMENTO;	
  end PRC_AUT_CONF_ESP_AUTORIZADOR_U;

