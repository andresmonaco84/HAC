 CREATE OR REPLACE FUNCTION "FNC_COB_VL_ISS"
(
   pCAD_UNI_ID_UNIDADE IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
    pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
    pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
    pCAD_PLA_ID_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE DEFAULT NULL,
    pDATA_EMISSAO_INI IN TB_FAT_NOF_NOTA_FISCAL.FAT_NFO_DT_EMISSAO%TYPE DEFAULT NULL,
    pDATA_EMISSAO_FIM IN TB_FAT_NOF_NOTA_FISCAL.FAT_NFO_DT_EMISSAO%TYPE DEFAULT NULL,
    pDATA_VENCIMENTO_INI IN TB_FAT_NOF_NOTA_FISCAL.FAT_NFO_DT_VENCIMENTO%TYPE DEFAULT NULL,
    pDATA_VENCIMENTO_FIM IN TB_FAT_NOF_NOTA_FISCAL.FAT_NFO_DT_VENCIMENTO%TYPE DEFAULT NULL,
    pDATA_PAGTO_INI  IN TB_COB_MGC_MOV_GUIA_COBRANCA.COB_MGC_DT_MOVIMENTO%TYPE DEFAULT NULL,
    pDATA_PAGTO_FIM  IN TB_COB_MGC_MOV_GUIA_COBRANCA.COB_MGC_DT_MOVIMENTO%TYPE DEFAULT NULL,

    pCAD_BAN_ID IN TB_CAD_BAN_BANCO.CAD_BAN_ID%TYPE DEFAULT NULL,
    pASS_BCT_ID IN TB_COB_MGC_MOV_GUIA_COBRANCA.ASS_BCT_ID%TYPE DEFAULT NULL,
    pPENDETE_CONTABILIDADE   VARCHAR2 DEFAULT NULL,
    pENVIADO_CONTABILIDADE   VARCHAR2 DEFAULT NULL,

    pDATA_CONTAB_INI     IN TB_COB_MGC_MOV_GUIA_COBRANCA.COB_MGC_DT_LIBERACAO_CONTAB%TYPE DEFAULT NULL,
    pDATA_CONTAB_FIM     IN TB_COB_MGC_MOV_GUIA_COBRANCA.COB_MGC_DT_LIBERACAO_CONTAB%TYPE DEFAULT NULL,
    pDATA_MOVIMENTO_FIM  IN TB_COB_MGC_MOV_GUIA_COBRANCA.COB_MGC_DT_MOVIMENTO%TYPE DEFAULT NULL,
    pFAT_NOF_NR_NOTAFISCAL   IN TB_FAT_NOF_NOTA_FISCAL.FAT_NOF_NR_NOTAFISCAL%TYPE DEFAULT NULL,
    pFAT_NOF_TP_SERIEFISCAL  IN TB_FAT_NOF_NOTA_FISCAL.FAT_NOF_TP_SERIEFISCAL%TYPE DEFAULT NULL
)
---retorna O VALOR NOF_VL_ISS
return NUMBER is Result NUMBER;
begin

