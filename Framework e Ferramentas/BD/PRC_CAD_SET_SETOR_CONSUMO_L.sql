CREATE OR REPLACE PROCEDURE "PRC_CAD_SET_SETOR_CONSUMO_L"
  (
     pCAD_UNI_ID_UNIDADE            IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO  IN TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE,
     pATD_ATE_TP_PACIENTE           IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  v_cursor            PKG_CURSOR.t_cursor;
  begin
    -- A U
    IF(pATD_ATE_TP_PACIENTE = 'A' OR pATD_ATE_TP_PACIENTE = 'U') THEN
        OPEN v_cursor FOR
        select str.cad_set_id,
               uni.cad_uni_ds_unidade || ' - ' || str.cad_set_ds_setor as cad_set_ds_setor
          from tb_cad_set_setor str, tb_cad_uni_unidade uni
         where str.cad_uni_id_unidade = uni.cad_uni_id_unidade
           and str.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO
           and str.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE
           and (str.cad_set_fl_gravaatend_ok = 'S')
		   and (str.cad_set_fl_ativo_ok = 'S' or str.cad_set_dt_ultima_atualizacao > trunc(sysdate) -90)
           order by 2;
    ELSE
      -- I E
      OPEN v_cursor FOR
    select str.cad_set_id,
           uni.cad_uni_ds_unidade || ' - ' || str.cad_set_ds_setor as cad_set_ds_setor
        from tb_cad_set_setor str, tb_cad_uni_unidade uni
       where str.cad_uni_id_unidade = uni.cad_uni_id_unidade
         and str.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO
         and str.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE
         and (str.cad_set_fl_gravaatend_ok = 'S' or
             str.cad_set_fl_movimentapacint_ok = 'S' or
             str.cad_set_fl_permiteintern_ok = 'S')
		 and (str.cad_set_fl_ativo_ok = 'S' or str.cad_set_dt_ultima_atualizacao > trunc(sysdate) -90)						 
      union
      select str.cad_set_id,
             uni.cad_uni_ds_unidade || ' - ' || str.cad_set_ds_setor as cad_set_ds_setor
        from tb_cad_set_setor             str,
             tb_cad_uni_unidade           uni,
             tb_cad_lat_local_atendimento lat
       where str.cad_uni_id_unidade = uni.cad_uni_id_unidade
         and str.cad_lat_id_local_atendimento = lat.cad_lat_id_local_atendimento
         and lat.cad_lat_cd_local_atendimento not in ('INT')
         and str.cad_set_fl_gravaatend_ok = 'S'
         and str.cad_set_fl_movimentapacint_ok = 'S'
		 and (str.cad_set_fl_ativo_ok = 'S' or str.cad_set_dt_ultima_atualizacao > trunc(sysdate) -90)
         order by 2;
    END IF;
    io_cursor := v_cursor;
end PRC_CAD_SET_SETOR_CONSUMO_L;
 