
--PRC_SEG_MPF_MODULO_PERFIL_R_L

create or replace procedure PRC_SEG_MPF_MODULO_PERFIL_R_L 
(
     pSEG_PER_ID_PERFIL IN TB_SEG_MPF_MODULO_PERFIL.SEG_PER_ID_PERFIL%type DEFAULT NULL,
     pSEG_MOD_ID_MODULO IN TB_SEG_MPF_MODULO_PERFIL.SEG_MOD_ID_MODULO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_SEG_MPF_MODULO_PERFIL_R_L
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
  IF pSEG_PER_ID_PERFIL IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_PER_ID_PERFIL = ' || pSEG_PER_ID_PERFIL; END IF;
IF pSEG_MOD_ID_MODULO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_MOD_ID_MODULO = ' || pSEG_MOD_ID_MODULO; END IF;
 
   V_SELECT := '
SELECT	
       SEG_PER_ID_PERFIL,
       SEG_MOD_ID_MODULO
FROM TB_SEG_MPF_MODULO_PERFIL
WHERE null is null  '    ;
       
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_SEG_MPF_MODULO_PERFIL_R_L;
