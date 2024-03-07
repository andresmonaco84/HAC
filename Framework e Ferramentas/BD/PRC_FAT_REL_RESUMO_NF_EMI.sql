CREATE OR REPLACE PROCEDURE "PRC_FAT_REL_RESUMO_NF_EMI"
(
    PFAT_CCP_MES_FAT IN TB_FAT_NOF_NOTA_FISCAL.FAT_NOF_MES_FAT%TYPE DEFAULT NULL,
    PFAT_CCP_ANO_FAT IN TB_FAT_NOF_NOTA_FISCAL.FAT_NOF_ANO_FAT%TYPE DEFAULT NULL,
    pATD_ATE_TP_PACIENTE_I in tb_atd_ate_atendimento.atd_ate_tp_paciente%type default null,
    pATD_ATE_TP_PACIENTE_E in tb_atd_ate_atendimento.atd_ate_tp_paciente%type default null,
    pATD_ATE_TP_PACIENTE_A in tb_atd_ate_atendimento.atd_ate_tp_paciente%type default null,
    pATD_ATE_TP_PACIENTE_U in tb_atd_ate_atendimento.atd_ate_tp_paciente%type default null,

    io_cursor OUT PKG_CURSOR.t_cursor
)
IS
/********************************************************************
*    Procedure: PRC_FAT_REL_RESUMO_NF_EMI
*
*    Data Criação: 16/04/2012  Por: Eduardo
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
BEGIN
  OPEN v_cursor FOR
select
 tipopac.tipo_paciente ,
  uni.cad_uni_ds_unidade,
  mun.aux_mun_nm_municipio,
sum (nof.fat_nof_vl_iss) Total_Iss,
sum(nof.fat_nfo_vl_faturado) Total_Fat,
sum(nof.fat_nof_vl_ir +  nof.fat_nof_vl_cofins + nof.fat_nof_vl_pis + NOF.FAT_NOF_VL_CSLL) Retenção,
       cnv.cad_tpe_cd_codigo EMPRESA
       from tb_cad_cnv_convenio cnv,
       tb_aux_mun_municipio mun,
       tb_cad_end_endereco ende,
       tb_fat_nof_nota_fiscal nof,
       tb_cad_uni_unidade uni,
       ( select distinct ccp.fat_nof_id ,decode( CCP.Atd_Ate_Tp_Paciente,'U','Ambulatório','A','Ambulatório','Internação')
       tipo_paciente
        from
        tb_fat_ccp_conta_cons_parc ccp, TB_FAT_NOF_NOTA_FISCAL NOF
       where CCP.FAT_NOF_ID=NOF.FAT_NOF_ID
       AND NOF.FAT_NOF_MES_FAT = PFAT_CCP_MES_FAT
       AND NOF.FAT_NOF_ANO_FAT = PFAT_CCP_ANO_FAT      
       and  ( pATD_ATE_TP_PACIENTE_I IS not NULL and CCP.Atd_Ate_Tp_Paciente = 'I'
          OR  pATD_ATE_TP_PACIENTE_E IS NOT NULL AND CCP.Atd_Ate_Tp_Paciente = 'E'
          OR  pATD_ATE_TP_PACIENTE_A IS NOT NULL AND CCP.Atd_Ate_Tp_Paciente = 'A'
          OR  pATD_ATE_TP_PACIENTE_U IS NOT NULL AND CCP.Atd_Ate_Tp_Paciente = 'U')

        )  tipopac
       where
       nof.fat_nof_id   = tipopac.fat_nof_id
       and   nof.cad_cnv_id_convenio=cnv.cad_cnv_id_convenio
       and uni.cad_pes_id_pessoa=ende.cad_pes_id_pessoa
       and ende.aux_mun_cd_ibge=mun.aux_mun_cd_ibge
       and ende.aux_tte_cd_tp_tel_end = 2
       and nof.cad_uni_id_unidade=uni.cad_uni_id_unidade
       AND (NOF.FAT_NOF_MES_FAT = PFAT_CCP_MES_FAT)
      AND (NOF.FAT_NOF_ANO_FAT = PFAT_CCP_ANO_FAT)
      group by  tipopac.tipo_paciente ,
       uni.cad_uni_ds_unidade,
       mun.aux_mun_nm_municipio,
       cnv.cad_tpe_cd_codigo;


io_cursor := v_cursor;
END PRC_FAT_REL_RESUMO_NF_EMI;
 