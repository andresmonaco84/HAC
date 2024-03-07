CREATE OR REPLACE PROCEDURE PRC_MTMD_HIST_NOTA_FISCAL_S
(
   pCAD_MTMD_ID IN TB_MTMD_HISTORICO_NOTA_FISCAL.CAD_MTMD_ID%type DEFAULT NULL,
   pCAD_MTMD_FILIAL_ID IN TB_MTMD_HISTORICO_NOTA_FISCAL.CAD_MTMD_FILIAL_ID%type DEFAULT NULL,
   pMTMD_NR_NOTA IN TB_MTMD_HISTORICO_NOTA_FISCAL.MTMD_NR_NOTA%type DEFAULT NULL,
   pMTMD_DATA_PRC_MEDIO IN TB_MTMD_HISTORICO_NOTA_FISCAL.MTMD_DATA_PRC_MEDIO%type DEFAULT NULL,
   pIDMOV IN TB_MTMD_HISTORICO_NOTA_FISCAL.IDMOV%type DEFAULT NULL,
   pMTMD_LOTEST_ID IN TB_MTMD_HISTORICO_NOTA_FISCAL.MTMD_LOTEST_ID%type DEFAULT NULL,
   pMTMD_COD_LOTE IN TB_MTMD_LOTEST_LOTE_ESTOQUE.MTMD_COD_LOTE%type DEFAULT NULL,
   io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_MTMD_HISTORICO_NOTA_FISCAL_S
*
*    Data Criacao: 	data da  criai??i??o   Por: Nome do Analista
*    Data Alteracao:	22/07/2014       Por: Andri??
*         Alteracao:	Padri??o string dinamica, e mudani??a de parametros
*    Data Alteracao:  24/10/2017  Por: Andre S. Monaco
*         Alteracao:  Adicao funcao SOUND ALIKE na descricao item
*    Data Alteracao:  03/2018  Por: Andre S. Monaco
*         Alteracao:  Add. Campo MTMD_COD_LOTE
*
*    Funcao: Select de NF
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
V_WHERE  varchar2(5000);
V_SELECT  varchar2(5000);
begin
  IF pCAD_MTMD_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND HISTNF.CAD_MTMD_ID = ' || pCAD_MTMD_ID; END IF;
  IF pCAD_MTMD_FILIAL_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND HISTNF.CAD_MTMD_FILIAL_ID = ' || pCAD_MTMD_FILIAL_ID; END IF;
  IF pMTMD_NR_NOTA IS NOT NULL THEN V_WHERE := V_WHERE || ' AND HISTNF.MTMD_NR_NOTA = ' || CHR(39) || pMTMD_NR_NOTA || CHR(39); END IF;
  IF pMTMD_DATA_PRC_MEDIO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND HISTNF.MTMD_DATA_PRC_MEDIO > ' || CHR(39) || pMTMD_DATA_PRC_MEDIO || CHR(39); END IF;
  IF pIDMOV IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND HISTNF.IDMOV = ' || pIDMOV; END IF;
  IF pMTMD_LOTEST_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND LOTE.MTMD_LOTEST_ID = ' || pMTMD_LOTEST_ID; END IF;
  IF pMTMD_COD_LOTE IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND LOTE.MTMD_COD_LOTE = ' || CHR(39) || pMTMD_COD_LOTE || CHR(39); END IF;  
  V_SELECT := ' SELECT HISTNF.CAD_MTMD_ID,
                       HISTNF.CAD_MTMD_FILIAL_ID,
                       HISTNF.MTMD_NR_NOTA,
                       LOTE.MTMD_LOTEST_ID,
                       HISTNF.MTMD_CUSTO_MEDIO,
                       HISTNF.MTMD_DATA_PRC_MEDIO,
                       --NVL(LOTE.MTMD_QTDE, HISTNF.MTMD_QTDE) MTMD_QTDE,
                       CASE WHEN (SELECT COUNT(CAD_MTMD_ID) FROM TB_MTMD_LOTEST_LOTE_ESTOQUE
                                   WHERE CAD_MTMD_FILIAL_ID = HISTNF.CAD_MTMD_FILIAL_ID AND
                                         CAD_MTMD_ID        = HISTNF.CAD_MTMD_ID AND
                                         IDMOV              = HISTNF.IDMOV) <= 1 THEN
                                 HISTNF.MTMD_QTDE
                             ELSE
                                 --NVL(LOTE.MTMD_QTDE, HISTNF.MTMD_QTDE)
				                         DECODE(NVL(LOTE.MTMD_QTDE,0), 0, HISTNF.MTMD_QTDE, ((HISTNF.MTMD_QTDE/HISTNF.QTD_TOTAL_NOTA)*LOTE.MTMD_QTDE))
                       END MTMD_QTDE,
                       HISTNF.MTMD_PRECO_UNITARIO,
                       HISTNF.UNIDADE_COMPRA,
                       HISTNF.TP_MOVIMENTO,
                       HISTNF.DS_FORNECEDOR,
                       HISTNF.MTMD_ESTCON_QTDE_ANTERIOR,
                       HISTNF.QTD_TOTAL_NOTA,
                       PRODUTO.CAD_MTMD_CODMNE,
                       FNC_MTMD_SOUNDALIKE(PRODUTO.CAD_MTMD_NOMEFANTASIA,PRODUTO.CAD_MTMD_GRUPO_ID) CAD_MTMD_NOMEFANTASIA,
                       PRODUTO.CAD_MTMD_CD_FABRICANTE,
                       HISTNF.IDMOV,
                       NVL(LOTE.MTMD_NUM_LOTE_ALT, LOTE.MTMD_NUM_LOTE) MTMD_NUM_LOTE,
                       NVL(LOTE.MTMD_DT_VAL_ALT, LOTE.MTMD_DT_VALIDADE) MTMD_DT_VALIDADE,                       
                       PRODUTO.CAD_MTMD_FL_MAV,
                       LOTE.MTMD_COD_LOTE
                  FROM TB_MTMD_HISTORICO_NOTA_FISCAL HISTNF JOIN
                       TB_CAD_MTMD_MAT_MED PRODUTO ON PRODUTO.CAD_MTMD_ID = HISTNF.CAD_MTMD_ID LEFT JOIN
                       TB_MTMD_LOTEST_LOTE_ESTOQUE LOTE ON (HISTNF.CAD_MTMD_FILIAL_ID = LOTE.CAD_MTMD_FILIAL_ID AND
                                                            HISTNF.CAD_MTMD_ID = LOTE.CAD_MTMD_ID AND
                                                            HISTNF.IDMOV = LOTE.IDMOV)
                  WHERE NULL IS NULL ' || V_WHERE ||
                  ' ORDER BY PRODUTO.CAD_MTMD_NOMEFANTASIA ASC, HISTNF.MTMD_DATA_PRC_MEDIO DESC, HISTNF.MTMD_NR_NOTA DESC';
  OPEN v_cursor FOR
  V_SELECT;
  io_cursor := v_cursor;
end PRC_MTMD_HIST_NOTA_FISCAL_S;