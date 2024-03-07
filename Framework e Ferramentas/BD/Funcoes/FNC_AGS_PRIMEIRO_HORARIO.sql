create or replace function FNC_AGS_PRIMEIRO_HORARIO
(
 pLIB_PRD_ID in TB_AGS_AGE_AGENDA_SADT.LIB_PRD_ID%TYPE,
 pAGS_AGE_DT_ATENDIMENTO IN TB_AGS_AGE_AGENDA_SADT.AGS_AGE_DT_ATENDIMENTO%TYPE,
 pCAD_PRD_ID IN TB_AGS_AGE_AGENDA_SADT.CAD_PRD_ID%TYPE,
 pCANCELADO VARCHAR default null
)
--------------------------------------------------------------
-- DT. 06/07/2010   por: PEDRO
-- RETORNA O PRIMEIRO HORARIO DO AGENDAMENTO
--
--------------------------------------------------------------
return NUMBER is Result NUMBER;
begin
IF pCANCELADO IS NULL THEN
              SELECT AGS1.AGS_AGE_HR_ATENDIMENTO INTO RESULT
              FROM   TB_AGS_AGE_AGENDA_SADT AGS1
              WHERE
                     AGS1.AGS_AGE_DT_ATENDIMENTO = pAGS_AGE_DT_ATENDIMENTO
                 AND AGS1.LIB_PRD_ID = pLIB_PRD_ID
                 AND AGS1.CAD_PRD_ID = pCAD_PRD_ID
                 AND ROWNUM = 1
              ORDER BY AGS1.AGS_AGE_HR_ATENDIMENTO
              ;
 ELSE
              SELECT AGC.AGS_AGE_HR_ATENDIMENTO INTO RESULT
              FROM   TB_AGS_AGC_AGENDA_CANC_SADT AGC
              WHERE
                     AGC.AGS_AGE_DT_ATENDIMENTO = pAGS_AGE_DT_ATENDIMENTO
                 AND AGC.LIB_LPR_ID = pLIB_PRD_ID
                 AND AGC.CAD_PRD_ID = pCAD_PRD_ID
                 AND ROWNUM = 1
              ORDER BY AGC.AGS_AGE_HR_ATENDIMENTO;
 END IF;
return(Result);
  
end FNC_AGS_PRIMEIRO_HORARIO;
/
