create or replace procedure PRC_FAT_FCL_ULTIMO_LOTE
  (

     pNewIdt OUT integer,
      io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_FAT_FCL_ULTIMO_LOTE
  *
  *    Data Criacao:   11/02/2008   Por: PEDRO
  *    Data Alteracao:
  *    Alteracao:
  *
  *    Funcao: retorna o nrlote ultimo
  *
  *******************************************************************/
 v_cursor PKG_CURSOR.t_cursor;
 -- nrLote NUMBER;

  begin
   OPEN v_cursor FOR

select seq_fat_fcl_nr_seq_lote_01.nextval from dual;

io_cursor := v_cursor;

  end PRC_FAT_FCL_ULTIMO_LOTE;
