create or replace procedure PRC_AGE_AGD_ULT_DT_AT_S
(
 PTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE DEFAULT NULL,
 pCAD_PRO_ID_PROFISSIONALEXEC IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%TYPE DEFAULT NULL,
 pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
 pCAD_PAC_ID_PACIENTE IN TB_CAD_PAC_PACIENTE.CAD_PAC_ID_PACIENTE%TYPE,
 pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
 pATD_ATE_DT_ATENDIMENTO IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
 pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE DEFAULT NULL,
 io_cursor OUT PKG_CURSOR.t_cursor
)
  /********************************************************************
  *    Procedure: PRC_AGE_AGD_ULT_DT_AT_S
  *
  *    Data Criacao: 05/10/2007   Por: Bruno Alvares
  *    Data Alteracao: 05/10/2007   Por: Cristiane Gomes da Silva
  *
  *    Funcao: Recuperar a ultima data de atendimento para convenios
  *            diferentes de servico prestado
  *
  *    Alteracao: 1) Retirar o acesso a tabela Especialidade do legado
  *	          para usar somente a tabela do TISS
  *
  *    Data Alterac?o: 17/09/2008    Por:  Andrea Cazuca
  *    Alterac?o:  Incluido o tipo de atendimento 10
  *
  *    Data Alterac?o: 22/01/2009    Por:  Andrea Cazuca
  *    Alterac?o: Incluido o parametro CAD_LAT_ID_LOCAL_ATENDIMENTO
  *
  *    Data Alterac?o: 15/07/2009    Por: Cristiane Gomes
  *    Alteracao: Utilizar a tabela de atendimento SGS ao inves da tabela do legado
  *
  *    Data Alterac?o: 15/01/2010    Por: Davi Silvestre M. dos Reis
  *    Alteracao: Retornar, tambem, a hora do ultimo atendimento (e nao somente a data)
  *
  *    Data Alterac?o: 23/02/2010    Por: Davi Silvestre M. dos Reis
  *    Alteracao: Inclusao do filtro pela Data de Atendimento
  *
  *    Data Alterac?o: 12/03/2010    Por: Davi Silvestre M. dos Reis
  *    Alteracao: Desconsiderar o atendimento atual
  *
  *******************************************************************/
is
  v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
  SELECT ATE.ATD_ATE_DT_ATENDIMENTO DATA, MAX(ATE.ATD_ATE_HR_ATENDIMENTO) HORA
    FROM TB_ATD_ATE_ATENDIMENTO ATE,
         TB_ASS_PAT_PACIEATEND PAT,
         TB_CAD_PAC_PACIENTE PAC
    WHERE (ATE.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
       OR  pCAD_UNI_ID_UNIDADE IS NULL)
      AND (DECODE(ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO,34,30,ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO) = CASE WHEN PAC.CAD_CNV_ID_CONVENIO = 281 AND pCAD_LAT_ID_LOCAL_ATENDIMENTO = 34 THEN
                                              30
                                              ELSE
                                              pCAD_LAT_ID_LOCAL_ATENDIMENTO
                                              END
       OR  pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL)
      AND (ATE.TIS_CBO_CD_CBOS = PTIS_CBO_CD_CBOS
       OR  PTIS_CBO_CD_CBOS is null)
      AND (ATE.CAD_PRO_ID_PROF_EXEC = pCAD_PRO_ID_PROFISSIONALEXEC
       OR  pCAD_PRO_ID_PROFISSIONALEXEC is null)
      AND (ATE.TIS_TAT_CD_TPATENDIMENTO = 4
       OR ATE.ATD_ATE_FL_CARATER_SOLIC = 'U')
      AND ATE.ATD_ATE_FL_RETORNO_OK = 'N'
      AND ATE.ATD_ATE_FL_STATUS = 'A'
      AND (ATE.ATD_ATE_DT_ATENDIMENTO <= pATD_ATE_DT_ATENDIMENTO
       OR pATD_ATE_DT_ATENDIMENTO is null)
      AND PAT.ATD_ATE_ID = ATE.ATD_ATE_ID
      AND PAT.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
      AND (ATE.ATD_ATE_ID !=  pATD_ATE_ID
       OR pATD_ATE_ID is null)
      AND PAT.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
  GROUP BY ATE.ATD_ATE_DT_ATENDIMENTO
    HAVING MAX(ATE.ATD_ATE_DT_ATENDIMENTO) = (SELECT MAX(ATE.ATD_ATE_DT_ATENDIMENTO) 
                                                FROM TB_ATD_ATE_ATENDIMENTO ATE,
                                                     TB_ASS_PAT_PACIEATEND PAT,
                                                     TB_CAD_PAC_PACIENTE PAC
                                                WHERE (ATE.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
                                                   OR  pCAD_UNI_ID_UNIDADE IS NULL)
                                                  AND (DECODE(ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO,34,30,ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO) = CASE WHEN PAC.CAD_CNV_ID_CONVENIO = 281 AND pCAD_LAT_ID_LOCAL_ATENDIMENTO = 34 THEN
                                                                                          30
                                                                                          ELSE
                                                                                          pCAD_LAT_ID_LOCAL_ATENDIMENTO
                                                                                          END
                                                   OR  pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL)
                                                  AND (ATE.TIS_CBO_CD_CBOS = PTIS_CBO_CD_CBOS
                                                   OR  PTIS_CBO_CD_CBOS is null)
                                                  AND (ATE.CAD_PRO_ID_PROF_EXEC = pCAD_PRO_ID_PROFISSIONALEXEC
                                                   OR  pCAD_PRO_ID_PROFISSIONALEXEC is null)
                                                  AND (ATE.TIS_TAT_CD_TPATENDIMENTO = 4
                                                   OR ATE.ATD_ATE_FL_CARATER_SOLIC = 'U')
                                                  AND ATE.ATD_ATE_FL_RETORNO_OK = 'N'
                                                  AND ATE.ATD_ATE_FL_STATUS = 'A'
                                                  AND (ATE.ATD_ATE_DT_ATENDIMENTO <= pATD_ATE_DT_ATENDIMENTO
                                                   OR pATD_ATE_DT_ATENDIMENTO is null)
                                                  AND PAT.ATD_ATE_ID = ATE.ATD_ATE_ID
                                                  AND PAT.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
                                                  AND PAT.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
                                                  AND (ATE.ATD_ATE_ID !=  pATD_ATE_ID
                                                   OR pATD_ATE_ID is null));
   io_cursor := v_cursor;
end PRC_AGE_AGD_ULT_DT_AT_S;
 