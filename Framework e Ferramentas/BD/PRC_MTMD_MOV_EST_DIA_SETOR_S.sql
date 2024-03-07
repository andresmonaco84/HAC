create or replace procedure PRC_MTMD_MOV_EST_DIA_SETOR_S
(
   pMTMD_MOV_MES IN TB_MTMD_MOV_ESTOQUE_MES.MTMD_MOV_MES%type DEFAULT NULL,
   pMTMD_MOV_ANO IN TB_MTMD_MOV_ESTOQUE_MES.MTMD_MOV_ANO%type DEFAULT NULL,
   pCAD_MTMD_FILIAL_ID IN TB_MTMD_MOV_ESTOQUE_MES.CAD_MTMD_FILIAL_ID%type DEFAULT NULL,
   pDEVOLUCAO IN NUMBER DEFAULT NULL, -- 0 ou 1 (se 0 = consumo)
   pQUEBRAS   IN NUMBER DEFAULT NULL, -- 0 = TODAS AS BAIXAS
                                      -- 1 = APENAS BAIXAS REFERENTE A QUEBRAS
                                      -- 2 = TODAS AS BAIXAS MENOS AS QUEBRAS
   io_cursor OUT PKG_CURSOR.t_cursor
) is
/********************************************************************
*    Procedure: PRC_MTMD_MOV_EST_DIA_SETOR_S
*
*    Data Criacao:   25/03/2011   Por: Andre Souza Monaco
*
*    Funcao: Relatorio de fechamento 29 de consumo/devoluc?es/quebras
*            (por grupo/setor-centrocusto)
*******************************************************************/
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
  dDatafIM := TO_DATE( TO_CHAR(LAST_DAY(dDataIni),'DDMMYYYY')||' 0000','DDMMYYYY HH24MI');
  IF (NVL(pDEVOLUCAO,0)=0) THEN --Consumo
      OPEN v_cursor FOR
      SELECT EST_DIA.MTMD_MOV_DATA,
           EST_DIA.CAD_UNI_ID_UNIDADE,
           UNI.CAD_UNI_DS_UNIDADE,
           EST_DIA.CAD_SET_ID,
           SETOR.CAD_SET_DS_SETOR,
           CCUSTO.CAD_CEC_CD_CCUSTO CD_CCUSTO,
           Substr(CCUSTO.CAD_CEC_CD_CCUSTO,0,5) CCUSTO,
           (SELECT CAD_CEC_DS_CCUSTO FROM TB_CAD_CEC_CENTRO_CUSTO WHERE CAD_CEC_CD_CCUSTO = Substr(CCUSTO.CAD_CEC_CD_CCUSTO,0,5)) CCUSTO_DESCRICAO_SINTETICA,
           CCUSTO.CAD_CEC_DS_CCUSTO CCUSTO_DESCRICAO,
           SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,1,EST_DIA.VLR_SAIDA,0))   DROG_MED,    --1
           SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,61,EST_DIA.VLR_SAIDA,0))  PROTESE,     --61
           SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,4,EST_DIA.VLR_SAIDA,0))   ALIMENTO,    --4
           SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,11,EST_DIA.VLR_SAIDA,0))  COPA,        --11
           SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,5,EST_DIA.VLR_SAIDA,0))   IMPRES,      --5
           SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,6,EST_DIA.VLR_SAIDA,0))   MAT_MED_HOSP,--6
           SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,12,EST_DIA.VLR_SAIDA,0))  HIGIE,      -- 12
           SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,8,EST_DIA.VLR_SAIDA,0))   MANUTEN,    -- 8
           SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,9,EST_DIA.VLR_SAIDA,0))   OLEO,       -- 9
           SUM(
                CASE
                   WHEN EST_DIA.CAD_MTMD_GRUPO_ID NOT IN (1,61,4,11,5,6,12,8,9) THEN
                      EST_DIA.VLR_SAIDA
                   ELSE
                      0
                END
              ) OUTROS,
           SUM(
              (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,1,EST_DIA.VLR_SAIDA,0))+
              (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,61,EST_DIA.VLR_SAIDA,0))+
              (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,4,EST_DIA.VLR_SAIDA,0))+
              (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,11,EST_DIA.VLR_SAIDA,0))+
              (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,5,EST_DIA.VLR_SAIDA,0))+
              (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,6,EST_DIA.VLR_SAIDA,0))+
              (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,12,EST_DIA.VLR_SAIDA,0))+
              (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,8,EST_DIA.VLR_SAIDA,0))+
              (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,9,EST_DIA.VLR_SAIDA,0))+
              (CASE
                      WHEN EST_DIA.CAD_MTMD_GRUPO_ID NOT IN (1,61,4,11,5,6,12,8,9) THEN
                         EST_DIA.VLR_SAIDA
                      ELSE
                         0
               END)
           ) TOTAL
      FROM
      (
      SELECT EST_DIA.MTMD_MOV_DATA,
             EST_DIA.CAD_UNI_ID_UNIDADE,
             EST_DIA.CAD_SET_ID,
             EST_DIA.CAD_MTMD_GRUPO_ID,
             SUM(EST_DIA.MTMD_VALOR_SAIDA)    VLR_SAIDA
      FROM
      (SELECT DIAP.MTMD_MOV_DATA,
              DIAP.CAD_UNI_ID_UNIDADE,
              DIAP.CAD_SET_ID,
              DIAP.CAD_MTMD_GRUPO_ID,
              MTMD.CAD_MTMD_ID,
              MTMD.CAD_MTMD_NOMEFANTASIA DESCRICAO,
              SUM(
                  (CASE
                   WHEN (NVL(pQUEBRAS,0) = 0 AND DIAP.CAD_MTMD_SUBTP_ID NOT IN (15)) THEN DIAP.MTMD_VALOR_SAIDA
                   WHEN (NVL(pQUEBRAS,0) = 1 AND DIAP.CAD_MTMD_SUBTP_ID = 6) THEN DIAP.MTMD_VALOR_SAIDA
                   WHEN (NVL(pQUEBRAS,0) = 2 AND DIAP.CAD_MTMD_SUBTP_ID NOT IN (15, 6)) THEN DIAP.MTMD_VALOR_SAIDA
                   ELSE 0
                   END )
                 ) MTMD_VALOR_SAIDA
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
             AND   MTMD_VALOR_ENTRADA != 0
             AND   MTMD_QTDE_ENTRADA > 0
           ) NOTAS
      WHERE DIAP.MTMD_MOV_DATA >= dDataIni
      AND   DIAP.MTMD_MOV_DATA <= dDatafIM
      AND   DIAP.CAD_MTMD_FILIAL_ID             = pCAD_MTMD_FILIAL_ID
      AND  MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID
      AND  LINHA_ZERO.CAD_MTMD_ID(+)            = DIAP.CAD_MTMD_ID
      AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)     = DIAP.CAD_MTMD_FILIAL_ID
      AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)      = DIAP.CAD_MTMD_GRUPO_ID
      AND  NOTAS.MTMD_MOV_DATA(+)       = DIAP.MTMD_MOV_DATA
      AND  NOTAS.CAD_MTMD_ID(+)         = DIAP.CAD_MTMD_ID
      AND  NOTAS.CAD_MTMD_FILIAL_ID(+)  = DIAP.CAD_MTMD_FILIAL_ID
      AND  NOTAS.CAD_MTMD_GRUPO_ID(+)   = DIAP.CAD_MTMD_GRUPO_ID
      AND  NOTAS.CAD_MTMD_SUBGRUPO_ID(+) = DIAP.CAD_MTMD_SUBGRUPO_ID
      AND  NOTAS.CAD_MTMD_TPMOV_ID(+)       = DIAP.CAD_MTMD_TPMOV_ID
      AND  DIAP.CAD_MTMD_GRUPO_ID NOT IN (40,42)
      GROUP BY DIAP.MTMD_MOV_DATA,
               DIAP.CAD_UNI_ID_UNIDADE,
               DIAP.CAD_SET_ID,
               DIAP.CAD_MTMD_GRUPO_ID,
               MTMD.CAD_MTMD_ID,
               DIAP.CAD_MTMD_FILIAL_ID,
               MTMD.CAD_MTMD_NOMEFANTASIA,
               LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR,
               LINHA_ZERO.MTMD_SALDO_ATUAL,
               LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,
               LINHA_ZERO.MTMD_VALOR_ATUAL,
               LINHA_ZERO.MTMD_SALDO_ANTERIOR,
               LINHA_ZERO.MTMD_VALOR_ANTERIOR
      ) EST_DIA
      GROUP BY EST_DIA.MTMD_MOV_DATA,
               EST_DIA.CAD_UNI_ID_UNIDADE,
               EST_DIA.CAD_SET_ID,
               EST_DIA.CAD_MTMD_GRUPO_ID
      ) EST_DIA,
      TB_CAD_UNI_UNIDADE UNI,
      TB_CAD_SET_SETOR   SETOR,
      TB_CAD_CEC_CENTRO_CUSTO CCUSTO
      WHERE UNI.CAD_UNI_ID_UNIDADE = EST_DIA.CAD_UNI_ID_UNIDADE AND
            SETOR.CAD_SET_ID       = EST_DIA.CAD_SET_ID AND
            CCUSTO.CAD_CEC_ID_CCUSTO = FNC_OBTER_CCUSTO(EST_DIA.CAD_SET_ID,
                                                        DECODE(EST_DIA.CAD_MTMD_GRUPO_ID, 1, 'MED', 'MAT'),
                                                        NULL,
                                                        NULL,
                                                        NULL,
                                                        NULL,
                                                        EST_DIA.MTMD_MOV_DATA)
      GROUP BY EST_DIA.MTMD_MOV_DATA,
               EST_DIA.CAD_UNI_ID_UNIDADE,
               EST_DIA.CAD_SET_ID,
               UNI.CAD_UNI_DS_UNIDADE,
               SETOR.CAD_SET_DS_SETOR,
               CCUSTO.CAD_CEC_CD_CCUSTO,
               CCUSTO.CAD_CEC_DS_CCUSTO
      ORDER BY UNI.CAD_UNI_DS_UNIDADE, CCUSTO.CAD_CEC_CD_CCUSTO, EST_DIA.MTMD_MOV_DATA;
  ELSE -- Devoluc?o
      OPEN v_cursor FOR
      SELECT MTMD_MOV_DATA,
             CAD_UNI_ID_UNIDADE,
             CAD_UNI_DS_UNIDADE,
             CD_CCUSTO,
             CCUSTO_DESCRICAO,
             SUM(DROG_MED) DROG_MED,
             SUM(PROTESE) PROTESE,
             SUM(ALIMENTO) ALIMENTO,
             SUM(COPA) COPA,
             SUM(IMPRES) IMPRES,
             SUM(MAT_MED_HOSP) MAT_MED_HOSP,
             SUM(HIGIE) HIGIE,
             SUM(MANUTEN) MANUTEN,
             SUM(OLEO) OLEO,
             SUM(OUTROS) OUTROS,
             SUM(TOTAL) TOTAL
        FROM
      (
      SELECT EST_DIA.MTMD_MOV_DATA,
           244 CAD_UNI_ID_UNIDADE, --EST_DIA.CAD_UNI_ID_UNIDADE,
           'SANTOS' CAD_UNI_DS_UNIDADE, --UNI.CAD_UNI_DS_UNIDADE,
           EST_DIA.CAD_SET_ID,
           SETOR.CAD_SET_DS_SETOR,
           CCUSTO.CAD_CEC_CD_CCUSTO CD_CCUSTO,
           CCUSTO.CAD_CEC_DS_CCUSTO CCUSTO_DESCRICAO,
           SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,1,EST_DIA.MTMD_VALOR_ENTRADA,0))   DROG_MED,    --1
           SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,61,EST_DIA.MTMD_VALOR_ENTRADA,0))  PROTESE,     --61
           SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,4,EST_DIA.MTMD_VALOR_ENTRADA,0))   ALIMENTO,    --4
           SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,11,EST_DIA.MTMD_VALOR_ENTRADA,0))  COPA,        --11
           SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,5,EST_DIA.MTMD_VALOR_ENTRADA,0))   IMPRES,      --5
           SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,6,EST_DIA.MTMD_VALOR_ENTRADA,0))   MAT_MED_HOSP,--6
           SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,12,EST_DIA.MTMD_VALOR_ENTRADA,0))   HIGIE,      -- 12
           SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,8,EST_DIA.MTMD_VALOR_ENTRADA,0))    MANUTEN,    -- 8
           SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,9,EST_DIA.MTMD_VALOR_ENTRADA,0))    OLEO,       -- 9
           SUM(
               CASE
                  WHEN EST_DIA.CAD_MTMD_GRUPO_ID NOT IN (1,61,4,11,5,6,12,8,9) THEN
                     EST_DIA.MTMD_VALOR_ENTRADA
                  ELSE
                     0
               END
              ) OUTROS,
           SUM(
              (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,1,EST_DIA.MTMD_VALOR_ENTRADA,0))+
              (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,61,EST_DIA.MTMD_VALOR_ENTRADA,0))+
              (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,4,EST_DIA.MTMD_VALOR_ENTRADA,0))+
              (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,11,EST_DIA.MTMD_VALOR_ENTRADA,0))+
              (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,5,EST_DIA.MTMD_VALOR_ENTRADA,0))+
              (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,6,EST_DIA.MTMD_VALOR_ENTRADA,0))+
              (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,12,EST_DIA.MTMD_VALOR_ENTRADA,0))+
              (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,8,EST_DIA.MTMD_VALOR_ENTRADA,0))+
              (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,9,EST_DIA.MTMD_VALOR_ENTRADA,0))+
              (CASE
                      WHEN EST_DIA.CAD_MTMD_GRUPO_ID NOT IN (1,61,4,11,5,6,12,8,9) THEN
                         EST_DIA.MTMD_VALOR_ENTRADA
                      ELSE
                         0
                   END)
           ) TOTAL
      FROM
      (
      SELECT EST_DIA.MTMD_MOV_DATA,
             EST_DIA.CAD_UNI_ID_UNIDADE,
             EST_DIA.CAD_SET_ID,
             EST_DIA.CAD_MTMD_GRUPO_ID,
             SUM(EST_DIA.MTMD_VALOR_ENTRADA)    MTMD_VALOR_ENTRADA
      FROM
      (SELECT DIAP.MTMD_MOV_DATA,
              DIAP.CAD_UNI_ID_UNIDADE,
              DIAP.CAD_SET_ID,
              DIAP.CAD_MTMD_GRUPO_ID,
              MTMD.CAD_MTMD_ID,
              MTMD.CAD_MTMD_NOMEFANTASIA DESCRICAO,
              SUM(
                   (CASE
                     WHEN (DIAP.CAD_MTMD_SUBTP_ID NOT IN (1)) THEN DIAP.MTMD_VALOR_ENTRADA
                     ELSE 0
                     END )
                 ) MTMD_VALOR_ENTRADA
      FROM TB_CAD_MTMD_MAT_MED MTMD,
           TB_MTMD_MOV_ESTOQUE_DIA DIAP,
           (
             SELECT CAD_MTMD_ID, CAD_MTMD_FILIAL_ID, CAD_MTMD_GRUPO_ID, CAD_MTMD_SUBGRUPO_ID, MTMD_VALOR_ATUAL, MTMD_VALOR_ANTERIOR
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
             SELECT CAD_MTMD_ID, MTMD_MOV_DATA, CAD_MTMD_FILIAL_ID, CAD_MTMD_TPMOV_ID, CAD_MTMD_SUBTP_ID, CAD_MTMD_SUBGRUPO_ID, CAD_MTMD_GRUPO_ID
             FROM TB_MTMD_MOV_ESTOQUE_DIA
             WHERE CAD_MTMD_TPMOV_ID            = 1
             AND   CAD_MTMD_SUBTP_ID            = 1
             AND   MTMD_MOV_DATA >= dDataIni
             AND   MTMD_MOV_DATA <= dDatafIM
             AND   (pCAD_MTMD_FILIAL_ID IS NULL OR CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID)
             AND   MTMD_VALOR_ENTRADA != 0
             AND   MTMD_QTDE_ENTRADA > 0
           ) NOTAS
      WHERE DIAP.MTMD_MOV_DATA >= dDataIni
      AND   DIAP.MTMD_MOV_DATA <= dDatafIM
      AND   DIAP.CAD_MTMD_FILIAL_ID             = pCAD_MTMD_FILIAL_ID
      AND  MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID
      AND  LINHA_ZERO.CAD_MTMD_ID(+)            = DIAP.CAD_MTMD_ID
      AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)     = DIAP.CAD_MTMD_FILIAL_ID
      AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)      = DIAP.CAD_MTMD_GRUPO_ID
      AND  NOTAS.MTMD_MOV_DATA(+)       = DIAP.MTMD_MOV_DATA
      AND  NOTAS.CAD_MTMD_ID(+)         = DIAP.CAD_MTMD_ID
      AND  NOTAS.CAD_MTMD_FILIAL_ID(+)  = DIAP.CAD_MTMD_FILIAL_ID
      AND  NOTAS.CAD_MTMD_GRUPO_ID(+)   = DIAP.CAD_MTMD_GRUPO_ID
      AND  NOTAS.CAD_MTMD_SUBGRUPO_ID(+) = DIAP.CAD_MTMD_SUBGRUPO_ID
      AND  NOTAS.CAD_MTMD_TPMOV_ID(+)       = DIAP.CAD_MTMD_TPMOV_ID
      AND  DIAP.CAD_MTMD_GRUPO_ID NOT IN (40,42)
      GROUP BY DIAP.MTMD_MOV_DATA,
               DIAP.CAD_UNI_ID_UNIDADE,
               DIAP.CAD_SET_ID,
               DIAP.CAD_MTMD_GRUPO_ID,
               MTMD.CAD_MTMD_ID,
               DIAP.CAD_MTMD_FILIAL_ID,
               MTMD.CAD_MTMD_NOMEFANTASIA
      ) EST_DIA
      GROUP BY EST_DIA.MTMD_MOV_DATA,
               EST_DIA.CAD_UNI_ID_UNIDADE,
               EST_DIA.CAD_SET_ID,
               EST_DIA.CAD_MTMD_GRUPO_ID
      ) EST_DIA,
      TB_CAD_UNI_UNIDADE UNI,
      TB_CAD_SET_SETOR   SETOR,
      TB_CAD_CEC_CENTRO_CUSTO CCUSTO
      WHERE UNI.CAD_UNI_ID_UNIDADE = EST_DIA.CAD_UNI_ID_UNIDADE AND
            SETOR.CAD_SET_ID       = EST_DIA.CAD_SET_ID AND
            CCUSTO.CAD_CEC_ID_CCUSTO = FNC_OBTER_CCUSTO(EST_DIA.CAD_SET_ID,
                                                        DECODE(EST_DIA.CAD_MTMD_GRUPO_ID, 1, 'MED', 'MAT'),
                                                        NULL,
                                                        NULL,
                                                        NULL,
                                                        NULL,
                                                        EST_DIA.MTMD_MOV_DATA)
      GROUP BY EST_DIA.MTMD_MOV_DATA,
               EST_DIA.CAD_UNI_ID_UNIDADE,
               EST_DIA.CAD_SET_ID,
               UNI.CAD_UNI_DS_UNIDADE,
               SETOR.CAD_SET_DS_SETOR,
               CCUSTO.CAD_CEC_CD_CCUSTO,
               CCUSTO.CAD_CEC_DS_CCUSTO
      HAVING SUM(
                  (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,1,EST_DIA.MTMD_VALOR_ENTRADA,0))+
                  (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,61,EST_DIA.MTMD_VALOR_ENTRADA,0))+
                  (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,4,EST_DIA.MTMD_VALOR_ENTRADA,0))+
                  (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,11,EST_DIA.MTMD_VALOR_ENTRADA,0))+
                  (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,5,EST_DIA.MTMD_VALOR_ENTRADA,0))+
                  (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,6,EST_DIA.MTMD_VALOR_ENTRADA,0))+
                  (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,12,EST_DIA.MTMD_VALOR_ENTRADA,0))+
                  (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,8,EST_DIA.MTMD_VALOR_ENTRADA,0))+
                  (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,9,EST_DIA.MTMD_VALOR_ENTRADA,0))+
                  (CASE
                          WHEN EST_DIA.CAD_MTMD_GRUPO_ID NOT IN (1,61,4,11,5,6,12,8,9) THEN
                             EST_DIA.MTMD_VALOR_ENTRADA
                          ELSE
                             0
                       END)
               ) > 0
      )
      GROUP BY MTMD_MOV_DATA,
               CAD_UNI_ID_UNIDADE,
               CAD_UNI_DS_UNIDADE,
               CD_CCUSTO,
               CCUSTO_DESCRICAO
      ORDER BY CD_CCUSTO, MTMD_MOV_DATA;
  END IF;
  io_cursor := v_cursor;
end PRC_MTMD_MOV_EST_DIA_SETOR_S;