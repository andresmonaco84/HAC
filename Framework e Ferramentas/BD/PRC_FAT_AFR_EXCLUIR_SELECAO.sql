create or replace procedure PRC_FAT_AFR_EXCLUIR_SELECAO
(
     pATD_ATE_ID             TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE,
     pFAT_COC_ID             TB_FAT_CCP_CONTA_CONS_PARC.FAT_COC_ID%TYPE,
     pFAT_CCP_ID             TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ID%TYPE,
     pCAD_PAC_ID_PACIENTE    TB_FAT_CCP_CONTA_CONS_PARC.CAD_PAC_ID_PACIENTE%TYPE
)
is

/* Marcus Relva - 16/05/2011 */

begin
  
delete tb_fat_afr_atend_fatur_res afr
where afr.atd_ate_id = pATD_ATE_ID
and   afr.fat_ccp_id = pFAT_CCP_ID
and   afr.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE
and   afr.fat_coc_id = pFAT_COC_ID
and   (afr.fat_nof_id is null or afr.fat_nof_id = 0);

end PRC_FAT_AFR_EXCLUIR_SELECAO;