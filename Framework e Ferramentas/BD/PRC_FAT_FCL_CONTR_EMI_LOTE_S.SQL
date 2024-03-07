--PRC_FAT_FCL_CONTR_EMI_LOTE_S
create or replace procedure PRC_FAT_FCL_CONTR_EMI_LOTE_S 
(
     pFAT_FCL_NR_SEQ_LOTE IN TB_FAT_FCL_CONTR_EMI_LOTE.FAT_FCL_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_FAT_FCL_CONTR_EMI_LOTE_S
* 
*    Data Criacao: 	data da  criação   Por: Pedro
*    Data Alteracao:	20/9/2010  Por: Pedro
*    Alteracao: FAT_FCL_NR_SEQ_IMPRIME
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT	
       FAT_FCL_NR_SEQ_LOTE,
       FAT_COC_ID,
       FAT_CCP_ID,
       FAT_FCL_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       ATD_ATE_ID,
       CAD_PAC_ID_PACIENTE,
       FAT_FCL_NR_SEQ_IMPRIME

FROM TB_FAT_FCL_CONTR_EMI_LOTE
WHERE
        FAT_FCL_NR_SEQ_LOTE = pFAT_FCL_NR_SEQ_LOTE;          
io_cursor := v_cursor;
end PRC_FAT_FCL_CONTR_EMI_LOTE_S;
/
