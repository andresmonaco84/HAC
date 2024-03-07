create or replace procedure prc_age_rel_cons_online_pac
(
  pCAD_CNV_ID_CONVENIO             IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
  pCAD_PLA_ID_PLANO                IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE DEFAULT NULL,
  pCAD_UNI_ID_UNIDADE              IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
  pCAD_LAT_ID_LOCAL_ATENDIMENTO    IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
  pTIS_CBO_CD_CBOS                 IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE DEFAULT NULL,
  pCAD_PRO_ID_PROFISSIONAL         IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%TYPE DEFAULT NULL,
  pDT_INICIO_CONSULTA              IN TB_AGE_AGD_AGENDA.AGE_AGD_DT_ATENDIMENTO%TYPE DEFAULT NULL,
  pDT_FIM_CONSULTA                 IN TB_AGE_AGD_AGENDA.AGE_AGD_DT_ATENDIMENTO%TYPE DEFAULT NULL,
  pCAD_PES_NM_PESSOA               IN TB_CAD_PES_PESSOA.CAD_PES_NM_PESSOA%TYPE DEFAULT NULL,
  pCAD_PAC_CD_CREDENCIAL           IN TB_CAD_PAC_PACIENTE.CAD_PAC_CD_CREDENCIAL%TYPE DEFAULT NULL,
  io_cursor                        OUT PKG_CURSOR.t_cursor
  )
is
  v_cursor PKG_CURSOR.t_cursor;
  BEGIN
  
    /********************************************************************
  *    Procedure: prc_age_rel_cons_online_pac
  *
  *    Data Criacao:  ??/??/????   Por: ????????
  *    Data Alteracao: 22/11/2007  Por: Guilherme
  *    Alteração: Correção do decode de credencial
  *
  *    Funcao: Agendamentos online
  *
  *******************************************************************/
 
       OPEN v_cursor FOR
               select
                      cnv.cad_cnv_cd_hac_prestador convenio,
                      pla.cad_pla_cd_plano_hac plano,
                      pes_uni.cad_pes_nm_pessoa unidade,
                      lat.cad_lat_ds_local_atendimento local_atendimento,
                      cbo.tis_cbo_ds_cbos_hac especialidade,
                      pes_pro.cad_pes_nm_pessoa profissional,
                      agd.age_agd_dt_atendimento data_atendimento,
                      agd.age_agd_hr_atendimento hora_atendimento,
                      pes.cad_pes_nm_pessoa paciente,
                      decode(agg.age_agg_tp_horario, 1, 'N',
                                                     2, 'E',
                                                     3, 'EE',
                                                     4, 'R',
                                                     5, 'SP') tipo_horario,
                      decode(esm.age_esm_nr_dia_semana, 1, '2º',
                                                        2, '3º',
                                                        3, '4º',
                                                        4, '5º',
                                                        5, '6º',
                                                        6, 'S') dia_semana,
                      sau.age_sau_nr_sala sala,
                      sau.age_sau_cd_andar andar,
--                      prd.cad_prd_ds_descricao produto,
                      subst.substituto substituto,
                      agd.age_agd_ds_observacao obs,
--                      agd.age_agd_dt_ultima_atualizacao ultimaatualizacao,
                      agd.seg_usu_id_usuario usuario--,
--                      agd.age_agd_tp_agenda tipoagenda
              from    tb_age_agd_agenda agd,
                      tb_age_agg_agenda_gerada agg,
                      tb_age_esm_escala_medica esm,
                      tb_cad_uni_unidade uni,
                      tb_cad_lat_local_atendimento lat,
                      tb_tis_cbo_cbos cbo,
                      tb_cad_pro_profissional pro,
                      tb_age_sau_sala_unid_and sau,
