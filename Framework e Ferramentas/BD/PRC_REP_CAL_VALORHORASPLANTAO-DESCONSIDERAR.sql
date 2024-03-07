CREATE OR REPLACE PROCEDURE PRC_REP_CAL_VALORHORASPLANTAO(PREP_PGM_MES_FECHAMENTO IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_FECHAMENTO%TYPE,
                                                          PREP_PGM_ANO_FECHAMENTO IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_FECHAMENTO%TYPE,
                                                          PREP_PGM_MES_PAGTO      IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
                                                          PREP_PGM_ANO_PAGTO      IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE,
                                                          PSEG_USU_ID_USUARIO     IN TB_REP_PPC_PAG_PROF_CLI.SEG_USU_ID_USUARIO%TYPE,
                                                          PCLINICAS               IN STRING) IS

  /********************************************************************
  *    PROCEDURE: PRC_REP_IMP_REPASSE_FATURADO
  *
  *    DATA CRIACAO:   01/05/2012   POR:
  *    DATA ALTERACAO:  DATA DA ALTERAÇÃO  POR: NOME DO ANALISTA
  *
  *    FUNCAO: IMPORTAR PRODUTIVIDADE PASSANDO CLINICA UNIDADE E LOCAL [P3]
  *
  *******************************************************************/
  --LIDTRETORNO NUMBER;

