CREATE OR REPLACE PROCEDURE SGS.PRC_MTMD_MOV_ESTOQUE_MES_S
  (
     pCAD_MTMD_ID IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_ID%type DEFAULT NULL,
     pMTMD_MOV_MES IN NUMBER DEFAULT NULL,
     pMTMD_MOV_ANO IN NUMBER DEFAULT NULL,
     pCAD_MTMD_FILIAL_ID IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_FILIAL_ID%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     pCAD_MTMD_GRUPO_ID IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_GRUPO_ID%type DEFAULT NULL,
     pCAD_MTMD_SUBGRUPO_ID IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_SUBGRUPO_ID%type DEFAULT NULL,
     pCOLUNAS_INVENTARIO NUMBER DEFAULT NULL, -- 0 ou 1
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_MTMD_MOV_ESTOQUE_MES_S
  *
  *    Data Criacao: 	22/04/2010   Por: RICARDO COSTA
  *    Data Alteracao:	 20/05/2010  Por: RICARDO COSTA
  *         Alterac?o: Adequac?o das colunas a nova estrutura
  *    Data Alteracao:	 21/03/2011  Por: Andre
  *         Alterac?o: Adequac?o das colunas a nova estrutura
  *    Data Alteracao:	 24/03/2011  Por: Andre
  *         Alterac?o: Adic?o do param. pCAD_UNI_ID_UNIDADE
  *    Data Alteracao:	 04/04/2011  Por: Andre
  *         Alterac?o: Adic?o do param. pCAD_MTMD_GRUPO_ID
  *    Data Alteracao:	 18/05/2011  Por: Andre
  *         Alterac?o: Adic?o do param. pCAD_MTMD_SUBGRUPO_ID
  *    Data Alteracao:	 08/06/2011  Por: Andre
  *         Alterac?o: Adic?o dos campos para diferenciar o consumo das perdas
  *
  *    Funcao: Relatorio de fechamento mensal 23 (analitico)
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  vUnidade TB_MTMD_MOV_ESTOQUE_MES.CAD_UNI_ID_UNIDADE%type := 244; --SANTOS
  dDataIni DATE;
  dDataFim DATE;
  sMes     VARCHAR2(2);
  BEGIN
  IF (  LENGTH(TO_CHAR(pMTMD_MOV_MES)) = 1 ) THEN
     sMes := '0'||TO_CHAR(pMTMD_MOV_MES);  
  ELSE
     sMes := TO_CHAR(pMTMD_MOV_MES);     
  END IF;
  dDataIni := TO_DATE( '01'||sMes||TO_CHAR(pMTMD_MOV_ANO)||' 0000','DDMMYYYY HH24MI');
  dDatafIM := TO_DATE( TO_CHAR(LAST_DAY(dDataIni),'DDMMYYYY')||' 2359','DDMMYYYY HH24MI');
  IF (pCAD_UNI_ID_UNIDADE IS NOT NULL AND pCAD_UNI_ID_UNIDADE != 244) THEN
     vUnidade := pCAD_UNI_ID_UNIDADE;
  END IF;
  IF (vUnidade = 244) THEN
    IF (NVL(pCOLUNAS_INVENTARIO,0) = 0) THEN
        OPEN v_cursor FOR
         SELECT MTMD.CAD_MTMD_ID,
               MTMD.CAD_MTMD_NOMEFANTASIA DESCRICAO, 
               (  -- se saldo inicial for zero n?o retorna custo medio
                  CASE
                     WHEN LINHA_ZERO.MTMD_SALDO_ANTERIOR = 0 THEN 0
                     ELSE LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR  
                  END
               )                                          MTMD_CUSTO_MEDIO_ANTERIOR,
               LINHA_ZERO.MTMD_SALDO_ANTERIOR             MTMD_SALDO_ANTERIOR,
               LINHA_ZERO.MTMD_VALOR_ANTERIOR             MTMD_VALOR_ANTERIOR,    
               LINHA_ZERO.MTMD_SALDO_ATUAL                MTMD_SALDO_ATUAL,       
               DECODE( LINHA_ZERO.MTMD_SALDO_ATUAL, 0, 0, LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL)  MTMD_CUSTO_MEDIO_ATUAL,
               LINHA_ZERO.MTMD_VALOR_ATUAL                MTMD_VALOR_ATUAL,    
               SUM(NVL(NOTAS.MTMD_QTDE_ENTRADA,0))        MTMD_QTDE_ENTRADA,
               SUM(NVL(NOTAS.MTMD_VALOR_ENTRADA,0))       MTMD_VALOR_ENTRADA,       
               SUM( 
                   (CASE
                     WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15) THEN DIAP.MTMD_QTDE_SAIDA -- nao inclui estorno de nota fiscal
                     ELSE 0
                     END )       
                )   MTMD_QTDE_SAIDA,
               SUM(
                   (CASE
                     WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15) THEN DIAP.MTMD_VALOR_SAIDA   -- nao inclui estorno de nota fiscal
                     ELSE 0
                     END )              
                  ) MTMD_VALOR_SAIDA,          
               SUM( 
                   (CASE
                     WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15, 6) THEN DIAP.MTMD_QTDE_SAIDA -- nao inclui estorno de nota fiscal, nem perdas
                     ELSE 0
                     END )       
                )   MTMD_QTDE_CONSUMO,
               SUM(
                   (CASE
                     WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15, 6) THEN DIAP.MTMD_VALOR_SAIDA   -- nao inclui estorno de nota fiscal, nem perdas
                     ELSE 0
                     END )              
                  ) MTMD_VALOR_CONSUMO,          
               SUM( 
                   (CASE
                     WHEN DIAP.CAD_MTMD_SUBTP_ID IN (6) THEN DIAP.MTMD_QTDE_SAIDA
                     ELSE 0
                     END )       
                )   MTMD_QTDE_PERDA,
               SUM(
                   (CASE
                     WHEN DIAP.CAD_MTMD_SUBTP_ID IN (6) THEN DIAP.MTMD_VALOR_SAIDA
                     ELSE 0
                     END )              
                  ) MTMD_VALOR_PERDA,          
          --       SUM(DECODE( DIAP.CAD_MTMD_SUBTP_ID,15, DIAP.MTMD_QTDE_SAIDA,0) )   ENT_DEV_AQUISICAO,     -- DEV NOTA
          --       SUM( DECODE( DIAP.CAD_MTMD_SUBTP_ID,15, DIAP.MTMD_VALOR_SAIDA,0) ) ENT_VLR_DEV_AQUISICAO, -- DEV NOTA 
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
                /*          
                */
                --       SUM(DIAP.MTMD_SALDO_ATUAL ) ATUAL,
                --       SUM(DIAP.MTMD_VALOR_ATUAL  ) VLR_ATU
                FROM TB_CAD_MTMD_MAT_MED MTMD,
                     TB_MTMD_MOV_ESTOQUE_DIA DIAP,
                     (
                       SELECT *
                       FROM TB_MTMD_MOV_ESTOQUE_DIA
                       WHERE MTMD_MOV_DATA                = dDataIni
                       AND   ( pCAD_MTMD_FILIAL_ID IS NULL OR CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID )
                       AND   ( pCAD_MTMD_ID IS NULL OR CAD_MTMD_ID = pCAD_MTMD_ID )
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
                       AND   MTMD_MOV_DATA >= dDataIni
                       AND   MTMD_MOV_DATA <= dDatafIM       
                       AND   ( pCAD_MTMD_FILIAL_ID IS NULL OR CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID )
                       AND   ( pCAD_MTMD_ID IS NULL OR CAD_MTMD_ID = pCAD_MTMD_ID )       
                --       AND   MTMD_VALOR_ENTRADA != 0
                --       AND   MTMD_QTDE_ENTRADA > 0
                     ) NOTAS 
                WHERE DIAP.MTMD_MOV_DATA >= dDataIni
                AND   DIAP.MTMD_MOV_DATA <= dDatafIM
                AND   DIAP.CAD_MTMD_FILIAL_ID             = pCAD_MTMD_FILIAL_ID
                    
                AND   DIAP.CAD_MTMD_GRUPO_ID = LINHA_ZERO.CAD_MTMD_GRUPO_ID
                --AND   DIAP.CAD_MTMD_SUBGRUPO_ID = LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID
                    
                AND   ( pCAD_MTMD_ID IS NULL OR DIAP.CAD_MTMD_ID = pCAD_MTMD_ID )
                AND   ( pCAD_MTMD_GRUPO_ID IS NULL OR DIAP.CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID )
                AND   ( pCAD_MTMD_SUBGRUPO_ID IS NULL OR DIAP.CAD_MTMD_SUBGRUPO_ID = pCAD_MTMD_SUBGRUPO_ID )
                AND   MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID
                    
                AND  LINHA_ZERO.CAD_MTMD_ID(+)             = DIAP.CAD_MTMD_ID
                AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)        = DIAP.CAD_MTMD_FILIAL_ID
                    
                --AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)         = DIAP.CAD_MTMD_GRUPO_ID
                --AND  LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID(+)         = DIAP.CAD_MTMD_SUBGRUPO_ID
                AND  NOTAS.MTMD_MOV_DATA(+)       = DIAP.MTMD_MOV_DATA
                AND  NOTAS.CAD_MTMD_ID(+)         = DIAP.CAD_MTMD_ID
                AND  NOTAS.CAD_MTMD_FILIAL_ID(+)  = DIAP.CAD_MTMD_FILIAL_ID
                    
                /*AND  NOTAS.CAD_MTMD_GRUPO_ID(+)   = DIAP.CAD_MTMD_GRUPO_ID
                AND  NOTAS.CAD_MTMD_SUBGRUPO_ID(+) = DIAP.CAD_MTMD_SUBGRUPO_ID*/
                    
                AND  NOTAS.CAD_MTMD_TPMOV_ID(+)       = DIAP.CAD_MTMD_TPMOV_ID
                AND  NOTAS.CAD_MTMD_SUBTP_ID(+)       = DIAP.CAD_MTMD_SUBTP_ID
                AND  DIAP.CAD_MTMD_GRUPO_ID NOT IN (40,42)
                -- AND   DIAP.CAD_MTMD_GRUPO_ID      IN (1,2,4,5,6,8,9,11,12,61) 
                GROUP BY MTMD.CAD_MTMD_ID,   
                         DIAP.CAD_MTMD_FILIAL_ID,  
                         MTMD.CAD_MTMD_NOMEFANTASIA,
                         LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR,
                         LINHA_ZERO.MTMD_SALDO_ATUAL,       
                         LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,
                         LINHA_ZERO.MTMD_VALOR_ATUAL,       
                         LINHA_ZERO.MTMD_SALDO_ANTERIOR,
                         LINHA_ZERO.MTMD_VALOR_ANTERIOR
                HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)+ NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) > 0
                ORDER BY MTMD.CAD_MTMD_NOMEFANTASIA;   
          /*
          SELECT
             mtmd.cad_mtmd_id, MTMD.cad_mtmd_nomefantasia CAD_MTMD_NOMEFANTASIA,
             MTMD.cad_mtmd_unid_controle_ds,
             MOV.mtmd_mov_mes,
             MOV.mtmd_mov_ano,
             MOV.mtmd_custo_medio_anterior,
             SUM(MOV.MTMD_MOV_ESTOQUE_ANTERIOR )            MTMD_MOV_ESTOQUE_ANTERIOR,
             SUM(MOV.MTMD_VALOR_TOTAL_ANTERIOR )            MTMD_VALOR_TOTAL_ANTERIOR,
             SUM(NVL(MOV.mtmd_qtde_ENTRADA,0))              mtmd_qtde_ENTRADA,
             SUM(NVL(MOV.MTMD_VALOR_TOTAL_MES_ENTRADA,0))   MTMD_VALOR_TOTAL_MES_ENTRADA,
             SUM( NVL(MOV.mtmd_QTDE_SAIDA,0) )              mtmd_QTDE_SAIDA,
             SUM( NVL(MOV.MTMD_VALOR_TOTAL_MES_SAIDA,0) )   MTMD_VALOR_TOTAL_MES_SAIDA,
             MOV.mtmd_custo_medio,
             SUM(NVL(MOV.mtmd_mov_estoque_atual,0))          mtmd_mov_estoque_atual,
             SUM(NVL(MOV.MTMD_VALOR_TOTAL_MES,0))            MTMD_VALOR_TOTAL_MES,
             SUM(NVL(MOV.MTMD_QTDE_ACERTO,0))                MTMD_QTDE_ACERTO
          FROM TB_MTMD_MOV_ESTOQUE_MES MOV,
               TB_CAD_MTMD_MAT_MED     MTMD
          WHERE (pCAD_MTMD_ID                  is null OR MOV.CAD_MTMD_ID = pCAD_MTMD_ID)
          AND   (pCAD_LAT_ID_LOCAL_ATENDIMENTO is null OR MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
          AND   (pCAD_UNI_ID_UNIDADE           is null OR MOV.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
          AND   (pCAD_SET_ID                   is null OR MOV.CAD_SET_ID = pCAD_SET_ID)
          AND   (pMTMD_MOV_MES                 is null OR MOV.MTMD_MOV_MES = pMTMD_MOV_MES)
          AND   (pMTMD_MOV_ANO                 is null OR MOV.MTMD_MOV_ANO = pMTMD_MOV_ANO)
          AND   (pCAD_MTMD_FILIAL_ID is null OR MOV.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID)
          AND   MOV.CAD_MTMD_GRUPO_ID          IN (1,2,4,5,6,8,9,11,12,61)    
          AND   (pMTMD_MOV_TIPO                is null OR MOV.MTMD_MOV_TIPO = pMTMD_MOV_TIPO)
          AND   (pCAD_MTMD_SUBTP_ID            is null OR MOV.CAD_MTMD_SUBTP_ID = pCAD_MTMD_SUBTP_ID)
      --    AND MOV.MTMD_MOV_TIPO = 1
      --    AND MOV.CAD_MTMD_SUBTP_ID = 0
      --    AND MOV.MTMD_MOV_MES = 4
      --    AND MOV.MTMD_MOV_ANO = 2010
      --    AND   MOV.cad_mtmd_filial_id     = 1
          AND   (pCAD_MTMD_GRUPO_ID            is null OR MOV.CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID)
          AND   (pCAD_MTMD_SUBGRUPO_ID         is null OR MOV.CAD_MTMD_SUBGRUPO_ID = pCAD_MTMD_SUBGRUPO_ID)
          AND   MTMD.cad_mtmd_id               = MOV.cad_mtmd_id
          GROUP BY
             mtmd.cad_mtmd_id, MTMD.cad_mtmd_nomefantasia ,
             MTMD.cad_mtmd_unid_controle_ds,
             MOV.mtmd_mov_mes,
             MOV.mtmd_mov_ano,
             MOV.mtmd_custo_medio_anterior,
             MOV.mtmd_custo_medio
          ORDER BY MTMD.cad_mtmd_nomefantasia */  
    ELSE
         OPEN v_cursor FOR
         SELECT MTMD.CAD_MTMD_ID,
               MTMD.CAD_MTMD_NOMEFANTASIA DESCRICAO, 
               (  -- se saldo inicial for zero n?o retorna custo medio
                  CASE
                     WHEN LINHA_ZERO.MTMD_SALDO_ANTERIOR = 0 THEN 0
                     ELSE LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR  
                  END
               )                                          MTMD_CUSTO_MEDIO_ANTERIOR,
               LINHA_ZERO.MTMD_SALDO_ANTERIOR             MTMD_SALDO_ANTERIOR,
               LINHA_ZERO.MTMD_VALOR_ANTERIOR             MTMD_VALOR_ANTERIOR,    
               LINHA_ZERO.MTMD_SALDO_ATUAL                MTMD_SALDO_ATUAL,       
               DECODE( LINHA_ZERO.MTMD_SALDO_ATUAL, 0, 0, LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL)  MTMD_CUSTO_MEDIO_ATUAL,
               LINHA_ZERO.MTMD_VALOR_ATUAL                MTMD_VALOR_ATUAL,    
               SUM(NVL(NOTAS.MTMD_QTDE_ENTRADA,0))        MTMD_QTDE_ENTRADA,
               SUM(NVL(NOTAS.MTMD_VALOR_ENTRADA,0))       MTMD_VALOR_ENTRADA,       
               SUM( 
                   (CASE
                     WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15) THEN DIAP.MTMD_QTDE_SAIDA -- nao inclui estorno de nota fiscal
                     ELSE 0
                     END )       
                )   MTMD_QTDE_SAIDA,
               SUM(
                   (CASE
                     WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15) THEN DIAP.MTMD_VALOR_SAIDA   -- nao inclui estorno de nota fiscal
                     ELSE 0
                     END )              
                  ) MTMD_VALOR_SAIDA,          
               SUM( 
                   (CASE
                     WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15, 6, 43) THEN DIAP.MTMD_QTDE_SAIDA -- nao inclui estorno de nota fiscal, nem perdas, nem inventatio
                     ELSE 0
                     END )       
                )   MTMD_QTDE_CONSUMO,
               SUM(
                   (CASE
                     WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15, 6, 43) THEN DIAP.MTMD_VALOR_SAIDA   -- nao inclui estorno de nota fiscal, nem perdas, nem inventatio
                     ELSE 0
                     END )              
                  ) MTMD_VALOR_CONSUMO,   
               SUM( 
                     (CASE
                       WHEN DIAP.CAD_MTMD_SUBTP_ID IN (43) THEN DIAP.MTMD_QTDE_SAIDA
                       ELSE 0
                       END )       
                  )   MTMD_QTDE_BAIXA_INVENTARIO,
                 SUM(
                     (CASE
                       WHEN DIAP.CAD_MTMD_SUBTP_ID IN (43) THEN DIAP.MTMD_VALOR_SAIDA
                       ELSE 0
                       END )              
                    ) MTMD_VALOR_BAIXA_INVENTARIO,        
               SUM( 
                   (CASE
                     WHEN DIAP.CAD_MTMD_SUBTP_ID IN (6) THEN DIAP.MTMD_QTDE_SAIDA
                     ELSE 0
                     END )       
                )   MTMD_QTDE_PERDA,
               SUM(
                   (CASE
                     WHEN DIAP.CAD_MTMD_SUBTP_ID IN (6) THEN DIAP.MTMD_VALOR_SAIDA
                     ELSE 0
                     END )              
                  ) MTMD_VALOR_PERDA,          
               SUM( (CASE
                     WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (1, 44) THEN DIAP.MTMD_QTDE_ENTRADA
                     ELSE 0
                     END )
                   ) MTMD_QTDE_DEVOLUCAO,  -- OUTRAS ENTRAS QUE NAO SEJA NF
               SUM( (CASE
                     WHEN (DIAP.CAD_MTMD_SUBTP_ID NOT IN (1, 44)) THEN DIAP.MTMD_VALOR_ENTRADA
                     ELSE 0
                     END )
                  ) MTMD_VLR_DEVOLUCAO, -- OUTRAS ENTRADAS QUE NAO SEJA NF
               SUM( (CASE
                       WHEN DIAP.CAD_MTMD_SUBTP_ID IN (44) THEN DIAP.MTMD_QTDE_ENTRADA
                       ELSE 0
                       END )
                     ) MTMD_QTDE_ENTRADA_INVENTARIO,           
                 SUM( (CASE
                       WHEN (DIAP.CAD_MTMD_SUBTP_ID IN (44)) THEN DIAP.MTMD_VALOR_ENTRADA
                       ELSE 0
                       END )
                    ) MTMD_VLR_ENTRADA_INVENTARIO
                FROM TB_CAD_MTMD_MAT_MED MTMD,
                     TB_MTMD_MOV_ESTOQUE_DIA DIAP,
                     (
                       SELECT *
                       FROM TB_MTMD_MOV_ESTOQUE_DIA
                       WHERE MTMD_MOV_DATA                = dDataIni
                       AND   ( pCAD_MTMD_FILIAL_ID IS NULL OR CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID )
                       AND   ( pCAD_MTMD_ID IS NULL OR CAD_MTMD_ID = pCAD_MTMD_ID )
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
                       AND   MTMD_MOV_DATA >= dDataIni
                       AND   MTMD_MOV_DATA <= dDatafIM       
                       AND   ( pCAD_MTMD_FILIAL_ID IS NULL OR CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID )
                       AND   ( pCAD_MTMD_ID IS NULL OR CAD_MTMD_ID = pCAD_MTMD_ID )       
                     ) NOTAS 
                WHERE DIAP.MTMD_MOV_DATA >= dDataIni
                AND   DIAP.MTMD_MOV_DATA <= dDatafIM
                AND   DIAP.CAD_MTMD_FILIAL_ID             = pCAD_MTMD_FILIAL_ID            
                AND   DIAP.CAD_MTMD_GRUPO_ID = LINHA_ZERO.CAD_MTMD_GRUPO_ID            
                AND   ( pCAD_MTMD_ID IS NULL OR DIAP.CAD_MTMD_ID = pCAD_MTMD_ID )
                AND   ( pCAD_MTMD_GRUPO_ID IS NULL OR DIAP.CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID )
                AND   ( pCAD_MTMD_SUBGRUPO_ID IS NULL OR DIAP.CAD_MTMD_SUBGRUPO_ID = pCAD_MTMD_SUBGRUPO_ID )
                AND   MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID            
                AND  LINHA_ZERO.CAD_MTMD_ID(+)             = DIAP.CAD_MTMD_ID
                AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)        = DIAP.CAD_MTMD_FILIAL_ID            
                AND  NOTAS.MTMD_MOV_DATA(+)       = DIAP.MTMD_MOV_DATA
                AND  NOTAS.CAD_MTMD_ID(+)         = DIAP.CAD_MTMD_ID
                AND  NOTAS.CAD_MTMD_FILIAL_ID(+)  = DIAP.CAD_MTMD_FILIAL_ID
                AND  NOTAS.CAD_MTMD_TPMOV_ID(+)       = DIAP.CAD_MTMD_TPMOV_ID
                AND  NOTAS.CAD_MTMD_SUBTP_ID(+)       = DIAP.CAD_MTMD_SUBTP_ID
                AND  DIAP.CAD_MTMD_GRUPO_ID NOT IN (40,42)
                GROUP BY MTMD.CAD_MTMD_ID,   
                         DIAP.CAD_MTMD_FILIAL_ID,  
                         MTMD.CAD_MTMD_NOMEFANTASIA,
                         LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR,
                         LINHA_ZERO.MTMD_SALDO_ATUAL,       
                         LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,
                         LINHA_ZERO.MTMD_VALOR_ATUAL,       
                         LINHA_ZERO.MTMD_SALDO_ANTERIOR,
                         LINHA_ZERO.MTMD_VALOR_ANTERIOR
                HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)+ NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) > 0
                ORDER BY MTMD.CAD_MTMD_NOMEFANTASIA;      
    END IF;   
  ELSE
      OPEN v_cursor FOR
      SELECT MTMD.CAD_MTMD_ID,
             MTMD.CAD_MTMD_NOMEFANTASIA DESCRICAO, 
             0             MTMD_CUSTO_MEDIO_ANTERIOR,       
             0             MTMD_SALDO_ANTERIOR,
             0             MTMD_VALOR_ANTERIOR,            
             SUM( 
                 (CASE
                   WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15) THEN DIAP.MTMD_QTDE_SAIDA -- nao inclui estorno de nota fiscal
                   ELSE 0
                   END )       
              ) MTMD_QTDE_ENTRADA,
             SUM(
                 (CASE
                   WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15) THEN DIAP.MTMD_VALOR_SAIDA   -- nao inclui estorno de nota fiscal
                   ELSE 0
                   END )              
               ) MTMD_VALOR_ENTRADA,  
             0 MTMD_QTDE_DEVOLUCAO, 
             0 MTMD_VLR_DEVOLUCAO,
             SUM( 
                 (CASE
                   WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15) THEN DIAP.MTMD_QTDE_SAIDA -- nao inclui estorno de nota fiscal
                   ELSE 0
                   END )       
              )   MTMD_QTDE_SAIDA,       
             SUM(
                 (CASE
                   WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15) THEN DIAP.MTMD_VALOR_SAIDA   -- nao inclui estorno de nota fiscal
                   ELSE 0
                   END )              
                ) MTMD_VALOR_SAIDA, 
             SUM( 
                 (CASE
                   WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15, 6) THEN DIAP.MTMD_QTDE_SAIDA -- nao inclui estorno de nota fiscal, nem perdas
                   ELSE 0
                   END )       
              )   MTMD_QTDE_CONSUMO,
             SUM(
                 (CASE
                   WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15, 6) THEN DIAP.MTMD_VALOR_SAIDA   -- nao inclui estorno de nota fiscal, nem perdas
                   ELSE 0
                   END )              
                ) MTMD_VALOR_CONSUMO,
                  
             SUM( 
                 (CASE
                   WHEN DIAP.CAD_MTMD_SUBTP_ID IN (6) THEN DIAP.MTMD_QTDE_SAIDA
                   ELSE 0
                   END )       
              )   MTMD_QTDE_PERDA,
             SUM(
                 (CASE
                   WHEN DIAP.CAD_MTMD_SUBTP_ID IN (6) THEN DIAP.MTMD_VALOR_SAIDA
                   ELSE 0
                   END )              
                ) MTMD_VALOR_PERDA,                      
             0  MTMD_CUSTO_MEDIO_ATUAL,
             0  MTMD_SALDO_ATUAL,              
             0  MTMD_VALOR_ATUAL    
      FROM TB_CAD_MTMD_MAT_MED MTMD,
           TB_MTMD_MOV_ESTOQUE_DIA DIAP,
           (
             SELECT *
             FROM TB_MTMD_MOV_ESTOQUE_DIA
             WHERE MTMD_MOV_DATA                = dDataIni
             AND   ( pCAD_MTMD_FILIAL_ID IS NULL OR CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID )
             AND   ( pCAD_MTMD_ID IS NULL OR CAD_MTMD_ID = pCAD_MTMD_ID )
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
             AND   MTMD_MOV_DATA >= dDataIni
             AND   MTMD_MOV_DATA <= dDatafIM       
             AND   ( pCAD_MTMD_FILIAL_ID IS NULL OR CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID )
             AND   ( pCAD_MTMD_ID IS NULL OR CAD_MTMD_ID = pCAD_MTMD_ID )       
           ) NOTAS                        
      WHERE DIAP.MTMD_MOV_DATA >= dDataIni
      AND   DIAP.MTMD_MOV_DATA <= dDatafIM
      AND   DIAP.CAD_MTMD_FILIAL_ID            = pCAD_MTMD_FILIAL_ID
      AND   ( pCAD_MTMD_ID IS NULL OR DIAP.CAD_MTMD_ID = pCAD_MTMD_ID )
      AND   ( pCAD_MTMD_GRUPO_ID IS NULL OR DIAP.CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID )
      AND   ( pCAD_MTMD_SUBGRUPO_ID IS NULL OR DIAP.CAD_MTMD_SUBGRUPO_ID = pCAD_MTMD_SUBGRUPO_ID )
      AND  DIAP.CAD_UNI_ID_UNIDADE             = vUnidade
      AND  MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID
      AND  LINHA_ZERO.CAD_MTMD_ID(+)               = DIAP.CAD_MTMD_ID
      AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)        = DIAP.CAD_MTMD_FILIAL_ID
      AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)         = DIAP.CAD_MTMD_GRUPO_ID
      AND  NOTAS.MTMD_MOV_DATA(+)       = DIAP.MTMD_MOV_DATA
      AND  NOTAS.CAD_MTMD_ID(+)         = DIAP.CAD_MTMD_ID
      AND  NOTAS.CAD_MTMD_FILIAL_ID(+)  = DIAP.CAD_MTMD_FILIAL_ID
      AND  NOTAS.CAD_MTMD_TPMOV_ID(+)       = DIAP.CAD_MTMD_TPMOV_ID
      AND  NOTAS.CAD_MTMD_SUBTP_ID(+)       = DIAP.CAD_MTMD_SUBTP_ID
      AND  DIAP.CAD_MTMD_GRUPO_ID NOT IN (40,42)
      GROUP BY MTMD.CAD_MTMD_ID,   
               DIAP.CAD_MTMD_FILIAL_ID,  
               MTMD.CAD_MTMD_NOMEFANTASIA,
               LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR,
               LINHA_ZERO.MTMD_SALDO_ATUAL,       
               LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,
               LINHA_ZERO.MTMD_VALOR_ATUAL,       
               LINHA_ZERO.MTMD_SALDO_ANTERIOR,
               LINHA_ZERO.MTMD_VALOR_ANTERIOR
      HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)+ NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) > 0
      ORDER BY MTMD.CAD_MTMD_NOMEFANTASIA; 
  END IF;
  io_cursor := v_cursor;
end PRC_MTMD_MOV_ESTOQUE_MES_S;

 