  --PRC_INT_CAD_SITQUARTOLEITO_SID
  create or replace procedure PRC_INT_CAD_SITQUARTOLEITO_SID
  (
     pCAD_SQL_CD_SIT_QUARTO_LEITO IN TB_CAD_SQL_SIT_QUARTO_LEITO.CAD_SQL_CD_SIT_QUARTO_LEITO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_CAD_SITQUARTOLEITO_SID
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
       CAD_SQL_CD_SIT_QUARTO_LEITO,
       CAD_SQL_DS_SIT_QUARTO_LEITO
    FROM TB_CAD_SQL_SIT_QUARTO_LEITO
    WHERE
        CAD_SQL_CD_SIT_QUARTO_LEITO = pCAD_SQL_CD_SIT_QUARTO_LEITO;          
    io_cursor := v_cursor;
  end PRC_INT_CAD_SITQUARTOLEITO_SID;