BEGIN

  BEGIN
    FOR TEMP IN (SELECT DISTINCT REP.CAD_REP_ID,
                                 CPR.CAD_CLC_ID,
                                 CLC.CAD_CLC_CD_CLINICA,
                                 CLC.CAD_CLC_DS_DESCRICAO,
                                 CPR.CAD_UNI_ID_UNIDADE UNID,
                                 CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                 RPG.ASS_RPG_PC_HAC PCHAC,
                                 RPG.ASS_RPG_PC_ACS PCACS,
                                 HORASTRAB.PAGOHAC,
                                 HORASTRAB.PAGOACS,
                                 RPG.ASS_RPG_ID,
                                 CASE
                                   WHEN RPG.ASS_RPG_PC_HAC > 0 AND
                                        RPG.ASS_RPG_PC_ACS = 0 THEN
                                    'HAC'
                                   WHEN RPG.ASS_RPG_PC_ACS > 0 AND
                                        RPG.ASS_RPG_PC_HAC = 0 THEN
                                    'ACS'
                                 END FONTEPAG,
                                 REP.CAD_REP_VL_MINIMO,
                                 REP.CAD_REP_VL_PAGTO_FIXO,
                                 REP.CAD_REP_VL_PAGTO,
                                 UNI.CAD_UNI_DS_UNIDADE,
                                 PRO.CAD_PRO_ID_PROFISSIONAL
                   FROM TB_ASS_CPR_CLINICA_PROF CPR,
                        TB_CAD_REP_REGRA_PAGAMENTO REP,
                        TB_ASS_RPG_REGRA_PAGTO RPG,
                        TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                        TB_CAD_PRO_PROFISSIONAL PRO,
                        TB_CAD_UNI_UNIDADE UNI,
                        (SELECT DISTINCT CLC.CAD_CLC_ID,
                                         CPR.CAD_UNI_ID_UNIDADE,
                                         CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                         REP.CAD_REP_VL_PAGTO,
                                         HTR.CAD_HTR_QT_HORA_SEMANA,
                                         HTR.CAD_HTR_VL_FATOR_MULTI_SEMANA,
                                         HTR.CAD_HTR_QT_HORA_FIM_SEMANA,
                                         HTR.CAD_PRO_ID_PROFISSIONAL,
                                         HTR.CAD_HTR_VL_FATOR_MULTI_FIMSEM,
                                         RPG.ASS_RPG_PC_HAC,
                                         RPG.ASS_RPG_PC_ACS,
                                         (((HTR.CAD_HTR_QT_HORA_SEMANA *
                                         HTR.CAD_HTR_VL_FATOR_MULTI_SEMANA) *
                                         CAD_REP_VL_PAGTO) *
                                         RPG.ASS_RPG_PC_HAC) / 100 PAGOHAC,
                                         (((HTR.CAD_HTR_QT_HORA_SEMANA *
                                         HTR.CAD_HTR_VL_FATOR_MULTI_SEMANA) *
                                         CAD_REP_VL_PAGTO) *
                                         RPG.ASS_RPG_PC_ACS) / 100 PAGOACS
                         
                           FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                                TB_CAD_REP_REGRA_PAGAMENTO     REP,
                                TB_ASS_RPG_REGRA_PAGTO         RPG,
                                TB_CAD_HTR_HORA_TRAB           HTR,
                                TB_CAD_CLC_CLINICA_CREDENCIADA CLC
                          WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                            AND REP.CAD_REP_ID = RPG.CAD_REP_ID 
                            AND CLC.CAD_CLC_CD_CLINICA IN ( SELECT * FROM TABLE(FNC_SPLIT( PCLINICAS )))
                            AND REP.CAD_REP_TP_BASE_CALCULO = ('VLHRPLANT')
                            AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                            AND HTR.CAD_CLC_ID = CLC.CAD_CLC_ID
                            AND CPR.CAD_UNI_ID_UNIDADE =
                                HTR.CAD_UNI_ID_UNIDADE
                            AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                            AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO =
                                HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                            AND HTR.CAD_PRO_ID_PROFISSIONAL IS NULL
                            AND HTR.CAD_HTR_DT_FIM_VIGENCIA IS NULL) HORASTRAB
                 /*                   FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                                         TB_CAD_REP_REGRA_PAGAMENTO     REP,
                                         TB_ASS_RPG_REGRA_PAGTO         RPG,
                                         TB_CAD_HTR_HORA_TRAB           HTR,
                                         TB_CAD_CLC_CLINICA_CREDENCIADA CLC
                                   WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                                     AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                                     AND CLC.CAD_CLC_CD_CLINICA IN 4
                                     AND REP.CAD_REP_TP_BASE_CALCULO = ('VLHRPLANT')
                                     AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                                     AND HTR.CAD_CLC_ID = CLC.CAD_CLC_ID
                                     AND CPR.CAD_UNI_ID_UNIDADE = HTR.CAD_UNI_ID_UNIDADE
                                     AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL
                                     AND HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL
                                     AND HTR.CAD_PRO_ID_PROFISSIONAL IS NULL
                 */
                  WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                    AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                    AND CPR.CAD_CLC_ID = CLC.CAD_CLC_ID
                    AND CLC.CAD_CLC_CD_CLINICA IN (SELECT * FROM TABLE(FNC_SPLIT( PCLINICAS )))
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLHRPLANT')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL =
                        CPR.CAD_PRO_ID_PROFISSIONAL
                    AND UNI.CAD_UNI_ID_UNIDADE(+) = CPR.CAD_UNI_ID_UNIDADE
                    AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                    AND CPR.CAD_CLC_ID = HORASTRAB.CAD_CLC_ID
                    AND CPR.CAD_UNI_ID_UNIDADE =
                        HORASTRAB.CAD_UNI_ID_UNIDADE
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO =
                        HORASTRAB.CAD_LAT_ID_LOCAL_ATENDIMENTO
                    AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PAGOHAC > 0
                  ORDER BY CLC.CAD_CLC_CD_CLINICA
                 
                 ) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID        = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_FL_PAGO   = 'P',
               PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO,
               PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
        
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_UNI_ID_UNIDADE = TEMP.UNID
           AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO =
               TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
           AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
           AND PGM.ASS_RPG_ID IS NULL
           AND PGM.REP_PGM_MES_FECHAMENTO = PREP_PGM_MES_FECHAMENTO
           AND PGM.REP_PGM_ANO_FECHAMENTO = PREP_PGM_ANO_FECHAMENTO;
      
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
           PPC.CAD_REP_TP_BASE_CALCULO)
        VALUES
          (SEQ_REP_PPC_01.NEXTVAL,
           TEMP.CAD_CLC_ID,
           TEMP.UNID,
           TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO,
           TEMP.PAGOHAC,
           0,
           PREP_PGM_MES_FECHAMENTO,
           PREP_PGM_ANO_FECHAMENTO,
           PREP_PGM_MES_PAGTO,
           PREP_PGM_ANO_PAGTO,
           PSEG_USU_ID_USUARIO,
           SYSDATE,
           'F',
           'VLHRPLANT');
      
