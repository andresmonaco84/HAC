create or replace procedure PRC_ASS_CDP_CNV_DC_LOC_PLA_DIS
( pCAD_CNV_ID_CONVENIO          IN TB_ASS_CDL_CONV_DOC_LOCATEND.CAD_CNV_ID_CONVENIO%TYPE,
  pCAD_LAT_ID_LOCAL_ATENDIMENTO  IN TB_ASS_CDL_CONV_DOC_LOCATEND.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE,
  pCAD_PLA_ID_PLANO             IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE,
  io_cursor OUT PKG_CURSOR.t_cursor) 
is
/********************************************************************
  *    Procedure: PRC_ASS_CDP_CNV_DC_LOC_PLA_DIS
  * 
  *    Data Criacao: 	  28/06/2007         Por: Fabiola Lopes
  *    Data Alteracao:	data da alteraÃ§Ã£o  Por: Nome do Analista
  *
  *    Funcao: Lista os documentos disponíveis para associação
  *
  *******************************************************************/  
v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
  SELECT CDL.ASS_CDL_ID,
         CDL.CAD_LAT_ID_LOCAL_ATENDIMENTO,
         CDL.CAD_CNV_ID_CONVENIO,
         CDL.CAD_DOC_ID_DOCUMENTO
  FROM   TB_ASS_CDL_CONV_DOC_LOCATEND CDL
  WHERE  CDL.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
  AND    CDL.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
  AND    NOT EXISTS ( SELECT 1
                      FROM   TB_ASS_CDP_CNV_DC_LOC_PLANO CDP
                      WHERE  CDL.ASS_CDL_ID = CDP.ASS_CDL_ID
                      AND    cdp.cad_pla_id_plano = pCAD_PLA_ID_PLANO );
  io_cursor := v_cursor;
end PRC_ASS_CDP_CNV_DC_LOC_PLA_DIS;
/
