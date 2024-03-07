create or replace procedure PRC_AGE_AGD_PROF_PACIENTE
  (
      pAGE_ESM_ID IN TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_ID%type,
      pAGE_AGG_DT_AGENDA IN TB_AGE_AGG_AGENDA_GERADA.AGE_AGG_DT_AGENDA%type DEFAULT NULL,
      pRESUMO CHAR,
      io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_AGG_PROF_PACIENTE
  *
  *    Data Criacao:   29/10/2007           Por: Andrea Cazuca
  *    Funcao: Lista a Agenda Marcada do Profissional
  *
  *     Data Alteracao: 29/04/2008      Por: Fabiola Lopes
  *     Alteracao: Inclusao de um campo CODINTAMB
  *
  *********************************************************************/

  v_cursor PKG_CURSOR.t_cursor;
begin
  IF pRESUMO = 'S' THEN
     OPEN v_cursor FOR
          SELECT  distinct AGG.AGE_AGG_DT_AGENDA DATA,
                  COUNT(AGG.AGE_AGG_ID) QTD,
                  DECODE(AGG.AGE_AGG_TP_HORARIO, 1,'N',2,'E',3,'EE',4,'R',5,'SP',6,'T') TP_HORARIO,
                  AGG.AGE_AGG_FL_STATUS_HORARIO STATUS,
                  FALTA.FALTA FALTA
          FROM    TB_AGE_AGD_AGENDA AGD,
                  TB_AGE_AGG_AGENDA_GERADA AGG,
                  TB_AGE_ESM_ESCALA_MEDICA ESM,
                  (SELECT AGG.AGE_AGG_ID,
                          ESF.AGE_ESF_FL_SUBSTITUTO_OK FALTA
                   FROM   TB_AGE_AGG_AGENDA_GERADA AGG,
                          TB_AGE_ESM_ESCALA_MEDICA ESM,
                          TB_AGE_ESF_ESCALA_FALTAS ESF
                   WHERE  AGG.AGE_ESM_ID = pAGE_ESM_ID
                   AND    AGG.AGE_AGG_DT_AGENDA >= TRUNC(SYSDATE)
                   AND    AGG.AGE_AGG_FL_STATUS_HORARIO != '3'
                   AND    AGG.AGE_ESM_ID = ESM.AGE_ESM_ID
                   AND    ESM.AGE_ESM_ID = pAGE_ESM_ID
                   AND    ESM.AGE_ESM_ID = ESF.AGE_ESM_ID(+)
                   AND    AGG.AGE_AGG_DT_AGENDA BETWEEN ESF.AGE_ESF_DT_INI_FALTA AND ESF.AGE_ESF_DT_FIM_FALTA) FALTA
          WHERE   AGG.AGE_ESM_ID = pAGE_ESM_ID
          AND     AGG.AGE_AGG_DT_AGENDA >= TRUNC(SYSDATE)
          AND     AGG.AGE_AGG_FL_STATUS_HORARIO != '3'
          AND     AGG.AGE_AGG_ID = AGD.AGE_AGG_ID(+)
          AND     AGG.AGE_ESM_ID = ESM.AGE_ESM_ID
          AND     ESM.AGE_ESM_ID = pAGE_ESM_ID
          AND     AGG.AGE_AGG_ID = FALTA.AGE_AGG_ID(+)
          AND     (AGG.AGE_AGG_DT_AGENDA BETWEEN ESM.AGE_ESM_DT_INI_ESCALA AND ESM.AGE_ESM_DT_FIM_ESCALA
          OR      ESM.AGE_ESM_DT_FIM_ESCALA IS NULL)
          GROUP BY AGG.AGE_AGG_DT_AGENDA, DECODE(AGG.AGE_AGG_TP_HORARIO, 1,'N',2,'E',3,'EE',4,'R',5,'SP',6,'T'),
                   AGG.AGE_AGG_FL_STATUS_HORARIO, FALTA.FALTA
          ORDER BY AGG.AGE_AGG_DT_AGENDA, AGG.AGE_AGG_FL_STATUS_HORARIO;
  ELSE
    OPEN v_cursor FOR
         SELECT  AGG.AGE_AGG_HR_AGENDA HORAAGENDAMENTO,
                 DECODE(AGG.AGE_AGG_FL_STATUS_HORARIO,1,'LIVRE',4,'BLOQUEADO',PES.CAD_PES_NM_PESSOA) NOMEPACIENTE,
                 DECODE(AGG.AGE_AGG_TP_HORARIO, 1,'N',2,'E',3,'EE',4,'R',5,'SP',6,'T') TIPOHORARIO,
                 SAU.AGE_SAU_CD_ANDAR ANDAR,
                 FALTA.SUBSTITUTO PROFISSIONALSUBSTITUTO,
                 AGD.AGE_AGD_CD_INTAMB CODINTAMB
         FROM    TB_AGE_AGD_AGENDA AGD,
                 TB_AGE_AGG_AGENDA_GERADA AGG,
                 TB_CAD_PAC_PACIENTE PAC,
                 TB_CAD_PES_PESSOA PES,
                 TB_AGE_ESM_ESCALA_MEDICA ESM,
                 TB_AGE_SAU_SALA_UNID_AND SAU,
                 (SELECT AGG.AGE_AGG_ID,
                         DECODE(PES.CAD_PES_NM_PESSOA,NULL,NULL,PES.CAD_PES_NM_PESSOA) SUBSTITUTO,
                         ESF.AGE_ESF_FL_SUBSTITUTO_OK FALTA
                  FROM   TB_AGE_AGG_AGENDA_GERADA AGG,
                         TB_CAD_PES_PESSOA PES,
                         TB_AGE_ESM_ESCALA_MEDICA ESM,
                         TB_AGE_ESF_ESCALA_FALTAS ESF,
                         TB_CAD_PRO_PROFISSIONAL PRO
                  WHERE  AGG.AGE_ESM_ID = pAGE_ESM_ID
                  AND    AGG.AGE_AGG_DT_AGENDA = pAGE_AGG_DT_AGENDA
                  AND    AGG.AGE_AGG_FL_STATUS_HORARIO != '3'
                  AND    AGG.AGE_ESM_ID = ESM.AGE_ESM_ID
                  AND    ESM.AGE_ESM_ID = pAGE_ESM_ID
                  AND    ESM.AGE_ESM_ID = ESF.AGE_ESM_ID(+)
                  AND    AGG.AGE_AGG_DT_AGENDA BETWEEN ESF.AGE_ESF_DT_INI_FALTA AND ESF.AGE_ESF_DT_FIM_FALTA
                  AND    ESF.CAD_PRO_ID_PROFISSIONAL_SUBST = PRO.CAD_PRO_ID_PROFISSIONAL(+)
                  AND    PRO.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA(+)) FALTA
         WHERE   AGG.AGE_ESM_ID = pAGE_ESM_ID
         AND     AGG.AGE_AGG_DT_AGENDA = pAGE_AGG_DT_AGENDA
         AND     AGG.AGE_AGG_FL_STATUS_HORARIO != '3'
         AND     AGG.AGE_AGG_ID = AGD.AGE_AGG_ID(+)
         AND     AGD.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE(+)
         AND     PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA(+)
         AND     AGG.AGE_ESM_ID = ESM.AGE_ESM_ID
         AND     ESM.AGE_ESM_ID = pAGE_ESM_ID
         AND     ESM.AGE_SAU_ID = SAU.AGE_SAU_ID
         AND     AGG.AGE_AGG_ID = FALTA.AGE_AGG_ID(+)
         AND     (FALTA.FALTA = 'S' OR FALTA.FALTA IS NULL)
         AND     (AGG.AGE_AGG_DT_AGENDA BETWEEN ESM.AGE_ESM_DT_INI_ESCALA AND ESM.AGE_ESM_DT_FIM_ESCALA
         OR      ESM.AGE_ESM_DT_FIM_ESCALA IS NULL)
         ORDER BY AGG.AGE_AGG_DT_AGENDA, AGG.AGE_AGG_HR_AGENDA;
  END IF;

  io_cursor := v_cursor;

end PRC_AGE_AGD_PROF_PACIENTE;
