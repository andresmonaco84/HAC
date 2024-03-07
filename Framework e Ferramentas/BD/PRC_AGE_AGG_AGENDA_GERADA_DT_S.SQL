create or replace procedure PRC_AGE_AGG_AGENDA_GERADA_DT_S
  (
     pAGE_AGG_ID IN TB_AGE_AGG_AGENDA_GERADA.AGE_AGG_ID%type DEFAULT NULL,
     pAGE_AGG_DT_AGENDA IN TB_AGE_AGG_AGENDA_GERADA.AGE_AGG_DT_AGENDA%type DEFAULT NULL,
     pAGE_AGG_HR_AGENDA IN TB_AGE_AGG_AGENDA_GERADA.AGE_AGG_HR_AGENDA%type DEFAULT NULL,
     pAGE_ESM_ID IN TB_AGE_AGG_AGENDA_GERADA.AGE_ESM_ID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure:        PRC_AGE_AGG_AGENDA_GERADA_DT_S
  *    Data Criacao: 	   Por: Fabiola R. Lopes
  *
  *    Data Alteracao:  04/05/2009          Por: Davi Silvestre M. dos Reis
  *			    Alteracao: Limitacao da exibicao da agenda gerada em 90 dias
  *
  *    Funcao:           Listar as Datas da Agenda Gerada
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	DISTINCT
       AGE_AGG_DT_AGENDA
    FROM TB_AGE_AGG_AGENDA_GERADA
    WHERE
        (pAGE_AGG_ID is null OR AGE_AGG_ID = pAGE_AGG_ID)
    AND (pAGE_AGG_DT_AGENDA is null OR AGE_AGG_DT_AGENDA = pAGE_AGG_DT_AGENDA)
    AND (pAGE_AGG_HR_AGENDA is null OR AGE_AGG_HR_AGENDA = pAGE_AGG_HR_AGENDA)
    AND (pAGE_ESM_ID is null OR AGE_ESM_ID = pAGE_ESM_ID)
--    AND AGE_AGG_DT_AGENDA > SYSDATE;
    AND AGE_AGG_DT_AGENDA BETWEEN TRUNC(SYSDATE) AND ADD_MONTHS(TRUNC(SYSDATE), 3);
    io_cursor := v_cursor;
  end PRC_AGE_AGG_AGENDA_GERADA_DT_S;
/
