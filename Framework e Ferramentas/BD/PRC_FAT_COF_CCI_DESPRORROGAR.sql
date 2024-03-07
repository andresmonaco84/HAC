CREATE OR REPLACE PROCEDURE PRC_FAT_COF_CCI_DESPRORROGAR
(
    pFAT_COF_NR_ANO_FATURAMENTO IN NUMBER,
    pFAT_COF_NR_MES_FATURAMENTO IN NUMBER,
    pATD_ATE_ID             in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE,
    pFAT_CCP_ID             in TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ID%TYPE,
    pCAD_PAC_ID_PACIENTE    in TB_FAT_CCP_CONTA_CONS_PARC.CAD_PAC_ID_PACIENTE%TYPE    
)
IS

/* Marcus Relva - Fechamento - 18/04/2011 */

mes       number;
ano       number;

BEGIN

/* Calcula mes seguinte */  
select to_char(add_months(to_date('01/' || pFAT_COF_NR_MES_FATURAMENTO || '/' || pFAT_COF_NR_ANO_FATURAMENTO,'dd/MM/yyyy'),-1),'MM') mes,
       to_char(add_months(to_date('01/' || pFAT_COF_NR_MES_FATURAMENTO || '/' || pFAT_COF_NR_ANO_FATURAMENTO,'dd/MM/yyyy'),-1),'yyyy') ano
       into mes, ano
from dual;

/* Atualizar Consumo */  
update tb_fat_cci_conta_consu_item cci
set cci.fat_cci_ano_fechamento = ano,
    cci.fat_cci_mes_fechamento = mes
where cci.fat_cci_id in
(
select cci.fat_cci_id
         from tb_fat_cci_conta_consu_item cci,
              tb_fat_ccp_conta_cons_parc  ccp,
              tb_cad_pac_paciente         pac,
              tb_atd_ate_atendimento      ate
where 
      cci.fat_coc_id              = ccp.fat_coc_id
and   cci.fat_ccp_id              = ccp.fat_ccp_id  
and   cci.atd_ate_id              = ccp.atd_ate_id
and   cci.atd_ate_id              = ate.atd_ate_id
and   cci.cad_pac_id_paciente     = pac.cad_pac_id_paciente
and   cci.cad_pac_id_paciente     = ccp.cad_pac_id_paciente
and   cci.fat_cci_fl_status       = 'A'
and   cci.fat_cci_tp_destino_item not in ('H','T')
and   ccp.fat_nof_id is null
and   cci.atd_ate_id = pATD_ATE_ID
and   cci.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE
and   cci.fat_ccp_id = pFAT_CCP_ID
);

/* Atualizar Parcelas */
update tb_fat_ccp_conta_cons_parc ccp
set ccp.fat_ccp_mes_fat = mes, ccp.fat_ccp_ano_fat = ano
where ccp.atd_ate_id = pATD_ATE_ID
and   ccp.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE
and   ccp.fat_ccp_id = pFAT_CCP_ID
and   ccp.fat_nof_id is null;

/* Atualizar Resumo */
update tb_fat_afr_atend_fatur_res afr
set afr.fat_afr_nr_anofat = ano, afr.fat_afr_nr_mesfat = mes
where afr.atd_ate_id = pATD_ATE_ID
and   afr.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE
and   afr.fat_ccp_id = pFAT_CCP_ID
and   afr.fat_nof_id is null;

END PRC_FAT_COF_CCI_DESPRORROGAR;
