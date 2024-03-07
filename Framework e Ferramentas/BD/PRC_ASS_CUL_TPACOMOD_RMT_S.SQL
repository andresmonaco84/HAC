create or replace procedure PRC_ASS_CUL_TPACOMOD_RMT_S
  (
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CTA_CONV_TPATEND.CAD_CNV_ID_CONVENIO%type,
     pCAD_PLA_ID_PLANO    IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.CAD_PLA_ID_PLANO%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE  IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CUL_TPACOMOD_RMT_S
  *
  *    Data Criacao:   15/07/2009   Por: Pedro
  *    Data Alteracao: 03/05/2010   Por: Andre Souza Monaco
  *         Alteracao: Retirada das tabelas TB_CAD_PES_PESSOA, TB_CAD_LAT_LOCAL_ATENDIMENTO e TB_CAD_SET_SETOR 
  *                    da query e adic?o da TB_ASS_CTP_CNV_UN_TPACOM_PLA e do parametro pCAD_PLA_ID_PLANO
  *    Data Alteracao: 07/6/2010 / Adicionado campo TPL.ASS_CTP_PC_HM_ACOMODACAO / Marcus Relva
  *    Data Alteracao: 26/08/2010 / Adicionado join da tabela plano / Andre Souza Monaco
  *    Data Alteracao: 23/11/2010 / Retirada da tabela TB_ASS_CUL_CONV_UNI_LOCATEND do join / Andre Souza Monaco
  *
  *    Funcao: Lista Unidade e Lat (Ativos e que permitem internacao) x Cnv x TpAcomodacao
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
     SELECT  DISTINCT
             UNI.CAD_UNI_ID_UNIDADE,
             UNI.CAD_UNI_DS_UNIDADE,               
             CNV.CAD_CNV_ID_CONVENIO,
             TPL.CAD_PLA_ID_PLANO,             
             CNV.CAD_CNV_CD_HAC_PRESTADOR,       
             TAC.TIS_TAC_CD_TIPO_ACOMODACAO,
             TAC.TIS_TAC_DS_TIPO_ACOMODACAO,
             CUT.ASS_CUT_ID,
             TPL.ASS_CTP_DT_INI_VIGENCIA,
             TPL.ASS_CTP_DT_FIM_VIGENCIA,
             TPL.ASS_CTP_PC_HM_ACOMODACAO,
             TPL.ASS_CTP_PC_HM_ARTROSCOPIA,
             TPL.ASS_CTP_PC_HM_LAPAROSCOPIA,
             PLA.CAD_PLA_CD_PLANO_HAC
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
           INNER JOIN TB_ASS_CTP_CNV_UN_TPACOM_PLA TPL
            ON CUT.ASS_CUT_ID = TPL.ASS_CUT_ID  
           INNER JOIN TB_CAD_PLA_PLANO PLA
            ON PLA.CAD_PLA_ID_PLANO = TPL.CAD_PLA_ID_PLANO
           WHERE (UNI.CAD_UNI_FL_STATUS = 'A')
            AND  (UTA.ASS_UTA_FL_ATIVO_OK = 'S')
            AND  (CNV.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
            AND  (pCAD_PLA_ID_PLANO IS NULL OR TPL.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
            AND  (pCAD_UNI_ID_UNIDADE IS NULL OR UNI.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
            ORDER BY TPL.ASS_CTP_DT_FIM_VIGENCIA, TPL.ASS_CTP_DT_INI_VIGENCIA,
                     UNI.CAD_UNI_DS_UNIDADE, TAC.TIS_TAC_DS_TIPO_ACOMODACAO;
    io_cursor := v_cursor;
  end PRC_ASS_CUL_TPACOMOD_RMT_S;
