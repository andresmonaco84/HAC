--PRC_ASS_RPG_REGRA_PAGTO_S
create or replace procedure PRC_ASS_RPG_REGRA_PAGTO_S 
(
     pASS_RPG_ID IN TB_ASS_RPG_REGRA_PAGTO.ASS_RPG_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ASS_RPG_REGRA_PAGTO_S
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
       ASS_CPR_ID,
       CAD_REP_ID,
       CAD_REP_DT_INICIO_VIGENCIA,
       CAD_REP_DT_FIM_VIGENCIA,
       SEG_USU_ID_USUARIO,
       CAD_REP_DT_ULTIMA_ATUALIZACAO,
       ASS_RPG_ID
FROM TB_ASS_RPG_REGRA_PAGTO
WHERE
        ASS_RPG_ID = pASS_RPG_ID;          
io_cursor := v_cursor;
end PRC_ASS_RPG_REGRA_PAGTO_S;