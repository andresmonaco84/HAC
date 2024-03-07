CREATE OR REPLACE PROCEDURE PRC_COB_REL_11_MOV_GUIA_COM
  (
    pCAD_UNI_ID_UNIDADE  IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
    pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
    pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
     pCAD_PLA_ID_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE DEFAULT NULL,
    pDATA_EMISSAO_INI    IN TB_FAT_NOF_NOTA_FISCAL.FAT_NFO_DT_EMISSAO%TYPE DEFAULT NULL,
    pDATA_EMISSAO_FIM    IN TB_FAT_NOF_NOTA_FISCAL.FAT_NFO_DT_EMISSAO%TYPE DEFAULT NULL,
    pDATA_VENCIMENTO_INI IN TB_FAT_NOF_NOTA_FISCAL.FAT_NFO_DT_VENCIMENTO%TYPE DEFAULT NULL,
    pDATA_VENCIMENTO_FIM IN TB_FAT_NOF_NOTA_FISCAL.FAT_NFO_DT_VENCIMENTO%TYPE DEFAULT NULL,
    pDATA_PAGTO_INI      IN TB_COB_MGC_MOV_GUIA_COBRANCA.COB_MGC_DT_MOVIMENTO%TYPE DEFAULT NULL,
    pDATA_PAGTO_FIM      IN TB_COB_MGC_MOV_GUIA_COBRANCA.COB_MGC_DT_MOVIMENTO%TYPE DEFAULT NULL,
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
    pDESCONSIDERAR_QUITADOS  VARCHAR2 DEFAULT NULL,
    pDESCONSIDERAR_QUITADOS_VALOR VARCHAR2 DEFAULT NULL,
    pFAT_NOF_NR_NOTAFISCAL   IN TB_FAT_NOF_NOTA_FISCAL.FAT_NOF_NR_NOTAFISCAL%TYPE DEFAULT NULL,
    pFAT_NOF_TP_SERIEFISCAL  IN TB_FAT_NOF_NOTA_FISCAL.FAT_NOF_TP_SERIEFISCAL%TYPE DEFAULT NULL,
    pCAD_TPE_CD_CODIGO_ACS   IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_TPE_CD_CODIGO_FU    IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_TPE_CD_CODIGO_PA    IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_TPE_CD_CODIGO_SP    IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_TPE_CD_CODIGO_NP    IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pATD_GUI_CD_CODIGO       IN TB_COB_CCP_CONTA_CONS_PARC.ATD_GUI_CD_CODIGO%TYPE DEFAULT NULL,
    pATD_GUI_CD_SENHA        IN TB_COB_CCP_CONTA_CONS_PARC.ATD_GUI_CD_SENHA%TYPE DEFAULT NULL,
    pATD_ATE_ID              IN TB_COB_CCP_CONTA_CONS_PARC.ATD_ATE_ID%TYPE DEFAULT NULL,
    pGUIAS_COM_VALOR_A_MAIOR VARCHAR2 DEFAULT NULL,
   -- teste out long,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_COB_REL_11_MOV_GUIA_COM
  *
  *    Data Criac?o: 06/11/2012  Por: PEDRO
  *    Alteracao:
  *
  *    PARECIDO COM RELATORIOS 11
  *******************************************************************/
 v_cursor PKG_CURSOR.t_cursor;
  V_SELECT  varchar2(25000);
  V_WHERE_NOF  varchar2(10000);
  V_WHERE_MGC  varchar2(5000);
  V_WHERE_CCP  varchar2(5000);
  V_HAVING  varchar2(5000);
begin
  V_WHERE_NOF := NULL;
IF pCAD_CNV_ID_CONVENIO IS NOT NULL THEN V_WHERE_NOF:= V_WHERE_NOF || ' AND NOF.CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO; END IF;
IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN V_WHERE_NOF:= V_WHERE_NOF || ' AND NOF.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE; END IF;
IF pFAT_NOF_NR_NOTAFISCAL IS NOT NULL THEN V_WHERE_NOF:= V_WHERE_NOF || ' AND NOF.FAT_NOF_NR_NOTAFISCAL = ' || pFAT_NOF_NR_NOTAFISCAL; END IF;
IF pFAT_NOF_TP_SERIEFISCAL IS NOT NULL THEN V_WHERE_NOF:= V_WHERE_NOF || ' AND NOF.FAT_NOF_TP_SERIEFISCAL = ' || CHR(39) || pFAT_NOF_TP_SERIEFISCAL || CHR(39); END IF;
IF pDATA_EMISSAO_INI IS NOT NULL THEN V_WHERE_NOF:= V_WHERE_NOF || ' AND NOF.FAT_NFO_DT_EMISSAO >= ' || CHR(39) || pDATA_EMISSAO_INI || CHR(39); END IF;
IF pDATA_EMISSAO_FIM IS NOT NULL THEN V_WHERE_NOF:= V_WHERE_NOF || ' AND NOF.FAT_NFO_DT_EMISSAO <= ' || CHR(39) || pDATA_EMISSAO_FIM || CHR(39); END IF;
IF pDATA_VENCIMENTO_INI IS NOT NULL THEN V_WHERE_NOF:= V_WHERE_NOF || ' AND NOF.FAT_NFO_DT_VENCIMENTO >= ' || CHR(39) || pDATA_VENCIMENTO_INI || CHR(39); END IF;
IF pDATA_VENCIMENTO_FIM IS NOT NULL THEN V_WHERE_NOF:= V_WHERE_NOF || ' AND NOF.FAT_NFO_DT_VENCIMENTO <= ' || CHR(39) || pDATA_VENCIMENTO_FIM || CHR(39); END IF;
IF pATD_ATE_ID IS NOT NULL THEN V_WHERE_CCP:= V_WHERE_CCP || ' AND CCP.ATD_ATE_ID = ' || pATD_ATE_ID; END IF;
IF pATD_GUI_CD_CODIGO IS NOT NULL THEN V_WHERE_CCP:= V_WHERE_CCP || ' AND CCP.ATD_GUI_CD_CODIGO LIKE ' || CHR(39) || pATD_GUI_CD_CODIGO || CHR(39); END IF;
IF pATD_GUI_CD_SENHA IS NOT NULL THEN V_WHERE_CCP:= V_WHERE_CCP || ' AND CCP.ATD_GUI_CD_SENHA LIKE  ' || CHR(39) || pATD_GUI_CD_SENHA || CHR(39); END IF;
IF pAMBULATORIO IS NOT NULL AND pINTERNADO IS NULL THEN V_WHERE_CCP:= V_WHERE_CCP || 'AND CCP.CAD_LAT_ID_LOCAL_ATENDIMENTO != 29 '  ; END IF;
IF pAMBULATORIO IS NULL AND pINTERNADO IS NOT NULL THEN V_WHERE_CCP:= V_WHERE_CCP || 'AND CCP.CAD_LAT_ID_LOCAL_ATENDIMENTO = 29 '  ; END IF;
V_WHERE_MGC := NULL;
IF pDATA_CONTAB_INI IS NOT NULL THEN V_WHERE_MGC:= V_WHERE_MGC || ' AND MGC.COB_MGC_DT_LIBERACAO_CONTAB >= ' || CHR(39) || pDATA_CONTAB_INI || CHR(39); END IF;
IF pDATA_CONTAB_FIM IS NOT NULL THEN V_WHERE_MGC:= V_WHERE_MGC || ' AND MGC.COB_MGC_DT_LIBERACAO_CONTAB <= ' || CHR(39) || pDATA_CONTAB_FIM || CHR(39); END IF;
IF pDATA_PAGTO_INI IS NOT NULL THEN V_WHERE_MGC:= V_WHERE_MGC || ' AND MGC.COB_MGC_DT_MOVIMENTO >= ' || CHR(39) || pDATA_PAGTO_INI || CHR(39); END IF;
IF pDATA_PAGTO_FIM IS NOT NULL THEN V_WHERE_MGC:= V_WHERE_MGC || ' AND MGC.COB_MGC_DT_MOVIMENTO <= ' || CHR(39) || pDATA_PAGTO_FIM || CHR(39); END IF;
IF pASS_BCT_ID IS NOT NULL THEN V_WHERE_MGC:= V_WHERE_MGC || ' AND MGC.ASS_BCT_ID = ' || pASS_BCT_ID; END IF;
V_HAVING := NULL;
IF pDESCONSIDERAR_QUITADOS IS NOT NULL THEN V_HAVING:= V_HAVING ||
   ' AND (SUM(NVL(MGC.COB_MGC_VL_MOVIMENTO,0) + NVL(MGC.COB_MGC_VL_ISS,0) +                                                        
 NVL(MGC.COB_MGC_VL_IR,0) + NVL(MGC.COB_MGC_VL_CSLL,0) + NVL(MGC.COB_MGC_VL_PIS,0) + NVL(MGC.COB_MGC_VL_COFINS,0)) + ' ||CHR(39)|| TO_NUMBER(REPLACE(pDESCONSIDERAR_QUITADOS_VALOR,',','.'),'999999.99') ||CHR(39)|| ') < CCP.COB_CCP_VL_TOT_CONTA ' ; END IF;
