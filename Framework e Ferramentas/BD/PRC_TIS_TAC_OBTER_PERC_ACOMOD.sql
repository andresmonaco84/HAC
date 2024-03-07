create or replace procedure sgs.PRC_TIS_TAC_OBTER_PERC_ACOMOD
  (
     pATD_ATE_ID                IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE,
     pDATACONSUMO               IN DATE,
     pCAD_CNV_ID_CONVENIO       IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE,
     pCAD_PLA_ID_PLANO          IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE,
     pCAD_PRD_ID                IN TB_CAD_PRD_PRODUTO.CAD_PRD_ID%TYPE,
     pCAD_TAP_TP_ATRIBUTO       IN TB_CAD_PRD_PRODUTO.CAD_TAP_TP_ATRIBUTO%TYPE,
     pAUX_GPC_CD_GRUPOPROC      IN TB_CAD_PRD_PRODUTO.AUX_GPC_CD_GRUPOPROC%TYPE,
     pAUX_EPP_CD_ESPECPROC      IN TB_CAD_PRD_PRODUTO.AUX_EPP_CD_ESPECPROC%TYPE,
     pTIS_MED_CD_TABELAMEDICA   IN TB_CAD_PRD_PRODUTO.TIS_MED_CD_TABELAMEDICA%TYPE,
     pCAD_SET_ID                IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE,
     io_cursor                  OUT PKG_CURSOR.t_cursor
  )
  is
  --Setor UTI
  SETOR_UTI_INFANTIL     constant number := 202;
  SETOR_UTI_NEONATAL     constant number := 203;
  SETOR_UTI_GERAL        constant number := 201;
  SETOR_UTI_CARDIOLOGICA constant number := 200;
  SETOR_UTI_S            constant number := 204;
  SETOR_UTI_TERREO       constant number := 2652;
  SETOR_UTIR_RETAGUARDA  constant number := 2753;
  SETOR_UTIE_GERAL       constant number := 2732;
  SETOR_UTI2_2B_COVID    constant number := 2792;
  pct_acomodacao   number;
  v_fl_considerapchmaco     tb_cad_cnv_convenio.cad_cnv_fl_considerapchmaco%type;
  v_fl_utiliza_regra_cbhpm  tb_cad_cnv_convenio.cad_cnv_fl_utiliza_regra_cbhpm%type;
  v_cursor               PKG_CURSOR.t_cursor;
  begin
  /* Vefifica se convenio considera percentual de acomodacao */
  begin
  select cnv.cad_cnv_fl_considerapchmaco, cnv.cad_cnv_fl_utiliza_regra_cbhpm
    into   v_fl_considerapchmaco, v_fl_utiliza_regra_cbhpm
    from   tb_cad_cnv_convenio cnv
    where  cnv.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO;
  exception when others then
     v_fl_considerapchmaco := null;
  end;
  if(v_fl_considerapchmaco = 'S'
     AND ((pCAD_SET_ID NOT IN (SETOR_UTI_INFANTIL, SETOR_UTI_NEONATAL ,SETOR_UTI_GERAL ,SETOR_UTI_CARDIOLOGICA, SETOR_UTI_TERREO, SETOR_UTI_S,
    SETOR_UTIR_RETAGUARDA, SETOR_UTIE_GERAL, SETOR_UTI2_2B_COVID))
          OR v_fl_utiliza_regra_cbhpm = 'S'))then
    begin
       /* Verificar se existe excecao na cvp por produto */
      select cvp.ass_cvp_pc_acomod_hm
         into pct_acomodacao
      from tb_ass_cvp_conv_vlr_produto cvp
      where cvp.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
      and cvp.cad_prd_id = pCAD_PRD_ID
      and cvp.ass_cvp_pc_acomod_hm is not null
      and (cvp.cad_pla_id_plano is null or cvp.cad_pla_id_plano = pCAD_PLA_ID_PLANO)
      and cvp.ass_cvp_fl_status = 'A'
      and fnc_validar_vigencia_data(cvp.ass_cvp_dt_inicio_vigencia, cvp.ass_cvp_dt_fim_vigencia, pDATACONSUMO) = 1
      and rownum = 1;
      exception when others then
       pct_acomodacao := null;
    end;
    if(pct_acomodacao is null) then
        begin
         /* Verificar se existe excecao na cvp por tipo de atributo / grupo / especialidade */
        select cvp.ass_cvp_pc_acomod_hm
           into pct_acomodacao
        from tb_ass_cvp_conv_vlr_produto cvp
        where cvp.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
        and cvp.cad_prd_id is null
        and cvp.ass_cvp_pc_acomod_hm is not null
        and (cvp.cad_pla_id_plano is null or cvp.cad_pla_id_plano = pCAD_PLA_ID_PLANO)
        and cvp.ass_cvp_fl_status = 'A'
        and fnc_validar_vigencia_data(cvp.ass_cvp_dt_inicio_vigencia, cvp.ass_cvp_dt_fim_vigencia, pDATACONSUMO) = 1
        and cvp.cad_tap_tp_atributo = pCAD_TAP_TP_ATRIBUTO
        and cvp.aux_epp_cd_especproc = pAUX_EPP_CD_ESPECPROC
        and cvp.tis_med_cd_tabelamedica = pTIS_MED_CD_TABELAMEDICA
        and (cvp.aux_gpc_cd_grupoproc is null or cvp.aux_gpc_cd_grupoproc = pAUX_GPC_CD_GRUPOPROC)
        and rownum = 1;
        exception when others then
         pct_acomodacao := null;
      end;
    end if;
    if(pct_acomodacao is null) then
        begin
        /* Verificar se existe associacao na ctp para IML */
           select ctp.ass_ctp_pc_hm_acomodacao
           into pct_acomodacao
          from tb_ass_cul_conv_uni_locatend cul,
               tb_ass_cnu_convenio_unidade  cnu,
               tb_cad_uni_unidade           uni,
               tb_ass_cut_conv_uni_tpacomod cut,
               tb_tis_tac_tipo_acomodacao   tac,
               tb_ass_ctp_cnv_un_tpacom_pla ctp,
               tb_ass_uta_unid_tpacomod     uta,
               tb_atd_iml_int_mov_leito     iml,
               tb_cad_cnv_convenio          cnv,
               tb_atd_ate_atendimento       ate
         where
               cul.ass_cnu_id                   = cnu.ass_cnu_id
           and uni.cad_uni_id_unidade           = cnu.cad_uni_id_unidade
           and uta.cad_uni_id_unidade           = uni.cad_uni_id_unidade
           and cut.ass_uta_id_unid_tpacomod     = uta.ass_uta_id_unid_tpacomod
           and cut.ass_cnu_id                   = cnu.ass_cnu_id
           and tac.tis_tac_cd_tipo_acomodacao   = uta.tis_tac_cd_tipo_acomodacao
           and cut.ass_cut_id                   = ctp.ass_cut_id
           /* se ficou na enfermaria, cobra enfermaria senao autorizada */
           and decode(iml.tis_tac_cd_tipo_acomodacao,1,1,iml.tis_tac_cd_tipo_acomod_aut)   = tac.tis_tac_cd_tipo_acomodacao
           and cnu.cad_cnv_id_convenio          = cnv.cad_cnv_id_convenio
           and ate.atd_ate_id                   = iml.atd_ate_id
           and uni.Cad_Uni_Id_Unidade           = ate.cad_uni_id_unidade
           and cul.cad_lat_id_local_atendimento = ate.cad_lat_id_local_atendimento
           /* Tipo de Paciente Internado */
           and ate.atd_ate_tp_paciente = 'I'
           /* Validar Vigencias */
           and fnc_validar_vigencia_data(cul.ass_cul_dt_ini_vigencia, cul.ass_cul_dt_fim_vigencia, pDATACONSUMO) = 1
           and fnc_validar_vigencia_data(cnu.ass_cnu_dt_ini_vigencia, cnu.ass_cnu_dt_fim_vigencia, pDATACONSUMO) = 1
           and fnc_validar_vigencia_data(cut.ass_cut_dt_ini_vigencia, cut.ass_cut_dt_fim_vigencia, pDATACONSUMO) = 1
           and fnc_validar_vigencia_data(ctp.ass_ctp_dt_ini_vigencia, ctp.ass_ctp_dt_fim_vigencia, pDATACONSUMO) = 1
           /* Tipo de Acomodacao na Hora do Consumo */
           and (fnc_juntar_data_hora(iml.atd_iml_dt_entrada, iml.atd_iml_hr_entrada) <=  pDATACONSUMO
               and (fnc_juntar_data_hora(iml.atd_iml_dt_saida, iml.atd_iml_hr_saida) > pDATACONSUMO or iml.atd_iml_dt_saida is null))
           /* Ativos */
           and uta.ass_uta_fl_ativo_ok = 'S'
           and uni.cad_uni_fl_status = 'A'
           and iml.atd_iml_fl_status = 'A'
           /* Filtros */
           and iml.atd_ate_id = pATD_ATE_ID
           and cnv.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
           and ctp.cad_pla_id_plano = pCAD_PLA_ID_PLANO;
         exception when others then
           pct_acomodacao := null;
         end;
    end if;
     if(pct_acomodacao is null) then
        begin
        /* Verificar se existe associacao na ctp para IMS*/
           select ctp.ass_ctp_pc_hm_acomodacao
           into pct_acomodacao
          from tb_ass_cul_conv_uni_locatend cul,
               tb_ass_cnu_convenio_unidade  cnu,
               tb_cad_uni_unidade           uni,
               tb_ass_cut_conv_uni_tpacomod cut,
               tb_tis_tac_tipo_acomodacao   tac,
               tb_ass_ctp_cnv_un_tpacom_pla ctp,
               tb_ass_uta_unid_tpacomod     uta,
               tb_atd_ims_int_mov_setor     ims,
               tb_cad_cnv_convenio          cnv,
               tb_atd_ate_atendimento       ate
         where
               cul.ass_cnu_id                   = cnu.ass_cnu_id
           and uni.cad_uni_id_unidade           = cnu.cad_uni_id_unidade
           and uta.cad_uni_id_unidade           = uni.cad_uni_id_unidade
           and cut.ass_uta_id_unid_tpacomod     = uta.ass_uta_id_unid_tpacomod
           and cut.ass_cnu_id                   = cnu.ass_cnu_id
           and tac.tis_tac_cd_tipo_acomodacao   = uta.tis_tac_cd_tipo_acomodacao
           and cut.ass_cut_id                   = ctp.ass_cut_id
           and ims.tis_tac_cd_tipo_acomod_aut   = tac.tis_tac_cd_tipo_acomodacao
           and cnu.cad_cnv_id_convenio          = cnv.cad_cnv_id_convenio
           and ate.atd_ate_id                   = ims.atd_ate_id
           and uni.Cad_Uni_Id_Unidade           = ate.cad_uni_id_unidade
           and cul.cad_lat_id_local_atendimento = ate.cad_lat_id_local_atendimento
             /* Tipo de Paciente Internado */
           and ate.atd_ate_tp_paciente = 'I'
           /* Validar Vigencias */
           and fnc_validar_vigencia_data(cul.ass_cul_dt_ini_vigencia, cul.ass_cul_dt_fim_vigencia, pDATACONSUMO) = 1
           and fnc_validar_vigencia_data(cnu.ass_cnu_dt_ini_vigencia, cnu.ass_cnu_dt_fim_vigencia, pDATACONSUMO) = 1
           and fnc_validar_vigencia_data(cut.ass_cut_dt_ini_vigencia, cut.ass_cut_dt_fim_vigencia, pDATACONSUMO) = 1
           and fnc_validar_vigencia_data(ctp.ass_ctp_dt_ini_vigencia, ctp.ass_ctp_dt_fim_vigencia, pDATACONSUMO) = 1
           /* Tipo de Acomodacao na Hora do Consumo */
           and (fnc_juntar_data_hora(ims.atd_ims_dt_entrada, ims.atd_ims_hr_entrada) <=  pDATACONSUMO
               and (fnc_juntar_data_hora(ims.atd_ims_dt_saida, ims.atd_ims_hr_saida) >= pDATACONSUMO or ims.atd_ims_dt_saida is null))
           /* Ativos */
           and uta.ass_uta_fl_ativo_ok = 'S'
           and uni.cad_uni_fl_status = 'A'
           and ims.atd_ims_fl_status = 'A'
           /* Filtros */
           and ims.atd_ate_id = pATD_ATE_ID
           and cnv.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
           and ctp.cad_pla_id_plano = pCAD_PLA_ID_PLANO;
         exception when others then
           pct_acomodacao := null;
         end;
    end if;
end if;
  OPEN v_cursor FOR
  select pct_acomodacao as tis_tac_pc_acomodacao_hm from dual;
  io_cursor := v_cursor;
end PRC_TIS_TAC_OBTER_PERC_ACOMOD;
/
