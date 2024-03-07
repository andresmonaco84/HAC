CREATE OR REPLACE PROCEDURE PRC_ATS_RETORNA_DATA_EXAME_S
(
pCAD_UNI_ID_UNIDADE           IN TB_ATS_UPR_UNI_PRA_RESULTADO.CAD_UNI_ID_UNIDADE%TYPE,
                                                           pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ATS_UPR_UNI_PRA_RESULTADO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE,
                                                           pAUX_EPP_CD_ESPECPROC         IN TB_ATS_UPR_UNI_PRA_RESULTADO.AUX_EPP_CD_ESPECPROC%TYPE,
                                                           pCAD_PRD_ID                   IN TB_ATS_UPR_UNI_PRA_RESULTADO.CAD_PRD_ID%TYPE,
                                                           pATS_UPR_QT_DIAS              OUT NUMBER) IS
  /********************************************************************
  *    Procedure: PRC_ATS_RETORNA_DATA_EXAME_S
  *
  *    Data Criacao:      Por:
  *    Funcao:
  *
  *    Data Alteracao: 06/09/2010  Por: Pedro
  *    Alteracao:   -- AND UPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
  *
  *******************************************************************/
BEGIN
  BEGIN
    SELECT NVL(UPR.ATS_UPR_QT_DIAS, 0)
      INTO pATS_UPR_QT_DIAS
      FROM TB_ATS_UPR_UNI_PRA_RESULTADO UPR
     WHERE UPR.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
      -- AND UPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
       AND UPR.AUX_EPP_CD_ESPECPROC = pAUX_EPP_CD_ESPECPROC
       AND UPR.CAD_PRD_ID = pCAD_PRD_ID;
  EXCEPTION
    WHEN NO_DATA_FOUND THEN
      BEGIN
        SELECT NVL(UPR.ATS_UPR_QT_DIAS, 0)
          INTO pATS_UPR_QT_DIAS
          FROM TB_ATS_UPR_UNI_PRA_RESULTADO UPR
         WHERE UPR.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
          -- AND UPR.CAD_LAT_ID_LOCAL_ATENDIMENTO =  pCAD_LAT_ID_LOCAL_ATENDIMENTO
           AND UPR.AUX_EPP_CD_ESPECPROC = pAUX_EPP_CD_ESPECPROC
           AND UPR.CAD_PRD_ID IS NULL;
      EXCEPTION
        WHEN NO_DATA_FOUND THEN
          pATS_UPR_QT_DIAS := 0;
      END;
  END;
END PRC_ATS_RETORNA_DATA_EXAME_S;
/
