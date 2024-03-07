CREATE OR REPLACE PROCEDURE "PRC_CTS_REL_04"
  (
     pCTS_RES_RESU_MES1       IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_MES_PAGTO%type,
     pCTS_RES_RESU_ANO1       IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_ANO_PAGTO%type,
     pCTS_RES_RESU_MES2       IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_MES_PAGTO%type,
     pCTS_RES_RESU_ANO2       IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_ANO_PAGTO%type,
     pCTS_RES_RESU_MES3       IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_MES_PAGTO%type,
     pCTS_RES_RESU_ANO3       IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_ANO_PAGTO%type,
     pCTS_RES_RESU_MES4       IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_MES_PAGTO%type,
     pCTS_RES_RESU_ANO4       IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_ANO_PAGTO%type,
     pCTS_RES_RESU_MES5       IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_MES_PAGTO%type,
     pCTS_RES_RESU_ANO5       IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_ANO_PAGTO%type,
     pCTS_RES_RESU_MES6       IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_MES_PAGTO%type,
     pCTS_RES_RESU_ANO6       IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_ANO_PAGTO%type,
     pCTS_RES_RESU_MES7       IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_MES_PAGTO%type,
     pCTS_RES_RESU_ANO7       IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_ANO_PAGTO%type,
     pCTS_RES_RESU_MES8       IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_MES_PAGTO%type,
     pCTS_RES_RESU_ANO8       IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_ANO_PAGTO%type,
     pCTS_RES_RESU_MES9       IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_MES_PAGTO%type,
     pCTS_RES_RESU_ANO9       IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_ANO_PAGTO%type,
     pCTS_RES_RESU_MES10      IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_MES_PAGTO%type,
     pCTS_RES_RESU_ANO10      IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_ANO_PAGTO%type,
     pCTS_RES_RESU_MES11      IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_MES_PAGTO%type,
     pCTS_RES_RESU_ANO11      IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_ANO_PAGTO%type,
     pCTS_RES_RESU_MES12      IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_MES_PAGTO%type,
     pCTS_RES_RESU_ANO12      IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_ANO_PAGTO%type,
     IO_CURSOR                OUT PKG_CURSOR.T_CURSOR
  )
  IS
v_cursor PKG_CURSOR.t_cursor;
BEGIN
  OPEN v_cursor FOR
    SELECT RES.CTS_RES_RESU_TIPO              TIPO,
           RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL  NIVEL,
           RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI DESCRICAO,
           RES.CTS_RES_RESU_CAD_CTS_CD_CONTA  CONTA,

           MES1.PERC_TOTAL_1,
           MES2.PERC_TOTAL_2,
           MES3.PERC_TOTAL_3,
           MES4.PERC_TOTAL_4,
           MES5.PERC_TOTAL_5,
           MES6.PERC_TOTAL_6,
           MES7.PERC_TOTAL_7,
           MES8.PERC_TOTAL_8,
           MES9.PERC_TOTAL_9,
           MES10.PERC_TOTAL_10,
           MES11.PERC_TOTAL_11,
           MES12.PERC_TOTAL_12,
           MES1.TOTAL_PERC_TOTAL1,
           MES2.TOTAL_PERC_TOTAL2,
           MES3.TOTAL_PERC_TOTAL3,
           MES4.TOTAL_PERC_TOTAL4,
           MES5.TOTAL_PERC_TOTAL5,
           MES6.TOTAL_PERC_TOTAL6,
           MES7.TOTAL_PERC_TOTAL7,
           MES8.TOTAL_PERC_TOTAL8,
           MES9.TOTAL_PERC_TOTAL9,
           MES10.TOTAL_PERC_TOTAL10,
           MES11.TOTAL_PERC_TOTAL11,
           MES12.TOTAL_PERC_TOTAL12

      FROM TB_CTS_RES_RESUMO_GERAL RES,

      (SELECT RES.CTS_RES_RESU_PC_TOTAL PERC_TOTAL_1, RES.SEQ_CTS_RES_RESUMO_01, T0TAL_PERCENTUAL_TOTAL1.TOT_PERC_TOTAL1 TOTAL_PERC_TOTAL1
         FROM TB_CTS_RES_RESUMO_GERAL RES, (SELECT ROUND(SUM((((RES.CTS_RES_RESU_VL_REC_DIRETA +
                                                                RES.CTS_RES_RESU_VL_REC_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_REC_INDIRETA) /
                                                               (RES.CTS_RES_RESU_VL_DESP_DIRETA +
                                                                RES.CTS_RES_RESU_VL_DESP_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_DESP_INDIRETA )))-1),4) TOT_PERC_TOTAL1
                                              FROM TB_CTS_RES_RESUMO_GERAL RES
                                             WHERE RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL = 2
                                               AND RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES1
                                               AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO1
                                               AND RES.CTS_RES_RESU_TIPO = 'R'
--                                               AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0)
                                               AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1 ) T0TAL_PERCENTUAL_TOTAL1
        WHERE RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES1
          AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO1
          AND RES.CTS_RES_RESU_TIPO = 'R'
