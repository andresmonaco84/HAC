
--PRC_SEG_PEU_PERMISSAO_USU_R_L
create or replace procedure PRC_SEG_PEU_PERMISSAO_USU_R_L 
(
     pSEG_PER_ID_PERFIL IN TB_SEG_PEU_PERMISSAO_USUARIO.SEG_PER_ID_PERFIL%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_SEG_PEU_PERMISSAO_USUARIO.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE IN TB_SEG_PEU_PERMISSAO_USUARIO.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     pSEG_MOD_ID_MODULO IN TB_SEG_PEU_PERMISSAO_USUARIO.SEG_MOD_ID_MODULO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_SEG_PEU_PERMISSAO_USU_R_L
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
       SEG_USU_ID_USUARIO,
       CAD_UNI_ID_UNIDADE,
       SEG_MOD_ID_MODULO
FROM TB_SEG_PEU_PERMISSAO_USUARIO
WHERE
        (pSEG_PER_ID_PERFIL is null OR SEG_PER_ID_PERFIL = pSEG_PER_ID_PERFIL) AND 
        (pSEG_USU_ID_USUARIO is null OR SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO) AND 
        (pCAD_UNI_ID_UNIDADE is null OR CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE) AND 
        (pSEG_MOD_ID_MODULO is null OR SEG_MOD_ID_MODULO = pSEG_MOD_ID_MODULO);          
io_cursor := v_cursor;
end PRC_SEG_PEU_PERMISSAO_USU_R_L;
