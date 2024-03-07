

  --PRC_AUT_ATO_MEDICO_LIMITE_I
  create or replace procedure PRC_AUT_ATO_MEDICO_LIMITE_I
  (
     pCODATOMED IN TB_AUT_ATO_MEDICO_LIMITE.CODATOMED%type,
     pTP_ATENDIMENTO IN TB_AUT_ATO_MEDICO_LIMITE.TP_ATENDIMENTO%type,
     pQTD_DIAS_PERIODO IN TB_AUT_ATO_MEDICO_LIMITE.QTD_DIAS_PERIODO%type default NULL,
     pQTD_LIMITE IN TB_AUT_ATO_MEDICO_LIMITE.QTD_LIMITE%type default NULL	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_ATO_MEDICO_LIMITE_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_AUT_ATO_MEDICO_LIMITE
    (
       CODATOMED,
       TP_ATENDIMENTO,
       QTD_DIAS_PERIODO,
       QTD_LIMITE
    )
    VALUES
    (
	     pCODATOMED,
	     pTP_ATENDIMENTO,
	     pQTD_DIAS_PERIODO,
	     pQTD_LIMITE
    );
	
  end PRC_AUT_ATO_MEDICO_LIMITE_I;

