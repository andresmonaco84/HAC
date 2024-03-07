

  --PRC_BENDEPAGRAV_U
  create or replace procedure PRC_BENDEPAGRAV_U
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
  *    Procedure: PRC_BENDEPAGRAV_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE BNF_BENDEPAGRAV
    SET	   
        DATLIMITE = pDATLIMITE,
        DATINICIO = pDATINICIO 
    WHERE
        CID = pCID
    AND CODBEN = pCODBEN
    AND CODCON = pCODCON
    AND CODEST = pCODEST
    AND CODSEQBEN = pCODSEQBEN;	
  end PRC_BENDEPAGRAV_U;

