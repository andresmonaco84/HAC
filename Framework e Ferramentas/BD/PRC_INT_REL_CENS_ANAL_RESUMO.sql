CREATE OR REPLACE PROCEDURE "PRC_INT_REL_CENS_ANAL_RESUMO"
(pCAD_SET_ID                 IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
 PATD_ATE_DT_ATENDIMENTO_INI IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE,
 pCAD_UNI_ID_UNIDADE   IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
 pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
 pCOM_HOSP_DIA VARCHAR2 DEFAULT NULL,
 pCAD_CSE_ID IN TB_CAD_SET_SETOR.CAD_CSE_ID%TYPE DEFAULT NULL,
 io_cursor                   OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_INT_REL_CENS_ANAL_RESUMO
  *
  *    Data Criacao:   24/09/2009   Por: Pedro
  *    Data Alteracao:  15/9/2010  Por: Pedro
  *    Alterac?o: estava sem PATD_ATE_DT_ATENDIMENTO_INI nas sub-querys QTD_INT_VINDOS_DIA_ANTER
  *
  *    Funcao: Censo dos Setores (Analitico)
  *
  case when cnv.cad_cnv_cd_hac_prestador = 'SD01' then 'ACS'
                    when cnv.cad_cgc_id = 1 and cnv.cad_tpe_cd_codigo = NULL and cnv.cad_cnv_cd_hac_prestador != 'S077' then 'AMIL'
                    when cnv.cad_cnv_cd_hac_prestador in ('GG05', 'HAC', 'NP01', 'NR14', 'S077') then 'FUNC.'
                    when cnv.cad_cgc_id = 2 then 'MERCADO' 
                    else cnv.cad_cnv_cd_hac_prestador  end subgrupo
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
    SELECT NVL(FNC_INT_QTD_DIA(pCAD_SET_ID, PATD_ATE_DT_ATENDIMENTO_INI,
                               NULL,
                               NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,
                               'ACS',pCOM_HOSP_DIA, pCAD_CSE_ID ),
               0)  QTD_INT_NO_DIA_ACS,
               
           NVL(FNC_INT_QTD_DIA(pCAD_SET_ID,
                               PATD_ATE_DT_ATENDIMENTO_INI,
                               NULL,
                               NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,
                               'AMIL',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) QTD_INT_NO_DIA_AMIL,
               
           NVL(FNC_INT_QTD_DIA(pCAD_SET_ID,
                               PATD_ATE_DT_ATENDIMENTO_INI,
                               NULL,
                               NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,
                               'FUNCIONARIO',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) QTD_INT_NO_DIA_FUNCIONARIO,
               
           NVL(FNC_INT_QTD_DIA(pCAD_SET_ID,
                               PATD_ATE_DT_ATENDIMENTO_INI,
                               NULL,
                               NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,
                               'MERCADO',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) QTD_INT_NO_DIA_MERCADO,
               
           NVL(FNC_INT_QTD_DIA(pCAD_SET_ID,
                               PATD_ATE_DT_ATENDIMENTO_INI,
                               NULL,
                               NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,
                               'PARTICULAR',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) QTD_INT_NO_DIA_PARTICULAR,
               
           NVL(FNC_INT_QTD_MOV_RECEBIDAS(pCAD_SET_ID,
                                         PATD_ATE_DT_ATENDIMENTO_INI,
                                         NULL,
                                         NULL,
                                         pCAD_UNI_ID_UNIDADE,
                                         pCAD_CNV_ID_CONVENIO,
                                         'ACS',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0)  QTD_INT_RECEBIDAS_ACS,
               
           NVL(FNC_INT_QTD_MOV_RECEBIDAS(pCAD_SET_ID,
                                         PATD_ATE_DT_ATENDIMENTO_INI,
                                         NULL,
                                         NULL,
                                         pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,
                               'AMIL',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) QTD_INT_RECEBIDAS_AMIL,
               
           NVL(FNC_INT_QTD_MOV_RECEBIDAS(pCAD_SET_ID,
                                         PATD_ATE_DT_ATENDIMENTO_INI,
                                         NULL,
                                         NULL,
                                         pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,
                               'FUNCIONARIO',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) QTD_INT_RECEBIDAS_FUNCIONARIO,
               
           NVL(FNC_INT_QTD_MOV_RECEBIDAS(pCAD_SET_ID,
                                         PATD_ATE_DT_ATENDIMENTO_INI,
                                         NULL,
                                         NULL,
                                         pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,
                               'MERCADO',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) QTD_INT_RECEBIDAS_MERCADO,
               
           NVL(FNC_INT_QTD_MOV_RECEBIDAS(pCAD_SET_ID,
                                         PATD_ATE_DT_ATENDIMENTO_INI,
                                         NULL,
                                         NULL,
                                         pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,
                               'PARTICULAR',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) QTD_INT_RECEBIDAS_PARTICULAR,
               
           NVL((SELECT Count(DISTINCT IML.ATD_ATE_ID)
               -- IML.ATD_ATE_ID, IML.ATD_IML_DT_SAIDA, IML.ATD_IML_HR_SAIDA,IML.ATD_IML_DT_ENTRADA,IML.ATD_IML_HR_ENTRADA,
               -- SETOR.CAD_SET_DS_SETOR , ATD.ATD_ATE_DT_ATENDIMENTO
                 FROM TB_ATD_IML_INT_MOV_LEITO IML
                 JOIN TB_CAD_QLE_QUARTO_LEITO QLE ON QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                 JOIN TB_ATD_ATE_ATENDIMENTO ATD ON ATD.ATD_ATE_ID = IML.ATD_ATE_ID
                 JOIN TB_ASS_PAT_PACIEATEND PAT ON PAT.ATD_ATE_ID = ATD.ATD_ATE_ID
                 JOIN TB_CAD_PAC_PACIENTE PAC ON PAC.CAD_PAC_ID_PACIENTE = FNC_BUSCAR_PACIENTE_ATUAL(PAT.ATD_ATE_ID)
                JOIN TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = QLE.CAD_SET_ID
                 LEFT JOIN (SELECT IML3.ATD_ATE_ID,
                                  IML3.ATD_IML_DT_ENTRADA,
                                  IML3.ATD_IML_HR_ENTRADA,
                                  IML3.ATD_IML_DT_SAIDA,
                                  IML3.ATD_IML_HR_SAIDA,
                                  QLE3.CAD_SET_ID
                             FROM TB_ATD_IML_INT_MOV_LEITO IML3
                             JOIN TB_CAD_QLE_QUARTO_LEITO QLE3 ON QLE3.CAD_QLE_ID = IML3.CAD_CAD_QLE_ID
                             JOIN TB_ATD_ATE_ATENDIMENTO ATD3 ON ATD3.ATD_ATE_ID = IML3.ATD_ATE_ID
                            WHERE (IML3.ATD_IML_FL_STATUS = 'A')
                              AND (IML3.ATD_IML_DT_ENTRADA = PATD_ATE_DT_ATENDIMENTO_INI)
                              AND (ATD3.ATD_ATE_FL_STATUS = 'A')
                              AND IML3.ATD_IML_ID = FNC_INT_PRIM_MOV_QUARTO_LEITO(ATD3.ATD_ATE_ID)
                              AND (pCAD_UNI_ID_UNIDADE IS NULL OR ATD3.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
                           UNION
                           SELECT IML4.ATD_ATE_ID,
                                  IML4.ATD_IML_DT_ENTRADA,
                                  IML4.ATD_IML_HR_ENTRADA,
                                  IML4.ATD_IML_DT_SAIDA,
                                  IML4.ATD_IML_HR_SAIDA,
                                  QLE4.CAD_SET_ID
                             FROM TB_ATD_IML_INT_MOV_LEITO IML4
                             JOIN TB_CAD_QLE_QUARTO_LEITO QLE4 ON QLE4.CAD_QLE_ID = IML4.CAD_CAD_QLE_ID
                             JOIN TB_ATD_ATE_ATENDIMENTO ATD4 ON ATD4.ATD_ATE_ID = IML4.ATD_ATE_ID
                            WHERE (IML4.ATD_IML_FL_STATUS = 'A')
                              AND (IML4.ATD_IML_DT_ENTRADA = PATD_ATE_DT_ATENDIMENTO_INI + 1)
                              AND (ATD4.ATD_ATE_FL_STATUS = 'A')
                              AND IML4.ATD_IML_ID = FNC_INT_PRIM_MOV_QUARTO_LEITO(ATD4.ATD_ATE_ID)
                              AND (pCAD_UNI_ID_UNIDADE IS NULL OR ATD4.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)                              
                              AND EXISTS
                            (SELECT IMS.ATD_ATE_ID,
                                          IMS.ATD_IMS_DT_SAIDA,
                                          IMS.ATD_IMS_HR_SAIDA,
                                          IMS.ATD_IMS_DT_ENTRADA,
                                          IMS.ATD_IMS_HR_ENTRADA,
                                          IMS.CAD_SET_ID_SETOR
                                     FROM TB_ATD_IMS_INT_MOV_SETOR IMS
                                     JOIN TB_CAD_SET_SETOR SETOR4 ON SETOR4.CAD_SET_ID = IMS.CAD_SET_ID_SETOR
                                    WHERE IMS.ATD_ATE_ID = IML4.ATD_ATE_ID
                                      AND IMS.ATD_IMS_FL_STATUS = 'A'
                                      AND IMS.ATD_IMS_DT_SAIDA = IML4.ATD_IML_DT_ENTRADA
                                      AND IMS.ATD_IMS_HR_SAIDA = IML4.ATD_IML_HR_ENTRADA
                                      AND SETOR4.CAD_SET_ID = IMS.CAD_SET_ID_SETOR
                                      AND SETOR4.CAD_SET_CD_SETOR IN ('ADM', 'CECI')
                                      AND IMS.ATD_IMS_DT_ENTRADA = PATD_ATE_DT_ATENDIMENTO_INI
                                      AND IMS.ATD_IMS_DT_ENTRADA = ATD4.ATD_ATE_DT_ATENDIMENTO
                                      AND IMS.ATD_IMS_HR_ENTRADA = ATD4.ATD_ATE_HR_ATENDIMENTO)
                            ORDER BY 1, 2, 3, 4, 5, 6) DESTINO
                   ON DESTINO.ATD_ATE_ID = IML.ATD_ATE_ID
                  AND (DESTINO.ATD_IML_DT_SAIDA IS NULL OR DESTINO.ATD_IML_DT_SAIDA >= IML.ATD_IML_DT_ENTRADA)
                  AND DESTINO.ATD_IML_HR_ENTRADA = IML.ATD_IML_HR_SAIDA
                WHERE IML.ATD_IML_DT_ENTRADA < PATD_ATE_DT_ATENDIMENTO_INI
                  and (ATD.ATD_ATE_DT_ATENDIMENTO < PATD_ATE_DT_ATENDIMENTO_INI)
                  AND (IML.ATD_IML_DT_SAIDA >= PATD_ATE_DT_ATENDIMENTO_INI OR IML.ATD_IML_DT_SAIDA IS NULL)
                  AND (DESTINO.CAD_SET_ID IS NULL OR DESTINO.CAD_SET_ID != QLE.CAD_SET_ID)
                  AND (pCAD_SET_ID IS NULL OR QLE.CAD_SET_ID = pCAD_SET_ID)
                  AND (pCAD_UNI_ID_UNIDADE IS NULL OR atd.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
                  AND (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)                  
                  AND (IML.ATD_IML_FL_STATUS = 'A')
               AND ((pCOM_HOSP_DIA IS NULL) OR 
                      (pCOM_HOSP_DIA = '0' AND (pCAD_CSE_ID = '8') AND SETOR.CAD_CSE_ID = 8) OR                      
(pCOM_HOSP_DIA = '0' AND (PCAD_CSE_ID NOT IN ('8','9') OR PCAD_CSE_ID IS NULL) AND SETOR.CAD_CSE_ID NOT IN ('8','9')) OR
                      (pCOM_HOSP_DIA = '1' AND SETOR.CAD_CSE_ID = 8))
                 AND (PAC.CAD_CNV_ID_CONVENIO=281)
                ),
               0) QTD_INT_VINDOS_DIA_ANTER_ACS,
               
           NVL((SELECT Count(DISTINCT IML.ATD_ATE_ID)
                 FROM TB_ATD_IML_INT_MOV_LEITO IML
                 JOIN TB_CAD_QLE_QUARTO_LEITO QLE ON QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                 JOIN TB_ATD_ATE_ATENDIMENTO ATD ON ATD.ATD_ATE_ID = IML.ATD_ATE_ID
                 JOIN TB_ASS_PAT_PACIEATEND PAT ON PAT.ATD_ATE_ID = ATD.ATD_ATE_ID
                 JOIN TB_CAD_PAC_PACIENTE PAC ON PAC.CAD_PAC_ID_PACIENTE = FNC_BUSCAR_PACIENTE_ATUAL(PAT.ATD_ATE_ID)
                 JOIN TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = QLE.CAD_SET_ID
                JOIN TB_CAD_CNV_CONVENIO CNV1 ON CNV1.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
                 LEFT JOIN (SELECT IML3.ATD_ATE_ID,
                                  IML3.ATD_IML_DT_ENTRADA,
                                  IML3.ATD_IML_HR_ENTRADA,
                                  IML3.ATD_IML_DT_SAIDA,
                                  IML3.ATD_IML_HR_SAIDA,
                                  QLE3.CAD_SET_ID
                             FROM TB_ATD_IML_INT_MOV_LEITO IML3
                             JOIN TB_CAD_QLE_QUARTO_LEITO QLE3 ON QLE3.CAD_QLE_ID = IML3.CAD_CAD_QLE_ID
                             JOIN TB_ATD_ATE_ATENDIMENTO ATD3 ON ATD3.ATD_ATE_ID = IML3.ATD_ATE_ID
                            WHERE (IML3.ATD_IML_FL_STATUS = 'A')
                              AND (IML3.ATD_IML_DT_ENTRADA = PATD_ATE_DT_ATENDIMENTO_INI)
                              AND (ATD3.ATD_ATE_FL_STATUS = 'A')
                              AND IML3.ATD_IML_ID = FNC_INT_PRIM_MOV_QUARTO_LEITO(ATD3.ATD_ATE_ID)
                           UNION
                           SELECT IML4.ATD_ATE_ID,
                                  IML4.ATD_IML_DT_ENTRADA,
                                  IML4.ATD_IML_HR_ENTRADA,
                                  IML4.ATD_IML_DT_SAIDA,
                                  IML4.ATD_IML_HR_SAIDA,
                                  QLE4.CAD_SET_ID
                             FROM TB_ATD_IML_INT_MOV_LEITO IML4
                             JOIN TB_CAD_QLE_QUARTO_LEITO QLE4 ON QLE4.CAD_QLE_ID = IML4.CAD_CAD_QLE_ID
                             JOIN TB_ATD_ATE_ATENDIMENTO ATD4 ON ATD4.ATD_ATE_ID = IML4.ATD_ATE_ID
                            WHERE (IML4.ATD_IML_FL_STATUS = 'A')
                              AND (IML4.ATD_IML_DT_ENTRADA = PATD_ATE_DT_ATENDIMENTO_INI + 1)
                              AND (ATD4.ATD_ATE_FL_STATUS = 'A')
                              AND IML4.ATD_IML_ID = FNC_INT_PRIM_MOV_QUARTO_LEITO(ATD4.ATD_ATE_ID)
                              AND EXISTS
                            (SELECT IMS.ATD_ATE_ID,
                                          IMS.ATD_IMS_DT_SAIDA,
                                          IMS.ATD_IMS_HR_SAIDA,
                                          IMS.ATD_IMS_DT_ENTRADA,
                                          IMS.ATD_IMS_HR_ENTRADA,
                                          IMS.CAD_SET_ID_SETOR
                                     FROM TB_ATD_IMS_INT_MOV_SETOR IMS
                                     JOIN TB_CAD_SET_SETOR SETOR4 ON SETOR4.CAD_SET_ID = IMS.CAD_SET_ID_SETOR
                                    WHERE IMS.ATD_ATE_ID = IML4.ATD_ATE_ID
                                      AND IMS.ATD_IMS_FL_STATUS = 'A'
                                      AND IMS.ATD_IMS_DT_SAIDA = IML4.ATD_IML_DT_ENTRADA
                                      AND IMS.ATD_IMS_HR_SAIDA = IML4.ATD_IML_HR_ENTRADA
                                      AND SETOR4.CAD_SET_ID = IMS.CAD_SET_ID_SETOR
                                      AND SETOR4.CAD_SET_CD_SETOR IN ('ADM', 'CECI')
                                      AND IMS.ATD_IMS_DT_ENTRADA = PATD_ATE_DT_ATENDIMENTO_INI
                                      AND IMS.ATD_IMS_DT_ENTRADA = ATD4.ATD_ATE_DT_ATENDIMENTO
                                      AND IMS.ATD_IMS_HR_ENTRADA = ATD4.ATD_ATE_HR_ATENDIMENTO)
                            ORDER BY 1, 2, 3, 4, 5, 6) DESTINO
                   ON DESTINO.ATD_ATE_ID = IML.ATD_ATE_ID
                  AND (DESTINO.ATD_IML_DT_SAIDA IS NULL OR DESTINO.ATD_IML_DT_SAIDA >= IML.ATD_IML_DT_ENTRADA)
                  AND DESTINO.ATD_IML_HR_ENTRADA = IML.ATD_IML_HR_SAIDA
                WHERE IML.ATD_IML_DT_ENTRADA < PATD_ATE_DT_ATENDIMENTO_INI
                  and (ATD.ATD_ATE_DT_ATENDIMENTO < PATD_ATE_DT_ATENDIMENTO_INI)
                  AND (IML.ATD_IML_DT_SAIDA >= PATD_ATE_DT_ATENDIMENTO_INI OR IML.ATD_IML_DT_SAIDA IS NULL)

                  AND (DESTINO.CAD_SET_ID IS NULL OR DESTINO.CAD_SET_ID != QLE.CAD_SET_ID)
                  AND (pCAD_SET_ID IS NULL OR QLE.CAD_SET_ID = pCAD_SET_ID)
                  AND (pCAD_UNI_ID_UNIDADE IS NULL OR atd.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)                  
                  AND (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)                    
                  AND (IML.ATD_IML_FL_STATUS = 'A')
                AND ((pCOM_HOSP_DIA IS NULL) OR 
                      (pCOM_HOSP_DIA = '0' AND (pCAD_CSE_ID = '8') AND SETOR.CAD_CSE_ID = 8) OR                      
(pCOM_HOSP_DIA = '0' AND (PCAD_CSE_ID NOT IN ('8','9') OR PCAD_CSE_ID IS NULL) AND SETOR.CAD_CSE_ID NOT IN ('8','9')) OR
                      (pCOM_HOSP_DIA = '1' AND SETOR.CAD_CSE_ID = 8))
             AND cnv1.cad_cgc_id = 1 and cnv1.CAD_CNV_ID_CONVENIO = NULL and cnv1.cad_cnv_cd_hac_prestador != 'S077' 
                ),
               0) QTD_INT_VINDOS_DIA_ANTER_AMIL,
               
           NVL((SELECT Count(DISTINCT IML.ATD_ATE_ID)
                 FROM TB_ATD_IML_INT_MOV_LEITO IML
                 JOIN TB_CAD_QLE_QUARTO_LEITO QLE ON QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                 JOIN TB_ATD_ATE_ATENDIMENTO ATD ON ATD.ATD_ATE_ID = IML.ATD_ATE_ID
                 JOIN TB_ASS_PAT_PACIEATEND PAT ON PAT.ATD_ATE_ID = ATD.ATD_ATE_ID
                 JOIN TB_CAD_PAC_PACIENTE PAC ON PAC.CAD_PAC_ID_PACIENTE = FNC_BUSCAR_PACIENTE_ATUAL(PAT.ATD_ATE_ID)
                 JOIN TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = QLE.CAD_SET_ID               
                 JOIN TB_CAD_CNV_CONVENIO CNV1 ON CNV1.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
                 LEFT JOIN (SELECT IML3.ATD_ATE_ID,
                                  IML3.ATD_IML_DT_ENTRADA,
                                  IML3.ATD_IML_HR_ENTRADA,
                                  IML3.ATD_IML_DT_SAIDA,
                                  IML3.ATD_IML_HR_SAIDA,
                                  QLE3.CAD_SET_ID
                             FROM TB_ATD_IML_INT_MOV_LEITO IML3
                             JOIN TB_CAD_QLE_QUARTO_LEITO QLE3 ON QLE3.CAD_QLE_ID = IML3.CAD_CAD_QLE_ID
                             JOIN TB_ATD_ATE_ATENDIMENTO ATD3 ON ATD3.ATD_ATE_ID = IML3.ATD_ATE_ID
                            WHERE (IML3.ATD_IML_FL_STATUS = 'A')
                              AND (IML3.ATD_IML_DT_ENTRADA = PATD_ATE_DT_ATENDIMENTO_INI)
                              AND (ATD3.ATD_ATE_FL_STATUS = 'A')
                              AND IML3.ATD_IML_ID = FNC_INT_PRIM_MOV_QUARTO_LEITO(ATD3.ATD_ATE_ID)
                           UNION
                           SELECT IML4.ATD_ATE_ID,
                                  IML4.ATD_IML_DT_ENTRADA,
                                  IML4.ATD_IML_HR_ENTRADA,
                                  IML4.ATD_IML_DT_SAIDA,
                                  IML4.ATD_IML_HR_SAIDA,
                                  QLE4.CAD_SET_ID
                             FROM TB_ATD_IML_INT_MOV_LEITO IML4
                             JOIN TB_CAD_QLE_QUARTO_LEITO QLE4 ON QLE4.CAD_QLE_ID = IML4.CAD_CAD_QLE_ID
                             JOIN TB_ATD_ATE_ATENDIMENTO ATD4 ON ATD4.ATD_ATE_ID = IML4.ATD_ATE_ID
                            WHERE (IML4.ATD_IML_FL_STATUS = 'A')
                              AND (IML4.ATD_IML_DT_ENTRADA = PATD_ATE_DT_ATENDIMENTO_INI + 1)
                              AND (ATD4.ATD_ATE_FL_STATUS = 'A')
                              AND IML4.ATD_IML_ID = FNC_INT_PRIM_MOV_QUARTO_LEITO(ATD4.ATD_ATE_ID)
                              AND EXISTS
                            (SELECT IMS.ATD_ATE_ID,
                                          IMS.ATD_IMS_DT_SAIDA,
                                          IMS.ATD_IMS_HR_SAIDA,
                                          IMS.ATD_IMS_DT_ENTRADA,
                                          IMS.ATD_IMS_HR_ENTRADA,
                                          IMS.CAD_SET_ID_SETOR
                                     FROM TB_ATD_IMS_INT_MOV_SETOR IMS
                                     JOIN TB_CAD_SET_SETOR SETOR4
                                       ON SETOR4.CAD_SET_ID =
                                          IMS.CAD_SET_ID_SETOR
                                    WHERE IMS.ATD_ATE_ID = IML4.ATD_ATE_ID
                                      AND IMS.ATD_IMS_FL_STATUS = 'A'
                                      AND IMS.ATD_IMS_DT_SAIDA = IML4.ATD_IML_DT_ENTRADA
                                      AND IMS.ATD_IMS_HR_SAIDA = IML4.ATD_IML_HR_ENTRADA
                                      AND SETOR4.CAD_SET_ID = IMS.CAD_SET_ID_SETOR
                                      AND SETOR4.CAD_SET_CD_SETOR IN ('ADM', 'CECI')
                                      AND IMS.ATD_IMS_DT_ENTRADA = PATD_ATE_DT_ATENDIMENTO_INI
                                      AND IMS.ATD_IMS_DT_ENTRADA = ATD4.ATD_ATE_DT_ATENDIMENTO
                                      AND IMS.ATD_IMS_HR_ENTRADA = ATD4.ATD_ATE_HR_ATENDIMENTO)
                            ORDER BY 1, 2, 3, 4, 5, 6) DESTINO
                   ON DESTINO.ATD_ATE_ID = IML.ATD_ATE_ID
                  AND (DESTINO.ATD_IML_DT_SAIDA IS NULL OR DESTINO.ATD_IML_DT_SAIDA >= IML.ATD_IML_DT_ENTRADA)
                  AND DESTINO.ATD_IML_HR_ENTRADA = IML.ATD_IML_HR_SAIDA
                WHERE IML.ATD_IML_DT_ENTRADA < PATD_ATE_DT_ATENDIMENTO_INI
                  and (ATD.ATD_ATE_DT_ATENDIMENTO < PATD_ATE_DT_ATENDIMENTO_INI)
                  AND (IML.ATD_IML_DT_SAIDA >= PATD_ATE_DT_ATENDIMENTO_INI OR IML.ATD_IML_DT_SAIDA IS NULL)
                  AND (DESTINO.CAD_SET_ID IS NULL OR DESTINO.CAD_SET_ID != QLE.CAD_SET_ID)
                  AND (pCAD_SET_ID IS NULL OR QLE.CAD_SET_ID = pCAD_SET_ID)
                  AND (pCAD_UNI_ID_UNIDADE IS NULL OR atd.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
                  AND (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)                    
                  AND (IML.ATD_IML_FL_STATUS = 'A')
                 
                 AND ((pCOM_HOSP_DIA IS NULL) OR 
                      (pCOM_HOSP_DIA = '0' AND (pCAD_CSE_ID = '8') AND SETOR.CAD_CSE_ID = 8) OR                      
(pCOM_HOSP_DIA = '0' AND (PCAD_CSE_ID NOT IN ('8','9') OR PCAD_CSE_ID IS NULL) AND SETOR.CAD_CSE_ID NOT IN ('8','9')) OR
                      (pCOM_HOSP_DIA = '1' AND SETOR.CAD_CSE_ID = 8))
                      
                 AND cnv1.cad_cnv_cd_hac_prestador in ('GG05', 'HAC', 'NP01', 'NR14', 'S077') 
                ),
               0) QTD_INT_VINDOS_DIA_ANTER_FUNC,
               
           NVL((SELECT Count(DISTINCT IML.ATD_ATE_ID)
                 FROM TB_ATD_IML_INT_MOV_LEITO IML
                 JOIN TB_CAD_QLE_QUARTO_LEITO QLE ON QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                 JOIN TB_ATD_ATE_ATENDIMENTO ATD ON ATD.ATD_ATE_ID = IML.ATD_ATE_ID
                 JOIN TB_ASS_PAT_PACIEATEND PAT ON PAT.ATD_ATE_ID = ATD.ATD_ATE_ID
                 JOIN TB_CAD_PAC_PACIENTE PAC ON PAC.CAD_PAC_ID_PACIENTE = FNC_BUSCAR_PACIENTE_ATUAL(PAT.ATD_ATE_ID)
                 JOIN TB_CAD_CNV_CONVENIO CNV1 ON CNV1.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
                 JOIN TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = QLE.CAD_SET_ID                 
                 LEFT JOIN (SELECT IML3.ATD_ATE_ID,
                                  IML3.ATD_IML_DT_ENTRADA,
                                  IML3.ATD_IML_HR_ENTRADA,
                                  IML3.ATD_IML_DT_SAIDA,
                                  IML3.ATD_IML_HR_SAIDA,
                                  QLE3.CAD_SET_ID
                             FROM TB_ATD_IML_INT_MOV_LEITO IML3
                             JOIN TB_CAD_QLE_QUARTO_LEITO QLE3 ON QLE3.CAD_QLE_ID = IML3.CAD_CAD_QLE_ID
                             JOIN TB_ATD_ATE_ATENDIMENTO ATD3 ON ATD3.ATD_ATE_ID = IML3.ATD_ATE_ID
                            WHERE (IML3.ATD_IML_FL_STATUS = 'A')
                              AND (IML3.ATD_IML_DT_ENTRADA = PATD_ATE_DT_ATENDIMENTO_INI)
                              AND (ATD3.ATD_ATE_FL_STATUS = 'A')
                              AND IML3.ATD_IML_ID = FNC_INT_PRIM_MOV_QUARTO_LEITO(ATD3.ATD_ATE_ID)
                           UNION
                           SELECT IML4.ATD_ATE_ID,
                                  IML4.ATD_IML_DT_ENTRADA,
                                  IML4.ATD_IML_HR_ENTRADA,
                                  IML4.ATD_IML_DT_SAIDA,
                                  IML4.ATD_IML_HR_SAIDA,
                                  QLE4.CAD_SET_ID
                             FROM TB_ATD_IML_INT_MOV_LEITO IML4
                             JOIN TB_CAD_QLE_QUARTO_LEITO QLE4 ON QLE4.CAD_QLE_ID = IML4.CAD_CAD_QLE_ID
                             JOIN TB_ATD_ATE_ATENDIMENTO ATD4 ON ATD4.ATD_ATE_ID = IML4.ATD_ATE_ID
                            WHERE (IML4.ATD_IML_FL_STATUS = 'A')
                              AND (IML4.ATD_IML_DT_ENTRADA = PATD_ATE_DT_ATENDIMENTO_INI + 1)
                              AND (ATD4.ATD_ATE_FL_STATUS = 'A')
                              AND IML4.ATD_IML_ID = FNC_INT_PRIM_MOV_QUARTO_LEITO(ATD4.ATD_ATE_ID)
                              AND EXISTS
                            (SELECT IMS.ATD_ATE_ID,
                                          IMS.ATD_IMS_DT_SAIDA,
                                          IMS.ATD_IMS_HR_SAIDA,
                                          IMS.ATD_IMS_DT_ENTRADA,
                                          IMS.ATD_IMS_HR_ENTRADA,
                                          IMS.CAD_SET_ID_SETOR
                                     FROM TB_ATD_IMS_INT_MOV_SETOR IMS
                                     JOIN TB_CAD_SET_SETOR SETOR4 ON SETOR4.CAD_SET_ID = IMS.CAD_SET_ID_SETOR
                                    WHERE IMS.ATD_ATE_ID = IML4.ATD_ATE_ID
                                      AND IMS.ATD_IMS_FL_STATUS = 'A'
                                      AND IMS.ATD_IMS_DT_SAIDA = IML4.ATD_IML_DT_ENTRADA
                                      AND IMS.ATD_IMS_HR_SAIDA = IML4.ATD_IML_HR_ENTRADA
                                      AND SETOR4.CAD_SET_ID = IMS.CAD_SET_ID_SETOR
                                      AND SETOR4.CAD_SET_CD_SETOR IN ('ADM', 'CECI')
                                      AND IMS.ATD_IMS_DT_ENTRADA = PATD_ATE_DT_ATENDIMENTO_INI
                                      AND IMS.ATD_IMS_DT_ENTRADA = ATD4.ATD_ATE_DT_ATENDIMENTO
                                      AND IMS.ATD_IMS_HR_ENTRADA = ATD4.ATD_ATE_HR_ATENDIMENTO)
                            ORDER BY 1, 2, 3, 4, 5, 6) DESTINO
                   ON DESTINO.ATD_ATE_ID = IML.ATD_ATE_ID
                  AND (DESTINO.ATD_IML_DT_SAIDA IS NULL OR DESTINO.ATD_IML_DT_SAIDA >= IML.ATD_IML_DT_ENTRADA)
                  AND DESTINO.ATD_IML_HR_ENTRADA = IML.ATD_IML_HR_SAIDA
                WHERE IML.ATD_IML_DT_ENTRADA < PATD_ATE_DT_ATENDIMENTO_INI
                  and (ATD.ATD_ATE_DT_ATENDIMENTO < PATD_ATE_DT_ATENDIMENTO_INI)
                  AND (IML.ATD_IML_DT_SAIDA >= PATD_ATE_DT_ATENDIMENTO_INI OR IML.ATD_IML_DT_SAIDA IS NULL)
                  AND (DESTINO.CAD_SET_ID IS NULL OR DESTINO.CAD_SET_ID != QLE.CAD_SET_ID)
                  AND (pCAD_SET_ID IS NULL OR QLE.CAD_SET_ID = pCAD_SET_ID)
                  AND (pCAD_UNI_ID_UNIDADE IS NULL OR atd.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
                  AND (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)                    
                  AND (IML.ATD_IML_FL_STATUS = 'A')
AND ((pCOM_HOSP_DIA IS NULL) OR 
                      (pCOM_HOSP_DIA = '0' AND (pCAD_CSE_ID = '8') AND SETOR.CAD_CSE_ID = 8) OR                      
(pCOM_HOSP_DIA = '0' AND (PCAD_CSE_ID NOT IN ('8','9') OR PCAD_CSE_ID IS NULL) AND SETOR.CAD_CSE_ID NOT IN ('8','9')) OR
                      (pCOM_HOSP_DIA = '1' AND SETOR.CAD_CSE_ID = 8))
                      
                 AND CNV1.CAD_CGC_ID = 2 AND cnv1.cad_cnv_id_convenio!=282 
                ),
               0) QTD_INT_VINDOS_DIA_ANTER_MERC,
               
           NVL((SELECT Count(DISTINCT IML.ATD_ATE_ID)
                 FROM TB_ATD_IML_INT_MOV_LEITO IML
                 JOIN TB_CAD_QLE_QUARTO_LEITO QLE ON QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                 JOIN TB_ATD_ATE_ATENDIMENTO ATD ON ATD.ATD_ATE_ID = IML.ATD_ATE_ID
                 JOIN TB_ASS_PAT_PACIEATEND PAT ON PAT.ATD_ATE_ID = ATD.ATD_ATE_ID
                 JOIN TB_CAD_PAC_PACIENTE PAC ON PAC.CAD_PAC_ID_PACIENTE = FNC_BUSCAR_PACIENTE_ATUAL(PAT.ATD_ATE_ID)
                 JOIN TB_CAD_CNV_CONVENIO CNV1 ON CNV1.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
                 JOIN TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = QLE.CAD_SET_ID
                 LEFT JOIN (SELECT IML3.ATD_ATE_ID,
                                  IML3.ATD_IML_DT_ENTRADA,
                                  IML3.ATD_IML_HR_ENTRADA,
                                  IML3.ATD_IML_DT_SAIDA,
                                  IML3.ATD_IML_HR_SAIDA,
                                  QLE3.CAD_SET_ID
                             FROM TB_ATD_IML_INT_MOV_LEITO IML3
                             JOIN TB_CAD_QLE_QUARTO_LEITO QLE3 ON QLE3.CAD_QLE_ID = IML3.CAD_CAD_QLE_ID
                             JOIN TB_ATD_ATE_ATENDIMENTO ATD3 ON ATD3.ATD_ATE_ID = IML3.ATD_ATE_ID
                            WHERE (IML3.ATD_IML_FL_STATUS = 'A')
                              AND (IML3.ATD_IML_DT_ENTRADA = PATD_ATE_DT_ATENDIMENTO_INI)
                              AND (ATD3.ATD_ATE_FL_STATUS = 'A')
                              AND IML3.ATD_IML_ID = FNC_INT_PRIM_MOV_QUARTO_LEITO(ATD3.ATD_ATE_ID)
                           UNION
                           SELECT IML4.ATD_ATE_ID,
                                  IML4.ATD_IML_DT_ENTRADA,
                                  IML4.ATD_IML_HR_ENTRADA,
                                  IML4.ATD_IML_DT_SAIDA,
                                  IML4.ATD_IML_HR_SAIDA,
                                  QLE4.CAD_SET_ID
                             FROM TB_ATD_IML_INT_MOV_LEITO IML4
                             JOIN TB_CAD_QLE_QUARTO_LEITO QLE4 ON QLE4.CAD_QLE_ID = IML4.CAD_CAD_QLE_ID
                             JOIN TB_ATD_ATE_ATENDIMENTO ATD4 ON ATD4.ATD_ATE_ID = IML4.ATD_ATE_ID
                            WHERE (IML4.ATD_IML_FL_STATUS = 'A')
                              AND (IML4.ATD_IML_DT_ENTRADA = PATD_ATE_DT_ATENDIMENTO_INI + 1)
                              AND (ATD4.ATD_ATE_FL_STATUS = 'A')
                              AND IML4.ATD_IML_ID = FNC_INT_PRIM_MOV_QUARTO_LEITO(ATD4.ATD_ATE_ID)
                              AND EXISTS
                            (SELECT IMS.ATD_ATE_ID,
                                          IMS.ATD_IMS_DT_SAIDA,
                                          IMS.ATD_IMS_HR_SAIDA,
                                          IMS.ATD_IMS_DT_ENTRADA,
                                          IMS.ATD_IMS_HR_ENTRADA,
                                          IMS.CAD_SET_ID_SETOR
                                     FROM TB_ATD_IMS_INT_MOV_SETOR IMS
                                     JOIN TB_CAD_SET_SETOR SETOR4 ON SETOR4.CAD_SET_ID = IMS.CAD_SET_ID_SETOR
                                    WHERE IMS.ATD_ATE_ID = IML4.ATD_ATE_ID
                                      AND IMS.ATD_IMS_FL_STATUS = 'A'
                                      AND IMS.ATD_IMS_DT_SAIDA = IML4.ATD_IML_DT_ENTRADA
                                      AND IMS.ATD_IMS_HR_SAIDA = IML4.ATD_IML_HR_ENTRADA
                                      AND SETOR4.CAD_SET_ID = IMS.CAD_SET_ID_SETOR
                                      AND SETOR4.CAD_SET_CD_SETOR IN ('ADM', 'CECI')
                                      AND IMS.ATD_IMS_DT_ENTRADA = PATD_ATE_DT_ATENDIMENTO_INI
                                      AND IMS.ATD_IMS_DT_ENTRADA = ATD4.ATD_ATE_DT_ATENDIMENTO
                                      AND IMS.ATD_IMS_HR_ENTRADA = ATD4.ATD_ATE_HR_ATENDIMENTO)
                            ORDER BY 1, 2, 3, 4, 5, 6) DESTINO
                   ON DESTINO.ATD_ATE_ID = IML.ATD_ATE_ID
                  AND (DESTINO.ATD_IML_DT_SAIDA IS NULL OR
                      DESTINO.ATD_IML_DT_SAIDA >= IML.ATD_IML_DT_ENTRADA)
                  AND DESTINO.ATD_IML_HR_ENTRADA = IML.ATD_IML_HR_SAIDA
                WHERE IML.ATD_IML_DT_ENTRADA < PATD_ATE_DT_ATENDIMENTO_INI
                  and (ATD.ATD_ATE_DT_ATENDIMENTO < PATD_ATE_DT_ATENDIMENTO_INI)
                  AND (IML.ATD_IML_DT_SAIDA >= PATD_ATE_DT_ATENDIMENTO_INI OR IML.ATD_IML_DT_SAIDA IS NULL)
                  AND (DESTINO.CAD_SET_ID IS NULL OR DESTINO.CAD_SET_ID != QLE.CAD_SET_ID)
                  AND (pCAD_SET_ID IS NULL OR QLE.CAD_SET_ID = pCAD_SET_ID)
                  AND (pCAD_UNI_ID_UNIDADE IS NULL OR atd.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
                  AND (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)                    
                  AND (IML.ATD_IML_FL_STATUS = 'A')
AND ((pCOM_HOSP_DIA IS NULL) OR 
                      (pCOM_HOSP_DIA = '0' AND (pCAD_CSE_ID = '8') AND SETOR.CAD_CSE_ID = 8) OR                      
(pCOM_HOSP_DIA = '0' AND (PCAD_CSE_ID NOT IN ('8','9') OR PCAD_CSE_ID IS NULL) AND SETOR.CAD_CSE_ID NOT IN ('8','9')) OR
                      (pCOM_HOSP_DIA = '1' AND SETOR.CAD_CSE_ID = 8))
                      
                  AND CNV1.CAD_CNV_ID_CONVENIO = 282 AND CNV1.cad_cgc_id = 2
                ),
               0) QTD_INT_VINDOS_DIA_ANTER_PART,
               
               
           NVL(FNC_INT_QTD_MOV_ENVIADAS(pCAD_SET_ID,
                                        PATD_ATE_DT_ATENDIMENTO_INI,
                                        NULL,
                                        NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO ,'ACS',pCOM_HOSP_DIA, pCAD_CSE_ID ),
               0)  QTD_MOV_ENVIADAS_ACS,
           NVL(FNC_INT_QTD_MOV_ENVIADAS(pCAD_SET_ID,
                                        PATD_ATE_DT_ATENDIMENTO_INI,
                                        NULL,
                                        NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO ,'AMIL',pCOM_HOSP_DIA, pCAD_CSE_ID ),
               0) QTD_MOV_ENVIADAS_AMIL,
           NVL(FNC_INT_QTD_MOV_ENVIADAS(pCAD_SET_ID,
                                        PATD_ATE_DT_ATENDIMENTO_INI,
                                        NULL,
                                        NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'FUNCIONARIO',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) QTD_MOV_ENVIADAS_FUNCIONARIO,
           NVL(FNC_INT_QTD_MOV_ENVIADAS(pCAD_SET_ID,
                                        PATD_ATE_DT_ATENDIMENTO_INI,
                                        NULL,
                                        NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'MERCADO' ,pCOM_HOSP_DIA, pCAD_CSE_ID ),
               0) QTD_MOV_ENVIADAS_MERCADO,
           NVL(FNC_INT_QTD_MOV_ENVIADAS(pCAD_SET_ID,
                                        PATD_ATE_DT_ATENDIMENTO_INI,
                                        NULL,
                                        NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'PARTICULAR',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) QTD_MOV_ENVIADAS_PARTICULAR,
               
               
           NVL(FNC_INT_SAIDAS(pCAD_SET_ID,
                              PATD_ATE_DT_ATENDIMENTO_INI,
                              null,
                              NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'ACS',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0)  QTD_SAIDAS_ACS,
           NVL(FNC_INT_SAIDAS(pCAD_SET_ID,
                              PATD_ATE_DT_ATENDIMENTO_INI,
                              null,
                              NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'AMIL',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) QTD_SAIDAS_AMIL,
           NVL(FNC_INT_SAIDAS(pCAD_SET_ID,
                              PATD_ATE_DT_ATENDIMENTO_INI,
                              null,
                              NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'FUNCIONARIO',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) QTD_SAIDAS_FUNCIONARIO,
           NVL(FNC_INT_SAIDAS(pCAD_SET_ID,
                              PATD_ATE_DT_ATENDIMENTO_INI,
                              null,
                              NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'MERCADO',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) QTD_SAIDAS_MERCADO,
           NVL(FNC_INT_SAIDAS(pCAD_SET_ID,
                              PATD_ATE_DT_ATENDIMENTO_INI,
                              null,
                              NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'PARTICULAR',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) QTD_SAIDAS_PARTICULAR,
               
           NVL(FNC_INT_SAIDAS_OBITO(pCAD_SET_ID,
                                    PATD_ATE_DT_ATENDIMENTO_INI,
                                    null,
                                    NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'ACS',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0)  QTD_SAIDAS_OBITO_ACS,
           NVL(FNC_INT_SAIDAS_OBITO(pCAD_SET_ID,
                                    PATD_ATE_DT_ATENDIMENTO_INI,
                                    null,
                                    NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,
                               'AMIL',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) QTD_SAIDAS_OBITO_AMIL,
           NVL(FNC_INT_SAIDAS_OBITO(pCAD_SET_ID,
                                    PATD_ATE_DT_ATENDIMENTO_INI,
                                    null,
                                    NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,
                               'FUNCIONARIO',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) QTD_SAIDAS_OBITO_FUNCIONARIO,
           NVL(FNC_INT_SAIDAS_OBITO(pCAD_SET_ID,
                                    PATD_ATE_DT_ATENDIMENTO_INI,
                                    null,
                                    NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'MERCADO',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) QTD_SAIDAS_OBITO_MERCADO,
           NVL(FNC_INT_SAIDAS_OBITO(pCAD_SET_ID,
                                    PATD_ATE_DT_ATENDIMENTO_INI,
                                    null,
                                    NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,
                               'PARTICULAR',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) QTD_SAIDAS_OBITO_PARTICULAR,

           NVL(FNC_INT_SAIDAS(pCAD_SET_ID,
                              PATD_ATE_DT_ATENDIMENTO_INI,
                              null,
                              NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'ACS',pCOM_HOSP_DIA, pCAD_CSE_ID  ),0)  +
           NVL(FNC_INT_SAIDAS_OBITO(pCAD_SET_ID,
                                    PATD_ATE_DT_ATENDIMENTO_INI,
                                    null,
                                    NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'ACS',pCOM_HOSP_DIA, pCAD_CSE_ID  ), 0) +
           NVL(FNC_INT_QTD_MOV_ENVIADAS(pCAD_SET_ID,
                                        PATD_ATE_DT_ATENDIMENTO_INI,
                                        NULL,
                                        NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'ACS',pCOM_HOSP_DIA, pCAD_CSE_ID  ),0) QTD_SAIDAS_TOTAL_ACS,
               
               
           NVL(FNC_INT_SAIDAS(pCAD_SET_ID,
                              PATD_ATE_DT_ATENDIMENTO_INI,
                              null,
                              NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO ,'AMIL',pCOM_HOSP_DIA, pCAD_CSE_ID ),
               0) + NVL(FNC_INT_SAIDAS_OBITO(pCAD_SET_ID,
                                             PATD_ATE_DT_ATENDIMENTO_INI,
                                             null,
                                             NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'AMIL',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
                        0) + NVL(FNC_INT_QTD_MOV_ENVIADAS(pCAD_SET_ID,
                                                          PATD_ATE_DT_ATENDIMENTO_INI,
                                                          NULL,
                                                          NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'AMIL',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
                                 0) QTD_SAIDAS_TOTAL_AMIL,
                                 
           NVL(FNC_INT_SAIDAS(pCAD_SET_ID,
                              PATD_ATE_DT_ATENDIMENTO_INI,
                              null,
                              NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO, 'FUNCIONARIO',pCOM_HOSP_DIA, pCAD_CSE_ID ),
               0) + NVL(FNC_INT_SAIDAS_OBITO(pCAD_SET_ID,
                                             PATD_ATE_DT_ATENDIMENTO_INI,
                                             null,
                                             NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'FUNCIONARIO',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
                        0) + NVL(FNC_INT_QTD_MOV_ENVIADAS(pCAD_SET_ID,
                                                          PATD_ATE_DT_ATENDIMENTO_INI,
                                                          NULL,
                                                          NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'FUNCIONARIO',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
                                 0) QTD_SAIDAS_TOTAL_FUNCIONARIO,
                                 
           NVL(FNC_INT_SAIDAS(pCAD_SET_ID,
                              PATD_ATE_DT_ATENDIMENTO_INI,
                              null,
                              NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO, 'MERCADO',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) + NVL(FNC_INT_SAIDAS_OBITO(pCAD_SET_ID,
                                             PATD_ATE_DT_ATENDIMENTO_INI,
                                             null,
                                             NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO, 'MERCADO',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
                        0) + NVL(FNC_INT_QTD_MOV_ENVIADAS(pCAD_SET_ID,
                                                          PATD_ATE_DT_ATENDIMENTO_INI,
                                                          NULL,
                                                          NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO, 'MERCADO',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
                                 0) QTD_SAIDAS_TOTAL_MERCADO,
                                 
           NVL(FNC_INT_SAIDAS(pCAD_SET_ID,
                              PATD_ATE_DT_ATENDIMENTO_INI,
                              null,
                              NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'PARTICULAR',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) + NVL(FNC_INT_SAIDAS_OBITO(pCAD_SET_ID,
                                             PATD_ATE_DT_ATENDIMENTO_INI,
                                             null,
                                             NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'PARTICULAR',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
                        0) + NVL(FNC_INT_QTD_MOV_ENVIADAS(pCAD_SET_ID,
                                                          PATD_ATE_DT_ATENDIMENTO_INI,
                                                          NULL,
                                                          NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'PARTICULAR',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
                                 0) QTD_SAIDAS_TOTAL_PARTICULAR,
                                 
                                 
           NVL(FNC_INT_QTD_PAC_ZERO_HORA(pCAD_SET_ID,
                                                  PATD_ATE_DT_ATENDIMENTO_INI,
                                                  NULL,
                                                  NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'ACS',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
                        0) QTD_PAC_ZERO_HORA_ACS,
           NVL(FNC_INT_QTD_PAC_ZERO_HORA(pCAD_SET_ID,
                                         PATD_ATE_DT_ATENDIMENTO_INI,
                                         NULL,
                                         NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'AMIL',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) QTD_PAC_ZERO_HORA_AMIL,
           NVL(FNC_INT_QTD_PAC_ZERO_HORA(pCAD_SET_ID,
                                         PATD_ATE_DT_ATENDIMENTO_INI,
                                         NULL,
                                         NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'FUNCIONARIO',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) QTD_PAC_ZERO_HORA_FUNCIONARIO,
           NVL(FNC_INT_QTD_PAC_ZERO_HORA(pCAD_SET_ID,
                                         PATD_ATE_DT_ATENDIMENTO_INI,
                                         NULL,
                                         NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'MERCADO',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) QTD_PAC_ZERO_HORA_MERCADO,
           NVL(FNC_INT_QTD_PAC_ZERO_HORA(pCAD_SET_ID,
                                         PATD_ATE_DT_ATENDIMENTO_INI,
                                         NULL,
                                         NULL,
                               pCAD_UNI_ID_UNIDADE,
                               pCAD_CNV_ID_CONVENIO,'PARTICULAR',pCOM_HOSP_DIA, pCAD_CSE_ID  ),
               0) QTD_PAC_ZERO_HORA_PARTICULAR
      FROM DUAL;
  io_cursor := v_cursor;
end PRC_INT_REL_CENS_ANAL_RESUMO;
