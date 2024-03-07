

--PRC_CAD_PEC_PERCLME_R_S
create or replace procedure PRC_CAD_PEC_PERCLME_R_S 
(
     pCAD_PEC_ID IN TB_CAD_PEC_PERCLME.CAD_PEC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_PEC_PERCLME_R_S
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
       CAD_PEC_ID,
       CAD_CME_CLASSIF_MED,
       CAD_PEC_PC_CLASSIF_MED,
       CAD_PEC_PC_ICMS,
       CAD_PEC_DT_INICIO_VIGENCIA,
       CAD_PEC_DT_FIM_VIGENCIA,
       CAD_PEC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
FROM TB_CAD_PEC_PERCLME
WHERE
        CAD_PEC_ID = pCAD_PEC_ID;          
io_cursor := v_cursor;
end PRC_CAD_PEC_PERCLME_R_S;
