

--PRC_FAT_TCS_COMANDA_SET_CC_S
create or replace procedure PRC_FAT_TCS_COMANDA_SET_CC_S 
(
     pCAD_SET_ID IN TB_FAT_TCS_COMANDA_SET_CC.CAD_SET_ID%type,
     pFAT_TCO_ID IN TB_FAT_TCS_COMANDA_SET_CC.FAT_TCO_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_FAT_TCS_COMANDA_SET_CC_S
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
       FAT_TCO_ID,
       FAT_TCS_FL_STATUS,
       FAT_TCS_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_SET_ID
FROM TB_FAT_TCS_COMANDA_SET_CC
WHERE
        CAD_SET_ID = pCAD_SET_ID
    AND FAT_TCO_ID = pFAT_TCO_ID;          
io_cursor := v_cursor;
end PRC_FAT_TCS_COMANDA_SET_CC_S;
