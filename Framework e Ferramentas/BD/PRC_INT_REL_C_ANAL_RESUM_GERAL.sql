CREATE OR REPLACE PROCEDURE "PRC_INT_REL_C_ANAL_RESUM_GERAL"(pCAD_UNI_ID_UNIDADE         IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE,
                                                             pCAD_SET_ID                 IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
                                                             PATD_ATE_DT_ATENDIMENTO_INI IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE,
                                                             io_cursor                   OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_INT_REL_C_ANAL_RESUM_GERAL
  *
  *    Data Criacao:   17/09/2010   Por: Pedro
  *    Data Alteracao:  Por: ?
  *    Alterac?o:
  *
  *    Funcao: Censo dos Setores (Analitico)
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
    SELECT NVL(FNC_INT_QTD_DIA(null, PATD_ATE_DT_ATENDIMENTO_INI, NULL, NULL, pCAD_UNI_ID_UNIDADE), 0) QTD_INT_NO_DIA,
           NVL(FNC_INT_QTD_MOV_RECEBIDAS(null, PATD_ATE_DT_ATENDIMENTO_INI, NULL, NULL, pCAD_UNI_ID_UNIDADE), 0) QTD_INT_TRANSFERIDOS,
           
           (SELECT SUM(Count(DISTINCT IML.ATD_ATE_ID))
              FROM TB_ATD_IML_INT_MOV_LEITO IML
              JOIN TB_CAD_QLE_QUARTO_LEITO QLE55 ON QLE55.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
              JOIN TB_ATD_ATE_ATENDIMENTO ATD ON ATD.ATD_ATE_ID = IML.ATD_ATE_ID
              JOIN TB_CAD_PAC_PACIENTE PAC ON PAC.CAD_PAC_ID_PACIENTE = FNC_BUSCAR_PACIENTE_ATUAL(ATD.ATD_ATE_ID)
              JOIN TB_ATD_AIC_ATE_INT_COMPL AIC ON AIC.ATD_ATE_ID = ATD.ATD_ATE_ID
              JOIN TB_CAD_PLA_PLANO PLA1 ON PLA1.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
              JOIN TB_CAD_SET_SETOR SETOR ON QLE55.CAD_SET_ID = SETOR.CAD_SET_ID
              LEFT JOIN (SELECT IML3.ATD_ATE_ID,
                               IML3.ATD_IML_DT_SAIDA,
                               IML3.ATD_IML_HR_SAIDA,
                               IML3.ATD_IML_DT_ENTRADA,
                               IML3.ATD_IML_HR_ENTRADA,
                               QLE3.CAD_SET_ID
                          FROM TB_ATD_IML_INT_MOV_LEITO IML3
                          JOIN TB_CAD_QLE_QUARTO_LEITO QLE3 ON QLE3.CAD_QLE_ID = IML3.CAD_CAD_QLE_ID
                          JOIN TB_ATD_ATE_ATENDIMENTO ATD3 ON ATD3.ATD_ATE_ID = IML3.ATD_ATE_ID
                         WHERE (IML3.ATD_IML_FL_STATUS = 'A')
                           AND (IML3.ATD_IML_DT_ENTRADA = PATD_ATE_DT_ATENDIMENTO_INI)
                           AND (ATD3.ATD_ATE_FL_STATUS = 'A')
                           AND (pCAD_UNI_ID_UNIDADE IS NULL OR ATD3.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
                           AND IML3.ATD_IML_ID = FNC_INT_PRIM_MOV_QUARTO_LEITO(ATD3.ATD_ATE_ID)
                        UNION
                        SELECT IML4.ATD_ATE_ID,
                               IML4.ATD_IML_DT_SAIDA,
                               IML4.ATD_IML_HR_SAIDA,
                               IML4.ATD_IML_DT_ENTRADA,
                               IML4.ATD_IML_HR_ENTRADA,
                               QLE4.CAD_SET_ID
                          FROM TB_ATD_IML_INT_MOV_LEITO IML4
                          JOIN TB_CAD_QLE_QUARTO_LEITO QLE4 ON QLE4.CAD_QLE_ID = IML4.CAD_CAD_QLE_ID
                          JOIN TB_ATD_ATE_ATENDIMENTO ATD4 ON ATD4.ATD_ATE_ID = IML4.ATD_ATE_ID
                         WHERE (IML4.ATD_IML_FL_STATUS = 'A')
                           AND (IML4.ATD_IML_DT_ENTRADA = PATD_ATE_DT_ATENDIMENTO_INI + 1)
                           AND (ATD4.ATD_ATE_FL_STATUS = 'A')
                           AND (pCAD_UNI_ID_UNIDADE IS NULL OR ATD4.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
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
                         ORDER BY 1, 2, 3, 4, 5, 6
                        ) DESTINO
                ON DESTINO.ATD_ATE_ID = IML.ATD_ATE_ID
               AND (DESTINO.ATD_IML_DT_SAIDA IS NULL OR DESTINO.ATD_IML_DT_SAIDA >= IML.ATD_IML_DT_ENTRADA)
               AND DESTINO.ATD_IML_HR_ENTRADA = IML.ATD_IML_HR_SAIDA
             WHERE IML.ATD_IML_DT_ENTRADA < PATD_ATE_DT_ATENDIMENTO_INI
               and (ATD.ATD_ATE_DT_ATENDIMENTO < PATD_ATE_DT_ATENDIMENTO_INI)
               AND (IML.ATD_IML_DT_SAIDA >= PATD_ATE_DT_ATENDIMENTO_INI OR IML.ATD_IML_DT_SAIDA IS NULL)
                  -- SE TIVER DESTINO NO MESMO DIA E PORQUE N?O ESTA MAIS NO SETOR
               AND (DESTINO.CAD_SET_ID IS NULL OR DESTINO.CAD_SET_ID != QLE55.CAD_SET_ID)
               AND (IML.ATD_IML_FL_STATUS = 'A')
               and (atd.atd_ate_fl_status = 'A')
               AND (pCAD_UNI_ID_UNIDADE IS NULL OR ATD.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
               and (pCAD_SET_ID is null or qle55.cad_set_id = pCAD_SET_ID)
             GROUP BY IML.ATD_ATE_ID
           ) QTD_INT_VINDOS_DIA_ANTERIOR,
           
           NVL(FNC_INT_SAIDAS_OBITO(null, PATD_ATE_DT_ATENDIMENTO_INI,NULL,NULL,pCAD_UNI_ID_UNIDADE),0) QTD_SAIDAS_OBITO,
           NVL(FNC_INT_SAIDAS(null,PATD_ATE_DT_ATENDIMENTO_INI,NULL,NULL,pCAD_UNI_ID_UNIDADE),0) QTD_SAIDAS,
           NVL(FNC_INT_QTD_MOV_ENVIADAS(null,PATD_ATE_DT_ATENDIMENTO_INI,NULL,NULL,pCAD_UNI_ID_UNIDADE), 0) QTD_MOV_ENVIADAS,
           NVL(FNC_INT_QTD_PAC_ZERO_HORA(null,PATD_ATE_DT_ATENDIMENTO_INI, NULL,NULL,pCAD_UNI_ID_UNIDADE), 0) QTD_PAC_ZERO_HORA
      FROM DUAL;
  io_cursor := v_cursor;
end PRC_INT_REL_C_ANAL_RESUM_GERAL;
 