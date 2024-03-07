

  --PRC_AUT_ATO_MEDICO_LIMITE_D
  create or replace procedure PRC_AUT_ATO_MEDICO_LIMITE_D 
  (
     pCODATOMED IN TB_AUT_ATO_MEDICO_LIMITE.CODATOMED%type,
     pTP_ATENDIMENTO IN TB_AUT_ATO_MEDICO_LIMITE.TP_ATENDIMENTO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUT_ATO_MEDICO_LIMITE_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AUT_ATO_MEDICO_LIMITE
    WHERE  
        CODATOMED = pCODATOMED
    AND TP_ATENDIMENTO = pTP_ATENDIMENTO;	   
  end PRC_AUT_ATO_MEDICO_LIMITE_D;
