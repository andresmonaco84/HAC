CREATE OR REPLACE PROCEDURE "PRC_FAT_GRAVAR_AFR"
(
     pATD_ATE_ID             TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE,
     pFAT_CCP_ID             TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ID%TYPE,
     pCAD_PAC_ID_PACIENTE    TB_FAT_CCP_CONTA_CONS_PARC.CAD_PAC_ID_PACIENTE%TYPE,
		 pSEG_USU_ID_USUARIO     TB_FAT_AFR_ATEND_FATUR_RES.Seg_Usu_Id_Usuario%TYPE
)
is
/* Marcus Relva - 22/07/2013 - Gravacao do Resumo Faturamento*/
begin   

for itens in (
select atd.atd_ate_tp_paciente,
       ccp.fat_ccp_id,
       ccp.fat_ccp_mes_fat,
       ccp.fat_ccp_ano_fat,
       cci.cad_tap_tp_atributo,
       sum(cci.fat_cci_vl_produto) fat_cci_vl_produto,
       sum(cci.fat_cci_vl_faturado) fat_cci_vl_faturado,
       ccp.fat_coc_id,
       lnf.fat_lnf_id,
       atd.cad_uni_id_unidade,
			 atd.cad_lat_id_local_atendimento,
			 pac.cad_cnv_id_convenio,
			 cnv.cad_tpe_cd_codigo, 
			 atd.atd_ate_id,
			 ccp.fat_nof_id,
			 pac.cad_pac_id_paciente
  from tb_fat_lnf_lote_cta_parc_nf lnf,
       tb_fat_cci_conta_consu_item cci,
       tb_fat_ccp_conta_cons_parc  ccp,
       tb_atd_ate_atendimento      atd,
			 tb_cad_pac_paciente pac,
			 tb_cad_cnv_convenio cnv
 where
       atd.atd_ate_id = patd_ate_id
   and ccp.fat_ccp_id = pfat_ccp_id
   and ccp.cad_pac_id_paciente = pcad_pac_id_paciente
   and pac.cad_pac_id_paciente = ccp.cad_pac_id_paciente
	 and pac.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
   and lnf.fat_lnf_id = ccp.fat_lnf_id
   and ccp.atd_ate_id = atd.atd_ate_id
   and cci.fat_ccp_id = ccp.fat_ccp_id
   and cci.atd_ate_id = atd.atd_ate_id
   and cci.cad_pac_id_paciente = ccp.cad_pac_id_paciente
   and (cci.fat_cci_fl_pacote is null or cci.fat_cci_fl_pacote <> 'S')
   and cci.fat_cci_fl_status = 'A'
group by atd.atd_ate_tp_paciente,
       atd.atd_ate_id,
       ccp.fat_ccp_id,
       ccp.fat_ccp_mes_fat,
       ccp.fat_ccp_ano_fat,
       cci.cad_tap_tp_atributo,
       ccp.fat_coc_id,
       lnf.fat_lnf_id,
       atd.cad_uni_id_unidade,
       atd.cad_lat_id_local_atendimento,
			 pac.cad_cnv_id_convenio,
			 cnv.cad_tpe_cd_codigo,
 			 ccp.fat_nof_id,
			 pac.cad_pac_id_paciente)
		loop
		
			insert into tb_fat_afr_atend_fatur_res afr
			(afr.atd_ate_tp_paciente,
				afr.atd_ate_id,
				afr.fat_ccp_id,
				afr.fat_afr_nr_mesfat,
				afr.fat_afr_nr_anofat,
				afr.cad_tap_tp_atributo,
				afr.fat_afr_vl_tot_produto,
				afr.fat_afr_vl_tot_faturado,
				afr.fat_nof_id,
				afr.seg_usu_id_usuario,
				afr.fat_afr_dt_ultima_atualizacao,
				afr.fat_afr_fl_status,
				afr.fat_coc_id,
				afr.cad_pac_id_paciente,
				afr.fat_lnf_id,
				afr.cad_cnv_id_convenio,
				afr.cad_uni_id_unidade,
				afr.cad_lat_id_local_atendimento,
				afr.cad_tpe_cd_codigo)
				values
				(itens.atd_ate_tp_paciente,
				 itens.atd_ate_id,
				 itens.fat_ccp_id,
				 itens.fat_ccp_mes_fat,
				 itens.fat_ccp_ano_fat,
				 itens.cad_tap_tp_atributo,
				 itens.fat_cci_vl_produto,
				 itens.fat_cci_vl_faturado,
				 itens.fat_nof_id,
         pSEG_USU_ID_USUARIO,
				 sysdate,
				 'A',
				 1,
				 pCAD_PAC_ID_PACIENTE,
				 itens.fat_lnf_id,
				 itens.cad_cnv_id_convenio,
				 itens.cad_uni_id_unidade,
				 itens.cad_lat_id_local_atendimento,
				 itens.cad_tpe_cd_codigo
				);	
			
			
		end loop;


end PRC_FAT_GRAVAR_AFR;
 