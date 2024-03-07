CREATE OR REPLACE PROCEDURE "PRC_FAT_REL_45_PREV_UNI"
(
    pCAD_UNI_ID_UNIDADE IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
    pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
    pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
    pTIS_TAT_CD_TPATENDIMENTO IN TB_TIS_TAT_TP_ATENDIMENTO.TIS_TAT_CD_TPATENDIMENTO%TYPE DEFAULT NULL,
    pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE DEFAULT NULL,
    pFAT_CCP_MES_FAT IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_MES_FAT%TYPE DEFAULT NULL,
    pFAT_CCP_ANO_FAT IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ANO_FAT%TYPE DEFAULT NULL,
    pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
    pCAD_PLA_ID_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_GB IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_PL IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_FU IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_PA IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_SP IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_NP IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pATD_ATE_DT_ATENDIMENTO_INI IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
    pATD_ATE_DT_ATENDIMENTO_FIM IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
    pATD_ATE_TP_PACIENTE_I in tb_atd_ate_atendimento.atd_ate_tp_paciente%type default null,
    pATD_ATE_TP_PACIENTE_E in tb_atd_ate_atendimento.atd_ate_tp_paciente%type default null,
    pATD_ATE_TP_PACIENTE_A in tb_atd_ate_atendimento.atd_ate_tp_paciente%type default null,
    pATD_ATE_TP_PACIENTE_U in tb_atd_ate_atendimento.atd_ate_tp_paciente%type default null,
    pFATURADO   VARCHAR2 DEFAULT NULL, 
    pLOTEGERADO VARCHAR2 DEFAULT NULL,
    pAUDITORIA  VARCHAR2 DEFAULT NULL,
    pEMITIDO    VARCHAR2 DEFAULT NULL,
    pDIGITADO   VARCHAR2 DEFAULT NULL,
    io_cursor OUT PKG_CURSOR.t_cursor
    -- , TESTE OUT  LONG 
)
IS
/********************************************************************
*    Procedure: PRC_FAT_REL_45_PREV_UNI
*
*    Data Alteracao: 29/6/2011  Por: Pedro
*    Altera��o: diminuicao de custo -> v_select
*
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(2000);
  V_WHERE2  varchar2(500);
  V_SELECT  varchar2(20000);
  begin
    V_WHERE := NULL;
    IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND CCI.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE;    END IF;
    IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND CCI.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || pCAD_LAT_ID_LOCAL_ATENDIMENTO;    END IF;
    IF pCAD_SET_ID IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND ATE.CAD_SET_ID = ' || pCAD_SET_ID;    END IF;
    IF pFAT_CCP_MES_FAT IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND CCI.FAT_CCI_MES_FECHAMENTO = ' || pFAT_CCP_MES_FAT;    END IF;
    IF pFAT_CCP_ANO_FAT IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND CCI.FAT_CCI_ANO_FECHAMENTO = ' || pFAT_CCP_ANO_FAT;    END IF;
    IF pCAD_CNV_ID_CONVENIO IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND CCI.CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO;    END IF;
    IF pCAD_PLA_ID_PLANO IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND PAC.CAD_PLA_ID_PLANO = ' || pCAD_PLA_ID_PLANO;    END IF;    
    IF pATD_ATE_DT_ATENDIMENTO_INI IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND ATE.ATD_ATE_DT_ATENDIMENTO >= ' ||CHR(39)|| pATD_ATE_DT_ATENDIMENTO_INI ||CHR(39);    END IF;
    IF pATD_ATE_DT_ATENDIMENTO_FIM IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND ATE.ATD_ATE_DT_ATENDIMENTO <= ' ||CHR(39)|| pATD_ATE_DT_ATENDIMENTO_FIM ||CHR(39);    END IF;
    IF pTIS_TAT_CD_TPATENDIMENTO IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND ATE.TIS_TAT_CD_TPATENDIMENTO = ' ||CHR(39)|| pTIS_TAT_CD_TPATENDIMENTO ||CHR(39);    END IF;
    IF pTIS_CBO_CD_CBOS IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND ATE.TIS_CBO_CD_CBOS = ' ||CHR(39)|| pTIS_CBO_CD_CBOS ||CHR(39);    END IF;

    V_WHERE2 := NULL;    
    IF pFAT_CCP_MES_FAT IS NOT NULL THEN       V_WHERE2 := V_WHERE2 || ' AND CCP.FAT_CCP_MES_FAT = ' || pFAT_CCP_MES_FAT;    END IF;
    IF pFAT_CCP_ANO_FAT IS NOT NULL THEN       V_WHERE2 := V_WHERE2 || ' AND CCP.FAT_CCP_ANO_FAT = ' || pFAT_CCP_ANO_FAT;    END IF;
    
    V_SELECT := 
   '
 SELECT     TIPO_PLANO,
            CAD_LAT_ID_LOCAL_ATENDIMENTO,
            CAD_LAT_DS_LOCAL_ATENDIMENTO,
            CAD_UNI_ID_UNIDADE,
            CAD_UNI_DS_UNIDADE,
            QTDE,
            FATURADOS,
            --0 DESPESA_RECEITA,
            CASE WHEN TIPO_PLANO IN (' ||CHR(39)|| 'FU' ||CHR(39)|| ',' ||CHR(39)|| 'NP' ||CHR(39)|| ') THEN 1 ELSE 0 END DESPESA_RECEITA,
            CASE WHEN CAD_LAT_ID_LOCAL_ATENDIMENTO != 29 THEN ' ||CHR(39)|| 'AMBULATORIO' ||CHR(39)|| ' ELSE ' ||CHR(39)|| 'INTERNADO' ||CHR(39)|| ' END LOCAL_ATENDIMENTO,
            NULL SERVICOS_ADM
  FROM
  (
    SELECT  QTDE.TIPO_PLANO,
            LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO,
            LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
            UNI.CAD_UNI_ID_UNIDADE,
            UNI.CAD_UNI_DS_UNIDADE,
            NVL(QTDE.TOTAL_QTD,0) QTDE,
            NVL(QTDE.TOTAL_FAT,0) FATURADOS
    FROM    TB_CAD_UNI_UNIDADE UNI
    JOIN    TB_ASS_ULO_UNID_LOCAL ULO
    ON      UNI.CAD_UNI_ID_UNIDADE = ULO.CAD_UNI_ID_UNIDADE
    JOIN    TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
    ON      ULO.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
     LEFT JOIN (        SELECT  COUNT(DISTINCT CCI.ATD_ATE_ID||cci.FAT_CCP_ID||CCI.CAD_CNV_ID_CONVENIO) TOTAL_QTD,
                         SUM(CCI.FAT_CCI_VL_FATURADO) TOTAL_FAT,
                         CCI.CAD_UNI_ID_UNIDADE, CCI.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                         CNV.CAD_TPE_CD_CODIGO TIPO_PLANO
             FROM    TB_FAT_CCI_CONTA_CONSU_ITEM CCI
             LEFT JOIN TB_FAT_CCP_CONTA_CONS_PARC   CCP
              ON      CCP.FAT_CCP_ID             = CCI.FAT_CCP_ID
              AND     CCP.ATD_ATE_ID             = CCI.ATD_ATE_ID
              AND     CCP.CAD_PAC_ID_PACIENTE    = CCI.CAD_PAC_ID_PACIENTE
              AND     CCP.FAT_COC_ID             = CCI.FAT_COC_ID
              AND     CCP.FAT_CCP_FL_STATUS      = ' ||CHR(39)|| 'A' ||CHR(39)|| '
              ' || V_WHERE2 || '
              JOIN    TB_ATD_ATE_ATENDIMENTO       ATE
              ON      CCI.ATD_ATE_ID             = ATE.ATD_ATE_ID
              JOIN    TB_CAD_PAC_PACIENTE          PAC
              ON      PAC.CAD_PAC_ID_PACIENTE    = CCI.CAD_PAC_ID_PACIENTE
              JOIN    TB_CAD_CNV_CONVENIO          CNV
              ON      CNV.CAD_CNV_ID_CONVENIO     = CCI.CAD_CNV_ID_CONVENIO
              WHERE   (CCI.FAT_CCI_FL_STATUS = ' ||CHR(39)|| 'A' ||CHR(39)|| ')
              AND     ((CCI.FAT_CCI_FL_PACOTE IS NULL) OR (CCI.FAT_CCI_FL_PACOTE = ' ||CHR(39)|| 'N' ||CHR(39)|| '))
              ' || V_WHERE || '
             AND     ((' ||CHR(39)|| pFATURADO ||CHR(39)|| ' IS NOT NULL AND CCP.FAT_NOF_ID IS NOT NULL )
                  OR  (' ||CHR(39)|| pAUDITORIA ||CHR(39)|| ' IS NOT NULL AND CCP.FAT_CCP_FL_STATUS_AUDIT = ' ||CHR(39)|| 'E' ||CHR(39)|| ')
                  OR  (' ||CHR(39)|| pLOTEGERADO ||CHR(39)|| ' IS NOT NULL AND CCP.FAT_CCP_FL_FATURADA = ' ||CHR(39)|| 'S' ||CHR(39)|| ' AND CCP.FAT_NOF_ID IS NULL)
                  OR  (' ||CHR(39)|| pEMITIDO ||CHR(39)|| ' IS NOT NULL AND CCP.FAT_CCP_FL_EMITIDA = ' ||CHR(39)|| 'S' ||CHR(39)|| ' AND CCP.FAT_CCP_FL_FATURADA = ' ||CHR(39)|| 'N' ||CHR(39)|| '
                      AND (CCP.FAT_CCP_FL_STATUS_AUDIT = ' ||CHR(39)|| 'A' ||CHR(39)|| ' OR CCP.FAT_CCP_DT_ENVIO_AUDIT IS NULL))
                  OR  (' ||CHR(39)|| pDIGITADO ||CHR(39)|| ' IS NOT NULL AND CCI.FAT_CCP_ID IS NULL))
              AND     (' ||CHR(39)|| pATD_ATE_TP_PACIENTE_I ||CHR(39)|| ' IS not NULL and CCI.atd_ate_tp_paciente = ' ||CHR(39)|| 'I' ||CHR(39)|| '
                OR     ' ||CHR(39)|| pATD_ATE_TP_PACIENTE_E ||CHR(39)|| ' IS NOT NULL AND CCI.atd_ate_tp_paciente = ' ||CHR(39)|| 'E' ||CHR(39)|| '
                OR     ' ||CHR(39)|| pATD_ATE_TP_PACIENTE_A ||CHR(39)|| ' IS NOT NULL AND CCI.atd_ate_tp_paciente = ' ||CHR(39)|| 'A' ||CHR(39)|| '
                OR     ' ||CHR(39)|| pATD_ATE_TP_PACIENTE_U ||CHR(39)|| ' IS NOT NULL AND CCI.atd_ate_tp_paciente = ' ||CHR(39)|| 'U' ||CHR(39)|| ' )
             AND (' ||chr(39)|| pCAD_PLA_CD_TIPOPLANO_GB  ||chr(39)|| ' IS not NULL and CNV.CAD_TPE_CD_CODIGO = ' ||chr(39)|| 'ACS' ||chr(39)|| '
               OR ' ||chr(39)||  pCAD_PLA_CD_TIPOPLANO_PA  ||chr(39)|| ' IS NOT NULL AND CNV.CAD_TPE_CD_CODIGO = ' ||chr(39)|| 'PA' ||chr(39)|| '
               OR ' ||chr(39)||  pCAD_PLA_CD_TIPOPLANO_SP  ||chr(39)|| ' IS NOT NULL AND CNV.CAD_TPE_CD_CODIGO = ' ||chr(39)|| 'SP' ||chr(39)|| '
               OR ' ||chr(39)||  pCAD_PLA_CD_TIPOPLANO_NP  ||chr(39)|| ' IS NOT NULL AND CNV.CAD_TPE_CD_CODIGO = ' ||chr(39)|| 'NP' ||chr(39)|| '
               OR ' ||chr(39)||  pCAD_PLA_CD_TIPOPLANO_FU  ||chr(39)|| ' IS NOT NULL AND CNV.CAD_TPE_CD_CODIGO = ' ||chr(39)|| 'FU' ||chr(39)|| ')
               GROUP BY CCI.CAD_UNI_ID_UNIDADE, CCI.CAD_LAT_ID_LOCAL_ATENDIMENTO,CNV.CAD_TPE_CD_CODIGO
            ) QTDE
            ON QTDE.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
           AND QTDE.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
    WHERE   UNI.CAD_UNI_FL_FATURA_UNID_OK = ' ||CHR(39)|| 'S' ||CHR(39)|| '
    )
    WHERE (QTDE > 0 OR FATURADOS > 0)
  ORDER   BY 5'
  ;  
  -- TESTE :=  V_SELECT ;
OPEN v_cursor FOR
    V_SELECT ;
    --  SELECT 1 FROM DUAL;
    io_cursor := v_cursor;
END PRC_FAT_REL_45_PREV_UNI;
 