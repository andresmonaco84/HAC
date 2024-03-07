  create or replace procedure PRC_ASS_CTA_CONV_TPATEND_U
  (
     pASS_CTA_ID IN TB_ASS_CTA_CONV_TPATEND.ASS_CTA_ID%type,
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CTA_CONV_TPATEND.CAD_CNV_ID_CONVENIO%type,
     pTIS_TAT_CD_TPATENDIMENTO IN TB_ASS_CTA_CONV_TPATEND.TIS_TAT_CD_TPATENDIMENTO%type,
     pASS_CTA_DS_MOTIVO_FIM_VIGEN IN TB_ASS_CTA_CONV_TPATEND.ASS_CTA_DS_MOTIVO_FIM_VIGENCIA%type default NULL,
     pASS_CTA_DT_INI_VIGENCIA IN TB_ASS_CTA_CONV_TPATEND.ASS_CTA_DT_INI_VIGENCIA%type,
     pASS_CTA_DT_FIM_VIGENCIA IN TB_ASS_CTA_CONV_TPATEND.ASS_CTA_DT_FIM_VIGENCIA%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_CTA_CONV_TPATEND.SEG_USU_ID_USUARIO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CTA_CONV_TPATEND_U
  * 
  *    Data Criacao: 	29/05/2007   Por: Adnrea Cazuca
  *    Data Alteracao:	data da alteraÃ§Ã£o  Por: Nome do Analista
  *
  *    Funcao: Atualiza a Associação Convenio X Tipo de Atendimento
  *
  *******************************************************************/  
  begin
    UPDATE TB_ASS_CTA_CONV_TPATEND
    SET	   
        CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO,
        TIS_TAT_CD_TPATENDIMENTO = pTIS_TAT_CD_TPATENDIMENTO,
        ASS_CTA_DS_MOTIVO_FIM_VIGENCIA = upper(pASS_CTA_DS_MOTIVO_FIM_VIGEN),
        ASS_CTA_DT_ULTIMA_ATUALIZACAO = sysdate,
        ASS_CTA_DT_INI_VIGENCIA = pASS_CTA_DT_INI_VIGENCIA,
        ASS_CTA_DT_FIM_VIGENCIA = pASS_CTA_DT_FIM_VIGENCIA,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO 
    WHERE
        ASS_CTA_ID = pASS_CTA_ID;	
  end PRC_ASS_CTA_CONV_TPATEND_U;
/
