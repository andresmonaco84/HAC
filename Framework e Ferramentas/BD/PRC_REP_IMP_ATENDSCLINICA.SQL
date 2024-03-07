create or replace procedure PRC_REP_IMP_ATENDSCLINICA(
pCAD_PRD_CD_CODIGO                  IN STRING DEFAULT NULL,
pATD_ATE_ID                         IN STRING DEFAULT NULL,
pCAD_PRO_ID_PROFISSIONAL_FAT        IN STRING DEFAULT NULL,
pCAD_PRO_ID_PROFISSIONAL_PAG        IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%TYPE DEFAULT NULL,
pREP_PGM_TP_CREDENCIA_PROF          IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_TP_CREDENCIA_PROF%TYPE DEFAULT NULL,
pSEG_USU_ID_USUARIO_CRIACAO         IN TB_REP_PGM_PAGTO_MEDICO.SEG_USU_ID_USUARIO_CRIACAO%TYPE DEFAULT NULL,
pCAD_CLC_ID                         IN TB_CAD_CLC_CLINICA_CREDENCIADA.CAD_CLC_ID%TYPE DEFAULT NULL,
pREP_PGM_MES_PAGTO                  IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE DEFAULT NULL,
pREP_PGM_ANO_PAGTO                  IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE DEFAULT NULL,
pREP_PGM_FONTE_PAGADORA             IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_FONTE_PAGADORA%TYPE DEFAULT NULL,
pFAT_CCP_MES_FAT                    IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_MES_FAT%TYPE DEFAULT NULL,
pFAT_CCP_ANO_FAT                    IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ANO_FAT%TYPE DEFAULT NULL,
pREP_PGM_VL_PAGO                    IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_VL_PAGO%TYPE DEFAULT NULL
)
IS