--          AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0) --VER SE TEM NECESSIDADE
          AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
        ORDER BY RES.CTS_RES_RESU_TIPO, CTS_RES_RESU_CAD_CTS_CD_CONTA) MES1,


      (SELECT RES.CTS_RES_RESU_PC_TOTAL PERC_TOTAL_2, RES.SEQ_CTS_RES_RESUMO_01, T0TAL_PERCENTUAL_TOTAL2.TOT_PERC_TOTAL2 TOTAL_PERC_TOTAL2
         FROM TB_CTS_RES_RESUMO_GERAL RES, (SELECT ROUND(SUM((((RES.CTS_RES_RESU_VL_REC_DIRETA +
                                                                RES.CTS_RES_RESU_VL_REC_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_REC_INDIRETA) /
                                                               (RES.CTS_RES_RESU_VL_DESP_DIRETA +
                                                                RES.CTS_RES_RESU_VL_DESP_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_DESP_INDIRETA )))-1),4) TOT_PERC_TOTAL2
                                              FROM TB_CTS_RES_RESUMO_GERAL RES
                                             WHERE RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL = 2
                                               AND RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES2
                                               AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO2
                                               AND RES.CTS_RES_RESU_TIPO = 'R'
--                                               AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0)
                                               AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1 ) T0TAL_PERCENTUAL_TOTAL2
        WHERE RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES2
          AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO2
          AND RES.CTS_RES_RESU_TIPO = 'R'
--          AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0) --VER SE TEM NECESSIDADE
          AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
        ORDER BY RES.CTS_RES_RESU_TIPO, CTS_RES_RESU_CAD_CTS_CD_CONTA) MES2,


        (SELECT RES.CTS_RES_RESU_PC_TOTAL PERC_TOTAL_3, RES.SEQ_CTS_RES_RESUMO_01, T0TAL_PERCENTUAL_TOTAL3.TOT_PERC_TOTAL3 TOTAL_PERC_TOTAL3
         FROM TB_CTS_RES_RESUMO_GERAL RES, (SELECT ROUND(SUM((((RES.CTS_RES_RESU_VL_REC_DIRETA +
                                                                RES.CTS_RES_RESU_VL_REC_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_REC_INDIRETA) /
                                                               (RES.CTS_RES_RESU_VL_DESP_DIRETA +
                                                                RES.CTS_RES_RESU_VL_DESP_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_DESP_INDIRETA )))-1),4) TOT_PERC_TOTAL3
                                              FROM TB_CTS_RES_RESUMO_GERAL RES
                                             WHERE RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL = 2
                                               AND RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES3
                                               AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO3
                                               AND RES.CTS_RES_RESU_TIPO = 'R'
--                                               AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0)
                                               AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1 ) T0TAL_PERCENTUAL_TOTAL3
        WHERE RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES3
          AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO3
          AND RES.CTS_RES_RESU_TIPO = 'R'
