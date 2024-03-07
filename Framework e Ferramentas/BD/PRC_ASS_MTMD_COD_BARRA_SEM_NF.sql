CREATE OR REPLACE PROCEDURE PRC_ASS_MTMD_COD_BARRA_SEM_NF
(
   pCAD_MTMD_ID IN TB_ASS_MTMD_CODIGO_BARRA.CAD_MTMD_ID%type,
   pMTMD_NUM_LOTE IN TB_MTMD_LOTEST_LOTE_ESTOQUE.MTMD_NUM_LOTE%type,
   pMTMD_DT_VALIDADE IN TB_MTMD_LOTEST_LOTE_ESTOQUE.MTMD_DT_VALIDADE%type,
   pMTMD_QTDE IN TB_MTMD_LOTEST_LOTE_ESTOQUE.MTMD_QTDE%type := 0,
   pSEG_ID_USUARIO_IMPRESSAO IN TB_ASS_MTMD_CODIGO_BARRA.SEG_ID_USUARIO_IMPRESSAO%type DEFAULT NULL,
   pCAD_MTMD_SUBTP_ID IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_SUBTP_ID%type := 61, --MOV. ENTRADA EXTERNA SEM NF - NOVO LOTE
   pID_EMP_EMPRESTIMO IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID_EMP_EMPRESTIMO%type DEFAULT NULL,
   pCAD_SET_ID IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type := 29, --ALMOX
   io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ASS_MTMD_COD_BARRA_SEM_NF
*
*    Data Criacao: 4/11/19   Por: Andre Souza Monaco
*
*    Funcao: Insere e retorna cod. barra de um medicamento sem entrada via NF
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
IdtLote TB_MTMD_LOTEST_LOTE_ESTOQUE.MTMD_LOTEST_ID%type;
IdMov TB_MTMD_LOTEST_LOTE_ESTOQUE.IDMOV%type;
CodLote TB_MTMD_LOTEST_LOTE_ESTOQUE.MTMD_COD_LOTE%type;
vCUSTO_MEDIO TB_MTMD_HISTORICO_NOTA_FISCAL.MTMD_CUSTO_MEDIO%type;
vCAD_MTMD_GRUPO_ID TB_CAD_MTMD_MAT_MED.CAD_MTMD_GRUPO_ID%type;
nIdEntrada integer;
BEGIN  
  -- VERIFICA SE JA EXISTE LOTE CADASTRADO PARA ESTE PRODUTO NO SGS, SE NAO, INSERE.
  BEGIN
     SELECT CAD_MTMD_GRUPO_ID
     INTO   vCAD_MTMD_GRUPO_ID
     FROM TB_CAD_MTMD_MAT_MED
     WHERE CAD_MTMD_ID = pCAD_MTMD_ID;
     IF (vCAD_MTMD_GRUPO_ID <> 1 AND
         NVL(pMTMD_QTDE,0) > 0 AND NVL(pCAD_MTMD_SUBTP_ID, 61) IN (62,63)) THEN --Se for material, ignorar lote
       PRC_MTMD_MOV_ENTRADA_UNIDADE( pCAD_MTMD_ID,
                                     NULL, --Lote
                                     1,
                                     NULL,
                                     244,
                                     33,
                                     pCAD_SET_ID,
                                     1,
                                     pCAD_MTMD_SUBTP_ID,
                                     pMTMD_QTDE,
                                     NULL,
                                     NULL,
                                     1,
                                     pSEG_ID_USUARIO_IMPRESSAO,
                                     NULL,
                                     nIdEntrada);
       IF (pID_EMP_EMPRESTIMO IS NOT NULL) THEN
         UPDATE TB_MTMD_MOV_MOVIMENTACAO 
            SET CAD_MTMD_ID_EMP_EMPRESTIMO = pID_EMP_EMPRESTIMO
          WHERE MTMD_MOV_ID = nIdEntrada;
       END IF;
       OPEN v_cursor FOR
        SELECT
           BARRA.CAD_MTMD_ID,
           BARRA.CAD_MTMD_FILIAL_ID,
           BARRA.MTMD_LOTEST_ID,
           BARRA.MTM_CD_BARRA,
           NULL MTMD_COD_LOTE
        FROM TB_ASS_MTMD_CODIGO_BARRA BARRA
        WHERE
            BARRA.CAD_MTMD_ID = pCAD_MTMD_ID AND
            Length(BARRA.MTM_CD_BARRA) = 13 AND ROWNUM = 1;
       io_cursor := v_cursor;
       RETURN; 
     END IF;
     SELECT MTMD_LOTEST_ID
     INTO   IdtLote
     FROM TB_MTMD_LOTEST_LOTE_ESTOQUE LOTE
     WHERE LOTE.CAD_MTMD_FILIAL_ID  = 1
     AND   LOTE.CAD_MTMD_ID         = pCAD_MTMD_ID
     AND   TRIM(Replace(LOTE.MTMD_NUM_LOTE,'.','')) = TRIM(Replace(pMTMD_NUM_LOTE,'.',''))
     AND   LOTE.MTMD_CONTROLA_LOTEST = 1 AND ROWNUM = 1;
     --AND   IDMOV                    < 0;
     -- REALIZA A ENTRADA DO PRODUTO NO ESTOQUE DO LOTE JA EXISTENTE
     IF (NVL(pMTMD_QTDE,0) > 0 AND NVL(pCAD_MTMD_SUBTP_ID, 61) IN (62,63)) THEN --ENTRADA EMPRESTIMO OBTIDO/DEVOLVIDO
       PRC_MTMD_MOV_ENTRADA_UNIDADE( pCAD_MTMD_ID,
                                     IdtLote,
                                     1,
                                     NULL,
                                     244,
                                     33,
                                     pCAD_SET_ID,
                                     1,
                                     pCAD_MTMD_SUBTP_ID,
                                     pMTMD_QTDE,
                                     NULL,
                                     NULL,
                                     1,
                                     pSEG_ID_USUARIO_IMPRESSAO,
                                     NULL,
                                     nIdEntrada);
       IF (pID_EMP_EMPRESTIMO IS NOT NULL) THEN
         UPDATE TB_MTMD_MOV_MOVIMENTACAO 
            SET CAD_MTMD_ID_EMP_EMPRESTIMO = pID_EMP_EMPRESTIMO
          WHERE MTMD_MOV_ID = nIdEntrada;
       END IF;
     END IF;
  EXCEPTION
     WHEN NO_DATA_FOUND THEN
        vCUSTO_MEDIO := FNC_MTMD_PRECO_MEDIO(pCAD_MTMD_ID, 1);        
        SELECT SEQ_MTMD_LOTE.NEXTVAL INTO IdtLote FROM DUAL;
        SELECT SEQ_MTMD_IDMOV_NEG.NEXTVAL INTO IdMov FROM DUAL;
        SELECT NVL(MAX(TO_NUMBER(MTMD_COD_LOTE)),99990)+1          
          INTO CodLote
          FROM TB_MTMD_LOTEST_LOTE_ESTOQUE LOTEST
         WHERE CAD_MTMD_ID = pCAD_MTMD_ID
           AND TO_NUMBER(MTMD_COD_LOTE) > 99990;
        BEGIN
          INSERT INTO TB_MTMD_LOTEST_LOTE_ESTOQUE
          ( MTMD_LOTEST_ID,       CAD_MTMD_ID,            MTMD_NUM_LOTE,
            MTMD_DT_VALIDADE,     MTMD_CONTROLA_LOTEST,   MTMD_COD_LOTE,
            MTMD_IDLOTE_RM,       MTMD_DATA_ATUALIZADO,   CAD_MTMD_FILIAL_ID,
            IDMOV,                MTMD_QTDE,              CAD_MTMD_CD_FABRICANTE
          )
          VALUES
          ( IdtLote,              pCAD_MTMD_ID,          TRIM(pMTMD_NUM_LOTE),
            pMTMD_DT_VALIDADE,    1,                     CodLote,
            NULL,                 SYSDATE,               1,
            IdMov,                pMTMD_QTDE,            '0000'
          );          
          PRC_MTMD_MOV_ESTOQUE_ENTRADA(pCAD_MTMD_ID,
                                       IdtLote,
                                       1,
                                       244,
                                       33,
                                       pCAD_SET_ID,
                                       NVL(pMTMD_QTDE,0),
                                       vCUSTO_MEDIO,
                                       1,
                                       NVL(pCAD_MTMD_SUBTP_ID, 61), --MOV. ENTRADA EXTERNA SEM NF - NOVO LOTE
                                       IdtLote, --'000000',
                                       SYSDATE,
                                       IdMov,
                                       1,
                                       1,
                                       NULL,
                                       '! ENTRADA EXTERNA SEM NF !',
                                       'UN',
                                       NULL,
                                       NVL(pMTMD_QTDE,0),
                                       NULL);
          IF (pID_EMP_EMPRESTIMO IS NOT NULL AND pCAD_MTMD_SUBTP_ID IS NOT NULL) THEN
             UPDATE TB_MTMD_MOV_MOVIMENTACAO 
                SET CAD_MTMD_ID_EMP_EMPRESTIMO = pID_EMP_EMPRESTIMO,
                    MTMD_MOV_ESTOQUE_ATUAL = FNC_MTMD_ESTOQUE_UNIDADE(pCAD_MTMD_ID,
                                                                      244,
                                                                      33,
                                                                      pCAD_SET_ID,
                                                                      1,
                                                                      NULL)
              WHERE CAD_SET_ID = pCAD_SET_ID AND
                    CAD_MTMD_TPMOV_ID = 1 AND
                    CAD_MTMD_SUBTP_ID = NVL(pCAD_MTMD_SUBTP_ID, 61) AND
                    CAD_MTMD_ID = pCAD_MTMD_ID AND
                    MTMD_LOTEST_ID = IdtLote AND
                    MTMD_MOV_DATA > TRUNC(SYSDATE);
          END IF;
          BEGIN
            PRC_ASS_MTMD_CODIGO_BARRA_I(pCAD_MTMD_ID, 1, IdtLote, FNC_MTMD_COD_BARRA_EAN13(IdtLote, pCAD_MTMD_ID), pSEG_ID_USUARIO_IMPRESSAO);
          END;
        END;
  END;
  OPEN v_cursor FOR
  SELECT
     BARRA.CAD_MTMD_ID,
     BARRA.CAD_MTMD_FILIAL_ID,
     BARRA.MTMD_LOTEST_ID,
     BARRA.MTM_CD_BARRA,
     LOTE.MTMD_COD_LOTE
  FROM TB_ASS_MTMD_CODIGO_BARRA BARRA JOIN
       TB_MTMD_LOTEST_LOTE_ESTOQUE LOTE ON LOTE.MTMD_LOTEST_ID = BARRA.MTMD_LOTEST_ID
  WHERE
      BARRA.MTMD_LOTEST_ID = IdtLote;
  io_cursor := v_cursor;
END PRC_ASS_MTMD_COD_BARRA_SEM_NF;