  --PRC_INT_TIS_TP_REGINT_S
create or replace procedure PRC_INT_TIS_TP_REGINT_S(pTIS_TRI_CD_TP_REGINTERNACAO IN TB_TIS_TRI_TP_REGINTERNACAO.TIS_TRI_CD_TP_REGINTERNACAO%type DEFAULT NULL,
                                                    pTIS_TRI_DS_TP_REGINTERNACAO IN TB_TIS_TRI_TP_REGINTERNACAO.TIS_TRI_DS_TP_REGINTERNACAO%type DEFAULT NULL,
                                                    io_cursor                    OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_INT_TIS_TP_REGINT_S
  * 
  *    Data Criacao:  data da  criaÃ§Ã£o   Por: Nome do Analista
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
  IF pTIS_TRI_CD_TP_REGINTERNACAO IS NOT NULL THEN
    V_WHERE := V_WHERE || 'WHERE TIS_TRI_CD_TP_REGINTERNACAO = ' ||
               pTIS_TRI_CD_TP_REGINTERNACAO;
  END IF;
  IF pTIS_TRI_DS_TP_REGINTERNACAO IS NOT NULL THEN
    IF V_WHERE IS NULL THEN
      V_WHERE := V_WHERE || 'WHERE TIS_TRI_DS_TP_REGINTERNACAO = ' ||
                 pTIS_TRI_DS_TP_REGINTERNACAO;
    ELSE
      V_WHERE := V_WHERE || ' AND TIS_TRI_DS_TP_REGINTERNACAO = ' ||
                 pTIS_TRI_DS_TP_REGINTERNACAO;
    END IF;
  END IF;
  V_SELECT := 'SELECT	
       TIS_TRI_CD_TP_REGINTERNACAO,
       TIS_TRI_DS_TP_REGINTERNACAO
    FROM TB_TIS_TRI_TP_REGINTERNACAO ' || V_WHERE;
  OPEN v_cursor FOR V_SELECT;
  io_cursor := v_cursor;
end PRC_INT_TIS_TP_REGINT_S;
/
