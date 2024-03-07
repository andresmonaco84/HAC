CREATE OR REPLACE PROCEDURE PRC_FAT_CCI_DESMARCAR_CPARC_U
(
    pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE,
    pCAD_PAC_ID_PACIENTE IN TB_CAD_PAC_PACIENTE.CAD_PAC_ID_PACIENTE%TYPE,    
    pFAT_CCP_ID IN TB_FAT_CCI_CONTA_CONSU_ITEM.FAT_CCP_ID%TYPE,
    pFAT_COC_ID IN TB_FAT_CCI_CONTA_CONSU_ITEM.FAT_COC_ID%TYPE
)
IS
/********************************************************************
*    Procedure: PRC_FAT_CCI_DESMARCAR_CPARC_U
*******************************************************************/
BEGIN

-- Desmarcar Itens de Consumo          
UPDATE TB_FAT_CCI_CONTA_CONSU_ITEM CCI
SET CCI.FAT_CCP_ID = NULL
WHERE CCI.FAT_CCP_ID = pFAT_CCP_ID
AND CCI.FAT_COC_ID = pFAT_COC_ID
AND CCI.ATD_ATE_ID = pATD_ATE_ID
AND CCI.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE;

-- Deletar Parcelas
DELETE TB_FAT_CCP_CONTA_CONS_PARC CCP
WHERE CCP.FAT_CCP_ID = pFAT_CCP_ID
AND CCP.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
AND CCP.ATD_ATE_ID = pATD_ATE_ID
AND CCP.FAT_COC_ID = pFAT_COC_ID;
  
END PRC_FAT_CCI_DESMARCAR_CPARC_U;
