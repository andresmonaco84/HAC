

  --PRC_AUT_ATO_ESPEC_I
  create or replace procedure PRC_AUT_ATO_ESPEC_I
  (
     pCODATOMED IN TB_AUT_ATO_ESPEC.CODATOMED%type,
     pCODESPMED IN TB_AUT_ATO_ESPEC.CODESPMED%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_ATO_ESPEC_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_AUT_ATO_ESPEC
    (
       CODATOMED,
       CODESPMED
    )
    VALUES
    (
	     pCODATOMED,
	     pCODESPMED
    );
	
  end PRC_AUT_ATO_ESPEC_I;

