create or replace procedure PRC_FAT_CCI_HISTORICO_PAC
(
     pATD_ATE_ID IN TB_FAT_CCI_CONTA_CONSU_ITEM.ATD_ATE_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is

v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
select uni.cad_uni_cd_unid_hospitalar,
       str.cad_set_cd_setor,
       lat.cad_lat_cd_local_atendimento,
       ate.atd_ate_dt_atendimento,
       ate.atd_ate_hr_atendimento,
       cnv.cad_cnv_cd_hac_prestador,
       cbo.tis_cbo_cd_cbos_hac,
       pro.cad_pro_nm_nome,
       ate.atd_ate_id,
       tat.tis_tat_ds_tpatendimento,
       ate.atd_ate_fl_status,
       ate.atd_ate_fl_retorno_ok
  from tb_atd_ate_atendimento       ate,
       tb_cad_uni_unidade           uni,
       tb_cad_cnv_convenio          cnv,
       tb_ass_pat_pacieatend        pat,
       tb_tis_tat_tp_atendimento    tat,
       tb_tis_cbo_cbos              cbo,
       tb_cad_pro_profissional      pro,
       tb_cad_pac_paciente          pac,
       tb_cad_set_setor             str,
       tb_cad_lat_local_atendimento lat
 where ate.cad_uni_id_unidade = uni.cad_uni_id_unidade
   and pat.atd_ate_id = ate.atd_ate_id
   and pat.cad_pac_id_paciente = pac.cad_pac_id_paciente
   and pac.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
   and ate.cad_set_id = str.cad_set_id
   and ate.tis_cbo_cd_cbos = cbo.tis_cbo_cd_cbos(+)
   and ate.cad_pro_id_prof_exec = pro.cad_pro_id_profissional(+)
   and ate.tis_tat_cd_tpatendimento = tat.tis_tat_cd_tpatendimento
   and ate.cad_lat_id_local_atendimento = lat.cad_lat_id_local_atendimento
    and pac.cad_pes_id_pessoa in
       (select pac.cad_pes_id_pessoa
          from tb_ass_pat_pacieatend pat, tb_cad_pac_paciente pac
         where pat.atd_ate_id = pATD_ATE_ID
         and   pat.cad_pac_id_paciente = pac.cad_pac_id_paciente)
   ORDER BY ate.atd_ate_dt_atendimento DESC;

io_cursor := v_cursor;

end PRC_FAT_CCI_HISTORICO_PAC;
