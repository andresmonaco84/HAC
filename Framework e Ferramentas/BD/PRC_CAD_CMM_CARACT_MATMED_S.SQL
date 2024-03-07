

--PRC_CAD_CMM_CARACT_MATMED_S
create or replace procedure PRC_CAD_CMM_CARACT_MATMED_S 
(
     pCAD_CMM_CD_CARACMATMED IN TB_CAD_CMM_CARACT_MATMED.CAD_CMM_CD_CARACMATMED%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_CMM_CARACT_MATMED_S
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
       CAD_CMM_CD_CARACMATMED,
       CAD_CMM_DS_CARACMATMED,
       CAD_CMM_FL_STATUS,
       CAD_CMM_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
FROM TB_CAD_CMM_CARACT_MATMED
WHERE
        CAD_CMM_CD_CARACMATMED = pCAD_CMM_CD_CARACMATMED;          
io_cursor := v_cursor;
end PRC_CAD_CMM_CARACT_MATMED_S;
