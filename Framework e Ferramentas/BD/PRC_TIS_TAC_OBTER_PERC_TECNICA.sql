create or replace procedure sgs.PRC_TIS_TAC_OBTER_PERC_TECNICA
  (
     pATD_ATE_ID            IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE,
     pDATACONSUMO           IN DATE,
     pCAD_CNV_ID_CONVENIO   IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE,
     pCAD_PLA_ID_PLANO      IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is  
   v_cursor               PKG_CURSOR.t_cursor;
    begin  
    OPEN v_cursor FOR    
       select distinct ctp.ass_ctp_pc_hm_artroscopia, ctp.ass_ctp_pc_hm_laparoscopia              
      from tb_ass_cul_conv_uni_locatend cul,
           tb_ass_cnu_convenio_unidade  cnu,
           tb_cad_uni_unidade           uni,
           tb_ass_cut_conv_uni_tpacomod cut,
           tb_tis_tac_tipo_acomodacao   tac,
           tb_ass_ctp_cnv_un_tpacom_pla ctp,
           tb_ass_uta_unid_tpacomod     uta,
           tb_atd_iml_int_mov_leito     iml,           
           tb_cad_cnv_convenio          cnv
     where 
           cul.ass_cnu_id                 = cnu.ass_cnu_id
       and uni.cad_uni_id_unidade         = cnu.cad_uni_id_unidade   
       and uta.cad_uni_id_unidade         = uni.cad_uni_id_unidade
       and cut.ass_uta_id_unid_tpacomod   = uta.ass_uta_id_unid_tpacomod
       and cut.ass_cnu_id                 = cnu.ass_cnu_id
       and tac.tis_tac_cd_tipo_acomodacao = uta.tis_tac_cd_tipo_acomodacao
       and cut.ass_cut_id                 = ctp.ass_cut_id       
       and iml.tis_tac_cd_tipo_acomod_aut = tac.tis_tac_cd_tipo_acomodacao
       and cnu.cad_cnv_id_convenio        = cnv.cad_cnv_id_convenio
       /* Validar Vigencias */
       and fnc_validar_vigencia_data(cul.ass_cul_dt_ini_vigencia, cul.ass_cul_dt_fim_vigencia, pDATACONSUMO) = 1
       and fnc_validar_vigencia_data(cnu.ass_cnu_dt_ini_vigencia, cnu.ass_cnu_dt_fim_vigencia, pDATACONSUMO) = 1
       and fnc_validar_vigencia_data(cut.ass_cut_dt_ini_vigencia, cut.ass_cut_dt_fim_vigencia, pDATACONSUMO) = 1
       and fnc_validar_vigencia_data(ctp.ass_ctp_dt_ini_vigencia, ctp.ass_ctp_dt_fim_vigencia, pDATACONSUMO) = 1
       /* Tipo de Acomodacao na Hora do Consumo */
       and (fnc_juntar_data_hora(iml.atd_iml_dt_entrada, iml.atd_iml_hr_entrada) <=  pDATACONSUMO 
           and (fnc_juntar_data_hora(iml.atd_iml_dt_saida, iml.atd_iml_hr_saida) > pDATACONSUMO) or 
               (iml.atd_iml_dt_saida is null))
       /* Ativos */           
       and uta.ass_uta_fl_ativo_ok = 'S'
       and uni.cad_uni_fl_status = 'A'           
       and iml.atd_iml_fl_status = 'A'   
       /* Filtros */  
       and iml.atd_ate_id = pATD_ATE_ID   
       and cnv.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
       and ctp.cad_pla_id_plano = pCAD_PLA_ID_PLANO
       union 
       select distinct case
                  when atd.atd_ate_tp_paciente = 'E' and
                       cnv.cad_cnv_id_convenio = 281 and
                       ctp.ass_ctp_pc_hm_artroscopia >= 100 then
                   (ctp.ass_ctp_pc_hm_artroscopia -
                   nvl(tac.tis_tac_pc_acomodacao_hm, 0))
                  else
                   ctp.ass_ctp_pc_hm_artroscopia
                end ass_ctp_pc_hm_artroscopia,
                case
                  when atd.atd_ate_tp_paciente = 'E' and
                       cnv.cad_cnv_id_convenio = 281 and
                       ctp.ass_ctp_pc_hm_laparoscopia >= 100 then
                   (ctp.ass_ctp_pc_hm_laparoscopia -
                   nvl(tac.tis_tac_pc_acomodacao_hm, 0))
                  else
                   ctp.ass_ctp_pc_hm_laparoscopia
                end ass_ctp_pc_hm_laparoscopia
  from tb_ass_cul_conv_uni_locatend cul,
       tb_ass_cnu_convenio_unidade  cnu,
       tb_cad_uni_unidade           uni,
       tb_ass_cut_conv_uni_tpacomod cut,
       tb_tis_tac_tipo_acomodacao   tac,
       tb_ass_ctp_cnv_un_tpacom_pla ctp,
       tb_ass_uta_unid_tpacomod     uta,
       tb_atd_ims_int_mov_setor     ims,
       tb_cad_cnv_convenio          cnv,
       tb_atd_ate_atendimento       atd
 where cul.ass_cnu_id = cnu.ass_cnu_id
       and uni.cad_uni_id_unidade         = cnu.cad_uni_id_unidade
       and uta.cad_uni_id_unidade         = uni.cad_uni_id_unidade
       and cut.ass_uta_id_unid_tpacomod   = uta.ass_uta_id_unid_tpacomod
       and cut.ass_cnu_id                 = cnu.ass_cnu_id
       and tac.tis_tac_cd_tipo_acomodacao = uta.tis_tac_cd_tipo_acomodacao
       and cut.ass_cut_id                 = ctp.ass_cut_id
       and iMS.tis_tac_cd_tipo_acomod_aut = tac.tis_tac_cd_tipo_acomodacao
       and cnu.cad_cnv_id_convenio        = cnv.cad_cnv_id_convenio 
       and ims.atd_ate_id=atd.atd_ate_id 
       /* Tipo de paciente internado */
       and atd.atd_ate_tp_paciente in ('I', 'E')
        /* Validar Vigencias */
       and fnc_validar_vigencia_data(cul.ass_cul_dt_ini_vigencia, cul.ass_cul_dt_fim_vigencia, pDATACONSUMO) = 1
       and fnc_validar_vigencia_data(cnu.ass_cnu_dt_ini_vigencia, cnu.ass_cnu_dt_fim_vigencia, pDATACONSUMO) = 1
       and fnc_validar_vigencia_data(cut.ass_cut_dt_ini_vigencia, cut.ass_cut_dt_fim_vigencia, pDATACONSUMO) = 1
       and fnc_validar_vigencia_data(ctp.ass_ctp_dt_ini_vigencia, ctp.ass_ctp_dt_fim_vigencia, pDATACONSUMO) = 1
       /* Tipo de Acomodacao na Hora do Consumo */
       and (fnc_juntar_data_hora(ims.atd_ims_dt_entrada, ims.atd_ims_hr_entrada) <=  pDATACONSUMO )
        and uta.ass_uta_fl_ativo_ok = 'S'
       and uni.cad_uni_fl_status = 'A'
       and ims.atd_ims_fl_status = 'A'
       /* Filtros */
       and ims.atd_ate_id = pATD_ATE_ID
       and cnv.cad_cnv_id_convenio =  pCAD_CNV_ID_CONVENIO
       and ctp.cad_pla_id_plano = pCAD_PLA_ID_PLANO 
       and rownum = 1;
  io_cursor := v_cursor;
end PRC_TIS_TAC_OBTER_PERC_TECNICA;
 