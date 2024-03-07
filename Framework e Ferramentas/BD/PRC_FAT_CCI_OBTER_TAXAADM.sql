create or replace procedure PRC_FAT_CCI_OBTER_TAXAADM
  (  pDATACONSUMO           IN DATE,
     pCAD_CNV_ID_CONVENIO   IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE,
     pCAD_PLA_ID_PLANO      IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE,
     pCAD_PRD_ID            IN TB_CAD_PRD_PRODUTO.CAD_PRD_ID%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  v_cursor               PKG_CURSOR.t_cursor;
  begin  
  
    OPEN v_cursor FOR    
      select cvp.ass_cvp_id,
             cvp.cad_cnv_id_convenio,
             cvp.cad_lat_id_local_atendimento,
             cvp.cad_tap_tp_atributo,
             cvp.cad_prd_id,
             cvp.cad_tih_tp_indice_hosp,
             cvp.ass_cvp_qt_indice_hosp,
             cvp.ass_cvp_vl_indice_hosp,
             cvp.ass_cvp_tp_porte,
             cvp.ass_cvp_vl_produto,
             cvp.ass_cvp_qt_maxima_perm,
             cvp.ass_cvp_qt_minima_perm,
             cvp.ass_cvp_pc_acrescimo,
             cvp.ass_cvp_pc_desconto,
             cvp.ass_cvp_vl_acrescimo,
             cvp.ass_cvp_vl_desconto,
             cvp.ass_cvp_pc_taxaadm,
             cvp.ass_cvp_pc_doppler,
             cvp.ass_cvp_dt_inicio_vigencia,
             cvp.ass_cvp_dt_fim_vigencia,
             cvp.tis_cde_cd_codigo_despesa,
             cvp.ass_cpe_id,
             cvp.ass_dt_ultima_atualizacao,
             cvp.seg_usu_id_usuario,
             cvp.ass_cvp_fl_pc_acrescimohr,
             cvp.ass_cvp_fl_isen_cobra,
             cvp.ass_cvp_fl_cobert_anest,
             cvp.ass_cvp_tp_unid_consumo,
             cvp.ass_cvp_pc_acomod_hm,
             cvp.cad_pla_id_plano,
             cvp.cad_spl_id,
             cvp.cad_uni_id_unidade,
             cvp.aux_epp_cd_especproc,
             cvp.aux_gpc_cd_grupoproc,
             cvp.tis_med_cd_tabelamedica,
             cvp.ass_cvp_fl_status,
             cvp.ass_cvp_tp_porte_sala,
             cvp.cad_prd_id_taxa_adm
        from tb_ass_cvp_conv_vlr_produto cvp
       where cvp.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
             and cvp.cad_prd_id = pCAD_PRD_ID
             and cvp.cad_prd_id_taxa_adm is not null
             and (cvp.cad_pla_id_plano is null or cvp.cad_pla_id_plano = pCAD_PLA_ID_PLANO)
             and cvp.ass_cvp_fl_status = 'A'
             and fnc_validar_vigencia_data(cvp.ass_cvp_dt_inicio_vigencia, cvp.ass_cvp_dt_fim_vigencia, pDATACONSUMO) = 1
             and rownum = 1;     
    
    io_cursor := v_cursor;
    
end PRC_FAT_CCI_OBTER_TAXAADM;
