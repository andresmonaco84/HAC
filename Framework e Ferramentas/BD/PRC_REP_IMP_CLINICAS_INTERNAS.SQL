CREATE OR REPLACE PROCEDURE "PRC_REP_IMP_CLINICAS_INTERNAS"
 (pDATA_INI                             IN DATE DEFAULT NULL,
  pDATA_FIM                             IN DATE DEFAULT NULL,
  pSEG_USU_ID_USUARIO                   IN TB_SEG_USU_USUARIO.SEG_USU_ID_USUARIO%TYPE,
  pCAD_UNI_ID_UNIDADE                   IN STRING,
  pCAD_PRO_ID_PROFISSIONAL              IN STRING
) IS
  /********************************************************************
  *    PROCEDURE: PRC_REP_IMP_CLINICAS_INTERNAS
  *
  *    DATA CRIACAO:    20/02/2013         POR:
  *    DATA ALTERACAO:  DATA DA ALTERAC?O  POR: NOME DO ANALISTA
  *
  *    FUNCAO:
  *
  *******************************************************************/
BEGIN
  BEGIN
    FOR X IN (SELECT RESULTADO.UNID,
                     RESULTADO.LOC,
                     RESULTADO.CAD_PRO_ID_PROFISSIONAL,
                     RESULTADO.TIS_CBO_CD_CBOS,
                     RESULTADO.TIS_CBO_DS_CBOS_HAC,
                     DECODE(RESULTADO.DIASINT, 14, 2.1, 4.2) MULT,
                     RESULTADO.HORAS,
                     RESULTADO.CAD_PRO_NM_NOME,
                     RESULTADO.CAD_PRO_NR_CONSELHO,
                     RESULTADO.RESIDENTE
                FROM (SELECT TMP.UNID,
                             TMP.LOC,
                             CBOS.TIS_CBO_CD_CBOS,
                             CBOS.TIS_CBO_DS_CBOS_HAC,
                             TMP.CAD_PRO_ID_PROFISSIONAL,
                             PRO.CAD_PRO_NR_CONSELHO,
                             PRO.CAD_PRO_NM_NOME,
                             PRO.CAD_PRO_FL_RESIDENTE_OK RESIDENTE,
                             DIASINT,
                             CASE
                               WHEN SUM(HORAS) = 1.60  THEN 2.0
                               WHEN SUM(HORAS) = 2.30  THEN 2.50
                               WHEN SUM(HORAS) = 2.60  THEN 3.0
                               WHEN SUM(HORAS) = 3.60  THEN 4.0
                               WHEN SUM(HORAS) = 4.30  THEN 4.50
                               WHEN SUM(HORAS) = 6.30  THEN 6.50
                               WHEN SUM(HORAS) = 4.60  THEN 5.0
                               WHEN SUM(HORAS) = 5.60  THEN 6.0
                               WHEN SUM(HORAS) = 6.60  THEN 7.0
                               WHEN SUM(HORAS) = 7.60  THEN 8.0
                               WHEN SUM(HORAS) = 8.60  THEN 9.0
                               WHEN SUM(HORAS) = 3.30  THEN 3.50
                               WHEN SUM(HORAS) = 3.30  THEN 3.50
                               WHEN SUM(HORAS) = 5.30  THEN 5.50
                               WHEN SUM(HORAS) = 5.90  THEN 6.50
                               WHEN SUM(HORAS) = 7.30  THEN 7.50
                               WHEN SUM(HORAS) = 7.90  THEN 8.50
                               WHEN SUM(HORAS) = 9.80  THEN 10.20
                               WHEN SUM(HORAS) = 11.30 THEN 11.50
                               WHEN SUM(HORAS) = 10.60 THEN 11.00
                               WHEN SUM(HORAS) = 15.70 THEN 16.10
                               WHEN SUM(HORAS) = 21.60 THEN 22.00
                               WHEN SUM(HORAS) = 44.30 THEN 44.50
                               WHEN SUM(HORAS) = 40.60 THEN 41.00
                               WHEN SUM(HORAS) = 15.60 THEN 16.00
                               WHEN SUM(HORAS) = 16.60 THEN 17.00
                               WHEN SUM(HORAS) = 17.60 THEN 18.00
                               ELSE SUM(HORAS)
                             END HORAS
                        FROM (SELECT ESM.CAD_UNI_ID_UNIDADE UNID,
                                     ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO LOC,
                                     ESM.CAD_PRO_ID_PROFISSIONAL,
                                     ESM.TIS_CBO_CD_CBOS,
                                     ESM.AGE_ESM_QT_DIAS_INTERVALO DIASINT,
                                     CASE
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 3.70 THEN 3.30
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 0.70 THEN 0.30
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 1.70 THEN 1.30
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 2.70 THEN 2.30
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 4.70 THEN 4.30
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 5.70 THEN 5.30
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 2.45 THEN 3.00
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 3.45 THEN 4.00
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 4.45 THEN 5.00
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 2.40 THEN 3.00
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 2.40 THEN 3.00
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 6.60 THEN 7.00
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 1.85 THEN 1.30
                                       ELSE (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100
                                     END HORAS
                                FROM TB_AGE_ESM_ESCALA_MEDICA ESM
                               WHERE ESM.AGE_ESM_FL_SITUACAO IN ('A')
                                 AND ESM.AGE_ESM_FL_AGENDAGERADA_OK = 'S'
                                 AND ESM.AGE_ESM_DT_INI_ESCALA <= pDATA_INI
                                 AND (pCAD_UNI_ID_UNIDADE IS NULL OR ESM.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT(pCAD_UNI_ID_UNIDADE))))
                                 AND (pCAD_PRO_ID_PROFISSIONAL IS NULL OR ESM.CAD_PRO_ID_PROFISSIONAL IN (SELECT * FROM TABLE(FNC_SPLIT(pCAD_PRO_ID_PROFISSIONAL))))
                                 AND (TRUNC(ESM.AGE_ESM_DT_INI_ESCALA) <> TRUNC(ESM.AGE_ESM_DT_FIM_ESCALA) OR ESM.AGE_ESM_DT_FIM_ESCALA IS NULL)
                              UNION ALL
                              SELECT ESM.CAD_UNI_ID_UNIDADE UNID,
                                     ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO LOC,
                                     ESM.CAD_PRO_ID_PROFISSIONAL,
                                     ESM.TIS_CBO_CD_CBOS,
                                     ESM.AGE_ESM_QT_DIAS_INTERVALO DIASINT,
                                     CASE
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 3.70 THEN 3.30
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 0.70 THEN 0.30
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 1.70 THEN 1.30
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 2.70 THEN 2.30
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 4.70 THEN 4.30
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 5.70 THEN 5.30
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 2.45 THEN 3.00
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 3.45 THEN 4.00
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 4.45 THEN 5.00
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 2.40 THEN 3.00
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 2.40 THEN 3.00
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 6.60 THEN 7.00
                                       WHEN (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100 = 1.85 THEN 1.30
                                       ELSE (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA) / 100
                                     END HORAS
                                FROM TB_AGE_ESM_ESCALA_MEDICA ESM
                               WHERE ESM.AGE_ESM_FL_SITUACAO = 'I'
                                 AND ESM.AGE_ESM_FL_AGENDAGERADA_OK = 'S'
                                 AND ESM.AGE_ESM_DT_INI_ESCALA <= pDATA_INI
                                 AND (pCAD_UNI_ID_UNIDADE IS NULL OR ESM.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT(pCAD_UNI_ID_UNIDADE))))
                                 AND (pCAD_PRO_ID_PROFISSIONAL IS NULL OR ESM.CAD_PRO_ID_PROFISSIONAL IN (SELECT * FROM TABLE(FNC_SPLIT(pCAD_PRO_ID_PROFISSIONAL))))
                                 AND (TRUNC(ESM.AGE_ESM_DT_FIM_ESCALA) >= TO_DATE(pDATA_INI) - 1 OR ESM.AGE_ESM_DT_FIM_ESCALA IS NULL)
                                 AND (TRUNC(ESM.AGE_ESM_DT_INI_ESCALA) <> TRUNC(ESM.AGE_ESM_DT_FIM_ESCALA) OR ESM.AGE_ESM_DT_FIM_ESCALA IS NULL)) TMP
                       INNER JOIN TB_CAD_PRO_PROFISSIONAL PRO
                          ON PRO.CAD_PRO_ID_PROFISSIONAL = TMP.CAD_PRO_ID_PROFISSIONAL
                       INNER JOIN TB_CAD_PES_PESSOA PES
                          ON PES.CAD_PES_ID_PESSOA = PRO.CAD_PES_ID_PESSOA
                       INNER JOIN TB_TIS_CBO_CBOS CBOS
                          ON CBOS.TIS_CBO_CD_CBOS = TMP.TIS_CBO_CD_CBOS
                       GROUP BY TMP.UNID,
                                TMP.LOC,
                                CBOS.TIS_CBO_CD_CBOS,
                                CBOS.TIS_CBO_DS_CBOS_HAC,
                                TMP.CAD_PRO_ID_PROFISSIONAL,
                                PRO.CAD_PRO_NR_CONSELHO,
                                PRO.CAD_PRO_NM_NOME,
                                PRO.CAD_PRO_FL_RESIDENTE_OK,
                                DIASINT) RESULTADO
               WHERE NOT EXISTS
               (SELECT CPR.CAD_PRO_ID_PROFISSIONAL
                  FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                       TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                       TB_ASS_RPG_REGRA_PAGTO         RPG,
                       TB_CAD_REP_REGRA_PAGAMENTO     REP
                 WHERE CPR.CAD_CLC_ID = CLC.CAD_CLC_ID
                   AND CPR.CAD_PRO_ID_PROFISSIONAL = RESULTADO.CAD_PRO_ID_PROFISSIONAL
                   AND CLC.CAD_CLC_CD_CLINICA IN (45, 62, 111, 112, 113, 116)
                   AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                   AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                   AND CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                   AND RPG.CAD_REP_ID = REP.CAD_REP_ID
                   AND REP.CAD_REP_TP_BASE_CALCULO = 'VLHORA'
                   AND CPR.CAD_UNI_ID_UNIDADE = RESULTADO.UNID))
     LOOP
      BEGIN
        INSERT INTO TB_CAD_HTR_HORA_TRAB
          (CAD_HTR_ID,
           CAD_UNI_ID_UNIDADE,
           CAD_LAT_ID_LOCAL_ATENDIMENTO,
           CAD_PRO_ID_PROFISSIONAL,
           TIS_CBO_CD_CBOS,
           CAD_HTR_DT_INICIO_VIGENCIA,
           CAD_HTR_DT_FIM_VIGENCIA,
           CAD_HTR_QT_HORA_SEMANA,
           CAD_HTR_VL_FATOR_MULTI_SEMANA,
           CAD_HTR_DT_ULTIMA_ATUALIZACAO,
           SEG_USU_ID_USUARIO)
        VALUES
          (SEQ_CAD_HTR_01.NEXTVAL,
           X.UNID,
           X.LOC,
           X.CAD_PRO_ID_PROFISSIONAL,
           X.TIS_CBO_CD_CBOS,
           pDATA_INI,
           pDATA_FIM,
           X.HORAS,
           X.MULT,
           SYSDATE,
           PSEG_USU_ID_USUARIO);
      END;
    END LOOP COMMIT;
  END;
END PRC_REP_IMP_CLINICAS_INTERNAS;