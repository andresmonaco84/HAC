CREATE OR REPLACE PROCEDURE PRC_ASS_MTMD_COD_BARRA_AVULSO
(
   pCAD_MTMD_ID IN TB_ASS_MTMD_CODIGO_BARRA.CAD_MTMD_ID%type,
   pCAD_MTMD_FILIAL_ID IN TB_ASS_MTMD_CODIGO_BARRA.CAD_MTMD_FILIAL_ID%type,
   pSEG_ID_USUARIO_IMPRESSAO IN TB_ASS_MTMD_CODIGO_BARRA.SEG_ID_USUARIO_IMPRESSAO%type DEFAULT NULL,
   io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ASS_MTMD_CODIGO_BARRA_S
*
*    Data Criacao: 	24/06/2009   Por: André Souza Monaco
*   Data Alteração: 05/08/2014   Por: André Souza Monaco
*        Alteração: Ativação e adequação para o novo modelo de lotes
*
*    Funcao: Insere um cod. barra avulso do produto se ainda não existe,
*            retornando o cursor dele
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
IdtLote TB_MTMD_LOTEST_LOTE_ESTOQUE.MTMD_LOTEST_ID%type;
BEGIN
  -- VERIFICA SE JA EXISTE LOTE AVULSO CADASTRADO PARA ESTE PRODUTO NO SGS, SE NÃO, INSERE.
  BEGIN
     SELECT MTMD_LOTEST_ID
     INTO   IdtLote
     FROM TB_MTMD_LOTEST_LOTE_ESTOQUE LOTE
     WHERE LOTE.IDMOV              = 0
     AND   LOTE.CAD_MTMD_ID        = pCAD_MTMD_ID
     AND   LOTE.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID;
  EXCEPTION
     WHEN NO_DATA_FOUND THEN
        SELECT SEQ_MTMD_LOTE.NEXTVAL INTO IdtLote FROM DUAL;
        BEGIN
          INSERT INTO TB_MTMD_LOTEST_LOTE_ESTOQUE
          ( MTMD_LOTEST_ID,       CAD_MTMD_ID,            
            MTMD_DATA_ATUALIZADO, CAD_MTMD_FILIAL_ID,
            IDMOV,                MTMD_QTDE                
          )
          VALUES
          ( IdtLote,              pCAD_MTMD_ID,          
            SYSDATE,              pCAD_MTMD_FILIAL_ID,
            0,                    1
          );
          BEGIN
            PRC_ASS_MTMD_CODIGO_BARRA_I(pCAD_MTMD_ID, pCAD_MTMD_FILIAL_ID, IdtLote, FNC_MTMD_COD_BARRA_EAN13(IdtLote, pCAD_MTMD_ID), pSEG_ID_USUARIO_IMPRESSAO);
          END;
          --COMMIT;
        END;
  END;

  OPEN v_cursor FOR
  SELECT
     CAD_MTMD_ID,
     CAD_MTMD_FILIAL_ID,
     MTMD_LOTEST_ID,
     MTM_CD_BARRA
  FROM TB_ASS_MTMD_CODIGO_BARRA
  WHERE
      MTMD_LOTEST_ID = IdtLote;
  io_cursor := v_cursor;
END PRC_ASS_MTMD_COD_BARRA_AVULSO;
 
