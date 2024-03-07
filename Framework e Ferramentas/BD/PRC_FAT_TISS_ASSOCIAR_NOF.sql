CREATE OR REPLACE PROCEDURE PRC_FAT_TISS_ASSOCIAR_NOF(pFAT_NOF_ID number,
                                                     pMARCAR     varchar2) is

  v_idnof number;

begin
  /* Marcus Relva - 11/09/2014 */
  
  if (pMARCAR = 'N') then
    v_idnof := null;
  end if;
	
  for itens in (select ccp.atd_ate_id,
                       ccp.cad_pac_id_paciente,
                       ccp.fat_ccp_id
                  from tb_fat_ccp_conta_cons_parc ccp
                 where ccp.fat_nof_id = pFAT_NOF_ID) loop
  
    update tiss.tss_spsadt_sgs_v3 s
       set s.idt_nof = v_idnof
     where s.nr_atendimento = itens.atd_ate_id
       and s.idt_paciente = itens.cad_pac_id_paciente
       and s.cd_parcela = itens.fat_ccp_id;
  
    update tiss.tss_resumo_int_sgs_v3 i
       set i.idt_nof = v_idnof
     where i.nr_atendimento = itens.atd_ate_id
       and i.idt_paciente = itens.cad_pac_id_paciente
       and i.cd_parcela = itens.fat_ccp_id;
  
  end loop;

end PRC_FAT_TISS_ASSOCIAR_NOF;
/
