CREATE OR REPLACE PROCEDURE "PRC_LOG_CONFERENCIA_FECHAMENTO"
IS
/* Marcus Relva - VALIDAR NF - 06/08/2012 */
v_header         varchar2(1000) := '<font face="calibri">';
v_mensagem       varchar2(32000) := '<table style="border:1px solid #000000; padding 5px; font-family:courier;">';
v_grupo          varchar2(100)  := 'InterfacesMonitoramento@anacosta.com.br';
v_mailhost VARCHAR2(64) := '172.16.1.18';
v_con utl_smtp.connection;
BEGIN
for itensmesano in  (select to_char(add_months(sysdate, -1), 'MM') as mes,
       to_char(add_months(sysdate, -1), 'yyyy') as ano
  from dual
union
select to_char(sysdate, 'MM') as mes, to_char(sysdate, 'yyyy') as ano
  from dual
union
select to_char(add_months(sysdate, 1), 'MM') as mes,
       to_char(add_months(sysdate, 1), 'yyyy') as ano
  from dual
)
loop
v_mensagem := v_mensagem || '<tr><td colspan=2 bgcolor=#E6E6E6><center><b>' || itensmesano.ano || '/' || itensmesano.mes || '</b></center></td></tr>' ;
FOR itens IN (
--cci
select 'CCI' as tabela,  sum(cci.fat_cci_vl_faturado) valor
 from tb_fat_ccp_conta_cons_parc ccp, tb_fat_cci_conta_consu_item cci
where ccp.atd_ate_id = cci.atd_ate_id
  and ccp.cad_pac_id_paciente = cci.cad_pac_id_paciente
  and ccp.fat_ccp_id = cci.fat_ccp_id
  and ccp.fat_coc_id = cci.fat_coc_id
  and cci.fat_cci_fl_status = 'A'
  and cci.fat_cci_tp_destino_item not in ('H','T')
  and cci.cad_tap_tp_atributo <> 'PAC'
  and ccp.fat_ccp_mes_fat = itensmesano.mes
  and ccp.fat_ccp_ano_fat = itensmesano.ano
  and ccp.fat_nof_id is not null
  and ccp.Fat_Nof_Id <> 0
  group by cci.fat_cci_mes_fechamento, cci.fat_cci_ano_fechamento
  union
 --ccp
  select 'CCP' as tabela, sum(ccp.fat_ccp_vl_tot_conta) AS VALOR
  from tb_fat_ccp_conta_cons_parc ccp
  where ccp.fat_ccp_fl_status = 'A'
   and ccp.fat_ccp_fl_faturada = 'S'
   and ccp.fat_ccp_mes_fat = itensmesano.mes
  and ccp.fat_ccp_ano_fat = itensmesano.ano
  and ccp.fat_nof_id is not null
  and ccp.fat_nof_id <> 0
   group by ccp.fat_ccp_mes_fat, ccp.fat_ccp_ano_fat
   union
   --afr
select 'AFR' as tabela, sum(afr.fat_afr_vl_tot_faturado) as valor
  from tb_fat_afr_atend_fatur_res afr
  join tb_cad_pac_paciente pac
    on afr.cad_pac_id_paciente = pac.cad_pac_id_paciente
  join tb_cad_cnv_convenio cnv
    on pac.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
  join tb_atd_ate_atendimento ate
    on afr.atd_ate_id = ate.atd_ate_id
  join tb_cad_uni_unidade uni
    on ate.cad_uni_id_unidade = uni.cad_uni_id_unidade
 where afr.fat_nof_id is not null
 and   afr.fat_afr_nr_mesfat = itensmesano.mes
 and   afr.fat_afr_nr_anofat = itensmesano.ano
 and   afr.fat_nof_id <> 0
 group by afr.fat_afr_nr_mesfat, afr.fat_afr_nr_anofat
 union
 --nof
 select 'NOF' as tabela, sum(nof.fat_nfo_vl_faturado) as valor
 from tb_fat_nof_nota_fiscal nof
 where nof.fat_nof_mes_fat = itensmesano.mes
 and nof.fat_nof_ano_fat = itensmesano.ano
 and nof.fat_nof_id <> 0
 and nof.fat_nof_fl_status = 'A'
 group by nof.fat_nof_mes_fat, nof.fat_nof_ano_fat
union
--tmov
select 'TMOV' as tabela, sum(tmov.valorbruto)
from rm.tmov@RMDB
where  to_char(tmov.dataemissao,'MM') = itensmesano.mes
   and to_char(tmov.dataemissao,'yyyy') = itensmesano.ano
   and tmov.codcoligada = 1
   and status != 'C'
   and tmov.codtmv like '2.2%'
   AND  tmov.codtmv not in ('2.2.03','2.2.09','2.2.10','2.2.11','2.2.14', '2.2.15', '2.2.16', '2.2.04', '2.2.18')
group by    to_char(tmov.dataemissao,'MM'), to_char(tmov.dataemissao,'yyyy')
union
--titmmov
select 'TITMMOV' as tabela, sum(valorliquido)
from rm.titmmov@RMDB
where idmov in (
select idmov
from rm.tmov@RMDB
where  to_char(tmov.dataemissao,'MM') = itensmesano.mes
   and to_char(tmov.dataemissao,'yyyy') = itensmesano.ano
   and tmov.codcoligada = 1
   and status != 'C'
   and tmov.codtmv like '2.2%'
   AND  tmov.codtmv not in ('2.2.03','2.2.09','2.2.10','2.2.11','2.2.14', '2.2.15', '2.2.16', '2.2.04', '2.2.18')
)
)
LOOP
if(nvl(itens.valor,0) > 0) then
v_mensagem := v_mensagem || '<tr><td>' || itens.tabela || '</td><td style="text-align:right;">' ||replace(replace(replace(to_char(itens.valor,'999,999,999,999.00'),'.','*'),',','.'),'*',',') || '</td></tr>' ;
end if;
END LOOP;
for itensemitidas in (
   select 'ABERTO CCP' as tabela, sum(cci.fat_cci_vl_faturado) valor
 from tb_fat_ccp_conta_cons_parc ccp, tb_fat_cci_conta_consu_item cci
where ccp.atd_ate_id = cci.atd_ate_id
  and ccp.cad_pac_id_paciente = cci.cad_pac_id_paciente
  and ccp.fat_ccp_id = cci.fat_ccp_id
  and ccp.fat_coc_id = cci.fat_coc_id
  and cci.fat_cci_fl_status = 'A'
  and cci.fat_cci_tp_destino_item not in ('H','T')
  and cci.cad_tap_tp_atributo <> 'PAC'
  and ccp.fat_ccp_mes_fat = itensmesano.mes
  and ccp.fat_ccp_ano_fat = itensmesano.ano
  and ccp.Fat_Nof_Id is null
  group by cci.fat_cci_mes_fechamento, cci.fat_cci_ano_fechamento
  union
select 'ABERTO CCI' as tabela, sum(ccp.fat_ccp_vl_tot_conta) valor
 from tb_fat_ccp_conta_cons_parc ccp
where ccp.fat_ccp_mes_fat = itensmesano.mes
  and ccp.fat_ccp_ano_fat = itensmesano.ano
  and ccp.Fat_Nof_Id is null
  and ccp.fat_ccp_fl_status = 'A'
  group by ccp.fat_ccp_mes_fat, ccp.fat_ccp_ano_fat
  union
  select 'CALCULADO CCI', sum(cci.fat_cci_vl_calculado) valor
from tb_fat_ccp_conta_cons_parc ccp, tb_fat_cci_conta_consu_item cci
where ccp.atd_ate_id = cci.atd_ate_id
and ccp.cad_pac_id_paciente = cci.cad_pac_id_paciente
and ccp.fat_ccp_id = cci.fat_ccp_id
and ccp.fat_coc_id = cci.fat_coc_id
and cci.fat_cci_fl_status = 'A'
and cci.fat_cci_tp_destino_item not in ('H','T')
and cci.cad_tap_tp_atributo <> 'PAC'
and ccp.fat_ccp_mes_fat = itensmesano.mes
and ccp.fat_ccp_ano_fat = itensmesano.ano
group by cci.fat_cci_mes_fechamento, cci.fat_cci_ano_fechamento
union
select 'CALCULADO CCP',  sum(ccp.fat_ccp_vl_tot_original) valor
from tb_fat_ccp_conta_cons_parc ccp
where ccp.fat_ccp_mes_fat = itensmesano.mes
and ccp.fat_ccp_ano_fat = itensmesano.ano
and ccp.fat_ccp_fl_status = 'A'
group by ccp.fat_ccp_mes_fat, ccp.fat_ccp_ano_fat)
  loop
    v_mensagem := v_mensagem || '<tr><td>' || itensemitidas.tabela || '</td><td style="text-align:right;">' || replace(replace(replace(to_char(itensemitidas.valor,'999,999,999,999.00'),'.','*'),',','.'),'*',',') || '</td></tr>' ;
  end loop;
end loop;
v_mensagem := v_mensagem || '</table>';



/* Faz o envio se registrou algum erro */
if(length(v_mensagem) > 0) then
  prc_envia_email_n('', v_grupo, 'Resumo do Faturamento', '', to_clob(v_header || v_mensagem), null);
  commit;
end if;

END PRC_LOG_CONFERENCIA_FECHAMENTO;