IF pCOM_PAGAMENTO IS NOT NULL AND pSEM_PAGAMENTO IS NULL THEN V_HAVING:= V_HAVING || ' AND SUM(NVL(MGC.COB_MGC_VL_MOVIMENTO,0) + NVL(MGC.COB_MGC_VL_ISS,0) + NVL(MGC.COB_MGC_VL_IR,0) + NVL(MGC.COB_MGC_VL_CSLL,0) + NVL(MGC.COB_MGC_VL_PIS,0) + NVL(MGC.COB_MGC_VL_COFINS,0)) > 0 '  ; END IF;
IF pCOM_PAGAMENTO IS NULL AND pSEM_PAGAMENTO IS NOT NULL THEN V_HAVING:= V_HAVING || ' AND SUM(NVL(MGC.COB_MGC_VL_MOVIMENTO,0) + NVL(MGC.COB_MGC_VL_ISS,0) + NVL(MGC.COB_MGC_VL_IR,0) + NVL(MGC.COB_MGC_VL_CSLL,0) + NVL(MGC.COB_MGC_VL_PIS,0) + NVL(MGC.COB_MGC_VL_COFINS,0)) = 0 '  ; END IF;
IF pGUIAS_COM_VALOR_A_MAIOR IS NOT NULL THEN V_HAVING:= V_HAVING || ' AND (SUM(NVL(MGC.COB_MGC_VL_MOVIMENTO,0) + NVL(MGC.COB_MGC_VL_ISS,0) +
 NVL(MGC.COB_MGC_VL_IR,0) + NVL(MGC.COB_MGC_VL_CSLL,0) + NVL(MGC.COB_MGC_VL_PIS,0) + NVL(MGC.COB_MGC_VL_COFINS,0)) ) > CCP.COB_CCP_VL_TOT_CONTA ' ; END IF;
   V_SELECT := '
