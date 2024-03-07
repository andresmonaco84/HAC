CREATE OR REPLACE PROCEDURE PRC_MTMD_IMPORTA_INVENT_MED
(
     pCAD_UNI_ID_UNIDADE           IN TB_MTMD_ESTOQUE_LOCAL.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_ESTOQUE_LOCAL.CAD_LAT_ID_LOCAL_ATENDIMENTO%type DEFAULT NULL,
     pCAD_SET_ID                   IN TB_MTMD_ESTOQUE_LOCAL.CAD_SET_ID%type,
     pSEG_USU_ID_USUARIO           IN TB_MTMD_MOV_MOVIMENTACAO.SEG_USU_ID_USUARIO%TYPE,
     pCAD_MTMD_FILIAL_ID           IN TB_MTMD_ESTOQUE_LOCAL.CAD_MTMD_FILIAL_ID%TYPE,
     pMTMD_MOV_DATA                IN DATE,
     pCAD_MTMD_GRUPO_ID            IN TB_CAD_MTMD_INVENTARIO_FECHA.CAD_MTMD_GRUPO_ID%type DEFAULT NULL
) IS
 /********************************************************************
  *    Procedure: PRC_MTMD_IMPORTA_INVENTARIO
  *
  *    Data Criacao: 10/2018        Por: Andre
  *
  *    Funcao: Importa dados do inventario de medicamentos p/ o estoque
  *******************************************************************/
   vMTMD_LOTEST_ID    TB_MTMD_LOTEST_LOTE_ESTOQUE.MTMD_LOTEST_ID%TYPE;
   vMTMD_CONTROLA_LOTEST TB_MTMD_LOTEST_LOTE_ESTOQUE.MTMD_CONTROLA_LOTEST%TYPE;
   vMTMD_ID_ORIGINAL  TB_CAD_MTMD_MAT_MED.CAD_MTMD_ID%TYPE;
   vCAD_MTMD_ANDAMENTO TB_CAD_MTMD_INVENTARIO_FECHA.CAD_MTMD_ANDAMENTO%TYPE;
   vCAD_MTMD_TPMOV_ID TB_CAD_MTMD_SUBTP_MOVIMENTACAO.CAD_MTMD_TPMOV_ID%TYPE;
   vCAD_MTMD_SUBTP_ID TB_CAD_MTMD_SUBTP_MOVIMENTACAO.CAD_MTMD_SUBTP_ID%TYPE;
   vNewIdt            NUMBER;
   --vQTDECONTABIL      NUMBER;
   nEXISTE            NUMBER;
   sMsgEmail          LONG;
   sTitulo            VARCHAR2(20);
   erro               BOOLEAN := false;
   nPercConsumo       NUMBER;
