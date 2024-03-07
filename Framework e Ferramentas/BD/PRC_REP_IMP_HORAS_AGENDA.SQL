CREATE OR REPLACE PROCEDURE PRC_REP_IMP_HORAS_AGENDA(PDATAINICIOVIGENCIA IN DATE,
                                                     PDATAFIMVIGENCIA    IN DATE,
                                                     PUSUARIOIMPORTACAO  IN INTEGER) IS
  /********************************************************************
  *    Procedure: PRC_REP_IMP_HORAS_AGENDA
  *
  *    Data Criacao:   01/15/2012   Por:
  *    Data Alteracao:  data da alteracao  Por: Nome do Analista
  *
  *    Funcao: Descricao da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  LIDTRETORNO NUMBER;
BEGIN
  DECLARE
    CURSOR X IS
      SELECT RESULTADO.UNID,
             RESULTADO.LOC,
             RESULTADO.CAD_PRO_ID_PROFISSIONAL,
             RESULTADO.TIS_CBO_CD_CBOS,
             RESULTADO.HORAS_DISPONIVEIS HORAS_CONTRATADAS
        FROM (SELECT TMP.UNID,
                     TMP.LOC,
                     CBOS.TIS_CBO_CD_CBOS,
                     TMP.CAD_PRO_ID_PROFISSIONAL,
                     ROUND(SUM(HORAS_DISPONIVEIS)) HORAS_DISPONIVEIS
                FROM (SELECT ESM.CAD_UNI_ID_UNIDADE UNID,
                             ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO LOC,
                             ESM.CAD_PRO_ID_PROFISSIONAL,
                             ESM.TIS_CBO_CD_CBOS,
                             (FNC_AGE_ESM_DIAS_DISPONIVEIS(ESM.AGE_ESM_ID, PDATAINICIOVIGENCIA, PDATAFIMVIGENCIA) * (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA)) / 100 HORAS_DISPONIVEIS
                        FROM SGS.TB_AGE_ESM_ESCALA_MEDICA ESM
                       WHERE ESM.AGE_ESM_FL_SITUACAO IN ('A', 'S')
                         AND ESM.AGE_ESM_FL_AGENDAGERADA_OK = 'S'
                         AND ESM.AGE_ESM_DT_INI_ESCALA <= PDATAFIMVIGENCIA
                      UNION ALL
                      SELECT ESM.CAD_UNI_ID_UNIDADE UNID,
                             ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO LOC,
                             ESM.CAD_PRO_ID_PROFISSIONAL,
                             ESM.TIS_CBO_CD_CBOS,
                             (FNC_AGE_ESM_DIAS_DISPONIVEIS(ESM.AGE_ESM_ID, PDATAINICIOVIGENCIA, PDATAFIMVIGENCIA) * (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA)) / 100 HORAS_DISPONIVEIS
                        FROM SGS.TB_AGE_ESM_ESCALA_MEDICA ESM
                       WHERE ESM.AGE_ESM_FL_SITUACAO = 'I'
                         AND ESM.AGE_ESM_FL_AGENDAGERADA_OK = 'S'
                         AND ESM.AGE_ESM_DT_INI_ESCALA <= PDATAFIMVIGENCIA) TMP
               INNER JOIN SGS.TB_CAD_PRO_PROFISSIONAL PRO
                  ON PRO.CAD_PRO_ID_PROFISSIONAL = TMP.CAD_PRO_ID_PROFISSIONAL
               INNER JOIN SGS.TB_CAD_PES_PESSOA PES
                  ON PES.CAD_PES_ID_PESSOA = PRO.CAD_PES_ID_PESSOA
               INNER JOIN SGS.TB_TIS_CBO_CBOS CBOS
                  ON CBOS.TIS_CBO_CD_CBOS = TMP.TIS_CBO_CD_CBOS
               GROUP BY TMP.UNID,
                        TMP.LOC,
                        TMP.TIS_CBO_CD_CBOS,
                        TMP.CAD_PRO_ID_PROFISSIONAL) RESULTADO
       WHERE RESULTADO.HORAS_DISPONIVEIS > 0
       ORDER BY 2;
  BEGIN
    FOR TEMP IN X LOOP
      SELECT SEQ_CAD_HTR_01.NEXTVAL INTO LIDTRETORNO FROM DUAL;
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
        (LIDTRETORNO,
         TEMP.UNID,
         TEMP.LOC,
         TEMP.CAD_PRO_ID_PROFISSIONAL,
         TEMP.TIS_CBO_CD_CBOS,
         PDATAINICIOVIGENCIA,
         PDATAFIMVIGENCIA,
         TEMP.HORAS_CONTRATADAS,
         1.05,
         SYSDATE,
         PUSUARIOIMPORTACAO);
    END LOOP;
    EXCEPTION
        WHEN DUP_VAL_ON_INDEX THEN
            NULL;
        END;
    COMMIT;
END PRC_REP_IMP_HORAS_AGENDA;
 
/
