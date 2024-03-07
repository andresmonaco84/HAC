--PRC_TIS_TLG_TP_LOGRADOURO_RMT_S
create or replace procedure PRC_TIS_TLG_TP_LOGRADOURO_RMT_S 
(
     pTIS_TLG_CD_TPLOGRADOURO IN TB_TIS_TLG_TP_LOGRADOURO.TIS_TLG_CD_TPLOGRADOURO%type DEFAULT NULL,
     pTIS_TLG_DS_TPLOGRADOURO IN TB_TIS_TLG_TP_LOGRADOURO.TIS_TLG_DS_TPLOGRADOURO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_TIS_TLG_TP_LOGRADOURO_RMT_S
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
  IF pTIS_TLG_CD_TPLOGRADOURO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND TIS_TLG_CD_TPLOGRADOURO = ' || CHR(39) || pTIS_TLG_CD_TPLOGRADOURO || CHR(39); END IF;
IF pTIS_TLG_DS_TPLOGRADOURO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND TIS_TLG_DS_TPLOGRADOURO = ' || CHR(39) || pTIS_TLG_DS_TPLOGRADOURO || CHR(39); END IF;
 
   V_SELECT := '
SELECT	
       TIS_TLG_CD_TPLOGRADOURO,
       TIS_TLG_DS_TPLOGRADOURO
FROM TB_TIS_TLG_TP_LOGRADOURO
WHERE null is null  '    ;
       
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_TIS_TLG_TP_LOGRADOURO_RMT_S;
