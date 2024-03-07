CREATE OR REPLACE PROCEDURE "PRC_CTS_ATU_PERC_REC_DES_D" (pCTS_RES_MES IN TB_CTS_RES_RESULTADO_CUSTOS.CTS_RES_MES%TYPE,
                                                          pCTS_RES_ANO IN TB_CTS_RES_RESULTADO_CUSTOS.CTS_RES_ANO%TYPE) IS
BEGIN
    FOR TEMP IN (SELECT RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI,RES.SEQ_CTS_RES_RESUMO_01,

                        CASE WHEN (TOTAL_DIRETA_INTERMEDIARIA.TOT_RECEITA_DIR_INT > 0) THEN
                             ROUND((RES.CTS_RES_RESU_VL_REC_DIRETA  + RES.CTS_RES_RESU_VL_REC_INTERMEDI)  /
                             TOTAL_DIRETA_INTERMEDIARIA.TOT_RECEITA_DIR_INT, 4) 
                        ELSE
                             0
                        END PERC_RATEIO_RECEITA,

                        CASE WHEN (TOTAL_DIRETA_INTERMEDIARIA.TOT_DESPESA_DIR_INT > 0) THEN
                             ROUND((RES.CTS_RES_RESU_VL_DESP_DIRETA + RES.CTS_RES_RESU_VL_DESP_INTERMEDI) /
                             TOTAL_DIRETA_INTERMEDIARIA.TOT_DESPESA_DIR_INT, 4) 
                        ELSE
                             0
                        END PERC_RATEIO_DESPESA,

                        CASE WHEN (RES.CTS_RES_RESU_VL_DESP_DIRETA + RES.CTS_RES_RESU_VL_DESP_INTERMEDI) > 0 THEN
                             ROUND(((RES.CTS_RES_RESU_VL_REC_DIRETA  + RES.CTS_RES_RESU_VL_REC_INTERMEDI) /
                             (RES.CTS_RES_RESU_VL_DESP_DIRETA + RES.CTS_RES_RESU_VL_DESP_INTERMEDI)) - 1, 4)
                        ELSE
                             0
                        END PERC_DIRETO,

                        CASE WHEN (RES.CTS_RES_RESU_VL_DESP_DIRETA + RES.CTS_RES_RESU_VL_DESP_INTERMEDI + RES.CTS_RES_RESU_VL_DESP_INDIRETA) > 0 THEN
                             ROUND(((RES.CTS_RES_RESU_VL_REC_DIRETA  + RES.CTS_RES_RESU_VL_REC_INTERMEDI + RES.CTS_RES_RESU_VL_REC_INDIRETA) /
                             (RES.CTS_RES_RESU_VL_DESP_DIRETA + RES.CTS_RES_RESU_VL_DESP_INTERMEDI + RES.CTS_RES_RESU_VL_DESP_INDIRETA)) - 1, 4)
                        ELSE
                             0
                        END PERC_TOTAL

  FROM TB_CTS_RES_RESUMO_GERAL RES, (SELECT SUM(RES.CTS_RES_RESU_VL_REC_DIRETA)  + SUM(RES.CTS_RES_RESU_VL_REC_INTERMEDI)  TOT_RECEITA_DIR_INT,
                                            SUM(RES.CTS_RES_RESU_VL_DESP_DIRETA) + SUM(RES.CTS_RES_RESU_VL_DESP_INTERMEDI) TOT_DESPESA_DIR_INT
                                           FROM TB_CTS_RES_RESUMO_GERAL RES
                                          WHERE RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL = 2
                                            AND RES.CTS_RES_RESU_MES = pCTS_RES_MES
                                            AND RES.CTS_RES_RESU_ANO = pCTS_RES_ANO
                                            AND RES.CTS_RES_RESU_TIPO = 'D'
                                            AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1) TOTAL_DIRETA_INTERMEDIARIA,
                                     (SELECT SUM(RES.CTS_RES_RESU_VL_REC_DIRETA) + SUM(RES.CTS_RES_RESU_VL_REC_INTERMEDI)  + SUM(RES.CTS_RES_RESU_VL_REC_INDIRETA)  TOT_RECEITA,
                                            SUM(RES.CTS_RES_RESU_VL_DESP_DIRETA) + SUM(RES.CTS_RES_RESU_VL_DESP_INTERMEDI) + SUM(RES.CTS_RES_RESU_VL_DESP_INDIRETA) TOT_DESPESA
                                           FROM TB_CTS_RES_RESUMO_GERAL RES
                                          WHERE RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL = 2
                                            AND RES.CTS_RES_RESU_MES = pCTS_RES_MES
                                            AND RES.CTS_RES_RESU_ANO = pCTS_RES_ANO
                                            AND RES.CTS_RES_RESU_TIPO = 'D'
                                            AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1) TOTAL
 WHERE RES.CTS_RES_RESU_MES = pCTS_RES_MES
   AND RES.CTS_RES_RESU_ANO = pCTS_RES_ANO
   AND RES.CTS_RES_RESU_TIPO = 'D'
   AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
ORDER BY 1) LOOP
      BEGIN
        UPDATE TB_CTS_RES_RESUMO_GERAL CTS
           SET CTS.CTS_RES_RESU_PC_RATEIO_RECEITA = TEMP.PERC_RATEIO_RECEITA,
               CTS.CTS_RES_RESU_PC_RATEIO_DESPESA = TEMP.PERC_RATEIO_DESPESA,
               CTS.CTS_RES_RESU_PC_DIRETO = TEMP.PERC_DIRETO,
               CTS.CTS_RES_RESU_PC_TOTAL = TEMP.PERC_TOTAL
         WHERE CTS.SEQ_CTS_RES_RESUMO_01 = TEMP.SEQ_CTS_RES_RESUMO_01
           AND CTS.CTS_RES_RESU_MES = pCTS_RES_MES
           AND CTS.CTS_RES_RESU_ANO = pCTS_RES_ANO;
      END;
      COMMIT;
  END LOOP;
END PRC_CTS_ATU_PERC_REC_DES_D;
