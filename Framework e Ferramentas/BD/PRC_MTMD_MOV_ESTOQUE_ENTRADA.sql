CREATE OR REPLACE PROCEDURE PRC_MTMD_MOV_ESTOQUE_ENTRADA
(    pCAD_MTMD_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type,
     pMTMD_LOTEST_ID               IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_LOTEST_ID%type,
     pCAD_MTMD_FILIAL_ID           IN TB_CAD_MTMD_FILIAL.CAD_MTMD_FILIAL_ID%type,
     pCAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_SET_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type,
     pMTMD_ESTLOC_QTDE             IN TB_MTMD_ESTOQUE_LOCAL.MTMD_ESTLOC_QTDE%type,
     VlrUnitario                   IN NUMBER,
     pCAD_MTMD_TPMOV_ID            IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_TPMOV_ID%type,
     pCAD_MTMD_SUBTP_ID            IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_SUBTP_ID%type,
     pMTMD_NR_NOTA                 IN TB_MTMD_HISTORICO_NOTA_FISCAL.MTMD_NR_NOTA%TYPE,
     dDtMov                        IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_DATA%type, -- data movimento RM
     pIdMov                        IN NUMBER,  -- id do movimento na RM
     CdColigada                    IN NUMBER,  -- coligada RM
     IdSeqMovRM                    IN NUMBER,   -- SEQUENCIA DO ITEM NA RM
     sTipoMov                      IN VARCHAR2, -- TIPO DE MOVIMENTO
     sNomeFormecedor               IN VARCHAR2,
     sCODUND                       IN VARCHAR2, -- UNIDADE DE COMPRA DA NOTA FISCAL
     sSerie                        IN VARCHAR2,
     pQTD_TOTAL_NOTA               IN NUMBER,
     pNUM_AUTORIZA_FORNECEDOR      IN TB_MTMD_HISTORICO_NOTA_FISCAL.NUM_AUTORIZA_FORNECEDOR%TYPE DEFAULT NULL
)
IS
pNewIdt      NUMBER; -- RETORNO DO ID DA MOVIMENTACAO
pNewIdtBaixa NUMBER; -- RETORNO DO ID DA MOVIMENTACAO
nPercConsumo NUMBER;
vMTMD_ID_ORIGINAL NUMBER := NULL;
  /********************************************************************
  *    Procedure: PRC_MTMD_MOV_ESTOQUE_ENTRADA
  *
  *    Data Criacao:   11/2009   Por: RICARDO COSTA
  *    Data Alteracao:  08/03/2010    Por: RICARDO COSTA
  *         Alterac?o: TRUNC NA VERIFICAC?O DA QTD, EXISTE QTDE COM CASAS DECIMAIS NA RM
  *    Data Alteracao:  31/03/2010    Por: RICARDO COSTA
  *         Alterac?o: Mudei a ordem em que grava o movimento, passei para o final da procedure
  *                    pois na gravac?o da movimentac?o ia buscar o preco medio e n?o encontrava
  *                    quando era um produto sem nota fiscal anterior
  *    Data Alteracao:  21/05/2010    Por: RICARDO COSTA
  *         Alterac?o: Totalizac?o do estoque contabil
  *    Data Alteracao:  16/05/2012    Por: Andre Souza Monaco
  *         Alterac?o: Inclus?o de regra que evita duplicac?o de NF e entrada
  *                    de acordo com o log de estornos
  *    Data Alteracao:  19/06/2012    Por: Andre Souza Monaco
  *         Alterac?o: Quando mov 1.2.48 realizar baixa automatica
  *    Data Alteracao:  07/04/2014    Por: Andre Souza Monaco
  *         Alterac?o: Inclus?o do campo NUM_AUTORIZA_FORNECEDOR
  *    Data Alteracao:  06/11/2015    Por: Andre Souza Monaco
  *         Alterac?o: Verificar se j? tem NF por fornecedor tamb?m
  *    Data Alteracao:  14/03/2016    Por: Andre Souza Monaco
  *         Alterac?o: Atualizar medicamento original
  *    Data Alteracao:  29/12/2016    Por: Andre Souza Monaco
  *         Alterac?o: Dar baixa autom. para alimentos nao estocaveis
  *    Data Alteracao:  14/01/2021    Por: Andre Souza Monaco
  *         Alterac?o: Quando mov 1.2.70 (do laboratorio), realizar baixa automatica
  *
  *    Funcao:  SOMENTE PARA ENTRADA DE NOTAS FISCAIS, VINDA DO SISTEMA RM
  *             ADICIONA PRODUTO NO ESTOQUE DA UNDIADE PASSADA E ESTOQUE CONTABIL
  *
  *******************************************************************/
