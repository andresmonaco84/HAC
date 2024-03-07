CREATE OR REPLACE PROCEDURE SGS."PRC_FAT_COF_CCI_DESFAZER" (
    pATD_ATE_TP_PACIENTE        IN VARCHAR2,
    pCAD_CNV_ID_CONVENIO        IN NUMBER,
    pCAD_UNI_ID_UNIDADE         IN NUMBER,
    pFAT_COF_NR_ANO_FATURAMENTO IN NUMBER,
    pFAT_COF_NR_MES_FATURAMENTO IN NUMBER
)
IS
/* Marcus Relva - Desfazer Fechamento - 14/04/2011 */
mes       number;
ano       number;
begin  
/* Remover da COF */
delete tb_fat_cof_controle_fecha cof
where cof.atd_ate_tp_paciente = pATD_ATE_TP_PACIENTE
and   cof.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
and   cof.cad_uni_id_unidade  = pCAD_UNI_ID_UNIDADE
and   cof.fat_cof_nr_ano_faturamento = pFAT_COF_NR_ANO_FATURAMENTO
and   cof.fat_cof_nr_mes_faturamento = pFAT_COF_NR_MES_FATURAMENTO;
/* Calcula mes seguinte */  
select to_char(add_months(to_date('01/' || pFAT_COF_NR_MES_FATURAMENTO || '/' || pFAT_COF_NR_ANO_FATURAMENTO,'dd/MM/yyyy'),1),'MM') mes,
       to_char(add_months(to_date('01/' || pFAT_COF_NR_MES_FATURAMENTO || '/' || pFAT_COF_NR_ANO_FATURAMENTO,'dd/MM/yyyy'),1),'yyyy') ano
       into mes, ano
from dual;
/* Atualizar Tabelas TISS */
FOR ITENS IN (select ccp.cad_pac_id_paciente, ccp.atd_ate_id, ccp.fat_ccp_id, ccp.fat_ccp_ano_fat, ccp.fat_ccp_mes_fat
         from tb_fat_ccp_conta_cons_parc  ccp,
              tb_cad_pac_paciente         pac,
              tb_atd_ate_atendimento      ate
where ate.atd_ate_id              = ccp.atd_ate_id
and   ccp.cad_pac_id_paciente     = pac.cad_pac_id_paciente
and   ccp.fat_nof_id is null
and   ccp.fat_ccp_mes_fat = mes
and   ccp.fat_ccp_ano_fat = ano
and   pac.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO  
and   ate.cad_uni_id_unidade  = pCAD_UNI_ID_UNIDADE
and   ate.atd_ate_tp_paciente = pATD_ATE_TP_PACIENTE)
LOOP
  prc_fat_tiss_atualiza_mesano(ITENS.ATD_ATE_ID, ITENS.FAT_CCP_ID, mes, ano, ITENS.CAD_PAC_ID_PACIENTE, 1,null,null);  
END LOOP;
/* Voltar Data Fechamento do Consumo*/
update tb_fat_cci_conta_consu_item cci
set cci.fat_cci_ano_fechamento = pFAT_COF_NR_ANO_FATURAMENTO,
    cci.fat_cci_mes_fechamento = pFAT_COF_NR_MES_FATURAMENTO
where cci.fat_cci_id in
(
select cci.fat_cci_id
         from tb_fat_cci_conta_consu_item cci,
              tb_fat_ccp_conta_cons_parc  ccp,
              tb_cad_pac_paciente         pac,
              tb_atd_ate_atendimento      ate
where 
      cci.fat_coc_id              = ccp.fat_coc_id(+)
and   cci.fat_ccp_id              = ccp.fat_ccp_id(+)  
and   cci.atd_ate_id              = ccp.atd_ate_id(+)
and   cci.atd_ate_id              = ate.atd_ate_id
and   cci.cad_pac_id_paciente     = pac.cad_pac_id_paciente
and   cci.cad_pac_id_paciente     = ccp.cad_pac_id_paciente(+)
and   cci.fat_cci_fl_status       = 'A'
and   cci.fat_cci_tp_destino_item not in ('H','T')
and   ccp.fat_nof_id is null
and   cci.fat_cci_mes_fechamento = mes
and   cci.fat_cci_ano_fechamento = ano
and   pac.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO  
and   ate.cad_uni_id_unidade  = pCAD_UNI_ID_UNIDADE
and   ate.atd_ate_tp_paciente = pATD_ATE_TP_PACIENTE
);
/* Voltar data de Fechamento Parcelas */
update tb_fat_ccp_conta_cons_parc ccp
set    ccp.fat_ccp_ano_fat = pFAT_COF_NR_ANO_FATURAMENTO, ccp.fat_ccp_mes_fat = pFAT_COF_NR_MES_FATURAMENTO
where (ccp.cad_pac_id_paciente, ccp.atd_ate_id, ccp.fat_ccp_id, ccp.fat_ccp_ano_fat, ccp.fat_ccp_mes_fat) in 
(
select ccp.cad_pac_id_paciente, ccp.atd_ate_id, ccp.fat_ccp_id, ccp.fat_ccp_ano_fat, ccp.fat_ccp_mes_fat
         from tb_fat_ccp_conta_cons_parc  ccp,
              tb_cad_pac_paciente         pac,
              tb_atd_ate_atendimento      ate
where ate.atd_ate_id              = ccp.atd_ate_id
and   ccp.cad_pac_id_paciente     = pac.cad_pac_id_paciente
and   ccp.fat_nof_id is null
and   ccp.fat_ccp_mes_fat = mes
and   ccp.fat_ccp_ano_fat = ano
and   pac.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO  
and   ate.cad_uni_id_unidade  = pCAD_UNI_ID_UNIDADE
and   ate.atd_ate_tp_paciente = pATD_ATE_TP_PACIENTE
);
/* Atualizar Resumo */
update tb_fat_afr_atend_fatur_res afr
set afr.fat_afr_nr_anofat = pFAT_COF_NR_ANO_FATURAMENTO, afr.fat_afr_nr_mesfat = pFAT_COF_NR_MES_FATURAMENTO
where (afr.atd_ate_id, afr.cad_pac_id_paciente, afr.fat_ccp_id, afr.fat_afr_nr_mesfat, afr.fat_afr_nr_anofat)
in (select afr.atd_ate_id, afr.cad_pac_id_paciente, afr.fat_ccp_id, afr.fat_afr_nr_mesfat, afr.fat_afr_nr_anofat
       from tb_fat_afr_atend_fatur_res afr,
            tb_atd_ate_atendimento ate,
            tb_cad_pac_paciente pac              
where afr.atd_ate_id          = ate.atd_ate_id
and   afr.cad_pac_id_paciente = pac.cad_pac_id_paciente
and   afr.fat_nof_id          is null
and   pac.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
and   ate.cad_uni_id_unidade  = pCAD_UNI_ID_UNIDADE
and   ate.atd_ate_tp_paciente = pATD_ATE_TP_PACIENTE
and   afr.fat_afr_nr_anofat   = ano
and   afr.fat_afr_nr_mesfat   = mes);
END PRC_FAT_COF_CCI_DESFAZER;
