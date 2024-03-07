create or replace procedure PRC_CAD_CFM_ESPEC_CFM_L 
(
     pCAD_CFM_ID_CFM IN TB_CAD_CFM_ESPEC_CFM.CAD_CFM_ID_CFM%type DEFAULT NULL,
     pCAD_CFM_DS_ESPECIALIDADE IN TB_CAD_CFM_ESPEC_CFM.CAD_CFM_DS_ESPECIALIDADE%type DEFAULT NULL,
     pCAD_CFM_DT_ULTIMA_ATUALIZACAO IN TB_CAD_CFM_ESPEC_CFM.CAD_CFM_DT_ULTIMA_ATUALIZACAO%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_CAD_CFM_ESPEC_CFM.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_CFM_ESPEC_CFM_L
* 
*    Data Criacao: 	11/04/2012   Por: Andr�
*
*    Funcao: Lista Especialidade CFM
*
*******************************************************************/
 v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(5000);
  V_SELECT  varchar2(5000);
begin
  V_WHERE := NULL;
  IF pCAD_CFM_ID_CFM IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_CFM_ID_CFM = ' || pCAD_CFM_ID_CFM; END IF;
IF pCAD_CFM_DS_ESPECIALIDADE IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_CFM_DS_ESPECIALIDADE = ' || CHR(39) || pCAD_CFM_DS_ESPECIALIDADE || CHR(39); END IF;
IF pCAD_CFM_DT_ULTIMA_ATUALIZACAO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_CFM_DT_ULTIMA_ATUALIZACAO = ' || CHR(39) || pCAD_CFM_DT_ULTIMA_ATUALIZACAO || CHR(39); END IF;
IF pSEG_USU_ID_USUARIO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_USU_ID_USUARIO = ' || pSEG_USU_ID_USUARIO; END IF;
 
   V_SELECT := '
SELECT	
       CAD_CFM_ID_CFM,
       CAD_CFM_DS_ESPECIALIDADE,
       CAD_CFM_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
FROM TB_CAD_CFM_ESPEC_CFM
WHERE null is null  '    ;
       
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_CAD_CFM_ESPEC_CFM_L;