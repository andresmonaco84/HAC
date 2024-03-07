create or replace procedure PRC_ATD_PKT_PRESCRICAO_KIT_S
(
     pATD_PKT_ID IN TB_ATD_PKT_PRESCRICAO_KIT.ATD_PKT_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ATD_PKT_PRESCRICAO_KIT_S
*
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT
       ATD_PKT_ID,
       ATD_PKT_KIT_STATUS,
       ATD_PKT_DESCRICAO,
       ATD_PKT_ID_USU_ULT_ATUALIZ,
       ATD_PKT_DT_ULT_ATUALIZ,
       CAD_SET_ID,

       ATD_PKT_FL_INT_ALA,
       ATD_PKT_FL_INT_UTI,
       ATD_PKT_FL_INT_ADULTO,
       ATD_PKT_FL_INT_NEO
FROM TB_ATD_PKT_PRESCRICAO_KIT
WHERE
        ATD_PKT_ID = pATD_PKT_ID;
io_cursor := v_cursor;
end PRC_ATD_PKT_PRESCRICAO_KIT_S;
