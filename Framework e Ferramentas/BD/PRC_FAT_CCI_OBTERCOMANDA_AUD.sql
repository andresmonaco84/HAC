CREATE OR REPLACE PROCEDURE PRC_FAT_CCI_OBTERCOMANDA_AUD
(
  pATD_ATE_ID IN TB_FAT_MCC_MOV_COM_CONSUMO.ATD_ATE_ID%TYPE,
  IO_CURSOR   OUT PKG_CURSOR.T_CURSOR) IS
  /********************************************************************
  * Marcus Relva - 30/12/2010  
  *******************************************************************/
  V_CURSOR PKG_CURSOR.T_CURSOR;
  COMANDA_MATMED       CONSTANT NUMBER := 1;     
  COMANDA_MATMED_AMBPS CONSTANT NUMBER := 349;     
BEGIN
  OPEN V_CURSOR FOR
  select mcc.fat_mcc_id,
         mcc.atd_ate_id,
         mcc.fat_mcc_dt_movimentacao,
         mcc.fat_mcc_hr_movimentacao,
         mcc.fat_mcc_vl_tot_mov_comanda,
         mcc.fat_mcc_qt_tot_item_mov_com,
         mcc.fat_mcc_dt_ultima_atualizacao,
         mcc.seg_usu_id_usuario,
         mcc.fat_mcc_fl_status,
         mcc.fat_coc_fl_faturado,
         mcc.atd_gui_cd_codigo,
         mcc.fat_tco_id,
         mcc.cad_set_id,
         				 str.cad_set_ds_setor as DESCRICAO_SETOR       
    from tb_fat_mcc_mov_com_consumo mcc,
         tb_cad_set_setor str
   where str.cad_set_id = mcc.cad_set_id
         and   mcc.atd_ate_id = pATD_ATE_ID
         and   mcc.fat_tco_id in (COMANDA_MATMED,COMANDA_MATMED_AMBPS)
         and   mcc.fat_mcc_fl_status = 'A'         
          order by mcc.fat_mcc_dt_ultima_atualizacao desc;
  IO_CURSOR := V_CURSOR;
END PRC_FAT_CCI_OBTERCOMANDA_AUD;