/*
*  SOMENTE PARA ENTRADA DE NOTAS FISCAIS, VINDA DO SISTEMA RM
* ADICIONA PRODUTO NO ESTOQUE DA UNDIADE PASSADA E ESTOQUE CONTABIL
*
* CHAMADA: TRIGGER RM ( TITMMOV )
*/
vPRECO_UNITARIO_ANT        TB_MTMD_HISTORICO_NOTA_FISCAL.MTMD_PRECO_UNITARIO%TYPE := FNC_MTMD_PRECO_UNITARIO(pCAD_MTMD_ID,1);
vMTMD_CUSTO_MEDIO          TB_MTMD_ESTOQUE_CONTABIL.MTMD_CUSTO_MEDIO%TYPE;
vMTMD_ESTCON_QTDE          TB_MTMD_ESTOQUE_CONTABIL.mtmd_estcon_qtde%TYPE;
vMTMD_ESTCON_QTDE_ANTERIOR TB_MTMD_HISTORICO_NOTA_FISCAL.MTMD_ESTCON_QTDE_ANTERIOR%TYPE;
nFilial                    NUMBER;
vCAD_UNI_ID_UNIDADE           TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type;
vCAD_LAT_ID_LOCAL_ATENDIMENTO TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type;
vCAD_SET_ID                   TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type;
--vMTMD_LOTEST_ID            TB_MTMD_LOTEST_LOTE_ESTOQUE.MTMD_LOTEST_ID%TYPE;
vQtde                      TB_MTMD_ESTOQUE_LOCAL.MTMD_ESTLOC_QTDE%type;
vQtdeEstoqueAlmox          TB_MTMD_ESTOQUE_LOCAL.MTMD_ESTLOC_QTDE%type;
--vPrecoUnitario             TB_MTMD_HISTORICO_NOTA_FISCAL.MTMD_PRECO_UNITARIO%type;
-- VlrUnitarioAnterior        TB_MTMD_HISTORICO_NOTA_FISCAL.MTMD_PRECO_UNITARIO%TYPE;
--vEstoque                   TB_MTMD_ESTOQUE_CONTABIL.MTMD_ESTCON_QTDE%TYPE;
--dCustoMedio                DATE; -- DATA DO CUST0 MEDIO QUE ESTA SENDO EXCLUIDO
--vUNIDADE_COMPRA            VARCHAR2(20);
--vQTD_TOTAL_NOTA            NUMBER;
--vNOTA_ALTERADA             NUMBER;
--dtUltimoConsumo            DATE;
bValida_Inclusao           BOOLEAN := false;
bAtualizarAcertoEstorno    BOOLEAN := false;
bBaixaAuto                 BOOLEAN := false;
bAtualizarEstoque          BOOLEAN := false;
vMovBaixaAuto              VARCHAR2(50) := '1.2.48'; --CONSIGNADOS
vMovBaixaAuto2             VARCHAR2(50) := '1.2.70'; --LABORATORIO
vMovDevolucao              VARCHAR2(50) := '2.2.03';
vMovConsignadoLab          VARCHAR2(50);
vTipoMovDevolucao          VARCHAR2(50);
vQTDE_ENTRADA              TB_MTMD_ESTOQUE_CONTABIL.mtmd_estcon_qtde%TYPE;
vCAD_MTMD_ID_ACERTO        TB_MTMD_HISTORICO_NOTA_FISCAL.CAD_MTMD_ID%TYPE;
vCAD_MTMD_TPMOV_ID         TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_TPMOV_ID%type := pCAD_MTMD_TPMOV_ID;
vCAD_MTMD_SUBTP_ID         TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_SUBTP_ID%type := pCAD_MTMD_SUBTP_ID;
vCAD_MTMD_GRUPO_ID         TB_CAD_MTMD_MAT_MED.CAD_MTMD_GRUPO_ID%TYPE;
vCAD_MTMD_SUBGRUPO_ID      TB_CAD_MTMD_MAT_MED.CAD_MTMD_SUBGRUPO_ID%TYPE;
--vMTMD_NR_NOTA              TB_MTMD_HISTORICO_NOTA_FISCAL.MTMD_NR_NOTA%TYPE;
PROCEDURE PRC_MTMD_ESTOQUE_MOVIMENTACAO( pTipoMov IN VARCHAR2,
                                         pCAD_UNI_ID_UNIDADE           IN OUT TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
                                         pCAD_LAT_ID_LOCAL_ATENDIMENTO IN OUT TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
                                         pCAD_SET_ID                   IN OUT TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type
                                         ) IS
