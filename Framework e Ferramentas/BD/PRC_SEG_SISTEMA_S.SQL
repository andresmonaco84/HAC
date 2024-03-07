 --PRC_SEG_SISTEMA_S 
create or replace procedure PRC_SEG_SISTEMA_S 
(
     pSEG_ID_SISTEMA IN TB_SEG_SISTEMA.SEG_ID_SISTEMA%type DEFAULT NULL,
     pSEG_NM_SISTEMA IN TB_SEG_SISTEMA.SEG_NM_SISTEMA%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_SEG_SISTEMA_S
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
  IF pSEG_ID_SISTEMA IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_ID_SISTEMA = ' || pSEG_ID_SISTEMA; END IF;
IF pSEG_NM_SISTEMA IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_NM_SISTEMA = ' || CHR(39) || pSEG_NM_SISTEMA || CHR(39); END IF;
 
   V_SELECT := '
SELECT	
       SEG_ID_SISTEMA,
       SEG_NM_SISTEMA
FROM TB_SEG_SISTEMA
WHERE null is null  '    ;
       
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_SEG_SISTEMA_S;
