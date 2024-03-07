CREATE OR REPLACE PROCEDURE "PRC_AGE_REL_MAIS_15DIAS"
  (
       PTIS_CBO_CD_CBOS IN tb_tis_cbo_cbos.tis_cbo_cd_cbos%type DEFAULT NULL,
       PCAD_UNI_ID_UNIDADE IN tb_cad_uni_unidade.cad_uni_id_unidade%type DEFAULT NULL,
       PCAD_LAT_ID_LOCAL_ATENDIMENTO IN tb_cad_lat_local_atendimento.cad_lat_id_local_atendimento%type DEFAULT NULL,
       PCAD_PLA_CD_TIPOPLANO IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
      io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_REL_MAIS_15DIAS
  *
  *    Data Criacao:   13/10/2010           Por: Eduardo Hyppolito
  *    Funcao: Verifica agendamento de consultas para mais de 15 dias
  *
  *
  *********************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
begin
      OPEN v_cursor FOR
SELECT count(decode(age.age_agd_fl_exige_profissional,'S',age.age_agd_fl_exige_profissional) )qtd_s,
       count(decode(age.age_agd_fl_exige_profissional,'N',age.age_agd_fl_exige_profissional,'','N')) qtd_n,
       TO_NUMBER(UNI.CAD_UNI_CD_UNID_HOSPITALAR) CAD_UNI_CD_UNID_HOSPITALAR,
       UNI.Cad_Uni_Ds_Unidade,
       cbo.tis_cbo_cd_cbos,
       CBO.TIS_CBO_DS_CBOS_HAC
       --age.age_agd_fl_exige_profissional
from
  tb_age_esm_escala_medica med,
  tb_age_agd_agenda age,
  tb_tis_cbo_cbos cbo,
  tb_cad_uni_unidade uni,
  tb_cad_lat_local_atendimento lat,
  tb_cad_pac_paciente pac,
  tb_cad_pla_plano pla
where
                   age.age_esm_id = med.age_esm_id
AND                med.tis_cbo_cd_cbos = cbo.tis_cbo_cd_cbos
AND                med.age_esm_fl_situacao IN('A','S')
AND                med.cad_uni_id_unidade = uni.cad_uni_id_unidade
AND                med.age_esm_id=age.age_esm_id
AND                age.age_agd_fl_status='P'
AND                age.age_agd_dt_atendimento >=(sysdate + 15)
and                pla.cad_pla_id_plano = pac.cad_pla_id_plano
and                age.cad_pac_id_paciente = pac.cad_pac_id_paciente
and                med.cad_lat_id_local_atendimento = lat.cad_lat_id_local_atendimento
AND                (PTIS_CBO_CD_CBOS is null or cbo.tis_cbo_cd_cbos = PTIS_CBO_CD_CBOS)
AND                (PCAD_UNI_ID_UNIDADE is null or uni.cad_uni_id_unidade = PCAD_UNI_ID_UNIDADE)
AND                (PCAD_LAT_ID_LOCAL_ATENDIMENTO is null or lat.cad_lat_id_local_atendimento = PCAD_LAT_ID_LOCAL_ATENDIMENTO)
and                (PCAD_PLA_CD_TIPOPLANO IS NULL OR PLA.CAD_PLA_CD_TIPOPLANO = PCAD_PLA_CD_TIPOPLANO)
group by
      UNI.Cad_Uni_Ds_Unidade,
      UNI.CAD_UNI_CD_UNID_HOSPITALAR,
      CBO.TIS_CBO_DS_CBOS_HAC,
      cbo.tis_cbo_cd_cbos
      --age.age_agd_fl_exige_profissional
order by 2,5;
  io_cursor := v_cursor;
end PRC_AGE_REL_MAIS_15DIAS;
