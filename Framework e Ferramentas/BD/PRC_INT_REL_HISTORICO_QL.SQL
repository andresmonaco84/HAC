CREATE OR REPLACE procedure SGS.PRC_INT_REL_HISTORICO_QL
  (
    pATD_ATE_DT_ATENDIMENTO_INI IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
    pATD_ATE_DT_ATENDIMENTO_FIM IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
    pCAD_UNI_ID_UNIDADE IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
    pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
    pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
    io_cursor              OUT PKG_CURSOR.t_cursor) is
  v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
select
        qle.cad_qle_nr_quarto || '/' || qle.cad_qle_nr_leito                                                                  quarto_leito,
        sql.cad_sql_ds_sit_quarto_leito                                                                                       situacao,
        hql.cad_hql_dt_hr_inicio                                                                                              data_inicio,
        decode(hql.cad_hql_dt_hr_fim, null, sysdate, hql.cad_hql_dt_hr_fim)                                                   data_fim,
        count(hql.cad_hql_id)                                                                                                 total,
        --trunc(((decode(hql.cad_hql_dt_hr_fim, null, sysdate, hql.cad_hql_dt_hr_fim) - hql.cad_hql_dt_hr_inicio) * 24) * 60)   minutos,
        trunc(((decode(to_date(to_char(hql.cad_hql_dt_hr_fim, 'dd/MM/yyyy HH24:mi'), 'dd/MM/yyyy HH24:mi'), null, sysdate, to_date(to_char(hql.cad_hql_dt_hr_fim, 'dd/MM/yyyy HH24:mi'), 'dd/MM/yyyy HH24:mi')) - to_date(to_char(hql.cad_hql_dt_hr_inicio, 'dd/MM/yyyy HH24:mi'), 'dd/MM/yyyy HH24:mi')) * 24) * 60)  minutos,
        trunc((decode(hql.cad_hql_dt_hr_fim, null, sysdate, hql.cad_hql_dt_hr_fim) - hql.cad_hql_dt_hr_inicio) * 24 
             + trunc((decode(hql.cad_hql_dt_hr_fim, null, sysdate, hql.cad_hql_dt_hr_fim)  - hql.cad_hql_dt_hr_inicio) 
             - trunc(decode(hql.cad_hql_dt_hr_fim, null, sysdate, hql.cad_hql_dt_hr_fim) - hql.cad_hql_dt_hr_inicio)) * 24)   horas,
        trunc(decode(hql.cad_hql_dt_hr_fim, null, sysdate, hql.cad_hql_dt_hr_fim) - hql.cad_hql_dt_hr_inicio)                 dias,
        round(trunc(decode(hql.cad_hql_dt_hr_fim, null, sysdate, hql.cad_hql_dt_hr_fim) - hql.cad_hql_dt_hr_inicio)/7,0)      semanas,
        round(months_between (decode(hql.cad_hql_dt_hr_fim, null, sysdate, hql.cad_hql_dt_hr_fim), hql.cad_hql_dt_hr_inicio)) meses
   from tb_cad_set_setor setor
   join tb_cad_qle_quarto_leito qle
     on qle.cad_set_id = setor.cad_set_id
   join tb_cad_hql_his_sit_qto_leito hql
     on qle.cad_qle_id = hql.cad_qle_id
   join tb_cad_sql_sit_quarto_leito sql
     on hql.cad_sql_cd_sit_quarto_leito = sql.cad_sql_cd_sit_quarto_leito
  where setor.cad_uni_id_unidade = PCAD_UNI_ID_UNIDADE
    and setor.cad_lat_id_local_atendimento = PCAD_LAT_ID_LOCAL_ATENDIMENTO
    and setor.cad_set_id = PCAD_SET_ID
    and setor.cad_set_fl_ativo_ok = 'S'
    and ((to_date(trunc(hql.cad_hql_dt_hr_inicio), 'dd/MM/yyyy') <= to_date(PATD_ATE_DT_ATENDIMENTO_FIM, 'dd/MM/yyyy')) and
         (hql.cad_hql_dt_hr_fim is null or to_date(trunc(hql.cad_hql_dt_hr_fim), 'dd/MM/yyyy') >= to_date(PATD_ATE_DT_ATENDIMENTO_INI, 'dd/MM/yyyy')))
group by qle.cad_qle_nr_quarto || '/' || qle.cad_qle_nr_leito,
         sql.cad_sql_ds_sit_quarto_leito,
         hql.cad_hql_dt_hr_inicio,
         hql.cad_hql_dt_hr_fim,
         --trunc(((decode(hql.cad_hql_dt_hr_fim, null, sysdate, hql.cad_hql_dt_hr_fim) - hql.cad_hql_dt_hr_inicio) * 24) * 60),
         trunc(((decode(to_date(to_char(hql.cad_hql_dt_hr_fim, 'dd/MM/yyyy HH24:mi'), 'dd/MM/yyyy HH24:mi'), null, sysdate, to_date(to_char(hql.cad_hql_dt_hr_fim, 'dd/MM/yyyy HH24:mi'), 'dd/MM/yyyy HH24:mi')) - to_date(to_char(hql.cad_hql_dt_hr_inicio, 'dd/MM/yyyy HH24:mi'), 'dd/MM/yyyy HH24:mi')) * 24) * 60),
         trunc((decode(hql.cad_hql_dt_hr_fim, null, sysdate, hql.cad_hql_dt_hr_fim) - hql.cad_hql_dt_hr_inicio) * 24 + 
         trunc((decode(hql.cad_hql_dt_hr_fim, null, sysdate, hql.cad_hql_dt_hr_fim)  - hql.cad_hql_dt_hr_inicio) - 
         trunc(decode(hql.cad_hql_dt_hr_fim, null, sysdate, hql.cad_hql_dt_hr_fim) - hql.cad_hql_dt_hr_inicio)) * 24),
         trunc(decode(hql.cad_hql_dt_hr_fim, null, sysdate, hql.cad_hql_dt_hr_fim) - hql.cad_hql_dt_hr_inicio),
         round(trunc(decode(hql.cad_hql_dt_hr_fim, null, sysdate, hql.cad_hql_dt_hr_fim) - hql.cad_hql_dt_hr_inicio)/7,0),
         round(months_between (decode(hql.cad_hql_dt_hr_fim, null, sysdate, hql.cad_hql_dt_hr_fim), hql.cad_hql_dt_hr_inicio))
order by 1, 2, 3, 4;
  io_cursor := v_cursor;
end PRC_INT_REL_HISTORICO_QL;