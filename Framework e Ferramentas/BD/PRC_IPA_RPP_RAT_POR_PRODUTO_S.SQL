create or replace procedure PRC_IPA_RPP_RAT_POR_PRODUTO_S
(
     pPAC_RPP_ID IN TB_CAD_PRD_PRODUTO.CAD_PRD_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_IPA_RPP_RAT_POR_PRODUTO_S
*
*    Data Criacao:     02/03/20102           Por: Rafael Coimbra
*    Data Alteracao:   Data da altera??o    Por: Nome do Analista
*
*    Funcao: Lista o Rateio de um Pacote pelo tipo de produtos
*            daquele pacote
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT
       PRD.CAD_TAP_TP_ATRIBUTO,
       TAP.CAD_TAP_DS_ATRIBUTO,
       IPA.CAD_IPA_VL_FINAL_PACOTE,
       sum(IPA.CAD_IPA_VL_ITEM_PACOTE) as Total_Por_Tipo,
       round(sum(IPA.CAD_IPA_VL_ITEM_PACOTE)/IPA.CAD_IPA_VL_FINAL_PACOTE * 100.00,2) as Porcentagem
FROM
       TB_CAD_PRD_PRODUTO PRD
INNER JOIN TB_CAD_TAP_TP_ATRIB_PRODUTO TAP
      ON PRD.CAD_TAP_TP_ATRIBUTO = TAP.CAD_TAP_TP_ATRIBUTO
INNER JOIN TB_CAD_IPA_ITEM_PACOTE IPA
      ON PRD.CAD_PRD_ID = IPA.CAD_PRD_ID_ITEM_PACOTE
WHERE
      IPA.CAD_PRD_ID_PACOTE = pPAC_RPP_ID
GROUP BY
       PRD.CAD_TAP_TP_ATRIBUTO,
       TAP.CAD_TAP_DS_ATRIBUTO,
       IPA.CAD_IPA_VL_FINAL_PACOTE;
io_cursor := v_cursor;
end PRC_IPA_RPP_RAT_POR_PRODUTO_S;
