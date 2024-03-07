CREATE OR REPLACE PROCEDURE PRC_REL_RFM_RESU_FAT_MTMD_G
(
   pREL_RFM_ANO_FECHAMENTO  IN TB_REL_RFM_RESU_FAT_MTMD.REL_RFM_ANO_FECHAMENTO%type,
   pREL_RFM_MES_FECHAMENTO  IN TB_REL_RFM_RESU_FAT_MTMD.REL_RFM_MES_FECHAMENTO%type,
   pSEG_USU_ID_USUARIO      IN TB_REL_RFM_RESU_FAT_MTMD.SEG_USU_ID_USUARIO%type,
   pPROCESSAR_FECHA_ESTOQUE IN INTEGER, -- 0 ou 1 (F ou V)
   pPROCESSAR_RECEITA       IN INTEGER  -- 0 ou 1 (F ou V)
)
  is
  /********************************************************************
  *    Procedure: PRC_REL_RFM_RESU_FAT_MTMD_G
  *
  *    Data Criacao:   30/09/2013   Por: André S. Monaco
  *    Data Alteração: 06/11/2013   Por: André S. Monaco  
  *         Alteração: Adição de NVL(PRD.CAD_CMM_CD_CARACMATMED, 0) nas
  *                    queries da receita
  *    Data Alteração: 12/12/2013   Por: André S. Monaco  
  *         Alteração: Adição de NVL(SUM(XXX), 0) em todas as
  *                    queries da receita
  *
  *    Funcao: Gerar dados do resumo do fechamento de mat/med
  *******************************************************************/
  dDataIni DATE;
  dDataFim DATE;
  sMes     VARCHAR2(2);
  nCount   INTEGER;
  nReceitaHAC1 NUMBER; -- MED. QUIMIO e PROT./ORT./SINT. HAC
  nReceitaACS1 NUMBER; -- MED. QUIMIO e PROT./ORT./SINT. ACS
  nCustoFunc1  NUMBER; -- CUSTO FUNC. MED. QUIMIO e PROT./ORT./SINT.
  nReceitaHAC2 NUMBER; -- MED. EXCETO QUIMIO e MAT. EXCETO PROT./ORT./SINT. HAC
  nReceitaACS2 NUMBER; -- MED. EXCETO QUIMIO e MAT. EXCETO PROT./ORT./SINT. ACS
  nCustoFunc2  NUMBER; -- CUSTO FUNC. MED. EXCETO QUIMIO e MAT. EXCETO PROT./ORT./SINT.
  BEGIN

    IF (NVL(pPROCESSAR_FECHA_ESTOQUE, 0) = 1) THEN

      IF (  LENGTH(TO_CHAR(pREL_RFM_MES_FECHAMENTO)) = 1 ) THEN
         sMes := '0' || TO_CHAR(pREL_RFM_MES_FECHAMENTO);
      ELSE
         sMes := TO_CHAR(pREL_RFM_MES_FECHAMENTO);
      END IF;
      dDataIni := TO_DATE('01' || sMes || TO_CHAR(pREL_RFM_ANO_FECHAMENTO)||' 0000','DDMMYYYY HH24MI');
      dDatafIM := TO_DATE( TO_CHAR(LAST_DAY(dDataIni),'DDMMYYYY')||' 2359','DDMMYYYY HH24MI');

      FOR VAL IN (
                  SELECT ROWNUM SEQUENCIA,
                         VALOR VL_ITEM
                  FROM (
                  SELECT NULL VALOR --1
                  FROM DUAL
                  UNION ALL
                  SELECT NULL VALOR --2
                  FROM DUAL
                  UNION ALL
                  SELECT (SELECT NVL(SUM(T.MTMD_VALOR_ENTRADA), 0)  --3
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 1 AND T.CAD_MTMD_SUBTP_ID = 1
                           AND T.CAD_MTMD_GRUPO_ID = 1 AND T.CAD_MTMD_SUBGRUPO_ID = 16
                           AND T.CAD_MTMD_FILIAL_ID = 1) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT ((SELECT NVL(SUM(T.MTMD_VALOR_SAIDA), 0)  --4
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 2 AND T.CAD_MTMD_SUBTP_ID NOT IN (6)
                           AND T.CAD_MTMD_GRUPO_ID = 1 AND T.CAD_MTMD_SUBGRUPO_ID = 16
                           AND T.MTMD_VALOR_SAIDA > 0 AND T.CAD_MTMD_FILIAL_ID = 1)+
                          (SELECT NVL(SUM(T.MTMD_VALOR_SAIDA), 0)
                              FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                             WHERE T.MTMD_MOV_DATA >= dDataIni
                               AND T.MTMD_MOV_DATA <= dDataFim
                               AND T.CAD_MTMD_TPMOV_ID = 2 AND T.CAD_MTMD_SUBTP_ID IN (6)
                               AND T.CAD_MTMD_GRUPO_ID = 1 AND T.CAD_MTMD_SUBGRUPO_ID = 16
                               AND T.MTMD_VALOR_SAIDA > 0 AND T.CAD_MTMD_FILIAL_ID = 1)-
                           (SELECT NVL(SUM(T.MTMD_VALOR_ENTRADA), 0)
                              FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                             WHERE T.MTMD_MOV_DATA >= dDataIni
                               AND T.MTMD_MOV_DATA <= dDataFim
                               AND T.CAD_MTMD_TPMOV_ID = 1 AND T.CAD_MTMD_SUBTP_ID != 1
                               AND T.CAD_MTMD_GRUPO_ID = 1 AND T.CAD_MTMD_SUBGRUPO_ID = 16
                               AND T.CAD_MTMD_FILIAL_ID = 1)
                         ) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT (SELECT NVL(SUM(T.MTMD_VALOR_ATUAL), 0)  --5
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 0 AND T.CAD_MTMD_SUBTP_ID = 0
                           AND T.CAD_MTMD_GRUPO_ID = 1 AND T.CAD_MTMD_SUBGRUPO_ID = 16
                           AND T.MTMD_VALOR_ATUAL > 0 AND T.CAD_MTMD_FILIAL_ID = 1) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT NULL VALOR  --6
                  FROM DUAL
                  UNION ALL
                  SELECT (SELECT NVL(SUM(T.MTMD_VALOR_ENTRADA), 0)  --7
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 1 AND T.CAD_MTMD_SUBTP_ID = 1
                           AND T.CAD_MTMD_GRUPO_ID = 1 AND T.CAD_MTMD_SUBGRUPO_ID = 16
                           AND T.CAD_MTMD_FILIAL_ID = 2) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT ((SELECT NVL(SUM(T.MTMD_VALOR_SAIDA), 0) --8
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 2 AND T.CAD_MTMD_SUBTP_ID NOT IN (6)
                           AND T.CAD_MTMD_GRUPO_ID = 1 AND T.CAD_MTMD_SUBGRUPO_ID = 16
                           AND T.MTMD_VALOR_SAIDA > 0 AND T.CAD_MTMD_FILIAL_ID = 2)+
                          (SELECT NVL(SUM(T.MTMD_VALOR_SAIDA), 0)
                              FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                             WHERE T.MTMD_MOV_DATA >= dDataIni
                               AND T.MTMD_MOV_DATA <= dDataFim
                               AND T.CAD_MTMD_TPMOV_ID = 2 AND T.CAD_MTMD_SUBTP_ID IN (6)
                               AND T.CAD_MTMD_GRUPO_ID = 1 AND T.CAD_MTMD_SUBGRUPO_ID = 16
                               AND T.MTMD_VALOR_SAIDA > 0 AND T.CAD_MTMD_FILIAL_ID = 2)-
                           (SELECT NVL(SUM(T.MTMD_VALOR_ENTRADA), 0)
                              FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                             WHERE T.MTMD_MOV_DATA >= dDataIni
                               AND T.MTMD_MOV_DATA <= dDataFim
                               AND T.CAD_MTMD_TPMOV_ID = 1 AND T.CAD_MTMD_SUBTP_ID != 1
                               AND T.CAD_MTMD_GRUPO_ID = 1 AND T.CAD_MTMD_SUBGRUPO_ID = 16
                               AND T.CAD_MTMD_FILIAL_ID = 2)
                         ) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT (SELECT NVL(SUM(T.MTMD_VALOR_ATUAL), 0) --9
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 0 AND T.CAD_MTMD_SUBTP_ID = 0
                           AND T.CAD_MTMD_GRUPO_ID = 1 AND T.CAD_MTMD_SUBGRUPO_ID = 16
                           AND T.MTMD_VALOR_ATUAL > 0 AND T.CAD_MTMD_FILIAL_ID = 2) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT NULL VALOR --10
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --11
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --12
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --13
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --14
                  FROM DUAL
                  UNION ALL                  
                  SELECT NULL VALOR --15
                  FROM DUAL
                  UNION ALL
                  SELECT NULL VALOR --16
                  FROM DUAL
                  UNION ALL
                  SELECT (SELECT NVL(SUM(T.MTMD_VALOR_ENTRADA), 0) --17
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 1 AND T.CAD_MTMD_SUBTP_ID = 1
                           AND T.CAD_MTMD_GRUPO_ID = 1 AND T.CAD_MTMD_SUBGRUPO_ID != 16
                           AND T.CAD_MTMD_FILIAL_ID = 1) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT ((SELECT NVL(SUM(T.MTMD_VALOR_SAIDA), 0) --18
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 2 AND T.CAD_MTMD_SUBTP_ID NOT IN (6)
                           AND T.CAD_MTMD_GRUPO_ID = 1 AND T.CAD_MTMD_SUBGRUPO_ID != 16
                           AND T.MTMD_VALOR_SAIDA > 0 AND T.CAD_MTMD_FILIAL_ID = 1)+
                          (SELECT NVL(SUM(T.MTMD_VALOR_SAIDA), 0)
                              FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                             WHERE T.MTMD_MOV_DATA >= dDataIni
                               AND T.MTMD_MOV_DATA <= dDataFim
                               AND T.CAD_MTMD_TPMOV_ID = 2 AND T.CAD_MTMD_SUBTP_ID IN (6)
                               AND T.CAD_MTMD_GRUPO_ID = 1 AND T.CAD_MTMD_SUBGRUPO_ID != 16
                               AND T.MTMD_VALOR_SAIDA > 0 AND T.CAD_MTMD_FILIAL_ID = 1)-
                           (SELECT NVL(SUM(T.MTMD_VALOR_ENTRADA), 0)
                              FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                             WHERE T.MTMD_MOV_DATA >= dDataIni
                               AND T.MTMD_MOV_DATA <= dDataFim
                               AND T.CAD_MTMD_TPMOV_ID = 1 AND T.CAD_MTMD_SUBTP_ID != 1
                               AND T.CAD_MTMD_GRUPO_ID = 1 AND T.CAD_MTMD_SUBGRUPO_ID != 16
                               AND T.CAD_MTMD_FILIAL_ID = 1)
                         ) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT (SELECT NVL(SUM(T.MTMD_VALOR_ATUAL), 0) --19
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 0 AND T.CAD_MTMD_SUBTP_ID = 0
                           AND T.CAD_MTMD_GRUPO_ID = 1 AND T.CAD_MTMD_SUBGRUPO_ID != 16
                           AND T.MTMD_VALOR_ATUAL > 0 AND T.CAD_MTMD_FILIAL_ID = 1) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT NULL VALOR --20
                  FROM DUAL
                  UNION ALL
                  SELECT (SELECT NVL(SUM(T.MTMD_VALOR_ENTRADA), 0) --21
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 1 AND T.CAD_MTMD_SUBTP_ID = 1
                           AND T.CAD_MTMD_GRUPO_ID = 1 AND T.CAD_MTMD_SUBGRUPO_ID != 16
                           AND T.CAD_MTMD_FILIAL_ID = 2) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT ((SELECT NVL(SUM(T.MTMD_VALOR_SAIDA), 0) --22
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 2 AND T.CAD_MTMD_SUBTP_ID NOT IN (6)
                           AND T.CAD_MTMD_GRUPO_ID = 1 AND T.CAD_MTMD_SUBGRUPO_ID != 16
                           AND T.MTMD_VALOR_SAIDA > 0 AND T.CAD_MTMD_FILIAL_ID = 2)+
                          (SELECT NVL(SUM(T.MTMD_VALOR_SAIDA), 0)
                              FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                             WHERE T.MTMD_MOV_DATA >= dDataIni
                               AND T.MTMD_MOV_DATA <= dDataFim
                               AND T.CAD_MTMD_TPMOV_ID = 2 AND T.CAD_MTMD_SUBTP_ID IN (6)
                               AND T.CAD_MTMD_GRUPO_ID = 1 AND T.CAD_MTMD_SUBGRUPO_ID != 16
                               AND T.MTMD_VALOR_SAIDA > 0 AND T.CAD_MTMD_FILIAL_ID = 2)-
                           (SELECT NVL(SUM(T.MTMD_VALOR_ENTRADA), 0)
                              FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                             WHERE T.MTMD_MOV_DATA >= dDataIni
                               AND T.MTMD_MOV_DATA <= dDataFim
                               AND T.CAD_MTMD_TPMOV_ID = 1 AND T.CAD_MTMD_SUBTP_ID != 1
                               AND T.CAD_MTMD_GRUPO_ID = 1 AND T.CAD_MTMD_SUBGRUPO_ID != 16
                               AND T.CAD_MTMD_FILIAL_ID = 2)
                         ) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT (SELECT NVL(SUM(T.MTMD_VALOR_ATUAL), 0) --23
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 0 AND T.CAD_MTMD_SUBTP_ID = 0
                           AND T.CAD_MTMD_GRUPO_ID = 1 AND T.CAD_MTMD_SUBGRUPO_ID != 16
                           AND T.MTMD_VALOR_ATUAL > 0 AND T.CAD_MTMD_FILIAL_ID = 2) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT NULL VALOR --24
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --25
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --26
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --27
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --28
                  FROM DUAL
                  UNION ALL
                  SELECT NULL VALOR --29
                  FROM DUAL
                  UNION ALL
                  SELECT NULL VALOR --30
                  FROM DUAL
                  UNION ALL
                  SELECT (SELECT NVL(SUM(T.MTMD_VALOR_ENTRADA), 0) --31
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 1 AND T.CAD_MTMD_SUBTP_ID = 1
                           AND T.CAD_MTMD_GRUPO_ID = 1
                           AND T.CAD_MTMD_FILIAL_ID = 1) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT ((SELECT NVL(SUM(T.MTMD_VALOR_SAIDA), 0) --32
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 2 AND T.CAD_MTMD_SUBTP_ID NOT IN (6)
                           AND T.CAD_MTMD_GRUPO_ID = 1
                           AND T.MTMD_VALOR_SAIDA > 0 AND T.CAD_MTMD_FILIAL_ID = 1)+
                          (SELECT NVL(SUM(T.MTMD_VALOR_SAIDA), 0)
                              FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                             WHERE T.MTMD_MOV_DATA >= dDataIni
                               AND T.MTMD_MOV_DATA <= dDataFim
                               AND T.CAD_MTMD_TPMOV_ID = 2 AND T.CAD_MTMD_SUBTP_ID IN (6)
                               AND T.CAD_MTMD_GRUPO_ID = 1
                               AND T.MTMD_VALOR_SAIDA > 0 AND T.CAD_MTMD_FILIAL_ID = 1)-
                           (SELECT NVL(SUM(T.MTMD_VALOR_ENTRADA), 0)
                              FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                             WHERE T.MTMD_MOV_DATA >= dDataIni
                               AND T.MTMD_MOV_DATA <= dDataFim
                               AND T.CAD_MTMD_TPMOV_ID = 1 AND T.CAD_MTMD_SUBTP_ID != 1
                               AND T.CAD_MTMD_GRUPO_ID = 1
                               AND T.CAD_MTMD_FILIAL_ID = 1)
                         ) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT (SELECT NVL(SUM(T.MTMD_VALOR_ATUAL), 0) --33
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 0 AND T.CAD_MTMD_SUBTP_ID = 0
                           AND T.CAD_MTMD_GRUPO_ID = 1
                           AND T.MTMD_VALOR_ATUAL > 0 AND T.CAD_MTMD_FILIAL_ID = 1) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT NULL VALOR --34
                  FROM DUAL
                  UNION ALL
                  SELECT (SELECT NVL(SUM(T.MTMD_VALOR_ENTRADA), 0) --35
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 1 AND T.CAD_MTMD_SUBTP_ID = 1
                           AND T.CAD_MTMD_GRUPO_ID = 1
                           AND T.CAD_MTMD_FILIAL_ID = 2) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT ((SELECT NVL(SUM(T.MTMD_VALOR_SAIDA), 0) --36
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 2 AND T.CAD_MTMD_SUBTP_ID NOT IN (6)
                           AND T.CAD_MTMD_GRUPO_ID = 1
                           AND T.MTMD_VALOR_SAIDA > 0 AND T.CAD_MTMD_FILIAL_ID = 2)+
                          (SELECT NVL(SUM(T.MTMD_VALOR_SAIDA), 0)
                              FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                             WHERE T.MTMD_MOV_DATA >= dDataIni
                               AND T.MTMD_MOV_DATA <= dDataFim
                               AND T.CAD_MTMD_TPMOV_ID = 2 AND T.CAD_MTMD_SUBTP_ID IN (6)
                               AND T.CAD_MTMD_GRUPO_ID = 1
                               AND T.MTMD_VALOR_SAIDA > 0 AND T.CAD_MTMD_FILIAL_ID = 2)-
                           (SELECT NVL(SUM(T.MTMD_VALOR_ENTRADA), 0)
                              FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                             WHERE T.MTMD_MOV_DATA >= dDataIni
                               AND T.MTMD_MOV_DATA <= dDataFim
                               AND T.CAD_MTMD_TPMOV_ID = 1 AND T.CAD_MTMD_SUBTP_ID != 1
                               AND T.CAD_MTMD_GRUPO_ID = 1
                               AND T.CAD_MTMD_FILIAL_ID = 2)
                         ) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT (SELECT NVL(SUM(T.MTMD_VALOR_ATUAL), 0) --37
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 0 AND T.CAD_MTMD_SUBTP_ID = 0
                           AND T.CAD_MTMD_GRUPO_ID = 1
                           AND T.MTMD_VALOR_ATUAL > 0 AND T.CAD_MTMD_FILIAL_ID = 2) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT NULL VALOR --38
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --29
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --40
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --41
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --42
                  FROM DUAL
                  UNION ALL
                  SELECT NULL VALOR --43
                  FROM DUAL
                  UNION ALL
                  SELECT (SELECT NVL(SUM(T.MTMD_VALOR_ENTRADA), 0) --44
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 1 AND T.CAD_MTMD_SUBTP_ID = 1
                           AND T.CAD_MTMD_GRUPO_ID = 61
                           AND T.CAD_MTMD_FILIAL_ID = 1) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT (SELECT NVL(SUM(T.MTMD_VALOR_ENTRADA), 0) --45
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 1 AND T.CAD_MTMD_SUBTP_ID = 1
                           AND T.CAD_MTMD_GRUPO_ID IN (6, 61)
                           AND T.CAD_MTMD_FILIAL_ID = 2) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT NULL VALOR --46
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --47
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --48
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --49
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --50
                  FROM DUAL
                  UNION ALL
                  SELECT NULL VALOR --51
                  FROM DUAL
                  UNION ALL
                  SELECT NULL VALOR --52
                  FROM DUAL
                  UNION ALL
                  SELECT (SELECT NVL(SUM(T.MTMD_VALOR_ENTRADA), 0) --53
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 1 AND T.CAD_MTMD_SUBTP_ID = 1
                           AND T.CAD_MTMD_GRUPO_ID = 6
                           AND T.CAD_MTMD_FILIAL_ID = 1) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT ((SELECT NVL(SUM(T.MTMD_VALOR_SAIDA), 0) --54
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 2 AND T.CAD_MTMD_SUBTP_ID NOT IN (6)
                           AND T.CAD_MTMD_GRUPO_ID = 6
                           AND T.MTMD_VALOR_SAIDA > 0 AND T.CAD_MTMD_FILIAL_ID = 1)+
                          (SELECT NVL(SUM(T.MTMD_VALOR_SAIDA), 0)
                              FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                             WHERE T.MTMD_MOV_DATA >= dDataIni
                               AND T.MTMD_MOV_DATA <= dDataFim
                               AND T.CAD_MTMD_TPMOV_ID = 2 AND T.CAD_MTMD_SUBTP_ID IN (6)
                               AND T.CAD_MTMD_GRUPO_ID = 6
                               AND T.MTMD_VALOR_SAIDA > 0 AND T.CAD_MTMD_FILIAL_ID = 1)-
                           (SELECT NVL(SUM(T.MTMD_VALOR_ENTRADA), 0)
                              FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                             WHERE T.MTMD_MOV_DATA >= dDataIni
                               AND T.MTMD_MOV_DATA <= dDataFim
                               AND T.CAD_MTMD_TPMOV_ID = 1 AND T.CAD_MTMD_SUBTP_ID != 1
                               AND T.CAD_MTMD_GRUPO_ID = 6
                               AND T.CAD_MTMD_FILIAL_ID = 1)
                         ) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT (SELECT NVL(SUM(T.MTMD_VALOR_ATUAL), 0) --55
                          FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T
                         WHERE T.MTMD_MOV_DATA >= dDataIni
                           AND T.MTMD_MOV_DATA <= dDataFim
                           AND T.CAD_MTMD_TPMOV_ID = 0 AND T.CAD_MTMD_SUBTP_ID = 0
                           AND T.CAD_MTMD_GRUPO_ID = 6
                           AND T.MTMD_VALOR_ATUAL > 0 AND T.CAD_MTMD_FILIAL_ID = 1) VALOR
                  FROM DUAL
                  UNION ALL
                  SELECT NULL VALOR --56
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --57
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --58
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --59
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --60
                  FROM DUAL
                  UNION ALL
                  SELECT NULL VALOR --61
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --62
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --63
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --64
                  FROM DUAL
                  UNION ALL
                  SELECT 0 VALOR --65
                  FROM DUAL
                  )
      )
      LOOP

          BEGIN
            INSERT INTO TB_REL_RFM_RESU_FAT_MTMD
            (
               REL_RMF_SEQ_ITEM,         REL_RFM_ANO_FECHAMENTO,          REL_RFM_MES_FECHAMENTO,
               REL_RMF_VL_ITEM,          SEG_USU_ID_USUARIO,              REL_RMF_DT_ULTIMA_ATUALIZACAO
            )
            VALUES
            (
               VAL.SEQUENCIA,            pREL_RFM_ANO_FECHAMENTO,         pREL_RFM_MES_FECHAMENTO,
               VAL.VL_ITEM,              pSEG_USU_ID_USUARIO,             SYSDATE
            );
         EXCEPTION
            WHEN DUP_VAL_ON_INDEX THEN
               UPDATE TB_REL_RFM_RESU_FAT_MTMD
                  SET REL_RMF_VL_ITEM               =  DECODE(VAL.VL_ITEM, 0, REL_RMF_VL_ITEM, VAL.VL_ITEM), -- Só atualizar o que tiver valor na query
                      SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
                      REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
               WHERE REL_RMF_SEQ_ITEM        = VAL.SEQUENCIA
               AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
               AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;
         END;

      END LOOP;

      IF (NVL(pPROCESSAR_RECEITA, 0) = 1) THEN --Já comita se tiver que processar receita também
         COMMIT;
      END IF;
    END IF; --FIM PROCESSAMENTO FECHA. ESTOQUE

    IF (NVL(pPROCESSAR_FECHA_ESTOQUE, 0) = 0 AND NVL(pPROCESSAR_RECEITA, 0) = 1) THEN
    
       SELECT COUNT(RFM.REL_RMF_SEQ_ITEM) INTO nCount 
         FROM TB_REL_RFM_RESU_FAT_MTMD RFM
        WHERE RFM.REL_RFM_ANO_FECHAMENTO = pREL_RFM_ANO_FECHAMENTO AND
              RFM.REL_RFM_MES_FECHAMENTO = pREL_RFM_MES_FECHAMENTO;
                 
       IF (nCount = 0) THEN
             RAISE_APPLICATION_ERROR(-20000, 'FAVOR PROCESSAR ANTES OS DADOS DO FECHAMENTO DO ESTOQUE');
       END IF;
    END IF;
    
    /*
    CODs Item Receita:
    RSP - Receita SP
    RACS - Receita ACS
    RTOT - Receita Total
    CF - Custo FUnc.
    
    Agrupamentos:
    1 - MED. QUIMIO
    2 - MED. EXCETO QUIMIO
    3 - MED. TOTAL
    4 - PROT./ORT./SINT.
    5 - MAT. EXCETO PROT./ORT./SINT.
    6 - MAT. TOTAL 
    */

    IF (NVL(pPROCESSAR_RECEITA, 0) = 1) THEN
    
      ----- INICIO MED. QUIMIO -----------------------------------------------------
      SELECT NVL(SUM(CCI.FAT_CCI_VL_FATURADO),0)
        INTO nReceitaHAC1
        FROM TB_FAT_CCI_CONTA_CONSU_ITEM CCI 
        JOIN TB_FAT_CCP_CONTA_CONS_PARC  CCP ON (CCP.FAT_CCP_ID = CCI.FAT_CCP_ID AND CCP.FAT_COC_ID = CCI.FAT_COC_ID AND 
                                                 CCP.ATD_ATE_ID = CCI.ATD_ATE_ID AND CCP.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE)
        JOIN TB_CAD_PRD_PRODUTO          PRD ON PRD.CAD_PRD_ID = CCI.CAD_PRD_ID
        WHERE CCP.FAT_CCP_MES_FAT = pREL_RFM_MES_FECHAMENTO AND       
              CCP.FAT_CCP_ANO_FAT = pREL_RFM_ANO_FECHAMENTO AND
              CCP.CAD_TPE_CD_CODIGO IN ('SP','PA') AND
              CCP.FAT_CCP_FL_FATURADA = 'S' AND
              CCP.FAT_CCP_FL_EMITIDA = 'S' AND      
              CCI.FAT_CCI_FL_STATUS = 'A' AND
              CCI.FAT_CCI_TP_DESTINO_ITEM NOT IN ('H','T') AND
              CCI.CAD_TAP_TP_ATRIBUTO IN ('MED') AND 
              NVL(PRD.CAD_CMM_CD_CARACMATMED, 0) IN (23);                             

      SELECT NVL(SUM(CCI.FAT_CCI_VL_FATURADO),0) 
        INTO nReceitaACS1
        FROM TB_FAT_CCI_CONTA_CONSU_ITEM CCI 
        JOIN TB_FAT_CCP_CONTA_CONS_PARC  CCP ON (CCP.FAT_CCP_ID = CCI.FAT_CCP_ID AND CCP.FAT_COC_ID = CCI.FAT_COC_ID AND 
                                                 CCP.ATD_ATE_ID = CCI.ATD_ATE_ID AND CCP.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE)
        JOIN TB_CAD_PRD_PRODUTO          PRD ON PRD.CAD_PRD_ID = CCI.CAD_PRD_ID
        WHERE CCP.FAT_CCP_MES_FAT = pREL_RFM_MES_FECHAMENTO AND       
              CCP.FAT_CCP_ANO_FAT = pREL_RFM_ANO_FECHAMENTO AND
              CCP.CAD_TPE_CD_CODIGO IN ('ACS') AND
              CCP.FAT_CCP_FL_FATURADA = 'S' AND
              CCP.FAT_CCP_FL_EMITIDA = 'S' AND      
              CCI.FAT_CCI_FL_STATUS = 'A' AND
              CCI.FAT_CCI_TP_DESTINO_ITEM NOT IN ('H','T') AND
              CCI.CAD_TAP_TP_ATRIBUTO IN ('MED') AND 
              NVL(PRD.CAD_CMM_CD_CARACMATMED, 0) IN (23);      
              
      SELECT NVL(SUM(CCI.FAT_CCI_VL_FATURADO),0) 
        INTO nCustoFunc1
        FROM TB_FAT_CCI_CONTA_CONSU_ITEM CCI 
        JOIN TB_FAT_CCP_CONTA_CONS_PARC  CCP ON (CCP.FAT_CCP_ID = CCI.FAT_CCP_ID AND CCP.FAT_COC_ID = CCI.FAT_COC_ID AND 
                                                 CCP.ATD_ATE_ID = CCI.ATD_ATE_ID AND CCP.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE)
        JOIN TB_CAD_PRD_PRODUTO          PRD ON PRD.CAD_PRD_ID = CCI.CAD_PRD_ID
        WHERE CCP.FAT_CCP_MES_FAT = pREL_RFM_MES_FECHAMENTO AND       
              CCP.FAT_CCP_ANO_FAT = pREL_RFM_ANO_FECHAMENTO AND
              CCP.CAD_TPE_CD_CODIGO IN ('FU','NP') AND
              CCP.FAT_CCP_FL_FATURADA = 'S' AND
              CCP.FAT_CCP_FL_EMITIDA = 'S' AND      
              CCI.FAT_CCI_FL_STATUS = 'A' AND
              CCI.FAT_CCI_TP_DESTINO_ITEM NOT IN ('H','T') AND
              CCI.CAD_TAP_TP_ATRIBUTO IN ('MED') AND 
              NVL(PRD.CAD_CMM_CD_CARACMATMED, 0) IN (23);  
      
      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  nReceitaHAC1,
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 1 AND 
                                                E.REL_RFM_COD_ITEM = 'RSP')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;
        
      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  nReceitaACS1,
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 1 AND 
                                                E.REL_RFM_COD_ITEM = 'RACS')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;


      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  nReceitaHAC1 + nReceitaACS1,
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 1 AND 
                                                E.REL_RFM_COD_ITEM = 'RTOT')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;


      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  nCustoFunc1,
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 1 AND 
                                                E.REL_RFM_COD_ITEM = 'CF')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;
      
      COMMIT;
      ----- FIM MED. QUIMIO -----------------------------------------------------
      
      ----- INICIO MED. EXCETO QUIMIO -----------------------------------------------------
      SELECT NVL(SUM(CCI.FAT_CCI_VL_FATURADO),0) 
        INTO nReceitaHAC2
        FROM TB_FAT_CCI_CONTA_CONSU_ITEM CCI 
        JOIN TB_FAT_CCP_CONTA_CONS_PARC  CCP ON (CCP.FAT_CCP_ID = CCI.FAT_CCP_ID AND CCP.FAT_COC_ID = CCI.FAT_COC_ID AND 
                                                 CCP.ATD_ATE_ID = CCI.ATD_ATE_ID AND CCP.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE)
        JOIN TB_CAD_PRD_PRODUTO          PRD ON PRD.CAD_PRD_ID = CCI.CAD_PRD_ID
        WHERE CCP.FAT_CCP_MES_FAT = pREL_RFM_MES_FECHAMENTO AND       
              CCP.FAT_CCP_ANO_FAT = pREL_RFM_ANO_FECHAMENTO AND
              CCP.CAD_TPE_CD_CODIGO IN ('SP','PA') AND
              CCP.FAT_CCP_FL_FATURADA = 'S' AND
              CCP.FAT_CCP_FL_EMITIDA = 'S' AND      
              CCI.FAT_CCI_FL_STATUS = 'A' AND
              CCI.FAT_CCI_TP_DESTINO_ITEM NOT IN ('H','T') AND
              CCI.CAD_TAP_TP_ATRIBUTO IN ('MED') AND 
              NVL(PRD.CAD_CMM_CD_CARACMATMED, 0) NOT IN (23);                             

      SELECT NVL(SUM(CCI.FAT_CCI_VL_FATURADO),0) 
        INTO nReceitaACS2
        FROM TB_FAT_CCI_CONTA_CONSU_ITEM CCI 
        JOIN TB_FAT_CCP_CONTA_CONS_PARC  CCP ON (CCP.FAT_CCP_ID = CCI.FAT_CCP_ID AND CCP.FAT_COC_ID = CCI.FAT_COC_ID AND 
                                                 CCP.ATD_ATE_ID = CCI.ATD_ATE_ID AND CCP.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE)
        JOIN TB_CAD_PRD_PRODUTO          PRD ON PRD.CAD_PRD_ID = CCI.CAD_PRD_ID
        WHERE CCP.FAT_CCP_MES_FAT = pREL_RFM_MES_FECHAMENTO AND       
              CCP.FAT_CCP_ANO_FAT = pREL_RFM_ANO_FECHAMENTO AND
              CCP.CAD_TPE_CD_CODIGO IN ('ACS') AND
              CCP.FAT_CCP_FL_FATURADA = 'S' AND
              CCP.FAT_CCP_FL_EMITIDA = 'S' AND      
              CCI.FAT_CCI_FL_STATUS = 'A' AND
              CCI.FAT_CCI_TP_DESTINO_ITEM NOT IN ('H','T') AND
              CCI.CAD_TAP_TP_ATRIBUTO IN ('MED') AND 
              NVL(PRD.CAD_CMM_CD_CARACMATMED, 0) NOT IN (23);      
              
      SELECT NVL(SUM(CCI.FAT_CCI_VL_FATURADO),0) 
        INTO nCustoFunc2
        FROM TB_FAT_CCI_CONTA_CONSU_ITEM CCI 
        JOIN TB_FAT_CCP_CONTA_CONS_PARC  CCP ON (CCP.FAT_CCP_ID = CCI.FAT_CCP_ID AND CCP.FAT_COC_ID = CCI.FAT_COC_ID AND 
                                                 CCP.ATD_ATE_ID = CCI.ATD_ATE_ID AND CCP.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE)
        JOIN TB_CAD_PRD_PRODUTO          PRD ON PRD.CAD_PRD_ID = CCI.CAD_PRD_ID
        WHERE CCP.FAT_CCP_MES_FAT = pREL_RFM_MES_FECHAMENTO AND       
              CCP.FAT_CCP_ANO_FAT = pREL_RFM_ANO_FECHAMENTO AND
              CCP.CAD_TPE_CD_CODIGO IN ('FU','NP') AND
              CCP.FAT_CCP_FL_FATURADA = 'S' AND
              CCP.FAT_CCP_FL_EMITIDA = 'S' AND      
              CCI.FAT_CCI_FL_STATUS = 'A' AND
              CCI.FAT_CCI_TP_DESTINO_ITEM NOT IN ('H','T') AND
              CCI.CAD_TAP_TP_ATRIBUTO IN ('MED') AND 
              NVL(PRD.CAD_CMM_CD_CARACMATMED, 0) NOT IN (23);  
      
      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  nReceitaHAC2,
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 2 AND 
                                                E.REL_RFM_COD_ITEM = 'RSP')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;
        
      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  nReceitaACS2,
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 2 AND 
                                                E.REL_RFM_COD_ITEM = 'RACS')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;


      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  nReceitaHAC2 + nReceitaACS2,
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 2 AND 
                                                E.REL_RFM_COD_ITEM = 'RTOT')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;


      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  nCustoFunc2,
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 2 AND 
                                                E.REL_RFM_COD_ITEM = 'CF')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;
      
      COMMIT;
      ----- FIM MED. EXCETO QUIMIO -----------------------------------------------------
      
      ----- INICIO MED. TOTAL -----------------------------------------------------
      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  nReceitaHAC2 + nReceitaHAC1,
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 3 AND
                                                E.REL_RFM_COD_ITEM = 'RSP')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;
        
      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  nReceitaACS2 + nReceitaACS1,
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 3 AND 
                                                E.REL_RFM_COD_ITEM = 'RACS')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;


      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  (nReceitaHAC2 + nReceitaACS2) + (nReceitaHAC1 + nReceitaACS1),
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 3 AND 
                                                E.REL_RFM_COD_ITEM = 'RTOT')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;


      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  nCustoFunc2 + nCustoFunc1,
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 3 AND 
                                                E.REL_RFM_COD_ITEM = 'CF')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;
      
      COMMIT;
      ----- FIM MED. TOTAL -----------------------------------------------------
      
      ----- INICIO PROT./ORT./SINT. -----------------------------------------------------
      SELECT NVL(SUM(CCI.FAT_CCI_VL_FATURADO),0) 
        INTO nReceitaHAC1
        FROM TB_FAT_CCI_CONTA_CONSU_ITEM CCI 
        JOIN TB_FAT_CCP_CONTA_CONS_PARC  CCP ON (CCP.FAT_CCP_ID = CCI.FAT_CCP_ID AND CCP.FAT_COC_ID = CCI.FAT_COC_ID AND 
                                                 CCP.ATD_ATE_ID = CCI.ATD_ATE_ID AND CCP.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE)
        JOIN TB_CAD_PRD_PRODUTO          PRD ON PRD.CAD_PRD_ID = CCI.CAD_PRD_ID
        WHERE CCP.FAT_CCP_MES_FAT = pREL_RFM_MES_FECHAMENTO AND       
              CCP.FAT_CCP_ANO_FAT = pREL_RFM_ANO_FECHAMENTO AND
              CCP.CAD_TPE_CD_CODIGO IN ('SP','PA') AND
              CCP.FAT_CCP_FL_FATURADA = 'S' AND
              CCP.FAT_CCP_FL_EMITIDA = 'S' AND      
              CCI.FAT_CCI_FL_STATUS = 'A' AND
              CCI.FAT_CCI_TP_DESTINO_ITEM NOT IN ('H','T') AND
              CCI.CAD_TAP_TP_ATRIBUTO IN ('MAT','MM','M2') AND  
              NVL(PRD.CAD_CMM_CD_CARACMATMED, 0) IN (20, 21, 22);                             

      SELECT NVL(SUM(CCI.FAT_CCI_VL_FATURADO),0) 
        INTO nReceitaACS1
        FROM TB_FAT_CCI_CONTA_CONSU_ITEM CCI 
        JOIN TB_FAT_CCP_CONTA_CONS_PARC  CCP ON (CCP.FAT_CCP_ID = CCI.FAT_CCP_ID AND CCP.FAT_COC_ID = CCI.FAT_COC_ID AND 
                                                 CCP.ATD_ATE_ID = CCI.ATD_ATE_ID AND CCP.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE)
        JOIN TB_CAD_PRD_PRODUTO          PRD ON PRD.CAD_PRD_ID = CCI.CAD_PRD_ID
        WHERE CCP.FAT_CCP_MES_FAT = pREL_RFM_MES_FECHAMENTO AND       
              CCP.FAT_CCP_ANO_FAT = pREL_RFM_ANO_FECHAMENTO AND
              CCP.CAD_TPE_CD_CODIGO IN ('ACS') AND
              CCP.FAT_CCP_FL_FATURADA = 'S' AND
              CCP.FAT_CCP_FL_EMITIDA = 'S' AND      
              CCI.FAT_CCI_FL_STATUS = 'A' AND
              CCI.FAT_CCI_TP_DESTINO_ITEM NOT IN ('H','T') AND
              CCI.CAD_TAP_TP_ATRIBUTO IN ('MAT','MM','M2') AND  
              NVL(PRD.CAD_CMM_CD_CARACMATMED, 0) IN (20, 21, 22);      
              
      SELECT NVL(SUM(CCI.FAT_CCI_VL_FATURADO),0) 
        INTO nCustoFunc1
        FROM TB_FAT_CCI_CONTA_CONSU_ITEM CCI 
        JOIN TB_FAT_CCP_CONTA_CONS_PARC  CCP ON (CCP.FAT_CCP_ID = CCI.FAT_CCP_ID AND CCP.FAT_COC_ID = CCI.FAT_COC_ID AND 
                                                 CCP.ATD_ATE_ID = CCI.ATD_ATE_ID AND CCP.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE)
        JOIN TB_CAD_PRD_PRODUTO          PRD ON PRD.CAD_PRD_ID = CCI.CAD_PRD_ID
        WHERE CCP.FAT_CCP_MES_FAT = pREL_RFM_MES_FECHAMENTO AND       
              CCP.FAT_CCP_ANO_FAT = pREL_RFM_ANO_FECHAMENTO AND
              CCP.CAD_TPE_CD_CODIGO IN ('FU','NP') AND
              CCP.FAT_CCP_FL_FATURADA = 'S' AND
              CCP.FAT_CCP_FL_EMITIDA = 'S' AND      
              CCI.FAT_CCI_FL_STATUS = 'A' AND
              CCI.FAT_CCI_TP_DESTINO_ITEM NOT IN ('H','T') AND
              CCI.CAD_TAP_TP_ATRIBUTO IN ('MAT','MM','M2') AND  
              NVL(PRD.CAD_CMM_CD_CARACMATMED, 0) IN (20, 21, 22);  
      
      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  nReceitaHAC1,
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 4 AND 
                                                E.REL_RFM_COD_ITEM = 'RSP')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;
        
      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  nReceitaACS1,
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 4 AND 
                                                E.REL_RFM_COD_ITEM = 'RACS')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;


      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  nReceitaHAC1 + nReceitaACS1,
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 4 AND 
                                                E.REL_RFM_COD_ITEM = 'RTOT')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;


      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  nCustoFunc1,
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 4 AND 
                                                E.REL_RFM_COD_ITEM = 'CF')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;
      
      COMMIT;
      ----- FIM PROT./ORT./SINT. -----------------------------------------------------
      
      ----- INICIO MAT. EXCETO PROT./ORT./SINT. -----------------------------------------------------
      SELECT NVL(SUM(CCI.FAT_CCI_VL_FATURADO),0) 
        INTO nReceitaHAC2
        FROM TB_FAT_CCI_CONTA_CONSU_ITEM CCI 
        JOIN TB_FAT_CCP_CONTA_CONS_PARC  CCP ON (CCP.FAT_CCP_ID = CCI.FAT_CCP_ID AND CCP.FAT_COC_ID = CCI.FAT_COC_ID AND 
                                                 CCP.ATD_ATE_ID = CCI.ATD_ATE_ID AND CCP.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE)
        JOIN TB_CAD_PRD_PRODUTO          PRD ON PRD.CAD_PRD_ID = CCI.CAD_PRD_ID
        WHERE CCP.FAT_CCP_MES_FAT = pREL_RFM_MES_FECHAMENTO AND       
              CCP.FAT_CCP_ANO_FAT = pREL_RFM_ANO_FECHAMENTO AND
              CCP.CAD_TPE_CD_CODIGO IN ('SP','PA') AND
              CCP.FAT_CCP_FL_FATURADA = 'S' AND
              CCP.FAT_CCP_FL_EMITIDA = 'S' AND      
              CCI.FAT_CCI_FL_STATUS = 'A' AND
              CCI.FAT_CCI_TP_DESTINO_ITEM NOT IN ('H','T') AND
              CCI.CAD_TAP_TP_ATRIBUTO IN ('MAT','MM','M2') AND 
              NVL(PRD.CAD_CMM_CD_CARACMATMED, 0) NOT IN (20, 21, 22);                             

      SELECT NVL(SUM(CCI.FAT_CCI_VL_FATURADO),0) 
        INTO nReceitaACS2
        FROM TB_FAT_CCI_CONTA_CONSU_ITEM CCI 
        JOIN TB_FAT_CCP_CONTA_CONS_PARC  CCP ON (CCP.FAT_CCP_ID = CCI.FAT_CCP_ID AND CCP.FAT_COC_ID = CCI.FAT_COC_ID AND 
                                                 CCP.ATD_ATE_ID = CCI.ATD_ATE_ID AND CCP.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE)
        JOIN TB_CAD_PRD_PRODUTO          PRD ON PRD.CAD_PRD_ID = CCI.CAD_PRD_ID
        WHERE CCP.FAT_CCP_MES_FAT = pREL_RFM_MES_FECHAMENTO AND       
              CCP.FAT_CCP_ANO_FAT = pREL_RFM_ANO_FECHAMENTO AND
              CCP.CAD_TPE_CD_CODIGO IN ('ACS') AND
              CCP.FAT_CCP_FL_FATURADA = 'S' AND
              CCP.FAT_CCP_FL_EMITIDA = 'S' AND      
              CCI.FAT_CCI_FL_STATUS = 'A' AND
              CCI.FAT_CCI_TP_DESTINO_ITEM NOT IN ('H','T') AND
              CCI.CAD_TAP_TP_ATRIBUTO IN ('MAT','MM','M2') AND 
              NVL(PRD.CAD_CMM_CD_CARACMATMED, 0) NOT IN (20, 21, 22);      
              
      SELECT NVL(SUM(CCI.FAT_CCI_VL_FATURADO),0) 
        INTO nCustoFunc2
        FROM TB_FAT_CCI_CONTA_CONSU_ITEM CCI 
        JOIN TB_FAT_CCP_CONTA_CONS_PARC  CCP ON (CCP.FAT_CCP_ID = CCI.FAT_CCP_ID AND CCP.FAT_COC_ID = CCI.FAT_COC_ID AND 
                                                 CCP.ATD_ATE_ID = CCI.ATD_ATE_ID AND CCP.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE)
        JOIN TB_CAD_PRD_PRODUTO          PRD ON PRD.CAD_PRD_ID = CCI.CAD_PRD_ID
        WHERE CCP.FAT_CCP_MES_FAT = pREL_RFM_MES_FECHAMENTO AND       
              CCP.FAT_CCP_ANO_FAT = pREL_RFM_ANO_FECHAMENTO AND
              CCP.CAD_TPE_CD_CODIGO IN ('FU','NP') AND
              CCP.FAT_CCP_FL_FATURADA = 'S' AND
              CCP.FAT_CCP_FL_EMITIDA = 'S' AND      
              CCI.FAT_CCI_FL_STATUS = 'A' AND
              CCI.FAT_CCI_TP_DESTINO_ITEM NOT IN ('H','T') AND
              CCI.CAD_TAP_TP_ATRIBUTO IN ('MAT','MM','M2') AND 
              NVL(PRD.CAD_CMM_CD_CARACMATMED, 0) NOT IN (20, 21, 22);  
      
      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  nReceitaHAC2,
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 5 AND 
                                                E.REL_RFM_COD_ITEM = 'RSP')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;
        
      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  nReceitaACS2,
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 5 AND 
                                                E.REL_RFM_COD_ITEM = 'RACS')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;


      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  nReceitaHAC2 + nReceitaACS2,
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 5 AND 
                                                E.REL_RFM_COD_ITEM = 'RTOT')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;


      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  nCustoFunc2,
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 5 AND 
                                                E.REL_RFM_COD_ITEM = 'CF')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;
      
      COMMIT;
      ----- FIM MAT. EXCETO PROT./ORT./SINT. -----------------------------------------------------
      
      ----- INICIO MAT. TOTAL -----------------------------------------------------
      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  nReceitaHAC2 + nReceitaHAC1,
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 6 AND
                                                E.REL_RFM_COD_ITEM = 'RSP')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;
        
      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  nReceitaACS2 + nReceitaACS1,
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 6 AND 
                                                E.REL_RFM_COD_ITEM = 'RACS')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;


      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  (nReceitaHAC2 + nReceitaACS2) + (nReceitaHAC1 + nReceitaACS1),
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 6 AND 
                                                E.REL_RFM_COD_ITEM = 'RTOT')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;


      UPDATE TB_REL_RFM_RESU_FAT_MTMD
          SET REL_RMF_VL_ITEM               =  nCustoFunc2 + nCustoFunc1,
              SEG_USU_ID_USUARIO            =  pSEG_USU_ID_USUARIO,
              REL_RMF_DT_ULTIMA_ATUALIZACAO =  SYSDATE
        WHERE REL_RMF_SEQ_ITEM        = (SELECT E.REL_RMF_SEQ_ITEM 
                                           FROM TB_REL_RFM_MTMD_ESTRUTURA E
                                          WHERE E.REL_RFM_AGRUPAMENTO_ID = 6 AND 
                                                E.REL_RFM_COD_ITEM = 'CF')
        AND   REL_RFM_ANO_FECHAMENTO  = pREL_RFM_ANO_FECHAMENTO
        AND   REL_RFM_MES_FECHAMENTO  = pREL_RFM_MES_FECHAMENTO;
      
      COMMIT;
      ----- FIM MAT. TOTAL -----------------------------------------------------

    END IF;  

