

  --PRC_AGS_AGC_AGENDA_CANC_SADT_D
  create or replace procedure PRC_AGS_AGC_AGENDA_CANC_SADT_D 
  (
     pAGS_AGE_ID IN TB_AGS_AGC_AGENDA_CANC_SADT.AGS_AGE_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGS_AGC_AGENDA_CANC_SADT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AGS_AGC_AGENDA_CANC_SADT
    WHERE  
        AGS_AGE_ID = pAGS_AGE_ID;	   
  end PRC_AGS_AGC_AGENDA_CANC_SADT_D;
