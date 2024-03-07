CREATE OR REPLACE PROCEDURE PRC_AGE_AGG_AGENDA_ULT_DT_S
(
   pAGE_ESM_ID IN TB_AGE_AGG_AGENDA_GERADA.AGE_ESM_ID%TYPE,
   pNewIdt     OUT DATE
)
IS
 /********************************************************************
  *    Procedure: PRC_AGE_AGG_AGENDA_ULT_DT_S
  *
  *    Data Criacao:   17/12/2008   Por: Fabíola Lopes
  *    Alteração:
  *
  *    Funcao: Lista a última data da agenda gerada
  *
  *******************************************************************/
lIdtRetorno DATE;

BEGIN
   
   lIdtRetorno := NULL;
   
   SELECT DISTINCT max(agg.age_agg_dt_agenda)
     INTO lIdtRetorno
     FROM tb_age_agg_agenda_gerada agg
    WHERE agg.age_esm_id = pAGE_ESM_ID;

   pNewIdt := lIdtRetorno;

   EXCEPTION
     WHEN OTHERS THEN
       pNewIdt := NULL;
END;
/
