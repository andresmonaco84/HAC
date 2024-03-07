create or replace procedure PRC_FAT_CCI_OBTER_PSALA
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
      select cvp.ass_cvp_tp_porte_sala
    from tb_ass_cvp_conv_vlr_produto cvp
    where cvp.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
    and cvp.cad_prd_id = pCAD_PRD_ID
    and cvp.ass_cvp_tp_porte_sala is not null
    and (cvp.cad_pla_id_plano is null or cvp.cad_pla_id_plano = pCAD_PLA_ID_PLANO)
    and cvp.ass_cvp_fl_status = 'A'
    and fnc_validar_vigencia_data(cvp.ass_cvp_dt_inicio_vigencia, cvp.ass_cvp_dt_fim_vigencia, pDATACONSUMO) = 1
    and rownum = 1;    
    
    io_cursor := v_cursor;
    
end PRC_FAT_CCI_OBTER_PSALA;
