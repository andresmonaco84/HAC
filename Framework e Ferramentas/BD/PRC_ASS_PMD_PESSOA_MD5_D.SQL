

  --PRC_ASS_PMD_PESSOA_MD5_D
  create or replace procedure PRC_ASS_PMD_PESSOA_MD5_D 
  (
     pASS_PMD_ID IN TB_ASS_PMD_PESSOA_MD5.ASS_PMD_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PMD_PESSOA_MD5_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_PMD_PESSOA_MD5
    WHERE  
        ASS_PMD_ID = pASS_PMD_ID;	   
  end PRC_ASS_PMD_PESSOA_MD5_D;
