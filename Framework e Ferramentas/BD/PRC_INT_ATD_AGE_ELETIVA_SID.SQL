  --PRC_INT_ATD_AGE_ELETIVA_SID
  create or replace procedure PRC_INT_ATD_AGE_ELETIVA_SID 
  (
     pATD_IAE_ID IN TB_ATD_IAE_INT_AGE_ELETIVA.ATD_IAE_ID%type,     
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_ATD_AGE_ELETIVA_SID
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       ATD_IAE_ID,
       ATD_IAE_DT_AGENDA,
       ATD_IAE_HR_AGENDA,
       ATD_IAE_DT_ATENDIMENTO,
       ATD_IAE_HR_ATENDIMENTO,
       CODPAD,
       ATD_IAE_DS_INDCLINICA,
       ATD_IAE_FL_INDIC_RN_OK,
       ATD_IAE_DS_OBSERVACAO,
       ATD_IAE_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_CID_CD_CID10,
       TIS_IAC_CD_INDACIDENTE,
       CAD_UNI_ID_UNIDADE,
       TIS_CBO_CD_CBOS,
       CAD_SET_ID,
       CAD_UNI_ID_UNID_PROC,
       ATD_IAE_NR_CONSELHO_SOLIC,
       ATD_IAE_CD_UFCONSELHO_SOLIC,
       ATD_IAE_FL_STATUS,
       TIS_CPR_CD_CONSELHOPROF_SOLIC,
       TIS_TIN_CD_INTERNACAO,
       ATD_IAE_DS_CONTATO,
       ATD_IAE_DS_PROCEDIMENTO,
       TIS_TRI_CD_REGINTERNACAO,
       ATD_IAE_QT_DIARIA_SOLICITADA,
       ATD_IAE_CD_GUIA,
       ATD_IAE_CD_SENHA,
       ATD_IAE_DT_VALIDADE,
       ATD_IAE_DT_EMISSAO,
       ATD_IAE_DT_AUTORIZACAO,
       CAD_PAC_ID_PACIENTE,
       ATD_IAE_QT_DIAS_VALIDADE,
       TIS_TAC_CD_TIPO_ACOMODACAO,
       CAD_PRD_ID,
       ATD_IAE_TP_PACIENTE
    FROM TB_ATD_IAE_INT_AGE_ELETIVA
    WHERE
        ATD_IAE_ID = pATD_IAE_ID;          
    io_cursor := v_cursor;
  end PRC_INT_ATD_AGE_ELETIVA_SID;
