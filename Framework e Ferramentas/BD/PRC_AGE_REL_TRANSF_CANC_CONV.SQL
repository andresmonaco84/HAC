create or replace procedure PRC_AGE_REL_TRANSF_CANC_CONV
  (
     pDT_INICIO_CONSULTA           IN TB_AGE_AGD_AGENDA.AGE_AGD_DT_ATENDIMENTO%type,
     pDT_FIM_CONSULTA              IN TB_AGE_AGD_AGENDA.AGE_AGD_DT_ATENDIMENTO%type,
     pCAD_UNI_ID_UNIDADE           IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type                     DEFAULT NULL,
     pTIS_CBO_CD_CBOS              IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type                           DEFAULT NULL,
     pCAD_CNV_ID_CONVENIO          IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE                   DEFAULT NULL,
     pCAD_PLA_ID_PLANO             IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE                         DEFAULT NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN tb_cad_lat_local_atendimento.cad_lat_id_local_atendimento%TYPE DEFAULT NULL,
     io_cursor                     OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AGE_REL_TRANSF_CANC_CONV
  * 
  *    Data Criacao:  20/09/2007   Por: Guilherme
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Alimentar relatorio de Agendamentos a Transferir/Cancelar
  *            por Convênio
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    
   select 
                                               agd.age_agd_id,
                             lat.cad_lat_cd_local_atendimento,
                               uni.cad_uni_cd_unid_hospitalar,
                                 cnv.cad_cnv_cd_hac_prestador,
                      pes_cnv.cad_pes_nm_pessoa nome_convenio,
                  pes_pro.cad_pes_nm_pessoa nome_profissional,
                                      cbo.tis_cbo_cd_cbos_hac,      --mnemonico especialidade
                                   agd.age_agd_hr_atendimento,
                                   agd.age_agd_dt_atendimento,
                      pes_pac.cad_pes_nm_pessoa nome_paciente,
FNC_CAD_PES_TELEFONE_S(pac.cad_pes_id_pessoa, 1) tel_paciente,
    FNC_CAD_PES_EMAIL_S(pac.cad_pes_id_pessoa) email_paciente,
                                      pla.cad_pla_cd_plano_hac,
                                      pro.cad_pro_nr_conselho numero_conselho 
   FROM
                    tb_cad_uni_unidade uni,
                   tb_cad_cnv_convenio cnv,
                 tb_cad_pes_pessoa pes_cnv,
               tb_cad_pro_profissional pro,
                 tb_cad_pes_pessoa pes_pro,
                       tb_tis_cbo_cbos cbo,
                     tb_age_agd_agenda agd,
                 tb_cad_pes_pessoa pes_pac,
                   tb_cad_pac_paciente pac,
              tb_age_esm_escala_medica esm,
                      tb_cad_pla_plano pla,
           tb_cad_lat_local_atendimento lat
            
          WHERE

          
              (pCAD_LAT_ID_LOCAL_ATENDIMENTO  IS NULL OR lat.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
          AND (pCAD_UNI_ID_UNIDADE            IS NULL OR uni.cad_uni_id_unidade           = pCAD_UNI_ID_UNIDADE)
          AND (pCAD_CNV_ID_CONVENIO           IS NULL OR cnv.cad_cnv_id_convenio          = pCAD_CNV_ID_CONVENIO)
          AND (pTIS_CBO_CD_CBOS               IS NULL OR  cbo.tis_cbo_cd_cbos             = pTIS_CBO_CD_CBOS)          
          AND (pCAD_PLA_ID_PLANO              IS NULL OR pla.cad_pla_id_plano             = pCAD_PLA_ID_PLANO)

          AND (agd.age_agd_dt_atendimento BETWEEN pDT_INICIO_CONSULTA AND pDT_FIM_CONSULTA)
          AND agd.age_agd_fl_status<>'C'    

          AND cnv.cad_cnv_id_convenio          = pac.cad_cnv_id_convenio
          AND cnv.cad_pes_id_pessoa            = pes_cnv.cad_pes_id_pessoa
          AND cbo.tis_cbo_cd_cbos              = esm.tis_cbo_cd_cbos
          AND esm.age_esm_id                   = agd.age_esm_id
          AND esm.cad_uni_id_unidade           = uni.cad_uni_id_unidade
          AND esm.cad_pro_id_profissional      = pro.cad_pro_id_profissional
          AND esm.tis_cbo_cd_cbos              = cbo.tis_cbo_cd_cbos
          AND esm.cad_lat_id_local_atendimento = lat.cad_lat_id_local_atendimento
          AND pac.cad_pac_id_paciente          = agd.cad_pac_id_paciente
          AND pac.cad_pes_id_pessoa            = pes_pac.cad_pes_id_pessoa
          AND agd.cad_pro_id_profissionalexec  = esm.cad_pro_id_profissional
          AND pro.cad_pes_id_pessoa            = pes_pro.cad_pes_id_pessoa
          AND pla.cad_cnv_id_convenio          = cnv.cad_cnv_id_convenio
          AND pac.cad_pla_id_plano             = pla.cad_pla_id_plano
          
          ORDER BY 
             cnv.cad_cnv_cd_hac_prestador,
             uni.cad_uni_cd_hospitalar,
             lat.cad_lat_id_local_atendimento,
             cbo.tis_cbo_ds_cbos,
             pes_pro.cad_pes_nm_pessoa,
             agd.age_agd_dt_atendimento,
             agd.age_agd_hr_atendimento ;          

    io_cursor := v_cursor;
  end PRC_AGE_REL_TRANSF_CANC_CONV;
/
