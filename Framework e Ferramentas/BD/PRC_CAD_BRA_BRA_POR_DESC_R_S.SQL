create or replace procedure PRC_CAD_BRA_BRA_POR_DESC_R_S
(
     pCAD_BRA_DS_PRODUTO IN TB_CAD_BRA_BRASINDICE.CAD_BRA_DS_PRODUTO%type,
     pCAD_BRA_DS_LAB IN TB_CAD_BRA_BRASINDICE.CAD_BRA_DS_LAB%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_CAD_BRA_BRA_POR_DESC_R_S
*
*    Data Criacao:   02/08/2010   Por: Rafael Coimbra
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Seleciona os registros da Tabela pela descrição.
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT
       CAD_BRA_ID,
       CAD_BRA_CD_TISS,
       CAD_BRA_NM_MNEMONICO,
       CAD_BRA_CD_LAB,
       CAD_BRA_DS_LAB,
       CAD_BRA_CD_PRODUTO,
       CAD_BRA_DS_PRODUTO,
       CAD_BRA_CD_APR,
       CAD_BRA_DS_APR,
       CAD_BRA_VL_PRECO,
       CAD_BRA_QT_EMBALAGEM,
       CAD_BRA_TP_PRECO,
       CAD_BRA_VL_PRECO_UNITARIO,
       CAD_BRA_ED_EDICAO,
       CAD_BRA_PC_IPI,
       CAD_CME_CLASSIF_MED,
       CAD_BRA_ID_INTEIRO,
       CAD_BRA_ID_FRACIONADO,
       CAD_BRA_QT_FRACIONADO,
       CAD_BRA_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
    CAD_BRA_CD_TUSS
FROM TB_CAD_BRA_BRASINDICE
WHERE
       (CAD_BRA_DS_PRODUTO LIKE '%' || pCAD_BRA_DS_PRODUTO || '%'
       OR UPPER(CAD_BRA_DS_APR) LIKE '%' || pCAD_BRA_DS_PRODUTO || '%')
       AND UPPER(CAD_BRA_DS_LAB) LIKE '%' || UPPER(pCAD_BRA_DS_LAB) || '%'
       
ORDER BY CAD_BRA_DS_PRODUTO;

io_cursor := v_cursor;
end PRC_CAD_BRA_BRA_POR_DESC_R_S;
 