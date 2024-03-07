
--PRC_FAT_TCS_COMANDA_SET_CC_L
create or replace procedure PRC_FAT_TCS_COMANDA_SET_CC_L 
(
     pFAT_TCO_ID IN TB_FAT_TCS_COMANDA_SET_CC.FAT_TCO_ID%type DEFAULT NULL,
     pFAT_TCS_FL_STATUS IN TB_FAT_TCS_COMANDA_SET_CC.FAT_TCS_FL_STATUS%type DEFAULT NULL,
     pFAT_TCS_DT_ULTIMA_ATUALIZACAO IN TB_FAT_TCS_COMANDA_SET_CC.FAT_TCS_DT_ULTIMA_ATUALIZACAO%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_FAT_TCS_COMANDA_SET_CC.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     pCAD_SET_ID IN TB_FAT_TCS_COMANDA_SET_CC.CAD_SET_ID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_FAT_TCS_COMANDA_SET_CC_L
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
  IF pFAT_TCO_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND FAT_TCO_ID = ' || pFAT_TCO_ID; END IF;
IF pFAT_TCS_FL_STATUS IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND FAT_TCS_FL_STATUS = ' || CHR(39) || pFAT_TCS_FL_STATUS || CHR(39); END IF;
IF pFAT_TCS_DT_ULTIMA_ATUALIZACAO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND FAT_TCS_DT_ULTIMA_ATUALIZACAO = ' || CHR(39) || pFAT_TCS_DT_ULTIMA_ATUALIZACAO || CHR(39); END IF;
IF pSEG_USU_ID_USUARIO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_USU_ID_USUARIO = ' || pSEG_USU_ID_USUARIO; END IF;
IF pCAD_SET_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_ID = ' || pCAD_SET_ID; END IF;
 
   V_SELECT := '
SELECT	
       FAT_TCO_ID,
       FAT_TCS_FL_STATUS,
       FAT_TCS_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_SET_ID
FROM TB_FAT_TCS_COMANDA_SET_CC
WHERE null is null  '    ;
       
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_FAT_TCS_COMANDA_SET_CC_L;
