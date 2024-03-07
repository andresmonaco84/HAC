CREATE OR REPLACE PROCEDURE "PRC_FAT_CCI_AUDITORIA"
(
     pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%type,     
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,     
     pFAT_CCP_ID IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ID%TYPE DEFAULT NULL,
     pFAT_CCI_FL_FATURADO  IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_FL_FATURADA%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/*********************************************************************************
*    Procedure: PRC_FAT_CCI_AUDITORIA
* 
*    Marcus Relva - 27/12/2010
**********************************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
select max(cci.cad_maa_id) cad_maa_id,
       cci.cad_tap_tp_atributo,
       cci.fat_cci_fl_fracionado,
       sum(cci.fat_cci_qt_consumo) fat_cci_qt_consumo,
       round(sum(cci.fat_cci_vl_faturado),2) fat_cci_vl_faturado,
       /*
       decode(cci.fat_cci_fl_fracionado,                                                                   
       'S', cci.fat_cci_vl_matmed_fabrica,                                                       
       'N', round((cci.fat_cci_vl_faturado / cci.fat_cci_qt_consumo),2)) fat_cci_vl_unitario,
       */
       round((cci.fat_cci_vl_faturado / cci.fat_cci_qt_consumo),2) fat_cci_vl_unitario,
       decode(str.cad_set_cd_setor,'CECI','CENTRO CIRURGICO',
                                   'ENDO','ENDOSCOPIA',
                                   'HEMD','HEMODINAMICA','ENFERMARIA') DESCRICAO_SETOR,
       prd.cad_prd_id,
       prd.cad_prd_cd_codigo,
       prd.cad_prd_cd_gprexa,
       CASE WHEN cci.fat_cci_fl_fracionado = 'S' THEN
          prd.cad_prd_ds_descricao || ' - ' || prd.cad_prd_qt_apr_matmed
       WHEN cci.fat_cci_fl_fracionado = 'N' THEN
          prd.cad_prd_ds_descricao
       END cad_prd_ds_descricao,
       prd.seg_usu_id_usuario,
       prd.cad_prd_dt_ultima_atualizacao,
       prd.cad_prd_fl_status,
       prd.cad_prd_nm_mnemonico,
       prd.aux_epp_cd_especproc,
       prd.aux_gpc_cd_grupoproc,
       prd.cad_prd_ds_resumida,
       prd.cad_prd_tp_produto,
       prd.tis_med_cd_tabelamedica,
       prd.cad_prd_fl_utilizaagend_ok,
       prd.cad_prd_id_produtotabela,
       prd.cad_prd_fl_contrastado,
       prd.cad_tap_tp_atributo,
       prd.cad_tih_tp_indice_hosp,
       prd.cad_prd_qt_indice_hosp,
       prd.cad_prd_qt_auxiliar,
       prd.cad_prd_pc_doppler,
       prd.cad_prd_tp_porte,
       prd.cad_dt_inicio_vigencia,
       prd.cad_prd_qt_incidencia,
       prd.cad_prd_qt_m2_filme,
       prd.cad_prd_qt_custo_oper,
       prd.cad_prd_qt_honorario,
       prd.cad_prd_tp_sexo_permitido,
       prd.cad_prd_fl_cobra_hextra,
       prd.tis_tac_cd_tipo_acomodacao,
       prd.cad_prd_fl_permite_retorno,
       prd.cad_prd_cd_nat_despesa_tiss,
       prd.cad_prd_vl_produto,
       prd.cad_prd_pc_hac,
       prd.cad_umc_cd_medida_consumo,
       prd.cad_prd_nm_fantasia,
       prd.cad_prd_fl_fracionado,
       prd.cad_prd_pc_acrescimo,
       prd.cad_prd_vl_venda,
--       prd.cad_prd_vl_customedio,
       prd.cad_prd_vl_custo,
       prd.cad_prd_qt_minima,
       prd.cad_prd_qt_maxima,
       prd.cad_apm_id_matmed,
       prd.cad_prd_qt_apr_matmed,
       prd.cad_prd_fl_isento_cobranca,
       prd.cad_prd_fl_estoque_acs,
       prd.cad_prd_pc_desconto,
       prd.cad_prd_fl_kit,
       prd.cad_prd_cd_barra,
       prd.cad_prd_fl_alto_custo,
       prd.cad_prd_vl_unitario,
       prd.cad_cme_classif_med,
       prd.cad_prd_fl_usorestritomed,
       prd.cad_prd_vl_matmed_fabrica,
       prd.cad_prd_fl_matespecial,
       prd.cad_cmm_cd_caracmatmed,
       prd.cad_prd_vl_matmed_vend_fra,
       prd.cad_prd_vl_matmed_fabr_fra,
       prd.cad_prd_id_produto_matmed,
       prd.cad_prd_cd_fabr_matmed,
       prd.cad_prd_nm_fabr_matmed,
       prd.cad_prd_tp_embalag_matmed,
       prd.cad_prd_cd_tabela_matmed,
       prd.cad_prd_cd_tab_apre_matmed,
       prd.cad_prd_nm_tab_apre_matmed,
       prd.cad_prd_cd_codigo_amb92,
       prd.cad_prd_fl_notafiscalmatmed,
       prd.cad_prd_fl_cobrapchmaco,
       prd.cad_prd_fl_mat_consignado,
       prd.cad_prd_tp_porte_cbhpm,
       prd.cad_prd_tp_porte_sala,
       prd.cad_prd_fl_lanca_diaria,
       prd.cad_prd_fl_cirurgia,       
       prd.cad_prd_pc_porte_cbhpm,
       cci.fat_cci_id_principal,
       max(cci.fat_cci_vl_customedio) as cad_prd_vl_customedio,
       prd.tis_gpp_cd_grau_part_prof
  from tb_fat_cci_conta_consu_item cci 
	     join tb_cad_prd_produto prd on cci.cad_prd_id = prd.cad_prd_id
       join tb_fat_mcc_mov_com_consumo mcc on cci.atd_ate_id = mcc.atd_ate_id
			                                     and cci.fat_mcc_id = mcc.fat_mcc_id
			 join tb_cad_set_setor str on mcc.cad_set_id = str.cad_set_id
       join tb_cad_pac_paciente pac on cci.cad_pac_id_paciente = pac.cad_pac_id_paciente
       join tb_fat_ccp_conta_cons_parc ccp on cci.atd_ate_id = ccp.atd_ate_id
                                            	 and cci.cad_pac_id_paciente = ccp.cad_pac_id_paciente
																							 and cci.fat_ccp_id = ccp.fat_ccp_id
 where 
       cci.cad_tap_tp_atributo in ('MAT', 'MED')
			 and cci.cad_nfm_id is null
       and cci.atd_ate_id = pATD_ATE_ID
       and cci.fat_cci_fl_status = 'A'
       and (cci.fat_cci_fl_pacote = 'N' or cci.fat_cci_fl_pacote is null)
       and (pCAD_CNV_ID_CONVENIO is null or pac.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO)
       and (pFAT_CCP_ID is null or cci.fat_ccp_id = pFAT_CCP_ID)
       and (pFAT_CCI_FL_FATURADO is null or ccp.fat_ccp_fl_faturada = pFAT_CCI_FL_FATURADO)
 group by 
       cci.fat_cci_id_principal,			 
       cci.cad_tap_tp_atributo,
       cci.fat_cci_fl_fracionado,
       round((cci.fat_cci_vl_faturado / cci.fat_cci_qt_consumo),2),
       /*
       decode(cci.fat_cci_fl_fracionado, 
       --Fracionado, trazer o valor unitario como valor de fabrica
       'S', cci.fat_cci_vl_matmed_fabrica,
       --Nao fracionado, dividir faturado / qt. consumo
       'N', round((cci.fat_cci_vl_faturado / cci.fat_cci_qt_consumo),2)),       
       */
        decode(str.cad_set_cd_setor,
                       'CECI',
                       'CENTRO CIRURGICO',
                       'ENDO',
                       'ENDOSCOPIA',
                       'HEMD',
                       'HEMODINAMICA',
                       'ENFERMARIA'),
                        prd.cad_prd_id,
       prd.cad_prd_cd_codigo,
       prd.cad_prd_cd_gprexa,
       prd.cad_prd_ds_descricao,
       prd.seg_usu_id_usuario,
       prd.cad_prd_dt_ultima_atualizacao,
       prd.cad_prd_fl_status,
       prd.cad_prd_nm_mnemonico,
       prd.aux_epp_cd_especproc,
       prd.aux_gpc_cd_grupoproc,
       prd.cad_prd_ds_resumida,
       prd.cad_prd_tp_produto,
       prd.tis_med_cd_tabelamedica,
       prd.cad_prd_fl_utilizaagend_ok,
       prd.cad_prd_id_produtotabela,
       prd.cad_prd_fl_contrastado,
       prd.cad_tap_tp_atributo,
       prd.cad_tih_tp_indice_hosp,
       prd.cad_prd_qt_indice_hosp,
       prd.cad_prd_qt_auxiliar,
       prd.cad_prd_pc_doppler,
       prd.cad_prd_tp_porte,
       prd.cad_dt_inicio_vigencia,
       prd.cad_prd_qt_incidencia,
       prd.cad_prd_qt_m2_filme,
       prd.cad_prd_qt_custo_oper,
       prd.cad_prd_qt_honorario,
       prd.cad_prd_tp_sexo_permitido,
       prd.cad_prd_fl_cobra_hextra,
       prd.tis_tac_cd_tipo_acomodacao,
       prd.cad_prd_fl_permite_retorno,
       prd.cad_prd_cd_nat_despesa_tiss,
       prd.cad_prd_vl_produto,
       prd.cad_prd_pc_hac,
       prd.cad_umc_cd_medida_consumo,
       prd.cad_prd_nm_fantasia,
       prd.cad_prd_fl_fracionado,
       prd.cad_prd_pc_acrescimo,
       prd.cad_prd_vl_venda,
    --   prd.cad_prd_vl_customedio,
       prd.cad_prd_vl_custo,
       prd.cad_prd_qt_minima,
       prd.cad_prd_qt_maxima,
       prd.cad_apm_id_matmed,
       prd.cad_prd_qt_apr_matmed,
       prd.cad_prd_fl_isento_cobranca,
       prd.cad_prd_fl_estoque_acs,
       prd.cad_prd_pc_desconto,
       prd.cad_prd_fl_kit,
       prd.cad_prd_cd_barra,
       prd.cad_prd_fl_alto_custo,
       prd.cad_prd_vl_unitario,
       prd.cad_cme_classif_med,
       prd.cad_prd_fl_usorestritomed,
       prd.cad_prd_vl_matmed_fabrica,
       prd.cad_prd_fl_matespecial,
       prd.cad_cmm_cd_caracmatmed,
       prd.cad_prd_vl_matmed_vend_fra,
       prd.cad_prd_vl_matmed_fabr_fra,
       prd.cad_prd_id_produto_matmed,
       prd.cad_prd_cd_fabr_matmed,
       prd.cad_prd_nm_fabr_matmed,
       prd.cad_prd_tp_embalag_matmed,
       prd.cad_prd_cd_tabela_matmed,
       prd.cad_prd_cd_tab_apre_matmed,
       prd.cad_prd_nm_tab_apre_matmed,
       prd.cad_prd_cd_codigo_amb92,
       prd.cad_prd_fl_notafiscalmatmed,
       prd.cad_prd_fl_cobrapchmaco,
       prd.cad_prd_fl_mat_consignado,
       prd.cad_prd_tp_porte_cbhpm,
       prd.cad_prd_tp_porte_sala,
       prd.cad_prd_fl_lanca_diaria,
       prd.cad_prd_fl_cirurgia,       
       prd.cad_prd_pc_porte_cbhpm,
       prd.tis_gpp_cd_grau_part_prof
          order by  DESCRICAO_SETOR, cci.cad_tap_tp_atributo, fat_cci_fl_fracionado,  prd.cad_prd_ds_descricao;
io_cursor := v_cursor;
end PRC_FAT_CCI_AUDITORIA;
 