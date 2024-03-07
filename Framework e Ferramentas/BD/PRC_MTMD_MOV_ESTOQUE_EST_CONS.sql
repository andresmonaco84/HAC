CREATE OR REPLACE PROCEDURE "PRC_MTMD_MOV_ESTOQUE_EST_CONS"
(
     pMTMD_MOV_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_ID%type,
     pCAD_MTMD_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type,
     --pMTMD_LOTEST_ID               IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_LOTEST_ID%type DEFAULT NULL,
     pCAD_MTMD_FILIAL_ID           IN TB_CAD_MTMD_FILIAL.CAD_MTMD_FILIAL_ID%type,
     pCAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_SET_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type,
     pMTMD_ESTLOC_QTDE             IN TB_MTMD_ESTOQUE_LOCAL.MTMD_ESTLOC_QTDE%type DEFAULT NULL,
     pMTMD_ID_USUARIO_ESTORNO      IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_ID_USUARIO_ESTORNO%type,
     pCAD_MTMD_SUBTP_ID            IN TB_CAD_MTMD_SUBTP_MOVIMENTACAO.CAD_MTMD_SUBTP_ID%TYPE DEFAULT NULL
)
IS
  /***********************************************************************************************
  *    Procedure: PRC_MTMD_MOV_ESTOQUE_EST_CONS
  *
  *    Data Criacao: 03/2009      Por: RICARDO COSTA
  *    Data Alteracao: 04/02/2010 Por: RICARDO COSTA
  *         Alterac?o: Chamada da procedure de faturamento
  *    Data Alteracao: 31/03/2010 Por: ANDRE SOUZA MONACO
  *         Alterac?o: A qtd. do movimento e buscada dentro da procedure
  *                    garantindo que ela esteja certa
  *    Data Alteracao: 07/04/2010 Por: ANDRE SOUZA MONACO
  *         Alterac?o: N?o estornar quando ambulatorio
  *    Data Alteracao: 19/04/2010 Por: RICARDO COSTA
  *         Alterac?o: Verificac?o Carrinho de emergencia para estoque contabil
  *    Data Alteracao: 21/03/2011      Por: Andre Souza Monaco
  *         Descric?o: Desativac?o do interface com o legado
  *    Data Alteracao: 16/10/2015      Por: Andre Souza Monaco
  *         Descric?o: Atualizar qtd. fornecida quando tiver MTMD_REQ_ID e for Kit
  *    Data Alteracao: 16/05/2016      Por: Andre Souza Monaco
  *         Descric?o: Atualizar qtd. fornecida quando tiver pMTMD_REQ_ID e for com prescricao quando for UTI GERAL/CARDIO
  *
  *    Funcao: ESTORNA CONSUMO DO PRODUTO E EXCLUI DO FATURAMENTO
  *            CHAMADA DA TELA DE HISTORICO DE CONSUMO DO PACIENTE (ATENDIMENTO)
  *            CHAMADA DA PROCEDURE DE ESTORNO DE CONSUMO CCENTRO DE CUSTO
  ************************************************************************************************/
   nFracionado        TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_FRACIONA%TYPE;
   nBaixaAutomatica   TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_BAIXA_AUTOMATICA%TYPE;
   bFaturado          TB_CAD_MTMD_SUBTP_MOVIMENTACAO.CAD_MTMD_FL_FATURA%TYPE;
