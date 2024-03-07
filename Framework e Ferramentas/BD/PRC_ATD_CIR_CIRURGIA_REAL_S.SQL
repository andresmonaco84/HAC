create or replace procedure PRC_ATD_CIR_CIRURGIA_REAL_S
(
     pATD_CIR_ID IN TB_ATD_CIR_CIRURGIA_REALIZADA.ATD_CIR_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ATD_CIR_CIRURGIA_REAL_S 
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
       ATD_CIR_ID,
       ATD_ATE_ID,
       ATD_CIR_DT_INICIO_REALIZ,
       ATD_CIR_DT_FIM_REALIZ,
       ATD_CIR_HR_INICIO_REALIZ,
       ATD_CIR_HR_FIM_REALIZ,
       SEG_USU_ID_USU_CRIACAO,
       ATD_CIR_DT_CRIACAO,
       SEG_USU_ID_USU_ULT_ATUALIZ,
       ATD_CIR_DT_ULT_ATUALIZ,
       ATD_CIR_FL_SITUACAO,
       AGE_SAU_ID,
       CAD_PRO_ID_CIRURGIAO,
	   ATD_CIR_MOTIVO_CANCELAMENTO
FROM TB_ATD_CIR_CIRURGIA_REALIZADA
WHERE
        ATD_CIR_ID = pATD_CIR_ID;          
io_cursor := v_cursor;
end PRC_ATD_CIR_CIRURGIA_REAL_S ;