END PRC_REL_RFM_RESU_FAT_MTMD_G;

--delete tb_rel_rfm_mtmd_estrutura t where t.rel_rmf_seq_item in (15, 30, 45, 54, 65)
--delete tb_rel_rfm_resu_fat_mtmd r where r.rel_rmf_seq_item in (15, 30, 45, 54, 65)

/*
declare
cont int := 1;
begin

for x in
(
select r.rel_rfm_ano_fechamento, r.rel_rfm_mes_fechamento, r.rel_rmf_seq_item
  from tb_rel_rfm_resu_fat_mtmd r --where r.rel_rfm_ano_fechamento = 2012 --and r.rel_rfm_mes_fechamento in (6,7)
  order by r.rel_rfm_ano_fechamento, r.rel_rfm_mes_fechamento, r.rel_rmf_seq_item
)
loop    

    --if (cont = 66) then
    if (x.rel_rmf_seq_item = 1) then
        cont := 1;
    end if;
    
    update tb_rel_rfm_resu_fat_mtmd set rel_rmf_seq_item = cont
     where rel_rmf_seq_item = x.rel_rmf_seq_item and 
           rel_rfm_ano_fechamento = x.rel_rfm_ano_fechamento and 
           rel_rfm_mes_fechamento = x.rel_rfm_mes_fechamento;    
    
    cont := cont + 1;
end loop;

end;

begin

for x in
(
select rownum, r.rel_rmf_seq_item
  from tb_rel_rfm_mtmd_estrutura r 
  order by rel_rmf_seq_item
)
loop    
    
    update tb_rel_rfm_mtmd_estrutura set rel_rmf_seq_item = x.rownum
     where rel_rmf_seq_item = x.rel_rmf_seq_item;    
     
end loop;

end;
*/
