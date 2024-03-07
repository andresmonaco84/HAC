 /*SELECT (SELECT SUBGRUPO.CAD_MTMD_SUBGRUPO_ID || ' - ' || SUBGRUPO.CAD_MTMD_SUBGRUPO_DESCRICAO 
        FROM TB_CAD_MTMD_SUBGRUPO SUBGRUPO
        WHERE SUBGRUPO.CAD_MTMD_SUBGRUPO_ID = LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID AND
              SUBGRUPO.CAD_MTMD_GRUPO_ID    = LINHA_ZERO.CAD_MTMD_GRUPO_ID) SUBGRUPO,
       MTMD.CAD_MTMD_NOMEFANTASIA || ' - ' || MTMD.CAD_MTMD_CODMNE PRODUTO, 
       (CASE
         WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15) THEN DIAP.MTMD_QTDE_SAIDA -- nao inclui estorno de nota fiscal
         ELSE 0
         END ) MTMD_QTDE_SAIDA,
       (CASE
         WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15) THEN DIAP.MTMD_VALOR_SAIDA   -- nao inclui estorno de nota fiscal
         ELSE 0
         END ) MTMD_VALOR_SAIDA           
FROM TB_CAD_MTMD_MAT_MED MTMD,
     TB_MTMD_MOV_ESTOQUE_DIA DIAP,
     (
       SELECT *
       FROM TB_MTMD_MOV_ESTOQUE_DIA
       WHERE MTMD_MOV_DATA                = TO_DATE('01012011 0000','DDMMYYYY  HH24MI')
       AND   ( 1 IS NULL OR CAD_MTMD_FILIAL_ID = 1 )
       AND   ( null IS NULL OR CAD_MTMD_ID = null )
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
       AND   MTMD_MOV_DATA >= TO_DATE('01012011 0000','DDMMYYYY  HH24MI')
       AND   MTMD_MOV_DATA <= TO_DATE('31012011 0000','DDMMYYYY  HH24MI')       
       AND   ( 1 IS NULL OR CAD_MTMD_FILIAL_ID = 1 )
       AND   ( null IS NULL OR CAD_MTMD_ID = null )     
     ) NOTAS,
     TB_CAD_UNI_UNIDADE UNI,
     TB_CAD_SET_SETOR   SETOR     
WHERE UNI.CAD_UNI_ID_UNIDADE = DIAP.CAD_UNI_ID_UNIDADE 
AND   SETOR.CAD_SET_ID = DIAP.CAD_SET_ID 
AND   DIAP.MTMD_MOV_DATA >= TO_DATE('01012011 0000','DDMMYYYY  HH24MI')
AND   DIAP.MTMD_MOV_DATA <= TO_DATE('31012011 0000','DDMMYYYY  HH24MI')
AND   ( null IS NULL OR DIAP.CAD_MTMD_ID = null )
AND   ( 1 IS NULL OR DIAP.CAD_MTMD_FILIAL_ID = 1 )
AND   MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID
AND  LINHA_ZERO.CAD_MTMD_ID(+)            = DIAP.CAD_MTMD_ID
AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)     = DIAP.CAD_MTMD_FILIAL_ID
AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)      = DIAP.CAD_MTMD_GRUPO_ID
AND  LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID(+)   = DIAP.CAD_MTMD_SUBGRUPO_ID
AND  NOTAS.MTMD_MOV_DATA(+)       = DIAP.MTMD_MOV_DATA
AND  NOTAS.CAD_MTMD_ID(+)         = DIAP.CAD_MTMD_ID
AND  NOTAS.CAD_MTMD_FILIAL_ID(+)  = DIAP.CAD_MTMD_FILIAL_ID
AND  NOTAS.CAD_MTMD_TPMOV_ID(+)       = DIAP.CAD_MTMD_TPMOV_ID
AND  NOTAS.CAD_MTMD_SUBTP_ID(+)       = DIAP.CAD_MTMD_SUBTP_ID
AND  DIAP.CAD_MTMD_GRUPO_ID NOT IN (40,42)
AND  DIAP.CAD_MTMD_GRUPO_ID = 5
--AND  DIAP.CAD_MTMD_SUBGRUPO_ID = 52
AND  DIAP.MTMD_VALOR_SAIDA > 0
AND NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0) > 0              
ORDER BY LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID, MTMD.CAD_MTMD_NOMEFANTASIA*/

