

--PRC_FAT_AFR_ATEND_FATUR_RES_D
create or replace procedure PRC_FAT_AFR_ATEND_FATUR_RES_D 
(
     pATD_ATE_ID IN TB_FAT_AFR_ATEND_FATUR_RES.ATD_ATE_ID%type,
     pCAD_PAC_ID_PACIENTE IN TB_FAT_AFR_ATEND_FATUR_RES.CAD_PAC_ID_PACIENTE%type,
     pCAD_TAP_TP_ATRIBUTO IN TB_FAT_AFR_ATEND_FATUR_RES.CAD_TAP_TP_ATRIBUTO%type,
     pFAT_CCP_ID IN TB_FAT_AFR_ATEND_FATUR_RES.FAT_CCP_ID%type,
     pFAT_COC_ID IN TB_FAT_AFR_ATEND_FATUR_RES.FAT_COC_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_FAT_AFR_ATEND_FATUR_RES_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_FAT_AFR_ATEND_FATUR_RES
WHERE  
        ATD_ATE_ID = pATD_ATE_ID
    AND CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
    AND CAD_TAP_TP_ATRIBUTO = pCAD_TAP_TP_ATRIBUTO
    AND FAT_CCP_ID = pFAT_CCP_ID
    AND FAT_COC_ID = pFAT_COC_ID;	   
end PRC_FAT_AFR_ATEND_FATUR_RES_D;
