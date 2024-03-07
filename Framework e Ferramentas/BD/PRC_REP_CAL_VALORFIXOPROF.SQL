CREATE OR REPLACE PROCEDURE SGS."PRC_REP_CAL_VALORFIXOPROF"
 (PREP_PGM_MES_FECHAMENTO               IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_FECHAMENTO%TYPE,
  PREP_PGM_ANO_FECHAMENTO               IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_FECHAMENTO%TYPE,
  PREP_PGM_MES_PAGTO                    IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
  PREP_PGM_ANO_PAGTO                    IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE,
  PSEG_USU_ID_USUARIO                   IN TB_REP_PPC_PAG_PROF_CLI.SEG_USU_ID_USUARIO%TYPE,
  --PCAD_CLC_ID                           IN STRING,
  PCAD_UNI_ID_UNIDADE                   IN STRING,
  PCAD_LAT_ID_LOCAL_ATENDIMENTO         IN STRING,
  PCAD_PRO_ID_PROFISSIONAL              IN STRING,
  PREP_PPC_FL_ANTECIPACAO               IN TB_REP_PPC_PAG_PROF_CLI.REP_PPC_FL_ANTECIPACAO%TYPE
) IS
  /********************************************************************
  *    PROCEDURE: PRC_REP_CAL_VALORFIXOPROF
  *
  *    DATA CRIACAO:    30/01/2013   POR:
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
                               CPR.CAD_UNI_ID_UNIDADE UNID,
                               CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO LOCALATEN,
                               RPG.ASS_RPG_PC_HAC               PCHAC,
                               RPG.ASS_RPG_PC_ACS               PCACS,
                               CPR.CAD_PRO_ID_PROFISSIONAL PROFISSIONAL,
                               REP.CAD_REP_VL_PAGTO PAGOHAC,
                               0                    PAGOACS,
                                REP.CAD_REP_ID,
                               'MF' CREDENCIAMENTO,
                               'HAC' FONTEPAGADORA
                          FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                               TB_CAD_REP_REGRA_PAGAMENTO     REP,
                               TB_ASS_RPG_REGRA_PAGTO         RPG,
                               TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                               TB_CAD_PRO_PROFISSIONAL        PRO,
                               TB_REP_IMPORTACAO_CLI_TEMP     ICT
                         WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                           AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                           AND CPR.CAD_CLC_ID = CLC.CAD_CLC_ID
                           AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                           AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIXOPROF')
                           AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                           AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                           AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                           AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                           AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                           AND RPG.ASS_RPG_PC_HAC > 0
                           AND RPG.ASS_RPG_PC_ACS = 0
                           --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_CLC_ID )))
                           AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                           AND (PCAD_UNI_ID_UNIDADE IS NULL OR CPR.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_UNI_ID_UNIDADE ))))
                           AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_LAT_ID_LOCAL_ATENDIMENTO ))))
                           AND (PCAD_PRO_ID_PROFISSIONAL IS NULL OR PRO.CAD_PRO_ID_PROFISSIONAL IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_PRO_ID_PROFISSIONAL ))))
                           AND NOT EXISTS (SELECT * FROM TB_REP_PPC_PAG_PROF_CLI PPC 
                           WHERE PPC.CAD_CLC_ID=CPR.CAD_CLC_ID 
                           AND  PPC.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                           AND PPC.CAD_LAT_ID_LOCAL = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                           AND PPC.CAD_REP_TP_BASE_CALCULO = 'VLFIXOPROF'
                           AND PPC.REP_PPC_FONTE_PAGADORA = 'HAC' 
                           AND PPC.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                           AND PPC.REP_PPC_VL_PAGO_HAC = REP.CAD_REP_VL_PAGTO
                           AND PPC.REP_PPC_MES_PAGTO =  PREP_PGM_MES_PAGTO
                           AND PPC.REP_PPC_ANO_PAGTO =  PREP_PGM_ANO_PAGTO)
               UNION ALL
               -- ACS
               SELECT DISTINCT CPR.CAD_CLC_ID,
                               CPR.CAD_UNI_ID_UNIDADE UNID,
                               CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO LOCALATEN,
                               RPG.ASS_RPG_PC_HAC               PCHAC,
                               RPG.ASS_RPG_PC_ACS               PCACS,
                               CPR.CAD_PRO_ID_PROFISSIONAL PROFISSIONAL,
                               0 PAGOHAC,
                               REP.CAD_REP_VL_PAGTO PAGOACS,
                               REP.CAD_REP_ID,
                               'MC' CREDENCIAMENTO,
                               'ACS' FONTEPAGADORA
                          FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                               TB_CAD_REP_REGRA_PAGAMENTO     REP,
                               TB_ASS_RPG_REGRA_PAGTO         RPG,
                               TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                               TB_CAD_PRO_PROFISSIONAL        PRO,
                               TB_REP_IMPORTACAO_CLI_TEMP     ICT
                         WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                           AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                           AND CPR.CAD_CLC_ID = CLC.CAD_CLC_ID
                           AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                           AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIXOPROF')
                           AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                           AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                           AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                           AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                           AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                           AND RPG.ASS_RPG_PC_ACS > 0
                           AND RPG.ASS_RPG_PC_HAC = 0
                           --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_CLC_ID )))
                           AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                           AND (PCAD_UNI_ID_UNIDADE IS NULL OR CPR.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_UNI_ID_UNIDADE ))))
                           AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_LAT_ID_LOCAL_ATENDIMENTO ))))
                           AND (PCAD_PRO_ID_PROFISSIONAL IS NULL OR PRO.CAD_PRO_ID_PROFISSIONAL IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_PRO_ID_PROFISSIONAL ))))
                           AND NOT EXISTS (SELECT * FROM TB_REP_PPC_PAG_PROF_CLI PPC 
                           WHERE PPC.CAD_CLC_ID=CPR.CAD_CLC_ID 
                           AND  PPC.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                           AND PPC.CAD_LAT_ID_LOCAL = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                           AND PPC.CAD_REP_TP_BASE_CALCULO = 'VLFIXOPROF'
                           AND PPC.REP_PPC_FONTE_PAGADORA = 'ACS' 
                           AND PPC.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                           AND PPC.REP_PPC_VL_PAGO_ACS = REP.CAD_REP_VL_PAGTO
                           AND PPC.REP_PPC_MES_PAGTO =  PREP_PGM_MES_PAGTO
                           AND PPC.REP_PPC_ANO_PAGTO =  PREP_PGM_ANO_PAGTO)
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
         'VLFIXOPROF',
         TEMP.CREDENCIAMENTO,
         TEMP.FONTEPAGADORA,
         SYSDATE,
         PSEG_USU_ID_USUARIO,
         PREP_PPC_FL_ANTECIPACAO,
         TEMP.CAD_REP_ID);
    END;
  END LOOP;
COMMIT;
END;
END PRC_REP_CAL_VALORFIXOPROF;
/