create or replace procedure PRC_AGS_REL_ESTAT_AGENDADOS
  (
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO in TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%type,
     pAGE_SAU_ID IN tb_age_sau_sala_unid_and.age_sau_id%TYPE DEFAULT NULL,
     pAUX_EPP_CD_ESPECPROC in tb_aux_epp_especproc.aux_epp_cd_especproc%type default null,
     pCAD_PRD_ID IN tb_cad_prd_produto.cad_prd_id%type default null,
     pDT_INI_CONSULTA in TB_AGS_AGE_AGENDA_SADT.AGS_AGE_DT_AGENDAMENTO%type,
     pDT_FIM_CONSULTA in TB_AGS_AGE_AGENDA_SADT.AGS_AGE_DT_AGENDAMENTO%type,
     pHR_INI_CONSULTA in TB_AGS_AGE_AGENDA_SADT.AGS_AGE_HR_AGENDAMENTO%type,
     pHR_FIM_CONSULTA in TB_AGS_AGE_AGENDA_SADT.AGS_AGE_HR_AGENDAMENTO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGS_REL_ESTAT_AGENDADOS
  *
  *    Data Criacao:  06/11/2008   Por: Pedro
  *    Data Alteracao: data da alteracao  Por: Nome do Analista
  *
  *    Data Alteracao:  30/03/2008  Por: Pedro
  *    Alterac?o: join EPP
  *
  *    Funcao: Alimentar relatorio Agendados no SADT - UC AGESADT-20
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
 select distinct
           UNI.CAD_UNI_DS_UNIDADE NM_UNIDADE,
           lat.cad_lat_ds_local_atendimento DS_LOCAL,
           epp.aux_epp_ds_descricao DS_ESPECIALIDADE,
           setor.cad_set_ds_setor DS_SETOR,
           sau.age_sau_nr_sala NR_SALA,
           prd.cad_prd_ds_descricao DS_PRODUTO,
          prd.cad_prd_nm_mnemonico NM_MNEMONICO,
           to_char(ags.ags_age_dt_atendimento, 'dd/MM/yyyy') DT_AGENDAMENTO,
           Count(to_char(ags.ags_age_dt_atendimento, 'dd/MM/yyyy')) AGENDADOS
      from
           tb_ags_age_agenda_sadt ags
     inner join tb_ags_esm_escala_sadt agsesm        on agsesm.ags_esm_id = ags.ags_esm_id
     inner join tb_cad_uni_unidade uni        on uni.cad_uni_id_unidade = agsesm.cad_uni_id_unidade

     inner join tb_cad_lat_local_atendimento lat        on lat.cad_lat_id_local_atendimento = agsesm.cad_lat_id_local_atendimento
     inner join tb_cad_set_setor setor        on setor.cad_set_id = agsesm.cad_set_id
     inner join tb_age_sau_sala_unid_and sau        on sau.age_sau_id = agsesm.age_sau_id
     inner join tb_cad_prd_produto prd        on prd.cad_prd_id = ags.cad_prd_id
     inner join tb_aux_epp_especproc epp        on prd.aux_epp_cd_especproc = epp.aux_epp_cd_especproc
                                             and prd.tis_med_cd_tabelamedica = epp.tis_med_cd_tabelamedica
   
    where
          (agsesm.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE)
      and (agsesm.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
      and (agsesm.cad_set_id = pCAD_SET_ID)
      and (ags.ags_age_dt_atendimento between pDT_INI_CONSULTA and pDT_FIM_CONSULTA)
      and (pAGE_SAU_ID IS NULL OR SAU.AGE_SAU_ID = pAGE_SAU_ID)
      AND (pAUX_EPP_CD_ESPECPROC IS NULL OR EPP.AUX_EPP_CD_ESPECPROC = pAUX_EPP_CD_ESPECPROC)
      AND (pCAD_PRD_ID IS NULL OR PRD.CAD_PRD_ID = pCAD_PRD_ID)
      AND (pHR_INI_CONSULTA IS NULL OR ags.ags_age_HR_atendimento >= pHR_INI_CONSULTA)
      AND (pHR_FIM_CONSULTA IS NULL OR ags.ags_age_HR_atendimento <= pHR_FIM_CONSULTA)
      
     group by UNI.CAD_UNI_DS_UNIDADE ,
           lat.cad_lat_ds_local_atendimento ,
           epp.aux_epp_ds_descricao ,
           setor.cad_set_ds_setor ,
           sau.age_sau_nr_sala ,
           prd.cad_prd_ds_descricao ,
           prd.cad_prd_nm_mnemonico ,
          to_char(ags.ags_age_dt_atendimento, 'dd/MM/yyyy')
           order by to_char(ags.ags_age_dt_atendimento, 'dd/MM/yyyy')
            ;
    io_cursor := v_cursor;
  end PRC_AGS_REL_ESTAT_AGENDADOS;
 