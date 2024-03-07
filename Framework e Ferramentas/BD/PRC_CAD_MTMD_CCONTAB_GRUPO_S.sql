 create or replace procedure PRC_CAD_MTMD_CCONTAB_GRUPO_S
(
     pCAD_MTMD_COD_COLIGADA IN TB_CAD_MTMD_CCONTAB_GRUPO.CAD_MTMD_COD_COLIGADA%type,
     pCAD_MTMD_DT_INI_VIG IN TB_CAD_MTMD_CCONTAB_GRUPO.CAD_MTMD_DT_INI_VIG%type,
     pCAD_MTMD_GRUPO_ID IN TB_CAD_MTMD_CCONTAB_GRUPO.CAD_MTMD_GRUPO_ID%type,
     pCAD_MTMD_TIPO_MOV IN TB_CAD_MTMD_CCONTAB_GRUPO.CAD_MTMD_TIPO_MOV%type,
     pCAD_SET_ID IN TB_CAD_MTMD_CCONTAB_GRUPO.CAD_SET_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_CAD_MTMD_CCONTAB_GRUPO_S
*
*    Data Criacao: 	31/01/2012   Por: André S. Monaco
*
*    Funcao: Selecionar conta do grupo
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT
       CAD_MTMD_TIPO_MOV,
       CAD_MTMD_GRUPO_ID,
       CAD_MTMD_DT_INI_VIG,
       CAD_MTMD_DT_FIM_VIG,
       CAD_MTMD_COD_COLIGADA,
       CAD_SET_ID,
       CAD_COD_CONTA_CRED,
       CAD_COD_CONTA_CRED_DESCRICAO,
       CAD_COD_CONTA_DEB,
       CAD_COD_CONTA_DEB_DESCRICAO,
       SEG_DT_ATUALIZACAO,
       SEG_USU_ID_USUARIO
FROM TB_CAD_MTMD_CCONTAB_GRUPO
WHERE
        CAD_MTMD_COD_COLIGADA = pCAD_MTMD_COD_COLIGADA
    AND CAD_MTMD_DT_INI_VIG = pCAD_MTMD_DT_INI_VIG
    AND CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID
    AND CAD_MTMD_TIPO_MOV = pCAD_MTMD_TIPO_MOV
    AND CAD_SET_ID = pCAD_SET_ID;
io_cursor := v_cursor;
end PRC_CAD_MTMD_CCONTAB_GRUPO_S;
