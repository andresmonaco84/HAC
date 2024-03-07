CREATE OR REPLACE PROCEDURE "PRC_ATD_ULTIMA_MOV_GERAL_S" (pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE,
                                                       IO_CURSOR   OUT PKG_CURSOR.T_CURSOR) IS
  /********************************************************************
  *    Procedure: PRC_ATD_ULTIMA_MOV_GERAL_S
  *
  *    Data Criacao:   09/10/2010          Por:  Fabiola
  *    Funcao: Recupera a ultima movimentacao entre leitos, setores, clinicas e materiais e medicamentos
  *
   *******************************************************************/
  V_CURSOR PKG_CURSOR.T_CURSOR;
BEGIN
  OPEN V_CURSOR FOR
  /*
      SELECT MAX(MOV.DT) DATA_ULT_MOV, MAX(MOV.HR) HORA_ULT_MOV
        FROM (SELECT DISTINCT IML.ATD_IML_DT_ENTRADA DT,
                              IML.ATD_IML_HR_ENTRADA HR
                FROM TB_ATD_IML_INT_MOV_LEITO IML
               WHERE IML.ATD_IML_FL_STATUS = 'A'
                 AND IML.ATD_ATE_ID = pATD_ATE_ID
              UNION ALL
              SELECT DISTINCT IMC.ATD_IMC_DT_ENTRADA DT,
                              IMC.ATD_IMC_HR_ENTRADA HR
                FROM TB_ATD_IMC_INT_MOV_CLINICA IMC
               WHERE IMC.ATD_ATE_ID = pATD_ATE_ID
              UNION ALL
              SELECT DISTINCT IMS.ATD_IMS_DT_ENTRADA DT,
                              IMS.ATD_IMS_HR_ENTRADA HR
                FROM TB_ATD_IMS_INT_MOV_SETOR IMS
               WHERE IMS.ATD_IMS_FL_STATUS = 'A'
                 AND IMS.ATD_ATE_ID = pATD_ATE_ID
              UNION ALL
              SELECT DISTINCT TO_DATE(MTMD.MTMD_MOV_DATA,'dd/MM/yyyy') DT,
                              TO_NUMBER(TO_CHAR(MTMD.MTMD_MOV_DATA,'hh24mi')) HR
                FROM TB_MTMD_MOV_MOVIMENTACAO MTMD
               WHERE MTMD.ATD_ATE_ID = pATD_ATE_ID
                 AND MTMD.MTMD_MOV_FL_ESTORNO = 0) MOV;*/
    SELECT TO_DATE(TO_CHAR(MAX(MOV.DATAHORA), 'ddMMyyyy'), 'ddMMyyyy') DATA_ULT_MOV,
           TO_NUMBER(TO_CHAR(MAX(MOV.DATAHORA), 'hh24mi')) HORA_ULT_MOV
      FROM (SELECT DISTINCT to_date(max(to_char(IML.ATD_IML_DT_ENTRADA, 'ddMMyyyy') ||
            lpad(to_char(IML.ATD_IML_HR_ENTRADA), 4, '0')), 'ddMMyyyyhh24mi') DATAHORA
              FROM TB_ATD_IML_INT_MOV_LEITO IML
             WHERE IML.ATD_IML_FL_STATUS = 'A'
               AND IML.ATD_ATE_ID = pATD_ATE_ID
            UNION ALL
            SELECT DISTINCT to_date(max(to_char(IMC.ATD_IMC_DT_ENTRADA, 'ddMMyyyy') ||
                    lpad(to_char(IMC.ATD_IMC_HR_ENTRADA), 4, '0')), 'ddMMyyyyhh24mi') DATAHORA
              FROM TB_ATD_IMC_INT_MOV_CLINICA IMC
             WHERE IMC.ATD_ATE_ID = pATD_ATE_ID
            UNION ALL
            SELECT DISTINCT to_date(max(to_char(IMS.ATD_IMS_DT_ENTRADA, 'ddMMyyyy') ||
                            lpad(to_char(IMS.ATD_IMS_HR_ENTRADA), 4, '0')), 'ddMMyyyyhh24mi') DATAHORA
              FROM TB_ATD_IMS_INT_MOV_SETOR IMS
             WHERE IMS.ATD_IMS_FL_STATUS = 'A'
               AND IMS.ATD_ATE_ID = pATD_ATE_ID
          /*  UNION ALL
            SELECT DISTINCT to_date(to_char(max(MTMD.MTMD_MOV_DATA), 'ddMMyyyyhh24mi'), 'ddMMyyyyhh24mi') DATAHORA
              FROM TB_MTMD_MOV_MOVIMENTACAO MTMD
             WHERE MTMD.ATD_ATE_ID = pATD_ATE_ID
               AND MTMD.MTMD_MOV_FL_ESTORNO = 0
               AND MTMD.CAD_MTMD_SUBTP_ID IN (11, 14, 18, 24, 25, 26, 35, 36)*/ 
                ) MOV;
  IO_CURSOR := V_CURSOR;
END PRC_ATD_ULTIMA_MOV_GERAL_S;
 