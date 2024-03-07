CREATE OR REPLACE PROCEDURE SGS."PRC_REP_CAL_VALORHORA"
 (PREP_PGM_MES_FECHAMENTO               IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_FECHAMENTO%TYPE,
  PREP_PGM_ANO_FECHAMENTO               IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_FECHAMENTO%TYPE,
  PREP_PGM_MES_PAGTO                    IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
  PREP_PGM_ANO_PAGTO                    IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE,
  PSEG_USU_ID_USUARIO                   IN TB_REP_PPC_PAG_PROF_CLI.SEG_USU_ID_USUARIO%TYPE,
  --PCAD_CLC_ID                           IN STRING,
  PCAD_UNI_ID_UNIDADE                   IN STRING,
  PCAD_LAT_ID_LOCAL_ATENDIMENTO         IN STRING,
  PCAD_PRO_ID_PROFISSIONAL              IN STRING,
  PCAD_HTR_DT_INICIO_VIGENCIA           IN DATE,
  PREP_PPC_FL_ANTECIPACAO               IN TB_REP_PPC_PAG_PROF_CLI.REP_PPC_FL_ANTECIPACAO%TYPE
) IS
  /********************************************************************
  *    PROCEDURE: PRC_REP_CAL_VALORHORA
  *
  *    DATA CRIACAO:    29/01/2013   POR:
  *    DATA ALTERACAO:  DATA DA ALTERAÇÃO  POR: NOME DO ANALISTA
  *
  *    FUNCAO:
  *
  *******************************************************************/
