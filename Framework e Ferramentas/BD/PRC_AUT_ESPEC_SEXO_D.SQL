

  --PRC_AUT_ESPEC_SEXO_D
  create or replace procedure PRC_AUT_ESPEC_SEXO_D 
  (
     pCODESPMED IN TB_AUT_ESPEC_SEXO.CODESPMED%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUT_ESPEC_SEXO_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AUT_ESPEC_SEXO
    WHERE  
        CODESPMED = pCODESPMED;	   
  end PRC_AUT_ESPEC_SEXO_D;
