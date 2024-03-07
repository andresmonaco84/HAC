

--PRC_COB_CCP_CONTA_CONS_PARC_S
create or replace procedure PRC_COB_CCP_CONTA_CONS_PARC_S 
(
     pATD_ATE_ID IN TB_COB_CCP_CONTA_CONS_PARC.ATD_ATE_ID%type,
     pCAD_PAC_ID_PACIENTE IN TB_COB_CCP_CONTA_CONS_PARC.CAD_PAC_ID_PACIENTE%type,
     pCOB_CCP_ID IN TB_COB_CCP_CONTA_CONS_PARC.COB_CCP_ID%type,
     pCOB_COC_ID IN TB_COB_CCP_CONTA_CONS_PARC.COB_COC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_COB_CCP_CONTA_CONS_PARC_S
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
       COB_CCP_ID,
       COB_COC_ID,
       CAD_PAC_ID_PACIENTE,
       COB_CCP_DT_PARCELA,
       COB_CCP_HR_PARCELA,
       COB_CCP_VL_TOT_CONTA,
       COB_CCP_VL_TOT_DESCONTO,
       COB_CCP_PC_TOT_DESCONTO,
       ATD_GUI_CD_CODIGO,
       COB_CCP_MES_FAT,
       COB_CCP_ANO_FAT,
       COB_CCP_FL_STATUS,
       FAT_NOF_ID,
       COB_CCP_NR_REMESSA,
       COB_CCP_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       ATD_ATE_ID,
       COB_CCP_DT_PARCELA_INI,
       COB_CCP_HR_PARCELA_INI,
       CAD_CNV_ID_CONVENIO,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       ATD_ATE_TP_PACIENTE,
       ATD_GUI_DT_VALIDADE,
       ATD_GUI_CD_SENHA,
       CAD_PES_NM_PESSOA,
       COB_CCP_VL_IR_FATURADO,
       COB_CCP_VL_ISS_FATURADO,
       COB_CCP_VL_COFINS_FATURADO,
       COB_CCP_VL_CSLL_FATURADO,
       COB_CCP_VL_PIS_FATURADO,
       CAD_PAC_CD_CREDENCIAL,
       ATD_ATE_DT_ATENDIMENTO
FROM TB_COB_CCP_CONTA_CONS_PARC
WHERE
        ATD_ATE_ID = pATD_ATE_ID
    AND CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
    AND COB_CCP_ID = pCOB_CCP_ID
    AND COB_COC_ID = pCOB_COC_ID;          
io_cursor := v_cursor;
end PRC_COB_CCP_CONTA_CONS_PARC_S;
