create or replace procedure PRC_TIS_TTP_TPTECNICA_PROCED_L
(
     pTIS_TTP_CD_TPTECNICA IN TB_TIS_TTP_TPTECNICA_PROCED.TIS_TTP_CD_TPTECNICA%type DEFAULT NULL,
     pTIS_TTP_DS_TPTECNICA IN TB_TIS_TTP_TPTECNICA_PROCED.TIS_TTP_DS_TPTECNICA%type DEFAULT NULL,
	   pTIS_TTP_FL_STATUS    IN TB_TIS_TTP_TPTECNICA_PROCED.TIS_TTP_FL_STATUS%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_TIS_TTP_TPTECNICA_PROCED_L
*
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
 v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(5000);
  V_SELECT  varchar2(5000);
begin
  V_WHERE := NULL;
  IF pTIS_TTP_CD_TPTECNICA IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND TIS_TTP_CD_TPTECNICA = ' || CHR(39) || pTIS_TTP_CD_TPTECNICA || CHR(39); END IF;
  IF pTIS_TTP_DS_TPTECNICA IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND TIS_TTP_DS_TPTECNICA = ' || CHR(39) || pTIS_TTP_DS_TPTECNICA || CHR(39); END IF;
  IF pTIS_TTP_FL_STATUS IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND TIS_TTP_FL_STATUS = ' || CHR(39) || pTIS_TTP_FL_STATUS || CHR(39); END IF;
  
   V_SELECT := '
SELECT
       TIS_TTP_CD_TPTECNICA,
       TIS_TTP_DS_TPTECNICA,
       TIS_TTP_FL_STATUS
FROM TB_TIS_TTP_TPTECNICA_PROCED
WHERE null is null  '    ;

OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_TIS_TTP_TPTECNICA_PROCED_L;