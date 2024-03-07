--PRC_CAD_SPL_SUB_PLANO_RMT_S
create or replace procedure PRC_CAD_SPL_SUB_PLANO_RMT_S 
(
     pCAD_SPL_ID IN TB_CAD_SPL_SUB_PLANO.CAD_SPL_ID%type DEFAULT NULL,
     pCAD_SPL_CD_SUB_PLANO IN TB_CAD_SPL_SUB_PLANO.CAD_SPL_CD_SUB_PLANO%type DEFAULT NULL,
     pCAD_SPL_DS_SUB_PLANO IN TB_CAD_SPL_SUB_PLANO.CAD_SPL_DS_SUB_PLANO%type DEFAULT NULL,
     pCAD_SPL_FL_STATUS IN TB_CAD_SPL_SUB_PLANO.CAD_SPL_FL_STATUS%type DEFAULT NULL,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_SPL_SUB_PLANO.CAD_CNV_ID_CONVENIO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_SPL_SUB_PLANO_RMT_S
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
  IF pCAD_SPL_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SPL_ID = ' || pCAD_SPL_ID; END IF;
IF pCAD_SPL_CD_SUB_PLANO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SPL_CD_SUB_PLANO = ' || CHR(39) || pCAD_SPL_CD_SUB_PLANO || CHR(39); END IF;
IF pCAD_SPL_DS_SUB_PLANO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SPL_DS_SUB_PLANO = ' || CHR(39) || pCAD_SPL_DS_SUB_PLANO || CHR(39); END IF;
IF pCAD_SPL_FL_STATUS IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SPL_FL_STATUS = ' || CHR(39) || pCAD_SPL_FL_STATUS || CHR(39); END IF;
IF pCAD_CNV_ID_CONVENIO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO; END IF;
 
   V_SELECT := '
SELECT	
       CAD_SPL_ID,
       CAD_SPL_CD_SUB_PLANO,
       CAD_SPL_DS_SUB_PLANO,
       CAD_SPL_FL_STATUS,
       CAD_CNV_ID_CONVENIO
FROM TB_CAD_SPL_SUB_PLANO
WHERE null is null  '    ;
       
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_CAD_SPL_SUB_PLANO_RMT_S;
