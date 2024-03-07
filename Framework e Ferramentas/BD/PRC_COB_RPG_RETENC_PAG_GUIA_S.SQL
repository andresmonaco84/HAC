--PRC_COB_RPG_RETENCAO_PAGTO_GUIA_S
create or replace procedure PRC_COB_RPG_RETENC_PAG_GUIA_S 
(
     pCOB_RPG_ID IN TB_COB_RPG_RETENCAO_PAGTO_GUIA.COB_RPG_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_COB_RPG_RETENCAO_PAGTO_GUIA_S
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT	
       COB_RPG_ID,
       COB_PAG_ID,
       ASS_CUI_ID,
       COB_RPG_VL_RETENCAO,
       COB_RPG_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       COB_RPG_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO_ATUALIZ
FROM TB_COB_RPG_RETENCAO_PAGTO_GUIA
WHERE
        COB_RPG_ID = pCOB_RPG_ID;          
io_cursor := v_cursor;
end PRC_COB_RPG_RETENC_PAG_GUIA_S;
/
