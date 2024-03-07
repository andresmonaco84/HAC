create or replace procedure PRC_AGE_AGD_ATUALIZA_FALTAS_U is
  /********************************************************************
  *    Procedure: PRC_AGE_AGD_ATUALIZA_FALTAS_U
  * 
  *    Data Criacao:  06/10/2009   Por: Cristiane Gomes da Silva
  *    Funcao: Atualizar faltas de atendimentos agendados
  *
  *    Data Alteracao:  03/09/2014   Por: Cristiane Gomes
  *    Alteracao: Tratar periodo de falta integral do profissional
  *
  *******************************************************************/
  v_error_code    number;
  v_error_message varchar2(900);
  v_contador      number;
begin
  v_contador := 0;
  FOR I IN (SELECT AGD.AGE_AGD_ID
              FROM TB_AGE_AGD_AGENDA        AGD,
                   TB_AGE_ESM_ESCALA_MEDICA ESM,
                   TB_CAD_UNI_UNIDADE       UNI
             WHERE AGD.AGE_AGD_FL_STATUS = 'P'
               AND AGD.AGE_ESM_ID = ESM.AGE_ESM_ID
               AND ESM.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
               AND UNI.CAD_UNI_FL_GRAVA_ATEND_OK = 'S'
               AND TRUNC(AGD.AGE_AGD_DT_ATENDIMENTO) < TRUNC(SYSDATE)
               AND AGD.AGE_AGD_CD_INTAMB IS NOT NULL
               AND NOT EXISTS
             (SELECT ATE.ATD_ATE_ID
                      FROM TB_ATD_ATE_ATENDIMENTO ATE,
                           TB_CAD_UNI_UNIDADE     UNI,
                           TB_AGE_AGD_AGENDA      AGD2
                     WHERE ATE.ATD_ATE_ID = AGD2.AGE_AGD_CD_INTAMB
                       AND ATE.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
                       AND TRUNC(AGD2.AGE_AGD_DT_ATENDIMENTO) <
                           TRUNC(SYSDATE)
                       AND AGD2.AGE_AGD_ID = AGD.AGE_AGD_ID
                       AND ATE.ATD_ATE_TP_PACIENTE = 'A'
                       AND UNI.CAD_UNI_FL_GRAVA_ATEND_OK = 'S')
               AND NOT EXISTS
             (SELECT PAA.CODATEAMB
                      FROM PACIENTE_ATENDIMENTO_AMB PAA,
                           TB_AGE_AGD_AGENDA        AGD2
                     WHERE PAA.CODATEAMB = AGD.AGE_AGD_CD_INTAMB
                       AND TRUNC(AGD2.AGE_AGD_DT_ATENDIMENTO) <
                           TRUNC(SYSDATE)
                       AND AGD2.AGE_AGD_ID = AGD.AGE_AGD_ID
                       AND PAA.CODSITATE != 'P'
                       AND CODUNIHOS NOT IN (17))
               AND NOT EXISTS
             (SELECT AGD2.AGE_AGD_ID
                      FROM TB_AGE_AGD_AGENDA        AGD2,
                           TB_AGE_ESM_ESCALA_MEDICA ESM,
                           TB_AGE_ESF_ESCALA_FALTAS ESF
                     WHERE AGD2.AGE_ESM_ID = ESM.AGE_ESM_ID
                       AND ESF.AGE_ESM_ID = ESM.AGE_ESM_ID
                       AND AGD2.AGE_AGD_ID = AGD.AGE_AGD_ID
                       AND AGD2.AGE_AGD_DT_ATENDIMENTO BETWEEN
                           ESF.AGE_ESF_DT_INI_FALTA AND
                           ESF.AGE_ESF_DT_FIM_FALTA
                       AND (AGD2.AGE_AGD_HR_ATENDIMENTO BETWEEN
                           ESF.AGE_ESF_HR_INI_FALTA AND
                           ESF.AGE_ESF_HR_FIM_FALTA OR
                           (ESF.AGE_ESF_HR_INI_FALTA IS NULL AND
                           ESF.AGE_ESF_HR_FIM_FALTA IS NULL))
                       AND (ESF.AGE_ESF_FL_SUBSTITUTO_OK = 'N' OR
                           ESF.AGE_ESF_FL_SUBSTITUTO_OK IS NULL))) LOOP
    UPDATE TB_AGE_AGD_AGENDA AGD
       SET AGD.AGE_AGD_FL_STATUS             = 'F',
           AGD.AGE_AGD_DT_ULTIMA_ATUALIZACAO = sysdate
     WHERE AGD.AGE_AGD_ID = I.AGE_AGD_ID;
     V_CONTADOR := V_CONTADOR + 1;
    IF V_CONTADOR = 100 THEN
      COMMIT;
      V_CONTADOR := 0;
    END IF;
  END LOOP;
  COMMIT;
EXCEPTION
  WHEN OTHERS THEN
    v_error_code    := SQLCODE;
    v_error_message := SQLERRM;
    raise_application_error(v_error_code, v_error_message);
  
end PRC_AGE_AGD_ATUALIZA_FALTAS_U;
/
