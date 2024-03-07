create or replace procedure PRC_AGE_AGD_VERIF_PEND_ESM
  (
     pAGE_ESM_ID in TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_ID%TYPE,
     pAGE_ESM_DT_FIM_ESCALA IN TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_DT_FIM_ESCALA%TYPE DEFAULT NULL,
    io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_AGD_VERIF_PEND_ESM
  *
  *    Data Criacao:  23/11/2007   Por: Guilherme
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Verifica se existem agendas geradas para datas
  *            futuras de acordo com a escala médica
  *
  *    Data Alteração: 11/12/2007  Por: Guilherme
  *    Alteração: Parâmetro de data opcional
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  data TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_DT_FIM_ESCALA%TYPE;
  BEGIN
IF pAGE_ESM_DT_FIM_ESCALA IS NULL THEN
   data := SYSDATE;
   ELSE
   data:=pAGE_ESM_DT_FIM_ESCALA;
   END IF;
    OPEN v_cursor FOR

     SELECT
          1
      FROM
          tb_age_agd_agenda agd
      WHERE
        trunc(agd.age_agd_dt_atendimento)> trunc(data)
      AND agd.age_esm_id = pAGE_ESM_ID
      AND (agd.age_agd_fl_status = 'P');
         io_cursor := v_cursor;

end PRC_AGE_AGD_VERIF_PEND_ESM;  
/
