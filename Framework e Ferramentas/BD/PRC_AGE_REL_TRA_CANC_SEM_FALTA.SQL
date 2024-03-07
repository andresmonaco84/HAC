CREATE OR REPLACE PROCEDURE PRC_AGE_REL_TRA_CANC_SEM_FALTA(pDT_INICIO_CONSULTA           in TB_AGE_AGD_AGENDA.AGE_AGD_DT_ATENDIMENTO%type,
                                                             pDT_FIM_CONSULTA              in TB_AGE_AGD_AGENDA.AGE_AGD_DT_ATENDIMENTO%type,
                                                             pCAD_UNI_ID_UNIDADE           IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type,
                                                             pCAD_LAT_ID_LOCAL_ATENDIMENTO in TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
                                                             pTIS_CBO_CD_CBOS              IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type default null,
                                                             pCAD_PRO_ID_PROFISSIONAL      in TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%type default null,
                                                             pAGE_SAU_CD_ANDAR             IN TB_AGE_SAU_SALA_UNID_AND.AGE_SAU_CD_ANDAR%type default null,
                                                             pAGE_ESM_HR_INI_ESCALA        in TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_HR_INI_ESCALA%type default null,
                                                             pAGE_ESM_HR_FIM_ESCALA        in TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_HR_FIM_ESCALA%type default null,
                                                             pTELEMEDICINA                 in Tb_Age_Agd_Agenda.Age_Agd_Fl_Telemedicina%type default null,
                                                             io_cursor                     OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_AGE_REL_TRA_CANC_SEM_FALTA
 *
  *    Data Alterarcao: 10/6/2016 Por: pedro
  *    Alteracao: add hr age
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
    select usu.seg_usu_ds_nome nome_usuario,
           decode(agd.age_agd_tp_agenda,
                  1,
                  'N',
                  2,
                  'E',
                  3,
                  'EE',
                  4,
                  'R',
                  5,
                  'SP',
                  6,
                  'TMD') tipo_horario,
           agd.age_agd_fl_status status_agendamento,
           SAU.AGE_SAU_CD_ANDAR,
           cbo.tis_cbo_ds_cbos_hac,
           pro.cad_pro_nm_nome nome_profissional,
           agd.age_agd_dt_atendimento,
           agd.age_agd_hr_atendimento,
           agd.age_agd_dt_agenda,
           agd.AGE_AGD_HR_AGENDA,
           esm.age_esm_hr_ini_escala,
           esm.age_esm_hr_fim_escala,
           agg.age_agg_id,
           agd.age_agd_id,
           agg.age_agg_hr_agenda,
           pes_paciente.cad_pes_nm_pessoa nome_paciente,
           pac.cad_pac_nr_prontuario,
           sau.age_sau_cd_andar,
           pla.cad_pla_cd_plano_hac,
           cnv.cad_cnv_cd_hac_prestador,
           pac.cad_pac_cd_credencial,
           pac.cad_pac_nm_titular,
           FNC_CAD_PES_TELEFONE_LISTA_S(pac.cad_pes_id_pessoa) tel_paciente,
           FNC_CAD_PES_EMAIL_S(pac.cad_pes_id_pessoa) email_paciente,
           FNC_CAD_PES_MUNICIPIO_S(pac.cad_pes_id_pessoa, 1) municipio_paciente,
           FNC_CAD_PES_ENDERECO_S(pac.cad_pes_id_pessoa, 1) endereco_paciente,
           agd.age_agd_ds_observacao obs_agendamento,
           pro.cad_pro_nr_conselho numero_conselho,
           agd.age_agd_fl_exige_profissional,
           FNC_SENHA_UTILIZADA(agd.age_agd_id, NULL) senha,
           TO_CHAR(pes_paciente.cad_pes_dt_nascimento, 'dd/MM/yyyy') data_nascimento_pac,
           esf.cad_pro_id_profissional_subst PRO_ID_SUB,
           prof_sub.cad_pro_nr_conselho PRO_NRO_CRM_SUB,
           prof_sub.cad_pro_nm_nome PRO_NOME_SUB,
           decode(agd.age_agd_fl_telemedicina,'S','TELEMEDICINA','PRESENCIAL') AGE_AGD_FL_TELEMEDICINA
           
      from tb_age_agg_agenda_gerada agg,
           tb_cad_pac_paciente      pac,
           tb_cad_pes_pessoa        pes_paciente,
           tb_age_esm_escala_medica esm,
           tb_age_sau_sala_unid_and sau,
           tb_age_agd_agenda        agd,
           tb_cad_pla_plano         pla,
           tb_tis_cbo_cbos          cbo,
           tb_cad_pro_profissional  pro,
           tb_seg_usu_usuario       usu,
           tb_cad_cnv_convenio      cnv,
           tb_age_esf_escala_faltas esf,
           tb_cad_pro_profissional prof_sub
     where agg.age_agg_id = agd.age_agg_id
       and agg.age_esm_id = esm.age_esm_id
       and agg.age_esf_id = esf.age_esf_id (+)
       and esf.cad_pro_id_profissional_subst = prof_sub.cad_pro_id_profissional (+)
       and agd.cad_pac_id_paciente = pac.cad_pac_id_paciente
       and agd.age_esm_id = esm.age_esm_id
       and esm.age_sau_id = sau.age_sau_id
       and esm.tis_cbo_cd_cbos = cbo.tis_cbo_cd_cbos
       and esm.cad_pro_id_profissional = pro.cad_pro_id_profissional
       and pac.cad_pes_id_pessoa = pes_paciente.cad_pes_id_pessoa
       and pac.cad_pla_id_plano = pla.cad_pla_id_plano
       AND usu.seg_usu_id_usuario = agd.seg_usu_id_usuario
       and pla.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
          --Filtros *******************
          --  and    agd.age_agd_fl_status   = 'P'
          --AND  agd.age_agd_fl_status   <> 'C'
       AND (agd.age_agd_fl_status <> 'C' or exists
            (select *
               from tb_atd_ate_atendimento ate
              where ate.atd_ate_id = agd.age_agd_cd_intamb
                and ate.atd_ate_fl_status = 'C'))
       and agd.age_agd_dt_atendimento between pDT_INICIO_CONSULTA AND pDT_FIM_CONSULTA
       and (pAGE_ESM_HR_INI_ESCALA is null OR agd.age_agd_hr_atendimento between pAGE_ESM_HR_INI_ESCALA AND pAGE_ESM_HR_FIM_ESCALA)
       and (esm.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE)
       and (esm.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
       and (pTIS_CBO_CD_CBOS is null OR esm.tis_cbo_cd_cbos = pTIS_CBO_CD_CBOS)
       and (pCAD_PRO_ID_PROFISSIONAL is null OR esm.cad_pro_id_profissional = pCAD_PRO_ID_PROFISSIONAL)
       and (pAGE_SAU_CD_ANDAR is null OR sau.age_sau_cd_andar = pAGE_SAU_CD_ANDAR)
       and (pTELEMEDICINA is null or agd.age_agd_fl_telemedicina = pTELEMEDICINA)
       AND NOT EXISTS
     (SELECT agg.age_agg_id
              FROM tb_age_esf_escala_faltas esf
             WHERE agg.age_esm_id = esf.age_esm_id
               AND trunc(agg.age_agg_dt_agenda) BETWEEN
                   trunc(esf.age_esf_dt_ini_falta) AND
                   trunc(esf.age_esf_dt_fim_falta) AND
                   (
                       esf.age_esf_hr_ini_falta is null or
                       agg.age_agg_hr_agenda between esf.age_esf_hr_ini_falta and esf.age_esf_hr_fim_falta
                   )
               AND esf.cad_pro_id_profissional_subst IS NULL)
     ORDER BY agd.age_agd_dt_atendimento,
              agd.age_agd_hr_atendimento,
              agd.age_agd_fl_status;
  io_cursor := v_cursor;
end PRC_AGE_REL_TRA_CANC_SEM_FALTA;
