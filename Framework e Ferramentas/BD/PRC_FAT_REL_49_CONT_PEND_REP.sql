CREATE OR REPLACE PROCEDURE "PRC_FAT_REL_49_CONT_PEND_REP"
(
    pATD_ATE_DT_ATENDIMENTO_INI VARCHAR2 DEFAULT NULL,
    pATD_ATE_DT_ATENDIMENTO_FIM VARCHAR2 DEFAULT NULL,
    pATD_ATE_FL_CARATER_SOLIC_U IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_FL_CARATER_SOLIC%TYPE DEFAULT NULL,
    pATD_ATE_FL_CARATER_SOLIC_E IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_FL_CARATER_SOLIC%TYPE DEFAULT NULL,
    pCAD_UNI_ID_UNIDADE IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
    pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
    pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
    pATD_ATE_TP_PACIENTE IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE DEFAULT NULL,
    pCAD_PRD_ID IN TB_CAD_PRD_PRODUTO.CAD_PRD_ID%TYPE DEFAULT NULL,
    pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE DEFAULT NULL,
    pCAD_PRO_ID_PROF_EXEC IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%TYPE DEFAULT NULL,
    pCAD_CNV_ID_CONVENIO     IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
    pCAD_PLA_ID_PLANO        IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE DEFAULT NULL,
    pCAD_UNI_ID_UNID_PROC    IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNID_PROC%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_GB IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL, --ACS
    pCAD_PLA_CD_TIPOPLANO_PL IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL, --ACS
    pCAD_PLA_CD_TIPOPLANO_FU IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_NP IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_PA IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_SP IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pATD_ATE_TP_PACIENTE_I IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE DEFAULT NULL,
    pATD_ATE_TP_PACIENTE_E IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE DEFAULT NULL,
    pATD_ATE_TP_PACIENTE_A IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE DEFAULT NULL,
    pATD_ATE_TP_PACIENTE_U IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE DEFAULT NULL,
    pFAT_CCP_MES_FAT IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_MES_FAT%TYPE DEFAULT NULL,
    pFAT_CCP_ANO_FAT IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ANO_FAT%TYPE DEFAULT NULL,
    pFATURADO   VARCHAR2 DEFAULT NULL,
    pLOTEGERADO VARCHAR2 DEFAULT NULL,
    pAUDITORIA  VARCHAR2 DEFAULT NULL,
    pEMITIDO    VARCHAR2 DEFAULT NULL,
    pDIGITADO   VARCHAR2 DEFAULT NULL,
    pALTA   VARCHAR2 DEFAULT NULL,
    pTIS_TAT_CD_TPATENDIMENTO IN TB_ATD_ATE_ATENDIMENTO.TIS_TAT_CD_TPATENDIMENTO%TYPE DEFAULT NULL,
    pCAD_MPF_ID VARCHAR2 DEFAULT NULL,
    IO_CURSOR OUT PKG_CURSOR.T_CURSOR--,
   -- TESTE OUT  LONG
)
IS
/********************************************************************
*    PROCEDURE: PRC_FAT_REL_49_CONT_PEND_REP
*
*    DATA Altera��o: 05/09/2013 POR: PEDRO
*    ALTERA��O: CUSTO
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(3000);
 -- V_WHERE2  varchar2(3000);
  V_SELECT  varchar2(30000);
  begin
    V_WHERE := NULL;
    IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND CCI.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE;    END IF;
    IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND CCI.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || pCAD_LAT_ID_LOCAL_ATENDIMENTO;    END IF;
    IF pCAD_SET_ID IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND ATE.CAD_SET_ID = ' || pCAD_SET_ID;    END IF;
    IF pCAD_CNV_ID_CONVENIO IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND CCI.CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO;    END IF;
    IF pCAD_PLA_ID_PLANO IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND PAC.CAD_PLA_ID_PLANO = ' || pCAD_PLA_ID_PLANO;    END IF;
    IF pFAT_CCP_MES_FAT IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND CCI.FAT_CCI_MES_FECHAMENTO = ' || pFAT_CCP_MES_FAT;    END IF;
    IF pFAT_CCP_ANO_FAT IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND CCI.FAT_CCI_ANO_FECHAMENTO = ' || pFAT_CCP_ANO_FAT;    END IF;
    IF pTIS_CBO_CD_CBOS IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND ATE.TIS_CBO_CD_CBOS = ' ||CHR(39)|| pTIS_CBO_CD_CBOS ||CHR(39);    END IF;
    IF pCAD_PRO_ID_PROF_EXEC IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND ATE.CAD_PRO_ID_PROF_EXEC = ' || pCAD_PRO_ID_PROF_EXEC;    END IF;
    IF pCAD_PRD_ID IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND CCI.CAD_PRD_ID = ' || pCAD_PRD_ID;    END IF;
    IF pATD_ATE_DT_ATENDIMENTO_INI IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND CCI.FAT_CCI_DT_INICIO_CONSUMO >= ' ||CHR(39)|| pATD_ATE_DT_ATENDIMENTO_INI ||CHR(39);    END IF;
    IF pATD_ATE_DT_ATENDIMENTO_FIM IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND CCI.FAT_CCI_DT_INICIO_CONSUMO <= ' ||CHR(39)|| pATD_ATE_DT_ATENDIMENTO_FIM ||CHR(39);    END IF;
    IF pCAD_UNI_ID_UNID_PROC IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND ATE.CAD_UNI_ID_UNID_PROC = ' || pCAD_UNI_ID_UNID_PROC;    END IF;
    IF pTIS_TAT_CD_TPATENDIMENTO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATE.TIS_TAT_CD_TPATENDIMENTO = ' ||CHR(39)|| pTIS_TAT_CD_TPATENDIMENTO ||CHR(39);    END IF;
    IF pCAD_MPF_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND (MPF.CAD_MPF_ID IN (SELECT COLUMN_VALUE FROM TABLE(FNC_SPLIT(' || CHR(39) || pCAD_MPF_ID || CHR(39) || ')))) ' ; END IF;
   V_SELECT :=
   '
     SELECT     CCI.FAT_CCI_ID,
            DECODE(CCI.ATD_ATE_TP_PACIENTE,'||CHR(39)||'A'||CHR(39)||','||CHR(39)||'AMBULATORIO'||CHR(39)||','||CHR(39)||'U'||CHR(39)||','||CHR(39)||'URGENCIA'||CHR(39)||','||CHR(39)||'I'||CHR(39)||','||CHR(39)||'INTERNADO'||CHR(39)||','||CHR(39)||'E'||CHR(39)||','||CHR(39)||'EXTERNO'||CHR(39)||') TP_PACIENTE,
            ATE.ATD_ATE_TP_PACIENTE,
            CNV.CAD_CNV_CD_HAC_PRESTADOR,
            CNV.CAD_CNV_NM_FANTASIA,
            PLA.CAD_PLA_CD_PLANO_HAC,
            PLA.CAD_PLA_NM_NOME_PLANO,
            UNI.CAD_UNI_DS_UNIDADE,
            UNI.CAD_UNI_CD_UNID_HOSPITALAR,
            LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
            TAT.TIS_TAT_DS_TPATENDIMENTO,
            PAC.CAD_PAC_NR_PRONTUARIO,
            ATE.ATD_ATE_ID,
            PES.CAD_PES_NM_PESSOA,
            TRUNC(ATE.ATD_ATE_DT_ATENDIMENTO) ATD_ATE_DT_ATENDIMENTO,
            ATE.ATD_ATE_HR_ATENDIMENTO,
            CCI.FAT_CCP_ID,
            PRO.CAD_PRO_NR_CONSELHO,
            PRO.CAD_PRO_NM_NOME,
            CCI.FAT_CCI_QT_CONSUMO,
            PRD.CAD_PRD_CD_CODIGO,
            PRD.CAD_PRD_DS_DESCRICAO,
            nvl(CCP.FAT_CCP_MES_FAT,cci.fat_cci_mes_fechamento) FAT_CCP_MES_FAT,
            nvl(CCP.FAT_CCP_ANO_FAT,cci.fat_cci_ANO_fechamento) FAT_CCP_ANO_FAT,
            MPF.CAD_MPF_FL_MOTIVO,
            MPF.CAD_MPF_DS_MOTI_PEND_FATURAR,
            CASE WHEN CCP.FAT_NOF_ID IS NOT NULL THEN '||CHR(39)||'FATURADO'||CHR(39)||'
                 WHEN CCP.FAT_CCP_FL_STATUS_AUDIT = '||CHR(39)||'E'||CHR(39)||' THEN '||CHR(39)||'EM ANALISE'||CHR(39)||'
                 WHEN CCP.FAT_CCP_FL_FATURADA = '||CHR(39)||'S'||CHR(39)||' AND CCP.FAT_NOF_ID IS NULL THEN '||CHR(39)||'LOTE GERADO'||CHR(39)||'
                 WHEN CCP.FAT_CCP_FL_EMITIDA = '||CHR(39)||'S'||CHR(39)||' AND CCP.FAT_CCP_FL_FATURADA = '||CHR(39)||'N'||CHR(39)||'
                      AND (CCP.FAT_CCP_FL_STATUS_AUDIT = '||CHR(39)||'A'||CHR(39)||' OR CCP.FAT_CCP_DT_ENVIO_AUDIT IS NULL) THEN '||CHR(39)||'EMITIDO'||CHR(39)||'
                 WHEN CCI.FAT_CCP_ID IS NULL THEN '||CHR(39)||'DIGITADO'||CHR(39)||'
            END SITUACAO
   FROM      TB_FAT_CCI_CONTA_CONSU_ITEM CCI
   LEFT JOIN TB_FAT_CCP_CONTA_CONS_PARC CCP
   ON        CCP.FAT_CCP_ID          = CCI.FAT_CCP_ID
   AND       CCP.ATD_ATE_ID          = CCI.ATD_ATE_ID
   AND       CCP.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
   AND       CCP.FAT_COC_ID          = CCI.FAT_COC_ID
   AND       (CCP.FAT_CCP_FL_STATUS   = '||CHR(39)||'A'||CHR(39)||')
    JOIN      TB_ATD_ATE_ATENDIMENTO      ATE   ON      ATE.ATD_ATE_ID                = CCI.ATD_ATE_ID
    JOIN      TB_CAD_PAC_PACIENTE         PAC   ON      PAC.CAD_PAC_ID_PACIENTE       = CCI.CAD_PAC_ID_PACIENTE
    JOIN      TB_CAD_PLA_PLANO            PLA   ON      PLA.CAD_PLA_ID_PLANO          = PAC.CAD_PLA_ID_PLANO
    JOIN      TB_CAD_CNV_CONVENIO         CNV   ON      CNV.CAD_CNV_ID_CONVENIO       = CCI.CAD_CNV_ID_CONVENIO
    JOIN      TB_CAD_PES_PESSOA           PES   ON      PAC.CAD_PES_ID_PESSOA         = PES.CAD_PES_ID_PESSOA
    JOIN      TB_TIS_TAT_TP_ATENDIMENTO   TAT   ON      TAT.TIS_TAT_CD_TPATENDIMENTO  = ATE.TIS_TAT_CD_TPATENDIMENTO
    JOIN      TB_CAD_UNI_UNIDADE          UNI   ON      UNI.CAD_UNI_ID_UNIDADE        = CCI.CAD_UNI_ID_UNIDADE
    JOIN      TB_CAD_LAT_LOCAL_ATENDIMENTO LAT  ON      LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = CCI.CAD_LAT_ID_LOCAL_ATENDIMENTO
    JOIN      TB_CAD_PRD_PRODUTO          PRD   ON      PRD.CAD_PRD_ID                = CCI.CAD_PRD_ID_COBRADO
    LEFT JOIN TB_CAD_PRO_PROFISSIONAL     PRO   ON      PRO.CAD_PRO_ID_PROFISSIONAL   = CCI.CAD_PRO_ID_PROFISSIONAL
    JOIN      TB_CAD_MPF_MOTI_PEND_FATURAR MPF  ON      MPF.CAD_MPF_ID                = CCI.CAD_MPF_ID
                                                AND     MPF.CAD_MPF_FL_MOTIVO         = '||CHR(39)||'P'||CHR(39)||'
   WHERE  (CCI.FAT_CCI_FL_STATUS = '||CHR(39)||'A'||CHR(39)||')
   AND    (CCI.FAT_CCI_TP_DESTINO_ITEM != '||CHR(39)||'H'||CHR(39)||')
   AND    (UNI.CAD_UNI_FL_FATURA_UNID_OK = '||CHR(39)||'S'||CHR(39)||')
   AND    (CCI.CAD_TAP_TP_ATRIBUTO != '||CHR(39)||'M2'||CHR(39)||')
       ' || V_WHERE || '
    AND    (' ||chr(39)|| pATD_ATE_FL_CARATER_SOLIC_U  ||chr(39)|| 'IS NOT NULL AND ATE.ATD_ATE_FL_CARATER_SOLIC = ' ||chr(39)|| 'U' ||chr(39)|| '
       OR ' ||chr(39)|| pATD_ATE_FL_CARATER_SOLIC_E ||chr(39)|| ' IS NOT NULL AND ATE.ATD_ATE_FL_CARATER_SOLIC = ' ||chr(39)|| 'E' ||chr(39)|| ')
    AND (' ||chr(39)|| pATD_ATE_TP_PACIENTE_A  ||chr(39)|| ' IS not NULL and CCI.ATD_ATE_TP_PACIENTE = ' ||chr(39)|| 'A' ||chr(39)|| '
     OR ' ||chr(39)|| pATD_ATE_TP_PACIENTE_U ||chr(39)|| ' IS NOT NULL AND CCI.ATD_ATE_TP_PACIENTE = ' ||chr(39)|| 'U' ||chr(39)|| '
     OR ' ||chr(39)|| pATD_ATE_TP_PACIENTE_I ||chr(39)|| ' IS NOT NULL AND CCI.ATD_ATE_TP_PACIENTE = ' ||chr(39)|| 'I' ||chr(39)|| '
     OR ' ||chr(39)|| pATD_ATE_TP_PACIENTE_E ||chr(39)|| ' IS NOT NULL AND CCI.ATD_ATE_TP_PACIENTE = ' ||chr(39)|| 'E' ||chr(39)|| ')
    AND (' ||chr(39)|| pCAD_PLA_CD_TIPOPLANO_GB  ||chr(39)|| ' IS not NULL and PLA.CAD_PLA_CD_TIPOPLANO = ' ||chr(39)|| 'GB' ||chr(39)|| '
     OR ' ||chr(39)||  pCAD_PLA_CD_TIPOPLANO_PL  ||chr(39)|| ' IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = ' ||chr(39)|| 'PL' ||chr(39)|| '
     OR ' ||chr(39)||  pCAD_PLA_CD_TIPOPLANO_PA  ||chr(39)|| ' IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = ' ||chr(39)|| 'PA' ||chr(39)|| '
     OR ' ||chr(39)||  pCAD_PLA_CD_TIPOPLANO_SP  ||chr(39)|| ' IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = ' ||chr(39)|| 'SP' ||chr(39)|| '
     OR ' ||chr(39)||  pCAD_PLA_CD_TIPOPLANO_NP  ||chr(39)|| ' IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = ' ||chr(39)|| 'NP' ||chr(39)|| '
     OR ' ||chr(39)||  pCAD_PLA_CD_TIPOPLANO_FU  ||chr(39)|| ' IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = ' ||chr(39)|| 'FU' ||chr(39)|| ')    
     AND     ((' ||chr(39)|| pFATURADO ||chr(39)|| ' IS NOT NULL AND CCP.FAT_NOF_ID IS NOT NULL )
      OR  (' ||chr(39)|| pAUDITORIA ||chr(39)|| ' IS NOT NULL AND CCP.FAT_CCP_FL_STATUS_AUDIT = ' ||chr(39)|| 'E' ||chr(39)|| ')
      OR  (' ||chr(39)|| pLOTEGERADO ||chr(39)|| ' IS NOT NULL AND CCP.FAT_CCP_FL_FATURADA = ' ||chr(39)|| 'S' ||chr(39)|| ' AND CCP.FAT_NOF_ID IS NULL)
      OR  (' ||chr(39)|| pEMITIDO ||chr(39)|| ' IS NOT NULL AND CCP.FAT_CCP_FL_EMITIDA = ' ||chr(39)|| 'S' ||chr(39)|| ' AND CCP.FAT_CCP_FL_FATURADA = ' ||chr(39)|| 'N' ||chr(39)|| '
          AND (CCP.FAT_CCP_FL_STATUS_AUDIT = ' ||chr(39)|| 'A' ||chr(39)|| ' OR CCP.FAT_CCP_DT_ENVIO_AUDIT IS NULL))
      OR  (' ||chr(39)|| pDIGITADO ||chr(39)|| ' IS NOT NULL AND CCI.FAT_CCP_ID IS NULL))
    ORDER   BY  TRUNC(ATE.ATD_ATE_DT_ATENDIMENTO) DESC';
   -- TESTE :=  V_SELECT ;
OPEN v_cursor FOR
   V_SELECT ;
    io_cursor := v_cursor;
END PRC_FAT_REL_49_CONT_PEND_REP;
 