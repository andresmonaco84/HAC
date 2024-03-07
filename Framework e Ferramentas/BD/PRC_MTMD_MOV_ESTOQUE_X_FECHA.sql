create or replace procedure PRC_MTMD_MOV_ESTOQUE_X_FECHA
(
     pMTMD_MOV_MES IN TB_MTMD_MOV_ESTOQUE_MES.MTMD_MOV_MES%type DEFAULT NULL,
     pMTMD_MOV_ANO IN TB_MTMD_MOV_ESTOQUE_MES.MTMD_MOV_ANO%type DEFAULT NULL,
     pCAD_MTMD_FILIAL_ID IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_FILIAL_ID%type DEFAULT NULL,
     pCAD_MTMD_GRUPO_ID IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_GRUPO_ID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) is
/********************************************************************
  *    Procedure: PRC_MTMD_MOV_ESTOQUE_X_FECHA
  *
  *    Data Criacao:   30/09/2011   Por: Andre Souza Monaco
  *
  *    Funcao: lista o que tinha no estoque com o fechamento contabil
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
  dDatafIM := TO_DATE( TO_CHAR(LAST_DAY(dDataIni),'DDMMYYYY')||' 2359','DDMMYYYY HH24MI');
  OPEN v_cursor FOR
  SELECT MTMD.CAD_MTMD_ID,
         MTMD.CAD_MTMD_NOMEFANTASIA DESCRICAO,
         MTMD.CAD_MTMD_CODMNE,
         MTMD.CAD_MTMD_UNID_CONTROLE_DS,
         LINHA_ZERO.CAD_MTMD_GRUPO_ID,
         LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID,
         GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
         SUBGRUPO.CAD_MTMD_SUBGRUPO_DESCRICAO,
         --DECODE( LINHA_ZERO.MTMD_SALDO_ATUAL, 0, 0, LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL)  MTMD_CUSTO_MEDIO,
         LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL MTMD_CUSTO_MEDIO,
         (SELECT NVL(SUM(MTMD_MOV_SALDO),0)
            FROM (SELECT * FROM TB_MTMD_MOV_MES MM
                   WHERE MM.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID AND
                         --MM.CAD_MTMD_ID = MTMD.CAD_MTMD_ID AND
                         --MM.MTMD_MOV_MES <= pMTMD_MOV_MES AND
                         --MM.MTMD_MOV_ANO <= pMTMD_MOV_ANO
                         --(MM.MTMD_MOV_MES <= DECODE(pMTMD_MOV_MES, 1, 12, pMTMD_MOV_MES) OR MM.MTMD_MOV_MES <= pMTMD_MOV_MES) AND
                         --(MM.MTMD_MOV_ANO <= DECODE(pMTMD_MOV_MES, 1, pMTMD_MOV_ANO-1, pMTMD_MOV_ANO) OR MM.MTMD_MOV_ANO <= pMTMD_MOV_ANO)
                         MM.MTMD_MOV_ANO || LPAD(MM.MTMD_MOV_MES, 2, '0') <= pMTMD_MOV_ANO || LPAD(TO_CHAR(pMTMD_MOV_MES), 2, '0')
                         ORDER BY MM.MTMD_MOV_ANO DESC, MM.MTMD_MOV_MES DESC)
                   WHERE ROWNUM = 1 AND CAD_MTMD_ID = MTMD.CAD_MTMD_ID ) MTMD_SALDO_FISICO,
          DECODE(LINHA_ZERO.MTMD_SALDO_ATUAL,
                 (SELECT NVL(SUM(MTMD_MOV_SALDO),0)
                    FROM (SELECT * FROM TB_MTMD_MOV_MES MM
                           WHERE MM.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID AND
                                 MM.MTMD_MOV_ANO || LPAD(MM.MTMD_MOV_MES, 2, '0') <= pMTMD_MOV_ANO || LPAD(TO_CHAR(pMTMD_MOV_MES), 2, '0')
                                 ORDER BY MM.MTMD_MOV_ANO DESC, MM.MTMD_MOV_MES DESC)
                           WHERE ROWNUM = 1 AND CAD_MTMD_ID = MTMD.CAD_MTMD_ID ),
                  NVL(LINHA_ZERO.MTMD_VALOR_ATUAL,0),
                  TRUNC((SELECT NVL(SUM(MTMD_MOV_SALDO),0)
                    FROM (SELECT * FROM TB_MTMD_MOV_MES MM
                           WHERE MM.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID AND
                                 MM.MTMD_MOV_ANO || LPAD(MM.MTMD_MOV_MES, 2, '0') <= pMTMD_MOV_ANO || LPAD(TO_CHAR(pMTMD_MOV_MES), 2, '0')
                                 ORDER BY MM.MTMD_MOV_ANO DESC, MM.MTMD_MOV_MES DESC)
                           WHERE ROWNUM = 1 AND CAD_MTMD_ID = MTMD.CAD_MTMD_ID ) * LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL, 2)) MTMD_VALOR_FISICO,
          LINHA_ZERO.MTMD_SALDO_ATUAL                MTMD_SALDO_ATUAL,
          LINHA_ZERO.MTMD_VALOR_ATUAL                MTMD_VALOR_ATUAL
  FROM TB_CAD_MTMD_MAT_MED MTMD,
       TB_CAD_MTMD_GRUPO GRUPO,
       TB_CAD_MTMD_SUBGRUPO SUBGRUPO,
       TB_MTMD_MOV_ESTOQUE_DIA DIAP,
       (
         SELECT *
         FROM TB_MTMD_MOV_ESTOQUE_DIA
         WHERE MTMD_MOV_DATA                = dDataIni
         AND   ( CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID )
         AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
         AND   CAD_UNI_ID_UNIDADE           = 244
         AND   CAD_SET_ID                   = 29
         AND   CAD_MTMD_TPMOV_ID            = 0
         AND   CAD_MTMD_SUBTP_ID            = 0
       ) LINHA_ZERO
  WHERE DIAP.MTMD_MOV_DATA >= dDataIni
  AND   DIAP.MTMD_MOV_DATA <= dDatafIM
  AND   ( DIAP.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID )
  AND   ( pCAD_MTMD_GRUPO_ID IS NULL OR DIAP.CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID )
  AND   MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID
  AND   GRUPO.CAD_MTMD_GRUPO_ID             = LINHA_ZERO.CAD_MTMD_GRUPO_ID
  AND   (SUBGRUPO.CAD_MTMD_GRUPO_ID(+)         = LINHA_ZERO.CAD_MTMD_GRUPO_ID
  AND   SUBGRUPO.CAD_MTMD_SUBGRUPO_ID(+)       = LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID)
  AND  LINHA_ZERO.CAD_MTMD_ID(+)               = DIAP.CAD_MTMD_ID
  AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)        = DIAP.CAD_MTMD_FILIAL_ID
  AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)         = DIAP.CAD_MTMD_GRUPO_ID
  AND  (LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID != 942 OR LINHA_ZERO.MTMD_VALOR_ATUAL != 0) -- NAO CONTEMPLAR ALIMENTOS NAO ESTOCAVEIS
  AND  NOT LINHA_ZERO.CAD_MTMD_FILIAL_ID IS NULL
  GROUP BY MTMD.CAD_MTMD_ID,
           DIAP.CAD_MTMD_FILIAL_ID,
           MTMD.CAD_MTMD_NOMEFANTASIA,
           MTMD.CAD_MTMD_CODMNE,
           MTMD.CAD_MTMD_UNID_CONTROLE_DS,
           LINHA_ZERO.CAD_MTMD_GRUPO_ID,
           LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID,
           GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
           SUBGRUPO.CAD_MTMD_SUBGRUPO_DESCRICAO,
           LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR,
           LINHA_ZERO.MTMD_SALDO_ATUAL,
           LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,
           LINHA_ZERO.MTMD_VALOR_ATUAL,
           LINHA_ZERO.MTMD_SALDO_ANTERIOR,
           LINHA_ZERO.MTMD_VALOR_ANTERIOR
  --HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)+ NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) > 0
  HAVING (SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)+ NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) > 0 OR LINHA_ZERO.MTMD_SALDO_ATUAL = 0)
  UNION
  SELECT MES.CAD_MTMD_ID,
         M.CAD_MTMD_NOMEFANTASIA DESCRICAO,
         M.CAD_MTMD_CODMNE,
         M.CAD_MTMD_UNID_CONTROLE_DS,
         M.CAD_MTMD_GRUPO_ID,
         M.CAD_MTMD_SUBGRUPO_ID,
         G.CAD_MTMD_GRUPO_DESCRICAO,
         S.CAD_MTMD_SUBGRUPO_DESCRICAO,       
         FNC_MTMD_PRECO_PERIODO(MES.CAD_MTMD_ID, MES.CAD_MTMD_FILIAL_ID, 
                                ADD_MONTHS(dDataIni,-12), dDatafIM) MTMD_CUSTO_MEDIO,                              
         MES.MTMD_MOV_SALDO MTMD_SALDO_FISICO,
         (TRUNC(FNC_MTMD_PRECO_PERIODO(MES.CAD_MTMD_ID, MES.CAD_MTMD_FILIAL_ID, 
                                        ADD_MONTHS(dDataIni,-12), dDatafIM) *
         MES.MTMD_MOV_SALDO,2)) MTMD_VALOR_FISICO,       
         0 MTMD_SALDO_ATUAL,
         0 MTMD_VALOR_ATUAL
  FROM TB_MTMD_MOV_MES MES JOIN 
       TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = MES.CAD_MTMD_ID JOIN
       TB_CAD_MTMD_GRUPO G ON G.CAD_MTMD_GRUPO_ID = M.CAD_MTMD_GRUPO_ID JOIN
       TB_CAD_MTMD_SUBGRUPO S ON S.CAD_MTMD_GRUPO_ID = M.CAD_MTMD_GRUPO_ID AND S.CAD_MTMD_SUBGRUPO_ID = M.CAD_MTMD_SUBGRUPO_ID
  WHERE MES.MTMD_MOV_ANO = pMTMD_MOV_ANO 
    AND MES.MTMD_MOV_MES = pMTMD_MOV_MES
    AND MES.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID 
    AND (M.CAD_MTMD_SUBGRUPO_ID != 942) --NAO CONTEMPLAR ALIMENTOS NAO ESTOCAVEIS
    AND ( pCAD_MTMD_GRUPO_ID IS NULL OR M.CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID )
    AND MES.MTMD_MOV_SALDO > 0
    AND MES.CAD_MTMD_ID 
    NOT IN (SELECT DISTINCT MTMD.CAD_MTMD_ID
              FROM TB_CAD_MTMD_MAT_MED MTMD,
                   TB_MTMD_MOV_ESTOQUE_DIA DIAP,
                   (
                     SELECT *
                     FROM TB_MTMD_MOV_ESTOQUE_DIA
                     WHERE MTMD_MOV_DATA                = dDataIni
                     AND   ( CAD_MTMD_FILIAL_ID         = pCAD_MTMD_FILIAL_ID )
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
                     AND   ( CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID )
                   ) NOTAS                
              WHERE DIAP.MTMD_MOV_DATA >= dDataIni
              AND   DIAP.MTMD_MOV_DATA <= dDatafIM
              AND   ( DIAP.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID )
              AND   MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID
              AND  LINHA_ZERO.CAD_MTMD_ID(+)               = DIAP.CAD_MTMD_ID
              AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)        = DIAP.CAD_MTMD_FILIAL_ID
              AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)         = DIAP.CAD_MTMD_GRUPO_ID
              AND  NOTAS.MTMD_MOV_DATA(+)       = DIAP.MTMD_MOV_DATA
              AND  NOTAS.CAD_MTMD_ID(+)         = DIAP.CAD_MTMD_ID
              AND  NOTAS.CAD_MTMD_FILIAL_ID(+)  = DIAP.CAD_MTMD_FILIAL_ID
              AND  NOTAS.CAD_MTMD_TPMOV_ID(+)   = DIAP.CAD_MTMD_TPMOV_ID
              AND  NOTAS.CAD_MTMD_SUBTP_ID(+)   = DIAP.CAD_MTMD_SUBTP_ID
              AND NOT LINHA_ZERO.CAD_MTMD_FILIAL_ID IS NULL
              GROUP BY MTMD.CAD_MTMD_ID,   
                       DIAP.CAD_MTMD_FILIAL_ID,  
                       MTMD.CAD_MTMD_NOMEFANTASIA,
                       LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR,
                       LINHA_ZERO.MTMD_SALDO_ATUAL,       
                       LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,
                       LINHA_ZERO.MTMD_VALOR_ATUAL,       
                       LINHA_ZERO.MTMD_SALDO_ANTERIOR,
                       LINHA_ZERO.MTMD_VALOR_ANTERIOR
              HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)+ NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) > 0)    
  /*SELECT MES.CAD_MTMD_ID,
         M.CAD_MTMD_NOMEFANTASIA DESCRICAO,
         M.CAD_MTMD_CODMNE,
         M.CAD_MTMD_UNID_CONTROLE_DS,
         LINHA_ZERO.CAD_MTMD_GRUPO_ID,
         LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID,
         LINHA_ZERO.CAD_MTMD_GRUPO_DESCRICAO,
         LINHA_ZERO.CAD_MTMD_SUBGRUPO_DESCRICAO,
         CASE WHEN (LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL IS NULL) THEN --OR LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL = 0) THEN
              FNC_MTMD_PRECO_PERIODO(MES.CAD_MTMD_ID, MES.CAD_MTMD_FILIAL_ID, Add_months(dDataIni, -12), dDatafIM)
         ELSE
              NVL(LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,
                  FNC_MTMD_PRECO_PERIODO(MES.CAD_MTMD_ID, MES.CAD_MTMD_FILIAL_ID, Add_months(dDataIni, -12), dDatafIM))
         END  MTMD_CUSTO_MEDIO,
         MES.MTMD_MOV_SALDO MTMD_SALDO_FISICO,
         DECODE(LINHA_ZERO.MTMD_SALDO_ATUAL, MES.MTMD_MOV_SALDO, NVL(LINHA_ZERO.MTMD_VALOR_ATUAL,0),
                 TRUNC((MES.MTMD_MOV_SALDO *
                  CASE WHEN (LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL IS NULL) THEN-- OR LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL = 0) THEN
                      FNC_MTMD_PRECO_PERIODO(MES.CAD_MTMD_ID, MES.CAD_MTMD_FILIAL_ID, Add_months(dDataIni, -12), dDatafIM)
                 ELSE
                      NVL(LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,
                          FNC_MTMD_PRECO_PERIODO(MES.CAD_MTMD_ID, MES.CAD_MTMD_FILIAL_ID, Add_months(dDataIni, -12), dDatafIM))
                 END),2)) MTMD_VALOR_FISICO,
         NVL(LINHA_ZERO.MTMD_SALDO_ATUAL,0) MTMD_SALDO_ATUAL,
         NVL(LINHA_ZERO.MTMD_VALOR_ATUAL,0) MTMD_VALOR_ATUAL
  FROM SGS.TB_MTMD_MOV_MES MES JOIN
       TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = MES.CAD_MTMD_ID
       LEFT JOIN
       ( SELECT EDIA.*, GRUPO.CAD_MTMD_GRUPO_DESCRICAO, SUBGRUPO.CAD_MTMD_SUBGRUPO_DESCRICAO
         FROM TB_MTMD_MOV_ESTOQUE_DIA EDIA JOIN
              TB_CAD_MTMD_GRUPO GRUPO ON GRUPO.CAD_MTMD_GRUPO_ID = EDIA.CAD_MTMD_GRUPO_ID LEFT JOIN
              TB_CAD_MTMD_SUBGRUPO SUBGRUPO ON (SUBGRUPO.CAD_MTMD_GRUPO_ID = EDIA.CAD_MTMD_GRUPO_ID AND SUBGRUPO.CAD_MTMD_SUBGRUPO_ID = EDIA.CAD_MTMD_SUBGRUPO_ID)
         WHERE EDIA.MTMD_MOV_DATA                = dDataIni
         AND   ( EDIA.CAD_MTMD_FILIAL_ID         = pCAD_MTMD_FILIAL_ID )
         AND   EDIA.CAD_LAT_ID_LOCAL_ATENDIMENTO = 33
         AND   EDIA.CAD_UNI_ID_UNIDADE           = 244
         AND   EDIA.CAD_SET_ID                   = 29
         AND   EDIA.CAD_MTMD_TPMOV_ID            = 0
         AND   EDIA.CAD_MTMD_SUBTP_ID            = 0
       ) LINHA_ZERO ON LINHA_ZERO.CAD_MTMD_ID = MES.CAD_MTMD_ID AND MES.CAD_MTMD_FILIAL_ID = LINHA_ZERO.CAD_MTMD_FILIAL_ID
  WHERE MES.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID AND
        MES.MTMD_MOV_ANO = pMTMD_MOV_ANO AND
        MES.MTMD_MOV_MES = pMTMD_MOV_MES AND
        LINHA_ZERO.CAD_MTMD_GRUPO_ID != 4
        AND   ( pCAD_MTMD_GRUPO_ID IS NULL OR M.CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID )*/
  ORDER BY 2;--MTMD.CAD_MTMD_NOMEFANTASIA;
  io_cursor := v_cursor;
end PRC_MTMD_MOV_ESTOQUE_X_FECHA;