CREATE OR REPLACE PROCEDURE SGS."PRC_REP_CAL_FIXOATENDIMENTO" (PREP_PGM_MES_PAGTO          IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
                                                           PREP_PGM_ANO_PAGTO          IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE,
                                                           PSEG_USU_ID_USUARIO_ATUALIZ IN TB_REP_PPC_PAG_PROF_CLI.SEG_USU_ID_USUARIO%TYPE
--                                                           PCAD_CLC_ID                 IN STRING
) IS
  /********************************************************************
  *    PROCEDURE: PRC_REP_IMP_REPASSE_FATURADO
  *
  *    DATA CRIACAO:    01/05/2012   POR:
  *    DATA ALTERACAO:  DATA DA ALTERAC?O  POR: NOME DO ANALISTA
  *
  *    FUNCAO: IMPORTAR PRODUTIVIDADE PASSANDO CLINICA UNIDADE E LOCAL [P3]
  *
  *******************************************************************/
  --LIDTRETORNO NUMBER;
  BEGIN
  ----------------2 PRO
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                       --    AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                           AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                           AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                           AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                           AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                          --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                          --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                           AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                           AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                           AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                           AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                           AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                           AND CPR.CAD_PRD_ID IS NOT NULL
                           AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                           AND CPR.TIS_CBO_CD_CBOS IS NOT NULL
                           AND CPR.CAD_SET_ID IS NOT NULL
                           AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                           AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                           AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                           AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                           AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                           AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                           AND PGM.TIS_CBO_CD_CBOS = CPR.TIS_CBO_CD_CBOS
                           AND PGM.CAD_SET_ID_REALIZACAO = CPR.CAD_SET_ID
                           AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                           AND PGM.REP_PGM_FL_PAGO   = 'P'
                           AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                           AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
              ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO             
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND PGM.TIS_CBO_CD_CBOS = TEMP.TIS_CBO_CD_CBOS
         AND PGM.CAD_SET_ID_REALIZACAO = TEMP.CAD_SET_ID
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO   = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
------------------------------------------3 PROD
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                           --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                           AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                           AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                           AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                           AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                          --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                          --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                           AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                           AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                           AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                           AND CPR.CAD_PRD_ID IS NOT NULL
                           AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                           AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                           AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                           AND CPR.TIS_CBO_CD_CBOS IS NOT NULL
                           AND CPR.CAD_SET_ID IS NULL
                           AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                           AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                           AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                           AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                           AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                           AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                           AND PGM.TIS_CBO_CD_CBOS = CPR.TIS_CBO_CD_CBOS
                           AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                           AND PGM.REP_PGM_FL_PAGO   = 'P'
                           AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                           AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO                  
                  ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND PGM.TIS_CBO_CD_CBOS = TEMP.TIS_CBO_CD_CBOS
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO   = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
------------------------------- 4 PROD
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_PRD_ID IS NOT NULL
                  AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NULL
                  AND CPR.CAD_SET_ID IS NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                  AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO='P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
                  ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO             
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO='P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
-------------------------5 PROD
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL                 
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_PRD_ID IS NOT NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                  AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NOT NULL
                  AND CPR.CAD_SET_ID IS NOT NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                  AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                  AND PGM.TIS_CBO_CD_CBOS = CPR.TIS_CBO_CD_CBOS
                  AND PGM.CAD_SET_ID_REALIZACAO = CPR.CAD_SET_ID
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0 
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO             
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND PGM.TIS_CBO_CD_CBOS = TEMP.TIS_CBO_CD_CBOS
         AND PGM.CAD_SET_ID_REALIZACAO = TEMP.CAD_SET_ID
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0 
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
------------------------------------6 PROD
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL                 
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_PRD_ID IS NOT NULL
                  AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NULL
                  AND CPR.CAD_SET_ID IS NOT NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                  AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                  AND PGM.CAD_SET_ID_REALIZACAO = CPR.CAD_SET_ID
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO        
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO             
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND PGM.CAD_SET_ID_REALIZACAO = TEMP.CAD_SET_ID
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO        
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
------------------------------------ PROD 7
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_PRD_ID IS NOT NULL
                  AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NULL
                  AND CPR.CAD_SET_ID IS NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                  AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
                  AND PGM.REP_PGM_FL_PAGO = 'P'
         ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO             
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
-------------------------------------- PROD 8
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL                
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_PRD_ID IS NOT NULL
                  AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NOT NULL
                  AND CPR.CAD_SET_ID IS NOT NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND PGM.TIS_CBO_CD_CBOS = CPR.TIS_CBO_CD_CBOS
                  AND PGM.CAD_SET_ID_REALIZACAO = CPR.CAD_SET_ID
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,        
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO             
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND PGM.TIS_CBO_CD_CBOS = TEMP.TIS_CBO_CD_CBOS
         AND PGM.CAD_SET_ID_REALIZACAO = TEMP.CAD_SET_ID
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
------------------------ PROD 9
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL                  
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_PRD_ID IS NOT NULL
                  AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NOT NULL
                  AND CPR.CAD_SET_ID IS NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND PGM.TIS_CBO_CD_CBOS = CPR.TIS_CBO_CD_CBOS
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,        
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO             
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND PGM.TIS_CBO_CD_CBOS = TEMP.TIS_CBO_CD_CBOS
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
-------------------------------------10 PROD
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL                
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_PRD_ID IS NOT NULL
                  AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NULL
                  AND CPR.CAD_SET_ID IS NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,       
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO             
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
----------------------------------------11
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL                 
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_PRD_ID IS NOT NULL
                  AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NULL
                  AND CPR.CAD_SET_ID IS NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO             
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
---------------------------------12 PROD
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL                 
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_PRD_ID IS NOT NULL
                  AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NULL
                  AND CPR.CAD_SET_ID IS NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO 
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
-------------------PROD 13
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                  AND CPR.CAD_PRD_ID IS NOT NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NOT NULL
                  AND CPR.CAD_SET_ID IS NOT NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND PGM.TIS_CBO_CD_CBOS = CPR.TIS_CBO_CD_CBOS
                  AND PGM.CAD_SET_ID_REALIZACAO = CPR.CAD_SET_ID
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND PGM.TIS_CBO_CD_CBOS = TEMP.TIS_CBO_CD_CBOS
         AND PGM.CAD_SET_ID_REALIZACAO = TEMP.CAD_SET_ID
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
-------------------------- PROD14
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                  AND CPR.CAD_PRD_ID IS NOT NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NOT NULL
                  AND CPR.CAD_SET_ID IS NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND PGM.TIS_CBO_CD_CBOS = CPR.TIS_CBO_CD_CBOS
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO  
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND PGM.TIS_CBO_CD_CBOS = TEMP.TIS_CBO_CD_CBOS
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
------------------------------------- PROD15
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                  AND CPR.CAD_PRD_ID IS NOT NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NULL
                  AND CPR.CAD_SET_ID IS NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
