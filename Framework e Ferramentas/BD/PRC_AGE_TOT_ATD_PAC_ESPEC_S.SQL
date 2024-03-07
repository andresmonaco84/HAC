create or replace procedure PRC_AGE_TOT_ATD_PAC_ESPEC_S
  (
     pATD_ATE_DT_ATENDIMENTO IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE,
     pCAD_PAC_ID_PACIENTE    IN TB_ASS_PAT_PACIEATEND.CAD_PAC_ID_PACIENTE%TYPE,
     pTIS_CBO_CD_CBOS        IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is

  /********************************************************************
  *    Procedure:        PRC_AGE_TOT_ATD_PAC_ESPEC_S
  *
  *    Data Criacao:     25/07/2008         Por: Fabiola R. Lopes
  *    Data Alteracao:   data da alteragco  Por: Nome do Analista
  *
  *    Funcao: Recupera a quantidade de Atendimentos do Paciente e Especialidade
  *
  *     Data Alteracao:   04/08/2008
  *     Alteracao: Acerto no parametro da data
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin

    OPEN v_cursor FOR

      SELECT COUNT(*) TOTAL_ATEND
        FROM TB_ATD_ATE_ATENDIMENTO ATD,
             TB_ASS_PAT_PACIEATEND PAT,
             TB_TIS_TAT_TP_ATENDIMENTO TAT
       WHERE PAT.ATD_ATE_ID = ATD.ATD_ATE_ID
         AND ATD.ATD_ATE_FL_RETORNO_OK = 'N'
         -- AND TO_CHAR(ATD.ATD_ATE_DT_ATENDIMENTO, 'YYYY') = TO_CHAR(TO_DATE(pATD_ATE_DT_ATENDIMENTO,'DD/MM/YYYY'),'YYYY') --TO_CHAR(pATD_ATE_DT_ATENDIMENTO,'YYYY')
         AND TO_CHAR(ATD.ATD_ATE_DT_ATENDIMENTO, 'YYYY') = to_char(pATD_ATE_DT_ATENDIMENTO,'yyyy')
         AND PAT.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
         AND TAT.TIS_TAT_CD_TPATENDIMENTO = 4
         AND TAT.TIS_TAT_CD_TPATENDIMENTO = ATD.TIS_TAT_CD_TPATENDIMENTO
         AND ATD.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS
         AND ATD.ATD_ATE_FL_STATUS = 'A';
    io_cursor := v_cursor;

  end PRC_AGE_TOT_ATD_PAC_ESPEC_S;
  /