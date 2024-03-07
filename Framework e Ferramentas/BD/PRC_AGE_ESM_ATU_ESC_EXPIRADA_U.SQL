create or replace procedure PRC_AGE_ESM_ATU_ESC_EXPIRADA_U
is
  /********************************************************************
  *    Procedure: PRC_AGE_ESM_ATU_ESC_EXPIRADA_U
  *
  *    Data Criacao:  27/03/2008   Por: Cristiane Gomes da Silva
  *    Data Alteracao:  21/01/2009 Por: Cristiane Gomes da Silva
  *
  *    Funcao: Atualizar escalas médicas expiradas
  *
  *    Alteracao: 1) Utilizar o status 'X'
  *               2) Utilizar o status 'I', pois ainda não foi tratado
  *               pelo módulo de agendamento de consultas.
  *               3) Considerar situação diferente de 'I' e 'E'
  *******************************************************************/
    v_error_code                 number;
    v_error_message              varchar2(900);
begin
  UPDATE TB_AGE_ESM_ESCALA_MEDICA ESM
  SET ESM.AGE_ESM_FL_SITUACAO = 'I'
  WHERE ESM.AGE_ESM_DT_FIM_ESCALA IS NOT NULL
  AND TRUNC(ESM.AGE_ESM_DT_FIM_ESCALA) < TRUNC(SYSDATE)
  AND ESM.AGE_ESM_FL_SITUACAO NOT IN ('I','E');
  COMMIT;
  EXCEPTION
  WHEN DUP_VAL_ON_INDEX THEN NULL;  
  WHEN OTHERS THEN
     v_error_code := SQLCODE;
     v_error_message := SQLERRM;
     raise_application_error(v_error_code, v_error_message);
end PRC_AGE_ESM_ATU_ESC_EXPIRADA_U;
/
