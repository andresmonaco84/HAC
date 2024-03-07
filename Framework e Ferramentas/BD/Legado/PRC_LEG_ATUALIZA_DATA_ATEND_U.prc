create or replace procedure PRC_LEG_ATUALIZA_DATA_ATEND_U
(
  pCODATEAMB IN PACIENTE_ATENDIMENTO_AMB.CODATEAMB%TYPE,
  pDATATE    IN PACIENTE_ATENDIMENTO_AMB.DATATE%TYPE,
  pHORATE    IN PACIENTE_ATENDIMENTO_AMB.HORATE%TYPE
)
is
  /********************************************************************
  *    Procedure: PRC_LEG_ATUALIZA_DATA_ATEND_U
  *
  *    Data Criacao:  22/11/2007   Por: Andrea Cazuca
  *
  *    Funcao: Atualiza data e hora em razão da transferência de paciente
  *
  *******************************************************************/
   begin
    UPDATE PACIENTE_ATENDIMENTO_AMB
    SET    DATATE = pDATATE,
           HORATE = pHORATE
    WHERE  CODATEAMB = pCODATEAMB;

end PRC_LEG_ATUALIZA_DATA_ATEND_U;
/
