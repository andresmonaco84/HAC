

--PRC_ASS_PRE_PROF_ESP_EXAME_S
create or replace procedure PRC_ASS_PRE_PROF_ESP_EXAME_S 
(
     pASS_PRE_ID IN TB_ASS_PRE_PROF_ESP_EXAME.ASS_PRE_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ASS_PRE_PROF_ESP_EXAME_S
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
       ASS_PRE_ID,
       CAD_PRO_ID_PROFISSIONAL,
       AUX_EPP_CD_ESPECPROC,
       AUX_GPC_GRUPOPROC,
       ASS_PRE_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       TIS_MED_CD_TABELAMEDICA,
       ASS_PRE_FL_ATIVO
FROM TB_ASS_PRE_PROF_ESP_EXAME
WHERE
        ASS_PRE_ID = pASS_PRE_ID;          
io_cursor := v_cursor;
end PRC_ASS_PRE_PROF_ESP_EXAME_S;
