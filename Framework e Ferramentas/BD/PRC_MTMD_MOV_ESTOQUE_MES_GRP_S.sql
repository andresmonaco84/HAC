CREATE OR REPLACE PROCEDURE PRC_MTMD_MOV_ESTOQUE_MES_GRP_S
(
     pMTMD_MOV_MES IN TB_MTMD_MOV_ESTOQUE_MES.MTMD_MOV_MES%type DEFAULT NULL,
     pMTMD_MOV_ANO IN TB_MTMD_MOV_ESTOQUE_MES.MTMD_MOV_ANO%type DEFAULT NULL,
     pCAD_MTMD_FILIAL_ID IN TB_MTMD_MOV_ESTOQUE_MES.CAD_MTMD_FILIAL_ID%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     pCAD_MTMD_FL_PADRAO IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_PADRAO%type DEFAULT NULL,
     pCOLUNAS_INVENTARIO NUMBER DEFAULT NULL, -- 0 ou 1
     io_cursor OUT PKG_CURSOR.t_cursor
) is
/********************************************************************
  *    Procedure: PRC_MTMD_MOV_ESTOQUE_MES_GRP_S
  *
  *    Data Criacao:   01/2011   Por: RICARDO COSTA
  *    Data Alteracao:   24/03/2011  Por: Andre
  *         Alterac?o: Adic?o do param. pCAD_UNI_ID_UNIDADE
  *    Data Alteracao:   13/06/2011  Por: Andre
  *         Alterac?o: Adic?o dos campos para diferenciar o consumo das perdas
  *
  *    Funcao: Relatorio de fechamento mensal 25 (por grupo/subgrupo)
  *******************************************************************/
  vUnidade TB_MTMD_MOV_ESTOQUE_MES.CAD_UNI_ID_UNIDADE%type := 244; --SANTOS
  dDataIni DATE;
  dDataFim DATE;
  sMes     VARCHAR2(2);
  v_cursor PKG_CURSOR.t_cursor;
