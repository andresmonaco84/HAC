create or replace procedure PRC_ASS_CDL_RMT_S
  (
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CTA_CONV_TPATEND.CAD_CNV_ID_CONVENIO%type,
     pCAD_PLA_ID_PLANO    IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.CAD_PLA_ID_PLANO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CDL_RMT_S
  *
  *    Data Criacao:   15/07/2009   Por: Pedro
  *    Data Alteracao: 03/05/2010   Por: André Souza Monaco
  *         Alteração: Ajuste e adição da TB_ASS_CTP_CNV_UN_TPACOM_PLA e do parâmetro pCAD_PLA_ID_PLANO
  *
  *    Funcao: Lista Documentos ativos por convênio e plano de locais ativos
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR

      SELECT LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO, 
             DOC.CAD_DOC_DS_DOCUMENTO, 
             CNV.CAD_CNV_CD_HAC_PRESTADOR,
             LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO, 
             CNV.CAD_CNV_ID_CONVENIO  
       FROM TB_ASS_CDL_CONV_DOC_LOCATEND CDL
             INNER JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
              ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = CDL.CAD_LAT_ID_LOCAL_ATENDIMENTO
             INNER JOIN TB_CAD_CNV_CONVENIO CNV
              ON CNV.CAD_CNV_ID_CONVENIO = CDL.CAD_CNV_ID_CONVENIO
             INNER JOIN TB_CAD_DOC_DOCUMENTO DOC
              ON DOC.CAD_DOC_ID_DOCUMENTO = CDL.CAD_DOC_ID_DOCUMENTO
             INNER JOIN TB_ASS_CDP_CNV_DC_LOC_PLANO DLP
              ON CDL.ASS_CDL_ID = DLP.ASS_CDL_ID
             WHERE
                 (LAT.CAD_LAT_FL_ATIVO_OK = 'S')
             AND (DOC.CAD_DOC_FL_ATIVO_OK = 'S')
             AND (CNV.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
             AND (DLP.CAD_PLA_ID_PLANO    = pCAD_PLA_ID_PLANO)
             ORDER BY LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO, DOC.CAD_DOC_DS_DOCUMENTO;

    io_cursor := v_cursor;
  end PRC_ASS_CDL_RMT_S;



