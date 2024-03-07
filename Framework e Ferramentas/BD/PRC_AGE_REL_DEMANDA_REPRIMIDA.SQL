CREATE OR REPLACE PROCEDURE "PRC_AGE_REL_DEMANDA_REPRIMIDA" (
  pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE,
  pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE,
  pCOD_TIPO_HORARIO in tb_age_agg_agenda_gerada.age_agg_tp_horario%type default null,
  io_cursor OUT PKG_CURSOR.t_cursor
  )
   IS
  /********************************************************************
  *    Procedure: PRC_AGE_REL_DEMANDA_REPRIMIDA
  *
  *    Data Alterac?o: 21/08/2009  Por: Pedro
  *    Alterac?o: no primeiro insert estava errado a ordem qtd_escalas e qtd_medicos
  *
  *  *******************************************************************/
      v_cursor2 PKG_CURSOR.t_cursor;
      temp_especialidade VARCHAR2(35):=' ';
      temp_medico NUMBER :=0;
      qtd_sete NUMBER :=0;
      qtd_quinze NUMBER:=0;
      qtd_vinte_cinco NUMBER:=0;
      qtd_trinta NUMBER:=0;
      qtd_quarenta_cinco NUMBER:=0;
      qtd_quarenta_seis NUMBER:=0;
      qtd_escalas  NUMBER := 0;
      qtd_medicos  NUMBER := 0;
      v_cursor PKG_CURSOR.t_cursor;
      diferenca_dias NUMBER :=0;
      BEGIN
          DELETE FROM tb_tmp_age_demanda_reprimida;
      COMMIT;
        DECLARE CURSOR
        v_cursor IS
        SELECT
          DISTINCT  cbo.tis_cbo_ds_cbos_hac especialidade,  pro.cad_pro_id_profissional profissional,pee.age_pee_cd_periodo_escala,
        (SELECT substr(FNC_age_agg_prox_agd_livre(pro.cad_pro_id_profissional, pee.age_pee_cd_periodo_escala,pCAD_UNI_ID_UNIDADE, pCAD_LAT_ID_LOCAL_ATENDIMENTO, esm.age_esm_id, esm.tis_cbo_cd_cbos,pCOD_TIPO_HORARIO),1,10)
         FROM dual ) dias
        FROM
         tb_tis_cbo_cbos cbo,
         tb_cad_pro_profissional pro,
         tb_age_esm_escala_medica esm,
         tb_age_pee_periodo_escala pee,
         tb_ass_pcb_profissional_cbos pcb
         WHERE cbo.tis_cbo_cd_cbos = esm.tis_cbo_cd_cbos
         AND esm.cad_pro_id_profissional = pro.cad_pro_id_profissional
         AND esm.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE
         AND esm.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO
         AND esm.age_pee_id = pee.age_pee_id
         AND pcb.cad_pro_id_profissional = pro.cad_pro_id_profissional
         AND cbo.tis_cbo_cd_cbos = pcb.tis_cbo_cd_cbos
         AND esm.tis_cbo_cd_cbos = pcb.tis_cbo_cd_cbos
         AND esm.cad_pro_id_profissional = pcb.cad_pro_id_profissional
        AND esm.age_esm_fl_situacao = 'A'
        AND (esm.age_esm_dt_fim_escala is null or trunc(esm.age_esm_dt_fim_escala) >= trunc(sysdate))
        AND esm.age_esm_id IN (SELECT agg.age_esm_id 
                               FROM tb_age_agg_agenda_gerada agg 
                               WHERE agg.age_esm_id = esm.age_esm_id
                                 AND agg.age_agg_fl_status_horario = 1 
                                 AND agg.age_agg_tp_horario = pCOD_TIPO_HORARIO 
                                 AND(agg.age_esf_id IS NULL   OR agg.age_esf_id IN (SELECT esf.age_esf_id 
                                                                                    FROM tb_age_esf_escala_faltas esf
                                                                                    WHERE esf.age_esf_id = agg.age_esf_id
                                                                                      AND esf.cad_pro_id_profissional_subst IS NOT NULL ) )
        AND trunc(agg.age_agg_dt_agenda) >= trunc(SYSDATE) ) order by 1;
        BEGIN
        for registros in v_cursor
               LOOP
                 IF  temp_especialidade  != registros.especialidade THEN
                  IF temp_especialidade!=' ' THEN
                      INSERT INTO
                      tb_tmp_age_demanda_reprimida
                      VALUES(
                      temp_especialidade,
                      qtd_medicos ,
                      qtd_sete,
                      qtd_quinze,
                      qtd_vinte_cinco,
                      qtd_trinta,
                      qtd_quarenta_cinco,
                      qtd_quarenta_seis,
                      qtd_escalas
                      );
                  END IF;
                    temp_especialidade:=registros.especialidade;
                    qtd_sete:= 0; qtd_quinze:=0; qtd_vinte_cinco:=0;
                    qtd_trinta:=0; qtd_quarenta_cinco:=0; qtd_quarenta_seis:=0;
                    qtd_medicos:=0; qtd_escalas:=0;
                  END IF;
                  IF temp_medico != registros.profissional THEN qtd_medicos := qtd_medicos + 1; END IF;
                  temp_medico := registros.profissional;
                  qtd_escalas := qtd_escalas + 1;
                  diferenca_dias:=trunc(TO_DATE(registros.dias,'dd/MM/yyyy'))  - trunc(SYSDATE);
                   CASE
                     WHEN diferenca_dias BETWEEN 1 AND 7 THEN qtd_sete:=qtd_sete+1;
                     WHEN diferenca_dias BETWEEN 8 AND 14 THEN qtd_quinze:=qtd_quinze+1;
                     WHEN diferenca_dias BETWEEN 15 AND 30 THEN qtd_vinte_cinco:=qtd_vinte_cinco+1;
                     WHEN diferenca_dias BETWEEN 31 AND 45 THEN qtd_trinta:=qtd_trinta+1;
                     WHEN diferenca_dias BETWEEN 46 AND 60 THEN qtd_quarenta_cinco:=qtd_quarenta_cinco+1;
                     ELSE qtd_quarenta_seis:=qtd_quarenta_seis+1;
                   END CASE;
               end loop;
               INSERT INTO
                      tb_tmp_age_demanda_reprimida
                      VALUES(
                      temp_especialidade,
                      qtd_medicos,
                      qtd_sete,
                      qtd_quinze,
                      qtd_vinte_cinco,
                      qtd_trinta,
                      qtd_quarenta_cinco,
                      qtd_quarenta_seis,
                      qtd_escalas);
        COMMIT;
      END;
         OPEN v_cursor2 FOR
         SELECT * FROM tb_tmp_age_demanda_reprimida;
          io_cursor := v_cursor2;
    END PRC_AGE_REL_DEMANDA_REPRIMIDA;
 