CREATE OR REPLACE PROCEDURE PRC_MTMD_REQ_ITEM_DISP_D
(
     pMTMD_REQ_ID                 IN TB_MTMD_REQUISICAO_ITEM.MTMD_REQ_ID%type,
     pCAD_MTMD_ID                 IN TB_MTMD_REQUISICAO_ITEM.CAD_MTMD_ID%type,
     pMTMD_ID_USUARIO_DISPENSACAO IN TB_MTMD_REQ_REQUISICAO.seg_usu_id_usuario%TYPE,
     pMTMD_LOTEST_ID              IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_LOTEST_ID%TYPE DEFAULT NULL
)
IS
/*
  VERIFICA E TENTA EXCLUIR ITEM DA REQUISIC?O QUE ESTA NA DISPENSAC?O
*/
ESTORNO_DISP                  CONSTANT NUMBER := 23;
vATD_ATE_ID                   TB_MTMD_REQ_REQUISICAO.ATD_ATE_ID%type;
vATD_ATE_TP_PACIENTE          TB_MTMD_REQ_REQUISICAO.atd_ate_tp_paciente%TYPE;
vMTM_TIPO_REQUISICAO          TB_MTMD_REQ_REQUISICAO.MTM_TIPO_REQUISICAO%type;
vCAD_SET_ID                   TB_CAD_SET_SETOR.CAD_SET_ID%type;
vCAD_LAT_ID_LOCAL_ATENDIMENTO TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type;
vCAD_UNI_ID_UNIDADE           TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type;
vCAD_MTMD_FILIAL_REQUISICAO   TB_MTMD_REQ_REQUISICAO.CAD_MTMD_FILIAL_ID%type;
vMTMD_REQITEM_QTD_SOLICITADA  TB_MTMD_REQUISICAO_ITEM.MTMD_REQITEM_QTD_SOLICITADA%TYPE;
vMTMD_REQITEM_QTD_FORNECIDA   TB_MTMD_REQUISICAO_ITEM.MTMD_REQITEM_QTD_FORNECIDA%type;
vCAD_MTMD_PRESCRICAO_ID       TB_MTMD_REQUISICAO_ITEM.CAD_MTMD_PRESCRICAO_ID%type;
nFilialProduto                TB_MTMD_REQ_REQUISICAO.CAD_MTMD_FILIAL_ID%type; -- FILIAL DO PRODUTO
nProdutoOriginal              TB_MTMD_REQUISICAO_ITEM.CAD_MTMD_ID%type;  -- CODIGO DO PRODUTO ORIGINAL DA REQUSIC?O SE ITEM ATUAL FOR 1 SIMILAR
vNewIdt                       NUMBER;
vNewIdtBaixa                  NUMBER := 0;
vQtdEstornoDisp               NUMBER := 0;
vQtdFornValida       NUMBER := 0;
vMTMD_CONTROLA_LOTEST      TB_MTMD_LOTEST_LOTE_ESTOQUE.MTMD_CONTROLA_LOTEST%TYPE;
vCAD_MTMD_FL_CONTROLA_LOTE TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_CONTROLA_LOTE%TYPE;
vCAD_MTMD_PRIATI_ID        TB_CAD_MTMD_MAT_MED.CAD_MTMD_PRIATI_ID%type;
--=============================================================================================
-- Data Alteracao:	 11/04/2013        Por: Andre
-- Alterac?o: Forcar para pegar HAC quando filial de CE
-- nProdutoOriginal:
-- Vai conter o ID do produto original da requisic?o quando produto
-- que esta sendo dispensado for um similar
--=============================================================================================
-- INICIO DA PROCEDURE
BEGIN
   -- BUSCA INFORMAC?ES SOBRE REQUISICAO E ITEM
   BEGIN
      SELECT REQUISICAO.cad_set_id,          REQUISICAO.cad_lat_id_local_atendimento,
             REQUISICAO.cad_uni_id_unidade,  REQUISICAO.cad_mtmd_filial_id,
             REQUISICAO.atd_ate_id,          REQUISICAO.mtm_tipo_requisicao,
             REQUISICAO.atd_ate_tp_paciente
      INTO   vCAD_SET_ID,                    vCAD_LAT_ID_LOCAL_ATENDIMENTO,
             vCAD_UNI_ID_UNIDADE,            vCAD_MTMD_FILIAL_REQUISICAO,
             vATD_ATE_ID,                    vMTM_TIPO_REQUISICAO,
             vATD_ATE_TP_PACIENTE
      FROM TB_MTMD_REQ_REQUISICAO REQUISICAO
      WHERE REQUISICAO.mtmd_req_id = pMTMD_REQ_ID;
   EXCEPTION WHEN NO_DATA_FOUND THEN
      RAISE_APPLICATION_ERROR(-20001, 'REQUISIC?O NAO ENCONTRADA !!!' );
   END;
   -- Se for pedido de Carrinho de Emergencia, Filial sera sempre HAC nas movimentac?es do
   -- centro de dispensac?o
   IF (vMTM_TIPO_REQUISICAO = 3 OR vCAD_MTMD_FILIAL_REQUISICAO = 4) THEN
       nFilialProduto := 1;
   ELSE
       nFilialProduto := FNC_MTMD_RETORNA_FILIAL( pCAD_MTMD_ID, vCAD_MTMD_FILIAL_REQUISICAO, vCAD_SET_ID );
   END IF;
   -- VERIFICA SE ITEM FAZ PARTE DA REQUSIC?O
   nProdutoOriginal := 0; -- nao e similar
   BEGIN
       SELECT ITEM.MTMD_REQITEM_QTD_SOLICITADA,
              ITEM.mtmd_reqitem_qtd_fornecida,
              ITEM.MTMD_ID_ORIGINAL,
              ITEM.CAD_MTMD_PRESCRICAO_ID
       INTO   vMTMD_REQITEM_QTD_SOLICITADA,
              vMTMD_REQITEM_QTD_FORNECIDA,
              nProdutoOriginal,
              vCAD_MTMD_PRESCRICAO_ID
       FROM TB_MTMD_REQUISICAO_ITEM ITEM
       WHERE ITEM.mtmd_req_id   = pMTMD_REQ_ID
       AND   ITEM.cad_mtmd_id   = pCAD_MTMD_ID;
   EXCEPTION WHEN NO_DATA_FOUND THEN
      IF ( nProdutoOriginal = 0 ) THEN
         -- NAO E ORIGINAL DA REQUISICAO NEM SIMILAR A UM ITEM DA REQUISIC?O
         RAISE_APPLICATION_ERROR(-20001, 'ITEM NAO CONSTA NA REQUISICAO !!!' );
      END IF;
   END;

   IF (vCAD_SET_ID = 2252 AND vMTM_TIPO_REQUISICAO = PKG_MTMD_CONSTANTES.REQ_PERSONALIZADA ) THEN --PARA ATENDIMENTO DOMICILIAR, TRANSFERIR P/ ALMOX QUANDO PEDIDO PERSONALIZADO                            );

     IF ( nProdutoOriginal > 0 ) THEN
        PRC_MTMD_REQUISICAO_ITEM_U( pMTMD_REQ_ID,
                                    pCAD_MTMD_ID,
                                    vMTMD_REQITEM_QTD_FORNECIDA-1,
                                    vMTMD_REQITEM_QTD_FORNECIDA
                                   );
     /*ELSE
        -- N?O SIMILAR, ATUALIZA QTDE FORNECIDA NA REQUISICAO
        PRC_MTMD_REQUISICAO_ITEM_U( pMTMD_REQ_ID,
                                    pCAD_MTMD_ID,
                                    vMTMD_REQITEM_QTD_SOLICITADA,
                                    vMTMD_REQITEM_QTD_FORNECIDA-1
                                   );*/
     END IF;

     vMTMD_REQITEM_QTD_FORNECIDA := 1; --NO ATENDIMENTO DOMICILIAR E SEMPRE DE 1 EM 1
     PRC_MTMD_MOV_ESTOQUE_BAIXA(pCAD_MTMD_ID,
                                 pMTMD_REQ_ID,
                                 pMTMD_LOTEST_ID,
                                 nFilialProduto,
                                 vCAD_UNI_ID_UNIDADE,
                                 vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                 vCAD_SET_ID,
                                 vMTMD_REQITEM_QTD_FORNECIDA,
                                 vATD_ATE_ID,
                                 vATD_ATE_TP_PACIENTE,
                                 2, --BAIXA
                                 3, --BAIXA TRANSF.
                                 0, --pCAD_MTMD_FL_FRACIONA,
                                 pMTMD_ID_USUARIO_DISPENSACAO,
                                 NULL, -- DT_FAT
                                 NULL, --HR_FAT
                                 vNewIdtBaixa);
   ELSE
     -- SE FOR MEDICAMENTO SIMILAR DELETA PRODUTO DA REQUISIC?O
     IF ( nProdutoOriginal > 0 ) THEN
        PRC_MTMD_REQUISICAO_ITEM_D(pCAD_MTMD_ID, pMTMD_REQ_ID);
     ELSE
        -- N?O SIMILAR, ATUALIZA QTDE FORNECIDA NA REQUISICAO
        PRC_MTMD_REQUISICAO_ITEM_U( pMTMD_REQ_ID,
                                    pCAD_MTMD_ID,
                                    vMTMD_REQITEM_QTD_SOLICITADA,
                                    0 -- QUANTIDADE FORNECIDA SERA ZERADA
                                   );
     END IF;
   END IF;
   vMTMD_CONTROLA_LOTEST := FNC_MTMD_CONTROLA_LOTE(pCAD_MTMD_ID,NULL,vCAD_MTMD_FL_CONTROLA_LOTE);
   IF (vCAD_MTMD_FL_CONTROLA_LOTE = 0 OR
       (vCAD_SET_ID = 2252 AND vMTM_TIPO_REQUISICAO = PKG_MTMD_CONSTANTES.REQ_PERSONALIZADA)) THEN
      PRC_MTMD_MOV_BAIXA_CENT_DISP(pCAD_MTMD_ID,
                                   pMTMD_LOTEST_ID,
                                   nFilialProduto,
                                   pMTMD_REQ_ID,
                                   vCAD_UNI_ID_UNIDADE,
                                   vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                   vCAD_SET_ID,
                                   1, -- ENTRADA
                                   ESTORNO_DISP, -- DISPENSAC?O ESTORNO
                                   vMTMD_REQITEM_QTD_FORNECIDA,
                                   vATD_ATE_ID,
                                   vATD_ATE_TP_PACIENTE,
                                   1, -- pMTMD_MOV_FL_FINALIZADO,
                                   pMTMD_ID_USUARIO_DISPENSACAO,
                                   1, -- E Entrada
                                   vNewIdt
                                  );
      UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
      MTMD_MOV_FL_ESTORNO = 1
      WHERE MTMD_MOV_ID = vNewIdt;
      IF (vNewIdtBaixa > 0) THEN
         UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
         MTMD_MOV_ID_REF = vNewIdt
         WHERE MTMD_MOV_ID = vNewIdtBaixa;
         -- ATUALIZA REFERENCIA DA MOVIMENTACAO
         UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
         MTMD_MOV_ID_REF = vNewIdtBaixa
         WHERE MTMD_MOV_ID = vNewIdt;
      END IF;
    ELSE
       vQtdFornValida := 0;
       --PERCORRER MOVIMENTACOES DE SAIDA DO CENTRO DE DISPENSACAO PARA ENCONTRAR LOTES E ESTORNAR
       FOR MOV_BAIXA IN (SELECT DECODE(MOV.MTMD_LOTEST_ID,0,NULL,MOV.MTMD_LOTEST_ID) MTMD_LOTEST_ID,
                                 SUM(MOV.MTMD_MOV_QTDE) MTMD_MOV_QTDE
                            FROM TB_MTMD_MOV_MOVIMENTACAO MOV
                           WHERE MOV.CAD_MTMD_ID = pCAD_MTMD_ID AND
                                 MOV.CAD_MTMD_FILIAL_ID = nFilialProduto AND
                                 MOV.MTMD_REQ_ID = pMTMD_REQ_ID AND
                                 MOV.CAD_MTMD_TPMOV_ID = 2 AND
                                 MOV.CAD_MTMD_SUBTP_ID IN (5,8,10,22) AND --Baixas de dispensacao
                                 MOV.MTMD_MOV_FL_ESTORNO = 0
                          GROUP BY MOV.MTMD_LOTEST_ID)
       LOOP
          SELECT NVL(SUM(MOV.MTMD_MOV_QTDE),0)
            INTO vQtdEstornoDisp
            FROM TB_MTMD_MOV_MOVIMENTACAO MOV
            WHERE MOV.CAD_MTMD_ID = pCAD_MTMD_ID AND
                  MOV.CAD_MTMD_FILIAL_ID = nFilialProduto AND
                  MOV.MTMD_REQ_ID = pMTMD_REQ_ID AND
                  MOV.CAD_MTMD_TPMOV_ID = 1 AND
                  MOV.CAD_MTMD_SUBTP_ID = ESTORNO_DISP AND --Estorno dispensacao
                  MOV.MTMD_MOV_FL_ESTORNO = 1 AND
                  NVL(MOV.MTMD_LOTEST_ID,0) = NVL(MOV_BAIXA.MTMD_LOTEST_ID,0);

          PRC_MTMD_MOV_BAIXA_CENT_DISP(pCAD_MTMD_ID,
                                       MOV_BAIXA.MTMD_LOTEST_ID,
                                       nFilialProduto,
                                       pMTMD_REQ_ID,
                                       vCAD_UNI_ID_UNIDADE,
                                       vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                       vCAD_SET_ID,
                                       1, -- ENTRADA
                                       ESTORNO_DISP, -- DISPENSAC?O ESTORNO
                                       MOV_BAIXA.MTMD_MOV_QTDE-vQtdEstornoDisp,
                                       vATD_ATE_ID,
                                       vATD_ATE_TP_PACIENTE,
                                       1, -- pMTMD_MOV_FL_FINALIZADO,
                                       pMTMD_ID_USUARIO_DISPENSACAO,
                                       1, -- E Entrada
                                       vNewIdt);
          UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
          MTMD_MOV_FL_ESTORNO = 1
          WHERE MTMD_MOV_ID = vNewIdt;

          vQtdFornValida := vQtdFornValida + (MOV_BAIXA.MTMD_MOV_QTDE-vQtdEstornoDisp);
       END LOOP;
       IF (vQtdFornValida <> vMTMD_REQITEM_QTD_FORNECIDA) THEN
          RAISE_APPLICATION_ERROR(-20001,'QTDE FORNECIDA DO ITEM DIFERENTE DO QUE ESTA ESTORNANDO');
       END IF;
    END IF;
    IF (NVL(vCAD_MTMD_PRESCRICAO_ID,0) > 0) THEN
       SELECT CAD_MTMD_PRIATI_ID
         INTO vCAD_MTMD_PRIATI_ID
         FROM TB_CAD_MTMD_MAT_MED MED
        WHERE MED.CAD_MTMD_ID = pCAD_MTMD_ID;
       IF (NVL(vCAD_MTMD_PRIATI_ID,0) != 0) THEN
          SELECT PI.CAD_MTMD_ID 
            INTO nProdutoOriginal
            FROM TB_CAD_MTMD_PRESCRICAO_ITEM PI JOIN
                 TB_CAD_MTMD_MAT_MED MED ON MED.CAD_MTMD_ID = PI.CAD_MTMD_ID
           WHERE NVL(PI.CAD_MTMD_PRC_ITEM_STATUS,1) = 1
             AND PI.CAD_MTMD_PRESCRICAO_ID = vCAD_MTMD_PRESCRICAO_ID
             AND MED.CAD_MTMD_PRIATI_ID = vCAD_MTMD_PRIATI_ID;
       ELSE
          nProdutoOriginal := pCAD_MTMD_ID;
       END IF; 
       --ATUALIZAR QTD. DISPENSADA NA PRESCRICAO
       UPDATE TB_CAD_MTMD_PRESCRICAO_ITEM PI
          SET PI.CAD_MTMD_PRC_QTDE_DISP = NVL(PI.CAD_MTMD_PRC_QTDE_DISP,0) - vMTMD_REQITEM_QTD_FORNECIDA
        WHERE NVL(PI.CAD_MTMD_PRC_ITEM_STATUS,1) = 1 AND
              PI.CAD_MTMD_PRESCRICAO_ID = vCAD_MTMD_PRESCRICAO_ID AND
              PI.CAD_MTMD_ID = nProdutoOriginal; --DECODE(NVL(nProdutoOriginal,0), 0, pCAD_MTMD_ID, nProdutoOriginal);
    END IF;
END;