--                      tb_age_pee_periodo_escala pee,
                      tb_cad_cnv_convenio cnv,
                      tb_cad_pla_plano pla,
                      tb_cad_pac_paciente pac,
                      tb_cad_pes_pessoa pes,
                      tb_cad_pes_pessoa pes_uni,
                      tb_cad_pes_pessoa pes_pro,
                      tb_cad_pes_pessoa pes_conv,
                      tb_cad_prd_produto prd, ( select  agg.age_agg_id, pes.cad_pes_nm_pessoa substituto
                                                from    tb_cad_pes_pessoa pes,
                                                        tb_age_agd_agenda agd,
                                                        tb_age_agg_agenda_gerada agg,
                                                        tb_age_esm_escala_medica esm,
                                                        tb_cad_uni_unidade uni,
                                                        tb_cad_lat_local_atendimento lat,
                                                        tb_tis_cbo_cbos cbo,
                                                        tb_cad_pro_profissional pro1,
                                                        tb_cad_pro_profissional pro2,
                                                        tb_age_esf_escala_faltas esf,
                                                        tb_age_sau_sala_unid_and sau,
                                                        -- tb_age_pee_periodo_escala pee,
                                                        tb_cad_cnv_convenio cnv,
                                                        tb_cad_pla_plano pla,
                                                        tb_cad_pac_paciente pac,
                                                        tb_cad_prd_produto prd
                                                where   agd.age_agd_fl_status <> 'C'
                                                and     agd.age_agd_fl_status <> 'F'
                                                and     agg.age_agg_id = agd.age_agg_id
                                                and     esm.age_esm_id = agg.age_esm_id
                                                and     esf.age_esm_id = esm.age_esm_id
                                                and     esf.cad_pro_id_profissional_subst = pro2.cad_pro_id_profissional
                                                and     pes.cad_pes_id_pessoa = pro2.cad_pes_id_pessoa
                                                and     esm.cad_uni_id_unidade = uni.cad_uni_id_unidade
                                                and     esm.cad_lat_id_local_atendimento = lat.cad_lat_id_local_atendimento
                                                and     esm.tis_cbo_cd_cbos = cbo.tis_cbo_cd_cbos
                                                and     esm.cad_pro_id_profissional = pro1.cad_pro_id_profissional
                                                and     esm.age_sau_id = sau.age_sau_id
                                                -- and     esm.age_pee_id = pee.age_pee_id
                                                and     agd.cad_pac_id_paciente = pac.cad_pac_id_paciente
                                                and     pac.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
                                                and     pac.cad_pla_id_plano = pla.cad_pla_id_plano
                                                -- and     pes.cad_pes_id_pessoa = pac.cad_pes_id_pessoa
                                                and     agd.cad_prd_id = prd.cad_prd_id

                                                   and     agd.age_esm_id = esm.age_esm_id
                                                   and     agd.age_esm_id = agg.age_esm_id
                                                   and     pla.cad_cnv_id_convenio= cnv.cad_cnv_id_convenio

                                                and    (decode(pCAD_CNV_ID_CONVENIO, 0, null, pCAD_CNV_ID_CONVENIO) is null or cnv.cad_cnv_id_convenio = decode(pCAD_CNV_ID_CONVENIO, 0, null, pCAD_CNV_ID_CONVENIO) )
                                                and    (decode(pCAD_PLA_ID_PLANO, 0, null, pCAD_PLA_ID_PLANO) is null or pla.cad_pla_id_plano = decode(pCAD_PLA_ID_PLANO, 0, null, pCAD_PLA_ID_PLANO) )
                                                and    (decode(pCAD_UNI_ID_UNIDADE, 0, null, pCAD_UNI_ID_UNIDADE) is null or uni.cad_uni_id_unidade = decode(pCAD_UNI_ID_UNIDADE, 0, null, pCAD_UNI_ID_UNIDADE) )
                                                and    (decode(pCAD_LAT_ID_LOCAL_ATENDIMENTO, 0, null, pCAD_LAT_ID_LOCAL_ATENDIMENTO) is null or lat.cad_lat_id_local_atendimento = decode(pCAD_LAT_ID_LOCAL_ATENDIMENTO, 0, null, pCAD_LAT_ID_LOCAL_ATENDIMENTO) )
                                                and    (decode(pTIS_CBO_CD_CBOS, 0, null, pTIS_CBO_CD_CBOS) is null or cbo.tis_cbo_cd_cbos = decode(pTIS_CBO_CD_CBOS, 0, null, pTIS_CBO_CD_CBOS) )
                                                and    (decode(pCAD_PRO_ID_PROFISSIONAL, 0, null, pCAD_PRO_ID_PROFISSIONAL) is null or esm.cad_pro_id_profissional = decode(pCAD_PRO_ID_PROFISSIONAL, 0, null, pCAD_PRO_ID_PROFISSIONAL) )
                                                and    ( (pDT_FIM_CONSULTA IS  NULL OR agd.age_agd_dt_atendimento between pDT_INICIO_CONSULTA and pDT_FIM_CONSULTA ) OR
                                                         (TRUNC(agd.age_agd_dt_atendimento) >= TRUNC(pDT_INICIO_CONSULTA)) )
                                                and    (UPPER(pCAD_PES_NM_PESSOA) is null or pes.cad_pes_nm_pessoa LIKE UPPER( '%'||pCAD_PES_NM_PESSOA||'%' ) )
                                                AND    (decode(pCAD_PAC_CD_CREDENCIAL, 0, null, pCAD_PAC_CD_CREDENCIAL) is null or pac.cad_pac_cd_credencial = decode(pCAD_PAC_CD_CREDENCIAL, 0, null, pCAD_PAC_CD_CREDENCIAL))
                                                ) subst
              where   agd.age_agd_fl_status <> 'C'
              and     agd.age_agd_fl_status <> 'F'
              and     agd.age_agg_id = agg.age_agg_id
              and     agg.age_esm_id = esm.age_esm_id
              and     esm.cad_uni_id_unidade = uni.cad_uni_id_unidade
              and     esm.cad_lat_id_local_atendimento = lat.cad_lat_id_local_atendimento
              and     esm.tis_cbo_cd_cbos = cbo.tis_cbo_cd_cbos
              and     esm.cad_pro_id_profissional = pro.cad_pro_id_profissional
              and     esm.age_sau_id = sau.age_sau_id
