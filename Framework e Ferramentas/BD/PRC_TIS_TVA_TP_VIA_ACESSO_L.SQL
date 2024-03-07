create or replace procedure PRC_TIS_TVA_TP_VIA_ACESSO_L
(
     pTIS_TVA_CD_VIAACESSO IN TB_TIS_TVA_TP_VIA_ACESSO.TIS_TVA_CD_VIAACESSO%type DEFAULT NULL,
     pTIS_TVA_DS_VIAACESSO IN TB_TIS_TVA_TP_VIA_ACESSO.TIS_TVA_DS_VIAACESSO%type DEFAULT NULL,
	   pTIS_TVA_FL_STATUS	   IN TB_TIS_TVA_TP_VIA_ACESSO.TIS_TVA_FL_STATUS%type DEFAULT NULL,
     pTIS_TVA_CD_VIAACESSO_V3 IN TB_TIS_TVA_TP_VIA_ACESSO.TIS_TVA_CD_VIAACESSO_V3%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_TIS_TVA_TP_VIA_ACESSO_L
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
  IF pTIS_TVA_CD_VIAACESSO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND TIS_TVA_CD_VIAACESSO = ' || CHR(39) || pTIS_TVA_CD_VIAACESSO || CHR(39); END IF;
  IF pTIS_TVA_DS_VIAACESSO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND TIS_TVA_DS_VIAACESSO = ' || CHR(39) || pTIS_TVA_DS_VIAACESSO || CHR(39); END IF;
  IF pTIS_TVA_FL_STATUS IS NOT NULL THEN V_WHERE := V_WHERE || ' AND TIS_TVA_FL_STATUS = ' || CHR(39) || pTIS_TVA_FL_STATUS || CHR(39); END IF;
  IF pTIS_TVA_CD_VIAACESSO_V3 IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND TIS_TVA_CD_VIAACESSO_V3 = ' || CHR(39) || pTIS_TVA_CD_VIAACESSO_V3 || CHR(39); END IF;

   V_SELECT := '
SELECT
       TIS_TVA_CD_VIAACESSO,
       TIS_TVA_DS_VIAACESSO,
       TIS_TVA_FL_STATUS,
       TIS_TVA_CD_VIAACESSO_V3
FROM TB_TIS_TVA_TP_VIA_ACESSO
WHERE null is null  '    ;

OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_TIS_TVA_TP_VIA_ACESSO_L;