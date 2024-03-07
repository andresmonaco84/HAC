

  --PRC_RESTRICAO_BENEF_D
  create or replace procedure PRC_RESTRICAO_BENEF_D 
  (
     pCD_RESTRICAO IN BNF_RESTRICAO_BENEF.CD_RESTRICAO%type,
     pCODBEN IN BNF_RESTRICAO_BENEF.CODBEN%type,
     pCODCON IN BNF_RESTRICAO_BENEF.CODCON%type,
     pCODEST IN BNF_RESTRICAO_BENEF.CODEST%type,
     pCODSEQBEN IN BNF_RESTRICAO_BENEF.CODSEQBEN%type,
     pDT_RESTRICAO IN BNF_RESTRICAO_BENEF.DT_RESTRICAO%type,
     pHR_RESTRICAO IN BNF_RESTRICAO_BENEF.HR_RESTRICAO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_RESTRICAO_BENEF_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE BNF_RESTRICAO_BENEF
    WHERE  
        CD_RESTRICAO = pCD_RESTRICAO
    AND CODBEN = pCODBEN
    AND CODCON = pCODCON
    AND CODEST = pCODEST
    AND CODSEQBEN = pCODSEQBEN
    AND DT_RESTRICAO = pDT_RESTRICAO
    AND HR_RESTRICAO = pHR_RESTRICAO;	   
  end PRC_RESTRICAO_BENEF_D;
