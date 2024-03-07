create or replace procedure sgs.PRC_AGE_REL_AGENDA_SEP_PRONT
  (
     pDT_INICIO_CONSULTA in TB_AGE_AGD_AGENDA.AGE_AGD_DT_ATENDIMENTO%type,
     pDT_FIM_CONSULTA in TB_AGE_AGD_AGENDA.AGE_AGD_DT_ATENDIMENTO%type,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type default null,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO in TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type default null,
     pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type default null,
     pCAD_PRO_ID_PROFISSIONAL in TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%type default null,
     pAGE_SAU_CD_ANDAR IN TB_AGE_SAU_SALA_UNID_AND.AGE_SAU_CD_ANDAR%type default null,
     pAGE_AGD_FL_STATUS IN TB_AGE_AGD_AGENDA.AGE_AGD_FL_STATUS%type default null,
     pAGE_ESM_HR_INI_ESCALA in TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_HR_INI_ESCALA%type default null,
     pAGE_ESM_HR_FIM_ESCALA in TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_HR_FIM_ESCALA%type default null,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_REL_AGENDA_SEP_PRONT
  *
  *  Funcao: Alimentar relatorio de Agendamentos para separac?o de prontuario
  *
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
     pac.cad_pac_id_paciente,
           agd.age_agd_hr_atendimento,
           agd.age_agd_dt_atendimento,
           agd.age_agd_cd_intamb,
           pes.cad_pes_nm_pessoa nome_paciente,
           pac.cad_pac_nr_prontuario,
           cnv.cad_cnv_cd_hac_prestador,
           pla.cad_pla_cd_plano_hac,
           pac.cad_pac_cd_credencial,
           pac.cad_pac_nm_titular,           
           pro.cad_pro_nm_nome nome_profissional,
           lat.cad_lat_ds_local_atendimento,
           cbo.tis_cbo_ds_cbos_hac,
           esm.age_esm_hr_ini_escala,
           esm.age_esm_hr_fim_escala,
           agd.age_agd_ds_observacao,
           sau.age_sau_cd_andar,
           pro.cad_pro_nr_conselho numero_conselho,
           FNC_AGE_AGD_ATEND_PAC_S
                  (uni.cad_uni_id_unidade,
                   pac.cad_pac_id_paciente,
                   agd.age_agd_dt_atendimento, 
                   agd.age_agd_id)
           Proximo_Atendimento
    FROM   tb_age_agd_agenda agd
    JOIN   tb_age_esm_escala_medica esm ON AGD.AGE_ESM_ID = ESM.AGE_ESM_ID 
    JOIN   tb_cad_pac_paciente pac ON PAC.CAD_PAC_ID_PACIENTE = AGD.CAD_PAC_ID_PACIENTE
    JOIN   tb_cad_pes_pessoa pes ON PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA
    JOIN   tb_cad_uni_unidade uni ON UNI.CAD_UNI_ID_UNIDADE = ESM.CAD_UNI_ID_UNIDADE
    JOIN   tb_cad_lat_local_atendimento lat ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO
    JOIN   tb_age_sau_sala_unid_and sau ON SAU.AGE_SAU_ID = ESM.AGE_SAU_ID
    JOIN   tb_tis_cbo_cbos cbo ON CBO.TIS_CBO_CD_CBOS = ESM.TIS_CBO_CD_CBOS
    JOIN   tb_cad_pro_profissional pro ON PRO.CAD_PRO_ID_PROFISSIONAL = ESM.CAD_PRO_ID_PROFISSIONAL
    JOIN   tb_age_pee_periodo_escala pee ON PEE.AGE_PEE_ID = ESM.AGE_PEE_ID
    JOIN   tb_age_agg_agenda_gerada agg ON AGG.AGE_ESM_ID = ESM.AGE_ESM_ID AND AGG.AGE_AGG_ID = AGD.AGE_AGG_ID
    JOIN   tb_cad_pla_plano pla ON PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
    JOIN   tb_cad_cnv_convenio cnv ON CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
    where
           (agd.age_agd_fl_status = Upper(pAGE_AGD_FL_STATUS))
          
           and (esm.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE)
           AND (SAU.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
           and (esm.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
           and (agd.age_agd_dt_atendimento between pDT_INICIO_CONSULTA and pDT_FIM_CONSULTA)
           and (pAGE_ESM_HR_INI_ESCALA is null or 
                             (to_char(agd.age_agd_dt_atendimento, 'dd/MM/yyyy') = TO_CHAR(sysdate, 'dd/MM/yyyy')
                              and agd.age_agd_hr_atendimento between pAGE_ESM_HR_INI_ESCALA and 
                                                                     pAGE_ESM_HR_FIM_ESCALA))
          
           and (pTIS_CBO_CD_CBOS is null or ESM.tis_cbo_cd_cbos = pTIS_CBO_CD_CBOS)
           and (pCAD_PRO_ID_PROFISSIONAL is null or esm.cad_pro_id_profissional = pCAD_PRO_ID_PROFISSIONAL)
           and (pAGE_SAU_CD_ANDAR is null or sau.age_sau_cd_andar = pAGE_SAU_CD_ANDAR)
            AND (NOT EXISTS 
               (SELECT agg.age_agg_id FROM 
                       tb_age_esf_escala_faltas esf
                  WHERE agg.age_esm_id = esf.age_esm_id
                    AND trunc(agg.age_agg_dt_agenda) BETWEEN trunc(esf.age_esf_dt_ini_falta) AND trunc(esf.age_esf_dt_fim_falta)
                    AND (esf.age_esf_hr_ini_falta is NULL or trunc(agg.age_agg_hr_agenda) BETWEEN trunc(esf.age_esf_hr_ini_falta) AND trunc(esf.age_esf_hr_fim_falta))
                    AND esf.cad_pro_id_profissional_subst IS NULL
               ));
    io_cursor := v_cursor;
  end PRC_AGE_REL_AGENDA_SEP_PRONT;
