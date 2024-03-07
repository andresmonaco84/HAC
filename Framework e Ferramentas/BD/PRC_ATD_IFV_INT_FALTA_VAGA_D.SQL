  --PRC_ATD_IFV_INT_FALTA_VAGA_D
  CREATE OR REPLACE PROCEDURE PRC_ATD_IFV_INT_FALTA_VAGA_D
  (
    PATD_IFV_ID IN TB_ATD_IFV_INT_FALTA_VAGA.ATD_IFV_ID%TYPE
  ) IS
  /********************************************************************
  *    Procedure: PRC_ATD_IFV_INT_FALTA_VAGA_D
  * 
  *    Data Criacao:  24/01/2011             Por: Fabiola Lopes
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Exclui registro da TB_ATD_IFV_INT_FALTA_VAGA
  *
  *******************************************************************/
BEGIN
  DELETE TB_ATD_IFV_INT_FALTA_VAGA WHERE ATD_IFV_ID = PATD_IFV_ID;
END PRC_ATD_IFV_INT_FALTA_VAGA_D;
