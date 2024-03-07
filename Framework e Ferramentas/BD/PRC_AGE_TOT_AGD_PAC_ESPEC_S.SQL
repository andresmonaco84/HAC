create or replace procedure PRC_AGE_TOT_AGD_PAC_ESPEC_S
  (
     pAGE_AGD_DT_ATENDIMENTO IN TB_AGE_AGD_AGENDA.AGE_AGD_DT_ATENDIMENTO%TYPE,
     pCAD_PAC_ID_PACIENTE    IN TB_ASS_PAT_PACIEATEND.CAD_PAC_ID_PACIENTE%TYPE,
     pTIS_CBO_CD_CBOS        IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is

  /********************************************************************
  *    Procedure:        PRC_AGE_TOT_AGD_PAC_ESPEC_S
  *
  *    Data Criacao:     25/07/2008         Por: Fabiola R. Lopes
  *    Data Alteracao:   data da alteragco  Por: Nome do Analista
  *
  *    Funcao: Recupera a quantidade de Agendamentos do Paciente e Especialidade
  *
  *     Data Alteracao:   04/08/2008
  *     Alteracao: Acerto no parametro da data
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;

  begin

    OPEN v_cursor FOR

      SELECT COUNT(*) TOTAL_AGEND
        FROM TB_AGE_AGD_AGENDA AGE,
             TB_AGE_ESM_ESCALA_MEDICA ESM
       WHERE AGE.AGE_AGD_FL_STATUS = 'P'
         AND AGE.AGE_AGD_TP_AGENDA != 4
--         AND TO_DATE(TO_CHAR(AGE.AGE_AGD_DT_ATENDIMENTO,'YYYY'),'YYYY') = TO_DATE(pAGE_AGD_DT_ATENDIMENTO,'YYYY')
--         AND TO_CHAR(AGE.AGE_AGD_DT_ATENDIMENTO, 'YYYY') = TO_CHAR(TO_DATE(pAGE_AGD_DT_ATENDIMENTO,'DD/MM/YYYY'),'YYYY')
         AND TO_CHAR(AGE.AGE_AGD_DT_ATENDIMENTO, 'YYYY') = to_char(pAGE_AGD_DT_ATENDIMENTO,'yyyy')
         AND AGE.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
         AND ESM.AGE_ESM_ID = AGE.AGE_ESM_ID
         AND ESM.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS;

    io_cursor := v_cursor;

  end PRC_AGE_TOT_AGD_PAC_ESPEC_S;
  /