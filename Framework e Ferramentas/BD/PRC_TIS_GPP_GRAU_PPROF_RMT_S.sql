create or replace procedure PRC_TIS_GPP_GRAU_PPROF_RMT_S
(
     pTIS_GPP_CD_GRAU_PART_PROF IN TB_TIS_GPP_GRAU_PART_PROF.TIS_GPP_CD_GRAU_PART_PROF%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_TIS_GPP_GRAU_PPROF_RMT_S
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
       TIS_GPP_CD_GRAU_PART_PROF,
       TIS_GPP_DS_GRAU_PART_PROF,
       TIS_GPP_PC_GRAU_PART_PROF,
       TIS_GPP_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
	     TIS_GPP_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO

FROM TB_TIS_GPP_GRAU_PART_PROF
WHERE
        TIS_GPP_CD_GRAU_PART_PROF = pTIS_GPP_CD_GRAU_PART_PROF;
io_cursor := v_cursor;
end PRC_TIS_GPP_GRAU_PPROF_RMT_S;