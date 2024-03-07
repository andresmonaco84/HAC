create or replace procedure PRC_ATD_PHE_PRESC_HEM_ENF_S
(
     pATD_PHE_ID IN TB_ATD_PHE_PRESC_HEM_ENF.ATD_PHE_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ATD_PHE_PRESC_HEM_ENF_S
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
       ATD_PME_ID,
       ATD_PHE_HORA,
       ATD_PHE_VL_PASIS,
       ATD_PHE_VL_PULSO,
       ATD_PHE_VL_DOR,
       ATD_PHE_VL_GLICCAP,
       ATD_PHE_VL_PADIS,
       ATD_PHE_ID_USU_CRIACAO,
       ATD_PHE_DT_CRIACAO,
       ATD_PHE_ID_USU_ATUALIZ,
       ATD_PHE_DT_ULT_ATUALIZ,
       ATD_PHE_ID,
       ATD_PHE_VL_TEMPINI,
       ATD_PHE_VL_TEMPFIM,
       ATD_PHE_VL_PESO
FROM TB_ATD_PHE_PRESC_HEM_ENF
WHERE
        ATD_PHE_ID = pATD_PHE_ID;
io_cursor := v_cursor;
end PRC_ATD_PHE_PRESC_HEM_ENF_S;
