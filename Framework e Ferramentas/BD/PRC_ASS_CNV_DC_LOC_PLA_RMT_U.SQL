  --PRC_ASS_CNV_DC_LOC_PLA_RMT_U
  create or replace procedure PRC_ASS_CNV_DC_LOC_PLA_RMT_U
  (
     pASS_CDP_ID IN TB_ASS_CDP_CNV_DC_LOC_PLANO.ASS_CDP_ID%type,
     pASS_CDL_ID IN TB_ASS_CDP_CNV_DC_LOC_PLANO.ASS_CDL_ID%type,
     pCAD_PLA_ID_PLANO IN TB_ASS_CDP_CNV_DC_LOC_PLANO.CAD_PLA_ID_PLANO%type,
     pASS_CDP_DT_ULTIMA_ATUALIZACAO IN TB_ASS_CDP_CNV_DC_LOC_PLANO.ASS_CDP_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_CDP_CNV_DC_LOC_PLANO.SEG_USU_ID_USUARIO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNV_DC_LOC_PLA_RMT_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_ASS_CDP_CNV_DC_LOC_PLANO
    SET	   
        ASS_CDL_ID = pASS_CDL_ID,
        CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO,
        ASS_CDP_DT_ULTIMA_ATUALIZACAO = pASS_CDP_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO 
    WHERE
        ASS_CDP_ID = pASS_CDP_ID;	
  end PRC_ASS_CNV_DC_LOC_PLA_RMT_U;

