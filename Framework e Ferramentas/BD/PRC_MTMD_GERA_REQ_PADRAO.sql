CREATE OR REPLACE PROCEDURE "PRC_MTMD_GERA_REQ_PADRAO"
   (
     pCAD_SET_ID                   IN TB_CAD_SET_SETOR.CAD_SET_ID%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE,
     pCAD_UNI_ID_UNIDADE           IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pCAD_MTMD_FILIAL_ID           IN TB_MTMD_REQ_REQUISICAO.CAD_MTMD_FILIAL_ID%type,
     pSEG_USU_ID_USUARIO           IN TB_MTMD_REQ_REQUISICAO.SEG_USU_ID_USUARIO%TYPE DEFAULT NULL,
     pCAD_SET_SETOR_FARMACIA       IN TB_MTMD_REQ_REQUISICAO.CAD_SET_SETOR_FARMACIA%TYPE DEFAULT NULL,
     pMED_CD_TABELAMEDICA          IN TB_CAD_MTMD_MAT_MED.TIS_MED_CD_TABELAMEDICA%TYPE DEFAULT NULL
   )
    IS
--===============================================================================
-- Gera requisic?o do pedido padrao
--===============================================================================
/*
  public enum StatusRequisicao
        { CANCELADA = 0, ABERTA = 1, FECHADA = 2, DISPENSADA_ALMOX = 3, RECEBIDA_UNIDADE = 4, IMPRESSO = 5 }
   public enum TipoRequisicao
        { PERSONALISADA = 0, PADRAO = 1, AVULSO = 2, CARRINHO_EMERGENCIA = 3 }
*/
 pNewIdt             SGS.TB_MTMD_REQ_REQUISICAO.mtmd_req_id%TYPE;
 vConsumo            NUMBER;
 --vQtdeEstoqueCentral NUMBER;
 vFornecer           NUMBER;
 vEstoqueUnidade     NUMBER;
 vTipo               NUMBER;
 nFilial             NUMBER;
 vMTMD_ESTLOC_QTDE_FRACIONADA NUMBER;
