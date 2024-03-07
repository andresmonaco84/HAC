create or replace procedure PRC_CAD_IND_INDICADOR_S
(
     pCAD_IND_ID IN TB_CAD_IND_INDICADOR.CAD_IND_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_CAD_IND_INDICADOR_S
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
       CAD_IND_ID,
       CAD_IND_DS_CODIGO,
       CAD_IND_DS_DESCRICAO,
       CAD_IND_DS_GRUPO,
       CAD_IND_DS_TIPOUSUARIO,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_SET_ID,
       SEG_USU_ID_USUARIO,
       CAD_IND_DT_ULTIMA_ATUALIZACAO,
       CAD_IND_DS_PERIODO,
       CAD_IND_DS_TIPO_INFO,
       CAD_IND_VL_MIN,
       CAD_IND_VL_MAX,
       CAD_IND_DS_OPCOES
FROM TB_CAD_IND_INDICADOR
WHERE
        CAD_IND_ID = pCAD_IND_ID;
io_cursor := v_cursor;
end PRC_CAD_IND_INDICADOR_S;
