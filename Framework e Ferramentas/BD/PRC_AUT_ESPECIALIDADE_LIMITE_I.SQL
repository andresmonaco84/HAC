

  --PRC_AUT_ESPECIALIDADE_LIMITE_I
  create or replace procedure PRC_AUT_ESPECIALIDADE_LIMITE_I
  (
     pCODESPMED IN TB_AUT_ESPECIALIDADE_LIMITE.CODESPMED%type,
     pTP_ATENDIMENTO IN TB_AUT_ESPECIALIDADE_LIMITE.TP_ATENDIMENTO%type,
     pQTD_DIAS_PERIODO IN TB_AUT_ESPECIALIDADE_LIMITE.QTD_DIAS_PERIODO%type default NULL,
     pQTD_LIMITE IN TB_AUT_ESPECIALIDADE_LIMITE.QTD_LIMITE%type default NULL	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_ESPECIALIDADE_LIMITE_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_AUT_ESPECIALIDADE_LIMITE
    (
       CODESPMED,
       TP_ATENDIMENTO,
       QTD_DIAS_PERIODO,
       QTD_LIMITE
    )
    VALUES
    (
	     pCODESPMED,
	     pTP_ATENDIMENTO,
	     pQTD_DIAS_PERIODO,
	     pQTD_LIMITE
    );
	
  end PRC_AUT_ESPECIALIDADE_LIMITE_I;

