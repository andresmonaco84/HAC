create or replace procedure PRC_ASS_CUT_FINALIZAR_VIGENCIA
  (
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CNU_CONVENIO_UNIDADE.CAD_CNV_ID_CONVENIO%type,
     pASS_CUT_DT_FIM_VIGENCIA IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CUT_DT_FIM_VIGENCIA%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_CUT_CONV_UNI_TPACOMOD.SEG_USU_ID_USUARIO%type,
     pASS_CUT_DS_MOTIVO_FIM_VIG IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CUT_DS_MOTIVO_FIM_VIGENCIA%type default NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CUT_FINALIZAR_VIGENCIA
  *
  *    Data Criacao:   19/08/2009         Por: Alexandre M. Muniz
  *    Funcao: Finaliza a vigência dos Tipos de Acomodação de todas as
  *            Unidades de um Convênio.
  *
  *******************************************************************/
  begin
    UPDATE TB_ASS_CUT_CONV_UNI_TPACOMOD
    SET
        ASS_CUT_DS_MOTIVO_FIM_VIGENCIA = pASS_CUT_DS_MOTIVO_FIM_VIG,
        ASS_CUT_DT_FIM_VIGENCIA = pASS_CUT_DT_FIM_VIGENCIA,
        ASS_CUT_DT_ULTIMA_ATUALIZACAO = SYSDATE,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
    WHERE
        ASS_CNU_ID IN (SELECT CNU.ASS_CNU_ID
                         FROM TB_ASS_CNU_CONVENIO_UNIDADE CNU
                        WHERE CNU.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO);    
    
  end PRC_ASS_CUT_FINALIZAR_VIGENCIA;
