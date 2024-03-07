CREATE OR REPLACE PROCEDURE "PRC_FAT_LOTE_NEMITIDA_L"
(
  pCAD_UNI_ID_UNIDADE           TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
  pCAD_LAT_ID_LOCAL_ATENDIMENTO VARCHAR2,
  pCAD_SET_ID                   VARCHAR2,
  pATD_ATE_DT_ATENDIMENTO       TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
  pCAD_CNV_ID_CONVENIO          TB_CAD_PAC_PACIENTE.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
  IO_CURSOR                     OUT PKG_CURSOR.T_CURSOR
)
  IS
/* 08/05/2013 - Marcus Relva - Alteracao para formato concatenado */
  V_CURSOR PKG_CURSOR.T_CURSOR;
  V_WHERE  varchar2(2000);
  V_SELECT varchar2(6000);
BEGIN
       v_where := ' AND ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT column_value from table(FNC_SPLIT(''' || pCAD_LAT_ID_LOCAL_ATENDIMENTO || ''')))
       AND ATE.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE ||'
       AND ATE.ATD_ATE_DT_ATENDIMENTO <=  ''' || pATD_ATE_DT_ATENDIMENTO || '''
       AND cnv.CAD_CNV_ID_CONVENIO = '|| pCAD_CNV_ID_CONVENIO ;       
       if(pCAD_SET_ID is not null) then
          v_where := v_where || ' AND ATE.CAD_SET_ID IN (SELECT column_value from table(FNC_SPLIT(''' || pCAD_SET_ID || '''))) ';
       end if;              
 V_SELECT := 'select ate.atd_ate_id,
       ate.atd_ate_tp_paciente,
       pes.cad_pes_nm_pessoa,
       ate.atd_ate_dt_atendimento,
       ate.atd_ate_hr_atendimento,
       ina.atd_ina_dt_alta_adm,
       ina.atd_ina_hr_alta_adm,
       ina.tis_msi_cd_motivosaidaint,
       sum(cci.fat_cci_vl_produto),
       sum(cci.fat_cci_vl_faturado),
       cci.cad_pac_id_paciente,
       cci.cad_cnv_id_convenio,
       cci.fat_ccp_id,
       1 as fat_coc_id,
       pla.cad_pla_cd_tipoplano,
       cnv.cad_cnv_qt_dia_conta_parcial,
       cid10.cad_cid_ds_cid10,
       cnv.cad_cnv_fl_env_envioonline,
       ate.cad_uni_id_unidade,
       pla.cad_pla_id_plano,
       cnv.cad_tpe_cd_codigo,
       ate.cad_lat_id_local_atendimento,
       max(mpf.cad_mpf_fl_motivo) as pendencia
  from tb_atd_ate_atendimento       ate
       left join tb_atd_ina_int_alta ina on ina.atd_ate_id = ate.atd_ate_id
       join tb_fat_cci_conta_consu_item  cci on cci.atd_ate_id = ate.atd_ate_id
                                             and cci.atd_ate_tp_paciente = ate.atd_ate_tp_paciente
                                             and cci.cad_uni_id_unidade = ate.cad_uni_id_unidade
       join  tb_cad_pac_paciente pac on cci.cad_pac_id_paciente = pac.cad_pac_id_paciente
                                    and cci.cad_cnv_id_convenio = pac.cad_cnv_id_convenio
       join tb_cad_pes_pessoa   pes on pes.cad_pes_id_pessoa = pac.cad_pes_id_pessoa
       join tb_cad_pla_plano    pla on pac.cad_pla_id_plano = pla.cad_pla_id_plano
       join tb_cad_cnv_convenio cnv on pac.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
                                    and cci.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
       left join tb_cad_cid_cid10 cid10 on ate.cad_cid_cd_cid10 = cid10.cad_cid_cd_cid10
       left join tb_cad_mpf_moti_pend_faturar mpf on cci.cad_mpf_id = mpf.cad_mpf_id
 where
    ate.atd_ate_fl_status =  ''A''
   and cci.fat_cci_fl_status =  ''A''
   and cci.fat_cci_tp_destino_item not in (''H'', ''T'')
   and cci.fat_ccp_id is null
   and cci.fat_cci_mes_fechamento = to_char(fnc_mesanoaberto(ate.atd_ate_tp_paciente, cci.cad_cnv_id_convenio, cci.cad_uni_id_unidade),''MM'')
   and cci.fat_cci_ano_fechamento =  to_char(fnc_mesanoaberto(ate.atd_ate_tp_paciente, cci.cad_cnv_id_convenio, cci.cad_uni_id_unidade),''yyyy'')
   and (ate.tis_tat_cd_tpatendimento = ''4'' and ate.cad_cid_cd_cid10 is not null or ate.tis_tat_cd_tpatendimento <> ''4'')
   and ((sgs.fnc_fat_libera_auto(ate.cad_set_id, cci.atd_ate_tp_paciente,  cci.cad_cnv_id_convenio, ate.tis_tat_cd_tpatendimento, ate.cad_pro_id_prof_exec) = 0
       and ate.atd_ate_fl_libera_emissao = ''S'') or
       sgs.fnc_fat_libera_auto(ate.cad_set_id, cci.atd_ate_tp_paciente, cci.cad_cnv_id_convenio, ate.tis_tat_cd_tpatendimento, ate.cad_pro_id_prof_exec) = 1)
   and ((ate.atd_ate_tp_paciente in (''I'', ''E'') and
        fnc_juntar_data_hora(cci.fat_cci_dt_fim_consumo, cci.fat_cci_hr_fim_consumo) <= sysdate) or ate.atd_ate_tp_paciente not in (''I'', ''E''))



  '
|| v_where ||
 ' group by ate.atd_ate_tp_paciente,
          ate.atd_ate_id,
          pes.cad_pes_nm_pessoa,
          ate.atd_ate_dt_atendimento,
          ate.atd_ate_hr_atendimento,
          ina.atd_ina_dt_alta_adm,
          ina.atd_ina_hr_alta_adm,
          ina.tis_msi_cd_motivosaidaint,
          cci.cad_pac_id_paciente,
          cci.cad_cnv_id_convenio,
          cci.fat_ccp_id,
          1,
          pla.cad_pla_cd_tipoplano,
          cnv.cad_cnv_qt_dia_conta_parcial,
          cid10.cad_cid_ds_cid10,
          cnv.cad_cnv_fl_env_envioonline,
          ate.cad_uni_id_unidade,
          pla.cad_pla_id_plano,
          cnv.cad_tpe_cd_codigo,
          ate.cad_lat_id_local_atendimento';
--dbms_output.put_line(V_SELECT);
  OPEN V_CURSOR FOR
-- select sysdate from dual;
 V_SELECT;
  io_cursor := v_cursor;
END PRC_FAT_LOTE_NEMITIDA_L;
