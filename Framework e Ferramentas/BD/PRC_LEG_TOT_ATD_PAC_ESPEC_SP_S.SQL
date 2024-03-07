create or replace procedure PRC_LEG_TOT_ATD_PAC_ESPEC_SP_S
  (
     pDATATE                 IN PACIENTE_ATENDIMENTO_AMB.DATATE%TYPE,
     pTIS_CBO_CD_CBOS        IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE,
     pCAD_PAC_ID_PACIENTE    IN TB_CAD_PAC_PACIENTE.CAD_PAC_ID_PACIENTE%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is

  /********************************************************************
  *    Procedure:        PRC_LEG_TOT_ATD_PAC_ESPEC_SP_S
  *
  *    Data Criacao:     25/07/2008         Por: Fabiola R. Lopes
  *    Data Alteracao:   data da alteragco  Por: Nome do Analista
  *
  *    Funcao: Recupera a quantidade de atendimentos por Paciente e Especialidade de Servico Prestado
  *
  *     Data Alteracao:   04/08/2008
  *     Alteracao: Acerto no parametro da data
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;

  begin

    OPEN v_cursor FOR

      --Se Servico Prestado ou Particular
      SELECT COUNT(*) TOT_ATE_LEG_SP
        FROM PACIENTE_ATENDIMENTO_AMB PAA,
             TB_TIS_CBO_CBOS CBO,
             TB_CAD_PAC_PACIENTE PAC
       WHERE CBO.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS
         AND PAA.CODESPMED = CBO.TIS_CBO_CD_CBOS_HAC
         AND CODTIPATE IN ('1','23','26')
         AND CODSITATE = 'A'
         AND PAC.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
         AND PAC.CAD_PAC_NR_PRONTUARIO  = PAA.CODPAC
--       AND TO_CHAR(PAA.DATATE, 'YYYY') = TO_CHAR(TO_DATE(pDATATE,'DD/MM/YYYY'),'YYYY')
         AND TO_CHAR(PAA.DATATE, 'YYYY') = to_char(pDATATE,'yyyy')
         AND NOT EXISTS (SELECT *
                           FROM TB_ATD_ATE_ATENDIMENTO ATE
                          WHERE ATE.ATD_ATE_ID = PAA.CODATEAMB);

  io_cursor := v_cursor;

end PRC_LEG_TOT_ATD_PAC_ESPEC_SP_S;
/