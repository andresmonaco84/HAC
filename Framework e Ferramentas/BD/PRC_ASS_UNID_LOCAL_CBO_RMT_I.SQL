  --PRC_ASS_UNID_LOCAL_CBO_RMT_I
  create or replace procedure PRC_ASS_UNID_LOCAL_CBO_RMT_I
  (
     pTIS_CBO_CD_CBOS IN TB_ASS_ULC_UNID_LOCAL_CBOS.TIS_CBO_CD_CBOS%type,
     pASS_ULC_QTD_ATEND_HORA IN TB_ASS_ULC_UNID_LOCAL_CBOS.ASS_ULC_QTD_ATEND_HORA%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_ULC_UNID_LOCAL_CBOS.SEG_USU_ID_USUARIO%type,
     pASS_ULC_DT_ULTIMA_ATUALIZACAO IN TB_ASS_ULC_UNID_LOCAL_CBOS.ASS_ULC_DT_ULTIMA_ATUALIZACAO%type,
     pASS_ULC_FL_STATUS IN TB_ASS_ULC_UNID_LOCAL_CBOS.ASS_ULC_FL_STATUS%type,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_ULC_UNID_LOCAL_CBOS.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_ULC_UNID_LOCAL_CBOS.CAD_LAT_ID_LOCAL_ATENDIMENTO%type--,
     --pASS_ULC_CD_PROGRAMA_ACS IN TB_ASS_ULC_UNID_LOCAL_CBOS.ASS_ULC_CD_PROGRAMA_ACS%type DEFAULT NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_UNID_LOCAL_CBO_RMT_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_ASS_ULC_UNID_LOCAL_CBOS
    (
       TIS_CBO_CD_CBOS,
       ASS_ULC_QTD_ATEND_HORA,
       SEG_USU_ID_USUARIO,
       ASS_ULC_DT_ULTIMA_ATUALIZACAO,
       ASS_ULC_FL_STATUS,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO--,
     --  ASS_ULC_CD_PROGRAMA_ACS
    )
    VALUES
    (
	     pTIS_CBO_CD_CBOS,
	     pASS_ULC_QTD_ATEND_HORA,
	     pSEG_USU_ID_USUARIO,
	     pASS_ULC_DT_ULTIMA_ATUALIZACAO,
	     pASS_ULC_FL_STATUS,
	     pCAD_UNI_ID_UNIDADE,
	     pCAD_LAT_ID_LOCAL_ATENDIMENTO--,
	   --  pASS_ULC_CD_PROGRAMA_ACS
    );
	
  end PRC_ASS_UNID_LOCAL_CBO_RMT_I;

