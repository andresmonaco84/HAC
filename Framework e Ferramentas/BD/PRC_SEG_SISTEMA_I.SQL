
---fim


  --PRC_SEG_SISTEMA_I
  create or replace procedure PRC_SEG_SISTEMA_I
  (
     pSEG_ID_SISTEMA IN TB_SEG_SISTEMA.SEG_ID_SISTEMA%type,
     pSEG_NM_SISTEMA IN TB_SEG_SISTEMA.SEG_NM_SISTEMA%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_SISTEMA_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_SEG_SISTEMA
    (
       SEG_ID_SISTEMA,
       SEG_NM_SISTEMA
    )
    VALUES
    (
	     pSEG_ID_SISTEMA,
	     pSEG_NM_SISTEMA
    );
	
  end PRC_SEG_SISTEMA_I;

