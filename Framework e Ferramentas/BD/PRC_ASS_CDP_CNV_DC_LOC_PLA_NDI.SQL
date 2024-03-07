create or replace procedure PRC_ASS_CDP_CNV_DC_LOC_PLA_NDI
( pCAD_CNV_ID_CONVENIO          IN TB_ASS_CDL_CONV_DOC_LOCATEND.CAD_CNV_ID_CONVENIO%TYPE,
  pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_CDL_CONV_DOC_LOCATEND.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
  pCAD_PLA_ID_PLANO             IN TB_ASS_CDP_CNV_DC_LOC_PLANO.CAD_PLA_ID_PLANO%TYPE,
  io_cursor OUT PKG_CURSOR.t_cursor)
is
/********************************************************************
  *    Procedure: PRC_ASS_CDP_CNV_DC_LOC_PLA_NDI
  * 
  *    Data Criacao: 	  28/06/2007           Por: Fabiola Lopes
  *    Data Alteracao:	data da altera???#o  Por: Nome do Analista
  *
  *    Funcao: Lista os documentos ja associados
  *
  *******************************************************************/  
v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
  SELECT CDL.ASS_CDL_ID,
         CDL.CAD_LAT_ID_LOCAL_ATENDIMENTO,
         CDL.CAD_CNV_ID_CONVENIO,
         CDL.CAD_DOC_ID_DOCUMENTO,
         CDP.CAD_PLA_ID_PLANO
  FROM   TB_ASS_CDL_CONV_DOC_LOCATEND CDL,
         TB_ASS_CDP_CNV_DC_LOC_PLANO CDP
  WHERE  CDL.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
  AND    ( pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR CDL.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO )
  AND    CDP.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO
  AND    CDL.ASS_CDL_ID = CDP.ASS_CDL_ID;
  io_cursor := v_cursor;
end PRC_ASS_CDP_CNV_DC_LOC_PLA_NDI;