create or replace procedure PRC_ATE_REL_PRONTUARIO
  (
     PATD_DT_INICIO in TB_AGE_AGD_AGENDA.AGE_AGD_DT_ATENDIMENTO%type,
     PATD_DT_FIM in TB_AGE_AGD_AGENDA.AGE_AGD_DT_ATENDIMENTO%type,
     PATD_HR_INICIO IN TB_AGE_AGD_AGENDA.AGE_AGD_HR_AGENDA%TYPE default null,
     PATD_HR_FIM IN TB_AGE_AGD_AGENDA.AGE_AGD_HR_AGENDA%TYPE default null,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO in TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type default null,
     pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type default null,
     pCAD_PRO_ID_PROFISSIONAL in TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%type default null,
     PCAD_SET_NR_ANDAR IN TB_AGE_SAU_SALA_UNID_AND.AGE_SAU_CD_ANDAR%type default null,
    -- pAGE_SAU_NR_SALA IN TB_AGE_SAU_SALA_UNID_AND.AGE_SAU_NR_SALA%type default null,
     pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%type default null,
          pCAD_CGC_ID IN tb_cad_cnv_convenio.cad_cgc_id%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_REL_AGENDADOS
  *
  *    Data Criacao:  18/08/2008   Por: Pedro
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  ******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    select
           pes.cad_pes_nm_pessoa nome_paciente,
           pac.cad_pac_nr_prontuario nr_prontuario,
           pla.cad_pla_cd_plano_hac cd_plano,
           cnv.cad_cnv_cd_hac_prestador cd_convenio,
           setor.cad_set_cd_setor cd_setor,
           esm.age_esm_hr_ini_escala,
           esm.age_esm_hr_fim_escala,
           sau.age_sau_cd_andar cd_andar,
          -- sau.age_sau_nr_sala nr_sala,
           to_char(agd.age_agd_dt_agenda,'dd/MM/yyyy') dt_agendamento,
           agd.age_agd_fl_status fl_status
    from
           tb_cad_pes_pessoa pes,
           tb_cad_pac_paciente pac,
           tb_age_agd_agenda agd,
           tb_age_esm_escala_medica esm,
           tb_cad_uni_unidade uni,
           tb_cad_lat_local_atendimento lat,
           tb_age_sau_sala_unid_and sau,
           tb_tis_cbo_cbos cbo,
           tb_cad_pro_profissional pro,
           tb_age_pee_periodo_escala pee,
           tb_age_agg_agenda_gerada agg,
           tb_cad_pla_plano pla,
           tb_cad_cnv_convenio cnv,
           tb_cad_pes_pessoa pes_uni,
           tb_cad_pes_pessoa pes_pro,
           tb_ass_uss_unid_loc_set_sala uss,
           tb_cad_set_setor setor
    where
           agd.age_agd_fl_status <> 'C' and agd.age_agd_fl_status <> 'F'
    and    agd.cad_pac_id_paciente = pac.cad_pac_id_paciente
    and    agd.cad_pro_id_profissionalexec = pro.cad_pro_id_profissional
    and    agd.age_agg_id = agg.age_agg_id
    and    agd.age_esm_id = esm.age_esm_id
    and    agg.age_esm_id = esm.age_esm_id
    and    pac.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
    and    pac.cad_pla_id_plano = pla.cad_pla_id_plano
    and    esm.cad_uni_id_unidade = uni.cad_uni_id_unidade
    and    esm.cad_lat_id_local_atendimento = lat.cad_lat_id_local_atendimento
    and    esm.tis_cbo_cd_cbos = cbo.tis_cbo_cd_cbos
    and    esm.cad_pro_id_profissional = pro.cad_pro_id_profissional
    and    esm.age_sau_id = sau.age_sau_id
    and    esm.age_pee_id = pee.age_pee_id
    and    sau.age_sau_id = uss.age_sau_id
    and    uss.cad_set_id = setor.cad_set_id
    and    pes.cad_pes_id_pessoa = pac.cad_pes_id_pessoa
    and    pes_uni.cad_pes_id_pessoa = uni.cad_pes_id_pessoa
    and    pes_pro.cad_pes_id_pessoa = pro.cad_pes_id_pessoa
    and    sau.cad_uni_id_unidade = uni.cad_uni_id_unidade
    and agd.age_agd_dt_atendimento between PATD_DT_INICIO and PATD_DT_FIM
    and (PATD_HR_INICIO is null or agd.age_agd_hr_atendimento between PATD_HR_INICIO and PATD_HR_FIM)
    and (uni.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE)
    and (pCAD_LAT_ID_LOCAL_ATENDIMENTO is null or lat.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
    AND (pCAD_SET_ID IS NULL OR uss.cad_set_id = pCAD_SET_ID )
    and (pTIS_CBO_CD_CBOS is null or cbo.tis_cbo_cd_cbos = pTIS_CBO_CD_CBOS)
    and (pCAD_PRO_ID_PROFISSIONAL is null or agd.cad_pro_id_profissionalexec = pCAD_PRO_ID_PROFISSIONAL)
    and (PCAD_SET_NR_ANDAR is null or sau.age_sau_cd_andar = PCAD_SET_NR_ANDAR)
    AND (pCAD_CGC_ID IS NULL OR CNV.CAD_CGC_ID = pCAD_CGC_ID)
   -- and (pAGE_SAU_NR_SALA is null or sau.age_sau_nr_sala = pAGE_SAU_NR_SALA )
  AND NOT EXISTS
               (SELECT agg.age_agg_id FROM
                      tb_age_esf_escala_faltas esf
                  WHERE
                  agg.age_esm_id = esf.age_esm_id
                   AND trunc(agg.age_agg_dt_agenda) BETWEEN trunc(esf.age_esf_dt_ini_falta) AND trunc(esf.age_esf_dt_fim_falta)
                    AND
                       esf.cad_pro_id_profissional_subst IS NULL
               );
    io_cursor := v_cursor;
  end PRC_ATE_REL_PRONTUARIO;
 