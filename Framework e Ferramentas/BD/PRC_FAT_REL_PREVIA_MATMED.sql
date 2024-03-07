CREATE OR REPLACE PROCEDURE "PRC_FAT_REL_PREVIA_MATMED"
  (
    pFAT_CCP_ID IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ID%TYPE DEFAULT NULL,
    pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE,
    pCAD_PAC_ID_PACIENTE IN TB_CAD_PAC_PACIENTE.CAD_PAC_ID_PACIENTE%TYPE,
    pDATA IN TB_FAT_CCI_CONTA_CONSU_ITEM.FAT_CCI_DT_INICIO_CONSUMO%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_FAT_REL_PREVIA_MATMED
  *
  *    Data ALTER: 27/08/2013  Por: Pedro
  *
  *    ATENC?O: manutenc?o nesta procedure requer revis?o na PRC_FAT_REL_CONTA_MATMED tambem
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
 SELECT DISTINCT
               CASE WHEN SETOR.CAD_SET_CD_SETOR = 'HEMD' THEN 'HEMODINAMICA'
                    WHEN SETOR.CAD_SET_CD_SETOR = 'ENDO' THEN 'ENDOSCOPIA'
                    WHEN SETOR.CAD_SET_CD_SETOR = 'CECI' THEN 'CENTRO CIRURGICO'
                    ELSE 'ENFERMARIA' 
                END SETOR,
               '' FAT_FCL_NR_SEQ_IMPRIME,
               CCI.ATD_ATE_ID,
               CCI.CAD_PAC_ID_PACIENTE,
              -- CCI.FAT_CCI_ID,
               '' FAT_COC_ID,
               pFAT_CCP_ID FAT_CCP_ID,
               AIC.ATD_AIC_DS_EMPRESA,
               DECODE(CCI.ATD_ATE_TP_PACIENTE,'I','INTERNADO','E','EXTERNO','A',
                              'AMBULATÓRIO','U','PRONTO SOCORRO')  ATD_ATE_TP_PACIENTE,
               GUI.ATD_GUI_CD_CODIGO,
               GUI.ATD_GUI_CD_SENHA,
               --TOTAL SOMA DO VALOR FATURADO DE TODOS OS ITENS DE DIARIAS(AGRUPAR)
               PRD.CAD_PRD_NM_MNEMONICO,
               PRD.CAD_PRD_DS_DESCRICAO,
               PRD.CAD_TAP_TP_ATRIBUTO,
               TAP.CAD_TAP_DS_ATRIBUTO,
               CCI.FAT_CCI_FL_FRACIONADO,
               APM.CAD_APM_DS_PRODUTO,
               '' FAT_CCP_MES_COMPET,
               '' FAT_CCP_ANO_COMPET,
               '' FAT_CCP_MES_FAT,
               '' FAT_CCP_ANO_FAT,
               CCI.FAT_CCI_VL_MATMED_FABRICA FAT_CCI_VL_MATMED_FABRICA,
               CCI.FAT_CCI_VL_MATMED_FABRICA FAT_CCI_VL_UNITARIO,
              SUM(CCI.FAT_CCI_QT_CONSUMO) OVER
                                     (PARTITION BY CCI.ATD_ATE_ID,CCI.FAT_CCP_ID,CCI.FAT_COC_ID,CCI.CAD_PAC_ID_PACIENTE,
                                     CCI.CAD_PRD_ID,CCI.FAT_CCI_VL_MATMED_FABRICA,CCI.FAT_CCI_FL_FRACIONADO,
                                     CASE WHEN SETOR.CAD_SET_CD_SETOR = 'HEMD' THEN 'HEMODINAMICA'
                    WHEN SETOR.CAD_SET_CD_SETOR = 'ENDO' THEN 'ENDOSCOPIA'
                    WHEN SETOR.CAD_SET_CD_SETOR = 'CECI' THEN 'CENTRO CIRURGICO'
                    ELSE 'ENFERMARIA' 
                END ) FAT_CCI_QT_CONSUMO,
               SUM(CCI.FAT_CCI_VL_FATURADO) OVER
                                    (PARTITION BY CCI.ATD_ATE_ID,CCI.FAT_CCP_ID,CCI.FAT_COC_ID,CCI.CAD_PAC_ID_PACIENTE,
                                     CCI.CAD_PRD_ID,CCI.FAT_CCI_VL_MATMED_FABRICA,CCI.FAT_CCI_FL_FRACIONADO,CASE WHEN SETOR.CAD_SET_CD_SETOR = 'HEMD' THEN 'HEMODINAMICA'
                    WHEN SETOR.CAD_SET_CD_SETOR = 'ENDO' THEN 'ENDOSCOPIA'
                    WHEN SETOR.CAD_SET_CD_SETOR = 'CECI' THEN 'CENTRO CIRURGICO'
                    ELSE 'ENFERMARIA' 
                END) FAT_CCI_VL_FATURADO,
               to_char(CCI.FAT_COC_ID) || '-' || to_char(CCI.FAT_CCP_ID) || '-' || to_char(CCI.CAD_PAC_ID_PACIENTE) ||
                                                 to_char(CCI.ATD_ATE_ID) coc_ccp_pac_atd,
               '' TIS_MSI_DS_MOTIVOSAIDAINT,
               PAC.CAD_PAC_NR_PRONTUARIO,
               PAC.CAD_PAC_CD_CREDENCIAL ,
               PAC.CAD_PAC_NM_TITULAR,
               PAC.CAD_PAC_DT_VALIDADECREDENCIAL,
               PES.CAD_PES_NM_PESSOA PACIENTE,
               PES.CAD_PES_NR_RG,
               UNI.CAD_UNI_DS_UNIDADE,
               
               CNV.CAD_CNV_CD_HAC_PRESTADOR,
               CNV.CAD_CNV_NM_FANTASIA,
               PLA.CAD_PLA_CD_TIPOPLANO,
               PLA.CAD_PLA_CD_PLANO_HAC,
               PLA.CAD_PLA_NM_NOME_PLANO,
               '' CAD_SET_DS_SETOR,
               TO_CHAR(ATD.ATD_ATE_DT_ATENDIMENTO,'DD/MM/YYYY') ATD_ATE_DT_ATENDIMENTO,
               ATD.ATD_ATE_HR_ATENDIMENTO,
               TO_CHAR(INA.ATD_INA_DT_ALTA_CLINICA,'DD/MM/YYYY') ATD_INA_DT_ALTA_CLINICA,
               INA.ATD_INA_HR_ALTA_CLINICA,
                pDATA FAT_CCP_DT_PARCELA
              
   FROM
               TB_FAT_CCI_CONTA_CONSU_ITEM CCI
  JOIN          TB_ATD_ATE_ATENDIMENTO      ATD
  ON            ATD.ATD_ATE_ID            = CCI.ATD_ATE_ID
  JOIN          TB_CAD_PRD_PRODUTO          PRD
  ON            PRD.CAD_PRD_ID            = CCI.CAD_PRD_ID
  JOIN          TB_CAD_TAP_TP_ATRIB_PRODUTO TAP
  ON            TAP.CAD_TAP_TP_ATRIBUTO   = PRD.CAD_TAP_TP_ATRIBUTO
  JOIN          TB_FAT_MCC_MOV_COM_CONSUMO MCC
  ON            MCC.FAT_MCC_ID          = CCI.FAT_MCC_ID
  AND           MCC.ATD_ATE_ID          = CCI.ATD_ATE_ID
  JOIN          TB_CAD_SET_SETOR          SETOR
  ON            SETOR.CAD_SET_ID        = MCC.CAD_SET_ID
  JOIN          TB_CAD_PAC_PACIENTE       PAC
  ON            PAC.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
  JOIN          TB_CAD_PES_PESSOA         PES
  ON            PES.CAD_PES_ID_PESSOA   = PAC.CAD_PES_ID_PESSOA
  JOIN          TB_CAD_CNV_CONVENIO       CNV
  ON            CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO

  JOIN          TB_CAD_PLA_PLANO          PLA
  ON            PLA.CAD_PLA_ID_PLANO    = PAC.CAD_PLA_ID_PLANO
  LEFT JOIN     TB_ATD_AIC_ATE_INT_COMPL  AIC
  ON            AIC.ATD_ATE_ID          = CCI.ATD_ATE_ID
  LEFT JOIN     TB_ATD_INA_INT_ALTA         INA
  ON            INA.ATD_ATE_ID            = CCI.ATD_ATE_ID
  JOIN          TB_CAD_UNI_UNIDADE          UNI
  ON            UNI.CAD_UNI_ID_UNIDADE    = CCI.CAD_UNI_ID_UNIDADE
 
  LEFT JOIN     TB_CAD_APM_APRES_PRO_MATMED APM
  ON            APM.CAD_APM_ID_MATMED     = PRD.CAD_APM_ID_MATMED
  LEFT JOIN     TB_ATD_GUI_GUIAATEND  GUI
  ON             GUI.ATD_ATE_ID            = CCI.ATD_ATE_ID
 -- AND            GUI.CAD_PAC_ID_PACIENTE   = CCI.CAD_PAC_ID_PACIENTE
  and            GUI.ATD_GUI_FL_GUIAPRINC_OK = 'S'
  WHERE         CCI.ATD_ATE_ID = pATD_ATE_ID
  AND           CCI.FAT_CCP_ID IS NULL
  AND           CCI.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
   AND ((CCI.FAT_CCI_DT_INICIO_CONSUMO < pDATA AND CCI.ATD_ATE_TP_PACIENTE IN ('I'))
                            OR CCI.ATD_ATE_TP_PACIENTE IN ('A','U','E'))
  AND           (CCI.FAT_CCI_FL_STATUS     = 'A')
  AND           ((CCI.FAT_CCI_FL_PACOTE IS NULL) OR (CCI.FAT_CCI_FL_PACOTE = 'N'))
   --  AND    ((CCI.FAT_CCI_FL_KITPRA IS NULL) OR (CCI.FAT_CCI_FL_KITPRA = 'N'))
  AND         (PRD.TIS_MED_CD_TABELAMEDICA != 'IP')
  AND         (CCI.CAD_TAP_TP_ATRIBUTO IN ('MAT','MED'))
  
  ORDER BY  CASE WHEN SETOR.CAD_SET_CD_SETOR = 'HEMD' THEN 'HEMODINAMICA'
                    WHEN SETOR.CAD_SET_CD_SETOR = 'ENDO' THEN 'ENDOSCOPIA'
                    WHEN SETOR.CAD_SET_CD_SETOR = 'CECI' THEN 'CENTRO CIRURGICO'
                    ELSE 'ENFERMARIA' 
                END, CCI.FAT_CCI_FL_FRACIONADO , PRD.CAD_PRD_DS_DESCRICAO
  ;
             io_cursor := v_cursor;
  end PRC_FAT_REL_PREVIA_MATMED;
 