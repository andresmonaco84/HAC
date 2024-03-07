CREATE OR REPLACE PROCEDURE SGS."PRC_FAT_REL_VL_RECEITA_UNI"
(
    pCAD_UNI_ID_UNIDADE IN VARCHAR2 DEFAULT NULL,
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
    io_cursor OUT PKG_CURSOR.t_cursor
)
IS
/********************************************************************
*    Procedure: PRC_FAT_REL_VL_RECEITA_UNI  -------------------------------->>>>>>>>>>>>>>>> FAT_43
*
*    Data Criac?o: 21/10/2011  Por: Pedro
*    Alterac?o: cursos,estagios,servicos_adm
*
* essa proc e parente da PRC_FAT_REL_PREVIA_FATURAD(FAT_05) ;)
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
BEGIN
  OPEN v_cursor FOR
 SELECT      CASE WHEN TIPO_PLANO IN ('ACS') THEN 'ANA COSTA SAUDE'
                 WHEN TIPO_PLANO IN ('SP') THEN 'SERVICO PRESTADO'
                 WHEN TIPO_PLANO IN ('PA') THEN 'PARTICULAR'
                 WHEN TIPO_PLANO IN ('FU') THEN 'FUNCIONARIO'
                 WHEN TIPO_PLANO IN ('NP') THEN 'NAO PAGANTE'
            END  TIPO_PLANO,
            CASE WHEN TIPO_PLANO IN ('FU','NP') THEN 1 ELSE 0 END DESPESA_RECEITA, --0Receita  1Despesa
            CASE WHEN CAD_LAT_ID_LOCAL_ATENDIMENTO not in (29,46) THEN 'AMBULATORIO' ELSE 'INTERNADO' END LOCAL_ATENDIMENTO,
            CAD_LAT_DS_LOCAL_ATENDIMENTO,
            CAD_UNI_ID_UNIDADE,
            CAD_UNI_DS_UNIDADE,
            QTDE,
            FATURADOS,
            NULL SERVICOS_ADM,
            NULL ESTAGIOS,
            NULL CURSOS
  FROM
  (
    SELECT  DISTINCT CASE WHEN TP_PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' ELSE Tp_PLA.CAD_PLA_CD_TIPOPLANO END TIPO_PLANO,
            LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO,
            LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
            UNI.CAD_UNI_ID_UNIDADE,
            UNI.CAD_UNI_DS_UNIDADE,
            NVL(QTDE.TOTAL,0) QTDE,
            NVL(FATURADOS.TOTAL,0) FATURADOS
    FROM    TB_CAD_UNI_UNIDADE UNI
    JOIN    TB_ASS_ULO_UNID_LOCAL ULO
    ON      UNI.CAD_UNI_ID_UNIDADE = ULO.CAD_UNI_ID_UNIDADE
    JOIN    TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
    ON      ULO.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
    JOIN    (SELECT DISTINCT PLA.CAD_PLA_CD_TIPOPLANO FROM TB_CAD_PLA_PLANO PLA) TP_PLA
    ON      1 = 1
     LEFT JOIN (        SELECT  COUNT(DISTINCT CCP.ATD_ATE_ID|| CCP.FAT_CCP_ID|| PAC.CAD_CNV_ID_CONVENIO) TOTAL,
                         ATE.CAD_UNI_ID_UNIDADE, ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                          CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' ELSE PLA.CAD_PLA_CD_TIPOPLANO END CAD_PLA_CD_TIPOPLANO
             FROM    TB_FAT_CCP_CONTA_CONS_PARC CCP
              JOIN    TB_ATD_ATE_ATENDIMENTO       ATE
              ON      CCP.ATD_ATE_ID             = ATE.ATD_ATE_ID
              JOIN    TB_CAD_PAC_PACIENTE          PAC
              ON      PAC.CAD_PAC_ID_PACIENTE    = CCP.CAD_PAC_ID_PACIENTE
              JOIN    TB_CAD_PLA_PLANO             PLA
              ON      PLA.CAD_PLA_ID_PLANO       = PAC.CAD_PLA_ID_PLANO
              WHERE   (CCP.FAT_CCP_FL_FATURADA = 'S')
              AND     (ATE.ATD_ATE_FL_STATUS = 'A')
              AND     (CCP.FAT_CCP_FL_STATUS = 'A')
              AND     (CCP.FAT_NOF_ID IS NOT NULL)
             AND     (pCAD_UNI_ID_UNIDADE IS NULL OR ATE.CAD_UNI_ID_UNIDADE IN (select column_value from table(fnc_split(pCAD_UNI_ID_UNIDADE))))
              AND     (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
              AND     (pCAD_SET_ID IS NULL OR ATE.CAD_SET_ID = pCAD_SET_ID)
              AND     (FAT_CCP_MES_FAT = pFAT_CCP_MES_FAT)
              AND     (FAT_CCP_ANO_FAT = pFAT_CCP_ANO_FAT)
              AND     (pTIS_TAT_CD_TPATENDIMENTO IS NULL OR ATE.TIS_TAT_CD_TPATENDIMENTO = pTIS_TAT_CD_TPATENDIMENTO)
              AND     (pTIS_CBO_CD_CBOS IS NULL OR ATE.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS)
              AND     (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
              AND     (pCAD_PLA_ID_PLANO IS NULL OR PAC.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
              AND (pCAD_PLA_CD_TIPOPLANO_GB IS not NULL and PLA.CAD_PLA_CD_TIPOPLANO = 'GB'
               OR pCAD_PLA_CD_TIPOPLANO_PL IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PL'
           --    OR pCAD_PLA_CD_TIPOPLANO_PA IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PA'
               OR pCAD_PLA_CD_TIPOPLANO_SP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'SP'
               OR pCAD_PLA_CD_TIPOPLANO_NP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'NP'
               OR pCAD_PLA_CD_TIPOPLANO_FU IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'FU')
               GROUP BY ATE.CAD_UNI_ID_UNIDADE, ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' ELSE PLA.CAD_PLA_CD_TIPOPLANO END
            ) QTDE
            ON QTDE.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
           AND QTDE.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
           AND QTDE.CAD_PLA_CD_TIPOPLANO = CASE WHEN TP_PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' ELSE TP_PLA.CAD_PLA_CD_TIPOPLANO END
           left join  (
              SELECT  SUM(CCP.FAT_CCP_VL_TOT_CONTA) TOTAL, ATE.CAD_UNI_ID_UNIDADE, ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO,
               CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' ELSE PLA.CAD_PLA_CD_TIPOPLANO END CAD_PLA_CD_TIPOPLANO
              FROM    TB_FAT_CCP_CONTA_CONS_PARC CCP
              JOIN    TB_ATD_ATE_ATENDIMENTO       ATE
              ON      CCP.ATD_ATE_ID             = ATE.ATD_ATE_ID
              JOIN    TB_CAD_PAC_PACIENTE          PAC
              ON      PAC.CAD_PAC_ID_PACIENTE    = CCP.CAD_PAC_ID_PACIENTE
              JOIN    TB_CAD_PLA_PLANO             PLA
              ON      PLA.CAD_PLA_ID_PLANO       = PAC.CAD_PLA_ID_PLANO
              WHERE   (CCP.FAT_CCP_FL_FATURADA = 'S')
              AND     (ATE.ATD_ATE_FL_STATUS = 'A')
              AND     (CCP.FAT_CCP_FL_STATUS = 'A')
              AND     (CCP.FAT_NOF_ID IS NOT NULL)
              AND     (pCAD_UNI_ID_UNIDADE IS NULL OR ATE.CAD_UNI_ID_UNIDADE IN (select column_value from table(fnc_split(pCAD_UNI_ID_UNIDADE))))
              AND     (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
              AND     (pCAD_SET_ID IS NULL OR ATE.CAD_SET_ID = pCAD_SET_ID)
              AND     (FAT_CCP_MES_FAT = pFAT_CCP_MES_FAT)
              AND     (FAT_CCP_ANO_FAT = pFAT_CCP_ANO_FAT)
              AND     (pTIS_TAT_CD_TPATENDIMENTO IS NULL OR ATE.TIS_TAT_CD_TPATENDIMENTO = pTIS_TAT_CD_TPATENDIMENTO)
              AND     (pTIS_CBO_CD_CBOS IS NULL OR ATE.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS)
              AND     (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
              AND     (pCAD_PLA_ID_PLANO IS NULL OR PAC.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
              AND (pCAD_PLA_CD_TIPOPLANO_GB IS not NULL and PLA.CAD_PLA_CD_TIPOPLANO = 'GB'
               OR pCAD_PLA_CD_TIPOPLANO_PL IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PL'
           --    OR pCAD_PLA_CD_TIPOPLANO_PA IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PA'
               OR pCAD_PLA_CD_TIPOPLANO_SP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'SP'
               OR pCAD_PLA_CD_TIPOPLANO_NP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'NP'
               OR pCAD_PLA_CD_TIPOPLANO_FU IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'FU')
              GROUP BY  ATE.CAD_UNI_ID_UNIDADE,  ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO,
               CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' ELSE PLA.CAD_PLA_CD_TIPOPLANO END
            ) FATURADOS
          ON FATURADOS.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
         AND FATURADOS.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND FATURADOS.CAD_PLA_CD_TIPOPLANO = CASE WHEN TP_PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'ACS' ELSE TP_PLA.CAD_PLA_CD_TIPOPLANO END
    WHERE   UNI.CAD_UNI_FL_FATURA_UNID_OK = 'S'
    )
    WHERE (QTDE > 0 OR FATURADOS > 0)
 UNION
    SELECT       'PARTICULAR' TIPO_PLANO, --SEM DIFERENCA DE CLASSE
                 0 DESPESA_RECEITA,
            CASE WHEN CAD_LAT_ID_LOCAL_ATENDIMENTO not in (29,46) THEN 'AMBULATORIO' ELSE 'INTERNADO' END LOCAL_ATENDIMENTO,
            CAD_LAT_DS_LOCAL_ATENDIMENTO,
            CAD_UNI_ID_UNIDADE,
            CAD_UNI_DS_UNIDADE,
            QTDE,
            FATURADOS,
            NULL SERVICOS_ADM,
            NULL ESTAGIOS,
            NULL CURSOS
  FROM
  (
    SELECT  LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO,
            LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
            UNI.CAD_UNI_ID_UNIDADE,
            UNI.CAD_UNI_DS_UNIDADE,
            NVL(QTDE.TOTAL,0) QTDE,
            NVL(FATURADOS.TOTAL,0) FATURADOS
    FROM    TB_CAD_UNI_UNIDADE UNI
    JOIN    TB_ASS_ULO_UNID_LOCAL ULO
    ON      UNI.CAD_UNI_ID_UNIDADE = ULO.CAD_UNI_ID_UNIDADE
    JOIN    TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
    ON      ULO.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
     LEFT JOIN (        SELECT  COUNT(DISTINCT CCP.ATD_ATE_ID|| CCP.FAT_CCP_ID|| PAC.CAD_CNV_ID_CONVENIO) TOTAL, ATE.CAD_UNI_ID_UNIDADE, ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO
             FROM    TB_FAT_CCP_CONTA_CONS_PARC CCP
              JOIN    TB_ATD_ATE_ATENDIMENTO       ATE
              ON      CCP.ATD_ATE_ID             = ATE.ATD_ATE_ID
              JOIN    TB_CAD_PAC_PACIENTE          PAC
              ON      PAC.CAD_PAC_ID_PACIENTE    = CCP.CAD_PAC_ID_PACIENTE
              JOIN    TB_CAD_PLA_PLANO             PLA
              ON      PLA.CAD_PLA_ID_PLANO       = PAC.CAD_PLA_ID_PLANO
              JOIN    TB_FAT_COC_CONTA_CONSUMO     COC
              ON      COC.ATD_ATE_ID             = CCP.ATD_ATE_ID
              AND     COC.CAD_PAC_ID_PACIENTE    = CCP.CAD_PAC_ID_PACIENTE
              AND     COC.FAT_COC_ID             = CCP.FAT_COC_ID
              JOIN    TB_FAT_CCI_CONTA_CONSU_ITEM  CCI
              ON      CCI.ATD_ATE_ID             = CCP.ATD_ATE_ID
              AND     CCI.CAD_PAC_ID_PACIENTE    = CCP.CAD_PAC_ID_PACIENTE
              AND     CCI.FAT_CCP_ID             = CCP.FAT_CCP_ID
              AND     CCI.FAT_COC_ID             = CCP.FAT_COC_ID
              JOIN    TB_FAT_MCC_MOV_COM_CONSUMO   MCC
              ON      MCC.FAT_MCC_ID             = CCI.FAT_MCC_ID
              AND     MCC.ATD_ATE_ID             = CCI.ATD_ATE_ID
              WHERE   (CCP.FAT_CCP_FL_FATURADA = 'S')
              AND     (ATE.ATD_ATE_FL_STATUS = 'A')
              AND     (CCP.FAT_CCP_FL_STATUS = 'A')
              AND     (COC.FAT_COC_FL_STATUS = 'A')
              AND     (CCP.FAT_NOF_ID IS NOT NULL)
              AND     CCI.FAT_CCI_FL_STATUS      = 'A'
--              AND     CCI.FAT_CCI_FL_FATURADO    = 'S'
              AND     (CCI.FAT_CCI_FL_PACOTE = 'N' OR CCI.FAT_CCI_FL_PACOTE IS NULL)
              AND     (CCI.FAT_CCI_TP_DESTINO_ITEM != 'H')
              AND     (MCC.FAT_TCO_ID            != 10)
              AND     (MCC.FAT_MCC_FL_STATUS     = 'A')
             AND     (pCAD_UNI_ID_UNIDADE IS NULL OR ATE.CAD_UNI_ID_UNIDADE IN (select column_value from table(fnc_split(pCAD_UNI_ID_UNIDADE))))
              AND     (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
              AND     (pCAD_SET_ID IS NULL OR ATE.CAD_SET_ID = pCAD_SET_ID)
              AND     (FAT_CCP_MES_FAT = pFAT_CCP_MES_FAT)
              AND     (FAT_CCP_ANO_FAT = pFAT_CCP_ANO_FAT)
              AND     (pTIS_TAT_CD_TPATENDIMENTO IS NULL OR ATE.TIS_TAT_CD_TPATENDIMENTO = pTIS_TAT_CD_TPATENDIMENTO)
              AND     (pTIS_CBO_CD_CBOS IS NULL OR ATE.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS)
              AND     (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
              AND     (pCAD_PLA_ID_PLANO IS NULL OR PAC.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
              AND     (
                      (pCAD_PLA_CD_TIPOPLANO_PA IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO IN ('PA'))
                      OR (PLA.CAD_PLA_CD_TIPOPLANO IS NULL)
                      )
               GROUP BY ATE.CAD_UNI_ID_UNIDADE, ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO
            ) QTDE
            ON QTDE.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
           AND QTDE.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
           left join  (
              SELECT  SUM(CCI.FAT_CCI_VL_FATURADO) TOTAL, ATE.CAD_UNI_ID_UNIDADE, ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO
             FROM    TB_FAT_CCP_CONTA_CONS_PARC CCP
              JOIN    TB_ATD_ATE_ATENDIMENTO       ATE
              ON      CCP.ATD_ATE_ID             = ATE.ATD_ATE_ID
              JOIN    TB_CAD_PAC_PACIENTE          PAC
              ON      PAC.CAD_PAC_ID_PACIENTE    = CCP.CAD_PAC_ID_PACIENTE
              JOIN    TB_CAD_PLA_PLANO             PLA
              ON      PLA.CAD_PLA_ID_PLANO       = PAC.CAD_PLA_ID_PLANO
              JOIN    TB_FAT_COC_CONTA_CONSUMO     COC
              ON      COC.ATD_ATE_ID             = CCP.ATD_ATE_ID
              AND     COC.CAD_PAC_ID_PACIENTE    = CCP.CAD_PAC_ID_PACIENTE
              AND     COC.FAT_COC_ID             = CCP.FAT_COC_ID
              JOIN    TB_FAT_CCI_CONTA_CONSU_ITEM  CCI
              ON      CCI.ATD_ATE_ID             = CCP.ATD_ATE_ID
              AND     CCI.CAD_PAC_ID_PACIENTE    = CCP.CAD_PAC_ID_PACIENTE
              AND     CCI.FAT_CCP_ID             = CCP.FAT_CCP_ID
              AND     CCI.FAT_COC_ID             = CCP.FAT_COC_ID
              JOIN    TB_FAT_MCC_MOV_COM_CONSUMO   MCC
              ON      MCC.FAT_MCC_ID             = CCI.FAT_MCC_ID
              AND     MCC.ATD_ATE_ID             = CCI.ATD_ATE_ID
              WHERE   (CCP.FAT_CCP_FL_FATURADA = 'S')
              AND     (ATE.ATD_ATE_FL_STATUS = 'A')
              AND     (CCP.FAT_CCP_FL_STATUS = 'A')
              AND     (COC.FAT_COC_FL_STATUS = 'A')
              AND     (CCP.FAT_NOF_ID IS NOT NULL)
              AND     CCI.FAT_CCI_FL_STATUS      = 'A'
--              AND     CCI.FAT_CCI_FL_FATURADO    = 'S'
              AND       (CCI.FAT_CCI_FL_PACOTE = 'N' OR CCI.FAT_CCI_FL_PACOTE IS NULL)
              AND     (CCI.FAT_CCI_TP_DESTINO_ITEM != 'H')
              AND     (MCC.FAT_TCO_ID            != 10)
              AND     (MCC.FAT_MCC_FL_STATUS     = 'A')
              AND     (pCAD_UNI_ID_UNIDADE IS NULL OR ATE.CAD_UNI_ID_UNIDADE IN (select column_value from table(fnc_split(pCAD_UNI_ID_UNIDADE))))
              AND     (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
              AND     (pCAD_SET_ID IS NULL OR ATE.CAD_SET_ID = pCAD_SET_ID)
              AND     (FAT_CCP_MES_FAT = pFAT_CCP_MES_FAT)
              AND     (FAT_CCP_ANO_FAT = pFAT_CCP_ANO_FAT)
              AND     (pTIS_TAT_CD_TPATENDIMENTO IS NULL OR ATE.TIS_TAT_CD_TPATENDIMENTO = pTIS_TAT_CD_TPATENDIMENTO)
              AND     (pTIS_CBO_CD_CBOS IS NULL OR ATE.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS)
              AND     (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
              AND     (pCAD_PLA_ID_PLANO IS NULL OR PAC.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
               AND     (
                      (pCAD_PLA_CD_TIPOPLANO_PA IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO IN ('PA'))
                      OR (PLA.CAD_PLA_CD_TIPOPLANO IS NULL)
                      )
              GROUP BY  ATE.CAD_UNI_ID_UNIDADE,  ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO
            ) FATURADOS
          ON FATURADOS.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
         AND FATURADOS.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
    WHERE   UNI.CAD_UNI_FL_FATURA_UNID_OK = 'S'
    )
    WHERE (QTDE > 0 OR FATURADOS > 0)
UNION
    SELECT       'PARTICULAR' TIPO_PLANO, --COM DIF. DE CLASSE
                 0 DESPESA_RECEITA,
            CASE WHEN CAD_LAT_ID_LOCAL_ATENDIMENTO not in (29,46) THEN 'AMBULATORIO' ELSE 'INTERNADO' END LOCAL_ATENDIMENTO,
            CAD_LAT_DS_LOCAL_ATENDIMENTO,
            CAD_UNI_ID_UNIDADE,
            CASE WHEN CAD_UNI_ID_UNIDADE = 244 THEN 'DIF. DE CLASSE - SANTOS'
                 WHEN CAD_UNI_ID_UNIDADE = 247 THEN 'DIF. DE CLASSE - S.VICENTE'
                 WHEN CAD_UNI_ID_UNIDADE = 245 THEN 'DIF. DE CLASSE - GUARUJA'
                 ELSE NULL
            END CAD_UNI_DS_UNIDADE,
            QTDE,
            FATURADOS,
            NULL SERVICOS_ADM,
            NULL ESTAGIOS,
            NULL CURSOS
  FROM
  (
    SELECT  LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO,
            LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
            UNI.CAD_UNI_ID_UNIDADE,
            UNI.CAD_UNI_DS_UNIDADE,
            NVL(QTDE.TOTAL,0) QTDE,
            NVL(FATURADOS.TOTAL,0) FATURADOS
    FROM    TB_CAD_UNI_UNIDADE UNI
    JOIN    TB_ASS_ULO_UNID_LOCAL ULO
    ON      UNI.CAD_UNI_ID_UNIDADE = ULO.CAD_UNI_ID_UNIDADE
    JOIN    TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
    ON      ULO.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
     LEFT JOIN (   SELECT     COUNT(DISTINCT CCP.ATD_ATE_ID||CCP.FAT_CCP_ID||PAC.CAD_CNV_ID_CONVENIO) TOTAL,
                        ATE.CAD_UNI_ID_UNIDADE, ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO
             FROM    TB_FAT_CCP_CONTA_CONS_PARC CCP
              JOIN    TB_ATD_ATE_ATENDIMENTO       ATE
              ON      CCP.ATD_ATE_ID             = ATE.ATD_ATE_ID
              JOIN    TB_CAD_PAC_PACIENTE          PAC
              ON      PAC.CAD_PAC_ID_PACIENTE    = CCP.CAD_PAC_ID_PACIENTE
              JOIN    TB_CAD_PLA_PLANO             PLA
              ON      PLA.CAD_PLA_ID_PLANO       = PAC.CAD_PLA_ID_PLANO
              JOIN    TB_FAT_COC_CONTA_CONSUMO     COC
              ON      COC.ATD_ATE_ID             = CCP.ATD_ATE_ID
              AND     COC.CAD_PAC_ID_PACIENTE    = CCP.CAD_PAC_ID_PACIENTE
              AND     COC.FAT_COC_ID             = CCP.FAT_COC_ID
              JOIN    TB_FAT_CCI_CONTA_CONSU_ITEM  CCI
              ON      CCI.ATD_ATE_ID             = CCP.ATD_ATE_ID
              AND     CCI.CAD_PAC_ID_PACIENTE    = CCP.CAD_PAC_ID_PACIENTE
              AND     CCI.FAT_CCP_ID             = CCP.FAT_CCP_ID
              AND     CCI.FAT_COC_ID             = CCP.FAT_COC_ID
              JOIN    TB_FAT_MCC_MOV_COM_CONSUMO   MCC
              ON      MCC.FAT_MCC_ID             = CCI.FAT_MCC_ID
              AND     MCC.ATD_ATE_ID             = CCI.ATD_ATE_ID
              WHERE   (CCP.FAT_CCP_FL_FATURADA = 'S')
              AND     (ATE.ATD_ATE_FL_STATUS = 'A')
              AND     (CCP.FAT_CCP_FL_STATUS = 'A')
              AND     (COC.FAT_COC_FL_STATUS = 'A')
              AND     (CCP.FAT_NOF_ID IS NOT NULL)
               AND     CCI.FAT_CCI_FL_STATUS      = 'A'
--              AND     CCI.FAT_CCI_FL_FATURADO    = 'S'
              AND       (CCI.FAT_CCI_FL_PACOTE = 'N' OR CCI.FAT_CCI_FL_PACOTE IS NULL)
               AND     (CCI.FAT_CCI_TP_DESTINO_ITEM != 'H')
               AND     (MCC.FAT_TCO_ID            = 10)
               AND     (MCC.FAT_MCC_FL_STATUS     = 'A')
              AND     (ATE.CAD_UNI_ID_UNIDADE IN (244,247,245))
              AND     (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
              AND     (pCAD_SET_ID IS NULL OR ATE.CAD_SET_ID = pCAD_SET_ID)
              AND     (FAT_CCP_MES_FAT = pFAT_CCP_MES_FAT)
              AND     (FAT_CCP_ANO_FAT = pFAT_CCP_ANO_FAT)
              AND     (pTIS_TAT_CD_TPATENDIMENTO IS NULL OR ATE.TIS_TAT_CD_TPATENDIMENTO = pTIS_TAT_CD_TPATENDIMENTO)
              AND     (pTIS_CBO_CD_CBOS IS NULL OR ATE.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS)
              AND     (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
              AND     (pCAD_PLA_ID_PLANO IS NULL OR PAC.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
              AND     (
                      (pCAD_PLA_CD_TIPOPLANO_PA IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO IN ('PA'))
                      OR (PLA.CAD_PLA_CD_TIPOPLANO IS NULL)
                      )
               GROUP BY ATE.CAD_UNI_ID_UNIDADE, ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO
            ) QTDE
            ON QTDE.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
           AND QTDE.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
           left join  (
              SELECT  SUM(CCI.FAT_CCI_VL_FATURADO) TOTAL, ATE.CAD_UNI_ID_UNIDADE, ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO
              FROM    TB_FAT_CCP_CONTA_CONS_PARC CCP
              JOIN    TB_ATD_ATE_ATENDIMENTO       ATE
              ON      CCP.ATD_ATE_ID             = ATE.ATD_ATE_ID
              JOIN    TB_CAD_PAC_PACIENTE          PAC
              ON      PAC.CAD_PAC_ID_PACIENTE    = CCP.CAD_PAC_ID_PACIENTE
              JOIN    TB_CAD_PLA_PLANO             PLA
              ON      PLA.CAD_PLA_ID_PLANO       = PAC.CAD_PLA_ID_PLANO
              JOIN    TB_FAT_COC_CONTA_CONSUMO     COC
              ON      COC.ATD_ATE_ID             = CCP.ATD_ATE_ID
              AND     COC.CAD_PAC_ID_PACIENTE    = CCP.CAD_PAC_ID_PACIENTE
              AND     COC.FAT_COC_ID             = CCP.FAT_COC_ID
              JOIN    TB_FAT_CCI_CONTA_CONSU_ITEM  CCI
              ON      CCI.ATD_ATE_ID             = CCP.ATD_ATE_ID
              AND     CCI.CAD_PAC_ID_PACIENTE    = CCP.CAD_PAC_ID_PACIENTE
              AND     CCI.FAT_CCP_ID             = CCP.FAT_CCP_ID
              AND     CCI.FAT_COC_ID             = CCP.FAT_COC_ID
              JOIN    TB_FAT_MCC_MOV_COM_CONSUMO   MCC
              ON      MCC.FAT_MCC_ID             = CCI.FAT_MCC_ID
              AND     MCC.ATD_ATE_ID             = CCI.ATD_ATE_ID
              WHERE   (CCP.FAT_CCP_FL_FATURADA = 'S')
              AND     (ATE.ATD_ATE_FL_STATUS = 'A')
              AND     (CCP.FAT_CCP_FL_STATUS = 'A')
              AND     (COC.FAT_COC_FL_STATUS = 'A')
              AND     (CCP.FAT_NOF_ID IS NOT NULL)
               AND     CCI.FAT_CCI_FL_STATUS      = 'A'
--              AND     CCI.FAT_CCI_FL_FATURADO    = 'S'
              AND       (CCI.FAT_CCI_FL_PACOTE = 'N' OR CCI.FAT_CCI_FL_PACOTE IS NULL)
               AND     (CCI.FAT_CCI_TP_DESTINO_ITEM != 'H')
               AND     (MCC.FAT_TCO_ID            = 10)
               AND     (MCC.FAT_MCC_FL_STATUS     = 'A')
              AND     (ATE.CAD_UNI_ID_UNIDADE IN (244,247,245))
              AND     (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
              AND     (pCAD_SET_ID IS NULL OR ATE.CAD_SET_ID = pCAD_SET_ID)
              AND     (FAT_CCP_MES_FAT = pFAT_CCP_MES_FAT)
              AND     (FAT_CCP_ANO_FAT = pFAT_CCP_ANO_FAT)
              AND     (pTIS_TAT_CD_TPATENDIMENTO IS NULL OR ATE.TIS_TAT_CD_TPATENDIMENTO = pTIS_TAT_CD_TPATENDIMENTO)
              AND     (pTIS_CBO_CD_CBOS IS NULL OR ATE.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS)
              AND     (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
              AND     (pCAD_PLA_ID_PLANO IS NULL OR PAC.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
               AND     (
                      (pCAD_PLA_CD_TIPOPLANO_PA IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO IN ('PA'))
                      OR (PLA.CAD_PLA_CD_TIPOPLANO IS NULL)
                      )
              GROUP BY  ATE.CAD_UNI_ID_UNIDADE,  ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO
            ) FATURADOS
          ON FATURADOS.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
         AND FATURADOS.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
    WHERE   UNI.CAD_UNI_FL_FATURA_UNID_OK = 'S'
    )
    WHERE (QTDE > 0 OR FATURADOS > 0)
   UNION
SELECT      'PARTICULAR' TIPO_PLANO, --LEGADO(AMB)
            0 DESPESA_RECEITA,
            CASE WHEN CAD_LAT_ID_LOCAL_ATENDIMENTO not in (29,46) THEN 'AMBULATORIO' ELSE 'INTERNADO' END LOCAL_ATENDIMENTO,
            CAD_LAT_DS_LOCAL_ATENDIMENTO,
            CAD_UNI_ID_UNIDADE,
            CAD_UNI_DS_UNIDADE,
            QTDE,
            FATURADOS,
            NULL SERVICOS_ADM,
            NULL ESTAGIOS,
            NULL CURSOS
  FROM
  (
    SELECT  LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO,
            LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
            UNI.CAD_UNI_ID_UNIDADE,
            UNI.CAD_UNI_DS_UNIDADE,
            QTDE,
            NVL(FATURADOS.TOTAL,0) FATURADOS
    FROM    TB_CAD_UNI_UNIDADE UNI
    JOIN    TB_ASS_ULO_UNID_LOCAL ULO
    ON      UNI.CAD_UNI_ID_UNIDADE = ULO.CAD_UNI_ID_UNIDADE
    JOIN    TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
    ON      ULO.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
          LEFT JOIN  (
             SELECT   'PARTICULAR' TIPO_PLANO,
           27 CAD_LAT_ID_LOCAL_ATENDIMENTO,
           'AMBULATORIO' CAD_LAT_DS_LOCAL_ATENDIMENTO ,
           U.CAD_UNI_ID_UNIDADE,
           U.CAD_UNI_DS_UNIDADE,
           COUNT(1) QTDE,
           SUM(NVL(F.VALTOTNF,0) + NVL(F.VL_DESCONTO_ISS,0)) TOTAL
           FROM  TB_NOTA_FISCAL F, TB_CAD_UNI_UNIDADE U--, TB_ATD_ATE_ATENDIMENTO ATE
           WHERE F.TIPONF = 'AMB'
           AND F.CODUNIHOS = U.CAD_UNI_CD_UNID_HOSPITALAR
          -- AND ATE.ATD_ATE_ID  = F.CODATEAMB
           AND TO_CHAR(DATNF,'mmyyyy') = trim(to_char(pFAT_CCP_MES_FAT,'00') || to_char(pFAT_CCP_ANO_FAT))
           AND F.SITNF != 'C'
           AND NOT (F.CODCXA = 2 AND F.CODUNIHOS = 6)
           AND (pCAD_UNI_ID_UNIDADE IS NULL OR U.CAD_UNI_ID_UNIDADE IN (select column_value from table(fnc_split(pCAD_UNI_ID_UNIDADE))))
           AND ((pCAD_CNV_ID_CONVENIO IS NULL OR pCAD_CNV_ID_CONVENIO = 282 )
             OR (rownum =0))
           AND (
               (pCAD_PLA_CD_TIPOPLANO_PA IS NOT NULL)
               OR (rownum =0)
               )
           GROUP BY 'PARTICULAR',
           27 ,
           'AMBULATORIO'  ,
           U.CAD_UNI_ID_UNIDADE,
           U.CAD_UNI_DS_UNIDADE
           HAVING NVL(SUM(F.VALTOTNF),0) > 0
            ) FATURADOS
         ON FATURADOS.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
         AND FATURADOS.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
    WHERE   UNI.CAD_UNI_FL_FATURA_UNID_OK = 'S'
    )
    WHERE (FATURADOS > 0)
UNION
SELECT
      NULL TIPO_PLANO,
      0    DESPESA_RECEITA,
      NULL LOCAL_ATENDIMENTO,
      NULL CAD_LAT_DS_LOCAL_ATENDIMENTO,
      NULL CAD_UNI_ID_UNIDADE,
      NULL CAD_UNI_DS_UNIDADE,
      NULL QTDE,
      NULL FATURADOS,
      NULL SERVICOS_ADM,
      NULL ESTAGIOS,
      NVL(SUM(NF.Valtotnf),0) CURSOS
      FROM tb_nota_fiscal nf,
           TB_CAD_UNI_UNIDADE UNI
      WHERE
          nF.Codunihos = UNI.CAD_UNI_CD_UNID_HOSPITALAR
      AND TO_CHAR(nf.datnf,'MM') = pFAT_CCP_MES_FAT
      AND TO_CHAR(nf.datnf,'yyyy') = pFAT_CCP_ANO_FAT
      AND nf.tiponf = 'TXC'
      AND NF.SITNF != 'C'
      AND (pCAD_UNI_ID_UNIDADE IS NULL OR uNI.CAD_UNI_ID_UNIDADE IN (select column_value from table(fnc_split(pCAD_UNI_ID_UNIDADE))))
 UNION
 SELECT
      NULL TIPO_PLANO,
      0    DESPESA_RECEITA,
      NULL LOCAL_ATENDIMENTO,
      NULL CAD_LAT_DS_LOCAL_ATENDIMENTO,
      NULL CAD_UNI_ID_UNIDADE,
      NULL CAD_UNI_DS_UNIDADE,
      NULL QTDE,
      NULL FATURADOS,
      NULL SERVICOS_ADM,
      NVL(SUM(NOF.FAT_NFO_VL_FATURADO),0) ESTAGIOS,
      NULL CURSOS
      FROM TB_CAD_PLA_PLANO PLA, TB_CAD_CNV_CONVENIO CNV, TB_FAT_NOF_NOTA_FISCAL NOF,
           TB_CAD_UNI_UNIDADE UNI
      WHERE
          NOF.FAT_NOF_MES_FAT     = pFAT_CCP_MES_FAT
      AND NOF.FAT_NOF_ANO_FAT     = pFAT_CCP_ANO_FAT
      AND NOF.CAD_CNV_ID_CONVENIO = PLA.CAD_CNV_ID_CONVENIO
      AND CNV.CAD_CNV_ID_CONVENIO = PLA.CAD_CNV_ID_CONVENIO
      AND NOF.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
      AND NOF.FAT_NOF_FL_STATUS = 'A'
      AND (CNV.CAD_CNV_CD_HAC_PRESTADOR in ('FESS','VALE','FUL1'))
      AND (pCAD_UNI_ID_UNIDADE IS NULL OR uNI.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
      AND (pCAD_CNV_ID_CONVENIO IS NULL OR CNV.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
      AND (pCAD_PLA_ID_PLANO IS NULL OR PLA.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
UNION
 SELECT
      NULL TIPO_PLANO,
      0    DESPESA_RECEITA,
      NULL LOCAL_ATENDIMENTO,
      NULL CAD_LAT_DS_LOCAL_ATENDIMENTO,
      NULL CAD_UNI_ID_UNIDADE,
      NULL CAD_UNI_DS_UNIDADE,
      NULL QTDE,
      NULL FATURADOS,
      NVL(SUM(NOF.FAT_NFO_VL_FATURADO),0) SERVICOS_ADM,
      NULL ESTAGIOS,
      NULL CURSOS
      FROM TB_CAD_PLA_PLANO PLA, TB_CAD_CNV_CONVENIO CNV, TB_FAT_NOF_NOTA_FISCAL NOF,
           TB_CAD_UNI_UNIDADE UNI
      WHERE
          NOF.FAT_NOF_MES_FAT     = pFAT_CCP_MES_FAT
      AND NOF.FAT_NOF_ANO_FAT     = pFAT_CCP_ANO_FAT
      AND NOF.CAD_CNV_ID_CONVENIO = PLA.CAD_CNV_ID_CONVENIO
      AND CNV.CAD_CNV_ID_CONVENIO = PLA.CAD_CNV_ID_CONVENIO
      AND NOF.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
      AND NOF.FAT_NOF_FL_STATUS = 'A'
      AND (CNV.CAD_CNV_CD_HAC_PRESTADOR = 'S186')
      AND (pCAD_UNI_ID_UNIDADE IS NULL OR uNI.CAD_UNI_ID_UNIDADE IN (select column_value from table(fnc_split(pCAD_UNI_ID_UNIDADE))))
      AND (pCAD_CNV_ID_CONVENIO IS NULL OR CNV.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
      AND (pCAD_PLA_ID_PLANO IS NULL OR PLA.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
  ;
  io_cursor := v_cursor;
END PRC_FAT_REL_VL_RECEITA_UNI;
 