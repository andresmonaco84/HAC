CREATE OR REPLACE PROCEDURE PRC_CTS_RES_CARGA_DESPESA_RM
------------------  SELECT_CARGA_DESPESA_RM_COM_CODCFO
(
    P_MESFAT  IN TB_CTS_MOV_MOVIMENTACAO_RM.CTS_MOV_RM_MES%TYPE,
    P_ANOFAT  IN TB_CTS_MOV_MOVIMENTACAO_RM.CTS_MOV_RM_ANO%TYPE,
    P_USUARIO IN TB_CTS_MOV_MOVIMENTACAO_RM.SEG_USU_ID_ALTERACAO%TYPE
)
IS
/********************************************************************
*    alterado para o mes de maio/2014 no incluir codcfo  AND NVL(LAN.INTEGRACHAVE,0) =  TMOV.IDMOV(+)
*    acrescentado  para o mes 12/2014   para ler FLAN quando integrachave inicia com B
*
*
*    PROCEDURE: PRC_CTS_RES_CARGA_DESPESA_RM
*    DATA:13/08/2013          POR: Neide
*
*********************************************************************/
BEGIN


DECLARE
a char(1);

BEGIN

select 'a' into a from dual;

            
BEGIN
  -- APAGA REGISTROS DO PERiODO INFORMADO;
  DELETE TB_CTS_MOV_MOVIMENTACAO_RM M
   WHERE M.CTS_MOV_RM_ANO = P_ANOFAT
     AND M.CTS_MOV_RM_MES = P_MESFAT;
