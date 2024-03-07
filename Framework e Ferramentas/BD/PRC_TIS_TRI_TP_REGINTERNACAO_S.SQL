create or replace procedure PRC_TIS_TRI_TP_REGINTERNACAO_S
  (
     pTIS_TRI_CD_TP_REGINTERNACAO IN TB_TIS_TRI_TP_REGINTERNACAO.TIS_TRI_CD_TP_REGINTERNACAO%type DEFAULT NULL,
     
    
     
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TRI_TP_REGINTERNACAO_S
  *
  *    Data Criacao:    12/04/2007    Por: Fabiola R. Lopes
  *    Data Alteracao:           Por:
  *
  *    Funcao: Listar os Tipos de Regime de Internacao
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       TIS_TRI_CD_TP_REGINTERNACAO,
       TIS_TRI_DS_TP_REGINTERNACAO,
       TIS_TRI_FL_STATUS,
       
       TIS_TRI_DT_CRIACAO,
      SEG_USU_ID_USUARIO_CRIACAO,
      TIS_TRI_DT_ULT_ATUALIZACAO,
      SEG_USU_ID_USU_ULT_ATUALIZ
      
    FROM TB_TIS_TRI_TP_REGINTERNACAO
    WHERE
        (pTIS_TRI_CD_TP_REGINTERNACAO is null OR TIS_TRI_CD_TP_REGINTERNACAO = pTIS_TRI_CD_TP_REGINTERNACAO)
 order by TIS_TRI_DS_TP_REGINTERNACAO;
    io_cursor := v_cursor;
  end PRC_TIS_TRI_TP_REGINTERNACAO_S;
 