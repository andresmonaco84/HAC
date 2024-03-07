CREATE OR REPLACE PROCEDURE PRC_MTMD_REQ_ITEM_PENDENTE
(
   pMTMD_REQ_ID IN TB_MTMD_REQUISICAO_ITEM.MTMD_REQ_ID%type DEFAULT NULL,
   pATD_ATE_ID IN TB_MTMD_REQ_REQUISICAO.ATD_ATE_ID%type DEFAULT NULL,
   io_cursor OUT PKG_CURSOR.t_cursor
)
 IS
v_cursor PKG_CURSOR.t_cursor;
vSetor   NUMBER DEFAULT NULL;
/*
SELECIONA ITENS PARA TELA DE DISPENSAC?O.
SOMENTE ITENS QUE TENHAM QTDE A FORNECER PENDENTE
*/
BEGIN
IF (pMTMD_REQ_ID IS NOT NULL) THEN
  OPEN v_cursor FOR
  SELECT ITEM.MTMD_REQ_ID,
         ITEM.CAD_MTMD_ID,
         -- SE ID ORIGINAL E NULL N?O E SIMILAR,
         -- RETORNA QTDE DEDUZINDO A QTDE FORNECIDA NOS SIMILARES
         -- SE N?O RETORNA A PRORIA QTDE SOLICITADA
         DECODE( ITEM.MTMD_ID_ORIGINAL, NULL,
                 (ITEM.MTMD_REQITEM_QTD_SOLICITADA - FNC_MTMD_REQ_SOMA_SIMILAR( ITEM.CAD_MTMD_ID,
                                                                                ITEM.MTMD_REQ_ID,
                                                                                FNC_MTMD_PRINCIPIO_ATIVO (ITEM.CAD_MTMD_ID))),
                 ITEM.MTMD_REQITEM_QTD_SOLICITADA
               ) MTMD_REQITEM_QTD_SOLICITADA,
         (SELECT MTMD.CAD_MTMD_NOMEFANTASIA
          FROM SGS.TB_CAD_MTMD_MAT_MED MTMD
          WHERE MTMD.cad_mtmd_id = ITEM.MTMD_ID_ORIGINAL )  DS_PRODUTO_ORIGINAL,
         ITEM.MTMD_REQITEM_QTD_FORNECIDA,
         ITEM.CAD_MTMD_ID,
         PRODUTO.CAD_MTMD_UNIDADE_VENDA,
         PRODUTO.CAD_MTMD_UNIDADE_CONTROLE,
         FNC_MTMD_SOUNDALIKE(PRODUTO.CAD_MTMD_NOMEFANTASIA,PRODUTO.CAD_MTMD_GRUPO_ID) CAD_MTMD_NOMEFANTASIA,
         PRODUTO.CAD_MTMD_UNID_VENDA_DS,
         FNC_MTMD_PRINCIPIO_ATIVO (ITEM.CAD_MTMD_ID) CAD_MTMD_PRIATI_ID,
         ITEM.CAD_MTMD_PRESCRICAO_ID,
         REQUISICAO.CAD_SET_ID,
         PRODUTO.CAD_MTMD_FL_MAV,
         PRODUTO.CAD_MTMD_GRUPO_ID
      FROM TB_MTMD_REQUISICAO_ITEM       ITEM,
           TB_MTMD_REQ_REQUISICAO        REQUISICAO,
           TB_CAD_MTMD_MAT_MED           PRODUTO
      WHERE ITEM.MTMD_REQ_ID         = pMTMD_REQ_ID
      AND   REQUISICAO.MTMD_REQ_ID   = ITEM.MTMD_REQ_ID
      AND   PRODUTO.CAD_MTMD_ID      = ITEM.CAD_MTMD_ID
      AND   (ITEM.MTMD_REQITEM_QTD_FORNECIDA + FNC_MTMD_REQ_SOMA_SIMILAR ( ITEM.CAD_MTMD_ID,
                                                                           ITEM.MTMD_REQ_ID,
                                                                           FNC_MTMD_PRINCIPIO_ATIVO (ITEM.CAD_MTMD_ID))) !=
                                                                          (DECODE( ITEM.MTMD_ID_ORIGINAL, NULL,
                                                                                   -- SE FOR ITEM ORIGINAL RETORNA QTD SOLICITADA
                                                                                   ITEM.MTMD_REQITEM_QTD_SOLICITADA ,
                                                                                   -- SE FOR ITEM SIMILAR E QTDE SOLICITADA + SOMA DE
                                                                                   -- OUTROS ITENS SE EXISTIR
                                                                                  (ITEM.MTMD_REQITEM_QTD_SOLICITADA +
                                                                                    FNC_MTMD_REQ_SOMA_SIMILAR( ITEM.CAD_MTMD_ID,
                                                                                                               ITEM.MTMD_REQ_ID,
                                                                                                               FNC_MTMD_PRINCIPIO_ATIVO (ITEM.CAD_MTMD_ID))
                                                                                  ))
               )
      /*
      AND   (ITEM.MTMD_REQITEM_QTD_FORNECIDA + FNC_MTMD_REQ_SOMA_SIMILAR ( ITEM.CAD_MTMD_ID,
                                                                           ITEM.MTMD_REQ_ID,
                                                                           FNC_MTMD_PRINCIPIO_ATIVO (ITEM.CAD_MTMD_ID))) !=
                                                                           ITEM.MTMD_REQITEM_QTD_SOLICITADA
    */
      ORDER BY PRODUTO.CAD_MTMD_NOMEFANTASIA;
