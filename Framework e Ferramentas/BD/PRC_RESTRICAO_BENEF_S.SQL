 
  --PRC_RESTRICAO_BENEF_S
  create or replace procedure PRC_RESTRICAO_BENEF_S 
  (
     pCODCON IN BNF_RESTRICAO_BENEF.CODCON%type DEFAULT NULL,
     pCODEST IN BNF_RESTRICAO_BENEF.CODEST%type DEFAULT NULL,
     pCODBEN IN BNF_RESTRICAO_BENEF.CODBEN%type DEFAULT NULL,
     pCODSEQBEN IN BNF_RESTRICAO_BENEF.CODSEQBEN%type DEFAULT NULL,
     pCD_RESTRICAO IN BNF_RESTRICAO_BENEF.CD_RESTRICAO%type DEFAULT NULL,
     pDT_RESTRICAO IN BNF_RESTRICAO_BENEF.DT_RESTRICAO%type DEFAULT NULL,
     pHR_RESTRICAO IN BNF_RESTRICAO_BENEF.HR_RESTRICAO%type DEFAULT NULL,
     pDT_LIBERACAO IN BNF_RESTRICAO_BENEF.DT_LIBERACAO%type DEFAULT NULL,
     pHR_LIBERACAO IN BNF_RESTRICAO_BENEF.HR_LIBERACAO%type DEFAULT NULL,
     pNM_RESTRICAO IN BNF_RESTRICAO_BENEF.NM_RESTRICAO%type DEFAULT NULL,
     pNM_LIBERACAO IN BNF_RESTRICAO_BENEF.NM_LIBERACAO%type DEFAULT NULL,
     pOBS IN BNF_RESTRICAO_BENEF.OBS%type DEFAULT NULL,
     pDATVENPAG IN BNF_RESTRICAO_BENEF.DATVENPAG%type DEFAULT NULL,
     pOBSLIB IN BNF_RESTRICAO_BENEF.OBSLIB%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_RESTRICAO_BENEF_S
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
       CD_RESTRICAO,
       DT_RESTRICAO,
       HR_RESTRICAO,
       DT_LIBERACAO,
       HR_LIBERACAO,
       NM_RESTRICAO,
       NM_LIBERACAO,
       OBS,
       DATVENPAG,
       OBSLIB
    FROM BNF_RESTRICAO_BENEF
    WHERE
        (pCODCON is null OR CODCON = pCODCON) AND 
        (pCODEST is null OR CODEST = pCODEST) AND 
        (pCODBEN is null OR CODBEN = pCODBEN) AND 
        (pCODSEQBEN is null OR CODSEQBEN = pCODSEQBEN) AND 
        (pCD_RESTRICAO is null OR CD_RESTRICAO = pCD_RESTRICAO) AND 
        (pDT_RESTRICAO is null OR DT_RESTRICAO = pDT_RESTRICAO) AND 
        (pHR_RESTRICAO is null OR HR_RESTRICAO = pHR_RESTRICAO) AND 
        (pDT_LIBERACAO is null OR DT_LIBERACAO = pDT_LIBERACAO) AND 
        (pHR_LIBERACAO is null OR HR_LIBERACAO = pHR_LIBERACAO) AND 
        (pNM_RESTRICAO is null OR NM_RESTRICAO = pNM_RESTRICAO) AND 
        (pNM_LIBERACAO is null OR NM_LIBERACAO = pNM_LIBERACAO) AND 
        (pOBS is null OR OBS = pOBS) AND 
        (pDATVENPAG is null OR DATVENPAG = pDATVENPAG) AND 
        (pOBSLIB is null OR OBSLIB = pOBSLIB);          
    io_cursor := v_cursor;
  end PRC_RESTRICAO_BENEF_S;
