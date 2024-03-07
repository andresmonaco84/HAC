

--PRC_CAD_TAN_TIPO_ANESTESIA_S
create or replace procedure PRC_CAD_TAN_TIPO_ANESTESIA_S 
(
     pCAD_TAN_TP_ANESTESIA IN TB_CAD_TAN_TIPO_ANESTESIA.CAD_TAN_TP_ANESTESIA%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_TAN_TIPO_ANESTESIA_S
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
       CAD_TAN_TP_ANESTESIA,
       CAD_TAN_DS_ANESTESIA,
       CAD_TAN_FL_STATUS,
       CAD_TAN_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
FROM TB_CAD_TAN_TIPO_ANESTESIA
WHERE
        CAD_TAN_TP_ANESTESIA = pCAD_TAN_TP_ANESTESIA;          
io_cursor := v_cursor;
end PRC_CAD_TAN_TIPO_ANESTESIA_S;
