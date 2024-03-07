create or replace procedure PRC_TIS_TAC_CNV_PLA_DIARIA
  (          
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE,
     pCAD_PLA_ID_PLANO    IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE,
     pCODPAD              IN TB_ATD_ATE_ATENDIMENTO.CODPAD%TYPE,
     pDATACONSUMO         IN DATE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is 
  v_cursor            PKG_CURSOR.t_cursor;
  SD01 CONSTANT NUMBER := 281;     
  GG05 CONSTANT NUMBER := 283;
  begin
      if(pCAD_CNV_ID_CONVENIO <> SD01 AND pCAD_CNV_ID_CONVENIO <> GG05) then  
      OPEN v_cursor FOR
          select distinct tac.tis_tac_cd_tipo_acomodacao
          from tb_ass_cut_conv_uni_tpacomod cut,
               tb_ass_ctp_cnv_un_tpacom_pla ctp,
               tb_ass_uta_unid_tpacomod     uta,
               tb_tis_tac_tipo_acomodacao   tac,
               tb_ass_cnu_convenio_unidade  cnu
         where cut.ass_uta_id_unid_tpacomod = uta.ass_uta_id_unid_tpacomod
          and cut.ass_cut_id = ctp.ass_cut_id
          and uta.tis_tac_cd_tipo_acomodacao = tac.tis_tac_cd_tipo_acomodacao
          and cnu.ass_cnu_id = cut.ass_cnu_id   
          and ctp.cad_pla_id_plano = pCAD_PLA_ID_PLANO
          and cnu.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO            
          and fnc_validar_vigencia_data(cnu.ass_cnu_dt_ini_vigencia, cnu.ass_cnu_dt_fim_vigencia, pDATACONSUMO) = 1
          and fnc_validar_vigencia_data(cut.ass_cut_dt_ini_vigencia, cut.ass_cut_dt_fim_vigencia, pDATACONSUMO) = 1
          and fnc_validar_vigencia_data(ctp.ass_ctp_dt_ini_vigencia, ctp.ass_ctp_dt_fim_vigencia, pDATACONSUMO) = 1;
      else
      OPEN v_cursor FOR
          select distinct tac.tis_tac_cd_tipo_acomodacao 
          from tb_cad_taa_tipo_acomodacao_acs acs, tb_tis_tac_tipo_acomodacao tac 
          where acs.tis_tac_cd_tipo_acomodacao = tac.tis_tac_cd_tipo_acomodacao
          and acs.cad_taa_cd_tipo_acomodacao_acs = pCODPAD;
      end if; 
    
    io_cursor := v_cursor;
            
end PRC_TIS_TAC_CNV_PLA_DIARIA;

