CREATE OR REPLACE PROCEDURE PRC_CAD_VCM_VERIFICA_NF_S
  (
     pCAD_CNV_ID_CONVENIO   in       TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_CNV_ID_CONVENIO%TYPE,
     pCAD_PRD_ID            in       TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_PRD_ID%TYPE,
     pTIS_MED_CD_TABELAMEDICA in     TB_CAD_VCM_VAL_COBR_MAT_MED.TIS_MED_CD_TABELAMEDICA%TYPE,
     pCAD_TAP_TP_ATRIBUTO in         TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_TAP_TP_ATRIBUTO%TYPE,
     pCAD_CMM_CD_CARACMATMED in      TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_CMM_CD_CARACMATMED%TYPE,
     pCAD_PLA_ID_PLANO        in     TB_CAD_VCM_VAL_COBR_MAT_MED.CAD_PLA_ID_PLANO%TYPE,
     pDATACONSUMO             in     DATE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_VCM_VERIFICA_NF_S  --CADASTRO REMOTING
  *
  *    Data Alteracao: 7/8/2012    Por: André Souza Monaco
  *         Alteração: Quando não achar na exceção, buscar no cadastro do produto para materiais.
  *                    Para medicamentos, sempre buscar no cadastro do produto quando achar na exceção
  *    Data Alteracao: 19/10/2012    Por: André Souza Monaco
  *         Alteração: Para medicamentos, sempre buscar no cadastro do produto (sem verificação na exceção)
  *
  *    Funcao: Verifica se produto utiliza NF e se é Isento de Cobrança  
  ******************************************************************/
  v_count  NUMBER := 0;
  v_cursor PKG_CURSOR.t_cursor;
  begin  
   if (pCAD_TAP_TP_ATRIBUTO = 'MAT') THEN
     select count(1)
     into v_count
     from tb_cad_vcm_val_cobr_mat_med vcm
     where vcm.cad_prd_id = pCAD_PRD_ID
     and vcm.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
     and vcm.tis_med_cd_tabelamedica = pTIS_MED_CD_TABELAMEDICA
     --and vcm.cad_cmm_cd_caracmatmed = pCAD_CMM_CD_CARACMATMED
     and vcm.cad_tap_tp_atributo = pCAD_TAP_TP_ATRIBUTO
     and (vcm.cad_pla_id_plano = pCAD_PLA_ID_PLANO or vcm.cad_pla_id_plano is null)
     and vcm.cad_vcm_fl_status = 'A'
     and fnc_validar_vigencia_data(vcm.cad_vcm_dt_inicio_vigencia, vcm.cad_vcm_dt_fim_vigencia,pDATACONSUMO) = 1;
    
     if v_count > 0 THEN     
       OPEN v_cursor FOR
        select CASE WHEN NVL(vcm.cad_vcm_fl_utiliza_vl_nf, 'N') = 'S' THEN 'S'                             
                        ELSE (select nvl(cad_prd_fl_notafiscalmatmed, 'N')
                                from tb_cad_prd_produto
                               where cad_prd_id = pCAD_PRD_ID 
                                 and tis_med_cd_tabelamedica = pTIS_MED_CD_TABELAMEDICA)
                   END cad_vcm_fl_utiliza_vl_nf,
               NVL(vcm.cad_vcm_fl_isento_cobranca, 'N') cad_vcm_fl_isento_cobranca
        from tb_cad_vcm_val_cobr_mat_med vcm
        where vcm.cad_prd_id = pCAD_PRD_ID
        and vcm.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
        and vcm.tis_med_cd_tabelamedica = pTIS_MED_CD_TABELAMEDICA
        --and vcm.cad_cmm_cd_caracmatmed = pCAD_CMM_CD_CARACMATMED
        and vcm.cad_tap_tp_atributo = pCAD_TAP_TP_ATRIBUTO
        and vcm.cad_vcm_fl_status = 'A'
        and fnc_validar_vigencia_data(vcm.cad_vcm_dt_inicio_vigencia, vcm.cad_vcm_dt_fim_vigencia,pDATACONSUMO) = 1
        and (vcm.cad_pla_id_plano = pCAD_PLA_ID_PLANO or vcm.cad_pla_id_plano is null)
        order by vcm.cad_pla_id_plano;        
     else     
       select count(1)
       into v_count
       from tb_cad_vcm_val_cobr_mat_med vcm
       where vcm.cad_prd_id is null
       and vcm.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
       and vcm.tis_med_cd_tabelamedica = pTIS_MED_CD_TABELAMEDICA
       and vcm.cad_cmm_cd_caracmatmed = pCAD_CMM_CD_CARACMATMED
       and vcm.cad_tap_tp_atributo = pCAD_TAP_TP_ATRIBUTO
       and vcm.cad_vcm_fl_status = 'A'
       and fnc_validar_vigencia_data(vcm.cad_vcm_dt_inicio_vigencia, vcm.cad_vcm_dt_fim_vigencia,pDATACONSUMO) = 1
       and (vcm.cad_pla_id_plano = pCAD_PLA_ID_PLANO or vcm.cad_pla_id_plano is null);
       
       if v_count > 0 THEN
           OPEN v_cursor FOR
            select CASE WHEN NVL(vcm.cad_vcm_fl_utiliza_vl_nf, 'N') = 'S' THEN 'S'                             
                        ELSE (select nvl(cad_prd_fl_notafiscalmatmed, 'N')
                                from tb_cad_prd_produto
                               where cad_prd_id = pCAD_PRD_ID 
                                 and tis_med_cd_tabelamedica = pTIS_MED_CD_TABELAMEDICA)
                   END cad_vcm_fl_utiliza_vl_nf,
                   NVL(vcm.cad_vcm_fl_isento_cobranca, 'N') cad_vcm_fl_isento_cobranca
            from tb_cad_vcm_val_cobr_mat_med vcm
            where vcm.cad_prd_id is null
            and vcm.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
            and vcm.tis_med_cd_tabelamedica = pTIS_MED_CD_TABELAMEDICA
            and vcm.cad_cmm_cd_caracmatmed = pCAD_CMM_CD_CARACMATMED
            and vcm.cad_tap_tp_atributo = pCAD_TAP_TP_ATRIBUTO
            and vcm.cad_vcm_fl_status = 'A'
            and fnc_validar_vigencia_data(vcm.cad_vcm_dt_inicio_vigencia, vcm.cad_vcm_dt_fim_vigencia,pDATACONSUMO) = 1
            and (vcm.cad_pla_id_plano = pCAD_PLA_ID_PLANO or vcm.cad_pla_id_plano is null)
            order by vcm.cad_pla_id_plano;
       else
           OPEN v_cursor FOR
            select nvl(cad_prd_fl_notafiscalmatmed, 'N') cad_vcm_fl_utiliza_vl_nf,
                   NVL(cad_prd_fl_isento_cobranca, 'N') cad_vcm_fl_isento_cobranca
              from tb_cad_prd_produto
             where cad_prd_id = pCAD_PRD_ID 
               and tis_med_cd_tabelamedica = pTIS_MED_CD_TABELAMEDICA;
       end if;      
     end if;
   elsif (pCAD_TAP_TP_ATRIBUTO = 'MED') THEN       
       -- Busca flag no cadastro de produto
        OPEN v_cursor FOR
          select nvl(cad_prd_fl_notafiscalmatmed, 'N') cad_vcm_fl_utiliza_vl_nf, 
                 NVL(cad_prd_fl_isento_cobranca, 'N') cad_vcm_fl_isento_cobranca
            from tb_cad_prd_produto
           where cad_prd_id = pCAD_PRD_ID 
             and tis_med_cd_tabelamedica = pTIS_MED_CD_TABELAMEDICA;           
   end if;
io_cursor := v_cursor;
end PRC_CAD_VCM_VERIFICA_NF_S;
