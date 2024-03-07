create or replace procedure PRC_INT_TIS_TP_INTERNACAO_S(pTIS_TIN_CD_INTERNACAO IN TB_TIS_TIN_TP_INTERNACAO.TIS_TIN_CD_INTERNACAO%type DEFAULT NULL,
                                                                   pTIS_TIN_DS_INTERNACAO IN TB_TIS_TIN_TP_INTERNACAO.TIS_TIN_DS_INTERNACAO%type DEFAULT NULL,
                                                                   io_cursor              OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_INT_TIS_TP_INTERNACAO_S
  * 
  *    Data Criacao:  data da  criação   Por: Nome do Analista
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *    Data Alteracao:  01/11/2010  Por: Cristiane
  *    Alteracao: Não utilizar mais OR para tratar parametros nulos
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(2000);
  V_SELECT varchar2(4000);
begin
  V_WHERE := NULL;
  IF pTIS_TIN_CD_INTERNACAO IS NOT NULL THEN
    V_WHERE := V_WHERE || 'WHERE TIS_TIN_CD_INTERNACAO = ' ||
               pTIS_TIN_CD_INTERNACAO;
  END IF;
  IF pTIS_TIN_DS_INTERNACAO IS NOT NULL THEN
    IF V_WHERE IS NULL THEN
      V_WHERE := V_WHERE || 'WHERE TIS_TIN_DS_INTERNACAO = ' ||
                 pTIS_TIN_DS_INTERNACAO;
    ELSE
      V_WHERE := V_WHERE || ' AND TIS_TIN_DS_INTERNACAO = ' ||
                 pTIS_TIN_DS_INTERNACAO;
    END IF;
  END IF;
  V_SELECT := 'SELECT TIS_TIN_CD_INTERNACAO, TIS_TIN_DS_INTERNACAO
      FROM TB_TIS_TIN_TP_INTERNACAO ' || V_WHERE;
  OPEN v_cursor FOR
    V_SELECT;
  io_cursor := v_cursor;
end PRC_INT_TIS_TP_INTERNACAO_S;
/
