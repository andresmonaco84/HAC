

  --PRC_AUT_ESPEC_IDADE_U
  create or replace procedure PRC_AUT_ESPEC_IDADE_U
  (
     pCODESPMED IN TB_AUT_ESPEC_IDADE.CODESPMED%type,
     pIDADE IN TB_AUT_ESPEC_IDADE.IDADE%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_ESPEC_IDADE_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AUT_ESPEC_IDADE
    SET	   
        IDADE = pIDADE 
    WHERE
        CODESPMED = pCODESPMED;	
  end PRC_AUT_ESPEC_IDADE_U;

