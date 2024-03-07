

--PRC_FAT_CCP_CONTA_CONS_PARC_D
create or replace procedure PRC_FAT_CCP_CONTA_CONS_PARC_D 
(
     pATD_ATE_ID IN TB_FAT_CCP_CONTA_CONS_PARC.ATD_ATE_ID%type,
     pCAD_PAC_ID_PACIENTE IN TB_FAT_CCP_CONTA_CONS_PARC.CAD_PAC_ID_PACIENTE%type,
     pFAT_CCP_ID IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ID%type,
     pFAT_COC_ID IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_COC_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_FAT_CCP_CONTA_CONS_PARC_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_FAT_CCP_CONTA_CONS_PARC
WHERE  
        ATD_ATE_ID = pATD_ATE_ID
    AND CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
    AND FAT_CCP_ID = pFAT_CCP_ID
    AND FAT_COC_ID = pFAT_COC_ID;	   
end PRC_FAT_CCP_CONTA_CONS_PARC_D;
