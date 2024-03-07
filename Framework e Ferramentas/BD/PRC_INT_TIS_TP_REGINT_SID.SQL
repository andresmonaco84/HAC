  --PRC_INT_TIS_TP_REGINT_SID
  create or replace procedure PRC_INT_TIS_TP_REGINT_SID 
  (
     pTIS_TRI_CD_TP_REGINTERNACAO IN TB_TIS_TRI_TP_REGINTERNACAO.TIS_TRI_CD_TP_REGINTERNACAO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_TIS_TP_REGINT_SID
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
       TIS_TRI_CD_TP_REGINTERNACAO,
       TIS_TRI_DS_TP_REGINTERNACAO
    FROM TB_TIS_TRI_TP_REGINTERNACAO
    WHERE
        TIS_TRI_CD_TP_REGINTERNACAO = pTIS_TRI_CD_TP_REGINTERNACAO;          
    io_cursor := v_cursor;
  end PRC_INT_TIS_TP_REGINT_SID;
