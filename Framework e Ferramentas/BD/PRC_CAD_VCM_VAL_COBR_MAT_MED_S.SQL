create or replace procedure PRC_CAD_VCM_VAL_COBR_MAT_MED_S
(
     pCAD_VCM_ID IN TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_VCM_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_CAD_VCM_VAL_COBR_MAT_MED_S
*
*    Data Criacao:  data da  criação   Por: Nome do Analista
*    Data Alteracao: data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT
       CAD_VCM_ID,
       CAD_CNV_ID_CONVENIO,
       CAD_PRD_ID,
       CAD_VCM_FL_UTILIZA_VL_NF,
       TIS_MED_CD_TABELAMEDICA,
       CAD_VCM_VL_FIXO,
       CAD_VCM_VL_CUSTO,
       CAD_VCM_PC_MARGEM,
       CAD_VCM_FL_ISENTO_COBRANCA,
       CAD_VCM_DT_INICIO_VIGENCIA,
       CAD_VCM_DT_FIM_VIGENCIA,
       CAD_VCM_FL_INT_FRAC,
       CAD_VCM_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_VCM_VL_DIVISOR,
       CAD_TAP_TP_ATRIBUTO,
       CAD_CMM_CD_CARACMATMED,
       CAD_VCM_VL_FRACIONADO,
       CAD_VCM_VL_FINAL,
       CAD_VCM_FL_STATUS,
       CAD_VCM_VL_PRODUTO,
       CAD_PLA_ID_PLANO,
       CAD_VCM_FL_USORESTRITOMED,
       CAD_VCM_PC_TAXASERVMED,
       CAD_PRD_ID_TAXASERVMED,
       CAD_VCM_FL_UTILIZA_VL_CUSTO
FROM TB_CAD_VCM_VAL_COBR_MAT_MED
WHERE
        CAD_VCM_ID = pCAD_VCM_ID;
io_cursor := v_cursor;
end PRC_CAD_VCM_VAL_COBR_MAT_MED_S;
 