BEGIN
-- ================================================================================================
-- RETORNA A UNIDADE ONDE O TIPO DE MOVIMENTAC?O IRA ABASTACER
-- EX.: 1.2.51 - MATERIAL DE MANUTENC?O
--      ABASTECE O ESTOQUE DO ALMOXARIFADO - MANUTENC?O
-- ================================================================================================
 IF (pTipoMov IS NULL AND pCAD_SET_ID = 2592) THEN --ENTRADA DE EMPRESTIMO NA FARMACIA
    SELECT SETOR.CAD_SET_ID,
            SETOR.CAD_UNI_ID_UNIDADE,
            SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO
     INTO   pCAD_SET_ID,
            pCAD_UNI_ID_UNIDADE,
            pCAD_LAT_ID_LOCAL_ATENDIMENTO
     FROM TB_CAD_SET_SETOR SETOR
    WHERE SETOR.CAD_SET_ID = pCAD_SET_ID;
 ELSE
     BEGIN
      --BUSCA ALMOX POR TIPO DE MOVIMENTAC?O
      SELECT CCUSTO.CAD_SET_ID,
             CCUSTO.CAD_UNI_ID_UNIDADE,
             CCUSTO.CAD_LAT_ID_LOCAL_ATENDIMENTO
      INTO   pCAD_SET_ID,
             pCAD_UNI_ID_UNIDADE,
             pCAD_LAT_ID_LOCAL_ATENDIMENTO
      FROM TB_MTMD_MOV_CCUSTO CCUSTO
      WHERE CCUSTO.MTMD_TIPO_MOV_ENTRADA = pTipoMov;
      EXCEPTION WHEN NO_DATA_FOUND THEN
       --BUSCA ALMOX CENTRAL
       BEGIN
           SELECT SETOR.CAD_SET_ID,
                  SETOR.CAD_UNI_ID_UNIDADE,
                  SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO
           INTO   pCAD_SET_ID,
                  pCAD_UNI_ID_UNIDADE,
                  pCAD_LAT_ID_LOCAL_ATENDIMENTO
           FROM TB_CAD_SET_SETOR SETOR
           WHERE SETOR.CAD_SET_ALMOX_CENTRAL = 1;
       EXCEPTION
         WHEN TOO_MANY_ROWS THEN
              RAISE_APPLICATION_ERROR(-20000,'SETOR: EXISTE MAIS QUE UM ESTOQUE CENTRAL CADASTRADO');
         WHEN NO_DATA_FOUND THEN
             RAISE_APPLICATION_ERROR(-20000,'SETOR NO_DATA_FOUND');
         WHEN OTHERS THEN
             RAISE_APPLICATION_ERROR(-20000,'SETOR '||sqlerrm);
       END;
     END;
 END IF;
END PRC_MTMD_ESTOQUE_MOVIMENTACAO;
--#################### I N I C I O  P R O C E D U R E ###########################################################
BEGIN
--RAISE_APPLICATION_ERROR(-20000,'DEVOLUCAO');
BEGIN
   --Verifica se produto esta pendente de acerto devido a estorno
   SELECT DISTINCT E.CAD_MTMD_ID_ACERTO INTO vCAD_MTMD_ID_ACERTO
     FROM TB_MTMD_HISTORICO_NF_ESTORNO E
    WHERE E.STATUS = 0 AND
          E.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID AND
          TO_NUMBER(E.MTMD_NR_NOTA) = TO_NUMBER(pMTMD_NR_NOTA) AND
          E.CAD_MTMD_ID_ACERTO = pCAD_MTMD_ID;
   bAtualizarAcertoEstorno := true;
   bValida_Inclusao := true;
EXCEPTION
  WHEN NO_DATA_FOUND THEN
       BEGIN
         --Query para n?o duplicar produto e NF
         SELECT MTMD_QTDE INTO vQtde
           FROM TB_MTMD_HISTORICO_NOTA_FISCAL H
         WHERE H.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID AND
               TO_NUMBER(H.MTMD_NR_NOTA) = TO_NUMBER(pMTMD_NR_NOTA) AND
               H.CAD_MTMD_ID = pCAD_MTMD_ID AND
               TO_NUMBER(TO_CHAR(H.MTMD_DATA_PRC_MEDIO,'YYYYMM')) = TO_NUMBER(TO_CHAR(SYSDATE,'YYYYMM')) AND
               TRIM(H.DS_FORNECEDOR) = TRIM(sNomeFormecedor);
         IF (TRUNC(vQtde) != TRUNC(pMTMD_ESTLOC_QTDE)) THEN
           /*SELECT MTMD_LOTEST_ID INTO vMTMD_LOTEST_ID
             FROM TB_MTMD_HISTORICO_NOTA_FISCAL H
           WHERE H.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID AND
                 H.MTMD_NR_NOTA = pMTMD_NR_NOTA AND
                 H.CAD_MTMD_ID = pCAD_MTMD_ID AND
                 TO_NUMBER(TO_CHAR(H.MTMD_DATA_PRC_MEDIO,'YYYYMM')) = TO_NUMBER(TO_CHAR(SYSDATE,'YYYYMM'));*/
           --IF (pMTMD_LOTEST_ID = vMTMD_LOTEST_ID) THEN
            RAISE_APPLICATION_ERROR(-20000,'QTDE. N?O PODE SER ALTERADA');
           --END IF;
         END IF;
       EXCEPTION
          WHEN NO_DATA_FOUND THEN
               bValida_Inclusao := true;
       END;
