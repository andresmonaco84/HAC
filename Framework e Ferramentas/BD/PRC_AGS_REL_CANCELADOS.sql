CREATE OR REPLACE PROCEDURE "PRC_AGS_REL_CANCELADOS"
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

     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGS_REL_CANCELADOS
  *
  *    Data Criacao:  26/11/2008   Por: Pedro
  *    Data Alteracao: data da alteracao  Por: Nome do Analista
  *
  *    Data Alteracao:	30/03/2010  Por: pedro
  *    Alterac?o: join EPP
  *
  *    Funcao: Alimentar relatorio de Pacientes Cancelados no SADT
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
OPEN v_cursor FOR
 select distinct
           uni.cad_uni_ds_unidade,
           lat.cad_lat_ds_local_atendimento DS_LOCAL,
           epp.aux_epp_ds_descricao DS_ESPECIALIDADE,
           setor.cad_set_ds_setor DS_SETOR,
           sau.age_sau_cd_andar CD_ANDAR,
           to_char(agsesm.ags_esm_dt_ini_escala, 'dd/MM/yyyy') DT_INI_ESCALA,
           to_char(agsesm.ags_esm_dt_fim_escala, 'dd/MM/yyyy') DT_FIM_ESCALA,
           agsesm.ags_esm_hr_ini_escala HR_INI_ESCALA,
           agsesm.ags_esm_hr_fim_escala HR_FIM_ESCALA,
           sau.age_sau_nr_sala NR_SALA,
           prd.cad_prd_ds_descricao DS_PRODUTO,
           prd.cad_prd_nm_mnemonico NM_MNEMONICO,
           to_char(agc.ags_age_dt_atendimento, 'dd/MM/yyyy') DT_AGENDAMENTO,
           agc.ags_age_hr_atendimento HR_AGENDAMENTO,
           pes_pac.cad_pes_nm_pessoa NM_PACIENTE,
           FNC_RETORNA_TEL_PAC(pes_pac.cad_pes_id_pessoa) NR_TELEFONE,
           cnv.cad_cnv_cd_hac_prestador CD_CONVENIO,
           agc.ags_age_cd_intamb,
           agc.ags_age_in_origem_intamb,
           agc.lib_lpr_id ID_LIBERACAO,
           agc.ags_age_dt_atendimento,
           agc.ags_age_hr_atendimento,
           AGC.AGS_AGE_TP_AGENDAMENTO,
           DECODE(AGC.AGS_AGE_TP_AGENDAMENTO,'A','ADMINISTRATIVO','D','DESISTENCIA','F','FALTA MEDICA','P','FALTA PACIENTE') DS_TP_AGENDAMENTO
      from
           tb_ags_agc_agenda_canc_sadt agc
     inner join tb_ags_esm_escala_sadt agsesm
        on agsesm.ags_esm_id = agc.ags_esm_id
     inner join tb_cad_uni_unidade uni
        on uni.cad_uni_id_unidade = agsesm.cad_uni_id_unidade
    
     inner join tb_cad_lat_local_atendimento lat
        on lat.cad_lat_id_local_atendimento = agsesm.cad_lat_id_local_atendimento
     inner join tb_cad_set_setor setor
        on setor.cad_set_id = agsesm.cad_set_id
     inner join tb_age_sau_sala_unid_and sau
        on sau.age_sau_id = agsesm.age_sau_id
     inner join tb_cad_prd_produto prd
        on prd.cad_prd_id = agc.cad_prd_id
     inner join tb_aux_epp_especproc epp
        on prd.aux_epp_cd_especproc = epp.aux_epp_cd_especproc
        and prd.tis_med_cd_tabelamedica = epp.tis_med_cd_tabelamedica
     inner join tb_cad_pac_paciente pac
        on pac.cad_pac_id_paciente = agc.cad_pac_id_paciente
     inner join tb_cad_pes_pessoa pes_pac
        on pes_pac.cad_pes_id_pessoa = pac.cad_pes_id_pessoa
     inner join tb_cad_cnv_convenio cnv
        on cnv.cad_cnv_id_convenio = pac.cad_cnv_id_convenio
    where
          (agsesm.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE)
      and (agsesm.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
      and (agsesm.cad_set_id = pCAD_SET_ID)
      and (pCAD_CNV_ID_CONVENIO is null or pac.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO)
      and (pCAD_PLA_ID_PLANO is null or pac.cad_pla_id_plano = pCAD_PLA_ID_PLANO)
      and (pAGE_SAU_ID is null or sau.age_sau_id = pAGE_SAU_ID)
      and (agc.ags_age_dt_atendimento between pDT_INI_CONSULTA and pDT_FIM_CONSULTA)
      and (pHR_INI_CONSULTA is null or agc.ags_age_hr_atendimento >= pHR_INI_CONSULTA)
      and (pHR_FIM_CONSULTA is null or agc.ags_age_hr_atendimento <= pHR_FIM_CONSULTA)
      and (pAUX_EPP_CD_ESPECPROC is null or epp.aux_epp_cd_especproc = pAUX_EPP_CD_ESPECPROC)
      and (pCAD_PRD_ID  is null or prd.cad_prd_id = pCAD_PRD_ID)
     order by
   agc.ags_age_dt_atendimento,
     agc.ags_age_hr_atendimento
      ;
    io_cursor := v_cursor;
  end PRC_AGS_REL_CANCELADOS;
 