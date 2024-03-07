

--PRC_ASS_PAT_PACIEATEND_R_S
create or replace procedure PRC_ASS_PAT_PACIEATEND_R_S 
(
     pASS_PAT_DT_ENTRADA IN TB_ASS_PAT_PACIEATEND.ASS_PAT_DT_ENTRADA%type,
     pASS_PAT_HR_ENTRADA IN TB_ASS_PAT_PACIEATEND.ASS_PAT_HR_ENTRADA%type,
     pATD_ATE_ID IN TB_ASS_PAT_PACIEATEND.ATD_ATE_ID%type,
     pCAD_PAC_ID_PACIENTE IN TB_ASS_PAT_PACIEATEND.CAD_PAC_ID_PACIENTE%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ASS_PAT_PACIEATEND_R_S
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
       ATD_ATE_ID,
       CAD_PAC_ID_PACIENTE,
       ASS_PAT_DT_ENTRADA,
       ASS_PAT_HR_ENTRADA,
       ASS_PAT_DT_SAIDA,
       ASS_PAT_HR_SAIDA,
       ASS_PAT_FL_STATUS,
       SEG_USU_ID_USUARIO,
       ASS_PAT_DT_ULTIMA_ATUALIZACAO,
       ASS_PAT_NR_CONTA,
       CAD_CNV_ID_CONVENIO,
       CAD_PLA_ID_PLANO,
       CAD_PAC_CD_CREDENCIAL,
       ASS_PAT_DS_OBSERVACAO
FROM TB_ASS_PAT_PACIEATEND
WHERE
        ASS_PAT_DT_ENTRADA = pASS_PAT_DT_ENTRADA
    AND ASS_PAT_HR_ENTRADA = pASS_PAT_HR_ENTRADA
    AND ATD_ATE_ID = pATD_ATE_ID
    AND CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE;          
io_cursor := v_cursor;
end PRC_ASS_PAT_PACIEATEND_R_S;
