  --PRC_INT_TIS_INDACIDENTE_SID
  create or replace procedure PRC_INT_TIS_INDACIDENTE_SID 
  (
     pTIS_IAC_CD_INDACIDENTE IN TB_TIS_IAC_INDACIDENTE.TIS_IAC_CD_INDACIDENTE%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_TIS_INDACIDENTE_SID
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
       TIS_IAC_CD_INDACIDENTE,
       TIS_IAC_DS_INDACIDENTE
    FROM TB_TIS_IAC_INDACIDENTE
    WHERE
        TIS_IAC_CD_INDACIDENTE = pTIS_IAC_CD_INDACIDENTE;          
    io_cursor := v_cursor;
  end PRC_INT_TIS_INDACIDENTE_SID;
