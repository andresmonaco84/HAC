CREATE OR REPLACE PROCEDURE PRC_MTMD_MOV_HIST_PRD_SETOR
  (
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE,
     pCAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%TYPE,
     pCAD_SET_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%TYPE,
     pCAD_MTMD_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%TYPE,
     pCAD_MTMD_FILIAL_ID           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_FILIAL_ID%TYPE,
     pMTMD_MOV_DATA                IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_DATA%TYPE DEFAULT NULL,
     pMTMD_MOV_DATA_ATE            IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_DATA%TYPE DEFAULT NULL,
     pMTMD_COD_LOTE                IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_COD_LOTE%TYPE DEFAULT NULL,
     io_cursor                     OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_MTMD_MOV_HIST_PRD_SETOR
  *
  *    Data Criacao:   09/08/2010   Por: RICARDO COSTA
  *    Data Alteracao:  18/08/2010   Por: RICARDO COSTA
  *         Alterac?o: Permitir usuario enviar a data de inicio da consulta
  *    Data Alteracao:  18/07/2013   Por: Andre
  *         Alterac?o: Mostrar movimentac?es de todos os setores quando estoque compartilhado
  *    Data Alteracao:  03/2018   Por: Andre
  *         Alterac?o: Add. pMTMD_COD_LOTE
  *
  *    Funcao: RETORNA HISTORICO DE MOVIMENTAC?O DE PRODUTOS POR SETOR,
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  --CONVERSAO_INTEIRO_FRACIONADO   CONSTANT NUMBER := 32;
  --FRACIONADO     CONSTANT NUMBER := 1;
  NAO_FRACIONADO CONSTANT NUMBER := 0;
  CONSUMO_FRACIONADO             CONSTANT NUMBER := 14;
  CONSUMO_NAO_FRACIONADO         CONSTANT NUMBER :=11;
  CONSUMO_NAO_FATURADO           CONSTANT NUMBER :=18;
  SIM            CONSTANT NUMBER := 1;
  NAO            CONSTANT NUMBER := 0;
  dData          DATE;
  dDataAte       DATE;
-- ================================================================================================
BEGIN
    IF ( pMTMD_MOV_DATA IS NULL ) THEN
       dData := TRUNC(SYSDATE) - 3;
    ELSE
       dData := TRUNC(pMTMD_MOV_DATA);
    END IF;
    IF ( pMTMD_MOV_DATA_ATE IS NULL ) THEN
       dDataAte := SYSDATE;
    ELSE
       dDataAte := TO_DATE(TO_CHAR(pMTMD_MOV_DATA_ATE, 'DDMMYYYY') || ' 235959','DDMMYYYY HH24MISS');
    END IF;
    OPEN v_cursor FOR
    SELECT
       MOVIMENTACAO.MTMD_MOV_ID,
       MOVIMENTACAO.MTMD_REQ_ID,
       MOVIMENTACAO.MTMD_LOTEST_ID,
       MOVIMENTACAO.CAD_MTMD_ID,
       MOVIMENTACAO.CAD_MTMD_TPMOV_ID,
       MOVIMENTACAO.CAD_MTMD_SUBTP_ID,
       MOVIMENTACAO.MTMD_MOV_DATA,
       MOVIMENTACAO.MTMD_MOV_QTDE,
       CASE
          WHEN MOVIMENTACAO.CAD_MTMD_TPMOV_ID = PKG_MTMD_CONSTANTES.TIPO_MOVIMENTO_ENTRADA THEN MOVIMENTACAO.MTMD_MOV_QTDE
          ELSE 0
       END QTDE_ENTRADA,
       CASE
          WHEN MOVIMENTACAO.CAD_MTMD_TPMOV_ID = PKG_MTMD_CONSTANTES.TIPO_MOVIMENTO_SAIDA THEN MOVIMENTACAO.MTMD_MOV_QTDE
          ELSE 0
       END QTDE_SAIDA,
       MOVIMENTACAO.MTMD_MOV_FL_FINALIZADO,
       MOVIMENTACAO.ATD_ATE_ID,
       MOVIMENTACAO.ATD_ATE_TP_PACIENTE,
       MOVIMENTACAO.MTMD_MOV_FL_FATURADO,
       MOVIMENTACAO.CAD_MTMD_FILIAL_ID,
       MOVIMENTACAO.MTMD_TP_FRACAO_ID,
       PRODUTO.CAD_MTMD_UNIDADE_VENDA,
       CASE
             WHEN ( MOVIMENTACAO.CAD_MTMD_SUBTP_ID = CONSUMO_NAO_FRACIONADO AND PRODUTO.CAD_MTMD_FL_FRACIONA = SIM ) THEN ( NAO_FRACIONADO ) -- FRACIONADO PARA INTEIRO
             ELSE ( PRODUTO.CAD_MTMD_FL_FRACIONA  )
       END CAD_MTMD_FL_FRACIONA,
       CASE
         WHEN (MOVIMENTACAO.MTMD_TP_FRACAO_ID IS NOT NULL) THEN
            TO_CHAR(MOVIMENTACAO.MTMD_QTD_CONVERTIDA)||' '||(SELECT MTMD_DS_TP_FRACAO FROM TB_MTMD_TIPO_FRACAO WHERE MTMD_TP_FRACAO_ID = MOVIMENTACAO.MTMD_TP_FRACAO_ID)
         WHEN ( MOVIMENTACAO.CAD_MTMD_SUBTP_ID = CONSUMO_FRACIONADO AND PRODUTO.CAD_MTMD_FL_FRACIONA = NAO ) THEN 'FRACIONADO'
         WHEN ( MOVIMENTACAO.CAD_MTMD_SUBTP_ID = CONSUMO_NAO_FRACIONADO AND PRODUTO.CAD_MTMD_FL_FRACIONA = SIM ) THEN 'INTEIRO'
         WHEN ( MOVIMENTACAO.CAD_MTMD_SUBTP_ID = CONSUMO_NAO_FATURADO   AND PRODUTO.CAD_MTMD_FL_FRACIONA = SIM ) THEN 'INTEIRO'
         ELSE NULL
       END  DS_QTDE_CONVERTIDA,
       NULL MTMD_DT_RESSUPRIMENTO,
       -- SUBTP.CAD_MTMD_SUBTP_DESCRICAO,
       -- DESCRICAO DO MOVIMENTO
       -- MOVIMENTACAO.CAD_MTMD_TPMOV_ID,
       -- MOVIMENTACAO.CAD_MTMD_SUBTP_ID,
       CASE
             WHEN MOVIMENTACAO.CAD_MTMD_TPMOV_ID = 1 THEN -- ENTRADA
                CASE
                   WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 2 THEN -- TRANSFERENCIA
                      SUBTP.CAD_MTMD_SUBTP_DESCRICAO||' '||
                      ( SELECT SETOR.CAD_SET_DS_SETOR
                        FROM TB_MTMD_MOV_MOVIMENTACAO MOV,
                             TB_CAD_SET_SETOR       SETOR
                        WHERE MTMD_MOV_ID                        = MOVIMENTACAO.MTMD_MOV_ID_REF
                        AND   SETOR.CAD_SET_ID                   = MOV.CAD_SET_ID
                        AND   SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO
                        AND   SETOR.CAD_UNI_ID_UNIDADE           = MOV.CAD_UNI_ID_UNIDADE )
                   WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 29 THEN -- ESTORNO DE CONSUMO NO CENTRO DE CUSTO
                      SUBTP.CAD_MTMD_SUBTP_DESCRICAO||': '||
                      (SELECT SETOR_HORA FROM
                       (SELECT UNI.CAD_UNI_DS_RESUMIDA || '/' || SETOR.CAD_SET_CD_SETOR || ' ' || TO_CHAR(MOV.MTMD_MOV_DATA,'(DD/MM/YY HH24:MI:SS)') SETOR_HORA
                        FROM TB_MTMD_MOV_MOVIMENTACAO MOV,
                             TB_CAD_SET_SETOR       SETOR,
                             TB_CAD_UNI_UNIDADE     UNI
                        WHERE MOV.MTMD_MOV_ID_REF                    = MOVIMENTACAO.MTMD_MOV_ID_REF
                        AND   UNI.CAD_UNI_ID_UNIDADE             = MOV.CAD_UNI_ID_UNIDADE
                        AND   SETOR.CAD_SET_ID                   = MOV.CAD_SET_ID
                        AND   SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO
                        AND   SETOR.CAD_UNI_ID_UNIDADE           = MOV.CAD_UNI_ID_UNIDADE
                        ORDER BY MOV.CAD_MTMD_TPMOV_ID DESC)
                        WHERE ROWNUM = 1) --DAR A PRIORIDADE PARA O MOV. 2 (BAIXA), CASO HAJA ESTORNO.
                   ELSE                   --SE NAO ACHAR MOVIMENTO INFORMATIVO DO DESTINO, TRAZ O MOV. 1 DO ESTORNO MESMO.
                      SUBTP.CAD_MTMD_SUBTP_DESCRICAO
                 END
             WHEN MOVIMENTACAO.CAD_MTMD_TPMOV_ID = 2 THEN -- SAIDA
                CASE
                   WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN (5, 8, 10) THEN
                      -- 5 = AVULSO
                      -- 8 = PEDIDO PADRAO
                      -- 10 = PERSONALIZADO
                      -- DISPENSAC?O PEDIDO PADRAO, RETORNA DESCRICAO DO SETOR QUE RECEBEU O PEDIDO
                      'DISPENSADO P/ '||
                      ( SELECT SETOR.CAD_SET_DS_SETOR||' '||
                               -- SE UNIDADES FOREM DIFERENTES RETORNA UNIDADE TBM
                               CASE
                                  WHEN REQ.CAD_UNI_ID_UNIDADE != MOVIMENTACAO.CAD_UNI_ID_UNIDADE THEN
                                     (SELECT UNI.CAD_UNI_DS_UNIDADE
                                      FROM TB_CAD_UNI_UNIDADE UNI
                                      WHERE UNI.CAD_UNI_ID_UNIDADE = REQ.CAD_UNI_ID_UNIDADE )
                                  ELSE NULL
                               END ||
                               -- RETORNA TIPO DE BAIXA
                               CASE
                                  WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 5  THEN ' (AVULSO)'
                                  WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 8  THEN ' (PADRAO)'
                                  WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 10 THEN ' (PERSONALIZADO)'
                               END
                        FROM TB_MTMD_REQ_REQUISICAO REQ,
                             TB_CAD_SET_SETOR       SETOR
                        WHERE REQ.MTMD_REQ_ID                    = MOVIMENTACAO.MTMD_REQ_ID
                        AND   SETOR.CAD_SET_ID                   = REQ.CAD_SET_ID
                        AND   SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = REQ.CAD_LAT_ID_LOCAL_ATENDIMENTO
                        AND   SETOR.CAD_UNI_ID_UNIDADE           = REQ.CAD_UNI_ID_UNIDADE )
                   WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 3 THEN -- TRANSFERENCIA
                      SUBTP.CAD_MTMD_SUBTP_DESCRICAO||', DESTINO: '||
                      ( SELECT UNI.CAD_UNI_DS_RESUMIDA || '/' || SETOR.CAD_SET_CD_SETOR
                        FROM TB_MTMD_MOV_MOVIMENTACAO MOV,
                             TB_CAD_SET_SETOR       SETOR,
                             TB_CAD_UNI_UNIDADE     UNI
                        WHERE MTMD_MOV_ID                        = MOVIMENTACAO.MTMD_MOV_ID_REF
                        AND   UNI.CAD_UNI_ID_UNIDADE             = MOV.CAD_UNI_ID_UNIDADE
                        AND   SETOR.CAD_SET_ID                   = MOV.CAD_SET_ID
                        AND   SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO
                        AND   SETOR.CAD_UNI_ID_UNIDADE           = MOV.CAD_UNI_ID_UNIDADE )
                   WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 19 THEN -- CONSUMO CENTRO CUSTO
                      -- SUBTP.CAD_MTMD_SUBTP_DESCRICAO||' '||
                      'BAIXA CENT. CUSTO, DESTINO: '||
                      (SELECT SETOR FROM
                       (SELECT UNI.CAD_UNI_DS_RESUMIDA || '/' || SETOR.CAD_SET_CD_SETOR ||' '||
                               (DECODE(MOV.CAD_MTMD_SUBTP_ID,28,' (HOME CARE)','')) SETOR
                        FROM TB_MTMD_MOV_MOVIMENTACAO MOV,
                             TB_CAD_SET_SETOR       SETOR,
                             TB_CAD_UNI_UNIDADE     UNI
                        WHERE ((MOV.MTMD_MOV_FL_ESTORNO = 1 AND MOV.MTMD_MOV_ID_REF = MOVIMENTACAO.MTMD_MOV_ID) OR --COM ESTORNO O ID_REF E REFERENTE AO MOV. DE ESTORNO
                               (MOV.MTMD_MOV_FL_ESTORNO = 0 AND MOV.MTMD_MOV_ID = MOVIMENTACAO.MTMD_MOV_ID_REF)) --SEM ESTORNO O ID_REF E O SETOR DESTINO DO CENTRO DE CUSTO
                        AND   UNI.CAD_UNI_ID_UNIDADE             = MOV.CAD_UNI_ID_UNIDADE
                        AND   SETOR.CAD_SET_ID                   = MOV.CAD_SET_ID
                        AND   SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO
                        AND   SETOR.CAD_UNI_ID_UNIDADE           = MOV.CAD_UNI_ID_UNIDADE
                        ORDER BY MOV.CAD_MTMD_TPMOV_ID DESC)
                        WHERE ROWNUM = 1) --DAR A PRIORIDADE PARA O MOV. 2 (BAIXA), CASO HAJA ESTORNO.
                                          --SE NAO ACHAR MOVIMENTO INFORMATIVO DO DESTINO, TRAZ O MOV. 1 DO ESTORNO MESMO
                   WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 27 THEN -- INFORMATIVO CONSUMO CENTRO CUSTO
                      'DESPESA CENT. CUSTO '
                   ELSE
                     SUBTP.CAD_MTMD_SUBTP_DESCRICAO
                END
       END CAD_MTMD_SUBTP_DESCRICAO,
       -- FIM DESCRICAO MOVIMENTO
       SUBTP.CAD_MTMD_FL_FATURA,
       USU_MOV.SEG_USU_DS_NOME DS_USUARIO,
       (CASE
           WHEN PRODUTO.CAD_MTMD_FL_FRACIONA = SIM AND MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN (14, 35 ) THEN
              TO_CHAR( MOVIMENTACAO.MTMD_MOV_QTDE )||'/'||TO_CHAR( PRODUTO.CAD_MTMD_UNIDADE_VENDA)
           ELSE
              TO_CHAR( MOVIMENTACAO.MTMD_MOV_QTDE )
        END)  DS_QTDE_CONSUMO,
        MOVIMENTACAO.MTMD_MOV_ESTOQUE_ATUAL,
        MOVIMENTACAO.MTMD_MOV_FL_ESTORNO,
        MOVIMENTACAO.MTMD_COD_LOTE,
        MOVIMENTACAO.MTMD_MOV_SALDO_LOTE_SETOR,
        MOVIMENTACAO.MTMD_MOV_SALDO_LOTE_TOTAL
    FROM TB_MTMD_MOV_MOVIMENTACAO       MOVIMENTACAO,
         TB_CAD_MTMD_MAT_MED            PRODUTO,
         TB_CAD_MTMD_SUBTP_MOVIMENTACAO SUBTP,
         TB_SEG_USU_USUARIO             USU_MOV
    WHERE MOVIMENTACAO.CAD_MTMD_ID                  = pCAD_MTMD_ID
    AND   MOVIMENTACAO.CAD_UNI_ID_UNIDADE           IN (SELECT CAD_UNI_ID_UNIDADE
                                                          FROM TB_MTMD_CFG_ESTOQUE_CONSUMO CONSUMO
                                                          WHERE MTMD_SETOR_ESTOQUE_CONSUMO = (SELECT MTMD_SETOR_ESTOQUE_CONSUMO
                                                                                                FROM TB_MTMD_CFG_ESTOQUE_CONSUMO
                                                                                               WHERE CAD_SET_ID = pCAD_SET_ID AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID)
                                                            AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
                                                        UNION
                                                        SELECT MTMD_UNIDADE_ESTOQUE_CONSUMO
                                                          FROM TB_MTMD_CFG_ESTOQUE_CONSUMO CONSUMO
                                                          WHERE CAD_SET_ID = pCAD_SET_ID AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
                                                        UNION
                                                        SELECT CAD_UNI_ID_UNIDADE
                                                          FROM TB_MTMD_CFG_ESTOQUE_CONSUMO CONSUMO
                                                          WHERE MTMD_UNIDADE_ESTOQUE_CONSUMO = pCAD_UNI_ID_UNIDADE AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
                                                        UNION
                                                        SELECT SETOR.CAD_UNI_ID_UNIDADE
                                                          FROM TB_CAD_SET_SETOR SETOR
                                                         WHERE CAD_SET_ID = pCAD_SET_ID)
    AND   MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT CAD_LAT_ID_LOCAL_ATENDIMENTO
                                                          FROM TB_MTMD_CFG_ESTOQUE_CONSUMO CONSUMO
                                                         WHERE MTMD_SETOR_ESTOQUE_CONSUMO = (SELECT MTMD_SETOR_ESTOQUE_CONSUMO
                                                                                               FROM TB_MTMD_CFG_ESTOQUE_CONSUMO
                                                                                              WHERE CAD_SET_ID = pCAD_SET_ID AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID)
                                                           AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
                                                        UNION
                                                        SELECT MTMD_LOCAL_ESTOQUE_CONSUMO
                                                          FROM TB_MTMD_CFG_ESTOQUE_CONSUMO CONSUMO
                                                          WHERE CAD_SET_ID = pCAD_SET_ID AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
                                                        UNION
                                                        SELECT CAD_LAT_ID_LOCAL_ATENDIMENTO
                                                          FROM TB_MTMD_CFG_ESTOQUE_CONSUMO CONSUMO
                                                          WHERE MTMD_LOCAL_ESTOQUE_CONSUMO = pCAD_LAT_ID_LOCAL_ATENDIMENTO AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
                                                        UNION
                                                        SELECT SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                                                          FROM TB_CAD_SET_SETOR SETOR
                                                         WHERE CAD_SET_ID = pCAD_SET_ID)
    AND   MOVIMENTACAO.CAD_SET_ID                   IN (SELECT CAD_SET_ID
                                                          FROM TB_MTMD_CFG_ESTOQUE_CONSUMO CONSUMO
                                                          WHERE MTMD_SETOR_ESTOQUE_CONSUMO = (SELECT MTMD_SETOR_ESTOQUE_CONSUMO
                                                                                               FROM TB_MTMD_CFG_ESTOQUE_CONSUMO
                                                                                              WHERE CAD_SET_ID = pCAD_SET_ID AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID)
                                                            AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
                                                        UNION
                                                        SELECT MTMD_SETOR_ESTOQUE_CONSUMO
                                                          FROM TB_MTMD_CFG_ESTOQUE_CONSUMO CONSUMO
                                                          WHERE CAD_SET_ID = pCAD_SET_ID AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
                                                        UNION
                                                        SELECT CAD_SET_ID
                                                          FROM TB_MTMD_CFG_ESTOQUE_CONSUMO CONSUMO
                                                          WHERE MTMD_SETOR_ESTOQUE_CONSUMO = pCAD_SET_ID AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
                                                        UNION
                                                        SELECT SETOR.CAD_SET_ID
                                                          FROM TB_CAD_SET_SETOR SETOR
                                                         WHERE CAD_SET_ID = pCAD_SET_ID)
    AND   MOVIMENTACAO.CAD_MTMD_FILIAL_ID           = pCAD_MTMD_FILIAL_ID
    AND   (pMTMD_COD_LOTE                           IS NULL OR MOVIMENTACAO.MTMD_COD_LOTE = pMTMD_COD_LOTE)
    AND   (MOVIMENTACAO.MTMD_MOV_DATA >= dData AND MOVIMENTACAO.MTMD_MOV_DATA <= dDataAte)
  --AND   (pMTMD_MOV_DATA                is null OR MOVIMENTACAO.MTMD_MOV_DATA >= pMTMD_MOV_DATA)
  --AND   MOVIMENTACAO.CAD_MTMD_TPMOV_ID = 2 AND (MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN (11, 14, 18, 24, 25, 26, 35)
    AND   MOVIMENTACAO.CAD_MTMD_ID       = PRODUTO.CAD_MTMD_ID
    AND   SUBTP.CAD_MTMD_SUBTP_ID        = MOVIMENTACAO.CAD_MTMD_SUBTP_ID
    AND   USU_MOV.SEG_USU_ID_USUARIO(+)  = MOVIMENTACAO.SEG_USU_ID_USUARIO
  --AND   ( MOVIMENTACAO.CAD_SET_ID = 61 OR  MOVIMENTACAO.mtmd_mov_data     >= dData ) -- LIMITA DATA DE MOVIMENTACAO/ MENOS PARA O CENTRO CIRURGICO
  --ORDER BY MOVIMENTACAO.MTMD_MOV_DATA, PRODUTO.CAD_MTMD_NOMEFANTASIA;
  --ORDER BY MOVIMENTACAO.MTMD_MOV_ID;
    ORDER BY PRODUTO.CAD_MTMD_NOMEFANTASIA, MOVIMENTACAO.MTMD_MOV_DATA,
             DECODE(MOVIMENTACAO.CAD_MTMD_TPMOV_ID,1,MOVIMENTACAO.MTMD_MOV_ESTOQUE_ATUAL),
             DECODE(MOVIMENTACAO.CAD_MTMD_TPMOV_ID,2,MOVIMENTACAO.MTMD_MOV_ESTOQUE_ATUAL) DESC;
    io_cursor := v_cursor;
end PRC_MTMD_MOV_HIST_PRD_SETOR;