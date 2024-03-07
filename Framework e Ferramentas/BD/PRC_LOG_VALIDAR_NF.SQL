CREATE OR REPLACE PROCEDURE PRC_LOG_VALIDAR_NF
IS
/* Marcus Relva - VALIDAR NF - 06/08/2012 */
v_header         varchar2(1000) := '<font face="calibri">';
v_mensagem       varchar2(32000) := '';
v_grupo          varchar2(100)  := 'InterfacesMonitoramento@anacosta.com.br';


v_ccp number(15,5) := 0;
v_cci number(15,5) := 0;
v_afr number(15,5) := 0;
v_nof number(15,5) := 0;

v_mesccp number := 0;
v_mescci number := 0;
v_mesafr number := 0;
v_mesnof number := 0;

v_mailhost VARCHAR2(64) := '172.16.1.18';
v_con utl_smtp.connection;
BEGIN
FOR itens IN (
	select n.fat_nof_id, 
	       n.fat_nof_nr_notafiscal, 
				 uni.cad_uni_ds_municipio, 
				 uni.cad_uni_ds_unidade, 
				 cnv.cad_cnv_cd_hac_prestador  
				 from tb_fat_nof_nota_fiscal n
	join tb_cad_uni_unidade uni on n.cad_uni_id_unidade = uni.cad_uni_id_unidade
	join tb_cad_cnv_convenio cnv on n.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
	where trunc(n.fat_nfo_dt_emissao) > trunc(sysdate) -1
	and n.fat_nof_fl_status = 'A'
)
LOOP
	begin
		select item.valor, parcela.valor, resumo.valor, nota.valor,
           item.mes, parcela.mes, resumo.mes, nota.mes
			into v_cci, v_ccp, v_afr, v_nof, v_mescci, v_mesccp, v_mesafr, v_mesnof
			from (select 'CCI',
										sum(cci.fat_cci_vl_faturado) valor,
										cci.fat_cci_mes_fechamento AS MES,
										cci.fat_cci_ano_fechamento AS ANO
							from tb_fat_ccp_conta_cons_parc  ccp,
										tb_fat_cci_conta_consu_item cci
						 where ccp.atd_ate_id = cci.atd_ate_id
							 and ccp.cad_pac_id_paciente = cci.cad_pac_id_paciente
							 and ccp.fat_ccp_id = cci.fat_ccp_id
							 and ccp.fat_coc_id = cci.fat_coc_id
							 and cci.fat_cci_fl_status = 'A'
							 and cci.fat_cci_tp_destino_item <> 'H'
							 and cci.cad_tap_tp_atributo <> 'PAC'
							 and ccp.fat_nof_id = itens.fat_nof_id
						 group by cci.fat_cci_mes_fechamento, cci.fat_cci_ano_fechamento) item,
					 (select 'CCP',
									 sum(ccp.fat_ccp_vl_tot_conta) AS VALOR,
									 ccp.fat_ccp_mes_fat AS MES,
									 ccp.fat_ccp_ano_fat AS ANO
							from tb_fat_ccp_conta_cons_parc ccp
						 where ccp.fat_nof_id = itens.fat_nof_id
							 and ccp.fat_ccp_fl_status = 'A'
							 and ccp.fat_ccp_fl_faturada = 'S'
						 group by ccp.fat_ccp_mes_fat, ccp.fat_ccp_ano_fat) parcela,
					 (select 'AFR',
									 sum(afr.fat_afr_vl_tot_faturado) as valor,
									 afr.fat_afr_nr_mesfat AS MES,
									 afr.fat_afr_nr_anofat AS ANO
							from tb_fat_afr_atend_fatur_res afr
							join tb_cad_pac_paciente pac
								on afr.cad_pac_id_paciente = pac.cad_pac_id_paciente
							join tb_cad_cnv_convenio cnv
								on pac.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
							join tb_atd_ate_atendimento ate
								on afr.atd_ate_id = ate.atd_ate_id
							join tb_cad_uni_unidade uni
								on ate.cad_uni_id_unidade = uni.cad_uni_id_unidade
						 where afr.fat_nof_id = itens.fat_nof_id
						 group by afr.fat_afr_nr_mesfat, afr.fat_afr_nr_anofat) resumo,
					 (select 'NOF',
										nof.fat_nfo_vl_faturado as valor,
										nof.fat_nof_mes_fat     AS MES,
										nof.fat_nof_ano_fat     AS ANO
							from tb_fat_nof_nota_fiscal nof
						 where nof.fat_nof_id = itens.fat_nof_id) nota;						 
	exception when others then
 	v_mensagem := v_mensagem 
	    || '<b>VERIFICAR NF: </b>' || itens.fat_nof_nr_notafiscal
			|| '<br><b>CONVENIO: </b>' || itens.cad_cnv_cd_hac_prestador 
			|| '<br><b>MUNICIPIO: </b>' || itens.cad_uni_ds_municipio 
			|| '<br><b>UNIDADE: </b>' || itens.cad_uni_ds_unidade 
			|| '<br><b>FAT_NOF_ID: </b>' || itens.fat_nof_id ||'<hr/>';
		v_ccp := 0;
		v_cci := 0;
		v_afr := 0;
		v_nof := 0;		
		v_mesccp := 0;
		v_mescci := 0;
		v_mesafr := 0;
		v_mesnof := 0;
	end;
	
   if(v_cci != v_ccp or v_cci != v_afr or v_cci != v_nof
    or v_ccp != v_afr or v_ccp != v_nof
		or v_afr != v_nof) then
			v_mensagem := v_mensagem 
			|| '<b>VERIFICAR VALORES PARA NF: </b>' || itens.fat_nof_nr_notafiscal
			|| '<br><b>CONVENIO: </b>' || itens.cad_cnv_cd_hac_prestador 
			|| '<br><b>MUNICIPIO: </b>' || itens.cad_uni_ds_municipio 
			|| '<br><b>UNIDADE: </b>' || itens.cad_uni_ds_unidade 
			|| '<br><b>FAT_NOF_ID: </b>' || itens.fat_nof_id 
			|| '<br><b>VALOR CCI: </b>' || v_cci 
			|| '<br><b>VALOR CCP: </b>' || v_ccp 
  			|| '<br><b>VALOR AFR: </b>' || v_afr 
			|| '<br><b>VALOR NOF: </b>' || v_nof ||'<hr/>';
		end if;
		
	 if(v_mescci != v_mesccp or v_mescci != v_mesafr or v_mescci != v_mesnof
    or v_mesccp != v_mesafr or v_mesccp != v_mesnof
		or v_mesafr != v_mesnof) then
			v_mensagem := v_mensagem 
			|| '<b>VERIFICAR MES/ANO PARA NF: </b>' || itens.fat_nof_nr_notafiscal
			|| '<br><b>CONVENIO: </b>' || itens.cad_cnv_cd_hac_prestador 
			|| '<br><b>MUNICIPIO: </b>' || itens.cad_uni_ds_municipio 
			|| '<br><b>UNIDADE: </b>' || itens.cad_uni_ds_unidade 
			|| '<br><b>FAT_NOF_ID: </b>' || itens.fat_nof_id  
			|| '<br><b>MES CCI: </b>' || v_mescci 
			|| '<br><b>MES CCP: </b>' || v_mesccp 
  			|| '<br><b>MES AFR: </b>' || v_mesafr 
			|| '<br><b>MES NOF: </b>' || v_mesnof ||'<hr/>';
		end if;
		
END LOOP;

/* Faz o envio se registrou algum erro */
if(length(v_mensagem) > 0) then
	v_con := utl_smtp.open_connection(v_mailhost, 25);
	utl_smtp.helo(v_con, v_mailhost);
	utl_smtp.mail(v_con, v_grupo);
	utl_smtp.rcpt(v_con, v_grupo);
	utl_smtp.open_data(v_con);
	utl_smtp.write_data(v_con, 'From:  "LOG" <'|| v_grupo ||'>' || UTL_TCP.CRLF);
	utl_smtp.write_data(v_con, 'To: "LOG" <'|| v_grupo ||'>' || UTL_TCP.CRLF);
	utl_smtp.write_data(v_con, 'Subject: Divergencia de nota fiscal' || UTL_TCP.CRLF);
	utl_smtp.write_data(v_con, 'Content-Type: text/html' || UTL_TCP.CRLF || UTL_TCP.CRLF);
	utl_smtp.write_data(v_con,  v_header || v_mensagem || UTL_TCP.CRLF);
	utl_smtp.close_data(v_con);
	utl_smtp.quit(v_con);
end if;

END PRC_LOG_VALIDAR_NF;
  