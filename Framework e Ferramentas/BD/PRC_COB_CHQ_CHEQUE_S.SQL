--PRC_COB_CHQ_CHEQUE_S
create or replace procedure PRC_COB_CHQ_CHEQUE_S 
(
     pCOB_CHQ_ID IN TB_COB_CHQ_CHEQUE.COB_CHQ_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_COB_CHQ_CHEQUE_S
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
       COB_CHQ_ID,
       CAD_BAN_ID,
       COB_CHQ_CD_AGENCIA,
       COB_CHQ_DV_AGENCIA,
       COB_CHQ_NR_CONTA,
       COB_CHQ_DV_CONTA,
       COB_CHQ_NR_CHEQUE,
       CAD_PES_ID_PESSOA,
       COB_CHQ_DT_CHEQUE,
       COB_CHQ_VL_CHEQUE,
       COB_CHQ_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       COB_CHQ_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO_ATUALIZ,
       COB_SCH_ID
FROM TB_COB_CHQ_CHEQUE
WHERE
        COB_CHQ_ID = pCOB_CHQ_ID;          
io_cursor := v_cursor;
end PRC_COB_CHQ_CHEQUE_S;
/
