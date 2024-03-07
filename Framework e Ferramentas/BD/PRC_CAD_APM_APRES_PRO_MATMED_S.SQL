

--PRC_CAD_APM_APRES_PRO_MATMED_S
create or replace procedure PRC_CAD_APM_APRES_PRO_MATMED_S 
(
     pCAD_APM_ID_MATMED IN TB_CAD_APM_APRES_PRO_MATMED.CAD_APM_ID_MATMED%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_APM_APRES_PRO_MATMED_S
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
       CAD_APM_ID_MATMED,
       CAD_APM_DS_PRODUTO,
       CAD_APM_FL_STATUS,
       CAD_APM_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
FROM TB_CAD_APM_APRES_PRO_MATMED
WHERE
        CAD_APM_ID_MATMED = pCAD_APM_ID_MATMED;          
io_cursor := v_cursor;
end PRC_CAD_APM_APRES_PRO_MATMED_S;
