create or replace procedure PRC_ASS_PRP_PROF_PROC_D
  (
     pASS_PRP_ID IN TB_ASS_PRP_PROFISSIONAL_PROD.ASS_PRP_ID%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PRP_PROF_PROC_D
  * 
  *    Data Criacao: 	22/08/2008           Por: Davi Silvestre M. dos Reis
  *    Data Alteracao:	                   Por: 
  *
  *    Funcao: Excluir registros na tabela TB_ASS_PRP_PROFISSIONAL_PROD
  *
  *******************************************************************/  
  begin
    DELETE TB_ASS_PRP_PROFISSIONAL_PROD
    WHERE
        ASS_PRP_ID = pASS_PRP_ID;
            
  end PRC_ASS_PRP_PROF_PROC_D;
/
