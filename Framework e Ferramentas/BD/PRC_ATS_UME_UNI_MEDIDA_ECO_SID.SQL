

---bozo

  --PRC_ATS_UME_UNI_MEDIDA_ECO_SID
  create or replace procedure PRC_ATS_UME_UNI_MEDIDA_ECO_SID 
  (
     pATS_UME_CD_ECOCARDIO IN TB_ATS_UME_UNI_MEDIDA_ECOCAR.ATS_UME_CD_ECOCARDIO%type,
     pATS_UME_CD_UNID_MEDIDA IN TB_ATS_UME_UNI_MEDIDA_ECOCAR.ATS_UME_CD_UNID_MEDIDA%type,
     pATS_UME_TP_UNID_MEDIDA IN TB_ATS_UME_UNI_MEDIDA_ECOCAR.ATS_UME_TP_UNID_MEDIDA%type     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ATS_UME_UNI_MEDIDA_ECOCAR_SID
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
       ATS_UME_TP_UNID_MEDIDA,
       ATS_UME_DS_UNID_MEDIDA,
       ATS_UME_QT_UNID_MEDIDA_INI,
       ATS_UME_QT_UNID_MEDIDA_ECO_INI,
       ATS_UME_QT_UNID_MEDIDA_ECO_FIM,
       ATS_UME_CD_UNID_MEDIDA,
       ATS_UME_QT_UNID_MEDIDA_FIM,
       ATS_UME_CD_ECOCARDIO,
       ATS_UME_DS_ECOCARDIO,
       ATS_UME_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       ATS_UME_FL_STATUS
    FROM TB_ATS_UME_UNI_MEDIDA_ECOCAR
    WHERE
        ATS_UME_CD_ECOCARDIO = pATS_UME_CD_ECOCARDIO
    AND ATS_UME_CD_UNID_MEDIDA = pATS_UME_CD_UNID_MEDIDA
    AND ATS_UME_TP_UNID_MEDIDA = pATS_UME_TP_UNID_MEDIDA;          
    io_cursor := v_cursor;
  end PRC_ATS_UME_UNI_MEDIDA_ECO_SID;
