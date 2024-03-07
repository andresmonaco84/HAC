create or replace PROCEDURE     "PRC_INATIVACOES_SGS_U" is
  /********************************************************************
  *    Procedure: PRC_INATIVACOES_SGS_U
  *
  *    Data Criacao:  30/09/2009   Por: Cristiane Gomes da Silva
  *    Funcao: Inativacoes SGS em geral
  *
  *    Data Alteracao: 30/1/2012   Por: Cristiane Gomes
  *    Alteracao: Inclusao da inativacao das escalas de exames vencidas
  *
  *    Data Alteracao: 16/04/2012   Por: Pedro
  *    Alteracao: ocorria erro no update da TB_AGE_ESM_ESCALA_MEDICA - IND_01
  *
  *    Data Alteracao: 29/01/2013   Por: Davi S. M. dos Reis
  *    Alteracao: exclusao dos feriados das agendas geradas (quando nao houver agendamento)
  *******************************************************************/
  v_error_code    number;
  v_error_message varchar2(900);
begin
  BEGIN
    -- INATIVACAO DE ESCALAS MEDICAS
     FOR ESCALAS IN
      ( SELECT ESM.AGE_ESM_ID, ESM.AGE_SAU_ID, ESM.AGE_ESM_DT_INI_ESCALA, ESM.AGE_ESM_NR_DIA_SEMANA, ESM.CAD_PRO_ID_PROFISSIONAL,
               ESM.CAD_UNI_ID_UNIDADE, ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO, ESM.AGE_PEE_ID, ESM.TIS_CBO_CD_CBOS, ESM.AGE_ESM_FL_SITUACAO
          FROM TB_AGE_ESM_ESCALA_MEDICA ESM
         WHERE ESM.AGE_ESM_DT_FIM_ESCALA IS NOT NULL
           AND TRUNC(ESM.AGE_ESM_DT_FIM_ESCALA) < TRUNC(SYSDATE)
           AND ESM.AGE_ESM_FL_SITUACAO = 'A'
       )
    LOOP
       BEGIN
        UPDATE TB_AGE_ESM_ESCALA_MEDICA ESM
           SET ESM.AGE_ESM_FL_SITUACAO = 'I', ESM.AGE_ESM_DT_ULTIMA_ATUALIZACAO = SYSDATE
         WHERE ESM.AGE_ESM_ID = ESCALAS.AGE_ESM_ID;
       EXCEPTION
          WHEN DUP_VAL_ON_INDEX THEN
              BEGIN
                UPDATE TB_AGE_ESM_ESCALA_MEDICA ESM
                   SET ESM.AGE_ESM_FL_SITUACAO = 'E', ESM.AGE_ESM_DT_ULTIMA_ATUALIZACAO = SYSDATE
                 WHERE ESM.AGE_ESM_ID = ESCALAS.AGE_ESM_ID;
                 EXCEPTION
                       WHEN DUP_VAL_ON_INDEX THEN
                        UPDATE TB_AGE_ESM_ESCALA_MEDICA ESM
                         SET ESM.AGE_ESM_DT_INI_ESCALA = ESM.AGE_ESM_DT_INI_ESCALA -1 , ESM.AGE_ESM_DT_ULTIMA_ATUALIZACAO = SYSDATE
                       WHERE ESM.AGE_ESM_ID = ESCALAS.AGE_ESM_ID;
                 END;
       END;
    END LOOP;
    COMMIT;
  EXCEPTION
   -- WHEN DUP_VAL_ON_INDEX THEN
  --    NULL;
    WHEN OTHERS THEN
      v_error_code    := -20000;
      v_error_message := SQLERRM;
      raise_application_error(v_error_code, 'INATIVACAO DE ESCALAS MEDICAS - ' || v_error_message);
  END;
  BEGIN
    -- INATIVACAO DE PLANOS
    UPDATE TB_CAD_PLA_PLANO PLA
       SET PLA.CAD_PLA_FL_SITUACAO_PLANO = 'I'
     WHERE PLA.CAD_PLA_DT_FIM_VIGENCIA IS NOT NULL
       AND TRUNC(PLA.CAD_PLA_DT_FIM_VIGENCIA) < TRUNC(SYSDATE)
       AND PLA.CAD_PLA_FL_SITUACAO_PLANO = 'A';
    COMMIT;
  EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
      NULL;
    WHEN OTHERS THEN
      v_error_code    := -20000;
      v_error_message := SQLERRM;
      raise_application_error(v_error_code,  'INATIVACAO DE PLANOS - ' || v_error_message);
  END;
  BEGIN
    -- INATIVACAO DE CONVENIOS
    UPDATE TB_CAD_CNV_CONVENIO CNV
       SET CNV.CAD_CNV_FL_STATUS = 'I'
     WHERE CNV.CAD_CNV_DT_FIM_VIGENCIA IS NOT NULL
       AND TRUNC(CNV.CAD_CNV_DT_FIM_VIGENCIA) < TRUNC(SYSDATE)
       AND CNV.CAD_CNV_FL_STATUS = 'A';
    COMMIT;
  EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
      NULL;
    WHEN OTHERS THEN
      v_error_code    := -20000;
      v_error_message := SQLERRM;
      raise_application_error(v_error_code,  'INATIVACAO DE CONVENIOS - ' || v_error_message);
  END;
  BEGIN
    -- INATIVACAO DE CLINICA CREDENCIADA
    UPDATE TB_CAD_CLC_CLINICA_CREDENCIADA CLC
       SET CLC.CAD_CLC_FL_STATUS = 'I'
     WHERE CLC.CAD_CLC_DT_FIM_VIGENCIA IS NOT NULL
       AND TRUNC(CLC.CAD_CLC_DT_FIM_VIGENCIA) < TRUNC(SYSDATE)
       AND CLC.CAD_CLC_FL_STATUS = 'A';
    COMMIT;
  EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
      NULL;
    WHEN OTHERS THEN
      v_error_code    := -20000;
      v_error_message := SQLERRM;
      raise_application_error(v_error_code,  'INATIVACAO DE CLINICA CREDENCIADA - ' || v_error_message);
  END;
  --
  BEGIN
    -- INATIVACAO DE ESCALAS EXAMES
    UPDATE TB_AGS_ESM_ESCALA_SADT ESM
       SET ESM.AGS_ESM_FL_STATUS = 'I'
     WHERE ESM.AGS_ESM_DT_FIM_ESCALA IS NOT NULL
       AND TRUNC(ESM.AGS_ESM_DT_FIM_ESCALA) < TRUNC(SYSDATE)
       AND ESM.AGS_ESM_FL_STATUS = 'A';
    COMMIT;
  EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
      NULL;
    WHEN OTHERS THEN
      v_error_code    := -20000;
      v_error_message := SQLERRM;
      raise_application_error(v_error_code, 'INATIVACAO DE ESCALAS DE EXAMES - ' || v_error_message);
  END;
  --
  BEGIN
    -- EXCLUSAO DAS DATAS DE AGENDA GERADA EM FERIADOS (QUE AINDA NAO ESTEJAM AGENDADAS)
    DELETE FROM TB_AGE_AGG_AGENDA_GERADA 
     WHERE AGE_AGG_ID IN (
    SELECT AGG.AGE_AGG_ID FROM TB_AGE_AGG_AGENDA_GERADA AGG
     INNER JOIN TB_AGE_ESM_ESCALA_MEDICA ESM
        ON ESM.AGE_ESM_ID = AGG.AGE_ESM_ID
        AND ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO != 28        
     WHERE AGG.AGE_AGG_DT_AGENDA > TRUNC(SYSDATE)
       AND AGG.AGE_AGG_DT_AGENDA IN (SELECT FER.CAD_FER_DT_FERIADO  
                                       FROM TB_CAD_FER_FERIADO FER
                                      WHERE FER.CAD_FER_DT_FERIADO > TRUNC(SYSDATE)
                                         AND (FER.CAD_FER_TP_FERIADO IN ('F', 'E') 
                                               OR FER.CAD_FER_TP_FERIADO = 'M')
                                              AND FER.CAD_UNI_ID_UNIDADE = ESM.CAD_UNI_ID_UNIDADE)
       AND AGG.AGE_AGG_ID NOT IN (SELECT AGD.AGE_AGG_ID 
                                     FROM TB_AGE_AGD_AGENDA AGD
                                    WHERE AGD.AGE_ESM_ID = ESM.AGE_ESM_ID));
  EXCEPTION
    WHEN OTHERS THEN
      v_error_code    := -20000;
      v_error_message := SQLERRM;
      raise_application_error(v_error_code,  'EXCLUSAO DE FERIADOS DE AGENDAS GERADAS - ' || v_error_message);
  END;
  --  
EXCEPTION
  WHEN OTHERS THEN
    v_error_code    := SQLCODE;
    v_error_message := SQLERRM;
    raise_application_error(v_error_code, v_error_message);
END PRC_INATIVACOES_SGS_U;