

  --PRC_RESTRICAO_BENEF_I
  create or replace procedure PRC_RESTRICAO_BENEF_I
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
  *    Procedure: PRC_RESTRICAO_BENEF_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO BNF_RESTRICAO_BENEF
    (
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
    )
    VALUES
    (
	     pCODCON,
	     pCODEST,
	     pCODBEN,
	     pCODSEQBEN,
	     pCD_RESTRICAO,
	     pDT_RESTRICAO,
	     pHR_RESTRICAO,
	     pDT_LIBERACAO,
	     pHR_LIBERACAO,
	     pNM_RESTRICAO,
	     pNM_LIBERACAO,
	     pOBS,
	     pDATVENPAG,
	     pOBSLIB
    );
	
  end PRC_RESTRICAO_BENEF_I;

