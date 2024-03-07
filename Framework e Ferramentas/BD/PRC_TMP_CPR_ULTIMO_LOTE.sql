create or replace procedure PRC_TMP_CPR_ULTIMO_LOTE
  (
     pNEWIDT OUT INTEGER,
     IO_CURSOR OUT PKG_CURSOR.T_CURSOR
  )
  is
  /********************************************************************
  *    Procedure: PRC_TMP_CPR_ULTIMO_LOTE
  *
  *    Data Criacao:   16/08/2011   Por: PEDRO
  *    Data Alteracao:
  *    Alteracao:
  *
  *    Funcao: retorna o nrlote ultimo
  *
  *******************************************************************/
 V_CURSOR PKG_CURSOR.T_CURSOR;

BEGIN

OPEN V_CURSOR FOR

  SELECT SEQ_TMP_CPR_01.NEXTVAL FROM DUAL ;

  IO_CURSOR := V_CURSOR;

end PRC_TMP_CPR_ULTIMO_LOTE;
/
