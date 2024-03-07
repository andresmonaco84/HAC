--PRC_TIS_TAT_TP_ATENDIMENTO_L
create or replace procedure PRC_TIS_TAT_TP_ATENDIMENTO_L 
(
     pTIS_TAT_CD_TPATENDIMENTO IN TB_TIS_TAT_TP_ATENDIMENTO.TIS_TAT_CD_TPATENDIMENTO%type DEFAULT NULL,
     pTIS_TAT_DS_TPATENDIMENTO IN TB_TIS_TAT_TP_ATENDIMENTO.TIS_TAT_DS_TPATENDIMENTO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_TIS_TAT_TP_ATENDIMENTO_L
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
  IF pTIS_TAT_CD_TPATENDIMENTO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND TIS_TAT_CD_TPATENDIMENTO = ' || CHR(39) || pTIS_TAT_CD_TPATENDIMENTO || CHR(39); END IF;
IF pTIS_TAT_DS_TPATENDIMENTO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND TIS_TAT_DS_TPATENDIMENTO = ' || CHR(39) || pTIS_TAT_DS_TPATENDIMENTO || CHR(39); END IF;
 
   V_SELECT := '
SELECT	
       TIS_TAT_CD_TPATENDIMENTO,
       TIS_TAT_DS_TPATENDIMENTO
FROM TB_TIS_TAT_TP_ATENDIMENTO
WHERE null is null  '    ;
       
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_TIS_TAT_TP_ATENDIMENTO_L;
