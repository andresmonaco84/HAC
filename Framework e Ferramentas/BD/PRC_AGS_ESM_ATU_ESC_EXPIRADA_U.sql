create or replace procedure PRC_AGS_ESM_ATU_ESC_EXPIRADA_U
is
  /********************************************************************
  *    Procedure: PRC_AGS_ESM_ATU_ESC_EXPIRADA_U
  *
  *    Data Criacao:  02/09/2008    Por: Cristiane Gomes da Silva
  *    Data Alteracao:              Por:
  *
  *    Funcao: Atualizar escalas SADT expiradas
  *
  *******************************************************************/
    v_error_code                 number;
    v_error_message              varchar2(900);
begin
  UPDATE TB_AGS_ESM_ESCALA_SADT ESM
  SET ESM.AGS_ESM_FL_STATUS = 'X'
  WHERE ESM.AGS_ESM_DT_FIM_ESCALA IS NOT NULL
  AND TRUNC(ESM.AGS_ESM_DT_FIM_ESCALA) < TRUNC(SYSDATE)
  AND ESM.AGS_ESM_FL_STATUS != 'X';
  COMMIT;
  EXCEPTION
  WHEN OTHERS THEN
     v_error_code := SQLCODE;
     v_error_message := SQLERRM;
     raise_application_error(v_error_code, v_error_message);
end PRC_AGS_ESM_ATU_ESC_EXPIRADA_U;
/
