

  --PRC_ECIALIDADE_I
  create or replace procedure PRC_ECIALIDADE_I
  (
     pCODESPMED IN ESPECIALIDADE.CODESPMED%type,
     pDESESPMED IN ESPECIALIDADE.DESESPMED%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ECIALIDADE_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO ESPECIALIDADE
    (
       CODESPMED,
       DESESPMED
    )
    VALUES
    (
	     pCODESPMED,
	     pDESESPMED
    );
	
  end PRC_ECIALIDADE_I;

