CREATE OR REPLACE PROCEDURE PRC_TIS_TAC_ACOMODACAO_REP_L
  (
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TAC_ACOMODACAO_REP_L
  *
  *    Data Criacao:    data da criacao    Por: Nome do Analista
  *    Data Alteracao:  data da alteracao  Por: Nome do Analista
  *
  *    Funcao: Descricaoo da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT TIS_TAC_CD_TIPO_ACOMODACAO, TIS_TAC_DS_TIPO_ACOMODACAO
      FROM TB_TIS_TAC_TIPO_ACOMODACAO TAC
     WHERE TAC.TIS_TAC_FL_UTILIZA_REPASSE = 'S';
    io_cursor := v_cursor;
  end PRC_TIS_TAC_ACOMODACAO_REP_L;
