

--PRC_ASS_PPG_PAC_ATE_GUIA_R_S
create or replace procedure PRC_ASS_PPG_PAC_ATE_GUIA_R_S 
(
     pASS_PAP_ID IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.ASS_PAP_ID%type,
     pATD_ATE_ID IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.ATD_ATE_ID%type,
     pATE_GUI_CD_CODIGO IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.ATE_GUI_CD_CODIGO%type,
     pATE_GUI_DT_VALIDADE IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.ATE_GUI_DT_VALIDADE%type,
     pCAD_PAC_ID_PACIENTE IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.CAD_PAC_ID_PACIENTE%type,
     pCAD_PRD_ID IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.CAD_PRD_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ASS_PPG_PAC_ATE_GUIA_R_S
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
       SEG_USU_ID_USUARIO,
       ASS_PPG_DT_ULTIMA_ATUALIZACAO,
       ATE_GUI_CD_CODIGO,
       ATE_GUI_DT_VALIDADE,
       ATD_ATE_ID,
       CAD_PRD_ID,
       CAD_PAC_ID_PACIENTE,
       ASS_PPG_CD_SENHA,
       ASS_PPG_CD_SENHA_AUTORIZADOR,
       ASS_PPG_DT_VALIDADE_SENHA,
       ASS_PAP_ID,
       ASS_PPG_DT_EMISSAOGUIA,
       ASS_PPG_DT_AUTORIZGUIA
FROM TB_ASS_PPG_PAC_ATE_PROC_GUIA
WHERE
        ASS_PAP_ID = pASS_PAP_ID
    AND ATD_ATE_ID = pATD_ATE_ID
    AND ATE_GUI_CD_CODIGO = pATE_GUI_CD_CODIGO
    AND ATE_GUI_DT_VALIDADE = pATE_GUI_DT_VALIDADE
    AND CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
    AND CAD_PRD_ID = pCAD_PRD_ID;          
io_cursor := v_cursor;
end PRC_ASS_PPG_PAC_ATE_GUIA_R_S;
