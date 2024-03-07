CREATE OR REPLACE PROCEDURE "PRC_FAT_CCI_TELA_CONSUMOW_L"
(
  pATD_ATE_ID                   TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE,
  IO_CURSOR                     OUT PKG_CURSOR.T_CURSOR
)
  IS
  /* Retornar Consumo */
  V_CURSOR PKG_CURSOR.T_CURSOR;
BEGIN
  OPEN V_CURSOR FOR
   select prd.cad_prd_cd_codigo,
       decode(cci.cad_tap_tp_atributo, 'M2', prd.cad_prd_ds_descricao || ' (filme m²)', 
									  'TAX', prd.cad_prd_ds_descricao || ' (taxa)', 
									  prd.cad_prd_ds_descricao) as cad_prd_ds_descricao,
       prd.cad_prd_id,       
       prd.cad_tap_tp_atributo,
       cci.fat_cci_fl_pacote,
       cci.fat_cci_fl_kitpra,
       str.cad_set_ds_setor,
       str.cad_set_id,
       tco.fat_tco_ds_comanda,
       tco.fat_tco_id,
       pro.cad_pro_nr_conselho,
       cci.fat_cci_id,
       cci.fat_cci_qt_consumo,
       cci.fat_cci_fl_fracionado,
       cci.fat_cci_vl_calculado,
       cci.fat_cci_vl_faturado
  from tb_fat_cci_conta_consu_item cci,
       tb_fat_mcc_mov_com_consumo  mcc,
       tb_cad_set_setor            str,
       tb_fat_tco_tipo_comanda     tco,
       tb_cad_prd_produto          prd,
       tb_cad_pro_profissional     pro
 where cci.fat_mcc_id = mcc.fat_mcc_id
   and mcc.cad_set_id = str.cad_set_id
   and mcc.fat_tco_id = tco.fat_tco_id
   and cci.cad_prd_id = prd.cad_prd_id
   and cci.cad_pro_id_profissional = pro.cad_pro_id_profissional(+)
   and cci.fat_cci_fl_status = 'A'
   and mcc.fat_mcc_fl_status = 'A'
	 and cci.cad_cnv_id_convenio = 282
   and cci.atd_ate_id = pATD_ATE_ID   
   and cci.fat_cci_tp_destino_item != 'H'
   order by 1,2;
IO_CURSOR := V_CURSOR;
END prc_fat_cci_tela_consumow_l;
 