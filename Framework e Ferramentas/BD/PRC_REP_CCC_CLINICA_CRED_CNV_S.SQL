create or replace procedure PRC_REP_CCC_CLINICA_CRED_CNV_S
(
     pREP_CCC_ID IN TB_REP_CCC_CLINICA_CRED_CNV.REP_CCC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_REP_CCC_CLINICA_CRED_CNV_S
*
*    Data Criacao:  data da  criação   Por: Nome do Analista
*    Data Alteracao: data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT
       CAD_TAP_TP_ATRIBUTO,
       CAD_TPE_CD_CODIGO,
       REP_CCC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       REP_CCC_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       CAD_CNV_ID_CONVENIO,
       CAD_CLC_ID,
       ATD_ATE_TP_PACIENTE,
       REP_CCC_DT_INICIO_VIGENCIA,
       REP_CCC_DT_FIM_VIGENCIA,
       TIS_MED_CD_TABELAMEDICA,
       AUX_EPP_CD_ESPECPROC,
       AUX_GPC_CD_GRUPOPROC,
       CAD_PRD_ID,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_PRD_CD_PACOTE,
       CAD_PRD_CD_ITEM_PACOTE,
       CAD_PRO_ID_PROFISSIONAL,
       REP_CCC_ID,
       TIS_CBO_CD_CBOS,
       REP_RCD_ID,
       ATD_ATE_FL_CARATER_SOLIC
FROM TB_REP_CCC_CLINICA_CRED_CNV
WHERE
        REP_CCC_ID = pREP_CCC_ID;
io_cursor := v_cursor;
end PRC_REP_CCC_CLINICA_CRED_CNV_S;
 