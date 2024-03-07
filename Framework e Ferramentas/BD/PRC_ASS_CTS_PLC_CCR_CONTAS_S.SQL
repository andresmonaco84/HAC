create or replace procedure PRC_ASS_CTS_PLC_CCR_CONTAS_S
(
     pASS_CTS_CCR_ID IN TB_ASS_CTS_PLC_CCR_CONTAS.ASS_CTS_CCR_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ASS_CTS_PLC_CCR_CONTAS_PRC_S
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
       ASS_CTS_CCR_ID,
       CAD_CTS_PLC_ID,
       CAD_CCR_ID,
       ASS_CTS_PLC_CCR_FL_STATUS,
       SEG_USU_ID_INCLUSAO,
       ASS_CTS_PLC_CCR_DT_INCLUSAO,
       SEG_USU_ID_ALTERACAO,
       ASS_CTS_PLC_CCR_DT_ALTERACAO,
       ASS_TIPO_CONTA,
       CAD_CEC_CD_GRUPOCCUSTO,
       CAD_CTS_PLC_ID_PARA,
       CAD_CEC_ID_CCUSTO,
       CAD_CLC_CT_EMPRESA,
       CAD_CCR_ID_GRUPO,
       CAD_UNI_ID_UNIDADE,
       CAD_CTS_PLC_CCR_DS_OBSERVACAO
FROM TB_ASS_CTS_PLC_CCR_CONTAS
WHERE
        ASS_CTS_CCR_ID = pASS_CTS_CCR_ID;
io_cursor := v_cursor;
end PRC_ASS_CTS_PLC_CCR_CONTAS_S;
