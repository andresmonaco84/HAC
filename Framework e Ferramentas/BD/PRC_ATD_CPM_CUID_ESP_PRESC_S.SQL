create or replace procedure PRC_ATD_CPM_CUID_ESP_PRESC_S
(
     pATD_CPM_ID IN TB_ATD_CPM_CUID_ESP_PRESC_MED.ATD_CPM_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ATD_CPM_CUID_ESP_PRESC_MED_S
*
*    Data Criacao: 	data da  cria??o   Por: Nome do Analista
*    Data Alteracao:	data da altera??o  Por: Nome do Analista
*
*    Funcao: Descri??o da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT
       ATD_CPM_ID,
       ATD_PME_ID,
       ATD_CPM_DS_CUIDADO_ESPEC,
       ATD_CPM_DS_OBSERVACAO,
       ATD_CPM_DT_HORA_CRIACAO,
       ATD_CPM_ID_USU_CRIACAO,
       ATD_CPM_DT_ULT_ATUALIZ,
       ATD_CPM_ID_USU_ULT_ATUALIZ,
       ATD_CPM_STATUS,
       ATD_CPM_FL_IMPRESSO,
    ATD_CPM_TP_CUIDADO 
FROM TB_ATD_CPM_CUID_ESP_PRESC_MED
WHERE
        ATD_CPM_ID = pATD_CPM_ID;
io_cursor := v_cursor;
end PRC_ATD_CPM_CUID_ESP_PRESC_S;
