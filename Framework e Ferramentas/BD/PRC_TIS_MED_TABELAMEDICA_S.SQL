create or replace procedure PRC_TIS_MED_TABELAMEDICA_S
  (
     pTIS_MED_CD_TABELAMEDICA IN TB_TIS_MED_TABELAMEDICA.TIS_MED_CD_TABELAMEDICA%type DEFAULT NULL,
     pTIS_MED_DS_TABELAMEDICA IN TB_TIS_MED_TABELAMEDICA.TIS_MED_DS_TABELAMEDICA%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_MED_TABELAMEDICA_S
  *
  *    Data Criacao:  11/04/07       Por: Silmara
  *    Data Alteracao: 11/02/2014   Por: Andre
  *         Alteracao: INCLUSAO DE ORDER BY pela TIS_MED_DS_TABELAMEDICA
  *
  *    Funcao: Obt??m  tabela(s) m??dica(s)- TISS
  *
  *    Data Alteracao: 19/11/2007  Por: Guilherme Holdack
  *    Alterac?o: Remoc?o de Upper em campo, no where
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       TIS_MED_CD_TABELAMEDICA,
       TIS_MED_DS_TABELAMEDICA,
       TIS_MED_DT_INICIO_VIGENCIA,
       TIS_MED_DT_FIM_VIGENCIA,
       TIS_MED_FL_STATUS,
       TIS_MED_FL_UTILIZA_LANCAMENTO,
       TIS_MED_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
    TIS_MED_FL_UTILIZA_REPASSE,
    TIS_MED_DT_CRIACAO,
    SEG_USU_ID_USUARIO_CRIACAO

    FROM TB_TIS_MED_TABELAMEDICA
    WHERE
        (pTIS_MED_CD_TABELAMEDICA is null OR TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA)
        AND (pTIS_MED_DS_TABELAMEDICA is null OR TIS_MED_DS_TABELAMEDICA LIKE UPPER('%'||pTIS_MED_DS_TABELAMEDICA||'%'))
        ORDER BY TIS_MED_DS_TABELAMEDICA;
    io_cursor := v_cursor;
  end PRC_TIS_MED_TABELAMEDICA_S;
 