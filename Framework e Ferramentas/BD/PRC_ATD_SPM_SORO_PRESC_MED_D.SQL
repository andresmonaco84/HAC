create or replace procedure PRC_ATD_SPM_SORO_PRESC_MED_D
(
     pATD_SPM_ID IN TB_ATD_SPM_SORO_PRESC_MED.ATD_SPM_ID%type
)
is
/********************************************************************
*    Procedure: PRC_ATD_SPM_SORO_PRESC_MED_D
*
*    Data Criacao: 	data da  cria??o   Por: Nome do Analista
*    Data Alteracao:	data da altera??o  Por: Nome do Analista
*
*    Funcao: Descri??o da funcionalidade da Stored Procedure
*
*******************************************************************/
begin
DELETE TB_ATD_SPM_SORO_PRESC_MED
WHERE
        ATD_SPM_ID = pATD_SPM_ID;
end PRC_ATD_SPM_SORO_PRESC_MED_D;