--     AND M.CTS_MOV_RM_ANO = 3000;  ---- LINHA PARA DESENV
FOR MOV IN (
SELECT SALDO.ANO,
       SALDO.MES,
       SALDO.ID_CONTA,
       SALDO.ID_UNIDADE,
       SALDO.ID_CCUSTO,
       SUM(SALDO.VALOR) TOTAL,
       SALDO.CODCFO
  FROM (SELECT TO_CHAR(LAN.DATA, 'YYYY') ANO,
               TO_CHAR(LAN.DATA, 'MM') MES,
               CCR.CAD_CCR_ID ID_CONTA,
               UNI.CAD_UNI_ID_UNIDADE ID_UNIDADE,
               CC.CAD_CEC_ID_CCUSTO ID_CCUSTO,
               SUM(VALOR) * -1 VALOR,
               NULL CODCFO
          FROM RM.CPARTIDA@RMDB             LAN,
               TB_CAD_CCR_CCONTA_RM    CCR,
               RM.GFILIAL@RMDB              F,
---               UNIDADE_HOSPITALAR      U,
               TB_CAD_UNI_UNIDADE      UNI,
               TB_CAD_CEC_CENTRO_CUSTO CC ,
               RM.CHISTP@RMDB   CHISTP
           WHERE CCR.CAD_CCR_CD_COLIGADA = LAN.CODCOLIGADA
           AND CCR.CAD_CCR_CD_CONTA = LAN.DEBITO
           AND LAN.CODCOLIGADA = F.CODCOLIGADA
           AND LAN.CODFILIAL = F.CODFILIAL
---           AND F.CODFILIAL = DECODE(U.CODUNIHOS, 6, NULL, U.CODFILIAL)
---           AND DECODE(U.CODUNIHOS, 6, 2, U.CODUNIHOS) = UNI.CAD_UNI_CD_UNID_HOSPITALAR
           AND F.CODFILIAL =   DECODE(uni.cad_uni_id_unidade , 248 , NULL, uni.codfilial )
           AND DECODE(uni.cad_uni_id_unidade, 248, 244, uni.cad_uni_id_unidade) = UNI.CAD_UNI_id_unidade
           AND LAN.CODCCUSTO = CC.CAD_CEC_CD_CCUSTO(+)
           AND LAN.CODCOLIGADA = 1
           AND TO_CHAR(LAN.DATA, 'YYYY') = P_ANOFAT  AND LAN.CODLOTE = 0
           AND TO_CHAR(LAN.DATA, 'MM') = P_MESFAT
           ---
           and lan.codcoligada = chistp.codcoligada(+)
           and lan.codhistp = chistp.codhistp(+)
           and nvl(chistp.histfecha,0)  = 0
           ---
           AND (LAN.DEBITO LIKE '3%' OR LAN.DEBITO LIKE '4%')
           AND LAN.DEBITO NOT IN ('4.1.01.001.0001.001', '4.1.01.001.0001.002', '4.1.01.001.0001.003', '4.1.01.001.0001.004')
         GROUP BY TO_CHAR(LAN.DATA, 'YYYY'),
                  TO_CHAR(LAN.DATA, 'MM'),
                  CCR.CAD_CCR_ID,
                  UNI.CAD_UNI_ID_UNIDADE,
                  CC.CAD_CEC_ID_CCUSTO
        UNION
        SELECT TO_CHAR(LAN.DATA, 'YYYY') ANO,
               TO_CHAR(LAN.DATA, 'MM') MES,
               CCR.CAD_CCR_ID ID_CONTA,
               UNI.CAD_UNI_ID_UNIDADE ID_UNIDADE,
               CC.CAD_CEC_ID_CCUSTO ID_CCUSTO,
               SUM(VALOR) VALOR,
               NULL CODCFO
          FROM RM.CPARTIDA@RMDB             LAN,
               TB_CAD_CCR_CCONTA_RM    CCR,
               RM.GFILIAL@RMDB              F,
---               UNIDADE_HOSPITALAR      U,
               TB_CAD_UNI_UNIDADE      UNI,
               TB_CAD_CEC_CENTRO_CUSTO CC ,
               RM.chistp@RMDB chistp
         WHERE CCR.CAD_CCR_CD_COLIGADA = LAN.CODCOLIGADA
           AND CCR.CAD_CCR_CD_CONTA = LAN.CREDITO
           AND LAN.CODCOLIGADA = F.CODCOLIGADA
           AND LAN.CODFILIAL = F.CODFILIAL
---           AND F.CODFILIAL = DECODE(U.CODUNIHOS, 6, NULL, U.CODFILIAL)
---           AND DECODE(U.CODUNIHOS, 6, 2, U.CODUNIHOS) = UNI.CAD_UNI_CD_UNID_HOSPITALAR
           AND F.CODFILIAL =   DECODE(uni.cad_uni_id_unidade , 248 , NULL, uni.codfilial )
           AND DECODE(uni.cad_uni_id_unidade, 248, 244, uni.cad_uni_id_unidade) = UNI.CAD_UNI_id_unidade
           AND LAN.CODCCUSTO = CC.CAD_CEC_CD_CCUSTO(+)
           AND LAN.CODCOLIGADA = 1
           AND TO_CHAR(LAN.DATA, 'YYYY') = P_ANOFAT AND LAN.CODLOTE = 0
           AND TO_CHAR(LAN.DATA, 'MM') = P_MESFAT
           ---
           and lan.codcoligada = chistp.codcoligada(+)
           and lan.codhistp = chistp.codhistp(+)
           and nvl(chistp.histfecha,0)  = 0
           ---
           AND (LAN.CREDITO LIKE '3%' OR LAN.CREDITO LIKE '4%')
           AND LAN.CREDITO NOT IN ('4.1.01.001.0001.001', '4.1.01.001.0001.002', '4.1.01.001.0001.003', '4.1.01.001.0001.004')
         GROUP BY TO_CHAR(LAN.DATA, 'YYYY'),
                  TO_CHAR(LAN.DATA, 'MM'),
                  CCR.CAD_CCR_ID,
                  UNI.CAD_UNI_ID_UNIDADE,
                  CC.CAD_CEC_ID_CCUSTO
   -----
  ------
   -----
        -- INCLUIR CODCFO PARA HM, TAXAS E SERVICOS TECNICOS;
        UNION ALL
        SELECT TO_CHAR(LAN.DATA, 'YYYY') ANO,
               TO_CHAR(LAN.DATA, 'MM') MES,
               CCR.CAD_CCR_ID ID_CONTA,
               UNI.CAD_UNI_ID_UNIDADE ID_UNIDADE,
               CC.CAD_CEC_ID_CCUSTO ID_CCUSTO,
               SUM(VALOR) * -1 VALOR,
               TMOV.CODCFO
          FROM RM.CPARTIDA@RMDB             LAN,
               TB_CAD_CCR_CCONTA_RM    CCR,
               RM.GFILIAL@RMDB              F,
---               UNIDADE_HOSPITALAR      U,
               TB_CAD_UNI_UNIDADE      UNI,
               TB_CAD_CEC_CENTRO_CUSTO CC,
               RM.TMOV@RMDB                 TMOV ,
               RM.chistp@RMDB chistp
         WHERE CCR.CAD_CCR_CD_COLIGADA = LAN.CODCOLIGADA
           AND CCR.CAD_CCR_CD_CONTA = LAN.DEBITO
           AND LAN.CODCOLIGADA = F.CODCOLIGADA
           AND LAN.CODFILIAL = F.CODFILIAL
---           AND F.CODFILIAL = DECODE(U.CODUNIHOS, 6, NULL, U.CODFILIAL)
---           AND DECODE(U.CODUNIHOS, 6, 2, U.CODUNIHOS) = UNI.CAD_UNI_CD_UNID_HOSPITALAR
           AND F.CODFILIAL =   DECODE(uni.cad_uni_id_unidade , 248 , NULL, uni.codfilial )
           AND DECODE(uni.cad_uni_id_unidade, 248, 244, uni.cad_uni_id_unidade) = UNI.CAD_UNI_id_unidade
           AND LAN.CODCCUSTO = CC.CAD_CEC_CD_CCUSTO(+)
           AND LAN.CODCOLIGADA = 1
           AND TO_CHAR(LAN.DATA, 'YYYY') = P_ANOFAT  AND LAN.CODLOTE = 0
           AND TO_CHAR(LAN.DATA, 'MM') = P_MESFAT
           ---
           and lan.codcoligada = chistp.codcoligada(+)
           and lan.codhistp = chistp.codhistp(+)
           and nvl(chistp.histfecha,0)  = 0
           ---
           AND (LAN.DEBITO LIKE '3%' OR LAN.DEBITO LIKE '4%')
           AND DEBITO IN ('4.1.01.001.0001.001', '4.1.01.001.0001.002', '4.1.01.001.0001.003', '4.1.01.001.0001.004')
           AND NVL(LAN.INTEGRACHAVE,0) =  TMOV.IDMOV(+)
   AND SUBSTR(NVL(LAN.INTEGRACHAVE,0),1,1) IN ( '0' ,'1' , '2', '3', '4', '5','6','7','8','9' )
         GROUP BY TO_CHAR(LAN.DATA, 'YYYY'),
                  TO_CHAR(LAN.DATA, 'MM'),
                  CCR.CAD_CCR_ID,
                  UNI.CAD_UNI_ID_UNIDADE,
                  CC.CAD_CEC_ID_CCUSTO,
                  TMOV.CODCFO
  UNION ALL
   -------- acrescentado para mes 12/2014  integrachave com letra B  veio da tabela FLAN  -------------
  SELECT   TO_CHAR(LAN.DATA, 'YYYY') ANO,
               TO_CHAR(LAN.DATA, 'MM') MES,
               CCR.CAD_CCR_ID ID_CONTA,
               UNI.CAD_UNI_ID_UNIDADE ID_UNIDADE,
               CC.CAD_CEC_ID_CCUSTO ID_CCUSTO,
               SUM(VALOR) * -1 VALOR,
               FLAN.CODCFO
          FROM RM.CPARTIDA@RMDB             LAN,
               TB_CAD_CCR_CCONTA_RM    CCR,
               RM.GFILIAL@RMDB              F,
               TB_CAD_UNI_UNIDADE      UNI,
               TB_CAD_CEC_CENTRO_CUSTO CC,
               RM.FLAN@RMDB                 FLAN ,
               RM.chistp@RMDB chistp
         WHERE CCR.CAD_CCR_CD_COLIGADA = LAN.CODCOLIGADA
           AND CCR.CAD_CCR_CD_CONTA = LAN.DEBITO
           AND LAN.CODCOLIGADA = F.CODCOLIGADA
           AND LAN.CODFILIAL = F.CODFILIAL
           AND F.CODFILIAL =   DECODE(uni.cad_uni_id_unidade , 248 , NULL, uni.codfilial )
           AND DECODE(uni.cad_uni_id_unidade, 248, 244, uni.cad_uni_id_unidade) = UNI.CAD_UNI_id_unidade
           AND LAN.CODCCUSTO = CC.CAD_CEC_CD_CCUSTO(+)
           AND LAN.CODCOLIGADA = 1
           AND TO_CHAR(LAN.DATA, 'YYYY') = P_ANOFAT  AND LAN.CODLOTE = 0
           AND TO_CHAR(LAN.DATA, 'MM') = P_MESFAT
           and lan.codcoligada = chistp.codcoligada(+)
           and lan.codhistp = chistp.codhistp(+)
           and nvl(chistp.histfecha,0)  = 0
           AND (LAN.DEBITO LIKE '3%' OR LAN.DEBITO LIKE '4%')
           AND DEBITO IN ( '4.1.01.001.0001.001',
                           '4.1.01.001.0001.002',
                           '4.1.01.001.0001.003',
                           '4.1.01.001.0001.004')
           AND LAN.INTEGRACHAVE = 'B'||FLAN.IDLAN(+)
AND SUBSTR(NVL(LAN.INTEGRACHAVE,0),1,1)  = 'B'
         GROUP BY TO_CHAR(LAN.DATA, 'YYYY'),
                  TO_CHAR(LAN.DATA, 'MM'),
                  CCR.CAD_CCR_ID,
                  UNI.CAD_UNI_ID_UNIDADE,
                  CC.CAD_CEC_ID_CCUSTO,
                  FLAN.CODCFO
        UNION
        SELECT TO_CHAR(LAN.DATA, 'YYYY') ANO,
               TO_CHAR(LAN.DATA, 'MM') MES,
               CCR.CAD_CCR_ID ID_CONTA,
               UNI.CAD_UNI_ID_UNIDADE ID_UNIDADE,
               CC.CAD_CEC_ID_CCUSTO ID_CCUSTO,
               SUM(VALOR) VALOR,
               TMOV.CODCFO
          FROM RM.CPARTIDA@RMDB             LAN,
               TB_CAD_CCR_CCONTA_RM    CCR,
               RM.GFILIAL@RMDB              F,
----               UNIDADE_HOSPITALAR      U,
               TB_CAD_UNI_UNIDADE      UNI,
               TB_CAD_CEC_CENTRO_CUSTO CC,
               RM.TMOV@RMDB                 TMOV ,
               RM.chistp@RMDB chistp
         WHERE CCR.CAD_CCR_CD_COLIGADA = LAN.CODCOLIGADA
           AND CCR.CAD_CCR_CD_CONTA = LAN.CREDITO
           AND LAN.CODCOLIGADA = F.CODCOLIGADA
           AND LAN.CODFILIAL = F.CODFILIAL
----           AND F.CODFILIAL = DECODE(U.CODUNIHOS, 6, NULL, U.CODFILIAL)
----           AND DECODE(U.CODUNIHOS, 6, 2, U.CODUNIHOS) = UNI.CAD_UNI_CD_UNID_HOSPITALAR
           AND F.CODFILIAL =   DECODE(uni.cad_uni_id_unidade , 248 , NULL, uni.codfilial )
           AND DECODE(uni.cad_uni_id_unidade, 248, 244, uni.cad_uni_id_unidade) = UNI.CAD_UNI_id_unidade
           AND LAN.CODCCUSTO = CC.CAD_CEC_CD_CCUSTO(+)
           AND LAN.CODCOLIGADA = 1
           AND TO_CHAR(LAN.DATA, 'YYYY') = P_ANOFAT
           AND TO_CHAR(LAN.DATA, 'MM') = P_MESFAT    AND LAN.CODLOTE = 0
           ---
           and lan.codcoligada = chistp.codcoligada(+)
           and lan.codhistp = chistp.codhistp(+)
           and nvl(chistp.histfecha,0)  = 0
           ---
           AND (LAN.CREDITO LIKE '3%' OR LAN.CREDITO LIKE '4%')
           AND LAN.CREDITO IN ('4.1.01.001.0001.001', '4.1.01.001.0001.002', '4.1.01.001.0001.003', '4.1.01.001.0001.004')
           AND NVL(LAN.INTEGRACHAVE,0) =  TMOV.IDMOV(+)
         GROUP BY TO_CHAR(LAN.DATA, 'YYYY'),
                  TO_CHAR(LAN.DATA, 'MM'),
                  CCR.CAD_CCR_ID,
                  UNI.CAD_UNI_ID_UNIDADE,
                  CC.CAD_CEC_ID_CCUSTO,
                  TMOV.CODCFO) SALDO
GROUP BY SALDO.ANO,
          SALDO.MES,
          SALDO.ID_CONTA,
          SALDO.ID_UNIDADE,
          SALDO.ID_CCUSTO,
          SALDO.CODCFO  )     LOOP
    INSERT INTO TB_CTS_MOV_MOVIMENTACAO_RM
      (CTS_MOV_RM_ID,
       CTS_MOV_RM_ANO,
       CTS_MOV_RM_MES,
       CAD_CCR_ID,
       CAD_UNI_ID_UNIDADE,
       CAD_CEC_ID_CCUSTO,
       CTS_MOV_RM_VL_SALDO,
       SEG_USU_ID_INCLUSAO,
       CTS_MOV_RM_DT_INCLUSAO,
       SEG_USU_ID_ALTERACAO,
       CTS_MOV_RM_DT_ALTERACAO,
       CODCFO )
    VALUES
      (SEQ_CTS_MOV_RM_01.NEXTVAL,
       MOV.ANO,
       MOV.MES,
       MOV.ID_CONTA,
       MOV.ID_UNIDADE,
       MOV.ID_CCUSTO,
       MOV.TOTAL,
       P_USUARIO,
       SYSDATE,
       P_USUARIO,
       SYSDATE,
       MOV.CODCFO);
  END LOOP;
  COMMIT;
END;
----
---
END;
END PRC_CTS_RES_CARGA_DESPESA_RM;