

  --PRC_AGE_AGC_AGENDA_CANCELADA_D
  create or replace procedure PRC_AGE_AGC_AGENDA_CANCELADA_D 
  (
     pAGE_AGD_ID IN TB_AGE_AGC_AGENDA_CANCELADA.AGE_AGD_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_AGC_AGENDA_CANCELADA_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AGE_AGC_AGENDA_CANCELADA
    WHERE  
        AGE_AGD_ID = pAGE_AGD_ID;	   
  end PRC_AGE_AGC_AGENDA_CANCELADA_D;
