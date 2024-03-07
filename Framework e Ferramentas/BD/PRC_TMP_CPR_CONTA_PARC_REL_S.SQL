

--PRC_TMP_CPR_CONTA_PARC_REL_S
create or replace procedure PRC_TMP_CPR_CONTA_PARC_REL_S 
(
     pTMP_CPR_NR_SEQ_LOTE IN TB_TMP_CPR_CONTA_PARC_REL.TMP_CPR_NR_SEQ_LOTE%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_TMP_CPR_CONTA_PARC_REL_S
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
       ATD_ATE_ID,
       CAD_PAC_ID_PACIENTE,
       FAT_CCP_ID,
       SEG_USU_ID_USUARIO,
       TMP_CPR_DT_ULTIMA_ATUALIZACAO,
       TMP_CPR_DT_INT,
       TMP_CPR_DT_ALTA,
       TMP_CPR_NR_SEQ_LOTE,
       TMP_CPR_NR_SEQ_IMPRIME,
       TMP_CPR_DT_PARCELA_INI,
       TMP_CPR_DT_PARCELA,
       TMP_CPR_MES_ANO_FAT,
       TMP_CPR_STATUS_AUDITORIA,
       TMP_CPR_FLAG_FATURADO,
       TMP_CPR_FLAG_EMITIDO,
       TMP_CPR_NR_NOTA_FISCAL,
       TMP_CPR_TP_SERIE_FISCAL
FROM TB_TMP_CPR_CONTA_PARC_REL
WHERE
        TMP_CPR_NR_SEQ_LOTE = pTMP_CPR_NR_SEQ_LOTE;          
io_cursor := v_cursor;
end PRC_TMP_CPR_CONTA_PARC_REL_S;
