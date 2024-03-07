create or replace procedure PRC_CAD_PRD_PRODUTO_SMM_R_L
(
     pCAD_PRD_NM_MNEMONICO IN TB_CAD_PRD_PRODUTO.CAD_PRD_NM_MNEMONICO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_CAD_PRD_PRODUTO_SMM_R_L
*
*    Data Criacao:   data da  criação   Por: Nome do Analista
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT
       CAD_PRD_ID,
       CAD_PRD_NM_MNEMONICO,
       CAD_PRD_DS_DESCRICAO
FROM TB_CAD_PRD_PRODUTO
WHERE
       TIS_MED_CD_TABELAMEDICA IN ('95','96') AND
       (pCAD_PRD_NM_MNEMONICO is null OR CAD_PRD_NM_MNEMONICO = pCAD_PRD_NM_MNEMONICO) AND       
       CAD_PRD_FL_STATUS = 'A';
io_cursor := v_cursor;
end PRC_CAD_PRD_PRODUTO_SMM_R_L;
