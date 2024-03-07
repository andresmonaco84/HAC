
--PRC_SEG_MOD_MODULO_R_L
create or replace procedure PRC_SEG_MOD_MODULO_R_L 
(
     pSEG_MOD_ID_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_ID_MODULO%type DEFAULT NULL,
     pSEG_MOD_NM_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_NM_MODULO%type DEFAULT NULL,
     pSEG_MOD_DS_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_DS_MODULO%type DEFAULT NULL,
     pSEG_MOD_CD_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_CD_MODULO%type DEFAULT NULL,
     pSEG_MOD_DS_SISTEMA IN TB_SEG_MOD_MODULO.SEG_MOD_DS_SISTEMA%type DEFAULT NULL,
     pSEG_MOD_DS_VERSAO IN TB_SEG_MOD_MODULO.SEG_MOD_DS_VERSAO%type DEFAULT NULL,
     pSEG_MOD_DT_VERSAO IN TB_SEG_MOD_MODULO.SEG_MOD_DT_VERSAO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_SEG_MOD_MODULO_R_L
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
        (pSEG_MOD_ID_MODULO is null OR SEG_MOD_ID_MODULO = pSEG_MOD_ID_MODULO) AND 
        (pSEG_MOD_NM_MODULO is null OR SEG_MOD_NM_MODULO = pSEG_MOD_NM_MODULO) AND 
        (pSEG_MOD_DS_MODULO is null OR SEG_MOD_DS_MODULO = pSEG_MOD_DS_MODULO) AND 
        (pSEG_MOD_CD_MODULO is null OR SEG_MOD_CD_MODULO = pSEG_MOD_CD_MODULO) AND 
        (pSEG_MOD_DS_SISTEMA is null OR SEG_MOD_DS_SISTEMA = pSEG_MOD_DS_SISTEMA) AND 
        (pSEG_MOD_DS_VERSAO is null OR SEG_MOD_DS_VERSAO = pSEG_MOD_DS_VERSAO) AND 
        (pSEG_MOD_DT_VERSAO is null OR SEG_MOD_DT_VERSAO = pSEG_MOD_DT_VERSAO);          
io_cursor := v_cursor;
end PRC_SEG_MOD_MODULO_R_L;
