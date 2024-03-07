

  --PRC_AGS_OPR_ORIENTACAO_PROD_D
  create or replace procedure PRC_AGS_OPR_ORIENTACAO_PROD_D 
  (
     pAGS_OPR_ID IN TB_AGS_OPR_ORIENTACAO_PROD.AGS_OPR_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGS_OPR_ORIENTACAO_PROD_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AGS_OPR_ORIENTACAO_PROD
    WHERE  
        AGS_OPR_ID = pAGS_OPR_ID;	   
  end PRC_AGS_OPR_ORIENTACAO_PROD_D;
