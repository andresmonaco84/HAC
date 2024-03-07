--PRC_CAD_MDC_MOTIVO_DEV_CHEQUE_S
create or replace procedure PRC_CAD_MDC_MOT_DEV_CHEQUE_S 
(
     pCAD_MDC_ID IN TB_CAD_MDC_MOTIVO_DEV_CHEQUE.CAD_MDC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_MDC_MOTIVO_DEV_CHEQUE_S
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
       CAD_MDC_ID,
       CAD_MDC_CD_MOTIVO_DEV_CHEQUE,
       CAD_MDC_DS_MOTIVO_DEV_CHEQUE,
       CAD_MDC_TP_CLASSIFICACAO,
       CAD_MDC_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       CAD_MDC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO_ATUALIZ
FROM TB_CAD_MDC_MOTIVO_DEV_CHEQUE
WHERE
        CAD_MDC_ID = pCAD_MDC_ID;          
io_cursor := v_cursor;
end PRC_CAD_MDC_MOT_DEV_CHEQUE_S;
/
