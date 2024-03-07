create or replace procedure PRC_ATD_PPI_PROF_PROCED_INT_S
(
     pATD_PPI_ID IN TB_ATD_PPI_PROF_PROCED_INT.ATD_PPI_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ATD_PPI_PROF_PROCED_INT_S
*
*    Data Criacao:  data da  cria??o   Por: Nome do Analista
*    Data Alteracao:  data da altera??o  Por: Nome do Analista
*
*    Funcao: Descri??o da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT
       ATD_PPI_ID,
       ATD_ATE_ID,
       CAD_PRO_ID_PROFISSIONAL,
       TIS_CBO_CD_CBOS,
       CAD_PRD_ID,
       ATD_PPI_QT_REAL,
       ATD_PPI_DT_REAL,
       ATD_PPI_HR_REAL,
       SEG_USU_ID_USUARIO,
       ATD_PPI_DT_ULTIMA_ATUALIZACAO,
       ATD_PPI_FL_STATUS,
       ATD_PPI_FL_ATUALIZADO_LANCAM,
       ATD_PPI_DT_ATUALIZA_LANCAM,
       ATD_PPI_DS_OBSERVACAO,
       CAD_SET_SETOR
FROM TB_ATD_PPI_PROF_PROCED_INT
WHERE
        ATD_PPI_ID = pATD_PPI_ID;
io_cursor := v_cursor;
end PRC_ATD_PPI_PROF_PROCED_INT_S;
