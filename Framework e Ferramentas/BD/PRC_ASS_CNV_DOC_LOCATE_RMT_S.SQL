  --PRC_ASS_CNV_DOC_LOCATE_RMT_S
  create or replace procedure PRC_ASS_CNV_DOC_LOCATE_RMT_S 
  (
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_CDL_CONV_DOC_LOCATEND.CAD_LAT_ID_LOCAL_ATENDIMENTO%type DEFAULT NULL,
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CDL_CONV_DOC_LOCATEND.CAD_CNV_ID_CONVENIO%type DEFAULT NULL,
     pCAD_DOC_ID_DOCUMENTO IN TB_ASS_CDL_CONV_DOC_LOCATEND.CAD_DOC_ID_DOCUMENTO%type DEFAULT NULL,
     pASS_CDL_ID IN TB_ASS_CDL_CONV_DOC_LOCATEND.ASS_CDL_ID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNV_DOC_LOCATE_RMT_S
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_CNV_ID_CONVENIO,
       CAD_DOC_ID_DOCUMENTO,
       ASS_CDL_ID
    FROM TB_ASS_CDL_CONV_DOC_LOCATEND
    WHERE
        (pCAD_LAT_ID_LOCAL_ATENDIMENTO is null OR CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO) AND 
        (pCAD_CNV_ID_CONVENIO is null OR CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO) AND 
        (pCAD_DOC_ID_DOCUMENTO is null OR CAD_DOC_ID_DOCUMENTO = pCAD_DOC_ID_DOCUMENTO) AND 
        (pASS_CDL_ID is null OR ASS_CDL_ID = pASS_CDL_ID);          
    io_cursor := v_cursor;
  end PRC_ASS_CNV_DOC_LOCATE_RMT_S;
