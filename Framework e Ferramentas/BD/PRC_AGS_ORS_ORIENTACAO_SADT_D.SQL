

  --PRC_AGS_ORS_ORIENTACAO_SADT_D
  create or replace procedure PRC_AGS_ORS_ORIENTACAO_SADT_D 
  (
     pAGS_ORS_ID IN TB_AGS_ORS_ORIENTACAO_SADT.AGS_ORS_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGS_ORS_ORIENTACAO_SADT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AGS_ORS_ORIENTACAO_SADT
    WHERE  
        AGS_ORS_ID = pAGS_ORS_ID;	   
  end PRC_AGS_ORS_ORIENTACAO_SADT_D;
