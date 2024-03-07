CREATE OR REPLACE PROCEDURE "PRC_MTMD_MOV_VERIFICA_CONSUMO"
  (
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     pCAD_SET_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type DEFAULT NULL,
     pATD_ATE_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.ATD_ATE_ID%type DEFAULT NULL,
     pRetorno                      OUT integer
  )
  is
  /********************************************************************
  *    Procedure: PRC_MTMD_MOV_VERIFICA_CONSUMO
  *
  *    Data Criacao:  30/06/2010   Por: RICARDO COSTA
  *    Data Alteracao:              Por:
  *         Alterac?o:
  *
  *    Funcao: VERIFICA SE HOUVE ALGUMA  MOVIMENTAC?O PARA O PACIENTE
  *
  *******************************************************************/
  SIM            CONSTANT NUMBER := 1;
  NAO            CONSTANT NUMBER := 0;
  BEGIN
   BEGIN
    SELECT 1
    INTO   pRetorno
    FROM TB_MTMD_MOV_MOVIMENTACAO MOVIMENTACAO
    WHERE (pCAD_LAT_ID_LOCAL_ATENDIMENTO is null OR MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
    AND   (pCAD_UNI_ID_UNIDADE           is null OR MOVIMENTACAO.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
    AND   (pCAD_SET_ID                   is null OR MOVIMENTACAO.CAD_SET_ID = pCAD_SET_ID)
    AND   (pATD_ATE_ID                   is null OR MOVIMENTACAO.ATD_ATE_ID = pATD_ATE_ID)
    AND   MOVIMENTACAO.MTMD_MOV_FL_ESTORNO = NAO
    AND   MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN (11, 14, 18, 24, 25, 26, 35, 36, 60);
   EXCEPTION
      WHEN NO_DATA_FOUND THEN
         pRetorno := 0;
      WHEN TOO_MANY_ROWS THEN
         pRetorno := 1;
   END;
  END PRC_MTMD_MOV_VERIFICA_CONSUMO;