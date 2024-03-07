

  --PRC_AUT_ESPEC_SEXO_I
  create or replace procedure PRC_AUT_ESPEC_SEXO_I
  (
     pCODESPMED IN TB_AUT_ESPEC_SEXO.CODESPMED%type,
     pSEXBEN IN TB_AUT_ESPEC_SEXO.SEXBEN%type default NULL	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_ESPEC_SEXO_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_AUT_ESPEC_SEXO
    (
       CODESPMED,
       SEXBEN
    )
    VALUES
    (
	     pCODESPMED,
	     pSEXBEN
    );
	
  end PRC_AUT_ESPEC_SEXO_I;

