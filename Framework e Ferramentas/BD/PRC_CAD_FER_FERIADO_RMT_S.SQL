

--PRC_CAD_FER_FERIADO_RMT_S
create or replace procedure PRC_CAD_FER_FERIADO_RMT_S 
(
     pCAD_FER_ID_FERIADO IN TB_CAD_FER_FERIADO.CAD_FER_ID_FERIADO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_FER_FERIADO_RMT_S
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
       CAD_FER_ID_FERIADO,
       CAD_UNI_ID_UNIDADE,
       CAD_FER_DT_FERIADO,
       CAD_FER_TP_FERIADO,
       CAD_FER_DS_FERIADO,
       CAD_FER_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
FROM TB_CAD_FER_FERIADO
WHERE
        CAD_FER_ID_FERIADO = pCAD_FER_ID_FERIADO;          
io_cursor := v_cursor;
end PRC_CAD_FER_FERIADO_RMT_S;
