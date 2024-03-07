--PRC_SEG_UUN_USUARIO_UNID_R_L
 create or replace procedure PRC_SEG_UUN_USUARIO_UNID_R_L 
(
     pSEG_USU_ID_USUARIO IN TB_SEG_UUN_USUARIO_UNIDADE.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE IN TB_SEG_UUN_USUARIO_UNIDADE.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_SEG_UUN_USUARIO_UNID_R_L
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
  IF pSEG_USU_ID_USUARIO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_USU_ID_USUARIO = ' || pSEG_USU_ID_USUARIO; END IF;
IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE; END IF;
 
   V_SELECT := '
SELECT	
       SEG_USU_ID_USUARIO,
       CAD_UNI_ID_UNIDADE
FROM TB_SEG_UUN_USUARIO_UNIDADE
WHERE null is null  '    ;
       
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_SEG_UUN_USUARIO_UNID_R_L;
