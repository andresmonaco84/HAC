CREATE OR REPLACE PROCEDURE SGS."PRC_FAT_REL_CAPA_LOTE"(pLOTE       IN TB_FAT_FCL_CONTR_EMI_LOTE.FAT_FCL_NR_SEQ_LOTE%TYPE default null,
                                                        pFAT_LNF_ID IN TB_FAT_LNF_LOTE_CTA_PARC_NF.FAT_LNF_ID%TYPE,
                                                        io_cursor   OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  * 18/06/2014 - Marcus Relva - Retirado JOIN com a CCI
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
begin

  if (pLOTE is null or pLOTE = '' or pLOTE = '0' or pLOTE = 0) then
  
    OPEN v_cursor FOR
      select atd.atd_ate_id,
             pac.cad_pac_id_paciente,
             case
               when atd.atd_ate_tp_paciente not in ('I') then
                to_char(atd.atd_ate_dt_atendimento, 'DD/MM/YYYY')
               else
                to_char(ccp.fat_ccp_dt_parcela_ini, 'DD/MM/YYYY')
             end atd_ate_dt_atendimento,             
             to_char(ccp.fat_ccp_dt_parcela, 'DD/MM/YYYY') atd_ina_dt_alta_clinica,
             atd.atd_ate_tp_paciente,
             coc.fat_coc_id,
             ccp.fat_ccp_id,
             to_char(coc.fat_coc_id) || '-' || to_char(ccp.fat_ccp_id) conta_parcela,
             ccp.fat_ccp_dt_faturamento,
             lnf.fat_lnf_dt_emissao,
             lnf.fat_lnf_hr_emissao,
             ccp.fat_lnf_id,
             gui.atd_gui_cd_codigo,
             gui.atd_gui_cd_senha,
             uni.cad_uni_ds_unidade,
             ccp.fat_ccp_mes_compet,
             ccp.fat_ccp_ano_compet,
             pac.cad_pac_cd_credencial,
             pac.cad_pac_nr_prontuario,
             pes.cad_pes_nm_pessoa paciente,
             decode(aic.atd_aic_tp_situacao_pac,
                    'I',
                    'INTERNADO',
                    'A',
                    'ALTA') atd_aic_tp_situacao_pac,
             cnv.cad_cnv_id_convenio,
             cnv.cad_cnv_cd_hac_prestador,
             cnv.cad_cnv_nm_fantasia,
             pla.cad_pla_cd_plano_hac,
             pla.cad_pla_nm_nome_plano,
             case
               when pla.cad_pla_cd_tipoplano in ('GB', 'PL') then
                'ACS'
               else
                pla.cad_pla_cd_tipoplano
             end cad_pla_cd_tipoplano,
             ccp.fat_ccp_vl_tot_conta,
             lnf.fat_lnf_vl_faturado,
             lnf.fat_lnf_id as fat_fcl_nr_seq_lote,
             0 as fat_fcl_nr_seq_imprime,
             ccp.fat_ccp_mes_fat,
             ccp.fat_ccp_ano_fat,
             nof.fat_nof_nr_notafiscal,
             nof.fat_nof_tp_seriefiscal
        from tb_fat_lnf_lote_cta_parc_nf lnf
        join tb_fat_ccp_conta_cons_parc ccp
          on ccp.fat_lnf_id = lnf.fat_lnf_id
        join tb_atd_ate_atendimento atd
          on atd.atd_ate_id = ccp.atd_ate_id
        join tb_fat_coc_conta_consumo coc
          on coc.atd_ate_id = ccp.atd_ate_id
         and coc.fat_coc_id = ccp.fat_coc_id
         and coc.cad_pac_id_paciente = ccp.cad_pac_id_paciente
        join tb_cad_pac_paciente pac
          on pac.cad_pac_id_paciente = ccp.cad_pac_id_paciente
        join tb_cad_pes_pessoa pes
          on pes.cad_pes_id_pessoa = pac.cad_pes_id_pessoa
        join tb_cad_cnv_convenio cnv
          on cnv.cad_cnv_id_convenio = pac.cad_cnv_id_convenio
        join tb_cad_pla_plano pla
          on pla.cad_pla_id_plano = pac.cad_pla_id_plano
        join tb_cad_pes_pessoa pes_cnv
          on pes_cnv.cad_pes_id_pessoa = cnv.cad_pes_id_pessoa
        left join tb_atd_aic_ate_int_compl aic
          on aic.atd_ate_id = atd.atd_ate_id
        left join tb_atd_ina_int_alta ina
          on ina.atd_ate_id = atd.atd_ate_id
        left join tb_atd_gui_guiaatend gui
          on gui.atd_ate_id = ccp.atd_ate_id
         and case
               when gui.cad_pac_id_paciente is not null then
                ccp.cad_pac_id_paciente
               else
                null
             end = gui.cad_pac_id_paciente
         and gui.atd_gui_fl_guiaprinc_ok = 'S'
        join tb_cad_uni_unidade uni
          on uni.cad_uni_id_unidade = atd.cad_uni_id_unidade
        left join tb_fat_nof_nota_fiscal nof
          on nof.fat_nof_id = ccp.fat_nof_id
       where (lnf.fat_lnf_id = pFAT_LNF_ID)
       group by atd.atd_ate_id,
                pac.cad_pac_id_paciente,
                case
                when atd.atd_ate_tp_paciente not in ('I') then
                to_char(atd.atd_ate_dt_atendimento, 'DD/MM/YYYY')
                else
                to_char(ccp.fat_ccp_dt_parcela_ini, 'DD/MM/YYYY')
                end,
                to_char(ccp.fat_ccp_dt_parcela, 'DD/MM/YYYY'),
                atd.atd_ate_tp_paciente,
                coc.fat_coc_id,
                ccp.fat_ccp_id,
                to_char(coc.fat_coc_id) || '-' || to_char(ccp.fat_ccp_id),
                ccp.fat_ccp_dt_faturamento,
                lnf.fat_lnf_dt_emissao,
                lnf.fat_lnf_hr_emissao,
                ccp.fat_lnf_id,
                gui.atd_gui_cd_codigo,
                gui.atd_gui_cd_senha,
                uni.cad_uni_ds_unidade,
                ccp.fat_ccp_mes_compet,
                ccp.fat_ccp_ano_compet,
                pac.cad_pac_cd_credencial,
                pac.cad_pac_nr_prontuario,
                pes.cad_pes_nm_pessoa,
                decode(aic.atd_aic_tp_situacao_pac,
                       'I',
                       'INTERNADO',
                       'A',
                       'ALTA'),
                cnv.cad_cnv_id_convenio,
                cnv.cad_cnv_cd_hac_prestador,
                cnv.cad_cnv_nm_fantasia,
                pla.cad_pla_cd_plano_hac,
                pla.cad_pla_nm_nome_plano,
                case
                  when pla.cad_pla_cd_tipoplano in ('GB', 'PL') then
                   'ACS'
                  else
                   pla.cad_pla_cd_tipoplano
                end,
                ccp.fat_ccp_vl_tot_conta,
                lnf.fat_lnf_vl_faturado,
                lnf.fat_lnf_id,
                ccp.fat_ccp_mes_fat,
                ccp.fat_ccp_ano_fat,
                nof.fat_nof_nr_notafiscal,
                nof.fat_nof_tp_seriefiscal
       order by pes.cad_pes_nm_pessoa;
  
  else
    OPEN v_cursor FOR
      SELECT ATD.ATD_ATE_ID,
             PAC.CAD_PAC_ID_PACIENTE,
             case
               when atd.atd_ate_tp_paciente not in ('I') then
                to_char(atd.atd_ate_dt_atendimento, 'DD/MM/YYYY')
               else
                to_char(ccp.fat_ccp_dt_parcela_ini, 'DD/MM/YYYY')
             end atd_ate_dt_atendimento,             
             to_char(ccp.fat_ccp_dt_parcela, 'DD/MM/YYYY') atd_ina_dt_alta_clinica,
             ATD.ATD_ATE_TP_PACIENTE,
             COC.FAT_COC_ID,
             CCP.FAT_CCP_ID,
             to_char(COC.FAT_COC_ID) || '-' || to_char(CCP.FAT_CCP_ID) conta_parcela,
             CCP.FAT_CCP_DT_FATURAMENTO,
             LNF.FAT_LNF_DT_EMISSAO,
             LNF.FAT_LNF_HR_EMISSAO,
             CCP.FAT_LNF_ID,
             GUI.ATD_GUI_CD_CODIGO,
             GUI.ATD_GUI_CD_SENHA,
             UNI.CAD_UNI_DS_UNIDADE,
             CCP.FAT_CCP_MES_COMPET,
             CCP.FAT_CCP_ANO_COMPET,
             PAC.CAD_PAC_CD_CREDENCIAL,
             PAC.CAD_PAC_NR_PRONTUARIO,
             PES.CAD_PES_NM_PESSOA PACIENTE,
             DECODE(AIC.ATD_AIC_TP_SITUACAO_PAC,
                    'I',
                    'INTERNADO',
                    'A',
                    'ALTA') ATD_AIC_TP_SITUACAO_PAC,
             CNV.CAD_CNV_ID_CONVENIO,
             CNV.CAD_CNV_CD_HAC_PRESTADOR,
             CNV.CAD_CNV_NM_FANTASIA,
             PLA.CAD_PLA_CD_PLANO_HAC,
             PLA.CAD_PLA_NM_NOME_PLANO,
             CASE
               WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB', 'PL') THEN
                'ACS'
               ELSE
                PLA.CAD_PLA_CD_TIPOPLANO
             END CAD_PLA_CD_TIPOPLANO,
             CCP.FAT_CCP_VL_TOT_CONTA,
             LNF.FAT_LNF_VL_FATURADO,
             FCL.FAT_FCL_NR_SEQ_LOTE,
             FCL.FAT_FCL_NR_SEQ_IMPRIME,
             CCP.FAT_CCP_MES_FAT,
             CCP.FAT_CCP_ANO_FAT,
             NOF.FAT_NOF_NR_NOTAFISCAL,
             NOF.FAT_NOF_TP_SERIEFISCAL
        FROM TB_FAT_LNF_LOTE_CTA_PARC_NF LNF
        JOIN TB_FAT_CCP_CONTA_CONS_PARC CCP
          ON CCP.FAT_LNF_ID = LNF.FAT_LNF_ID
        JOIN TB_ATD_ATE_ATENDIMENTO ATD
          ON ATD.ATD_ATE_ID = CCP.ATD_ATE_ID
        JOIN TB_FAT_COC_CONTA_CONSUMO COC
          ON COC.ATD_ATE_ID = CCP.ATD_ATE_ID
         AND COC.FAT_COC_ID = CCP.FAT_COC_ID
         AND COC.CAD_PAC_ID_PACIENTE = CCP.CAD_PAC_ID_PACIENTE
        JOIN TB_CAD_PAC_PACIENTE PAC
          ON PAC.CAD_PAC_ID_PACIENTE = CCP.CAD_PAC_ID_PACIENTE
        JOIN TB_CAD_PES_PESSOA PES
          ON PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA
        JOIN TB_CAD_CNV_CONVENIO CNV
          ON CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
        JOIN TB_CAD_PLA_PLANO PLA
          ON PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
        JOIN TB_CAD_PES_PESSOA PES_CNV
          ON PES_CNV.CAD_PES_ID_PESSOA = CNV.CAD_PES_ID_PESSOA
        LEFT JOIN TB_ATD_AIC_ATE_INT_COMPL AIC
          ON AIC.ATD_ATE_ID = ATD.ATD_ATE_ID
        LEFT JOIN TB_ATD_INA_INT_ALTA INA
          ON INA.ATD_ATE_ID = ATD.ATD_ATE_ID
        LEFT JOIN TB_ATD_GUI_GUIAATEND GUI
          ON GUI.ATD_ATE_ID = CCP.ATD_ATE_ID
         and case
               when gui.cad_pac_id_paciente IS NOT NULL then
                ccp.cad_pac_id_paciente
               else
                null
             end = gui.cad_pac_id_paciente
         AND GUI.ATD_GUI_FL_GUIAPRINC_OK = 'S'
        JOIN TB_CAD_UNI_UNIDADE UNI
          ON UNI.CAD_UNI_ID_UNIDADE = ATD.CAD_UNI_ID_UNIDADE
        LEFT JOIN TB_FAT_NOF_NOTA_FISCAL NOF
          ON NOF.FAT_NOF_ID = CCP.FAT_NOF_ID
        JOIN TB_FAT_FCL_CONTR_EMI_LOTE FCL
          ON FCL.FAT_COC_ID = COC.FAT_COC_ID
         AND FCL.FAT_CCP_ID = CCP.FAT_CCP_ID
         AND FCL.ATD_ATE_ID = COC.ATD_ATE_ID
         AND FCL.ATD_ATE_ID = CCP.ATD_ATE_ID
         AND FCL.CAD_PAC_ID_PACIENTE = CCP.CAD_PAC_ID_PACIENTE
         AND FCL.CAD_PAC_ID_PACIENTE = COC.CAD_PAC_ID_PACIENTE
       WHERE (FCL.FAT_FCL_NR_SEQ_LOTE = pLOTE)
         and (LNF.FAT_LNF_ID = pFAT_LNF_ID)
       GROUP BY ATD.ATD_ATE_ID,
                PAC.CAD_PAC_ID_PACIENTE,
                case
                when atd.atd_ate_tp_paciente not in ('I') then
                to_char(atd.atd_ate_dt_atendimento, 'DD/MM/YYYY')
                else
                to_char(ccp.fat_ccp_dt_parcela_ini, 'DD/MM/YYYY')
                end,                
                to_char(ccp.fat_ccp_dt_parcela, 'DD/MM/YYYY'),
                ATD.ATD_ATE_TP_PACIENTE,
                COC.FAT_COC_ID,
                CCP.FAT_CCP_ID,
                to_char(COC.FAT_COC_ID) || '-' || to_char(CCP.FAT_CCP_ID),
                CCP.FAT_CCP_DT_FATURAMENTO,
                LNF.FAT_LNF_DT_EMISSAO,
                LNF.FAT_LNF_HR_EMISSAO,
                CCP.FAT_LNF_ID,
                GUI.ATD_GUI_CD_CODIGO,
                GUI.ATD_GUI_CD_SENHA,
                UNI.CAD_UNI_DS_UNIDADE,
                CCP.FAT_CCP_MES_COMPET,
                CCP.FAT_CCP_ANO_COMPET,
                PAC.CAD_PAC_CD_CREDENCIAL,
                PAC.CAD_PAC_NR_PRONTUARIO,
                PES.CAD_PES_NM_PESSOA,
                DECODE(AIC.ATD_AIC_TP_SITUACAO_PAC,
                       'I',
                       'INTERNADO',
                       'A',
                       'ALTA'),
                CNV.CAD_CNV_ID_CONVENIO,
                CNV.CAD_CNV_CD_HAC_PRESTADOR,
                CNV.CAD_CNV_NM_FANTASIA,
                PLA.CAD_PLA_CD_PLANO_HAC,
                PLA.CAD_PLA_NM_NOME_PLANO,
                CASE
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO IN ('GB', 'PL') THEN
                   'ACS'
                  ELSE
                   PLA.CAD_PLA_CD_TIPOPLANO
                END,
                CCP.FAT_CCP_VL_TOT_CONTA,
                LNF.FAT_LNF_VL_FATURADO,
                FCL.FAT_FCL_NR_SEQ_LOTE,
                FCL.FAT_FCL_NR_SEQ_IMPRIME,
                CCP.FAT_CCP_MES_FAT,
                CCP.FAT_CCP_ANO_FAT,
                NOF.FAT_NOF_NR_NOTAFISCAL,
                NOF.FAT_NOF_TP_SERIEFISCAL
       ORDER BY FCL.FAT_FCL_NR_SEQ_IMPRIME ASC;
  
  end if;

  io_cursor := v_cursor;
end PRC_FAT_REL_CAPA_LOTE;
