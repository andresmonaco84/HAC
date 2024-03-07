CREATE OR REPLACE procedure PRC_TIS_TLG_TP_LOGRADOURO_S 
  (
     pTIS_TLG_CD_TPLOGRADOURO IN TB_TIS_TLG_TP_LOGRADOURO.TIS_TLG_CD_TPLOGRADOURO%type DEFAULT NULL,
     pTIS_TLG_DS_TPLOGRADOURO IN TB_TIS_TLG_TP_LOGRADOURO.TIS_TLG_DS_TPLOGRADOURO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TLG_TP_LOGRADOURO_S
  * 
  *    Data Criacao: 	  06/03/2007           Por: Fabiola R. Lopes
  *    Data Alteracao:	                       Por: 
  *
  *    Funcao: Listar os Tipos de Logradouros
  *
  *    Data Alteracao: 19/11/2007  Por: Guilherme Holdack
  *    Alteração: Remoção de Upper em campo, no where
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	TIS_TLG_CD_TPLOGRADOURO,
			TIS_TLG_DS_TPLOGRADOURO
    FROM	TB_TIS_TLG_TP_LOGRADOURO
    WHERE
		( pTIS_TLG_CD_TPLOGRADOURO is null OR TIS_TLG_CD_TPLOGRADOURO = pTIS_TLG_CD_TPLOGRADOURO)
	AND	( pTIS_TLG_DS_TPLOGRADOURO is null OR TIS_TLG_DS_TPLOGRADOURO LIKE UPPER('%'||pTIS_TLG_DS_TPLOGRADOURO||'%'))
    ORDER BY TIS_TLG_CD_TPLOGRADOURO;
    io_cursor := v_cursor;
  end PRC_TIS_TLG_TP_LOGRADOURO_S;