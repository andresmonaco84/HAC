

--PRC_SEG_MPF_MODULO_PERFIL_S
create or replace procedure PRC_SEG_MPF_MODULO_PERFIL_S 
(
     pSEG_MOD_ID_MODULO IN TB_SEG_MPF_MODULO_PERFIL.SEG_MOD_ID_MODULO%type,
     pSEG_PER_ID_PERFIL IN TB_SEG_MPF_MODULO_PERFIL.SEG_PER_ID_PERFIL%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_SEG_MPF_MODULO_PERFIL_S
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
       SEG_MOD_ID_MODULO
FROM TB_SEG_MPF_MODULO_PERFIL
WHERE
        SEG_MOD_ID_MODULO = pSEG_MOD_ID_MODULO
    AND SEG_PER_ID_PERFIL = pSEG_PER_ID_PERFIL;          
io_cursor := v_cursor;
end PRC_SEG_MPF_MODULO_PERFIL_S;