SELECT --DISTINCT
       2 ORDEM,
       NULL CAD_BAN_NM_BANCO,
       NULL ASS_BCT_NR_CONTA, --DUPLICA LINHA E NAO USA NESSES RELATORIOS
       CNV.CAD_CNV_CD_HAC_PRESTADOR,
       CNV.CAD_CNV_NM_FANTASIA,
       CCP.CAD_PES_NM_PESSOA,
       CCP.CAD_PAC_CD_CREDENCIAL,
       CCP.ATD_ATE_DT_ATENDIMENTO,
       UNI.CAD_UNI_DS_RESUMIDA CAD_UNI_DS_UNIDADE,
       TRUNC(NOF.FAT_NFO_DT_EMISSAO) FAT_NFO_DT_EMISSAO,
       TRUNC(NOF.FAT_NFO_DT_VENCIMENTO) FAT_NFO_DT_VENCIMENTO,
       ULTIMO_PGTO.COB_MGC_DT_MOVIMENTO,
       NOF.FAT_NOF_ID,
       NOF.FAT_NOF_NR_NOTAFISCAL,
       NOF.FAT_NOF_TP_SERIEFISCAL,
       NOF.FAT_NFO_VL_FATURADO,
       NOF.FAT_NOF_VL_ISS,
       NOF.FAT_NOF_VL_IR,
       NOF.FAT_NOF_VL_CSLL,
       NOF.FAT_NOF_VL_PIS,
       NOF.FAT_NOF_VL_COFINS,
       NOF.FAT_NOF_VL_DESCONTO,
       NOF.FAT_NFO_VL_RETENCAO,
       NOF.FAT_NFO_VL_LIQUIDO,
       CCP.COB_CCP_VL_ISS_FATURADO,
       CCP.COB_CCP_VL_IR_FATURADO,
       CCP.COB_CCP_VL_CSLL_FATURADO,
       CCP.COB_CCP_VL_PIS_FATURADO,
       CCP.COB_CCP_VL_COFINS_FATURADO,
       CCP.COB_CCP_VL_TOT_CONTA,
       CCP.COB_CCP_VL_TOT_CONTA - NVL(CCP.COB_CCP_VL_ISS_FATURADO,0) - NVL(CCP.COB_CCP_VL_IR_FATURADO,0) -
          NVL(CCP.COB_CCP_VL_CSLL_FATURADO,0) - NVL(CCP.COB_CCP_VL_PIS_FATURADO,0) -
          NVL(CCP.COB_CCP_VL_COFINS_FATURADO,0)    VALOR_LIQUIDO_PARCELA,
       SUM( NVL(MGC.COB_MGC_VL_ISS,0))  COB_MGC_VL_ISS,
       SUM( NVL(MGC.COB_MGC_VL_IR,0))  COB_MGC_VL_IR,
       SUM( NVL(MGC.COB_MGC_VL_CSLL,0))  COB_MGC_VL_CSLL,
       SUM( NVL(MGC.COB_MGC_VL_PIS,0))  COB_MGC_VL_PIS,
       SUM( NVL(MGC.COB_MGC_VL_COFINS,0))  COB_MGC_VL_COFINS,
       NVL(NOTACREDITO.NOTACREDITO,0) NOTACREDITO,
       0 DESCONTO,
       SUM( NVL(MGC.COB_MGC_VL_MOVIMENTO,0))  COB_MGC_VL_MOVIMENTO,
       SUM(NVL(MGC.COB_MGC_VL_MOVIMENTO,0) + NVL(MGC.COB_MGC_VL_ISS,0) + NVL(MGC.COB_MGC_VL_IR,0) + NVL(MGC.COB_MGC_VL_CSLL,0) +
           NVL(MGC.COB_MGC_VL_PIS,0) + NVL(MGC.COB_MGC_VL_COFINS,0))  VALOR_DIGITADO, --vl calculado na tela
       SUM(NVL(MGC.COB_MGC_VL_MOVIMENTO,0) + NVL(MGC.COB_MGC_VL_ISS,0) + NVL(MGC.COB_MGC_VL_IR,0) + NVL(MGC.COB_MGC_VL_CSLL,0) +
                                       NVL(MGC.COB_MGC_VL_PIS,0) + NVL(MGC.COB_MGC_VL_COFINS,0))
                                      -  NVL(SUM(MGC.COB_MGC_VL_MOVIMENTO),0)  TOTAL_RETENCOES,
       NULL COB_MGC_DT_LIBERACAO_CONTAB,
       CCP.ATD_GUI_CD_CODIGO,
       CCP.ATD_ATE_ID,
       CCP.COB_CCP_ID,
       CCP.COB_COC_ID,
       CCP.CAD_PAC_ID_PACIENTE,
       CCP.ATD_GUI_DT_VALIDADE,
       CCP.ATD_GUI_CD_SENHA
