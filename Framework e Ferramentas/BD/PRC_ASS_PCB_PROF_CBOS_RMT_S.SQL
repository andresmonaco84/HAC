CREATE OR REPLACE PROCEDURE PRC_ASS_PCB_PROF_CBOS_RMT_S
(
     pCAD_PRO_ID_PROFISSIONAL IN TB_ASS_PCB_PROFISSIONAL_CBOS.CAD_PRO_ID_PROFISSIONAL%type,
     pTIS_CBO_CD_CBOS IN TB_ASS_PCB_PROFISSIONAL_CBOS.TIS_CBO_CD_CBOS%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ASS_PCB_PROF_CBOS_RMT_S
*
*    Data Criacao:  15/07/2010   Por: André Souza Monaco
*    Data Alteracao:   Por:
*
*    Funcao: Obtem especialidade do profissional
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT
       ASS_PCB_DS_OBS,
       ASS_PCB_FL_STATUS,
       TIS_CBO_CD_CBOS,
       CAD_PRO_ID_PROFISSIONAL,
       SEG_USU_ID_USUARIO,
       ASS_PCB_DT_ULTIMA_ATUALIZACAO,
       ASS_PCB_FL_ESPECIALISTA,
       CAD_CFM_ID_CFM
FROM TB_ASS_PCB_PROFISSIONAL_CBOS
WHERE
        CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL
    AND TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS;
io_cursor := v_cursor;
end PRC_ASS_PCB_PROF_CBOS_RMT_S;
 
