--PRC_COB_DCH_DEVOLUCAO_CHEQUE_S
create or replace procedure PRC_COB_DCH_DEVOLUCAO_CHEQUE_S 
(
     pCOB_DCH_ID IN TB_COB_DCH_DEVOLUCAO_CHEQUE.COB_DCH_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_COB_DCH_DEVOLUCAO_CHEQUE_S
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
       COB_DCH_ID,
       COB_CHQ_ID,
       COB_DCH_DT_DEVOLUCAO,
       CAD_MDC_ID,
       COB_DCH_DT_REAPRESENTACAO,
       ASS_BCT_ID,
       COB_DCH_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       COB_DCH_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO_ATUALIZ
FROM TB_COB_DCH_DEVOLUCAO_CHEQUE
WHERE
        COB_DCH_ID = pCOB_DCH_ID;          
io_cursor := v_cursor;
end PRC_COB_DCH_DEVOLUCAO_CHEQUE_S;
/
