 
--PRC_CAD_CME_CLASSIF_MED_L
create or replace procedure PRC_CAD_CME_CLASSIF_MED_L 
(
     pCAD_CME_CLASSIF_MED IN TB_CAD_CME_CLASSIF_MED.CAD_CME_CLASSIF_MED%type DEFAULT NULL,
     pCAD_CME_DS_CLASSIF_MED IN TB_CAD_CME_CLASSIF_MED.CAD_CME_DS_CLASSIF_MED%type DEFAULT NULL,
     pCAD_CME_DT_ULTIMA_ATUALIZACAO IN TB_CAD_CME_CLASSIF_MED.CAD_CME_DT_ULTIMA_ATUALIZACAO%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_CAD_CME_CLASSIF_MED.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_CME_CLASSIF_MED_L
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
  IF pCAD_CME_CLASSIF_MED IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_CME_CLASSIF_MED = ' || pCAD_CME_CLASSIF_MED; END IF;
IF pCAD_CME_DS_CLASSIF_MED IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_CME_DS_CLASSIF_MED = ' || CHR(39) || pCAD_CME_DS_CLASSIF_MED || CHR(39); END IF;
IF pCAD_CME_DT_ULTIMA_ATUALIZACAO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_CME_DT_ULTIMA_ATUALIZACAO = ' || CHR(39) || pCAD_CME_DT_ULTIMA_ATUALIZACAO || CHR(39); END IF;
IF pSEG_USU_ID_USUARIO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_USU_ID_USUARIO = ' || pSEG_USU_ID_USUARIO; END IF;
 
   V_SELECT := '
SELECT	
       CAD_CME_CLASSIF_MED,
       CAD_CME_DS_CLASSIF_MED,
       CAD_CME_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
FROM TB_CAD_CME_CLASSIF_MED
WHERE null is null  '    ;
       
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_CAD_CME_CLASSIF_MED_L;
