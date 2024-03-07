

--PRC_CAD_PRA_PRODUT_AUTOM_S
create or replace procedure PRC_CAD_PRA_PRODUT_AUTOM_S 
(
     pCAD_PRA_ID IN TB_CAD_PRA_PRODUT_AUTOM.CAD_PRA_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_PRA_PRODUT_AUTOM_S
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
       CAD_PRA_ID,
       CAD_PRD_ID,
       CAD_PRD_ID_PRO_ASS,
       CAD_PRA_DT_INICIO_VIGENCIA,
       CAD_PRA_DT_FIM_VIGENCIA,
       CAD_PRA_FL_STATUS,
       CAD_PRA_QT_PRO_ASS,
       CAD_PRA_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_PRA_QT_MULT_ASS,
       CAD_CNV_ID_CONVENIO,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
	   CAD_PRA_FL_HORAEXTRA
FROM TB_CAD_PRA_PRODUT_AUTOM
WHERE
        CAD_PRA_ID = pCAD_PRA_ID;          
io_cursor := v_cursor;
end PRC_CAD_PRA_PRODUT_AUTOM_S;