-----------------------------PROD16
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                  AND CPR.CAD_PRD_ID IS NOT NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NULL
                  AND CPR.CAD_SET_ID IS NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO      
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
------------------------------PROD18
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL
                  AND CPR.CAD_PRD_ID IS NOT NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NOT NULL
                  AND CPR.CAD_SET_ID IS NOT NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                  AND PGM.TIS_CBO_CD_CBOS = CPR.TIS_CBO_CD_CBOS
                  AND PGM.CAD_SET_ID_REALIZACAO = CPR.CAD_SET_ID
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND PGM.TIS_CBO_CD_CBOS = TEMP.TIS_CBO_CD_CBOS
         AND PGM.CAD_SET_ID_REALIZACAO = TEMP.CAD_SET_ID
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
------------ PROD19
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL
                  AND CPR.CAD_PRD_ID IS NOT NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NOT NULL
                  AND CPR.CAD_SET_ID IS NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                  AND PGM.TIS_CBO_CD_CBOS = CPR.TIS_CBO_CD_CBOS
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO   
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND PGM.TIS_CBO_CD_CBOS = TEMP.TIS_CBO_CD_CBOS
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
------------------------------------------PROD20
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL
                  AND CPR.CAD_PRD_ID IS NOT NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NULL
                  AND CPR.CAD_SET_ID IS NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO 
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
-----------------------------------PROD21
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL
                  AND CPR.CAD_PRD_ID IS NOT NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NULL
                  AND CPR.CAD_SET_ID IS NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
---------------------------------------22
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
				  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL                  
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                  AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                  AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                  AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                  AND CPR.CAD_PRD_ID IS NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NOT NULL
                  AND CPR.CAD_SET_ID IS NOT NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                  AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                  AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                  AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND PGM.TIS_CBO_CD_CBOS = CPR.TIS_CBO_CD_CBOS
                  AND PGM.CAD_SET_ID_REALIZACAO = CPR.CAD_SET_ID
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0 
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO  
         ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO 
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
         AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
         AND PGM.AUX_GPC_CD_GRUPOPROC = TEMP.AUX_GPC_CD_GRUPOPROC
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND PGM.TIS_CBO_CD_CBOS = TEMP.TIS_CBO_CD_CBOS
         AND PGM.CAD_SET_ID_REALIZACAO = TEMP.CAD_SET_ID
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0 
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;  
    END;
  END LOOP;
   COMMIT;
