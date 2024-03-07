CREATE OR REPLACE PROCEDURE PRC_INT_VERIFICA_1MOV
(pATD_ATE_ID                    IN TB_ATD_IMS_INT_MOV_SETOR.ATD_ATE_ID%TYPE DEFAULT NULL,
 IO_CURSOR                      OUT PKG_CURSOR.T_CURSOR) IS
  /********************************************************************
  *    Procedure: PRC_INT_VERIFICA_1MOV
  *
  *    Data Criacao:    20/10/2010         Por: Fabiola Lopes
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Verifica se a primeira movimentacao no setor
  *
  *******************************************************************/
  V_CURSOR PKG_CURSOR.T_CURSOR;
BEGIN
  OPEN V_CURSOR FOR
    SELECT IMS.ATD_ATE_ID, COUNT(*)
      FROM TB_ATD_IMS_INT_MOV_SETOR IMS
     WHERE IMS.ATD_ATE_ID = pATD_ATE_ID
       AND NOT EXISTS (SELECT *
              FROM TB_ATD_IML_INT_MOV_LEITO IML
             WHERE IML.ATD_ATE_ID = IMS.ATD_ATE_ID)
       AND NOT EXISTS (SELECT *
              FROM TB_ATD_IMC_INT_MOV_CLINICA IMC
             WHERE IMS.ATD_ATE_ID = IMC.ATD_ATE_ID)
     GROUP BY IMS.ATD_ATE_ID
    HAVING COUNT(*) = 1;
  IO_CURSOR := V_CURSOR;
END PRC_INT_VERIFICA_1MOV;