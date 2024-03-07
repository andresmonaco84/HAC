

  --PRC_RESTRICAO_BENEF_U
  create or replace procedure PRC_RESTRICAO_BENEF_U
  (
     pCODCON IN BNF_RESTRICAO_BENEF.CODCON%type,
     pCODEST IN BNF_RESTRICAO_BENEF.CODEST%type,
     pCODBEN IN BNF_RESTRICAO_BENEF.CODBEN%type,
     pCODSEQBEN IN BNF_RESTRICAO_BENEF.CODSEQBEN%type,
     pCD_RESTRICAO IN BNF_RESTRICAO_BENEF.CD_RESTRICAO%type,
     pDT_RESTRICAO IN BNF_RESTRICAO_BENEF.DT_RESTRICAO%type,
     pHR_RESTRICAO IN BNF_RESTRICAO_BENEF.HR_RESTRICAO%type,
     pDT_LIBERACAO IN BNF_RESTRICAO_BENEF.DT_LIBERACAO%type default NULL,
     pHR_LIBERACAO IN BNF_RESTRICAO_BENEF.HR_LIBERACAO%type default NULL,
     pNM_RESTRICAO IN BNF_RESTRICAO_BENEF.NM_RESTRICAO%type default NULL,
     pNM_LIBERACAO IN BNF_RESTRICAO_BENEF.NM_LIBERACAO%type default NULL,
     pOBS IN BNF_RESTRICAO_BENEF.OBS%type default NULL,
     pDATVENPAG IN BNF_RESTRICAO_BENEF.DATVENPAG%type default NULL,
     pOBSLIB IN BNF_RESTRICAO_BENEF.OBSLIB%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_RESTRICAO_BENEF_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE BNF_RESTRICAO_BENEF
    SET	   
        DT_LIBERACAO = pDT_LIBERACAO,
        HR_LIBERACAO = pHR_LIBERACAO,
        NM_RESTRICAO = pNM_RESTRICAO,
        NM_LIBERACAO = pNM_LIBERACAO,
        OBS = pOBS,
        DATVENPAG = pDATVENPAG,
        OBSLIB = pOBSLIB 
    WHERE
        CD_RESTRICAO = pCD_RESTRICAO
    AND CODBEN = pCODBEN
    AND CODCON = pCODCON
    AND CODEST = pCODEST
    AND CODSEQBEN = pCODSEQBEN
    AND DT_RESTRICAO = pDT_RESTRICAO
    AND HR_RESTRICAO = pHR_RESTRICAO;	
  end PRC_RESTRICAO_BENEF_U;

