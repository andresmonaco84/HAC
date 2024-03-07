CREATE OR REPLACE FUNCTION SGS.FNC_MTMD_ESTOQUE_CONTABIL
(    pCAD_MTMD_ID         IN  TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type,
     pCAD_MTMD_FILIAL_ID  IN  TB_MTMD_HISTORICO_NOTA_FISCAL.CAD_MTMD_FILIAL_ID%TYPE
)
 RETURN NUMBER IS


/*
*
*/

  /********************************************************************
  *    Procedure: FNC_MTMD_ESTOQUE_CONTABIL
  *
  *    Data Criacao: 09/2009     Por: RICARDO COSTA
  *    Data Alteracao:  21/05/2010  Por: RICARDO COSTA
  *         Alteração: Totalizando estoque pela tabela de estoque local
  *
  *    Funcao: RETORNA ESTOQUE_CONTABIL DO PRODUTO DE ACORDO COM A FILIAL.
  *            SE A FILIAL FOR HAC, RETORNA A SOMA COM O ESTOQUE DE CARRINHO DE EMERGÊNCIA
  *
  *******************************************************************/

ResultadoFinal NUMBER;
BEGIN
   /*
   IF (pCAD_MTMD_FILIAL_ID = 1) THEN
     SELECT SUM(ESTOQUE.MTMD_ESTCON_QTDE)
     INTO   ResultadoFinal
     FROM TB_MTMD_ESTOQUE_CONTABIL ESTOQUE
     WHERE ESTOQUE.CAD_MTMD_ID        = pCAD_MTMD_ID
     AND   ESTOQUE.CAD_MTMD_FILIAL_ID IN ( 1, 4);
   ELSE
     SELECT ESTOQUE.MTMD_ESTCON_QTDE
     INTO   ResultadoFinal
     FROM TB_MTMD_ESTOQUE_CONTABIL ESTOQUE
     WHERE ESTOQUE.CAD_MTMD_ID        = pCAD_MTMD_ID
     AND   ESTOQUE.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID;
   END IF;
*/
         IF (  pCAD_MTMD_FILIAL_ID = 1  ) THEN
            SELECT NVL(SUM(MTMD_ESTLOC_QTDE),0)+ NVL(SUM(MTMD_ESTLOC_QTDE_FRACIONADA),0)
            INTO ResultadoFinal
            FROM TB_MTMD_ESTOQUE_LOCAL ESTLOC
            WHERE CAD_MTMD_ID                  = pCAD_MTMD_ID
            AND   CAD_MTMD_FILIAL_ID           IN (1,4); -- HAC E CE
         ELSE --IF (  pCAD_MTMD_FILIAL_ID = 2  ) THEN
            SELECT NVL(SUM(MTMD_ESTLOC_QTDE),0)+ NVL(SUM(MTMD_ESTLOC_QTDE_FRACIONADA),0)
            INTO ResultadoFinal
            FROM TB_MTMD_ESTOQUE_LOCAL ESTLOC
            WHERE CAD_MTMD_ID                  = pCAD_MTMD_ID
            AND   CAD_MTMD_FILIAL_ID           = pCAD_MTMD_FILIAL_ID;
         END IF;


   RETURN NVL(ResultadoFinal,0);
END FNC_MTMD_ESTOQUE_CONTABIL;