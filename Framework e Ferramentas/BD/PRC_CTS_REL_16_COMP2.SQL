CREATE OR REPLACE PROCEDURE SGS.PRC_CTS_REL_16_COMP2(pCTS_RES_RESU_MES IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_MES_PAGTO%type,
                                           pCTS_RES_RESU_ANO IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_ANO_PAGTO%type) IS
  V_MES            NUMBER(2);
  V_ANO            NUMBER(4);
  V_CONTADOR_MES NUMBER;
  V_CONTADOR     NUMBER;
BEGIN
  V_CONTADOR_MES := 12;
  V_MES            := pCTS_RES_RESU_MES;
  V_ANO            := pCTS_RES_RESU_ANO;
  V_CONTADOR     := 0;
  WHILE V_CONTADOR_MES > 0 LOOP
    FOR CTS IN 
      (
        SELECT X.DESCRICAO,
               X.DIARIA DIARIAS,
               X.CONTA,
               X.MES,
               X.ANO,
               X.VALOR_MES VALOR,
               X.PERCENTUAL_MES PERCENTUAL,
               X.CTS_RES_RESU_COD_DESCRICAO,
               X.CTS_RES_RESU_COD_DIARIA CODIGO_DIARIA
          FROM TB_CTS_ANALISE_GERENCIAL_COMP1 X
         WHERE X.MES = V_MES
           AND X.ANO = V_ANO
         ORDER BY 1,2
      ) LOOP
      IF V_CONTADOR_MES = 12 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL_COMP2 C
           SET C.MES_12                  = V_MES,
               C.ANO_12                  = V_ANO,
               C.VALOR_MES_12            = CTS.VALOR,
               C.PERCENTUAL_MES_12       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO = CTS.CTS_RES_RESU_COD_DESCRICAO;
        COMMIT;
      END IF;
      IF V_CONTADOR_MES = 11 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL_COMP2 C
           SET C.MES_11                  = V_MES,
              C.ANO_11                  = V_ANO,
               C.VALOR_MES_11            = CTS.VALOR,
               C.PERCENTUAL_MES_11       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO = CTS.CTS_RES_RESU_COD_DESCRICAO;
        COMMIT;
      END IF;
      IF V_CONTADOR_MES = 10 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL_COMP2 C
           SET C.MES_10                  = V_MES,
               C.ANO_10                  = V_ANO,
               C.VALOR_MES_10            = CTS.VALOR,
               C.PERCENTUAL_MES_10       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO = CTS.CTS_RES_RESU_COD_DESCRICAO;
        COMMIT;
      END IF;
      IF V_CONTADOR_MES = 9 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL_COMP2 C
           SET C.MES_09                  = V_MES,
               C.ANO_09                  = V_ANO,
               C.VALOR_MES_09            = CTS.VALOR,
               C.PERCENTUAL_MES_09       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO = CTS.CTS_RES_RESU_COD_DESCRICAO;
        COMMIT;
      END IF;
      IF V_CONTADOR_MES = 8 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL_COMP2 C
           SET C.MES_08                  = V_MES,
               C.ANO_08                  = V_ANO,
               C.VALOR_MES_08            = CTS.VALOR,
               C.PERCENTUAL_MES_08       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO = CTS.CTS_RES_RESU_COD_DESCRICAO;
      END IF;
      IF V_CONTADOR_MES = 7 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL_COMP2 C
           SET C.MES_07                  = V_MES,
               C.ANO_07                  = V_ANO,
               C.VALOR_MES_07            = CTS.VALOR,
               C.PERCENTUAL_MES_07       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO = CTS.CTS_RES_RESU_COD_DESCRICAO;
        COMMIT;
      END IF;
      IF V_CONTADOR_MES = 6 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL_COMP2 C
           SET C.MES_06                  = V_MES,
               C.ANO_06                  = V_ANO,
               C.VALOR_MES_06            = CTS.VALOR,
               C.PERCENTUAL_MES_06       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO = CTS.CTS_RES_RESU_COD_DESCRICAO;
        COMMIT;
      END IF;
      IF V_CONTADOR_MES = 5 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL_COMP2 C
           SET C.MES_05                  = V_MES,
               C.ANO_05                  = V_ANO,
               C.VALOR_MES_05            = CTS.VALOR,
               C.PERCENTUAL_MES_05       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO = CTS.CTS_RES_RESU_COD_DESCRICAO;
        COMMIT;
      END IF;
      IF V_CONTADOR_MES = 4 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL_COMP2 C
           SET C.MES_04                  = V_MES,
               C.ANO_04                  = V_ANO,
               C.VALOR_MES_04            = CTS.VALOR,
               C.PERCENTUAL_MES_04       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO = CTS.CTS_RES_RESU_COD_DESCRICAO;
        COMMIT;
      END IF;
      IF V_CONTADOR_MES = 3 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL_COMP2 C
           SET C.MES_03                  = V_MES,
               C.ANO_03                  = V_ANO,
               C.VALOR_MES_03            = CTS.VALOR,
               C.PERCENTUAL_MES_03       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO = CTS.CTS_RES_RESU_COD_DESCRICAO;
        COMMIT;
      END IF;
      IF V_CONTADOR_MES = 2 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL_COMP2 C
           SET C.MES_02                  = V_MES,
               C.ANO_02                  = V_ANO,
               C.VALOR_MES_02            = CTS.VALOR,
               C.PERCENTUAL_MES_02       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO = CTS.CTS_RES_RESU_COD_DESCRICAO;
        COMMIT;
      END IF;
      IF V_CONTADOR_MES = 1 THEN
        UPDATE TB_CTS_ANALISE_GERENCIAL_COMP2 C
           SET C.MES_01                  = V_MES,
               C.ANO_01                  = V_ANO,
               C.VALOR_MES_01            = CTS.VALOR,
               C.PERCENTUAL_MES_01       = CTS.PERCENTUAL,
               C.CTS_RES_RESU_COD_DIARIA = CTS.CODIGO_DIARIA
         WHERE C.DIARIA = CTS.DIARIAS
           AND C.CTS_RES_RESU_COD_DESCRICAO = CTS.CTS_RES_RESU_COD_DESCRICAO;
        COMMIT;
      END IF;
      V_CONTADOR := V_CONTADOR + 1;
      IF V_CONTADOR = 256 THEN
        COMMIT;
        V_MES := V_MES - 1;
        IF V_MES = 0 THEN
          V_MES := 12;
          V_ANO := V_ANO - 1;
        END IF;
        V_CONTADOR_MES := V_CONTADOR_MES - 1;
        V_CONTADOR     := 0;
      END IF;
    END LOOP;
  END LOOP;
  COMMIT;
END PRC_CTS_REL_16_COMP2;
/
