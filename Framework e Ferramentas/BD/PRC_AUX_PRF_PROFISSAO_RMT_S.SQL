  --PRC_AUX_PRF_PROFISSAO_RMT_S

create or replace procedure PRC_AUX_PRF_PROFISSAO_RMT_S 
(
     pAUX_PRF_CD_CODIGO IN TB_AUX_PRF_PROFISSAO.AUX_PRF_CD_CODIGO%type DEFAULT NULL,
     pAUX_PRF_DS_DESCRICAO IN TB_AUX_PRF_PROFISSAO.AUX_PRF_DS_DESCRICAO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_AUX_PRF_PROFISSAO_RMT_S
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
  IF pAUX_PRF_CD_CODIGO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND AUX_PRF_CD_CODIGO = ' || pAUX_PRF_CD_CODIGO; END IF;
IF pAUX_PRF_DS_DESCRICAO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND AUX_PRF_DS_DESCRICAO = ' || CHR(39) || pAUX_PRF_DS_DESCRICAO || CHR(39); END IF;
 
   V_SELECT := '
SELECT	
       AUX_PRF_CD_CODIGO,
       AUX_PRF_DS_DESCRICAO
FROM TB_AUX_PRF_PROFISSAO
WHERE null is null  '    ;
       
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_AUX_PRF_PROFISSAO_RMT_S;
