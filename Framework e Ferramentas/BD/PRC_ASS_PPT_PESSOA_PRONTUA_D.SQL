

  --PRC_ASS_PPT_PESSOA_PRONTUARIO_D
  create or replace procedure PRC_ASS_PPT_PESSOA_PRONTUA_D 
  (
     pASS_PPT_ID_PESSOA_PRONTUARIO IN TB_ASS_PPT_PESSOA_PRONTUARIO.ASS_PPT_ID_PESSOA_PRONTUARIO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PPT_PESSOA_PRONTUA_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_PPT_PESSOA_PRONTUARIO
    WHERE  
        ASS_PPT_ID_PESSOA_PRONTUARIO = pASS_PPT_ID_PESSOA_PRONTUARIO;	   
  end PRC_ASS_PPT_PESSOA_PRONTUA_D;