--              and     esm.age_pee_id = pee.age_pee_id
              and     agd.cad_pac_id_paciente = pac.cad_pac_id_paciente
              and     subst.age_agg_id (+) = agg.age_agg_id
              and     pac.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
              and     pac.cad_pla_id_plano = pla.cad_pla_id_plano
              and     pes.cad_pes_id_pessoa = pac.cad_pes_id_pessoa
              and     pes_uni.cad_pes_id_pessoa = uni.cad_pes_id_pessoa
              and     pes_pro.cad_pes_id_pessoa = pro.cad_pes_id_pessoa
              and     pes_conv.cad_pes_id_pessoa = cnv.cad_pes_id_pessoa
              and     agd.cad_prd_id = prd.cad_prd_id

                 and     agd.age_esm_id = esm.age_esm_id
                 and     agd.age_esm_id = agg.age_esm_id
                 and     pla.cad_cnv_id_convenio= cnv.cad_cnv_id_convenio

              and    (decode(pCAD_CNV_ID_CONVENIO, 0, null, pCAD_CNV_ID_CONVENIO) is null or cnv.cad_cnv_id_convenio = decode(pCAD_CNV_ID_CONVENIO, 0, null, pCAD_CNV_ID_CONVENIO))
              and    (decode(pCAD_PLA_ID_PLANO, 0, null, pCAD_PLA_ID_PLANO) is null or pla.cad_pla_id_plano = decode(pCAD_PLA_ID_PLANO, 0, null, pCAD_PLA_ID_PLANO))
              and    (decode(pCAD_UNI_ID_UNIDADE, 0, null, pCAD_UNI_ID_UNIDADE) is null or uni.cad_uni_id_unidade = decode(pCAD_UNI_ID_UNIDADE, 0, null, pCAD_UNI_ID_UNIDADE))
              and    (decode(pCAD_LAT_ID_LOCAL_ATENDIMENTO, 0, null, pCAD_LAT_ID_LOCAL_ATENDIMENTO) is null or lat.cad_lat_id_local_atendimento = decode(pCAD_LAT_ID_LOCAL_ATENDIMENTO, 0, null, pCAD_LAT_ID_LOCAL_ATENDIMENTO))
              and    (decode(pTIS_CBO_CD_CBOS, 0, null, pTIS_CBO_CD_CBOS) is null or cbo.tis_cbo_cd_cbos = decode(pTIS_CBO_CD_CBOS, 0, null, pTIS_CBO_CD_CBOS))
              and    (decode(pCAD_PRO_ID_PROFISSIONAL, 0, null, pCAD_PRO_ID_PROFISSIONAL) is null or agd.cad_pro_id_profissionalexec = decode(pCAD_PRO_ID_PROFISSIONAL, 0, null, pCAD_PRO_ID_PROFISSIONAL))
              and    ( (agd.age_agd_dt_atendimento between pDT_INICIO_CONSULTA and pDT_FIM_CONSULTA and pDT_FIM_CONSULTA IS NOT NULL) OR
                       (agd.age_agd_dt_atendimento >= pDT_INICIO_CONSULTA and pDT_FIM_CONSULTA IS NULL) )
              and    (UPPER(pCAD_PES_NM_PESSOA) is null or pes.cad_pes_nm_pessoa LIKE UPPER( '%'||pCAD_PES_NM_PESSOA||'%' ) )

              AND    (decode(pCAD_PAC_CD_CREDENCIAL, '0', null, pCAD_PAC_CD_CREDENCIAL) is null or pac.cad_pac_cd_credencial = decode(pCAD_PAC_CD_CREDENCIAL, '0', null, pCAD_PAC_CD_CREDENCIAL))
              ORDER BY agd.age_agd_dt_atendimento, agd.age_agd_hr_atendimento;
  io_cursor := v_cursor;
  --Atualizado 30/09/07 13:17
end PRC_AGE_REL_CONS_ONLINE_PAC;
/