--          AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0) --VER SE TEM NECESSIDADE
          AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
        ORDER BY RES.CTS_RES_RESU_TIPO, CTS_RES_RESU_CAD_CTS_CD_CONTA) MES3,


        (SELECT RES.CTS_RES_RESU_PC_TOTAL PERC_TOTAL_4, RES.SEQ_CTS_RES_RESUMO_01, T0TAL_PERCENTUAL_TOTAL4.TOT_PERC_TOTAL4 TOTAL_PERC_TOTAL4
         FROM TB_CTS_RES_RESUMO_GERAL RES, (SELECT ROUND(SUM((((RES.CTS_RES_RESU_VL_REC_DIRETA +
                                                                RES.CTS_RES_RESU_VL_REC_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_REC_INDIRETA) /
                                                               (RES.CTS_RES_RESU_VL_DESP_DIRETA +
                                                                RES.CTS_RES_RESU_VL_DESP_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_DESP_INDIRETA )))-1),4) TOT_PERC_TOTAL4
                                              FROM TB_CTS_RES_RESUMO_GERAL RES
                                             WHERE RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL = 2
                                               AND RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES4
                                               AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO4
                                               AND RES.CTS_RES_RESU_TIPO = 'R'
--                                               AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0)
                                               AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1 ) T0TAL_PERCENTUAL_TOTAL4
        WHERE RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES4
          AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO4
          AND RES.CTS_RES_RESU_TIPO = 'R'
--          AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0) --VER SE TEM NECESSIDADE
          AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
        ORDER BY RES.CTS_RES_RESU_TIPO, CTS_RES_RESU_CAD_CTS_CD_CONTA) MES4,


        (SELECT RES.CTS_RES_RESU_PC_TOTAL PERC_TOTAL_5, RES.SEQ_CTS_RES_RESUMO_01, T0TAL_PERCENTUAL_TOTAL5.TOT_PERC_TOTAL5 TOTAL_PERC_TOTAL5
         FROM TB_CTS_RES_RESUMO_GERAL RES, (SELECT ROUND(SUM((((RES.CTS_RES_RESU_VL_REC_DIRETA +
                                                                RES.CTS_RES_RESU_VL_REC_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_REC_INDIRETA) /
                                                               (RES.CTS_RES_RESU_VL_DESP_DIRETA +
                                                                RES.CTS_RES_RESU_VL_DESP_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_DESP_INDIRETA )))-1),4) TOT_PERC_TOTAL5
                                              FROM TB_CTS_RES_RESUMO_GERAL RES
                                             WHERE RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL = 2
                                               AND RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES5
                                               AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO5
                                               AND RES.CTS_RES_RESU_TIPO = 'R'
--                                               AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0)
                                               AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1 ) T0TAL_PERCENTUAL_TOTAL5
        WHERE RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES5
          AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO5
          AND RES.CTS_RES_RESU_TIPO = 'R'
--          AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0) --VER SE TEM NECESSIDADE
          AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
        ORDER BY RES.CTS_RES_RESU_TIPO, CTS_RES_RESU_CAD_CTS_CD_CONTA) MES5,


        (SELECT RES.CTS_RES_RESU_PC_TOTAL PERC_TOTAL_6, RES.SEQ_CTS_RES_RESUMO_01, T0TAL_PERCENTUAL_TOTAL6.TOT_PERC_TOTAL6 TOTAL_PERC_TOTAL6
         FROM TB_CTS_RES_RESUMO_GERAL RES, (SELECT ROUND(SUM((((RES.CTS_RES_RESU_VL_REC_DIRETA +
                                                                RES.CTS_RES_RESU_VL_REC_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_REC_INDIRETA) /
                                                               (RES.CTS_RES_RESU_VL_DESP_DIRETA +
                                                                RES.CTS_RES_RESU_VL_DESP_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_DESP_INDIRETA )))-1),4) TOT_PERC_TOTAL6
                                              FROM TB_CTS_RES_RESUMO_GERAL RES
                                             WHERE RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL = 2
                                               AND RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES6
                                               AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO6
                                               AND RES.CTS_RES_RESU_TIPO = 'R'
--                                               AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0)
                                               AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1 ) T0TAL_PERCENTUAL_TOTAL6
        WHERE RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES6
          AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO6
          AND RES.CTS_RES_RESU_TIPO = 'R'
