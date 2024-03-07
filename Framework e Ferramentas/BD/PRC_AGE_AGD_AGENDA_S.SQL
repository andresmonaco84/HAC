create or replace procedure PRC_AGE_AGD_AGENDA_S
  (
     pAGE_AGD_ID IN TB_AGE_AGD_AGENDA.AGE_AGD_ID%type DEFAULT NULL,
     pAGE_AGG_ID IN TB_AGE_AGD_AGENDA.AGE_AGG_ID%type DEFAULT NULL,
     pAGE_AGD_DT_ATENDIMENTO IN TB_AGE_AGD_AGENDA.AGE_AGD_DT_ATENDIMENTO%TYPE DEFAULT NULL,
     pCAD_PAC_ID_PACIENTE IN TB_AGE_AGD_AGENDA.CAD_PAC_ID_PACIENTE%TYPE DEFAULT NULL,
     pAGE_AGD_CD_INTAMB IN TB_AGE_AGD_AGENDA.AGE_AGD_CD_INTAMB%TYPE DEFAULT NULL,
     pAGE_AGD_FL_STATUS IN TB_AGE_AGD_AGENDA.AGE_AGD_FL_STATUS%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_AGD_AGENDA_S
  *
  *    Data Alteracao:  10/6/2016   Por: Pedro
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(2000);
  V_SELECT  varchar2(2000);
  begin
    V_WHERE := NULL;
    IF pAGE_AGD_ID IS NOT NULL THEN
       V_WHERE := V_WHERE || ' WHERE AGE_AGD_ID = ' || pAGE_AGD_ID;
    END IF;
    IF pAGE_AGG_ID IS NOT NULL THEN
       IF V_WHERE IS NOT NULL THEN
          V_WHERE := V_WHERE || ' AND ';
       ELSE
          V_WHERE := 'WHERE ';
       END IF;
       V_WHERE := V_WHERE || ' AGE_AGG_ID = ' || pAGE_AGG_ID;
    END IF;
    IF pAGE_AGD_DT_ATENDIMENTO IS NOT NULL THEN
       IF V_WHERE IS NOT NULL THEN
          V_WHERE := V_WHERE || ' AND ';
       ELSE
          V_WHERE := 'WHERE ';
       END IF;
       V_WHERE := V_WHERE || ' AGE_AGD_DT_ATENDIMENTO = ' || CHR(39) || pAGE_AGD_DT_ATENDIMENTO || CHR(39);
    END IF;
    IF pCAD_PAC_ID_PACIENTE IS NOT NULL THEN
       IF V_WHERE IS NOT NULL THEN
          V_WHERE := V_WHERE || ' AND ';
       ELSE
          V_WHERE := 'WHERE ';
       END IF;
       V_WHERE := V_WHERE || ' CAD_PAC_ID_PACIENTE = ' || pCAD_PAC_ID_PACIENTE;
    END IF;
    IF pAGE_AGD_CD_INTAMB IS NOT NULL THEN
       IF V_WHERE IS NOT NULL THEN
          V_WHERE := V_WHERE || ' AND ';
       ELSE
          V_WHERE := 'WHERE ';
       END IF;
       V_WHERE := V_WHERE || ' AGE_AGD_CD_INTAMB = ' || pAGE_AGD_CD_INTAMB;
    END IF;
    IF pAGE_AGD_FL_STATUS IS NOT NULL THEN
       IF V_WHERE IS NOT NULL THEN
          V_WHERE := V_WHERE || ' AND ';
       ELSE
          V_WHERE := 'WHERE ';
       END IF;
       V_WHERE := V_WHERE || ' AGE_AGD_FL_STATUS = ' || pAGE_AGD_FL_STATUS;
    END IF;
    V_SELECT := 'SELECT
       AGE_AGD_ID,
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
       AGD.SEG_USU_ID_USUARIO,
       AGE_AGD_DT_ULTIMA_ATUALIZACAO,
       AGE_AGD_CD_INTAMB,
       AGE_AGD_IN_INTAMB,
       AGD.AGE_ESM_ID,
       CAD_PAC_ID_PACIENTE,
       CAD_PRO_ID_PROFISSIONALEXEC,
       CAD_PRO_ID_PROFISSIONALSOLIC,
       AGE_AGD_DT_LIMITE_RETORNO,
       AGE_AGG_ID,
       CAD_PRD_ID,
       SEG_USU_ID_DESBLOQUEIO,
       SEG_USU_ID_AGENENCESP,
       ESM.CAD_UNI_ID_UNIDADE,
       ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO,
       ESM.TIS_CBO_CD_CBOS,
       SAU.AGE_SAU_CD_ANDAR,
       SAU.AGE_SAU_NR_SALA,
       AGD.AGE_AGD_DT_ULTIMA_ATUALIZACAO,
       AGD.AGE_AGD_FL_EXIGE_PROFISSIONAL,
       AGD.CAD_UNI_ID_UNID_LOGIN_USU,
       AGD.AGE_AGD_FL_TELEMEDICINA,
       AGD.age_agd_fl_confirma_status,
       AGD.age_agd_fl_confirma_tipo,
       AGD.age_agd_ds_confirma_obs,
       AGD.seg_usu_id_confirma,
       AGD.age_agd_dt_confirma,
       agd.AGE_AGD_CD_REMARCACAO
       
    FROM TB_AGE_AGD_AGENDA AGD
    INNER JOIN TB_AGE_ESM_ESCALA_MEDICA ESM
     ON AGD.AGE_ESM_ID = ESM.AGE_ESM_ID
    INNER JOIN TB_AGE_SAU_SALA_UNID_AND SAU
     ON SAU.AGE_SAU_ID = ESM.AGE_SAU_ID ' || V_WHERE;
    OPEN v_cursor FOR
    V_SELECT;
    io_cursor := v_cursor;
  end PRC_AGE_AGD_AGENDA_S;
