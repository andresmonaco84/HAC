

  --PRC_AGS_ESM_ESCALA_SADT_D
  create or replace procedure PRC_AGS_ESM_ESCALA_SADT_D 
  (
     pAGS_ESM_ID IN TB_AGS_ESM_ESCALA_SADT.AGS_ESM_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGS_ESM_ESCALA_SADT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AGS_ESM_ESCALA_SADT
    WHERE  
        AGS_ESM_ID = pAGS_ESM_ID;	   
  end PRC_AGS_ESM_ESCALA_SADT_D;
