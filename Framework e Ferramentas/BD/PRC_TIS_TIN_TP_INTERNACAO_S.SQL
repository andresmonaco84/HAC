create or replace procedure PRC_TIS_TIN_TP_INTERNACAO_S
  (
     pTIS_TIN_CD_INTERNACAO IN TB_TIS_TIN_TP_INTERNACAO.TIS_TIN_CD_INTERNACAO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TIN_TP_INTERNACAO_S
  *
  *    Data Criacao:  11/04/2007   Por: Andrea Cazuca
  *    Data Alteracao: data da altera???#o  Por: Nome do Analista
  *
  *    Funcao: Seleciona o Tipo de Internac?o
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       TIS_TIN_CD_INTERNACAO,
       TIS_TIN_DS_INTERNACAO,
       TIS_TIN_FL_STATUS,
       TIS_TIN_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       TIS_TIN_DT_ULT_ATUALIZACAO,
       SEG_USU_ID_USU_ULT_ATUALIZ
       
    FROM TB_TIS_TIN_TP_INTERNACAO
    WHERE
        (pTIS_TIN_CD_INTERNACAO is null OR TIS_TIN_CD_INTERNACAO = pTIS_TIN_CD_INTERNACAO)
    ORDER BY TIS_TIN_DS_INTERNACAO;
    io_cursor := v_cursor;
  end PRC_TIS_TIN_TP_INTERNACAO_S;
 