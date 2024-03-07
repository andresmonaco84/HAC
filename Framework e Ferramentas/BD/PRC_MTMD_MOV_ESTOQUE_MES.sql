CREATE OR REPLACE PROCEDURE SGS.PRC_MTMD_MOV_ESTOQUE_MES
(
pDataDe  IN DATE default null,
pDataAte IN DATE default null
) IS
vDataDe  DATE := pDataDe;
vDataAte DATE := pDataAte;
BEGIN
  IF (pDataDe IS NULL OR pDataAte IS NULL) THEN
     vDataDe  := TO_DATE('01/' || TO_CHAR(sysdate, 'MM/yyyy'), 'dd/MM/yyyy');
     vDataAte := TO_DATE(TO_CHAR(sysdate-1, 'dd/MM/yyyy'), 'dd/MM/yyyy');
  END IF;
  DELETE SGS.TB_MTMD_MOV_ESTOQUE_SAI; --Tabela Temporaria
  INSERT INTO SGS.TB_MTMD_MOV_ESTOQUE_SAI
  SELECT MOV.MTMD_MOV_ID,
         MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO,
         MOV.CAD_UNI_ID_UNIDADE,
         NVL(SETOR.CAD_SET_CE_SETOR_PAI, MOV.CAD_SET_ID) CAD_SET_ID,
         MOV.MTMD_REQ_ID,
         MOV.MTMD_LOTEST_ID,
         MOV.CAD_MTMD_ID,
         MOV.CAD_MTMD_TPMOV_ID,
         MOV.CAD_MTMD_SUBTP_ID,
         MOV.MTMD_MOV_DATA,
         MOV.MTMD_MOV_QTDE,
         MOV.MTMD_MOV_FL_FINALIZADO,
         MOV.ATD_ATE_ID,
         MOV.ATD_ATE_TP_PACIENTE,
         MOV.CAD_MTMD_FILIAL_ID,
         MOV.SEG_USU_ID_USUARIO,
         MOV.MTMD_MOV_FL_FATURADO,
         MOV.MTMD_ID_USUARIO_ESTORNO,
         MOV.MTMD_MOV_ID_REF,
         MOV.MTMD_MOV_ESTOQUE_ATUAL,
         MOV.MTMD_MOV_FL_ESTORNO,
         MOV.MTMD_MOV_QTDE_FRACIONADA,
         MOV.MTMD_TP_FRACAO_ID,
         MOV.MTMD_QTD_CONVERTIDA,
         MOV.MTMD_LOCAL_ESTOQUE_CONSUMO,
         MOV.MTMD_UNIDADE_ESTOQUE_CONSUMO,
         MOV.MTMD_SETOR_ESTOQUE_CONSUMO,
         MOV.MTMD_MOV_HORA_FATURAMENTO,
         MOV.MTMD_MOV_DATA_FATURAMENTO,
         NVL(MOV.CAD_MTMD_GRUPO_ID, MAT.CAD_MTMD_GRUPO_ID) CAD_MTMD_GRUPO_ID,
         NVL(MOV.CAD_MTMD_SUBGRUPO_ID, MAT.CAD_MTMD_SUBGRUPO_ID) CAD_MTMD_SUBGRUPO_ID,
         MOV.MTMD_CUSTO_MEDIO,
         MOV.SEQ_PACIENTE
   FROM SGS.TB_MTMD_MOV_MOVIMENTACAO       MOV,
        SGS.TB_CAD_MTMD_MAT_MED            MAT,
        SGS.TB_CAD_MTMD_SUBTP_MOVIMENTACAO TIP,
        TB_CAD_SET_SETOR                   SETOR
   WHERE MOV.MTMD_MOV_DATA >= vDataDe
   AND   MOV.MTMD_MOV_DATA < vDataAte+1
   AND   SETOR.CAD_SET_ID        = MOV.CAD_SET_ID
   AND   MAT.CAD_MTMD_ID         = MOV.CAD_MTMD_ID
   AND   TIP.CAD_MTMD_TPMOV_ID   = MOV.CAD_MTMD_TPMOV_ID
   AND   TIP.CAD_MTMD_SUBTP_ID   = MOV.CAD_MTMD_SUBTP_ID
   AND   TIP.CAD_MTMD_FL_CONSUMO = 1
   AND   MOV.CAD_MTMD_SUBTP_ID NOT IN (1,15)
   ORDER BY MOV.MTMD_MOV_DATA,       MOV.CAD_MTMD_ID,       MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO,
         MOV.CAD_UNI_ID_UNIDADE,  MOV.CAD_SET_ID,        MOV.CAD_MTMD_FILIAL_ID,
         MOV.CAD_MTMD_TPMOV_ID,   MOV.CAD_MTMD_SUBTP_ID, MOV.CAD_MTMD_GRUPO_ID,
         MOV.CAD_MTMD_SUBGRUPO_ID;
  -- Acertar o centro de custo do subtipo 19
  UPDATE SGS.TB_MTMD_MOV_ESTOQUE_SAI S SET
         CAD_UNI_ID_UNIDADE = NVL((SELECT CAD_UNI_ID_UNIDADE FROM SGS.TB_MTMD_MOV_MOVIMENTACAO WHERE MTMD_MOV_ID = S.MTMD_MOV_ID_REF),CAD_UNI_ID_UNIDADE),
         CAD_LAT_ID_LOCAL_ATENDIMENTO = NVL((SELECT CAD_LAT_ID_LOCAL_ATENDIMENTO FROM SGS.TB_MTMD_MOV_MOVIMENTACAO WHERE MTMD_MOV_ID = S.MTMD_MOV_ID_REF),CAD_LAT_ID_LOCAL_ATENDIMENTO),
         CAD_SET_ID = NVL((SELECT CAD_SET_ID FROM SGS.TB_MTMD_MOV_MOVIMENTACAO WHERE MTMD_MOV_ID = S.MTMD_MOV_ID_REF),CAD_SET_ID)
  WHERE S.CAD_MTMD_TPMOV_ID = 2 AND
        S.CAD_MTMD_SUBTP_ID = 19 AND
        S.MTMD_MOV_FL_ESTORNO = 0;
  UPDATE SGS.TB_MTMD_MOV_ESTOQUE_SAI S SET
         CAD_UNI_ID_UNIDADE = NVL((SELECT CAD_UNI_ID_UNIDADE FROM SGS.TB_MTMD_MOV_MOVIMENTACAO WHERE MTMD_MOV_ID_REF = S.MTMD_MOV_ID AND CAD_MTMD_TPMOV_ID = 2),CAD_UNI_ID_UNIDADE),
         CAD_LAT_ID_LOCAL_ATENDIMENTO = NVL((SELECT CAD_LAT_ID_LOCAL_ATENDIMENTO FROM SGS.TB_MTMD_MOV_MOVIMENTACAO WHERE MTMD_MOV_ID_REF = S.MTMD_MOV_ID AND CAD_MTMD_TPMOV_ID = 2),CAD_LAT_ID_LOCAL_ATENDIMENTO),
         CAD_SET_ID = NVL((SELECT CAD_SET_ID FROM SGS.TB_MTMD_MOV_MOVIMENTACAO WHERE MTMD_MOV_ID_REF = S.MTMD_MOV_ID AND CAD_MTMD_TPMOV_ID = 2),CAD_SET_ID)
  WHERE S.CAD_MTMD_TPMOV_ID = 2 AND
        S.CAD_MTMD_SUBTP_ID = 19 AND
        S.MTMD_MOV_FL_ESTORNO = 1;
  UPDATE SGS.TB_MTMD_MOV_ESTOQUE_SAI S SET
         CAD_UNI_ID_UNIDADE = NVL((SELECT CAD_UNI_ID_UNIDADE FROM SGS.TB_MTMD_MOV_MOVIMENTACAO WHERE MTMD_MOV_ID_REF = S.MTMD_MOV_ID_REF AND CAD_MTMD_TPMOV_ID = 2),CAD_UNI_ID_UNIDADE),
         CAD_LAT_ID_LOCAL_ATENDIMENTO = NVL((SELECT CAD_LAT_ID_LOCAL_ATENDIMENTO FROM SGS.TB_MTMD_MOV_MOVIMENTACAO WHERE MTMD_MOV_ID_REF = S.MTMD_MOV_ID_REF AND CAD_MTMD_TPMOV_ID = 2),CAD_LAT_ID_LOCAL_ATENDIMENTO),
         CAD_SET_ID = NVL((SELECT CAD_SET_ID FROM SGS.TB_MTMD_MOV_MOVIMENTACAO WHERE MTMD_MOV_ID_REF = S.MTMD_MOV_ID_REF AND CAD_MTMD_TPMOV_ID = 2),CAD_SET_ID)
  WHERE S.CAD_MTMD_TPMOV_ID = 1 AND
        S.CAD_MTMD_SUBTP_ID = 29;
  -- Acertar Filial Carr. Emerg. para o HAC
  UPDATE SGS.TB_MTMD_MOV_ESTOQUE_SAI SET
         CAD_MTMD_FILIAL_ID = 1
  WHERE CAD_MTMD_FILIAL_ID = 4;
  COMMIT;
  PRC_MTMD_MOV_ESTOQUE_MES_ENTRA(NULL, vDataDe, vDataAte);
  PRC_MTMD_MOV_ESTOQUE_MES_GERA(5, vDataDe, vDataAte);
  --Acertar Saldo Contabil eliminando Emprestimos
  /*FOR X IN (SELECT EST_DIA.CAD_MTMD_GRUPO_ID,
                   EST_DIA.CAD_MTMD_SUBGRUPO_ID,
                   EST_DIA.CAD_MTMD_ID, EST_DIA.MTMD_MOV_DATA,
                   (SELECT NVL(E.MTMD_SALDO_ATUAL_CONT,E.MTMD_SALDO_ATUAL)
                     FROM TB_MTMD_MOV_ESTOQUE_DIA E
                    WHERE MTMD_MOV_DATA >= vDataDe-32
                      AND MTMD_MOV_DATA <= vDataDe-28
                      AND CAD_MTMD_FILIAL_ID = 1 AND CAD_SET_ID = 29
                      AND CAD_MTMD_TPMOV_ID = 0 AND CAD_MTMD_SUBTP_ID = 0
                      AND E.CAD_MTMD_ID = EST_DIA.CAD_MTMD_ID) SALDO_ANTERIOR,
                   (SELECT NVL(E.MTMD_VALOR_ATUAL_CONT,E.MTMD_VALOR_ATUAL)
                     FROM TB_MTMD_MOV_ESTOQUE_DIA E
                    WHERE MTMD_MOV_DATA >= vDataDe-32
                      AND MTMD_MOV_DATA <= vDataDe-28
                      AND CAD_MTMD_FILIAL_ID = 1 AND CAD_SET_ID = 29
                      AND CAD_MTMD_TPMOV_ID = 0 AND CAD_MTMD_SUBTP_ID = 0
                      AND E.CAD_MTMD_ID = EST_DIA.CAD_MTMD_ID) VLR_ANTERIOR,
                   SUM(EST_DIA.MTMD_QTDE_ENTRADAS) QTD_ENTRADAS,
                   SUM(EST_DIA.MTMD_VLR_ENTRADAS) VLR_ENTRADAS,
                   SUM(EST_DIA.MTMD_QTDE_BAIXAS) QTD_BAIXAS,
                   SUM(EST_DIA.MTMD_VLR_BAIXAS) VLR_BAIXAS
            FROM (SELECT MTMD.CAD_MTMD_ID, LINHA_ZERO.MTMD_MOV_DATA,
                          DIAP.CAD_MTMD_GRUPO_ID,
                          DIAP.CAD_MTMD_SUBGRUPO_ID,
                          (
                          CASE
                          WHEN LINHA_ZERO.MTMD_SALDO_ANTERIOR = 0 THEN 0
                          ELSE LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR
                          END
                          )                                          MTMD_CUSTO_MEDIO_ANTERIOR,
                          LINHA_ZERO.MTMD_SALDO_ANTERIOR             MTMD_SALDO_ANTERIOR,
                          LINHA_ZERO.MTMD_VALOR_ANTERIOR             MTMD_VALOR_ANTERIOR,
                          LINHA_ZERO.MTMD_SALDO_ATUAL                MTMD_SALDO_ATUAL,
                          LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL          MTMD_CUSTO_MEDIO_ATUAL,
                          LINHA_ZERO.MTMD_VALOR_ATUAL                MTMD_VALOR_ATUAL,
                          SUM( (CASE
                          WHEN DIAP.CAD_MTMD_SUBTP_ID IN (64,65) THEN DIAP.MTMD_QTDE_SAIDA
                          ELSE 0
                          END )
                          )   MTMD_QTDE_BAIXA_EMPRESTIMO,
                          SUM( (CASE
                          WHEN DIAP.CAD_MTMD_SUBTP_ID IN (64,65) THEN DIAP.MTMD_VALOR_SAIDA
                          ELSE 0
                          END )
                          ) MTMD_VALOR_BAIXA_EMPRESTIMO,
                          SUM( (CASE
                          WHEN DIAP.CAD_MTMD_SUBTP_ID IN (62,63) THEN DIAP.MTMD_QTDE_ENTRADA
                          ELSE 0
                          END )
                          ) MTMD_QTDE_ENTRADA_EMPRESTIMO,
                          SUM( (CASE
                          WHEN (DIAP.CAD_MTMD_SUBTP_ID IN (62,63)) THEN DIAP.MTMD_VALOR_ENTRADA
                          ELSE 0
                          END )
                          ) MTMD_VLR_ENTRADA_EMPRESTIMO,
                          SUM( (CASE
                                WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (62,63) THEN DIAP.MTMD_QTDE_ENTRADA
                                ELSE 0
                                END )
                          ) MTMD_QTDE_ENTRADAS,
                          SUM( (CASE
                                WHEN (DIAP.CAD_MTMD_SUBTP_ID NOT IN (62,63)) THEN DIAP.MTMD_VALOR_ENTRADA
                                ELSE 0
                                END )
                          ) MTMD_VLR_ENTRADAS,
                          SUM((CASE
                                WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (64,65) THEN DIAP.MTMD_QTDE_SAIDA
                                ELSE 0
                                END )
                               )   MTMD_QTDE_BAIXAS,
                          SUM((CASE
                                WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (64,65) THEN DIAP.MTMD_VALOR_SAIDA
                                ELSE 0
                                END )
                                ) MTMD_VLR_BAIXAS
                    FROM TB_CAD_MTMD_MAT_MED MTMD,
                          TB_MTMD_MOV_ESTOQUE_DIA DIAP,
                          (
                          SELECT *
                          FROM TB_MTMD_MOV_ESTOQUE_DIA
                          WHERE MTMD_MOV_DATA                = vDataDe
                          AND   (1 IS NULL OR CAD_MTMD_FILIAL_ID = 1)
                          AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
                          AND   CAD_UNI_ID_UNIDADE           = 244
                          AND   CAD_SET_ID                   = 29
                          AND   CAD_MTMD_TPMOV_ID            = 0
                          AND   CAD_MTMD_SUBTP_ID            = 0
                          ) LINHA_ZERO,
                          (
                          SELECT *
                          FROM TB_MTMD_MOV_ESTOQUE_DIA
                          WHERE CAD_MTMD_TPMOV_ID            = 1
                          AND   CAD_MTMD_SUBTP_ID            = 1
                          AND   MTMD_MOV_DATA >= vDataDe
                          AND   MTMD_MOV_DATA <= vDataAte
                          AND   (1 IS NULL OR CAD_MTMD_FILIAL_ID = 1)
                          ) NOTAS
                    WHERE DIAP.MTMD_MOV_DATA >= vDataDe
                    AND   DIAP.MTMD_MOV_DATA <= vDataAte
                    AND   DIAP.CAD_MTMD_FILIAL_ID             = 1
                    AND   MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID
                    AND  LINHA_ZERO.CAD_MTMD_ID(+)               = DIAP.CAD_MTMD_ID
                    AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)        = DIAP.CAD_MTMD_FILIAL_ID
                    AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)         = DIAP.CAD_MTMD_GRUPO_ID
                    AND  LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID(+)         = DIAP.CAD_MTMD_SUBGRUPO_ID
                    AND  NOTAS.MTMD_MOV_DATA(+)       = DIAP.MTMD_MOV_DATA
                    AND  NOTAS.CAD_MTMD_ID(+)         = DIAP.CAD_MTMD_ID
                    AND  NOTAS.CAD_MTMD_FILIAL_ID(+)  = DIAP.CAD_MTMD_FILIAL_ID
                    AND  NOTAS.CAD_MTMD_GRUPO_ID(+)   = DIAP.CAD_MTMD_GRUPO_ID
                    AND  NOTAS.CAD_MTMD_SUBGRUPO_ID(+) = DIAP.CAD_MTMD_SUBGRUPO_ID
                    AND  NOTAS.CAD_MTMD_TPMOV_ID(+)       = DIAP.CAD_MTMD_TPMOV_ID
                    AND  NOTAS.CAD_MTMD_SUBTP_ID(+)       = DIAP.CAD_MTMD_SUBTP_ID
                    AND  DIAP.CAD_MTMD_GRUPO_ID NOT IN (40,42)
                    GROUP BY MTMD.CAD_MTMD_ID,LINHA_ZERO.MTMD_MOV_DATA,
                            DIAP.CAD_MTMD_FILIAL_ID,
                            MTMD.CAD_MTMD_NOMEFANTASIA,
                            LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR,
                            LINHA_ZERO.MTMD_SALDO_ATUAL,
                            LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,
                            LINHA_ZERO.MTMD_VALOR_ATUAL,
                            LINHA_ZERO.MTMD_SALDO_ANTERIOR,
                            LINHA_ZERO.MTMD_VALOR_ANTERIOR,
                            DIAP.CAD_MTMD_GRUPO_ID,
                            DIAP.CAD_MTMD_SUBGRUPO_ID
                    HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0) + NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) > 0) EST_DIA,
                    TB_CAD_MTMD_GRUPO            GRUPO,
                    TB_CAD_MTMD_SUBGRUPO         SUBG
            WHERE GRUPO.CAD_MTMD_GRUPO_ID (+)= EST_DIA.CAD_MTMD_GRUPO_ID AND
                    SUBG.CAD_MTMD_SUBGRUPO_ID (+)= EST_DIA.CAD_MTMD_SUBGRUPO_ID AND
                    SUBG.CAD_MTMD_GRUPO_ID (+)= EST_DIA.CAD_MTMD_GRUPO_ID
            GROUP BY EST_DIA.CAD_MTMD_GRUPO_ID, EST_DIA.CAD_MTMD_SUBGRUPO_ID, EST_DIA.CAD_MTMD_ID, EST_DIA.MTMD_MOV_DATA
            ORDER BY EST_DIA.CAD_MTMD_GRUPO_ID, EST_DIA.CAD_MTMD_SUBGRUPO_ID
  ) LOOP
    UPDATE TB_MTMD_MOV_ESTOQUE_DIA SET
           MTMD_SALDO_ANT_CONT          = X.SALDO_ANTERIOR,
           MTMD_VALOR_ANT_CONT          = X.VLR_ANTERIOR,
           MTMD_SALDO_ATUAL_CONT        = (NVL(X.SALDO_ANTERIOR,0) + X.QTD_ENTRADAS) - X.QTD_BAIXAS,
           MTMD_VALOR_ATUAL_CONT        = (NVL(X.VLR_ANTERIOR,0)   + X.VLR_ENTRADAS) - X.VLR_BAIXAS
     WHERE MTMD_MOV_DATA                = X.MTMD_MOV_DATA
     AND   CAD_MTMD_ID                  = X.CAD_MTMD_ID
     AND   CAD_MTMD_FILIAL_ID           = 1
     AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
     AND   CAD_UNI_ID_UNIDADE           = 244
     AND   CAD_SET_ID                   = 29
     AND   CAD_MTMD_TPMOV_ID            = 0
     AND   CAD_MTMD_SUBTP_ID            = 0;
  END LOOP;
  COMMIT;*/
END  PRC_MTMD_MOV_ESTOQUE_MES;