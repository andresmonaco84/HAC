CREATE OR REPLACE PROCEDURE PRC_MTMD_REQ_ITEM_DISP_I
(
     pMTMD_REQ_ID                 IN TB_MTMD_REQUISICAO_ITEM.MTMD_REQ_ID%type,
     pCAD_MTMD_ID                 IN TB_MTMD_REQUISICAO_ITEM.CAD_MTMD_ID%type,
     pCAD_MTMD_PRIATI_ID          IN TB_CAD_MTMD_PRIATI_PRINC_ATIVO.CAD_MTMD_PRIATI_ID%type,
     pMTMD_REQITEM_QTD_FORNECIDA  IN TB_MTMD_REQUISICAO_ITEM.MTMD_REQITEM_QTD_FORNECIDA%type,
     pMTMD_ID_USUARIO_DISPENSACAO IN TB_MTMD_REQ_REQUISICAO.seg_usu_id_usuario%TYPE,
     pMTMD_LOTEST_ID              IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_LOTEST_ID%TYPE DEFAULT NULL
)
IS
   /*************************************************************************************
   *    Procedure: PRC_MTMD_REQ_ITEM_DISP_I
   *
   *    Data Criacao:   12/2009  Por: RICARDO COSTA
   *    Data Alteracao:   01/06/2010        Por: RICARDO COSTA
   *         alterac?o: Adicionado tipos de requisic?o OUTROS/HIGIENIZAC?O
   *    Data Alteracao:   09/07/2010        Por: RICARDO COSTA
   *         alterac?o: CHECAGEM DE ESTOQUE DO CENTRO DE DISPENSAC?O FOI COMENTADA,
   *                    A VERIFICAC?O ESTA SENDO FEITA DIRETO NA PROCEDURE QUE FAZ A BAIXA
   *                    PRC_MTMD_MOV_BAIXA_CENT_DISP
   *    Data Alteracao:   19/03/2013        Por: Andre
   *         Alterac?o: Arrumei os cods. de erro
   *    Data Alteracao:   11/04/2013        Por: Andre
   *         Alterac?o: Forcar para pegar HAC quando filial de CE
   *    Data Alteracao:   05/09/2014        Por: Andre
   *         Alterac?o: Para novo setor do ATENDIMENTO DOMICILIAR (HOMECARE),
   *                    dar entrada direta para pedido personalizado
   *    Data Alteracao:   03/2018        Por: Andre
   *         Alterac?o: Add. pMTMD_LOTEST_ID
   *    Data Alteracao:   12/2018        Por: Andre
   *         Alterac?o: Entrada direto no Setor Destino para todos os Pedidos
   *
   *    Funcao: VERIFICA E TENTA INSERIR ITEM DA REQUISIC?O PARA DISPENSAC?O
   *            Faz a verificac?o do produto para saber se pode dispensar,
   *            Verifica estoque padr?o, quantidade em estoque no centro de
   *            dispensac?o, etc...
   *            Se tudo estiver OK, chama procedure que vai fazer a reserva do produto
   *=> nProdutoOriginal:
   *   Vai conter o ID do produto original da requisic?o quando produto
   *   que esta sendo dispensado for um similar
   *
   *=> nFornecida:
   *  e o total do que ja foi gravado na requisic?o + o que esta sendo dispensado no momento
   *
   *=> vMTMD_REQITEM_QTD_SOLICITADA:
   *  E a quantidade solicitada pelo setor, no caso de similar a qtde solicitada sempre sera
   *  o valor do item original e a qtde solicitada do similar sempre sera igual a quantidade
   *  dispensada
   *    CHAMADA: Tela Dispensac?o,
   *
   **************************************************************************************/
