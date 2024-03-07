create or replace procedure PRC_ASS_CTP_FINALIZAR_VIGENCIA
  (
     pCAD_CNV_ID_CONVENIO IN TB_CAD_PLA_PLANO.CAD_CNV_ID_CONVENIO%type,
     pCAD_PLA_ID_PLANO IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.CAD_PLA_ID_PLANO%type DEFAULT NULL,
     pASS_CTP_DT_FIM_VIGENCIA IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.ASS_CTP_DT_FIM_VIGENCIA%type DEFAULT NULL,     
     pSEG_USU_ID_USUARIO IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.SEG_USU_ID_USUARIO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CTP_FINALIZAR_VIGENCIA
  *
  *    Data Criacao:   27/08/2009   Por: Alexandre M. Muniz
  *    Funcao: Finalizar a vigência de todos os tipos de acomodação
  *            de um plano de saúde
  *
  *    Data Alteracao:  -  Por: -
  *
  *******************************************************************/
  begin
  
    UPDATE TB_ASS_CTP_CNV_UN_TPACOM_PLA
    SET
        ASS_CTP_DT_FIM_VIGENCIA = pASS_CTP_DT_FIM_VIGENCIA,        
        ASS_CTP_DT_ULTIMA_ATUALIZACAO = SYSDATE,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
    WHERE
        ASS_CTP_DT_FIM_VIGENCIA IS NULL
    AND CAD_PLA_ID_PLANO IN (SELECT PLA.CAD_PLA_ID_PLANO
                               FROM TB_CAD_PLA_PLANO PLA
                              WHERE PLA.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
                                AND (pCAD_PLA_ID_PLANO IS NULL OR PLA.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO));
        
  end PRC_ASS_CTP_FINALIZAR_VIGENCIA;
