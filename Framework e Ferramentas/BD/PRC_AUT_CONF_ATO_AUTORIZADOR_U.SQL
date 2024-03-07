

  --PRC_AUT_CONF_ATO_AUTORIZADOR_U
  create or replace procedure PRC_AUT_CONF_ATO_AUTORIZADOR_U
  (
     pQTD_LIMITE IN TB_AUT_CONF_ATO_AUTORIZADOR.QTD_LIMITE%type,
     pCODATOMED IN TB_AUT_CONF_ATO_AUTORIZADOR.CODATOMED%type,
     pQTD_DIAS_PERIODO IN TB_AUT_CONF_ATO_AUTORIZADOR.QTD_DIAS_PERIODO%type default NULL,
     pTP_ATENDIMENTO IN TB_AUT_CONF_ATO_AUTORIZADOR.TP_ATENDIMENTO%type,
     pCODCON IN TB_AUT_CONF_ATO_AUTORIZADOR.CODCON%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_CONF_ATO_AUTORIZADOR_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AUT_CONF_ATO_AUTORIZADOR
    SET	   
        QTD_LIMITE = pQTD_LIMITE,
        QTD_DIAS_PERIODO = pQTD_DIAS_PERIODO 
    WHERE
        CODATOMED = pCODATOMED
    AND CODCON = pCODCON
    AND TP_ATENDIMENTO = pTP_ATENDIMENTO;	
  end PRC_AUT_CONF_ATO_AUTORIZADOR_U;

