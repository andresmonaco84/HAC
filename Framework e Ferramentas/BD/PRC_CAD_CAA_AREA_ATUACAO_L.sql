create or replace procedure PRC_CAD_CAA_AREA_ATUACAO_L 
(
     pCAD_CCA_ID_AREA_ATUACAO IN TB_CAD_CAA_AREA_ATUACAO.CAD_CCA_ID_AREA_ATUACAO%type DEFAULT NULL,
     pCAD_CCA_DS_AREA_ATUACAO IN TB_CAD_CAA_AREA_ATUACAO.CAD_CCA_DS_AREA_ATUACAO%type DEFAULT NULL,
     pCAD_CCA_DT_ULTIMA_ATUALIZACAO IN TB_CAD_CAA_AREA_ATUACAO.CAD_CCA_DT_ULTIMA_ATUALIZACAO%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_CAD_CAA_AREA_ATUACAO.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_CAA_AREA_ATUACAO_L
* 
*    Data Criacao: 	16/04/2012   Por: Andr�
*
*    Funcao: Lista �rea de Atua��o
*******************************************************************/
 v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(5000);
  V_SELECT  varchar2(5000);
begin
  V_WHERE := NULL;
  IF pCAD_CCA_ID_AREA_ATUACAO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_CCA_ID_AREA_ATUACAO = ' || pCAD_CCA_ID_AREA_ATUACAO; END IF;
IF pCAD_CCA_DS_AREA_ATUACAO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_CCA_DS_AREA_ATUACAO = ' || CHR(39) || pCAD_CCA_DS_AREA_ATUACAO || CHR(39); END IF;
IF pCAD_CCA_DT_ULTIMA_ATUALIZACAO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_CCA_DT_ULTIMA_ATUALIZACAO = ' || CHR(39) || pCAD_CCA_DT_ULTIMA_ATUALIZACAO || CHR(39); END IF;
IF pSEG_USU_ID_USUARIO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_USU_ID_USUARIO = ' || pSEG_USU_ID_USUARIO; END IF;
 
   V_SELECT := '
SELECT	
       CAD_CCA_ID_AREA_ATUACAO,
       CAD_CCA_DS_AREA_ATUACAO,
       CAD_CCA_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
FROM TB_CAD_CAA_AREA_ATUACAO
WHERE null is null  '    ;
       
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_CAD_CAA_AREA_ATUACAO_L;