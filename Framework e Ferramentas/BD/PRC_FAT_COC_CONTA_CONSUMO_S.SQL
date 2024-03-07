

--PRC_FAT_COC_CONTA_CONSUMO_S
create or replace procedure PRC_FAT_COC_CONTA_CONSUMO_S 
(
     pATD_ATE_ID IN TB_FAT_COC_CONTA_CONSUMO.ATD_ATE_ID%type,
     pCAD_PAC_ID_PACIENTE IN TB_FAT_COC_CONTA_CONSUMO.CAD_PAC_ID_PACIENTE%type,
     pFAT_COC_ID IN TB_FAT_COC_CONTA_CONSUMO.FAT_COC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_FAT_COC_CONTA_CONSUMO_S
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
       FAT_COC_ID,
       FAT_COC_TP_DESTINO_CONTA,
       ATD_ATE_ID,
       CAD_PAC_ID_PACIENTE,
       FAT_COC_VL_TOTAL_ORIGINAL,
       FAT_COC_PC_DESCONTO,
       FAT_COC_VL_DESCONTO,
       FAT_COC_VL_TOTAL_CONTA,
       FAT_COC_DT_INI_CONSUMO,
       FAT_COC_HR_INI_CONSUMO,
       FAT_COC_DT_FIM_CONSUMO,
       FAT_COC_HR_FIM_CONSUMO,
       FAT_COC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       FAT_COC_FL_STATUS
FROM TB_FAT_COC_CONTA_CONSUMO
WHERE
        ATD_ATE_ID = pATD_ATE_ID
    AND CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
    AND FAT_COC_ID = pFAT_COC_ID;          
io_cursor := v_cursor;
end PRC_FAT_COC_CONTA_CONSUMO_S;