/*        INSERT INTO TB_REP_RPA_RESUMO_PAGTO
          (REP_RPA_ID,
           CAD_CLC_ID,
           REP_RPA_DT_PAGAMENTO,
           REP_RPA_MES_PAGTO,
           REP_RPA_ANO_PAGTO,
           REP_RPA_TP_CREDENCIA_PROF,
           REP_RPA_VL_PAGTO_CLINICA,
           SEG_USU_ID_USUARIO,
           REP_RPA_DT_ULTIMA_ATUALIZACAO,
           REP_RPA_DT_CRIACAO,
           SEG_USU_ID_USUARIO_CRIACAO,
           REP_RPA_VL_DESCONTO,
           CAD_UNI_ID_UNIDADE,
           REP_RPA_VL_ACRESCIMO,
           REP_RPA_DT_INICIO,
           REP_RPA_DT_FIM,
           ID_CAD_JPG,
           REP_PRA_VL_IMPOSTO,
           REP_RPA_FL_STATUS,
           REP_RPA_FONTE_PAGADORA)
        VALUES
          (SEQ_REP_RPA_01.NEXTVAL,
           TEMP.CAD_CLC_ID,
           SYSDATE,
           PREP_PGM_MES_PAGTO,
           PREP_PGM_ANO_PAGTO,
           'MF',
           TEMP.PAGOHAC,
           PSEG_USU_ID_USUARIO,
           SYSDATE,
           SYSDATE,
           PSEG_USU_ID_USUARIO,
           0,
           TEMP.UNID,
           0,
           NULL,
           NULL,
           NULL,
           NULL,
           'A',
           'HAC');
*/      
      END;
    END LOOP COMMIT;
  END;

  -------------------------ACS

  BEGIN
    FOR TEMP IN (SELECT DISTINCT REP.CAD_REP_ID,
                                 CPR.CAD_CLC_ID,
                                 CLC.CAD_CLC_CD_CLINICA,
                                 CLC.CAD_CLC_DS_DESCRICAO,
                                 CPR.CAD_UNI_ID_UNIDADE UNID,
                                 CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                 RPG.ASS_RPG_PC_HAC PCHAC,
                                 RPG.ASS_RPG_PC_ACS PCACS,
                                 HORASTRAB.PAGOHAC,
                                 HORASTRAB.PAGOACS,
                                 PRO.CAD_PRO_ID_PROFISSIONAL,
                                 RPG.ASS_RPG_ID,
                                 CASE
                                   WHEN RPG.ASS_RPG_PC_HAC > 0 AND
                                        RPG.ASS_RPG_PC_ACS = 0 THEN
                                    'HAC'
                                   WHEN RPG.ASS_RPG_PC_ACS > 0 AND
                                        RPG.ASS_RPG_PC_HAC = 0 THEN
                                    'ACS'
                                 END FONTEPAG,
                                 REP.CAD_REP_VL_MINIMO,
                                 REP.CAD_REP_VL_PAGTO_FIXO,
                                 REP.CAD_REP_VL_PAGTO,
                                 UNI.CAD_UNI_DS_UNIDADE
                   FROM TB_ASS_CPR_CLINICA_PROF CPR,
                        TB_CAD_REP_REGRA_PAGAMENTO REP,
                        TB_ASS_RPG_REGRA_PAGTO RPG,
                        TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                        TB_CAD_PRO_PROFISSIONAL PRO,
                        TB_CAD_UNI_UNIDADE UNI,
                        (SELECT DISTINCT CLC.CAD_CLC_ID,
                                         CPR.CAD_UNI_ID_UNIDADE,
                                         CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                         REP.CAD_REP_VL_PAGTO,
                                         HTR.CAD_HTR_QT_HORA_SEMANA,
                                         HTR.CAD_HTR_VL_FATOR_MULTI_SEMANA,
                                         HTR.CAD_HTR_QT_HORA_FIM_SEMANA,
                                         HTR.CAD_PRO_ID_PROFISSIONAL,
                                         HTR.CAD_HTR_VL_FATOR_MULTI_FIMSEM,
                                         RPG.ASS_RPG_PC_HAC,
                                         RPG.ASS_RPG_PC_ACS,
                                         (((HTR.CAD_HTR_QT_HORA_SEMANA *
                                         HTR.CAD_HTR_VL_FATOR_MULTI_SEMANA) *
                                         CAD_REP_VL_PAGTO) *
                                         RPG.ASS_RPG_PC_HAC) / 100 PAGOHAC,
                                         (((HTR.CAD_HTR_QT_HORA_SEMANA *
                                         HTR.CAD_HTR_VL_FATOR_MULTI_SEMANA) *
                                         CAD_REP_VL_PAGTO) *
                                         RPG.ASS_RPG_PC_ACS) / 100 PAGOACS
                         
                           FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                                TB_CAD_REP_REGRA_PAGAMENTO     REP,
                                TB_ASS_RPG_REGRA_PAGTO         RPG,
                                TB_CAD_HTR_HORA_TRAB           HTR,
                                TB_CAD_CLC_CLINICA_CREDENCIADA CLC
                          WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                            AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                            AND CLC.CAD_CLC_CD_CLINICA IN (SELECT * FROM TABLE(FNC_SPLIT( PCLINICAS )))
                            AND REP.CAD_REP_TP_BASE_CALCULO = ('VLHRPLANT')
                            AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                            AND HTR.CAD_CLC_ID = CLC.CAD_CLC_ID
                            AND CPR.CAD_UNI_ID_UNIDADE =
                                HTR.CAD_UNI_ID_UNIDADE
                            AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                            AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO =
                                HTR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                            AND HTR.CAD_PRO_ID_PROFISSIONAL IS NULL
                            AND HTR.CAD_HTR_DT_FIM_VIGENCIA IS NULL) HORASTRAB --AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID AND REP.CAD_REP_TP_BASE_CALCULO IN('VLHRPLANT') AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL AND UNI.CAD_UNI_ID_UNIDADE(+) = CPR.CAD_UNI_ID_UNIDADE AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL AND CPR.CAD_CLC_ID = HORASTRAB.CAD_CLC_ID AND CPR.CAD_UNI_ID_UNIDADE = HORASTRAB.CAD_UNI_ID_UNIDADE AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = HORASTRAB.CAD_LAT_ID_LOCAL_ATENDIMENTO AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL AND PAGOACS > 0
                  ORDER BY CLC.CAD_CLC_CD_CLINICA
                 
                 ) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID        = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_FL_PAGO   = 'P',
               PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO,
               PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_UNI_ID_UNIDADE = TEMP.UNID
           AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO =
               TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
           AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
           AND PGM.ASS_RPG_ID IS NULL
           AND PGM.REP_PGM_MES_FECHAMENTO = PREP_PGM_MES_FECHAMENTO
           AND PGM.REP_PGM_ANO_FECHAMENTO = PREP_PGM_ANO_FECHAMENTO;
      
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
           PPC.CAD_REP_TP_BASE_CALCULO)
        VALUES
          (SEQ_REP_PPC_01.NEXTVAL,
           TEMP.CAD_CLC_ID,
           TEMP.UNID,
           TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO,
           0,
           TEMP.PAGOACS,
           PREP_PGM_MES_FECHAMENTO,
           PREP_PGM_ANO_FECHAMENTO,
           PREP_PGM_MES_PAGTO,
           PREP_PGM_ANO_PAGTO,
           PSEG_USU_ID_USUARIO,
           SYSDATE,
           'F',
           'VLHRPLANT');
      
