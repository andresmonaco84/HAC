CREATE OR REPLACE PROCEDURE SGS."PRC_REP_CAL_VALORCHFIXO"
 (PREP_PGM_MES_PAGTO                    IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
  PREP_PGM_ANO_PAGTO                    IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE,
  PSEG_USU_ID_USUARIO                   IN TB_REP_PPC_PAG_PROF_CLI.SEG_USU_ID_USUARIO%TYPE,
  --PCAD_CLC_ID                           IN STRING,
  PCAD_UNI_ID_UNIDADE                   IN STRING,
  PCAD_LAT_ID_LOCAL_ATENDIMENTO         IN STRING,
  PCAD_PRO_ID_PROFISSIONAL              IN STRING
) IS
  /********************************************************************
  *    PROCEDURE: PRC_REP_CAL_VALORCHFIXO
  *
  *    DATA CRIACAO:    30/01/2013   POR:
  *    DATA ALTERACAO:  DATA DA ALTERA¨¿O  POR: NOME DO ANALISTA
  *
  *    FUNCAO:
  *
  *******************************************************************/
BEGIN
BEGIN
  FOR TEMP IN (SELECT DISTINCT PGM.REP_PGM_ID,
                               CPR.ASS_CPR_ID,
                               RPG.ASS_RPG_ID,
                               REP.CAD_REP_ID,
                               CPR.CAD_CLC_ID,
                               CLC.CAD_CLC_CD_CLINICA,
                               CLC.CAD_CLC_DS_DESCRICAO,
                               CPR.CAD_UNI_ID_UNIDADE,
                               CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                               CPR.TIS_CBO_CD_CBOS,
                               CPR.CAD_PRD_ID,
                               CPR.TIS_MED_CD_TABELAMEDICA,
                               CPR.AUX_EPP_CD_ESPECPROC,
                               CPR.AUX_GPC_CD_GRUPOPROC,
                               CPR.CAD_CNV_ID_CONVENIO,
                               CPR.CAD_SET_ID,
                               REP.CAD_REP_TP_BASE_CALCULO,
                               CPR.CAD_TPE_CD_CODIGO,
                               CPR.CAD_PRO_ID_PROFISSIONAL,
                               REP.CAD_REP_VL_MINIMO,
                               REP.CAD_REP_QT_INDICE,
                               REP.CAD_REP_VL_INDICE_HOSP,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO,
							                 DECODE(RPG.ASS_RPG_PC_HAC,0,'ACS','HAC') FONTEPAGADORA

                          FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                               TB_CAD_REP_REGRA_PAGAMENTO     REP,
                               TB_ASS_RPG_REGRA_PAGTO         RPG,
                               TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                               TB_CAD_PRO_PROFISSIONAL        PRO,
                               TB_REP_PGM_PAGTO_MEDICO        PGM,
                               TB_REP_IMPORTACAO_CLI_TEMP     ICT

                         WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                           AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                           AND CPR.CAD_CLC_ID = CLC.CAD_CLC_ID
                           AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                           AND REP.CAD_REP_TP_BASE_CALCULO IN ('CHFIX')
                           AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                           AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                           AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                           AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                           AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                           AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                           AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                           AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                           AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                           AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                           AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                           AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                           AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
                           AND NVL(REP.CAD_REP_VL_INDICE_HOSP, 0) > 0
                           AND NVL(REP.CAD_REP_QT_INDICE, 0) > 0
                           AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                           AND CPR.CAD_PRD_ID IS NOT NULL
                           --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_CLC_ID )))
                           AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                           AND (PCAD_UNI_ID_UNIDADE IS NULL OR CPR.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_UNI_ID_UNIDADE ))))
                           AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO  IS NULL OR CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_LAT_ID_LOCAL_ATENDIMENTO ))))
                           AND (PCAD_PRO_ID_PROFISSIONAL IS NULL OR CPR.CAD_PRO_ID_PROFISSIONAL IN (SELECT * FROM TABLE(FNC_SPLIT( PCAD_PRO_ID_PROFISSIONAL ))))
                           ) LOOP
    BEGIN

      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM

         SET PGM.ASS_RPG_ID = TEMP.ASS_RPG_ID,
                              PGM.REP_PGM_VL_PAGO = (TEMP.CAD_REP_VL_INDICE_HOSP * TEMP.CAD_REP_QT_INDICE) * PGM.REP_PGM_QT_CONSUMO,
                              PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
                              PGM.SEG_USU_ID_USUARIO_ATUALIZ = PSEG_USU_ID_USUARIO

       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_FONTE_PAGADORA = TEMP.FONTEPAGADORA
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP COMMIT;
END;

END PRC_REP_CAL_VALORCHFIXO;