CREATE OR REPLACE
procedure PRC_TIS_SPR_STATUS_PROTOCOLO_S
  (
     pTIS_SPR_CD_STATUS IN TB_TIS_SPR_STATUS_PROTOCOLO.TIS_SPR_CD_STATUS%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: {nome da procedure}
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
       TIS_SPR_CD_STATUS,
       TIS_SPR_DS_STATUS
    FROM TB_TIS_SPR_STATUS_PROTOCOLO
    WHERE
        (pTIS_SPR_CD_STATUS is null OR TIS_SPR_CD_STATUS = pTIS_SPR_CD_STATUS);
    io_cursor := v_cursor;
  end PRC_TIS_SPR_STATUS_PROTOCOLO_S;
/
