 
  --PRC__ENDERECO_BENEF_S
  create or replace procedure PRC_ENDERECO_BENEF_S 
  (
     pCODCON IN BNF_ENDERECO_BENEF.CODCON%type DEFAULT NULL,
     pCODEST IN BNF_ENDERECO_BENEF.CODEST%type DEFAULT NULL,
     pCODBEN IN BNF_ENDERECO_BENEF.CODBEN%type DEFAULT NULL,
     pCODCID IN BNF_ENDERECO_BENEF.CODCID%type DEFAULT NULL,
     pENDBEN IN BNF_ENDERECO_BENEF.ENDBEN%type DEFAULT NULL,
     pBAIBEN IN BNF_ENDERECO_BENEF.BAIBEN%type DEFAULT NULL,
     pUFBEN IN BNF_ENDERECO_BENEF.UFBEN%type DEFAULT NULL,
     pOBS IN BNF_ENDERECO_BENEF.OBS%type DEFAULT NULL,
     pCEPBEN IN BNF_ENDERECO_BENEF.CEPBEN%type DEFAULT NULL,
     pTELBEN IN BNF_ENDERECO_BENEF.TELBEN%type DEFAULT NULL,
     pDDDBEN IN BNF_ENDERECO_BENEF.DDDBEN%type DEFAULT NULL,
     pTELBEN1 IN BNF_ENDERECO_BENEF.TELBEN1%type DEFAULT NULL,
     pDDDBEN1 IN BNF_ENDERECO_BENEF.DDDBEN1%type DEFAULT NULL,
     pTELBEN2 IN BNF_ENDERECO_BENEF.TELBEN2%type DEFAULT NULL,
     pDDDBEN2 IN BNF_ENDERECO_BENEF.DDDBEN2%type DEFAULT NULL,
     pEMAIL IN BNF_ENDERECO_BENEF.EMAIL%type DEFAULT NULL,
     pNUMEND IN BNF_ENDERECO_BENEF.NUMEND%type DEFAULT NULL,
     pCOMPEND IN BNF_ENDERECO_BENEF.COMPEND%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC__ENDERECO_BENEF_S
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
    FROM BNF_ENDERECO_BENEF
    WHERE
        (pCODCON is null OR CODCON = pCODCON) AND 
        (pCODEST is null OR CODEST = pCODEST) AND 
        (pCODBEN is null OR CODBEN = pCODBEN) AND 
        (pCODCID is null OR CODCID = pCODCID) AND 
        (pENDBEN is null OR ENDBEN = pENDBEN) AND 
        (pBAIBEN is null OR BAIBEN = pBAIBEN) AND 
        (pUFBEN is null OR UFBEN = pUFBEN) AND 
        (pOBS is null OR OBS = pOBS) AND 
        (pCEPBEN is null OR CEPBEN = pCEPBEN) AND 
        (pTELBEN is null OR TELBEN = pTELBEN) AND 
        (pDDDBEN is null OR DDDBEN = pDDDBEN) AND 
        (pTELBEN1 is null OR TELBEN1 = pTELBEN1) AND 
        (pDDDBEN1 is null OR DDDBEN1 = pDDDBEN1) AND 
        (pTELBEN2 is null OR TELBEN2 = pTELBEN2) AND 
        (pDDDBEN2 is null OR DDDBEN2 = pDDDBEN2) AND 
        (pEMAIL is null OR EMAIL = pEMAIL) AND 
        (pNUMEND is null OR NUMEND = pNUMEND) AND 
        (pCOMPEND is null OR COMPEND = pCOMPEND);          
    io_cursor := v_cursor;
  end PRC_ENDERECO_BENEF_S;
