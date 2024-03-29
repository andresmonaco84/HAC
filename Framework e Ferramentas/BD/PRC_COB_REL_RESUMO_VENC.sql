CREATE OR REPLACE PROCEDURE "PRC_COB_REL_RESUMO_VENC"
  (
    pCAD_UNI_ID_UNIDADE IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
   -- pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
    pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
   -- pCAD_PLA_ID_PLANO    IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE DEFAULT NULL,
        pDATA_EMISSAO_INI IN TB_FAT_NOF_NOTA_FISCAL.FAT_NFO_DT_EMISSAO%TYPE DEFAULT NULL,
    pDATA_EMISSAO_FIM IN TB_FAT_NOF_NOTA_FISCAL.FAT_NFO_DT_EMISSAO%TYPE DEFAULT NULL,
    pDATA_VENCIMENTO_INI IN TB_FAT_NOF_NOTA_FISCAL.FAT_NFO_DT_VENCIMENTO%TYPE DEFAULT NULL,
    pDATA_VENCIMENTO_FIM IN TB_FAT_NOF_NOTA_FISCAL.FAT_NFO_DT_VENCIMENTO%TYPE DEFAULT NULL,
    pDATA_PAGTO_INI  IN TB_COB_MGC_MOV_GUIA_COBRANCA.COB_MGC_DT_MOVIMENTO%TYPE DEFAULT NULL,
    pDATA_PAGTO_FIM  IN TB_COB_MGC_MOV_GUIA_COBRANCA.COB_MGC_DT_MOVIMENTO%TYPE DEFAULT NULL,
    pDATA_CONTAB_INI     IN TB_COB_MGC_MOV_GUIA_COBRANCA.COB_MGC_DT_LIBERACAO_CONTAB%TYPE DEFAULT NULL,
    pDATA_CONTAB_FIM     IN TB_COB_MGC_MOV_GUIA_COBRANCA.COB_MGC_DT_LIBERACAO_CONTAB%TYPE DEFAULT NULL,
    pDATA_MOVIMENTO_FIM  IN TB_COB_MGC_MOV_GUIA_COBRANCA.COB_MGC_DT_MOVIMENTO%TYPE DEFAULT NULL,
    pCAD_BAN_ID          IN TB_CAD_BAN_BANCO.CAD_BAN_ID%TYPE DEFAULT NULL,
    pASS_BCT_ID          IN TB_COB_MGC_MOV_GUIA_COBRANCA.ASS_BCT_ID%TYPE DEFAULT NULL,
    pPENDETE_CONTABILIDADE   VARCHAR2 DEFAULT NULL,
    pENVIADO_CONTABILIDADE   VARCHAR2 DEFAULT NULL,
    pAMBULATORIO             VARCHAR2 DEFAULT NULL,
    pINTERNADO               VARCHAR2 DEFAULT NULL,
    pCOM_PAGAMENTO           VARCHAR2 DEFAULT NULL,
    pSEM_PAGAMENTO           VARCHAR2 DEFAULT NULL,
    pATD_ATE_TP_PACIENTE_A   VARCHAR2 DEFAULT NULL,
    pATD_ATE_TP_PACIENTE_I   VARCHAR2 DEFAULT NULL,
    PDESCONSIDERAR_QUITADOS  VARCHAR2 DEFAULT NULL,
    pFAT_NOF_NR_NOTAFISCAL   IN TB_FAT_NOF_NOTA_FISCAL.FAT_NOF_NR_NOTAFISCAL%TYPE DEFAULT NULL,
    pFAT_NOF_TP_SERIEFISCAL  IN TB_FAT_NOF_NOTA_FISCAL.FAT_NOF_TP_SERIEFISCAL%TYPE DEFAULT NULL,
    pCAD_TPE_CD_CODIGO_ACS   IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_TPE_CD_CODIGO_FU    IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_TPE_CD_CODIGO_PA    IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_TPE_CD_CODIGO_SP    IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_TPE_CD_CODIGO_NP    IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_COB_REL_RESUMO_VENC
  *
  *    Data Criac?o: 22/10/2012  Por: PEDRO
  *    Alteracao:
  *
  * 
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  -- a     constant VARCHAR2(3) := '410';
  begin
    OPEN v_cursor FOR
--SELECT TRUNC(DECODE('1/1/2012',NULL,SYSDATE,'1/1/2012'))-30 FROM DUAL
SELECT DISTINCT
       FNC_COB_PERIODO_VENCIMENTO(NOF.FAT_NFO_DT_VENCIMENTO,pDATA_CONTAB_FIM,'0') ORDEM,
       FNC_COB_PERIODO_VENCIMENTO(NOF.FAT_NFO_DT_VENCIMENTO,pDATA_CONTAB_FIM,'1') PERIODO,
       SUM( CCP.COB_CCP_VL_TOT_CONTA) OVER (PARTITION BY FNC_COB_PERIODO_VENCIMENTO(NOF.FAT_NFO_DT_VENCIMENTO,pDATA_CONTAB_FIM,'1') ) PARCELA,
       NVL(MGC.DIGITADO,0) DIGITADO ,
       SUM(CCP.COB_CCP_VL_TOT_CONTA) OVER (PARTITION BY  FNC_COB_PERIODO_VENCIMENTO(NOF.FAT_NFO_DT_VENCIMENTO,pDATA_CONTAB_FIM,'1')) - NVL(MGC.DIGITADO,0)  SALDO_BRUTO,
       SUM(CCP.COB_CCP_VL_TOT_CONTA - CCP.COB_CCP_VL_IR_FATURADO - CCP.COB_CCP_VL_ISS_FATURADO - CCP.COB_CCP_VL_COFINS_FATURADO - CCP.COB_CCP_VL_CSLL_FATURADO - CCP.COB_CCP_VL_PIS_FATURADO ) OVER (PARTITION BY FNC_COB_PERIODO_VENCIMENTO(NOF.FAT_NFO_DT_VENCIMENTO,pDATA_CONTAB_FIM,'1')) - NVL(MGC.LIQUIDO,0)   SALDO_LIQUIDO, 
       SUM(CCP.COB_CCP_VL_TOT_CONTA - NVL(CCP.COB_CCP_VL_ISS_FATURADO,0)) OVER (PARTITION BY  FNC_COB_PERIODO_VENCIMENTO(NOF.FAT_NFO_DT_VENCIMENTO,pDATA_CONTAB_FIM,'1')) - NVL(MGC.BRUTOMENOSISS,0)  SALDO_BRUTO_MENOS_ISS,
       SUM(NVL(CCP.COB_CCP_VL_ISS_FATURADO,0)) OVER (PARTITION BY FNC_COB_PERIODO_VENCIMENTO(NOF.FAT_NFO_DT_VENCIMENTO,pDATA_CONTAB_FIM,'1')) - NVL(MGC.ISS,0)  SALDO_ISS--,  
      -- FFF.QTD
FROM      TB_FAT_NOF_NOTA_FISCAL       NOF
JOIN      TB_COB_CCP_CONTA_CONS_PARC   CCP  ON  CCP.FAT_NOF_ID          = NOF.FAT_NOF_ID
                                           AND ((pAMBULATORIO IS NOT NULL AND CCP.CAD_LAT_ID_LOCAL_ATENDIMENTO != 29) OR
                                              (pINTERNADO IS NOT NULL AND CCP.CAD_LAT_ID_LOCAL_ATENDIMENTO = 29))
JOIN      TB_CAD_CNV_CONVENIO          CNV  ON  CNV.CAD_CNV_ID_CONVENIO = NOF.CAD_CNV_ID_CONVENIO
JOIN      TB_CAD_UNI_UNIDADE           UNI  ON  UNI.CAD_UNI_ID_UNIDADE  = NOF.CAD_UNI_ID_UNIDADE
LEFT JOIN (SELECT DISTINCT 
            SUM(NVL(MGC.COB_MGC_VL_MOVIMENTO,0) + NVL(MGC.COB_MGC_VL_ISS,0) + NVL(MGC.COB_MGC_VL_IR,0) + NVL(MGC.COB_MGC_VL_CSLL,0) + NVL(MGC.COB_MGC_VL_PIS,0) + NVL(MGC.COB_MGC_VL_COFINS,0)) OVER (PARTITION BY  FNC_COB_PERIODO_VENCIMENTO(NOF.FAT_NFO_DT_VENCIMENTO,pDATA_CONTAB_FIM,'1') ) DIGITADO,
            SUM(NVL(MGC.COB_MGC_VL_MOVIMENTO,0)) OVER (PARTITION BY  FNC_COB_PERIODO_VENCIMENTO(NOF.FAT_NFO_DT_VENCIMENTO,pDATA_CONTAB_FIM,'1') ) LIQUIDO,
            SUM(NVL(MGC.COB_MGC_VL_MOVIMENTO,0) + NVL(MGC.COB_MGC_VL_IR,0) + NVL(MGC.COB_MGC_VL_CSLL,0) + NVL(MGC.COB_MGC_VL_PIS,0) + NVL(MGC.COB_MGC_VL_COFINS,0)) OVER (PARTITION BY  FNC_COB_PERIODO_VENCIMENTO(NOF.FAT_NFO_DT_VENCIMENTO,pDATA_CONTAB_FIM,'1') ) BRUTOMENOSISS,
            SUM(NVL(MGC.COB_MGC_VL_ISS,0)) OVER (PARTITION BY  FNC_COB_PERIODO_VENCIMENTO(NOF.FAT_NFO_DT_VENCIMENTO,pDATA_CONTAB_FIM,'1') ) ISS,
            FNC_COB_PERIODO_VENCIMENTO(NOF.FAT_NFO_DT_VENCIMENTO,pDATA_CONTAB_FIM,'1') PERIODO   
           FROM TB_COB_MGC_MOV_GUIA_COBRANCA MGC
           JOIN TB_FAT_NOF_NOTA_FISCAL       NOF ON NOF.FAT_NOF_ID = MGC.FAT_NOF_ID
           --LEFT JOIN TB_CAD_TMC_TIPO_MOV_COBRANCA TMC  ON  TMC.CAD_TMC_ID          = MGC.CAD_TMC_ID
           LEFT JOIN TB_ASS_BCT_BANCO_CONTA       BCT  ON  BCT.ASS_BCT_ID          = MGC.ASS_BCT_ID
                                        --    AND    (pCAD_BAN_ID is null or BCT.CAD_BAN_ID = pCAD_BAN_ID)
           LEFT JOIN TB_CAD_BAN_BANCO             BAN  ON  BAN.CAD_BAN_ID          = BCT.CAD_BAN_ID
           WHERE  MGC.CAD_TMC_ID          != 7
           AND    (pDATA_EMISSAO_INI IS NULL OR NOF.FAT_NFO_DT_EMISSAO >= pDATA_EMISSAO_INI)
           AND    (pDATA_EMISSAO_FIM IS NULL OR NOF.FAT_NFO_DT_EMISSAO <= pDATA_EMISSAO_FIM)
           AND    (pDATA_VENCIMENTO_INI IS NULL OR NOF.FAT_NFO_DT_VENCIMENTO >= pDATA_VENCIMENTO_INI)
           AND    (pDATA_VENCIMENTO_FIM IS NULL OR NOF.FAT_NFO_DT_VENCIMENTO <= pDATA_VENCIMENTO_FIM)
           AND    (pCAD_CNV_ID_CONVENIO is null or NOF.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
           AND    (pCAD_UNI_ID_UNIDADE IS NULL OR NOF.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
           AND    (pFAT_NOF_NR_NOTAFISCAL IS NULL OR NOF.FAT_NOF_NR_NOTAFISCAL = pFAT_NOF_NR_NOTAFISCAL)
           AND    (pFAT_NOF_TP_SERIEFISCAL IS NULL OR NOF.FAT_NOF_TP_SERIEFISCAL = pFAT_NOF_TP_SERIEFISCAL)
           AND    MGC.COB_MGC_DT_LIBERACAO_CONTAB <= TRUNC(DECODE(pDATA_CONTAB_FIM,NULL,SYSDATE,pDATA_CONTAB_FIM))
           AND    (pDATA_CONTAB_INI IS NULL OR MGC.COB_MGC_DT_LIBERACAO_CONTAB >= pDATA_CONTAB_INI)
          -- AND    (pDATA_CONTAB_FIM IS NULL OR MGC.COB_MGC_DT_LIBERACAO_CONTAB <= pDATA_CONTAB_FIM)
           AND    (pDATA_PAGTO_INI IS NULL OR MGC.COB_MGC_DT_MOVIMENTO >= pDATA_PAGTO_INI)
           AND    (pDATA_PAGTO_FIM IS NULL OR MGC.COB_MGC_DT_MOVIMENTO <= pDATA_PAGTO_FIM)
           AND    (pASS_BCT_ID is null or MGC.ASS_BCT_ID = pASS_BCT_ID)
           AND ((pCOM_PAGAMENTO IS NOT NULL AND NVL(MGC.COB_MGC_VL_MOVIMENTO,0) + NVL(MGC.COB_MGC_VL_ISS,0) + NVL(MGC.COB_MGC_VL_IR,0) + NVL(MGC.COB_MGC_VL_CSLL,0) +
                             NVL(MGC.COB_MGC_VL_PIS,0) + NVL(MGC.COB_MGC_VL_COFINS,0) != 0) OR
              (pSEM_PAGAMENTO IS NOT NULL AND NVL(MGC.COB_MGC_VL_MOVIMENTO,0) + NVL(MGC.COB_MGC_VL_ISS,0) + NVL(MGC.COB_MGC_VL_IR,0) + NVL(MGC.COB_MGC_VL_CSLL,0) +
                             NVL(MGC.COB_MGC_VL_PIS,0) + NVL(MGC.COB_MGC_VL_COFINS,0) = 0))
           ) MGC
           ON MGC.PERIODO             = FNC_COB_PERIODO_VENCIMENTO(NOF.FAT_NFO_DT_VENCIMENTO,pDATA_CONTAB_FIM,'1')
    

 WHERE   CNV.CAD_CNV_CD_OPCAO_PAGTO = 1
--AND  NOF.FAT_NFO_DT_EMISSAO >= '1/01/2011'
--AND NOF.FAT_NFO_DT_VENCIMENTO >= TRUNC(DECODE('01/01/2010',NULL,SYSDATE,'01/01/2011'))-180
--AND NOF.FAT_NFO_DT_VENCIMENTO < TRUNC(DECODE('01/01/2012',NULL,SYSDATE,'01/01/2013'))-120
AND    (pDATA_EMISSAO_INI IS NULL OR NOF.FAT_NFO_DT_EMISSAO >= pDATA_EMISSAO_INI)
AND    (pDATA_EMISSAO_FIM IS NULL OR NOF.FAT_NFO_DT_EMISSAO <= pDATA_EMISSAO_FIM)
AND    (pDATA_VENCIMENTO_INI IS NULL OR NOF.FAT_NFO_DT_VENCIMENTO >= pDATA_VENCIMENTO_INI)
AND    (pDATA_VENCIMENTO_FIM IS NULL OR NOF.FAT_NFO_DT_VENCIMENTO <= pDATA_VENCIMENTO_FIM)
AND    (pCAD_CNV_ID_CONVENIO is null or NOF.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
AND    (pCAD_UNI_ID_UNIDADE IS NULL OR NOF.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
AND    (pFAT_NOF_NR_NOTAFISCAL IS NULL OR NOF.FAT_NOF_NR_NOTAFISCAL = pFAT_NOF_NR_NOTAFISCAL)
AND    (pFAT_NOF_TP_SERIEFISCAL IS NULL OR NOF.FAT_NOF_TP_SERIEFISCAL = pFAT_NOF_TP_SERIEFISCAL)

ORDER BY FNC_COB_PERIODO_VENCIMENTO(NOF.FAT_NFO_DT_VENCIMENTO,pDATA_CONTAB_FIM,'0')
  ;
             io_cursor := v_cursor;
  end PRC_COB_REL_RESUMO_VENC;    
 