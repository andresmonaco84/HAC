

  --PRC_ASS_PEM_PESSOA_EMAIL_D
  create or replace procedure PRC_ASS_PEM_PESSOA_EMAIL_D 
  (
     pASS_PEM_ID_PESSOA_EMAIL IN TB_ASS_PEM_PESSOA_EMAIL.ASS_PEM_ID_PESSOA_EMAIL%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PEM_PESSOA_EMAIL_D
  * 
  *    Data Criacao: 	11/06/2007  Por: Ricardo Costa
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Exclui E-Mail Associado a Pessoa
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_PEM_PESSOA_EMAIL
    WHERE  
        ASS_PEM_ID_PESSOA_EMAIL = pASS_PEM_ID_PESSOA_EMAIL;	   
  end PRC_ASS_PEM_PESSOA_EMAIL_D;
