create or replace procedure PRC_TIS_TAT_TP_ATENDIMENTO_S
  (
     pTIS_TAT_CD_TPATENDIMENTO IN TB_TIS_TAT_TP_ATENDIMENTO.TIS_TAT_CD_TPATENDIMENTO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TAT_TP_ATENDIMENTO_S
  *
  *    Data Criacao:   11/04/2007       Por: Fabiola R. Lopes
  *    Data Alteracao:            Por: Nome do Analista
  *
  *    Funcao: Listar Tipos de Atendimentos
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       TIS_TAT_CD_TPATENDIMENTO,
       TIS_TAT_DS_TPATENDIMENTO,
      TIS_TAT_FL_STATUS,
      TIS_TAT_DT_CRIACAO,
      SEG_USU_ID_USUARIO_CRIACAO,
      TIS_TAT_DT_ULT_ATUALIZACAO,
      SEG_USU_ID_USU_ULT_ATUALIZ

    FROM TB_TIS_TAT_TP_ATENDIMENTO
    WHERE
        (pTIS_TAT_CD_TPATENDIMENTO is null OR TIS_TAT_CD_TPATENDIMENTO = pTIS_TAT_CD_TPATENDIMENTO)
    ORDER BY TIS_TAT_DS_TPATENDIMENTO;
    io_cursor := v_cursor;
  end PRC_TIS_TAT_TP_ATENDIMENTO_S;
 