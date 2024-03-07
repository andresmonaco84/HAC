create or replace procedure PRC_ASS_CTU_CNV_PORTESALA
(
   pCAD_CNV_ID_CONVENIO IN TB_ASS_CTU_CNV_TAB_UTILIZA.CAD_CNV_ID_CONVENIO%type,
   pCAD_PRD_TP_PORTE IN  TB_CAD_PRD_PRODUTO.CAD_PRD_TP_PORTE%TYPE,  
   io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ASS_CTU_CNV_PORTESALA
*    Autor: Marcus Relva // 16/12/2010
*    Retorna o produto de taxa de sala de acordo com a tabela utilizada
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
     OPEN v_cursor FOR
      select prd.cad_prd_tp_porte_sala,
             prd.cad_prd_tp_porte_cbhpm,
             prd.cad_prd_fl_cobrapchmaco,
             prd.cad_prd_fl_notafiscalmatmed,
             prd.cad_prd_cd_codigo_amb92,
             prd.cad_prd_fl_mat_consignado,
             prd.cad_prd_nm_tab_apre_matmed,
             prd.cad_prd_cd_tab_apre_matmed,
             prd.cad_prd_cd_tabela_matmed,
             prd.cad_prd_tp_embalag_matmed,
             prd.cad_prd_nm_fabr_matmed,
             prd.cad_prd_cd_fabr_matmed,
             prd.cad_prd_id_produto_matmed,
             prd.cad_prd_vl_matmed_fabr_fra,
             prd.cad_prd_vl_matmed_vend_fra,
             prd.cad_cmm_cd_caracmatmed,
             prd.cad_prd_fl_matespecial,
             prd.cad_prd_vl_matmed_fabrica,
             prd.cad_prd_fl_usorestritomed,
             prd.cad_cme_classif_med,
             prd.cad_prd_vl_unitario,
             prd.cad_prd_fl_alto_custo,
             prd.cad_prd_cd_barra,
             prd.cad_prd_fl_kit,
             prd.cad_prd_pc_desconto,
             prd.cad_prd_fl_estoque_acs,
             prd.cad_prd_fl_isento_cobranca,
             prd.cad_prd_qt_apr_matmed,
             prd.cad_apm_id_matmed,
             prd.cad_prd_qt_maxima,
             prd.cad_prd_qt_minima,
             prd.cad_prd_vl_custo,
             prd.cad_prd_vl_customedio,
             prd.cad_prd_vl_venda,
             prd.cad_prd_pc_acrescimo,
             prd.cad_prd_fl_fracionado,
             prd.cad_prd_nm_fantasia,
             prd.cad_umc_cd_medida_consumo,
             prd.cad_prd_pc_hac,
             prd.cad_prd_vl_produto,
             prd.cad_prd_cd_nat_despesa_tiss,
             prd.cad_prd_fl_permite_retorno,
             prd.tis_tac_cd_tipo_acomodacao,
             prd.cad_prd_fl_cobra_hextra,
             prd.cad_prd_tp_sexo_permitido,
             prd.cad_prd_qt_honorario,
             prd.cad_prd_qt_custo_oper,
             prd.cad_prd_qt_m2_filme,
             prd.cad_prd_qt_incidencia,
             prd.cad_dt_inicio_vigencia,
             prd.cad_prd_tp_porte,
             prd.cad_prd_pc_doppler,
             prd.cad_prd_qt_auxiliar,
             prd.cad_prd_qt_indice_hosp,
             prd.cad_tih_tp_indice_hosp,
             prd.cad_tap_tp_atributo,
             prd.cad_prd_fl_contrastado,
             prd.cad_prd_id_produtotabela,
             prd.cad_prd_fl_utilizaagend_ok,
             prd.tis_med_cd_tabelamedica,
             prd.cad_prd_tp_produto,
             prd.cad_prd_ds_resumida,
             prd.aux_gpc_cd_grupoproc,
             prd.aux_epp_cd_especproc,
             prd.cad_prd_nm_mnemonico,
             prd.cad_prd_fl_status,
             prd.cad_prd_dt_ultima_atualizacao,
             prd.seg_usu_id_usuario,
             prd.cad_prd_ds_descricao,
             prd.cad_prd_cd_gprexa,
             prd.cad_prd_cd_codigo,
             prd.cad_prd_id,
             prd.cad_prd_fl_cirurgia,
             prd.cad_prd_fl_lanca_diaria,
             prd.cad_prd_pc_porte_cbhpm,
             prd.TIS_GPP_CD_GRAU_PART_PROF
        from tb_ass_ctu_cnv_tab_utiliza ctu,
             tb_cad_prd_produto prd
       where ctu.tis_med_cd_tabelamedica = prd.tis_med_cd_tabelamedica
             and ctu.cad_tap_tp_atributo = prd.cad_tap_tp_atributo
             and ctu.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
             and prd.cad_prd_tp_porte = pCAD_PRD_TP_PORTE
             and ctu.cad_tap_tp_atributo = 'TAX'
             and prd.cad_prd_fl_status = 'A'
             and fnc_validar_vigencia(ctu.ass_ctu_dt_inicio_vigencia, ctu.ass_ctu_dt_fim_vigencia) = 1;
      io_cursor := v_cursor;
end PRC_ASS_CTU_CNV_PORTESALA;
