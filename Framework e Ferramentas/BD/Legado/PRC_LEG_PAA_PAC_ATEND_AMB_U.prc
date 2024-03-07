create or replace procedure PRC_LEG_PAA_PAC_ATEND_AMB_U
  (
     pCODAND      IN PACIENTE_ATENDIMENTO_AMB.CODAND%TYPE,
     pCODMED      IN PACIENTE_ATENDIMENTO_AMB.CODMED%TYPE,
     pCODESPMED   IN PACIENTE_ATENDIMENTO_AMB.CODESPMED%TYPE,
     pCODUNIHOS   IN PACIENTE_ATENDIMENTO_AMB.CODUNIHOS%TYPE,
     pLOCAL      IN PACIENTE_ATENDIMENTO_AMB.LOCAL%TYPE,
     pCODAND_OLD  IN PACIENTE_ATENDIMENTO_AMB.CODAND%TYPE
  )
  is
  /********************************************************************
  *    Procedure: PRC_LEG_PAA_PAC_ATEND_AMB_U
  *
  *    Data Criacao:   27/06/2008           Por: Fabiola Lopes
  *    Data Alteracao:                      Por:
  *
  *    Funcao: Alterac?o de registro na tabela PRC_LEG_PAA_PAC_ATEND_AMB_U
  *
  *******************************************************************/
  BEGIN
    UPDATE PACIENTE_ATENDIMENTO_AMB AMB
       SET CODAND = pCODAND
     WHERE CODMED = pCODMED
       AND CODESPMED = pCODESPMED
       AND CODUNIHOS = pCODUNIHOS
       AND LOCAL = pLOCAL
       AND TRUNC(DATATE) > = TRUNC(SYSDATE)
       AND CODAND = pCODAND_OLD
       AND CODSITATE = 'P';
  end PRC_LEG_PAA_PAC_ATEND_AMB_U;
/
