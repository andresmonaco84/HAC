CREATE OR REPLACE PROCEDURE PRC_ASS_PMD_PESSOA_MD5_AUX_I IS
  CURSOR MD5 IS
  /********************************************************************
  *    Procedure: PRC_ASS_PMD_PESSOA_MD5_AUX_I
  * 
  *    Data Criacao:   data da criacao   Por: Nome do Analista
  *    Funcao: Descricao da funcionalidade da Stored Procedure

  *    Data Alteracao:  12/11/2010  Por: Fabiola Lopes
  *    Alteracao: Coloquei um trunc na data de nascimento para evitar de gravar a hora
  *
  *    Data Alteracao:
  *    Alteracao:
  *
  *******************************************************************/  
    SELECT PMD.ASS_PMD_CD_MD5_ATUAL, COUNT(PMD.ASS_PMD_CD_MD5_ATUAL)
      FROM TB_ASS_PMD_PESSOA_MD5 PMD
     GROUP BY PMD.ASS_PMD_CD_MD5_ATUAL
    HAVING COUNT(PMD.ASS_PMD_CD_MD5_ATUAL) > 1
     ORDER BY PMD.ASS_PMD_CD_MD5_ATUAL;
BEGIN
  FOR I IN MD5 LOOP
    FOR J IN (SELECT PMD.ASS_PMD_ID,
                     PMD.ASS_PMD_CD_MD5_ATUAL,
                     PMD.ASS_PMD_CD_MD5_ANTERIOR,
                     PMD.ASS_PMD_DT_ULTIMA_ATUALIZACAO,
                     PMD.SEG_USU_ID_USUARIO,
                     PMD.CAD_PES_ID_PESSOA,
                     PES.CAD_PES_NM_PESSOA,
                     PES.CAD_PES_NM_NOMEMAE,
                     PES.CAD_PES_TP_SEXO,
                     PES.CAD_PES_DT_NASCIMENTO
                FROM TB_ASS_PMD_PESSOA_MD5 PMD, TB_CAD_PES_PESSOA PES
               WHERE PMD.ASS_PMD_CD_MD5_ATUAL = I.ASS_PMD_CD_MD5_ATUAL
                 AND PMD.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA) LOOP
      INSERT INTO TB_ASS_PMD_PESSOA_MD5_AUX AUX
        (AUX.ASS_PMD_ID,
         AUX.ASS_PMD_CD_MD5_ATUAL,
         AUX.ASS_PMD_CD_MD5_ANTERIOR,
         AUX.ASS_PMD_DT_ULTIMA_ATUALIZACAO,
         AUX.SEG_USU_ID_USUARIO,
         AUX.CAD_PES_ID_PESSOA,
         AUX.ASS_PMD_NM_PACIENTE,
         AUX.ASS_PMD_NM_MAE,
         AUX.ASS_PMD_TP_SEXO,
         TRUNC(AUX.ASS_PMD_DT_NASCIMENTO),
         AUX.ASS_PMD_FL_STATUS)
      VALUES
        (J.ASS_PMD_ID,
         J.ASS_PMD_CD_MD5_ATUAL,
         J.ASS_PMD_CD_MD5_ANTERIOR,
         J.ASS_PMD_DT_ULTIMA_ATUALIZACAO,
         J.SEG_USU_ID_USUARIO,
         J.CAD_PES_ID_PESSOA,
         J.CAD_PES_NM_PESSOA,
         J.CAD_PES_NM_NOMEMAE,
         J.CAD_PES_TP_SEXO,
         J.CAD_PES_DT_NASCIMENTO,
         'A');
    END LOOP;
    COMMIT;
  END LOOP;
END PRC_ASS_PMD_PESSOA_MD5_AUX_I;