BEGIN
FOR T IN (SELECT DISTINCT ATD.ATD_ATE_ID,
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
                          CCI.CAD_PRO_ID_PROFISSIONAL,
                          CCI.FAT_CCI_PC_GRAU_PART_PROF,
                          SYSDATE REP_PGM_DT_ULTIMA_ATUALIZACAO,
                          (NVL(CCI.FAT_CCI_VL_CALCULADO, 0)) VL_CALCULADO,
                          CCI.CAD_PAC_ID_PACIENTE,
                          CCI.FAT_CCI_TP_CREDENCIA_PROF,
                          CCI.FAT_CCI_FL_PACOTE,
                          CCI.CAD_CEC_ID_CCUSTO,
                          CCI.CAD_CAC_ID_CLASSCONTABIL,
                          CCI.FAT_CCI_MES_FECHAMENTO,
                          CCI.FAT_CCI_ANO_FECHAMENTO,
                          SYSDATE,
                          ATD.CAD_UNI_ID_UNIDADE,
                          CASE
                            WHEN MCC.FAT_TCO_ID = 289 THEN
                             28
                            ELSE
                             DECODE(ATD.CODCLI, NULL, ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO, 28)
                            END CAD_LAT_ID_LOCAL_ATENDIMENTO,
                            'F',
                          MCC.CAD_SET_ID,
                          PAC.CAD_CNV_ID_CONVENIO,
                          CCI.FAT_CCI_PC_ACOMODACAO_HM,
                          CASE
                            WHEN ATD.ATD_ATE_TP_PACIENTE IN ('A', 'U') THEN
                             NULL
                            ELSE
                             DECODE(CCI.FAT_CCI_PC_ACOMODACAO_HM, NULL, 1, 11)
                          END TPACOM,
                          CCI.FAT_CCI_CD_CLINICA_PROF,
                          Cci.CAD_CLC_ID,
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
                          END ESPECMED,
                          CNV.CAD_TPE_CD_CODIGO

              FROM TB_FAT_CCI_CONTA_CONSU_ITEM    CCI,
                   TB_CAD_CNV_CONVENIO            CNV,
                   TB_CAD_PAC_PACIENTE            PAC,
                   TB_ATD_ATE_ATENDIMENTO         ATD,
                   TB_FAT_CCP_CONTA_CONS_PARC     CCP,
                   TB_CAD_PES_PESSOA              PES,
                   TB_CAD_PLA_PLANO               PLA,
                   TB_FAT_MCC_MOV_COM_CONSUMO     MCC,
                   TB_CAD_PRD_PRODUTO             PRD,
                   TB_TIS_CBO_CBOS                CBOS

             WHERE CCP.FAT_CCP_MES_FAT = pFAT_CCP_MES_FAT --PARAMETRO
               AND CCP.FAT_CCP_ANO_FAT = pFAT_CCP_ANO_FAT --PARAMETRO
               AND ATD.ATD_ATE_ID = CCI.ATD_ATE_ID
               AND PAC.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
               AND PRD.CAD_PRD_ID = CCI.CAD_PRD_ID
               AND PAC.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
               AND PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA
               AND PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
               AND CCI.CAD_PRD_ID = PRD.CAD_PRD_ID
               AND MCC.ATD_ATE_ID = ATD.ATD_ATE_ID
               AND CCI.FAT_MCC_ID = MCC.FAT_MCC_ID
               AND CCI.CAD_TAP_TP_ATRIBUTO IN ('EXA', 'HM', 'TAX')
               AND CCI.FAT_CCI_FL_STATUS <> 'C'
               AND CCP.FAT_CCP_FL_EMITIDA = 'S'
               AND CCP.FAT_CCP_FL_FATURADA = 'S'
               AND CCP.FAT_NOF_ID IS NOT NULL
               AND MCC.ATD_ATE_ID = CCI.ATD_ATE_ID
               AND MCC.FAT_MCC_ID = CCI.FAT_MCC_ID
               AND CCP.FAT_CCP_ID = CCI.FAT_CCP_ID
               AND CCP.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
               AND CCP.ATD_ATE_ID = CCI.ATD_ATE_ID
               AND CCP.FAT_COC_ID = CCI.FAT_COC_ID
               AND CCI.FAT_CCI_FL_STATUS = 'A'
               AND ATD.ATD_ATE_FL_STATUS = 'A'
               AND ATD.ATD_ATE_TP_PACIENTE IN ('A', 'U', 'I', 'E')
               AND (pCAD_PRD_CD_CODIGO IS NULL OR PRD.CAD_PRD_CD_CODIGO IN (SELECT * FROM TABLE(FNC_SPLIT(pCAD_PRD_CD_CODIGO)))) -- (pCAD_PRD_CD_CODIGO)) --PARAMETRO
               AND ATD.TIS_CBO_CD_CBOS = CBOS.TIS_CBO_CD_CBOS(+)
               AND (pATD_ATE_ID IS NULL OR ATD.ATD_ATE_ID IN (SELECT * FROM TABLE(FNC_SPLIT(pATD_ATE_ID)))) -- (pATD_ATE_ID)) --PARAMETRO
               AND (CCI.FAT_CCI_FL_IMPORTADO_REPASSE = 'N' OR CCI.FAT_CCI_FL_IMPORTADO_REPASSE IS NULL)
               AND (pCAD_PRO_ID_PROFISSIONAL_FAT IS NULL OR CCI.CAD_PRO_ID_PROFISSIONAL IN (SELECT * FROM TABLE(FNC_SPLIT(pCAD_PRO_ID_PROFISSIONAL_FAT)))) --2737 -- profissional faturado
               ) LOOP
    BEGIN
      INSERT INTO TB_REP_PGM_PAGTO_MEDICO(ATD_ATE_ID,
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
                                          CAD_CLC_ID,
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
                                          TIS_TAC_CD_TIPO_ACOMOD_AUT,
                                          REP_PGM_FL_PAGO,
                                          REP_PGM_FONTE_PAGADORA,
                                          REP_PGM_CD_JUSTIFICATIVA, 
                                          REP_PGM_VL_PAGO)
              VALUES
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
                                          pCAD_PRO_ID_PROFISSIONAL_PAG, --PARAMETRO - profissional pagamento
                                          T.FAT_CCI_PC_GRAU_PART_PROF,
                                          T.REP_PGM_DT_ULTIMA_ATUALIZACAO,
                                          T.VL_CALCULADO,
                                          T.CAD_PAC_ID_PACIENTE,
                                          pREP_PGM_TP_CREDENCIA_PROF, --PARAMETRO
                                          T.FAT_CCI_FL_PACOTE,
                                          T.CAD_CEC_ID_CCUSTO,
                                          T.CAD_CAC_ID_CLASSCONTABIL,
                                          T.FAT_CCI_MES_FECHAMENTO,
                                          T.FAT_CCI_ANO_FECHAMENTO,
                                          pSEG_USU_ID_USUARIO_CRIACAO, --PARAMETRO
                                          SYSDATE,
                                          T.CAD_UNI_ID_UNIDADE,
                                          T.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                          'F',
                                          SEQ_REP_PGM_01.NEXTVAL,
                                          T.CAD_SET_ID,
                                          T.CAD_SET_ID,
                                          T.FAT_CCI_PC_ACOMODACAO_HM,
                                          T.CAD_CNV_ID_CONVENIO,
                                          pCAD_CLC_ID, --PARAMETRO
                                          T.CAD_PLA_CD_TIPOPLANO,
                                          T.AUX_EPP_CD_ESPECPROC,
                                          T.AUX_GPC_CD_GRUPOPROC,
                                          T.TIS_MED_CD_TABELAMEDICA,
                                          T.ATD_ATE_FL_RETORNO_OK,
                                          pREP_PGM_MES_PAGTO, --PARAMETRO
                                          pREP_PGM_ANO_PAGTO, --PARAMETRO
                                          'A',
                                          T.FAT_CCI_ID,
                                          T.CAD_TPE_CD_CODIGO,
                                          T.ESPECMED,
                                          T.TPACOM,
                                          'P',
                                          pREP_PGM_FONTE_PAGADORA,
                                          103,
                                          pREP_PGM_VL_PAGO);

      UPDATE TB_FAT_CCI_CONTA_CONSU_ITEM CCI1
         SET CCI1.FAT_CCI_FL_IMPORTADO_REPASSE = 'P'
       WHERE CCI1.FAT_CCI_ID = T.FAT_CCI_ID;
    END;
  END LOOP;
  COMMIT;
end PRC_REP_IMP_ATENDSCLINICA;
