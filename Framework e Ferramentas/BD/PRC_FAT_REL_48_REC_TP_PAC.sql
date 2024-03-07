CREATE OR REPLACE PROCEDURE "PRC_FAT_REL_48_REC_TP_PAC"
(
    pATD_ATE_DT_ATENDIMENTO_INI VARCHAR2 DEFAULT NULL,
    pATD_ATE_DT_ATENDIMENTO_FIM VARCHAR2 DEFAULT NULL,
    pCAD_UNI_ID_UNIDADE VARCHAR2 DEFAULT NULL,
    pCAD_LAT_ID_LOCAL_ATENDIMENTO VARCHAR2 DEFAULT NULL,
    pCAD_SET_ID VARCHAR2 DEFAULT NULL,
    pTIS_TAT_CD_TPATENDIMENTO IN TB_TIS_TAT_TP_ATENDIMENTO.TIS_TAT_CD_TPATENDIMENTO%TYPE DEFAULT NULL,
    pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE DEFAULT NULL,
    pCAD_CNV_ID_CONVENIO VARCHAR2 DEFAULT NULL,
    pCAD_PLA_ID_PLANO VARCHAR2 DEFAULT NULL,
    pFAT_CCP_MES_FAT VARCHAR2 DEFAULT NULL,
    pFAT_CCP_ANO_FAT VARCHAR2 DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_GB VARCHAR2 DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_PL VARCHAR2 DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_FU VARCHAR2 DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_PA VARCHAR2 DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_SP VARCHAR2 DEFAULT NULL,
    pCAD_PLA_CD_TIPOPLANO_NP VARCHAR2 DEFAULT NULL,
    pATD_ATE_TP_PACIENTE_A VARCHAR2 DEFAULT NULL,
    pATD_ATE_TP_PACIENTE_U VARCHAR2 DEFAULT NULL,
    pATD_ATE_TP_PACIENTE_I VARCHAR2 DEFAULT NULL,
    pATD_ATE_TP_PACIENTE_E VARCHAR2 DEFAULT NULL,
    io_cursor OUT PKG_CURSOR.t_cursor
   --, TESTE OUT  LONG 
)
IS
/********************************************************************
*    Procedure: PRC_FAT_REL_48_REC_TP_PAC  ------->>>>> FAT_48
*
*    Data aLT: 6/09/2013  Por: Pedro H. A. C.
*    Alteração: custo
*
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(1000);
  V_WHERE2  varchar2(1000);
  V_WHERE3  varchar2(1000);
  V_SELECT  varchar2(30000);
  begin
    V_WHERE := NULL;
    IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN V_WHERE := V_WHERE || ' AND CCI.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE;    END IF;
    IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND CCI.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || pCAD_LAT_ID_LOCAL_ATENDIMENTO;    END IF;
    IF pCAD_CNV_ID_CONVENIO IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND CCI.CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO;    END IF;
    IF pCAD_PLA_ID_PLANO IS NOT NULL THEN       V_WHERE := V_WHERE || ' AND PAC.CAD_PLA_ID_PLANO = ' || pCAD_PLA_ID_PLANO;    END IF;
 V_WHERE2 := NULL;    
 IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN       V_WHERE2 := V_WHERE2 || ' AND U.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE;    END IF;
    IF (pATD_ATE_TP_PACIENTE_A IS NULL) OR (pCAD_PLA_CD_TIPOPLANO_PA IS NULL) OR 
       (pCAD_CNV_ID_CONVENIO IS NOT NULL AND pCAD_CNV_ID_CONVENIO != 282) OR 
       (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL AND pCAD_LAT_ID_LOCAL_ATENDIMENTO != 27) THEN
       V_WHERE2 := V_WHERE2 || ' AND ROWNUM = 0 ' ;
    END IF;
  V_WHERE3 := NULL;
    IF (pCAD_PLA_CD_TIPOPLANO_GB IS NULL) OR
       (pATD_ATE_TP_PACIENTE_A IS NULL AND pATD_ATE_TP_PACIENTE_U IS NULL) OR
       (pCAD_UNI_ID_UNIDADE IS NOT NULL AND pCAD_UNI_ID_UNIDADE != 248) OR 
       (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL OR pCAD_LAT_ID_LOCAL_ATENDIMENTO != 27) OR 
       (pCAD_CNV_ID_CONVENIO IS NOT NULL AND pCAD_CNV_ID_CONVENIO != 281) 
          THEN
       V_WHERE3 := V_WHERE3 || ' AND ROWNUM = 0 ' ;
    END IF;
    V_SELECT := '
   SELECT DISTINCT
       TIPO_PLANO,
       DESPESA_RECEITA,
       LOCAL_ATENDIMENTO,
       CAD_LAT_DS_LOCAL_ATENDIMENTO,
       CAD_UNI_ID_UNIDADE,
       CAD_UNI_DS_UNIDADE,
       ATD_ATE_TP_PACIENTE,
       SUM(FATURADO) OVER (PARTITION BY TIPO_PLANO,DESPESA_RECEITA,LOCAL_ATENDIMENTO,CAD_LAT_DS_LOCAL_ATENDIMENTO, CAD_UNI_ID_UNIDADE, CAD_UNI_DS_UNIDADE, ATD_ATE_TP_PACIENTE) FATURADO ,
       SUM(CALCULADO) OVER (PARTITION BY TIPO_PLANO,DESPESA_RECEITA,LOCAL_ATENDIMENTO,CAD_LAT_DS_LOCAL_ATENDIMENTO, CAD_UNI_ID_UNIDADE, CAD_UNI_DS_UNIDADE, ATD_ATE_TP_PACIENTE) CALCULADO,
       SUM(QTD_CONTAS) OVER (PARTITION BY TIPO_PLANO,DESPESA_RECEITA,LOCAL_ATENDIMENTO,CAD_LAT_DS_LOCAL_ATENDIMENTO, CAD_UNI_ID_UNIDADE, CAD_UNI_DS_UNIDADE, ATD_ATE_TP_PACIENTE) QTD_CONTAS
  FROM
  (
    SELECT
           CASE WHEN TP_PLA.CAD_TPE_CD_CODIGO IN (' ||chr(39)|| 'ACS' ||chr(39)|| ') THEN ' ||chr(39)|| 'ANA COSTA SAUDE' ||chr(39)|| '
                 WHEN TP_PLA.CAD_TPE_CD_CODIGO IN (' ||chr(39)|| 'SP' ||chr(39)|| ')  THEN ' ||chr(39)|| 'SERVIÇO PRESTADO' ||chr(39)|| '
                 WHEN TP_PLA.CAD_TPE_CD_CODIGO IN (' ||chr(39)|| 'PA' ||chr(39)|| ')  THEN ' ||chr(39)|| 'PARTICULAR' ||chr(39)|| '
                 WHEN TP_PLA.CAD_TPE_CD_CODIGO IN (' ||chr(39)|| 'FU' ||chr(39)|| ')  THEN ' ||chr(39)|| 'FUNCIONARIO' ||chr(39)|| '
                 WHEN TP_PLA.CAD_TPE_CD_CODIGO IN (' ||chr(39)|| 'NP' ||chr(39)|| ')  THEN ' ||chr(39)|| 'NAO PAGANTE' ||chr(39)|| '
            END  TIPO_PLANO,
            CASE WHEN TP_PLA.CAD_TPE_CD_CODIGO IN (' ||chr(39)|| 'FU' ||chr(39)|| ',' ||chr(39)|| 'NP' ||chr(39)|| ') THEN 1 ELSE 0 END DESPESA_RECEITA,
            CASE WHEN LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO != ' || 29 || ' THEN ' ||chr(39)|| 'AMBULATORIO' ||chr(39)|| ' ELSE ' ||chr(39)|| 'INTERNADO' ||chr(39)|| ' END LOCAL_ATENDIMENTO,
            LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
            UNI.CAD_UNI_ID_UNIDADE,
            CASE WHEN UNI.CAD_UNI_ID_UNIDADE = 244 AND DIFERENCA.DIF = ' ||chr(39)|| 'COMDIF' ||chr(39)|| ' AND TP_PLA.CAD_TPE_CD_CODIGO = ' ||chr(39)|| 'PA' ||chr(39)|| ' THEN ' ||chr(39)|| 'DIF. DE CLASSE - SANTOS' ||chr(39)|| '
                 WHEN UNI.CAD_UNI_ID_UNIDADE = 247 AND DIFERENCA.DIF = ' ||chr(39)|| 'COMDIF' ||chr(39)|| ' AND TP_PLA.CAD_TPE_CD_CODIGO = ' ||chr(39)|| 'PA' ||chr(39)|| ' THEN ' ||chr(39)|| 'DIF. DE CLASSE - S.VICENTE' ||chr(39)|| '
                 WHEN UNI.CAD_UNI_ID_UNIDADE = 245 AND DIFERENCA.DIF = ' ||chr(39)|| 'COMDIF' ||chr(39)|| ' AND TP_PLA.CAD_TPE_CD_CODIGO = ' ||chr(39)|| 'PA' ||chr(39)|| ' THEN ' ||chr(39)|| 'DIF. DE CLASSE - GUARUJÁ' ||chr(39)|| '
                 ELSE UNI.CAD_UNI_DS_UNIDADE
            END CAD_UNI_DS_UNIDADE,
            DIFERENCA.DIF,
            DECODE(TP_ATD.ATD_ATE_TP_PACIENTE,' ||chr(39)|| 'A' ||chr(39)|| ',' ||chr(39)|| 'AMBULATORIO' ||chr(39)|| ',' ||chr(39)|| 'U' ||chr(39)|| ',' ||chr(39)|| 'URGENCIA' ||chr(39)|| ',' ||chr(39)|| 'E' ||chr(39)|| ',' ||chr(39)|| 'EXTERNO' ||chr(39)|| ',' ||chr(39)|| 'I' ||chr(39)|| ',' ||chr(39)|| 'INTERNO' ||chr(39)|| ' ) ATD_ATE_TP_PACIENTE,
            EMITIDOS.FATURADO ,
            EMITIDOS.CALCULADO,
            EMITIDOS.QTD_CONTAS
    FROM    TB_CAD_UNI_UNIDADE UNI
    JOIN    TB_ASS_ULO_UNID_LOCAL ULO             ON      UNI.CAD_UNI_ID_UNIDADE           = ULO.CAD_UNI_ID_UNIDADE
    JOIN    TB_CAD_LAT_LOCAL_ATENDIMENTO LAT      ON      ULO.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
    JOIN    (SELECT DISTINCT CNV.CAD_TPE_CD_CODIGO FROM TB_CAD_CNV_CONVENIO CNV) TP_PLA    ON  1 = 1 
    JOIN    (SELECT ' ||chr(39)|| 'SEMDIF' ||chr(39)|| ' DIF FROM DUAL union SELECT ' ||chr(39)|| 'COMDIF' ||chr(39)|| ' DIF FROM DUAL) DIFERENCA    ON   1 = 1 
    JOIN    (SELECT DISTINCT ATE.ATD_ATE_TP_PACIENTE  FROM TB_ATD_ATE_ATENDIMENTO ATE) TP_ATD    ON   1 = 1 
    LEFT JOIN (  SELECT  SUM(CCI.FAT_CCI_VL_FATURADO) FATURADO,
                         SUM(CCI.FAT_CCI_VL_CALCULADO) CALCULADO,
                         COUNT(DISTINCT CCI.ATD_ATE_ID||CCI.FAT_CCP_ID||CCI.CAD_CNV_ID_CONVENIO) QTD_CONTAS,
                        CCI.CAD_UNI_ID_UNIDADE,
                        CCI.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                        CCI.ATD_ATE_TP_PACIENTE,
                        CNV.CAD_TPE_CD_CODIGO,
                        CASE WHEN MCC.FAT_TCO_ID !=  10  THEN ' ||chr(39)|| 'SEMDIF' ||chr(39)|| '
                             WHEN MCC.FAT_TCO_ID =  10   THEN ' ||chr(39)|| 'COMDIF' ||chr(39)|| '
                         END  DIF
              FROM    TB_FAT_CCI_CONTA_CONSU_ITEM  CCI
              JOIN    TB_CAD_CNV_CONVENIO          CNV  ON      CNV.CAD_CNV_ID_CONVENIO    = CCI.CAD_CNV_ID_CONVENIO
              JOIN    TB_CAD_PAC_PACIENTE          PAC  ON      PAC.CAD_PAC_ID_PACIENTE    = CCI.CAD_PAC_ID_PACIENTE
              JOIN    TB_FAT_CCP_CONTA_CONS_PARC   CCP  ON      CCP.ATD_ATE_ID             = CCI.ATD_ATE_ID
                                                        AND     CCP.CAD_PAC_ID_PACIENTE    = CCI.CAD_PAC_ID_PACIENTE
                                                        AND     CCP.FAT_CCP_ID             = CCI.FAT_CCP_ID
                                                        AND     CCP.FAT_COC_ID             = CCI.FAT_COC_ID
                                                        AND     (CCP.FAT_CCP_FL_STATUS     = ' ||chr(39)|| 'A' ||chr(39)|| ')
                                                        AND     (CCP.FAT_CCP_MES_FAT       = ' ||chr(39)|| pFAT_CCP_MES_FAT ||chr(39)|| ')
                                                        AND     (CCP.FAT_CCP_ANO_FAT       = ' ||chr(39)|| pFAT_CCP_ANO_FAT ||chr(39)|| ')
                                                        AND     (CCP.FAT_NOF_ID IS NOT NULL)
              JOIN    TB_FAT_MCC_MOV_COM_CONSUMO   MCC  ON      MCC.FAT_MCC_ID             = CCI.FAT_MCC_ID
                                                        AND     MCC.ATD_ATE_ID             = CCI.ATD_ATE_ID                                                      
              WHERE
                      CCI.FAT_CCI_FL_STATUS = ' ||chr(39)|| 'A' ||chr(39)|| '
              AND     (CCI.FAT_CCI_FL_PACOTE = ' ||chr(39)|| 'N' ||chr(39)|| ' OR CCI.FAT_CCI_FL_PACOTE IS NULL)
              AND     (CCI.FAT_CCI_TP_DESTINO_ITEM not in (' ||chr(39)|| 'H' ||chr(39)|| ',' ||chr(39)|| 'T' ||chr(39)|| '))
              AND     (CCI.FAT_CCI_MES_FECHAMENTO = ' ||chr(39)|| pFAT_CCP_MES_FAT ||chr(39)|| ')
              AND     (CCI.FAT_CCI_ANO_FECHAMENTO = ' ||chr(39)|| pFAT_CCP_ANO_FAT ||chr(39)|| ')              
              '
              || V_WHERE ||
              '
              AND (' ||chr(39)|| pATD_ATE_TP_PACIENTE_A  ||chr(39)|| ' IS not NULL and CCI.ATD_ATE_TP_PACIENTE = ' ||chr(39)|| 'A' ||chr(39)|| '
               OR ' ||chr(39)|| pATD_ATE_TP_PACIENTE_U ||chr(39)|| ' IS NOT NULL AND CCI.ATD_ATE_TP_PACIENTE = ' ||chr(39)|| 'U' ||chr(39)|| '
               OR ' ||chr(39)|| pATD_ATE_TP_PACIENTE_I ||chr(39)|| ' IS NOT NULL AND CCI.ATD_ATE_TP_PACIENTE = ' ||chr(39)|| 'I' ||chr(39)|| '
               OR ' ||chr(39)|| pATD_ATE_TP_PACIENTE_E ||chr(39)|| ' IS NOT NULL AND CCI.ATD_ATE_TP_PACIENTE = ' ||chr(39)|| 'E' ||chr(39)|| ')
              AND (' ||chr(39)|| pCAD_PLA_CD_TIPOPLANO_GB  ||chr(39)|| ' IS not NULL and CNV.CAD_TPE_CD_CODIGO = ' ||chr(39)|| 'ACS' ||chr(39)|| '
               OR ' ||chr(39)||  pCAD_PLA_CD_TIPOPLANO_PA  ||chr(39)|| ' IS NOT NULL AND CNV.CAD_TPE_CD_CODIGO = ' ||chr(39)|| 'PA' ||chr(39)|| '
               OR ' ||chr(39)||  pCAD_PLA_CD_TIPOPLANO_SP  ||chr(39)|| ' IS NOT NULL AND CNV.CAD_TPE_CD_CODIGO = ' ||chr(39)|| 'SP' ||chr(39)|| '
               OR ' ||chr(39)||  pCAD_PLA_CD_TIPOPLANO_NP  ||chr(39)|| ' IS NOT NULL AND CNV.CAD_TPE_CD_CODIGO = ' ||chr(39)|| 'NP' ||chr(39)|| '
               OR ' ||chr(39)||  pCAD_PLA_CD_TIPOPLANO_FU  ||chr(39)|| ' IS NOT NULL AND CNV.CAD_TPE_CD_CODIGO = ' ||chr(39)|| 'FU' ||chr(39)|| ')
              GROUP BY
                      CCI.CAD_UNI_ID_UNIDADE,
                      CCI.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                      CCI.ATD_ATE_TP_PACIENTE,
                      CNV.CAD_TPE_CD_CODIGO,
                      CASE WHEN MCC.FAT_TCO_ID !=  10 THEN ' ||chr(39)|| 'SEMDIF' ||chr(39)|| '
                           WHEN MCC.FAT_TCO_ID = 10  THEN ' ||chr(39)|| 'COMDIF' ||chr(39)|| '
                      END
            ) EMITIDOS
            ON  EMITIDOS.CAD_UNI_ID_UNIDADE           = UNI.CAD_UNI_ID_UNIDADE
            AND EMITIDOS.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
            AND EMITIDOS.CAD_TPE_CD_CODIGO         = TP_PLA.CAD_TPE_CD_CODIGO
            AND EMITIDOS.DIF                          = DIFERENCA.DIF
            AND EMITIDOS.ATD_ATE_TP_PACIENTE          = TP_ATD.ATD_ATE_TP_PACIENTE
    WHERE   UNI.CAD_UNI_FL_FATURA_UNID_OK = ' ||chr(39)|| 'S' ||chr(39)|| ' AND (EMITIDOS.FATURADO > 0 or EMITIDOS.CALCULADO > 0 )
  UNION all
   SELECT   
           '||chr(39)||'ANA COSTA SAUDE'||chr(39)||' TIPO_PLANO,
            0 DESPESA_RECEITA,
            '||chr(39)||'AMBULATORIO'||chr(39)||' LOCAL_ATENDIMENTO,
            '||chr(39)||'AMBULATORIO'||chr(39)||' CAD_LAT_DS_LOCAL_ATENDIMENTO,
            248 CAD_UNI_ID_UNIDADE,
            '||chr(39)||'AMB. SANTOS - Consultorio'||chr(39)||' CAD_UNI_DS_UNIDADE,
            '||chr(39)||'SEMDIF'||chr(39)||' DIF,
            '||chr(39)||'AMBULATORIO'||chr(39)||' ATD_ATE_TP_PACIENTE,
            0 FATURADO ,
            SUM(VL_CALCULADO)    CALCULADO,
            COUNT(*) QTD_CONTAS
              FROM    ATEN_CONS_PART               ACP
              JOIN    TB_CAD_PLA_PLANO PLA ON PLA.CAD_PLA_CD_PLANO_HAC = ACP.CODCON
              WHERE TO_CHAR(ACP.DATFAT, '||chr(39)||'MMYYYY'||chr(39)||')  = trim(to_char('||chr(39)|| pFAT_CCP_MES_FAT||chr(39)||','||chr(39)||'00'||chr(39)||') || to_char('||chr(39)||pFAT_CCP_ANO_FAT||chr(39)||'))
             ' || V_WHERE3 || '
  UNION ALL     
    SELECT  ' ||chr(39)|| 'PARTICULAR' ||chr(39)|| ' TIPO_PLANO,
            0 DESPESA_RECEITA,
            ' ||chr(39)|| 'AMBULATORIO' ||chr(39)|| ' LOCAL_ATENDIMENTO,
            ' ||chr(39)|| 'AMBULATORIO' ||chr(39)|| ' CAD_LAT_DS_LOCAL_ATENDIMENTO,
            UNI.CAD_UNI_ID_UNIDADE,
            UNI.CAD_UNI_DS_UNIDADE,
            NULL DIF,
            ' ||chr(39)|| 'AMBULATORIO' ||chr(39)|| ' ATD_ATE_TP_PACIENTE,
            FATURADOS_NOF.TOTAL_FAT FATURADO,
            FATURADOS_NOF.TOTAL_FAT CALCULADO,
            FATURADOS_NOF.QTD_CONTAS
    FROM    TB_CAD_UNI_UNIDADE UNI
    JOIN    TB_ASS_ULO_UNID_LOCAL ULO        ON   UNI.CAD_UNI_ID_UNIDADE = ULO.CAD_UNI_ID_UNIDADE
                                             AND  ULO.CAD_LAT_ID_LOCAL_ATENDIMENTO =  27 
    LEFT JOIN (SELECT  U.CAD_UNI_ID_UNIDADE, U.CAD_UNI_DS_UNIDADE, COUNT(*) QTD_CONTAS,SUM(NVL(F.VALTOTNF,0)) + SUM(NVL(F.VL_DESCONTO_ISS,0)) TOTAL_FAT
           FROM  TB_NOTA_FISCAL F, TB_CAD_UNI_UNIDADE U
           WHERE F.TIPONF = ' ||chr(39)|| 'AMB' ||chr(39)|| '
           AND F.CODUNIHOS = U.CAD_UNI_CD_UNID_HOSPITALAR
           AND TO_CHAR(F.DATNF,' ||chr(39)|| 'mmyyyy' ||chr(39)|| ') = trim(to_char(' ||chr(39)|| pFAT_CCP_MES_FAT ||chr(39)||','||chr(39)||'00'||chr(39)||') || to_char(' ||chr(39)|| pFAT_CCP_ANO_FAT ||chr(39)|| '))
           AND F.SITNF != ' ||chr(39)|| 'C' ||chr(39)|| '
           AND NOT (F.CODCXA = 2 AND F.CODUNIHOS =  6 )
           '
           || V_WHERE2 ||
           '
             GROUP BY  U.CAD_UNI_ID_UNIDADE, U.CAD_UNI_DS_UNIDADE
           HAVING (SUM(NVL(F.VALTOTNF, 0 )) + SUM(NVL(F.VL_DESCONTO_ISS,  0 ))) >  0 
            ) FATURADOS_NOF
         ON FATURADOS_NOF.CAD_UNI_ID_UNIDADE   = UNI.CAD_UNI_ID_UNIDADE         
    WHERE UNI.CAD_UNI_FL_STATUS = ' ||chr(39)|| 'A' ||chr(39)|| ' AND UNI.CAD_UNI_FL_FATURA_UNID_OK = ' ||chr(39)|| 'S' ||chr(39)|| ' AND FATURADOS_NOF.TOTAL_FAT > 0
    )
    WHERE (FATURADO >  0  or CALCULADO > 0)';
  -- TESTE :=  V_SELECT ;
 OPEN v_cursor FOR
   V_SELECT ;
  -- SELECT 1 FROM DUAL;
    io_cursor := v_cursor;
END PRC_FAT_REL_48_REC_TP_PAC;
 