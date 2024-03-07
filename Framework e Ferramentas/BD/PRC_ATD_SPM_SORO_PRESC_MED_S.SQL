create or replace procedure PRC_ATD_SPM_SORO_PRESC_MED_S
(
     pATD_SPM_ID IN TB_ATD_SPM_SORO_PRESC_MED.ATD_SPM_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ATD_SPM_SORO_PRESC_MED_S
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
       ATD_SPM_ID,
       ATD_PME_ID,
       ATD_SPM_DS_DESCRICAO,
       ATD_SPM_DS_VIA,
       ATD_SPM_DS_INTERVALO,
       ATD_SPM_DS_OBSERVACAO,
       ATD_SPM_DT_HORA_CRIACAO,
       ATD_SPM_ID_USU_CRIACAO,
       ATD_SPM_DT_ULT_ATUALIZ,
       ATD_SPM_ID_USU_ULT_ATUALIZ,
       ATD_SPM_CD_VIA
FROM TB_ATD_SPM_SORO_PRESC_MED
WHERE
        ATD_SPM_ID = pATD_SPM_ID;
io_cursor := v_cursor;
end PRC_ATD_SPM_SORO_PRESC_MED_S;
