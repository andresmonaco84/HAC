

  --PRC_ECIALIDADE_D
  create or replace procedure PRC_ECIALIDADE_D 
  (
     pCODESPMED IN ESPECIALIDADE.CODESPMED%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ECIALIDADE_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE ESPECIALIDADE
    WHERE  
        CODESPMED = pCODESPMED;	   
  end PRC_ECIALIDADE_D;
