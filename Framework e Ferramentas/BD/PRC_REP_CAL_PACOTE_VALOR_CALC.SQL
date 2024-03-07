CREATE OR REPLACE PROCEDURE "PRC_REP_CAL_PACOTE_VALOR_CALC"
 (PREP_PGM_MES_PAGTO                    IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
  PREP_PGM_ANO_PAGTO                    IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE,
  PSEG_USU_ID_USUARIO                   IN TB_REP_PPC_PAG_PROF_CLI.SEG_USU_ID_USUARIO%TYPE
) IS
  /********************************************************************
  *    PROCEDURE: PRC_REP_CAL_PACOTE_VALOR_CALC
  *
  *    DATA CRIACAO:    06/02/2013         POR: FABIOLA
  *    DATA ALTERACAO:  DATA DA ALTERA??O  POR: NOME DO ANALISTA
  *
  *    FUNCAO:
  *
  *******************************************************************/

BEGIN
 BEGIN
  FOR TEMP IN (SELECT PGM.REP_PGM_ID,
                      CLC.CAD_CLC_CD_CLINICA,
                      PRD.CAD_PRD_CD_CODIGO,
                      PRD.CAD_PRD_DS_DESCRICAO,
                      PGM.CAD_PRO_ID_PROFISSIONAL,
                      REP.CAD_REP_VL_PAGTO,
                      REP.CAD_REP_PC_REPASSE,
                      RPG.ASS_RPG_ID,
                      PRD.CAD_PRD_ID,
                      PGM.CAD_TPE_CD_CODIGO,
                      PGM.CAD_CLC_ID

                 FROM TB_REP_PGM_PAGTO_MEDICO        PGM,
                      TB_CAD_PRD_PRODUTO             PRD,
                      TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                      TB_ASS_CPR_CLINICA_PROF        CPR,
                      TB_ASS_RPG_REGRA_PAGTO         RPG,
                      TB_CAD_REP_REGRA_PAGAMENTO     REP

                WHERE PGM.CAD_PRD_ID = PRD.CAD_PRD_ID
                  AND PRD.TIS_MED_CD_TABELAMEDICA = 'IP'
                  AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
                  AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO
                  AND CLC.CAD_CLC_ID = PGM.CAD_CLC_ID
                  AND CPR.CAD_CLC_ID = PGM.CAD_CLC_ID
                  AND CPR.CAD_PRO_ID_PROFISSIONAL = PGM.CAD_PRO_ID_PROFISSIONAL
                  AND CPR.CAD_PRD_CD_ITEM_PACOTE = TRIM(PRD.CAD_PRD_CD_CODIGO)
                  AND CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                  AND RPG.CAD_REP_ID = REP.CAD_REP_ID
                  AND REP.CAD_REP_PC_REPASSE > 0

                  /* alterado aqui */
                  -- AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN CPR.ASS_CPR_DT_INICIO_VIGENCIA AND DECODE(CPR.ASS_CPR_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), CPR.ASS_CPR_DT_FIM_VIGENCIA)                            
                  AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN RPG.CAD_REP_DT_INICIO_VIGENCIA AND DECODE(RPG.CAD_REP_DT_FIM_VIGENCIA, NULL, TRUNC(SYSDATE), RPG.CAD_REP_DT_FIM_VIGENCIA)
                  /* fim */

                  AND CPR.CAD_TPE_CD_CODIGO = PGM.CAD_TPE_CD_CODIGO) LOOP

    BEGIN

      UPDATE TB_REP_PGM_PAGTO_MEDICO PGM

         SET PGM.ASS_RPG_ID                    = TEMP.ASS_RPG_ID,
             PGM.REP_PGM_VL_PAGO               = (PGM.REP_PGM_VL_CALCULADO * TEMP.CAD_REP_PC_REPASSE) / 100,
             PGM.SEG_USU_ID_USUARIO_ATUALIZ    = PSEG_USU_ID_USUARIO,
             PGM.REP_PGM_DT_ULTIMA_ATUALIZACAO = SYSDATE

       WHERE PGM.CAD_CLC_ID = TEMP.CAD_CLC_ID
         AND PGM.REP_PGM_FL_PACOTE = 'S'
         AND NVL(PGM.REP_PGM_VL_PAGO, 0) = 0
         AND PGM.REP_PGM_ID = TEMP.REP_PGM_ID
         AND PGM.REP_PGM_FL_PAGO = 'P';
    END;
  END LOOP;
  COMMIT;
END;

END PRC_REP_CAL_PACOTE_VALOR_CALC;
