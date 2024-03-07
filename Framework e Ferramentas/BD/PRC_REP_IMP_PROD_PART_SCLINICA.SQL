CREATE OR REPLACE PROCEDURE SGS.PRC_REP_IMP_PROD_PART_SCLINICA (pFAT_CCI_DT_INICIO_CONSUMO_INI          IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE,
                                                                pFAT_CCI_DT_INICIO_CONSUMO_FIM          IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE,
                                                                pUSUARIO_IMPORTACAO                     IN TB_ATD_ATE_ATENDIMENTO.SEG_USU_ID_USUARIO%TYPE,
                                                                pREP_PGM_MES_PAGTO                      IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
                                                                pREP_PGM_ANO_PAGTO                      IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE) IS
  /********************************************************************
  *    PROCEDURE: PRC_REP_IMP_PROD_PART_SCLINICA
  *
  *    DATA CRIACAO:    26/02/2013         POR:
  *    DATA ALTERACAO:  DATA DA ALTERAÇÃO  POR: NOME DO ANALISTA
  *
  *    FUNCAO: IMPORTAR PRODUTIVIDADE PASSANDO CLINICA UNIDADE E LOCAL [P3]
  *
  *******************************************************************/
BEGIN
  ---IMPORTAÇÃO PARTICULAR
  FOR T IN ( SELECT DISTINCT ATD.ATD_ATE_ID,
                    ATD.ATD_ATE_FL_REPASSE_STATUS,
                    CCI.FAT_CCP_ID,
                    CCI.FAT_COC_ID,
                    CCI.CAD_TAP_TP_ATRIBUTO,
                    CCI.CAD_PRD_ID,
                    CCI.CAD_TIH_TP_INDICE_HOSP,
                    CCI.FAT_CCI_QT_INDICE,
                    CCI.FAT_CCI_VL_INDICE,
                    CCI.FAT_CCI_VL_UNITARIO,
                    CCI.FAT_CCI_DT_INICIO_CONSUMO DT_REALIZACAO,
                    CCI.FAT_CCI_HR_INICIO_CONSUMO,
                    (NVL(CCI.FAT_CCI_VL_FATURADO, 0)) VL_FATURADO,
                    (CCI.FAT_CCI_QT_CONSUMO) QTD,
                    -- CCI.CAD_PRO_ID_PROFISSIONAL,
                    APL.CAD_PRO_ID_PROF  CAD_PRO_ID_PROFISSIONAL,
                    PROLAUDA.CAD_PRO_NR_CONSELHO,
                    PROLAUDA.CAD_PRO_NM_NOME,
                    CCI.FAT_CCI_PC_GRAU_PART_PROF,
                    SYSDATE REP_PGM_DT_ULTIMA_ATUALIZACAO,
                    (NVL(CCI.FAT_CCI_VL_CALCULADO, 0)) VL_CALCULADO,
                    CCI.CAD_PAC_ID_PACIENTE,
                    --CCI.FAT_CCI_TP_CREDENCIA_PROF,
                    'MF' FAT_CCI_TP_CREDENCIA_PROF ,
                    CCI.FAT_CCI_FL_PACOTE,
                    CCI.CAD_CEC_ID_CCUSTO,
                    CCI.CAD_CAC_ID_CLASSCONTABIL,
                    CCI.FAT_CCI_MES_FECHAMENTO,
                    CCI.FAT_CCI_ANO_FECHAMENTO,
                    SYSDATE,
                    ATD.CAD_UNI_ID_UNIDADE,
                    ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                    'F',
                    MCC.CAD_SET_ID,
                    PAC.CAD_CNV_ID_CONVENIO,
                    CCI.FAT_CCI_PC_ACOMODACAO_HM,
                    CCI.FAT_CCI_CD_CLINICA_PROF,
                    PLA.CAD_PLA_CD_TIPOPLANO,
                    PRD.AUX_EPP_CD_ESPECPROC,
                    PRD.AUX_GPC_CD_GRUPOPROC,
                    PRD.TIS_MED_CD_TABELAMEDICA,
                    ATD.ATD_ATE_FL_RETORNO_OK,
                    ATD.TIS_CBO_CD_CBOS,
                    ATD.ATD_ATE_TP_PACIENTE,
                    CCI.FAT_CCI_ID,
                     CASE
                      WHEN ATD.ATD_ATE_TP_PACIENTE IN ('A', 'U') THEN
                       ATD.TIS_CBO_CD_CBOS
                      ELSE
                       NULL
                    END,
                    CNV.CAD_TPE_CD_CODIGO,
                    CPR.CAD_CLC_ID,
                    CLC.CAD_CLC_CD_CLINICA,
                    CLC.CAD_CLC_DS_DESCRICAO
               FROM TB_FAT_CCI_CONTA_CONSU_ITEM     CCI,
                    TB_CAD_CNV_CONVENIO             CNV,
                    TB_CAD_PAC_PACIENTE             PAC,
                    TB_ATD_ATE_ATENDIMENTO          ATD,
                    TB_CAD_PES_PESSOA               PES,
                    TB_CAD_PLA_PLANO                PLA,
                    TB_FAT_MCC_MOV_COM_CONSUMO      MCC,
                    TB_CAD_PRD_PRODUTO              PRD,
                    TB_FAT_CCP_CONTA_CONS_PARC      CCP,
                    TB_ATS_APL_ATEN_PROCED_LAUDO    APL,
                    TB_ATS_ATE_ATENDIMENTO_SADT     ATS,
                    TB_ASS_CPR_CLINICA_PROF         CPR,
                    TB_CAD_CLC_CLINICA_CREDENCIADA  CLC,
                    TB_CAD_PRO_PROFISSIONAL         PROLAUDA
              WHERE ATD.ATD_ATE_ID = CCI.ATD_ATE_ID
                AND PAC.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
                AND PRD.CAD_PRD_ID = CCI.CAD_PRD_ID
                AND PAC.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
                AND PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA
                AND PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
                AND CCI.CAD_PRD_ID = PRD.CAD_PRD_ID
                AND MCC.ATD_ATE_ID = CCI.ATD_ATE_ID
                AND MCC.FAT_MCC_ID = CCI.FAT_MCC_ID
                AND CNV.CAD_CNV_ID_CONVENIO = PLA.CAD_CNV_ID_CONVENIO
                AND CCI.CAD_TAP_TP_ATRIBUTO IN ('EXA', 'HM', 'TAX')
                AND ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (30, 27, 34)
                AND CCI.FAT_CCI_FL_STATUS <> 'C'
                AND CCI.FAT_CCI_FL_STATUS = 'A'
                AND ATD.ATD_ATE_FL_STATUS = 'A'
                AND CCI.ATD_ATE_ID = APL.ATS_ATE_CD_INTLIB
                AND ATS.ATS_ATE_CD_INTLIB = APL.ATS_ATE_CD_INTLIB
                AND ATS.AUX_EPP_CD_ESPECPROC = APL.AUX_EPP_CD_ESPECPROC
                AND ATS.TIS_MED_CD_TABELAMEDICA = APL.TIS_MED_CD_TABELAMEDICA
                AND ATS.ATS_ATE_IN_INTLIB = APL.ATS_ATE_IN_INTLIB
                AND ATS.CAD_PRD_ID = APL.CAD_PRD_ID
                AND APL.CAD_PRO_ID_PROF = PROLAUDA.CAD_PRO_ID_PROFISSIONAL
                AND CPR.CAD_CLC_ID = CLC.CAD_CLC_ID
                AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                AND CPR.CAD_PRO_ID_PROFISSIONAL = APL.CAD_PRO_ID_PROF
                AND CLC.CAD_CLC_CD_CLINICA IN (28,39,25)
                AND TRUNC(CCI.FAT_CCI_DT_INICIO_CONSUMO) = TRUNC(ATS.ATS_ATE_DT_REALIZ_PROCED)
                AND TRUNC(ATD.ATD_ATE_DT_ATENDIMENTO) BETWEEN pFAT_CCI_DT_INICIO_CONSUMO_INI AND pFAT_CCI_DT_INICIO_CONSUMO_FIM
                AND PRD.AUX_EPP_CD_ESPECPROC IN ('406','408','409','410','411')
                AND CCP.FAT_NOF_ID IS NOT NULL
                AND ATD.ATD_ATE_TP_PACIENTE IN ('A', 'U')
                AND CCI.FAT_CCI_CD_CLINICA_PROF IS NULL
                AND CCI.CAD_PRO_ID_PROFISSIONAL IS NOT NULL
                AND CNV.CAD_TPE_CD_CODIGO = 'PA'
                AND CCP.FAT_CCP_ID = CCI.FAT_CCP_ID
                AND CCP.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
                AND CCP.ATD_ATE_ID = CCI.ATD_ATE_ID
                AND CCP.FAT_COC_ID = CCI.FAT_COC_ID
                AND (CCI.FAT_CCI_FL_IMPORTADO_REPASSE = 'N' OR CCI.FAT_CCI_FL_IMPORTADO_REPASSE IS NULL) ) LOOP
      BEGIN
      INSERT INTO TB_REP_PGM_PAGTO_MEDICO
        (ATD_ATE_ID,
         FAT_CCP_ID,
         FAT_COC_ID,
         CAD_TAP_TP_ATRIBUTO,
         CAD_PRD_ID,
         CAD_TIH_TP_INDICE_HOSP,
         REP_PGM_QT_INDICE,
         REP_PGM_VL_INDICE,
         REP_PGM_VL_UNITARIO,
         REP_PGM_DT_INICIO_REALIZACAO,
         REP_PGM_HR_INICIO_REALIZACAO,
         REP_PGM_VL_FATURADO,
         REP_PGM_QT_CONSUMO,
         CAD_PRO_ID_PROFISSIONAL,
         REP_PGM_PC_GRAU_PART_PROF,
         REP_PGM_DT_ULTIMA_ATUALIZACAO,
         REP_PGM_VL_CALCULADO,
         CAD_PAC_ID_PACIENTE,
         REP_PGM_TP_CREDENCIA_PROF,
         REP_PGM_FL_PACOTE,
         CAD_CEC_ID_CCUSTO,
         CAD_CAC_ID_CLASSCONTABIL,
         REP_PGM_MES_FECHAMENTO,
         REP_PGM_ANO_FECHAMENTO,
         SEG_USU_ID_USUARIO_CRIACAO,
         REP_PGM_DT_CRIACAO,
         CAD_UNI_ID_UNIDADE,
         CAD_LAT_ID_LOCAL_ATENDIMENTO,
         REP_PGM_CD_ORIGEM,
         REP_PGM_ID,
         CAD_SET_ID_REALIZACAO,
         CAD_SET_ID_MOVIMENTACAO,
         FAT_CCI_PC_ACOMODACAO_HM,
         CAD_CNV_ID_CONVENIO,
         CAD_PLA_CD_TIPOPLANO,
         AUX_EPP_CD_ESPECPROC,
         AUX_GPC_CD_GRUPOPROC,
         TIS_MED_CD_TABELAMEDICA,
         REP_PGM_FL_ATENDIMENTO_RETORNO,
         REP_PGM_MES_PAGTO,
         REP_PGM_ANO_PAGTO,
         REP_PGM_FL_STATUS,
         FAT_CCI_ID,
         CAD_TPE_CD_CODIGO,
         TIS_CBO_CD_CBOS,
         REP_PGM_FONTE_PAGADORA,
         REP_PGM_CD_JUSTIFICATIVA,
         CAD_CLC_ID,
         REP_PGM_FL_PAGO)
      -------
      VALUES
      -----
        (T.ATD_ATE_ID,
         T.FAT_CCP_ID,
         T.FAT_COC_ID,
         T.CAD_TAP_TP_ATRIBUTO,
         T.CAD_PRD_ID,
         T.CAD_TIH_TP_INDICE_HOSP,
         T.FAT_CCI_QT_INDICE,
         T.FAT_CCI_VL_INDICE,
         T.FAT_CCI_VL_UNITARIO,
         T.DT_REALIZACAO,
         T.FAT_CCI_HR_INICIO_CONSUMO,
         T.VL_FATURADO,
         T.QTD,
         T.CAD_PRO_ID_PROFISSIONAL,
         T.FAT_CCI_PC_GRAU_PART_PROF,
         T.REP_PGM_DT_ULTIMA_ATUALIZACAO,
         T.VL_CALCULADO,
         T.CAD_PAC_ID_PACIENTE,
         T.FAT_CCI_TP_CREDENCIA_PROF,
         T.FAT_CCI_FL_PACOTE,
         T.CAD_CEC_ID_CCUSTO,
         T.CAD_CAC_ID_CLASSCONTABIL,
         T.FAT_CCI_MES_FECHAMENTO,
         T.FAT_CCI_ANO_FECHAMENTO,
         pUSUARIO_IMPORTACAO,
         SYSDATE,
         T.CAD_UNI_ID_UNIDADE,
         T.CAD_LAT_ID_LOCAL_ATENDIMENTO,
         'F',
         SEQ_REP_PGM_01.NEXTVAL,
         T.CAD_SET_ID,
         T.CAD_SET_ID,
         T.FAT_CCI_PC_ACOMODACAO_HM,
         T.CAD_CNV_ID_CONVENIO,
         T.CAD_PLA_CD_TIPOPLANO,
         T.AUX_EPP_CD_ESPECPROC,
         T.AUX_GPC_CD_GRUPOPROC,
         T.TIS_MED_CD_TABELAMEDICA,
         T.ATD_ATE_FL_RETORNO_OK,
         pREP_PGM_MES_PAGTO,
         pREP_PGM_ANO_PAGTO,
        'A',
         T.FAT_CCI_ID,
         T.CAD_TPE_CD_CODIGO,
         T.TIS_CBO_CD_CBOS,
         'HAC',
         822,
         T.CAD_CLC_ID,
         'P');
      UPDATE TB_FAT_CCI_CONTA_CONSU_ITEM CCI1
         SET CCI1.FAT_CCI_FL_IMPORTADO_REPASSE = 'P',
          CCI1.CAD_MPF_ID = NULL
       WHERE CCI1.FAT_CCI_ID = T.FAT_CCI_ID;
      UPDATE TB_FAT_CCI_CONTA_CONSU_ITEM CCI1
         SET CCI1.CAD_MPF_ID = NULL
       WHERE CCI1.FAT_CCI_ID_PRINCIPAL = T.FAT_CCI_ID
			 AND CCI1.CAD_TAP_TP_ATRIBUTO = 'M2';
      EXCEPTION
       WHEN OTHERS THEN
        UPDATE TB_FAT_CCI_CONTA_CONSU_ITEM CCI1
           SET CCI1.FAT_CCI_FL_IMPORTADO_REPASSE = 'E'
         WHERE CCI1.FAT_CCI_ID = T.FAT_CCI_ID;
    END;
  END LOOP;
  COMMIT;
END PRC_REP_IMP_PROD_PART_SCLINICA;