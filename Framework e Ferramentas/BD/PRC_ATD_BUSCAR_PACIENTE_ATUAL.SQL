create or replace procedure PRC_ATD_BUSCAR_PACIENTE_ATUAL
  (
     pATD_ATE_ID            IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE DEFAULT NULL,  
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATD_BUSCAR_PACIENTE_ATUAL
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

    SELECT fnc_buscar_paciente_atual(pATD_ATE_ID) CAD_PAC_ID_PACIENTE FROM DUAL;

    io_cursor := v_cursor;
  end PRC_ATD_BUSCAR_PACIENTE_ATUAL;
