create or replace procedure PRC_TIS_TTP_TPTECNICA_PROCED_S
  (
     pTIS_TTP_CD_TPTECNICA IN TB_TIS_TTP_TPTECNICA_PROCED.TIS_TTP_CD_TPTECNICA%type DEFAULT NULL,
     pTIS_TTP_DS_TPTECNICA IN TB_TIS_TTP_TPTECNICA_PROCED.TIS_TTP_DS_TPTECNICA%type DEFAULT NULL,
	 io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TTP_TPTECNICA_PROCED_S
  *
  *    Data Criacao: 	12/03/2007   Por: Andréa Cazuca
  *    Data Alteracao:	           Por:
  *
  *    Funcao: Seleciona Técnica Utilizada no Procedimento
  *
  *    Data Alteracao: 19/11/2007  Por: Guilherme Holdack
  *    Alteração: Remoção de Upper em campo, no where
  *
  *    Data Alteração: 20/03/2014  Por: Andréa Cazuca
  *    Alteração:  Inclusão dos campos TIS_TTP_CD_TPTECNICA_V3, TIS_TTP_DS_OBSERVACAO
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       TIS_TTP_CD_TPTECNICA,
       TIS_TTP_DS_TPTECNICA,
	     TIS_TTP_FL_STATUS,
       TIS_TTP_CD_TPTECNICA_V3,
       TIS_TTP_DS_OBSERVACAO
    FROM TB_TIS_TTP_TPTECNICA_PROCED
    WHERE
        (pTIS_TTP_CD_TPTECNICA is null OR TIS_TTP_CD_TPTECNICA = pTIS_TTP_CD_TPTECNICA)
        AND (pTIS_TTP_DS_TPTECNICA is null OR TIS_TTP_DS_TPTECNICA LIKE UPPER(pTIS_TTP_DS_TPTECNICA))
    order by TIS_TTP_CD_TPTECNICA;
    io_cursor := v_cursor;
  end PRC_TIS_TTP_TPTECNICA_PROCED_S;