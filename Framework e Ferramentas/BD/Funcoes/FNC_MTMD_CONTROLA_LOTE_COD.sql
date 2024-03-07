CREATE OR REPLACE FUNCTION FNC_MTMD_CONTROLA_LOTE_COD (
pCAD_MTMD_ID                  IN TB_MTMD_ESTOQUE_LOTE.CAD_MTMD_ID%type,
pMTMD_COD_LOTE                IN TB_MTMD_LOTEST_LOTE_ESTOQUE.MTMD_COD_LOTE%type DEFAULT NULL
) RETURN  NUMBER IS --Retorna 0 ou 1 (false/true) de acordo com que o lote (pMTMD_COD_LOTE) tenha controle ou nao
vMTMD_CONTROLA_LOTEST      TB_MTMD_LOTEST_LOTE_ESTOQUE.MTMD_CONTROLA_LOTEST%TYPE;
/***********************************************************************************************
*  Function: FNC_MTMD_CONTROLA_LOTE
*
*  Data Criacao:   05/2018         Por: Andre
*
*  Funcao: RETORNA SE ITEM TEM CONTROLE DE LOTE APENAS CONSULTANDO TABELA TB_MTMD_LOTEST_LOTE_ESTOQUE
*************************************************************************************************/
BEGIN
  IF (pMTMD_COD_LOTE IS NOT NULL) THEN
      BEGIN
          SELECT MTMD_CONTROLA_LOTEST
            INTO vMTMD_CONTROLA_LOTEST
            FROM (SELECT NVL(LOTE.MTMD_CONTROLA_LOTEST,0) MTMD_CONTROLA_LOTEST
                    FROM TB_MTMD_LOTEST_LOTE_ESTOQUE LOTE
                   WHERE LOTE.CAD_MTMD_FILIAL_ID = 1 AND
                         LOTE.CAD_MTMD_ID   = pCAD_MTMD_ID AND
                         LOTE.MTMD_COD_LOTE = pMTMD_COD_LOTE
                   ORDER BY LOTE.MTMD_LOTEST_ID)
           WHERE ROWNUM = 1;

          RETURN vMTMD_CONTROLA_LOTEST;
       EXCEPTION WHEN NO_DATA_FOUND THEN
          RETURN 0;
       END;
  ELSE
       RETURN 0;
  END IF;
END FNC_MTMD_CONTROLA_LOTE_COD;