END;
----------------------------------------23 GRUPO
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL                 
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                  AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                  AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                  AND CPR.AUX_GPC_CD_GRUPOPROC IS NULL
                  AND CPR.CAD_PRD_ID IS NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NOT NULL
                  AND CPR.CAD_SET_ID IS NOT NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                  AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                  AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND PGM.TIS_CBO_CD_CBOS = CPR.TIS_CBO_CD_CBOS
                  AND PGM.CAD_SET_ID_REALIZACAO = CPR.CAD_SET_ID
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
         AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND PGM.TIS_CBO_CD_CBOS = TEMP.TIS_CBO_CD_CBOS
         AND PGM.CAD_SET_ID_REALIZACAO = TEMP.CAD_SET_ID
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
----------------------24
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL                  
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                  AND CPR.TIS_MED_CD_TABELAMEDICA IS NULL
                  AND CPR.AUX_EPP_CD_ESPECPROC IS NULL
                  AND CPR.AUX_GPC_CD_GRUPOPROC IS NULL
                  AND CPR.CAD_PRD_ID IS NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NOT NULL
                  AND CPR.CAD_SET_ID IS NOT NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                  AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND PGM.TIS_CBO_CD_CBOS = CPR.TIS_CBO_CD_CBOS
                  AND PGM.CAD_SET_ID_REALIZACAO = CPR.CAD_SET_ID
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0 
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND PGM.TIS_CBO_CD_CBOS = TEMP.TIS_CBO_CD_CBOS
         AND PGM.CAD_SET_ID_REALIZACAO = TEMP.CAD_SET_ID
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0 
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;         
    END;
  END LOOP;
   COMMIT;
END;
---------------------------------25
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL                 
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                  AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                  AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                  AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                  AND CPR.CAD_PRD_ID IS NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NOT NULL
                  AND CPR.CAD_SET_ID IS NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                  AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                  AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                  AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND PGM.TIS_CBO_CD_CBOS = CPR.TIS_CBO_CD_CBOS
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO     
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
         AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
         AND PGM.AUX_GPC_CD_GRUPOPROC = TEMP.AUX_GPC_CD_GRUPOPROC
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND PGM.TIS_CBO_CD_CBOS = TEMP.TIS_CBO_CD_CBOS
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
---------------------------------26
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                  AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                  AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                  AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                  AND CPR.CAD_PRD_ID IS NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NULL
                  AND CPR.CAD_SET_ID IS NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                  AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                  AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                  AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0 
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO  
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
         AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
         AND PGM.AUX_GPC_CD_GRUPOPROC = TEMP.AUX_GPC_CD_GRUPOPROC
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0 
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
-------------------------------27
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL                 
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                  AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                  AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                  AND CPR.AUX_GPC_CD_GRUPOPROC IS NULL
                  AND CPR.CAD_PRD_ID IS NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NULL
                  AND CPR.CAD_SET_ID IS NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                  AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                  AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P' 
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
         AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P' 
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
--------------------------------------28
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL                  
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                  AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                  AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                  AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                  AND CPR.CAD_PRD_ID IS NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NULL
                  AND CPR.CAD_SET_ID IS NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                  AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                  AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                  AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
         AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
         AND PGM.AUX_GPC_CD_GRUPOPROC = TEMP.AUX_GPC_CD_GRUPOPROC
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
   COMMIT;
END;
----------------------------29
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL                  
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                  AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                  AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                  AND CPR.AUX_GPC_CD_GRUPOPROC IS NULL
                  AND CPR.CAD_PRD_ID IS NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NULL
                  AND CPR.CAD_SET_ID IS NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                  AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                  AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
         AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
  COMMIT;
END;
----------------------------  30
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL                  
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                  AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                  AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                  AND CPR.AUX_GPC_CD_GRUPOPROC IS NULL
                  AND CPR.CAD_PRD_ID IS NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                  AND CPR.TIS_CBO_CD_CBOS IS NOT NULL
                  AND CPR.CAD_SET_ID IS NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                  AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                  AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND PGM.TIS_CBO_CD_CBOS = CPR.TIS_CBO_CD_CBOS
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
         AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND PGM.TIS_CBO_CD_CBOS = TEMP.TIS_CBO_CD_CBOS
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
  COMMIT;
END;
--------------------------------------------------------4
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                  AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                  AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                  AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                  AND CPR.CAD_PRD_ID IS NOT NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                  AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                  AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                  AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO 
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
         AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
         AND PGM.AUX_GPC_CD_GRUPOPROC = TEMP.AUX_GPC_CD_GRUPOPROC
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
  COMMIT;
