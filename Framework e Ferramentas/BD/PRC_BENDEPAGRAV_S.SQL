 
  --PRC_BENDEPAGRAV_S
  create or replace procedure PRC_BENDEPAGRAV_S 
  (
     pCODCON IN BNF_BENDEPAGRAV.CODCON%type DEFAULT NULL,
     pCODEST IN BNF_BENDEPAGRAV.CODEST%type DEFAULT NULL,
     pCODBEN IN BNF_BENDEPAGRAV.CODBEN%type DEFAULT NULL,
     pCODSEQBEN IN BNF_BENDEPAGRAV.CODSEQBEN%type DEFAULT NULL,
     pDATLIMITE IN BNF_BENDEPAGRAV.DATLIMITE%type DEFAULT NULL,
     pCID IN BNF_BENDEPAGRAV.CID%type DEFAULT NULL,
     pDATINICIO IN BNF_BENDEPAGRAV.DATINICIO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_BENDEPAGRAV_S
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CODCON,
       CODEST,
       CODBEN,
       CODSEQBEN,
       DATLIMITE,
       CID,
       DATINICIO
    FROM BNF_BENDEPAGRAV
    WHERE
        (pCODCON is null OR CODCON = pCODCON) AND 
        (pCODEST is null OR CODEST = pCODEST) AND 
        (pCODBEN is null OR CODBEN = pCODBEN) AND 
        (pCODSEQBEN is null OR CODSEQBEN = pCODSEQBEN) AND 
        (pDATLIMITE is null OR DATLIMITE = pDATLIMITE) AND 
        (pCID is null OR CID = pCID) AND 
        (pDATINICIO is null OR DATINICIO = pDATINICIO);          
    io_cursor := v_cursor;
  end PRC_BENDEPAGRAV_S;
