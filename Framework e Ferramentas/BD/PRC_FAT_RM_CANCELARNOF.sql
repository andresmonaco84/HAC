CREATE OR REPLACE PROCEDURE SGS."PRC_FAT_RM_CANCELARNOF" (pATD_ATE_ID in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%type,
 pFAT_CCP_ID in TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ID%type) is
v_fat_nof_id number;
begin
  /* Excluir movimentos com NOF */
  /* Marcus Relva 01/06/2012 */
  begin
    select distinct ccp.fat_nof_id
                    into v_fat_nof_id
                    from tb_atd_ate_atendimento     ate,
                         tb_fat_ccp_conta_cons_parc ccp,
                         tb_fat_nof_nota_fiscal     nof
                   where ((ate.atd_ate_fl_fat_status = 'F' and ate.Atd_Ate_Tp_Paciente in ('A','U'))
                          or (ate.atd_ate_tp_paciente in ('I','E')))
                     and ccp.atd_ate_id = ate.atd_ate_id
                     and ccp.fat_nof_id = nof.fat_nof_id
                     and ate.atd_ate_id = pATD_ATE_ID
                     and ccp.fat_ccp_id = pFAT_CCP_ID
										 and ccp.cad_cnv_id_convenio = 282;
  exception when others then
      raise_application_error(-20000,'ERRO AO OBTER NOTA FISCAL');
  end;
  update tb_fat_ccp_conta_cons_parc ccp
       set ccp.fat_nof_id = null
     where ccp.atd_ate_id = pATD_ATE_ID
       and ccp.fat_ccp_id = pFAT_CCP_ID
       and ccp.fat_nof_id = v_fat_nof_id;
    update tb_fat_afr_atend_fatur_res afr
       set afr.fat_nof_id = null
     where afr.atd_ate_id = pATD_ATE_ID
       and afr.fat_ccp_id = pFAT_CCP_ID
       and afr.fat_nof_id = v_fat_nof_id;
    update tb_fat_nof_nota_fiscal nof
    set nof.fat_nof_fl_status = 'C', nof.fat_nof_dt_cancelamento = sysdate     
    where nof.fat_nof_id = v_fat_nof_id;
end PRC_FAT_RM_CANCELARNOF;
 