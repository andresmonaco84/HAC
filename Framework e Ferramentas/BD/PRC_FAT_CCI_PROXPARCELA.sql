CREATE OR REPLACE PROCEDURE "PRC_FAT_CCI_PROXPARCELA"
(
    pATD_ATE_ID IN TB_FAT_CCI_CONTA_CONSU_ITEM.ATD_ATE_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/*******************************************************************
* Exibir parcelas na tela de consumo (Marcus Relva 05/10/2010)
* Exibir parcelas quando nao existir paciente na TB_ASS_PAT (Marcus Relva 30/03/2012)
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
   OPEN v_cursor FOR
select cnv.cad_cnv_cd_hac_prestador,
       CNV.CAD_CNV_NM_FANTASIA,
       ATE.ATD_ATE_ID,
       ccp.fat_ccp_id,
       ccp.fat_ccp_fl_faturada,
       ccp.fat_ccp_dt_parcela,
       ccp.fat_ccp_dt_parcela_ini,
       ina.atd_ina_dt_alta_adm,
       cnv.cad_cnv_qt_dia_conta_parcial,
       ate.atd_ate_tp_paciente,
       ate.atd_ate_dt_atendimento,
       nof.fat_nof_nr_notafiscal,
       nof.fat_nof_tp_seriefiscal,
       pac.cad_pac_id_paciente,
       pla.cad_pla_cd_plano_hac,
       PLA.CAD_PLA_NM_NOME_PLANO,
       pat.ass_pat_dt_saida,
       decode(ccp.fat_ccp_mes_fat || '/' || ccp.fat_ccp_ano_fat, '/', null, ccp.fat_ccp_mes_fat || '/' || ccp.fat_ccp_ano_fat) as mesanofat,
       cnv.cad_cnv_cd_hac_prestador || '/' || pla.cad_pla_cd_plano_hac as cnvpla,
       decode(to_char(ccp.fat_ccp_dt_parcela_ini,'dd/MM/yy') ||' a ', ' a ', '',to_char(ccp.fat_ccp_dt_parcela_ini,'dd/MM/yy') ||' a ' ) || to_char(ccp.fat_ccp_dt_parcela,'dd/MM/yy') as periodo,
       decode(ccp.fat_ccp_fl_status_audit, 'E', 'Em Auditoria', 'A', 'Auditada', '') as statusauditoria
  from tb_atd_ate_atendimento          ate
  join tb_ass_pat_pacieatend           pat  on pat.atd_ate_id           = ate.atd_ate_id
  left join tb_atd_ina_int_alta        ina  on ina.atd_ate_id           = ate.atd_ate_id
  join tb_cad_pac_paciente             pac  on pac.cad_pac_id_paciente  = pat.cad_pac_id_paciente
  join tb_cad_cnv_convenio             cnv  on cnv.cad_cnv_id_convenio  = pac.cad_cnv_id_convenio
  join tb_cad_pla_plano                pla  on pla.cad_pla_id_plano     = pac.cad_pla_id_plano
  left join tb_fat_ccp_conta_cons_parc ccp  on ccp.atd_ate_id           = pat.atd_ate_id
                                            and ccp.cad_pac_id_paciente = pat.cad_pac_id_paciente
  left join tb_fat_nof_nota_fiscal     nof  on nof.fat_nof_id           = ccp.fat_nof_id
 where  ate.atd_ate_id =  pATD_ATE_ID
   and  ate.atd_ate_fl_status = 'A'
 union
 select cnv.cad_cnv_cd_hac_prestador,
       CNV.CAD_CNV_NM_FANTASIA,
       ATE.ATD_ATE_ID,
       ccp.fat_ccp_id,
       ccp.fat_ccp_fl_faturada,
       ccp.fat_ccp_dt_parcela,
       ccp.fat_ccp_dt_parcela_ini,
       ina.atd_ina_dt_alta_adm,
       cnv.cad_cnv_qt_dia_conta_parcial,
       ate.atd_ate_tp_paciente,
       ate.atd_ate_dt_atendimento,
       nof.fat_nof_nr_notafiscal,
       nof.fat_nof_tp_seriefiscal,
       pac.cad_pac_id_paciente,
       pla.cad_pla_cd_plano_hac,
       PLA.CAD_PLA_NM_NOME_PLANO,
       null as ass_pat_dt_saida,
       decode(ccp.fat_ccp_mes_fat || '/' || ccp.fat_ccp_ano_fat, '/', null, ccp.fat_ccp_mes_fat || '/' || ccp.fat_ccp_ano_fat) as mesanofat,
       cnv.cad_cnv_cd_hac_prestador || '/' || pla.cad_pla_cd_plano_hac as cnvpla,
       decode(to_char(ccp.fat_ccp_dt_parcela_ini,'dd/MM/yy') ||' a ', ' a ', '',to_char(ccp.fat_ccp_dt_parcela_ini,'dd/MM/yy') ||' a ' ) || to_char(ccp.fat_ccp_dt_parcela,'dd/MM/yy') as periodo,
       decode(ccp.fat_ccp_fl_status_audit, 'E', 'Em Auditoria', 'A', 'Auditada', '') as statusauditoria
  from tb_atd_ate_atendimento          ate
  left join tb_atd_ina_int_alta        ina  on ina.atd_ate_id           = ate.atd_ate_id
  join tb_fat_ccp_conta_cons_parc      ccp  on ccp.atd_ate_id           = ate.atd_ate_id
  join tb_cad_pac_paciente             pac  on pac.cad_pac_id_paciente  = ccp.cad_pac_id_paciente
  join tb_cad_cnv_convenio             cnv  on cnv.cad_cnv_id_convenio  = pac.cad_cnv_id_convenio
  join tb_cad_pla_plano                pla  on pla.cad_pla_id_plano     = pac.cad_pla_id_plano  
  left join tb_fat_nof_nota_fiscal     nof  on nof.fat_nof_id           = ccp.fat_nof_id
 where  ate.atd_ate_id =  pATD_ATE_ID
   and  ate.atd_ate_fl_status = 'A'
 and    (ate.atd_ate_id, pac.cad_pac_id_paciente) not in
        (select pat.atd_ate_id, pat.cad_pac_id_paciente 
         from tb_ass_pat_pacieatend pat
         where pat.atd_ate_id = pATD_ATE_ID)
   order by 1, 2;
io_cursor := v_cursor;
end PRC_FAT_CCI_PROXPARCELA;
 