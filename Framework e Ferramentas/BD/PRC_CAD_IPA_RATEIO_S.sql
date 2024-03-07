create or replace procedure PRC_CAD_IPA_RATEIO_S
(
     pCAD_PRD_ID IN TB_CAD_PRD_PRODUTO.CAD_PRD_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_CAD_IPA_RATEIO_S
*
*    Data Criacao:     21/08/2010           Por: Marcus Relva
*
*    Funcao: Lista o Rateio de um Pacote pelo produto
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT IPA.CAD_IPA_ID,
	   PRD.CAD_PRD_DS_DESCRICAO,
       IPA.CAD_IPA_VL_ITEM_PACOTE,
       IPA.CAD_IPA_PC_RATEIO,
       IPA.CAD_IPA_VL_FINAL_PACOTE
FROM   TB_CAD_PRD_PRODUTO PRD,
       TB_CAD_IPA_ITEM_PACOTE IPA
WHERE  IPA.CAD_PRD_ID_ITEM_PACOTE = PRD.CAD_PRD_ID
AND    IPA.CAD_PRD_ID_PACOTE = pCAD_PRD_ID;     
       
io_cursor := v_cursor;
end PRC_CAD_IPA_RATEIO_S;
