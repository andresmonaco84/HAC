create or replace procedure PRC_ATD_DPM_DIETA_PRESC_MED_S
(
     pATD_DPM_ID IN TB_ATD_DPM_DIETA_PRESC_MED.ATD_DPM_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ATD_DPM_DIETA_PRESC_MED_S
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
       ATD_DPM_ID,
       ATD_PME_ID,
       ATD_DPM_DS_DIETA,
       ATD_DPM_DS_OBSERVACAO,
       ATD_DPM_DT_HORA_CRIACAO,
       ATD_DPM_ID_USU_CRIACAO,
       ATD_DPM_DT_ULT_ATUALIZ,
       ATD_DPM_ID_USU_ULT_ATUALIZ,
       ATD_DPM_STATUS,
       ATD_DPM_FL_IMPRESSO,
       CAD_MTMD_ID
       
FROM TB_ATD_DPM_DIETA_PRESC_MED
WHERE
        ATD_DPM_ID = pATD_DPM_ID;
io_cursor := v_cursor;
end PRC_ATD_DPM_DIETA_PRESC_MED_S;
