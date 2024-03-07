

  --PRC_AUT_ESPEC_IDADE_I
  create or replace procedure PRC_AUT_ESPEC_IDADE_I
  (
     pCODESPMED IN TB_AUT_ESPEC_IDADE.CODESPMED%type,
     pIDADE IN TB_AUT_ESPEC_IDADE.IDADE%type default NULL	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_ESPEC_IDADE_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_AUT_ESPEC_IDADE
    (
       CODESPMED,
       IDADE
    )
    VALUES
    (
	     pCODESPMED,
	     pIDADE
    );
	
  end PRC_AUT_ESPEC_IDADE_I;