--   nUnidadeVenda NUMBER;
   nQtdeConsumida     NUMBER;
   nQtdeEstLoc        NUMBER;
   -- nQtdeEstLocFracionada NUMBER; (N?o estamos mais controlando a Qtd. Fracionada)
   nSubTpMov             TB_CAD_MTMD_SUBTP_MOVIMENTACAO.CAD_MTMD_SUBTP_ID%TYPE;
   bMovimentaEstoque     BOOLEAN;
   nTabelaMedica         TB_CAD_MTMD_MAT_MED.TIS_MED_CD_TABELAMEDICA%TYPE;
   nFilial               TB_CAD_MTMD_FILIAL.CAD_MTMD_FILIAL_ID%type;
   nFilialMov            TB_CAD_MTMD_FILIAL.CAD_MTMD_FILIAL_ID%type;
   pNewIdt               TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_ID%type;
   vPERCENTUAL           NUMBER;
   vATD_ATE_ID           TB_MTMD_MOV_MOVIMENTACAO.atd_ate_id%TYPE;
   vATD_ATE_TP_PACIENTE  TB_MTMD_MOV_MOVIMENTACAO.ATD_ATE_TP_PACIENTE%TYPE;
   nReutilizavel         TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_REUTILIZAVEL%TYPE;
   vMTMD_LOTEST_ID       TB_MTMD_MOV_MOVIMENTACAO.MTMD_LOTEST_ID%TYPE;
SIM CONSTANT NUMBER := 1;
NAO CONSTANT NUMBER := 0;
-- SUB_MOV_CONS_PAC_EST_FRAC    CONSTANT NUMBER := 17; -- ESTORNO CONSUMO FRACIONADO
-- SUB_MOV_CONS_PAC_EST         CONSTANT NUMBER := 16; -- ESTONRO CONSUMO PACIENTE
-- SUB_MOV_ESTORNO_CONS_CCUSTO  CONSTANT NUMBER := 29;
-- SUB_MOV_CONS_PACIENTE        CONSTANT NUMBER := 11;
-- SUB_MOV_CONS_PAC_FRAC        CONSTANT NUMBER := 14;
-- SUB_TP_BAIXA_FRAC_NAO_FAT    CONSTANT NUMBER := 35;
-- ESTORNO_BAIXA_FRAC_NAO_FAT   CONSTANT NUMBER := 38;
-- SUB_MOV_BAIXA_CONSUMO_CCUSTO CONSTANT NUMBER := 19;
-- SUB_CONSUMO_CAR_EMERGENCIA   CONSTANT NUMBER := 25;
-- SUB_MOV_BAIXA_NAO_FATURADO   CONSTANT NUMBER := 18;
-- ESTORNO_BAIXA_NAO_FATURADO   CONSTANT NUMBER := 13;
FILIAL_CARRINHO_EMERGENCIA   CONSTANT NUMBER := 4;
TABELA_MEDICA_MATERIAL       CONSTANT NUMBER := 95;
TABELA_MEDICA_MEDICAMENTO    CONSTANT NUMBER := 96;
TIPO_MOVIMENTO_ENTRADA       CONSTANT NUMBER := 1;
TIPO_MOVIMENTO_SAIDA         CONSTANT NUMBER := 2;
vMTMD_REQ_ID               TB_MTMD_MOV_MOVIMENTACAO.MTMD_REQ_ID%type;
vUNIDADE_ESTOQUE_CONSUMO   TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type;
vLOCAL_ESTOQUE_CONSUMO     TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type;
vSETOR_ESTOQUE_CONSUMO     TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type;
--vCAD_MTMD_KIT_ID           TB_MTMD_REQ_REQUISICAO.CAD_MTMD_KIT_ID%type;
vSETOR_FARMACIA            TB_MTMD_REQ_REQUISICAO.CAD_SET_SETOR_FARMACIA%TYPE;
vCAD_MTMD_PRESCRICAO_ID    TB_MTMD_REQUISICAO_ITEM.CAD_MTMD_PRESCRICAO_ID%TYPE;
vCAD_MTMD_ID_PRESCRICAO    TB_MTMD_REQUISICAO_ITEM.CAD_MTMD_ID%TYPE := pCAD_MTMD_ID;
vCAD_MTMD_ID_ORIGINAL      TB_MTMD_REQUISICAO_ITEM.CAD_MTMD_ID%TYPE := pCAD_MTMD_ID;
vCAD_MTMD_PRIATI_ID        TB_CAD_MTMD_MAT_MED.CAD_MTMD_PRIATI_ID%TYPE;
nConsumo NUMBER;
----------------------------------------------------------------------------------------------------
-- VERIFICA SE TIPO DE MOVIMENTO E FATURADO
----------------------------------------------------------------------------------------------------
FUNCTION FNC_MTMD_MOV_COBRA_PRODUTO( ppCAD_MTMD_SUBTP_ID  IN NUMBER) RETURN NUMBER IS Faturado NUMBER;
BEGIN
   SELECT SUBTP.CAD_MTMD_FL_FATURA
   INTO Faturado
   FROM TB_CAD_MTMD_SUBTP_MOVIMENTACAO SUBTP
   WHERE SUBTP.CAD_MTMD_SUBTP_ID = ppCAD_MTMD_SUBTP_ID;
   RETURN Faturado;
