create or replace procedure PRC_CAD_CHS_CONV_HIST_STATUS_U
  (
     pCAD_CHS_ID IN TB_CAD_CHS_CONV_HISTO_STATUS.CAD_CHS_ID%type,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CHS_CONV_HISTO_STATUS.CAD_CNV_ID_CONVENIO%type,
     pCAD_CHS_DT_INI_VIGENCIA IN TB_CAD_CHS_CONV_HISTO_STATUS.CAD_CHS_DT_INI_VIGENCIA%type,
     pCAD_CHS_DT_FIM_VIGENCIA IN TB_CAD_CHS_CONV_HISTO_STATUS.CAD_CHS_DT_FIM_VIGENCIA%type default NULL,
     pCAD_CHS_FL_STATUS IN TB_CAD_CHS_CONV_HISTO_STATUS.CAD_CHS_FL_STATUS%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_CHS_CONV_HISTO_STATUS.SEG_USU_ID_USUARIO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_CHS_CONV_HIST_STATUS_U
  *
  *    Data Criacao: 	20/06/2007   Por: Andrea Cazuca
  *    Funcao: Altera Status do Conv??nio
  *
  *	   Data Alteracao: 24/08/09      Por: Alexandre M. Muniz
  *    Descrição: Desabilitação da condição CAD_CHS_DT_FIM_VIGENCIA IS NULL 
  *               na cláusula where
  *******************************************************************/
  begin

    UPDATE TB_CAD_CHS_CONV_HISTO_STATUS
    SET
        CAD_CHS_DT_INI_VIGENCIA = pCAD_CHS_DT_INI_VIGENCIA,
        CAD_CHS_DT_FIM_VIGENCIA = pCAD_CHS_DT_FIM_VIGENCIA,
        CAD_CHS_FL_STATUS = pCAD_CHS_FL_STATUS,
        CAD_CHS_DT_ULTIMA_ATUALIZACAO = sysdate,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
    WHERE
        (pCAD_CHS_ID is null OR CAD_CHS_ID = pCAD_CHS_ID)
    AND (pCAD_CNV_ID_CONVENIO is null OR CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO);
    --AND CAD_CHS_DT_FIM_VIGENCIA IS NULL;
  end PRC_CAD_CHS_CONV_HIST_STATUS_U;