/*        INSERT INTO TB_REP_RPA_RESUMO_PAGTO
          (REP_RPA_ID,
           CAD_CLC_ID,
           REP_RPA_DT_PAGAMENTO,
           REP_RPA_MES_PAGTO,
           REP_RPA_ANO_PAGTO,
           REP_RPA_TP_CREDENCIA_PROF,
           REP_RPA_VL_PAGTO_CLINICA,
           SEG_USU_ID_USUARIO,
           REP_RPA_DT_ULTIMA_ATUALIZACAO,
           REP_RPA_DT_CRIACAO,
           SEG_USU_ID_USUARIO_CRIACAO,
           REP_RPA_VL_DESCONTO,
           CAD_UNI_ID_UNIDADE,
           REP_RPA_VL_ACRESCIMO,
           REP_RPA_DT_INICIO,
           REP_RPA_DT_FIM,
           ID_CAD_JPG,
           REP_PRA_VL_IMPOSTO,
           REP_RPA_FL_STATUS,
           REP_RPA_FONTE_PAGADORA)
        VALUES
          (SEQ_REP_RPA_01.NEXTVAL,
           TEMP.CAD_CLC_ID,
           SYSDATE,
           PREP_PGM_MES_PAGTO,
           PREP_PGM_ANO_PAGTO,
           'MC',
           TEMP.PAGOACS,
           PSEG_USU_ID_USUARIO,
           SYSDATE,
           SYSDATE,
           PSEG_USU_ID_USUARIO,
           0,
           TEMP.UNID,
           0,
           NULL,
           NULL,
           NULL,
           NULL,
           'A',
           'ACS');*/
      
      END;
    END LOOP COMMIT;
  END;

END PRC_REP_CAL_VALORHORASPLANTAO;
/
