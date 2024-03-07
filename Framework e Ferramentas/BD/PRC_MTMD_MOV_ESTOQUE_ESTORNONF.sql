CREATE OR REPLACE PROCEDURE "PRC_MTMD_MOV_ESTOQUE_ESTORNONF"
(    pCAD_MTMD_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type,
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
     IdMov                         IN NUMBER, -- id do movimento na RM
     CdColigada                    IN NUMBER,  -- coligada RM
     pIDSEQMOVRM                   IN TB_MTMD_HISTORICO_NOTA_FISCAL.IDSEQMOVRM%TYPE,
     sTipoMov                      IN VARCHAR2, -- TIPO DE MOVIMENTO
     sSerie                        IN VARCHAR2
) IS
pNewIdt NUMBER; -- RETORNO DO ID DA MOVIMENTACAO
  /********************************************************************
  *    Procedure: PRC_MTMD_MOV_ESTOQUE_ESTORNONF
  *
  *    Data Criacao: 	11/2009   Por: RICARDO COSTA
  *    Data Alteracao:	08/03/2010    Por: RICARDO COSTA
  *         Alteração: TRUNC NA VERIFICAÇÃO DA QTD, EXISTE QTDE COM CASAS DECIMAIS NA RM
  *    Data Alteracao:	07/05/2010    Por: RICARDO COSTA
  *         Alteração: MELHORIA NA MSG DE ALGUNS ERROS
  *
  *    Funcao: ESTORNA NOTA FISCAL
  *
  *******************************************************************/
/*
* ESTORNA PRODUTO DO ESTOQUE DA UNIDADE PASSADA E ESTOQUE CONTABIL
*
* CHAMADA: TRIGGER RM ( TITMMOV )
*/
vMTMD_CUSTO_MEDIO          TB_MTMD_ESTOQUE_CONTABIL.MTMD_CUSTO_MEDIO%TYPE;
vMTMD_CUSTO_MEDIO_ANTERIOR TB_MTMD_ESTOQUE_CONTABIL.MTMD_CUSTO_MEDIO%TYPE;
vMTMD_ESTCON_QTDE_ANTERIOR TB_MTMD_HISTORICO_NOTA_FISCAL.MTMD_ESTCON_QTDE_ANTERIOR%TYPE;
vCAD_UNI_ID_UNIDADE           TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type;
vCAD_LAT_ID_LOCAL_ATENDIMENTO TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type;
vCAD_SET_ID                   TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type;
vMTMD_ESTCON_QTDE         NUMBER;
x                          NUMBER;
vMTMD_LOTEST_ID            TB_MTMD_LOTEST_LOTE_ESTOQUE.MTMD_LOTEST_ID%TYPE;
vQtde                      TB_MTMD_ESTOQUE_LOCAL.MTMD_ESTLOC_QTDE%type;
vPrecoUnitario             TB_MTMD_HISTORICO_NOTA_FISCAL.MTMD_PRECO_UNITARIO%type;
-- VlrUnitarioAnterior        TB_MTMD_HISTORICO_NOTA_FISCAL.MTMD_PRECO_UNITARIO%TYPE;
vEstoque                   TB_MTMD_ESTOQUE_CONTABIL.MTMD_ESTCON_QTDE%TYPE;
dCustoMedio                DATE; -- DATA DO CUST0 MEDIO QUE ESTA SENDO EXCLUIDO
dCustoMedioAnterior        DATE; -- DATA DO CUST0 MEDIO QUE ESTA SENDO EXCLUIDO
nFilial                    NUMBER;
vIdSeqOld                  TB_MTMD_HISTORICO_NOTA_FISCAL.IDSEQMOVRM%type;
vMTMD_MOV_ID               NUMBER;
dtUltimoConsumo            DATE;
vCAD_MTMD_NOMEFANTASIA     TB_CAD_MTMD_MAT_MED.cad_mtmd_nomefantasia%TYPE;
PROCEDURE PRC_MTMD_ESTOQUE_MOVIMENTACAO( pTipoMov IN VARCHAR2,
                                         pCAD_UNI_ID_UNIDADE           IN OUT TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
                                         pCAD_LAT_ID_LOCAL_ATENDIMENTO IN OUT TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
                                         pCAD_SET_ID                   IN OUT TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type
                                         ) IS