SELECT DISTINCT SUM(NOF.FAT_NOF_VL_ISS) OVER (PARTITION BY CASE WHEN pCAD_CNV_ID_CONVENIO IS NOT NULL THEN NOF.CAD_CNV_ID_CONVENIO ELSE NULL END) INTO RESULT
  FROM TB_FAT_NOF_NOTA_FISCAL NOF
  JOIN (SELECT DISTINCT MGC.FAT_NOF_ID FROM TB_COB_MGC_MOV_GUIA_COBRANCA MGC
        JOIN TB_FAT_NOF_NOTA_FISCAL NOF ON MGC.FAT_NOF_ID = NOF.FAT_NOF_ID
        JOIN TB_ASS_BCT_BANCO_CONTA BCT ON BCT.ASS_BCT_ID = MGC.ASS_BCT_ID
        WHERE NOF.FAT_NOF_ID = MGC.FAT_NOF_ID
        AND    (pDATA_EMISSAO_INI IS NULL OR NOF.FAT_NFO_DT_EMISSAO >= pDATA_EMISSAO_INI)
        AND    (pDATA_EMISSAO_FIM IS NULL OR NOF.FAT_NFO_DT_EMISSAO <= pDATA_EMISSAO_FIM)
        AND    (pDATA_VENCIMENTO_INI IS NULL OR NOF.FAT_NFO_DT_VENCIMENTO >= pDATA_VENCIMENTO_INI)
        AND    (pDATA_VENCIMENTO_FIM IS NULL OR NOF.FAT_NFO_DT_VENCIMENTO <= pDATA_VENCIMENTO_FIM)
        AND    (pCAD_CNV_ID_CONVENIO is null or NOF.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
        AND    (pCAD_UNI_ID_UNIDADE IS NULL OR NOF.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
        AND    (pCAD_PLA_ID_PLANO is null or NOF.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
        AND    (pFAT_NOF_NR_NOTAFISCAL IS NULL OR NOF.FAT_NOF_NR_NOTAFISCAL = pFAT_NOF_NR_NOTAFISCAL)
        AND    (pFAT_NOF_TP_SERIEFISCAL IS NULL OR NOF.FAT_NOF_TP_SERIEFISCAL = pFAT_NOF_TP_SERIEFISCAL)

        AND    (pDATA_PAGTO_INI IS NULL OR MGC.COB_MGC_DT_MOVIMENTO >= pDATA_PAGTO_INI)
        AND    (pDATA_PAGTO_FIM IS NULL OR MGC.COB_MGC_DT_MOVIMENTO <= pDATA_PAGTO_FIM)
        AND    (pDATA_CONTAB_INI IS NULL OR MGC.COB_MGC_DT_LIBERACAO_CONTAB >= pDATA_CONTAB_INI)
        AND    (pDATA_CONTAB_FIM IS NULL OR MGC.COB_MGC_DT_LIBERACAO_CONTAB <= pDATA_CONTAB_FIM)
        AND    (pDATA_MOVIMENTO_FIM IS NULL OR MGC.COB_MGC_DT_MOVIMENTO <= pDATA_MOVIMENTO_FIM)
        AND    (pCAD_BAN_ID is null or BCT.CAD_BAN_ID = pCAD_BAN_ID)
        AND    (pASS_BCT_ID is null or MGC.ASS_BCT_ID = pASS_BCT_ID)
        AND (
            (pPENDETE_CONTABILIDADE IS NOT NULL AND MGC.COB_MGC_DT_LIBERACAO_CONTAB IS     NULL) OR
            (pENVIADO_CONTABILIDADE IS NOT NULL AND MGC.COB_MGC_DT_LIBERACAO_CONTAB IS NOT NULL) OR
            NULL IS NULL
            )
       -- AND ROWNUM =1
        ) MGC
    ON MGC.FAT_NOF_ID = NOF.FAT_NOF_ID
   /* WHERE
               (pDATA_EMISSAO_INI IS NULL OR NOF.FAT_NFO_DT_EMISSAO >= pDATA_EMISSAO_INI)
        AND    (pDATA_EMISSAO_FIM IS NULL OR NOF.FAT_NFO_DT_EMISSAO <= pDATA_EMISSAO_FIM)
        AND    (pDATA_VENCIMENTO_INI IS NULL OR NOF.FAT_NFO_DT_VENCIMENTO >= pDATA_VENCIMENTO_INI)
        AND    (pDATA_VENCIMENTO_FIM IS NULL OR NOF.FAT_NFO_DT_VENCIMENTO <= pDATA_VENCIMENTO_FIM)
        AND    (pCAD_CNV_ID_CONVENIO is null or NOF.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
        AND    (pCAD_UNI_ID_UNIDADE IS NULL OR NOF.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
        AND    (pCAD_PLA_ID_PLANO is null or NOF.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
        AND    (pFAT_NOF_NR_NOTAFISCAL IS NULL OR NOF.FAT_NOF_NR_NOTAFISCAL = pFAT_NOF_NR_NOTAFISCAL)
        AND    (pFAT_NOF_TP_SERIEFISCAL IS NULL OR NOF.FAT_NOF_TP_SERIEFISCAL = pFAT_NOF_TP_SERIEFISCAL)
    */
;

  return(Result);
end FNC_COB_VL_ISS;