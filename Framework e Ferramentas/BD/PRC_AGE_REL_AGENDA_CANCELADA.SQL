create or replace procedure PRC_AGE_REL_AGENDA_CANCELADA
  (
     pDT_INICIO_CONSULTA in TB_AGE_AGD_AGENDA.AGE_AGD_DT_ATENDIMENTO%type,
     pDT_FIM_CONSULTA in TB_AGE_AGD_AGENDA.AGE_AGD_DT_ATENDIMENTO%type,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type default null,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO in TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type default null,
     pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type default null,
     pCAD_PRO_ID_PROFISSIONAL in TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%type default null,
     pAGE_SAU_CD_ANDAR IN TB_AGE_SAU_SALA_UNID_AND.AGE_SAU_CD_ANDAR%type default null,
    -- pAGE_AGD_FL_STATUS IN TB_AGE_AGD_AGENDA.AGE_AGD_FL_STATUS%type default null,
     pAGE_ESM_HR_INI_ESCALA in TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_HR_INI_ESCALA%type default null,
     pAGE_ESM_HR_FIM_ESCALA in TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_HR_FIM_ESCALA%type default null,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_REL_AGENDA_CANCELADA
  *
  *    Data Criacao:  22/10/2007   Por: Guilherme
  *
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Alimentar relatorio de Agendamentos Cancelados, com nome
  *            de usuario e data de cancelamento.
  *
  *    Alterac?o: Retorno de senha de agenda e data de nascimento do paciente
  *
  *   Data Alterac?o: 14/10/2008  por: Pedro
  *   Alterac?o: retirado agendamentos cancelados da tabela de agenda e passado para tb_age_agc_agenda_cancelada
  *   Data Alterac?o: 15/12/2008 Por: Silmara
  *   Alterac?o: retirada da tb_age_agg_agenda_gerada,n?o e mais obrigatorio o relacionamento.
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
            usu.seg_usu_ds_nome,
            agc.age_agc_dt_cancelamento,
           agc.age_agd_hr_atendimento,
           agc.age_agd_dt_atendimento,
           agc.age_agd_cd_intamb,
           pes.cad_pes_nm_pessoa nome_paciente,
           pac.cad_pac_nr_prontuario,
           pla.cad_pla_cd_plano_hac,
           pac.cad_pac_cd_credencial,
           pac.cad_pac_nm_titular,
           pes_pro.cad_pes_nm_pessoa nome_profissional,
           lat.cad_lat_ds_local_atendimento,
           cbo.tis_cbo_ds_cbos_hac,
           esm.age_esm_hr_ini_escala,
           esm.age_esm_hr_fim_escala,
           agc.age_agc_ds_observacao age_agd_ds_observacao,
           sau.age_sau_cd_andar,
           pro.cad_pro_nr_conselho numero_conselho,
           FNC_SENHA_UTILIZADA(agc.age_agd_id,'C') senha,
           TO_CHAR(pes.cad_pes_dt_nascimento,'dd/MM/yyyy') data_nascimento_pac,
           fnc_cad_pes_telefone_s(PES.CAD_PES_ID_PESSOA,1) TEL
    from
           tb_cad_pes_pessoa pes,
           tb_cad_pac_paciente pac,
           tb_age_esm_escala_medica esm,
           tb_cad_uni_unidade uni,
           tb_cad_lat_local_atendimento lat,
           tb_age_sau_sala_unid_and sau,
           tb_tis_cbo_cbos cbo,
           tb_cad_pro_profissional pro,
           tb_age_pee_periodo_escala pee,
           tb_cad_pla_plano pla,
           tb_cad_cnv_convenio cnv,
           tb_cad_pes_pessoa pes_uni,
           tb_cad_pes_pessoa pes_pro,
           tb_age_agc_agenda_cancelada agc,
           tb_seg_usu_usuario usu
    where
            agc.cad_pac_id_paciente = pac.cad_pac_id_paciente
           and agc.cad_pro_id_profissionalexec = pro.cad_pro_id_profissional
           and agc.age_esm_id = esm.age_esm_id
           AND agc.age_agd_id = agc.age_agd_id
           AND usu.seg_usu_id_usuario = agc.seg_usu_id_usuario
           and pac.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
           and pac.cad_pla_id_plano = pla.cad_pla_id_plano
           and esm.cad_uni_id_unidade = uni.cad_uni_id_unidade
           and esm.cad_lat_id_local_atendimento = lat.cad_lat_id_local_atendimento
           and esm.tis_cbo_cd_cbos = cbo.tis_cbo_cd_cbos
           and esm.cad_pro_id_profissional = pro.cad_pro_id_profissional
           and esm.age_sau_id = sau.age_sau_id
           and esm.age_pee_id = pee.age_pee_id
           and pes.cad_pes_id_pessoa = pac.cad_pes_id_pessoa
           and pes_uni.cad_pes_id_pessoa = uni.cad_pes_id_pessoa
           and pes_pro.cad_pes_id_pessoa = pro.cad_pes_id_pessoa
           and sau.cad_uni_id_unidade = uni.cad_uni_id_unidade
           
           and (:pDT_INICIO_CONSULTA IS NULL or AGC.age_agd_dt_atendimento >= :pDT_INICIO_CONSULTA )
           and (:pDT_FIM_CONSULTA IS NULL or AGC.age_agd_dt_atendimento <= :pDT_FIM_CONSULTA )
           and (:pDT_INICIO_CANCEL IS NULL or AGC.AGE_AGC_DT_CANCELAMENTO >= :pDT_INICIO_CANCEL )
           and (:pDT_FIM_CANCEL IS NULL or AGC.AGE_AGC_DT_CANCELAMENTO <= :pDT_FIM_CANCEL )
           and (:pAGE_ESM_HR_INI_ESCALA is null or agc.age_agd_hr_atendimento between :pAGE_ESM_HR_INI_ESCALA and :pAGE_ESM_HR_FIM_ESCALA)
           and (uni.cad_uni_id_unidade = :pCAD_UNI_ID_UNIDADE)
           and (lat.cad_lat_id_local_atendimento = :pCAD_LAT_ID_LOCAL_ATENDIMENTO)
           and (:pTIS_CBO_CD_CBOS is null or cbo.tis_cbo_cd_cbos = :pTIS_CBO_CD_CBOS)
           and (:pCAD_PRO_ID_PROFISSIONAL is null or agc.cad_pro_id_profissionalexec = :pCAD_PRO_ID_PROFISSIONAL)
           and (:pAGE_SAU_CD_ANDAR is null or sau.age_sau_cd_andar = :pAGE_SAU_CD_ANDAR);
    io_cursor := v_cursor;
  end PRC_AGE_REL_AGENDA_CANCELADA;
