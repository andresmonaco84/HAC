create or replace procedure PRC_COB_MGC_MOV_GUIA_D
(
     pCOB_MGC_ID IN TB_COB_MGC_MOV_GUIA_COBRANCA.COB_MGC_ID%type
)
is
/********************************************************************
*    Procedure: PRC_COB_MGC_MOV_GUIA_COBRANCA_D
*
*    Data Criacao:  08/06/2012   Por: PEDRO
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
begin
DELETE TB_COB_MGC_MOV_GUIA_COBRANCA
WHERE
        COB_MGC_ID = pCOB_MGC_ID;
end PRC_COB_MGC_MOV_GUIA_D;
 