BEGIN
 BEGIN
  FOR TEMP IN (
               -- HAC
               SELECT DISTINCT CPR.CAD_CLC_ID,
                               CLC.CAD_CLC_CD_CLINICA,
                               CLC.CAD_CLC_DS_DESCRICAO,
                               HORASTRAB.UNID UNID,
                               HORASTRAB.LOCALATEN,
                               CPR.CAD_PRO_ID_PROFISSIONAL PROFISSIONAL,
                               REP.CAD_REP_TP_BASE_CALCULO,
                               REP.CAD_REP_ID,
                              NVL( (((HORASTRAB.CAD_HTR_QT_HORA_SEMANA) * (REP.CAD_REP_VL_PAGTO)) * (RPG.ASS_RPG_PC_HAC / 100)),0) PAGOHAC,
                               0 PAGOACS,
                               'MF' CREDENCIAMENTO,
                               'HAC' FONTEPAGADORA,
                                HORASTRAB.CAD_HTR_ID
                          FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                               TB_CAD_REP_REGRA_PAGAMENTO     REP,
                               TB_ASS_RPG_REGRA_PAGTO         RPG,
                               TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                               TB_CAD_PRO_PROFISSIONAL        PRO,
                               TB_REP_IMPORTACAO_CLI_TEMP     ICT,
                               (SELECT DISTINCT CLC.CAD_CLC_ID,
                                                CLC.CAD_CLC_CD_CLINICA,
                                                DECODE(CPR.CAD_UNI_ID_UNIDADE, NULL, NVL(CPR.CAD_UNI_ID_UNIDADE, 0), HTR.CAD_UNI_ID_UNIDADE) UNID,
                                                DECODE(CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO, NULL, NVL(CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO, 0), HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO) LOCALATEN,
                                                HTR.TIS_CBO_CD_CBOS,
                                                DECODE(CPR.TIS_CBO_CD_CBOS, NULL, NVL(CPR.TIS_CBO_CD_CBOS, 0), HTR.TIS_CBO_CD_CBOS) CPRESPEC,
                                                CPR.CAD_PRO_ID_PROFISSIONAL,
                                                PRO.CAD_PRO_NR_CONSELHO,
                                                PRO.CAD_PRO_NM_NOME,
                                                REP.CAD_REP_VL_PAGTO,
                                                HTR.CAD_HTR_QT_HORA_SEMANA,
                                                RPG.ASS_RPG_PC_HAC,
                                                RPG.ASS_RPG_PC_ACS,
                                                CAD_REP_VL_PAGTO,
                                                HTR.CAD_HTR_ID
                                           FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                                                TB_CAD_REP_REGRA_PAGAMENTO     REP,
                                                TB_ASS_RPG_REGRA_PAGTO         RPG,
                                                TB_CAD_HTR_HORA_TRAB           HTR,
                                                TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                                                TB_CAD_PRO_PROFISSIONAL        PRO,
                                                TB_CAD_HFA_HORAS_FALTA         HFA,
                                                TB_REP_IMPORTACAO_CLI_TEMP     ICT
                                          WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                                            AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                                            AND REP.CAD_REP_TP_BASE_CALCULO = ('VLHORA')
                                            AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                                            AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                                            AND HTR.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                                            AND HTR.CAD_PRO_ID_PROFISSIONAL IS NOT NULL
                                            AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                                            AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                                            AND HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                                            AND HTR.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                                            AND HTR.CAD_HTR_ID = HFA.CAD_HTR_ID(+)
                                            --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_CLC_ID )))
                                            AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                                            AND (PCAD_UNI_ID_UNIDADE IS NULL OR CPR.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_UNI_ID_UNIDADE ))))
                                            AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR
                                                 CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_LAT_ID_LOCAL_ATENDIMENTO ))))
                                            AND (PCAD_PRO_ID_PROFISSIONAL IS NULL OR
                                                 PRO.CAD_PRO_ID_PROFISSIONAL IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_PRO_ID_PROFISSIONAL ))))
                                            AND HTR.CAD_HTR_DT_INICIO_VIGENCIA = PCAD_HTR_DT_INICIO_VIGENCIA
                                        ) HORASTRAB
                         WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                           AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                           AND CPR.CAD_CLC_ID = CLC.CAD_CLC_ID
                           AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                           AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLHORA')
                           AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                           AND CPR.CAD_CLC_ID = HORASTRAB.CAD_CLC_ID
                           AND CPR.CAD_PRO_ID_PROFISSIONAL = HORASTRAB.CAD_PRO_ID_PROFISSIONAL
                           AND CPR.CAD_UNI_ID_UNIDADE = HORASTRAB.UNID
                           AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = HORASTRAB.LOCALATEN
                           AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                           AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                           --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_CLC_ID )))
                           AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                           AND (PCAD_UNI_ID_UNIDADE IS NULL OR
                                CPR.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_UNI_ID_UNIDADE ))))
                           AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR
                                CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_LAT_ID_LOCAL_ATENDIMENTO ))))
                           AND RPG.ASS_RPG_PC_HAC > 0
                           AND NVL( (((HORASTRAB.CAD_HTR_QT_HORA_SEMANA) * (REP.CAD_REP_VL_PAGTO)) * (RPG.ASS_RPG_PC_HAC / 100)),0) > 0
                          AND NVL(REP.CAD_REP_VL_PAGTO,0) > 0                           
                           AND NOT EXISTS (SELECT *
                                             FROM TB_REP_PPC_PAG_PROF_CLI PPC
                                            WHERE PPC.CAD_HTR_ID = HORASTRAB.CAD_HTR_ID
                                              AND PPC.REP_PPC_MES_PAGTO= PREP_PGM_MES_PAGTO
                                              AND PPC.REP_PPC_ANO_PAGTO =  PREP_PGM_ANO_PAGTO
                                              AND PPC.CAD_CLC_ID = CPR.CAD_CLC_ID
                                              AND PPC.CAD_REP_TP_BASE_CALCULO = 'VLHORA'
                                              AND PPC.REP_PPC_FONTE_PAGADORA = 'HAC'
                                              AND PPC.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                                              AND PPC.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                                              AND PPC.CAD_LAT_ID_LOCAL = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO)
                           UNION ALL
                           -- HACFS
                           SELECT DISTINCT CPR.CAD_CLC_ID,
                               CLC.CAD_CLC_CD_CLINICA,
                               CLC.CAD_CLC_DS_DESCRICAO,
                               HORASTRAB.UNID UNID,
                               HORASTRAB.LOCALATEN,
                               CPR.CAD_PRO_ID_PROFISSIONAL PROFISSIONAL,
                               REP.CAD_REP_TP_BASE_CALCULO,
                               REP.CAD_REP_ID,
                             NVL(  (((HORASTRAB.CAD_HTR_QT_HORA_FIM_SEMANA) * (REP.CAD_REP_VL_PAGTO_EXTRA)) * (RPG.ASS_RPG_PC_HAC / 100)),0) PAGOHAC,
                               0 PAGOACS,
                               'MF' CREDENCIAMENTO,
                               'HAC' FONTEPAGADORA,
                                HORASTRAB.CAD_HTR_ID
                          FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                               TB_CAD_REP_REGRA_PAGAMENTO     REP,
                               TB_ASS_RPG_REGRA_PAGTO         RPG,
                               TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                               TB_CAD_PRO_PROFISSIONAL        PRO,
                               TB_REP_IMPORTACAO_CLI_TEMP     ICT,
                               (SELECT DISTINCT CLC.CAD_CLC_ID,
                                                CLC.CAD_CLC_CD_CLINICA,
                                                DECODE(CPR.CAD_UNI_ID_UNIDADE, NULL, NVL(CPR.CAD_UNI_ID_UNIDADE, 0), HTR.CAD_UNI_ID_UNIDADE) UNID,
                                                DECODE(CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO, NULL, NVL(CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO, 0), HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO) LOCALATEN,
                                                HTR.TIS_CBO_CD_CBOS,
                                                DECODE(CPR.TIS_CBO_CD_CBOS, NULL, NVL(CPR.TIS_CBO_CD_CBOS, 0), HTR.TIS_CBO_CD_CBOS) CPRESPEC,
                                                CPR.CAD_PRO_ID_PROFISSIONAL,
                                                PRO.CAD_PRO_NR_CONSELHO,
                                                PRO.CAD_PRO_NM_NOME,
                                                REP.CAD_REP_VL_PAGTO,
                                                HTR.CAD_HTR_QT_HORA_FIM_SEMANA,
                                                RPG.ASS_RPG_PC_HAC,
                                                RPG.ASS_RPG_PC_ACS,
                                                REP.CAD_REP_VL_PAGTO_EXTRA,
                                                HTR.CAD_HTR_ID
                                           FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                                                TB_CAD_REP_REGRA_PAGAMENTO     REP,
                                                TB_ASS_RPG_REGRA_PAGTO         RPG,
                                                TB_CAD_HTR_HORA_TRAB           HTR,
                                                TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                                                TB_CAD_PRO_PROFISSIONAL        PRO,
                                                TB_CAD_HFA_HORAS_FALTA         HFA,
                                                TB_REP_IMPORTACAO_CLI_TEMP     ICT
                                          WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                                            AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                                            AND REP.CAD_REP_TP_BASE_CALCULO = ('VLHORAFS')
                                            AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                                            AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                                            AND HTR.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                                            AND HTR.CAD_PRO_ID_PROFISSIONAL IS NOT NULL
                                            AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                                            AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                                            AND HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                                            AND HTR.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                                            AND HTR.CAD_HTR_ID = HFA.CAD_HTR_ID(+)
                                            --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_CLC_ID )))
                                            AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                                            AND (PCAD_UNI_ID_UNIDADE IS NULL OR CPR.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_UNI_ID_UNIDADE ))))
                                            AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR
                                                 CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_LAT_ID_LOCAL_ATENDIMENTO ))))
                                            AND (PCAD_PRO_ID_PROFISSIONAL IS NULL OR
                                                 PRO.CAD_PRO_ID_PROFISSIONAL IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_PRO_ID_PROFISSIONAL ))))
                                            AND HTR.CAD_HTR_DT_INICIO_VIGENCIA = PCAD_HTR_DT_INICIO_VIGENCIA
                                        ) HORASTRAB
                         WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                           AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                           AND CPR.CAD_CLC_ID = CLC.CAD_CLC_ID
                           AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                           AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLHORAFS')
                           AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                           AND CPR.CAD_CLC_ID = HORASTRAB.CAD_CLC_ID
                           AND CPR.CAD_PRO_ID_PROFISSIONAL = HORASTRAB.CAD_PRO_ID_PROFISSIONAL
                           AND CPR.CAD_UNI_ID_UNIDADE = HORASTRAB.UNID
                           AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = HORASTRAB.LOCALATEN
                           AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                           AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                           --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_CLC_ID )))
                           AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                           AND (PCAD_UNI_ID_UNIDADE IS NULL OR
                                CPR.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_UNI_ID_UNIDADE ))))
                           AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR
                                CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_LAT_ID_LOCAL_ATENDIMENTO ))))
                           AND RPG.ASS_RPG_PC_HAC > 0 
                             AND NVL(  (((HORASTRAB.CAD_HTR_QT_HORA_FIM_SEMANA) * (REP.CAD_REP_VL_PAGTO_EXTRA)) * (RPG.ASS_RPG_PC_HAC / 100)),0) > 0
                          AND NVL(REP.CAD_REP_VL_PAGTO_EXTRA,0) > 0
                           AND NOT EXISTS (SELECT *
                                             FROM TB_REP_PPC_PAG_PROF_CLI PPC
                                            WHERE PPC.CAD_HTR_ID = HORASTRAB.CAD_HTR_ID
                                              AND PPC.REP_PPC_MES_PAGTO= PREP_PGM_MES_PAGTO
                                              AND PPC.REP_PPC_ANO_PAGTO =  PREP_PGM_ANO_PAGTO
                                              AND PPC.CAD_CLC_ID = CPR.CAD_CLC_ID
                                              AND PPC.CAD_REP_TP_BASE_CALCULO = 'VLHORAFS'
                                              AND PPC.REP_PPC_FONTE_PAGADORA = 'HAC'
                                              AND PPC.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                                              AND PPC.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                                              AND PPC.CAD_LAT_ID_LOCAL = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO)
                           UNION ALL
                           -- ACS
                SELECT DISTINCT CPR.CAD_CLC_ID,
                                CLC.CAD_CLC_CD_CLINICA,
                                CLC.CAD_CLC_DS_DESCRICAO,
                                HORASTRAB.UNID UNID,
                                HORASTRAB.LOCALATEN,
                                CPR.CAD_PRO_ID_PROFISSIONAL PROFISSIONAL,
                                REP.CAD_REP_TP_BASE_CALCULO,
                                REP.CAD_REP_ID,
                                0 PAGOHAC,
                              NVL( (((HORASTRAB.CAD_HTR_QT_HORA_SEMANA) * (REP.CAD_REP_VL_PAGTO)) * (RPG.ASS_RPG_PC_ACS / 100)),0) PAGOACS,
                                'MC' CREDENCIAMENTO,
                                'ACS' FONTEPAGADORA,
                                 HORASTRAB.CAD_HTR_ID
                           FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                                TB_CAD_REP_REGRA_PAGAMENTO     REP,
                                TB_ASS_RPG_REGRA_PAGTO         RPG,
                                TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                                TB_CAD_PRO_PROFISSIONAL        PRO,
                                TB_REP_IMPORTACAO_CLI_TEMP     ICT,
                                (SELECT DISTINCT CLC.CAD_CLC_ID,
                                                 CLC.CAD_CLC_CD_CLINICA,
                                                 DECODE(CPR.CAD_UNI_ID_UNIDADE, NULL, NVL(CPR.CAD_UNI_ID_UNIDADE, 0), HTR.CAD_UNI_ID_UNIDADE) UNID,
                                                 DECODE(CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO, NULL, NVL(CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO, 0), HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO) LOCALATEN,
                                                 HTR.TIS_CBO_CD_CBOS,
                                                 DECODE(CPR.TIS_CBO_CD_CBOS, NULL, NVL(CPR.TIS_CBO_CD_CBOS, 0), HTR.TIS_CBO_CD_CBOS) CPRESPEC,
                                                 CPR.CAD_PRO_ID_PROFISSIONAL,
                                                 PRO.CAD_PRO_NR_CONSELHO,
                                                 PRO.CAD_PRO_NM_NOME,
                                                 REP.CAD_REP_VL_PAGTO,
                                                 HTR.CAD_HTR_QT_HORA_SEMANA,
                                                 RPG.ASS_RPG_PC_HAC,
                                                 RPG.ASS_RPG_PC_ACS,
                                                 CAD_REP_VL_PAGTO,
                                                  HTR.CAD_HTR_ID
                                            FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                                                 TB_CAD_REP_REGRA_PAGAMENTO     REP,
                                                 TB_ASS_RPG_REGRA_PAGTO         RPG,
                                                 TB_CAD_HTR_HORA_TRAB           HTR,
                                                 TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                                                 TB_CAD_PRO_PROFISSIONAL        PRO,
                                                 TB_CAD_HFA_HORAS_FALTA         HFA,
                                                 TB_REP_IMPORTACAO_CLI_TEMP     ICT
                                           WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                                             AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                                             AND REP.CAD_REP_TP_BASE_CALCULO = ('VLHORA')
                                             AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                                             AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                                             AND HTR.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                                             AND HTR.CAD_PRO_ID_PROFISSIONAL IS NOT NULL
                                             AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                                             AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                                             AND HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                                             AND HTR.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                                             AND HTR.CAD_HTR_ID = HFA.CAD_HTR_ID(+)
                                             --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_CLC_ID )))
                                             AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                                             AND (PCAD_UNI_ID_UNIDADE IS NULL OR
                                                  CPR.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_UNI_ID_UNIDADE ))))
                                             AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR
                                                  CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_LAT_ID_LOCAL_ATENDIMENTO ))))
                                             AND (PCAD_PRO_ID_PROFISSIONAL IS NULL OR
                                                  PRO.CAD_PRO_ID_PROFISSIONAL IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_PRO_ID_PROFISSIONAL ))))
                                             AND HTR.CAD_HTR_DT_INICIO_VIGENCIA = PCAD_HTR_DT_INICIO_VIGENCIA
                                        ) HORASTRAB
                          WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                            AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                            AND CPR.CAD_CLC_ID = CLC.CAD_CLC_ID
                            AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                            AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLHORA')
                            AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                            AND CPR.CAD_CLC_ID = HORASTRAB.CAD_CLC_ID
                            AND CPR.CAD_PRO_ID_PROFISSIONAL = HORASTRAB.CAD_PRO_ID_PROFISSIONAL
                            AND CPR.CAD_UNI_ID_UNIDADE = HORASTRAB.UNID
                            AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = HORASTRAB.LOCALATEN
                            AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                            AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                            --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_CLC_ID )))
                            AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                            AND (PCAD_UNI_ID_UNIDADE IS NULL OR
                                 CPR.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_UNI_ID_UNIDADE ))))
                            AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR
                                 CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_LAT_ID_LOCAL_ATENDIMENTO ))))
                            AND RPG.ASS_RPG_PC_ACS > 0 
                            AND NVL(REP.CAD_REP_VL_PAGTO,0) > 0    
                            AND NVL( (((HORASTRAB.CAD_HTR_QT_HORA_SEMANA) * (REP.CAD_REP_VL_PAGTO)) * (RPG.ASS_RPG_PC_ACS / 100)),0) > 0                         
                            AND NOT EXISTS (SELECT *
                                              FROM TB_REP_PPC_PAG_PROF_CLI PPC
                                             WHERE PPC.CAD_HTR_ID=HORASTRAB.CAD_HTR_ID
                                               AND PPC.REP_PPC_MES_PAGTO= PREP_PGM_MES_PAGTO
                                               AND PPC.REP_PPC_ANO_PAGTO =  PREP_PGM_ANO_PAGTO
                                               AND PPC.CAD_CLC_ID=CPR.CAD_CLC_ID
                                               AND PPC.CAD_REP_TP_BASE_CALCULO = 'VLHORA'
                                               AND PPC.REP_PPC_FONTE_PAGADORA = 'ACS'
                                               AND PPC.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                                               AND PPC.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                                               AND PPC.CAD_LAT_ID_LOCAL = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO)
               UNION ALL
                       -- ACSFS
                SELECT DISTINCT CPR.CAD_CLC_ID,
                                CLC.CAD_CLC_CD_CLINICA,
                                CLC.CAD_CLC_DS_DESCRICAO,
                                HORASTRAB.UNID UNID,
                                HORASTRAB.LOCALATEN,
                                CPR.CAD_PRO_ID_PROFISSIONAL PROFISSIONAL,
                                REP.CAD_REP_TP_BASE_CALCULO,
                                REP.CAD_REP_ID,
                                0 PAGOHAC,
                               NVL( (((HORASTRAB.CAD_HTR_QT_HORA_FIM_SEMANA) * (REP.CAD_REP_VL_PAGTO_EXTRA)) * (RPG.ASS_RPG_PC_ACS / 100)),0) PAGOACS,
                                'MC' CREDENCIAMENTO,
                                'ACS' FONTEPAGADORA,
                                 HORASTRAB.CAD_HTR_ID
                           FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                                TB_CAD_REP_REGRA_PAGAMENTO     REP,
                                TB_ASS_RPG_REGRA_PAGTO         RPG,
                                TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                                TB_CAD_PRO_PROFISSIONAL        PRO,
                                TB_REP_IMPORTACAO_CLI_TEMP     ICT,
                                (SELECT DISTINCT CLC.CAD_CLC_ID,
                                                 CLC.CAD_CLC_CD_CLINICA,
                                                 DECODE(CPR.CAD_UNI_ID_UNIDADE, NULL, NVL(CPR.CAD_UNI_ID_UNIDADE, 0), HTR.CAD_UNI_ID_UNIDADE) UNID,
                                                 DECODE(CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO, NULL, NVL(CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO, 0), HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO) LOCALATEN,
                                                 HTR.TIS_CBO_CD_CBOS,
                                                 DECODE(CPR.TIS_CBO_CD_CBOS, NULL, NVL(CPR.TIS_CBO_CD_CBOS, 0), HTR.TIS_CBO_CD_CBOS) CPRESPEC,
                                                 CPR.CAD_PRO_ID_PROFISSIONAL,
                                                 PRO.CAD_PRO_NR_CONSELHO,
                                                 PRO.CAD_PRO_NM_NOME,
                                                 REP.CAD_REP_VL_PAGTO_EXTRA,
                                                 HTR.CAD_HTR_QT_HORA_FIM_SEMANA,
                                                 RPG.ASS_RPG_PC_HAC,
                                                 RPG.ASS_RPG_PC_ACS,
                                                 CAD_REP_VL_PAGTO,
                                                  HTR.CAD_HTR_ID
                                            FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                                                 TB_CAD_REP_REGRA_PAGAMENTO     REP,
                                                 TB_ASS_RPG_REGRA_PAGTO         RPG,
                                                 TB_CAD_HTR_HORA_TRAB           HTR,
                                                 TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                                                 TB_CAD_PRO_PROFISSIONAL        PRO,
                                                 TB_CAD_HFA_HORAS_FALTA         HFA,
                                                 TB_REP_IMPORTACAO_CLI_TEMP     ICT
                                           WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                                             AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                                             AND REP.CAD_REP_TP_BASE_CALCULO = ('VLHORAFS')
                                             AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                                             AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                                             AND HTR.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                                             AND HTR.CAD_PRO_ID_PROFISSIONAL IS NOT NULL
                                             AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                                             AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                                             AND HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                                             AND HTR.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                                             AND HTR.CAD_HTR_ID = HFA.CAD_HTR_ID(+)
                                             --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_CLC_ID )))
                                             AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                                             AND (PCAD_UNI_ID_UNIDADE IS NULL OR
                                                  CPR.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_UNI_ID_UNIDADE ))))
                                             AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR
                                                  CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_LAT_ID_LOCAL_ATENDIMENTO ))))
                                             AND (PCAD_PRO_ID_PROFISSIONAL IS NULL OR
                                                  PRO.CAD_PRO_ID_PROFISSIONAL IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_PRO_ID_PROFISSIONAL ))))
                                             AND HTR.CAD_HTR_DT_INICIO_VIGENCIA = PCAD_HTR_DT_INICIO_VIGENCIA
                                        ) HORASTRAB
                          WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                            AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                            AND CPR.CAD_CLC_ID = CLC.CAD_CLC_ID
                            AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                            AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLHORAFS')
                            AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                            AND CPR.CAD_CLC_ID = HORASTRAB.CAD_CLC_ID
                            AND CPR.CAD_PRO_ID_PROFISSIONAL = HORASTRAB.CAD_PRO_ID_PROFISSIONAL
                            AND CPR.CAD_UNI_ID_UNIDADE = HORASTRAB.UNID
                            AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = HORASTRAB.LOCALATEN
                            AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                            AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                            --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_CLC_ID )))
                            AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                            AND (PCAD_UNI_ID_UNIDADE IS NULL OR
                                 CPR.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_UNI_ID_UNIDADE ))))
                            AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR
                                 CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_LAT_ID_LOCAL_ATENDIMENTO ))))
                            AND RPG.ASS_RPG_PC_ACS > 0
                            AND NVL( (((HORASTRAB.CAD_HTR_QT_HORA_FIM_SEMANA) * (REP.CAD_REP_VL_PAGTO_EXTRA)) * (RPG.ASS_RPG_PC_ACS / 100)),0)  > 0
                            AND NVL(REP.CAD_REP_VL_PAGTO_EXTRA,0) > 0                             
                            AND NOT EXISTS (SELECT *
                                              FROM TB_REP_PPC_PAG_PROF_CLI PPC
                                             WHERE PPC.CAD_HTR_ID=HORASTRAB.CAD_HTR_ID
                                               AND PPC.REP_PPC_MES_PAGTO= PREP_PGM_MES_PAGTO
                                               AND PPC.REP_PPC_ANO_PAGTO =  PREP_PGM_ANO_PAGTO
                                               AND PPC.CAD_CLC_ID=CPR.CAD_CLC_ID
                                               AND PPC.CAD_REP_TP_BASE_CALCULO = 'VLHORAFS'
                                               AND PPC.REP_PPC_FONTE_PAGADORA = 'ACS'
                                               AND PPC.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                                               AND PPC.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                                               AND PPC.CAD_LAT_ID_LOCAL = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO)
                        ) LOOP                     
    BEGIN
      INSERT INTO TB_REP_PPC_PAG_PROF_CLI PPC
        (PPC.REP_PPC_ID,
         PPC.CAD_CLC_ID,
         PPC.CAD_UNI_ID_UNIDADE,
         PPC.CAD_LAT_ID_LOCAL,
         PPC.CAD_PRO_ID_PROFISSIONAL,
         PPC.REP_PPC_VL_PAGO_HAC,
         PPC.REP_PPC_VL_PAGO_ACS,
         PPC.REP_PPC_MES_FECHAMENTO,
         PPC.REP_PPC_ANO_FECHAMENTO,
         PPC.REP_PPC_MES_PAGTO,
         PPC.REP_PPC_ANO_PAGTO,
         PPC.SEG_USU_ID_USUARIO,
         PPC.REP_PPC_DT_ULTIMA_ATUALIZACAO,
         PPC.REP_PPC_FL_PAGTO,
         PPC.CAD_REP_TP_BASE_CALCULO,
         PPC.REP_PPC_TP_CREDENCIA_PROF,
         PPC.REP_PPC_FONTE_PAGADORA,
         PPC.REP_PPC_DT_CRIACAO,
         PPC.SEG_USU_ID_USUARIO_CRIACAO,
         PPC.CAD_HTR_ID,
         PPC.REP_PPC_FL_ANTECIPACAO,
         PPC.CAD_REP_ID)
      VALUES
        (SEQ_REP_PPC_01.NEXTVAL,
         TEMP.CAD_CLC_ID,
         TEMP.UNID,
         TEMP.LOCALATEN,
         TEMP.PROFISSIONAL,
         TEMP.PAGOHAC,
         TEMP.PAGOACS,
         PREP_PGM_MES_FECHAMENTO,
         PREP_PGM_ANO_FECHAMENTO,
         PREP_PGM_MES_PAGTO,
         PREP_PGM_ANO_PAGTO,
         PSEG_USU_ID_USUARIO,
         SYSDATE,
         'P',
         TEMP.CAD_REP_TP_BASE_CALCULO,
         TEMP.CREDENCIAMENTO,
         TEMP.FONTEPAGADORA,
         SYSDATE,
         PSEG_USU_ID_USUARIO,
         TEMP.CAD_HTR_ID,
         PREP_PPC_FL_ANTECIPACAO,
         TEMP.CAD_REP_ID);     
    END;
  END LOOP;
  COMMIT;
END;
END PRC_REP_CAL_VALORHORA;