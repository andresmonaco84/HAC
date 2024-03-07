create or replace procedure PRC_TIS_IAC_INDACIDENTE_S
  (
     pTIS_IAC_CD_INDACIDENTE IN TB_TIS_IAC_INDACIDENTE.TIS_IAC_CD_INDACIDENTE%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_IAC_INDACIDENTE_S
  *
  *    Data Criacao:  13/04/2007   Por: Silmara
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Obtem indicador(es) de acidente(s) -TISS
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       TIS_IAC_CD_INDACIDENTE,
       TIS_IAC_DS_INDACIDENTE,
       TIS_IAC_FL_STATUS,
       TIS_IAC_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       TIS_IAC_DT_ULT_ATUALIZACAO,
       SEG_USU_ID_USU_ULT_ATUALIZ

    FROM TB_TIS_IAC_INDACIDENTE
    WHERE
        (pTIS_IAC_CD_INDACIDENTE is null OR TIS_IAC_CD_INDACIDENTE = pTIS_IAC_CD_INDACIDENTE)
        order by TIS_IAC_CD_INDACIDENTE;
    io_cursor := v_cursor;
  end PRC_TIS_IAC_INDACIDENTE_S;
 