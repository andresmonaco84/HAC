  --PRC_TIS_TLG_TP_LOGRADOURO_SID
  create or replace procedure PRC_TIS_TLG_TP_LOGRADOURO_SID 
  (
     pTIS_TLG_CD_TPLOGRADOURO IN TB_TIS_TLG_TP_LOGRADOURO.TIS_TLG_CD_TPLOGRADOURO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TLG_TP_LOGRADOURO_SID
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
       TIS_TLG_CD_TPLOGRADOURO,
       TIS_TLG_DS_TPLOGRADOURO
    FROM TB_TIS_TLG_TP_LOGRADOURO
    WHERE
        TIS_TLG_CD_TPLOGRADOURO = pTIS_TLG_CD_TPLOGRADOURO;          
    io_cursor := v_cursor;
  end PRC_TIS_TLG_TP_LOGRADOURO_SID;