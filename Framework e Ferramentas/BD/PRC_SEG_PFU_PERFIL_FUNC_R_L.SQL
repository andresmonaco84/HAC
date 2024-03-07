
--PRC_SEG_PFU_PERFIL_FUNC_R_L
create or replace procedure PRC_SEG_PFU_PERFIL_FUNC_R_L 
(
     pSEG_PER_ID_PERFIL IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_PER_ID_PERFIL%type DEFAULT NULL,
     pSEG_MOD_ID_MODULO IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_MOD_ID_MODULO%type DEFAULT NULL,
     pSEG_FUN_ID_FUNCIONALIDADE IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_FUN_ID_FUNCIONALIDADE%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_SEG_PFU_PERFIL_FUNCIONALID_R_L
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
       SEG_PER_ID_PERFIL,
       SEG_MOD_ID_MODULO,
       SEG_FUN_ID_FUNCIONALIDADE
FROM TB_SEG_PFU_PERFIL_FUNCIONALID
WHERE
        (pSEG_PER_ID_PERFIL is null OR SEG_PER_ID_PERFIL = pSEG_PER_ID_PERFIL) AND 
        (pSEG_MOD_ID_MODULO is null OR SEG_MOD_ID_MODULO = pSEG_MOD_ID_MODULO) AND 
        (pSEG_FUN_ID_FUNCIONALIDADE is null OR SEG_FUN_ID_FUNCIONALIDADE = pSEG_FUN_ID_FUNCIONALIDADE);          
io_cursor := v_cursor;
end PRC_SEG_PFU_PERFIL_FUNC_R_L;
