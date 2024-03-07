create or replace procedure PRC_AGE_AGC_AGENDA_CANCELADA_S
  (
     pAGE_AGD_ID IN TB_AGE_AGC_AGENDA_CANCELADA.AGE_AGD_ID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_AGC_AGENDA_CANCELADA_S
  *
  *    Data Criacao:  data da  criac?o   Por: Nome do Analista
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Descric?o da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       AGE_AGD_ID,
       SEG_USU_ID_USUARIO,
       AGE_AGC_DT_CANCELAMENTO,
       AGE_AGC_TP_CANCELAMENTO,
       AGE_AGC_TP_FORMA_CANCELA,
       AGE_AGC_DS_OBSERVACAO,
       AGE_AGC_NM_SOLICITANTE,
       AGE_AGD_DT_AGENDA,
       AGE_AGD_HR_AGENDA,
       AGE_AGD_TP_AGENDA,
       AGE_AGD_CD_AMBESP,
       AGE_AGD_CD_AMBGRP,
       AGE_AGD_CD_AMBSEQ,
       AGE_AGD_CD_AMBTP,
       AGE_AGD_DT_ATENDIMENTO,
       AGE_AGD_HR_ATENDIMENTO,
       AGE_AGD_FL_STATUS,
       AGE_AGD_DS_OBSERVACAO,
       AGE_AGD_CD_INTAMB,
       AGE_AGD_IN_INTAMB,
       AGE_ESM_ID,
       CAD_PAC_ID_PACIENTE,
       CAD_PRO_ID_PROFISSIONALEXEC,
       CAD_PRO_ID_PROFISSIONALSOLIC,
       AGE_AGD_DT_LIMITE_RETORNO,
       AGE_AGG_ID,
       CAD_PRD_ID,
       SEG_USU_ID_DESBLOQUEIO,
       SEG_USU_ID_AGENENCESP,
       CAD_UNI_ID_UNID_LOGIN_USU,
       age_agd_fl_confirma_status,
       age_agd_fl_confirma_tipo,
       age_agd_ds_confirma_obs,
       seg_usu_id_confirma,
       age_agd_dt_confirma,
       AGE_AGD_CD_REMARCACAO
       
    FROM TB_AGE_AGC_AGENDA_CANCELADA
    WHERE
        (pAGE_AGD_ID is null OR AGE_AGD_ID = pAGE_AGD_ID);
    io_cursor := v_cursor;
  end PRC_AGE_AGC_AGENDA_CANCELADA_S;
