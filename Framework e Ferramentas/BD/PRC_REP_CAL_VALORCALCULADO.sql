CREATE OR REPLACE PROCEDURE SGS."PRC_REP_CAL_VALORCALCULADO"(PREP_PGM_MES_PAGTO  IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
                                                             PREP_PGM_ANO_PAGTO  IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE,
                                                             PSEG_USU_ID_USUARIO IN TB_REP_PPC_PAG_PROF_CLI.SEG_USU_ID_USUARIO%TYPE--,
                                                             --PCAD_CLC_ID         IN STRING
                                                             ) IS
  /********************************************************************
  *    PROCEDURE: PRC_REP_CAL_VALORCALCULADO
  *
  *    DATA CRIACAO:   01/05/2012   POR:
  *    DATA ALTERACAO:  DATA DA ALTERAC?O  POR: NOME DO ANALISTA
  *
  *    FUNCAO: IMPORTAR PRODUTIVIDADE PASSANDO CLINICA UNIDADE E LOCAL [P3]
  *
  *******************************************************************/
  --LIDTRETORNO NUMBER;
BEGIN
  ---ACOMODACAO
  BEGIN
    FOR TEMP IN (SELECT DISTINCT PGM.REP_PGM_ID,
                                 PGM.ATD_ATE_ID,
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
                                 CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
                                 REP.TIS_TAC_CD_TIPO_ACOMOD_AUT,
                                 PGM.FAT_CCI_PC_ACOMODACAO_HM,
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
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                    AND CPR.CAD_PRD_ID IS NOT NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    AND CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND CPR.CAD_PRD_ID = PGM.CAD_PRD_ID
                    AND CPR.CAD_PRO_ID_PROFISSIONAL = PGM.CAD_PRO_ID_PROFISSIONAL
                    AND CPR.CAD_UNI_ID_UNIDADE = PGM.CAD_UNI_ID_UNIDADE
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO
                    AND CPR.CAD_TPE_CD_CODIGO = PGM.CAD_TPE_CD_CODIGO
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
                    AND PGM.REP_PGM_FL_PAGO = 'P'
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                    AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                    AND REP.TIS_TAC_CD_TIPO_ACOMOD_AUT = 1
                    AND NVL(PGM.FAT_CCI_PC_ACOMODACAO_HM, 0) = 0
                 UNION ALL
                 SELECT DISTINCT PGM.REP_PGM_ID,
                                 PGM.ATD_ATE_ID,
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
                                CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
                                 REP.TIS_TAC_CD_TIPO_ACOMOD_AUT,
                                 PGM.FAT_CCI_PC_ACOMODACAO_HM,
                                 CPR.SEG_USU_ID_USUARIO_CRIACAO
                   FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                        TB_CAD_REP_REGRA_PAGAMENTO     REP,
                        TB_ASS_RPG_REGRA_PAGTO         RPG,
                        TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                        TB_CAD_PRO_PROFISSIONAL        PRO,
                        TB_CAD_UNI_UNIDADE             UNI,
                        TB_REP_PGM_PAGTO_MEDICO        PGM,
                        TB_REP_IMPORTACAO_CLI_TEMP     ICT
                  WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                    AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                    AND CPR.CAD_CLC_ID = CLC.CAD_CLC_ID
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND UNI.CAD_UNI_ID_UNIDADE(+) = CPR.CAD_UNI_ID_UNIDADE
                    AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                    AND CPR.CAD_PRD_ID IS NOT NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    AND CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND CPR.CAD_PRD_ID = PGM.CAD_PRD_ID
                    AND CPR.CAD_PRO_ID_PROFISSIONAL = PGM.CAD_PRO_ID_PROFISSIONAL
                    AND CPR.CAD_UNI_ID_UNIDADE = PGM.CAD_UNI_ID_UNIDADE
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO
                    AND CPR.CAD_TPE_CD_CODIGO = PGM.CAD_TPE_CD_CODIGO
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
                    AND PGM.REP_PGM_FL_PAGO = 'P'
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                    AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                    AND REP.TIS_TAC_CD_TIPO_ACOMOD_AUT > 1
                    AND NVL(PGM.FAT_CCI_PC_ACOMODACAO_HM, 0) > 0) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
           AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
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
  --------------    1 PROD SETOR
  BEGIN
    --  GOTO SAIR1;
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
                                CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
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
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                    AND CPR.CAD_PRD_ID IS NOT NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                    AND CPR.CAD_SET_ID IS NOT NULL
                    AND CPR.CAD_PRD_ID = PGM.CAD_PRD_ID
                    AND CPR.CAD_PRO_ID_PROFISSIONAL =  PGM.CAD_PRO_ID_PROFISSIONAL
                    AND CPR.CAD_UNI_ID_UNIDADE = PGM.CAD_UNI_ID_UNIDADE
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO
                    AND CPR.CAD_TPE_CD_CODIGO = PGM.CAD_TPE_CD_CODIGO
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
                    AND PGM.REP_PGM_FL_PAGO = 'P'
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                    AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                    AND PGM.CAD_SET_ID_MOVIMENTACAO = CPR.CAD_SET_ID
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
           AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
           AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
           AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
           AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
           AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
           AND PGM.AUX_GPC_CD_GRUPOPROC = TEMP.AUX_GPC_CD_GRUPOPROC
           AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
           AND PGM.CAD_SET_ID_MOVIMENTACAO = TEMP.CAD_SET_ID
           AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
           AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
           AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
           AND PGM.REP_PGM_FL_PAGO = 'P'
           AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
      END;
    END LOOP;
    COMMIT;
  END;
  ----------------1 PRO
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
                                 CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
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
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                    AND CPR.CAD_PRD_ID IS NOT NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                    AND CPR.CAD_PRD_ID = PGM.CAD_PRD_ID
                    AND CPR.CAD_PRO_ID_PROFISSIONAL = PGM.CAD_PRO_ID_PROFISSIONAL
                    AND CPR.CAD_UNI_ID_UNIDADE = PGM.CAD_UNI_ID_UNIDADE
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO
                    AND CPR.CAD_TPE_CD_CODIGO = PGM.CAD_TPE_CD_CODIGO
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
                    AND PGM.REP_PGM_FL_PAGO = 'P'
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                    AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
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
  ----------- 1A NOVO local novo
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
                                CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
                                 CPR.SEG_USU_ID_USUARIO_CRIACAO
                   FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                        TB_CAD_REP_REGRA_PAGAMENTO     REP,
                        TB_ASS_RPG_REGRA_PAGTO         RPG,
                        TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                        TB_CAD_PRO_PROFISSIONAL        PRO,
                        TB_CAD_UNI_UNIDADE             UNI,
                        TB_REP_PGM_PAGTO_MEDICO        PGM,
                        TB_REP_IMPORTACAO_CLI_TEMP     ICT
                  WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                    AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                    AND CPR.CAD_CLC_ID = CLC.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND UNI.CAD_UNI_ID_UNIDADE(+) = CPR.CAD_UNI_ID_UNIDADE
                    AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                    AND CPR.CAD_PRD_ID IS NOT NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    /* ------------------------------------------------------- */
                    AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                    AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                    AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
           AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
           AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
           AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
           AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
           AND PGM.AUX_GPC_CD_GRUPOPROC = TEMP.AUX_GPC_CD_GRUPOPROC
           AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO -- N?O PRECISA ESTAR NO WHERE DO SELECT?
           AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
           AND PGM.REP_PGM_FL_PAGO = 'P' -- N?O PRECISA ESTAR NO WHERE DO SELECT?
           AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
           AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
           AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
      END;
    END LOOP;
    COMMIT;
  END;
  ----------- 1A NOVO UNIDADE NULO LOCAL NOT NULL
  -- <<SAIR1>>
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
                                CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
                                 CPR.SEG_USU_ID_USUARIO_CRIACAO
                   FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                        TB_CAD_REP_REGRA_PAGAMENTO     REP,
                        TB_ASS_RPG_REGRA_PAGTO         RPG,
                        TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                        TB_CAD_PRO_PROFISSIONAL        PRO,
                        TB_CAD_UNI_UNIDADE             UNI,
                        TB_REP_PGM_PAGTO_MEDICO        PGM,
                        TB_REP_IMPORTACAO_CLI_TEMP     ICT
                  WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                    AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                    AND CPR.CAD_CLC_ID = CLC.CAD_CLC_ID
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND UNI.CAD_UNI_ID_UNIDADE(+) = CPR.CAD_UNI_ID_UNIDADE
                    AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                    AND CPR.CAD_PRD_ID IS NOT NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                       /* ------------------------------------------------------- */
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                    AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                    AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                    AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                    AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                 ) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
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
  --GOTO SAIR;
  ----1C NOVO
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
                                CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
                                 CPR.SEG_USU_ID_USUARIO_CRIACAO
                   FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                        TB_CAD_REP_REGRA_PAGAMENTO     REP,
                        TB_ASS_RPG_REGRA_PAGTO         RPG,
                        TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                        TB_CAD_PRO_PROFISSIONAL        PRO,
                        TB_CAD_UNI_UNIDADE             UNI,
                        TB_REP_PGM_PAGTO_MEDICO        PGM,
                        TB_REP_IMPORTACAO_CLI_TEMP     ICT
                  WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                    AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                    AND CPR.CAD_CLC_ID = CLC.CAD_CLC_ID
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND UNI.CAD_UNI_ID_UNIDADE(+) = CPR.CAD_UNI_ID_UNIDADE
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                    AND CPR.CAD_PRD_ID IS NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                     AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    ) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
           AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
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
  ----------------------------------2 SETOR
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
                                 CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
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
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                    AND CPR.CAD_PRD_ID IS NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                    AND CPR.CAD_SET_ID IS NOT NULL
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                    AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                    AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                    AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                    AND PGM.CAD_SET_ID_MOVIMENTACAO = CPR.CAD_SET_ID
                    AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
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
           AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID
           AND PGM.CAD_SET_ID_MOVIMENTACAO = TEMP.CAD_SET_ID
           AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
      END;
    END LOOP;
    COMMIT;
  END;
  ---------------------------------------2
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
                                CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
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
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                    AND CPR.CAD_PRD_ID IS NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                    AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                    AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                    AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                    AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
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
  ----------------------------------------3 GRUPO SETOR
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
                                CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
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
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NULL
                    AND CPR.CAD_PRD_ID IS NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                    AND CPR.CAD_SET_ID IS NOT NULL
                    AND CPR.CAD_CLC_ID = PGM.CAD_CLC_ID
                    AND CPR.CAD_PRO_ID_PROFISSIONAL = PGM.CAD_PRO_ID_PROFISSIONAL
                    AND CPR.CAD_UNI_ID_UNIDADE = PGM.CAD_UNI_ID_UNIDADE
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO
                    AND CPR.TIS_MED_CD_TABELAMEDICA = PGM.TIS_MED_CD_TABELAMEDICA
                    AND CPR.AUX_EPP_CD_ESPECPROC = PGM.AUX_EPP_CD_ESPECPROC
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                    AND CPR.CAD_TPE_CD_CODIGO = PGM.CAD_TPE_CD_CODIGO) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
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
           AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID
           AND PGM.CAD_SET_ID_MOVIMENTACAO = TEMP.CAD_SET_ID;
      END;
    END LOOP;
    COMMIT;
  END;
  ----------------------------------------3 GRUPO
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
                                 CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
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
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NULL
                    AND CPR.CAD_PRD_ID IS NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                    AND CPR.CAD_CLC_ID = PGM.CAD_CLC_ID
                    AND CPR.CAD_PRO_ID_PROFISSIONAL = PGM.CAD_PRO_ID_PROFISSIONAL
                    AND CPR.CAD_UNI_ID_UNIDADE = PGM.CAD_UNI_ID_UNIDADE
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO
                    AND CPR.TIS_MED_CD_TABELAMEDICA = PGM.TIS_MED_CD_TABELAMEDICA
                    AND CPR.AUX_EPP_CD_ESPECPROC = PGM.AUX_EPP_CD_ESPECPROC
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                    AND CPR.CAD_TPE_CD_CODIGO = PGM.CAD_TPE_CD_CODIGO) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
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
                                 CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
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
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                    AND CPR.CAD_PRD_ID IS NOT NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                    /* ------------------------------------------------------- */
                    AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                    AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                    AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                    AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
           AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
           AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
           AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
           AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
           AND PGM.AUX_GPC_CD_GRUPOPROC = TEMP.AUX_GPC_CD_GRUPOPROC
           AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
           AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
           AND PGM.REP_PGM_FL_PAGO = 'P' -- N?O PRECISA ESTAR NO WHERE DO SELECT?
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
                                CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
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
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                    AND CPR.CAD_PRD_ID IS NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                    /* ------------------------------------------------------- */
                    AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                    AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                    AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                    AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
           AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
           AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
           AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
           AND PGM.AUX_GPC_CD_GRUPOPROC = TEMP.AUX_GPC_CD_GRUPOPROC
           AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
           AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
           AND PGM.REP_PGM_FL_PAGO = 'P' -- N?O PRECISA ESTAR NO WHERE DO SELECT?
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
                                 CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
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
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NULL
                    AND CPR.CAD_PRD_ID IS NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                    /* ------------------------------------------------------- */
                    AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                    AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                    AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
           AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
           AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
           AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
           AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
           AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
           AND PGM.REP_PGM_FL_PAGO = 'P' -- N?O PRECISA ESTAR NO WHERE DO SELECT?
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
                                CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
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
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                    AND CPR.CAD_PRD_ID IS NOT NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                    /* ------------------------------------------------------- */
                    AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                    AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                    AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
           AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
           AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
           AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
           AND PGM.AUX_GPC_CD_GRUPOPROC = TEMP.AUX_GPC_CD_GRUPOPROC
           AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
           AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
           AND PGM.REP_PGM_FL_PAGO = 'P' -- N?O PRECISA ESTAR NO WHERE DO SELECT?
           AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
           AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
           AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
      END;
    END LOOP;
    COMMIT;
  END;
  -------------------------------------------8A
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
                                CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
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
--                    AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                    AND CPR.CAD_PRD_ID IS NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                    /* ------------------------------------------------------- */
                    AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                    AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                    AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                    AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
           AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
           AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
           AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
           AND PGM.AUX_GPC_CD_GRUPOPROC = TEMP.AUX_GPC_CD_GRUPOPROC
           AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
           AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
           AND PGM.REP_PGM_FL_PAGO = 'P' -- N?O PRECISA ESTAR NO WHERE DO SELECT?
           AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
           AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
           AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
      END;
    END LOOP;
    COMMIT;
  END;
  -------------------8B UNIDADE TABELA GRUPO EMPRE LOCAL NULO
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
                                CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
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
--                    AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NULL
                    AND CPR.CAD_PRD_ID IS NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                       /* ------------------------------------------------------- */
                    AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                    AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                    AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
           AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
           AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
           AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
           AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
           AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
           AND PGM.REP_PGM_FL_PAGO = 'P' -- N?O PRECISA ESTAR NO WHERE DO SELECT?
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
                                CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
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
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                    AND CPR.CAD_PRD_ID IS NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                    /* ------------------------------------------------------- */
                    AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                    AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                    AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
           AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
           AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
           AND PGM.AUX_GPC_CD_GRUPOPROC = TEMP.AUX_GPC_CD_GRUPOPROC
           AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
           AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
           AND PGM.REP_PGM_FL_PAGO = 'P'  -- N?O PRECISA ESTAR NO WHERE DO SELECT?
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
                                CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
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
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    AND CPR.CAD_UNI_ID_UNIDADE IS NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NULL
                    AND CPR.CAD_PRD_ID IS NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                    /* ------------------------------------------------------- */
                    AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                    AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
           AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
           AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
           AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
           AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
           AND PGM.REP_PGM_FL_PAGO = 'P' -- N?O PRECISA ESTAR NO WHERE DO SELECT?
           AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
           AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
           AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
      END;
    END LOOP;
    COMMIT;
  END;
  -- UNIDADE LOCAL TIPO EMPRESA TABELA NAO NULO GRUPO SUBGRUPO NULO
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
                                CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
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
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NULL
                    AND CPR.CAD_PRD_ID IS NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND CPR.CAD_TPE_CD_CODIGO IS NOT NULL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    /* ------------------------------------------------------- */
                    AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                    AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                    AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.CAD_TPE_CD_CODIGO = CPR.CAD_TPE_CD_CODIGO
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
           AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
           AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
           AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
           AND PGM.CAD_TPE_CD_CODIGO = TEMP.CAD_TPE_CD_CODIGO
           AND PGM.ASS_RPG_ID IS NULL -- PRECISA ESTAR NO WHERE DO SELECT?
           AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
           AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
           AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
           AND PGM.REP_PGM_FL_PAGO = 'P' -- PRECISA ESTAR NO WHERE DO SELECT?
           AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
      END;
    END LOOP;
    COMMIT;
  END;
  -------------------------- EMPRESA NULA PROCEDIMENTO (NOVO)
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
                                 CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
                                 RPG.ASS_RPG_PC_HAC,
                                 RPG.ASS_RPG_PC_ACS,
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
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                    AND CPR.CAD_PRD_ID IS NOT NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NULL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND NVL(RPG.ASS_RPG_PC_HAC, 0) > 0
                    AND NVL(RPG.ASS_RPG_PC_ACS, 0) = 0
                    /* ------------------------------------------------------- */
                    AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                    AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                    AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                    AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
           AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
           AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
           AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
           AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
           AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
           AND PGM.AUX_GPC_CD_GRUPOPROC = TEMP.AUX_GPC_CD_GRUPOPROC
           AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
           AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
           AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
           AND PGM.REP_PGM_FL_PAGO = 'P' -- NAO PRECISA ESTAR NO WHERE DO SELECT?
           AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
      END;
    END LOOP;
    COMMIT;
  END;
  --------------
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
                                 CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
                                 RPG.ASS_RPG_PC_HAC,
                                 RPG.ASS_RPG_PC_ACS,
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
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                    AND CPR.CAD_PRD_ID IS NOT NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NULL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND NVL(RPG.ASS_RPG_PC_HAC, 0) = 0
                    AND NVL(RPG.ASS_RPG_PC_ACS, 0) > 0
                    /* ------------------------------------------------------- */
                    AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                    AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                    AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND PGM.CAD_PRD_ID = CPR.CAD_PRD_ID
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                    AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
           AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
           AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
           AND PGM.CAD_PRD_ID = TEMP.CAD_PRD_ID
           AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
           AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
           AND PGM.AUX_GPC_CD_GRUPOPROC = TEMP.AUX_GPC_CD_GRUPOPROC
           AND PGM.ASS_RPG_ID IS NULL -- NAO PRECISA ESTAR NO WHERE DO SELECT?
           AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
           AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
           AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
           AND PGM.REP_PGM_FL_PAGO = 'P'  -- NAO PRECISA ESTAR NO WHERE DO SELECT?
           AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
      END;
    END LOOP;
    COMMIT;
  END;
  ---empresa nula procedimento NULO novo
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
                                CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
                                 RPG.ASS_RPG_PC_HAC,
                                 RPG.ASS_RPG_PC_ACS,
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
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                    AND CPR.CAD_PRD_ID IS NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NULL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND NVL(RPG.ASS_RPG_PC_HAC, 0) > 0
                    AND NVL(RPG.ASS_RPG_PC_ACS, 0) = 0
                    /* ------------------------------------------------------- */
                    AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                    AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                    AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                    AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0 -- N?O PRECISA ESTAR NO WHERE?
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
           AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
           AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
           AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
           AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
           AND PGM.AUX_GPC_CD_GRUPOPROC = TEMP.AUX_GPC_CD_GRUPOPROC
           AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
           AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
           AND PGM.REP_PGM_FL_PAGO = 'P' -- N?O PRECISA ESTAR NO WHERE DO SELECT?
           AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
      END;
    END LOOP;
    COMMIT;
  END;
  --------------------
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
                                CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
                                 RPG.ASS_RPG_PC_HAC,
                                 RPG.ASS_RPG_PC_ACS,
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
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NOT NULL
                    AND CPR.CAD_PRD_ID IS NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NULL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND NVL(RPG.ASS_RPG_PC_HAC, 0) = 0
                    AND NVL(RPG.ASS_RPG_PC_ACS, 0) > 0
                    /* ------------------------------------------------------- */
                    AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                    AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                    AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                    AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
           AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
           AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
           AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
           AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
           AND PGM.AUX_GPC_CD_GRUPOPROC = TEMP.AUX_GPC_CD_GRUPOPROC
           AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
           AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
           AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
           AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
      END;
    END LOOP;
    COMMIT;
  END;
  ---empresa nula grupo nulo
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
                                 CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
                                 RPG.ASS_RPG_PC_HAC,
                                 RPG.ASS_RPG_PC_ACS,
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
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NULL
                    AND CPR.CAD_PRD_ID IS NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NULL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND NVL(RPG.ASS_RPG_PC_HAC, 0) > 0
                    AND NVL(RPG.ASS_RPG_PC_ACS, 0) = 0
                    /* ------------------------------------------------------- */
                    AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                    AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                    AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                    AND PGM.AUX_GPC_CD_GRUPOPROC = CPR.AUX_GPC_CD_GRUPOPROC -- N?O PRECISA POIS N?O ESTA NO UPDATE? OU RETIRAR O WHERE DO SELECT
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0 --PRECISA ESTAR NO UPDATE?
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
           AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
           AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
           AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
           AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
           AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
           AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
           AND PGM.REP_PGM_FL_PAGO = 'P'
           AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
      END;
    END LOOP;
    COMMIT;
  END;
  --------------------
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
                                CASE WHEN  PGM.CAD_UNI_ID_UNIDADE = 244 AND PGM.REP_PGM_FONTE_PAGADORA = 'HAC'
                                   AND PGM.ATD_ATE_FL_CARATER_SOLIC = 'E' AND REP.Cad_Rep_Pc_Repasse = 90.00
                                   AND PGM.CAD_SET_ID_MOVIMENTACAO = 61
                                   THEN 100.00  ELSE REP.CAD_REP_PC_REPASSE
                                   END  CAD_REP_PC_REPASSE,
                                 RPG.ASS_RPG_PC_HAC,
                                 RPG.ASS_RPG_PC_ACS,
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
                    AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLCAL')
                    AND PRO.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND CPR.CAD_UNI_ID_UNIDADE IS NOT NULL
                    AND NVL(REP.CAD_REP_PC_REPASSE, 0) > 0
                    AND CPR.TIS_MED_CD_TABELAMEDICA IS NOT NULL
                    AND CPR.AUX_EPP_CD_ESPECPROC IS NOT NULL
                    AND CPR.AUX_GPC_CD_GRUPOPROC IS NULL
                    AND CPR.CAD_PRD_ID IS NULL
                    AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL
                    AND CPR.CAD_TPE_CD_CODIGO IS NULL
                    --AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    --AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND
                        DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)
                    AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND
                        DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                    --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                    AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                    AND NVL(RPG.ASS_RPG_PC_HAC, 0) = 0
                    AND NVL(RPG.ASS_RPG_PC_ACS, 0) > 0
                    /* ------------------------------------------------------- */
                    AND PGM.CAD_CLC_ID = CPR.CAD_CLC_ID
                    AND PGM.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                    AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                    AND PGM.CAD_PRO_ID_PROFISSIONAL = CPR.CAD_PRO_ID_PROFISSIONAL
                    AND PGM.TIS_MED_CD_TABELAMEDICA = CPR.TIS_MED_CD_TABELAMEDICA
                    AND PGM.AUX_EPP_CD_ESPECPROC = CPR.AUX_EPP_CD_ESPECPROC
                    AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
                    AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                    AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO) LOOP
      BEGIN
        UPDATE TB_REP_PGM_PAGTO_MEDICO PGM
           SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
               PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
               PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
               PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO
         WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
           AND PGM.CAD_UNI_ID_UNIDADE = TEMP.CAD_UNI_ID_UNIDADE
           AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = TEMP.CAD_LAT_ID_LOCAL_ATENDIMENTO
           AND PGM.CAD_PRO_ID_PROFISSIONAL = TEMP.CAD_PRO_ID_PROFISSIONAL
           AND PGM.TIS_MED_CD_TABELAMEDICA = TEMP.TIS_MED_CD_TABELAMEDICA
           AND PGM.AUX_EPP_CD_ESPECPROC = TEMP.AUX_EPP_CD_ESPECPROC
           AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
           AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
           AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
           AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID;
      END;
    END LOOP;
    COMMIT;
  END;
  --<<SAIR>>
  --NULL;
END PRC_REP_CAL_VALORCALCULADO;