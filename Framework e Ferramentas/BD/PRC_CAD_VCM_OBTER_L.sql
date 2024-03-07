create or replace procedure PRC_CAD_VCM_OBTER_L
(
     pCAD_CNV_ID_CONVENIO     IN TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_CNV_ID_CONVENIO%type,
     pCAD_PRD_ID              IN TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_PRD_ID%type, 
     pTIS_MED_CD_TABELAMEDICA IN TB_CAD_VCM_VAL_COBR_MAT_MED.TIS_MED_CD_TABELAMEDICA%type,
     pCAD_PLA_ID_PLANO        IN TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_PLA_ID_PLANO%type,
     pCAD_TAP_TP_ATRIBUTO     IN TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_TAP_TP_ATRIBUTO%type,
     pCAD_CMM_CD_CARACMATMED  IN TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_CMM_CD_CARACMATMED%type,
     pDATACONSUMO             IN DATE,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_CAD_VCM_OBTER_L
*    Marcus Relva - 13/12/2010
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
       CAD_VCM_FL_UTILIZA_VL_CUSTO
FROM TB_CAD_VCM_VAL_COBR_MAT_MED
WHERE        
        -- Campos Obrigatprios
        (CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO) AND
        (CAD_TAP_TP_ATRIBUTO = pCAD_TAP_TP_ATRIBUTO) AND        
        --Campos Opcionais
        (CAD_PLA_ID_PLANO is null OR CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO) AND
        (CAD_PRD_ID is null OR CAD_PRD_ID = pCAD_PRD_ID) AND
        (TIS_MED_CD_TABELAMEDICA is null OR TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA) AND
        (CAD_CMM_CD_CARACMATMED is null OR CAD_CMM_CD_CARACMATMED = pCAD_CMM_CD_CARACMATMED) AND           
        --Validacoes     
        FNC_VALIDAR_VIGENCIA_DATA(CAD_VCM_DT_INICIO_VIGENCIA, CAD_VCM_DT_FIM_VIGENCIA, pDATACONSUMO) = 1 AND
        CAD_VCM_FL_STATUS = 'A';        
io_cursor := v_cursor;
end PRC_CAD_VCM_OBTER_L;
 