CREATE OR REPLACE PROCEDURE "PRC_ATE_REL_ATEND_TPATEND"
  (
     pCAD_UNI_ID_UNIDADE in TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO in TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type default null,
     pCAD_SET_NR_ANDAR in TB_CAD_SET_SETOR.CAD_SET_NR_ANDAR%type default null,
     pCAD_SET_ID in TB_CAD_SET_SETOR.CAD_SET_ID%type default null,
     pCAD_CNV_ID_CONVENIO in TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type default null,
     pCAD_PLA_ID_PLANO in TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%type default null,
     pTIS_CBO_CD_CBOS in TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type default null,
     pCAD_PRO_ID_PROFISSIONAL in TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%type default null,
     pATD_DT_INICIO in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%type default null,
     pATD_DT_FIM in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%type default null,
     pATD_HR_INICIO in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_HR_ATENDIMENTO%type default null,
     pATD_HR_FIM in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_HR_ATENDIMENTO%type default null,
     pTIS_TAT_CD_TPATENDIMENTO in TB_TIS_TAT_TP_ATENDIMENTO.TIS_TAT_CD_TPATENDIMENTO%type default null,
     pCAD_PLA_CD_TIPOPLANO in TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%type default null,
     pATD_ATE_FL_INDIC_RN_OK in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_FL_INDIC_RN_OK%type default null,
     pATD_ATE_FL_RETORNO_OK in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_FL_RETORNO_OK%type default null,
     pATD_ATE_FL_STATUS in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_FL_STATUS%type default null,
          pCAD_CGC_ID IN tb_cad_cnv_convenio.cad_cgc_id%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATE_REL_ATEND_TPATEND
  * 
 *
  *    Alterac?o dos campos do Select
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
 select 
       UNI.CAD_UNI_DS_UNIDADE ds_unidade,             
       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'PLANO ACS' 
              WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'FU' THEN 'FUNCIONARIO'
              WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'SP' THEN 'S.PRESTADO'
              WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'NP' THEN 'NAO PAGANTE'
              ELSE 'PARTICULAR'
         END TIPO_EMPRESA,
       cbo.tis_cbo_ds_cbos_hac ds_especialidade,
       PRO.CAD_PRO_NR_CONSELHO nr_conselho,
       PRO.CAD_PRO_NM_NOME nm_medico,
       cnv.cad_cnv_cd_hac_prestador cd_convenio,       
       tat.tis_tat_ds_tpatendimento ds_tipo_atendimento,
       Count(atd.atd_ate_id)  quantidade
        from tb_atd_ate_atendimento atd
     inner join tb_cad_uni_unidade uni
        on uni.cad_uni_id_unidade = atd.cad_uni_id_unidade
        and (pCAD_UNI_ID_UNIDADE is null or atd.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE)
     inner join tb_cad_lat_local_atendimento lat
        on lat.cad_lat_id_local_atendimento = atd.cad_lat_id_local_atendimento
       and (pCAD_LAT_ID_LOCAL_ATENDIMENTO is null or atd.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
     inner join tb_cad_set_setor setor
        on atd.cad_set_id = setor.cad_set_id
       and (pCAD_SET_NR_ANDAR  is null or setor.cad_set_nr_andar = pCAD_SET_NR_ANDAR)
       AND (pCAD_SET_ID is null or setor.CAD_SET_ID = pCAD_SET_ID)
     inner join tb_tis_cbo_cbos cbo
        on atd.tis_cbo_cd_cbos = cbo.tis_cbo_cd_cbos
       and (pTIS_CBO_CD_CBOS is null or atd.tis_cbo_cd_cbos = pTIS_CBO_CD_CBOS)
     LEFT join tb_cad_pro_profissional pro
        on atd.cad_pro_id_prof_exec = pro.cad_pro_id_profissional
     inner join tb_ass_pat_pacieatend pat
        on atd.atd_ate_id = pat.atd_ate_id
     inner join tb_cad_pac_paciente pac
        on pac.cad_pac_id_paciente = pat.cad_pac_id_paciente
     left join tb_age_agd_agenda agd
        on agd.age_agd_cd_intamb = atd.atd_ate_id
     inner join tb_cad_cnv_convenio cnv
        on cnv.cad_cnv_id_convenio = pac.cad_cnv_id_convenio
       and (pCAD_CNV_ID_CONVENIO is null or pac.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO)
     inner join tb_cad_pla_plano pla
        on pla.cad_pla_id_plano = pac.cad_pla_id_plano
       and (pCAD_PLA_ID_PLANO is null or pac.cad_pla_id_plano = pCAD_PLA_ID_PLANO)
       and (pCAD_PLA_CD_TIPOPLANO is null or pla.cad_pla_cd_tipoplano = pCAD_PLA_CD_TIPOPLANO)
     inner join tb_tis_tat_tp_atendimento tat
        on tat.tis_tat_cd_tpatendimento = atd.tis_tat_cd_tpatendimento
       and (pTIS_TAT_CD_TPATENDIMENTO is null or tat.tis_tat_cd_tpatendimento = pTIS_TAT_CD_TPATENDIMENTO)
     where
           (atd.atd_ate_dt_atendimento between pATD_DT_INICIO and pATD_DT_FIM)
       and (pATD_HR_INICIO is null or atd.atd_ate_hr_atendimento >= pATD_HR_INICIO)
       and (pATD_HR_FIM is null or atd.atd_ate_hr_atendimento <= pATD_HR_FIM)
       and (pATD_ATE_FL_INDIC_RN_OK is null or atd.atd_ate_fl_indic_rn_ok = pATD_ATE_FL_INDIC_RN_OK)
       and (pATD_ATE_FL_RETORNO_OK is null or atd.atd_ate_fl_retorno_ok = pATD_ATE_FL_RETORNO_OK)
       and (pCAD_PRO_ID_PROFISSIONAL is null or atd.cad_pro_id_prof_exec = pCAD_PRO_ID_PROFISSIONAL)
        AND (pCAD_CGC_ID IS NULL OR CNV.CAD_CGC_ID = pCAD_CGC_ID)
       and (atd.atd_ate_fl_status = 'A')
    GROUP BY
       UNI.CAD_UNI_DS_UNIDADE,              
       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB','PL') THEN 'PLANO ACS' 
              WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'FU' THEN 'FUNCIONARIO'
              WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'SP' THEN 'S.PRESTADO'
              WHEN PLA.CAD_PLA_CD_TIPOPLANO = 'NP' THEN 'NAO PAGANTE'
                ELSE 'PARTICULAR' END,
       cbo.tis_cbo_ds_cbos_hac,
       PRO.CAD_PRO_NR_CONSELHO,
       PRO.CAD_PRO_NM_NOME ,
       --atd.atd_ate_id,
       cnv.cad_cnv_cd_hac_prestador,      
       tat.tis_tat_ds_tpatendimento
       ;
    io_cursor := v_cursor;
  end PRC_ATE_REL_ATEND_TPATEND;
