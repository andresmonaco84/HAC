create or replace procedure PRC_BENEF_ACS_S
  (
     pCODCON IN BNF_BENEFICIARIO.CODCON%type DEFAULT NULL,
     pCODEST IN BNF_BENEFICIARIO.CODEST%type DEFAULT NULL,
     pCODBEN IN BNF_BENEFICIARIO.CODBEN%type DEFAULT NULL,
     pCODSEQBEN IN BNF_BENEFICIARIO.CODSEQBEN%type DEFAULT NULL,
     pNOMBEN IN BNF_BENEFICIARIO.NOMBEN%type DEFAULT NULL,
     pCODPADATEBEN IN BNF_BENEFICIARIO.CODPADATEBEN%type DEFAULT NULL,
     pCODPADCOBBEN IN BNF_BENEFICIARIO.CODPADCOBBEN%type DEFAULT NULL,
     pCODINDBEN IN BNF_BENEFICIARIO.CODINDBEN%type DEFAULT NULL,
     pSEXBEN IN BNF_BENEFICIARIO.SEXBEN%type DEFAULT NULL,
     pCODGRAPAR IN BNF_BENEFICIARIO.CODGRAPAR%type DEFAULT NULL,
     pESTCIVBEN IN BNF_BENEFICIARIO.ESTCIVBEN%type DEFAULT NULL,
     pDATNASBEN IN BNF_BENEFICIARIO.DATNASBEN%type DEFAULT NULL,
     pDATINGCONBEN IN BNF_BENEFICIARIO.DATINGCONBEN%type DEFAULT NULL,
     pDATADMEMP IN BNF_BENEFICIARIO.DATADMEMP%type DEFAULT NULL,
     pDATSAICONBEN IN BNF_BENEFICIARIO.DATSAICONBEN%type DEFAULT NULL,
     pOCUEMPBEN IN BNF_BENEFICIARIO.OCUEMPBEN%type DEFAULT NULL,
     pCARPROBEN IN BNF_BENEFICIARIO.CARPROBEN%type DEFAULT NULL,
     pCODSITBEN IN BNF_BENEFICIARIO.CODSITBEN%type DEFAULT NULL,
     pDATLIMBEN IN BNF_BENEFICIARIO.DATLIMBEN%type DEFAULT NULL,
     pDATSITBEN IN BNF_BENEFICIARIO.DATSITBEN%type DEFAULT NULL,
     pCPFBEN IN BNF_BENEFICIARIO.CPFBEN%type DEFAULT NULL,
     pRGBEN IN BNF_BENEFICIARIO.RGBEN%type DEFAULT NULL,
     pCODACO IN BNF_BENEFICIARIO.CODACO%type DEFAULT NULL,
     pCODPLA IN BNF_BENEFICIARIO.CODPLA%type DEFAULT NULL,
     pVALCOB IN BNF_BENEFICIARIO.VALCOB%type DEFAULT NULL,
     pCODTIPPAD IN BNF_BENEFICIARIO.CODTIPPAD%type DEFAULT NULL,
     pDATEMIEXC IN BNF_BENEFICIARIO.DATEMIEXC%type DEFAULT NULL,
     pSITATI IN BNF_BENEFICIARIO.SITATI%type DEFAULT NULL,
     pCODTIPCARBEN IN BNF_BENEFICIARIO.CODTIPCARBEN%type DEFAULT NULL,
     pINDPAG IN BNF_BENEFICIARIO.INDPAG%type DEFAULT NULL,
     pDT_ATU_INDPAG IN BNF_BENEFICIARIO.DT_ATU_INDPAG%type DEFAULT NULL,
     pIND_NEGOCIACAO IN BNF_BENEFICIARIO.IND_NEGOCIACAO%type DEFAULT NULL,
     pDATFATOD IN BNF_BENEFICIARIO.DATFATOD%type DEFAULT NULL,
     pIDADEBEN IN BNF_BENEFICIARIO.IDADEBEN%type DEFAULT NULL,
     pMAEBEN IN BNF_BENEFICIARIO.MAEBEN%type DEFAULT NULL,
     pCANC_ANS IN BNF_BENEFICIARIO.CANC_ANS%type DEFAULT NULL,
     pID_AUTORIZACAO_ANS IN BNF_BENEFICIARIO.ID_AUTORIZACAO_ANS%type DEFAULT NULL,
     pVLPERC IN BNF_BENEFICIARIO.VLPERC%type DEFAULT NULL,
     pCODPRO IN BNF_BENEFICIARIO.CODPRO%type DEFAULT NULL,
     pDATALTBEN IN BNF_BENEFICIARIO.DATALTBEN%type DEFAULT NULL,
     pCD_EMPRESA IN BNF_BENEFICIARIO.CD_EMPRESA%type DEFAULT NULL,
     pID_COPART_EXAME IN BNF_BENEFICIARIO.ID_COPART_EXAME%type DEFAULT NULL,
     pID_COPART_CONSULTA IN BNF_BENEFICIARIO.ID_COPART_CONSULTA%type DEFAULT NULL,
     pID_CRONICO IN BNF_BENEFICIARIO.ID_CRONICO%type DEFAULT NULL,
     pCO_PART IN BNF_BENEFICIARIO.CO_PART%type DEFAULT NULL,
     pID_EMISSAO_CARTEIRINHA IN BNF_BENEFICIARIO.ID_EMISSAO_CARTEIRINHA%type DEFAULT NULL,
     pVL_COBRANCA_ATUAL IN BNF_BENEFICIARIO.VL_COBRANCA_ATUAL%type DEFAULT NULL,
     pDT_COBRANCA_ATUAL IN BNF_BENEFICIARIO.DT_COBRANCA_ATUAL%type DEFAULT NULL,
     pDT_REF_COBRANCA_ATUAL IN BNF_BENEFICIARIO.DT_REF_COBRANCA_ATUAL%type DEFAULT NULL,
     pDT_EMISSAO_CARTEIRINHA IN BNF_BENEFICIARIO.DT_EMISSAO_CARTEIRINHA%type DEFAULT NULL,
     pID_CONTENCIOSO IN BNF_BENEFICIARIO.ID_CONTENCIOSO%type DEFAULT NULL,
     pDS_CONTENCIOSO IN BNF_BENEFICIARIO.DS_CONTENCIOSO%type DEFAULT NULL,
     pID_SUSPENSAO_BOLETO IN BNF_BENEFICIARIO.ID_SUSPENSAO_BOLETO%type DEFAULT NULL,
     pID_DOENTE_CRONICO IN BNF_BENEFICIARIO.ID_DOENTE_CRONICO%type DEFAULT NULL,
     pCD_CID_CRONICO IN BNF_BENEFICIARIO.CD_CID_CRONICO%type DEFAULT NULL,
     pID_REPASSE IN BNF_BENEFICIARIO.ID_REPASSE%type DEFAULT NULL,
     pDT_EXCLUSAO_FATURA IN BNF_BENEFICIARIO.DT_EXCLUSAO_FATURA%type DEFAULT NULL,
     pCD_LOCAL_REPASSE IN BNF_BENEFICIARIO.CD_LOCAL_REPASSE%type DEFAULT NULL,
     pID_PAC IN BNF_BENEFICIARIO.ID_PAC%type DEFAULT NULL,
     pID_CURATIVO IN BNF_BENEFICIARIO.ID_CURATIVO%type DEFAULT NULL,
     pDT_INI_CURATIVO IN BNF_BENEFICIARIO.DT_INI_CURATIVO%type DEFAULT NULL,
     pID_HOMECARE IN BNF_BENEFICIARIO.ID_HOMECARE%type DEFAULT NULL,
     pDT_INI_HOMECARE IN BNF_BENEFICIARIO.DT_INI_HOMECARE%type DEFAULT NULL,
     pID_MEDFAMILIA IN BNF_BENEFICIARIO.ID_MEDFAMILIA%type DEFAULT NULL,
     pDT_INI_MEDFAMILIA IN BNF_BENEFICIARIO.DT_INI_MEDFAMILIA%type DEFAULT NULL,
     pID_SEGURO_REMISSAO IN BNF_BENEFICIARIO.ID_SEGURO_REMISSAO%type DEFAULT NULL,
     pID_PLANO_BEM IN BNF_BENEFICIARIO.ID_PLANO_BEM%type DEFAULT NULL,
     pDT_INI_CRONICO IN BNF_BENEFICIARIO.DT_INI_CRONICO%type DEFAULT NULL,
     pDT_INI_PLANO_BEM IN BNF_BENEFICIARIO.DT_INI_PLANO_BEM%type DEFAULT NULL,
     pDT_INICIO_REPASSE IN BNF_BENEFICIARIO.DT_INICIO_REPASSE%type DEFAULT NULL,
     pDT_FINAL_REPASSE IN BNF_BENEFICIARIO.DT_FINAL_REPASSE%type DEFAULT NULL,
     pCD_EMPRESA_REPASSE IN BNF_BENEFICIARIO.CD_EMPRESA_REPASSE%type DEFAULT NULL,
     pDS_LOCALIDADE IN BNF_BENEFICIARIO.DS_LOCALIDADE%type DEFAULT NULL,
     pID_EMPRESA_REPASSADA IN BNF_BENEFICIARIO.ID_EMPRESA_REPASSADA%type DEFAULT NULL,
     pDT_FIM_PLANO_BEM IN BNF_BENEFICIARIO.DT_FIM_PLANO_BEM%type DEFAULT NULL,
     pCD_PLANO_BEM IN BNF_BENEFICIARIO.CD_PLANO_BEM%type DEFAULT NULL,
     pID_ACESSORIO IN BNF_BENEFICIARIO.ID_ACESSORIO%type DEFAULT NULL,
     pCODNAC IN BNF_BENEFICIARIO.CODNAC%type DEFAULT NULL,
     pCODPAIS IN BNF_BENEFICIARIO.CODPAIS%type DEFAULT NULL,
     pORGAO_EMISSOR_RG IN BNF_BENEFICIARIO.ORGAO_EMISSOR_RG%type DEFAULT NULL,
     pPAIS_EMISSOR_RG IN BNF_BENEFICIARIO.PAIS_EMISSOR_RG%type DEFAULT NULL,
     pPISPASEP IN BNF_BENEFICIARIO.PISPASEP%type DEFAULT NULL,
     pIND_ACIDENTE_TRABALHO IN BNF_BENEFICIARIO.IND_ACIDENTE_TRABALHO%type DEFAULT NULL,
     pCODPAC IN BNF_BENEFICIARIO.CODPAC%type DEFAULT NULL,
     pDOCBEN IN BNF_BENEFICIARIO.DOCBEN%type DEFAULT NULL,
     pCOD_NATDOC IN BNF_BENEFICIARIO.COD_NATDOC%type DEFAULT NULL,
     pDT_EXPEDOC IN BNF_BENEFICIARIO.DT_EXPEDOC%type DEFAULT NULL,
     pCOD_ATIVPRINC IN BNF_BENEFICIARIO.COD_ATIVPRINC%type DEFAULT NULL,
     pIDOPER IN BNF_BENEFICIARIO.IDOPER%type DEFAULT NULL,
     pID_CARTAO_AUTORIZADOR IN BNF_BENEFICIARIO.ID_CARTAO_AUTORIZADOR%type DEFAULT NULL,
     pDT_CARTAO_AUTORIZADOR IN BNF_BENEFICIARIO.DT_CARTAO_AUTORIZADOR%type DEFAULT NULL,
     pNM_REDUZIDO IN BNF_BENEFICIARIO.NM_REDUZIDO%type DEFAULT NULL,
     pDS_LOGIN IN BNF_BENEFICIARIO.DS_LOGIN%type DEFAULT NULL,
     pCD_CCO IN BNF_BENEFICIARIO.CD_CCO%type DEFAULT NULL,
     pDV_CCO IN BNF_BENEFICIARIO.DV_CCO%type DEFAULT NULL,
     pCDPLANOANS_ORIGEM IN BNF_BENEFICIARIO.CDPLANOANS_ORIGEM%type DEFAULT NULL,
     pSITUACAO BNF_SITUACAO_BENEF.SITATI%type DEFAULT NULL,
     pINCLUIR_HOMECARE IN DECIMAL DEFAULT NULL,  -- Verifica se n�o existe na tabela TB_BNF_HOMECARE
     pEXISTE_HOMECARE  IN DECIMAL DEFAULT NULL,  -- Verifica se existe na tabela TB_BNF_HOMECARE
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC__BENEFICIARIO_S
  * 
  *    Data Criacao: 	data da  cria��o   Por: Nome do Analista
  *    Data Alteracao:	data da altera��o  Por: Nome do Analista
  *
  *    Funcao: Descri��o da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       DECODE(CODCON, 'GG05', 'GG05', 'SD01') CODCON,
       CODCON CODPLA,
       CODEST,
       CODBEN,
       CODSEQBEN,
       NOMBEN,
       CODPADATEBEN,
       CODPADCOBBEN,
       CODINDBEN,
       SEXBEN,
       CODGRAPAR,
       ESTCIVBEN,
       DATNASBEN,
       DATINGCONBEN,
       DATADMEMP,
       DATSAICONBEN,
       OCUEMPBEN,
       CARPROBEN,
       BNF.CODSITBEN,
       DATLIMBEN,
       DATSITBEN,
       CPFBEN,
       RGBEN,
       CODACO,
       CODPLA,
       VALCOB,
       CODTIPPAD,
       DATEMIEXC,
       BNF.SITATI,
       CODTIPCARBEN,
       INDPAG,
       DT_ATU_INDPAG,
       IND_NEGOCIACAO,
       DATFATOD,
       IDADEBEN,
       MAEBEN,
       CANC_ANS,
       ID_AUTORIZACAO_ANS,
       VLPERC,
       CODPRO,
       DATALTBEN,
       CD_EMPRESA,
       ID_COPART_EXAME,
       ID_COPART_CONSULTA,
       ID_CRONICO,
       CO_PART,
       ID_EMISSAO_CARTEIRINHA,
       VL_COBRANCA_ATUAL,
       DT_COBRANCA_ATUAL,
       DT_REF_COBRANCA_ATUAL,
       DT_EMISSAO_CARTEIRINHA,
       ID_CONTENCIOSO,
       DS_CONTENCIOSO,
       ID_SUSPENSAO_BOLETO,
       ID_DOENTE_CRONICO,
       CD_CID_CRONICO,
       ID_REPASSE,
       DT_EXCLUSAO_FATURA,
       CD_LOCAL_REPASSE,
       ID_PAC,
       ID_CURATIVO,
       DT_INI_CURATIVO,
       ID_HOMECARE,
       DT_INI_HOMECARE,
       ID_MEDFAMILIA,
       DT_INI_MEDFAMILIA,
       ID_SEGURO_REMISSAO,
       ID_PLANO_BEM,
       DT_INI_CRONICO,
       DT_INI_PLANO_BEM,
       DT_INICIO_REPASSE,
       DT_FINAL_REPASSE,
       CD_EMPRESA_REPASSE,
       DS_LOCALIDADE,
       ID_EMPRESA_REPASSADA,
       DT_FIM_PLANO_BEM,
       CD_PLANO_BEM,
       ID_ACESSORIO,
       CODNAC,
       CODPAIS,
       ORGAO_EMISSOR_RG,
       PAIS_EMISSOR_RG,
       PISPASEP,
       IND_ACIDENTE_TRABALHO,
       CODPAC,
       DOCBEN,
       COD_NATDOC,
       DT_EXPEDOC,
       COD_ATIVPRINC,
       IDOPER,
       ID_CARTAO_AUTORIZADOR,
       DT_CARTAO_AUTORIZADOR,
       NM_REDUZIDO,
       DS_LOGIN,
       CD_CCO,
       DV_CCO,
       CDPLANOANS_ORIGEM,
       LPAD(CODEST,3,'0') || LPAD(CODBEN,7,'0') || LPAD(CODSEQBEN,2,'0') CREDENCIAL,
       CONVENIO.CAD_CNV_NM_FANTASIA
    FROM BNF_BENEFICIARIO BNF,
         TB_CAD_PLA_PLANO PLANO,
         TB_CAD_CNV_CONVENIO CONVENIO
         --BNF_SITUACAO_BENEF SIT
    WHERE
         --BNF.CODSITBEN = SIT.CODSITBEN(+) AND
         PLANO.CAD_CNV_ID_CONVENIO = CONVENIO.CAD_CNV_ID_CONVENIO AND
         PLANO.CAD_PLA_CD_PLANO = BNF.CODCON  AND
        (pCODCON is null OR CODCON = pCODCON) AND 
        (pCODEST is null OR CODEST = pCODEST) AND 
        (pCODBEN is null OR CODBEN = pCODBEN) AND 
        (pCODSEQBEN is null OR CODSEQBEN = pCODSEQBEN) AND 
        --(pNOMBEN ||'%' is null OR NOMBEN like pNOMBEN ||'%') AND 
        (pNOMBEN is null OR NOMBEN like '%' || pNOMBEN ||'%') AND 
        (pCODPADATEBEN is null OR CODPADATEBEN = pCODPADATEBEN) AND 
        (pCODPADCOBBEN is null OR CODPADCOBBEN = pCODPADCOBBEN) AND 
        (pCODINDBEN is null OR CODINDBEN = pCODINDBEN) AND 
        (pSEXBEN is null OR SEXBEN = pSEXBEN) AND 
        (pCODGRAPAR is null OR CODGRAPAR = pCODGRAPAR) AND 
        (pESTCIVBEN is null OR ESTCIVBEN = pESTCIVBEN) AND 
        (pDATNASBEN is null OR DATNASBEN = pDATNASBEN) AND 
        (pDATINGCONBEN is null OR DATINGCONBEN = pDATINGCONBEN) AND 
        (pDATADMEMP is null OR DATADMEMP = pDATADMEMP) AND 
        (pDATSAICONBEN is null OR DATSAICONBEN = pDATSAICONBEN) AND 
        (pOCUEMPBEN is null OR OCUEMPBEN = pOCUEMPBEN) AND 
        (pCARPROBEN is null OR CARPROBEN = pCARPROBEN) AND 
        (pCODSITBEN is null OR BNF.CODSITBEN = pCODSITBEN) AND 
        (pDATLIMBEN is null OR DATLIMBEN = pDATLIMBEN) AND 
        (pDATSITBEN is null OR DATSITBEN = pDATSITBEN) AND 
        (pCPFBEN is null OR CPFBEN = pCPFBEN) AND 
        (pRGBEN is null OR RGBEN = pRGBEN) AND 
        (pCODACO is null OR CODACO = pCODACO) AND 
        (pCODPLA is null OR CODPLA = pCODPLA) AND 
        (pVALCOB is null OR VALCOB = pVALCOB) AND 
        (pCODTIPPAD is null OR CODTIPPAD = pCODTIPPAD) AND 
        (pDATEMIEXC is null OR DATEMIEXC = pDATEMIEXC) AND 
        (pSITATI is null OR BNF.SITATI = pSITATI) AND 
        (pCODTIPCARBEN is null OR CODTIPCARBEN = pCODTIPCARBEN) AND 
        (pINDPAG is null OR INDPAG = pINDPAG) AND 
        (pDT_ATU_INDPAG is null OR DT_ATU_INDPAG = pDT_ATU_INDPAG) AND 
        (pIND_NEGOCIACAO is null OR IND_NEGOCIACAO = pIND_NEGOCIACAO) AND 
        (pDATFATOD is null OR DATFATOD = pDATFATOD) AND 
        (pIDADEBEN is null OR IDADEBEN = pIDADEBEN) AND 
        (pMAEBEN is null OR MAEBEN = pMAEBEN) AND 
        (pCANC_ANS is null OR CANC_ANS = pCANC_ANS) AND 
        (pID_AUTORIZACAO_ANS is null OR ID_AUTORIZACAO_ANS = pID_AUTORIZACAO_ANS) AND 
        (pVLPERC is null OR VLPERC = pVLPERC) AND 
        (pCODPRO is null OR CODPRO = pCODPRO) AND 
        (pDATALTBEN is null OR DATALTBEN = pDATALTBEN) AND 
        (pCD_EMPRESA is null OR CD_EMPRESA = pCD_EMPRESA) AND 
        (pID_COPART_EXAME is null OR ID_COPART_EXAME = pID_COPART_EXAME) AND 
        (pID_COPART_CONSULTA is null OR ID_COPART_CONSULTA = pID_COPART_CONSULTA) AND 
        (pID_CRONICO is null OR ID_CRONICO = pID_CRONICO) AND 
        (pCO_PART is null OR CO_PART = pCO_PART) AND 
        (pID_EMISSAO_CARTEIRINHA is null OR ID_EMISSAO_CARTEIRINHA = pID_EMISSAO_CARTEIRINHA) AND 
        (pVL_COBRANCA_ATUAL is null OR VL_COBRANCA_ATUAL = pVL_COBRANCA_ATUAL) AND 
        (pDT_COBRANCA_ATUAL is null OR DT_COBRANCA_ATUAL = pDT_COBRANCA_ATUAL) AND 
        (pDT_REF_COBRANCA_ATUAL is null OR DT_REF_COBRANCA_ATUAL = pDT_REF_COBRANCA_ATUAL) AND 
        (pDT_EMISSAO_CARTEIRINHA is null OR DT_EMISSAO_CARTEIRINHA = pDT_EMISSAO_CARTEIRINHA) AND 
        (pID_CONTENCIOSO is null OR ID_CONTENCIOSO = pID_CONTENCIOSO) AND 
        (pDS_CONTENCIOSO is null OR DS_CONTENCIOSO = pDS_CONTENCIOSO) AND 
        (pID_SUSPENSAO_BOLETO is null OR ID_SUSPENSAO_BOLETO = pID_SUSPENSAO_BOLETO) AND 
        (pID_DOENTE_CRONICO is null OR ID_DOENTE_CRONICO = pID_DOENTE_CRONICO) AND 
        (pCD_CID_CRONICO is null OR CD_CID_CRONICO = pCD_CID_CRONICO) AND 
        (pID_REPASSE is null OR ID_REPASSE = pID_REPASSE) AND 
        (pDT_EXCLUSAO_FATURA is null OR DT_EXCLUSAO_FATURA = pDT_EXCLUSAO_FATURA) AND 
        (pCD_LOCAL_REPASSE is null OR CD_LOCAL_REPASSE = pCD_LOCAL_REPASSE) AND 
        (pID_PAC is null OR ID_PAC = pID_PAC) AND 
        (pID_CURATIVO is null OR ID_CURATIVO = pID_CURATIVO) AND 
        (pDT_INI_CURATIVO is null OR DT_INI_CURATIVO = pDT_INI_CURATIVO) AND 
        (pID_HOMECARE is null OR ID_HOMECARE = pID_HOMECARE) AND 
        (pDT_INI_HOMECARE is null OR DT_INI_HOMECARE = pDT_INI_HOMECARE) AND 
        (pID_MEDFAMILIA is null OR ID_MEDFAMILIA = pID_MEDFAMILIA) AND 
        (pDT_INI_MEDFAMILIA is null OR DT_INI_MEDFAMILIA = pDT_INI_MEDFAMILIA) AND 
        (pID_SEGURO_REMISSAO is null OR ID_SEGURO_REMISSAO = pID_SEGURO_REMISSAO) AND 
        (pID_PLANO_BEM is null OR ID_PLANO_BEM = pID_PLANO_BEM) AND 
        (pDT_INI_CRONICO is null OR DT_INI_CRONICO = pDT_INI_CRONICO) AND 
        (pDT_INI_PLANO_BEM is null OR DT_INI_PLANO_BEM = pDT_INI_PLANO_BEM) AND 
        (pDT_INICIO_REPASSE is null OR DT_INICIO_REPASSE = pDT_INICIO_REPASSE) AND 
        (pDT_FINAL_REPASSE is null OR DT_FINAL_REPASSE = pDT_FINAL_REPASSE) AND 
        (pCD_EMPRESA_REPASSE is null OR CD_EMPRESA_REPASSE = pCD_EMPRESA_REPASSE) AND 
        (pDS_LOCALIDADE is null OR DS_LOCALIDADE = pDS_LOCALIDADE) AND 
        (pID_EMPRESA_REPASSADA is null OR ID_EMPRESA_REPASSADA = pID_EMPRESA_REPASSADA) AND 
        (pDT_FIM_PLANO_BEM is null OR DT_FIM_PLANO_BEM = pDT_FIM_PLANO_BEM) AND 
        (pCD_PLANO_BEM is null OR CD_PLANO_BEM = pCD_PLANO_BEM) AND 
        (pID_ACESSORIO is null OR ID_ACESSORIO = pID_ACESSORIO) AND 
        (pCODNAC is null OR CODNAC = pCODNAC) AND 
        (pCODPAIS is null OR CODPAIS = pCODPAIS) AND 
        (pORGAO_EMISSOR_RG is null OR ORGAO_EMISSOR_RG = pORGAO_EMISSOR_RG) AND 
        (pPAIS_EMISSOR_RG is null OR PAIS_EMISSOR_RG = pPAIS_EMISSOR_RG) AND 
        (pPISPASEP is null OR PISPASEP = pPISPASEP) AND 
        (pIND_ACIDENTE_TRABALHO is null OR IND_ACIDENTE_TRABALHO = pIND_ACIDENTE_TRABALHO) AND 
        (pCODPAC is null OR CODPAC = pCODPAC) AND 
        (pDOCBEN is null OR DOCBEN = pDOCBEN) AND 
        (pCOD_NATDOC is null OR COD_NATDOC = pCOD_NATDOC) AND 
        (pDT_EXPEDOC is null OR DT_EXPEDOC = pDT_EXPEDOC) AND 
        (pCOD_ATIVPRINC is null OR COD_ATIVPRINC = pCOD_ATIVPRINC) AND 
        (pIDOPER is null OR IDOPER = pIDOPER) AND 
        (pID_CARTAO_AUTORIZADOR is null OR ID_CARTAO_AUTORIZADOR = pID_CARTAO_AUTORIZADOR) AND 
        (pDT_CARTAO_AUTORIZADOR is null OR DT_CARTAO_AUTORIZADOR = pDT_CARTAO_AUTORIZADOR) AND 
        (pNM_REDUZIDO is null OR NM_REDUZIDO = pNM_REDUZIDO) AND 
        (pDS_LOGIN is null OR DS_LOGIN = pDS_LOGIN) AND 
        (pCD_CCO is null OR CD_CCO = pCD_CCO) AND 
        (pDV_CCO is null OR DV_CCO = pDV_CCO) AND 
        (pCDPLANOANS_ORIGEM is null OR CDPLANOANS_ORIGEM = pCDPLANOANS_ORIGEM) AND
        --(pSITUACAO is null OR SIT.SITATI = pSITUACAO) AND
        (pSITUACAO is null OR BNF.SITATI = pSITUACAO) AND
        (pINCLUIR_HOMECARE is null OR NOT EXISTS       
                                          (SELECT BHC.BNF_COD_PLANO
                                           FROM TB_BNF_HOMECARE BHC
                                           WHERE BHC.BNF_COD_PLANO = BNF.CODCON AND BHC.BNF_LOJA_ID = BNF.CODEST AND 
                                                 BHC.BNF_BEN_ID = BNF.CODBEN AND
                                                 BHC.BNF_COD_SEQ = BNF.CODSEQBEN)) AND
        (pEXISTE_HOMECARE is null OR EXISTS       
                                     (SELECT BHC.BNF_COD_PLANO
                                      FROM TB_BNF_HOMECARE BHC
                                      WHERE BHC.BNF_COD_PLANO = BNF.CODCON AND BHC.BNF_LOJA_ID = BNF.CODEST AND 
                                            BHC.BNF_BEN_ID = BNF.CODBEN AND
                                            BHC.BNF_COD_SEQ = BNF.CODSEQBEN))                                                                           
         ORDER BY BNF.NOMBEN, BNF.DATNASBEN;                              
    io_cursor := v_cursor;
  end PRC_BENEF_ACS_S;