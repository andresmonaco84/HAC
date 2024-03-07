  --PRC_ASS_UNILOC_CBO_PRO_RMT_I
  create or replace procedure PRC_ASS_UNILOC_CBO_PRO_RMT_I
  (
     pASS_UCP_QTD_AGEND_PERM_CBOS IN TB_ASS_UCP_UNID_LOC_CBO_PROF.ASS_UCP_QTD_AGEND_PERM_CBOS%type default NULL,
     pASS_UCP_DS_OBS IN TB_ASS_UCP_UNID_LOC_CBO_PROF.ASS_UCP_DS_OBS%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_UCP_UNID_LOC_CBO_PROF.SEG_USU_ID_USUARIO%type,
     pASS_UCP_DT_ULTIMA_ATUALIZACAO IN TB_ASS_UCP_UNID_LOC_CBO_PROF.ASS_UCP_DT_ULTIMA_ATUALIZACAO%type,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_UCP_UNID_LOC_CBO_PROF.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_UCP_UNID_LOC_CBO_PROF.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pTIS_CBO_CD_CBOS IN TB_ASS_UCP_UNID_LOC_CBO_PROF.TIS_CBO_CD_CBOS%type,
     pCAD_PRO_ID_PROFISSIONAL IN TB_ASS_UCP_UNID_LOC_CBO_PROF.CAD_PRO_ID_PROFISSIONAL%type,
     pASS_UCP_FL_STATUS IN TB_ASS_UCP_UNID_LOC_CBO_PROF.ASS_UCP_FL_STATUS%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_UNILOC_CBO_PRO_RMT_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_ASS_UCP_UNID_LOC_CBO_PROF
    (
       ASS_UCP_QTD_AGEND_PERM_CBOS,
       ASS_UCP_DS_OBS,
       SEG_USU_ID_USUARIO,
       ASS_UCP_DT_ULTIMA_ATUALIZACAO,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       TIS_CBO_CD_CBOS,
       CAD_PRO_ID_PROFISSIONAL,
       ASS_UCP_FL_STATUS
    )
    VALUES
    (
	     pASS_UCP_QTD_AGEND_PERM_CBOS,
	     pASS_UCP_DS_OBS,
	     pSEG_USU_ID_USUARIO,
	     pASS_UCP_DT_ULTIMA_ATUALIZACAO,
	     pCAD_UNI_ID_UNIDADE,
	     pCAD_LAT_ID_LOCAL_ATENDIMENTO,
	     pTIS_CBO_CD_CBOS,
	     pCAD_PRO_ID_PROFISSIONAL,
	     pASS_UCP_FL_STATUS
    );
	
  end PRC_ASS_UNILOC_CBO_PRO_RMT_I;

