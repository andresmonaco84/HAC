CREATE OR REPLACE PROCEDURE "PRC_INT_MOTIVO_SAIDA_INT_S"
  (
     pTIS_MSI_CD_MOTIVOSAIDAINT IN TB_TIS_MSI_MOTIVO_SAIDA_INT.TIS_MSI_CD_MOTIVOSAIDAINT%type DEFAULT NULL,
     pTIS_MSI_CD_TIPOALTA IN TB_TIS_MSI_MOTIVO_SAIDA_INT.TIS_MSI_CD_TIPOALTA%type DEFAULT NULL,
     pTIS_MSI_DS_MOTIVOSAIDAINT IN TB_TIS_MSI_MOTIVO_SAIDA_INT.TIS_MSI_DS_MOTIVOSAIDAINT%type DEFAULT NULL,
     pTIS_MSI_FL_STATUS  IN TB_TIS_MSI_MOTIVO_SAIDA_INT.TIS_MSI_FL_STATUS%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_MOTIVO_SAIDA_INT_S
  *
  *    Data Criacao:  data da  criação   Por: Nome do Analista
  *    Data Alteracao: data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       TIS_MSI_CD_MOTIVOSAIDAINT,
       TIS_MSI_CD_TIPOALTA,
       TIS_MSI_DS_MOTIVOSAIDAINT,
       TIS_MSI_FL_STATUS
    FROM TB_TIS_MSI_MOTIVO_SAIDA_INT
    WHERE
        (pTIS_MSI_CD_MOTIVOSAIDAINT is null OR TIS_MSI_CD_MOTIVOSAIDAINT = pTIS_MSI_CD_MOTIVOSAIDAINT) AND
        (pTIS_MSI_CD_TIPOALTA is null OR TIS_MSI_CD_TIPOALTA = pTIS_MSI_CD_TIPOALTA) AND
        (pTIS_MSI_DS_MOTIVOSAIDAINT is null OR TIS_MSI_DS_MOTIVOSAIDAINT = pTIS_MSI_DS_MOTIVOSAIDAINT) AND
        (pTIS_MSI_FL_STATUS IS NULL OR TIS_MSI_FL_STATUS = pTIS_MSI_FL_STATUS);
    io_cursor := v_cursor;
  end PRC_INT_MOTIVO_SAIDA_INT_S;
 