END FNC_MTMD_MOV_COBRA_PRODUTO;
----------------------------------------------------------------------------------------------------
-- VERIFICA SE TIPO DE MOVIMENTO ALTERA ESTOQUE CONTABIL
----------------------------------------------------------------------------------------------------
FUNCTION FNC_GERA_MOV_CONTABIL( pppCAD_MTMD_SUBTP_ID IN NUMBER) RETURN NUMBER IS
     nCAD_MTMD_FL_CONSUMO  NUMBER;
BEGIN
   SELECT SUBTP.CAD_MTMD_FL_CONSUMO
   INTO nCAD_MTMD_FL_CONSUMO
   FROM TB_CAD_MTMD_SUBTP_MOVIMENTACAO SUBTP
   WHERE SUBTP.CAD_MTMD_SUBTP_ID = pppCAD_MTMD_SUBTP_ID;
   RETURN nCAD_MTMD_FL_CONSUMO;
END FNC_GERA_MOV_CONTABIL;
-- #############################################################################################
BEGIN
   BEGIN
   -- BUSCA REGISTRO DA MOVIMENTAC?O
   SELECT MOV.CAD_MTMD_FILIAL_ID , MOV.CAD_MTMD_SUBTP_ID,   MTMD_REQ_ID,
          MOV.atd_ate_id,          MOV.atd_ate_tp_paciente, MOV.MTMD_MOV_QTDE, MTMD_LOTEST_ID
   INTO   nFilialMov,              nSubTpMov,               vMTMD_REQ_ID,
          vATD_ATE_ID,             vATD_ATE_TP_PACIENTE,    nQtdeConsumida,    vMTMD_LOTEST_ID
   FROM TB_MTMD_MOV_MOVIMENTACAO MOV
   WHERE MOV.MTMD_MOV_ID = pMTMD_MOV_ID
   AND   MOV.MTMD_MOV_FL_ESTORNO = 0;
   EXCEPTION WHEN NO_DATA_FOUND THEN
      RAISE_APPLICATION_ERROR(-20000,' MOVIMENTO N?O ENCONTRADO, ESTORNO CONSUMO  ');
   END;
   IF (nFilialMov = 4) THEN
      nFilial := nFilialMov;
   ELSE
      nFilial := FNC_MTMD_RETORNA_FILIAL( pCAD_MTMD_ID, nFilialMov, pCAD_SET_ID);
   END IF;
   -- VERIFICA DE QUAL ESTOQUE O SETOR CONSOME
   PRC_MTMD_ESTOQUE_DE_CONSUMO( pCAD_UNI_ID_UNIDADE,
                                pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                pCAD_SET_ID,
                                nFilial,
                                vUNIDADE_ESTOQUE_CONSUMO,
                                vLOCAL_ESTOQUE_CONSUMO,
                                vSETOR_ESTOQUE_CONSUMO
                               );
   -- RAISE_APPLICATION_ERROR(-20000,' FILIAL '||TO_CHAR(nFilial)||' MOV '||TO_CHAR(nSubTpMov) );
   -- VERIFICA SE E FRACIONADO
   bMovimentaEstoque  := TRUE;
   BEGIN
      -- BUSCA INFORMACOES SOBRE PRODUTO
      SELECT MATMED.CAD_MTMD_FL_FRACIONA,
             NVL(MATMED.CAD_MTMD_FL_BAIXA_AUTOMATICA, 0),
             MATMED.TIS_MED_CD_TABELAMEDICA,
             MATMED.CAD_MTMD_FL_REUTILIZAVEL,
             MATMED.CAD_MTMD_PRIATI_ID
      INTO   nFracionado,
             nBaixaAutomatica,
             nTabelaMedica,
             nReutilizavel,
             vCAD_MTMD_PRIATI_ID
      FROM TB_CAD_MTMD_MAT_MED MATMED
      WHERE MATMED.CAD_MTMD_ID = pCAD_MTMD_ID;
      -- EXISTEM PRODUTOS FRACIONADOS QUE PODEM SER BAIXADOS COMO INTEIROS
      -- VALE SEMPRE O TIPO DE MOVIMENTAC?O GRAVADA NO BANCO (11= INTEIRO / 14 = FRACIONADO)
      IF ( nSubTpMov IN ( PKG_MTMD_CONSTANTES.BAIXA_CONSUMO, PKG_MTMD_CONSTANTES.BAIXA_CAR_EMERGENCIA, 60)) THEN
         nFracionado := NAO;
         nSubTpMov       := PKG_MTMD_CONSTANTES.EST_CONSUMO;
      ELSIF ( nSubTpMov =  PKG_MTMD_CONSTANTES.BAIXA_CENTRO_CUSTO ) THEN
         nFracionado := NAO;
         nSubTpMov       := PKG_MTMD_CONSTANTES.EST_BAIXA_CENTRO_CUSTO;
      ELSIF ( nSubTpMov = PKG_MTMD_CONSTANTES.BAIXA_NAO_FATURADO ) THEN
         nFracionado := NAO;
         nSubTpMov       := PKG_MTMD_CONSTANTES.EST_NAO_FATURADO; -- 13
      ELSIF ( nSubTpMov IN ( PKG_MTMD_CONSTANTES.MOV_BXA_FRACIONADO, PKG_MTMD_CONSTANTES.MOV_BXA_CAR_EMERGENCIA_FRAC )) THEN
         nFracionado := SIM;
         nSubTpMov   := PKG_MTMD_CONSTANTES.EST_MOV_FRACIONADO;
         bMovimentaEstoque := FALSE;
         -- SE FOR BAIXA AUTOMATICA GERA MOVIMENTO CONTABIL
      ELSIF ( nSubTpMov = PKG_MTMD_CONSTANTES.MOV_BXA_FRAC_NAO_FATURADO ) THEN
         nFracionado := SIM;
         nSubTpMov   := PKG_MTMD_CONSTANTES.EST_MOV_FRAC_N_FATURADO;
         bMovimentaEstoque := FALSE;
      ELSIF ( nSubTpMov = PKG_MTMD_CONSTANTES.MOV_BXA_REUTILIZAVEL ) THEN
         nFracionado := SIM;
         nSubTpMov   := PKG_MTMD_CONSTANTES.EST_MOV_REUTILIZAVEL;
         bMovimentaEstoque := FALSE;
      END IF;
   END;
   /*IF ( FNC_MTMD_MOV_COBRA_PRODUTO( nSubTpMov ) = SIM AND vATD_ATE_TP_PACIENTE != 'A') THEN -- N?o executar faturamento quando ambulatorio
      BEGIN
         PRC_MTMD_MOV_FATURAR_ONLINE (pMTMD_MOV_ID, 1);
      EXCEPTION WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-20000,SQLERRM);
      END;
   END IF;*/
   PRC_MTMD_MOV_MOVIMENTACAO_I (  pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                  pCAD_UNI_ID_UNIDADE,
                                  pCAD_SET_ID,
                                  vMTMD_REQ_ID,
                                  vMTMD_LOTEST_ID,
                                  pCAD_MTMD_ID,
                                  nFilial, -- nFilial,
                                  TIPO_MOVIMENTO_ENTRADA,
                                  nSubTpMov,
                                  SYSDATE,
                                  nQtdeConsumida, -- QTDE CONSUMIDA
                                  SIM, -- pMTMD_MOV_FL_FINALIZADO
                                  vATD_ATE_ID,
                                  vATD_ATE_TP_PACIENTE,
                                  pMTMD_ID_USUARIO_ESTORNO,
                                  NULL, -- ID_CONVERCAO
                                  NULL, -- QTDE_CONVERTIDA
                                  NULL, -- DT_FAT
                                  NULL, -- HR_FAT
                                  pNewIdt
                               );
  -- MOVIMENTO CRIADO DO ESTORNO APONTA PARA O MOVIMENTO ESTORNADO
  -- MOVIMENTO ESTORNADO APONTA PARA O MOVIMENTO DO ESTORNO
  -- ATUALIZA MOVIMENTO DO ESTORNO
  UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
  MTMD_MOV_FL_ESTORNO     = SIM,
  MTMD_MOV_ID_REF         = pMTMD_MOV_ID
  WHERE MTMD_MOV_ID = pNewIdt;
  -- ATUALIZA MOVIMENTO ESTORNADO
  UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
  MTMD_ID_USUARIO_ESTORNO = pMTMD_ID_USUARIO_ESTORNO,
  MTMD_MOV_FL_ESTORNO     = SIM,
  MTMD_MOV_ID_REF         = pNewIdt
  WHERE MTMD_MOV_ID = pMTMD_MOV_ID;
  IF ( bMovimentaEstoque = true ) THEN
      BEGIN
          SELECT MTMD_MOV_CONSUMO
          INTO   nConsumo
          FROM TB_MTMD_ESTOQUE_LOCAL
          WHERE CAD_MTMD_ID                  = pCAD_MTMD_ID
          AND   CAD_UNI_ID_UNIDADE           = vUNIDADE_ESTOQUE_CONSUMO
          AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = vLOCAL_ESTOQUE_CONSUMO
          AND   CAD_SET_ID                   = vSETOR_ESTOQUE_CONSUMO
          AND   CAD_MTMD_FILIAL_ID           = nFilial;
        IF ( nConsumo > 0 )  THEN
           nConsumo := nQtdeConsumida;
        ELSE
           nConsumo := 0;
        END IF;
        UPDATE TB_MTMD_ESTOQUE_LOCAL SET
        MTMD_ESTLOC_QTDE = NVL(MTMD_ESTLOC_QTDE,0) + nQtdeConsumida,
        MTMD_MOV_CONSUMO = NVL(MTMD_MOV_CONSUMO,0) - nConsumo,
        MTMD_ESTLOC_DATA = SYSDATE
        WHERE CAD_MTMD_ID                  = pCAD_MTMD_ID
        AND   CAD_UNI_ID_UNIDADE           = vUNIDADE_ESTOQUE_CONSUMO
        AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = vLOCAL_ESTOQUE_CONSUMO
        AND   CAD_SET_ID                   = vSETOR_ESTOQUE_CONSUMO
        AND   CAD_MTMD_FILIAL_ID           = nFilial;
        IF ( FNC_GERA_MOV_CONTABIL( nSubTpMov ) = SIM ) THEN
           -- CHECA CARRINHO DE EMERGENCIA, N?O EXISTE NO ESTQOUE CONTABIL
           UPDATE TB_MTMD_ESTOQUE_CONTABIL SET
           MTMD_ESTCON_QTDE           = MTMD_ESTCON_QTDE + nQtdeConsumida,
           MTMD_ESTCON_DT_ATUALIZACAO = SYSDATE
           WHERE CAD_MTMD_ID        = pCAD_MTMD_ID
           AND   CAD_MTMD_FILIAL_ID = DECODE(nFilial,4,1,nFilial);
           IF SQL%FOUND THEN
              -- ATUALIZA PERCENTUAL DE CONSUMO
              PRC_MTMD_ESTOQUE_PER_CONSUMO_U(  pCAD_MTMD_ID,
                                               nFilial,
                                               vUNIDADE_ESTOQUE_CONSUMO,
                                               vLOCAL_ESTOQUE_CONSUMO,
                                               vSETOR_ESTOQUE_CONSUMO,
                                               vPERCENTUAL);
           END IF; -- FIM SQL%FOUND CONTABIL
        END IF;
      END;
      IF (vMTMD_REQ_ID IS NOT NULL) THEN
          IF (NVL(vCAD_MTMD_PRIATI_ID,0) != 0) THEN
            BEGIN
               SELECT ITEM.CAD_MTMD_ID
                 INTO vCAD_MTMD_ID_ORIGINAL
                 FROM TB_MTMD_REQUISICAO_ITEM ITEM JOIN
                      TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = ITEM.CAD_MTMD_ID
               WHERE ITEM.mtmd_req_id   = vMTMD_REQ_ID
                 AND M.CAD_MTMD_PRIATI_ID   = vCAD_MTMD_PRIATI_ID
                 AND ITEM.MTMD_ID_ORIGINAL IS NULL AND ROWNUM = 1;
                 
               IF (vCAD_MTMD_ID_ORIGINAL <> pCAD_MTMD_ID) THEN
                 UPDATE TB_MTMD_REQUISICAO_ITEM
                    SET MTMD_REQITEM_QTD_SOLICITADA = NVL(MTMD_REQITEM_QTD_SOLICITADA,0) - nQtdeConsumida
                  WHERE CAD_MTMD_ID = pCAD_MTMD_ID
                    AND MTMD_REQ_ID = vMTMD_REQ_ID;
               END IF;
            EXCEPTION WHEN NO_DATA_FOUND THEN
                     NULL;--Nao barrar processo
            END;
          END IF;
          BEGIN
            SELECT ITEM.CAD_MTMD_PRESCRICAO_ID
             INTO  vCAD_MTMD_PRESCRICAO_ID
             FROM TB_MTMD_REQUISICAO_ITEM ITEM
             WHERE ITEM.mtmd_req_id   = vMTMD_REQ_ID
             AND   ITEM.cad_mtmd_id   = pCAD_MTMD_ID
             AND   ITEM.MTMD_ID_ORIGINAL IS NULL;
             vCAD_MTMD_ID_PRESCRICAO := pCAD_MTMD_ID;
             IF (NVL(vCAD_MTMD_PRIATI_ID,0) != 0) THEN
              SELECT PI.CAD_MTMD_ID 
                INTO vCAD_MTMD_ID_PRESCRICAO
                FROM TB_CAD_MTMD_PRESCRICAO_ITEM PI JOIN
                     TB_CAD_MTMD_MAT_MED MED ON MED.CAD_MTMD_ID = PI.CAD_MTMD_ID
               WHERE NVL(PI.CAD_MTMD_PRC_ITEM_STATUS,1) = 1
                 AND PI.CAD_MTMD_PRESCRICAO_ID = vCAD_MTMD_PRESCRICAO_ID
                 AND MED.CAD_MTMD_PRIATI_ID = vCAD_MTMD_PRIATI_ID;
             END IF;
          EXCEPTION WHEN NO_DATA_FOUND THEN --PROCURA SIMILAR
             IF (NVL(vCAD_MTMD_PRIATI_ID,0) != 0) THEN
                 BEGIN
                    SELECT ITEM.CAD_MTMD_PRESCRICAO_ID, ITEM.CAD_MTMD_ID
                     INTO  vCAD_MTMD_PRESCRICAO_ID,     vCAD_MTMD_ID_PRESCRICAO
                     FROM TB_MTMD_REQUISICAO_ITEM ITEM JOIN
                          TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = ITEM.CAD_MTMD_ID
                     WHERE ITEM.mtmd_req_id   = vMTMD_REQ_ID
                     AND   M.CAD_MTMD_PRIATI_ID   = vCAD_MTMD_PRIATI_ID
                     AND   ITEM.MTMD_ID_ORIGINAL IS NULL AND ROWNUM = 1;
                     IF (NVL(vCAD_MTMD_PRIATI_ID,0) != 0) THEN
                      SELECT PI.CAD_MTMD_ID 
                        INTO vCAD_MTMD_ID_PRESCRICAO
                        FROM TB_CAD_MTMD_PRESCRICAO_ITEM PI JOIN
                             TB_CAD_MTMD_MAT_MED MED ON MED.CAD_MTMD_ID = PI.CAD_MTMD_ID
                       WHERE NVL(PI.CAD_MTMD_PRC_ITEM_STATUS,1) = 1
                         AND PI.CAD_MTMD_PRESCRICAO_ID = vCAD_MTMD_PRESCRICAO_ID
                         AND MED.CAD_MTMD_PRIATI_ID = vCAD_MTMD_PRIATI_ID;
                     END IF;
                 EXCEPTION WHEN NO_DATA_FOUND THEN
                     vCAD_MTMD_ID_PRESCRICAO := NULL;
                 END;
             END IF;
          END;          
          IF (vCAD_MTMD_PRESCRICAO_ID IS NOT NULL) THEN
             --Atualizar qtd. fornecida prescricao quando for UTI GERAL/CARDIO
             UPDATE TB_CAD_MTMD_PRESCRICAO_ITEM PI
                SET PI.CAD_MTMD_PRC_QTDE_DISP = NVL(PI.CAD_MTMD_PRC_QTDE_DISP,0) - nQtdeConsumida
              WHERE NVL(PI.CAD_MTMD_PRC_ITEM_STATUS,1) = 1 AND
                    PI.CAD_MTMD_PRESCRICAO_ID = vCAD_MTMD_PRESCRICAO_ID AND
                    PI.CAD_MTMD_ID = vCAD_MTMD_ID_PRESCRICAO;
          END IF;
          SELECT REQ.CAD_SET_SETOR_FARMACIA
            INTO vSETOR_FARMACIA
            FROM TB_MTMD_REQ_REQUISICAO REQ
           WHERE REQ.MTMD_REQ_ID = vMTMD_REQ_ID;
          IF (vSETOR_FARMACIA = 61 OR
              (pCAD_SET_ID IN (200,201,2652) AND pCAD_SET_ID != vSETOR_ESTOQUE_CONSUMO AND nFracionado = NAO)) THEN
            --Quando for UTI GERAL/CARDIO, atualizar qtd. dispensada do Pedido
            IF (NVL(vCAD_MTMD_PRIATI_ID,0) != 0) THEN
               UPDATE TB_MTMD_REQUISICAO_ITEM
                 SET MTMD_REQITEM_QTD_FORNECIDA = NVL(MTMD_REQITEM_QTD_FORNECIDA,0) - nQtdeConsumida
               WHERE CAD_MTMD_ID = pCAD_MTMD_ID
                 AND MTMD_REQ_ID = vMTMD_REQ_ID;
            ELSE
               UPDATE TB_MTMD_REQUISICAO_ITEM
                  SET MTMD_REQITEM_QTD_FORNECIDA = MTMD_REQITEM_QTD_FORNECIDA - nQtdeConsumida
                WHERE CAD_MTMD_ID = pCAD_MTMD_ID
                AND   MTMD_REQ_ID = vMTMD_REQ_ID;
            END IF;
          END IF;
      END IF;
   END IF;
END PRC_MTMD_MOV_ESTOQUE_EST_CONS;