BEGIN
   -- SELECIONA PEDIDO PADRAO DO SETOR
   pNewIdt := NULL;
   IF (pCAD_MTMD_FILIAL_ID = 4) THEN
      vTipo := 3; -- CARRINHO_EMERGENCIA
   ELSE
      vTipo := 1; -- TIPO PADRAO
   END IF;
   FOR PAD IN
   ( SELECT ITEM.cad_mtmd_id, ITEM.mtmd_pedpad_qtde, ITEM.MTMD_PEDPAD_PERCENT_RESSUP,
            -- MTMD.CAD_MTMD_PRIATI_ID,
            FNC_MTMD_PRINCIPIO_ATIVO( MTMD.CAD_MTMD_ID ) CAD_MTMD_PRIATI_ID,
            PADRAO.MTMD_PEDPAD_ID, MTMD.TIS_MED_CD_TABELAMEDICA
     FROM SGS.TB_MTMD_PEDIDO_PADRAO       PADRAO,
          SGS.TB_MTMD_PEDIDO_PADRAO_ITENS ITEM,
          SGS.TB_CAD_MTMD_MAT_MED         MTMD
     WHERE PADRAO.cad_set_id                   = pCAD_SET_ID
     AND   PADRAO.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO
     AND   PADRAO.cad_uni_id_unidade           = pCAD_UNI_ID_UNIDADE
     AND   PADRAO.cad_mtmd_filial_id           = pCAD_MTMD_FILIAL_ID
     AND   ITEM.mtmd_pedpad_id                 = PADRAO.MTMD_PEDPAD_ID
     AND   MTMD.cad_mtmd_id                    = ITEM.cad_mtmd_id )
     LOOP
        IF (NVL(pMED_CD_TABELAMEDICA,0) = 0 OR NVL(pMED_CD_TABELAMEDICA,0) = PAD.TIS_MED_CD_TABELAMEDICA) THEN
          nFilial := FNC_MTMD_RETORNA_FILIAL( PAD.CAD_MTMD_ID, pCAD_MTMD_FILIAL_ID, pCAD_SET_ID);
          IF (pCAD_MTMD_FILIAL_ID != 2 OR
              (pCAD_MTMD_FILIAL_ID = 2 AND nFilial = pCAD_MTMD_FILIAL_ID)) THEN -- Nao deixar gerar material ou fracionado pro ACS
            PRC_MTMD_ESTOQUE_PER_CONSUMO_U(  PAD.CAD_MTMD_ID,
                                             nFilial,
                                             pCAD_UNI_ID_UNIDADE,
                                             pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                             pCAD_SET_ID,
                                             vConsumo);
              --========================================================================================
              -- GERA ITENS QUE ATINGIU PONTO DE RESSUPRIMENTO
              IF ( vConsumo >= PAD.MTMD_PEDPAD_PERCENT_RESSUP OR vConsumo IS NULL ) THEN
                -- PARA GARANTIR QUE N?O VAI GERAR REQUISIC?O VAZIA, PELO MENOS 1 ITEM TEM QUE ESTAR NO
                -- PONTO DE RESSUPRIMENTO
                IF ( pNewIdt IS NULL ) THEN
                   -- GERA REQUISICAO
                   PRC_MTMD_REQ_REQUISICAO_I  ( NULL, -- pATD_ATE_ID
                                                NULL, -- pATD_ATE_TP_PACIENTE
                                                2, -- STATUS FECHADA
                                                pCAD_SET_ID,
                                                pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                pCAD_UNI_ID_UNIDADE,
                                                vTipo,
                                                nFilial,
                                                pSEG_USU_ID_USUARIO,
                                                NULL, -- pMTMD_FL_PENDENTE
                                                NULL, -- pMTMD_REQ_ID_REF
                                                NULL,
                                                pCAD_SET_SETOR_FARMACIA,
                                                0,--URGENCIA
                                                pNewIdt
                                               );
                    -- ATUALIZA DATA DO ULTIMO PEDIDO
                    PRC_MTMD_PEDIDO_PADRAO_U   (PAD.MTMD_PEDPAD_ID,null,null,null,null,1);
                END IF;
                 -- VERIFICA ESTOQUE NA UNIDADE, SO GERA DIFERENCA ENTRE ESTOQUE E QTDE A FORNECER
                 vEstoqueUnidade := NVL(FNC_MTMD_EST_PADRAO_UNIDADE( PAD.CAD_MTMD_PRIATI_ID,
                                                                     PAD.CAD_MTMD_ID,
                                                                     pCAD_UNI_ID_UNIDADE,
                                                                     pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                                     pCAD_SET_ID,
                                                                     nFilial,
                                                                    NULL
                                                                   ),0);
                 -- ADICIONA DIFERENCA FRACIONADA
                 vMTMD_ESTLOC_QTDE_FRACIONADA := NVL(FNC_MTMD_ESTOQUE_FRACIONADO( PAD.CAD_MTMD_PRIATI_ID,
                                                                                  PAD.CAD_MTMD_ID,
                                                                                  nFilial,
                                                                                  pCAD_UNI_ID_UNIDADE,
                                                                                  pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                                                  pCAD_SET_ID ),0);
                 -- GERA DIFERENCA
                 vFornecer := PAD.MTMD_PEDPAD_QTDE - (vEstoqueUnidade+vMTMD_ESTLOC_QTDE_FRACIONADA);
                 IF ( vFornecer > 0 ) THEN
                    -- ESTAVA APARECENDO ITEM ZERADO NA REQUISICAO
                    PRC_MTMD_REQUISICAO_ITEM_I  (  pNewIdt, PAD.CAD_MTMD_ID, vFornecer, 0 );
                 END IF;
              END IF;
              --========================================================================================
          END IF;
        END IF;
     END LOOP;
END; -- Procedure/