

--PRC_FAT_CCP_CONTA_CONS_PARC_S
create or replace procedure PRC_FAT_CCP_CONTA_CONS_PARC_S 
(
     pATD_ATE_ID IN TB_FAT_CCP_CONTA_CONS_PARC.ATD_ATE_ID%type,
     pCAD_PAC_ID_PACIENTE IN TB_FAT_CCP_CONTA_CONS_PARC.CAD_PAC_ID_PACIENTE%type,
     pFAT_CCP_ID IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ID%type,
     pFAT_COC_ID IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_COC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_FAT_CCP_CONTA_CONS_PARC_S
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
       FAT_CCP_ID,
       FAT_COC_ID,
       CAD_PAC_ID_PACIENTE,
       FAT_CCP_DT_PARCELA,
       FAT_CCP_HR_PARCELA,
       FAT_CCP_VL_TOT_ORIGINAL,
       FAT_CCP_VL_TOT_CONTA,
       FAT_CCP_VL_TOT_DESCONTO,
       FAT_CCP_PC_TOT_DESCONTO,
       ATD_GUI_CD_CODIGO,
       FAT_CCP_FL_EMITIDA,
       FAT_CCP_FL_FATURADA,
       FAT_CCP_MES_FAT,
       FAT_CCP_ANO_FAT,
       FAT_CCP_MES_COMPET,
       FAT_CCP_ANO_COMPET,
       FAT_CCP_FL_STATUS,
       FAT_CCP_DT_CANCELAMENTO,
       FAT_NOF_ID,
       FAT_CCP_FL_ENVIO_ONLINE,
       FAT_CCP_NR_REMESSA,
       FAT_CCP_DT_FATURAMENTO,
       FAT_CCP_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       TIS_MSI_CD_MOTIVOSAIDAINT,
       FAT_LNF_ID,
       ATD_ATE_ID,
       FAT_CCP_DT_PARCELA_INI,
       FAT_CCP_HR_PARCELA_INI,
       FAT_CCP_FL_STATUS_AUDIT,
       FAT_CCP_DT_ENVIO_AUDIT,
       CAD_CNV_ID_CONVENIO,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       ATD_ATE_TP_PACIENTE,
       CAD_PLA_ID_PLANO,
       ATD_GUI_DT_VALIDADE,
       ATD_GUI_CD_SENHA,
       CAD_TPE_CD_CODIGO
FROM TB_FAT_CCP_CONTA_CONS_PARC
WHERE
        ATD_ATE_ID = pATD_ATE_ID
    AND CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
    AND FAT_CCP_ID = pFAT_CCP_ID
    AND FAT_COC_ID = pFAT_COC_ID;          
io_cursor := v_cursor;
end PRC_FAT_CCP_CONTA_CONS_PARC_S;
