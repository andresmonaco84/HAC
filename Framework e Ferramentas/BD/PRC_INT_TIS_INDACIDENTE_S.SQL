  --PRC_INT_TIS_INDACIDENTE_S
create or replace procedure PRC_INT_TIS_INDACIDENTE_S(pTIS_IAC_CD_INDACIDENTE IN TB_TIS_IAC_INDACIDENTE.TIS_IAC_CD_INDACIDENTE%type DEFAULT NULL,
                                                      pTIS_IAC_DS_INDACIDENTE IN TB_TIS_IAC_INDACIDENTE.TIS_IAC_DS_INDACIDENTE%type DEFAULT NULL,
                                                      io_cursor               OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_INT_TIS_INDACIDENTE_S
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
  IF pTIS_IAC_CD_INDACIDENTE IS NOT NULL THEN
    V_WHERE := V_WHERE || 'WHERE TIS_IAC_CD_INDACIDENTE = ' ||
               pTIS_IAC_CD_INDACIDENTE;
  END IF;
  IF pTIS_IAC_DS_INDACIDENTE IS NOT NULL THEN
    IF V_WHERE IS NULL THEN
      V_WHERE := V_WHERE || 'WHERE TIS_IAC_DS_INDACIDENTE = ' ||
                 pTIS_IAC_DS_INDACIDENTE;
    ELSE
      V_WHERE := V_WHERE || ' AND TIS_IAC_DS_INDACIDENTE = ' ||
                 pTIS_IAC_DS_INDACIDENTE;
    END IF;
  END IF;
  V_SELECT := 'SELECT	
       TIS_IAC_CD_INDACIDENTE,
       TIS_IAC_DS_INDACIDENTE
    FROM TB_TIS_IAC_INDACIDENTE ' || V_WHERE;
  OPEN v_cursor FOR V_SELECT;
  io_cursor := v_cursor;
end PRC_INT_TIS_INDACIDENTE_S;
/