ELSE
  SELECT NVL(MAX(REQ.CAD_SET_ID),0)
    INTO vSetor
    FROM TB_MTMD_REQ_REQUISICAO REQ
   WHERE REQ.ATD_ATE_ID = pATD_ATE_ID AND ROWNUM = 1;
  IF (vSetor = 2252) THEN --ATENDIMENTO DOMICILIAR
     BEGIN
        FOR xxx IN
        (
          SELECT MTMD_REQ_ID
          FROM TB_MTMD_REQ_REQUISICAO
          WHERE MTMD_REQ_FL_STATUS IN (2, 5) --NO ALMOXARIFADO
            AND CAD_SET_ID = 2252
            AND TRUNC(SYSDATE - MTMD_REQ_DT_ATUALIZACAO) >= 10
        )
        LOOP
           UPDATE TB_MTMD_REQ_REQUISICAO SET
                  MTMD_REQ_FL_STATUS = 0 -- CANCELADA
            WHERE MTMD_REQ_ID = xxx.MTMD_REQ_ID;
        END LOOP;
     END;
  END IF;
  OPEN v_cursor FOR
  SELECT ITEM.MTMD_REQ_ID,
         ITEM.CAD_MTMD_ID,
         -- SE ID ORIGINAL E NULL N?O E SIMILAR,
         -- RETORNA QTDE DEDUZINDO A QTDE FORNECIDA NOS SIMILARES
         -- SE N?O RETORNA A PRORIA QTDE SOLICITADA
         DECODE( ITEM.MTMD_ID_ORIGINAL, NULL,
                 (ITEM.MTMD_REQITEM_QTD_SOLICITADA - FNC_MTMD_REQ_SOMA_SIMILAR( ITEM.CAD_MTMD_ID,
                                                                                ITEM.MTMD_REQ_ID,
                                                                                FNC_MTMD_PRINCIPIO_ATIVO (ITEM.CAD_MTMD_ID))),
                 ITEM.MTMD_REQITEM_QTD_SOLICITADA
               ) MTMD_REQITEM_QTD_SOLICITADA,
         (SELECT MTMD.CAD_MTMD_NOMEFANTASIA
          FROM SGS.TB_CAD_MTMD_MAT_MED MTMD
          WHERE MTMD.cad_mtmd_id = ITEM.MTMD_ID_ORIGINAL )  DS_PRODUTO_ORIGINAL,
         ITEM.MTMD_REQITEM_QTD_FORNECIDA,
         ITEM.CAD_MTMD_ID,
         PRODUTO.CAD_MTMD_UNIDADE_VENDA,
         PRODUTO.CAD_MTMD_UNIDADE_CONTROLE,
         FNC_MTMD_SOUNDALIKE(PRODUTO.CAD_MTMD_NOMEFANTASIA,PRODUTO.CAD_MTMD_GRUPO_ID) CAD_MTMD_NOMEFANTASIA,
         PRODUTO.CAD_MTMD_UNID_VENDA_DS,
         FNC_MTMD_PRINCIPIO_ATIVO (ITEM.CAD_MTMD_ID) CAD_MTMD_PRIATI_ID,
         ITEM.CAD_MTMD_PRESCRICAO_ID,
         REQUISICAO.CAD_SET_ID,
         PRODUTO.CAD_MTMD_FL_MAV,
         PRODUTO.CAD_MTMD_GRUPO_ID
      FROM TB_MTMD_REQUISICAO_ITEM       ITEM,
           TB_MTMD_REQ_REQUISICAO        REQUISICAO,
           TB_CAD_MTMD_MAT_MED           PRODUTO
      WHERE REQUISICAO.MTM_TIPO_REQUISICAO = 0 --PERSONALIZADO
      --AND   REQUISICAO.MTMD_REQ_FL_STATUS IN (2,5)--NO ALMOXARIFADO
      AND   REQUISICAO.MTMD_REQ_FL_STATUS NOT IN (0,1,3,6)--CANCELADA, ABERTA EM DIGITAC?O e DISPENSADA
      AND   REQUISICAO.ATD_ATE_ID    = pATD_ATE_ID
      AND   REQUISICAO.MTMD_REQ_ID   = ITEM.MTMD_REQ_ID
      AND   PRODUTO.CAD_MTMD_ID      = ITEM.CAD_MTMD_ID
      AND   (ITEM.MTMD_REQITEM_QTD_FORNECIDA + FNC_MTMD_REQ_SOMA_SIMILAR ( ITEM.CAD_MTMD_ID,
                                                                           ITEM.MTMD_REQ_ID,
                                                                           FNC_MTMD_PRINCIPIO_ATIVO (ITEM.CAD_MTMD_ID))) !=
                                                                          (DECODE( ITEM.MTMD_ID_ORIGINAL, NULL,
                                                                                   -- SE FOR ITEM ORIGINAL RETORNA QTD SOLICITADA
                                                                                   ITEM.MTMD_REQITEM_QTD_SOLICITADA ,
                                                                                   -- SE FOR ITEM SIMILAR E QTDE SOLICITADA + SOMA DE
                                                                                   -- OUTROS ITENS SE EXISTIR
                                                                                  (ITEM.MTMD_REQITEM_QTD_SOLICITADA +
                                                                                    FNC_MTMD_REQ_SOMA_SIMILAR( ITEM.CAD_MTMD_ID,
                                                                                                               ITEM.MTMD_REQ_ID,
                                                                                                               FNC_MTMD_PRINCIPIO_ATIVO (ITEM.CAD_MTMD_ID))
                                                                                  )))
      ORDER BY PRODUTO.CAD_MTMD_NOMEFANTASIA;
END IF;
io_cursor := v_cursor;
END;