--          AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0) --VER SE TEM NECESSIDADE
          AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
        ORDER BY RES.CTS_RES_RESU_TIPO, CTS_RES_RESU_CAD_CTS_CD_CONTA) MES6,


        (SELECT RES.CTS_RES_RESU_PC_TOTAL PERC_TOTAL_7, RES.SEQ_CTS_RES_RESUMO_01, T0TAL_PERCENTUAL_TOTAL7.TOT_PERC_TOTAL7 TOTAL_PERC_TOTAL7
         FROM TB_CTS_RES_RESUMO_GERAL RES, (SELECT ROUND(SUM((((RES.CTS_RES_RESU_VL_REC_DIRETA +
                                                                RES.CTS_RES_RESU_VL_REC_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_REC_INDIRETA) /
                                                               (RES.CTS_RES_RESU_VL_DESP_DIRETA +
                                                                RES.CTS_RES_RESU_VL_DESP_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_DESP_INDIRETA )))-1),4) TOT_PERC_TOTAL7
                                              FROM TB_CTS_RES_RESUMO_GERAL RES
                                             WHERE RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL = 2
                                               AND RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES7
                                               AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO7
                                               AND RES.CTS_RES_RESU_TIPO = 'R'
--                                               AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0)
                                               AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1 ) T0TAL_PERCENTUAL_TOTAL7
        WHERE RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES7
          AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO7
          AND RES.CTS_RES_RESU_TIPO = 'R'
--          AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0) --VER SE TEM NECESSIDADE
          AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
        ORDER BY RES.CTS_RES_RESU_TIPO, CTS_RES_RESU_CAD_CTS_CD_CONTA) MES7,


        (SELECT RES.CTS_RES_RESU_PC_TOTAL PERC_TOTAL_8, RES.SEQ_CTS_RES_RESUMO_01, T0TAL_PERCENTUAL_TOTAL8.TOT_PERC_TOTAL8 TOTAL_PERC_TOTAL8
         FROM TB_CTS_RES_RESUMO_GERAL RES, (SELECT ROUND(SUM((((RES.CTS_RES_RESU_VL_REC_DIRETA +
                                                                RES.CTS_RES_RESU_VL_REC_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_REC_INDIRETA) /
                                                               (RES.CTS_RES_RESU_VL_DESP_DIRETA +
                                                                RES.CTS_RES_RESU_VL_DESP_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_DESP_INDIRETA )))-1),4) TOT_PERC_TOTAL8
                                              FROM TB_CTS_RES_RESUMO_GERAL RES
                                             WHERE RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL = 2
                                               AND RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES8
                                               AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO8
                                               AND RES.CTS_RES_RESU_TIPO = 'R'
--                                               AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0)
                                               AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1 ) T0TAL_PERCENTUAL_TOTAL8
        WHERE RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES8
          AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO8
          AND RES.CTS_RES_RESU_TIPO = 'R'
