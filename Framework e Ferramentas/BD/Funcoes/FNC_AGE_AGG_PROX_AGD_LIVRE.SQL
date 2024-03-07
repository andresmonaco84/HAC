create or replace function FNC_AGE_AGG_PROX_AGD_LIVRE
(
pCAD_PRO_ID_profissional IN tb_cad_pro_profissional.cad_pro_id_profissional%TYPE DEFAULT NULL,
pAGE_PEE_CD_PERIODO_ESCALA IN tb_age_pee_periodo_escala.age_pee_cd_periodo_escala%TYPE DEFAULT NULL,
pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
pCAD_LAT_ID_LOCAL_ATENDIMENTO IN Tb_Cad_Lat_Local_Atendimento.Cad_Lat_Id_Local_Atendimento%TYPE DEFAULT NULL,
pAGE_ESM_ID IN tb_age_esm_escala_medica.age_esm_id%TYPE DEFAULT NULL,
 pTIS_CBO_CD_CBOS IN tb_tis_cbo_cbos.tis_cbo_cd_cbos%TYPE DEFAULT NULL,
 pCOD_TIPO_HORARIO IN TB_AGE_AGG_AGENDA_GERADA.AGE_AGG_TP_HORARIO%TYPE DEFAULT NULL
)
return VARCHAR2 is
  Result VARCHAR(25);
begin
  /********************************************************************
  *    Func?o: FNC_AGE_AGG_PROX_AGD_LIVRE
  *
  *    Data Criacao:  08/11/2007   Por: Guilherme
  *
  *    Utilidade: Retornar uma string contendo a proxima agenda livre e a quantidade
  *               de dias  
  *
  *    Data Alterac?o: 17/6/2010  Por: Pedro
  *    Alterac?o: tirando feriados do resultado
  *
  *******************************************************************/
  IF pCAD_UNI_ID_UNIDADE IS NULL THEN
  IF pAGE_PEE_CD_PERIODO_ESCALA IS NOT NULL THEN
  SELECT * INTO RESULT FROM(
    SELECT
          TO_CHAR(agg.age_agg_dt_agenda,'dd/MM/yyyy')||' '||
          (substr(lpad(agg.age_agg_hr_agenda,4,'0'),1,2)||':'||substr(lpad(agg.age_agg_hr_agenda,4,'0'),3,2))||' '||
          (trunc(agg.age_agg_dt_agenda) - trunc(SYSDATE)  )proximo_horario_livre

        FROM
             tb_age_agg_agenda_gerada agg,
             tb_age_esm_escala_medica esm,
             tb_age_pee_periodo_escala pee
        WHERE
              agg.age_esm_id = esm.age_esm_id
              AND esm.cad_pro_id_profissional = pCAD_PRO_ID_profissional
        AND   trunc(agg.age_agg_dt_agenda) > trunc(SYSDATE)
        AND agg.age_agg_fl_status_horario = 1--status 1 = liberado
        AND agg.age_agg_tp_horario = pCOD_TIPO_HORARIO
        AND esm.age_pee_id = pee.age_pee_id
        AND esm.age_esm_fl_situacao = 'A'
        AND pee.age_pee_cd_periodo_escala = pAGE_PEE_CD_PERIODO_ESCALA
        AND agg.age_esf_id IS NULL
         AND NOT EXISTS
       (
           SELECT  FER.CAD_FER_DT_FERIADO
           FROM    TB_CAD_FER_FERIADO FER                  
           WHERE   FER.CAD_UNI_ID_UNIDADE = ESM.CAD_UNI_ID_UNIDADE
           AND     FER.CAD_FER_DT_FERIADO = AGG.AGE_AGG_DT_AGENDA
       )

        ORDER BY
        agg.age_agg_dt_agenda,
        agg.age_agg_hr_agenda
        )
        WHERE rownum = 1;
    return(Result);
  ELSE
     SELECT * INTO RESULT FROM(
      SELECT
            TO_CHAR(agg.age_agg_dt_agenda,'dd/MM/yyyy')||' '||
            (substr(lpad(agg.age_agg_hr_agenda,4,'0'),1,2)||':'||substr(lpad(agg.age_agg_hr_agenda,4,'0'),3,2))||' '||
            (trunc(agg.age_agg_dt_agenda) - trunc(SYSDATE)  )proximo_horario_livre

          FROM
               tb_age_agg_agenda_gerada agg,
               tb_age_esm_escala_medica esm
          WHERE
                agg.age_esm_id = esm.age_esm_id
                AND esm.cad_pro_id_profissional = pCAD_PRO_ID_profissional
          AND   trunc(agg.age_agg_dt_agenda) > trunc(SYSDATE)
          AND agg.age_agg_fl_status_horario = 1--status 1 = liberado
          AND agg.age_agg_tp_horario = pCOD_TIPO_HORARIO
          AND esm.age_esm_fl_situacao = 'A'
          AND agg.age_esf_id IS NULL
          AND NOT EXISTS
          (
           SELECT  FER.CAD_FER_DT_FERIADO
           FROM    TB_CAD_FER_FERIADO FER                  
           WHERE   FER.CAD_UNI_ID_UNIDADE = ESM.CAD_UNI_ID_UNIDADE
           AND     FER.CAD_FER_DT_FERIADO = AGG.AGE_AGG_DT_AGENDA
          )
          ORDER BY
          agg.age_agg_dt_agenda,
          agg.age_agg_hr_agenda
          )
          WHERE rownum = 1;
      return(Result);
  END IF;
