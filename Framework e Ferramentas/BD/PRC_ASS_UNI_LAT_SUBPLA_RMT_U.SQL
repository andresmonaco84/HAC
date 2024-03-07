  --PRC_ASS_UNI_LAT_SUBPLA_RMT_U
  create or replace procedure PRC_ASS_UNI_LAT_SUBPLA_RMT_U
  (
     pASS_USP_ID IN TB_ASS_USP_UNI_LAT_SUB_PLANO.ASS_USP_ID%type,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_USP_UNI_LAT_SUB_PLANO.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_USP_UNI_LAT_SUB_PLANO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_SPL_ID IN TB_ASS_USP_UNI_LAT_SUB_PLANO.CAD_SPL_ID%type,
     pASS_USP_FL_STATUS IN TB_ASS_USP_UNI_LAT_SUB_PLANO.ASS_USP_FL_STATUS%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_USP_UNI_LAT_SUB_PLANO.SEG_USU_ID_USUARIO%type,
     pASS_USP_DT_ULTIMA_ATUALIZACAO IN TB_ASS_USP_UNI_LAT_SUB_PLANO.ASS_USP_DT_ULTIMA_ATUALIZACAO%type,
     pCAD_PLA_ID_PLANO IN TB_ASS_USP_UNI_LAT_SUB_PLANO.CAD_PLA_ID_PLANO%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_UNI_LAT_SUBPLA_RMT_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_ASS_USP_UNI_LAT_SUB_PLANO
    SET	   
        CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE,
        CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO,
        CAD_SPL_ID = pCAD_SPL_ID,
        ASS_USP_FL_STATUS = pASS_USP_FL_STATUS,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        ASS_USP_DT_ULTIMA_ATUALIZACAO = pASS_USP_DT_ULTIMA_ATUALIZACAO,
        CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO 
    WHERE
        ASS_USP_ID = pASS_USP_ID;	
  end PRC_ASS_UNI_LAT_SUBPLA_RMT_U;

