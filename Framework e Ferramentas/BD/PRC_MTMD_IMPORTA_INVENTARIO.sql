CREATE OR REPLACE PROCEDURE "PRC_MTMD_IMPORTA_INVENTARIO"
(
     pCAD_UNI_ID_UNIDADE           IN TB_MTMD_ESTOQUE_LOCAL.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_ESTOQUE_LOCAL.CAD_LAT_ID_LOCAL_ATENDIMENTO%type DEFAULT NULL,
     pCAD_SET_ID                   IN TB_MTMD_ESTOQUE_LOCAL.CAD_SET_ID%type,
     pSEG_USU_ID_USUARIO           IN TB_MTMD_MOV_MOVIMENTACAO.SEG_USU_ID_USUARIO%TYPE,
     pCAD_MTMD_FILIAL_ID           IN TB_MTMD_ESTOQUE_LOCAL.CAD_MTMD_FILIAL_ID%TYPE,
     pMTMD_MOV_DATA_FATURAMENTO    IN DATE, --Parametro usado para identificar a data do inventario
     pCAD_MTMD_GRUPO_ID            IN TB_CAD_MTMD_INVENTARIO_FECHA.CAD_MTMD_GRUPO_ID%type DEFAULT NULL
) IS
 /********************************************************************
  *    Procedure: PRC_MTMD_IMPORTA_INVENTARIO
  *
  *    Data Criacao:   12/2010        Por: Ricardo
  *    Data Alteracao: 16/08/2011    Por: Andre
  *         Alteracao: Mudanca para as tabelas do SGS
  *  Data Alterac?o:  18/03/13  Por: Andre
  *       Alterac?o:  N?o importar mais itens com qtd. zerada
  *  Data Alterac?o:  17/02/14  Por: Andre
  *       Alterac?o:  Voltou a dar entrada mesmo com qtd. zerada
  *                   para visualizar historico
  *  Data Alterac?o:  02/12/15  Por: Andre
  *       Alterac?o:  Voltar inventario pro mesmo status anterior (1 ou 2)
  *  Data Alterac?o:  06/12/16  Por: Andre
  *       Alterac?o:  Enviar email de aviso para item fracionado do ACS,
  *                   e forcar entrada apenas de medicamentos para o Plano.
  *  Data Alterac?o:  26/10/18  Por: Andre
  *       Alterac?o:  Esta rotina passar? a importar apenas materiais
  *
  *    Funcao: Importa dados do inventario para o estoque
  *******************************************************************/
   vMTMD_ID_ORIGINAL  TB_CAD_MTMD_MAT_MED.CAD_MTMD_ID%TYPE;
   vCAD_MTMD_GRUPO_ID TB_CAD_MTMD_MAT_MED.CAD_MTMD_GRUPO_ID%TYPE;
   vCAD_MTMD_FL_FRACIONA TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_FRACIONA%TYPE;
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
      WHERE TRUNC(INV.CAD_MTMD_DT_INVENTARIO) = TRUNC(pMTMD_MOV_DATA_FATURAMENTO)
      AND   INV.CAD_SET_ID                    = pCAD_SET_ID
      AND   INV.CAD_MTMD_FILIAL_ID            = pCAD_MTMD_FILIAL_ID
    --  AND   NVL(INV.CAD_MTMD_QTDE_FINAL, 0)   > 0
      AND   INV.MTMD_COD_LOTE                 = 0;
      IF ( nEXISTE = 0 ) THEN
         RAISE_APPLICATION_ERROR(-20000,' NAO EXISTE NADA PARA IMPORTAR NESTA DATA  ');
      END IF;
   END;
   SELECT CAD_MTMD_ANDAMENTO INTO vCAD_MTMD_ANDAMENTO
     FROM TB_CAD_MTMD_INVENTARIO_FECHA
    WHERE CAD_MTMD_DT_INVENTARIO = pMTMD_MOV_DATA_FATURAMENTO
      AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
      AND (pCAD_MTMD_GRUPO_ID IS NULL OR CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID)
      AND CAD_SET_ID = pCAD_SET_ID AND ROWNUM = 1;
   --INATIVA PARA PODER REALIZAR MOVIMENTAC?O
   UPDATE TB_CAD_MTMD_INVENTARIO_FECHA SET CAD_MTMD_ANDAMENTO = 0
    WHERE CAD_MTMD_DT_INVENTARIO = pMTMD_MOV_DATA_FATURAMENTO
      AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
      AND (pCAD_MTMD_GRUPO_ID IS NULL OR CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID)
      AND CAD_SET_ID = pCAD_SET_ID;
   -- INATIVA TODOS OS ITENS DO SETOR
   sMsgEmail:='<HTML>';
   FOR ONLINE IN (
    SELECT MTMD.CAD_MTMD_ID,        MTMD.CAD_MTMD_NOMEFANTASIA,
           ESTLOC.CAD_UNI_ID_UNIDADE,          ESTLOC.CAD_LAT_ID_LOCAL_ATENDIMENTO,
         ESTLOC.CAD_SET_ID,                ESTLOC.CAD_MTMD_FILIAL_ID,          ESTLOC.MTMD_ESTLOC_DATA,
         ESTLOC.MTMD_ESTLOC_QTDE,          ESTLOC.MTMD_ESTLOC_QTDE_FRACIONADA, ESTLOC.MTMD_LOTEST_ID,
         ESTLOC.MTMD_ESTLOC_FL_PADRAO,     ESTLOC.MTMD_PEDPAD_QTDE,            ESTLOC.MTMD_MOV_ESTOQUE_ATUAL,
         ESTLOC.MTMD_MOV_CONSUMO,          ESTLOC.MTMD_MOV_CONSUMO_OUTROS,     ESTLOC.MTMD_MOV_CONSUMO_PERC,
         ESTLOC.MTMD_MOV_DT_FORNECIMENTO,  ESTLOC.MTMD_ESTLOC_QTDE_DISP,       ESTLOC.MTMD_ID_ORIGINAL, MTMD.CAD_MTMD_FL_FRACIONA
    FROM TB_MTMD_ESTOQUE_LOCAL ESTLOC,
         TB_CAD_MTMD_MAT_MED   MTMD
    WHERE /*eSTLOC.CAD_UNI_ID_UNIDADE           = pCAD_UNI_ID_UNIDADE
    AND   ESTLOC.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO*/
          MTMD.TIS_MED_CD_TABELAMEDICA        = 95
    AND  (pCAD_MTMD_GRUPO_ID IS NULL OR MTMD.CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID)
    AND   ESTLOC.CAD_SET_ID                   = pCAD_SET_ID
    AND   ESTLOC.CAD_MTMD_FILIAL_ID           = pCAD_MTMD_FILIAL_ID
    AND   MTMD.CAD_MTMD_ID                    = ESTLOC.CAD_MTMD_ID)
   LOOP
      IF (pCAD_MTMD_FILIAL_ID = 2 AND NVL(ONLINE.CAD_MTMD_FL_FRACIONA,0) = 1) THEN --NAO PODE TER FRACIONADO NO ACS
        sMsgEmail := sMsgEmail ||
                     'PRODUTO  '||TO_CHAR(ONLINE.CAD_MTMD_ID)||' '||ONLINE.CAD_MTMD_NOMEFANTASIA||
                      '<br> LOCAL UNIDADE / LOCAL / SETOR '||TO_CHAR(ONLINE.CAD_UNI_ID_UNIDADE)||
                      ' '||TO_CHAR(ONLINE.CAD_LAT_ID_LOCAL_ATENDIMENTO)|| ' '||TO_CHAR(ONLINE.CAD_SET_ID);
       PRC_ENVIA_EMAIL_CURTO('sgs@anacosta.com.br',
                             'andre.monaco@prestadores.anacosta.com.br',
                             '[IMPORTACAO INVENTARIO ACS - ITEM FRACIONADO - AVISO]',
                             sMsgEmail);
      ELSE
        INSERT INTO TB_MTMD_ESTOQUE_LOCAL_BKP
        (  CAD_MTMD_ID,                       CAD_UNI_ID_UNIDADE,                  CAD_LAT_ID_LOCAL_ATENDIMENTO,
           CAD_SET_ID,                        CAD_MTMD_FILIAL_ID,                  MTMD_ESTLOC_DATA,
           MTMD_ESTLOC_QTDE,                  MTMD_ESTLOC_QTDE_FRACIONADA,         MTMD_LOTEST_ID,
           MTMD_ESTLOC_FL_PADRAO,             MTMD_PEDPAD_QTDE,                    MTMD_MOV_ESTOQUE_ATUAL,
           MTMD_MOV_CONSUMO,                  MTMD_MOV_CONSUMO_OUTROS,             MTMD_MOV_CONSUMO_PERC,
           MTMD_MOV_DT_FORNECIMENTO,          MTMD_ESTLOC_QTDE_DISP,               MTMD_ID_ORIGINAL,
           MTMD_DT_TRANSACAO,                 SEG_USU_ID_USUARIO)
        VALUES
        (  ONLINE.CAD_MTMD_ID,               ONLINE.CAD_UNI_ID_UNIDADE,          ONLINE.CAD_LAT_ID_LOCAL_ATENDIMENTO,
           ONLINE.CAD_SET_ID,                ONLINE.CAD_MTMD_FILIAL_ID,          ONLINE.MTMD_ESTLOC_DATA,
           ONLINE.MTMD_ESTLOC_QTDE,          ONLINE.MTMD_ESTLOC_QTDE_FRACIONADA, ONLINE.MTMD_LOTEST_ID,
           ONLINE.MTMD_ESTLOC_FL_PADRAO,     ONLINE.MTMD_PEDPAD_QTDE,            ONLINE.MTMD_MOV_ESTOQUE_ATUAL,
           ONLINE.MTMD_MOV_CONSUMO,          ONLINE.MTMD_MOV_CONSUMO_OUTROS,     ONLINE.MTMD_MOV_CONSUMO_PERC,
           ONLINE.MTMD_MOV_DT_FORNECIMENTO,  ONLINE.MTMD_ESTLOC_QTDE_DISP,       ONLINE.MTMD_ID_ORIGINAL,
           SYSDATE,                          pSEG_USU_ID_USUARIO );
        IF (NVL(ONLINE.MTMD_ESTLOC_QTDE, 0) > 0) THEN
          -- BAIXA ESTOQUE
          vCAD_MTMD_TPMOV_ID := 2;
          vCAD_MTMD_SUBTP_ID := PKG_MTMD_CONSTANTES.BAIXA_ACERTO;
          sTitulo := 'ENTRANDO INVENTARIO';
          BEGIN
             PRC_MTMD_MOV_ESTOQUE_BAIXA( ONLINE.CAD_MTMD_ID,
                                         NULL, -- pMTMD_REQ_ID
                                         NULL, --pMTMD_LOTEST_ID
                                         ONLINE.CAD_MTMD_FILIAL_ID,
                                         ONLINE.CAD_UNI_ID_UNIDADE,
                                         ONLINE.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                         ONLINE.CAD_SET_ID,
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
                               '<BR> PRODUTO  '||TO_CHAR(ONLINE.CAD_MTMD_ID)||' '||ONLINE.CAD_MTMD_NOMEFANTASIA||
                               '<br> FILIAL '||TO_CHAR(ONLINE.CAD_MTMD_FILIAL_ID)||
                               '<br> LOCAL UNIDADE / LOCAL / SETOR '||TO_CHAR(ONLINE.CAD_UNI_ID_UNIDADE)||
                               ' '||TO_CHAR(ONLINE.CAD_LAT_ID_LOCAL_ATENDIMENTO)||
                               ' '||TO_CHAR(ONLINE.CAD_SET_ID)||
                               ' '||
                               '<BR>'||SQLERRM||'<BR>';
          END;
        END IF;
        -- EXCLUI ITEM DO ESTOQUE
         /*DELETE TB_MTMD_ESTOQUE_LOCAL
         WHERE CAD_UNI_ID_UNIDADE           = ONLINE.CAD_UNI_ID_UNIDADE
         AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = ONLINE.CAD_LAT_ID_LOCAL_ATENDIMENTO
         AND   CAD_SET_ID                   = ONLINE.CAD_SET_ID
         AND   CAD_MTMD_FILIAL_ID           = ONLINE.CAD_MTMD_FILIAL_ID
         AND   CAD_MTMD_ID                  = ONLINE.CAD_MTMD_ID;*/
         UPDATE TB_MTMD_MOV_MES
          SET
              MTMD_MOV_SALDO        = FNC_MTMD_ESTOQUE_CONTABIL(ONLINE.CAD_MTMD_ID, DECODE(ONLINE.CAD_MTMD_FILIAL_ID, 4, 1, ONLINE.CAD_MTMD_FILIAL_ID)),
              MTMD_DATA_ATUALIZACAO = SYSDATE
          WHERE
              CAD_MTMD_FILIAL_ID = DECODE(ONLINE.CAD_MTMD_FILIAL_ID, 4, 1, ONLINE.CAD_MTMD_FILIAL_ID)
          AND CAD_MTMD_ID        = ONLINE.CAD_MTMD_ID
          AND MTMD_MOV_ANO       = TO_NUMBER(TO_CHAR(pMTMD_MOV_DATA_FATURAMENTO,'YYYY'))
          AND MTMD_MOV_MES       = TO_NUMBER(TO_CHAR(pMTMD_MOV_DATA_FATURAMENTO,'MM'));
      END IF;
   END LOOP;
    -- IMPORTA ITENS DO INVENTARIO
   FOR INVENT IN (
       SELECT INV.*, UNI.CAD_UNI_ID_UNIDADE, SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO
       FROM TB_CAD_MTMD_INVENTARIO INV,
            TB_CAD_UNI_UNIDADE UNI,
            TB_CAD_SET_SETOR SETOR,
            TB_CAD_MTMD_MAT_MED PROD
       WHERE SETOR.CAD_SET_ID = INV.CAD_SET_ID
         AND UNI.CAD_UNI_ID_UNIDADE = SETOR.CAD_UNI_ID_UNIDADE
         AND PROD.CAD_MTMD_ID = INV.CAD_MTMD_ID
         AND PROD.TIS_MED_CD_TABELAMEDICA        = 95
         AND TRUNC(INV.CAD_MTMD_DT_INVENTARIO)   = TRUNC(pMTMD_MOV_DATA_FATURAMENTO)
         AND INV.CAD_SET_ID                      = pCAD_SET_ID
         AND INV.CAD_MTMD_FILIAL_ID              = pCAD_MTMD_FILIAL_ID
         AND (pCAD_MTMD_GRUPO_ID IS NULL OR PROD.CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID)
         AND NVL(INV.CAD_MTMD_QTDE_FINAL,0) > 0
        )
   LOOP
       IF (pCAD_MTMD_FILIAL_ID = 2) THEN --So vai necessitar buscar esse campo para o ACS para a proxima verificacao
         SELECT MATMED.CAD_MTMD_GRUPO_ID, MATMED.CAD_MTMD_FL_FRACIONA
           INTO vCAD_MTMD_GRUPO_ID,       vCAD_MTMD_FL_FRACIONA
           FROM TB_CAD_MTMD_MAT_MED MATMED
          WHERE MATMED.CAD_MTMD_ID = INVENT.CAD_MTMD_ID;
       END IF;
       IF (pCAD_MTMD_FILIAL_ID != 2 OR (pCAD_MTMD_FILIAL_ID = 2 AND NVL(vCAD_MTMD_GRUPO_ID,0) = 1 AND NVL(vCAD_MTMD_FL_FRACIONA,0) = 0)) THEN --Para ACS, dar entrada so de medicamento inteiro
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
            PRC_MTMD_MOV_ENTRADA_UNIDADE( INVENT.CAD_MTMD_ID,
                                          NULL, -- pMTMD_LOTEST_ID
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
                AND MTMD_MOV_ANO       = TO_NUMBER(TO_CHAR(pMTMD_MOV_DATA_FATURAMENTO,'YYYY'))
                AND MTMD_MOV_MES       = TO_NUMBER(TO_CHAR(pMTMD_MOV_DATA_FATURAMENTO,'MM'));
               -- ATUALIZA PERCENTUAL DE CONSUMO
               PRC_MTMD_ESTOQUE_PER_CONSUMO_U(INVENT.CAD_MTMD_ID, pCAD_MTMD_FILIAL_ID, INVENT.CAD_UNI_ID_UNIDADE, INVENT.CAD_LAT_ID_LOCAL_ATENDIMENTO, INVENT.CAD_SET_ID, nPercConsumo);
               /*vQTDECONTABIL := FNC_MTMD_ESTOQUE_CONTABIL( INVENT.CAD_MTMD_ID,
                                                           pCAD_MTMD_FILIAL_ID );
               UPDATE TB_MTMD_ESTOQUE_CONTABIL SET
               MTMD_ESTCON_QTDE = vQTDECONTABIL
               WHERE CAD_MTMD_ID        = INVENT.CAD_MTMD_ID
               AND  CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID;*/
          EXCEPTION WHEN OTHERS THEN
                erro := true;
                sMsgEmail := sMsgEmail ||
                     '<BR> <B>'||sTitulo||'</B> '||
                     '<BR> PRODUTO  '||TO_CHAR(INVENT.CAD_MTMD_ID)||
                      '<BR> FILIAL '||TO_CHAR(pCAD_MTMD_FILIAL_ID)||
                      '<BR> LOCAL UNIDADE / LOCAL / SETOR '||TO_CHAR(INVENT.CAD_UNI_ID_UNIDADE)||
                      ' '||TO_CHAR(INVENT.CAD_LAT_ID_LOCAL_ATENDIMENTO)||
                      ' '||TO_CHAR(INVENT.CAD_SET_ID)||
                      ' '||
                       '<BR>'||SQLERRM||'<BR>';
          END;
       END IF;
   END LOOP;
   UPDATE TB_CAD_MTMD_INVENTARIO_FECHA SET MTMD_DT_IMPORT = SYSDATE
    WHERE CAD_MTMD_DT_INVENTARIO = pMTMD_MOV_DATA_FATURAMENTO
      AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
      AND (pCAD_MTMD_GRUPO_ID IS NULL OR CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID)
      AND CAD_SET_ID = pCAD_SET_ID
      AND FL_MEDICAMENTO = 0;
   --ATIVA NOVAMENTE INVENTARIO
   UPDATE TB_CAD_MTMD_INVENTARIO_FECHA SET CAD_MTMD_ANDAMENTO = vCAD_MTMD_ANDAMENTO
    WHERE CAD_MTMD_DT_INVENTARIO = pMTMD_MOV_DATA_FATURAMENTO
      AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
      AND (pCAD_MTMD_GRUPO_ID IS NULL OR CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID)
      AND CAD_SET_ID = pCAD_SET_ID;
   IF (erro) THEN
     sMsgEmail:=sMsgEmail||'</HTML>';
     PRC_ENVIA_EMAIL_CURTO('sgs@anacosta.com.br',
                           'andre.monaco@prestadores.anacosta.com.br',
                           '[IMPORTACAO INVENTARIO]',
                           sMsgEmail);
   END IF;
END PRC_MTMD_IMPORTA_INVENTARIO;