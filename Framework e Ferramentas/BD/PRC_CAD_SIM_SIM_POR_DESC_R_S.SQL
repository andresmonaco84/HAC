CREATE OR REPLACE PROCEDURE PRC_CAD_SIM_SIM_POR_DESC_R_S
(
     pCAD_SIM_DS_PRODUTO IN TB_CAD_SIM_SIMPRO.CAD_SIM_DS_PRODUTO%type,
          pCAD_SIM_TP_FABRICANTE IN TB_CAD_SIM_SIMPRO.CAD_SIM_TP_FABRICANTE%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_SIM_SIM_POR_DESC_R_S
* 
*    Data Criacao:   02/08/2010   Por: Rafael Coimbra
*
*    Data Alteracao:  24/07/2015  Por: Andre
*         Alteracao:  Add campo IDENT_DESCRICAO
*
*    Funcao: Seleciona os registros da Tabela pela descric?o.
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT  
       CAD_SIM_ID,
       CAD_SIM_CD_SIMPRO,
       CAD_SIM_NM_MNEMONICO,
       CAD_SIM_DS_PRODUTO,
       CAD_SIM_DT_VIGENCIA,
       CAD_SIM_ID_IDENTIFICACAO,
       CAD_SIM_VL_PRECO_FABRICA,
       CAD_SIM_VL_PRECO_VENDA,
       CAD_SIM_VL_FRACAO_FABRICA,
       CAD_SIM_VL_FRACAO_VENDA,
       CAD_SIM_TP_EMBALAGEM,
       CAD_SIM_TP_FRACAO,
       CAD_SIM_QT_EMBALAGEM,
       CAD_SIM_QT_FRACAO,
       CAD_SIM_TP_ALTERACAO,
       CAD_SIM_TP_FABRICANTE,
       CAD_SIM_ID_INTEIRO,
       CAD_SIM_ID_FRACIONADO,
       CAD_SIM_QT_FRACIONADO,
       CAD_SIM_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
	     CAD_SIM_CD_TUSS,
       CAD_SIM_ID_IDENTIFICACAO || ' - ' || 
       DECODE(CAD_SIM_ID_IDENTIFICACAO, 
              'F', 'Preco de Fabrica',
              'V', 'Preco de Venda',
              'L', 'Fora de Linha',
              'A', 'Atualizacao Suspensa',
              'D', 'Descontinuado') IDENT_DESCRICAO
FROM TB_CAD_SIM_SIMPRO
WHERE
       CAD_SIM_DS_PRODUTO LIKE '%' || pCAD_SIM_DS_PRODUTO || '%'
       AND UPPER(CAD_SIM_TP_FABRICANTE) LIKE '%' || UPPER(pCAD_SIM_TP_FABRICANTE) || '%' 
ORDER BY CAD_SIM_DS_PRODUTO;          
io_cursor := v_cursor;
end PRC_CAD_SIM_SIM_POR_DESC_R_S;