SELECT SUBG.CAD_MTMD_SUBGRUPO_ID ||' '|| SUBG.CAD_MTMD_SUBGRUPO_DESCRICAO SUBGRUPO,
       EST_DIA.MTMD_MOV_DATA DATA_CONSUMO,
       SETOR.CAD_SET_DS_SETOR || ' - ' || UNI.CAD_UNI_DS_UNIDADE SETOR,
       --SUBTP_MOV.CAD_MTMD_SUBTP_DESCRICAO,
       EST_DIA.DESCRICAO || ' - ' || EST_DIA.CAD_MTMD_CODMNE PRODUTO,
       /*SUM(EST_DIA.MTMD_SALDO_ANTERIOR) ANTERIOR,
       SUM(EST_DIA.MTMD_VALOR_ANTERIOR) VLR_ANTERIOR,
       SUM(EST_DIA.MTMD_QTDE_ENTRADA )  ENTRADAS,
       SUM(EST_DIA.MTMD_VALOR_ENTRADA)  VLR_ENTRADA,      
       SUM(EST_DIA.MTMD_QTDE_DEVOLUCAO) DEVOLUCAO,
       SUM(EST_DIA.MTMD_VLR_DEVOLUCAO)  VLR_DEVOLUCAO,*/
       EST_DIA.MTMD_QTDE_SAIDA     QTDE_SAIDA,
       EST_DIA.MTMD_VALOR_SAIDA    VALOR_SAIDA    
       /*SUM(EST_DIA.MTMD_SALDO_ATUAL)    SALDO_ATUAL,
       SUM(EST_DIA.MTMD_VALOR_ATUAL)    VLR_ATUAL*/
FROM
  (SELECT DIAP.MTMD_MOV_DATA, 
          DIAP.CAD_UNI_ID_UNIDADE,
          DIAP.CAD_SET_ID,
          --DIAP.CAD_MTMD_SUBTP_ID,
          MTMD.CAD_MTMD_ID,
          MTMD.CAD_MTMD_CODMNE,
          DIAP.CAD_MTMD_GRUPO_ID, 
          DIAP.CAD_MTMD_SUBGRUPO_ID,
       MTMD.CAD_MTMD_NOMEFANTASIA DESCRICAO, 
       (  -- se saldo inicial for zero n�o retorna custo medio
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
       SUM(NVL(NOTAS.MTMD_QTDE_ENTRADA,0))        MTMD_QTDE_ENTRADA,
       SUM(NVL(NOTAS.MTMD_VALOR_ENTRADA,0))       MTMD_VALOR_ENTRADA,       
       SUM( 
           (CASE
             --WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15) THEN DIAP.MTMD_QTDE_SAIDA -- nao inclui estorno de nota fiscal
             WHEN (DIAP.CAD_MTMD_SUBTP_ID NOT IN (15) AND LINHA_ZERO.MTMD_VALOR_ATUAL>=0) THEN DIAP.MTMD_QTDE_SAIDA -- nao inclui estorno de nota fiscal
             ELSE 0
             END )       
        )   MTMD_QTDE_SAIDA,       
       SUM(
           (CASE
             WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15) THEN DIAP.MTMD_VALOR_SAIDA   -- nao inclui estorno de nota fiscal
             ELSE 0
             END )              
          ) MTMD_VALOR_SAIDA,
       SUM( (CASE
             WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (1) THEN DIAP.MTMD_QTDE_ENTRADA
             ELSE 0
             END )
           ) MTMD_QTDE_DEVOLUCAO,  -- OUTRAS ENTRAS QUE NAO SEJA NF           
       SUM( (CASE
             WHEN (DIAP.CAD_MTMD_SUBTP_ID NOT IN (1)) THEN DIAP.MTMD_VALOR_ENTRADA
             ELSE 0
             END )
          ) MTMD_VLR_DEVOLUCAO -- OUTRAS ENTRADAS QUE NAO SEJA NF
