create or replace procedure PRC_AGESADT_REL_AGENDADOS
  (
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO in TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%type,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type default null,
     pCAD_PLA_ID_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%type default null,
     pDT_INI_CONSULTA in TB_AGS_AGE_AGENDA_SADT.AGS_AGE_DT_ATENDIMENTO%type,
     pDT_FIM_CONSULTA in TB_AGS_AGE_AGENDA_SADT.AGS_AGE_DT_ATENDIMENTO%type,
     pHR_INI_CONSULTA in TB_AGS_AGE_AGENDA_SADT.AGS_AGE_HR_ATENDIMENTO%type default null,
     pHR_FIM_CONSULTA in TB_AGS_AGE_AGENDA_SADT.AGS_AGE_HR_ATENDIMENTO%type default null,
     pAGE_SAU_ID in tb_age_sau_sala_unid_and.age_sau_id%type default null,
     pAUX_EPP_CD_ESPECPROC in tb_aux_epp_especproc.aux_epp_cd_especproc%type default null,
     pCAD_PRD_ID  in tb_cad_prd_produto.cad_prd_id%type default null,
     pCAD_PRO_ID_PROFISSIONAL  IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGESADT_REL_AGENDADOS
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
OPEN v_cursor FOR
    select
           UNI.CAD_UNI_DS_UNIDADE NM_UNIDADE,
           lat.cad_lat_ds_local_atendimento DS_LOCAL,
           epp.aux_epp_ds_descricao DS_ESPECIALIDADE,
           setor.cad_set_ds_setor DS_SETOR,
           sau.age_sau_cd_andar CD_ANDAR,
           SAU.AGE_SAU_NR_SALA NR_SALA,
           SAU.AGE_SAU_DS_SALA DS_SALA,
           to_char(agsesm.ags_esm_dt_ini_escala, 'dd/MM/yyyy') DT_INI_ESCALA,
           to_char(agsesm.ags_esm_dt_fim_escala, 'dd/MM/yyyy') DT_FIM_ESCALA,
           agsesm.ags_esm_hr_ini_escala HR_INI_ESCALA,
           agsesm.ags_esm_hr_fim_escala HR_FIM_ESCALA,

           prd.cad_prd_ds_descricao DS_PRODUTO,
           prd.cad_prd_nm_mnemonico NM_MNEMONICO,
           to_char(ags.ags_age_dt_atendimento, 'dd/MM/yyyy') DT_AGENDAMENTO,
           ags.ags_age_hr_atendimento HR_AGENDAMENTO,
           pes_pac.cad_pes_nm_pessoa NM_PACIENTE,
           FNC_RETORNA_TEL_PAC(pes_pac.cad_pes_id_pessoa) NR_TELEFONE,
           cnv.cad_cnv_cd_hac_prestador CD_CONVENIO,
           ags.ags_age_cd_intamb,
           ags.ags_age_in_origem_intamb,
           ags.lib_prd_id ID_LIBERACAO,
           pac.cad_pac_nr_prontuario NR_PRONTUARIO,
           PRO.CAD_PRO_NM_NOME NM_PROFISSIONAL,
           PES_PAC.CAD_PES_DT_NASCIMENTO
      from
           tb_ags_age_agenda_sadt ags
      join tb_ags_esm_escala_sadt agsesm on agsesm.ags_esm_id = ags.ags_esm_id
      join tb_cad_uni_unidade uni on uni.cad_uni_id_unidade = agsesm.cad_uni_id_unidade
      join tb_cad_lat_local_atendimento lat on lat.cad_lat_id_local_atendimento = agsesm.cad_lat_id_local_atendimento
      join tb_cad_set_setor setor on setor.cad_set_id = agsesm.cad_set_id
      join tb_age_sau_sala_unid_and sau on sau.age_sau_id = agsesm.age_sau_id
      join tb_cad_prd_produto prd on prd.cad_prd_id = ags.cad_prd_id
      join tb_aux_epp_especproc epp on prd.aux_epp_cd_especproc = epp.aux_epp_cd_especproc
                                   and prd.tis_med_cd_tabelamedica = epp.tis_med_cd_tabelamedica
      join tb_cad_pac_paciente pac on pac.cad_pac_id_paciente = ags.cad_pac_id_paciente
      join tb_cad_pes_pessoa pes_pac on pes_pac.cad_pes_id_pessoa = pac.cad_pes_id_pessoa
      join tb_cad_cnv_convenio cnv on cnv.cad_cnv_id_convenio = pac.cad_cnv_id_convenio
     LEFT JOIN TB_CAD_PRO_PROFISSIONAL PRO ON PRO.CAD_PRO_ID_PROFISSIONAL = AGSESM.CAD_PRO_ID_PROFISSIONAL

    where
          (agsesm.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE)
      and (agsesm.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
      and (agsesm.cad_set_id = pCAD_SET_ID)
      and (pCAD_CNV_ID_CONVENIO is null or pac.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO)
      and (pCAD_PLA_ID_PLANO is null or pac.cad_pla_id_plano = pCAD_PLA_ID_PLANO)
      and (pAGE_SAU_ID is null or sau.age_sau_id = pAGE_SAU_ID)
      and (ags.ags_age_dt_atendimento between pDT_INI_CONSULTA and pDT_FIM_CONSULTA)
      and (pHR_INI_CONSULTA is null or ags.ags_age_hr_atendimento >= pHR_INI_CONSULTA)
      and (pHR_FIM_CONSULTA is null or ags.ags_age_hr_atendimento <= pHR_FIM_CONSULTA)
      and (pAUX_EPP_CD_ESPECPROC is null or epp.aux_epp_cd_especproc = pAUX_EPP_CD_ESPECPROC)
      and (pCAD_PRD_ID  is null or prd.cad_prd_id = pCAD_PRD_ID)
      and (pCAD_PRO_ID_PROFISSIONAL IS NULL OR PRO.CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL)
  order by
     ags.ags_age_dt_atendimento,
     ags.ags_age_hr_atendimento;
    io_cursor := v_cursor;
  end PRC_AGESADT_REL_AGENDADOS;
 