BEGIN
-- ================================================================================================
-- RETORNA A UNIDADE ONDE O TIPO DE MOVIMENTAÇÃO IRÁ ABASTACER
-- EX.: 1.2.51 - MATERIAL DE MANUTENÇÃO
--      ABASTECE O ESTOQUE DO ALMOXARIFADO - MANUTENÇÃO
-- ================================================================================================
   vMTMD_ESTCON_QTDE := TRUNC(pMTMD_ESTLOC_QTDE); -- QTDE SENDO ESTORNADA
   BEGIN
   -- BUSCA ALMOX POR TIPO DE MOVIMENTAÇÃO
    SELECT CCUSTO.CAD_SET_ID,
           CCUSTO.CAD_UNI_ID_UNIDADE,
           CCUSTO.CAD_LAT_ID_LOCAL_ATENDIMENTO
    INTO   pCAD_SET_ID,
           pCAD_UNI_ID_UNIDADE,
           pCAD_LAT_ID_LOCAL_ATENDIMENTO
    FROM TB_MTMD_MOV_CCUSTO CCUSTO
    WHERE CCUSTO.MTMD_TIPO_MOV_ENTRADA = sTipoMov;
    EXCEPTION WHEN NO_DATA_FOUND THEN
         --BUSCA ALMOX CENTRAL
         BEGIN
             SELECT SETOR.CAD_SET_ID,
                    SETOR.CAD_UNI_ID_UNIDADE,
                    SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO
             INTO   pCAD_SET_ID,
                    pCAD_UNI_ID_UNIDADE,
                    pCAD_LAT_ID_LOCAL_ATENDIMENTO
             FROM SGS.TB_CAD_SET_SETOR SETOR
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
END PRC_MTMD_ESTOQUE_MOVIMENTACAO;
BEGIN
      PRC_MTMD_ESTOQUE_MOVIMENTACAO( sTipoMov,
                                     vCAD_UNI_ID_UNIDADE,
                                     vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                     vCAD_SET_ID
                                    );
   nFilial := FNC_MTMD_RETORNA_FILIAL( pCAD_MTMD_ID, pCAD_MTMD_FILIAL_ID, pCAD_SET_ID);
   -- VERIFICA SE TEM ESTOQUE PARA ESTORNO

   vEstoque := FNC_MTMD_ESTOQUE_CONTABIL(pCAD_MTMD_ID, nFilial );
     -- SE EXISTIR O ITEM NÃO ENTRA NO EXCEPTION, SE EXISTIR E ESTIVER ZERADO NAO PODE ESTORNAR
     IF ( vEstoque < vMTMD_ESTCON_QTDE ) THEN
        -- RAISE_APPLICATION_ERROR(-20000,' CONTAGEM ESTOQUE, NAO EXISTE ESTOQUE, PRODUTO '||TO_CHAR(pCAD_MTMD_ID)||' '||sqlerrm);
        -- BUSCA DESCRICAO DO PRODUTO
        BEGIN
        SELECT MTMD.CAD_MTMD_NOMEFANTASIA
        INTO vCAD_MTMD_NOMEFANTASIA
        FROM TB_CAD_MTMD_MAT_MED MTMD
        WHERE CAD_MTMD_ID = pCAD_MTMD_ID;
        RAISE_APPLICATION_ERROR(-20000,' NAO EXISTE ESTOQUE, PRODUTO :'||vCAD_MTMD_NOMEFANTASIA||
                                       ' QTDE ESTOQUE '||TO_CHAR(vEstoque)||
                                       ' QTDE ESTORNO '||TO_CHAR(vMTMD_ESTCON_QTDE));
        END;
     END IF;
   -- VERIFICA ESTOQUE DO PRODUTO NO ALMOXARIFADO DE ORIGEM
   BEGIN
      SELECT MTMD_ESTLOC_QTDE
      INTO vEstoque
      FROM TB_MTMD_ESTOQUE_LOCAL
      WHERE  CAD_MTMD_ID                 = pCAD_MTMD_ID
      AND    CAD_MTMD_FILIAL_ID          = nFilial
      AND   CAD_UNI_ID_UNIDADE           = vCAD_UNI_ID_UNIDADE
      AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = vCAD_LAT_ID_LOCAL_ATENDIMENTO
      AND   CAD_SET_ID                   = vCAD_SET_ID;
     -- SE EXISTIR O ITEM NÃO ENTRA NO EXCEPTION, SE EXISTIR E ESTIVER ZERADO NAO PODE ESTORNAR
     IF ( vEstoque < vMTMD_ESTCON_QTDE ) THEN
        BEGIN
        SELECT MTMD.CAD_MTMD_NOMEFANTASIA
        INTO vCAD_MTMD_NOMEFANTASIA
        FROM TB_CAD_MTMD_MAT_MED MTMD
        WHERE CAD_MTMD_ID = pCAD_MTMD_ID;
        END;
        RAISE_APPLICATION_ERROR(-20000,' CONTAGEM ESTOQUE, '||CHR(13)||' NAO EXISTE ESTOQUE, ESTOQUE CENTRAL ( LOCAL ) PRODUTO '||TO_CHAR(pCAD_MTMD_ID)||
                                       ' ESTOQUE ATUAL  '||TO_CHAR(vEstoque)||CHR(13)||
                                       ' QTDE NOTA '||TO_CHAR(vMTMD_ESTCON_QTDE)||CHR(13)||
                                       ' FILIAL '||TO_CHAR(nFilial)||CHR(13)||
                                       ' PRODUTO '||vCAD_MTMD_NOMEFANTASIA||CHR(13)||
                                       ' '||sqlerrm);
     END IF;
   EXCEPTION
      WHEN NO_DATA_FOUND THEN
         NULL;
      WHEN OTHERS THEN
         RAISE_APPLICATION_ERROR(-20000,' ESTOQUE CENTRAL ( LOCAL ) PRODUTO '||TO_CHAR(pCAD_MTMD_ID)||' '||sqlerrm);
   END;
   -- BUSCA INFORMAÇÕES DO PRODUTO NO HISOTRICO DA NOTA
   BEGIN
      SELECT MTMD_LOTEST_ID,    MTMD_QTDE,    MTMD_PRECO_UNITARIO,  MTMD_DATA_PRC_MEDIO,  MTMD_MOV_ID
      INTO   vMTMD_LOTEST_ID,   vQtde,        vPrecoUnitario,       dCustoMedio,          vMTMD_MOV_ID
      FROM TB_MTMD_HISTORICO_NOTA_FISCAL
      WHERE CAD_MTMD_ID        = pCAD_MTMD_ID
      AND   CAD_MTMD_FILIAL_ID = nFilial
      AND   MTMD_NR_NOTA       = pMTMD_NR_NOTA
      AND   IDMOV              = IdMov
      AND   CODCOLIGADA        = CdColigada
      AND   IDSEQMOVRM         = pIDSEQMOVRM
      AND   SERIE              = sSerie;
   EXCEPTION
      WHEN NO_DATA_FOUND THEN
         NULL;
      WHEN OTHERS THEN
         RAISE_APPLICATION_ERROR(-20000,'OTHERS HISTORICO NOTA FISCAL '||sqlerrm);
   END;
   
   BEGIN
     -- BUSCA ULTIMA MOVIMENTACAO DO PRODUTO
     -- DEVE SER MENOR QUE A ENTRADA DO PRODUTO, SE MOVIMENTAÇÃO FOR POSTERIOR A ENTRADA NÃO PODE ESTORNAR
     IF ( pMTMD_NR_NOTA NOT IN  ('144293') ) THEN
        SELECT CONTA.DT_ULTIMO_CONSUMO
        INTO   dtUltimoConsumo
        FROM SGS.TB_MTMD_ESTOQUE_CONTABIL CONTA
        WHERE CONTA.CAD_MTMD_ID        = pCAD_MTMD_ID
        AND   CONTA.CAD_MTMD_FILIAL_ID = nFilial;
        
        IF ( dtUltimoConsumo > dCustoMedio ) THEN
           RAISE_APPLICATION_ERROR(-20000,' ESTE PRODUTO NAO PODE SER ALTERADO, JA HOUVE MOVIMENTACAO DE ESTOQUE ');
        END IF;
     END IF;
   EXCEPTION WHEN OTHERS THEN
     RAISE_APPLICATION_ERROR(-20000,SQLERRM||' ERRO BUSCANDO ULTIMO CONSUMO  PRODUTO '||TO_CHAR(pCAD_MTMD_ID)||
                                    ' FILIAL  '||TO_CHAR(nFilial)||
                                    ' ULT. CONS '||TO_CHAR(dtUltimoConsumo, 'DD/MM/YYYY HH24MI')||
                                    ' DT ENTRADA '||TO_CHAR(dCustoMedio,'DD/MM/YYYY HH24MI'));
   END;   
   
   -- FAZ COMPARACAO DA QTDE PARA SABER SE ESTA CORRETA
   IF ( vQtde != vMTMD_ESTCON_QTDE ) THEN
      RAISE_APPLICATION_ERROR(-20000,'COMPARACAO NA QUANTIDADE DO ESTORNO NAO CONFERE COM QTDE CADASTRADA NA NOTA '||TO_CHAR(vQtde)||
                                     ' QTDE RECEBIDA RM '||TO_CHAR(vMTMD_ESTCON_QTDE)||' '||sqlerrm);
   END IF;
   BEGIN
      -- GERA MOVIMENTAÇÃO DE ESTORNO
      PRC_MTMD_MOV_MOVIMENTACAO_I (   vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                      vCAD_UNI_ID_UNIDADE,
                                      vCAD_SET_ID,
                                      NULL,  -- REQUISICAO
                                      vMTMD_LOTEST_ID,
                                      pCAD_MTMD_ID,
                                      nFilial,
                                      pCAD_MTMD_TPMOV_ID,
                                      pCAD_MTMD_SUBTP_ID,
                                      SYSDATE,
                                      vMTMD_ESTCON_QTDE,
                                      1,    -- FLAG FINALIZADO
                                      NULL, -- ID ATENDIMENTO
                                      NULL, -- TIPO ATENDIMENTO
                                      1, -- Usuario
                                      NULL, -- ID_CONVERSAO
                                      NULL, -- QTDE_CONVERTIDA
                                      NULL, -- DT_FAT
                                      NULL, -- HR_FAT
                                      pNewIdt
                                   );
   -- ATUALIZA MOVIMENTAÇÃO ANTERIOR COMO ESTORNADA
  UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
  MTMD_MOV_FL_ESTORNO     = 1,
  MTMD_CUSTO_MEDIO        = vPrecoUnitario,  
  MTMD_MOV_ID_REF         = vMTMD_MOV_ID
  WHERE MTMD_MOV_ID = pNewIdt;
  -- ATUALIZA MOVIMENTO ESTORNADO
  UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
  MTMD_ID_USUARIO_ESTORNO = 1, --
  MTMD_MOV_FL_ESTORNO     = 1,
  MTMD_MOV_ID_REF         = pNewIdt
  WHERE MTMD_MOV_ID = vMTMD_MOV_ID;
   END;
   -- EXCLUI NOTA DO HISTORICO
   BEGIN
      DELETE TB_MTMD_HISTORICO_NOTA_FISCAL
      WHERE CAD_MTMD_ID        = pCAD_MTMD_ID
      AND   CAD_MTMD_FILIAL_ID = nFilial
      AND   MTMD_NR_NOTA       = pMTMD_NR_NOTA
      AND   IDMOV              = IdMov
      AND   CODCOLIGADA        = CdColigada
      AND   IDSEQMOVRM         = pIDSEQMOVRM
      AND   SERIE              = sSerie;
   EXCEPTION WHEN NO_DATA_FOUND THEN
      NULL;
   END;
   -- PARA O MESMO PRODUTO E FILIAL
   -- SE EXISTIR ENTRADA DE NOTAS POSTERIOR A NOTA QUE ESTA SENDO EXCLUIDA
   -- RECALCULA TODAS ATE A ATUAL.
   --
   -- BUSCA CUSTO MEDIO ANTERIOR AO ITEM EXCLUIDO
   -- SIMULA ULTIMA NOTA QUE ENTROU NO ESTOQUE
   BEGIN
     SELECT MTMD_CUSTO_MEDIO,           MTMD_DATA_PRC_MEDIO,   MTMD_ESTCON_QTDE_ANTERIOR
     INTO   vMTMD_CUSTO_MEDIO_ANTERIOR, dCustoMedioAnterior,   vMTMD_ESTCON_QTDE_ANTERIOR
     FROM TB_MTMD_HISTORICO_NOTA_FISCAL
     WHERE MTMD_DATA_PRC_MEDIO = ( SELECT MAX( MTMD_DATA_PRC_MEDIO  )
                                   FROM TB_MTMD_HISTORICO_NOTA_FISCAL
                                   WHERE MTMD_DATA_PRC_MEDIO <  dCustoMedio
                                   AND   CAD_MTMD_ID          = pCAD_MTMD_ID
                                   AND   CAD_MTMD_FILIAL_ID   = nFilial )
     AND CAD_MTMD_ID          = pCAD_MTMD_ID
     AND CAD_MTMD_FILIAL_ID   = nFilial
     -- AND SERIE                = sSerie
     AND ROWNUM = 1;
   EXCEPTION
     WHEN TOO_MANY_ROWS THEN
        RAISE_APPLICATION_ERROR(-20000,' PRODUTO '||TO_CHAR(pCAD_MTMD_ID)||' FILIAL '||TO_CHAR(nFilial) );
     WHEN NO_DATA_FOUND THEN
      vMTMD_CUSTO_MEDIO_ANTERIOR := 0;
      vMTMD_CUSTO_MEDIO          := 0;
      NULL;
   END;
   -- ATUALIZA CUSTO MEDIO
   vMTMD_CUSTO_MEDIO := vMTMD_CUSTO_MEDIO_ANTERIOR;
   FOR recalc IN
   ( SELECT MTMD_PRECO_UNITARIO, MTMD_QTDE,   MTMD_LOTEST_ID,  MTMD_NR_NOTA,
            IDMOV,               CODCOLIGADA, IDSEQMOVRM,
            MTMD_ESTCON_QTDE_ANTERIOR, -- ESTOQUE NA EPOCA DA ENTRADA DA NOTA
            MTMD_CUSTO_MEDIO  -- CUSTO MEDIO CALCULADO NA ENTRADA DA NOTA
     FROM TB_MTMD_HISTORICO_NOTA_FISCAL NOTA
     WHERE CAD_MTMD_ID          = pCAD_MTMD_ID
     AND   CAD_MTMD_FILIAL_ID   = nFilial
     AND   MTMD_DATA_PRC_MEDIO > dCustoMedioAnterior
     -- AND   SERIE                = sSerie
     ORDER BY MTMD_DATA_PRC_MEDIO
   )
   LOOP
      -- RECALCULA CUSTO MEDIO
      vMTMD_CUSTO_MEDIO := FNC_MTMD_CALCULA_CUSTO_MEDIO ( pCAD_MTMD_ID,
                                                          nFilial,
                                                          RECALC.MTMD_QTDE,
                                                          RECALC.MTMD_PRECO_UNITARIO,
                                                          RECALC.MTMD_ESTCON_QTDE_ANTERIOR, -- QTDE HISTORICO
                                                          vMTMD_CUSTO_MEDIO           -- CUSTO MEDIO HISTORICO
                                                        );
      -- ATUALIZA CUSTO MEDIO NA NOTA FISCAL
      UPDATE TB_MTMD_HISTORICO_NOTA_FISCAL SET
      MTMD_CUSTO_MEDIO          = vMTMD_CUSTO_MEDIO
