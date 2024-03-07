
--PRC_SEG_FUN_FUNCIONALID_R_S
create or replace procedure PRC_SEG_FUN_FUNCIONALID_R_S 
(
     pSEG_FUN_ID_FUNCIONALIDADE IN TB_SEG_FUN_FUNCIONALIDADE.SEG_FUN_ID_FUNCIONALIDADE%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_SEG_FUN_FUNCIONALID_R_S
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
       SEG_FUN_ID_FUNCIONALIDADE,
       SEG_FUN_DS_DESCRICAO,
       SEG_FUN_FL_ITEM_MENU_OK,
       SEG_FUN_ID_FUNCIONALIDADE_PAI,
       SEG_FUN_DS_NOME_PAGINA,
       SEG_FUN_NM_NOME,
       SEG_MOD_ID_MODULO
FROM TB_SEG_FUN_FUNCIONALIDADE
WHERE
        SEG_FUN_ID_FUNCIONALIDADE = pSEG_FUN_ID_FUNCIONALIDADE;          
io_cursor := v_cursor;
end PRC_SEG_FUN_FUNCIONALID_R_S;

