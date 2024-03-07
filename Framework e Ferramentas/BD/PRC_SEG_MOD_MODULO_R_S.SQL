
--PRC_SEG_MOD_MODULO_R_S
create or replace procedure PRC_SEG_MOD_MODULO_R_S 
(
     pSEG_MOD_ID_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_ID_MODULO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_SEG_MOD_MODULO_R_S
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
       SEG_MOD_ID_MODULO,
       SEG_MOD_NM_MODULO,
       SEG_MOD_DS_MODULO,
       SEG_MOD_CD_MODULO,
       SEG_MOD_DS_SISTEMA,
       SEG_MOD_DS_VERSAO,
       SEG_MOD_DT_VERSAO
FROM TB_SEG_MOD_MODULO
WHERE
        SEG_MOD_ID_MODULO = pSEG_MOD_ID_MODULO;          
io_cursor := v_cursor;
end PRC_SEG_MOD_MODULO_R_S;
