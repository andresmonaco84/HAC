create or replace procedure PRC_LEG_ATUALIZA_AGE_ATEND_U
is
  /********************************************************************
  *    Procedure: PRC_LEG_ATUALIZA_AGE_ATEND_U
  *
  *    Data Criacao:  05/10/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao: 26/10/2007   Por: Cristiane Gomes da Silva
  *
  *    Funcao: Atualizar agendas atendidas
  *
  *    Alteracao: 1) Correcao da atualizacao de agendas atendidas
  *               2) Nao sera alterado o usu�rio
  *
  *******************************************************************/
    v_error_code                 number;
    v_error_message              varchar2(900);
  begin
    UPDATE TB_AGE_AGD_AGENDA AGD
    SET    AGD.AGE_AGD_FL_STATUS = 'A',
           AGD.AGE_AGD_DT_ULTIMA_ATUALIZACAO = sysdate
    WHERE  EXISTS (SELECT PAA.CODATEAMB
                  FROM PACIENTE_ATENDIMENTO_AMB PAA
                  WHERE PAA.CODATEAMB = AGD.AGE_AGD_CD_INTAMB
                  AND AGD.AGE_AGD_IN_INTAMB = 'A'
                  AND TRUNC(PAA.DATATE) < TRUNC(sysdate)                  
                  AND PAA.CODSITATE = 'A'
                  AND AGD.AGE_AGD_FL_STATUS = 'P');
                  
    COMMIT;

    EXCEPTION
    WHEN OTHERS THEN
       v_error_code := SQLCODE;
       v_error_message := SQLERRM;
       raise_application_error(v_error_code, v_error_message);
end PRC_LEG_ATUALIZA_AGE_ATEND_U;
/
