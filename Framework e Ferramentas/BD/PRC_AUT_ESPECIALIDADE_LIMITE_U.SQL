

  --PRC_AUT_ESPECIALIDADE_LIMITE_U
  create or replace procedure PRC_AUT_ESPECIALIDADE_LIMITE_U
  (
     pCODESPMED IN TB_AUT_ESPECIALIDADE_LIMITE.CODESPMED%type,
     pTP_ATENDIMENTO IN TB_AUT_ESPECIALIDADE_LIMITE.TP_ATENDIMENTO%type,
     pQTD_DIAS_PERIODO IN TB_AUT_ESPECIALIDADE_LIMITE.QTD_DIAS_PERIODO%type default NULL,
     pQTD_LIMITE IN TB_AUT_ESPECIALIDADE_LIMITE.QTD_LIMITE%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_ESPECIALIDADE_LIMITE_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AUT_ESPECIALIDADE_LIMITE
    SET	   
        QTD_DIAS_PERIODO = pQTD_DIAS_PERIODO,
        QTD_LIMITE = pQTD_LIMITE 
    WHERE
        CODESPMED = pCODESPMED
    AND TP_ATENDIMENTO = pTP_ATENDIMENTO;	
  end PRC_AUT_ESPECIALIDADE_LIMITE_U;

