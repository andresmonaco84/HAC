
  create or replace procedure PRC_SEG_USUARIO_D 
  (
     pSEG_USU_ID_USUARIO IN TB_SEG_USU_USUARIO.SEG_USU_ID_USUARIO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_SEG_USU_USUARIO_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_SEG_USU_USUARIO
    WHERE  
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO;	   
  end PRC_SEG_USUARIO_D;
