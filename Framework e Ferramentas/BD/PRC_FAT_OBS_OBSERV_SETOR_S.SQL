

--PRC_FAT_OBS_OBSERV_SETOR_S
create or replace procedure PRC_FAT_OBS_OBSERV_SETOR_S 
(
     pFAT_OBS_ID IN TB_FAT_OBS_OBSERV_SETOR.FAT_OBS_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_FAT_OBS_OBSERV_SETOR_S
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
       FAT_OBS_ID,
       FAT_OBS_DS_OBSERVACAO,
       CAD_SET_ID_SETOR,
       FAT_OBS_FL_STATUS,
       FAT_OBS_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
FROM TB_FAT_OBS_OBSERV_SETOR
WHERE
        FAT_OBS_ID = pFAT_OBS_ID;          
io_cursor := v_cursor;
end PRC_FAT_OBS_OBSERV_SETOR_S;
