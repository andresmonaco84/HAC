CREATE OR REPLACE PROCEDURE SGS."PRC_REP_CAL_VALORHORAPLANTAO"
( PREP_PGM_MES_FECHAMENTO               IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_FECHAMENTO%TYPE,
  PREP_PGM_ANO_FECHAMENTO               IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_FECHAMENTO%TYPE,
  PREP_PGM_MES_PAGTO                    IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
  PREP_PGM_ANO_PAGTO                    IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE,
  PSEG_USU_ID_USUARIO                   IN TB_REP_PPC_PAG_PROF_CLI.SEG_USU_ID_USUARIO%TYPE,
  --PCAD_CLC_ID                           IN STRING,
  PCAD_UNI_ID_UNIDADE                   IN STRING,
  PCAD_LAT_ID_LOCAL_ATENDIMENTO         IN STRING,
  PCAD_HTR_DT_INICIO_VIGENCIA           IN DATE,
  PREP_PPC_FL_ANTECIPACAO        IN TB_REP_PPC_PAG_PROF_CLI.REP_PPC_FL_ANTECIPACAO%TYPE
) IS
  /********************************************************************
  *    PROCEDURE: PRC_REP_CAL_VALORHORAPLANTAO
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
                               CPR.CAD_UNI_ID_UNIDADE UNID,
                               HORASTRAB.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                               RPG.ASS_RPG_PC_HAC                   PCHAC,
                               RPG.ASS_RPG_PC_ACS                   PCACS,
                               HORASTRAB.PAGOHAC,
                               0 PAGOACS,
                               HORASTRAB.CAD_HTR_DT_INICIO_VIGENCIA,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_TP_BASE_CALCULO,
							   REP.CAD_REP_ID,
                               --UNI.CAD_UNI_DS_UNIDADE,
                               'MF' CREDENCIAMENTO,
                               'HAC' FONTEPAGADORA,
                               HORASTRAB.CAD_HTR_ID
                          FROM TB_ASS_CPR_CLINICA_PROF CPR,
                               TB_CAD_REP_REGRA_PAGAMENTO REP,
                               TB_ASS_RPG_REGRA_PAGTO RPG,
                               TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                               TB_REP_IMPORTACAO_CLI_TEMP     ICT,
                               (SELECT DISTINCT HTR.CAD_HTR_ID,
                                                CLC.CAD_CLC_ID,
                                                CPR.CAD_UNI_ID_UNIDADE,
                                                HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                REP.CAD_REP_VL_PAGTO,
                                                HTR.CAD_HTR_QT_HORA_SEMANA,
                                                HTR.CAD_HTR_VL_FATOR_MULTI_SEMANA,
                                                HTR.CAD_HTR_QT_HORA_FIM_SEMANA,
                                                HTR.CAD_PRO_ID_PROFISSIONAL,
                                                HTR.CAD_HTR_VL_FATOR_MULTI_FIMSEM,
                                                RPG.ASS_RPG_PC_HAC,
                                                RPG.ASS_RPG_PC_ACS,
                                                (((HTR.CAD_HTR_QT_HORA_SEMANA * HTR.CAD_HTR_VL_FATOR_MULTI_SEMANA) * CAD_REP_VL_PAGTO) * RPG.ASS_RPG_PC_HAC) / 100 PAGOHAC,
                                                (((HTR.CAD_HTR_QT_HORA_SEMANA * HTR.CAD_HTR_VL_FATOR_MULTI_SEMANA) * CAD_REP_VL_PAGTO) * RPG.ASS_RPG_PC_ACS) / 100 PAGOACS,
                                                HTR.CAD_HTR_DT_INICIO_VIGENCIA
                                           FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                                                TB_CAD_REP_REGRA_PAGAMENTO     REP,
                                                TB_ASS_RPG_REGRA_PAGTO         RPG,
                                                TB_CAD_HTR_HORA_TRAB           HTR,
                                                TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                                                TB_REP_IMPORTACAO_CLI_TEMP     ICT
                                          WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                                            AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                                            AND REP.CAD_REP_TP_BASE_CALCULO = ('VLHRPLANT')
                                            AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                                            AND HTR.CAD_CLC_ID = CLC.CAD_CLC_ID
                                            AND CPR.CAD_UNI_ID_UNIDADE = HTR.CAD_UNI_ID_UNIDADE
                                            AND (CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO OR CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL)
                                            AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                                            AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                                            AND HTR.CAD_PRO_ID_PROFISSIONAL IS NULL
                                            --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_CLC_ID )))
                                            AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                                            AND (PCAD_UNI_ID_UNIDADE IS NULL OR CPR.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_UNI_ID_UNIDADE ))))
                                            AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_LAT_ID_LOCAL_ATENDIMENTO ))))
                                            AND HTR.CAD_HTR_DT_INICIO_VIGENCIA = PCAD_HTR_DT_INICIO_VIGENCIA ) HORASTRAB
                         WHERE CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                           AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLHRPLANT')
                           AND CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                           AND RPG.CAD_REP_ID = REP.CAD_REP_ID
                           AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                           AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                           AND CPR.CAD_CLC_ID = HORASTRAB.CAD_CLC_ID
                           AND CPR.CAD_UNI_ID_UNIDADE = HORASTRAB.CAD_UNI_ID_UNIDADE
                           AND (CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = HORASTRAB.CAD_LAT_ID_LOCAL_ATENDIMENTO OR CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL)
                           AND HORASTRAB.CAD_PRO_ID_PROFISSIONAL IS NULL
--                           AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_CLC_ID )))
                           AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                           AND (PCAD_UNI_ID_UNIDADE IS NULL OR CPR.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_UNI_ID_UNIDADE ))))
                           AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR HORASTRAB.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_LAT_ID_LOCAL_ATENDIMENTO ))))
                           AND PAGOHAC > 0
                           AND RPG.ASS_RPG_PC_HAC > 0
                           AND NOT EXISTS (SELECT *
                                             FROM TB_REP_PPC_PAG_PROF_CLI PPC
                                            WHERE PPC.CAD_CLC_ID=CPR.CAD_CLC_ID
                                              AND PPC.CAD_HTR_ID = HORASTRAB.CAD_HTR_ID
                                              AND PPC.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                                              AND PPC.CAD_LAT_ID_LOCAL = HORASTRAB.CAD_LAT_ID_LOCAL_ATENDIMENTO
                                              AND PPC.REP_PPC_MES_PAGTO = PREP_PGM_MES_PAGTO
                                              AND PPC.REP_PPC_ANO_PAGTO = PREP_PGM_ANO_PAGTO
                                              AND PPC.CAD_REP_TP_BASE_CALCULO = 'VLHRPLANT'
                                              AND PPC.REP_PPC_FONTE_PAGADORA = 'HAC')
               UNION ALL 
               -- HACFS
               SELECT DISTINCT CPR.CAD_CLC_ID,
                               CLC.CAD_CLC_CD_CLINICA,
                               CLC.CAD_CLC_DS_DESCRICAO,
                               CPR.CAD_UNI_ID_UNIDADE UNID,
                               HORASTRAB.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                               RPG.ASS_RPG_PC_HAC                   PCHAC,
                               RPG.ASS_RPG_PC_ACS                   PCACS,
                               HORASTRAB.PAGOHACFS,
                               0 PAGOACSFS,
                               HORASTRAB.CAD_HTR_DT_INICIO_VIGENCIA,
                               REP.CAD_REP_VL_PAGTO_EXTRA,
                               REP.CAD_REP_TP_BASE_CALCULO,
                               REP.CAD_REP_ID,
                               --UNI.CAD_UNI_DS_UNIDADE,
                               'MF' CREDENCIAMENTO,
                               'HAC' FONTEPAGADORA,
                               HORASTRAB.CAD_HTR_ID
                          FROM TB_ASS_CPR_CLINICA_PROF CPR,
                               TB_CAD_REP_REGRA_PAGAMENTO REP,
                               TB_ASS_RPG_REGRA_PAGTO RPG,
                               TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                               TB_REP_IMPORTACAO_CLI_TEMP     ICT,
                               (SELECT DISTINCT HTR.CAD_HTR_ID,
                                                CLC.CAD_CLC_ID,
                                                CPR.CAD_UNI_ID_UNIDADE,
                                                HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                REP.CAD_REP_VL_PAGTO,
                                                HTR.CAD_HTR_QT_HORA_SEMANA,
                                                HTR.CAD_HTR_VL_FATOR_MULTI_SEMANA,
                                                HTR.CAD_HTR_QT_HORA_FIM_SEMANA,
                                                HTR.CAD_PRO_ID_PROFISSIONAL,
                                                HTR.CAD_HTR_VL_FATOR_MULTI_FIMSEM,
                                                RPG.ASS_RPG_PC_HAC,
                                                RPG.ASS_RPG_PC_ACS,                                               
                                                (((HTR.CAD_HTR_QT_HORA_FIM_SEMANA * HTR.CAD_HTR_VL_FATOR_MULTI_FIMSEM) * REP.CAD_REP_VL_PAGTO_EXTRA) * RPG.ASS_RPG_PC_HAC) / 100 PAGOHACFS,
                                                (((HTR.CAD_HTR_QT_HORA_FIM_SEMANA * HTR.CAD_HTR_VL_FATOR_MULTI_FIMSEM) * REP.CAD_REP_VL_PAGTO_EXTRA) * RPG.ASS_RPG_PC_ACS) / 100 PAGOACSFS,
                                                HTR.CAD_HTR_DT_INICIO_VIGENCIA
                                           FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                                                TB_CAD_REP_REGRA_PAGAMENTO     REP,
                                                TB_ASS_RPG_REGRA_PAGTO         RPG,
                                                TB_CAD_HTR_HORA_TRAB           HTR,
                                                TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                                                TB_REP_IMPORTACAO_CLI_TEMP     ICT
                                          WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                                            AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                                            AND REP.CAD_REP_TP_BASE_CALCULO = ('VLHRPLAFS')
                                            AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                                            AND HTR.CAD_CLC_ID = CLC.CAD_CLC_ID
                                            AND CPR.CAD_UNI_ID_UNIDADE = HTR.CAD_UNI_ID_UNIDADE
                                            AND (CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO OR CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL)
                                            AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                                            AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                                            AND HTR.CAD_PRO_ID_PROFISSIONAL IS NULL
                                            --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_CLC_ID )))
                                            AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                                            AND (PCAD_UNI_ID_UNIDADE IS NULL OR CPR.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_UNI_ID_UNIDADE ))))
                                            AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_LAT_ID_LOCAL_ATENDIMENTO ))))
                                            AND HTR.CAD_HTR_DT_INICIO_VIGENCIA = PCAD_HTR_DT_INICIO_VIGENCIA ) HORASTRAB
                         WHERE CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                           AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLHRPLAFS')
                           AND CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                           AND RPG.CAD_REP_ID = REP.CAD_REP_ID
                           AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                           AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                           AND CPR.CAD_CLC_ID = HORASTRAB.CAD_CLC_ID
                           AND CPR.CAD_UNI_ID_UNIDADE = HORASTRAB.CAD_UNI_ID_UNIDADE
                           AND (CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = HORASTRAB.CAD_LAT_ID_LOCAL_ATENDIMENTO OR CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL)
                           AND HORASTRAB.CAD_PRO_ID_PROFISSIONAL IS NULL
                           --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_CLC_ID )))
                           AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                           AND (PCAD_UNI_ID_UNIDADE IS NULL OR CPR.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_UNI_ID_UNIDADE ))))
                           AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR HORASTRAB.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_LAT_ID_LOCAL_ATENDIMENTO ))))
                           AND PAGOHACFS > 0
                           AND RPG.ASS_RPG_PC_HAC > 0
                           AND NOT EXISTS (SELECT *
                                             FROM TB_REP_PPC_PAG_PROF_CLI PPC
                                            WHERE PPC.CAD_CLC_ID=CPR.CAD_CLC_ID
                                              AND PPC.CAD_HTR_ID = HORASTRAB.CAD_HTR_ID
                                              AND PPC.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                                              AND PPC.CAD_LAT_ID_LOCAL = HORASTRAB.CAD_LAT_ID_LOCAL_ATENDIMENTO
                                              AND PPC.REP_PPC_MES_PAGTO = PREP_PGM_MES_PAGTO
                                              AND PPC.REP_PPC_ANO_PAGTO = PREP_PGM_ANO_PAGTO
                                              AND PPC.CAD_REP_TP_BASE_CALCULO = 'VLHRPLAFS'
                                              AND PPC.REP_PPC_FONTE_PAGADORA = 'HAC')                               
               UNION ALL
               -- ACS
               SELECT DISTINCT CPR.CAD_CLC_ID,
                               CLC.CAD_CLC_CD_CLINICA,
                               CLC.CAD_CLC_DS_DESCRICAO,
                               CPR.CAD_UNI_ID_UNIDADE UNID,
                               HORASTRAB.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                               RPG.ASS_RPG_PC_HAC                   PCHAC,
                               RPG.ASS_RPG_PC_ACS                   PCACS,
                               0 PAGOHAC,
                               HORASTRAB.PAGOACS,
                               HORASTRAB.CAD_HTR_DT_INICIO_VIGENCIA,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_TP_BASE_CALCULO,
                               REP.CAD_REP_ID,
                               'MC' CREDENCIAMENTO,
                               'ACS' FONTEPAGADORA,
                               HORASTRAB.CAD_HTR_ID
                          FROM TB_ASS_CPR_CLINICA_PROF CPR,
                               TB_CAD_REP_REGRA_PAGAMENTO REP,
                               TB_ASS_RPG_REGRA_PAGTO RPG,
                               TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                               TB_REP_IMPORTACAO_CLI_TEMP     ICT,
                               (SELECT DISTINCT HTR.CAD_HTR_ID,
                                                CLC.CAD_CLC_ID,
                                                CPR.CAD_UNI_ID_UNIDADE,
                                                HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                REP.CAD_REP_VL_PAGTO,
                                                HTR.CAD_HTR_QT_HORA_SEMANA,
                                                HTR.CAD_HTR_VL_FATOR_MULTI_SEMANA,
                                                HTR.CAD_HTR_QT_HORA_FIM_SEMANA,
                                                HTR.CAD_PRO_ID_PROFISSIONAL,
                                                HTR.CAD_HTR_VL_FATOR_MULTI_FIMSEM,
                                                RPG.ASS_RPG_PC_HAC,
                                                RPG.ASS_RPG_PC_ACS,
                                                (((HTR.CAD_HTR_QT_HORA_SEMANA * HTR.CAD_HTR_VL_FATOR_MULTI_SEMANA) * CAD_REP_VL_PAGTO) * RPG.ASS_RPG_PC_HAC) / 100 PAGOHAC,
                                                (((HTR.CAD_HTR_QT_HORA_SEMANA * HTR.CAD_HTR_VL_FATOR_MULTI_SEMANA) * CAD_REP_VL_PAGTO) * RPG.ASS_RPG_PC_ACS) / 100 PAGOACS,
                                                HTR.CAD_HTR_DT_INICIO_VIGENCIA
                                           FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                                                TB_CAD_REP_REGRA_PAGAMENTO     REP,
                                                TB_ASS_RPG_REGRA_PAGTO         RPG,
                                                TB_CAD_HTR_HORA_TRAB           HTR,
                                                TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                                                TB_REP_IMPORTACAO_CLI_TEMP     ICT
                                          WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                                            AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                                            AND REP.CAD_REP_TP_BASE_CALCULO = ('VLHRPLANT')
                                            AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                                            AND HTR.CAD_CLC_ID = CLC.CAD_CLC_ID
                                            AND CPR.CAD_UNI_ID_UNIDADE = HTR.CAD_UNI_ID_UNIDADE
                      AND (CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO OR CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL)
                                            AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                                            AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                                            AND HTR.CAD_PRO_ID_PROFISSIONAL IS NULL
                                            --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_CLC_ID )))
                                            AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                                            AND (PCAD_UNI_ID_UNIDADE IS NULL OR CPR.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_UNI_ID_UNIDADE ))))
                                            AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_LAT_ID_LOCAL_ATENDIMENTO ))))
                                            AND HTR.CAD_HTR_DT_INICIO_VIGENCIA = PCAD_HTR_DT_INICIO_VIGENCIA ) HORASTRAB
                         WHERE CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                           AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLHRPLANT')
                           AND CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                           AND RPG.CAD_REP_ID = REP.CAD_REP_ID
                           AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                           AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                           AND CPR.CAD_CLC_ID = HORASTRAB.CAD_CLC_ID
                           AND CPR.CAD_UNI_ID_UNIDADE = HORASTRAB.CAD_UNI_ID_UNIDADE
                           AND (CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = HORASTRAB.CAD_LAT_ID_LOCAL_ATENDIMENTO OR CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL)
                           AND HORASTRAB.CAD_PRO_ID_PROFISSIONAL IS NULL
                           --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_CLC_ID )))
                           AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                           AND (PCAD_UNI_ID_UNIDADE IS NULL OR CPR.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_UNI_ID_UNIDADE ))))
                           AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR HORASTRAB.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_LAT_ID_LOCAL_ATENDIMENTO ))))
                           AND PAGOACS > 0
                           AND RPG.ASS_RPG_PC_ACS > 0
                           AND NOT EXISTS (SELECT *
                                             FROM TB_REP_PPC_PAG_PROF_CLI PPC
                                            WHERE PPC.CAD_CLC_ID = CPR.CAD_CLC_ID
                                              AND PPC.CAD_HTR_ID = HORASTRAB.CAD_HTR_ID
                                              AND PPC.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                                              AND PPC.CAD_LAT_ID_LOCAL = HORASTRAB.CAD_LAT_ID_LOCAL_ATENDIMENTO
                                              AND PPC.REP_PPC_MES_PAGTO = PREP_PGM_MES_PAGTO
                                              AND PPC.REP_PPC_ANO_PAGTO = PREP_PGM_ANO_PAGTO
                                              AND PPC.CAD_REP_TP_BASE_CALCULO = 'VLHRPLANT'
                                              AND PPC.REP_PPC_FONTE_PAGADORA = 'ACS')
                      UNION ALL 
                      --ACSFS
                       SELECT DISTINCT CPR.CAD_CLC_ID,
                               CLC.CAD_CLC_CD_CLINICA,
                               CLC.CAD_CLC_DS_DESCRICAO,
                               CPR.CAD_UNI_ID_UNIDADE UNID,
                               HORASTRAB.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                               RPG.ASS_RPG_PC_HAC                   PCHAC,
                               RPG.ASS_RPG_PC_ACS                   PCACS,
                               0 PAGOHACFS,
                               HORASTRAB.PAGOACSFS,
                               HORASTRAB.CAD_HTR_DT_INICIO_VIGENCIA,
                               REP.CAD_REP_VL_PAGTO_EXTRA,
                               REP.CAD_REP_TP_BASE_CALCULO,
                               REP.CAD_REP_ID,
                               'MC' CREDENCIAMENTO,
                               'ACS' FONTEPAGADORA,
                               HORASTRAB.CAD_HTR_ID
                          FROM TB_ASS_CPR_CLINICA_PROF CPR,
                               TB_CAD_REP_REGRA_PAGAMENTO REP,
                               TB_ASS_RPG_REGRA_PAGTO RPG,
                               TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                               TB_REP_IMPORTACAO_CLI_TEMP     ICT,
                               (SELECT DISTINCT HTR.CAD_HTR_ID,
                                                CLC.CAD_CLC_ID,
                                                CPR.CAD_UNI_ID_UNIDADE,
                                                HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                REP.CAD_REP_VL_PAGTO,
                                                HTR.CAD_HTR_QT_HORA_SEMANA,
                                                HTR.CAD_HTR_VL_FATOR_MULTI_SEMANA,
                                                HTR.CAD_HTR_QT_HORA_FIM_SEMANA,
                                                HTR.CAD_PRO_ID_PROFISSIONAL,
                                                HTR.CAD_HTR_VL_FATOR_MULTI_FIMSEM,
                                                RPG.ASS_RPG_PC_HAC,
                                                RPG.ASS_RPG_PC_ACS,
                                                (((HTR.CAD_HTR_QT_HORA_FIM_SEMANA * HTR.CAD_HTR_VL_FATOR_MULTI_FIMSEM) * REP.CAD_REP_VL_PAGTO_EXTRA) * RPG.ASS_RPG_PC_HAC) / 100 PAGOHACFS,
                                                (((HTR.CAD_HTR_QT_HORA_FIM_SEMANA * HTR.CAD_HTR_VL_FATOR_MULTI_FIMSEM) * REP.CAD_REP_VL_PAGTO_EXTRA) * RPG.ASS_RPG_PC_ACS) / 100 PAGOACSFS,
                                                HTR.CAD_HTR_DT_INICIO_VIGENCIA
                                           FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                                                TB_CAD_REP_REGRA_PAGAMENTO     REP,
                                                TB_ASS_RPG_REGRA_PAGTO         RPG,
                                                TB_CAD_HTR_HORA_TRAB           HTR,
                                                TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                                                TB_REP_IMPORTACAO_CLI_TEMP     ICT
                                          WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                                            AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                                            AND REP.CAD_REP_TP_BASE_CALCULO = ('VLHRPLAFS')
                                            AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                                            AND HTR.CAD_CLC_ID = CLC.CAD_CLC_ID
                                            AND CPR.CAD_UNI_ID_UNIDADE = HTR.CAD_UNI_ID_UNIDADE
                      AND (CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO OR CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL)
                                            AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                                            AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                                            AND HTR.CAD_PRO_ID_PROFISSIONAL IS NULL
                                            --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_CLC_ID )))
                                            AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                                            AND (PCAD_UNI_ID_UNIDADE IS NULL OR CPR.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_UNI_ID_UNIDADE ))))
                                            AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_LAT_ID_LOCAL_ATENDIMENTO ))))
                                            AND HTR.CAD_HTR_DT_INICIO_VIGENCIA = PCAD_HTR_DT_INICIO_VIGENCIA ) HORASTRAB
                         WHERE CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                           AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLHRPLAFS')
                           AND CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                           AND RPG.CAD_REP_ID = REP.CAD_REP_ID
                           AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                           AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                           AND CPR.CAD_CLC_ID = HORASTRAB.CAD_CLC_ID
                           AND CPR.CAD_UNI_ID_UNIDADE = HORASTRAB.CAD_UNI_ID_UNIDADE
                           AND (CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = HORASTRAB.CAD_LAT_ID_LOCAL_ATENDIMENTO OR CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL)
                           AND HORASTRAB.CAD_PRO_ID_PROFISSIONAL IS NULL
                           --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_CLC_ID )))
                           AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                           AND (PCAD_UNI_ID_UNIDADE IS NULL OR CPR.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_UNI_ID_UNIDADE ))))
                           AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR HORASTRAB.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_LAT_ID_LOCAL_ATENDIMENTO ))))
                           AND PAGOACSFS > 0
                           AND RPG.ASS_RPG_PC_ACS > 0
                           AND NOT EXISTS (SELECT *
                                             FROM TB_REP_PPC_PAG_PROF_CLI PPC
                                            WHERE PPC.CAD_CLC_ID = CPR.CAD_CLC_ID
                                              AND PPC.CAD_HTR_ID = HORASTRAB.CAD_HTR_ID
                                              AND PPC.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                                              AND PPC.CAD_LAT_ID_LOCAL = HORASTRAB.CAD_LAT_ID_LOCAL_ATENDIMENTO
                                              AND PPC.REP_PPC_MES_PAGTO = PREP_PGM_MES_PAGTO
                                              AND PPC.REP_PPC_ANO_PAGTO = PREP_PGM_ANO_PAGTO
                                              AND PPC.CAD_REP_TP_BASE_CALCULO = 'VLHRPLAFS'
                                              AND PPC.REP_PPC_FONTE_PAGADORA = 'ACS')
                              ) LOOP
    BEGIN
      INSERT INTO TB_REP_PPC_PAG_PROF_CLI PPC
        (PPC.REP_PPC_ID,
         PPC.CAD_CLC_ID,
         PPC.CAD_UNI_ID_UNIDADE,
         PPC.CAD_LAT_ID_LOCAL,
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
         TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO,
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
END PRC_REP_CAL_VALORHORAPLANTAO;