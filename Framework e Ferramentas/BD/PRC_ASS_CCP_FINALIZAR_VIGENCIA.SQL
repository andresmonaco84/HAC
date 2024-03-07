create or replace procedure PRC_ASS_CCP_FINALIZAR_VIGENCIA
  (
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CCP_CONV_CLINICA_PROCED.CAD_CNV_ID_CONVENIO%type,
     pASS_CCP_FL_STATUS IN TB_ASS_CCP_CONV_CLINICA_PROCED.ASS_CCP_FL_STATUS%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_CCP_CONV_CLINICA_PROCED.SEG_USU_ID_USUARIO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CCP_FINALIZAR_VIGENCIA
  * 
  *    Data Criacao:   20/08/2009   Por: Alexandre M. Muniz
  *    Data Alteracao:  -  Por -
  *    Alteracao:  -
  *
  *    Funcao: Inativar todos os procedimento de um convênio
  *
  *******************************************************************/  
  begin
  
    UPDATE TB_ASS_CCP_CONV_CLINICA_PROCED
    SET        
        ASS_CCP_DT_ULTIMA_ATUALIZACAO = SYSDATE,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        ASS_CCP_FL_STATUS = pASS_CCP_FL_STATUS
    WHERE
        CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO;
        
  end PRC_ASS_CCP_FINALIZAR_VIGENCIA;
