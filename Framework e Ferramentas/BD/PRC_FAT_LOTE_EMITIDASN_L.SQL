CREATE OR REPLACE PROCEDURE "PRC_FAT_LOTE_EMITIDASN_L"
(
  pCAD_UNI_ID_UNIDADE           TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
  pCAD_LAT_ID_LOCAL_ATENDIMENTO VARCHAR2,
  pCAD_SET_ID                   VARCHAR2,
  pATD_ATE_DT_ATENDIMENTO       TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
  pCAD_CNV_ID_CONVENIO          TB_CAD_PAC_PACIENTE.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
  IO_CURSOR                     OUT PKG_CURSOR.T_CURSOR) IS
  /********************************************************************
  *    Procedure: PRC_FAT_LOTE_EMITIDASN_L
  *
  *    Data Criacao:   data da criac?o   Por: Nome do Analista
  *
  *    Data Alteracao: 08/07/2010        Por: Fabiola Lopes
  *    Alteracao: Retirei a tabela PAT conforme definic?o junto com a Silmara (para identificac?o do paciente)
  *
  *    Data Alteracao: 22/07/2010        Por: Fabiola Lopes
  *    Alteracao: Inclus?o do join entre as tabelas CCP e PAC
  *
  *    Funcao: Descric?o da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  V_CURSOR PKG_CURSOR.T_CURSOR;
BEGIN
  OPEN V_CURSOR FOR
    SELECT  DISTINCT ATE.ATD_ATE_ID,
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
                    CID10.CAD_CID_DS_CID10,
                    CCP.FAT_CCP_DT_PARCELA,
                    CCP.FAT_CCP_ANO_FAT,
                    CCP.FAT_CCP_MES_FAT,
                    ATE.CAD_UNI_ID_UNIDADE
      FROM TB_ATD_ATE_ATENDIMENTO      ATE,
           TB_FAT_MCC_MOV_COM_CONSUMO  MCC,
           TB_FAT_CCI_CONTA_CONSU_ITEM CCI,
           TB_FAT_COC_CONTA_CONSUMO    COC,
           TB_FAT_CCP_CONTA_CONS_PARC  CCP,
           TB_CAD_PAC_PACIENTE         PAC,
           TB_CAD_PES_PESSOA           PES,
           TB_CAD_CID_CID10            CID10
     WHERE ATE.ATD_ATE_TP_PACIENTE IN ('A', 'U')
           AND ATE.CAD_CID_CD_CID10 = CID10.CAD_CID_CD_CID10(+)
       AND ATE.ATD_ATE_FL_STATUS = 'A'
       AND MCC.FAT_MCC_FL_STATUS = 'A'
       AND CCI.FAT_CCI_FL_STATUS = 'A'
--       AND CCI.FAT_CCI_FL_FATURADO = 'N'
       AND (CCI.FAT_FL_PENDENTE_AUTORIZA = 'A' OR CCI.FAT_FL_PENDENTE_AUTORIZA IS NULL)
       AND CCP.FAT_CCP_FL_FATURADA = 'N'
       AND ATE.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
       AND ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT column_value from table(FNC_SPLIT(pCAD_LAT_ID_LOCAL_ATENDIMENTO)))
       AND PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
--       AND (pCAD_SET_ID IS NULL OR ATE.CAD_SET_ID = pCAD_SET_ID)
       AND (pCAD_SET_ID is null or ATE.CAD_SET_ID IN (SELECT column_value from table(FNC_SPLIT(pCAD_SET_ID))))
       AND ATE.ATD_ATE_DT_ATENDIMENTO <= pATD_ATE_DT_ATENDIMENTO       
       AND PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
       AND CCI.FAT_MCC_ID = MCC.FAT_MCC_ID  
       AND CCI.ATD_ATE_ID = MCC.ATD_ATE_ID
       AND MCC.ATD_ATE_ID = ATE.ATD_ATE_ID
       AND COC.ATD_ATE_ID = ATE.ATD_ATE_ID
       AND COC.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
       AND CCP.ATD_ATE_ID = ATE.ATD_ATE_ID
       AND CCP.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
       AND CCP.FAT_COC_ID = COC.FAT_COC_ID
       AND CCI.FAT_COC_ID = COC.FAT_COC_ID
       AND CCI.FAT_CCP_ID = CCP.FAT_CCP_ID
       AND CCI.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
       AND CCI.ATD_ATE_ID = ATE.ATD_ATE_ID 
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
                    CID10.CAD_CID_DS_CID10,
                    ccp.fat_ccp_dt_parcela,
                    CCP.FAT_CCP_ANO_FAT,
                    CCP.FAT_CCP_MES_FAT,
                    ATE.CAD_UNI_ID_UNIDADE
      FROM TB_ATD_ATE_ATENDIMENTO      ATE,           
           TB_ATD_INA_INT_ALTA         INA,
           TB_FAT_MCC_MOV_COM_CONSUMO  MCC,
           TB_FAT_CCI_CONTA_CONSU_ITEM CCI,
           TB_FAT_COC_CONTA_CONSUMO    COC,
           TB_FAT_CCP_CONTA_CONS_PARC  CCP,
           TB_CAD_PAC_PACIENTE         PAC,
           TB_CAD_PES_PESSOA           PES,
           TB_CAD_CID_CID10            CID10
     WHERE      
           ATE.ATD_ATE_TP_PACIENTE IN ('I', 'E')
       AND PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
       AND ATE.CAD_CID_CD_CID10 = CID10.CAD_CID_CD_CID10(+)
       AND ATE.ATD_ATE_FL_STATUS = 'A'
       AND MCC.FAT_MCC_FL_STATUS = 'A'
       AND CCI.FAT_CCI_FL_STATUS = 'A'
--       AND CCI.FAT_CCI_FL_FATURADO = 'N'
       AND (CCI.FAT_FL_PENDENTE_AUTORIZA = 'A' OR CCI.FAT_FL_PENDENTE_AUTORIZA IS NULL)
       AND CCP.FAT_CCP_FL_FATURADA = 'N'
       AND ATE.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
       AND ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT column_value from table(FNC_SPLIT(pCAD_LAT_ID_LOCAL_ATENDIMENTO)))
       AND (pCAD_SET_ID is null or ATE.CAD_SET_ID IN (SELECT column_value from table(FNC_SPLIT(pCAD_SET_ID))))
--       AND (pCAD_SET_ID IS NULL OR ATE.CAD_SET_ID = pCAD_SET_ID)
       AND ATE.ATD_ATE_DT_ATENDIMENTO <= pATD_ATE_DT_ATENDIMENTO      
       AND INA.ATD_ATE_ID(+) = ATE.ATD_ATE_ID
       AND CCI.FAT_MCC_ID = MCC.FAT_MCC_ID
       AND CCI.ATD_ATE_ID = MCC.ATD_ATE_ID
       AND MCC.ATD_ATE_ID = ATE.ATD_ATE_ID
       AND PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
       AND COC.ATD_ATE_ID = ATE.ATD_ATE_ID
       AND COC.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
       AND CCP.ATD_ATE_ID = ATE.ATD_ATE_ID
       AND CCP.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
       AND CCP.FAT_COC_ID = COC.FAT_COC_ID
       AND CCI.FAT_COC_ID = COC.FAT_COC_ID
       AND CCI.FAT_CCP_ID = CCP.FAT_CCP_ID
       AND CCI.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
       AND CCI.ATD_ATE_ID = ATE.ATD_ATE_ID ;
  IO_CURSOR := V_CURSOR;
END PRC_FAT_LOTE_EMITIDASN_L;
 