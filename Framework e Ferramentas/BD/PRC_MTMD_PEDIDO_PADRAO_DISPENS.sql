CREATE OR REPLACE PROCEDURE "PRC_MTMD_PEDIDO_PADRAO_DISPENS"
  (
     pCAD_MTMD_FILIAL_ID IN TB_MTMD_PEDIDO_PADRAO.CAD_MTMD_FILIAL_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_MTMD_PEDIDO_PADRAO_DISPENS
  *
  *    Data Criacao:   28/05/2009   Por: Alexandre M. Muniz
  *    Data Alteracao: 12/06/2009   Por: André Souza Monaco
  *
  *    Funcao: Retorna todos os ítens de todos os pedidos padrões
  *            cujo percentual de estoque restante é menor ou igual
  *            ao percentual de estoque mínimo
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;

  begin
    OPEN v_cursor FOR
    SELECT ITEMPED.CAD_MTMD_ID,
           ITEMPED.MTMD_PEDPAD_ID,
           ITEMPED.MTMD_PEDPAD_QTDE,
           -- QTDE EM ESTOQUE PELO SOMATÓRIO DOS SIMILARES
           FNC_MTMD_EST_PADRAO_UNIDADE(FNC_MTMD_PRINCIPIO_ATIVO (ITEMPED.CAD_MTMD_ID),
                                       ITEMPED.CAD_MTMD_ID,
                                       PED.CAD_UNI_ID_UNIDADE,
                                       PED.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                       PED.CAD_SET_ID,
                                       PED.CAD_MTMD_FILIAL_ID,
                                       NULL -- LOTE
                                       ) QTDE_ESTOQUE_LOCAL,
           FNC_MTMD_DATA_ULT_FORNECIMENTO(ITEMPED.CAD_MTMD_ID,
                                          PED.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                          PED.CAD_UNI_ID_UNIDADE,
                                          PED.CAD_SET_ID,
                                          FNC_MTMD_RETORNA_FILIAL(ITEMPED.CAD_MTMD_ID, PED.CAD_MTMD_FILIAL_ID, PED.CAD_SET_ID)) MTMD_DT_DISPENSACAO,
           PED.CAD_UNI_ID_UNIDADE,
           PED.CAD_LAT_ID_LOCAL_ATENDIMENTO,
           PED.CAD_SET_ID,
           UNIDADE.CAD_UNI_DS_UNIDADE,
           LOC.CAD_LAT_DS_LOCAL_ATENDIMENTO,
           SETOR.CAD_SET_DS_SETOR,
           PROD.CAD_MTMD_NOMEFANTASIA,
           NVL(ITEMPED.MTMD_PEDPAD_PERCENT_RESSUP, 0) AS MTMD_PEDPAD_PERCENT_RESSUP,
           ESTOQUE.MTMD_MOV_CONSUMO_PERC PERCENTUAL_CONSUMIDO
           /*(100 - FNC_MTMD_PERC_ESTOQUE_PADRAO(FNC_MTMD_PRINCIPIO_ATIVO (ITEMPED.CAD_MTMD_ID),
                                               ITEMPED.CAD_MTMD_ID,
                                               PED.CAD_UNI_ID_UNIDADE,
                                               PED.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                               PED.CAD_SET_ID,
                                               PED.CAD_MTMD_FILIAL_ID,
                                               NULL, --LOTE
                                               ITEMPED.MTMD_PEDPAD_QTDE)) PERCENTUAL_CONSUMIDO*/
           --ITEMPERCCONSUMIDO.PERCENTUAL_CONSUMIDO
      FROM TB_MTMD_PEDIDO_PADRAO        PED,
           TB_MTMD_PEDIDO_PADRAO_ITENS  ITEMPED,
           TB_CAD_MTMD_MAT_MED          PROD,
           TB_CAD_SET_SETOR             SETOR,
           TB_CAD_UNI_UNIDADE           UNIDADE,
           TB_CAD_LAT_LOCAL_ATENDIMENTO LOC,
           TB_MTMD_ESTOQUE_LOCAL        ESTOQUE
           /*(SELECT ITEMPED.MTMD_PEDPAD_ID,
                   ITEMPED.CAD_MTMD_ID,
                   -- RETORNA PERCENTUAL DE CONSUMO
                   NVL(CEIL((FNC_MTMD_CONSUMO_MAT_MED(MATMED.CAD_MTMD_PRIATI_ID,
                                                      ITEMPED.CAD_MTMD_ID,
                                                      PED.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                      PED.CAD_UNI_ID_UNIDADE,
                                                      PED.CAD_SET_ID,
                                                      PED.CAD_MTMD_FILIAL_ID,
                                                      PED.MTMD_DT_DISPENSACAO,
                                                      SYSDATE,
                                                      2 -- PERCENTUAL
                                                  ))), 0) PERCENTUAL_CONSUMIDO
              FROM TB_MTMD_PEDIDO_PADRAO PED,
                   TB_MTMD_PEDIDO_PADRAO_ITENS ITEMPED,
                   Tb_Cad_Mtmd_Mat_Med MATMED
              WHERE ITEMPED.CAD_MTMD_ID = MATMED.CAD_MTMD_ID
               AND PED.MTMD_PEDPAD_ID = ITEMPED.MTMD_PEDPAD_ID
               AND PED.MTMD_DT_DISPENSACAO IS NOT NULL) ITEMPERCCONSUMIDO*/
     WHERE PED.MTMD_PEDPAD_ID               = ITEMPED.MTMD_PEDPAD_ID
       AND ITEMPED.CAD_MTMD_ID              = PROD.CAD_MTMD_ID
       AND (ESTOQUE.CAD_MTMD_ID = ITEMPED.CAD_MTMD_ID AND ESTOQUE.CAD_MTMD_FILIAL_ID = PED.CAD_MTMD_FILIAL_ID AND ESTOQUE.CAD_SET_ID = PED.CAD_SET_ID)
       AND PED.MTMD_DT_DISPENSACAO          IS NOT NULL
       AND PED.CAD_UNI_ID_UNIDADE           = UNIDADE.CAD_UNI_ID_UNIDADE
       AND PED.CAD_LAT_ID_LOCAL_ATENDIMENTO = LOC.CAD_LAT_ID_LOCAL_ATENDIMENTO
       AND PED.CAD_SET_ID                   = SETOR.CAD_SET_ID
       --AND ITEMPED.CAD_MTMD_ID = ITEMPERCCONSUMIDO.CAD_MTMD_ID
       --AND ITEMPED.MTMD_PEDPAD_ID = ITEMPERCCONSUMIDO.MTMD_PEDPAD_ID
       --AND ((100 - ITEMPERCCONSUMIDO.PERCENTUAL_CONSUMIDO) <= (NVL(ITEMPED.MTMD_PEDPAD_PERCENT_RESSUP, 0))) --Se (% Estoque Restante <= % Estoque Mínimo) exibe o item
       --AND PED.CAD_MTMD_FILIAL_ID           = FNC_MTMD_RETORNA_FILIAL( ITEMPED.CAD_MTMD_ID, pCAD_MTMD_FILIAL_ID)
       AND PED.CAD_MTMD_FILIAL_ID           = pCAD_MTMD_FILIAL_ID
       /*AND (100 - NVL(FNC_MTMD_PERC_ESTOQUE_PADRAO(FNC_MTMD_PRINCIPIO_ATIVO (ITEMPED.CAD_MTMD_ID),
                                                   ITEMPED.CAD_MTMD_ID,
                                                   PED.CAD_UNI_ID_UNIDADE,
                                                   PED.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                   PED.CAD_SET_ID,
                                                   PED.CAD_MTMD_FILIAL_ID, -- nao precisa chamar a function que ajusta unidade, ja ajustou no query principal
                                                   NULL, --LOTE
                                                   ITEMPED.MTMD_PEDPAD_QTDE), 0)) >= NVL(ITEMPED.MTMD_PEDPAD_PERCENT_RESSUP, 0)*/
       AND ESTOQUE.MTMD_MOV_CONSUMO_PERC >= NVL(ITEMPED.MTMD_PEDPAD_PERCENT_RESSUP, 0)
       --AND PROD.CAD_MTMD_FL_BAIXA_AUTOMATICA != 1
       AND NOT PED.MTMD_DT_DISPENSACAO IS NULL
       /*AND NOT EXISTS  ( SELECT ITEM.MTMD_REQ_ID
                         FROM TB_MTMD_REQUISICAO_ITEM ITEM,
                              TB_MTMD_REQ_REQUISICAO REQ
                         WHERE ITEM.MTMD_REQ_ID = REQ.MTMD_REQ_ID
                         AND ITEM.CAD_MTMD_ID = ITEMPED.CAD_MTMD_ID
                         AND TRUNC(REQ.MTMD_DATA_REQUISICAO) = TRUNC(SYSDATE))
                         AND ( SELECT COUNT(REQ.MTMD_REQ_ID)
                               FROM SGS.TB_MTMD_REQ_REQUISICAO REQ,
                                    SGS.TB_MTMD_REQUISICAO_ITEM ITEM
                               WHERE REQ.cad_lat_id_local_atendimento = PED.CAD_LAT_ID_LOCAL_ATENDIMENTO
                               AND   REQ.cad_set_id                   = PED.CAD_SET_ID
                               AND   REQ.cad_uni_id_unidade           = PED.CAD_UNI_ID_UNIDADE
                               AND   REQ.cad_mtmd_filial_id           = PED.CAD_MTMD_FILIAL_ID
                               AND   (REQ.mtmd_req_fl_status          = 2 OR -- FECHADA OU
                                      REQ.mtmd_req_fl_status          = 1 OR -- ABERTA OU
                                      REQ.mtmd_req_fl_status          = 5)   -- IMPRESSA
                               AND   REQ.mtmd_fl_pendente             = 1    -- PENDENTE
                               AND   ITEM.mtmd_req_id                 = REQ.MTMD_REQ_ID
                               AND   ITEM.cad_mtmd_id                 = ITEMPED.CAD_MTMD_ID) = 0*/
  ORDER BY UNIDADE.CAD_UNI_DS_UNIDADE,
           LOC.CAD_LAT_DS_LOCAL_ATENDIMENTO,
           SETOR.CAD_SET_DS_SETOR,
           PROD.CAD_MTMD_NOMEFANTASIA;
     io_cursor := v_cursor;
END PRC_MTMD_PEDIDO_PADRAO_DISPENS; -- Procedure

 
