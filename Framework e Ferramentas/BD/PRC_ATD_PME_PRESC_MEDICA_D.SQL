create or replace procedure PRC_ATD_PME_PRESC_MEDICA_D
(
     pATD_PME_ID IN TB_ATD_PME_PRESCRICAO_MEDICA.ATD_PME_ID%type
)
is
/********************************************************************
*    Procedure: PRC_ATD_PME_PRESCRICAO_MEDICA_D
*
*    Data Criacao: 	data da  cria??o   Por: Nome do Analista
*    Data Alteracao:	data da altera??o  Por: Nome do Analista
*
*    Funcao: Descri??o da funcionalidade da Stored Procedure
*
*******************************************************************/
begin
DELETE TB_ATD_PME_PRESCRICAO_MEDICA
WHERE
        ATD_PME_ID = pATD_PME_ID;
end PRC_ATD_PME_PRESC_MEDICA_D;
