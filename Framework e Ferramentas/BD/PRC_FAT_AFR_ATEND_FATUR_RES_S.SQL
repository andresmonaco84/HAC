

--PRC_FAT_AFR_ATEND_FATUR_RES_S
create or replace procedure PRC_FAT_AFR_ATEND_FATUR_RES_S 
(
     pATD_ATE_ID IN TB_FAT_AFR_ATEND_FATUR_RES.ATD_ATE_ID%type,
     pCAD_PAC_ID_PACIENTE IN TB_FAT_AFR_ATEND_FATUR_RES.CAD_PAC_ID_PACIENTE%type,
     pCAD_TAP_TP_ATRIBUTO IN TB_FAT_AFR_ATEND_FATUR_RES.CAD_TAP_TP_ATRIBUTO%type,
     pFAT_CCP_ID IN TB_FAT_AFR_ATEND_FATUR_RES.FAT_CCP_ID%type,
     pFAT_COC_ID IN TB_FAT_AFR_ATEND_FATUR_RES.FAT_COC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_FAT_AFR_ATEND_FATUR_RES_S
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
       ATD_ATE_TP_PACIENTE,
       ATD_ATE_ID,
       FAT_CCP_ID,
       FAT_AFR_NR_MESFAT,
       FAT_AFR_NR_ANOFAT,
       CAD_TAP_TP_ATRIBUTO,
       FAT_AFR_VL_TOT_PRODUTO,
       FAT_AFR_VL_TOT_FATURADO,
       FAT_AFR_VL_ACRESCIMO,
       FAT_AFR_VL_DESCONTO,
       FAT_NOF_ID,
       SEG_USU_ID_USUARIO,
       FAT_AFR_DT_ULTIMA_ATUALIZACAO,
       FAT_AFR_FL_STATUS,
       FAT_COC_ID,
       CAD_PAC_ID_PACIENTE,
       FAT_LNF_ID,
       CAD_CNV_ID_CONVENIO,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_TPE_CD_CODIGO
FROM TB_FAT_AFR_ATEND_FATUR_RES
WHERE
        ATD_ATE_ID = pATD_ATE_ID
    AND CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
    AND CAD_TAP_TP_ATRIBUTO = pCAD_TAP_TP_ATRIBUTO
    AND FAT_CCP_ID = pFAT_CCP_ID
    AND FAT_COC_ID = pFAT_COC_ID;          
io_cursor := v_cursor;
end PRC_FAT_AFR_ATEND_FATUR_RES_S;
