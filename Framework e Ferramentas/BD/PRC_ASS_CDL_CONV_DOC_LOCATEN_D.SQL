create or replace procedure PRC_ASS_CDL_CONV_DOC_LOCATEN_D
  (
    pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_CDL_CONV_DOC_LOCATEND.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CDL_CONV_DOC_LOCATEND.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
     pASS_CDL_ID IN tb_ass_cdl_conv_doc_locatend.ass_cdl_id%TYPE DEFAULT NULL   
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CDL_CONV_DOC_LOCATEND_D
  * 
  *    Data Criacao: 	12/06/2007   Por: Silmara
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_CDL_CONV_DOC_LOCATEND
    WHERE  CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
    AND    CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    OR     ASS_CDL_ID = pASS_CDL_ID;       
  end PRC_ASS_CDL_CONV_DOC_LOCATEN_D;
/
