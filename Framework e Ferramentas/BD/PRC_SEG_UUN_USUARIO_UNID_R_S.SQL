--PRC_SEG_UUN_USUARIO_UNID_R_S
create or replace procedure PRC_SEG_UUN_USUARIO_UNID_R_S 
(
     pCAD_UNI_ID_UNIDADE IN TB_SEG_UUN_USUARIO_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pSEG_USU_ID_USUARIO IN TB_SEG_UUN_USUARIO_UNIDADE.SEG_USU_ID_USUARIO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_SEG_UUN_USUARIO_UNID_R_S
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
       SEG_USU_ID_USUARIO,
       CAD_UNI_ID_UNIDADE
FROM TB_SEG_UUN_USUARIO_UNIDADE
WHERE
        CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
    AND SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO;          
io_cursor := v_cursor;
end PRC_SEG_UUN_USUARIO_UNID_R_S;

