create or replace procedure PRC_ASS_CAU_CONV_AUTORIZADOR_S
(
     pASS_CAU_ID IN TB_ASS_CAU_CONV_AUTORIZADOR.ASS_CAU_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ASS_CAU_CONV_AUTORIZADOR_S
*
*    Data Criacao:   data da  criação   Por: Nome do Analista
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT
       ASS_CAU_ID,
       CAD_CNV_ID_CONVENIO,
       CAD_AUT_ID,
       ASS_CAU_DT_INI_VIGENCIA,
       ASS_CAU_DT_FIM_VIGENCIA,
       ASS_CAU_QT_MAX_AUTORIZACAO,
       ASS_CAU_FL_STATUS,
       SEG_USU_ID_USUARIO_CRIACAO,
       ASS_CAU_DT_CRIACAO,
       SEG_USU_ID_USUARIO_ATUALIZACAO,
       ASS_CAU_DT_ULTIMA_ATUALIZACAO
FROM TB_ASS_CAU_CONV_AUTORIZADOR
WHERE
        ASS_CAU_ID = pASS_CAU_ID;
io_cursor := v_cursor;
end PRC_ASS_CAU_CONV_AUTORIZADOR_S;
/
