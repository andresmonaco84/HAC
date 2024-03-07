CREATE OR REPLACE PROCEDURE "PRC_OBTER_PACIENTE_AUDITORIA"
  (
     pATD_ATE_ID            IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE,
     pFAT_CCP_ID            IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ID%TYPE,
     pCAD_CNV_ID_CONVENIO   IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    select pac.*,       
           cnv.*,
           pla.*
  from tb_fat_ccp_conta_cons_parc ccp,
       tb_cad_pac_paciente pac,
       tb_cad_cnv_convenio cnv,
       tb_cad_pla_plano pla
 where ccp.cad_pac_id_paciente     = pac.cad_pac_id_paciente 
       and pac.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
       and pac.cad_pla_id_plano    = pla.cad_pla_id_plano
       and ccp.fat_ccp_fl_status   = 'A'
       AND ccp.fat_ccp_id          = pFAT_CCP_ID
       and ccp.atd_ate_id          = pATD_ATE_ID
       and cnv.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO;
    io_cursor := v_cursor;
  end PRC_OBTER_PACIENTE_AUDITORIA;
 