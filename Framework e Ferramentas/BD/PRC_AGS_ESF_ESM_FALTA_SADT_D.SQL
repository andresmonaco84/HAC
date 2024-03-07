

  --PRC_AGS_ESF_ESCALA_FALTA_SADT_D
  create or replace procedure PRC_AGS_ESF_ESM_FALTA_SADT_D 
  (
     pAGS_ESF_ID IN TB_AGS_ESF_ESCALA_FALTA_SADT.AGS_ESF_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGS_ESF_ESCALA_FALTA_SADT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AGS_ESF_ESCALA_FALTA_SADT
    WHERE  
        AGS_ESF_ID = pAGS_ESF_ID;	   
  end PRC_AGS_ESF_ESM_FALTA_SADT_D;
