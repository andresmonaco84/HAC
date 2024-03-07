CREATE OR REPLACE TRIGGER TR_INTERF_MATMED
 AFTER
 INSERT OR UPDATE OR DELETE
 ON RM.TITMMOV
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
sStatus          TMOV.STATUS%TYPE;
sTipo            TMOV.tipo%TYPE;
sTipoMov         TMOV.codtmv%TYPE;
NotaFiscal       TMOV.numeromov%TYPE;
vCODCCUSTO       TMOV.CODCCUSTO%TYPE;
sControlaEstoque TITMTMV.efeitosaldoa2%TYPE;
dDataMov         TMOV.DATAMOVIMENTO%TYPE;
IdMov            TMOV.IDMOV%TYPE;
vCODCFO          TMOV.CODCFO%TYPE;
vNOMEFORNECEDOR  FCFO.NOMEFANTASIA%TYPE;
vNUM_AUTORIZA_FORN FCFOCOMPL.NROAUTORFUNC%TYPE;
vQtdCompra       NUMBER;
vGOTAS           NUMBER;


CdColigada       TMOV.CODCOLIGADA%TYPE;
VlrUnitario      TITMMOV.VALORUNITARIO%TYPE;
--VlrTeste         TITMMOV.VALORUNITARIO%TYPE;
-- VlrUnitario      NUMBER;
-- VlrOld           TITMMOV.VALORUNITARIO%TYPE;
-- VlrNew           TITMMOV.VALORUNITARIO%TYPE;

NomeFantasia     TPRODUTO.nomefantasia%type;
pDESCRICAO       TPRODUTO.DESCRICAO%TYPE;
IDTPRODUTO_RM    TPRODUTO.IDPRD%TYPE;
pCONTROLADOPORLOTE TPRODUTO.CONTROLADOPORLOTE%TYPE;
pCODFAB          TPRODUTODEF.CODFAB%TYPE;
pFRACIONADO      NUMBER;
pCODUNDCONTROLE  TPRODUTODEF.CODUNDCONTROLE%TYPE;
pCODUNDVENDA     TPRODUTODEF.CODUNDVENDA%TYPE;
pCODUNDCOMPRA    TPRODUTODEF.CODUNDCOMPRA%TYPE;
pCODUNDNOTA      TPRODUTODEF.CODUNDCOMPRA%TYPE; -- UNIDADE DE COMPRA DA NOTA
pCODIGOPRD       TPRODUTO.CODIGOPRD%TYPE;
pGRUPO           TPRODUTODEF.CODTB3FAT%TYPE;
pSUBGRUPO        TPRODUTODEF.CODTB4FAT%TYPE;
sSerie           VARCHAR2(8);

ControlaLote     TPRODUTO.CONTROLADOPORLOTE%TYPE;

IdtProduto       SGS.TB_CAD_MTMD_MAT_MED.cad_mtmd_id@PRODUCAO%TYPE;
UnidadeCompra    SGS.TB_CAD_MTMD_MAT_MED.cad_mtmd_unidade_compra@PRODUCAO%TYPE;
UnidadeNota      SGS.TB_CAD_MTMD_MAT_MED.cad_mtmd_unidade_compra@PRODUCAO%TYPE;
IdtFilial        SGS.TB_MTMD_ESTOQUE_LOCAL.CAD_MTMD_FILIAL_ID@PRODUCAO%TYPE;
--IdtLote          SGS.TB_MTMD_LOTEST_LOTE_ESTOQUE.MTMD_LOTEST_ID@PRODUCAO%TYPE;
Qtde             SGS.TB_MTMD_ESTOQUE_LOCAL.MTMD_ESTLOC_QTDE@PRODUCAO%TYPE;
-- Qtde             NUMBER;
-- NewIdtMov        SGS.TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_ID@PRODUCAO%TYPE;

IdtSetor         SGS.TB_CAD_SET_SETOR.CAD_SET_ID@PRODUCAO%TYPE;
IdtLocal         SGS.TB_CAD_SET_SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO@PRODUCAO%TYPE;
IdtUnidade       SGS.TB_CAD_SET_SETOR.CAD_UNI_ID_UNIDADE@PRODUCAO%TYPE;
IdtTipoMov       SGS.TB_CAD_MTMD_TIPO_MOVIMENTACAO.CAD_MTMD_TPMOV_ID@PRODUCAO%TYPE;
IdtSubTipoMov    SGS.TB_CAD_MTMD_SUBTP_MOVIMENTACAO.CAD_MTMD_SUBTP_ID@PRODUCAO%TYPE;
TipoProduto      SGS.TB_CAD_MTMD_MAT_MED.TIS_MED_CD_TABELAMEDICA@PRODUCAO%TYPE; -- 95= material 96=,edicamento
-- VlrCustoMedio    SGS.TB_MTMD_HISTORICO_NOTA_FISCAL.MTMD_CUSTO_MEDIO@PRODUCAO%TYPE;
-- VlrCustoMedio    NUMBER;

RM_ESTOQUE_HAC    CONSTANT NUMBER := 1;
RM_ESTOQUE_ACS    CONSTANT NUMBER := 2;
SGS_ESTOQUE_HAC   SGS.TB_MTMD_ESTOQUE_LOCAL.CAD_MTMD_FILIAL_ID@PRODUCAO%TYPE := 1;
SGS_ESTOQUE_ACS   SGS.TB_MTMD_ESTOQUE_LOCAL.CAD_MTMD_FILIAL_ID@PRODUCAO%TYPE := 2;
-- SGS_ESTOQUE_TODOS SGS.TB_MTMD_ESTOQUE_LOCAL.CAD_MTMD_FILIAL_ID@PRODUCAO%TYPE := 3;


PARAPROCESSO EXCEPTION;


BEGIN

