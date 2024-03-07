create or replace procedure PRC_CAD_AUT_AUTORIZADOR_S
(
     pCAD_AUT_ID IN TB_CAD_AUT_AUTORIZADOR.CAD_AUT_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_AUT_AUTORIZADOR_S
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
       CAD_AUT_ID,
       CAD_AUT_DS_DESCRICAO,
       CAD_AUT_FL_STATUS,
       SEG_USU_ID_USUARIO_CRIACAO,
       CAD_AUT_DT_CRIACAO,
       SEG_USU_ID_USUARIO_ATUALIZACAO,
       CAD_AUT_DT_ULTIMA_ATUALIZACAO
FROM TB_CAD_AUT_AUTORIZADOR
WHERE
        CAD_AUT_ID = pCAD_AUT_ID;          
io_cursor := v_cursor;
end PRC_CAD_AUT_AUTORIZADOR_S;
/
