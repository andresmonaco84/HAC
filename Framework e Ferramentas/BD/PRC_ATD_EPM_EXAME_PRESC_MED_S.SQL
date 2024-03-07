create or replace procedure PRC_ATD_EPM_EXAME_PRESC_MED_S
(
     pATD_EPM_ID IN TB_ATD_EPM_EXAME_PRESC_MED.ATD_EPM_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ATD_EPM_EXAME_PRESC_MED_S
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
       ATD_EPM_ID,
       ATD_PME_ID,
       ATD_EPM_DS_EXAME,
       ATD_EPM_DS_OBSERVACAO,
       ATD_EPM_DT_HORA_CRIACAO,
       ATD_EPM_ID_USU_CRIACAO,
       ATD_EPM_DT_ULT_ATUALIZ,
       ATD_EPM_ID_USU_ULT_ATUALIZ,
       ATD_EPM_STATUS,
       ATD_EPM_FL_IMPRESSO

FROM TB_ATD_EPM_EXAME_PRESC_MED a
WHERE
        ATD_EPM_ID = pATD_EPM_ID;
io_cursor := v_cursor;
end PRC_ATD_EPM_EXAME_PRESC_MED_S;
