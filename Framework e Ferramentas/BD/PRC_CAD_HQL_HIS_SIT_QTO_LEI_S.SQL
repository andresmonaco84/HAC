create or replace procedure PRC_CAD_HQL_HIS_SIT_QTO_LEI_S
(
     pCAD_HQL_ID IN TB_CAD_HQL_HIS_SIT_QTO_LEITO.CAD_HQL_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_CAD_HQL_HIS_SIT_QTO_LEI_S
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
       CAD_HQL_ID,
       CAD_QLE_ID,
       CAD_SQL_CD_SIT_QUARTO_LEITO,
       CAD_HQL_DT_HR_INICIO,
       CAD_HQL_DT_HR_FIM,
       SEG_USU_ID_USU_REG_INICIO,
       SEG_USU_ID_USU_REG_FIM,
	   CAD_HQL_DS_OBSERVACAO
FROM TB_CAD_HQL_HIS_SIT_QTO_LEITO
WHERE
        CAD_HQL_ID = pCAD_HQL_ID;
io_cursor := v_cursor;
end PRC_CAD_HQL_HIS_SIT_QTO_LEI_S;