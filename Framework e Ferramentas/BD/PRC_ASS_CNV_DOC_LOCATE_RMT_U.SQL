  --PRC_ASS_CNV_DOC_LOCATE_RMT_U
  create or replace procedure PRC_ASS_CNV_DOC_LOCATE_RMT_U
  (
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_CDL_CONV_DOC_LOCATEND.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CDL_CONV_DOC_LOCATEND.CAD_CNV_ID_CONVENIO%type,
     pCAD_DOC_ID_DOCUMENTO IN TB_ASS_CDL_CONV_DOC_LOCATEND.CAD_DOC_ID_DOCUMENTO%type,
     pASS_CDL_ID IN TB_ASS_CDL_CONV_DOC_LOCATEND.ASS_CDL_ID%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNV_DOC_LOCATE_RMT_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_ASS_CDL_CONV_DOC_LOCATEND
    SET	   
        CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO,
        CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO,
        CAD_DOC_ID_DOCUMENTO = pCAD_DOC_ID_DOCUMENTO 
    WHERE
        ASS_CDL_ID = pASS_CDL_ID;	
  end PRC_ASS_CNV_DOC_LOCATE_RMT_U;

