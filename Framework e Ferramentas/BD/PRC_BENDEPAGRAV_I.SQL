

  --PRC_BENDEPAGRAV_I
  create or replace procedure PRC_BENDEPAGRAV_I
  (
     pCODCON IN BNF_BENDEPAGRAV.CODCON%type,
     pCODEST IN BNF_BENDEPAGRAV.CODEST%type,
     pCODBEN IN BNF_BENDEPAGRAV.CODBEN%type,
     pCODSEQBEN IN BNF_BENDEPAGRAV.CODSEQBEN%type,
     pDATLIMITE IN BNF_BENDEPAGRAV.DATLIMITE%type,
     pCID IN BNF_BENDEPAGRAV.CID%type,
     pDATINICIO IN BNF_BENDEPAGRAV.DATINICIO%type default NULL	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_BENDEPAGRAV_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO BNF_BENDEPAGRAV
    (
       CODCON,
       CODEST,
       CODBEN,
       CODSEQBEN,
       DATLIMITE,
       CID,
       DATINICIO
    )
    VALUES
    (
	     pCODCON,
	     pCODEST,
	     pCODBEN,
	     pCODSEQBEN,
	     pDATLIMITE,
	     pCID,
	     pDATINICIO
    );
	
  end PRC_BENDEPAGRAV_I;

