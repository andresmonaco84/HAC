
--PRC_SEG_PER_PERFIL_R_L
create or replace procedure PRC_SEG_PER_PERFIL_R_L 
(
     pSEG_PER_ID_PERFIL IN TB_SEG_PER_PERFIL.SEG_PER_ID_PERFIL%type DEFAULT NULL,
     pSEG_PER_NM_PERFIL IN TB_SEG_PER_PERFIL.SEG_PER_NM_PERFIL%type DEFAULT NULL,
     pSEG_PER_FL_STATUS IN TB_SEG_PER_PERFIL.SEG_PER_FL_STATUS%type DEFAULT NULL,
     pSEG_PER_DT_ULTIMA_ATUALIZACAO IN TB_SEG_PER_PERFIL.SEG_PER_DT_ULTIMA_ATUALIZACAO%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_SEG_PER_PERFIL.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_SEG_PER_PERFIL_R_L
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
IF pSEG_PER_NM_PERFIL IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_PER_NM_PERFIL = ' || CHR(39) || pSEG_PER_NM_PERFIL || CHR(39); END IF;
IF pSEG_PER_FL_STATUS IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_PER_FL_STATUS = ' || CHR(39) || pSEG_PER_FL_STATUS || CHR(39); END IF;
IF pSEG_PER_DT_ULTIMA_ATUALIZACAO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_PER_DT_ULTIMA_ATUALIZACAO = ' || CHR(39) || pSEG_PER_DT_ULTIMA_ATUALIZACAO || CHR(39); END IF;
IF pSEG_USU_ID_USUARIO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_USU_ID_USUARIO = ' || pSEG_USU_ID_USUARIO; END IF;
 
   V_SELECT := '
SELECT	
       SEG_PER_ID_PERFIL,
       SEG_PER_NM_PERFIL,
       SEG_PER_FL_STATUS,
       SEG_PER_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
FROM TB_SEG_PER_PERFIL
WHERE null is null  '    ;
       
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_SEG_PER_PERFIL_R_L;
