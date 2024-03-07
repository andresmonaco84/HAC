

  --PRC_VICO_I
  create or replace procedure PRC_VICO_I
  (
     pCODSER IN SERVICO.CODSER%type,
     pNOMSER IN SERVICO.NOMSER%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_VICO_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO SERVICO
    (
       CODSER,
       NOMSER
    )
    VALUES
    (
	     pCODSER,
	     pNOMSER
    );
	
  end PRC_VICO_I;

