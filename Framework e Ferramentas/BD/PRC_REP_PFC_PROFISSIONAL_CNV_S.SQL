--PRC_REP_PFC_PROFISSIONAL_CNV_S
create or replace procedure PRC_REP_PFC_PROFISSIONAL_CNV_S 
(
     pREP_PFC_ID IN TB_REP_PFC_PROFISSIONAL_CNV.REP_PFC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_REP_PFC_PROFISSIONAL_CNV_S
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
       CAD_CNV_ID_CONVENIO,
       CAD_PRO_ID_PROFISSIONAL,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_TAP_TP_ATRIBUTO,
       SEG_USU_ID_USUARIO_CRIACAO,
       SEG_USU_ID_USUARIO_ATUA,
       REP_PFC_DT_CRIACAO,
       REP_PFC_DT_ULTIMA_ATUALIZACAO,
       CAD_CPR_TP_CREDENCIA_PROF,
       REP_PFC_PC_CONTA,
       REP_PFC_DT_INICIO_VIGENCIA,
       REP_PFC_DT_FIM_VIGENCIA,
       REP_PFC_ID
FROM TB_REP_PFC_PROFISSIONAL_CNV
WHERE
        REP_PFC_ID = pREP_PFC_ID;          
io_cursor := v_cursor;
end PRC_REP_PFC_PROFISSIONAL_CNV_S;
/
