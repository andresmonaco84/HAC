create or replace procedure PRC_ASS_CTA_RMT_S
  (
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CTA_CONV_TPATEND.CAD_CNV_ID_CONVENIO%TYPE,
     pCAD_PLA_ID_PLANO    IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CTA_RMT_S
  *
  *    Data Criacao:   15/07/2009   Por: Pedro
  *    Data Alteracao: 12/05/2010   Por: André Souza Monaco
  *         Alteracao: Traz por plano e não por locais ativos
  *
  *    Funcao: Convenio/Plano x Tipo de Atendimento
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    
     SELECT       
           TAT.TIS_TAT_CD_TPATENDIMENTO,
           TAT.TIS_TAT_DS_TPATENDIMENTO,
           PTA.ASS_PTA_DT_INI_VIGENCIA,
           PTA.ASS_PTA_DT_FIM_VIGENCIA
     FROM TB_ASS_CTA_CONV_TPATEND CTA
     INNER JOIN TB_TIS_TAT_TP_ATENDIMENTO TAT
      ON TAT.TIS_TAT_CD_TPATENDIMENTO = CTA.TIS_TAT_CD_TPATENDIMENTO
     INNER JOIN TB_ASS_PTA_PLA_TPATEND PTA
      ON PTA.ASS_CTA_ID = CTA.ASS_CTA_ID
     WHERE
           (CTA.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO) AND 
           (PTA.CAD_PLA_ID_PLANO    = pCAD_PLA_ID_PLANO)
     ORDER BY CTA.ASS_CTA_DT_FIM_VIGENCIA, ASS_CTA_DT_INI_VIGENCIA, TAT.TIS_TAT_DS_TPATENDIMENTO;
     
   io_cursor := v_cursor;
  end PRC_ASS_CTA_RMT_S;



