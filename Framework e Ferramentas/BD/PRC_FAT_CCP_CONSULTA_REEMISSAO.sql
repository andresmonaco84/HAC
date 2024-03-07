CREATE OR REPLACE PROCEDURE PRC_FAT_CCP_CONSULTA_REEMISSAO
(
  pATD_ATE_ID          IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE,
  pCAD_PAC_ID_PACIENTE IN TB_FAT_CCP_CONTA_CONS_PARC.CAD_PAC_ID_PACIENTE%TYPE,
  pFAT_CCP_ID          IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ID%TYPE,
  
 
  IO_CURSOR            OUT PKG_CURSOR.T_CURSOR
)
  IS

/* Marcus Relva - Obter dados para reemissao pela tela de auditoria */

  V_CURSOR PKG_CURSOR.T_CURSOR;
 
BEGIN
  OPEN V_CURSOR FOR
  select ate.atd_ate_id,
       ate.atd_ate_tp_paciente,
       pes.cad_pes_nm_pessoa,
       ate.atd_ate_dt_atendimento,
       ate.atd_ate_hr_atendimento,
       ina.atd_ina_dt_alta_adm,
       ina.atd_ina_hr_alta_adm,
       ina.tis_msi_cd_motivosaidaint,
       pac.cad_pac_id_paciente,
       pac.cad_cnv_id_convenio,
       ccp.fat_ccp_id,
       ccp.fat_coc_id,
       cid.cad_cid_ds_cid10,
       pla.cad_pla_cd_tipoplano,
       cnv.cad_cnv_fl_env_envioonline,
       ate.cad_uni_id_unidade
         from tb_atd_ate_atendimento     ate,
              tb_fat_ccp_conta_cons_parc ccp,
              tb_cad_pac_paciente        pac,
              tb_cad_pes_pessoa          pes,
              tb_cad_cnv_convenio        cnv,
              tb_cad_pla_plano           pla,
              tb_atd_ina_int_alta        ina,
              tb_cad_cid_cid10           cid
where
              ccp.atd_ate_id          = ate.atd_ate_id
          and ccp.cad_pac_id_paciente = pac.cad_pac_id_paciente
          and pac.cad_pes_id_pessoa   = pes.cad_pes_id_pessoa
          and pac.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
          and pac.cad_pla_id_plano    = pla.cad_pla_id_plano
          and ate.atd_ate_id          = ina.atd_ate_id(+)
          and ate.cad_cid_cd_cid10    = cid.cad_cid_cd_cid10(+)
          and ccp.atd_ate_id          = pATD_ATE_ID
          and ccp.fat_ccp_id          = pFAT_CCP_ID
          and ccp.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE;
          
  IO_CURSOR := V_CURSOR;
END PRC_FAT_CCP_CONSULTA_REEMISSAO;
