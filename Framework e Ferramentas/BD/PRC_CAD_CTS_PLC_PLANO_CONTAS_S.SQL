--PRC_CAD_CTS_PLC_PLANO_CONTAS_S
create or replace procedure PRC_CAD_CTS_PLC_PLANO_CONTAS_S 
(
     pCAD_CTS_PLC_ID IN TB_CAD_CTS_PLC_PLANO_CONTAS.CAD_CTS_PLC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_CTS_PLC_PLANO_CONTAS_S
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
       CAD_CTS_PLC_ID,
       CAD_CTS_CD_COLIGADA,
       CAD_CTS_CD_CONTA,
       CAD_CTS_CD_NIVEL,
       CAD_CTS_DS_DESCRICAO,
       CAD_CTS_CD_NATUREZA,
       CAD_CTS_CD_MASCARA,
       CAD_CTS_PLC_REFER_ID,
       CAD_CTS_FL_STATUS,
       CAD_CTS_DT_INATIVACAO,
       SEG_USU_ID_INCLUSAO,
       CAD_CTS_DT_INCLUSAO,
       SEG_USU_ID_ALTERACAO,
       CAD_CTS_DT_ALTERACAO,
       CAD_TAP_TP_ATRIBUTO,
       CAD_CTS_FL_RATEIO_DIRETO,
       CAD_CTS_OBSERVACAO
FROM TB_CAD_CTS_PLC_PLANO_CONTAS
WHERE
        CAD_CTS_PLC_ID = pCAD_CTS_PLC_ID;          
io_cursor := v_cursor;
end PRC_CAD_CTS_PLC_PLANO_CONTAS_S;
