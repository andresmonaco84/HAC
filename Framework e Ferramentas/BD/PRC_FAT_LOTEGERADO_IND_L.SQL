CREATE OR REPLACE PROCEDURE "PRC_FAT_LOTEGERADO_IND_L"
(
  pATD_ATE_ID          IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE DEFAULT NULL,
  pCAD_CNV_ID_CONVENIO IN TB_CAD_PAC_PACIENTE.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
  pFAT_LNF_ID          IN TB_FAT_LNF_LOTE_CTA_PARC_NF.FAT_LNF_ID%TYPE DEFAULT NULL,
  IO_CURSOR            OUT PKG_CURSOR.T_CURSOR
) 
  IS
  /********************************************************************
  *    Procedure: PRC_FAT_LOTEGERADO_IND_L
  *
  *    Data Criacao:   data da criação   Por: Nome do Analista
  *
  *    Data Alteracao: 13/07/2010        Por: Fabiola Lopes
  *    Alteracao: Retirei a tabela PAT conforme definição junto com a Silmara (para identificação do paciente)
  *
  *    Data Alteracao: 22/07/2010        Por: Fabiola Lopes
  *    Alteracao: Inclusão do join entre as tabelas CCP e PAC
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  V_CURSOR PKG_CURSOR.T_CURSOR;
BEGIN
  OPEN V_CURSOR FOR
    SELECT DISTINCT ATE.ATD_ATE_ID,
                    ATE.ATD_ATE_TP_PACIENTE,
                    PES.CAD_PES_NM_PESSOA,
                    ATE.ATD_ATE_DT_ATENDIMENTO,
                    ATE.ATD_ATE_HR_ATENDIMENTO,
                    NULL,
                    NULL,
                    CCP.FAT_COC_ID,
                    CCP.FAT_CCP_ID,
                    PAC.CAD_PAC_ID_PACIENTE,
                    PAC.CAD_CNV_ID_CONVENIO,
                    CCI.FAT_CCP_ID,
                    CCI.FAT_COC_ID,
                    PAC.CAD_PAC_NR_PRONTUARIO,
                    UNI.CAD_UNI_DS_UNIDADE,
                    CCP.FAT_CCP_DT_PARCELA,
                    CCP.FAT_CCP_VL_TOT_CONTA
      FROM TB_ATD_ATE_ATENDIMENTO      ATE,
           TB_FAT_MCC_MOV_COM_CONSUMO  MCC,
           TB_FAT_CCI_CONTA_CONSU_ITEM CCI,
           TB_FAT_COC_CONTA_CONSUMO    COC,
           TB_FAT_CCP_CONTA_CONS_PARC  CCP,
           TB_CAD_PAC_PACIENTE         PAC,
           TB_CAD_PES_PESSOA           PES,
           TB_CAD_UNI_UNIDADE          UNI,
           TB_FAT_LNF_LOTE_CTA_PARC_NF LNF
     WHERE ATE.ATD_ATE_ID = pATD_ATE_ID
       AND PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
       AND LNF.FAT_LNF_ID = pFAT_LNF_ID
       AND PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
       AND LNF.FAT_LNF_ID = CCP.FAT_LNF_ID
       AND ATE.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
       AND MCC.ATD_ATE_ID = ATE.ATD_ATE_ID
       AND CCI.FAT_MCC_ID = MCC.FAT_MCC_ID
       AND CCI.ATD_ATE_ID = MCC.ATD_ATE_ID
       AND COC.ATD_ATE_ID = ATE.ATD_ATE_ID
       AND COC.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
       AND CCP.ATD_ATE_ID = ATE.ATD_ATE_ID
       AND CCP.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
       AND CCP.FAT_COC_ID = COC.FAT_COC_ID
       AND CCI.FAT_COC_ID = COC.FAT_COC_ID
       AND CCI.FAT_CCP_ID = CCP.FAT_CCP_ID
       AND CCI.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
       AND CCI.ATD_ATE_ID = ATE.ATD_ATE_ID 
       AND ATE.ATD_ATE_TP_PACIENTE IN ('A', 'U')
       AND ATE.ATD_ATE_FL_STATUS = 'A'
       AND MCC.FAT_MCC_FL_STATUS = 'A'
       AND CCI.FAT_CCI_FL_STATUS = 'A'
--       AND CCI.FAT_CCI_FL_FATURADO = 'S'
--       AND (CCI.FAT_FL_PENDENTE_AUTORIZA = 'A' OR CCI.FAT_FL_PENDENTE_AUTORIZA IS NULL)
       AND CCI.FAT_CCP_ID IS NOT NULL
       AND CCI.FAT_COC_ID IS NOT NULL
       AND CCP.FAT_CCP_FL_FATURADA = 'S'
       AND CCP.FAT_NOF_ID IS NULL
    UNION ALL
    SELECT DISTINCT ATE.ATD_ATE_ID,
                    ATE.ATD_ATE_TP_PACIENTE,
                    PES.CAD_PES_NM_PESSOA,
                    ATE.ATD_ATE_DT_ATENDIMENTO,
                    ATE.ATD_ATE_HR_ATENDIMENTO,
                    INA.ATD_INA_DT_ALTA_ADM,
                    INA.ATD_INA_HR_ALTA_ADM,
                    CCP.FAT_COC_ID,
                    CCP.FAT_CCP_ID,
                    PAC.CAD_PAC_ID_PACIENTE,
                    PAC.CAD_CNV_ID_CONVENIO,
                    CCI.FAT_CCP_ID,
                    CCI.FAT_COC_ID,
                    PAC.CAD_PAC_NR_PRONTUARIO,
                    UNI.CAD_UNI_DS_UNIDADE,
                    CCP.FAT_CCP_DT_PARCELA,
                    CCP.FAT_CCP_VL_TOT_CONTA
      FROM TB_ATD_ATE_ATENDIMENTO      ATE,
           TB_ATD_AIC_ATE_INT_COMPL    AIC,
           TB_ATD_INA_INT_ALTA         INA,
           TB_FAT_MCC_MOV_COM_CONSUMO  MCC,
           TB_FAT_CCI_CONTA_CONSU_ITEM CCI,
           TB_FAT_COC_CONTA_CONSUMO    COC,
           TB_FAT_CCP_CONTA_CONS_PARC  CCP,
           TB_CAD_PAC_PACIENTE         PAC,
           TB_CAD_PES_PESSOA           PES,
           TB_CAD_UNI_UNIDADE          UNI,
           TB_FAT_LNF_LOTE_CTA_PARC_NF LNF
     WHERE ATE.ATD_ATE_ID = pATD_ATE_ID
       AND PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
       AND AIC.ATD_ATE_ID = ATE.ATD_ATE_ID
       AND INA.ATD_ATE_ID(+) = AIC.ATD_ATE_ID
       AND MCC.ATD_ATE_ID = ATE.ATD_ATE_ID
       AND LNF.FAT_LNF_ID = CCP.FAT_LNF_ID
       AND LNF.FAT_LNF_ID = pFAT_LNF_ID
       AND ATE.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE       
       AND PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
       AND CCI.FAT_MCC_ID = MCC.FAT_MCC_ID
       AND CCI.ATD_ATE_ID = MCC.ATD_ATE_ID
       AND COC.ATD_ATE_ID = ATE.ATD_ATE_ID
       AND COC.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
       AND CCP.ATD_ATE_ID = ATE.ATD_ATE_ID
       AND CCP.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
       AND CCP.FAT_COC_ID = COC.FAT_COC_ID
       AND CCI.FAT_COC_ID = COC.FAT_COC_ID
       AND CCI.FAT_CCP_ID = CCP.FAT_CCP_ID
       AND CCI.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
       AND CCI.ATD_ATE_ID = ATE.ATD_ATE_ID 
        AND ATE.ATD_ATE_TP_PACIENTE IN ('I', 'E')
       AND ATE.ATD_ATE_FL_STATUS = 'A'
       AND MCC.FAT_MCC_FL_STATUS = 'A'
       AND CCI.FAT_CCI_FL_STATUS = 'A'
 --      AND CCI.FAT_CCI_FL_FATURADO = 'S'
--       AND (CCI.FAT_FL_PENDENTE_AUTORIZA = 'A' OR CCI.FAT_FL_PENDENTE_AUTORIZA IS NULL)
       AND CCI.FAT_CCP_ID IS NOT NULL
       AND CCI.FAT_COC_ID IS NOT NULL
       AND CCP.FAT_CCP_FL_FATURADA = 'S'
       AND CCP.FAT_NOF_ID IS NULL
      ;
  IO_CURSOR := V_CURSOR;
END PRC_FAT_LOTEGERADO_IND_L;
 