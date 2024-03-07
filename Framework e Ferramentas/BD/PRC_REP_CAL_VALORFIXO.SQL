CREATE OR REPLACE PROCEDURE SGS."PRC_REP_CAL_VALORFIXO"
 (PREP_PGM_MES_FECHAMENTO               IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_FECHAMENTO%TYPE,
  PREP_PGM_ANO_FECHAMENTO               IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_FECHAMENTO%TYPE,
  PREP_PGM_MES_PAGTO                    IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
  PREP_PGM_ANO_PAGTO                    IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE,
  PSEG_USU_ID_USUARIO                   IN TB_REP_PPC_PAG_PROF_CLI.SEG_USU_ID_USUARIO%TYPE,
  --PCAD_CLC_ID                           IN STRING,
  PCAD_UNI_ID_UNIDADE                   IN STRING,
  PCAD_LAT_ID_LOCAL_ATENDIMENTO         IN STRING,
  PREP_PPC_FL_ANTECIPACAO        IN TB_REP_PPC_PAG_PROF_CLI.REP_PPC_FL_ANTECIPACAO%TYPE
) IS
  /********************************************************************
  *    PROCEDURE: PRC_REP_CAL_VALORFIXO
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
               -- ACS
               SELECT DISTINCT REP.CAD_REP_ID,
                               CPR.CAD_CLC_ID,
                               CLC.CAD_CLC_CD_CLINICA,
                               CLC.CAD_CLC_DS_DESCRICAO,
                               CPR.CAD_UNI_ID_UNIDADE           UNID,
                               CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO LOCALATEN,
                               RPG.ASS_RPG_PC_HAC               PCHAC,
                               RPG.ASS_RPG_PC_ACS               PCACS,
                               REP.CAD_REP_VL_PAGTO_FIXO        PAGOACS,                              
                               0                                PAGOHAC,
                               'MC' CREDENCIAMENTO,
                               'ACS' FONTEPAGADORA
                          FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                               TB_CAD_REP_REGRA_PAGAMENTO     REP,
                               TB_ASS_RPG_REGRA_PAGTO         RPG,
                               TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                               TB_REP_IMPORTACAO_CLI_TEMP     ICT
                         WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                           AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                           AND CPR.CAD_CLC_ID = CLC.CAD_CLC_ID
                           AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                           AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIX')
                           AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL 
                           AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL 
                           AND NVL(REP.CAD_REP_VL_PAGTO_FIXO, 0) >= 0
                           -- ACS > 0
                           AND NVL(RPG.ASS_RPG_PC_ACS, 0) > 0
                           AND NVL(RPG.ASS_RPG_PC_HAC, 0) = 0
                           --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                           AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                           AND (PCAD_UNI_ID_UNIDADE IS NULL OR CPR.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_UNI_ID_UNIDADE))))
                           AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_LAT_ID_LOCAL_ATENDIMENTO))))
                           AND NOT EXISTS (SELECT * FROM TB_REP_PPC_PAG_PROF_CLI PPC 
                           WHERE PPC.CAD_CLC_ID=CPR.CAD_CLC_ID 
                           AND  PPC.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                           AND PPC.CAD_LAT_ID_LOCAL = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                           AND PPC.CAD_REP_TP_BASE_CALCULO = 'VLFIX'
                           AND PPC.REP_PPC_FONTE_PAGADORA = 'ACS' 
                           AND PPC.REP_PPC_VL_PAGO_ACS = REP.CAD_REP_VL_PAGTO_FIXO 
                           AND PPC.REP_PPC_MES_PAGTO =  PREP_PGM_MES_PAGTO
                           AND PPC.REP_PPC_ANO_PAGTO =  PREP_PGM_ANO_PAGTO)
UNION ALL
               -- HAC
               SELECT DISTINCT REP.CAD_REP_ID,
                               CPR.CAD_CLC_ID,
                               CLC.CAD_CLC_CD_CLINICA,
                               CLC.CAD_CLC_DS_DESCRICAO,
                               CPR.CAD_UNI_ID_UNIDADE           UNID,
                               CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO LOCALATEN,
                               RPG.ASS_RPG_PC_HAC               PCHAC,
                               RPG.ASS_RPG_PC_ACS               PCACS,
                               0                                PAGOACS,
                               REP.CAD_REP_VL_PAGTO_FIXO        PAGOHAC,                             
                               'MF' CREDENCIAMENTO,
                               'HAC' FONTEPAGADORA
                          FROM TB_ASS_CPR_CLINICA_PROF        CPR,
                               TB_CAD_REP_REGRA_PAGAMENTO     REP,
                               TB_ASS_RPG_REGRA_PAGTO         RPG,
                               TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                               TB_REP_IMPORTACAO_CLI_TEMP     ICT
                         WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                           AND REP.CAD_REP_ID = RPG.CAD_REP_ID
                           AND CPR.CAD_CLC_ID = CLC.CAD_CLC_ID
                           AND CLC.CAD_CLC_ID = CPR.CAD_CLC_ID
                           AND REP.CAD_REP_TP_BASE_CALCULO IN ('VLFIX')
                           AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                           AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL 
                           AND NVL(REP.CAD_REP_VL_PAGTO_FIXO, 0) >= 0
                           -- HAC > 0
                           AND NVL(RPG.ASS_RPG_PC_ACS, 0) = 0
                           AND NVL(RPG.ASS_RPG_PC_HAC, 0) > 0                           
                           --AND CLC.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_CLC_ID)))
                           AND CLC.CAD_CLC_ID = ICT.CAD_CLC_ID
                           AND (PCAD_UNI_ID_UNIDADE IS NULL OR CPR.CAD_UNI_ID_UNIDADE IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_UNI_ID_UNIDADE))))
                           AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT * FROM TABLE(FNC_SPLIT(PCAD_LAT_ID_LOCAL_ATENDIMENTO))))
                           AND NOT EXISTS (SELECT * FROM TB_REP_PPC_PAG_PROF_CLI PPC 
                           WHERE PPC.CAD_CLC_ID=CPR.CAD_CLC_ID 
                           AND  PPC.CAD_UNI_ID_UNIDADE = CPR.CAD_UNI_ID_UNIDADE
                           AND PPC.CAD_LAT_ID_LOCAL = CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                           AND PPC.CAD_REP_TP_BASE_CALCULO = 'VLFIX'
                           AND PPC.REP_PPC_FONTE_PAGADORA = 'HAC' 
                           AND PPC.REP_PPC_VL_PAGO_HAC = REP.CAD_REP_VL_PAGTO_FIXO 
                           AND PPC.REP_PPC_MES_PAGTO =  PREP_PGM_MES_PAGTO
                           AND PPC.REP_PPC_ANO_PAGTO =  PREP_PGM_ANO_PAGTO)
                           )
                            LOOP
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
         NULL,
         TEMP.PAGOHAC,
         TEMP.PAGOACS,
         PREP_PGM_MES_FECHAMENTO,
         PREP_PGM_ANO_FECHAMENTO,
         PREP_PGM_MES_PAGTO,
         PREP_PGM_ANO_PAGTO,
         PSEG_USU_ID_USUARIO,
         SYSDATE,
         'P',
         'VLFIX',
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
END PRC_REP_CAL_VALORFIXO;