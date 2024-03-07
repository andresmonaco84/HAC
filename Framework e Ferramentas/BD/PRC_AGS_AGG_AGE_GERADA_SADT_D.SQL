

  --PRC_AGS_AGG_AGE_GERADA_SADT_D
  create or replace procedure PRC_AGS_AGG_AGE_GERADA_SADT_D 
  (
     pAGS_AGG_ID IN TB_AGS_AGG_AGE_GERADA_SADT.AGS_AGG_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGS_AGG_AGE_GERADA_SADT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AGS_AGG_AGE_GERADA_SADT
    WHERE  
        AGS_AGG_ID = pAGS_AGG_ID;	   
  end PRC_AGS_AGG_AGE_GERADA_SADT_D;
