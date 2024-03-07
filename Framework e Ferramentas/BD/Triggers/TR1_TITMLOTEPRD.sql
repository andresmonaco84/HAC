CREATE OR REPLACE TRIGGER TR1_TITMLOTEPRD
 AFTER
  INSERT OR UPDATE OR DELETE
 ON RM.TITMLOTEPRD
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
vIdLoteRm          TLOTEPRD.idlote%TYPE;
vCodLote           TLOTEPRD.NUMLOTE%TYPE;
vNumLoteFabricante TLOTEPRD.NUMLOTEFABRICANTE%TYPE;
vDataValidade      TLOTEPRD.DATAVALIDADE%TYPE;
vDataEntrada       TLOTEPRD.DATAENTRADA%TYPE;
vDataFabricacao    TLOTEPRD.DATAFABRICACAO%TYPE;
vIdPrd             TPRODUTO.IDPRD%TYPE;
vControlaLote      TPRODUTO.CONTROLADOPORLOTE%TYPE;
vCodigoPrd         TPRODUTO.CODIGOPRD%TYPE;
vIdMov             TMOV.IDMOV%TYPE;
vNumNF             TMOV.NUMEROMOV%TYPE;
vCODTMV            TMOV.CODTMV%TYPE;
vMTMD_IDLOTE_RM    INTEGER;
vCAD_UNI_ID_UNIDADE INTEGER;
vCAD_LAT_ID_LOCAL_ATENDIMENTO INTEGER;
vCAD_SET_ID        INTEGER;
vMTMD_MOV_ID_SGS   NUMBER(10);
vMTMD_MOV_ID_NOVO  NUMBER(10);
vIdMtmdSGS         NUMBER;
vIdLoteSGS         NUMBER;
vExisteSGS         NUMBER;
vMTMD_MOV_ESTOQUE_ATUAL NUMBER;
vIdLoteExisteMovSGS  NUMBER;
vQtdLoteExisteMovSGS NUMBER;
vQtdLoteSGS        NUMBER;
vQtdTotalNfSGS     NUMBER;
vNovaQtdLote       NUMBER;
vQtdJaInseridaNF   NUMBER;
vCodFabricante     VARCHAR(15);
vDataMov           DATE;
vDataLoteSGS       DATE;
vUnidadeNota       SGS.TB_CAD_MTMD_MAT_MED.CAD_MTMD_UNIDADE_COMPRA@PRODUCAO%TYPE;
vCAD_MTMD_GRUPO_ID SGS.TB_CAD_MTMD_MAT_MED.CAD_MTMD_GRUPO_ID@PRODUCAO%TYPE;
vCAD_MTMD_SUBGRUPO_ID SGS.TB_CAD_MTMD_MAT_MED.CAD_MTMD_SUBGRUPO_ID@PRODUCAO%TYPE;
vMTMD_CUSTO_MEDIO  SGS.TB_MTMD_ESTOQUE_CONTABIL.MTMD_CUSTO_MEDIO@PRODUCAO%type;
BEGIN
--IF(:NEW.IDMOV = 5388292) THEN RETURN; END IF;
IF ((:NEW.IDMOV IS NOT NULL AND :NEW.IDLOTE IS NOT NULL) OR DELETING) THEN
  SELECT LOTE.IDLOTE,       LOTE.NUMLOTEFABRICANTE,   LOTE.DATAVALIDADE,
         LOTE.DATAENTRADA,  LOTE.DATAFABRICACAO,      LOTE.IDPRD,
         PRODUTO.CODIGOPRD, PRODUTO.CONTROLADOPORLOTE,LOTE.NUMLOTE
    INTO vIdLoteRm,         vNumLoteFabricante,       vDataValidade,
         vDataEntrada,      vDataFabricacao,          vIdPrd,
         vCodigoPrd,        vControlaLote,            vCodLote
   FROM TLOTEPRD LOTE JOIN TPRODUTO PRODUTO
        ON (LOTE.CODCOLIGADA = PRODUTO.CODCOLPRD AND LOTE.IDPRD = PRODUTO.IDPRD)
  WHERE LOTE.CODCOLIGADA = NVL(:NEW.CODCOLIGADA,:OLD.CODCOLIGADA)
    AND LOTE.IDLOTE      = NVL(:NEW.IDLOTE,:OLD.IDLOTE);

  SELECT CODTMV INTO vCODTMV
    FROM TMOV
   WHERE IDMOV = NVL(:NEW.IDMOV,:OLD.IDMOV)
   AND   CODCOLIGADA = NVL(:NEW.CODCOLIGADA,:OLD.CODCOLIGADA);

  SELECT PRODUTO.CAD_MTMD_ID, PRODUTO.CAD_MTMD_CD_FABRICANTE, PRODUTO.CAD_MTMD_GRUPO_ID
    INTO vIdMtmdSGS,          vCodFabricante,                 vCAD_MTMD_GRUPO_ID
    FROM SGS.TB_CAD_MTMD_MAT_MED@PRODUCAO PRODUTO
    WHERE TRIM(PRODUTO.CAD_MTMD_CODMNE) = TRIM(vCodigoPrd);

  IF (vControlaLote = 1) THEN
      SELECT COUNT(H.CAD_MTMD_ID)
        INTO vExisteSGS
       FROM SGS.TB_MTMD_HISTORICO_NOTA_FISCAL@PRODUCAO H
       WHERE H.CAD_MTMD_ID        = vIdMtmdSGS AND
             H.CAD_MTMD_FILIAL_ID = NVL(:NEW.CODCOLIGADA,:OLD.CODCOLIGADA) AND
             H.IDMOV              = NVL(:NEW.IDMOV,:OLD.IDMOV);
      vIdMov := NVL(:NEW.IDMOV,:OLD.IDMOV);
      IF ( vExisteSGS = 0 ) THEN --Nao existe no SGS com o mesmo IDMOV, NF pode ter sido excluida e trocado o IDMOV, verificar para atualizar LOTE
         SELECT T.NUMEROMOV INTO vNumNF
           FROM TMOV T
          WHERE T.CODCOLIGADA = NVL(:NEW.CODCOLIGADA,:OLD.CODCOLIGADA) AND
                T.IDMOV = vIdMov;
         SELECT COUNT(H.CAD_MTMD_ID)
          INTO vExisteSGS
          FROM SGS.TB_MTMD_HISTORICO_NOTA_FISCAL@PRODUCAO H
         WHERE H.CAD_MTMD_ID        = vIdMtmdSGS AND
               H.CAD_MTMD_FILIAL_ID = NVL(:NEW.CODCOLIGADA,:OLD.CODCOLIGADA) AND
               H.MTMD_NR_NOTA       = vNumNF;
         IF ( vExisteSGS > 0 ) THEN
            SELECT H.IDMOV INTO vIdMov
             FROM SGS.TB_MTMD_HISTORICO_NOTA_FISCAL@PRODUCAO H
             WHERE H.CAD_MTMD_ID        = vIdMtmdSGS AND
                   H.CAD_MTMD_FILIAL_ID = NVL(:NEW.CODCOLIGADA,:OLD.CODCOLIGADA) AND
                   H.MTMD_NR_NOTA       = vNumNF;
         END IF;
      END IF;
      IF INSERTING THEN
        BEGIN
          SELECT MTMD_DATA_ATUALIZADO, MTMD_IDLOTE_RM
            INTO  vDataLoteSGS,        vMTMD_IDLOTE_RM
            FROM SGS.TB_MTMD_LOTEST_LOTE_ESTOQUE@PRODUCAO LOTE
           WHERE LOTE.CAD_MTMD_FILIAL_ID  = NVL(:NEW.CODCOLIGADA,:OLD.CODCOLIGADA)
           AND   LOTE.IDMOV               = vIdMov
           AND   LOTE.CAD_MTMD_ID         = vIdMtmdSGS AND ROWNUM = 1;
           --Esta inserindo um novo lote para um item ja existente na mesma NF no SGS
           --Verifica esta Data porque um item pode entrar em mais de um lote na mesma NF quando inserida tudo junto ao mesmo tempo
           IF (SYSDATE > vDataLoteSGS+0.0003 AND vIdMov NOT IN(00)) THEN
              IF ( vExisteSGS > 0 AND vMTMD_IDLOTE_RM <> vIdLoteRm AND vNumNF NOT IN('00')) THEN
                BEGIN
                  SELECT MTMD_DATA_ATUALIZADO, MTMD_IDLOTE_RM
                    INTO  vDataLoteSGS,        vMTMD_IDLOTE_RM
                    FROM SGS.TB_MTMD_LOTEST_LOTE_ESTOQUE@PRODUCAO LOTE
                   WHERE LOTE.CAD_MTMD_FILIAL_ID  = NVL(:NEW.CODCOLIGADA,:OLD.CODCOLIGADA)
                   AND   LOTE.IDMOV               = vIdMov
                   AND   LOTE.CAD_MTMD_ID         = vIdMtmdSGS AND MTMD_IDLOTE_RM = vIdLoteRm;
                EXCEPTION
                  WHEN NO_DATA_FOUND THEN
                    RAISE_APPLICATION_ERROR(-20000,'LOTE JA INSERIDO PARA ESTE ITEM NO SGS, NO CASO DE TROCA DE LOTE SOLICITE A EXCLUSAO DO MESMO DO ESTOQUE. IDMOV SGS '
                                             ||TO_CHAR(vIdMov)||' PRODUTO RM '||TO_CHAR(vIdPrd)||
                                             ' ID LOTE RM '||TO_CHAR(vIdLoteRm)||' '||sqlerrm );
                END;
              ELSE
                RETURN; --Item ja OK no SGS, nao precisa inserir novamente
              END IF;
           END IF;
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
            NULL;
          WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-20000,sqlerrm);
        END;
      END IF;
      IF ( vExisteSGS > 0 ) THEN
        BEGIN
           SELECT MTMD_LOTEST_ID
             INTO vIdLoteSGS
             FROM SGS.TB_MTMD_LOTEST_LOTE_ESTOQUE@PRODUCAO LOTE
            WHERE LOTE.CAD_MTMD_FILIAL_ID  = NVL(:NEW.CODCOLIGADA,:OLD.CODCOLIGADA)
            AND   LOTE.IDMOV               = vIdMov
            AND   LOTE.MTMD_IDLOTE_RM      = vIdLoteRm
            AND   LOTE.CAD_MTMD_ID         = vIdMtmdSGS;
           /*IF DELETING THEN
              DELETE TB_MTMD_LOTEST_LOTE_ESTOQUE@PRODUCAO
              WHERE CAD_MTMD_FILIAL_ID  = :OLD.CODCOLIGADA
              AND   IDMOV               = :OLD.IDMOV
              AND   MTMD_IDLOTE_RM      = vIdLoteRm
              AND   CAD_MTMD_ID         = vIdMtmdSGS;*/
           UPDATE TB_MTMD_LOTEST_LOTE_ESTOQUE@PRODUCAO
           SET    MTMD_NUM_LOTE        = TRIM(vNumLoteFabricante),
                  MTMD_COD_LOTE        = vCodLote,
                  MTMD_DT_VALIDADE     = vDataValidade,
                  MTMD_DT_ENTRADA      = vDataEntrada,
                  MTMD_DT_FABRICACAO   = vDataFabricacao,
                  MTMD_QTDE            = :NEW.QUANTIDADE2,
                  CAD_MTMD_CD_FABRICANTE = vCodFabricante,
                  MTMD_DATA_ATUALIZADO = SYSDATE
           WHERE CAD_MTMD_FILIAL_ID  = :NEW.CODCOLIGADA
           AND   IDMOV               = vIdMov
           AND   MTMD_IDLOTE_RM      = vIdLoteRm
           AND   CAD_MTMD_ID         = vIdMtmdSGS;
        EXCEPTION
           WHEN NO_DATA_FOUND THEN
              IF (INSERTING OR UPDATING) THEN
                SELECT SGS.SEQ_MTMD_LOTE.NEXTVAL@PRODUCAO INTO vIdLoteSGS FROM DUAL;
                BEGIN
                  INSERT INTO SGS.TB_MTMD_LOTEST_LOTE_ESTOQUE@PRODUCAO
                  ( MTMD_LOTEST_ID,       CAD_MTMD_ID,            MTMD_NUM_LOTE,
                    MTMD_DT_VALIDADE,     MTMD_DT_ENTRADA,        MTMD_DT_FABRICACAO,
                    MTMD_IDLOTE_RM,       MTMD_DATA_ATUALIZADO,   CAD_MTMD_FILIAL_ID,
                    IDMOV,                MTMD_QTDE,              CAD_MTMD_CD_FABRICANTE,
                    MTMD_CONTROLA_LOTEST, MTMD_COD_LOTE
                  )
                  VALUES
                  ( vIdLoteSGS,           vIdMtmdSGS,            TRIM(vNumLoteFabricante),
                    vDataValidade,        vDataEntrada,          vDataFabricacao,
                    vIdLoteRm,            SYSDATE,               :NEW.CODCOLIGADA,
                    vIdMov,               :NEW.QUANTIDADE2,      vCodFabricante,
                    1,                    vCodLote
                  );
                EXCEPTION
                   WHEN OTHERS THEN
                      RAISE_APPLICATION_ERROR(-20000,'ERRO AO INSERIR LOTE SGS '||TO_CHAR(vIdLoteSGS)||' PRODUTO RM '||TO_CHAR(vIdPrd)||
                                                     ' ID LOTE RM '||TO_CHAR(vIdLoteRm)||' '||sqlerrm );
                END;
              END IF;
        END;
        --Atualiza LOTE de medicamento quando nao for devolucao
        IF ( vCAD_MTMD_GRUPO_ID = 1 AND NOT DELETING AND vCODTMV != '2.2.03') THEN
          IF (vCodLote IS NULL) THEN
             RAISE_APPLICATION_ERROR(-20000,' NUMERO DO LOTE OBRIGATORIO ');
          END IF;

          IF (UPDATING AND NVL(:OLD.QUANTIDADE2,0) <> :NEW.QUANTIDADE2) THEN
             RAISE_APPLICATION_ERROR(-20000,' ALTERACAO DE QTD. DE LOTE NAO PERMITIDA, FAVOR SOLICITAR EXCLUSAO DA NF NO SGS ');
          END IF;

          SELECT H.MTMD_MOV_ID,    H.MTMD_QTDE
            INTO vMTMD_MOV_ID_SGS, vQtdTotalNfSGS
            FROM SGS.TB_MTMD_HISTORICO_NOTA_FISCAL@PRODUCAO H
           WHERE H.CAD_MTMD_ID        = vIdMtmdSGS AND
                 H.CAD_MTMD_FILIAL_ID = NVL(:NEW.CODCOLIGADA,:OLD.CODCOLIGADA) AND
                 H.IDMOV              = vIdMov;

          BEGIN
            SELECT CAD_UNI_ID_UNIDADE, CAD_LAT_ID_LOCAL_ATENDIMENTO,  CAD_SET_ID,       MTMD_MOV_DATA,
                   CAD_MTMD_GRUPO_ID,  CAD_MTMD_SUBGRUPO_ID,          MTMD_CUSTO_MEDIO, MTMD_MOV_ESTOQUE_ATUAL
              INTO vCAD_UNI_ID_UNIDADE,vCAD_LAT_ID_LOCAL_ATENDIMENTO, vCAD_SET_ID,      vDataMov,
                   vCAD_MTMD_GRUPO_ID, vCAD_MTMD_SUBGRUPO_ID,         vMTMD_CUSTO_MEDIO,vMTMD_MOV_ESTOQUE_ATUAL
              FROM TB_MTMD_MOV_MOVIMENTACAO@PRODUCAO M
             WHERE MTMD_MOV_ID = vMTMD_MOV_ID_SGS;
          EXCEPTION WHEN NO_DATA_FOUND THEN
            RAISE_APPLICATION_ERROR(-20000,'ERRO AO ATUALIZAR LOTE SGS (MOVIMENTO ENTRADA NF NAO ENCONTRADO) '||TO_CHAR(vIdLoteSGS)||' PRODUTO RM '||TO_CHAR(vIdPrd)||
                                             ' ID LOTE RM '||TO_CHAR(vIdLoteRm)||' '||sqlerrm );
          END;

          SELECT UNIDADE.FATORCONVERSAO
            INTO vUnidadeNota
            FROM TITMMOV TTM JOIN
                 TUND UNIDADE ON UNIDADE.CODUND = TTM.CODUND
           WHERE TTM.CODCOLIGADA = :NEW.CODCOLIGADA AND
                 TTM.IDMOV       = :NEW.IDMOV AND
                 TTM.IDPRD       = vIdPrd;

          IF INSERTING THEN
             vQtdLoteSGS := :NEW.QUANTIDADE2 * vUnidadeNota;
          ELSE
             vQtdLoteSGS := (:NEW.QUANTIDADE2 - NVL(:OLD.QUANTIDADE2,0)) * vUnidadeNota;
          END IF;

          BEGIN
            INSERT INTO SGS.TB_MTMD_ESTOQUE_LOTE@PRODUCAO
            ( MTMD_COD_LOTE,            CAD_MTMD_ID,            CAD_SET_ID,
              CAD_MTMD_FILIAL_ID,       MTMD_EST_QTDE,          MTMD_DATA_ATUALIZADO
            )
            VALUES
            ( TRIM(vCodLote),           vIdMtmdSGS,             vCAD_SET_ID,
              :NEW.CODCOLIGADA,         vQtdLoteSGS,            SYSDATE
            );
          EXCEPTION WHEN DUP_VAL_ON_INDEX THEN
            IF (vQtdLoteSGS > 0) THEN
              UPDATE SGS.TB_MTMD_ESTOQUE_LOTE@PRODUCAO
                 SET MTMD_EST_QTDE = MTMD_EST_QTDE + vQtdLoteSGS,
                     MTMD_DATA_ATUALIZADO = SYSDATE
               WHERE MTMD_COD_LOTE = TRIM(vCodLote) AND
                     CAD_MTMD_ID    = vIdMtmdSGS AND
                     CAD_SET_ID     = vCAD_SET_ID AND
                     CAD_MTMD_FILIAL_ID = :NEW.CODCOLIGADA;
            END IF;
          END;

          SELECT MTMD_EST_QTDE INTO vNovaQtdLote
               FROM SGS.TB_MTMD_ESTOQUE_LOTE@PRODUCAO
              WHERE MTMD_COD_LOTE = TRIM(vCodLote) AND
                    CAD_MTMD_ID    = vIdMtmdSGS AND
                    CAD_SET_ID     = vCAD_SET_ID AND
                    CAD_MTMD_FILIAL_ID = :NEW.CODCOLIGADA;
          IF (vNovaQtdLote < 0) THEN
             RAISE_APPLICATION_ERROR(-20000,'SALDO DO LOTE NAO PODE FICAR NEGATIVO NO SGS. ID_LOTE SGS '
                                             ||TO_CHAR(vIdLoteSGS)||' PRODUTO RM '||TO_CHAR(vIdPrd)||
                                             ' ID LOTE RM '||TO_CHAR(vIdLoteRm)||' '||sqlerrm );
          END IF;

          UPDATE SGS.TB_MTMD_MOV_MOVIMENTACAO@PRODUCAO
          SET MTMD_MOV_QTDE  = vQtdLoteSGS,
              MTMD_LOTEST_ID = vIdLoteSGS,
              MTMD_COD_LOTE  = TRIM(vCodLote),
              MTMD_MOV_SALDO_LOTE_SETOR = vNovaQtdLote,
              MTMD_MOV_SALDO_LOTE_TOTAL = (SELECT NVL(SUM(MTMD_EST_QTDE),0)
                                             FROM SGS.TB_MTMD_ESTOQUE_LOTE@PRODUCAO
                                            WHERE MTMD_COD_LOTE = TRIM(vCodLote) AND
                                                  CAD_MTMD_ID   = vIdMtmdSGS AND
                                                  CAD_MTMD_FILIAL_ID = :NEW.CODCOLIGADA)
          WHERE MTMD_MOV_ID = vMTMD_MOV_ID_SGS AND MTMD_MOV_SALDO_LOTE_SETOR IS NULL;

          --Se mesmo item tiver mais de 1 lote na mesma NF, inserir movimentacao de lote que nao entrou originalmente para rastreio
          IF (vQtdTotalNfSGS <> vQtdLoteSGS) THEN
            
            UPDATE SGS.TB_MTMD_MOV_MOVIMENTACAO@PRODUCAO
            SET MTMD_MOV_ESTOQUE_ATUAL = (vMTMD_MOV_ESTOQUE_ATUAL - vQtdTotalNfSGS + vQtdLoteSGS)
            WHERE MTMD_MOV_ID = vMTMD_MOV_ID_SGS AND MTMD_LOTEST_ID = vIdLoteSGS;

            BEGIN
              SELECT MOV.MTMD_LOTEST_ID
                INTO vIdLoteExisteMovSGS
                FROM SGS.TB_MTMD_MOV_MOVIMENTACAO@PRODUCAO MOV JOIN
                     SGS.TB_MTMD_HISTORICO_NOTA_FISCAL@PRODUCAO NF ON NF.MTMD_MOV_ID = MOV.MTMD_MOV_ID
               WHERE MOV.CAD_MTMD_TPMOV_ID = 1 AND MOV.CAD_MTMD_SUBTP_ID = 1 AND
                     MOV.MTMD_MOV_DATA >= SYSDATE-30 AND
                     MOV.CAD_MTMD_ID = vIdMtmdSGS AND
                     MOV.MTMD_LOTEST_ID = vIdLoteSGS AND
                     NF.IDMOV = vIdMov;
            EXCEPTION WHEN NO_DATA_FOUND THEN
              vIdLoteExisteMovSGS := 0;
            END;

            IF (vIdLoteExisteMovSGS <> vIdLoteSGS) THEN
              BEGIN                
                SELECT NVL(SUM(LOTE.MTMD_QTDE),0) 
                  INTO vQtdJaInseridaNF
                  FROM SGS.TB_MTMD_LOTEST_LOTE_ESTOQUE@PRODUCAO LOTE
                 WHERE LOTE.CAD_MTMD_FILIAL_ID  = NVL(:NEW.CODCOLIGADA,:OLD.CODCOLIGADA) AND
                       LOTE.CAD_MTMD_ID = vIdMtmdSGS AND
                       LOTE.IDMOV = vIdMov;
                       
                vQtdJaInseridaNF := vQtdJaInseridaNF * vUnidadeNota;
                       
                SELECT MOV.MTMD_MOV_QTDE
                  INTO vQtdLoteExisteMovSGS
                  FROM SGS.TB_MTMD_MOV_MOVIMENTACAO@PRODUCAO MOV JOIN
                       SGS.TB_MTMD_HISTORICO_NOTA_FISCAL@PRODUCAO NF ON NF.MTMD_MOV_ID = MOV.MTMD_MOV_ID
                 WHERE MOV.CAD_MTMD_TPMOV_ID = 1 AND MOV.CAD_MTMD_SUBTP_ID = 1 AND
                       MOV.MTMD_MOV_DATA >= SYSDATE-30 AND
                       MOV.CAD_MTMD_ID = vIdMtmdSGS AND
                       NF.IDMOV = vIdMov;
                       
                vMTMD_MOV_ESTOQUE_ATUAL := vMTMD_MOV_ESTOQUE_ATUAL - vQtdLoteExisteMovSGS + vQtdJaInseridaNF;
              
                SELECT SGS.SEQ_MTMD_MOVIMENTACAO.NEXTVAL@PRODUCAO INTO vMTMD_MOV_ID_NOVO FROM DUAL;
                INSERT INTO SGS.TB_MTMD_MOV_MOVIMENTACAO@PRODUCAO
                (
                   MTMD_MOV_ID,
                   CAD_LAT_ID_LOCAL_ATENDIMENTO,
                   CAD_UNI_ID_UNIDADE,
                   CAD_SET_ID,
                   MTMD_LOTEST_ID,
                   CAD_MTMD_ID,
                   CAD_MTMD_TPMOV_ID,
                   CAD_MTMD_SUBTP_ID,
                   MTMD_MOV_DATA,
                   MTMD_MOV_QTDE,
                   MTMD_MOV_FL_FINALIZADO,
                   CAD_MTMD_FILIAL_ID,
                   SEG_USU_ID_USUARIO,
                   MTMD_MOV_ESTOQUE_ATUAL,
                   MTMD_MOV_FL_ESTORNO,
                   MTMD_MOV_FL_FATURADO,
                   CAD_MTMD_GRUPO_ID,
                   CAD_MTMD_SUBGRUPO_ID,
                   MTMD_CUSTO_MEDIO,
                   MTMD_COD_LOTE,
                   MTMD_MOV_SALDO_LOTE_SETOR,
                   MTMD_MOV_SALDO_LOTE_TOTAL
                )
                VALUES
                (
                  vMTMD_MOV_ID_NOVO,
                  vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                  vCAD_UNI_ID_UNIDADE,
                  vCAD_SET_ID,
                  vIdLoteSGS,
                  vIdMtmdSGS,
                  1,
                  1,
                  vDataMov,
                  vQtdLoteSGS,
                  1,
                  :NEW.CODCOLIGADA,
                  1,
                  vMTMD_MOV_ESTOQUE_ATUAL,
                  0,
                  0,
                  vCAD_MTMD_GRUPO_ID,
                  vCAD_MTMD_SUBGRUPO_ID,
                  vMTMD_CUSTO_MEDIO,
                  TRIM(vCodLote),
                  vNovaQtdLote,
                  (SELECT NVL(SUM(MTMD_EST_QTDE),0)
                     FROM SGS.TB_MTMD_ESTOQUE_LOTE@PRODUCAO
                    WHERE MTMD_COD_LOTE = TRIM(vCodLote) AND
                          CAD_MTMD_ID   = vIdMtmdSGS AND
                          CAD_MTMD_FILIAL_ID = :NEW.CODCOLIGADA)
                );
              EXCEPTION WHEN OTHERS THEN
                 RAISE_APPLICATION_ERROR(-20005,' ERRO AO INSERIR MOV SGS VIA INTERFACE RM ');
              END;
            END IF;
          END IF;
        END IF;
      END IF;
  END IF;
END IF;
END;