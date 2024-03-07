CREATE OR REPLACE PROCEDURE PRC_CTS_REL_16(pCTS_RES_RESU_MES IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_MES_PAGTO%type,
                                           pCTS_RES_RESU_ANO IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_ANO_PAGTO%type) IS
  MES            NUMBER(2);
  ANO            NUMBER(4);
  V_CONTADOR_MES NUMBER;
  V_CONTADOR     NUMBER;

BEGIN
  V_CONTADOR_MES := 12;
  MES            := pCTS_RES_RESU_MES;
  ANO            := pCTS_RES_RESU_ANO;
  V_CONTADOR     := 0;
  WHILE V_CONTADOR_MES > 0 LOOP
    FOR CTS IN (SELECT RES.CTS_RES_RESU_TIPO TIPO,
                       RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL NIVEL,
                       RTRIM(UPPER(RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI)) DESCRICAO,
                       RES.CTS_RES_RESU_CAD_CTS_CD_CONTA CONTA,
                       'RECEITA DIRETA' DIARIAS,
                       ROUND(SUM(RES.CTS_RES_RESU_VL_REC_DIRETA)) VALOR,
                       ROUND(DECODE(RES.CTS_RES_RESU_VL_REC_DIRETA +
                                    RES.CTS_RES_RESU_VL_REC_INDIRETA +
                                    RES.CTS_RES_RESU_VL_REC_INTERMEDI,
                                    0,
                                    0,
                                    (RES.CTS_RES_RESU_VL_REC_DIRETA) /
                                    (RES.CTS_RES_RESU_VL_REC_DIRETA +
                                    RES.CTS_RES_RESU_VL_REC_INDIRETA +
                                    RES.CTS_RES_RESU_VL_REC_INTERMEDI) * 100),
                             2) PERCENTUAL,
                       RES.CTS_RES_RESU_COD_DESCRICAO,
                       1 CODIGO_DIARIA
                  FROM TB_CTS_RES_RESUMO_GERAL RES
                 WHERE RES.CTS_RES_RESU_MES = MES
                   AND RES.CTS_RES_RESU_ANO = ANO
                   AND RES.CTS_RES_RESU_TIPO = 'R'
                   AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
                 GROUP BY RES.CTS_RES_RESU_TIPO,
                          RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL,
                          RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI,
                          CTS_RES_RESU_CAD_CTS_CD_CONTA,
                          RES.CTS_RES_RESU_COD_DESCRICAO,
                          DECODE(RES.CTS_RES_RESU_VL_REC_DIRETA +
                                 RES.CTS_RES_RESU_VL_REC_INDIRETA +
                                 RES.CTS_RES_RESU_VL_REC_INTERMEDI,
                                 0,
                                 0,
                                 (RES.CTS_RES_RESU_VL_REC_DIRETA) /
                                 (RES.CTS_RES_RESU_VL_REC_DIRETA +
                                 RES.CTS_RES_RESU_VL_REC_INDIRETA +
                                 RES.CTS_RES_RESU_VL_REC_INTERMEDI) * 100),
                          RES.CTS_RES_RESU_COD_DESCRICAO
                UNION ALL
                -- RECEITA INDIRETA
                SELECT RES.CTS_RES_RESU_TIPO TIPO,
                       RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL NIVEL,
                       RTRIM(UPPER(RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI)) DESCRICAO,
                       UPPER(RES.CTS_RES_RESU_CAD_CTS_CD_CONTA) CONTA,
                       'RECEITA INDIRETA' DIARIAS,
                       ROUND(SUM(RES.CTS_RES_RESU_VL_REC_INDIRETA)) VALOR,
                       ROUND(DECODE((SUM(RES.CTS_RES_RESU_VL_REC_DIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_REC_INDIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_REC_INTERMEDI)),
                                    0,
                                    0,
                                    (SUM(RES.CTS_RES_RESU_VL_REC_INDIRETA)) /
                                    (SUM(RES.CTS_RES_RESU_VL_REC_DIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_REC_INDIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_REC_INTERMEDI)) * 100),
                             2) PERCENTUAL,
                       RES.CTS_RES_RESU_COD_DESCRICAO,
                       2 CODIGO_DIARIA
                  FROM TB_CTS_RES_RESUMO_GERAL RES
                 WHERE RES.CTS_RES_RESU_MES = MES
                   AND RES.CTS_RES_RESU_ANO = ANO
                   AND RES.CTS_RES_RESU_TIPO = 'R'
                   AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
                 GROUP BY RES.CTS_RES_RESU_TIPO,
                          RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL,
                          RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI,
                          CTS_RES_RESU_CAD_CTS_CD_CONTA,
                          RES.CTS_RES_RESU_COD_DESCRICAO
                UNION ALL
                -- RECEITA PROPRIA
                SELECT RES.CTS_RES_RESU_TIPO TIPO,
                       RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL NIVEL,
                       RTRIM(UPPER(RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI)) DESCRICAO,
                       UPPER(RES.CTS_RES_RESU_CAD_CTS_CD_CONTA) CONTA,
                       'RECEITA PROPRIA' DIARIAS,
                       ROUND(SUM(RES.CTS_RES_RESU_VL_REC_DIRETA)) +
                       ROUND(SUM(RES.CTS_RES_RESU_VL_REC_INDIRETA)) VALOR,
                       ROUND(DECODE(SUM(RES.CTS_RES_RESU_VL_REC_DIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_REC_INDIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_REC_INTERMEDI),
                                    0,
                                    0,
                                    (SUM(RES.CTS_RES_RESU_VL_REC_DIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_REC_INDIRETA)) /
                                    (SUM(RES.CTS_RES_RESU_VL_REC_DIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_REC_INDIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_REC_INTERMEDI)) * 100),
                             2) PERCENTUAL,
                       RES.CTS_RES_RESU_COD_DESCRICAO,
                       3 CODIGO_DIARIA
                  FROM TB_CTS_RES_RESUMO_GERAL RES
                 WHERE RES.CTS_RES_RESU_MES = MES
                   AND RES.CTS_RES_RESU_ANO = ANO
                   AND RES.CTS_RES_RESU_TIPO = 'R'
                   AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
                 GROUP BY RES.CTS_RES_RESU_TIPO,
                          RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL,
                          RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI,
                          CTS_RES_RESU_CAD_CTS_CD_CONTA,
                          RES.CTS_RES_RESU_COD_DESCRICAO
                UNION ALL
                -- DESPESA DIRETA
                SELECT RES.CTS_RES_RESU_TIPO TIPO,
                       RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL NIVEL,
                       RTRIM(UPPER(RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI)) DESCRICAO,
                       UPPER(RES.CTS_RES_RESU_CAD_CTS_CD_CONTA) CONTA,
                       'DESPESA DIRETA' DIARIAS,
                       ROUND(SUM(RES.CTS_RES_RESU_VL_DESP_DIRETA)) VALOR,
                       ROUND(DECODE(SUM(RES.CTS_RES_RESU_VL_DESP_DIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_DESP_INDIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_DESP_INTERMEDI),
                                    0,
                                    0,
                                    (SUM(RES.CTS_RES_RESU_VL_DESP_DIRETA) /
                                    (SUM(RES.CTS_RES_RESU_VL_DESP_DIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_DESP_INDIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_DESP_INTERMEDI)) * 100)),
                             2) PERCENTUAL,
                       RES.CTS_RES_RESU_COD_DESCRICAO,
                       4 CODIGO_DIARIA
                  FROM TB_CTS_RES_RESUMO_GERAL RES
                 WHERE RES.CTS_RES_RESU_MES = MES
                   AND RES.CTS_RES_RESU_ANO = ANO
                   AND RES.CTS_RES_RESU_TIPO = 'R'
                   AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
                 GROUP BY RES.CTS_RES_RESU_TIPO,
                          RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL,
                          RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI,
                          CTS_RES_RESU_CAD_CTS_CD_CONTA,
                          RES.CTS_RES_RESU_COD_DESCRICAO
                UNION ALL
                -- DESPESA INDIRETA          
                SELECT RES.CTS_RES_RESU_TIPO TIPO,
                       RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL NIVEL,
                       RTRIM(UPPER(RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI)) DESCRICAO,
                       UPPER(RES.CTS_RES_RESU_CAD_CTS_CD_CONTA) CONTA,
                       'DESPESA INDIRETA' DIARIAS,
                       ROUND(SUM(RES.CTS_RES_RESU_VL_DESP_INDIRETA)) VALOR,
                       ROUND(DECODE(SUM(RES.CTS_RES_RESU_VL_DESP_DIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_DESP_INDIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_DESP_INTERMEDI),
                                    0,
                                    0,
                                    (SUM(RES.CTS_RES_RESU_VL_DESP_INDIRETA)) /
                                    (SUM(RES.CTS_RES_RESU_VL_DESP_DIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_DESP_INDIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_DESP_INTERMEDI)) * 100),
                             2) PERCENTUAL,
                       RES.CTS_RES_RESU_COD_DESCRICAO,
                       5 CODIGO_DIARIA
                  FROM TB_CTS_RES_RESUMO_GERAL RES
                 WHERE RES.CTS_RES_RESU_MES = MES
                   AND RES.CTS_RES_RESU_ANO = ANO
                   AND RES.CTS_RES_RESU_TIPO = 'R'
                   AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
                 GROUP BY RES.CTS_RES_RESU_TIPO,
                          RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL,
                          RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI,
                          CTS_RES_RESU_CAD_CTS_CD_CONTA,
                          RES.CTS_RES_RESU_COD_DESCRICAO
                UNION ALL
                --DESPESA PROPRIA
                SELECT RES.CTS_RES_RESU_TIPO TIPO,
                       RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL NIVEL,
                       RTRIM(UPPER(RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI)) DESCRICAO,
                       UPPER(RES.CTS_RES_RESU_CAD_CTS_CD_CONTA) CONTA,
                       'DESPESA PROPRIA' DIARIAS,
                       ROUND(SUM(RES.CTS_RES_RESU_VL_DESP_DIRETA)) +
                       ROUND(SUM(RES.CTS_RES_RESU_VL_DESP_INDIRETA)) VALOR,
                       ROUND(DECODE(SUM(RES.CTS_RES_RESU_VL_DESP_DIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_DESP_INDIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_DESP_INTERMEDI),
                                    0,
                                    0,
                                    (SUM(RES.CTS_RES_RESU_VL_DESP_DIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_DESP_INDIRETA)) /
                                    (SUM(RES.CTS_RES_RESU_VL_DESP_DIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_DESP_INDIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_DESP_INTERMEDI)) * 100),
                             2) PERCENTUAL,
                       RES.CTS_RES_RESU_COD_DESCRICAO,
                       6 CODIGO_DIARIA
                  FROM TB_CTS_RES_RESUMO_GERAL RES
                 WHERE RES.CTS_RES_RESU_MES = MES
                   AND RES.CTS_RES_RESU_ANO = ANO
                   AND RES.CTS_RES_RESU_TIPO = 'R'
                   AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
                 GROUP BY RES.CTS_RES_RESU_TIPO,
                          RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL,
                          RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI,
                          CTS_RES_RESU_CAD_CTS_CD_CONTA,
                          RES.CTS_RES_RESU_COD_DESCRICAO
                UNION ALL
                -- RECEITA INTERMEDIARIA
                SELECT RES.CTS_RES_RESU_TIPO TIPO,
                       RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL NIVEL,
                       RTRIM(UPPER(RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI)) DESCRICAO,
                       UPPER(RES.CTS_RES_RESU_CAD_CTS_CD_CONTA) CONTA,
                       'RECEITA INTERMEDIARIA' DIARIAS,
                       ROUND(SUM(RES.CTS_RES_RESU_VL_REC_INTERMEDI)) VALOR,
                       
                       ROUND(DECODE(SUM(RES.CTS_RES_RESU_VL_REC_DIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_REC_INDIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_REC_INTERMEDI),
                                    0,
                                    0,
                                    (SUM(RES.CTS_RES_RESU_VL_REC_INTERMEDI)) /
                                    (SUM(RES.CTS_RES_RESU_VL_REC_DIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_REC_INDIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_REC_INTERMEDI)) * 100),
                             2) PERCENTUAL,
                       RES.CTS_RES_RESU_COD_DESCRICAO,
                       7 CODIGO_DIARIA
                  FROM TB_CTS_RES_RESUMO_GERAL RES
                 WHERE RES.CTS_RES_RESU_MES = MES
                   AND RES.CTS_RES_RESU_ANO = ANO
                   AND RES.CTS_RES_RESU_TIPO = 'R'
                   AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
                 GROUP BY RES.CTS_RES_RESU_TIPO,
                          RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL,
                          RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI,
                          CTS_RES_RESU_CAD_CTS_CD_CONTA,
                          RES.CTS_RES_RESU_COD_DESCRICAO
                
                UNION ALL
                -- DESPESA INTERMEDIARIA
                SELECT RES.CTS_RES_RESU_TIPO TIPO,
                       RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL NIVEL,
                       RTRIM(UPPER(RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI)) DESCRICAO,
                       RES.CTS_RES_RESU_CAD_CTS_CD_CONTA CONTA,
                       'DESPESA INTERMEDIARIA' DIARIAS,
                       ROUND(SUM(RES.CTS_RES_RESU_VL_DESP_INTERMEDI)) VALOR,
                       DECODE(SUM(RES.CTS_RES_RESU_VL_DESP_DIRETA) +
                              SUM(RES.CTS_RES_RESU_VL_DESP_INDIRETA) +
                              SUM(RES.CTS_RES_RESU_VL_DESP_INTERMEDI),
                              0,
                              0,
                              ROUND((SUM(RES.CTS_RES_RESU_VL_DESP_INTERMEDI) /
                                    (SUM(RES.CTS_RES_RESU_VL_DESP_DIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_DESP_INDIRETA) +
                                    SUM(RES.CTS_RES_RESU_VL_DESP_INTERMEDI))) * 100,
                                    2)) PERCENTUAL,
                       RES.CTS_RES_RESU_COD_DESCRICAO,
                       8 CODIGO_DIARIA
                  FROM TB_CTS_RES_RESUMO_GERAL RES
                 WHERE RES.CTS_RES_RESU_MES = MES
                   AND RES.CTS_RES_RESU_ANO = ANO
                   AND RES.CTS_RES_RESU_TIPO = 'R'
                   AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
                 GROUP BY RES.CTS_RES_RESU_TIPO,
                          RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL,
                          RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI,
                          CTS_RES_RESU_CAD_CTS_CD_CONTA,
                          RES.CTS_RES_RESU_COD_DESCRICAO
                UNION ALL
                --INDICE RESULTADO DIRETO
                SELECT RES.CTS_RES_RESU_TIPO TIPO,
                       RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL NIVEL,
                       RTRIM(UPPER(RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI)) DESCRICAO,
                       UPPER(RES.CTS_RES_RESU_CAD_CTS_CD_CONTA) CONTA,
                       'INDICE RESULTADO DIRETO' DIARIAS,
                       ROUND(SUM(RES.CTS_RES_RESU_VL_REC_DIRETA) /
                             SUM(RES.CTS_RES_RESU_VL_DESP_DIRETA),
                             2) VALOR,
                       NULL PERCENTUAL,
                       RES.CTS_RES_RESU_COD_DESCRICAO,
                       9 CODIGO_DIARIA
                  FROM TB_CTS_RES_RESUMO_GERAL RES
                 WHERE RES.CTS_RES_RESU_MES = MES
                   AND RES.CTS_RES_RESU_ANO = ANO
                   AND RES.CTS_RES_RESU_TIPO = 'R'
                   AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
                 GROUP BY RES.CTS_RES_RESU_TIPO,
                          RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL,
                          RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI,
                          CTS_RES_RESU_CAD_CTS_CD_CONTA,
                          RES.CTS_RES_RESU_COD_DESCRICAO
                UNION ALL
                --INDICE RESULTADO PROPRIO - (DIRETO + INDIRETO)
                SELECT RES.CTS_RES_RESU_TIPO TIPO,
                       RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL NIVEL,
                       RTRIM(UPPER(RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI)) DESCRICAO,
                       UPPER(RES.CTS_RES_RESU_CAD_CTS_CD_CONTA) CONTA,
                       'INDICE RESULTADO PROPRIO (DIRETO + INDIRETO)' DIARIAS,
                       ROUND((SUM(RES.CTS_RES_RESU_VL_REC_DIRETA) +
                             SUM(CTS_RES_RESU_VL_REC_INDIRETA)) /
                             (SUM(RES.CTS_RES_RESU_VL_DESP_DIRETA) +
                             SUM(RES.CTS_RES_RESU_VL_DESP_INDIRETA)),
                             2) VALOR,
                       NULL PERCENTUAL,
                       RES.CTS_RES_RESU_COD_DESCRICAO,
                       10 CODIGO_DIARIA
                  FROM TB_CTS_RES_RESUMO_GERAL RES
                 WHERE RES.CTS_RES_RESU_MES = MES
                   AND RES.CTS_RES_RESU_ANO = ANO
                   AND RES.CTS_RES_RESU_TIPO = 'R'
                   AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
                 GROUP BY RES.CTS_RES_RESU_TIPO,
                          RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL,
                          RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI,
                          CTS_RES_RESU_CAD_CTS_CD_CONTA,
                          RES.CTS_RES_RESU_COD_DESCRICAO
                UNION ALL
                --INDICE RESULTADO INTERMEDIARIO
                SELECT RES.CTS_RES_RESU_TIPO TIPO,
                       RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL NIVEL,
                       RTRIM(UPPER(RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI)) DESCRICAO,
                       UPPER(RES.CTS_RES_RESU_CAD_CTS_CD_CONTA) CONTA,
                       'INDICE RESULTADO INTERMEDIARIO' DIARIAS,
                       --SUM(RES.CTS_RES_RESU_VL_REC_INTERMEDI) / SUM(RES.CTS_RES_RESU_VL_DESP_INTERMEDI) VALOR,
                       ROUND(DECODE(SUM(RES.CTS_RES_RESU_VL_DESP_INTERMEDI),
                                    0,
                                    0,
                                    SUM(RES.CTS_RES_RESU_VL_REC_INTERMEDI) /
                                    SUM(RES.CTS_RES_RESU_VL_DESP_INTERMEDI)),
                             2) VALOR,
                       NULL PERCENTUAL,
                       RES.CTS_RES_RESU_COD_DESCRICAO,
                       11 CODIGO_DIARIA
                  FROM TB_CTS_RES_RESUMO_GERAL RES
                 WHERE RES.CTS_RES_RESU_MES = MES
                   AND RES.CTS_RES_RESU_ANO = ANO
                   AND RES.CTS_RES_RESU_TIPO = 'R'
                   AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
                 GROUP BY RES.CTS_RES_RESU_TIPO,
                          RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL,
                          RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI,
                          CTS_RES_RESU_CAD_CTS_CD_CONTA,
                          RES.CTS_RES_RESU_COD_DESCRICAO
                UNION ALL
                -- RECEITA TOTAL
                SELECT RES.CTS_RES_RESU_TIPO TIPO,
                       RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL NIVEL,
                       RTRIM(UPPER(RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI)) DESCRICAO,
                       UPPER(RES.CTS_RES_RESU_CAD_CTS_CD_CONTA) CONTA,
                       'RECEITA TOTAL' DIARIAS,
                       ROUND(SUM(RES.CTS_RES_RESU_VL_REC_DIRETA) +
                             SUM(RES.CTS_RES_RESU_VL_REC_INDIRETA) +
                             SUM(RES.CTS_RES_RESU_VL_REC_INTERMEDI)) VALOR,
                       NULL PERCENTUAL,
                       RES.CTS_RES_RESU_COD_DESCRICAO,
                       12 CODIGO_DIARIA
                  FROM TB_CTS_RES_RESUMO_GERAL RES
                 WHERE RES.CTS_RES_RESU_MES = MES
                   AND RES.CTS_RES_RESU_ANO = ANO
                   AND RES.CTS_RES_RESU_TIPO = 'R'
                   AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
                 GROUP BY RES.CTS_RES_RESU_TIPO,
                          RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL,
                          RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI,
                          CTS_RES_RESU_CAD_CTS_CD_CONTA,
                          RES.CTS_RES_RESU_COD_DESCRICAO
                UNION ALL
                -- DESPESA TOTAL
                SELECT RES.CTS_RES_RESU_TIPO TIPO,
                       RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL NIVEL,
                       RTRIM(UPPER(RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI)) DESCRICAO,
                       UPPER(RES.CTS_RES_RESU_CAD_CTS_CD_CONTA) CONTA,
                       'DESPESA TOTAL' DIARIAS,
                       ROUND(SUM(RES.CTS_RES_RESU_VL_DESP_DIRETA) +
                             SUM(RES.CTS_RES_RESU_VL_DESP_INDIRETA) +
                             SUM(RES.CTS_RES_RESU_VL_DESP_INTERMEDI)) VALOR,
                       NULL PERCENTUAL,
                       RES.CTS_RES_RESU_COD_DESCRICAO,
                       13 CODIGO_DIARIA
                  FROM TB_CTS_RES_RESUMO_GERAL RES
                 WHERE RES.CTS_RES_RESU_MES = MES
                   AND RES.CTS_RES_RESU_ANO = ANO
                   AND RES.CTS_RES_RESU_TIPO = 'R'
                   AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
                 GROUP BY RES.CTS_RES_RESU_TIPO,
                          RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL,
                          RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI,
                          CTS_RES_RESU_CAD_CTS_CD_CONTA,
                          RES.CTS_RES_RESU_COD_DESCRICAO
                UNION ALL
                -- INDICE RESULTADO TOTAL
                SELECT RES.CTS_RES_RESU_TIPO TIPO,
                       RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL NIVEL,
                       RTRIM(UPPER(RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI)) DESCRICAO,
                       UPPER(RES.CTS_RES_RESU_CAD_CTS_CD_CONTA) CONTA,
                       'INDICE RESULTADO TOTAL' DIARIAS,
                       ROUND((SUM(RES.CTS_RES_RESU_VL_REC_DIRETA) +
                             SUM(RES.CTS_RES_RESU_VL_REC_INDIRETA) +
                             SUM(RES.CTS_RES_RESU_VL_REC_INTERMEDI)) /
                             (SUM(RES.CTS_RES_RESU_VL_DESP_DIRETA) +
                             SUM(RES.CTS_RES_RESU_VL_DESP_INDIRETA) +
                             SUM(RES.CTS_RES_RESU_VL_DESP_INTERMEDI)),
                             2) VALOR,
                       NULL PERCENTUAL,
                       RES.CTS_RES_RESU_COD_DESCRICAO,
                       14 CODIGO_DIARIA
                  FROM TB_CTS_RES_RESUMO_GERAL RES
                 WHERE RES.CTS_RES_RESU_MES = MES
                   AND RES.CTS_RES_RESU_ANO = ANO
                   AND RES.CTS_RES_RESU_TIPO = 'R'
                   AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
                 GROUP BY RES.CTS_RES_RESU_TIPO,
                          RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL,
                          RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI,
                          CTS_RES_RESU_CAD_CTS_CD_CONTA,
                          RES.CTS_RES_RESU_COD_DESCRICAO
                UNION ALL
                -- PACIENTES DIA
                SELECT RES.CTS_RES_RESU_TIPO TIPO,
                       RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL NIVEL,
                       RTRIM(UPPER(RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI)) DESCRICAO,
                       RES.CTS_RES_RESU_CAD_CTS_CD_CONTA CONTA,
                       'PACIENTES DIA' DIARIAS,
                       ROUND(SUM(RES.CTS_RES_RESU_VL_PACIENTES_DIA)) VALOR,
                       NULL PERCENTUAL,
                       RES.CTS_RES_RESU_COD_DESCRICAO,
                       15 CODIGO_DIARIA
                  FROM TB_CTS_RES_RESUMO_GERAL RES
                 WHERE RES.CTS_RES_RESU_MES = MES
                   AND RES.CTS_RES_RESU_ANO = ANO
                   AND RES.CTS_RES_RESU_TIPO = 'R'
                   AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
                 GROUP BY RES.CTS_RES_RESU_TIPO,
                          RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL,
                          RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI,
                          CTS_RES_RESU_CAD_CTS_CD_CONTA,
                          RES.CTS_RES_RESU_COD_DESCRICAO
                -- RESULTADO PACIENTE DIA
                UNION ALL
                SELECT RES.CTS_RES_RESU_TIPO TIPO,
                       RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL NIVEL,
                       RTRIM(UPPER(RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI)) DESCRICAO,
                       RES.CTS_RES_RESU_CAD_CTS_CD_CONTA CONTA,
                       'RESULTADO PACIENTE DIA' DIARIAS,
                       DECODE(SUM(RES.CTS_RES_RESU_VL_PACIENTES_DIA),
                              0,
                              0,
                              ((SUM(RES.CTS_RES_RESU_VL_REC_DIRETA) +
                              SUM(RES.CTS_RES_RESU_VL_REC_INDIRETA) +
                              SUM(RES.CTS_RES_RESU_VL_REC_INTERMEDI)) -
                              (SUM(RES.CTS_RES_RESU_VL_DESP_DIRETA) +
                              SUM(RES.CTS_RES_RESU_VL_DESP_INDIRETA) +
                              SUM(RES.CTS_RES_RESU_VL_DESP_INTERMEDI))) /
                              SUM(RES.CTS_RES_RESU_VL_PACIENTES_DIA)) VALOR,
                       
                       NULL                           PERCENTUAL,
                       RES.CTS_RES_RESU_COD_DESCRICAO,
                       16                             CODIGO_DIARIA
                  FROM TB_CTS_RES_RESUMO_GERAL RES
                 WHERE RES.CTS_RES_RESU_MES = MES
                   AND RES.CTS_RES_RESU_ANO = ANO
                   AND RES.CTS_RES_RESU_TIPO = 'R'
                   AND RES.CTS_RES_RESU_CAD_CTS_CD_CONTA != 1
                 GROUP BY RES.CTS_RES_RESU_TIPO,
                          RES.CTS_RES_RESU_CAD_CTS_CD_NIVEL,
                          RES.CTS_RES_RESU_CAD_CTS_DS_DESCRI,
                          CTS_RES_RESU_CAD_CTS_CD_CONTA,
                          RES.CTS_RES_RESU_COD_DESCRICAO
                 ORDER BY DESCRICAO) LOOP
    
      IF V_CONTADOR_MES = 12 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL C
           SET C.MES_12                  = MES,
               C.ANO_12                  = ANO,
               C.VALOR_MES_12            = CTS.VALOR,
               C.PERCENTUAL_MES_12       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO =
               CTS.CTS_RES_RESU_COD_DESCRICAO;
        COMMIT;
      END IF;
    
      IF V_CONTADOR_MES = 11 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL C
           SET C.MES_11                  = MES,
               C.ANO_11                  = ANO,
               C.VALOR_MES_11            = CTS.VALOR,
               C.PERCENTUAL_MES_11       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO =
               CTS.CTS_RES_RESU_COD_DESCRICAO;
        COMMIT;
      END IF;
    
      IF V_CONTADOR_MES = 10 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL C
           SET C.MES_10                  = MES,
               C.ANO_10                  = ANO,
               C.VALOR_MES_10            = CTS.VALOR,
               C.PERCENTUAL_MES_10       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO =
               CTS.CTS_RES_RESU_COD_DESCRICAO;
        COMMIT;
      END IF;
    
      IF V_CONTADOR_MES = 9 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL C
           SET C.MES_09                  = MES,
               C.ANO_09                  = ANO,
               C.VALOR_MES_09            = CTS.VALOR,
               C.PERCENTUAL_MES_09       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO =
               CTS.CTS_RES_RESU_COD_DESCRICAO;
        COMMIT;
      END IF;
    
      IF V_CONTADOR_MES = 8 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL C
           SET C.MES_08                  = MES,
               C.ANO_08                  = ANO,
               C.VALOR_MES_08            = CTS.VALOR,
               C.PERCENTUAL_MES_08       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO =
               CTS.CTS_RES_RESU_COD_DESCRICAO;
      END IF;
    
      IF V_CONTADOR_MES = 7 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL C
           SET C.MES_07                  = MES,
               C.ANO_07                  = ANO,
               C.VALOR_MES_07            = CTS.VALOR,
               C.PERCENTUAL_MES_07       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO =
               CTS.CTS_RES_RESU_COD_DESCRICAO;
        COMMIT;
      END IF;
    
      IF V_CONTADOR_MES = 6 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL C
           SET C.MES_06                  = MES,
               C.ANO_06                  = ANO,
               C.VALOR_MES_06            = CTS.VALOR,
               C.PERCENTUAL_MES_06       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO =
               CTS.CTS_RES_RESU_COD_DESCRICAO;
        COMMIT;
      END IF;
    
      IF V_CONTADOR_MES = 5 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL C
           SET C.MES_05                  = MES,
               C.ANO_05                  = ANO,
               C.VALOR_MES_05            = CTS.VALOR,
               C.PERCENTUAL_MES_05       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO =
               CTS.CTS_RES_RESU_COD_DESCRICAO;
        COMMIT;
      END IF;
    
      IF V_CONTADOR_MES = 4 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL C
           SET C.MES_04                  = MES,
               C.ANO_04                  = ANO,
               C.VALOR_MES_04            = CTS.VALOR,
               C.PERCENTUAL_MES_04       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO =
               CTS.CTS_RES_RESU_COD_DESCRICAO;
        COMMIT;
      END IF;
    
      IF V_CONTADOR_MES = 3 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL C
           SET C.MES_03                  = MES,
               C.ANO_03                  = ANO,
               C.VALOR_MES_03            = CTS.VALOR,
               C.PERCENTUAL_MES_03       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO =
               CTS.CTS_RES_RESU_COD_DESCRICAO;
        COMMIT;
      END IF;
    
      IF V_CONTADOR_MES = 2 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL C
           SET C.MES_02                  = MES,
               C.ANO_02                  = ANO,
               C.VALOR_MES_02            = CTS.VALOR,
               C.PERCENTUAL_MES_02       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO =
               CTS.CTS_RES_RESU_COD_DESCRICAO;
        COMMIT;
      END IF;
    
      IF V_CONTADOR_MES = 1 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL C
           SET C.MES_01                  = MES,
               C.ANO_01                  = ANO,
               C.VALOR_MES_01            = CTS.VALOR,
               C.PERCENTUAL_MES_01       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO =
               CTS.CTS_RES_RESU_COD_DESCRICAO;
        COMMIT;
      END IF;
    
      V_CONTADOR := V_CONTADOR + 1;
    
      IF V_CONTADOR = 256 THEN
        COMMIT;
        MES := MES - 1;
        IF MES = 0 THEN
          MES := 12;
          ANO := ANO - 1;
        END IF;
      
        V_CONTADOR_MES := V_CONTADOR_MES - 1;
        V_CONTADOR     := 0;
      END IF;
    END LOOP;
  END LOOP;

  COMMIT;

END PRC_CTS_REL_16;
/