FROM TB_CAD_MTMD_MAT_MED MTMD,
     TB_MTMD_MOV_ESTOQUE_DIA DIAP,
     (
       SELECT *
       FROM TB_MTMD_MOV_ESTOQUE_DIA
       WHERE MTMD_MOV_DATA                = TO_DATE('01012011 0000','DDMMYYYY HH24MI')
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
       AND   MTMD_MOV_DATA >= TO_DATE('01012011 0000','DDMMYYYY HH24MI')
       AND   MTMD_MOV_DATA <= TO_DATE('31012011 0000','DDMMYYYY HH24MI')
       AND   (1 IS NULL OR CAD_MTMD_FILIAL_ID = 1)
       AND   1 != 0
       AND   MTMD_QTDE_ENTRADA > 0
     
     ) NOTAS                
WHERE DIAP.MTMD_MOV_DATA >= TO_DATE('01012011 0000','DDMMYYYY HH24MI')
AND   DIAP.MTMD_MOV_DATA <= TO_DATE('31012011 0000','DDMMYYYY HH24MI')
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
AND  DIAP.CAD_MTMD_GRUPO_ID = 61
--AND  DIAP.CAD_MTMD_SUBGRUPO_ID = 83
GROUP BY DIAP.MTMD_MOV_DATA, 
         DIAP.CAD_UNI_ID_UNIDADE,
         DIAP.CAD_SET_ID,
         --DIAP.CAD_MTMD_SUBTP_ID,
         MTMD.CAD_MTMD_ID,   
         MTMD.CAD_MTMD_CODMNE,
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
HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)  ) > 0) EST_DIA,
 TB_CAD_MTMD_GRUPO            GRUPO,
 TB_CAD_MTMD_SUBGRUPO         SUBG,
 TB_CAD_UNI_UNIDADE           UNI,
 TB_CAD_SET_SETOR             SETOR/*,
 TB_CAD_MTMD_SUBTP_MOVIMENTACAO SUBTP_MOV  */  
WHERE GRUPO.CAD_MTMD_GRUPO_ID (+)= EST_DIA.CAD_MTMD_GRUPO_ID AND 
      SUBG.CAD_MTMD_SUBGRUPO_ID (+)= EST_DIA.CAD_MTMD_SUBGRUPO_ID AND 
      SUBG.CAD_MTMD_GRUPO_ID (+)= EST_DIA.CAD_MTMD_GRUPO_ID AND
      SETOR.CAD_SET_ID = EST_DIA.CAD_SET_ID AND
      UNI.CAD_UNI_ID_UNIDADE = EST_DIA.CAD_UNI_ID_UNIDADE AND
      --SUBTP_MOV.CAD_MTMD_SUBTP_ID = EST_DIA.CAD_MTMD_SUBTP_ID AND
      EST_DIA.MTMD_QTDE_SAIDA > 0 
      --AND SUBG.CAD_MTMD_SUBGRUPO_ID IS NOT NULL
ORDER BY EST_DIA.CAD_MTMD_SUBGRUPO_ID, EST_DIA.MTMD_MOV_DATA, UNI.CAD_UNI_DS_UNIDADE, SETOR.CAD_SET_DS_SETOR, EST_DIA.DESCRICAO;


