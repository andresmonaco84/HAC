CREATE OR REPLACE PROCEDURE PRC_FAT_CCI_TELA_CONSUMO_L(pATD_ATE_ID          IN TB_FAT_CCI_CONTA_CONSU_ITEM.ATD_ATE_ID%type,
                                                       pFAT_MCC_ID          IN TB_FAT_CCI_CONTA_CONSU_ITEM.FAT_MCC_ID%type DEFAULT NULL,
                                                       pFAT_TCO_ID          IN TB_FAT_MCC_MOV_COM_CONSUMO.FAT_TCO_ID%type DEFAULT NULL,
                                                       pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
                                                       pFAT_CCP_ID          IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ID%TYPE DEFAULT NULL,
                                                       pFAT_CCI_FL_FATURADO IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_FL_FATURADA%TYPE,
                                                       io_cursor            OUT PKG_CURSOR.t_cursor) is
  /*********************************************************************************
  *    Procedure: PRC_FAT_CCI_TELA_CONSUMO_L
  * 
  *    Data Criacao:   12/07/2010   Por: Marcus Relva
  * 
  *    Alterac?o - 13/07/2010 - Caio - Inclus?o de novos filtros convenio e parcela
  *
  *    Alterac?o - 21/10/2010 - Davi S. M. dos Reis - Inclus?o do campo (fat_cci_fl_kitpra)
  *
  *    Alterac?o - 25/07/2014 - André - Alteração de descrição de FlagPendenteAutorizacao
  * 
  *    Funcao: Carregar os itens para tela de consumo
  *
  **********************************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
    select cci.fat_cci_id,
           cci.fat_mcc_id,
           cci.fat_ccp_id,
           cci.fat_coc_id,
           cci.cad_tap_tp_atributo,
           cci.cad_prd_id,
           cci.cad_tih_tp_indice_hosp,
           cci.fat_cci_qt_indice,
           cci.fat_cci_vl_indice,
           cci.fat_cci_vl_produto,
           cci.fat_cci_vl_unitario,
           cci.fat_cci_dt_inicio_consumo,
           cci.fat_cci_hr_inicio_consumo,
           cci.fat_cci_dt_fim_consumo,
           cci.fat_cci_hr_fim_consumo,
           cci.fat_cci_vl_faturado,
           cci.fat_cci_qt_consumo,
           cci.fat_cci_pc_acrescimo,
           cci.fat_cci_pc_desconto,
           cci.fat_cci_tp_destino_item,
           cci.cad_pro_id_profissional,
           cci.tis_gpp_cd_grau_part_prof,
           cci.fat_cci_pc_grau_part_prof,
           cci.tis_tva_cd_viaacesso,
           cci.tis_ttp_cd_tptecnica,
           cci.fat_cci_fl_simultanea,
           cci.fat_cci_fl_bilateral,
           cci.fat_cci_vl_customedio,
           cci.fat_cci_fl_fracionado,
           cci.fat_cci_qt_fracionada,
           cci.fat_cci_pc_doppler,
           cci.tis_cpr_cd_conselhoprof,
           cci.cad_pso_cd_conselho,
           cci.cad_pso_sg_uf_conselho,
           cci.fat_fl_proced_principal,
           cci.fat_fl_pendente_autoriza,
           cci.fat_cci_fl_utilizavideo,
           cci.fat_cci_fl_status,
           cci.fat_cci_tp_porteanestesico,
           cci.fat_cci_vl_porteanestesico,
           cci.seg_usu_id_usuario,
           cci.fat_cci_dt_ultima_atualizacao,
           cci.fat_cci_qt_m2filme,
           cci.fat_cci_vl_m2filme,
           cci.fat_cci_vl_calculado,
           cci.fat_cci_pc_horario,
           cci.fat_cci_cd_guia,
           cci.fat_cci_cd_senha,
           cci.cad_mpf_id,
           cci.cad_apm_id_matmed,
           cci.fat_cci_vl_matmed_fabrica,
           cci.atd_ate_id,
           cci.cad_umc_cd_medida_consumo,
           cci.cad_nfm_id,
           cci.ass_usc_id,
           cci.cad_maa_id,
           cci.cad_pac_id_paciente,
           cci.fat_cci_tp_credencia_prof,
           cci.fat_cci_cd_clinica_prof,
           cci.ats_apl_id,
           cci.fat_cci_fl_equipe_diferente,
           cci.fat_cci_pc_acomodacao_hm,
           cci.fat_cci_id_principal,
           cci.fat_cci_fl_pacote,
           cci.fat_cci_pc_tabela_acrescimo,
           cci.fat_cci_pc_tabela_desconto,
           cci.fat_cci_vl_pre_calculado,
           cci.cad_cac_id_classcontabil,
           cci.cad_cec_id_ccusto,
           cci.fat_cci_qt_cons_ant,
           cci.fat_cci_qt_cons_aud,
           cci.fat_cci_vl_unitario_ant,
           cci.fat_cci_vl_unitario_aud,
           cci.cad_prd_id_cobrado,
           cci.fat_cci_vl_desconto,
           cci.fat_cci_vl_acrescimo,
           cci.fat_cci_mes_fechamento,
           cci.fat_cci_ano_fechamento,
           cci.SEG_USU_ID_USUARIO_CRIACAO,
           cci.FAT_CCI_DT_CRIACAO,
           cci.FAT_CCI_FL_IMPORTADO_REPASSE,
           cci.CAD_UNI_ID_UNIDADE,
           cci.CAD_LAT_ID_LOCAL_ATENDIMENTO,
           cci.ATD_ATE_TP_PACIENTE,
           cci.CAD_CNV_ID_CONVENIO,
           cci.CAD_CLC_ID,
           decode(cci.fat_cci_fl_status, 'A', 'Ativo', 'C', 'Cancelado') as DescricaoStatus,
           fnc_juntar_data_hora(cci.fat_cci_dt_inicio_consumo,
                                cci.fat_cci_hr_inicio_consumo) as DataHoraConsumo,
           decode(cci.cad_mpf_id, NULL, '0', '1') as FlagMotivoPendencia,
           decode(cci.fat_cci_tp_destino_item,
                  'C',
                  'CONV',
                  'H',
                  'HOSP',
                  'P',
                  'PART',
                  'T',
                  'PCTE') || '/' || cnv.cad_cnv_cd_hac_prestador || '/' ||
           pla.cad_pla_cd_plano_hac || '/' || pac.cad_pac_cd_credencial as DescricaoFontePagadora,
           prd.cad_prd_fl_contrastado as FlagContrastado,
           decode(cci.fat_fl_pendente_autoriza,
                  'A',
                  'Autorizado',
                  'N',
                  'Não Autorizado',
                  'P',
                  'Pendente',
                  '') as FlagPendenteAutorizacao,
           pro.cad_pro_cd_cod_pro as CodigoCRMProfissional,
           ccp.fat_ccp_fl_faturada as FlagFaturado,
           cci.fat_cci_fl_kitpra,
           prd.cad_prd_cd_codigo,
           prd.cad_prd_ds_descricao,
           tap.cad_tap_ds_atributo,
           maa.cad_maa_ds_descricao,
           cac.cad_cac_ds_classcontabil,
           cec.cad_cec_ds_ccusto,
           gpp.tis_gpp_ds_grau_part_prof,
           null as DescricaoCredenciamento,
           upper(clc.cad_clc_ds_descricao) as DescricaoClinica,
           seg.seg_usu_ds_login,
           ccp.fat_ccp_ano_fat,
           ccp.fat_ccp_mes_fat,
           mpf.cad_mpf_fl_motivo,
           mpf.cad_mpf_ds_moti_pend_faturar,
           cci.CAD_CPR_TP_CREDENCIA_PROF,
           ccp.fat_ccp_fl_faturada,
           cci.fat_cci_nr_aut_func_emp_nf,
           cci.tis_cbo_cd_cbos,
           cci.FAT_CCI_PC_MED_RESTRITO,
           seg_c.seg_usu_ds_login as SEG_USU_DS_LOGIN_C,
           apm.cad_apm_ds_produto,
           cci.fat_cci_nr_aut_func_emp_nf,
           
           pes_sol.cad_pes_nm_pessoa   as nome_sol,
           pes_exe.cad_pes_nm_pessoa   as nome_exe,
           pro.tis_cpr_cd_conselhoprof as conselho_exe,
           pro.cad_pro_nr_conselho,
           pro.cad_pro_sg_uf_conselho,
           sol.tis_cpr_cd_conselhoprof,
           cci.cad_pso_cd_conselho,
           cci.cad_pso_sg_uf_conselho
    
      from tb_fat_mcc_mov_com_consumo     mcc,
           tb_fat_cci_conta_consu_item    cci,
           tb_atd_ate_atendimento         ate,
           tb_cad_prd_produto             prd,
           tb_cad_tap_tp_atrib_produto    tap,
           tb_seg_usu_usuario             seg,
           tb_seg_usu_usuario             seg_c,
           tb_cad_mpf_moti_pend_faturar   mpf,
           tb_cad_pac_paciente            pac,
           tb_cad_cnv_convenio            cnv,
           tb_cad_pla_plano               pla,
           tb_ats_apl_aten_proced_laudo   apl,
           tb_cad_pro_profissional        pro,
           tb_cad_maa_moti_altera_audit   maa,
           tb_cad_cec_centro_custo        cec,
           tb_cad_cac_classif_contab      cac,
           tb_tis_gpp_grau_part_prof      gpp,
           tb_cad_clc_clinica_credenciada clc,
           tb_fat_ccp_conta_cons_parc     ccp,
           tb_cad_apm_apres_pro_matmed    apm,
           tb_cad_pro_profissional        sol,
           tb_cad_pes_pessoa              pes_exe,
           tb_cad_pes_pessoa              pes_sol
     where cci.fat_mcc_id = mcc.fat_mcc_id
       and cci.atd_ate_id = ate.atd_ate_id
       and cci.cad_prd_id = prd.cad_prd_id
       and cci.cad_tap_tp_atributo = tap.cad_tap_tp_atributo
       and cci.seg_usu_id_usuario = seg.seg_usu_id_usuario
       and cci.seg_usu_id_usuario = seg_c.seg_usu_id_usuario
       and cci.cad_pac_id_paciente = pac.cad_pac_id_paciente
       and pac.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
       and pac.cad_pla_id_plano = pla.cad_pla_id_plano
       and cci.cad_apm_id_matmed = apm.cad_apm_id_matmed(+)
       and cci.cad_mpf_id = mpf.cad_mpf_id(+)
       and cci.ats_apl_id = apl.ats_apl_id(+)
       and cci.cad_pro_id_profissional = pro.cad_pro_id_profissional(+)
       and pro.cad_pes_id_pessoa = pes_exe.cad_pes_id_pessoa(+)
       and cci.tis_cpr_cd_conselhoprof = sol.tis_cpr_cd_conselhoprof(+)
       and cci.cad_pso_cd_conselho = sol.cad_pro_nr_conselho(+)
       and cci.cad_pso_sg_uf_conselho = sol.cad_pro_sg_uf_conselho(+)
       and sol.cad_pes_id_pessoa = pes_sol.cad_pes_id_pessoa(+)
       and cci.cad_maa_id = maa.cad_maa_id(+)
       and cci.cad_cec_id_ccusto = cec.cad_cec_id_ccusto(+)
       and cci.cad_cac_id_classcontabil = cac.cad_cac_id_classcontabil(+)
       and cci.tis_gpp_cd_grau_part_prof = gpp.tis_gpp_cd_grau_part_prof(+)
          --   and cci.fat_cci_cd_clinica_prof = rep_clinicas.cd_clinica(+)   
       and cci.atd_ate_id = ccp.atd_ate_id(+)
       and cci.cad_pac_id_paciente = ccp.cad_pac_id_paciente(+)
       and cci.fat_ccp_id = ccp.fat_ccp_id(+)
       and cci.cad_clc_id = clc.cad_clc_id(+)
       and (pFAT_MCC_ID is null or mcc.fat_mcc_id = pFAT_MCC_ID)
       and (pFAT_TCO_ID is null or mcc.fat_tco_id = pFAT_TCO_ID)
       and (pCAD_CNV_ID_CONVENIO is null or
           pac.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO)
       and (pFAT_CCP_ID is null or cci.fat_ccp_id = pFAT_CCP_ID)
          /*
          pFAT_CCI_FL_FATURADO null  - tudo
          pFAT_CCI_FL_FATURADO = "N" - não faturados (com e sem parcela)
          pFAT_CCI_FL_FATURADO = "S" - sem parcela
          */
       and (pFAT_CCI_FL_FATURADO is null or
           (pFAT_CCI_FL_FATURADO = 'N' and
           (CCP.FAT_CCP_FL_FATURADA = 'N' or
           CCP.FAT_CCP_FL_FATURADA is null)) or
           (pFAT_CCI_FL_FATURADO = 'S' and cci.fat_ccp_id is null))
       and cci.atd_ate_id = pATD_ATE_ID;
  io_cursor := v_cursor;
end PRC_FAT_CCI_TELA_CONSUMO_L;