--          AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0) --VER SE TEM NECESSIDADE
          AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
        ORDER BY RES.CTS_RES_RESU_TIPO, CTS_RES_RESU_CAD_CTS_CD_CONTA) MES8,


        (SELECT RES.CTS_RES_RESU_PC_TOTAL PERC_TOTAL_9, RES.SEQ_CTS_RES_RESUMO_01, T0TAL_PERCENTUAL_TOTAL9.TOT_PERC_TOTAL9 TOTAL_PERC_TOTAL9
         FROM TB_CTS_RES_RESUMO_GERAL RES, (SELECT ROUND(SUM((((RES.CTS_RES_RESU_VL_REC_DIRETA +
                                                                RES.CTS_RES_RESU_VL_REC_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_REC_INDIRETA) /
                                                               (RES.CTS_RES_RESU_VL_DESP_DIRETA +
                                                                RES.CTS_RES_RESU_VL_DESP_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_DESP_INDIRETA )))-1),4) TOT_PERC_TOTAL9
                                              FROM TB_CTS_RES_RESUMO_GERAL RES
                                             WHERE RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL = 2
                                               AND RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES9
                                               AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO9
                                               AND RES.CTS_RES_RESU_TIPO = 'R'
--                                               AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0)
                                               AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1 ) T0TAL_PERCENTUAL_TOTAL9
        WHERE RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES9
          AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO9
          AND RES.CTS_RES_RESU_TIPO = 'R'
--          AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0) --VER SE TEM NECESSIDADE
          AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
        ORDER BY RES.CTS_RES_RESU_TIPO, CTS_RES_RESU_CAD_CTS_CD_CONTA) MES9,


        (SELECT RES.CTS_RES_RESU_PC_TOTAL PERC_TOTAL_10, RES.SEQ_CTS_RES_RESUMO_01, T0TAL_PERCENTUAL_TOTAL10.TOT_PERC_TOTAL10 TOTAL_PERC_TOTAL10
         FROM TB_CTS_RES_RESUMO_GERAL RES, (SELECT ROUND(SUM((((RES.CTS_RES_RESU_VL_REC_DIRETA +
                                                                RES.CTS_RES_RESU_VL_REC_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_REC_INDIRETA) /
                                                               (RES.CTS_RES_RESU_VL_DESP_DIRETA +
                                                                RES.CTS_RES_RESU_VL_DESP_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_DESP_INDIRETA )))-1),4) TOT_PERC_TOTAL10
                                              FROM TB_CTS_RES_RESUMO_GERAL RES
                                             WHERE RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL = 2
                                               AND RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES10
                                               AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO10
                                               AND RES.CTS_RES_RESU_TIPO = 'R'
--                                               AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0)
                                               AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1 ) T0TAL_PERCENTUAL_TOTAL10
        WHERE RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES10
          AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO10
          AND RES.CTS_RES_RESU_TIPO = 'R'
--          AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0) --VER SE TEM NECESSIDADE
          AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
        ORDER BY RES.CTS_RES_RESU_TIPO, CTS_RES_RESU_CAD_CTS_CD_CONTA) MES10,


        (SELECT RES.CTS_RES_RESU_PC_TOTAL PERC_TOTAL_11, RES.SEQ_CTS_RES_RESUMO_01, T0TAL_PERCENTUAL_TOTAL11.TOT_PERC_TOTAL11 TOTAL_PERC_TOTAL11
         FROM TB_CTS_RES_RESUMO_GERAL RES, (SELECT ROUND(SUM((((RES.CTS_RES_RESU_VL_REC_DIRETA +
                                                                RES.CTS_RES_RESU_VL_REC_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_REC_INDIRETA) /
                                                               (RES.CTS_RES_RESU_VL_DESP_DIRETA +
                                                                RES.CTS_RES_RESU_VL_DESP_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_DESP_INDIRETA )))-1),4) TOT_PERC_TOTAL11
                                              FROM TB_CTS_RES_RESUMO_GERAL RES
                                             WHERE RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL = 2
                                               AND RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES11
                                               AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO11
                                               AND RES.CTS_RES_RESU_TIPO = 'R'
--                                               AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0)
                                               AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1 ) T0TAL_PERCENTUAL_TOTAL11
        WHERE RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES11
          AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO11
          AND RES.CTS_RES_RESU_TIPO = 'R'
