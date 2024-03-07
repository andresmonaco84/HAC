create or replace procedure PRC_ASS_CTA_FINALIZAR_VIGENCIA
  (
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CTA_CONV_TPATEND.CAD_CNV_ID_CONVENIO%type,
     pASS_CTA_DT_FIM_VIGENCIA IN TB_ASS_CTA_CONV_TPATEND.ASS_CTA_DT_FIM_VIGENCIA%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_CTA_CONV_TPATEND.SEG_USU_ID_USUARIO%type,
     pASS_CTA_DS_MOTIVO_FIM_VIG IN TB_ASS_CTA_CONV_TPATEND.ASS_CTA_DS_MOTIVO_FIM_VIGENCIA%type default NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CTA_FINALIZAR_VIGENCIA
  *
  *    Data Criacao:   19/08/2009   Por: Alexandre M. Muniz
  *    Data Alteracao:  data da alteraÃ§Ã£o  Por: Nome do Analista
  *
  *    Funcao: Finaliza a vigência dos tipos de atendimento de um convênio
  *
  *******************************************************************/
  begin
    UPDATE TB_ASS_CTA_CONV_TPATEND
    SET        
        ASS_CTA_DS_MOTIVO_FIM_VIGENCIA = pASS_CTA_DS_MOTIVO_FIM_VIG,
        ASS_CTA_DT_ULTIMA_ATUALIZACAO = sysdate,
        ASS_CTA_DT_FIM_VIGENCIA = pASS_CTA_DT_FIM_VIGENCIA,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
    WHERE
        CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO;
        
  end PRC_ASS_CTA_FINALIZAR_VIGENCIA;
