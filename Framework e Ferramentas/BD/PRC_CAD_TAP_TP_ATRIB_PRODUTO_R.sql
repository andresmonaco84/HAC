 create or replace procedure PRC_CAD_TAP_TP_ATRIB_PRODUTO_R
  (
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_TAP_TP_ATRIB_PRODUTO_R
  *
  *    Data Criacao:   03/12/2010   Por: André Souza Monaco
  *
  *    Funcao: Lista itens de cobrança com join
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       TAP.CAD_TAP_TP_ATRIBUTO,
       TAP.CAD_TAP_DS_ATRIBUTO,
       TAP.CAD_TAP_FL_STATUS,
       DECODE(TAP.CAD_TAP_FL_STATUS, 'A', 'ATIVO', 'CANCELADO') SITUACAO,
       TAP.CAD_TAP_DT_ULTIMA_ATUALIZACAO,
       TAP.SEG_USU_ID_USUARIO,
       TAP.TIS_CDE_CD_CODIGO_DESPESA,
       CDE.TIS_CDE_DS_DESCRICAO_DESPESA
    FROM TB_CAD_TAP_TP_ATRIB_PRODUTO TAP,
         TB_TIS_CDE_CODIGO_DESPESA   CDE
    WHERE CDE.TIS_CDE_CD_CODIGO_DESPESA (+)= TAP.TIS_CDE_CD_CODIGO_DESPESA
    ORDER BY TAP.CAD_TAP_DS_ATRIBUTO;
    io_cursor := v_cursor;
  end PRC_CAD_TAP_TP_ATRIB_PRODUTO_R;