FROM      TB_FAT_NOF_NOTA_FISCAL       NOF
JOIN      TB_COB_CCP_CONTA_CONS_PARC   CCP  ON  CCP.FAT_NOF_ID          = NOF.FAT_NOF_ID
JOIN      TB_CAD_CNV_CONVENIO          CNV  ON  CNV.CAD_CNV_ID_CONVENIO = NOF.CAD_CNV_ID_CONVENIO
LEFT JOIN TB_COB_MGC_MOV_GUIA_COBRANCA MGC  ON  MGC.FAT_NOF_ID          = CCP.FAT_NOF_ID
                                           AND  MGC.ATD_ATE_ID          = CCP.ATD_ATE_ID
                                           AND  MGC.CAD_PAC_ID_PACIENTE = CCP.CAD_PAC_ID_PACIENTE
                                           AND  MGC.COB_COC_ID          = CCP.COB_COC_ID
                                           AND  MGC.COB_CCP_ID          = CCP.COB_CCP_ID
                                           AND  MGC.ATD_GUI_CD_CODIGO   = CCP.ATD_GUI_CD_CODIGO
                                           AND  MGC.ATD_GUI_DT_VALIDADE = CCP.ATD_GUI_DT_VALIDADE
                                           AND  MGC.CAD_TMC_ID          NOT IN (7,8)
                                          ' || V_WHERE_MGC || '
LEFT JOIN  (SELECT MAX(TRUNC(MGC.COB_MGC_DT_MOVIMENTO)) COB_MGC_DT_MOVIMENTO,
                   MGC.FAT_NOF_ID, MGC.ATD_ATE_ID, MGC.CAD_PAC_ID_PACIENTE, MGC.COB_COC_ID,
                   MGC.COB_CCP_ID, MGC.ATD_GUI_CD_CODIGO, MGC.ATD_GUI_DT_VALIDADE
            FROM TB_FAT_NOF_NOTA_FISCAL       NOF
            JOIN TB_COB_MGC_MOV_GUIA_COBRANCA MGC ON MGC.FAT_NOF_ID = NOF.FAT_NOF_ID
                WHERE   MGC.CAD_TMC_ID          NOT IN (7,8)
                ' || V_WHERE_NOF || ' ' || V_WHERE_MGC || '
                 AND ((' ||CHR(39)|| pCOM_PAGAMENTO ||CHR(39)|| ' IS NOT NULL AND NVL(MGC.COB_MGC_VL_MOVIMENTO,0) + NVL(MGC.COB_MGC_VL_ISS,0) + NVL(MGC.COB_MGC_VL_IR,0) + NVL(MGC.COB_MGC_VL_CSLL,0) +
                                            NVL(MGC.COB_MGC_VL_PIS,0) + NVL(MGC.COB_MGC_VL_COFINS,0) != 0) OR
                      (' ||CHR(39)|| pSEM_PAGAMENTO ||CHR(39)|| ' IS NOT NULL AND NVL(MGC.COB_MGC_VL_MOVIMENTO,0) + NVL(MGC.COB_MGC_VL_ISS,0) + NVL(MGC.COB_MGC_VL_IR,0) + NVL(MGC.COB_MGC_VL_CSLL,0) +
                                            NVL(MGC.COB_MGC_VL_PIS,0) + NVL(MGC.COB_MGC_VL_COFINS,0) = 0))
               GROUP BY  MGC.FAT_NOF_ID, MGC.ATD_ATE_ID, MGC.CAD_PAC_ID_PACIENTE, MGC.COB_COC_ID,
                   MGC.COB_CCP_ID, MGC.ATD_GUI_CD_CODIGO, MGC.ATD_GUI_DT_VALIDADE
          ) ULTIMO_PGTO
          ON  ULTIMO_PGTO.FAT_NOF_ID          = CCP.FAT_NOF_ID
         AND  ULTIMO_PGTO.ATD_ATE_ID          = CCP.ATD_ATE_ID
         AND  ULTIMO_PGTO.CAD_PAC_ID_PACIENTE = CCP.CAD_PAC_ID_PACIENTE
         AND  ULTIMO_PGTO.COB_COC_ID          = CCP.COB_COC_ID
         AND  ULTIMO_PGTO.COB_CCP_ID          = CCP.COB_CCP_ID
         AND  ULTIMO_PGTO.ATD_GUI_CD_CODIGO   = CCP.ATD_GUI_CD_CODIGO
         AND  ULTIMO_PGTO.ATD_GUI_DT_VALIDADE = CCP.ATD_GUI_DT_VALIDADE
