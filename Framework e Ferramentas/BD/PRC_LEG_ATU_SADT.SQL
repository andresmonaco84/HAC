CREATE OR REPLACE PROCEDURE SGS."PRC_LEG_ATU_SADT" is
  /********************************************************************
  *    Procedure: PRC_LEG_ATU_SADT
  *
  *    Data Criacao:  13/02/2009   Por: SILMARA
  *    Funcao: incluir as informações na tabelas legado SADT
  *
  *******************************************************************/
     v_contador                      number;
    v_error_code                    number;
    v_contador                       number;  
     v_error_message                 varchar2(900);
    ex_atendimentoinexistente       exception;
    nRetorno integer;  
 begin  
   for atsaten in 
     (select ats.ats_ate_id   v_nr_codexa,
       prd.cad_prd_tp_produto v_codunisad,
       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO='SP' AND CNV.CAD_CNV_CD_HAC_PRESTADOR='SX73' AND PLA.CAD_PLA_CD_PLANO_HAC IN ('SKIDO','SKIPA')
                   THEN 'SX94'
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='SP'  THEN SUBSTR(cnv.cad_cnv_cd_hac_prestador,1,4)
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='GB' THEN PLA.CAD_PLA_CD_PLANO_HAC
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='PL' THEN PLA.CAD_PLA_CD_PLANO_HAC
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='PA' THEN SUBSTR(cnv.cad_cnv_cd_hac_prestador,1,4)
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='FU' THEN PLA.CAD_PLA_CD_PLANO_HAC
                  ELSE SUBSTR(cnv.cad_cnv_cd_hac_prestador,1,4)
                  END v_codcon,      
       ats.ats_ate_dt_realiz_proced v_dt_dtexa,
       LPAD(TO_CHAR(ats.ats_ate_hr_realiz_proced),4,'0') v_horexa,
       ats.ats_ate_cd_intlib v_nr_codateamb,
       TO_NUMBER(TRIM(PRO.CAD_PRO_NR_CONSELHO)) v_nr_codmed,
       proced.cd_proced v_nr_cd_proced,
       arp.ats_arp_dt_resultado v_dt_datent,
       ats.ats_ate_tp_proced v_tipexa,
       DECODE(ats.ats_ate_fl_status,'A','N','C','S') v_cancelado,
       pac.cad_pac_nr_prontuario v_nr_codpac,
    ats.ATS_ATE_NR_QUARTO v_quarto,
      ats.ats_ate_nr_leito v_leito,
         ats_ate_fl_rn v_rn,    
       TO_NUMBER(UNI.CAD_UNI_CD_UNID_HOSPITALAR,'99') v_nr_codunihos, 
       prd.cad_prd_nm_mnemonico v_mne,
       decode(ats.ats_ate_fl_equip_int_ext,'I','H','E','HM') v_equip,
       decode(apl.ats_apl_status_laudo, 'P','E', apl.ats_apl_status_laudo) v_sitlaudo 
     from
      sgs.tb_ats_ate_atendimento_sadt ats ,
      sgs.tb_cad_prd_produto prd,
      sgs.tb_cad_cnv_convenio cnv,
      sgs.tb_cad_pro_profissional pro,
      hospital.sadt_procedencia proced,
      sgs.tb_ats_arp_aten_result_proced arp,
      sgs.tb_cad_pac_paciente pac,
       sgs.tb_cad_uni_unidade uni,
      sgs.tb_cad_set_setor setor,
      sgs.tb_cad_set_setor setorproced,
      sgs.tb_cad_pla_plano pla,
      sgs.Tb_Ats_Apl_Aten_Proced_Laudo apl 
      where ats.cad_pac_id_paciente_int=pac.cad_pac_id_paciente
      and pac.cad_cnv_id_convenio=cnv.cad_cnv_id_convenio
      and ats.cad_set_id_aten=setor.cad_set_id
      and trim(setorproced.cad_set_ds_procedencia) like trim(proced.ds_proced) 
      and apl.cad_pro_id_prof=pro.cad_pro_id_profissional
      and ats.ats_ate_cd_intlib=arp.ats_ate_cd_intlib
      and ats.ats_ate_in_intlib=arp.ats_ate_in_intlib
      and ats.ats_ate_id=arp.ats_ate_id
      and ats.aux_epp_cd_especproc=arp.ats_epp_cd_especproc
      and ats.cad_prd_id=arp.cad_prd_id
      and ats.cad_set_id_aten=setor.cad_set_id
      and setor.cad_uni_id_unidade=uni.cad_uni_id_unidade
      and ats.cad_set_id=setorproced.cad_set_id
      and prd.cad_prd_id=ats.cad_prd_id
      and pla.cad_cnv_id_convenio=cnv.cad_cnv_id_convenio
      and pla.cad_pla_id_plano=pac.cad_pla_id_plano
      and ats.ats_ate_id= apl.ats_ate_id 
      and ats.aux_epp_cd_especproc=apl.aux_epp_cd_especproc 
      and ats.ats_ate_in_intlib=apl.ats_ate_in_intlib 
      and ats.ats_ate_cd_intlib=apl.ats_ate_cd_intlib
      and ats.cad_prd_id=apl.cad_prd_id       
      and ats.ats_ate_atu_interf_legado is null    
      and ats.ats_ate_fl_status ='A'     
      ) 
   LOOP
      BEGIN
    Insert into  hospital.SADT_PACIENTE
   (CODEXA ,
    CODUNISAD ,
    CODCON,
    CODREC,
    DATEXA,
    HOREXA,
    CODATEAMB,
    CRM,
    CD_PROCED,
    DATENT,   
    TIPEXA  ,   
    CANCELADO  ,
    CODPAC, 
    RN,
    CODUNIHOS,
    OBS
     )   
     VALUES
   ( atsaten.v_nr_codexa,
     trim(atsaten.v_codunisad),
     atsaten.v_codcon,
     1, 
    atsaten.v_dt_dtexa,
    atsaten.v_horexa,
    atsaten.v_nr_codateamb,
    trim(atsaten.v_nr_codmed),
    atsaten.v_nr_cd_proced ,
    atsaten.v_dt_datent,
    atsaten.v_tipexa,
    atsaten.v_cancelado,
    atsaten.v_nr_codpac,
    atsaten.v_rn,   
    atsaten.v_nr_codunihos,
    'INTERF '||TO_CHAR(SYSDATE,'DD-MM-YYYY'));     
 EXCEPTION
     WHEN DUP_VAL_ON_INDEX THEN
           NULL; 
  END;
  END LOOP;
 begin   
   for atsexa  in 
     (select ats.ats_ate_id   v_nr_codexa,
       prd.cad_prd_tp_produto v_codunisad,
       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO='SP' AND CNV.CAD_CNV_CD_HAC_PRESTADOR='SX73' AND PLA.CAD_PLA_CD_PLANO_HAC IN ('SKIDO','SKIPA')
                   THEN 'SX94'
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='SP'  THEN SUBSTR(cnv.cad_cnv_cd_hac_prestador,1,4)
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='GB' THEN PLA.CAD_PLA_CD_PLANO_HAC
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='PL' THEN PLA.CAD_PLA_CD_PLANO_HAC
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='PA' THEN SUBSTR(cnv.cad_cnv_cd_hac_prestador,1,4)
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='FU' THEN PLA.CAD_PLA_CD_PLANO_HAC
                  ELSE SUBSTR(cnv.cad_cnv_cd_hac_prestador,1,4)
                  END v_codcon,    
       ats.ats_ate_dt_realiz_proced v_dt_dtexa,
       ats.ats_ate_hr_realiz_proced v_hor,
       LPAD(TO_CHAR(ats.ats_ate_hr_realiz_proced),4,'0') v_horexa,
       ats.ats_ate_cd_intlib v_nr_codateamb,
       TO_NUMBER(TRIM(PRO.CAD_PRO_NR_CONSELHO)) v_nr_codmed,
       proced.cd_proced v_nr_cd_proced,
       arp.ats_arp_dt_resultado v_dt_datent,
       ats.ats_ate_tp_proced v_tipexa,
       DECODE(ats.ats_ate_fl_status,'A','N','C','S') v_cancelado,
       pac.cad_pac_nr_prontuario v_nr_codpac,
    ats.ATS_ATE_NR_QUARTO v_quarto,
      ats.ats_ate_nr_leito v_leito,
         ats_ate_fl_rn v_rn,
         ats.ats_ate_in_intlib v_intlib,
         ats.cad_prd_id    v_idproduto,     
         ats.aux_epp_cd_especproc v_esp,
       TO_NUMBER(UNI.CAD_UNI_CD_UNID_HOSPITALAR,'99') v_nr_codunihos, 
       prd.cad_prd_nm_mnemonico v_mne,
       decode(ats.ats_ate_fl_equip_int_ext,'I','H','E','HM') v_equip,
     decode(apl.ats_apl_status_laudo, 'P','E', apl.ats_apl_status_laudo) v_sitlaudo
         from
      sgs.tb_ats_ate_atendimento_sadt ats ,
      sgs.tb_cad_prd_produto prd,
      sgs.tb_cad_cnv_convenio cnv,
      sgs.tb_cad_pro_profissional pro,
      hospital.sadt_procedencia proced,
      sgs.tb_ats_arp_aten_result_proced arp,
      sgs.tb_cad_pac_paciente pac,
       sgs.tb_cad_uni_unidade uni,
      sgs.tb_cad_set_setor setor,
      sgs.tb_cad_set_setor setorproced,
      sgs.tb_cad_pla_plano pla,
      sgs.Tb_Ats_Apl_Aten_Proced_Laudo apl  
      where ats.cad_pac_id_paciente_int=pac.cad_pac_id_paciente
      and pac.cad_cnv_id_convenio=cnv.cad_cnv_id_convenio
      and ats.cad_set_id_aten=setor.cad_set_id
      and trim(setorproced.cad_set_ds_procedencia) like trim(proced.ds_proced)  
      and apl.cad_pro_id_prof=pro.cad_pro_id_profissional
      and ats.ats_ate_cd_intlib=arp.ats_ate_cd_intlib
      and ats.ats_ate_in_intlib=arp.ats_ate_in_intlib
      and ats.ats_ate_id=arp.ats_ate_id
      and ats.aux_epp_cd_especproc=arp.ats_epp_cd_especproc
      and ats.cad_prd_id=arp.cad_prd_id
      and ats.cad_set_id_aten=setor.cad_set_id
      and setor.cad_uni_id_unidade=uni.cad_uni_id_unidade
      and ats.cad_set_id=setorproced.cad_set_id
      and prd.cad_prd_id=ats.cad_prd_id
      and pla.cad_cnv_id_convenio=cnv.cad_cnv_id_convenio
      and pla.cad_pla_id_plano=pac.cad_pla_id_plano
      and ats.ats_ate_id= apl.ats_ate_id 
      and ats.aux_epp_cd_especproc=apl.aux_epp_cd_especproc 
      and ats.ats_ate_in_intlib=apl.ats_ate_in_intlib 
      and ats.ats_ate_cd_intlib=apl.ats_ate_cd_intlib
      and ats.cad_prd_id=apl.cad_prd_id     
      and ats.ats_ate_atu_interf_legado is null 
      and ats.ats_ate_fl_status ='A'        
     )
   LOOP
    BEGIN
      nRetorno :=0; 
    Insert into  hospital.SADT_EXAMES_PACIENTE
    ( CODUNISAD,     
      CODEXA,       
      LOCAL_EQUIPAMENTO,    
  	  CODMNE,    
      TIPLDO,   
      CODSITLDO,   
		  CODREC,   
      CODUNIHOS,
       OBS)
		VALUES    
		(trim(atsexa.v_codunisad),
     atsexa.v_nr_codexa,     
     atsexa.v_equip,
     trim(atsexa.v_mne),
     'N',
     atsexa.v_sitlaudo,
      1,      
     atsexa.v_nr_codunihos,
     'INTERF '||TO_CHAR(SYSDATE,'DD-MM-YYYY'));
     EXCEPTION
       WHEN DUP_VAL_ON_INDEX THEN   
         null;         
     END;
   END LOOP;
   END;  
