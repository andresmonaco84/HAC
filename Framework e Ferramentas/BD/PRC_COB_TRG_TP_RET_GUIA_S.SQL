

--PRC_COB_TRG_TP_RET_GUIA_S
create or replace procedure PRC_COB_TRG_TP_RET_GUIA_S 
(
     pCAD_CNV_ID_CONVENIO IN TB_COB_TRG_TIPO_RETENCAO_GUIA.CAD_CNV_ID_CONVENIO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_COB_TRG_TP_RET_GUIA_S
* 
*    Data Criacao: 	13/06/2012   Por: Pedro
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
       COB_TRG_TP_RETENCAO,
       COB_TRG_DT_INI_VIGENCIA,
       COB_TRG_DT_FIM_VIGENCIA,
       SEG_USU_ID_USUARIO_CRIACAO,
       COB_TRG_DT_CRIACAO,
       SEG_USU_ID_USUARIO_ATUALIZ,
       COB_TRG_DT_ULTIMA_ATUALIZ
FROM TB_COB_TRG_TIPO_RETENCAO_GUIA
WHERE
        CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO;          
io_cursor := v_cursor;
end PRC_COB_TRG_TP_RET_GUIA_S;
