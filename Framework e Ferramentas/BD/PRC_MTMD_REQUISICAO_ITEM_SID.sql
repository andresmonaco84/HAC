CREATE OR REPLACE PROCEDURE "PRC_MTMD_REQUISICAO_ITEM_SID"
  (
     pMTMD_REQ_ID IN TB_MTMD_REQUISICAO_ITEM.MTMD_REQ_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_MTMD_REQUISICAO_ITEM_SID
  *
  *    Data Criacao:   2009          Por: Ricardo
  *    Data Alteracao: 11/06/2013    Por: Andre S. Monmaco
  *         Alteracao: Mudanca da ordenac?o por mat/med
  *    Data Alteracao: 08/04/2016    Por: Andre S. Monmaco
  *         Alteracao: Add. CAD_MTMD_PRESCRICAO_ID
  *    Data Alteracao:  24/10/2017  Por: Andre S. Monaco
  *         Alteracao:  Adicao funcao SOUND ALIKE na descricao
  *
  *    Funcao: Carrega itens da requisicao
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
SELECT ITEM.MTMD_REQ_ID,
       ITEM.CAD_MTMD_ID,
       ITEM.MTMD_REQITEM_QTD_SOLICITADA,
       ITEM.MTMD_REQITEM_QTD_FORNECIDA,
       ITEM.CAD_MTMD_ID,
       ITEM.CAD_MTMD_PRESCRICAO_ID,
       PRODUTO.CAD_MTMD_UNIDADE_VENDA,
       PRODUTO.CAD_MTMD_UNIDADE_CONTROLE,
       FNC_MTMD_SOUNDALIKE(PRODUTO.CAD_MTMD_NOMEFANTASIA,PRODUTO.CAD_MTMD_GRUPO_ID) CAD_MTMD_NOMEFANTASIA,
       PRODUTO.CAD_MTMD_UNID_VENDA_DS,
       FNC_MTMD_PRINCIPIO_ATIVO (PRODUTO.CAD_MTMD_ID) CAD_MTMD_PRIATI_ID,
       FNC_MTMD_ESTOQUE_UNIDADE( ITEM.CAD_MTMD_ID,
                                 REQUISICAO.cad_uni_id_unidade,
                                 REQUISICAO.cad_lat_id_local_atendimento,
                                 REQUISICAO.cad_set_id,
                                 FNC_MTMD_RETORNA_FILIAL( ITEM.CAD_MTMD_ID, REQUISICAO.CAD_MTMD_FILIAL_ID, REQUISICAO.CAD_SET_ID ),
                                 -- REQUISICAO.CAD_MTMD_FILIAL_ID,
                                 NULL ) MTMD_ESTLOC_QTDE,
       FNC_MTMD_PRODUTO_PADRAO ( ITEM.CAD_MTMD_ID,
                                 FNC_MTMD_RETORNA_FILIAL( ITEM.CAD_MTMD_ID, REQUISICAO.CAD_MTMD_FILIAL_ID, REQUISICAO.CAD_SET_ID ),
                                 -- REQUISICAO.CAD_MTMD_FILIAL_ID,
                                 REQUISICAO.CAD_SET_ID,
                                 REQUISICAO.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                 REQUISICAO.CAD_UNI_ID_UNIDADE ) MTMD_PEDPAD_QTDE,
       FNC_MTMD_ESTOQUE_CENT_DISP ( ITEM.CAD_MTMD_ID,
                                    REQUISICAO.cad_uni_id_unidade,
                                    REQUISICAO.cad_lat_id_local_atendimento,
                                    REQUISICAO.cad_set_id,
                                    FNC_MTMD_RETORNA_FILIAL( ITEM.CAD_MTMD_ID, REQUISICAO.CAD_MTMD_FILIAL_ID, REQUISICAO.CAD_SET_ID ),
                                    -- REQUISICAO.CAD_MTMD_FILIAL_ID,
                                    NULL ) MTMD_ESTLOC_CENTDISP_QTDE,
       -- QTDE EM ESTOQUE PELO SOMAT??RIO DOS SIMILARES
       FNC_MTMD_EST_PADRAO_UNIDADE(FNC_MTMD_PRINCIPIO_ATIVO (PRODUTO.CAD_MTMD_ID),
                                   ITEM.CAD_MTMD_ID,
                                   REQUISICAO.CAD_UNI_ID_UNIDADE,
                                   REQUISICAO.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                   REQUISICAO.CAD_SET_ID,
                                   FNC_MTMD_RETORNA_FILIAL( ITEM.CAD_MTMD_ID, REQUISICAO.CAD_MTMD_FILIAL_ID, REQUISICAO.CAD_SET_ID ),
                                   -- REQUISICAO.CAD_MTMD_FILIAL_ID,
                                   NULL -- LOTE
                               ) MTMD_ESTPADRAO_LOCAL_QTDE,
        PRODUTO.CAD_MTMD_FL_MAV,
        ITEM.CAD_MTMD_KIT_ID_ITEM,
        (SELECT CAD_MTMD_KIT_DSC
           FROM TB_CAD_MTMD_KIT
          WHERE CAD_MTMD_KIT_ID = ITEM.CAD_MTMD_KIT_ID_ITEM) CAD_MTMD_KIT_DSC_ITEM,
        ITEM.MTMD_QTD_KIT_MULTIPLICA,
        PRODUTO.CAD_MTMD_GRUPO_ID,
        PRODUTO.CAD_MTMD_SUBGRUPO_ID,
        (SELECT RIA_QTD_HRS_PERIODO_DOSE
           FROM TB_MTMD_REQUISICAO_ITEM_AUTO
          WHERE MTMD_REQ_ID = ITEM.MTMD_REQ_ID AND
                CAD_MTMD_ID = ITEM.CAD_MTMD_ID AND ROWNUM = 1) RIA_QTD_HRS_PERIODO_DOSE,
        (SELECT RIA_DATA_HORA_ADM_PAC
           FROM TB_MTMD_REQUISICAO_ITEM_AUTO
          WHERE MTMD_REQ_ID = ITEM.MTMD_REQ_ID AND
                CAD_MTMD_ID = ITEM.CAD_MTMD_ID AND ROWNUM = 1) RIA_DATA_HORA_ADM_PAC,
         ITEM.ATD_PME_ID,
         ITEM.ATD_MPM_ID,
         ITEM.MTMD_REQITEM_CANCEL_JUST,
         ITEM.MTMD_REQ_VIA
    FROM TB_MTMD_REQUISICAO_ITEM       ITEM,
         TB_MTMD_REQ_REQUISICAO        REQUISICAO,
         TB_CAD_MTMD_MAT_MED           PRODUTO
    WHERE ITEM.MTMD_REQ_ID         = pMTMD_REQ_ID
    AND   REQUISICAO.MTMD_REQ_ID   = ITEM.MTMD_REQ_ID
    AND   PRODUTO.CAD_MTMD_ID      = ITEM.CAD_MTMD_ID
    ORDER BY PRODUTO.TIS_MED_CD_TABELAMEDICA DESC, PRODUTO.CAD_MTMD_NOMEFANTASIA;
    io_cursor := v_cursor;
  end PRC_MTMD_REQUISICAO_ITEM_SID;