--      MTMD_ESTCON_QTDE_ANTERIOR = vMTMD_ESTCON_QTDE_ANTERIOR,
--      MTMD_DATA_PRC_MEDIO       = SYSDATE
      WHERE MTMD_LOTEST_ID     = recalc.MTMD_LOTEST_ID
      AND   MTMD_NR_NOTA       = recalc.MTMD_NR_NOTA
      AND   IDMOV              = recalc.IDMOV
      AND   CODCOLIGADA        = recalc.CODCOLIGADA
      AND   IDSEQMOVRM         = recalc.IDSEQMOVRM
      AND   CAD_MTMD_ID        = pCAD_MTMD_ID
      AND   CAD_MTMD_FILIAL_ID = nFilial
      AND   SERIE              = sSerie;
      --
--      vMTMD_ESTCON_QTDE_ANTERIOR := (vMTMD_ESTCON_QTDE_ANTERIOR + recalc.MTMD_QTDE );
--      vMTMD_CUSTO_MEDIO_ANTERIOR := vMTMD_CUSTO_MEDIO;
   END LOOP;
   -- BAIXA ESTOQUE DO ALMOXARIFADO CENTRAL
   UPDATE TB_MTMD_ESTOQUE_LOCAL SET
   MTMD_ESTLOC_QTDE = MTMD_ESTLOC_QTDE - vMTMD_ESTCON_QTDE,
   MTMD_ESTLOC_DATA = SYSDATE
   WHERE CAD_MTMD_ID                  = pCAD_MTMD_ID
   AND   CAD_UNI_ID_UNIDADE           = vCAD_UNI_ID_UNIDADE
   AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = vCAD_LAT_ID_LOCAL_ATENDIMENTO
   AND   CAD_SET_ID                   = vCAD_SET_ID
   AND   CAD_MTMD_FILIAL_ID           = nFilial;
   -- AND   MTMD_LOTEST_ID     = pMTMD_LOTEST_ID   ;
   -- BAIXA ESTOQUE CONTABIL
   vMTMD_ESTCON_QTDE := FNC_MTMD_ESTOQUE_CONTABIL(pCAD_MTMD_ID, nFilial );
   BEGIN
      UPDATE TB_MTMD_ESTOQUE_CONTABIL SET
      MTMD_ESTCON_QTDE           = vMTMD_ESTCON_QTDE,
      MTMD_ESTCON_DT_ATUALIZACAO = SYSDATE,
      MTMD_CUSTO_MEDIO           = vMTMD_CUSTO_MEDIO -- VALOR DO ULTIMO CUSTO MEDIO RECALCULADO
      WHERE CAD_MTMD_ID        = pCAD_MTMD_ID
      AND   CAD_MTMD_FILIAL_ID = nFilial;
   END;
   --
   --
END PRC_MTMD_MOV_ESTOQUE_ESTORNONF;

 
