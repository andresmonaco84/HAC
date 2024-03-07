

  --PRC_SEG_SISTEMA_D
  create or replace procedure PRC_SEG_SISTEMA_D 
  (
     pSEG_ID_SISTEMA IN TB_SEG_SISTEMA.SEG_ID_SISTEMA%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_SEG_SISTEMA_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_SEG_SISTEMA
    WHERE  
        SEG_ID_SISTEMA = pSEG_ID_SISTEMA;	   
  end PRC_SEG_SISTEMA_D;
