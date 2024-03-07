CREATE OR REPLACE PROCEDURE "PRC_INT_MOTIVO_SAIDA_INT_U"
  (
     pTIS_MSI_CD_MOTIVOSAIDAINT IN TB_TIS_MSI_MOTIVO_SAIDA_INT.TIS_MSI_CD_MOTIVOSAIDAINT%type,
     pTIS_MSI_CD_TIPOALTA IN TB_TIS_MSI_MOTIVO_SAIDA_INT.TIS_MSI_CD_TIPOALTA%type,
     pTIS_MSI_DS_MOTIVOSAIDAINT IN TB_TIS_MSI_MOTIVO_SAIDA_INT.TIS_MSI_DS_MOTIVOSAIDAINT%type,
          pTIS_MSI_FL_STATUS IN TB_TIS_MSI_MOTIVO_SAIDA_INT.TIS_MSI_FL_STATUS%type DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_MOTIVO_SAIDA_INT_U
  *
  *    Data Criacao:  data da  criação   Por: Nome do Analista
  *    Data Alteracao: data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  begin
    UPDATE TB_TIS_MSI_MOTIVO_SAIDA_INT
    SET
        TIS_MSI_CD_TIPOALTA = pTIS_MSI_CD_TIPOALTA,
        TIS_MSI_DS_MOTIVOSAIDAINT = pTIS_MSI_DS_MOTIVOSAIDAINT,
        TIS_MSI_FL_STATUS = pTIS_MSI_FL_STATUS
    WHERE
        TIS_MSI_CD_MOTIVOSAIDAINT = pTIS_MSI_CD_MOTIVOSAIDAINT;
  end PRC_INT_MOTIVO_SAIDA_INT_U;
 