--IF :NEW.CODCOLIGADA = 1 THEN

   -- BUSCO INFORMAC?ES SOBRE O ITEM NO TMOV
   IF DELETING THEN
     pCODUNDNOTA := :OLD.CODUND;
     BEGIN
       SELECT CODIGOPRD INTO pCODIGOPRD
       FROM TPRODUTO PRODUTO
       WHERE PRODUTO.CODCOLPRD = :OLD.CODCOLIGADA
       AND   PRODUTO.IDPRD     = :OLD.IDPRD;

       BEGIN
         SELECT PRODUTO.CONTROLADOPORLOTE, PRODUTO.NOMEFANTASIA, PRODUTO.DESCRICAO,
                DEF.CODFAB,                DECODE( CAMPOLIVRE2, 'S', 1, 0),
                DEF.CODUNDCONTROLE,        DEF.CODUNDVENDA,
                DEF.CODUNDCOMPRA,          PRODUTO.CONTROLADOPORLOTE,
                DEF.CODTB3FAT,             DEF.CODTB4FAT
         INTO   ControlaLote,              NomeFantasia,         pDescricao,
                pCODFAB,                   pFRACIONADO,
                pCODUNDCONTROLE,           pCODUNDVENDA,
                pCODUNDCOMPRA,             pCONTROLADOPORLOTE,
                pGRUPO,                    pSUBGRUPO
         FROM TPRODUTO PRODUTO, TPRODUTODEF DEF
         WHERE DEF.CODCOLIGADA   = PRODUTO.CODCOLPRD
         AND   DEF.IDPRD         = PRODUTO.IDPRD
         AND   PRODUTO.CODCOLPRD = 1 --Sempre pegar inf. do HAC
         AND   TRIM(PRODUTO.CODIGOPRD) = TRIM(pCODIGOPRD);
       EXCEPTION
         WHEN NO_DATA_FOUND THEN
           SELECT PRODUTO.CONTROLADOPORLOTE, PRODUTO.NOMEFANTASIA, PRODUTO.DESCRICAO,
                  DEF.CODFAB,                DECODE( CAMPOLIVRE2, 'S', 1, 0),
                  DEF.CODUNDCONTROLE,        DEF.CODUNDVENDA,
                  DEF.CODUNDCOMPRA,
                  DEF.CODTB3FAT,             DEF.CODTB4FAT
           INTO   ControlaLote,              NomeFantasia,         pDescricao,
                  pCODFAB,                   pFRACIONADO,
                  pCODUNDCONTROLE,           pCODUNDVENDA,
                  pCODUNDCOMPRA,
                  pGRUPO,                    pSUBGRUPO
           FROM TPRODUTO PRODUTO, TPRODUTODEF DEF
           WHERE DEF.CODCOLIGADA   = PRODUTO.CODCOLPRD
           AND   DEF.IDPRD         = PRODUTO.IDPRD
           AND   PRODUTO.CODCOLPRD = :OLD.CODCOLIGADA
           AND   TRIM(PRODUTO.CODIGOPRD) = TRIM(pCODIGOPRD);
         END;
     END;

     BEGIN
        SELECT NOTA.STATUS,       NOTA.TIPO, NOTA.codtmv, NOTA.NUMEROMOV,
               NOTA.DATAMOVIMENTO, NOTA.SERIE
        INTO   sStatus,           sTipo,     sTipoMov,    NotaFiscal,
               dDataMov,          sSerie
        FROM TMOV NOTA
        WHERE NOTA.IDMOV       = :OLD.IDMOV
        AND   NOTA.codcoligada = :OLD.CODCOLIGADA;
     EXCEPTION
        WHEN NO_DATA_FOUND THEN
             RAISE_APPLICATION_ERROR(-20000,' N?o encontrou nota fiscal IDMOV '||IdMov||' COLIGADA '||CdColigada);
        WHEN TOO_MANY_ROWS THEN
             RAISE_APPLICATION_ERROR(-20000,' MUITAS LINHAS IDMOV '||IdMov||' COLIGADA '||CdColigada);
        WHEN OTHERS THEN
             RAISE_APPLICATION_ERROR(-20000,'Nota Fiscal '||sqlerrm);
     END;
     --
     BEGIN
          SELECT TIPOMOVIMENTO.efeitosaldoa2
          INTO   sControlaEstoque
          FROM TITMTMV TIPOMOVIMENTO
          WHERE TIPOMOVIMENTO.CODTMV      = sTipoMov
          AND TIPOMOVIMENTO.CODCOLIGADA   = :OLD.CODCOLIGADA;
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
               RAISE_APPLICATION_ERROR(-20000,'Tipo Movimento NO_DATA_FOUND');
          WHEN OTHERS THEN
               RAISE_APPLICATION_ERROR(-20000,'Tipo Movimento '||sqlerrm);
        END;

        IDTPRODUTO_RM := :OLD.IDPRD;
   ELSE -- INSERTING OU UPDATING ====================================================================
     IF ( :NEW.CODUND IS NOT NULL  ) THEN
        pCODUNDNOTA := :NEW.CODUND;
     ELSE
        pCODUNDNOTA := :OLD.CODUND;
     END IF;
     BEGIN
       SELECT CODIGOPRD INTO pCODIGOPRD
       FROM TPRODUTO PRODUTO
       WHERE PRODUTO.CODCOLPRD = :NEW.CODCOLIGADA
       AND   PRODUTO.IDPRD     = :NEW.IDPRD;

       BEGIN
         SELECT PRODUTO.CONTROLADOPORLOTE, PRODUTO.NOMEFANTASIA, PRODUTO.DESCRICAO,
                DEF.CODFAB,                DECODE( CAMPOLIVRE2, 'S', 1, 0),
                DEF.CODUNDCONTROLE,        DEF.CODUNDVENDA,
                DEF.CODUNDCOMPRA,
                DEF.CODTB3FAT,             DEF.CODTB4FAT,       DECODE( PRODUTO.CAMPOLIVRE3, 'S', 1, NULL)
         INTO   ControlaLote,              NomeFantasia,         pDescricao,
                pCODFAB,                   pFRACIONADO,
                pCODUNDCONTROLE,           pCODUNDVENDA,
                pCODUNDCOMPRA,
                pGRUPO,                    pSUBGRUPO,         vGOTAS
         FROM TPRODUTO PRODUTO, TPRODUTODEF DEF
         WHERE DEF.CODCOLIGADA   = PRODUTO.CODCOLPRD
         AND   DEF.IDPRD         = PRODUTO.IDPRD
         AND   PRODUTO.CODCOLPRD = 1 --Sempre pegar inf. do HAC
         AND   TRIM(PRODUTO.CODIGOPRD) = TRIM(pCODIGOPRD);
       EXCEPTION
           WHEN NO_DATA_FOUND THEN
                SELECT PRODUTO.CONTROLADOPORLOTE, PRODUTO.NOMEFANTASIA, PRODUTO.DESCRICAO,
                        DEF.CODFAB,                DECODE( CAMPOLIVRE2, 'S', 1, 0),
                        DEF.CODUNDCONTROLE,        DEF.CODUNDVENDA,
                        DEF.CODUNDCOMPRA,
                        DEF.CODTB3FAT,             DEF.CODTB4FAT,       DECODE( PRODUTO.CAMPOLIVRE3, 'S', 1, NULL)
                 INTO   ControlaLote,              NomeFantasia,         pDescricao,
                        pCODFAB,                   pFRACIONADO,
                        pCODUNDCONTROLE,           pCODUNDVENDA,
                        pCODUNDCOMPRA,
                        pGRUPO,                    pSUBGRUPO,         vGOTAS
                 FROM TPRODUTO PRODUTO, TPRODUTODEF DEF
                 WHERE DEF.CODCOLIGADA   = PRODUTO.CODCOLPRD
                 AND   DEF.IDPRD         = PRODUTO.IDPRD
                 AND   PRODUTO.CODCOLPRD = :NEW.CODCOLIGADA
                 AND   TRIM(PRODUTO.CODIGOPRD) = TRIM(pCODIGOPRD);
       END;
     END;

     --
     IF ( UPDATING ) THEN
        -- AQUI
        IF ( :OLD.IDPRD !=  :NEW.IDPRD ) THEN
           RAISE_APPLICATION_ERROR(-20000,'Voce n?o pode alterar este item ( tentativa de alterar codigo do item )');
        END IF;

        BEGIN
           SELECT NOTA.STATUS,        NOTA.TIPO,   NOTA.codtmv, NOTA.NUMEROMOV,
                  NOTA.DATAMOVIMENTO, NOTA.CODCFO, NOTA.SERIE
           INTO   sStatus,           sTipo,     sTipoMov,        NotaFiscal,
                  dDataMov,          vCODCFO,   sSerie
           FROM TMOV NOTA
           WHERE NOTA.IDMOV       = :NEW.IDMOV
           AND   NOTA.codcoligada = :NEW.CODCOLIGADA;
        EXCEPTION
           WHEN NO_DATA_FOUND THEN
                RAISE_APPLICATION_ERROR(-20000,' N?o encontrou nota fiscal IDMOV '||IdMov||' COLIGADA '||CdColigada);
           WHEN TOO_MANY_ROWS THEN
                RAISE_APPLICATION_ERROR(-20000,' MUITAS LINHAS IDMOV '||IdMov||' COLIGADA '||CdColigada);
           WHEN OTHERS THEN
                RAISE_APPLICATION_ERROR(-20000,'Nota Fiscal '||sqlerrm);
        END;
     ELSIF ( INSERTING ) THEN
        BEGIN
           SELECT NOTA.STATUS,        NOTA.TIPO,   NOTA.codtmv, NOTA.NUMEROMOV,
                  NOTA.DATAMOVIMENTO, NOTA.CODCFO, NOTA.SERIE
           INTO   sStatus,           sTipo,        sTipoMov,    NotaFiscal,
                  dDataMov,          vCODCFO,      sSerie
           FROM TMOV NOTA
           WHERE NOTA.IDMOV       = :NEW.IDMOV
           AND   NOTA.codcoligada = :NEW.CODCOLIGADA;
        EXCEPTION
           WHEN NO_DATA_FOUND THEN
                RAISE_APPLICATION_ERROR(-20000,' N?o encontrou nota fiscal IDMOV '||IdMov||' COLIGADA '||CdColigada);
           WHEN TOO_MANY_ROWS THEN
                RAISE_APPLICATION_ERROR(-20000,' MUITAS LINHAS IDMOV '||IdMov||' COLIGADA '||CdColigada);
           WHEN OTHERS THEN
                RAISE_APPLICATION_ERROR(-20000,'Nota Fiscal '||sqlerrm);
        END;
     END IF;
     --

     --
     BEGIN
          SELECT TIPOMOVIMENTO.efeitosaldoa2
          INTO   sControlaEstoque
          FROM TITMTMV TIPOMOVIMENTO
          WHERE TIPOMOVIMENTO.CODTMV      = sTipoMov
          AND TIPOMOVIMENTO.CODCOLIGADA   = :NEW.CODCOLIGADA;
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
               RAISE_APPLICATION_ERROR(-20000,'Tipo Movimento NO_DATA_FOUND');
          WHEN OTHERS THEN
               RAISE_APPLICATION_ERROR(-20000,'Tipo Movimento '||sqlerrm);
        END;
        IDTPRODUTO_RM := :NEW.IDPRD;
   END IF;

   -- UNDADE DE COMPRA
   BEGIN
      SELECT UNIDADE.FATORCONVERSAO
      INTO  UnidadeNota
      FROM TUND UNIDADE
      WHERE UNIDADE.CODUND = pCODUNDNOTA;
   EXCEPTION WHEN NO_DATA_FOUND THEN
      RAISE_APPLICATION_ERROR(-20000,'UNIDADE DE COMPRA - NO_DATA_FOUND');
   END;

   BEGIN
        IF (sTipoMov = '1.2.48' AND :NEW.CODCOLIGADA = 1) THEN
            SELECT CODCCUSTO INTO vCODCCUSTO FROM TMOV
             WHERE IDMOV = :NEW.IDMOV AND CODCOLIGADA = :NEW.CODCOLIGADA;
            --Para consignados do HAC, buscar setor pelo Centro de Custo para baixa automatica
            SELECT ASS.CAD_SET_ID,
                   ASS.CAD_UNI_ID_UNIDADE,
                   ASS.CAD_LAT_ID_LOCAL_ATENDIMENTO
              INTO IdtSetor,
                   IdtUnidade,
                   IdtLocal
              FROM SGS.TB_ASS_USC_UNI_SET_CCUS_CLA@PRODUCAO ASS,
                   SGS.TB_CAD_CEC_CENTRO_CUSTO@PRODUCAO     CEC
             WHERE CEC.CAD_CEC_ID_CCUSTO = ASS.CAD_CEC_ID_CCUSTO AND
                   TRIM(CEC.CAD_CEC_CD_CCUSTO) = TRIM(vCODCCUSTO) AND
                   ASS.CAD_UNI_ID_UNIDADE IN (244,248) AND --SANTOS E AMB. SANTOS
                   ASS.CAD_TAP_TP_ATRIBUTO = 'MAT' AND
                   ASS.CAD_CEC_ID_CCUSTO IS NOT NULL AND
                   ASS.ASS_USC_FL_STATUS = 'A' AND
                   (ASS.ASS_USC_DT_FIM_VIGENCIA IS NULL OR
                    (ASS.ASS_USC_DT_INICIO_VIGENCIA <= TRUNC(SYSDATE) AND TRUNC(SYSDATE) <= TRUNC(NVL(ASS.ASS_USC_DT_FIM_VIGENCIA, SYSDATE)))) AND
                    ROWNUM = 1;
             --RAISE_APPLICATION_ERROR(-20000,'1.2.48 - ' || vCODCCUSTO || ' ' || IdtSetor || ' ');
        ELSIF (sTipoMov NOT IN ('2.2.08', '2.2.12', '2.2.01')) THEN
             --BUSCA ALMOX CENTRAL, PODE TROCAR ALMOXARIFADO NA PROCEDURE DE ENTRADA DEPENDENDO TIPO DE MOVIMENTO
             SELECT SETOR.CAD_SET_ID,
                    SETOR.CAD_UNI_ID_UNIDADE,
                    SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO
             INTO   IdtSetor,
                    IdtUnidade,
                    IdtLocal
             FROM SGS.TB_CAD_SET_SETOR@PRODUCAO SETOR
             WHERE SETOR.CAD_SET_ALMOX_CENTRAL = 1;
        END IF;
   EXCEPTION
         WHEN TOO_MANY_ROWS THEN
             --DSADT.EMAIL@PRODUCAO('andre.monaco@anacosta.com.br', '[TRIGGER NF]SETOR DE ABASTECIMENTO TOO_MANY_ROWS ',' CODCCUSTO '||TO_CHAR(vCODCCUSTO)||' - '||sTipoMov);
             RAISE_APPLICATION_ERROR(-20000,'SETOR DE ABASTECIMENTO TOO_MANY_ROWS');
         WHEN NO_DATA_FOUND THEN
             --DSADT.EMAIL@PRODUCAO('andre.monaco@anacosta.com.br', '[TRIGGER NF]SETOR DE ABASTECIMENTO NO_DATA_FOUND ',' CODCCUSTO '||TO_CHAR(vCODCCUSTO)||' - '||sTipoMov);
             RAISE_APPLICATION_ERROR(-20000,'SETOR DE ABASTECIMENTO NO_DATA_FOUND');
         WHEN OTHERS THEN
             --DSADT.EMAIL@PRODUCAO('andre.monaco@anacosta.com.br', '[TRIGGER NF]SETOR DE ABASTECIMENTO ',' CODCCUSTO '||TO_CHAR(vCODCCUSTO)||' - '||sTipoMov);
             RAISE_APPLICATION_ERROR(-20000,'SETOR DE ABASTECIMENTO'||sqlerrm);
   END;

   /*BEGIN
       SELECT SETOR.CAD_SET_ID,
              SETOR.CAD_UNI_ID_UNIDADE,
              SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO
       INTO   IdtSetor,
              IdtUnidade,
              IdtLocal
       FROM SGS.TB_CAD_SET_SETOR@PRODUCAO SETOR
       -- FROM SGS.TB_CAD_SET_SETOR@SGSDEV SETOR
       WHERE SETOR.CAD_SET_ALMOX_CENTRAL = 1;
   EXCEPTION
     WHEN TOO_MANY_ROWS THEN
          RAISE_APPLICATION_ERROR(-20000,'SETOR');
     WHEN NO_DATA_FOUND THEN
         RAISE_APPLICATION_ERROR(-20000,'SETOR NO_DATA_FOUND');
     WHEN OTHERS THEN
         RAISE_APPLICATION_ERROR(-20000,'SETOR '||sqlerrm);
   END;*/

   --IF DELETING THEN
   --   RAISE_APPLICATION_ERROR(-20000,'PRIMEIRO TESTE DELETANDO STATUS '||sStatus||' TIPO '||sTipo);
   -- END IF;
