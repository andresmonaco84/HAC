CREATE OR REPLACE PROCEDURE "PRC_COB_REL_23_VL_A_MENOR"
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
    pCAD_TPE_CD_CODIGO_ACS IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_TPE_CD_CODIGO_FU IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_TPE_CD_CODIGO_PA IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_TPE_CD_CODIGO_SP IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_TPE_CD_CODIGO_NP IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
     pDATA_CONTAB_INI     IN TB_COB_MGC_MOV_GUIA_COBRANCA.COB_MGC_DT_LIBERACAO_CONTAB%TYPE DEFAULT NULL,
    pDATA_CONTAB_FIM     IN TB_COB_MGC_MOV_GUIA_COBRANCA.COB_MGC_DT_LIBERACAO_CONTAB%TYPE DEFAULT NULL,
    pDATA_MOVIMENTO_FIM  IN TB_COB_MGC_MOV_GUIA_COBRANCA.COB_MGC_DT_MOVIMENTO%TYPE DEFAULT NULL,
    pFAT_NOF_NR_NOTAFISCAL   IN TB_FAT_NOF_NOTA_FISCAL.FAT_NOF_NR_NOTAFISCAL%TYPE DEFAULT NULL,
    pFAT_NOF_TP_SERIEFISCAL  IN TB_FAT_NOF_NOTA_FISCAL.FAT_NOF_TP_SERIEFISCAL%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
    -- ,TESTE OUT LONG
  )
  is
  /********************************************************************
  *    Procedure: PRC_COB_REL_23_VL_A_MENOR
  *
  *    Data ALT: 15/01/2014  Por: PEDRO
  *    Alteracao:
  *
  *
  *******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
  V_WHERE_NOTA  varchar2(3000);
  V_WHERE_MGC  varchar2(3000);
  V_SELECT  varchar2(30000);
begin
  V_WHERE_NOTA := NULL;
IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN V_WHERE_NOTA:= V_WHERE_NOTA || ' AND NOF.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE; END IF;
IF pCAD_CNV_ID_CONVENIO IS NOT NULL THEN V_WHERE_NOTA := V_WHERE_NOTA || ' AND NOF.CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO;    END IF;
IF pFAT_NOF_NR_NOTAFISCAL IS NOT NULL THEN V_WHERE_NOTA := V_WHERE_NOTA || ' AND NOF.FAT_NOF_NR_NOTAFISCAL = ' ||CHR(39)|| pFAT_NOF_NR_NOTAFISCAL ||CHR(39);    END IF;
IF pFAT_NOF_TP_SERIEFISCAL IS NOT NULL THEN V_WHERE_NOTA := V_WHERE_NOTA || ' AND NOF.FAT_NOF_TP_SERIEFISCAL = ' ||CHR(39)|| pFAT_NOF_TP_SERIEFISCAL ||CHR(39);    END IF;
IF pDATA_EMISSAO_INI IS NOT NULL THEN V_WHERE_NOTA := V_WHERE_NOTA || ' AND TRUNC(NOF.FAT_NFO_DT_EMISSAO) >= ' ||CHR(39)|| pDATA_EMISSAO_INI ||CHR(39);    END IF;
IF pDATA_EMISSAO_FIM IS NOT NULL THEN V_WHERE_NOTA := V_WHERE_NOTA || ' AND TRUNC(NOF.FAT_NFO_DT_EMISSAO) <= ' ||CHR(39)|| pDATA_EMISSAO_FIM ||CHR(39);    END IF;
IF pDATA_VENCIMENTO_INI IS NOT NULL THEN V_WHERE_NOTA := V_WHERE_NOTA || ' AND TRUNC(NOF.FAT_NFO_DT_VENCIMENTO) >= ' ||CHR(39)|| pDATA_VENCIMENTO_INI ||CHR(39);    END IF;
IF pDATA_VENCIMENTO_FIM IS NOT NULL THEN V_WHERE_NOTA := V_WHERE_NOTA || ' AND TRUNC(NOF.FAT_NFO_DT_VENCIMENTO) <= ' ||CHR(39)|| pDATA_VENCIMENTO_FIM ||CHR(39);    END IF;
V_WHERE_MGC := NULL;
IF pDATA_CONTAB_INI IS NOT NULL THEN V_WHERE_MGC := V_WHERE_MGC || ' AND MGC.COB_MGC_DT_LIBERACAO_CONTAB >= ' ||CHR(39)|| pDATA_CONTAB_INI ||CHR(39);    END IF;
IF pDATA_CONTAB_FIM IS NOT NULL THEN V_WHERE_MGC := V_WHERE_MGC || ' AND MGC.COB_MGC_DT_LIBERACAO_CONTAB <= ' ||CHR(39)|| pDATA_CONTAB_FIM ||CHR(39);    END IF;
IF pDATA_PAGTO_INI IS NOT NULL THEN V_WHERE_MGC := V_WHERE_MGC || ' AND MGC.COB_MGC_DT_MOVIMENTO >= ' ||CHR(39)|| pDATA_PAGTO_INI ||CHR(39);    END IF;
IF pDATA_PAGTO_FIM IS NOT NULL THEN V_WHERE_MGC := V_WHERE_MGC || ' AND MGC.COB_MGC_DT_MOVIMENTO <= ' ||CHR(39)|| pDATA_PAGTO_FIM ||CHR(39);    END IF;
IF pASS_BCT_ID IS NOT NULL THEN V_WHERE_MGC:= V_WHERE_MGC || ' AND MGC.ASS_BCT_ID = ' || pASS_BCT_ID; END IF;
V_SELECT:=
'
SELECT
       CNV.CAD_CNV_CD_HAC_PRESTADOR,
       CNV.CAD_CNV_NM_FANTASIA,
       UNI.CAD_UNI_DS_UNIDADE,
       UNI.CAD_UNI_DS_RESUMIDA,
       TRUNC(NOF.FAT_NFO_DT_EMISSAO) FAT_NFO_DT_EMISSAO,
       TRUNC(NOF.FAT_NFO_DT_VENCIMENTO) FAT_NFO_DT_VENCIMENTO,
       NOF.FAT_NOF_ID,
       NOF.FAT_NOF_NR_NOTAFISCAL,
       NOF.FAT_NOF_TP_SERIEFISCAL,
       NOF.FAT_NFO_VL_FATURADO,
       NOF.FAT_NOF_VL_ISS,
       NOF.FAT_NOF_VL_DESCONTO,
       NOF.FAT_NFO_VL_RETENCAO,
       NVL(NOF.FAT_NFO_VL_LIQUIDO,0) FAT_NFO_VL_LIQUIDO,
       NVL(MGC.VALOR_DIGITADO,0) VALOR_DIGITADO,
       NVL(MGC.VALOR_PAGO,0) VALOR_PAGO,
       NVL(MGC.COB_MGC_VL_ISS,0)COB_MGC_VL_ISS,
       NVL(MGC.COB_MGC_VL_IR,0)COB_MGC_VL_IR,
       NVL(MGC.COB_MGC_VL_CSLL,0) COB_MGC_VL_CSLL,
       NVL(MGC.COB_MGC_VL_PIS,0) COB_MGC_VL_PIS,
       NVL(MGC.COB_MGC_VL_COFINS,0) COB_MGC_VL_COFINS,
       SUM(NVL(CCP.COB_CCP_VL_TOT_CONTA,0)) COB_CCP_VL_TOT_CONTA,
       NVL(SUM(NVL(CCP.COB_CCP_VL_ISS_FATURADO,0)),0) COB_CCP_VL_ISS_FATURADO,
       SUM(NVL(CCP.COB_CCP_VL_IR_FATURADO,0)) COB_CCP_VL_IR_FATURADO,
       SUM(NVL(CCP.COB_CCP_VL_CSLL_FATURADO,0)) COB_CCP_VL_CSLL_FATURADO,
       SUM(NVL(CCP.COB_CCP_VL_PIS_FATURADO,0)) COB_CCP_VL_PIS_FATURADO,
       SUM(NVL(CCP.COB_CCP_VL_COFINS_FATURADO,0)) COB_CCP_VL_COFINS_FATURADO,
       NVL(SUM(NVL(CCP.COB_CCP_VL_ISS_FATURADO,0)) - NVL(MGC.COB_MGC_VL_ISS,0),0) SALDO_ISS,
       SUM(CCP.COB_CCP_VL_TOT_CONTA) - SUM(NVL(CCP.COB_CCP_VL_ISS_FATURADO,0)) BRUTO_MENOS_ISS_NOTA,
       (NVL(MGC.VALOR_DIGITADO,0)-NVL(MGC.COB_MGC_VL_ISS,0)) BRUTO_MENOS_ISS_PAGO,
       (SUM(NVL(CCP.COB_CCP_VL_TOT_CONTA,0)) - SUM(NVL(CCP.COB_CCP_VL_ISS_FATURADO,0))) - (NVL(MGC.VALOR_DIGITADO,0)-NVL(MGC.COB_MGC_VL_ISS,0))+NVL(ANTECIPACAO.ISS,0)   SALDO_BRUTO_MENOS_ISS,
       (SUM(NVL(CCP.COB_CCP_VL_TOT_CONTA,0)) - NVL(MGC.VALOR_DIGITADO,0)) SALDO_BRUTO_NOTA,
       CASE WHEN EXISTE_GUIA_SEM_PGTO.EXISTE_GUIA_SEM_PGTO = 1 THEN ''S'' ELSE ''N'' END GUIA_EM_ABERTO,
       NVL(ANTECIPACAO.ISS,0) ANTECIPACAO_ISS,
       NVL(ANTECIPACAO.OP,0)  ANTECIPACAO_OP,
       (TO_DATE('||CHR(39)|| pDATA_CONTAB_FIM ||CHR(39)|| ') - NOF.FAT_NFO_DT_VENCIMENTO)+1 QTD_DIAS,
       FNC_COB_PERIODO_VENCIMENTO(NOF.FAT_NFO_DT_VENCIMENTO,TO_DATE('||CHR(39)|| pDATA_CONTAB_FIM ||CHR(39)|| '),''0'') ORDEM,
       FNC_COB_PERIODO_VENCIMENTO(NOF.FAT_NFO_DT_VENCIMENTO,TO_DATE('||CHR(39)|| pDATA_CONTAB_FIM ||CHR(39)|| '),''1'') PERIODO,
       UNI.CODFILIAL
FROM      TB_FAT_NOF_NOTA_FISCAL       NOF
JOIN      TB_COB_CCP_CONTA_CONS_PARC   CCP  ON  CCP.FAT_NOF_ID          = NOF.FAT_NOF_ID
JOIN      TB_CAD_CNV_CONVENIO          CNV  ON  CNV.CAD_CNV_ID_CONVENIO = NOF.CAD_CNV_ID_CONVENIO
JOIN      TB_CAD_UNI_UNIDADE           UNI  ON  UNI.CAD_UNI_ID_UNIDADE  = NOF.CAD_UNI_ID_UNIDADE
LEFT JOIN (SELECT SUM(NVL(MGC.COB_MGC_VL_MOVIMENTO,0))+SUM(NVL(MGC.COB_MGC_VL_ISS,0))+SUM(NVL(MGC.COB_MGC_VL_IR,0))+SUM(NVL(MGC.COB_MGC_VL_CSLL,0))+ SUM(NVL(MGC.COB_MGC_VL_PIS,0)) +SUM(NVL(MGC.COB_MGC_VL_COFINS,0)) VALOR_DIGITADO,
                  SUM(NVL(MGC.COB_MGC_VL_MOVIMENTO,0)) VALOR_PAGO,
                  SUM(NVL(MGC.COB_MGC_VL_ISS,0))  COB_MGC_VL_ISS,
                  SUM(NVL(MGC.COB_MGC_VL_IR,0))  COB_MGC_VL_IR,
                  SUM(NVL(MGC.COB_MGC_VL_CSLL,0))  COB_MGC_VL_CSLL,
                  SUM(NVL(MGC.COB_MGC_VL_PIS,0))  COB_MGC_VL_PIS,
                  SUM(NVL(MGC.COB_MGC_VL_COFINS,0))  COB_MGC_VL_COFINS,
                  MGC.FAT_NOF_ID
       FROM TB_FAT_NOF_NOTA_FISCAL       NOF
        JOIN TB_COB_MGC_MOV_GUIA_COBRANCA MGC ON MGC.FAT_NOF_ID = NOF.FAT_NOF_ID
        WHERE MGC.CAD_TMC_ID          not in ( 7,8)
      ' || V_WHERE_NOTA || ' ' || V_WHERE_MGC || '
        AND (
            ('||CHR(39)|| pPENDETE_CONTABILIDADE ||CHR(39)||' IS NOT NULL AND MGC.COB_MGC_DT_LIBERACAO_CONTAB IS     NULL) OR
            ('||CHR(39)|| pENVIADO_CONTABILIDADE ||CHR(39)||' IS NOT NULL AND MGC.COB_MGC_DT_LIBERACAO_CONTAB IS NOT NULL) OR
            NULL IS NULL
            )
        GROUP BY MGC.FAT_NOF_ID
      ) MGC ON  MGC.FAT_NOF_ID          = CCP.FAT_NOF_ID
LEFT  JOIN (SELECT DISTINCT AAA.EXISTE_GUIA_SEM_PGTO,AAA.FAT_NOF_ID FROM
           (SELECT DISTINCT 1 EXISTE_GUIA_SEM_PGTO,
                CCP.FAT_NOF_ID,CCP.ATD_ATE_ID,CCP.CAD_PAC_ID_PACIENTE,CCP.COB_COC_ID,CCP.COB_CCP_ID,CCP.ATD_GUI_CD_CODIGO,CCP.ATD_GUI_DT_VALIDADE,
               SUM(NVL(MGC.COB_MGC_VL_MOVIMENTO,0) + NVL(MGC.COB_MGC_VL_ISS,0) + NVL(MGC.COB_MGC_VL_IR,0) + NVL(MGC.COB_MGC_VL_CSLL,0) +
                NVL(MGC.COB_MGC_VL_PIS,0) + NVL(MGC.COB_MGC_VL_COFINS,0)), CCP.COB_CCP_VL_TOT_CONTA
             FROM      TB_COB_CCP_CONTA_CONS_PARC   CCP
             LEFT JOIN TB_COB_MGC_MOV_GUIA_COBRANCA MGC ON  MGC.FAT_NOF_ID          = CCP.FAT_NOF_ID
                                                       AND  MGC.ATD_ATE_ID          = CCP.ATD_ATE_ID
                                                       AND  MGC.CAD_PAC_ID_PACIENTE = CCP.CAD_PAC_ID_PACIENTE
                                                       AND  MGC.COB_COC_ID          = CCP.COB_COC_ID
                                                       AND  MGC.COB_CCP_ID          = CCP.COB_CCP_ID
                                                       AND  MGC.ATD_GUI_CD_CODIGO   = CCP.ATD_GUI_CD_CODIGO
                                                       AND  MGC.ATD_GUI_DT_VALIDADE = CCP.ATD_GUI_DT_VALIDADE
               GROUP BY
                CCP.FAT_NOF_ID,CCP.ATD_ATE_ID,CCP.CAD_PAC_ID_PACIENTE,CCP.COB_COC_ID,CCP.COB_CCP_ID,CCP.ATD_GUI_CD_CODIGO,CCP.ATD_GUI_DT_VALIDADE
                ,CCP.COB_CCP_VL_TOT_CONTA
            HAVING  SUM(NVL(MGC.COB_MGC_VL_MOVIMENTO,0) + NVL(MGC.COB_MGC_VL_ISS,0) + NVL(MGC.COB_MGC_VL_IR,0) + NVL(MGC.COB_MGC_VL_CSLL,0) +
                NVL(MGC.COB_MGC_VL_PIS,0) + NVL(MGC.COB_MGC_VL_COFINS,0)) < CCP.COB_CCP_VL_TOT_CONTA
                ) AAA
            ) EXISTE_GUIA_SEM_PGTO ON  EXISTE_GUIA_SEM_PGTO.FAT_NOF_ID          = CCP.FAT_NOF_ID
LEFT JOIN (SELECT FAT_NOF_ID, SUM(ISS) ISS, SUM(OP) OP
            FROM
           (SELECT MGC.FAT_NOF_ID, SUM(NVL(MGC.COB_MGC_VL_ISS,0))  ISS,
                  SUM(NVL(MGC.COB_MGC_VL_IR,0)) + SUM(NVL(MGC.COB_MGC_VL_CSLL,0)) + SUM(NVL(MGC.COB_MGC_VL_PIS,0)) + SUM(NVL(MGC.COB_MGC_VL_COFINS,0)) OP
             FROM TB_FAT_NOF_NOTA_FISCAL       NOF
             JOIN TB_COB_MGC_MOV_GUIA_COBRANCA MGC ON MGC.FAT_NOF_ID = NOF.FAT_NOF_ID
            WHERE MGC.CAD_TMC_ID = 8
           ' || V_WHERE_NOTA || ' ' || V_WHERE_MGC || '
            GROUP BY MGC.FAT_NOF_ID
         UNION ALL
            SELECT MGC.FAT_NOF_ID, SUM(NVL(MGC.COB_MGC_VL_ISS,0))*-1  ISS,
                  (SUM(NVL(MGC.COB_MGC_VL_IR,0)) + SUM(NVL(MGC.COB_MGC_VL_CSLL,0)) + SUM(NVL(MGC.COB_MGC_VL_PIS,0)) + SUM(NVL(MGC.COB_MGC_VL_COFINS,0)))*-1 OP
             FROM TB_FAT_NOF_NOTA_FISCAL       NOF
             JOIN TB_COB_MGC_MOV_GUIA_COBRANCA MGC ON MGC.FAT_NOF_ID = NOF.FAT_NOF_ID
            WHERE MGC.CAD_TMC_ID = 9
           ' || V_WHERE_NOTA || ' ' || V_WHERE_MGC || '
            GROUP BY MGC.FAT_NOF_ID
            )
            GROUP BY FAT_NOF_ID
          ) ANTECIPACAO ON ANTECIPACAO.FAT_NOF_ID = NOF.FAT_NOF_ID
WHERE  CNV.CAD_CNV_CD_OPCAO_PAGTO = ''1''
' || V_WHERE_NOTA || '
      GROUP BY
       NVL(MGC.VALOR_DIGITADO,0),
       NVL(MGC.VALOR_PAGO,0),
       NVL(MGC.COB_MGC_VL_ISS,0),
       NVL(MGC.COB_MGC_VL_IR,0),
       NVL(MGC.COB_MGC_VL_CSLL,0),
       NVL(MGC.COB_MGC_VL_PIS,0),
       NVL(MGC.COB_MGC_VL_COFINS,0),
       CNV.CAD_CNV_CD_HAC_PRESTADOR,
       CNV.CAD_CNV_NM_FANTASIA,
       UNI.CAD_UNI_DS_UNIDADE,
       UNI.CAD_UNI_DS_RESUMIDA,
       TRUNC(NOF.FAT_NFO_DT_EMISSAO) ,
       TRUNC(NOF.FAT_NFO_DT_VENCIMENTO) ,
       NOF.FAT_NOF_ID,
       NOF.FAT_NOF_NR_NOTAFISCAL,
       NOF.FAT_NOF_TP_SERIEFISCAL,
       NOF.FAT_NFO_VL_FATURADO,
       NOF.FAT_NOF_VL_ISS,
       NOF.FAT_NOF_VL_DESCONTO,
       NOF.FAT_NFO_VL_RETENCAO,
       NVL(NOF.FAT_NFO_VL_LIQUIDO,0) ,
       EXISTE_GUIA_SEM_PGTO.EXISTE_GUIA_SEM_PGTO,
       NVL(ANTECIPACAO.ISS,0) ,
       NVL(ANTECIPACAO.OP,0) ,
       (TO_DATE('||CHR(39)|| pDATA_CONTAB_FIM ||CHR(39)|| ') - NOF.FAT_NFO_DT_VENCIMENTO)+1 ,
       FNC_COB_PERIODO_VENCIMENTO(NOF.FAT_NFO_DT_VENCIMENTO,TO_DATE('||CHR(39)|| pDATA_CONTAB_FIM ||CHR(39)|| '),''0'') ,
       FNC_COB_PERIODO_VENCIMENTO(NOF.FAT_NFO_DT_VENCIMENTO,TO_DATE('||CHR(39)|| pDATA_CONTAB_FIM ||CHR(39)|| '),''1''),
       UNI.CODFILIAL
HAVING ((SUM(NVL(CCP.COB_CCP_VL_TOT_CONTA,0)) - SUM(NVL(CCP.COB_CCP_VL_ISS_FATURADO,0))) - (NVL(MGC.VALOR_DIGITADO,0)-NVL(MGC.COB_MGC_VL_ISS,0))+NVL(ANTECIPACAO.ISS,0) ) >= 0.0001'
  ;
   -- TESTE :=  V_SELECT ;
   --dbms_output.put_line(V_SELECT);
  OPEN v_cursor FOR
  -- SELECT 1 FROM DUAL;
   V_SELECT ;
    io_cursor := v_cursor;
  end PRC_COB_REL_23_VL_A_MENOR;
