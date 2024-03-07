

  --PRC_ASS_PRP_PROFISSIONAL_PROD_D
  create or replace procedure PRC_ASS_PRP_PROF_PROD_D
  (
     pASS_PRP_ID IN TB_ASS_PRP_PROFISSIONAL_PROD.ASS_PRP_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PRP_PROFISSIONAL_PROD_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_PRP_PROFISSIONAL_PROD
    WHERE  
        ASS_PRP_ID = pASS_PRP_ID;	   
  end PRC_ASS_PRP_PROF_PROD_D;
