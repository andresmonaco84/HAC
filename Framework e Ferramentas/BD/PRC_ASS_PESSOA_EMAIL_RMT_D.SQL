  --PRC_ASS_PESSOA_EMAIL_RMT_D
  create or replace procedure PRC_ASS_PESSOA_EMAIL_RMT_D 
  (
     pASS_PEM_ID_PESSOA_EMAIL IN TB_ASS_PEM_PESSOA_EMAIL.ASS_PEM_ID_PESSOA_EMAIL%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PESSOA_EMAIL_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_PEM_PESSOA_EMAIL
    WHERE  
        ASS_PEM_ID_PESSOA_EMAIL = pASS_PEM_ID_PESSOA_EMAIL;	   
  end PRC_ASS_PESSOA_EMAIL_RMT_D;
