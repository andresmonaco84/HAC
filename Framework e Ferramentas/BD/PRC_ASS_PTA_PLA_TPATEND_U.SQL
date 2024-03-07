CREATE OR REPLACE PROCEDURE PRC_ASS_PTA_PLA_TPATEND_U
  (
     pASS_PTA_ID IN TB_ASS_PTA_PLA_TPATEND.ASS_PTA_ID%type,
     pASS_PTA_DS_MOTIVO_FIM_VIGEN IN TB_ASS_PTA_PLA_TPATEND.ASS_PTA_DS_MOTIVO_FIM_VIGENCIA%type default NULL,
     pASS_PTA_DT_FIM_VIGENCIA IN TB_ASS_PTA_PLA_TPATEND.ASS_PTA_DT_FIM_VIGENCIA%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_PTA_PLA_TPATEND.SEG_USU_ID_USUARIO%type,
     pASS_PTA_DT_INI_VIGENCIA IN TB_ASS_PTA_PLA_TPATEND.ASS_PTA_DT_INI_VIGENCIA%type default NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PTA_PLA_TPATEND_U
  *
  *    Data Criacao:   14/09/2009   Por: Alexandre M. Muniz  *
  *    Data Alteracao:  12/03/2014  Por: André
  *         Alteracao:  Atualização também do campo ASS_PTA_DT_INI_VIGENCIA
  *
  *    Funcao: Atualiza a Associac?o Plano X Tipo de Atendimento
  *******************************************************************/
  begin

    UPDATE TB_ASS_PTA_PLA_TPATEND
    SET
        ASS_PTA_DS_MOTIVO_FIM_VIGENCIA = upper(pASS_PTA_DS_MOTIVO_FIM_VIGEN),        
        ASS_PTA_DT_ULTIMA_ATUALIZACAO = sysdate,
        ASS_PTA_DT_INI_VIGENCIA = pASS_PTA_DT_INI_VIGENCIA,
        ASS_PTA_DT_FIM_VIGENCIA = pASS_PTA_DT_FIM_VIGENCIA,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
    WHERE
        ASS_PTA_ID = pASS_PTA_ID;

  end PRC_ASS_PTA_PLA_TPATEND_U;
 
