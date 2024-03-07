create or replace procedure PRC_ASS_PTA_FINALIZAR_VIGENCIA
  (
     pCAD_CNV_ID_CONVENIO IN TB_CAD_PLA_PLANO.CAD_CNV_ID_CONVENIO%type,
     pCAD_PLA_ID_PLANO IN TB_ASS_CLP_CNV_UND_LOC_PLANO.CAD_PLA_ID_PLANO%type DEFAULT NULL,
     pASS_CLP_DT_FIM_VIGENCIA IN TB_ASS_CLP_CNV_UND_LOC_PLANO.ASS_CLP_DT_FIM_VIGENCIA%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_CLP_CNV_UND_LOC_PLANO.SEG_USU_ID_USUARIO%type,
     pASS_PTA_DS_MOTIVO_FIM_VIG IN TB_ASS_PTA_PLA_TPATEND.ASS_PTA_DS_MOTIVO_FIM_VIGENCIA %type DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PTA_FINALIZAR_VIGENCIA
  *
  *    Data Criacao:    15/09/2009   Por: Alexandre M. Muniz
  *
  *    Funcao: Finalizar a vigência de todos os tipos de atendimento
  *            de um plano de saúde
  *
  *    Data Alteracao: -             Por: -
  *    Alterac?o: -
  *******************************************************************/
  begin

    UPDATE TB_ASS_PTA_PLA_TPATEND
    SET
        ASS_PTA_DT_FIM_VIGENCIA = pASS_CLP_DT_FIM_VIGENCIA,        
        ASS_PTA_DT_ULTIMA_ATUALIZACAO = SYSDATE,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        ASS_PTA_DS_MOTIVO_FIM_VIGENCIA = pASS_PTA_DS_MOTIVO_FIM_VIG
    WHERE
        CAD_PLA_ID_PLANO IN (SELECT PLA.CAD_PLA_ID_PLANO
                               FROM TB_CAD_PLA_PLANO PLA
                              WHERE PLA.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
                                AND (pCAD_PLA_ID_PLANO IS NULL OR PLA.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO));        

  end PRC_ASS_PTA_FINALIZAR_VIGENCIA;
