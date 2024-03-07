

--PRC_ASS_PAP_PAC_ATEN_PROC_R_S
create or replace procedure PRC_ASS_PAP_PAC_ATEN_PROC_R_S 
(
     pASS_PAP_ID IN TB_ASS_PAP_PAC_ATEN_PROC.ASS_PAP_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ASS_PAP_PAC_ATEN_PROC_R_S
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
       CAD_PRD_ID,
       CAD_PAC_ID_PACIENTE,
       ASS_PAP_QT_SOLIC,
       ASS_PAP_DT_SOLIC,
       ASS_PAP_FL_STATUS_SOLIC,
       ASS_PAP_HR_SOLIC,
       ASS_PAP_QT_AUTOR,
       ASS_PAP_DT_AUTOR,
       ASS_PAP_HR_AUTOR,
       ASS_PAP_FL_STATUS_AUTOR,
       ASS_PAP_QT_REALIZ,
       ASS_PAP_DT_REALIZ,
       ASS_PAP_HR_INI_REALIZ,
       ASS_PAP_HR_FIM_REALIZ,
       ASS_PAP_FL_STATUS_REALIZ,
       SEG_USU_ID_USUARIO,
       ASS_PAP_NR_CONTA,
       ASS_PAP_DT_ULTIMA_ATUALIZACAO,
       ASS_PAP_ID,
       ASS_PAP_FL_ORIGEM,
       CAD_UNI_ID_UNIDADE,
       CODPAD,
       ATD_ATE_NR_CONSELHO_SOLIC,
       ATD_ATE_CD_UFCONSELHO_SOLIC,
       TIS_CPR_CD_CONSELHOPROF_SOLIC,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       ASS_PAP_NM_ATENDENTE_PLANO,
       CAD_CLC_ID,
       ASS_PAP_DS_OBSERVACAO,
       CAD_SET_ID_SETOR_LIBERACAO,
       ASS_PAP_DS_RET_AUTORIZADOR,
       ASS_PAP_FL_CARATER_SOLIC,
       ASS_PAP_FL_AUTORIZ_MANUAL_OK,
       ASS_PAP_FL_ACIDENTE_TRAB_OK,
       ASS_PAP_FL_SEM_GUIA_OK,
       ASS_PAP_DT_VALIDADE,
       FAT_CCI_ID
FROM TB_ASS_PAP_PAC_ATEN_PROC
WHERE
        ASS_PAP_ID = pASS_PAP_ID;          
io_cursor := v_cursor;
end PRC_ASS_PAP_PAC_ATEN_PROC_R_S;
