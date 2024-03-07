CREATE OR REPLACE PROCEDURE PRC_MTMD_REQ_ITEM_DISPENSA
(
   pMTMD_REQ_ID              IN TB_MTMD_REQUISICAO_ITEM.MTMD_REQ_ID%TYPE,
   pSEG_USU_ID_USUARIO       IN TB_MTMD_MOV_MOVIMENTACAO.SEG_USU_ID_USUARIO%TYPE
)
IS
/********************************************************************
  *    Procedure: PRC_MTMD_REQ_ITEM_DISPENSA
  *
  *      Data Criacao: 12/2009  Por: RICARDO COSTA
  *    Data Alteracao:     	  Por:
  *         alterac?o:
  *    Data Alteracao: 29/11/2011      Por: Andre S. Monaco
  *         Descric?o: Registrar movimentac?es durante inventario, quando um dos setores ainda n?o teve inventario
  *    Data Alteracao: 27/03/2012      Por: Andre S. Monaco
  *         Descric?o: Ultima alterac?o (29/11/11) comentada
  *    Data Alteracao: 28/05/2015      Por: Andre S. Monaco
  *         Descric?o: Gerar pendente sempre com a filial do pedido original
  *    Data Alteracao:	14/03/2016    Por: Andre Souza Monaco
  *         Alterac?o: Atualizar medicamento original, com ref. ao estoque padrao
  *    Data Alteracao:	13/06/2017    Por: Andre Souza Monaco
  *         Alterac?o: Gerar pendencia de pedido pendente de psicotropicos
  *    Data Alteracao:	03/2018    Por: Andre Souza Monaco
  *         Alterac?o: Dispensar medicamentos com lote
  *    Data Alteracao:   12/2018        Por: Andre
  *         Alterac?o: Entrada passa a ser direta no Setor Destino na PRC_MTMD_REQ_ITEM_DISP_I
  *
  *    Funcao: Muda Status Pedido e gera pendencia
  *******************************************************************/
vMTM_TIPO_REQUISICAO  TB_MTMD_REQ_REQUISICAO.MTM_TIPO_REQUISICAO%TYPE;
vCAD_MTMD_SUBTP_S     TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_SUBTP_ID%TYPE;
vMTMD_PEDPAD_ID       TB_MTMD_PEDIDO_PADRAO.MTMD_PEDPAD_ID%TYPE;
pNewIdt               INTEGER;
PADRAO                CONSTANT NUMBER := 1;
CARRINHO_EMERGENCIA   CONSTANT NUMBER := 3;
vMTMD_REQ_ID_PENDENTE TB_MTMD_REQUISICAO_ITEM.MTMD_REQ_ID%TYPE;  -- NOVO ID PARA REQUISIC?O DE PENDENTES
nFilial               TB_MTMD_REQ_REQUISICAO.CAD_MTMD_FILIAL_ID%type;
nQtdePendente         NUMBER;
vCAD_MTMD_SUBGRUPO_ID TB_CAD_MTMD_MAT_MED.CAD_MTMD_SUBGRUPO_ID%TYPE;
-- ===================================================================================
FUNCTION FNC_MTMD_REQ_PENDENTE
(
   pMTMD_REQ_ID_PENDENTE         IN TB_MTMD_REQUISICAO_ITEM.MTMD_REQ_ID%type, -- REQUISICAO PEDENTE
   pCAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
   pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
   pCAD_SET_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type,
   pCAD_MTMD_FILIAL_ID           IN TB_CAD_MTMD_FILIAL.CAD_MTMD_FILIAL_ID%type,
   pATD_ATE_ID                   IN TB_MTMD_REQ_REQUISICAO.ATD_ATE_ID%type default NULL,
   pATD_ATE_TP_PACIENTE          IN TB_MTMD_REQ_REQUISICAO.ATD_ATE_TP_PACIENTE%type default NULL,
   pMTMD_REQ_FL_STATUS           IN TB_MTMD_REQ_REQUISICAO.MTMD_REQ_FL_STATUS%type default NULL,
   pMTM_TIPO_REQUISICAO          IN TB_MTMD_REQ_REQUISICAO.MTM_TIPO_REQUISICAO%type,
   pSEG_USU_ID_USUARIO           IN TB_MTMD_REQ_REQUISICAO.SEG_USU_ID_USUARIO%TYPE DEFAULT NULL,
   pMTMD_FL_PENDENTE             IN TB_MTMD_REQ_REQUISICAO.MTMD_FL_PENDENTE%TYPE DEFAULT NULL,
   pMTMD_REQ_ID_REF              IN TB_MTMD_REQ_REQUISICAO.MTMD_REQ_ID_REF%TYPE DEFAULT NULL,
   -- ITEM
   pCAD_MTMD_ID                  IN TB_MTMD_REQUISICAO_ITEM.CAD_MTMD_ID%type,
   pMTMD_REQITEM_QTD_SOLICITADA  IN TB_MTMD_REQUISICAO_ITEM.MTMD_REQITEM_QTD_SOLICITADA%type,
   pMTMD_REQITEM_QTD_FORNECIDA   IN TB_MTMD_REQUISICAO_ITEM.MTMD_REQITEM_QTD_FORNECIDA%type default NULL,
   pMTMD_ID_ORIGINAL             IN TB_MTMD_REQUISICAO_ITEM.MTMD_ID_ORIGINAL%TYPE DEFAULT NULL,
   pCAD_MTMD_PRESCRICAO_ID       IN SGS.TB_MTMD_REQUISICAO_ITEM.CAD_MTMD_PRESCRICAO_ID%TYPE DEFAULT NULL,
   pCAD_SET_SETOR_FARMACIA       IN TB_MTMD_REQ_REQUISICAO.CAD_SET_SETOR_FARMACIA%TYPE DEFAULT NULL
) RETURN NUMBER IS
  /********************************************************************
  *    Procedure: FNC_MTMD_REQ_PENDENTE
  *
  *      Data Criacao: 12/2009  Por: RICARDO COSTA
  *    Data Alteracao:     	  Por:
  *         alterac?o:
  *
  *    Funcao: GERA REQUISIC?O PENDENTE
               RETORNA ID DA REQUSIC?O PENDENTE
  *******************************************************************/
