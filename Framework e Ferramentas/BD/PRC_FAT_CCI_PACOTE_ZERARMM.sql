create or replace procedure PRC_FAT_CCI_PACOTE_ZERARMM
  ( 
     pATD_ATE_ID            IN TB_FAT_CCI_CONTA_CONSU_ITEM.ATD_ATE_ID%TYPE,
     pCAD_SET_ID            IN TB_FAT_MCC_MOV_COM_CONSUMO.CAD_SET_ID%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  v_cursor               PKG_CURSOR.t_cursor;
  /*
  Retorna as Datas em que existem pacotes para um atendimento/setor;
  Essas datas serão usadas para zerar os itens de MAT/MED dentro de um setor quando existir pacote.
  Marcus Relva - 23/12/2010
  */
  begin   
  
  
   OPEN V_CURSOR FOR
    select distinct cci.fat_cci_dt_inicio_consumo
    from tb_fat_cci_conta_consu_item cci,
    tb_fat_mcc_mov_com_consumo mcc
    where cci.fat_mcc_id = mcc.fat_mcc_id
    and cci.cad_tap_tp_atributo = 'PAC'
    and mcc.cad_set_id = pCAD_SET_ID
    and cci.atd_ate_id = pATD_ATE_ID
    and cci.atd_ate_id = mcc.atd_ate_id
    and cci.fat_cci_fl_status = 'A';
    
    io_cursor := v_cursor;
    
end PRC_FAT_CCI_PACOTE_ZERARMM;
