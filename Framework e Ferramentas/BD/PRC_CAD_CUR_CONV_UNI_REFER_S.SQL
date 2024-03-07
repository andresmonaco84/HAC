

--PRC_CAD_CUR_CONV_UNI_REFER_S
create or replace procedure PRC_CAD_CUR_CONV_UNI_REFER_S 
(
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CUR_CONV_UNI_REFER.CAD_CNV_ID_CONVENIO%type,
     pCAD_CUR_CD_REFERENCIADO IN TB_CAD_CUR_CONV_UNI_REFER.CAD_CUR_CD_REFERENCIADO%type,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_CUR_CONV_UNI_REFER.CAD_UNI_ID_UNIDADE%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_CUR_CONV_UNI_REFER_S
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
       CAD_CNV_ID_CONVENIO,
       CAD_UNI_ID_UNIDADE,
       CAD_CUR_CD_REFERENCIADO,
       CAD_CUR_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_CUR_FL_STATUS,
       CAD_SET_ID
FROM TB_CAD_CUR_CONV_UNI_REFER
WHERE
        CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
    AND CAD_CUR_CD_REFERENCIADO = pCAD_CUR_CD_REFERENCIADO
    AND CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE;          
io_cursor := v_cursor;
end PRC_CAD_CUR_CONV_UNI_REFER_S;
