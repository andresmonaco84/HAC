--PRC_CAD_BAN_BANCO_S
create or replace procedure PRC_CAD_BAN_BANCO_S 
(
     pCAD_BAN_ID IN TB_CAD_BAN_BANCO.CAD_BAN_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_BAN_BANCO_S
* 
*    Data Criacao: 	12/8/2011   Por: Pedro
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT	
       CAD_BAN_ID,
       CAD_BAN_CD_BANCO,
       CAD_BAN_NM_BANCO,
       CAD_BAN_CD_BANCO_LEG,
       CAD_BAN_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       CAD_BAN_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO_ATUALIZ
FROM TB_CAD_BAN_BANCO
WHERE
        CAD_BAN_ID = pCAD_BAN_ID;          
io_cursor := v_cursor;
end PRC_CAD_BAN_BANCO_S;
/