pNewIdt                      integer;
--nEstoqueUnidade number;
BEGIN
    IF ( pMTMD_REQ_ID_PENDENTE = 0 ) THEN
       -- PRIMEIRO ITEM PENDENTE GERA NOVA REQUISIC?O
       PRC_MTMD_REQ_REQUISICAO_I ( pATD_ATE_ID,
                                   pATD_ATE_TP_PACIENTE,
                                   pMTMD_REQ_FL_STATUS,
                                   pCAD_SET_ID,
                                   pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                   pCAD_UNI_ID_UNIDADE,
                                   pMTM_TIPO_REQUISICAO,
                                   pCAD_MTMD_FILIAL_ID, -- FILIAL DA REQUISIC?O, N?O DO PRODUTO
                                   pSEG_USU_ID_USUARIO,
                                   pMTMD_FL_PENDENTE,
                                   pMTMD_REQ_ID_REF, -- pMTMD_REQ_ID_REF,
                                   NULL,
                                   pCAD_SET_SETOR_FARMACIA,
                                   0,--URGENCIA
                                   pNewIdt -- RETORNA NOVA ID
                                 );
    ELSE
       pNewIdt := pMTMD_REQ_ID_PENDENTE;
    END IF; -- FIM TESTE NOVO ID PENDENTE
     -- INSERE ITEM NA REQUISIC?O DE PENDENCIA
     PRC_MTMD_REQUISICAO_ITEM_I(  pNewIdt,
                                  pCAD_MTMD_ID,
                                  pMTMD_REQITEM_QTD_SOLICITADA, -- MTMD_REQITEM_QTD_SOLICITADA,
                                  pMTMD_REQITEM_QTD_FORNECIDA,
                                  pMTMD_ID_ORIGINAL,
                                  pCAD_MTMD_PRESCRICAO_ID
                                );
    RETURN pNewIdt;
END FNC_MTMD_REQ_PENDENTE;
-- ===================================================================================
FUNCTION FNC_MTMD_NUM_PEDIDO_PADRAO
(
   pCAD_MTMD_FILIAL_ID           IN TB_CAD_MTMD_FILIAL.CAD_MTMD_FILIAL_ID%type,
   pCAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
   pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
   pCAD_SET_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type
) RETURN NUMBER IS
vMTMD_PEDPAD_ID         NUMBER;
BEGIN
   -- PEGA O ID DO PEDIDO PADR?O PARA PODE ATUALIZAR A DATA DA ULTIMA DISPENSAC?O NO FIM DO PROCESSO
   BEGIN
     SELECT PADRAO.MTMD_PEDPAD_ID
     INTO   vMTMD_PEDPAD_ID
     FROM   TB_MTMD_PEDIDO_PADRAO PADRAO
     WHERE PADRAO.CAD_UNI_ID_UNIDADE           = pCAD_UNI_ID_UNIDADE
     AND   PADRAO.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
     AND   PADRAO.CAD_SET_ID                   = pCAD_SET_ID
     AND   PADRAO.CAD_MTMD_FILIAL_ID           = pCAD_MTMD_FILIAL_ID;
   EXCEPTION WHEN NO_DATA_FOUND THEN
     vMTMD_PEDPAD_ID := 0;
   END;
   RETURN vMTMD_PEDPAD_ID;
