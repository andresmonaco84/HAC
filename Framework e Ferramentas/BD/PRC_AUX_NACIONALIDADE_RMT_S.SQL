  --PRC_AUX_NACIONALIDADE_RMT_S

create or replace procedure PRC_AUX_NACIONALIDADE_RMT_S 
(
     pAUX_NAC_CD_CODIGO IN TB_AUX_NAC_NACIONALIDADE.AUX_NAC_CD_CODIGO%type DEFAULT NULL,
     pAUX_NAC_NM_NOME IN TB_AUX_NAC_NACIONALIDADE.AUX_NAC_NM_NOME%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_AUX_NACIONALIDADE_RMT_S
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
  IF pAUX_NAC_CD_CODIGO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND AUX_NAC_CD_CODIGO = ' || pAUX_NAC_CD_CODIGO; END IF;
IF pAUX_NAC_NM_NOME IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND AUX_NAC_NM_NOME = ' || CHR(39) || pAUX_NAC_NM_NOME || CHR(39); END IF;
 
   V_SELECT := '
SELECT	
       AUX_NAC_CD_CODIGO,
       AUX_NAC_NM_NOME
FROM TB_AUX_NAC_NACIONALIDADE
WHERE null is null  '    ;
       
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_AUX_NACIONALIDADE_RMT_S;
