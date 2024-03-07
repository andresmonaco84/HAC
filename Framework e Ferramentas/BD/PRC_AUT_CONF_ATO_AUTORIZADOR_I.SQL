

  --PRC_AUT_CONF_ATO_AUTORIZADOR_I
  create or replace procedure PRC_AUT_CONF_ATO_AUTORIZADOR_I
  (
     pQTD_LIMITE IN TB_AUT_CONF_ATO_AUTORIZADOR.QTD_LIMITE%type,
     pCODATOMED IN TB_AUT_CONF_ATO_AUTORIZADOR.CODATOMED%type,
     pQTD_DIAS_PERIODO IN TB_AUT_CONF_ATO_AUTORIZADOR.QTD_DIAS_PERIODO%type default NULL,
     pTP_ATENDIMENTO IN TB_AUT_CONF_ATO_AUTORIZADOR.TP_ATENDIMENTO%type,
     pCODCON IN TB_AUT_CONF_ATO_AUTORIZADOR.CODCON%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_CONF_ATO_AUTORIZADOR_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_AUT_CONF_ATO_AUTORIZADOR
    (
       QTD_LIMITE,
       CODATOMED,
       QTD_DIAS_PERIODO,
       TP_ATENDIMENTO,
       CODCON
    )
    VALUES
    (
	     pQTD_LIMITE,
	     pCODATOMED,
	     pQTD_DIAS_PERIODO,
	     pTP_ATENDIMENTO,
	     pCODCON
    );
	
  end PRC_AUT_CONF_ATO_AUTORIZADOR_I;