END;
IF (bValida_Inclusao) THEN
  IF (INSTR(vMovBaixaAuto,sTipoMov) > 0 OR INSTR(vMovBaixaAuto2,sTipoMov) > 0) THEN
     bBaixaAuto := true;
     vQTDE_ENTRADA := pMTMD_ESTLOC_QTDE-pMTMD_ESTLOC_QTDE;
     nFilial := pCAD_MTMD_FILIAL_ID;
     IF (sTipoMov = vMovBaixaAuto2) THEN --Quando LAB busca estoque do LAB
       PRC_MTMD_ESTOQUE_MOVIMENTACAO(sTipoMov,
                                     vCAD_UNI_ID_UNIDADE,
                                     vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                     vCAD_SET_ID
                                    );  
     ELSE
       vCAD_UNI_ID_UNIDADE := pCAD_UNI_ID_UNIDADE;
       vCAD_LAT_ID_LOCAL_ATENDIMENTO := pCAD_LAT_ID_LOCAL_ATENDIMENTO;
       vCAD_SET_ID := pCAD_SET_ID;
     END IF;
  ELSE
     vQTDE_ENTRADA := pMTMD_ESTLOC_QTDE;
     -- VERIFICA SE TIPO DE MOVIMENTO E DIRECIONADO PARA OUTRO ESTOQUE
     IF (sTipoMov = vMovDevolucao) THEN --SE DEVOLUCAO, PEGA NO HISTORICO TIPO MOV. DE ENTRADA
       BEGIN
         SELECT TRIM(H.TP_MOVIMENTO)
            INTO vTipoMovDevolucao
            FROM TB_MTMD_HISTORICO_NOTA_FISCAL H INNER JOIN TB_CAD_MTMD_MAT_MED M
              ON M.CAD_MTMD_ID = H.CAD_MTMD_ID
           WHERE H.MTMD_DATA_PRC_MEDIO > ADD_MONTHS(SYSDATE, -6) AND
                 ROWNUM = 1 AND
                 H.TP_MOVIMENTO != sTipoMov AND
                 H.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID AND
                 H.CAD_MTMD_ID = pCAD_MTMD_ID;
       EXCEPTION
         WHEN NO_DATA_FOUND THEN
            vTipoMovDevolucao := sTipoMov;
       END;

       PRC_MTMD_ESTOQUE_MOVIMENTACAO(vTipoMovDevolucao,
                                     vCAD_UNI_ID_UNIDADE,
                                     vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                     vCAD_SET_ID
                                    );
     ELSE
       IF (sTipoMov IS NULL AND vCAD_SET_ID IS NULL) THEN
          vCAD_SET_ID := pCAD_SET_ID;
       END IF;
       PRC_MTMD_ESTOQUE_MOVIMENTACAO(sTipoMov,
                                     vCAD_UNI_ID_UNIDADE,
                                     vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                     vCAD_SET_ID
                                    );
     END IF;
     nFilial := FNC_MTMD_RETORNA_FILIAL( pCAD_MTMD_ID, pCAD_MTMD_FILIAL_ID, pCAD_SET_ID);
  END IF;
  IF ( nFilial IS NULL ) THEN
     RAISE_APPLICATION_ERROR(-20000,' FILIAL ESTA EM BRANCO  ');
  END IF;
  SELECT PROD.CAD_MTMD_GRUPO_ID, PROD.CAD_MTMD_SUBGRUPO_ID
    INTO vCAD_MTMD_GRUPO_ID,  vCAD_MTMD_SUBGRUPO_ID
    FROM TB_CAD_MTMD_MAT_MED PROD
   WHERE PROD.CAD_MTMD_ID = pCAD_MTMD_ID;
  IF (vCAD_MTMD_GRUPO_ID = 4 AND vCAD_MTMD_SUBGRUPO_ID = 942) THEN --DAR BAIXA AUTO. PARA ALIMENTOS NAO ESTOCAVEIS
     bBaixaAuto := true;
     vQTDE_ENTRADA := pMTMD_ESTLOC_QTDE-pMTMD_ESTLOC_QTDE;
  END IF;
  BEGIN
     -- PEGA ESTOQUE ANTERIOR A ENTRADA DA NOTA
     vMTMD_ESTCON_QTDE_ANTERIOR := FNC_MTMD_ESTOQUE_CONTABIL(pCAD_MTMD_ID, nFilial );
  EXCEPTION
    WHEN NO_DATA_FOUND THEN
       vMTMD_ESTCON_QTDE_ANTERIOR := NULL;
  END;
  BEGIN
     INSERT INTO TB_MTMD_HISTORICO_NOTA_FISCAL
     (CAD_MTMD_ID,               CAD_MTMD_FILIAL_ID,             MTMD_NR_NOTA,         MTMD_CUSTO_MEDIO,
      MTMD_DATA_PRC_MEDIO,       MTMD_QTDE,                      MTMD_PRECO_UNITARIO,  MTMD_LOTEST_ID,
      IDMOV,                     CODCOLIGADA,                    DTMOV,                IDSEQMOVRM,
      MTMD_ESTCON_QTDE_ANTERIOR, DS_FORNECEDOR,                  TP_MOVIMENTO,         UNIDADE_COMPRA,
      SERIE,                     QTD_TOTAL_NOTA,                 NUM_AUTORIZA_FORNECEDOR
     )
      VALUES
     (pCAD_MTMD_ID,               nFilial,                       pMTMD_NR_NOTA,        vMTMD_CUSTO_MEDIO,
      SYSDATE,                    TRUNC(pMTMD_ESTLOC_QTDE),      ROUND(VlrUnitario,2), pMTMD_LOTEST_ID,
      pIdMov,                     CdColigada,                    dDtMov,               IdSeqMovRM,
      vMTMD_ESTCON_QTDE_ANTERIOR, SUBSTR(sNomeFormecedor,1,100), sTipoMov,             sCODUND,
      sSerie,                     pQTD_TOTAL_NOTA,               pNUM_AUTORIZA_FORNECEDOR);
  EXCEPTION
     WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-20000,'HISTORICO NOTA FISCAL LOTE: '||TO_CHAR(pMTMD_LOTEST_ID)||' FILIAL  '||TO_CHAR(nFilial)||' '||sqlerrm);
        NULL;
  END;
  IF (sTipoMov = vMovDevolucao) THEN
    BEGIN
      SELECT TRIM(H.TP_MOVIMENTO)
        INTO vMovConsignadoLab
       FROM TB_MTMD_HISTORICO_NOTA_FISCAL H INNER JOIN TB_CAD_MTMD_MAT_MED M
       ON M.CAD_MTMD_ID = H.CAD_MTMD_ID
       WHERE H.MTMD_DATA_PRC_MEDIO > ADD_MONTHS(SYSDATE, -6) AND
             ROWNUM = 1 AND
             H.TP_MOVIMENTO IN (vMovBaixaAuto,vMovBaixaAuto2) AND
             H.CAD_MTMD_FILIAL_ID = nFilial AND
             H.CAD_MTMD_ID = pCAD_MTMD_ID;
    EXCEPTION
      WHEN NO_DATA_FOUND THEN
         vMovConsignadoLab := 0;
    END;
    IF (vMovConsignadoLab IN (vMovBaixaAuto,vMovBaixaAuto2)) THEN --NAO REALIZAR MOVIMENTO DE DEVOLUCAO DE CONSIGNADO OU LAB, POIS ESTOQUE ESTA SEMPRE ZERADO
       RETURN;
    END IF;
    --QUANDO DEVOLUCAO, VALIDAR QTD ESTOQUE CENTRO DISP.
    SELECT NVL(SUM(L.MTMD_ESTLOC_QTDE),0)
      INTO vQtdeEstoqueAlmox
      FROM TB_MTMD_ESTOQUE_LOCAL L
     WHERE L.CAD_MTMD_ID = pCAD_MTMD_ID AND
           L.CAD_SET_ID = vCAD_SET_ID AND
           L.CAD_MTMD_FILIAL_ID = nFilial;
    IF (vQtdeEstoqueAlmox < TRUNC(vQTDE_ENTRADA)) THEN
       RAISE_APPLICATION_ERROR(-20000,'SALDO INDISPONIVEL NO ALMOXARIFADO PARA DEVOLUCAO.');
    ELSE
       vQTDE_ENTRADA := -vQTDE_ENTRADA; --SE DEVOLUCAO OK, SERA DADO BAIXA NO ALMOX.
    END IF;
    vCAD_MTMD_TPMOV_ID := 2;
    vCAD_MTMD_SUBTP_ID := 15; --ESTORNO NF
    BEGIN
      vMTMD_CUSTO_MEDIO := FNC_MTMD_CALCULA_CUSTO_MEDIO ( pCAD_MTMD_ID,
                                                        nFilial,
                                                        TRUNC(vQTDE_ENTRADA),
                                                        ROUND(VlrUnitario,2),
                                                        NULL, -- QTDE HISTORICO
                                                        NULL  -- CUSTO MEDIO HISTORICO
                                                       );
    EXCEPTION
      WHEN OTHERS THEN
        vMTMD_CUSTO_MEDIO := VlrUnitario;
    END;
    BEGIN
      INSERT INTO TB_MTMD_MOV_MES
      (
         CAD_MTMD_FILIAL_ID,
         CAD_MTMD_ID,
         MTMD_MOV_MES,
         MTMD_MOV_ANO,
         MTMD_QTDE_ENTRADA,
         MTMD_QTDE_SAIDA,
         MTMD_MOV_SALDO,
         MTMD_DATA_ATUALIZACAO
      )
      VALUES
      (
        nFilial,
        pCAD_MTMD_ID,
        TO_NUMBER(TO_CHAR(SYSDATE,'MM')),
        TO_NUMBER(TO_CHAR(SYSDATE,'YYYY')),
        0,
        0,
        FNC_MTMD_ESTOQUE_CONTABIL(pCAD_MTMD_ID, pCAD_MTMD_FILIAL_ID),
        SYSDATE
      );
    EXCEPTION
      WHEN DUP_VAL_ON_INDEX THEN
        NULL;--SO PARA GARANTIR QUE EXISTE PARA OS PROXIMOS UPDATES
    END;
  ELSE
    BEGIN
      vMTMD_CUSTO_MEDIO := FNC_MTMD_CALCULA_CUSTO_MEDIO ( pCAD_MTMD_ID,
                                                        nFilial,
                                                        TRUNC(pMTMD_ESTLOC_QTDE),
                                                        ROUND(VlrUnitario,2),
                                                        NULL, -- QTDE HISTORICO
                                                        NULL  -- CUSTO MEDIO HISTORICO
                                                       );
    EXCEPTION
      WHEN OTHERS THEN
        vMTMD_CUSTO_MEDIO := VlrUnitario;
    END;
  END IF;
  BEGIN
      SELECT MATMED.CAD_MTMD_ID
        INTO vMTMD_ID_ORIGINAL
        FROM TB_MTMD_PEDIDO_PADRAO PADRAO,
             TB_MTMD_PEDIDO_PADRAO_ITENS ITENS,
             TB_CAD_MTMD_MAT_MED MATMED
        WHERE ITENS.MTMD_PEDPAD_ID                   = PADRAO.MTMD_PEDPAD_ID
        AND   ITENS.CAD_MTMD_ID                      = MATMED.CAD_MTMD_ID
        AND   PADRAO.CAD_SET_ID                      = vCAD_SET_ID
        AND   PADRAO.CAD_MTMD_FILIAL_ID              = nFilial
        AND   ITENS.CAD_MTMD_ID                      != pCAD_MTMD_ID
        AND   MATMED.CAD_MTMD_PRIATI_ID              != 0
        AND   MATMED.CAD_MTMD_PRIATI_ID              = FNC_MTMD_PRINCIPIO_ATIVO(pCAD_MTMD_ID) AND ROWNUM = 1;
  EXCEPTION WHEN NO_DATA_FOUND THEN
      NULL;
  END;
  BEGIN
     IF (vQTDE_ENTRADA >= 0) THEN
       INSERT INTO TB_MTMD_ESTOQUE_LOCAL
       ( CAD_MTMD_ID,                    MTMD_LOTEST_ID,                CAD_MTMD_FILIAL_ID,
         CAD_SET_ID,                     CAD_LAT_ID_LOCAL_ATENDIMENTO,  CAD_UNI_ID_UNIDADE,
         MTMD_ESTLOC_DATA,               MTMD_ESTLOC_QTDE,              MTMD_ESTLOC_FL_PADRAO,
         MTMD_ESTLOC_QTDE_FRACIONADA,    MTMD_MOV_DT_FORNECIMENTO,      MTMD_MOV_ESTOQUE_ATUAL, MTMD_ID_ORIGINAL,
         MTMD_PEDPAD_QTDE
       )
       VALUES
       ( pCAD_MTMD_ID,                   pMTMD_LOTEST_ID,               nFilial,
         vCAD_SET_ID,                    vCAD_LAT_ID_LOCAL_ATENDIMENTO, vCAD_UNI_ID_UNIDADE,
         SYSDATE,                        TRUNC(vQTDE_ENTRADA),          0,
         0,                              SYSDATE,                       TRUNC(vQTDE_ENTRADA),   vMTMD_ID_ORIGINAL,
         FNC_MTMD_PRODUTO_PADRAO(pCAD_MTMD_ID,
                                 nFilial,
                                 vCAD_SET_ID,
                                 vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                 vCAD_UNI_ID_UNIDADE)
       );
     ELSE
       bAtualizarEstoque := true; --Atualizar Estoque NF Devolucao (dar baixa)
     END IF;
  EXCEPTION
        WHEN DUP_VAL_ON_INDEX THEN
          bAtualizarEstoque := true;
  END;
  IF (bAtualizarEstoque) THEN
    UPDATE TB_MTMD_ESTOQUE_LOCAL
       SET
           MTMD_ESTLOC_QTDE = NVL(MTMD_ESTLOC_QTDE,0) + TRUNC(vQTDE_ENTRADA),
           MTMD_MOV_ESTOQUE_ATUAL   = TRUNC(vQTDE_ENTRADA), -- fornecido - NO ALMOXARIFADO N?O SOMA, E A QUANTIDADE DO ULTIMO FORNECIMENTO
           MTMD_ID_ORIGINAL         = vMTMD_ID_ORIGINAL,
           MTMD_MOV_CONSUMO         = NULL, -- ZERA CONSUMO
           MTMD_MOV_CONSUMO_OUTROS  = NULL, -- ZERA OUTROS CONSUMOS
           MTMD_MOV_CONSUMO_PERC    = NULL, -- ZERA PERCENTUAL DE CONSUMO
           -- MTMD_PEDPAD_QTDE         = vMTMD_PEDPAD_QTDE,
           MTMD_MOV_DT_FORNECIMENTO = SYSDATE, -- ATUALIZA DATA DE FORNECIMENTO
           MTMD_ESTLOC_DATA         = SYSDATE
           WHERE CAD_MTMD_ID                  = pCAD_MTMD_ID
           AND   CAD_UNI_ID_UNIDADE           = vCAD_UNI_ID_UNIDADE
           AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = vCAD_LAT_ID_LOCAL_ATENDIMENTO
           AND   CAD_SET_ID                   = vCAD_SET_ID
           AND   CAD_MTMD_FILIAL_ID           = nFilial;
  END IF;
  BEGIN
     INSERT INTO TB_MTMD_ESTOQUE_CONTABIL
     ( CAD_MTMD_ID,    CAD_MTMD_FILIAL_ID,      MTMD_ESTCON_DT_ATUALIZACAO,     MTMD_ESTCON_QTDE,        MTMD_CUSTO_MEDIO)
     VALUES
     ( pCAD_MTMD_ID,   nFilial,                 SYSDATE,                        TRUNC(vQTDE_ENTRADA),    vMTMD_CUSTO_MEDIO);
  EXCEPTION WHEN DUP_VAL_ON_INDEX THEN
     -- SE JA EXISTE ATUALIZA
     -- totaliza estoque local
     vMTMD_ESTCON_QTDE := FNC_MTMD_ESTOQUE_CONTABIL(pCAD_MTMD_ID, nFilial );
     UPDATE TB_MTMD_ESTOQUE_CONTABIL SET
     MTMD_ESTCON_QTDE           = vMTMD_ESTCON_QTDE, -- MTMD_ESTCON_QTDE + pMTMD_ESTLOC_QTDE,
     MTMD_ESTCON_DT_ATUALIZACAO = SYSDATE,
     MTMD_CUSTO_MEDIO           = vMTMD_CUSTO_MEDIO
     WHERE CAD_MTMD_ID        = pCAD_MTMD_ID
     AND   CAD_MTMD_FILIAL_ID = nFilial;
  END;
  -- REGISTRO DA MOVIMENTAC?O OCORRE DEPOIS DA ENTRADA NO ESTOQUE LOCAL, POIS PODE SER QUE O PRODUTO N?O EXISTE EM ESTOQUE
  -- DARIA ERRO DE CHAVE
  PRC_MTMD_MOV_MOVIMENTACAO_I (   vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                  vCAD_UNI_ID_UNIDADE,
                                  vCAD_SET_ID,
                                  NULL,  -- REQUISICAO
                                  pMTMD_LOTEST_ID,
                                  pCAD_MTMD_ID,
                                  nFilial,
                                  vCAD_MTMD_TPMOV_ID,
                                  vCAD_MTMD_SUBTP_ID,
                                  SYSDATE,
                                  TRUNC(pMTMD_ESTLOC_QTDE),
                                  1,
                                  NULL, -- ID ATENDIMENTO
                                  NULL, -- TIPO ATENDIMENTO
                                  1, -- Usuario
                                  NULL, -- ID_CONVERSAO
                                  NULL, -- QTDE_CONVERTIDA
                                  NULL, -- DT_FAT
                                  NULL, -- HR_FAT
                                  pNewIdt
                               );
  UPDATE TB_MTMD_MOV_MES
    SET
        MTMD_MOV_SALDO        = FNC_MTMD_ESTOQUE_CONTABIL(pCAD_MTMD_ID, nFilial),
        MTMD_DATA_ATUALIZACAO = SYSDATE
    WHERE
        CAD_MTMD_FILIAL_ID = nFilial
    AND CAD_MTMD_ID        = pCAD_MTMD_ID
    AND MTMD_MOV_ANO       = TO_NUMBER(TO_CHAR(SYSDATE,'YYYY'))
    AND MTMD_MOV_MES       = TO_NUMBER(TO_CHAR(SYSDATE,'MM'));
  IF (bBaixaAuto) THEN
    SELECT SEQ_MTMD_MOVIMENTACAO.NEXTVAL INTO pNewIdtBaixa FROM DUAL;
    INSERT INTO TB_MTMD_MOV_MOVIMENTACAO
    (
       MTMD_MOV_ID,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_UNI_ID_UNIDADE,
       CAD_SET_ID,
       CAD_MTMD_ID,
       CAD_MTMD_TPMOV_ID,
       CAD_MTMD_SUBTP_ID,
       MTMD_MOV_DATA,
       MTMD_MOV_QTDE,
       MTMD_MOV_FL_FINALIZADO,
       CAD_MTMD_FILIAL_ID,
       SEG_USU_ID_USUARIO,
       MTMD_MOV_FL_ESTORNO,
       MTMD_MOV_ID_REF,
       MTMD_MOV_ESTOQUE_ATUAL,
       MTMD_CUSTO_MEDIO
    )
    VALUES
    (
      pNewIdtBaixa,
      vCAD_LAT_ID_LOCAL_ATENDIMENTO,
      vCAD_UNI_ID_UNIDADE,
      vCAD_SET_ID,
      pCAD_MTMD_ID,
      2,
      12, --BAIXA AUTOMATICA
      SYSDATE,
      TRUNC(pMTMD_ESTLOC_QTDE),
      1,
      nFilial,
      1,
      0,
      pNewIdt,
      FNC_MTMD_ESTOQUE_UNIDADE(pCAD_MTMD_ID,
                               vCAD_UNI_ID_UNIDADE,
                               vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                               vCAD_SET_ID,
                               nFilial,
                               NULL),
      vMTMD_CUSTO_MEDIO
    );
  END IF;
  IF (bBaixaAuto OR sTipoMov = vMovDevolucao) THEN
    UPDATE TB_MTMD_MOV_MES
      SET
          MTMD_QTDE_SAIDA       = MTMD_QTDE_SAIDA+pMTMD_ESTLOC_QTDE,
          MTMD_DATA_ATUALIZACAO = SYSDATE
      WHERE
          CAD_MTMD_FILIAL_ID = nFilial
      AND CAD_MTMD_ID        = pCAD_MTMD_ID
      AND MTMD_MOV_ANO       = TO_NUMBER(TO_CHAR(SYSDATE,'YYYY'))
      AND MTMD_MOV_MES       = TO_NUMBER(TO_CHAR(SYSDATE,'MM'));
  END IF;
  BEGIN
    -- ATUALIZA SEQUENCIA DE MOVIMENTAC?O E CUSTO MEDIO NA NOTA
    UPDATE TB_MTMD_HISTORICO_NOTA_FISCAL SET
    MTMD_MOV_ID = pNewIdt,
    MTMD_CUSTO_MEDIO = vMTMD_CUSTO_MEDIO
    WHERE CAD_MTMD_ID        = pCAD_MTMD_ID
    AND   CAD_MTMD_FILIAL_ID = nFilial
    AND   MTMD_NR_NOTA       = pMTMD_NR_NOTA
    AND   IDMOV              = pIdMov
    AND   CODCOLIGADA        = CdColigada
    AND   IDSEQMOVRM         = IdSeqMovRM;
  END;
  --- ATUALIZA O VALOR DO CUSTO MEDIO NA MOVIMETNCAO PARA SER O VALOR DO PRECO UNITARIO QUANDO ENTRADA DE NOTA
  /*UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
  MTMD_CUSTO_MEDIO = ROUND(VlrUnitario,2)
  WHERE MTMD_MOV_ID = pNewIdt;*/
  IF (bAtualizarAcertoEstorno) THEN
     UPDATE TB_MTMD_HISTORICO_NF_ESTORNO
        SET MTMD_MOV_DATA_ACERTO = SYSDATE,
            STATUS = 1
      WHERE
              CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
          AND CAD_MTMD_ID_ACERTO = pCAD_MTMD_ID
          AND TO_NUMBER(MTMD_NR_NOTA) = TO_NUMBER(pMTMD_NR_NOTA)
          AND STATUS = 0;
  END IF;
  -- ATUALIZA PERCENTUAL DE CONSUMO
  PRC_MTMD_ESTOQUE_PER_CONSUMO_U(  pCAD_MTMD_ID, nFilial,  vCAD_UNI_ID_UNIDADE, vCAD_LAT_ID_LOCAL_ATENDIMENTO, vCAD_SET_ID, nPercConsumo);
  -- ENVIAR E-MAIL DE ALERTA QUANDO CUSTO MEDIO SOFRER GRANDE VARIACAO PRA NF HAC
  IF (pCAD_MTMD_FILIAL_ID = 1) THEN
     PRC_MTMD_EMAIL_AVISO_VAR_CM(pCAD_MTMD_ID, pMTMD_NR_NOTA, vPRECO_UNITARIO_ANT, VlrUnitario);
  END IF;
END IF;
END PRC_MTMD_MOV_ESTOQUE_ENTRADA;