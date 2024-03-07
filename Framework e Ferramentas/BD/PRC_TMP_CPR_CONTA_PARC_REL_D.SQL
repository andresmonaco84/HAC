CREATE OR REPLACE PROCEDURE "PRC_TMP_CPR_CONTA_PARC_REL_D"
(
     pTMP_CPR_NR_SEQ_LOTE IN TB_TMP_CPR_CONTA_PARC_REL.TMP_CPR_NR_SEQ_LOTE%type DEFAULT NULL
)
is
/********************************************************************
*    Procedure: PRC_TMP_CPR_CONTA_PARC_REL_D
*
*    Data Criacao:  data da  criac?o   Por: Nome do Analista
*    Data Alteracao: data da alterac?o  Por: Nome do Analista
*
*    Funcao: Descric?o da funcionalidade da Stored Procedure
*
*******************************************************************/
begin
  
if(pTMP_CPR_NR_SEQ_LOTE IS NOT NULL) THEN
    DELETE TB_TMP_CPR_CONTA_PARC_REL WHERE TMP_CPR_NR_SEQ_LOTE = pTMP_CPR_NR_SEQ_LOTE;
END IF;

if(pTMP_CPR_NR_SEQ_LOTE IS NULL) THEN
    DELETE TB_TMP_CPR_CONTA_PARC_REL TMP WHERE TRUNC(TMP.TMP_CPR_DT_ULTIMA_ATUALIZACAO) = TRUNC(SYSDATE-1);
END IF;

        
end PRC_TMP_CPR_CONTA_PARC_REL_D;
 