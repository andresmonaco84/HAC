create or replace procedure PRC_ASS_ATI_ATE_INDICADOR_S
(
     pASS_ATI_ID IN TB_ASS_ATI_ATE_INDICADOR.ASS_ATI_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ASS_ATI_ATE_INDICADOR_S
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
       ASS_ATI_ID,
       CAD_IND_ID,
       ATD_ATE_ID,
       CAD_PES_ID_PESSOA,
       ATD_IDR_ID,
       SEG_USU_ID_USUARIO_C,
       ASS_ATI_DT_CRIACAO,
       SEG_USU_ID_USUARIO_A,
       ASS_ATI_DT_ULT_ATUALIZ,
       ASS_ATI_DT_RSL_INI,
       ASS_ATI_DT_RSL_FIM,
       ASS_ATI_FL_RSL,
       ASS_ATI_VL_RSL_MIN,
       ASS_ATI_VL_RSL_MAX,
       ASS_ATI_DS_RSL
FROM TB_ASS_ATI_ATE_INDICADOR
WHERE
        ASS_ATI_ID = pASS_ATI_ID;
io_cursor := v_cursor;
end PRC_ASS_ATI_ATE_INDICADOR_S;