END;
----------------------------------------5
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                  AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                  AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                  AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                  AND CPR.CAD_PRD_ID IS NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                  AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                  AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
         AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
         AND PGM.AUX_GPC_CD_GRUPOPROC = TEMP.AUX_GPC_CD_GRUPOPROC
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
  COMMIT;
END;
----------------------------------------5A
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                  AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                  AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                  AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                  AND CPR.CAD_PRD_ID IS NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                  AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                  AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
         AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
         AND PGM.AUX_GPC_CD_GRUPOPROC = TEMP.AUX_GPC_CD_GRUPOPROC
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
  COMMIT;
END;
--------------------------------6 UNIDADE PRODUTO GUPO
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                  AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                  AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                  AND CPR.AUX_GPC_CD_GRUPOPROC IS NULL
                  AND CPR.CAD_PRD_ID IS NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                  AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
         AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
  COMMIT;
END;
-----------------------------7 UNIDADE/LOCAL NULO PROCEDIMENTO NOT NULL
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                  AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                  AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                  AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                  AND CPR.CAD_PRD_ID IS NOT NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                  AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                  AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                  AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
         AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
         AND PGM.AUX_GPC_CD_GRUPOPROC = TEMP.AUX_GPC_CD_GRUPOPROC
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
  COMMIT;
END;
-----------------------------8 UNIDADE/LOCAL NULO PROCEDIMENTO   NULL
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                  AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                  AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                  AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                  AND CPR.CAD_PRD_ID IS NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                  AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                  AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P' 
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
         AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
         AND PGM.AUX_GPC_CD_GRUPOPROC = TEMP.AUX_GPC_CD_GRUPOPROC
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P' 
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
  COMMIT;
END;
-----------------------------9 UNIDADE/LOCAL NULO PROCEDIMENTO SUBGRUPO  NULL
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
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
                  --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(  PCAD_CLC_ID  )))
                  AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                  AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                  --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  AND NVL(REP.CAD_REP_VL_PAGTO, 0) > 0
                  AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                  AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                  AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                  AND CPR.AUX_GPC_CD_GRUPOPROC IS NULL
                  AND CPR.CAD_PRD_ID IS NULL
                  AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL
                  AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                  AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                  AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                  AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                  AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                  AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                  AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                  AND PGM.REP_PGM_FL_PAGO = 'P'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
               ) LOOP
    BEGIN
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
         AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
  COMMIT;
END;
-------------------------
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
                               REP.CAD_REP_VL_PAGTO_FIXO,
                               REP.CAD_REP_VL_PAGTO,
                               REP.CAD_REP_PC_REPASSE,
                               CPR.SEG_USU_ID_USUARIO_CRIACAO
                          FROM TB_ASS_CPR_CLINICA_PROF CPR,
                               TB_CAD_REP_REGRA_PAGAMENTO REP,
                               TB_ASS_RPG_REGRA_PAGTO RPG,
                               TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                               TB_CAD_PRO_PROFISSIONAL PRO,
                               TB_REP_PGM_PAGTO_MEDICO        PGM,
                               TB_REP_IMPORTACAO_CLI_TEMP     ICT
                         WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID 
                           AND REP.CAD_REP_ID = RPG.CAD_REP_ID  
                           AND CPR.CAD_CLC_ID = CLC.CAD_CLC_ID 
                           AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID 
                           --AND CLC.CAD_CLC_ID IN ( SELECT * FROM TABLE(FNC_SPLIT( PCAD_CLC_ID )))
                           AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                           AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIA')
                           AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL 
                           --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL 
                           --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                           AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA) 
                           AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                           AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                           AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                           AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL  
                           AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT  NULL    
                           AND CPR.CAD_PRD_ID IS NOT NULL 
                           AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL   
                           AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                           AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                           AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                           AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                           AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                           AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                           AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                           AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                           AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                           AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                           AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                           AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
                           AND PGM.REP_PGM_FL_PAGO = 'P'
                          ) LOOP 
    BEGIN 
      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO_ATUALIZ,
             PGM.REP_PGM_VL_PAGO               = TEMP.CAD_REP_VL_PAGTO * PGM.REP_PGM_QT_CONSUMO
       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
         AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
         AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
         AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
         AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
         AND PGM.AUX_GPC_CD_GRUPOPROC = TEMP.AUX_GPC_CD_GRUPOPROC
         AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
         AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
         AND PGM.REP_PGM_FL_PAGO = 'P'
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
    END;
  END LOOP;
 COMMIT;
END;
END PRC_REP_CAL_FIXOATENDIMENTO;