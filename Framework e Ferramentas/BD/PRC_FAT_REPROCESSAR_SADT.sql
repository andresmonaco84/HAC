CREATE OR REPLACE PROCEDURE "PRC_FAT_REPROCESSAR_SADT" (
   pATS_APL_ID             in TB_ATS_APL_ATEN_PROCED_LAUDO.ATS_APL_ID%TYPE,
   pATS_ATE_CD_INTLIB      in TB_ATS_APL_ATEN_PROCED_LAUDO.ATS_ATE_CD_INTLIB%TYPE
)
IS
USUARIO_INTERFACE      constant number := 8087; 
BEGIN  
/* ATUALIZAR COMO NAO PROCESSADOS OS LAUDOS */
update tb_ats_apl_aten_proced_laudo apl
set apl.ats_ate_fl_atualizado_lancam = 'N'
where (apl.ats_apl_id, apl.ats_ate_id, apl.ats_ate_cd_intlib, apl.aux_epp_cd_especproc, apl.cad_prd_id) 
in 
     (
      select apl.ats_apl_id, apl.ats_ate_id, apl.ats_ate_cd_intlib, apl.aux_epp_cd_especproc, apl.cad_prd_id
          from tb_ats_apl_aten_proced_laudo apl,
               tb_ats_ate_atendimento_sadt ats,
               (select cci.ats_apl_id, cci.atd_ate_id, cci.fat_ccp_id from tb_fat_cci_conta_consu_item cci
                        where  cci.atd_ate_id = pATS_ATE_CD_INTLIB
                        and   cci.fat_cci_fl_status = 'A'
                        and   cci.ats_apl_id is not null
                        and   cci.seg_usu_id_usuario = USUARIO_INTERFACE
                        and   cci.cad_tap_tp_atributo in ('EXA','HM')                      
                ) itens
               where ats.ats_ate_id           = apl.ats_ate_id
               and   ats.ats_ate_cd_intlib    = apl.ats_ate_cd_intlib
               and   ats.ats_ate_in_intlib    = apl.ats_ate_in_intlib
               and   ats.aux_epp_cd_especproc = apl.aux_epp_cd_especproc
               and   ats.cad_prd_id           = apl.cad_prd_id
               and   apl.ats_apl_id           = itens.ats_apl_id(+)
               and   apl.ats_ate_cd_intlib    = itens.atd_ate_id(+)
               and   itens.fat_ccp_id is null
               and   (apl.ats_ate_id, ats.ats_ate_dt_realiz_proced) in
                       (select  apl.ats_ate_id, ats.ats_ate_dt_realiz_proced
                          from tb_ats_apl_aten_proced_laudo apl,
                               tb_ats_ate_atendimento_sadt ats
                           where ats.ats_ate_id           = apl.ats_ate_id
                           and   ats.ats_ate_cd_intlib    = apl.ats_ate_cd_intlib
                           and   ats.ats_ate_in_intlib    = apl.ats_ate_in_intlib
                           and   ats.aux_epp_cd_especproc = apl.aux_epp_cd_especproc
                           and   ats.cad_prd_id           = apl.cad_prd_id
                           and apl.ats_ate_cd_intlib = pATS_ATE_CD_INTLIB
                           and apl.ats_apl_id = pATS_APL_ID)
      );

/* REMOVER AUTORIZACAO DOS ITENS */			
update tb_ass_pap_pac_aten_proc pap
   set pap.fat_cci_id = null
 where pap.fat_cci_id in
       (select cci.fat_cci_id
          from tb_fat_cci_conta_consu_item cci
         where cci.ats_apl_id in
               (select apl.ats_apl_id
                  from tb_ats_apl_aten_proced_laudo apl,
                       tb_ats_ate_atendimento_sadt  ats
                 where ats.ats_ate_id = apl.ats_ate_id
                   and ats.ats_ate_cd_intlib = apl.ats_ate_cd_intlib
                   and ats.ats_ate_in_intlib = apl.ats_ate_in_intlib
                   and ats.aux_epp_cd_especproc = apl.aux_epp_cd_especproc
                   and ats.aux_epp_cd_especproc = apl.aux_epp_cd_especproc
                   and ats.cad_prd_id = apl.cad_prd_id
                   and (apl.ats_ate_id, ats.ats_ate_dt_realiz_proced) in
                       (select apl.ats_ate_id, ats.ats_ate_dt_realiz_proced
                          from tb_ats_apl_aten_proced_laudo apl,
                               tb_ats_ate_atendimento_sadt  ats
                         where ats.ats_ate_id = apl.ats_ate_id
                           and ats.ats_ate_cd_intlib = apl.ats_ate_cd_intlib
                           and ats.ats_ate_in_intlib = apl.ats_ate_in_intlib
                           and ats.aux_epp_cd_especproc =
                               apl.aux_epp_cd_especproc
                           and ats.cad_prd_id = apl.cad_prd_id
                           and apl.ats_ate_cd_intlib = pATS_ATE_CD_INTLIB
                           and apl.ats_apl_id = pATS_APL_ID))
           and cci.atd_ate_id = pATS_ATE_CD_INTLIB
           and cci.seg_usu_id_usuario = USUARIO_INTERFACE
           and cci.fat_ccp_id is null);
			
/* APAGAR CONSUMO DOS EXAMES ASSOCIADOS */      
delete tb_fat_cci_conta_consu_item cci
 where cci.ats_apl_id in
         (select apl.ats_apl_id
            from tb_ats_apl_aten_proced_laudo apl,
                 tb_ats_ate_atendimento_sadt ats
                 where ats.ats_ate_id           = apl.ats_ate_id
                 and   ats.ats_ate_cd_intlib    = apl.ats_ate_cd_intlib
                 and   ats.ats_ate_in_intlib    = apl.ats_ate_in_intlib
                 and   ats.aux_epp_cd_especproc = apl.aux_epp_cd_especproc
                 and   ats.aux_epp_cd_especproc = apl.aux_epp_cd_especproc
                 and   ats.cad_prd_id           = apl.cad_prd_id
                 and   (apl.ats_ate_id, ats.ats_ate_dt_realiz_proced) in
                         (select  apl.ats_ate_id, ats.ats_ate_dt_realiz_proced
                            from tb_ats_apl_aten_proced_laudo apl,
                                 tb_ats_ate_atendimento_sadt ats
                             where ats.ats_ate_id           = apl.ats_ate_id
                             and   ats.ats_ate_cd_intlib    = apl.ats_ate_cd_intlib
                             and   ats.ats_ate_in_intlib    = apl.ats_ate_in_intlib
                             and   ats.aux_epp_cd_especproc = apl.aux_epp_cd_especproc
                             and   ats.cad_prd_id           = apl.cad_prd_id
                             and apl.ats_ate_cd_intlib = pATS_ATE_CD_INTLIB
                             and apl.ats_apl_id = pATS_APL_ID))
   and cci.atd_ate_id = pATS_ATE_CD_INTLIB
   and cci.seg_usu_id_usuario = USUARIO_INTERFACE
   and cci.fat_ccp_id is null;    
/* ATUALIZAR AS COMANDAS DA INTERFACE DE SADT IMAGEM */     
for comanda in (select mcc.fat_mcc_id from tb_fat_mcc_mov_com_consumo mcc
                       where mcc.atd_ate_id = pATS_ATE_CD_INTLIB
                       and   mcc.seg_usu_id_usuario = USUARIO_INTERFACE) loop
    prc_fat_mcc_atualizar_vl_total(comanda.fat_mcc_id);
end loop;                   
END PRC_FAT_REPROCESSAR_SADT;
 