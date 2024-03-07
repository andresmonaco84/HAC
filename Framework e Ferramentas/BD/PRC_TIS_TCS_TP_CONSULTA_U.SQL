create or replace procedure PRC_TIS_TCS_TP_CONSULTA_U
  (
     pTIS_TCS_CD_TPCONSULTA IN TB_TIS_TCS_TP_CONSULTA.TIS_TCS_CD_TPCONSULTA%type,
     pTIS_TCS_DS_TPCONSULTA IN TB_TIS_TCS_TP_CONSULTA.TIS_TCS_DS_TPCONSULTA%type,
     pSEG_USU_ID_USUARIO    IN TB_TIS_TCS_TP_CONSULTA.SEG_USU_ID_USUARIO_CRIACAO%type DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TCS_TP_CONSULTA_U
  *
  *    Data Criacao: 	17/04/2007   Por: Andrea Cazuca
  *    Data Alteracao:  25/05/2007   Por: Silmara
  *    Altera??ao:Foi alterado os par??metros para gravar em mai??sculo
  *    Funcao: Altera Tipo de Consulta
  *
  *******************************************************************/
  begin
    UPDATE TB_TIS_TCS_TP_CONSULTA
    SET
        TIS_TCS_DS_TPCONSULTA = UPPER(pTIS_TCS_DS_TPCONSULTA),
        TIS_TCS_DT_ULT_ATUALIZACAO = SYSDATE,
        SEG_USU_ID_USU_ULT_ATUALIZ = pSEG_USU_ID_USUARIO
    WHERE
        TIS_TCS_CD_TPCONSULTA = pTIS_TCS_CD_TPCONSULTA;
  end PRC_TIS_TCS_TP_CONSULTA_U;
 