--   IF ( sStatus = 'F' AND UPDATING ) THEN
   IF ( sStatus IN ('F','N') AND (INSERTING) ) THEN
      IF ( sTipo = 'P' AND (INSERTING) ) THEN
         -- RAISE_APPLICATION_ERROR(-20000,'ATUALIZANDO STATUS '||sStatus||' TIPO '||sTipo);
         IF ( sControlaEstoque = 'A' OR sTipoMov = '2.2.03') THEN --2.2.03 = DEVOLUCAO
            -- BUSCA FORNECEDOR
            BEGIN
               SELECT F.NOMEFANTASIA, FC.NROAUTORFUNC
                 INTO vNOMEFORNECEDOR, vNUM_AUTORIZA_FORN
                 FROM FCFO F LEFT JOIN FCFOCOMPL FC ON F.CODCOLIGADA = FC.CODCOLIGADA AND F.CODCFO = FC.CODCFO
               WHERE F.CODCFO = vCODCFO
               AND   F.CODCOLIGADA = :NEW.CODCOLIGADA;
              /*SELECT NOMEFANTASIA
               INTO   vNOMEFORNECEDOR
               FROM FCFO
               WHERE CODCFO      = vCODCFO
               AND   CODCOLIGADA = :NEW.CODCOLIGADA;*/
            EXCEPTION WHEN OTHERS THEN
                vNOMEFORNECEDOR := 'NAO LOCALIZADO';
              --  DSADT.EMAIL@PRODUCAO('andre.monaco@anacosta.com.br', '[TRIGGER NF] FORNECEDOR',' PROBLEMA FORNECEDOR '||NVL(vCODCFO,'#NULO#')||' ERRO '||SQLERRM);
                RAISE_APPLICATION_ERROR(-20000,'[TRIGGER NF] FORNECEDOR PROBLEMA FORNECEDOR '||NVL(vCODCFO,'#NULO#')||' ERRO '||SQLERRM);
            END;

            -- FAZ CONTROLE DE ESTOQUE DO PRODUTO
            -- E ENTRADA DE NOTA, VERIFICO SE CONTROLE ESTOQUE
