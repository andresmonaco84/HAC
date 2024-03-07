

--PRC_ASS_PPG_PAC_ATE_GUIA_R_D
create or replace procedure PRC_ASS_PPG_PAC_ATE_GUIA_R_D 
(
     pASS_PAP_ID IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.ASS_PAP_ID%type,
     pATD_ATE_ID IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.ATD_ATE_ID%type,
     pATE_GUI_CD_CODIGO IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.ATE_GUI_CD_CODIGO%type,
     pATE_GUI_DT_VALIDADE IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.ATE_GUI_DT_VALIDADE%type,
     pCAD_PAC_ID_PACIENTE IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.CAD_PAC_ID_PACIENTE%type,
     pCAD_PRD_ID IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.CAD_PRD_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ASS_PPG_PAC_ATE_GUIA_R_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ASS_PPG_PAC_ATE_PROC_GUIA
WHERE  
        ASS_PAP_ID = pASS_PAP_ID
    AND ATD_ATE_ID = pATD_ATE_ID
    AND ATE_GUI_CD_CODIGO = pATE_GUI_CD_CODIGO
    AND ATE_GUI_DT_VALIDADE = pATE_GUI_DT_VALIDADE
    AND CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
    AND CAD_PRD_ID = pCAD_PRD_ID;	   
end PRC_ASS_PPG_PAC_ATE_GUIA_R_D;
