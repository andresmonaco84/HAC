create or replace procedure PRC_INT_REL_ESTAT_TP_INTERN
  (
     pCAD_UNI_ID_UNIDADE in TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE,
     pATD_ATE_DT_ATENDIMENTO_INI IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE,
     pATD_ATE_DT_ATENDIMENTO_FIM IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_REL_ESTAT_TP_INTERN
  *
  *    Data Criacao:  10/11/2010   Por:PEDRO
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
SELECT  DISTINCT
        AIC.TIS_TIN_CD_INTERNACAO,
        TIN.TIS_TIN_DS_INTERNACAO ,
       -- TO_CHAR(ATE.ATD_ATE_DT_ATENDIMENTO,'MM') MES,
        COUNT(ATE.ATD_ATE_ID) OVER(PARTITION BY AIC.TIS_TIN_CD_INTERNACAO) TOTAL

FROM     TB_ATD_ATE_ATENDIMENTO ATE
JOIN     TB_ATD_AIC_ATE_INT_COMPL AIC
ON       ATE.ATD_ATE_ID = AIC.ATD_ATE_ID
JOIN     TB_TIS_TIN_TP_INTERNACAO TIN
ON       TIN.TIS_TIN_CD_INTERNACAO = AIC.TIS_TIN_CD_INTERNACAO
WHERE
         ATE.ATD_ATE_FL_STATUS = 'A'
AND      ATE.ATD_ATE_DT_ATENDIMENTO BETWEEN pATD_ATE_DT_ATENDIMENTO_INI AND pATD_ATE_DT_ATENDIMENTO_FIM
AND      ATE.CAD_UNI_ID_UNIDADE = PCAD_UNI_ID_UNIDADE
   ;
    io_cursor := v_cursor;
  end PRC_INT_REL_ESTAT_TP_INTERN;
/