END FNC_MTMD_NUM_PEDIDO_PADRAO;
-- ===================================================================================
FUNCTION FNC_SOMA_SIMILARES
(
pMTMD_REQ_ID IN TB_MTMD_REQUISICAO_ITEM.MTMD_REQ_ID%TYPE,
pCAD_MTMD_ID IN TB_MTMD_REQUISICAO_ITEM.MTMD_ID_ORIGINAL%TYPE
) RETURN NUMBER IS
  /********************************************************************
  *    Procedure: FNC_SOMA_SIMILARES
  *
  *      Data Criacao: 25/11/2010  Por: RICARDO COSTA
  *    Data Alteracao:            Por:
  *         alterac?o:
  *
  *    Funcao: SOMA SIMILARES DA REQUISIC?O ATUAL
  *
  *******************************************************************/
nTotalItem NUMBER;
BEGIN
      -- BUSCA PRODUTO NA REQUISIC?O E SOMA QUANTIDADE JA FORNECIDA
      BEGIN
         SELECT NVL(SUM(ITEM.MTMD_REQITEM_QTD_FORNECIDA),0)
         INTO   nTotalItem
         FROM TB_MTMD_REQUISICAO_ITEM ITEM
         WHERE ITEM.MTMD_REQ_ID      = pMTMD_REQ_ID
         AND   ITEM.MTMD_ID_ORIGINAL = pCAD_MTMD_ID;
      EXCEPTION WHEN NO_DATA_FOUND THEN
         nTotalItem := 0;
      END;
      RETURN nTotalItem;
