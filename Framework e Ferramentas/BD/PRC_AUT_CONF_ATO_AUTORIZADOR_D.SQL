

  --PRC_AUT_CONF_ATO_AUTORIZADOR_D
  create or replace procedure PRC_AUT_CONF_ATO_AUTORIZADOR_D 
  (
     pCODATOMED IN TB_AUT_CONF_ATO_AUTORIZADOR.CODATOMED%type,
     pCODCON IN TB_AUT_CONF_ATO_AUTORIZADOR.CODCON%type,
     pTP_ATENDIMENTO IN TB_AUT_CONF_ATO_AUTORIZADOR.TP_ATENDIMENTO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUT_CONF_ATO_AUTORIZADOR_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AUT_CONF_ATO_AUTORIZADOR
    WHERE  
        CODATOMED = pCODATOMED
    AND CODCON = pCODCON
    AND TP_ATENDIMENTO = pTP_ATENDIMENTO;	   
  end PRC_AUT_CONF_ATO_AUTORIZADOR_D;
