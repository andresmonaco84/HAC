create or replace procedure PRC_TIS_CPR_CONSELHO_PROF_S
  (
     pTIS_CPR_CD_CONSELHOPROF IN TB_TIS_CPR_CONSELHO_PROF.TIS_CPR_CD_CONSELHOPROF%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_CPR_CONSELHO_PROF_S
  *
  *    Data Criacao: 	07/03/2007  Por: Silmara
  *
  *    Funcao:  Obtém Conselho(s) Profissional(is) - TISS
  *
  *    Data Alteração:  20/03/2014  Por:  Andréa Cazuca
  *    Alteração: Inclusão do campo TIS_CPR_CD_CONSELHOPROF_V3
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       TIS_CPR_CD_CONSELHOPROF,
       TIS_CPR_DS_CONSELHOPROF,
	     TIS_CPR_FL_STATUS,
       TIS_CPR_CD_CONSELHOPROF_V3
    FROM TB_TIS_CPR_CONSELHO_PROF
    WHERE
        (pTIS_CPR_CD_CONSELHOPROF is null OR TIS_CPR_CD_CONSELHOPROF = pTIS_CPR_CD_CONSELHOPROF)
        order by TIS_CPR_CD_CONSELHOPROF;
    io_cursor := v_cursor;
  end PRC_TIS_CPR_CONSELHO_PROF_S;