

  --PRC__ENDERECO_BENEF_I
  create or replace procedure PRC_ENDERECO_BENEF_I
  (
     pCODCON IN BNF_ENDERECO_BENEF.CODCON%type,
     pCODEST IN BNF_ENDERECO_BENEF.CODEST%type,
     pCODBEN IN BNF_ENDERECO_BENEF.CODBEN%type,
     pCODCID IN BNF_ENDERECO_BENEF.CODCID%type,
     pENDBEN IN BNF_ENDERECO_BENEF.ENDBEN%type,
     pBAIBEN IN BNF_ENDERECO_BENEF.BAIBEN%type,
     pUFBEN IN BNF_ENDERECO_BENEF.UFBEN%type,
     pOBS IN BNF_ENDERECO_BENEF.OBS%type default NULL,
     pCEPBEN IN BNF_ENDERECO_BENEF.CEPBEN%type default NULL,
     pTELBEN IN BNF_ENDERECO_BENEF.TELBEN%type default NULL,
     pDDDBEN IN BNF_ENDERECO_BENEF.DDDBEN%type default NULL,
     pTELBEN1 IN BNF_ENDERECO_BENEF.TELBEN1%type default NULL,
     pDDDBEN1 IN BNF_ENDERECO_BENEF.DDDBEN1%type default NULL,
     pTELBEN2 IN BNF_ENDERECO_BENEF.TELBEN2%type default NULL,
     pDDDBEN2 IN BNF_ENDERECO_BENEF.DDDBEN2%type default NULL,
     pEMAIL IN BNF_ENDERECO_BENEF.EMAIL%type default NULL,
     pNUMEND IN BNF_ENDERECO_BENEF.NUMEND%type default NULL,
     pCOMPEND IN BNF_ENDERECO_BENEF.COMPEND%type default NULL	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ENDERECO_BENEF_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO BNF_ENDERECO_BENEF
    (
       CODCON,
       CODEST,
       CODBEN,
       CODCID,
       ENDBEN,
       BAIBEN,
       UFBEN,
       OBS,
       CEPBEN,
       TELBEN,
       DDDBEN,
       TELBEN1,
       DDDBEN1,
       TELBEN2,
       DDDBEN2,
       EMAIL,
       NUMEND,
       COMPEND
    )
    VALUES
    (
	     pCODCON,
	     pCODEST,
	     pCODBEN,
	     pCODCID,
	     pENDBEN,
	     pBAIBEN,
	     pUFBEN,
	     pOBS,
	     pCEPBEN,
	     pTELBEN,
	     pDDDBEN,
	     pTELBEN1,
	     pDDDBEN1,
	     pTELBEN2,
	     pDDDBEN2,
	     pEMAIL,
	     pNUMEND,
	     pCOMPEND
    );
	
  end PRC_ENDERECO_BENEF_I;

