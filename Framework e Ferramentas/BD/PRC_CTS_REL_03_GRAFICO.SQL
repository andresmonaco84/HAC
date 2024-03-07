CREATE OR REPLACE PROCEDURE "PRC_CTS_REL_03_GRAFICO"
(
  IO_CURSOR OUT PKG_CURSOR.T_CURSOR,
  pCTS_RES_RESU_MES       IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_MES_PAGTO%type,
  pCTS_RES_RESU_ANO       IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_ANO_PAGTO%type
)
IS
  V_CURSOR PKG_CURSOR.T_CURSOR;
BEGIN
  
DECLARE
  V_MES  NUMBER;
  V_ANO  NUMBER;
  V_DATA DATE;
  C_MES  VARCHAR(2);
  C_ANO  VARCHAR(4);
  C_DATA VARCHAR(10);
BEGIN
  V_MES := pCTS_RES_RESU_MES;
  V_ANO := pCTS_RES_RESU_ANO;
  C_MES := TO_CHAR(V_MES);
  C_ANO := TO_CHAR(V_ANO);
  C_DATA:= '01/' || LPAD(C_MES, 2, '0') || '/' || C_ANO;
  V_DATA := TO_DATE(C_DATA, 'DD/MM/YYYY');
  
  OPEN V_CURSOR FOR
SELECT RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI                              DESCRICAO,
       (SUM(MES1.PERC_DIRETO_1) * 100)                                 PERCENTUAL_DIRETO,
       (SUM(MES1.PERC_TOTAL_1)  * 100)                                 PERCENTUAL_TOTAL,
       RES.CTS_RES_RESU_ANO || '/' || LPAD(RES.CTS_RES_RESU_MES,2,'0') ANOMES
  FROM TB_CTS_RES_RESUMO_GERAL RES,
  (SELECT RES.SEQ_CTS_RES_RESUMO_01,
          RES.CTS_RES_RESU_PC_DIRETO PERC_DIRETO_1,
          TOT_PERC_DIR_TOT_1.TOT_PERC_DIRETO1 TOTAL_PERC_DIRETO1,
          RES.CTS_RES_RESU_PC_TOTAL PERC_TOTAL_1,
          TOT_PERC_DIR_TOT_1.TOT_PERC_TOTAL1 TOTAL_PERC_TOTAL1
     FROM TB_CTS_RES_RESUMO_GERAL RES, (SELECT ROUND(SUM((((RES.CTS_RES_RESU_VL_REC_DIRETA +
                                                            RES.CTS_RES_RESU_VL_REC_INTERMEDI) /
                                                           (RES.CTS_RES_RESU_VL_DESP_DIRETA +
                                                            RES.CTS_RES_RESU_VL_DESP_INTERMEDI)))-1),2) TOT_PERC_DIRETO1,
                                               ROUND(SUM((((RES.CTS_RES_RESU_VL_REC_DIRETA +
                                                            RES.CTS_RES_RESU_VL_REC_INTERMEDI +
                                                            RES.CTS_RES_RESU_VL_REC_INDIRETA) /
                                                           (RES.CTS_RES_RESU_VL_DESP_DIRETA +
                                                            RES.CTS_RES_RESU_VL_DESP_INTERMEDI +
                                                            RES.CTS_RES_RESU_VL_DESP_INDIRETA )))-1),2) TOT_PERC_TOTAL1
                                          FROM TB_CTS_RES_RESUMO_GERAL RES
                                         WHERE RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL = 2
                                           AND RES.CTS_RES_RESU_TIPO = 'R'
                                           AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
                                           AND TO_DATE('01/' || LPAD(RES.CTS_RES_RESU_MES, 2, '0') || '/' || RES.CTS_RES_RESU_ANO, 'DD/MM/YYYY')
                                           BETWEEN TRUNC(ADD_MONTHS(V_DATA, -12))
                                           AND TRUNC(ADD_MONTHS(V_DATA, -1)) ) TOT_PERC_DIR_TOT_1
    WHERE RES.CTS_RES_RESU_TIPO = 'R'
      AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
      AND TO_DATE('01/' || LPAD(RES.CTS_RES_RESU_MES, 2, '0') || '/' || RES.CTS_RES_RESU_ANO, 'DD/MM/YYYY')
      BETWEEN TRUNC(ADD_MONTHS(V_DATA, -12))
      AND TRUNC(ADD_MONTHS(V_DATA, -1))
    ORDER BY RES.CTS_RES_RESU_TIPO, CTS_RES_RESU_CAD_CTS_CD_CONTA) MES1
 WHERE RES.CTS_RES_RESU_TIPO = 'R'
   AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
   AND RES.SEQ_CTS_RES_RESUMO_01 = MES1.SEQ_CTS_RES_RESUMO_01(+)
   AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA IN ('110', '180')
   AND TO_DATE('01/' || LPAD(RES.CTS_RES_RESU_MES, 2, '0') || '/' || RES.CTS_RES_RESU_ANO, 'DD/MM/YYYY')
   BETWEEN TRUNC(ADD_MONTHS(V_DATA, -12))
   AND TRUNC(ADD_MONTHS(V_DATA, -1))
 GROUP BY RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI,
          RES.CTS_RES_RESU_ANO || '/' || LPAD(RES.CTS_RES_RESU_MES,2,'0')
 ORDER BY 4, 1;
 END;
 IO_CURSOR := V_CURSOR;
END  PRC_CTS_REL_03_GRAFICO;