begin  
   for atsinterfseg in 
  (   select  aps.ats_ate_id    v_nr_codexa,         
       prd.cad_prd_tp_produto v_codunisad,   
       aps.ats_ate_cd_intlib v_nr_codateamb,       
       TO_NUMBER(UNI.CAD_UNI_CD_UNID_HOSPITALAR,'99') v_nr_codunihos,
        ats.ats_ate_tp_proced v_tipexa, 
       prd.cad_prd_nm_mnemonico v_nm_mnemonico
          from
      tb_ats_ate_atendimento_sadt ats ,
      tb_cad_prd_produto prd,      
      tb_cad_uni_unidade uni,
      tb_cad_set_setor setor,    
      Tb_Ats_Apl_Aten_Proced_Laudo apl,
      tb_ats_aps_aten_proc_segmento aps  
      where       
       ats.cad_set_id_aten=setor.cad_set_id      
      and setor.cad_uni_id_unidade=uni.cad_uni_id_unidade          
     and ats.ats_ate_id= apl.ats_ate_id 
      and ats.aux_epp_cd_especproc=apl.aux_epp_cd_especproc 
      and ats.ats_ate_in_intlib=apl.ats_ate_in_intlib 
       and ats.ats_ate_cd_intlib=apl.ats_ate_cd_intlib
      and ats.cad_prd_id=apl.cad_prd_id   
     and ats.ats_ate_atu_interf_legado is null
      and ats.ats_ate_fl_status ='A' 
       and ats.ats_ate_id= aps.ats_ate_id 
      and ats.aux_epp_cd_especproc=aps.aux_epp_cd_especproc 
     and ats.ats_ate_in_intlib=aps.ats_ate_in_intlib 
      and ats.ats_ate_cd_intlib=aps.ats_ate_cd_intlib 
      and ats.cad_prd_id=aps.cad_prd_id
       and aps.cad_prd_id!=aps.cad_prd_id_aps
       and ats.cad_prd_id=prd.cad_prd_id )       
    LOOP
      BEGIN  
      INSERT INTO hospital.SADT_INTERF_FATURAMENTO
		 ( CODEXA,  
       CODMNE,
		   CODUNISAD,   
        ACAO,
		   STATUS, 
       TIPLDO,
		   CODUNIHOS,
       CODMNE_SEG,
       DT_ENTRADA,
		   CODATE )
		 VALUES
		 ( atsinterfseg.v_nr_codexa,
        'SEGMENTO', 
		    trim(atsinterfseg.v_codunisad), 
        'INS',
		     'A' ,
         'N',
		     atsinterfseg.v_nr_codunihos,
         'SEGMENTO', 
         SYSDATE,
		     atsinterfseg.v_nr_codateamb); 
 END;
  END LOOP;
   END;   
 begin  
   for atsinterf in 
  ( select ats.ats_ate_id   v_nr_codexa,
       prd.cad_prd_tp_produto v_codunisad,
       CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO='SP' AND CNV.CAD_CNV_CD_HAC_PRESTADOR='SX73' AND PLA.CAD_PLA_CD_PLANO_HAC IN ('SKIDO','SKIPA')
                   THEN 'SX94'
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='SP'  THEN SUBSTR(cnv.cad_cnv_cd_hac_prestador,1,4)
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='GB' THEN PLA.CAD_PLA_CD_PLANO_HAC
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='PL' THEN PLA.CAD_PLA_CD_PLANO_HAC
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='PA' THEN SUBSTR(cnv.cad_cnv_cd_hac_prestador,1,4)
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='FU' THEN PLA.CAD_PLA_CD_PLANO_HAC
                  ELSE SUBSTR(cnv.cad_cnv_cd_hac_prestador,1,4)
                  END v_codcon,   
       ats.ats_ate_dt_realiz_proced v_dt_dtexa,
       ats.ats_ate_hr_realiz_proced v_hor,
       LPAD(TO_CHAR(ats.ats_ate_hr_realiz_proced),4,'0') v_horexa,
       ats.ats_ate_cd_intlib v_nr_codateamb,
       TO_NUMBER(TRIM(PRO.CAD_PRO_NR_CONSELHO)) v_nr_codmed,
       proced.cd_proced v_nr_cd_proced,
       arp.ats_arp_dt_resultado v_dt_datent,
       ats.ats_ate_tp_proced v_tipexa,
       DECODE(ats.ats_ate_fl_status,'A','N','C','S') v_cancelado,
       pac.cad_pac_nr_prontuario v_nr_codpac,
    ats.ATS_ATE_NR_QUARTO v_quarto,
      ats.ats_ate_nr_leito v_leito,
         ats_ate_fl_rn v_rn,
           ats.cad_prd_id    v_idproduto,
          ats.aux_epp_cd_especproc v_esp,
           ats.ats_ate_in_intlib v_intlib,    
       TO_NUMBER(UNI.CAD_UNI_CD_UNID_HOSPITALAR,'99') v_nr_codunihos, 
       prd.cad_prd_nm_mnemonico v_mne,
       decode(ats.ats_ate_fl_equip_int_ext,'I','H','E','HM') v_equip,
      decode(apl.ats_apl_status_laudo, 'P','E', apl.ats_apl_status_laudo) v_sitlaudo 
          from
      sgs.tb_ats_ate_atendimento_sadt ats ,
      sgs.tb_cad_prd_produto prd,
      sgs.tb_cad_cnv_convenio cnv,
      sgs.tb_cad_pro_profissional pro,
      hospital.sadt_procedencia proced,
      sgs.tb_ats_arp_aten_result_proced arp,
      sgs.tb_cad_pac_paciente pac,
       sgs.tb_cad_uni_unidade uni,
      sgs.tb_cad_set_setor setor,
      sgs.tb_cad_set_setor setorproced,
      sgs.tb_cad_pla_plano pla,
      sgs.Tb_Ats_Apl_Aten_Proced_Laudo apl  
      where ats.cad_pac_id_paciente_int=pac.cad_pac_id_paciente
      and pac.cad_cnv_id_convenio=cnv.cad_cnv_id_convenio
      and ats.cad_set_id_aten=setor.cad_set_id
      and trim(setorproced.cad_set_ds_procedencia) like trim(proced.ds_proced)    
      and apl.cad_pro_id_prof=pro.cad_pro_id_profissional
      and ats.ats_ate_cd_intlib=arp.ats_ate_cd_intlib
      and ats.ats_ate_in_intlib=arp.ats_ate_in_intlib
      and ats.ats_ate_id=arp.ats_ate_id
      and ats.aux_epp_cd_especproc=arp.ats_epp_cd_especproc
      and ats.cad_prd_id=arp.cad_prd_id
      and ats.cad_set_id_aten=setor.cad_set_id
      and setor.cad_uni_id_unidade=uni.cad_uni_id_unidade
      and ats.cad_set_id=setorproced.cad_set_id
      and prd.cad_prd_id=ats.cad_prd_id
      and pla.cad_cnv_id_convenio=cnv.cad_cnv_id_convenio
      and pla.cad_pla_id_plano=pac.cad_pla_id_plano
      and ats.ats_ate_id= apl.ats_ate_id 
      and ats.aux_epp_cd_especproc=apl.aux_epp_cd_especproc 
      and ats.ats_ate_in_intlib=apl.ats_ate_in_intlib 
      and ats.ats_ate_cd_intlib=apl.ats_ate_cd_intlib
      and ats.cad_prd_id=apl.cad_prd_id   
       and ats.ats_ate_atu_interf_legado is null         
       and ats.ats_ate_fl_status ='A'  
        AND NOT EXISTS(SELECT A.CODEXA,A.CODUNISAD,A.CODMNE,A.CODATE
         from SADT_INTERF_FATURAMENTO A  
         where A.CODEXA=ats.ats_ate_id
          and a.codunisad=prd.cad_prd_tp_produto
          and a.codmne=prd.cad_prd_nm_mnemonico 
          and a.codate=ats.ats_ate_cd_intlib)) 
    LOOP
      BEGIN  
      INSERT INTO hospital.SADT_INTERF_FATURAMENTO
		 ( CODEXA,  
       CODMNE,
		   CODUNISAD,   
        ACAO,
		   STATUS, 
       TIPLDO,
		   CODUNIHOS,
       CODMNE_SEG,
       DT_ENTRADA,
		   CODATE )
		 VALUES
		 ( atsinterf.v_nr_codexa,
        trim(atsinterf.v_mne),
		    trim(atsinterf.v_codunisad), 
        'INS',
		     'A' ,
         'N',
		     atsinterf.v_nr_codunihos,
       trim(atsinterf.v_mne), 
         SYSDATE,
		     atsinterf.v_nr_codateamb);    
   UPDATE tb_ats_ate_atendimento_sadt  
     SET ats_ate_atu_interf_legado = 'S'
     WHERE ats_ate_id = atsinterf.v_nr_codexa 
     AND  ats_ate_dt_realiz_proced = atsinterf.v_dt_dtexa
     AND ats_ate_cd_intlib = atsinterf.v_nr_codateamb
     AND CAD_PRD_ID = atsinterf.v_idproduto
     AND  aux_epp_cd_especproc = atsinterf.v_esp
     AND  ats_ate_hr_realiz_proced = atsinterf.v_hor 
     AND   ats_ate_in_intlib = atsinterf.v_intlib;           
   EXCEPTION
     WHEN DUP_VAL_ON_INDEX THEN
           NULL; 
  END;
  END LOOP;
     END; 
  commit;
end PRC_LEG_ATU_SADT;
/