END;
-- ===================================================================================
BEGIN
     vMTMD_REQ_ID_PENDENTE := 0;
     FOR ITEM IN
     ( SELECT REQ.CAD_UNI_ID_UNIDADE,
              REQ.CAD_LAT_ID_LOCAL_ATENDIMENTO,
              REQ.CAD_SET_ID,
              REQ.CAD_MTMD_FILIAL_ID,
              REQ.MTM_TIPO_REQUISICAO,
              REQ_ITEM.CAD_MTMD_ID,
              REQ_ITEM.MTMD_REQITEM_QTD_FORNECIDA,
              DECODE( REQ_ITEM.MTMD_ID_ORIGINAL, NULL,
                     (REQ_ITEM.MTMD_REQITEM_QTD_SOLICITADA - FNC_MTMD_REQ_SOMA_SIMILAR( REQ_ITEM.cad_mtmd_id,
                                                                                        REQ_ITEM.MTMD_REQ_ID,
                                                                                        FNC_MTMD_PRINCIPIO_ATIVO (PRODUTO.CAD_MTMD_ID))),
                    REQ_ITEM.MTMD_REQITEM_QTD_SOLICITADA
              ) MTMD_REQITEM_QTD_SOLICITADA,
              REQ_ITEM.MTMD_REQITEM_QTD_SOLICITADA ITEM_QTD_SOLICITADA_ORIGINAL,
              REQ.ATD_ATE_ID,
              REQ.ATD_ATE_TP_PACIENTE,
              REQ_ITEM.MTMD_ID_ORIGINAL,
              FNC_MTMD_PRINCIPIO_ATIVO (PRODUTO.CAD_MTMD_ID) CAD_MTMD_PRIATI_ID,
              PRODUTO.CAD_MTMD_NOMEFANTASIA,
              REQ.MTMD_FL_PENDENTE,
              REQ_ITEM.CAD_MTMD_PRESCRICAO_ID,
              REQ.MTMD_REQ_FL_STATUS,
              REQ.CAD_SET_SETOR_FARMACIA
       FROM TB_MTMD_REQ_REQUISICAO  REQ,
            TB_MTMD_REQUISICAO_ITEM REQ_ITEM,
            TB_CAD_MTMD_MAT_MED     PRODUTO
       WHERE REQ_ITEM.MTMD_REQ_ID = REQ.MTMD_REQ_ID
       AND   REQ_ITEM.CAD_MTMD_ID = PRODUTO.CAD_MTMD_ID
       AND   REQ_ITEM.MTMD_REQ_ID = pMTMD_REQ_ID )
     LOOP
        vMTM_TIPO_REQUISICAO := ITEM.MTM_TIPO_REQUISICAO;
        nFilial := FNC_MTMD_RETORNA_FILIAL( ITEM.CAD_MTMD_ID, ITEM.CAD_MTMD_FILIAL_ID, ITEM.CAD_SET_ID);
        IF (vMTM_TIPO_REQUISICAO IN (PADRAO,CARRINHO_EMERGENCIA) AND
            NVL(vMTMD_PEDPAD_ID,0) = 0) THEN
            vMTMD_PEDPAD_ID := FNC_MTMD_NUM_PEDIDO_PADRAO(nFilial,
                                                          ITEM.CAD_UNI_ID_UNIDADE,
                                                          ITEM.CAD_LAT_ID_LOCAL_ATENDIMENTO, 
                                                          ITEM.CAD_SET_ID);
        END IF;
        SELECT M.CAD_MTMD_SUBGRUPO_ID
          INTO vCAD_MTMD_SUBGRUPO_ID
          FROM TB_CAD_MTMD_MAT_MED M
         WHERE M.CAD_MTMD_ID = ITEM.CAD_MTMD_ID;
        -- NAO GERA PENDENCIA DE ITEM PENDENTE (a nao ser que tenha prescricao ou seja um psicotropico)
        IF ( ITEM.MTMD_FL_PENDENTE = 0 OR NVL(ITEM.CAD_MTMD_PRESCRICAO_ID, 0) > 0 OR vCAD_MTMD_SUBGRUPO_ID IN (12,912)) THEN
           -- VERIFICA SIMILARES
           nQtdePendente := ITEM.ITEM_QTD_SOLICITADA_ORIGINAL - (FNC_SOMA_SIMILARES( pMTMD_REQ_ID, ITEM.CAD_MTMD_ID) + NVL(ITEM.MTMD_REQITEM_QTD_FORNECIDA,0));
           IF ( nQtdePendente > 0 ) THEN
              -- GERA PENDENTES
              vMTMD_REQ_ID_PENDENTE := FNC_MTMD_REQ_PENDENTE ( vMTMD_REQ_ID_PENDENTE, -- ID DA REQUSICAO PENDENTE
                                                               ITEM.CAD_UNI_ID_UNIDADE,
                                                               ITEM.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                               ITEM.CAD_SET_ID,
                                                               ITEM.CAD_MTMD_FILIAL_ID,
                                                               ITEM.ATD_ATE_ID,
                                                               ITEM.ATD_ATE_TP_PACIENTE,
                                                               1, -- pMTMD_REQ_FL_STATUS (ABERTO)
                                                               ITEM.MTM_TIPO_REQUISICAO,
                                                               pSEG_USU_ID_USUARIO,
                                                               1, --pMTMD_FL_PENDENTE,
                                                               pMTMD_REQ_ID, -- pMTMD_REQ_ID_REF,
                                                               ITEM.CAD_MTMD_ID,
                                                               nQtdePendente, -- ITEM.MTMD_REQITEM_QTD_SOLICITADA,
                                                               0, -- pMTMD_REQITEM_QTD_FORNECIDA,
                                                               ITEM.MTMD_ID_ORIGINAL,
                                                               ITEM.CAD_MTMD_PRESCRICAO_ID,
                                                               ITEM.CAD_SET_SETOR_FARMACIA
                                                              );
           END IF;
        END IF;
     END LOOP;
     IF (NVL(vMTMD_PEDPAD_ID,0) != 0) THEN
        -- ATUALIZA DATA DA ULTIMA DISPENSAC?O DO PEDIDO PADR?O
        PRC_MTMD_PEDIDO_PADRAO_U(vMTMD_PEDPAD_ID,
                                     NULL,
                                     NULL,
                                     NULL,
                                     1, -- pFL_ATUALIZAR_DT_DISPENSACAO
                                     NULL);
     END IF;
     -- ATUALIZA STATUS E USUARIO/DATA DISPENSAC?O DA REQUISIC?O
     PRC_MTMD_REQ_REQUISICAO_U(pMTMD_REQ_ID,
                               3, -- DISPENSADA ALMOXARIFADO
                               pSEG_USU_ID_USUARIO);
END PRC_MTMD_REQ_ITEM_DISPENSA;