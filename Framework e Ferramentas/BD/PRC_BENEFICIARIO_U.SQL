  create or replace procedure PRC_BENEFICIARIO_U
  (
     pCODCON IN BNF_BENEFICIARIO.CODCON%type,
     pCODEST IN BNF_BENEFICIARIO.CODEST%type,
     pCODBEN IN BNF_BENEFICIARIO.CODBEN%type,
     pCODSEQBEN IN BNF_BENEFICIARIO.CODSEQBEN%type,
     pNOMBEN IN BNF_BENEFICIARIO.NOMBEN%type,
     pCODPADATEBEN IN BNF_BENEFICIARIO.CODPADATEBEN%type,
     pCODINDBEN IN BNF_BENEFICIARIO.CODINDBEN%type,
     pSEXBEN IN BNF_BENEFICIARIO.SEXBEN%type,
     pESTCIVBEN IN BNF_BENEFICIARIO.ESTCIVBEN%type default NULL,
     pDATNASBEN IN BNF_BENEFICIARIO.DATNASBEN%type,
     pCODSITBEN IN BNF_BENEFICIARIO.CODSITBEN%type,
     pCPFBEN IN BNF_BENEFICIARIO.CPFBEN%type default NULL,
     pRGBEN IN BNF_BENEFICIARIO.RGBEN%type default NULL,
     pMAEBEN IN BNF_BENEFICIARIO.MAEBEN%type default NULL,
     pID_REPASSE IN BNF_BENEFICIARIO.ID_REPASSE%type default NULL,
     pIND_ACIDENTE_TRABALHO IN BNF_BENEFICIARIO.IND_ACIDENTE_TRABALHO%type default NULL,
     pCODPAC IN BNF_BENEFICIARIO.CODPAC%type default NULL,
     pCD_EMPRESA IN BNF_BENEFICIARIO.CD_EMPRESA%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_BENEFICIARIO_U
  * 
  *    Data Criacao: 	08/08/2008   Por: Andrea Cazuca
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Grava Beneficiario 
  *
  *******************************************************************/  
  begin
    UPDATE BNF_BENEFICIARIO
    SET	   
        NOMBEN = pNOMBEN,
        CODINDBEN = pCODINDBEN,
        SEXBEN = pSEXBEN,
        ESTCIVBEN = pESTCIVBEN,
        DATNASBEN = pDATNASBEN,
        CODSITBEN = pCODSITBEN,
        CPFBEN = pCPFBEN,
        RGBEN = pRGBEN,
        MAEBEN = pMAEBEN,
        ID_REPASSE = pID_REPASSE,
        IND_ACIDENTE_TRABALHO = pIND_ACIDENTE_TRABALHO,
        CODPAC = pCODPAC
    WHERE
    CODBEN = pCODBEN
    AND CODCON = pCODCON
    AND CODEST = pCODEST
    AND CODSEQBEN = pCODSEQBEN;	
  end PRC_BENEFICIARIO_U;
/
