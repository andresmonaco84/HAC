CREATE OR REPLACE PROCEDURE "PRC_REP_IMP_SANTOS_CLINICA"
 (pDATA_INI                             IN DATE DEFAULT NULL,
  pDATA_FIM                             IN DATE DEFAULT NULL,
  pSEG_USU_ID_USUARIO                   IN TB_SEG_USU_USUARIO.SEG_USU_ID_USUARIO%TYPE,
  pCAD_UNI_ID_UNIDADE                   IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
  pCAD_PRO_ID_PROFISSIONAL              IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%TYPE DEFAULT NULL
) IS
  /********************************************************************
  *    PROCEDURE: PRC_REP_IMP_SANTOS_CLINICA
  *
  *    DATA CRIACAO:    20/02/2013         POR:
  *    DATA ALTERACAO:  DATA DA ALTERAC?O  POR: NOME DO ANALISTA
  *
  *    FUNCAO:
  *
  *******************************************************************/
BEGIN
 BEGIN
  FOR TEMP IN (SELECT RESULTADO.CAD_UNI_ID_UNIDADE UNID,
                      RESULTADO.CAD_LAT_ID_LOCAL_ATENDIMENTO LOC,
                      RESULTADO.CAD_PRO_ID_PROFISSIONAL,
                      RESULTADO.TIS_CBO_CD_CBOS,
                      TRIM(RESULTADO.TIS_CPR_CD_CONSELHOPROF) CONSELHO,
                      TO_NUMBER(RESULTADO.CAD_PRO_NR_CONSELHO) CRM,
                      RESULTADO.CAD_PES_NM_PESSOA NOMMED,
                      RESULTADO.TIS_CBO_CD_CBOS_HAC CODESPMED,
                      RESULTADO.HORAS_DISPONIVEIS - NVL(HORAS_FALTA, 0) HORAS_CONTRATADAS,
                      (RESULTADO.HORAS_DISPONIVEIS - NVL(HORAS_FALTA, 0)) * 4 CONSULTAS_PREVISTAS,
                      (TOTAL_NORMAL + TOTAL_ENCAIXE_ESPECIAL +
                      TOTAL_SERVICO_PRESTADO + TOTAL_ENCAIXE +
                      TOTAL_RETORNO) CONSULTAS_AGENDADAS,
                      TOTAL_FALTA_PAC FALTA_PACIENTE,
                      ROUND(CAPACIDADE + CAPACIDADE_RETORNO) CAPACIDADE_ATENDIMENTOS
                 FROM (SELECT CBOS.TIS_CBO_CD_CBOS_HAC,
                              TMP.TIS_CBO_CD_CBOS,
                              TMP.CAD_UNI_ID_UNIDADE,
                              TMP.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                              TMP.CAD_PRO_ID_PROFISSIONAL,
                              ROUND(SUM(HOAS_DISPONIVEIS)) HORAS_DISPONIVEIS,
                              PRO.CAD_PRO_NR_CONSELHO,
                              PES.CAD_PES_NM_PESSOA,
                              SUM(TOTAL_RETORNO) TOTAL_RETORNO,
                              SUM(TOTAL_NORMAL) TOTAL_NORMAL,
                              SUM(TOTAL_ENCAIXE_ESPECIAL) TOTAL_ENCAIXE_ESPECIAL,
                              SUM(TOTAL_SERVICO_PRESTADO) TOTAL_SERVICO_PRESTADO,
                              SUM(TOTAL_ENCAIXE) TOTAL_ENCAIXE,
                              ROUND(SUM(HORAS_TRABALHADAS)) HORAS_TRABALHADAS,
                              ROUND(SUM(HORAS_FALTA)) HORAS_FALTA,
                              ROUND(SUM(HORAS_FALTA_PAC)) TOTAL_FALTA_PAC,
                              SUM(CAPACIDADE) CAPACIDADE,
                              SUM(CAPACIDADE_RETORNO) CAPACIDADE_RETORNO,
                              PRO.TIS_CPR_CD_CONSELHOPROF
                         FROM (SELECT ESM.CAD_UNI_ID_UNIDADE,
                                      ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                      ESM.CAD_PRO_ID_PROFISSIONAL,
                                      ESM.TIS_CBO_CD_CBOS,
                                      ---- DATA PARAMETRO TELA
                                      (FNC_AGE_ESM_DIAS_DISPONIVEIS(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM) * (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA)) / 100 HOAS_DISPONIVEIS,
                                      (FNC_AGE_ESM_TIPO_RETORNO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) TOTAL_RETORNO,
                                      (FNC_AGE_ESM_TIPO_NORMAL(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) TOTAL_NORMAL,
                                      (FNC_AGE_ESM_TIPO_EE(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) TOTAL_ENCAIXE_ESPECIAL,
                                      (FNC_AGE_ESM_TIPO_SP(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) TOTAL_SERVICO_PRESTADO,
                                      (FNC_AGE_ESM_TIPO_ENCAIXE(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) TOTAL_ENCAIXE,
                                      (FNC_AGE_ESM_DIAS_ATENDIDOS(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM) * (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA)) / 100 HORAS_TRABALHADAS,
                                      (FNC_AGE_ESM_TOTAL_FALTAS(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM) * (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA)) / 100 HORAS_FALTA,
                                      (FNC_AGE_ESM_TOTAL_FALTA_PAC(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) HORAS_FALTA_PAC,
                                      (FNC_AGE_ESM_CAPAC_NORMAL_SP(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) CAPACIDADE,
                                      (FNC_AGE_ESM_CAPAC_RETORNO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) CAPACIDADE_RETORNO
                                 FROM TB_AGE_ESM_ESCALA_MEDICA ESM,
                                      TB_CAD_PRO_PROFISSIONAL      PRO

                                WHERE (pCAD_UNI_ID_UNIDADE IS NULL OR ESM.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
                                  AND ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO = 27
                                  AND (pCAD_PRO_ID_PROFISSIONAL IS NULL OR ESM.CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL)
                                  AND ESM.AGE_ESM_FL_SITUACAO IN ('A')
                                  AND ESM.AGE_ESM_FL_AGENDAGERADA_OK = 'S'
                                  AND ESM.AGE_ESM_DT_INI_ESCALA <= pDATA_FIM
                                  AND ESM.CAD_PRO_ID_PROFISSIONAL = PRO.CAD_PRO_ID_PROFISSIONAL
                                  AND EXISTS
                                  (SELECT CPR.CAD_PRO_ID_PROFISSIONAL
                                     FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                                          TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                                          TB_ASS_RPG_REGRA_PAGTO         RPG,
                                          TB_CAD_REP_REGRA_PAGAMENTO     REP
                                    WHERE CPR.CAD_CLC_ID = CLC.CAD_CLC_ID
                                      AND CPR.CAD_PRO_ID_PROFISSIONAL = ESM.CAD_PRO_ID_PROFISSIONAL
                                      AND CLC.CAD_CLC_CD_CLINICA = 45
                                      AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                                      AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                                      AND CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                                      AND RPG.CAD_REP_ID = REP.CAD_REP_ID
                                      AND REP.CAD_REP_TP_BASE_CALCULO = 'VLHORA'
                                      AND CPR.CAD_UNI_ID_UNIDADE = ESM.CAD_UNI_ID_UNIDADE)
                               UNION ALL
                               SELECT ESM.CAD_UNI_ID_UNIDADE,
                                      ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                      ESM.CAD_PRO_ID_PROFISSIONAL,
                                      ESM.TIS_CBO_CD_CBOS,
                                      ---- DATA PARAMETRO TELA
                                      (FNC_AGE_ESM_DIAS_DISPONIVEIS(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM) * (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA)) / 100 HOAS_DISPONIVEIS,
                                      (FNC_AGE_ESM_TIPO_RETORNO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) TOTAL_RETORNO,
                                      (FNC_AGE_ESM_TIPO_NORMAL(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) TOTAL_NORMAL,
                                      (FNC_AGE_ESM_TIPO_EE(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) TOTAL_ENCAIXE_ESPECIAL,
                                      (FNC_AGE_ESM_TIPO_SP(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) TOTAL_SERVICO_PRESTADO,
                                      (FNC_AGE_ESM_TIPO_ENCAIXE(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) TOTAL_ENCAIXE,
                                      (FNC_AGE_ESM_DIAS_ATENDIDOS(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM) * (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA)) / 100 HORAS_TRABALHADAS,
                                      (FNC_AGE_ESM_TOTAL_FALTAS(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM) * (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA)) / 100 HORAS_FALTA,
                                      (FNC_AGE_ESM_TOTAL_FALTA_PAC(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) HORAS_FALTA_PAC,
                                      (FNC_AGE_ESM_CAPAC_NORMAL_SP(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) CAPACIDADE,
                                      (FNC_AGE_ESM_CAPAC_RETORNO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) CAPACIDADE_RETORNO
                                 FROM TB_AGE_ESM_ESCALA_MEDICA ESM,
                                      TB_CAD_PRO_PROFISSIONAL      PRO

                                WHERE (pCAD_UNI_ID_UNIDADE IS NULL OR ESM.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
                                  AND ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO = 27
                                  AND (pCAD_PRO_ID_PROFISSIONAL IS NULL OR ESM.CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL)
                                  AND ESM.AGE_ESM_FL_SITUACAO = 'I'
                                  AND ESM.AGE_ESM_FL_AGENDAGERADA_OK = 'S'
                                  AND ESM.AGE_ESM_DT_INI_ESCALA <= pDATA_FIM
                                  AND ESM.CAD_PRO_ID_PROFISSIONAL = PRO.CAD_PRO_ID_PROFISSIONAL
                                  AND EXISTS
                                  (SELECT CPR.CAD_PRO_ID_PROFISSIONAL
                                     FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                                          TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                                          TB_ASS_RPG_REGRA_PAGTO         RPG,
                                          TB_CAD_REP_REGRA_PAGAMENTO     REP
                                    WHERE CPR.CAD_CLC_ID = CLC.CAD_CLC_ID
                                      AND CPR.CAD_PRO_ID_PROFISSIONAL = ESM.CAD_PRO_ID_PROFISSIONAL
                                      AND CLC.CAD_CLC_CD_CLINICA = 45
                                      AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                                      AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                                      AND CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                                      AND RPG.CAD_REP_ID = REP.CAD_REP_ID
                                      AND REP.CAD_REP_TP_BASE_CALCULO = 'VLHORA'
                                      AND CPR.CAD_UNI_ID_UNIDADE = ESM.CAD_UNI_ID_UNIDADE)
                               ) TMP
                        INNER JOIN TB_CAD_PRO_PROFISSIONAL PRO
                           ON PRO.CAD_PRO_ID_PROFISSIONAL = TMP.CAD_PRO_ID_PROFISSIONAL
                        INNER JOIN TB_CAD_PES_PESSOA PES
                           ON PES.CAD_PES_ID_PESSOA = PRO.CAD_PES_ID_PESSOA
                        INNER JOIN TB_TIS_CBO_CBOS CBOS
                           ON CBOS.TIS_CBO_CD_CBOS = TMP.TIS_CBO_CD_CBOS
                        GROUP BY PRO.TIS_CPR_CD_CONSELHOPROF,
                                 CBOS.TIS_CBO_CD_CBOS_HAC,
                                 TMP.CAD_PRO_ID_PROFISSIONAL,
                                 PRO.CAD_PRO_NR_CONSELHO,
                                 PES.CAD_PES_NM_PESSOA,
                                 TMP.CAD_UNI_ID_UNIDADE,
                                 TMP.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                 TMP.TIS_CBO_CD_CBOS,
                                 TMP.CAD_PRO_ID_PROFISSIONAL
                        ORDER BY PES.CAD_PES_NM_PESSOA) RESULTADO
                WHERE RESULTADO.HORAS_DISPONIVEIS - NVL(HORAS_FALTA, 0) > 0
                ORDER BY 2
               ) LOOP
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
         TEMP.UNID,
         TEMP.LOC,
         TEMP.CAD_PRO_ID_PROFISSIONAL,
         TEMP.TIS_CBO_CD_CBOS,
         pDATA_INI,
         pDATA_FIM,
         TEMP.HORAS_CONTRATADAS,
         1.00,
         SYSDATE,
         PSEG_USU_ID_USUARIO);
    EXCEPTION
      WHEN DUP_VAL_ON_INDEX THEN
        NULL;
    END;
  END LOOP;
  COMMIT;
  END;
END PRC_REP_IMP_SANTOS_CLINICA;