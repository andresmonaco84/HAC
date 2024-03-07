CREATE OR REPLACE PROCEDURE PRC_REP_ASS_RPG_MUDAR_REGRA_1(pCAD_REP_ID                 IN TB_ASS_RPG_REGRA_PAGTO.CAD_REP_ID%TYPE DEFAULT NULL,
                                                        pCAD_REP_DT_INICIO_VIGENCIA IN TB_ASS_RPG_REGRA_PAGTO.CAD_REP_DT_INICIO_VIGENCIA%TYPE DEFAULT NULL,
                                                        pSEG_USU_ID_USUARIO         IN TB_ASS_RPG_REGRA_PAGTO.SEG_USU_ID_USUARIO%TYPE DEFAULT NULL,
                                                        pCAD_CLC_ID                 IN STRING,
                                                        pCAD_REP_ID_FILTRO          IN TB_ASS_RPG_REGRA_PAGTO.CAD_REP_ID%TYPE DEFAULT NULL) IS
  /********************************************************************
  *    PROCEDURE: PRC_REP_ASS_RPG_MUDAR_REGRA_1
  *
  *    DATA CRIACAO:    25/07/2013   POR:
  *    DATA ALTERACAO:  DATA DA ALTERAC?O  POR: NOME DO ANALISTA
  *
  *    FUNCAO:
  *
  *******************************************************************/
BEGIN
  BEGIN
    FOR TEMP IN (SELECT RPG.ASS_CPR_ID,
                        RPG.CAD_REP_ID,
                        RPG.CAD_REP_DT_INICIO_VIGENCIA,
                        RPG.CAD_REP_DT_FIM_VIGENCIA,
                        RPG.SEG_USU_ID_USUARIO,
                        RPG.CAD_REP_DT_ULTIMA_ATUALIZACAO,
                        RPG.ASS_RPG_ID,
                        RPG.ASS_RPG_PC_HAC,
                        RPG.ASS_RPG_PC_ACS
                   FROM TB_ASS_RPG_REGRA_PAGTO  RPG,
                        TB_ASS_CPR_CLINICA_PROF CPR
                  WHERE CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                    AND RPG.CAD_REP_ID = pCAD_REP_ID_FILTRO
                    AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                    AND CPR.CAD_CLC_ID IN (SELECT * FROM TABLE(FNC_SPLIT(pCAD_CLC_ID)))) LOOP
      BEGIN

        INSERT INTO TB_ASS_RPG_REGRA_PAGTO
          (ASS_RPG_ID,
           CAD_REP_ID,
           CAD_REP_DT_INICIO_VIGENCIA,
           CAD_REP_DT_FIM_VIGENCIA,
           SEG_USU_ID_USUARIO,
           CAD_REP_DT_ULTIMA_ATUALIZACAO,
           ASS_CPR_ID,
           ASS_RPG_PC_HAC,
           ASS_RPG_PC_ACS)
        VALUES
          (SEQ_ASS_RPG_01.NEXTVAL,
           pCAD_REP_ID,
           pCAD_REP_DT_INICIO_VIGENCIA,
           NULL,
           pSEG_USU_ID_USUARIO,
           SYSDATE,
           TEMP.ASS_CPR_ID,
           TEMP.ASS_RPG_PC_HAC,
           TEMP.ASS_RPG_PC_ACS);
      END;   
    END LOOP
    COMMIT;
  END;
  
  PRC_REP_ASS_RPG_MUDAR_REGRA_2(pCAD_REP_ID, pCAD_REP_DT_INICIO_VIGENCIA, pSEG_USU_ID_USUARIO, pCAD_CLC_ID, pCAD_REP_ID_FILTRO);
  
END PRC_REP_ASS_RPG_MUDAR_REGRA_1;
/
