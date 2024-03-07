create or replace procedure sgs.PRC_FAT_REL_PREVIA
  (
    pATD_ATE_ID IN TB_FAT_CCI_CONTA_CONSU_ITEM.ATD_ATE_ID%TYPE,
    pCAD_PAC_ID_PACIENTE IN TB_FAT_CCI_CONTA_CONSU_ITEM.CAD_PAC_ID_PACIENTE%TYPE,
    pDATA IN TB_FAT_CCI_CONTA_CONSU_ITEM.FAT_CCI_DT_INICIO_CONSUMO%TYPE,
    io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_FAT_REL_PREVIA
  *
  *    Data Alteracao: 14/10/2010  Por: Pedro
  *    Alterac?o:
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
SELECT
               CASE WHEN CCI.CAD_TAP_TP_ATRIBUTO = 'DIA' THEN 1
                WHEN CCI.CAD_TAP_TP_ATRIBUTO = 'HM'  THEN 2
                WHEN CCI.CAD_TAP_TP_ATRIBUTO = 'EXA' THEN 3
                WHEN CCI.CAD_TAP_TP_ATRIBUTO = 'TAX' THEN 5
                WHEN CCI.CAD_TAP_TP_ATRIBUTO = 'GAS' THEN 6
                WHEN CCI.CAD_TAP_TP_ATRIBUTO = 'PAC' THEN 7
               END ORDEM,
               ATD.ATD_ATE_ID,
               PAC.CAD_PAC_ID_PACIENTE,
               DECODE(ATD.ATD_ATE_TP_PACIENTE,'I','INTERNADO','E','EXTERNO','A','AMBULATORIO','U','PRONTO SOCORRO')
               ATD_ATE_TP_PACIENTE,
               DECODE(ATD.ATD_ATE_FL_CARATER_SOLIC,'U','URGENCIA','E','ELETIVA') ATD_ATE_FL_CARATER_SOLIC,
               TO_CHAR(ATD.ATD_ATE_DT_ATENDIMENTO,'DD/MM/YYYY') ATD_ATE_DT_ATENDIMENTO,
               ATD.ATD_ATE_HR_ATENDIMENTO,
               TO_CHAR(INA.ATD_INA_DT_ALTA_CLINICA,'DD/MM/YYYY') ATD_INA_DT_ALTA_CLINICA,
               INA.ATD_INA_HR_ALTA_CLINICA,
               CCI.FAT_COC_ID,
               CCI.FAT_CCP_ID,
               NULL coc_ccp_pac_atd,
               UNI.CAD_UNI_DS_UNIDADE UNIDADE,
               UNI.CAD_UNI_NR_CNES,
               PES_UNI.CAD_PES_NR_CNPJ_CPF,
               (SELECT  GUI.ATD_GUI_CD_SENHA
                  FROM    TB_ATD_GUI_GUIAATEND  GUI
                  WHERE   GUI.ATD_GUI_FL_GUIAPRINC_OK = 'S' AND ROWNUM = 1
                  AND GUI.ATD_ATE_ID = pATD_ATE_ID ) ATD_GUI_CD_CODIGO,
               (SELECT  GUI.ATD_GUI_CD_CODIGO
                  FROM    TB_ATD_GUI_GUIAATEND  GUI
                  WHERE   GUI.ATD_GUI_FL_GUIAPRINC_OK = 'S' AND ROWNUM = 1
                  AND GUI.ATD_ATE_ID = pATD_ATE_ID ) ATD_GUI_CD_SENHA,
               CCI.CAD_TAP_TP_ATRIBUTO,
               TAP.CAD_TAP_DS_ATRIBUTO,
               '' FAT_CCP_MES_COMPET,
               '' FAT_CCP_ANO_COMPET,
               '' FAT_CCP_MES_FAT,
               '' FAT_CCP_ANO_FAT,
               '' TIS_MSI_DS_MOTIVOSAIDAINT,
               AIC.ATD_AIC_DS_EMPRESA,
               PAC.CAD_PAC_CD_CREDENCIAL,
               PAC.CAD_PAC_NR_PRONTUARIO,
               PES.CAD_PES_NM_PESSOA PACIENTE,
               TO_CHAR(PAC.CAD_PAC_DT_VALIDADECREDENCIAL,'DD/MM/YYYY') CAD_PAC_DT_VALIDADECREDENCIAL,
               PES.CAD_PES_NR_RG,
               PAC.CAD_PAC_NM_TITULAR,
               DECODE(AIC.ATD_AIC_TP_SITUACAO_PAC,'I','INTERNADO','A','ALTA') ATD_AIC_TP_SITUACAO_PAC,
               CNV.CAD_CNV_CD_HAC_PRESTADOR,
               CNV.CAD_CNV_NM_FANTASIA,
             --  PES_CNV.CAD_PES_NR_CNPJ_CPF
               PLA.CAD_PLA_CD_TIPOPLANO,
               PLA.CAD_PLA_CD_PLANO_HAC,
               PLA.CAD_PLA_NM_NOME_PLANO,
               PRO.CAD_PRO_NM_NOME PROFISSIONAL,
               PRO.CAD_PRO_NR_CONSELHO,
               PRO.CAD_PRO_SG_UF_CONSELHO,
               CASE WHEN CID_PRI.CAD_CID_DS_CID10 IS NULL THEN
                         CID_ATD.CAD_CID_DS_CID10
                    ELSE CID_PRI.CAD_CID_DS_CID10
               END CID_PRINCIPAL,
               --CASE WHEN (ATD.ATD_ATE_TP_PACIENTE = 'A' OR ATD.ATD_ATE_TP_PACIENTE = 'U') AND CID_SEC1.CAD_CID_DS_CID10 IS NULL
               --     THEN CID_ATD.CAD_CID_DS_CID10
              --      ELSE CID_SEC1.CAD_CID_DS_CID10
             --  END CID_SECUNDARIO,
               CID_SEC1.CAD_CID_DS_CID10 CID_SECUNDARIO,
               CID_SEC2.CAD_CID_DS_CID10 CID_SECUNDARIO2,
               CID_SEC3.CAD_CID_DS_CID10 CID_SECUNDARIO3,
               CID_SEC4.CAD_CID_DS_CID10 CID_SECUNDARIO4,
               CID_SEC5.CAD_CID_DS_CID10 CID_SECUNDARIO5,
               CASE WHEN CID_PRI.CAD_CID_DS_CID10 IS NULL THEN
                         CID_ATD.CAD_CID_CD_CID10
                    ELSE CID_PRI.CAD_CID_CD_CID10
               END CAD_CID_CD_CID10_PRI,
               CID_SEC1.CAD_CID_CD_CID10 CAD_CID_CD_CID10_1,
               CID_SEC2.CAD_CID_CD_CID10 CAD_CID_CD_CID10_2,
               CID_SEC3.CAD_CID_CD_CID10 CAD_CID_CD_CID10_3,
               CID_SEC4.CAD_CID_CD_CID10 CAD_CID_CD_CID10_4,
               CID_SEC5.CAD_CID_CD_CID10 CAD_CID_CD_CID10_5,
               TIN.TIS_TIN_DS_INTERNACAO,
               TRI.TIS_TRI_DS_TP_REGINTERNACAO,
--               APM.CAD_APM_DS_PRODUTO,
               PRD.CAD_PRD_CD_CODIGO,
               PRD.CAD_PRD_NM_MNEMONICO,
               PRD.CAD_PRD_DS_DESCRICAO DS_PRD,
                DECODE(CCI.FAT_FL_PENDENTE_AUTORIZA,'P','(PENDENTE) ','N','(N?O AUTORIZADO) ') || PRD.CAD_PRD_DS_DESCRICAO AS CAD_PRD_DS_DESCRICAO,
               EPP.AUX_EPP_DS_DESCRICAO,
               PRD_ORI.CAD_PRD_CD_CODIGO CAD_PRD_CD_CODIGO_ORIGEM,
               CASE WHEN CCI.CAD_TAP_TP_ATRIBUTO != 'EXA' THEN TO_CHAR(CCI.FAT_CCI_DT_INICIO_CONSUMO,'DD/MM/YYYY')
                ELSE NULL
               END FAT_CCI_DT_INICIO_CONSUMO,
               CASE WHEN CCI.CAD_TAP_TP_ATRIBUTO in ('TAX','HM') THEN CCI.FAT_CCI_HR_INICIO_CONSUMO
                ELSE NULL
               END FAT_CCI_HR_INICIO_CONSUMO,
               NULL FAT_CCI_DT_FIM_CONSUMO,
               NULL FAT_CCI_HR_FIM_CONSUMO,
              -- CCI.FAT_CCI_QT_CONSUMO,
             -- trunc(CCI.FAT_CCI_VL_FATURADO,2) FAT_CCI_VL_FATURADO,
               SUM(CCI.FAT_CCI_QT_CONSUMO) OVER
                                     (PARTITION BY cci.ATD_ATE_ID,cci.FAT_CCP_ID,cci.FAT_COC_ID,cci.CAD_PAC_ID_PACIENTE,
                                   --   PRD.CAD_PRD_ID,CCI.FAT_CCI_DT_INICIO_CONSUMO,CCI.FAT_CCI_HR_INICIO_CONSUMO,
                                     CASE
                              WHEN ((CCI.CAD_TAP_TP_ATRIBUTO = 'HM' OR CCI.CAD_TAP_TP_ATRIBUTO = 'EXA') AND NVL(CNV.CAD_CNV_FL_UTILIZAEQUIVALE, 'N') = 'N') THEN
                               CCI.CAD_PRD_ID_COBRADO
                              ELSE
                               CCI.CAD_PRD_ID
                            END ,CASE WHEN CCI.CAD_TAP_TP_ATRIBUTO != 'EXA' THEN CCI.FAT_CCI_DT_INICIO_CONSUMO
                                                         ELSE NULL END ,
                                                    CASE WHEN CCI.CAD_TAP_TP_ATRIBUTO in ('TAX','HM') THEN CCI.FAT_CCI_HR_INICIO_CONSUMO
                                                      ELSE NULL
                                                     END,
                                                     CASE WHEN cci.cad_tap_tp_atributo = 'HM' THEN cci.tis_gpp_cd_grau_part_prof
                                                      ELSE NULL
                                                     END, 
                                     DECODE(CCI.CAD_TAP_TP_ATRIBUTO,'DIA','DIARIA','EXA','EXAME','TAX',
                                     'TAXAS','GAS','GASES')) FAT_CCI_QT_CONSUMO,
               CASE WHEN CCI.CAD_TAP_TP_ATRIBUTO in ('HM') THEN trunc(CCI.FAT_CCI_VL_FATURADO,2)
                ELSE NULL
               END  FAT_CCI_VL_FATURADO_ORIGINAL,
               trunc(SUM(round(CCI.FAT_CCI_VL_FATURADO,2)) OVER
                                     (PARTITION BY cci.ATD_ATE_ID,cci.FAT_CCP_ID,cci.FAT_COC_ID,cci.CAD_PAC_ID_PACIENTE,
                                     --   PRD.CAD_PRD_ID,CCI.FAT_CCI_DT_INICIO_CONSUMO,CCI.FAT_CCI_HR_INICIO_CONSUMO,
                                    CASE
                                      WHEN ((CCI.CAD_TAP_TP_ATRIBUTO = 'HM' OR CCI.CAD_TAP_TP_ATRIBUTO = 'EXA') AND NVL(CNV.CAD_CNV_FL_UTILIZAEQUIVALE, 'N') = 'N') THEN
                                       CCI.CAD_PRD_ID_COBRADO
                                      ELSE
                                       CCI.CAD_PRD_ID
                                    END ,
                                    CASE WHEN CCI.CAD_TAP_TP_ATRIBUTO != 'EXA' THEN CCI.FAT_CCI_DT_INICIO_CONSUMO
                                                         ELSE NULL END ,
                                                    CASE WHEN CCI.CAD_TAP_TP_ATRIBUTO in ('TAX','HM') THEN CCI.FAT_CCI_HR_INICIO_CONSUMO
                                                      ELSE NULL
                                                     END,
                                     DECODE(CCI.CAD_TAP_TP_ATRIBUTO,'DIA','DIARIA','EXA','EXAME','TAX',
                                     'TAXAS','GAS','GASES' ) ),2)
                                     *
                                     CASE WHEN (CCI.TIS_GPP_CD_GRAU_PART_PROF IN ('1','2','3','4','5','6','7','8',
                                                '9','10','11','12','13') AND (CCI.CAD_TAP_TP_ATRIBUTO = 'HM')) THEN 0  ELSE 1 END
                                     FAT_CCI_VL_FATURADO,
               trunc(CCI.FAT_CCI_VL_UNITARIO,2) FAT_CCI_VL_UNITARIO,
               CASE WHEN CCI.CAD_TAP_TP_ATRIBUTO in ('HM') THEN TRIM(GPP.TIS_GPP_CD_GRAU_PART_PROF)
                ELSE NULL
               END  TIS_GPP_CD_GRAU_PART_PROF,
               CASE WHEN CCI.CAD_TAP_TP_ATRIBUTO in ('HM') THEN GPP.TIS_GPP_DS_GRAU_PART_PROF
                ELSE NULL
               END TIS_GPP_DS_GRAU_PART_PROF,
               CASE WHEN CCI.CAD_TAP_TP_ATRIBUTO in ('HM') THEN GPP.TIS_GPP_PC_GRAU_PART_PROF
                ELSE NULL
               END TIS_GPP_PC_GRAU_PART_PROF,
               CCI.FAT_CCI_TP_PORTEANESTESICO,
               MPF.CAD_MPF_DS_MOTI_PEND_FATURAR,
                DECODE(CCI.FAT_CCI_TP_CREDENCIA_PROF,'MC','MEDICO CREDENCIADO','CR','MEDICO CREDENCIADO') FAT_CCI_TP_CREDENCIA_PROF,
               NVL((SELECT SUM(CCI.FAT_CCI_VL_FATURADO)
                     FROM                TB_FAT_CCI_CONTA_CONSU_ITEM CCI
                    WHERE  CCI.CAD_TAP_TP_ATRIBUTO = 'MED'
                      AND CCI.FAT_CCI_FL_STATUS = 'A'
                      AND ((CCI.FAT_CCI_FL_PACOTE IS NULL) OR (CCI.FAT_CCI_FL_PACOTE = 'N'))
                     -- AND ((CCI.FAT_CCI_FL_KITPRA IS NULL) OR (CCI.FAT_CCI_FL_KITPRA = 'N'))
                      AND CCI.FAT_CCP_ID IS NULL
                      AND CCI.ATD_ATE_ID = pATD_ATE_ID
                      AND CCI.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
                      AND ((CCI.FAT_CCI_DT_INICIO_CONSUMO < pDATA AND ATD.ATD_ATE_TP_PACIENTE IN ('I'))
                            OR ATD.ATD_ATE_TP_PACIENTE IN ('A','U','E'))
                  ),0) TOTAL_MED,
               NVL((SELECT SUM(CCI.FAT_CCI_VL_FATURADO)
                     FROM                TB_FAT_CCI_CONTA_CONSU_ITEM CCI
                    WHERE  CCI.CAD_TAP_TP_ATRIBUTO = 'MAT'
                      AND CCI.FAT_CCI_FL_STATUS = 'A'
                      AND ((CCI.FAT_CCI_FL_PACOTE IS NULL) OR (CCI.FAT_CCI_FL_PACOTE = 'N'))
                    --  AND ((CCI.FAT_CCI_FL_KITPRA IS NULL) OR (CCI.FAT_CCI_FL_KITPRA = 'N'))
                      AND CCI.FAT_CCP_ID IS NULL
                      AND CCI.ATD_ATE_ID = pATD_ATE_ID
                      AND CCI.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
                      AND ((CCI.FAT_CCI_DT_INICIO_CONSUMO < pDATA AND ATD.ATD_ATE_TP_PACIENTE IN ('I'))
                            OR ATD.ATD_ATE_TP_PACIENTE IN ('A','U','E'))
                  ),0) TOTAL_MAT
  FROM
                TB_ATD_ATE_ATENDIMENTO      ATD
  JOIN          TB_FAT_CCI_CONTA_CONSU_ITEM CCI
  ON            CCI.ATD_ATE_ID            = ATD.ATD_ATE_ID
  AND           CCI.FAT_CCI_FL_STATUS     = 'A'
  AND           CCI.CAD_TAP_TP_ATRIBUTO NOT IN ('M2','MAT','MED')
  LEFT JOIN     TB_CAD_PRD_PRODUTO          PRD
  ON            PRD.CAD_PRD_ID            = CCI.CAD_PRD_ID
  LEFT JOIN     TB_CAD_TAP_TP_ATRIB_PRODUTO TAP
  ON            TAP.CAD_TAP_TP_ATRIBUTO   = CCI.CAD_TAP_TP_ATRIBUTO
  LEFT JOIN     TB_AUX_EPP_ESPECPROC        EPP
  ON            EPP.AUX_EPP_CD_ESPECPROC  = PRD.AUX_EPP_CD_ESPECPROC
  AND           EPP.TIS_MED_CD_TABELAMEDICA = PRD.TIS_MED_CD_TABELAMEDICA
  LEFT JOIN     TB_TIS_GPP_GRAU_PART_PROF   GPP
  ON            GPP.TIS_GPP_CD_GRAU_PART_PROF = CCI.TIS_GPP_CD_GRAU_PART_PROF
  LEFT JOIN     TB_CAD_PRO_PROFISSIONAL     PRO
  ON            PRO.CAD_PRO_ID_PROFISSIONAL = CCI.CAD_PRO_ID_PROFISSIONAL
  --LEFT JOIN     TB_CAD_APM_APRES_PRO_MATMED APM
 -- ON            APM.CAD_APM_ID_MATMED     = PRD.CAD_APM_ID_MATMED
  JOIN          TB_CAD_PAC_PACIENTE       PAC
  ON            PAC.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
  JOIN          TB_CAD_PES_PESSOA         PES
  ON            PES.CAD_PES_ID_PESSOA   = PAC.CAD_PES_ID_PESSOA
  JOIN          TB_CAD_CNV_CONVENIO       CNV
  ON            CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
  JOIN          TB_CAD_PES_PESSOA         PES_CNV
  ON            PES_CNV.CAD_PES_ID_PESSOA = CNV.CAD_PES_ID_PESSOA
  JOIN          TB_CAD_PLA_PLANO          PLA
  ON            PLA.CAD_PLA_ID_PLANO    = PAC.CAD_PLA_ID_PLANO
  LEFT JOIN     TB_ATD_AIC_ATE_INT_COMPL  AIC
  ON            AIC.ATD_ATE_ID          = ATD.ATD_ATE_ID
  LEFT JOIN     TB_ATD_INA_INT_ALTA         INA
  ON            INA.ATD_ATE_ID            = ATD.ATD_ATE_ID
  JOIN          TB_CAD_UNI_UNIDADE          UNI
  ON            UNI.CAD_UNI_ID_UNIDADE    = ATD.CAD_UNI_ID_UNIDADE
  JOIN          TB_CAD_PES_PESSOA           PES_UNI
  ON            PES_UNI.CAD_PES_ID_PESSOA = UNI.CAD_PES_ID_PESSOA
  LEFT JOIN     TB_CAD_CID_CID10            CID_ATD
  ON            CID_ATD.CAD_CID_CD_CID10      = ATD.CAD_CID_CD_CID10
  LEFT JOIN     TB_ATD_IDG_INT_DIAGNOSTICO  IDG
  ON            IDG.ATD_ATE_ID            = ATD.ATD_ATE_ID
  LEFT JOIN     TB_CAD_CID_CID10            CID_PRI
  ON            CID_PRI.CAD_CID_CD_CID10  = IDG.ATD_IDG_CD_CIDPRINCIPAL
  LEFT JOIN     TB_CAD_CID_CID10            CID_SEC1
  ON            CID_SEC1.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC1
  LEFT JOIN     TB_CAD_CID_CID10            CID_SEC2
  ON            CID_SEC2.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC2
  LEFT JOIN     TB_CAD_CID_CID10            CID_SEC3
  ON            CID_SEC3.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC3
  LEFT JOIN     TB_CAD_CID_CID10            CID_SEC4
  ON            CID_SEC4.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC4
  LEFT JOIN     TB_CAD_CID_CID10            CID_SEC5
  ON            CID_SEC5.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC5
  LEFT JOIN     TB_TIS_TIN_TP_INTERNACAO    TIN
  ON            TIN.TIS_TIN_CD_INTERNACAO = AIC.TIS_TIN_CD_INTERNACAO
  LEFT JOIN     TB_TIS_TRI_TP_REGINTERNACAO TRI
  ON            TRI.TIS_TRI_CD_TP_REGINTERNACAO = AIC.TIS_TRI_CD_REGINTENNACAO
  LEFT JOIN     TB_ASS_CPE_CONV_PROD_EQUIVALE CPE
  ON            CPE.CAD_PRD_ID_DESTINO    = CCI.CAD_PRD_ID
  AND           CPE.CAD_CNV_ID_CONVENIO   = PAC.CAD_CNV_ID_CONVENIO
  AND           CPE.CAD_LAT_ID_LOCAL_ATENDIMENTO = ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO
  LEFT JOIN     TB_CAD_PRD_PRODUTO          PRD_ORI
  ON            PRD_ORI.CAD_PRD_ID        = CPE.CAD_PRD_ID_ORIGEM
  LEFT JOIN     TB_CAD_MPF_MOTI_PEND_FATURAR MPF
  ON            MPF.CAD_MPF_ID            = CCI.CAD_MPF_ID
  WHERE         CCI.ATD_ATE_ID = pATD_ATE_ID
  AND           CCI.FAT_CCP_ID IS NULL
  AND           CCI.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
  AND ((CCI.FAT_CCI_DT_INICIO_CONSUMO < pDATA AND ATD.ATD_ATE_TP_PACIENTE IN ('I'))
                            OR ATD.ATD_ATE_TP_PACIENTE IN ('A','U','E'))
  AND           ((CCI.FAT_CCI_FL_PACOTE IS NULL) OR (CCI.FAT_CCI_FL_PACOTE = 'N'))
  --AND           ((CCI.FAT_CCI_FL_KITPRA IS NULL) OR (CCI.FAT_CCI_FL_KITPRA = 'N'))
  AND           (PRD.TIS_MED_CD_TABELAMEDICA != 'IP')
  UNION
          SELECT
                4 ORDEM,
               ATD.ATD_ATE_ID,
               PAC.CAD_PAC_ID_PACIENTE,
               DECODE(ATD.ATD_ATE_TP_PACIENTE,'I','INTERNADO','E','EXTERNO','A','AMBULATORIO','U','PRONTO SOCORRO')
               ATD_ATE_TP_PACIENTE,
               DECODE(ATD.ATD_ATE_FL_CARATER_SOLIC,'U','URGENCIA','E','ELETIVA') ATD_ATE_FL_CARATER_SOLIC,
               TO_CHAR(ATD.ATD_ATE_DT_ATENDIMENTO,'DD/MM/YYYY') ATD_ATE_DT_ATENDIMENTO,
               ATD.ATD_ATE_HR_ATENDIMENTO,
               TO_CHAR(INA.ATD_INA_DT_ALTA_CLINICA,'DD/MM/YYYY') ATD_INA_DT_ALTA_CLINICA,
               INA.ATD_INA_HR_ALTA_CLINICA,
               CCI.FAT_COC_ID,
               CCI.FAT_CCP_ID,
               NULL coc_ccp_pac_atd,
               UNI.CAD_UNI_DS_UNIDADE UNIDADE,
               UNI.CAD_UNI_NR_CNES,
               PES_UNI.CAD_PES_NR_CNPJ_CPF,
               (SELECT  GUI.ATD_GUI_CD_SENHA
                  FROM    TB_ATD_GUI_GUIAATEND  GUI
                  WHERE   GUI.ATD_GUI_FL_GUIAPRINC_OK = 'S' AND ROWNUM = 1
                  AND GUI.ATD_ATE_ID = pATD_ATE_ID ) ATD_GUI_CD_CODIGO,
               (SELECT  GUI.ATD_GUI_CD_CODIGO
                  FROM    TB_ATD_GUI_GUIAATEND  GUI
                  WHERE   GUI.ATD_GUI_FL_GUIAPRINC_OK = 'S' AND ROWNUM = 1
                  AND GUI.ATD_ATE_ID = pATD_ATE_ID ) ATD_GUI_CD_SENHA,
               'M2' CAD_TAP_TP_ATRIBUTO,
               'FILME' CAD_TAP_DS_ATRIBUTO,
               '' FAT_CCP_MES_COMPET,
               '' FAT_CCP_ANO_COMPET,
               '' FAT_CCP_MES_FAT,
               '' FAT_CCP_ANO_FAT,
               '' TIS_MSI_DS_MOTIVOSAIDAINT,
               AIC.ATD_AIC_DS_EMPRESA,
               PAC.CAD_PAC_CD_CREDENCIAL,
               PAC.CAD_PAC_NR_PRONTUARIO,
               PES.CAD_PES_NM_PESSOA PACIENTE,
               TO_CHAR(PAC.CAD_PAC_DT_VALIDADECREDENCIAL,'DD/MM/YYYY') CAD_PAC_DT_VALIDADECREDENCIAL,
               PES.CAD_PES_NR_RG,
               PAC.CAD_PAC_NM_TITULAR,
               DECODE(AIC.ATD_AIC_TP_SITUACAO_PAC,'I','INTERNADO','A','ALTA') ATD_AIC_TP_SITUACAO_PAC,
               CNV.CAD_CNV_CD_HAC_PRESTADOR,
               CNV.CAD_CNV_NM_FANTASIA,
             --  PES_CNV.CAD_PES_NR_CNPJ_CPF
               PLA.CAD_PLA_CD_TIPOPLANO,
               PLA.CAD_PLA_CD_PLANO_HAC,
               PLA.CAD_PLA_NM_NOME_PLANO,
               NULL PROFISSIONAL,
               NULL CAD_PRO_NR_CONSELHO,
               NULL CAD_PRO_SG_UF_CONSELHO,
               CASE WHEN CID_PRI.CAD_CID_DS_CID10 IS NULL THEN
                         CID_ATD.CAD_CID_DS_CID10
                    ELSE CID_PRI.CAD_CID_DS_CID10
               END CID_PRINCIPAL,
               --CASE WHEN (ATD.ATD_ATE_TP_PACIENTE = 'A' OR ATD.ATD_ATE_TP_PACIENTE = 'U') AND CID_SEC1.CAD_CID_DS_CID10 IS NULL
               --     THEN CID_ATD.CAD_CID_DS_CID10
              --      ELSE CID_SEC1.CAD_CID_DS_CID10
             --  END CID_SECUNDARIO,
               CID_SEC1.CAD_CID_DS_CID10 CID_SECUNDARIO,
               CID_SEC2.CAD_CID_DS_CID10 CID_SECUNDARIO2,
               CID_SEC3.CAD_CID_DS_CID10 CID_SECUNDARIO3,
               CID_SEC4.CAD_CID_DS_CID10 CID_SECUNDARIO4,
               CID_SEC5.CAD_CID_DS_CID10 CID_SECUNDARIO5,
               CASE WHEN CID_PRI.CAD_CID_DS_CID10 IS NULL THEN
                         CID_ATD.CAD_CID_CD_CID10
                    ELSE CID_PRI.CAD_CID_CD_CID10
               END CAD_CID_CD_CID10_PRI,
               CID_SEC1.CAD_CID_CD_CID10 CAD_CID_CD_CID10_1,
               CID_SEC2.CAD_CID_CD_CID10 CAD_CID_CD_CID10_2,
               CID_SEC3.CAD_CID_CD_CID10 CAD_CID_CD_CID10_3,
               CID_SEC4.CAD_CID_CD_CID10 CAD_CID_CD_CID10_4,
               CID_SEC5.CAD_CID_CD_CID10 CAD_CID_CD_CID10_5,
               TIN.TIS_TIN_DS_INTERNACAO,
               TRI.TIS_TRI_DS_TP_REGINTERNACAO,
--               APM.CAD_APM_DS_PRODUTO,
               NULL CAD_PRD_CD_CODIGO,
               NULL CAD_PRD_NM_MNEMONICO,
               NULL  DS_PRD,
               'METRO QUADRADO DE FILME' CAD_PRD_DS_DESCRICAO,
               NULL AUX_EPP_DS_DESCRICAO,
               NULL  CAD_PRD_CD_CODIGO_ORIGEM,
               NULL  FAT_CCI_DT_INICIO_CONSUMO,
               NULL FAT_CCI_HR_INICIO_CONSUMO,
               NULL FAT_CCI_DT_FIM_CONSUMO,
               NULL FAT_CCI_HR_FIM_CONSUMO,
              -- CCI.FAT_CCI_QT_CONSUMO,
             -- trunc(CCI.FAT_CCI_VL_FATURADO,2) FAT_CCI_VL_FATURADO,
               NULL  FAT_CCI_QT_CONSUMO,
               NULL  FAT_CCI_VL_FATURADO_ORIGINAL,
               nvl(M2.TOTAL_FILME,0)  FAT_CCI_VL_FATURADO,
               NULL  FAT_CCI_VL_UNITARIO,
              NULL  TIS_GPP_CD_GRAU_PART_PROF,
               NULL TIS_GPP_DS_GRAU_PART_PROF,
               NULL TIS_GPP_PC_GRAU_PART_PROF,
               NULL FAT_CCI_TP_PORTEANESTESICO,
               NULL CAD_MPF_DS_MOTI_PEND_FATURAR,
              NULL FAT_CCI_TP_CREDENCIA_PROF,
               NVL((SELECT SUM(CCI.FAT_CCI_VL_FATURADO)
                     FROM                TB_FAT_CCI_CONTA_CONSU_ITEM CCI
                    WHERE  CCI.CAD_TAP_TP_ATRIBUTO = 'MED'
                      AND CCI.FAT_CCI_FL_STATUS = 'A'
                       AND ((CCI.FAT_CCI_FL_PACOTE IS NULL) OR (CCI.FAT_CCI_FL_PACOTE = 'N'))
                    --  AND ((CCI.FAT_CCI_FL_KITPRA IS NULL) OR (CCI.FAT_CCI_FL_KITPRA = 'N'))
                      AND CCI.FAT_CCP_ID IS NULL
                      AND CCI.ATD_ATE_ID = pATD_ATE_ID
                      AND CCI.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
                      AND ((CCI.FAT_CCI_DT_INICIO_CONSUMO < pDATA AND ATD.ATD_ATE_TP_PACIENTE IN ('I'))
                            OR ATD.ATD_ATE_TP_PACIENTE IN ('A','U','E'))
                  ),0) TOTAL_MED,
               NVL((SELECT SUM(CCI.FAT_CCI_VL_FATURADO)
                     FROM                TB_FAT_CCI_CONTA_CONSU_ITEM CCI
                    WHERE  CCI.CAD_TAP_TP_ATRIBUTO = 'MAT'
                      AND CCI.FAT_CCI_FL_STATUS = 'A'
                      AND ((CCI.FAT_CCI_FL_PACOTE IS NULL) OR (CCI.FAT_CCI_FL_PACOTE = 'N'))
                    --  AND ((CCI.FAT_CCI_FL_KITPRA IS NULL) OR (CCI.FAT_CCI_FL_KITPRA = 'N'))
                      AND CCI.FAT_CCP_ID IS NULL
                      AND CCI.ATD_ATE_ID = pATD_ATE_ID
                      AND CCI.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
                      AND ((CCI.FAT_CCI_DT_INICIO_CONSUMO < pDATA AND ATD.ATD_ATE_TP_PACIENTE IN ('I'))
                            OR ATD.ATD_ATE_TP_PACIENTE IN ('A','U','E'))
                  ),0) TOTAL_MAT
  FROM
                TB_ATD_ATE_ATENDIMENTO      ATD
  JOIN          TB_FAT_CCI_CONTA_CONSU_ITEM CCI
  ON            CCI.ATD_ATE_ID            = ATD.ATD_ATE_ID
  AND           CCI.FAT_CCI_FL_STATUS     = 'A'
  AND           CCI.CAD_TAP_TP_ATRIBUTO IN ('M2')
  LEFT JOIN     TB_CAD_PRD_PRODUTO          PRD
  ON            PRD.CAD_PRD_ID            = CCI.CAD_PRD_ID
  JOIN          TB_CAD_PAC_PACIENTE       PAC
  ON            PAC.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
  JOIN          TB_CAD_PES_PESSOA         PES
  ON            PES.CAD_PES_ID_PESSOA   = PAC.CAD_PES_ID_PESSOA
  JOIN          TB_CAD_CNV_CONVENIO       CNV
  ON            CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
  JOIN          TB_CAD_PES_PESSOA         PES_CNV
  ON            PES_CNV.CAD_PES_ID_PESSOA = CNV.CAD_PES_ID_PESSOA
  JOIN          TB_CAD_PLA_PLANO          PLA
  ON            PLA.CAD_PLA_ID_PLANO    = PAC.CAD_PLA_ID_PLANO
  LEFT JOIN     TB_ATD_AIC_ATE_INT_COMPL  AIC
  ON            AIC.ATD_ATE_ID          = ATD.ATD_ATE_ID
  LEFT JOIN     TB_ATD_INA_INT_ALTA         INA
  ON            INA.ATD_ATE_ID            = ATD.ATD_ATE_ID
  JOIN          TB_CAD_UNI_UNIDADE          UNI
  ON            UNI.CAD_UNI_ID_UNIDADE    = ATD.CAD_UNI_ID_UNIDADE
  JOIN          TB_CAD_PES_PESSOA           PES_UNI
  ON            PES_UNI.CAD_PES_ID_PESSOA = UNI.CAD_PES_ID_PESSOA
  LEFT JOIN     TB_CAD_CID_CID10            CID_ATD
  ON            CID_ATD.CAD_CID_CD_CID10      = ATD.CAD_CID_CD_CID10
  LEFT JOIN     TB_ATD_IDG_INT_DIAGNOSTICO  IDG
  ON            IDG.ATD_ATE_ID            = ATD.ATD_ATE_ID
  LEFT JOIN     TB_CAD_CID_CID10            CID_PRI
  ON            CID_PRI.CAD_CID_CD_CID10  = IDG.ATD_IDG_CD_CIDPRINCIPAL
  LEFT JOIN     TB_CAD_CID_CID10            CID_SEC1
  ON            CID_SEC1.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC1
  LEFT JOIN     TB_CAD_CID_CID10            CID_SEC2
  ON            CID_SEC2.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC2
  LEFT JOIN     TB_CAD_CID_CID10            CID_SEC3
  ON            CID_SEC3.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC3
  LEFT JOIN     TB_CAD_CID_CID10            CID_SEC4
  ON            CID_SEC4.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC4
  LEFT JOIN     TB_CAD_CID_CID10            CID_SEC5
  ON            CID_SEC5.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC5
  LEFT JOIN     TB_TIS_TIN_TP_INTERNACAO    TIN
  ON            TIN.TIS_TIN_CD_INTERNACAO = AIC.TIS_TIN_CD_INTERNACAO
  LEFT JOIN     TB_TIS_TRI_TP_REGINTERNACAO TRI
  ON            TRI.TIS_TRI_CD_TP_REGINTERNACAO = AIC.TIS_TRI_CD_REGINTENNACAO
  LEFT JOIN     (SELECT SUM(CCI.FAT_CCI_VL_FATURADO) TOTAL_FILME,
                        CCI.ATD_ATE_ID,  CCI.CAD_PAC_ID_PACIENTE
                   FROM    TB_FAT_CCI_CONTA_CONSU_ITEM CCI, TB_ATD_ATE_ATENDIMENTO ATD
                    WHERE  CCI.CAD_TAP_TP_ATRIBUTO = 'M2'
                    AND ATD.ATD_ATE_ID = CCI.ATD_ATE_ID
                    AND CCI.FAT_CCI_FL_STATUS = 'A'
                    AND ((CCI.FAT_CCI_FL_PACOTE IS NULL) OR (CCI.FAT_CCI_FL_PACOTE = 'N'))
                 --  AND ((CCI.FAT_CCI_FL_KITPRA IS NULL) OR (CCI.FAT_CCI_FL_KITPRA = 'N'))
                    AND CCI.FAT_CCP_ID IS NULL
                    AND ((CCI.FAT_CCI_DT_INICIO_CONSUMO < pDATA AND ATD.ATD_ATE_TP_PACIENTE IN ('I'))
                            OR ATD.ATD_ATE_TP_PACIENTE IN ('A','U','E'))
                    GROUP BY CCI.ATD_ATE_ID, CCI.CAD_PAC_ID_PACIENTE
                ) M2
  ON            M2.ATD_ATE_ID = CCI.ATD_ATE_ID
  AND           M2.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
  WHERE         CCI.ATD_ATE_ID = pATD_ATE_ID
  AND           CCI.FAT_CCP_ID IS NULL
  AND           CCI.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
  AND ((CCI.FAT_CCI_DT_INICIO_CONSUMO < pDATA AND ATD.ATD_ATE_TP_PACIENTE IN ('I'))
                            OR ATD.ATD_ATE_TP_PACIENTE IN ('A','U','E'))
  AND           ((CCI.FAT_CCI_FL_PACOTE IS NULL) OR (CCI.FAT_CCI_FL_PACOTE = 'N'))
  --AND           ((CCI.FAT_CCI_FL_KITPRA IS NULL) OR (CCI.FAT_CCI_FL_KITPRA = 'N'))
  AND           (nvl(M2.TOTAL_FILME,0) > 0)
 UNION
          SELECT
                9 ORDEM,
               ATD.ATD_ATE_ID,
               PAC.CAD_PAC_ID_PACIENTE,
               DECODE(ATD.ATD_ATE_TP_PACIENTE,'I','INTERNADO','E','EXTERNO','A','AMBULATORIO','U','PRONTO SOCORRO')
               ATD_ATE_TP_PACIENTE,
               DECODE(ATD.ATD_ATE_FL_CARATER_SOLIC,'U','URGENCIA','E','ELETIVA') ATD_ATE_FL_CARATER_SOLIC,
               TO_CHAR(ATD.ATD_ATE_DT_ATENDIMENTO,'DD/MM/YYYY') ATD_ATE_DT_ATENDIMENTO,
               ATD.ATD_ATE_HR_ATENDIMENTO,
               TO_CHAR(INA.ATD_INA_DT_ALTA_CLINICA,'DD/MM/YYYY') ATD_INA_DT_ALTA_CLINICA,
               INA.ATD_INA_HR_ALTA_CLINICA,
               CCI.FAT_COC_ID,
               CCI.FAT_CCP_ID,
               NULL coc_ccp_pac_atd,
               UNI.CAD_UNI_DS_UNIDADE UNIDADE,
               UNI.CAD_UNI_NR_CNES,
               PES_UNI.CAD_PES_NR_CNPJ_CPF,
               (SELECT  GUI.ATD_GUI_CD_SENHA
                  FROM    TB_ATD_GUI_GUIAATEND  GUI
                  WHERE   GUI.ATD_GUI_FL_GUIAPRINC_OK = 'S' AND ROWNUM = 1
                  AND GUI.ATD_ATE_ID = pATD_ATE_ID ) ATD_GUI_CD_CODIGO,
               (SELECT  GUI.ATD_GUI_CD_CODIGO
                  FROM    TB_ATD_GUI_GUIAATEND  GUI
                  WHERE   GUI.ATD_GUI_FL_GUIAPRINC_OK = 'S' AND ROWNUM = 1
                  AND GUI.ATD_ATE_ID = pATD_ATE_ID ) ATD_GUI_CD_SENHA,
               'MM' CAD_TAP_TP_ATRIBUTO,
               'MATMED' CAD_TAP_DS_ATRIBUTO,
               '' FAT_CCP_MES_COMPET,
               '' FAT_CCP_ANO_COMPET,
               '' FAT_CCP_MES_FAT,
               '' FAT_CCP_ANO_FAT,
               '' TIS_MSI_DS_MOTIVOSAIDAINT,
               AIC.ATD_AIC_DS_EMPRESA,
               PAC.CAD_PAC_CD_CREDENCIAL,
               PAC.CAD_PAC_NR_PRONTUARIO,
               PES.CAD_PES_NM_PESSOA PACIENTE,
               TO_CHAR(PAC.CAD_PAC_DT_VALIDADECREDENCIAL,'DD/MM/YYYY') CAD_PAC_DT_VALIDADECREDENCIAL,
               PES.CAD_PES_NR_RG,
               PAC.CAD_PAC_NM_TITULAR,
               DECODE(AIC.ATD_AIC_TP_SITUACAO_PAC,'I','INTERNADO','A','ALTA') ATD_AIC_TP_SITUACAO_PAC,
               CNV.CAD_CNV_CD_HAC_PRESTADOR,
               CNV.CAD_CNV_NM_FANTASIA,
             --  PES_CNV.CAD_PES_NR_CNPJ_CPF
               PLA.CAD_PLA_CD_TIPOPLANO,
               PLA.CAD_PLA_CD_PLANO_HAC,
               PLA.CAD_PLA_NM_NOME_PLANO,
               NULL PROFISSIONAL,
               NULL CAD_PRO_NR_CONSELHO,
               NULL CAD_PRO_SG_UF_CONSELHO,
               CASE WHEN CID_PRI.CAD_CID_DS_CID10 IS NULL THEN
                         CID_ATD.CAD_CID_DS_CID10
                    ELSE CID_PRI.CAD_CID_DS_CID10
               END CID_PRINCIPAL,
               --CASE WHEN (ATD.ATD_ATE_TP_PACIENTE = 'A' OR ATD.ATD_ATE_TP_PACIENTE = 'U') AND CID_SEC1.CAD_CID_DS_CID10 IS NULL
               --     THEN CID_ATD.CAD_CID_DS_CID10
              --      ELSE CID_SEC1.CAD_CID_DS_CID10
             --  END CID_SECUNDARIO,
               CID_SEC1.CAD_CID_DS_CID10 CID_SECUNDARIO,
               CID_SEC2.CAD_CID_DS_CID10 CID_SECUNDARIO2,
               CID_SEC3.CAD_CID_DS_CID10 CID_SECUNDARIO3,
               CID_SEC4.CAD_CID_DS_CID10 CID_SECUNDARIO4,
               CID_SEC5.CAD_CID_DS_CID10 CID_SECUNDARIO5,
               CASE WHEN CID_PRI.CAD_CID_DS_CID10 IS NULL THEN
                         CID_ATD.CAD_CID_CD_CID10
                    ELSE CID_PRI.CAD_CID_CD_CID10
               END CAD_CID_CD_CID10_PRI,
               CID_SEC1.CAD_CID_CD_CID10 CAD_CID_CD_CID10_1,
               CID_SEC2.CAD_CID_CD_CID10 CAD_CID_CD_CID10_2,
               CID_SEC3.CAD_CID_CD_CID10 CAD_CID_CD_CID10_3,
               CID_SEC4.CAD_CID_CD_CID10 CAD_CID_CD_CID10_4,
               CID_SEC5.CAD_CID_CD_CID10 CAD_CID_CD_CID10_5,
               TIN.TIS_TIN_DS_INTERNACAO,
               TRI.TIS_TRI_DS_TP_REGINTERNACAO,
--               APM.CAD_APM_DS_PRODUTO,
               NULL CAD_PRD_CD_CODIGO,
               NULL CAD_PRD_NM_MNEMONICO,
               NULL  DS_PRD,
               NULL CAD_PRD_DS_DESCRICAO,
               NULL AUX_EPP_DS_DESCRICAO,
               NULL  CAD_PRD_CD_CODIGO_ORIGEM,
               NULL  FAT_CCI_DT_INICIO_CONSUMO,
               NULL FAT_CCI_HR_INICIO_CONSUMO,
               NULL FAT_CCI_DT_FIM_CONSUMO,
               NULL FAT_CCI_HR_FIM_CONSUMO,
              -- CCI.FAT_CCI_QT_CONSUMO,
             -- trunc(CCI.FAT_CCI_VL_FATURADO,2) FAT_CCI_VL_FATURADO,
               NULL  FAT_CCI_QT_CONSUMO,
               NULL  FAT_CCI_VL_FATURADO_ORIGINAL,
               NULL  FAT_CCI_VL_FATURADO,
               NULL  FAT_CCI_VL_UNITARIO,
              NULL  TIS_GPP_CD_GRAU_PART_PROF,
               NULL TIS_GPP_DS_GRAU_PART_PROF,
               NULL TIS_GPP_PC_GRAU_PART_PROF,
               NULL FAT_CCI_TP_PORTEANESTESICO,
               NULL CAD_MPF_DS_MOTI_PEND_FATURAR,
              NULL FAT_CCI_TP_CREDENCIA_PROF,
               NVL((SELECT SUM(CCI.FAT_CCI_VL_FATURADO)
                     FROM                TB_FAT_CCI_CONTA_CONSU_ITEM CCI
                    WHERE  CCI.CAD_TAP_TP_ATRIBUTO = 'MED'
                      AND CCI.FAT_CCI_FL_STATUS = 'A'
                       AND ((CCI.FAT_CCI_FL_PACOTE IS NULL) OR (CCI.FAT_CCI_FL_PACOTE = 'N'))
                --      AND ((CCI.FAT_CCI_FL_KITPRA IS NULL) OR (CCI.FAT_CCI_FL_KITPRA = 'N'))
                      AND CCI.FAT_CCP_ID IS NULL
                      AND CCI.ATD_ATE_ID = pATD_ATE_ID
                      AND CCI.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
                      AND ((CCI.FAT_CCI_DT_INICIO_CONSUMO < pDATA AND ATD.ATD_ATE_TP_PACIENTE IN ('I'))
                            OR ATD.ATD_ATE_TP_PACIENTE IN ('A','U','E'))
                  ),0) TOTAL_MED,
               NVL((SELECT SUM(CCI.FAT_CCI_VL_FATURADO)
                     FROM                TB_FAT_CCI_CONTA_CONSU_ITEM CCI
                    WHERE  CCI.CAD_TAP_TP_ATRIBUTO = 'MAT'
                      AND CCI.FAT_CCI_FL_STATUS = 'A'
                       AND ((CCI.FAT_CCI_FL_PACOTE IS NULL) OR (CCI.FAT_CCI_FL_PACOTE = 'N'))
                  --    AND ((CCI.FAT_CCI_FL_KITPRA IS NULL) OR (CCI.FAT_CCI_FL_KITPRA = 'N'))
                      AND CCI.FAT_CCP_ID IS NULL
                      AND CCI.ATD_ATE_ID = pATD_ATE_ID
                      AND CCI.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
                      AND ((CCI.FAT_CCI_DT_INICIO_CONSUMO < pDATA AND ATD.ATD_ATE_TP_PACIENTE IN ('I'))
                            OR ATD.ATD_ATE_TP_PACIENTE IN ('A','U','E'))
                  ),0) TOTAL_MAT
  FROM
                TB_ATD_ATE_ATENDIMENTO      ATD
  JOIN          TB_FAT_CCI_CONTA_CONSU_ITEM CCI
  ON            CCI.ATD_ATE_ID            = ATD.ATD_ATE_ID
  AND           CCI.FAT_CCI_FL_STATUS     = 'A'
  AND           CCI.CAD_TAP_TP_ATRIBUTO IN ('MAT','MED')
  LEFT JOIN     TB_CAD_PRD_PRODUTO          PRD
  ON            PRD.CAD_PRD_ID            = CCI.CAD_PRD_ID
  JOIN          TB_CAD_PAC_PACIENTE       PAC
  ON            PAC.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
  JOIN          TB_CAD_PES_PESSOA         PES
  ON            PES.CAD_PES_ID_PESSOA   = PAC.CAD_PES_ID_PESSOA
  JOIN          TB_CAD_CNV_CONVENIO       CNV
  ON            CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
  JOIN          TB_CAD_PES_PESSOA         PES_CNV
  ON            PES_CNV.CAD_PES_ID_PESSOA = CNV.CAD_PES_ID_PESSOA
  JOIN          TB_CAD_PLA_PLANO          PLA
  ON            PLA.CAD_PLA_ID_PLANO    = PAC.CAD_PLA_ID_PLANO
  LEFT JOIN     TB_ATD_AIC_ATE_INT_COMPL  AIC
  ON            AIC.ATD_ATE_ID          = ATD.ATD_ATE_ID
  LEFT JOIN     TB_ATD_INA_INT_ALTA         INA
  ON            INA.ATD_ATE_ID            = ATD.ATD_ATE_ID
  JOIN          TB_CAD_UNI_UNIDADE          UNI
  ON            UNI.CAD_UNI_ID_UNIDADE    = ATD.CAD_UNI_ID_UNIDADE
  JOIN          TB_CAD_PES_PESSOA           PES_UNI
  ON            PES_UNI.CAD_PES_ID_PESSOA = UNI.CAD_PES_ID_PESSOA
  LEFT JOIN     TB_CAD_CID_CID10            CID_ATD
  ON            CID_ATD.CAD_CID_CD_CID10      = ATD.CAD_CID_CD_CID10
  LEFT JOIN     TB_ATD_IDG_INT_DIAGNOSTICO  IDG
  ON            IDG.ATD_ATE_ID            = ATD.ATD_ATE_ID
  LEFT JOIN     TB_CAD_CID_CID10            CID_PRI
  ON            CID_PRI.CAD_CID_CD_CID10  = IDG.ATD_IDG_CD_CIDPRINCIPAL
  LEFT JOIN     TB_CAD_CID_CID10            CID_SEC1
  ON            CID_SEC1.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC1
  LEFT JOIN     TB_CAD_CID_CID10            CID_SEC2
  ON            CID_SEC2.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC2
  LEFT JOIN     TB_CAD_CID_CID10            CID_SEC3
  ON            CID_SEC3.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC3
  LEFT JOIN     TB_CAD_CID_CID10            CID_SEC4
  ON            CID_SEC4.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC4
  LEFT JOIN     TB_CAD_CID_CID10            CID_SEC5
  ON            CID_SEC5.CAD_CID_CD_CID10 = IDG.ATD_IDG_CD_CIDSEC5
  LEFT JOIN     TB_TIS_TIN_TP_INTERNACAO    TIN
  ON            TIN.TIS_TIN_CD_INTERNACAO = AIC.TIS_TIN_CD_INTERNACAO
  LEFT JOIN     TB_TIS_TRI_TP_REGINTERNACAO TRI
  ON            TRI.TIS_TRI_CD_TP_REGINTERNACAO = AIC.TIS_TRI_CD_REGINTENNACAO
  WHERE         CCI.ATD_ATE_ID = pATD_ATE_ID
  AND           CCI.FAT_CCP_ID IS NULL
  AND           CCI.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
  AND ((CCI.FAT_CCI_DT_INICIO_CONSUMO < pDATA AND ATD.ATD_ATE_TP_PACIENTE IN ('I'))
                            OR ATD.ATD_ATE_TP_PACIENTE IN ('A','U','E'))
  AND           ((CCI.FAT_CCI_FL_PACOTE IS NULL) OR (CCI.FAT_CCI_FL_PACOTE = 'N'))
  AND           ROWNUM = 1
  --AND           ((CCI.FAT_CCI_FL_KITPRA IS NULL) OR (CCI.FAT_CCI_FL_KITPRA = 'N'))
       ORDER BY 1,57;
             io_cursor := v_cursor;
  end PRC_FAT_REL_PREVIA;
