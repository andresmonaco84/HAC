create or replace procedure PRC_ATD_DPM_DIETA_PRESC_MED_D
(
     pATD_DPM_ID IN TB_ATD_DPM_DIETA_PRESC_MED.ATD_DPM_ID%type
)
is
/********************************************************************
*    Procedure: PRC_ATD_DPM_DIETA_PRESC_MED_D
*
*    Data Criacao: 	data da  cria??o   Por: Nome do Analista
*    Data Alteracao:	data da altera??o  Por: Nome do Analista
*
*    Funcao: Descri??o da funcionalidade da Stored Procedure
*
*******************************************************************/
begin
DELETE TB_ATD_DPM_DIETA_PRESC_MED
WHERE
        ATD_DPM_ID = pATD_DPM_ID;
end PRC_ATD_DPM_DIETA_PRESC_MED_D;
