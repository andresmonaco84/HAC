create or replace procedure PRC_ATD_BUSCAR_PACIENTE_DATA
  (
     pATD_ATE_ID            IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE,
     pDATA_ATENDIMENTO      IN DATE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR

    SELECT FNC_BUSCAR_PACIENTE_DATA(pATD_ATE_ID, pDATA_ATENDIMENTO) CAD_PAC_ID_PACIENTE FROM DUAL;

    io_cursor := v_cursor;
  end PRC_ATD_BUSCAR_PACIENTE_DATA;
