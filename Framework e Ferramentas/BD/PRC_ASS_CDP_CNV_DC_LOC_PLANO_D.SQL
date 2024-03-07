create or replace procedure PRC_ASS_CDP_CNV_DC_LOC_PLANO_D
  (
     pCAD_PLA_ID_PLANO             IN TB_ASS_CDP_CNV_DC_LOC_PLANO.CAD_PLA_ID_PLANO%TYPE DEFAULT NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_CDL_CONV_DOC_LOCATEND.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
     pCAD_CNV_ID_CONVENIO          IN TB_ASS_CDL_CONV_DOC_LOCATEND.CAD_CNV_ID_CONVENIO%type DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CDP_CNV_DC_LOC_PLANO_D
  * 
  *    Data Criacao: 	28/06/2007         Por: Fabiola Lopes
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
     DELETE FROM TB_ASS_CDP_CNV_DC_LOC_PLANO CDP
     WHERE CDP.ASS_CDL_ID IN ( SELECT CDL.ASS_CDL_ID
                               FROM   TB_ASS_CDL_CONV_DOC_LOCATEND CDL
                               WHERE  CDL.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
                               AND    CDL.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO )
     AND   CDP.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO;
end PRC_ASS_CDP_CNV_DC_LOC_PLANO_D;