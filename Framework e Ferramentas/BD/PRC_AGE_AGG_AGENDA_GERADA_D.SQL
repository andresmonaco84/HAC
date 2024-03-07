  create or replace procedure PRC_AGE_AGG_AGENDA_GERADA_D
  (
     pAGE_AGG_ID IN TB_AGE_AGG_AGENDA_GERADA.AGE_AGG_ID%type     
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AGE_AGG_AGENDA_GERADA_D
  * 
  *    Data Criacao: 	18/09/2007   Por: Andrea Cazuca
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Excui da Agenda Gerada
  *
  *******************************************************************/  
  begin
    UPDATE TB_AGE_AGD_AGENDA
    SET    AGE_AGG_ID = NULL
    WHERE  AGE_AGG_ID = pAGE_AGG_ID;
    
    DELETE TB_AGE_AGG_AGENDA_GERADA
    WHERE
        AGE_AGG_ID = pAGE_AGG_ID;

  end PRC_AGE_AGG_AGENDA_GERADA_D;
/
