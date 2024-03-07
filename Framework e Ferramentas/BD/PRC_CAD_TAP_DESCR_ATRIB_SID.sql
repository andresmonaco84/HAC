create or replace procedure PRC_CAD_TAP_DESCR_ATRIB_SID
  (
     pCAD_TAP_TP_ATRIBUTO IN TB_CAD_TAP_TP_ATRIB_PRODUTO.CAD_TAP_TP_ATRIBUTO%type,     
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_TAP_DESCR_ATRIB_SID
  * 
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT  
       CAD_TAP_TP_ATRIBUTO,
       CAD_TAP_DS_ATRIBUTO
    FROM TB_CAD_TAP_TP_ATRIB_PRODUTO
    WHERE
        CAD_TAP_TP_ATRIBUTO = pCAD_TAP_TP_ATRIBUTO;          
    io_cursor := v_cursor;
  end PRC_CAD_TAP_DESCR_ATRIB_SID;
