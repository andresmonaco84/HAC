    create or replace function sgs.FNC_AGE_HORA_LIVRE

(

   pAGE_ESM_ID IN TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_ID%TYPE,

 

   pDATA_INI IN TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_DT_INI_ESCALA%TYPE,

   pDATA_FIM IN TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_DT_FIM_ESCALA%TYPE

 

)

return NUMBER is Result NUMBER;

 

 

BEGIN

 

 

 

SELECT   COUNT(AGG.AGE_AGG_HR_AGENDA) into Result

             FROM TB_AGE_AGG_AGENDA_GERADA AGG,

                  TB_AGE_ESM_ESCALA_MEDICA ESM

           WHERE AGG.AGE_AGG_DT_AGENDA     BETWEEN   pDATA_INI  AND  pDATA_FIM

           AND AGG.AGE_AGG_FL_STATUS_HORARIO    in ( 1,4 )

           AND AGG.AGE_AGG_TP_HORARIO          !=    3

           AND AGG.AGE_ESF_ID                   IS NULL

           AND ESM.AGE_ESM_ID                   = AGG.AGE_ESM_ID

           AND ESM.AGE_ESM_ID           =  PAGE_ESM_ID

 

;

return(RESULT);

end FNC_AGE_HORA_LIVRE;