create or replace procedure PRC_INT_ATD_INA_INT_ALTA_SID
  (
     pATD_ATE_ID IN TB_ATD_INA_INT_ALTA.ATD_ATE_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATD_INA_INT_ALTA_SID
  *
  *    Data Criacao:   data da  cria??o   Por: Nome do Analista
  *    Data Alteracao:  data da altera??o  Por: Nome do Analista
  *
  *    Funcao: Descri??o da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       ATD_ATE_ID,
       TRUNC(ATD_INA_DT_ALTA_CLINICA) ATD_INA_DT_ALTA_CLINICA,
       TRUNC(ATD_INA_DT_ALTA_ADM) ATD_INA_DT_ALTA_ADM,
       ATD_INA_HR_ALTA_ADM,
       TIS_MSI_CD_MOTIVOSAIDAINT,
       ATD_INA_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       ATD_INA_HR_ALTA_CLINICA,
       CAD_PRO_ID_PROFISSIONAL,
       TIS_CBO_CD_CBOS,
       ATD_INA_ID,
       SEG_USU_ID_USUARIO_ALTA,
       ATD_INA_DS_OBSERVACAO,

       ATD_INA_CD_MOTIVO_PERM_LEITO,
       ATD_INA_DS_RECEITUARIO
       
    FROM TB_ATD_INA_INT_ALTA
    WHERE
        ATD_ATE_ID = pATD_ATE_ID;
    io_cursor := v_cursor;
  end PRC_INT_ATD_INA_INT_ALTA_SID;
