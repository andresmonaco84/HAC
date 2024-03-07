
--PRC_AUX_FPG_FORMAPAGTO_L
create or replace procedure PRC_AUX_FPG_FORMAPAGTO_L 
(
     pAUX_FPG_CD_FORMAPAGTO IN TB_AUX_FPG_FORMAPAGTO.AUX_FPG_CD_FORMAPAGTO%type DEFAULT NULL,
     pAUX_FPG_DS_FORMAPAGTO IN TB_AUX_FPG_FORMAPAGTO.AUX_FPG_DS_FORMAPAGTO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_AUX_FPG_FORMAPAGTO_L
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
  IF pAUX_FPG_CD_FORMAPAGTO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND AUX_FPG_CD_FORMAPAGTO = ' || CHR(39) || pAUX_FPG_CD_FORMAPAGTO || CHR(39); END IF;
IF pAUX_FPG_DS_FORMAPAGTO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND AUX_FPG_DS_FORMAPAGTO = ' || CHR(39) || pAUX_FPG_DS_FORMAPAGTO || CHR(39); END IF;
 
   V_SELECT := '
SELECT	
       AUX_FPG_CD_FORMAPAGTO,
       AUX_FPG_DS_FORMAPAGTO
FROM TB_AUX_FPG_FORMAPAGTO
WHERE null is null  '    ;
       
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_AUX_FPG_FORMAPAGTO_L;