ELSE
     SELECT * INTO RESULT FROM(
      SELECT
 TO_CHAR(agg.age_agg_dt_agenda,'dd/MM/yyyy')||' '||
            (substr(lpad(agg.age_agg_hr_agenda,4,'0'),1,2)||':'||substr(lpad(agg.age_agg_hr_agenda,4,'0'),3,2))||' '||
            (trunc(agg.age_agg_dt_agenda) - trunc(SYSDATE)  )proximo_horario_livre

          FROM
               tb_age_agg_agenda_gerada agg,
               tb_age_esm_escala_medica esm,
               tb_age_pee_periodo_escala pee
          WHERE
                agg.age_esm_id = esm.age_esm_id
--                AND esm.cad_pro_id_profissional = pCAD_PRO_ID_profissional
          AND   trunc(agg.age_agg_dt_agenda) > trunc(SYSDATE)
          AND agg.age_agg_fl_status_horario = 1--status 1 = liberado
          AND agg.age_agg_tp_horario = pCOD_TIPO_HORARIO
          AND esm.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE
          AND esm.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO
          AND esm.age_pee_id = pee.age_pee_id
          AND pee.age_pee_cd_periodo_escala = pAGE_PEE_CD_PERIODO_ESCALA
          AND esm.cad_pro_id_profissional = pCAD_PRO_ID_profissional
          AND ESM.Tis_Cbo_Cd_Cbos = pTIS_CBO_CD_CBOS
          AND esm.age_esm_fl_situacao = 'A'
           AND NOT EXISTS
           (
           SELECT  FER.CAD_FER_DT_FERIADO
           FROM    TB_CAD_FER_FERIADO FER                  
           WHERE   FER.CAD_UNI_ID_UNIDADE = ESM.CAD_UNI_ID_UNIDADE
           AND     FER.CAD_FER_DT_FERIADO = AGG.AGE_AGG_DT_AGENDA
           )
          AND
          (
          agg.age_esf_id IS NULL
          OR
          (agg.age_esf_id IN (SELECT esf.age_esf_id FROM tb_age_esf_escala_faltas esf WHERE esf.age_esf_id = agg.age_esf_id AND esf.cad_pro_id_profissional_subst IS NOT NULL)
          ))
          ORDER BY
          agg.age_agg_dt_agenda,
          agg.age_agg_hr_agenda
          )
          WHERE rownum = 1;
      return(Result);
END IF;
end FNC_AGE_AGG_PROX_AGD_LIVRE;
/