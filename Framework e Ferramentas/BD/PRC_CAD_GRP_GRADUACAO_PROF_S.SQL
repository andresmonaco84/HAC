

--PRC_CAD_GRP_GRADUACAO_PROF_S
create or replace procedure PRC_CAD_GRP_GRADUACAO_PROF_S 
(
     pCAD_GRP_ID IN TB_CAD_GRP_GRADUACAO_PROF.CAD_GRP_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_GRP_GRADUACAO_PROF_S
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
       CAD_GRP_ID,
       CAD_GRP_TP_CURSO,
       CAD_GRP_NM_ENTIDADE_CURSO,
       CAD_GRP_NR_ANO_CONCLUSAO,
       CAD_GRP_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_PRO_ID_PROFISSIONAL,
       CAD_PRO_FL_RECONHECIDA_MEC,
       TIS_CBO_CD_CBOS,
       CAD_PRO_FL_ESPECIALISTA,
       CAD_GRP_DT_REVALID_CURSO
FROM TB_CAD_GRP_GRADUACAO_PROF
WHERE
        CAD_GRP_ID = pCAD_GRP_ID;          
io_cursor := v_cursor;
end PRC_CAD_GRP_GRADUACAO_PROF_S;
