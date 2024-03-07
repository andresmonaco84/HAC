create or replace procedure PRC_AGE_AGD_VERIF_PROC_ESM
  (
     pAGE_ESM_ID in TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_ID%TYPE,
     pAGE_ESM_DT_FIM_ESCALA in TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_DT_FIM_ESCALA%TYPE,
    io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_AGD_VERIF_PROC_ESM
  *
  *    Data Criacao:  15/10/2007   Por: Guilherme
  *    Data Alteracao: 22/10/2007  Por: Cristiane Gomes
  *
  *    Funcao: Verifica se existem procedimentos para a data informada e
  *            escala médica. Procedure utilizada para verificar a possibilidade
  *            de se fechar uma escala em uma data informada. Caso não
  *            hajam atendimentos com status A, nem F (atendidos / faltas)
  *            e/ou todos os outros cancelados / transferidos, é permitido
  *            o encerramento da escala na data informada
  *
  *   Data Alteração: 16/10/2007   Por: Cristiane Gomes da Silva
  *   Alteração: 1) Troca da verificação do status para que simplesmente seja verificado
  *              status diferente de cancelado ('C').
  *              2) Inclusão da condição de data de atendimento >= a data de fim da escala                 
  *              3) Alteração da condição de data de atendimento > que a data de fim de escala
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR


      SELECT 1 FROM tb_age_agd_agenda agd
      WHERE
      trunc(agd.age_agd_dt_atendimento) > pAGE_ESM_DT_FIM_ESCALA
      AND agd.age_esm_id = pAGE_ESM_ID
      AND (agd.age_agd_fl_status <> 'C')
      AND NOT EXISTS
      (
        SELECT agg.age_agg_id FROM tb_age_agg_agenda_gerada agg
        WHERE agd.age_agg_id = agg.age_agg_id
        AND agg.age_agg_fl_status_horario = 3
      );
      
      
          io_cursor := v_cursor;
    -- Atualizado 9/10/07 16:35
end PRC_AGE_AGD_VERIF_PROC_ESM;
/