vMTMD_PEDPAD_QTDE             TB_MTMD_PEDIDO_PADRAO_ITENS.MTMD_PEDPAD_QTDE%TYPE;
vATD_ATE_ID                   TB_MTMD_REQ_REQUISICAO.ATD_ATE_ID%TYPE;
vATD_ATE_TP_PACIENTE          TB_MTMD_REQ_REQUISICAO.atd_ate_tp_paciente%TYPE;
vMTM_TIPO_REQUISICAO          TB_MTMD_REQ_REQUISICAO.MTM_TIPO_REQUISICAO%TYPE;
vCAD_SET_ID                   TB_CAD_SET_SETOR.CAD_SET_ID%TYPE;
vCAD_LAT_ID_LOCAL_ATENDIMENTO TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE;
vCAD_UNI_ID_UNIDADE           TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE;
vCAD_MTMD_FILIAL_REQUISICAO   TB_MTMD_REQ_REQUISICAO.CAD_MTMD_FILIAL_ID%TYPE;
vMTMD_REQITEM_QTD_SOLICITADA  TB_MTMD_REQUISICAO_ITEM.MTMD_REQITEM_QTD_SOLICITADA%TYPE;
vCAD_MTMD_PRESCRICAO_ID       TB_MTMD_REQUISICAO_ITEM.CAD_MTMD_PRESCRICAO_ID%TYPE;
vCAD_MTMD_ID_PRESCRICAO       TB_MTMD_REQUISICAO_ITEM.CAD_MTMD_ID%TYPE := pCAD_MTMD_ID;
vCAD_MTMD_KIT_ID_ITEM         TB_MTMD_REQUISICAO_ITEM.CAD_MTMD_KIT_ID_ITEM%TYPE;
vCAD_MTMD_DT_FIM_CONS         TB_CAD_MTMD_PRESCRICAO_ITEM.CAD_MTMD_DT_FIM_CONS%TYPE;
vCAD_MTMD_TPMOV_S             TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_TPMOV_ID%TYPE;
vCAD_MTMD_SUBTP_S             TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_SUBTP_ID%type;
vCAD_MTMD_SUBTP_E             TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_SUBTP_ID%TYPE;
nFilialProduto                TB_MTMD_REQ_REQUISICAO.CAD_MTMD_FILIAL_ID%TYPE; -- FILIAL DO PRODUTO
nFornecida                    NUMBER;                                         -- TOTAL DA QUANTIDADE JA FORNECIDA NESTA REQUISIC?O
nQtdFornOutrosPedidosPrescr   NUMBER;
nProdutoOriginal              TB_MTMD_REQUISICAO_ITEM.CAD_MTMD_ID%TYPE;       -- CODIGO DO PRODUTO ORIGINAL DA REQUSIC?O SE ITEM ATUAL FOR 1 SIMILAR
nEstoqueUnidade               TB_MTMD_ESTOQUE_LOCAL.MTMD_ESTLOC_QTDE%TYPE;    -- ESTOQUE DO PRODUTO NA UNIDADE
nTotalSimilarRequisicao       NUMBER;                                         -- TOTALIZA ITENS DISPENSADOS NESTA REQUISIC?O INCLUINDO SIMILARES
vNewIdt                       NUMBER;
nIdEntrada                    NUMBER;
nEmDispensacao                NUMBER;
nQtdTotalAutoPrescricao       NUMBER;
vUNIDADE_ESTOQUE_CONSUMO   TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type;
vLOCAL_ESTOQUE_CONSUMO     TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type;
vSETOR_ESTOQUE_CONSUMO     TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type;
vMTMD_REQ_FL_STATUS        TB_MTMD_REQ_REQUISICAO.MTMD_REQ_FL_STATUS%TYPE;
vSETOR_FARMACIA            TB_MTMD_REQ_REQUISICAO.CAD_SET_SETOR_FARMACIA%TYPE;
vCAD_MTMD_GRUPO_ID         TB_CAD_MTMD_MAT_MED.CAD_MTMD_GRUPO_ID%TYPE;
-- TIPO REQUISICAO
-- PERSONALIZADA       CONSTANT NUMBER := 0;
PADRAO              CONSTANT NUMBER := 1;
AVULSO              CONSTANT NUMBER := 2;
HIGIENIZACAO        CONSTANT NUMBER := 6;
OUTROS              CONSTANT NUMBER := 7;
CARRINHO_EMERG      CONSTANT NUMBER := 3;
FILIAL_CE           CONSTANT NUMBER := 4;
BAIXA_PERSONALIZADA CONSTANT NUMBER := 10;
BAIXA_PADRAO        CONSTANT NUMBER := 8;
BAIXA_AVULSO        CONSTANT NUMBER := 5;
BAIXA_CARRINHO      CONSTANT NUMBER := 22;
ENTRADA_PERSONALIZADA CONSTANT NUMBER := 9;
ENTRADA_PADRAO        CONSTANT NUMBER := 7;
ENTRADA_AVULSO        CONSTANT NUMBER := 4;
ENTRADA_CARRINHO      CONSTANT NUMBER := 21;
-- INICIO DA PROCEDURE
BEGIN
   --
   -- BUSCA INFORMAC?ES SOBRE REQUISICAO E ITEM
   BEGIN
      SELECT REQUISICAO.cad_set_id,          REQUISICAO.cad_lat_id_local_atendimento,
             REQUISICAO.cad_uni_id_unidade,  REQUISICAO.cad_mtmd_filial_id,
             REQUISICAO.atd_ate_id,          REQUISICAO.mtm_tipo_requisicao,
             REQUISICAO.atd_ate_tp_paciente, REQUISICAO.MTMD_REQ_FL_STATUS,   REQUISICAO.CAD_SET_SETOR_FARMACIA
      INTO   vCAD_SET_ID,                    vCAD_LAT_ID_LOCAL_ATENDIMENTO,
             vCAD_UNI_ID_UNIDADE,            vCAD_MTMD_FILIAL_REQUISICAO,
             vATD_ATE_ID,                    vMTM_TIPO_REQUISICAO,
             vATD_ATE_TP_PACIENTE,           vMTMD_REQ_FL_STATUS,             vSETOR_FARMACIA
      FROM TB_MTMD_REQ_REQUISICAO REQUISICAO
      WHERE REQUISICAO.mtmd_req_id = pMTMD_REQ_ID;
      IF ( vMTMD_REQ_FL_STATUS IN ( PKG_MTMD_CONSTANTES.REQ_STATUS_DISPENSADA, PKG_MTMD_CONSTANTES.REQ_STATUS_RECEBIDA )  ) THEN
         RAISE_APPLICATION_ERROR(-20102,' ESTE PEDIDO JA FOI DISPENSADO POR OUTRO PROCESSO ');
      END IF;      
   EXCEPTION WHEN NO_DATA_FOUND THEN
      RAISE_APPLICATION_ERROR(-20000, 'REQUISICAO NAO ENCONTRADA !!!' );
   END;
   -- Se for pedido de Carrinho de Emergencia, Filial sera sempre HAC nas movimentac?es do
   -- centro de dispensac?o
   IF (vMTM_TIPO_REQUISICAO = CARRINHO_EMERG OR vCAD_MTMD_FILIAL_REQUISICAO = FILIAL_CE) THEN
       nFilialProduto := 1;
   ELSE
       nFilialProduto := FNC_MTMD_RETORNA_FILIAL( pCAD_MTMD_ID, vCAD_MTMD_FILIAL_REQUISICAO, vCAD_SET_ID );
   END IF;
   -- VERIFICA SE ITEM FAZ PARTE DA REQUSIC?O
   nProdutoOriginal := 0; -- nao e similar
   BEGIN
       SELECT NVL(ITEM.mtmd_reqitem_qtd_fornecida,0), ITEM.MTMD_REQITEM_QTD_SOLICITADA,
              NVL(ITEM.MTMD_ID_ORIGINAL,0),            ITEM.CAD_MTMD_PRESCRICAO_ID,      CAD_MTMD_KIT_ID_ITEM,
              CAD_MTMD_GRUPO_ID
       INTO   nFornecida,                             vMTMD_REQITEM_QTD_SOLICITADA,
              nProdutoOriginal,                       vCAD_MTMD_PRESCRICAO_ID,          vCAD_MTMD_KIT_ID_ITEM,
              vCAD_MTMD_GRUPO_ID
       FROM TB_MTMD_REQUISICAO_ITEM ITEM JOIN
            TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = ITEM.CAD_MTMD_ID
       WHERE ITEM.mtmd_req_id   = pMTMD_REQ_ID
       AND   ITEM.cad_mtmd_id   = pCAD_MTMD_ID;       
       IF (NVL(vCAD_MTMD_PRESCRICAO_ID,0) != 0 AND NVL(pCAD_MTMD_PRIATI_ID,0) != 0) THEN
        SELECT PI.CAD_MTMD_ID 
          INTO vCAD_MTMD_ID_PRESCRICAO
          FROM TB_CAD_MTMD_PRESCRICAO_ITEM PI JOIN
               TB_CAD_MTMD_MAT_MED MED ON MED.CAD_MTMD_ID = PI.CAD_MTMD_ID
         WHERE NVL(PI.CAD_MTMD_PRC_ITEM_STATUS,1) = 1
           AND PI.CAD_MTMD_PRESCRICAO_ID = vCAD_MTMD_PRESCRICAO_ID
           AND MED.CAD_MTMD_PRIATI_ID = pCAD_MTMD_PRIATI_ID;
       END IF;
       IF ( nProdutoOriginal > 0 ) THEN
          -- BUSCA QTD SOLICITADA DO ORIGINAL
          BEGIN
            SELECT ITEM.MTMD_REQITEM_QTD_SOLICITADA
            INTO   vMTMD_REQITEM_QTD_SOLICITADA
            FROM TB_MTMD_REQUISICAO_ITEM ITEM
            WHERE ITEM.mtmd_req_id   = pMTMD_REQ_ID
            AND   ITEM.cad_mtmd_id   = nProdutoOriginal;
          EXCEPTION WHEN NO_DATA_FOUND THEN
             RAISE_APPLICATION_ERROR(-20000,'SIMILAR SEM ORIGINAL');
          END;
          BEGIN
            SELECT ITEM.CAD_MTMD_PRESCRICAO_ID
             INTO  vCAD_MTMD_PRESCRICAO_ID
             FROM TB_MTMD_REQUISICAO_ITEM ITEM
             WHERE ITEM.mtmd_req_id   = pMTMD_REQ_ID
             AND   ITEM.cad_mtmd_id   = nProdutoOriginal;
            vCAD_MTMD_ID_PRESCRICAO := nProdutoOriginal;
            IF (NVL(pCAD_MTMD_PRIATI_ID,0) != 0) THEN
              SELECT PI.CAD_MTMD_ID 
                INTO vCAD_MTMD_ID_PRESCRICAO
                FROM TB_CAD_MTMD_PRESCRICAO_ITEM PI JOIN
                     TB_CAD_MTMD_MAT_MED MED ON MED.CAD_MTMD_ID = PI.CAD_MTMD_ID
               WHERE NVL(PI.CAD_MTMD_PRC_ITEM_STATUS,1) = 1
                 AND PI.CAD_MTMD_PRESCRICAO_ID = vCAD_MTMD_PRESCRICAO_ID
                 AND MED.CAD_MTMD_PRIATI_ID = pCAD_MTMD_PRIATI_ID;
            END IF;
          EXCEPTION WHEN NO_DATA_FOUND THEN
             NULL;
          END;
       END IF;
   EXCEPTION WHEN NO_DATA_FOUND THEN
      -- N?O FAZ PARTE DA REQUISICAO, VERIFICA SIMILAR
      IF (pCAD_MTMD_PRIATI_ID > 0) THEN
         SELECT ITEM.cad_mtmd_id
           INTO   nProdutoOriginal
           FROM TB_MTMD_REQUISICAO_ITEM ITEM JOIN
                TB_CAD_MTMD_MAT_MED MATMED ON MATMED.CAD_MTMD_ID = ITEM.CAD_MTMD_ID
           WHERE ITEM.mtmd_req_id = pMTMD_REQ_ID
           AND   MATMED.CAD_MTMD_PRIATI_ID = pCAD_MTMD_PRIATI_ID
           AND   ITEM.MTMD_ID_ORIGINAL IS NULL;
      ELSE
         nProdutoOriginal := FNC_MTMD_REQ_ITEM_SIMILAR( pCAD_MTMD_ID, pMTMD_REQ_ID, pCAD_MTMD_PRIATI_ID);
      END IF;
      IF ( nProdutoOriginal = 0 ) THEN
         -- NAO E ORIGINAL DA REQUISICAO NEM SIMILAR A UM ITEM DA REQUISIC?O
         RAISE_APPLICATION_ERROR(-20000, 'ITEM NAO CONSTA DA REQUISIC?O !!!' );
      END IF;
      BEGIN
        SELECT ITEM.CAD_MTMD_PRESCRICAO_ID
         INTO  vCAD_MTMD_PRESCRICAO_ID
         FROM TB_MTMD_REQUISICAO_ITEM ITEM
         WHERE ITEM.mtmd_req_id   = pMTMD_REQ_ID
         AND   ITEM.cad_mtmd_id   = nProdutoOriginal;
        vCAD_MTMD_ID_PRESCRICAO := nProdutoOriginal;
        IF (NVL(pCAD_MTMD_PRIATI_ID,0) != 0) THEN
          SELECT PI.CAD_MTMD_ID 
            INTO vCAD_MTMD_ID_PRESCRICAO
            FROM TB_CAD_MTMD_PRESCRICAO_ITEM PI JOIN
                 TB_CAD_MTMD_MAT_MED MED ON MED.CAD_MTMD_ID = PI.CAD_MTMD_ID
           WHERE NVL(PI.CAD_MTMD_PRC_ITEM_STATUS,1) = 1
             AND PI.CAD_MTMD_PRESCRICAO_ID = vCAD_MTMD_PRESCRICAO_ID
             AND MED.CAD_MTMD_PRIATI_ID = pCAD_MTMD_PRIATI_ID;
         END IF;
      EXCEPTION WHEN NO_DATA_FOUND THEN
         NULL;
      END;
      nFornecida := 0;
   END;
   -- SOMA QUANTIDADE JA FORNECIDA COM QUANTIDADE ATUAL
   nFornecida := nFornecida + pMTMD_REQITEM_QTD_FORNECIDA;
   -- SOMA QTDE SIMILARES JA LIBERADOS NESTA REQUISIC?O
   -- PODE EXISTIR DISPENSAC?O PARTE DO PRODUTO ORIGINAL E PARTE DE SIMILAR
   nTotalSimilarRequisicao := FNC_MTMD_REQ_SOMA_SIMILAR( pCAD_MTMD_ID, pMTMD_REQ_ID, pCAD_MTMD_PRIATI_ID );
   IF (vSETOR_FARMACIA IS NOT NULL OR vCAD_MTMD_GRUPO_ID = 1 OR vMTM_TIPO_REQUISICAO NOT IN (PADRAO) OR
       (vSETOR_FARMACIA IS NULL AND vCAD_MTMD_GRUPO_ID = 1 AND vMTM_TIPO_REQUISICAO IN (PADRAO))) THEN
     -- VERIFICA SE E MAIOR QUE QTDE SOLICITADA (liberar apenas para padrao dispensado pelo Almox. Central)
     IF ( ( nFornecida + nTotalSimilarRequisicao ) > vMTMD_REQITEM_QTD_SOLICITADA ) THEN
        RAISE_APPLICATION_ERROR(-20000, 'QTDE DISPENSADA MAIOR QUE QTDE SOLICITADA !!!' );
     END IF;
   END IF;
   -- VERIFICA SE PRODUTO E PADRAO NA UNIDADE
   IF ( vMTM_TIPO_REQUISICAO IN (PADRAO,CARRINHO_EMERG)) THEN --==================== PADR?O =========================
      IF ( nProdutoOriginal > 0 ) THEN
         -- PRODUTO ATUAL E SIMILAR VERIFICA SE ITEM ORIGINAL DA REQUISICAO E PADRAO
         vMTMD_PEDPAD_QTDE := FNC_MTMD_PRODUTO_PADRAO ( nProdutoOriginal,
                                                        vCAD_MTMD_FILIAL_REQUISICAO,
                                                        vCAD_SET_ID,
                                                        vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                        vCAD_UNI_ID_UNIDADE
                                                      );
      ELSE
         -- PRODUTO ATUAL N?O E SIMILAR, VEIRIFCA QTDE DELE MESMO
         vMTMD_PEDPAD_QTDE := FNC_MTMD_PRODUTO_PADRAO ( pCAD_MTMD_ID,
                                                        vCAD_MTMD_FILIAL_REQUISICAO,
                                                        vCAD_SET_ID,
                                                        vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                        vCAD_UNI_ID_UNIDADE
                                                      );
      END IF;
      -- QTDE FORNECIDA NAO PODE SER MAIOR QUE QUANTIDADE PADRAO DA UNIDADE
      IF (vMTM_TIPO_REQUISICAO IN (CARRINHO_EMERG) AND vMTMD_PEDPAD_QTDE > 0 AND vCAD_SET_ID NOT IN (61,2592,2632)) THEN --Nao Validar C.Cir./Farm
         -- BUSCA QTDE EM ESTOQUE NA UNIDADE
         IF (vMTM_TIPO_REQUISICAO = CARRINHO_EMERG) THEN
           nEstoqueUnidade := FNC_MTMD_EST_PADRAO_UNIDADE( pCAD_MTMD_PRIATI_ID,
                                                           pCAD_MTMD_ID,
                                                           vCAD_UNI_ID_UNIDADE,
                                                           vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                           vCAD_SET_ID,
                                                           FILIAL_CE,
                                                           NULL -- pMTMD_LOTEST_ID
                                                          );
         ELSE
           nEstoqueUnidade := FNC_MTMD_EST_PADRAO_UNIDADE( pCAD_MTMD_PRIATI_ID,
                                                           pCAD_MTMD_ID,
                                                           vCAD_UNI_ID_UNIDADE,
                                                           vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                           vCAD_SET_ID,
                                                           nFilialProduto,
                                                           NULL -- pMTMD_LOTEST_ID
                                                          );
         END IF;
         IF ( ( nEstoqueUnidade + pMTMD_REQITEM_QTD_FORNECIDA + nTotalSimilarRequisicao ) > vMTMD_PEDPAD_QTDE  ) THEN
            RAISE_APPLICATION_ERROR(-20006, 'QTDE FORNECIDA NAO PODE SER MAIOR QUE A QUANTIDADE PADRAO NA UNIDADE !!!' );
         END IF;
      --ELSIF (vMTM_TIPO_REQUISICAO = PADRAO AND vCAD_SET_ID NOT IN (61,2592,2632)) THEN
        -- RAISE_APPLICATION_ERROR(-20000, 'PRODUTO NAO PADRAO EM UMA REQUISICAO PADRAO !!!' );
      END IF; -- QTDE PADRAO MAIOR QUE ZERO
   END IF; -- VERIFICA SE E TIPO PADRAO ==================== PADR?O ================================
   IF (NVL(vCAD_MTMD_PRESCRICAO_ID,0) > 0) THEN
     --Validar Item Prescricao
     BEGIN
       SELECT NVL(PI.CAD_MTMD_PRC_QTDE_TOTAL,0),  PI.CAD_MTMD_DT_FIM_CONS
         INTO nQtdTotalAutoPrescricao,            vCAD_MTMD_DT_FIM_CONS
         FROM TB_CAD_MTMD_PRESCRICAO_ITEM PI
        WHERE NVL(PI.CAD_MTMD_PRC_ITEM_STATUS,1) = 1 AND
              PI.CAD_MTMD_PRESCRICAO_ID = vCAD_MTMD_PRESCRICAO_ID AND
              PI.CAD_MTMD_ID IN (vCAD_MTMD_ID_PRESCRICAO);
        SELECT SUM(RI.MTMD_REQITEM_QTD_FORNECIDA)
          INTO nQtdFornOutrosPedidosPrescr
          FROM TB_MTMD_REQUISICAO_ITEM RI JOIN
               TB_MTMD_REQ_REQUISICAO R ON R.MTMD_REQ_ID = RI.MTMD_REQ_ID
          WHERE RI.MTMD_REQ_ID != pMTMD_REQ_ID AND
                R.ATD_ATE_ID   = vATD_ATE_ID AND
                RI.CAD_MTMD_ID IN (vCAD_MTMD_ID_PRESCRICAO) AND
                RI.CAD_MTMD_PRESCRICAO_ID = vCAD_MTMD_PRESCRICAO_ID;
        IF ((nFornecida + nQtdFornOutrosPedidosPrescr) > nQtdTotalAutoPrescricao) THEN
           RAISE_APPLICATION_ERROR(-20000, 'QTDE TOTAL FORNECIDA DESTE ITEM NAO PODE SER MAIOR QUE A QUANTIDADE AUTORIZADA DA PRESCRICAO ' || TO_CHAR(vCAD_MTMD_PRESCRICAO_ID) || '!!!');
        END IF;
        IF (TRUNC(SYSDATE) > TRUNC(vCAD_MTMD_DT_FIM_CONS)) THEN
           RAISE_APPLICATION_ERROR(-20000, 'DATA ATUAL NAO PODE SER MAIOR QUE A DATA LIMITE CONSUMO DA PRESCRICAO ' || TO_CHAR(vCAD_MTMD_PRESCRICAO_ID) || '!!!');
        END IF;
     EXCEPTION WHEN NO_DATA_FOUND THEN
         RAISE_APPLICATION_ERROR(-20000, 'ITEM NAO CONSTA NA PRESCRICAO ' || TO_CHAR(vCAD_MTMD_PRESCRICAO_ID) || '!!!');
     END;
   END IF;
   /* RETIRADO VERIFICAC?O FOI CENTRALIZADA NA PROCEDURE DE BAIXA DO CENTRO DE DISP.
   -- VERIFICA SE EXISTE EM ESTOQUE NO CENTRO DE DISPENSACAO
   nEstoqueUnidade := NVL(FNC_MTMD_ESTOQUE_CENT_DISP ( pCAD_MTMD_ID,
                                                       vCAD_UNI_ID_UNIDADE,
                                                       vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                       vCAD_SET_ID,
                                                       nFilialProduto,
                                                       NULL
                                         ),0);
   IF ( nEstoqueUnidade < pMTMD_REQITEM_QTD_FORNECIDA ) THEN
--      RAISE_APPLICATION_ERROR(-20010, 'N?O EXISTE ESTOQUE PARA DISPENSAR ESTE ITEM !!! SALDO '||TO_CHAR(nEstoqueUnidade) );
      RAISE_APPLICATION_ERROR(-20010, 'N?O EXISTE ESTOQUE PARA DISPENSAR ESTE ITEM !!! SALDO '||TO_CHAR(nEstoqueUnidade)||' U/L/S '||TO_CHAR(vCAD_UNI_ID_UNIDADE)||
                                                                                                                                '/'||TO_CHAR(vCAD_LAT_ID_LOCAL_ATENDIMENTO)||
                                                                                                                                '/'||TO_CHAR(vCAD_SET_ID));
   END IF;
   */
   -- PRECISA VERIFICAR SE O PRODUTO E ACS E A FILIAL E HOSPITAL ?????????????????
   -- SE FOR MEDICAMENTO SIMILAR INSERE PRODUTO
   IF ( nProdutoOriginal > 0 ) THEN
      BEGIN
         PRC_MTMD_REQUISICAO_ITEM_I( pMTMD_REQ_ID,
                                     pCAD_MTMD_ID,
                                     nFornecida,
                                     nFornecida,
                                     nProdutoOriginal,
                                     vCAD_MTMD_PRESCRICAO_ID
                                    );
      EXCEPTION WHEN DUP_VAL_ON_INDEX THEN
         -- SO E NECESSARIO DA PRIMEIRA VEZ QUE TENTAR DISPENSAR PRODUTO
         -- NA SEGUNDA PASSAGEM O PRODUTO JA FAZ PARTE DA REQUISICAO
         --
         -- ATUALIZA QTDE FORNECIDA NA REQUISICAO
         PRC_MTMD_REQUISICAO_ITEM_U( pMTMD_REQ_ID,
                                     pCAD_MTMD_ID,
                                     nFornecida,
                                     nFornecida
                                    );
      END;
   ELSE
      -- N?O SIMILAR, ATUALIZA QTDE FORNECIDA NA REQUISICAO
      PRC_MTMD_REQUISICAO_ITEM_U( pMTMD_REQ_ID,
                                  pCAD_MTMD_ID,
                                  vMTMD_REQITEM_QTD_SOLICITADA,
                                  nFornecida,
                                  vCAD_MTMD_KIT_ID_ITEM
                                 );
   END IF;
   vCAD_MTMD_TPMOV_S := 2; -- BAIXA
   IF ( vMTM_TIPO_REQUISICAO = PADRAO ) THEN
      vCAD_MTMD_SUBTP_S := BAIXA_PADRAO;
      vCAD_MTMD_SUBTP_E := ENTRADA_PADRAO;
   ELSIF ( vMTM_TIPO_REQUISICAO = PKG_MTMD_CONSTANTES.REQ_PERSONALIZADA ) THEN
      vCAD_MTMD_SUBTP_S := BAIXA_PERSONALIZADA;
      vCAD_MTMD_SUBTP_E := ENTRADA_PERSONALIZADA;
   ELSIF ( vMTM_TIPO_REQUISICAO IN (HIGIENIZACAO, OUTROS, AVULSO, 9)) THEN --9 = MANUTENCAO
      vCAD_MTMD_SUBTP_S := BAIXA_AVULSO;
      vCAD_MTMD_SUBTP_E := ENTRADA_AVULSO;
   ELSIF ( vMTM_TIPO_REQUISICAO = PKG_MTMD_CONSTANTES.REQ_CARRINHO_EMERGENCIA ) THEN
      vCAD_MTMD_SUBTP_S := BAIXA_CARRINHO;
      vCAD_MTMD_SUBTP_E := ENTRADA_CARRINHO;
   ELSIF ( vMTM_TIPO_REQUISICAO = PKG_MTMD_CONSTANTES.REQ_ESTOQUE_LOCAL ) THEN
      vCAD_MTMD_SUBTP_S := PKG_MTMD_CONSTANTES.MOV_BXA_REQ_ESTOQUE_LOCAL;
      vCAD_MTMD_SUBTP_E := PKG_MTMD_CONSTANTES.MOV_ENT_REQ_ESTOQUE_LOCAL;
   END IF;
   PRC_MTMD_MOV_BAIXA_CENT_DISP( pCAD_MTMD_ID,
                                 pMTMD_LOTEST_ID,
                                 nFilialProduto, -- CUIDADO CARRINHO DE EMERGENCIA SO EXISTE NAS UNIDADES AQUI SEMPRE SERA HAC
                                 pMTMD_REQ_ID,
                                 vCAD_UNI_ID_UNIDADE,
                                 vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                 vCAD_SET_ID,
                                 vCAD_MTMD_TPMOV_S,
                                 vCAD_MTMD_SUBTP_S,
                                 pMTMD_REQITEM_QTD_FORNECIDA,
                                 vATD_ATE_ID,
                                 vATD_ATE_TP_PACIENTE,
                                 0, -- pMTMD_MOV_FL_FINALIZADO,
                                 pMTMD_ID_USUARIO_DISPENSACAO,
                                 0, -- Reserva produto do estoque do centro de dispensac?o ( almoxarifado)
                                 vNewIdt
                                );
    /*IF (vCAD_SET_ID = 2252 AND vMTM_TIPO_REQUISICAO = PKG_MTMD_CONSTANTES.REQ_PERSONALIZADA ) THEN --PARA ATENDIMENTO DOMICILIAR DAR ENTRADA DIRETO NO PEDIDO PERSONALIZADO
       PRC_MTMD_MOV_ENTRADA_UNIDADE ( pCAD_MTMD_ID,
                                      pMTMD_LOTEST_ID,
                                      nFilialProduto,
                                      pMTMD_REQ_ID,
                                      vCAD_UNI_ID_UNIDADE,
                                      vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                      vCAD_SET_ID,
                                      1, --ENTRADA
                                      9, --ENTRADA_PERSONALIZADA
                                      pMTMD_REQITEM_QTD_FORNECIDA,
                                      vATD_ATE_ID,
                                      vATD_ATE_TP_PACIENTE,
                                      1,
                                      pMTMD_ID_USUARIO_DISPENSACAO,
                                      NULL,
                                      vNewIdt );
    END IF;*/
    IF (nProdutoOriginal = 0 OR
        (vMTM_TIPO_REQUISICAO NOT IN (PADRAO,CARRINHO_EMERG) AND nProdutoOriginal > 0)) THEN
       nProdutoOriginal := NULL;
    ELSIF (vMTM_TIPO_REQUISICAO IN (CARRINHO_EMERG) AND NVL(pCAD_MTMD_PRIATI_ID,0) != 0) THEN
      BEGIN
         SELECT ITEM.CAD_MTMD_ID
         INTO  nProdutoOriginal
         FROM TB_MTMD_PEDIDO_PADRAO       PADRAO,
              TB_MTMD_PEDIDO_PADRAO_ITENS ITEM,
              TB_CAD_MTMD_MAT_MED         PROD
         WHERE PADRAO.CAD_MTMD_FILIAL_ID            = vCAD_MTMD_FILIAL_REQUISICAO
         AND   PADRAO.cad_uni_id_unidade            = vCAD_UNI_ID_UNIDADE
         AND   PADRAO.cad_lat_id_local_atendimento  = vCAD_LAT_ID_LOCAL_ATENDIMENTO
         AND   PADRAO.cad_set_id                    = vCAD_SET_ID
         AND   ITEM.mtmd_pedpad_id                  = PADRAO.MTMD_PEDPAD_ID
         AND   PROD.CAD_MTMD_ID                     = ITEM.CAD_MTMD_ID
         AND   PROD.CAD_MTMD_PRIATI_ID              = pCAD_MTMD_PRIATI_ID;
      EXCEPTION
          WHEN OTHERS THEN
             nProdutoOriginal := NULL;
      END;
    END IF;
    PRC_MTMD_MOV_ENTRADA_UNIDADE ( pCAD_MTMD_ID,
                                    pMTMD_LOTEST_ID,
                                    vCAD_MTMD_FILIAL_REQUISICAO,
                                    pMTMD_REQ_ID,
                                    vCAD_UNI_ID_UNIDADE,
                                    vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                    vCAD_SET_ID,
                                    1, --ENTRADA
                                    vCAD_MTMD_SUBTP_E,
                                    pMTMD_REQITEM_QTD_FORNECIDA,
                                    vATD_ATE_ID,
                                    vATD_ATE_TP_PACIENTE,
                                    1,
                                    pMTMD_ID_USUARIO_DISPENSACAO,
                                    nProdutoOriginal,
                                    nIdEntrada );
     -- ATUALIZA REFENRENCIA DA MOVIMENTAC?O DE BAIXA APONTANDO PARA A  MOVIMENTAC?OD E ENTRADA
    UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
    MTMD_MOV_ID_REF = vNewIdt
    WHERE MTMD_MOV_ID = nIdEntrada;
    -- ATUALIZA REFERENCIA DA MOVIMENTAC?O DE ENTRADA APONTANDO PARA A MOVIMENTAC?O DE BAIXA
    UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
    MTMD_MOV_ID_REF = nIdEntrada
    WHERE MTMD_MOV_ID = vNewIdt;
    IF (NVL(vCAD_MTMD_PRESCRICAO_ID,0) > 0) THEN
       --ATUALIZAR QTD. DISPENSADA NA PRESCRICAO
       UPDATE TB_CAD_MTMD_PRESCRICAO_ITEM PI
          SET PI.CAD_MTMD_PRC_QTDE_DISP = NVL(PI.CAD_MTMD_PRC_QTDE_DISP,0) + pMTMD_REQITEM_QTD_FORNECIDA
        WHERE NVL(PI.CAD_MTMD_PRC_ITEM_STATUS,1) = 1 AND
              PI.CAD_MTMD_PRESCRICAO_ID = vCAD_MTMD_PRESCRICAO_ID AND
              PI.CAD_MTMD_ID IN (vCAD_MTMD_ID_PRESCRICAO);
    END IF;
END PRC_MTMD_REQ_ITEM_DISP_I;