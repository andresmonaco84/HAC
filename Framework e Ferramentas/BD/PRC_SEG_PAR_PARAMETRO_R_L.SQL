--PRC_SEG_PAR_PARAMETRO_R_L
create or replace procedure PRC_SEG_PAR_PARAMETRO_R_L 
(
     pSEG_PAR_CD IN TB_SEG_PAR_PARAMETRO.SEG_PAR_CD%type DEFAULT NULL,
     pSEG_PAR_NM_PARAMETRO IN TB_SEG_PAR_PARAMETRO.SEG_PAR_NM_PARAMETRO%type DEFAULT NULL,
     pSEG_PAR_VL_PARAMETRO IN TB_SEG_PAR_PARAMETRO.SEG_PAR_VL_PARAMETRO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_SEG_PAR_PARAMETRO_R_L
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
  IF pSEG_PAR_CD IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_PAR_CD = ' || pSEG_PAR_CD; END IF;
IF pSEG_PAR_NM_PARAMETRO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_PAR_NM_PARAMETRO = ' || CHR(39) || pSEG_PAR_NM_PARAMETRO || CHR(39); END IF;
IF pSEG_PAR_VL_PARAMETRO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_PAR_VL_PARAMETRO = ' || CHR(39) || pSEG_PAR_VL_PARAMETRO || CHR(39); END IF;
 
   V_SELECT := '
SELECT	
       SEG_PAR_CD,
       SEG_PAR_NM_PARAMETRO,
       SEG_PAR_VL_PARAMETRO
FROM TB_SEG_PAR_PARAMETRO
WHERE null is null  '    ;
       
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_SEG_PAR_PARAMETRO_R_L;