LEFT JOIN  (SELECT  SUM(NVL(MGC.COB_MGC_VL_MOVIMENTO,0)) NOTACREDITO, MGC.ATD_ATE_ID , MGC.CAD_PAC_ID_PACIENTE ,MGC.COB_CCP_ID ,MGC.COB_COC_ID,
                    MGC.ATD_GUI_CD_CODIGO ,MGC.ATD_GUI_DT_VALIDADE, MGC.FAT_NOF_ID
              FROM TB_FAT_NOF_NOTA_FISCAL       NOF
            JOIN TB_COB_MGC_MOV_GUIA_COBRANCA MGC ON MGC.FAT_NOF_ID = NOF.FAT_NOF_ID
            WHERE   MGC.CAD_TMC_ID          = 2
           ' || V_WHERE_NOF || ' ' || V_WHERE_MGC || '
            AND ((' ||CHR(39)|| pCOM_PAGAMENTO ||CHR(39)|| ' IS NOT NULL AND NVL(MGC.COB_MGC_VL_MOVIMENTO,0) + NVL(MGC.COB_MGC_VL_ISS,0) + NVL(MGC.COB_MGC_VL_IR,0) + NVL(MGC.COB_MGC_VL_CSLL,0) +
                             NVL(MGC.COB_MGC_VL_PIS,0) + NVL(MGC.COB_MGC_VL_COFINS,0) != 0) OR
              (' ||CHR(39)|| pSEM_PAGAMENTO ||CHR(39)|| ' IS NOT NULL AND NVL(MGC.COB_MGC_VL_MOVIMENTO,0) + NVL(MGC.COB_MGC_VL_ISS,0) + NVL(MGC.COB_MGC_VL_IR,0) + NVL(MGC.COB_MGC_VL_CSLL,0) +
                             NVL(MGC.COB_MGC_VL_PIS,0) + NVL(MGC.COB_MGC_VL_COFINS,0) = 0))
           GROUP BY MGC.ATD_ATE_ID ,MGC.CAD_PAC_ID_PACIENTE ,MGC.COB_CCP_ID , MGC.COB_COC_ID,MGC.ATD_GUI_CD_CODIGO ,
                    MGC.ATD_GUI_DT_VALIDADE, MGC.FAT_NOF_ID
         ) NOTACREDITO --N.C.
         ON   NOTACREDITO.ATD_ATE_ID          = MGC.ATD_ATE_ID
        AND   NOTACREDITO.CAD_PAC_ID_PACIENTE = MGC.CAD_PAC_ID_PACIENTE
        AND   NOTACREDITO.COB_CCP_ID          = MGC.COB_CCP_ID
        AND   NOTACREDITO.COB_COC_ID          = MGC.COB_COC_ID
        AND   NOTACREDITO.ATD_GUI_CD_CODIGO   = MGC.ATD_GUI_CD_CODIGO
        AND   NOTACREDITO.ATD_GUI_DT_VALIDADE = MGC.ATD_GUI_DT_VALIDADE
        AND   NOTACREDITO.FAT_NOF_ID          = MGC.FAT_NOF_ID
JOIN      TB_CAD_UNI_UNIDADE           UNI  ON  UNI.CAD_UNI_ID_UNIDADE  = NOF.CAD_UNI_ID_UNIDADE
LEFT JOIN TB_CAD_TMC_TIPO_MOV_COBRANCA TMC  ON  TMC.CAD_TMC_ID          = MGC.CAD_TMC_ID
LEFT JOIN TB_ASS_BCT_BANCO_CONTA       BCT  ON  BCT.ASS_BCT_ID          = MGC.ASS_BCT_ID
                                            AND    (' ||CHR(39)|| pCAD_BAN_ID ||CHR(39)|| ' IS NULL OR BCT.CAD_BAN_ID = ' ||CHR(39)|| pCAD_BAN_ID ||CHR(39)|| ')
