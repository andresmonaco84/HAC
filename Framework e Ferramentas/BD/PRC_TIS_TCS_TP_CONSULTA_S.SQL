create or replace procedure PRC_TIS_TDO_TIPODOENCA_S
  (
     pTIS_TDO_CD_TIPODOENCA IN TB_TIS_TDO_TIPODOENCA.TIS_TDO_CD_TIPODOENCA%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: {nome da procedure}
  *
  *    Data Criacao: 	data da  cria???#o   Por: Nome do Analista
  *    Data Alteracao:	data da altera???#o  Por: Nome do Analista
  *
  *    Funcao: Descri???#o da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       TIS_TDO_CD_TIPODOENCA,
       TIS_TDO_DS_TIPODOENCA,
       TIS_TDO_DT_CRIACAO,
        SEG_USU_ID_USUARIO_CRIACAO,
        TIS_TDO_DT_ULT_ATUALIZACAO,
        SEG_USU_ID_USU_ULT_ATUALIZ

    FROM TB_TIS_TDO_TIPODOENCA
    WHERE
        (pTIS_TDO_CD_TIPODOENCA is null OR TIS_TDO_CD_TIPODOENCA = pTIS_TDO_CD_TIPODOENCA)
        ORDER BY TIS_TDO_CD_TIPODOENCA;
    io_cursor := v_cursor;
  end PRC_TIS_TDO_TIPODOENCA_S;
 