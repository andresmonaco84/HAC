BEGIN

FOR X IN (SELECT MTMD.CAD_MTMD_ID,
                  --LINHA_ZERO.CAD_MTMD_GRUPO_ID,
                  LINHA_ZERO.MTMD_SALDO_ANTERIOR,
                  LINHA_ZERO.MTMD_VALOR_ANTERIOR,
                  LINHA_ZERO.MTMD_SALDO_ATUAL,
                  LINHA_ZERO.MTMD_VALOR_ATUAL
            FROM TB_CAD_MTMD_MAT_MED MTMD,
                  TB_MTMD_MOV_ESTOQUE_DIA DIAP,
                  (
                  SELECT *
                  FROM TB_MTMD_MOV_ESTOQUE_DIA
                  WHERE MTMD_MOV_DATA                = TO_DATE('01092022 0000','DDMMYYYY HH24MI')
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
                  AND   MTMD_MOV_DATA >= TO_DATE('01092022 0000','DDMMYYYY HH24MI')
                  AND   MTMD_MOV_DATA <= TO_DATE('30092022 0000','DDMMYYYY HH24MI')
                  AND   (1 IS NULL OR CAD_MTMD_FILIAL_ID = 1)
                  ) NOTAS
            WHERE DIAP.MTMD_MOV_DATA >= TO_DATE('01092022 0000','DDMMYYYY HH24MI')
            AND   DIAP.MTMD_MOV_DATA <= TO_DATE('30092022 0000','DDMMYYYY HH24MI')
            AND   DIAP.CAD_MTMD_FILIAL_ID     = 1
            AND   DIAP.CAD_MTMD_GRUPO_ID      = LINHA_ZERO.CAD_MTMD_GRUPO_ID
            AND   MTMD.CAD_MTMD_ID            = DIAP.CAD_MTMD_ID
            AND  LINHA_ZERO.CAD_MTMD_ID(+)    = DIAP.CAD_MTMD_ID
            AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+) = DIAP.CAD_MTMD_FILIAL_ID
            AND  NOTAS.MTMD_MOV_DATA(+)       = DIAP.MTMD_MOV_DATA
            AND  NOTAS.CAD_MTMD_ID(+)         = DIAP.CAD_MTMD_ID
            AND  NOTAS.CAD_MTMD_FILIAL_ID(+)  = DIAP.CAD_MTMD_FILIAL_ID
            AND  NOTAS.CAD_MTMD_TPMOV_ID(+)       = DIAP.CAD_MTMD_TPMOV_ID
            AND  NOTAS.CAD_MTMD_SUBTP_ID(+)       = DIAP.CAD_MTMD_SUBTP_ID
            AND  DIAP.CAD_MTMD_GRUPO_ID NOT IN (40,42)
            GROUP BY MTMD.CAD_MTMD_ID,                     
                     DIAP.CAD_MTMD_FILIAL_ID,  
                     MTMD.CAD_MTMD_NOMEFANTASIA,
                     --LINHA_ZERO.CAD_MTMD_GRUPO_ID,
                     LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR,
                     LINHA_ZERO.MTMD_SALDO_ATUAL,       
                     LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,
                     LINHA_ZERO.MTMD_VALOR_ATUAL,       
                     LINHA_ZERO.MTMD_SALDO_ANTERIOR,
                     LINHA_ZERO.MTMD_VALOR_ANTERIOR
            HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)+ NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) > 0
) LOOP


  UPDATE TB_MTMD_MOV_ESTOQUE_DIA SET
         MTMD_SALDO_ANT_CONT          = X.MTMD_SALDO_ANTERIOR,
         MTMD_VALOR_ANT_CONT          = X.MTMD_VALOR_ANTERIOR,
         MTMD_SALDO_ATUAL_CONT        = X.MTMD_SALDO_ATUAL,
         MTMD_VALOR_ATUAL_CONT        = X.MTMD_VALOR_ATUAL
   WHERE MTMD_MOV_DATA                = TO_DATE('01092022 0000','DDMMYYYY HH24MI')
   AND   CAD_MTMD_ID                  = X.CAD_MTMD_ID
   AND   CAD_MTMD_FILIAL_ID           = 1
   AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
   AND   CAD_UNI_ID_UNIDADE           = 244
   AND   CAD_SET_ID                   = 29
   AND   CAD_MTMD_TPMOV_ID            = 0
   AND   CAD_MTMD_SUBTP_ID            = 0;

END LOOP;

END;

--NAO ATUALIZAR SALDO/VALOR ANTERIOR APENAS NO FECHAMENTO DE SETEMBRO/22
