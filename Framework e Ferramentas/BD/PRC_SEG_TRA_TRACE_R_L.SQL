--PRC_SEG_TRA_TRACE_R_L
create or replace procedure PRC_SEG_TRA_TRACE_R_L 
(
     pSEG_TRA_ID_TRACE IN TB_SEG_TRA_TRACE.SEG_TRA_ID_TRACE%type DEFAULT NULL,
     pSEG_TRA_DT_TRACE IN TB_SEG_TRA_TRACE.SEG_TRA_DT_TRACE%type DEFAULT NULL,
     pSEG_TRA_NR_IP IN TB_SEG_TRA_TRACE.SEG_TRA_NR_IP%type DEFAULT NULL,
     pSEG_TRA_DS_URL IN TB_SEG_TRA_TRACE.SEG_TRA_DS_URL%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_SEG_TRA_TRACE.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_SEG_TRA_TRACE_R_L
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
  IF pSEG_TRA_ID_TRACE IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_TRA_ID_TRACE = ' || pSEG_TRA_ID_TRACE; END IF;
IF pSEG_TRA_DT_TRACE IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_TRA_DT_TRACE = ' || CHR(39) || pSEG_TRA_DT_TRACE || CHR(39); END IF;
IF pSEG_TRA_NR_IP IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_TRA_NR_IP = ' || CHR(39) || pSEG_TRA_NR_IP || CHR(39); END IF;
IF pSEG_TRA_DS_URL IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_TRA_DS_URL = ' || CHR(39) || pSEG_TRA_DS_URL || CHR(39); END IF;
IF pSEG_USU_ID_USUARIO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_USU_ID_USUARIO = ' || pSEG_USU_ID_USUARIO; END IF;
 
   V_SELECT := '
SELECT	
       SEG_TRA_ID_TRACE,
       SEG_TRA_DT_TRACE,
       SEG_TRA_NR_IP,
       SEG_TRA_DS_URL,
       SEG_USU_ID_USUARIO
FROM TB_SEG_TRA_TRACE
WHERE null is null  '    ;
       
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_SEG_TRA_TRACE_R_L;