--          AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0) --VER SE TEM NECESSIDADE
          AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
        ORDER BY RES.CTS_RES_RESU_TIPO, CTS_RES_RESU_CAD_CTS_CD_CONTA) MES11,


        (SELECT RES.CTS_RES_RESU_PC_TOTAL PERC_TOTAL_12, RES.SEQ_CTS_RES_RESUMO_01, T0TAL_PERCENTUAL_TOTAL12.TOT_PERC_TOTAL12 TOTAL_PERC_TOTAL12
         FROM TB_CTS_RES_RESUMO_GERAL RES, (SELECT ROUND(SUM((((RES.CTS_RES_RESU_VL_REC_DIRETA +
                                                                RES.CTS_RES_RESU_VL_REC_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_REC_INDIRETA) /
                                                               (RES.CTS_RES_RESU_VL_DESP_DIRETA +
                                                                RES.CTS_RES_RESU_VL_DESP_INTERMEDI +
                                                                RES.CTS_RES_RESU_VL_DESP_INDIRETA )))-1),4) TOT_PERC_TOTAL12
                                              FROM TB_CTS_RES_RESUMO_GERAL RES
                                             WHERE RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL = 2
                                               AND RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES12
                                               AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO12
                                               AND RES.CTS_RES_RESU_TIPO = 'R'
--                                               AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0)
                                               AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1 ) T0TAL_PERCENTUAL_TOTAL12
        WHERE RES.CTS_RES_RESU_MES = pCTS_RES_RESU_MES12
          AND RES.CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO12
          AND RES.CTS_RES_RESU_TIPO = 'R'
--          AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0) --VER SE TEM NECESSIDADE
          AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
        ORDER BY RES.CTS_RES_RESU_TIPO, CTS_RES_RESU_CAD_CTS_CD_CONTA) MES12

     WHERE RES.CTS_RES_RESU_TIPO = 'R'
       AND (RES.CTS_RES_RESU_VL_REC_DIRETA > 0 AND RES.CTS_RES_RESU_VL_DESP_DIRETA > 0) --VER SE TEM NECESSIDADE
       AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
       AND RES.SEQ_CTS_RES_RESUMO_01 = MES1.SEQ_CTS_RES_RESUMO_01(+)
       AND RES.SEQ_CTS_RES_RESUMO_01 = MES2.SEQ_CTS_RES_RESUMO_01(+)
       AND RES.SEQ_CTS_RES_RESUMO_01 = MES3.SEQ_CTS_RES_RESUMO_01(+)
       AND RES.SEQ_CTS_RES_RESUMO_01 = MES4.SEQ_CTS_RES_RESUMO_01(+)
       AND RES.SEQ_CTS_RES_RESUMO_01 = MES5.SEQ_CTS_RES_RESUMO_01(+)
       AND RES.SEQ_CTS_RES_RESUMO_01 = MES6.SEQ_CTS_RES_RESUMO_01(+)
       AND RES.SEQ_CTS_RES_RESUMO_01 = MES7.SEQ_CTS_RES_RESUMO_01(+)
       AND RES.SEQ_CTS_RES_RESUMO_01 = MES8.SEQ_CTS_RES_RESUMO_01(+)
       AND RES.SEQ_CTS_RES_RESUMO_01 = MES9.SEQ_CTS_RES_RESUMO_01(+)
       AND RES.SEQ_CTS_RES_RESUMO_01 = MES10.SEQ_CTS_RES_RESUMO_01(+)
       AND RES.SEQ_CTS_RES_RESUMO_01 = MES11.SEQ_CTS_RES_RESUMO_01(+)
       AND RES.SEQ_CTS_RES_RESUMO_01 = MES12.SEQ_CTS_RES_RESUMO_01(+)
     GROUP BY RES.CTS_RES_RESU_TIPO,
              RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL,
              RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI,
              RES.CTS_RES_RESU_CAD_CTS_CD_CONTA
     ORDER BY RES.CTS_RES_RESU_TIPO, CTS_RES_RESU_CAD_CTS_CD_CONTA;

    IO_CURSOR := V_CURSOR;
 END PRC_CTS_REL_04;
