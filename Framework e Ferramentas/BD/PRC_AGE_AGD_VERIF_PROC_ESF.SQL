create or replace procedure PRC_AGE_AGD_VERIF_PROC_ESF
  (
     pAGE_ESM_ID in TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_ID%TYPE,
     pAGE_ESF_DT_INI_FALTA IN TB_AGE_ESF_ESCALA_FALTAS.AGE_ESF_DT_INI_FALTA%TYPE,
     pAGE_ESF_DT_FIM_FALTA in TB_AGE_ESF_ESCALA_FALTAS.AGE_ESF_DT_FIM_FALTA%TYPE,
    io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_AGD_VERIF_PROC_ESF
  *
  *    Data Criacao:  19/10/2007   Por: Guilherme
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Verifica se existem agendamentos para o período da 
  *            data de falta informada e escala médica. 
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR


      SELECT
          1 
      FROM
          tb_age_agd_agenda agd
      WHERE 
          trunc(agd.age_agd_dt_atendimento)>= pAGE_ESF_DT_INI_FALTA
      AND trunc(agd.age_agd_dt_atendimento)<= pAGE_ESF_DT_FIM_FALTA
      
      AND agd.age_esm_id = pAGE_ESM_ID
       AND (agd.age_agd_fl_status <> 'C')
      AND NOT EXISTS
      (
        SELECT agg.age_agg_id FROM tb_age_agg_agenda_gerada agg
        WHERE agd.age_agg_id = agg.age_agg_id
        AND agg.age_agg_fl_status_horario = 3
      );
   io_cursor := v_cursor;

end PRC_AGE_AGD_VERIF_PROC_ESF;
/
