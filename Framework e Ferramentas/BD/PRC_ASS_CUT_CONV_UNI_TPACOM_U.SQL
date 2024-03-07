create or replace procedure PRC_ASS_CUT_CONV_UNI_TPACOM_U
  (
     pASS_CUT_ID IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CUT_ID%type,
     pASS_CUT_DT_INI_VIGENCIA IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CUT_DT_INI_VIGENCIA%type,
     pASS_CUT_DS_MOTIVO_FIM_VIG IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CUT_DS_MOTIVO_FIM_VIGENCIA%type default NULL,
     pASS_CUT_DT_FIM_VIGENCIA IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CUT_DT_FIM_VIGENCIA%type default NULL,
     pASS_UTA_ID_UNID_TPACOMOD IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_UTA_ID_UNID_TPACOMOD%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_CUT_CONV_UNI_TPACOMOD.SEG_USU_ID_USUARIO%type,
     pASS_CNU_ID IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CNU_ID%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CUT_CONV_UNI_TPACOM_U
  *
  *    Data Criacao: 	12/06/2007         Por: Fabíola R. Lopes
  *    Funcao: Altera as Associações de Convênio Unidade x Tipo de Acomodação
  *
  *    Data Alteracao: 28/06/2007   Por: Andrea Cazuca
  *    Alteracao: Inclui update na tabela TB_ASS_CTP_CNV_UN_TPACOM_PLA
  *               nos campos fim de vigencia e motivo fim vigencia, para fechar vigência
  *******************************************************************/
  begin
    UPDATE TB_ASS_CUT_CONV_UNI_TPACOMOD
    SET
        ASS_CUT_DT_INI_VIGENCIA = pASS_CUT_DT_INI_VIGENCIA,
        ASS_CUT_DS_MOTIVO_FIM_VIGENCIA = UPPER(pASS_CUT_DS_MOTIVO_FIM_VIG),
        ASS_CUT_DT_FIM_VIGENCIA = pASS_CUT_DT_FIM_VIGENCIA,
        ASS_CUT_DT_ULTIMA_ATUALIZACAO = SYSDATE,
        ASS_UTA_ID_UNID_TPACOMOD = pASS_UTA_ID_UNID_TPACOMOD,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        ASS_CNU_ID = pASS_CNU_ID
    WHERE
        ASS_CUT_ID = pASS_CUT_ID;
        
    -- Verifica se a data de fim de vigencia está preenchida
    IF pASS_CUT_DT_FIM_VIGENCIA is not null then
    
       UPDATE TB_ASS_CTP_CNV_UN_TPACOM_PLA
       SET
          ASS_CTP_DT_FIM_VIGENCIA = pASS_CUT_DT_FIM_VIGENCIA,
          ASS_CTP_DT_ULTIMA_ATUALIZACAO = SYSDATE,
          SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
       WHERE
          ASS_CUT_ID = pASS_CUT_ID;
    
    END IF;
  end PRC_ASS_CUT_CONV_UNI_TPACOM_U;
/
