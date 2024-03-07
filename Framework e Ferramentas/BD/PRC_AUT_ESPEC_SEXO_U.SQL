

  --PRC_AUT_ESPEC_SEXO_U
  create or replace procedure PRC_AUT_ESPEC_SEXO_U
  (
     pCODESPMED IN TB_AUT_ESPEC_SEXO.CODESPMED%type,
     pSEXBEN IN TB_AUT_ESPEC_SEXO.SEXBEN%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_ESPEC_SEXO_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AUT_ESPEC_SEXO
    SET	   
        SEXBEN = pSEXBEN 
    WHERE
        CODESPMED = pCODESPMED;	
  end PRC_AUT_ESPEC_SEXO_U;

