create or replace procedure PRC_AGE_REL_AGENDA_TRANSF
  (
     pDT_INICIO_CONSULTA in TB_AGE_AGD_AGENDA.AGE_AGD_DT_ATENDIMENTO%type,
     pDT_FIM_CONSULTA in TB_AGE_AGD_AGENDA.AGE_AGD_DT_ATENDIMENTO%type,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type default null,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO in TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type default null,
     pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type default null,
     pCAD_PRO_ID_PROFISSIONAL in TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%type default null,
     pAGE_SAU_CD_ANDAR IN TB_AGE_SAU_SALA_UNID_AND.AGE_SAU_CD_ANDAR%type default null,
     pAGE_ESM_HR_INI_ESCALA in TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_HR_INI_ESCALA%type default null,
     pAGE_ESM_HR_FIM_ESCALA in TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_HR_FIM_ESCALA%type default null,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AGE_REL_AGENDA_TRANSF
  * 
  *    Data Criacao:  11/09/2007   Por: Guilherme
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Alimentar relatorio de Agenda transferida
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    
  select 
           agd.age_agd_hr_atendimento,
           agd.age_agd_dt_atendimento,
           agd.age_agd_cd_intamb,
           pes.cad_pes_nm_pessoa nome_paciente,
           pac.cad_pac_nr_prontuario,
           pla.cad_pla_cd_plano_hac,
           pac.cad_pac_cd_credencial,
           pac.cad_pac_nm_titular,
           pes_pro.cad_pes_nm_pessoa nome_profissional,
           cbo.tis_cbo_ds_cbos_hac,
           esm.age_esm_hr_ini_escala,
           esm.age_esm_hr_fim_escala,
           pac.cad_pac_ds_observacao,
           sau.age_sau_cd_andar,
           tra.age_tra_id,
           pro.cad_pro_nr_conselho numero_conselho

  from 
      tb_cad_pes_pessoa pes, 
      tb_cad_pac_paciente pac, 
      tb_age_agd_agenda agd, 
      tb_age_esm_escala_medica esm,
      tb_age_sau_sala_unid_and sau,
      tb_tis_cbo_cbos cbo,
      tb_cad_pro_profissional pro,
      tb_age_agg_agenda_gerada agg,
      tb_cad_pla_plano pla,
      tb_cad_pes_pessoa pes_pro,
      tb_age_tra_transf_agenda tra

  where
      
      tra.age_agg_id_origem = agg.age_agg_id
      AND agg.age_agg_id = agd.age_agg_id
      AND tra.cad_pac_id_paciente = agd.cad_pac_id_paciente
      and agd.cad_pac_id_paciente = pac.cad_pac_id_paciente
      and agd.cad_pro_id_profissionalexec = pro.cad_pro_id_profissional
      and agd.age_agg_id = agg.age_agg_id
      and agd.age_esm_id = esm.age_esm_id
      and agg.age_esm_id = esm.age_esm_id
      

      and pac.cad_pla_id_plano = pla.cad_pla_id_plano
      
      and esm.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE
      and esm.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO
      and esm.tis_cbo_cd_cbos = cbo.tis_cbo_cd_cbos
      and esm.cad_pro_id_profissional = pro.cad_pro_id_profissional
      and esm.age_sau_id = sau.age_sau_id

      
      and pes.cad_pes_id_pessoa = pac.cad_pes_id_pessoa
      and pes_pro.cad_pes_id_pessoa = pro.cad_pes_id_pessoa
      and sau.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE
      and agd.age_agd_dt_atendimento between pDT_INICIO_CONSULTA and pDT_FIM_CONSULTA
      and (pAGE_ESM_HR_INI_ESCALA is null or agd.age_agd_hr_atendimento between pAGE_ESM_HR_INI_ESCALA and pAGE_ESM_HR_FIM_ESCALA)
      
--      and (pCAD_UNI_ID_UNIDADE is null or uni.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE)
--      and (pCAD_LAT_ID_LOCAL_ATENDIMENTO is null or lat.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
      and (pTIS_CBO_CD_CBOS is null or cbo.tis_cbo_cd_cbos = pTIS_CBO_CD_CBOS)
      and (pCAD_PRO_ID_PROFISSIONAL is null or agd.cad_pro_id_profissionalexec = pCAD_PRO_ID_PROFISSIONAL)
      and (pAGE_SAU_CD_ANDAR is null or sau.age_sau_cd_andar = pAGE_SAU_CD_ANDAR);
         
    io_cursor := v_cursor;
  end PRC_AGE_REL_AGENDA_TRANSF;
/
