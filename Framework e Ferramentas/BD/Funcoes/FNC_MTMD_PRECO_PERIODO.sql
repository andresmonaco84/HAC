CREATE OR REPLACE FUNCTION FNC_MTMD_PRECO_PERIODO
(
     pCAD_MTMD_ID         IN sgs.tb_mtmd_historico_nota_fiscal.cad_mtmd_id%TYPE,
     pCAD_MTMD_FILIAL_ID  IN sgs.tb_mtmd_historico_nota_fiscal.CAD_MTMD_FILIAL_ID%TYPE,
     pMTMD_MOV_DATA                IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_DATA%type DEFAULT NULL,
     pMTMD_MOV_DATA_ATE            IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_DATA%type DEFAULT NULL
)
 RETURN NUMBER IS
 /********************************************************************
  *    Procedure: FNC_MTMD_PRECO_PERIODO
  *
  *    Data Criacao:   08/04/2010   Por: Andre Souza Monaco
  *    Data Alterac?o: 27/01/2011   Por: Andre Souza Monaco
  *         Alterac?o: Comentario ao procurar na tb_mtmd_mov_movimentacao
  *    Data Alterac?o: 28/09/2011   Por: Andre Souza Monaco
  *         Alterac?o: Estava buscano preco unitario ao inves do preco medio
  *    Data Alterac?o: 28/11/2018   Por: Andre Souza Monaco
  *         Alterac?o: Buscar CM do Fechamento
  *
  *    Funcao: Retorna preco do periodo
  *******************************************************************/
 nFilial  NUMBER;
 nRetorno NUMBER := 0;
BEGIN
    nFilial := FNC_MTMD_RETORNA_FILIAL (pCAD_MTMD_ID, pCAD_MTMD_FILIAL_ID, NULL);
    /*SELECT NVL(SUM(MTMD_CUSTO_MEDIO_ATUAL),0)
      INTO nRetorno
      FROM (SELECT MTMD_CUSTO_MEDIO_ATUAL
              FROM TB_MTMD_MOV_ESTOQUE_DIA
             WHERE CAD_SET_ID         = 29
             AND   CAD_MTMD_SUBTP_ID  = 0
             AND   CAD_MTMD_FILIAL_ID = 1
             AND   MTMD_CUSTO_MEDIO_ATUAL > 0
             AND   MTMD_MOV_DATA BETWEEN trunc(pMTMD_MOV_DATA-90) and trunc(pMTMD_MOV_DATA_ATE)
             AND   CAD_MTMD_ID        = pCAD_MTMD_ID
            ORDER BY MTMD_MOV_DATA DESC)
    WHERE ROWNUM = 1;*/
    -- Se n?o achou nada nas movimentac?es, retorna valor da ultima nota do periodo
    IF (nRetorno = 0) THEN
      BEGIN
          select nvl(mtmd_custo_medio,0)
          into   nRetorno
          from (select t.mtmd_custo_medio
          from tb_mtmd_historico_nota_fiscal t
          where cad_mtmd_id = pCAD_MTMD_ID and
                CAD_MTMD_FILIAL_ID = nFilial and
                trunc(t.mtmd_data_prc_medio) between trunc(pMTMD_MOV_DATA-60) and trunc(pMTMD_MOV_DATA_ATE)
          order by t.mtmd_data_prc_medio desc)
          where rownum = 1;
      EXCEPTION WHEN NO_DATA_FOUND THEN
         nRetorno := 0;
      END;
    END IF;
    -- Se ainda assim n?o achar, procura pela ultima nota
    IF (nRetorno = 0) THEN
        nRetorno := FNC_MTMD_PRECO_MEDIO(pCAD_MTMD_ID, nFilial);
    END IF;
   RETURN nRetorno;
END FNC_MTMD_PRECO_PERIODO;