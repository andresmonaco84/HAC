

--PRC_CAD_CCR_CCONTA_RM_S
create or replace procedure PRC_CAD_CCR_CCONTA_RM_S 
(
     pCAD_CCR_ID IN TB_CAD_CCR_CCONTA_RM.CAD_CCR_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_CCR_CCONTA_RM_S
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
       CAD_CCR_ID,
       CAD_CCR_CD_COLIGADA,
       CAD_CCR_CD_CONTA,
       CAD_CCR_CD_REDUZIDO,
       CAD_CCR_DS_DESCRICAO,
       CAD_CCR_FL_ANALIT_SINT,
       CAD_CCR_FL_RATEIO,
       CAD_CCR_FL_NATUREZA,
       CAD_CCR_FL_STATUS,
       SEG_USU_ID_INCLUSAO,
       CAD_CCR_DT_INCLUSAO,
       SEG_USU_ID_ALTERACAO,
       CAD_CCR_DT_ALTERACAO
FROM TB_CAD_CCR_CCONTA_RM
WHERE
        CAD_CCR_ID = pCAD_CCR_ID;          
io_cursor := v_cursor;
end PRC_CAD_CCR_CCONTA_RM_S;
