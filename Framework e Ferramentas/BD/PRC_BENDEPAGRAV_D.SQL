

  --PRC_BENDEPAGRAV_D
  create or replace procedure PRC_BENDEPAGRAV_D 
  (
     pCID IN BNF_BENDEPAGRAV.CID%type,
     pCODBEN IN BNF_BENDEPAGRAV.CODBEN%type,
     pCODCON IN BNF_BENDEPAGRAV.CODCON%type,
     pCODEST IN BNF_BENDEPAGRAV.CODEST%type,
     pCODSEQBEN IN BNF_BENDEPAGRAV.CODSEQBEN%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_BENDEPAGRAV_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE BNF_BENDEPAGRAV
    WHERE  
        CID = pCID
    AND CODBEN = pCODBEN
    AND CODCON = pCODCON
    AND CODEST = pCODEST
    AND CODSEQBEN = pCODSEQBEN;	   
  end PRC_BENDEPAGRAV_D;
