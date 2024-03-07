 
--PRC_CAD_CPR_CREDENCIA_PROF_L
create or replace procedure PRC_CAD_CPR_CREDENCIA_PROF_L 
(
     pCAD_CPR_TP_CREDENCIA_PROF IN TB_CAD_CPR_CREDENCIA_PROF.CAD_CPR_TP_CREDENCIA_PROF%type DEFAULT NULL,
     pCAD_CPR_DS_CREDENCIA_PROF IN TB_CAD_CPR_CREDENCIA_PROF.CAD_CPR_DS_CREDENCIA_PROF%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_CPR_CREDENCIA_PROF_L
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
  IF pCAD_CPR_TP_CREDENCIA_PROF IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_CPR_TP_CREDENCIA_PROF = ' || CHR(39) || pCAD_CPR_TP_CREDENCIA_PROF || CHR(39); END IF;
IF pCAD_CPR_DS_CREDENCIA_PROF IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_CPR_DS_CREDENCIA_PROF = ' || CHR(39) || pCAD_CPR_DS_CREDENCIA_PROF || CHR(39); END IF;
 
   V_SELECT := '
SELECT	
       CAD_CPR_TP_CREDENCIA_PROF,
       CAD_CPR_DS_CREDENCIA_PROF
FROM TB_CAD_CPR_CREDENCIA_PROF
WHERE null is null  '    ;
       
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_CAD_CPR_CREDENCIA_PROF_L;
