create or replace procedure PRC_COB_CCP_CONTA_CONS_PARC_D
(
     pFAT_NOF_ID IN TB_COB_CCP_CONTA_CONS_PARC.FAT_NOF_ID%type
)
is
/********************************************************************
*    Procedure: PRC_COB_CCP_CONTA_CONS_PARC_D
*
*    Data Criacao:   data da  cria??o   Por: Nome do Analista
*    Data Alteracao:  data da altera??o  Por: Nome do Analista
*
*    Funcao: Descri??o da funcionalidade da Stored Procedure
*
*******************************************************************/
begin
DELETE TB_COB_CCP_CONTA_CONS_PARC
WHERE  FAT_NOF_ID = pFAT_NOF_ID;
end PRC_COB_CCP_CONTA_CONS_PARC_D;
