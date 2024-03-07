create or replace procedure PRC_LEG_TOT_ATD_PAC_ESPEC_S
  (
     pDATATE                 IN PACIENTE_ATENDIMENTO_AMB.DATATE%TYPE,
     pTIS_CBO_CD_CBOS        IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE,
     pCAD_PAC_ID_PACIENTE    IN TB_CAD_PAC_PACIENTE.CAD_PAC_ID_PACIENTE%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is

  /********************************************************************
  *    Procedure:        PRC_LEG_TOT_ATD_PAC_ESPEC_S
  *
  *    Data Criacao:     25/07/2008         Por: Fabiola R. Lopes
  *    Data Alteracao:   data da alteragco  Por: Nome do Analista
  *
  *    Funcao: Recupera a quantidade de Agendamentos do Paciente e Especialidade informadas
  *
  *     Data Alteracao:   04/08/2008
  *     Alteracao: Acerto no parametro da data
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;

  begin

    OPEN v_cursor FOR

      -- Se ACS (Convenio SD01) ou Funcionario (Convenio GG05)
      SELECT COUNT(*) TOT_ATE_LEG
        FROM PACIENTE_ATENDIMENTO_AMB PAA,
             TB_TIS_CBO_CBOS CBO,
             TB_CAD_PLA_PLANO PLA,
             TB_CAD_PAC_PACIENTE PAC
       WHERE CBO.TIS_CBO_CD_CBOS = PTIS_CBO_CD_CBOS
         AND PAA.CODESPMED = CBO.TIS_CBO_CD_CBOS_HAC
         AND CODTIPATE IN (1,23,26)
         AND CODSITATE = 'A'
         AND PAC.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
         AND PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
         AND PAA.CODCON = SUBSTR(PLA.CAD_PLA_CD_PLANO,0,4)
         AND PAA.CODEST = TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,0,3))
         AND PAA.CODBEN = TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,4,7))
         AND PAA.DIGCARIDE = TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,11,2))
--       AND TO_DATE(TO_CHAR(PAA.DATATE,'yyyy'),'yyyy') = TO_DATE(TO_CHAR (pDATATE, 'yyyy'), 'yyyy')
--       AND TO_CHAR(PAA.DATATE, 'YYYY') = TO_CHAR(TO_DATE(pDATATE,'DD/MM/YYYY'),'YYYY')
         AND TO_CHAR(PAA.DATATE, 'YYYY') = TO_CHAR(pDATATE,'yyyy')
         AND NOT EXISTS (SELECT *
                           FROM TB_ATD_ATE_ATENDIMENTO ATE
                          WHERE ATE.ATD_ATE_ID = PAA.CODATEAMB);
  io_cursor := v_cursor;

end PRC_LEG_TOT_ATD_PAC_ESPEC_S;
/