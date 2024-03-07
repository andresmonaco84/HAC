CREATE OR REPLACE PROCEDURE SGS."PRC_FAT_COF_CCI_FECHAMENTO" (
    pSPLIT_TIPOPACIENTE IN VARCHAR2,
    pSPLIT_CONVENIO     IN VARCHAR2,
    pSPLIT_UNIDADE      IN VARCHAR2,
    pFAT_CCI_ANO_FECHAMENTO IN NUMBER,
    pFAT_CCI_MES_FECHAMENTO IN NUMBER   
)
IS
/* Marcus Relva - Fechamento - 08/04/2011 */
mes       number;
ano       number;
BEGIN
/* Calcula mes seguinte */  
select to_char(add_months(to_date('01/' || pFAT_CCI_MES_FECHAMENTO || '/' || pFAT_CCI_ANO_FECHAMENTO,'dd/MM/yyyy'),1),'MM') mes,
       to_char(add_months(to_date('01/' || pFAT_CCI_MES_FECHAMENTO || '/' || pFAT_CCI_ANO_FECHAMENTO,'dd/MM/yyyy'),1),'yyyy') ano
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
and   ccp.fat_ccp_mes_fat = pFAT_CCI_MES_FECHAMENTO
and   ccp.fat_ccp_ano_fat = pFAT_CCI_ANO_FECHAMENTO
and   pac.cad_cnv_id_convenio in (select column_value from table(fnc_split(pSPLIT_CONVENIO))) 
and   ate.cad_uni_id_unidade  in (select column_value from table(fnc_split(pSPLIT_UNIDADE)))
and   ate.atd_ate_tp_paciente in (select column_value from table(fnc_split(pSPLIT_TIPOPACIENTE))))
LOOP  
    prc_fat_tiss_atualiza_mesano(ITENS.ATD_ATE_ID, ITENS.FAT_CCP_ID, mes, ano, ITENS.CAD_PAC_ID_PACIENTE, 1,null,null);
END LOOP;
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
      cci.fat_coc_id              = ccp.fat_coc_id(+)
and   cci.fat_ccp_id              = ccp.fat_ccp_id(+)  
and   cci.atd_ate_id              = ccp.atd_ate_id(+)
and   cci.atd_ate_id              = ate.atd_ate_id
and   cci.cad_pac_id_paciente     = pac.cad_pac_id_paciente
and   cci.cad_pac_id_paciente     = ccp.cad_pac_id_paciente(+)
and   cci.fat_cci_fl_status       = 'A'
and   cci.fat_cci_tp_destino_item not in ('H','T')
and   ccp.fat_nof_id is null
and   cci.fat_cci_mes_fechamento = pFAT_CCI_MES_FECHAMENTO
and   cci.fat_cci_ano_fechamento = pFAT_CCI_ANO_FECHAMENTO
and   pac.cad_cnv_id_convenio in (select column_value from table(fnc_split(pSPLIT_CONVENIO))) 
and   ate.cad_uni_id_unidade  in (select column_value from table(fnc_split(pSPLIT_UNIDADE)))
and   ate.atd_ate_tp_paciente in (select column_value from table(fnc_split(pSPLIT_TIPOPACIENTE)))
);
/* Atualizar Parcelas */
update tb_fat_ccp_conta_cons_parc ccp
set    ccp.fat_ccp_ano_fat = ano, ccp.fat_ccp_mes_fat = mes
where (ccp.cad_pac_id_paciente, ccp.atd_ate_id, ccp.fat_ccp_id, ccp.fat_ccp_ano_fat, ccp.fat_ccp_mes_fat) in 
(
select ccp.cad_pac_id_paciente, ccp.atd_ate_id, ccp.fat_ccp_id, ccp.fat_ccp_ano_fat, ccp.fat_ccp_mes_fat
         from tb_fat_ccp_conta_cons_parc  ccp,
              tb_cad_pac_paciente         pac,
              tb_atd_ate_atendimento      ate
where ate.atd_ate_id              = ccp.atd_ate_id
and   ccp.cad_pac_id_paciente     = pac.cad_pac_id_paciente
and   ccp.fat_nof_id is null
and   ccp.fat_ccp_mes_fat = pFAT_CCI_MES_FECHAMENTO
and   ccp.fat_ccp_ano_fat = pFAT_CCI_ANO_FECHAMENTO
and   pac.cad_cnv_id_convenio in (select column_value from table(fnc_split(pSPLIT_CONVENIO))) 
and   ate.cad_uni_id_unidade  in (select column_value from table(fnc_split(pSPLIT_UNIDADE)))
and   ate.atd_ate_tp_paciente in (select column_value from table(fnc_split(pSPLIT_TIPOPACIENTE)))
);
/* Atualizar Resumo */
update tb_fat_afr_atend_fatur_res afr
set afr.fat_afr_nr_anofat = ano, afr.fat_afr_nr_mesfat = mes
where (afr.atd_ate_id, afr.cad_pac_id_paciente, afr.fat_ccp_id, afr.fat_afr_nr_mesfat, afr.fat_afr_nr_anofat)
in (select afr.atd_ate_id, afr.cad_pac_id_paciente, afr.fat_ccp_id, afr.fat_afr_nr_mesfat, afr.fat_afr_nr_anofat
       from tb_fat_afr_atend_fatur_res afr,
            tb_atd_ate_atendimento ate,
            tb_cad_pac_paciente pac              
where afr.atd_ate_id          = ate.atd_ate_id
and   afr.cad_pac_id_paciente = pac.cad_pac_id_paciente
and   afr.fat_nof_id          is null
and   pac.cad_cnv_id_convenio in (select column_value from table(fnc_split(pSPLIT_CONVENIO))) 
and   ate.cad_uni_id_unidade  in (select column_value from table(fnc_split(pSPLIT_UNIDADE)))
and   ate.atd_ate_tp_paciente in (select column_value from table(fnc_split(pSPLIT_TIPOPACIENTE)))
and   afr.fat_afr_nr_anofat   = pFAT_CCI_ANO_FECHAMENTO
and   afr.fat_afr_nr_mesfat   = pFAT_CCI_MES_FECHAMENTO);
END PRC_FAT_COF_CCI_FECHAMENTO;
