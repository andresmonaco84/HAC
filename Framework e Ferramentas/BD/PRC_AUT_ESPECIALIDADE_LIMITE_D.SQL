

  --PRC_AUT_ESPECIALIDADE_LIMITE_D
  create or replace procedure PRC_AUT_ESPECIALIDADE_LIMITE_D 
  (
     pCODESPMED IN TB_AUT_ESPECIALIDADE_LIMITE.CODESPMED%type,
     pTP_ATENDIMENTO IN TB_AUT_ESPECIALIDADE_LIMITE.TP_ATENDIMENTO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUT_ESPECIALIDADE_LIMITE_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AUT_ESPECIALIDADE_LIMITE
    WHERE  
        CODESPMED = pCODESPMED
    AND TP_ATENDIMENTO = pTP_ATENDIMENTO;	   
  end PRC_AUT_ESPECIALIDADE_LIMITE_D;
