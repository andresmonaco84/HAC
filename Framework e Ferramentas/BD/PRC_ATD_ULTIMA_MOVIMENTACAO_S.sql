CREATE OR REPLACE PROCEDURE PRC_ATD_ULTIMA_MOVIMENTACAO_S
( pATD_ATE_ID  IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE,
  IO_CURSOR    OUT PKG_CURSOR.T_CURSOR) IS

  /********************************************************************
  *    Procedure: PRC_ATD_ULTIMA_MOVIMENTACAO_S
  *
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao: 15/12/2010        Por: Fabiola Lopes
  *    Data Alteracao: 17/12/2010        Por: Fabiola Lopes
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *    Alteracao: Retirei a data/hora de saida nulas para recuperar a ultima movimentacao independete da saida
  *    Alteracao: Acerto para obter ultima data/hora de entrada/saida
  *
  *******************************************************************/

  V_CURSOR PKG_CURSOR.T_CURSOR;
BEGIN
  OPEN V_CURSOR FOR

   SELECT TO_DATE(TO_CHAR(MAX(MOV.DATAHORA), 'ddMMyyyy'), 'ddMMyyyy') DATA_ULT_MOV,
       TO_NUMBER(TO_CHAR(MAX(MOV.DATAHORA), 'hh24mi')) HORA_ULT_MOV
       
FROM ( 

  SELECT CASE WHEN IML.ATD_IML_DT_SAIDA IS NULL THEN
           TO_DATE(MAX(TO_CHAR(IML.ATD_IML_DT_ENTRADA, 'ddMMyyyy') ||
           LPAD(TO_CHAR(IML.ATD_IML_HR_ENTRADA), 4, '0')), 'ddMMyyyyhh24mi') 
         ELSE
           TO_DATE(MAX(TO_CHAR(IML.ATD_IML_DT_SAIDA, 'ddMMyyyy') ||
           LPAD(TO_CHAR(IML.ATD_IML_HR_SAIDA), 4, '0')), 'ddMMyyyyhh24mi')
         END
          DATAHORA
    FROM TB_ATD_IML_INT_MOV_LEITO IML
   WHERE IML.ATD_IML_FL_STATUS = 'A'
     AND IML.ATD_ATE_ID = pATD_ATE_ID
GROUP BY IML.ATD_IML_DT_SAIDA

   UNION ALL

  SELECT CASE WHEN IMC.ATD_IMC_DT_SAIDA IS NULL THEN
           TO_DATE(MAX(TO_CHAR(IMC.ATD_IMC_DT_ENTRADA, 'ddMMyyyy') || 
           LPAD(TO_CHAR(IMC.ATD_IMC_HR_ENTRADA), 4, '0')), 'ddMMyyyyhh24mi') 
         ELSE
           TO_DATE(MAX(TO_CHAR(IMC.ATD_IMC_DT_SAIDA, 'ddMMyyyy') || 
           LPAD(TO_CHAR(IMC.ATD_IMC_HR_SAIDA), 4, '0')), 'ddMMyyyyhh24mi')
         END
         DATAHORA      
    FROM TB_ATD_IMC_INT_MOV_CLINICA IMC
   WHERE IMC.ATD_ATE_ID = pATD_ATE_ID
GROUP BY IMC.ATD_IMC_DT_SAIDA 

   UNION ALL

  SELECT CASE WHEN IMS.ATD_IMS_DT_SAIDA IS NULL THEN 
           TO_DATE(MAX(TO_CHAR(IMS.ATD_IMS_DT_ENTRADA, 'ddMMyyyy') || 
           LPAD(TO_CHAR(IMS.ATD_IMS_HR_ENTRADA), 4, '0')), 'ddMMyyyyhh24mi') 
         ELSE 
           TO_DATE(MAX(TO_CHAR(IMS.ATD_IMS_DT_SAIDA, 'ddMMyyyy') || 
           LPAD(TO_CHAR(IMS.ATD_IMS_HR_SAIDA), 4, '0')), 'ddMMyyyyhh24mi')
           END
          DATAHORA
    FROM TB_ATD_IMS_INT_MOV_SETOR IMS
   WHERE IMS.ATD_IMS_FL_STATUS = 'A'
     AND IMS.ATD_ATE_ID = pATD_ATE_ID
GROUP BY IMS.ATD_IMS_DT_SAIDA    
     ) MOV;

  IO_CURSOR := V_CURSOR;

END PRC_ATD_ULTIMA_MOVIMENTACAO_S;
