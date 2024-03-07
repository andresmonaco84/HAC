

--PRC_ASS_PAT_PACIEATEND_R_D
create or replace procedure PRC_ASS_PAT_PACIEATEND_R_D 				
(
     pASS_PAT_DT_ENTRADA IN TB_ASS_PAT_PACIEATEND.ASS_PAT_DT_ENTRADA%type,
     pASS_PAT_HR_ENTRADA IN TB_ASS_PAT_PACIEATEND.ASS_PAT_HR_ENTRADA%type,
     pATD_ATE_ID IN TB_ASS_PAT_PACIEATEND.ATD_ATE_ID%type,
     pCAD_PAC_ID_PACIENTE IN TB_ASS_PAT_PACIEATEND.CAD_PAC_ID_PACIENTE%type	
)
is
/********************************************************************
*    Procedure: PRC_ASS_PAT_PACIEATEND_R_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ASS_PAT_PACIEATEND
WHERE  
        ASS_PAT_DT_ENTRADA = pASS_PAT_DT_ENTRADA
    AND ASS_PAT_HR_ENTRADA = pASS_PAT_HR_ENTRADA
    AND ATD_ATE_ID = pATD_ATE_ID
    AND CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE;	   
end PRC_ASS_PAT_PACIEATEND_R_D;
