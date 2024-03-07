create or replace procedure PRC_ATD_EPM_EXAME_PRESC_MED_D
(
     pATD_EPM_ID IN TB_ATD_EPM_EXAME_PRESC_MED.ATD_EPM_ID%type
)
is
/********************************************************************
*    Procedure: PRC_ATD_EPM_EXAME_PRESC_MED_D
*
*    Data Criacao: 	data da  cria??o   Por: Nome do Analista
*    Data Alteracao:	data da altera??o  Por: Nome do Analista
*
*    Funcao: Descri??o da funcionalidade da Stored Procedure
*
*******************************************************************/
begin
DELETE TB_ATD_EPM_EXAME_PRESC_MED
WHERE
        ATD_EPM_ID = pATD_EPM_ID;
end PRC_ATD_EPM_EXAME_PRESC_MED_D;
