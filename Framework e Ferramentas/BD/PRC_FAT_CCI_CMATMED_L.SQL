CREATE OR REPLACE PROCEDURE PRC_FAT_CCI_CMATMED_L
(    pFAT_MCC_ID IN TB_FAT_CCI_CONTA_CONSU_ITEM.FAT_MCC_ID%TYPE,
     pCAD_PAC_ID_PACIENTE IN TB_CAD_PAC_PACIENTE.CAD_PAC_ID_PACIENTE%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/*********************************************************************************
*    Procedure: PRC_FAT_CCI_CMATMED_L
* 
*    Marcus Relva - 11/01/2011
**********************************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
select -- Carrega os campos necessarios da produto
       CASE WHEN cci.fat_cci_fl_fracionado = 'S' THEN
          prd.cad_prd_ds_descricao || ' - ' || prd.cad_prd_qt_apr_matmed
       WHEN cci.fat_cci_fl_fracionado = 'N' THEN
          prd.cad_prd_ds_descricao
       END cad_prd_ds_descricao,
       prd.aux_epp_cd_especproc,
       prd.tis_med_cd_tabelamedica,
       prd.cad_prd_cd_codigo,
       prd.cad_umc_cd_medida_consumo,
       prd.cad_prd_qt_apr_matmed,
       prd.cad_prd_qt_minima,
       prd.cad_prd_qt_maxima,
       tap.cad_tap_ds_atributo,
       -- Carrega todos os campos da item
       fnc_juntar_data_hora(cci.fat_cci_dt_inicio_consumo, cci.fat_cci_hr_inicio_consumo) fat_cci_dt_inicio_consumo,
       cci.fat_cci_fl_fracionado,
       cci.fat_cci_qt_consumo,
       cci.fat_cci_vl_matmed_fabrica,
       cci.fat_cci_vl_calculado,
       cci.fat_cci_vl_faturado,
       cci.fat_cci_id,
       cci.cad_prd_id,
       cci.cad_tap_tp_atributo,
       cci.fat_mcc_id,
       cci.fat_ccp_id,
       cci.fat_coc_id,
       cci.cad_tih_tp_indice_hosp,
       cci.fat_cci_qt_indice,
       cci.fat_cci_vl_indice,
       cci.fat_cci_vl_produto,
       cci.fat_cci_vl_unitario,
       cci.fat_cci_hr_inicio_consumo,
       cci.fat_cci_dt_fim_consumo,
       cci.fat_cci_vl_customedio,
       cci.fat_cci_fl_bilateral,
       cci.fat_cci_fl_simultanea,
       cci.tis_ttp_cd_tptecnica,
       cci.tis_tva_cd_viaacesso,
       cci.fat_cci_pc_grau_part_prof,
       cci.tis_gpp_cd_grau_part_prof,
       cci.cad_pro_id_profissional,
       cci.fat_cci_tp_destino_item,
--       cci.fat_cci_fl_faturado,
       cci.fat_cci_pc_desconto,
       cci.fat_cci_pc_acrescimo,
       cci.fat_cci_hr_fim_consumo,
       cci.fat_cci_vl_unitario_aud,
       cci.fat_cci_vl_unitario_ant,
       cci.fat_cci_qt_cons_ant,
       cci.fat_cci_qt_cons_aud,
       cci.fat_cci_fl_kitpra,
       cci.cad_cac_id_classcontabil,
       cci.cad_cec_id_ccusto,
       cci.fat_cci_vl_pre_calculado,
       cci.fat_cci_pc_tabela_desconto,
       cci.cad_prd_id_cobrado,
       cci.fat_cci_vl_desconto,
       cci.fat_cci_vl_acrescimo,
       cci.fat_cci_fl_pacote,
       cci.fat_cci_id_principal,
       cci.fat_cci_pc_acomodacao_hm,
       cci.fat_cci_fl_equipe_diferente,
       cci.ats_apl_id,
       cci.fat_cci_cd_clinica_prof,
       cci.fat_cci_tp_credencia_prof,
       cci.cad_pac_id_paciente,
       cci.cad_maa_id,
       cci.ass_usc_id,
       cci.cad_umc_cd_medida_consumo,
       cci.atd_ate_id,
       cci.cad_nfm_id,
       cci.cad_apm_id_matmed,
       cci.cad_mpf_id,
       cci.fat_cci_cd_senha,
       cci.fat_cci_cd_guia,
       cci.fat_cci_pc_horario,
       cci.fat_cci_pc_tabela_acrescimo,
       cci.fat_cci_vl_m2filme,
       cci.fat_cci_qt_m2filme,
       cci.fat_cci_dt_ultima_atualizacao,
       cci.seg_usu_id_usuario,
       cci.fat_cci_vl_porteanestesico,
       cci.fat_cci_tp_porteanestesico,
       cci.fat_cci_fl_status,
       cci.fat_cci_qt_fracionada,
       cci.tis_cpr_cd_conselhoprof,
       cci.fat_cci_pc_doppler,
       cci.cad_pso_sg_uf_conselho,
       cci.cad_pso_cd_conselho,
       cci.fat_fl_pendente_autoriza,
       cci.fat_fl_proced_principal,
       cci.fat_cci_fl_utilizavideo,
       cci.fat_cci_mes_fechamento,
       cci.fat_cci_ano_fechamento,
       CCI.SEG_USU_ID_USUARIO_CRIACAO,
       CCI.FAT_CCI_DT_CRIACAO,
       CCI.FAT_CCI_FL_IMPORTADO_REPASSE,
       CCI.CAD_UNI_ID_UNIDADE,
       CCI.CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CCI.ATD_ATE_TP_PACIENTE,
       CCI.CAD_CNV_ID_CONVENIO,
       cci.CAD_CLC_ID,
       cci.CAD_CPR_TP_CREDENCIA_PROF,
			 cci.fat_cci_pc_repasse,
       cci.FAT_CCI_NR_AUT_FUNC_EMP_NF,
       cci.tis_cbo_cd_cbos,
       cci.FAT_CCI_PC_MED_RESTRITO
  from tb_fat_cci_conta_consu_item cci,
       tb_cad_tap_tp_atrib_produto tap,
       tb_cad_prd_produto prd
 where cci.cad_tap_tp_atributo = tap.cad_tap_tp_atributo
       and           cci.cad_prd_id = prd.cad_prd_id
       and           cci.fat_mcc_id = pFAT_MCC_ID
       and           cci.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE
       and           cci.fat_cci_fl_status = 'A'
       and           cci.cad_tap_tp_atributo in ('MAT','MED')
       and           cci.fat_ccp_id is null
order by tap.cad_tap_ds_atributo,
      prd.cad_prd_ds_descricao;    
io_cursor := v_cursor;
end PRC_FAT_CCI_CMATMED_L;
 