LEFT JOIN TB_CAD_BAN_BANCO             BAN  ON  BAN.CAD_BAN_ID          = BCT.CAD_BAN_ID
WHERE  CNV.CAD_CNV_CD_OPCAO_PAGTO = 1
' || V_WHERE_NOF || '
' || V_WHERE_CCP || '
GROUP BY
       null,
       NULL,
       CNV.CAD_CNV_CD_HAC_PRESTADOR,
       CNV.CAD_CNV_NM_FANTASIA,
       CCP.CAD_PES_NM_PESSOA,
       CCP.CAD_PAC_CD_CREDENCIAL,
       CCP.ATD_ATE_DT_ATENDIMENTO,
       UNI.CAD_UNI_DS_RESUMIDA,
       TRUNC(NOF.FAT_NFO_DT_EMISSAO) ,
       TRUNC(NOF.FAT_NFO_DT_VENCIMENTO) ,
       ULTIMO_PGTO.COB_MGC_DT_MOVIMENTO,
      NOF.FAT_NOF_ID,
       NOF.FAT_NOF_NR_NOTAFISCAL,
       NOF.FAT_NOF_TP_SERIEFISCAL,
       NOF.FAT_NFO_VL_FATURADO,
       NOF.FAT_NOF_VL_ISS,
       NOF.FAT_NOF_VL_IR,
       NOF.FAT_NOF_VL_CSLL,
       NOF.FAT_NOF_VL_PIS,
       NOF.FAT_NOF_VL_COFINS,
       NOF.FAT_NOF_VL_DESCONTO,
       NOF.FAT_NFO_VL_RETENCAO,
       NOF.FAT_NFO_VL_LIQUIDO,
       CCP.COB_CCP_VL_ISS_FATURADO,
       CCP.COB_CCP_VL_IR_FATURADO,
       CCP.COB_CCP_VL_CSLL_FATURADO,
       CCP.COB_CCP_VL_PIS_FATURADO,
       CCP.COB_CCP_VL_COFINS_FATURADO,
       CCP.COB_CCP_VL_TOT_CONTA,
       CCP.COB_CCP_VL_TOT_CONTA - CCP.COB_CCP_VL_ISS_FATURADO - CCP.COB_CCP_VL_IR_FATURADO - CCP.COB_CCP_VL_CSLL_FATURADO -
       CCP.COB_CCP_VL_PIS_FATURADO - CCP.COB_CCP_VL_COFINS_FATURADO,
       NVL(NOTACREDITO.NOTACREDITO,0),
       0,
       NULL,
       CCP.ATD_GUI_CD_CODIGO,
       CCP.ATD_ATE_ID,
       CCP.COB_CCP_ID,
       CCP.COB_COC_ID,
       CCP.CAD_PAC_ID_PACIENTE,
       CCP.ATD_GUI_DT_VALIDADE,
        CCP.ATD_GUI_CD_SENHA
HAVING 1=1
    ' || V_HAVING ||'
ORDER BY 4,--CNV.CAD_CNV_CD_HAC_PRESTADOR,
         11,--NOF.FAT_NFO_DT_VENCIMENTO,
         9,--CAD_UNI_DS_UNIDADE
         14,--NOF.FAT_NOF_NR_NOTAFISCAL,
         15,--NOF.FAT_NOF_TP_SERIEFISCAL,
         6--CCP.CAD_PES_NM_PESSOA
'    ;
   --TESTE :=  V_SELECT ;
