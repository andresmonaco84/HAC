  --PRC_INT_TIS_TP_INTERNACAO_SID
  create or replace procedure PRC_INT_TIS_TP_INTERNACAO_SID 
  (
     pTIS_TIN_CD_INTERNACAO IN TB_TIS_TIN_TP_INTERNACAO.TIS_TIN_CD_INTERNACAO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_TIS_TP_INTERNACAO_SID
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       TIS_TIN_CD_INTERNACAO,
       TIS_TIN_DS_INTERNACAO
    FROM TB_TIS_TIN_TP_INTERNACAO
    WHERE
        TIS_TIN_CD_INTERNACAO = pTIS_TIN_CD_INTERNACAO;          
    io_cursor := v_cursor;
  end PRC_INT_TIS_TP_INTERNACAO_SID;
