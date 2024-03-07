create or replace procedure PRC_ASS_CNU_TPACOMOD_RMT_S
  (
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CTA_CONV_TPATEND.CAD_CNV_ID_CONVENIO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNU_TPACOMOD_RMT_S
  *
  *    Data Criacao:   27/05/2010   Por: André Souza Monaco
  *
  *    Funcao: Lista Unidade * x Cnv x TpAcomodacao
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR

     SELECT DISTINCT
       TAC.TIS_TAC_CD_TIPO_ACOMODACAO,
       TAC.TIS_TAC_DS_TIPO_ACOMODACAO,
       CUT.ASS_CUT_DT_INI_VIGENCIA,
       CUT.ASS_CUT_DT_FIM_VIGENCIA
     FROM TB_ASS_CNU_CONVENIO_UNIDADE CNU
           INNER JOIN TB_CAD_UNI_UNIDADE UNI
            ON UNI.CAD_UNI_ID_UNIDADE = CNU.CAD_UNI_ID_UNIDADE
           INNER JOIN TB_CAD_CNV_CONVENIO CNV
            ON CNV.CAD_CNV_ID_CONVENIO = CNU.CAD_CNV_ID_CONVENIO
           INNER JOIN  TB_ASS_UTA_UNID_TPACOMOD UTA
            ON UTA.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
           INNER JOIN TB_ASS_CUT_CONV_UNI_TPACOMOD CUT
            ON (CUT.ASS_UTA_ID_UNID_TPACOMOD = UTA.ASS_UTA_ID_UNID_TPACOMOD AND
                CUT.ASS_CNU_ID = CNU.ASS_CNU_ID)
           INNER JOIN TB_TIS_TAC_TIPO_ACOMODACAO TAC
            ON TAC.TIS_TAC_CD_TIPO_ACOMODACAO = UTA.TIS_TAC_CD_TIPO_ACOMODACAO
           WHERE (UNI.CAD_UNI_FL_STATUS = 'A')
            AND  (UTA.ASS_UTA_FL_ATIVO_OK = 'S')
            AND  (CNV.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
     ORDER BY TAC.TIS_TAC_DS_TIPO_ACOMODACAO;

    io_cursor := v_cursor;
  end PRC_ASS_CNU_TPACOMOD_RMT_S;
