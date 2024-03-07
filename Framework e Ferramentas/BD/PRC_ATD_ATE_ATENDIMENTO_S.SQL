CREATE OR REPLACE PROCEDURE "PRC_ATD_ATE_ATENDIMENTO_S" (pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%type DEFAULT NULL,
                                                      io_cursor   OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_ATD_ATE_ATENDIMENTO_S
  *
  *    Data Criacao:  17/01/2008   Por: Andrea Cazuca
  *
  *    Funcao: Seleciona Atendimento
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(2000);
  V_SELECT varchar2(4000);
begin
  V_WHERE := NULL;
  IF pATD_ATE_ID IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND ATD_ATE_ID = ' || pATD_ATE_ID;
    ELSE
      V_WHERE := V_WHERE || ' ATD_ATE_ID = ' || pATD_ATE_ID;
    END IF;
  END IF;
  V_SELECT := 'SELECT
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
       ATD_ATE_FL_PRONT_ELETR_ATIVO,
       TIS_CBO_CD_CBOS_SOLIC,
       ATD_ATE_ID_PRIORIDADE_ATEND,
       ATD_ATE_FL_SUSPEITA_COVID19,
       ATD_ATE_DS_COMPLEMENTO,
       ATD_ATE_FL_PEDIATRIA_ONCO,
       ATD_ATE_TP_DOMICILIAR,
       ATD_ATE_IN_TEA
    FROM TB_ATD_ATE_ATENDIMENTO
    WHERE ' || V_WHERE;
  OPEN v_cursor FOR V_SELECT;
  io_cursor := v_cursor;
end PRC_ATD_ATE_ATENDIMENTO_S;
