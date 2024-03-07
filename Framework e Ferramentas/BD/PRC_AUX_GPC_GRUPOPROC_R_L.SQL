
--PRC_AUX_GPC_GRUPOPROC_R_L
create or replace procedure PRC_AUX_GPC_GRUPOPROC_R_L 
(
     pAUX_GPC_CD_GRUPOPROC IN TB_AUX_GPC_GRUPOPROC.AUX_GPC_CD_GRUPOPROC%type DEFAULT NULL,
     pAUX_GPC_DS_DESCRICAO IN TB_AUX_GPC_GRUPOPROC.AUX_GPC_DS_DESCRICAO%type DEFAULT NULL,
     pAUX_EPP_CD_ESPECPROC IN TB_AUX_GPC_GRUPOPROC.AUX_EPP_CD_ESPECPROC%type DEFAULT NULL,
     pTIS_MED_CD_TABELAMEDICA IN TB_AUX_GPC_GRUPOPROC.TIS_MED_CD_TABELAMEDICA%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_AUX_GPC_GRUPOPROC_R_L
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
  IF pAUX_GPC_CD_GRUPOPROC IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND AUX_GPC_CD_GRUPOPROC = ' || CHR(39) || pAUX_GPC_CD_GRUPOPROC || CHR(39); END IF;
IF pAUX_GPC_DS_DESCRICAO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND AUX_GPC_DS_DESCRICAO = ' || CHR(39) || pAUX_GPC_DS_DESCRICAO || CHR(39); END IF;
IF pAUX_EPP_CD_ESPECPROC IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND AUX_EPP_CD_ESPECPROC = ' || CHR(39) || pAUX_EPP_CD_ESPECPROC || CHR(39); END IF;
IF pTIS_MED_CD_TABELAMEDICA IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND TIS_MED_CD_TABELAMEDICA = ' || CHR(39) || pTIS_MED_CD_TABELAMEDICA || CHR(39); END IF;
 
   V_SELECT := '
SELECT	
       AUX_GPC_CD_GRUPOPROC,
       AUX_GPC_DS_DESCRICAO,
       AUX_EPP_CD_ESPECPROC,
       TIS_MED_CD_TABELAMEDICA
FROM TB_AUX_GPC_GRUPOPROC
WHERE null is null  '    ;
       
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_AUX_GPC_GRUPOPROC_R_L;