--Com SUBGRUPO = null
/*

SELECT '' SUBGRUPO,
       DIAP.MTMD_MOV_DATA DATA_CONSUMO,
       SETOR.CAD_SET_DS_SETOR || ' - ' || UNI.CAD_UNI_DS_UNIDADE SETOR,
       MTMD.CAD_MTMD_NOMEFANTASIA || ' - ' || MTMD.CAD_MTMD_CODMNE PRODUTO,       
       (CASE
         --WHEN (DIAP.CAD_MTMD_SUBTP_ID NOT IN (15) AND LINHA_ZERO.MTMD_VALOR_ATUAL>=0) THEN DIAP.MTMD_QTDE_SAIDA -- nao inclui estorno de nota fiscal
         WHEN (DIAP.CAD_MTMD_SUBTP_ID NOT IN (15)) THEN DIAP.MTMD_QTDE_SAIDA -- nao inclui estorno de nota fiscal
         ELSE 0
         END )       
       MTMD_QTDE_SAIDA,       
   
       (CASE
         WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15) THEN DIAP.MTMD_VALOR_SAIDA   -- nao inclui estorno de nota fiscal
         ELSE 0
         END )              
       MTMD_VALOR_SAIDA       
FROM TB_CAD_MTMD_MAT_MED MTMD,
     TB_MTMD_MOV_ESTOQUE_DIA DIAP,
     (
       SELECT *
       FROM TB_MTMD_MOV_ESTOQUE_DIA
       WHERE MTMD_MOV_DATA                = TO_DATE('01012011 0000','DDMMYYYY HH24MI')
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
       AND   MTMD_MOV_DATA >= TO_DATE('01012011 0000','DDMMYYYY HH24MI')
       AND   MTMD_MOV_DATA <= TO_DATE('31012011 0000','DDMMYYYY HH24MI')
       AND   (1 IS NULL OR CAD_MTMD_FILIAL_ID = 1)
       AND   1 != 0
       AND   MTMD_QTDE_ENTRADA > 0
     
     ) NOTAS,
 TB_CAD_UNI_UNIDADE           UNI,
 TB_CAD_SET_SETOR             SETOR         
WHERE UNI.CAD_UNI_ID_UNIDADE = DIAP.CAD_UNI_ID_UNIDADE
AND   SETOR.CAD_SET_ID = DIAP.CAD_SET_ID
AND   DIAP.MTMD_MOV_DATA >= TO_DATE('01012011 0000','DDMMYYYY HH24MI')
AND   DIAP.MTMD_MOV_DATA <= TO_DATE('31012011 0000','DDMMYYYY HH24MI')
AND   DIAP.CAD_MTMD_FILIAL_ID             = 1
AND   MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID
AND  LINHA_ZERO.CAD_MTMD_ID(+)            = DIAP.CAD_MTMD_ID
AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)     = DIAP.CAD_MTMD_FILIAL_ID
AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)      = DIAP.CAD_MTMD_GRUPO_ID
AND  LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID(+)   = DIAP.CAD_MTMD_SUBGRUPO_ID
AND  NOTAS.MTMD_MOV_DATA(+)       = DIAP.MTMD_MOV_DATA
AND  NOTAS.CAD_MTMD_ID(+)         = DIAP.CAD_MTMD_ID
AND  NOTAS.CAD_MTMD_FILIAL_ID(+)  = DIAP.CAD_MTMD_FILIAL_ID
AND  NOTAS.CAD_MTMD_GRUPO_ID(+)   = DIAP.CAD_MTMD_GRUPO_ID
AND  NOTAS.CAD_MTMD_SUBGRUPO_ID(+) = DIAP.CAD_MTMD_SUBGRUPO_ID
AND  NOTAS.CAD_MTMD_TPMOV_ID(+)       = DIAP.CAD_MTMD_TPMOV_ID
AND  NOTAS.CAD_MTMD_SUBTP_ID(+)       = DIAP.CAD_MTMD_SUBTP_ID
AND  DIAP.CAD_MTMD_GRUPO_ID NOT IN (40,42)
AND  DIAP.CAD_MTMD_GRUPO_ID = 8
and diap.cad_mtmd_subgrupo_id is null
and NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0) > 0


*/