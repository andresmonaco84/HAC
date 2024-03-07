CREATE OR REPLACE PROCEDURE "PRC_FAT_REL_CONTA"
  (
    pLOTE IN TB_FAT_FCL_CONTR_EMI_LOTE.FAT_FCL_NR_SEQ_LOTE%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
/* Marcus Relva - 16/05/2013 - Integracao com historico  */
  v_cursor PKG_CURSOR.t_cursor;
  v_select varchar2(32767);
  v_select_parte2 varchar2(32767);
  v_tabela varchar2(100);
  begin
  select case when count(1) > 0 then ' TB_FAT_CCI_CONTA_CONSU_ITEM ' else ' TB_FAT_CIH_ITEM_HISTORICO ' end as tabela 
  into v_tabela
  from tb_fat_fcl_contr_emi_lote f
join tb_fat_cci_conta_consu_item i on  f.atd_ate_id = i.atd_ate_id
                                   and f.fat_ccp_id = i.fat_ccp_id
                                   and f.cad_pac_id_paciente = i.cad_pac_id_paciente
where f.fat_fcl_nr_seq_lote = pLOTE;
  v_select := 'SELECT DISTINCT FCL.FAT_FCL_NR_SEQ_IMPRIME,
                CASE
                  WHEN CCI.CAD_TAP_TP_ATRIBUTO = ''DIA'' THEN
                   1
                  WHEN CCI.CAD_TAP_TP_ATRIBUTO = ''HM'' THEN
                   2
                  WHEN CCI.CAD_TAP_TP_ATRIBUTO = ''EXA'' THEN
                   3
                  WHEN CCI.CAD_TAP_TP_ATRIBUTO = ''TAX'' THEN
                   5
                  WHEN CCI.CAD_TAP_TP_ATRIBUTO = ''GAS'' THEN
                   6
                  WHEN CCI.CAD_TAP_TP_ATRIBUTO = ''PAC'' THEN
                   7
                END ORDEM,
                ATD.ATD_ATE_ID,
                PAC.CAD_PAC_ID_PACIENTE,
                DECODE(ATD.ATD_ATE_TP_PACIENTE,
                       ''I'',
                       ''INTERNADO'',
                       ''E'',
                       ''EXTERNO'',
                       ''A'',
                       ''AMBULATORIO'',
                       ''U'',
                       ''PRONTO SOCORRO'') ATD_ATE_TP_PACIENTE,
                DECODE(ATD.ATD_ATE_FL_CARATER_SOLIC,
                       ''U'',
                       ''URGENCIA'',
                       ''E'',
                       ''ELETIVA'') ATD_ATE_FL_CARATER_SOLIC,
                TO_CHAR(ATD.ATD_ATE_DT_ATENDIMENTO, ''DD/MM/YYYY'') ATD_ATE_DT_ATENDIMENTO,
                ATD.ATD_ATE_HR_ATENDIMENTO,
                TO_CHAR(INA.ATD_INA_DT_ALTA_CLINICA, ''DD/MM/YYYY'') ATD_INA_DT_ALTA_CLINICA,
                INA.ATD_INA_HR_ALTA_CLINICA,
                TO_CHAR(CCP.FAT_CCP_DT_PARCELA, ''DD/MM/YYYY'') FAT_CCP_DT_PARCELA,
                CCP.FAT_CCP_HR_PARCELA,
                TO_CHAR(CCP.FAT_CCP_DT_PARCELA_INI, ''DD/MM/YYYY'') FAT_CCP_DT_PARCELA_INI,
                CCP.FAT_CCP_HR_PARCELA_INI,
                COC.FAT_COC_ID,
                CCP.FAT_CCP_ID,
                to_char(COC.FAT_COC_ID) || ''-'' || to_char(CCP.FAT_CCP_ID) || ''-'' ||
                to_char(PAC.CAD_PAC_ID_PACIENTE) || to_char(ATD.ATD_ATE_ID) coc_ccp_pac_atd,
                UNI.CAD_UNI_DS_UNIDADE UNIDADE,
                UNI.CAD_UNI_NR_CNES,
                PES_UNI.CAD_PES_NR_CNPJ_CPF,
                GUI.ATD_GUI_CD_CODIGO,
                GUI.ATD_GUI_CD_SENHA,
                CCI.CAD_TAP_TP_ATRIBUTO,
                TAP.CAD_TAP_DS_ATRIBUTO,
                CCP.FAT_CCP_MES_COMPET,
                CCP.FAT_CCP_ANO_COMPET,
                CCP.FAT_CCP_MES_FAT,
                CCP.FAT_CCP_ANO_FAT,
                MSI.TIS_MSI_DS_MOTIVOSAIDAINT,
                AIC.ATD_AIC_DS_EMPRESA,
                PAC.CAD_PAC_CD_CREDENCIAL,
                PAC.CAD_PAC_NR_PRONTUARIO,
                PES.CAD_PES_NM_PESSOA PACIENTE,
                TO_CHAR(PAC.CAD_PAC_DT_VALIDADECREDENCIAL, ''DD/MM/YYYY'') CAD_PAC_DT_VALIDADECREDENCIAL,
                PES.CAD_PES_NR_RG,
                PAC.CAD_PAC_NM_TITULAR,
                DECODE(AIC.ATD_AIC_TP_SITUACAO_PAC,
                       ''I'',
                       ''INTERNADO'',
                       ''A'',
                       ''ALTA'') ATD_AIC_TP_SITUACAO_PAC,
                CNV.CAD_CNV_CD_HAC_PRESTADOR,
                CNV.CAD_CNV_NM_FANTASIA || CASE
                  WHEN CNV.CAD_CNV_ID_CONVENIO = 282 AND
                       ATD.ATD_ATE_TP_PACIENTE = ''I'' THEN
                   (select '' (DIFERENCA DE CLASSE)''
                      from tb_fat_mcc_mov_com_consumo mcc1
                      JOIN TB_FAT_TCO_TIPO_COMANDA TCO
                        ON TCO.FAT_TCO_ID = MCC1.FAT_TCO_ID
                       AND TCO.FAT_TCO_ID = 10
                     where mcc1.atd_ate_id = CCI.ATD_ATE_ID
                       AND MCC1.FAT_MCC_ID = CCI.FAT_MCC_ID
                       AND CCI.FAT_CCI_DT_INICIO_CONSUMO BETWEEN
                           TRUNC(CCP.FAT_CCP_DT_PARCELA_INI) AND
                           CCP.FAT_CCP_DT_PARCELA
                       AND ROWNUM = 1)
                  ELSE
                   ''''
                END CAD_CNV_NM_FANTASIA,
                PLA.CAD_PLA_CD_TIPOPLANO,
                PLA.CAD_PLA_CD_PLANO_HAC,
                PLA.CAD_PLA_NM_NOME_PLANO,
                CASE
                  WHEN CCI.CAD_TAP_TP_ATRIBUTO = ''HM'' THEN
                   PRO.CAD_PRO_NM_NOME
                  ELSE
                   NULL
                END PROFISSIONAL,
                CASE
                  WHEN CCI.CAD_TAP_TP_ATRIBUTO = ''HM'' THEN
                   PRO.CAD_PRO_NR_CONSELHO
                  ELSE
                   NULL
                END CAD_PRO_NR_CONSELHO,
                CASE
                  WHEN CCI.CAD_TAP_TP_ATRIBUTO = ''HM'' THEN
                   PRO.CAD_PRO_SG_UF_CONSELHO
                  ELSE
                   NULL
                END CAD_PRO_SG_UF_CONSELHO,
                CASE
                  WHEN CID_PRI.CAD_CID_DS_CID10 IS NULL THEN
                   CID_ATD.CAD_CID_DS_CID10
                  ELSE
                   CID_PRI.CAD_CID_DS_CID10
                END CID_PRINCIPAL,
                CID_SEC1.CAD_CID_DS_CID10 CID_SECUNDARIO,
                CID_SEC2.CAD_CID_DS_CID10 CID_SECUNDARIO2,
                CID_SEC3.CAD_CID_DS_CID10 CID_SECUNDARIO3,
                CID_SEC4.CAD_CID_DS_CID10 CID_SECUNDARIO4,
                CID_SEC5.CAD_CID_DS_CID10 CID_SECUNDARIO5,
                CASE
                  WHEN CID_PRI.CAD_CID_DS_CID10 IS NULL THEN
                   CID_ATD.CAD_CID_CD_CID10
                  ELSE
                   CID_PRI.CAD_CID_CD_CID10
                END CAD_CID_CD_CID10_PRI,
                CID_SEC1.CAD_CID_CD_CID10 CAD_CID_CD_CID10_1,
                CID_SEC2.CAD_CID_CD_CID10 CAD_CID_CD_CID10_2,
                CID_SEC3.CAD_CID_CD_CID10 CAD_CID_CD_CID10_3,
                CID_SEC4.CAD_CID_CD_CID10 CAD_CID_CD_CID10_4,
                CID_SEC5.CAD_CID_CD_CID10 CAD_CID_CD_CID10_5,
                TIN.TIS_TIN_DS_INTERNACAO,
                TRI.TIS_TRI_DS_TP_REGINTERNACAO,
                CASE
                  WHEN ((CCI.CAD_TAP_TP_ATRIBUTO = ''HM'' OR
                       CCI.CAD_TAP_TP_ATRIBUTO = ''EXA'') AND
                       NVL(CNV.CAD_CNV_FL_UTILIZAEQUIVALE, ''N'') = ''N'') THEN
                   (SELECT PRD_COB.CAD_PRD_CD_CODIGO
                      FROM TB_CAD_PRD_PRODUTO PRD_COB
                     WHERE PRD_COB.CAD_PRD_ID = CCI.CAD_PRD_ID_COBRADO)
                  ELSE
                   PRD.CAD_PRD_CD_CODIGO
                END CAD_PRD_CD_CODIGO,
                CASE
                  WHEN ((CCI.CAD_TAP_TP_ATRIBUTO = ''HM'' OR
                       CCI.CAD_TAP_TP_ATRIBUTO = ''EXA'') AND
                       NVL(CNV.CAD_CNV_FL_UTILIZAEQUIVALE, ''N'') = ''N'') THEN
                   (SELECT PRD_COB.CAD_PRD_NM_MNEMONICO
                      FROM TB_CAD_PRD_PRODUTO PRD_COB
                     WHERE PRD_COB.CAD_PRD_ID = CCI.CAD_PRD_ID_COBRADO)
                  ELSE
                   PRD.CAD_PRD_NM_MNEMONICO
                END CAD_PRD_NM_MNEMONICO,
                DECODE(PRD_MED.CAD_PRD_CD_CODIGO,
                       NULL,
                       CASE
                         WHEN ((CCI.CAD_TAP_TP_ATRIBUTO = ''HM'' OR
                              CCI.CAD_TAP_TP_ATRIBUTO = ''EXA'') AND
                              NVL(CNV.CAD_CNV_FL_UTILIZAEQUIVALE, ''N'') = ''N'') THEN
                          (SELECT PRD_COB.CAD_PRD_DS_DESCRICAO
                             FROM TB_CAD_PRD_PRODUTO PRD_COB
                            WHERE PRD_COB.CAD_PRD_ID = CCI.CAD_PRD_ID_COBRADO)
                         ELSE
                          PRD.CAD_PRD_DS_DESCRICAO
                       END,
                       ''('' || trim(PRD_MED.CAD_PRD_CD_CODIGO) || '')'' ||
                       PRD.CAD_PRD_DS_DESCRICAO) CAD_PRD_DS_DESCRICAO,
                EPP.AUX_EPP_DS_DESCRICAO,
                PRD_ORI.CAD_PRD_CD_CODIGO CAD_PRD_CD_CODIGO_ORIGEM,
                CASE
                  WHEN (CCI.CAD_TAP_TP_ATRIBUTO not in (''EXA'', ''DIA'') AND
                       TRIM(PRD.CAD_PRD_CD_CODIGO) NOT IN (''00821000'')) or
                       (CCI.CAD_TAP_TP_ATRIBUTO = ''EXA'' and
                       epp.aux_epp_cd_especproc in
                       (''410'', ''34'', ''411'', ''36'')) THEN
                   TO_CHAR(CCI.FAT_CCI_DT_INICIO_CONSUMO, ''DD/MM/YYYY'')
                  WHEN (CCI.CAD_TAP_TP_ATRIBUTO = ''DIA'') THEN
                   (SELECT to_char(MIN(CCI1.FAT_CCI_DT_INICIO_CONSUMO),
                                   ''DD/MM/YYYY'')
                      FROM ' || v_tabela || ' CCI1
                     WHERE CCI1.ATD_ATE_ID = CCI.ATD_ATE_ID
                       AND CCI1.FAT_CCP_ID = CCI.FAT_CCP_ID
                       AND CCI1.FAT_COC_ID = CCI.FAT_COC_ID
                       AND CCI1.CAD_PRD_ID = CCI.CAD_PRD_ID
                       AND CCI1.FAT_CCI_VL_UNITARIO =CCI.FAT_CCI_VL_UNITARIO
                       AND CCI1.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE)
                  ELSE
                   NULL
                END FAT_CCI_DT_INICIO_CONSUMO,
                CASE
                  WHEN (CCI.CAD_TAP_TP_ATRIBUTO in (''TAX'', ''HM'', ''GAS'') AND
                       TRIM(PRD.CAD_PRD_CD_CODIGO) NOT IN (''00821000'')) or
                       (CCI.CAD_TAP_TP_ATRIBUTO = ''EXA'' and
                       epp.aux_epp_cd_especproc in
                       (''410'', ''34'', ''411'', ''36'')) THEN
                   CCI.FAT_CCI_HR_INICIO_CONSUMO
                  ELSE
                   NULL
                END FAT_CCI_HR_INICIO_CONSUMO,
                null FAT_CCI_DT_FIM_CONSUMO,
                NULL FAT_CCI_HR_FIM_CONSUMO,
                SUM(CCI.FAT_CCI_QT_CONSUMO) OVER(PARTITION BY ATD.ATD_ATE_ID, CCP.FAT_CCP_ID, COC.FAT_COC_ID, PAC.CAD_PAC_ID_PACIENTE, 
                 CASE
                  WHEN ((CCI.CAD_TAP_TP_ATRIBUTO = ''HM'' OR CCI.CAD_TAP_TP_ATRIBUTO = ''EXA'') AND NVL(CNV.CAD_CNV_FL_UTILIZAEQUIVALE, ''N'') = ''N'') THEN
                   CCI.CAD_PRD_ID_COBRADO
                  ELSE
                   CCI.CAD_PRD_ID
                END ,
                CASE
                  WHEN (CCI.CAD_TAP_TP_ATRIBUTO NOT IN (''EXA'',  ''DIA'') AND
                       TRIM(PRD.CAD_PRD_CD_CODIGO) NOT IN  (''00821000'')) or
                       (CCI.CAD_TAP_TP_ATRIBUTO = ''EXA'' and epp.aux_epp_cd_especproc in (''410'', ''34'', ''411'',  ''36'')) 
                       THEN TO_CHAR(CCI.FAT_CCI_DT_INICIO_CONSUMO, ''DD/MM/YYYY'')
                  WHEN CCI.CAD_TAP_TP_ATRIBUTO = ''DIA'' THEN
                   (SELECT to_char(MIN(CCI1.FAT_CCI_DT_INICIO_CONSUMO), ''DD/MM/YYYY'')
                      FROM ' || v_tabela || ' CCI1
                     WHERE CCI1.ATD_ATE_ID = CCI.ATD_ATE_ID
                       AND CCI1.FAT_CCP_ID =CCI.FAT_CCP_ID
                       AND CCI1.FAT_COC_ID = CCI.FAT_COC_ID
                       AND CCI1.CAD_PRD_ID =CCI.CAD_PRD_ID
                       AND CCI1.FAT_CCI_VL_UNITARIO = CCI.FAT_CCI_VL_UNITARIO
                       AND CCI1.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE )
                  ELSE NULL
                  END,
                CASE
                  WHEN CCI.CAD_TAP_TP_ATRIBUTO = ''EXA'' and epp.aux_epp_cd_especproc in (''410'', ''34'', ''411'', ''36'') THEN CCI.FAT_CCI_HR_INICIO_CONSUMO
                  ELSE
                   NULL
                END,
                CASE
                  WHEN CCI.CAD_TAP_TP_ATRIBUTO in (''TAX'', ''HM'', ''GAS'', ''PAC'') AND TRIM(PRD.CAD_PRD_CD_CODIGO) NOT IN (''00821000'') THEN CCI.FAT_CCI_ID
                  ELSE
                   NULL
                 END,
                CASE
                  WHEN CCI.CAD_TAP_TP_ATRIBUTO in (''TAX'') AND
                       TRIM(PRD.CAD_PRD_CD_CODIGO) IN (''00821000'') THEN TRIM(PRD_MED.CAD_PRD_CD_CODIGO) || CCI.FAT_CCI_VL_UNITARIO
                  ELSE
                   NULL
                END,CASE
                  WHEN cci.cad_tap_tp_atributo = ''HM'' THEN cci.tis_gpp_cd_grau_part_prof
                  ELSE
                   NULL
                END,
                 DECODE(CCI.CAD_TAP_TP_ATRIBUTO, ''DIA'', ''DIARIA'', ''EXA'', ''EXAME'', ''TAX'', ''TAXAS'', ''GAS'', ''GASES'')) FAT_CCI_QT_CONSUMO,
                CASE
                  WHEN CCI.CAD_TAP_TP_ATRIBUTO in (''HM'') THEN
                   trunc(CCI.FAT_CCI_VL_FATURADO, 2)
                  ELSE
                   NULL
                END FAT_CCI_VL_FATURADO_ORIGINAL,
                trunc(SUM(ROUND(CCI.FAT_CCI_VL_FATURADO, 2))
                      OVER(PARTITION BY ATD.ATD_ATE_ID,
                           CCP.FAT_CCP_ID,
                           COC.FAT_COC_ID,
                           PAC.CAD_PAC_ID_PACIENTE,
                           --PRD.CAD_PRD_ID,
                             CASE
                              WHEN ((CCI.CAD_TAP_TP_ATRIBUTO = ''HM'' OR CCI.CAD_TAP_TP_ATRIBUTO = ''EXA'') AND NVL(CNV.CAD_CNV_FL_UTILIZAEQUIVALE, ''N'') = ''N'') THEN
                               CCI.CAD_PRD_ID_COBRADO
                              ELSE
                               CCI.CAD_PRD_ID
                            END ,
                           CASE
                             WHEN (CCI.CAD_TAP_TP_ATRIBUTO NOT IN (''EXA'', ''DIA'') AND
                                  TRIM(PRD.CAD_PRD_CD_CODIGO) NOT IN (''00821000'')) or
                                  (CCI.CAD_TAP_TP_ATRIBUTO = ''EXA'' and
                                  epp.aux_epp_cd_especproc in
                                  (''410'', ''34'', ''411'', ''36'')) THEN
                              TO_CHAR(CCI.FAT_CCI_DT_INICIO_CONSUMO, ''DD/MM/YYYY'')
                             WHEN CCI.CAD_TAP_TP_ATRIBUTO = ''DIA'' THEN
                              (SELECT to_char(MIN(CCI1.FAT_CCI_DT_INICIO_CONSUMO),
                                              ''DD/MM/YYYY'')
                                 FROM ' || v_tabela || ' CCI1
                                WHERE CCI1.ATD_ATE_ID = CCI.ATD_ATE_ID
                                  AND CCI1.FAT_CCP_ID = CCI.FAT_CCP_ID
                                  AND CCI1.FAT_COC_ID = CCI.FAT_COC_ID
                                  AND CCI1.CAD_PRD_ID = CCI.CAD_PRD_ID
                                  AND CCI1.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
                                  AND CCI1.FAT_CCI_VL_UNITARIO = CCI.FAT_CCI_VL_UNITARIO )
                             ELSE
                              NULL
                           END,
                           CASE
                             WHEN CCI.CAD_TAP_TP_ATRIBUTO = ''EXA'' and
                                  epp.aux_epp_cd_especproc in
                                  (''410'', ''34'', ''411'', ''36'') THEN
                              CCI.FAT_CCI_HR_INICIO_CONSUMO
                             ELSE
                              NULL
                           END,
                           CASE
                             WHEN CCI.CAD_TAP_TP_ATRIBUTO in (''TAX'') AND
                                  TRIM(PRD.CAD_PRD_CD_CODIGO) IN (''00821000'') THEN
                              TRIM(PRD_MED.CAD_PRD_CD_CODIGO) ||
                              CCI.FAT_CCI_VL_UNITARIO
                             ELSE
                              NULL
                           END,
                           CASE
                             WHEN CCI.CAD_TAP_TP_ATRIBUTO in
                                  (''TAX'', ''HM'', ''GAS'', ''PAC'') AND
                                  TRIM(PRD.CAD_PRD_CD_CODIGO) NOT IN (''00821000'') THEN
                              CCI.FAT_CCI_ID
                             ELSE
                              NULL
                           END,
                           DECODE(CCI.CAD_TAP_TP_ATRIBUTO,
                                  ''DIA'',
                                  ''DIARIA'',
                                  ''EXA'',
                                  ''EXAME'',
                                  ''TAX'',
                                  ''TAXAS'',
                                  ''GAS'',
                                  ''GASES'')),
                      2) FAT_CCI_VL_FATURADO,
                CASE
                  WHEN CCI.CAD_TAP_TP_ATRIBUTO in (''TAX'') AND
                       TRIM(PRD.CAD_PRD_CD_CODIGO) IN (''00821000'') THEN
                   CCI.FAT_CCI_VL_UNITARIO
                  ELSE
                   NULL
                END FAT_CCI_VL_UNITARIO,
                CASE
                  WHEN CCI.CAD_TAP_TP_ATRIBUTO in (''HM'') THEN
                   TRIM(GPP.TIS_GPP_CD_GRAU_PART_PROF)
                  ELSE
                   NULL
                END TIS_GPP_CD_GRAU_PART_PROF,
                CASE
                  WHEN CCI.CAD_TAP_TP_ATRIBUTO in (''HM'') THEN
                   GPP.TIS_GPP_DS_GRAU_PART_PROF
                  ELSE
                   NULL
                END TIS_GPP_DS_GRAU_PART_PROF,
                CASE
                  WHEN CCI.CAD_TAP_TP_ATRIBUTO in (''HM'') AND
                       CCI.FAT_CCI_PC_GRAU_PART_PROF IS NOT NULL THEN
                   (CCI.FAT_CCI_PC_GRAU_PART_PROF / 100)
                  ELSE
                   NULL
                END TIS_GPP_PC_GRAU_PART_PROF,
                NVL(CCI.FAT_CCI_TP_PORTEANESTESICO, 0) FAT_CCI_TP_PORTEANESTESICO,
                null CAD_MPF_DS_MOTI_PEND_FATURAR,
                CASE
                  WHEN CCI.CAD_TAP_TP_ATRIBUTO = ''HM'' THEN
                   DECODE(CCI.FAT_CCI_TP_CREDENCIA_PROF,
                          ''MC'',
                          ''MEDICO CREDENCIADO'',
                          ''CR'',
                          ''MEDICO CREDENCIADO'')
                  ELSE
                   NULL
                END FAT_CCI_TP_CREDENCIA_PROF,
                CASE
                  WHEN CCI.CAD_TAP_TP_ATRIBUTO NOT IN (''EXA'', ''TAX'', ''DIA'') THEN
                   NVL(CCI.FAT_CCI_ID_PRINCIPAL, CCI.FAT_CCI_ID)
                  WHEN CCI.CAD_TAP_TP_ATRIBUTO = ''TAX'' AND
                       TRIM(PRD.CAD_PRD_CD_CODIGO) NOT IN (''00821000'') THEN
                   CCI.FAT_CCI_ID
                  ELSE
                   NULL
                END FAT_CCI_ID,
                (SELECT DISTINCT SUM(CCI1.FAT_CCI_VL_FATURADO)
                   FROM TB_FAT_FCL_CONTR_EMI_LOTE FCL1
                   JOIN ' || v_tabela || ' CCI1
                     ON CCI1.FAT_CCP_ID = FCL1.FAT_CCP_ID
                    AND CCI1.ATD_ATE_ID = FCL1.ATD_ATE_ID
                    AND CCI1.FAT_COC_ID = FCL1.FAT_COC_ID
                    AND CCI1.CAD_PAC_ID_PACIENTE = FCL1.CAD_PAC_ID_PACIENTE
                   JOIN TB_ATD_ATE_ATENDIMENTO ATD1
                     ON ATD1.ATD_ATE_ID = CCI1.ATD_ATE_ID
                   JOIN TB_FAT_CCP_CONTA_CONS_PARC CCP1
                     ON CCP1.FAT_CCP_ID = CCI1.FAT_CCP_ID
                    AND CCP1.FAT_COC_ID = CCI1.FAT_COC_ID
                    AND CCP1.ATD_ATE_ID = CCI1.ATD_ATE_ID
                    AND CCP1.CAD_PAC_ID_PACIENTE = CCI1.CAD_PAC_ID_PACIENTE
                   JOIN TB_FAT_COC_CONTA_CONSUMO COC1
                     ON COC1.FAT_COC_ID = CCI1.FAT_COC_ID
                    AND COC1.ATD_ATE_ID = CCI1.ATD_ATE_ID
                    AND COC1.CAD_PAC_ID_PACIENTE = CCI1.CAD_PAC_ID_PACIENTE
                   JOIN TB_CAD_PRD_PRODUTO PRD1
                     ON PRD1.CAD_PRD_ID = CCI1.CAD_PRD_ID
                  WHERE (COC1.FAT_COC_ID = CCI.FAT_COC_ID)
                    AND (PRD1.CAD_TAP_TP_ATRIBUTO = ''MED'')
                    AND (CCP1.FAT_CCP_ID = CCI.FAT_CCP_ID)
                    AND (ATD1.ATD_ATE_ID = CCI.ATD_ATE_ID)
                    AND (CCP1.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE)
                    AND ((CCI.FAT_CCI_FL_PACOTE IS NULL) OR
                        (CCI.FAT_CCI_FL_PACOTE = ''N''))
                    AND (PRD1.TIS_MED_CD_TABELAMEDICA != ''IP'')
                    AND (CCI1.FAT_CCI_FL_STATUS = ''A'')
                    AND (CCP1.FAT_CCP_FL_STATUS = ''A'')
                    AND (COC1.FAT_COC_FL_STATUS = ''A'')
                    AND FCL1.FAT_FCL_NR_SEQ_LOTE = ' || pLOTE || ') TOTAL_MED,
                (SELECT DISTINCT SUM(CCI2.FAT_CCI_VL_FATURADO)
                   FROM TB_FAT_FCL_CONTR_EMI_LOTE FCL2
                   JOIN ' || v_tabela || ' CCI2
                     ON CCI2.FAT_CCP_ID = FCL2.FAT_CCP_ID
                    AND CCI2.ATD_ATE_ID = FCL2.ATD_ATE_ID
                    AND CCI2.FAT_COC_ID = FCL2.FAT_COC_ID
                    AND CCI2.CAD_PAC_ID_PACIENTE = FCL2.CAD_PAC_ID_PACIENTE
                   JOIN TB_ATD_ATE_ATENDIMENTO ATD2
                     ON ATD2.ATD_ATE_ID = CCI2.ATD_ATE_ID
                   JOIN TB_FAT_CCP_CONTA_CONS_PARC CCP2
                     ON CCP2.FAT_CCP_ID = CCI2.FAT_CCP_ID
                    AND CCP2.FAT_COC_ID = CCI2.FAT_COC_ID
                    AND CCP2.ATD_ATE_ID = CCI2.ATD_ATE_ID
                    AND CCP2.CAD_PAC_ID_PACIENTE = CCI2.CAD_PAC_ID_PACIENTE
                   JOIN TB_FAT_COC_CONTA_CONSUMO COC2
                     ON COC2.FAT_COC_ID = CCI2.FAT_COC_ID
                    AND COC2.ATD_ATE_ID = CCI2.ATD_ATE_ID
                    AND COC2.CAD_PAC_ID_PACIENTE = CCI2.CAD_PAC_ID_PACIENTE
                   JOIN TB_CAD_PRD_PRODUTO PRD2
                     ON PRD2.CAD_PRD_ID = CCI2.CAD_PRD_ID
                  WHERE (COC2.FAT_COC_ID = CCI.FAT_COC_ID)
                    AND (PRD2.CAD_TAP_TP_ATRIBUTO = ''MAT'')
                    AND (CCP2.FAT_CCP_ID = CCI.FAT_CCP_ID)
                    AND (ATD2.ATD_ATE_ID = CCI.ATD_ATE_ID)
                    AND (CCP2.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE)
                    AND ((CCI2.FAT_CCI_FL_PACOTE IS NULL) OR
                        (CCI.FAT_CCI_FL_PACOTE = ''N''))
                    AND (PRD2.TIS_MED_CD_TABELAMEDICA != ''IP'')
                    AND (CCI2.FAT_CCI_FL_STATUS = ''A'')
                    AND (CCP2.FAT_CCP_FL_STATUS = ''A'')
                    AND (COC2.FAT_COC_FL_STATUS = ''A'')
                    AND FCL2.FAT_FCL_NR_SEQ_LOTE = ' || pLOTE || ') TOTAL_MAT
  FROM TB_FAT_FCL_CONTR_EMI_LOTE FCL
  JOIN ' || v_tabela || ' CCI
    ON CCI.FAT_CCP_ID = FCL.FAT_CCP_ID
   AND CCI.ATD_ATE_ID = FCL.ATD_ATE_ID
   AND CCI.FAT_COC_ID = FCL.FAT_COC_ID
   AND CCI.CAD_PAC_ID_PACIENTE = FCL.CAD_PAC_ID_PACIENTE
  JOIN TB_ATD_ATE_ATENDIMENTO ATD
    ON ATD.ATD_ATE_ID = CCI.ATD_ATE_ID
  JOIN TB_FAT_CCP_CONTA_CONS_PARC CCP
    ON CCP.FAT_CCP_ID = CCI.FAT_CCP_ID
   AND CCP.FAT_COC_ID = CCI.FAT_COC_ID
   AND CCP.ATD_ATE_ID = CCI.ATD_ATE_ID
   AND CCP.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
  JOIN TB_FAT_COC_CONTA_CONSUMO COC
    ON COC.FAT_COC_ID = CCI.FAT_COC_ID
   AND COC.ATD_ATE_ID = CCI.ATD_ATE_ID
   AND COC.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
  LEFT JOIN TB_CAD_PRD_PRODUTO PRD
    ON PRD.CAD_PRD_ID = CCI.CAD_PRD_ID
  LEFT JOIN TB_CAD_TAP_TP_ATRIB_PRODUTO TAP
    ON TAP.CAD_TAP_TP_ATRIBUTO = CCI.CAD_TAP_TP_ATRIBUTO
  LEFT JOIN TB_AUX_EPP_ESPECPROC EPP
    ON EPP.AUX_EPP_CD_ESPECPROC = PRD.AUX_EPP_CD_ESPECPROC
   AND EPP.TIS_MED_CD_TABELAMEDICA = PRD.TIS_MED_CD_TABELAMEDICA
  LEFT JOIN TB_TIS_GPP_GRAU_PART_PROF GPP
    ON GPP.TIS_GPP_CD_GRAU_PART_PROF = CCI.TIS_GPP_CD_GRAU_PART_PROF
  LEFT JOIN TB_CAD_PRO_PROFISSIONAL PRO
    ON PRO.CAD_PRO_ID_PROFISSIONAL = CCI.CAD_PRO_ID_PROFISSIONAL
  JOIN TB_CAD_PAC_PACIENTE PAC
    ON PAC.CAD_PAC_ID_PACIENTE = CCP.CAD_PAC_ID_PACIENTE
  JOIN TB_CAD_PES_PESSOA PES
    ON PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA
  JOIN TB_CAD_CNV_CONVENIO CNV
    ON CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
  JOIN TB_CAD_PES_PESSOA PES_CNV
    ON PES_CNV.CAD_PES_ID_PESSOA = CNV.CAD_PES_ID_PESSOA
  JOIN TB_CAD_PLA_PLANO PLA
    ON PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
  LEFT JOIN TB_ATD_AIC_ATE_INT_COMPL AIC
    ON AIC.ATD_ATE_ID = CCI.ATD_ATE_ID
  LEFT JOIN TB_ATD_INA_INT_ALTA INA
    ON INA.ATD_ATE_ID = CCI.ATD_ATE_ID
  LEFT JOIN TB_TIS_MSI_MOTIVO_SAIDA_INT MSI
    ON MSI.TIS_MSI_CD_MOTIVOSAIDAINT = CCP.TIS_MSI_CD_MOTIVOSAIDAINT
  JOIN TB_CAD_UNI_UNIDADE UNI
    ON UNI.CAD_UNI_ID_UNIDADE = ATD.CAD_UNI_ID_UNIDADE
  JOIN TB_CAD_PES_PESSOA PES_UNI
    ON PES_UNI.CAD_PES_ID_PESSOA = UNI.CAD_PES_ID_PESSOA
  LEFT JOIN TB_CAD_CID_CID10 CID_ATD
    ON CID_ATD.CAD_CID_CD_CID10 = ATD.CAD_CID_CD_CID10
  LEFT JOIN TB_ATD_IDG_INT_DIAGNOSTICO IDG
    ON IDG.ATD_ATE_ID = CCI.ATD_ATE_ID
  LEFT JOIN TB_CAD_CID_CID10 CID_PRI
    ON CID_PRI.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDPRINCIPAL
  LEFT JOIN TB_CAD_CID_CID10 CID_SEC1
    ON CID_SEC1.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC1
  LEFT JOIN TB_CAD_CID_CID10 CID_SEC2
    ON CID_SEC2.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC2
  LEFT JOIN TB_CAD_CID_CID10 CID_SEC3
    ON CID_SEC3.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC3
  LEFT JOIN TB_CAD_CID_CID10 CID_SEC4
    ON CID_SEC4.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC4
  LEFT JOIN TB_CAD_CID_CID10 CID_SEC5
    ON CID_SEC5.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC5
  LEFT JOIN TB_TIS_TIN_TP_INTERNACAO TIN
    ON TIN.TIS_TIN_CD_INTERNACAO = AIC.TIS_TIN_CD_INTERNACAO
  LEFT JOIN TB_TIS_TRI_TP_REGINTERNACAO TRI
    ON TRI.TIS_TRI_CD_TP_REGINTERNACAO = AIC.TIS_TRI_CD_REGINTENNACAO
  LEFT JOIN TB_ATD_GUI_GUIAATEND GUI
    ON GUI.ATD_ATE_ID = CCI.ATD_ATE_ID
   AND GUI.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
   and GUI.ATD_GUI_FL_GUIAPRINC_OK = ''S''
  LEFT JOIN TB_ASS_CPE_CONV_PROD_EQUIVALE CPE
    ON CPE.CAD_PRD_ID_DESTINO = CCI.CAD_PRD_ID
   AND CPE.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
   AND CPE.CAD_LAT_ID_LOCAL_ATENDIMENTO = ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO
  LEFT JOIN TB_CAD_PRD_PRODUTO PRD_ORI
    ON PRD_ORI.CAD_PRD_ID = CPE.CAD_PRD_ID_ORIGEM
  --LEFT JOIN TB_CAD_MPF_MOTI_PEND_FATURAR MPF
 --   ON MPF.CAD_MPF_ID = CCI.CAD_MPF_ID
  LEFT JOIN ' || v_tabela || ' CCI_MED
    ON CCI.FAT_CCI_ID_PRINCIPAL = CCI_MED.FAT_CCI_ID_PRINCIPAL
   AND CCI.CAD_TAP_TP_ATRIBUTO = ''TAX''
   AND CCI_MED.CAD_TAP_TP_ATRIBUTO = ''MED''
   AND (CCI.FAT_CCI_FL_KITPRA IS NULL OR CCI.FAT_CCI_FL_KITPRA = ''N'')
  LEFT JOIN TB_CAD_PRD_PRODUTO PRD_MED
    ON CCI_MED.CAD_PRD_ID = PRD_MED.CAD_PRD_ID
 WHERE (FCL.FAT_FCL_NR_SEQ_LOTE = ' || pLOTE || ')
   AND ((CCI.FAT_CCI_FL_PACOTE IS NULL) OR (CCI.FAT_CCI_FL_PACOTE = ''N''))
   AND (PRD.TIS_MED_CD_TABELAMEDICA != ''IP'')
   AND CCI.FAT_CCI_FL_STATUS = ''A''
   AND CCP.FAT_CCP_FL_STATUS = ''A''
   AND COC.FAT_COC_FL_STATUS = ''A''
   AND CCI.CAD_TAP_TP_ATRIBUTO NOT IN (''M2'', ''MAT'', ''MED'')
UNION ';
v_select_parte2 := 'SELECT DISTINCT FCL.FAT_FCL_NR_SEQ_IMPRIME,
                4 ORDEM,
                ATD.ATD_ATE_ID,
                PAC.CAD_PAC_ID_PACIENTE,
                DECODE(ATD.ATD_ATE_TP_PACIENTE,
                       ''I'',
                       ''INTERNADO'',
                       ''E'',
                       ''EXTERNO'',
                       ''A'',
                       ''AMBULATORIO'',
                       ''U'',
                       ''PRONTO SOCORRO'') ATD_ATE_TP_PACIENTE,
                DECODE(ATD.ATD_ATE_FL_CARATER_SOLIC,
                       ''U'',
                       ''URGENCIA'',
                       ''E'',
                       ''ELETIVA'') ATD_ATE_FL_CARATER_SOLIC,
                TO_CHAR(ATD.ATD_ATE_DT_ATENDIMENTO, ''DD/MM/YYYY'') ATD_ATE_DT_ATENDIMENTO,
                ATD.ATD_ATE_HR_ATENDIMENTO,
                TO_CHAR(INA.ATD_INA_DT_ALTA_CLINICA, ''DD/MM/YYYY'') ATD_INA_DT_ALTA_CLINICA,
                INA.ATD_INA_HR_ALTA_CLINICA,
                TO_CHAR(CCP.FAT_CCP_DT_PARCELA, ''DD/MM/YYYY'') FAT_CCP_DT_PARCELA,
                CCP.FAT_CCP_HR_PARCELA,
                TO_CHAR(CCP.FAT_CCP_DT_PARCELA_INI, ''DD/MM/YYYY'') FAT_CCP_DT_PARCELA_INI,
                CCP.FAT_CCP_HR_PARCELA_INI,
                COC.FAT_COC_ID,
                CCP.FAT_CCP_ID,
                to_char(COC.FAT_COC_ID) || ''-'' || to_char(CCP.FAT_CCP_ID) || ''-'' ||
                to_char(PAC.CAD_PAC_ID_PACIENTE) || to_char(ATD.ATD_ATE_ID) coc_ccp_pac_atd,
                UNI.CAD_UNI_DS_UNIDADE UNIDADE,
                UNI.CAD_UNI_NR_CNES,
                PES_UNI.CAD_PES_NR_CNPJ_CPF,
                GUI.ATD_GUI_CD_CODIGO,
                GUI.ATD_GUI_CD_SENHA,
                ''M2'' CAD_TAP_TP_ATRIBUTO,
                ''FILMES'' CAD_TAP_DS_ATRIBUTO,
                CCP.FAT_CCP_MES_COMPET,
                CCP.FAT_CCP_ANO_COMPET,
                CCP.FAT_CCP_MES_FAT,
                CCP.FAT_CCP_ANO_FAT,
                MSI.TIS_MSI_DS_MOTIVOSAIDAINT,
                AIC.ATD_AIC_DS_EMPRESA,
                PAC.CAD_PAC_CD_CREDENCIAL,
                PAC.CAD_PAC_NR_PRONTUARIO,
                PES.CAD_PES_NM_PESSOA PACIENTE,
                TO_CHAR(PAC.CAD_PAC_DT_VALIDADECREDENCIAL, ''DD/MM/YYYY'') CAD_PAC_DT_VALIDADECREDENCIAL,
                PES.CAD_PES_NR_RG,
                PAC.CAD_PAC_NM_TITULAR,
                DECODE(AIC.ATD_AIC_TP_SITUACAO_PAC,
                       ''I'',
                       ''INTERNADO'',
                       ''A'',
                       ''ALTA'') ATD_AIC_TP_SITUACAO_PAC,
                CNV.CAD_CNV_CD_HAC_PRESTADOR,
                CNV.CAD_CNV_NM_FANTASIA || CASE
                  WHEN CNV.CAD_CNV_ID_CONVENIO = 282 AND
                       ATD.ATD_ATE_TP_PACIENTE = ''I'' THEN
                   (select '' (DIFERENCA DE CLASSE)''
                      from tb_fat_mcc_mov_com_consumo mcc1
                      JOIN TB_FAT_TCO_TIPO_COMANDA TCO
                        ON TCO.FAT_TCO_ID = MCC1.FAT_TCO_ID
                       AND TCO.FAT_TCO_ID = 10
                     where mcc1.atd_ate_id = CCI.ATD_ATE_ID
                       AND MCC1.FAT_MCC_ID = CCI.FAT_MCC_ID
                       AND CCI.FAT_CCI_DT_INICIO_CONSUMO BETWEEN
                           CCP.FAT_CCP_DT_PARCELA_INI AND
                           CCP.FAT_CCP_DT_PARCELA
                       AND ROWNUM = 1)
                  ELSE
                   ''''
                END CAD_CNV_NM_FANTASIA,
                PLA.CAD_PLA_CD_TIPOPLANO,
                PLA.CAD_PLA_CD_PLANO_HAC,
                PLA.CAD_PLA_NM_NOME_PLANO,
                NULL PROFISSIONAL,
                NULL CAD_PRO_NR_CONSELHO,
                NULL CAD_PRO_SG_UF_CONSELHO,
                CASE
                  WHEN CID_PRI.CAD_CID_DS_CID10 IS NULL THEN
                   CID_ATD.CAD_CID_DS_CID10
                  ELSE
                   CID_PRI.CAD_CID_DS_CID10
                END CID_PRINCIPAL,
                CID_SEC1.CAD_CID_DS_CID10 CID_SECUNDARIO,
                CID_SEC2.CAD_CID_DS_CID10 CID_SECUNDARIO2,
                CID_SEC3.CAD_CID_DS_CID10 CID_SECUNDARIO3,
                CID_SEC4.CAD_CID_DS_CID10 CID_SECUNDARIO4,
                CID_SEC5.CAD_CID_DS_CID10 CID_SECUNDARIO5,
                CASE
                  WHEN CID_PRI.CAD_CID_DS_CID10 IS NULL THEN
                   CID_ATD.CAD_CID_CD_CID10
                  ELSE
                   CID_PRI.CAD_CID_CD_CID10
                END CAD_CID_CD_CID10_PRI,
                CID_SEC1.CAD_CID_CD_CID10 CAD_CID_CD_CID10_1,
                CID_SEC2.CAD_CID_CD_CID10 CAD_CID_CD_CID10_2,
                CID_SEC3.CAD_CID_CD_CID10 CAD_CID_CD_CID10_3,
                CID_SEC4.CAD_CID_CD_CID10 CAD_CID_CD_CID10_4,
                CID_SEC5.CAD_CID_CD_CID10 CAD_CID_CD_CID10_5,
                TIN.TIS_TIN_DS_INTERNACAO,
                TRI.TIS_TRI_DS_TP_REGINTERNACAO,
                null CAD_PRD_CD_CODIGO,
                null CAD_PRD_NM_MNEMONICO,
                ''METRO QUADRADO DE FILME'' CAD_PRD_DS_DESCRICAO,
                null AUX_EPP_DS_DESCRICAO,
                null CAD_PRD_CD_CODIGO_ORIGEM,
                null FAT_CCI_DT_INICIO_CONSUMO,
                null FAT_CCI_HR_INICIO_CONSUMO,
                null FAT_CCI_DT_FIM_CONSUMO,
                null FAT_CCI_HR_FIM_CONSUMO,
                null FAT_CCI_QT_CONSUMO,
                nvl(M2.TOTAL_FILME, 0) FAT_CCI_VL_FATURADO_ORIGINAL,
                nvl(M2.TOTAL_FILME, 0) FAT_CCI_VL_FATURADO,
                null FAT_CCI_VL_UNITARIO,
                null TIS_GPP_CD_GRAU_PART_PROF,
                null TIS_GPP_DS_GRAU_PART_PROF,
                null TIS_GPP_PC_GRAU_PART_PROF,
                null FAT_CCI_TP_PORTEANESTESICO,
                null CAD_MPF_DS_MOTI_PEND_FATURAR,
                null FAT_CCI_TP_CREDENCIA_PROF,
                NULL FAT_CCI_ID,
                null TOTAL_MED,
                null TOTAL_MAT
  FROM TB_FAT_FCL_CONTR_EMI_LOTE FCL
  JOIN ' || v_tabela || ' CCI
    ON CCI.FAT_CCP_ID = FCL.FAT_CCP_ID
   AND CCI.ATD_ATE_ID = FCL.ATD_ATE_ID
   AND CCI.FAT_COC_ID = FCL.FAT_COC_ID
   AND CCI.CAD_PAC_ID_PACIENTE = FCL.CAD_PAC_ID_PACIENTE
  JOIN TB_ATD_ATE_ATENDIMENTO ATD
    ON ATD.ATD_ATE_ID = CCI.ATD_ATE_ID
  JOIN TB_FAT_CCP_CONTA_CONS_PARC CCP
    ON CCP.FAT_CCP_ID = CCI.FAT_CCP_ID
   AND CCP.FAT_COC_ID = CCI.FAT_COC_ID
   AND CCP.ATD_ATE_ID = CCI.ATD_ATE_ID
   AND CCP.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
  JOIN TB_FAT_COC_CONTA_CONSUMO COC
    ON COC.FAT_COC_ID = CCI.FAT_COC_ID
   AND COC.ATD_ATE_ID = CCI.ATD_ATE_ID
   AND COC.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
  JOIN TB_CAD_PAC_PACIENTE PAC
    ON PAC.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
  JOIN TB_CAD_PES_PESSOA PES
    ON PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA
  JOIN TB_CAD_CNV_CONVENIO CNV
    ON CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
  JOIN TB_CAD_PES_PESSOA PES_CNV
    ON PES_CNV.CAD_PES_ID_PESSOA = CNV.CAD_PES_ID_PESSOA
  JOIN TB_CAD_PLA_PLANO PLA
    ON PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
  LEFT JOIN TB_ATD_AIC_ATE_INT_COMPL AIC
    ON AIC.ATD_ATE_ID = CCI.ATD_ATE_ID
  LEFT JOIN TB_ATD_INA_INT_ALTA INA
    ON INA.ATD_ATE_ID = CCI.ATD_ATE_ID
  LEFT JOIN TB_TIS_MSI_MOTIVO_SAIDA_INT MSI
    ON MSI.TIS_MSI_CD_MOTIVOSAIDAINT = CCP.TIS_MSI_CD_MOTIVOSAIDAINT
  JOIN TB_CAD_UNI_UNIDADE UNI
    ON UNI.CAD_UNI_ID_UNIDADE = ATD.CAD_UNI_ID_UNIDADE
  JOIN TB_CAD_PES_PESSOA PES_UNI
    ON PES_UNI.CAD_PES_ID_PESSOA = UNI.CAD_PES_ID_PESSOA
  LEFT JOIN TB_CAD_CID_CID10 CID_ATD
    ON CID_ATD.CAD_CID_CD_CID10 = ATD.CAD_CID_CD_CID10
  LEFT JOIN TB_ATD_IDG_INT_DIAGNOSTICO IDG
    ON IDG.ATD_ATE_ID = ATD.ATD_ATE_ID
  LEFT JOIN TB_CAD_CID_CID10 CID_PRI
    ON CID_PRI.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDPRINCIPAL
  LEFT JOIN TB_CAD_CID_CID10 CID_SEC1
    ON CID_SEC1.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC1
  LEFT JOIN TB_CAD_CID_CID10 CID_SEC2
    ON CID_SEC2.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC2
  LEFT JOIN TB_CAD_CID_CID10 CID_SEC3
    ON CID_SEC3.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC3
  LEFT JOIN TB_CAD_CID_CID10 CID_SEC4
    ON CID_SEC4.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC4
  LEFT JOIN TB_CAD_CID_CID10 CID_SEC5
    ON CID_SEC5.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC5
  LEFT JOIN TB_TIS_TIN_TP_INTERNACAO TIN
    ON TIN.TIS_TIN_CD_INTERNACAO = AIC.TIS_TIN_CD_INTERNACAO
  LEFT JOIN TB_TIS_TRI_TP_REGINTERNACAO TRI
    ON TRI.TIS_TRI_CD_TP_REGINTERNACAO = AIC.TIS_TRI_CD_REGINTENNACAO
  LEFT JOIN TB_ATD_GUI_GUIAATEND GUI
    ON GUI.ATD_ATE_ID = CCI.ATD_ATE_ID
   AND GUI.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
   and GUI.ATD_GUI_FL_GUIAPRINC_OK = ''S''
  LEFT JOIN (SELECT SUM(CCI.FAT_CCI_VL_FATURADO) TOTAL_FILME,
                    FCL.FAT_FCL_NR_SEQ_LOTE,
                    FCL.ATD_ATE_ID,
                    FCL.FAT_COC_ID,
                    FCL.FAT_CCP_ID,
                    FCL.CAD_PAC_ID_PACIENTE
               FROM ' || v_tabela || ' CCI, TB_FAT_FCL_CONTR_EMI_LOTE FCL
              WHERE FCL.ATD_ATE_ID = CCI.ATD_ATE_ID
                AND FCL.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
                AND FCL.FAT_COC_ID = CCI.FAT_COC_ID
                AND FCL.FAT_CCP_ID = CCI.FAT_CCP_ID
                AND CCI.CAD_TAP_TP_ATRIBUTO = ''M2''
                AND CCI.FAT_CCI_FL_STATUS = ''A''
                AND ((CCI.FAT_CCI_FL_PACOTE IS NULL) OR
                    (CCI.FAT_CCI_FL_PACOTE = ''N''))
              GROUP BY FCL.FAT_FCL_NR_SEQ_LOTE,
                       FCL.ATD_ATE_ID,
                       FCL.FAT_COC_ID,
                       FCL.FAT_CCP_ID,
                       FCL.CAD_PAC_ID_PACIENTE) M2
    ON FCL.FAT_FCL_NR_SEQ_LOTE = M2.FAT_FCL_NR_SEQ_LOTE
   AND FCL.FAT_COC_ID = M2.FAT_COC_ID
   AND FCL.FAT_CCP_ID = M2.FAT_CCP_ID
   AND FCL.ATD_ATE_ID = M2.ATD_ATE_ID
   AND FCL.CAD_PAC_ID_PACIENTE = M2.CAD_PAC_ID_PACIENTE
 WHERE (FCL.FAT_FCL_NR_SEQ_LOTE = ' || pLOTE || ')
   AND (nvl(M2.TOTAL_FILME, 0) > 0)
   AND CCI.FAT_CCI_FL_STATUS = ''A''
   AND CCP.FAT_CCP_FL_STATUS = ''A''
   AND COC.FAT_COC_FL_STATUS = ''A''
   AND CCI.CAD_TAP_TP_ATRIBUTO = ''M2''
UNION
SELECT distinct FCL.FAT_FCL_NR_SEQ_IMPRIME,
                9 ORDEM,
                ATD.ATD_ATE_ID,
                PAC.CAD_PAC_ID_PACIENTE,
                DECODE(ATD.ATD_ATE_TP_PACIENTE,
                       ''I'',
                       ''INTERNADO'',
                       ''E'',
                       ''EXTERNO'',
                       ''A'',
                       ''AMBULATORIO'',
                       ''U'',
                       ''PRONTO SOCORRO'') ATD_ATE_TP_PACIENTE,
                DECODE(ATD.ATD_ATE_FL_CARATER_SOLIC,
                       ''U'',
                       ''URGENCIA'',
                       ''E'',
                       ''ELETIVA'') ATD_ATE_FL_CARATER_SOLIC,
                TO_CHAR(ATD.ATD_ATE_DT_ATENDIMENTO, ''DD/MM/YYYY'') ATD_ATE_DT_ATENDIMENTO,
                ATD.ATD_ATE_HR_ATENDIMENTO,
                TO_CHAR(INA.ATD_INA_DT_ALTA_CLINICA, ''DD/MM/YYYY'') ATD_INA_DT_ALTA_CLINICA,
                INA.ATD_INA_HR_ALTA_CLINICA,
                TO_CHAR(CCP.FAT_CCP_DT_PARCELA, ''DD/MM/YYYY'') FAT_CCP_DT_PARCELA,
                CCP.FAT_CCP_HR_PARCELA,
                TO_CHAR(CCP.FAT_CCP_DT_PARCELA_INI, ''DD/MM/YYYY'') FAT_CCP_DT_PARCELA_INI,
                CCP.FAT_CCP_HR_PARCELA_INI,
                COC.FAT_COC_ID,
                CCP.FAT_CCP_ID,
                to_char(COC.FAT_COC_ID) || ''-'' || to_char(CCP.FAT_CCP_ID) || ''-'' ||
                to_char(PAC.CAD_PAC_ID_PACIENTE) || to_char(ATD.ATD_ATE_ID) coc_ccp_pac_atd,
                UNI.CAD_UNI_DS_UNIDADE UNIDADE,
                UNI.CAD_UNI_NR_CNES,
                PES_UNI.CAD_PES_NR_CNPJ_CPF,
                GUI.ATD_GUI_CD_CODIGO,
                GUI.ATD_GUI_CD_SENHA,
                ''MM'' CAD_TAP_TP_ATRIBUTO,
                ''MATMED'' CAD_TAP_DS_ATRIBUTO,
                CCP.FAT_CCP_MES_COMPET,
                CCP.FAT_CCP_ANO_COMPET,
                CCP.FAT_CCP_MES_FAT,
                CCP.FAT_CCP_ANO_FAT,
                MSI.TIS_MSI_DS_MOTIVOSAIDAINT,
                AIC.ATD_AIC_DS_EMPRESA,
                PAC.CAD_PAC_CD_CREDENCIAL,
                PAC.CAD_PAC_NR_PRONTUARIO,
                PES.CAD_PES_NM_PESSOA PACIENTE,
                TO_CHAR(PAC.CAD_PAC_DT_VALIDADECREDENCIAL, ''DD/MM/YYYY'') CAD_PAC_DT_VALIDADECREDENCIAL,
                PES.CAD_PES_NR_RG,
                PAC.CAD_PAC_NM_TITULAR,
                DECODE(AIC.ATD_AIC_TP_SITUACAO_PAC,
                       ''I'',
                       ''INTERNADO'',
                       ''A'',
                       ''ALTA'') ATD_AIC_TP_SITUACAO_PAC,
                CNV.CAD_CNV_CD_HAC_PRESTADOR,
                CNV.CAD_CNV_NM_FANTASIA || CASE
                  WHEN CNV.CAD_CNV_ID_CONVENIO = 282 AND
                       ATD.ATD_ATE_TP_PACIENTE = ''I'' THEN
                   (select '' (DIFERENCA DE CLASSE)''
                      from tb_fat_mcc_mov_com_consumo mcc1
                      JOIN TB_FAT_TCO_TIPO_COMANDA TCO
                        ON TCO.FAT_TCO_ID = MCC1.FAT_TCO_ID
                       AND TCO.FAT_TCO_ID = 10
                     where mcc1.atd_ate_id = CCI.ATD_ATE_ID
                       AND MCC1.FAT_MCC_ID = CCI.FAT_MCC_ID
                       AND CCI.FAT_CCI_DT_INICIO_CONSUMO BETWEEN
                           CCP.FAT_CCP_DT_PARCELA_INI AND
                           CCP.FAT_CCP_DT_PARCELA
                       AND ROWNUM = 1)
                  ELSE
                   ''''
                END CAD_CNV_NM_FANTASIA,
                PLA.CAD_PLA_CD_TIPOPLANO,
                PLA.CAD_PLA_CD_PLANO_HAC,
                PLA.CAD_PLA_NM_NOME_PLANO,
                null PROFISSIONAL,
                null CAD_PRO_NR_CONSELHO,
                null CAD_PRO_SG_UF_CONSELHO,
                CASE
                  WHEN CID_PRI.CAD_CID_DS_CID10 IS NULL THEN
                   CID_ATD.CAD_CID_DS_CID10
                  ELSE
                   CID_PRI.CAD_CID_DS_CID10
                END CID_PRINCIPAL,
                CID_SEC1.CAD_CID_DS_CID10 CID_SECUNDARIO,
                CID_SEC2.CAD_CID_DS_CID10 CID_SECUNDARIO2,
                CID_SEC3.CAD_CID_DS_CID10 CID_SECUNDARIO3,
                CID_SEC4.CAD_CID_DS_CID10 CID_SECUNDARIO4,
                CID_SEC5.CAD_CID_DS_CID10 CID_SECUNDARIO5,
                CASE
                  WHEN CID_PRI.CAD_CID_DS_CID10 IS NULL THEN
                   CID_ATD.CAD_CID_CD_CID10
                  ELSE
                   CID_PRI.CAD_CID_CD_CID10
                END CAD_CID_CD_CID10_PRI,
                CID_SEC1.CAD_CID_CD_CID10 CAD_CID_CD_CID10_1,
                CID_SEC2.CAD_CID_CD_CID10 CAD_CID_CD_CID10_2,
                CID_SEC3.CAD_CID_CD_CID10 CAD_CID_CD_CID10_3,
                CID_SEC4.CAD_CID_CD_CID10 CAD_CID_CD_CID10_4,
                CID_SEC5.CAD_CID_CD_CID10 CAD_CID_CD_CID10_5,
                TIN.TIS_TIN_DS_INTERNACAO,
                TRI.TIS_TRI_DS_TP_REGINTERNACAO,
                NULL CAD_PRD_CD_CODIGO,
                NULL CAD_PRD_NM_MNEMONICO,
                NULL CAD_PRD_DS_DESCRICAO,
                NULL AUX_EPP_DS_DESCRICAO,
                NULL CAD_PRD_CD_CODIGO_ORIGEM,
                NULL FAT_CCI_DT_INICIO_CONSUMO,
                NULL FAT_CCI_HR_INICIO_CONSUMO,
                NULL FAT_CCI_DT_FIM_CONSUMO,
                NULL FAT_CCI_HR_FIM_CONSUMO,
                null FAT_CCI_QT_CONSUMO,
                null FAT_CCI_VL_FATURADO_ORIGINAL,
                null FAT_CCI_VL_FATURADO,
                null FAT_CCI_VL_UNITARIO,
                NULL TIS_GPP_CD_GRAU_PART_PROF,
                NULL TIS_GPP_DS_GRAU_PART_PROF,
                NULL TIS_GPP_PC_GRAU_PART_PROF,
                NULL FAT_CCI_TP_PORTEANESTESICO,
                NULL CAD_MPF_DS_MOTI_PEND_FATURAR,
                NULL FAT_CCI_TP_CREDENCIA_PROF,
                NULL FAT_CCI_ID,
                (SELECT DISTINCT SUM(CCI1.FAT_CCI_VL_FATURADO)
                   FROM TB_FAT_FCL_CONTR_EMI_LOTE FCL1
                   JOIN ' || v_tabela || ' CCI1
                     ON CCI1.FAT_CCP_ID = FCL1.FAT_CCP_ID
                    AND CCI1.ATD_ATE_ID = FCL1.ATD_ATE_ID
                    AND CCI1.FAT_COC_ID = FCL1.FAT_COC_ID
                    AND CCI1.CAD_PAC_ID_PACIENTE = FCL1.CAD_PAC_ID_PACIENTE
                   JOIN TB_ATD_ATE_ATENDIMENTO ATD1
                     ON ATD1.ATD_ATE_ID = CCI1.ATD_ATE_ID
                   JOIN TB_FAT_CCP_CONTA_CONS_PARC CCP1
                     ON CCP1.FAT_CCP_ID = CCI1.FAT_CCP_ID
                    AND CCP1.FAT_COC_ID = CCI1.FAT_COC_ID
                    AND CCP1.ATD_ATE_ID = CCI1.ATD_ATE_ID
                    AND CCP1.CAD_PAC_ID_PACIENTE = CCI1.CAD_PAC_ID_PACIENTE
                   JOIN TB_FAT_COC_CONTA_CONSUMO COC1
                     ON COC1.FAT_COC_ID = CCI1.FAT_COC_ID
                    AND COC1.ATD_ATE_ID = CCI1.ATD_ATE_ID
                    AND COC1.CAD_PAC_ID_PACIENTE = CCI1.CAD_PAC_ID_PACIENTE
                   JOIN TB_CAD_PRD_PRODUTO PRD1
                     ON PRD1.CAD_PRD_ID = CCI1.CAD_PRD_ID
                  WHERE (COC1.FAT_COC_ID = CCI.FAT_COC_ID)
                    AND (PRD1.CAD_TAP_TP_ATRIBUTO = ''MED'')
                    AND (CCP1.FAT_CCP_ID = CCI.FAT_CCP_ID)
                    AND (ATD1.ATD_ATE_ID = CCI.ATD_ATE_ID)
                    AND (CCP1.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE)
                    AND ((CCI.FAT_CCI_FL_PACOTE IS NULL) OR
                        (CCI.FAT_CCI_FL_PACOTE = ''N''))
                    AND (PRD1.TIS_MED_CD_TABELAMEDICA != ''IP'')
                    AND (CCI1.FAT_CCI_FL_STATUS = ''A'')
                    AND (CCP1.FAT_CCP_FL_STATUS = ''A'')
                    AND (COC1.FAT_COC_FL_STATUS = ''A'')
                    AND FCL1.FAT_FCL_NR_SEQ_LOTE = ' || pLOTE || ') TOTAL_MED,
                (SELECT DISTINCT SUM(CCI2.FAT_CCI_VL_FATURADO)
                   FROM TB_FAT_FCL_CONTR_EMI_LOTE FCL2
                   JOIN ' || v_tabela || ' CCI2
                     ON CCI2.FAT_CCP_ID = FCL2.FAT_CCP_ID
                    AND CCI2.ATD_ATE_ID = FCL2.ATD_ATE_ID
                    AND CCI2.FAT_COC_ID = FCL2.FAT_COC_ID
                    AND CCI2.CAD_PAC_ID_PACIENTE = FCL2.CAD_PAC_ID_PACIENTE
                   JOIN TB_ATD_ATE_ATENDIMENTO ATD2
                     ON ATD2.ATD_ATE_ID = CCI2.ATD_ATE_ID
                   JOIN TB_FAT_CCP_CONTA_CONS_PARC CCP2
                     ON CCP2.FAT_CCP_ID = CCI2.FAT_CCP_ID
                    AND CCP2.FAT_COC_ID = CCI2.FAT_COC_ID
                    AND CCP2.ATD_ATE_ID = CCI2.ATD_ATE_ID
                    AND CCP2.CAD_PAC_ID_PACIENTE = CCI2.CAD_PAC_ID_PACIENTE
                   JOIN TB_FAT_COC_CONTA_CONSUMO COC2
                     ON COC2.FAT_COC_ID = CCI2.FAT_COC_ID
                    AND COC2.ATD_ATE_ID = CCI2.ATD_ATE_ID
                    AND COC2.CAD_PAC_ID_PACIENTE = CCI2.CAD_PAC_ID_PACIENTE
                   JOIN TB_CAD_PRD_PRODUTO PRD2
                     ON PRD2.CAD_PRD_ID = CCI2.CAD_PRD_ID
                  WHERE (COC2.FAT_COC_ID = CCI.FAT_COC_ID)
                    AND (PRD2.CAD_TAP_TP_ATRIBUTO = ''MAT'')
                    AND (CCP2.FAT_CCP_ID = CCI.FAT_CCP_ID)
                    AND (ATD2.ATD_ATE_ID = CCI.ATD_ATE_ID)
                    AND (CCP2.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE)
                    AND ((CCI2.FAT_CCI_FL_PACOTE IS NULL) OR
                        (CCI.FAT_CCI_FL_PACOTE = ''N''))
                    AND (PRD2.TIS_MED_CD_TABELAMEDICA != ''IP'')
                    AND (CCI2.FAT_CCI_FL_STATUS = ''A'')
                    AND (CCP2.FAT_CCP_FL_STATUS = ''A'')
                    AND (COC2.FAT_COC_FL_STATUS = ''A'')
                    AND FCL2.FAT_FCL_NR_SEQ_LOTE = ' || pLOTE || ') TOTAL_MAT
  FROM TB_FAT_FCL_CONTR_EMI_LOTE FCL
  JOIN ' || v_tabela || ' CCI
    ON CCI.FAT_CCP_ID = FCL.FAT_CCP_ID
   AND CCI.ATD_ATE_ID = FCL.ATD_ATE_ID
   AND CCI.FAT_COC_ID = FCL.FAT_COC_ID
   AND CCI.CAD_PAC_ID_PACIENTE = FCL.CAD_PAC_ID_PACIENTE
  JOIN TB_ATD_ATE_ATENDIMENTO ATD
    ON ATD.ATD_ATE_ID = CCI.ATD_ATE_ID
  JOIN TB_FAT_CCP_CONTA_CONS_PARC CCP
    ON CCP.FAT_CCP_ID = CCI.FAT_CCP_ID
   AND CCP.FAT_COC_ID = CCI.FAT_COC_ID
   AND CCP.ATD_ATE_ID = CCI.ATD_ATE_ID
   AND CCP.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
  JOIN TB_FAT_COC_CONTA_CONSUMO COC
    ON COC.FAT_COC_ID = CCI.FAT_COC_ID
   AND COC.ATD_ATE_ID = CCI.ATD_ATE_ID
   AND COC.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
  JOIN TB_CAD_PAC_PACIENTE PAC
    ON PAC.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
  JOIN TB_CAD_PES_PESSOA PES
    ON PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA
  JOIN TB_CAD_CNV_CONVENIO CNV
    ON CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
  JOIN TB_CAD_PES_PESSOA PES_CNV
    ON PES_CNV.CAD_PES_ID_PESSOA = CNV.CAD_PES_ID_PESSOA
  JOIN TB_CAD_PLA_PLANO PLA
    ON PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
  LEFT JOIN TB_ATD_AIC_ATE_INT_COMPL AIC
    ON AIC.ATD_ATE_ID = CCI.ATD_ATE_ID
  LEFT JOIN TB_ATD_INA_INT_ALTA INA
    ON INA.ATD_ATE_ID = CCI.ATD_ATE_ID
  LEFT JOIN TB_TIS_MSI_MOTIVO_SAIDA_INT MSI
    ON MSI.TIS_MSI_CD_MOTIVOSAIDAINT = CCP.TIS_MSI_CD_MOTIVOSAIDAINT
  JOIN TB_CAD_UNI_UNIDADE UNI
    ON UNI.CAD_UNI_ID_UNIDADE = ATD.CAD_UNI_ID_UNIDADE
  JOIN TB_CAD_PES_PESSOA PES_UNI
    ON PES_UNI.CAD_PES_ID_PESSOA = UNI.CAD_PES_ID_PESSOA
  LEFT JOIN TB_CAD_CID_CID10 CID_ATD
    ON CID_ATD.CAD_CID_CD_CID10 = ATD.CAD_CID_CD_CID10
  LEFT JOIN TB_ATD_IDG_INT_DIAGNOSTICO IDG
    ON IDG.ATD_ATE_ID = CCI.ATD_ATE_ID
  LEFT JOIN TB_CAD_CID_CID10 CID_PRI
    ON CID_PRI.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDPRINCIPAL
  LEFT JOIN TB_CAD_CID_CID10 CID_SEC1
    ON CID_SEC1.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC1
  LEFT JOIN TB_CAD_CID_CID10 CID_SEC2
    ON CID_SEC2.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC2
  LEFT JOIN TB_CAD_CID_CID10 CID_SEC3
    ON CID_SEC3.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC3
  LEFT JOIN TB_CAD_CID_CID10 CID_SEC4
    ON CID_SEC4.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC4
  LEFT JOIN TB_CAD_CID_CID10 CID_SEC5
    ON CID_SEC5.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC5
  LEFT JOIN TB_TIS_TIN_TP_INTERNACAO TIN
    ON TIN.TIS_TIN_CD_INTERNACAO = AIC.TIS_TIN_CD_INTERNACAO
  LEFT JOIN TB_TIS_TRI_TP_REGINTERNACAO TRI
    ON TRI.TIS_TRI_CD_TP_REGINTERNACAO = AIC.TIS_TRI_CD_REGINTENNACAO
  LEFT JOIN TB_ATD_GUI_GUIAATEND GUI
    ON GUI.ATD_ATE_ID = CCI.ATD_ATE_ID
   AND GUI.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
   and GUI.ATD_GUI_FL_GUIAPRINC_OK = ''S''
 WHERE (FCL.FAT_FCL_NR_SEQ_LOTE = ' || pLOTE || ')
   AND ((CCI.FAT_CCI_FL_PACOTE IS NULL) OR (CCI.FAT_CCI_FL_PACOTE = ''N''))
   AND CCI.FAT_CCI_FL_STATUS = ''A''
   AND CCP.FAT_CCP_FL_STATUS = ''A''
   AND COC.FAT_COC_FL_STATUS = ''A''
   AND CCI.CAD_TAP_TP_ATRIBUTO IN (''MAT'', ''MED'')
   AND ROWNUM = 1
 ORDER BY 1, 2';  
    OPEN v_cursor FOR
 v_select || v_select_parte2;
             io_cursor := v_cursor;
  end PRC_FAT_REL_CONTA;
