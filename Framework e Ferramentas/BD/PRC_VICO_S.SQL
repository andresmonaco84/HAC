create or replace procedure PRC_VICO_S
  (
     pCODSER IN BENEFICIARIO.SERVICO.CODSER%type DEFAULT NULL,
     pNOMSER IN BENEFICIARIO.SERVICO.NOMSER%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_VICO_S
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
       CODSER,
       NOMSER
    FROM BENEFICIARIO.SERVICO
    WHERE
        (pCODSER is null OR CODSER = pCODSER) AND
        (pNOMSER is null OR NOMSER = pNOMSER);
    io_cursor := v_cursor;
  end PRC_VICO_S;
