CREATE OR REPLACE PROCEDURE PRC_FAT_REL_PREVIA_FATURAD
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
    io_cursor OUT PKG_CURSOR.t_cursor
)
IS
/********************************************************************
*    Procedure: PRC_FAT_REL_PREVIA_FATURAD
*
*    FAT_05  e   fat_32
*
*    Data Alteracao: 27/4/2011  Por: Pedro
*    Alterac?o: TUDO
*
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(3000);
   V_WHERE2  varchar2(3000);
  V_SELECT  varchar2(30000);
begin
  V_WHERE := NULL;
IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATE.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE; END IF;
IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || pCAD_LAT_ID_LOCAL_ATENDIMENTO; END IF;
IF pCAD_SET_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATE.CAD_SET_ID = ' || pCAD_SET_ID; END IF;
IF pCAD_CNV_ID_CONVENIO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND PAC.CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO;    END IF;
IF pCAD_PLA_ID_PLANO IS NOT NULL THEN    V_WHERE := V_WHERE || ' AND PAC.CAD_PLA_ID_PLANO = ' || pCAD_PLA_ID_PLANO;    END IF;
IF pFAT_CCP_MES_FAT IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CCP.FAT_CCP_MES_FAT = ' || pFAT_CCP_MES_FAT; END IF;
IF pFAT_CCP_ANO_FAT IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CCP.FAT_CCP_ANO_FAT = ' || pFAT_CCP_ANO_FAT; END IF;
IF pTIS_TAT_CD_TPATENDIMENTO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATE.TIS_TAT_CD_TPATENDIMENTO = ' ||CHR(39)|| pTIS_TAT_CD_TPATENDIMENTO ||CHR(39); END IF;
IF pATD_ATE_DT_ATENDIMENTO_INI IS NOT NULL THEN V_WHERE := V_WHERE || ' AND CCI.FAT_CCI_DT_INICIO_CONSUMO >= ' ||CHR(39)|| pATD_ATE_DT_ATENDIMENTO_INI ||CHR(39);    END IF;
IF pATD_ATE_DT_ATENDIMENTO_FIM IS NOT NULL THEN V_WHERE := V_WHERE || ' AND CCI.FAT_CCI_DT_FIM_CONSUMO <= ' ||CHR(39)|| pATD_ATE_DT_ATENDIMENTO_FIM ||CHR(39);    END IF;
IF pTIS_CBO_CD_CBOS IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATE.TIS_CBO_CD_CBOS <= ' ||CHR(39)|| pTIS_CBO_CD_CBOS ||CHR(39);    END IF;
V_WHERE2 := NULL;
IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN V_WHERE2:= V_WHERE2 || ' AND NOF.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE; END IF;
IF pCAD_CNV_ID_CONVENIO IS NOT NULL THEN V_WHERE2 := V_WHERE2 || ' AND NOF.CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO;    END IF;
IF pCAD_PLA_ID_PLANO IS NOT NULL THEN    V_WHERE2 := V_WHERE2 || ' AND NOF.CAD_PLA_ID_PLANO = ' || pCAD_PLA_ID_PLANO;    END IF;
V_SELECT:=
'
 SELECT     CASE WHEN TIPO_PLANO IN ('||chr(39)||'ACS'||chr(39)||') THEN '||chr(39)||'ANA COSTA SAUDE'||chr(39)||'
                 WHEN TIPO_PLANO IN ('||chr(39)||'SP'||chr(39)||')  THEN '||chr(39)||'SERVICO PRESTADO'||chr(39)||'
                 WHEN TIPO_PLANO IN ('||chr(39)||'PA'||chr(39)||')  THEN '||chr(39)||'PARTICULAR'||chr(39)||'
                 WHEN TIPO_PLANO IN ('||chr(39)||'FU'||chr(39)||')  THEN '||chr(39)||'FUNCIONARIO HAC'||chr(39)||'
                 WHEN TIPO_PLANO IN ('||chr(39)||'FU-S077'||chr(39)||')  THEN '||chr(39)||'FUNCIONARIO ACS'||chr(39)||'
                 WHEN TIPO_PLANO IN ('||chr(39)||'NP'||chr(39)||')  THEN '||chr(39)||'NAO PAGANTE'||chr(39)||'
            END  TIPO_PLANO,
            CAD_LAT_ID_LOCAL_ATENDIMENTO,
            CAD_LAT_DS_LOCAL_ATENDIMENTO,
            CAD_UNI_ID_UNIDADE,
            CAD_UNI_DS_UNIDADE,
            QTDE,
            FATURADOS,
            CASE WHEN TIPO_PLANO IN ('||chr(39)||'FU'||chr(39)||','||chr(39)||'NP'||chr(39)||','||chr(39)||'FU-S077'||chr(39)||') THEN 1 ELSE 0 END DESPESA_RECEITA, --0Receita  1Despesa
            CASE WHEN CAD_LAT_ID_LOCAL_ATENDIMENTO != 29 THEN '||chr(39)||'AMBULATORIO'||chr(39)||' ELSE '||chr(39)||'INTERNADO'||chr(39)||' END LOCAL_ATENDIMENTO,
            NULL SERVICOS_ADM,
           NULL ESTAGIOS,
           NULL CURSOS
  FROM
  (
    SELECT
             QTDE.TIPO_PLANO,
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
     LEFT JOIN (        SELECT  COUNT(DISTINCT CCP.ATD_ATE_ID||CCP.FAT_CCP_ID||PAC.CAD_CNV_ID_CONVENIO) TOTAL_QTD,
                                SUM(CCP.FAT_CCP_VL_TOT_CONTA) TOTAL_FAT,
      ATE.CAD_UNI_ID_UNIDADE, ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO,
      CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('||chr(39)||'GB'||chr(39)||','||chr(39)||'PL'||chr(39)||') THEN '||chr(39)||'ACS'||chr(39)||'
                          WHEN PLA.CAD_PLA_CD_PLANO_HAC = ''S077'' AND 
                            PLA.CAD_PLA_CD_TIPOPLANO IN (''FU'') THEN ''FU-S077'' ELSE PLA.CAD_PLA_CD_TIPOPLANO END TIPO_PLANO

             FROM    TB_FAT_CCP_CONTA_CONS_PARC CCP
              JOIN    TB_ATD_ATE_ATENDIMENTO       ATE
              ON      CCP.ATD_ATE_ID             = ATE.ATD_ATE_ID
              JOIN    TB_CAD_PAC_PACIENTE          PAC
              ON      PAC.CAD_PAC_ID_PACIENTE    = CCP.CAD_PAC_ID_PACIENTE
              JOIN    TB_CAD_PLA_PLANO             PLA
              ON      PLA.CAD_PLA_ID_PLANO       = PAC.CAD_PLA_ID_PLANO
              WHERE   (CCP.FAT_CCP_FL_FATURADA = '||chr(39)||'S'||chr(39)||')
              AND     (ATE.ATD_ATE_FL_STATUS = '||chr(39)||'A'||chr(39)||')
              AND     (CCP.FAT_CCP_FL_STATUS = '||chr(39)||'A'||chr(39)||')
              AND     (CCP.FAT_NOF_ID IS NOT NULL)
              ' || V_WHERE || '
           AND ('||chr(39)|| pATD_ATE_TP_PACIENTE_I ||chr(39)||' IS not NULL and ate.atd_ate_tp_paciente = '||chr(39)||'I'||chr(39)||'
           OR '||chr(39)|| pATD_ATE_TP_PACIENTE_E ||chr(39)||' IS NOT NULL AND ate.atd_ate_tp_paciente = '||chr(39)||'E'||chr(39)||'
           OR '||chr(39)|| pATD_ATE_TP_PACIENTE_A ||chr(39)||' IS NOT NULL AND ate.atd_ate_tp_paciente = '||chr(39)||'A'||chr(39)||'
           OR '||chr(39)|| pATD_ATE_TP_PACIENTE_U ||chr(39)||' IS NOT NULL AND ate.atd_ate_tp_paciente = '||chr(39)||'U'||chr(39)||')
       AND    ('||chr(39)|| pCAD_PLA_CD_TIPOPLANO_GB ||chr(39)||' IS not NULL and PLA.CAD_PLA_CD_TIPOPLANO = '||chr(39)||'GB'||chr(39)||'
         OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_PL ||chr(39)||' IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = '||chr(39)||'PL'||chr(39)||'
         OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_PA ||chr(39)||' IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = '||chr(39)||'PA'||chr(39)||'
         OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_SP ||chr(39)||' IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = '||chr(39)||'SP'||chr(39)||'
         OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_FU ||chr(39)||' IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = '||chr(39)||'FU'||chr(39)||'
         OR '||chr(39)|| pCAD_PLA_CD_TIPOPLANO_NP ||chr(39)||' IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = '||chr(39)||'NP'||chr(39)||')
               GROUP BY ATE.CAD_UNI_ID_UNIDADE, ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO,
               CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('||chr(39)||'GB'||chr(39)||','||chr(39)||'PL'||chr(39)||') THEN '||chr(39)||'ACS'||chr(39)||'
               WHEN PLA.CAD_PLA_CD_PLANO_HAC = ''S077'' AND PLA.CAD_PLA_CD_TIPOPLANO IN (''FU'') THEN ''FU-S077'' ELSE PLA.CAD_PLA_CD_TIPOPLANO END
            ) QTDE
            ON QTDE.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
           AND QTDE.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
    WHERE   UNI.CAD_UNI_FL_FATURA_UNID_OK = '||chr(39)||'S'||chr(39)||'
    )
    WHERE (QTDE > 0 OR FATURADOS > 0)
UNION
 SELECT   '||chr(39)||'PARTICULAR'||chr(39)||' TIPO_PLANO,
           27 CAD_LAT_ID_LOCAL_ATENDIMENTO,
           '||chr(39)||'AMBULATORIO'||chr(39)||' CAD_LAT_DS_LOCAL_ATENDIMENTO ,
           U.CAD_UNI_ID_UNIDADE,
           U.CAD_UNI_DS_UNIDADE,
           COUNT(1) QTDE,
           SUM(NVL(F.VALTOTNF,0) + NVL(F.VL_DESCONTO_ISS,0)) FATURADOS,
             0 DESPESA_RECEITA,
          '||chr(39)||'AMBULATORIO'||chr(39)||' LOCAL_ATENDIMENTO ,
           NULL SERVICOS_ADM,
           NULL ESTAGIOS,
           NULL CURSOS
           FROM  TB_NOTA_FISCAL F, TB_CAD_UNI_UNIDADE U
           WHERE F.TIPONF = '||chr(39)||'AMB'||chr(39)||'
           AND F.CODUNIHOS = U.CAD_UNI_CD_UNID_HOSPITALAR
           AND TO_CHAR(DATNF,'||chr(39)||'mmyyyy'||chr(39)||') = trim(to_char('||chr(39)||pFAT_CCP_MES_FAT||chr(39)||','||chr(39)||'00'||chr(39)||') || to_char('||chr(39)||pFAT_CCP_ANO_FAT||chr(39)||'))
           AND F.SITNF != '||chr(39)||'C'||chr(39)||'
           AND NOT (F.CODCXA = 2 AND F.CODUNIHOS = 6)
           AND ('||chr(39)|| pCAD_UNI_ID_UNIDADE ||chr(39)||' IS NULL OR U.CAD_UNI_ID_UNIDADE = '||chr(39)|| pCAD_UNI_ID_UNIDADE ||chr(39)||' )
           AND (
               ('||chr(39)|| pCAD_PLA_CD_TIPOPLANO_PA ||chr(39)||' IS NOT NULL)
               OR (rownum =0)
               )
           GROUP BY U.CAD_UNI_ID_UNIDADE, U.CAD_UNI_DS_UNIDADE
           HAVING NVL(SUM(F.VALTOTNF),0) > 0
     UNION
       SELECT
      NULL TIPO_PLANO,
      NULL CAD_LAT_ID_LOCAL_ATENDIMENTO,
      NULL CAD_LAT_DS_LOCAL_ATENDIMENTO,
      NULL CAD_UNI_ID_UNIDADE,
      NULL CAD_UNI_DS_UNIDADE,
      NULL QTDE,
      NULL FATURADOS,
      0 DESPESA_RECEITA,
      NULL LOCAL_ATENDIMENTO,
      NVL(SUM(NOF.FAT_NFO_VL_FATURADO),0) SERVICOS_ADM,
      NULL ESTAGIOS,
      NULL CURSOS
      FROM TB_CAD_PLA_PLANO PLA, TB_CAD_CNV_CONVENIO CNV, TB_FAT_NOF_NOTA_FISCAL NOF,
           TB_CAD_UNI_UNIDADE UNI
      WHERE
          NOF.FAT_NOF_MES_FAT    = '||chr(39)|| pFAT_CCP_MES_FAT ||chr(39)||'
      AND NOF.FAT_NOF_ANO_FAT    = '||chr(39)|| pFAT_CCP_ANO_FAT ||chr(39)||'
      AND NOF.CAD_CNV_ID_CONVENIO   = PLA.CAD_CNV_ID_CONVENIO
      AND CNV.CAD_CNV_ID_CONVENIO   = PLA.CAD_CNV_ID_CONVENIO
      AND NOF.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
      AND NOF.FAT_NOF_FL_STATUS = '||chr(39)||'A'||chr(39)||'
      AND (CNV.CAD_CNV_CD_HAC_PRESTADOR = '||chr(39)||'S186'||chr(39)||')
      ' || v_where2 ||'
    UNION
     SELECT
      NULL TIPO_PLANO,
      NULL CAD_LAT_ID_LOCAL_ATENDIMENTO,
      NULL CAD_LAT_DS_LOCAL_ATENDIMENTO,
      NULL CAD_UNI_ID_UNIDADE,
      NULL CAD_UNI_DS_UNIDADE,
      NULL QTDE,
      NULL FATURADOS,
      0 DESPESA_RECEITA,
      NULL LOCAL_ATENDIMENTO,
      NULL SERVICOS_ADM,
      NVL(SUM(NOF.FAT_NFO_VL_FATURADO),0) ESTAGIOS,
      NULL CURSOS
      FROM TB_CAD_PLA_PLANO PLA, TB_CAD_CNV_CONVENIO CNV, TB_FAT_NOF_NOTA_FISCAL NOF,
           TB_CAD_UNI_UNIDADE UNI
      WHERE
          NOF.FAT_NOF_MES_FAT    = '||chr(39)|| pFAT_CCP_MES_FAT ||chr(39)||'
      AND NOF.FAT_NOF_ANO_FAT    = '||chr(39)|| pFAT_CCP_ANO_FAT ||chr(39)||'
      AND NOF.CAD_CNV_ID_CONVENIO   = PLA.CAD_CNV_ID_CONVENIO
      AND CNV.CAD_CNV_ID_CONVENIO   = PLA.CAD_CNV_ID_CONVENIO
      AND NOF.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
      AND NOF.FAT_NOF_FL_STATUS = '||chr(39)||'A'||chr(39)||'
      AND (CNV.CAD_CNV_CD_HAC_PRESTADOR in ('||chr(39)||'FESS'||chr(39)||','||chr(39)||'VALE'||chr(39)||','||chr(39)||'FUL1'||chr(39)||'))
       ' || v_where2 || '
     UNION
    SELECT
      NULL TIPO_PLANO,
      NULL CAD_LAT_ID_LOCAL_ATENDIMENTO,
      NULL CAD_LAT_DS_LOCAL_ATENDIMENTO,
      NULL CAD_UNI_ID_UNIDADE,
      NULL CAD_UNI_DS_UNIDADE,
      NULL QTDE,
      NULL FATURADOS,
      0 DESPESA_RECEITA,
      NULL LOCAL_ATENDIMENTO,
      NULL SERVICOS_ADM,
      NULL ESTAGIOS,
      NVL(SUM(nf.Valtotnf),0) CURSOS
      FROM tb_nota_fiscal nf,
           TB_CAD_UNI_UNIDADE UNI
      WHERE
          nF.Codunihos = UNI.CAD_UNI_CD_UNID_HOSPITALAR
      AND to_number(TO_CHAR(nf.datnf,'||chr(39)||'MM'||chr(39)||')) = nvl('||chr(39)|| pFAT_CCP_MES_FAT ||chr(39)||',0)
      AND to_number(TO_CHAR(nf.datnf,'||chr(39)||'yyyy'||chr(39)||')) = nvl('||chr(39)|| pFAT_CCP_ANO_FAT ||chr(39)||',0)
      AND nf.tiponf = '||chr(39)||'TXC'||chr(39)||'
      AND NF.SITNF != '||chr(39)||'C'||chr(39)||'
      AND ( '||chr(39)|| pCAD_UNI_ID_UNIDADE ||chr(39)||' IS NULL OR uNI.CAD_UNI_ID_UNIDADE = '||chr(39)|| pCAD_UNI_ID_UNIDADE ||chr(39)||' )
  ORDER   BY 3'
   ;
   -- TESTE :=  V_SELECT ;
  OPEN v_cursor FOR
   V_SELECT ;
    io_cursor := v_cursor;
END PRC_FAT_REL_PREVIA_FATURAD;
/