begin
  IF (  LENGTH(TO_CHAR(pMTMD_MOV_MES)) = 1 ) THEN
     sMes := '0'||TO_CHAR(pMTMD_MOV_MES);
  ELSE
     sMes := TO_CHAR(pMTMD_MOV_MES);
  END IF;
  dDataIni := TO_DATE( '01'||TO_CHAR(sMes)||TO_CHAR(pMTMD_MOV_ANO)||' 0000','DDMMYYYY HH24MI');
  dDatafIM := TO_DATE( TO_CHAR(LAST_DAY(dDataIni),'DDMMYYYY')||' 2359','DDMMYYYY HH24MI');
  IF (pCAD_UNI_ID_UNIDADE IS NOT NULL AND pCAD_UNI_ID_UNIDADE != 244) THEN
     vUnidade := pCAD_UNI_ID_UNIDADE;
  END IF;
  IF (vUnidade = 244) THEN
      IF (NVL(pCOLUNAS_INVENTARIO,0) = 0) THEN
        OPEN v_cursor FOR
        SELECT EST_DIA.CAD_MTMD_GRUPO_ID,
               GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
               EST_DIA.CAD_MTMD_SUBGRUPO_ID,
               SUBG.CAD_MTMD_SUBGRUPO_ID||' '||SUBG.CAD_MTMD_SUBGRUPO_DESCRICAO CAD_MTMD_SUBGRUPO_DESCRICAO,
               SUM(EST_DIA.MTMD_SALDO_ANTERIOR) ANTERIOR,
               SUM(EST_DIA.MTMD_VALOR_ANTERIOR) VLR_ANTERIOR,
               SUM(EST_DIA.MTMD_QTDE_ENTRADA )  ENTRADAS,
               SUM(EST_DIA.MTMD_VALOR_ENTRADA)  VLR_ENTRADA,
               SUM(EST_DIA.MTMD_QTDE_DEVOLUCAO) DEVOLUCAO,
               SUM(EST_DIA.MTMD_VLR_DEVOLUCAO)  VLR_DEVOLUCAO,
               SUM(EST_DIA.MTMD_QTDE_SAIDA)     SAIDAS,
               SUM(EST_DIA.MTMD_VALOR_SAIDA)    VLR_SAIDA,
               SUM(EST_DIA.MTMD_QTDE_CONSUMO)   CONSUMOS,
               SUM(EST_DIA.MTMD_VALOR_CONSUMO)  VLR_CONSUMO,
               SUM(EST_DIA.MTMD_QTDE_PERDA)     PERDAS,
               SUM(EST_DIA.MTMD_VALOR_PERDA)    VLR_PERDA,
               SUM(EST_DIA.MTMD_SALDO_ATUAL)    SALDO_ATUAL,
               SUM(EST_DIA.MTMD_VALOR_ATUAL)    VLR_ATUAL
          FROM
          --(SELECT MTMD.CAD_MTMD_ID,MTMD.CAD_MTMD_GRUPO_ID, MTMD.CAD_MTMD_SUBGRUPO_ID,
            (SELECT MTMD.CAD_MTMD_ID,
                    DIAP.CAD_MTMD_GRUPO_ID,
                    DIAP.CAD_MTMD_SUBGRUPO_ID,
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
                 LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL          MTMD_CUSTO_MEDIO_ATUAL,
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
                 WHERE MTMD_MOV_DATA                = dDataIni
                 AND   (pCAD_MTMD_FILIAL_ID IS NULL OR CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID)
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
                 AND   (pCAD_MTMD_FILIAL_ID IS NULL OR CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID)
                 --AND   MTMD_VALOR_ENTRADA != 0
                 --AND   MTMD_QTDE_ENTRADA > 0
               ) NOTAS
          WHERE DIAP.MTMD_MOV_DATA >= dDataIni
          AND   DIAP.MTMD_MOV_DATA <= dDatafIM
          AND   DIAP.CAD_MTMD_FILIAL_ID             = pCAD_MTMD_FILIAL_ID
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
          AND  (pCAD_MTMD_FL_PADRAO is null OR MTMD.CAD_MTMD_FL_PADRAO = pCAD_MTMD_FL_PADRAO)
          GROUP BY MTMD.CAD_MTMD_ID,
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
          GROUP BY EST_DIA.CAD_MTMD_GRUPO_ID,
                   GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
                   EST_DIA.CAD_MTMD_SUBGRUPO_ID,
                   SUBG.CAD_MTMD_SUBGRUPO_ID,
                   SUBG.CAD_MTMD_SUBGRUPO_DESCRICAO
          ORDER BY EST_DIA.CAD_MTMD_GRUPO_ID, EST_DIA.CAD_MTMD_SUBGRUPO_ID;
              /*SELECT DIAP.CAD_MTMD_GRUPO_ID,
                   GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
                   DIAP.CAD_MTMD_SUBGRUPO_ID,
                   SUBG.CAD_MTMD_SUBGRUPO_ID||' '||SUBG.CAD_MTMD_SUBGRUPO_DESCRICAO CAD_MTMD_SUBGRUPO_DESCRICAO,
                   SUM(DIAP.MTMD_SALDO_ANTERIOR) anterior,
                   SUM(DIAP.MTMD_VALOR_ANTERIOR) VLR_ANTERIOR,
                   SUM(DIAP.MTMD_QTDE_ENTRADA )        ENTRADAS,
                   SUM(DIAP.MTMD_VALOR_ENTRADA) VLR_ENTRADA,
                   SUM(DIAP.MTMD_QTDE_SAIDA)           SAIDAS,
                   SUM(DIAP.MTMD_VALOR_SAIDA) VLR_SAIDA,
                   SUM(DIAP.MTMD_SALDO_ATUAL)    SALDO_ATUAL,
                   SUM(DIAP.MTMD_VALOR_ATUAL)      VLR_ATUAL
            FROM  SGS.TB_MTMD_MOV_ESTOQUE_DIA DIAP,
                 TB_CAD_MTMD_GRUPO            GRUPO,
                 TB_CAD_MTMD_SUBGRUPO         SUBG
            WHERE DIAP.MTMD_MOV_DATA >= dDataIni
            AND   DIAP.MTMD_MOV_DATA <= dDatafIM
            AND   DIAP.CAD_MTMD_FILIAL_ID     = pCAD_MTMD_FILIAL_ID
            -- AND   mes.cad_mtmd_grupo_id      IN (1,2,4,5,6,8,9,11,12,61 )
            -- AND   MES.CAD_MTMD_GRUPO_ID      = 1
            -- AND   MES.CAD_MTMD_SUBGRUPO_ID   = 13
            AND   GRUPO.CAD_MTMD_GRUPO_ID(+)    = DIAP.CAD_MTMD_GRUPO_ID
            AND   SUBG.CAD_MTMD_GRUPO_ID(+)     = DIAP.CAD_MTMD_GRUPO_ID
            AND   SUBG.CAD_MTMD_SUBGRUPO_ID(+)  = DIAP.CAD_MTMD_SUBGRUPO_ID
            GROUP BY DIAP.CAD_MTMD_GRUPO_ID,
                     GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
                     DIAP.CAD_MTMD_SUBGRUPO_ID,
                     SUBG.CAD_MTMD_SUBGRUPO_ID||' '||SUBG.CAD_MTMD_SUBGRUPO_DESCRICAO
            ORDER BY DIAP.CAD_MTMD_GRUPO_ID,       DIAP.CAD_MTMD_SUBGRUPO_ID;
            */
            /*
              SELECT MES.CAD_MTMD_GRUPO_ID,
                   GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
                   MES.CAD_MTMD_SUBGRUPO_ID,
                   SUBG.CAD_MTMD_SUBGRUPO_ID||' '||SUBG.CAD_MTMD_SUBGRUPO_DESCRICAO CAD_MTMD_SUBGRUPO_DESCRICAO,
                   SUM(MES.MTMD_MOV_ESTOQUE_ANTERIOR) anterior,
                   SUM(MES.MTMD_VALOR_TOTAL_ANTERIOR) VLR_ANTERIOR,
                   SUM(MES.MTMD_QTDE_ENTRADA )        ENTRADAS,
                   SUM(MES.MTMD_VALOR_TOTAL_MES_ENTRADA) VLR_ENTRADA,
                   SUM(MES.MTMD_QTDE_SAIDA)           SAIDAS,
                   SUM(MES.MTMD_VALOR_TOTAL_MES_SAIDA) VLR_SAIDA,
                   SUM(MES.MTMD_MOV_ESTOQUE_ATUAL)    SALDO_ATUAL,
                   SUM(MES.MTMD_VALOR_TOTAL_MES)      VLR_ATUAL
            FROM  SGS.TB_MTMD_MOV_ESTOQUE_MES MES,
                 TB_CAD_MTMD_GRUPO            GRUPO,
                 TB_CAD_MTMD_SUBGRUPO         SUBG
            WHERE MES.MTMD_MOV_MES           = pMTMD_MOV_MES
            AND   MES.MTMD_MOV_ANO           = pMTMD_MOV_ANO
            AND   MES.CAD_MTMD_FILIAL_ID     = pCAD_MTMD_FILIAL_ID
            -- AND   mes.cad_mtmd_grupo_id      IN (1,2,4,5,6,8,9,11,12,61 )
            -- AND   MES.CAD_MTMD_GRUPO_ID      = 1
            -- AND   MES.CAD_MTMD_SUBGRUPO_ID   = 13
            AND   GRUPO.CAD_MTMD_GRUPO_ID(+)    = MES.CAD_MTMD_GRUPO_ID
            AND   SUBG.CAD_MTMD_GRUPO_ID(+)     = MES.CAD_MTMD_GRUPO_ID
            AND   SUBG.CAD_MTMD_SUBGRUPO_ID(+)  = MES.CAD_MTMD_SUBGRUPO_ID
            GROUP BY MES.CAD_MTMD_GRUPO_ID,
                   GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
                   MES.CAD_MTMD_SUBGRUPO_ID,
                   SUBG.CAD_MTMD_SUBGRUPO_ID||' '||SUBG.CAD_MTMD_SUBGRUPO_DESCRICAO
            ORDER BY MES.CAD_MTMD_GRUPO_ID,       MES.CAD_MTMD_SUBGRUPO_ID; */
      ELSE
        OPEN v_cursor FOR
        SELECT EST_DIA.CAD_MTMD_GRUPO_ID,
             GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
             EST_DIA.CAD_MTMD_SUBGRUPO_ID,
             SUBG.CAD_MTMD_SUBGRUPO_ID||' '||SUBG.CAD_MTMD_SUBGRUPO_DESCRICAO CAD_MTMD_SUBGRUPO_DESCRICAO,
             SUM(EST_DIA.MTMD_SALDO_ANTERIOR) ANTERIOR,
             SUM(EST_DIA.MTMD_VALOR_ANTERIOR) VLR_ANTERIOR,
             SUM(EST_DIA.MTMD_SALDO_ANT_CONT) ANTERIOR_CONT,
             SUM(EST_DIA.MTMD_VALOR_ANT_CONT) VLR_ANTERIOR_CONT,
             SUM(EST_DIA.MTMD_QTDE_ENTRADA )  ENTRADAS,
             SUM(EST_DIA.MTMD_VALOR_ENTRADA)  VLR_ENTRADA,
             SUM(EST_DIA.MTMD_QTDE_DEVOLUCAO) DEVOLUCAO,
             SUM(EST_DIA.MTMD_VLR_DEVOLUCAO)  VLR_DEVOLUCAO,
             SUM(EST_DIA.MTMD_QTDE_SAIDA)     SAIDAS,
             SUM(EST_DIA.MTMD_VALOR_SAIDA)    VLR_SAIDA,
             SUM(EST_DIA.MTMD_QTDE_CONSUMO)   CONSUMOS,
             SUM(EST_DIA.MTMD_VALOR_CONSUMO)  VLR_CONSUMO,
             SUM(EST_DIA.MTMD_QTDE_PERDA)     PERDAS,
             SUM(EST_DIA.MTMD_VALOR_PERDA)    VLR_PERDA,
             SUM(EST_DIA.MTMD_SALDO_ATUAL)    SALDO_ATUAL,
             SUM(EST_DIA.MTMD_VALOR_ATUAL)    VLR_ATUAL,
             SUM(EST_DIA.MTMD_SALDO_ATUAL_CONT) SALDO_ATUAL_CONT,
             SUM(EST_DIA.MTMD_VALOR_ATUAL_CONT) VLR_ATUAL_CONT,
             SUM(EST_DIA.MTMD_VLR_ENTRADA_INVENTARIO) MTMD_VLR_ENTRADA_INVENTARIO,
             SUM(EST_DIA.MTMD_VALOR_BAIXA_INVENTARIO) MTMD_VALOR_BAIXA_INVENTARIO,
             SUM(EST_DIA.MTMD_QTDE_ENTRADA_INVENTARIO) MTMD_QTDE_ENTRADA_INVENTARIO,
             SUM(EST_DIA.MTMD_QTDE_BAIXA_INVENTARIO) MTMD_QTDE_BAIXA_INVENTARIO,
             SUM(EST_DIA.MTMD_QTDE_ENTRADA_EMPRESTIMO) QTD_ENTRADA_EMPRESTIMO,
             SUM(EST_DIA.MTMD_VLR_ENTRADA_EMPRESTIMO) VLR_ENTRADA_EMPRESTIMO,
             SUM(EST_DIA.MTMD_QTDE_BAIXA_EMPRESTIMO) QTD_BAIXA_EMPRESTIMO,
             SUM(EST_DIA.MTMD_VALOR_BAIXA_EMPRESTIMO) VLR_BAIXA_EMPRESTIMO
          FROM
          --(SELECT MTMD.CAD_MTMD_ID,MTMD.CAD_MTMD_GRUPO_ID, MTMD.CAD_MTMD_SUBGRUPO_ID,
            (SELECT MTMD.CAD_MTMD_ID,
                    DIAP.CAD_MTMD_GRUPO_ID,
                    DIAP.CAD_MTMD_SUBGRUPO_ID,
                 MTMD.CAD_MTMD_NOMEFANTASIA DESCRICAO,
                 (  -- se saldo inicial for zero n?o retorna custo medio
                    CASE
                       WHEN LINHA_ZERO.MTMD_SALDO_ANTERIOR = 0 THEN 0
                       ELSE LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR
                    END
                 )                                          MTMD_CUSTO_MEDIO_ANTERIOR,
                 LINHA_ZERO.MTMD_SALDO_ANTERIOR             MTMD_SALDO_ANTERIOR,
                 LINHA_ZERO.MTMD_VALOR_ANTERIOR             MTMD_VALOR_ANTERIOR,
                 LINHA_ZERO.MTMD_SALDO_ANT_CONT             MTMD_SALDO_ANT_CONT,
                 LINHA_ZERO.MTMD_VALOR_ANT_CONT             MTMD_VALOR_ANT_CONT,
                 LINHA_ZERO.MTMD_SALDO_ATUAL                MTMD_SALDO_ATUAL,
                 LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL          MTMD_CUSTO_MEDIO_ATUAL,
                 LINHA_ZERO.MTMD_VALOR_ATUAL                MTMD_VALOR_ATUAL,
                 LINHA_ZERO.MTMD_SALDO_ATUAL_CONT           MTMD_SALDO_ATUAL_CONT,
                 LINHA_ZERO.MTMD_VALOR_ATUAL_CONT           MTMD_VALOR_ATUAL_CONT,
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
                       WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15, 6, 43, 64, 65) THEN DIAP.MTMD_QTDE_SAIDA -- nao inclui estorno de nota fiscal, nem perdas, nem inventatio
                       ELSE 0
                       END )
                  )   MTMD_QTDE_CONSUMO,
                 SUM(
                     (CASE
                       WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15, 6, 43, 64, 65) THEN DIAP.MTMD_VALOR_SAIDA   -- nao inclui estorno de nota fiscal, nem perdas, nem inventatio
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
                       WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (1, 44, 62, 63) THEN DIAP.MTMD_QTDE_ENTRADA
                       ELSE 0
                       END )
                     ) MTMD_QTDE_DEVOLUCAO,  -- OUTRAS ENTRAS QUE NAO SEJA NF
                 SUM( (CASE
                       WHEN (DIAP.CAD_MTMD_SUBTP_ID NOT IN (1, 44, 62, 63)) THEN DIAP.MTMD_VALOR_ENTRADA
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
                    ) MTMD_VLR_ENTRADA_INVENTARIO,
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
                      ) MTMD_VLR_ENTRADA_EMPRESTIMO
          FROM TB_CAD_MTMD_MAT_MED MTMD,
               TB_MTMD_MOV_ESTOQUE_DIA DIAP,
               (
                 SELECT *
                 FROM TB_MTMD_MOV_ESTOQUE_DIA
                 WHERE MTMD_MOV_DATA                = dDataIni
                 AND   (pCAD_MTMD_FILIAL_ID IS NULL OR CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID)
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
                 AND   (pCAD_MTMD_FILIAL_ID IS NULL OR CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID)
                 --AND   MTMD_VALOR_ENTRADA != 0
                 --AND   MTMD_QTDE_ENTRADA > 0
               ) NOTAS
          WHERE DIAP.MTMD_MOV_DATA >= dDataIni
          AND   DIAP.MTMD_MOV_DATA <= dDatafIM
          AND   DIAP.CAD_MTMD_FILIAL_ID             = pCAD_MTMD_FILIAL_ID
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
          AND  (pCAD_MTMD_FL_PADRAO is null OR MTMD.CAD_MTMD_FL_PADRAO = pCAD_MTMD_FL_PADRAO)
          GROUP BY MTMD.CAD_MTMD_ID,
                   DIAP.CAD_MTMD_FILIAL_ID,
                   MTMD.CAD_MTMD_NOMEFANTASIA,
                   LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR,
                   LINHA_ZERO.MTMD_SALDO_ATUAL,
                   LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,
                   LINHA_ZERO.MTMD_VALOR_ATUAL,
                   LINHA_ZERO.MTMD_SALDO_ANTERIOR,
                   LINHA_ZERO.MTMD_VALOR_ANTERIOR,
                   LINHA_ZERO.MTMD_SALDO_ANT_CONT,
                   LINHA_ZERO.MTMD_VALOR_ANT_CONT,
                   LINHA_ZERO.MTMD_SALDO_ATUAL_CONT,
                   LINHA_ZERO.MTMD_VALOR_ATUAL_CONT,
                   DIAP.CAD_MTMD_GRUPO_ID,
                   DIAP.CAD_MTMD_SUBGRUPO_ID
          HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0) + NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) <> 0) EST_DIA,
           TB_CAD_MTMD_GRUPO            GRUPO,
           TB_CAD_MTMD_SUBGRUPO         SUBG
          WHERE GRUPO.CAD_MTMD_GRUPO_ID (+)= EST_DIA.CAD_MTMD_GRUPO_ID AND
                SUBG.CAD_MTMD_SUBGRUPO_ID (+)= EST_DIA.CAD_MTMD_SUBGRUPO_ID AND
                SUBG.CAD_MTMD_GRUPO_ID (+)= EST_DIA.CAD_MTMD_GRUPO_ID
          GROUP BY EST_DIA.CAD_MTMD_GRUPO_ID,
                   GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
                   EST_DIA.CAD_MTMD_SUBGRUPO_ID,
                   SUBG.CAD_MTMD_SUBGRUPO_ID,
                   SUBG.CAD_MTMD_SUBGRUPO_DESCRICAO
          ORDER BY EST_DIA.CAD_MTMD_GRUPO_ID, EST_DIA.CAD_MTMD_SUBGRUPO_ID;
      END IF;
  ELSE
      OPEN v_cursor FOR
      SELECT EST_DIA.CAD_MTMD_GRUPO_ID,
           GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
           EST_DIA.CAD_MTMD_SUBGRUPO_ID,
           SUBG.CAD_MTMD_SUBGRUPO_ID||' '||SUBG.CAD_MTMD_SUBGRUPO_DESCRICAO CAD_MTMD_SUBGRUPO_DESCRICAO,
           0 ANTERIOR,
           0 VLR_ANTERIOR,
           SUM(EST_DIA.MTMD_QTDE_SAIDA ) ENTRADAS,
           SUM(EST_DIA.MTMD_VALOR_SAIDA) VLR_ENTRADA,
           0 DEVOLUCAO,
           0 VLR_DEVOLUCAO,
           --N?o demonstrar devoluc?es
           /*SUM(EST_DIA.MTMD_QTDE_SAIDA)-SUM(EST_DIA.MTMD_QTDE_DEVOLUCAO ) ENTRADAS,
           SUM(EST_DIA.MTMD_VALOR_SAIDA)-SUM(EST_DIA.MTMD_VLR_DEVOLUCAO)   VLR_ENTRADA,
           SUM(EST_DIA.MTMD_QTDE_DEVOLUCAO ) DEVOLUCAO,
           SUM(EST_DIA.MTMD_VLR_DEVOLUCAO) VLR_DEVOLUCAO,*/
           SUM(EST_DIA.MTMD_QTDE_SAIDA)    SAIDAS,
           SUM(EST_DIA.MTMD_VALOR_SAIDA)   VLR_SAIDA,
           SUM(EST_DIA.MTMD_QTDE_CONSUMO)  CONSUMOS,
           SUM(EST_DIA.MTMD_VALOR_CONSUMO) VLR_CONSUMO,
           SUM(EST_DIA.MTMD_QTDE_PERDA)    PERDAS,
           SUM(EST_DIA.MTMD_VALOR_PERDA)   VLR_PERDA,
           0 SALDO_ATUAL,
           0 VLR_ATUAL
        FROM
        --(SELECT MTMD.CAD_MTMD_ID,MTMD.CAD_MTMD_GRUPO_ID, MTMD.CAD_MTMD_SUBGRUPO_ID,
          (SELECT MTMD.CAD_MTMD_ID,
                  DIAP.CAD_MTMD_GRUPO_ID,
                  DIAP.CAD_MTMD_SUBGRUPO_ID,
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
               LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL          MTMD_CUSTO_MEDIO_ATUAL,
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
               WHERE MTMD_MOV_DATA                = dDataIni
               AND   (pCAD_MTMD_FILIAL_ID IS NULL OR CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID)
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
               AND   (pCAD_MTMD_FILIAL_ID IS NULL OR CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID)
               --AND   MTMD_VALOR_ENTRADA != 0
               AND   MTMD_QTDE_ENTRADA > 0
             ) NOTAS
        WHERE DIAP.MTMD_MOV_DATA >= dDataIni
        AND   DIAP.MTMD_MOV_DATA <= dDatafIM
        AND   DIAP.CAD_MTMD_FILIAL_ID             = pCAD_MTMD_FILIAL_ID
        AND  DIAP.CAD_UNI_ID_UNIDADE              = vUnidade
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
        AND  (pCAD_MTMD_FL_PADRAO is null OR MTMD.CAD_MTMD_FL_PADRAO = pCAD_MTMD_FL_PADRAO)
        GROUP BY MTMD.CAD_MTMD_ID,
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
        GROUP BY EST_DIA.CAD_MTMD_GRUPO_ID,
                 GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
                 EST_DIA.CAD_MTMD_SUBGRUPO_ID,
                 SUBG.CAD_MTMD_SUBGRUPO_ID,
                 SUBG.CAD_MTMD_SUBGRUPO_DESCRICAO
        ORDER BY EST_DIA.CAD_MTMD_GRUPO_ID, EST_DIA.CAD_MTMD_SUBGRUPO_ID;
  END IF;
  io_cursor := v_cursor;
end PRC_MTMD_MOV_ESTOQUE_MES_GRP_S;