BEGIN
   -- VERIFICA SE EXISTE DATA PASSADA PARA IMPORTAR
   BEGIN
      SELECT COUNT(1)
      INTO   nEXISTE
      FROM TB_CAD_MTMD_INVENTARIO INV
      WHERE TRUNC(INV.CAD_MTMD_DT_INVENTARIO) = TRUNC(pMTMD_MOV_DATA)
      AND   INV.CAD_SET_ID                    = pCAD_SET_ID
      AND   INV.CAD_MTMD_FILIAL_ID            = pCAD_MTMD_FILIAL_ID
    --  AND   NVL(INV.CAD_MTMD_QTDE_FINAL, 0)   > 0
      AND   INV.MTMD_COD_LOTE IS NOT NULL;
      IF ( nEXISTE = 0 ) THEN
         RAISE_APPLICATION_ERROR(-20000,' NAO EXISTE NADA PARA IMPORTAR NESTA DATA  ');
      END IF;
   END;
   SELECT CAD_MTMD_ANDAMENTO INTO vCAD_MTMD_ANDAMENTO
     FROM TB_CAD_MTMD_INVENTARIO_FECHA
    WHERE CAD_MTMD_DT_INVENTARIO = pMTMD_MOV_DATA
      AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
      AND (pCAD_MTMD_GRUPO_ID IS NULL OR CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID)
      AND CAD_SET_ID = pCAD_SET_ID AND ROWNUM = 1;
   --INATIVA PARA PODER REALIZAR MOVIMENTAC?O
   UPDATE TB_CAD_MTMD_INVENTARIO_FECHA SET CAD_MTMD_ANDAMENTO = 0
    WHERE CAD_MTMD_DT_INVENTARIO = pMTMD_MOV_DATA
      AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
      AND (pCAD_MTMD_GRUPO_ID IS NULL OR CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID)
      AND CAD_SET_ID = pCAD_SET_ID;
   -- INATIVA TODOS OS ITENS DO SETOR
   sMsgEmail:='<HTML>';
   FOR ONLINE IN (SELECT PRODUTO.CAD_MTMD_ID,
                         ESTLOTE.MTMD_COD_LOTE,
                         ESTLOTE.MTMD_EST_QTDE MTMD_ESTLOC_QTDE,
                         SETOR.CAD_UNI_ID_UNIDADE,
                         SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                     FROM TB_MTMD_ESTOQUE_LOTE ESTLOTE JOIN
                          TB_CAD_MTMD_MAT_MED PRODUTO ON PRODUTO.CAD_MTMD_ID = ESTLOTE.CAD_MTMD_ID JOIN
                          TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = ESTLOTE.CAD_SET_ID JOIN
                          TB_CAD_UNI_UNIDADE UNI ON UNI.CAD_UNI_ID_UNIDADE = SETOR.CAD_UNI_ID_UNIDADE
                     WHERE PRODUTO.CAD_MTMD_FL_ATIVO  = 1
                       AND PRODUTO.CAD_MTMD_GRUPO_ID  = 1
                       AND FNC_MTMD_CONTROLA_LOTE_COD(ESTLOTE.CAD_MTMD_ID, ESTLOTE.MTMD_COD_LOTE) = 1
                       AND ESTLOTE.CAD_SET_ID         = pCAD_SET_ID
                       AND ESTLOTE.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
                    UNION
                    SELECT  DISTINCT
                            PRODUTO.CAD_MTMD_ID,
                            '0' MTMD_COD_LOTE,
                            FNC_MTMD_EST_SEMLOTE_SETOR(PRODUTO.CAD_MTMD_ID,
                                                       SETOR.CAD_UNI_ID_UNIDADE,
                                                       SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                       SETOR.CAD_SET_ID,
                                                       ESTLOTE.CAD_MTMD_FILIAL_ID) MTMD_ESTLOC_QTDE,
                            SETOR.CAD_UNI_ID_UNIDADE,
                            SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO
                     FROM TB_MTMD_ESTOQUE_LOTE ESTLOTE JOIN
                          TB_CAD_MTMD_MAT_MED PRODUTO ON PRODUTO.CAD_MTMD_ID = ESTLOTE.CAD_MTMD_ID JOIN
                          TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = ESTLOTE.CAD_SET_ID JOIN
                          TB_CAD_UNI_UNIDADE UNI ON UNI.CAD_UNI_ID_UNIDADE = SETOR.CAD_UNI_ID_UNIDADE
                     WHERE PRODUTO.CAD_MTMD_FL_ATIVO  = 1
                       AND PRODUTO.CAD_MTMD_GRUPO_ID  = 1
                       AND ESTLOTE.CAD_SET_ID         = pCAD_SET_ID
                       AND ESTLOTE.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
                     UNION
                     SELECT DISTINCT
                            MTMD.CAD_MTMD_ID,
                            '0' MTMD_COD_LOTE,
                            ESTLOC.MTMD_ESTLOC_QTDE,
                            ESTLOC.CAD_UNI_ID_UNIDADE,
                            ESTLOC.CAD_LAT_ID_LOCAL_ATENDIMENTO
                      FROM TB_MTMD_ESTOQUE_LOCAL ESTLOC,
                           TB_CAD_MTMD_MAT_MED   MTMD
                      WHERE ESTLOC.CAD_SET_ID                   = pCAD_SET_ID
                      AND   ESTLOC.CAD_MTMD_FILIAL_ID           = pCAD_MTMD_FILIAL_ID
                      AND   MTMD.CAD_MTMD_ID                    = ESTLOC.CAD_MTMD_ID
                      AND   MTMD.CAD_MTMD_FL_ATIVO              = 1
                      AND   MTMD.CAD_MTMD_GRUPO_ID              = 1
                      AND   MTMD.CAD_MTMD_ID NOT IN (SELECT CAD_MTMD_ID
                                                       FROM TB_MTMD_ESTOQUE_LOTE
                                                       WHERE CAD_SET_ID = pCAD_SET_ID AND
                                                             CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID))
   LOOP
      INSERT INTO TB_MTMD_ESTOQUE_LOCAL_BKP
        (  CAD_MTMD_ID,                      CAD_UNI_ID_UNIDADE,                CAD_LAT_ID_LOCAL_ATENDIMENTO,
           CAD_SET_ID,                       CAD_MTMD_FILIAL_ID,                MTMD_ESTLOC_DATA,
           MTMD_ESTLOC_QTDE,                 MTMD_COD_LOTE)
        VALUES
        (  ONLINE.CAD_MTMD_ID,               ONLINE.CAD_UNI_ID_UNIDADE,         ONLINE.CAD_LAT_ID_LOCAL_ATENDIMENTO,
           pCAD_SET_ID,                      pCAD_MTMD_FILIAL_ID,               SYSDATE,
           ONLINE.MTMD_ESTLOC_QTDE,          ONLINE.MTMD_COD_LOTE);
        IF (NVL(ONLINE.MTMD_ESTLOC_QTDE, 0) > 0) THEN
          -- BAIXA ESTOQUE
          vCAD_MTMD_TPMOV_ID := 2;
          vCAD_MTMD_SUBTP_ID := PKG_MTMD_CONSTANTES.BAIXA_ACERTO;
          sTitulo := 'ENTRANDO INVENTARIO';

          IF (ONLINE.MTMD_COD_LOTE != '0') THEN
            SELECT L.MTMD_LOTEST_ID
              INTO vMTMD_LOTEST_ID
              FROM TB_MTMD_LOTEST_LOTE_ESTOQUE L
             WHERE L.CAD_MTMD_ID = ONLINE.CAD_MTMD_ID AND
                   L.MTMD_COD_LOTE = ONLINE.MTMD_COD_LOTE AND
                   L.CAD_MTMD_FILIAL_ID = 1 AND ROWNUM = 1;
          ELSE
            vMTMD_LOTEST_ID := NULL;
          END IF;

          BEGIN
             PRC_MTMD_MOV_ESTOQUE_BAIXA( ONLINE.CAD_MTMD_ID,
                                         NULL, -- pMTMD_REQ_ID
                                         vMTMD_LOTEST_ID,
                                         pCAD_MTMD_FILIAL_ID,
                                         ONLINE.CAD_UNI_ID_UNIDADE,
                                         ONLINE.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                         pCAD_SET_ID,
                                         ONLINE.MTMD_ESTLOC_QTDE,
                                         NULL,-- pATD_ATE_ID
                                         NULL,-- pATD_ATE_TP_PACIENTE
                                         vCAD_MTMD_TPMOV_ID,
                                         vCAD_MTMD_SUBTP_ID,
                                         0, --pCAD_MTMD_FL_FRACIONA
                                         pSEG_USU_ID_USUARIO,
                                         NULL,
                                         NULL,
                                         vNewIdt);
             -- ATUALIZA PARA MOVIMENTACAO DE INVENTARIO
             UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
             CAD_MTMD_SUBTP_ID      = 43 -- MOV BAIXA INVENTARIO
             WHERE MTMD_MOV_ID = vNewIdt;
          EXCEPTION WHEN OTHERS THEN
             erro := true;
             sMsgEmail := sMsgEmail ||
                               '<BR> <B>CORRECAO SAIDA</B> '||
                               '<BR> PRODUTO  '||TO_CHAR(ONLINE.CAD_MTMD_ID)||' '||
                               '<BR> FILIAL '||TO_CHAR(pCAD_MTMD_FILIAL_ID)||
                               '<BR> SETOR '||TO_CHAR(pCAD_SET_ID)||' '||
                               '<BR>'||TO_CHAR(SQLERRM)||'<BR>';
          END;
        END IF;
        IF (ONLINE.MTMD_COD_LOTE != '0') THEN
          -- EXCLUI ITEM DO ESTOQUE
           DELETE TB_MTMD_ESTOQUE_LOTE
           WHERE CAD_SET_ID                   = pCAD_SET_ID
           AND   CAD_MTMD_FILIAL_ID           = pCAD_MTMD_FILIAL_ID
           AND   CAD_MTMD_ID                  = ONLINE.CAD_MTMD_ID
           AND   MTMD_COD_LOTE                = ONLINE.MTMD_COD_LOTE;
        END IF;
        UPDATE TB_MTMD_MOV_MES
          SET
              MTMD_MOV_SALDO        = FNC_MTMD_ESTOQUE_CONTABIL(ONLINE.CAD_MTMD_ID, DECODE(pCAD_MTMD_FILIAL_ID, 4, 1, pCAD_MTMD_FILIAL_ID)),
              MTMD_DATA_ATUALIZACAO = SYSDATE
          WHERE
              CAD_MTMD_FILIAL_ID = DECODE(pCAD_MTMD_FILIAL_ID, 4, 1, pCAD_MTMD_FILIAL_ID)
          AND CAD_MTMD_ID        = ONLINE.CAD_MTMD_ID
          AND MTMD_MOV_ANO       = TO_NUMBER(TO_CHAR(pMTMD_MOV_DATA,'YYYY'))
          AND MTMD_MOV_MES       = TO_NUMBER(TO_CHAR(pMTMD_MOV_DATA,'MM'));
   END LOOP;
    -- IMPORTA ITENS DO INVENTARIO
   FOR INVENT IN (
       SELECT INV.*, UNI.CAD_UNI_ID_UNIDADE, SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO
       FROM TB_CAD_MTMD_INVENTARIO INV,
            TB_CAD_UNI_UNIDADE UNI,
            TB_CAD_SET_SETOR SETOR,
            TB_CAD_MTMD_MAT_MED PROD
       WHERE SETOR.CAD_SET_ID = INV.CAD_SET_ID
         AND UNI.CAD_UNI_ID_UNIDADE              = SETOR.CAD_UNI_ID_UNIDADE
         AND PROD.CAD_MTMD_ID                    = INV.CAD_MTMD_ID
         AND PROD.CAD_MTMD_GRUPO_ID              = 1
         AND TRUNC(INV.CAD_MTMD_DT_INVENTARIO)   = TRUNC(pMTMD_MOV_DATA)
         AND INV.CAD_SET_ID                      = pCAD_SET_ID
         AND INV.CAD_MTMD_FILIAL_ID              = pCAD_MTMD_FILIAL_ID
         AND INV.MTMD_COD_LOTE                  != '0'
         AND NVL(INV.CAD_MTMD_QTDE_FINAL,0)     > 0
         --AND (NVL(INV.CAD_MTMD_QTDE_FINAL,0) > 0 OR NVL(INV.CAD_MTMD_QTDE_ANTERIOR,0) > 0)
        )
   LOOP
     /*DELETE TB_MTMD_ESTOQUE_LOCAL
       WHERE CAD_UNI_ID_UNIDADE           = INVENT.CAD_UNI_ID_UNIDADE
       AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = INVENT.CAD_LAT_ID_LOCAL_ATENDIMENTO
       AND   CAD_SET_ID                   = pCAD_SET_ID
       AND   CAD_MTMD_FILIAL_ID           = pCAD_MTMD_FILIAL_ID
       AND   CAD_MTMD_ID                  = INVENT.CAD_MTMD_ID;*/
     -- FAZ ACERTO DE ENTRADA DO PRODUTO NO ESTOQUE
     vCAD_MTMD_TPMOV_ID := 1;
     vCAD_MTMD_SUBTP_ID := PKG_MTMD_CONSTANTES.ENTRADA_ACERTO;
     BEGIN
        SELECT MATMED.CAD_MTMD_ID
          INTO vMTMD_ID_ORIGINAL
          FROM TB_MTMD_PEDIDO_PADRAO PADRAO,
               TB_MTMD_PEDIDO_PADRAO_ITENS ITENS,
               TB_CAD_MTMD_MAT_MED MATMED
          WHERE ITENS.MTMD_PEDPAD_ID                   = PADRAO.MTMD_PEDPAD_ID
          AND   ITENS.CAD_MTMD_ID                      = MATMED.CAD_MTMD_ID
          AND   PADRAO.CAD_SET_ID                      = INVENT.CAD_SET_ID
          AND   PADRAO.CAD_MTMD_FILIAL_ID              = pCAD_MTMD_FILIAL_ID
          AND   ITENS.CAD_MTMD_ID                      != INVENT.CAD_MTMD_ID
          AND   MATMED.CAD_MTMD_PRIATI_ID              != 0
          AND   MATMED.CAD_MTMD_PRIATI_ID              = FNC_MTMD_PRINCIPIO_ATIVO(INVENT.CAD_MTMD_ID) AND ROWNUM = 1;
     EXCEPTION WHEN OTHERS THEN
         vMTMD_ID_ORIGINAL := NULL;
     END;
     BEGIN
        -- VERIFICAR SE CODIGO CONTROLA LOTE
        -- CASO NAO CONTROLAR, DELETAR TODO LOTE DA TB_MTMD_ESTOQUE_LOTE CASO EXISTA, POIS PASSAR? A CONTROLAR
        vMTMD_CONTROLA_LOTEST := FNC_MTMD_CONTROLA_LOTE_COD(INVENT.CAD_MTMD_ID,INVENT.MTMD_COD_LOTE);

        IF (NVL(vMTMD_CONTROLA_LOTEST,0) = 0) THEN
           DELETE TB_MTMD_ESTOQUE_LOTE
            WHERE CAD_MTMD_ID   = INVENT.CAD_MTMD_ID
              AND MTMD_COD_LOTE = INVENT.MTMD_COD_LOTE;
        END IF;

        UPDATE TB_MTMD_LOTEST_LOTE_ESTOQUE
           SET MTMD_CONTROLA_LOTEST = 1,
               MTMD_DATA_ATUALIZADO = SYSDATE
         WHERE CAD_MTMD_ID = INVENT.CAD_MTMD_ID AND
               MTMD_COD_LOTE = INVENT.MTMD_COD_LOTE AND
               NVL(MTMD_CONTROLA_LOTEST,0) = 0;

        SELECT L.MTMD_LOTEST_ID
          INTO vMTMD_LOTEST_ID
          FROM TB_MTMD_LOTEST_LOTE_ESTOQUE L
         WHERE L.CAD_MTMD_ID = INVENT.CAD_MTMD_ID AND
               L.MTMD_COD_LOTE = INVENT.MTMD_COD_LOTE AND
               L.CAD_MTMD_FILIAL_ID = 1 AND ROWNUM = 1;

        PRC_MTMD_MOV_ENTRADA_UNIDADE( INVENT.CAD_MTMD_ID,
                                      vMTMD_LOTEST_ID,
                                      pCAD_MTMD_FILIAL_ID,
                                      NULL, -- pMTMD_REQ_ID,
                                      INVENT.CAD_UNI_ID_UNIDADE,
                                      INVENT.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                      INVENT.CAD_SET_ID,
                                      vCAD_MTMD_TPMOV_ID,
                                      vCAD_MTMD_SUBTP_ID,
                                      NVL(INVENT.CAD_MTMD_QTDE_FINAL,0),
                                      NULL, --pATD_ATE_ID,
                                      NULL, -- pATD_ATE_TP_PACIENTE,
                                      1, --pMTMD_MOV_FL_FINALIZADO,
                                      pSEG_USU_ID_USUARIO,
                                      vMTMD_ID_ORIGINAL,
                                      vNewIdt);
         -- ATUALIZA PARA MOVIMENTACAO DE INVENTARIO
           UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
           CAD_MTMD_SUBTP_ID      = 44 -- MOV ENTRADA INVENTARIO
           WHERE MTMD_MOV_ID = vNewIdt;
           -- ACERTA ESTOQUE CONTABIL
           UPDATE TB_MTMD_MOV_MES
            SET
                MTMD_MOV_SALDO        = FNC_MTMD_ESTOQUE_CONTABIL(INVENT.CAD_MTMD_ID, DECODE(pCAD_MTMD_FILIAL_ID, 4, 1, pCAD_MTMD_FILIAL_ID)),
                MTMD_DATA_ATUALIZACAO = SYSDATE
            WHERE
                CAD_MTMD_FILIAL_ID = DECODE(pCAD_MTMD_FILIAL_ID, 4, 1, pCAD_MTMD_FILIAL_ID)
            AND CAD_MTMD_ID        = INVENT.CAD_MTMD_ID
            AND MTMD_MOV_ANO       = TO_NUMBER(TO_CHAR(pMTMD_MOV_DATA,'YYYY'))
            AND MTMD_MOV_MES       = TO_NUMBER(TO_CHAR(pMTMD_MOV_DATA,'MM'));
           -- ATUALIZA PERCENTUAL DE CONSUMO
           PRC_MTMD_ESTOQUE_PER_CONSUMO_U(INVENT.CAD_MTMD_ID, pCAD_MTMD_FILIAL_ID, INVENT.CAD_UNI_ID_UNIDADE, INVENT.CAD_LAT_ID_LOCAL_ATENDIMENTO, INVENT.CAD_SET_ID, nPercConsumo);
      EXCEPTION WHEN OTHERS THEN
            erro := true;
            sMsgEmail := sMsgEmail ||
                 '<BR> <B>'||sTitulo||'</B> '||
                 '<BR> PRODUTO  '||TO_CHAR(INVENT.CAD_MTMD_ID)||
                 '<BR> FILIAL '||TO_CHAR(pCAD_MTMD_FILIAL_ID)||
                 '<BR> SETOR '||TO_CHAR(INVENT.CAD_SET_ID)||' '||
                 '<BR>'||TO_CHAR(SQLERRM)||'<BR>';
            --RAISE_APPLICATION_ERROR(-20000,sMsgEmail);
      END;
   END LOOP;
   UPDATE TB_CAD_MTMD_INVENTARIO_FECHA SET MTMD_DT_IMPORT = SYSDATE
    WHERE CAD_MTMD_DT_INVENTARIO = pMTMD_MOV_DATA
      AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
      AND CAD_SET_ID = pCAD_SET_ID
      AND FL_MEDICAMENTO = 1;
   --ATIVA NOVAMENTE INVENTARIO
   UPDATE TB_CAD_MTMD_INVENTARIO_FECHA SET CAD_MTMD_ANDAMENTO = vCAD_MTMD_ANDAMENTO
    WHERE CAD_MTMD_DT_INVENTARIO = pMTMD_MOV_DATA
      AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
      AND (pCAD_MTMD_GRUPO_ID IS NULL OR CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID)
      AND CAD_SET_ID = pCAD_SET_ID;
   IF (erro) THEN
     --RAISE_APPLICATION_ERROR(-20000,sMsgEmail);
     sMsgEmail:=sMsgEmail||'</HTML>';
     PRC_ENVIA_EMAIL_CURTO('sgs@anacosta.com.br',
                           'andre.monaco@prestadores.anacosta.com.br',
                           '[IMPORTACAO INVENTARIO]',
                           sMsgEmail);
   END IF;
END PRC_MTMD_IMPORTA_INVENT_MED;