 
--PRC_CAD_CGC_CLASSIF_GRUPO_CONV_L
create or replace procedure PRC_CAD_CGC_CLASSIF_CONV_L 
(
     pCAD_CGC_ID IN TB_CAD_CGC_CLASSIF_GRUPO_CONV.CAD_CGC_ID%type DEFAULT NULL,
     pCAD_CGC_DS_DESCRICAO IN TB_CAD_CGC_CLASSIF_GRUPO_CONV.CAD_CGC_DS_DESCRICAO%type DEFAULT NULL,
     pCAD_CGC_DT_ULT_ATUALIZACAO IN TB_CAD_CGC_CLASSIF_GRUPO_CONV.CAD_CGC_DT_ULT_ATUALIZACAO%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_CAD_CGC_CLASSIF_GRUPO_CONV.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_CGC_CLASSIF_CONV_L
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
  IF pCAD_CGC_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_CGC_ID = ' || pCAD_CGC_ID; END IF;
IF pCAD_CGC_DS_DESCRICAO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_CGC_DS_DESCRICAO = ' || CHR(39) || pCAD_CGC_DS_DESCRICAO || CHR(39); END IF;
IF pCAD_CGC_DT_ULT_ATUALIZACAO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_CGC_DT_ULT_ATUALIZACAO = ' || CHR(39) || pCAD_CGC_DT_ULT_ATUALIZACAO || CHR(39); END IF;
IF pSEG_USU_ID_USUARIO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_USU_ID_USUARIO = ' || pSEG_USU_ID_USUARIO; END IF;
 
   V_SELECT := '
SELECT	
       CAD_CGC_ID,
       CAD_CGC_DS_DESCRICAO,
       CAD_CGC_DT_ULT_ATUALIZACAO,
       SEG_USU_ID_USUARIO
FROM TB_CAD_CGC_CLASSIF_GRUPO_CONV
WHERE null is null  '    ;
       
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_CAD_CGC_CLASSIF_CONV_L;
