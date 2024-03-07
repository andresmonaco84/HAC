CREATE OR REPLACE PROCEDURE "PRC_FAT_INCLUIR_NOF" (pATD_ATE_ID          in number,
                                                pPERCENTUALISS       in number,
                                                pNUMERONF            in varchar2,
                                                pFAT_NOF_FL_JURIDICA in varchar2,
                                                pFAT_CCP_ID          in number,
                                                pDESCONTO in number default null) IS
  v_idnof              number;
  v_idusuariointerface number := 8642;  
  v_convenio_pa constant number := 282;
	v_municipio varchar2(200);
  v_inscricaomunicipal varchar2(100);
  v_tipoempresa varchar2(10);
BEGIN
  select seq_fat_nof_01.nextval into v_idnof from dual;
  FOR ITENS IN (select ate.atd_ate_id,
                       ate.cad_uni_id_unidade,
                       pac.cad_cnv_id_convenio,
                       pac.cad_pla_id_plano,
                       ccp.fat_ccp_id,
                       ccp.cad_pac_id_paciente,
                       ccp.fat_ccp_ano_fat,
                       ccp.fat_ccp_mes_fat,
                       ccp.fat_ccp_vl_tot_conta,
                       ccp.fat_lnf_id,
                       ccp.fat_ccp_dt_parcela,
											 decode(decode(ate.atd_ate_tp_paciente, 'U', 'A', 'E', 'I', ate.atd_ate_tp_paciente), 'I','INT','A','AMB') tipopaciente
                  from tb_atd_ate_atendimento     ate,
                       tb_fat_ccp_conta_cons_parc ccp,
                       tb_cad_pac_paciente        pac
                 where ate.atd_ate_id = ccp.Atd_Ate_Id
                   and ccp.cad_pac_id_paciente = pac.cad_pac_id_paciente
                   and ccp.atd_ate_id = pATD_ATE_ID
                   and ccp.fat_ccp_id = pFAT_CCP_ID
                   and pac.cad_cnv_id_convenio = v_convenio_pa) LOOP
	begin		
		select mun.aux_mun_nm_municipio, 
		pes.cad_pes_cd_inscr_munic, 
		cnv.cad_tpe_cd_codigo
		into v_municipio,
		     v_inscricaomunicipal,
				 v_tipoempresa
		from tb_cad_uni_unidade uni
		join tb_cad_pes_pessoa pes
		on uni.cad_pes_id_pessoa = pes.cad_pes_id_pessoa
		join tb_cad_end_endereco e
		on pes.cad_pes_id_pessoa = e.cad_pes_id_pessoa
		and e.aux_tte_cd_tp_tel_end = 2
		join tb_aux_mun_municipio mun
		on e.aux_mun_cd_ibge = mun.aux_mun_cd_ibge
		cross join tb_cad_cnv_convenio cnv
		where uni.cad_uni_id_unidade = itens.cad_uni_id_unidade
		and cnv.cad_cnv_id_convenio = itens.cad_cnv_id_convenio;
  exception when others then
		 v_municipio := null;
		 v_inscricaomunicipal := null;
   	 v_tipoempresa := null;
	end;									 
    /*Inserir na NOF*/
    insert into tb_fat_nof_nota_fiscal
      (CAD_CNV_ID_CONVENIO,
       CAD_MCN_ID,
       CAD_PLA_ID_PLANO,
       CAD_UNI_ID_UNIDADE,
       FAT_NFO_DT_EMISSAO,
       FAT_NFO_DT_VENCIMENTO,
       FAT_NFO_VL_FATURADO,
       FAT_NFO_VL_LIQUIDO,
       FAT_NFO_VL_RETENCAO,
       FAT_NOF_ANO_FAT,
       FAT_NOF_DS_DESCONTO,
       FAT_NOF_DT_CANCELAMENTO,
       FAT_NOF_DT_ULTIMA_ATUALIZACAO,
       FAT_NOF_FL_JURIDICA,
       FAT_NOF_FL_STATUS,
       FAT_NOF_ID,
       FAT_NOF_MES_FAT,
       FAT_NOF_NR_DOCUMENTO,
       FAT_NOF_NR_NOTAFISCAL,
       FAT_NOF_PC_COFINS,
       FAT_NOF_PC_CSLL,
       FAT_NOF_PC_IR,
       FAT_NOF_PC_ISS,
       FAT_NOF_PC_PIS,
       FAT_NOF_TP_SERIEFISCAL,
       FAT_NOF_VL_COFINS,
       FAT_NOF_VL_CSLL,
       FAT_NOF_VL_DESCONTO,
       FAT_NOF_VL_IR,
       FAT_NOF_VL_ISS,
       FAT_NOF_VL_PIS,
       SEG_USU_ID_USUARIO,
       SEG_USU_ID_USUARIO_CANCELA,
			 cad_uni_ds_municipio,
       cad_uni_cd_inscr_munic,
       cad_tpe_cd_codigo,
       fat_nof_tp_grupo_pac,
       fat_nof_vl_notafiscal)
    values
      (
      itens.cad_cnv_id_convenio, --CAD_CNV_ID_CONVENIO  282
       null, --CAD_MCN_ID  
       itens.cad_pla_id_plano, --CAD_PLA_ID_PLANO  401
       itens.cad_uni_id_unidade, --CAD_UNI_ID_UNIDADE  244
       sysdate, --FAT_NFO_DT_EMISSAO  07/01/2011 13:15:43
       (sysdate + 3), --FAT_NFO_DT_VENCIMENTO  07/01/2011 13:15:43
       itens.fat_ccp_vl_tot_conta, --FAT_NFO_VL_FATURADO  1376,65
       round((itens.fat_ccp_vl_tot_conta-(pPERCENTUALISS * (itens.fat_ccp_vl_tot_conta / 100))),2) - nvl(pDESCONTO,0), --FAT_NFO_VL_LIQUIDO  1376,65
       (pPERCENTUALISS * (itens.fat_ccp_vl_tot_conta / 100)), --FAT_NFO_VL_RETENCAO  0,00
       itens.fat_ccp_ano_fat, --FAT_NOF_ANO_FAT   2011
       null, --FAT_NOF_DS_DESCONTO  
       null, --FAT_NOF_DT_CANCELAMENTO  
       sysdate, --FAT_NOF_DT_ULTIMA_ATUALIZACAO  
       pFAT_NOF_FL_JURIDICA, --FAT_NOF_FL_JURIDICA  S
       'A', --FAT_NOF_FL_STATUS  A
       v_idnof, --FAT_NOF_ID  861
       itens.fat_ccp_mes_fat, --FAT_NOF_MES_FAT  1
       null, --FAT_NOF_NR_DOCUMENTO  
       pNUMERONF, --FAT_NOF_NR_NOTAFISCAL  17186
       null, --FAT_NOF_PC_COFINS  
       null, --FAT_NOF_PC_CSLL  
       null, --FAT_NOF_PC_IR  
       pPERCENTUALISS, --FAT_NOF_PC_ISS  
       null, --FAT_NOF_PC_PIS  
       null, --FAT_NOF_TP_SERIEFISCAL  A
       null, --FAT_NOF_VL_COFINS  
       null, --FAT_NOF_VL_CSLL  
       nvl(pDESCONTO,0), --FAT_NOF_VL_DESCONTO  
       null, --FAT_NOF_VL_IR  
       (pPERCENTUALISS * (itens.fat_ccp_vl_tot_conta / 100)), --FAT_NOF_VL_ISS  
       null, --FAT_NOF_VL_PIS  
       v_idusuariointerface, --SEG_USU_ID_USUARIO 
       null,
			 v_municipio,
			 v_inscricaomunicipal,
			 v_tipoempresa,
			 itens.tipopaciente,
       itens.fat_ccp_vl_tot_conta); 
    /*Atualizar CCP*/
    update tb_fat_ccp_conta_cons_parc ccp
       set ccp.fat_nof_id = v_idnof
     where ccp.atd_ate_id = itens.atd_ate_id
       and ccp.fat_ccp_id = itens.fat_ccp_id
       and ccp.cad_pac_id_paciente = itens.cad_pac_id_paciente;
    /*Atualizar AFR*/
    update tb_fat_afr_atend_fatur_res afr
       set afr.fat_nof_id = v_idnof
     where afr.atd_ate_id = itens.atd_ate_id
       and afr.fat_ccp_id = itens.fat_ccp_id
       and afr.cad_pac_id_paciente = itens.Cad_Pac_Id_Paciente;
  END LOOP;
end PRC_FAT_INCLUIR_NOF;
 
/
