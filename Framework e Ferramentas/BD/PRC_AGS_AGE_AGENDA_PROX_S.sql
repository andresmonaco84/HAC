CREATE OR REPLACE PROCEDURE "PRC_AGS_AGE_AGENDA_PROX_S"
  (
     pAGS_AGE_DT_ATENDIMENTO IN TB_AGS_AGE_AGENDA_SADT.AGS_AGE_DT_ATENDIMENTO%type DEFAULT NULL,
     pAGS_ESM_ID IN TB_AGS_AGE_AGENDA_SADT.AGS_ESM_ID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGS_AGE_AGENDA_SADT_S
  *
  *    Data Criacao:   data da  criac?o   Por: Nome do Analista
  *    Data Alteracao:  data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: RECUPERAR AGENDAMENTOS POSTERIORES A DATA PASSADA
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       LIB_PRD_ID,
       CAD_PRD_ID,
       AGS_AGE_DT_AGENDAMENTO,
       AGS_AGE_HR_AGENDAMENTO,
       AGS_AGE_TP_HORARIO,
       AGS_AGE_TP_AGENDAMENTO,
       AGS_AGE_DT_ATENDIMENTO,
       AGS_AGE_HR_ATENDIMENTO,
       AGS_AGE_FL_STATUS,
       AGS_AGE_DS_OBSERVACAO,
       SEG_USU_ID_USUARIO_AGENDA,
       AGS_AGE_DT_ULT_ATU_AGENDA,
       AGS_AGE_CD_INTAMB,
       AGS_AGE_IN_ORIGEM_INTAMB,
       AGS_ESM_ID,
       CAD_PAC_ID_PACIENTE,
       CAD_PRO_ID_PROFISSIONALEXEC,
       AGS_AGG_ID,
       AGS_AGE_ID
       FROM TB_AGS_AGE_AGENDA_SADT AGE
       WHERE AGE.AGS_ESM_ID = pAGS_ESM_ID
       AND AGE.AGS_AGE_DT_ATENDIMENTO >= pAGS_AGE_DT_ATENDIMENTO;

    io_cursor := v_cursor;
  end PRC_AGS_AGE_AGENDA_PROX_S;

 