--=====================================================================================================
            IdtTipoMov    := 1; -- ENTRADA
            IdtSubTipoMov := 1; -- ENTRADA FORNECEDOR
            IF ( :NEW.CODCOLIGADA = RM_ESTOQUE_HAC ) THEN
               IdtFilial := SGS_ESTOQUE_HAC;
            ELSIF ( :NEW.CODCOLIGADA = RM_ESTOQUE_ACS ) THEN
               IdtFilial := SGS_ESTOQUE_ACS;
            ELSE
               -- IdtFilial := SGS_ESTOQUE_TODOS;
               -- IdtFilial := NULL;
               IdtFilial := SGS_ESTOQUE_HAC;
               -- RAISE_APPLICATION_ERROR(-20000,'ERRO SELECIONANDO FILIAL '||SQLERRM);
            END IF;
            IF ( IdtFilial IS NOT NULL ) THEN
              -- BUSCA INFORMAC?O DENTRO DO SGS

               -- BUSCA PRODUTO
               BEGIN
                  -- retirada unidade de compra do cadastro deve ser usada a da nota fiscal
                  SELECT PRODUTO.cad_mtmd_id,
                         PRODUTO.cad_mtmd_unidade_compra,
                         PRODUTO.TIS_MED_CD_TABELAMEDICA
                  INTO   IdtProduto,
                         UnidadeCompra,
                         TipoProduto
                  FROM SGS.TB_CAD_MTMD_MAT_MED@PRODUCAO PRODUTO
                  -- FROM SGS.TB_CAD_MTMD_MAT_MED@SGSDEV PRODUTO
                  --WHERE PRODUTO.CAD_MTMD_CD_RM = :NEW.IDPRD;
                  WHERE PRODUTO.CAD_MTMD_FL_ATIVO = 1 AND
                        TRIM(PRODUTO.CAD_MTMD_CODMNE) = TRIM(pCODIGOPRD);
                    --AND CAD_MTMD_ID NOT IN (50113);
                  IF ( TipoProduto = 95 ) THEN
                     -- E MATERIAL AJUSTA FILIAL PARA HAC
                     IdtFilial := SGS_ESTOQUE_HAC;
                  END IF;
               EXCEPTION
                 WHEN TOO_MANY_ROWS THEN
                      RAISE_APPLICATION_ERROR(-20000,'PRODUTO');
                 WHEN NO_DATA_FOUND THEN
                    SGS.PRC_CAD_MTMD_MAT_MED_I@PRODUCAO ( pGRUPO, -- GRUPO
                    -- SGS.PRC_CAD_MTMD_MAT_MED_I@SGSDEV ( pGRUPO, -- GRUPO
                                                    pSUBGRUPO,
                                                    NomeFantasia,
                                                    pDESCRICAO,
                                                    pCODFAB,
                                                    pFRACIONADO,
                                                    1, -- ATIVO
                                                    :NEW.IDPRD,
                                                    pCONTROLADOPORLOTE,
                                                    pCODUNDCONTROLE,
                                                    pCODUNDVENDA,
                                                    pCODUNDCOMPRA,
                                                    pCODIGOPRD,
                                                    vGOTAS,
                                                    IdtProduto
                                                  );
                       BEGIN
                           SELECT PRODUTO.cad_mtmd_id,
                                  -- PRODUTO.cad_mtmd_unidade_compra,
                                  PRODUTO.TIS_MED_CD_TABELAMEDICA
                           INTO   IdtProduto,
                                  -- UnidadeCompra,
                                  TipoProduto
                           FROM SGS.TB_CAD_MTMD_MAT_MED@PRODUCAO PRODUTO
                           -- FROM SGS.TB_CAD_MTMD_MAT_MED@SGSDEV PRODUTO
                           --WHERE PRODUTO.CAD_MTMD_CD_RM = :OLD.IDPRD;
                           WHERE PRODUTO.CAD_MTMD_FL_ATIVO = 1 AND
                                 TRIM(PRODUTO.CAD_MTMD_CODMNE) = TRIM(pCODIGOPRD);
                           IF ( TipoProduto = 95 ) THEN
                              -- E MATERIAL AJUSTA FILIAL PARA HAC
                              IdtFilial := SGS_ESTOQUE_HAC;
                           END IF;
                       EXCEPTION WHEN NO_DATA_FOUND THEN
                        --  DSADT.EMAIL@PRODUCAO('andre.monaco@anacosta.com.br', '[TRIGGER NF] Produto nao cadastrado UPDATE TENTATIVA 2',' ID RM '||TO_CHAR(:OLD.IDPRD));
                          RAISE_APPLICATION_ERROR(-20000,'[TRIGGER NF] Produto nao cadastrado ');
                       END;
                      -- DSADT.EMAIL@PRODUCAO('ricardo.costa@anacosta.com.br', 'Produto nao cadastrado DELETANDO',' ID RM '||TO_CHAR(:NEW.IDPRD));
                      -- RAISE_APPLICATION_ERROR(-20000,'PRODUTO NO_DATA_FOUND '||TO_CHAR(:NEW.IDPRD));
                 WHEN OTHERS THEN
                      RAISE_APPLICATION_ERROR(-20000,'PRODUTO '||sqlerrm);
               END;
              IF ( :NEW.QUANTIDADE IS NULL ) THEN
                 Qtde := :OLD.QUANTIDADE;
              ELSE
                 Qtde := :NEW.QUANTIDADE;
              END IF;
              vQtdCompra := Qtde;
              Qtde := (Qtde * UnidadeNota );
              IF ( Qtde IS NULL ) THEN
                 RAISE_APPLICATION_ERROR(-20000,' N?O TEM QUANTIDADE PRODUTO '||TO_CHAR(IdtProduto) ||' QTDE '||TO_CHAR(Qtde)||' UnidadeCompra '||TO_CHAR(UnidadeCompra));
              END IF;
  --=====================================================================================================
              IF INSERTING THEN
                -- INSERE CODIGO DE BARRA
                /*BEGIN
                  -- SGS.PRC_ASS_MTMD_CODIGO_BARRA_I@SGSDEV(IdtProduto, IdtFilial, IdtLote, SGS.FNC_MTMD_COD_BARRA_EAN13@SGSDEV(IdtLote, IdtProduto));
                  SGS.PRC_ASS_MTMD_CODIGO_BARRA_I@PRODUCAO(IdtProduto, IdtFilial, IdtLote, SGS.FNC_MTMD_COD_BARRA_EAN13@PRODUCAO(IdtLote, IdtProduto));
                EXCEPTION
                 WHEN DUP_VAL_ON_INDEX THEN
                    -- VERIFICAR O QUE FAZER NESTE CASO
                    NULL;
                 WHEN OTHERS THEN
                     DSADT.EMAIL@PRODUCAO('andre.monaco@anacosta.com.br', '[TRIGGER NF] CHAMADA PROCEDURE QUE INSERE COD. BARRA', 'PRODUTO '||TO_CHAR(IdtProduto)||' LOTE '||TO_CHAR(IdtLote)||' ID RM  '||TO_CHAR(:NEW.IDPRD));
                     RAISE_APPLICATION_ERROR(-20000,'CHAMADA PROCEDURE QUE INSERE COD. BARRA, PRODUTO '||TO_CHAR(IdtProduto)||' LOTE '||TO_CHAR(IdtLote)||' ID RM  '||TO_CHAR(:NEW.IDPRD)||sqlerrm);
                END;*/
                --

                BEGIN
                 -- GERA MOVIMENTO
                 /*VlrUnitario   := NVL(:NEW.VALORUNITARIO,0);
                 IF ( VlrUnitario = 0 OR VlrUnitario IS NULL ) THEN
                    VlrUnitario := NVL(:NEW.PRECOUNITARIO,0);
                    VlrUnitario := VlrUnitario/UnidadeNota;


                    IF ( VlrUnitario = 0 OR VlrUnitario IS NULL ) THEN
                       -- RAISE_APPLICATION_ERROR(-20000,'VALOR EM BRANCO '||TO_CHAR(:NEW.VALORUNITARIO)||TO_CHAR(:NEW.IDPRD));
                       DSADT.EMAIL@PRODUCAO('ricardo.costa@anacosta.com.br', '[TRIGGER NF] VALOR ', 'PRODUTO '||TO_CHAR(IdtProduto)||' VALOR '||TO_CHAR(VlrTeste)||' ID RM  '||TO_CHAR(:NEW.IDPRD)||' NOTA '||TO_CHAR(NotaFiscal));
                    END IF;
                 END IF; */
                 -- CONFORME ORIENTACAO DA NEIDE, AJUSTEI VALOR UNITARIO PEGANDO VALOR FINANCEIRO QUE JA CONTEM TODOS OS IMPOSTOS E DESCONTOS
                 -- RATEADOS
                 VlrUnitario := ( :NEW.VALORFINANCEIRO/Qtde  );
                 -- RAISE_APPLICATION_ERROR(-20000,'EM CIMA DA PROCEDURE '||TO_CHAR(:NEW.VALORUNITARIO)||TO_CHAR(:NEW.IDPRD));
                 --IF (NotaFiscal NOT IN ('2005872') OR (NotaFiscal = '2005872' AND IdtProduto = 3981)) THEN
                 IF (NotaFiscal NOT IN ('0000000')) THEN

                     --IF ( (:NEW.CODCOLIGADA = RM_ESTOQUE_HAC) OR (:NEW.CODCOLIGADA = RM_ESTOQUE_ACS AND TRIM(sTipoMov) != '1.2.48') ) THEN
                     --IF ( TRIM(sTipoMov) != '1.2.48' ) THEN
                          /*IF (NotaFiscal = '999999') THEN
                             RAISE_APPLICATION_ERROR(-20000,' IdtFilial '||TO_CHAR(IdtFilial) ||' SGS_ESTOQUE_HAC '||TO_CHAR(SGS_ESTOQUE_HAC)||' RM_ESTOQUE_ACS '||TO_CHAR(RM_ESTOQUE_ACS)||' sTipoMov '||TO_CHAR(sTipoMov));
                          END IF;*/
                          IF ( :NEW.CODCOLIGADA = RM_ESTOQUE_ACS AND TRIM(sTipoMov) = '1.2.48' ) THEN
                             IdtFilial := SGS_ESTOQUE_ACS;
                          ELSIF (TRIM(sTipoMov) = '1.4.01') THEN
                             IdtFilial := 5; --Estoque Consignado
                             --RAISE_APPLICATION_ERROR(-20000,' IdtFilial 5');
                          END IF;
                          --Se Mov. Bonificac?o e Prot. Ort. Sint, lancar como baixa automatica no estoque
                          IF ( TRIM(sTipoMov) = '1.2.62' AND pGRUPO = '61' ) THEN

                             IF (:NEW.CODCOLIGADA = RM_ESTOQUE_ACS) THEN IdtFilial := SGS_ESTOQUE_ACS; END IF;
                             sTipoMov := '1.2.48';--Lanca como consignado no SGS para dar baixa automatica

                          ELSIF ( TRIM(sTipoMov) = '1.2.62' AND pGRUPO IN ('06','6') AND :NEW.CODCOLIGADA = RM_ESTOQUE_ACS ) THEN
                             -- Material tambem esta liberado para entrar neste movimento para o Plano
                             IdtFilial := SGS_ESTOQUE_ACS;
                             sTipoMov := '1.2.48';--Lanca como consignado no SGS para dar baixa automatica

                          ELSIF ( :NEW.CODCOLIGADA = RM_ESTOQUE_ACS AND TRIM(sTipoMov) NOT IN ('1.2.48','2.2.03') AND pGRUPO != '01' ) THEN

                             --DSADT.EMAIL@PRODUCAO('andre.monaco@anacosta.com.br', '[TRIGGER NF] MATERIAL NA COLIGADA 2 ', 'PRODUTO '||TO_CHAR(IdtProduto)||' ID RM  '||TO_CHAR(:NEW.IDPRD)||' ERRO  '||SQLERRM);
                             RAISE_APPLICATION_ERROR(-20000,'N?O PODE HAVER MATERIAL NA COLIGADA 2 '||sqlerrm);

                          ELSIF ( :NEW.CODCOLIGADA = RM_ESTOQUE_ACS AND TRIM(sTipoMov) != '1.2.48' AND NVL(pFRACIONADO, 0) = 1 ) THEN

                             --DSADT.EMAIL@PRODUCAO('andre.monaco@anacosta.com.br', '[TRIGGER NF] FRACIONADO NA COLIGADA 2 ', 'PRODUTO '||TO_CHAR(IdtProduto)||' ID RM  '||TO_CHAR(:NEW.IDPRD)||' ERRO  '||SQLERRM);
                             RAISE_APPLICATION_ERROR(-20000,'N?O PODE HAVER FRACIONADO NA COLIGADA 2 '||sqlerrm);

                          END IF;
                          IF (sTipoMov != '2.2.03' OR (sTipoMov = '2.2.03' AND pGRUPO NOT IN ('01','1'))) THEN --Nao inserir devolucao de medicamento aqui, tera que ser devolvido manualmente no SGS
                            SGS.PRC_MTMD_MOV_ESTOQUE_ENTRADA@PRODUCAO (  IdtProduto,
                                                                         NULL, --IdtLote,
                                                                         IdtFilial,
                                                                         IdtUnidade,
                                                                         IdtLocal,
                                                                         IdtSetor,
                                                                         Qtde,
                                                                         VlrUnitario,
                                                                         IdtTipoMov,
                                                                         IdtSubTipoMov,
                                                                         NotaFiscal,
                                                                         dDataMov,
                                                                         :NEW.IDMOV,
                                                                         :NEW.CODCOLIGADA,
                                                                         :NEW.NSEQITMMOV,
                                                                         sTipoMov,
                                                                         vNOMEFORNECEDOR,
                                                                         pCODUNDNOTA,
                                                                         sSerie,
                                                                         vQtdCompra,
                                                                         vNUM_AUTORIZA_FORN
                                                                       );
                          END IF;
                     --END IF;
                END IF;
                EXCEPTION
                   WHEN OTHERS THEN
                       --DSADT.EMAIL@PRODUCAO('andre.monaco@anacosta.com.br', '[TRIGGER NF] ENTRADA ESTOQUE UPDATING', 'PRODUTO '||TO_CHAR(IdtProduto)||' ID RM  '||TO_CHAR(:NEW.IDPRD)||' ERRO  '||SQLERRM);
                       RAISE_APPLICATION_ERROR(-20000,'CHAMADA PROCEDURE ENTRADA ESTOQUE '||sqlerrm);
                END;
              ELSIF INSERTING THEN
               -- N?O PODE EXISTIR OS DOIS TIPOS INSERTING E UPDATING
               -- A RM REALIZA OS DOIS TIPO E DUPLICA ITENS NA BASE SGS
               NULL;
              END IF; -- TESTE INSERTING / UPDATE
            ELSE
               RAISE_APPLICATION_ERROR(-20000,'SEM FILIAL');
            END IF; -- TESTE FILIAL
         END IF; -- FIM IF CONTROLE DE ESTOQUE
         -- RAISE_APPLICATION_ERROR(-20000,'CONTROLE DE ESTOQUE '||TO_CHAR(:NEW.VALORUNITARIO)||TO_CHAR(:NEW.IDPRD));

     END IF; -- FIM IF TIPO
   ELSIF ( sStatus IN ('N','F') AND DELETING ) THEN
--    ELSIF ( sStatus IN ('F') AND DELETING ) THEN
      IF ( sTipo = 'P' AND DELETING ) THEN
         IF ( sControlaEstoque = 'A' ) THEN
            IdtTipoMov    := 2; -- SAIDA
            IdtSubTipoMov := 15; -- ESTORNO NF
            IF ( :NEW.CODCOLIGADA = RM_ESTOQUE_HAC ) THEN
               IdtFilial := SGS_ESTOQUE_HAC;
            ELSIF ( :NEW.CODCOLIGADA = RM_ESTOQUE_ACS ) THEN
               IdtFilial := SGS_ESTOQUE_ACS;
            ELSE
               -- IdtFilial := SGS_ESTOQUE_TODOS;
               IdtFilial := SGS_ESTOQUE_HAC;
               -- RAISE_APPLICATION_ERROR(-20000,'ERRO SELECIONANDO FILIAL '||SQLERRM);
            END IF;
            IF ( IdtFilial IS NOT NULL ) THEN
              -- BUSCA INFORMAC?O DENTRO DO SGS

               -- BUSCA PRODUTO
               BEGIN
                  SELECT PRODUTO.cad_mtmd_id,
                         PRODUTO.cad_mtmd_unidade_compra,
                         PRODUTO.TIS_MED_CD_TABELAMEDICA
                  INTO   IdtProduto,
                         UnidadeCompra,
                         TipoProduto
                  -- FROM SGS.TB_CAD_MTMD_MAT_MED@SGSDEV PRODUTO
                  FROM SGS.TB_CAD_MTMD_MAT_MED@PRODUCAO PRODUTO
                  --WHERE PRODUTO.CAD_MTMD_CD_RM = :OLD.IDPRD;
                  WHERE TRIM(PRODUTO.CAD_MTMD_CODMNE) = TRIM(pCODIGOPRD);
                  IF ( TipoProduto = 95 ) THEN
                     -- E MATERIAL AJUSTA FILIAL PARA HAC
                     IdtFilial := SGS_ESTOQUE_HAC;
                  END IF;
               EXCEPTION
                 WHEN TOO_MANY_ROWS THEN
                      RAISE_APPLICATION_ERROR(-20000,'PRODUTO');
                 WHEN NO_DATA_FOUND THEN
                      -- DSADT.EMAIL@PRODUCAO('ricardo.costa@anacosta.com.br', 'Produto nao cadastrado DELETANDO',' ID RM '||TO_CHAR(:OLD.IDPRD));
                      -- RAISE_APPLICATION_ERROR(-20000,'PRODUTO NO_DATA_FOUND '||TO_CHAR(:OLD.IDPRD));
                       SGS.PRC_CAD_MTMD_MAT_MED_I@PRODUCAO ( pGRUPO, -- GRUPO
                       -- SGS.PRC_CAD_MTMD_MAT_MED_I@SGSDEV ( pGRUPO, -- GRUPO
                                                    pSUBGRUPO,
                                                    NomeFantasia,
                                                    pDESCRICAO,
                                                    pCODFAB,
                                                    pFRACIONADO,
                                                    1, -- ATIVO
                                                    IDTPRODUTO_RM,
                                                    pCONTROLADOPORLOTE,
                                                    pCODUNDCONTROLE,
                                                    pCODUNDVENDA,
                                                    pCODUNDCOMPRA,
                                                    pCODIGOPRD,
                                                    vGOTAS,
                                                    IdtProduto
                                                  );
                       BEGIN
                           SELECT PRODUTO.cad_mtmd_id,
                                  -- PRODUTO.cad_mtmd_unidade_compra,
                                  PRODUTO.TIS_MED_CD_TABELAMEDICA
                           INTO   IdtProduto,
                                  -- UnidadeCompra,
                                  TipoProduto
                           FROM SGS.TB_CAD_MTMD_MAT_MED@PRODUCAO PRODUTO
                           -- FROM SGS.TB_CAD_MTMD_MAT_MED@SGSDEV PRODUTO
                           -- WHERE PRODUTO.CAD_MTMD_CD_RM = :OLD.IDPRD;
                           WHERE TRIM(PRODUTO.CAD_MTMD_CODMNE) = TRIM(pCODIGOPRD);
                           IF ( TipoProduto = 95 ) THEN
                              -- E MATERIAL AJUSTA FILIAL PARA HAC
                              IdtFilial := SGS_ESTOQUE_HAC;
                           END IF;
                       EXCEPTION WHEN NO_DATA_FOUND THEN
                         -- DSADT.EMAIL@PRODUCAO('andre.monaco@anacosta.com.br', '[TRIGGER NF]Produto nao cadastrado DELETANDO TENTATIVA 2',' ID RM '||TO_CHAR(:OLD.IDPRD));
                         RAISE_APPLICATION_ERROR(-20000,'Produto nao cadastrado DELETANDO TENTATIVA 2');
                       END;
                 WHEN OTHERS THEN
                      RAISE_APPLICATION_ERROR(-20000,'PRODUTO '||sqlerrm);
               END;
               Qtde := (:OLD.QUANTIDADE * UnidadeNota );
              IF (Qtde = 0 OR Qtde IS NULL ) THEN
                 RAISE_APPLICATION_ERROR(-20000,' N?O TEM QUANTIDADE (DELETANDO) PRODUTO '||TO_CHAR(IdtProduto) ||' QTDE '||TO_CHAR(Qtde)||' UnidadeCompra '||TO_CHAR(UnidadeCompra));
              END IF;
             IF ( NotaFiscal IN ('123456')) THEN
               SGS.PRC_MTMD_MOV_ESTOQUE_ESTORNONF@PRODUCAO( IdtProduto,    -- OK
               -- SGS.PRC_MTMD_MOV_ESTOQUE_ESTORNONF@SGSDEV( IdtProduto,    -- OK
                                                  IdtFilial,     -- OK
                                                  IdtUnidade,    --
                                                  IdtLocal,      -- OK
                                                  IdtSetor,      --
                                                  Qtde,          -- OK
                                                  VlrUnitario,   -- OK
                                                  IdtTipoMov,    -- OK
                                                  IdtSubTipoMov, -- OK
                                                  NotaFiscal,
                                                  dDataMov,
                                                  :OLD.IDMOV,
                                                  :OLD.CODCOLIGADA,
                                                  :OLD.NSEQITMMOV,
                                                  sTipoMov,
                                                  sSerie
                                               );
             END IF;
            END IF; -- TESTE FILIAL
         END IF; -- CONTROLE DE ESTOQUE DELETING
      END IF; -- sTipo and deleting
   END IF;  -- STATUS UPDATING
   -- RAISE_APPLICATION_ERROR(-20000,'ULTIMO TESTE '||sStatus||' TIPO '||sTipo);

--END IF;

END;