 create or replace procedure PRC_ATD_ATENDIMENTO_HIST
(
     pDATAINI                      IN DATE,
     pDATAFIM                      IN DATE,
     io_cursor                     OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *  Procedure: PRC_ATD_ATENDIMENTO_HIST
  *
  *  Data Criacao: 13/10/2010   Por: André Souza Monaco
  *
  *  Funcao: RETORNA ATENDIMENTOS NO PERÍODO
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       ATD_ATE_TP_PACIENTE,
       ATD_ATE_ID,
       ATD_ATE_DT_ATENDIMENTO,
       ATD_ATE_HR_ATENDIMENTO,
       CODPAD,
       ATD_ATE_FL_CARATER_SOLIC,
       ATD_ATE_DS_INDCLINICA,
       ATD_ATE_FL_INDIC_RN_OK,
       ATD_ATE_FL_RETORNO_OK,
       ATD_ATE_DS_OBSERVACAO,
       ATD_ATE_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       TIS_TSC_CD_TIPOSAIDACONSULTA,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_CID_CD_CID10,
       TIS_TAT_CD_TPATENDIMENTO,
       TIS_IAC_CD_INDACIDENTE,
       CAD_UNI_ID_UNIDADE,
       TIS_CBO_CD_CBOS,
       CAD_SET_ID,
       CAD_UNI_ID_UNID_PROC,
       CODCLI,
       CAD_PRO_ID_PROF_EXEC,
       ATD_ATE_NR_CONSELHO_SOLIC,
       ATD_ATE_CD_UFCONSELHO_SOLIC,
       ATD_ATE_FL_STATUS,
       TIS_CPR_CD_CONSELHOPROF_SOLIC,
       ATD_ATE_NR_SENHA_CHAMADA,
       ATD_ATE_FL_LIBERA_EMISSAO,
       ATD_ATE_DS_MOTIVO_CANCELA
    FROM TB_ATD_ATE_ATENDIMENTO
    WHERE (TRUNC(ATD_ATE_DT_ATENDIMENTO) BETWEEN TRUNC(pDATAINI) AND TRUNC(pDATAFIM))
    ORDER BY ATD_ATE_ID;
    io_cursor := v_cursor;
end PRC_ATD_ATENDIMENTO_HIST;
