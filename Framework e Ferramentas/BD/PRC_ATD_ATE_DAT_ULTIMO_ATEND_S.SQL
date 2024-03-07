create or replace procedure PRC_ATD_ATE_DAT_ULTIMO_ATEND_S
(      pCAD_PAC_ID_PACIENTE IN TB_ASS_PAT_PACIEATEND.CAD_PAC_ID_PACIENTE%TYPE,
       pTIS_CBO_CD_CBOS IN TB_ATD_ATE_ATENDIMENTO.TIS_CBO_CD_CBOS%TYPE,
       pCAD_UNI_ID_UNIDADE IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE,
       io_cursor            OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_ATD_ATE_DAT_ULTIMO_ATEND_S
  *
  *    Data Criacao:   09/04/2008   Por: Andrea Cazuca
  *    Funcao: Seleciona ultima data do atendimento do paciente
  *
  *    Data Alteracao: 21/05/2008    Por: Fabíola Lopes
  *    Alteração: Inclusão de dois parâmetros para realização da busca corretamente
  *               TIS_CBO_CD_CBOS e CAD_UNI_ID_UNIDADE
  *
  *    Data Alteracao: 26/06/2008    Por: Andrea Cazuca
  *    Alteracao: Incluído o Status na clausula where
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
    SELECT * FROM (
           SELECT MAX(ATD.ATD_ATE_DT_ATENDIMENTO) DT_ATENDIMENTO,
                  ATD.ATD_ATE_HR_ATENDIMENTO HORA_ATENDIMENTO,
                  CBO.TIS_CBO_CD_CBOS_HAC CBOS,
                  ATD.CAD_UNI_ID_UNIDADE UNIDADE
           FROM   TB_ATD_ATE_ATENDIMENTO ATD,
                  TB_ASS_PAT_PACIEATEND  PAT,
                  TB_TIS_CBO_CBOS        CBO
           WHERE  ATD.ATD_ATE_ID = PAT.ATD_ATE_ID
           AND    PAT.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
           AND    ATD.TIS_CBO_CD_CBOS = CBO.TIS_CBO_CD_CBOS
           AND    ATD.TIS_TAT_CD_TPATENDIMENTO = 4
           AND    ATD.ATD_ATE_FL_RETORNO_OK = 'N'
           AND    ATD.ATD_ATE_FL_STATUS = 'A'
           AND    ATD.ATD_ATE_DT_ATENDIMENTO <= TRUNC(SYSDATE)
           AND    ATD.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS
           AND    ATD.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
           GROUP BY ATD.ATD_ATE_HR_ATENDIMENTO, CBO.TIS_CBO_CD_CBOS_HAC, ATD.CAD_UNI_ID_UNIDADE
           ORDER BY 1 DESC)
    WHERE ROWNUM < 2;
  io_cursor := v_cursor;
end PRC_ATD_ATE_DAT_ULTIMO_ATEND_S;
/
