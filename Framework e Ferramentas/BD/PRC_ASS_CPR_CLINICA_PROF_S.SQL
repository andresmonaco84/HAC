--PRC_ASS_CPR_CLINICA_PROF_S
create or replace procedure PRC_ASS_CPR_CLINICA_PROF_S 
(
     pASS_CPR_ID IN TB_ASS_CPR_CLINICA_PROF.ASS_CPR_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ASS_CPR_CLINICA_PROF_S
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
       ASS_CPR_ID,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_PRO_ID_PROFISSIONAL,
       TIS_CBO_CD_CBOS,
       CAD_PRD_ID,
       ASS_CPR_DT_INICIO_VIGENCIA,
       ASS_CPR_DT_FIM_VIGENCIA,
       ASS_CPR_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_CLC_ID,
       TIS_MED_CD_TABELAMEDICA,
       AUX_EPP_CD_ESPECPROC,
       AUX_GPC_CD_GRUPOPROC,
       CAD_CNV_ID_CONVENIO,
       CAD_SET_ID,
       CAD_TPE_CD_CODIGO,
       ASS_CPR_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       CAD_PLA_ID_PLANO
FROM TB_ASS_CPR_CLINICA_PROF
WHERE
        ASS_CPR_ID = pASS_CPR_ID;          
io_cursor := v_cursor;
end PRC_ASS_CPR_CLINICA_PROF_S;