create or replace procedure PRC_ATD_ATENDIMENTO_R_SID
  (
     pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ATD_ATENDIMENTO_R_SID
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	21/10/2014  Por: Andrea Cazuca
  *    Alteracao:  Inclusao do campo TIS_CBO_CD_CBOS_SOLIC
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
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
       TIS_CBO_CD_CBOS_SOLIC,
	   ATD_ATE_DS_MOTIVO_CANCELA,
       ATD_ATE_FL_SUSPEITA_COVID19,
       ATD_ATE_FL_PEDIATRIA_ONCO
    FROM TB_ATD_ATE_ATENDIMENTO
    WHERE
        ATD_ATE_ID = pATD_ATE_ID;          
    io_cursor := v_cursor;
  end PRC_ATD_ATENDIMENTO_R_SID;
