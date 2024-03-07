
--PRC_AUX_MUN_MUNICIPIO_RMT_S
create or replace procedure PRC_AUX_MUN_MUNICIPIO_RMT_S 
(
     pAUX_MUN_CD_IBGE IN TB_AUX_MUN_MUNICIPIO.AUX_MUN_CD_IBGE%type DEFAULT NULL,
     pAUX_MUN_SG_UF IN TB_AUX_MUN_MUNICIPIO.AUX_MUN_SG_UF%type DEFAULT NULL,
     pAUX_MUN_NM_MUNICIPIO IN TB_AUX_MUN_MUNICIPIO.AUX_MUN_NM_MUNICIPIO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_AUX_MUN_MUNICIPIO_RMT_S
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
  IF pAUX_MUN_CD_IBGE IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND AUX_MUN_CD_IBGE = ' || CHR(39) || pAUX_MUN_CD_IBGE || CHR(39); END IF;
IF pAUX_MUN_SG_UF IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND AUX_MUN_SG_UF = ' || CHR(39) || pAUX_MUN_SG_UF || CHR(39); END IF;
IF pAUX_MUN_NM_MUNICIPIO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND AUX_MUN_NM_MUNICIPIO = ' || CHR(39) || pAUX_MUN_NM_MUNICIPIO || CHR(39); END IF;
 
   V_SELECT := '
SELECT	
       AUX_MUN_CD_IBGE,
       AUX_MUN_SG_UF,
       AUX_MUN_NM_MUNICIPIO
FROM TB_AUX_MUN_MUNICIPIO
WHERE null is null  '    ;
       
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_AUX_MUN_MUNICIPIO_RMT_S;

