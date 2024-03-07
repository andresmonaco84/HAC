create or replace procedure PRC_TIS_UTD_UNIDTEMPODOENCA_S
  (
     pTIS_UTD_CD_UNIDTEMPODOENCA IN TB_TIS_UTD_UNIDTEMPODOENCA.TIS_UTD_CD_UNIDTEMPODOENCA%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_UTD_UNIDTEMPODOENCA_S
  *
  *    Data Criacao: 	16/04/2007   Por:Silmara
  *    Data Alteracao:	data da altera???#o  Por: Nome do Analista
  *
  *    Funcao: Obt??m  unidade(s) de tempo de doen??a(s)-TISS
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       TIS_UTD_CD_UNIDTEMPODOENCA,
       TIS_UTD_DS_UNIDTEMPODOENCA,
       TIS_UTD_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       TIS_UTD_DT_ULT_ATUALIZACAO,
       SEG_USU_ID_USU_ULT_ATUALIZ
    FROM TB_TIS_UTD_UNIDTEMPODOENCA
    WHERE
        (pTIS_UTD_CD_UNIDTEMPODOENCA is null OR TIS_UTD_CD_UNIDTEMPODOENCA = pTIS_UTD_CD_UNIDTEMPODOENCA)
        ORDER BY TIS_UTD_CD_UNIDTEMPODOENCA;
    io_cursor := v_cursor;
  end PRC_TIS_UTD_UNIDTEMPODOENCA_S;
 