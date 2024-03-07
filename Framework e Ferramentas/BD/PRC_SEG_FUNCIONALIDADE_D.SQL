

  --PRC_SEG_FUN_FUNCIONALIDADE_D
  create or replace procedure PRC_SEG_FUNCIONALIDADE_D 
  (
     pSEG_FUN_ID_FUNCIONALIDADE IN TB_SEG_FUN_FUNCIONALIDADE.SEG_FUN_ID_FUNCIONALIDADE%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_SEG_FUN_FUNCIONALIDADE_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_SEG_FUN_FUNCIONALIDADE
    WHERE  
        SEG_FUN_ID_FUNCIONALIDADE = pSEG_FUN_ID_FUNCIONALIDADE;	   
  end PRC_SEG_FUNCIONALIDADE_D;
