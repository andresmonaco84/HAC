

  --PRC_AUT_ATO_ESPEC_D
  create or replace procedure PRC_AUT_ATO_ESPEC_D 
  (
     pCODATOMED IN TB_AUT_ATO_ESPEC.CODATOMED%type,
     pCODESPMED IN TB_AUT_ATO_ESPEC.CODESPMED%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUT_ATO_ESPEC_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AUT_ATO_ESPEC
    WHERE  
        CODATOMED = pCODATOMED
    AND CODESPMED = pCODESPMED;	   
  end PRC_AUT_ATO_ESPEC_D;
