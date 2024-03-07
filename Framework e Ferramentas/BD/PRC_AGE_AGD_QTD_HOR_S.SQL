create or replace procedure PRC_AGE_AGD_QTD_HOR_S
  (
     pAGE_ESM_ID IN TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_ID%type,
     pAGE_AGD_FL_STATUS IN TB_AGE_AGD_AGENDA.AGE_AGD_FL_STATUS%type,
     pAGE_AGD_TP_AGENDA IN TB_AGE_AGD_AGENDA.AGE_AGD_TP_AGENDA%type default null,
     pAGE_AGD_DT_ATENDIMENTO IN TB_AGE_AGD_AGENDA.AGE_AGD_DT_ATENDIMENTO%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_AGD_QTD_HOR_S
  *
  *    Data Criacao: 	 08/08/2007            Por: Guilherme Holdack
  *    Data Alteracao: 14/09/2007            Por: Bruno A. Costa
  *
  *    Função: Lista a contagem de registros de acordo com filtros específicos
  *    Alteração: Somente para datas iguais ou maiores que data atual
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
          COUNT(AGD.AGE_AGD_ID)
    FROM TB_AGE_AGD_AGENDA AGD
    WHERE
    (AGD.AGE_ESM_ID  =  pAGE_ESM_ID)
    AND agd.age_agd_fl_status <> pAGE_AGD_FL_STATUS
    AND (pAGE_AGD_TP_AGENDA is null or AGD.AGE_AGD_TP_AGENDA = pAGE_AGD_TP_AGENDA)
    AND AGE_AGD_DT_ATENDIMENTO = pAGE_AGD_DT_ATENDIMENTO;
    io_cursor := v_cursor;

end PRC_AGE_AGD_QTD_HOR_S;