OPEN v_cursor FOR
    --  SELECT 1 FROM DUAL;
       V_SELECT  ;
  io_cursor := v_cursor;
      /*  NVL(SUM(MGC.COB_MGC_VL_ISS) OVER(PARTITION BY NOF.FAT_NOF_ID),0) COB_MGC_VL_ISS,
       NVL(SUM(MGC.COB_MGC_VL_IR) OVER(PARTITION BY NOF.FAT_NOF_ID),0) COB_MGC_VL_IR,
       NVL(SUM(MGC.COB_MGC_VL_CSLL) OVER(PARTITION BY NOF.FAT_NOF_ID),0) COB_MGC_VL_CSLL,
       NVL(SUM(MGC.COB_MGC_VL_PIS) OVER(PARTITION BY NOF.FAT_NOF_ID),0) COB_MGC_VL_PIS,
       NVL(SUM(MGC.COB_MGC_VL_COFINS) OVER(PARTITION BY NOF.FAT_NOF_ID),0) COB_MGC_VL_COFINS,
       NVL(NULL,0) NOTACREDITO,
       SUM(MGC.COB_MGC_VL_MOVIMENTO) OVER(PARTITION BY NOF.FAT_NOF_ID) COB_MGC_VL_MOVIMENTO,
       NVL(SUM(MGC.COB_MGC_VL_MOVIMENTO + MGC.COB_MGC_VL_ISS + MGC.COB_MGC_VL_IR + MGC.COB_MGC_VL_CSLL +
           MGC.COB_MGC_VL_PIS + MGC.COB_MGC_VL_COFINS) OVER(PARTITION BY NOF.FAT_NOF_ID),0) VALOR_DIGITADO, --vl calculado na tela
       NVL(SUM(MGC.COB_MGC_VL_MOVIMENTO + MGC.COB_MGC_VL_ISS + MGC.COB_MGC_VL_IR + MGC.COB_MGC_VL_CSLL +
                                       MGC.COB_MGC_VL_PIS + MGC.COB_MGC_VL_COFINS) OVER(PARTITION BY NOF.FAT_NOF_ID),0)
                                      -  NVL(SUM(MGC.COB_MGC_VL_MOVIMENTO) OVER(PARTITION BY NOF.FAT_NOF_ID),0) TOTAL_RETENCOES,*/
                                      /*,
       FNC_COB_VL_FATURADO(pCAD_UNI_ID_UNIDADE , pCAD_LAT_ID_LOCAL_ATENDIMENTO, NOF.CAD_CNV_ID_CONVENIO,  pCAD_PLA_ID_PLANO , pDATA_EMISSAO_INI ,       pDATA_EMISSAO_FIM ,    pDATA_VENCIMENTO_INI,   pDATA_VENCIMENTO_FIM,    pDATA_PAGTO_INI ,    pDATA_PAGTO_FIM,       pCAD_BAN_ID ,    pASS_BCT_ID ,   pPENDETE_CONTABILIDADE ,    pENVIADO_CONTABILIDADE,    pDATA_CONTAB_INI,    pDATA_CONTAB_FIM,    pDATA_MOVIMENTO_FIM,       pFAT_NOF_NR_NOTAFISCAL,    pFAT_NOF_TP_SERIEFISCAL) CNV_FAT_NFO_VL_FATURADO,
       FNC_COB_VL_ISS(pCAD_UNI_ID_UNIDADE , pCAD_LAT_ID_LOCAL_ATENDIMENTO, NOF.CAD_CNV_ID_CONVENIO, pCAD_PLA_ID_PLANO, pDATA_EMISSAO_INI ,       pDATA_EMISSAO_FIM ,    pDATA_VENCIMENTO_INI,   pDATA_VENCIMENTO_FIM,    pDATA_PAGTO_INI ,    pDATA_PAGTO_FIM,       pCAD_BAN_ID ,    pASS_BCT_ID ,   pPENDETE_CONTABILIDADE ,    pENVIADO_CONTABILIDADE,    pDATA_CONTAB_INI,    pDATA_CONTAB_FIM,    pDATA_MOVIMENTO_FIM,       pFAT_NOF_NR_NOTAFISCAL,    pFAT_NOF_TP_SERIEFISCAL) CNV_FAT_NFO_VL_ISS,
       FNC_COB_VL_DESCONTO(pCAD_UNI_ID_UNIDADE , pCAD_LAT_ID_LOCAL_ATENDIMENTO, NOF.CAD_CNV_ID_CONVENIO, pCAD_PLA_ID_PLANO, pDATA_EMISSAO_INI ,       pDATA_EMISSAO_FIM ,    pDATA_VENCIMENTO_INI,   pDATA_VENCIMENTO_FIM,    pDATA_PAGTO_INI ,    pDATA_PAGTO_FIM,       pCAD_BAN_ID ,   pASS_BCT_ID ,   pPENDETE_CONTABILIDADE ,    pENVIADO_CONTABILIDADE,    pDATA_CONTAB_INI,    pDATA_CONTAB_FIM,    pDATA_MOVIMENTO_FIM,       pFAT_NOF_NR_NOTAFISCAL,    pFAT_NOF_TP_SERIEFISCAL) CNV_FAT_NFO_VL_DESCONTO,
       FNC_COB_VL_RETENCAO(pCAD_UNI_ID_UNIDADE , pCAD_LAT_ID_LOCAL_ATENDIMENTO, NOF.CAD_CNV_ID_CONVENIO, pCAD_PLA_ID_PLANO, pDATA_EMISSAO_INI ,       pDATA_EMISSAO_FIM ,    pDATA_VENCIMENTO_INI,   pDATA_VENCIMENTO_FIM,    pDATA_PAGTO_INI ,    pDATA_PAGTO_FIM,       pCAD_BAN_ID ,    pASS_BCT_ID,   pPENDETE_CONTABILIDADE ,    pENVIADO_CONTABILIDADE,    pDATA_CONTAB_INI,    pDATA_CONTAB_FIM,    pDATA_MOVIMENTO_FIM,       pFAT_NOF_NR_NOTAFISCAL,    pFAT_NOF_TP_SERIEFISCAL) CNV_FAT_NFO_VL_RETENCAO,
       FNC_COB_VL_LIQUIDO(pCAD_UNI_ID_UNIDADE , pCAD_LAT_ID_LOCAL_ATENDIMENTO, NOF.CAD_CNV_ID_CONVENIO, pCAD_PLA_ID_PLANO, pDATA_EMISSAO_INI ,       pDATA_EMISSAO_FIM ,    pDATA_VENCIMENTO_INI,   pDATA_VENCIMENTO_FIM,    pDATA_PAGTO_INI ,    pDATA_PAGTO_FIM,       pCAD_BAN_ID ,    pASS_BCT_ID ,   pPENDETE_CONTABILIDADE ,    pENVIADO_CONTABILIDADE,    pDATA_CONTAB_INI,    pDATA_CONTAB_FIM,    pDATA_MOVIMENTO_FIM,       pFAT_NOF_NR_NOTAFISCAL,    pFAT_NOF_TP_SERIEFISCAL) CNV_FAT_NFO_VL_LIQUIDO,
       FNC_COB_VL_FATURADO(pCAD_UNI_ID_UNIDADE , pCAD_LAT_ID_LOCAL_ATENDIMENTO, DECODE(pCAD_CNV_ID_CONVENIO,NULL,NULL,pCAD_CNV_ID_CONVENIO) , pCAD_PLA_ID_PLANO, pDATA_EMISSAO_INI ,       pDATA_EMISSAO_FIM ,    pDATA_VENCIMENTO_INI,   pDATA_VENCIMENTO_FIM,    pDATA_PAGTO_INI ,    pDATA_PAGTO_FIM,       pCAD_BAN_ID ,    DECODE(pASS_BCT_ID,NULL,NULL,pASS_BCT_ID)  ,   pPENDETE_CONTABILIDADE ,    pENVIADO_CONTABILIDADE,    pDATA_CONTAB_INI,    pDATA_CONTAB_FIM,    pDATA_MOVIMENTO_FIM,       pFAT_NOF_NR_NOTAFISCAL,    pFAT_NOF_TP_SERIEFISCAL) TOT_FAT_NFO_VL_FATURADO,
       FNC_COB_VL_ISS(pCAD_UNI_ID_UNIDADE , pCAD_LAT_ID_LOCAL_ATENDIMENTO, DECODE(pCAD_CNV_ID_CONVENIO,NULL,NULL,pCAD_CNV_ID_CONVENIO), pCAD_PLA_ID_PLANO, pDATA_EMISSAO_INI ,       pDATA_EMISSAO_FIM ,    pDATA_VENCIMENTO_INI,   pDATA_VENCIMENTO_FIM,    pDATA_PAGTO_INI ,    pDATA_PAGTO_FIM,       pCAD_BAN_ID ,   DECODE(pASS_BCT_ID,NULL,NULL,pASS_BCT_ID)  ,   pPENDETE_CONTABILIDADE ,    pENVIADO_CONTABILIDADE,    pDATA_CONTAB_INI,    pDATA_CONTAB_FIM,    pDATA_MOVIMENTO_FIM,       pFAT_NOF_NR_NOTAFISCAL,    pFAT_NOF_TP_SERIEFISCAL) TOT_FAT_NFO_VL_ISS,
       FNC_COB_VL_DESCONTO(pCAD_UNI_ID_UNIDADE , pCAD_LAT_ID_LOCAL_ATENDIMENTO, DECODE(pCAD_CNV_ID_CONVENIO,NULL,NULL,pCAD_CNV_ID_CONVENIO), pCAD_PLA_ID_PLANO, pDATA_EMISSAO_INI ,       pDATA_EMISSAO_FIM ,    pDATA_VENCIMENTO_INI,   pDATA_VENCIMENTO_FIM,    pDATA_PAGTO_INI ,    pDATA_PAGTO_FIM,       pCAD_BAN_ID ,   DECODE(pASS_BCT_ID,NULL,NULL,pASS_BCT_ID)  ,   pPENDETE_CONTABILIDADE ,    pENVIADO_CONTABILIDADE,    pDATA_CONTAB_INI,    pDATA_CONTAB_FIM,    pDATA_MOVIMENTO_FIM,       pFAT_NOF_NR_NOTAFISCAL,    pFAT_NOF_TP_SERIEFISCAL) TOT_FAT_NFO_VL_DESCONTO,
       FNC_COB_VL_RETENCAO(pCAD_UNI_ID_UNIDADE , pCAD_LAT_ID_LOCAL_ATENDIMENTO, DECODE(pCAD_CNV_ID_CONVENIO,NULL,NULL,pCAD_CNV_ID_CONVENIO), pCAD_PLA_ID_PLANO, pDATA_EMISSAO_INI ,       pDATA_EMISSAO_FIM ,    pDATA_VENCIMENTO_INI,   pDATA_VENCIMENTO_FIM,    pDATA_PAGTO_INI ,    pDATA_PAGTO_FIM,       pCAD_BAN_ID , DECODE(pASS_BCT_ID,NULL,NULL,pASS_BCT_ID) ,   pPENDETE_CONTABILIDADE ,    pENVIADO_CONTABILIDADE,    pDATA_CONTAB_INI,    pDATA_CONTAB_FIM,    pDATA_MOVIMENTO_FIM,       pFAT_NOF_NR_NOTAFISCAL,    pFAT_NOF_TP_SERIEFISCAL) TOT_FAT_NFO_VL_RETENCAO,
       FNC_COB_VL_LIQUIDO(pCAD_UNI_ID_UNIDADE , pCAD_LAT_ID_LOCAL_ATENDIMENTO, DECODE(pCAD_CNV_ID_CONVENIO,NULL,NULL,pCAD_CNV_ID_CONVENIO), pCAD_PLA_ID_PLANO, pDATA_EMISSAO_INI ,       pDATA_EMISSAO_FIM ,    pDATA_VENCIMENTO_INI,   pDATA_VENCIMENTO_FIM,    pDATA_PAGTO_INI ,    pDATA_PAGTO_FIM,       pCAD_BAN_ID , DECODE(pASS_BCT_ID,NULL,NULL,pASS_BCT_ID)  ,   pPENDETE_CONTABILIDADE ,    pENVIADO_CONTABILIDADE,    pDATA_CONTAB_INI,    pDATA_CONTAB_FIM,    pDATA_MOVIMENTO_FIM,       pFAT_NOF_NR_NOTAFISCAL,  pFAT_NOF_TP_SERIEFISCAL) TOT_FAT_NFO_VL_LIQUIDO
       */
  end PRC_COB_REL_11_MOV_GUIA_COM;
 