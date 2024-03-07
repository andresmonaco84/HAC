  --PRC_ASS_CNV_DOC_LOCATE_RMT_
  create or replace procedure PRC_ASS_CNV_DOC_LOCATE_RMT_ 
  (
     pASS_CDL_ID IN TB_ASS_CDL_CONV_DOC_LOCATEND.ASS_CDL_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNV_DOC_LOCATE_RMT_
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
        ASS_CDL_ID = pASS_CDL_ID;          
    io_cursor := v_cursor;
  end PRC_ASS_CNV_DOC_LOCATE_RMT_;
