create or replace procedure PRC_ASS_CNU_FINALIZAR_VIGENCIA
  (
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CNU_CONVENIO_UNIDADE.CAD_CNV_ID_CONVENIO%type,
     pASS_CNU_DT_FIM_VIGENCIA IN TB_ASS_CNU_CONVENIO_UNIDADE.ASS_CNU_DT_FIM_VIGENCIA%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_CNU_CONVENIO_UNIDADE.SEG_USU_ID_USUARIO%type,
     pASS_CNU_DS_MOTIVO_FIM_VIG IN TB_ASS_CNU_CONVENIO_UNIDADE.ASS_CNU_DS_MOTIVO_FIM_VIGENCIA%type default NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNU_FINALIZAR_VIGENCIA
  *
  *    Data Criacao:   19/08/2009   Por: Alexandre M. Muniz
  *    Funcao: Finaliza a vigência de todas as unidades de um convênio
  *
  *******************************************************************/

  begin

    UPDATE TB_ASS_CNU_CONVENIO_UNIDADE
    SET
        ASS_CNU_DT_FIM_VIGENCIA = pASS_CNU_DT_FIM_VIGENCIA,
        ASS_CNU_DS_MOTIVO_FIM_VIGENCIA = pASS_CNU_DS_MOTIVO_FIM_VIG,
        ASS_CNU_DT_ULTIMA_ATUALIZACAO = sysdate,        
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
    WHERE
        CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO;    

  end PRC_ASS_CNU_FINALIZAR_VIGENCIA;
