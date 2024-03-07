CREATE OR REPLACE PROCEDURE "PRC_FAT_REL_CONTA_MATMED"
  (
    pLOTE IN TB_FAT_FCL_CONTR_EMI_LOTE.FAT_FCL_NR_SEQ_LOTE%TYPE DEFAULT NULL,
    pFAT_COC_ID IN TB_FAT_COC_CONTA_CONSUMO.FAT_COC_ID%TYPE DEFAULT NULL,
    pFAT_CCP_ID IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ID%TYPE DEFAULT NULL,
    pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE DEFAULT NULL,
    pCAD_PAC_ID_PACIENTE IN TB_CAD_PAC_PACIENTE.CAD_PAC_ID_PACIENTE%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_FAT_REL_CONTA_MATMED
  *
  *    Data Alteracao: 27/08/2013  Por: Pedro
 *    Alterac?o: CUSTO-RETIRADO A FUNCAO PRA CALCULO DO MATMED
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
--prc_fat_rel_conta_matmed
/*
SELECT * FROM TB_FAT_FCL_CONTR_EMI_LOTE FCL 
JOIN          TB_FAT_CCI_CONTA_CONSU_ITEM CCI
  ON            CCI.FAT_CCP_ID            = FCL.FAT_CCP_ID
  AND           CCI.ATD_ATE_ID            = FCL.ATD_ATE_ID
  AND           CCI.FAT_COC_ID            = FCL.FAT_COC_ID
  AND           CCI.CAD_PAC_ID_PACIENTE   = FCL.CAD_PAC_ID_PACIENTE
WHERE CCI.CAD_TAP_TP_ATRIBUTO = 'MAT'
*/
SELECT DISTINCT
               CASE WHEN SETOR.CAD_SET_CD_SETOR = 'HEMD' THEN 'HEMODINAMICA'
                    WHEN SETOR.CAD_SET_CD_SETOR = 'ENDO' THEN 'ENDOSCOPIA'
                    WHEN SETOR.CAD_SET_CD_SETOR = 'CECI' THEN 'CENTRO CIRURGICO'
                    ELSE 'ENFERMARIA' 
                END SETOR,               
               FCL.FAT_FCL_NR_SEQ_IMPRIME,
               CCI.ATD_ATE_ID,
               CCI.CAD_PAC_ID_PACIENTE,
              
               CCI.FAT_COC_ID,
               CCI.FAT_CCP_ID,               
               AIC.ATD_AIC_DS_EMPRESA,
               DECODE(CCI.ATD_ATE_TP_PACIENTE,'I','INTERNADO','E','EXTERNO','A',
               'AMBULATORIO','U','PRONTO SOCORRO')  ATD_ATE_TP_PACIENTE,
               GUI.ATD_GUI_CD_CODIGO,
               GUI.ATD_GUI_CD_SENHA,
              
               PRD.CAD_PRD_NM_MNEMONICO,
               PRD.CAD_PRD_DS_DESCRICAO,
               CCI.CAD_TAP_TP_ATRIBUTO,
               TAP.CAD_TAP_DS_ATRIBUTO,
               CCI.FAT_CCI_FL_FRACIONADO,
               APM.CAD_APM_DS_PRODUTO,
               CCP.FAT_CCP_MES_COMPET,
               CCP.FAT_CCP_ANO_COMPET,
               CCP.FAT_CCP_MES_FAT,
               CCP.FAT_CCP_ANO_FAT,
               NULL FAT_CCI_VL_MATMED_FABRICA,
               CCI.FAT_CCI_VL_UNITARIO FAT_CCI_VL_UNITARIO,
               SUM(CCI.FAT_CCI_QT_CONSUMO) OVER
                                     (PARTITION BY CCI.ATD_ATE_ID,CCI.FAT_CCP_ID,CCI.FAT_COC_ID,CCI.CAD_PAC_ID_PACIENTE,
                                     CCI.CAD_PRD_ID,CCI.FAT_CCI_VL_UNITARIO,CCI.FAT_CCI_FL_FRACIONADO,
                                     CASE WHEN SETOR.CAD_SET_CD_SETOR = 'HEMD' THEN 'HEMODINAMICA'
                                          WHEN SETOR.CAD_SET_CD_SETOR = 'ENDO' THEN 'ENDOSCOPIA'
                                          WHEN SETOR.CAD_SET_CD_SETOR = 'CECI' THEN 'CENTRO CIRURGICO'
                                          ELSE 'ENFERMARIA' 
                                      END ) FAT_CCI_QT_CONSUMO,
               SUM(CCI.FAT_CCI_VL_FATURADO) OVER
                                    (PARTITION BY CCI.ATD_ATE_ID,CCI.FAT_CCP_ID,CCI.FAT_COC_ID,CCI.CAD_PAC_ID_PACIENTE,
                                     CCI.CAD_PRD_ID,CCI.FAT_CCI_VL_UNITARIO,CCI.FAT_CCI_FL_FRACIONADO,
                                     CASE WHEN SETOR.CAD_SET_CD_SETOR = 'HEMD' THEN 'HEMODINAMICA'
                                          WHEN SETOR.CAD_SET_CD_SETOR = 'ENDO' THEN 'ENDOSCOPIA'
                                          WHEN SETOR.CAD_SET_CD_SETOR = 'CECI' THEN 'CENTRO CIRURGICO'
                                          ELSE 'ENFERMARIA' 
                                      END) FAT_CCI_VL_FATURADO,
               to_char(CCI.FAT_COC_ID) || '-' || to_char(CCP.FAT_CCP_ID) || '-' || to_char(CCI.CAD_PAC_ID_PACIENTE) ||
                                                 to_char(CCI.ATD_ATE_ID) coc_ccp_pac_atd,
               MSI.TIS_MSI_DS_MOTIVOSAIDAINT,
               PAC.CAD_PAC_NR_PRONTUARIO,
               PAC.CAD_PAC_CD_CREDENCIAL ,
               PAC.CAD_PAC_NM_TITULAR,
               PAC.CAD_PAC_DT_VALIDADECREDENCIAL,
               PES.CAD_PES_NM_PESSOA PACIENTE,
               PES.CAD_PES_NR_RG,
               UNI.CAD_UNI_DS_UNIDADE,
              
               CNV.CAD_CNV_CD_HAC_PRESTADOR,
               CNV.CAD_CNV_NM_FANTASIA ||
               CASE WHEN CNV.CAD_CNV_ID_CONVENIO = 282 AND CCI.ATD_ATE_TP_PACIENTE = 'I' THEN
                 (select ' (DIFERENÇA DE CLASSE)' from tb_fat_mcc_mov_com_consumo mcc1 
                  JOIN TB_FAT_TCO_TIPO_COMANDA TCO ON TCO.FAT_TCO_ID = MCC1.FAT_TCO_ID AND TCO.FAT_TCO_ID=10
                  where mcc1.atd_ate_id = CCI.ATD_ATE_ID AND MCC1.FAT_MCC_ID = CCI.FAT_MCC_ID 
                  AND CCI.FAT_CCI_DT_INICIO_CONSUMO BETWEEN CCP.FAT_CCP_DT_PARCELA_INI AND CCP.FAT_CCP_DT_PARCELA
                  AND ROWNUM =1) -- VERIFICAR SE EXISTE ITEM DIF DE CLASSE NO PERIODO DA PARCELA
                ELSE '' END CAD_CNV_NM_FANTASIA,
               PLA.CAD_PLA_CD_TIPOPLANO,
               PLA.CAD_PLA_CD_PLANO_HAC,
               PLA.CAD_PLA_NM_NOME_PLANO,
               NULL CAD_SET_DS_SETOR,
               TO_CHAR(ATD.ATD_ATE_DT_ATENDIMENTO,'DD/MM/YYYY') ATD_ATE_DT_ATENDIMENTO,
               ATD.ATD_ATE_HR_ATENDIMENTO,
               TO_CHAR(INA.ATD_INA_DT_ALTA_CLINICA,'DD/MM/YYYY') ATD_INA_DT_ALTA_CLINICA,
               INA.ATD_INA_HR_ALTA_CLINICA,
               TO_CHAR(CCP.FAT_CCP_DT_PARCELA,'DD/MM/YYYY') FAT_CCP_DT_PARCELA,
               CCI.CAD_PRD_ID,
               CCP.FAT_CCP_HR_PARCELA,
               TO_CHAR(CCP.FAT_CCP_DT_PARCELA_INI,'DD/MM/YYYY') FAT_CCP_DT_PARCELA_INI--,
            
               
   FROM         TB_FAT_FCL_CONTR_EMI_LOTE FCL
  JOIN          TB_FAT_CCI_CONTA_CONSU_ITEM CCI
  ON            CCI.FAT_CCP_ID            = FCL.FAT_CCP_ID
  AND           CCI.ATD_ATE_ID            = FCL.ATD_ATE_ID
  AND           CCI.FAT_COC_ID            = FCL.FAT_COC_ID
  AND           CCI.CAD_PAC_ID_PACIENTE   = FCL.CAD_PAC_ID_PACIENTE  
  JOIN          TB_FAT_CCP_CONTA_CONS_PARC  CCP
  ON            CCP.FAT_CCP_ID            = CCI.FAT_CCP_ID
  AND           CCP.FAT_COC_ID            = CCI.FAT_COC_ID
  AND           CCP.ATD_ATE_ID            = CCI.ATD_ATE_ID
  AND           CCP.CAD_PAC_ID_PACIENTE   = CCI.CAD_PAC_ID_PACIENTE 
  JOIN          TB_ATD_ATE_ATENDIMENTO      ATD
  ON            ATD.ATD_ATE_ID            = CCI.ATD_ATE_ID
  LEFT JOIN     TB_CAD_PRD_PRODUTO          PRD
  ON            PRD.CAD_PRD_ID            = CCI.CAD_PRD_ID
  LEFT JOIN     TB_CAD_TAP_TP_ATRIB_PRODUTO TAP
  ON            TAP.CAD_TAP_TP_ATRIBUTO   = PRD.CAD_TAP_TP_ATRIBUTO
  JOIN          TB_FAT_MCC_MOV_COM_CONSUMO MCC
  ON            MCC.FAT_MCC_ID          = CCI.FAT_MCC_ID
  AND           MCC.ATD_ATE_ID          = CCI.ATD_ATE_ID
  JOIN          TB_CAD_SET_SETOR          SETOR
  ON            SETOR.CAD_SET_ID        = MCC.CAD_SET_ID
  JOIN          TB_CAD_PAC_PACIENTE       PAC
  ON            PAC.CAD_PAC_ID_PACIENTE = CCP.CAD_PAC_ID_PACIENTE
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
  LEFT JOIN     TB_TIS_MSI_MOTIVO_SAIDA_INT MSI
  ON            MSI.TIS_MSI_CD_MOTIVOSAIDAINT = CCP.TIS_MSI_CD_MOTIVOSAIDAINT
  JOIN          TB_CAD_UNI_UNIDADE          UNI
  ON            UNI.CAD_UNI_ID_UNIDADE    = CCI.CAD_UNI_ID_UNIDADE 
  LEFT JOIN     TB_CAD_APM_APRES_PRO_MATMED APM
  ON            APM.CAD_APM_ID_MATMED     = PRD.CAD_APM_ID_MATMED
  LEFT JOIN     TB_ATD_GUI_GUIAATEND  GUI
  ON             GUI.ATD_ATE_ID            = CCI.ATD_ATE_ID
  AND            GUI.CAD_PAC_ID_PACIENTE   = CCI.CAD_PAC_ID_PACIENTE
  and            GUI.ATD_GUI_FL_GUIAPRINC_OK = 'S'
     WHERE  (pLOTE IS NULL OR FCL.FAT_FCL_NR_SEQ_LOTE = pLOTE)
     AND    (CCI.FAT_CCI_FL_STATUS     = 'A')
     AND    (pFAT_COC_ID  IS NULL OR FCL.FAT_COC_ID = pFAT_COC_ID)
     AND    (pFAT_CCP_ID IS NULL OR FCL.FAT_CCP_ID = pFAT_CCP_ID)
     AND    (pATD_ATE_ID IS NULL OR FCL.ATD_ATE_ID = pATD_ATE_ID)
     AND    (pCAD_PAC_ID_PACIENTE IS NULL OR FCL.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE)
     AND    ((CCI.FAT_CCI_FL_PACOTE IS NULL) OR (CCI.FAT_CCI_FL_PACOTE = 'N'))
  
     AND    (PRD.TIS_MED_CD_TABELAMEDICA != 'IP')
     AND    (CCI.CAD_TAP_TP_ATRIBUTO IN ('MAT','MED'))
  
  
  ORDER BY  CASE WHEN SETOR.CAD_SET_CD_SETOR = 'HEMD' THEN 'HEMODINAMICA'
                    WHEN SETOR.CAD_SET_CD_SETOR = 'ENDO' THEN 'ENDOSCOPIA'
                    WHEN SETOR.CAD_SET_CD_SETOR = 'CECI' THEN 'CENTRO CIRURGICO'
                    ELSE 'ENFERMARIA' 
                END,FCL.FAT_FCL_NR_SEQ_IMPRIME, CCI.FAT_CCI_FL_FRACIONADO , PRD.CAD_PRD_DS_DESCRICAO
 
  ;
  /* (SELECT   DISTINCT      SUM(CCI1.FAT_CCI_VL_FATURADO)  
                    FROM         TB_FAT_FCL_CONTR_EMI_LOTE FCL1
                      JOIN          TB_FAT_CCI_CONTA_CONSU_ITEM CCI1
                      ON            CCI1.FAT_CCP_ID            = FCL1.FAT_CCP_ID
                      AND           CCI1.ATD_ATE_ID            = FCL1.ATD_ATE_ID
                      AND           CCI1.FAT_COC_ID            = FCL1.FAT_COC_ID
                      AND           CCI1.CAD_PAC_ID_PACIENTE   = FCL1.CAD_PAC_ID_PACIENTE
                      JOIN        TB_CAD_PRD_PRODUTO          PRD1
                      ON            PRD1.CAD_PRD_ID            = CCI1.CAD_PRD_ID
                    WHERE        (CCI1.FAT_COC_ID              = CCI.FAT_COC_ID)
                    AND          (CCI1.CAD_TAP_TP_ATRIBUTO     = 'MED')
                    AND          (CCI1.FAT_CCP_ID              = CCI.FAT_CCP_ID)
                    AND          (CCI1.ATD_ATE_ID              = CCI.ATD_ATE_ID)
                    AND          (CCI1.CAD_PAC_ID_PACIENTE     = CCI.CAD_PAC_ID_PACIENTE)
                    AND          ((CCI1.FAT_CCI_FL_PACOTE IS NULL) OR (CCI1.FAT_CCI_FL_PACOTE = 'N'))
                   -- AND          ((CCI.FAT_CCI_FL_KITPRA IS NULL) OR (CCI.FAT_CCI_FL_KITPRA = 'N'))
                    AND          (PRD1.TIS_MED_CD_TABELAMEDICA != 'IP')
                    AND          (CCI1.FAT_CCI_FL_STATUS       = 'A')
             ) TOTAL_MED,
               (SELECT   DISTINCT      SUM(CCI2.FAT_CCI_VL_FATURADO)
                   FROM         TB_FAT_FCL_CONTR_EMI_LOTE FCL2
                      JOIN          TB_FAT_CCI_CONTA_CONSU_ITEM CCI2
                      ON            CCI2.FAT_CCP_ID            = FCL2.FAT_CCP_ID
                      AND           CCI2.ATD_ATE_ID            = FCL2.ATD_ATE_ID
                      AND           CCI2.FAT_COC_ID            = FCL2.FAT_COC_ID
                      AND           CCI2.CAD_PAC_ID_PACIENTE   = FCL2.CAD_PAC_ID_PACIENTE
                       JOIN     TB_CAD_PRD_PRODUTO          PRD2
                      ON            PRD2.CAD_PRD_ID            = CCI1.CAD_PRD_ID
                   WHERE        (CCI2.FAT_COC_ID               = CCI.FAT_COC_ID)
                    AND          (CCI2.CAD_TAP_TP_ATRIBUTO     = 'MAT')
                    AND          (CCI2.FAT_CCP_ID              = CCI.FAT_CCP_ID)
                    AND          (CCI2.ATD_ATE_ID              = CCI.ATD_ATE_ID)
                    AND          (CCI2.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE)
                    AND          ((CCI2.FAT_CCI_FL_PACOTE IS NULL) OR (CCI.FAT_CCI_FL_PACOTE = 'N'))
                   -- AND          ((CCI.FAT_CCI_FL_KITPRA IS NULL) OR (CCI.FAT_CCI_FL_KITPRA = 'N'))
                    AND          (PRD2.TIS_MED_CD_TABELAMEDICA != 'IP')
                    AND          (CCI2.FAT_CCI_FL_STATUS       = 'A')
                  ) TOTAL_MAT*/
             io_cursor := v_cursor;
  end PRC_FAT_REL_CONTA_MATMED;
 