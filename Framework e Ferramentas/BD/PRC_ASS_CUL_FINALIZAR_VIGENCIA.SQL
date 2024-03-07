create or replace procedure PRC_ASS_CUL_FINALIZAR_VIGENCIA
  (
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CNU_CONVENIO_UNIDADE.CAD_CNV_ID_CONVENIO%type,
     pASS_CUL_DT_FIM_VIGENCIA IN TB_ASS_CUL_CONV_UNI_LOCATEND.ASS_CUL_DT_FIM_VIGENCIA%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_CUL_CONV_UNI_LOCATEND.SEG_USU_ID_USUARIO%type,
     pASS_CUL_DS_MOTIVO_FIM_VIG IN TB_ASS_CUL_CONV_UNI_LOCATEND.ASS_CUL_DS_MOTIVO_FIM_VIGENCIA%type default NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CUL_FINALIZAR_VIGENCIA
  *
  *    Data Criacao:   19/08/2009  Por: Alexandre M. Muniz
  *    Funcao: Finaliza a vigência de todos os locais de atendimento de
  *    todas as unidades de um convênio.
  *******************************************************************/
  begin
    UPDATE TB_ASS_CUL_CONV_UNI_LOCATEND
    SET
        ASS_CUL_DS_MOTIVO_FIM_VIGENCIA = pASS_CUL_DS_MOTIVO_FIM_VIG,
        ASS_CUL_DT_FIM_VIGENCIA = pASS_CUL_DT_FIM_VIGENCIA,
        ASS_CUL_DT_ULTIMA_ATUALIZACAO = SYSDATE,        
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO        
    WHERE
        ASS_CNU_ID IN (SELECT CNU.ASS_CNU_ID
                         FROM TB_ASS_CNU_CONVENIO_UNIDADE CNU
                        WHERE CNU.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO);

  end PRC_ASS_CUL_FINALIZAR_VIGENCIA;
