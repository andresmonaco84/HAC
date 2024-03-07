create or replace procedure PRC_CAD_TMC_TIPO_MOV_COB_S
(
     pCAD_TMC_ID IN TB_CAD_TMC_TIPO_MOV_COBRANCA.CAD_TMC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_CAD_TMC_TIPO_MOV_COB_S
*
*    Data Criacao: 	30/03/2012   Por: André
*
*    Funcao: Pesquisa tipo movimento cobrança
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT
       CAD_TMC_ID,
       CAD_TMC_DS_DESCRICAO,
       CAD_TMC_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       CAD_TMC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO_ATUALIZ
FROM TB_CAD_TMC_TIPO_MOV_COBRANCA
WHERE
        CAD_TMC_ID = pCAD_TMC_ID;
io_cursor := v_cursor;
end PRC_CAD_TMC_TIPO_MOV_COB_S;
